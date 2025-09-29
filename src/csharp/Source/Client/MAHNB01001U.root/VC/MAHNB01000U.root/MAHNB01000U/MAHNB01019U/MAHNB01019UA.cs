using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;  // 2010/06/15 Add

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using System.IO;//ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ������͗p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͗p�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br>Update Note: </br>
    /// <br>2009.07.15 22018 ��� ���b MANTIS[0013801] �a�k�R�[�h�K�C�h�̏����\�����[�h��ݒ�\�ɕύX�B</br>
    /// <br>Update Note : 2009/12/23 ���M</br>
    /// <br>              PM.NS-5-A�EPM.NS�ێ�˗��C</br>
    /// <br>              �o�א����͍ő包���A�󒍐����͍ő包����ǉ�</br>
    /// <br>              �t�b�^���̃t�H�[�J�X�����ǉ�</br>
    /// <br>Update Note  : 2010/01/27 ����</br>
    /// <br>               PM1003-A�E�o�l�D�m�r�@�S������</br>
    /// <br>               �o�l�D�m�r�@�S�����ǂ̑Ή�</br>
    /// <br>Update Note: 2010/02/02 ���M</br>
    /// <br>           : Redmine#2757�̑Ή�</br>
    /// <br>Update Note : 2010/02/26 ���n ��� </br>
    /// <br>              SCM�Ή�</br>
    /// <br>Update Note: 2010/06/15 �R�H �F�Y</br>
    /// <br>             RC�A�g�Ή�</br>
    /// <br>             �@SCM��񎩓��W�J�̍폜</br>
    ///                  �A��������^�u�̍폜�i������������̂ݓ��͐���ֈړ�</br>
    /// <br>             �B�I�v�V��������^�u�̒ǉ�</br>
    /// <br>             �CRC�A�g�p�t�H���_��ǉ�</br>
    /// <br>Update Note : 2010/07/22 ���n ��� </br>
    /// <br>              SCM��񎩓��W�J����ɂO�Ƃ���(�s�v�Ȉ�)</br>
    /// <br>Update Note: 2010/08/06 20056 ���n ��� </br>
    /// <br>             �S���ҁA�󒍎ҁA���s�҂̕\�������ύX</br>
    /// <br>Update Note: 2011/08/08 �A��1002 ����g </br>
    /// <br>             �u���͌�̃J�[�\���ʒu�v�̃h���v�_�A�E��ǉ�</br>
    /// <br>Update Note: 2011/08/09 �A��4,979 ���X��</br>
    /// <br>               ���[�U�[�ݒ�̓��͐���ɃA�N�e�B�u�F���ڂ�ǉ�</br>
    /// <br>Update Note: 2012/04/11 No.594 �e�c ���V </br>
    /// <br>             �u���i������̃t�H�[�J�X�ʒu�v���ڒǉ�</br>
    /// <br>Update Note: 2012/05/21 ���c �N�v </br>
    /// <br>             No.594��Q�Ή��s���̂��߂��Ƃɖ߂�</br>
    /// <br>Update Note: 2013/02/14 �{�{ ����</br>
    /// <br>             �d����(�d�����)�̃t�H�[�J�X�����ǉ�</br>
    /// <br>Update Note: 2013/04/23 �e�c ���V</br>
    /// <br>             ���͌�̃J�[�\���ʒu���ڂ̏��ԁA�l�����ւ�</br>
    /// <br>             �o�l�m�r�^�C�v�FDataValue�@1��0</br>
    /// <br>             �o�l�V�^�C�v�@�FDataValue�@0��1</br>
    /// <br>Update Note: 2013/11/05 �e�c ���V</br>
    /// <br>             �d�|�ꗗ��1492(��594)�Ή�</br>
    /// <br>             �u���i������̃t�H�[�J�X�ʒu�v���ڒǉ����A�󒍓`�[����͂��₷������</br>
    /// <br>Update Note: 2014/02/24 �e�c ���V</br>
    /// <br>             �d�|�ꗗ ��2307</br>
    /// <br>             ���[�U�[�ݒ�Ɂu�`�[��ʂ̋L���v���ڒǉ�</br>     
    /// <br>Update Note : 2017/01/22 ����</br>
    /// <br>�Ǘ��ԍ�    : 11270046-00</br>
    /// <br>            : Redmine#48967 ���q�������ǂ̑Ή�</br>
    /// <br>Update Note: 2018/09/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11470152-00</br>
    /// <br>           : �w�ݒ�x��ʂŉ�ʐ���^�u�̕ύX</br>
    /// <br>Update Note: 2021/03/16 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 ����`�[���͌���0�~��Q�̑Ή�</br>
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\�����ڐݒ�̒ǉ�</br>
    /// <br>Update Note: 2021/06/21 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\���̑Ή�</br>
    /// <br>Update Note: 2021/09/10 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�</br> 
    /// <br>Update Note: 2022/04/26 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11870080-00</br>
    /// <br>           : PMKOBETSU-4208 �d�q����Ή�</br> 
    /// <br>Update Note: 2022/10/05 �c������</br>
    /// <br>�Ǘ��ԍ�   : 11870141-00</br>
    /// <br>           : �C���{�C�X�c�Ή�</br> 
    /// </remarks>
    public partial class SalesSlipInputSetup : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private SalesSlipInputConstructionAcs _salesSlipInputConstructionAcs;
        private ControlScreenSkin _controlScreenSkin;
        private HeaderFocusConstructionList _headerFocusConstructionList;
        private FunctionConstructionList _functionConstructionList;// ADD 2010/07/06
        private FunctionDetailConstructionList _functionDetailConstructionList;// ADD 2010/08/13
        private Dictionary<string, Control> _headerItemsDictionary;
        private Dictionary<string, Control> _functionItemsDictionary;// ADD 2010/07/06
        private Dictionary<string, Control> _functionDetailItemsDictionary;// ADD 2010/08/13
        private FooterFocusConstructionList _footerFocusConstructionList;// ADD 2009/12/23
        private Dictionary<string, Control> _footerItemsDictionary;// ADD 2009/12/23
        private SalesSlipInputSetupDataSet.HeaderFocusDataTable _headerFocusDataTable;
        private SalesSlipInputSetupDataSet.FunctionDataTable _functionDataTable;// ADD 2010/07/06
        private SalesSlipInputSetupDataSet.FunctionDetailDataTable _functionDetailDataTable;// ADD 2010/08/13
        private SalesSlipInputSetupDataSet.DetailFocusDataTable _detailFocusDataTable;
        private SalesSlipInputSetupDataSet.FooterFocusDataTable _footerFocusDataTable; // ADD 2009/12/23
        private DataView _headerFocusView = null;
        private DataView _functionView = null;// ADD 2010/07/06
        private DataView _functionDetailView = null;// ADD 2010/08/13
        private DataView _detailFocusView = null;
        private DataView _footerFocusView = null;// ADD 2009/12/23
        private List<string> _optionList = new List<string>();   // 2010/06/15 Add
        private PMKEN08020UF ModelSelectionSetting;// ADD 2017/01/22 ���� Redmine#48967
        // --- ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� ----->>>>>
        private const string CusGuidDisChangeMsg = "���Ӑ�K�C�h�\���@�\�̓��C�h���j�^�̂��g�p�𐄏��������܂��B";
        private const int CusGuidDisChangeMsgValue = 0;
        // --- ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� -----<<<<<
        //--- ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή� ----->>>>>
        private const string PRINTCHECKMSG = "�v�����^�ݒ�ŁAPDF�v�����^�𐳂����o�^���Ă��������B";
        private const string PRINTER_NORMAL = "Microsoft Print to PDF";
        private const string PRINTER_CUBE = "CubePDF";
        private const int MODE_NONE = 0; //�uPDF�o�͂��Ȃ��v���[�h
        private const string XML_PDFPRINTERSETTINGENABLE = "MAHNB01001U_PDFPrinterSettingEnable.xml";
        //--- ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή� -----<<<<<

        //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� ----->>>>>
        /// <summary>�ԕi��ԓ`����ݒ�XML�t�@�C��</summary>
        private const string XML_RETURNREDSETTINGS = "MAHNB01001U_ReturnRedSetting.xml";
        /// <summary>�ԕi��ԓ`���� ���l���g�p���[�h</summary>
        private const int ReturnRedNote_BLANK = 0;//��
        private const int ReturnRedNote_SLIPNUM = 1;//������t�{�����`�[�ԍ�
        private const int ReturnRedNote_ORIGINAL = 2;//�����`�[�ԍ�
        private const int ReturnRedNote_OPTIONAL = 3;//�C��
         private string _returnRedNote1 = string.Empty;
        private string _returnRedNote2 = string.Empty;
        private string _returnRedNote3 = string.Empty;
        /// <summary>�ԕi��ԓ`���� ���l���󔒃`�F�b�N���[�h</summary>
        private const int ReturnRedBlankCheck_OFF = 0;//�`�F�b�N����
        private const int ReturnRedBlankCheck_ON = 1;//�`�F�b�N����
        //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� -----<<<<<
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Programmer : �A��1002 ����g</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : �A��4,979 ���X��</br>
        /// <br>Date       : 2011/08/09</br>
        /// <br>Update Note: 2017/01/22 ����</br>
        /// <br>�Ǘ��ԍ�   : 11270046-00</br>
        /// <br>           : Redmine#48967 ���q�������ǂ̑Ή�</br>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00</br>
        /// <br>           : �w�ݒ�x��ʂŉ�ʐ���^�u�̕ύX</br>
        /// <br>Update Note: 2021/03/16 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 ����`�[���͌���0�~��Q�̑Ή�</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\�����ڐݒ�̒ǉ�</br>
        /// <br>Update Note: 2022/10/05 �c��������</br>
        /// <br>�Ǘ��ԍ�   : 11870141-00</br>
        /// <br>           : �C���{�C�X�c�Ή�</br>
        /// </remarks>
        public SalesSlipInputSetup()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._salesSlipInputConstructionAcs = SalesSlipInputConstructionAcs.GetInstance();
            this._controlScreenSkin = new ControlScreenSkin();
            this._headerFocusConstructionList = new HeaderFocusConstructionList();
            this._headerItemsDictionary = new Dictionary<string, Control>();
            this._functionItemsDictionary = new Dictionary<string, Control>();// ADD 2010/07/06
            this._functionDetailItemsDictionary = new Dictionary<string, Control>();// ADD 2010/08/13
            this._footerFocusConstructionList = new FooterFocusConstructionList();// ADD 2009/12/23
            this._footerItemsDictionary = new Dictionary<string, Control>();// ADD 2009/12/23
            this._headerFocusDataTable = new SalesSlipInputSetupDataSet.HeaderFocusDataTable();
            this._functionDataTable = new SalesSlipInputSetupDataSet.FunctionDataTable();// ADD 2010/07/06
            this._functionDetailDataTable = new SalesSlipInputSetupDataSet.FunctionDetailDataTable();// ADD 2010/08/13
            this._detailFocusDataTable = new SalesSlipInputSetupDataSet.DetailFocusDataTable();
            this._footerFocusDataTable = new SalesSlipInputSetupDataSet.FooterFocusDataTable();// ADD 2009/12/23
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPosition, this._salesSlipInputConstructionAcs.FocusPositionValue, 0);
            this.tNedit_DataInputCount.SetInt(this._salesSlipInputConstructionAcs.DataInputCountValue);
            this.SetComboEditorItemIndex(this.tComboEditor_FontSize, this._salesSlipInputConstructionAcs.FontSizeValue, 11);
            this.SetComboEditorItemIndex(this.tComboEditor_Colors, this._salesSlipInputConstructionAcs.ColorsValue, 0); // ADD 2011/08/09
            this.SetOptionSetItemIndex(this.uOptionSet_ClearAfterSave, this._salesSlipInputConstructionAcs.ClearAfterSaveValue);
            this.SetOptionSetItemIndex(this.uOptionSet_UltraOptionSet, this._salesSlipInputConstructionAcs.UltraOptionSetValue); //ADD 2010/01/27
            this.SetOptionSetItemIndex(this.uOptionSet_SaveInfoStore, this._salesSlipInputConstructionAcs.SaveInfoStoreValue);
            this.SetOptionSetItemIndex(this.uOptionSet_PartySaleSlipDiv, this._salesSlipInputConstructionAcs.PartySaleSlipValue);
            //>>>2010/08/06
            this.SetComboEditorItemIndex(this.tComboEditor_EmployeeCdDiv, this._salesSlipInputConstructionAcs.EmployeeCdDivValue, 0);
            this.SetComboEditorItemIndex(this.tComboEditor_FrontEmployeeCdDiv, this._salesSlipInputConstructionAcs.FrontEmployeeCdDivValue, 0);
            this.SetComboEditorItemIndex(this.tComboEditor_SalesInputCdDiv, this._salesSlipInputConstructionAcs.SalesInputCdDivValue, 0);
            this.tEdit_EmployeeCode.Text = this._salesSlipInputConstructionAcs.EmployeeCdValue;
            //<<<2010/08/06
            this.tEdit_FrontEmployeeCd.Text = this._salesSlipInputConstructionAcs.FrontEmployeeCdValue;
            this.tEdit_SalesInputCd.Text = this._salesSlipInputConstructionAcs.SalesInputCdValue;
