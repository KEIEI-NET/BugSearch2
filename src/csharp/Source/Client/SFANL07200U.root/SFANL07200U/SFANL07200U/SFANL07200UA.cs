#define CLR2
//#define _ONE_SECTION_ONLY_  // ADD 2010/02/19 MANTIS�Ή�[14310]�F�^���I��1���_�݂̂̏�ԂƂ���t���O �������[�X���͖����Ƃ��邱��

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;   // 2008.09.05 T.Kudoh ADD
using Broadleaf.Application.Controller.Facade;  // 2008.09.05 T.Kudoh ADD
using Broadleaf.Application.Controller.Util;    // 2008.09.05 T.Kudoh ADD
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using Broadleaf.Library.Diagnostics;// ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[����(�������̓^�C�v)�t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[����(�������̓^�C�v)�̃t���[���N���X�ł��B</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2006.01.17</br>
    /// <br>Update Note: 2006.04.17 Y.Sasaki</br>
    /// <br>           : �P.�{�^�����̕ύX�BPDF�o�́�PDF�\��</br>
    /// <br>           : �Q.PDF����ۑ��@�\�ǉ��B</br>
    /// <br>Update Note: 2006.04.19 Y.Sasaki</br>
    /// <br>           : �P.VS2005(CLR2.0) �Ή� </br>
    /// <br>Update Note: 2006.05.01 Y.Sasaki</br>
    /// <br>           : �P.�I������PDF���폜����Ȃ����ۂ̉���B </br>
    /// <br>Update Note: 2006.07.24 Y.Sasaki</br>
    /// <br>           : �P.�u���b�V���A�b�v�Ή�(�X���C�_�[�A�^�u�X�^�C��)�B </br>
    /// <br>Update Note: 2006.08.09  Y.Sasaki </br>
    /// <br>           : �P.�V�X�e���I��L�莞�̑I���\�V�X�e���̐ݒ��<br>
    /// <br>           : �I���\�V�X�e�����I���ł���悤�ɋ@�\�ǉ��B<br>
    /// <br>Update Note: 2006.09.01  Y.Sasaki </br>
    /// <br>           : �P.�e�L�X�g�o�͋@�\�ǉ�<br>
    /// <br>Update Note: 2006.09.04  Y.Sasaki </br>
    /// <br>           : �P.���_�R�[�h�̃g�����ǉ�<br>
    /// <br>Update Note: 2006.09.26  Y.Sasaki </br>
    /// <br>           : �P.���_����ݒ�Łu�S���_�v���ݒ肳���Ƃ��A�u�S�Ёv�Ƀ`�F�b�N�����Ȃ���Q�����B<br>
    /// <br>Update Note: 2006.09.28  Y.Sasaki </br>
    /// <br>           : �P.�e�L�X�g�o�͋@�\�ǉ��B<br>
    /// <br>Update Note: 2007.03.05  Y.Sasaki </br>
    /// <br>           : �P.�g��.NS�p�ɕύX�B�O���t�\���@�\�ǉ�<br>
    /// <br>Update Note: 2007.06.29  Y.Sasaki </br>
    /// <br>           : �P.�i�r�Q�[�g���[�h���ɑS�Ẳ�ʂ��Ƃ��āA����������Ȃ����Ƃ����
    /// <br>           : �G���[�ɂȂ��Q�����B
    /// <br>Update Note: 2007.06.29  Y.Sasaki </br>
    /// <br>           : �P.�O���t��ʃ^�u���A�N�e�B�u�Ȏ��ɒ��o�������I���ł��Ȃ��悤�ɏC���B</br>
    /// <br>Update Note: 2007.07.24  Y.Sasaki </br>
    /// <br>           : �P.�q��ʂ̓��t�R���|�Ƀt�H�[�J�X�������ԁA���[���T�v���X��</br>
    /// <br>           : ������悤�ȓ��͒l�̏ꍇ�ɁA�O���t�\���{�^�����������Ɠ��t�R���|�̓����l������������錻�ۂ������B</br>
    /// <br>Update Note: 2008.09.05  T.Kudoh </br>
    /// <br>           : �P.���쌠���ɉ������{�^������̑Ή�</br>
    /// <br>Update Note: 2008.11.12  Y.Shinobu </br>
    /// <br>           : �P�D���s�@�\�ǉ�</br>
    /// <br>Update Note: 2009.01.14  Y.Shinobu </br>
    /// <br>           : �P�D��QID:9980�Ή�</br>
    /// <br>Update Note: 2009.01.19  Y.Shinobu </br>
    /// <br>           : �P�D��QID:9982�Ή�</br>
    /// <br>Update Note: 2009.09.02  ��� ���b </br>
    /// <br>           : �P�DMANTIS 0013848</br>
    /// <br>           :     "���s"�{�^���������ɁA�v���r���[�Ȃ�������Ă��������Ȃ��s����C���B</br>
    /// <br>Update Note: 2009.12.25  �H��</br>
    /// <br>           : �P�DMANTIS 0014310</br>
    /// <br>           :     ���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�����C��</br>
    /// <br>Update Note: 2010.02.19  �H��</br>
    /// <br>           : �P�DMANTIS 0014310</br>
    /// <br>           :     ���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�����C���i�����߂��j</br>
    /// <br>Update Note: 2010.05.11  �H��</br>
    /// <br>           : �P�DMANTIS 0015358</br>
    /// <br>           :     1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C��</br>
    /// <br>Update Note: 2010/08/16  ����</br>
    /// <br>           : ��Q���ǑΉ��i�W�����j/br>
    /// <br>           :     �L�[�{�[�h����̉��ǂ��s���B</br>
    /// <br>Update Note: 2011/03/14 yangmj</br>
    /// <br>             ����\��\�ŁA��ʓ��͓��e��XML�ɕۑ����A
    /// <br> �@�@�@�@�@�@����N�����ɐݒ肵�����e�����f�����l�ɂ���̏C��</br>
    /// <br>Update Note: 2011/10/27 ������</br>
    /// <br>             ��Q�� #26273�̑Ή�</br>
    /// <br>Update Note: 2011/12/15 �����x</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
    /// <br>             Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    /// <br>�Ǘ��ԍ�   : 11000606-00  </br>
    /// <br>             �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
    /// <br>Update Note: 2021/01/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11670323-00</br>
    /// <br>             PMKOBETSU-4109�@�v���O�����N�����O�𑀍엚�����O�ɏo�͂���ǉ��Ή�</br>
    /// </remarks>
    public class SFANL07200UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)

        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_TabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorTree;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private System.Windows.Forms.Panel SFUKK06180U_Fill_Panel;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar SelectExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet AddUpCd_UOptionSet;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private Infragistics.Win.UltraWinTree.UltraTree Section_UTree;
        private Infragistics.Win.UltraWinTree.UltraTree System_UTree;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _SFANL07200UAAutoHideControl;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea3;
        private System.Windows.Forms.Panel PdfHistory_Panel;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private TMemPos tMemPos1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor startRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel startRangeUltraLabel;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor endRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel endRangeUltraLabel;
        private TNedit tEdit_SectionCode_St;
        private TNedit tEdit_SectionCode_Ed;
        private TRetKeyControl tRetKeyControl;
        private TArrowKeyControl tArrowKeyControl;
        private UiSetControl uiSetControl;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow3;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow4;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===============================================================================
        // �R���X�g���N�^
        // ===============================================================================
        # region Constructor
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
        /// </remarks>
        public SFANL07200UA()
        {
            InitializeComponent();

#if !CLR2      
			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._loginSectionCode = this._loginEmployee.BelongSectionCode;
            }

            //--- �����V�X�e������
            this._introduceSystem = new Hashtable();

            //  �����L������
#if false		// USB �� Company�@�֕ύX ���iS�m�F�ς�
			if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Contract ||     //�_��ς�
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Trial_Contract) //�̌��Ō_��ς�
			{
				this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF, "����");
			}

			//  ����L������
			if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Contract ||     //�_��ς�
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Trial_Contract) //�̌��Ō_��ς�
			{
				this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK, "���");
			}

			//  �Ԕ̗L������
			if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Contract ||     //�_��ς�
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Trial_Contract) //�̌��Ō_��ς�
			{
				this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS, "�Ԕ�");
			}
#else
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Contract ||     //�_��ς�
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Trial_Contract) //�̌��Ō_��ς�
            {
                this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF, "����");
            }

            //  ����L������
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Contract ||     //�_��ς�
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Trial_Contract) //�̌��Ō_��ς�
            {
                this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK, "���");
            }

            //  �Ԕ̗L������
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Contract ||     //�_��ς�
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Trial_Contract) //�̌��Ō_��ς�
            {
                this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS, "�Ԕ�");
            }
#endif
            // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // FIXME:�e�L�X�g�o�́cUSB�`�F�b�N
            PurchaseStatus purchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (purchaseStatus == PurchaseStatus.Contract ||			// �_���
                    purchaseStatus == PurchaseStatus.Trial_Contract)	// �̌��Ō_���
            {
                this._isOptTextOutPut = true;
            }
            else
            {
                this._isOptTextOutPut = false;
            }
            // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            //--- �A�N�Z�X�N���X�C���X�^���X��
            this._secInfoAcs = new SecInfoAcs();
            this._prtOutSetAcs = new PrtOutSetAcs();
            this._noMngSetAcs = new NoMngSetAcs();

            // �I�����_��ނ�Default�A�C�e�����쐬���܂��B
            this._arDefultSecKind = new ArrayList(2);

            SectionKind secKind1 = new SectionKind();
            secKind1.CtrlFuncName = "���ьv�㋒�_";
            secKind1.CtrlFuncCode = (int)SecInfoAcs.CtrlFuncCode.ResultsAddUpSecCd;
            this._arDefultSecKind.Add(secKind1);

            SectionKind secKind2 = new SectionKind();
            secKind2.CtrlFuncName = "�����v�㋒�_";
            secKind2.CtrlFuncCode = (int)SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd;
            this._arDefultSecKind.Add(secKind2);

            // PDF�폜���X�g�e�[�u���쐬
            this._delPDFList = new Hashtable();

            // ��ʃf�U�C���ύX�N���X
            SFANL07200UA.mControlScreenSkin = new ControlScreenSkin();
        }
        #endregion

        // ===============================================================================
        // �j��
        // ===============================================================================
        #region Dispose
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        /// <br>Update Note: 2011/03/14 yangmj</br>
        /// <br>             ����\��\�ŁA��ʓ��͓��e��XML�ɕۑ����A
        /// <br> �@�@�@�@�@�@����N�����ɐݒ肵�����e�����f�����l�ɂ���̏C��</br>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            //-----ADD 2011/03/14 ---------->>>>>
            // �I�����Ă��鋒�_���O���o�́@������\��\�ŋN�����Ă���ꍇ�̂�
            if (_dckauFlag)
            {
                SectionTreeHelper.ExportCheckedSectionCode(this.Section_UTree, true);
            }
            //-----ADD 2011/03/14 ----------<<<<<

            base.Dispose(disposing);
        }
        #endregion

        // ===============================================================================
        // Windows�t�H�[���f�U�C�i�Ő������ꂽ�R�[�h
        // ===============================================================================
        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("15887006-b123-425f-864e-3a811a2c4619"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("fd30e023-a611-4cef-bd96-552b5157b8bd"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("15887006-b123-425f-864e-3a811a2c4619"), -1);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("14433859-0725-4ebd-a557-fdb6711dcbf4"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("8087aaa9-2b2f-45f4-a82f-93170cf47281"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("14433859-0725-4ebd-a557-fdb6711dcbf4"), -1);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("524f5fb4-ad59-49eb-97a6-66081c3c8354"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("7fabf8be-5362-446b-9bc9-d84e9a0750d3"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("524f5fb4-ad59-49eb-97a6-66081c3c8354"), -1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Update_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Change_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NextPage_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Graph_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Update_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Graph_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Update_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Change_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NextPage_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL07200UA));
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.AddUpCd_UOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tEdit_SectionCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.endRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.startRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.startRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Section_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.System_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.StartNavigatorTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.PdfHistory_Panel = new System.Windows.Forms.Panel();
            this.SelectExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.SFUKK06180U_Fill_Panel = new System.Windows.Forms.Panel();
            this.Main_TabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._SFANL07200UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uiSetControl = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow4 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this._SFANL07200UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._SFANL07200UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFANL07200UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).BeginInit();
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).BeginInit();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.System_UTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).BeginInit();
            this.SelectExplorerBar.SuspendLayout();
            this.SFUKK06180U_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).BeginInit();
            this.Main_TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this._SFANL07200UAAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.dockableWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AddUpCd_UOptionSet);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(201, 44);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            this.ultraExplorerBarContainerControl1.Visible = false;
            // 
            // AddUpCd_UOptionSet
            // 
            this.AddUpCd_UOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.AddUpCd_UOptionSet.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AddUpCd_UOptionSet.Location = new System.Drawing.Point(2, 4);
            this.AddUpCd_UOptionSet.Name = "AddUpCd_UOptionSet";
            this.AddUpCd_UOptionSet.Size = new System.Drawing.Size(224, 35);
            this.AddUpCd_UOptionSet.TabIndex = 0;
            this.AddUpCd_UOptionSet.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.AddUpCd_UOptionSet.ValueChanged += new System.EventHandler(this.AddUpCd_UOptionSet_ValueChanged);
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_SectionCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_SectionCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.endRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.endRangeUltraLabel);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.startRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.startRangeUltraLabel);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(28, 146);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(201, 50);
            this.ultraExplorerBarContainerControl4.TabIndex = 3;
            // 
            // tEdit_SectionCode_Ed
            // 
            this.tEdit_SectionCode_Ed.ActiveAppearance = appearance9;
            this.tEdit_SectionCode_Ed.AutoSelect = true;
            this.tEdit_SectionCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_Ed.DataText = "99";
            this.tEdit_SectionCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_Ed.Location = new System.Drawing.Point(46, 26);
            this.tEdit_SectionCode_Ed.MaxLength = 12;
            this.tEdit_SectionCode_Ed.Name = "tEdit_SectionCode_Ed";
            this.tEdit_SectionCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_Ed.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_Ed.TabIndex = 2;
            this.tEdit_SectionCode_Ed.Text = "99";
            this.tEdit_SectionCode_Ed.Leave += new System.EventHandler(this.endRangeTNedit_Leave);
            // 
            // tEdit_SectionCode_St
            // 
            this.tEdit_SectionCode_St.ActiveAppearance = appearance10;
            this.tEdit_SectionCode_St.AutoSelect = true;
            this.tEdit_SectionCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_St.DataText = "99";
            this.tEdit_SectionCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_St.Location = new System.Drawing.Point(46, 0);
            this.tEdit_SectionCode_St.MaxLength = 12;
            this.tEdit_SectionCode_St.Name = "tEdit_SectionCode_St";
            this.tEdit_SectionCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_St.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_St.TabIndex = 1;
            this.tEdit_SectionCode_St.Text = "99";
            this.tEdit_SectionCode_St.Leave += new System.EventHandler(this.startRangeTNedit_Leave);
            // 
            // endRangeNameUltraTextEditor
            // 
            this.endRangeNameUltraTextEditor.Enabled = false;
            this.endRangeNameUltraTextEditor.Location = new System.Drawing.Point(80, 26);
            this.endRangeNameUltraTextEditor.Name = "endRangeNameUltraTextEditor";
            this.endRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.endRangeNameUltraTextEditor.TabIndex = 5;
            // 
            // endRangeUltraLabel
            // 
            this.endRangeUltraLabel.Location = new System.Drawing.Point(0, 30);
            this.endRangeUltraLabel.Name = "endRangeUltraLabel";
            this.endRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.endRangeUltraLabel.TabIndex = 3;
            this.endRangeUltraLabel.Text = "�I��";
            // 
            // startRangeNameUltraTextEditor
            // 
            this.startRangeNameUltraTextEditor.Enabled = false;
            this.startRangeNameUltraTextEditor.Location = new System.Drawing.Point(80, 0);
            this.startRangeNameUltraTextEditor.Name = "startRangeNameUltraTextEditor";
            this.startRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.startRangeNameUltraTextEditor.TabIndex = 2;
            // 
            // startRangeUltraLabel
            // 
            this.startRangeUltraLabel.Location = new System.Drawing.Point(0, 4);
            this.startRangeUltraLabel.Name = "startRangeUltraLabel";
            this.startRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.startRangeUltraLabel.TabIndex = 0;
            this.startRangeUltraLabel.Text = "�J�n";
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.Section_UTree);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(28, 249);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(184, 0);
            this.ultraExplorerBarContainerControl2.TabIndex = 1;
            this.ultraExplorerBarContainerControl2.Visible = false;
            // 
            // Section_UTree
            // 
            this.Section_UTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Section_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_UTree.Location = new System.Drawing.Point(0, 0);
            this.Section_UTree.Name = "Section_UTree";
            this.Section_UTree.Size = new System.Drawing.Size(184, 0);
            this.Section_UTree.TabIndex = 3;
            this.Section_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Section_UTree_AfterCheck);
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.System_UTree);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(201, 71);
            this.ultraExplorerBarContainerControl3.TabIndex = 2;
            this.ultraExplorerBarContainerControl3.Visible = false;
            // 
            // System_UTree
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.System_UTree.Appearance = appearance2;
            this.System_UTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.System_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.System_UTree.Location = new System.Drawing.Point(0, 0);
            this.System_UTree.Name = "System_UTree";
            this.System_UTree.Size = new System.Drawing.Size(201, 71);
            this.System_UTree.TabIndex = 0;
            this.System_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.System_UTree_AfterCheck);
            // 
            // StartNavigatorTree
            // 
            this.StartNavigatorTree.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartNavigatorTree.Location = new System.Drawing.Point(0, 27);
            this.StartNavigatorTree.Name = "StartNavigatorTree";
            this.StartNavigatorTree.Size = new System.Drawing.Size(250, 621);
            this.StartNavigatorTree.TabIndex = 0;
            this.StartNavigatorTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorTree_MouseDown);
            this.StartNavigatorTree.DoubleClick += new System.EventHandler(this.StartNavigatorTree_DoubleClick);
            // 
            // PdfHistory_Panel
            // 
            this.PdfHistory_Panel.BackColor = System.Drawing.Color.White;
            this.PdfHistory_Panel.Location = new System.Drawing.Point(0, 27);
            this.PdfHistory_Panel.Name = "PdfHistory_Panel";
            this.PdfHistory_Panel.Size = new System.Drawing.Size(250, 621);
            this.PdfHistory_Panel.TabIndex = 0;
            // 
            // SelectExplorerBar
            // 
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "AddUpCdList";
            ultraExplorerBarGroup1.Settings.ContainerHeight = 44;
            ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup1.Text = "�v�㋒�_��I�����܂�";
            ultraExplorerBarGroup1.Visible = false;
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup2.Key = "SectionRange";
            ultraExplorerBarGroup2.Settings.ContainerHeight = 50;
            ultraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup2.Text = "�o�͋��_�͈̔͂��w�肵�܂�";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup3.Expanded = false;
            ultraExplorerBarGroup3.Key = "SectionList";
            ultraExplorerBarGroup3.Settings.ContainerHeight = 316;
            ultraExplorerBarGroup3.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup3.Text = "�o�͑Ώۋ��_��I�����܂�";
            ultraExplorerBarGroup3.Visible = false;
            ultraExplorerBarGroup4.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup4.Key = "SystemList";
            ultraExplorerBarGroup4.Settings.ContainerHeight = 71;
            ultraExplorerBarGroup4.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup4.Text = "�V�X�e����I�����܂�";
            ultraExplorerBarGroup4.Visible = false;
            this.SelectExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3,
            ultraExplorerBarGroup4});
            this.SelectExplorerBar.GroupSpacing = 5;
            this.SelectExplorerBar.Location = new System.Drawing.Point(0, 27);
            this.SelectExplorerBar.Name = "SelectExplorerBar";
            this.SelectExplorerBar.ShowDefaultContextMenu = false;
            this.SelectExplorerBar.Size = new System.Drawing.Size(250, 621);
            this.SelectExplorerBar.TabIndex = 0;
            this.SelectExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XPExplorerBar;
            // 
            // SFUKK06180U_Fill_Panel
            // 
            this.SFUKK06180U_Fill_Panel.Controls.Add(this.Main_TabControl);
            this.SFUKK06180U_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFUKK06180U_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFUKK06180U_Fill_Panel.Location = new System.Drawing.Point(22, 63);
            this.SFUKK06180U_Fill_Panel.Name = "SFUKK06180U_Fill_Panel";
            this.SFUKK06180U_Fill_Panel.Size = new System.Drawing.Size(994, 648);
            this.SFUKK06180U_Fill_Panel.TabIndex = 0;
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_TabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_TabControl.Location = new System.Drawing.Point(0, 0);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_TabControl.Size = new System.Drawing.Size(994, 648);
            this.Main_TabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_TabControl.TabIndex = 0;
            this.Main_TabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Main_TabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Main_TabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_TabControl.TabMoved += new Infragistics.Win.UltraWinTabControl.TabMovedEventHandler(this.Main_TabControl_TabMoved);
            this.Main_TabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_TabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(992, 627);
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockAreaPane1.DockedBefore = new System.Guid("14433859-0725-4ebd-a557-fdb6711dcbf4");
            dockableControlPane1.Control = this.StartNavigatorTree;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane1.Key = "StartNavigator";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(12, 156, 250, 274);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance3.FontData.SizeInPoints = 10F;
            dockableControlPane1.Settings.Appearance = appearance3;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "�N���i�r�Q�[�^";
            dockableControlPane1.ToolTipCaption = "�o�͂��钠�[��I�����܂��B";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(250, 648);
            dockAreaPane2.DockedBefore = new System.Guid("524f5fb4-ad59-49eb-97a6-66081c3c8354");
            dockableControlPane2.Control = this.PdfHistory_Panel;
            dockableControlPane2.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane2.Key = "PdfHistory";
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(21, 14, 250, 354);
            dockableControlPane2.Pinned = false;
            dockableControlPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance4.FontData.SizeInPoints = 10F;
            dockableControlPane2.Settings.Appearance = appearance4;
            dockableControlPane2.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "�o�͍ςݒ��[����";
            dockableControlPane2.ToolTipCaption = "�ߋ��ɏo�͂������[�̌������s���܂��B";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(250, 648);
            dockableControlPane3.Control = this.SelectExplorerBar;
            dockableControlPane3.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane3.Key = "SelectCondition";
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(17, 7, 250, 621);
            dockableControlPane3.Pinned = false;
            dockableControlPane3.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance5.FontData.SizeInPoints = 10F;
            dockableControlPane3.Settings.Appearance = appearance5;
            dockableControlPane3.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane3.Size = new System.Drawing.Size(100, 100);
            dockableControlPane3.Text = "�o�͏����I��";
            dockableControlPane3.ToolTipCaption = "���[�̏o�͏�����I�����܂��B";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane3.Size = new System.Drawing.Size(250, 648);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            this.Main_DockManager.PaneDisplayed += new Infragistics.Win.UltraWinDock.PaneDisplayedEventHandler(this.Main_DockManager_PaneDisplayed);
            // 
            // _SFANL07200UAUnpinnedTabAreaLeft
            // 
            this._SFANL07200UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFANL07200UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 63);
            this._SFANL07200UAUnpinnedTabAreaLeft.Name = "_SFANL07200UAUnpinnedTabAreaLeft";
            this._SFANL07200UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 648);
            this._SFANL07200UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _SFANL07200UAUnpinnedTabAreaRight
            // 
            this._SFANL07200UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFANL07200UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 63);
            this._SFANL07200UAUnpinnedTabAreaRight.Name = "_SFANL07200UAUnpinnedTabAreaRight";
            this._SFANL07200UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 648);
            this._SFANL07200UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _SFANL07200UAUnpinnedTabAreaTop
            // 
            this._SFANL07200UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFANL07200UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 63);
            this._SFANL07200UAUnpinnedTabAreaTop.Name = "_SFANL07200UAUnpinnedTabAreaTop";
            this._SFANL07200UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(994, 0);
            this._SFANL07200UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _SFANL07200UAUnpinnedTabAreaBottom
            // 
            this._SFANL07200UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFANL07200UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 711);
            this._SFANL07200UAUnpinnedTabAreaBottom.Name = "_SFANL07200UAUnpinnedTabAreaBottom";
            this._SFANL07200UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(994, 0);
            this._SFANL07200UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _SFANL07200UAAutoHideControl
            // 
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow3);
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow2);
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow4);
            this._SFANL07200UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._SFANL07200UAAutoHideControl.Name = "_SFANL07200UAAutoHideControl";
            this._SFANL07200UAAutoHideControl.Owner = this.Main_DockManager;
            this._SFANL07200UAAutoHideControl.Size = new System.Drawing.Size(55, 648);
            this._SFANL07200UAAutoHideControl.TabIndex = 9;
            // 
            // dockableWindow3
            // 
            this.dockableWindow3.Location = new System.Drawing.Point(-10000, 0);
            this.dockableWindow3.Name = "dockableWindow3";
            this.dockableWindow3.Owner = this.Main_DockManager;
            this.dockableWindow3.Size = new System.Drawing.Size(250, 648);
            this.dockableWindow3.TabIndex = 36;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.PdfHistory_Panel);
            this.dockableWindow1.Location = new System.Drawing.Point(-10000, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(250, 648);
            this.dockableWindow1.TabIndex = 37;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.StartNavigatorTree);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.Main_DockManager;
            this.dockableWindow2.Size = new System.Drawing.Size(250, 648);
            this.dockableWindow2.TabIndex = 36;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 711);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance7.TextHAlignAsString = "Center";
            this.Main_StatusBar.PanelAppearance = appearance7;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel2.Key = "Date";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel2.Width = 90;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "Time";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel3.Width = 50;
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.Main_StatusBar.Size = new System.Drawing.Size(1016, 23);
            this.Main_StatusBar.TabIndex = 15;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "����(&C)";
            this.Close_menuItem.Click += new System.EventHandler(this.Close_menuItem_Click);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.TabEnable = false;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // uiSetControl
            // 
            this.uiSetControl.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl.OwnerForm = this;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(255, 648);
            this.windowDockingArea1.TabIndex = 16;
            // 
            // windowDockingArea3
            // 
            this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea3.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea3.Name = "windowDockingArea3";
            this.windowDockingArea3.Owner = this.Main_DockManager;
            this.windowDockingArea3.Size = new System.Drawing.Size(255, 648);
            this.windowDockingArea3.TabIndex = 26;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea2.Location = new System.Drawing.Point(277, 63);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.Main_DockManager;
            this.windowDockingArea2.Size = new System.Drawing.Size(255, 648);
            this.windowDockingArea2.TabIndex = 31;
            // 
            // dockableWindow4
            // 
            this.dockableWindow4.Controls.Add(this.SelectExplorerBar);
            this.dockableWindow4.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow4.Name = "dockableWindow4";
            this.dockableWindow4.Owner = this.Main_DockManager;
            this.dockableWindow4.Size = new System.Drawing.Size(0, 0);
            this.dockableWindow4.TabIndex = 38;
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Left
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFANL07200UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFANL07200UA_Toolbars_Dock_Area_Left.Name = "_SFANL07200UA_Toolbars_Dock_Area_Left";
            this._SFANL07200UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._SFANL07200UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            labelTool2.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            buttonTool13.SharedProps.Caption = "�I��(F1)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool14.SharedProps.Caption = "���(F10)";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool15.SharedProps.Caption = "PDF�\��(F11)";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            popupMenuTool3.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool19.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19});
            labelTool5.SharedProps.Caption = "���O�C���S����";
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Bottom";
            labelTool6.SharedProps.AppearancesSmall.Appearance = appearance6;
            labelTool6.SharedProps.Width = 150;
            buttonTool20.SharedProps.Caption = "���o(&E)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool4.SharedProps.Caption = "�E�B���h�E(&W)";
            popupMenuTool5.SharedProps.Caption = "�^�u�ؑ�(&J)";
            popupMenuTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool5.SharedProps.ToolTipText = "��ʂ�؂�ւ��܂��B";
            buttonTool21.SharedProps.Caption = "PDF����ۑ�(F12)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool22.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Enabled = false;
            buttonTool23.SharedProps.Caption = "�O���t�\��(&G)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Visible = false;
            buttonTool24.SharedProps.Caption = "�ݒ�(&O)";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool24.SharedProps.Visible = false;
            buttonTool25.SharedProps.Caption = "�m��(&A)";
            buttonTool25.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool25.SharedProps.Enabled = false;
            buttonTool25.SharedProps.Visible = false;
            buttonTool26.SharedProps.Caption = "�K�C�h(F5)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            buttonTool26.SharedProps.Visible = false;
            buttonTool27.SharedProps.Caption = "�ؑ�(F2)";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            buttonTool28.SharedProps.Caption = "����(F3)";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool13,
            buttonTool14,
            buttonTool15,
            popupMenuTool3,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool20,
            popupMenuTool4,
            popupMenuTool5,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            buttonTool28});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Right
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFANL07200UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFANL07200UA_Toolbars_Dock_Area_Right.Name = "_SFANL07200UA_Toolbars_Dock_Area_Right";
            this._SFANL07200UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._SFANL07200UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Top
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFANL07200UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFANL07200UA_Toolbars_Dock_Area_Top.Name = "_SFANL07200UA_Toolbars_Dock_Area_Top";
            this._SFANL07200UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._SFANL07200UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.Name = "_SFANL07200UA_Toolbars_Dock_Area_Bottom";
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // SFANL07200UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._SFANL07200UAAutoHideControl);
            this.Controls.Add(this.SFUKK06180U_Fill_Panel);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this.windowDockingArea3);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaRight);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SFANL07200UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���[";
            this.Load += new System.EventHandler(this.SFANL07200UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SFANL07200UA_FormClosed);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).EndInit();
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).EndInit();
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.System_UTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).EndInit();
            this.SelectExplorerBar.ResumeLayout(false);
            this.SFUKK06180U_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).EndInit();
            this.Main_TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this._SFANL07200UAAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.dockableWindow4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ===============================================================================
        // �f���Q�[�g�錾
        // ===============================================================================
        #region �f���Q�[�g�錾
        /// <summary>�v�㋒�_�I���C�x���g�p�f���Q�[�g</summary>
        /// <param name="checkState">�I���v�㋒�_(1:���� 2:����)</param>
        private delegate void CheckedAddUpEventHandler(int AddUpCd);

        /// <summary>���_�I���C�x���g�p�f���Q�[�g</summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="checkState">�`�F�b�N���</param>
        private delegate void CheckedSectionEventHandler(string sectionCode, CheckState checkState);

        /// <summary>�V�X�e���I���C�x���g�p�f���Q�[�g</summary>
        /// <param name="sectionCode">�V�X�e���R�[�h</param>
        /// <param name="checkState">�`�F�b�N���</param>
        private delegate void CheckedSystemEventHandler(int sysCode, CheckState checkState);

        /// <summary>�������_�ݒ�p�f���Q�[�g</summary>
        /// <param name="sectionCodeLst">���_�R�[�h���X�g</param>
        private delegate void InitSelectSectionEventHandler(string[] sectionCodeLst);
        #endregion

        // ===============================================================================
        // �v���C�x�[�g�ϐ�
        // ===============================================================================
        #region private member
        internal static string[] _parameter;																				// �N���p�����[�^
        private bool _navigaterMenuMode = false;						// �N���i�r�Q�[�^�[���[�h
        private string _enterpriseCode = "";
        private Employee _loginEmployee = null;
        private string _loginSectionCode = "";								// ���O�C�����_�R�[�h


        private Hashtable _formControlInfoTable = new Hashtable();
        private Hashtable _introduceSystem = null;							// �����V�X�e��
        private Hashtable _setPdfKeyList = new Hashtable();	// �o�͗��������pKEY���X�g(KEY:���[KEY, Value:���[DLL)

        private int[] _introduceSystemCdLst = null;							// �����V�X�e���R�[�h���X�g

        private Point _lastMouseDown;
        private static System.Windows.Forms.Form _form = null;

        private bool _isOptSection = false;						// ���_�I�v�V�����t���O	
        private bool _isMainOfficeFunc = false;						// �{�Ћ@�\�L��
        private bool _isOptTextOutPut = false;													// �e�L�X�g�o�̓I�v�V�����t���O

        private SortedList _secInfoLst = null;							// ���_��񃊃X�g
        private SecInfoAcs _secInfoAcs = null;							// ���_���擾�A�N�Z�X�N���X

        private bool _isEvent = false;
        private bool _secNodeCheckEvent = false;						// ���_�I���C�x���g�����t���O				
        private bool _sysNodeCheckEvent = false;						// �V�X�e���I���C�x���g�����t���O

        private bool _isDefaultSectionSelect = false;						// �f�t�H���g���_�I��\���t���O
        private bool _isDefaultSystemSelect = false;						// �f�t�H���g�V�X�e���I��\���t���O

        private SFANL06101UA _pdfHistorySerchForm = null;							// PDF�����������

