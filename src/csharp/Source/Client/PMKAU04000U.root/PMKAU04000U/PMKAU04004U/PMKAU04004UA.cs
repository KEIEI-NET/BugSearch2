/// <br>Update Note: 2012/05/24�z�M�� 2012/04/01 Redmine#29250 </br>
/// <br>             ���Ӑ�d�q�����@�f�[�^�X�V�����̒ǉ��ɂ���(���׍X�V�����̒ǉ�)</br>
/// <br>Update Note:                  2012/06/01 30744 ���� ����q</br>
/// <br>             ���Ӑ�d�q�����@�c���ꗗ�\���̒��o���_�ǉ�</br>
/// <br>Update Note:                  2012/08/22 FSI�����@�v</br>
/// <br>             ���Ӑ�d�q�����@���[�U�[�ݒ�̎d�����⊮�����ǉ�</br>
/// <br>Update Note:                  2013/04/19 �{�{ ����</br>
/// <br>             ���Ӑ�d�q�����@�ԓ`���s�E�Ĕ��s���̈���m�F�_�C�A���O�\���ݒ��ǉ�</br>
/// <br>Update Note:                  2013/05/20 #35729 liusy</br>
/// <br>             ���Ӑ�d�q�����@ �e�L�X�g�o�͎��̘a��Ή�</br>
/// <br>Update Note:                  2014/02/05 �{�{ ����</br>
/// <br>             ���Ӑ�d�q�����@�d�|�ꗗ ��2290</br>
/// <br>Update Note:                  K2014/05/28 �ђ��} </br>
/// <br>           : ���Ӑ�d�q����  Redmine#42764 ����e�X�g��Q�Ή��B��������ʑΉ�</br>
/// <br>Update Note:                  K2014/06/04 ���R </br>
/// <br>           : ���Ӑ�d�q����  Redmine#42764 ��������ʎ���e�X�g��Q�Ή���8</br>
/// <br>Update Note:                  2015/03/16 �i�N</br>
/// <br>           : ���Ӑ�d�q����  �ϊ���i�� �����l�̔�\���Ή�</br>
/// <br>UpdateNote : 2015/02/05 ������ </br>
/// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
/// <br>UpdateNote : 2015/02/25 ������ Redmine#44701 No.1 </br>
/// <br>           : �e�L�X�g�o�͌��������Ȃ��ʒu�̒���</br>
/// <br>UpdateNote : 2015/03/03 ������ Redmine#44701</br>
/// <br>           : ���o���������Ȃ��`�F�b�N���̃��b�Z�[�W�̕ύX</br>
/// <br>Update Note: K2015/04/27 �� </br>
/// <br>�Ǘ��ԍ�   : 11100842-00 �����Z���i���̌ʊJ���˗� </br>
/// <br>           : ���Ӑ�d�q������񔄉���ǉ�����B�����Z���i���I�v�V�������L���̏ꍇ�̂݁B</br>
/// <br>Update Note: ���Ӑ�d�q����  K2015/06/16 鸏� </br>
/// <br>�Ǘ��ԍ�   :                 11101427-00</br>
/// <br>           :                 ���C�S���̌ʊJ���˗� </br>
/// <br>           :                 ���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
/// <br>Update Note:                  2015/09/17 �c����</br>
/// <br>           : ���Ӑ�d�q����  Redmine#47006 ���Ӑ�d�q�����̏�Q�Ή�</br>
/// <br>           :                 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
/// <br>Update Note:                  2015/11/13 ���O</br>
/// <br>           : ���Ӑ�d�q����  Redmine#47636 ���C�S���ƃ����Z���i���}�[�W</br>
/// <br>           :                 �}�[�W������A���Ӑ�d�q�����̃e�L�X�g�o�͂ŁA�n�悪�o�͂���Ȃ��̏�Q�Ή�</br>
/// <br>Update Note: K2015/11/17  ���� </br>
/// <br>�Ǘ��ԍ�   : 11170188-00  </br>
/// <br>           : Redmine#47636�@#6�ݒ�����X�V���Ȃ��ꍇ�A�ݒ�O��xml�t�@�C���Ɣ�r�l���ς���Ă���̏�Q�Ή��B</br>
/// <br>Update Note: 2018/09/04 杍^</br>
/// <br>�Ǘ��ԍ�   : 11470152-00</br>
/// <br>           : ���������\���@�\�ǉ��Ή�</br>
/// <br>Update Note: 2022/05/05 ����</br>
/// <br>�Ǘ��ԍ�   : 11870080-00</br>
/// <br>           : �[�i���d�q����A�g�Ή�</br>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;     // UserSettingController�Ɏg�p
//using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
using Broadleaf.Application.Controller;
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
// --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
// --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

namespace Broadleaf.Windows.Forms
{
    public partial class PMKAU04004UA : Form
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
        // �ݒ�t�@�C����̗�ԍ���3���[���l��
        static public readonly int ct_ColumnCountLength = 3;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        # region const
        // �p�^�[���폜�m�F���b�Z�[�W
        private const string MSG_CONFIRM_DELETE_PATTERN = "�I�𒆂̏o�̓p�^�[�����폜���Ă�낵���ł����H";
        // �t�@�C���������̓��b�Z�[�W
        private const string MSG_OUTPUTTEXT_NOFILENAME = "�t�@�C��������͂��ĉ�����";
        
        // �p�^�[�������̓��b�Z�[�W
        private const string MSG_OUTPUTTEXT_NOPATTERN = "�o�̓p�^�[������͂��ĉ�����";
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
        ///<summary> PDF�v�����^�Ǘ��ԍ� �K�{���̓`�F�b�N ���b�Z�[�W</summary>
        private const string MSG_PDFPRINTERNUMBER_NOPATTERN = "�v�����^�ݒ�ŁAPDF�v�����^�𐳂����o�^���Ă��������B";
        ///<summary> PDF�v�����^�Ǘ��ԍ� �K�{���̓`�F�b�N ���b�Z�[�W</summary>
        private const string MSG_PDFPRINTERWAIT_NOPATTERN = "PDF�v�����^�ҋ@���Ԃ�ݒ肵�ĉ������B";
        ///<summary> �uPDF�o�͂��Ȃ��v���[�h</summary>
        private const int MODE_NONE = 1;
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
        # region event
        /// <summary>�`�[�O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingSlipGrid;
        /// <summary>���׃O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingDetailGrid;
        /// <summary>�ԓ`�O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingRedSlipGrid;
        /// <summary>�c���O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingBalanceGrid;

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        public event EventHandler TextOutputEvent;
        //----- ADD 2015/02/05 ������ --------------------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD

        #region �v���C�x�[�g�ϐ�

        // �ݒ�ۑ��p���ʃI�u�W�F�N�g

        //private UserSettingController uSettingControl;

        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKAU04000U_Construction.XML";

        //----- DEL K2014/06/04 By ���R Redmine42764 ��8 -------->>>>>
        ////----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
        ///// <summary>�`�[�O���b�h���n�R�[�h(��������p)</summary>
        //private const string XML_SLIP_CODE_TOUA = "1039104010410000000110421043000200030004000500060007000900100011001200130014001500160017001800190020002100220023002400250026002700280029003000311044003210450033003400350036104600371047003810481049105010510008";
        ///// <summary>���׃O���b�h���n�R�[�h(��������p)</summary>
        //private const string XML_DETAIL_CODE_TOUA = "107310741075000000010002107610770003107800040005107900060007000800090010001100120013001400151080001600170018108110820019108300200021002200240025002600270028002900300031003200330034003500360037003800390040004110840042108500431086004400451087004600470048004900500051005200530054005500560057005800590060108800610062108900631090006400650066109100670068109200231093109410951096109710981099110011011102110311041105110611071108110900691110111111121113111411151116111711180070007100721119112011211122";        
        ////----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<
        //----- DEL K2014/06/04 By ���R Redmine42764 ��8 --------<<<<<

        // �f�[�^�Z�b�g
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
        //private ExportColumnDataSet _dataSet;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        private CustPtrSalesDetailDataSet _dataSet;
        private int prevDividerChar;
        private int prevParenthesis;
        private int prevTieNumeric;
        private int prevTieChar;
        private int prevTitleLine;
        private int prevSlipNote;
        private int prevSlipNote2;
        private int prevSlipNote3;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

        // ���[�U�[�ݒ�
        private CustPtrSalesUserConst _userSetting;
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
        /// <summary>PDF�o�͐ݒ�̐ݒ荀�ځi���Ӑ�d�q�����j</summary>
        private const string ctPrint_PMKAU04001U_PDFOutputSettings_Xml = "PMKAU04001U_PDFOutputSettings.xml";
        /// <summary>PDF�o�͐ݒ�̐ݒ荀�ځi���Ӑ�d�q�����j</summary>
        private const string ctPrint_PMKAU04001U_PDFPrinterSettingEnable_Xml = "PMKAU04001U_PDFPrinterSettingEnable.xml";
        /// <summary>Windows�W�� PDF�v�����^���@Microsoft Print to PDF</summary>
        private const string ctBase_PrintName = "MICROSOFT PRINT TO PDF";
        /// <summary>���̑� Cube PDF�v�����^���@CUBEPDF</summary>
        private const string ctOther_CubePrintName = "CUBEPDF";
        /// <summary> PDF�o�͐ݒ�t�@�C���\����</summary>
        private eBooksOutputSetting _eBooksOutputSetting;
        /// <summary> �v�����^�ݒ�A�N�Z�X�N���X</summary>
        private PrtManageAcs _prtManageAcs = null;
        /// <summary> �v�����^Dic</summary>
        private Dictionary<string, string> _printDic = null;

        /// <summary>�X�N���v�gEnum(0:Windows�W�� Microsoft Print to PDF /1:���̑� PRIMOPDF�ECUBEPDF)</summary>
        private enum pdfPrinterEnum : int
        {
            BaseSetting_Xml = 0,�@�@// Windows�W��
            OtherSetting_Xml = 1,   // ���̑�
        }

        /// <summary>�o�͓`�[�敪 0:�����I���Ȃ�/1:�ԓ`/2:�Ĕ��s/3:�����I������ </summary>
        private enum outPutSlipTypeEnum : int
        {
            No = 0,                 // 0:�����I���Ȃ�
            DebitNoteChecked = 1,   // �ԓ`�̂�
            RePrintChecked = 2,     // �Ĕ��s
            All = 3,                // �����I������
        }

        // PDF�o�͋敪�f�t�H���g�l �u���Ȃ��v
        private const string DEFAULT_PDFOUTPUT_VALUE = "1";
        // �o�͓`�[�敪_�ԓ`
        private const string DEFAULT_OUTPUTSLIPTYPE_VALUE = "1";
        // PDF�v�����^�[
        private const string DEFAULT_PRINTER_VALUE = "0";
        // PDF�v�����^�[No
        private const string DEFAULT_PRINTERNO_VALUE = "9999";
        // PDF�v�����^�[�ҋ@����
        private const string DEFAULT_PRINTERWAUTTIME_VALUE = "0";

        /// <summary>�d�q����A�g�I�v�V����(OPT-PM03300)</summary>
        public int _opt_EBooksLink;
        /// <summary>�d�q����A�g�I�v�V����(OPT-PM03300)</summary>
        public int Opt_EBooksLink
        {
            get { return _opt_EBooksLink; }
            set { _opt_EBooksLink = value; }
        }
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

        // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
        //// ���[�U�[�ݒ�
        //private int _outputStyle;
        //
        //// **** �X�L���ݒ�p�N���X ****
        //private ControlScreenSkin _controlScreenSkin;
        // --- DEL 2020/12/21 �x���Ή� ----------<<<<<

        // ��؂蕶��
        private string _divider;

        // �p�^�[��
        private string[] _outputPattern;

        // �I������Ă���p�^�[����
        private string _selectedPattern;

        // �`�[�O���b�h�̐ݒ�
        private string _gridSetting_Slip = string.Empty;

        // ���׃O���b�h�̐ݒ�
        private string _gridSetting_Detail = string.Empty;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        // �`�[����index�f�B�N�V���i��
        private Dictionary<string, int> _columnIndexDicOfSlip;
        // ���׍���index�f�B�N�V���i��
        private Dictionary<string, int> _columnIndexDicOfDetail;
        // �`�[�O���b�h�J�����E�R���N�V����
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _slipColCollection;
        // ���׃O���b�h�J�����E�R���N�V����
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _detailColCollection;
        // �t�H�[�J�X����
        private FocusControl _focusControl1;
        private FocusControl _focusControl2;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        // �O���b�h�E�J�����`���[�U�[����
        GridColumnChooserControl _gridColumnChooserControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>> 
        // ���؎����ԃI�v�V����
        private bool _opFujikiCustom = false;
        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<

        //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
        /// <summary>�����I�v�V�������</summary>
        private int _opt_Toua;
        /// <summary>�Ԏ탁�[�J�[�R�[�h�N�����̖�</summary>
        private const string CL_CARMAKERCODE_NAME = "MakerCode";

        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
        /// <summary>���C�S���I�v�V�������</summary>
        private int _opt_Meigo;
        /// <summary>�n��</summary>
        private const string SALESAREA_NAME = "SalesAreaName";
        /// <summary>���̓R�[�h1</summary>
        private const string CUSTANALYSCODE1_NAME = "CustAnalysCode1";
        /// <summary>���̓R�[�h2</summary>
        private const string CUSTANALYSCODE2_NAME = "CustAnalysCode2";
        /// <summary>���̓R�[�h3</summary>
        private const string CUSTANALYSCODE3_NAME = "CustAnalysCode3";
        /// <summary>���̓R�[�h4</summary>
        private const string CUSTANALYSCODE4_NAME = "CustAnalysCode4";
        /// <summary>���̓R�[�h5</summary>
        private const string CUSTANALYSCODE5_NAME = "CustAnalysCode5";
        /// <summary>���̓R�[�h6</summary>
        private const string CUSTANALYSCODE6_NAME = "CustAnalysCode6";
        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

        /// <summary>�ݒ�XML�t�@�C���p�X</summary>
        private const string XML_FILE_PATH = "UISettings\\";
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<

        // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ---->>>>>
        /// <summary>�����Z���i</summary>
        private int _opt_Momose;
        /// <summary>��񔄉��N�����̖�</summary>
        private const string CL_SECONDSALEPRICE_NAME = "SecondSalePrice";
        // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ----<<<<<

        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        public CustPtrSalesUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
        /// <summary>
        /// �`�[�O���b�h�J�����E�R���N�V���� 
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection SlipColCollection
        {
            get { return _slipColCollection; }
            set { _slipColCollection = value;}
        }
        /// <summary>
        /// ���׃O���b�h�J�����E�R���N�V����
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection DetailColCollection
        {
            get { return _detailColCollection; }
            set { _detailColCollection = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
        /// <summary>
        /// ��؂蕶��
        /// </summary>
        private int DividerChar
        {
            get
            {
                if ( rb_DividerChar_0.Checked )
                {
                    return 0;
                }
                else if ( rb_DividerChar_1.Checked )
                {
                    return 1;
                }
                else if ( rb_DividerChar_2.Checked )
                {
                    return 2;
                }
                else
                {
                    rb_DividerChar_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_DividerChar_0.Checked = true;
                        tEdit_DividerChar.Enabled = false;
                        break;
                    case 1:
                        rb_DividerChar_1.Checked = true;
                        tEdit_DividerChar.Enabled = true;
                        break;
                    case 2:
                        rb_DividerChar_2.Checked = true;
                        tEdit_DividerChar.Enabled = false;
                        break;
                }
            }
        }
        /// <summary>
        /// ���蕶��
        /// </summary>
        private int Parenthesis
        {
            get
            {
                if ( rb_Parenthesis_0.Checked )
                {
                    return 0;
                }
                else if ( rb_Parenthesis_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_Parenthesis_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_Parenthesis_0.Checked = true;
                        tEdit_ParenthesisChar.Enabled = false;
                        break;
                    case 1:
                        rb_Parenthesis_1.Checked = true;
                        tEdit_ParenthesisChar.Enabled = true;
                        break;
                }
            }
        }
        /// <summary>
        /// ���l����
        /// </summary>
        private int TieNumeric
        {
            get
            {
                if ( rb_TieNumeric_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TieNumeric_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_TieNumeric_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_TieNumeric_0.Checked = true;
                        break;
                    case 1:
                        rb_TieNumeric_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        private int TieChar
        {
            get
            {
                if ( rb_TieChar_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TieChar_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_TieChar_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_TieChar_0.Checked = true;
                        break;
                    case 1:
                        rb_TieChar_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// �^�C�g���s
        /// </summary>
        private int TitleLine
        {
            get
            {
                if ( rb_TitleLine_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TitleLine_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_TitleLine_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_TitleLine_0.Checked = true;
                        break;
                    case 1:
                        rb_TitleLine_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// ���l�P
        /// </summary>
        private int SlipNote
        {
            get
            {
                if ( rb_SlipNote_0.Checked )
                {
                    return 0;
                }
                else if ( rb_SlipNote_1.Checked )
                {
                    return 1;
                }
                else if ( rb_SlipNote_2.Checked )
                {
                    return 2;
                }
                // ---------ADD 2010/01/29--------->>>>>
                else if (rb_SlipNote_3.Checked)
                {
                    return 3;
                }
                // ---------ADD 2010/01/29---------<<<<<
                else
                {
                    rb_SlipNote_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_SlipNote_0.Checked = true;
                        break;
                    case 1:
                        rb_SlipNote_1.Checked = true;
                        break;
                    case 2:
                        rb_SlipNote_2.Checked = true;
                        break;
                    // ---------ADD 2010/01/29--------->>>>>
                    case 3:
                        rb_SlipNote_3.Checked = true;
                        break;
                    // ---------ADD 2010/01/29---------<<<<<
                }
            }
        }
        /// <summary>
        /// ���l�Q
        /// </summary>
        private int SlipNote2
        {
            get
            {
                if ( rb_SlipNote2_0.Checked )
                {
                    return 0;
                }
                else if ( rb_SlipNote2_1.Checked )
                {
                    return 1;
                }
                else if ( rb_SlipNote2_2.Checked )
                {
                    return 2;
                }
                // ---------ADD 2010/01/29--------->>>>>
                else if (rb_SlipNote2_3.Checked)
                {
                    return 3;
                }
                // ---------ADD 2010/01/29---------<<<<<
                else
                {
                    rb_SlipNote2_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_SlipNote2_0.Checked = true;
                        break;
                    case 1:
                        rb_SlipNote2_1.Checked = true;
                        break;
                    case 2:
                        rb_SlipNote2_2.Checked = true;
                        break;
                    // ---------ADD 2010/01/29--------->>>>>
                    case 3:
                        rb_SlipNote2_3.Checked = true;
                        break;
                    // ---------ADD 2010/01/29---------<<<<<
                }
            }
        }
        /// <summary>
        /// ���l�R
        /// </summary>
        private int SlipNote3
        {
            get
            {
                if ( rb_SlipNote3_0.Checked )
                {
                    return 0;
                }
                else if ( rb_SlipNote3_1.Checked )
                {
                    return 1;
                }
                else if ( rb_SlipNote3_2.Checked )
                {
                    return 2;
                }
                // ---------ADD 2010/01/29--------->>>>>
                else if (rb_SlipNote3_3.Checked)
                {
                    return 3;
                }
                // ---------ADD 2010/01/29---------<<<<<
                else
                {
                    rb_SlipNote3_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_SlipNote3_0.Checked = true;
                        break;
                    case 1:
                        rb_SlipNote3_1.Checked = true;
                        break;
                    case 2:
                        rb_SlipNote3_2.Checked = true;
                        break;
                    // ---------ADD 2010/01/29--------->>>>>
                    case 3:
                        rb_SlipNote3_3.Checked = true;
                        break;
                    // ---------ADD 2010/01/29---------<<<<<
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD
        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �`�[����m�F�_�C�A���O(�ԓ`���s)
        /// </summary>
        private bool RedPrintDialog
        {
            get
            {
                if (tComboEditor_RedPrintDialog.SelectedIndex == 0) //�\�����Ȃ�
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case false:
                        tComboEditor_RedPrintDialog.SelectedIndex = 0; //�\�����Ȃ�
                        break;
                    case true:
                        tComboEditor_RedPrintDialog.SelectedIndex = 1; //�\������
                        break;
                }
            }
        }
        /// <summary>
        /// �`�[����m�F�_�C�A���O(�Ĕ��s)
        /// </summary>
        private bool ReisssuePrintDialog
        {
            get
            {
                if (tComboEditor_ReisssuePrintDialog.SelectedIndex == 0) //�\�����Ȃ�
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case false:
                        tComboEditor_ReisssuePrintDialog.SelectedIndex = 0; //�\�����Ȃ�
                        break;
                    case true:
                        tComboEditor_ReisssuePrintDialog.SelectedIndex = 1; //�\������
                        break;
                }
            }
        }
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�------>>>>>
        /// <summary>
        /// �^�u����̏����ݒ�
        /// </summary>
        private int InitSelectDisplay
        {
            get
            {
                if (tComboEditor_InitSelectDisplay.SelectedIndex == 0) //�c���Ɖ���\��
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        tComboEditor_InitSelectDisplay.SelectedIndex = 0; //�c���Ɖ���\��
                        break;
                    case 1:
                        tComboEditor_InitSelectDisplay.SelectedIndex = 1; //���v�Ɖ���\��
                        break;
                }
            }
            //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<
        }

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <br>Update Note : K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>            : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>Update Note : K2015/11/17  ���� </br>
        /// <br>�Ǘ��ԍ�    : 11170188-00  </br>
        /// <br>            : Redmine#47636�@#6�ݒ�����X�V���Ȃ��ꍇ�A�ݒ�O��xml�t�@�C���Ɣ�r�l���ς���Ă���̏�Q�Ή��B</br>
        public PMKAU04004UA()
        {
            InitializeComponent();
            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
            #region �� �d�q����A�g�I�v�V����(OPT-PM03300)
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus eBooksLinkOpt;
            eBooksLinkOpt = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);
            if (eBooksLinkOpt == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_EBooksLink = (int)Option.ON;
            }
            else
            {
                this._opt_EBooksLink = (int)Option.OFF;
            }
            #endregion
            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this._dataSet = new CustPtrSalesDetailDataSet();

            //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
            #region ��������I�v�V����
            // ��������ʃI�v�V�����R�[�h�̒ǉ�
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus touaCustom;
            touaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ToaCustom);
            if (touaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Toua = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Toua = Convert.ToInt32(Option.OFF);
            }
            #endregion

            // �����Z���i���̌ʃI�v�V�����R�[�h�̒ǉ�
            #region �����Z���i�I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus momoseCustom;
            momoseCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MomoseCustom);
            if (momoseCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Momose = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Momose = Convert.ToInt32(Option.OFF);
            }
            #endregion

            #region ���C�S���I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus meigoCustom;
            meigoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoLedgerCustom);
            if (meigoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Meigo = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Meigo = Convert.ToInt32(Option.OFF);
            }
            #endregion
            //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<


            // �`�[����index
            int i = 0; //ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�
            _columnIndexDicOfSlip = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.SalesList.Columns.Count; index++ )
            {
                //_columnIndexDicOfSlip.Add(_dataSet.SalesList.Columns[index].ColumnName, index);//DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�
                //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
                if (this._opt_Toua == Convert.ToInt32(Option.OFF) && _dataSet.SalesList.Columns[index].ColumnName == CL_CARMAKERCODE_NAME)
                {
                    continue;

                }

                if (_opt_Meigo == (Int32)Option.OFF)
                {

                    if (_dataSet.SalesList.Columns[index].ColumnName == SALESAREA_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE1_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE2_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE3_NAME ||
                         _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE4_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE5_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE6_NAME)
                    {
                        continue;
                    }
                }
                
                _columnIndexDicOfSlip.Add( _dataSet.SalesList.Columns[index].ColumnName, i );
                i++;
                //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<
            }

            // ���׍���index
            int ii = 0;//ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�
            _columnIndexDicOfDetail = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.SalesDetail.Columns.Count; index++ )
            {
                //_columnIndexDicOfDetail.Add(_dataSet.SalesDetail.Columns[index].ColumnName, index);//DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�
                //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
                if (this._opt_Momose == Convert.ToInt32(Option.OFF) && _dataSet.SalesDetail.Columns[index].ColumnName == CL_SECONDSALEPRICE_NAME)
                {
                    continue;
                }
                if (_opt_Meigo == (Int32)Option.OFF)
                {

                    if (_dataSet.SalesDetail.Columns[index].ColumnName == SALESAREA_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE1_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE2_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE3_NAME ||
                         _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE4_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE5_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE6_NAME)
                    {
                        continue;
                    }
                }
                
                _columnIndexDicOfDetail.Add( _dataSet.SalesDetail.Columns[index].ColumnName, ii );
                ii++;
                //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<
            }

            this._userSetting = new CustPtrSalesUserConst();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
            // �t�H�[�J�X����(�e�L�X�g�o�͐ݒ�^�u)
            _focusControl1 = new FocusControl();
            _focusControl1.AddLine( tComboEditor_OutputStyle );
            _focusControl1.AddLine( rb_DividerChar_0, rb_DividerChar_1, tEdit_DividerChar, rb_DividerChar_2 );
            _focusControl1.AddLine( rb_Parenthesis_0, rb_Parenthesis_1, tEdit_ParenthesisChar );
            _focusControl1.AddLine( rb_TieNumeric_0, rb_TieNumeric_1 );
            _focusControl1.AddLine( rb_TieChar_0, rb_TieChar_1 );
            _focusControl1.AddLine( rb_TitleLine_0, rb_TitleLine_1 );
            _focusControl1.AddLine( tComboEditor_OutputType );
            //add by liusy #35729 2013/05/20 -----<<<<<
            _focusControl1.AddLine( tComboEditor_DateType );
            //add by liusy #35729 2013/05/20 ----->>>>>

            _focusControl1.AddLine(uCheckEditor_RetSlipMinus_Saleslip); // ADD 2015/09/17 �c���� Redmine#47006
            _focusControl1.AddLine(uCheckEditor_RetSlipMinus_Meisai); // ADD 2015/09/17 �c���� Redmine#47006

            // �t�H�[�J�X����(�ԓ`�ݒ�^�u)
            _focusControl2 = new FocusControl();
            //_focusControl2.AddLine( rb_SlipNote_0, rb_SlipNote_1, rb_SlipNote_2 );// DEL 2010/01/29
            _focusControl2.AddLine(rb_SlipNote_0, rb_SlipNote_1, rb_SlipNote_2, rb_SlipNote_3);// ADD 2010/01/29
            _focusControl2.AddLine( tEdit_SlipNote );
            //_focusControl2.AddLine( rb_SlipNote2_0, rb_SlipNote2_1, rb_SlipNote2_2 );// DEL 2010/01/29
            _focusControl2.AddLine(rb_SlipNote2_0, rb_SlipNote2_1, rb_SlipNote2_2, rb_SlipNote2_3);// ADD 2010/01/29
            _focusControl2.AddLine( tEdit_SlipNote2 );
            //_focusControl2.AddLine( rb_SlipNote3_0, rb_SlipNote3_1, rb_SlipNote3_2 );// DEL 2010/01/29
            _focusControl2.AddLine(rb_SlipNote3_0, rb_SlipNote3_1, rb_SlipNote3_2, rb_SlipNote3_3);// ADD 2010/01/29
            _focusControl2.AddLine( tEdit_SlipNote3 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            _focusControl2.AddLine(tComboEditor_RedPrintDialog);
            _focusControl2.AddLine(tComboEditor_ReisssuePrintDialog);
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            _gridColumnChooserControl = new GridColumnChooserControl();
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector );
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector2 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>>
            // ���؎����ԃI�v�V�����̔���
            this._opFujikiCustom = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FujikiCustom) > 0);
            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<

           // ----- DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
           // //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
           // #region ��������I�v�V����
           // // ��������ʃI�v�V�����R�[�h�̒ǉ�
           // Broadleaf.Application.Remoting.ParamData.PurchaseStatus touaCustom;
           // touaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ToaCustom);
           // if (touaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
           // {
           //     this._opt_Toua = Convert.ToInt32(Option.ON);
           // }
           // else
           // {
           //     this._opt_Toua = Convert.ToInt32(Option.OFF);
           // }
           // #endregion
           // //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<

           //// ---- ADD K2015/04/29 �� �e�L�X�g�o�͍��ڂɑ�񔄉���ǉ����� ---->>>>>
           // // �����Z���i���̌ʃI�v�V�����R�[�h�̒ǉ�
           // #region �����Z���i�I�v�V����
           // Broadleaf.Application.Remoting.ParamData.PurchaseStatus momoseCustom;
           // momoseCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MomoseCustom);
           // if (momoseCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
           // {
           //     this._opt_Momose = Convert.ToInt32(Option.ON);
           // }
           // else
           // {
           //     this._opt_Momose = Convert.ToInt32(Option.OFF);
           // }
           // #endregion
           // // ---- ADD K2015/04/29 BY �� �e�L�X�g�o�͍��ڂɑ�񔄉���ǉ����� ----<<<<<

           // //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
           // #region ���C�S���I�v�V����
           // Broadleaf.Application.Remoting.ParamData.PurchaseStatus meigoCustom;
           // meigoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoLedgerCustom);
           // if (meigoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
           // {
           //     this._opt_Meigo = Convert.ToInt32(Option.ON);
           // }
           // else
           // {
           //     this._opt_Meigo = Convert.ToInt32(Option.OFF);
           // }
           // #endregion
           // //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
           // ----- DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        /// <summary>
        /// �`�[����index�擾����
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetColumnPositionOfSlip( string[] patterns, string columnName )
        {
            if ( _columnIndexDicOfSlip.ContainsKey( columnName ) )
            {
                try
                {
                    return Int32.Parse( patterns[_columnIndexDicOfSlip[columnName]].ToString() );
                }
                catch
                {
                    return _columnIndexDicOfSlip.Count + 1;
                }
            }
            else
            {
                return _columnIndexDicOfSlip.Count + 1;
            }
        }
        /// <summary>
        /// ���׍���index�擾����
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetColumnPositionOfDetail( string[] patterns, string columnName )
        {
            if ( _columnIndexDicOfDetail.ContainsKey( columnName ) )
            {
                try
                {
                    return Int32.Parse( patterns[_columnIndexDicOfDetail[columnName]].ToString() );
                }
                catch
                {
                    return _columnIndexDicOfDetail.Count + 1;
                }
            }
            else
            {
                return _columnIndexDicOfDetail.Count + 1;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: K2015/11/17  ����</br>
        /// <br>           : ���Ӑ�d�q����  Redmine#47636�@#6�s��̑Ή�</br>
        /// <br>           : �ݒ�����X�V���Ȃ��ꍇ�A�ݒ�O��xml�t�@�C���Ɣ�r�l���ς���Ă���̏�Q�Ή�</br>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00</br>
        /// <br>           : ���������\���@�\�ǉ��Ή�</br>
        private void PMKAU04004UA_Load(object sender, EventArgs e)
        {
            // ��ʐݒ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //this._dataSet = new ExportColumnDataSet();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
            if (this._opt_Toua == Convert.ToInt32(Option.OFF) && this._dataSet.SalesList.Columns.Contains(CL_CARMAKERCODE_NAME))
            {
                this._dataSet.SalesList.Columns.Remove(CL_CARMAKERCODE_NAME);
            }

            // ��񔄉��R�[�h���폜���܂�
            if (this._opt_Momose == Convert.ToInt32(Option.OFF) && this._dataSet.SalesDetail.Columns.Contains(CL_SECONDSALEPRICE_NAME))
            {
                this._dataSet.SalesDetail.Columns.Remove(CL_SECONDSALEPRICE_NAME);
            }

            if (this._opt_Meigo == Convert.ToInt32(Option.OFF) && this._dataSet.SalesList.Columns.Contains(SALESAREA_NAME))
            {
                #region �`�[�\��
                this._dataSet.SalesList.Columns.Remove(SALESAREA_NAME);          //�n��
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE1_NAME);    //���̓R�[�h1
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE2_NAME);    //���̓R�[�h2
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE3_NAME);    //���̓R�[�h3
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE4_NAME);    //���̓R�[�h4
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE5_NAME);    //���̓R�[�h5
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE6_NAME);    //���̓R�[�h6
                #endregion

                #region ���ו\��
                this._dataSet.SalesDetail.Columns.Remove(SALESAREA_NAME);        //�n��
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE1_NAME);  //���̓R�[�h1 
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE2_NAME);  //���̓R�[�h2
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE3_NAME);  //���̓R�[�h3
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE4_NAME);  //���̓R�[�h4
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE5_NAME);  //���̓R�[�h5
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE6_NAME);  //���̓R�[�h6
                #endregion
            }
            //----- ADD K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<
            // �O���b�h���Ɏg�p����f�[�^�r���[���쐬
            DataView dViewSlip = new DataView( this._dataSet.SalesList );
            DataView dViewDetail = new DataView( this._dataSet.SalesDetail );


            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_ColumnItemSelector.DataSource = dViewSlip;
            this.uGrid_ColumnItemSelector2.DataSource = dViewDetail;

            // �ݒ�l������΃��[�h
            this._userSetting = new CustPtrSalesUserConst();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
            InitializeUserSetting( ref _userSetting );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD
            this.Deserialize();

            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
            // �d�q����A�g�^�u�������ݒ�
            InitEBooksLinkSetting();
            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

            // �p�^�[���E��؂蕶���E�ݒ薼���擾
            if (this._userSetting != null)
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // �J����
            InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1);

            // �{�^���ݒ�
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // 2010/04/15 Add >>>
            this.uButton_ClaimeFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_ClaimeFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            this.uButton_ChargeFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_ChargeFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            // 2010/04/15 Add <<<

            // ��{�p�^�[�����쐬
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //string tempName = string.Empty;
            //createPatternStringNonCustom(0, out tempName, true);
            //createPatternStringNonCustom(1, out tempName, true);
            //createPatternStringNonCustom(2, out tempName, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            if ( _userSetting == null ||
                _userSetting.OutputPattern == null ||
                _userSetting.OutputPattern.Length == 0 )
            {
                string tempName = string.Empty;
                createPatternStringNonCustom( 0, out tempName, true );
                createPatternStringNonCustom( 1, out tempName, true );
                createPatternStringNonCustom( 2, out tempName, true );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
            //this._outputStyle = 0;// �����ݒ�
            // --- DEL 2020/12/21 �x���Ή� ----------<<<<<

            // ��ʂ̏����l���Z�b�g
            setInitialValue();

            // ��ʂ̏����ݒ�
            this.tComboEditor_OutputType_ValueChanged( null, null );
            //add by liusy #35729 2013/05/20 -----<<<<<
            this.tComboEditor_DateType_ValueChanged(null, null);
            //add by liusy #35729 2013/05/20 ----->>>>>
            this.tComboEditor_OutputStyle_ValueChanged( null, null );

            // -------------ADD 2009/12/28------------>>>>>
            //���א���
            this.tComboEditor_AllowRowFiltering.SelectedIndex = _userSetting.AllowRowFiltering;
            this.tComboEditor_AllowColSwapping.SelectedIndex = _userSetting.AllowColSwapping;
            this.tComboEditor_FixedHeaderIndicator.SelectedIndex = _userSetting.FixedHeaderIndicator;
            // -------------ADD 2009/12/28------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
            // ValueChanged�C�x���g�ŏ����ς�����t�@�C������߂�
            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

            //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
            uCheckEditor_NoCountCtrl.CheckedChanged -= new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
            if (_userSetting.SearchCountCtrl == 1)
            {
                this.uCheckEditor_NoCountCtrl.Checked = true;
            }
            else
            {
                this.uCheckEditor_NoCountCtrl.Checked = false;
            }
            uCheckEditor_NoCountCtrl.CheckedChanged += new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
            //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<

            // 2010/04/15 Add >>>
            tEdit_ClaimeFileName.Text = _userSetting.ClaimeFileName;
            tEdit_ChargeFileName.Text = _userSetting.ChargeFileName;
            // 2010/04/15 Add <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            //�\���X�V

            // ��؂蕶���C��
            if ( prevDividerChar == 1 )
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // ���蕶���C��
            if ( prevParenthesis == 1 )
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }
            // �ԓ`���l�P
            //if ( this.SlipNote == 2 )// DEL 2010/01/29
            if (this.SlipNote == 3)// ADD 2010/01/29
            {
                this.tEdit_SlipNote.Enabled = true;
            }
            else
            {
                this.tEdit_SlipNote.Enabled = false;
                this.tEdit_SlipNote.Clear();
            }
            // �ԓ`���l�Q
            //if ( this.SlipNote2 == 2 )// DEL 2010/01/29
            if (this.SlipNote2 == 3)// ADD 2010/01/29
            {
                this.tEdit_SlipNote2.Enabled = true;
            }
            else
            {
                this.tEdit_SlipNote2.Enabled = false;
                this.tEdit_SlipNote2.Clear();
            }
            // �ԓ`���l�R
            //if (this.SlipNote3 == 2)// DEL 2010/01/29
            if (this.SlipNote3 == 3)// ADD 2010/01/29
            {
                this.tEdit_SlipNote3.Enabled = true;
            }
            else
            {
                this.tEdit_SlipNote3.Enabled = false;
                this.tEdit_SlipNote3.Clear();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            // �`�[����m�F�_�C�A���O(�ԓ`���s)
            this.tComboEditor_RedPrintDialog.SelectedIndex = (_userSetting.RedPrintDialog) ? 1 : 0;
            // �`�[����m�F�_�C�A���O(�Ĕ��s)
            this.tComboEditor_ReisssuePrintDialog.SelectedIndex = (_userSetting.ReisssuePrintDialog) ? 1 : 0;
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<

            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>> 
            // ���؎����ԃI�v�V���������̏ꍇ
            if (!this._opFujikiCustom)
            {
                // �����\���敪���ڂ͔�\��
                this.ultraLabel44.Visible = false;
                this.tComboEditor_DateType.Visible = false;
                this.tComboEditor_DateType.Enabled = false; // ADD 2015/09/17 �c���� Redmine#47006
            }
            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<
            this.tComboEditor_InitSelectDisplay.SelectedIndex = _userSetting.InitSelectDisplay;// 2018/09/04 杍^�@���������\���̑Ή�
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
        /// <summary>
        /// ���[�U�[�ݒ菉��������
        /// </summary>
        /// <param name="_userSetting"></param>
        private void InitializeUserSetting( ref CustPtrSalesUserConst userSetting )
        {
            userSetting = new CustPtrSalesUserConst();
            InitializeSlipGrid( ref userSetting );
            InitializeDetailGrid( ref userSetting );
            InitializeRedSlipGrid( ref userSetting );
            InitializeBalanceGrid( ref userSetting );
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�`�[�\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeSlipGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.SlipColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustSlip = false;
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i���ו\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeDetailGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.DetailColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustDetail = false;
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�ԓ`���s���̖͂��ו\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeRedSlipGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.RedSlipColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustRedSlip = false;
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            userSetting.RedPrintDialog = false;
            userSetting.ReisssuePrintDialog = false;
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�c���ꗗ�\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeBalanceGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.BalanceColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustBalance = false;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�֐�

        /// <summary>
        /// ��ʂ̏����l��ݒ�
        /// </summary>
        private void setInitialValue()
        {
            // �ݒ�l������΂����ݒu
            if ( this._outputPattern == null )
            {
                this.tEdit_DividerChar.Clear();
                this.tEdit_ParenthesisChar.Clear();
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;

                this.tComboEditor_OutputType.SelectedIndex = 0;
                //add by liusy #35729 2013/05/20 -----<<<<<
                this.tComboEditor_DateType.SelectedIndex = 0;
                //add by liusy #35729 2013/05/20 ----->>>>>
                this.tComboEditor_OutputStyle.SelectedIndex = 0;

                //this.uOptionSet_SlipNote.CheckedIndex = 0;
                //this.uOptionSet_SlipNote2.CheckedIndex = 0;
                //this.uOptionSet_SlipNote3.CheckedIndex = 1;
                this.SlipNote = 0;
                this.SlipNote2 = 0;
                this.SlipNote3 = 1;
            }
            else
            {
                string pName = string.Empty;
                string[] patternValue = new string[9];

                // �p�^�[���̍\��
                // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
                // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
                // ���l����i����^���Ȃ�)                          4
                // ��������i����^���Ȃ�)                          5
                // �^�C�g���s�i����^�Ȃ��j                         6
                // �`�[�o�͍��ڃ��X�g (32����x2����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��99, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
                // ���׏o�͍��ڃ��X�g (57����x2����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��99, �K��ExportColumnDataSet.SalesDetail�̏��ɕ���ł��� 8
                // �p�^�[���`��(.CSV/.TXT/.PRN/�J�X�^��)            9

                if ( String.IsNullOrEmpty( this._selectedPattern ) )
                {
                    this._selectedPattern = "�e�L�X�g�o�̓p�^�[��1";
                }

                // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                this.tComboEditor_PetternSelect.Items.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                Infragistics.Win.ValueListItem item;
                foreach ( string pattern in this._outputPattern )
                {
                    item = new Infragistics.Win.ValueListItem();

                    // �ŏ��̋�؂蕶���܂ł��p�^�[����
                    if ( pattern.Contains( this._divider ) )
                    {
                        pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );
                        item.DataValue = pName;
                        item.DisplayText = pName;

                        this.tComboEditor_PetternSelect.Items.Add( item );

                        // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                        if ( pName == this._selectedPattern )
                        {
                            getPatternValue( pattern.Substring( pattern.IndexOf( this._divider ) + 1 ), out patternValue );
                        }
                    }
                }

                // �擾���I�������A��ʂ�ݒ肷��

                // �t�@�C����
                this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;

                //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
                uCheckEditor_NoCountCtrl.CheckedChanged -= new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                if (_userSetting.SearchCountCtrl == 1)
                {
                    this.uCheckEditor_NoCountCtrl.Checked = true;
                }
                else
                {
                    this.uCheckEditor_NoCountCtrl.Checked = false;
                }
                uCheckEditor_NoCountCtrl.CheckedChanged += new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<

                // �p�^�[����
                this.tComboEditor_PetternSelect.Text = this._selectedPattern;

                // �t�h�\��
                SetDisplayFromPattern( patternValue );
            }
        }

        /// <summary>
        /// �p�^�[���̓��e�𕪉�
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //pValue = new string[10];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            //const int ct_ItemCount = 11;   del by liusy #35729 2013/05/20
            //const int ct_ItemCount = 12; //add by liusy #35729 2013/05/20 // DEL 2015/09/17 �c���� Redmine#47006

            const int ct_ItemCount = 14; // ADD 2015/09/17 �c���� Redmine#47006

            pValue = new string[ct_ItemCount];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            string str1 = pBody;
            string str2 = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //for (int i=0; i < 10; i++)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            for ( int i = 0; i < ct_ItemCount; i++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            {
                // DEL 2015/09/17 �c���� Redmine#47006 ---------- >>>>>
                // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>>
                //if (i == 11 && this._opFujikiCustom == false)
                //{
                //    str1 = "0";
                //    continue;
                //}
                // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<
                // DEL 2015/09/17 �c���� Redmine#47006 ---------- <<<<<

                if (str1.Contains(this._divider))
                {
                    pValue[i] = str1.Substring(0, str1.IndexOf(this._divider));
                }
                else
                {

                    pValue[i] = str1.Substring(0);

                    // ----- DEL 2015/09/17 �c���� Redmine#47006 ----->>>>>
                    //add by liusy #35729 2013/05/20 -----<<<<<
                    //if (str1.Length == 1)
                    //{
                    //    str1 = "0";
                    //    continue;
                    //}
                    //add by liusy #35729 2013/05/20 ----->>>>>
                    // ----- DEL 2015/09/17 �c���� Redmine#47006 -----<<<<<

                    // ----- ADD 2015/09/17 �c���� Redmine#47006 ----->>>>>
                    // ����XML�̃p�^�[���̓��e��11���ڂ̏ꍇ�A�V�������ڂ̓��e��ǉ����܂��B
                    if (i == 10)
                    {
                        // �����̍��ځu�����\���敪�v�̏ꍇ�A�u0�v��ݒ肵�܂��B
                        pValue[11] = "0";
                        // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�̏ꍇ�A�I�t��ݒ肵�܂��B
                        pValue[12] = "0";
                        // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�̏ꍇ�A�I����ݒ肵�܂��B
                        pValue[13] = "1";
                        break;
                    }
                    // ����XML�̃p�^�[���̓��e��12���ڂ̏ꍇ�A�V�������ڂ̓��e��ǉ����܂��B
                    else if (i == 11)
                    {
                        // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�̏ꍇ�A�I�t��ݒ肵�܂��B
                        pValue[12] = "0";
                        // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�̏ꍇ�A�I����ݒ肵�܂��B
                        pValue[13] = "1";
                        break;
                    }
                    // ----- ADD 2015/09/17 �c���� Redmine#47006 -----<<<<<
                }
                str2 = str1.Substring(str1.IndexOf(this._divider) + 1);
                str1 = str2;
            }
        }

        /// <summary>
        /// �O���b�h�̃Z�b�e�B���O�𕶎��񂩂���o��
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <param name="isSlip"></param>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //if (isSlip)
            //{
            //    gridSetting = new string[32];

            //    for (int i = 0; i < 32; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            //else
            //{
            //    gridSetting = new string[57];
                
            //    for (int i = 0; i < 57; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            //int count = patternStr.Length / 3;
            //gridSetting = new string[count];

            //for ( int i = 0; i < count; i++ )
            //{
            //    gridSetting[i] = patternStr.Substring( i * 3, 3 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
            int count = patternStr.Length / (ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * (ct_ColumnCountLength + 1), (ct_ColumnCountLength + 1) );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD
        }

        /// <summary>
        /// �I�����ꂽ�p�^�[����K�p
        /// </summary>
        private void getSelectedPattern()
        {

            string pName = string.Empty;
            string[] patternValue = new string[9];

            // �p�^�[���̍\��
            // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
            // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
            // ���l����i����^���Ȃ�)                          4
            // ��������i����^���Ȃ�)                          5
            // �^�C�g���s�i����^�Ȃ��j                         6
            // �`�[�o�͍��ڃ��X�g (32����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
            // ���׏o�͍��ڃ��X�g (57����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesDetail�̏��ɕ���ł��� 8
            // �p�^�[���`��(.CSV/.TXT/.PRN/�J�X�^��)            9

            // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
            // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
            //int counter = 0;
            // --- DEL 2020/12/21 �x���Ή� ----------<<<<<
            foreach (string pattern in this._outputPattern)
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));

                    // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                    if (pName == this._selectedPattern)
                    {
                        getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                        break;
                    }
                }
            }

            // �擾���I�������A��ʂ�ݒ肷��

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            //// �t�@�C����
            //this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL

            // �p�^�[����
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // �t�h�\��
            SetDisplayFromPattern( patternValue );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patternValue"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void SetDisplayFromPattern( string[] patternValue )
        {
            try
            {
                // �o�͌`��
                //this.uComboEditor_OutputStyle.Text = "�J�X�^��";
                this.tComboEditor_OutputStyle.SelectedIndex = Int32.Parse( patternValue[9].ToString() );

                // ��؂蕶��
                //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse( patternValue[0].ToString() );
                this.DividerChar = Int32.Parse( patternValue[0].ToString() );
                prevDividerChar = this.DividerChar;
                // ��؂蕶���C��
                this.tEdit_DividerChar.Text = patternValue[1].ToString();
                if ( prevDividerChar == 1 )
                {
                    this.tEdit_DividerChar.Enabled = true;
                }
                else
                {
                    this.tEdit_DividerChar.Enabled = false;
                    this.tEdit_DividerChar.Clear();
                }

                // ���蕶��
                //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse( patternValue[2].ToString() );
                this.Parenthesis = Int32.Parse( patternValue[2].ToString() );
                prevParenthesis = this.Parenthesis;
                // ���蕶���C��
                this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();
                if ( prevParenthesis == 1 )
                {
                    this.tEdit_ParenthesisChar.Enabled = true;
                }
                else
                {
                    this.tEdit_ParenthesisChar.Enabled = false;
                    this.tEdit_ParenthesisChar.Clear();
                }

                // ���l����
                //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse( patternValue[4].ToString() );
                this.TieNumeric = Int32.Parse( patternValue[4].ToString() );
                prevTieNumeric = this.TieNumeric;
                // ��������
                //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse( patternValue[5].ToString() );
                this.TieChar = Int32.Parse( patternValue[5].ToString() );
                prevTieChar = this.TieChar;

                // �^�C�g���s
                //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse( patternValue[6].ToString() );
                this.TitleLine = Int32.Parse( patternValue[6].ToString() );
                prevTitleLine = this.TitleLine;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                // �O���b�h�I��	
                this.tComboEditor_OutputType.SelectedIndex = Int32.Parse( patternValue[10].ToString() );
                // --- UPD 2014/02/05 T.Miyamoto ------------------------------>>>>>
                ////add by liusy #35729 2013/05/20 -----<<<<<
                //this.tComboEditor_DateType.SelectedIndex = Int32.Parse(patternValue[11].ToString());
                ////add by liusy #35729 2013/05/20 ----->>>>>
                if (this._opFujikiCustom)
                {
                    this.tComboEditor_DateType.SelectedIndex = Int32.Parse(patternValue[11].ToString());
                }
                // --- UPD 2014/02/05 T.Miyamoto ------------------------------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�`�F�b�N�I���̏ꍇ�A
                if (patternValue[12] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = false;
                }

                // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�`�F�b�N�I���̏ꍇ�A
                if (patternValue[13] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Meisai.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Meisai.Checked = false;
                }
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                // �O���b�h
                this._gridSetting_Slip = patternValue[7].ToString();
                this._gridSetting_Detail = patternValue[8].ToString();

                // �J�����ݒ�
                InitializeGridColumns( this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0 );
                InitializeGridColumns( this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1 );
            }
            catch
            {
            }

            try
            {
                // �ԓ`�ݒ�
                //this.uOptionSet_SlipNote.CheckedIndex = this._userSetting.SlipNote1Pattern;
                this.SlipNote = this._userSetting.SlipNote1Pattern;
                prevSlipNote = this.SlipNote;
                this.tEdit_SlipNote.Text = this._userSetting.SlipNote1Default;
                //if ( this.SlipNote == 2 )// DEL 2010/01/29
                if (this.SlipNote == 3)// ADD 2010/01/29
                {
                    this.tEdit_SlipNote.Enabled = true;
                }
                else
                {
                    this.tEdit_SlipNote.Enabled = false;
                    this.tEdit_SlipNote.Clear();
                }
                //this.uOptionSet_SlipNote2.CheckedIndex = this._userSetting.SlipNote2Pattern;
                this.SlipNote2 = this._userSetting.SlipNote2Pattern;
                prevSlipNote2 = this.SlipNote2;
                this.tEdit_SlipNote2.Text = this._userSetting.SlipNote2Default;
                //if ( this.SlipNote2 == 2 )// DEL 2010/01/29
                if (this.SlipNote2 == 3)// ADD 2010/01/29
                {
                    this.tEdit_SlipNote2.Enabled = true;
                }
                else
                {
                    this.tEdit_SlipNote2.Enabled = false;
                    this.tEdit_SlipNote2.Clear();
                }
                //this.uOptionSet_SlipNote3.CheckedIndex = this._userSetting.SlipNote3Pattern;
                this.SlipNote3 = this._userSetting.SlipNote3Pattern;
                prevSlipNote3 = this.SlipNote3;
                this.tEdit_SlipNote3.Text = this._userSetting.SlipNote3Default;
                //if ( this.SlipNote3 == 2 )// DEL 2010/01/29
                if (this.SlipNote3 == 3)// ADD 2010/01/29
                {
                    this.tEdit_SlipNote3.Enabled = true;
                }
                else
                {
                    this.tEdit_SlipNote3.Enabled = false;
                    this.tEdit_SlipNote3.Clear();
                }
            }
            catch
            {
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD

        /// <summary>
        /// �f�[�^�O���b�h�Z�b�g
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="tabNo"></param>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, int tabNo)
        {
            // �\���ʒu�����l
            int visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                //column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }


            switch (tabNo)
            {
                case 0:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                        # region // DEL
                        //// �ݒ肪����΂���ɏ]���A�Ȃ���ΑS�\��
                        //if (String.IsNullOrEmpty(this._gridSetting_Slip))
                        //{
                        //#region �`�[�O���b�h�w�b�_�쐬�i�ݒ�Ȃ��j

                        //    // �`�[���t
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �`�[�ԍ�
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �敪��
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �S���Җ�
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���z
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �����
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �e��
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Caption = "�e��";
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ޕʔԍ�
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Caption = "�ޕʔԍ�";
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Ԏ�
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �N��
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Caption = "�N��";
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ԑ�No
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Caption = "�ԑ�No";
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �^��
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Caption = "�^��";
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�P
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�Q
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�R
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Caption = "���l�R";
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �󒍎�
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍎�";
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���s��
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ�R�[�h
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ於
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ撍��
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "���Ӑ撍��";
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Ǘ�No
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ�No";
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v�㌳��No
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "�v�㌳��No";
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v���o��No
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Caption = "�v���o��No";
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N1
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Caption = "UOE���}�[�N1";
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N2
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Caption = "UOE���}�[�N2";
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���_
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �J���[����
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Caption = "�J���[����";
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �g��������
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Caption = "�g��������";
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ�`�[�ԍ�
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Caption = "���Ӑ�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v���
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���|�敪
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ԓ`�敪
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // �[����R�[�h
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Caption = "�[����R�[�h";
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �[���於
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Caption = "�[���於";
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion
                        //}
                        //else
                        //{
                        //#region �`�[�O���b�h�w�b�_�쐬�i�ݒ肠��j

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //string[] gridPattern = new string[32];
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    string[] gridPattern;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    getGridSettingPattern(this._gridSetting_Slip, out gridPattern, true);

                        //    int position = 0;

                        //    // �`�[���t
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[0].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �`�[�ԍ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[1].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �敪��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[2].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �S���Җ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[3].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���z
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[4].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[5].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ConsumeTaxColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �e��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[6].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.GrossProfitColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Caption = "�e��";
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �ޕʔԍ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[7].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CategoryNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Caption = "�ޕʔԍ�";
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �Ԏ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[8].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ModelFullNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �N��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[9].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FirstEntryDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Caption = "�N��";
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �ԑ�No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[10].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FrameNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Caption = "�ԑ�No";
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �^��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[11].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FullModelColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Caption = "�^��";
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�P
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[12].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SlipNoteColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�Q
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[13].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SlipNote2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�R
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[14].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SlipNote3Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Caption = "���l�R";
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �󒍎�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[15].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍎�";
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���s��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[16].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesInputNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ�R�[�h
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[17].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CustomerCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ於
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[18].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CustomerSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ撍��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[19].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "���Ӑ撍��";
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �Ǘ�No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[20].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CarMngCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ�No";
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �v�㌳��No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[21].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "�v�㌳��No";
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �v���o��No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[22].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Caption = "�v���o��No";
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOE���}�[�N1
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[23].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.UoeRemark1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Caption = "UOE���}�[�N1";
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOE���}�[�N2
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[24].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.UoeRemark2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Caption = "UOE���}�[�N2";
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���_
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[25].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SectionGuideNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �J���[����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[26].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ColorName1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Caption = "�J���[����";
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �g��������
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[27].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.TrimNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Caption = "�g��������";
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ�`�[�ԍ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[28].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CustSlipNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Caption = "���Ӑ�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �v���
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[29].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.AddUpADateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���|�敪
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[30].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //// �ԓ`�敪
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    ////position = Int32.Parse( gridPattern[31].ToString() );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    //position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.DebitNoteDivColumn.ColumnName );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // �[����R�[�h
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Caption = "�[����R�[�h";
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �[���於
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Caption = "�[���於";
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion
                        //}
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD

                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                        {
                            getGridSettingPattern( this._gridSetting_Slip, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _slipColCollection )
                        {
                            // �I��p�̃`�F�b�N�{�b�N�X�͏��O
                            if ( orgCol.Key == _dataSet.SalesList.SelectionColumn.ColumnName ) continue;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                            // �����敪�͏��O
                            if ( orgCol.Key == _dataSet.SalesList.HistoryDivNameColumn.ColumnName ) continue;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD

                            // �J�����`���[�U���珜�O����Ă��鍀�ڂ͓�������p�Ƃ݂Ȃ��ď��O
                            if ( orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True ) continue;

                            // ���J��������R�s�[
                            Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                            Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                            Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                            // �l�Z�b�g
                            Columns[orgCol.Key].Hidden = false;
                            Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                            Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                            if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 ADD
                                int hiddenFlag = (int)Math.Pow( 10, ct_ColumnCountLength );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 ADD

                                // �ݒ肠��
                                position = GetColumnPositionOfSlip( gridPattern, orgCol.Key );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                //if ( position > 100 )
                                if ( position >= hiddenFlag )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                    //Columns[orgCol.Key].Header.VisiblePosition = position - 100;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - hiddenFlag;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                                else if (position > gridPattern.Length && orgCol.Key == _dataSet.SalesList.UpdateDateTimeColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                                else
                                {
                                    Columns[orgCol.Key].Hidden = false;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                            }
                            else
                            {
                                // �ݒ�Ȃ�
                                Columns[orgCol.Key].Hidden = false;
                                Columns[orgCol.Key].Header.VisiblePosition = position++;
                            }
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD

                        #region �J�����`���[�U�ݒ�

                        //--------------------------------------------------------------------------------
                        //  �J�����`���[�U��L���ɂ���
                        //--------------------------------------------------------------------------------
                        this.uGrid_ColumnItemSelector.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorWidth = 24;

                        // �J�����`���[�U�{�^���̊O�ς�ݒ�
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // �J�����`���[�U�ݒ�

                        // �񕝎���������ݒ�l�ɂ��������čs��
                        autoColumnAdjust(false, 0);

                        break;
                    }
                case 1:
                    {
                        #region ����

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                        # region // DEL
                        //// �ݒ肪����΂���ɏ]���A�Ȃ���ΑS�\��
                        //if (String.IsNullOrEmpty(this._gridSetting_Detail))
                        //{
                        //    #region ���׃O���b�h�w�b�_�쐬�i�ݒ�Ȃ��j

                        //    // �`�[���t
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �`�[�ԍ�
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �sNo
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "�sNo";
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �敪��
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �S���Җ�
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �i��
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �i��
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BL�R�[�h
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BL�O���[�v
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BL��ٰ��";
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ����
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Caption = "����";
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �W�����i
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "�W�����i";
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �P��
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "�P��";
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ����
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "����";
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���z
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �����
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 DEL
                        //    //// �e���i����`�[���v�j
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Caption = "�e��";
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 DEL

                        //    // �ޕʔԍ�
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Caption = "�ޕʔԍ�";
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Ԏ�
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �N��
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Caption = "�N��";
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ԑ�No
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Caption = "�ԑ�No";
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �^��
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Caption = "�^��";
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�P
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�Q
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�R
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Caption = "���l�R";
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �󒍎�
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍎�";
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���s��
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ�R�[�h
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ於
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �d����R�[�h
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �d����
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Caption = "�d����";
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ撍��
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "���Ӑ撍��";
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Ǘ�No
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ�No";
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v�㌳��No
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "�v�㌳��No";
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v���o��No
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Caption = "�v���o��No";
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ����No
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Caption = "����No";
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �݌Ɏ��敪
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Caption = "�݌Ɏ��敪";
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �q��
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Caption = "�q��";
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �����d��No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "�����d��No";
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Caption = "�����d��No";
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                        //    // ������R�[�h
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Caption = "������R�[�h";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ������
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Caption = "������";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N�P
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Caption = "UOE���}�[�N�P";
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N�Q
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Caption = "UOE���}�[�N�Q";
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �̔��敪
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Caption = "�̔��敪";
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���_
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���ה��l
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "���ה��l";
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �J���[��
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Caption = "�J���[��";
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �g������
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Caption = "�g������";
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Z�o���i
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "�Z�o���i";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Z�o����
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Caption = "�Z�o����";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �Z�o����
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Caption = "�Z�o����";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���[�J�[�R�[�h
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���[�J�[
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "���[�J�[";
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 DEL
                        //    //// �����i�e���j
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Caption = "�����i�e���j";
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 DEL

                        //    // ���Ӑ�`�[�ԍ�
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Caption = "���Ӑ�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v���
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���|�敪��
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ԓ`�敪
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // �[����R�[�h
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Caption = "�[����R�[�h";
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �[���於
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Caption = "�[���於";
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion // ���׃O���b�h�w�b�_�쐬�i�ݒ�Ȃ��j
                        //}
                        //else
                        //{
                        //    #region ���׃O���b�h�w�b�_�쐬�i�ݒ肠��j

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //string[] gridPattern = new string[57];
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    string[] gridPattern;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    getGridSettingPattern(this._gridSetting_Detail, out gridPattern, false);

                        //    int position = 0;

                        //    // �`�[���t
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[0].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �`�[�ԍ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[1].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �sNo
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[2].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "�sNo";
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �敪��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[3].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �S���Җ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[4].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �i��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[5].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GoodsNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �i��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[6].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GoodsNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // BL�R�[�h
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[7].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // BL�O���[�v
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[8].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BL��ٰ��";
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[9].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Caption = "����";
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �W�����i
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[10].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "�W�����i";
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �P��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[11].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "�P��";
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[12].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "����";
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���z
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[13].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[14].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �e���i����`�[���v�j
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[15].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Caption = "�e��";
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �ޕʔԍ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[16].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CategoryNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Caption = "�ޕʔԍ�";
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �Ԏ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[17].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �N��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[18].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Caption = "�N��";
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �ԑ�No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[19].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FrameNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Caption = "�ԑ�No";
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �^��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[20].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FullModelColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Caption = "�^��";
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�P
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[21].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SlipNoteColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�Q
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[22].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SlipNote2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�R
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[23].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SlipNote3Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Caption = "���l�R";
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �󒍎�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[24].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍎�";
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���s��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[25].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ�R�[�h
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[26].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ於
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[27].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �d����R�[�h
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[28].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SupplierCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {   
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �d����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[29].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Caption = "�d����";
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���Ӑ撍��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[30].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "���Ӑ撍��";
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �Ǘ�No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[31].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ�No";
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �v�㌳��No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[32].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "�v�㌳��No";
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �v���o��No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[33].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Caption = "�v���o��No";
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ����No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[34].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Caption = "����No";
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �݌Ɏ��敪
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[35].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Caption = "�݌Ɏ��敪";
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �q��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[36].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Caption = "�q��";
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �����d��No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    ////position = Int32.Parse( gridPattern[37].ToString() );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    //position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "�����d��No";
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName );
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Caption = "�����d��No";
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD


                        //    // ������R�[�h
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[38].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Caption = "������R�[�h";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ������
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[39].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Caption = "������";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOE���}�[�N�P
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[40].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOERemark1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Caption = "UOE���}�[�N�P";
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOE���}�[�N�Q
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[41].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOERemark2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Caption = "UOE���}�[�N�Q";
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �̔��敪
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[42].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GuideNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Caption = "�̔��敪";
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���_
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[43].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���ה��l
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[44].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.DtlNoteColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "���ה��l";
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �J���[��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[45].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ColorName1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Caption = "�J���[��";
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �g������
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[46].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.TrimNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Caption = "�g������";
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �Z�o���i
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[47].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "�Z�o���i";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �Z�o����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[48].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Caption = "�Z�o����";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �Z�o����
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[49].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Caption = "�Z�o����";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���[�J�[�R�[�h
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[50].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���[�J�[
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[51].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.MakerNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "���[�J�[";
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 DEL
                        //    //// �����i�e���j
                        //    //position = Int32.Parse(gridPattern[52].ToString());
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Caption = "�����i�e���j";
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 DEL

                        //    // ���Ӑ�`�[�ԍ�
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[53].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Caption = "���Ӑ�`�[�ԍ�";
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // �v���
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[54].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.AddUpADateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���|�敪��
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[55].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //// �ԓ`�敪
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    ////position = Int32.Parse( gridPattern[56].ToString() );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    //position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // �[����R�[�h
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Caption = "�[����R�[�h";
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �[���於
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Caption = "�[���於";
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion // ���׃O���b�h�w�b�_�쐬�i�ݒ肠��j
                        //}
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Detail) )
                        {
                            getGridSettingPattern( this._gridSetting_Detail, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _detailColCollection )
                        {
                            // �I��p�̃`�F�b�N�{�b�N�X�͏��O
                            if ( orgCol.Key == _dataSet.SalesDetail.SelectionCheckColumn.ColumnName ) continue;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                            // �����敪�͏��O
                            if ( orgCol.Key == _dataSet.SalesDetail.HistoryDivNameColumn.ColumnName ) continue;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD

                            // �J�����`���[�U���珜�O����Ă��鍀�ڂ͓�������p�Ƃ݂Ȃ��ď��O
                            if ( orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True ) continue;

                            // ���J��������R�s�[
                            Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                            Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                            Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                            // �l�Z�b�g
                            Columns[orgCol.Key].Hidden = false;
                            Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                            Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                            if ( !string.IsNullOrEmpty( _gridSetting_Detail ) )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 ADD
                                int hiddenFlag = (int)Math.Pow( 10, ct_ColumnCountLength );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 ADD

                                // �ݒ肠��
                                position = GetColumnPositionOfDetail( gridPattern, orgCol.Key );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                //if ( position > 100 )
                                if ( position >= hiddenFlag )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                    //Columns[orgCol.Key].Header.VisiblePosition = position - 100;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - hiddenFlag;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                                else if (position > gridPattern.Length && orgCol.Key == _dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                                // --- ADD �i�N 2015/03/16 �ϊ���i�� �����l�̔�\���Ή� ----->>>>> 
                                else if (position > gridPattern.Length && orgCol.Key == _dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                                // --- ADD �i�N 2015/03/16 �ϊ���i�� �����l�̔�\���Ή� -----<<<<<
                                else
                                {
                                    Columns[orgCol.Key].Hidden = false;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                            }
                            else
                            {
                                // �ݒ�Ȃ�
                                Columns[orgCol.Key].Hidden = false;
                                Columns[orgCol.Key].Header.VisiblePosition = position++;
                                // --- ADD �i�N 2015/03/16 �ϊ���i�� �����l�̔�\���Ή� ----->>>>> 
                                if (orgCol.Key == _dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                }
                                // --- ADD �i�N 2015/03/16 �ϊ���i�� �����l�̔�\���Ή� -----<<<<<
                            }
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD

                        #region �J�����`���[�U�ݒ�

                        //--------------------------------------------------------------------------------
                        //  �J�����`���[�U��L���ɂ���
                        //--------------------------------------------------------------------------------
                        this.uGrid_ColumnItemSelector2.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorWidth = 24;

                        // �J�����`���[�U�{�^���̊O�ς�ݒ�		
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector2.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // �J�����`���[�U�ݒ�

                        // �񕝎���������ݒ�l�ɂ��������čs��
                        autoColumnAdjust(false, 1);

                        #endregion //����

                        break;
                    }
                default: break;
            }

            // �O�ϐݒ�
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // �O�ϐݒ�
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

        }

        /// <summary>
        /// �񕝎�������
        /// </summary>
        /// <param name="autoAdjust">�����������邩�ǂ���</param>
        /// <param name="targetGrid">�ΏۂƂȂ�O���b�h 0:�`�[�ꗗ, 1:����</param>
        private void autoColumnAdjust(bool autoAdjust, int targetGrid)
        {
            switch (targetGrid)
            {
                case 0:
                    {
                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_ColumnItemSelector.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_ColumnItemSelector.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            //this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();   // DEL 2012/04/01 gezh Redmine#29250
                            // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                            if (!this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].Hidden)
                            {
                                this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                            }
                            // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                        }
                        break;
                    }
                case 1:
                    {
                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            //this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();   // ADD 2012/04/01 gezh Redmine#29250
                            // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                            if (!this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].Hidden)
                            {
                                this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                            }
                            // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                        }
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// ���͒l�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool checkValues()
        {
            /* ---DEL 2009/02/10 �s��Ή�[10726] ----------------------------------------------->>>>>
            // �t�@�C����
            if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim())) return false;

            // �p�^�[����
            if ( String.IsNullOrEmpty( this.tComboEditor_PetternSelect.Text.Trim() ) ) return false;
               ---DEL 2009/02/10 �s��Ή�[10726] -----------------------------------------------<<<<< */
            // ---ADD 2009/02/10 �s��Ή�[10726] ----------------------------------------------->>>>>
            // ------------DEL 2010/01/29----------->>>>>
            //// �t�@�C����
            //if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
            //{
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOFILENAME, -1, MessageBoxButtons.OK);
            //    this.tEdit_SettingFileName.Focus();
            //    return false;
            //}
            // ------------DEL 2010/01/29-----------<<<<<
            // �p�^�[����
            if (String.IsNullOrEmpty(this.tComboEditor_PetternSelect.Text.Trim()))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOPATTERN, -1, MessageBoxButtons.OK);
                this.tComboEditor_PetternSelect.Focus();
                return false;
            }
            // ---ADD 2009/02/10 �s��Ή�[10726] -----------------------------------------------<<<<<
            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
            if (this._opt_EBooksLink == (int)Option.ON)
            {
                //�uPDF�o�͂��Ȃ��v�ȊO�̏ꍇ
                if ((tComboEditor_OutPutMode.SelectedIndex) != MODE_NONE)
                {
                    // PDF�v�����^�Ǘ��ԍ��@�K�{���̓`�F�b�N
                    if (string.IsNullOrEmpty(tEdit_PdfPrinterNumber.Text.Trim()))
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_PDFPRINTERNUMBER_NOPATTERN, -1, MessageBoxButtons.OK);
                        this.tEdit_PdfPrinterNumber.Focus();
                        return false;
                    }
                }
                // PDF�v�����^�ҋ@����(�~���b) �K�{���̓`�F�b�N
                if (string.IsNullOrEmpty(tEdit_PdfPrinterWait.Text.Trim()))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_PDFPRINTERWAIT_NOPATTERN, -1, MessageBoxButtons.OK);
                    this.tEdit_PdfPrinterWait.Focus();
                    return false;
                }

            }
            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<
            return true;
        }

        /// <summary>
        /// �p�^�[�����X�V
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void renewalOutputPattern(bool isDelete)
        {
            if (!isDelete)
            {
                // ���O
                string selectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
                //string value01 = this.uOptionSet_DividerChar.CheckedIndex.ToString();
                string value01 = this.DividerChar.ToString();
                string value02 = this.tEdit_DividerChar.Text.Trim();
                //string value03 = this.uOptionSet_Parenthesis.CheckedIndex.ToString();
                string value03 = this.Parenthesis.ToString();
                string value04 = this.tEdit_ParenthesisChar.Text.Trim();
                //string value05 = this.uOptionSet_TieNumeric.CheckedIndex.ToString();
                string value05 = this.TieNumeric.ToString();
                //string value06 = this.uOptionSet_TieChar.CheckedIndex.ToString();
                string value06 = this.TieChar.ToString();
                //string value07 = this.uOptionSet_TitleLine.CheckedIndex.ToString();
                string value07 = this.TitleLine.ToString();

                // �O���b�h����ݒ�l���擾
                string value08 = string.Empty;
                createGridPatternString(true, out value08);
                string value09 = string.Empty;
                createGridPatternString(false, out value09);
                //string value08 = "00100200300400500600700800901001101201301401501601701801902021022023024025026027028029030031032";
                //string value09 = "010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657";
                string value10 = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string value11 = this.tComboEditor_OutputType.SelectedItem.DataValue.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                //add by liusy #35729 2013/05/20 -----<<<<<
                string value12 = "0";
                if (this._opFujikiCustom)
                {
                    value12 = this.tComboEditor_DateType.SelectedItem.DataValue.ToString();
                }
                //add by liusy #35729 2013/05/20 ----->>>>>

                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                string value13 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Saleslip.Checked)
                {
                    // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v���`�F�b�N�I������ꍇ�A�u1�v�Ƃ���
                    value13 = "1";
                }
                else
                {
                    // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v���`�F�b�N�I�t����ꍇ�A�u0�v�Ƃ���
                    value13 = "0";
                }

                string value14 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Meisai.Checked)
                {
                    // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v���`�F�b�N�I������ꍇ�A�u1�v�Ƃ���
                    value14 = "1";
                }
                else
                {
                    // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v���`�F�b�N�I�t����ꍇ�A�u0�v�Ƃ���
                    value14 = "0";
                }
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                // �S�ĘA��
                string convinedStr = selectedPatternName + this._divider +
                        value01 + this._divider + value02 + this._divider +
                        value03 + this._divider + value04 + this._divider +
                        value05 + this._divider + value06 + this._divider +
                        value07 + this._divider + value08 + this._divider +
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //value09 + this._divider + value10;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        value09 + this._divider +
                        value10 + this._divider +
                        //value11;  //del by liusy #35729 2013/05/20
                        //add by liusy #35729 2013/05/20 -----<<<<<
                        value11+ this._divider +
                        //value12; // DEL 2015/09/17 �c���� Redmine#47006
                        //add by liusy #35729 2013/05/20 ----->>>>>
                        
                        //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                        value12 + this._divider +
                        value13 + this._divider +
                        value14;
                        //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                string[] newOutputPattern;

                if (this._outputPattern == null)
                {
                    newOutputPattern = new string[1];
                    newOutputPattern[0] = convinedStr;
                }
                else
                {
                    bool exists = false;
                    string pName = string.Empty;
                    int count = 0;

                    // �����łȂ�������
                    foreach (string pattern in this._outputPattern)
                    {
                        // �ŏ��̋�؂蕶���܂ł��p�^�[����
                        if (pattern.Contains(this._divider))
                        {
                            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                            //if (pName == this._selectedPattern)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            if ( pName == selectedPatternName )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                            {
                                this._outputPattern[count] = convinedStr;
                                exists = true;
                                break;
                            }
                        }
                        count++;
                    }

                    if (exists)
                    {
                        // �X�V
                        this._userSetting.OutputPattern = this._outputPattern;
                    }
                    else
                    {
                        newOutputPattern = new string[this._outputPattern.Length + 1];
                        count = 0;
                        foreach (string pattern in _outputPattern)
                        {
                            newOutputPattern[count] = pattern;
                            count++;
                        }
                        newOutputPattern[count] = convinedStr;

                        // �ǉ�
                        this._userSetting.OutputPattern = newOutputPattern;
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�̐ݒ�𕶎���ɕϊ�
        /// </summary>
        /// <param name="isSlip"></param>
        /// <param name="patternString"></param>
        /// <br>Update Note : K2015/07/15 ��</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>            : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>Update Note : K2015/11/17  ����</br>
        /// <br>            : ���Ӑ�d�q����  Redmine#47636�@#6�s��̑Ή�</br>
        /// <br>            : �ݒ�����X�V���Ȃ��ꍇ�A�ݒ�O��xml�t�@�C���Ɣ�r�l���ς���Ă���̏�Q�Ή�</br>
        private void createGridPatternString(bool isSlip, out string patternString)
        {
            patternString = string.Empty;

            if (isSlip)
            {
                #region �`�[�O���b�h
                
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //string[] gridHeaderPattern = new string[32];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL

                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string[] gridHeaderPattern = new string[col.Count];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                //if (col[0].Header.Caption == "
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                    # region // DEL
                    //switch (column.Header.Caption)
                    //{
                    //    case "�`�[���t":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�`�[�ԍ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�S���Җ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���z":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�e��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�ޕʔԍ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Ԏ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�N��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�ԑ�No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�^��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���l�P":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���l�Q":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���l�R":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�󒍎�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���s��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ�R�[�h":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ於":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[18] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[18] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ撍��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Ǘ�No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[20] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[20] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�v�㌳��No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[21] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[21] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�v���o��No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[22] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[22] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOE���}�[�N1":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[23] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[23] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOE���}�[�N2":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[24] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[24] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���_":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[25] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[25] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�J���[����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[26] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[26] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�g��������":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[27] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[27] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ�`�[�ԍ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[28] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[28] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�v���":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[29] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[29] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���|�敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[30] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[30] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�ԓ`�敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[31] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[31] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    default: break;
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD

                    //----- DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
                    //----- ADD K2015/07/15 �� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                    //if (_opt_Toua == (Int32)Option.OFF && column.Key == CL_CARMAKERCODE_NAME) continue;

                    //if (_opt_Meigo == (Int32)Option.OFF)
                    //{

                    //    if (column.Key == SALESAREA_NAME || column.Key == CUSTANALYSCODE1_NAME || column.Key == CUSTANALYSCODE2_NAME || column.Key == CUSTANALYSCODE3_NAME ||
                    //        column.Key == CUSTANALYSCODE4_NAME || column.Key == CUSTANALYSCODE5_NAME || column.Key == CUSTANALYSCODE6_NAME)
                    //    {
                    //        continue;
                    //    }
                    //}
                    //----- ADD K2015/07/15 �� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
                    //----- DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<

                    if ( _columnIndexDicOfSlip.ContainsKey( column.Key ) )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 DEL
                        //if ( column.Hidden )
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        //else
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                }

                // ��̏��ɕ��Ԃ悤�ɕ�������쐬�i���Ԃ��قȂ�Ɛ���ɏC���ł��Ȃ��j
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //for (int i = 0; i < 32; i++)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                for ( int i = 0; i < col.Count; i++ )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                #endregion // �`�[�O���b�h
            }
            else
            {
                #region ���׃O���b�h

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //string[] gridHeaderPattern = new string[57];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL

                // UI�ɕ\������Ă������DisplayLayout������K�v������
                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string[] gridHeaderPattern = new string[col.Count];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                    # region // DEL
                    //switch (column.Header.Caption)
                    //{
                    //    case "�`�[���t":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�`�[�ԍ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�sNo":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�S���Җ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�i��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�i��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "BL����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "BL��ٰ��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�W�����i":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�P��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���z":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�e��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�ޕʔԍ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Ԏ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�N��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[18] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[18] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�ԑ�No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�^��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[20] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[20] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���l�P":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[21] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[21] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���l�Q":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[22] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[22] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���l�R":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[23] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[23] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�󒍎�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[24] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[24] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���s��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[25] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[25] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ�R�[�h":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[26] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[26] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ於":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[27] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[27] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�d����R�[�h":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[28] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[28] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�d����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[29] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[29] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ撍��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[30] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[30] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Ǘ�No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[31] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[31] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�v�㌳��No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[32] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[32] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�v���o��No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[33] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[33] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "����No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[34] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[34] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�݌Ɏ��敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[35] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[35] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�q��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[36] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[36] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�����d��No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[37] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[37] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "������R�[�h":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[38] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[38] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "������":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[39] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[39] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOE���}�[�N�P":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[40] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[40] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOE���}�[�N�Q":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[41] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[41] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�̔��敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[42] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[42] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���_":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[43] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[43] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���ה��l":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[44] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[44] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�J���[��":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[45] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[45] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�g������":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[46] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[46] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Z�o���i":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[47] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[47] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Z�o����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[48] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[48] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�Z�o����":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[49] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[49] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���[�J�[�R�[�h":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[50] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[50] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���[�J�[":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[51] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[51] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�����i�e���j":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[52] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[52] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���Ӑ�`�[�ԍ�":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[53] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[53] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�v���":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[54] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[54] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "���|�敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[55] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[55] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "�ԓ`�敪":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[56] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[56] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    default: break;
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD

                    //----- DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�--------->>>>>
                    //if (_opt_Momose == (Int32)Option.OFF && column.Key == CL_SECONDSALEPRICE_NAME) continue;//ADD K2015/11/13 ���O �����Z���i���̌ʊJ���˗�:���Ӑ�d�q�����u��񔄉��v��ǉ�����
                    ////----- ADD K2015/07/15 �� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                    //if (_opt_Meigo == (Int32)Option.OFF)
                    //{

                    //    if (column.Key == SALESAREA_NAME || column.Key == CUSTANALYSCODE1_NAME || column.Key == CUSTANALYSCODE2_NAME || column.Key == CUSTANALYSCODE3_NAME ||
                    //        column.Key == CUSTANALYSCODE4_NAME || column.Key == CUSTANALYSCODE5_NAME || column.Key == CUSTANALYSCODE6_NAME)
                    //    {
                    //        continue;
                    //    }
                    //}
                    ////----- ADD K2015/07/15 �� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
                    //----- DEL K2015/11/17  �����@Redmine#47636�@#6�s��̑Ή�---------<<<<<
                    if ( _columnIndexDicOfDetail.ContainsKey( column.Key ) )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 DEL
                        //if ( column.Hidden )
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        //else
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                }

                // ��̏��ɕ��Ԃ悤�ɕ�������쐬�i���Ԃ��قȂ�Ɛ���ɏC���ł��Ȃ��j
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //for (int i = 0; i < 57; i++)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                for (int i = 0; i < col.Count; i++)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                #endregion // ���׃O���b�h
            }
        }

        /// <summary>
        /// ��{�p�^�[����ǉ�
        /// </summary>
        /// <param name="outputStyle"></param>
        /// <param name="patternString"></param>
        /// <param name="addPattern"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void createPatternStringNonCustom(int outputStyle, out string patternString, bool addPattern)
        {

            patternString = string.Empty;
            string selectedPatternName = string.Empty;
            string value01 = string.Empty;
            string value02 = string.Empty;
            string value03 = string.Empty;
            string value04 = string.Empty;
            string value05 = string.Empty;
            string value06 = string.Empty;
            string value07 = string.Empty;
            string value08 = string.Empty;
            string value09 = string.Empty;
            string value10 = string.Empty;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            string value11 = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

            string value12 = string.Empty; // ADD 2015/09/17 �c���� Redmine#47006
            string value13 = string.Empty; // ADD 2015/09/17 �c���� Redmine#47006
            string value14 = string.Empty; // ADD 2015/09/17 �c���� Redmine#47006

            switch (outputStyle)
            {
                case 0:
                    {
                        selectedPatternName = "�e�L�X�g�o�̓p�^�[��1";
                        value01 = "1";
                        value02 = ",";
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "0"; // ADD 2015/09/17 �c���� Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        value14 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        break;
                    }
                case 1:
                    {
                        selectedPatternName = "�e�L�X�g�o�̓p�^�[��2";
                        value01 = "0";
                        value02 = string.Empty;
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "1";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "0"; // ADD 2015/09/17 �c���� Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        value14 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        break;
                    }
                case 2:
                    {
                        selectedPatternName = "�e�L�X�g�o�̓p�^�[��3";
                        value01 = "1";
                        value02 = " ";
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "2";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "0"; // ADD 2015/09/17 �c���� Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        value14 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        break;
                    }

                default: break;
            }

            //----- DEL K2014/06/04 By ���R Redmine42764 ��8 -------->>>>>
            ////----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
            //// ���������I�v�V�����́uON�v�̏ꍇ�A��������p�R�[�h��ݒ肵�܂�
            //if (this._opt_Toua == Convert.ToInt32(Option.ON))
            //{
            //    value08 = XML_SLIP_CODE_TOUA;
            //    value09 = XML_DETAIL_CODE_TOUA;
            //}
            ////----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<
            //----- DEL K2014/06/04 By ���R Redmine42764 ��8 --------<<<<

            patternString = selectedPatternName + this._divider +
                value01 + this._divider + value02 + this._divider +
                value03 + this._divider + value04 + this._divider +
                value05 + this._divider + value06 + this._divider +
                value07 + this._divider + value08 + this._divider +
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //value09 + this._divider + value10;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                value09 + this._divider + value10 + this._divider +
                //value11; // DEL 2015/09/17 �c���� Redmine#47006
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                value11 + this._divider +
                value12 + this._divider +
                value13 + this._divider +
                value14;
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<


            if (addPattern)
            {

                string[] newOutputPattern;

                if (this._outputPattern == null)
                {
                    newOutputPattern = new string[1];
                    newOutputPattern[0] = patternString;
                    this._outputPattern = newOutputPattern;
                }
                else
                {
                    bool exists = false;
                    string pName = string.Empty;
                    int count = 0;

                    // �����łȂ�������
                    foreach (string pattern in this._outputPattern)
                    {
                        // �ŏ��̋�؂蕶���܂ł��p�^�[����
                        if (pattern.Contains(this._divider))
                        {
                            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                            //if (pName == this._selectedPattern)
                            if (pName == selectedPatternName)
                            {
                                this._outputPattern[count] = patternString;
                                exists = true;
                                break;
                            }
                        }
                        count++;
                    }

                    if (exists)
                    {
                        // �X�V
                        this._userSetting.OutputPattern = this._outputPattern;
                    }
                    else
                    {
                        newOutputPattern = new string[this._outputPattern.Length + 1];
                        count = 0;
                        foreach (string pattern in _outputPattern)
                        {
                            newOutputPattern[count] = pattern;
                            count++;
                        }
                        newOutputPattern[count] = patternString;

                        // �ǉ�
                        this._outputPattern = newOutputPattern;
                        this._userSetting.OutputPattern = newOutputPattern;
                    }
                }
            }
        }
        #endregion // �v���C�x�[�g�֐�

        #region ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public event EventHandler DataChanged;

        /// <summary>
        /// ���Ӑ�d�q�����p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note: 2010/06/08 ������ �e�L�X�g�o�͐悪�ۑ�����Ȃ��s��̑Ή�</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // ----------UPD 2010/06/08 ----------->>>>>
                //UserSettingController.SerializeUserSetting( _userSetting, Path.Combine( ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME ) );
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                // ----------UPD 2010/06/08 -----------<<<<<
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.InnerException.Message );
            }

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// ���Ӑ�d�q�����p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note: 2010/06/08 ������ �e�L�X�g�o�͐悪�ۑ�����Ȃ��s��̑Ή�</br>
        /// <br>Update Note: K2014/05/28 �ђ��} </br>
        /// <br>           : Redmine#42764 ����e�X�g��Q�Ή��B��������ʑΉ�</br>
        /// <br>Update Note: K2015/4/27 ��</br>
        /// <br>           : 11100842-00 �����Z���i���̌ʊJ���˗�
        /// <br>           : ���Ӑ�d�q������񔄉���ǉ�����B�����Z���i���I�v�V�������L���̏ꍇ�̂݁B</br>
        /// <br>Update Note: K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�   : 11101427-00</br>
        /// <br>           : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// </remarks>
        public void Deserialize()
        {
            // -----------UPD 2010/06/08------------>>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            // -----------UPD 2010/06/08------------<<<<<
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                try
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                {
                    // -----------UPD 2010/06/08------------>>>>>
                    //this._userSetting = UserSettingController.DeserializeUserSetting<CustPtrSalesUserConst>( Path.Combine( ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME ) );
                    this._userSetting = UserSettingController.DeserializeUserSetting<CustPtrSalesUserConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                    // -----------UPD 2010/06/08------------<<<<<

                    //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
                    if (this._opt_Toua == Convert.ToInt32(Option.ON))
                    {
                        try
                        {
                            if (this._userSetting != null &&
                                this._userSetting.SlipColumnsList != null &&
                                this._userSetting.SlipColumnsList.Count != 0)
                            {
                                List<ColumnInfo> slipColumnList = this._userSetting.SlipColumnsList;
                                //XML�t�@�C���͍ŐV���ǂ������f�t���O
                                bool isNewXmlFile = false;
                                foreach (ColumnInfo columnInfo in slipColumnList)
                                {
                                    if (columnInfo.ColumnName.Equals(CL_CARMAKERCODE_NAME))
                                    {
                                        isNewXmlFile = true;
                                        break;
                                    }
                                }
                                if (!isNewXmlFile && File.Exists(XML_FILE_PATH + XML_FILE_NAME))
                                {
                                    File.Delete(XML_FILE_PATH + XML_FILE_NAME);
                                    this._userSetting = new CustPtrSalesUserConst();
                                    InitializeUserSetting(ref _userSetting);
                                    return;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //�����s�v
                        }
                    }
                    //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<

                    // ---- ADD K2015/04/29 �� �����Z���i�̑�񔄉��ǉ� ---->>>>>
                    if (this._opt_Momose == Convert.ToInt32(Option.ON))
                    {
                        if (this._userSetting != null &&
                            this._userSetting.DetailColumnsList != null &&
                            this._userSetting.DetailColumnsList.Count != 0)
                        {
                            //���ݗ�̃`�F�b�N
                            if (!CheckExistColumn(CL_SECONDSALEPRICE_NAME))
                            {
                                return;
                            }
                        }
                    }
                    // ---- ADD K2015/04/29 �� �����Z���i�̑�񔄉��ǉ� ----<<<<<
                    
                    //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                    {
                        if (this.MeigoCheckColumn()) {
                            return;
                        }
                    }
                    //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
                   
                    // ---------- ADD 2012/08/22 ---------->>>>>
                    // �d�����̃��[�U�[�ݒ�̕⊮����
                    int index = -1;
                    int StockPartySaleSlipNumVP = 1;
                    bool StockDateflg = false;

                    for (int i = 0; i < this._userSetting.RedSlipColumnsList.Count; i++)
                    {
                        if (this._userSetting.RedSlipColumnsList[i].ColumnName == "StockPartySaleSlipNum")
                        {
                            // �d���`�[�ԍ��̃C���f�b�N�X�ƕ��я����擾
                            index = i;
                            StockPartySaleSlipNumVP = this._userSetting.RedSlipColumnsList[i].VisiblePosition;
                        }

                        if (this._userSetting.RedSlipColumnsList[i].ColumnName == "StockDate")
                        {
                            // �d�����̐ݒ肪���݂��Ă���
                            StockDateflg = true;
                            break;
                        }
                    }

                    // �d���`�[�ԍ��̐ݒ肪���݂��Ă��āA�d�����̐ݒ肪���݂��Ă��Ȃ�������
                    if (index > -1 && StockDateflg != true)
                    {
                        // �d���`�[�ԍ��ȍ~�̕��я��̍Đݒ�
                        for (int j = 0; j < this._userSetting.RedSlipColumnsList.Count; j++)
                        {
                            if (this._userSetting.RedSlipColumnsList[j].VisiblePosition > StockPartySaleSlipNumVP)
                            {
                                ColumnInfo tempRedSlipColumnsList = this._userSetting.RedSlipColumnsList[j];

                                // �d������}�����邽�߁A���я���1���ɂ��炷
                                tempRedSlipColumnsList.VisiblePosition = this._userSetting.RedSlipColumnsList[j].VisiblePosition + 1;

                                this._userSetting.RedSlipColumnsList[j] = tempRedSlipColumnsList;
                            }
                        }

                        // �d���`�[�ԍ��̌�Ɏd�����������ݒ�l�ő}��
                        this._userSetting.RedSlipColumnsList.Insert(index + 1, new ColumnInfo("StockDate", StockPartySaleSlipNumVP + 1, false, 130, false));
                    }
                    // ---------- ADD 2012/08/22 ----------<<<<<
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                catch
                {
                    this._userSetting = new CustPtrSalesUserConst();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
            }
        }

                // ---- ADD K2015/04/29 �� �e�L�X�g�o�͍��ڂɑ�񔄉���ǉ����� ---->>>>>
        /// <summary>
        /// XML�t�@�C���͍ŐV���ǂ������f�t���O
        /// </summary>
        /// <param name="columnName">��</param>
        /// <returns>���ݗ�̃`�F�b�N true:���݂���@false:���݂Ȃ�</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/04/29</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        private bool CheckExistColumn(string columnName)
        {
            // ���݃t���O (true:���݂���@false:���݂Ȃ�)
            bool isExist = false;

            try
            {
                List<ColumnInfo> detailColumnList = this._userSetting.DetailColumnsList;

                foreach (ColumnInfo columnInfo in detailColumnList)
                {
                    if (columnInfo.ColumnName.Equals(columnName))
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist && File.Exists(Path.Combine(XML_FILE_PATH, XML_FILE_NAME)))
                {
                    File.Delete(Path.Combine(XML_FILE_PATH, XML_FILE_NAME));
                    this._userSetting = new CustPtrSalesUserConst();
                    InitializeUserSetting(ref _userSetting);
                }
            }
            catch (Exception)
            {
                //�����s�v
            }

            return isExist;
        }

        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
        #region ���C�S���I�v�V����
        /// <summary>
        /// ���C�S���I�v�V����
        /// </summary>
        /// <remark>
        /// <br>Note		: ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>Programmer	: 鸏�</br>
        /// <br>Date		: K2015/06/16</br>
        /// </remark>
        private bool MeigoCheckColumn()
        {
            bool returnFlag = false;
            // ���݃t���O (true:���݂���@false:���݂Ȃ�)
            bool existAllFlag = false;
            try
            {
                if (this._userSetting != null &&
                    this._userSetting.SlipColumnsList != null &&
                    this._userSetting.SlipColumnsList.Count != 0)
                {
                    //�n��
                    Boolean checkArea = false;
                    //���̓R�[�h1
                    Boolean checkCustanalysCode1 = false;
                    //���̓R�[�h2
                    Boolean checkCustanalysCode2 = false;
                    //���̓R�[�h3
                    Boolean checkCustanalysCode3 = false;
                    //���̓R�[�h4
                    Boolean checkCustanalysCode4 = false;
                    //���̓R�[�h5
                    Boolean checkCustanalysCode5 = false;
                    //���̓R�[�h6
                    Boolean checkCustanalysCode6 = false;
                    List<ColumnInfo> slipColumnList = this._userSetting.SlipColumnsList;
                    //XML�t�@�C���͍ŐV���ǂ������f�t���O
                    foreach (ColumnInfo columnInfo in slipColumnList)
                    {
                        if (columnInfo.ColumnName.Equals(SALESAREA_NAME))
                        {
                            checkArea = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE1_NAME))
                        {
                            checkCustanalysCode1 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE2_NAME))
                        {
                            checkCustanalysCode2 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE3_NAME))
                        {
                            checkCustanalysCode3 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE4_NAME))
                        {
                            checkCustanalysCode4 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE5_NAME))
                        {
                            checkCustanalysCode5 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE6_NAME))
                        {
                            checkCustanalysCode6 = true;
                        }
                        if (checkArea && checkCustanalysCode1 && checkCustanalysCode2 && checkCustanalysCode3 && checkCustanalysCode4 && checkCustanalysCode5 && checkCustanalysCode6)
                        {
                            existAllFlag = true;
                            break;
                        }
                    }
                    if (!existAllFlag && File.Exists(Path.Combine(XML_FILE_PATH, XML_FILE_NAME)))
                    {
                        File.Delete(Path.Combine(XML_FILE_PATH, XML_FILE_NAME));
                        this._userSetting = new CustPtrSalesUserConst();
                        InitializeUserSetting(ref _userSetting);
                        returnFlag = true;
                    }
                }
            }
            catch (Exception)
            {
                return returnFlag;
            }
            return returnFlag;
        }
        #endregion
        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

        /// <summary>
        /// ���Ӑ�d�q�����p���[�U�[�ݒ� �ݒ���e��������
        /// </summary>
        public void Degradation(string selectedSettingName, out string[] patternValue)
        {
            // �ݒ肳�ꂽ�p�^�[����(��{�I�Ɉ����Ɠ����ɂȂ�)
            if (String.IsNullOrEmpty(selectedSettingName))
            {
                selectedSettingName = this._userSetting.SelectedPatternName;
            }

            // �p�^�[������ы�؂蕶�����擾
            this._outputPattern = this._userSetting.OutputPattern;
            this._divider = this._userSetting.DIVIDER;

            string pName = string.Empty;
            //string[] 
            patternValue = new string[9];

            // �p�^�[���̍\��
            // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
            // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
            // ���l����i����^���Ȃ�)                          4
            // ��������i����^���Ȃ�)                          5
            // �^�C�g���s�i����^�Ȃ��j                         6
            // �`�[�o�͍��ڃ��X�g (32����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
            // ���׏o�͍��ڃ��X�g (57����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesDetail�̏��ɕ���ł��� 8

            // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
            foreach (string pattern in this._outputPattern)
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                    // �v�����ꂽ�p�^�[�����H
                    if (pName == selectedSettingName)
                    {
                        getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                    }
                }
            }
        }

        /// <summary>
        /// �J�������̃��X�g�擾
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="isSlip"></param>
        /// <returns></returns>
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //if (isSlip)
            //{
            //    columnList = new List<String>();//[32];
            //    string[] p = new string[32];
            //    getGridSettingPattern( sourceStr, out p, true );

            //    for ( int i = 0; i < 32; i++ )
            //    {
            //        columnList.Add( p[i] );
            //    }
            //}
            //else
            //{
            //    columnList = new List<String>();//[57];
            //    string[] p = new string[57];
            //    getGridSettingPattern( sourceStr, out p, true );

            //    for ( int i = 0; i < 57; i++ )
            //    {
            //        columnList.Add( p[i] );
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            columnList = new List<String>();
            string[] p;
            getGridSettingPattern( sourceStr, out p, true );

            for ( int i = 0; i < p.Length; i++ )
            {
                columnList.Add( p[i] );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            return columnList;
        }

        #endregion // ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        #region �C�x���g

        /// <summary>
        /// �o�͌`���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_OutputStyle_ValueChanged(object sender, EventArgs e)
        {
            // �I��l
            string selected = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            //string ext = string.Empty;
            //if (fileName.Length > 4) ext = fileName.Substring(fileName.Length - 4, 4);

            //string newExt = string.Empty;
            //switch (selected)
            //{
            //    case "0": newExt = ".CSV"; break;
            //    case "1": newExt = ".TXT"; break;
            //    case "2": newExt = ".PRN"; break;
            //    case "3": newExt = ext; break;
            //    default:break;
            //}
            //if (fileName.Length > 4)
            //{
                
            //    if (ext.Contains("."))
            //    {
            //        if (ext.ToLower() == ".txt" || ext.ToLower() == ".prn" || ext.ToLower() == ".csv")
            //        {
            //            fileName = fileName.ToUpper().Replace(".TXT", newExt).Replace(".PRN", newExt).Replace(".CSV", newExt);
            //        }
            //    }
            //    else if (fileName.Contains("."))
            //    {
            //        fileName = fileName.Substring(1, fileName.IndexOf(".", 1)) + newExt;
            //    }
            //    else
            //    {
            //        fileName = fileName + newExt;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            fileName = CustPtrSalesUserConst.ChangeFileExtension( fileName, selected );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
            this.tEdit_SettingFileName.Text = fileName;

            // �J�X�^���̂Ƃ��̂ݗL��
            bool val = (this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() == "3");

            // ���ڂ𒲐�
            //this.uOptionSet_DividerChar.Enabled = val;
            this.pn_DividerChar.Enabled = val;
            //this.uOptionSet_Parenthesis.Enabled = val;
            this.pn_Parenthesis.Enabled = val;
            //this.uOptionSet_TieChar.Enabled = val;
            this.pn_TieChar.Enabled = val;
            //this.uOptionSet_TieNumeric.Enabled = val;
            this.pn_TieNumeric.Enabled = val;
            //this.uOptionSet_TitleLine.Enabled = val;
            this.pn_TitleLine.Enabled = val;

            this.tEdit_DividerChar.Enabled = val;
            this.tEdit_ParenthesisChar.Enabled = val;

            //this.uComboEditor_OutputType.Enabled = val;

            //this.uGrid_ColumnItemSelector.Enabled = val;
            //this.uGrid_ColumnItemSelector2.Enabled = val;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //if (val) this.uComboEditor_PetternSelect.Text = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
        }

        /// <summary>
        /// �o�̓^�C�v�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void tComboEditor_OutputType_ValueChanged(object sender, EventArgs e)
        {

            if ( this.tComboEditor_OutputType.SelectedItem == null ||
                 this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0" ) //�`�[
            {
                this.uGrid_ColumnItemSelector.Visible = true;
                this.uGrid_ColumnItemSelector2.Visible = false;

                // ----- ADD 2015/09/17 �c���� Redmine#47006 ----->>>>>
                this.uCheckEditor_RetSlipMinus_Meisai.Visible = false;
                this.uCheckEditor_RetSlipMinus_Meisai.Enabled = false;
                this.uCheckEditor_RetSlipMinus_Saleslip.Enabled = true;
                this.uCheckEditor_RetSlipMinus_Saleslip.Visible = true;
                // ----- ADD 2015/09/17 �c���� Redmine#47006 -----<<<<<
            }
            else
            {
                this.uGrid_ColumnItemSelector.Visible = false;
                this.uGrid_ColumnItemSelector2.Visible = true;

                // ----- ADD 2015/09/17 �c���� Redmine#47006 ----->>>>>
                this.uCheckEditor_RetSlipMinus_Meisai.Enabled = true;
                this.uCheckEditor_RetSlipMinus_Meisai.Visible = true;
                this.uCheckEditor_RetSlipMinus_Saleslip.Visible = false;
                this.uCheckEditor_RetSlipMinus_Saleslip.Enabled = false;
                // ----- ADD 2015/09/17 �c���� Redmine#47006 -----<<<<<
            }
        }

        /// <summary>
        /// �����\���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DateType_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �p�^�[���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
                getSelectedPattern();
            }
        }

        #endregion // �C�x���g

        #region �{�^��

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            //string str = string.Empty;
            //createGridPatternString(true, out str);
            //createGridPatternString(false, out str);

            //return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //// �V���A���C�Y
            //this.Serialize();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this.DialogResult = DialogResult.Cancel;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            this.Close();
        }

        /// <summary>
        /// OK�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00</br>
        /// <br>           : ���������\���@�\�ǉ��Ή�</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // �`�F�b�N
            if (!checkValues())
            {
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            if ( Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() ) == 3 )
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = 3;
            }
            else 
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            renewalOutputPattern( false );
            this._userSetting.OutputStyle = Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

            // �t�@�C����
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
            if (this.uCheckEditor_NoCountCtrl.Checked)
            {
                _userSetting.SearchCountCtrl = 1;
            }
            else
            {
                _userSetting.SearchCountCtrl = 0;
            }
            //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<

            // �p�^�[����
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();

            // �ԓ`���s�^�u�̓��e
            //this._userSetting.SlipNote1Pattern = this.uOptionSet_SlipNote.CheckedIndex;
            this._userSetting.SlipNote1Pattern = this.SlipNote;
            this._userSetting.SlipNote1Default = this.tEdit_SlipNote.Text.Trim();
            //this._userSetting.SlipNote2Pattern = this.uOptionSet_SlipNote2.CheckedIndex;
            this._userSetting.SlipNote2Pattern = this.SlipNote2;
            this._userSetting.SlipNote2Default = this.tEdit_SlipNote2.Text.Trim();
            //this._userSetting.SlipNote3Pattern = this.uOptionSet_SlipNote3.CheckedIndex;
            this._userSetting.SlipNote3Pattern = this.SlipNote3;
            this._userSetting.SlipNote3Default = this.tEdit_SlipNote3.Text.Trim();
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            this._userSetting.RedPrintDialog = this.RedPrintDialog;
            this._userSetting.ReisssuePrintDialog = this.ReisssuePrintDialog;
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<

            // -----------ADD 2009/12/28------------>>>>>
            this._userSetting.AllowRowFiltering = this.tComboEditor_AllowRowFiltering.SelectedIndex;
            this._userSetting.AllowColSwapping = this.tComboEditor_AllowColSwapping.SelectedIndex;
            this._userSetting.FixedHeaderIndicator = this.tComboEditor_FixedHeaderIndicator.SelectedIndex;
            // -----------ADD 2009/12/28------------<<<<<

            // 2010/04/15 Add >>>
            this._userSetting.ClaimeFileName = this.tEdit_ClaimeFileName.Text;
            this._userSetting.ChargeFileName = this.tEdit_ChargeFileName.Text;
            // 2010/04/15 Add <<<
            this._userSetting.InitSelectDisplay = this.InitSelectDisplay;// 2018/09/04 杍^�@���������\���̑Ή�

            // �V���A���C�Y
            this.Serialize();

            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
            if (this._opt_EBooksLink == (int)Option.ON)
            {
                // �d�q����A�g�ݒ���ۑ��@
                // PDF�v�����^���ڐݒ������������
                WriteEBooksOutputSetting();
            }
            // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

            //----- ADD 2015/02/05 ������ -------------------->>>>>
            if (TextOutputEvent != null)
            {
                TextOutputEvent(this, e);
            }
            //----- ADD 2015/02/05 ������ --------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this.DialogResult = DialogResult.OK;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            // �I��
            this.Close();
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // �{�^��

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        /// <summary>
        /// �ԓ`�ݒ�@���l�P�����\���@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uOptionSet_SlipNote_ValueChanged( object sender, EventArgs e )
        {
            //switch ( (int)uOptionSet_SlipNote.Value )
            switch ( this.SlipNote )
            {
                default:
                // ��
                case 0:
                    {
                        tEdit_SlipNote.Text = string.Empty;
                        tEdit_SlipNote.Enabled = false;
                    }
                    break;
                // ���t�E�`�[�ԍ�
                case 1:
                    {
                        tEdit_SlipNote.Text = string.Empty;
                        tEdit_SlipNote.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29--------->>>>>
                // ����
                case 2:
                    {
                        tEdit_SlipNote.Text = string.Empty;
                        tEdit_SlipNote.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29---------<<<<<
                // �C��
                //case 2:// DEL 2010/01/29
                case 3:// ADD 2010/01/29
                    {
                        tEdit_SlipNote.Enabled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// �ԓ`�ݒ�@���l�Q�����\���@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uOptionSet_SlipNote2_ValueChanged( object sender, EventArgs e )
        {
            //switch ( (int)uOptionSet_SlipNote2.Value )
            switch ( this.SlipNote2 )
            {
                default:
                // ��
                case 0:
                    {
                        tEdit_SlipNote2.Text = string.Empty;
                        tEdit_SlipNote2.Enabled = false;
                    }
                    break;
                // ���t�E�`�[�ԍ�
                case 1:
                    {
                        tEdit_SlipNote2.Text = string.Empty;
                        tEdit_SlipNote2.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29--------->>>>>
                // ����
                case 2:
                    {
                        tEdit_SlipNote2.Text = string.Empty;
                        tEdit_SlipNote2.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29---------<<<<<
                // �C��
                //case 2:// DEL 2010/01/29
                case 3:// ADD 2010/01/29
                    {
                        tEdit_SlipNote2.Enabled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// �ԓ`�ݒ�@���l�R�����\���@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uOptionSet_SlipNote3_ValueChanged( object sender, EventArgs e )
        {
            //switch ( (int)uOptionSet_SlipNote3.Value )
            switch ( this.SlipNote3 )
            {
                default:
                // ��
                case 0:
                    {
                        tEdit_SlipNote3.Text = string.Empty;
                        tEdit_SlipNote3.Enabled = false;
                    }
                    break;
                // ���t�E�`�[�ԍ�
                case 1:
                    {
                        tEdit_SlipNote3.Text = string.Empty;
                        tEdit_SlipNote3.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29--------->>>>>
                // ����
                case 2:
                    {
                        tEdit_SlipNote3.Text = string.Empty;
                        tEdit_SlipNote3.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29---------<<<<<
                // �C��
                //case 2:// DEL 2010/01/29
                case 3:// ADD 2010/01/29
                    {
                        tEdit_SlipNote3.Enabled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// �ݒ�^�u�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTabControl_Setting_SelectedTabChanged( object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e )
        {
            switch ( uTabControl_Setting.SelectedTab.Key )
            {
                default:
                    {
                    }
                    break;
                // �ԓ`�ݒ�
                case "RedSlip":
                    {
                        // �\���X�V
                        uOptionSet_SlipNote_ValueChanged( sender, new EventArgs() );
                        uOptionSet_SlipNote2_ValueChanged( sender, new EventArgs() );
                        uOptionSet_SlipNote3_ValueChanged( sender, new EventArgs() );
                    }
                    break;
            }
        }
        /// <summary>
        /// �e�L�X�g�o�̓p�^�[���폜�{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_PaternDelete_Click( object sender, EventArgs e )
        {
            if ( this.tComboEditor_PetternSelect.SelectedItem == null ) return;

            // ���ݑI������Ă���p�^�[�����폜�ΏۂƂ���
            string deletePattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();

            // �m�F�_�C�A���O
            if ( TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_DELETE_PATTERN + Environment.NewLine + Environment.NewLine + string.Format( "�o�̓p�^�[���F{0}", deletePattern ),
                -1, MessageBoxButtons.YesNo ) == DialogResult.No )
            {
                return;
            }

            // �폜
            # region [�폜]
            // ���݂̃p�^�[���ꗗ�����X�g�Ɋi�[����
            List<string> patternList = new List<string>( _outputPattern );
            string pName = string.Empty;

            // ���v����p�^�[�������폜
            foreach ( string pattern in this._outputPattern )
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );

                    // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                    if ( pName == deletePattern )
                    {
                        patternList.Remove( pattern );
                        break;
                    }
                }
            }
            // �폜��̃��X�g���e�Œu��������
            _outputPattern = patternList.ToArray();
            # endregion

            // �\���X�V
            # region [�\���X�V]
            // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
            this.tComboEditor_PetternSelect.Items.Clear();

            Infragistics.Win.ValueListItem item;
            foreach ( string pattern in this._outputPattern )
            {
                item = new Infragistics.Win.ValueListItem();

                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );
                    item.DataValue = pName;
                    item.DisplayText = pName;

                    this.tComboEditor_PetternSelect.Items.Add( item );
                }
            }
            // �ŏ��̃p�^�[����I������
            if ( tComboEditor_PetternSelect.Items.Count > 0 )
            {
                tComboEditor_PetternSelect.SelectedIndex = 0;
            }
            else
            {
                tComboEditor_PetternSelect.Text = string.Empty;
            }
            # endregion

            //// ���ʃ_�C�A���O
            //TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //    "�폜���܂����B",
            //    -1, MessageBoxButtons.OK );
        }
        /// <summary>
        /// �p�^�[���e�L�X�g�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PetternSelect_ValueChanged( object sender, EventArgs e )
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                // �����̃p�^�[��
                this.uComboEditor_PetternSelect_SelectionChangeCommitted( sender, e );
            }
            else
            {
                // �V�K�p�^�[��
            }

            // �폜�{�^���̗L����������
            uButton_PaternDelete.Enabled = (tComboEditor_PetternSelect.SelectedItem != null);
        }
        /// <summary>
        /// �ݒ�t�h�����\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU04004UA_Shown( object sender, EventArgs e )
        {
            tEdit_SettingFileName.Focus();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
        /// <summary>
        /// �������{�^���i�`�[�O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_SlipGrid_Click( object sender, EventArgs e )
        {
            InitializeSlipGrid( ref _userSetting );
            if ( this.ClearSettingSlipGrid != null )
            {
                this.ClearSettingSlipGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �������{�^���i���׃O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_DetailGrid_Click( object sender, EventArgs e )
        {
            InitializeDetailGrid( ref _userSetting );
            if ( this.ClearSettingDetailGrid != null )
            {
                this.ClearSettingDetailGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �������{�^���i�ԓ`�O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_RedSlipGrid_Click( object sender, EventArgs e )
        {
            InitializeRedSlipGrid( ref _userSetting );
            if ( this.ClearSettingRedSlipGrid != null )
            {
                this.ClearSettingRedSlipGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �������{�^���i�c���O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_BalanceGrid_Click( object sender, EventArgs e )
        {
            InitializeBalanceGrid( ref _userSetting );
            if ( this.ClearSettingBalanceGrid != null )
            {
                this.ClearSettingBalanceGrid( this, new EventArgs() );
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00 ���������\���̑Ή�</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            //if ( e.PrevCtrl == null || e.NextCtrl == null ) return;
            if ( e.PrevCtrl == null ) return;

            switch ( e.PrevCtrl.Name )
            {
                # region [�e�L�X�g�o��]
                case "tEdit_SettingFileName":
                    {
                        # region [���t�H�[�J�X]
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( !string.IsNullOrEmpty( tEdit_SettingFileName.Text ) )
                                        {
                                            // ������
                                            //e.NextCtrl = tComboEditor_PetternSelect; // DEL 2015/02/25 ������ Redmine#44701 No.1
                                            e.NextCtrl = this.uCheckEditor_NoCountCtrl; // ADD 2015/02/25 ������ Redmine#44701 No.1
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                case "uButton_FileSelect":
                    //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    e.NextCtrl = this.uCheckEditor_NoCountCtrl;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<
                    break;
                case "tComboEditor_PetternSelect":
                    {
                        # region [���t�H�[�J�X]
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tComboEditor_OutputStyle;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = uButton_PaternDelete;
                                    }
                                    break;
                            }
                        }
                        //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = this.uCheckEditor_NoCountCtrl;
                                    }
                                    break;
                            }
                        }
                        //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<
                        # endregion
                    }
                    break;

                case "tComboEditor_OutputStyle":
                case "rb_DividerChar_0":
                case "rb_DividerChar_1":
                case "tEdit_DividerChar":
                case "rb_DividerChar_2":
                case "rb_Parenthesis_0":
                case "rb_Parenthesis_1":
                case "tEdit_ParenthesisChar":
                case "rb_TieNumeric_0":
                case "rb_TieNumeric_1":
                case "rb_TieChar_0":
                case "rb_TieChar_1":
                case "rb_TitleLine_0":
                case "rb_TitleLine_1":
                //case "tComboEditor_OutputType":     //add by liusy #35729 2013/05/20 // DEL 2015/09/17 �c���� Redmine#47006
                    {
                        // �����ڂ��擾
                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                        if ( nextControl != null )
                        {
                            e.NextCtrl = nextControl;
                        }

                        //----- DEL 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>>
                        //if (!this._opFujikiCustom)
                        //{
                        //    if (e.PrevCtrl.Name == "tComboEditor_OutputType")
                        //    {

                        //        if (!e.ShiftKey)
                        //        {
                        //            switch (e.Key)
                        //            {
                        //                case Keys.Down:
                        //                    {
                        //                        e.NextCtrl = e.PrevCtrl;
                        //                    }
                        //                    break;
                        //                case Keys.Tab:
                        //                case Keys.Return:
                        //                    {
                        //                        // �^�u�؂�ւ�
                        //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                        //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                        //                        // ������
                        //                        e.NextCtrl = tEdit_ClaimeFileName;
                        //                    }
                        //                    break;
                        //                default:
                        //                    {
                        //                        // �����ڂ��擾
                        //                        Control nextActiveControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                        //                        if (nextActiveControl != null)
                        //                        {
                        //                            e.NextCtrl = nextActiveControl;
                        //                        }
                        //                    }
                        //                    break;
                        //            }
                        //        }
                        //    }
                        //}
                        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<
                        //----- DEL 2015/09/17 �c���� Redmine#47006 ----------<<<<<
                    }
                    break;
                /*del by liusy #35729 2013/05/20 -----<<<<<
                case "tComboEditor_OutputType":
                        {
                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Down:
                                            {
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                            break;
                                        case Keys.Tab:
                                        case Keys.Return:
                                            {
                                                // �^�u�؂�ւ�
                                        // 2010/04/15 >>>
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                                uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        // 2010/04/15 <<<
                                                uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                                // ������
                                        // 2010/04/15 >>>
                                        //e.NextCtrl = rb_SlipNote_0;
                                                e.NextCtrl = tEdit_ClaimeFileName;
                                        // 2010/04/15 <<<
                                            }
                                            break;
                                        default:
                                            {
                                                // �����ڂ��擾
                                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                                        if ( nextControl != null )
                                                {
                                            e.NextCtrl = nextControl;
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                    break;
                   del by liusy #35729 2013/05/20 ----->>>>>*/
                //----- DEL 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                //add by liusy #35729 2013/05/20 -----<<<<<
                //case "tComboEditor_DateType":
                //    {
                //        if (!e.ShiftKey)
                //        {
                //            switch (e.Key)
                //            {
                //                case Keys.Down:
                //                    {
                //                        e.NextCtrl = e.PrevCtrl;
                //                    }
                //                    break;
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // �^�u�؂�ւ�
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // ������
                //                        e.NextCtrl = tEdit_ClaimeFileName;
                //                    }
                //                    break;
                //                default:
                //                    {
                //                        // �����ڂ��擾
                //                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                //                        if (nextControl != null)
                //                        {
                //                            e.NextCtrl = nextControl;
                //                        }
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                   //add by liusy #35729 2013/05/20 ----->>>>>
                //----- DEL 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                case "tComboEditor_OutputType":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        if (this.uCheckEditor_RetSlipMinus_Saleslip.Visible)
                                        {
                                            e.NextCtrl = uCheckEditor_RetSlipMinus_Saleslip;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uCheckEditor_RetSlipMinus_Meisai;
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        // �����ڂ��擾
                                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                                    }
                                    break;
                case "tComboEditor_DateType":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // �����ڂ��擾
                                        Control nextControl = _focusControl1.GetNextControl(tComboEditor_OutputType, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                    {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        // �����ڂ��擾
                                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                                        if ( nextControl != null )
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                        //----- ADD 2015/02/05 ������ -------------------->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �����ڂ��擾
                                        e.NextCtrl = this.tComboEditor_OutputType;
                                    }
                                    break;
                            }
                        } 
                        //----- ADD 2015/02/05 ������ --------------------<<<<<
                    }
                    break;
                   //add by liusy #35729 2013/05/20 ----->>>>>
                //----- ADD 2015/02/05 ������ -------------------->>>>>
                case "uCheckEditor_NoCountCtrl":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ������
                                        e.NextCtrl = this.tComboEditor_PetternSelect;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ������
                                        e.NextCtrl = this.uButton_FileSelect;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                //----- ADD 2015/02/05 ������ --------------------<<<<<

                case "uCheckEditor_RetSlipMinus_Saleslip": // �ԕi�`�[���z���}�C�i�X�ŏo�͂̋敪
                case "uCheckEditor_RetSlipMinus_Meisai":
                    {

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_OutputType;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = tEdit_ClaimeFileName;

                                    }
                                    break;
                                default:
                                    {
                                        // �����ڂ��擾
                                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // ������
                            e.NextCtrl = tComboEditor_OutputType;
                        }
                    }
                    break;
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                # endregion

                // 2010/04/15 Add >>>
                #region [�c���o��]
                case "tEdit_ClaimeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_ClaimeFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_ChargeFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_ClaimeFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (uTabControl_Setting.Tabs["TextOutput"].Visible == true)
                                        {
                                            // �^�u�؂�ւ�
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            // ������
                                            //e.NextCtrl = tComboEditor_OutputType; del by liusy #35729 2013/05/20

                                            //----- DEL 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                                            //if (this.tComboEditor_DateType.Visible)
                                            //{
                                            //    e.NextCtrl = tComboEditor_DateType; //add by liusy #35729 2013/05/20
                                            //}
                                            //else
                                            //{
                                            //    e.NextCtrl = tComboEditor_OutputType;
                                            //}
                                            //----- DEL 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                                            //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                                            // ������
                                            if (this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0")
                                            {
                                                e.NextCtrl = uCheckEditor_RetSlipMinus_Saleslip; // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�̋敪
                                            }
                                            else
                                            {
                                                e.NextCtrl = uCheckEditor_RetSlipMinus_Meisai; // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�̋敪
                                            }
                                            //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<
                                        }
                                        else
                                        {
                                            // ������
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        // ----------UPD 2010/01/29----------<<<<<

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_ChargeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_ChargeFileName.Text))
                                        {
                                            // ������
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            e.NextCtrl = rb_SlipNote_0;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_ChargeFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_ChargeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ������
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        e.NextCtrl = rb_SlipNote_0;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                #endregion
                // 2010/04/15 Add <<<

                # region [�ԓ`���s]
                case "rb_SlipNote_0":
                    {
                        if ( !e.ShiftKey )
                        {
                            // �����ڂ��擾
                            Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                            if ( nextControl != null )
                            {
                                e.NextCtrl = nextControl;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ----------UPD 2010/01/29---------->>>>>
                                        //// �^�u�؂�ւ�
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                        //uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        //// ������
                                        //e.NextCtrl = tComboEditor_OutputType;
                                        // 2010/04/15 >>>
                                        //if (uTabControl_Setting.Tabs["TextOutput"].Visible == true)
                                        if (uTabControl_Setting.Tabs["BalanceOutput"].Visible == true)
                                        // 2010/04/15 <<<
                                        {
                                            // �^�u�؂�ւ�
                                            // 2010/04/15 >>>
                                            //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                            // 2010/04/15 <<<
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            // ������
                                            // 2010/04/15 >>>
                                            //e.NextCtrl = tComboEditor_OutputType;
                                            e.NextCtrl = tEdit_ChargeFileName;
                                            // 2010/04/15 <<<
                                        }
                                        else
                                        {
                                            // ������
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        // ----------UPD 2010/01/29----------<<<<<

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "rb_SlipNote_1":
                case "rb_SlipNote_2":
                case "rb_SlipNote_3":// ADD 2010/01/29
                case "tEdit_SlipNote":
                case "rb_SlipNote2_0":
                case "rb_SlipNote2_1":
                case "rb_SlipNote2_2":
                case "rb_SlipNote2_3":// ADD 2010/01/29
                case "tEdit_SlipNote2":
                case "rb_SlipNote3_0":  // ADD 2013/04/19 T.Miyamoto
                case "rb_SlipNote3_1":  // ADD 2013/04/19 T.Miyamoto
                case "rb_SlipNote3_2":  // ADD 2013/04/19 T.Miyamoto
                case "rb_SlipNote3_3":  // ADD 2013/04/19 T.Miyamoto
                case "tEdit_SlipNote3": // ADD 2013/04/19 T.Miyamoto
                    {
                        // �����ڂ��擾
                        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                        if ( nextControl != null )
                        {
                            e.NextCtrl = nextControl;
                        }
                    }
                    break;
                // DEL 2013/04/19 T.Miyamoto ------------------------------>>>>>
                //case "rb_SlipNote3_0":
                //case "rb_SlipNote3_1":
                //case "rb_SlipNote3_2":// ADD 2010/01/29
                //    {
                //        // �����ڂ��擾
                //        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //        if ( nextControl != null )
                //        {
                //            e.NextCtrl = nextControl;
                //        }

                //        if ( !tEdit_SlipNote3.Enabled )
                //        {
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Down:
                //                        {
                //                            e.NextCtrl = e.PrevCtrl;
                //                        }
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //    break;
                ////case "rb_SlipNote3_2":// DE; 2010/01/29
                //case "rb_SlipNote3_3":// ADD 2010/01/29
                //    {
                //        // �����ڂ��擾
                //        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //        if ( nextControl != null )
                //        {
                //            e.NextCtrl = nextControl;
                //        }

                //        if ( !tEdit_SlipNote3.Enabled )
                //        {
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Down:
                //                        {
                //                            e.NextCtrl = e.PrevCtrl;
                //                        }
                //                        break;
                //                    case Keys.Tab:
                //                    case Keys.Return:
                //                        {
                //                            // ---------------UPD 2009/12/28--------------->>>>>
                //                            // �^�u�؂�ւ�
                //                            //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                //                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                //                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                            // ������
                //                            //e.NextCtrl = uButton_Clear_SlipGrid;
                //                            e.NextCtrl = tComboEditor_AllowRowFiltering;
                //                            // ---------------UPD 2009/12/28---------------<<<<<
                //                        }
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //    break;
                //case "tEdit_SlipNote3":
                //    {
                //        if ( !e.ShiftKey )
                //        {
                //            switch ( e.Key )
                //            {
                //                case Keys.Down:
                //                    {
                //                        e.NextCtrl = e.PrevCtrl;
                //                    }
                //                    break;
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // -------------UPD 2009/12/28------------->>>>>
                //                        // �^�u�؂�ւ�
                //                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // ������
                //                        //e.NextCtrl = uButton_Clear_SlipGrid;
                //                        e.NextCtrl = tComboEditor_AllowRowFiltering;
                //                        // -------------UPD 2009/12/28-------------<<<<<
                //                    }
                //                    break;
                //                default:
                //                    {
                //                        // �����ڂ��擾
                //                        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //                        if ( nextControl != null )
                //                        {
                //                            e.NextCtrl = nextControl;
                //                        }
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                // DEL 2013/04/19 T.Miyamoto ------------------------------<<<<<
                // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
                case "tComboEditor_RedPrintDialog":
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                        e.NextCtrl = tComboEditor_ReisssuePrintDialog;
                                        }
                                        break;
                                }
                            }
                        }
                    break;
                case "tComboEditor_ReisssuePrintDialog":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = tComboEditor_AllowRowFiltering;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
                # endregion

                // ------------ADD 2009/12/28------------->>>>>
                # region [���א���]
                case "tComboEditor_AllowRowFiltering":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tComboEditor_AllowColSwapping;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        // UPD 2013/04/19 T.Miyamoto ------------------------------>>>>>
                                        //if (tEdit_SlipNote3.Enabled)
                                        //{
                                        //    e.NextCtrl = tEdit_SlipNote3;
                                        //}
                                        //else
                                        //{
                                        //    e.NextCtrl = rb_SlipNote3_3;
                                        //}
                                        e.NextCtrl = tComboEditor_ReisssuePrintDialog;
                                        // UPD 2013/04/19 T.Miyamoto ------------------------------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tComboEditor_AllowColSwapping":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tComboEditor_FixedHeaderIndicator;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tComboEditor_FixedHeaderIndicator":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        //----- UPD�@2018/09/04 杍^�@���������\���̑Ή�------->>>>>
                                        // �^�u�؂�ւ�
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TabControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        //e.NextCtrl = uButton_Clear_SlipGrid;
                                        e.NextCtrl = tComboEditor_InitSelectDisplay;
                                        //----- UPD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion
                // ------------ADD 2009/12/28-------------<<<<<
                //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�------->>>>>
                # region [�^�u����]
                case "tComboEditor_InitSelectDisplay":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = uButton_Clear_SlipGrid;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = tComboEditor_FixedHeaderIndicator;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion
                //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<
                # region [�ݒ�N���A]
                case "uButton_Clear_SlipGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_SlipGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {

                                        //----- UPD�@2018/09/04 杍^�@���������\���̑Ή�------->>>>>
                                        // -------------UPD 2009/12/28--------------->>>>>
                                        // �^�u�؂�ւ�
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TabControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        //e.NextCtrl = tComboEditor_FixedHeaderIndicator;
                                        e.NextCtrl = tComboEditor_InitSelectDisplay;
                                        // -------------UPD 2009/12/28---------------<<<<<
                                        //----- UPD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_DetailGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_DetailGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_RedSlipGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_RedSlipGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_BalanceGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        //e.NextCtrl = uButton_OK;  // DEL 2022/05/05 ���� �[�i���d�q����A�g�Ή�
                                        // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@------->>>>>
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["EbooksLinkSetting"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = tComboEditor_OutPutMode;
                                        // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@-------<<<<<
                                    }
                                    break;
                                case Keys.Return:
                                    {
                                        uButton_Clear_BalanceGrid_Click( this, new EventArgs() );
                                        // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@------->>>>>
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["EbooksLinkSetting"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = tComboEditor_OutPutMode;
                                        // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@-------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion

                // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@------->>>>>
                // 
                case "tComboEditor_OutPutMode":
                    if (e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    // �^�u�؂�ւ�
                                    uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                    uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                    // ������
                                    e.NextCtrl = uButton_Clear_SlipGrid;
                                }
                                break;
                        }
                    }
                    break;
                // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@-------<<<<<
                case "uButton_OK":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        // �{�^������
                                        uButton_OK_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Cancel":
                    if ( !e.ShiftKey )
                    {
                        switch ( e.Key )
                        {
                            case Keys.Return:
                                {
                                    // �{�^������
                                    uButton_Cancel_Click( this, new EventArgs() );
                                }
                                break;
                            case Keys.Tab:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// ��؂蕶��Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_0_Enter( object sender, EventArgs e )
        {
            this.DividerChar = prevDividerChar;
        }
        /// <summary>
        /// ��؂蕶��Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_0_Leave( object sender, EventArgs e )
        {
            prevDividerChar = this.DividerChar;
        }
        /// <summary>
        /// ��؂蕶��Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_1_CheckedChanged( object sender, EventArgs e )
        {
            if ( rb_DividerChar_1.Checked )
            {
                tEdit_DividerChar.Enabled = true;
            }
            else
            {
                tEdit_DividerChar.Enabled = false;
                tEdit_DividerChar.Clear();
            }
        }
        /// <summary>
        /// ���蕶��Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_0_Enter( object sender, EventArgs e )
        {
            this.Parenthesis = prevParenthesis;
        }
        /// <summary>
        /// ���蕶��Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_0_Leave( object sender, EventArgs e )
        {
            prevParenthesis = this.Parenthesis;
        }
        /// <summary>
        /// ���蕶��Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_1_CheckedChanged( object sender, EventArgs e )
        {
            if ( rb_Parenthesis_1.Checked )
            {
                tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                tEdit_ParenthesisChar.Enabled = false;
                tEdit_ParenthesisChar.Clear();
            }
        }
        /// <summary>
        /// ���l����Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieNumeric_0_Enter( object sender, EventArgs e )
        {
            this.TieNumeric = prevTieNumeric;
        }
        /// <summary>
        /// ���l����Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieNumeric_0_Leave( object sender, EventArgs e )
        {
            prevTieNumeric = this.TieNumeric;
        }
        /// <summary>
        /// ��������Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieChar_0_Enter( object sender, EventArgs e )
        {
            this.TieChar = prevTieChar;
        }
        /// <summary>
        /// ��������Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieChar_0_Leave( object sender, EventArgs e )
        {
            prevTieChar = this.TieChar;
        }
        /// <summary>
        /// �^�C�g���sEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TitleLine_0_Enter( object sender, EventArgs e )
        {
            this.TitleLine = prevTitleLine;
        }
        /// <summary>
        /// �^�C�g���sLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TitleLine_0_Leave( object sender, EventArgs e )
        {
            prevTitleLine = this.TitleLine;
        }
        /// <summary>
        /// �`�[���l�PEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote_0_Enter( object sender, EventArgs e )
        {
            this.SlipNote = prevSlipNote;
        }
        /// <summary>
        /// �`�[���l�PLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote_0_Leave( object sender, EventArgs e )
        {
            prevSlipNote = this.SlipNote;
        }
        /// <summary>
        /// �`�[���l�QEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote2_0_Enter( object sender, EventArgs e )
        {
            this.SlipNote2 = prevSlipNote2;
        }
        /// <summary>
        /// �`�[���l�QLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote2_0_Leave( object sender, EventArgs e )
        {
            prevSlipNote2 = this.SlipNote2;
        }
        /// <summary>
        /// �`�[���l�REnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote3_0_Enter( object sender, EventArgs e )
        {
            this.SlipNote3 = prevSlipNote3;
        }
        /// <summary>
        /// �`�[���l�RLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote3_0_Leave( object sender, EventArgs e )
        {
            prevSlipNote3 = this.SlipNote3;
        }
        /// <summary>
        /// ���l�P�C�Ӄ`�F�b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rb_SlipNote_2_CheckedChanged( object sender, EventArgs e )// DEL 2010/01/29
        private void rb_SlipNote_3_CheckedChanged(object sender, EventArgs e)// ADD 2010/01/29
        {
            if ( rb_SlipNote_3.Checked )
            {
                tEdit_SlipNote.Enabled = true;
            }
            else
            {
                tEdit_SlipNote.Enabled = false;
                tEdit_SlipNote.Clear();
            }
        }
        /// <summary>
        /// ���l�Q�C�Ӄ`�F�b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rb_SlipNote2_2_CheckedChanged( object sender, EventArgs e )// DEL 2010/01/29
        private void rb_SlipNote2_3_CheckedChanged(object sender, EventArgs e)// ADD 2010/01/29
        {
            if ( rb_SlipNote2_3.Checked )
            {
                tEdit_SlipNote2.Enabled = true;
            }
            else
            {
                tEdit_SlipNote2.Enabled = false;
                tEdit_SlipNote2.Clear();
            }
        }
        /// <summary>
        /// ���l�R�C�Ӄ`�F�b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rb_SlipNote3_2_CheckedChanged( object sender, EventArgs e )// DEL 2010/01/29
        private void rb_SlipNote3_3_CheckedChanged(object sender, EventArgs e)// ADD 2010/01/29
        {
            if ( rb_SlipNote3_3.Checked )
            {
                tEdit_SlipNote3.Enabled = true;
            }
            else
            {
                tEdit_SlipNote3.Enabled = false;
                tEdit_SlipNote3.Clear();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD
        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\������
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/29</br>
        /// <remarks>
        public void uTabControlSet(bool display)
        {
            //�e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B
            uTabControl_Setting.Tabs["TextOutput"].Visible = display;
            // 2010/04/15 Add >>>
            uTabControl_Setting.Tabs["BalanceOutput"].Visible = display;
            // 2010/04/15 Add <<<
        }

        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
        /// <summary>
        /// �d�q����A�g�I�v�V�����̗L���A�����Őݒ�̓d�q����A�g�^�u�̕\������
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : �d�q����A�g�I�v�V�����̗L���A�����Őݒ�̓d�q����A�g�^�u�̕\��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2022/05/05</br>
        /// </remarks>
        public void uTabControlEbookLinkSet(bool display)
        {
            // �d�q����A�g�I�v�V�����̗L���A�����Őݒ�̓d�q����A�g�^�u�̕\��������s���B
            uTabControl_Setting.Tabs["EbooksLinkSetting"].Visible = display;
        }
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

        // 2010/04/15 Add >>>
        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ClaimeFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_ClaimeFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_ClaimeFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_ClaimeFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ChargeFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_ChargeFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_ChargeFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_ChargeFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>
        /// ���o���������Ȃ��I��ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���o���������Ȃ��I��ύX�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// <br>UpdateNote : 2015/03/03 ������ Redmine#44701</br>
        /// <br>           : ���o���������Ȃ��`�F�b�N���̃��b�Z�[�W�̕ύX</br>
        /// </remarks>
        private void uCheckEditor_NoCountCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (uCheckEditor_NoCountCtrl.Checked)
            {
                if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                    //"���o���������Ȃ��ŏo�͂��܂��B��낵���ł����H", -1, MessageBoxButtons.YesNo) == DialogResult.No) // DEL 2015/03/03 ������ Redmine#44701
                    "20,000���̒��o���������Ȃ��ŏo�͂��܂��B\n��낵���ł����H", -1, MessageBoxButtons.YesNo) == DialogResult.No) // ADD 2015/03/03 ������ Redmine#44701
                { 
                    uCheckEditor_NoCountCtrl.CheckedChanged -= new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                    uCheckEditor_NoCountCtrl.Checked = false;
                    uCheckEditor_NoCountCtrl.CheckedChanged += new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                }
            }
        }
        //----- ADD 2015/02/05 ������ --------------------<<<<<
        // 2010/04/15 Add <<<
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
        #region[�d�q����A�g�������\��]
        /// <summary>
        /// �d�q����A�g�������\��
        /// </summary>
        private void InitEBooksLinkSetting()
        {

            if (this._opt_EBooksLink == (int)Option.ON)
            {
                // �v�����^Dic
                _printDic = new Dictionary<string, string>();
                // �v�����^Dic�����擾
                ArrayList printerList = new ArrayList();
                // �v�����^�}�X�^�A�N�Z�X�N���X
                _prtManageAcs = new PrtManageAcs();
                try
                {
                    if (_prtManageAcs.SearchAll(out printerList, LoginInfoAcquisition.EnterpriseCode) == 0)
                    {
                        foreach (PrtManage prtManage in printerList)
                        {
                            // �_���폜����Ă���v�����^�ݒ�}�X�^�f�[�^�͖���
                            if (!prtManage.LogicalDeleteCode.Equals(0)) continue;
                            // �v�����^Dic
                            _printDic.Add(prtManage.PrinterMngNo.ToString(), prtManage.PrinterName.ToUpper());
                        }
                    }
                }
                catch (Exception)
                {
                    // �v�����^Dic
                    _printDic = new Dictionary<string, string>();
                }

                // ���Ӑ�d�q������PDF�o�͐ݒ�t�@�C�����擾
                _eBooksOutputSetting = geteBooksOutputSetting();
                // ����t�@�C�����ݔ��f
                if (!UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFPrinterSettingEnable_Xml)))
                {
                    // PDF�v�����^���� ����s��
                    tComboEditor_PdfPrinter.Enabled = false;
                }
                else
                {
                    // PDF�v�����^���� �����
                    tComboEditor_PdfPrinter.Enabled = true;
                }

                // �`�[PDF�o�� 
                tComboEditor_OutPutMode.SelectedIndex = Convert.ToInt32(_eBooksOutputSetting.OutputMode);
                // �o�͓`�[�敪
                uCheckEditor_DebitNote.Checked = false;
                uCheckEditor_RePrint.Checked = false;
                switch (Convert.ToInt32(_eBooksOutputSetting.OutputSlipType))
                {
                    case (Int32)outPutSlipTypeEnum.DebitNoteChecked:
                        uCheckEditor_DebitNote.Checked = true;
                        break;
                    case (Int32)outPutSlipTypeEnum.RePrintChecked:
                        uCheckEditor_RePrint.Checked = true;
                        break;
                    case (Int32)outPutSlipTypeEnum.All:
                        uCheckEditor_DebitNote.Checked = true;
                        uCheckEditor_RePrint.Checked = true;
                        break;
                    case (Int32)outPutSlipTypeEnum.No:
                        uCheckEditor_DebitNote.Checked = false;
                        uCheckEditor_RePrint.Checked = false;
                        break;
                    default:
                        uCheckEditor_DebitNote.Checked = true;
                        uCheckEditor_RePrint.Checked = false;
                        break;
                }
                // PDF�v�����^ [Windows�W���^���̑�]
                tComboEditor_PdfPrinter.SelectedIndex = Convert.ToInt32(_eBooksOutputSetting.PDFPrinter);
                // ���蓖�čς݂̃v�����^�Ǘ��ԍ�
                string sPrintName = string.Empty;
                // ���蓖�čς݂̃v�����^�Ǘ��ԍ�
                _eBooksOutputSetting.PDFPrinterNumber = string.Empty;
                foreach (string key in _printDic.Keys)
                {
                    sPrintName = _printDic[key].ToUpper();
                    // Windows�W��
                    if (Convert.ToInt32(_eBooksOutputSetting.PDFPrinter) == (int)pdfPrinterEnum.BaseSetting_Xml)
                    {
                        if (sPrintName.Contains(ctBase_PrintName))
                        {
                            // �v�����^�ԍ�
                            _eBooksOutputSetting.PDFPrinterNumber = key;
                            break;
                        }

                    }
                    // ���̑�
                    else
                    {
                        // PRIMO PDF�ECube PDF �v�����^
                        if (sPrintName.Contains(ctOther_CubePrintName))
                        {
                            // �v�����^�ԍ�
                            _eBooksOutputSetting.PDFPrinterNumber = key;
                            break;
                        }
                    }
                }

                tEdit_PdfPrinterNumber.Text = _eBooksOutputSetting.PDFPrinterNumber;
                // �z�v�����^���䂪�I������܂ł̑ҋ@���ԃ~���b
                tEdit_PdfPrinterWait.Text = _eBooksOutputSetting.PDFPrinterWait;
            }
        }
        #endregion

        # region[���Ӑ�d�q������PDF�o�͐ݒ�t�@�C�����擾]
        /// <summary>
        /// ���Ӑ�d�q������PDF�o�͐ݒ�t�@�C�����擾
        /// </summary>
        public eBooksOutputSetting geteBooksOutputSetting()
        {
            eBooksOutputSetting eBookSetting = null;
            try
            {
                // ����t�@�C������PDF�v�����^���ڐݒ�XML�t�@�C�����݂̏ꍇ
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFOutputSettings_Xml)))
                    {
                        eBookSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFOutputSettings_Xml));
                    }
            }
            catch (Exception)
            {
                //�@���������e���Ȃ�
            }

            // PDF�v�����^�ݒ荀�ڂ̃f�t�H���g�l��ݒ�
            if (eBookSetting == null)
            {
                eBookSetting = new eBooksOutputSetting();
                eBookSetting.OutputMode = DEFAULT_PDFOUTPUT_VALUE;           �@ // �`�[PDF�o��
                eBookSetting.OutputSlipType = DEFAULT_OUTPUTSLIPTYPE_VALUE;     // �o�͓`�[�敪
                eBookSetting.PDFPrinter = DEFAULT_PRINTER_VALUE;                // PDF�v�����^ [Windows�W���^���̑�]
                eBookSetting.PDFPrinterNumber = DEFAULT_PRINTERNO_VALUE;        // ���蓖�čς݂̃v�����^�Ǘ��ԍ�
                eBookSetting.PDFPrinterWait = DEFAULT_PRINTERWAUTTIME_VALUE;    // ���z�v�����^���䂪�I������܂ł̑ҋ@����(�~���b)
            }

            return eBookSetting;
        }
        # endregion

        # region[PDF�v�����^���ڐݒ������������]
        /// <summary>
        ///PDF�v�����^���ڐݒ������������
        /// </summary>
        /// <returns></returns>
        public void WriteEBooksOutputSetting()
        {
            try
            {
                eBooksOutputSetting setting = new eBooksOutputSetting();

                // �`�[PDF�o��
                setting.OutputMode = Convert.ToString(tComboEditor_OutPutMode.SelectedIndex);
                // �o�͓`�[�敪
                int iOutputSlipType = 0;
                if ((!uCheckEditor_DebitNote.Checked) && (!uCheckEditor_RePrint.Checked)) 
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.No;
                }
                else if ((uCheckEditor_DebitNote.Checked) && (uCheckEditor_RePrint.Checked)) 
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.All;
                }
                else if (uCheckEditor_RePrint.Checked)
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.RePrintChecked;
                }
                else if (uCheckEditor_DebitNote.Checked)
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.DebitNoteChecked;
                }
                setting.OutputSlipType = iOutputSlipType.ToString();

                // PDF�v�����^ [Windows�W���^���̑�] 
                setting.PDFPrinter = Convert.ToString(tComboEditor_PdfPrinter.SelectedIndex);
                // ���蓖�čς݂̃v�����^�Ǘ��ԍ�
                setting.PDFPrinterNumber = tEdit_PdfPrinterNumber.Text.Trim();
                // ���z�v�����^���䂪�I������܂ł̑ҋ@����(�~���b)
                setting.PDFPrinterWait = Convert.ToString(tEdit_PdfPrinterWait.GetInt());

                UserSettingController.SerializeUserSetting(setting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFOutputSettings_Xml)));
            }
            catch (Exception)
            {
                //�@���������e���Ȃ�
            }
 
        }
        #endregion

        #region [PDF�v�����^�ύX�A������]
        /// <summary>
        /// PDF�v�����^�ύX�A������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PdfPrinter_ValueChanged(object sender, EventArgs e)
        {
            tEdit_PdfPrinterNumber.Text = string.Empty;
            if (_printDic.Count > 0) 
            {
                string sPrintName = string.Empty;
                foreach (string key in _printDic.Keys)
                {
                    sPrintName = _printDic[key].ToUpper();
                    // Windows�W��
                    if (tComboEditor_PdfPrinter.SelectedIndex == (int)pdfPrinterEnum.BaseSetting_Xml)
                    {
                        if (sPrintName.Contains(ctBase_PrintName))
                        {
                            // �v�����^�ԍ�
                            tEdit_PdfPrinterNumber.Text = key;
                            break;
                        }
                    }
                    // ���̑�
                    else
                    {
                        // Cube PDF �v�����^
                        if (sPrintName.Contains(ctOther_CubePrintName))
                        {
                            // �v�����^�ԍ�
                            tEdit_PdfPrinterNumber.Text = key;
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<
    }

    // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
    # region [PDF�v�����^���ڐݒ���]
    /// <summary>
    /// PDF�v�����^���ڐݒ���
    /// </summary>
    /// <remarks> 
    /// </remarks>
    public class eBooksOutputSetting
    {
        /// <summary>PDF�v�����^���ڐݒ���</summary>
        public eBooksOutputSetting()
        {

        }

        /// <summary>�`�[PDF�o��</summary>
        private string _outputMode;
        /// <summary>�o�͓`�[�敪</summary>
        private string _outputSlipType;
        /// <summary>PDF�v�����^ [Windows�W���^���̑�] </summary>
        private string _pDFPrinter;
        /// <summary>���蓖�čς݂̃v�����^�Ǘ��ԍ� </summary>
        private string _pDFPrinterNumber;
        /// <summary>���z�v�����^���䂪�I������܂ł̑ҋ@����(�~���b)</summary>
        private string _pDFPrinterWait;

        /// <summary>�`�[PDF�o��</summary>
        public string OutputMode
        {
            get { return _outputMode; }
            set { _outputMode = value; }
        }

        /// <summary>�o�͓`�[�敪</summary>
        public string OutputSlipType
        {
            get { return _outputSlipType; }
            set { _outputSlipType = value; }
        }
        /// <summary>PDF�v�����^ [Windows�W���^���̑�] </summary>
        public string PDFPrinter
        {
            get { return _pDFPrinter; }
            set { _pDFPrinter = value; }
        }

        /// <summary>���蓖�čς݂̃v�����^�Ǘ��ԍ� </summary>
        public string PDFPrinterNumber
        {
            get { return _pDFPrinterNumber; }
            set { _pDFPrinterNumber = value; }
        }

        /// <summary>���z�v�����^���䂪�I������܂ł̑ҋ@����</summary>
        public string PDFPrinterWait
        {
            get { return _pDFPrinterWait; }
            set { _pDFPrinterWait = value; }
        }

    }
    #endregion
    // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

    /// <summary>
    /// ���Ӑ�d�q�����p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q�����̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br>Update Note: 2018/09/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11470152-00 ���������\���̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CustPtrSalesUserConst
    {

        # region �v���C�x�[�g�ϐ�

        // �o�̓t�@�C����
        private string _outputFileName;

        //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
        // ���o���������Ȃ�
        private int _searchCountCtrl;
        //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<

        // �o�͌`��
        private int _outputStyle;

        // �o�̓p�^�[��
        private string[] _outputPattern;

        // �I�����ꂽ�p�^�[����
        private string _selectedPatternName;

        // ���l�P�p�^�[��
        private int _slipNote1Pattern;

        // ���l�P�C��
        private string _slipNote1Default;

        // ���l�Q�p�^�[��
        private int _slipNote2Pattern;

        // ���l�Q�C��
        private string _slipNote2Default;

        // ���l�R�p�^�[��
        private int _slipNote3Pattern;

        // ���l�R�C��
        private string _slipNote3Default;

        // 2010/04/15 Add >>>
        // �o�̓t�@�C�����i�����j
        private string _claimeFileName;

        // �o�̓t�@�C�����i���|�j
        private string _chargeFileName;
        // 2010/04/15 Add <<<

        /// <summary>���ڋ�؂蕶��</summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
        //private const string STRING_DIVIDER = "/";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        private const string STRING_DIVIDER = "'";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

        //private const int[] DEFAULT_VAL_SLIP = { 0, 0, 0, 2, 3, 0, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 0, 27, 28, 29, 30, 31, 0, 32, 33 };

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
        // �L���ȏڍ׏������X�g
        private List<string> _enabledConditionList;
        // --------------ADD 2009/12/28------------->>>>>
        // �L���Ȋ�{�������X�g
        private List<string> _enabledCommonConditionList;
        // �ڍ׏���Enable���X�g
        private List<string> _enabledList;
        // --------------ADD 2009/12/28-------------<<<<<
        // �`�[�O���b�h�J�������X�g
        private List<ColumnInfo> _slipColumnsList;
        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;
        // �`�[�O���b�h�J�������X�g
        private List<ColumnInfo> _redSlipColumnsList;
        // �c���O���b�h�J�������X�g
        private List<ColumnInfo> _balanceColumnsList;

        // �ڍ׏����O���[�v�W�J���
        private bool _extraConditionExpanded;
        // ���v�\���O���[�v�W�J���
        private bool _balanceChartExpanded;

        // �`�[�O���b�h�����T�C�Y����
        private bool _autoAdjustSlip;
        // ���׃O���b�h�����T�C�Y����
        private bool _autoAdjustDetail;
        // �ԓ`�O���b�h�����T�C�Y����
        private bool _autoAdjustRedSlip;
        // �c���O���b�h�����T�C�Y����
        private bool _autoAdjustBalance;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

        // ------------ADD 2009/12/28------------>>>>>
        // �s�t�B���^
        private int _allowRowFiltering;
        // �����
        private int _allowColSwapping;
        // ��Œ�
        private int _fixedHeaderIndicator;
        // ------------ADD 2009/12/28------------<<<<<

        // ADD 2012/06/01 ----------------------->>>>>
        // ���o���_���
        private int _remainSectionType;
        // ADD 2012/06/01 ----------------------->>>>>

        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        // �`�[����m�F�_�C�A���O(�ԓ`���s)
        private bool _RedPrintDialog;
        // �`�[����m�F�_�C�A���O(�Ĕ��s)
        private bool _ReisssuePrintDialog;
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        private int _initSelectDisplay;// 2018/09/04 杍^�@���������\���̑Ή�

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// ���Ӑ�d�q�������[�U�[�ݒ���N���X
        /// </summary>
        public CustPtrSalesUserConst()
        {
            
        }

        # endregion // �R���X�g���N�^

        # region �v���p�e�B

        /// <summary>�o�̓t�@�C����</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        //----- ADD 2015/02/25 ������ Redmine#44701 No.1 -------------------->>>>>
        /// <summary>
        /// ���o���������Ȃ�
        /// </summary>
        public int SearchCountCtrl
        {
            get { return _searchCountCtrl; }
            set { _searchCountCtrl = value; }
        }
        //----- ADD 2015/02/25 ������ Redmine#44701 No.1 --------------------<<<<<

        /// <summary>�o�͌^��</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>�o�̓p�^�[��</summary>
        public string[] OutputPattern
        {
            get { return this._outputPattern; }
            set { this._outputPattern = value; }
        }

        /// <summary>�I���p�^�[����</summary>
        public string SelectedPatternName
        {
            get { return this._selectedPatternName; }
            set { this._selectedPatternName = value; }
        }

        /// <summary>���l�P�p�^�[��</summary>
        public int SlipNote1Pattern
        {
            get { return this._slipNote1Pattern; }
            set { this._slipNote1Pattern = value; }
        }

        /// <summary>���l�P�C�Ӑݒ�</summary>
        public string SlipNote1Default
        {
            get { return this._slipNote1Default; }
            set { this._slipNote1Default = value; }
        }

        /// <summary>���l�Q�p�^�[��</summary>
        public int SlipNote2Pattern
        {
            get { return this._slipNote2Pattern; }
            set { this._slipNote2Pattern = value; }
        }

        /// <summary>���l�Q�C�Ӑݒ�</summary>
        public string SlipNote2Default
        {
            get { return this._slipNote2Default; }
            set { this._slipNote2Default = value; }
        }
        /// <summary>���l�R�p�^�[��</summary>
        public int SlipNote3Pattern
        {
            get { return this._slipNote3Pattern; }
            set { this._slipNote3Pattern = value; }
        }

        /// <summary>���l�R�C�Ӑݒ�</summary>
        public string SlipNote3Default
        {
            get { return this._slipNote3Default; }
            set { this._slipNote3Default = value; }
        }

        /// <summary>��؂蕶��</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        // 2010/04/15 Add >>>
        // �o�̓t�@�C�����i�����j
        public string ClaimeFileName
        {
            get { return this._claimeFileName; }
            set { this._claimeFileName = value; }
        }

        // �o�̓t�@�C�����i���|�j
        public string ChargeFileName
        {
            get { return this._chargeFileName; }
            set { this._chargeFileName = value; }
        }
        // 2010/04/15 Add <<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
        /// <summary>�L���ȏڍ׏������X�g</summary>
        public List<string> EnabledConditionList
        {
            get { return this._enabledConditionList; }
            set { this._enabledConditionList = value; }
        }
        // -----------ADD 2009/12/28----------->>>>>
        /// <summary>�L���Ȋ�{�������X�g</summary>
        public List<string> EnabledCommonConditionList
        {
            get { return this._enabledCommonConditionList; }
            set { this._enabledCommonConditionList = value; }
        }
        /// <summary>�L���Ȋ�{����Enable���X�g</summary>
        public List<string> EnabledList
        {
            get { return this._enabledList; }
            set { this._enabledList = value; }
        }
        // -----------ADD 2009/12/28-----------<<<<<
        /// <summary>�`�[�O���b�h�J�������X�g</summary>
        public List<ColumnInfo> SlipColumnsList
        {
            get { return this._slipColumnsList; }
            set { this._slipColumnsList = value; }
        }
        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        /// <summary>�c���O���b�h�J�������X�g</summary>
        public List<ColumnInfo> RedSlipColumnsList
        {
            get { return this._redSlipColumnsList; }
            set { this._redSlipColumnsList = value; }
        }
        /// <summary>�c���O���b�h�J�������X�g</summary>
        public List<ColumnInfo> BalanceColumnsList
        {
            get { return this._balanceColumnsList; }
            set { this._balanceColumnsList = value; }
        }
        /// <summary>�ڍ׏����O���[�v�W�J���</summary>
        public bool ExtraConditionExpanded
        {
            get { return _extraConditionExpanded; }
            set { _extraConditionExpanded = value; }
        }
        /// <summary>���v�\���O���[�v�W�J���</summary>
        public bool BalanceChartExpanded
        {
            get { return _balanceChartExpanded; }
            set { _balanceChartExpanded = value; }
        }
        /// <summary>�`�[�O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustSlip
        {
            get { return _autoAdjustSlip; }
            set { _autoAdjustSlip = value; }
        }
        /// <summary>���׃O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustDetail
        {
            get { return _autoAdjustDetail; }
            set { _autoAdjustDetail = value; }
        }
        /// <summary>�ԓ`�O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustRedSlip
        {
            get { return _autoAdjustRedSlip; }
            set { _autoAdjustRedSlip = value; }
        }
        /// <summary>�c���O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustBalance
        {
            get { return _autoAdjustBalance; }
            set { _autoAdjustBalance = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

        // -----------ADD 2009/12/28----------->>>>>
        /// <summary>�s�t�B���^</summary>
        public int AllowRowFiltering
        {
            get { return _allowRowFiltering; }
            set { _allowRowFiltering = value; }
        }
        /// <summary>�����</summary>
        public int AllowColSwapping
        {
            get { return _allowColSwapping; }
            set { _allowColSwapping = value; }
        }
        /// <summary>��Œ�</summary>
        public int FixedHeaderIndicator
        {
            get { return _fixedHeaderIndicator; }
            set { _fixedHeaderIndicator = value; }
        }
        // -----------ADD 2009/12/28-----------<<<<<

        // ADD 2012/06/01 ----------------------->>>>>
        /// <summary>���o���_���</summary>
        public int RemainSectionType
        {
            get { return _remainSectionType; }
            set { _remainSectionType = value; }
        }
        // ADD 2012/06/01 -----------------------<<<<<

        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        /// <summary>�`�[����m�F�_�C�A���O(�ԓ`���s)</summary>
        public bool RedPrintDialog
        {
            get { return this._RedPrintDialog; }
            set { this._RedPrintDialog = value; }
        }
        /// <summary>�`�[����m�F�_�C�A���O(�Ĕ��s)</summary>
        public bool ReisssuePrintDialog
        {
            get { return this._ReisssuePrintDialog; }
            set { this._ReisssuePrintDialog = value; }
        }
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�------->>>>>
        /// <summary>�^�u����̏����I��</summary>
        public int InitSelectDisplay
        {
            get { return this._initSelectDisplay; }
            set { this._initSelectDisplay = value; }
        }
        //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<

        # endregion

        /// <summary>
        /// ���Ӑ�d�q�������[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>���Ӑ�d�q�������[�U�[�ݒ���N���X</returns>
        public CustPtrSalesUserConst Clone()
        {
            CustPtrSalesUserConst constObj = new CustPtrSalesUserConst();
            return constObj;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        /// <summary>
        /// �t�@�C���g���q�ϊ�����
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newExtension"></param>
        /// <returns></returns>
        public static string ChangeFileExtension( string fileName, string selectedValue )
        {
            string newExt = string.Empty;
            switch ( selectedValue )
            {
                case "0":
                    newExt = ".CSV";
                    break;
                case "1":
                    newExt = ".TXT";
                    break;
                case "2":
                    newExt = ".PRN";
                    break;
                case "3":
                default:
                    break;
            }
            if ( newExt != string.Empty )
            {
                try
                {
                    fileName = Path.ChangeExtension( fileName, newExt );
                }
                catch
                {
                }
            }
            return fileName;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>��</summary>
        private string _columnName;
        /// <summary>���я�</summary>
        private int _visiblePosition;
        /// <summary>��\���t���O</summary>
        private bool _hidden;
        /// <summary>��</summary>
        private int _width;
        /// <summary>�Œ�t���O</summary>
        private bool _columnFixed;
        /// <summary>
        /// ��
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// ���я�
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// ��\���t���O
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// �Œ�t���O
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="visiblePosition">���я�</param>
        /// <param name="hidden">��\���t���O</param>
        /// <param name="width">��</param>
        /// <param name="columnFixed">�Œ�t���O</param>
        public ColumnInfo( string columnName, int visiblePosition, bool hidden, int width, bool columnFixed )
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 ADD
    /// <summary>
    /// ColumnInfo��r�N���X�i�\�[�g�p�j
    /// </summary>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo��r����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare( ColumnInfo x, ColumnInfo y )
        {
            // ��\�����Ŕ�r
            int result = x.VisiblePosition.CompareTo( y.VisiblePosition );
            // ��\��������v����ꍇ�͗񖼂Ŕ�r(�ʏ�͔������Ȃ�)
            if ( result == 0 )
            {
                result = x.ColumnName.CompareTo( y.ColumnName );
            }
            return result;
        }
    }
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 ADD
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
    # region [��ʃt�H�[�J�X����N���X]
    /// <summary>
    /// ��ʃt�H�[�J�X����N���X
    /// </summary>
    internal class FocusControl
    {
        List<List<Control>> _controls;
        Dictionary<string, int> _col;
        Dictionary<string, int> _row;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FocusControl()
        {
            this.Clear();
        }

        /// <summary>
        /// ����������
        /// </summary>
        public void Clear()
        {
            _controls = new List<List<Control>>();
            _col = new Dictionary<string, int>();
            _row = new Dictionary<string, int>();
        }

        /// <summary>
        /// �P�s�ǉ�
        /// </summary>
        /// <param name="controls"></param>
        public void AddLine( params Control[] controls )
        {
            List<Control> line = new List<Control>( controls );

            for ( int index = 0; index < line.Count; index++ )
            {
                int col = index;
                int row = _controls.Count;

                _col.Add( line[index].Name, col );
                _row.Add( line[index].Name, row );
            }
            
            _controls.Add( line );
        }

        /// <summary>
        /// ���R���g���[���擾�i�t�H�[�J�X�ړ���j
        /// </summary>
        /// <param name="prevControl"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        public Control GetNextControl( Control prevControl, Keys key, bool shiftKey )
        {
            Control nextControl = null;

            if ( !_col.ContainsKey( prevControl.Name ) ) return null;

            int col = _col[prevControl.Name];
            int row = _row[prevControl.Name];

            if ( _controls[row][col].Name != prevControl.Name ) return null;

            if ( !shiftKey )
            {
                switch ( key )
                {
                    # region [UP]
                    case Keys.Up:
                        {
                            if ( row - 1 >= 0 )
                            {
                                int originCol = col;
                                row--;

                                if ( col > _controls[row].Count - 1 )
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while ( nextControl == null || nextControl.Enabled == false )
                                {
                                    if ( col > 0 )
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if ( row > 0 )
                                    {
                                        col = originCol;
                                        row--;
                                        if ( col > _controls[row].Count - 1 )
                                        {
                                            col = _controls[row].Count - 1;
                                        }
                                        nextControl = _controls[row][col];
                                    }
                                    else
                                    {
                                        nextControl = null;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                nextControl = null;
                            }
                        }
                        break;
                    # endregion

                    # region [DOWN]
                    case Keys.Down:
                        {
                            if ( row + 1 <= _controls.Count - 1 )
                            {
                                int originCol = col;
                                row++;

                                if ( col > _controls[row].Count - 1 )
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while ( nextControl == null || nextControl.Enabled == false )
                                {
                                    if ( col > 0 )
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if ( row + 1 <= _controls.Count - 1 )
                                    {
                                        col = originCol;
                                        row++;
                                        if ( col > _controls[row].Count - 1 )
                                        {
                                            col = _controls[row].Count - 1;
                                        }
                                        nextControl = _controls[row][col];
                                    }
                                    else
                                    {
                                        nextControl = null;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                nextControl = null;
                            }
                        }
                        break;
                    # endregion

                    # region [LEFT]
                    case Keys.Left:
                        {
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col > 0 )
                                {
                                    col--;
                                    nextControl = _controls[row][col];
                                }
                                else
                                {
                                    nextControl = null;
                                    break;
                                }
                            }
                        }
                        break;
                    # endregion

                    # region [RIGHT]
                    case Keys.Right:
                        {
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col < _controls[row].Count - 1 )
                                {
                                    col++;
                                    nextControl = _controls[row][col];
                                }
                                else
                                {
                                    nextControl = null;
                                    break;
                                }
                            }
                        }
                        break;
                    # endregion

                    # region [Tab����]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab��������
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col + 1 <= _controls[row].Count - 1 )
                                {
                                    col++;
                                }
                                else if ( row + 1 <= _controls.Count - 1 )
                                {
                                    row++;
                                    col = 0;
                                }
                                else
                                {
                                    break;
                                }
                                nextControl = _controls[row][col];
                            }
                        }
                        break;
                    # endregion
                }
            }
            else
            {
                switch ( key )
                {
                    # region [Tab���O]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab���O����
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col - 1 >= 0 )
                                {
                                    col--;
                                }
                                else if ( row - 1 >= 0 )
                                {
                                    row--;
                                    col = _controls[row].Count - 1;
                                }
                                else
                                {
                                    break;
                                }

                                nextControl = _controls[row][col];
                            }
                        }
                        break;
                    # endregion
                }
            }

            return nextControl;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
    # region [�O���b�h�E��I���_�C�A���O����N���X]
    /// <summary>
    /// �O���b�h�E��I���_�C�A���O����N���X
    /// </summary>
    /// <remarks>Grid�̃J�����`���[�U�����ʉ����܂�</remarks>
    public class GridColumnChooserControl
    {
        private List<Infragistics.Win.UltraWinGrid.UltraGrid> _targetList;
        private Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog> _chooserDialogs;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GridColumnChooserControl()
        {
            _targetList = new List<Infragistics.Win.UltraWinGrid.UltraGrid>();
            _chooserDialogs = new Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog>();
        }

        /// <summary>
        /// �Ώےǉ�
        /// </summary>
        /// <param name="targetGrid"></param>
        public void Add( Infragistics.Win.UltraWinGrid.UltraGrid targetGrid )
        {
            if ( !_targetList.Contains( targetGrid ) )
            {
                // �Ώ�Grid���X�g
                _targetList.Add( targetGrid );
                // �J�����`���[�U�_�C�A���O
                _chooserDialogs.Add( targetGrid.Name, CreateColumnChooser( targetGrid ) );

                // �Ώ�Grid�ւ̑���
                targetGrid.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
                targetGrid.BeforeColumnChooserDisplayed += new Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventHandler( uGrid_BeforeColumnChooserDisplayed );
            }
        }
        /// <summary>
        /// �J�����`���[�U�[�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>��Grid�̃f�t�H���g�̃J�����`���[�U�[���J�X�^�}�C�Y���܂�</remarks>
        private void uGrid_BeforeColumnChooserDisplayed( object sender, Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventArgs e )
        {
            // �f�t�H���g�̏����̓L�����Z������
            e.Cancel = true;
            //bool flag = false;

            // �J�����`���[�U�[�_�C�A���O
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = _chooserDialogs[(sender as Control).Name];
            if ( chooser == null ) return;

            try
            {
                //-----------------------------------------------------------------
                // �����ӁF
                //   �Ӑ}�I�ɖ����Ȓl-1��^���鎖�Œ��O�Ƀ\�[�g��������Ȃ��悤�ɂ���B
                //-----------------------------------------------------------------
                chooser.ColumnChooserControl.ColumnDisplayOrder = (Infragistics.Win.UltraWinGrid.ColumnDisplayOrder)(-1);
                chooser.Show();
            }
            catch
            {
                // ��O
            }
        }
        /// <summary>
        /// �J�����`���[�U�[��������
        /// </summary>
        /// <param name="chooser"></param>
        private Infragistics.Win.UltraWinGrid.ColumnChooserDialog CreateColumnChooser( Infragistics.Win.UltraWinGrid.UltraGrid sourceGrid )
        {
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = new Infragistics.Win.UltraWinGrid.ColumnChooserDialog();

            chooser.Text = "�\�����ڂ̑I��";
            chooser.StartPosition = FormStartPosition.CenterScreen;
            chooser.Size = new Size( 250, 400 );
            chooser.TopMost = true;

            // �\����������A�j�����Ȃ�
            chooser.DisposeOnClose = Infragistics.Win.DefaultableBoolean.False;

            chooser.ColumnChooserControl.SourceGrid = sourceGrid;
            chooser.ColumnChooserControl.Font = sourceGrid.Font;

            return chooser;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
}