//2010/06/18 yamaji DEL
//DEL            this.SetComboEditorItemIndex(this.tComboEditor_SearchUICntDivCd, this._salesSlipInputConstructionAcs.SearchUICntDivCdValue, 0);
//DEL            this.SetComboEditorItemIndex(this.tComboEditor_EnterProcDivCd, this._salesSlipInputConstructionAcs.EnterProcDivCdValue, 0);
//DEL            this.SetComboEditorItemIndex(this.tComboEditor_PartsNoSearchDivCd, this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue, 0);
//2010/06/18 yamaji DEL
            this.tEdit_PartsJoinCntDivCd.Text = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterCarSearch, this._salesSlipInputConstructionAcs.FocusPositionAfterCarSearchValue, 2);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            this.SetComboEditorItemIndex( this.tComboEditor_BLGuideMode, this._salesSlipInputConstructionAcs.BLGuideModeValue, 0 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
            //this.SetOptionSetItemIndex(this.uOptionSet_scm, this._salesSlipInputConstructionAcs.ScmValue);// 2010/02/26 // 2010/07/22
            this.SetComboEditorItemIndex(this.tComboEditor_CursorPos, this._salesSlipInputConstructionAcs.CursorPosValue, 0);  //ADD �A��1002 2011/08/08
            // --- DEL 2012/05/21 ---------->>>>>
            //this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterBLCodeSearch, this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue, 0);   //ADD 2012/04/11 No.594
            // --- DEL 2012/05/21 ----------<<<<<
            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterBLCodeSearch, this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue, 0);
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
            // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_AcptAnOdrStatusMemory, this._salesSlipInputConstructionAcs.AcptAnOdrStatusMemoryValue, 0);
            // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_CustomerGuidDisplay, this._salesSlipInputConstructionAcs.CustomerGuidDisplayValue, 0);
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            // --- ADD 2009/12/23 ---------->>>>>
            this.tNedit_ShipmentMaxCnt.SetInt(this._salesSlipInputConstructionAcs.ShipmentMaxCntValue);
            this.tNedit_AcceptAnOrderMaxCnt.SetInt(this._salesSlipInputConstructionAcs.AcceptAnOrderMaxCntValue);
            // --- ADD 2009/12/23 ----------<<<<<

            // 2010/06/15 Add >>>
            this.tEdit_RCLinkDirectory.Text = this._salesSlipInputConstructionAcs.RCLinkDirectoryValue;
            // 2010/06/15 Add <<<

            // 2010/06/15 Add >>>
            this._optionList = new List<string>();

            // RC�A�g�t�H���_�́ARC�A���I�v�V�������L���ȏꍇ�̂ݗL��
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Trial_Contract || ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optionList.Add(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
                this.pnlOption_RCLink.Visible = true;
            }
            else
            {
                this.pnlOption_RCLink.Visible = false;
            }
            //----- ADD�@2018/09/04 杍^�@�w�ݒ�x��ʂŉ�ʐ���^�u�̕ύX------->>>>>
            this.tNedit_Month.SetInt(this._salesSlipInputConstructionAcs.InputMonthValue);
            //----- ADD�@2018/09/04 杍^�@�w�ݒ�x��ʂŉ�ʐ���^�u�̕ύX-------<<<<<

            // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133-------->>>>
            this.SetOptionSetItemIndex(this.uOptionSet_SaveUnitCostCheckDiv, this._salesSlipInputConstructionAcs.SaveUnitCostCheckDivValue);
            // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133--------<<<<<
            //----- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_OutputMode, this._salesSlipInputConstructionAcs.OutputMode, 0);
            if (this._salesSlipInputConstructionAcs.SalesOutputDiv == 1)
            {
                this.ultraCheckEditor_SalesOutputDiv.Checked = true;
            }
            else
            {
                this.ultraCheckEditor_SalesOutputDiv.Checked = false;
            }
            if (this._salesSlipInputConstructionAcs.EstimateOutputDiv == 1)
            {
                this.ultraCheckEditor_EstimateOutputDiv.Checked = true;
            }
            else
            {
                this.ultraCheckEditor_EstimateOutputDiv.Checked = false;
            }
            SetPdfPrinter();
            this.tNedit_PdfPrinterWait.Value = this._salesSlipInputConstructionAcs.PdfPrinterWait;

            // �d�q����A�g�I�v�V�������肪�L���ȏꍇ�u�d�q����A�g�v�^�u��\������
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this.uTabControl_Setup.Tabs["EBooksControl"].Visible = true;
            }
            else
            {
                this.uTabControl_Setup.Tabs["EBooksControl"].Visible = false;
            }
            
            //----- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�-------<<<<<

            //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� ----->>>>>
            this._salesSlipInputConstructionAcs.GetReturnRedSettings();
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedNote1, this._salesSlipInputConstructionAcs.ReturnRedNote1Mode);
            this.tEdit_ReturnRedNote1.Text = this._salesSlipInputConstructionAcs.ReturnRedNote1;
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedNote2, this._salesSlipInputConstructionAcs.ReturnRedNote2Mode);
            this.tEdit_ReturnRedNote2.Text = this._salesSlipInputConstructionAcs.ReturnRedNote2;
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedNote3, this._salesSlipInputConstructionAcs.ReturnRedNote3Mode);
            this.tEdit_ReturnRedNote3.Text = this._salesSlipInputConstructionAcs.ReturnRedNote3;
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedBlankCheck, this._salesSlipInputConstructionAcs.ReturnRedBlankCheckMode);
            //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� -----<<<<<

            // �I�v�V�����p�p�l���ɕ\�����鍀�ڂ����݂���ꍇ�̓^�u��\������
            this.uTabControl_Setup.Tabs["OptionControl"].Visible = ( this._optionList.Count > 0 );
            // 2010/06/15 Add <<<

            if (this.uTabControl_Setup.Tabs.Count > 1)
            {
                this.uTabControl_Setup.TabStop = true;
            }
            else
            {
                this.uTabControl_Setup.TabStop = false;
            }