#if false
		private CheckedAddUpEventHandler _checkedAddUpEvent     = null;							// �v�㋒�_�I���C�x���g
		private CheckedSectionEventHandler _checkedSectionEvent = null;							// ���_�I���C�x���g
		private CheckedSystemEventHandler _checkedSystemEvent   = null;							// �V�X�e���I���C�x���g
		private InitSelectSectionEventHandler _initSelectSectionEvent = null;				// �����ݒ苒�_�C�x���g
#endif
        private PrtOutSetAcs _prtOutSetAcs = null;							// ���[�o�͐ݒ�A�N�Z�X�N���X
        private PrtOutSet _prtOutSet = null;							// ���[�o�͐ݒ�f�[�^�N���X
        private ArrayList _arDefultSecKind = null;							// �����I�����_��ރ��X�g
        private MemoryStream _dockMemoryStream = null;							// DocManager�����ۑ����
        private NoMngSetAcs _noMngSetAcs = null;																		// �ԍ��^�C�v�Ǘ��}�X�^

        private Hashtable _delPDFList = null;							// �폜PDF�i�[���X�g

        // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        private SortedList<int, string> _slDefSoftWareCode = null;							// �f�t�H���g�I���\�V�X�e��
        // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

        private SFANL07200UE _userSetupFrm = null;																	// ���[�U�[�ݒ���
        internal static ControlScreenSkin mControlScreenSkin = null;												// ��ʃX�L���ύX���i 

        // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------>>>>
        private OperationHistoryLog operationHistoryLog = null;
        private ClientLogTextOut clientLogTextOut = null;
        // ���O�f�[�^��ʋ敪�R�[�h�F2�i���j���[���O�o�́j
        private const int MenuLog = 2;
        private const int OperationCode = 0;
        private const string DateMessage = "{0},{1},{2},{3},";
        private const string MethodName = "StartNavigatorTree_DoubleClick";
        private const string ErrMessageInit = "���O�o�͕��i�������G���[";
        private const string ErrMessage = ":�N��PG���O�o�̓G���[";
        // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------<<<<

        // >>>>> 2008.09.05 T.Kudoh ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        /// <summary>���쌠���̐���I�u�W�F�N�g�̃}�b�v</summary>
        /// <remarks>�L�[�F�v���O����ID</remarks>
        private readonly OperationAuthorityControllableMap<ReportController>
            _myOpeCtrlMap = new OperationAuthorityControllableMap<ReportController>();
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g�̃}�b�v</value>
        private OperationAuthorityControllableMap<ReportController> MyOpeCtrlMap
        {
            get { return _myOpeCtrlMap; }
        }
        // <<<<< 2008.09.05 T.Kudoh ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

        private bool _dckauFlag = false; //����\��\  //ADD 2011/03/14
        #endregion

        // ===============================================================================
        // �v���C�x�[�g�萔
        // ===============================================================================
        #region private constant
        private const string CT_PGID = "SFANL07200U";
        private const string MAIN_TITLE = "���[";
        private const string NAVIGATORTREE_XML = "SFANL07200U_Navigator.Dat";

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_WINDOW_KEY = "Window_PopupMenuTool";
        private const string TOOLBAR_FORMS_KEY = "Forms_PopupMenuTool";
        private const string TOOLBAR_RESETBUTTON_KEY = "Reset_ButtonTool";

        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_PRINTBUTTON_KEY = "Print_ButtonTool";
        private const string TOOLBAR_EXTRABUTTON_KEY = "Extract_ButtonTool";
        private const string TOOLBAR_PDFBUTTON_KEY = "Pdf_ButtonTool";
        private const string TOOLBAR_PDFSAVEBUTTON_KEY = "PDFSave_ButtonTool";
        private const string TOOLBAR_TEXTOUTPUTBUTTON_KEY = "TextOutPut_ButtonTool";		// 2006.09.01 Y.Sasaki ADD
        private const string TOOLBAR_UPDATEBUTTON_KEY = "Update_ButtonTool";		// 2008.11.12 Y.Shinobu ADD
        private const string TOOLBAR_GRAPHBUTTON_KEY = "Graph_ButtonTool";
        private const string TOOLBAR_SETUPBUTTON_KEY = "Setup_ButtonTool";

        // ---ADD 2010/08/16-------------------->>>
        // �K�C�h
        private const string TOOLBAR_GUIDEBUTTON_KEY = "Guide_ButtonTool";
        // �ؑ�
        private const string TOOLBAR_CHANGEBUTTON_KEY = "Change_ButtonTool";
        // ����
        private const string TOOLBAR_NEXTPAGEBUTTON_KEY = "NextPage_ButtonTool";
        // ---ADD 2010/08/16--------------------<<<

        // �h�b�N�}�l�[�W���[�L�[�ݒ�
        private const string DOCKMANAGER_NAVIGATOR_KEY = "StartNavigator";
        private const string DOCKMANAGER_SELECTCONDITION_KEY = "SelectCondition";
        private const string DOCKMANAGER_PDFHISTORTY_KEY = "PdfHistory";

        // �G�N�X�v���[���[�o�[�L�[�ݒ�
        private const string EXPLORERBAR_ADDUPCDLIST = "AddUpCdList";
        private const string EXPLORERBAR_SECTIONRANGE = "SectionRange";              // 2008.09.09 T.Kudoh ADD
        private const string EXPLORERBAR_SECTIONLIST = "SectionList";
        private const string EXPLORERBAR_SYSTEMLIST = "SystemList";

        // �r���[�t�H�[���p�ǉ��L�[���(�ΏۃA�Z���u��_VIEWR)
        private const string TAB_VIEWFORM_ADDKEY = "_VIWER";

        // �`���[�g�r���[�t�H�[���p�ǉ��L�[���(�ΏۃA�Z���u��_CHART)
        private const string TAB_CHARTVIEWFORM_ADDKEY = "_CHART";

        // �S�Ћ��_�R�[�h
        private const string CT_AllSectionCode = "0";

        // ���_�I����ރJ���������^�C�g��
        private const string CT_EXPLORERBAR_ADDUPCDLIST_TITLE = "�v�㋒�_��I�����܂��B";

        // �S���_�R�[�h
        private const string CT_AllCtrlFuncSecCode = "000000";	// 2006.09.26 Y.Sasaki ADD
        // >>>>> 2008.09.05 T.Kudoh ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        private const string CT_AllCtrlFuncSecName = "�S��";
        private const string SECTION_CODE_FORMAT = "00";

        // ���_�R�[�h�͈̔�
        private const string DEFAULT_START_SECTION_NAME = "�ŏ�����";
        private const string DEFAULT_END_SECTION_NAME = "�Ō�܂�";
        private const int MIN_SECTION_CODE = 1;
        private const int MAX_SECTION_CODE = 99;
        // <<<<< 2008.09.05 T.Kudoh ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        #endregion

        // ===============================================================================
        // �v���C�x�[�g�񋓌^
        // ===============================================================================
        #region private enum
        /// <summary>������[�h</summary>
        private enum emPrintMode : int
        {
            /// <summary>���</summary>
            emPrinter = 1,
            /// <summary>�o�c�e</summary>
            emPDF = 2,
            /// <summary>������o�c�e</summary>
            emPrinterAndPDF = 3
        }
        #endregion

        // ===============================================================================
        // ���C��
        // ===============================================================================
        #region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;
                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // �I�����C����Ԕ���
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        // �I�t���C�����
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID,
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new SFANL07200UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, -1, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();
            //�]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFUKK06180U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFUKK06180U", e.ToString(), 0, MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        // ===============================================================================
        // �f���Q�[�g�C�x���g
        // ===============================================================================
        #region delegateEvent
        private void ParentToolbarSettingEvent(object sender)
        {
            this.ToolBarSetting(sender);
        }

        // --- 2010/08/16 ---------->>>>>
        private void ParentToolbarGuideSettingEvent(bool enabled)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (buttonTool != null)
            {
                buttonTool.SharedProps.Enabled = enabled;
            }
        }
        // --- 2010/08/16 ----------<<<<<
        #endregion

        // ===============================================================================
        // �������\�b�h
        // ===============================================================================
        #region private method

        #region ���@�����ݒ�n�f�[�^READ����
        /// <summary>
        /// �����ݒ�n�f�[�^READ����
        /// </summary>
        /// <returns></returns>
        /// <br>Note       : �����ݒ�n�̃f�[�^�Ǎ��������s���܂��B
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.27</br>
        private int InitialSettingDBRead(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                message = "���[�ݒ�f�[�^�̓Ǎ��Ɏ��s���܂����B";

                // ���[�ݒ�f�[�^READ
                status = this._prtOutSetAcs.Read(out this._prtOutSet, this._enterpriseCode, this._loginSectionCode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            message = String.Format("���_�R�[�h�F[0]", this._loginSectionCode) + "\n\r" + "���[�o�͐ݒ���s���Ă��������B";
                            break;
                        }
                    default:
                        message = "���[�ݒ�f�[�^�̓Ǎ��Ɏ��s���܂����B";
                        break;
                }

                // �ԍ��^�C�v�Ǘ��}�X�^READ
                message = "�ԍ��^�C�v�Ǘ��}�X�^�̓Ǎ��Ɏ��s���܂����B";

                ArrayList retNoTypMngList;
                status = this._noMngSetAcs.Search(out retNoTypMngList, LoginInfoAcquisition.EnterpriseCode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            NumberControl.NoTypeMngList = retNoTypMngList.ToArray(typeof(NoTypeMng)) as NoTypeMng[];
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                message += "\n\r" + ex.Message;
            }


            return status;
        }
        #endregion

        #region ���@�N���i�r�Q�[�^�c���[���\�z����
        /// <summary>
        /// �c���[���\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c���[�����\�z���܂��B
        ///					�i�Q�K�w�ڂ̕\����\���`�F�b�N�A�R�K�w�ڂ̃J���[�ݒ�j</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.19</br>
        /// <br>Update Note: 2011/12/15 �����x</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
        /// </remarks>
        private void ConstructionTreeNode()
        {
            // �N���i�r�Q�[�^��񂪊i�[���ꂽ�o�C�i���t�@�C���̃��[�h
            if (System.IO.File.Exists(NAVIGATORTREE_XML))
            {
                this.StartNavigatorTree.LoadFromBinary(NAVIGATORTREE_XML);
            }

            this.StartNavigatorTree.Appearance.BackColor = Color.White;
            this.StartNavigatorTree.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(255)));
            this.StartNavigatorTree.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.StartNavigatorTree.HideSelection = false;
            bool firstNode = true;

            Hashtable delNode2KeyLst = new Hashtable();
            Hashtable delNode3KeyLst = new Hashtable();

            // �m�[�h�̕\����\���𐧌䂷��
            if (_parameter.Length != 0)
            {
                // �I���m�[�h��擪�Ɉړ�������
                firstNode = this.StartNavigatorTree.PerformAction(
                    Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                    false,
                    false);

                if (!firstNode)
                {
                    return;
                }

                //----------------------------------------------------------------------------//
                // �����V�X�e���̃`�F�b�N                                                     //
                //----------------------------------------------------------------------------//
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    if (utn1.Nodes.Count != 0)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/15 Redmine#27268
                                    bool nodeVisible = false;
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
#if false		// USB��Company�`�F�b�N�֕ύX
                      if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
                      {
#else
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
#endif
                                                nodeVisible = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!nodeVisible)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }

                                if (utn2.Nodes.Count == 0)
                                {
                                    if (!delNode2KeyLst.ContainsKey(utn2.Key))
                                    {
                                        delNode2KeyLst.Add(utn2.Key, utn2);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //----------------------------------------------------------------------------//
            // �O���[�v�̕\����\���𐧌䂷��                                             //
            //----------------------------------------------------------------------------//
            // �I���m�[�h��擪�Ɉړ�������
            firstNode = this.StartNavigatorTree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);

            if (!firstNode)
            {
                return;
            }


            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    utn1.Expanded = true;

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        bool utn2DeleteFlg = true;

                        // �p�����[�^���󔒂̏ꍇ�͑S�m�[�h��\������i�f���o�����ɂ͔�\���Ƃ���j
                        if (_parameter.Length == 0)
                        {
                            utn2DeleteFlg = false;
                        }
                        else
                        {
                            // Key�l��null�̏ꍇ�͔�\���Ƃ���
                            if (utn2.Key != null)
                            {

                                for (int i = 0; i < _parameter.Length; i++)
                                {
                                    //----------------------------------------------------------------------------//
                                    // �p�����[�^��100�Ŋ������]��ɂ��A�O���[�v�N�����P�̋N��������            //
                                    // �[���Ȃ��F�O���[�v                                                         //
                                    // �[������F�P��(���������݂���ꍇ�͐e�O���[�v���\��)                       //
                                    //----------------------------------------------------------------------------//
                                    string strPara = SFANL07200UA._parameter[i];
                                    int intPara = TStrConv.StrToIntDef(SFANL07200UA._parameter[i], -1);

                                    if ((intPara % 100) != 0)
                                    {
                                        intPara = (intPara / 100) * 100;
                                        strPara = intPara.ToString();
                                    }
                                    if (utn2.Key.ToString() == strPara)
                                    {
                                        utn2DeleteFlg = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (utn2DeleteFlg == true)
                        {
                            if (!delNode2KeyLst.ContainsKey(utn2.Key))
                            {
                                delNode2KeyLst.Add(utn2.Key, utn2);
                            }
                        }
                        else
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                // �p�����[�^���󔒈ȊO�ꍇ�̓m�[�h��W�J����
                                if (_parameter.Length != 0)
                                {
                                    utn2.Expanded = true;
                                }

                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/15 Redmine#27268
                                    bool utn3DeleteFlg = true;

                                    // �p�����[�^���󔒂̏ꍇ�͑S�m�[�h��\������i�f���o�����ɂ͔�\���Ƃ���j
                                    if (_parameter.Length == 0)
                                    {
                                        utn3DeleteFlg = false;
                                    }

                                    // Key�l��null�̏ꍇ�͔�\���Ƃ���
                                    if (utn3.Key != null)
                                    {
                                        for (int i = 0; i < _parameter.Length; i++)
                                        {

                                            //----------------------------------------------------------------------------//
                                            // �p�����[�^��100�Ŋ������]��ɂ��A�O���[�v�N�����P�̋N��������            //
                                            // �[���Ȃ��F�O���[�v                                                         //
                                            // �[������F�P��(���������݂���ꍇ�͐e�O���[�v���\��)                       //
                                            //----------------------------------------------------------------------------//
                                            string strPara = SFANL07200UA._parameter[i];
                                            int intPara = TStrConv.StrToIntDef(SFANL07200UA._parameter[i], -1);

                                            if ((intPara % 100) != 0)
                                            {
                                                if (utn3.Key.ToString() == strPara)
                                                {
                                                    utn3DeleteFlg = false;
                                                    utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                utn3DeleteFlg = false;
                                                utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                break;
                                            }
                                        }
                                    }
                                    if (utn3DeleteFlg == true)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ��O�K�w���폜
            foreach (DictionaryEntry entry in delNode3KeyLst)
            {
                // �폜�Ώۃm�[�h
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn.Parent.Key == utn2.Key)
                        {
                            utn2.Nodes.Remove(utn);
                            break;
                        }
                    }
                }
            }

            // ���K�w���폜
            foreach (DictionaryEntry entry in delNode2KeyLst)
            {
                // �폜�Ώۃm�[�h
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    utn1.Nodes.Remove(utn);
                }
            }

            this.StartNavigatorTree.ExpandAll();
        }
        #endregion

        #region ���@��ʃR���g���[���N���X�쐬����
        /// <summary>
        /// ��ʃR���g���[���N���X�쐬����
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note       : �e�������ʂ̃A�Z���u�������쐬���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private int CreateFormControlInfo()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (this.StartNavigatorTree.Nodes.Count == 0) return status;

            this._formControlInfoTable.Clear();

            FormControlInfo info = null;

            // �I���m�[�h��擪�Ɉړ�������
            bool result = this.StartNavigatorTree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);
            if (!result)
            {
                return status;
            }

            // �c���[�̃m�[�h�������ɁA�v���O�������R���N�V�����N���X���\�z����

            // �c���[�̃m�[�h���擾������͈ȉ��̒ʂ�
            // [DataKey:�A�Z���u������]
            // [Override.Tag:�N���X������]
            // [Text:�v���O��������]
            // [Tag:���䋒�_�R�[�h]
            // [Tag:���䋒�_�R�[�h]

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn2.Nodes.Count != 0)
                        {
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                            {
                                if (utn3.DataKey != null && utn3.DataKey.ToString().Trim() != "")
                                {
                                    // �A�Z���u��ID,�p�����[�^
                                    string target = utn3.DataKey.ToString();
                                    string assemblyID;
                                    string param;

                                    this.SplitTargetAssemblyID(target, out assemblyID, out param);
                                    // ����R�[�h
                                    int ctrlFuncCode = 0;
                                    if (utn3.Tag != null)
                                    {
                                        ctrlFuncCode = TStrConv.StrToIntDef(utn3.Tag.ToString(), 0);
                                    }

                                    // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                                    // �I���\�V�X�e�����̎擾
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });
                                    List<int> softWareCodeList = new List<int>(split.Length);

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
                                                switch (productCode)
                                                {
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_SF:
                                                        softWareCodeList.Add(1);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_BK:
                                                        softWareCodeList.Add(2);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_CS:
                                                        softWareCodeList.Add(3);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                                    // >>>>> 2006.08.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                                    // �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                                    info = new FormControlInfo(utn3.DataKey.ToString(),
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text,
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());
                                    //// �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                                    //info = new FormControlInfo(utn3.DataKey.ToString(),
                                    //  assemblyID,
                                    //  utn3.Override.Tag.ToString(),
                                    //  utn3.Text,
                                    //  utn3.Override.NodeAppearance.Image,
                                    //  ctrlFuncCode,
                                    //  param);
                                    // <<<<< 2006.08.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                                    Debug.WriteLine("<<" + utn3.DataKey.ToString() + ">> " + (info == null ? "null" : "OK"));
                                    this._formControlInfoTable.Add(utn3.DataKey.ToString(), info);

                                    utn3.Key = utn3.DataKey.ToString();
                                }
                            }
                        }
                    }
                }
            }

            // �v���O�������͐ݒ肳��Ă��邩
            status = (this._formControlInfoTable.Count == 0 ? (int)ConstantManagement.MethodResult.ctFNC_ERROR : (int)ConstantManagement.MethodResult.ctFNC_NORMAL);
            return status;
        }
        #endregion

        #region ���@�����񕪊�����
        /// <summary>
        /// �����񕪊�����
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <param name="id">���������P</param>
        /// <param name="prm">���������Q</param>
        /// <remarks>
        /// <br>Note       : �Ώە�������X�y�[�X�łQ�������܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.10</br>
        /// </remarks>
        private void SplitTargetAssemblyID(string target, out string id, out string prm)
        {
            id = "";
            prm = "";

            string[] split = target.Split(new Char[] { ' ' });
            if (split != null)
            {
                int i = 0;
                foreach (string wk in split)
                {
                    switch (i)
                    {
                        case 0:		// �A�Z���u��ID
                            {
                                id = wk;
                                break;
                            }
                        default:	// �ďo�p�����[�^
                            {
                                if (prm != "")
                                {
                                    prm += " " + wk;
                                }
                                else
                                {
                                    prm = wk;
                                }
                                break;
                            }
                    }
                    i++;
                }
            }
        }
        #endregion

        #region ���@�h�b�N�}�l�[�W���[�����ݒ菈��
        /// <summary>
        /// �h�b�N�}�l�[�W���[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �h�b�N�}�l�[�W���[�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void InitSettingDockManager()
        {
            //--- �h�b�N�}�l�[�W���[�̃A�C�R���ݒ�
            // �N���i�r�Q�[�^
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Settings.Appearance.Image = Size16_Index.TREE;

            // �o�͏����I��
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Settings.Appearance.Image = Size16_Index.TREE;

            // �o�͏����I��
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Settings.Appearance.Image = Size16_Index.PRINT;
        }
        #endregion

        #region ���@�c�[���o�[�����ݒ菈��
        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// <br>UpdateNote : �L�[�{�[�h����̉��ǂ��s��</br>
        /// <br>Programmer : PM1012C �� ��</br>
        /// <br>Date       : 2010/08/16</br>
        /// </remarks>
        private void InitSettingToolBar()
        {
            // �c�[���o�[�A�C�R���̐ݒ�
            this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            // ���O�C���S���҂ւ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ���O�C���S���Җ��ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (loginEmployeeName != null && this._loginEmployee != null)
            {
                loginEmployeeName.SharedProps.Caption = this._loginEmployee.Name;
            }

            // �I���̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_ENDBUTTON_KEY];
            if (closeButton != null) closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // ����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // ���o�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool extraButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
            if (extraButton != null) extraButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // PDF�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
            if (pdfButton != null) pdfButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // PDF����ۑ��̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfSaveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (pdfSaveButton != null) pdfSaveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // �e�L�X�g�o�͂̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool textOutPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
            if (textOutPutButton != null) textOutPutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // ���s�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
            if (updateButton != null) updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // �O���t�\���̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool graphButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
            if (graphButton != null) graphButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;

            // ���[�U�[�ݒ�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setUpButton != null) setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ---ADD 2010/08/16-------------------->>>
            // �K�C�h�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (guideButton != null) guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            // �ؑւ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool changeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_CHANGEBUTTON_KEY];
            if (changeButton != null) changeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;

            // ���ł̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool nextPageButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_NEXTPAGEBUTTON_KEY];
            if (nextPageButton != null) nextPageButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            // ---ADD 2010/08/16--------------------<<<
        }
        #endregion

        #region ���@���_���I�����X�g�ݒ菈��
        /// <summary>
        /// ���_���I�����X�g�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���I�����X�g�̍쐬���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.18</br>
        /// </remarks>
        private void InitSettingSectionTree()
        {
            // ���_�I���E�v�㋒�_�I�����\��
            this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
            this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
            this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = false; // ADD 2008/09/19 �s��Ή�[5528]

            // ���_�I�v�V�����L���`�F�b�N
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                this._isOptSection = true;
            }
            else
            {
                this._isOptSection = false;
            }

