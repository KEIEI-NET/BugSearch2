using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar = DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;//ADD  2011/08/05

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���R���[(����`�[)����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���DataSource�̃e�[�u���������s���܂��B</br>
    /// <br>               </br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2008.06.03</br>
    /// <br></br>
    /// <br>Update Note  : 2009.07.02  22018 ��� ���b</br>
    /// <br>             : �c�{�p�̎��Ж����ڂ�ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2009.07.27 ���痈</br>
    /// <br>               ���R���[�i����`�[�jA800��ǉ�����</br>
    /// <br></br>
    /// <br>Update Note  : 2009.08.05  22018 ��� ���b</br>
    /// <br>             : A700�̍��v���󎚐����PM7�Ɠ����e�ɏC���B�i�󎚈ʒu��A600�ƈقȂ�j</br>
    /// <br></br>
    /// <br>Update Note  : 2009.09.03  22018 ��� ���b</br>
    /// <br>             : �c�{�p�̓��Ӑ於�̂Ő������󎚂���Ȃ����ڂ�����ׁA�C���B</br>
    /// <br></br>
    /// <br>Update Note  : 2009/10/27  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2009/11/02  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2009/11/17  30531 ��� �r��</br>
    /// <br>             : ���Ӑ於�̂P�{���Ӑ於�̂Q�{�h�̂ŁA���Ӑ於�̂P�{�Q��20���܂ł����󎚂��Ȃ������ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2009/12/03  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/01  30531 ��� �r��</br>
    /// <br>             : Mantis�y15082�z�`�[������ڂ�ǉ��B(�艿���z����łȂ�5����)�y�����ʁz
    /// <br></br>
    /// <br>Update Note  : 2010/03/19  30531 ��� �r��</br>
    /// <br>             : Mantis�y15179�z�`�[������ڂ�ǉ��B(���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��))�y�x�m���i��Q�Ή��z</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/24  22018 ��� ���b</br>
    /// <br>             : �p�q�R�[�h�̈���@�\��ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/31  22018 ��� ���b</br>
    /// <br>             : �p�q�R�[�h�̓`�[�ԍ���9���ɕύX�B(��������9���捞�݉\�ɕύX�ƂȂ��)</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/13  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��B�i�e�����A�e���z�Ȃǁj�y�X�암�i�ʁz</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/03  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��B�i���ʍ��v�A������z(���ד]�Ŏ��Ȃ�))�y�������i�ʁz</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/24  30531 ��� �r��</br>
    /// <br>             : �Ԏ햼���S�p�����Ȃ��ꍇ�A���p�ɕϊ����鏈����ǉ��y������Q�Ή��z</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/29  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��B�i�`�[���l(��i)�A�`�[���l�i���i�j�A���Ӑ於�́j�y�O������ʁz</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/05  30531 ��� �r��</br>
    /// <br>             : �`�[������ڂ�ǉ��i�C�G���[�n�b�g�p����`�[�敪�j�y�������i�ʁz</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/06  30517 �Ė� �x��</br>
    /// <br>             : QR�R�[�h�g�у��[���Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/09  30531 ��� �r��</br>
    /// <br>             : �`�[���l(��i�E���i)�̈󎚏����C���y�O������ʁz</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/09  30517 �Ė� �x��</br>
    /// <br>             : QR�R�[�h�g�у��[���Ή�</br>
    /// <br>               �@����`�[���͂̂t�h���"�p�q�R�[�h�쐬"�`�F�b�N�{�b�N�X�l���g�p�����󎚔��f�̒ǉ�</br>
    /// <br>Update Note  : 2011/02/16  ����</br>
    /// <br>               ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
    /// <br>Update Note  : 2011/07/19  �����g</br>
    /// <br>               �����񓚋敪(SCM)�̒ǉ�</br>
    /// <br>Update Note  : 2011/08/05  �����g</br>
    /// <br>               ��Q�� #23404: �v���W�F�N�gNo1 PCC for NS�iSCM�j���� SCM�A�g�ۑ�ꗗ��59�Ή�</br>
    /// <br>Update Note  : 2011/08/08  �����g</br>
    /// <br>               ��Q�� #23459: SCM�I�v�V�����R�[�h�𗘗p</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 �����  �A��985</br>
    /// <br>             �@�yPM�v�]����9���z�M���zRedmine#23541 �A��985�̑Ή�</br> 
    /// <br></br>
    /// <br>Update Note  : 2011/08/17  caohh</br>
    /// <br>               �����[�g�`���F�`�[P001�Ή�</br>
    /// <br>Update Note  : 2011/09/13 �����  �A��985</br>
    /// <br>             �@�yPM�v�]����9���z�M���zRedmine##24920 �A��985�̑Ή�</br> 
    /// <br>Update Note  : 2012/02/07 �����H</br>
    /// <br>�Ǘ��ԍ�     : 10707327-00 2012/03/28�z�M��</br>
    /// <br>               Redmine#28291�@�������F�󎚎��G���[�ɂ��Ă̏C��</br>
    /// <br>Update Note  : 2013/02/19 xuyb</br>
    /// <br>�Ǘ��ԍ�     : 2013/03/13�z�M��</br>
    /// <br>               Redmine#34615�@No.1639�[�i��  �Ԏ햼���p�J�i�̑Ή�</br>
    /// <br>Update Note  : 2013/04/15 donggy</br>
    /// <br>�Ǘ��ԍ�     : 10801804-00 2013/05/15�z�M��</br>
    /// <br>               Redmine#35275�@���Ӑ�d�q�����œ`�[�^�C�v�`�W�O�O�̓`�[���Ĕ��s����ƃG���[����������̑Ή�</br>
    /// <br>Update Note  : 2017/08/30 3H �k�P�N</br>
    /// <br>�Ǘ��ԍ�     : 11370074-00 �n���f�B�Ή��i2���j</br>
    /// <br></br>
    /// </remarks>
    internal class PMHNB08001PB
    {
        

        # region [public static readonly �����o]
        /// <summary>���R���[����`�[�e�[�u��</summary>
        public static readonly string ct_TBL_FREPSALESSLIP = "FREPSALESSLIP";
        /// <summary>����y�[�W���R�s�[�J�E���gcolumn����</summary>
        public static readonly string ct_InPageCopyCount = "PMHNB08001P.INPAGECOPYCOUNT";
        /// <summary>���ʃ^�C�g���P</summary>
        public static readonly string ct_InPageCopyTitle1 = "PMHNB08001P.INPAGECOPYTITLE1";
        /// <summary>���ʃ^�C�g���Q</summary>
        public static readonly string ct_InPageCopyTitle2 = "PMHNB08001P.INPAGECOPYTITLE2";
        /// <summary>���ʃ^�C�g���R</summary>
        public static readonly string ct_InPageCopyTitle3 = "PMHNB08001P.INPAGECOPYTITLE3";
        /// <summary>���ʃ^�C�g���S</summary>
        public static readonly string ct_InPageCopyTitle4 = "PMHNB08001P.INPAGECOPYTITLE4";

        /// <summary>�Ő�</summary>
        public static readonly string ct_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>�󒍐�</summary>
        public static readonly string ct_AcptCount = "DPRT.ACPTCOUNTRF";
        /// <summary>�o�א�</summary>
        public static readonly string ct_ShipCount = "DPRT.SHIPCUONTRF";
        /// <summary>(�擪)�ޕʌ^���n�C�t��</summary>
        public static readonly string ct_HCategoryHyp = "HPRT.CATEGORYHYPRF";
        /// <summary>�ޕʌ^���n�C�t��</summary>
        public static readonly string ct_DCategoryHyp = "DPRT.CATEGORYHYPRF";
        /// <summary>�`�[�f�[�^�p�q�R�[�h</summary>
        public static readonly string ct_QRCode = "HPRT.QRCODERF";
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// <summary>�`�[�f�[�^�p�q�R�[�h(�Í��OCSV�f�[�^)</summary>
        public static readonly string ct_QRCodeSource = "HPRT.QRCODESOURCERF";
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
        ///// <summary>�q�ɃR�[�h�i�^�C�g���P�E�Q�j</summary>
        //public static readonly string ct_DWarehouseCodeRF = "DPRT.WAREHOUSECODERF";
        ///// <summary>�q�ɖ��i�^�C�g���P�E�Q�j</summary>
        //public static readonly string ct_DWarehouseNameRF = "DPRT.WAREHOUSENAMERF";
        ///// <summary>�I�ԁi�^�C�g���P�E�Q�j</summary>
        //public static readonly string ct_DWarehouseShelfNoRF = "DPRT.WAREHOUSESHELFNORF";
        /// <summary>�d����R�[�h�i���̂݁j</summary>
        public static readonly string ct_SupplierCdExtra = "DPRT.SUPPLIERCDEXTRARF";
        /// <summary>�I�ԁi���Ӑ撍�ԂȂ����j</summary>
        public static readonly string ct_ShelfNoExtra = "DPRT.SHELFNOEXTRARF";

        /// <summary>(Label)����Ń^�C�g��</summary>
        public static readonly string ct_TaxTitle = "PMHNB08001P.TAXTITLE";
        /// <summary>(Label)���v�^�C�g��</summary>
        public static readonly string ct_SubTotalTitle = "PMHNB08001P.SUBTOTALTITLE";

        // --- ADD  ���痈  2009.07.27 ---------->>>>>
        /// <summary>(Label)�o�א��}�C�i�X����</summary>
        public static readonly string ct_ShipmentCntMinusSignRF = "PMHNB08001P.SHIPMENTCNTMINUSSIGNRF";
        /// <summary>(Label)������z�i�Ŕ����j������z�}�C�i�X����</summary>
        public static readonly string ct_SalesMoneyTaxExcMinusSignRF = "PMHNB08001P.SALESMONEYTAXEXCMINUSSIGNRF";
        /// <summary>(Label)AB�{���������z�}�C�i�X����</summary>
        public static readonly string ct_ABHqSalesUnitCostMinusSignRF = "PMHNB08001P.ABHQSALESUNITCOSTMINUSSIGNRF";
        // --- ADD  ���痈  2009.07.27 ----------<<<<<
        // --- ADD  ���r��  2010/03/01 ---------->>>>>
        /// <summary>(Label)�ېō��v���z���e����</summary>
        public static readonly string ct_SalesTotalTaxIncTitle = "PMHNB08001P.SALESTOTALTAXINCTITLE";
        // --- ADD  ���r��  2010/03/01 ----------<<<<<

        // --- ADD ����� 2011/08/15---------->>>>>
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�P</summary>
        public static readonly string ct_SlipTitle11 = "PMHNB08001P.SLIPTITLE11";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�Q</summary>
        public static readonly string ct_SlipTitle12 = "PMHNB08001P.SLIPTITLE12";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�R</summary>
        public static readonly string ct_SlipTitle13 = "PMHNB08001P.SLIPTITLE13";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�S</summary>
        public static readonly string ct_SlipTitle14 = "PMHNB08001P.SLIPTITLE14";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�T</summary>
        public static readonly string ct_SlipTitle15 = "PMHNB08001P.SLIPTITLE15";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�P</summary>
        public static readonly string ct_SlipTitle21 = "PMHNB08001P.SLIPTITLE21";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�Q</summary>
        public static readonly string ct_SlipTitle22 = "PMHNB08001P.SLIPTITLE22";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�R</summary>
        public static readonly string ct_SlipTitle23 = "PMHNB08001P.SLIPTITLE23";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�S</summary>
        public static readonly string ct_SlipTitle24 = "PMHNB08001P.SLIPTITLE24";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�T</summary>
        public static readonly string ct_SlipTitle25 = "PMHNB08001P.SLIPTITLE25";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�P</summary>
        public static readonly string ct_SlipTitle31 = "PMHNB08001P.SLIPTITLE31";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�Q</summary>
        public static readonly string ct_SlipTitle32 = "PMHNB08001P.SLIPTITLE32";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�R</summary>
        public static readonly string ct_SlipTitle33 = "PMHNB08001P.SLIPTITLE33";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�S</summary>
        public static readonly string ct_SlipTitle34 = "PMHNB08001P.SLIPTITLE34";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�T</summary>
        public static readonly string ct_SlipTitle35 = "PMHNB08001P.SLIPTITLE35";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�P</summary>
        public static readonly string ct_SlipTitle41 = "PMHNB08001P.SLIPTITLE41";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�Q</summary>
        public static readonly string ct_SlipTitle42 = "PMHNB08001P.SLIPTITLE42";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�R</summary>
        public static readonly string ct_SlipTitle43 = "PMHNB08001P.SLIPTITLE43";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�S</summary>
        public static readonly string ct_SlipTitle44 = "PMHNB08001P.SLIPTITLE44";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�T</summary>
        public static readonly string ct_SlipTitle45 = "PMHNB08001P.SLIPTITLE45";
        // --- ADD ����� 2011/08/15----------<<<<<
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        # region [private static �����o]
        /// <summary>���|�[�g���ڃf�B�N�V���i��</summary>
        private static Dictionary<string, string> stc_reportItemDic;
        // --- ADD  ���r��  2010/03/01 ---------->>>>>        
        //private static PriceTaxCalculator stc_priceTaxCalculator = new PriceTaxCalculator();
        private static PriceTaxCalculator stc_priceTaxCalculator;
        // --- ADD  ���r��  2010/03/01 ----------<<<<<
        // --- ADD  ���r��  2010/05/13 ---------->>>>>
        private static GrossProfitCalculator stc_grossProfitCalculator;
        // --- ADD  ���r��  2010/05/13 ----------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

        // --- ADD  ���r��  2010/06/29 ---------->>>>>
        private static SlipPrintParameterofCount stc_slipPrintParameterofCount;
        // --- ADD  ���r��  2010/06/29 ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        # region [public static �����o]
        /// <summary>���|�[�g���ڃf�B�N�V���i��</summary>
        public static Dictionary<string, string> ReportItemDic
        {
            get
            {
                if ( stc_reportItemDic == null )
                {
                    stc_reportItemDic = new Dictionary<string, string>();
                }
                return stc_reportItemDic;
            }
            set { stc_reportItemDic = value; }
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD       
        

        # region [�f�[�^�e�[�u������]
        /// <summary>
        /// �f�[�^�e�[�u�����������i�X�L�[�}��`�j
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>
        /// <br>Update Note  : 2017/08/30 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�     : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// </remarks>
        public static DataTable CreateFrePSalesSlipTable( int index )
        {
            DataTable table = new DataTable( ct_TBL_FREPSALESSLIP + index.ToString() );

            # region [�X�L�[�}��`�i�`�[���ځj]
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACPTANODRSTATUSRF", typeof( Int32 ) ) );  // �󒍃X�e�[�^�X
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPNUMRF", typeof( string ) ) );  // ����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SECTIONCODERF", typeof( string ) ) );  // ���_�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SUBSECTIONCODERF", typeof( Int32 ) ) );  // ����R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEBITNOTEDIVRF", typeof( Int32 ) ) );  // �ԓ`�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEBITNLNKSALESSLNUMRF", typeof( string ) ) );  // �ԍ��A������`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPCDRF", typeof( Int32 ) ) );  // ����`�[�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESGOODSCDRF", typeof( Int32 ) ) );  // ���㏤�i�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACCRECDIVCDRF", typeof( Int32 ) ) );  // ���|�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SEARCHSLIPDATERF", typeof( Int32 ) ) );  // �`�[�������t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SHIPMENTDAYRF", typeof( Int32 ) ) );  // �o�ד��t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDATERF", typeof( Int32 ) ) );  // ������t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDUPADATERF", typeof( Int32 ) ) );  // �v����t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELAYPAYMENTDIVRF", typeof( Int32 ) ) );  // �����敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEFORMNORF", typeof( string ) ) );  // ���Ϗ��ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEDIVIDERF", typeof( Int32 ) ) );  // ���ϋ敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTCODERF", typeof( string ) ) );  // ������͎҃R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTNAMERF", typeof( string ) ) );  // ������͎Җ���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEECDRF", typeof( string ) ) );  // ��t�]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEENMRF", typeof( string ) ) );  // ��t�]�ƈ�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEECDRF", typeof( string ) ) );  // �̔��]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEENMRF", typeof( string ) ) );  // �̔��]�ƈ�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF", typeof( Int32 ) ) );  // ���z�\�����@�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TTLAMNTDISPRATEAPYRF", typeof( Int32 ) ) );  // ���z�\���|���K�p�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESTOTALTAXINCRF", typeof( Int64 ) ) );  // ����`�[���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESTOTALTAXEXCRF", typeof( Int64 ) ) );  // ����`�[���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) );  // ���㏬�v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) );  // ���㏬�v�i�Ŕ����j
            //table.Columns.Add( new DataColumn( "SALESSLIPRF.SALSENETPRICERF", typeof( Int64 ) ) );  // ���㐳�����z
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXRF", typeof( Int64 ) ) );  // ���㏬�v�i�Łj
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDSALESOUTTAXRF", typeof( Int64 ) ) );  // ����O�őΏۊz
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDSALESINTAXRF", typeof( Int64 ) ) );  // ������őΏۊz
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALSUBTTLSUBTOTAXFRERF", typeof( Int64 ) ) );  // ���㏬�v��ېőΏۊz
            //table.Columns.Add( new DataColumn( "SALESSLIPRF.SALSEOUTTAXRF", typeof( Int64 ) ) );  // ������z����Ŋz�i�O�Łj
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALAMNTCONSTAXINCLURF", typeof( Int64 ) ) );  // ������z����Ŋz�i���Łj
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDISTTLTAXEXCRF", typeof( Int64 ) ) );  // ����l�����z�v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDSALESDISOUTTAXRF", typeof( Int64 ) ) );  // ����l���O�őΏۊz���v
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDSALESDISINTAXRF", typeof( Int64 ) ) );  // ����l�����őΏۊz���v
            //table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDSALSEDISTAXFRERF", typeof( Int64 ) ) );  // ����l����ېőΏۊz���v
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDISOUTTAXRF", typeof( Int64 ) ) );  // ����l������Ŋz�i�O�Łj
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDISTTLTAXINCLURF", typeof( Int64 ) ) );  // ����l������Ŋz�i���Łj
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TOTALCOSTRF", typeof( Int64 ) ) );  // �������z�v
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CONSTAXLAYMETHODRF", typeof( Int32 ) ) );  // ����œ]�ŕ���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CONSTAXRATERF", typeof( Double ) ) );  // ����Őŗ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRACTIONPROCCDRF", typeof( Int32 ) ) );  // �[�������敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACCRECCONSTAXRF", typeof( Int64 ) ) );  // ���|�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.AUTODEPOSITCDRF", typeof( Int32 ) ) );  // ���������敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.AUTODEPOSITSLIPNORF", typeof( Int32 ) ) );  // ���������`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEPOSITALLOWANCETTLRF", typeof( Int64 ) ) );  // �����������v�z
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEPOSITALWCBLNCERF", typeof( Int64 ) ) );  // ���������c��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CLAIMCODERF", typeof( Int32 ) ) );  // ������R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CLAIMSNMRF", typeof( string ) ) );  // �����旪��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERCODERF", typeof( Int32 ) ) );  // ���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAMERF", typeof( string ) ) );  // ���Ӑ於��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAME2RF", typeof( string ) ) );  // ���Ӑ於��2
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERSNMRF", typeof( string ) ) );  // ���Ӑ旪��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.HONORIFICTITLERF", typeof( string ) ) );  // �h��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEECODERF", typeof( Int32 ) ) );  // �[�i��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEENAMERF", typeof( string ) ) );  // �[�i�於��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEENAME2RF", typeof( string ) ) );  // �[�i�於��2
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEEPOSTNORF", typeof( string ) ) );  // �[�i��X�֔ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEEADDR1RF", typeof( string ) ) );  // �[�i��Z��1(�s���{���s��S�E�����E��)
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEEADDR3RF", typeof( string ) ) );  // �[�i��Z��3(�Ԓn)
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEEADDR4RF", typeof( string ) ) );  // �[�i��Z��4(�A�p�[�g����)
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEETELNORF", typeof( string ) ) );  // �[�i��d�b�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEEFAXNORF", typeof( string ) ) );  // �[�i��FAX�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PARTYSALESLIPNUMRF", typeof( string ) ) );  // �����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTERF", typeof( string ) ) );  // �`�[���l
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTE2RF", typeof( string ) ) );  // �`�[���l�Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RETGOODSREASONDIVRF", typeof( Int32 ) ) );  // �ԕi���R�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RETGOODSREASONRF", typeof( string ) ) );  // �ԕi���R
            table.Columns.Add( new DataColumn( "SALESSLIPRF.REGIPROCDATERF", typeof( Int32 ) ) );  // ���W������
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CASHREGISTERNORF", typeof( Int32 ) ) );  // ���W�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.POSRECEIPTNORF", typeof( Int32 ) ) );  // POS���V�[�g�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DETAILROWCOUNTRF", typeof( Int32 ) ) );  // ���׍s��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.EDISENDDATERF", typeof( Int32 ) ) );  // �d�c�h���M��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.EDITAKEINDATERF", typeof( Int32 ) ) );  // �d�c�h�捞��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.UOEREMARK1RF", typeof( string ) ) );  // �t�n�d���}�[�N�P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.UOEREMARK2RF", typeof( string ) ) );  // �t�n�d���}�[�N�Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPPRINTFINISHCDRF", typeof( Int32 ) ) );  // �`�[���s�ϋ敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPPRINTDATERF", typeof( Int32 ) ) );  // ����`�[���s��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.BUSINESSTYPECODERF", typeof( Int32 ) ) );  // �Ǝ�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.BUSINESSTYPENAMERF", typeof( string ) ) );  // �Ǝ햼��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ORDERNUMBERRF", typeof( string ) ) );  // �����ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELIVEREDGOODSDIVRF", typeof( Int32 ) ) );  // �[�i�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELIVEREDGOODSDIVNMRF", typeof( string ) ) );  // �[�i�敪����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESAREACODERF", typeof( Int32 ) ) );  // �̔��G���A�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESAREANAMERF", typeof( string ) ) );  // �̔��G���A����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.COMPLETECDRF", typeof( Int32 ) ) );  // �ꎮ�`�[�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.STOCKGOODSTTLTAXEXCRF", typeof( Int64 ) ) );  // �݌ɏ��i���v���z�i�Ŕ��j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PUREGOODSTTLTAXEXCRF", typeof( Int64 ) ) );  // �������i���v���z�i�Ŕ��j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.LISTPRICEPRINTDIVRF", typeof( Int32 ) ) );  // �艿����敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ERANAMEDISPCD1RF", typeof( Int32 ) ) );  // �����\���敪�P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATAXDIVCDRF", typeof( Int32 ) ) );  // ���Ϗ���ŋ敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEFORMPRTCDRF", typeof( Int32 ) ) );  // ���Ϗ�����敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATESUBJECTRF", typeof( string ) ) );  // ���ό���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FOOTNOTES1RF", typeof( string ) ) );  // �r���P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FOOTNOTES2RF", typeof( string ) ) );  // �r���Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATETITLE1RF", typeof( string ) ) );  // ���σ^�C�g���P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATETITLE2RF", typeof( string ) ) );  // ���σ^�C�g���Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATETITLE3RF", typeof( string ) ) );  // ���σ^�C�g���R
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATETITLE4RF", typeof( string ) ) );  // ���σ^�C�g���S
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATETITLE5RF", typeof( string ) ) );  // ���σ^�C�g���T
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATENOTE1RF", typeof( string ) ) );  // ���ϔ��l�P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATENOTE2RF", typeof( string ) ) );  // ���ϔ��l�Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATENOTE3RF", typeof( string ) ) );  // ���ϔ��l�R
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATENOTE4RF", typeof( string ) ) );  // ���ϔ��l�S
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATENOTE5RF", typeof( string ) ) );  // ���ϔ��l�T
            table.Columns.Add( new DataColumn( "SECINFOSETRF.SECTIONGUIDENMRF", typeof( string ) ) );  // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SECINFOSETRF.SECTIONGUIDESNMRF", typeof( string ) ) );  // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SECINFOSETRF.COMPANYNAMECD1RF", typeof( Int32 ) ) );  // ���Ж��̃R�[�h1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRRF", typeof( string ) ) );  // ����PR��
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME1RF", typeof( string ) ) );  // ���Ж���1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME2RF", typeof( string ) ) );  // ���Ж���2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.POSTNORF", typeof( string ) ) );  // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS1RF", typeof( string ) ) );  // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS3RF", typeof( string ) ) );  // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS4RF", typeof( string ) ) );  // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO1RF", typeof( string ) ) );  // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO2RF", typeof( string ) ) );  // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO3RF", typeof( string ) ) );  // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE1RF", typeof( string ) ) );  // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE2RF", typeof( string ) ) );  // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE3RF", typeof( string ) ) );  // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.TRANSFERGUIDANCERF", typeof( string ) ) );  // ��s�U���ē���
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO1RF", typeof( string ) ) );  // ��s����1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO2RF", typeof( string ) ) );  // ��s����2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO3RF", typeof( string ) ) );  // ��s����3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE1RF", typeof( string ) ) );  // ���Аݒ�E�v1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE2RF", typeof( string ) ) );  // ���Аݒ�E�v2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGEINFODIVRF", typeof( Int32 ) ) );  // �摜���敪
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGEINFOCODERF", typeof( Int32 ) ) );  // �摜���R�[�h
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYURLRF", typeof( string ) ) );  // ����URL
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRSENTENCE2RF", typeof( string ) ) );  // ����PR��2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF", typeof( string ) ) );  // �摜�󎚗p�R�����g1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF", typeof( string ) ) );  // �摜�󎚗p�R�����g2
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) );  // ���Љ摜
            table.Columns.Add( new DataColumn( "SUBSECTIONRF.SUBSECTIONNAMERF", typeof( string ) ) );  // ���喼��
            table.Columns.Add( new DataColumn( "EMPINP.KANARF", typeof( string ) ) );  // ������͎҃J�i
            table.Columns.Add( new DataColumn( "EMPINP.SHORTNAMERF", typeof( string ) ) );  // ������͎ҒZ�k����
            table.Columns.Add( new DataColumn( "EMPFRT.KANARF", typeof( string ) ) );  // ��t�]�ƈ��J�i
            table.Columns.Add( new DataColumn( "EMPFRT.SHORTNAMERF", typeof( string ) ) );  // ��t�]�ƈ��Z�k����
            table.Columns.Add( new DataColumn( "EMPSAL.KANARF", typeof( string ) ) );  // �̔��]�ƈ��J�i
            table.Columns.Add( new DataColumn( "EMPSAL.SHORTNAMERF", typeof( string ) ) );  // �̔��]�ƈ��Z�k����
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTOMERSUBCODERF", typeof( string ) ) );  // ������T�u�R�[�h
            table.Columns.Add( new DataColumn( "CSTCLM.NAMERF", typeof( string ) ) );  // �����於��
            table.Columns.Add( new DataColumn( "CSTCLM.NAME2RF", typeof( string ) ) );  // �����於��2
            table.Columns.Add( new DataColumn( "CSTCLM.HONORIFICTITLERF", typeof( string ) ) );  // ������h��
            table.Columns.Add( new DataColumn( "CSTCLM.KANARF", typeof( string ) ) );  // ������J�i
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTOMERSNMRF", typeof( string ) ) );  // �����旪��
            table.Columns.Add( new DataColumn( "CSTCLM.OUTPUTNAMECODERF", typeof( Int32 ) ) );  // �����揔���R�[�h
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE1RF", typeof( Int32 ) ) );  // �����敪�̓R�[�h1
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE2RF", typeof( Int32 ) ) );  // �����敪�̓R�[�h2
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE3RF", typeof( Int32 ) ) );  // �����敪�̓R�[�h3
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE4RF", typeof( Int32 ) ) );  // �����敪�̓R�[�h4
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE5RF", typeof( Int32 ) ) );  // �����敪�̓R�[�h5
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE6RF", typeof( Int32 ) ) );  // �����敪�̓R�[�h6
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE1RF", typeof( string ) ) );  // ��������l1
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE2RF", typeof( string ) ) );  // ��������l2
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE3RF", typeof( string ) ) );  // ��������l3
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE4RF", typeof( string ) ) );  // ��������l4
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE5RF", typeof( string ) ) );  // ��������l5
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE6RF", typeof( string ) ) );  // ��������l6
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE7RF", typeof( string ) ) );  // ��������l7
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE8RF", typeof( string ) ) );  // ��������l8
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE9RF", typeof( string ) ) );  // ��������l9
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE10RF", typeof( string ) ) );  // ��������l10
            table.Columns.Add( new DataColumn( "CSTCST.CUSTOMERSUBCODERF", typeof( string ) ) );  // ���Ӑ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "CSTCST.NAMERF", typeof( string ) ) );  // ���Ӑ於��
            table.Columns.Add( new DataColumn( "CSTCST.NAME2RF", typeof( string ) ) );  // ���Ӑ於��2
            table.Columns.Add( new DataColumn( "CSTCST.HONORIFICTITLERF", typeof( string ) ) );  // ���Ӑ�h��
            table.Columns.Add( new DataColumn( "CSTCST.KANARF", typeof( string ) ) );  // ���Ӑ�J�i
            table.Columns.Add( new DataColumn( "CSTCST.CUSTOMERSNMRF", typeof( string ) ) );  // ���Ӑ旪��
            table.Columns.Add( new DataColumn( "CSTCST.OUTPUTNAMECODERF", typeof( Int32 ) ) );  // ���Ӑ揔���R�[�h
            // ---- ADD caohh 2011/08/17 ------>>>>>
            table.Columns.Add(new DataColumn("CSTCST.POSTNORF", typeof(string)));       // ���Ӑ�X�֔ԍ�
            table.Columns.Add(new DataColumn("CSTCST.ADDRESS1RF", typeof(string)));     // ���Ӑ�Z��1�i�s���{���s��S�E�����E���j 
            table.Columns.Add(new DataColumn("CSTCST.ADDRESS3RF", typeof(string)));     // ���Ӑ�Z��3�i�Ԓn�j
            table.Columns.Add(new DataColumn("CSTCST.ADDRESS4RF", typeof(string)));     // ���Ӑ�Z��4�i�A�p�[�g���́j
            table.Columns.Add(new DataColumn("CSTCST.HOMETELNORF", typeof(string)));    // ���Ӑ�d�b�ԍ��i����j
            table.Columns.Add(new DataColumn("CSTCST.OFFICETELNORF", typeof(string)));  // ���Ӑ�d�b�ԍ��i�Ζ���j
            table.Columns.Add(new DataColumn("CSTCST.PORTABLETELNORF", typeof(string)));// ���Ӑ�d�b�ԍ��i�g�сj
            table.Columns.Add(new DataColumn("CSTCST.OTHERSTELNORF", typeof(string)));  // ���Ӑ�d�b�ԍ��i���̑��j
            table.Columns.Add(new DataColumn("CSTCST.HOMEFAXNORF", typeof(string)));    // ���Ӑ�FAX�ԍ��i����j
            table.Columns.Add(new DataColumn("CSTCST.OFFICEFAXNORF", typeof(string)));  // ���Ӑ�FAX�ԍ��i�Ζ���j
            // ---- ADD caohh 2011/08/17 ------<<<<<
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE1RF", typeof( Int32 ) ) );  // ���Ӑ敪�̓R�[�h1
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE2RF", typeof( Int32 ) ) );  // ���Ӑ敪�̓R�[�h2
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE3RF", typeof( Int32 ) ) );  // ���Ӑ敪�̓R�[�h3
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE4RF", typeof( Int32 ) ) );  // ���Ӑ敪�̓R�[�h4
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE5RF", typeof( Int32 ) ) );  // ���Ӑ敪�̓R�[�h5
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE6RF", typeof( Int32 ) ) );  // ���Ӑ敪�̓R�[�h6
            table.Columns.Add( new DataColumn( "CSTCST.NOTE1RF", typeof( string ) ) );  // ���Ӑ���l1
            table.Columns.Add( new DataColumn( "CSTCST.NOTE2RF", typeof( string ) ) );  // ���Ӑ���l2
            table.Columns.Add( new DataColumn( "CSTCST.NOTE3RF", typeof( string ) ) );  // ���Ӑ���l3
            table.Columns.Add( new DataColumn( "CSTCST.NOTE4RF", typeof( string ) ) );  // ���Ӑ���l4
            table.Columns.Add( new DataColumn( "CSTCST.NOTE5RF", typeof( string ) ) );  // ���Ӑ���l5
            table.Columns.Add( new DataColumn( "CSTCST.NOTE6RF", typeof( string ) ) );  // ���Ӑ���l6
            table.Columns.Add( new DataColumn( "CSTCST.NOTE7RF", typeof( string ) ) );  // ���Ӑ���l7
            table.Columns.Add( new DataColumn( "CSTCST.NOTE8RF", typeof( string ) ) );  // ���Ӑ���l8
            table.Columns.Add( new DataColumn( "CSTCST.NOTE9RF", typeof( string ) ) );  // ���Ӑ���l9
            table.Columns.Add( new DataColumn( "CSTCST.NOTE10RF", typeof( string ) ) );  // ���Ӑ���l10
            table.Columns.Add( new DataColumn( "CSTADR.CUSTOMERSUBCODERF", typeof( string ) ) );  // �[����T�u�R�[�h
            table.Columns.Add( new DataColumn( "CSTADR.NAMERF", typeof( string ) ) );  // �[���於��
            table.Columns.Add( new DataColumn( "CSTADR.NAME2RF", typeof( string ) ) );  // �[���於��2
            table.Columns.Add( new DataColumn( "CSTADR.HONORIFICTITLERF", typeof( string ) ) );  // �[����h��
            table.Columns.Add( new DataColumn( "CSTADR.KANARF", typeof( string ) ) );  // �[����J�i
            table.Columns.Add( new DataColumn( "CSTADR.CUSTOMERSNMRF", typeof( string ) ) );  // �[���旪��
            table.Columns.Add( new DataColumn( "CSTADR.OUTPUTNAMECODERF", typeof( Int32 ) ) );  // �[���揔���R�[�h
            table.Columns.Add( new DataColumn( "CSTADR.CUSTANALYSCODE1RF", typeof( Int32 ) ) );  // �[���敪�̓R�[�h1
            table.Columns.Add( new DataColumn( "CSTADR.CUSTANALYSCODE2RF", typeof( Int32 ) ) );  // �[���敪�̓R�[�h2
            table.Columns.Add( new DataColumn( "CSTADR.CUSTANALYSCODE3RF", typeof( Int32 ) ) );  // �[���敪�̓R�[�h3
            table.Columns.Add( new DataColumn( "CSTADR.CUSTANALYSCODE4RF", typeof( Int32 ) ) );  // �[���敪�̓R�[�h4
            table.Columns.Add( new DataColumn( "CSTADR.CUSTANALYSCODE5RF", typeof( Int32 ) ) );  // �[���敪�̓R�[�h5
            table.Columns.Add( new DataColumn( "CSTADR.CUSTANALYSCODE6RF", typeof( Int32 ) ) );  // �[���敪�̓R�[�h6
            table.Columns.Add( new DataColumn( "CSTADR.NOTE1RF", typeof( string ) ) );  // �[������l1
            table.Columns.Add( new DataColumn( "CSTADR.NOTE2RF", typeof( string ) ) );  // �[������l2
            table.Columns.Add( new DataColumn( "CSTADR.NOTE3RF", typeof( string ) ) );  // �[������l3
            table.Columns.Add( new DataColumn( "CSTADR.NOTE4RF", typeof( string ) ) );  // �[������l4
            table.Columns.Add( new DataColumn( "CSTADR.NOTE5RF", typeof( string ) ) );  // �[������l5
            table.Columns.Add( new DataColumn( "CSTADR.NOTE6RF", typeof( string ) ) );  // �[������l6
            table.Columns.Add( new DataColumn( "CSTADR.NOTE7RF", typeof( string ) ) );  // �[������l7
            table.Columns.Add( new DataColumn( "CSTADR.NOTE8RF", typeof( string ) ) );  // �[������l8
            table.Columns.Add( new DataColumn( "CSTADR.NOTE9RF", typeof( string ) ) );  // �[������l9
            table.Columns.Add( new DataColumn( "CSTADR.NOTE10RF", typeof( string ) ) );  // �[������l10
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME1RF", typeof( string ) ) );  // ���Ж���1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME2RF", typeof( string ) ) );  // ���Ж���2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.POSTNORF", typeof( string ) ) );  // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS1RF", typeof( string ) ) );  // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS3RF", typeof( string ) ) );  // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS4RF", typeof( string ) ) );  // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO1RF", typeof( string ) ) );  // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO2RF", typeof( string ) ) );  // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO3RF", typeof( string ) ) );  // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE1RF", typeof( string ) ) );  // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE2RF", typeof( string ) ) );  // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE3RF", typeof( string ) ) );  // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "HADD.ACPTANODRSTNMRF", typeof( string ) ) );  // �󒍃X�e�[�^�X����
            table.Columns.Add( new DataColumn( "HADD.DEBITNOTEDIVNMRF", typeof( string ) ) );  // �ԓ`�敪����
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPNMRF", typeof( string ) ) );  // ����`�[�敪����
            table.Columns.Add( new DataColumn( "HADD.SALESGOODSNMRF", typeof( string ) ) );  // ���㏤�i�敪����
            table.Columns.Add( new DataColumn( "HADD.ACCRECDIVNMRF", typeof( string ) ) );  // ���|�敪����
            table.Columns.Add( new DataColumn( "HADD.DELAYPAYMENTDIVNMRF", typeof( string ) ) );  // �����敪����
            table.Columns.Add( new DataColumn( "HADD.ESTIMATEDIVIDENMRF", typeof( string ) ) );  // ���ϋ敪����
            table.Columns.Add( new DataColumn( "HADD.CONSTAXLAYMETHODNMRF", typeof( string ) ) );  // ����œ]�ŕ�������
            table.Columns.Add( new DataColumn( "HADD.AUTODEPOSITNMRF", typeof( string ) ) );  // ���������敪����
            table.Columns.Add( new DataColumn( "HADD.SLIPPRINTFINISHNMRF", typeof( string ) ) );  // �`�[���s�ϋ敪����
            table.Columns.Add( new DataColumn( "HADD.COMPLETENMRF", typeof( string ) ) );  // �ꎮ�`�[�敪����
            table.Columns.Add( new DataColumn( "HADD.CARMNGNORF", typeof( Int32 ) ) );  // (�擪)�ԗ��Ǘ��ԍ�
            table.Columns.Add( new DataColumn( "HADD.CARMNGCODERF", typeof( string ) ) );  // (�擪)���q�Ǘ��R�[�h
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE1CODERF", typeof( Int32 ) ) );  // (�擪)���^�������ԍ�
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE1NAMERF", typeof( string ) ) );  // (�擪)���^�����ǖ���
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE2RF", typeof( string ) ) );  // (�擪)�ԗ��o�^�ԍ��i��ʁj
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE3RF", typeof( string ) ) );  // (�擪)�ԗ��o�^�ԍ��i�J�i�j
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE4RF", typeof( Int32 ) ) );  // (�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATERF", typeof( Int32 ) ) );  // (�擪)���N�x
            table.Columns.Add( new DataColumn( "HADD.MAKERCODERF", typeof( Int32 ) ) );  // (�擪)���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "HADD.MAKERFULLNAMERF", typeof( string ) ) );  // (�擪)���[�J�[�S�p����
            table.Columns.Add( new DataColumn( "HADD.MODELCODERF", typeof( Int32 ) ) );  // (�擪)�Ԏ�R�[�h
            table.Columns.Add( new DataColumn( "HADD.MODELSUBCODERF", typeof( Int32 ) ) );  // (�擪)�Ԏ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "HADD.MODELFULLNAMERF", typeof( string ) ) );  // (�擪)�Ԏ�S�p����
            table.Columns.Add( new DataColumn( "HADD.EXHAUSTGASSIGNRF", typeof( string ) ) );  // (�擪)�r�K�X�L��
            table.Columns.Add( new DataColumn( "HADD.SERIESMODELRF", typeof( string ) ) );  // (�擪)�V���[�Y�^��
            table.Columns.Add( new DataColumn( "HADD.CATEGORYSIGNMODELRF", typeof( string ) ) );  // (�擪)�^���i�ޕʋL���j
            table.Columns.Add( new DataColumn( "HADD.FULLMODELRF", typeof( string ) ) );  // (�擪)�^���i�t���^�j
            table.Columns.Add( new DataColumn( "HADD.MODELDESIGNATIONNORF", typeof( Int32 ) ) );  // (�擪)�^���w��ԍ�
            table.Columns.Add( new DataColumn( "HADD.CATEGORYNORF", typeof( Int32 ) ) );  // (�擪)�ޕʔԍ�
            table.Columns.Add( new DataColumn( "HADD.FRAMEMODELRF", typeof( string ) ) );  // (�擪)�ԑ�^��
            table.Columns.Add( new DataColumn( "HADD.FRAMENORF", typeof( string ) ) );  // (�擪)�ԑ�ԍ�
            table.Columns.Add( new DataColumn( "HADD.SEARCHFRAMENORF", typeof( Int32 ) ) );  // (�擪)�ԑ�ԍ��i�����p�j
            table.Columns.Add( new DataColumn( "HADD.ENGINEMODELNMRF", typeof( string ) ) );  // (�擪)�G���W���^������
            table.Columns.Add( new DataColumn( "HADD.RELEVANCEMODELRF", typeof( string ) ) );  // (�擪)�֘A�^��
            table.Columns.Add( new DataColumn( "HADD.SUBCARNMCDRF", typeof( Int32 ) ) );  // (�擪)�T�u�Ԗ��R�[�h
            table.Columns.Add( new DataColumn( "HADD.MODELGRADESNAMERF", typeof( string ) ) );  // (�擪)�^���O���[�h����
            table.Columns.Add( new DataColumn( "HADD.COLORCODERF", typeof( string ) ) );  // (�擪)�J���[�R�[�h
            table.Columns.Add( new DataColumn( "HADD.COLORNAME1RF", typeof( string ) ) );  // (�擪)�J���[����1
            table.Columns.Add( new DataColumn( "HADD.TRIMCODERF", typeof( string ) ) );  // (�擪)�g�����R�[�h
            table.Columns.Add( new DataColumn( "HADD.TRIMNAMERF", typeof( string ) ) );  // (�擪)�g��������
            table.Columns.Add( new DataColumn( "HADD.MILEAGERF", typeof( Int32 ) ) );  // (�擪)�ԗ����s����
            table.Columns.Add( new DataColumn( "HADD.PRINTERMNGNORF", typeof( Int32 ) ) );  // �v�����^�Ǘ�No
            table.Columns.Add( new DataColumn( "HADD.SLIPPRTSETPAPERIDRF", typeof( string ) ) );  // �`�[����ݒ�p���[ID
            table.Columns.Add( new DataColumn( "HADD.NOTE1RF", typeof( string ) ) );  // ���Д��l�P
            table.Columns.Add( new DataColumn( "HADD.NOTE2RF", typeof( string ) ) );  // ���Д��l�Q
            table.Columns.Add( new DataColumn( "HADD.NOTE3RF", typeof( string ) ) );  // ���Д��l�R
            table.Columns.Add( new DataColumn( "HADD.REISSUEMARKRF", typeof( string ) ) );  // �Ĕ��s�}�[�N
            table.Columns.Add( new DataColumn( "HADD.REFCONSTAXPRTNMRF", typeof( string ) ) );  // �Q�l����ň󎚖���
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEHOURRF", typeof( Int32 ) ) ); // ������� ��
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEMINUTERF", typeof( Int32 ) ) ); // ������� ��
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMESECONDRF", typeof( Int32 ) ) ); // ������� �b
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFYRF", typeof( Int32 ) ) ); // �`�[�������t����N
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFSRF", typeof( Int32 ) ) ); // �`�[�������t����N��
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFWRF", typeof( Int32 ) ) ); // �`�[�������t�a��N
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFMRF", typeof( Int32 ) ) ); // �`�[�������t��
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFDRF", typeof( Int32 ) ) ); // �`�[�������t��
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFGRF", typeof( String ) ) ); // �`�[�������t����
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFRRF", typeof( String ) ) ); // �`�[�������t����
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFLSRF", typeof( String ) ) ); // �`�[�������t���e����(/)
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFLPRF", typeof( String ) ) ); // �`�[�������t���e����(.)
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFLYRF", typeof( String ) ) ); // �`�[�������t���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFLMRF", typeof( String ) ) ); // �`�[�������t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SEARCHSLIPDATEFLDRF", typeof( String ) ) ); // �`�[�������t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFYRF", typeof( Int32 ) ) ); // �o�ד��t����N
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFSRF", typeof( Int32 ) ) ); // �o�ד��t����N��
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFWRF", typeof( Int32 ) ) ); // �o�ד��t�a��N
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFMRF", typeof( Int32 ) ) ); // �o�ד��t��
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFDRF", typeof( Int32 ) ) ); // �o�ד��t��
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFGRF", typeof( String ) ) ); // �o�ד��t����
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFRRF", typeof( String ) ) ); // �o�ד��t����
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFLSRF", typeof( String ) ) ); // �o�ד��t���e����(/)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFLPRF", typeof( String ) ) ); // �o�ד��t���e����(.)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFLYRF", typeof( String ) ) ); // �o�ד��t���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFLMRF", typeof( String ) ) ); // �o�ד��t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTDAYFLDRF", typeof( String ) ) ); // �o�ד��t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFYRF", typeof( Int32 ) ) ); // ������t����N
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFSRF", typeof( Int32 ) ) ); // ������t����N��
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFWRF", typeof( Int32 ) ) ); // ������t�a��N
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFMRF", typeof( Int32 ) ) ); // ������t��
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFDRF", typeof( Int32 ) ) ); // ������t��
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFGRF", typeof( String ) ) ); // ������t����
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFRRF", typeof( String ) ) ); // ������t����
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLSRF", typeof( String ) ) ); // ������t���e����(/)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLPRF", typeof( String ) ) ); // ������t���e����(.)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLYRF", typeof( String ) ) ); // ������t���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLMRF", typeof( String ) ) ); // ������t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLDRF", typeof( String ) ) ); // ������t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFYRF", typeof( Int32 ) ) ); // �v����t����N
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFSRF", typeof( Int32 ) ) ); // �v����t����N��
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFWRF", typeof( Int32 ) ) ); // �v����t�a��N
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFMRF", typeof( Int32 ) ) ); // �v����t��
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFDRF", typeof( Int32 ) ) ); // �v����t��
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFGRF", typeof( String ) ) ); // �v����t����
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFRRF", typeof( String ) ) ); // �v����t����
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFLSRF", typeof( String ) ) ); // �v����t���e����(/)
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFLPRF", typeof( String ) ) ); // �v����t���e����(.)
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFLYRF", typeof( String ) ) ); // �v����t���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFLMRF", typeof( String ) ) ); // �v����t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.ADDUPADATEFLDRF", typeof( String ) ) ); // �v����t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFYRF", typeof( Int32 ) ) ); // ����`�[���s������N
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFSRF", typeof( Int32 ) ) ); // ����`�[���s������N��
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFWRF", typeof( Int32 ) ) ); // ����`�[���s���a��N
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFMRF", typeof( Int32 ) ) ); // ����`�[���s����
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFDRF", typeof( Int32 ) ) ); // ����`�[���s����
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFGRF", typeof( String ) ) ); // ����`�[���s������
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFRRF", typeof( String ) ) ); // ����`�[���s������
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLSRF", typeof( String ) ) ); // ����`�[���s�����e����(/)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLPRF", typeof( String ) ) ); // ����`�[���s�����e����(.)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLYRF", typeof( String ) ) ); // ����`�[���s�����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLMRF", typeof( String ) ) ); // ����`�[���s�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLDRF", typeof( String ) ) ); // ����`�[���s�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFYRF", typeof( Int32 ) ) ); // (�擪)���N�x����N
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFSRF", typeof( Int32 ) ) ); // (�擪)���N�x����N��
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFWRF", typeof( Int32 ) ) ); // (�擪)���N�x�a��N
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFMRF", typeof( Int32 ) ) ); // (�擪)���N�x��
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFDRF", typeof( Int32 ) ) ); // (�擪)���N�x��
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFGRF", typeof( String ) ) ); // (�擪)���N�x����
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFRRF", typeof( String ) ) ); // (�擪)���N�x����
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLSRF", typeof( String ) ) ); // (�擪)���N�x���e����(/)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLPRF", typeof( String ) ) ); // (�擪)���N�x���e����(.)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLYRF", typeof( String ) ) ); // (�擪)���N�x���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLMRF", typeof( String ) ) ); // (�擪)���N�x���e����(��)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLDRF", typeof( String ) ) ); // (�擪)���N�x���e����(��)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAME1RF", typeof( String ) ) ); // ����p���Ӑ於�́i��i�j
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAME2RF", typeof( String ) ) ); // ����p���Ӑ於�́i���i�j
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAME2HNRF", typeof( String ) ) ); // ����p���Ӑ於�́i���i�j�{�h��
            table.Columns.Add( new DataColumn( "HADD.MAKERHALFNAMERF", typeof( String ) ) ); // (�擪)���[�J�[���p����
            table.Columns.Add( new DataColumn( "HADD.MODELHALFNAMERF", typeof( String ) ) ); // (�擪)�Ԏ피�p����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTE3RF", typeof( String ) ) ); // �`�[���l�R
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAMEJOIN12RF", typeof( String ) ) ); //���Ӑ於�P�{���Ӑ於�Q
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAMEJOIN12HNRF", typeof( String ) ) ); // ���Ӑ於�P�{���Ӑ於�Q�{�h��
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1FHRF", typeof( String ) ) ); // ���Ж��P�i�O���j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1LHRF", typeof( String ) ) ); // ���Ж��P�i�㔼�j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2FHRF", typeof( String ) ) ); // ���Ж��Q�i�O���j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2LHRF", typeof( String ) ) ); // ���Ж��Q�i�㔼�j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RESULTSADDUPSECCDRF", typeof( String ) ) ); // ���ьv�㋒�_�R�[�h
            // --- ADD ���痈  2009.07.27 ---------->>>>>
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.SANDEMNGCODERF", typeof( Int64 ) ) );//AB�Z�d�Ǘ��R�[�h
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.DELIVERERNMRF", typeof( String ) ) );//AB�[�i�Җ�
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.DELIVERERADDRESSRF", typeof( String ) ) );//AB�[�i�ҏZ��
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.DELIVERERPHONENUMRF", typeof( String ) ) );//AB�[�i�҂s�d�k
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.ADDRESSEESHOPCDRF", typeof( Int64 ) ) );//AB�[�i��X�܃R�[�h
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.EXPENSEDIVCDRF", typeof( Int64 ) ) );//AB�o��敪
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.DIRECTSENDINGCDRF", typeof( Int64 ) ) );//AB�����敪
            table.Columns.Add( new DataColumn( "HADD.ABILLCODERF", typeof( Int64 ) ) );//AB�����敪
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.ACPTANORDERDIVRF", typeof( Int64 ) ) );//AB�󒍋敪
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.DELIVERERCDRF", typeof( Int64 ) ) );//AB�[�i�҃R�[�h
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.TRADCOMPNAMERF", typeof( String ) ) );//AB���i����
            table.Columns.Add( new DataColumn( "HADD.ABTRADCOMPCDRF", typeof( Int64 ) ) );//AB���i���R�[�h
            table.Columns.Add( new DataColumn( "SANDESETTINGRF.TRADCOMPSECTNAMERF", typeof( String ) ) );//AB���i�����_��
            table.Columns.Add( new DataColumn( "HADD.ABSLIPNOTE1RF", typeof( String ) ) );//AB�`�[���l�P
            table.Columns.Add( new DataColumn( "HADD.ABSLIPNOTE2RF", typeof( String ) ) );//AB�`�[���l�Q
            table.Columns.Add( new DataColumn( "HADD.ABMODELDESIGNATIONNORF", typeof( String ) ) );//(�擪)AB�^���w��ԍ�
            table.Columns.Add( new DataColumn( "HPRT.ABCATEGORYHYPRF", typeof( String ) ) );//(�擪)AB�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( "HADD.ABCATEGORYNORF", typeof( String ) ) );//(�擪)AB�ޕʔԍ�
            table.Columns.Add( new DataColumn( "HADD.ABFULLMODELRF", typeof( String ) ) );//(�擪)AB�^���i�t���^�j
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFYRF", typeof( String ) ) );//(�擪)AB���N�x����N
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFSRF", typeof( String ) ) );//(�擪)AB���N�x����N��
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFWRF", typeof( String ) ) );//(�擪)AB���N�x�a��N
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFMRF", typeof( String ) ) );//(�擪)AB���N�x��
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFGRF", typeof( String ) ) );//(�擪)AB���N�x����
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFRRF", typeof( String ) ) );//(�擪)AB���N�x����
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFLSRF", typeof( String ) ) );//(�擪)AB���N�x���e����(/)
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFLPRF", typeof( String ) ) );//(�擪)AB���N�x���e����(.)
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFLYRF", typeof( String ) ) );//(�擪)AB���N�x���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.ABFIRSTENTRYDATEFLMRF", typeof( String ) ) );//(�擪)AB���N�x���e����(��)
            table.Columns.Add( new DataColumn( "HADD.ABFRAMENORF", typeof( String ) ) );//(�擪)AB�ԑ�ԍ�
            table.Columns.Add( new DataColumn( "HADD.ABMODELHALFNAMERF", typeof( String ) ) );//(�擪)AB�Ԏ피�p����
            table.Columns.Add( new DataColumn( "HADD.SALESTOTALTAXEXCNOMINUSRF", typeof( Double ) ) );//����`�[���v�i�Ŕ����j(�}�C�i�X�����Ȃ�)
            table.Columns.Add( new DataColumn( "HADD.SALESTOTALTAXEXCWITHMINUSRF", typeof( Double ) ) );//����`�[���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "HADD.LISTPRICEMONEYTOTALTAXEXCRF", typeof( Double ) ) );//�艿���z���v(�Ŕ�)
            table.Columns.Add( new DataColumn( "HADD.ABHQTOTALCOSTNOMINUSRF", typeof( Double ) ) );//AB�{���������z���v(�}�C�i�X�����Ȃ�)
            table.Columns.Add( new DataColumn( "HADD.ABHQTOTALCOSTWITHMINUSRF", typeof( Double ) ) );//AB�{���������z���v
            // --- ADD ���痈�@2009.07.27 ----------<<<<<
            // --- ADD  ���r��  2010/03/19 ---------->>>>>
            table.Columns.Add( new DataColumn( "CSTCST.PRINTCUSTOMERNAMEJOIN12CSTRF", typeof( String ) ) );//���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
            // --- ADD  ���r��  2010/03/19 ----------<<<<<
            // --- ADD  ���r��  2010/05/13 ---------->>>>>
            table.Columns.Add(new DataColumn( "HADD.GROSSPROFITRATETTLRF", typeof( String ) ) );//���v�e����
            table.Columns.Add(new DataColumn( "HADD.GROSSPROFITTTLRF", typeof( Int64 ) ) );//���v�e�����z
            // --- ADD  ���r��  2010/05/13 ----------<<<<<
            // --- ADD  ���r��  2010/06/03 ---------->>>>>
            table.Columns.Add(new DataColumn( "HADD.SHIPMENTCNTTTLRF", typeof( Double ) ) );//���ʍ��v
            table.Columns.Add(new DataColumn( "HADD.SALESTTLTAXLAYDTLRF", typeof( Double ) ) );//�`�[���v(���ד]�ł̂ݐō�)
            table.Columns.Add(new DataColumn( "CSTCST.CUSTOMERNAMECSTRF", typeof( String ) ) );//���Ӑ於(���Ӑ�}�X�^�Q��)
            table.Columns.Add(new DataColumn( "CSTCST.CUSTOMERNAME2CSTRF", typeof(String)));//���Ӑ於�Q(���Ӑ�}�X�^�Q��)
            // --- ADD  ���r��  2010/06/03 ----------<<<<<
            // --- ADD  ���r��  2010/06/29 ---------->>>>>
            table.Columns.Add(new DataColumn( "SALESSLIPRF.SLIPNOTEUPPERRF", typeof( string ) ) );//�`�[���l�i��i�j
            table.Columns.Add(new DataColumn( "SALESSLIPRF.SLIPNOTELOWERRF", typeof( string ) ) );//�`�[���l�i���i�j
            table.Columns.Add(new DataColumn( "SALESSLIPRF.CUSTOMERNAME2HNRF", typeof( string ) ) );//���Ӑ於�Q�{�h��
            table.Columns.Add(new DataColumn( "SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF", typeof( String ) ) );//���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
            table.Columns.Add(new DataColumn( "SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF", typeof( String ) ) );//���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
            table.Columns.Add(new DataColumn( "SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF", typeof( String ) ) );//���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
            // --- ADD  ���r��  2010/06/29 ----------<<<<<
            // --- ADD  ���r��  2010/07/05 ---------->>>>>
            table.Columns.Add(new DataColumn( "HADD.SALESSLIPCDYHRF", typeof( Int32 ) ) );//����`�[�敪(�C�G���[�n�b�g�p)
            // --- ADD  ���r��  2010/07/05 ----------<<<<<

            // --- ADD ����� 2011/08/15---------->>>>>
            table.Columns.Add(new DataColumn(ct_SlipTitle11, typeof(string))); //�^�C�g���P�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle12, typeof(string))); //�^�C�g���P�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle13, typeof(string))); //�^�C�g���P�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle14, typeof(string))); //�^�C�g���P�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle15, typeof(string))); //�^�C�g���P�E�T

            table.Columns.Add(new DataColumn(ct_SlipTitle21, typeof(string))); //�^�C�g���Q�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle22, typeof(string))); //�^�C�g���Q�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle23, typeof(string))); //�^�C�g���Q�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle24, typeof(string))); //�^�C�g���Q�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle25, typeof(string))); //�^�C�g���Q�E�T

            table.Columns.Add(new DataColumn(ct_SlipTitle31, typeof(string))); //�^�C�g���R�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle32, typeof(string))); //�^�C�g���R�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle33, typeof(string))); //�^�C�g���R�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle34, typeof(string))); //�^�C�g���R�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle35, typeof(string))); //�^�C�g���R�E�T

            table.Columns.Add(new DataColumn(ct_SlipTitle41, typeof(string))); //�^�C�g���S�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle42, typeof(string))); //�^�C�g���S�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle43, typeof(string))); //�^�C�g���S�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle44, typeof(string))); //�^�C�g���S�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle45, typeof(string))); //�^�C�g���S�E�T
            // --- ADD ����� 2011/08/15----------<<<<<
            # endregion

            # region [�X�L�[�}��`�i���׍��ځj]
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACPTANODRSTATUSRF", typeof( Int32 ) ) );  // �󒍃X�e�[�^�X
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESSLIPNUMRF", typeof( string ) ) );  // ����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACCEPTANORDERNORF", typeof( Int32 ) ) );  // �󒍔ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESROWNORF", typeof( Int32 ) ) );  // ����s�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESDATERF", typeof( Int32 ) ) );  // ������t
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COMMONSEQNORF", typeof( Int64 ) ) );  // ���ʒʔ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESSLIPDTLNUMRF", typeof( Int64 ) ) );  // ���㖾�גʔ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACPTANODRSTATUSSRCRF", typeof( Int32 ) ) );  // �󒍃X�e�[�^�X�i���j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESSLIPDTLNUMSRCRF", typeof( Int64 ) ) );  // ���㖾�גʔԁi���j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERFORMALSYNCRF", typeof( Int32 ) ) );  // �d���`���i�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.STOCKSLIPDTLNUMSYNCRF", typeof( Int64 ) ) );  // �d�����גʔԁi�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESSLIPCDDTLRF", typeof( Int32 ) ) );  // ����`�[�敪�i���ׁj
            table.Columns.Add( new DataColumn( "SALESDETAILRF.STOCKMNGEXISTCDRF", typeof( Int32 ) ) );  // �݌ɊǗ��L���敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DELIGDSCMPLTDUEDATERF", typeof( Int32 ) ) );  // �[�i�����\���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSKINDCODERF", typeof( Int32 ) ) );  // ���i����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMAKERCDRF", typeof( Int32 ) ) );  // ���i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MAKERNAMERF", typeof( string ) ) );  // ���[�J�[����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNORF", typeof( string ) ) );  // ���i�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNAMERF", typeof( string ) ) );  // ���i����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSSHORTNAMERF", typeof( string ) ) );  // ���i������
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LARGEGOODSGANRECODERF", typeof( string ) ) );  // ���i�敪�O���[�v�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LARGEGOODSGANRENAMERF", typeof( string ) ) );  // ���i�敪�O���[�v����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MEDIUMGOODSGANRECODERF", typeof( string ) ) );  // ���i�敪�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MEDIUMGOODSGANRENAMERF", typeof( string ) ) );  // ���i�敪����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DETAILGOODSGANRECODERF", typeof( string ) ) );  // ���i�敪�ڍ׃R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DETAILGOODSGANRENAMERF", typeof( string ) ) );  // ���i�敪�ڍז���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGOODSCODERF", typeof( Int32 ) ) );  // BL���i�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGOODSFULLNAMERF", typeof( string ) ) );  // BL���i�R�[�h���́i�S�p�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ENTERPRISEGANRECODERF", typeof( Int32 ) ) );  // ���Е��ރR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ENTERPRISEGANRENAMERF", typeof( string ) ) );  // ���Е��ޖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSECODERF", typeof( string ) ) );  // �q�ɃR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSENAMERF", typeof( string ) ) );  // �q�ɖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSESHELFNORF", typeof( string ) ) );  // �q�ɒI��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESORDERDIVCDRF", typeof( Int32 ) ) );  // ����݌Ɏ�񂹋敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.OPENPRICEDIVRF", typeof( Int32 ) ) );  // �I�[�v�����i�敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.UNITCODERF", typeof( Int32 ) ) );  // �P�ʃR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.UNITNAMERF", typeof( string ) ) );  // �P�ʖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSRATERANKRF", typeof( string ) ) );  // ���i�|�������N
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CUSTRATEGRPCODERF", typeof( Int32 ) ) );  // ���Ӑ�|���O���[�v�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPRATEGRPCODERF", typeof( Int32 ) ) );  // �d����|���O���[�v�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICERATERF", typeof( Double ) ) );  // �艿��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICETAXINCFLRF", typeof( Double ) ) );  // �艿�i�ō��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICETAXEXCFLRF", typeof( Double ) ) );  // �艿�i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICECHNGCDRF", typeof( Int32 ) ) );  // �艿�ύX�敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESRATERF", typeof( Double ) ) );  // ������
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNPRCTAXINCFLRF", typeof( Double ) ) );  // ����P���i�ō��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) );  // ����P���i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COSTRATERF", typeof( Double ) ) );  // ������
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNITCOSTRF", typeof( Double ) ) );  // �����P��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SHIPMENTCNTRF", typeof( Double ) ) );  // �o�א�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACCEPTANORDERCNTRF", typeof( Double ) ) );  // �󒍐���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACPTANODRADJUSTCNTRF", typeof( Double ) ) );  // �󒍒�����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACPTANODRREMAINCNTRF", typeof( Double ) ) );  // �󒍎c��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.REMAINCNTUPDDATERF", typeof( Int32 ) ) );  // �c���X�V��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESMONEYTAXINCRF", typeof( Int64 ) ) );  // ������z�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESMONEYTAXEXCRF", typeof( Int64 ) ) );  // ������z�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COSTRF", typeof( Int64 ) ) );  // ����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GRSPROFITCHKDIVRF", typeof( Int32 ) ) );  // �e���`�F�b�N�敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESGOODSCDRF", typeof( Int32 ) ) );  // ���㏤�i�敪
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.SALSEPRICECONSTAXRF", typeof( Int64 ) ) );  // ������z����Ŋz
            table.Columns.Add( new DataColumn( "SALESDETAILRF.TAXATIONDIVCDRF", typeof( Int32 ) ) );  // �ېŋ敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PARTYSLIPNUMDTLRF", typeof( string ) ) );  // �����`�[�ԍ��i���ׁj
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DTLNOTERF", typeof( string ) ) );  // ���ה��l
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERCDRF", typeof( Int32 ) ) );  // �d����R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERSNMRF", typeof( string ) ) );  // �d���旪��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ORDERNUMBERRF", typeof( string ) ) );  // �����ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO1RF", typeof( string ) ) );  // �`�[�����P
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO2RF", typeof( string ) ) );  // �`�[�����Q
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO3RF", typeof( string ) ) );  // �`�[�����R
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO1RF", typeof( string ) ) );  // �Г������P
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO2RF", typeof( string ) ) );  // �Г������Q
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO3RF", typeof( string ) ) );  // �Г������R
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFLISTPRICERF", typeof( Double ) ) );  // �ύX�O�艿
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFSALESUNITPRICERF", typeof( Double ) ) );  // �ύX�O����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFUNITCOSTRF", typeof( Double ) ) );  // �ύX�O����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSNORF", typeof( string ) ) );  // ����p���i�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSNAMERF", typeof( string ) ) );  // ����p���i����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSMAKERCDRF", typeof( Int32 ) ) );  // ����p���i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSMAKERNMRF", typeof( string ) ) );  // ����p���i���[�J�[����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CONTRACTDIVCDDTLRF", typeof( Int32 ) ) );  // �_��敪�i���ׁj
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESROWNORF", typeof( Int32 ) ) );  // �ꎮ���הԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTGOODSMAKERCDRF", typeof( Int32 ) ) );  // ���[�J�[�R�[�h�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTMAKERNAMERF", typeof( string ) ) );  // ���[�J�[���́i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTGOODSNAMERF", typeof( string ) ) );  // ���i���́i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSHIPMENTCNTRF", typeof( Double ) ) );  // ���ʁi�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTUNITCODERF", typeof( Int32 ) ) );  // �P�ʃR�[�h�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTUNITNAMERF", typeof( string ) ) );  // �P�ʖ��́i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESUNPRCFLRF", typeof( Double ) ) );  // ����P���i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESMONEYRF", typeof( Int64 ) ) );  // ������z�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESUNITCOSTRF", typeof( Double ) ) );  // �����P���i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTCOSTRF", typeof( Int64 ) ) );  // �������z�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTPARTYSALSLNUMRF", typeof( string ) ) );  // �����`�[�ԍ��i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTNOTERF", typeof( string ) ) );  // �ꎮ���l
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CARMNGNORF", typeof( Int32 ) ) );  // �ԗ��Ǘ��ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CARMNGCODERF", typeof( string ) ) );  // ���q�Ǘ��R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE1CODERF", typeof( Int32 ) ) );  // ���^�������ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE1NAMERF", typeof( string ) ) );  // ���^�����ǖ���
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE2RF", typeof( string ) ) );  // �ԗ��o�^�ԍ��i��ʁj
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE3RF", typeof( string ) ) );  // �ԗ��o�^�ԍ��i�J�i�j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE4RF", typeof( Int32 ) ) );  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FIRSTENTRYDATERF", typeof( Int32 ) ) );  // ���N�x
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERCODERF", typeof( Int32 ) ) );  // ���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERFULLNAMERF", typeof( string ) ) );  // ���[�J�[�S�p����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELCODERF", typeof( Int32 ) ) );  // �Ԏ�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELSUBCODERF", typeof( Int32 ) ) );  // �Ԏ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELFULLNAMERF", typeof( string ) ) );  // �Ԏ�S�p����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.EXHAUSTGASSIGNRF", typeof( string ) ) );  // �r�K�X�L��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SERIESMODELRF", typeof( string ) ) );  // �V���[�Y�^��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CATEGORYSIGNMODELRF", typeof( string ) ) );  // �^���i�ޕʋL���j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FULLMODELRF", typeof( string ) ) );  // �^���i�t���^�j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELDESIGNATIONNORF", typeof( Int32 ) ) );  // �^���w��ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CATEGORYNORF", typeof( Int32 ) ) );  // �ޕʔԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FRAMEMODELRF", typeof( string ) ) );  // �ԑ�^��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FRAMENORF", typeof( string ) ) );  // �ԑ�ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SEARCHFRAMENORF", typeof( Int32 ) ) );  // �ԑ�ԍ��i�����p�j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.ENGINEMODELNMRF", typeof( string ) ) );  // �G���W���^������
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.RELEVANCEMODELRF", typeof( string ) ) );  // �֘A�^��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SUBCARNMCDRF", typeof( Int32 ) ) );  // �T�u�Ԗ��R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELGRADESNAMERF", typeof( string ) ) );  // �^���O���[�h����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.COLORCODERF", typeof( string ) ) );  // �J���[�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.COLORNAME1RF", typeof( string ) ) );  // �J���[����1
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.TRIMCODERF", typeof( string ) ) );  // �g�����R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.TRIMNAMERF", typeof( string ) ) );  // �g��������
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MILEAGERF", typeof( Int32 ) ) );  // �ԗ����s����
            table.Columns.Add( new DataColumn( "MAKGDS.MAKERSHORTNAMERF", typeof( string ) ) );  // ���i���[�J�[����
            table.Columns.Add( new DataColumn( "MAKGDS.MAKERKANANAMERF", typeof( string ) ) );  // ���i���[�J�[�J�i����
            table.Columns.Add( new DataColumn( "MAKGDS.GOODSMAKERCDRF", typeof( Int32 ) ) );  // ���[�U�[�������i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "MAKCMP.MAKERSHORTNAMERF", typeof( string ) ) );  // �ꎮ���[�J�[����
            table.Columns.Add( new DataColumn( "MAKCMP.MAKERKANANAMERF", typeof( string ) ) );  // �ꎮ���[�J�[�J�i����
            table.Columns.Add( new DataColumn( "MAKCMP.GOODSMAKERCDRF", typeof( Int32 ) ) );  // ���[�U�[�����ꎮ���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "GOODSURF.GOODSNAMEKANARF", typeof( string ) ) );  // ���i���̃J�i
            table.Columns.Add( new DataColumn( "GOODSURF.JANRF", typeof( string ) ) );  // JAN�R�[�h
            table.Columns.Add( new DataColumn( "GOODSURF.GOODSRATERANKRF", typeof( string ) ) );  // ���i�|�������N
            table.Columns.Add( new DataColumn( "GOODSURF.GOODSNONONEHYPHENRF", typeof( string ) ) );  // �n�C�t�������i�ԍ�
            table.Columns.Add( new DataColumn( "GOODSURF.GOODSNOTE1RF", typeof( string ) ) );  // ���i���l�P
            table.Columns.Add( new DataColumn( "GOODSURF.GOODSNOTE2RF", typeof( string ) ) );  // ���i���l�Q
            table.Columns.Add( new DataColumn( "GOODSURF.GOODSSPECIALNOTERF", typeof( string ) ) );  // ���i�K�i�E���L����
            table.Columns.Add( new DataColumn( "STOCKRF.SHIPMENTPOSCNTRF", typeof( Double ) ) );  // �o�׉\��
            table.Columns.Add( new DataColumn( "STOCKRF.DUPLICATIONSHELFNO1RF", typeof( string ) ) );  // �d���I�ԂP
            table.Columns.Add( new DataColumn( "STOCKRF.DUPLICATIONSHELFNO2RF", typeof( string ) ) );  // �d���I�ԂQ
            table.Columns.Add( new DataColumn( "STOCKRF.PARTSMANAGEMENTDIVIDE1RF", typeof( string ) ) );  // ���i�Ǘ��敪�P
            table.Columns.Add( new DataColumn( "STOCKRF.PARTSMANAGEMENTDIVIDE2RF", typeof( string ) ) );  // ���i�Ǘ��敪�Q
            table.Columns.Add( new DataColumn( "STOCKRF.STOCKNOTE1RF", typeof( string ) ) );  // �݌ɔ��l�P
            table.Columns.Add( new DataColumn( "STOCKRF.STOCKNOTE2RF", typeof( string ) ) );  // �݌ɔ��l�Q
            table.Columns.Add( new DataColumn( "WAREHOUSERF.WAREHOUSENOTE1RF", typeof( string ) ) );  // �q�ɔ��l1
            table.Columns.Add( new DataColumn( "USRCSG.GUIDENAMERF", typeof( string ) ) );  // ���Ӑ�|���f�q����
            table.Columns.Add( new DataColumn( "USRSPG.GUIDENAMERF", typeof( string ) ) );  // �d����|���f�q����
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERCDRF", typeof( Int32 ) ) );  // ���[�U�[�����d����R�[�h
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERNM1RF", typeof( string ) ) );  // �d���於1
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERNM2RF", typeof( string ) ) );  // �d���於2
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPHONORIFICTITLERF", typeof( string ) ) );  // �d����h��
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERKANARF", typeof( string ) ) );  // �d����J�i
            table.Columns.Add( new DataColumn( "SUPPLIERRF.PURECODERF", typeof( Int32 ) ) );  // �����敪
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERNOTE1RF", typeof( string ) ) );  // �d������l1
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERNOTE2RF", typeof( string ) ) );  // �d������l2
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERNOTE3RF", typeof( string ) ) );  // �d������l3
            table.Columns.Add( new DataColumn( "SUPPLIERRF.SUPPLIERNOTE4RF", typeof( string ) ) );  // �d������l4
            table.Columns.Add( new DataColumn( "BLGOODSCDURF.BLGOODSCODERF", typeof( Int32 ) ) );  // ���[�U�[����BL���i�R�[�h
            table.Columns.Add( new DataColumn( "BLGOODSCDURF.BLGOODSHALFNAMERF", typeof( string ) ) );  // BL���i�R�[�h���́i���p�j
            table.Columns.Add( new DataColumn( "DADD.STOCKMNGEXISTNMRF", typeof( string ) ) );  // �݌ɊǗ��L���敪����
            table.Columns.Add( new DataColumn( "DADD.GOODSKINDNAMERF", typeof( string ) ) );  // ���i��������
            table.Columns.Add( new DataColumn( "DADD.SALESORDERDIVNMRF", typeof( string ) ) );  // ����݌Ɏ�񂹋敪����
            table.Columns.Add( new DataColumn( "DADD.OPENPRICEDIVNMRF", typeof( string ) ) );  // �I�[�v�����i�敪����
            table.Columns.Add( new DataColumn( "DADD.GRSPROFITCHKDIVNMRF", typeof( string ) ) );  // �e���`�F�b�N�敪����
            table.Columns.Add( new DataColumn( "DADD.SALESGOODSNMRF", typeof( string ) ) );  // ���㏤�i�敪����
            table.Columns.Add( new DataColumn( "DADD.TAXATIONDIVNMRF", typeof( string ) ) );  // �ېŋ敪����
            table.Columns.Add( new DataColumn( "DADD.PURECODENMRF", typeof( string ) ) );  // �����敪
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFYRF", typeof( Int32 ) ) ); // �[�i�����\�������N
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFSRF", typeof( Int32 ) ) ); // �[�i�����\�������N��
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFWRF", typeof( Int32 ) ) ); // �[�i�����\����a��N
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFMRF", typeof( Int32 ) ) ); // �[�i�����\�����
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFDRF", typeof( Int32 ) ) ); // �[�i�����\�����
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFGRF", typeof( String ) ) ); // �[�i�����\�������
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFRRF", typeof( String ) ) ); // �[�i�����\�������
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFLSRF", typeof( String ) ) ); // �[�i�����\������e����(/)
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFLPRF", typeof( String ) ) ); // �[�i�����\������e����(.)
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFLYRF", typeof( String ) ) ); // �[�i�����\������e����(�N)
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFLMRF", typeof( String ) ) ); // �[�i�����\������e����(��)
            table.Columns.Add( new DataColumn( "DADD.DELIGDSCMPLTDUEDATEFLDRF", typeof( String ) ) ); // �[�i�����\������e����(��)
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
            table.Columns.Add( new DataColumn( "DADD.SALESORDERDIVMARKRF", typeof( String ) ) ); // �݌Ɏ��敪�}�[�N
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERHALFNAMERF", typeof( String ) ) ); // ���[�J�[���p����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELHALFNAMERF", typeof( String ) ) ); // �Ԏ피�p����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTBLGOODSCODERF", typeof( Int32 ) ) ); // BL���i�R�[�h�i����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTBLGOODSNAMERF", typeof( String ) ) ); // BL���i�R�[�h���́i����j
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSNORF", typeof( String ) ) ); // ����p�i��
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERCODERF", typeof( Int32 ) ) ); // ����p���[�J�[�R�[�h
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERNAMERF", typeof( String ) ) ); // ����p���[�J�[����
            table.Columns.Add( new DataColumn( "MAKPRT.MAKERKANANAMERF", typeof( String ) ) ); // ����p���[�J�[�J�i����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSLGROUPRF", typeof( Int32 ) ) ); // ���i�啪�ރR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSLGROUPNAMERF", typeof( String ) ) ); // ���i�啪�ޖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMGROUPRF", typeof( Int32 ) ) ); // ���i�����ރR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMGROUPNAMERF", typeof( String ) ) ); // ���i�����ޖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGROUPCODERF", typeof( Int32 ) ) ); // BL�O���[�v�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGROUPNAMERF", typeof( String ) ) ); // BL�O���[�v�R�[�h����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESCODERF", typeof( Int32 ) ) ); // �̔��敪�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESCDNMRF", typeof( String ) ) ); // �̔��敪����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNAMEKANARF", typeof( String ) ) ); // ���i���̃J�i
            // --- ADD ���痈  2009.07.27 ---------->>>>>
            table.Columns.Add( new DataColumn( "DADD.ABGOODSNOTE2RF", typeof( String ) ) );//ABOEM�R�[�h
            table.Columns.Add( new DataColumn( "DADD.ABGOODSKINDCODERF", typeof( Int64 ) ) );//AB�����敪
            table.Columns.Add( new DataColumn( "DADD.SHIPMENTCNTNOMINUSRF", typeof( Double ) ) );//�o�א�(�}�C�i�X�����Ȃ�)
            table.Columns.Add( new DataColumn( "DADD.SHIPMENTCNTWITHMINUSRF", typeof( Double ) ) );//�o�א�
            table.Columns.Add( new DataColumn( "DADD.SALESMONEYTAXEXCNOMINUSRF", typeof( Double ) ) );//������z�i�Ŕ����j(�}�C�i�X�����Ȃ�)
            table.Columns.Add( new DataColumn( "DADD.SALESMONEYTAXEXCWITHMINUSRF", typeof( Double ) ) );//������z�i�Ŕ����j
            table.Columns.Add( new DataColumn( "DADD.LISTPRICEMONEYTAXEXCRF", typeof( Double ) ) );//�艿���z(�Ŕ�)
            table.Columns.Add( new DataColumn( "DADD.ABHQSALESUNITCOSTRF", typeof( Double ) ) );//AB�{������
            table.Columns.Add( new DataColumn( "DADD.ABHQSALESUNITCOSTNOMINUSRF", typeof( Double ) ) );//AB�{���������z(�}�C�i�X�����Ȃ�)
            table.Columns.Add( new DataColumn( "DADD.ABHQSALESUNITCOSTWITHMINUSRF", typeof( Double ) ) );//AB�{���������z
            table.Columns.Add( new DataColumn( "DADD.ABGOODSCODERF", typeof( Int64 ) ) );//AB���i�R�[�h
            table.Columns.Add( new DataColumn( "DADD.SHIPMENTCNTMINUSSIGNRF", typeof( String ) ) );//�o�א��}�C�i�X����
            table.Columns.Add( new DataColumn( "DADD.SALESMONEYTAXEXCMINUSSIGNRF", typeof( String ) ) );//������z�}�C�i�X����
            table.Columns.Add( new DataColumn( "DADD.ABHQSALESUNITCOSTMINUSSIGNRF", typeof( String ) ) );//AB�{���������z�}�C�i�X����
            // --- ADD ���痈�@2009.07.27 ----------<<<<<
            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            table.Columns.Add( new DataColumn( "DADD.LISTPRICEMONEYTAXRF", typeof( Int64 ) ) );//�艿���z�����
            table.Columns.Add( new DataColumn( "DADD.DETAILROWCOUNTALLRF", typeof( Int32 ) ) );//���׍s��(��Ɉ�)
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            // --- ADD  ���r��  2010/05/13 ---------->>>>>
            table.Columns.Add( new DataColumn( "DADD.GROSSPROFITRATERF", typeof( Double ) ) );//���בe����
            table.Columns.Add( new DataColumn( "DADD.GROSSPROFITRF", typeof( Int64 ) ) );//�e�����z
            table.Columns.Add( new DataColumn( "SALESDETAILRF.UOEREMARK1DETAILRF", typeof( string ) ) );//UOE���}�[�N�P(����)
            table.Columns.Add( new DataColumn( "DADD.GROSSPROFITRATELTRLRF", typeof( String ) ) );//�e�������e����
            // --- ADD  ���r��  2010/05/13 ----------<<<<<
            // --- ADD  ���r��  2010/06/03 ---------->>>>>
            table.Columns.Add( new DataColumn( "DADD.SALESMONEYTAXLAYDTLRF", typeof( Double ) ) );//������z(���ד]�Ŏ��̂ݐō�)
            // --- ADD  ���r��  2010/06/03 ----------<<<<<
            // --- ADD  2011/07/19 ---------->>>>>
            table.Columns.Add(new DataColumn("HADD.NORMALPRTMARKRF", typeof(String)));//�ʏ픭�s�}�[�N
            table.Columns.Add(new DataColumn("HADD.SCMMANUALANSMARKRF", typeof(String)));//SCM�蓮�񓚃}�[�N
            table.Columns.Add(new DataColumn("HADD.SCMAUTOANSMARKRF", typeof(String)));//SCM�����񓚃}�[�N
            // --- ADD  2011/07/19 ----------<<<<<
            # endregion

            # region [���䍀��]
            // ���䍀��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle1, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle2, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle3, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle4, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyCount, typeof( int ) ) );  // ����y�[�W���R�s�[�J�E���g
            table.Columns.Add( new DataColumn( ct_PageCount, typeof( int ) ) );  // �y�[�W��
            // �󎚐��䂪����ȍ���
            table.Columns.Add( new DataColumn( ct_AcptCount, typeof( Double ) ) );  // �󒍐�
            table.Columns.Add( new DataColumn( ct_ShipCount, typeof( Double ) ) );  // �o�א�
            table.Columns.Add( new DataColumn( ct_HCategoryHyp, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_DCategoryHyp, typeof( string ) ) );  // �ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_QRCode, typeof( string ) ) ); // �p�q�R�[�h
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            table.Columns.Add( new DataColumn( ct_QRCodeSource, typeof( string ) ) ); // �p�q�R�[�h(���f�[�^)
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            //table.Columns.Add( new DataColumn( ct_DWarehouseCodeRF, typeof( string ) ) );  // �q�ɃR�[�h�i�^�C�g���P�E�Q�j
            //table.Columns.Add( new DataColumn( ct_DWarehouseNameRF, typeof( string ) ) );  // �q�ɖ��i�^�C�g���P�E�Q�j
            //table.Columns.Add( new DataColumn( ct_DWarehouseShelfNoRF, typeof( string ) ) );  // �I�ԁi�^�C�g���P�E�Q�j
            table.Columns.Add( new DataColumn( ct_SupplierCdExtra, typeof( string ) ) );  // �d����R�[�h�i���̂݁j
            table.Columns.Add( new DataColumn( ct_ShelfNoExtra, typeof( string ) ) );  // �I�ԁi���Ӑ撍�ԂȂ����j
            table.Columns.Add( new DataColumn( ct_TaxTitle, typeof( string ) ) );  // (Label)����Ń^�C�g��
            table.Columns.Add( new DataColumn( ct_SubTotalTitle, typeof( string ) ) );  // (Label)���v�^�C�g��
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAMERF", typeof( string ) ) );  // �y�c�{�z���Ӑ於��
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAME2RF", typeof( string ) ) );  //�y�c�{�z ���Ӑ於��2
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERSNMRF", typeof( string ) ) );  // �y�c�{�z���Ӑ旪��
            table.Columns.Add( new DataColumn( "HLG.HONORIFICTITLERF", typeof( string ) ) );  // �y�c�{�z�h��
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAMEJOIN12RF", typeof( String ) ) ); //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAMEJOIN12HNRF", typeof( String ) ) ); // �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/07/02 ADD
            table.Columns.Add( new DataColumn( "HLG.COMPANYNAME1RF", typeof( string ) ) );  // �y�c�{�z���Ж���1
            table.Columns.Add( new DataColumn( "HLG.COMPANYNAME2RF", typeof( string ) ) );  // �y�c�{�z���Ж���2
            table.Columns.Add( new DataColumn( "HLG.PRINTENTERPRISENAME1FHRF", typeof( String ) ) ); // �y�c�{�z���Ж��P�i�O���j
            table.Columns.Add( new DataColumn( "HLG.PRINTENTERPRISENAME1LHRF", typeof( String ) ) ); // �y�c�{�z���Ж��P�i�㔼�j
            table.Columns.Add( new DataColumn( "HLG.PRINTENTERPRISENAME2FHRF", typeof( String ) ) ); // �y�c�{�z���Ж��Q�i�O���j
            table.Columns.Add( new DataColumn( "HLG.PRINTENTERPRISENAME2LHRF", typeof( String ) ) ); // �y�c�{�z���Ж��Q�i�㔼�j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/07/02 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
            // A700�p�̓`�[���v�̈󎚈ʒu������s�����߂ɍ��ڒǉ��B
            table.Columns.Add( new DataColumn( "HADD.SALESTOTALTAXINCA700RF", typeof( String ) ) ); // �`�[���v�iA700�j���ō�
            table.Columns.Add( new DataColumn( "HADD.SALESTOTALTAXEXCA700RF", typeof( String ) ) ); // �`�[���v�iA700�j���Ŕ�
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.03 ADD
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAME1RF", typeof( String ) ) ); // �i�c�{�j����p���Ӑ於�́i��i�j
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAME2RF", typeof( String ) ) ); // �i�c�{�j����p���Ӑ於�́i���i�j
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAME2HNRF", typeof( String ) ) ); // �i�c�{�j����p���Ӑ於�́i���i�j�{�h��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.03 ADD
            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            table.Columns.Add( new DataColumn( ct_SalesTotalTaxIncTitle, typeof( string ) ) );  //  (Label)�ېō��v���z���e����
            table.Columns.Add( new DataColumn("HADD.LISTPRICEMONEYTOTALTAXRF", typeof( Int64 ) ) );//�艿���z���v�����
            table.Columns.Add( new DataColumn("HADD.LISTPRICEMONEYTOTALTAXINCRF", typeof( Int64 ) ) );//�艿���z���v(�ō�)
            table.Columns.Add( new DataColumn("HADD.SALESTTLTAXINCDMD", typeof( Int64 ) ) );//�`�[���v���z(�����]��)
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            // --- ADD  ���r��  2010/03/19 ---------->>>>>
            table.Columns.Add( new DataColumn("HLG.PRINTCUSTOMERNAMEJOIN12CSTRF", typeof( String ) ) );//���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
            // --- ADD  ���r��  2010/03/19 ----------<<<<<
            // --- ADD  ���r��  2010/06/03 ---------->>>>>
            table.Columns.Add( new DataColumn( "HLG.CUSTNOTE1RF", typeof( string ) ) );//�y�c�{�z���Ӑ���l�P
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAMECSTRF", typeof( string ) ) );//�y�c�{�z���Ӑ於�P(���Ӑ�}�X�^�Q��)
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAME2CSTRF", typeof( string ) ) );//�y�c�{�z���Ӑ於�Q(���Ӑ�}�X�^�Q��)
            // --- ADD  ���r��  2010/06/03 ----------<<<<<
            // --- ADD  ���r��  2010/06/29 ---------->>>>>
            table.Columns.Add(new DataColumn( "HLG.CUSTOMERNAME2HNRF", typeof( string ) ) );//�y�c�{�z���Ӑ於�Q�{�h��
            table.Columns.Add(new DataColumn( "HLG.PRINTCSTNAMEJOIN12HN1RF", typeof( String ) ) );//�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
            table.Columns.Add(new DataColumn( "HLG.PRINTCSTNAMEJOIN12HN2RF", typeof( String ) ) );//�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
            table.Columns.Add(new DataColumn( "HLG.PRINTCSTNAMEJOIN12HN3RF", typeof( String ) ) );//�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
            // --- ADD  ���r��  2010/06/29 ----------<<<<<
            # endregion

            table.Columns.Add(new DataColumn("HPRT.BARCDSALESSLNUMRF", typeof(string)));  // �o�[�R�[�h�i�`�[�ԍ��j // --- ADD 3H �k�P�N 2017/08/30
            return table;
        }
        # endregion

        # region [�f�[�^�ڍs�iDataClass��DataTable�j]
        /// <summary>
        /// �f�[�^�ڍs����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="currentIndex"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorks"></param>
        /// <param name="slipPrtSet"></param>
        /// <param name="salesTtlSt"></param>
        /// <remarks>
        /// <br>Update Note: 2011/02/16 ����</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br> 
        /// <br>Update Note: 2011/08/15 �����</br>
        /// <br>             �yPM�v�]����9���z�M���zRedmine#23541 �A��985�̑Ή�</br> 
        /// <br>Update Note: 2011/09/13 �����</br>
        /// <br>             �yPM�v�]����9���z�M���zRedmine#24920 �A��985�̑Ή�</br> 
        /// <br>Update Note  : 2013/02/19 xuyb</br>
        /// <br>               Redmine#34615�@No.1639�[�i�� �Ԏ햼���p�J�i�̑Ή�</br>
        /// <br>Update Note  : 2017/08/30 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�     : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// </remarks>
        // --- UPD  ���r��  2010/06/29 ---------->>>>>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //// --- ADD  ���r��  2010/03/01 ---------->>>>>
        ////public static void CopyToDataTable( ref DataTable table, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic )
        //public static void CopyToDataTable(ref DataTable table, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, TaxRateSetWork taxRateSet, List<SalesProcMoneyWork> salesProcMoneyList)
        //// --- ADD  ���r��  2010/03/01 ----------<<<<<
        //public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, TaxRateSetWork taxRateSet, List<SalesProcMoneyWork> salesProcMoneyList)
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        // --- UPD ����� 2011/08/15---------->>>>>
        //public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, TaxRateSetWork taxRateSet, List<SalesProcMoneyWork> salesProcMoneyList, SlipPrintParameterofCount slipPrintParameterofCount)
        public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, TaxRateSetWork taxRateSet, List<SalesProcMoneyWork> salesProcMoneyList, SlipPrintParameterofCount slipPrintParameterofCount, Dictionary<string, ar.ActiveReport3> subReportDic)
        // --- UPD ����� 2011/08/15----------<<<<<
        // --- UPD  ���r��  2010/06/29 ----------<<<<<
        {
            //----------------------------------------------------
            // �ȉ��̏����́A��{�I�Ɏ��̃|���V�[�ɏ]���L�q���܂��B
            // 
            // �@�E�`�[���ɑ΂���A�Œ薼�̂̃Z�b�g�Ȃǂ�
            // �@�@for�̑O�ɗ\�ߍs���܂��B
            //    �i�P��ŏI��点��ׁj
            // 
            // �@�E���׏��ɑ΂��鏈���́Afor�̒��ōs���܂��B
            //   �@�i���[�v���Q��܂킳�Ȃ��ׁj
            //
            // �������͏������x���d�����܂��B
            //----------------------------------------------------

            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            if (stc_priceTaxCalculator == null)
            {
                stc_priceTaxCalculator = new PriceTaxCalculator();
            }
            stc_priceTaxCalculator.TaxRateSet = taxRateSet;
            stc_priceTaxCalculator.SalesProcMoneyWorkList = salesProcMoneyList;
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            // --- ADD  ���r��  2010/05/13 ---------->>>>>
            if (stc_grossProfitCalculator == null)
            {
                stc_grossProfitCalculator = new GrossProfitCalculator();
            }
            // --- ADD  ���r��  2010/05/13 ----------<<<<<

            // �O���[�v�T�v���X�L�[(�O��ޔ�)
            GroupSuppressKey prevSuppressKey;

            // ����œ]�ŕ����i0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ېŁj
            int consTaxLayMethod = slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF;

            #region [�艿���z]
            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            //�艿���z����ň󎚃t���O
            bool listPriceTaxPrt = false;
            //���v���z(�Ŕ�)�i��ېł̏��i�ȊO�j
            Int64 ttlListPriceTaxFreeExc = 0;    

            //�艿���z(�Ŕ�)
            Dictionary<int, Int64> listPriceDic = new Dictionary<int,long>();
            //�艿���z�����
            Dictionary<int, Int64> listPriceTaxDic = new Dictionary<int,long>();
            //�艿���z���v�����
            Int64 ttlListPriceTax = 0;
            //�艿���z���v(�ō�)
            Int64 ttlListPrice = 0;
            //�[�������敪(������z�E�艿���z)
            int fracProcCode = slipWork.CSTCST_SALESMONEYFRCPROCCDRF;
            //�[�������敪(�����)s
            int taxFracProcCode = slipWork.CSTCST_SALESCNSTAXFRCPROCCDRF;
            //�`�[���s���t
            //DateTime printDate = (DateTime)slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF;
            DateTime printDate = TDateTime.LongDateToDateTime(slipWork.SALESSLIPRF_SALESDATERF);

            for( int index =0; index < detailWorks.Count; index++)
            {
                //�艿���z(�Ŕ�)�ɒl���Z�b�g
                decimal unfracPrice = (decimal)detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF * (decimal)detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;                                     
                Int64 targetPrice = stc_priceTaxCalculator.FractionProc(unfracPrice, fracProcCode);

                listPriceDic.Add(index, targetPrice);
                //�艿���z���v(�Ŕ�)�ɒl���Z�b�g
                ttlListPrice += targetPrice;           

                //��ېł̏��i
                if (detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF == 1)
                {
                    targetPrice = 0;
                }
                ttlListPriceTaxFreeExc += targetPrice;

                     
                
                //����p�^�[���ݒ�𔽉f����              
                if (CheckListPricePrint(detailWorks[index], eachSlipTypeSet) == true)
                {
                    listPriceTaxPrt = true;
                }
                

                //���ד]�ňȊO�͒艿���z����ł͂O���Z�b�g
                Int64 listPriceTax = 0;
                if (consTaxLayMethod != 1)
                {
                    listPriceTaxDic.Add(index, listPriceTax);
                }
                else
                {
                    //�艿���z����łɒl���Z�b�g               
                    listPriceTax = stc_priceTaxCalculator.GetTax(targetPrice, printDate, taxFracProcCode);
                    //��ېł̏��i�̏���ł��O�ɂ���
                    if (detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF == 1)
                    {
                        listPriceTax = 0;
                    }
                    listPriceTaxDic.Add(index, listPriceTax);
                }               

                //�艿���z���v����łɒl���Z�b�g
                ttlListPriceTax += listPriceTax;
            }

            //�艿���z���v�����(���ד]�ňȊO�̎�)  
            if (consTaxLayMethod != 1)
            {
                //���v���z(��ېł̏��i�ȊO�j�������ł��Z�o               
                ttlListPriceTax = stc_priceTaxCalculator.GetTax(ttlListPriceTaxFreeExc, printDate, taxFracProcCode);
            }            
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            #endregion


            // ������� (0:���,1:��)
            # region [����]
            DateTime printTime = new DateTime( slipWork.SALESSLIPRF_UPDATEDATETIMERF );
            slipWork.HADD_PRINTTIMEHOURRF = printTime.Hour;
            slipWork.HADD_PRINTTIMEMINUTERF = printTime.Minute;
            slipWork.HADD_PRINTTIMESECONDRF = printTime.Second;
            # endregion

            # region // DEL
            //// �擪�s�ԗ����Z�b�g
            //# region [�擪�s�ԗ����]
            //if ( detailWorks.Count > 0 )
            //{
            //    slipWork.HADD_CARMNGNORF = detailWorks[0].ACCEPTODRCARRF_CARMNGNORF;
            //    slipWork.HADD_CARMNGCODERF = detailWorks[0].ACCEPTODRCARRF_CARMNGCODERF;
            //    slipWork.HADD_NUMBERPLATE1CODERF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE1CODERF;
            //    slipWork.HADD_NUMBERPLATE1NAMERF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE1NAMERF;
            //    slipWork.HADD_NUMBERPLATE2RF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE2RF;
            //    slipWork.HADD_NUMBERPLATE3RF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE3RF;
            //    slipWork.HADD_NUMBERPLATE4RF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE4RF;
            //    slipWork.HADD_FIRSTENTRYDATERF = detailWorks[0].ACCEPTODRCARRF_FIRSTENTRYDATERF;
            //    slipWork.HADD_MAKERCODERF = detailWorks[0].ACCEPTODRCARRF_MAKERCODERF;
            //    slipWork.HADD_MAKERFULLNAMERF = detailWorks[0].ACCEPTODRCARRF_MAKERFULLNAMERF;
            //    slipWork.HADD_MODELCODERF = detailWorks[0].ACCEPTODRCARRF_MODELCODERF;
            //    slipWork.HADD_MODELSUBCODERF = detailWorks[0].ACCEPTODRCARRF_MODELSUBCODERF;
            //    slipWork.HADD_MODELFULLNAMERF = detailWorks[0].ACCEPTODRCARRF_MODELFULLNAMERF;
            //    slipWork.HADD_EXHAUSTGASSIGNRF = detailWorks[0].ACCEPTODRCARRF_EXHAUSTGASSIGNRF;
            //    slipWork.HADD_SERIESMODELRF = detailWorks[0].ACCEPTODRCARRF_SERIESMODELRF;
            //    slipWork.HADD_CATEGORYSIGNMODELRF = detailWorks[0].ACCEPTODRCARRF_CATEGORYSIGNMODELRF;
            //    slipWork.HADD_FULLMODELRF = detailWorks[0].ACCEPTODRCARRF_FULLMODELRF;
            //    slipWork.HADD_MODELDESIGNATIONNORF = detailWorks[0].ACCEPTODRCARRF_MODELDESIGNATIONNORF;
            //    slipWork.HADD_CATEGORYNORF = detailWorks[0].ACCEPTODRCARRF_CATEGORYNORF;
            //    slipWork.HADD_FRAMEMODELRF = detailWorks[0].ACCEPTODRCARRF_FRAMEMODELRF;
            //    slipWork.HADD_FRAMENORF = detailWorks[0].ACCEPTODRCARRF_FRAMENORF;
            //    slipWork.HADD_SEARCHFRAMENORF = detailWorks[0].ACCEPTODRCARRF_SEARCHFRAMENORF;
            //    slipWork.HADD_ENGINEMODELNMRF = detailWorks[0].ACCEPTODRCARRF_ENGINEMODELNMRF;
            //    slipWork.HADD_RELEVANCEMODELRF = detailWorks[0].ACCEPTODRCARRF_RELEVANCEMODELRF;
            //    slipWork.HADD_SUBCARNMCDRF = detailWorks[0].ACCEPTODRCARRF_SUBCARNMCDRF;
            //    slipWork.HADD_MODELGRADESNAMERF = detailWorks[0].ACCEPTODRCARRF_MODELGRADESNAMERF;
            //    slipWork.HADD_COLORCODERF = detailWorks[0].ACCEPTODRCARRF_COLORCODERF;
            //    slipWork.HADD_COLORNAME1RF = detailWorks[0].ACCEPTODRCARRF_COLORNAME1RF;
            //    slipWork.HADD_TRIMCODERF = detailWorks[0].ACCEPTODRCARRF_TRIMCODERF;
            //    slipWork.HADD_TRIMNAMERF = detailWorks[0].ACCEPTODRCARRF_TRIMNAMERF;
            //    slipWork.HADD_MILEAGERF = detailWorks[0].ACCEPTODRCARRF_MILEAGERF;
            //    slipWork.HADD_MAKERHALFNAMERF = detailWorks[0].ACCEPTODRCARRF_MAKERHALFNAMERF;
            //    slipWork.HADD_MODELHALFNAMERF = detailWorks[0].ACCEPTODRCARRF_MODELHALFNAMERF;
            //}
            //# endregion
            # endregion

            // �`�[work�e�햼��
            # region [slipWork�e�햼��]
            // HADD_ACPTANODRSTNMRF��HADD_SALESSLIPNMRF�͓������e�ŃZ�b�g����B

            //slipWork.HADD_ACPTANODRSTNMRF = GetHADD_ACPTANODRSTNMRF( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF );
            slipWork.HADD_ACPTANODRSTNMRF = GetHADD_ACPTANODRSTNMRF( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF, slipWork.SALESSLIPRF_SALESSLIPCDRF ); // �󒍽ð���{�`�[�敪
            slipWork.HADD_DEBITNOTEDIVNMRF = GetHADD_DEBITNOTEDIVNMRF( slipWork.SALESSLIPRF_DEBITNOTEDIVRF );
            //slipWork.HADD_SALESSLIPNMRF = GetHADD_SALESSLIPNMRF( slipWork.SALESSLIPRF_SALESSLIPCDRF );
            slipWork.HADD_SALESSLIPNMRF = slipWork.HADD_ACPTANODRSTNMRF;
            slipWork.HADD_SALESGOODSNMRF = GetHADD_SALESGOODSNMRF( slipWork.SALESSLIPRF_SALESGOODSCDRF );
            slipWork.HADD_ACCRECDIVNMRF = GetHADD_ACCRECDIVNMRF( slipWork.SALESSLIPRF_ACCRECDIVCDRF );
            slipWork.HADD_DELAYPAYMENTDIVNMRF = GetHADD_DELAYPAYMENTDIVNMRF( slipWork.SALESSLIPRF_DELAYPAYMENTDIVRF );
            slipWork.HADD_ESTIMATEDIVIDENMRF = GetHADD_ESTIMATEDIVIDENMRF( slipWork.SALESSLIPRF_ESTIMATEDIVIDERF );
            slipWork.HADD_CONSTAXLAYMETHODNMRF = GetHADD_CONSTAXLAYMETHODNMRF( slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF );
            slipWork.HADD_AUTODEPOSITNMRF = GetHADD_AUTODEPOSITNMRF( slipWork.SALESSLIPRF_AUTODEPOSITCDRF );
            slipWork.HADD_SLIPPRINTFINISHNMRF = GetHADD_SLIPPRINTFINISHNMRF( slipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF );
            //slipWork.HADD_COMPLETENMRF = GetHADD_COMPLETENMRF( slipWork.SALESSLIPRF_COMPLETECDRF );
            # endregion

            // �`�[��񒲐�
            # region [�`�[��񒲐�]
            // �ݏo�̏ꍇ��"������t"�����o�ד��t�Œu��������
            if ( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF == 40 )
            {
                slipWork.SALESSLIPRF_SALESDATERF = slipWork.SALESSLIPRF_SHIPMENTDAYRF;
            }
            # endregion

            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            // �p�q�R�[�h�f�[�^����
            # region [�p�q�R�[�h�f�[�^����]
            string qrData = string.Empty;
            string qrDataSource = string.Empty;

            // QR���ނ��\��t���Ă���ڲ��Ă̏ꍇ�̂ݏ�������
            if ( ReportItemDic.ContainsKey( ct_QRCode ) )
            {
                // QR���ވ������t���O
                bool qrCodePrint;
                // 2010/07/06 Add >>>
                // �g�у��[���t���O
                bool qrMailFlg = false;
                // 2010/07/06 Add <<<

                // qrCodePrint�̔���
                # region [qrCodePrint�̔���]
                // ���Ӑ�}�X�^.QR�R�[�h����敪(0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�)
                switch ( slipWork.CSTCST_QRCODEPRTCDRF )
                {
                    // 0:�W��
                    default:
                    case 0:
                        {
                            // �`�[����p�^�[���ݒ�.QR�R�[�h����敪((0:�W��) 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�)
                            switch ( slipPrtSet.QRCodePrintDivCd )
                            {
                                // (0:�W��) 1:���Ȃ� ... �}�X�����ɍ��킹��0��"������Ȃ�"�Ƃ݂Ȃ�
                                default:
                                case 0:
                                case 1:
                                    {
                                        qrCodePrint = false;
                                    }
                                    break;
                                // 2:�󎚂���
                                case 2:
                                    {
                                        if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
                                        {
                                            // ����Ȃ�Έ������
                                            qrCodePrint = true;
                                        }
                                        else
                                        {
                                            // �ԕi�Ȃ�Έ�����Ȃ�
                                            qrCodePrint = false;
                                        }
                                    }
                                    break;
                                // 3:�ԕi�܂�
                                case 3:
                                    {
                                        qrCodePrint = true;
                                    }
                                    break;
                                // 2010/07/06 Add >>>
                                // 4:�󎚂���i�g�у��[���j
                                case 4:
                                    {
                                        // 2010/07/09 QR�R�[�h�̃`�F�b�N���Ȃ��ꍇ�͈󎚂��Ȃ� Add >>>
                                        if (!slipPrintParameter.MakeQRDiv)
                                        {
                                            qrCodePrint = false;
                                            break;
                                        }
                                        // 2010/07/09 Add <<<
                                        if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 0)
                                        {
                                            // ����Ȃ�Έ������
                                            qrCodePrint = true;
                                            qrMailFlg = true;
                                        }
                                        else
                                        {
                                            // �ԕi�Ȃ�Έ�����Ȃ�
                                            qrCodePrint = false;
                                        }
                                    }
                                    break;
                                // 5:�ԕi�܂ށi�g�у��[���j
                                case 5:
                                    {
                                        // 2010/07/09 QR�R�[�h�̃`�F�b�N���Ȃ��ꍇ�͈󎚂��Ȃ� Add >>>
                                        if (!slipPrintParameter.MakeQRDiv)
                                        {
                                            qrCodePrint = false;
                                            break;
                                        }
                                        // 2010/07/09 Add <<<
                                        qrCodePrint = true;
                                        qrMailFlg = true;
                                    }
                                    break;
                                // 2010/07/06 Add <<<
                            }
                        }
                        break;
                    // 1:�󎚂��Ȃ�
                    case 1:
                        {
                            qrCodePrint = false;
                        }
                        break;
                    // 2:�󎚂���
                    case 2:
                        {
                            if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
                            {
                                // ����Ȃ�Έ������
                                qrCodePrint = true;
                            }
                            else
                            {
                                // �ԕi�Ȃ�Έ�����Ȃ�
                                qrCodePrint = false;
                            }
                        }
                        break;
                    // 3:�ԕi�܂�
                    case 3:
                        {
                            qrCodePrint = true;
                        }
                        break;
                    // 2010/07/06 Add >>>
                    // 4:�󎚂���i�g�у��[���j
                    case 4:
                        {
                            // 2010/07/09 QR�R�[�h�̃`�F�b�N���Ȃ��ꍇ�͈󎚂��Ȃ� Add >>>
                            if (!slipPrintParameter.MakeQRDiv)
                            {
                                qrCodePrint = false;
                                break;
                            }
                            // 2010/07/09 Add <<<
                            if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 0)
                            {
                                // ����Ȃ�Έ������
                                qrCodePrint = true;
                                qrMailFlg = true;
                            }
                            else
                            {
                                // �ԕi�Ȃ�Έ�����Ȃ�
                                qrCodePrint = false;
                            }
                        }
                        break;
                    // 5:�ԕi�܂ށi�g�у��[���j
                    case 5:
                        {
                            // 2010/07/09 QR�R�[�h�̃`�F�b�N���Ȃ��ꍇ�͈󎚂��Ȃ� Add >>>
                            if (!slipPrintParameter.MakeQRDiv)
                            {
                                qrCodePrint = false;
                                break;
                            }
                            // 2010/07/09 Add <<<
                            qrCodePrint = true;
                            qrMailFlg = true;
                        }
                        break;
                    // 2010/07/06 Add <<<
                }
                # endregion

                // QR���ޒ��o
                if ( qrCodePrint )
                {
                    // 2010/07/06 Add >>>
                    if (qrMailFlg)
                    {
                        qrData = MailQRDataCreateMediator.CreateData(slipWork.SALESSLIPRF_FILEHEADERGUID);
                        qrDataSource = slipWork.SALESSLIPRF_FILEHEADERGUID.ToString();
                    }
                    else
                        // 2010/07/06 Add <<<
                        SalesQRDataCreateMediator.CreateData(slipPrtSet.EnterpriseCode, slipWork, detailWorks, out qrDataSource, out qrData);
                }
            }
            # endregion
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<

            // �`�[�^�C�g���擾����
            List<List<string>> inPageCopyTitle = GetInPageCopyTitles( slipPrtSet );

            // �P�y�[�W�̖��׍s�����擾
            int feedCount = frePrtPSet.FormFeedLineCount;
            if ( feedCount <= 0 ) feedCount = 1;
            if ( slipPrtSet.DetailRowCount <= 0 ) slipPrtSet.DetailRowCount = feedCount;

            // ���s���擾
            int allDetailCount = GetAllDetailCount( detailWorks.Count, Math.Min( feedCount, slipPrtSet.DetailRowCount ) );

            // �S�y�[�W��
            int allPageCount = allDetailCount / Math.Min( feedCount, slipPrtSet.DetailRowCount );
            int pageStartIndex = 0;
            int pageEndIndex = pageStartIndex + feedCount - 1;

            int printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;

            for ( int pageIndex = 0; pageIndex < allPageCount; pageIndex++ )
            {
                // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                DataTable table = PMHNB08001PB.CreateFrePSalesSlipTable( currentIndex++ );
                retTables.Add( table );
                // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                // --- DEL m.suzuki 2010/03/24 ---------->>>>>
                # region // DEL
                //// �p�q�R�[�h�f�[�^����
                //# region [�p�q�R�[�h�f�[�^����]
                //string qrData = string.Empty;
                //// 0:���,1:��
                //if ( slipPrtSet.QRCodePrintDivCd == 1 )
                //{
                //    qrData = CreateQRData( slipWork, detailWorks, pageStartIndex, pageEndIndex );
                //}
                //# endregion
                # endregion
                // --- DEL m.suzuki 2010/03/24 ----------<<<<<

                for ( int inPageCopyCount = 0; inPageCopyCount < inPageCopyTitle[0].Count; inPageCopyCount++ )
                {
                    // �O��T�v���X�L�[�ޔ�p�N���A
                    prevSuppressKey = GroupSuppressKey.Create();

                    // ���׍s�ڍs
                    for ( int index = pageStartIndex; index <= pageEndIndex; index++ )
                    {
                        DataRow row = table.NewRow();

                        # region [���גǉ�]
                        // �y�[�W��
                        row[ct_PageCount] = pageIndex + 1;

                        // �ŏ��̃��R�[�h�^�Ō�̃��R�[�h�̂ݓ`�[���ڂ��Z�b�g����B
                        // (�P���ɖ��ׂ̐������{�������Ȃ���)
                        // �Ȃ������ł�"�Ō�̃��R�[�h"�Ƃ͋󔒍s�̉\�����܂ށB
                        if ( index == pageStartIndex || index == pageEndIndex )
                        {
                            # region [�y�[�W�擪�̎��p���]
                            slipWork.HADD_CARMNGNORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CARMNGNORF;
                            slipWork.HADD_CARMNGCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CARMNGCODERF;
                            slipWork.HADD_NUMBERPLATE1CODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE1CODERF;
                            slipWork.HADD_NUMBERPLATE1NAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE1NAMERF;
                            slipWork.HADD_NUMBERPLATE2RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE2RF;
                            slipWork.HADD_NUMBERPLATE3RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE3RF;
                            slipWork.HADD_NUMBERPLATE4RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE4RF;
                            slipWork.HADD_FIRSTENTRYDATERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FIRSTENTRYDATERF;
                            slipWork.HADD_MAKERCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MAKERCODERF;
                            slipWork.HADD_MAKERFULLNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MAKERFULLNAMERF;
                            slipWork.HADD_MODELCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELCODERF;
                            slipWork.HADD_MODELSUBCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELSUBCODERF;
                            slipWork.HADD_MODELFULLNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELFULLNAMERF;
                            slipWork.HADD_EXHAUSTGASSIGNRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_EXHAUSTGASSIGNRF;
                            slipWork.HADD_SERIESMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_SERIESMODELRF;
                            slipWork.HADD_CATEGORYSIGNMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CATEGORYSIGNMODELRF;
                            slipWork.HADD_FULLMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FULLMODELRF;
                            slipWork.HADD_MODELDESIGNATIONNORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELDESIGNATIONNORF;
                            slipWork.HADD_CATEGORYNORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CATEGORYNORF;
                            slipWork.HADD_FRAMEMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FRAMEMODELRF;
                            slipWork.HADD_FRAMENORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FRAMENORF;
                            slipWork.HADD_SEARCHFRAMENORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_SEARCHFRAMENORF;
                            slipWork.HADD_ENGINEMODELNMRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_ENGINEMODELNMRF;
                            slipWork.HADD_RELEVANCEMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_RELEVANCEMODELRF;
                            slipWork.HADD_SUBCARNMCDRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_SUBCARNMCDRF;
                            slipWork.HADD_MODELGRADESNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELGRADESNAMERF;
                            slipWork.HADD_COLORCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_COLORCODERF;
                            slipWork.HADD_COLORNAME1RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_COLORNAME1RF;
                            slipWork.HADD_TRIMCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_TRIMCODERF;
                            slipWork.HADD_TRIMNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_TRIMNAMERF;
                            slipWork.HADD_MILEAGERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MILEAGERF;
                            slipWork.HADD_MAKERHALFNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MAKERHALFNAMERF;
                            slipWork.HADD_MODELHALFNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELHALFNAMERF;
                            # endregion

                            # region [�`�[����Copy]
                            row["SALESSLIPRF.ACPTANODRSTATUSRF"] = slipWork.SALESSLIPRF_ACPTANODRSTATUSRF; // �󒍃X�e�[�^�X
                            row["SALESSLIPRF.SALESSLIPNUMRF"] = slipWork.SALESSLIPRF_SALESSLIPNUMRF; // ����`�[�ԍ�
                            row["SALESSLIPRF.SECTIONCODERF"] = slipWork.SALESSLIPRF_SECTIONCODERF; // ���_�R�[�h
                            row["SALESSLIPRF.SUBSECTIONCODERF"] = slipWork.SALESSLIPRF_SUBSECTIONCODERF; // ����R�[�h
                            row["SALESSLIPRF.DEBITNOTEDIVRF"] = slipWork.SALESSLIPRF_DEBITNOTEDIVRF; // �ԓ`�敪
                            row["SALESSLIPRF.DEBITNLNKSALESSLNUMRF"] = slipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF; // �ԍ��A������`�[�ԍ�
                            row["SALESSLIPRF.SALESSLIPCDRF"] = slipWork.SALESSLIPRF_SALESSLIPCDRF; // ����`�[�敪
                            row["SALESSLIPRF.SALESGOODSCDRF"] = slipWork.SALESSLIPRF_SALESGOODSCDRF; // ���㏤�i�敪
                            row["SALESSLIPRF.ACCRECDIVCDRF"] = slipWork.SALESSLIPRF_ACCRECDIVCDRF; // ���|�敪
                            row["SALESSLIPRF.SEARCHSLIPDATERF"] = slipWork.SALESSLIPRF_SEARCHSLIPDATERF; // �`�[�������t
                            row["SALESSLIPRF.SHIPMENTDAYRF"] = slipWork.SALESSLIPRF_SHIPMENTDAYRF; // �o�ד��t
                            row["SALESSLIPRF.SALESDATERF"] = slipWork.SALESSLIPRF_SALESDATERF; // ������t
                            row["SALESSLIPRF.ADDUPADATERF"] = slipWork.SALESSLIPRF_ADDUPADATERF; // �v����t
                            row["SALESSLIPRF.DELAYPAYMENTDIVRF"] = slipWork.SALESSLIPRF_DELAYPAYMENTDIVRF; // �����敪
                            row["SALESSLIPRF.ESTIMATEFORMNORF"] = slipWork.SALESSLIPRF_ESTIMATEFORMNORF; // ���Ϗ��ԍ�
                            row["SALESSLIPRF.ESTIMATEDIVIDERF"] = slipWork.SALESSLIPRF_ESTIMATEDIVIDERF; // ���ϋ敪
                            row["SALESSLIPRF.SALESINPUTCODERF"] = slipWork.SALESSLIPRF_SALESINPUTCODERF; // ������͎҃R�[�h
                            row["SALESSLIPRF.SALESINPUTNAMERF"] = slipWork.SALESSLIPRF_SALESINPUTNAMERF; // ������͎Җ���
                            row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF; // ��t�]�ƈ��R�[�h
                            row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEENMRF; // ��t�]�ƈ�����
                            row["SALESSLIPRF.SALESEMPLOYEECDRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEECDRF; // �̔��]�ƈ��R�[�h
                            row["SALESSLIPRF.SALESEMPLOYEENMRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEENMRF; // �̔��]�ƈ�����
                            row["SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF"] = slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF; // ���z�\�����@�敪
                            row["SALESSLIPRF.TTLAMNTDISPRATEAPYRF"] = slipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF; // ���z�\���|���K�p�敪
                            row["SALESSLIPRF.SALESTOTALTAXINCRF"] = slipWork.SALESSLIPRF_SALESTOTALTAXINCRF; // ����`�[���v�i�ō��݁j
                            row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF; // ����`�[���v�i�Ŕ����j
                            row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF; // ���㏬�v�i�ō��݁j
                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF; // ���㏬�v�i�Ŕ����j
                            //row["SALESSLIPRF.SALSENETPRICERF"] = slipWork.SALESSLIPRF_SALSENETPRICERF; // ���㐳�����z
                            row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXRF; // ���㏬�v�i�Łj
                            row["SALESSLIPRF.ITDEDSALESOUTTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF; // ����O�őΏۊz
                            row["SALESSLIPRF.ITDEDSALESINTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESINTAXRF; // ������őΏۊz
                            row["SALESSLIPRF.SALSUBTTLSUBTOTAXFRERF"] = slipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF; // ���㏬�v��ېőΏۊz
                            //row["SALESSLIPRF.SALSEOUTTAXRF"] = slipWork.SALESSLIPRF_SALSEOUTTAXRF; // ������z����Ŋz�i�O�Łj
                            row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = slipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF; // ������z����Ŋz�i���Łj
                            row["SALESSLIPRF.SALESDISTTLTAXEXCRF"] = slipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF; // ����l�����z�v�i�Ŕ����j
                            row["SALESSLIPRF.ITDEDSALESDISOUTTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF; // ����l���O�őΏۊz���v
                            row["SALESSLIPRF.ITDEDSALESDISINTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF; // ����l�����őΏۊz���v
                            //row["SALESSLIPRF.ITDEDSALSEDISTAXFRERF"] = slipWork.SALESSLIPRF_ITDEDSALSEDISTAXFRERF; // ����l����ېőΏۊz���v
                            row["SALESSLIPRF.SALESDISOUTTAXRF"] = slipWork.SALESSLIPRF_SALESDISOUTTAXRF; // ����l������Ŋz�i�O�Łj
                            row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = slipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF; // ����l������Ŋz�i���Łj
                            row["SALESSLIPRF.TOTALCOSTRF"] = slipWork.SALESSLIPRF_TOTALCOSTRF; // �������z�v
                            row["SALESSLIPRF.CONSTAXLAYMETHODRF"] = slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF; // ����œ]�ŕ���
                            row["SALESSLIPRF.CONSTAXRATERF"] = slipWork.SALESSLIPRF_CONSTAXRATERF; // ����Őŗ�
                            row["SALESSLIPRF.FRACTIONPROCCDRF"] = slipWork.SALESSLIPRF_FRACTIONPROCCDRF; // �[�������敪
                            row["SALESSLIPRF.ACCRECCONSTAXRF"] = slipWork.SALESSLIPRF_ACCRECCONSTAXRF; // ���|�����
                            row["SALESSLIPRF.AUTODEPOSITCDRF"] = slipWork.SALESSLIPRF_AUTODEPOSITCDRF; // ���������敪
                            row["SALESSLIPRF.AUTODEPOSITSLIPNORF"] = slipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF; // ���������`�[�ԍ�
                            row["SALESSLIPRF.DEPOSITALLOWANCETTLRF"] = slipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF; // �����������v�z
                            row["SALESSLIPRF.DEPOSITALWCBLNCERF"] = slipWork.SALESSLIPRF_DEPOSITALWCBLNCERF; // ���������c��
                            row["SALESSLIPRF.CLAIMCODERF"] = slipWork.SALESSLIPRF_CLAIMCODERF; // ������R�[�h
                            row["SALESSLIPRF.CLAIMSNMRF"] = slipWork.SALESSLIPRF_CLAIMSNMRF; // �����旪��
                            row["SALESSLIPRF.CUSTOMERCODERF"] = slipWork.SALESSLIPRF_CUSTOMERCODERF; // ���Ӑ�R�[�h
                            row["SALESSLIPRF.CUSTOMERNAMERF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF; // ���Ӑ於��
                            row["SALESSLIPRF.CUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF; // ���Ӑ於��2
                            row["SALESSLIPRF.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF; // ���Ӑ旪��
                            //row["SALESSLIPRF.HONORIFICTITLERF"] = slipWork.SALESSLIPRF_HONORIFICTITLERF; // �h��
                            row["SALESSLIPRF.ADDRESSEECODERF"] = slipWork.SALESSLIPRF_ADDRESSEECODERF; // �[�i��R�[�h
                            row["SALESSLIPRF.ADDRESSEENAMERF"] = slipWork.SALESSLIPRF_ADDRESSEENAMERF; // �[�i�於��
                            row["SALESSLIPRF.ADDRESSEENAME2RF"] = slipWork.SALESSLIPRF_ADDRESSEENAME2RF; // �[�i�於��2
                            row["SALESSLIPRF.ADDRESSEEPOSTNORF"] = slipWork.SALESSLIPRF_ADDRESSEEPOSTNORF; // �[�i��X�֔ԍ�
                            row["SALESSLIPRF.ADDRESSEEADDR1RF"] = slipWork.SALESSLIPRF_ADDRESSEEADDR1RF; // �[�i��Z��1(�s���{���s��S�E�����E��)
                            row["SALESSLIPRF.ADDRESSEEADDR3RF"] = slipWork.SALESSLIPRF_ADDRESSEEADDR3RF; // �[�i��Z��3(�Ԓn)
                            row["SALESSLIPRF.ADDRESSEEADDR4RF"] = slipWork.SALESSLIPRF_ADDRESSEEADDR4RF; // �[�i��Z��4(�A�p�[�g����)
                            row["SALESSLIPRF.ADDRESSEETELNORF"] = slipWork.SALESSLIPRF_ADDRESSEETELNORF; // �[�i��d�b�ԍ�
                            row["SALESSLIPRF.ADDRESSEEFAXNORF"] = slipWork.SALESSLIPRF_ADDRESSEEFAXNORF; // �[�i��FAX�ԍ�
                            row["SALESSLIPRF.PARTYSALESLIPNUMRF"] = slipWork.SALESSLIPRF_PARTYSALESLIPNUMRF; // �����`�[�ԍ�
                            row["SALESSLIPRF.SLIPNOTERF"] = slipWork.SALESSLIPRF_SLIPNOTERF; // �`�[���l
                            row["SALESSLIPRF.SLIPNOTE2RF"] = slipWork.SALESSLIPRF_SLIPNOTE2RF; // �`�[���l�Q
                            row["SALESSLIPRF.RETGOODSREASONDIVRF"] = slipWork.SALESSLIPRF_RETGOODSREASONDIVRF; // �ԕi���R�R�[�h
                            row["SALESSLIPRF.RETGOODSREASONRF"] = slipWork.SALESSLIPRF_RETGOODSREASONRF; // �ԕi���R
                            row["SALESSLIPRF.REGIPROCDATERF"] = slipWork.SALESSLIPRF_REGIPROCDATERF; // ���W������
                            row["SALESSLIPRF.CASHREGISTERNORF"] = slipWork.SALESSLIPRF_CASHREGISTERNORF; // ���W�ԍ�
                            row["SALESSLIPRF.POSRECEIPTNORF"] = slipWork.SALESSLIPRF_POSRECEIPTNORF; // POS���V�[�g�ԍ�
                            row["SALESSLIPRF.DETAILROWCOUNTRF"] = slipWork.SALESSLIPRF_DETAILROWCOUNTRF; // ���׍s��
                            row["SALESSLIPRF.EDISENDDATERF"] = slipWork.SALESSLIPRF_EDISENDDATERF; // �d�c�h���M��
                            row["SALESSLIPRF.EDITAKEINDATERF"] = slipWork.SALESSLIPRF_EDITAKEINDATERF; // �d�c�h�捞��
                            //row["SALESSLIPRF.UOEREMARK1RF"] = slipWork.SALESSLIPRF_UOEREMARK1RF; // �t�n�d���}�[�N�P
                            //row["SALESSLIPRF.UOEREMARK2RF"] = slipWork.SALESSLIPRF_UOEREMARK2RF; // �t�n�d���}�[�N�Q
                            row["SALESSLIPRF.SLIPPRINTFINISHCDRF"] = slipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF; // �`�[���s�ϋ敪
                            row["SALESSLIPRF.SALESSLIPPRINTDATERF"] = slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF; // ����`�[���s��
                            row["SALESSLIPRF.BUSINESSTYPECODERF"] = slipWork.SALESSLIPRF_BUSINESSTYPECODERF; // �Ǝ�R�[�h
                            row["SALESSLIPRF.BUSINESSTYPENAMERF"] = slipWork.SALESSLIPRF_BUSINESSTYPENAMERF; // �Ǝ햼��
                            row["SALESSLIPRF.ORDERNUMBERRF"] = slipWork.SALESSLIPRF_ORDERNUMBERRF; // �����ԍ�
                            row["SALESSLIPRF.DELIVEREDGOODSDIVRF"] = slipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF; // �[�i�敪
                            row["SALESSLIPRF.DELIVEREDGOODSDIVNMRF"] = slipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF; // �[�i�敪����
                            row["SALESSLIPRF.SALESAREACODERF"] = slipWork.SALESSLIPRF_SALESAREACODERF; // �̔��G���A�R�[�h
                            row["SALESSLIPRF.SALESAREANAMERF"] = slipWork.SALESSLIPRF_SALESAREANAMERF; // �̔��G���A����
                            //row["SALESSLIPRF.COMPLETECDRF"] = slipWork.SALESSLIPRF_COMPLETECDRF; // �ꎮ�`�[�敪
                            row["SALESSLIPRF.STOCKGOODSTTLTAXEXCRF"] = slipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF; // �݌ɏ��i���v���z�i�Ŕ��j
                            row["SALESSLIPRF.PUREGOODSTTLTAXEXCRF"] = slipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF; // �������i���v���z�i�Ŕ��j
                            row["SALESSLIPRF.LISTPRICEPRINTDIVRF"] = slipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF; // �艿����敪
                            row["SALESSLIPRF.ERANAMEDISPCD1RF"] = slipWork.SALESSLIPRF_ERANAMEDISPCD1RF; // �����\���敪�P
                            row["SALESSLIPRF.ESTIMATAXDIVCDRF"] = slipWork.SALESSLIPRF_ESTIMATAXDIVCDRF; // ���Ϗ���ŋ敪
                            row["SALESSLIPRF.ESTIMATEFORMPRTCDRF"] = slipWork.SALESSLIPRF_ESTIMATEFORMPRTCDRF; // ���Ϗ�����敪
                            row["SALESSLIPRF.ESTIMATESUBJECTRF"] = slipWork.SALESSLIPRF_ESTIMATESUBJECTRF; // ���ό���
                            row["SALESSLIPRF.FOOTNOTES1RF"] = slipWork.SALESSLIPRF_FOOTNOTES1RF; // �r���P
                            row["SALESSLIPRF.FOOTNOTES2RF"] = slipWork.SALESSLIPRF_FOOTNOTES2RF; // �r���Q
                            row["SALESSLIPRF.ESTIMATETITLE1RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE1RF; // ���σ^�C�g���P
                            row["SALESSLIPRF.ESTIMATETITLE2RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE2RF; // ���σ^�C�g���Q
                            row["SALESSLIPRF.ESTIMATETITLE3RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE3RF; // ���σ^�C�g���R
                            row["SALESSLIPRF.ESTIMATETITLE4RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE4RF; // ���σ^�C�g���S
                            row["SALESSLIPRF.ESTIMATETITLE5RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE5RF; // ���σ^�C�g���T
                            row["SALESSLIPRF.ESTIMATENOTE1RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE1RF; // ���ϔ��l�P
                            row["SALESSLIPRF.ESTIMATENOTE2RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE2RF; // ���ϔ��l�Q
                            row["SALESSLIPRF.ESTIMATENOTE3RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE3RF; // ���ϔ��l�R
                            row["SALESSLIPRF.ESTIMATENOTE4RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE4RF; // ���ϔ��l�S
                            row["SALESSLIPRF.ESTIMATENOTE5RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE5RF; // ���ϔ��l�T
                            row["SECINFOSETRF.SECTIONGUIDENMRF"] = slipWork.SECINFOSETRF_SECTIONGUIDENMRF; // ���_�K�C�h����
                            row["SECINFOSETRF.SECTIONGUIDESNMRF"] = slipWork.SECINFOSETRF_SECTIONGUIDESNMRF; // ���_�K�C�h����
                            row["SECINFOSETRF.COMPANYNAMECD1RF"] = slipWork.SECINFOSETRF_COMPANYNAMECD1RF; // ���Ж��̃R�[�h1
                            row["COMPANYNMRF.COMPANYPRRF"] = slipWork.COMPANYNMRF_COMPANYPRRF; // ����PR��
                            row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYNMRF_COMPANYNAME1RF; // ���Ж���1
                            row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYNMRF_COMPANYNAME2RF; // ���Ж���2
                            row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYNMRF_POSTNORF; // �X�֔ԍ�
                            row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYNMRF_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                            row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYNMRF_ADDRESS3RF; // �Z��3�i�Ԓn�j
                            row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYNMRF_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                            row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYNMRF_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                            row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYNMRF_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                            row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYNMRF_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                            row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                            row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                            row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                            row["COMPANYNMRF.TRANSFERGUIDANCERF"] = slipWork.COMPANYNMRF_TRANSFERGUIDANCERF; // ��s�U���ē���
                            row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO1RF; // ��s����1
                            row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO2RF; // ��s����2
                            row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO3RF; // ��s����3
                            row["COMPANYNMRF.COMPANYSETNOTE1RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE1RF; // ���Аݒ�E�v1
                            row["COMPANYNMRF.COMPANYSETNOTE2RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE2RF; // ���Аݒ�E�v2
                            row["COMPANYNMRF.IMAGEINFODIVRF"] = slipWork.COMPANYNMRF_IMAGEINFODIVRF; // �摜���敪
                            row["COMPANYNMRF.IMAGEINFOCODERF"] = slipWork.COMPANYNMRF_IMAGEINFOCODERF; // �摜���R�[�h
                            row["COMPANYNMRF.COMPANYURLRF"] = slipWork.COMPANYNMRF_COMPANYURLRF; // ����URL
                            row["COMPANYNMRF.COMPANYPRSENTENCE2RF"] = slipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF; // ����PR��2
                            row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF; // �摜�󎚗p�R�����g1
                            row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF; // �摜�󎚗p�R�����g2
                            row["IMAGEINFORF.IMAGEINFODATARF"] = slipWork.IMAGEINFORF_IMAGEINFODATARF; // ���Љ摜
                            row["SUBSECTIONRF.SUBSECTIONNAMERF"] = slipWork.SUBSECTIONRF_SUBSECTIONNAMERF; // ���喼��
                            row["EMPINP.KANARF"] = slipWork.EMPINP_KANARF; // ������͎҃J�i
                            row["EMPINP.SHORTNAMERF"] = slipWork.EMPINP_SHORTNAMERF; // ������͎ҒZ�k����
                            row["EMPFRT.KANARF"] = slipWork.EMPFRT_KANARF; // ��t�]�ƈ��J�i
                            row["EMPFRT.SHORTNAMERF"] = slipWork.EMPFRT_SHORTNAMERF; // ��t�]�ƈ��Z�k����
                            row["EMPSAL.KANARF"] = slipWork.EMPSAL_KANARF; // �̔��]�ƈ��J�i
                            row["EMPSAL.SHORTNAMERF"] = slipWork.EMPSAL_SHORTNAMERF; // �̔��]�ƈ��Z�k����
                            row["CSTCLM.CUSTOMERSUBCODERF"] = slipWork.CSTCLM_CUSTOMERSUBCODERF; // ������T�u�R�[�h
                            row["CSTCLM.NAMERF"] = slipWork.CSTCLM_NAMERF; // �����於��
                            row["CSTCLM.NAME2RF"] = slipWork.CSTCLM_NAME2RF; // �����於��2
                            row["CSTCLM.HONORIFICTITLERF"] = slipWork.CSTCLM_HONORIFICTITLERF; // ������h��
                            row["CSTCLM.KANARF"] = slipWork.CSTCLM_KANARF; // ������J�i
                            row["CSTCLM.CUSTOMERSNMRF"] = slipWork.CSTCLM_CUSTOMERSNMRF; // �����旪��
                            row["CSTCLM.OUTPUTNAMECODERF"] = slipWork.CSTCLM_OUTPUTNAMECODERF; // �����揔���R�[�h
                            row["CSTCLM.CUSTANALYSCODE1RF"] = slipWork.CSTCLM_CUSTANALYSCODE1RF; // �����敪�̓R�[�h1
                            row["CSTCLM.CUSTANALYSCODE2RF"] = slipWork.CSTCLM_CUSTANALYSCODE2RF; // �����敪�̓R�[�h2
                            row["CSTCLM.CUSTANALYSCODE3RF"] = slipWork.CSTCLM_CUSTANALYSCODE3RF; // �����敪�̓R�[�h3
                            row["CSTCLM.CUSTANALYSCODE4RF"] = slipWork.CSTCLM_CUSTANALYSCODE4RF; // �����敪�̓R�[�h4
                            row["CSTCLM.CUSTANALYSCODE5RF"] = slipWork.CSTCLM_CUSTANALYSCODE5RF; // �����敪�̓R�[�h5
                            row["CSTCLM.CUSTANALYSCODE6RF"] = slipWork.CSTCLM_CUSTANALYSCODE6RF; // �����敪�̓R�[�h6
                            row["CSTCLM.NOTE1RF"] = slipWork.CSTCLM_NOTE1RF; // ��������l1
                            row["CSTCLM.NOTE2RF"] = slipWork.CSTCLM_NOTE2RF; // ��������l2
                            row["CSTCLM.NOTE3RF"] = slipWork.CSTCLM_NOTE3RF; // ��������l3
                            row["CSTCLM.NOTE4RF"] = slipWork.CSTCLM_NOTE4RF; // ��������l4
                            row["CSTCLM.NOTE5RF"] = slipWork.CSTCLM_NOTE5RF; // ��������l5
                            row["CSTCLM.NOTE6RF"] = slipWork.CSTCLM_NOTE6RF; // ��������l6
                            row["CSTCLM.NOTE7RF"] = slipWork.CSTCLM_NOTE7RF; // ��������l7
                            row["CSTCLM.NOTE8RF"] = slipWork.CSTCLM_NOTE8RF; // ��������l8
                            row["CSTCLM.NOTE9RF"] = slipWork.CSTCLM_NOTE9RF; // ��������l9
                            row["CSTCLM.NOTE10RF"] = slipWork.CSTCLM_NOTE10RF; // ��������l10
                            row["CSTCST.CUSTOMERSUBCODERF"] = slipWork.CSTCST_CUSTOMERSUBCODERF; // ���Ӑ�T�u�R�[�h
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/07/02 DEL
                            //row["CSTCST.NAMERF"] = slipWork.CSTCST_NAMERF; // ���Ӑ於��
                            //row["CSTCST.NAME2RF"] = slipWork.CSTCST_NAME2RF; // ���Ӑ於��2
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/07/02 DEL
                            row["CSTCST.HONORIFICTITLERF"] = slipWork.CSTCST_HONORIFICTITLERF; // ���Ӑ�h��
                            row["CSTCST.KANARF"] = slipWork.CSTCST_KANARF; // ���Ӑ�J�i
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/07/02 DEL
                            //row["CSTCST.CUSTOMERSNMRF"] = slipWork.CSTCST_CUSTOMERSNMRF; // ���Ӑ旪��
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/07/02 DEL
                            row["CSTCST.OUTPUTNAMECODERF"] = slipWork.CSTCST_OUTPUTNAMECODERF; // ���Ӑ揔���R�[�h
                            // ---- ADD caohh 2011/08/17 ------>>>>>
                            row["CSTCST.POSTNORF"] = slipWork.CSTCST_POSTNORF;              // ���Ӑ�X�֔ԍ�
                            row["CSTCST.ADDRESS1RF"] = slipWork.CSTCST_ADDRESS1RF;          // ���Ӑ�Z��1�i�s���{���s��S�E�����E���j
                            row["CSTCST.ADDRESS3RF"] = slipWork.CSTCST_ADDRESS3RF;          // ���Ӑ�Z��3�i�Ԓn�j
                            row["CSTCST.ADDRESS4RF"] = slipWork.CSTCST_ADDRESS4RF;          // ���Ӑ�Z��4�i�A�p�[�g���́j
                            row["CSTCST.HOMETELNORF"] = slipWork.CSTCST_HOMETELNORF;        // ���Ӑ�d�b�ԍ��i����j
                            row["CSTCST.OFFICETELNORF"] = slipWork.CSTCST_OFFICETELNORF;    // ���Ӑ�d�b�ԍ��i�Ζ���j
                            row["CSTCST.PORTABLETELNORF"] = slipWork.CSTCST_PORTABLETELNORF;// ���Ӑ�d�b�ԍ��i�g�сj
                            row["CSTCST.OTHERSTELNORF"] = slipWork.CSTCST_OTHERSTELNORF;    // ���Ӑ�d�b�ԍ��i���̑��j
                            row["CSTCST.HOMEFAXNORF"] = slipWork.CSTCST_HOMEFAXNORF;        // ���Ӑ�FAX�ԍ��i����j
                            row["CSTCST.OFFICEFAXNORF"] = slipWork.CSTCST_OFFICEFAXNORF;    // ���Ӑ�FAX�ԍ��i�Ζ���j
                            // ---- ADD caohh 2011/08/17 ------<<<<<
                            row["CSTCST.CUSTANALYSCODE1RF"] = slipWork.CSTCST_CUSTANALYSCODE1RF; // ���Ӑ敪�̓R�[�h1
                            row["CSTCST.CUSTANALYSCODE2RF"] = slipWork.CSTCST_CUSTANALYSCODE2RF; // ���Ӑ敪�̓R�[�h2
                            row["CSTCST.CUSTANALYSCODE3RF"] = slipWork.CSTCST_CUSTANALYSCODE3RF; // ���Ӑ敪�̓R�[�h3
                            row["CSTCST.CUSTANALYSCODE4RF"] = slipWork.CSTCST_CUSTANALYSCODE4RF; // ���Ӑ敪�̓R�[�h4
                            row["CSTCST.CUSTANALYSCODE5RF"] = slipWork.CSTCST_CUSTANALYSCODE5RF; // ���Ӑ敪�̓R�[�h5
                            row["CSTCST.CUSTANALYSCODE6RF"] = slipWork.CSTCST_CUSTANALYSCODE6RF; // ���Ӑ敪�̓R�[�h6
                            row["CSTCST.NOTE1RF"] = slipWork.CSTCST_NOTE1RF; // ���Ӑ���l1
                            row["CSTCST.NOTE2RF"] = slipWork.CSTCST_NOTE2RF; // ���Ӑ���l2
                            row["CSTCST.NOTE3RF"] = slipWork.CSTCST_NOTE3RF; // ���Ӑ���l3
                            row["CSTCST.NOTE4RF"] = slipWork.CSTCST_NOTE4RF; // ���Ӑ���l4
                            row["CSTCST.NOTE5RF"] = slipWork.CSTCST_NOTE5RF; // ���Ӑ���l5
                            row["CSTCST.NOTE6RF"] = slipWork.CSTCST_NOTE6RF; // ���Ӑ���l6
                            row["CSTCST.NOTE7RF"] = slipWork.CSTCST_NOTE7RF; // ���Ӑ���l7
                            row["CSTCST.NOTE8RF"] = slipWork.CSTCST_NOTE8RF; // ���Ӑ���l8
                            row["CSTCST.NOTE9RF"] = slipWork.CSTCST_NOTE9RF; // ���Ӑ���l9
                            row["CSTCST.NOTE10RF"] = slipWork.CSTCST_NOTE10RF; // ���Ӑ���l10
                            row["CSTADR.CUSTOMERSUBCODERF"] = slipWork.CSTADR_CUSTOMERSUBCODERF; // �[����T�u�R�[�h
                            row["CSTADR.NAMERF"] = slipWork.CSTADR_NAMERF; // �[���於��
                            row["CSTADR.NAME2RF"] = slipWork.CSTADR_NAME2RF; // �[���於��2
                            row["CSTADR.HONORIFICTITLERF"] = slipWork.CSTADR_HONORIFICTITLERF; // �[����h��
                            row["CSTADR.KANARF"] = slipWork.CSTADR_KANARF; // �[����J�i
                            row["CSTADR.CUSTOMERSNMRF"] = slipWork.CSTADR_CUSTOMERSNMRF; // �[���旪��
                            row["CSTADR.OUTPUTNAMECODERF"] = slipWork.CSTADR_OUTPUTNAMECODERF; // �[���揔���R�[�h
                            row["CSTADR.CUSTANALYSCODE1RF"] = slipWork.CSTADR_CUSTANALYSCODE1RF; // �[���敪�̓R�[�h1
                            row["CSTADR.CUSTANALYSCODE2RF"] = slipWork.CSTADR_CUSTANALYSCODE2RF; // �[���敪�̓R�[�h2
                            row["CSTADR.CUSTANALYSCODE3RF"] = slipWork.CSTADR_CUSTANALYSCODE3RF; // �[���敪�̓R�[�h3
                            row["CSTADR.CUSTANALYSCODE4RF"] = slipWork.CSTADR_CUSTANALYSCODE4RF; // �[���敪�̓R�[�h4
                            row["CSTADR.CUSTANALYSCODE5RF"] = slipWork.CSTADR_CUSTANALYSCODE5RF; // �[���敪�̓R�[�h5
                            row["CSTADR.CUSTANALYSCODE6RF"] = slipWork.CSTADR_CUSTANALYSCODE6RF; // �[���敪�̓R�[�h6
                            row["CSTADR.NOTE1RF"] = slipWork.CSTADR_NOTE1RF; // �[������l1
                            row["CSTADR.NOTE2RF"] = slipWork.CSTADR_NOTE2RF; // �[������l2
                            row["CSTADR.NOTE3RF"] = slipWork.CSTADR_NOTE3RF; // �[������l3
                            row["CSTADR.NOTE4RF"] = slipWork.CSTADR_NOTE4RF; // �[������l4
                            row["CSTADR.NOTE5RF"] = slipWork.CSTADR_NOTE5RF; // �[������l5
                            row["CSTADR.NOTE6RF"] = slipWork.CSTADR_NOTE6RF; // �[������l6
                            row["CSTADR.NOTE7RF"] = slipWork.CSTADR_NOTE7RF; // �[������l7
                            row["CSTADR.NOTE8RF"] = slipWork.CSTADR_NOTE8RF; // �[������l8
                            row["CSTADR.NOTE9RF"] = slipWork.CSTADR_NOTE9RF; // �[������l9
                            row["CSTADR.NOTE10RF"] = slipWork.CSTADR_NOTE10RF; // �[������l10
                            row["COMPANYINFRF.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // ���Ж���1
                            row["COMPANYINFRF.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // ���Ж���2
                            row["COMPANYINFRF.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // �X�֔ԍ�
                            row["COMPANYINFRF.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                            row["COMPANYINFRF.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // �Z��3�i�Ԓn�j
                            row["COMPANYINFRF.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                            row["COMPANYINFRF.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                            row["COMPANYINFRF.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                            row["COMPANYINFRF.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                            row["HADD.ACPTANODRSTNMRF"] = slipWork.HADD_ACPTANODRSTNMRF; // �󒍃X�e�[�^�X����
                            row["HADD.DEBITNOTEDIVNMRF"] = slipWork.HADD_DEBITNOTEDIVNMRF; // �ԓ`�敪����
                            row["HADD.SALESSLIPNMRF"] = slipWork.HADD_SALESSLIPNMRF; // ����`�[�敪����
                            row["HADD.SALESGOODSNMRF"] = slipWork.HADD_SALESGOODSNMRF; // ���㏤�i�敪����
                            row["HADD.ACCRECDIVNMRF"] = slipWork.HADD_ACCRECDIVNMRF; // ���|�敪����
                            row["HADD.DELAYPAYMENTDIVNMRF"] = slipWork.HADD_DELAYPAYMENTDIVNMRF; // �����敪����
                            row["HADD.ESTIMATEDIVIDENMRF"] = slipWork.HADD_ESTIMATEDIVIDENMRF; // ���ϋ敪����
                            row["HADD.CONSTAXLAYMETHODNMRF"] = slipWork.HADD_CONSTAXLAYMETHODNMRF; // ����œ]�ŕ�������
                            row["HADD.AUTODEPOSITNMRF"] = slipWork.HADD_AUTODEPOSITNMRF; // ���������敪����
                            row["HADD.SLIPPRINTFINISHNMRF"] = slipWork.HADD_SLIPPRINTFINISHNMRF; // �`�[���s�ϋ敪����
                            row["HADD.COMPLETENMRF"] = slipWork.HADD_COMPLETENMRF; // �ꎮ�`�[�敪����
                            row["HADD.CARMNGNORF"] = slipWork.HADD_CARMNGNORF; // (�擪)�ԗ��Ǘ��ԍ�
                            row["HADD.CARMNGCODERF"] = slipWork.HADD_CARMNGCODERF; // (�擪)���q�Ǘ��R�[�h
                            row["HADD.NUMBERPLATE1CODERF"] = slipWork.HADD_NUMBERPLATE1CODERF; // (�擪)���^�������ԍ�
                            row["HADD.NUMBERPLATE1NAMERF"] = slipWork.HADD_NUMBERPLATE1NAMERF; // (�擪)���^�����ǖ���
                            row["HADD.NUMBERPLATE2RF"] = slipWork.HADD_NUMBERPLATE2RF; // (�擪)�ԗ��o�^�ԍ��i��ʁj
                            row["HADD.NUMBERPLATE3RF"] = slipWork.HADD_NUMBERPLATE3RF; // (�擪)�ԗ��o�^�ԍ��i�J�i�j
                            row["HADD.NUMBERPLATE4RF"] = slipWork.HADD_NUMBERPLATE4RF; // (�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            row["HADD.FIRSTENTRYDATERF"] = slipWork.HADD_FIRSTENTRYDATERF; // (�擪)���N�x
                            row["HADD.MAKERCODERF"] = slipWork.HADD_MAKERCODERF; // (�擪)���[�J�[�R�[�h
                            row["HADD.MAKERFULLNAMERF"] = slipWork.HADD_MAKERFULLNAMERF; // (�擪)���[�J�[�S�p����
                            row["HADD.MODELCODERF"] = slipWork.HADD_MODELCODERF; // (�擪)�Ԏ�R�[�h
                            row["HADD.MODELSUBCODERF"] = slipWork.HADD_MODELSUBCODERF; // (�擪)�Ԏ�T�u�R�[�h
                            row["HADD.MODELFULLNAMERF"] = slipWork.HADD_MODELFULLNAMERF; // (�擪)�Ԏ�S�p����
                            row["HADD.EXHAUSTGASSIGNRF"] = slipWork.HADD_EXHAUSTGASSIGNRF; // (�擪)�r�K�X�L��
                            row["HADD.SERIESMODELRF"] = slipWork.HADD_SERIESMODELRF; // (�擪)�V���[�Y�^��
                            row["HADD.CATEGORYSIGNMODELRF"] = slipWork.HADD_CATEGORYSIGNMODELRF; // (�擪)�^���i�ޕʋL���j
                            row["HADD.FULLMODELRF"] = slipWork.HADD_FULLMODELRF; // (�擪)�^���i�t���^�j
                            row["HADD.MODELDESIGNATIONNORF"] = slipWork.HADD_MODELDESIGNATIONNORF; // (�擪)�^���w��ԍ�
                            row["HADD.CATEGORYNORF"] = slipWork.HADD_CATEGORYNORF; // (�擪)�ޕʔԍ�
                            row["HADD.FRAMEMODELRF"] = slipWork.HADD_FRAMEMODELRF; // (�擪)�ԑ�^��
                            row["HADD.FRAMENORF"] = slipWork.HADD_FRAMENORF; // (�擪)�ԑ�ԍ�
                            row["HADD.SEARCHFRAMENORF"] = slipWork.HADD_SEARCHFRAMENORF; // (�擪)�ԑ�ԍ��i�����p�j
                            row["HADD.ENGINEMODELNMRF"] = slipWork.HADD_ENGINEMODELNMRF; // (�擪)�G���W���^������
                            row["HADD.RELEVANCEMODELRF"] = slipWork.HADD_RELEVANCEMODELRF; // (�擪)�֘A�^��
                            row["HADD.SUBCARNMCDRF"] = slipWork.HADD_SUBCARNMCDRF; // (�擪)�T�u�Ԗ��R�[�h
                            row["HADD.MODELGRADESNAMERF"] = slipWork.HADD_MODELGRADESNAMERF; // (�擪)�^���O���[�h����
                            row["HADD.COLORCODERF"] = slipWork.HADD_COLORCODERF; // (�擪)�J���[�R�[�h
                            row["HADD.COLORNAME1RF"] = slipWork.HADD_COLORNAME1RF; // (�擪)�J���[����1
                            row["HADD.TRIMCODERF"] = slipWork.HADD_TRIMCODERF; // (�擪)�g�����R�[�h
                            row["HADD.TRIMNAMERF"] = slipWork.HADD_TRIMNAMERF; // (�擪)�g��������
                            row["HADD.MILEAGERF"] = slipWork.HADD_MILEAGERF; // (�擪)�ԗ����s����
                            row["HADD.MAKERHALFNAMERF"] = slipWork.HADD_MAKERHALFNAMERF; // (�擪)���[�J�[���p����
                            row["HADD.MODELHALFNAMERF"] = slipWork.HADD_MODELHALFNAMERF; // (�擪)�Ԏ피�p����
                            row["HADD.PRINTERMNGNORF"] = slipWork.HADD_PRINTERMNGNORF; // �v�����^�Ǘ�No
                            row["HADD.SLIPPRTSETPAPERIDRF"] = slipWork.HADD_SLIPPRTSETPAPERIDRF; // �`�[����ݒ�p���[ID
                            row["HADD.NOTE1RF"] = slipWork.HADD_NOTE1RF; // ���Д��l�P
                            row["HADD.NOTE2RF"] = slipWork.HADD_NOTE2RF; // ���Д��l�Q
                            row["HADD.NOTE3RF"] = slipWork.HADD_NOTE3RF; // ���Д��l�R
                            row["HADD.REISSUEMARKRF"] = slipWork.HADD_REISSUEMARKRF; // �Ĕ��s�}�[�N
                            row["HADD.REFCONSTAXPRTNMRF"] = slipWork.HADD_REFCONSTAXPRTNMRF; // �Q�l����ň󎚖���
                            row["SALESSLIPRF.SLIPNOTE3RF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF; // �`�[���l�R
                            // --- ADD ���痈  2009.07.27 ---------->>>>>

                            // --- ADD 3H �k�P�N 2017/08/30---------->>>>>
                            #region�u�n���f�B�Ή��i2���j�v
                            // �o�[�R�[�h�i�`�[�ԍ��j
                            row["HPRT.BARCDSALESSLNUMRF"] = "*" + slipWork.SALESSLIPRF_SALESSLIPNUMRF + "*";
                            #endregion
                            // --- ADD 3H �k�P�N 2017/08/30----------<<<<<

                            // --- ADD  ���r��  2010/05/13 ---------->>>>>
                            if (index == pageStartIndex)
                            {
                                if (!String.IsNullOrEmpty(slipWork.SALESSLIPRF_UOEREMARK1RF) || !String.IsNullOrEmpty(slipWork.SALESSLIPRF_UOEREMARK2RF))
                                {
                                    row["SALESDETAILRF.UOEREMARK1DETAILRF"] = "C." + slipWork.SALESSLIPRF_UOEREMARK1RF; // �t�n�d���}�[�N�P
                                }
                                else
                                {
                                    row["SALESDETAILRF.UOEREMARK1DETAILRF"] = DBNull.Value; // �t�n�d���}�[�N�P
                                }
                            }
                            else
                            {
                                row["SALESDETAILRF.UOEREMARK1DETAILRF"] = DBNull.Value; // �t�n�d���}�[�N�P
                            }
                            // --- ADD  ���r��  2010/05/13 ----------<<<<<

                            // --- ADD  ���r��  2010/07/05 ---------->>>>>
                            // ����`�[�敪(�C�G���[�n�b�g�p)
                            if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 0)
                            {
                                row["HADD.SALESSLIPCDYHRF"] = "001";
                            }
                            else
                            {
                                row["HADD.SALESSLIPCDYHRF"] = "002";
                            }
                            // --- ADD  ���r��  2010/07/05 ----------<<<<<

                            //AB�Z�d�Ǘ��R�[�h
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {

                                row["SANDESETTINGRF.SANDEMNGCODERF"] = slipWork.SANDESETTINGRF_SANDEMNGCODE;
                            }
                            else
                            {
                                row["SANDESETTINGRF.SANDEMNGCODERF"] = 0;
                            }
                            //AB�[�i�Җ�
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {

                                row["SANDESETTINGRF.DELIVERERNMRF"] = slipWork.SANDESETTINGRF_DELIVERERNM;
                            }
                            else
                            {
                                row["SANDESETTINGRF.DELIVERERNMRF"] = string.Empty;
                            }

                            //AB�[�i�ҏZ��
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.DELIVERERADDRESSRF"] = slipWork.SANDESETTINGRF_DELIVERERADDRESS;
                            }
                            else
                            {
                                row["SANDESETTINGRF.DELIVERERADDRESSRF"] = string.Empty;
                            }

                            //AB�[�i�҂s�d�k
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                if ( string.IsNullOrEmpty( slipWork.SANDESETTINGRF_DELIVERERPHONENUM ) )
                                {
                                    row["SANDESETTINGRF.DELIVERERPHONENUMRF"] = string.Empty;
                                }
                                else
                                {
                                    row["SANDESETTINGRF.DELIVERERPHONENUMRF"] = "TEL " + slipWork.SANDESETTINGRF_DELIVERERPHONENUM;
                                }
                            }
                            else
                            {
                                row["SANDESETTINGRF.DELIVERERPHONENUMRF"] = string.Empty;
                            }

                            //AB�[�i��X�܃R�[�h
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.ADDRESSEESHOPCDRF"] = slipWork.SANDESETTINGRF_ADDRESSEESHOPCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.ADDRESSEESHOPCDRF"] = 0;
                            }
                            //AB�o��敪
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.EXPENSEDIVCDRF"] = slipWork.SANDESETTINGRF_EXPENSEDIVCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.EXPENSEDIVCDRF"] = 0;
                            }
                            //AB�����敪
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.DIRECTSENDINGCDRF"] = slipWork.SANDESETTINGRF_DIRECTSENDINGCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.DIRECTSENDINGCDRF"] = 0;
                            }
                            //AB�����敪
                            if ( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF == 30 )
                            {
                                if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
                                {
                                    row["HADD.ABILLCODERF"] = 010;
                                }
                                else if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 1 )
                                {
                                    row["HADD.ABILLCODERF"] = 020;
                                }
                            }
                            else
                            {
                                row["HADD.ABILLCODERF"] = DBNull.Value;
                            }
                            //AB�󒍋敪
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.ACPTANORDERDIVRF"] = slipWork.SANDESETTINGRF_ACPTANORDERDIV;
                            }
                            else
                            {
                                row["SANDESETTINGRF.ACPTANORDERDIVRF"] = 0;
                            }
                            //AB�[�i�҃R�[�h
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.DELIVERERCDRF"] = slipWork.SANDESETTINGRF_DELIVERERCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.DELIVERERCDRF"] = 0;
                            }
                            //AB���i����
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.TRADCOMPNAMERF"] = slipWork.SANDESETTINGRF_TRADCOMPNAME;
                            }
                            else
                            {
                                row["SANDESETTINGRF.TRADCOMPNAMERF"] = DBNull.Value;
                            }
                            // AB���i���R�[�h
                            // �擪���׍sAB�����敪���f
                            int goodsKindCd = GetGoodsKindCode( detailWorks[0], slipWork );
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                if ( goodsKindCd == 1 )
                                {
                                    row["HADD.ABTRADCOMPCDRF"] = slipWork.SANDESETTINGRF_PURETRADCOMPCD;
                                }
                                else if ( goodsKindCd == 2 )
                                {
                                    row["HADD.ABTRADCOMPCDRF"] = slipWork.SANDESETTINGRF_PRITRADCOMPCD;
                                }
                            }
                            else
                            {
                                row["HADD.ABTRADCOMPCDRF"] = 0;
                            }

                            //AB���i�����_��
                            if ( slipWork.SANDESETTINGRF_CUSTOMERCODE != 0 )
                            {
                                row["SANDESETTINGRF.TRADCOMPSECTNAMERF"] = slipWork.SANDESETTINGRF_TRADCOMPSECTNAME;
                            }
                            else
                            {
                                row["SANDESETTINGRF.TRADCOMPSECTNAMERF"] = string.Empty;
                            }
                            //AB�`�[���l�P
                            row["HADD.ABSLIPNOTE1RF"] = slipWork.SALESSLIPRF_SLIPNOTERF;
                            //AB�`�[���l�Q
                            row["HADD.ABSLIPNOTE2RF"] = slipWork.SALESSLIPRF_SLIPNOTERF;
                            //(�擪)AB�^���w��ԍ�
                            row["HADD.ABMODELDESIGNATIONNORF"] = slipWork.HADD_MODELDESIGNATIONNORF;
                            //(�擪)AB�ޕʔԍ�
                            row["HADD.ABCATEGORYNORF"] = slipWork.HADD_CATEGORYNORF;
                            // (�擪)AB�ޕʌ^���n�C�t��
                            if ( slipWork.HADD_MODELDESIGNATIONNORF != 0 || slipWork.HADD_CATEGORYNORF != 0 )
                            {
                                if ( slipWork.HADD_MODELDESIGNATIONNORF == 0 )
                                {
                                    row["HADD.ABMODELDESIGNATIONNORF"] = DBNull.Value;
                                }
                                if ( slipWork.HADD_CATEGORYNORF == 0 )
                                {
                                    row["HADD.ABCATEGORYNORF"] = DBNull.Value;
                                }
                                row["HPRT.ABCATEGORYHYPRF"] = "-";
                            }
                            else
                            {
                                row["HADD.ABMODELDESIGNATIONNORF"] = DBNull.Value;
                                row["HADD.ABCATEGORYNORF"] = DBNull.Value;
                                row["HPRT.ABCATEGORYHYPRF"] = string.Empty;
                            }
                            //(�擪)AB�^���i�t���^�j
                            row["HADD.ABFULLMODELRF"] = slipWork.HADD_FULLMODELRF;

                            // ���N�x
                            // �N��
                            ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_FIRSTENTRYDATERF, "HADD.ABFIRSTENTRYDATE", true );// yyyymm

                            ////(�擪)AB���N�x����N
                            //row["HADD.ABFIRSTENTRYDATEFYRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x����N��
                            //row["HADD.ABFIRSTENTRYDATEFSRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x�a��N
                            //row["HADD.ABFIRSTENTRYDATEFWRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x��
                            //row["HADD.ABFIRSTENTRYDATEFMRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x����
                            //row["HADD.ABFIRSTENTRYDATEFGRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x����
                            //row["HADD.ABFIRSTENTRYDATEFRRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x���e����(/)
                            //row["HADD.ABFIRSTENTRYDATEFLSRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x���e����(.)
                            //row["HADD.ABFIRSTENTRYDATEFLPRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x���e����(�N)
                            //row["HADD.ABFIRSTENTRYDATEFLYRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            ////(�擪)AB���N�x���e����(��)
                            //row["HADD.ABFIRSTENTRYDATEFLMRF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF;
                            // (�擪)AB�ԑ�ԍ�
                            row["HADD.ABFRAMENORF"] = slipWork.HADD_FRAMENORF;
                            // (�擪)AB�Ԏ피�p����
                            row["HADD.ABMODELHALFNAMERF"] = slipWork.HADD_MODELHALFNAMERF;
                            // --- ADD  xuyb  2013/02/19 Redmine#34615�@No.1639�[�i�� ---------->>>>>
                            if (string.IsNullOrEmpty(slipWork.HADD_MODELHALFNAMERF))
                            {
                                row["HADD.ABMODELHALFNAMERF"] = GetKanaString(slipWork.HADD_MODELFULLNAMERF);
                            }
                            // --- ADD  xuyb  2013/02/19 Redmine#34615�@No.1639�[�i�� ----------<<<<<

                            // �R�����g�w��敪
                            if ( slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 0 )
                            {
                                row["HADD.ABSLIPNOTE1RF"] = string.Empty;
                                row["HADD.ABSLIPNOTE2RF"] = string.Empty;
                                row["HADD.ABMODELDESIGNATIONNORF"] = string.Empty;
                                row["HPRT.ABCATEGORYHYPRF"] = string.Empty;
                                row["HADD.ABCATEGORYNORF"] = string.Empty;
                                row["HADD.ABFULLMODELRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFYRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFSRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFWRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFMRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFGRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFRRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLSRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLPRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLYRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLMRF"] = string.Empty;
                                row["HADD.ABFRAMENORF"] = string.Empty;
                                row["HADD.ABMODELHALFNAMERF"] = string.Empty;
                            }
                            else if ( slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 1 )
                            {
                                row["HADD.ABSLIPNOTE2RF"] = string.Empty;
                                row["HADD.ABMODELDESIGNATIONNORF"] = string.Empty;
                                row["HPRT.ABCATEGORYHYPRF"] = string.Empty;
                                row["HADD.ABCATEGORYNORF"] = string.Empty;
                                row["HADD.ABFULLMODELRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFYRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFSRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFWRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFMRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFGRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFRRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLSRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLPRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLYRF"] = string.Empty;
                                row["HADD.ABFIRSTENTRYDATEFLMRF"] = string.Empty;
                                row["HADD.ABFRAMENORF"] = string.Empty;
                                row["HADD.ABMODELHALFNAMERF"] = string.Empty;
                            }
                            else if ( slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 2 )
                            {
                                row["HADD.ABSLIPNOTE1RF"] = string.Empty;
                                row["HADD.ABSLIPNOTE2RF"] = string.Empty;
                            }
                            else if ( slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 3 )
                            {
                                row["HADD.ABSLIPNOTE1RF"] = string.Empty;
                            }



                            //����`�[���v�i�Ŕ����j(�}�C�i�X�����Ȃ�)
                            row["HADD.SALESTOTALTAXEXCNOMINUSRF"] = Math.Abs( slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF );
                            //����`�[���v�i�Ŕ����j
                            row["HADD.SALESTOTALTAXEXCWITHMINUSRF"] = slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                            // --- DEL  ���r��  2010/03/01 ---------->>>>>
                            //// �艿���z���v(�Ŕ�)
                            //long result = 0;
                            //foreach ( FrePSalesDetailWork detailWork in detailWorks )
                            //{
                            //    //result += detailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                            //    long afterUnit = 0;
                            //    double beforeUnit = detailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                            //    // �[������                                
                            //    FractionCalculate.FracCalcMoney( beforeUnit, 1, 2, out afterUnit );                                                               
                            //    result += afterUnit;
                            //}                            
                            //row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = result;
                            // --- DEL  ���r��  2010/03/01 ----------<<<<<
                            // AB�{���������z���v(�}�C�i�X�����Ȃ�)
                            long costResult = 0;
                            foreach ( FrePSalesDetailWork detailWork in detailWorks )
                            {
                                //costResult += GetABHqSalesUnitCost(detailWork, slipWork) * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                                long afterUnit = 0;
                                double beforeUnit = GetABHqSalesUnitCost( detailWork, slipWork ) * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                                // �[������
                                FractionCalculate.FracCalcMoney( beforeUnit, 1, 2, out afterUnit );
                                costResult += afterUnit;
                            }
                            row["HADD.ABHQTOTALCOSTNOMINUSRF"] = Math.Abs( costResult );
                            //AB�{���������z���v
                            row["HADD.ABHQTOTALCOSTWITHMINUSRF"] = costResult;

                            // --- ADD ���痈�@2009.07.27 ----------<<<<<
                           
                            // --- ADD  ���r��  2010/05/13 ---------->>>>>
                            //���v�e�����z
                            row["HADD.GROSSPROFITTTLRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF - slipWork.SALESSLIPRF_TOTALCOSTRF;
                            //���v�e����
                            row["HADD.GROSSPROFITRATETTLRF"] = stc_grossProfitCalculator.CalcGrossProfitRate(slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF, slipWork.SALESSLIPRF_TOTALCOSTRF);
                            // --- ADD  ���r��  2010/05/13 ----------<<<<<

                            // --- ADD  ���r��  2010/06/03 ---------->>>>>
                            Double shipmentCntTtl = 0;
                            foreach( FrePSalesDetailWork detailWork in detailWorks )
                            {
                                shipmentCntTtl += detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                            }
                            row["HADD.SHIPMENTCNTTTLRF"] = shipmentCntTtl;
                            // --- ADD  ���r��  2010/06/03 ----------<<<<<
                            # endregion

                            # region [�`�[����(�����ȊO)]

                            // ���ݒ莞 ��󎚃R�[�h
                            # region [���ݒ�]
                            if ( IsZero( slipWork.SALESSLIPRF_SUBSECTIONCODERF ) ) row["SALESSLIPRF.SUBSECTIONCODERF"] = DBNull.Value; // ����R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_CLAIMCODERF ) ) row["SALESSLIPRF.CLAIMCODERF"] = DBNull.Value; // ������R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_CUSTOMERCODERF ) ) row["SALESSLIPRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_ADDRESSEECODERF ) ) row["SALESSLIPRF.ADDRESSEECODERF"] = DBNull.Value; // �[�i��R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_RETGOODSREASONDIVRF ) ) row["SALESSLIPRF.RETGOODSREASONDIVRF"] = DBNull.Value; // �ԕi���R�R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_BUSINESSTYPECODERF ) ) row["SALESSLIPRF.BUSINESSTYPECODERF"] = DBNull.Value; // �Ǝ�R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF ) ) row["SALESSLIPRF.DELIVEREDGOODSDIVRF"] = DBNull.Value; // �[�i�敪
                            if ( IsZero( slipWork.SALESSLIPRF_SALESAREACODERF ) ) row["SALESSLIPRF.SALESAREACODERF"] = DBNull.Value; // �̔��G���A�R�[�h
                            if ( IsZero( slipWork.HADD_MODELDESIGNATIONNORF ) ) row["HADD.MODELDESIGNATIONNORF"] = DBNull.Value; // (�擪)�^���w��ԍ�
                            if ( IsZero( slipWork.HADD_CATEGORYNORF ) ) row["HADD.CATEGORYNORF"] = DBNull.Value; // (�擪)�ޕʔԍ�
                            if ( IsZero( slipWork.HADD_MAKERCODERF ) ) row["HADD.MAKERCODERF"] = DBNull.Value; // (�擪)���[�J�[�R�[�h
                            if ( IsZero( slipWork.HADD_MODELCODERF ) ) row["HADD.MODELCODERF"] = DBNull.Value; // (�擪)�Ԏ�R�[�h
                            if ( IsZero( slipWork.HADD_MODELSUBCODERF ) ) row["HADD.MODELSUBCODERF"] = DBNull.Value; // (�擪)�Ԏ�T�u�R�[�h
                            if ( IsZero( slipWork.HADD_CARMNGNORF ) ) row["HADD.CARMNGNORF"] = DBNull.Value; // (�擪)�ԗ��Ǘ��ԍ�
                            if ( IsZero( slipWork.HADD_NUMBERPLATE1CODERF ) ) row["HADD.NUMBERPLATE1CODERF"] = DBNull.Value; // (�擪)���^�������ԍ�
                            if ( IsZero( slipWork.HADD_NUMBERPLATE4RF ) ) row["HADD.NUMBERPLATE4RF"] = DBNull.Value; // (�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            if ( IsZero( slipWork.HADD_FIRSTENTRYDATERF ) ) row["HADD.FIRSTENTRYDATERF"] = DBNull.Value; // (�擪)���N�x
                            if ( IsZero( slipWork.HADD_SEARCHFRAMENORF ) ) row["HADD.SEARCHFRAMENORF"] = DBNull.Value; // (�擪)�ԑ�ԍ��i�����p�j
                            if ( IsZero( slipWork.HADD_SUBCARNMCDRF ) ) row["HADD.SUBCARNMCDRF"] = DBNull.Value; // (�擪)�T�u�Ԗ��R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_SECTIONCODERF ) ) row["SALESSLIPRF.SECTIONCODERF"] = DBNull.Value; // ���_�R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_SALESINPUTCODERF ) ) row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // ������͎҃R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF ) ) row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // ��t�]�ƈ��R�[�h
                            if ( IsZero( slipWork.SALESSLIPRF_SALESEMPLOYEECDRF ) ) row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // �̔��]�ƈ��R�[�h
                            # endregion

                            // ���Џ��
                            # region [���Џ��̐���]
                            // 0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�
                            switch ( slipPrtSet.EnterpriseNamePrtCd )
                            {
                                // ���Ж�
                                case 0:
                                    {
                                        // CompanyInf�̓��e�ɍ����ւ���
                                        row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // ���Ж���1
                                        row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // ���Ж���2
                                        row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // �X�֔ԍ�
                                        row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                                        row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // �Z��3�i�Ԓn�j
                                        row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                                        row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                                        row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                                        row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                                        row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                                        row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                                        row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                                        // bitmap�Ȃ�
                                        row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                        row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                    }
                                    break;
                                // ���_��
                                case 1:
                                    {
                                        // bitmap�Ȃ�
                                        row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                        row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                    }
                                    break;
                                // �r�b�g�}�b�v
                                case 2:
                                    {
                                        // ���Џ�񕶎���Ȃ�
                                        row["COMPANYNMRF.COMPANYNAME1RF"] = DBNull.Value; // ���Ж���1
                                        row["COMPANYNMRF.COMPANYNAME2RF"] = DBNull.Value; // ���Ж���2
                                        row["COMPANYNMRF.POSTNORF"] = DBNull.Value; // �X�֔ԍ�
                                        row["COMPANYNMRF.ADDRESS1RF"] = DBNull.Value; // �Z��1�i�s���{���s��S�E�����E���j
                                        row["COMPANYNMRF.ADDRESS3RF"] = DBNull.Value; // �Z��3�i�Ԓn�j
                                        row["COMPANYNMRF.ADDRESS4RF"] = DBNull.Value; // �Z��4�i�A�p�[�g���́j
                                        row["COMPANYNMRF.COMPANYTELNO1RF"] = DBNull.Value; // ���Гd�b�ԍ�1
                                        row["COMPANYNMRF.COMPANYTELNO2RF"] = DBNull.Value; // ���Гd�b�ԍ�2
                                        row["COMPANYNMRF.COMPANYTELNO3RF"] = DBNull.Value; // ���Гd�b�ԍ�3
                                        row["COMPANYNMRF.COMPANYTELTITLE1RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��1
                                        row["COMPANYNMRF.COMPANYTELTITLE2RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��2
                                        row["COMPANYNMRF.COMPANYTELTITLE3RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��3
                                    }
                                    break;
                                // �󎚂��Ȃ�
                                case 3:
                                default:
                                    {
                                        // ���Џ�񕶎���Ȃ�
                                        row["COMPANYNMRF.COMPANYNAME1RF"] = DBNull.Value; // ���Ж���1
                                        row["COMPANYNMRF.COMPANYNAME2RF"] = DBNull.Value; // ���Ж���2
                                        row["COMPANYNMRF.POSTNORF"] = DBNull.Value; // �X�֔ԍ�
                                        row["COMPANYNMRF.ADDRESS1RF"] = DBNull.Value; // �Z��1�i�s���{���s��S�E�����E���j
                                        row["COMPANYNMRF.ADDRESS3RF"] = DBNull.Value; // �Z��3�i�Ԓn�j
                                        row["COMPANYNMRF.ADDRESS4RF"] = DBNull.Value; // �Z��4�i�A�p�[�g���́j
                                        row["COMPANYNMRF.COMPANYTELNO1RF"] = DBNull.Value; // ���Гd�b�ԍ�1
                                        row["COMPANYNMRF.COMPANYTELNO2RF"] = DBNull.Value; // ���Гd�b�ԍ�2
                                        row["COMPANYNMRF.COMPANYTELNO3RF"] = DBNull.Value; // ���Гd�b�ԍ�3
                                        row["COMPANYNMRF.COMPANYTELTITLE1RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��1
                                        row["COMPANYNMRF.COMPANYTELTITLE2RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��2
                                        row["COMPANYNMRF.COMPANYTELTITLE3RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��3
                                        // bitmap�Ȃ�
                                        row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                        row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                    }
                                    break;
                            }

                            // ���Ж��P����
                            if ( row["COMPANYNMRF.COMPANYNAME1RF"] != DBNull.Value )
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName( (string)row["COMPANYNMRF.COMPANYNAME1RF"], out firstHalf, out lastHalf );
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
                            }
                            // ���Ж��Q����
                            if ( row["COMPANYNMRF.COMPANYNAME2RF"] != DBNull.Value )
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName( (string)row["COMPANYNMRF.COMPANYNAME2RF"], out firstHalf, out lastHalf );
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
                            }
                            # endregion

                            // ���Д��l
                            # region [���Д��l]
                            row["HADD.NOTE1RF"] = slipPrtSet.Note1; // ���Д��l�P
                            row["HADD.NOTE2RF"] = slipPrtSet.Note2; // ���Д��l�Q
                            row["HADD.NOTE3RF"] = slipPrtSet.Note3; // ���Д��l�R
                            # endregion

                            // �Ĕ��s�}�[�N
                            # region [�Ĕ��s�}�[�N]
                            if ( slipPrintParameter.ReissueDiv )
                            {
                                row["HADD.REISSUEMARKRF"] = slipPrtSet.ReissueMark; // �Ĕ��s�}�[�N
                            }
                            else
                            {
                                row["HADD.REISSUEMARKRF"] = string.Empty;
                            }
                            # endregion

                            // ����ň󎚐���
                            # region [���v��]
                            // ��ېŊ܂܂Ȃ��v����ېŊ܂ތv�ŏ���������
                            row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXINCRF"];
                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                            // A700���C�A�E�g�p�̍��v���ڂ�ǉ��B(�󎚈ʒu�𐧌䂷���)
                            row["HADD.SALESTOTALTAXINCA700RF"] = row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"];
                            row["HADD.SALESTOTALTAXEXCA700RF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD

                            // --- ADD  ���r��  2010/06/03 ---------->>>>>
                            #region[�`�[���z(���ד]�ł̂ݐō�)]
                            if (consTaxLayMethod == 1)
                            {
                                //���ד]�Ł@�ō����z
                                row["HADD.SALESTTLTAXLAYDTLRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"];
                            }
                            else
                            {
                                //���ד]�ňȊO�@�Ŕ����z
                                row["HADD.SALESTTLTAXLAYDTLRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                            }
                            #endregion
                            // --- ADD  ���r��  2010/06/03 ----------<<<<<

                            if ( pageIndex == allPageCount - 1 )
                            {
                                


                                // �]�ŕ���
                                switch ( consTaxLayMethod )
                                {         
                                    case 0:
                                    case 1:
                                        {
                                            // �`�[�]�ŁE���ד]��

                                            // �Q�l����ň󎚖��̂͋�
                                            row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;

                                            // ����ň󎚗L��(0:���Ȃ�/1:����)
                                            if ( slipPrtSet.ConsTaxPrtCdRF == 1 )
                                            {
                                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                                
                                                //�`�[���v(�����]��)�͋�
                                                row["HADD.SALESTTLTAXINCDMD"] = DBNull.Value;

                                                #region[�艿���z]
                                                //�艿�̍��v���z
                                                if (listPriceTaxPrt == true)
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = ttlListPrice;
                                                    //�艿���z���v�����
                                                    row["HADD.LISTPRICEMONEYTOTALTAXRF"] = ttlListPriceTax;
                                                    //�艿���z���v(�ō�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = ttlListPrice + ttlListPriceTax;
                                                }
                                                else
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;
                                                    //�艿���z���v�����
                                                    row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                                    //�艿���z���v(�ō�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;
                                                }
                                                #endregion
                                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                            }
                                            else
                                            {
                                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                                //�`�[���v(���ד]�ł̂ݐō�)�ɐŔ��̋��z���Z�b�g
                                                row["HADD.SALESTTLTAXLAYDTLRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // --- ADD  ���r��  2010/06/03 ----------<<<<<

                                                // ���v���ɏ��v
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // ���v���͋�
                                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                                // ����ł͋�
                                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;

                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                                                // A700�p
                                                // (���v���͋�)
                                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                                //// (���v���ɏ��v)
                                                //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD

                                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                                #region[�艿���z]
                                                //�艿�̍��v���z
                                                if (listPriceTaxPrt == true)
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = ttlListPrice;
                                                }
                                                else
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;
                                                }

                                                //�艿���z���v�����
                                                row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                                //�艿���z���v(�ō�)
                                                row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;
                                                #endregion

                                                //�`�[���v(�����]��)�͋�
                                                row["HADD.SALESTTLTAXINCDMD"] = DBNull.Value;
                                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                            }
                                        }
                                        break;
                                    case 2:
                                    case 3:
                                        {
                                            // �����e�E�����q

                                            // �Q�l����ň󎚗L��(0:���Ȃ�/1:����)
                                            if ( slipPrtSet.RefConsTaxDivCd == 1 )
                                            {
                                                // �Q�l����ň󎚖���
                                                row["HADD.REFCONSTAXPRTNMRF"] = slipPrtSet.RefConsTaxPrtNm;
                                                // ���v���ɏ��v
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // ���v���͋�
                                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;

                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                                                // A700�p
                                                // (���v���͋�)
                                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                                //// (���v���ɏ��v)
                                                //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD

                                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                                #region[�艿���z]
                                                //�艿�̍��v���z
                                                if (listPriceTaxPrt == true)
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = ttlListPrice;
                                                    //�艿���z���v�����
                                                    row["HADD.LISTPRICEMONEYTOTALTAXRF"] = ttlListPriceTax;
                                                    //�艿���z���v(�ō�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = ttlListPrice + ttlListPriceTax;
                                                }
                                                else
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;
                                                    //�艿���z���v�����
                                                    row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                                    //�艿���z���v(�ō�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;
                                                }
                                                #endregion

                                                //�`�[���v(�����]��)
                                                row["HADD.SALESTTLTAXINCDMD"] = slipWork.SALESSLIPRF_SALESTOTALTAXINCRF;
                                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                            }
                                            else
                                            {
                                                //// �Q�l����ň󎚖���
                                                //row["HADD.REFCONSTAXPRTNMRF"] = string.Empty;
                                                //// ����ł͋�
                                                //row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                                ////row["SALESSLIPRF.SALSEOUTTAXRF"] = DBNull.Value;
                                                //row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                                //row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                                //row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;

                                                // �Q�l����ň󎚖���
                                                row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                                // ���v���ɏ��v
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // ���v���͋�
                                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                                // ����ł͋�
                                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;

                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                                                // A700�p
                                                // (���v���͋�)
                                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                                //// (���v���ɏ��v)
                                                //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD

                                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                                //�艿�̍��v���z
                                                if (listPriceTaxPrt == true)
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = ttlListPrice;
                                                }
                                                else
                                                {
                                                    //�艿���z���v(�Ŕ�)
                                                    row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;
                                                }
                                                //�艿���z���v����ł͋�
                                                row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                                //�艿���z���v(�ō�)�͋�
                                                row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;
                                                //�`�[���v(�����]��)�͋�
                                                row["HADD.SALESTTLTAXINCDMD"] = DBNull.Value;
                                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                            }
                                        }
                                        break;
                                    case 9:
                                    default:
                                        {
                                            // ��ې�

                                            // ���v���ɏ��v
                                            row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                            row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                            // ���v���͋�
                                            row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;

                                            // �Q�l����ň󎚖���
                                            row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                            // ����ł͋�
                                            row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                            //row["SALESSLIPRF.SALSEOUTTAXRF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;

                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                                            // A700�p
                                            // (���v���͋�)
                                            row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                            //// (���v���ɏ��v)
                                            //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD

                                            // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                            if (listPriceTaxPrt == true)
                                            {
                                                //�艿���z���v(�Ŕ�)
                                                row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = ttlListPrice;
                                            }
                                            else
                                            {
                                                //�艿���z���v(�Ŕ�)
                                                row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;
                                            }
                                            //�艿���z���v����ł͋�
                                            row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                            //�艿���z���v(�ō�)�͋�
                                            row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;
                                            //�`�[���v(�����]��)�͋�
                                            row["HADD.SALESTTLTAXINCDMD"] = DBNull.Value;
                                            // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                // ���v��
                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                // ���v��
                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                // �Q�l����ň󎚖���
                                row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                // �����
                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                                // A700�p
                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                row["HADD.SALESTOTALTAXEXCA700RF"] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD

                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                //�艿���z���v(�Ŕ�)
                                row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;
                                //�艿���z���v�����
                                row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                //�艿���z���v(�ō�)
                                row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;
                                //�`�[���v(�����]��)�͋�
                                row["HADD.SALESTTLTAXINCDMD"] = DBNull.Value;
                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                //������z(���ד]�ł̂ݐō�)
                                row["HADD.SALESTTLTAXLAYDTLRF"] = DBNull.Value;
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                            }
                            # endregion

                            // �h�̂̐���
                            # region [�h��]
                            // �`�[����ݒ�̓��e�ō����ւ���i���Ӑ�}�X�^�D��j
                            if ( slipWork.CSTCLM_HONORIFICTITLERF.Trim() == string.Empty ) row["CSTCLM.HONORIFICTITLERF"] = slipPrtSet.HonorificTitle;
                            if ( slipWork.CSTCST_HONORIFICTITLERF.Trim() == string.Empty ) row["CSTCST.HONORIFICTITLERF"] = slipPrtSet.HonorificTitle;
                            if ( slipWork.CSTADR_HONORIFICTITLERF.Trim() == string.Empty ) row["CSTADR.HONORIFICTITLERF"] = slipPrtSet.HonorificTitle;
                            // ����f�[�^�̌h�͎̂g�킸�A���Ӑ�h�̂ŏ���������
                            row["SALESSLIPRF.HONORIFICTITLERF"] = row["CSTCST.HONORIFICTITLERF"]; // �h��
                            # endregion

                            // ������� (0:���,1:��)
                            # region [�������]
                            if ( slipPrtSet.TimePrintDivCd != 0 )
                            {
                                // ��
                                row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF;
                                row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF;
                                row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF;
                            }
                            else
                            {
                                // ���
                                row["HADD.PRINTTIMEHOURRF"] = DBNull.Value;
                                row["HADD.PRINTTIMEMINUTERF"] = DBNull.Value;
                                row["HADD.PRINTTIMESECONDRF"] = DBNull.Value;
                            }
                            # endregion

                            // ���t���ړW�J
                            # region [���t����]
                            // �ʏ�
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SEARCHSLIPDATERF, "HADD.SEARCHSLIPDATE", false ); // yyyymmdd
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SHIPMENTDAYRF, "HADD.SHIPMENTDAY", false );// yyyymmdd
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESDATERF, "HADD.SALESDATE", false );// yyyymmdd
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_ADDUPADATERF, "HADD.ADDUPADATE", false );// yyyymmdd
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF, "HADD.SALESSLIPPRINTDATE", false );// yyyymmdd
                            // �N��
                            ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_FIRSTENTRYDATERF, "HADD.FIRSTENTRYDATE", true );// yyyymm
                            # endregion

                            // ����p���Ӑ於��
                            # region [����p���Ӑ於��]
                            // 0:���|�Ȃ�,1:���|
                            if ( slipWork.SALESSLIPRF_ACCRECDIVCDRF != 0 )
                            {
                                //-----------------------------------------------------------
                                // ���|
                                //-----------------------------------------------------------
                                if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF != null && slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                                {
                                    // ��i�F���̂P
                                    row["HADD.PRINTCUSTOMERNAME1RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF;
                                    // ���i�F���̂Q
                                    row["HADD.PRINTCUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF;
                                    // ���i�F���̂Q�{�X�y�[�X�{�h��
                                    row["HADD.PRINTCUSTOMERNAME2HNRF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF + "�@" + (string)row["CSTCST.HONORIFICTITLERF"];
                                }
                                else
                                {
                                    // ��i�F��
                                    row["HADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value;
                                    // ���i�F���̂P
                                    row["HADD.PRINTCUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF;
                                    // ���i�F���̂P�{�X�y�[�X�{�h��
                                    row["HADD.PRINTCUSTOMERNAME2HNRF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF + "�@" + (string)row["CSTCST.HONORIFICTITLERF"];
                                }

                                // ���̂P�{���̂Q
                                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF + slipWork.SALESSLIPRF_CUSTOMERNAME2RF;
                                // --- ADD  ���r��  2010/03/19 ---------->>>>>
                                //���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                row["CSTCST.PRINTCUSTOMERNAMEJOIN12CSTRF"] = slipWork.CSTCST_NAMERF + slipWork.CSTCST_NAME2RF;
                                // --- ADD  ���r��  2010/03/19 ----------<<<<<

                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                //���Ӑ於(���Ӑ�}�X�^�Q��)
                                row["CSTCST.CUSTOMERNAMECSTRF"] = slipWork.CSTCST_NAMERF;
                                //���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                row["CSTCST.CUSTOMERNAME2CSTRF"] = slipWork.CSTCST_NAME2RF;
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<

                                // --- UPD  ���r��  2009/11/17 ---------->>>>>
                                // ���Ӑ於�̂P�{���Ӑ於�̂Q��20���܂Ŏ擾
                                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                                printCustomerNameJoin12 = printCustomerNameJoin12.PadRight(20, ' ');
                                printCustomerNameJoin12 = printCustomerNameJoin12.Substring(0, 20).TrimEnd();

                                // ���̂P�{���̂Q�{�󔒁{�h��
                                //row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] + "�@" + (string)row["CSTCST.HONORIFICTITLERF"];
                                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + "�@" + (string)row["CSTCST.HONORIFICTITLERF"];
                                // --- UPD  ���r��  2009/11/17 ----------<<<<<

                                // --- ADD  ���r��  2010/06/29 ---------->>>>>
                                //���Ӑ於�Q�{�󔒁{�h��(10���܂Ŏ擾)
                                string customerName2Hn = (string)row["SALESSLIPRF.CUSTOMERNAME2RF"];
                                customerName2Hn = customerName2Hn.PadRight(10, ' ');
                                customerName2Hn = customerName2Hn.Substring(0, 10).TrimEnd();
                                row["SALESSLIPRF.CUSTOMERNAME2HNRF"] = customerName2Hn + "  " + (string)row["CSTCST.HONORIFICTITLERF"];//���Ӑ於�́{�h��
                                

                                if (ReportItemDic.ContainsKey("SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF") || ReportItemDic.ContainsKey("SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF")
                                    || ReportItemDic.ContainsKey("SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF"))
                                {
                                    //���Ӑ於�P��20byte�擾
                                    string printCstName1 = (string)row["SALESSLIPRF.CUSTOMERNAMERF"];
                                    printCstName1 = SubStringOfByte(printCstName1, 20);
                                    //printCstName1 = printCstName1.PadRight(10 ,' ');
                                    //���Ӑ於�Q��20byte�擾
                                    string printCstName2 = (string)row["SALESSLIPRF.CUSTOMERNAME2RF"];
                                    //printCstName2 = SubStringOfByte(printCstName2, 20);
                                    //�h�̂��Sbyte�擾
                                    string honorificTitle = (string)row["CSTCST.HONORIFICTITLERF"];
                                    honorificTitle = SubStringOfByte(honorificTitle, 4);

                                    //���Ӑ於�P�{���Ӑ於�Q�{�h��(��)
                                    if (!string.IsNullOrEmpty(slipWork.SALESSLIPRF_CUSTOMERNAME2RF))
                                    {
                                            row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF"] = SubStringOfByte(printCstName1 + printCstName2, slipPrintParameterofCount.MinCount1ofCstNameJoin - 6).TrimEnd() + "  " + honorificTitle;
                                            row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF"] = SubStringOfByte(printCstName1 + printCstName2, slipPrintParameterofCount.MinCount2ofCstNameJoin - 6).TrimEnd() + "  " + honorificTitle;
                                            row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF"] = SubStringOfByte(printCstName1 + printCstName2, slipPrintParameterofCount.MinCount3ofCstNameJoin - 6).TrimEnd() + "  " + honorificTitle;
                                    }
                                    else
                                    {
                                        //���Ӑ於�P�݂̂̎�
                                        row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF"] = printCstName1.TrimEnd() + "  " + honorificTitle;
                                        row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF"] = printCstName1.TrimEnd() + "  " + honorificTitle;
                                        row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF"] = printCstName1.TrimEnd() + "  " + honorificTitle;
                                    }
                                }
                                // --- ADD  ���r��  2010/06/29 ----------<<<<<

                                
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/07/02 ADD
                                // ���Ӑ於(����f�[�^�̓��e�œ��ꂷ��)
                                row["CSTCST.NAMERF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF;
                                row["CSTCST.NAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF;
                                row["CSTCST.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/07/02 ADD
                            }
                            else
                            {
                                //-----------------------------------------------------------
                                // ��������
                                //-----------------------------------------------------------

                                // ���̂P���`�[��̗��̃Z�b�g
                                row["SALESSLIPRF.CUSTOMERNAMERF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                row["CSTCST.NAMERF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;

                                // ���̂Q����
                                row["SALESSLIPRF.CUSTOMERNAME2RF"] = DBNull.Value;
                                row["CSTCST.NAME2RF"] = DBNull.Value;

                                // ���́��`�[��̗��̃Z�b�g
                                row["CSTCST.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;

                                // �Ł���
                                row["CSTCST.KANARF"] = DBNull.Value;

                                // ��i�F��
                                row["HADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value;
                                // ���i�F����
                                row["HADD.PRINTCUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                // ���i�F���́{�X�y�[�X�{�h��
                                row["HADD.PRINTCUSTOMERNAME2HNRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF + "�@" + (string)row["CSTCST.HONORIFICTITLERF"];

                                // (���̂P�{���̂Q)�i�����̃Z�b�g�j
                                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;

                                // --- ADD  ���r��  2010/03/19 ---------->>>>>
                                // ���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                row["CSTCST.PRINTCUSTOMERNAMEJOIN12CSTRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                // --- ADD  ���r��  2010/03/19 ----------<<<<<

                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                //���Ӑ於(���Ӑ�}�X�^�Q��)
                                row["CSTCST.CUSTOMERNAMECSTRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                //���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                row["CSTCST.CUSTOMERNAME2CSTRF"] = DBNull.Value;
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                                
                                // (���̂P�{���̂Q)�i�����̃Z�b�g�j�{�󔒁{�h��
                                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF + "�@" + (string)row["CSTCST.HONORIFICTITLERF"];

                                // --- ADD  ���r��  2010/06/29 ---------->>>>>
                                //���Ӑ於�Q�{�󔒁{�h�́����Ӑ於�Q�͂Ȃ��̂Ōh�̂̂݃Z�b�g
                                row["SALESSLIPRF.CUSTOMERNAME2HNRF"] = (string)row["CSTCST.HONORIFICTITLERF"];//�h��

                                //���̂�10byte�擾
                                string CstName1 = (string)row["SALESSLIPRF.CUSTOMERNAMERF"];
                                CstName1 = SubStringOfByte(CstName1, 20).TrimEnd();
                                //�h�̂��Sbyte�擾
                                string honorificTitle = (string)row["CSTCST.HONORIFICTITLERF"];
                                honorificTitle = SubStringOfByte(honorificTitle, 4);

                                //���Ӑ於�P�{���Ӑ於�Q�{�h��(��)
                                row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF"] = CstName1 + "  " + honorificTitle;
                                row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF"] = CstName1 + "  " + honorificTitle;
                                row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF"] = CstName1 + "  " + honorificTitle;
                                // --- ADD  ���r��  2010/06/29 ----------<<<<<     
                            }
                            # endregion

                            // �ޕʌ^���n�C�t��
                            # region [�ޕʌ^���n�C�t��]
                            if ( slipWork.HADD_CATEGORYNORF == 0 && slipWork.HADD_MODELDESIGNATIONNORF == 0 )
                            {
                                row[ct_HCategoryHyp] = DBNull.Value;
                            }
                            else
                            {
                                row[ct_HCategoryHyp] = "-";
                            }
                            # endregion

                            // --- ADD  ���r��  2010/03/01 ---------->>>>>                            
                            #region [�W�����i���z����]

# if false
                            Int64 listPriceTotal = 0;
                            Int64 listPriceTaxTotal = 0;
                            for (int i = detailWorks.Count; i >= 0; i++)
                            {
                                //�艿���z���v(�Ŕ�)
                                listPriceTotal += _listPrice;
                                row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = listPriceTotal;

                                //�艿���z���v�����                            
                                switch (consTaxLayMethod)
                                {
                                    //���ד]��
                                    case 1:
                                        {
                                            //���ז��̏���ł������č��v����ł��o��
                                            listPriceTaxTotal += _listPriceTax;
                                            row["HADD.LISTPRICEMONEYTOTALTAXRF"] = listPriceTaxTotal;
                                        }
                                        break;
                                    //�`�[�]�ŁA�����]�Őe�A�����]�Ŏq
                                    case 0:
                                    case 2:
                                    case 3:
                                        {
                                            //�艿���z�̍��v����v�Z���A���v����ł��o��
                                            listPriceTaxTotal = stc_priceTaxCalculator.GetTax(listPriceTotal, slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF, slipWork.SalesMoneyFrcProcCd);
                                            row["HADD.LISTPRICEMONEYTOTALTAXRF"] = listPriceTaxTotal;
                                        }
                                        break;
                                    //��ې�
                                    case 9:
                                        {
                                            //����ł̈󎚖���
                                            row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;
                                        }
                                        break;
                                }

                                //�艿���z���v�����(�ō�)
                                switch (consTaxLayMethod)
                                {
                                    //���ד]��
                                    case 1:
                                        {
                                        }
                                        break;
                                    //�`�[�]�ŁA�����]�Őe�A�����]�Ŏq
                                    case 0:
                                    case 2:
                                    case 3:
                                        {
                                        }
                                    //��ې�
                                    case 9:
                                }

                            }
# endif
                            #endregion
                            // --- ADD  ���r��  2010/03/01 ----------<<<<<

                            // ���p�����ڑΉ�
                            # region [���p�����ڑΉ�]
                            // ���u�c���p���v���ڂ��󔒂̏ꍇ�u�c�S�p���v�̓��e���Z�b�g����i�Ԏ햼������͂����ꍇ�Ȃǁj
                            if ( string.IsNullOrEmpty( slipWork.HADD_MAKERHALFNAMERF ) )
                            {
                                row["HADD.MAKERHALFNAMERF"] = slipWork.HADD_MAKERFULLNAMERF; // (�擪)���[�J�[���p���́��S�p���Z�b�g
                            }
                            if ( string.IsNullOrEmpty( slipWork.HADD_MODELHALFNAMERF ) )
                            {
                                // --- UPD  ���r��  2010/06/24 ---------->>>>>
                                //row["HADD.MODELHALFNAMERF"] = slipWork.HADD_MODELFULLNAMERF; // (�擪)�Ԏ피�p���́��S�p���Z�b�g
                                row["HADD.MODELHALFNAMERF"] = GetKanaString(slipWork.HADD_MODELFULLNAMERF);
                                // --- UPD  ���r��  2010/06/24 ----------<<<<<
                            }
                            # endregion

                            // ���}�[�N�P�E�Q
                            # region [���}�[�N�P�E�Q]
                            if ( !String.IsNullOrEmpty( slipWork.SALESSLIPRF_UOEREMARK1RF ) || !String.IsNullOrEmpty( slipWork.SALESSLIPRF_UOEREMARK2RF ) )
                            {
                                row["SALESSLIPRF.UOEREMARK1RF"] = "C." + slipWork.SALESSLIPRF_UOEREMARK1RF; // �t�n�d���}�[�N�P
                                row["SALESSLIPRF.UOEREMARK2RF"] = slipWork.SALESSLIPRF_UOEREMARK2RF; // �t�n�d���}�[�N�Q
                            }
                            else
                            {
                                row["SALESSLIPRF.UOEREMARK1RF"] = DBNull.Value; // �t�n�d���}�[�N�P
                                row["SALESSLIPRF.UOEREMARK2RF"] = DBNull.Value; // �t�n�d���}�[�N�Q
                            }
                            # endregion

                            // �c�{�p�Ή�
                            # region [�c�{�p�Ή�]
                            // ������ȑO�̏�����row�ɃZ�b�g�������e���g�p���܂��B

                            // �����T�C�Y (0:�W��,1:��)
                            if ( slipPrtSet.SlipFontSize == 0 )
                            {
                                // �W��
                                row["HLG.CUSTOMERNAMERF"] = DBNull.Value;  // �y�c�{�z���Ӑ於��
                                row["HLG.CUSTOMERNAME2RF"] = DBNull.Value;  //�y�c�{�z ���Ӑ於��2
                                row["HLG.CUSTOMERSNMRF"] = DBNull.Value;  // �y�c�{�z���Ӑ旪��
                                row["HLG.HONORIFICTITLERF"] = DBNull.Value;  // �y�c�{�z�h��
                                row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q
                                row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value; // �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.03 ADD
                                row["HLG.PRINTCUSTOMERNAME1RF"] = DBNull.Value; // �i�c�{�j����p���Ӑ於�́i��i�j
                                row["HLG.PRINTCUSTOMERNAME2RF"] = DBNull.Value; // �i�c�{�j����p���Ӑ於�́i���i�j
                                row["HLG.PRINTCUSTOMERNAME2HNRF"] = DBNull.Value; // �i�c�{�j����p���Ӑ於�́i���i�j�{�h��
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.03 ADD
                                // --- ADD  ���r��  2010/03/19 ---------->>>>>
                                row["HLG.PRINTCUSTOMERNAMEJOIN12CSTRF"] = DBNull.Value; //  (�c�{) ���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                // --- ADD  ���r��  2010/03/19 ----------<<<<<
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                row["HLG.CUSTOMERNAMECSTRF"] = DBNull.Value; // �y�c�{�z���Ӑ於�P(���Ӑ�}�X�^�Q��)
                                row["HLG.CUSTOMERNAME2CSTRF"] = DBNull.Value; // �y�c�{�z���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                                // --- ADD  ���r��  2010/06/29 ---------->>>>>
                                row["HLG.CUSTOMERNAME2HNRF"] = DBNull.Value; // �y�c�{�z���Ӑ於�Q�{�h��
                                row["HLG.PRINTCSTNAMEJOIN12HN1RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
                                row["HLG.PRINTCSTNAMEJOIN12HN2RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
                                row["HLG.PRINTCSTNAMEJOIN12HN3RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
                                // --- ADD  ���r��  2010/06/29 ----------<<<<<
                            }
                            else
                            {
                                // �c�{�p
                                row["HLG.CUSTOMERNAMERF"] = row["SALESSLIPRF.CUSTOMERNAMERF"];  // �y�c�{�z���Ӑ於��
                                row["HLG.CUSTOMERNAME2RF"] = row["SALESSLIPRF.CUSTOMERNAME2RF"];  //�y�c�{�z ���Ӑ於��2
                                row["HLG.CUSTOMERSNMRF"] = row["SALESSLIPRF.CUSTOMERSNMRF"];  // �y�c�{�z���Ӑ旪��
                                row["HLG.HONORIFICTITLERF"] = row["SALESSLIPRF.HONORIFICTITLERF"];  // �y�c�{�z�h��
                                row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q
                                row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"]; // �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.03 ADD
                                row["HLG.PRINTCUSTOMERNAME1RF"] = row["HADD.PRINTCUSTOMERNAME1RF"]; // �i�c�{�j����p���Ӑ於�́i��i�j
                                row["HLG.PRINTCUSTOMERNAME2RF"] = row["HADD.PRINTCUSTOMERNAME2RF"]; // �i�c�{�j����p���Ӑ於�́i���i�j
                                row["HLG.PRINTCUSTOMERNAME2HNRF"] = row["HADD.PRINTCUSTOMERNAME2HNRF"]; // �i�c�{�j����p���Ӑ於�́i���i�j�{�h��
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.03 ADD
                                // --- ADD  ���r��  2010/03/19 ---------->>>>>
                                row["HLG.PRINTCUSTOMERNAMEJOIN12CSTRF"] = row["CSTCST.PRINTCUSTOMERNAMEJOIN12CSTRF"]; //  (�c�{) ���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                // --- ADD  ���r��  2010/03/19 ----------<<<<<
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                row["HLG.CUSTOMERNAMECSTRF"] = row["CSTCST.CUSTOMERNAMECSTRF"]; // �y�c�{�z���Ӑ於�P(���Ӑ�}�X�^�Q��)
                                row["HLG.CUSTOMERNAME2CSTRF"] = row["CSTCST.CUSTOMERNAME2CSTRF"]; // �y�c�{�z���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                                // --- ADD  ���r��  2010/06/29 ---------->>>>>
                                row["HLG.CUSTOMERNAME2HNRF"] = row["SALESSLIPRF.CUSTOMERNAME2HNRF"]; // �y�c�{�z���Ӑ於�Q�{�h��
                                row["HLG.PRINTCSTNAMEJOIN12HN1RF"] = row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF"]; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
                                row["HLG.PRINTCSTNAMEJOIN12HN2RF"] = row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF"]; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
                                row["HLG.PRINTCSTNAMEJOIN12HN3RF"] = row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF"]; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
                                // --- ADD  ���r��  2010/06/29 ----------<<<<<


                                row["SALESSLIPRF.CUSTOMERNAMERF"] = DBNull.Value;  // ���Ӑ於��
                                row["SALESSLIPRF.CUSTOMERNAME2RF"] = DBNull.Value;  //���Ӑ於��2
                                row["SALESSLIPRF.CUSTOMERSNMRF"] = DBNull.Value;  // ���Ӑ旪��
                                row["SALESSLIPRF.HONORIFICTITLERF"] = DBNull.Value;  // �h��
                                row["CSTCST.HONORIFICTITLERF"] = DBNull.Value;  // �h��
                                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value; //���Ӑ於�P�{���Ӑ於�Q
                                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value; // ���Ӑ於�P�{���Ӑ於�Q�{�h��
                                row["CSTCST.NAMERF"] = DBNull.Value;  // ���Ӑ於��
                                row["CSTCST.NAME2RF"] = DBNull.Value;  // ���Ӑ於��2
                                row["CSTCST.HONORIFICTITLERF"] = DBNull.Value;  // ���Ӑ�h��
                                row["CSTCST.CUSTOMERSNMRF"] = DBNull.Value;  // ���Ӑ旪��
                                row["CSTCST.HONORIFICTITLERF"] = DBNull.Value;  // �h��
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.03 ADD
                                row["HADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value; // ����p���Ӑ於�́i��i�j
                                row["HADD.PRINTCUSTOMERNAME2RF"] = DBNull.Value; // ����p���Ӑ於�́i���i�j
                                row["HADD.PRINTCUSTOMERNAME2HNRF"] = DBNull.Value; // ����p���Ӑ於�́i���i�j�{�h��
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.03 ADD
                                // --- ADD  ���r��  2010/03/19 ---------->>>>>
                                row["CSTCST.PRINTCUSTOMERNAMEJOIN12CSTRF"] = DBNull.Value; // ���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                // --- ADD  ���r��  2010/03/19 ----------<<<<<
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                row["CSTCST.CUSTOMERNAMECSTRF"] = DBNull.Value; //���Ӑ於�P(���Ӑ�}�X�^�Q��)
                                row["CSTCST.CUSTOMERNAME2CSTRF"] = DBNull.Value; //���Ӑ於�Q(���Ӑ�}�X�^�Q��)
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                                // --- ADD  ���r��  2010/06/29 ---------->>>>>
                                row["SALESSLIPRF.CUSTOMERNAME2HNRF"] = DBNull.Value; //���Ӑ於�Q�{�h��
                                row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN1RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
                                row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN2RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
                                row["SALESSLIPRF.PRINTCSTNAMEJOIN12HN3RF"] = DBNull.Value; //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
                                // --- ADD  ���r��  2010/06/29 ----------<<<<<

                            }
                            
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/07/02 ADD
                            // ���Ж��c�{�p(�󎚐���Ȃ��Ȃ̂ŁA��ɃR�s�[)
                            row["HLG.COMPANYNAME1RF"] = row["COMPANYNMRF.COMPANYNAME1RF"];
                            row["HLG.COMPANYNAME2RF"] = row["COMPANYNMRF.COMPANYNAME2RF"];
                            row["HLG.PRINTENTERPRISENAME1FHRF"] = row["HADD.PRINTENTERPRISENAME1FHRF"];
                            row["HLG.PRINTENTERPRISENAME1LHRF"] = row["HADD.PRINTENTERPRISENAME1LHRF"];
                            row["HLG.PRINTENTERPRISENAME2FHRF"] = row["HADD.PRINTENTERPRISENAME2FHRF"];
                            row["HLG.PRINTENTERPRISENAME2LHRF"] = row["HADD.PRINTENTERPRISENAME2LHRF"];
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/07/02 ADD
                            // --- UPD  2011/02/16 ---------->>>>>
                            //���Ж���(0:�W��,1:��)
                            if (slipPrtSet.EntNmPrtExpDiv == 0)
                            {
                                // �W��
                                SettingKmk(row, columnVisibleTypeDic, "COMPANYNMRF.COMPANYNAME1RF", "HLG.COMPANYNAME1RF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME1FHRF", "HLG.PRINTENTERPRISENAME1FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME1LHRF", "HLG.PRINTENTERPRISENAME1LHRF");
                                
                                SettingKmk(row, columnVisibleTypeDic, "COMPANYNMRF.COMPANYNAME2RF", "HLG.COMPANYNAME2RF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME2FHRF", "HLG.PRINTENTERPRISENAME2FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME2LHRF", "HLG.PRINTENTERPRISENAME2LHRF");
                            }
                            else
                            {
                                // ��
                                SettingKmk(row, columnVisibleTypeDic, "HLG.COMPANYNAME1RF", "COMPANYNMRF.COMPANYNAME1RF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME1FHRF", "HADD.PRINTENTERPRISENAME1FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME1LHRF", "HADD.PRINTENTERPRISENAME1LHRF");

                                SettingKmk(row, columnVisibleTypeDic, "HLG.COMPANYNAME2RF", "COMPANYNMRF.COMPANYNAME2RF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME2FHRF", "HADD.PRINTENTERPRISENAME2FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME2LHRF", "HADD.PRINTENTERPRISENAME2LHRF");
                            }
                            // --- UPD  2011/02/16 ----------<<<<<
                            // --- ADD  ���r��  2010/06/03 ---------->>>>>
                            // ���Ӑ���l�c�{�p(�󎚐���Ȃ��Ȃ̂ŁA��ɃR�s�[)
                            row["HLG.CUSTNOTE1RF"] = row["CSTCST.NOTE1RF"];
                            // --- ADD  ���r��  2010/06/03 ----------<<<<<

                            # endregion

                            // �p�q�R�[�h
                            # region [�p�q�R�[�h]
                            // --- UPD m.suzuki 2010/03/24 ---------->>>>>
                            //row[ct_QRCode] = qrData;

                            // ��i(inPageCopyCount=0)�݈̂������
                            if ( inPageCopyCount == 0 )
                            {
                                row[ct_QRCode] = qrData;
                                row[ct_QRCodeSource] = qrDataSource;
                            }
                            else
                            {
                                row[ct_QRCode] = string.Empty;
                                row[ct_QRCodeSource] = string.Empty;
                            }
                            // --- UPD m.suzuki 2010/03/24 ----------<<<<<
                            # endregion

                            // --- ADD  ���r��  2010/06/29 ---------->>>>> 
                            #region[�`�[���l(��i�E���i)]
                            // --- UPD  ���r��  2010/07/09 ---------->>>>>
                            if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTEUPPERRF") || ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTELOWERRF"))
                            {
                                //11�����ȏ�͓`�[���l�i���i�j�Ɉ󎚂���
                                string slipNote = (string)row["SALESSLIPRF.SLIPNOTERF"];

                                //slipNote = slipNote.PadRight(40, ' ');
                                Encoding encoding = Encoding.GetEncoding("Shift_JIS");
                                int count = encoding.GetByteCount(slipNote);

                                string slipNoteupper = SubStringOfByte(slipNote, 20);
                                string slipNotelower = string.Empty;

                                if (count >= 21)
                                {
                                    //string slipNotelower = slipNote.Substring(10);
                                    if (!string.IsNullOrEmpty(slipWork.SALESSLIPRF_SLIPNOTERF))
                                    {
                                        slipNotelower = slipNote.Substring(slipNoteupper.Length, slipNote.Length - slipNoteupper.Length);
                                    }

                                    //row["SALESSLIPRF.SLIPNOTEUPPERRF"] = slipWork.SALESSLIPRF_SLIPNOTERF;
                                    row["SALESSLIPRF.SLIPNOTEUPPERRF"] = slipNoteupper;
                                    row["SALESSLIPRF.SLIPNOTELOWERRF"] = slipNotelower;
                                }
                                else
                                {
                                    row["SALESSLIPRF.SLIPNOTEUPPERRF"] = DBNull.Value;
                                    //row["SALESSLIPRF.SLIPNOTELOWERRF"] = slipWork.SALESSLIPRF_SLIPNOTERF;
                                    row["SALESSLIPRF.SLIPNOTELOWERRF"] = slipNoteupper;
                                }
                            }
                            // --- UPD  ���r��  2010/07/09 ----------<<<<<
                            #endregion
                            // --- ADD  ���r��  2010/06/29 ----------<<<<<

                            # endregion

                            # region [�`�[����(�`�[�^�C�v�ʐݒ�)]
                            // �S����
                            if ( eachSlipTypeSet.SalesEmployee == 0 )
                            {
                                row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // �̔��]�ƈ��R�[�h
                                row["SALESSLIPRF.SALESEMPLOYEENMRF"] = DBNull.Value; // �̔��]�ƈ�����
                                row["EMPSAL.KANARF"] = DBNull.Value; // �̔��]�ƈ��J�i
                                row["EMPSAL.SHORTNAMERF"] = DBNull.Value; // �̔��]�ƈ��Z�k����
                            }
                            // �󒍎�
                            if ( eachSlipTypeSet.FrontEmployee == 0 )
                            {
                                row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // ��t�]�ƈ��R�[�h
                                row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = DBNull.Value; // ��t�]�ƈ�����
                                row["EMPFRT.KANARF"] = DBNull.Value; // ��t�]�ƈ��J�i
                                row["EMPFRT.SHORTNAMERF"] = DBNull.Value; // ��t�]�ƈ��Z�k����
                            }
                            // ���s��
                            if ( eachSlipTypeSet.SalesInput == 0 )
                            {
                                row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // ������͎҃R�[�h
                                row["SALESSLIPRF.SALESINPUTNAMERF"] = DBNull.Value; // ������͎Җ���
                                row["EMPINP.KANARF"] = DBNull.Value; // ������͎҃J�i
                                row["EMPINP.SHORTNAMERF"] = DBNull.Value; // ������͎ҒZ�k����
                            }
                            // ����
                            if ( eachSlipTypeSet.SalesPrice == 0 )
                            {
                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                //row["SALESSLIPRF.SALSEOUTTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.05 ADD
                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                row["HADD.SALESTOTALTAXEXCA700RF"] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.05 ADD
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                row["HADD.SALESTTLTAXLAYDTLRF"] = DBNull.Value;//�`�[���v(���ד]�ł̂ݐō�)
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                            }
                            # endregion
                        }

                        if ( index <= printEndIndex && index < detailWorks.Count )
                        {
                            //-------------------------------------------
                            // ������
                            //-------------------------------------------

                            # region [���׍���Copy]
                            row["SALESDETAILRF.ACPTANODRSTATUSRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRSTATUSRF; // �󒍃X�e�[�^�X
                            row["SALESDETAILRF.SALESSLIPNUMRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPNUMRF; // ����`�[�ԍ�
                            row["SALESDETAILRF.ACCEPTANORDERNORF"] = detailWorks[index].SALESDETAILRF_ACCEPTANORDERNORF; // �󒍔ԍ�
                            row["SALESDETAILRF.SALESROWNORF"] = detailWorks[index].SALESDETAILRF_SALESROWNORF; // ����s�ԍ�
                            row["SALESDETAILRF.SALESDATERF"] = detailWorks[index].SALESDETAILRF_SALESDATERF; // ������t
                            row["SALESDETAILRF.COMMONSEQNORF"] = detailWorks[index].SALESDETAILRF_COMMONSEQNORF; // ���ʒʔ�
                            row["SALESDETAILRF.SALESSLIPDTLNUMRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPDTLNUMRF; // ���㖾�גʔ�
                            row["SALESDETAILRF.ACPTANODRSTATUSSRCRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRSTATUSSRCRF; // �󒍃X�e�[�^�X�i���j
                            row["SALESDETAILRF.SALESSLIPDTLNUMSRCRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPDTLNUMSRCRF; // ���㖾�גʔԁi���j
                            row["SALESDETAILRF.SUPPLIERFORMALSYNCRF"] = detailWorks[index].SALESDETAILRF_SUPPLIERFORMALSYNCRF; // �d���`���i�����j
                            row["SALESDETAILRF.STOCKSLIPDTLNUMSYNCRF"] = detailWorks[index].SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF; // �d�����גʔԁi�����j
                            row["SALESDETAILRF.SALESSLIPCDDTLRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPCDDTLRF; // ����`�[�敪�i���ׁj
                            row["SALESDETAILRF.STOCKMNGEXISTCDRF"] = detailWorks[index].SALESDETAILRF_STOCKMNGEXISTCDRF; // �݌ɊǗ��L���敪
                            row["SALESDETAILRF.DELIGDSCMPLTDUEDATERF"] = detailWorks[index].SALESDETAILRF_DELIGDSCMPLTDUEDATERF; // �[�i�����\���
                            row["SALESDETAILRF.GOODSKINDCODERF"] = detailWorks[index].SALESDETAILRF_GOODSKINDCODERF; // ���i����
                            row["SALESDETAILRF.GOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF; // ���i���[�J�[�R�[�h
                            row["SALESDETAILRF.MAKERNAMERF"] = detailWorks[index].SALESDETAILRF_MAKERNAMERF; // ���[�J�[����
                            row["SALESDETAILRF.GOODSNORF"] = detailWorks[index].SALESDETAILRF_GOODSNORF; // ���i�ԍ�
                            row["SALESDETAILRF.GOODSNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSNAMERF; // ���i����
                            row["SALESDETAILRF.GOODSSHORTNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSSHORTNAMERF; // ���i������
                            //row["SALESDETAILRF.LARGEGOODSGANRECODERF"] = detailWorks[index].SALESDETAILRF_LARGEGOODSGANRECODERF; // ���i�敪�O���[�v�R�[�h
                            //row["SALESDETAILRF.LARGEGOODSGANRENAMERF"] = detailWorks[index].SALESDETAILRF_LARGEGOODSGANRENAMERF; // ���i�敪�O���[�v����
                            //row["SALESDETAILRF.MEDIUMGOODSGANRECODERF"] = detailWorks[index].SALESDETAILRF_MEDIUMGOODSGANRECODERF; // ���i�敪�R�[�h
                            //row["SALESDETAILRF.MEDIUMGOODSGANRENAMERF"] = detailWorks[index].SALESDETAILRF_MEDIUMGOODSGANRENAMERF; // ���i�敪����
                            //row["SALESDETAILRF.DETAILGOODSGANRECODERF"] = detailWorks[index].SALESDETAILRF_DETAILGOODSGANRECODERF; // ���i�敪�ڍ׃R�[�h
                            //row["SALESDETAILRF.DETAILGOODSGANRENAMERF"] = detailWorks[index].SALESDETAILRF_DETAILGOODSGANRENAMERF; // ���i�敪�ڍז���
                            row["SALESDETAILRF.BLGOODSCODERF"] = detailWorks[index].SALESDETAILRF_BLGOODSCODERF; // BL���i�R�[�h
                            row["SALESDETAILRF.BLGOODSFULLNAMERF"] = detailWorks[index].SALESDETAILRF_BLGOODSFULLNAMERF; // BL���i�R�[�h���́i�S�p�j
                            row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = detailWorks[index].SALESDETAILRF_ENTERPRISEGANRECODERF; // ���Е��ރR�[�h
                            row["SALESDETAILRF.ENTERPRISEGANRENAMERF"] = detailWorks[index].SALESDETAILRF_ENTERPRISEGANRENAMERF; // ���Е��ޖ���
                            row["SALESDETAILRF.WAREHOUSECODERF"] = detailWorks[index].SALESDETAILRF_WAREHOUSECODERF; // �q�ɃR�[�h
                            row["SALESDETAILRF.WAREHOUSENAMERF"] = detailWorks[index].SALESDETAILRF_WAREHOUSENAMERF; // �q�ɖ���
                            row["SALESDETAILRF.WAREHOUSESHELFNORF"] = detailWorks[index].SALESDETAILRF_WAREHOUSESHELFNORF; // �q�ɒI��
                            row["SALESDETAILRF.SALESORDERDIVCDRF"] = detailWorks[index].SALESDETAILRF_SALESORDERDIVCDRF; // ����݌Ɏ�񂹋敪
                            row["SALESDETAILRF.OPENPRICEDIVRF"] = detailWorks[index].SALESDETAILRF_OPENPRICEDIVRF; // �I�[�v�����i�敪
                            //row["SALESDETAILRF.UNITCODERF"] = detailWorks[index].SALESDETAILRF_UNITCODERF; // �P�ʃR�[�h
                            //row["SALESDETAILRF.UNITNAMERF"] = detailWorks[index].SALESDETAILRF_UNITNAMERF; // �P�ʖ���
                            row["SALESDETAILRF.GOODSRATERANKRF"] = detailWorks[index].SALESDETAILRF_GOODSRATERANKRF; // ���i�|�������N
                            row["SALESDETAILRF.CUSTRATEGRPCODERF"] = detailWorks[index].SALESDETAILRF_CUSTRATEGRPCODERF; // ���Ӑ�|���O���[�v�R�[�h
                            //row["SALESDETAILRF.SUPPRATEGRPCODERF"] = detailWorks[index].SALESDETAILRF_SUPPRATEGRPCODERF; // �d����|���O���[�v�R�[�h
                            row["SALESDETAILRF.LISTPRICERATERF"] = detailWorks[index].SALESDETAILRF_LISTPRICERATERF; // �艿��
                            row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXINCFLRF; // �艿�i�ō��C�����j
                            row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF; // �艿�i�Ŕ��C�����j
                            row["SALESDETAILRF.LISTPRICECHNGCDRF"] = detailWorks[index].SALESDETAILRF_LISTPRICECHNGCDRF; // �艿�ύX�敪
                            row["SALESDETAILRF.SALESRATERF"] = detailWorks[index].SALESDETAILRF_SALESRATERF; // ������
                            row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXINCFLRF; // ����P���i�ō��C�����j
                            row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXEXCFLRF; // ����P���i�Ŕ��C�����j
                            row["SALESDETAILRF.COSTRATERF"] = detailWorks[index].SALESDETAILRF_COSTRATERF; // ������
                            row["SALESDETAILRF.SALESUNITCOSTRF"] = detailWorks[index].SALESDETAILRF_SALESUNITCOSTRF; // �����P��
                            row["SALESDETAILRF.SHIPMENTCNTRF"] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF; // �o�א�
                            row["SALESDETAILRF.ACCEPTANORDERCNTRF"] = detailWorks[index].SALESDETAILRF_ACCEPTANORDERCNTRF; // �󒍐���
                            row["SALESDETAILRF.ACPTANODRADJUSTCNTRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRADJUSTCNTRF; // �󒍒�����
                            row["SALESDETAILRF.ACPTANODRREMAINCNTRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRREMAINCNTRF; // �󒍎c��
                            row["SALESDETAILRF.REMAINCNTUPDDATERF"] = detailWorks[index].SALESDETAILRF_REMAINCNTUPDDATERF; // �c���X�V��
                            row["SALESDETAILRF.SALESMONEYTAXINCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXINCRF; // ������z�i�ō��݁j
                            row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF; // ������z�i�Ŕ����j
                            row["SALESDETAILRF.COSTRF"] = detailWorks[index].SALESDETAILRF_COSTRF; // ����
                            row["SALESDETAILRF.GRSPROFITCHKDIVRF"] = detailWorks[index].SALESDETAILRF_GRSPROFITCHKDIVRF; // �e���`�F�b�N�敪
                            row["SALESDETAILRF.SALESGOODSCDRF"] = detailWorks[index].SALESDETAILRF_SALESGOODSCDRF; // ���㏤�i�敪
                            //row["SALESDETAILRF.SALSEPRICECONSTAXRF"] = detailWorks[index].SALESDETAILRF_SALSEPRICECONSTAXRF; // ������z����Ŋz
                            row["SALESDETAILRF.TAXATIONDIVCDRF"] = detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF; // �ېŋ敪
                            row["SALESDETAILRF.PARTYSLIPNUMDTLRF"] = detailWorks[index].SALESDETAILRF_PARTYSLIPNUMDTLRF; // �����`�[�ԍ��i���ׁj
                            row["SALESDETAILRF.DTLNOTERF"] = detailWorks[index].SALESDETAILRF_DTLNOTERF; // ���ה��l
                            row["SALESDETAILRF.SUPPLIERCDRF"] = detailWorks[index].SALESDETAILRF_SUPPLIERCDRF; // �d����R�[�h
                            row["SALESDETAILRF.SUPPLIERSNMRF"] = detailWorks[index].SALESDETAILRF_SUPPLIERSNMRF; // �d���旪��
                            row["SALESDETAILRF.ORDERNUMBERRF"] = detailWorks[index].SALESDETAILRF_ORDERNUMBERRF; // �����ԍ�
                            row["SALESDETAILRF.SLIPMEMO1RF"] = detailWorks[index].SALESDETAILRF_SLIPMEMO1RF; // �`�[�����P
                            row["SALESDETAILRF.SLIPMEMO2RF"] = detailWorks[index].SALESDETAILRF_SLIPMEMO2RF; // �`�[�����Q
                            row["SALESDETAILRF.SLIPMEMO3RF"] = detailWorks[index].SALESDETAILRF_SLIPMEMO3RF; // �`�[�����R
                            row["SALESDETAILRF.INSIDEMEMO1RF"] = detailWorks[index].SALESDETAILRF_INSIDEMEMO1RF; // �Г������P
                            row["SALESDETAILRF.INSIDEMEMO2RF"] = detailWorks[index].SALESDETAILRF_INSIDEMEMO2RF; // �Г������Q
                            row["SALESDETAILRF.INSIDEMEMO3RF"] = detailWorks[index].SALESDETAILRF_INSIDEMEMO3RF; // �Г������R
                            row["SALESDETAILRF.BFLISTPRICERF"] = detailWorks[index].SALESDETAILRF_BFLISTPRICERF; // �ύX�O�艿
                            row["SALESDETAILRF.BFSALESUNITPRICERF"] = detailWorks[index].SALESDETAILRF_BFSALESUNITPRICERF; // �ύX�O����
                            row["SALESDETAILRF.BFUNITCOSTRF"] = detailWorks[index].SALESDETAILRF_BFUNITCOSTRF; // �ύX�O����
                            //row["SALESDETAILRF.PRTGOODSNORF"] = detailWorks[index].SALESDETAILRF_PRTGOODSNORF; // ����p���i�ԍ�
                            //row["SALESDETAILRF.PRTGOODSNAMERF"] = detailWorks[index].SALESDETAILRF_PRTGOODSNAMERF; // ����p���i����
                            //row["SALESDETAILRF.PRTGOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_PRTGOODSMAKERCDRF; // ����p���i���[�J�[�R�[�h
                            //row["SALESDETAILRF.PRTGOODSMAKERNMRF"] = detailWorks[index].SALESDETAILRF_PRTGOODSMAKERNMRF; // ����p���i���[�J�[����
                            //row["SALESDETAILRF.CONTRACTDIVCDDTLRF"] = detailWorks[index].SALESDETAILRF_CONTRACTDIVCDDTLRF; // �_��敪�i���ׁj
                            row["SALESDETAILRF.CMPLTSALESROWNORF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESROWNORF; // �ꎮ���הԍ�
                            row["SALESDETAILRF.CMPLTGOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_CMPLTGOODSMAKERCDRF; // ���[�J�[�R�[�h�i�ꎮ�j
                            row["SALESDETAILRF.CMPLTMAKERNAMERF"] = detailWorks[index].SALESDETAILRF_CMPLTMAKERNAMERF; // ���[�J�[���́i�ꎮ�j
                            row["SALESDETAILRF.CMPLTGOODSNAMERF"] = detailWorks[index].SALESDETAILRF_CMPLTGOODSNAMERF; // ���i���́i�ꎮ�j
                            row["SALESDETAILRF.CMPLTSHIPMENTCNTRF"] = detailWorks[index].SALESDETAILRF_CMPLTSHIPMENTCNTRF; // ���ʁi�ꎮ�j
                            //row["SALESDETAILRF.CMPLTUNITCODERF"] = detailWorks[index].SALESDETAILRF_CMPLTUNITCODERF; // �P�ʃR�[�h�i�ꎮ�j
                            //row["SALESDETAILRF.CMPLTUNITNAMERF"] = detailWorks[index].SALESDETAILRF_CMPLTUNITNAMERF; // �P�ʖ��́i�ꎮ�j
                            row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESUNPRCFLRF; // ����P���i�ꎮ�j
                            row["SALESDETAILRF.CMPLTSALESMONEYRF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESMONEYRF; // ������z�i�ꎮ�j
                            row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESUNITCOSTRF; // �����P���i�ꎮ�j
                            row["SALESDETAILRF.CMPLTCOSTRF"] = detailWorks[index].SALESDETAILRF_CMPLTCOSTRF; // �������z�i�ꎮ�j
                            row["SALESDETAILRF.CMPLTPARTYSALSLNUMRF"] = detailWorks[index].SALESDETAILRF_CMPLTPARTYSALSLNUMRF; // �����`�[�ԍ��i�ꎮ�j
                            row["SALESDETAILRF.CMPLTNOTERF"] = detailWorks[index].SALESDETAILRF_CMPLTNOTERF; // �ꎮ���l
                            row["ACCEPTODRCARRF.CARMNGNORF"] = detailWorks[index].ACCEPTODRCARRF_CARMNGNORF; // �ԗ��Ǘ��ԍ�
                            row["ACCEPTODRCARRF.CARMNGCODERF"] = detailWorks[index].ACCEPTODRCARRF_CARMNGCODERF; // ���q�Ǘ��R�[�h
                            row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE1CODERF; // ���^�������ԍ�
                            row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE1NAMERF; // ���^�����ǖ���
                            row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE2RF; // �ԗ��o�^�ԍ��i��ʁj
                            row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE3RF; // �ԗ��o�^�ԍ��i�J�i�j
                            row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE4RF; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = detailWorks[index].ACCEPTODRCARRF_FIRSTENTRYDATERF; // ���N�x
                            row["ACCEPTODRCARRF.MAKERCODERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERCODERF; // ���[�J�[�R�[�h
                            row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERFULLNAMERF; // ���[�J�[�S�p����
                            row["ACCEPTODRCARRF.MODELCODERF"] = detailWorks[index].ACCEPTODRCARRF_MODELCODERF; // �Ԏ�R�[�h
                            row["ACCEPTODRCARRF.MODELSUBCODERF"] = detailWorks[index].ACCEPTODRCARRF_MODELSUBCODERF; // �Ԏ�T�u�R�[�h
                            row["ACCEPTODRCARRF.MODELFULLNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELFULLNAMERF; // �Ԏ�S�p����
                            row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = detailWorks[index].ACCEPTODRCARRF_EXHAUSTGASSIGNRF; // �r�K�X�L��
                            row["ACCEPTODRCARRF.SERIESMODELRF"] = detailWorks[index].ACCEPTODRCARRF_SERIESMODELRF; // �V���[�Y�^��
                            row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = detailWorks[index].ACCEPTODRCARRF_CATEGORYSIGNMODELRF; // �^���i�ޕʋL���j
                            row["ACCEPTODRCARRF.FULLMODELRF"] = detailWorks[index].ACCEPTODRCARRF_FULLMODELRF; // �^���i�t���^�j
                            row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = detailWorks[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF; // �^���w��ԍ�
                            row["ACCEPTODRCARRF.CATEGORYNORF"] = detailWorks[index].ACCEPTODRCARRF_CATEGORYNORF; // �ޕʔԍ�
                            row["ACCEPTODRCARRF.FRAMEMODELRF"] = detailWorks[index].ACCEPTODRCARRF_FRAMEMODELRF; // �ԑ�^��
                            row["ACCEPTODRCARRF.FRAMENORF"] = detailWorks[index].ACCEPTODRCARRF_FRAMENORF; // �ԑ�ԍ�
                            row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = detailWorks[index].ACCEPTODRCARRF_SEARCHFRAMENORF; // �ԑ�ԍ��i�����p�j
                            row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = detailWorks[index].ACCEPTODRCARRF_ENGINEMODELNMRF; // �G���W���^������
                            row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = detailWorks[index].ACCEPTODRCARRF_RELEVANCEMODELRF; // �֘A�^��
                            row["ACCEPTODRCARRF.SUBCARNMCDRF"] = detailWorks[index].ACCEPTODRCARRF_SUBCARNMCDRF; // �T�u�Ԗ��R�[�h
                            row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELGRADESNAMERF; // �^���O���[�h����
                            row["ACCEPTODRCARRF.COLORCODERF"] = detailWorks[index].ACCEPTODRCARRF_COLORCODERF; // �J���[�R�[�h
                            row["ACCEPTODRCARRF.COLORNAME1RF"] = detailWorks[index].ACCEPTODRCARRF_COLORNAME1RF; // �J���[����1
                            row["ACCEPTODRCARRF.TRIMCODERF"] = detailWorks[index].ACCEPTODRCARRF_TRIMCODERF; // �g�����R�[�h
                            row["ACCEPTODRCARRF.TRIMNAMERF"] = detailWorks[index].ACCEPTODRCARRF_TRIMNAMERF; // �g��������
                            row["ACCEPTODRCARRF.MILEAGERF"] = detailWorks[index].ACCEPTODRCARRF_MILEAGERF; // �ԗ����s����
                            row["MAKGDS.MAKERSHORTNAMERF"] = detailWorks[index].MAKGDS_MAKERSHORTNAMERF; // ���i���[�J�[����
                            row["MAKGDS.MAKERKANANAMERF"] = detailWorks[index].MAKGDS_MAKERKANANAMERF; // ���i���[�J�[�J�i����
                            row["MAKGDS.GOODSMAKERCDRF"] = detailWorks[index].MAKGDS_GOODSMAKERCDRF; // ���[�U�[�������i���[�J�[�R�[�h
                            row["MAKCMP.MAKERSHORTNAMERF"] = detailWorks[index].MAKCMP_MAKERSHORTNAMERF; // �ꎮ���[�J�[����
                            row["MAKCMP.MAKERKANANAMERF"] = detailWorks[index].MAKCMP_MAKERKANANAMERF; // �ꎮ���[�J�[�J�i����
                            row["MAKCMP.GOODSMAKERCDRF"] = detailWorks[index].MAKCMP_GOODSMAKERCDRF; // ���[�U�[�����ꎮ���[�J�[�R�[�h
                            //row["GOODSURF.GOODSNAMEKANARF"] = detailWorks[index].GOODSURF_GOODSNAMEKANARF; // ���i���̃J�i
                            row["GOODSURF.JANRF"] = detailWorks[index].GOODSURF_JANRF; // JAN�R�[�h
                            row["GOODSURF.GOODSRATERANKRF"] = detailWorks[index].GOODSURF_GOODSRATERANKRF; // ���i�|�������N
                            row["GOODSURF.GOODSNONONEHYPHENRF"] = detailWorks[index].GOODSURF_GOODSNONONEHYPHENRF; // �n�C�t�������i�ԍ�
                            row["GOODSURF.GOODSNOTE1RF"] = detailWorks[index].GOODSURF_GOODSNOTE1RF; // ���i���l�P
                            row["GOODSURF.GOODSNOTE2RF"] = detailWorks[index].GOODSURF_GOODSNOTE2RF; // ���i���l�Q
                            row["GOODSURF.GOODSSPECIALNOTERF"] = detailWorks[index].GOODSURF_GOODSSPECIALNOTERF; // ���i�K�i�E���L����
                            row["STOCKRF.SHIPMENTPOSCNTRF"] = detailWorks[index].STOCKRF_SHIPMENTPOSCNTRF; // �o�׉\��
                            row["STOCKRF.DUPLICATIONSHELFNO1RF"] = detailWorks[index].STOCKRF_DUPLICATIONSHELFNO1RF; // �d���I�ԂP
                            row["STOCKRF.DUPLICATIONSHELFNO2RF"] = detailWorks[index].STOCKRF_DUPLICATIONSHELFNO2RF; // �d���I�ԂQ
                            row["STOCKRF.PARTSMANAGEMENTDIVIDE1RF"] = detailWorks[index].STOCKRF_PARTSMANAGEMENTDIVIDE1RF; // ���i�Ǘ��敪�P
                            row["STOCKRF.PARTSMANAGEMENTDIVIDE2RF"] = detailWorks[index].STOCKRF_PARTSMANAGEMENTDIVIDE2RF; // ���i�Ǘ��敪�Q
                            row["STOCKRF.STOCKNOTE1RF"] = detailWorks[index].STOCKRF_STOCKNOTE1RF; // �݌ɔ��l�P
                            row["STOCKRF.STOCKNOTE2RF"] = detailWorks[index].STOCKRF_STOCKNOTE2RF; // �݌ɔ��l�Q
                            row["WAREHOUSERF.WAREHOUSENOTE1RF"] = detailWorks[index].WAREHOUSERF_WAREHOUSENOTE1RF; // �q�ɔ��l1
                            row["USRCSG.GUIDENAMERF"] = detailWorks[index].USRCSG_GUIDENAMERF; // ���Ӑ�|���f�q����
                            //row["USRSPG.GUIDENAMERF"] = detailWorks[index].USRSPG_GUIDENAMERF; // �d����|���f�q����
                            row["SUPPLIERRF.SUPPLIERCDRF"] = detailWorks[index].SUPPLIERRF_SUPPLIERCDRF; // ���[�U�[�����d����R�[�h
                            row["SUPPLIERRF.SUPPLIERNM1RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNM1RF; // �d���於1
                            row["SUPPLIERRF.SUPPLIERNM2RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNM2RF; // �d���於2
                            row["SUPPLIERRF.SUPPHONORIFICTITLERF"] = detailWorks[index].SUPPLIERRF_SUPPHONORIFICTITLERF; // �d����h��
                            row["SUPPLIERRF.SUPPLIERKANARF"] = detailWorks[index].SUPPLIERRF_SUPPLIERKANARF; // �d����J�i
                            row["SUPPLIERRF.PURECODERF"] = detailWorks[index].SUPPLIERRF_PURECODERF; // �����敪
                            row["SUPPLIERRF.SUPPLIERNOTE1RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE1RF; // �d������l1
                            row["SUPPLIERRF.SUPPLIERNOTE2RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE2RF; // �d������l2
                            row["SUPPLIERRF.SUPPLIERNOTE3RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE3RF; // �d������l3
                            row["SUPPLIERRF.SUPPLIERNOTE4RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE4RF; // �d������l4
                            row["BLGOODSCDURF.BLGOODSCODERF"] = detailWorks[index].BLGOODSCDURF_BLGOODSCODERF; // ���[�U�[����BL���i�R�[�h
                            row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = detailWorks[index].BLGOODSCDURF_BLGOODSHALFNAMERF; // BL���i�R�[�h���́i���p�j
                            //row["DADD.STOCKMNGEXISTNMRF"] = detailWorks[index].DADD_STOCKMNGEXISTNMRF; // �݌ɊǗ��L���敪����
                            //row["DADD.GOODSKINDNAMERF"] = detailWorks[index].DADD_GOODSKINDNAMERF; // ���i��������
                            //row["DADD.SALESORDERDIVNMRF"] = detailWorks[index].DADD_SALESORDERDIVNMRF; // ����݌Ɏ�񂹋敪����
                            //row["DADD.OPENPRICEDIVNMRF"] = detailWorks[index].DADD_OPENPRICEDIVNMRF; // �I�[�v�����i�敪����
                            //row["DADD.GRSPROFITCHKDIVNMRF"] = detailWorks[index].DADD_GRSPROFITCHKDIVNMRF; // �e���`�F�b�N�敪����
                            //row["DADD.SALESGOODSNMRF"] = detailWorks[index].DADD_SALESGOODSNMRF; // ���㏤�i�敪����
                            //row["DADD.TAXATIONDIVNMRF"] = detailWorks[index].DADD_TAXATIONDIVNMRF; // �ېŋ敪����
                            //row["DADD.PURECODENMRF"] = detailWorks[index].DADD_PURECODENMRF; // �����敪
                            //row["DADD.SALESORDERDIVMARKRF"] = detailWorks[index].DADD_SALESORDERDIVMARKRF; // �݌Ɏ��敪�}�[�N
                            row["ACCEPTODRCARRF.MAKERHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERHALFNAMERF; // ���[�J�[���p����
                            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELHALFNAMERF; // �Ԏ피�p����
                            row["SALESDETAILRF.GOODSLGROUPRF"] = detailWorks[index].SALESDETAILRF_GOODSLGROUPRF; // ���i�啪�ރR�[�h
                            row["SALESDETAILRF.GOODSLGROUPNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSLGROUPNAMERF; // ���i�啪�ޖ���
                            row["SALESDETAILRF.GOODSMGROUPRF"] = detailWorks[index].SALESDETAILRF_GOODSMGROUPRF; // ���i�����ރR�[�h
                            row["SALESDETAILRF.GOODSMGROUPNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSMGROUPNAMERF; // ���i�����ޖ���
                            row["SALESDETAILRF.BLGROUPCODERF"] = detailWorks[index].SALESDETAILRF_BLGROUPCODERF; // BL�O���[�v�R�[�h
                            row["SALESDETAILRF.BLGROUPNAMERF"] = detailWorks[index].SALESDETAILRF_BLGROUPNAMERF; // BL�O���[�v�R�[�h����
                            row["SALESDETAILRF.SALESCODERF"] = detailWorks[index].SALESDETAILRF_SALESCODERF; // �̔��敪�R�[�h
                            row["SALESDETAILRF.SALESCDNMRF"] = detailWorks[index].SALESDETAILRF_SALESCDNMRF; // �̔��敪����
                            row["SALESDETAILRF.GOODSNAMEKANARF"] = detailWorks[index].SALESDETAILRF_GOODSNAMEKANARF; // ���i���̃J�i

                            // --- ADD ���痈  2009.07.27 ---------->>>>>

                           
                            //ABOEM�R�[�h
                            if ( slipWork.SANDESETTINGRF_PARTSOEMDIV == 0 )
                            {
                                row["DADD.ABGOODSNOTE2RF"] = DBNull.Value;
                            }
                            //else if (slipWork.SANDESETTINGRF_PARTSOEMDIV == 1)
                            else if ( slipWork.SANDESETTINGRF_PARTSOEMDIV == 1 &&
                                     !string.IsNullOrEmpty( detailWorks[index].SALESDETAILRF_GOODSNORF ) &&
                                     detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF != 0 )
                            {
                                // ���i�}�X�^����
                                GoodsAcs _goodsAcs = new GoodsAcs();
                                GoodsUnitData goodsUnitData;
                                // --- DEL donggy  for Redmine#35275 2013/04/15 --- >>>>>>>>
                                //int status = _goodsAcs.Read(slipPrtSet.EnterpriseCode, detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF,
                                //    detailWorks[index].SALESDETAILRF_GOODSNORF, out goodsUnitData );
                                // --- DEL donggy  for Redmine#35275 2013/04/15 --- <<<<<<<
                                // --- ADD donggy  for Redmine#35275 2013/04/15 --- >>>>>>>>
                                int status = _goodsAcs.SearchGoodsInfoOnly(slipPrtSet.EnterpriseCode, detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF,
                                                               detailWorks[index].SALESDETAILRF_GOODSNORF, out goodsUnitData); // ���i�}�X�^(���[�U�[�o�^���j����
                                // --- ADD donggy  for Redmine#35275 2013/04/15 --- <<<<<<<
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                                    && !string.IsNullOrEmpty( goodsUnitData.GoodsNo ) && goodsUnitData.LogicalDeleteCode == 0 )
                                {
                                    row["DADD.ABGOODSNOTE2RF"] = goodsUnitData.GoodsNote2;
                                }
                                else
                                {
                                    row["DADD.ABGOODSNOTE2RF"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                row["DADD.ABGOODSNOTE2RF"] = DBNull.Value;
                            }
                            //AB�����敪	
                            row["DADD.ABGOODSKINDCODERF"] = GetGoodsKindCode( detailWorks[index], slipWork );
                            //�o�א�(�}�C�i�X�����Ȃ�)	
                            row["DADD.SHIPMENTCNTNOMINUSRF"] = Math.Abs( detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF );
                            //�o�א��}�C�i�X����
                            if ( detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF >= 0 )
                            {
                                row["DADD.SHIPMENTCNTMINUSSIGNRF"] = string.Empty;
                            }
                            else
                            {
                                if ( titleDic.ContainsKey( ct_ShipmentCntMinusSignRF ) )
                                {
                                    row["DADD.SHIPMENTCNTMINUSSIGNRF"] = titleDic[ct_ShipmentCntMinusSignRF];
                                }
                            }

                            ////�o�א�
                            //row["DADD.SHIPMENTCNTWITHMINUSRF"] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            //������z�i�Ŕ����j(�}�C�i�X�����Ȃ�)  DADD.SALESMONEYTAXEXCNOMINUSRF
                            row["DADD.SALESMONEYTAXEXCNOMINUSRF"] = Math.Abs( detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF );
                            ////������z�i�Ŕ����j
                            //row["DADD.SALESMONEYTAXEXCWITHMINUSRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF;
                            //������z�i�Ŕ����j������z�}�C�i�X����
                            if ( detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF >= 0 )
                            {
                                row["DADD.SALESMONEYTAXEXCMINUSSIGNRF"] = string.Empty;
                            }
                            else
                            {
                                if ( titleDic.ContainsKey( ct_SalesMoneyTaxExcMinusSignRF ) )
                                {
                                    row["DADD.SALESMONEYTAXEXCMINUSSIGNRF"] = titleDic[ct_SalesMoneyTaxExcMinusSignRF];
                                }
                            }
                            // --- DEL  ���r��  2010/03/01 ---------->>>>>
                            ////�艿���z(�Ŕ�)  DADD.LISTPRICEMONEYTAXEXCRF	
                            ////row["DADD.LISTPRICEMONEYTAXEXCRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            //double beforeDoubleListpricemoneytaxexcrf = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            //long afterLongListpricemoneytaxexcrf = 0;                           
                            //// �[������
                            //FractionCalculate.FracCalcMoney( beforeDoubleListpricemoneytaxexcrf, 1, 2, out afterLongListpricemoneytaxexcrf );                            
                            //row["DADD.LISTPRICEMONEYTAXEXCRF"] = afterLongListpricemoneytaxexcrf;
                            // --- DEL  ���r��  2010/03/01 ----------<<<<<
                            //AB�{������  DADD.ABHQSALESUNITCOSTRF	
                            double aBHqSalesUnitCost = GetABHqSalesUnitCost( detailWorks[index], slipWork );
                            row["DADD.ABHQSALESUNITCOSTRF"] = aBHqSalesUnitCost;
                            //AB�{���������z(�}�C�i�X�����Ȃ�)  DADD.ABHQSALESUNITCOSTNOMINUSRF	
                            //row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = Math.Abs(aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF);
                            double beforeDoubleAbhqsalesunitconstnominusrf = Math.Abs( aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF );
                            long afterLongAbhqsalesunitconstnominusrf = 0;
                            // �[������
                            FractionCalculate.FracCalcMoney( beforeDoubleAbhqsalesunitconstnominusrf, 1, 2, out afterLongAbhqsalesunitconstnominusrf );
                            row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = afterLongAbhqsalesunitconstnominusrf;
                            ////AB�{���������z
                            //row["DADD.ABHQSALESUNITCOSTWITHMINUSRF"] = aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            //AB�{���������z�}�C�i�X����
                            if ( aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF >= 0 )
                            {
                                row["DADD.ABHQSALESUNITCOSTMINUSSIGNRF"] = string.Empty;
                            }
                            else
                            {
                                if ( titleDic.ContainsKey( ct_ABHqSalesUnitCostMinusSignRF ) )
                                {
                                    row["DADD.ABHQSALESUNITCOSTMINUSSIGNRF"] = titleDic[ct_ABHqSalesUnitCostMinusSignRF];
                                }
                            }

                            // --- ADD  ���r��  2010/05/13 ---------->>>>>
                            //�e�����z                         
                            row["DADD.GROSSPROFITRF"] = GetGrossProfit(detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF, (decimal)detailWorks[index].SALESDETAILRF_SALESUNITCOSTRF, (decimal)detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF);                           
                            //�e����
                            Double grossProfitRate = 0;
                            grossProfitRate = stc_grossProfitCalculator.CalcGrossProfitRate((long)detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF, (long)detailWorks[index].SALESDETAILRF_COSTRF);
                            row["DADD.GROSSPROFITRATERF"] = grossProfitRate;
                            //�e�������e����
                            if (!string.IsNullOrEmpty(grossProfitRate.ToString()))
                            {
                                row["DADD.GROSSPROFITRATELTRLRF"] = "%";
                            }
                            else
                            {
                                row["DADD.GROSSPROFITRATELTRLRF"] = DBNull.Value;
                            }
                            // --- ADD  ���r��  2010/05/13 ----------<<<<<

                            // --- ADD  ���r��  2010/06/03 ---------->>>
                            #region[������z(���ד]�ł̂ݐō�)]
                            if (consTaxLayMethod == 1)
                            {
                                //���ד]��
                                row["DADD.SALESMONEYTAXLAYDTLRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXINCRF;
                            }
                            else
                            {
                                //���ד]�ňȊO
                                row["DADD.SALESMONEYTAXLAYDTLRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF;
                            }
                            #endregion
                            // --- ADD  ���r��  2010/06/03 ----------<<<<<

                            // --- ADD  2011/07/19 ---------->>>
                            #region[�����񓚋敪(SCM)]
                            // SCM�񓚃}�[�N�󎚋敪:0:���Ȃ�,1:����
                            //if (slipPrtSet.SCMAnsMarkPrtDiv == 0)// DEL  2011/08/05
                            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC) != PurchaseStatus.Contract || slipPrtSet.SCMAnsMarkPrtDiv == 0)// ADD  2011/08/05 // DEL  2011/08/08
                            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) != PurchaseStatus.Contract || slipPrtSet.SCMAnsMarkPrtDiv == 0)// ADD  2011/08/08
                            {
                                row["HADD.NORMALPRTMARKRF"] = string.Empty;
                                row["HADD.SCMMANUALANSMARKRF"] = string.Empty;
                                row["HADD.SCMAUTOANSMARKRF"] = string.Empty;
                            }
                            else
                            {
                                // 0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������
                                if (detailWorks[index].SALESDETAILRF_AUTOANSWERDIVSCMRF == 0)
                                {
                                    row["HADD.NORMALPRTMARKRF"] = slipPrtSet.NormalPrtMark;
                                    row["HADD.SCMMANUALANSMARKRF"] = string.Empty;
                                    row["HADD.SCMAUTOANSMARKRF"] = string.Empty;
                                }
                                else if (detailWorks[index].SALESDETAILRF_AUTOANSWERDIVSCMRF == 1)
                                {
                                    row["HADD.NORMALPRTMARKRF"] = string.Empty;
                                    row["HADD.SCMMANUALANSMARKRF"] = slipPrtSet.SCMManualAnsMark;
                                    row["HADD.SCMAUTOANSMARKRF"] = string.Empty;
                                }
                                else if (detailWorks[index].SALESDETAILRF_AUTOANSWERDIVSCMRF == 2)
                                {
                                    row["HADD.NORMALPRTMARKRF"] = string.Empty;
                                    row["HADD.SCMMANUALANSMARKRF"] = string.Empty;
                                    row["HADD.SCMAUTOANSMARKRF"] = slipPrtSet.SCMAutoAnsMark;
                                }
                            }
                            #endregion
                            // --- ADD  2011/07/19 ----------<<<<<

                            // �s�l���s�ƒ��ߍs�擾
                            //���ߍs �t���O
                            bool rowFlg1 = false;
                            //�s�l���s �t���O
                            bool rowFlg2 = false;
                            if ( detailWorks[index].SALESDETAILRF_SALESSLIPCDDTLRF == 3 )
                            {
                                rowFlg1 = true;
                            }
                            if ( detailWorks[index].SALESDETAILRF_SALESSLIPCDDTLRF == 2
                                && detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF == 0 )
                            {
                                rowFlg2 = true;
                            }
                            //AB���i�R�[�h  DADD.ABGOODSCODERF	
                            if ( rowFlg1 || rowFlg2 )
                            {
                                row["DADD.ABGOODSCODERF"] = 0;
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( detailWorks[index].SANDEGOODSCDCHGRF_ABGOODSCODE ) )
                                {
                                    row["DADD.ABGOODSCODERF"] = detailWorks[index].SANDEGOODSCDCHGRF_ABGOODSCODE;
                                }
                                else
                                {
                                    if ( !string.IsNullOrEmpty( slipWork.SANDESETTINGRF_ABGOODSCODE ) )
                                    {
                                        row["DADD.ABGOODSCODERF"] = slipWork.SANDESETTINGRF_ABGOODSCODE;
                                    }
                                    else
                                    {
                                        row["DADD.ABGOODSCODERF"] = 0;
                                    }
                                }
                            }
                            // ����
                            if ( rowFlg1 || rowFlg2 )
                            {
                                row["DADD.SHIPMENTCNTNOMINUSRF"] = DBNull.Value;
                                row["DADD.LISTPRICEMONEYTAXEXCRF"] = DBNull.Value;
                                row["DADD.ABHQSALESUNITCOSTRF"] = DBNull.Value;
                                row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = DBNull.Value;
                                row["DADD.ABGOODSCODERF"] = DBNull.Value;
                                if ( rowFlg1 )
                                {
                                    row["DADD.SALESMONEYTAXEXCNOMINUSRF"] = DBNull.Value;
                                }
                            }

                            // --- ADD ���痈�@2009.07.27 ----------<<<<<                            
                            # endregion

                            # region [���׍���(�����ȊO)]

                            // ���ݒ莞 ��󎚃R�[�h
                            # region [���ݒ�]
                            //if ( IsZero( detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF ) ) row["SALESDETAILRF.GOODSMAKERCDRF"] = DBNull.Value; // ���i���[�J�[�R�[�h
                            //if ( IsZero( detailWorks[index].SALESDETAILRF_BLGOODSCODERF )) row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_ENTERPRISEGANRECODERF ) ) row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = DBNull.Value; // ���Е��ރR�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_CUSTRATEGRPCODERF ) ) row["SALESDETAILRF.CUSTRATEGRPCODERF"] = DBNull.Value; // ���Ӑ�|���O���[�v�R�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_SUPPLIERCDRF ) ) row["SALESDETAILRF.SUPPLIERCDRF"] = DBNull.Value; // �d����R�[�h
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_MAKERCODERF ) ) row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value; // ���[�J�[�R�[�h
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_MODELCODERF ) ) row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value; // �Ԏ�R�[�h
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF ) ) row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value; // �^���w��ԍ�
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_CATEGORYNORF ) ) row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value; // �ޕʔԍ�
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_MAKERCODERF ) ) row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value; // ���[�J�[�R�[�h
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_MODELCODERF ) ) row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value; // �Ԏ�R�[�h
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_MODELSUBCODERF ) ) row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value; // �Ԏ�T�u�R�[�h
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_CARMNGNORF ) ) row["ACCEPTODRCARRF.CARMNGNORF"] = DBNull.Value; // �ԗ��Ǘ��ԍ�
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE1CODERF ) ) row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = DBNull.Value; // ���^�������ԍ�
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE4RF ) ) row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = DBNull.Value; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_FIRSTENTRYDATERF ) ) row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = DBNull.Value; // ���N�x
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_SEARCHFRAMENORF ) ) row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = DBNull.Value; // �ԑ�ԍ��i�����p�j
                            if ( IsZero( detailWorks[index].ACCEPTODRCARRF_SUBCARNMCDRF ) ) row["ACCEPTODRCARRF.SUBCARNMCDRF"] = DBNull.Value; // �T�u�Ԗ��R�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_WAREHOUSECODERF ) ) row["SALESDETAILRF.WAREHOUSECODERF"] = DBNull.Value; // �q�ɃR�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_GOODSLGROUPRF ) ) row["SALESDETAILRF.GOODSLGROUPRF"] = DBNull.Value; // ���i�啪�ރR�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_GOODSMGROUPRF ) ) row["SALESDETAILRF.GOODSMGROUPRF"] = DBNull.Value; // ���i�����ރR�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_BLGROUPCODERF ) ) row["SALESDETAILRF.BLGROUPCODERF"] = DBNull.Value; // BL�O���[�v�R�[�h
                            if ( IsZero( detailWorks[index].SALESDETAILRF_SALESCODERF ) ) row["SALESDETAILRF.SALESCODERF"] = DBNull.Value; // �̔��敪�R�[�h
                            # endregion

                            // ���z�\��
                            # region [���z�\��]

                            // �ō��t���O
                            bool taxIn = false;
                            # region [taxIn]
                            // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
                            if ( slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF == 1 )
                            {
                                //------------------------------------------------------------
                                // ���z�\��������@���@�ېŋ敪�ɂ�炸�A��ɐō��\��
                                //------------------------------------------------------------
                                taxIn = true;
                            }
                            else
                            {
                                //------------------------------------------------------------
                                // ���z�\�������Ȃ��@���@�ېŋ敪�ɏ]��
                                //------------------------------------------------------------
                                // 0:�ې�,1:��ې�,2:�ېŁi���Łj
                                if ( detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF == 2 )
                                {
                                    // �ō��݂���
                                    taxIn = true;
                                }
                            }
                            # endregion

                            // �󎚓��e�͕K��..TAXINC..�Ɋi�[���A..TAXEXC..�͎g�p���Ȃ�
                            # region [set]
                            if ( taxIn )
                            {
                                // �ō�
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXINCFLRF; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXINCFLRF; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXINCRF; // ������z�i�ō��݁j
                                // --- ADD  ���r��  2010/03/01 ---------->>>>>                               
                                //�艿���z�����
                                //row["DADD.LISTPRICEMONEYTAXRF"] = listPriceTaxDic[index];
                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                            }
                            else
                            {
                                // �Ŕ�
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXEXCFLRF; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF; // ������z�i�Ŕ����j
                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                //�艿���z(�Ŕ�)
                                //row["DADD.LISTPRICEMONEYTAXEXCRF"] = listPriceDic[index];
                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                            }
                            row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                            row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                            row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // ������z�i�Ŕ����j                        
                            # endregion

                            # endregion

                            // "����p"����
                            # region ["����p"]
                            // �i"����p"���ڂ�����A�ȉ��̃J�����͓��e�������ւ���j
                            row["SALESDETAILRF.GOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_PRTMAKERCODERF; // ���i���[�J�[�R�[�h
                            row["SALESDETAILRF.MAKERNAMERF"] = detailWorks[index].SALESDETAILRF_PRTMAKERNAMERF; // ���[�J�[����
                            row["SALESDETAILRF.GOODSNORF"] = detailWorks[index].SALESDETAILRF_PRTGOODSNORF; // ���i�ԍ�
                            row["SALESDETAILRF.BLGOODSCODERF"] = detailWorks[index].SALESDETAILRF_PRTBLGOODSCODERF; // BL���i�R�[�h
                            row["SALESDETAILRF.BLGOODSFULLNAMERF"] = detailWorks[index].SALESDETAILRF_PRTBLGOODSNAMERF; // BL���i�R�[�h���́i�S�p�j
                            // ��󎚔���
                            if ( detailWorks[index].SALESDETAILRF_PRTMAKERCODERF == 0 ) row["SALESDETAILRF.GOODSMAKERCDRF"] = DBNull.Value; // ���i���[�J�[�R�[�h
                            if ( detailWorks[index].SALESDETAILRF_PRTBLGOODSCODERF == 0 ) row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h
                            # endregion

                            // �Œ薼�̎擾
                            # region [�Œ薼��]
                            row["DADD.STOCKMNGEXISTNMRF"] = GetDADD_STOCKMNGEXISTNMRF( detailWorks[index].SALESDETAILRF_STOCKMNGEXISTCDRF ); // �݌ɊǗ��L���敪����
                            row["DADD.GOODSKINDNAMERF"] = GetDADD_GOODSKINDNAMERF( detailWorks[index].SALESDETAILRF_GOODSKINDCODERF ); // ���i��������
                            row["DADD.SALESORDERDIVNMRF"] = GetDADD_SALESORDERDIVNMRF( detailWorks[index].SALESDETAILRF_SALESORDERDIVCDRF ); // ����݌Ɏ�񂹋敪����
                            row["DADD.OPENPRICEDIVNMRF"] = GetDADD_OPENPRICEDIVNMRF( detailWorks[index].SALESDETAILRF_OPENPRICEDIVRF ); // �I�[�v�����i�敪����
                            row["DADD.GRSPROFITCHKDIVNMRF"] = GetDADD_GRSPROFITCHKDIVNMRF( detailWorks[index].SALESDETAILRF_GRSPROFITCHKDIVRF ); // �e���`�F�b�N�敪����
                            row["DADD.SALESGOODSNMRF"] = GetDADD_SALESGOODSNMRF( detailWorks[index].SALESDETAILRF_SALESGOODSCDRF ); // ���㏤�i�敪����
                            row["DADD.TAXATIONDIVNMRF"] = GetDADD_TAXATIONDIVNMRF( detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF ); // �ېŋ敪����
                            row["DADD.PURECODENMRF"] = GetDADD_PURECODENMRF( detailWorks[index].SUPPLIERRF_PURECODERF ); // �����敪
                            # endregion

                            // �݌Ɏ��敪�}�[�N
                            # region [�݌Ɏ��敪�}�[�N]
                            // 0:���("*")�C1:�݌�("")
                            if ( detailWorks[index].SALESDETAILRF_SALESORDERDIVCDRF == 0 )
                            {
                                row["DADD.SALESORDERDIVMARKRF"] = "*"; // �݌Ɏ��敪�}�[�N

                                // �݌ɏ����
                                row["SALESDETAILRF.WAREHOUSECODERF"] = DBNull.Value; // �q�ɃR�[�h
                                row["STOCKRF.SHIPMENTPOSCNTRF"] = DBNull.Value; // �o�׉\��
                                row["STOCKRF.DUPLICATIONSHELFNO1RF"] = DBNull.Value; // �d���I�ԂP
                                row["STOCKRF.DUPLICATIONSHELFNO2RF"] = DBNull.Value; // �d���I�ԂQ
                                row["STOCKRF.PARTSMANAGEMENTDIVIDE1RF"] = DBNull.Value; // ���i�Ǘ��敪�P
                                row["STOCKRF.PARTSMANAGEMENTDIVIDE2RF"] = DBNull.Value; // ���i�Ǘ��敪�Q
                                row["STOCKRF.STOCKNOTE1RF"] = DBNull.Value; // �݌ɔ��l�P
                                row["STOCKRF.STOCKNOTE2RF"] = DBNull.Value; // �݌ɔ��l�Q
                                row["WAREHOUSERF.WAREHOUSENOTE1RF"] = DBNull.Value; // �q�ɔ��l1

                                // �d����R�[�h(���̂�)
                                row[ct_SupplierCdExtra] = row["SALESDETAILRF.SUPPLIERCDRF"];
                            }
                            else
                            {
                                row["DADD.SALESORDERDIVMARKRF"] = string.Empty; // �݌Ɏ��敪�}�[�N

                                // �d����R�[�h(���̂�)���݌ɂȂ�Δ��
                                row[ct_SupplierCdExtra] = DBNull.Value;

                                // �I�ԁi���Ӑ撍�ԂȂ����̂݁j
                                if ( string.IsNullOrEmpty( detailWorks[index].SALESDETAILRF_PARTYSLIPNUMDTLRF ) )
                                {
                                    row[ct_ShelfNoExtra] = row["SALESDETAILRF.WAREHOUSESHELFNORF"];
                                }
                            }
                            # endregion

                            // ���t�W�J
                            # region [���t�W�J]
                            // �ʏ�
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, detailWorks[index].SALESDETAILRF_DELIGDSCMPLTDUEDATERF, "DADD.DELIGDSCMPLTDUEDATE", false ); // �[�������\���yyyymmdd
                            // �N��
                            ExtractDate( ref row, allDefSet.EraNameDispCd1, detailWorks[index].ACCEPTODRCARRF_FIRSTENTRYDATERF, "DADD.FIRSTENTRYDATE", true ); // ���N�xyyyymm
                            # endregion

                            // �󒍐��E�o�א�
                            # region [�󒍐��E�o�א�]
                            if ( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF == 10 || slipWork.SALESSLIPRF_ACPTANODRSTATUSRF == 20 )
                            {
                                // �󒍃X�e�[�^�X��10:����,20:��
                                row[ct_AcptCount] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF; // �󒍐�
                                row[ct_ShipCount] = DBNull.Value; // �o�א�
                            }
                            else
                            {
                                // �󒍃X�e�[�^�X��10:����,20:��
                                row[ct_AcptCount] = DBNull.Value; // �󒍐�
                                row[ct_ShipCount] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF; // �o�א�
                            }
                            # endregion

                            // �ޕʌ^���n�C�t��
                            # region [�ޕʌ^���n�C�t��]
                            if ( detailWorks[index].ACCEPTODRCARRF_CATEGORYNORF == 0 && detailWorks[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF == 0 )
                            {
                                row[ct_DCategoryHyp] = DBNull.Value;
                            }
                            else
                            {
                                row[ct_DCategoryHyp] = "-";
                            }
                            # endregion

                            // ���p���Ή�
                            # region [���p���Ή�]
                            if ( string.IsNullOrEmpty( detailWorks[index].SALESDETAILRF_GOODSNAMEKANARF ) )
                            {
                                row["SALESDETAILRF.GOODSNAMEKANARF"] = detailWorks[index].SALESDETAILRF_GOODSNAMERF; // �i���J�i���i���Z�b�g
                            }
                            row["GOODSURF.GOODSNAMEKANARF"] = row["SALESDETAILRF.GOODSNAMEKANARF"];
                            if ( string.IsNullOrEmpty( detailWorks[index].ACCEPTODRCARRF_MAKERHALFNAMERF ) )
                            {
                                row["ACCEPTODRCARRF.MAKERHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERFULLNAMERF; // ���[�J�[���p���́��S�p���Z�b�g
                            }
                            if ( string.IsNullOrEmpty( detailWorks[index].ACCEPTODRCARRF_MODELHALFNAMERF ) )
                            {
                                // --- UPD  ���r��  2010/06/24 ---------->>>>>
                                //row["ACCEPTODRCARRF.MODELHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELFULLNAMERF; // �Ԏ피�p���́��S�p���Z�b�g
                                row["ACCEPTODRCARRF.MODELHALFNAMERF"] = GetKanaString(detailWorks[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                                // --- UPD  ���r��  2010/06/24 ----------<<<<<
                            }
                            # endregion
                                                       
                            // --- ADD  ���r��  2010/03/01 ---------->>>>>
                            #region [�艿���z]
                            //�艿���z(�Ŕ�)
                            row["DADD.LISTPRICEMONEYTAXEXCRF"] = listPriceDic[index];
                            //�艿���z�����
                            //���ד]�łŏ���Łu�󎚂���v�̎�
                            if (consTaxLayMethod == 1 && slipPrtSet.ConsTaxPrtCdRF == 1)
                            {                                
                                row["DADD.LISTPRICEMONEYTAXRF"] = listPriceTaxDic[index];
                            }
                            else
                            {                           
                                row["DADD.LISTPRICEMONEYTAXRF"] = DBNull.Value;
                            }
                            #endregion
                            // --- ADD  ���r��  2010/03/01 ----------<<<<<


                            // �s�l���E���ߍs�̐���
                            # region [�s�l���E���ߍs�̐���]
                            if ( IsRowDiscount( detailWorks[index] ) )
                            {
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // �����P��
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // �o�א�
                                row["SALESDETAILRF.ACCEPTANORDERCNTRF"] = DBNull.Value; // �󒍐���
                                row["SALESDETAILRF.ACPTANODRADJUSTCNTRF"] = DBNull.Value; // �󒍒�����
                                row["SALESDETAILRF.ACPTANODRREMAINCNTRF"] = DBNull.Value; // �󒍎c��
                                row[ct_AcptCount] = DBNull.Value; // �󒍐�
                                row[ct_ShipCount] = DBNull.Value; // �o�א�
                                row["DADD.STOCKMNGEXISTNMRF"] = DBNull.Value; // �݌ɊǗ��L���敪����
                                row["DADD.GOODSKINDNAMERF"] = DBNull.Value; // ���i��������
                                row["DADD.SALESORDERDIVNMRF"] = DBNull.Value; // ����݌Ɏ�񂹋敪����
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // �I�[�v�����i�敪����
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // �e���`�F�b�N�敪����
                                row["DADD.SALESGOODSNMRF"] = DBNull.Value; // ���㏤�i�敪����
                                row["DADD.TAXATIONDIVNMRF"] = DBNull.Value; // �ېŋ敪����
                                row["DADD.PURECODENMRF"] = DBNull.Value; // �����敪
                                row["DADD.SALESORDERDIVMARKRF"] = DBNull.Value; // �݌Ɏ��敪�}�[�N
                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                row["DADD.LISTPRICEMONEYTAXEXCRF"] = DBNull.Value;//�艿���z(�Ŕ�)
                                row["DADD.LISTPRICEMONEYTAXRF"] = DBNull.Value;//�艿���z�����
                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                            else if ( IsCommentRow( detailWorks[index] ) )
                            {
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // �����P��
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // �o�א�
                                row["SALESDETAILRF.ACCEPTANORDERCNTRF"] = DBNull.Value; // �󒍐���
                                row["SALESDETAILRF.ACPTANODRADJUSTCNTRF"] = DBNull.Value; // �󒍒�����
                                row["SALESDETAILRF.ACPTANODRREMAINCNTRF"] = DBNull.Value; // �󒍎c��
                                row[ct_AcptCount] = DBNull.Value; // �󒍐�
                                row[ct_ShipCount] = DBNull.Value; // �o�א�
                                row["DADD.STOCKMNGEXISTNMRF"] = DBNull.Value; // �݌ɊǗ��L���敪����
                                row["DADD.GOODSKINDNAMERF"] = DBNull.Value; // ���i��������
                                row["DADD.SALESORDERDIVNMRF"] = DBNull.Value; // ����݌Ɏ�񂹋敪����
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // �I�[�v�����i�敪����
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // �e���`�F�b�N�敪����
                                row["DADD.SALESGOODSNMRF"] = DBNull.Value; // ���㏤�i�敪����
                                row["DADD.TAXATIONDIVNMRF"] = DBNull.Value; // �ېŋ敪����
                                row["DADD.PURECODENMRF"] = DBNull.Value; // �����敪
                                row["DADD.SALESORDERDIVMARKRF"] = DBNull.Value; // �݌Ɏ��敪�}�[�N

                                // ���z���
                                row["SALESDETAILRF.OPENPRICEDIVRF"] = DBNull.Value; // �I�[�v�����i�敪
                                row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // �艿��
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // �ύX�O�艿
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // �I�[�v�����i�敪����
                                row["SALESDETAILRF.SALESRATERF"] = DBNull.Value; // ������
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value; // ������z�i�ō��݁j
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // ������z�i�Ŕ����j
                                row["SALESDETAILRF.BFSALESUNITPRICERF"] = DBNull.Value; // �ύX�O����
                                row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = DBNull.Value; // ����P���i�ꎮ�j
                                row["SALESDETAILRF.CMPLTSALESMONEYRF"] = DBNull.Value; // ������z�i�ꎮ�j
                                row["SALESDETAILRF.COSTRATERF"] = DBNull.Value; // ������
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // �����P��
                                row["SALESDETAILRF.COSTRF"] = DBNull.Value; // ����
                                row["SALESDETAILRF.GRSPROFITCHKDIVRF"] = DBNull.Value; // �e���`�F�b�N�敪
                                row["SALESDETAILRF.BFUNITCOSTRF"] = DBNull.Value; // �ύX�O����
                                row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = DBNull.Value; // �����P���i�ꎮ�j
                                row["SALESDETAILRF.CMPLTCOSTRF"] = DBNull.Value; // �������z�i�ꎮ�j
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // �e���`�F�b�N�敪����
                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                row["DADD.LISTPRICEMONEYTAXEXCRF"] = DBNull.Value;//�艿���z(�Ŕ�)
                                row["DADD.LISTPRICEMONEYTAXRF"] = DBNull.Value;//�艿���z�����
                                // --- ADD  ���r��  2010/03/01 ----------<<<<<
                                // --- ADD  ���r��  2010/05/13 ---------->>>>>
                                row["DADD.GROSSPROFITRATERF"] = DBNull.Value;//�e����
                                row["DADD.GROSSPROFITRF"] = DBNull.Value;//�e�����z
                                row["DADD.GROSSPROFITRATELTRLRF"] = DBNull.Value;//�e�������e����
                                // --- ADD  ���r��  2010/05/13 ----------<<<<<
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                row["DADD.SALESMONEYTAXLAYDTLRF"] = DBNull.Value;//������z(���ד]�ł̂ݐō�)
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
                            # endregion

                            # endregion

                            # region [�O���[�v�T�v���X]
                            // ����T�v���X�L�[�擾
                            GroupSuppressKey suppressKey = GroupSuppressKey.CreateKeyOfCar( row );
                            if ( suppressKey.CompareTo( prevSuppressKey ) == 0 ) ReflectSuppressOfCar( ref row );
                            // �ޔ��L�[�X�V
                            prevSuppressKey = suppressKey;
                            # endregion

                            # region [���׍���(�`�[�^�C�v�ʐݒ�)]
                            // �i��
                            if ( eachSlipTypeSet.GoodsNo == 0 )
                            {
                                row["SALESDETAILRF.GOODSNORF"] = DBNull.Value; // ���i�ԍ�
                                row["GOODSURF.GOODSNONONEHYPHENRF"] = DBNull.Value; // �n�C�t�������i�ԍ�
                            }
                            // �a�k�R�[�h
                            if ( eachSlipTypeSet.BLGoodsCode == 0 )
                            {
                                row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h
                                row["SALESDETAILRF.BLGOODSFULLNAMERF"] = DBNull.Value; // BL���i�R�[�h���́i�S�p�j
                                row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = DBNull.Value; // BL���i�R�[�h���́i���p�j
                            }
                            // �W�����i
                            if (CheckListPricePrint(detailWorks[index], eachSlipTypeSet) == false)
                            {
                                row["SALESDETAILRF.OPENPRICEDIVRF"] = DBNull.Value; // �I�[�v�����i�敪
                                row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // �艿��
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // �ύX�O�艿
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // �I�[�v�����i�敪����
                                // --- ADD  ���r��  2010/03/01 ---------->>>>>
                                row["DADD.LISTPRICEMONEYTAXEXCRF"] = DBNull.Value;//�艿���z(�Ŕ���)
                                row["DADD.LISTPRICEMONEYTAXRF"] = DBNull.Value;//�艿���z�����
                                row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = DBNull.Value;//�艿���z���v(�Ŕ���)
                                row["HADD.LISTPRICEMONEYTOTALTAXRF"] = DBNull.Value;//�艿���z���v�����
                                row["HADD.LISTPRICEMONEYTOTALTAXINCRF"] = DBNull.Value;//�艿���z���v(�ō�)
                                // --- ADD  ���r��  2010/03/01 ----------<<<<<                                
                            }                             
                            
                            // ����
                            if ( eachSlipTypeSet.SalesPrice == 0 )
                            {
                                row["SALESDETAILRF.SALESRATERF"] = DBNull.Value; // ������
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value; // ������z�i�ō��݁j
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // ������z�i�Ŕ����j
                                row["SALESDETAILRF.BFSALESUNITPRICERF"] = DBNull.Value; // �ύX�O����
                                row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = DBNull.Value; // ����P���i�ꎮ�j
                                row["SALESDETAILRF.CMPLTSALESMONEYRF"] = DBNull.Value; // ������z�i�ꎮ�j
                                // --- ADD  ���r��  2010/06/03 ---------->>>>>
                                row["DADD.SALESMONEYTAXLAYDTLRF"] = DBNull.Value; // ������z(���ד]�ł̂ݐō�)
                                // --- ADD  ���r��  2010/06/03 ----------<<<<<
                            }
                            // ����
                            if ( eachSlipTypeSet.Cost == 0 )
                            {
                                row["SALESDETAILRF.COSTRATERF"] = DBNull.Value; // ������
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // �����P��
                                row["SALESDETAILRF.COSTRF"] = DBNull.Value; // ����
                                row["SALESDETAILRF.GRSPROFITCHKDIVRF"] = DBNull.Value; // �e���`�F�b�N�敪
                                row["SALESDETAILRF.BFUNITCOSTRF"] = DBNull.Value; // �ύX�O����
                                row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = DBNull.Value; // �����P���i�ꎮ�j
                                row["SALESDETAILRF.CMPLTCOSTRF"] = DBNull.Value; // �������z�i�ꎮ�j
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // �e���`�F�b�N�敪����
                            }
                            // ���}�[�N
                            if ( eachSlipTypeSet.SalesOrderDiv == 0 )
                            {
                                row["DADD.SALESORDERDIVMARKRF"] = DBNull.Value; // �݌Ɏ��敪�}�[�N
                                row["DADD.SALESORDERDIVNMRF"] = DBNull.Value; // ����݌Ɏ�񂹋敪����
                            }
                            # endregion
                        }
                        else
                        {
                            //-------------------------------------------
                            // �󖾍�
                            //-------------------------------------------
                        }
                        // --- ADD  ���r��  2010/03/01 ---------->>>>>
                        //���׍s��(��ɕ\��)
                        int detailFeedCount = 0;
                        if (frePrtPSet.FormFeedLineCount != index + 1)
                        {
                            detailFeedCount = (index + 1) % frePrtPSet.FormFeedLineCount;
                        }
                        else
                        {
                            detailFeedCount = frePrtPSet.FormFeedLineCount;
                        }                       
                        row["DADD.DETAILROWCOUNTALLRF"] = detailFeedCount;
                        // --- ADD  ���r��  2010/03/01 ----------<<<<<

                        # region [���䍀��]
                        row[ct_InPageCopyTitle1] = inPageCopyTitle[0][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyTitle2] = inPageCopyTitle[1][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyTitle3] = inPageCopyTitle[2][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyTitle4] = inPageCopyTitle[3][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyCount] = (pageIndex * 10) + inPageCopyCount;    // ����y�[�W���R�s�[�J�E���g

                        // --- ADD ����� 2011/08/15---------->>>>>
                        // --- UPD ����� 2011/09/13---------->>>>>
                        //if (inPageCopyTitle[0].Count < 5)
                        //{
                        //    for (int i = inPageCopyTitle[0].Count; i < 5; i++)
                        //    {
                        //        inPageCopyTitle[0].Add(string.Empty);
                        //    }
                        //}
                        //row[ct_SlipTitle11] = inPageCopyTitle[0][0]; // �^�C�g���P�E�P
                        //row[ct_SlipTitle12] = inPageCopyTitle[0][1]; // �^�C�g���P�E�Q
                        //row[ct_SlipTitle13] = inPageCopyTitle[0][2]; // �^�C�g���P�E�R
                        //row[ct_SlipTitle14] = inPageCopyTitle[0][3]; // �^�C�g���P�E�S
                        //row[ct_SlipTitle15] = inPageCopyTitle[0][4]; // �^�C�g���P�E�T

                        for (int i = 0; i < inPageCopyTitle[0].Count; i++)
                        {
                            row["PMHNB08001P.SLIPTITLE1" + (i + 1)] = inPageCopyTitle[0][i];
                        }
                        // --- UPD ����� 2011/09/13----------<<<<<

                        row[ct_SlipTitle21] = inPageCopyTitle[1][0]; // �^�C�g���Q�E�P
                        row[ct_SlipTitle22] = inPageCopyTitle[1][1]; // �^�C�g���Q�E�Q
                        row[ct_SlipTitle23] = inPageCopyTitle[1][2]; // �^�C�g���Q�E�R
                        row[ct_SlipTitle24] = inPageCopyTitle[1][3]; // �^�C�g���Q�E�S
                        row[ct_SlipTitle25] = inPageCopyTitle[1][4]; // �^�C�g���Q�E�T

                        row[ct_SlipTitle31] = inPageCopyTitle[2][0]; // �^�C�g���R�E�P
                        row[ct_SlipTitle32] = inPageCopyTitle[2][1]; // �^�C�g���R�E�Q
                        row[ct_SlipTitle33] = inPageCopyTitle[2][2]; // �^�C�g���R�E�R
                        row[ct_SlipTitle34] = inPageCopyTitle[2][3]; // �^�C�g���R�E�S
                        row[ct_SlipTitle35] = inPageCopyTitle[2][4]; // �^�C�g���R�E�T

                        row[ct_SlipTitle41] = inPageCopyTitle[3][0]; // �^�C�g���S�E�P
                        row[ct_SlipTitle42] = inPageCopyTitle[3][1]; // �^�C�g���S�E�Q
                        row[ct_SlipTitle43] = inPageCopyTitle[3][2]; // �^�C�g���S�E�R
                        row[ct_SlipTitle44] = inPageCopyTitle[3][3]; // �^�C�g���S�E�S
                        row[ct_SlipTitle45] = inPageCopyTitle[3][4]; // �^�C�g���S�E�T
                        // --- ADD ����� 2011/08/15----------<<<<<


                        if ( pageIndex == allPageCount - 1 )
                        {
                            // �ŏI��
                            if ( titleDic.ContainsKey( ct_TaxTitle ) )
                            {
                                row[ct_TaxTitle] = titleDic[ct_TaxTitle];
                            }
                            else
                            {
                                row[ct_TaxTitle] = "�����";
                            }
                            if ( titleDic.ContainsKey( ct_SubTotalTitle ) )
                            {
                                row[ct_SubTotalTitle] = titleDic[ct_SubTotalTitle];
                            }
                            else
                            {
                                row[ct_SubTotalTitle] = "���v";
                            }
                            // --- ADD  ���r��  2010/03/01 ---------->>>>>
                            if (titleDic.ContainsKey(ct_SalesTotalTaxIncTitle))
                            {
                                row[ct_SalesTotalTaxIncTitle] = titleDic[ct_SalesTotalTaxIncTitle];
                            }
                            else
                            {
                                row[ct_SalesTotalTaxIncTitle] = "���v";
                            }
                            // --- ADD  ���r��  2010/03/01 ----------<<<<<
                        }
                        else
                        {
                            // �ŏI�ȊO
                            row[ct_TaxTitle] = string.Empty;
                            row[ct_SubTotalTitle] = string.Empty;
                            // --- ADD  ���r��  2010/03/01 ---------->>>>>
                            row[ct_SalesTotalTaxIncTitle] = string.Empty;
                            // --- ADD  ���r��  2010/03/01 ----------<<<<<
                        }
                        # endregion

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                        // �^�C�g���ʈ󎚐���Ή�
                        ReflectColumnVisibleType( ref row, columnVisibleTypeDic, inPageCopyCount );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

                        # endregion

                        table.Rows.Add( row );
                    }

                    // --- ADD ����� 2011/08/15---------->>>>>
                    // �T�u���|�[�g���L��i�T�u���|�[�g�@�\�̏����j
                    if (subReportDic.Count > 0)
                    {
                        break;
                    }
                    // --- ADD ����� 2011/08/15----------<<<<<
                }

                pageStartIndex = Math.Min( pageEndIndex, printEndIndex ) + 1;
                pageEndIndex = pageStartIndex + feedCount - 1;
                printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;
            }
        }

        // --- DEL m.suzuki 2010/03/24 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/30 ADD
        ///// <summary>
        ///// �p�q�R�[�h�f�[�^��������
        ///// </summary>
        ///// <param name="slipWork"></param>
        ///// <param name="detailWorks"></param>
        ///// <param name="pageStartIndex"></param>
        ///// <param name="pageEndIndex"></param>
        ///// <returns></returns>
        //private static string CreateQRData( FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, int pageStartIndex, int pageEndIndex )
        //{
        //    string qrData = string.Empty;

        //    try
        //    {

        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }

        //    return qrData;
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/30 ADD
        // --- DEL m.suzuki 2010/03/24 ----------<<<<<
        /// <summary>
        /// �s�l���̔��菈��
        /// </summary>
        /// <param name="detailWork"></param>
        /// <returns></returns>
        private static bool IsRowDiscount( FrePSalesDetailWork detailWork )
        {
            // ����`�[�敪(����)=2:�l���A���A�o�א����[���Ȃ�΍s�l��
            return ((detailWork.SALESDETAILRF_SALESSLIPCDDTLRF == 2) && (detailWork.SALESDETAILRF_SHIPMENTCNTRF == 0));
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
        /// <summary>
        /// ���ߍs�̔��菈��
        /// </summary>
        /// <param name="detailWork"></param>
        /// <returns></returns>
        private static bool IsCommentRow( FrePSalesDetailWork detailWork )
        {
            // ����`�[�敪(����)=3:���߂Ȃ�Β��ߍs
            return (detailWork.SALESDETAILRF_SALESSLIPCDDTLRF == 3);
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
        /// <summary>
        /// �^�C�g���ʈ󎚐���Ή�
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnVisibleTypeDic"></param>
        private static void ReflectColumnVisibleType( ref DataRow row, Dictionary<string, string> columnVisibleTypeDic, int inPageCopyCount )
        {
            foreach ( DataColumn column in row.Table.Columns )
            {
                string columnName = column.ColumnName.ToUpper();

                if ( columnVisibleTypeDic.ContainsKey( columnName ) )
                {
                    bool visible = false;

                    # region [�^�C�g����Visible�擾]
                    switch ( columnVisibleTypeDic[columnName] )
                    {
                        case "1":
                            if ( inPageCopyCount == 0 ) visible = true; break;
                        case "2":
                            if ( inPageCopyCount == 1 ) visible = true; break;
                        case "3":
                            if ( inPageCopyCount == 2 ) visible = true; break;
                        case "4":
                            if ( inPageCopyCount == 3 ) visible = true; break;
                        case "5":
                            if ( inPageCopyCount == 4 ) visible = true; break;
                        case "6":
                            if ( inPageCopyCount != 0 ) visible = true; break;
                        case "7":
                            if ( inPageCopyCount != 1 ) visible = true; break;
                        case "8":
                            if ( inPageCopyCount != 2 ) visible = true; break;
                        case "9":
                            if ( inPageCopyCount != 3 ) visible = true; break;
                        case "10":
                            if ( inPageCopyCount != 4 ) visible = true; break;
                        case "11":
                            if ( inPageCopyCount == 0 || inPageCopyCount == 1 ) visible = true; break;
                        case "12":
                            if ( inPageCopyCount == 0 || inPageCopyCount == 1 || inPageCopyCount == 2 ) visible = true; break;
                        case "13":
                            if ( inPageCopyCount == 2 || inPageCopyCount == 3 || inPageCopyCount == 4 ) visible = true; break;
                        case "14":
                            if ( inPageCopyCount == 3 || inPageCopyCount == 4 ) visible = true; break;
                        default:
                            visible = true; break;
                    }
                    # endregion

                    // �󎚃L�����Z��
                    if ( visible == false )
                    {
                        row[columnName] = DBNull.Value;
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// ���Ж��̕�������
        /// </summary>
        /// <param name="originName"></param>
        /// <param name="firstHalf"></param>
        /// <param name="lastHalf"></param>
        private static void DivideEnterpriseName( string originName, out string firstHalf, out string lastHalf )
        {
            # region // DEL
            //// ���Ж��̂̍ő咷(byte)
            //const int fullByteCount = 40;
            //// ������̒���(byte)
            //const int halfByteCount = 20;

            //// �X�y�[�X�ŋl�߂�
            //originName = originName.PadRight( fullByteCount, ' ' );
            //// �O�����擾
            //firstHalf = SubStringOfByte( originName, halfByteCount );
            //// �㔼���擾
            //lastHalf = originName.Substring( firstHalf.Length, originName.Length - firstHalf.Length );

            //// ���X�y�[�X�J�b�g
            //firstHalf = firstHalf.TrimEnd();
            //lastHalf = lastHalf.TrimEnd();
            # endregion

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
        ///// <summary>
        ///// ������@�o�C�g���w��؂蔲��
        ///// </summary>
        ///// <param name="encoding">�G���R�[�f�B���O</param>
        ///// <param name="orgString">���̕�����</param>
        ///// <param name="byteCount">�o�C�g��</param>
        ///// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        //private static string SubStringOfByte( string orgString, int byteCount )
        //{
        //    Encoding encoding = Encoding.GetEncoding( "Shift_JIS" ); 

        //    string resultString = string.Empty;

        //    // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
        //    // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
        //    orgString = orgString.PadRight( byteCount ).Substring( 0, byteCount );

        //    int count;

        //    for ( int i = orgString.Length; i >= 0; i-- )
        //    {
        //        // �u�������v�����炷
        //        resultString = orgString.Substring( 0, i );

        //        // �o�C�g�����擾���Ĕ���
        //        count = encoding.GetByteCount( resultString );
        //        if ( count <= byteCount ) break;
        //    }
        //    return resultString;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// �艿�󎚃`�F�b�N�i���ז��ɔ���j
        /// </summary>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="eachSlipTypeSet"></param>
        /// <returns></returns>
        private static bool CheckListPricePrint( FrePSalesDetailWork frePSalesDetailWork, EachSlipTypeSet eachSlipTypeSet )
        {
            switch ( eachSlipTypeSet.ListPrice )
            {
                // 0:�󎚂��Ȃ�
                case 0:
                default:
                    return false;
                // 1:�󎚂���
                case 1:
                    return true;
                // 2:�|�����P
                case 2:
                    {
                        // �P�����艿�̏ꍇ�݈̂󎚂���
                        return (frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF < frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF);
                    }
                    break;
            }
            return false;
        }

        # region [�O���[�v�T�v���X]
        /// <summary>
        /// �O���[�v�T�v���X����
        /// </summary>
        /// <param name="row"></param>
        private static void ReflectSuppressOfCar( ref DataRow row )
        {
            row["ACCEPTODRCARRF.CARMNGNORF"] = DBNull.Value;  // �ԗ��Ǘ��ԍ�
            row["ACCEPTODRCARRF.CARMNGCODERF"] = DBNull.Value;  // ���q�Ǘ��R�[�h
            row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = DBNull.Value;  // ���^�������ԍ�
            row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = DBNull.Value;  // ���^�����ǖ���
            row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = DBNull.Value;  // �ԗ��o�^�ԍ��i��ʁj
            row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = DBNull.Value;  // �ԗ��o�^�ԍ��i�J�i�j
            row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = DBNull.Value;  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = DBNull.Value;  // ���N�x
            row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value;  // ���[�J�[�R�[�h
            row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = DBNull.Value;  // ���[�J�[�S�p����
            row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value;  // �Ԏ�R�[�h
            row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value;  // �Ԏ�T�u�R�[�h
            row["ACCEPTODRCARRF.MODELFULLNAMERF"] = DBNull.Value;  // �Ԏ�S�p����
            row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = DBNull.Value;  // �r�K�X�L��
            row["ACCEPTODRCARRF.SERIESMODELRF"] = DBNull.Value;  // �V���[�Y�^��
            row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = DBNull.Value;  // �^���i�ޕʋL���j
            row["ACCEPTODRCARRF.FULLMODELRF"] = DBNull.Value;  // �^���i�t���^�j
            row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value;  // �^���w��ԍ�
            row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value;  // �ޕʔԍ�
            row["ACCEPTODRCARRF.FRAMEMODELRF"] = DBNull.Value;  // �ԑ�^��
            row["ACCEPTODRCARRF.FRAMENORF"] = DBNull.Value;  // �ԑ�ԍ�
            row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = DBNull.Value;  // �ԑ�ԍ��i�����p�j
            row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = DBNull.Value;  // �G���W���^������
            row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = DBNull.Value;  // �֘A�^��
            row["ACCEPTODRCARRF.SUBCARNMCDRF"] = DBNull.Value;  // �T�u�Ԗ��R�[�h
            row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = DBNull.Value;  // �^���O���[�h����
            row["ACCEPTODRCARRF.COLORCODERF"] = DBNull.Value;  // �J���[�R�[�h
            row["ACCEPTODRCARRF.COLORNAME1RF"] = DBNull.Value;  // �J���[����1
            row["ACCEPTODRCARRF.TRIMCODERF"] = DBNull.Value;  // �g�����R�[�h
            row["ACCEPTODRCARRF.TRIMNAMERF"] = DBNull.Value;  // �g��������
            row["ACCEPTODRCARRF.MILEAGERF"] = DBNull.Value;  // �ԗ����s����
            row["ACCEPTODRCARRF.MAKERHALFNAMERF"] = DBNull.Value; // ���[�J�[���p����
            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = DBNull.Value; // �Ԏ피�p����
            row["DADD.FIRSTENTRYDATEFYRF"] = DBNull.Value; // ���N�x����N
            row["DADD.FIRSTENTRYDATEFSRF"] = DBNull.Value; // ���N�x����N��
            row["DADD.FIRSTENTRYDATEFWRF"] = DBNull.Value; // ���N�x�a��N
            row["DADD.FIRSTENTRYDATEFMRF"] = DBNull.Value; // ���N�x��
            row["DADD.FIRSTENTRYDATEFGRF"] = DBNull.Value; // ���N�x����
            row["DADD.FIRSTENTRYDATEFRRF"] = DBNull.Value; // ���N�x����
            row["DADD.FIRSTENTRYDATEFLSRF"] = DBNull.Value; // ���N�x���e����(/)
            row["DADD.FIRSTENTRYDATEFLPRF"] = DBNull.Value; // ���N�x���e����(.)
            row["DADD.FIRSTENTRYDATEFLYRF"] = DBNull.Value; // ���N�x���e����(�N)
            row["DADD.FIRSTENTRYDATEFLMRF"] = DBNull.Value; // ���N�x���e����(��)
        }
        # endregion

        # region [���t�֘A���� �W�J����]
        /// <summary>
        /// ���t�֘A���ځ@�W�J
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd"></param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
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
        ///// <summary>
        ///// ���t�֘A���ځ@�W�J
        ///// </summary>
        ///// <param name="targetRow"></param>
        ///// <param name="eraNameDispCd">0:����@1:�a��</param>
        ///// <param name="date"></param>
        ///// <param name="dateColumnName"></param>
        ///// <param name="isMonth"></param>
        //private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth )
        //{
        //    // �a��t���O
        //    bool jpEra = (eraNameDispCd == 1);

        //    if ( date != 0 )
        //    {
        //        // �N�����ڂ̏ꍇ�́A�a��ϊ��ɔ����Ďw��N���̍ŏI���ɕϊ�����
        //        if ( isMonth )
        //        {
        //            // �w��N���̓��������߂�(=���̌��̍ŏI��)
        //            int dd = DateTime.DaysInMonth( date / 100, date % 100 );

        //            // YYYYMMDD�ɂ���
        //            date = (date * 100) + dd;
        //        }

        //        // �N�i�a��or����j
        //        if ( jpEra )
        //        {
        //            // �a��
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = GetDateFW( date ); // �a��N
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = TDateTime.LongDateToString( "GG", date ); // �a���
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = TDateTime.LongDateToString( "gg", date ); // �a�������
        //            // �N���A
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
        //        }
        //        else
        //        {
        //            // ����
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = (date / 10000); // ����N
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = (date / 10000) % 100; // ����N(��)
        //            // �N���A
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
        //        }

        //        // ��
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = (date / 100) % 100; // ��

        //        // ���e�����n
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = "/";
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = ".";
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = "�N";
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = "��";

        //        if ( !isMonth )
        //        {
        //            // �N�����̏ꍇ�̂݃Z�b�g
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = (date % 100); // ��
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = "��";
        //        }
        //    }
        //    else
        //    {
        //        // �����ȓ��t�Ȃ�΋�
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = DBNull.Value;

        //        if ( !isMonth )
        //        {
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = DBNull.Value;
        //        }
        //    }
        //}
        /// <summary>
        /// ���t�֘A���ځ@�W�J
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd">0:����@1:�a��</param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
        /// <remarks>
        /// <br>Update Note: 2012/02/07 �����H</br>
        /// <br>�Ǘ��ԍ�   �F10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28291�@�������F�󎚎��G���[�ɂ��Ă̏C��</br>
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //bool jpEra = (eraNameDispCd == 1);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            bool jpEra;
            if ( !ReportItemDic.ContainsKey( string.Format( "{0}{1}RF", dateColumnName, "FW" ) ) )
            {
                // "�a��N"���ڂ�����������Œ�
                jpEra = false;
            }
            else if ( !ReportItemDic.ContainsKey( string.Format( "{0}{1}RF", dateColumnName, "FY" ) ) &&
                      !ReportItemDic.ContainsKey( string.Format( "{0}{1}RF", dateColumnName, "FS" ) ) )
            {
                // "����N"�E"����N��"���ڂ������������a��Œ�
                jpEra = true;
            }
            else
            {
                // �ʏ�͋敪�l�ɏ]��
                jpEra = (eraNameDispCd == 1);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
            // �N�̂ݔ���t���O
            bool isYear = false;

            //ADD 2012/02/07 �����H REDMINE#28291----->>>>>
            bool emptyYear = false;
            if (isMonth)//yyyymm
            {
                if ((date / 100) == 0 && (date % 100) != 0)
                    emptyYear = true;
            }
            //ADD 2012/02/07 �����H REDMINE#28291-----<<<<<

            //if ( date != 0 )  //DEL 2012/02/07 �����H REDMINE#28291
            if (date != 0 && !emptyYear)   //ADD 2012/02/07 �����H REDMINE#28291
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
                        date = ((int)(date / 100) * 10000) + (12 * 100) + dd;
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
        /// <param name="date"></param>
        /// <returns></returns>
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
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// ���ב��s���̎Z�o
        /// </summary>
        /// <param name="dataCount"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetAllDetailCount( int dataCount, int feedCount )
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
        /// <summary>
        /// ���݃y�[�W���擾
        /// </summary>
        /// <param name="index"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetPageCount( int index, int feedCount )
        {
            return (index / feedCount) + 1;
        }
        # endregion

        # region [���ʃ^�C�g���擾����]
        /// <summary>
        /// ���ʃ^�C�g���擾����
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        private static List<List<string>> GetInPageCopyTitles( SlipPrtSetWork slipPrtSet )
        {
            //*********************************************************************
            // ���ʂP���ڂ̃^�C�g�����ɂ���āA1�y�[�W���̃R�s�[�������肷��ׁA
            // �P���ڂ̂� string.Empty �̔�����s���܂��B
            // 
            // �Q���ڈȍ~�͂P�y�[�W���R�s�[���ւ̉e���������̂ŁA���̂܂ܑS�ăZ�b�g���܂��B
            //*********************************************************************

            List<List<string>> retList = new List<List<string>>();
            List<string> retList1 = new List<string>();

            //----------------------------------------------
            // ���ʂP���ڂ̃^�C�g���Q
            //----------------------------------------------
            retList1.Add( slipPrtSet.TitleName1 );
            List<string> title1List = new List<string>( new string[] { slipPrtSet.TitleName102, slipPrtSet.TitleName103, slipPrtSet.TitleName104, slipPrtSet.TitleName105 } );
            for ( int index = 0; index < title1List.Count; index++ )
            {
                // �󔒂�����΂����ŏI��
                if ( title1List[index] == string.Empty ) break;
                // �P�ǉ�
                retList1.Add( title1List[index] );
            }
            retList.Add( retList1 );

            //----------------------------------------------
            // ���ʂQ���ڈȍ~�̓x�^�ŃR�s�[����
            //----------------------------------------------
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName2, slipPrtSet.TitleName202, slipPrtSet.TitleName203, slipPrtSet.TitleName204, slipPrtSet.TitleName205 } ) );
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName3, slipPrtSet.TitleName302, slipPrtSet.TitleName303, slipPrtSet.TitleName304, slipPrtSet.TitleName305 } ) );
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName4, slipPrtSet.TitleName402, slipPrtSet.TitleName403, slipPrtSet.TitleName404, slipPrtSet.TitleName405 } ) );

            // �ԋp
            return retList;
        }
        # endregion

        # region [����f�[�^���擾]
        /// <summary>
        /// �`�[�]�ŕ����擾
        /// </summary>
        /// <param name="table"></param>
        public static int GetSALESSLIPRF_CONSTAXLAYMETHODRF( DataTable table )
        {
            try
            {
                // ����œ]�ŕ����i0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ېŁj
                return (int)table.Rows[0]["SALESSLIPRF.CONSTAXLAYMETHODRF"];
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// �󒍃X�e�[�^�X�擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static int GetSALESSLIPRF_ACPTANODRSTATUSRF( DataTable table )
        {
            try
            {
                // �󒍃X�e�[�^�X
                return (int)table.Rows[0]["SALESSLIPRF.ACPTANODRSTATUSRF"];
            }
            catch
            {
                return 0;
            }
        }

        // --- ADD ���痈  2009.07.27 ---------->>>>>
        /// <summary>
        /// ����`�[���v�i�Ŕ����j�擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Double GetHADD_SALESTOTALTAXEXCNOMINUSRF( DataTable table )
        {
            try
            {
                // ����`�[���v�i�Ŕ����j
                return (Double)table.Rows[0]["HADD.SALESTOTALTAXEXCWITHMINUSRF"];
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// AB�{���������z���v  �擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Double GetHADD_ABHQTOTALCOSTNOMINUSRF( DataTable table )
        {
            try
            {
                // AB�{���������z���v
                return (Double)table.Rows[0]["HADD.ABHQTOTALCOSTWITHMINUSRF"];
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD ���痈�@2009.07.27 ----------<<<<<        
        // --- ADD  ���r��  2009/10/27 ---------->>>>>
        /// <summary>
        /// �󒍎҃R�[�h�@�擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetSALESSLIPRF_FRONTEMPLOYEECDRF(DataTable table)
        {
            try
            {
                // �󒍎҃R�[�h
                return (string)table.Rows[0]["SALESSLIPRF.FRONTEMPLOYEECDRF"];
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ���s�҃R�[�h�@�擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetSALESSLIPRF_SALESINPUTCODERF(DataTable table)
        {
            try
            {
                // ���s�҃R�[�h
                return (string)table.Rows[0]["SALESSLIPRF.SALESINPUTCODERF"];
            }
            catch
            {
                return string.Empty;
            }
        }
        // --- ADD  ���r��  2009/10/27 ----------<<<<<
        // --- ADD  ���r��  2009/11/02 ---------->>>>>
        /// <summary>
        /// �ԑ�ԍ��@�擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetHADD_FRAMENORF(DataTable table)
        {
            try
            {
                // �ԑ�ԍ�
                return (string)table.Rows[0]["HADD.FRAMENORF"];
            }
            catch
            {
                return string.Empty;
            }
        }
        // --- ADD  ���r��  2009/11/02 ----------<<<<<
        // --- ADD  ���r��  2009/12/03 ---------->>>>>
        /// <summary>
        /// (�擪)�ԗ��Ǘ��R�[�h�@�擾
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetHADD_CARMNGCODERF(DataTable table)
        {
            try
            {
                // (�擪)�ԗ��Ǘ��R�[�h
                return (string)table.Rows[0]["HADD.CARMNGCODERF"];
            }
            catch
            {
                return string.Empty;
            }
        }
        // --- ADD  ���r��  2009/12/03 ----------<<<<<
        # endregion

        # region [�f�[�^�[������]
        /// <summary>
        /// ������R�[�h�̃[������
        /// </summary>
        /// <param name="textValue"></param>
        /// <returns></returns>
        // --- UPD  ���r��  2009/10/27 ---------->>>>>
        //private static bool IsZero( string textValue )
        public static bool IsZero(string textValue)
        // --- UPD  ���r��  2009/10/27 ----------<<<<<
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
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static bool IsZero(int intValue)
        {
            return (intValue == 0);
        }
        # endregion

        # region [�c�{�p�Ή����X�g]
        /// <summary>
        /// �c�{�p�Ή����X�g�擾����
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDoubleHeightTargetList()
        {
            List<string> list = new List<string>();

            list.Add( "HLG.CUSTOMERNAMERF" );  // �y�c�{�z���Ӑ於��
            list.Add( "HLG.CUSTOMERNAME2RF" );  //�y�c�{�z ���Ӑ於��2
            list.Add( "HLG.CUSTOMERSNMRF" );  // �y�c�{�z���Ӑ旪��
            list.Add( "HLG.HONORIFICTITLERF" );  // �y�c�{�z�h��
            list.Add( "HLG.PRINTCUSTOMERNAMEJOIN12RF" ); //�y�c�{�z���Ӑ於�P�{���Ӑ於�Q
            list.Add( "HLG.PRINTCUSTOMERNAMEJOIN12HNRF" ); // �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/07/02 ADD
            list.Add( "HLG.COMPANYNAME1RF" ); // �y�c�{�z���Ж���1
            list.Add( "HLG.COMPANYNAME2RF" ); // �y�c�{�z���Ж���2
            list.Add( "HLG.PRINTENTERPRISENAME1FHRF" ); // �y�c�{�z���Ж��P�i�O���j
            list.Add( "HLG.PRINTENTERPRISENAME1LHRF" ); // �y�c�{�z���Ж��P�i�㔼�j
            list.Add( "HLG.PRINTENTERPRISENAME2FHRF" ); // �y�c�{�z���Ж��Q�i�O���j
            list.Add( "HLG.PRINTENTERPRISENAME2LHRF" ); // �y�c�{�z���Ж��Q�i�㔼�j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/07/02 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.03 ADD
            list.Add( "HLG.PRINTCUSTOMERNAME1RF" );  // �i�c�{�j����p���Ӑ於�́i��i�j
            list.Add( "HLG.PRINTCUSTOMERNAME2RF" );  // �i�c�{�j����p���Ӑ於�́i���i�j
            list.Add( "HLG.PRINTCUSTOMERNAME2HNRF" );  // �i�c�{�j����p���Ӑ於�́i���i�j�{�h��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.03 ADD
            // --- ADD  ���r��  2010/03/19 ---------->>>>>
            list.Add("HLG.PRINTCUSTOMERNAMEJOIN12CSTRF"); //  (�c�{) ���Ӑ於�P�{���Ӑ於�Q(���Ӑ�}�X�^�Q��)
            // --- ADD  ���r��  2010/03/19 ----------<<<<<
            // --- ADD  ���r��  2010/06/03 ---------->>>>>
            list.Add("HLG.CUSTNOTE1RF");//�@�y�c�{�z���Ӑ���l
            list.Add("HLG.CUSTOMERNAMECSTRF");//  �y�c�{�z���Ӑ於�P(���Ӑ�}�X�^�Q��)
            list.Add("HLG.CUSTOMERNAME2CSTRF");//  �y�c�{�z���Ӑ於�Q(���Ӑ�}�X�^�Q��)
            // --- ADD  ���r��  2010/06/03 ----------<<<<<
            // --- ADD  ���r��  2010/06/29 ---------->>>>>
            list.Add("HLG.CUSTOMERNAME2HNRF");//  �y�c�{�z���Ӑ於�Q�{�h��
            list.Add("HLG.PRINTCSTNAMEJOIN12HN1RF");//  �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
            list.Add("HLG.PRINTCSTNAMEJOIN12HN2RF");//  �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
            list.Add("HLG.PRINTCSTNAMEJOIN12HN3RF");//  �y�c�{�z���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
            // --- ADD  ���r��  2010/06/29 ----------<<<<<

            return list;
        }
        # endregion

        # endregion

        # region [�O���[�v�T�v���X�L�[]
        /// <summary>
        /// �O���[�v�T�v���X�L�[
        /// </summary>
        private struct GroupSuppressKey : IComparable<GroupSuppressKey>
        {
            /// <summary>�y�[�W��</summary>
            private int _page;
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
            /// <param name="fullModel">�^��</param>
            /// <param name="modelFullName">�Ԏ�</param>
            /// <param name="firstEntryDate">�N��</param>
            public GroupSuppressKey( int page, string fullModel, string modelFullName, int firstEntryDate )
            {
                _page = page;
                _fullModel = fullModel;
                _modelFullName = modelFullName;
                _firstEntryDate = firstEntryDate;
            }
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public int CompareTo( GroupSuppressKey other )
            {
                int result;

                result = this.Page.CompareTo( other.Page );
                if ( result != 0 ) return result;

                result = this.FullModel.CompareTo( other.FullModel );
                if ( result != 0 ) return result;

                result = this.ModelFullName.CompareTo( other.ModelFullName );
                if ( result != 0 ) return result;

                result = this.FirstEntryDate.CompareTo( other.FirstEntryDate );

                return result;
            }
            /// <summary>
            /// �������ς݃C���X�^���X�擾
            /// </summary>
            /// <returns></returns>
            public static GroupSuppressKey Create()
            {
                GroupSuppressKey key = new GroupSuppressKey();
                key.Page = 0;
                key.FullModel = string.Empty;
                key.ModelFullName = string.Empty;
                key.FirstEntryDate = 0;
                return key;
            }
            /// <summary>
            /// ���q���L�[
            /// </summary>
            /// <param name="row"></param>
            /// <returns></returns>
            public static GroupSuppressKey CreateKeyOfCar( DataRow row )
            {
                GroupSuppressKey key = Create();
                // �y�[�W��
                if ( row[ct_PageCount] != DBNull.Value )
                {
                    key.Page = (int)row[ct_PageCount];
                }
                else
                {
                    key.Page = 0;
                }
                // �^��
                if ( row["ACCEPTODRCARRF.FULLMODELRF"] != DBNull.Value )
                {
                    key.FullModel = (string)row["ACCEPTODRCARRF.FULLMODELRF"];
                }
                else
                {
                    key.FullModel = string.Empty;
                }
                // �Ԏ햼
                if ( row["ACCEPTODRCARRF.MODELFULLNAMERF"] != DBNull.Value )
                {
                    key.ModelFullName = (string)row["ACCEPTODRCARRF.MODELFULLNAMERF"];
                }
                else
                {
                    key.ModelFullName = string.Empty;
                }
                // �N��
                if ( row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] != DBNull.Value )
                {
                    key.FirstEntryDate = (int)row["ACCEPTODRCARRF.FIRSTENTRYDATERF"];
                }
                else
                {
                    key.FirstEntryDate = 0;
                }
                return key;
            }
        }
        # endregion

        # region [�e��敪���̎擾]
        /// <summary>
        /// �󒍃X�e�[�^�X����
        /// </summary>
        /// <param name="acptAnOdrSt"></param>
        /// <param name="salesSlipCd"></param>
        /// <returns></returns>
        private static string GetHADD_ACPTANODRSTNMRF( int acptAnOdrSt, int salesSlipCd )
        {
            // 10:����,20:��,30:����,40:�o��
            switch ( acptAnOdrSt )
            {
                case 10:
                    return "����";
                case 20:
                    return "��";
                case 30:
                    if ( salesSlipCd == 0 )
                    {
                        return "����";
                    }
                    else
                    {
                        return "�ԕi";
                    }
                case 40:
                    return "�ݏo";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �ԓ`�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_DEBITNOTEDIVNMRF( int code )
        {
            // 0:���`,1:�ԓ`,2:����
            switch ( code )
            {
                case 0:
                    return "���`";
                case 1:
                    return "�ԓ`";
                case 2:
                    return "����";
                default:
                    return string.Empty;
            }
        }
        ///// <summary>
        ///// ����`�[�敪����
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //private static string GetHADD_SALESSLIPNMRF( int code )
        //{
        //    // 0:����,1:�ԕi
        //    switch ( code )
        //    {
        //        case 0:
        //            return "����";
        //        case 1:
        //            return "�ԕi";
        //        default:
        //            return string.Empty;
        //    }
        //}
        /// <summary>
        /// ���㏤�i�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_SALESGOODSNMRF( int code )
        {
            // 0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)
            switch ( code )
            {
                case 0:
                    return "���i";
                case 1:
                    return "���i�O";
                case 2:
                    return "����Œ���";
                case 3:
                    return "�c������";
                case 4:
                    return "���|�p����Œ���";
                case 5:
                    return "���|�p�c������";
                case 10:
                    return "���|�p����Œ���(����)";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ���|�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_ACCRECDIVNMRF( int code )
        {
            // 0:���|�Ȃ�,1:���|
            switch ( code )
            {
                case 0:
                    return "���|�Ȃ�";
                case 1:
                    return "���|";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �����敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_DELAYPAYMENTDIVNMRF( int code )
        {
            // 0:����(�����Ȃ�),1:����,2:�ė����c9:9������
            switch ( code )
            {
                case 0:
                    return "����";
                case 1:
                    return "����";
                case 2:
                    return "�ė���";
                default:
                    return string.Format( "{0}������", code );
            }
        }
        /// <summary>
        /// ���ϋ敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_ESTIMATEDIVIDENMRF( int hADD_ESTIMATEDIVIDENMRF )
        {
            // 1:�ʏ팩�ρ@2:�P������
            switch ( hADD_ESTIMATEDIVIDENMRF )
            {
                case 1:
                    return "�ʏ팩��";
                case 2:
                    return "�P������";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ����œ]�ŕ�������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_CONSTAXLAYMETHODNMRF( int code )
        {
            // 0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�
            switch ( code )
            {
                case 0:
                    return "�`�[�P��";
                case 1:
                    return "���גP��";
                case 2:
                    return "����(�e)";
                case 3:
                    return "����(�q)";
                case 9:
                    return "��ې�";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ���������敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_AUTODEPOSITNMRF( int code )
        {
            // 0:�ʏ����,1:��������
            switch ( code )
            {
                case 0:
                    return "�ʏ����";
                case 1:
                    return "��������";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �`�[���s�ϋ敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_SLIPPRINTFINISHNMRF( int code )
        {
            // 0:�����s 1:���s��
            switch ( code )
            {
                case 0:
                    return "�����s";
                case 1:
                    return "���s��";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �ꎮ�`�[�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_COMPLETENMRF( int code )
        {
            // 0:�ʏ�`�[,1:�ꎮ�`�[
            switch ( code )
            {
                case 0:
                    return "�ʏ�`�[";
                case 1:
                    return "�ꎮ�`�[";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �݌ɊǗ��L���敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_STOCKMNGEXISTNMRF( int code )
        {
            // 0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����
            switch ( code )
            {
                case 0:
                    return "";
                case 1:
                    return "�݌ɊǗ�";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ���i��������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_GOODSKINDNAMERF( int code )
        {
            // 0:���� 1:�D��
            switch ( code )
            {
                case 0:
                    return "����";
                case 1:
                    return "�D��";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ����݌Ɏ�񂹋敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_SALESORDERDIVNMRF( int code )
        {
            // 0:��񂹁C1:�݌�
            switch ( code )
            {
                case 0:
                    return "���";
                case 1:
                    return "�݌�";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �I�[�v�����i�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_OPENPRICEDIVNMRF( int code )
        {
            // 0:�ʏ�^1:�I�[�v�����i
            switch ( code )
            {
                case 0:
                    return "";
                case 1:
                    return "�I�[�v�����i";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �e���`�F�b�N�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_GRSPROFITCHKDIVNMRF( int code )
        {
            // 0:����,1:��������,2:���v�̏グ�߂�
            switch ( code )
            {
                case 0:
                    return "����";
                case 1:
                    return "";
                case 2:
                    return "";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ���㏤�i�敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_SALESGOODSNMRF( int code )
        {
            // 0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)
            switch ( code )
            {
                case 0:
                    return "���i";
                case 1:
                    return "���i�O";
                case 2:
                    return "����Œ���";
                case 3:
                    return "�c������";
                case 4:
                    return "���|�p����Œ���";
                case 5:
                    return "���|�p�c������";
                case 10:
                    return "���|�p����Œ���(����)";
                case 11:
                    return "���E";
                case 12:
                    return "���E(����)";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �ېŋ敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_TAXATIONDIVNMRF( int code )
        {
            // 0:�ې�,1:��ې�,2:�ېŁi���Łj
            switch ( code )
            {
                case 0:
                    return "�O��";
                case 1:
                    return "��ې�";
                case 2:
                    return "����";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �����敪
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_PURECODENMRF( int code )
        {
            // 0:�����A1:�D��
            switch ( code )
            {
                case 0:
                    return "����";
                case 1:
                    return "�D��";
                default:
                    return string.Empty;
            }
        }

        // --- ADD ���痈  2009.07.27 ---------->>>>>
        /// <summary>
        /// �����敪�擾
        /// </summary>
        /// <param name="detailWork">���׏��</param>
        /// <param name="slipWork">������</param>
        /// <returns>����</returns>
        private static int GetGoodsKindCode( FrePSalesDetailWork detailWork, FrePSalesSlipWork slipWork )
        {
            int goodsKindCode = 0;

            // ���㖾�׃f�[�^�̏��i���[�J�[�R�[�h(GoodsMakerCdRF)���u1�`99�v�̏ꍇ�A�u1�v���Z�b�g����
            if ( 1 <= detailWork.SALESDETAILRF_GOODSMAKERCDRF && 99 >= detailWork.SALESDETAILRF_GOODSMAKERCDRF )
            {
                goodsKindCode = 1;
            }
            else if ( detailWork.SALESDETAILRF_GOODSMAKERCDRF > 100 )
            {
                // ���i���[�J�[�R�[�h�ǉ�
                ArrayList goodsMakerCdList = new ArrayList();
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD1 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD2 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD3 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD4 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD5 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD6 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD7 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD8 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD9 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD10 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD11 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD12 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD13 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD14 );
                goodsMakerCdList.Add( slipWork.SANDESETTINGRF_GOODSMAKERCD15 );

                // �f�[�^��r
                bool isExistFlg = false;
                foreach ( int goodsMakserCd in goodsMakerCdList )
                {
                    if ( detailWork.SALESDETAILRF_GOODSMAKERCDRF == goodsMakserCd )
                    {
                        isExistFlg = true;
                        break;
                    }
                }

                if ( isExistFlg )
                {
                    goodsKindCode = 1;
                }
                else
                {
                    goodsKindCode = 2;
                }
            }
            else if ( detailWork.SALESDETAILRF_GOODSMAKERCDRF == 0 )
            {
                goodsKindCode = 2;
            }

            return goodsKindCode;
        }

        /// <summary>
        /// AB�{�������擾
        /// </summary>
        /// <param name="detailWork">���׏��</param>
        /// <param name="slipWork">������</param>
        /// <returns>����</returns>
        private static long GetABHqSalesUnitCost( FrePSalesDetailWork detailWork, FrePSalesSlipWork slipWork )
        {
            long salesUnitCos = 0;
            double result = 0.0;

            // �����敪�擾
            int goodsKindCode = GetGoodsKindCode( detailWork, slipWork );
            // ���i���d�ؗ�
            if ( goodsKindCode == 1 )
            {
                result = slipWork.SANDESETTINGRF_PURETRADCOMPRATE;
            }
            else
            {
                result = slipWork.SANDESETTINGRF_PRITRADCOMPRATE;
            }
            result = detailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF * result / 100;
            // �[������
            FractionCalculate.FracCalcMoney( result, 1, 2, out salesUnitCos );

            return salesUnitCos;
        }
        // --- ADD ���痈�@2009.07.27 ----------<<<<<

        // --- ADD  ���r��  2010/06/24 ---------->>>>>
        /// <summary>
        /// �S�p�˔��p�ϊ�
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private static string GetKanaString(string orgString)
        {
            // �S�p�˔��p�ϊ��i�r���Ɋ܂܂��ϊ��ł��Ȃ������͂��̂܂܁j
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }
        // --- ADD  ���r��  2010/06/24 ----------<<<<<
        # endregion

        // --- ADD  ���r��  2010/05/13 ---------->>>>>
        #region[�e���z(����)�̌v�Z]
        /// <summary>
        /// �e���z(����)���v�Z
        /// </summary>
        /// <param name="salesMoney">������z</param>
        /// <param name="salesSunitCost">�����P��</param>
        /// <param name="slipmentCnt">�o�א�</param>
        /// <returns></returns>
        private static Int64 GetGrossProfit(decimal salesMoney, decimal salesSunitCost, decimal slipmentCnt)
        {
            decimal grossProfit = salesMoney - salesSunitCost * slipmentCnt;
            //�؂�̂�
            return (Int64)grossProfit;
        }
        #endregion
        // --- ADD  ���r��  2010/05/13 ----------<<<<<

        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        # region [�p�q�R�[�h�T�C�YDictionary�擾]
        /// <summary>
        /// �p�q�R�[�h�T�C�YDictionary�擾
        /// </summary>
        /// <param name="table"></param>
        /// <param name="feedCount"></param>
        public static Dictionary<string,float> GetQRCodeSizeDictionary( DataTable table, int feedCount )
        {
            // --- UPD m.suzuki 2010/03/31 ---------->>>>>
            //int maxByteCount = 7 + 46 + (105 * feedCount); //4����:473, 6����:683
            int maxByteCount = 7 + 47 + (105 * feedCount); //4����:474, 6����:684
            // --- UPD m.suzuki 2010/03/31 ----------<<<<<

            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add( ct_QRCode, SalesQRDataCreateMediator.GetQRCodeSizeRate( (string)table.Rows[0][ct_QRCodeSource], maxByteCount ) );

            return dic;
        }
        # endregion
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        // --- ADD  ���r��  2010/06/29 ---------->>>>>
        # region [������o�C�g���擾]
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
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
        // --- ADD  ���r��  2010/06/29 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        # region [�c�{�p���ڕW�����ڐݒ�]
        /// <summary>
        /// �c�{�p���ڕW�����ڐݒ�
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnVisibleTypeDic"></param>
        /// <param name="target1"></param>
        /// <param name="target2"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �c�{�p���ڕW�����ڐݒ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/02/16</br>
        /// </remarks>
        protected static void SettingKmk(DataRow row, Dictionary<string, string> columnVisibleTypeDic, string target1, string target2)
        {
            if (columnVisibleTypeDic.ContainsKey(target1))
            {
                row[target2] = DBNull.Value;
            }
            else if (columnVisibleTypeDic.ContainsKey(target2))
            {
                row[target1] = DBNull.Value;
            }
            else
            {
                row[target1] = DBNull.Value;
                row[target2] = DBNull.Value;
            }   
        }
        #endregion
        // --- ADD  2011/02/16 ----------<<<<<
    }

    // --- ADD  ���r��  2010/03/01 ---------->>>>>
    #region[���z�E����ł��v�Z]
    /// <summary>
    /// ���z�Ə���ł��v�Z
    /// </summary>
    internal class PriceTaxCalculator
    {
        /// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        internal const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        internal const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;


        private TaxRateSetWork _taxRateSetWork;
        private List<SalesProcMoneyWork> _salesProcMoneyWorkList;

        private double _taxRate = 0;

        /// <summary>
        /// �ŗ��ݒ�
        /// </summary>
        public TaxRateSetWork TaxRateSet
        {
            get { return _taxRateSetWork; }
            set { _taxRateSetWork = value; }
        }
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
            _taxRateSetWork = new TaxRateSetWork();
            _salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
        }

        /// <summary>
        /// ���z�̒[���������s��        
        /// </summary>
        /// <param name="unfracPrice">���z</param>
        /// <param name="fracProcCode">�[�������敪</param>
        /// <returns></returns>
        public Int64 FractionProc(decimal unfracPrice, int fracProcCode)
        {
            long resultMoney = 0;
            //List<SalesProcMoneyWork> fractionPrice = new List<SalesProcMoneyWork>();            
            int listPriceFrocProcCd = 0;
            double listPriceFrocProcUnit = 0;
            //�[�������P�ʁA�[�������敪�擾
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_SalesMoney, fracProcCode ,(double)unfracPrice, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                  
            //�[������
            FractionCalculate.FracCalcMoney((double)unfracPrice, listPriceFrocProcUnit, listPriceFrocProcCd, out resultMoney);                        
            
            return resultMoney;
        }
        /// <summary>
        /// ����ł��v�Z�A�[���������s��
        /// </summary>
        /// <param name="targetPrice">���z</param>
        /// <param name="salesSlipDate">�`�[���s���t</param>
        /// <param name="fracProcCode">�[�������敪</param>
        /// <returns></returns>
        public Int64 GetTax(Int64 targetPrice, DateTime salesSlipDate, int fracProcCode)
        {
            long tax = 0;
            double taxRate = 0;
            int listPriceTaxFrocProcCd = 0;
            double listPriceTaxFrocProcUnit = 0;

            //�ŗ��擾
            taxRate = GetTaxRate(salesSlipDate);
            
            //�[�������P�ʁA�[�������敪�擾    
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, fracProcCode, targetPrice, out listPriceTaxFrocProcUnit, out listPriceTaxFrocProcCd);
            
            //����Ōv�Z�A�[������
            FractionCalculate.FracCalcMoney(targetPrice * taxRate, listPriceTaxFrocProcUnit, listPriceTaxFrocProcCd, out tax);
            
            return tax;
        }
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------            

            switch (fracProcMoneyDiv)
            {
                   
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��                
                //case _frePSalesSlipWork.SalesUnPrcFrcProcCd:
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
            //List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
            //    delegate( SalesProcMoney sProcMoney )
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
        /// <summary>
        /// �ŗ��擾����
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        public double GetTaxRate(DateTime addUpADate)
        {
            //if (_taxRateSet == null)
            if (_taxRateSetWork == null)
            {
                //this._taxRate = 0;
                this._taxRate = 0;
            }
            else
            {
                //this._taxRate = 0;


                if ((addUpADate >= _taxRateSetWork.TaxRateStartDate) &&
                    (addUpADate <= _taxRateSetWork.TaxRateEndDate))
                {
                    this._taxRate = _taxRateSetWork.TaxRate;
                }
                else if ((addUpADate >= _taxRateSetWork.TaxRateStartDate2) &&
                         (addUpADate <= _taxRateSetWork.TaxRateEndDate2))
                {
                    this._taxRate = _taxRateSetWork.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSetWork.TaxRateStartDate3) &&
                        (addUpADate <= _taxRateSetWork.TaxRateEndDate3))
                {
                    this._taxRate = _taxRateSetWork.TaxRate3;
                }
            }
            return this._taxRate;
        }

    }
    #endregion
    // --- ADD  ���r��  2010/03/01 ----------<<<<<

    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
    # region [�p�q�f�[�^��������N���X]
    /// <summary>
    /// �p�q�f�[�^��������N���X
    /// </summary>
    internal class SalesQRDataCreateMediator : QRDataCreateMediator
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="paraWork"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorkList"></param>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public static void CreateData( string enterpriseCode, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorkList, out string csvData, out string qrData )
        {
            StringBuilder data = new StringBuilder();

            //-------------------------------------------------------
            // �w�b�_
            //-------------------------------------------------------

            // �o�l���[�U�[�R�[�h
            data.Append( string.Format( "\"{0}\"", GetUserCode( enterpriseCode ) ) );

            // �Ɩ��敪(1:�o�l)
            AppendTo( ref data, 1 );

            // �`�[�敪(0:����,1:�ԕi)
            int countSign;
            if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
            {
                AppendTo( ref data, 0 ); // ����
                countSign = 1;
            }
            else
            {
                AppendTo( ref data, 1 ); // �ԕi
                countSign = -1;
            }

            // --- UPD m.suzuki 2010/03/31 ---------->>>>>
            //// �`�[�ԍ�(��8��)
            //AppendTo( ref data, ToInt( GetRight( slipWork.SALESSLIPRF_SALESSLIPNUMRF, 8 ) ) );
            // �`�[�ԍ�(9��)
            AppendTo( ref data, ToInt( GetRight( slipWork.SALESSLIPRF_SALESSLIPNUMRF, 9 ) ) );
            // --- UPD m.suzuki 2010/03/31 ----------<<<<<


            if ( detailWorkList.Count > 0 )
            {
                // �Ԏ탁�[�J�[�R�[�h
                AppendTo( ref data, detailWorkList[0].ACCEPTODRCARRF_MAKERCODERF );
                // �Ԏ햼(���p)
                AppendTo( ref data, SubStringOfByte( detailWorkList[0].ACCEPTODRCARRF_MODELHALFNAMERF, 20 ) );
            }
            else
            {
                // �Ԏ탁�[�J�[�R�[�h
                AppendTo( ref data, 0 );
                // �Ԏ햼(���p)
                AppendTo( ref data, string.Empty );
            }

            //-------------------------------------------------------
            // ����
            //-------------------------------------------------------
            for ( int index = 0; (index < detailWorkList.Count) && (index < 6); index++ )
            {
                FrePSalesDetailWork detailWork = detailWorkList[index];

                // �捞�敪
                switch ( detailWork.SALESDETAILRF_SALESSLIPCDDTLRF )
                {
                    default:
                        // �ʏ��0:�捞��
                        AppendTo( ref data, 0 );
                        break;
                    case 2:
                        // 2:�s�l��/���i�l���ˎ捞�敪��"1:�s��"�Ƃ���
                        AppendTo( ref data, 1 );
                        break;
                    case 3:
                        // 3:���߁ˏ��O���Ď����ׂ�
                        continue;
                }

                // �i��
                AppendTo( ref data, SubStringOfByte( detailWork.SALESDETAILRF_PRTGOODSNORF, 24 ) );

                // �i��
                if ( detailWork.SALESDETAILRF_GOODSNAMEKANARF.Trim() != string.Empty )
                {
                    // �i���J�i�i���p�̂݁j
                    AppendTo( ref data, SubStringOfByte( detailWork.SALESDETAILRF_GOODSNAMEKANARF, 40 ) );
                }
                else
                {
                    // �i���i�S�p�܂ށj
                    AppendTo( ref data, SubStringOfByte( detailWork.SALESDETAILRF_GOODSNAMERF, 40 ) );
                }

                // ���[�J�[�R�[�h
                AppendTo( ref data, detailWork.SALESDETAILRF_PRTMAKERCODERF );

                // �a�k�R�[�h
                if ( detailWork.SALESDETAILRF_SALESSLIPCDDTLRF == 2 && detailWork.SALESDETAILRF_SHIPMENTCNTRF == 0 )
                {
                    // �s�l���Ȃ��PM7���l��BL����=-1���Z�b�g����
                    AppendTo( ref data, -1 );
                }
                else
                {
                    // BL���ނ��Z�b�g
                    AppendTo( ref data, detailWork.SALESDETAILRF_PRTBLGOODSCODERF );
                }

                // �o�א�(�����_�ȉ�:�l�̌ܓ�)
                AppendTo( ref data, Round( detailWork.SALESDETAILRF_SHIPMENTCNTRF ) * countSign );

                // �P��(�����_�ȉ�:�l�̌ܓ�)
                AppendTo( ref data, Round( detailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF ) );

                // �艿(����f�[�^�Z�b�g�d�l��͂܂�ߕs�v�����A�l�̌ܓ�����)
                AppendTo( ref data, Round( detailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF ) );
            }

            // CSV�f�[�^����
            csvData = data.ToString();

            // �p�q�R�[�h�p�f�[�^������ɕϊ����ĕԋp
            qrData = QRDataCreator.CreateData( csvData );
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int Round( double orgValue )
        {
            Int64 resultValue;

            // �[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j
            FractionCalculate.FracCalcMoney( (double)orgValue, 1.0f, 2, out resultValue );

            return (int)resultValue;
        }
    }

    // 2010/07/06 Add >>>
    /// <summary>
    /// ���[���p�p�q�f�[�^��������N���X
    /// </summary>
    internal class MailQRDataCreateMediator : QRDataCreateMediator
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public static string CreateData(Guid guid)
        {
            // �p�q�R�[�h�p�f�[�^������ɕϊ����ĕԋp
            return QRDataCreator.CreateDataForMail(guid.ToString(), false);
        }
    }
    // 2010/07/06 Add <<<
    # endregion
    // --- ADD m.suzuki 2010/03/24 ----------<<<<<

    // --- ADD  ���r��  2010/05/13 ---------->>>>>
    #region[�e�����v�Z�����N���X]
    /// <summary>
    /// �e�������v�Z
    /// </summary>
    internal class GrossProfitCalculator
    {
        private SalesPriceCalculate _salesPriceCalculate;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GrossProfitCalculator()
        {
            _salesPriceCalculate = new SalesPriceCalculate();
        }

        /// <summary>
        /// �e�����Z�o����
        /// </summary>
        /// <param name="salesMoney">������z</param>
        /// <param name="cost">�������z</param>
        /// <returns></returns>
        public double CalcGrossProfitRate(long salesMoney, long cost)
        {
            double retRate = 0;
            if (salesMoney != 0)
            {
                this.GetRate((salesMoney - cost), salesMoney, out retRate); // ������R�ʂ��l�̌ܓ��Œ�
            }
            return retRate;
        }

        /// <summary>
        /// ���Z�菈��
        /// </summary>
        /// <param name="numerator">���l(���q)</param>
        /// <param name="denominator">���l(����)</param>
        /// <param name="rate">��</param>
        public void GetRate(double numerator, double denominator, out double rate)
        {
            rate = this._salesPriceCalculate.CalculateMarginRate(numerator, denominator);   
        }
    }
    #endregion
    // --- ADD  ���r��  2010/05/13 ----------<<<<<

    // --- ADD  ���r��  2010/06/29 ---------->>>>>
    #region[�`�[����\����]
    /// <summary>
    /// �`�[����\����
    /// </summary>
    public struct SlipPrintParameterofCount
    {
        /// <summary>���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P  �ő�󎚉\��</summary>
        private int _minCount1ofCstNameJoin;
        /// <summary>���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q  �ő�󎚉\��</summary>
        private int _minCount2ofCstNameJoin;
        /// <summary>���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R�@�ő�󎚉\��</summary>
        private int _minCount3ofCstNameJoin;

        /// <summary>
        /// ���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�P
        /// �ő�󎚉\��
        /// </summary>
        public int MinCount1ofCstNameJoin
        {
            get { return _minCount1ofCstNameJoin; }
            set { _minCount1ofCstNameJoin = value; }
        }
        /// <summary>
        /// ���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�Q
        /// �ő�󎚉\��
        /// </summary>
        public int MinCount2ofCstNameJoin
        {
            get { return _minCount2ofCstNameJoin; }
            set { _minCount2ofCstNameJoin = value; }
        }
        /// <summary>
        /// ���Ӑ於�P�{���Ӑ於�Q�{�h��(��)�R
        /// �ő�󎚉\��
        /// </summary>
        public int MinCount3ofCstNameJoin
        {
            get { return _minCount3ofCstNameJoin; }
            set { _minCount3ofCstNameJoin = value; }
        }
    }
    #endregion
    // --- ADD  ���r��  2010/06/29 ----------<<<<<
 

}