//2010/06/15 yamaji DEL
//DEL            this.SettingPartsJoinCntDivCdEnable((int)tComboEditor_PartsNoSearchDivCd.Value);
//2010/06/15 yamaji DEL

            // --- ADD 2010/06/02 ---------->>>>>
            this.ultraButton2.Enabled = false;
            this.ultraButton1.Enabled = false;
            // --- ADD 2010/06/02 ----------<<<<<
            //----- ADD 2017/01/22 ���� Redmine#48967 ----->>>>>
            this.ModelSelectionSetting = new PMKEN08020UF();
            this.ModelSelectionSetting.Deserialize();
            //----- ADD 2017/01/22 ���� Redmine#48967 -----<<<<<
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Method
        #region �S�ʏ���
        /// <summary>
        /// �R���{�G�f�B�^�A�C�e���C���f�b�N�X�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
        /// <param name="dataValue">�ݒ�l</param>
        /// <param name="defaultIndex">�����l</param>
        private void SetComboEditorItemIndex(TComboEditor sender, int dataValue, int defaultIndex)
        {
            int index = defaultIndex;

            for (int i = 0; i < sender.Items.Count; i++)
            {
                if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
                {
                    index = i;
                    break;
                }
            }

            sender.SelectedIndex = index;

            if ((index == -1) && (sender.DropDownStyle == Infragistics.Win.DropDownStyle.DropDown))
            {
                sender.Text = dataValue.ToString();
            }
        }

        /// <summary>
        /// �I�v�V�����Z�b�g�A�C�e���C���f�b�N�X�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۂƂȂ�I�v�V�����Z�b�g</param>
        /// <param name="dataValue">�ݒ�l</param>
        private void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
        {
            int index = -1;
            for (int i = 0; i < sender.Items.Count; i++)
            {
                if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
                {
                    index = i;
                    break;
                }
            }

            sender.CheckedIndex = index;
        }

        /// <summary>
        /// �I�v�V�����Z�b�g�I��l�擾����
        /// </summary>
        /// <param name="sender">�ΏۂƂȂ�I�v�V�����Z�b�g</param>
        /// <returns>�I��l</returns>
        private int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
        {
            if (sender.CheckedIndex >= 0)
            {
                return (int)sender.CheckedItem.DataValue;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// �R���{�G�f�B�^�I��l�擾����
        /// </summary>
        /// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
        /// <returns>�I��l</returns>
        private int GetComboEditorValue(TComboEditor sender)
        {
            if (sender.SelectedIndex >= 0)
            {
                return (int)sender.SelectedItem.DataValue;
            }
            else
            {
                int index = -1;

                // ���l�݂̂����͂���Ă���ꍇ�́A���͒l��value���r����B
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                if (regex.IsMatch(sender.Text.Trim()))
                {
                    int dataValue = 0;

                    try
                    {
                        dataValue = Convert.ToInt32(sender.Text.Trim());
                    }
                    catch (OverflowException)
                    {
                        // 
                    }

                    for (int i = 0; i < sender.Items.Count; i++)
                    {
                        if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
                        {
                            index = i;
                            break;
                        }
                    }
                }

                // ��L�̔�r�ŊY���f�[�^�����݂��Ȃ������ꍇ�́A���͒l��DisplayText���r����B
                if (index == -1)
                {
                    string selectText = sender.Text.Trim();

                    for (int i = 0; i < sender.Items.Count; i++)
                    {
                        if (sender.Items[i].DisplayText.Trim() == selectText)
                        {
                            index = i;
                            break;
                        }
                    }
                }

                // �Y���f�[�^�����݂��Ȃ��ꍇ��0�Ƃ���B
                if (index == -1)
                {
                    return 0;
                }
                else
                {
                    return (int)sender.Items[index].DataValue;
                }
            }
        }

        /// <summary>
        /// ���̓f�[�^�`�F�b�N����
        /// </summary>
        /// <returns>true:�`�F�b�NOK false:�`�F�b�NNG</returns>
        private bool InputDataCheck()
        {
            bool check = true;

            //---------------------------------------
            // ���͌���
            //---------------------------------------
            if ((this.tNedit_DataInputCount.GetInt() <= 0) || (this.tNedit_DataInputCount.GetInt() > 999))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���͍s����1����999�̒l����͂��ĉ������B",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                this.tNedit_DataInputCount.Focus();
                check = false;
                return check;
            }
            // --- ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
            if (this.tNedit_PdfPrinterNumber.GetInt() <= 0)
            {
                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = 
                    LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    //�uPDF�o�͂��Ȃ��v�ȊO�̏ꍇ
                    if (this.GetComboEditorValue(this.tComboEditor_OutputMode) != MODE_NONE)
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        TMsgDisp.Show(
                                form,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                PRINTCHECKMSG,
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                        form.TopMost = false;
                        check = false;
                        return check;
                    }
                    else
                    { 
                        //�u�I�v�V��������@���@PDF�o�͂��Ȃ��v�ꍇ�A���z�v�����^�̃`�F�b�N�͂��Ȃ�
                    }
                }
                else
                {
                    // �d�q����A�g�I�v�V�������肪�����ȏꍇ�A���z�v�����^�̃`�F�b�N�͂��Ȃ�
                }
            }
            // --- ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<

            return check;

        }
        #endregion

        #region ���׍��ڐ���֌W
        /// <summary>
        /// �t�H�[�J�X�ݒ�\���p�e�[�u���쐬����
        /// </summary>
        /// <param name="enterMoveTable"></param>
        /// <param name="nameTable"></param>
        /// <param name="retTable"></param>
        private void GetDisplayTable(Dictionary<string, EnterMoveValue> enterMoveTable, Hashtable nameTable, ArrayList effectiveList, out ArrayList retList)
        {
            ArrayList retKeyList = new ArrayList();
            Dictionary<string, DisplayTableInfo>displayTableInfoDic = new Dictionary<string, DisplayTableInfo>();
            DisplayTableInfo settingDisplayTableInfo = new DisplayTableInfo();

            string keyName = "";
            string endPosittion = enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion].Key;     // �I���ʒu
            settingDisplayTableInfo.KeyName = enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            settingDisplayTableInfo.Caption = nameTable[settingDisplayTableInfo.KeyName].ToString();

            for (int i = 0; i < enterMoveTable.Count; i++)
            {

                if (i == 0)
                {
                    settingDisplayTableInfo.Enabled = enterMoveTable[settingDisplayTableInfo.KeyName].Enabled;
                    settingDisplayTableInfo.EnabledControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnabledControl;
                    settingDisplayTableInfo.EnterStopControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnterStopControl;
                }

                // ���ڐݒ�
                if (settingDisplayTableInfo.KeyName != "")
                {
                    DisplayTableInfo displayTableInfo = new DisplayTableInfo();
                    displayTableInfo = settingDisplayTableInfo;
                    displayTableInfo.EnterStop = true;
                    // ���ݎ��̓Z�b�g���Ȃ�
                    if (!retKeyList.Contains(settingDisplayTableInfo.KeyName))
                    {
                        retKeyList.Add(settingDisplayTableInfo.KeyName);
                        displayTableInfoDic.Add(settingDisplayTableInfo.KeyName, displayTableInfo);
                    }
                }

                // �I������
                if (settingDisplayTableInfo.KeyName == endPosittion) break;

                // �ݒ���擾
                if (enterMoveTable.ContainsKey(settingDisplayTableInfo.KeyName))
                {
                    keyName = settingDisplayTableInfo.KeyName;
                    settingDisplayTableInfo = new DisplayTableInfo();
                    settingDisplayTableInfo.KeyName = enterMoveTable[keyName].Key;
                    settingDisplayTableInfo.Caption = nameTable[settingDisplayTableInfo.KeyName].ToString(); ;
                    settingDisplayTableInfo.Enabled = enterMoveTable[settingDisplayTableInfo.KeyName].Enabled;
                    settingDisplayTableInfo.EnabledControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnabledControl;
                    settingDisplayTableInfo.EnterStopControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnterStopControl;
                }
                else
                {
                    keyName = settingDisplayTableInfo.KeyName;
                    settingDisplayTableInfo = new DisplayTableInfo();
                    settingDisplayTableInfo.KeyName = "";
                    settingDisplayTableInfo.Caption = nameTable[keyName].ToString();
                    settingDisplayTableInfo.Enabled = false;
                    settingDisplayTableInfo.EnabledControl = false;
                    settingDisplayTableInfo.EnterStopControl = false;
                }
            }

            //-----------------------------------------------
            // �L�����ڑ��݃`�F�b�N
            //-----------------------------------------------
            // �Z�o�����\���p�e�[�u���ɗL�����ڂ��S�đ��݂��邩�ǂ����`�F�b�N
            // ���݂��Ȃ��ꍇ�́A�t�H�[�J�X�����Őݒ�
            //-----------------------------------------------
            string caption = "";
            foreach (string effectiveName in effectiveList)
            {
                caption = nameTable[effectiveName].ToString();
                if (!retKeyList.Contains(effectiveName))
                {
                    retKeyList.Add(effectiveName);
                    DisplayTableInfo displayTableInfo = new DisplayTableInfo();
                    displayTableInfo.KeyName = effectiveName;
                    displayTableInfo.Caption = caption;
                    displayTableInfo.EnterStop = false;
                    displayTableInfo.Enabled = enterMoveTable[effectiveName].Enabled;
                    displayTableInfo.EnabledControl = enterMoveTable[effectiveName].EnabledControl;
                    displayTableInfo.EnterStopControl = enterMoveTable[effectiveName].EnterStopControl;
                    displayTableInfoDic.Add(effectiveName, displayTableInfo);
                }
            }

            retList = new ArrayList();
            foreach (string key in retKeyList)
            {
                // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                //retList.Add(displayTableInfoDic[key]);
                if (key != "SupplierCdForStock")
                {
                    retList.Add(displayTableInfoDic[key]);
                }
                // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
            }
            // ADD 2013/02/14 T.Miyamoto ------------------------------>>>>>
            // �d����(�d�����)���ŏI�s�ɒǉ�
            retList.Add(displayTableInfoDic["SupplierCdForStock"]);
            // ADD 2013/02/14 T.Miyamoto ------------------------------<<<<<
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="headerFocusConstructionList"></param>
        private void SettingDataTableFromDisplayTableInfoList(ArrayList displayTableInfoList)
        {
            int rowNo = 1;
            this._detailFocusDataTable.Clear();
            this._detailFocusDataTable.DefaultView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;

            foreach (DisplayTableInfo displayTableInfo in displayTableInfoList)
            {
                SalesSlipInputSetupDataSet.DetailFocusRow row = this._detailFocusDataTable.NewDetailFocusRow();
                row.RowNo = rowNo;
                row.Key = displayTableInfo.KeyName;
                row.Caption = displayTableInfo.Caption;
                row.Enabled = displayTableInfo.Enabled;
                row.EnterStop = displayTableInfo.EnterStop;
                row.EnabledControl = displayTableInfo.EnabledControl;
                row.EnterStopControl = displayTableInfo.EnterStopControl;
                this._detailFocusDataTable.AddDetailFocusRow(row);
                rowNo++;
            }
        }

        /// <summary>
        /// Enter�L�[���͎��ړ��e�[�u���擾
        /// </summary>
        /// <param name="enterMoveTable"></param>
        /// <param name="enterMoveTableInit"></param>
        /// <param name="nameTable"></param>
        /// <param name="effectiveList"></param>
        /// <param name="endKeyNameList"></param>
        /// <returns></returns>
        private Dictionary<string, EnterMoveValue> GetEnterMoveTable(Dictionary<string, EnterMoveValue> enterMoveTable, Dictionary<string,EnterMoveValue> enterMoveTableInit, Hashtable nameTable, ArrayList effectiveList, ArrayList endKeyNameList)
        {
            List<DisplayTableInfo> retList = new List<DisplayTableInfo>();

            ArrayList retKeyList = new ArrayList();
            Dictionary<string, DisplayTableInfo> displayTableInfoDic = new Dictionary<string, DisplayTableInfo>();

            DataRow[] rows = this._detailFocusDataTable.Select(string.Format("{0}={1}", this._detailFocusDataTable.EnterStopColumn.ColumnName, true), string.Format("{0}", this._detailFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.DetailFocusRow row in rows)
            {
                DisplayTableInfo item = new DisplayTableInfo();
                item.KeyName = row.Key;
                item.Caption = row.Caption;
                item.Enabled = row.Enabled;
                item.EnterStop = row.EnterStop;
                item.EnabledControl = row.EnabledControl;
                item.EnterStopControl = row.EnterStopControl;
                retKeyList.Add(row.Key);
                displayTableInfoDic.Add(row.Key, item);
            }
            rows = this._detailFocusDataTable.Select(string.Format("{0}={1}", this._detailFocusDataTable.EnterStopColumn.ColumnName, false), string.Format("{0}", this._detailFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.DetailFocusRow row in rows)
            {
                DisplayTableInfo item = new DisplayTableInfo();
                item.KeyName = row.Key;
                item.Caption = row.Caption;
                item.Enabled = row.Enabled;
                item.EnterStop = row.EnterStop;
                item.EnabledControl = row.EnabledControl;
                item.EnterStopControl = row.EnterStopControl;
                retKeyList.Add(row.Key);
                displayTableInfoDic.Add(row.Key, item);
            }

            //-----------------------------------------------
            // �e�[�u���쐬
            //-----------------------------------------------
            string movePosittion = enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            string endPosittion = enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion].Key;

            Dictionary<string, EnterMoveValue> retTable = new Dictionary<string, EnterMoveValue>();
            EnterMoveValue enterMoveValue = null;

            int i = 0;
            DisplayTableInfo svDisplayTableInfo = new DisplayTableInfo();
            DisplayTableInfo svEndDisplayTableInfo = new DisplayTableInfo();
            bool startFlg = false;
            bool endFlg = false;

            foreach (string key in retKeyList)
            {
                DisplayTableInfo displayTableInfo = displayTableInfoDic[key];

                //-----------------------------------------------
                // �擪���ڏ��ݒ�
                //-----------------------------------------------
                if (startFlg == false)
                {
                    // �擪����
                    enterMoveValue = new EnterMoveValue();
                    enterMoveValue.Key = displayTableInfo.KeyName;
                    enterMoveValue.Enabled = displayTableInfo.Enabled;
                    enterMoveValue.EnabledControl = displayTableInfo.EnabledControl;
                    enterMoveValue.EnterStopControl = displayTableInfo.EnterStopControl;
                    retTable[SalesSlipInputConstructionAcs.ct_StartPosittion] = enterMoveValue;
                    svDisplayTableInfo = displayTableInfo;
                    startFlg = true;
                    i++;
                    continue;
                }

                //-----------------------------------------------
                // �ړ��\�ŏI���ڏ��ێ�
                //-----------------------------------------------
                // �������ڊY����
                if (displayTableInfo.EnterStop == false)
                {
                    if (endFlg == false)
                    {
                        svEndDisplayTableInfo = svDisplayTableInfo;
                        endFlg = true;
                    }
                }
                // ���X�g�ŏI���R�[�h(�S���ڗL����)
                // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                //else if (i == retList.Count - 1)
                else if (i == (retKeyList.Count - 1))
                // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
                {
                    // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                    //if (endFlg == false)
                    //{
                    //    svEndDisplayTableInfo = displayTableInfo;
                    //    endFlg = true;
                    //}
                    svEndDisplayTableInfo = displayTableInfo;
                    // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
                }

                //-----------------------------------------------
                // �e�[�u�����ݒ�
                //-----------------------------------------------
                if (svDisplayTableInfo.EnterStop == true)
                {
                    // �L��
                    enterMoveValue = new EnterMoveValue();
                    // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                    //if (endKeyNameList.Contains(svDisplayTableInfo.KeyName))
                    if (endFlg == true)
                    // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
                    {
                        enterMoveValue.Key = enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
                    }
                    else
                    {
                        enterMoveValue.Key = displayTableInfo.KeyName;
                    }
                    enterMoveValue.Enabled = svDisplayTableInfo.Enabled;
                    enterMoveValue.EnabledControl = svDisplayTableInfo.EnabledControl;
                    enterMoveValue.EnterStopControl = svDisplayTableInfo.EnterStopControl;
                    retTable[svDisplayTableInfo.KeyName] = enterMoveValue;
                    svDisplayTableInfo = displayTableInfo;
                }
                else
                {
                    // ����(������Ԃ�)
                    if (endFlg == true)
                    {
                        enterMoveValue = new EnterMoveValue();
                        enterMoveValue.Key = enterMoveTableInit[svDisplayTableInfo.KeyName].Key;
                        enterMoveValue.Enabled = displayTableInfoDic[svDisplayTableInfo.KeyName].Enabled;
                        enterMoveValue.EnabledControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnabledControl;
                        enterMoveValue.EnterStopControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnterStopControl;
                        retTable[svDisplayTableInfo.KeyName] = enterMoveValue;
                    }
                    else
                    {
                        retTable[svDisplayTableInfo.KeyName] = enterMoveTable[svDisplayTableInfo.KeyName];
                    }
                    svDisplayTableInfo = displayTableInfo;
                }
                i++;
            }

            //-----------------------------------------------
            // ���X�g�ŏI���ڐݒ�
            //-----------------------------------------------
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = retTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            enterMoveValue.Enabled = displayTableInfoDic[svDisplayTableInfo.KeyName].Enabled;
            enterMoveValue.EnabledControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnabledControl;
            enterMoveValue.EnterStopControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnterStopControl;
            retTable[svDisplayTableInfo.KeyName] = enterMoveValue;

            //-----------------------------------------------
            // �ړ��\�ŏI���ڏ��ݒ�
            //-----------------------------------------------
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = svEndDisplayTableInfo.KeyName;
            enterMoveValue.Enabled = svEndDisplayTableInfo.Enabled;
            enterMoveValue.EnabledControl = svEndDisplayTableInfo.EnabledControl;
            enterMoveValue.EnterStopControl = svEndDisplayTableInfo.EnterStopControl;
            retTable[SalesSlipInputConstructionAcs.ct_EndPosittion] = enterMoveValue;

            return retTable;
        }

        /// <summary>
        /// �s�ړ�����
        /// </summary>
        /// <param name="mode">0:��Ɉړ�,0�ȊO:���Ɉړ�</param>
        /// <param name="rowIndex">�Ώۍs�ԍ�</param>
        /// <returns></returns>
        private bool UpDownDetailRow(int mode, int rowIndex)
        {
            if (this._detailFocusView[rowIndex] == null) return false;

            // �Ώۍs�̏����擾����
            string key = (string)this._detailFocusView[rowIndex][this._detailFocusDataTable.KeyColumn.ColumnName];
            int no = (int)this._detailFocusView[rowIndex][this._detailFocusDataTable.RowNoColumn.ColumnName];

            if (no == 0) return false;

            string formatString = (mode == 0) ? "{0}<{1}" : "{0}>{1}";
            string sortString = (mode == 0) ? "{0} DESC" : "{0}";

            DataRow[] rows = this._detailFocusDataTable.Select(string.Format(formatString, this._detailFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._detailFocusDataTable.RowNoColumn.ColumnName));

            if ((rows != null) && (rows.Length > 0))
            {
                ChangeDetailRowNo(key, (int)rows[0][this._detailFocusDataTable.RowNoColumn.ColumnName]);
                ChangeDetailRowNo((string)rows[0][this._detailFocusDataTable.KeyColumn.ColumnName], no);
            }
            return true;
        }

        /// <summary>
        /// �s�ԍ��ύX����
        /// </summary>
        /// <param name="key">�ΏۃL�[</param>
        /// <param name="no">�ύX����ԍ�</param>
        /// <param name="visiblePosition">��\���ʒu</param>
        private void ChangeDetailRowNo(string key, int no)
        {
            DataRow[] rows = this._detailFocusDataTable.Select(string.Format("{0}='{1}'", this._detailFocusDataTable.KeyColumn.ColumnName, key));
            if (rows != null)
            {
                rows[0][this._detailFocusDataTable.RowNoColumn.ColumnName] = no;
            }
        }

        /// <summary>
        /// �O���b�h�Z���ݒ菈��
        /// </summary>
        private void SettingDetailControlGrid()
        {
            // �e�s���Ƃ̐ݒ�
            for (int i = 0; i < this.uGrid_DetailControl.Rows.Count; i++)
            {
                this.SettingDetailControlGridRow(i);
            }
        }

        /// <summary>
        /// �O���b�h�s�ݒ菈��
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        private void SettingDetailControlGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_DetailControl.DisplayLayout.Bands[0];
            if (editBand == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_DetailControl.Rows[rowIndex];

            row.Cells[this._detailFocusDataTable.EnabledColumn.ColumnName].Activation = ((bool)row.Cells[this._detailFocusDataTable.EnabledControlColumn.ColumnName].Value) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
            row.Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName].Activation = ((bool)row.Cells[this._detailFocusDataTable.EnterStopControlColumn.ColumnName].Value) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
        }
        #endregion

        // --- ADD 2010/07/06 ---------->>>>>
        /// <summary>
        /// �w�b�_���ڐ��䃊�X�g�ݒ菈��(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        private void SettingFunctionConstructionListFromDictionary(Dictionary<string, Control> functionItemsDictionary, ref List<FunctionConstruction> functionConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in functionItemsDictionary.Keys)
            {
                Control control = functionItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FunctionConstruction functionConstruction = new FunctionConstruction();
                Control control = functionItemsDictionary[key];
                functionConstruction.Key = control.Name;
                functionConstruction.Caption = key;
                functionConstruction.Checked = true;
                functionConstructionList.Add(functionConstruction);
            }
            this._functionConstructionList.functionConstruction = functionConstructionList;
        }
        // --- ADD 2010/07/06 ----------<<<<<

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>
        /// �w�b�_���ڐ��䃊�X�g�ݒ菈��(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        private void SettingFunctionDetailConstructionListFromDictionary(Dictionary<string, Control> functionDetailItemsDictionary, ref List<FunctionDetailConstruction> functionDetailConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in functionDetailItemsDictionary.Keys)
            {
                Control control = functionDetailItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FunctionDetailConstruction functionDetailConstruction = new FunctionDetailConstruction();
                Control control = functionDetailItemsDictionary[key];
                functionDetailConstruction.Key = control.Name;
                functionDetailConstruction.Caption = key;
                functionDetailConstruction.Checked = true;
                functionDetailConstructionList.Add(functionDetailConstruction);
            }
            this._functionDetailConstructionList.functionDetailConstruction = functionDetailConstructionList;
        }
        // --- ADD 2010/08/13 ----------<<<<<

        # region �w�b�_���ڐ���
        /// <summary>
        /// �w�b�_���ڐ��䃊�X�g�ݒ菈��(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        private void SettingHeaderFocusConstructionListFromDictionary(Dictionary<string, Control> headerItemsDictionary, ref List<HeaderFocusConstruction> headerFocusConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in headerItemsDictionary.Keys)
            {
                Control control = headerItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                Control control = headerItemsDictionary[key];
                headerFocusConstruction.Key = control.Name;
                headerFocusConstruction.Caption = key;
                headerFocusConstruction.EnterStop = true;
                headerFocusConstructionList.Add(headerFocusConstruction);
            }
            this._headerFocusConstructionList.headerFocusConstruction = headerFocusConstructionList;
        }

        /// <summary>
        /// �w�b�_���ڐݒ菈��(DataTable)
        /// </summary>
        /// <param name="headerFocusDataTableDataTable"></param>
        private void SettingHeaderFocusConstructionListFromDataTable(SalesSlipInputSetupDataSet.HeaderFocusDataTable headerFocusDataTable)
        {
            List<HeaderFocusConstruction> headerFocusConstructionList = new List<HeaderFocusConstruction>();
            DataRow[] rows = headerFocusDataTable.Select("", string.Format("{0}", headerFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.HeaderFocusRow row in rows)
            {
                HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                headerFocusConstruction.Key = row.Key;
                headerFocusConstruction.Caption = row.Caption;
                headerFocusConstruction.EnterStop = row.EnterStop;
                headerFocusConstructionList.Add(headerFocusConstruction);
            }
            this._headerFocusConstructionList.headerFocusConstruction = headerFocusConstructionList;
        }
        //---ADD 2010/07/06---------->>>>>
        /// <summary>
        /// �w�b�_���ڐݒ菈��(DataTable)
        /// </summary>
        /// <param name="headerFocusDataTableDataTable"></param>
        private void SettingFunctionConstructionListFromDataTable(SalesSlipInputSetupDataSet.FunctionDataTable functionDataTable)
        {
            List<FunctionConstruction> functionConstructionList = new List<FunctionConstruction>();
            DataRow[] rows = functionDataTable.Select("", string.Format("{0}", functionDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.FunctionRow row in rows)
            {
                FunctionConstruction functionConstruction = new FunctionConstruction();
                functionConstruction.Key = row.Key;
                functionConstruction.Caption = row.Caption;
                functionConstruction.Checked = row.Checked;
                functionConstructionList.Add(functionConstruction);
            }
            this._functionConstructionList.functionConstruction = functionConstructionList;
        }
        //---ADD 2010/07/06----------<<<<<

        //---ADD 2010/08/13---------->>>>>
        /// <summary>
        /// �w�b�_���ڐݒ菈��(DataTable)
        /// </summary>
        /// <param name="functionDetailDataTable"></param>
        private void SettingFunctionDetailConstructionListFromDataTable(SalesSlipInputSetupDataSet.FunctionDetailDataTable functionDetailDataTable)
        {
            List<FunctionDetailConstruction> functionDetailConstructionList = new List<FunctionDetailConstruction>();
            DataRow[] rows = functionDetailDataTable.Select("", string.Format("{0}", functionDetailDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.FunctionDetailRow row in rows)
            {
                FunctionDetailConstruction functionDetailConstruction = new FunctionDetailConstruction();
                functionDetailConstruction.Key = row.Key;
                functionDetailConstruction.Caption = row.Caption;
                functionDetailConstruction.Checked = row.Checked;
                functionDetailConstructionList.Add(functionDetailConstruction);
            }
            this._functionDetailConstructionList.functionDetailConstruction = functionDetailConstructionList;
        }
        //---ADD 2010/08/13----------<<<<<

        /// <summary>
        /// ���׃f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="headerFocusConstructionList"></param>
        private void SettingDataTableFromHeaderFocusConstructionList(HeaderFocusConstructionList headerFocusConstructionList)
        {
            int rowNo = 1;
            this._headerFocusDataTable.Clear();
            this._headerFocusDataTable.DefaultView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;

            foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
            {
                SalesSlipInputSetupDataSet.HeaderFocusRow row = this._headerFocusDataTable.NewHeaderFocusRow();
                row.RowNo = rowNo;
                row.Key = headerFocusConstruction.Key;
                row.Caption = headerFocusConstruction.Caption;
                row.EnterStop = headerFocusConstruction.EnterStop;
                this._headerFocusDataTable.AddHeaderFocusRow(row);
                rowNo++;
            }
        }

        // --- ADD 2010/07/06 ---------->>>>>
        /// <summary>
        /// ���׃f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="headerFocusConstructionList"></param>
        private void SettingDataTableFromFunctionConstructionList(FunctionConstructionList functionConstructionList)
        {
            int rowNo = 1;
            this._functionDataTable.Clear();
            this._functionDataTable.DefaultView.Sort = this._functionDataTable.RowNoColumn.ColumnName;

            foreach (FunctionConstruction functionConstruction in functionConstructionList.functionConstruction)
            {
                SalesSlipInputSetupDataSet.FunctionRow row = this._functionDataTable.NewFunctionRow();
                row.RowNo = rowNo;
                row.Key = functionConstruction.Key;
                row.Caption = functionConstruction.Caption;
                row.Checked = functionConstruction.Checked;
                this._functionDataTable.AddFunctionRow(row);
                rowNo++;
            }
        }
        // --- ADD 2010/07/06 ----------<<<<<

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>
        /// ���׃f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="functionDetailDataTable"></param>
        private void SettingDataTableFromFunctionDetailConstructionList(FunctionDetailConstructionList functionDetailConstructionList)
        {
            int rowNo = 1;
            this._functionDetailDataTable.Clear();
            this._functionDetailDataTable.DefaultView.Sort = this._functionDetailDataTable.RowNoColumn.ColumnName;

            foreach (FunctionDetailConstruction functionDetailConstruction in functionDetailConstructionList.functionDetailConstruction)
            {
                SalesSlipInputSetupDataSet.FunctionDetailRow row = this._functionDetailDataTable.NewFunctionDetailRow();
                row.RowNo = rowNo;
                row.Key = functionDetailConstruction.Key;
                row.Caption = functionDetailConstruction.Caption;
                row.Checked = functionDetailConstruction.Checked;
                this._functionDetailDataTable.AddFunctionDetailRow(row);
                rowNo++;
            }
        }
        // --- ADD 2010/08/13 ----------<<<<<

        /// <summary>
        /// �s�ړ�����
        /// </summary>
        /// <param name="mode">0:��Ɉړ�,0�ȊO:���Ɉړ�</param>
        /// <param name="rowIndex">�Ώۍs�ԍ�</param>
        /// <returns></returns>
        private bool UpDownHeaderRow(int mode, int rowIndex)
        {
            if (this._headerFocusView[rowIndex] == null) return false;

            // �Ώۍs�̏����擾����
            string key = (string)this._headerFocusView[rowIndex][this._headerFocusDataTable.KeyColumn.ColumnName];
            int no = (int)this._headerFocusView[rowIndex][this._headerFocusDataTable.RowNoColumn.ColumnName];

            if (no == 0) return false;

            string formatString = (mode == 0) ? "{0}<{1}" : "{0}>{1}";
            string sortString = (mode == 0) ? "{0} DESC" : "{0}";

            DataRow[] rows = this._headerFocusDataTable.Select(string.Format(formatString, this._headerFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._headerFocusDataTable.RowNoColumn.ColumnName));

            if ((rows != null) && (rows.Length > 0))
            {
                ChangeHeaderRowNo(key, (int)rows[0][this._headerFocusDataTable.RowNoColumn.ColumnName]);
                ChangeHeaderRowNo((string)rows[0][this._headerFocusDataTable.KeyColumn.ColumnName], no);
            }
            return true;
        }
        /// <summary>
        /// �s�ԍ��ύX����
        /// </summary>
        /// <param name="key">�ΏۃL�[</param>
        /// <param name="no">�ύX����ԍ�</param>
        /// <param name="visiblePosition">��\���ʒu</param>
        private void ChangeHeaderRowNo(string key, int no)
        {
            DataRow[] rows = this._headerFocusDataTable.Select(string.Format("{0}='{1}'", this._headerFocusDataTable.KeyColumn.ColumnName, key));
            if (rows != null)
            {
                rows[0][this._headerFocusDataTable.RowNoColumn.ColumnName] = no;
            }
        }
        # endregion

        // --- ADD 2009/12/23 ---------->>>>>
        # region �t�b�^���ڐ���
        /// <summary>
        /// �t�b�^���ڐ��䃊�X�g�ݒ菈��(Dictionary)
        /// </summary>
        /// <param name="footerItemsDictionary"></param>
        private void SettingFooterFocusConstructionListFromDictionary(Dictionary<string, Control> footerItemsDictionary, ref List<FooterFocusConstruction> footerFocusConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in footerItemsDictionary.Keys)
            {
                Control control = footerItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FooterFocusConstruction footerFocusConstruction = new FooterFocusConstruction();
                Control control = footerItemsDictionary[key];
                footerFocusConstruction.Key = control.Name;
                footerFocusConstruction.Caption = key;
                footerFocusConstruction.EnterStop = true;
                footerFocusConstructionList.Add(footerFocusConstruction);
            }
            this._footerFocusConstructionList.footerFocusConstruction = footerFocusConstructionList;
        }

        /// <summary>
        /// �t�b�^���ڐݒ菈��(DataTable)
        /// </summary>
        /// <param name="footerFocusDataTable"></param>
        private void SettingFooterFocusConstructionListFromDataTable(SalesSlipInputSetupDataSet.FooterFocusDataTable footerFocusDataTable)
        {
            List<FooterFocusConstruction> footerFocusConstructionList = new List<FooterFocusConstruction>();
            DataRow[] rows = footerFocusDataTable.Select("", string.Format("{0}", footerFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.FooterFocusRow row in rows)
            {
                FooterFocusConstruction footerFocusConstruction = new FooterFocusConstruction();
                footerFocusConstruction.Key = row.Key;
                footerFocusConstruction.Caption = row.Caption;
                footerFocusConstruction.EnterStop = row.EnterStop;
                footerFocusConstructionList.Add(footerFocusConstruction);
            }
            this._footerFocusConstructionList.footerFocusConstruction = footerFocusConstructionList;
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="footerFocusConstructionList"></param>
        private void SettingDataTableFromFooterFocusConstructionList(FooterFocusConstructionList footerFocusConstructionList)
        {
            int rowNo = 1;
            this._footerFocusDataTable.Clear();
            this._footerFocusDataTable.DefaultView.Sort = this._footerFocusDataTable.RowNoColumn.ColumnName;

            foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
            {
                SalesSlipInputSetupDataSet.FooterFocusRow row = this._footerFocusDataTable.NewFooterFocusRow();
                row.RowNo = rowNo;
                row.Key = footerFocusConstruction.Key;
                row.Caption = footerFocusConstruction.Caption;
                row.EnterStop = footerFocusConstruction.EnterStop;
                this._footerFocusDataTable.AddFooterFocusRow(row);
                rowNo++;
            }
        }

        /// <summary>
        /// �s�ړ�����
        /// </summary>
        /// <param name="mode">0:��Ɉړ�,0�ȊO:���Ɉړ�</param>
        /// <param name="rowIndex">�Ώۍs�ԍ�</param>
        /// <returns></returns>
        private bool UpDownFooterRow(int mode, int rowIndex)
        {
            if (this._footerFocusView[rowIndex] == null) return false;

            // �Ώۍs�̏����擾����
            string key = (string)this._footerFocusView[rowIndex][this._footerFocusDataTable.KeyColumn.ColumnName];
            int no = (int)this._footerFocusView[rowIndex][this._footerFocusDataTable.RowNoColumn.ColumnName];

            if (no == 0) return false;

            string formatString = (mode == 0) ? "{0}<{1}" : "{0}>{1}";
            string sortString = (mode == 0) ? "{0} DESC" : "{0}";

            DataRow[] rows = this._footerFocusDataTable.Select(string.Format(formatString, this._footerFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._footerFocusDataTable.RowNoColumn.ColumnName));

            if ((rows != null) && (rows.Length > 0))
            {
                ChangeFooterRowNo(key, (int)rows[0][this._footerFocusDataTable.RowNoColumn.ColumnName]);
                ChangeFooterRowNo((string)rows[0][this._footerFocusDataTable.KeyColumn.ColumnName], no);
            }
            return true;
        }

        /// <summary>
        /// �s�ԍ��ύX����
        /// </summary>
        /// <param name="key">�ΏۃL�[</param>
        /// <param name="no">�ύX����ԍ�</param>
        /// <param name="visiblePosition">��\���ʒu</param>
        private void ChangeFooterRowNo(string key, int no)
        {
            DataRow[] rows = this._footerFocusDataTable.Select(string.Format("{0}='{1}'", this._footerFocusDataTable.KeyColumn.ColumnName, key));
            if (rows != null)
            {
                rows[0][this._footerFocusDataTable.RowNoColumn.ColumnName] = no;
            }
        }
        # endregion
        // --- ADD 2009/12/23 ----------<<<<<
        # endregion
        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Update Note : 2017/01/22 ����</br>
        /// <br>�Ǘ��ԍ�    : 11270046-00</br>
        /// <br>            : Redmine#48967 ���q�������ǂ̑Ή�</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\�����ڐݒ�̒ǉ�</br>
        /// </remarks>
        private void SalesInputSetup_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.uButton_Ok.ImageList = this._imageList16;
            this.uButton_Cancel.ImageList = this._imageList16;
            this.uButton_EmployeeGuide.ImageList = this._imageList16; // 2010/08/06
            this.uButton_FrontEmployeeGuide.ImageList = this._imageList16;
            this.uButton_SalesInputGuide.ImageList = this._imageList16;

            this.uButton_Ok.Appearance.Image = (int)Size16_Index.DECISION;
            this.uButton_Cancel.Appearance.Image = (int)Size16_Index.BEFORE;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1; // 2010/08/06
            this.uButton_FrontEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // 2010/06/15 Add >>>
            this.uButton_RCLinkDirGuide.ImageList = this._imageList16;
            this.uButton_RCLinkDirGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // 2010/06/15 Add <<<
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            this.ultraButton_CustomerGuidDisplaySetting.ImageList = this._imageList16;
            this.ultraButton_CustomerGuidDisplaySetting.Appearance.Image = (int)Size16_Index.STAR1;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            //------------------------------------------------------
            // �w�b�_���ڐ���
            //------------------------------------------------------
            this._headerFocusView = this._headerFocusDataTable.DefaultView;
            this.uGrid_HeaderControl.DataSource = this._headerFocusView;
            this._headerFocusConstructionList = this._salesSlipInputConstructionAcs.HeaderFocusConstructionListValue;
            this._headerItemsDictionary = this._salesSlipInputConstructionAcs.HeaderItemsDictionary;
            if (this._headerFocusConstructionList.headerFocusConstruction.Count == 0)
            {
                this.SettingHeaderFocusConstructionListFromDictionary(this._headerItemsDictionary, ref this._headerFocusConstructionList.headerFocusConstruction);
            }
            this.SettingDataTableFromHeaderFocusConstructionList(this._headerFocusConstructionList);

            //---ADD 2010/07/06---------->>>>>
            //------------------------------------------------------
            // �t�@���N�V��������
            //------------------------------------------------------
            this._functionView = this._functionDataTable.DefaultView;
            this.uGrid_FunctionControl.DataSource = this._functionView;
            this._functionConstructionList = this._salesSlipInputConstructionAcs.FunctionConstructionListValue;
            this._functionItemsDictionary = this._salesSlipInputConstructionAcs.FunctionItemsDictionary;
            if (this._functionConstructionList.functionConstruction.Count == 0)
            {
                this.SettingFunctionConstructionListFromDictionary(this._functionItemsDictionary, ref this._functionConstructionList.functionConstruction);
            }
            this.SettingDataTableFromFunctionConstructionList(this._functionConstructionList);
            //---ADD 2010/07/06----------<<<<<

            //---ADD 2010/08/13---------->>>>>
            //------------------------------------------------------
            // �t�@���N�V��������
            //------------------------------------------------------
            this._functionDetailView = this._functionDetailDataTable.DefaultView;
            this.uGrid_FunctionDetailControl.DataSource = this._functionDetailView;
            this._functionDetailConstructionList = this._salesSlipInputConstructionAcs.FunctionDetailConstructionListValue;
            this._functionDetailItemsDictionary = this._salesSlipInputConstructionAcs.FunctionDetailItemsDictionary;
            if (this._functionDetailConstructionList.functionDetailConstruction.Count == 0)
            {
                this.SettingFunctionDetailConstructionListFromDictionary(this._functionDetailItemsDictionary, ref this._functionDetailConstructionList.functionDetailConstruction);
            }
            this.SettingDataTableFromFunctionDetailConstructionList(this._functionDetailConstructionList);
            //---ADD 2010/08/13----------<<<<<

            //------------------------------------------------------
            // ���ו��t�H�[�J�X�ݒ�
            //------------------------------------------------------
            // �t�H�[�J�X�ݒ�\���p�e�[�u���擾
            Dictionary<string, EnterMoveValue> enterMoveTable = this._salesSlipInputConstructionAcs.EnterMoveTable;
            Hashtable nameTable = this._salesSlipInputConstructionAcs.NameTable;
            ArrayList effectiveList = this._salesSlipInputConstructionAcs.EffectiveList;
            ArrayList retList = new ArrayList();
            GetDisplayTable(enterMoveTable, nameTable, effectiveList, out retList);
            this._detailFocusView = this._detailFocusDataTable.DefaultView;
            this.uGrid_DetailControl.DataSource = this._detailFocusView;
            this.SettingDataTableFromDisplayTableInfoList(retList);

            // --- ADD 2009/12/23 ---------->>>>>
            //------------------------------------------------------
            // �t�b�^���ڐ���
            //------------------------------------------------------
            this._footerFocusView = this._footerFocusDataTable.DefaultView;
            this.ultraGrid_FooterControl.DataSource = this._footerFocusView;
            this._footerFocusConstructionList = this._salesSlipInputConstructionAcs.FooterFocusConstructionListValue;
            this._footerItemsDictionary = this._salesSlipInputConstructionAcs.FooterItemsDictionary;
            if (this._footerFocusConstructionList.footerFocusConstruction.Count == 0)
            {
                this.SettingFooterFocusConstructionListFromDictionary(this._footerItemsDictionary, ref this._footerFocusConstructionList.footerFocusConstruction);
            }
            this.SettingDataTableFromFooterFocusConstructionList(this._footerFocusConstructionList);
            // --- ADD 2009/12/23 ----------<<<<<
            //----- ADD 2017/01/22 ���� Redmine#48967 ----->>>>>
            if (this.ModelSelectionSetting != null
                && this.ModelSelectionSetting.SettingItemInfo != null)
            {
                this.tComboEditor_FocusPositionDiv.SelectedIndex = this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv;
                this.tComboEditor_EnterActionDiv.SelectedIndex = this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv;
            }
            //----- ADD 2017/01/22 ���� Redmine#48967 -----<<<<<

            this.timer_Initial.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(uButton_Ok)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Programmer : �A��1002 ����g</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : �A��4,979 ���X��</br>
        /// <br>Date       : 2011/08/09</br>
        /// <br>Update Note: 2017/01/22 ����</br>
        /// <br>�Ǘ��ԍ�   : 11270046-00</br>
        /// <br>           : Redmine#48967 ���q�������ǂ̑Ή�</br>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00</br>
        /// <br>           : �w�ݒ�x��ʂŉ�ʐ���^�u�̕ύX</br>
        /// <br>Update Note: 2021/03/16 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 ����`�[���͌���0�~��Q�̑Ή�</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\�����ڐݒ�̒ǉ�</br>
        /// <br>Update Note: 2021/09/10 ������</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�</br> 
        /// <br>Update Note: 2022/04/26 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11870080-00</br>
        /// <br>           : PMKOBETSU-4208 �d�q����Ή�</br> 
        /// <br>Update Note: 2022/10/05 �c��������</br>
        /// <br>�Ǘ��ԍ�   : 11870141-00</br>
        /// <br>           : �C���{�C�X�c�Ή�</br>
        /// </remarks>
        private void uButton_Ok_Click(object sender, EventArgs e)
        {
            if (!this.InputDataCheck())
            {
                this.DialogResult = DialogResult.Retry;
                return;
            }

            this._salesSlipInputConstructionAcs.FocusPositionValue = this.GetComboEditorValue(this.tComboEditor_FocusPosition);
            this._salesSlipInputConstructionAcs.DataInputCountValue = this.tNedit_DataInputCount.GetInt();
            this._salesSlipInputConstructionAcs.InputMonthValue = this.tNedit_Month.GetInt();// ADD�@2018/09/04 杍^�@�w�ݒ�x��ʂŉ�ʐ���̕ύX
            this._salesSlipInputConstructionAcs.SaveUnitCostCheckDivValue = this.GetOptionSetValue(this.uOptionSet_SaveUnitCostCheckDiv);// ADD 2021/03/16 ���O FOR PMKOBETSU-4133
            this._salesSlipInputConstructionAcs.FontSizeValue = this.GetComboEditorValue(this.tComboEditor_FontSize);
            this._salesSlipInputConstructionAcs.ColorsValue = this.GetComboEditorValue(this.tComboEditor_Colors);// ADD 2011/08/09
            this._salesSlipInputConstructionAcs.ClearAfterSaveValue = this.GetOptionSetValue(this.uOptionSet_ClearAfterSave);
            this._salesSlipInputConstructionAcs.UltraOptionSetValue = this.GetOptionSetValue(this.uOptionSet_UltraOptionSet); // ADD 2010/01/27
            this._salesSlipInputConstructionAcs.SaveInfoStoreValue = this.GetOptionSetValue(this.uOptionSet_SaveInfoStore);
            this._salesSlipInputConstructionAcs.PartySaleSlipValue = this.GetOptionSetValue(this.uOptionSet_PartySaleSlipDiv);
            this._salesSlipInputConstructionAcs.PartySaleSlipValue = this.GetOptionSetValue(this.uOptionSet_PartySaleSlipDiv);
            //>>>2010/08/06
            this._salesSlipInputConstructionAcs.EmployeeCdDivValue = this.GetComboEditorValue(this.tComboEditor_EmployeeCdDiv);
            this._salesSlipInputConstructionAcs.FrontEmployeeCdDivValue = this.GetComboEditorValue(this.tComboEditor_FrontEmployeeCdDiv);
            this._salesSlipInputConstructionAcs.SalesInputCdDivValue = this.GetComboEditorValue(this.tComboEditor_SalesInputCdDiv);
            this._salesSlipInputConstructionAcs.EmployeeCdValue = this.tEdit_EmployeeCode.Text.Trim();
            //<<<2010/08/06
            this._salesSlipInputConstructionAcs.FrontEmployeeCdValue = this.tEdit_FrontEmployeeCd.Text.Trim();
            this._salesSlipInputConstructionAcs.SalesInputCdValue = this.tEdit_SalesInputCd.Text.Trim();
//2010/06/15 yamaji ADD
//DEL            this._salesSlipInputConstructionAcs.SearchUICntDivCdValue = this.GetComboEditorValue(this.tComboEditor_SearchUICntDivCd);
//DEL            this._salesSlipInputConstructionAcs.EnterProcDivCdValue = this.GetComboEditorValue(this.tComboEditor_EnterProcDivCd);
//DEL            this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue = this.GetComboEditorValue(this.tComboEditor_PartsNoSearchDivCd);
//2010/06/15 yamaji ADD

            this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue = this.tEdit_PartsJoinCntDivCd.Text.Trim();
            this._salesSlipInputConstructionAcs.FocusPositionAfterCarSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterCarSearch);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            this._salesSlipInputConstructionAcs.BLGuideModeValue = this.GetComboEditorValue( this.tComboEditor_BLGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
            this._salesSlipInputConstructionAcs.CursorPosValue = this.GetComboEditorValue(this.tComboEditor_CursorPos);  //ADD �A��1002 2011/08/08
            // --- DEL 2012/05/21 ---------->>>>>
            //this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterBLCodeSearch);   // ADD 2012/04/11 No.594
            // --- DEL 2012/05/21 ----------<<<<<
            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterBLCodeSearch);
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
            // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
            this._salesSlipInputConstructionAcs.AcptAnOdrStatusMemoryValue = this.GetComboEditorValue(this.tComboEditor_AcptAnOdrStatusMemory);
            // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            this._salesSlipInputConstructionAcs.CustomerGuidDisplayValue = this.GetComboEditorValue(this.tComboEditor_CustomerGuidDisplay);
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            //>>>2010/07/22
            //this._salesSlipInputConstructionAcs.ScmValue = this.GetOptionSetValue(this.uOptionSet_scm);//2010/02/16
            this._salesSlipInputConstructionAcs.ScmValue = 0;
            //<<<2010/07/22

            // --- ADD 2009/12/23 ---------->>>>>
            this._salesSlipInputConstructionAcs.ShipmentMaxCntValue = this.tNedit_ShipmentMaxCnt.GetInt();
            this._salesSlipInputConstructionAcs.AcceptAnOrderMaxCntValue = this.tNedit_AcceptAnOrderMaxCnt.GetInt();
            // --- ADD 2009/12/23 ----------<<<<<

// 2010/06/15 Add >>>
            this._salesSlipInputConstructionAcs.RCLinkDirectoryValue = this.tEdit_RCLinkDirectory.Text.Trim();
// 2010/06/15 Add <<<

            // �w�b�_���ڐ���
            this.SettingHeaderFocusConstructionListFromDataTable(this._headerFocusDataTable);
            this._salesSlipInputConstructionAcs.HeaderFocusConstructionListValue = this._headerFocusConstructionList;

            //---ADD 2010/07/06---------->>>>>
            // �t�@���N�V��������
            this.SettingFunctionConstructionListFromDataTable(this._functionDataTable);
            this._salesSlipInputConstructionAcs.FunctionConstructionListValue = this._functionConstructionList;
            //---ADD 2010/07/06----------<<<<<

            //---ADD 2010/08/13---------->>>>>
            // �t�@���N�V��������
            this.SettingFunctionDetailConstructionListFromDataTable(this._functionDetailDataTable);
            this._salesSlipInputConstructionAcs.FunctionDetailConstructionListValue = this._functionDetailConstructionList;
            //---ADD 2010/08/13----------<<<<<

            // �t�H�[�J�X�ݒ�\���p�e�[�u��
            Dictionary<string, EnterMoveValue> enterMoveTable = this._salesSlipInputConstructionAcs.EnterMoveTable;
            Dictionary<string, EnterMoveValue> enterMoveTableInit = this._salesSlipInputConstructionAcs.EnterMoveTableInit;
            Hashtable nameTable = this._salesSlipInputConstructionAcs.NameTable;
            ArrayList effectiveList = this._salesSlipInputConstructionAcs.EffectiveList;
            //ArrayList endKeyNameList = this._salesSlipInputConstructionAcs.EndKeyNameList;
            ArrayList endKeyNameList = this._salesSlipInputConstructionAcs.EndKeyNameListInit;
            this._salesSlipInputConstructionAcs.EnterMoveTable = this.GetEnterMoveTable(enterMoveTable, enterMoveTableInit, nameTable, effectiveList, endKeyNameList);

            // --- ADD 2009/12/23 ---------->>>>>
            // �t�b�^���ڐ���
            this.SettingFooterFocusConstructionListFromDataTable(this._footerFocusDataTable);
            this._salesSlipInputConstructionAcs.FooterFocusConstructionListValue = this._footerFocusConstructionList;
            // --- ADD 2009/12/23 ----------<<<<<

            this._salesSlipInputConstructionAcs.Serialize();
            //----- ADD 2017/01/22 ���� Redmine#48967 ----->>>>>
            if (this.ModelSelectionSetting != null
                && this.ModelSelectionSetting.SettingItemInfo != null)
            {
                this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv = this.tComboEditor_FocusPositionDiv.SelectedIndex;
                this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv = this.tComboEditor_EnterActionDiv.SelectedIndex;
                this.ModelSelectionSetting.Serialize();
            }
            //----- ADD 2017/01/22 ���� Redmine#48967 -----<<<<<
            // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�--->>>>>
            // ���P���`�F�b�N�ݒ�t�@�C���X�V
            this._salesSlipInputConstructionAcs.SaveUnitCostCheckSetting();
            // --- ADD 2021/09/10 ������ PMKOBETSU-4172 ���P���`�F�b�N�Ɛŗ����O�̐���t�@�C���̑Ή�---<<<<<
            // --- ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
            this._salesSlipInputConstructionAcs.OutputMode = this.GetComboEditorValue(this.tComboEditor_OutputMode);
            if (this.ultraCheckEditor_SalesOutputDiv.Checked)
            {
                this._salesSlipInputConstructionAcs.SalesOutputDiv = 1;
            }
            else
            {
                this._salesSlipInputConstructionAcs.SalesOutputDiv = 0;
            }
            if (this.ultraCheckEditor_EstimateOutputDiv.Checked)
            {
                this._salesSlipInputConstructionAcs.EstimateOutputDiv = 1;
            }
            else
            {
                this._salesSlipInputConstructionAcs.EstimateOutputDiv = 0;
            }
            this._salesSlipInputConstructionAcs.PdfPrinter = this.GetComboEditorValue(this.tComboEditor_PdfPrinter);
            this._salesSlipInputConstructionAcs.PdfPrinterNumber = this.tNedit_PdfPrinterNumber.GetInt();
            this._salesSlipInputConstructionAcs.PdfPrinterWait = this.tNedit_PdfPrinterWait.GetInt();

            // �d�q����o�͐ݒ�t�@�C���X�V
            this._salesSlipInputConstructionAcs.SaveEBooksOutputSetting();
            // --- ADD ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<

            //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� ----->>>>>
            this._salesSlipInputConstructionAcs.ReturnRedNote1Mode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote1);
            this._salesSlipInputConstructionAcs.ReturnRedNote1 = this.tEdit_ReturnRedNote1.Text;
            this._salesSlipInputConstructionAcs.ReturnRedNote2Mode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote2);
            this._salesSlipInputConstructionAcs.ReturnRedNote2 = this.tEdit_ReturnRedNote2.Text;
            this._salesSlipInputConstructionAcs.ReturnRedNote3Mode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote3);
            this._salesSlipInputConstructionAcs.ReturnRedNote3 = this.tEdit_ReturnRedNote3.Text;
            this._salesSlipInputConstructionAcs.ReturnRedBlankCheckMode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedBlankCheck);
            this._salesSlipInputConstructionAcs.SaveReturnRedControlSetting();
            //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� -----<<<<<
        }

        /// <summary>
        /// ���������^�C�}�[�N������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_Initial_Tick(object sender, EventArgs e)
        {
            this.timer_Initial.Enabled = false;

            this.SettingDetailControlGrid();
            
            this.tComboEditor_FocusPosition.Focus();

            //>>>2010/08/06
            this.EmployeeCdDiv_ValueChanged();
            this.FrontEmployeeCdDiv_ValueChanged();
            this.SalesInputCdDiv_ValueChanged();
            //<<<2010/08/06
        }

        /// <summary>
        /// �t�H�[���N���[�W���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void SalesInputSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �]�ƈ��K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._salesSlipInputConstructionAcs.EnterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //>>>2010/08/06
                // �S���҃R�[�h
                if (sender == this.uButton_EmployeeGuide)
                {
                    this.tEdit_EmployeeCode.Text = employee.EmployeeCode;
                }
                //<<<2010/08/06
                // �󒍎҃R�[�h
                if (sender == this.uButton_FrontEmployeeGuide)
                {
                    this.tEdit_FrontEmployeeCd.Text = employee.EmployeeCode;
                }
                // ���s�҃R�[�h
                if (sender == this.uButton_SalesInputGuide)
                {
                    this.tEdit_SalesInputCd.Text = employee.EmployeeCode;
                }
            }
        }

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// <summary>
        /// ���Ӑ�K�C�h�\���K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\�����ڐݒ�̒ǉ�</br>
        /// </remarks>
        private void ultraButton_CustomerGuidDisplaySetting_Click(object sender, EventArgs e)
        {
            //���Ӑ�K�C�h�\���ݒ��ʋN��
            PMKHN02840UA form = new PMKHN02840UA();
            try
            {
                form.ShowDialog();
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <br>Update Note: 2010/02/02 ���M redmine#2757�Ή�</br>
        /// <br>Note       : 2010/06/02 ���� PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.1</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            Control nextCtrl = null;

            switch (e.PrevCtrl.Name)
            {

                //>>>2010/08/06
                #region �S����
                //---------------------------------------------------------------
                // �S����
                //---------------------------------------------------------------
                case "tEdit_EmployeeCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_EmployeeCode.Text.Trim();

                        canChangeFocus = this.ChangeEmployee(code);

                        #region NextCtrl����
                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        nextCtrl = this.tComboEditor_EmployeeCdDiv;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_EmployeeCode.Text.Trim() == "")
                                        {
                                            nextCtrl = this.uButton_EmployeeGuide;
                                        }
                                        else
                                        {
                                            nextCtrl = tComboEditor_FrontEmployeeCdDiv;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
                #endregion
                //<<<2010/08/06

                #region �󒍎�
                //---------------------------------------------------------------
                // �󒍎�
                //---------------------------------------------------------------
                case "tEdit_FrontEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_FrontEmployeeCd.Text.Trim();

                        canChangeFocus = this.ChangeFrontEmployee(code);

                        #region NextCtrl����
                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        //>>>2010/08/06
                                        //nextCtrl = this.uOptionSet_PartySaleSlipDiv;
                                        nextCtrl = this.tComboEditor_FrontEmployeeCdDiv;
                                        //<<<2010/08/06
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_FrontEmployeeCd.Text.Trim() == "")
                                        {
                                            nextCtrl = this.uButton_FrontEmployeeGuide;
                                        }
                                        else
                                        {
                                            //>>>2010/08/06
                                            //nextCtrl = tEdit_SalesInputCd;
                                            nextCtrl = tComboEditor_SalesInputCdDiv;
                                            //<<<2010/08/06
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
                #endregion

                #region ���s��
                //---------------------------------------------------------------
                // ���s��
                //---------------------------------------------------------------
                case "tEdit_SalesInputCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesInputCd.Text.Trim();

                        canChangeFocus = this.ChangeSalesInput(code);

                        #region NextCtrl����
                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        //>>>2010/08/06
                                        //nextCtrl = this.tEdit_FrontEmployeeCd;
                                        nextCtrl = this.tComboEditor_SalesInputCdDiv;
                                        //<<<2010/08/06
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_SalesInputCd.Text.Trim() == "")
                                        {
                                            nextCtrl = this.uButton_SalesInputGuide;
                                        }
                                        else
                                        {
                                            // ---------- UPD 2010/01/27 ---------- >>>>>>>>>>
                                            // nextCtrl = this.uButton_Ok;
                                            nextCtrl = this.tComboEditor_FocusPositionAfterCarSearch;
                                            // ---------- UPD 2010/01/27 ---------- <<<<<<<<<<
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
                #endregion

                // --- ADD 2009/12/23 ---------->>>>>
                #region �o�א����͍ő包��
                //---------------------------------------------------------------
                // �o�א����͍ő包��
                //---------------------------------------------------------------
                case "tNedit_ShipmentMaxCnt":
                    {   // --- UPD 2010/02/02 ---------->>>>>
                        //if (this.tNedit_ShipmentMaxCnt.GetInt() > 7)
                        if (this.tNedit_ShipmentMaxCnt.GetInt() > 7 || this.tNedit_ShipmentMaxCnt.GetInt() == 0)
                        // --- UPD 2010/02/02 ----------<<<<<
                        {
                            this.tNedit_ShipmentMaxCnt.SetInt(7);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion

                #region �󒍐����͍ő包��
                //---------------------------------------------------------------
                // �󒍐����͍ő包��
                //---------------------------------------------------------------
                case "tNedit_AcceptAnOrderMaxCnt":
                    {
                        // --- UPD 2010/02/02 ---------->>>>>
                        //if (this.tNedit_AcceptAnOrderMaxCnt.GetInt() > 7)
                        if (this.tNedit_AcceptAnOrderMaxCnt.GetInt() > 7 || this.tNedit_AcceptAnOrderMaxCnt.GetInt() == 0)
                        // --- UPD 2010/02/02 ----------<<<<<
                        {
                            this.tNedit_AcceptAnOrderMaxCnt.SetInt(7);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion
                // --- ADD 2009/12/23 ----------<<<<<

                // --- ADD 2010/06/02 ---------->>>>>
                #region �u���v
                case "ultraButton1":
                    {
                        setButtonEnable();
                        break;
                    }
                #endregion
                // --- ADD 2010/06/02 ----------<<<<<

            }
        }

        /// <summary>
        /// tComboEditor_PartsNoSearchDivCd_SelectionChangeCommitted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PartsNoSearchDivCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
//2010/06/15 yamajiDEL
//DEL            this.SettingPartsJoinCntDivCdEnable((int)tComboEditor_PartsNoSearchDivCd.Value);
//2010/06/15 yamajiDEL
        }
        # endregion

        # region Event Methods(�w�b�_���ڐ���֌W(Grid))
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Header_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_HeaderControl.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            this.uGrid_HeaderControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ږ�
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ړ��L��
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �Œ���؂���ݒ�
            this.uGrid_HeaderControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        //---ADD 2010/07/06---------->>>>>
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Function_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_FunctionControl.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            this.uGrid_FunctionControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._functionDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ږ�
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �\���L��
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Width = 40;
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �Œ���؂���ݒ�
            this.uGrid_HeaderControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }
        //---ADD 2010/07/06----------<<<<<

        /// <summary>
        /// ���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_UpHeader_Click(object sender, EventArgs e)
        {
            if (this.uGrid_HeaderControl.ActiveRow != null)
            {
                uGrid_HeaderControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                    if (this.UpDownHeaderRow(0, this.uGrid_HeaderControl.ActiveRow.Index))
                        {
                            this.uGrid_HeaderControl.ActiveCell = this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Cells[this._headerFocusDataTable.EnterStopColumn.ColumnName];
                            this.uGrid_HeaderControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.uGrid_HeaderControl.ActiveCell = null;
                            this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Selected = true;
                        }
                    //}
                }
                finally
                {
                    uGrid_HeaderControl.EndUpdate();
                }
            }
        }

        /// <summary>
        /// ���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_DownHeader_Click(object sender, EventArgs e)
        {
            if (this.uGrid_HeaderControl.ActiveRow != null)
            {
                uGrid_HeaderControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                        if (this.UpDownHeaderRow(1, this.uGrid_HeaderControl.ActiveRow.Index))
                        {
                            this.uGrid_HeaderControl.ActiveCell = this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Cells[this._headerFocusDataTable.EnterStopColumn.ColumnName];
                            this.uGrid_HeaderControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.uGrid_HeaderControl.ActiveCell = null;
                            this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Selected = true;
                        }
                    //}
                }
                finally
                {
                    uGrid_HeaderControl.EndUpdate();
                }
            }
        }

        /// <summary>
        /// �����ݒ�ɖ߂��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_HeaderFocusUndo_Click(object sender, EventArgs e)
        {
            this._headerFocusConstructionList.headerFocusConstruction.Clear();
            this.SettingHeaderFocusConstructionListFromDictionary(this._headerItemsDictionary, ref this._headerFocusConstructionList.headerFocusConstruction);
            this.SettingDataTableFromHeaderFocusConstructionList(this._headerFocusConstructionList);
            this._headerFocusView = this._headerFocusDataTable.DefaultView;
            this.uGrid_HeaderControl.DataSource = this._headerFocusView;
        }

        //---ADD 2010/07/06---------->>>>>
        /// <summary>
        /// �����ݒ�ɖ߂��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FunctionUndo_Click(object sender, EventArgs e)
        {
            this._functionConstructionList.functionConstruction.Clear();
            this.SettingFunctionConstructionListFromDictionary(this._functionItemsDictionary, ref this._functionConstructionList.functionConstruction);
            this.SettingDataTableFromFunctionConstructionList(this._functionConstructionList);
            this._functionView = this._functionDataTable.DefaultView;
            this.uGrid_FunctionControl.DataSource = this._functionView;
        }
        //---ADD 2010/07/06----------<<<<<

        //---ADD 2010/08/13---------->>>>>
        /// <summary>
        /// �����ݒ�ɖ߂��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FunctionDetailUndo_Click(object sender, EventArgs e)
        {
            this._functionDetailConstructionList.functionDetailConstruction.Clear();
            this.SettingFunctionDetailConstructionListFromDictionary(this._functionDetailItemsDictionary, ref this._functionDetailConstructionList.functionDetailConstruction);
            this.SettingDataTableFromFunctionDetailConstructionList(this._functionDetailConstructionList);
            this._functionDetailView = this._functionDetailDataTable.DefaultView;
            this.uGrid_FunctionDetailControl.DataSource = this._functionDetailView;
        }
        //---ADD 2010/08/13----------<<<<<
        # endregion

        # region Event Methods(���א���֌W(Grid))
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Detail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_DetailControl.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            this.uGrid_DetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ږ�
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �\���L��
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Hidden = true;
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Width = 40;
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ړ��L��
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �Œ���؂���ݒ�
            this.uGrid_DetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// ���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : 2010/06/02 ���� PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.1</br>
        private void uButton_UpDetail_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow != null)
            {
                uGrid_DetailControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                    if (this.UpDownDetailRow(0, this.uGrid_DetailControl.ActiveRow.Index))
                    {
                        this.uGrid_DetailControl.ActiveCell = this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName];
                        this.uGrid_DetailControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.uGrid_DetailControl.ActiveCell = null;
                        this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Selected = true;
                    }
                    //}
                }
                finally
                {
                    uGrid_DetailControl.EndUpdate();
                    // --- ADD 2010/06/02 ---------->>>>>
                    setButtonEnable();
                    // --- ADD 2010/06/02 ----------<<<<<
                }
            }
        }

        /// <summary>
        /// ���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : 2010/06/02 ���� PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.1</br>
        private void uButton_DownDetail_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow != null)
            {
                uGrid_DetailControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                    if (this.UpDownDetailRow(1, this.uGrid_DetailControl.ActiveRow.Index))
                    {
                        this.uGrid_DetailControl.ActiveCell = this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName];
                        this.uGrid_DetailControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.uGrid_DetailControl.ActiveCell = null;
                        this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Selected = true;
                    }
                    //}
                }
                finally
                {
                    uGrid_DetailControl.EndUpdate();
                    // --- ADD 2010/06/02 ---------->>>>>
                    setButtonEnable();
                    // --- ADD 2010/06/02 ----------<<<<<
                }
            }
        }

        /// <summary>
        /// �����ݒ�ɖ߂��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_DetailFocusUndo_Click(object sender, EventArgs e)
        {
            Dictionary<string, EnterMoveValue> enterMoveTable = this._salesSlipInputConstructionAcs.EnterMoveTableInit;
            Hashtable nameTable = this._salesSlipInputConstructionAcs.NameTable;
            ArrayList effectiveList = this._salesSlipInputConstructionAcs.EffectiveList;
            ArrayList retList = new ArrayList();
            GetDisplayTable(enterMoveTable, nameTable, effectiveList, out retList);
            this.SettingDataTableFromDisplayTableInfoList(retList);
            this._detailFocusView = this._detailFocusDataTable.DefaultView;
            this.uGrid_DetailControl.DataSource = this._detailFocusView;
            this.SettingDetailControlGrid();
        }
        # endregion


        //>>>2010/08/06
        /// <summary>
        /// �S���ҕύX����
        /// </summary>
        /// <param name="code">�S���҃R�[�h</param>
        /// <returns></returns>
        private bool ChangeEmployee(string code)
        {
            bool ret = true;

            if (code == "")
            {
                this.tEdit_EmployeeCode.Text = code;
            }
            else
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
                Employee employee;
                int status = employeeAcs.Read(out employee, this._salesSlipInputConstructionAcs.EnterpriseCode, code);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�]�ƈ������݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_EmployeeCode.Clear();
                    ret = false;
                }
                else
                {
                    this.tEdit_EmployeeCode.Text = code;
                }
            }
            return ret;
        }
        //<<<2010/08/06

        /// <summary>
        /// �󒍎ҕύX����
        /// </summary>
        /// <param name="code">�󒍎҃R�[�h</param>
        /// <returns></returns>
        private bool ChangeFrontEmployee(string code)
        {
            bool ret = true;

            if (code == "")
            {
                this.tEdit_FrontEmployeeCd.Text = code;
            }
            else
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
                Employee employee;
                int status = employeeAcs.Read(out employee, this._salesSlipInputConstructionAcs.EnterpriseCode, code);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�]�ƈ������݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_FrontEmployeeCd.Clear(); // 2010/08/06
                    ret = false;
                }
                else
                {
                    this.tEdit_FrontEmployeeCd.Text = code;
                }
            }

            return ret;
        }

        /// <summary>
        /// ���s�ҕύX����
        /// </summary>
        /// <param name="code">���s�҃R�[�h</param>
        /// <returns></returns>
        private bool ChangeSalesInput(string code)
        {
            bool ret = true;

            if (code == "")
            {
                this.tEdit_SalesInputCd.Text = code;
            }
            else
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
                Employee employee;
                int status = employeeAcs.Read(out employee, this._salesSlipInputConstructionAcs.EnterpriseCode, code);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�]�ƈ������݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_SalesInputCd.Clear(); // 2010/08/06
                    ret = false;
                }
                else
                {
                    this.tEdit_SalesInputCd.Text = code;
                }
            }

            return ret;
        
        }

        /// <summary>
        /// �i�Ԍ�������Enabled�ݒ菈��
        /// </summary>
        /// <param name="partsNoSearchDivCd"></param>
        private void SettingPartsJoinCntDivCdEnable(int partsNoSearchDivCd)
        {
            if (partsNoSearchDivCd == 0) // �i�Ԍ����敪(0:PM7(�Z�b�g�̂�) 1:�����E�Z�b�g�E���)
            {
                tEdit_PartsJoinCntDivCd.Enabled = true;
                uLabel_PartsJoinCntDivCd.Enabled = true;
            }
            else
            {
                tEdit_PartsJoinCntDivCd.Enabled = false;
                uLabel_PartsJoinCntDivCd.Enabled = false;
            }
        }

        /// <summary>
        /// uLabel_MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uLabel_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            StringBuilder tipString = new StringBuilder();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;