#if DEBUG
            this._isOptSection = true;
#endif

            // ���_�I�v�V�����L��
            if (this._isOptSection)
            {

                // �{�Ћ@�\�H
                // 2008.12.26 [9574]
                //this._isMainOfficeFunc = (this._secInfoAcs.GetMainOfficeFuncFlag(this._loginSectionCode) == 1);
                this._isMainOfficeFunc = true;  // �{�Ћ@�\����
                // 2008.12.26 [9574]
                if (this._isMainOfficeFunc)
                {
                    // ���_�I���E�v�㋒�_�I�����\��
                    this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = true;
                    this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
                    this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = true;  // ADD 2008/09/19 �s��Ή�[5528]

                    // ���_��񃊃X�g�쐬
                    this._secInfoLst = new SortedList();
                    if (this._secInfoLst != null)
                    {
                        for (int i = 0; i < this._secInfoAcs.SecInfoSetList.Length; i++)
                        {
                            this._secInfoLst.Add(this._secInfoAcs.SecInfoSetList[i].SectionCode.TrimEnd(), this._secInfoAcs.SecInfoSetList[i].Clone());
                            // HACK:���f�o�b�O�p�����c1���_�݂̂Ƃ���ꍇ�A�L���ɂ���
#if _ONE_SECTION_ONLY_
                            break;
#endif
                        }
                    }

                    // ���_�c���[�쐬
                    this.Section_UTree.ShowLines = false;

                    // TODO:�������_���݂���ꍇ�A�S�Ђ�ݒ�
                    // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ---------->>>>>
                    //if (this._secInfoLst.Count > 1)
                    // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ----------<<<<<
                    // ADD 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ---------->>>>>
                    if (this._secInfoLst.Count > 0)
                    // ADD 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ----------<<<<<
                    {
                        //this.Section_UTree.Nodes.Add(CT_AllSectionCode,"�S��");               // 2008.09.05 T.Kudoh DEL
                        this.Section_UTree.Nodes.Add(CT_AllSectionCode, CT_AllCtrlFuncSecName); // 2008.09.05 T.Kudoh ADD
                        this.Section_UTree.Nodes[CT_AllSectionCode].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    foreach (DictionaryEntry entry in this._secInfoLst)
                    {
                        SecInfoSet secInfoSet = (SecInfoSet)entry.Value;

                        // >>>>> 2008.09.05 T.Kudoh ADD and DEL START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        //this.Section_UTree.Nodes.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm);
                        string key = secInfoSet.SectionCode.TrimEnd();
                        string text = key + ":" + secInfoSet.SectionGuideNm;
                        this.Section_UTree.Nodes.Add(key, text);
                        // <<<<< 2008.09.05 T.Kudoh ADD and DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                        this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ---------->>>>>
                    // ADD 2009/12/25 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�� ---------->>>>>
                    //// ���_����̏ꍇ�A���̋��_�ɌŒ�
                    //if (this.Section_UTree.Nodes.Count.Equals(1))
                    //{
                    //    this.Section_UTree.Nodes[0].CheckedState = CheckState.Checked;
                    //    this.Section_UTree.Enabled = false;
                    //}
                    // ADD 2009/12/25 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�� ----------<<<<<
                    // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ----------<<<<<
                }
            }
        }
        #endregion

        #region ���@�o�͑Ώۋ��_�͈̔͂̏����ݒ�

        /// <summary>
        /// �o�͑Ώۋ��_�͈̔͂��w�肷��R���g���[���̏����ݒ���s���܂��B
        /// </summary>
        /// <param name="loading">���[�h���̃t���O</param>
        /// <remarks>
        /// <br>Note       : ���[�t���[���C��</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2008.09.05</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>
        /// <br>             ����\��\�ŁA��ʓ��͓��e��XML�ɕۑ����A
        /// <br> �@�@�@�@�@�@����N�����ɐݒ肵�����e�����f�����l�ɂ���̏C��</br>
        /// </remarks>
        private void InitSectionRange(bool loading)
        {
            #region <Guard Phrase/>

            if (this.Section_UTree.Nodes.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            //----ADD 2011/03/14----->>>>>
            if (_dckauFlag)
            {
                SortedList<string, string> sortedSectionList = new SortedList<string, string>();
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in this.Section_UTree.Nodes)
                {
                    if (sectionNode.CheckedState.Equals(CheckState.Checked))
                    {
                        sortedSectionList.Add(sectionNode.Key, sectionNode.Text);
                    }
                }
                if (sortedSectionList.Count == 0)
                {
                    // �J�n���_�R�[�h�̏����l
                    this.tEdit_SectionCode_St.Text = string.Empty;
                    this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;

                    // �I�����_�R�[�h�̏����l
                    this.tEdit_SectionCode_Ed.Text = string.Empty;
                    this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
                }
                else
                {
                    // �J�n���_�R�[�h�̏����l
                    this.tEdit_SectionCode_St.Text = sortedSectionList.Keys[0].Trim();
                    this.startRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[0]);
                    // �S�Зp�̕␳
                    if (sortedSectionList.Keys[0].Trim().Equals(CT_AllSectionCode))
                    {
                        this.tEdit_SectionCode_St.Text = string.Empty;
                        this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;
                    }

                    // �I�����_�R�[�h�̏����l
                    this.tEdit_SectionCode_Ed.Text = sortedSectionList.Keys[sortedSectionList.Count - 1].Trim();
                    this.endRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[sortedSectionList.Count - 1]);
                    // �S�Зp�̕␳
                    if (sortedSectionList.Keys[sortedSectionList.Count - 1].Trim().Equals(CT_AllSectionCode))
                    {
                        this.tEdit_SectionCode_Ed.Text = string.Empty;
                        this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
                    }
                }
            }
            else
            {
                //----ADD 2011/03/14-----<<<<<

                // �J�n���_�R�[�h�̏����l
                string currentSectionCode = string.Empty;
                string currentSectionName = string.Empty;
                for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
                {
                    if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                    {
                        currentSectionCode = this.Section_UTree.Nodes[i].Key;
                        currentSectionName = GetSectionName(currentSectionCode);
                        break;
                    }
                }
                this.tEdit_SectionCode_St.Text = currentSectionCode;
                this.startRangeNameUltraTextEditor.Text = currentSectionName;

                // �I�����_�R�[�h�̏����l
                this.tEdit_SectionCode_Ed.Text = this.tEdit_SectionCode_St.Text;
                this.endRangeNameUltraTextEditor.Text = this.startRangeNameUltraTextEditor.Text;
            } //ADD 2011/03/14

            // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ---------->>>>>
            // ADD 2009/12/25 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�� ---------->>>>>
            //// ���_����̏ꍇ�A���̋��_�ɌŒ�
            //if (this.Section_UTree.Nodes.Count.Equals(1))
            //{
            //    this.tEdit_SectionCode_St.Enabled = false;
            //    this.tEdit_SectionCode_Ed.Enabled = false;
            //}
            // ADD 2009/12/25 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�� ----------<<<<<
            // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ----------<<<<<

            if (loading) this.tEdit_SectionCode_St.Focus();
        }

        /// <summary>
        /// ���_���̂��擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���[�t���[���C��</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2008.09.05</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            if (int.Parse(sectionCode).Equals(int.Parse(CT_AllCtrlFuncSecCode)))
            {
                return CT_AllCtrlFuncSecName;   // �S��
            }
            if (this._secInfoLst.ContainsKey(sectionCode))
            {
                return ((SecInfoSet)this._secInfoLst[sectionCode]).SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }

        // ADD 2009/03/12 �s��Ή�[11606] ---------->>>>>
        /// <summary>
        /// �o�͑Ώۋ��_�͈̔͂�ݒ肵�܂��B
        /// </summary>
        /// <param name="checkedSectionCodes">�I������Ă��鋒�_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �s��Ή�[11606]</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2009.03.12</br>
        /// </remarks>
        private void SetSectionRange(string[] checkedSectionCodes)
        {
            #region <Guard Phrase/>

            if (checkedSectionCodes == null || checkedSectionCodes.Length.Equals(0)) return;

            #endregion

            string startSectionCode = checkedSectionCodes[0];
            string endSectionCode = checkedSectionCodes[checkedSectionCodes.Length - 1];
            SetSectionRange(startSectionCode, endSectionCode);
        }

        /// <summary>
        /// �o�͑Ώۋ��_�͈̔͂�ݒ肵�܂��B
        /// </summary>
        /// <param name="startSectionCode">�J�n���_�R�[�h</param>
        /// <param name="endSectionCode">�I�����_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �s��Ή�[11606]</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2009.03.12</br>
        /// </remarks>
        private void SetSectionRange(
            string startSectionCode,
            string endSectionCode
        )
        {
            // �J�n���_
            this.tEdit_SectionCode_St.Text = startSectionCode;
            this.startRangeNameUltraTextEditor.Text = GetSectionName(startSectionCode);

            // �I�����_
            this.tEdit_SectionCode_Ed.Text = endSectionCode;
            this.endRangeNameUltraTextEditor.Text = GetSectionName(endSectionCode);
        }
        // ADD 2009/03/12 �s��Ή�[11606] ----------<<<<<

        #endregion  // ���@�o�͑Ώۋ��_�͈̔͂̏����ݒ�

        #region ���@�V�X�e���I�����X�g�ݒ菈��
        /// <summary>
        /// �V�X�e���I�����X�g�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e���I�����X�g�̍쐬���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.18</br>
        /// </remarks>
        private void InitSettingSystemTree()
        {
            // �V�X�e���I�����\��
            this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = false;

            int systemCnt = 0;

            // ����
            if (this._introduceSystem.ContainsKey(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF)) { systemCnt += 1; }
            // ���
            if (this._introduceSystem.ContainsKey(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK)) { systemCnt += 2; }
            // �Ԕ�
            if (this._introduceSystem.ContainsKey(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS)) { systemCnt += 4; }

            // �����V�X�e���p�^�[���𔻒�
            switch (systemCnt)
            {
                case 1:  // �����̂�
                    this._introduceSystemCdLst = new int[] { 1 };
                    break;
                case 2:  // ����̂�
                    this._introduceSystemCdLst = new int[] { 2 };
                    break;
                case 3:  // �����{���
                    this._introduceSystemCdLst = new int[] { 1, 2 };
                    break;
                case 4:  // �Ԕ̂̂�
                    this._introduceSystemCdLst = new int[] { 3 };
                    break;
                case 5:  // �����{�Ԕ�
                    this._introduceSystemCdLst = new int[] { 1, 3 };
                    break;
                case 6:  // ����{�Ԕ�
                    this._introduceSystemCdLst = new int[] { 2, 3 };
                    break;
                case 7:  // �����{����{�Ԕ�
                    this._introduceSystemCdLst = new int[] { 1, 2, 3 };
                    break;
            }

            // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            this._slDefSoftWareCode = new SortedList<int, string>();
            // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // �����V�X�e�����P�̂̏ꍇ�A�V�X�e���I���͔�\���Ƃ���B
            if (this._introduceSystem.Count > 1)
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = true;

                // �V�X�e���c���[�쐬
                this.System_UTree.ShowLines = false;

                foreach (int sysCode in this._introduceSystemCdLst)
                {
                    string sysName = "";

                    switch (sysCode)
                    {
                        case 1:
                            sysName = "����";
                            break;
                        case 2:
                            sysName = "���";
                            break;
                        case 3:
                            sysName = "�Ԕ�";
                            break;
                    }

                    this.System_UTree.Nodes.Add(sysCode.ToString(), sysName);
                    this.System_UTree.Nodes[sysCode.ToString()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                    this.System_UTree.Nodes[sysCode.ToString()].CheckedState = System.Windows.Forms.CheckState.Checked;

                    // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    this._slDefSoftWareCode.Add(sysCode, sysName);
                    // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                }
            }
            else
            {
                if (this._introduceSystemCdLst == null) return;

                foreach (int sysCode in this._introduceSystemCdLst)
                {
                    string sysName = "";

                    switch (sysCode)
                    {
                        case 1:
                            sysName = "����";
                            break;
                        case 2:
                            sysName = "���";
                            break;
                        case 3:
                            sysName = "�Ԕ�";
                            break;
                    }

                    this._slDefSoftWareCode.Add(sysCode, sysName);
                }
            }
        }
        #endregion

        #region ���@�o�͒��[���������ݒ菈��
        /// <summary>
        /// �o�͒��[��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e���I�����X�g�̍쐬���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.18</br>
        /// </remarks>
        private void InitSettingPdfHistorySubForm()
        {
            try
            {
                this._pdfHistorySerchForm = new SFANL06101UA();
                this._pdfHistorySerchForm.LoginWorker = this._loginEmployee.Name;

                mControlScreenSkin.SettingScreenSkin(this._pdfHistorySerchForm);

                // ���[�I���C�x���g��ǉ�
                this._pdfHistorySerchForm.SelectNode += new SelectNodeEvent(SelectPdfHistoryListNode);

                // �t�H�[���̋N��
                this._pdfHistorySerchForm.TopLevel = false;
                this._pdfHistorySerchForm.FormBorderStyle = FormBorderStyle.None;
                this.PdfHistory_Panel.Controls.Add(this._pdfHistorySerchForm);
                this._pdfHistorySerchForm.Dock = System.Windows.Forms.DockStyle.Fill;
                this._pdfHistorySerchForm.BringToFront();
                this._pdfHistorySerchForm.Show();
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ���@�o�͒��[�����Ǘ���ʒ��[�I������
        /// <summary>
        /// �o�͗����Ǘ���ʑI������
        /// </summary>
        /// <param name="printKey">���[KEY</param>
        /// <param name="printName">���[��</param>
        /// <param name="PDFFileName">PDF�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �V�X�e���I�����X�g�̍쐬���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private void SelectPdfHistoryListNode(string printKey, string printName, string PDFFileName)
        {
            // �h�b�N�}�l�[�W���[�̌Œ�s������
            this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Unpin();

            if (this._setPdfKeyList.ContainsKey(printKey))
            {
                string infoKey = this._setPdfKeyList[printKey].ToString();

                System.Windows.Forms.Form frm = null;

                this.ViewFormTabCreate(infoKey);

                this.ViewFormTabActive(infoKey, ref frm);

                if (frm != null)
                {
                    SFANL07200UB target = frm as SFANL07200UB;

                    target.IsSave = false;
                    target.PrintKey = "";
                    target.PrintName = "";
                    target.PrintDetailName = "";
                    target.PrintPDFPath = "";

                    target.ShowPDFPreview((Object)PDFFileName);
                }

                // �c�[���o�[�{�^���ݒ�
                this.ToolBarSetting(frm);
                // �h�b�N�}�l�W���[�ݒ�
                this.DockManagerCtrlPaneSetting(frm);
            }
        }
        #endregion

        #region ���@�o�c�e����ۑ�
        /// <summary>
        /// �o�c�e����ۑ�����
        /// </summary>
        /// <param name="key">�Ώے��[KEY</param>
        /// <remarks>
        /// <br>Note       : �Ώے��[KEY�̂o�c�e�t�@�C���𗚗�ۑ����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.13</br>
        /// </remarks>
        private void SavePDF(string key)
        {
            try
            {
                // �r���[�t�H�[���̏ꍇ�͐e��KEY���擾
                string mainKey = key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

                // �A�N�e�B�u�^�u���璠�[�R���g���[�������擾
                FormControlInfo info = this._formControlInfoTable[mainKey] as FormControlInfo;
                if (info == null) return;
                // --- ADD 2010/08/26 ---------->>>>>
                if (info.Form is IPrintConditionInpTypeGuidExecuter)
                {
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
                }
                // --- ADD 2010/08/26 ----------<<<<<
                // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
                if (info.Form is IPrintConditionInpTypeTextOutControl)
                {
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
                }
                // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

                // PDF�v���r���[�t�H�[��
                SFANL07200UB target = info.ViewForm as SFANL07200UB;
                if (target == null) return;

                // ����ۑ��͉\���H
                if (target.IsSave)
                {
                    if (this._pdfHistorySerchForm != null)
                    {
                        // �d���`�F�b�N
                        if (this._pdfHistorySerchForm.Contains(target.PrintKey, target.PrintPDFPath))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y���̂o�c�e�͊��ɗ���o�^����Ă��܂��B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // �o�͗����Ǘ��ɒǉ�
                        this._pdfHistorySerchForm.AddPrintInfo(target.PrintKey, target.PrintName, target.PrintDetailName,
                            target.PrintPDFPath);

                        // �폜���X�g���珜�O����
                        if (this._delPDFList.Contains(target.PrintPDFPath))
                        {
                            this._delPDFList.Remove(target.PrintPDFPath);
                        }
                    }

                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�ۑ����܂����B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "�o�c�e�̗���ۑ��Ɏ��s���܂����B" + "\n\r" + ex.Message,
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ���@�o�͏����I���G�N�X�v���[���[�o�[�O���[�v���ڃ`�F�b�N
        /// <summary>
        /// �o�͏����I���G�N�X�v���[���[�o�[�O���[�v���ڃ`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�͏����I���G�N�X�v���[���[�o�[���̃O���[�v���ڂ̃`�F�b�N�����B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void CheckExplorerBarGroup()
        {
            bool isShow = this.IsSelectGroup();

            if (isShow)
            {
                if (this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                {
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Show();
                    this.Main_TabControl.Focus(); // ADD 2010/08/26
                }
            }
            else
            {
                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Close();
            }
        }

        /// <summary>
        /// �o�͏����I���G�N�X�v���[���[�o�[�O���[�v���ڕ\���`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �o�͏����I���G�N�X�v���[���[�o�[���̃O���[�v���ڂ̕\���`�F�b�N�����B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.22</br>
        /// </remarks>
        private bool IsSelectGroup()
        {
            bool isShow = false;

            // �O���[�v���ڂ̕\����ԃ`�F�b�N
            foreach (Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup grp in this.SelectExplorerBar.Groups)
            {
                isShow = grp.Visible;
                // ��ł��\������Ă���΃h�b�N�}�l�[�W���[�̃y�C���͕\������
                if (isShow)
                {
                    break;
                }
            }
            return isShow;
        }
        #endregion

        #region ���@�P�̋N���E�i�r�N�����菈��
        /// <summary>
        /// �P�̋N���E�i�r�N�����菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>
        /// <br>             ����\��\�ŁA��ʓ��͓��e��XML�ɕۑ����A
        /// <br> �@�@�@�@�@�@����N�����ɐݒ肵�����e�����f�����l�ɂ���̏C��</br>
        /// </remarks>
        private void CheckNaviOrSingleStart()
        {
            // �N���i�r�Q�[�^���N��
            if (this._formControlInfoTable.Count > 1)
            {
                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Show();
                this._navigaterMenuMode = true;

                // ���_OP = �L && �{�Ћ@�\
                if (this._isOptSection && this._isMainOfficeFunc)
                {
                    // �f�t�H���g�`�F�b�N�̓��O�C�����_
                    if (this._secInfoLst.ContainsKey(this._loginSectionCode.TrimEnd()))
                    {
                        this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                    }
                }

                this.StartNavigatorTree.Focus();
            }
            // �P�̋N��
            else
            {
                FormControlInfo info = null;

                foreach (DictionaryEntry entry in this._formControlInfoTable)
                {
                    info = (FormControlInfo)entry.Value;
                    break;
                }
                if (info != null)
                {
                    //-----ADD 2011/03/14----->>>>>
                    if ("DCKAU02520U.DLL".Equals(info.AssemblyID))
                    {
                        _dckauFlag = true;
                    }
                    //-----ADD 2011/03/14-----<<<<<
                    this._navigaterMenuMode = false;
                    this.Text = info.Name;

                    // ���_OP = �L && �{�Ћ@�\
                    if (this._isOptSection && this._isMainOfficeFunc)
                    {
                        // ����@�\�R�[�h��苒�_�R�[�h�擾
                        string ctrlSecCode;
                        this.GetOwnSeCtrlCode(this._loginSectionCode, info.CtrlFuncCode, out ctrlSecCode);

                        // �Y�����_�������ݒ�
                        if (this._secInfoLst.ContainsKey(ctrlSecCode))
                        {
                            this.Section_UTree.Nodes[ctrlSecCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }

                    // �������͉��UI�N������
                    this.ShowChildInputForm(info.Key);

                    // ADD 2009/03/18 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ� ---------->>>>>
                    // ���쌠������
                    if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                    {
                        if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                            EntityUtil.CategoryCode.Report,
                            MyOpeCtrlMap.AddController(info.AssemblyID),
                            info.AssemblyID,
                            info.Name
                        ))
                        {
                            this.Close();   // �N���s�̂��ߋ����I��
                        }
                    }

                    //-----ADD 2011/03/14----->>>>>
                    if (_dckauFlag)
                    {
                        // ����@�\�R�[�h��苒�_�R�[�h�擾
                        string ctrlSecCode;
                        this.GetOwnSeCtrlCode(this._loginSectionCode, info.CtrlFuncCode, out ctrlSecCode);

                        // ���_OP = �L && �{�Ћ@�\
                        if (this._isOptSection && this._isMainOfficeFunc)
                        {
                            // �Y�����_�������ݒ�
                            if (this._secInfoLst.ContainsKey(ctrlSecCode))
                            {
                                this.Section_UTree.Nodes[ctrlSecCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                            }
                        }

                        // �O��I�����Ă������_��ݒ�
                        if (!SectionTreeHelper.ImportCheckedSectionCode(this.Section_UTree, true))
                        {
                            // �����ݒ苒�_�Ƀf�t�H���g�`�F�b�N�H
                            if (this._secInfoLst.ContainsKey(ctrlSecCode))
                            {
                                this.Section_UTree.Nodes[ctrlSecCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                            }
                        }
                    }
                    //-----ADD 2011/03/14-----<<<<<

                    BeginControllingByOperationAuthority(info.AssemblyID);
                    // ADD 2009/03/18 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ� ----------<<<<<

                }
            }
        }
        #endregion

        #region ���@�e���[�����t�h�N���X�N������
        /// <summary>
        /// �e���[����UI��ʋN������
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.19</br>
        /// </remarks>
        private void ShowChildInputForm(string key)
        {
            Cursor nowCursor = this.Cursor;
            System.Windows.Forms.Form childForm = null;

            this._isEvent = false;

            try
            {
                // �N���q��ʍ쐬����
                this.TabCreate(key);

                // �N���q��ʃA�N�e�B�u������		
                this.TabActive(key, ref childForm);

                // �c�[���o�[�Z�b�e�B���O
                this.ToolBarSetting(childForm);

                // ���C���t���[���̌ʉ�ʐݒ�
                this.ScreenPrivateSetting(key, childForm);

                // �N���i�r�Q�[�^�[�y�C����Œ�
                this.PinnedDockManagerControlPane(DOCKMANAGER_NAVIGATOR_KEY, false);

                // �o�͏����I���y�C���Œ�
                this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, true);

                // �o�͗��������y�C����Œ�
                this.PinnedDockManagerControlPane(DOCKMANAGER_PDFHISTORTY_KEY, false);
            }
            finally
            {
                this._isEvent = true;
                this.Cursor = nowCursor;
            }
        }
        #endregion

        #region ���@�e���[����UI��ʌʉ�ʐݒ菈��
        // TODO:���ӁI���j���[����Ăяo�����ꍇ�A�{���\�b�h�ŋ��_�̑I��ݒ肪�Đݒ肳��܂��B
        /// <summary>
        /// �e���[����UI��ʌʉ�ʐݒ菈��
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="activeForm">�A�N�e�B�u�ΏۂƂȂ�Form</param>
        /// <remarks>
        /// <br>Note       :�e������ʌʂ̃t���[����ʂ�ݒ肵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.19</br>
        /// <br>Update Note: 2006.03.28 Y.Sasaki</br>
        /// <br>           : �P.�J�X�^�����_��ޑI���ɑΉ�</br>
        /// </remarks>
        private void ScreenPrivateSetting(string key, System.Windows.Forms.Form activeForm)
        {
            if (activeForm == null) return;

            // �R���g���[�����擾
            FormControlInfo info = null;
            if (this._formControlInfoTable.ContainsKey(key))
            {
                info = this._formControlInfoTable[key] as FormControlInfo;
            }
            else
            {
                return;
            }

            // ����N�����͂��ꂼ��̏����l�𒠕[���ʗp�t�H�[���R���g���[���N���X�ɐݒ�
            if (!info.IsInit)
            {
                info.SelSectionKindIndex = 0;														// ���_���

                // >>>>> 2006.08.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                info.SelSystems = info.SoftWareCode;										// �V�X�e���I��
                //info.SelSystems = this._introduceSystemCdLst;						// �V�X�e���I��
                // <<<<< 2006.08.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // ���_OP�L��
                if (this._isOptSection)
                {
                    // �������_�ݒ�
                    string ctrlSecCode;
                    this.GetOwnSeCtrlCode(this._loginSectionCode, info.CtrlFuncCode, out ctrlSecCode);
                    info.SelSections = new string[] { ctrlSecCode };
                }
            }

            //----------------------------------------------------------------------------//
            // ��ʏ��X�V����                                                           //
            //----------------------------------------------------------------------------//
            // TODO:���_�֘A���c���j���[����Ăяo�����ꍇ�A�����ŋ��_�̑I��ݒ肪�Đݒ肳��܂��B
            if (this.Section_UTree.Nodes.Count > 1) // ADD 2010/02/19 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s��
            {   // �I���ł��鋒�_�������̏ꍇ�A�����I��ݒ���Đݒ肷��
                // ��U�S�Ẵ`�F�b�N���͂���	
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                {
                    utn.CheckedState = CheckState.Unchecked;
                }

                // �I������Ă��鋒�_���`�F�b�N
                foreach (string wkSection in info.SelSections)
                {
                    if (this.Section_UTree.Nodes.Exists(wkSection))
                    {
                        this.Section_UTree.Nodes[wkSection].CheckedState = CheckState.Checked;
                    }
                }

                // �o�͋��_�͈͎̔w��i�J�n�ƏI���j��ݒ�
                SetSectionRange(info.SelSections);  // ADD 2009/03/12 �s��Ή�[11606]
            }   // ADD 2010/02/19 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s��

            // �V�X�e���֘A���
            // ��U�S�Ẵ`�F�b�N���͂���	
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
            {
                utn.CheckedState = CheckState.Unchecked;
            }
            // �I������Ă���V�X�e�����`�F�b�N
            foreach (int wkSystem in info.SelSystems)
            {
                if (this.System_UTree.Nodes.Exists(wkSystem.ToString()))
                {
                    this.System_UTree.Nodes[wkSystem.ToString()].CheckedState = CheckState.Checked;
                }
            }

            //----------------------------------------------------------------------------//
            // ���_�I���O���[�v�\������                                                   //
            //----------------------------------------------------------------------------//
            // ���_�I���C���^�[�t�F�C�X���������Ă���
            if (activeForm is IPrintConditionInpTypeSelectedSection)
            {
                // ���_��ރJ�X�^���C���^�[�t�F�[�X���������Ă���H
                if (activeForm is IPrintConditionInpTypeCustomSelectSectionKind)
                {
                    IPrintConditionInpTypeCustomSelectSectionKind target = activeForm as IPrintConditionInpTypeCustomSelectSectionKind;

                    // ���_��ނ̉�ʐݒ�
                    if (target != null) { this.SettingSectionKindItemList(target.Title, target.CustomSectionKindList); }
                }
                else
                {
                    // ���_��ނ̉�ʐݒ�
                    this.SettingSectionKindItemList(CT_EXPLORERBAR_ADDUPCDLIST_TITLE, (SectionKind[])this._arDefultSecKind.ToArray(typeof(SectionKind)));
                }


                // �O�񋒓_��ނ���ʂɐݒ�
                if (this.AddUpCd_UOptionSet.Items != null && this.AddUpCd_UOptionSet.Items.Count > 0)
                {
                    this.AddUpCd_UOptionSet.CheckedIndex = info.SelSectionKindIndex;
                }

                // ���_�I���C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypeSelectedSection targetObj = activeForm as IPrintConditionInpTypeSelectedSection;

                if (targetObj != null)
                {
                    bool isVisibled = false;

                    if (this._isOptSection)
                    {
                        // ���[�ʏ����ɂ��\���L��
                        isVisibled = targetObj.InitVisibleCheckSection(this._isDefaultSectionSelect);

                        this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = targetObj.VisibledSelectAddUpCd;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = isVisibled;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = isVisibled;    // ADD 2008/09/19 �s��Ή�[5528]
                    }
                    else
                    {
                        this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = false;   // ADD 2008/09/19 �s��Ή�[5528]
                    }

                    // �v�㋒�_�I���͂��邩�H
                    if (targetObj.VisibledSelectAddUpCd)
                    {
                        int addCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.DataValue.ToString(), 0);
                        targetObj.InitSelectAddUpCd(addCode);
                    }

                    // ���_���ݒ�
                    targetObj.InitSelectSection(info.SelSections);

#if false					
					// ����N�����̂ݏ����ݒ���ݒ�
					if (!info.IsInit)
					{
						// �f�t�H���g�ݒ菉������@�\�R�[�h�擾
						int ctrlFuncCode = info.CtrlFuncCode;
						
						// �v�㋒�_�I�� = �L
						if (targetObj.VisibledSelectAddUpCd)
						{
							// �����v�㋒�_�ݒ菈��
							int addCode = 0;
							
							if (this.AddUpCd_UOptionSet.CheckedIndex != -1)
							{
								// ���_��ނ̎擾
								addCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.DataValue.ToString(), 0);
							
								// ����@�\�R�[�h�擾
								ctrlFuncCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.Tag.ToString(), 0);
							}
							
							targetObj.InitSelectAddUpCd(addCode);
						}

						string[] selSections = null;
						
						// ���_�I��L��
						if (isVisibled)
						{
							// �����I�����_�ݒ菈��
							ArrayList selSecList = new ArrayList();
							foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
							{
								if (utn.CheckedState == CheckState.Checked)
								{
									selSecList.Add(utn.Key);
								}
							}
							selSections = (string[])selSecList.ToArray(typeof(string));
						} 
						// ���_�I���Ȃ�
						else 
						{
							// ���_OP�L
							if (this._isOptSection)
							{
								// ���䋒�_�擾
								string ctrlSecCode; 
								this.GetOwnSeCtrlCode(this._loginSectionCode, ctrlFuncCode, out ctrlSecCode);
								selSections = new string[]{ctrlSecCode};
							} 
								// ���_OP��
							else
							{
								// �����_�R�[�h�擾
								string ctrlSecCode; 
								this.GetOwnSeCtrlCode(this._loginSectionCode, 10, out ctrlSecCode);
								selSections = new string[]{ctrlSecCode};
							}
						}

						// ���_�����ݒ�
						targetObj.InitSelectSection(selSections);
					}
#endif
                }
            }
            else
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
                this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = false;   // ADD 2008/09/19 �s��Ή�[5528]
            }

            //----------------------------------------------------------------------------//
            // �V�X�e���I���O���[�v�\������                                               //
            //----------------------------------------------------------------------------//
            // �V�X�e���I���C���^�[�t�F�C�X���������Ă���
            if (activeForm is IPrintConditionInpTypeSelectedSystem)
            {
                // �V�X�e���I���C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypeSelectedSystem targetObj = activeForm as IPrintConditionInpTypeSelectedSystem;

                // ���[�ʏ����ɂ��\���L��
                bool isVisibled = targetObj.InitVisibleCheckSystem(this._isDefaultSystemSelect);

                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = isVisibled;

                // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                if (isVisibled)
                {
                    // �V�X�e���I�����X�g�č쐬
                    this.SettingSystemItemList(info.SoftWareCode);

                    // �I������Ă���V�X�e�����`�F�b�N
                    foreach (int wkSystem in info.SelSystems)
                    {
                        if (this.System_UTree.Nodes.Exists(wkSystem.ToString()))
                        {
                            this.System_UTree.Nodes[wkSystem.ToString()].CheckedState = CheckState.Checked;
                        }
                    }
                }
                // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
#if true
                targetObj.InitSelectSystem(info.SelSystems);
#else
				// ����N�����̂ݏ����ݒ���ݒ�
				if (!info.IsInit)
				{
					// �����I���V�X�e������
					ArrayList selSysList = new ArrayList();
					foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
					{
						if (utn.CheckedState == CheckState.Checked)
						{
							selSysList.Add(TStrConv.StrToIntDef(utn.Key,-1));
						}
					}
					
					int[] selSystems = (int[])selSysList.ToArray(typeof(int));
					targetObj.InitSelectSystem(selSystems);
				}
#endif

            }
            else
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = false;
            }

            // �o�͏����I���y�C���\������
            this.CheckExplorerBarGroup();

            //----------------------------------------------------------------------------//
            // �o�͒��[���������\������                                                   //
            //----------------------------------------------------------------------------//
            // �o�͒��[���������C���^�[�t�F�C�X���������Ă���
            if (activeForm is IPrintConditionInpTypePdfCareer)
            {
                if (this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Show();

                // �o�͒��[���������C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypePdfCareer targetObj = activeForm as IPrintConditionInpTypePdfCareer;

                if (!info.IsInit)
                {
                    if (targetObj.PrintKey != null)
                    {
                        // �Y���̒��[KEY�͊��ɐݒ�ς݂��H
                        if (!this._setPdfKeyList.ContainsKey(targetObj.PrintKey))
                        {
                            // ���[����������ʂɒ��[KEY�ǉ�
                            this._pdfHistorySerchForm.SetPrintKey(targetObj.PrintKey, targetObj.PrintName);
                            if (info != null)
                            {
                                this._setPdfKeyList.Add(targetObj.PrintKey, info.Key);
                            }
                        }
                    }
                }
            }
            else
            {
                // �P�̋N���̎��̂ݔ���A�O���[�v�N�����͏�ɕ\�����Ă���
                if (!this._navigaterMenuMode)
                {
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Close();
                }
            }

            // >>>>> 2006.09.28 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //----------------------------------------------------------------------------//
            // �e�L�X�g�o�͔���                                                           //
            //----------------------------------------------------------------------------//
            // TODO:�e�L�X�g�o�̓C���^�[�t�F�C�X���������Ă���cEnabled
            if (this._isOptTextOutPut && activeForm is IPrintConditionInpTypeTextOutPut)
            {
                // �o�͒��[���������C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypeTextOutPut targetObj = activeForm as IPrintConditionInpTypeTextOutPut;
                if (targetObj != null)
                {
                    // �e�L�X�g�o��
                    Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = targetObj.CanTextOutPut;
                    }
                }
            }
            // <<<<< 2006.09.28 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //----------------------------------------------------------------------------//
            // ���s����                                                           //
            //----------------------------------------------------------------------------//
            // ���s�C���^�[�t�F�C�X���������Ă���
            if (activeForm is IPrintConditionInpTypeUpdate)
            {
                // ���s�C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypeUpdate targetObj = activeForm as IPrintConditionInpTypeUpdate;
                if (targetObj != null)
                {
                    // ���s
                    Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = targetObj.CanUpdate;
                    }
                }
            }
            // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            //----------------------------------------------------------------------------//
            // �O���t�\������                                                             //
            //----------------------------------------------------------------------------//
            // �O���t�\���C���^�[�t�F�C�X���������Ă���
            if (activeForm is IPrintConditionInpTypeChart)
            {
                // �O���t�\���C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypeChart targetObj = activeForm as IPrintConditionInpTypeChart;
                if (targetObj != null)
                {
                    // ���[�U�[�ݒ�
                    Infragistics.Win.UltraWinToolbars.ButtonTool setUpBtnTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    if (setUpBtnTool != null)
                    {
                        setUpBtnTool.SharedProps.Enabled = true;
                    }

                    // �O���t�\��
                    Infragistics.Win.UltraWinToolbars.ButtonTool graphBtnTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    if (graphBtnTool != null)
                    {
                        graphBtnTool.SharedProps.Enabled = targetObj.CanChart;
                    }
                }
            }

            // �����ݒ�ς�
            info.IsInit = true;
        }
        #endregion

        #region ���@���_��ރ��X�g��ʃ��C�A�E�g�ݒ�
        /// <summary>
        /// ���_��ރ��X�g��ʃ��C�A�E�g�ݒ�
        /// </summary>
        /// <param name="title">�^�C�g��</param>
        /// <param name="kindList">�ݒ���e���X�g</param>
        /// <remarks>
        /// <br>Note       : ���_��ނ���ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.07</br>
        /// </remarks>
        private void SettingSectionKindItemList(string title, SectionKind[] kindList)
        {
            // �v���ރR���{������
            this.AddUpCd_UOptionSet.Items.Clear();

            // �^�C�g���ݒ�
            this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Text = title;

            // �A�C�e�����e�̎擾
            if (kindList != null)
            {
                int i = 1;
                foreach (SectionKind kind in kindList)
                {
                    Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                    item.DataValue = i;
                    item.DisplayText = kind.CtrlFuncName;
                    item.Tag = kind.CtrlFuncCode;

                    this.AddUpCd_UOptionSet.Items.Add(item);
                    i++;
                }
            }
        }
        #endregion

        #region ���@�V�X�e���I�����X�g��ʃ��C�A�E�g�ݒ�
        /// <summary>
        /// �V�X�e���I�����X�g��ʃ��C�A�E�g�ݒ�
        /// </summary>
        /// <param name="softwareCode">�I���\�V�X�e��</param>
        /// <remarks>
        /// <br>Note       : �I���\�V�X�e������ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.08.09</br>
        /// </remarks>
        private void SettingSystemItemList(int[] softwareCode)
        {
            // �V�X�e���c���[�쐬
            this.System_UTree.Nodes.Clear();
            this.System_UTree.ShowLines = false;

            foreach (int sysCode in softwareCode)
            {
                if (this._slDefSoftWareCode.ContainsKey(sysCode))
                {
                    string sysName = "";

                    switch (sysCode)
                    {
                        case 1:
                            sysName = "����";
                            break;
                        case 2:
                            sysName = "���";
                            break;
                        case 3:
                            sysName = "�Ԕ�";
                            break;
                    }

                    this.System_UTree.Nodes.Add(sysCode.ToString(), sysName);
                    this.System_UTree.Nodes[sysCode.ToString()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                    this.System_UTree.Nodes[sysCode.ToString()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                }
            }

            if (this.System_UTree.Nodes.Count <= 1)
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = false;
            }
        }
        #endregion

        #region ���@�R���g���[���y�C���s������
        /// <summary>
        /// �R���g���[���y�C���s������
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="isPinned">[T:�Œ�EF:��Œ�]</param>
        /// <remarks>
        /// <br>Note       : �Y���L�[�̃y�C���̌Œ�E��Œ��Ԃ𐧌䂵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void PinnedDockManagerControlPane(string key, bool isPinned)
        {
            // �t���[�e�B���O����Ă���y�C���͖���
            if (this.Main_DockManager.ControlPanes[key].DockedState == Infragistics.Win.UltraWinDock.DockedState.Floating) return;

            // �Œ�
            if (isPinned)
            {
                if (!this.Main_DockManager.ControlPanes[key].Closed)
                {
                    if (!this.Main_DockManager.ControlPanes[key].Pinned)
                    {
                        this.Main_DockManager.ControlPanes[key].Pin();
                    }
                }
            }
            // ��Œ�
            else
            {
                if (!this.Main_DockManager.ControlPanes[key].Closed)
                {
                    if (this.Main_DockManager.ControlPanes[key].Pinned)
                    {
                        this.Main_DockManager.ControlPanes[key].Unpin();

                        if (!this.Main_DockManager.ControlPanes[key].Pinned &&
                            this.Main_DockManager.ControlPanes[key].Manager.FlyoutPane != null)
                        {
                            this.Main_DockManager.ControlPanes[key].Manager.FlyIn(true);
                        }
                    }
                }
            }
        }
        #endregion

        #region ���@�^�u����֘A����
        /// <summary>
        /// �^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="form">�A�N�e�B�u�������t�H�[���̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Main_TabControl.Tabs.Exists(key))
            {
                this.Main_TabControl.Tabs[key].Visible = true;
                this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[key];

                form = this.Main_TabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                // �E�B���h�E�X�e�C�g��ԕύX
                this.CreateWindowStateButtonTools();

                // WindowState�{�^����I����Ԃɂ���
                Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                {
                    if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                    if ((this.Main_TabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                    {
                        stateButtonTool.Checked = true;
                    }
                    else
                    {
                        stateButtonTool.Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// �r���[�t�H�[���^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="form">�A�N�e�B�u�������t�H�[���̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void ViewFormTabActive(string key, ref Form form)
        {
            Cursor nowCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �ǉ��L�[���ݒ�
                string viewKey = key + TAB_VIEWFORM_ADDKEY;

                if (this.Main_TabControl.Tabs.Exists(viewKey))
                {
                    this.Main_TabControl.Tabs[viewKey].Visible = true;
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[viewKey];

                    // �E�B���h�E�X�e�C�g��ԕύX
                    this.CreateWindowStateButtonTools();

                    form = this.Main_TabControl.Tabs[viewKey].Tag as System.Windows.Forms.Form;

                    // WindowState�{�^����I����Ԃɂ���
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.Main_TabControl.SelectedTab != null) && (viewKey == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }

                }
            }
            finally
            {
                this.Cursor = nowCursor;
            }
        }

        /// <summary>
        /// �`���[�g�\���r���[�t�H�[���^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="number">�\��No.</param>
        /// <param name="form">�A�N�e�B�u�������`���[�g�r���[�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        private void ChartViewFormTabActive(string key, int number, ref Form form)
        {
            Cursor nowCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �ǉ��L�[���ݒ�
                string chartViewKey = key + TAB_CHARTVIEWFORM_ADDKEY + number.ToString();

                if (this.Main_TabControl.Tabs.Exists(chartViewKey))
                {
                    this.Main_TabControl.Tabs[chartViewKey].Visible = true;
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[chartViewKey];

                    // �E�B���h�E�X�e�C�g��ԕύX
                    this.CreateWindowStateButtonTools();

                    form = this.Main_TabControl.Tabs[chartViewKey].Tag as AnalysisChartViewForm;

                    // WindowState�{�^����I����Ԃɂ���
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.Main_TabControl.SelectedTab != null) && (chartViewKey == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }

                }
            }
            finally
            {
                this.Cursor = nowCursor;
            }
        }


        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void TabCreate(string key)
        {
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;

            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

            // ���Ƀ��[�h�ς݁I
            if (info.Form != null) return;

            this.CreateTabForm(info);
        }

        /// <summary>
        /// �r���[�t�H�[���^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �r���[�^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void ViewFormTabCreate(string key)
        {
            // �r���[�\�����A�Z���u�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

            // ���Ƀ��[�h�ς݁I
            if (info.ViewForm != null) return;

            this.CreateTabViewForm(info);
        }

        /// <summary>
        /// �`���[�g�p�r���[�t�H�[���^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`���[�g�p�r���[�^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        private void ChartViewFormTabCreate(string key, int number)
        {
            // �r���[�\�����A�Z���u�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

            // ���Ƀ��[�h�ς݁I
            int index = number + 1;
            if (info.AnalysisChartViewFormLst.Count != 0 && index <= info.AnalysisChartViewFormLst.Count) return;

            this.CreateChartViewForm(info, number);
        }

        /// <summary>
        /// Tab�t�H�[����������
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));
            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.Form = form;

                // --- ADD 2010/08/26 ---------->>>>>
                if (info.Form is IPrintConditionInpTypeGuidExecuter)
                {
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
                }
                // --- ADD 2010/08/26 ----------<<<<<
                // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
                if (info.Form is IPrintConditionInpTypeTextOutControl)
                {
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
                }
                // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

                // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name;
                dataviewTab.Key = info.Key;
                dataviewTab.Tag = form;
                dataviewTab.Appearance.Image = info.Icon;
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                //----------------------------------------------------------------------------//
                // �e��f���Q�[�g�C�x���g�o�^                                                 //
                //----------------------------------------------------------------------------//

                // �c�[���o�[�{�^������C�x���g 
                if (form is IPrintConditionInpType)
                {
                    ((IPrintConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                }

                // --- 2010/08/16 ---------->>>>>
                if (form is IPrintConditionInpTypeGuidExecuter)
                {
                    ((IPrintConditionInpTypeGuidExecuter)form).ParentToolbarGuideSettingEvent += new ParentToolbarGuideSettingEventHandler(this.ParentToolbarGuideSettingEvent);
                }
                // --- 2010/08/16 ----------<<<<<

                // ���_�I���C�x���g
                if (form is IPrintConditionInpTypeSelectedSection)
                {
                    // ���_�I�v�V�����v���p�e�B
                    ((IPrintConditionInpTypeSelectedSection)form).IsOptSection = this._isOptSection;

                    // �{�Ћ@�\�v���p�e�B
                    ((IPrintConditionInpTypeSelectedSection)form).IsMainOfficeFunc = this._isMainOfficeFunc;

#if false
					// �v�㋒�_�I���C�x���g
					this._checkedAddUpEvent   += new CheckedAddUpEventHandler(((IPrintConditionInpTypeSelectedSection)form).SelectedAddUpCd);
					
					// �������_�ݒ�f���Q�[�g
					this._initSelectSectionEvent += new InitSelectSectionEventHandler(((IPrintConditionInpTypeSelectedSection)form).InitSelectSection);
					
					// ���_�I���C�x���g
					this._checkedSectionEvent += new CheckedSectionEventHandler(((IPrintConditionInpTypeSelectedSection)form).CheckedSection);
#endif
                }

#if false
				// �V�X�e���I���C�x���g
				if (form is IPrintConditionInpTypeSelectedSystem)
				{
					this._checkedSystemEvent  += new CheckedSystemEventHandler(((IPrintConditionInpTypeSelectedSystem)form).CheckedSystem);
				}
#endif

                this.Main_TabControl.Controls.Add(dataviewTabPageControl);
                this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Main_TabControl.SelectedTab = dataviewTab;

                // �t�H�[���v���p�e�B�ύX
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                if (form is IPrintConditionInpType)
                {
                    ((IPrintConditionInpType)form).Show(info.Param);
                }
                else
                {
                    form.Show();
                }
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }

        /// <summary>
        /// Tab�r���[�t�H�[����������
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private Form CreateTabViewForm(FormControlInfo info)
        {
            Form form = null;

            form = new SFANL07200UB();
            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.ViewForm = form;

                // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name + "�r���[";
                dataviewTab.Key = info.Key + TAB_VIEWFORM_ADDKEY;
                dataviewTab.Tag = form;
                dataviewTab.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW];
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                ((SFANL07200UB)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                // ���[���ʗp�t�H�[���R���g���[���̃L�[�����i�[���Ă���
                ((SFANL07200UB)form).FormControlInfoKey = info.Key;

                this.Main_TabControl.Controls.Add(dataviewTabPageControl);
                this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Main_TabControl.SelectedTab = dataviewTab;

                // �t�H�[���v���p�e�B�ύX
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);
                form.Show();
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }

        /// <summary>
        /// �`���[�g�r���[�t�H�[����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        private Form CreateChartViewForm(FormControlInfo info, int number)
        {
            AnalysisChartViewForm chartform = null;
            chartform = new AnalysisChartViewForm();

            info.AnalysisChartViewFormLst.Add(chartform);

            // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
            Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

            // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
            Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

            dataviewTab.TabPage = dataviewTabPageControl;

            // ���̓O���t�������y�[�W�ɕ������ꍇ
            if (info.AnalysisChartViewFormLst.Count > 1)
                dataviewTab.Text = info.Name + "���̓O���t(&" + number.ToString() + ")";
            else
                dataviewTab.Text = info.Name + "���̓O���t";
            dataviewTab.Key = info.Key + TAB_CHARTVIEWFORM_ADDKEY + number.ToString();
            dataviewTab.Tag = chartform;
            //				dataviewTab.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.];
            dataviewTab.Appearance.BackColor = Color.White;
            dataviewTab.Appearance.BackColor2 = Color.Lavender;
            dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            dataviewTab.ActiveAppearance.BackColor = Color.White;
            dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
            dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            ((AnalysisChartViewForm)chartform).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
            // ���[���ʗp�t�H�[���R���g���[���̃L�[�����i�[���Ă���
            ((AnalysisChartViewForm)chartform).FormControlInfoKey = info.Key;
            ((AnalysisChartViewForm)chartform).Number = number;

            this.Main_TabControl.Controls.Add(dataviewTabPageControl);
            this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });

            this.Main_TabControl.SelectedTab = dataviewTab;

            // �t�H�[���v���p�e�B�ύX
            chartform.TopLevel = false;
            chartform.FormBorderStyle = FormBorderStyle.None;
            dataviewTabPageControl.Controls.Add(chartform);
            chartform.Show();
            chartform.Dock = System.Windows.Forms.DockStyle.Fill;

            return chartform;
        }

        #endregion

        #region ���@�w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        /// <summary>
        /// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            catch (System.Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            return obj;
        }
        #endregion

        #region ���@�c�[���o�[�̕\���E�L���ݒ�
        /// <summary>
        /// �c�[���o�[�̕\���E�L���ݒ�
        /// </summary>
        /// <param name="activeForm">�A�N�e�B�u�ȃt�H�[���̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̕\���E��\���A�L���E�����ݒ���s���܂��B</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {

            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            // --- 2010/08/16 ---------->>>>>
            int count = 0;

            for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++)
            {
                if (this.Main_TabControl.Tabs[i].IsInView)
                {
                    count++;
                }
            }
            // F5:�K�C�h
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            if (buttonTool != null)
            {
                buttonTool.SharedProps.Enabled = false;
            }

            // F3:����
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_NEXTPAGEBUTTON_KEY];

            if (count > 1)
            {
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = true;
                }
            }
            else
            {
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
            // --- 2010/08/16 ----------<<<<<

            if (activeForm != null)
            {
                if (activeForm is IPrintConditionInpType)
                {
                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledPrintButton;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpType)activeForm).CanPrint;
                        }
                    }

                    // ���o
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledExtractButton;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpType)activeForm).CanExtract;
                        }
                    }

                    // PDF
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledPdfButton;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpType)activeForm).CanPdf;
                        }
                    }

                    // PDF����ۑ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledPdfButton;
                            buttonTool.SharedProps.Enabled = false;
                        }
                    }

                    // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    // TODO:�e�L�X�g�o�́c�c�[���o�[�ݒ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (activeForm is IPrintConditionInpTypeTextOutPut)
                        {
                            if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                            {
                                buttonTool.SharedProps.Visible = this._isOptTextOutPut;
                                buttonTool.SharedProps.Enabled = ((IPrintConditionInpTypeTextOutPut)activeForm).CanTextOutPut;
                            }
                        }
                        else
                        {
                            buttonTool.SharedProps.Visible = false;
                            buttonTool.SharedProps.Enabled = false;
                        }
                    }
                    else
                    {
                        buttonTool.SharedProps.Visible = false;
                    }
                    // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                    // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    // ���s
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (activeForm is IPrintConditionInpTypeUpdate)
                        {
                            buttonTool.SharedProps.Visible = true;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpTypeUpdate)activeForm).CanUpdate;
                        }
                        else
                        {
                            buttonTool.SharedProps.Visible = false;
                            buttonTool.SharedProps.Enabled = false;
                        }
                    }
                    else
                    {
                        buttonTool.SharedProps.Visible = false;
                    }
                    // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                    // �O���t�\��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    if (activeForm is IPrintConditionInpTypeChart)
                    {
                        if (buttonTool != null)
                        {
                            if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                            {
                                buttonTool.SharedProps.Visible = ((IPrintConditionInpTypeChart)activeForm).VisibledChartButton;
                                buttonTool.SharedProps.Enabled = ((IPrintConditionInpTypeChart)activeForm).CanChart;
                            }
                        }

                        // ���[�U�[�ݒ� 
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                        if (buttonTool != null)
                        {
                            if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 �s��Ή�[8937]�F�Z�L�����e�B�Ǘ��ݒ�Ő��������@�\���L���ƂȂ��Ă��Ȃ�
                            {
                                buttonTool.SharedProps.Visible = true;
                                buttonTool.SharedProps.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (buttonTool != null)
                        {
                            buttonTool.SharedProps.Visible = false;
                        }

                        // ���[�U�[�ݒ� 
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                        if (buttonTool != null)
                        {
                            buttonTool.SharedProps.Visible = false;
                        }
                    }

                }
                else if (activeForm is SFANL07200UB)
                {
                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    //// ���o
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                    //if (buttonTool != null) 
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    //// PDF
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                    //if (buttonTool != null) 
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    // PDF����ۑ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = ((SFANL07200UB)activeForm).IsSave;
                    }

                    //// >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    //// �e�L�X�g�o��
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}
                    //// <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                    //// �ݒ�
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    //// �O���t�\��
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}
                }
                else if (activeForm is AnalysisChartViewForm)
                {
                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    // ���o
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    //// PDF
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    // PDF����ۑ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    //// �e�L�X�g�o��
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    //// �ݒ�
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = true;
                    //}

                    //// �O���t�\��
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}
                }

            }
            else
            {
                // ���
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // ���o
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF����ۑ�
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                // �e�L�X�g�o��
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                // ���s
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // �O���t�\��
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // ���[�U�[�ݒ� 
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
        }
        #endregion

        #region ���@�h�b�N�}�l�[�W���e�R���g���[���y�C���̕\���E��\������
        /// <summary>
        /// �h�b�N�}�l�[�W���e�R���g���[���y�C���̕\���E��\������
        /// </summary>
        /// <param name="activeForm">�A�N�e�B�u�ȃt�H�[���̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �h�b�N�}�l�[�W���e�R���g���[���y�C���̕\���E��\���A�L���E�����ݒ���s���܂��B</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.22</br>
        /// </remarks>
        private void DockManagerCtrlPaneSetting(object activeFrom)
        {
            if (activeFrom != null)
            {
                // >>>>> 2007.07.17 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                //if (activeFrom is SFANL07200UB)
                //{
                // <<<<< 2007.07.17 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                if (!(activeFrom is IPrintConditionInpType))
                {
                    // �o�͏����ݒ�y�C��������
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Close();
                }
            }
            else
            {
                // �o�͏����ݒ�y�C��������
                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Close();
            }
        }
        #endregion

        #region ���@�I���^�u�ύX���c���[�m�[�h�I������
        /// <summary>
        /// �I���^�u�ύX���c���[�m�[�h�I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u���ύX���ꂽ�ꍇ�ɁA�ύX���ꂽ�^�u�Ɋ֘A�t��
        ///					 ��ꂽ�c���[�m�[�h��I�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.12</br>
        /// </remarks>
        private void SelectedTabChangedNodeSelect()
        {
            Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_TabControl.SelectedTab;
            if (tab == null)
            {
                return;
            }

            string key = tab.Key;

            if (tab.Tag is SFANL07200UB)
            {
                SFANL07200UB targetObj = tab.Tag as SFANL07200UB;
                key = targetObj.FormControlInfoKey;
            }
            else if (tab.Tag is AnalysisChartViewForm)
            {
                AnalysisChartViewForm targetObj = tab.Tag as AnalysisChartViewForm;
                key = targetObj.FormControlInfoKey;
            }

            Infragistics.Win.UltraWinTree.UltraTreeNode utn = this.StartNavigatorTree.GetNodeByKey(key);
            if (utn == null)
            {
                return;
            }

            this.StartNavigatorTree.ActiveNode = utn;

            bool result;

            result = this.StartNavigatorTree.PerformAction(
              Infragistics.Win.UltraWinTree.UltraTreeAction.ClearAllSelectedNodes,
              false,
              false);
            if (!result)
            {
                return;
            }

            result = this.StartNavigatorTree.PerformAction(
              Infragistics.Win.UltraWinTree.UltraTreeAction.SelectActiveNode,
              false,
              false);
            if (!result)
            {
                return;
            }
        }
        #endregion

        #region ���@����O���C���t���[�������`�F�b�N
        /// <summary>
        /// ����O���C���t���[���������`�F�b�N
        /// </summary>
        /// <returns>[T:OK,F:NG]</returns>
        /// <remarks>
        /// <br>Note       : ���C���t���[�������o�����`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.02.15</br>
        /// </remarks>
        private bool IsPrint()
        {
            // --- ADD 2009/01/14 ��QID:9980�Ή�------------------------------------------------------>>>>>
            // ���_�͈̓`�F�b�N
            if ((this.tEdit_SectionCode_St.DataText.Trim() != "") && (this.tEdit_SectionCode_Ed.DataText.Trim() != ""))
            {
                string sectionCodeSt = this.tEdit_SectionCode_St.DataText.Trim();
                string sectionCodeEd = this.tEdit_SectionCode_Ed.DataText.Trim();

                if (String.Compare(sectionCodeSt, sectionCodeEd) > 0)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�o�͋��_�͈̔͂��s���ł��B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    this.tEdit_SectionCode_St.Focus();
                    return false;
                }
            }
            // --- ADD 2009/01/14 ��QID:9980�Ή�------------------------------------------------------<<<<<

            // ���_�I���`�F�b�N		
            if (this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible)
            {
                bool isSecCheck = false;
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        isSecCheck = true;
                        break;
                    }
                }

                if (!isSecCheck)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�o�͑Ώۋ��_�͕K����̓`�F�b�N���Ă��������B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            // �V�X�e���I���`�F�b�N
            if (this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible)
            {
                bool isSystem = false;
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        isSystem = true;
                        break;
                    }
                }

                if (!isSystem)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�o�͑ΏۃV�X�e���͕K����̓`�F�b�N���Ă��������B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region ���@����@�\���_�擾
        /// <summary>
        /// ����@�\���_�擾
        /// </summary>
        /// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        /// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�̋��_������̓Ǎ����s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.01</br>
        /// </remarks>
        private int GetOwnSeCtrlCode(string sectionCode, int ctrlFuncCode, out string ctrlSectionCode)
        {
            // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ---------->>>>>
            // ADD 2009/12/25 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�� ---------->>>>>
            //// ���_����̏ꍇ�A���̋��_�ɌŒ�
            //if (this.Section_UTree.Nodes.Count.Equals(1))
            //{
            //    string theSectionCode = this.tEdit_SectionCode_St.Text.Trim();
            //    if (!theSectionCode.Equals(sectionCode.Trim()))
            //    {
            //        ctrlSectionCode = this.tEdit_SectionCode_St.Text;
            //        return 0;
            //    }
            //}
            // ADD 2009/12/25 MANTIS�Ή�[14310]�F���_�}�X�^��1���_�݂̂ł̋��_�͈͎w��̕s�� ----------<<<<<
            // DEL 2010/05/11 MANTIS�Ή�[15358]�F1���_�����o�^���Ȃ��ꍇ�A���_�͈͎̔w�肪���͂ł��Ȃ��̂ŁA���͉\�֏C�� ----------<<<<<

            // �Ώې��䋒�_�̏����l�͎����_
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            int status = this._secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (secInfoSet != null)
                    {
                        //						ctrlSectionCode = secInfoSet.SectionCode;
                        ctrlSectionCode = secInfoSet.SectionCode.TrimEnd();			// 2006.09.04 Y.Sasaki ADD

                        // >>>>> 2006.09.26 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        //�u�S���_: 000000�v��������u�S��: 0�v�ɒu��������
                        if (ctrlSectionCode.Equals(CT_AllCtrlFuncSecCode))
                        {
                            ctrlSectionCode = CT_AllSectionCode;
                        }
                        // <<<<< 2006.09.26 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                    }
                    break;
                default:
                    break;
            }

            return status;
        }
        #endregion

#if false
//		/// <summary>
//		/// ���ʒ��o�����ݒ菈��
//		/// </summary>
//		/// <param name="target">�ݒ�Ώ�object</param>
//		/// <remarks>
//		/// <br>Note       : ���ʒ��o������ݒ肵�܂��B</br>
//		/// <br>Programmer : 18012 Y.Sasaki</br>
//		/// <br>Date       : 2006.03.27</br>
//		/// </remarks>
//		private void SetExtractCondtnUI(object target)
//		{
//			// ���o�����擾�E�ݒ�C���^�t�F�[�X���������Ă��邩
//			if (target is IPrintConditionInpTypeCondition)
//			{
//				object objCondtn = ((IPrintConditionInpTypeCondition)target).ObjExtract;
//				
//				// ���o������{�N���X���p�����Ă���
//				if (objCondtn != null && objCondtn is ExtractionCondtnUI)
//				{
//					// ���[�o�͐ݒ�
//					((ExtractionCondtnUI)objCondtn).PrtOutSet = this._prtOutSet;
//				}
//			}
//		}
#endif

        #region ���@�E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �E�C���h�E�\�ʒu��ԃ{�^�����쐬���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void CreateWindowStateButtonTools()
        {
            Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];
            Infragistics.Win.UltraWinToolbars.PopupMenuTool formsPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_FORMS_KEY];

            windowPopupMenuTool.ResetTools();
            formsPopupMenuTool.ResetTools();

            // �u�E�B���h�E��������Ԃɖ߂��v�@�{�^���c�[���ǉ�
            if (!this.Main_ToolbarsManager.Tools.Exists(TOOLBAR_RESETBUTTON_KEY))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool resetButtonTool = new Infragistics.Win.UltraWinToolbars.ButtonTool(TOOLBAR_RESETBUTTON_KEY);
                resetButtonTool.SharedProps.Caption = "�E�B���h�E��������Ԃɖ߂�(&R)";
                resetButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowResetButtonTool_ToolClick);
                this.Main_ToolbarsManager.Tools.Add(resetButtonTool);
            }
            windowPopupMenuTool.Tools.AddTool(TOOLBAR_RESETBUTTON_KEY);

            for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_TabControl.Tabs[i];

                if (!tab.Visible) continue;

                string key = tab.Key;

                if (this.Main_ToolbarsManager.Tools.Exists(key))
                {
                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }
                else
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key, "TabWindow");
                    stateButtonTool.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
                    stateButtonTool.SharedProps.Caption = tab.Text;
                    stateButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowStateButtonTool_ToolClick);
                    stateButtonTool.Tag = true;
                    this.Main_ToolbarsManager.Tools.Add(stateButtonTool);

                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }

                if ((i == 0) && (windowPopupMenuTool.Tools.Exists(key)))
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[key];
                    stateButtonTool.InstanceProps.IsFirstInGroup = true;
                }
            }
        }
        #endregion

        #region ���@�u�E�B���h�E�������l�ɖ߂��v�{�^���N���b�N���C�x���g
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �E�B���h�E�X�e�[�g�{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void WindowResetButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (this._dockMemoryStream == null)
            {
                return;
            }

            this._dockMemoryStream.Position = 0;

            this.Main_DockManager.LoadFromBinary(this._dockMemoryStream);
        }
        #endregion

        #region ���@�E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �E�B���h�E�X�e�[�g�{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void WindowStateButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if ((this.Main_TabControl.Tabs.Exists(e.Tool.Key)))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[e.Tool.Key];

                    // �i�r�Q�[�^���j���[���[�h
                    if (this._navigaterMenuMode)
                    {
                        this.Main_TabControl.ContextMenu = this.TabControl_contextMenu;
                    }
                    else
                    {
                        int index = e.Tool.Key.ToString().IndexOf(TAB_VIEWFORM_ADDKEY);
                        if (index == -1)
                        {
                            // ��������
                            this.Main_TabControl.ContextMenu = null;
                        }
                        else
                        {
                            // �v���r�����
                            this.Main_TabControl.ContextMenu = this.TabControl_contextMenu;
                        }
                    }
                    Debug.WriteLine(this._formControlInfoTable.Contains(this.Main_TabControl.SelectedTab.Key) ? "OK" : "NG");
                    Form selectedForm = this._formControlInfoTable[this.Main_TabControl.SelectedTab.Key] as Form;

                    // ADD 2008/10/02 �s��Ή�[5774]---------->>>>>
                    if (selectedForm == null)
                    {
                        if (this._formControlInfoTable.Contains(this.Main_TabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._formControlInfoTable[this.Main_TabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                    if (this.Main_TabControl.ActiveTab != null)
                    {
                        this.Text = MAIN_TITLE + "�|" + this.Main_TabControl.ActiveTab.Text;
                        return;
                    }
                    // ADD 2008/10/02 �s��Ή�[5774]----------<<<<<

                    if (selectedForm != null)
                    {
                        this.Text = MAIN_TITLE + "�|" + selectedForm.Text;
                    }
                }
            }
        }
        #endregion

        #region ���@�^�u�\���E��\������
        /// <summary>
        /// �^�u�\���^��\��������
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="hidden">true:�\�� false:��\��</param>
        /// <remarks>
        /// <br>Note       : �^�u�̕\���^��\���𐧌䂵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_TabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }
        }
        #endregion

        #region ���@�i�r�Q�[�V�����̊Y���L�[�m�[�h�I����ԕύX
        /// <summary>
        /// �i�r�Q�[�V�����̊Y���L�[�m�[�h�I����ԕύX
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <remarks>
        /// <br>Note       : �i�r�Q�[�V�����̊Y���L�[�m�[�h�I����Ԃ𐧌䂵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void NodeSelectChaneg(string key, bool isSelected)
        {
            // �Y���L�[�̃m�[�h���擾
            Infragistics.Win.UltraWinTree.UltraTreeNode node = this.StartNavigatorTree.GetNodeByKey(key);

            if (node != null)
            {
                if (isSelected)
                {
                    node.Override.NodeAppearance.ForeColor = Color.Red;
                }
                else
                {
                    node.Override.NodeAppearance.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region ���@�G���[���b�Z�[�W�\������
        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.01.19</br>
        /// </remarks>
        internal static DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        #region ���@�`���[�g�^�u�t�H�[���N���A

        /// <summary>
        /// �`���[�g�^�u�t�H�[���N���A
        /// </summary>
        /// <param name="info">���[���ʗp�t�H�[���R���g���[���N���X</param>
        private void ClearChartTabForm(FormControlInfo info)
        {
            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
            if (info.AnalysisChartViewFormLst == null || info.AnalysisChartViewFormLst.Count == 0) return;

            try
            {
                this.Main_TabControl.BeginUpdate();

                foreach (AnalysisChartViewForm viewFrm in info.AnalysisChartViewFormLst)
                {
                    string tabKey = info.Key + TAB_CHARTVIEWFORM_ADDKEY + viewFrm.Number.ToString();

                    // �^�u�̍폜
                    if (this.Main_TabControl.Tabs.Exists(tabKey))
                        this.Main_TabControl.Tabs.Remove(this.Main_TabControl.Tabs[tabKey]);

                    // �E�B���h�E���j���[�̍폜
                    if (this.Main_ToolbarsManager.Tools.Exists(tabKey))
                        this.Main_ToolbarsManager.Tools.Remove(this.Main_ToolbarsManager.Tools[tabKey]);

                    viewFrm.Clear();
                }

                info.AnalysisChartViewFormLst.Clear();
            }
            finally
            {
                this.Main_TabControl.EndUpdate();
                this.Update();
            }
        }

        #endregion

        #region	�� DEBUG �p�R�[�h
#if DEBUG
        private DateTime _dtime_s, _dtime_e;
        private System.IO.FileStream _fs = null;
        private System.IO.StreamWriter _sw = null;

        private void DebugLogWrite(int mode, string msg)
        {
            this._fs = new System.IO.FileStream("SFANL07200U_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            this._sw = new System.IO.StreamWriter(this._fs, System.Text.Encoding.GetEncoding("shift_jis"));
            if (mode == 0)
            {

                this._dtime_s = DateTime.Now;
                TimeSpan ts = this._dtime_s.Subtract(this._dtime_s);
                string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
                    this._dtime_s, this._dtime_s.Millisecond, ts.ToString(), msg);
                this._sw.WriteLine(s);
                //				System.Diagnostics.Debug.WriteLine( s );
            }
            else if (mode == 1)
            {
                this._dtime_e = DateTime.Now;
                TimeSpan ts = this._dtime_e.Subtract(this._dtime_s);
                string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
                    this._dtime_e, this._dtime_e.Millisecond, ts.ToString(), msg);

                this._sw.WriteLine(s);
                //				System.Diagnostics.Debug.WriteLine( s );

                this._dtime_s = this._dtime_e;
            }
            else if (mode == 9)
            {
            }
            this._sw.Close();
            this._fs.Close();
        }
#endif
        #endregion

        #endregion

        // ===============================================================================
        // �R���g���[���C�x���g
        // ===============================================================================
        #region control event
        /// <summary>
        /// ���C���t���[����LOAD�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �C�x���g�̉�����L�q���܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void SFANL07200UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            mControlScreenSkin.LoadSkin();
            mControlScreenSkin.SettingScreenSkin(this);

            this._dockMemoryStream = new MemoryStream();

            // �N���i�r�Q�[�^�[�������Ă���
            this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Close();

            this._isEvent = false;
            int status;
            string message = "";
            try
            {
                // �����ݒ�f�[�^�Ǎ�
                status = this.InitialSettingDBRead(out message);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        message,
                        status,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    this.Close();
                    return;
                }

                // �N���i�r�Q�[�^�[�\�z
                this.ConstructionTreeNode();

                // �v���O�������e�[�u���\�z
                status = this.CreateFormControlInfo();
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        "�N���p�����[�^���s���ł��B!!",//ahn
                        -1,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    this.Close();
                    return;
                }

                // �h�b�N�}�l�[�W���[�����ݒ�
                this.InitSettingDockManager();

                // �c�[���o�[�����ݒ�
                this.InitSettingToolBar();

                // �c�[���o�[�{�^����Ԑݒ�
                this.ToolBarSetting(null);

                // ���_���ݒ菈��
                this.InitSettingSectionTree();

                // �V�X�e�����ݒ菈��
                this.InitSettingSystemTree();

                // �o�͒��[�Ǘ�������ʐݒ�
                this.InitSettingPdfHistorySubForm();

                // �o�͏����I���y�C���\������
                this.CheckExplorerBarGroup();

                // �E�C���h�E�{�^���쐬����
                this.CreateWindowStateButtonTools();
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �������_�I��\����ԕۑ�
                this._isDefaultSectionSelect = this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible;

                // �����V�X�e���I��\����ԕۑ�
                this._isDefaultSystemSelect = this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible;

                // �P�̋N���E�i�r�N�����菈��
                this.CheckNaviOrSingleStart();

                // DockManager�̏�Ԃ�ێ�����
                this.Main_DockManager.SaveAsBinary(this._dockMemoryStream);

                this._isEvent = true;
            }

            // �o�͑Ώۋ��_�͈̔͂̏����ݒ�
            this.InitSectionRange(true);    // 2008.09.05 T.Kudoh ADD
        }

        /// <summary>
        /// �c���[�m�[�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �N���i�r�Q�[�^�[�̃_�u���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void StartNavigatorTree_DoubleClick(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                this.StartNavigatorTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._formControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<

            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

            if (doubleClickedNode.Level == 2)
            {
                // >>>>> 2008.09.05 T.Kudoh ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        return; // �N���s�̂��ߋ����I��
                    }
                }
                // <<<<< 2008.09.05 T.Kudoh ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                Infragistics.Win.UltraWinTree.UltraTreeNode node = doubleClickedNode;

                // �������͉��UI�N������
                ShowChildInputForm(node.Key.ToString());

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);  // 2008.09.05 T.Kudoh ADD

                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------>>>>
                try
                {
                    try
                    {
                        // �N���C�A���g���O�o�͕��i������
                        if (clientLogTextOut == null)
                        {
                            clientLogTextOut = new ClientLogTextOut();
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }

                    try
                    {
                        // ���엚�����O�o�͕��i������
                        if (operationHistoryLog == null)
                        {
                            operationHistoryLog = new OperationHistoryLog();
                        }
                    }
                    catch (Exception ex)
                    {
                        // �G���[�����O�o��
                        try
                        {
                            if (clientLogTextOut != null)
                            {
                                clientLogTextOut.Output(ex.Source, ErrMessageInit, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                            }
                        }
                        catch
                        {
                            // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                        }
                    }

                    // ���O�o�͂��s��
                    string dateMessage = string.Format(DateMessage, MAIN_TITLE, node.Parent.Text, node.Text, info.AssemblyID);
                    if (operationHistoryLog != null)
                    {
                        // ���엚�����O�o��
                        operationHistoryLog.WriteOperationLog(this, DateTime.Now, (LogDataKind)MenuLog,
                        CT_PGID, MAIN_TITLE, MethodName, OperationCode, (int)ConstantManagement.MethodResult.ctFNC_NORMAL, dateMessage, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    // �G���[�����O�o��
                    try
                    {
                        if (clientLogTextOut != null)
                        {
                            clientLogTextOut.Output(ex.Source, MethodName + ErrMessage, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }
                }
                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------<<<<
            }
            // --- 2010/08/16 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool guideButtonTool;
                // F3:����
                guideButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
                if (guideButtonTool != null)
                {
                    guideButtonTool.SharedProps.Visible = true;
                }
            }

            if (this.Main_TabControl.Tabs.Count > 1)
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool nextPageButtonTool;
                // F3:����
                nextPageButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_NEXTPAGEBUTTON_KEY];
                if (nextPageButtonTool != null)
                {
                    nextPageButtonTool.SharedProps.Enabled = true;
                }
            }
            // --- 2010/08/16 ----------<<<<<
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // �c�[���{�^���̑��쌠���̐���ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_EXTRABUTTON_KEY, ReportFrameOpeCode.Extract, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUTBUTTON_KEY, ReportFrameOpeCode.OutputText, false));
            //toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_UPDATEBUTTON_KEY, ReportFrameOpeCode.OutputText, false)); // [���s]�{�^���͑��쌠������̊Ǘ��O
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_GRAPHBUTTON_KEY, ReportFrameOpeCode.ShowGraph, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_SETUPBUTTON_KEY, ReportFrameOpeCode.Setup, true));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // ���쌠���̐�����J�n
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        /// <summary>
        /// Control.MouseDown �C�x���g(StartNavigatorTree)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �c���[�R���g���[���ɂă}�E�X�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void StartNavigatorTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // �t�H�[������UiSetControl��T��	
            UiSetControl uiSetControl = UiSetControl.SearchFromOwner(this);
            if (uiSetControl != null)
            {
                // �ꊇ�[���l�ߏ���	
                uiSetControl.SettingAllControlsZeroPaddedText();
            }
            switch (e.Tool.Key)
            {
                case TOOLBAR_ENDBUTTON_KEY:		// �I��
                    {
                        this.Close();
                        break;
                    }

                case TOOLBAR_PRINTBUTTON_KEY:		// ���
                case TOOLBAR_PDFBUTTON_KEY:		// PDF�o��
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by ������ on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by ������ on 2011/10/27 
                        // �����`�F�b�N
                        if (!this.IsPrint()) return;

                        int printMode = (int)emPrintMode.emPrinter;

                        switch (e.Tool.Key)
                        {
                            case TOOLBAR_PRINTBUTTON_KEY:
                                // �ʏ���
                                printMode = (int)emPrintMode.emPrinterAndPDF;
                                break;
                            case TOOLBAR_PDFBUTTON_KEY:
                                // PDF�\��
                                printMode = (int)emPrintMode.emPDF;
                                break;
                            default:
                                break;
                        }

                        // �A�N�e�B�u�^�u����t�H�[�����擾
                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            printInfo.printmode = printMode;
                            printInfo.pdfopen = false;
                            printInfo.pdftemppath = "";

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // ����O�`�F�b�N
                            if (!childObj.PrintBeforeCheck()) return;

                            //            // ���ʒ��o�����ݒ� 
                            //						this.SetExtractCondtnUI(activeForm);

                            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            Object parameter = (object)printInfo;

                            // �`���[�g�o�͂���H
                            if (activeForm is IPrintConditionInpTypeChart)
                            {
                                // ���o����
                                status = childObj.Extract(ref parameter);
                                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    return;
                            }

                            // �������
                            status = childObj.Print(ref parameter);

                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    {
                                        // PDF�\���̏ꍇ
                                        if (printMode == (int)emPrintMode.emPDF)
                                        {
                                            // �o�c�e�폜���X�g�ɒǉ�
                                            if (printInfo.pdftemppath != "")
                                            {
                                                if (!this._delPDFList.Contains(printInfo.pdftemppath))
                                                {
                                                    this._delPDFList.Add(printInfo.pdftemppath, printInfo.pdftemppath);
                                                }
                                            }

                                            // �o�c�e��ʕ\��
                                            if (printInfo.pdfopen)
                                            {
                                                System.Windows.Forms.Form frm = null;

                                                this.ViewFormTabCreate(info.Key);

                                                this.ViewFormTabActive(info.Key, ref frm);

                                                SFANL07200UB viewFrm = frm as SFANL07200UB;

                                                if (viewFrm != null)
                                                {
                                                    viewFrm.IsSave = true;
                                                    viewFrm.PrintKey = printInfo.key;
                                                    viewFrm.PrintName = printInfo.prpnm;
                                                    viewFrm.PrintDetailName = printInfo.prpnm;
                                                    viewFrm.PrintPDFPath = printInfo.pdftemppath;

                                                    viewFrm.ShowPDFPreview((Object)printInfo.pdftemppath);
                                                }

                                                this.ToolBarSetting(viewFrm);
                                                this.DockManagerCtrlPaneSetting(viewFrm);
                                            }
                                        }
                                        break;
                                    }
                                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case TOOLBAR_EXTRABUTTON_KEY:		// ���o
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by ������ on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by ������ on 2011/10/27 
                        // �����`�F�b�N
                        if (!this.IsPrint()) return;

                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // �A�N�e�B�u�^�u����t�H�[�����擾
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // ����O�`�F�b�N
                            if (!childObj.PrintBeforeCheck()) return;

                            //						// ���ʒ��o�����ݒ� 
                            //						this.SetExtractCondtnUI(activeForm);

                            // ���o����
                            Object parameter = (object)printInfo;
                            int status = childObj.Extract(ref parameter);

                            // �c�[���o�[�{�^���ݒ�
                            this.ToolBarSetting(activeForm);
                            // �h�b�N�}�l�W���[�ݒ�
                            this.DockManagerCtrlPaneSetting(activeForm);
                        }
                        break;
                    }

                case TOOLBAR_PDFSAVEBUTTON_KEY:	// �o�c�e����ۑ�
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by ������ on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by ������ on 2011/10/27 
                        this.SavePDF(this.Main_TabControl.ActiveTab.Key.ToString());
                        break;
                    }
                // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                case TOOLBAR_TEXTOUTPUTBUTTON_KEY:	// TODO:�e�L�X�g�o�́c�@�\�ďo��
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by ������ on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by ������ on 2011/10/27 
                        // �����`�F�b�N
                        if (!this.IsPrint()) return;

                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // �A�N�e�B�u�^�u����t�H�[�����擾
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType && activeForm is IPrintConditionInpTypeTextOutPut)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // ����O�`�F�b�N
                            if (!childObj.PrintBeforeCheck()) return;

                            object parameter = (object)printInfo;

                            // ���o����
                            int status = childObj.Extract(ref parameter);
                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                return;

                            IPrintConditionInpTypeTextOutPut outPutObj = activeForm as IPrintConditionInpTypeTextOutPut;

                            // �p�����[�^�ݒ�
                            printInfo.selectInfoCode = 1;			// �I�����敪(�P�F�e�L�X�g)

                            // �e�L�X�g�o�͏���
                            outPutObj.OutPutText(ref parameter);
                        }
                        break;
                    }
                // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                case TOOLBAR_UPDATEBUTTON_KEY:	// ���s
                    {
                        // �����`�F�b�N
                        if (!this.IsPrint()) return;

                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // �A�N�e�B�u�^�u����t�H�[�����擾
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType && activeForm is IPrintConditionInpTypeUpdate)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.02 ADD
                            // ����{�^���������Ɠ��l��PrintMode���Z�b�g����B
                            printInfo.printmode = (int)emPrintMode.emPrinterAndPDF;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.02 ADD

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // ����O�`�F�b�N
                            if (!childObj.PrintBeforeCheck()) return;

                            object parameter = (object)printInfo;

                            // ���o����
                            int status = childObj.Extract(ref parameter);
                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                return;

                            IPrintConditionInpTypeUpdate updateObj = activeForm as IPrintConditionInpTypeUpdate;

                            // �p�����[�^�ݒ�
                            printInfo.selectInfoCode = 1;			// �I�����敪(�P�F�e�L�X�g)

                            // ���s����
                            updateObj.Update(ref parameter);
                        }
                        break;
                    }
                // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                case TOOLBAR_GRAPHBUTTON_KEY:	// �O���t�\��
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by ������ on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by ������ on 2011/10/27 
                        // ���ʏ�������ʐ���
                        SFCMN00299CA progressForm = new SFCMN00299CA();
                        progressForm.DispCancelButton = false;
                        progressForm.Title = "���̓`���[�g�쐬��";
                        progressForm.Message = "���݁A���̓`���[�g�쐬���ł��D�D�D";

                        try
                        {
                            // �����`�F�b�N
                            if (!this.IsPrint()) return;

                            string key = this.Main_TabControl.ActiveTab.Key.ToString();

                            if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                            {
                                key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                            }
                            else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                            {
                                key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                            }

                            // �A�N�e�B�u�^�u����t�H�[�����擾
                            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                            System.Windows.Forms.Form activeForm = info.Form;

                            if (activeForm is IPrintConditionInpTypeChart)
                            {

                                // ���[���ʃC���^�t�F�[�X���������Ă���Ȃ璊�o�������s��
                                if (activeForm is IPrintConditionInpType)
                                {
                                    IPrintConditionInpType extraObj = activeForm as IPrintConditionInpType;

                                    // ����O�`�F�b�N
                                    if (!extraObj.PrintBeforeCheck()) return;

                                    // >>>>> 2007.07.24 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                                    // ��ʓ��e���m�肳���Ă��
                                    this.Main_TabControl.Focus();
                                    // <<<<< 2007.07.24 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                                    // �`���[�g�^�u�̃N���A
                                    this.ClearChartTabForm(info);

                                    // �`���[�g�o�͂���H
                                    if (activeForm is IPrintConditionInpTypeChart)
                                    {
                                        // ���o����
                                        object para = 0;
                                        int status = extraObj.Extract(ref para);
                                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                            return;
                                    }
                                }

                                // ���o�����p�����[�^���擾
                                object paramater = null;
                                if (activeForm is IPrintConditionInpTypeCondition)
                                {
                                    paramater = ((IPrintConditionInpTypeCondition)activeForm).ObjExtract;
                                }

                                IPrintConditionInpTypeChart childObj = activeForm as IPrintConditionInpTypeChart;

                                // �`���[�g���o�N���X�����o���擾����
                                List<IChartExtract> chartExtractMember;
                                childObj.GetChartExtractMember(out chartExtractMember);

                                if (chartExtractMember == null) return;

                                // ���̓`���[�g�r���[�t�H�[�����擾�i��̕��̓`���[�g�r���[�t�H�[���ɑ΂��čő�S�܂Ŋi�[�j
                                int viewFormCount = chartExtractMember.Count / 4;
                                if ((chartExtractMember.Count % 4) != 0)
                                {
                                    viewFormCount++;
                                }

                                Form chartViewFrm = null;

                                // ���ʏ�������ʕ\��
                                progressForm.Show(this);

                                // ���̓`���[�g�r���[�t�H�[�����Ǘ��N���X����
                                for (int ix = 0; ix < viewFormCount; ix++)
                                {
                                    this.ChartViewFormTabCreate(info.Key, ix);
                                    this.ChartViewFormTabActive(info.Key, ix, ref chartViewFrm);

                                    List<IChartExtract> extraList = new List<IChartExtract>();

                                    // �Y���`���[�g��ʂɈ����n���`���[�g�p�����[�^�쐬
                                    for (int i = ix * 4; i < (ix + 1) * 4; i++)
                                    {
                                        if ((i + 1) > chartExtractMember.Count)
                                            break;

                                        extraList.Add(chartExtractMember[i]);
                                    }

                                    // �`���[�g�\��
                                    ((AnalysisChartViewForm)chartViewFrm).ChartExtractList = extraList;
                                    ((AnalysisChartViewForm)chartViewFrm).ShowMe(paramater);

                                }

                                // �c�[���o�[�{�^���ݒ�
                                this.ToolBarSetting(chartViewFrm);

                                // �h�b�N�}�l�W���[�ݒ�
                                this.DockManagerCtrlPaneSetting(chartViewFrm);
                            }
                        }
                        finally
                        {
                            // ���ʏ�������ʏI��
                            progressForm.Close();
                        }
                        break;
                    }
                case TOOLBAR_SETUPBUTTON_KEY:	// ���[�U�[�ݒ�
                    {
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new SFANL07200UE();

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
                // --- 2010/08/16 ---------->>>>>
                case TOOLBAR_GUIDEBUTTON_KEY:	// F5:�K�C�h
                    {
                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // �A�N�e�B�u�^�u����t�H�[�����擾
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpTypeGuidExecuter)
                        {
                            ((IPrintConditionInpTypeGuidExecuter)activeForm).ExcuteGuide(sender, e);
                        }

                        break;
                    }
                case TOOLBAR_NEXTPAGEBUTTON_KEY:	// F3�F����
                    {
                        int count = 0;
                        int maxIndex = 0;

                        for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++) {
                            if (this.Main_TabControl.Tabs[i].Visible) {
                                count++;
                                maxIndex = i;
                            }
                        }

                        if (this.Main_TabControl.SelectedTab.Index < maxIndex)
                        {
                            for (int j = this.Main_TabControl.SelectedTab.Index + 1; j <= maxIndex; j++)
                            {
                                if (this.Main_TabControl.Tabs[j].Visible)
                                {
                                    this.Main_TabControl.Tabs[j].Active = true;
                                    this.Main_TabControl.Tabs[j].Selected = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j <= maxIndex; j++)
                            {
                                if (this.Main_TabControl.Tabs[j].Visible)
                                {
                                    this.Main_TabControl.Tabs[j].Active = true;
                                    this.Main_TabControl.Tabs[j].Selected = true;
                                    break;
                                }
                            }
                        }
                        this.setInitFocus();
                        break;
                    }
                case TOOLBAR_CHANGEBUTTON_KEY:	// F2:�ؑ�
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by ������ on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by ������ on 2011/10/27 
                        if (StartNavigatorTree.ContainsFocus)
                        {
                            if (this.Main_TabControl.ActiveTab != null)
                            {
                                this.setInitFocus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Activate();
                                this.tEdit_SectionCode_St.Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Activate();
                                _pdfHistorySerchForm.Controls[1].Controls[0].Focus();
                            }
                        }
                        else if (Main_TabControl.ContainsFocus)
                        {
                            if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Activate();
                                this.tEdit_SectionCode_St.Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Activate();
                                _pdfHistorySerchForm.Controls[1].Controls[0].Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Activate();
                                this.StartNavigatorTree.Nodes[0].Selected = true;
                            }
                        }
                        else if (SelectExplorerBar.ContainsFocus)
                        {
                            if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Activate();
                                _pdfHistorySerchForm.Controls[1].Controls[0].Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Activate();
                                this.StartNavigatorTree.Nodes[0].Selected = true;
                            }
                            else if (this.Main_TabControl.ActiveTab != null)
                            {
                                this.setInitFocus();
                            }
                        }
                        else if (PdfHistory_Panel.ContainsFocus)
                        {
                            if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Activate();
                                this.StartNavigatorTree.Nodes[0].Selected = true;
                            }
                            else if (this.Main_TabControl.ActiveTab != null)
                            {
                                this.setInitFocus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Activate();
                                this.tEdit_SectionCode_St.Focus();
                            }
                        }

                        this.ParentToolbarGuideSettingEvent(false);
                        break;
                    }
                // --- 2010/08/16 ----------<<<<<


            }
        }

        /// <summary>
        /// UltraTabControl.SelectedTabChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">SelectedTabChanged�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �^�u�R���g���[����SelectedTab���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void Main_TabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // --- ADD 2010/08/16 ---------->>>>>
            if (this.Main_TabControl.ActiveTab != null)
            {
                string key = this.Main_TabControl.ActiveTab.Key.ToString();

                if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                {
                    key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                }
                else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                {
                    key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                }

                // �A�N�e�B�u�^�u����t�H�[�����擾
                FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                System.Windows.Forms.Form activeForm = info.Form;

                Infragistics.Win.UltraWinToolbars.ButtonTool guideButtonTool;
                // F5:�K�C�h
                guideButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
                if (guideButtonTool != null)
                {
                    if (activeForm is IPrintConditionInpTypeGuidExecuter)
                    {
                        guideButtonTool.SharedProps.Visible = true;
                    }
                    else
                    {
                        guideButtonTool.SharedProps.Visible = false;
                    }
                }
            }
            else
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool guideButtonTool;
                // F5:�K�C�h
                guideButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
                if (guideButtonTool != null)
                {
                    guideButtonTool.SharedProps.Visible = false;
                }
            }
            // --- ADD 2010/08/16 ----------<<<<<

            if (!this._isEvent) return;

            this._isEvent = false;

            try
            {
                // �I���^�u�ύX���c���[�m�[�h�I������
                SelectedTabChangedNodeSelect();

                if (e.Tab != null)
                {
                    if (this._navigaterMenuMode)
                    {
                        this.Text = MAIN_TITLE + "�|" + e.Tab.Text;
                    }

                    // �e��KEY���擾
                    string key = e.Tab.Key.ToString();

                    if (e.Tab.Tag is SFANL07200UB)
                    {
                        key = ((SFANL07200UB)e.Tab.Tag).FormControlInfoKey;
                    }
                    else if (e.Tab.Tag is AnalysisChartViewForm)
                    {
                        key = ((AnalysisChartViewForm)e.Tab.Tag).FormControlInfoKey;
                    }

                    if (!this._formControlInfoTable.ContainsKey(key))
                    {
                        return;
                    }

                    this.Main_TabControl.Focus();

                    FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[key];
                    Form targetForm = e.Tab.Tag as Form;

                    if (targetForm is IPrintConditionInpType)
                    {
                        // ���C���t���[���̌ʉ�ʐݒ�
                        this.ScreenPrivateSetting(key, targetForm);

                        // �o�͏����I���y�C�����Œ�
                        this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, true);

                        // �N���q��ʃA�N�e�B�u������		
                        this.TabActive(key, ref targetForm);
                    }
                    else if (targetForm is SFANL07200UB)
                    {
                        // �o�͏����I���y�C�����Œ�
                        this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, false);

                        // �r���[�t�H�[�����A�N�e�B�u��
                        this.ViewFormTabActive(key, ref targetForm);
                    }
                    else if (targetForm is AnalysisChartViewForm)
                    {
                        // �o�͏����I���y�C�����Œ�
                        this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, false);

                        // �r���[�t�H�[�����A�N�e�B�u��
                        this.ChartViewFormTabActive(key, ((AnalysisChartViewForm)targetForm).Number, ref targetForm);
                    }

                    // �N���i�r�Q�[�^�[�y�C�����Œ�
                    this.PinnedDockManagerControlPane(DOCKMANAGER_NAVIGATOR_KEY, false);

                    // �o�͗��������y�C�����Œ�
                    this.PinnedDockManagerControlPane(DOCKMANAGER_PDFHISTORTY_KEY, false);

                    if (targetForm != null)
                    {
                        this.ToolBarSetting(targetForm);
                        this.DockManagerCtrlPaneSetting(targetForm);
                    }

                }
                else
                {
                    this.Text = MAIN_TITLE;
                }
            }
            finally
            {
                this._isEvent = true;
            }
        }

        /// <summary>
        /// UltraTabControl.TabMoved �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">TabMoved�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �^�u���ړ����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.04.22</br>
        /// </remarks>
        private void Main_TabControl_TabMoved(object sender, Infragistics.Win.UltraWinTabControl.TabMovedEventArgs e)
        {
            if (!this._isEvent) return;

            if (e.Tab == null) return;

            string key = e.Tab.Key;
            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[key];

            Form targetForm = null;
            int index = e.Tab.Key.IndexOf(TAB_VIEWFORM_ADDKEY);
            if (index == -1)
            {
                targetForm = formControlInfo.Form;

                // �N���q��ʃA�N�e�B�u������		
                this.TabActive(key, ref targetForm);
            }
            else
            {
                targetForm = formControlInfo.ViewForm;

                // �r���[�t�H�[�����A�N�e�B�u��
                this.ViewFormTabActive(key, ref targetForm);
            }
        }

        /// <summary>
        /// �v�㋒�_�I����ԕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�\�[�X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �R���g���[���̒l���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void AddUpCd_UOptionSet_ValueChanged(object sender, System.EventArgs e)
        {
            if (!this._isEvent) return;

            // �A�N�e�B�u�^�u�͑��݂��邩
            if (this.Main_TabControl.ActiveTab == null) return;

            //--------------------------------------------------------------------------
            // �A�N�e�B�u�ȏ������͂t�h�ւ̒ʒm����
            //--------------------------------------------------------------------------
            // �A�N�e�B�u�^�u����t�H�[�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
            IPrintConditionInpTypeSelectedSection target = info.Form as IPrintConditionInpTypeSelectedSection;

            int addCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.DataValue.ToString(), 0);

            if (target != null)
            {
                if (target.VisibledSelectAddUpCd)
                {
                    // �I�����_��ނ�ʒm
                    target.SelectedAddUpCd(addCode);
                    info.SelSectionKindIndex = this.AddUpCd_UOptionSet.CheckedIndex;
                }
            }

            // �v�㋒�_�̑I���ɂ�萧��@�\�R�[�h��ؑւ�
            int ctrlFuncCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.Tag.ToString(), 0);

            string ctrlSecCode;
            this.GetOwnSeCtrlCode(this._loginSectionCode, ctrlFuncCode, out ctrlSecCode);
            string[] selSections = new string[] { ctrlSecCode };

            // ���_�����ݒ�f���Q�[�g
            if (target != null)
            {
                // �I�����_��ނ�ʒm
                target.InitSelectSection(selSections);
                info.SelSections = selSections;
            }

            //--------------------------------------------------------------------------
            // ���C���t���[���֘A�̏���
            //--------------------------------------------------------------------------
            // �{�Ћ@�\���̂�
            if (this._isMainOfficeFunc)
            {
                // ���_�ύX�C�x���g�𔭐������Ȃ��ׁA�C�x���g��OFF
                this._isEvent = false;
                try
                {
                    // �S�Ẵ`�F�b�N���͂���
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                    {
                        utn.CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // �Y�����_�R�[�h�Ƀ`�F�b�N
                    if (this._secInfoLst.ContainsKey(ctrlSecCode))
                    {
                        this.Section_UTree.Nodes[ctrlSecCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                    }
                }
                finally
                {
                    this._isEvent = true; ;
                }
            }
        }

        /// <summary>
        /// ���_�I���`�F�b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : checkedState�v���p�e�B���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void Section_UTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (!this._isEvent) return;

            if (this._secNodeCheckEvent) return;

            // �C�x���g���t���OON
            this._secNodeCheckEvent = true;

            // �A�N�e�B�u�^�u�͑��݂��邩
            if (this.Main_TabControl.ActiveTab == null) return;

            // �r���[�t�H�[���̏ꍇ�͐e��KEY���擾
            string key = this.Main_TabControl.ActiveTab.Key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

            // �A�N�e�B�u�^�u����t�H�[�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
            IPrintConditionInpTypeSelectedSection target = info.Form as IPrintConditionInpTypeSelectedSection;

            try
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode utnAll =
                    this.Section_UTree.GetNodeByKey(CT_AllSectionCode);

                // �h�S�Ёh�w�肳�ꂽ
                if (e.TreeNode.Key.ToString().Equals(CT_AllSectionCode))
                {
                    // �I��
                    if (utnAll != null)
                    {
                        if (utnAll.CheckedState == CheckState.Checked)
                        {
                            // ���̑��̍��ڂ̃`�F�b�N���͂���
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                            {
                                if (utn.Key.Equals(CT_AllSectionCode) == false)
                                {
                                    utn.CheckedState = CheckState.Unchecked;
                                }
                            }
                        }
                    }
                }
                // ���̑����_
                else
                {
                    if (utnAll != null)
                    {
                        if (utnAll.CheckedState == CheckState.Checked)
                        {
                            utnAll.CheckedState = CheckState.Unchecked;

                            if (target != null)
                            {
                                target.CheckedSection(utnAll.Key.ToString(), CheckState.Unchecked);
                            }

                        }
                    }
                }

                if (target != null)
                {
                    target.CheckedSection(e.TreeNode.Key.ToString(), e.TreeNode.CheckedState);
                }

                // �I������Ă��鋒�_����ۑ�
                if (info != null)
                {
                    ArrayList selSecList = new ArrayList();
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                    {
                        if (utn.CheckedState == CheckState.Checked)
                        {
                            selSecList.Add(utn.Key.ToString());
                        }
                    }
                    string[] selSections = (string[])selSecList.ToArray(typeof(string));
                    info.SelSections = selSections;
                }

            }
            finally
            {
                e.TreeNode.Selected = true;
                this._secNodeCheckEvent = false;
            }
        }

        /// <summary>
        /// �V�X�e���I���`�F�b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : checkedState�v���p�e�B���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void System_UTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (!this._isEvent) return;

            if (this._sysNodeCheckEvent) return;

            // �C�x���g���t���OON
            this._sysNodeCheckEvent = true;

            // �A�N�e�B�u�^�u�͑��݂��邩
            if (this.Main_TabControl.ActiveTab == null) return;

            // �r���[�t�H�[���̏ꍇ�͐e��KEY���擾
            string key = this.Main_TabControl.ActiveTab.Key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

            // �A�N�e�B�u�^�u����t�H�[�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
            IPrintConditionInpTypeSelectedSystem target = info.Form as IPrintConditionInpTypeSelectedSystem;

            try
            {
                if (target != null)
                {
                    int sysCode = TStrConv.StrToIntDef(e.TreeNode.Key.ToString(), 0);
                    target.CheckedSystem(sysCode, e.TreeNode.CheckedState);

                    // �I������Ă���V�X�e������ۑ�
                    if (info != null)
                    {
                        ArrayList selSysList = new ArrayList();
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
                        {
                            if (utn.CheckedState == CheckState.Checked)
                            {
                                selSysList.Add(utn.Key.ToString());
                            }
                        }

                        int[] selSystems = new int[selSysList.Count];

                        for (int i = 0; i < selSysList.Count; i++)
                        {
                            int wkInt = TStrConv.StrToIntDef(selSysList[i].ToString(), -1);
                            selSystems[i] = wkInt;
                        }
                        info.SelSystems = selSystems;
                    }
                }

            }
            finally
            {
                e.TreeNode.Selected = true;
                this._sysNodeCheckEvent = false;
            }
        }

        /// <summary>
        /// �|�b�v���j���[�u����v�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �u����v�{�^���������ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.03.28</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            if (this.Main_TabControl.ActiveTab == null) return;

            string key = this.Main_TabControl.ActiveTab.Key;

            // �^�u�\���ύX
            this.TabVisibleChange(key, false);

            // �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
            this.CreateWindowStateButtonTools();

            // >>>>> 2007.06.29 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            if (this.Main_TabControl.Tabs.Count == 0)
            {
                this.ToolBarSetting(null);
            }
            else
            {
                this.ToolBarSetting(this.Main_TabControl.ActiveTab);
            }
            // <<<<< 2007.06.29 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        }

        /// <summary>
        ///	�t�H�[������悤�Ƃ������̃C�x���g�ł��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[��������ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.05.01</br>
        /// </remarks>
        private void SFANL07200UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // �C�x���g�𐧌䂷��ׁA�t���O��OFF��
            this._isEvent = false;

            //int tabCnt = this.Main_TabControl.Tabs.Count;
            //for (int i = 0; i < tabCnt; i++)
            //{
            //    this.Main_TabControl.Tabs.RemoveAt(0);
            //}

            // �e���[�̃u���E�U�ɋ�A�h���X��\�������܂��B�\�����Ă���PDF�t�@�C�������ׂł��B
            foreach (DictionaryEntry entry in this._formControlInfoTable)
            {
                FormControlInfo info = entry.Value as FormControlInfo;
                if (info != null)
                {
                    SFANL07200UB viewFrm = info.ViewForm as SFANL07200UB;
                    if (viewFrm != null)
                    {
                        viewFrm.ShowPDFPreview("about:blank");
                        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                        viewFrm.Close();
                        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
                        viewFrm.Dispose();
                    }
                }
            }

            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_TabControl.Tabs)
            {
                this.Main_TabControl.Tabs.Remove(tab);
            }

            // �v���r���[�Ő��������o�c�e�t�@�C�����폜���܂��B
            int tryCnt;
            foreach (DictionaryEntry wkEntry in this._delPDFList)
            {
                if (System.IO.File.Exists(wkEntry.Value.ToString()))
                {
                    tryCnt = 0;
                    while (tryCnt < 3)
                    {
                        try
                        {
                            System.IO.File.Delete(wkEntry.Value.ToString());
                            break;
                        }
                        // --- UPD 2021/01/04 �x���Ή� ------>>>>
                        //catch (System.IO.IOException ex)
                        catch (System.IO.IOException)
                        // --- UPD 2021/01/04 �x���Ή� ------<<<<
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        tryCnt++;
                    }
                }
            }
        }

        #region <���_�͈͎̔w��/>

        /// <summary>
        /// �J�n���_�R�[�h�e�L�X�g�{�b�N�X��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void startRangeTNedit_Leave(object sender, EventArgs e)
        {
            SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);
        }

        /// <summary>
        /// �I�����_�R�[�h�e�L�X�g�{�b�N�X��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void endRangeTNedit_Leave(object sender, EventArgs e)
        {
            SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);

            // �J�n���_�R�[�h�֖߂�
            if (_focusStartRangeFlag)
            {
                _focusStartRangeFlag = false;
                this.tEdit_SectionCode_St.Focus();
            }
        }

        /// <summary>�J�n���_�R�[�h��I������t���O</summary>
        private bool _focusStartRangeFlag;

        /// <summary>
        /// [Enter]�L�[�Ńt�H�[�J�X�ړ������Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// <br>UpdateNote  : �L�[�{�[�h����̉��ǂ��s���B</br>
        /// <br>Programmer  : PM1012C �� ��</br>
        /// <br>Date        : 2010/08/16</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl != null)
            {
                Debug.WriteLine("���O�̃R���g���[���F" + e.PrevCtrl.Name);
            }
            else
            {
                Debug.WriteLine("���O�̃R���g���[���Fnull");
            }

            // ���_��I�����鏈��
            if ((e.PrevCtrl == this.tEdit_SectionCode_St) || (e.PrevCtrl == this.tEdit_SectionCode_Ed))
            {
                CheckSectionTreeNode(this.tEdit_SectionCode_St.Text.Trim(), this.tEdit_SectionCode_Ed.Text.Trim());

                // �J�n���_�R�[�h�֖߂�
                if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                {
                    _focusStartRangeFlag = true;
                }
            }

            // ---ADD 2010/08/16-------------------->>>
            if (e.Key == Keys.Enter)
            {
                // �N���i�r�Q�[�^��Enter�L�[���������ꂽ��
                if (this.StartNavigatorTree.ContainsFocus)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode keyDownNode =
                    this.StartNavigatorTree.SelectedNodes[0];
                    if (keyDownNode == null) return;

                    FormControlInfo info = this._formControlInfoTable[keyDownNode.Key.ToString()] as FormControlInfo;
                    if (info == null) return;

                    // --- ADD 2010/08/26 ---------->>>>>
                    if (info.Form is IPrintConditionInpTypeGuidExecuter)
                    {
                        ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                        ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
                    }
                    // --- ADD 2010/08/26 ----------<<<<<
                    // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
                    if (info.Form is IPrintConditionInpTypeTextOutControl)
                    {
                        ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                        ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
                    }
                    // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<


                    if (keyDownNode.Level == 2)
                    {
                        if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                        {
                            if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                                EntityUtil.CategoryCode.Report,
                                MyOpeCtrlMap.AddController(info.AssemblyID),
                                info.AssemblyID,
                                info.Name
                            ))
                            {
                                // �N���s�̂��ߋ����I��
                                return;
                            }
                        }

                        Infragistics.Win.UltraWinTree.UltraTreeNode node = keyDownNode;

                        // �������͉��UI�N������
                        ShowChildInputForm(node.Key.ToString());

                        keyDownNode.Override.NodeAppearance.ForeColor = Color.Red;

                        BeginControllingByOperationAuthority(info.AssemblyID);
                    }
                }
            }
            // ---ADD 2010/08/16--------------------<<<
        }

        /// <summary>
        /// ���_�͈̔͂��w�肷��UI��ݒ肵�܂��B
        /// </summary>
        /// <param name="sectionCodeUI">���_�R�[�hUI</param>
        /// <param name="sectionNameUI">���_����UI</param>
        /// <param name="defaultText">UI�ɉ������e�L�X�g</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void SetSectionRangeUI(
            Broadleaf.Library.Windows.Forms.TNedit sectionCodeUI,
            Infragistics.Win.UltraWinEditors.UltraTextEditor sectionNameUI,
            string defaultText
        )
        {
            // �ŏ�����^�Ō�܂�
            if (string.IsNullOrEmpty(sectionCodeUI.Text.Trim()))
            {
                sectionNameUI.Text = defaultText;
                return;
            }

            // �S��
            if (int.Parse(sectionCodeUI.Text.Trim()).Equals(0))
            {
                // �J�n
                this.tEdit_SectionCode_St.Text = int.Parse(CT_AllCtrlFuncSecCode).ToString(SECTION_CODE_FORMAT);
                this.startRangeNameUltraTextEditor.Text = CT_AllCtrlFuncSecName;

                // �I��
                this.tEdit_SectionCode_Ed.Text = int.Parse(CT_AllCtrlFuncSecCode).ToString(SECTION_CODE_FORMAT);
                this.endRangeNameUltraTextEditor.Text = CT_AllCtrlFuncSecName;

                return;
            }

            // �C��
            string sectionCode = int.Parse(sectionCodeUI.Text.Trim()).ToString(SECTION_CODE_FORMAT);
            sectionCodeUI.Text = sectionCode;
            sectionNameUI.Text = GetSectionName(sectionCode);
        }

        /// <summary>
        /// ���_�c���[�̃m�[�h���`�F�b�N��Ԃɂ��܂��B
        /// </summary>
        /// <param name="startSectionCode">�J�n���_�R�[�h</param>
        /// <param name="endSectionCode">�I�����_�R�[�h</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void CheckSectionTreeNode(
            string startSectionCode,
            string endSectionCode
        )
        {
            // �J�n���_�R�[�h�l
            int startCode = MIN_SECTION_CODE;
            if (!string.IsNullOrEmpty(startSectionCode))
            {
                startCode = int.Parse(startSectionCode);
                if (startCode < 0) startCode = MIN_SECTION_CODE;
            }
            // --- ADD 2009/01/19 ��QID:9982�Ή�------------------------------------------------------>>>>>
            else
            {
                if ((startSectionCode == null) || (startSectionCode.Trim() == ""))
                {
                    startCode = 0;
                }
            }
            // --- ADD 2009/01/19 ��QID:9982�Ή�------------------------------------------------------<<<<<

            // �I�����_�R�[�h�l
            int endCode = MAX_SECTION_CODE;
            if (!string.IsNullOrEmpty(endSectionCode))
            {
                endCode = int.Parse(endSectionCode);
                if (endCode > MAX_SECTION_CODE) endCode = MAX_SECTION_CODE;
            }
            // --- ADD 2009/01/19 ��QID:9982�Ή�------------------------------------------------------>>>>>
            else
            {
                if ((endSectionCode == null) || (endSectionCode.Trim() == ""))
                {
                    endCode = 99;
                }
            }
            // --- ADD 2009/01/19 ��QID:9982�Ή�------------------------------------------------------<<<<<

            // --- DEL 2009/01/19 ��QID:9982�Ή�------------------------------------------------------>>>>>
            //// �S�Ўw��̕␳
            //int allSectionCode = int.Parse(CT_AllSectionCode);
            //if (startCode.Equals(allSectionCode) || endCode.Equals(allSectionCode))
            //{
            //    startCode = allSectionCode;
            //    endCode = allSectionCode;
            //}
            // --- DEL 2009/01/19 ��QID:9982�Ή�------------------------------------------------------<<<<<

            if (startCode > endCode)
            {
                const string MSG = "�J�n���_�R�[�h���I�����_�R�[�h���傫�Ȓl�ł��B";  // LITERAL:
                this.Main_StatusBar.Panels["Text"].Text = MSG;
                return;
            }
            else
            {
                this.Main_StatusBar.Panels["Text"].Text = string.Empty;
            }

            // --- ADD 2009/01/19 ��QID:9982�Ή�------------------------------------------------------>>>>>
            for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
            {
                // �����I�ɖ��I���ɂ���
                if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                {
                    this.Section_UTree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                }
            }

            if (((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0)) &&
                ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0)))
            {
                // �S�БI��
                this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = CheckState.Checked;
            }
            else
            {
                if ((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0))
                {
                    startCode = MIN_SECTION_CODE;
                }
                else
                {
                    startCode = int.Parse(startSectionCode);
                }
                if ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0))
                {
                    endCode = MAX_SECTION_CODE;
                }
                else
                {
                    endCode = int.Parse(endSectionCode);
                }

                for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
                {
                    // �����I�ɖ��I���ɂ���
                    if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                    {
                        this.Section_UTree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // �J�n���_�R�[�h�l�ƏI�����_�R�[�h�l�͈͓̔��Ȃ�A�I������i�S�Ўw��̏ꍇ�A�S�Ђ�I������j
                    int sectionCode = int.Parse(this.Section_UTree.Nodes[i].Key);
                    if ((startCode <= sectionCode) && (sectionCode <= endCode))
                    {
                        if (!sectionCode.Equals(int.Parse(CT_AllSectionCode)))
                        {
                            string key = sectionCode.ToString(SECTION_CODE_FORMAT);
                            if (this._secInfoLst.ContainsKey(key))
                            {
                                this.Section_UTree.Nodes[key].CheckedState = System.Windows.Forms.CheckState.Checked;
                            }
                        }
                        else
                        {
                            this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }
                }
            }
            // --- ADD 2009/01/19 ��QID:9982�Ή�------------------------------------------------------<<<<<

            // --- DEL 2009/01/19 ��QID:9982�Ή�------------------------------------------------------>>>>>
            //// �m�[�h�I��
            //for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
            //{
            //    // �����I�ɖ��I���ɂ���
            //    if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
            //    {
            //        this.Section_UTree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
            //    }

            //    // �J�n���_�R�[�h�l�ƏI�����_�R�[�h�l�͈͓̔��Ȃ�A�I������i�S�Ўw��̏ꍇ�A�S�Ђ�I������j
            //    int sectionCode = int.Parse(this.Section_UTree.Nodes[i].Key);
            //    if ((startCode <= sectionCode) && (sectionCode <= endCode))
            //    {
            //        if (!sectionCode.Equals(int.Parse(CT_AllSectionCode)))
            //        {
            //            string key = sectionCode.ToString(SECTION_CODE_FORMAT);
            //            if (this._secInfoLst.ContainsKey(key))
            //            {
            //                this.Section_UTree.Nodes[key].CheckedState = System.Windows.Forms.CheckState.Checked;
            //            }
            //        }
            //        else
            //        {
            //            this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
            //        }
            //    }
            //}
            // --- DEL 2009/01/19 ��QID:9982�Ή�------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �y�C�����\�����ꂽ�Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void Main_DockManager_PaneDisplayed(object sender, Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs e)
        {
            if (e.Pane.Control.Name.Equals("SelectExplorerBar"))  // TODO:this.SelectExplorerBar�̖��O��ύX�����ꍇ�A�������ύX
            {
                e.Pane.Control.Select();
                this.tEdit_SectionCode_St.Focus();
            }
        }

        /// <summary>
        /// �t�H�[�J�X���ω������Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.NextCtrl == this.tEdit_SectionCode_St)
            {
                this.tEdit_SectionCode_St.Focus();
                this.tEdit_SectionCode_St.SelectAll();
                return;
            }
            if (e.NextCtrl == this.tEdit_SectionCode_Ed)
            {
                this.tEdit_SectionCode_Ed.Focus();
                this.tEdit_SectionCode_Ed.SelectAll();
                return;
            }
        }

        #endregion  // <���_�͈͎̔w��/>

        // --- ADD 2010/08/16 ---------->>>>>
        /// <summary>
        /// getFirstControl
        /// </summary>
        /// <param name="firstControl"></param>
        /// <param name="parentControl"></param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�{�[�h����̉��ǂ̑Ή�</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/16</br>
        /// </remarks>
        private void getFirstControl(ref Control firstControl, Control parentControl)
        {
            bool flg = false;
            foreach (Control control in parentControl.Controls)
            {
                if (!(control is Panel))
                {
                    flg = true;
                }
            }

            List<Control> controlList = new List<Control>();
            if (!flg)
            {
                Control firstPanel = new Control();
                firstPanel.Left = 1024;
                firstPanel.Top = 768;
                foreach (Control control in parentControl.Controls)
                {
                    if (control.Top < firstPanel.Top)
                    {
                        firstPanel = control;
                    }
                    else if (control.Top == firstPanel.Top)
                    {
                        if (control.Left < firstPanel.Left)
                        {
                            firstPanel = control;
                        }
                    }
                }

                foreach (Control controlTmp in firstPanel.Controls)
                {
                    controlList.Add(controlTmp);
                }
            }
            else
            {
                foreach (Control control in parentControl.Controls)
                {
                    controlList.Add(control);
                }
            }

            foreach (Control control in controlList)
            {
                if (control.Visible && control.Enabled && control.CanFocus && (control is TEdit || control is TNedit || control is TComboEditor
                            || control is TDateEdit || control is UltraOptionSet || control is UltraButton))
                {
                    if (control.Top < firstControl.Top)
                    {
                        firstControl = control;
                    }
                    else if (control.Top == firstControl.Top)
                    {
                        if (control.Left < firstControl.Left)
                        {
                            firstControl = control;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// getFirstExplorerBarContainerControl
        /// </summary>
        /// <param name="firstExplorerBar"></param>
        /// <param name="parentControl"></param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�{�[�h����̉��ǂ̑Ή�</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/16</br>
        /// </remarks>
        private void getFirstExplorerBarContainerControl(ref Control firstExplorerBar, Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (!(control is Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl) && control.Controls.Count != 0)
                {
                    getFirstExplorerBarContainerControl(ref firstExplorerBar, control);
                }
                else
                {
                    if (control is Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl && control.Visible && control.Enabled)
                    {
                        if (control.Top < firstExplorerBar.Top)
                        {
                            firstExplorerBar = control;
                        }
                        else if (control.Top == firstExplorerBar.Top)
                        {
                            if (control.Left < firstExplorerBar.Left)
                            {
                                firstExplorerBar = control;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// �v�����g�̏���
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�{�[�h����̉��ǂ̑Ή�</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/26</br>
        /// </remarks>
        public void ParentPrint()
        {
            object sender = new object();
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e = new Infragistics.Win.UltraWinToolbars.ToolClickEventArgs(this.Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY], null);

            this.Main_ToolbarsManager_ToolClick(sender, e);
        }

        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
        /// <summary>
        /// �e�L�X�g�o�̓{�^���̐���
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �e�L�X�g�o�̓{�^���̐���</br>
        /// <br>Programmer  : licb</br>
        /// <br>Date        : K2014/03/10</br>
        /// </remarks>
        public void TextOutControl()
        {
            //�e�L�X�g�o�́cUSB�`�F�b�N
            PurchaseStatus purchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            //�M�z�cUSB�`�F�b�N
            PurchaseStatus sletuPurchaseStatus =
                            LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl);
            if ((purchaseStatus == PurchaseStatus.Contract ||			// �e�L�X�g�o�͌_���
                    purchaseStatus == PurchaseStatus.Trial_Contract) &&   // �e�L�X�g�o�͑̌��Ō_���
                    (sletuPurchaseStatus == PurchaseStatus.Contract || // �M�z�_���
                    sletuPurchaseStatus == PurchaseStatus.Trial_Contract))// �M�z�̌��Ō_���
            {
                //�e�L�X�g�o�̓{�^��
                Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                if (buttonTool != null)
                {

                    buttonTool.SharedProps.Visible = true;
                }
            }
            else
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Visible = false;
                }

            }
        }
        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
        /// <summary>
        /// ���������̃t�H�[�J�X���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ���������̃t�H�[�J�X���擾����</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/26</br>
        /// </remarks>
        private void setInitFocus() {
            string key = this.Main_TabControl.ActiveTab.Key.ToString();

            if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
            {
                this.Main_TabControl.Focus();
                return;
            }
            else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
            {
                key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
            }

            // �A�N�e�B�u�^�u����t�H�[�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
            System.Windows.Forms.Form activeForm = info.Form;

            Control firstPanel = new Control();
            firstPanel.Left = 1024;
            firstPanel.Top = 768;
            foreach (Control parentControl in activeForm.Controls)
            {
                getFirstExplorerBarContainerControl(ref firstPanel, parentControl);
            }
            Control firstControl = new Control();
            firstControl.Left = 1024;
            firstControl.Top = 768;
            getFirstControl(ref firstControl, firstPanel);
            firstControl.Focus();
        }
        // --- ADD 2010/08/16 ----------<<<<<
    }

    // -----ADD 2011/03/14  ---------->>>>>
    #region ���_�c���[�R���g���[���̃w���p

    /// <summary>
    /// ���_�c���[�R���g���[���̃w���p�N���X
    /// </summary>
    internal static class SectionTreeHelper
    {
        /// <summary>
        /// �G�N�X�|�[�g�t�@�C���̃t���p�X���擾���܂��B
        /// </summary>
        private static string ExportPathName
        {
            get
            {
                return @".\UISettings\DCKAU02520U_SectionSetting.xml";
            }
        }

        /// <summary>
        /// �`�F�b�N����Ă��鋒�_�R�[�h���G�N�X�|�[�g���܂��B
        /// </summary>
        /// <param name="sectionTree">���_�c���[�R���g���[��</param>
        /// <param name="enabled">�L���t���O</param>
        public static void ExportCheckedSectionCode(
            Infragistics.Win.UltraWinTree.UltraTree sectionTree,
            bool enabled
        )
        {
            #region Guard Phrase

            if (sectionTree == null) return;
            if (!enabled) return;

            #endregion // Guard Phrase

            List<string> sectionPairList = new List<string>();

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in sectionTree.Nodes)
            {
                if (sectionNode.CheckedState.Equals(CheckState.Checked))
                {
                    sectionPairList.Add(sectionNode.Key);
                }
            }

            System.IO.FileStream outputFile = null;
            try
            {
                outputFile = new System.IO.FileStream(ExportPathName, System.IO.FileMode.Create);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
                serializer.Serialize(outputFile, sectionPairList);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (outputFile != null) outputFile.Close();
            }
        }

        /// <summary>
        /// �`�F�b�N����Ă������_�R�[�h���C���|�[�g���܂��B
        /// </summary>
        /// <param name="sectionTree">���_�c���[�R���g���[��</param>
        /// <param name="enabed">�L���t���O</param>
        /// <returns>
        /// <c>true</c> :�C���|�[�g���܂����B<br/>
        /// <c>false</c>:�C���|�[�g���܂���ł����B
        /// </returns>
        public static bool ImportCheckedSectionCode(
            Infragistics.Win.UltraWinTree.UltraTree sectionTree,
            bool enabed
        )
        {
            #region Guard Phrase

            if (sectionTree == null) return false;
            if (!System.IO.File.Exists(ExportPathName)) return false;
            if (!enabed) return false;

            #endregion // Guard Phrase

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));

            bool checkedTree = false;
            System.IO.FileStream inputFile = null;
            try
            {
                inputFile = new System.IO.FileStream(ExportPathName, System.IO.FileMode.Open);
                List<string> checkedSectionCodeList = (List<string>)serializer.Deserialize(inputFile);
                if (checkedSectionCodeList == null) return false;

                foreach (string sectionCode in checkedSectionCodeList)
                {
                    if (sectionTree.Nodes.Exists(sectionCode))
                    {
                        sectionTree.Nodes[sectionCode].CheckedState = CheckState.Checked;
                        checkedTree = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (inputFile != null) inputFile.Close();
            }
            return checkedTree;
        }
    }

    #endregion // ���_�c���[�R���g���[���̃w���p
    // -----ADD 2011/03/14  ----------<<<<<
}