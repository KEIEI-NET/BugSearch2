using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �`�[����m�F���
    /// </summary>
    /// <remarks>
    /// <br>Note         : �`�[����m�F��ʂł��B</br>
    /// <br>               �`�[����N���X(ISlipPrintProc����������N���X)���Ăяo���Ĉ�����s���܂��B</br>
    /// <br>               ( �����̂t�h�N���X�́A��ɁuDCCMN02000UA�v����Ăяo���܂��B )</br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2007.12.17</br>
    /// <br></br>
    /// <br>Update Note  : 2008.01.30 ��� ���b</br>
    /// <br>                 �@�d���ԕi�`�[����@�\��ǉ�</br>
    /// <br>Update Note  : 2008.02.22 ��� ���b</br>
    /// <br>                 �@�`�[�����l�ݒ�}�X�^���Q�Ƃ��Ȃ��悤�ɕύX</br>
    /// <br>                 �A�`�[���s��A�����[�g�Ăяo���Ńf�[�^���X�V����悤�ɕύX</br>
    /// <br>Update Note  : 2008.03.11 ��� ���b</br>
    /// <br>                 �@����E�d�����䃊���[�g�Ή��i�X�V���ʂ��G���g���ɕԋp����ׂ̑Ή��j</br>
    /// <br>---------------------------------------------------------------------------------</br>
    /// <br>Update Note  : 2008.05.29 ��� ���b</br>
    /// <br>                 �@PM.NS�����ύX�B</br>
    /// <br>                 �A���R���[(����`�[)�̈���@�\��ǉ��B</br>
    /// <br>                 �B�璷��Interface������폜�B</br>
    /// <br>                 �C�����������̈�,D�N���X�g�p/PMHNB08001P�Ȃ���ڸ��݂��Ȃ�/UI�\������ꍇ�݂̂̏����𐮗�</br>
    /// <br>Update Note  : 2009.07.16  20056 ���n ���</br>
    /// <br>             : �T�[�o�[�֔z�u����N���C�A���g�A�Z���u���Ή�</br>
    /// <br>             : �@���O�C�����擾���@�ύX</br>
    /// <br>             : �A�T�[�r�X�N���v���p�e�B�ǉ�</br>
    /// <br>             : �B�E�C���h�E�\�������ǉ�</br>
    /// <br>Update Note  : 2010.03.04  ���@�r��</br>
    /// <br>                 �@�ŗ��ݒ�A������z�����敪�ݒ���擾����</br>
    /// <br>Update Note  : 2010/05/14  22018 ��� ���b</br>
    /// <br>                 �T�u���|�[�g�@�\�̒ǉ��B�i�X��ʑΉ��ׁ̈A�ǉ��j</br>
    /// <br>Update Note  : 2010/05/18  30531 ��� �r��</br>
    /// <br>                 UOE�K�C�h���̐ݒ�擾�Ή��B�i�X��ʑΉ��ׁ̈A�ǉ��j</br>
    /// <br>Update Note  : 2010/06/04  22018 ��� ���b</br>
    /// <br>                 ���ʕ�����</br>
    /// <br>                   �r�b�l 2009.07.16 �̑g��</br>
    /// <br>Update Note  : 2010/07/09  22018 ��� ���b</br>
    /// <br>                 ���ʕ������Q</br>
    /// <br>                   ����`�[���͂̂t�h���"�p�q�R�[�h�쐬"�`�F�b�N�{�b�N�X�l����n�\�ɕύX�B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/08/30  30517 �Ė� �x��</br>
    /// <br>                 �ʑΉ����ǑΉ�</br>
    /// <br>                   ���R���[�i����`�[�j�ʑΉ��p����N���X�̌ʏ����t���O���Q�Ƃ��A�����𕪊򂷂�l�ɏC��</br>
    /// <br>             : �T�[�r�X�N��(�T�[�o�[)�������Ȃ����ׁA_isService �����0�Ƃ��� </br>
    /// <br>Update Note  : 2011/08/09  �����J</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : �����[�g�`�[���s</br>
    /// <br>Update Note  : 2011/09/16  �����J</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : ��������敪�{�w�C�x�ʒu����</br>
    /// <br>Update Note  : 2011/09/27  ���v��</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559�̑Ή�</br>
    /// <br>Update Note  : 2011/09/28  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25595�̑Ή�</br>
    /// <br>Update Note  : 2011/09/30  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 No2�̑Ή�</br>
    /// <br>Update Note  : 2011/10/11  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 �̑Ή�</br>
    /// <br>Update Note  : 2011/10/13  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 �̑Ή�</br>
    /// <br>Update Note  : 2011/10/15  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 �̑Ή�</br>
    /// <br>Update Note  : 2011/10/17  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 PCC�S�̐ݒ�.����`�[���s�敪�`�B�b�N�G�[���Ή�</br>
    /// <br>Update Note  : 2011/10/19  20056 ���n ���</br>
    /// <br>             : ��Q�Ή��F�݌Ɉړ��`�[���͂œ`������ƃG���[</br>
    /// <br>Update Note  : 2013/04/19  �{�{ ����</br>
    /// <br>             : �N����PG�����Ӑ�d�q�����Ŋm�F��ʂ�\������ꍇ�A�Ǘ������P�̃v�����^�������\������悤�ɏC��</br>
    /// <br>Update Note  : 2013/06/17  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : ��10542 SCM</br>
    /// <br>Update Note  : 2013/07/28  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : ��10542 SCM NO.10�̑Ή�</br>
    /// <br>Update Note  : 2013/09/19  30744 ����</br>
    /// <br>             : Redmine #40342</br>
    /// <br>             : �����[�g�`�[���s���G���[�Ή�</br>
    /// <br>Update Note  : 2013/09/20  �g��</br>
    /// <br>             : �����e��UOE���M���� ���x�x���Ή�</br>
    /// <br>Update Note  : 2014/07/30  杍^</br>
    /// <br>             : �u���Ӑ�d�q��������ԓ`�𔭍s����Ɗm�F�_�C�A���O���Q��\���i���`���Q�����j����A�����`���o�͂���Ȃ��v��Q�̑Ή��B</br>
    /// <br>             : Redmine#43082�u��Q�ꗗNo.10664�v</br>
    /// <br>Update Note  : 2014/12/05  �{�{ ����</br>
    /// <br>             : �d�|�ꗗ��2295(��1725)�Ή�</br>
    /// <br>             : ����������ɓo�^�����C�x���g�n���h�����A�����I����ɑS�č폜����悤�ɏC��</br>
    /// <br>Update Note  : 2013/10/30  30744 ����</br>
    /// <br>             : SCM�d�|�ꗗ��10614�Ή�</br>
    /// </remarks>
    internal class DCCMN02000UB : System.Windows.Forms.Form
    {
        #region Const
        //===================================
        // ���̑�
        //===================================
        /// <summary>�t�H�[���`�撆</summary>
        private const string ctFormDrawingNow = "FORMDRAWING";
        // �V�X�e���敪
        private const int ctSYSTEMDIV_CD = 0;
        // �摜�g�p�V�X�e���敪	
        private const int ctIMAGEUSESYSTEM_CODE = 10;
        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        // �ďo��PGID����p(���Ӑ挳��)
        private const string ctPGID_PMKAU04000U = "PMKAU04000U";
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        #endregion

        #region PrivateMember
        //==================================================================================
        // �v���C�x�C�g�����o��`
        //==================================================================================
        //***************************************************************
        // �����g�p�����o
        //***************************************************************
        // �`�[�������
        private ISlipPrintCndtn _iSlipPrintCndtn;
        // ����f�[�^
        private List<ArrayList> _printData;

        // �`�[����ݒ�f�[�^
        private SlipPrtSetWork _slipPrtSet;

        // ����v���r���[�t�H�[��
        private SFMIT01290UA _slipPrintAssemblyFrom;
        // ����h�L�������g�쐬���W���[��
        private Object _prtObj = null;
        // ����v���r���[�p�p�����[�^�N���X
        private SFMIT01290UB _prtParam;

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // �`�[���
        private int _slipKind = 0;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
        //// �񍀖ڃe�[�u��
        //private static Hashtable _slipColList = new Hashtable();
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
        // �O��l
        private string _prevText = "";
        private int _prevInt = 0;
        // ��ʃ^�C�v(0:�ȈՔŁA1:�ڍה�)
        private int _FormType = 0;

        // �_�C�A���O�Ȃ��������t���O
        private bool _printWithoutDialog;

        // �`�[����A�N�Z�X�N���X
        private SlipPrintAcs _slipPrintAcs;

        // �`�[����p�����[�^�i�f�[�^�N���X�O���j
        private SlipPrintParameter _slipPrintParameter;

        // �`�[����_�C�A���O�X�e�[�^�X
        private SlipPrintDialogStatus _slipPrintDialogState;
        // �`�[����_�C�A���O�f�[�^�L���b�V��
        private SlipDialogDataCache _dataCache;
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�T�[�r�X�N���t���O(0:�ʏ� 1:�T�[�r�X�N��)</summary> 
        private int _isService = 0;
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        //�����[�g�`�[���s���邩
        private bool _IsRmSlpPrt;
        //�����[�g�`�[���s�ݒ���
        private RmSlpPrtStWork _rmSlpPrtStWork;
        //�����[�g�`�[���s�A�N�Z�X�N���X
        private ScmRtPrtDtAcs _scmRtPrtDtAcs;
        //PCC���Аݒ�}�X�^�A�N�Z�X�N���X
        PccCmpnyStAcs _pccCmpnyStAcs;
        //PCC�S�̐ݒ�}�X�^�A�N�Z�X�N���X
        PccTtlStAcs _pccTtlStAcs;
        /// <summary>PCCUOE�����񓚋N���t���O(0:�ʏ� 1:PCCUOE�����񓚋N��)</summary> 
        private int _isAutoAns = 0;
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        /// <summary>����`�[���ʂ͂P���t���O�ifalse:�P���ȏ�Atrue:�P���j</summary> 
        private bool _isOnlyOneSlip = false;
        /// <summary>�Ō㑗�M�̔���`�[�t���O�ifalse:�Ō�ł͂Ȃ��Atrue:�Ō�j</summary> 
        private bool _isLastSlip = false;
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        /// <summary>�����[�g�`�[�ŐV���ʋ敪KEY�ύX�t���O�ifalse:�ύX���Ȃ��Atrue:�ύX����j</summary> 
        private bool _isKeyChangeFlag = false;
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        // ADD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
        /// <summary>����`�[�ԍ����X�g</summary> 
        private List<string> _slipNumlist;
        /// <summary>�⍇���ԍ����X�g</summary> 
        private List<string> _inquiryNumList;
        /// <summary>�^�u���b�g�N���敪</summary> 
        private bool _isTablet = false;
        // ADD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
        #endregion

        #region Component
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Broadleaf.Library.Windows.Forms.TLine tLine1;
        private Broadleaf.Library.Windows.Forms.TLine tLine2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox8;
        private System.Windows.Forms.Panel Form1_Fill_Panel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Splitter splitter1;
        private Infragistics.Win.Misc.UltraButton ubDetail;
        private Broadleaf.Library.Windows.Forms.TComboEditor tcePrintType;
        private System.Windows.Forms.Panel pnlBottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager utmMain;
        private Infragistics.Win.Misc.UltraGroupBox ugbPrintCopy;
        private Broadleaf.Library.Windows.Forms.TNedit tnPrintCopy;
        private Infragistics.Win.Misc.UltraLabel ulPrintCopy;
        private Infragistics.Win.Misc.UltraGroupBox ugbPrintRange;
        private Broadleaf.Library.Windows.Forms.TNedit tnPrintRangeTo;
        private Infragistics.Win.Misc.UltraLabel ulPrintRangeTo;
        private Broadleaf.Library.Windows.Forms.TNedit tnPrintRangeFrom;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosPrintRange;
        private Infragistics.Win.Misc.UltraLabel ulPrintRangeFrom;
        private Infragistics.Win.Misc.UltraGroupBox ugbPrinter;
        private Broadleaf.Library.Windows.Forms.TComboEditor tcePrinterName;
        private Infragistics.Win.Misc.UltraLabel ulPrinterName;
        private Infragistics.Win.Misc.UltraGroupBox ugbFormat;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ucePrevew;
        private Infragistics.Win.Misc.UltraLabel ulPrintMsg;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl utcDetail;
        private Infragistics.Win.Misc.UltraButton ubPdf;
        private Infragistics.Win.Misc.UltraButton ubPrint;
        private Infragistics.Win.Misc.UltraButton ubCancel;
        private System.Windows.Forms.Splitter splitter2;
        private Infragistics.Win.Misc.UltraGroupBox ugbCopyCount;
        private Infragistics.Win.Misc.UltraLabel ulCopyCount;
        private Infragistics.Win.Misc.UltraGroupBox ugbTitle;
        private Infragistics.Win.Misc.UltraLabel ulTitle4;
        private Infragistics.Win.Misc.UltraLabel ulTitle3;
        private Infragistics.Win.Misc.UltraLabel ulTitle2;
        private Infragistics.Win.Misc.UltraLabel ulTitle1;
        private Infragistics.Win.Misc.UltraGroupBox ugbSlipDatePrintDiv;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosSlipDatePrintDiv;
        private Infragistics.Win.Misc.UltraGroupBox ugbEnterpriseNamePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosEnterpriseNamePrtCd;
        private Infragistics.Win.Misc.UltraGroupBox ugbEachSlipTypeColMove;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugEachSlipTypeColMove;
        private Infragistics.Win.Misc.UltraGroupBox ugbEachSlipTypeCol;
        private Infragistics.Win.UltraWinTree.UltraTree utEachSlipTypeCol;
        private Infragistics.Win.Misc.UltraGroupBox ugbOutlinePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosOutlinePrtCd;
        private Infragistics.Win.Misc.UltraGroupBox ugbBankNamePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosBankNamePrtCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSourceColMove;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Bottom;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceSlipFontSize;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceSlipFontStyle;
        private Infragistics.Win.UltraWinEditors.UltraFontNameEditor ufneSlipFontName;
        private Broadleaf.Library.Windows.Forms.TNedit tneTopMargin;
        private Broadleaf.Library.Windows.Forms.TNedit tneLeftMargin;
        private System.Windows.Forms.Panel pnlPrevew;
        private Infragistics.Win.Misc.UltraLabel ulLeftMark1;
        private Infragistics.Win.Misc.UltraLabel ulLeftMark2;
        private Infragistics.Win.Misc.UltraLabel ulTopMark2;
        private Infragistics.Win.Misc.UltraLabel ulTopMark1;
        private Infragistics.Win.Misc.UltraGroupBox ugbMargin;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpHeader;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpDetail;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpDetail2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpMargin;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpFont;
        private Broadleaf.Library.Windows.Forms.TNedit tneRightMargin;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Broadleaf.Library.Windows.Forms.TLine tLine3;
        private Broadleaf.Library.Windows.Forms.TLine tLine4;
        private Infragistics.Win.Misc.UltraLabel ulBottomMark2;
        private Infragistics.Win.Misc.UltraLabel ulBottomMark1;
        private Infragistics.Win.Misc.UltraLabel ulRightMark2;
        private Infragistics.Win.Misc.UltraLabel ulRightMark1;
        private Broadleaf.Library.Windows.Forms.TNedit tneBottomMargin;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor tnCopyCount;
        private Infragistics.Win.Misc.UltraGroupBox ugbCustTelNoPrtDivCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosCustTelNoPrtDivCd;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox upbSlipImage;
        private System.Windows.Forms.ImageList ilSlipPrintImage;
        private System.Windows.Forms.PictureBox pbCompanyImage;
        private Infragistics.Win.Misc.UltraGroupBox ugbTotalPricePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosTotalPricePrtCd;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.ImageList imgListIntensive;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT4;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT3;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT2;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT1;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT4;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT3;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT2;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle2;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle3;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle4;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uttmToolTip;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private System.ComponentModel.IContainer components;
        #endregion

        #region Dispose
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // --- ADD 2014/12/05 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �C�x���g�n���h���폜
        /// </summary>
        public void EventDelete()
        {
            this.uosSlipDatePrintDiv.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.tnCopyCount.ValueChanged -= new System.EventHandler(this.tnCopyCount_TextChanged);
            this.tnCopyCount.Leave -= new System.EventHandler(this.UltraFontNameEditorLeave);
            this.tnCopyCount.Enter -= new System.EventHandler(this.UltraFontNameEditorEnter);
            this.tceTitle4.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.tceTitle3.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.tceTitle2.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.tceTitle1.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.ubSlipColorT4.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.ubSlipColorT3.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.ubSlipColorT2.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.ubSlipColorT1.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.uosEnterpriseNamePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosCustTelNoPrtDivCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosTotalPricePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.ugEachSlipTypeColMove.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugEachSlipTypeColMove_InitializeLayout);
            this.ugEachSlipTypeColMove.AfterColPosChanged -= new Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler(this.ugEachSlipTypeColMove_AfterColPosChanged);
            this.utEachSlipTypeCol.AfterCheck -= new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.utEachSlipTypeCol_AfterCheck);
            this.tneBottomMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneBottomMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tneRightMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneRightMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tneTopMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneTopMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tneLeftMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneLeftMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tceSlipFontSize.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.ufneSlipFontName.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.ufneSlipFontName.Leave -= new System.EventHandler(this.UltraFontNameEditorLeave);
            this.ufneSlipFontName.Enter -= new System.EventHandler(this.UltraFontNameEditorEnter);
            this.tceSlipFontStyle.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosOutlinePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosBankNamePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.utmMain.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.utmMain_ToolClick);
            this.tnPrintRangeTo.ValueChanged -= new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            this.tnPrintRangeFrom.ValueChanged -= new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            this.uosPrintRange.ValueChanged -= new System.EventHandler(this.uosPrintRange_ValueChanged);
            this.ubDetail.Click -= new System.EventHandler(this.ubDetail_Click);
            this.tcePrintType.ValueChanged -= new System.EventHandler(this.tcePrintType_ValueChanged);
            this.ubCancel.Click -= new System.EventHandler(this.ubPrint_Click);
            this.ubPrint.Click -= new System.EventHandler(this.ubPrint_Click);
            this.ubPdf.Click -= new System.EventHandler(this.ubPrint_Click);
            this.tRetKeyControl1.ChangeFocus -= new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            this.tArrowKeyControl1.ChangeFocus -= new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            this.Load -= new System.EventHandler(this.DCCMN02000UB_Load);
            this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.DCCMN02000UA_KeyDown);
        }
        // --- ADD 2014/12/05 T.Miyamoto ------------------------------<<<<<
        #endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�I���K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�I���K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�I���K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�I���K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ColMove", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 0");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 4");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 6");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 7");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 8");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 9");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 0");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 1");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 2");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn4 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 3");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 4");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 5");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn7 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 6");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn8 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 7");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn9 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 8");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn10 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 9");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton2 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton3 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton4 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cancel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cancel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf");
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton5 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton6 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton7 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCCMN02000UB));
            this.utpHeader = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbSlipDatePrintDiv = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosSlipDatePrintDiv = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ugbCopyCount = new Infragistics.Win.Misc.UltraGroupBox();
            this.tnCopyCount = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ulCopyCount = new Infragistics.Win.Misc.UltraLabel();
            this.ugbTitle = new Infragistics.Win.Misc.UltraGroupBox();
            this.tceTitle4 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceTitle3 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceTitle2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceTitle1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ubSlipColorT4 = new Infragistics.Win.Misc.UltraButton();
            this.ubSlipColorT3 = new Infragistics.Win.Misc.UltraButton();
            this.ubSlipColorT2 = new Infragistics.Win.Misc.UltraButton();
            this.ubSlipColorT1 = new Infragistics.Win.Misc.UltraButton();
            this.ulSlipColorT4 = new Infragistics.Win.Misc.UltraLabel();
            this.ulSlipColorT3 = new Infragistics.Win.Misc.UltraLabel();
            this.ulSlipColorT2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulSlipColorT1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle3 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle4 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbEnterpriseNamePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosEnterpriseNamePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ugbCustTelNoPrtDivCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosCustTelNoPrtDivCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.utpDetail = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbTotalPricePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosTotalPricePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.utpDetail2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbEachSlipTypeColMove = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ugEachSlipTypeColMove = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSourceColMove = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ugbEachSlipTypeCol = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.utEachSlipTypeCol = new Infragistics.Win.UltraWinTree.UltraTree();
            this.utpMargin = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbMargin = new Infragistics.Win.Misc.UltraGroupBox();
            this.ulRightMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulRightMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulBottomMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulBottomMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine3 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tneBottomMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tneRightMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ulTopMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulLeftMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulLeftMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTopMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tneTopMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tneLeftMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.upbSlipImage = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.utpFont = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox8 = new Infragistics.Win.Misc.UltraGroupBox();
            this.pbCompanyImage = new System.Windows.Forms.PictureBox();
            this.tceSlipFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ufneSlipFontName = new Infragistics.Win.UltraWinEditors.UltraFontNameEditor();
            this.tceSlipFontStyle = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbOutlinePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosOutlinePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ugbBankNamePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosBankNamePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.utcDetail = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.utmMain = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.pnlPrevew = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ugbPrintCopy = new Infragistics.Win.Misc.UltraGroupBox();
            this.tnPrintCopy = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ulPrintCopy = new Infragistics.Win.Misc.UltraLabel();
            this.ugbPrintRange = new Infragistics.Win.Misc.UltraGroupBox();
            this.tnPrintRangeTo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ulPrintRangeTo = new Infragistics.Win.Misc.UltraLabel();
            this.tnPrintRangeFrom = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uosPrintRange = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ulPrintRangeFrom = new Infragistics.Win.Misc.UltraLabel();
            this.ugbPrinter = new Infragistics.Win.Misc.UltraGroupBox();
            this.tcePrinterName = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ulPrinterName = new Infragistics.Win.Misc.UltraLabel();
            this.ugbFormat = new Infragistics.Win.Misc.UltraGroupBox();
            this.ubDetail = new Infragistics.Win.Misc.UltraButton();
            this.ucePrevew = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ulPrintMsg = new Infragistics.Win.Misc.UltraLabel();
            this.tcePrintType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubPrint = new Infragistics.Win.Misc.UltraButton();
            this.ubPdf = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this._SFMIT01407UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT01407UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT01407UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ilSlipPrintImage = new System.Windows.Forms.ImageList(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.imgListIntensive = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.uttmToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.utpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbSlipDatePrintDiv)).BeginInit();
            this.ugbSlipDatePrintDiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosSlipDatePrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCopyCount)).BeginInit();
            this.ugbCopyCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnCopyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbTitle)).BeginInit();
            this.ugbTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEnterpriseNamePrtCd)).BeginInit();
            this.ugbEnterpriseNamePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosEnterpriseNamePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCustTelNoPrtDivCd)).BeginInit();
            this.ugbCustTelNoPrtDivCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosCustTelNoPrtDivCd)).BeginInit();
            this.utpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbTotalPricePrtCd)).BeginInit();
            this.ugbTotalPricePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosTotalPricePrtCd)).BeginInit();
            this.utpDetail2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeColMove)).BeginInit();
            this.ugbEachSlipTypeColMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugEachSlipTypeColMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSourceColMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeCol)).BeginInit();
            this.ugbEachSlipTypeCol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utEachSlipTypeCol)).BeginInit();
            this.utpMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbMargin)).BeginInit();
            this.ugbMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneTopMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            this.utpFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).BeginInit();
            this.ultraGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufneSlipFontName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbOutlinePrtCd)).BeginInit();
            this.ugbOutlinePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosOutlinePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbBankNamePrtCd)).BeginInit();
            this.ugbBankNamePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosBankNamePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utcDetail)).BeginInit();
            this.utcDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utmMain)).BeginInit();
            this.Form1_Fill_Panel.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintCopy)).BeginInit();
            this.ugbPrintCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintRange)).BeginInit();
            this.ugbPrintRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uosPrintRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrinter)).BeginInit();
            this.ugbPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbFormat)).BeginInit();
            this.ugbFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrintType)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // utpHeader
            // 
            this.utpHeader.Controls.Add(this.ugbSlipDatePrintDiv);
            this.utpHeader.Controls.Add(this.ugbCopyCount);
            this.utpHeader.Controls.Add(this.ugbTitle);
            this.utpHeader.Controls.Add(this.ugbEnterpriseNamePrtCd);
            this.utpHeader.Controls.Add(this.ugbCustTelNoPrtDivCd);
            this.utpHeader.Location = new System.Drawing.Point(1, 22);
            this.utpHeader.Name = "utpHeader";
            this.utpHeader.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbSlipDatePrintDiv
            // 
            this.ugbSlipDatePrintDiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbSlipDatePrintDiv.BackColorInternal = System.Drawing.Color.White;
            this.ugbSlipDatePrintDiv.Controls.Add(this.uosSlipDatePrintDiv);
            this.ugbSlipDatePrintDiv.Location = new System.Drawing.Point(8, 184);
            this.ugbSlipDatePrintDiv.Name = "ugbSlipDatePrintDiv";
            this.ugbSlipDatePrintDiv.Size = new System.Drawing.Size(458, 44);
            this.ugbSlipDatePrintDiv.TabIndex = 130;
            this.ugbSlipDatePrintDiv.Text = "���s���t�̈�";
            // 
            // uosSlipDatePrintDiv
            // 
            this.uosSlipDatePrintDiv.BackColor = System.Drawing.Color.White;
            this.uosSlipDatePrintDiv.BackColorInternal = System.Drawing.Color.White;
            this.uosSlipDatePrintDiv.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosSlipDatePrintDiv.CheckedIndex = 0;
            this.uosSlipDatePrintDiv.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "�󎚂���";
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "�󎚂��Ȃ�";
            this.uosSlipDatePrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.uosSlipDatePrintDiv.ItemSpacingHorizontal = 6;
            this.uosSlipDatePrintDiv.ItemSpacingVertical = 2;
            this.uosSlipDatePrintDiv.Location = new System.Drawing.Point(32, 20);
            this.uosSlipDatePrintDiv.Name = "uosSlipDatePrintDiv";
            this.uosSlipDatePrintDiv.Size = new System.Drawing.Size(156, 20);
            this.uosSlipDatePrintDiv.TabIndex = 131;
            this.uosSlipDatePrintDiv.Text = "�󎚂���";
            this.uosSlipDatePrintDiv.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ugbCopyCount
            // 
            this.ugbCopyCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbCopyCount.BackColorInternal = System.Drawing.Color.White;
            this.ugbCopyCount.Controls.Add(this.tnCopyCount);
            this.ugbCopyCount.Controls.Add(this.ulCopyCount);
            this.ugbCopyCount.Location = new System.Drawing.Point(8, 8);
            this.ugbCopyCount.Name = "ugbCopyCount";
            this.ugbCopyCount.Size = new System.Drawing.Size(458, 44);
            this.ugbCopyCount.TabIndex = 110;
            this.ugbCopyCount.Text = "���ʖ���";
            // 
            // tnCopyCount
            // 
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tnCopyCount.Appearance = appearance2;
            this.tnCopyCount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnCopyCount.Location = new System.Drawing.Point(88, 16);
            this.tnCopyCount.MaxValue = 9;
            this.tnCopyCount.MinValue = 1;
            this.tnCopyCount.Name = "tnCopyCount";
            this.tnCopyCount.PromptChar = ' ';
            this.tnCopyCount.Size = new System.Drawing.Size(72, 21);
            this.tnCopyCount.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.tnCopyCount.TabIndex = 112;
            this.tnCopyCount.Value = 4;
            this.tnCopyCount.ValueChanged += new System.EventHandler(this.tnCopyCount_TextChanged);
            this.tnCopyCount.Leave += new System.EventHandler(this.UltraFontNameEditorLeave);
            this.tnCopyCount.Enter += new System.EventHandler(this.UltraFontNameEditorEnter);
            // 
            // ulCopyCount
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ulCopyCount.Appearance = appearance3;
            this.ulCopyCount.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulCopyCount.Location = new System.Drawing.Point(12, 20);
            this.ulCopyCount.Name = "ulCopyCount";
            this.ulCopyCount.Size = new System.Drawing.Size(60, 16);
            this.ulCopyCount.TabIndex = 2;
            this.ulCopyCount.Text = "���ʖ���";
            // 
            // ugbTitle
            // 
            this.ugbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbTitle.BackColorInternal = System.Drawing.Color.White;
            this.ugbTitle.Controls.Add(this.tceTitle4);
            this.ugbTitle.Controls.Add(this.tceTitle3);
            this.ugbTitle.Controls.Add(this.tceTitle2);
            this.ugbTitle.Controls.Add(this.tceTitle1);
            this.ugbTitle.Controls.Add(this.ubSlipColorT4);
            this.ugbTitle.Controls.Add(this.ubSlipColorT3);
            this.ugbTitle.Controls.Add(this.ubSlipColorT2);
            this.ugbTitle.Controls.Add(this.ubSlipColorT1);
            this.ugbTitle.Controls.Add(this.ulSlipColorT4);
            this.ugbTitle.Controls.Add(this.ulSlipColorT3);
            this.ugbTitle.Controls.Add(this.ulSlipColorT2);
            this.ugbTitle.Controls.Add(this.ulSlipColorT1);
            this.ugbTitle.Controls.Add(this.ulTitle1);
            this.ugbTitle.Controls.Add(this.ulTitle2);
            this.ugbTitle.Controls.Add(this.ulTitle3);
            this.ugbTitle.Controls.Add(this.ulTitle4);
            this.ugbTitle.Location = new System.Drawing.Point(8, 56);
            this.ugbTitle.Name = "ugbTitle";
            this.ugbTitle.Size = new System.Drawing.Size(458, 124);
            this.ugbTitle.TabIndex = 120;
            this.ugbTitle.Text = "�^�C�g��";
            // 
            // tceTitle4
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle4.ActiveAppearance = appearance4;
            this.tceTitle4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle4.ItemAppearance = appearance5;
            this.tceTitle4.Location = new System.Drawing.Point(54, 97);
            this.tceTitle4.MaxLength = 20;
            this.tceTitle4.Name = "tceTitle4";
            this.tceTitle4.Size = new System.Drawing.Size(268, 21);
            this.tceTitle4.TabIndex = 127;
            this.tceTitle4.Tag = "4";
            this.tceTitle4.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // tceTitle3
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle3.ActiveAppearance = appearance6;
            this.tceTitle3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle3.ItemAppearance = appearance7;
            this.tceTitle3.Location = new System.Drawing.Point(54, 72);
            this.tceTitle3.MaxLength = 20;
            this.tceTitle3.Name = "tceTitle3";
            this.tceTitle3.Size = new System.Drawing.Size(268, 21);
            this.tceTitle3.TabIndex = 125;
            this.tceTitle3.Tag = "3";
            this.tceTitle3.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // tceTitle2
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle2.ActiveAppearance = appearance8;
            this.tceTitle2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle2.ItemAppearance = appearance9;
            this.tceTitle2.Location = new System.Drawing.Point(54, 47);
            this.tceTitle2.MaxLength = 20;
            this.tceTitle2.Name = "tceTitle2";
            this.tceTitle2.Size = new System.Drawing.Size(268, 21);
            this.tceTitle2.TabIndex = 123;
            this.tceTitle2.Tag = "2";
            this.tceTitle2.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // tceTitle1
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle1.ActiveAppearance = appearance10;
            this.tceTitle1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle1.ItemAppearance = appearance11;
            this.tceTitle1.Location = new System.Drawing.Point(54, 22);
            this.tceTitle1.MaxLength = 20;
            this.tceTitle1.Name = "tceTitle1";
            this.tceTitle1.Size = new System.Drawing.Size(268, 21);
            this.tceTitle1.TabIndex = 121;
            this.tceTitle1.Tag = "1";
            this.tceTitle1.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // ubSlipColorT4
            // 
            this.ubSlipColorT4.Location = new System.Drawing.Point(396, 95);
            this.ubSlipColorT4.Name = "ubSlipColorT4";
            this.ubSlipColorT4.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT4.TabIndex = 128;
            this.ubSlipColorT4.Tag = "4";
            ultraToolTipInfo1.ToolTipText = "�F�I���K�C�h";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT4, ultraToolTipInfo1);
            this.ubSlipColorT4.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT4.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ubSlipColorT3
            // 
            this.ubSlipColorT3.Location = new System.Drawing.Point(396, 70);
            this.ubSlipColorT3.Name = "ubSlipColorT3";
            this.ubSlipColorT3.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT3.TabIndex = 126;
            this.ubSlipColorT3.Tag = "3";
            ultraToolTipInfo2.ToolTipText = "�F�I���K�C�h";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT3, ultraToolTipInfo2);
            this.ubSlipColorT3.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT3.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ubSlipColorT2
            // 
            this.ubSlipColorT2.Location = new System.Drawing.Point(396, 45);
            this.ubSlipColorT2.Name = "ubSlipColorT2";
            this.ubSlipColorT2.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT2.TabIndex = 124;
            this.ubSlipColorT2.Tag = "2";
            ultraToolTipInfo3.ToolTipText = "�F�I���K�C�h";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT2, ultraToolTipInfo3);
            this.ubSlipColorT2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT2.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ubSlipColorT1
            // 
            this.ubSlipColorT1.Location = new System.Drawing.Point(396, 20);
            this.ubSlipColorT1.Name = "ubSlipColorT1";
            this.ubSlipColorT1.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT1.TabIndex = 122;
            this.ubSlipColorT1.Tag = "1";
            ultraToolTipInfo4.ToolTipText = "�F�I���K�C�h";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT1, ultraToolTipInfo4);
            this.ubSlipColorT1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT1.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ulSlipColorT4
            // 
            appearance12.BorderColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Right";
            appearance12.TextVAlignAsString = "Middle";
            this.ulSlipColorT4.Appearance = appearance12;
            this.ulSlipColorT4.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT4.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT4.Enabled = false;
            this.ulSlipColorT4.Location = new System.Drawing.Point(332, 97);
            this.ulSlipColorT4.Name = "ulSlipColorT4";
            this.ulSlipColorT4.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT4.TabIndex = 139;
            // 
            // ulSlipColorT3
            // 
            appearance13.BorderColor = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.ulSlipColorT3.Appearance = appearance13;
            this.ulSlipColorT3.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT3.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT3.Enabled = false;
            this.ulSlipColorT3.Location = new System.Drawing.Point(332, 72);
            this.ulSlipColorT3.Name = "ulSlipColorT3";
            this.ulSlipColorT3.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT3.TabIndex = 138;
            // 
            // ulSlipColorT2
            // 
            appearance14.BorderColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.ulSlipColorT2.Appearance = appearance14;
            this.ulSlipColorT2.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT2.Enabled = false;
            this.ulSlipColorT2.Location = new System.Drawing.Point(332, 47);
            this.ulSlipColorT2.Name = "ulSlipColorT2";
            this.ulSlipColorT2.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT2.TabIndex = 137;
            // 
            // ulSlipColorT1
            // 
            appearance15.BorderColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.ulSlipColorT1.Appearance = appearance15;
            this.ulSlipColorT1.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT1.Enabled = false;
            this.ulSlipColorT1.Location = new System.Drawing.Point(332, 22);
            this.ulSlipColorT1.Name = "ulSlipColorT1";
            this.ulSlipColorT1.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT1.TabIndex = 135;
            // 
            // ulTitle1
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ulTitle1.Appearance = appearance16;
            this.ulTitle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle1.Location = new System.Drawing.Point(12, 24);
            this.ulTitle1.Name = "ulTitle1";
            this.ulTitle1.Size = new System.Drawing.Size(48, 16);
            this.ulTitle1.TabIndex = 5;
            this.ulTitle1.Text = "�P����";
            // 
            // ulTitle2
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ulTitle2.Appearance = appearance17;
            this.ulTitle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle2.Location = new System.Drawing.Point(12, 49);
            this.ulTitle2.Name = "ulTitle2";
            this.ulTitle2.Size = new System.Drawing.Size(48, 16);
            this.ulTitle2.TabIndex = 6;
            this.ulTitle2.Text = "�Q����";
            // 
            // ulTitle3
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ulTitle3.Appearance = appearance18;
            this.ulTitle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle3.Location = new System.Drawing.Point(12, 74);
            this.ulTitle3.Name = "ulTitle3";
            this.ulTitle3.Size = new System.Drawing.Size(48, 16);
            this.ulTitle3.TabIndex = 7;
            this.ulTitle3.Text = "�R����";
            // 
            // ulTitle4
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ulTitle4.Appearance = appearance19;
            this.ulTitle4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle4.Location = new System.Drawing.Point(12, 99);
            this.ulTitle4.Name = "ulTitle4";
            this.ulTitle4.Size = new System.Drawing.Size(48, 16);
            this.ulTitle4.TabIndex = 8;
            this.ulTitle4.Text = "�S����";
            // 
            // ugbEnterpriseNamePrtCd
            // 
            this.ugbEnterpriseNamePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbEnterpriseNamePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.ugbEnterpriseNamePrtCd.Controls.Add(this.uosEnterpriseNamePrtCd);
            this.ugbEnterpriseNamePrtCd.Location = new System.Drawing.Point(8, 280);
            this.ugbEnterpriseNamePrtCd.Name = "ugbEnterpriseNamePrtCd";
            this.ugbEnterpriseNamePrtCd.Size = new System.Drawing.Size(458, 44);
            this.ugbEnterpriseNamePrtCd.TabIndex = 150;
            this.ugbEnterpriseNamePrtCd.Text = "���Ж���";
            // 
            // uosEnterpriseNamePrtCd
            // 
            this.uosEnterpriseNamePrtCd.BackColor = System.Drawing.Color.White;
            this.uosEnterpriseNamePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosEnterpriseNamePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosEnterpriseNamePrtCd.CheckedIndex = 0;
            this.uosEnterpriseNamePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem12.DataValue = 0;
            valueListItem12.DisplayText = "���Ж���";
            valueListItem13.DataValue = 1;
            valueListItem13.DisplayText = "���_����";
            valueListItem14.DataValue = 2;
            valueListItem14.DisplayText = "�r�b�g�}�b�v��";
            valueListItem15.DataValue = 3;
            valueListItem15.DisplayText = "�󎚂��Ȃ�";
            this.uosEnterpriseNamePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15});
            this.uosEnterpriseNamePrtCd.ItemSpacingHorizontal = 6;
            this.uosEnterpriseNamePrtCd.ItemSpacingVertical = 2;
            this.uosEnterpriseNamePrtCd.Location = new System.Drawing.Point(32, 20);
            this.uosEnterpriseNamePrtCd.Name = "uosEnterpriseNamePrtCd";
            this.uosEnterpriseNamePrtCd.Size = new System.Drawing.Size(372, 20);
            this.uosEnterpriseNamePrtCd.TabIndex = 151;
            this.uosEnterpriseNamePrtCd.Text = "���Ж���";
            this.uosEnterpriseNamePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ugbCustTelNoPrtDivCd
            // 
            this.ugbCustTelNoPrtDivCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbCustTelNoPrtDivCd.BackColorInternal = System.Drawing.Color.White;
            this.ugbCustTelNoPrtDivCd.Controls.Add(this.uosCustTelNoPrtDivCd);
            this.ugbCustTelNoPrtDivCd.Location = new System.Drawing.Point(8, 232);
            this.ugbCustTelNoPrtDivCd.Name = "ugbCustTelNoPrtDivCd";
            this.ugbCustTelNoPrtDivCd.Size = new System.Drawing.Size(458, 44);
            this.ugbCustTelNoPrtDivCd.TabIndex = 140;
            this.ugbCustTelNoPrtDivCd.Text = "���Ӑ�d�b�ԍ��̈�";
            // 
            // uosCustTelNoPrtDivCd
            // 
            this.uosCustTelNoPrtDivCd.BackColor = System.Drawing.Color.White;
            this.uosCustTelNoPrtDivCd.BackColorInternal = System.Drawing.Color.White;
            this.uosCustTelNoPrtDivCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosCustTelNoPrtDivCd.CheckedIndex = 0;
            this.uosCustTelNoPrtDivCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem16.DataValue = 1;
            valueListItem16.DisplayText = "�󎚂���";
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "�󎚂��Ȃ�";
            this.uosCustTelNoPrtDivCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem16,
            valueListItem17});
            this.uosCustTelNoPrtDivCd.ItemSpacingHorizontal = 6;
            this.uosCustTelNoPrtDivCd.ItemSpacingVertical = 2;
            this.uosCustTelNoPrtDivCd.Location = new System.Drawing.Point(32, 20);
            this.uosCustTelNoPrtDivCd.Name = "uosCustTelNoPrtDivCd";
            this.uosCustTelNoPrtDivCd.Size = new System.Drawing.Size(156, 20);
            this.uosCustTelNoPrtDivCd.TabIndex = 141;
            this.uosCustTelNoPrtDivCd.Text = "�󎚂���";
            this.uosCustTelNoPrtDivCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // utpDetail
            // 
            this.utpDetail.Controls.Add(this.ugbTotalPricePrtCd);
            this.utpDetail.Location = new System.Drawing.Point(-10000, -10000);
            this.utpDetail.Name = "utpDetail";
            this.utpDetail.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbTotalPricePrtCd
            // 
            this.ugbTotalPricePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbTotalPricePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.ugbTotalPricePrtCd.Controls.Add(this.uosTotalPricePrtCd);
            this.ugbTotalPricePrtCd.Location = new System.Drawing.Point(8, 8);
            this.ugbTotalPricePrtCd.Name = "ugbTotalPricePrtCd";
            this.ugbTotalPricePrtCd.Size = new System.Drawing.Size(458, 44);
            this.ugbTotalPricePrtCd.TabIndex = 285;
            this.ugbTotalPricePrtCd.Text = "���v���z�󎚋敪";
            // 
            // uosTotalPricePrtCd
            // 
            this.uosTotalPricePrtCd.BackColor = System.Drawing.Color.White;
            this.uosTotalPricePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosTotalPricePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosTotalPricePrtCd.CheckedIndex = 0;
            this.uosTotalPricePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "�S�Ẵy�[�W";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "�擪�y�[�W�̂�";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "�ŏI�y�[�W�̂�";
            this.uosTotalPricePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.uosTotalPricePrtCd.ItemSpacingHorizontal = 6;
            this.uosTotalPricePrtCd.ItemSpacingVertical = 2;
            this.uosTotalPricePrtCd.Location = new System.Drawing.Point(32, 19);
            this.uosTotalPricePrtCd.Name = "uosTotalPricePrtCd";
            this.uosTotalPricePrtCd.Size = new System.Drawing.Size(292, 20);
            this.uosTotalPricePrtCd.TabIndex = 286;
            this.uosTotalPricePrtCd.Text = "�S�Ẵy�[�W";
            this.uosTotalPricePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // utpDetail2
            // 
            this.utpDetail2.Controls.Add(this.ugbEachSlipTypeColMove);
            this.utpDetail2.Controls.Add(this.ugbEachSlipTypeCol);
            this.utpDetail2.Location = new System.Drawing.Point(-10000, -10000);
            this.utpDetail2.Name = "utpDetail2";
            this.utpDetail2.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbEachSlipTypeColMove
            // 
            this.ugbEachSlipTypeColMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbEachSlipTypeColMove.BackColorInternal = System.Drawing.Color.White;
            this.ugbEachSlipTypeColMove.Controls.Add(this.ultraLabel1);
            this.ugbEachSlipTypeColMove.Controls.Add(this.ugEachSlipTypeColMove);
            this.ugbEachSlipTypeColMove.Location = new System.Drawing.Point(8, 196);
            this.ugbEachSlipTypeColMove.Name = "ugbEachSlipTypeColMove";
            this.ugbEachSlipTypeColMove.Size = new System.Drawing.Size(466, 192);
            this.ugbEachSlipTypeColMove.TabIndex = 320;
            this.ugbEachSlipTypeColMove.Text = "��ʒu";
            // 
            // ultraLabel1
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance23;
            this.ultraLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(16, 20);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(328, 23);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "����h���b�O���h���b�v�ňړ��ł��܂�";
            // 
            // ugEachSlipTypeColMove
            // 
            this.ugEachSlipTypeColMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugEachSlipTypeColMove.DataSource = this.ultraDataSourceColMove;
            appearance24.BackColor = System.Drawing.Color.White;
            this.ugEachSlipTypeColMove.DisplayLayout.Appearance = appearance24;
            this.ugEachSlipTypeColMove.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 196;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 8;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 8;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 8;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 8;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 9;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 35;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 40;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Width = 48;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Width = 48;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.ugEachSlipTypeColMove.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance25.BackColor = System.Drawing.Color.Transparent;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.CardAreaAppearance = appearance25;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance26.BackColor = System.Drawing.Color.LightGray;
            appearance26.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.FontData.Name = "MS UI Gothic";
            appearance26.FontData.SizeInPoints = 10F;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.HeaderAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance27.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.RowSelectorAppearance = appearance27;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance28.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectedRowAppearance = appearance28;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugEachSlipTypeColMove.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugEachSlipTypeColMove.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugEachSlipTypeColMove.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.ugEachSlipTypeColMove.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugEachSlipTypeColMove.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ugEachSlipTypeColMove.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ugEachSlipTypeColMove.Location = new System.Drawing.Point(12, 56);
            this.ugEachSlipTypeColMove.Name = "ugEachSlipTypeColMove";
            this.ugEachSlipTypeColMove.Size = new System.Drawing.Size(446, 32);
            this.ugEachSlipTypeColMove.TabIndex = 321;
            this.ugEachSlipTypeColMove.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugEachSlipTypeColMove_InitializeLayout);
            this.ugEachSlipTypeColMove.AfterColPosChanged += new Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler(this.ugEachSlipTypeColMove_AfterColPosChanged);
            // 
            // ultraDataSourceColMove
            // 
            this.ultraDataSourceColMove.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3,
            ultraDataColumn4,
            ultraDataColumn5,
            ultraDataColumn6,
            ultraDataColumn7,
            ultraDataColumn8,
            ultraDataColumn9,
            ultraDataColumn10});
            this.ultraDataSourceColMove.Band.Key = "ColMove";
            // 
            // ugbEachSlipTypeCol
            // 
            this.ugbEachSlipTypeCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbEachSlipTypeCol.BackColorInternal = System.Drawing.Color.White;
            this.ugbEachSlipTypeCol.Controls.Add(this.ultraLabel2);
            this.ugbEachSlipTypeCol.Controls.Add(this.utEachSlipTypeCol);
            this.ugbEachSlipTypeCol.Location = new System.Drawing.Point(8, 8);
            this.ugbEachSlipTypeCol.Name = "ugbEachSlipTypeCol";
            this.ugbEachSlipTypeCol.Size = new System.Drawing.Size(466, 184);
            this.ugbEachSlipTypeCol.TabIndex = 310;
            this.ugbEachSlipTypeCol.Text = "�������";
            // 
            // ultraLabel2
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance29;
            this.ultraLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(16, 28);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(220, 16);
            this.ultraLabel2.TabIndex = 5;
            this.ultraLabel2.Text = "�󎚂������w��ł��܂�";
            // 
            // utEachSlipTypeCol
            // 
            this.utEachSlipTypeCol.HideSelection = false;
            this.utEachSlipTypeCol.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.utEachSlipTypeCol.Location = new System.Drawing.Point(16, 48);
            this.utEachSlipTypeCol.Name = "utEachSlipTypeCol";
            this.utEachSlipTypeCol.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.utEachSlipTypeCol.Override = _override1;
            this.utEachSlipTypeCol.Size = new System.Drawing.Size(206, 116);
            this.utEachSlipTypeCol.TabIndex = 311;
            this.utEachSlipTypeCol.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.utEachSlipTypeCol_AfterCheck);
            // 
            // utpMargin
            // 
            this.utpMargin.Controls.Add(this.ugbMargin);
            this.utpMargin.Location = new System.Drawing.Point(-10000, -10000);
            this.utpMargin.Name = "utpMargin";
            this.utpMargin.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbMargin
            // 
            this.ugbMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance37.BackColor = System.Drawing.Color.White;
            this.ugbMargin.Appearance = appearance37;
            this.ugbMargin.Controls.Add(this.ulRightMark2);
            this.ugbMargin.Controls.Add(this.ulRightMark1);
            this.ugbMargin.Controls.Add(this.ulBottomMark1);
            this.ugbMargin.Controls.Add(this.ulBottomMark2);
            this.ugbMargin.Controls.Add(this.tLine4);
            this.ugbMargin.Controls.Add(this.tLine3);
            this.ugbMargin.Controls.Add(this.tneBottomMargin);
            this.ugbMargin.Controls.Add(this.ultraLabel4);
            this.ugbMargin.Controls.Add(this.ultraLabel3);
            this.ugbMargin.Controls.Add(this.tneRightMargin);
            this.ugbMargin.Controls.Add(this.ulTopMark1);
            this.ugbMargin.Controls.Add(this.ulLeftMark2);
            this.ugbMargin.Controls.Add(this.ulLeftMark1);
            this.ugbMargin.Controls.Add(this.ulTopMark2);
            this.ugbMargin.Controls.Add(this.tLine1);
            this.ugbMargin.Controls.Add(this.tneTopMargin);
            this.ugbMargin.Controls.Add(this.tneLeftMargin);
            this.ugbMargin.Controls.Add(this.ultraLabel11);
            this.ugbMargin.Controls.Add(this.ultraLabel10);
            this.ugbMargin.Controls.Add(this.tLine2);
            this.ugbMargin.Controls.Add(this.upbSlipImage);
            this.ugbMargin.Location = new System.Drawing.Point(8, 8);
            this.ugbMargin.Name = "ugbMargin";
            this.ugbMargin.Size = new System.Drawing.Size(458, 368);
            this.ugbMargin.TabIndex = 510;
            this.ugbMargin.Text = "�]��";
            // 
            // ulRightMark2
            // 
            appearance38.ForeColor = System.Drawing.Color.Red;
            appearance38.TextVAlignAsString = "Middle";
            this.ulRightMark2.Appearance = appearance38;
            this.ulRightMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulRightMark2.Font = new System.Drawing.Font("HG�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulRightMark2.Location = new System.Drawing.Point(264, 284);
            this.ulRightMark2.Name = "ulRightMark2";
            this.ulRightMark2.Size = new System.Drawing.Size(19, 16);
            this.ulRightMark2.TabIndex = 522;
            this.ulRightMark2.Text = "��";
            this.ulRightMark2.Visible = false;
            // 
            // ulRightMark1
            // 
            appearance39.ForeColor = System.Drawing.Color.Red;
            appearance39.TextVAlignAsString = "Middle";
            this.ulRightMark1.Appearance = appearance39;
            this.ulRightMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulRightMark1.Font = new System.Drawing.Font("HG�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulRightMark1.Location = new System.Drawing.Point(264, 72);
            this.ulRightMark1.Name = "ulRightMark1";
            this.ulRightMark1.Size = new System.Drawing.Size(19, 13);
            this.ulRightMark1.TabIndex = 521;
            this.ulRightMark1.Text = "��";
            this.ulRightMark1.Visible = false;
            // 
            // ulBottomMark1
            // 
            appearance40.ForeColor = System.Drawing.Color.Red;
            appearance40.TextVAlignAsString = "Middle";
            this.ulBottomMark1.Appearance = appearance40;
            this.ulBottomMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulBottomMark1.Font = new System.Drawing.Font("HGS�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulBottomMark1.Location = new System.Drawing.Point(128, 256);
            this.ulBottomMark1.Name = "ulBottomMark1";
            this.ulBottomMark1.Size = new System.Drawing.Size(19, 13);
            this.ulBottomMark1.TabIndex = 520;
            this.ulBottomMark1.Text = "��";
            this.ulBottomMark1.Visible = false;
            // 
            // ulBottomMark2
            // 
            appearance41.ForeColor = System.Drawing.Color.Red;
            appearance41.TextVAlignAsString = "Middle";
            this.ulBottomMark2.Appearance = appearance41;
            this.ulBottomMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulBottomMark2.Font = new System.Drawing.Font("HGS�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulBottomMark2.Location = new System.Drawing.Point(292, 256);
            this.ulBottomMark2.Name = "ulBottomMark2";
            this.ulBottomMark2.Size = new System.Drawing.Size(19, 13);
            this.ulBottomMark2.TabIndex = 519;
            this.ulBottomMark2.Text = "��";
            this.ulBottomMark2.Visible = false;
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.Location = new System.Drawing.Point(140, 260);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(160, 12);
            this.tLine4.TabIndex = 518;
            this.tLine4.Text = "tLine4";
            // 
            // tLine3
            // 
            this.tLine3.BackColor = System.Drawing.Color.Transparent;
            this.tLine3.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine3.Location = new System.Drawing.Point(276, 84);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(8, 204);
            this.tLine3.TabIndex = 517;
            this.tLine3.Text = "tLine3";
            // 
            // tneBottomMargin
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneBottomMargin.ActiveAppearance = appearance42;
            this.tneBottomMargin.AutoSelect = true;
            dropDownEditorButton1.Tag = "NEditCalculator";
            this.tneBottomMargin.ButtonsRight.Add(dropDownEditorButton1);
            this.tneBottomMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneBottomMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneBottomMargin.DataText = "";
            this.tneBottomMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneBottomMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneBottomMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneBottomMargin.Location = new System.Drawing.Point(209, 300);
            this.tneBottomMargin.MaxLength = 5;
            this.tneBottomMargin.Name = "tneBottomMargin";
            this.tneBottomMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneBottomMargin.Size = new System.Drawing.Size(69, 21);
            this.tneBottomMargin.TabIndex = 514;
            this.tneBottomMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneBottomMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // ultraLabel4
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance43;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(169, 300);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(40, 20);
            this.ultraLabel4.TabIndex = 9;
            this.ultraLabel4.Text = "��(&B)";
            // 
            // ultraLabel3
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance44;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(300, 144);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(56, 20);
            this.ultraLabel3.TabIndex = 8;
            this.ultraLabel3.Text = "�E(&R)";
            // 
            // tneRightMargin
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneRightMargin.ActiveAppearance = appearance45;
            this.tneRightMargin.AutoSelect = true;
            dropDownEditorButton2.Tag = "NEditCalculator";
            this.tneRightMargin.ButtonsRight.Add(dropDownEditorButton2);
            this.tneRightMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneRightMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneRightMargin.DataText = "";
            this.tneRightMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneRightMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneRightMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneRightMargin.Location = new System.Drawing.Point(300, 164);
            this.tneRightMargin.MaxLength = 5;
            this.tneRightMargin.Name = "tneRightMargin";
            this.tneRightMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneRightMargin.Size = new System.Drawing.Size(69, 21);
            this.tneRightMargin.TabIndex = 513;
            this.tneRightMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneRightMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // ulTopMark1
            // 
            appearance46.ForeColor = System.Drawing.Color.Red;
            appearance46.TextVAlignAsString = "Middle";
            this.ulTopMark1.Appearance = appearance46;
            this.ulTopMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulTopMark1.Font = new System.Drawing.Font("HGS�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTopMark1.Location = new System.Drawing.Point(128, 104);
            this.ulTopMark1.Name = "ulTopMark1";
            this.ulTopMark1.Size = new System.Drawing.Size(19, 13);
            this.ulTopMark1.TabIndex = 12;
            this.ulTopMark1.Text = "��";
            this.ulTopMark1.Visible = false;
            // 
            // ulLeftMark2
            // 
            appearance47.ForeColor = System.Drawing.Color.Red;
            appearance47.TextVAlignAsString = "Middle";
            this.ulLeftMark2.Appearance = appearance47;
            this.ulLeftMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulLeftMark2.Font = new System.Drawing.Font("HG�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulLeftMark2.Location = new System.Drawing.Point(156, 284);
            this.ulLeftMark2.Name = "ulLeftMark2";
            this.ulLeftMark2.Size = new System.Drawing.Size(19, 16);
            this.ulLeftMark2.TabIndex = 10;
            this.ulLeftMark2.Text = "��";
            this.ulLeftMark2.Visible = false;
            // 
            // ulLeftMark1
            // 
            appearance48.ForeColor = System.Drawing.Color.Red;
            appearance48.TextVAlignAsString = "Middle";
            this.ulLeftMark1.Appearance = appearance48;
            this.ulLeftMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulLeftMark1.Font = new System.Drawing.Font("HG�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulLeftMark1.Location = new System.Drawing.Point(156, 72);
            this.ulLeftMark1.Name = "ulLeftMark1";
            this.ulLeftMark1.Size = new System.Drawing.Size(19, 13);
            this.ulLeftMark1.TabIndex = 9;
            this.ulLeftMark1.Text = "��";
            this.ulLeftMark1.Visible = false;
            // 
            // ulTopMark2
            // 
            appearance49.ForeColor = System.Drawing.Color.Red;
            appearance49.TextVAlignAsString = "Middle";
            this.ulTopMark2.Appearance = appearance49;
            this.ulTopMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulTopMark2.Font = new System.Drawing.Font("HGS�n�p�p�߯�ߑ�", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTopMark2.Location = new System.Drawing.Point(292, 104);
            this.ulTopMark2.Name = "ulTopMark2";
            this.ulTopMark2.Size = new System.Drawing.Size(19, 13);
            this.ulTopMark2.TabIndex = 11;
            this.ulTopMark2.Text = "��";
            this.ulTopMark2.Visible = false;
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.Location = new System.Drawing.Point(140, 108);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(160, 12);
            this.tLine1.TabIndex = 4;
            this.tLine1.Text = "tLine1";
            // 
            // tneTopMargin
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneTopMargin.ActiveAppearance = appearance50;
            this.tneTopMargin.AutoSelect = true;
            dropDownEditorButton3.Tag = "NEditCalculator";
            this.tneTopMargin.ButtonsRight.Add(dropDownEditorButton3);
            this.tneTopMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneTopMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneTopMargin.DataText = "";
            this.tneTopMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneTopMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneTopMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneTopMargin.Location = new System.Drawing.Point(209, 48);
            this.tneTopMargin.MaxLength = 5;
            this.tneTopMargin.Name = "tneTopMargin";
            this.tneTopMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneTopMargin.Size = new System.Drawing.Size(69, 21);
            this.tneTopMargin.TabIndex = 511;
            this.tneTopMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneTopMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // tneLeftMargin
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneLeftMargin.ActiveAppearance = appearance51;
            this.tneLeftMargin.AutoSelect = true;
            dropDownEditorButton4.Tag = "NEditCalculator";
            this.tneLeftMargin.ButtonsRight.Add(dropDownEditorButton4);
            this.tneLeftMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneLeftMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneLeftMargin.DataText = "";
            this.tneLeftMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneLeftMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneLeftMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneLeftMargin.Location = new System.Drawing.Point(80, 164);
            this.tneLeftMargin.MaxLength = 5;
            this.tneLeftMargin.Name = "tneLeftMargin";
            this.tneLeftMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneLeftMargin.Size = new System.Drawing.Size(69, 21);
            this.tneLeftMargin.TabIndex = 512;
            this.tneLeftMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneLeftMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // ultraLabel11
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance52;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel11.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(169, 48);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(40, 20);
            this.ultraLabel11.TabIndex = 7;
            this.ultraLabel11.Text = "��(&T)";
            // 
            // ultraLabel10
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance53;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel10.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(80, 144);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(56, 20);
            this.ultraLabel10.TabIndex = 6;
            this.ultraLabel10.Text = "��(&L)";
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine2.Location = new System.Drawing.Point(164, 84);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(8, 204);
            this.tLine2.TabIndex = 5;
            this.tLine2.Text = "tLine2";
            // 
            // upbSlipImage
            // 
            this.upbSlipImage.BorderShadowColor = System.Drawing.Color.Empty;
            this.upbSlipImage.Location = new System.Drawing.Point(156, 92);
            this.upbSlipImage.Name = "upbSlipImage";
            this.upbSlipImage.Size = new System.Drawing.Size(132, 184);
            this.upbSlipImage.TabIndex = 13;
            // 
            // utpFont
            // 
            this.utpFont.Controls.Add(this.ultraGroupBox8);
            this.utpFont.Location = new System.Drawing.Point(-10000, -10000);
            this.utpFont.Name = "utpFont";
            this.utpFont.Size = new System.Drawing.Size(474, 383);
            // 
            // ultraGroupBox8
            // 
            this.ultraGroupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance54.BackColor = System.Drawing.Color.White;
            this.ultraGroupBox8.Appearance = appearance54;
            this.ultraGroupBox8.Controls.Add(this.pbCompanyImage);
            this.ultraGroupBox8.Controls.Add(this.tceSlipFontSize);
            this.ultraGroupBox8.Controls.Add(this.ufneSlipFontName);
            this.ultraGroupBox8.Controls.Add(this.tceSlipFontStyle);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox8.Location = new System.Drawing.Point(8, 8);
            this.ultraGroupBox8.Name = "ultraGroupBox8";
            this.ultraGroupBox8.Size = new System.Drawing.Size(458, 368);
            this.ultraGroupBox8.TabIndex = 610;
            this.ultraGroupBox8.Text = "�t�H���g";
            // 
            // pbCompanyImage
            // 
            this.pbCompanyImage.Location = new System.Drawing.Point(276, 96);
            this.pbCompanyImage.Name = "pbCompanyImage";
            this.pbCompanyImage.Size = new System.Drawing.Size(100, 50);
            this.pbCompanyImage.TabIndex = 614;
            this.pbCompanyImage.TabStop = false;
            this.pbCompanyImage.Visible = false;
            // 
            // tceSlipFontSize
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontSize.ActiveAppearance = appearance55;
            this.tceSlipFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tceSlipFontSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontSize.ItemAppearance = appearance56;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "�W��";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "��";
            this.tceSlipFontSize.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.tceSlipFontSize.Location = new System.Drawing.Point(104, 62);
            this.tceSlipFontSize.Name = "tceSlipFontSize";
            this.tceSlipFontSize.Size = new System.Drawing.Size(60, 21);
            this.tceSlipFontSize.TabIndex = 612;
            this.tceSlipFontSize.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ufneSlipFontName
            // 
            this.ufneSlipFontName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ufneSlipFontName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ufneSlipFontName.ItemAppearance = appearance57;
            this.ufneSlipFontName.Location = new System.Drawing.Point(104, 24);
            this.ufneSlipFontName.Name = "ufneSlipFontName";
            this.ufneSlipFontName.Size = new System.Drawing.Size(188, 21);
            this.ufneSlipFontName.TabIndex = 611;
            this.ufneSlipFontName.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            this.ufneSlipFontName.Leave += new System.EventHandler(this.UltraFontNameEditorLeave);
            this.ufneSlipFontName.Enter += new System.EventHandler(this.UltraFontNameEditorEnter);
            // 
            // tceSlipFontStyle
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontStyle.ActiveAppearance = appearance58;
            this.tceSlipFontStyle.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tceSlipFontStyle.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontStyle.ItemAppearance = appearance59;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "�W��";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "����";
            this.tceSlipFontStyle.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.tceSlipFontStyle.Location = new System.Drawing.Point(104, 100);
            this.tceSlipFontStyle.Name = "tceSlipFontStyle";
            this.tceSlipFontStyle.Size = new System.Drawing.Size(60, 21);
            this.tceSlipFontStyle.TabIndex = 613;
            this.tceSlipFontStyle.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ultraLabel9
            // 
            appearance60.BackColor = System.Drawing.Color.White;
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance60;
            this.ultraLabel9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(16, 99);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel9.TabIndex = 5;
            this.ultraLabel9.Text = "�����̑���";
            // 
            // ultraLabel8
            // 
            appearance61.BackColor = System.Drawing.Color.White;
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance61;
            this.ultraLabel8.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(16, 61);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel8.TabIndex = 4;
            this.ultraLabel8.Text = "�����̃T�C�Y";
            // 
            // ultraLabel6
            // 
            appearance62.BackColor = System.Drawing.Color.White;
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance62;
            this.ultraLabel6.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(16, 23);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel6.TabIndex = 3;
            this.ultraLabel6.Text = "�t�H���g";
            // 
            // ultraLabel5
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance30;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(8, 154);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(305, 23);
            this.ultraLabel5.TabIndex = 421;
            this.ultraLabel5.Text = "�����̃^�u�͔�\���ɕύX���܂��� 2008.2.22";
            // 
            // ugbOutlinePrtCd
            // 
            this.ugbOutlinePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance31.BackColor = System.Drawing.Color.White;
            this.ugbOutlinePrtCd.Appearance = appearance31;
            this.ugbOutlinePrtCd.Controls.Add(this.uosOutlinePrtCd);
            this.ugbOutlinePrtCd.Location = new System.Drawing.Point(8, 8);
            this.ugbOutlinePrtCd.Name = "ugbOutlinePrtCd";
            this.ugbOutlinePrtCd.Size = new System.Drawing.Size(458, 48);
            this.ugbOutlinePrtCd.TabIndex = 410;
            this.ugbOutlinePrtCd.Text = "�E�v�̈�";
            // 
            // uosOutlinePrtCd
            // 
            appearance32.BackColor = System.Drawing.Color.White;
            this.uosOutlinePrtCd.Appearance = appearance32;
            this.uosOutlinePrtCd.BackColor = System.Drawing.Color.White;
            this.uosOutlinePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosOutlinePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosOutlinePrtCd.CheckedIndex = 0;
            this.uosOutlinePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem18.DataValue = 1;
            valueListItem18.DisplayText = "�󎚂���";
            valueListItem19.DataValue = 0;
            valueListItem19.DisplayText = "�󎚂��Ȃ�";
            this.uosOutlinePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem18,
            valueListItem19});
            this.uosOutlinePrtCd.ItemSpacingHorizontal = 6;
            this.uosOutlinePrtCd.ItemSpacingVertical = 2;
            this.uosOutlinePrtCd.Location = new System.Drawing.Point(32, 20);
            this.uosOutlinePrtCd.Name = "uosOutlinePrtCd";
            this.uosOutlinePrtCd.Size = new System.Drawing.Size(156, 20);
            this.uosOutlinePrtCd.TabIndex = 411;
            this.uosOutlinePrtCd.Text = "�󎚂���";
            this.uosOutlinePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ugbBankNamePrtCd
            // 
            this.ugbBankNamePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance34.BackColor = System.Drawing.Color.White;
            this.ugbBankNamePrtCd.Appearance = appearance34;
            this.ugbBankNamePrtCd.Controls.Add(this.uosBankNamePrtCd);
            this.ugbBankNamePrtCd.Location = new System.Drawing.Point(8, 64);
            this.ugbBankNamePrtCd.Name = "ugbBankNamePrtCd";
            this.ugbBankNamePrtCd.Size = new System.Drawing.Size(458, 48);
            this.ugbBankNamePrtCd.TabIndex = 420;
            this.ugbBankNamePrtCd.Text = "��s���̈�";
            // 
            // uosBankNamePrtCd
            // 
            appearance35.BackColor = System.Drawing.Color.White;
            this.uosBankNamePrtCd.Appearance = appearance35;
            this.uosBankNamePrtCd.BackColor = System.Drawing.Color.White;
            this.uosBankNamePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosBankNamePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosBankNamePrtCd.CheckedIndex = 0;
            this.uosBankNamePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem20.DataValue = 1;
            valueListItem20.DisplayText = "�󎚂���";
            valueListItem21.DataValue = 0;
            valueListItem21.DisplayText = "�󎚂��Ȃ�";
            this.uosBankNamePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem20,
            valueListItem21});
            this.uosBankNamePrtCd.ItemSpacingHorizontal = 6;
            this.uosBankNamePrtCd.ItemSpacingVertical = 2;
            this.uosBankNamePrtCd.Location = new System.Drawing.Point(32, 20);
            this.uosBankNamePrtCd.Name = "uosBankNamePrtCd";
            this.uosBankNamePrtCd.Size = new System.Drawing.Size(156, 20);
            this.uosBankNamePrtCd.TabIndex = 421;
            this.uosBankNamePrtCd.Text = "�󎚂���";
            this.uosBankNamePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // utcDetail
            // 
            appearance63.BackColor = System.Drawing.Color.White;
            appearance63.BackColor2 = System.Drawing.Color.LightPink;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.utcDetail.ActiveTabAppearance = appearance63;
            appearance64.BackColor = System.Drawing.Color.White;
            appearance64.BackColor2 = System.Drawing.Color.Lavender;
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.utcDetail.Appearance = appearance64;
            this.utcDetail.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance65.BackColor = System.Drawing.Color.White;
            this.utcDetail.ClientAreaAppearance = appearance65;
            this.utcDetail.Controls.Add(this.ultraTabSharedControlsPage1);
            this.utcDetail.Controls.Add(this.utpDetail2);
            this.utcDetail.Controls.Add(this.utpFont);
            this.utcDetail.Controls.Add(this.utpMargin);
            this.utcDetail.Controls.Add(this.utpDetail);
            this.utcDetail.Controls.Add(this.utpHeader);
            this.utcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utcDetail.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.utcDetail.Location = new System.Drawing.Point(0, 281);
            this.utcDetail.Name = "utcDetail";
            this.utcDetail.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.utcDetail.Size = new System.Drawing.Size(476, 406);
            this.utcDetail.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.utcDetail.TabIndex = 2000;
            this.utcDetail.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.utcDetail.TabPadding = new System.Drawing.Size(5, 2);
            ultraTab1.TabPage = this.utpHeader;
            ultraTab1.Text = "�w�b�_�[";
            ultraTab2.TabPage = this.utpDetail;
            ultraTab2.Text = "����";
            ultraTab3.TabPage = this.utpDetail2;
            ultraTab3.Text = "����(��j";
            ultraTab5.TabPage = this.utpMargin;
            ultraTab5.Text = "�]��";
            ultraTab6.TabPage = this.utpFont;
            ultraTab6.Text = "�t�H���g";
            this.utcDetail.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab5,
            ultraTab6});
            this.utcDetail.Tag = "";
            this.utcDetail.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.utcDetail.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(474, 383);
            // 
            // utmMain
            // 
            this.utmMain.DesignerFlags = 1;
            this.utmMain.DockWithinContainer = this;
            this.utmMain.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.utmMain.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.utmMain.ShowFullMenusDelay = 500;
            this.utmMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Text = "�`�[���";
            this.utmMain.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool4.SharedProps.Caption = "�߂�(&C)";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.Caption = "���(&P)";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Caption = "PDF�o��(&F)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.utmMain.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6});
            this.utmMain.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.utmMain_ToolClick);
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.pnlPrevew);
            this.Form1_Fill_Panel.Controls.Add(this.splitter1);
            this.Form1_Fill_Panel.Controls.Add(this.pnlLeft);
            this.Form1_Fill_Panel.Controls.Add(this.ultraStatusBar1);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 28);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(982, 710);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // pnlPrevew
            // 
            this.pnlPrevew.BackColor = System.Drawing.Color.Lavender;
            this.pnlPrevew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrevew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrevew.Location = new System.Drawing.Point(481, 0);
            this.pnlPrevew.Name = "pnlPrevew";
            this.pnlPrevew.Size = new System.Drawing.Size(501, 687);
            this.pnlPrevew.TabIndex = 8;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(476, 0);
            this.splitter1.MinSize = 476;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 687);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.Controls.Add(this.utcDetail);
            this.pnlLeft.Controls.Add(this.splitter2);
            this.pnlLeft.Controls.Add(this.pnlMain);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(476, 687);
            this.pnlLeft.TabIndex = 1000;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 276);
            this.splitter2.MinExtra = 20;
            this.splitter2.MinSize = 230;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(476, 5);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.ugbPrintCopy);
            this.pnlMain.Controls.Add(this.ugbPrintRange);
            this.pnlMain.Controls.Add(this.ugbPrinter);
            this.pnlMain.Controls.Add(this.ugbFormat);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(476, 276);
            this.pnlMain.TabIndex = 1001;
            // 
            // ugbPrintCopy
            // 
            this.ugbPrintCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbPrintCopy.Controls.Add(this.tnPrintCopy);
            this.ugbPrintCopy.Controls.Add(this.ulPrintCopy);
            this.ugbPrintCopy.Location = new System.Drawing.Point(339, 164);
            this.ugbPrintCopy.Name = "ugbPrintCopy";
            this.ugbPrintCopy.Size = new System.Drawing.Size(125, 56);
            this.ugbPrintCopy.TabIndex = 4;
            this.ugbPrintCopy.Text = "����";
            // 
            // tnPrintCopy
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tnPrintCopy.ActiveAppearance = appearance66;
            this.tnPrintCopy.AutoSelect = true;
            dropDownEditorButton5.Tag = "NEditCalculator";
            this.tnPrintCopy.ButtonsRight.Add(dropDownEditorButton5);
            this.tnPrintCopy.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tnPrintCopy.CalcSize = new System.Drawing.Size(172, 200);
            this.tnPrintCopy.DataText = "";
            this.tnPrintCopy.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tnPrintCopy.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tnPrintCopy.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnPrintCopy.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnPrintCopy.Location = new System.Drawing.Point(60, 28);
            this.tnPrintCopy.MaxLength = 3;
            this.tnPrintCopy.Name = "tnPrintCopy";
            this.tnPrintCopy.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tnPrintCopy.Size = new System.Drawing.Size(48, 21);
            this.tnPrintCopy.TabIndex = 8;
            // 
            // ulPrintCopy
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ulPrintCopy.Appearance = appearance67;
            this.ulPrintCopy.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintCopy.Location = new System.Drawing.Point(16, 32);
            this.ulPrintCopy.Name = "ulPrintCopy";
            this.ulPrintCopy.Size = new System.Drawing.Size(32, 16);
            this.ulPrintCopy.TabIndex = 2;
            this.ulPrintCopy.Text = "����";
            // 
            // ugbPrintRange
            // 
            this.ugbPrintRange.Controls.Add(this.tnPrintRangeTo);
            this.ugbPrintRange.Controls.Add(this.ulPrintRangeTo);
            this.ugbPrintRange.Controls.Add(this.tnPrintRangeFrom);
            this.ugbPrintRange.Controls.Add(this.uosPrintRange);
            this.ugbPrintRange.Controls.Add(this.ulPrintRangeFrom);
            this.ugbPrintRange.Location = new System.Drawing.Point(8, 164);
            this.ugbPrintRange.Name = "ugbPrintRange";
            this.ugbPrintRange.Size = new System.Drawing.Size(324, 56);
            this.ugbPrintRange.TabIndex = 3;
            this.ugbPrintRange.Text = "����͈�";
            // 
            // tnPrintRangeTo
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tnPrintRangeTo.ActiveAppearance = appearance68;
            this.tnPrintRangeTo.AutoSelect = true;
            dropDownEditorButton6.Tag = "NEditCalculator";
            this.tnPrintRangeTo.ButtonsRight.Add(dropDownEditorButton6);
            this.tnPrintRangeTo.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tnPrintRangeTo.CalcSize = new System.Drawing.Size(172, 200);
            this.tnPrintRangeTo.DataText = "";
            this.tnPrintRangeTo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tnPrintRangeTo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tnPrintRangeTo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnPrintRangeTo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnPrintRangeTo.Location = new System.Drawing.Point(260, 28);
            this.tnPrintRangeTo.MaxLength = 3;
            this.tnPrintRangeTo.Name = "tnPrintRangeTo";
            this.tnPrintRangeTo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tnPrintRangeTo.Size = new System.Drawing.Size(48, 21);
            this.tnPrintRangeTo.TabIndex = 7;
            this.tnPrintRangeTo.ValueChanged += new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            // 
            // ulPrintRangeTo
            // 
            appearance69.TextVAlignAsString = "Middle";
            this.ulPrintRangeTo.Appearance = appearance69;
            this.ulPrintRangeTo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintRangeTo.Location = new System.Drawing.Point(224, 32);
            this.ulPrintRangeTo.Name = "ulPrintRangeTo";
            this.ulPrintRangeTo.Size = new System.Drawing.Size(32, 16);
            this.ulPrintRangeTo.TabIndex = 5;
            this.ulPrintRangeTo.Text = "�I��";
            // 
            // tnPrintRangeFrom
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tnPrintRangeFrom.ActiveAppearance = appearance70;
            this.tnPrintRangeFrom.AutoSelect = true;
            dropDownEditorButton7.Tag = "NEditCalculator";
            this.tnPrintRangeFrom.ButtonsRight.Add(dropDownEditorButton7);
            this.tnPrintRangeFrom.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tnPrintRangeFrom.CalcSize = new System.Drawing.Size(172, 200);
            this.tnPrintRangeFrom.DataText = "";
            this.tnPrintRangeFrom.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tnPrintRangeFrom.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tnPrintRangeFrom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnPrintRangeFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnPrintRangeFrom.Location = new System.Drawing.Point(160, 28);
            this.tnPrintRangeFrom.MaxLength = 3;
            this.tnPrintRangeFrom.Name = "tnPrintRangeFrom";
            this.tnPrintRangeFrom.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tnPrintRangeFrom.Size = new System.Drawing.Size(48, 21);
            this.tnPrintRangeFrom.TabIndex = 6;
            this.tnPrintRangeFrom.ValueChanged += new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            // 
            // uosPrintRange
            // 
            this.uosPrintRange.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosPrintRange.CheckedIndex = 0;
            this.uosPrintRange.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance71.FontData.SizeInPoints = 9F;
            this.uosPrintRange.ItemAppearance = appearance71;
            this.uosPrintRange.ItemOrigin = new System.Drawing.Point(2, 2);
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "���ׂ� ";
            valueListItem11.DataValue = 2;
            valueListItem11.DisplayText = "�y�[�W�w��";
            this.uosPrintRange.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11});
            this.uosPrintRange.ItemSpacingHorizontal = 2;
            this.uosPrintRange.ItemSpacingVertical = 4;
            this.uosPrintRange.Location = new System.Drawing.Point(12, 13);
            this.uosPrintRange.Name = "uosPrintRange";
            this.uosPrintRange.Size = new System.Drawing.Size(108, 40);
            this.uosPrintRange.TabIndex = 5;
            this.uosPrintRange.Text = "���ׂ� ";
            this.uosPrintRange.ValueChanged += new System.EventHandler(this.uosPrintRange_ValueChanged);
            // 
            // ulPrintRangeFrom
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ulPrintRangeFrom.Appearance = appearance72;
            this.ulPrintRangeFrom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintRangeFrom.Location = new System.Drawing.Point(128, 32);
            this.ulPrintRangeFrom.Name = "ulPrintRangeFrom";
            this.ulPrintRangeFrom.Size = new System.Drawing.Size(32, 16);
            this.ulPrintRangeFrom.TabIndex = 2;
            this.ulPrintRangeFrom.Text = "�J�n";
            // 
            // ugbPrinter
            // 
            this.ugbPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbPrinter.Controls.Add(this.tcePrinterName);
            this.ugbPrinter.Controls.Add(this.ulPrinterName);
            this.ugbPrinter.Location = new System.Drawing.Point(8, 108);
            this.ugbPrinter.Name = "ugbPrinter";
            this.ugbPrinter.Size = new System.Drawing.Size(456, 52);
            this.ugbPrinter.TabIndex = 2;
            this.ugbPrinter.Text = "�v�����^";
            // 
            // tcePrinterName
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrinterName.ActiveAppearance = appearance73;
            this.tcePrinterName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tcePrinterName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tcePrinterName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrinterName.ItemAppearance = appearance74;
            this.tcePrinterName.Location = new System.Drawing.Point(92, 16);
            this.tcePrinterName.Name = "tcePrinterName";
            this.tcePrinterName.Size = new System.Drawing.Size(268, 24);
            this.tcePrinterName.TabIndex = 4;
            // 
            // ulPrinterName
            // 
            appearance75.TextVAlignAsString = "Middle";
            this.ulPrinterName.Appearance = appearance75;
            this.ulPrinterName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrinterName.Location = new System.Drawing.Point(20, 16);
            this.ulPrinterName.Name = "ulPrinterName";
            this.ulPrinterName.Size = new System.Drawing.Size(72, 23);
            this.ulPrinterName.TabIndex = 2;
            this.ulPrinterName.Text = "�v�����^��";
            // 
            // ugbFormat
            // 
            this.ugbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbFormat.Controls.Add(this.ubDetail);
            this.ugbFormat.Controls.Add(this.ucePrevew);
            this.ugbFormat.Controls.Add(this.ulPrintMsg);
            this.ugbFormat.Controls.Add(this.tcePrintType);
            this.ugbFormat.Controls.Add(this.ultraLabel22);
            this.ugbFormat.Location = new System.Drawing.Point(8, 12);
            this.ugbFormat.Name = "ugbFormat";
            this.ugbFormat.Size = new System.Drawing.Size(456, 96);
            this.ugbFormat.TabIndex = 1;
            this.ugbFormat.Text = "���[";
            // 
            // ubDetail
            // 
            this.ubDetail.Location = new System.Drawing.Point(364, 16);
            this.ubDetail.Name = "ubDetail";
            this.ubDetail.Size = new System.Drawing.Size(84, 24);
            this.ubDetail.TabIndex = 2;
            this.ubDetail.Text = "�ڍאݒ�";
            this.ubDetail.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubDetail.Click += new System.EventHandler(this.ubDetail_Click);
            // 
            // ucePrevew
            // 
            this.ucePrevew.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ucePrevew.Location = new System.Drawing.Point(96, 68);
            this.ucePrevew.Name = "ucePrevew";
            this.ucePrevew.Size = new System.Drawing.Size(120, 20);
            this.ucePrevew.TabIndex = 3;
            this.ucePrevew.Text = "����v���r���[";
            // 
            // ulPrintMsg
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ulPrintMsg.Appearance = appearance76;
            this.ulPrintMsg.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintMsg.Location = new System.Drawing.Point(96, 40);
            this.ulPrintMsg.Name = "ulPrintMsg";
            this.ulPrintMsg.Size = new System.Drawing.Size(352, 23);
            this.ulPrintMsg.TabIndex = 3;
            this.ulPrintMsg.Text = "�`�S�p����ݒ肵�Ă�������";
            // 
            // tcePrintType
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrintType.ActiveAppearance = appearance77;
            this.tcePrintType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tcePrintType.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tcePrintType.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrintType.ItemAppearance = appearance78;
            this.tcePrintType.Location = new System.Drawing.Point(92, 16);
            this.tcePrintType.Name = "tcePrintType";
            this.tcePrintType.Size = new System.Drawing.Size(268, 24);
            this.tcePrintType.TabIndex = 1;
            this.tcePrintType.ValueChanged += new System.EventHandler(this.tcePrintType_ValueChanged);
            // 
            // ultraLabel22
            // 
            appearance79.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance79;
            this.ultraLabel22.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(20, 16);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel22.TabIndex = 2;
            this.ultraLabel22.Text = "�`�[�^�C�v";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.ubCancel);
            this.pnlBottom.Controls.Add(this.ubPrint);
            this.pnlBottom.Controls.Add(this.ubPdf);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 238);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(474, 36);
            this.pnlBottom.TabIndex = 1002;
            // 
            // ubCancel
            // 
            this.ubCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubCancel.Location = new System.Drawing.Point(144, 8);
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size(100, 24);
            this.ubCancel.TabIndex = 9;
            this.ubCancel.Text = "�߂�(&C)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler(this.ubPrint_Click);
            // 
            // ubPrint
            // 
            this.ubPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubPrint.Location = new System.Drawing.Point(248, 8);
            this.ubPrint.Name = "ubPrint";
            this.ubPrint.Size = new System.Drawing.Size(100, 24);
            this.ubPrint.TabIndex = 10;
            this.ubPrint.Text = "���(&P)";
            this.ubPrint.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubPrint.Click += new System.EventHandler(this.ubPrint_Click);
            // 
            // ubPdf
            // 
            this.ubPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubPdf.Location = new System.Drawing.Point(352, 8);
            this.ubPdf.Name = "ubPdf";
            this.ubPdf.Size = new System.Drawing.Size(116, 24);
            this.ubPdf.TabIndex = 11;
            this.ubPdf.Text = "�o�c�e�o��(&V)";
            this.ubPdf.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubPdf.Click += new System.EventHandler(this.ubPrint_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 687);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(982, 23);
            this.ultraStatusBar1.TabIndex = 5;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Left
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Left";
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 710);
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.utmMain;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Right
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(982, 28);
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Right";
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 710);
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.utmMain;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Top
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Top";
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(982, 28);
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.utmMain;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 738);
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Bottom";
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(982, 0);
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.utmMain;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "���ׂẴt�@�C��|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "PDF�̊i�[��";
            // 
            // ilSlipPrintImage
            // 
            this.ilSlipPrintImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSlipPrintImage.ImageStream")));
            this.ilSlipPrintImage.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSlipPrintImage.Images.SetKeyName(0, "");
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // imgListIntensive
            // 
            this.imgListIntensive.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIntensive.ImageStream")));
            this.imgListIntensive.TransparentColor = System.Drawing.Color.White;
            this.imgListIntensive.Images.SetKeyName(0, "");
            this.imgListIntensive.Images.SetKeyName(1, "");
            this.imgListIntensive.Images.SetKeyName(2, "");
            this.imgListIntensive.Images.SetKeyName(3, "");
            this.imgListIntensive.Images.SetKeyName(4, "");
            // 
            // uttmToolTip
            // 
            this.uttmToolTip.ContainingControl = this;
            this.uttmToolTip.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // DCCMN02000UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(982, 738);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Bottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DCCMN02000UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�`�[����m�F";
            this.Load += new System.EventHandler(this.DCCMN02000UB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DCCMN02000UA_KeyDown);
            this.utpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbSlipDatePrintDiv)).EndInit();
            this.ugbSlipDatePrintDiv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosSlipDatePrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCopyCount)).EndInit();
            this.ugbCopyCount.ResumeLayout(false);
            this.ugbCopyCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnCopyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbTitle)).EndInit();
            this.ugbTitle.ResumeLayout(false);
            this.ugbTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEnterpriseNamePrtCd)).EndInit();
            this.ugbEnterpriseNamePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosEnterpriseNamePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCustTelNoPrtDivCd)).EndInit();
            this.ugbCustTelNoPrtDivCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosCustTelNoPrtDivCd)).EndInit();
            this.utpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbTotalPricePrtCd)).EndInit();
            this.ugbTotalPricePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosTotalPricePrtCd)).EndInit();
            this.utpDetail2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeColMove)).EndInit();
            this.ugbEachSlipTypeColMove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugEachSlipTypeColMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSourceColMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeCol)).EndInit();
            this.ugbEachSlipTypeCol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utEachSlipTypeCol)).EndInit();
            this.utpMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbMargin)).EndInit();
            this.ugbMargin.ResumeLayout(false);
            this.ugbMargin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneBottomMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneRightMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneTopMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            this.utpFont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).EndInit();
            this.ultraGroupBox8.ResumeLayout(false);
            this.ultraGroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufneSlipFontName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbOutlinePrtCd)).EndInit();
            this.ugbOutlinePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosOutlinePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbBankNamePrtCd)).EndInit();
            this.ugbBankNamePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosBankNamePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utcDetail)).EndInit();
            this.utcDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utmMain)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintCopy)).EndInit();
            this.ugbPrintCopy.ResumeLayout(false);
            this.ugbPrintCopy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintRange)).EndInit();
            this.ugbPrintRange.ResumeLayout(false);
            this.ugbPrintRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uosPrintRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrinter)).EndInit();
            this.ugbPrinter.ResumeLayout(false);
            this.ugbPrinter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbFormat)).EndInit();
            this.ugbFormat.ResumeLayout(false);
            this.ugbFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrintType)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        //==================================================================================
        // �R���X�g���N�^
        //==================================================================================
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public DCCMN02000UB(SlipPrintAcs slipPrintAcs)
        {
            // �R���|�[�l���g������
            InitializeComponent();

            // �`�[����A�N�Z�X�N���X���
            _slipPrintAcs = slipPrintAcs;
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            _scmRtPrtDtAcs = new ScmRtPrtDtAcs();
            _pccCmpnyStAcs = new PccCmpnyStAcs();
            _pccTtlStAcs = new PccTtlStAcs();
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

            // �_�C�A���O�Ȃ���������Ȃ�
            _printWithoutDialog = false;

            // ��Ə����擾
            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                // ��ƃR�[�h��ݒ肷��
                _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            // �`�[����p�����[�^(�f�[�^�N���X�O���)
            _slipPrintParameter = new SlipPrintParameter();

            // �X�e�[�^�X
            _slipPrintDialogState = SlipPrintDialogStatus.Normal;

            // ������Ԃ��ȈՔłt�h�ɐݒ�
            this.Width = 540;
            this.Height = 300;
            this.MaximizeBox = false;
            this.CancelButton = this.ubCancel;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Normal;

            // �f�[�^�L���b�V������
            _dataCache = SlipDialogDataCache.GetInstance();
        }
        # endregion �� �R���X�g���N�^ ��

        //==================================================================================
        // �v���p�e�B
        //==================================================================================
        # region �� �v���p�e�B ��
        /// <summary>
        /// �`�[����_�C�A���O�X�e�[�^�X
        /// </summary>
        public SlipPrintDialogStatus SlipPrintDialogState
        {
            get { return _slipPrintDialogState; }
        }
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �T�[�r�X�N���v���p�e�B
        /// </summary>
        public int IsService
        {
            get { return this._isService; }
            set { this._isService = value; }
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �����[�g�`�[���s�v���p�e�B
        /// </summary>
        public bool IsRmSlpPrt
        {
            get { return this._IsRmSlpPrt; }
            set { this._IsRmSlpPrt = value; }
        }
        /// <summary>
        /// PCCUOE�����񓚋N���t���O�v���p�e�B(0:�ʏ� 1:PCCUOE�����񓚋N��)
        /// </summary>
        public int IsAutoAns
        {
            get { return this._isAutoAns; }
            set { this._isAutoAns = value; }
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        /// <summary>
        /// ����`�[���ʂ͂P���t���O�ifalse:�P���ȏ�Atrue:�P���j
        /// </summary>
        public bool IsOnlyOneSlip
        {
            set { this._isOnlyOneSlip = value; }
        }

        /// <summary>
        /// �Ō㑗�M�̔���`�[�t���O�ifalse:�Ō�ł͂Ȃ��Atrue:�Ō�j
        /// </summary>
        public bool IsLastSlip
        {
            set { this._isLastSlip = value; }
        }
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<

        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        /// <summary>
        /// �����[�g�`�[�ŐV���ʋ敪KEY�ύX�t���O�ifalse:�ύX���Ȃ��Atrue:�ύX����j
        /// </summary>
        public bool IsKeyChangeFlag
        {
            set { this._isKeyChangeFlag = value; }
        }
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        // ADD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
        /// <summary>
        /// ����`�[���X�g�v���p�e�B
        /// </summary>
        public List<string> SlipNumlist
        {
            get { return _slipNumlist; }
            set { _slipNumlist = value; }
        }
        /// <summary>
        /// �⍇���ԍ����X�g�v���p�e�B
        /// </summary>
        public List<string> InquiryNumList
        {
            get { return _inquiryNumList; }
            set { _inquiryNumList = value; }
        }
        /// <summary>
        /// �^�u���b�g�N���敪(True:�^�u���b�g���N�� False:�^�u���b�g�ȊO���N��)
        /// </summary>
        public bool IsTablet
        {
            get { return _isTablet; }
            set { _isTablet = value; }
        }
        // ADD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private List<List<object>> _printDataList;
        /// <summary>
        /// �����`�[���̃f�[�^���X�g
        /// </summary>
        public List<List<object>> PrintDataList
        {
            get { return _printDataList; }
            set { _printDataList = value; }
        }
        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        //==================================================================================
        // �C�x���g����
        //==================================================================================
        # region �� �C�x���g���� ��

        # region ���@�t�H�[�����[�h�C�x���g�����@��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCCMN02000UB_Load(object sender, EventArgs e)
        {
            //******************************************************
            // ���ӁF�@�ȉ��ł́A��ʂȂ�����̂Ƃ��s�v�ŁA
            //        ��ʂ���̎��̂ݕK�v�ȏ������L�q���܂��B
            //        (��ʂȂ����̏������ɗ͍����������)
            //******************************************************

            //------------------------------------------------------
            // �C���X�^���X����
            //------------------------------------------------------
            # region [�C���X�^���X����]
            // ����v���r���[�t�H�[��
            _slipPrintAssemblyFrom = new SFMIT01290UA();
            # endregion

            //------------------------------------------------------
            // ��ʂ��ȈՔłɂ���
            //------------------------------------------------------
            # region [��ʂ��ȈՔłɂ���]
            // �ڍ׃{�^���\���ɂ���
            ubDetail.Visible = true;
            // �v���r���[�{�^����\���ɂ���
            ucePrevew.Visible = true;

            // �ȈՔł̃{�^����\���ɂ���
            pnlBottom.Visible = true;

            // �^�u�R���g���[�����\��
            this.pnlLeft.Visible = false;
            // �r���[���[���\��
            this.pnlPrevew.Visible = false;
            // �c�[���o�[�\��
            this.utmMain.Visible = false;
            // �X�v���b�^�[���\��
            this.splitter1.Visible = false;
            // �X�e�[�^�X�o�[���\��
            this.ultraStatusBar1.Visible = false;

            // ���C���p�l����Parent��Dock��������
            this.pnlMain.Parent = Form1_Fill_Panel;
            this.pnlMain.Dock = DockStyle.Fill;

            //this.Width = 540;
            //this.Height = 300;
            //this.MaximizeBox = false;
            //this.CancelButton = this.ubCancel;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.WindowState = FormWindowState.Normal;
            # endregion

            //------------------------------------------------------
            // ��ʂ�������
            //------------------------------------------------------
            # region [��ʂ�������]
            // �]�����x�����\��
            this.ulTopMark1.Visible = false;
            this.ulTopMark2.Visible = false;
            this.ulLeftMark1.Visible = false;
            this.ulLeftMark2.Visible = false;
            # endregion

            //------------------------------------------------------
            // �ڍ׃^�u�̕\������
            //------------------------------------------------------
            # region [�ڍ׃^�u�̕\������]
            // �`�[�̏ꍇ
            // �@���׃^�u��\��
            // �A����C���[�W(bmp)��`�[�摜�ɂ���
            utpDetail.Tab.Visible = true;
            utpDetail2.Tab.Visible = true;
            //utpFooter.Tab.Visible = false;  // ���t�b�^�^�u�͖��g�p�̈ו\�����Ȃ��B
            upbSlipImage.Image = ilSlipPrintImage.Images[0];
            # endregion

            //-------------------------------------------
            // �e��A�C�R����ݒ肷��
            //-------------------------------------------
            # region [�A�C�R��]
            // �{�g���{�^��
            ubCancel.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.BEFORE];
            ubPrint.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINT];
            ubPdf.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW];
            // �ڍ׃{�^��
            ubDetail.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS];
            // �c�[���o�[�E�C���[�W���X�g��ݒ肷��
            utmMain.ImageListSmall = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            // �߂�ւ̃A�C�R���ݒ�
            ButtonTool CancelButton = (ButtonTool)utmMain.Tools["Cancel"];
            if (CancelButton != null)
            {
                CancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            }
            // ����ւ̃A�C�R���ݒ�
            ButtonTool PrintButton = (ButtonTool)utmMain.Tools["Print"];
            if (PrintButton != null)
            {
                PrintButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            }
            // PDF����ւ̃A�C�R���ݒ�
            ButtonTool PdfButton = (ButtonTool)utmMain.Tools["Pdf"];
            if (PdfButton != null)
            {
                PdfButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.VIEW;
            }

            // �w�b�_�[
            this.utcDetail.Tabs[0].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.HEADER];
            // ����
            this.utcDetail.Tabs[1].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.ROW];
            // ���ׁi��j
            this.utcDetail.Tabs[2].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.COL];
            //// �t�b�^�[
            //this.utcDetail.Tabs[3].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.FOOTER];
            // �}�[�W��
            this.utcDetail.Tabs[3].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MARGIN];
            // �t�H���g
            this.utcDetail.Tabs[4].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.FONT];

            // �J���[�K�C�h
            this.ubSlipColorT1.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ubSlipColorT2.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ubSlipColorT3.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ubSlipColorT4.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            # endregion

            //-------------------------------------------
            // �t�H���g�ꗗ����
            //-------------------------------------------
            # region [�t�H���g�ꗗ����]
            // Regular�y��Bold���T�|�[�g���Ă��Ȃ��t�H���g�͍폜����
            for (int ix = 0; ix != this.ufneSlipFontName.Items.Count; ix++)
            {
                FontFamily fontFamily = new FontFamily(this.ufneSlipFontName.Items[ix].ToString());
                if ((!fontFamily.IsStyleAvailable(FontStyle.Regular) ||
                    (!fontFamily.IsStyleAvailable(FontStyle.Bold))))
                {
                    this.ufneSlipFontName.Items.RemoveAt(ix);
                }
            }
            # endregion
        }
        # endregion

        # region �� �ڍ׃{�^�� ��
        /// <summary>
        /// �ڍ׃{�^���̉����C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׃{�^���̉����C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ubDetail_Click(object sender, System.EventArgs e)
        {
            _FormType = 1; // �ڍה�

            // ���DLL�Ɉ�������ƃf�[�^��ݒ肷��
            CallSetPrintConditionInfoAndDataMethod();
            // �g�嗦��ݒ肷��
            this._prtParam.ExpansionRate = 50;

            // �X�v���b�^�[��\��
            this.splitter1.Visible = true;
            // �r���[���[��\��
            this.pnlPrevew.Visible = true;
            // �^�u�R���g���[����\��
            this.pnlLeft.Visible = true;
            // �c�[���o�[�\��
            this.utmMain.Visible = true;
            // �X�v���b�^�[��\��
            this.splitter1.Visible = true;
            // �X�e�[�^�X�o�[��\��
            this.ultraStatusBar1.Visible = true;

            this.pnlMain.Parent = this.pnlLeft;
            this.pnlMain.Dock = DockStyle.Top;

            this.Width = 1024;
            this.Height = 730;

            this.MaximizeBox = true;
            this.CancelButton = null;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // �ȈՔł̃{�^�����\���ɂ���
            pnlBottom.Visible = false;
            // ���C���p�l����Height���k�߂�
            this.pnlMain.Height = 240;
            // �w�b�_�[��Tab�y�[�W���A�N�e�B�u�ɂ���
            this.utcDetail.SelectedTab = this.utpHeader.Tab;

            // �e��ʂ̐^�񒆂ɍĕ\��
            this.CenterToParent();

            // �v���r���[��ʂ��o�C���h����
            if (_slipPrintAssemblyFrom != null)
            {
                // �t�H�[���̋N��
                _slipPrintAssemblyFrom.TopLevel = false;
                _slipPrintAssemblyFrom.FormBorderStyle = FormBorderStyle.None;
                // �p�l���ɃR���g���[����ǉ�����
                this.pnlPrevew.Controls.Add(_slipPrintAssemblyFrom);
                _slipPrintAssemblyFrom.Dock = System.Windows.Forms.DockStyle.Fill;
                _slipPrintAssemblyFrom.BringToFront();
                _slipPrintAssemblyFrom.Show();
            }

            // �v���r���[�\��
            CallPrevewMethod();

            // ���[�^�C�v�Ƀt�H�[�J�X���ڂ�
            this.tcePrintType.Focus();
            // �ڍ׃{�^����\���ɂ���
            ubDetail.Visible = false;
            // �v���r���[�{�^�����\���ɂ���
            ucePrevew.Visible = false;

            // ���R���[�Ή��\��
            FormSettingForFreP(IsFrePSlip(_slipPrtSet));
        }
        # endregion �� �ڍ׃{�^�� ��

        # region �� �e��ݒ�@�ύX�C�x���g ��
        /// <summary>
        /// �`�[����ݒ荀�ڂ̕ύX�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�[����ݒ荀�ڂ̕ύX�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ItemValueChanged(object sender, System.EventArgs e)
        {
            // ��ʕ`�撆�́Aexit
            if ((string)utcDetail.Tag == ctFormDrawingNow)
            {
                return;
            }
            // �ȈՉ�ʒ��́A�������Ȃ�
            if (_FormType == 0)
            {
                return;
            }
            // ������W���[���́A���[�h����Ă��邩�H
            if (_slipPrintAssemblyFrom != null)
            {
                // �������f�[�^�ݒ胁�\�b�h�R�[��
                CallSetPrintConditionInfoAndDataMethod();
                // �g�嗦��ݒ肷��
                this._prtParam.ExpansionRate = 0;

                // �v���r���[���\�b�h�R�[��
                CallPrevewMethod();
            }

            if (sender is Control)
            {
                ((Control)sender).Focus();
            }
        }
        /// <summary>
        /// ���ʖ����̕ύX�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׃{�^���̉����C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tnCopyCount_TextChanged(object sender, System.EventArgs e)
        {
            // ���ʖ������擾����
            int CopyCount = (int)tnCopyCount.Value;

            // �^�C�g���P
            tceTitle1.Visible = true;
            // �^�C�g���Q
            if (CopyCount >= 2)
            {
                ulTitle2.Visible = true;
                tceTitle2.Visible = true;
                ulSlipColorT2.Visible = true;
                ubSlipColorT2.Visible = true;
            }
            else
            {
                ulTitle2.Visible = false;
                tceTitle2.Visible = false;
                ulSlipColorT2.Visible = false;
                ubSlipColorT2.Visible = false;
            }
            // �^�C�g���R
            if (CopyCount >= 3)
            {
                ulTitle3.Visible = true;
                tceTitle3.Visible = true;
                ulSlipColorT3.Visible = true;
                ubSlipColorT3.Visible = true;
            }
            else
            {
                ulTitle3.Visible = false;
                tceTitle3.Visible = false;
                ulSlipColorT3.Visible = false;
                ubSlipColorT3.Visible = false;
            }
            // �^�C�g���S
            if (CopyCount >= 4)
            {
                ulTitle4.Visible = true;
                tceTitle4.Visible = true;
                ulSlipColorT4.Visible = true;
                ubSlipColorT4.Visible = true;
            }
            else
            {
                ulTitle4.Visible = false;
                tceTitle4.Visible = false;
                ulSlipColorT4.Visible = false;
                ubSlipColorT4.Visible = false;
            }

            // ���ύX�C�x���g���N������
            System.EventArgs EvtArg = new EventArgs();
            ItemValueChanged(sender, EvtArg);
        }

        /// <summary>
        /// �y�[�W�͈͒l�ύX�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �y�[�W�͈͒l�ύX�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void uosPrintRange_ValueChanged(object sender, System.EventArgs e)
        {
            object ObjValue = uosPrintRange.Value;
            if (ObjValue != null)
            {
                int intValue = (int)ObjValue;
                if (intValue == 1)
                {
                    // �S��
                }
                else
                {
                    // �y�[�W�w��
                    // �y�[�W�J�n�Ƀt�H�[�J�X�ړ�
                    tnPrintRangeFrom.Focus();
                }
            }
        }

        /// <summary>
        /// �J�n�y�[�W�ύX�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׃{�^���̉����C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tnPrintRangeFrom_ValueChanged(object sender, System.EventArgs e)
        {
            // �J�nor�I���ɒl�������Ă���ꍇ
            if ((tnPrintRangeFrom.GetInt() > 0) || (tnPrintRangeTo.GetInt() > 0))
            {
                // �y�[�W����Ƀ`�F�b�N��t����
                uosPrintRange.Value = 2;
            }
        }

        /// <summary>
        /// �m�[�h�̃`�F�b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �m�[�h�̃`�F�b�N�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void utEachSlipTypeCol_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (e.TreeNode.CheckedState == CheckState.Unchecked)
            {
                // �m�[�h�̃`�F�b�N���O��Ă���ꍇ�A����\���ɂ���
                this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[e.TreeNode.Key].Hidden = true;
            }
            else
            {
                // �m�[�h�̃`�F�b�N�������Ă���ꍇ�A���\���ɂ���
                this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[e.TreeNode.Key].Hidden = false;
            }
            // ���ύX�C�x���g���N������
            System.EventArgs EvtArg = new EventArgs();
            ItemValueChanged(sender, EvtArg);
        }

        /// <summary>
        /// ��ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ړ��C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ugEachSlipTypeColMove_AfterColPosChanged(object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e)
        {
            // ���ύX�C�x���g���N������
            System.EventArgs EvtArg = new EventArgs();
            ItemValueChanged(sender, EvtArg);
        }

        /// <summary>
        /// ���ݑI�𒆂̓`�[�^�C�v�̈���ݒ���擾
        /// </summary>
        /// <returns></returns>
        private SlipPrtSetWork GetSlipPrtSetSelected()
        {
            // ��ʂ�comboBox��value���L�[�ɂ��Ď擾
            return _slipPrintAcs.GetSlipPrtSetWork((int)tcePrintType.Value);
        }

        /// <summary>
        /// �`�[�^�C�v�ύX�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�[�^�C�v�ύX�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tcePrintType_ValueChanged(object sender, System.EventArgs e)
        {
            // �`�[�^�C�v�擾
            if (tcePrintType.Value != null)
            {
                // �`�[����ݒ�R���N�V��������I�������`�[����ݒ���擾����
                _slipPrtSet = GetSlipPrtSetSelected();

                if (_slipPrtSet != null)
                {
                    // �v���r���[�t�H�[���𐶐�����
                    _slipPrintAssemblyFrom = null;
                    _slipPrintAssemblyFrom = new SFMIT01290UA();

                    // ������i�𐶐�����
                    _prtObj = null;

                    try
                    {
                        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                        //_prtObj = LoadAssemblyFrom(_slipPrtSet.OutputPgId, _slipPrtSet.OutputPgClassId);
                        _prtObj = LoadAssemblyFrom(_slipPrtSet.OutputPgId, _slipPrtSet.OutputPgClassId, _slipPrtSet.OutputFormFileName);
                        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

                    }
                    catch
                    {
                    }

                    // ������i�����Ɏ��s���I��
                    if (_prtObj == null)
                    {
                        TMsgDisp.Show(this
                            , emErrorLevel.ERR_LEVEL_STOPDISP
                            , null
                            , "�`�[����m�F���"
                            , null
                            , TMsgDisp.OPE_PRINT
                            , "������i�̐����Ɏ��s���܂����i" + _slipPrtSet.OutputPgId + "�j"
                            , 0
                            , null
                            , null
                            , MessageBoxButtons.OK
                            , MessageBoxDefaultButton.Button1);
                        return;
                    }


                    // �`�[����v���r���[���i�̐ݒ�
                    if (_slipPrintAssemblyFrom != null)
                    {
                        // �v���r���[��ʖ��ݒ�
                        _slipPrintAssemblyFrom.Text = "����v���r���[";
                    }

                    // �f�[�^��\������
                    //SlipPrtSetToDisplay(_slipPrtSet, _slipIniSet);
                    SlipPrtSetToDisplay(_slipPrtSet);

                    // ��ʂ��ڍהł̏ꍇ
                    if (_FormType != 0)
                    {
                        // �v���r���[�\����
                        // �v���r���[��ʂ��o�C���h����
                        if (_slipPrintAssemblyFrom != null)
                        {
                            this.pnlPrevew.Controls.Clear();
                            // �t�H�[���̋N��
                            _slipPrintAssemblyFrom.TopLevel = false;
                            _slipPrintAssemblyFrom.FormBorderStyle = FormBorderStyle.None;
                            // �p�l���ɃR���g���[����ǉ�����
                            this.pnlPrevew.Controls.Add(_slipPrintAssemblyFrom);
                            _slipPrintAssemblyFrom.Dock = System.Windows.Forms.DockStyle.Fill;
                            _slipPrintAssemblyFrom.BringToFront();
                            _slipPrintAssemblyFrom.Show();
                        }

                        // ���DLL�Ɉ�������ƃf�[�^��ݒ肷��
                        CallSetPrintConditionInfoAndDataMethod();
                        // �g�嗦��ݒ肷��
                        this._prtParam.ExpansionRate = 50;

                        // �v���r���[�\��
                        CallPrevewMethod();
                    }

                    // ���R���[�Ή��\���X�V
                    FormSettingForFreP(IsFrePSlip(_slipPrtSet));
                }
            }
        }
        /// <summary>
        /// ���R���[����
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        private bool IsFrePSlip(SlipPrtSetWork slipPrtSet)
        {
            return slipPrtSet.SpecialPurpose1.Equals("20");
        }
        /// <summary>
        /// ���R���[�Ή� ��ʐ���
        /// </summary>
        private void FormSettingForFreP(bool isFreP)
        {
            // �w�b�_�[
            ugbEnterpriseNamePrtCd.Visible = !isFreP;
            uosEnterpriseNamePrtCd.Visible = !isFreP;
            ugbCustTelNoPrtDivCd.Visible = !isFreP;
            uosCustTelNoPrtDivCd.Visible = !isFreP;
            // ����
            this.utcDetail.Tabs[1].Visible = !isFreP;
            // ���ׁi��j
            this.utcDetail.Tabs[2].Visible = !isFreP;
            // �]��
            // �t�H���g
            this.utcDetail.Tabs[4].Visible = !isFreP;
        }
        # endregion �� �e��ݒ�@�ύX�C�x���g ��

        # region �� �c�[���o�[�^�{�^���N���b�N ��
        /// <summary>
        /// �c�[���o�[�̃N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̃N���b�N�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void utmMain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // �c�[���o�[�N���b�N�C�x���g���{�^���̃C�x���g�Ɏ�������
            System.EventArgs buttonEventArgs = new EventArgs();
            switch (e.Tool.Key)
            {
                case "Cancel": // �L�����Z��
                    {
                        ubPrint_Click(ubCancel, buttonEventArgs);
                        break;
                    }
                case "Print": // ���
                    {
                        ubPrint_Click(ubPrint, buttonEventArgs);
                        break;
                    }
                case "Pdf": // �o�c�e
                    {
                        ubPrint_Click(ubPdf, buttonEventArgs);
                        break;
                    }
            }
        }

        /// <summary>
        /// ���/�L�����Z��/PDF�{�^���̃N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���/�L�����Z��/PDF�{�^���̃N���b�N�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ubPrint_Click(object sender, System.EventArgs e)
        {
            //==============================================================
            // �L�����Z���{�^��																								
            //==============================================================
            if (sender == ubCancel)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Hide();
            }

            //==============================================================
            // ����{�^��																								
            //==============================================================
            if (sender == ubPrint)
            {
                // ����Ăяo��
                if (CallPrint() == 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }

            //==============================================================
            // �o�c�e�{�^��																								
            //==============================================================
            if (sender == ubPdf)
            {
                if (this._printData != null)
                {
                    //------------------------------------------------------
                    // �������`�[���w�肳�ꂽ�ꍇ�A�o��PDF�t�@�C����
                    //   �`�[���ɕ����邽�߂ɁA�ꎞ�I�ɓ`�[�f�[�^�P���݂̂�
                    //   ��Ԃɂ��܂��B
                    //   �S�Ă̓`�[���o�c�e�o�͂�����A�S�`�[�f�[�^��
                    //   �ޔ����Ă������ϐ�����߂��܂��B
                    //------------------------------------------------------

                    // �`�[�f�[�^�`�k�k�ޔ�
                    List<ArrayList> printDataWk = this._printData;

                    for (int index = 0; index < printDataWk.Count; index++)
                    {
                        // PDF�������ݗp�ɂP�`�[���̃f�[�^�̂ݐݒ�
                        this._printData = new List<ArrayList>();
                        this._printData.Add(printDataWk[index]);

                        // �`�[�ԍ��擾
                        //string slipNum = GetSlipNumFromCndtn( this._iSlipPrintCndtn, index );
                        string slipNum = GetSlipNumFromCndtn(this._iSlipPrintCndtn, printDataWk[index], index);

                        // PDF�������� (�ꎞ�I�ɓ`�[�f�[�^���P�������ɂ��Ă���̂ŁA����[0]�Ԃ�����)
                        WritePDF(slipNum);
                    }

                    // �`�[�f�[�^�`�k�k�߂�
                    this._printData = printDataWk;
                }
            }
        }

        /// <summary>
        /// �`�[�ԍ��擾����( PDF�̘A�ԕt�Ɏg�p )
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetSlipNumFromCndtn(ISlipPrintCndtn iSlipPrintCndtn, ArrayList data, int index)
        {
            if (iSlipPrintCndtn is SalesSlipPrintCndtn)
            {
                // ����`�[�̏ꍇ
                FrePSalesSlipWork slipWork = (data[0] as FrePSalesSlipWork);

                string slipType = string.Empty;

                switch (slipWork.SALESSLIPRF_ACPTANODRSTATUSRF)
                {
                    case 10:
                        slipType = "����";
                        break;
                    case 20:
                        slipType = "��";
                        break;
                    default:
                    case 30:
                        switch (slipWork.SALESSLIPRF_SALESSLIPCDRF)
                        {
                            default:
                            case 0:
                                slipType = "����";
                                break;
                            case 1:
                                slipType = "�ԕi";
                                break;
                        }
                        break;
                    case 40:
                        slipType = "�ݏo";
                        break;
                }

                return string.Format("{0}_{1}", slipWork.SALESSLIPRF_SALESSLIPNUMRF, slipType);
            }
            else if (iSlipPrintCndtn is StockSlipPrintCndtn)
            {
                // �d���ԕi�`�[�̏ꍇ
                return string.Format("{0}_�d���ԕi", index.ToString());
            }
            else if (iSlipPrintCndtn is StockMoveSlipPrintCndtn)
            {
                // �݌Ɉړ��`�[�̏ꍇ
                FrePStockMoveSlipWork slipWork = (data[0] as FrePStockMoveSlipWork);
                return string.Format("{0}_�݌Ɉړ�", slipWork.MOVH_STOCKMOVESLIPNORF.ToString("000000000"));
            }
            else if (iSlipPrintCndtn is EstFmPrintCndtn)
            {
                // ���Ϗ��̏ꍇ
                FrePEstFmHead slipWork = (data[0] as FrePEstFmHead);
                return string.Format("{0}", slipWork.SALESSLIPRF_SALESSLIPNUMRF);
            }
            else if (iSlipPrintCndtn is UOESlipPrintCndtn)
            {
                // �t�n�d�`�[�̏ꍇ
                FrePSalesSlipWork slipWork = (data[0] as FrePSalesSlipWork);
                return string.Format("{0}_UOE", slipWork.SALESSLIPRF_SALESSLIPNUMRF);
            }

            // �`�[���ɑ���������e���擾�ł��Ȃ��ꍇ�͒ʂ��ԍ��Ƃ���index�����̂܂ܕԂ��B
            return index.ToString();
        }

        ///// <summary>
        ///// �`�[�ԍ��擾����( PDF�̘A�ԕt�Ɏg�p )
        ///// </summary>
        ///// <param name="iSlipPrintCndtn"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //private string GetSlipNumFromCndtn( ISlipPrintCndtn iSlipPrintCndtn, int index )
        //{
        //    if ( iSlipPrintCndtn is SalesSlipPrintCndtn )
        //    {
        //        return (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[index].SalesSlipNum;
        //    }
        //    else if ( iSlipPrintCndtn is StockSlipPrintCndtn )
        //    {
        //    }
        //    else if ( iSlipPrintCndtn is StockMoveSlipPrintCndtn )
        //    {
        //        return (iSlipPrintCndtn as StockMoveSlipPrintCndtn).StockMoveSlipKeyList[index].StockMoveSlipNo.ToString( "000000000" );
        //    }
        //    else if ( iSlipPrintCndtn is EstFmPrintCndtn )
        //    {
        //        return (iSlipPrintCndtn as EstFmPrintCndtn).EstFmUnitDataList[index].FrePEstFmHead.SALESSLIPRF_SALESSLIPNUMRF.Trim();
        //    }
        //    else if ( iSlipPrintCndtn is UOESlipPrintCndtn )
        //    {
        //    }

        //    // �`�[���ɑ���������e���擾�ł��Ȃ��ꍇ�͒ʂ��ԍ��Ƃ���index�����̂܂ܕԂ��B
        //    return index.ToString();
        //}

        /// <summary>
        /// ����Ăяo��
        /// </summary>
        /// <returns></returns>
        private int CallPrint()
        {
            int status = 0;

            // �����ƃf�[�^��������W���[���ɐݒ肷��
            CallSetPrintConditionInfoAndDataMethod();
            // ������\�b�h��CALL����
            // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((_FormType == 0) && (ucePrevew.CheckState == CheckState.Checked))
            // UPD 2013/09/19 Redmine#40342�Ή� --------------------------------------------------->>>>>
            //if ((_FormType == 0) && (ucePrevew.CheckState == CheckState.Checked) && (this._isService == 0))
            if ((_FormType == 0) && (ucePrevew.CheckState == CheckState.Checked) && (this._isService == 0) && (!this.IsTablet))
            // UPD 2013/09/19 Redmine#40342�Ή� ---------------------------------------------------<<<<<
            // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                // �v���r���[�L��̏ꍇ
                // �g�嗦��ݒ肷��
                this._prtParam.ExpansionRate = 50;
                status = CallPrevewAndPrintMethod();
            }
            else
            {
                // �v���r���[�����̏ꍇ
                status = CallPrintMethod();
            }

            if (status == 0)
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Normal;
            }
            else if (CheckInvalidPrinter())
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_InvalidPrinter;
            }
            else
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_CallPrint;
            }

            // status��Ԃ�
            return status;
        }
        /// <summary>
        /// �����ȃv�����^�ݒ�̃`�F�b�N����
        /// </summary>
        /// <returns>true:�v�����^�͕s���^false:�v�����^�͐���</returns>
        private bool CheckInvalidPrinter()
        {
            // ����h�L�������g�ɐݒ肳��Ă���v�����^���̂��擾����
            string printerName;
            try
            {
                printerName = ((ISlipPrintProc)_prtObj).PrintDocument.Printer.PrinterName;

                if (printerName == string.Empty) return true;

                // �C���X�g�[���ς݃v�����^�ꗗ�Ɋ܂܂�邩�A�`�F�b�N����
                bool printerExists = false;
                foreach (string wkStr in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (wkStr.Equals(printerName))
                    {
                        printerExists = true;
                        break;
                    }
                }
                return (!printerExists);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// �o�c�e�o�͌Ăяo������
        /// </summary>
        /// <param name="slipNum">�`�[�ԍ�</param>
        private void WritePDF(string slipNum)
        {
            // �擪�f�[�^(index=0)�Œ�
            WritePDF(0, slipNum);
        }
        /// <summary>
        /// �o�c�e�o�͌Ăяo������
        /// </summary>
        /// <param name="slipIndex">�`�[�f�[�^index</param>
        /// <param name="slipNum">�`�[�ԍ�</param>
        private void WritePDF(int slipIndex, string slipNum)
        {
            if (slipIndex < this._printData.Count && this._printData[slipIndex] != null && 0 <= this._printData[slipIndex].Count)
            {
            }
            else
            {
                return;
            }

            // �t�H���_
            if (!string.IsNullOrEmpty(_dataCache.PdfOutPath))
            {
                saveFileDialog1.InitialDirectory = _dataCache.PdfOutPath;
            }

            // �ۑ��t�H���_�w���ʂ�\������
            if (!string.IsNullOrEmpty(slipNum))
            {
                saveFileDialog1.FileName = tcePrintType.Text.Trim() + slipNum + ".pdf";
            }
            else
            {
                saveFileDialog1.FileName = tcePrintType.Text.Trim() + ".pdf";
            }


            // �t�@�C���ۑ��_�C�A���O
            DialogResult dSts = this.saveFileDialog1.ShowDialog(this);

            if (dSts == DialogResult.OK)
            {
                // �����ƃf�[�^��������W���[���ɐݒ肷��
                CallSetPrintConditionInfoAndDataMethod();

                if (_FormType == 0)
                {
                    // �g�嗦��ݒ肷��
                    this._prtParam.ExpansionRate = 50;
                }
                else
                {
                    // �g�嗦��ݒ肷��
                    this._prtParam.ExpansionRate = 0;
                }
                // PDF�o��
                CallPdfPrintMethod(saveFileDialog1.FileName);
            }
        }
        # endregion �� �c�[���o�[�^�{�^���N���b�N ��

        # region �� ChangeFocus ��

        /// <summary>
        /// ArrowKeyControl�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ArrowKeyControl�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //----------------------------------------------------
            // �t�H�[�J�X�ʒu�R���g���[��
            //----------------------------------------------------
            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
            {
                switch (e.PrevCtrl.Name.Trim())
                {
                    // PDF�{�^��
                    case "ubPdf":
                        {
                            // �`�[�^�C�v�Ƀt�H�[�J�X�J��
                            e.NextCtrl = tcePrintType;
                            break;
                        }
                    // �t�H���g�X�^�C��
                    case "tceSlipFontStyle":
                        {
                            // �`�[�^�C�v�Ƀt�H�[�J�X�J��
                            e.NextCtrl = tcePrintType;
                            break;
                        }
                    // ����
                    case "tnPrintCopy":
                        {
                            if (!this.pnlBottom.Visible)
                            {
                                // �w�b�_�[��Tab�y�[�W���A�N�e�B�u
                                this.utcDetail.SelectedTab = this.utpHeader.Tab;

                                // ���ʖ������̓^�C�g���P�Ƀt�H�[�J�X�J��
                                if (tnCopyCount.Enabled)
                                {
                                    e.NextCtrl = tnCopyCount;
                                }
                                else
                                {
                                    e.NextCtrl = tceTitle1;
                                }
                            }
                            break;
                        }
                    // ���Ж���
                    case "ugbEnterpriseNamePrtCd":
                        {
                            // ���ׂ�Tab�y�[�W���A�N�e�B�u
                            this.utcDetail.SelectedTab = this.utpDetail.Tab;
                            // ���v���z�󎚋敪�Ƀt�H�[�J�X�J��
                            e.NextCtrl = uosTotalPricePrtCd;
                            break;
                        }
                    // ���v���z�󎚋敪
                    case "uosTotalPricePrtCd":
                        {
                            // ����(��)��Tab�y�[�W���A�N�e�B�u
                            this.utcDetail.SelectedTab = this.utpDetail2.Tab;
                            // ���ח�󎚋敪�Ƀt�H�[�J�X�J��
                            e.NextCtrl = utEachSlipTypeCol;
                            break;
                        }
                    // ���ח�󎚋敪
                    case "utEachSlipTypeCol":
                        {
                            // �]����Tab�y�[�W���A�N�e�B�u
                            this.utcDetail.SelectedTab = this.utpMargin.Tab;
                            // �E�v�󎚋敪�Ƀt�H�[�J�X�J��
                            e.NextCtrl = uosOutlinePrtCd;
                            break;
                        }
                    // ��s���󎚋敪
                    case "uosBankNamePrtCd":
                        {
                            // �]����Tab�y�[�W���A�N�e�B�u
                            this.utcDetail.SelectedTab = this.utpMargin.Tab;
                            // �]���i��j�Ƀt�H�[�J�X�J��
                            e.NextCtrl = tneTopMargin;
                            break;
                        }
                    // �]���i���j
                    case "tneBottomMargin":
                        {
                            // �t�H���g��Tab�y�[�W���A�N�e�B�u
                            this.utcDetail.SelectedTab = this.utpFont.Tab;
                            // �t�H���g���̂Ƀt�H�[�J�X�J��
                            e.NextCtrl = ufneSlipFontName;
                            break;
                        }
                }
            }

            //----------------------------------------------------
            // �]���ݒ�̓��͐���
            //----------------------------------------------------
            if (this.tneTopMargin.GetValue() + this.tneBottomMargin.GetValue() > 10)
            {
                if (e.PrevCtrl == tneTopMargin)
                {
                    this.tneTopMargin.SetValue(10 - this.tneBottomMargin.GetValue());
                }
                else if (e.PrevCtrl == tneBottomMargin)
                {
                    this.tneBottomMargin.SetValue(10 - this.tneTopMargin.GetValue());
                }
            }
            if (this.tneLeftMargin.GetValue() + this.tneRightMargin.GetValue() > 5)
            {
                if (e.PrevCtrl == tneLeftMargin)
                {
                    this.tneLeftMargin.SetValue(5 - this.tneRightMargin.GetValue());
                }
                else if (e.PrevCtrl == tneRightMargin)
                {
                    this.tneRightMargin.SetValue(5 - this.tneLeftMargin.GetValue());
                }
            }

            //----------------------------------------------------
            // �l�ɕύX���������Ă��邩���f
            //----------------------------------------------------
            bool ItemValueChange = false;
            if (e.PrevCtrl is TEdit)
            {
                TEdit prevEdit = (TEdit)e.PrevCtrl;
                if (prevEdit.DataText != _prevText)
                {
                    ItemValueChange = true;
                }
            }
            if (e.PrevCtrl is TComboEditor)
            {
                TComboEditor prevCombo = (TComboEditor)e.PrevCtrl;
                if (prevCombo.Text != _prevText)
                {
                    ItemValueChange = true;
                }
            }
            if (e.PrevCtrl is TNedit)
            {
                TNedit prevEdit = (TNedit)e.PrevCtrl;
                if (prevEdit.GetInt() != _prevInt)
                {
                    ItemValueChange = true;
                }
            }
            if (ItemValueChange)
            {
                EventArgs evtArg = new EventArgs();
                ItemValueChanged(sender, evtArg);
            }

            //----------------------------------------------------
            // Next�t�B�[���h�̒l��ޔ�����
            //----------------------------------------------------
            if (e.NextCtrl is TEdit)
            {
                TEdit nextEdit = (TEdit)e.NextCtrl;
                _prevText = nextEdit.DataText;
            }
            if (e.NextCtrl is TComboEditor)
            {
                TComboEditor nextCombo = (TComboEditor)e.NextCtrl;
                _prevText = nextCombo.Text;
            }
            if (e.NextCtrl is TNedit)
            {
                TNedit nextEdit = (TNedit)e.NextCtrl;
                _prevInt = nextEdit.GetInt();
            }
        }
        # endregion

        # region �� Enter / Leave ��
        /// <summary>
        /// �]���G�f�B�b�gEnter�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]���G�f�B�b�gEnter�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tneTopMargin_Enter(object sender, System.EventArgs e)
        {
            if (sender == tneTopMargin)
            {
                ulTopMark1.Visible = true;
                ulTopMark2.Visible = true;
            }
            if (sender == tneLeftMargin)
            {
                ulLeftMark1.Visible = true;
                ulLeftMark2.Visible = true;
            }
            if (sender == tneRightMargin)
            {
                ulRightMark1.Visible = true;
                ulRightMark2.Visible = true;
            }
            if (sender == tneBottomMargin)
            {
                ulBottomMark1.Visible = true;
                ulBottomMark2.Visible = true;
            }
        }

        /// <summary>
        /// �]���G�f�B�b�gLeave�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]���G�f�B�b�gLeave�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tneTopMargin_Leave(object sender, System.EventArgs e)
        {
            if (sender == tneTopMargin)
            {
                ulTopMark1.Visible = false;
                ulTopMark2.Visible = false;
            }
            if (sender == tneLeftMargin)
            {
                ulLeftMark1.Visible = false;
                ulLeftMark2.Visible = false;
            }
            if (sender == tneRightMargin)
            {
                ulRightMark1.Visible = false;
                ulRightMark2.Visible = false;
            }
            if (sender == tneBottomMargin)
            {
                ulBottomMark1.Visible = false;
                ulBottomMark2.Visible = false;
            }
        }

        /// <summary>
        /// Enter�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : Enter�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void UltraFontNameEditorEnter(object sender, System.EventArgs e)
        {
            // UltraFontNameEditor�̏ꍇ�E�E�E
            if (sender is UltraFontNameEditor)
            {
                UltraFontNameEditor Ufne = (UltraFontNameEditor)sender;
                Ufne.Appearance.BackColor = Color.FromArgb(247, 227, 156);
            }
            // UltraNumericEditor�̏ꍇ�E�E�E
            if (sender is UltraNumericEditor)
            {
                UltraNumericEditor Une = (UltraNumericEditor)sender;
                Une.Appearance.BackColor = Color.FromArgb(247, 227, 156);
                Une.SelectAll();
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : Leave�C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void UltraFontNameEditorLeave(object sender, System.EventArgs e)
        {
            // UltraFontNameEditor�̏ꍇ�E�E�E
            if (sender is UltraFontNameEditor)
            {
                UltraFontNameEditor Ufne = (UltraFontNameEditor)sender;
                Ufne.Appearance.BackColor = Color.White;
            }
            // UltraNumericEditor�̏ꍇ�E�E�E
            if (sender is UltraNumericEditor)
            {
                UltraNumericEditor Une = (UltraNumericEditor)sender;
                Une.Appearance.BackColor = Color.White;
            }
        }
        # endregion

        # region �� ��ړ��O���b�h ��
        /// <summary>
        /// ��ړ��O���b�h�������C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ړ��O���b�h�������C�x���g</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ugEachSlipTypeColMove_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.ugEachSlipTypeColMove.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCol = SelectType.SingleAutoDrag;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeRow = SelectType.None;
        }
        # endregion �� ��ړ��O���b�h ��

        # region �� �`�[�F�{�^�� ��
        /// <summary>
        /// �`�[�F�{�^���N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�[�F�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ubSlipColor_Click(object sender, System.EventArgs e)
        {
            // ��ʕ`�撆�́Aexit
            if ((string)utcDetail.Tag == ctFormDrawingNow)
            {
                return;
            }

            Infragistics.Win.Misc.UltraButton wkUltraButton
                = sender as Infragistics.Win.Misc.UltraButton;
            if (wkUltraButton != null)
            {
                Infragistics.Win.Misc.UltraLabel wkUltraLabel = null;
                string wkStr = "ulSlipColorT" + wkUltraButton.Tag.ToString().Trim();
                // �^�C�g����UltraGroupBox����N���b�N���ꂽButton�Ƒ΂ɂȂ�Label���擾
                for (int ix = 0; ix != ugbTitle.Controls.Count; ix++)
                {
                    if (ugbTitle.Controls[ix].Name.Equals(wkStr))
                    {
                        wkUltraLabel = ugbTitle.Controls[ix] as Infragistics.Win.Misc.UltraLabel;
                        break;
                    }
                }
                if (wkUltraLabel != null)
                {
                    colorDialog1.Color
                        = Color.FromArgb(wkUltraLabel.Appearance.BackColor.R, wkUltraLabel.Appearance.BackColor.G, wkUltraLabel.Appearance.BackColor.B);
                    switch (colorDialog1.ShowDialog())
                    {
                        case DialogResult.OK:
                            {
                                if (!wkUltraLabel.Appearance.BackColor.Equals(colorDialog1.Color))
                                {
                                    wkUltraLabel.Appearance.BackColor = colorDialog1.Color;

                                    // ���ύX�C�x���g���N������˃v���r���[�̍ĕ`��
                                    System.EventArgs EvtArg = new EventArgs();
                                    ItemValueChanged(sender, EvtArg);
                                }
                                break;
                            }
                        default:
                            {
                                wkUltraButton.Focus();
                                break;
                            }
                    }
                }
            }
        }
        # endregion �� �`�[�F�{�^�� ��

        # region �� �`�[�^�C�g��NotInList ��
        /// <summary>
        /// �^�C�g������ItemNotInList�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�C�g���̃R���{�{�b�N�X�ɂ�ItemList�ɑ��݂��Ȃ��l�����͂��ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tceTitle_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
        # endregion �� �`�[�^�C�g��NotInList ��

        # region �� �L�[�_�E�� ��
        /// <summary>
        /// �t�H�[���L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[����ŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void DCCMN02000UA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ToolClickEventArgs ev = new ToolClickEventArgs(utmMain.Tools["Cancel"], new ListToolItem());
                utmMain_ToolClick(sender, ev);
            }
        }
        # endregion �� �L�[�_�E�� ��

        # endregion

        //==================================================================================
        // public���\�b�h��`
        //==================================================================================
        # region �� public���\�b�h ��

        # region �� ����m�F ��
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin

        /// <summary>
        /// ����m�F��ʕ\��(�����[�g�`�[���s)
        /// </summary>
        /// <param name="iSlipPrintCndtn">�`�[�������</param>
        /// <param name="printData">������f�[�^</param>
        /// <param name="printWithoutDialog">�m�F�_�C�A���O�\�������t���O</param>
        /// <param name="rmSlpPrtStWork">�����[�g�`���ݒ�}�X�^</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>�`�[����m�F��ʂ�\�����܂��B</br>
        /// <br>printWithoutDialog = true �̏ꍇ�͉�ʕ\�������ɒ��ڈ���������s���܂��B</br>
        /// </remarks>
        public void ShowDialog(ISlipPrintCndtn iSlipPrintCndtn, List<ArrayList> printData, bool printWithoutDialog, RmSlpPrtStWork rmSlpPrtStWork)
        {
            this._rmSlpPrtStWork = rmSlpPrtStWork;
            ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

        }

        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        /// <summary>
        /// ����m�F��ʕ\��
        /// </summary>
        /// <param name="iSlipPrintCndtn">�`�[�������</param>
        /// <param name="printData">������f�[�^</param>
        /// <param name="printWithoutDialog">�m�F�_�C�A���O�\�������t���O</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>�`�[����m�F��ʂ�\�����܂��B</br>
        /// <br>printWithoutDialog = true �̏ꍇ�͉�ʕ\�������ɒ��ڈ���������s���܂��B</br>
        /// </remarks>
        public void ShowDialog(ISlipPrintCndtn iSlipPrintCndtn, List<ArrayList> printData, bool printWithoutDialog)
        {
            // �_�C�A���O�Ȃ�����敪�擾
            _printWithoutDialog = printWithoutDialog;

            // ������f�[�^
            _printData = printData;

            // ����O���������s���A�����Ȃ�Έ������
            if (PrintMainInitial(iSlipPrintCndtn))
            {
                if (_printWithoutDialog)
                {
                    //----------------------------------------
                    // �_�C�A���O�Ȃ����
                    //----------------------------------------
                    // ����Ăяo��
                    PrintMain();
                }
                else
                {
                    // ---------- ADD 2014/07/30 杍^ Redmine#43082�u��Q�ꗗNo.10664�v --------- >>>
                    // ��Q���ہF�u���Ӑ�d�q��������ԓ`�𔭍s����Ɗm�F�_�C�A���O���Q��\���i���`���Q�����j����A�����`���o�͂���Ȃ��v��Q�̑Ή��B
                    // ��Q�����F�ȑO�����[�g�`�������d�l��ǉ����A_printWithoutDialog��True�̏ꍇ�A�����[�g�`�������d�l��ǉ����܂����B
                    //           �������A_printWithoutDialog��False�̏ꍇ�A�����[�g�`�������d�l���R��Ǝv���܂��B����A�Ή����܂��B

                    // _IsRmSlpPrt��True�̏ꍇ�A�����[�g�`���������܂��u�_�C�A���O�Ȃ��v�B
                    if (_IsRmSlpPrt)
                    {
                        // PrintMain���\�b�h�́A_IsRmSlpPrt��False�̏ꍇ�A�`�[����������܂��B
                        // PrintMain���\�b�h�́A_IsRmSlpPrt��True�̏ꍇ�A�����[�g�`���������܂��B
                        PrintMain();
                    }
                    // _IsRmSlpPrt��False�̏ꍇ�A���A_printWithoutDialog��False�̏ꍇ�A �_�C�A���O�\����,����{�^���ň�����܂��B
                    else
                    {
                    // ---------- ADD 2014/07/30 杍^ Redmine#43082�u��Q�ꗗNo.10664�v --------- <<<

                        //----------------------------------------
                        // �_�C�A���O�������m�F
                        //----------------------------------------
                        // �_�C�A���O�\����,����{�^���ň��(������O�ɓ`�[�X�V����)
                        DialogResult dialogResult = base.ShowDialog();
                        if (dialogResult == DialogResult.Cancel)
                        {
                            _slipPrintDialogState = SlipPrintDialogStatus.Cancel;
                        }

                    }  // ADD 2014/07/30 杍^ Redmine#43082�u��Q�ꗗNo.10664�v
                }
            }
            else
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_Initialize;
            }
        }

        # endregion �� ����m�F ��

        // ADD 2013/10/30 SCM�d�|�ꗗ��10614�Ή� ------------------------------------->>>>>
        /// <summary>
        /// �L���b�V���N���A
        /// </summary>
        /// <remarks>
        /// <br>�`�[����m�F��ʂ̃L���b�V���N���A���s���܂��B</br>
        /// </remarks>
        public void Clear()
        {
            if (this._slipPrintAcs != null) this._slipPrintAcs = null;
            if (this._scmRtPrtDtAcs != null) this._scmRtPrtDtAcs = null;
            if (this._pccCmpnyStAcs != null) this._pccCmpnyStAcs = null;
            if (this._pccTtlStAcs != null) this._pccTtlStAcs = null;
            if (this._dataCache != null) this._dataCache = null;
            if (this._printData != null) this._printData = null;
            if (this._prtObj != null) this._prtObj = null;
            if (this._slipPrintAssemblyFrom != null)
            {
                this._slipPrintAssemblyFrom.Dispose();
                this._slipPrintAssemblyFrom = null;
            }
            if (this._slipPrintAcs != null) this._slipPrtSet = null;
        }
        // ADD 2013/10/30 SCM�d�|�ꗗ��10614�Ή� -------------------------------------<<<<<

        # endregion �� public���\�b�h ��

        //==================================================================================
        // private���\�b�h��`
        //==================================================================================
        # region �� private���\�b�h ��

        # region �� ����m�F�t�h���C������ ��
        /// <summary>
        /// ������C������initialize
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <returns>true:�������� / false:�������s</returns>
        /// <remarks>��������������s���܂��B�i�֘A�}�X�^�ǂݍ��݂ƈ���f�[�^�擾�܂Łj</remarks>
        private bool PrintMainInitial(object iSlipPrintCndtn)
        {
            //----------------------------------------------
            // �`�[�����ʎ擾
            //----------------------------------------------
            if (GetSlipKind(out _slipKind, iSlipPrintCndtn) == false)
            {
                return false;
            }
            this._iSlipPrintCndtn = (ISlipPrintCndtn)iSlipPrintCndtn;

            //----------------------------------------------
            // ���������E����f�[�^�擾����
            //----------------------------------------------
            if (InitProcOnShow() != 0)
            {
                // �f�[�^�擾�ŃG���[�����������ꍇ�A�Y���f�[�^�������ꍇ�͏I��
                return false;
            }

            return true;
        }

        /// <summary>
        /// ����m�F�t�h���C������
        /// </summary>
        /// <remarks>
        /// <br>���̏����́A�Ăяo�����A�Z���u������̃p�����[�^�w��ɂ���ẮA</br>
        /// <br>�ʃX���b�h�Ŏ��s�����\��������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PrintMain()
        {
            // update by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            // ����Ăяo��
            //if ( CallPrint() == 0 )
            //{
            //    this.DialogResult = DialogResult.OK;
            //    this.Hide();
            //}            
            int status = 0;
            bool execPrint = true;
            bool execRemotePrint = true;
            // �ʏ�̓`�[�����������
            if (_IsRmSlpPrt || CheckSlipPrint() == false) execPrint = false;
            // �����[�g�`�[�����������
            if (!_IsRmSlpPrt || CheckRemoteSlipPrint() == false) execRemotePrint = false;

            // �ʏ�̓`�[���
            if (execPrint)
            {
                status = CallPrint();
            }

            if (status == 0)
            {
                // �����[�g�`���Ăяo��
                if (execRemotePrint)
                {
                    CallRemoteSlipPrint();
                }

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            // update by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        }

        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// SCM�����[�g�`�[����f�[�^���쐬����
        /// </summary>
        private void CallRemoteSlipPrint()
        {
            // �����ƃf�[�^��������W���[���ɐݒ肷��
            CallSetPrintConditionInfoAndDataMethod();

            // ���DLL���Ăяo��
            int status = ((ISlipPrintProc)_prtObj).StartPreview(this);
            string errMsg = null;
            if (status == 0)
            {
                // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                _scmRtPrtDtAcs.PrintDataList = PrintDataList;
                // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                //SCM�����[�g�`�[����f�[�^���쐬����
                //status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, out errMsg);//DEL 2013/06/17 zhubj FOR Redmine #36594
                //status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, _isOnlyOneSlip, _isLastSlip, out errMsg);//ADD 2013/06/17 zhubj FOR Redmine #36594//DEL 2013/07/28 zhubj FOR Redmine #36594
                // UPD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                //status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, _isOnlyOneSlip, _isLastSlip, _isKeyChangeFlag, out errMsg);//ADD 2013/07/28 zhubj FOR Redmine #36594
                status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, _isOnlyOneSlip, _isLastSlip, _isKeyChangeFlag, _slipNumlist, _inquiryNumList, out errMsg);
                PrintDataList = _scmRtPrtDtAcs.PrintDataList;
                // UPD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
            }

            if (status == 0)
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Normal;
            }
            else
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_CallPrint;
            }
        }

        /// <summary>
        /// �`�[���s�`�F�b�N
        /// </summary>
        /// <returns>�`�[���s�`�F�b�N����</returns>
        private bool CheckSlipPrint()
        {
            int status = -1;
            SCMTtlStAcs scmTtlStAcs;
            SCMTtlSt scmTtlSt;

            //add start by liusy 2011/09/27 #25559 --------->>>>>>>
            //////////////////////////////////////////////////////////////
            //�o�b�b�S�̐ݒ���Q�Ƃ���
            //////////////////////////////////////////////////////////////
            List<PccTtlSt> pccTtlStList;
            PccTtlSt parsePccTtlSt;
            PccTtlSt pccTtlSt;
            int retTotalCnt = 0;
            int readMode = 0;
            int readCnt = 0;
            //add end by liusy 2011/09/27 #25559 --------->>>>>>>

            //add start by wangqx 2011/10/17 #25559 --------->>>>>>>
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = this._printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            // ���㖾�׃f�[�^���[�N
            //>>>2011/10/19
            //FrePSalesDetailWork salesDetailWork = salesDetailWork = frePSalesDetailWorkList[0];

            FrePSalesDetailWork salesDetailWork = null;
            if ((frePSalesDetailWorkList != null) && (frePSalesDetailWorkList.Count != 0))
            {
                salesDetailWork = frePSalesDetailWorkList[0];
            }
            //<<<2011/10/19
            //add end by liusy 2011/10/17 #25559 ---------<<<<<<<
            
            if (_isAutoAns == 1)
            {
                scmTtlStAcs = new SCMTtlStAcs();
                scmTtlSt = new SCMTtlSt();
                //�Y�����_�̂o�b�b�S�̐ݒ���擾����
                status = scmTtlStAcs.Read(out scmTtlSt, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd());
                if (status != 0)
                {
                    return false;
                }
                //PCC�S�̐ݒ�ɊY������
                if (null != scmTtlSt)
                {
                    //add start by wangqx 2011/10/17 #25559 --------->>>>>>>
                    //SCM�̏ꍇ�APCC�S�̐ݒ���`�B�b�N����
                    //>>>2011/10/19
                    //if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0)
                    if ((salesDetailWork != null) && (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0))
                    //<<<2011/10/19
                    {
                    //add end by liusy 2011/10/17 #25559 ---------<<<<<<<
                        //��
                        if (_slipKind == 120)
                        {
                            //PCC�S�̐ݒ�.�󒍓`�[���s�敪==0:���Ȃ�
                            if (scmTtlSt.AcpOdrrSlipPrtDiv == 0)
                            {
                                return false;
                            }
                        }
                        //����
                        else if (_slipKind == 30)
                        {
                            //PCC�S�̐ݒ�.����`�[���s�敪==0:���Ȃ�
                            if (scmTtlSt.SalesSlipPrtDiv == 0)
                            {
                                return false;
                            }
                        }
                    }//add 2011/10/17 
                }
                
                //add start by wangqx 2011/10/13 #25559 --------->>>>>>>
                SalesTtlStWork SalesTtlStWork = this.GetSalesTtlSt();
                //delete start by wangqx 2011/10/15 #25559 --------->>>>>>>
                //// BL�߰µ��ް�S�̐ݒ�.����`�[���s�敪�����Ȃ��̏ꍇ�A�����񓚎���PM���ł̓`�[����ł��Ȃ�
                //if (((SalesSlipPrintCndtn)this._iSlipPrintCndtn).SCMTotalSettingSalesSlipPrtDiv == 0)
                //{
                //    //SCM�S�̐ݒ�.����`�[����t���O�F0 ������Ȃ�
                //    return false;
                //}
                //delete end by wangqx 2011/10/15 #25559 ---------<<<<<<<
                //add end by wangqx 2011/10/13 #25559---------<<<<<<<

                //add start by liusy 2011/09/27 #25559 --------->>>>>>>
                parsePccTtlSt = new PccTtlSt();
                parsePccTtlSt.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                parsePccTtlSt.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                pccTtlStList = new List<PccTtlSt>();
                pccTtlSt = null;
                //�Y�����_�̂o�b�b�S�̐ݒ���擾����
                _pccTtlStAcs.Search(ref pccTtlStList, parsePccTtlSt, out retTotalCnt, readMode, readCnt, ConstantManagement.LogicalMode.GetData0);

                if (null != pccTtlStList && pccTtlStList.Count > 0)
                {
                    pccTtlSt = pccTtlStList[0];
                }
                //PCC�S�̐ݒ�ɊY������
                if (null != pccTtlSt)
                {
                    //��
                    if (_slipKind == 120)
                    {
                        //PCC�S�̐ݒ�.�󒍓`�[���s�敪==0:���Ȃ�
                        if (pccTtlSt.AcpOdrrSlipPrtDiv == 0)
                        {
                            return false;
                        }
                    }
                    //delete start by wangqx 2011/10/11 #25559 --------->>>>>>>
                    ////����
                    //else if (_slipKind == 30)
                    //{
                    //    //PCC�S�̐ݒ�.����`�[���s�敪==0:���Ȃ�
                    //    if (pccTtlSt.SalesSlipPrtDiv == 0)
                    //    {
                    //        return false;
                    //    }
                    //}
                    //delete end by wangqx 2011/10/11 #25559 ---------<<<<<<<
                    //add start by wangqx 2011/10/15 #25559 --------->>>>>>>
                    //����
                    else if (_slipKind == 30)
                    {
                        //add start by wangqx 2011/10/17 #25559 --------->>>>>>>
                        //PCCUOE�̏ꍇ�ABL�߰µ��ް�S�̐ݒ�.����`�[���s�敪���`�B�b�N����
                        //>>>2011/10/19
                        //if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 1)
                        if ((salesDetailWork != null) && (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 1))
                        //<<<2011/10/19
                        {
                            //add end by liusy 2011/10/17 #25559 ---------<<<<<<<
                            // BL�߰µ��ް�S�̐ݒ�.����`�[���s�敪�����Ȃ��̏ꍇ�A�����񓚎���PM���ł̓`�[����ł��Ȃ�
                            if (pccTtlSt.SalesSlipPrtDiv == 0)
                            {
                                return false;
                            }
                        }//add 2011/10/17 
                    }
                    //add end by wangqx 2011/10/15 #25559 ---------<<<<<<<
                }
                //add end by liusy 2011/09/27 #25559 --------->>>>>>>

                //add start by wangqx 2011/09/30 #25559 No.2 --------->>>>>>>
                List<ArrayList> printDataWk = _printData;
                FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                
                // ���Ӑ�}�X�^����擾
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo;
                int flg = customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, out customerInfo);

                if (flg == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
                {
                    // �[�i���o�͐ݒ�`�F�b�N
                    if (customerInfo.SalesSlipPrtDiv == 1 && _slipKind == 30)
                    {
                        // 1:���g�p�̏ꍇ
                        return false;
                    }
                    //add start by wangqx 2011/10/11 #25559 --------->>>>>>>
                    else if (customerInfo.SalesSlipPrtDiv == 0)
                    {
                        // 0:�W���̏ꍇ
                        // PCC�S�̐ݒ�.����`�[���s�敪���`�F�b�N����
                        // PCC�S�̐ݒ�ɊY������
                        if (null != pccTtlSt)
                        {
                            //����
                            if (_slipKind == 30)
                            {
                                //PCC�S�̐ݒ�.����`�[���s�敪==1:���Ȃ�
                                if (SalesTtlStWork.SalesSlipPrtDiv == 1)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    //add end by wangqx 2011/10/11 #25559---------<<<<<<<
                }
                //add start by wangqx 2011/10/11 #25559 --------->>>>>>>
                else
                {
                    // PCC�S�̐ݒ�.����`�[���s�敪���`�F�b�N����
                    // PCC�S�̐ݒ�ɊY������
                    if (null != pccTtlSt)
                    {
                        //����
                        if (_slipKind == 30)
                        {
                            //PCC�S�̐ݒ�.����`�[���s�敪==1:���Ȃ�
                            if (SalesTtlStWork.SalesSlipPrtDiv == 1)
                            {
                                return false;
                            }
                        }
                    }
                }
                //add end by wangqx 2011/10/11 #25559---------<<<<<<<
                //add end by wangqx 2011/09/30 #25559 No.2 ---------<<<<<<<
            }

            return true;
        }

        /// <summary>
        /// �����[�g�`�[���s�`�F�b�N
        /// </summary>
        /// <returns>�����[�g�`�[���s�`�F�b�N����</returns>
        private bool CheckRemoteSlipPrint()
        {

            /*del start by liusy 2011/09/27 #25559 --------->>>>>>>
            //////////////////////////////////////////////////////////////
            //�o�b�b�S�̐ݒ���Q�Ƃ���
            //////////////////////////////////////////////////////////////
            List<PccTtlSt> pccTtlStList;
            PccTtlSt parsePccTtlSt;
            PccTtlSt pccTtlSt;
            int retTotalCnt = 0;
            int readMode = 0;
            int readCnt = 0;

            if (_isAutoAns == 1)
            {
                parsePccTtlSt = new PccTtlSt();
                parsePccTtlSt.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                parsePccTtlSt.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                pccTtlStList = new List<PccTtlSt>();
                pccTtlSt = null;
                //�Y�����_�̂o�b�b�S�̐ݒ���擾����
                _pccTtlStAcs.Search(ref pccTtlStList, parsePccTtlSt, out retTotalCnt, readMode, readCnt, ConstantManagement.LogicalMode.GetData0);

                if (null != pccTtlStList && pccTtlStList.Count > 0)
                {
                    pccTtlSt = pccTtlStList[0];
                }
                //PCC�S�̐ݒ�ɊY������
                if (null != pccTtlSt)
                {
                    //��
                    if (_slipKind == 120)
                    {
                        //PCC�S�̐ݒ�.�󒍓`�[���s�敪==0:���Ȃ�
                        if (pccTtlSt.AcpOdrrSlipPrtDiv == 0)
                        {
                            return false;
                        }
                    }
                    //����
                    else if (_slipKind == 30)
                    {
                        //PCC�S�̐ݒ�.����`�[���s�敪==0:���Ȃ�
                        if (pccTtlSt.SalesSlipPrtDiv == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            /*del end by liusy 2011/09/27 #25559 ---------<<<<<<< */
             
            //////////////////////////////////////////////////////////////
            //�o�b�b���Аݒ���Q�Ƃ���
            //////////////////////////////////////////////////////////////
            PccCmpnySt parsePccCmpnySt;
            PccCmpnySt pccCmpnySt;
            //�`�[�敪�F���� 
            if (_slipKind == 30)
            {
                // ���Ӑ�K�C�h������
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                Broadleaf.Application.UIData.CustomerInfo customerInfo;
                //����f�[�^
                List<ArrayList> printDataWk = _printData;
                FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, true, out customerInfo);
                // -- DEL 2011/09/28   ------ >>>>>>
                ////�ԓ`�̏ꍇ�͈�����Ȃ�
                //if (slipWork.SALESSLIPRF_DEBITNOTEDIVRF == 1)
                //{
                //    return false;
                //}
                // -- DEL 2011/09/28   ------ <<<<<<
                parsePccCmpnySt = new PccCmpnySt();
                //�⍇������ƃR�[�h
                parsePccCmpnySt.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                //�⍇�������_�R�[�h
                parsePccCmpnySt.InqOriginalSecCd = customerInfo.CustomerSecCode;
                //�⍇�����ƃR�[�h
                parsePccCmpnySt.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                //�⍇���拒�_�R�[�h
                parsePccCmpnySt.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

                _pccCmpnyStAcs.Read(ref parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
                //PCC���Аݒ�ɊY������
                if (null != parsePccCmpnySt)
                {
                    pccCmpnySt = parsePccCmpnySt;
                    if (_isAutoAns == 1)
                    {
                        //PCC���Аݒ�.�`�[���s�敪!=1:�� && PCC���Аݒ�.�`�[���s�敪!=3:����
                        if (pccCmpnySt.PccSlipPrtDiv != 1 && pccCmpnySt.PccSlipPrtDiv != 3)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        //PCC���Аݒ�.�`�[���s�敪!=2:�����[�g && PCC���Аݒ�.�`�[���s�敪!=3:���� 
                        if (pccCmpnySt.PccSlipPrtDiv != 2 && pccCmpnySt.PccSlipPrtDiv != 3)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

        /// <summary>
        /// �`�[�����ʎ擾����
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="iSlipPrintCndtn"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>�`�[�����ʂ��擾���܂��B�`�[����m�F�t�h�őI���\�ȓ`�[�^�C�v�́A���̓`�[�����ʂɈˑ����܂��B</br>
        /// </remarks>
        private bool GetSlipKind(out int slipKind, object iSlipPrintCndtn)
        {
            slipKind = 0;

            // �����Ƃ��ēn���ꂽ�N���X�𔻒�
            // ( 10:���Ϗ�,30:�[�i��,40:�ԕi�`�[,120:�󒍓`�[,130:�o�ד`�[,140:���ϓ`�[,150:�݌Ɉړ��`�[,160:UOE�`�[)
            if (iSlipPrintCndtn is SalesSlipPrintCndtn)
            {
                // << ���� >>
                //if ( (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[0].AcptAnOdrStatus == 10 )
                //{
                //    // 10:���Ϗ����C�A�E�g
                //    slipKind = 10;
                //}
                //else
                //{
                //    // 30:�[�i�����C�A�E�g
                //    slipKind = 30;
                //}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/16 DEL
                //slipKind = (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[0].AcptAnOdrStatus;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/16 ADD

                //switch ( (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[0].AcptAnOdrStatus )

                if (_printData != null && _printData.Count > 0 &&
                    _printData[0] != null && _printData[0].Count > 0)
                {
                    switch ((_printData[0][0] as FrePSalesSlipWork).SALESSLIPRF_ACPTANODRSTATUSRF)
                    {
                        case 10:
                            slipKind = 140; // ���ϓ`�[
                            break;
                        case 20:
                            slipKind = 120; // �󒍓`�[
                            break;
                        case 40:
                            slipKind = 130; // �ݏo�`�[
                            break;
                        case 30:
                        default:
                            slipKind = 30; // ����`�[
                            break;
                    }
                }
                else
                {
                    // ��O�I�ȃP�[�X�̏ꍇ�̓f�t�H���g��30:����`�[�Ƃ���
                    slipKind = 30;
                }

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/16 ADD
                // �Ĕ��s�敪
                _slipPrintParameter.ReissueDiv = (iSlipPrintCndtn as SalesSlipPrintCndtn).ReissueDiv;
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                // QR�쐬�敪
                _slipPrintParameter.MakeQRDiv = (iSlipPrintCndtn as SalesSlipPrintCndtn).MakeQRDiv;
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            }
            else if (iSlipPrintCndtn is StockSlipPrintCndtn)
            {
                // << �d�� >>
                // 40:�d���ԕi�`�[���C�A�E�g                
                slipKind = 40;

                // �Ĕ��s�敪�����g�p�Ȃ̂�false
                _slipPrintParameter.ReissueDiv = false;
            }
            else if (iSlipPrintCndtn is StockMoveSlipPrintCndtn)
            {
                // << �݌Ɉړ� >>
                // 150:�݌Ɉړ����C�A�E�g
                slipKind = 150;

                // �Ĕ��s�敪
                _slipPrintParameter.ReissueDiv = (iSlipPrintCndtn as StockMoveSlipPrintCndtn).ReissueDiv;
            }
            else if (iSlipPrintCndtn is EstFmPrintCndtn)
            {
                // << ���Ϗ� >>
                // 10:���Ϗ����C�A�E�g
                slipKind = 10;

                // �Ĕ��s�敪�����g�p�Ȃ̂�false
                _slipPrintParameter.ReissueDiv = false;
            }
            else if (iSlipPrintCndtn is UOESlipPrintCndtn)
            {
                // << �t�n�d�`�[ >>
                // 160:�t�n�d�`�[���C�A�E�g
                slipKind = 160;

                // �Ĕ��s�敪�����g�p�Ȃ̂�false
                _slipPrintParameter.ReissueDiv = false;
            }
            else
            {
                // ���̑��̃N���X��n���ꂽ���̓G���[�I��
                return false;
            }

            return true;
        }
        # endregion �� ����m�F�t�h���C������ ��

        # region �� �\����������������уf�[�^�擾 ��
        /// <summary>
        /// �\����������������уf�[�^�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���������������s���܂��B�����[�g�g�p�ɂ�����f�[�^�擾���s���܂��B</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int InitProcOnShow()
        {
            //******************************************************
            // ���ӁF�@�ȉ��ł́A��ʂȂ�����^��ʂ���@���ʂ�
            //         �K�v�ȏ����݂̂��L�q���܂��B
            //         ��ʂ���̏ꍇ�̂ݕK�v�ȏ����́ADCCMN02000UB_Load
            //         �ɋL�ڂ��܂��B
            //         ( ��ʂȂ����������������� )
            //******************************************************

            // ����v���r���[�p�p�����[�^�N���X
            _prtParam = new SFMIT01290UB();
            _FormType = 0; // �ȈՔ�

            //------------------------------------------------------
            // ��ʂ̏����l��ݒ肷��
            //------------------------------------------------------
            # region [��ʂ̏����l��ݒ肷��]
            // ����͈́i�S�āj
            uosPrintRange.Value = 1;
            // PDF�p�Z�[�u�_�C�A���O�̏����t�H���_�ݒ�
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            # endregion

            //------------------------------------------------------
            // �v�����^���R���{�{�b�N�X��ݒ�
            //------------------------------------------------------
            # region [�v�����^�ꗗ]
            tcePrinterName.Items.Clear();

            List<PrtManage> prtManageList = _slipPrintAcs.SearchAllPrtManage(_enterpriseCode);
            foreach (PrtManage itm in prtManageList)
            {
                if (itm.LogicalDeleteCode == 0)
                {
                    tcePrinterName.Items.Add(itm.PrinterMngNo, itm.PrinterName);
                }
            }
            # endregion

            //------------------------------------------------------
            // �`�[���R���{�{�b�N�X��ݒ�
            //------------------------------------------------------
            # region [�`�[�^�C�v�ꗗ]
            // �`�[����ݒ�f�B�N�V���i���擾
            int defaultValue = 0;
            int printerMngNo = 0;
            Dictionary<int, string> slipPrintTypeDic = _slipPrintAcs.GetSlipPrintTypeList(_slipKind, _printData, out defaultValue, out printerMngNo);

            // �R���{�{�b�N�X�ɓW�J
            tcePrintType.Items.Clear();
            foreach (int typeSeqNo in slipPrintTypeDic.Keys)
            {
                tcePrintType.Items.Add(typeSeqNo, slipPrintTypeDic[typeSeqNo]);
            }

            // �`�[�^�C�v��I����Ԃɂ���i���`�[�^�C�v��ValueChange�C�x���g�ŉ�ʕ\���j
            tcePrintType.Value = defaultValue;
            if (tcePrintType.Value == null && tcePrintType.Items != null && tcePrintType.Items.Count > 0)
            {
                tcePrintType.SelectedIndex = 0;
            }
            tcePrinterName.Value = printerMngNo;
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            // �m�F��ʕ\���̏ꍇ
            if (_printWithoutDialog == false)
            {
                Assembly myAssembly = Assembly.GetEntryAssembly();
                string sPgid = System.IO.Path.GetFileNameWithoutExtension(myAssembly.Location);
                // �N����PG�����Ӑ�d�q�����̏ꍇ�A�Ǘ������P�̃v�����^�������\������B
                if (sPgid == ctPGID_PMKAU04000U)
                {
                    tcePrinterName.Value = 1;
                }
            }
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
            if (tcePrinterName.Value == null && tcePrinterName.Items != null && tcePrinterName.Items.Count > 0)
            {
                tcePrinterName.SelectedIndex = 0;
            }

            # endregion

            //------------------------------------------------------
            // �f�[�^�N���X�O�̈�����䍀�ڂ�ݒ�
            //------------------------------------------------------
            # region [�f�[�^�N���X�O�̈�����䍀��]
            _slipPrintParameter.SlipDatePrintDiv = 1;   // ���t�󎚗L�� 1:����
            _slipPrintParameter.TotalPricePrtCd = 0;    // ���v���z�� 0:�S�y�[�W
            # endregion

            return 0;
        }
        # endregion �� �\����������������уf�[�^�擾 ��

        # region �� �A�Z���u���E���[�h ��
        // update by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        ///// <summary>
        ///// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        ///// </summary>
        ///// <param name="asmname">�A�Z���u������</param>
        ///// <param name="classname">�N���X����</param>
        ///// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        //private object LoadAssemblyFrom(string asmname, string classname)
        /// <summary>
        /// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="outputFormFileName">�o�͒��[�t�H�[����</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        private object LoadAssemblyFrom(string asmname, string classname, string outputFormFileName)
        // update by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        {
            object obj = null;
            try
            {
                //************************************************************
                // ������̓`�[����A�Z���u�����ݒ肳��Ă���ꍇ�A
                //   ���ڃC���X�^���X�������鎖�ŏ������x�����}��܂��B
                //
                //   �A���A���t���N�V�����ɂ�鏈�����c���A�g�����͈ێ����܂��B
                //   �A�Z���u�����[�h���ԒZ�k�ׁ̈A����`�[�A���Ϗ��ȊO��
                //   ���t���N�V�����ŌĂяo���܂��B
                //************************************************************
                switch (asmname)
                {
                    case "PMHNB08001P":
                        {
                            //------------------------------------------------
                            // ���R���[(����`�[)���
                            //------------------------------------------------
                            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                            //// 2010/08/30 Add >>>
                            //if (Broadleaf.Drawing.Printing.PMHNB08001PCA.CustomizeFlg)
                            //    obj = new Broadleaf.Drawing.Printing.PMHNB08001PCA();
                            //else
                            //    // 2010/08/30 Add <<<
                            //    obj = new Broadleaf.Drawing.Printing.PMHNB08001PA();
                            if (!Broadleaf.Drawing.Printing.PMHNB08001PCA.CustomizeFlg || Broadleaf.Drawing.Printing.PMHNB08001PA.IsPackage(outputFormFileName))
                            {
                                obj = new Broadleaf.Drawing.Printing.PMHNB08001PA();
                            }
                            else
                            {
                                obj = new Broadleaf.Drawing.Printing.PMHNB08001PCA();
                            }
                            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

                        }
                        break;
                    case "PMMIT08001P":
                        {
                            //------------------------------------------------
                            // ���R���[(���Ϗ�)���
                            //------------------------------------------------
                            obj = new Broadleaf.Drawing.Printing.PMMIT08001PA();
                        }
                        break;
                    default:
                        {
                            //------------------------------------------------
                            // ���t���N�V�����ɂ��C���X�^���X����
                            //------------------------------------------------
                            System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                            Type objType = asm.GetType(classname);
                            if (objType != null)
                            {
                                obj = Activator.CreateInstance(objType);
                            }
                        }
                        break;
                }

                //// ����C���^�t�F�[�X���s�`�F�b�N
                //Type PrintIF = obj.GetType().GetInterface( typeof( ISlipPrintProc ).Name );
                //if ( PrintIF == null || PrintIF.Name != "ISlipPrintProc" )
                //{
                //    throw new Exception( "������i�̐����Ɏ��s���܂����B" );
                //}
            }
            catch (FileNotFoundException ex)
            {
                // �ΏۃA�Z���u���Ȃ��i�x��)
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "�`�[����m�F���"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_CALL
                    , ex.Message
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                // �ΏۃA�Z���u���Ȃ��i�x��)
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "�`�[����m�F���"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_CALL
                    , ex.Message + "\n\r" + ex.StackTrace
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
            return obj;
        }
        # endregion �� �A�Z���u���E���[�h ��

        # region �� �A�Z���u���E����f�[�^�ݒ胁�\�b�h�Ăяo�� ��
        /// <summary>
        /// ��������E����f�[�^�ݒ胁�\�b�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��������E����f�[�^�ݒ胁�\�b�h�N������</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallSetPrintConditionInfoAndDataMethod()
        {
            SlipPrintConditionInfo slipPrintConditionInfo = new SlipPrintConditionInfo();
            // ��ʒl���擾����
            GetSlipPrtSetFromDisplay(ref slipPrintConditionInfo, ref _slipPrtSet);

            // �����ݒ�
            ArrayList ConditionInfo = new ArrayList();

            # region [���ʂ̐ݒ�]
            // �`�[����ݒ�
            if (_slipPrtSet != null)
            {
                ConditionInfo.Add(_slipPrtSet);

                // ���R���[�󎚈ʒu�ݒ�
                FrePrtPSetWork frePrtPSet = _slipPrintAcs.GetFrePrtPSet(_slipPrtSet);
                if (frePrtPSet != null)
                {
                    ConditionInfo.Add(frePrtPSet);
                }
            }
            else
            {
                ConditionInfo.Add(new SlipPrtSetWork());
            }
            // �`�[����p�����[�^
            ConditionInfo.Add(_slipPrintParameter.ToDictionary());

            // --- ADD m.suzuki 2010/05/14 ---------->>>>>
            // ���R���[�󎚈ʒu�ݒ�f�B�N�V���i��
            ConditionInfo.Add(_slipPrintAcs.GetFrePrtPSetDic());
            // �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i��
            ConditionInfo.Add(_slipPrintAcs.GetDecryptedFrePrtPSetDic());
            // --- ADD m.suzuki 2010/05/14 ----------<<<<<
            # endregion

            # region [�`�[�^�C�v�ʂ̐ݒ�]
            if (_iSlipPrintCndtn is SalesSlipPrintCndtn)
            {
                //---------------------------------------------
                // ����`�[
                //---------------------------------------------
                // �S�̏����\���ݒ�
                ConditionInfo.Add(this.GetAllDefSt());
                // ����S�̐ݒ�
                ConditionInfo.Add(this.GetSalesTtlSt());
                // --- ADD  ���r��  2010/03/04 ---------->>>>>
                //�ŗ��ݒ�
                ConditionInfo.Add(this.GetTaxRateSt());
                //������z�����敪�ݒ�
                ConditionInfo.Add(this.GetsalesProcMn());
                // --- ADD  ���r��  2010/03/04 ----------<<<<<
            }
            else if (_iSlipPrintCndtn is StockMoveSlipPrintCndtn)
            {
                //---------------------------------------------
                // �݌Ɉړ��`�[
                //---------------------------------------------
                // �S�̏����\���ݒ�
                ConditionInfo.Add(this.GetAllDefSt());
                // �݌ɊǗ��S�̐ݒ�
                ConditionInfo.Add(this.GetStockMngTtlSt());
            }
            else if (_iSlipPrintCndtn is EstFmPrintCndtn)
            {
                //---------------------------------------------
                // ���Ϗ�
                //---------------------------------------------
                // �S�̏����\���ݒ�
                ConditionInfo.Add(this.GetAllDefSt());
                // ����S�̐ݒ�
                ConditionInfo.Add(this.GetSalesTtlSt());
                // ���Ϗ����l�ݒ�(�ҏW�ς�)
                ConditionInfo.Add((_iSlipPrintCndtn as EstFmPrintCndtn).EstimateDefSet);
            }
            else if (_iSlipPrintCndtn is UOESlipPrintCndtn)
            {
                //---------------------------------------------
                // �t�n�d�`�[
                //---------------------------------------------
                // �S�̏����\���ݒ�
                ConditionInfo.Add(this.GetAllDefSt());
                // ����S�̐ݒ�
                ConditionInfo.Add(this.GetSalesTtlSt());
            }
            # endregion

            # region [�\�����]
            // �\���f�[�^
            if (_iSlipPrintCndtn.ExtrData != null && _iSlipPrintCndtn.ExtrData.Count > 0)
            {
                ConditionInfo.AddRange(_iSlipPrintCndtn.ExtrData);
            }
            slipPrintConditionInfo.ExtrInfo = ConditionInfo;
            # endregion

            // ����f�[�^�ݒ�
            object pData = this._printData;

            // ���DLL���A�Z���u������Ă��邩�H
            if (_prtObj != null)
            {
                //// ���DLL��I/F����������Ă��邩�H
                //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                //{
                // ���DLL�̃v���r���[�Ƀ��\�b�h��Kick
                int st = ((ISlipPrintProc)_prtObj).SetPrintConditionInfoAndData(this, slipPrintConditionInfo, pData);
                if (st == 0)
                {
                    return 0;
                }
                //}
            }
            return -1;
        }

        # region [�A�N�Z�X�N���X����̊e��ݒ�擾]
        /// <summary>
        /// �S�̏����\���ݒ�
        /// </summary>
        /// <returns></returns>
        private AllDefSetWork GetAllDefSt()
        {
            AllDefSetWork allDefSet = _slipPrintAcs.GetAllDefSet();
            if (allDefSet != null)
            {
                return allDefSet;
            }
            else
            {
                return (new AllDefSetWork());
            }
        }
        /// <summary>
        /// ����S�̐ݒ�擾
        /// </summary>
        /// <returns></returns>
        private SalesTtlStWork GetSalesTtlSt()
        {
            SalesTtlStWork salesTtlSt = _slipPrintAcs.GetSalesTtlSt();
            if (salesTtlSt != null)
            {
                return salesTtlSt;
            }
            else
            {
                return (new SalesTtlStWork());
            }
        }
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�
        /// </summary>
        /// <returns></returns>
        private object GetStockMngTtlSt()
        {
            StockMngTtlStWork stockMngTtlSt = _slipPrintAcs.GetStockMngTtlSt();
            if (stockMngTtlSt != null)
            {
                return stockMngTtlSt;
            }
            else
            {
                return (new StockMngTtlStWork());
            }
        }
        // --- ADD  ���r��  2010/03/04 ---------->>>>>
        /// <summary>
        /// �ŗ��ݒ�擾     
        /// </summary>
        /// <returns></returns>
        private TaxRateSetWork GetTaxRateSt()
        {
            TaxRateSetWork taxRateSet = _slipPrintAcs.GetTaxRateSet();
            if (taxRateSet != null)
            {
                return taxRateSet;
            }
            else
            {
                return (new TaxRateSetWork());
            }
        }
        /// <summary>
        /// ������z�����敪�ݒ�擾
        /// </summary>
        /// <returns></returns>
        private List<SalesProcMoneyWork> GetsalesProcMn()
        {
            List<SalesProcMoneyWork> salesProcMoney = _slipPrintAcs.GetSalesProcMoney();
            if (salesProcMoney != null)
            {
                return salesProcMoney;
            }
            else
            {
                return (new List<SalesProcMoneyWork>());
            }
        }
        // --- ADD  ���r��  2010/03/04 ----------<<<<<
        # endregion
        # endregion �� �A�Z���u���E����f�[�^�ݒ胁�\�b�h�Ăяo�� ��

        # region �� �A�Z���u���E�v���r���[�^����^�o�c�e�o�̓��\�b�h�Ăяo�� ��

        /// <summary>
        /// �v���r���[���\�b�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���r���[���\�b�h�N������</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPrevewMethod()
        {
            // �ȈՉ�ʂ̏ꍇ�������Ȃ�
            if (_FormType == 0)
            {
                return 0;
            }

            int status = 0;

            try
            {
                // ���DLL���A�Z���u������Ă��邩�H
                if (_prtObj != null)
                {
                    //// ���DLL��I/F����������Ă��邩�H
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // ���DLL���Ăяo��
                    status = ((ISlipPrintProc)_prtObj).StartPreview(this);

                    if (status == 0)
                    {
                        // �p�����[�^�̐ݒ�
                        _prtParam.PreviewDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PreviewDocument;
                        _prtParam.PrintDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PrintDocument;

                        if (_slipPrintAssemblyFrom != null)
                        {
                            if (_slipPrintAssemblyFrom.TopLevel) _slipPrintAssemblyFrom.ShowInTaskbar = true;
                            status = _slipPrintAssemblyFrom.PrintPreviewWithoutPrtBtn(_prtParam);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_STOPDISP
                    , ex.Source
                    , "�`�[����m�F���"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , "�v���r���[�����ɂăG���[���������܂���"
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// ������\�b�h�N�������i�v���r���[�����j
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������\�b�h�N�������i�v���r���[�����j</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPrintMethod()
        {
            int status = 0;
            try
            {
                // ���DLL���A�Z���u������Ă��邩�H
                if (_prtObj != null)
                {
                    //// ���DLL��I/F����������Ă��邩�H
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // ���DLL�̃v���r���[�Ƀ��\�b�h��Kick
                    status = ((ISlipPrintProc)_prtObj).StartDirectPrint(this);
                    //}
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_STOPDISP
                    , ex.Source
                    , "�`�[����m�F���"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , "����i�v���r���[�����j�����ɂăG���[���������܂���"
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// �v���r���[�{������\�b�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���r���[�{������\�b�h�N������</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPrevewAndPrintMethod()
        {
            int status = 0;
            try
            {
                // ���DLL���A�Z���u������Ă��邩�H
                if (_prtObj != null)
                {
                    //// ���DLL��I/F����������Ă��邩�H
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // ���DLL�̃v���r���[�Ƀ��\�b�h��Kick
                    status = ((ISlipPrintProc)_prtObj).StartPreviewPrint(this);

                    if (status == 0)
                    {
                        // �p�����[�^�̐ݒ�
                        _prtParam.PreviewDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PreviewDocument;
                        _prtParam.PrintDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PrintDocument;

                        if (_slipPrintAssemblyFrom != null)
                        {
                            if (_slipPrintAssemblyFrom.TopLevel) _slipPrintAssemblyFrom.ShowInTaskbar = true;
                            status = _slipPrintAssemblyFrom.PrintPreview(_prtParam);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //TMsgDisp.Show(this
                //    , emErrorLevel.ERR_LEVEL_STOPDISP
                //    , ex.Source
                //    , "�`�[����m�F���"
                //    , ex.TargetSite.Name
                //    , TMsgDisp.OPE_PRINT
                //    , "�v���r���[�{��������ɂăG���[���������܂���"
                //    , 0
                //    , null
                //    , ex
                //    , MessageBoxButtons.OK
                //    , MessageBoxDefaultButton.Button1);

                if (this._isService == 0)
                {
                    TMsgDisp.Show(this
                        , emErrorLevel.ERR_LEVEL_STOPDISP
                        , ex.Source
                        , "�`�[����m�F���"
                        , ex.TargetSite.Name
                        , TMsgDisp.OPE_PRINT
                        , "�v���r���[�{��������ɂăG���[���������܂���"
                        , 0
                        , null
                        , ex
                        , MessageBoxButtons.OK
                        , MessageBoxDefaultButton.Button1);
                }
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// PDF�{������\�b�h�N������
        /// </summary>
        /// <param name="PdfOutPath">�o�c�e�o�̓p�X</param>
        /// <remarks>
        /// <br>Note       : PDF�{������\�b�h�N������</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPdfPrintMethod(string PdfOutPath)
        {
            // �o�c�e�o�̓t�H���_�ޔ�
            _dataCache.PdfOutPath = Path.GetDirectoryName(PdfOutPath);

            int status = 0;
            try
            {
                // ���DLL���A�Z���u������Ă��邩�H
                if (_prtObj != null)
                {
                    //// ���DLL��I/F����������Ă��邩�H
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // ���DLL��PdfPrint���\�b�h��Kick
                    status = ((ISlipPrintProc)_prtObj).StartPdfPrint(this);
                    if (status == 0)
                    {
                        // �p�����[�^�̐ݒ�
                        _prtParam.PreviewDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PreviewDocument;
                        _prtParam.PrintDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PrintDocument;
                        _prtParam.PdfPath = PdfOutPath;

                        if (_slipPrintAssemblyFrom != null)
                        {
                            if (_slipPrintAssemblyFrom.TopLevel) _slipPrintAssemblyFrom.ShowInTaskbar = true;
                            status = _slipPrintAssemblyFrom.OutputPDF(_prtParam);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 DEL
                //TMsgDisp.Show(this
                //    , emErrorLevel.ERR_LEVEL_STOPDISP
                //    , ex.Source
                //    , "�`�[����m�F���"
                //    , ex.TargetSite.Name
                //    , TMsgDisp.OPE_PRINT
                //    , "StartPdfPrint���\�b�h����`����Ă��܂���"
                //    , 0
                //    , null
                //    , ex
                //    , MessageBoxButtons.OK
                //    , MessageBoxDefaultButton.Button1);
                //status = -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "�`�[����m�F���"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , "PDF�t�@�C���̕ۑ��Ɏ��s���܂����B" + Environment.NewLine
                     + "�t�@�C�����g�p���̉\��������܂��B"
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                status = -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
            }
            return status;
        }
        # endregion �� �A�Z���u���E�v���r���[�^����^�o�c�e�o�̓��\�b�h�Ăяo�� ��

        # region �� ��� �� �}�X�^�ݒ� ��

        /// <summary>
        /// ��ʂɒl��ݒ肷��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂɒl��ݒ肷��</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void SlipPrtSetToDisplay(SlipPrtSetWork slipPrtSet)
        {
            try
            {
                // ��ʕ\����
                this.utcDetail.Tag = ctFormDrawingNow;

                //----------------------------------------------------
                // �ȈՈ���m�F���
                //----------------------------------------------------
                # region [�ȈՈ���m�F]
                // �o�̓v���O����ID�E�E�E�ݒ�s�v

                // �o�͊m�F���b�Z�[�W
                ulPrintMsg.Text = slipPrtSet.OutConfimationMsg;

                // ����v���r���L���敪
                if (slipPrtSet.PrtPreviewExistCode == 1)
                {
                    ucePrevew.CheckState = CheckState.Checked;
                }
                else
                {
                    ucePrevew.CheckState = CheckState.Unchecked;
                }

                //// �v�����^�Ǘ��ԍ�
                //tcePrinterName.Value = slipPrtSet.PrinterMngNo;

                // �������
                tnPrintCopy.Value = slipPrtSet.PrtCirculation;
                # endregion

                //----------------------------------------------------
                // �w�b�_�[
                //----------------------------------------------------
                # region [�w�b�_]
                tnCopyCount.Enabled = true;
                tnCopyCount.MaxValue = 4;

                // �`�[�^�C�g��1
                SetTitleToDropDownItem(tceTitle1, slipPrtSet);
                tceTitle1.Text = slipPrtSet.TitleName1;
                // �`�[�^�C�g��2
                SetTitleToDropDownItem(tceTitle2, slipPrtSet);
                tceTitle2.Text = slipPrtSet.TitleName2;
                // �`�[�^�C�g��3
                SetTitleToDropDownItem(tceTitle3, slipPrtSet);
                tceTitle3.Text = slipPrtSet.TitleName3;
                // �`�[�^�C�g��4
                SetTitleToDropDownItem(tceTitle4, slipPrtSet);
                tceTitle4.Text = slipPrtSet.TitleName4;

                if (slipPrtSet.CopyCount > 0)
                {
                    tnCopyCount.Value = slipPrtSet.CopyCount;
                }
                else
                {
                    tnCopyCount.Value = 1;
                }

                // ��F��ݒ肷��
                ulSlipColorT1.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed1, slipPrtSet.SlipBaseColorGrn1, slipPrtSet.SlipBaseColorBlu1);
                ulSlipColorT2.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed2, slipPrtSet.SlipBaseColorGrn2, slipPrtSet.SlipBaseColorBlu2);
                ulSlipColorT3.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed3, slipPrtSet.SlipBaseColorGrn3, slipPrtSet.SlipBaseColorBlu3);
                ulSlipColorT4.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed4, slipPrtSet.SlipBaseColorGrn4, slipPrtSet.SlipBaseColorBlu4);

                // ���Ж�����敪
                uosEnterpriseNamePrtCd.Value = slipPrtSet.EnterpriseNamePrtCd;
                // �`�[���t�󎚋敪
                uosSlipDatePrintDiv.Value = _slipPrintParameter.SlipDatePrintDiv;
                //// ���Ӑ�d�b�ԍ��󎚋敪
                //uosCustTelNoPrtDivCd.Value = slipPrtSet.CustTelNoPrtDivCd;

                //// �o�[�R�[�h�󎚋敪�i�󒍔ԍ��j
                //if (slipPrtSet.BarCodeAcpOdrNoPrtCd == 1)
                //{
                //    uceBCAcpOdrNoPrtCd.Checked = true;
                //}
                //else
                //{
                //    uceBCAcpOdrNoPrtCd.Checked = false;
                //}
                //// �o�[�R�[�h�󎚋敪�i���Ӑ�R�[�h�j
                //if (slipPrtSet.BarCodeCustCodePrtCd == 1)
                //{
                //    uceBCCustCodePrtCd.Checked = true;
                //}
                //else
                //{
                //    uceBCCustCodePrtCd.Checked = false;
                //}
                # endregion

                //----------------------------------------------------
                // ����
                //----------------------------------------------------
                # region [����]
                // ���v���z�󎚋敪
                uosTotalPricePrtCd.Value = _slipPrintParameter.TotalPricePrtCd;
                # endregion


                //----------------------------------------------------
                // ���ׁi��j
                //----------------------------------------------------
                # region [���ׁi��j]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //_slipColList.Clear();

                //// �`�[�^�C�v�ʗ�
                //string wkStr = "";
                //string wkEachSlipTypeColId = "";
                //string wkEachSlipTypeColNm = "";
                //int wkEachSlipTypeColPrt = 0;
                //for (int ix = 0 ; ix != 10 ; ix++)
                //{
                //    wkStr = slipPrtSet.GetType().InvokeMember("EachSlipTypeColId" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
                //    if (wkStr != "")
                //    {
                //        wkEachSlipTypeColId = slipPrtSet.GetType().InvokeMember("EachSlipTypeColId" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
                //        wkEachSlipTypeColNm = slipPrtSet.GetType().InvokeMember("EachSlipTypeColNm" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
                //        wkEachSlipTypeColPrt = (int)slipPrtSet.GetType().InvokeMember("EachSlipTypeColPrt" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null);
                //        _slipColList.Add(ix, new SlipColInfo(wkEachSlipTypeColId, wkEachSlipTypeColNm, wkEachSlipTypeColPrt));
                //    }
                //}

                ////------------------------------------------------------
                //// �`�[���ݒ肷��
                ////------------------------------------------------------
                //// �f�[�^�\�[�X��Tree������������
                //ultraDataSourceColMove.Band.Columns.Clear();
                //this.utEachSlipTypeCol.Nodes.Clear();
                //// ��ړ��p�̃O���b�h��ݒ肷��
                //for (int ix = 0 ; ix < _slipColList.Count ; ix++)
                //{
                //    SlipColInfo item = (SlipColInfo)_slipColList[ix];
                //    // �f�[�^�\�[�X����
                //    this.ultraDataSourceColMove.Band.Columns.Add(item.SlipColId);
                //    // �f�[�^�\�[�X�O���b�h�ݒ�
                //    this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[item.SlipColId].Header.Caption = item.SlipColName;
                //    if (item.SlipColOnOff == 1)
                //    {
                //        this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Hidden = false;
                //    }
                //    else
                //    {
                //        this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Hidden = true;
                //    }
                //    // ��\������p��TreeNode��ݒ肷��
                //    Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode = new Infragistics.Win.UltraWinTree.UltraTreeNode();
                //    Infragistics.Win.UltraWinTree.Override _override = new Infragistics.Win.UltraWinTree.Override();
                //    _override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                //    ultraTreeNode.Override = _override;
                //    ultraTreeNode.Key = item.SlipColId;
                //    ultraTreeNode.Text = item.SlipColName;
                //    if (item.SlipColOnOff == 0)
                //    {
                //        ultraTreeNode.CheckedState = CheckState.Unchecked;
                //    }
                //    else
                //    {
                //        ultraTreeNode.CheckedState = CheckState.Checked;
                //    }

                //    this.utEachSlipTypeCol.Nodes.Add(ultraTreeNode);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                # endregion

                //----------------------------------------------------
                // �t�b�^�[
                //----------------------------------------------------
                # region [�t�b�^]
                //// ��s���󎚋敪
                //uosBankNamePrtCd.Value = slipIniSet.BankNamePrtCd;
                //// �E�v�󎚋敪
                //uosOutlinePrtCd.Value = slipIniSet.OutlinePrtCd;
                # endregion

                //----------------------------------------------------
                // �]��
                //----------------------------------------------------
                # region [�]��]
                // ��]��
                tneTopMargin.SetValue(slipPrtSet.TopMargin);
                // ���]��
                tneLeftMargin.SetValue(slipPrtSet.LeftMargin);
                // �E�]��
                tneRightMargin.SetValue(slipPrtSet.RightMargin);
                // ���]��
                tneBottomMargin.SetValue(slipPrtSet.BottomMargin);
                # endregion
                // 2011.09.16 zhouzy UPDATE STA >>>>>>
                if (_IsRmSlpPrt)
                {// ��]��
                    tneTopMargin.SetValue(_rmSlpPrtStWork.TopMargin);
                    // ���]��
                    tneLeftMargin.SetValue(_rmSlpPrtStWork.LeftMargin);
                }
                // 2011.09.16 zhouzy UPDATE END <<<<<<

                //----------------------------------------------------
                // �t�H���g
                //----------------------------------------------------
                # region [�t�H���g]
                // �`�[�t�H���g����
                ufneSlipFontName.Value = slipPrtSet.SlipFontName;
                // �`�[�t�H���g�T�C�Y
                tceSlipFontSize.Value = slipPrtSet.SlipFontSize;
                // �`�[�t�H���g�X�^�C��
                tceSlipFontStyle.Value = slipPrtSet.SlipFontStyle;
                # endregion
            }
            finally
            {
                // ��ʕ\���I��
                this.utcDetail.Tag = "";
            }
        }
        # endregion �� ��� �� �}�X�^�ݒ� ��

        # region �� ��� �� �}�X�^�ݒ� ��

        /// <summary>
        /// ��ʂ���l���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ���l���擾����</br>
        /// <br>Programer  : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void GetSlipPrtSetFromDisplay(ref SlipPrintConditionInfo slipPrintConditionInfo, ref SlipPrtSetWork slipPrtSet)
        {
            try
            {
                // ���Љ摜
                slipPrintConditionInfo.CompanyImage = this.pbCompanyImage.Image;

                //----------------------------------------------------
                // �ȈՈ���m�F���
                //----------------------------------------------------
                # region [�ȈՈ���m�F]
                // �o�̓v���O����ID����Z�b�g�s�v

                // ����v���r���L���敪
                if (ucePrevew.CheckState == CheckState.Checked)
                {
                    // �v���r���[�L
                    slipPrtSet.PrtPreviewExistCode = 1;
                }
                else
                {
                    // �v���r���[��
                    slipPrtSet.PrtPreviewExistCode = 0;
                }

                // �v�����^�Ǘ��ԍ�/�v�����^����
                if (tcePrinterName.Value != null)
                {
                    //// �v�����^�Ǘ��ԍ�
                    //slipPrtSet.PrinterMngNo = (int)tcePrinterName.Value;
                    // �v�����^����
                    slipPrintConditionInfo.PrinterName = tcePrinterName.Items[tcePrinterName.SelectedIndex].DisplayText;
                }

                // �������
                slipPrtSet.PrtCirculation = tnPrintCopy.GetInt();
                // ����͈�
                slipPrintConditionInfo.PrintRange = (int)uosPrintRange.Value;
                // ����J�n�y�[�W
                slipPrintConditionInfo.PrintTopPage = tnPrintRangeFrom.GetInt();
                // ����I���y�[�W
                slipPrintConditionInfo.PrintEndPage = tnPrintRangeTo.GetInt();
                # endregion

                //----------------------------------------------------
                // �w�b�_�[
                //----------------------------------------------------
                # region [�w�b�_]
                // �`�[�^�C�g��1
                slipPrtSet.TitleName1 = tceTitle1.Text;
                // �`�[�^�C�g��2
                slipPrtSet.TitleName2 = tceTitle2.Text;
                // �`�[�^�C�g��3
                slipPrtSet.TitleName3 = tceTitle3.Text;
                // �`�[�^�C�g��4
                slipPrtSet.TitleName4 = tceTitle4.Text;

                // �`�[���ʖ���
                slipPrtSet.CopyCount = (int)tnCopyCount.Value;

                // ���Ж�����敪
                slipPrtSet.EnterpriseNamePrtCd = (int)uosEnterpriseNamePrtCd.Value;
                // �`�[���t�󎚋敪
                _slipPrintParameter.SlipDatePrintDiv = (int)uosSlipDatePrintDiv.Value;
                //// ���Ӑ�d�b�ԍ��󎚋敪
                //slipPrtSet.CustTelNoPrtDivCd = (int)uosCustTelNoPrtDivCd.Value;

                //// �o�[�R�[�h�󎚋敪�i�󒍔ԍ��j
                //if ((this._isBarCodeOpt) &&
                //    (uceBCAcpOdrNoPrtCd.Checked))
                //{
                //    slipPrtSet.BarCodeAcpOdrNoPrtCd = 1;
                //}
                //else
                //{
                //    slipPrtSet.BarCodeAcpOdrNoPrtCd = 0;
                //}
                //// �o�[�R�[�h�󎚋敪�i���Ӑ�R�[�h�j
                //if ((this._isBarCodeOpt) &&
                //    (uceBCCustCodePrtCd.Checked))
                //{
                //    slipPrtSet.BarCodeCustCodePrtCd = 1;
                //}
                //else
                //{
                //    slipPrtSet.BarCodeCustCodePrtCd = 0;
                //}

                // ��F�P���擾����
                slipPrtSet.SlipBaseColorRed1 = ulSlipColorT1.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn1 = ulSlipColorT1.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu1 = ulSlipColorT1.Appearance.BackColor.B;
                // ��F�Q���擾����
                slipPrtSet.SlipBaseColorRed2 = ulSlipColorT2.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn2 = ulSlipColorT2.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu2 = ulSlipColorT2.Appearance.BackColor.B;
                // ��F�R���擾����
                slipPrtSet.SlipBaseColorRed3 = ulSlipColorT3.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn3 = ulSlipColorT3.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu3 = ulSlipColorT3.Appearance.BackColor.B;
                // ��F�S���擾����
                slipPrtSet.SlipBaseColorRed4 = ulSlipColorT4.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn4 = ulSlipColorT4.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu4 = ulSlipColorT4.Appearance.BackColor.B;

                # endregion

                //----------------------------------------------------
                // ����
                //----------------------------------------------------
                # region [����]
                // ���v���z�󎚋敪
                _slipPrintParameter.TotalPricePrtCd = (int)uosTotalPricePrtCd.Value;
                # endregion

                //----------------------------------------------------
                // ���ׁi��j
                //----------------------------------------------------
                # region [���ׁi��j]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //for (int ix = 0 ; ix < 10 ; ix++)
                //{
                //    string ColId = "";
                //    string ColNm = "";
                //    int ColPrt = 0;
                //    int ColPos = ix;

                //    // ��ړ��O���b�h����J���������擾����
                //    if (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns.Count > ix)
                //    {
                //        // ��̃|�W�V�������擾����
                //        ColPos = this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Header.VisiblePosition;
                //        if ((this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix] != null) &&
                //            (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Key != null) &&
                //            (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Header.Caption != null))
                //        {
                //            // ��h�c�Ɨ񖼂��擾
                //            ColId = (string)this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Key;
                //            ColNm = (string)this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Header.Caption;
                //            // ����敪���擾����
                //            if (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Hidden == false) ColPrt = 1;
                //        }
                //    }

                //    // �`�[�����ݒ肷��
                //    slipPrtSet.GetType().InvokeMember("EachSlipTypeColId" + (ColPos + 1).ToString(), BindingFlags.SetProperty, null, slipPrtSet, new Object[] { ColId });
                //    slipPrtSet.GetType().InvokeMember("EachSlipTypeColNm" + (ColPos + 1).ToString(), BindingFlags.SetProperty, null, slipPrtSet, new Object[] { ColNm });
                //    slipPrtSet.GetType().InvokeMember("EachSlipTypeColPrt" + (ColPos + 1).ToString(), BindingFlags.SetProperty, null, slipPrtSet, new Object[] { ColPrt });
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                # endregion

                //----------------------------------------------------
                // �t�b�^�[
                //----------------------------------------------------
                # region [�t�b�^]
                //// ��s���󎚋敪
                //slipIniSet.BankNamePrtCd = (int)uosBankNamePrtCd.Value;
                //// �E�v�󎚋敪
                //slipIniSet.OutlinePrtCd = (int)uosOutlinePrtCd.Value;
                # endregion

                //----------------------------------------------------
                // �]��
                //----------------------------------------------------
                # region [�]��]
                // ��]��
                slipPrtSet.TopMargin = tneTopMargin.GetValue();
                // ���]��
                slipPrtSet.LeftMargin = tneLeftMargin.GetValue();
                // �E�]��
                slipPrtSet.RightMargin = tneRightMargin.GetValue();
                // ���]��
                slipPrtSet.BottomMargin = tneBottomMargin.GetValue();
                # endregion

                //----------------------------------------------------
                // �t�H���g
                //----------------------------------------------------
                # region [�t�H���g]
                // �`�[�t�H���g����
                if (ufneSlipFontName.Value != null)
                {
                    slipPrtSet.SlipFontName = (string)ufneSlipFontName.Value;
                }
                // �`�[�t�H���g�T�C�Y
                if (tceSlipFontSize.Value != null)
                {
                    slipPrtSet.SlipFontSize = (int)tceSlipFontSize.Value;
                }
                // �`�[�t�H���g�X�^�C��
                if (tceSlipFontStyle.Value != null)
                {
                    slipPrtSet.SlipFontStyle = (int)tceSlipFontStyle.Value;
                }
                # endregion
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_STOPDISP
                    , ex.Source
                    , "�`�[����m�F���"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , ex.Message + "\n\r" + ex.StackTrace
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
        }
        # endregion �� ��� �� �}�X�^�ݒ� ��

        # region �� �`�[�^�C�g���EDropDownItem�ݒ� ��
        /// <summary>
        /// �`�[�^�C�g���I��pDropDownItem�Z�b�g����
        /// </summary>
        /// <param name="comboEditor">�Z�b�g�Ώ�ComboEditor</param>
        /// <param name="slipPrtSet">�`�[����ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ComboEditor��Item�ɑI��p�`�[�^�C�g�����Z�b�g���܂��B</br>
        /// <br>Programmer : 22018 ��؁@���b</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void SetTitleToDropDownItem(TComboEditor comboEditor, SlipPrtSetWork slipPrtSet)
        {
            comboEditor.Items.Clear();

            string wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "02", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "03", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "04", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "05", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
        }
        # endregion �� �`�[�^�C�g���EDropDownItem�ݒ� ��

        # endregion �� private���\�b�h ��

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
        ////==================================================================================
        //// �`�[����N���X
        ////==================================================================================
        //# region �� SlipColInfo ��
        ///// <summary>
        ///// �`�[����N���X
        ///// </summary>
        ///// <remarks>
        ///// <br>Programer  : 22018 ��؁@���b</br>
        ///// <br>Date       : 2007.12.17</br>
        ///// </remarks>
        //[Serializable]
        //private class SlipColInfo
        //{
        //    /// <summary>
        //    /// �`�[��ID
        //    /// </summary>
        //    private string _slipColId;
        //    /// <summary>
        //    /// �`�[�񖼏�
        //    /// </summary>
        //    private string _slipColName;
        //    /// <summary>
        //    /// �`�[��󎚋敪
        //    /// </summary>
        //    private int _slipColOnOff;

        //    /// <summary>
        //    /// �`�[��ID�v���p�e�B
        //    /// </summary>
        //    public string SlipColId
        //    {
        //        get { return _slipColId; }
        //        set { this._slipColId = value; }
        //    }
        //    /// <summary>
        //    /// �`�[�񖼏̃��p�e�B
        //    /// </summary>
        //    public string SlipColName
        //    {
        //        get { return _slipColName; }
        //        set { this._slipColName = value; }
        //    }
        //    /// <summary>
        //    /// �`�[��󎚋敪�v���p�e�B
        //    /// </summary>
        //    public int SlipColOnOff
        //    {
        //        get { return _slipColOnOff; }
        //        set { this._slipColOnOff = value; }
        //    }

        //    /// <summary>
        //    /// �R���X�g���N�^��`
        //    /// </summary>
        //    public SlipColInfo()
        //    {
        //        _slipColId = "";
        //        _slipColName = "";
        //        _slipColOnOff = 0;
        //    }

        //    public SlipColInfo(string pId, string pName, int pOnOff)
        //    {
        //        _slipColId = pId;
        //        _slipColName = pName;
        //        _slipColOnOff = pOnOff;
        //    }
        //}
        //# endregion �� SlipColInfo ��
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL

        # region ���@�`�[����p�����[�^�\���́@��
        /// <summary>
        /// �`�[����p�����[�^�\����
        /// </summary>
        /// <remarks>
        /// <br>���f�[�^�N���X�̃����o�Ƃ��đ��݂��Ȃ��f�[�^��</br>
        /// <br>�@����c�k�k�Ɏ󂯓n���ׂ̍\���̂ł��B</br>
        /// <br>��object�̃f�B�N�V���i���Ƃ̑��ݕϊ��@�\�������܂��B</br>
        /// </remarks>
        private struct SlipPrintParameter
        {
            /// <summary>���t�󎚗L��(0:���Ȃ�/1:����)</summary>
            private int _slipDatePrintDiv;
            /// <summary>���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)</summary>
            private int _totalPricePrtCd;
            /// <summary>�Ĕ��s�敪</summary>
            private bool _reissueDiv;
            // --- ADD m.suzuki 2010/07/09 ---------->>>>>
            /// <summary>QR�쐬�敪</summary>
            private bool _makeQRDiv;
            // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            /// <summary>
            /// ���t�󎚗L��(0:���Ȃ�/1:����)
            /// </summary>
            public int SlipDatePrintDiv
            {
                get { return _slipDatePrintDiv; }
                set { _slipDatePrintDiv = value; }
            }
            /// <summary>
            /// ���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)
            /// </summary>
            public int TotalPricePrtCd
            {
                get { return _totalPricePrtCd; }
                set { _totalPricePrtCd = value; }
            }
            /// <summary>
            /// �Ĕ��s�敪
            /// </summary>
            public bool ReissueDiv
            {
                get { return _reissueDiv; }
                set { _reissueDiv = value; }
            }
            // --- ADD m.suzuki 2010/07/09 ---------->>>>>
            /// <summary>
            /// QR�쐬�敪
            /// </summary>
            public bool MakeQRDiv
            {
                get { return _makeQRDiv; }
                set { _makeQRDiv = value; }
            }
            // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="slipDatePrintDiv">���t�󎚗L��(0:���Ȃ�/1:����)</param>
            /// <param name="totalPricePrtCd">���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)</param>
            /// <param name="reissueDiv">�Ĕ��s�敪</param>
            public SlipPrintParameter(int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv)
            {
                _slipDatePrintDiv = slipDatePrintDiv;
                _totalPricePrtCd = totalPricePrtCd;
                _reissueDiv = reissueDiv;
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                _makeQRDiv = false;
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            }
            // --- ADD m.suzuki 2010/07/09 ---------->>>>>
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="slipDatePrintDiv">���t�󎚗L��(0:���Ȃ�/1:����)</param>
            /// <param name="totalPricePrtCd">���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)</param>
            /// <param name="reissueDiv">�Ĕ��s�敪</param>
            /// <param name="makeQRDiv">QR�쐬�敪</param>
            public SlipPrintParameter(int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv, bool makeQRDiv)
            {
                _slipDatePrintDiv = slipDatePrintDiv;
                _totalPricePrtCd = totalPricePrtCd;
                _reissueDiv = reissueDiv;
                _makeQRDiv = makeQRDiv;
            }
            // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            /// <summary>
            /// �R���X�g���N�^ (object�̃f�B�N�V���i�����)
            /// </summary>
            /// <param name="objectDictionary"></param>
            public SlipPrintParameter(Dictionary<string, object> objectDictionary)
            {
                // �����l��ݒ�
                _slipDatePrintDiv = 1;
                _totalPricePrtCd = 0;
                _reissueDiv = false;
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                _makeQRDiv = false;
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<

                // �n���ꂽList�̓��e���i�[
                if (objectDictionary != null)
                {
                    if (objectDictionary.ContainsKey("SlipDatePrintDiv") && objectDictionary["SlipDatePrintDiv"] is int)
                    {
                        _slipDatePrintDiv = (int)objectDictionary["SlipDatePrintDiv"];
                    }
                    if (objectDictionary.ContainsKey("TotalPricePrtCd") && objectDictionary["TotalPricePrtCd"] is int)
                    {
                        _totalPricePrtCd = (int)objectDictionary["TotalPricePrtCd"];
                    }
                    if (objectDictionary.ContainsKey("ReissueDiv") && objectDictionary["ReissueDiv"] is bool)
                    {
                        _reissueDiv = (bool)objectDictionary["ReissueDiv"];
                    }
                    // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                    if (objectDictionary.ContainsKey("MakeQRDiv") && objectDictionary["MakeQRDiv"] is bool)
                    {
                        _makeQRDiv = (bool)objectDictionary["MakeQRDiv"];
                    }
                    // --- ADD m.suzuki 2010/07/09 ----------<<<<<
                }
            }
            /// <summary>
            /// �f�B�N�V���i���֕ϊ�
            /// </summary>
            /// <returns></returns>
            public Dictionary<string, object> ToDictionary()
            {
                // �����o���f�B�N�V���i���Ɋi�[
                Dictionary<string, object> objectDic = new Dictionary<string, object>();
                objectDic.Add("SlipDatePrintDiv", _slipDatePrintDiv);
                objectDic.Add("TotalPricePrtCd", _totalPricePrtCd);
                objectDic.Add("ReissueDiv", _reissueDiv);
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                objectDic.Add("MakeQRDiv", _makeQRDiv);
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<

                // Dictionary��Ԃ�
                return objectDic;
            }
        }
        # endregion ���@�`�[����p�����[�^�\���́@��

        # region [�`�[����_�C�A���O�E�X�e�[�^�X]
        /// <summary>
        /// �`�[����_�C�A���O�E�X�e�[�^�X
        /// </summary>
        public enum SlipPrintDialogStatus
        {
            Normal = 0,
            Cancel = 1,
            Error_CallPrint = 2,
            Error_Initialize = 3,
            Error_InvalidPrinter = 4,
        }
        # endregion

        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("DCCMN02000U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
#endif
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<                
    }
    /// <summary>
    /// �`�[�_�C�A���O���o�b�t�@
    /// </summary>
    /// <remarks>����v���Z�X���ŋ��L����������ێ����܂��B�isingleton�j</remarks>
    public class SlipDialogDataCache
    {
        // static�C���X�^���X
        private static SlipDialogDataCache stc_SlipDialogDataCache;

        // �o�c�e�o�̓p�X
        private string _pdfOutPath;

        /// <summary>
        /// �o�c�e�o�̓p�X
        /// </summary>
        public string PdfOutPath
        {
            get { return _pdfOutPath; }
            set { _pdfOutPath = value; }
        }

        /// <summary>
        /// �v���C�x�[�g�R���X�g���N�^
        /// </summary>
        private SlipDialogDataCache()
        {
            _pdfOutPath = string.Empty;
        }

        /// <summary>
        /// �C���X�^���X�擾
        /// </summary>
        /// <returns></returns>
        public static SlipDialogDataCache GetInstance()
        {
            if (stc_SlipDialogDataCache == null)
            {
                stc_SlipDialogDataCache = new SlipDialogDataCache();
            }
            return stc_SlipDialogDataCache;
        }
    }
}