// 2010/06/15 >>>
/*
            if (ctrl.Name == this.uLabel_SearchUICntDivCd.Name)
            {
                this.uLabel_SearchUICntDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "������ʐ���";
                tipString = tipString.Append("������A�\�������e�I����ʂ̕\���������w�肵�܂��B\r\n");
                tipString = tipString.Append("  PM7  �F�e�I����ʊԂ�߂邱�Ƃ͂ł��܂���B\r\n");
                tipString = tipString.Append("  PM.NS�F�e�I����ʊԂ����R�ɖ߂邱�Ƃ��ł��܂��B");
            }
            else if (ctrl.Name == this.uLabel_EnterProcDivCd.Name)
            {
                this.uLabel_EnterProcDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "�G���^�[�L�[����";
                tipString = tipString.Append("�e�I����ʂŃG���^�[�L�[�������̓�����w�肵�܂��B\r\n");
                tipString = tipString.Append("  PM7   �F�I����A����ʂ֐؂�ւ��܂��B\r\n");
                tipString = tipString.Append("          ���Z�b�g�I���́A�I���̂�\r\n");
                tipString = tipString.Append("  �I��  �F�����I�����\�ł��B\r\n");
                tipString = tipString.Append("  ����ʁF�I����A����ʂ֐؂�ւ��܂��B\r\n");
                tipString = tipString.Append("          �A���A�Z�b�g�I���̂݌�����ʐ���ɏ]�����삪�قȂ�܂��B\r\n");
                tipString = tipString.Append("            �E������ʐ���[PM7]�F�I����A���C����ʂ�\r\n");
                tipString = tipString.Append("            �E������ʐ���[PM.NS]�F�I����A�O��ʂ�");
            }
            else if (ctrl.Name == this.uLabel__PartsNoSearchDivCd.Name)
            {
                this.uLabel__PartsNoSearchDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "�i�Ԍ����敪";
                tipString = tipString.Append("�i�Ԍ������̌����Ώۂ��w�肵�܂��B\r\n");
                tipString = tipString.Append("  PM7(�Z�b�g�̂�)   �F�Z�b�g�̂ݑΏ�\r\n");
                tipString = tipString.Append("  �����E�Z�b�g�E��ցF�����E�Z�b�g�E��ւ܂őΏ�\r\n");
                tipString = tipString.Append("��[PM7(�Z�b�g�̂�)]�̏ꍇ�A�i�Ԍ������䂪�L���ɂȂ�܂��B");
            }
            else if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "�i�Ԍ�������";
                tipString = tipString.Append("�i�Ԍ����敪��[PM7(�Z�b�g�̂�)]�̏ꍇ�A\r\n�i�Ԍ�������Ŏw�肳��Ă��镶����\r\n�i�Ԃ̍Ō�ɕt������Ă����\r\n�����E�Z�b�g�E��ւ܂ł̌������s���܂��B");

            }
            if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "�i�Ԍ�������";
                tipString = tipString.Append("�w�肵���������i�Ԃ̍Ō�ɕt������Ă����\r\n�����E�Z�b�g�E��ւ̌������s���܂��B");

            }
 */ 
// 2010/06/15 <<<

            ultraToolTipInfo.ToolTipText = tipString.ToString();

            this.uToolTipManager_Information.Appearance.FontData.Name = "�l�r �S�V�b�N";
            this.uToolTipManager_Information.SetUltraToolTip(ctrl, ultraToolTipInfo);
            this.uToolTipManager_Information.Enabled = true;
        }

        /// <summary>
        /// uLabel_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uLabel_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
//2010/06/15 yamaji UPD>>>>>
/*
            if (ctrl.Name == this.uLabel_SearchUICntDivCd.Name)
            {
                this.uLabel_SearchUICntDivCd.Cursor = Cursors.Default;
            }
            else if (ctrl.Name == this.uLabel_EnterProcDivCd.Name)
            {
                this.uLabel_EnterProcDivCd.Cursor = Cursors.Default;
            }
            else if (ctrl.Name == this.uLabel__PartsNoSearchDivCd.Name)
            {
                this.uLabel__PartsNoSearchDivCd.Cursor = Cursors.Default;
            }
            else if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Default;
            }
*/
            if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Default;
            }
// 2010/06/15 <<<

            uToolTipManager_Information.Enabled = false;
        }

        // --- ADD 2009/12/23 ---------->>>>>
        # region Event Methods(�t�b�^���ڐ���֌W(Grid))
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid_FooterControl_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_FooterControl.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            this.ultraGrid_FooterControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ږ�
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ړ��L��
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �Œ���؂���ݒ�
            this.ultraGrid_FooterControl.DisplayLayout.Override.FixedCellSeparatorColor = this.ultraGrid_FooterControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// �����ݒ�ɖ߂��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FooterFocusUndo_Click(object sender, EventArgs e)
        {
            this._footerFocusConstructionList.footerFocusConstruction.Clear();
            this.SettingFooterFocusConstructionListFromDictionary(this._footerItemsDictionary, ref this._footerFocusConstructionList.footerFocusConstruction);
            this.SettingDataTableFromFooterFocusConstructionList(this._footerFocusConstructionList);
            this._footerFocusView = this._footerFocusDataTable.DefaultView;
            this.ultraGrid_FooterControl.DataSource = this._footerFocusView;
        }

        /// <summary>
        /// ���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_UpFooter_Click(object sender, EventArgs e)
        {
            if (this.ultraGrid_FooterControl.ActiveRow != null)
            {
                ultraGrid_FooterControl.BeginUpdate();
                try
                {
                    if (this.UpDownFooterRow(0, this.ultraGrid_FooterControl.ActiveRow.Index))
                    {
                        this.ultraGrid_FooterControl.ActiveCell = this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Cells[this._footerFocusDataTable.EnterStopColumn.ColumnName];
                        this.ultraGrid_FooterControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.ultraGrid_FooterControl.ActiveCell = null;
                        this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Selected = true;
                    }
                }
                finally
                {
                    ultraGrid_FooterControl.EndUpdate();
                }
            }
        }

        /// <summary>
        /// ���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_DownFooter_Click(object sender, EventArgs e)
        {
            if (this.ultraGrid_FooterControl.ActiveRow != null)
            {
                ultraGrid_FooterControl.BeginUpdate();
                try
                {
                    if (this.UpDownFooterRow(1, this.ultraGrid_FooterControl.ActiveRow.Index))
                    {
                        this.ultraGrid_FooterControl.ActiveCell = this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Cells[this._footerFocusDataTable.EnterStopColumn.ColumnName];
                        this.ultraGrid_FooterControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.ultraGrid_FooterControl.ActiveCell = null;
                        this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Selected = true;
                    }
                }
                finally
                {
                    ultraGrid_FooterControl.EndUpdate();
                }
            }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        // 2010/06/15 Add >>>
        /// <summary>
        /// RC�A�g�t�H���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RCLinkDirGuide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "�t�H���_��I�����ĉ������B";
            //fbd.RootFolder = Environment.SpecialFolder.;
            fbd.SelectedPath = this.tEdit_RCLinkDirectory.Text.Trim();
            fbd.ShowNewFolderButton = true;
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.tEdit_RCLinkDirectory.Text = fbd.SelectedPath;
            }
        }
        // 2010/06/15 Add <<<

        // --- ADD 2010/06/02 ---------->>>>>

        /// <summary>
        /// ���א���ActiveRow�ύX�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : 2010/06/02 ���� PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.1</br>
        /// </remarks>
        private void uGrid_DetailControl_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            setButtonEnable();

        }

        /// <summary>
        /// �{�^���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : 2010/06/02 ���� PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.1</br>
        /// </remarks>
        private void setButtonEnable()
        {
            // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
            //if (this.uGrid_DetailControl.ActiveRow.Index == 0 || this.uGrid_DetailControl.ActiveRow.Index == 1 || this.uGrid_DetailControl.ActiveRow.Index == 2)
            if (this.uGrid_DetailControl.ActiveRow.Index == 0 || 
                this.uGrid_DetailControl.ActiveRow.Index == 1 || 
                this.uGrid_DetailControl.ActiveRow.Index == 2 ||
                this.uGrid_DetailControl.ActiveRow.Index == (this._salesSlipInputConstructionAcs.EffectiveList.Count - 1))
            // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
            {
                this.ultraButton2.Enabled = false;
                this.ultraButton1.Enabled = false;
            }
            else if (this.uGrid_DetailControl.ActiveRow.Index == 3)
            {
                this.ultraButton2.Enabled = false;
                this.ultraButton1.Enabled = true;
            }
            // ADD 2013/02/14 T.Miyamoto ------------------------------>>>>>
            else if (this.uGrid_DetailControl.ActiveRow.Index == (this._salesSlipInputConstructionAcs.EffectiveList.Count - 2))
            {
                this.ultraButton2.Enabled = true;
                this.ultraButton1.Enabled = false;
            }
            // ADD 2013/02/14 T.Miyamoto ------------------------------<<<<<
            else
            {
                this.ultraButton2.Enabled = true;
                this.ultraButton1.Enabled = true;
            }
        }
        // --- ADD 2010/06/02 ----------<<<<<

        // --- ADD 2010/07/16 ---------->>>>>
        private void uGrid_DetailControl_AfterCellActivate(object sender, EventArgs e)
        {
            setButtonEnable();
        }

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : 2010/08/13 杍^ ��Q�E���ǑΉ�(�W�������[�X�Č�)No.14</br>
        /// </remarks>
        private void uGrid_FunctionDetailControl_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_FunctionDetailControl.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            this.uGrid_FunctionDetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���ږ�
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �\���L��
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Width = 40;
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �Œ���؂���ݒ�
            this.uGrid_FunctionDetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }
        // --- ADD 2010/08/13 ----------<<<<<
        // --- ADD 2010/07/16 ----------<<<<<

        //>>>2010/08/06
        /// <summary>
        /// tComboEditor_EmployeeCdDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_EmployeeCdDiv_ValueChanged(object sender, EventArgs e)
        {
            this.EmployeeCdDiv_ValueChanged();
        }

        /// <summary>
        /// �]�ƈ��敪�ύX���C�x���g
        /// </summary>
        private void EmployeeCdDiv_ValueChanged()
        {
            int employeeCdDiv = this.GetComboEditorValue(this.tComboEditor_EmployeeCdDiv);

            switch (employeeCdDiv)
            {
                case 0:
                    this.tEdit_EmployeeCode.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                    this.tEdit_EmployeeCode.Enabled = false;
                    this.uButton_EmployeeGuide.Enabled = false;
                    break;
                case 1:
                    this.tEdit_EmployeeCode.Clear();
                    this.tEdit_EmployeeCode.Enabled = false;
                    this.uButton_EmployeeGuide.Enabled = false;
                    break;
                case 2:
                    this.tEdit_EmployeeCode.Enabled = true;
                    this.uButton_EmployeeGuide.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// tComboEditor_FrontEmployeeCdDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_FrontEmployeeCdDiv_ValueChanged(object sender, EventArgs e)
        {
            this.FrontEmployeeCdDiv_ValueChanged();
        }

        /// <summary>
        /// �󒍎ҋ敪�ύX���C�x���g
        /// </summary>
        private void FrontEmployeeCdDiv_ValueChanged()
        {
            int employeeCdDiv = this.GetComboEditorValue(this.tComboEditor_FrontEmployeeCdDiv);

            switch (employeeCdDiv)
            {
                case 0:
                    this.tEdit_FrontEmployeeCd.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                    this.tEdit_FrontEmployeeCd.Enabled = false;
                    this.uButton_FrontEmployeeGuide.Enabled = false;
                    break;
                case 1:
                    this.tEdit_FrontEmployeeCd.Clear();
                    this.tEdit_FrontEmployeeCd.Enabled = false;
                    this.uButton_FrontEmployeeGuide.Enabled = false;
                    break;
                case 2:
                    this.tEdit_FrontEmployeeCd.Enabled = true;
                    this.uButton_FrontEmployeeGuide.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// tComboEditor_SalesInputCdDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SalesInputCdDiv_ValueChanged(object sender, EventArgs e)
        {
            this.SalesInputCdDiv_ValueChanged();
        }

        /// <summary>
        /// ���s�ҋ敪�ύX���C�x���g
        /// </summary>
        private void SalesInputCdDiv_ValueChanged()
        {
            int employeeCdDiv = this.GetComboEditorValue(this.tComboEditor_SalesInputCdDiv);

            switch (employeeCdDiv)
            {
                case 0:
                    this.tEdit_SalesInputCd.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                    this.tEdit_SalesInputCd.Enabled = false;
                    this.uButton_SalesInputGuide.Enabled = false;
                    break;
                case 1:
                    this.tEdit_SalesInputCd.Clear();
                    this.tEdit_SalesInputCd.Enabled = false;
                    this.uButton_SalesInputGuide.Enabled = false;
                    break;
                case 2:
                    this.tEdit_SalesInputCd.Enabled = true;
                    this.uButton_SalesInputGuide.Enabled = true;
                    break;
            }
        }
        //<<<2010/08/06

        // --- ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� ----->>>>>
        /// <summary>
        /// ���Ӑ���K�C�h�\���敪�ύX���C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <remarks>
        /// <br>Note       : 2021/06/21 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ�K�C�h�\���̑Ή�</br>
        /// </remarks>
        private void tComboEditor_CustomerGuidDisplay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tComboEditor_CustomerGuidDisplay.SelectedIndex == CusGuidDisChangeMsgValue)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    CusGuidDisChangeMsg,
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        // --- ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� -----<<<<<
        //----- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�------->>>>>
        /// <summary>
        /// pdf�v�����^�ύX���C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <remarks>
        /// <br>Update Note: 2022/04/26 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11870080-00</br>
        /// <br>           : PMKOBETSU-4208 �d�q����Ή�</br> 
        /// </remarks>
        private void tComboEditor_PdfPrinter_ValueChanged(object sender, EventArgs e)
        {
            // pdf�v�����^�[�ԍ�
            this.tNedit_PdfPrinterNumber.SetInt(_salesSlipInputConstructionAcs.GetPrinterNumber(tComboEditor_PdfPrinter.SelectedIndex));
        }
        /// <summary>
        /// ����t�@�C���擾
        /// </summary>
        /// <remarks>
        /// <br>Note         : ����t�@�C���擾</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private void SetPdfPrinter()
        {
            try
            {
                // PDF�v�����^�𐧌�
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFPRINTERSETTINGENABLE)))
                {
                    this.tComboEditor_PdfPrinter.Enabled = true;
                    this.SetComboEditorItemIndex(this.tComboEditor_PdfPrinter, this._salesSlipInputConstructionAcs.PdfPrinter, 0);
                    this.tNedit_PdfPrinterNumber.Value = this._salesSlipInputConstructionAcs.PdfPrinterNumber;
                }
                else
                {
                    this.tComboEditor_PdfPrinter.Enabled = false;
                    //�f�t�H���g�l�F�u0:Windows�W���v
                    this.tComboEditor_PdfPrinter.SelectedIndex = 0;
                    // pdf�v�����^�[�ԍ�
                    this.tNedit_PdfPrinterNumber.SetInt(_salesSlipInputConstructionAcs.GetPrinterNumber(tComboEditor_PdfPrinter.SelectedIndex));
                }
            }
            catch
            {
                this.tComboEditor_PdfPrinter.Enabled = false;
                this.tComboEditor_PdfPrinter.SelectedIndex = 0;
                // pdf�v�����^�[�ԍ�
                this.tNedit_PdfPrinterNumber.SetInt(_salesSlipInputConstructionAcs.GetPrinterNumber(tComboEditor_PdfPrinter.SelectedIndex));
            }
        }

        //----- ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�-------<<<<<

        //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� ----->>>>>
        private void ultraOptionSet_ReturnRedNote1_ValueChanged(object sender, EventArgs e)
        {
            if (this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote1) != ReturnRedNote_OPTIONAL)
            {
                tEdit_ReturnRedNote1.Enabled = false;
            }
            else
            {
                tEdit_ReturnRedNote1.Enabled = true;
            }
        }

        private void ultraOptionSet_ReturnRedNote2_ValueChanged(object sender, EventArgs e)
        {
            if (this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote2) != ReturnRedNote_OPTIONAL)
            {
                tEdit_ReturnRedNote2.Enabled = false;
            }
            else
            {
                tEdit_ReturnRedNote2.Enabled = true;
            }
        }

        private void ultraOptionSet_ReturnRedNote3_ValueChanged(object sender, EventArgs e)
        {
            if (this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote3) != ReturnRedNote_OPTIONAL)
            {
                tEdit_ReturnRedNote3.Enabled = false;
            }
            else
            {
                tEdit_ReturnRedNote3.Enabled = true;
            }
        }
        //--- ADD �c������ 2022/10/05 �C���{�C�X�c�Ή� -----<<<<<

        # endregion
    }
}