//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : UOE������ݒ�
// �v���O�����T�v   : UOE������}�X�^���̐ݒ���s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2008/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/01  �C�����e : ���[�J�[���̐�p���ڂ��^�u�ŕ\������悤�ɕύX
//           2009/08/12  �C�����e : �񓚕ۑ��t�H���_�̓��̓`�F�b�N�𖳌��ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ė� �x��
// �C �� ��  2009/09/14  �C�����e : MANTIS�y14242�z�����\���[�J�[�\�������s��
// �C �� ��  2009/09/14  �C�����e : MANTIS�y14243�z�C���ďo���w�����l�ݒ荀�ځx�́w�w�苒�_�x���\������Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : xuxh
// �C �� ��  2009/12/29  �C�����e : �y�v��No.1�z
//                                  �g���^�d�q�J�^���O�Ŏg�p���鑗�M�E��M�f�[�^�̕ۑ��ꏊ��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : 杍^
// �C �� ��  2010/01/19  �C�����e : Redmine:2505
//                                  Redmine�w�E�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �k���r
// �C �� ��  2010/03/08  �C�����e : PM1006
//                                  ���YWeb-UOE�A�����ڂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : jiangk
// �C �� ��  2010/04/23  �C�����e : PM1007C
//                                  �O�HWeb-UOE�A�����ڂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ������
// �C �� ��  2010/05/14  �C�����e : PM1008
//                                  ����UOEWeb���ڂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : ���
// �C �� ��  2010/07/27  �C�����e : PM1011
//                                  �g���^UOEWeb���ڂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : 杍^
// �� �� ��  2010/12/31  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : �{�w�C��
// �� �� ��  2011/01/28  �C�����e : �񓚎����捞�敪�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �� �� ��  2011/03/01  �C�����e : �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �� �� ��  2011/03/15  �C�����e : �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �{�w�C��
// �� �� ��  2011/05/10  �C�����e : �񓚕ۑ��t�H���_�i�}�c�_WebUOE�p�A�g�t�@�C���̊i�[�ꏊ�j�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/10/26  �C�����e : PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/12/15  �C�����e : Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��
// �� �� ��  2012/09/10  �C�����e : BL�Ǘ����[�U�[�R�[�h�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE������}�X�^ �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE������}�X�^���̐ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2008.06.26</br>
    /// <br>UpdateNote  : 2009/06/01 �Ɠc �M�u�@���[�J�[���̐�p���ڂ��^�u�ŕ\������悤�ɕύX</br>
    /// <br>                                    �z���_e-Parts���ڂ�ǉ�</br>
    /// <br>UpdateNote  : 2009/12/29 xuxh</br>
    /// <br>              �y�v��No.1�z</br>
    /// <br>              �g���^�d�q�J�^���O�Ŏg�p���鑗�M�E��M�f�[�^�̕ۑ��ꏊ��ݒ肷��</br> 
    /// <br>Update Note : 2010/01/19 杍^</br>
    /// <br>              Redmine:2505</br>
    /// <br>              Redmine�w�E�̑Ή�</br>
    /// <br>Update Note : 2010/03/08 �k���r</br>
    /// <br>              PM1006</br>
    /// <br>              ���YWeb-UOE�A�����ڂ̑Ή�</br>
	/// <br>Update Note : 2010/04/23 jiangk</br>
	/// <br>              PM1007C</br>
	/// <br>              �O�HWeb-UOE�A�����ڂ̑Ή�</br>
    /// <br>Update Note : 2010/05/14 ������</br>
    /// <br>              PM1008</br>
    /// <br>              ����UOEWeb���ڂ̑Ή�</br>
    /// <br>Update Note : 2010/07/27 ���</br>
    /// <br>              PM1011</br>
    /// <br>              �g���^UOEWeb���ڂ̑Ή�</br>
    /// <br>UpdateNote  : 2010/12/31 杍^</br>
    /// <br>            : UOE����������</br>
    /// <br>UpdateNote  : 2011/01/28 �{�w�C��</br>
    /// <br>            :�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
    /// <br>Update Note      :  2011/03/01 liyp</br>
    /// <br>       �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
    /// <br>Update Note  : 2011/03/15 liyp </br>
    /// <br>               �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���</br>
    /// <br>UpdateNote  : 2011/05/10 �{�w�C��</br>
    /// <br>            : �񓚕ۑ��t�H���_�i�}�c�_WebUOE�p�A�g�t�@�C���̊i�[�ꏊ�j�̒ǉ�</br>
    /// <br>UpdateNote  : 2011/10/26 ������</br>
    /// <br>            : PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpdateNote  : 2011/12/15 yangmj</br>
    /// <br>            : Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�</br>
    /// </remarks>
    public class PMUOE09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region ��Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel UOESupplierCd_Label;
        private TEdit UOESupplierName_tEdit;
        private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel TelNo_Label;
        private Infragistics.Win.Misc.UltraLabel UOETerminalCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOEHostCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEConnectPassword_Label;
        private Infragistics.Win.Misc.UltraLabel UOEConnectUserId_Label;
        private Infragistics.Win.Misc.UltraLabel UOEIDNum_Label;
        private Infragistics.Win.Misc.UltraLabel CommAssemblyId_Label;
        private TEdit GoodsMakerNm_tEdit;
        private TEdit TelNo_tEdit;
        private TNedit UOESupplierCd_tNedit;
        private TNedit tNedit_GoodsMakerCdAllowZero;
        private TEdit UOETerminalCd_tEdit;
        private TEdit UOEHostCode_tEdit;
        private TEdit UOEConnectPassword_tEdit;
        private TEdit UOEConnectUserId_tEdit;
        private TEdit UOEIDNum_tEdit;
        private TEdit CommAssemblyId_tEdit;
        private Infragistics.Win.Misc.UltraLabel ConnectVersionDiv_Label;
        private TComboEditor ConnectVersionDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel UOEShipSectCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOESalSectCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOEReservSectCd_Label;
        private Infragistics.Win.Misc.UltraLabel ReceiveCondition_Label;
        private Infragistics.Win.Misc.UltraLabel SubstPartsNoDiv_Label;
        private Infragistics.Win.Misc.UltraLabel PartsNoPrtCd_Label;
        private Infragistics.Win.Misc.UltraLabel ListPriceUseDiv_Label;
        private Infragistics.Win.Misc.UltraLabel StockSlipDtRecvDiv_Label;
        private Infragistics.Win.Misc.UltraLabel CheckCodeDiv_Label;
        private TEdit UOEShipSectCd_tEdit;
        private TEdit UOEShipSectNm_tEdit;
        private TEdit UOESalSectCd_tEdit;
        private TEdit UOESalSectNm_tEdit;
        private TEdit UOEReservSectCd_tEdit;
        private TEdit UOEReservSectNm_tEdit;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel UOEOrderRate_Label;
        private Infragistics.Win.Misc.UltraLabel BoCode_Label;
        private Infragistics.Win.Misc.UltraLabel DeliveredGoodsDiv_Label;
        private Infragistics.Win.Misc.UltraLabel EmployeeCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEResvdSection_Label;
        private Infragistics.Win.Misc.UltraLabel BusinessCode_Label;
        private TComboEditor BusinessCode_tComboEditor;
        private TComboEditor ReceiveCondition_tComboEditor;
        private TComboEditor SubstPartsNoDiv_tComboEditor;
        private TComboEditor PartsNoPrtCd_tComboEditor;
        private TComboEditor ListPriceUseDiv_tComboEditor;
        private TComboEditor StockSlipDtRecvDiv_tComboEditor;
        private TComboEditor CheckCodeDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private TEdit UOEOrderRate_tEdit;
        private Infragistics.Win.Misc.UltraButton uButton_UOESupplierGuide;
        private Infragistics.Win.Misc.UltraButton uButton_UOEShipSectGuide;
        private Infragistics.Win.Misc.UltraButton uButton_UOESalSectGuide;
        private Infragistics.Win.Misc.UltraButton uButton_UOEReservSectGuide;
        private Infragistics.Win.Misc.UltraButton uButton_MakerGuide;
        private Infragistics.Win.Misc.UltraButton uButton_SupplierGuide;
        private TRetKeyControl tRetKeyControl1;
        private IContainer components;
        private TArrowKeyControl tArrowKeyControl1;
        private DataSet Bind_DataSet;
        private Timer Initial_Timer;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel SupplierCd_Label;
        private TNedit tNedit_SupplierCd;
        private TEdit SupplierNm_tEdit;
        private TComboEditor UOEResvdSection_tComboEditor;
        private Infragistics.Win.Misc.UltraButton uButton_EmployeeGuide;
        private TComboEditor BoCode_tComboEditor;
        private TComboEditor DeliveredGoodsDiv_tComboEditor;
        private TEdit tEdit_EmployeeCode;
        private TEdit tEdit_EmployeeName;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Maker_ultraTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Mazda_AnswerAutoDiv_ultraLabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraLabel HondaSectionCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEItemCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOETestMode_Label;
        private Infragistics.Win.Misc.UltraLabel instrumentNo_Label;
        private TEdit instrumentNo_tEdit;
        private TEdit HondaSectionCode_tEdit;
        private TEdit UOEItemCd_tEdit;
        private TEdit UOETestMode_tEdit;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
        private Infragistics.Win.Misc.UltraLabel MazdaSectionCode_Label;
        private TEdit MazdaSectionCode_tEdit;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
        private Infragistics.Win.Misc.UltraLabel EmergencyDiv_Label;
        private TComboEditor EmergencyDiv_tComboEditor;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private TEdit UOEForcedTermUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEForcedTermUrl_Label;
        private TEdit UOEStockCheckUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEStockCheckUrl_Label;
        private TEdit UOEOrderUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEOrderUrl_Label;
        private TEdit UOELoginUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOELoginUrl_Label;
        private TEdit AnswerSaveFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel AnswerSaveFolder_Label;
        private Infragistics.Win.Misc.UltraLabel InqOrdDivCd_Label;
        private TComboEditor InqOrdDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel LoginTimeoutVal_Label1;
        private TNedit LoginTimeoutVal_tNedit;
        private Infragistics.Win.Misc.UltraButton uButton_AnswerSaveFolder;
        private Infragistics.Win.Misc.UltraLabel LoginTimeoutVal_Label2;
        private TEdit EPartsPassWord_tEdit;
        private Infragistics.Win.Misc.UltraLabel EPartsPassWord_Label;
        private TEdit EPartsUserId_tEdit;
        private Infragistics.Win.Misc.UltraLabel EPartsUserId_Label;
        private TEdit UOEePartsItemCd_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEePartsItemCd_Label;
        private TNedit EnableOdrMakerCd6_tNedit;
        private TNedit EnableOdrMakerCd5_tNedit;
        private TNedit EnableOdrMakerCd4_tNedit;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker6Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker5Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker4Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker3Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker2Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker1Guide;
        private TNedit EnableOdrMakerCd3_tNedit;
        private TNedit EnableOdrMakerCd2_tNedit;
        private TNedit EnableOdrMakerCd1_tNedit;
        private TEdit EnableOdrMakerNm6_tEdit;
        private TEdit EnableOdrMakerNm5_tEdit;
        private TEdit EnableOdrMakerNm4_tEdit;
        private TEdit EnableOdrMakerNm3_tEdit;
        private TEdit EnableOdrMakerNm2_tEdit;
        private TEdit EnableOdrMakerNm1_tEdit;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private Infragistics.Win.Misc.UltraButton uButton_AnswerSaveFolderOfTOYOTA;
        private TEdit AnswerSaveFolderOfTOYOTA_tEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private Infragistics.Win.Misc.UltraButton uButton_NissanAnswerSaveFolder;
        private TEdit NissanAnswerSaveFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel Nissan_ultraLabel;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
		private TEdit MitsubishiAnswerSaveFolder_tEdit;
		private Infragistics.Win.Misc.UltraLabel Mitsubishi_ultraLabel;
		private Infragistics.Win.Misc.UltraButton uButton_MitsubishiAnswerSaveFolder;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl7;
        private TEdit MeiJiUoeEigyousyoCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeEigyousyoCode_Label;
        private TEdit MeiJiUoeSystemUseType_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeSystemUseType_Label;
        private TEdit MeiJiUoePassword_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoePassword_Label;
        private TEdit MeiJiUoeTerminalID_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeTerminalID_Label;
        private TEdit MeiJiUoeCoCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeCoCode_Label;
        private TEdit MeiJiUoeJigyousyoCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeJigyousyoCode_Label;
        private TEdit MeiJiUoeEigyousyoFlag_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeEigyousyoFlag_Label;
        private TComboEditor AnswerAutoDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AnswerAutoDiv_ultraLabel;
        private TEdit WebPassword_tEdit;
        private Infragistics.Win.Misc.UltraLabel WebPassword_ultraLabel;
        private TEdit WebConnectCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel WebConnectCode_ultraLabel;
        private TEdit WebUserID_tEdit;
        private Infragistics.Win.Misc.UltraLabel WebUserID_ultraLabel;
        private Infragistics.Win.Misc.UltraLabel Nissan_AnswerAutoDiv_ultraLabel;
        private TComboEditor Nissan_AnswerAutoDiv_tComboEditor;
        private TEdit tEdit_MazdaSectionCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_MazdaSectionCode;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_HondaSectionCode;
        private Infragistics.Win.Misc.UltraButton uButton_MazdaAnswerSaveFolder;
        private TEdit MazdaAnswerSaveFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel Mazda_ultraLabel;
        private TEdit tEdit_HondaSectionCode;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl9;
        private TEdit OrderAddress_tEdit;
        private TEdit Domain_tEdit;
        private TComboEditor Connection_tComboEditor;
        private TComboEditor Protocol_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel CarMaker_uLabel;
        private Infragistics.Win.Misc.UltraLabel Connection_uLabel;
        private Infragistics.Win.Misc.UltraLabel TimeOut_uLabel;
        private Infragistics.Win.Misc.UltraLabel PurchaseAddress_uLabel;
        private Infragistics.Win.Misc.UltraLabel RestoreAddress_uLabel;
        private Infragistics.Win.Misc.UltraLabel OrderAddress_uLabel;
        private Infragistics.Win.Misc.UltraLabel Domain_uLabel;
        private Infragistics.Win.Misc.UltraLabel Protocol_uLabel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TEdit TimeOut_tEdit;
        private TEdit PurchaseAddress_tEdit;
        private TEdit RestoreAddress_tEdit;
        private Infragistics.Win.Misc.UltraButton CarMaker_uButton;
        private TEdit BLMngUserCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel BLMngUserCode_uLabel;
        private TComboEditor MakerCd6_tComboEditor;
        private TComboEditor MakerCd5_tComboEditor;
        private TComboEditor MakerCd4_tComboEditor;
        private TComboEditor MakerCd3_tComboEditor;
        private TComboEditor MakerCd2_tComboEditor;
        private TComboEditor MakerCd1_tComboEditor;

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;

        #endregion

        #region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance285 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance286 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance287 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance288 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance289 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance290 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance276 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance277 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance278 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance279 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance280 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance281 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance282 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance283 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance284 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance204 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance226 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance233 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance230 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance225 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance232 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance229 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance224 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance231 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance228 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance236 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance237 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance238 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance227 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance239 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance240 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance241 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance242 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance176 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance235 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance243 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance244 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance245 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance246 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance212 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance213 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance214 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance215 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance216 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance177 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance222 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance223 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance258 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance269 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance270 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance271 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance257 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance268 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance256 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance267 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance249 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance266 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance234 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance265 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance263 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance264 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance261 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance262 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance260 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance259 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance255 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance272 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance254 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance253 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance252 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance251 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance250 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance196 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance247 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance248 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance273 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance274 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance275 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance194 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance195 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab8 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab9 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09020UA));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.MakerCd6_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd5_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd4_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd3_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd2_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd1_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EnableOdrMakerCd6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_EnableOdrMaker6Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker5Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker4Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker3Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker2Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker1Guide = new Infragistics.Win.Misc.UltraButton();
            this.EnableOdrMakerCd3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerNm6_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm5_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.HondaSectionCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEItemCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOETestMode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.instrumentNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.instrumentNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.HondaSectionCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEItemCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOETestMode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.MazdaSectionCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MazdaSectionCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.EmergencyDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EmergencyDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.EPartsPassWord_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EPartsPassWord_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EPartsUserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EPartsUserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEePartsItemCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEePartsItemCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LoginTimeoutVal_Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.LoginTimeoutVal_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.LoginTimeoutVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_AnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.InqOrdDivCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.InqOrdDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UOEForcedTermUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEForcedTermUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEStockCheckUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEStockCheckUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEOrderUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEOrderUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOELoginUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOELoginUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AnswerSaveFolder_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.WebConnectCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WebConnectCode_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.WebUserID_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WebUserID_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.WebPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WebPassword_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AnswerAutoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AnswerAutoDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_AnswerSaveFolderOfTOYOTA = new Infragistics.Win.Misc.UltraButton();
            this.AnswerSaveFolderOfTOYOTA_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tEdit_MazdaSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel_MazdaSectionCode = new Infragistics.Win.Misc.UltraLabel();
            this.Nissan_AnswerAutoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Nissan_AnswerAutoDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_NissanAnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.NissanAnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Nissan_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.uButton_MitsubishiAnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.MitsubishiAnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mitsubishi_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.MeiJiUoeSystemUseType_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeSystemUseType_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoePassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoePassword_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeTerminalID_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeTerminalID_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeCoCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeCoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeJigyousyoCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeJigyousyoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeEigyousyoFlag_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeEigyousyoFlag_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeEigyousyoCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeEigyousyoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tEdit_HondaSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel_HondaSectionCode = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_MazdaAnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.MazdaAnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mazda_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.CarMaker_uButton = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.BLMngUserCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TimeOut_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PurchaseAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RestoreAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OrderAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Domain_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Connection_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Protocol_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CarMaker_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Connection_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BLMngUserCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.TimeOut_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PurchaseAddress_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RestoreAddress_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.OrderAddress_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Domain_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Protocol_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.TelNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOETerminalCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEHostCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEConnectPassword_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEConnectUserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEIDNum_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CommAssemblyId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TelNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOESupplierCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsMakerCdAllowZero = new Broadleaf.Library.Windows.Forms.TNedit();
            this.UOETerminalCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEHostCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEConnectPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEConnectUserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEIDNum_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CommAssemblyId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConnectVersionDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConnectVersionDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UOEShipSectCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESalSectCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEReservSectCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ReceiveCondition_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SubstPartsNoDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsNoPrtCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ListPriceUseDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockSlipDtRecvDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CheckCodeDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEShipSectCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEShipSectNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOESalSectCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOESalSectNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEReservSectCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEReservSectNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UOEOrderRate_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DeliveredGoodsDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EmployeeCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_EmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.UOEResvdSection_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BusinessCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BoCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DeliveredGoodsDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UOEResvdSection_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BusinessCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEOrderRate_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_EmployeeName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ReceiveCondition_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SubstPartsNoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartsNoPrtCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ListPriceUseDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockSlipDtRecvDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CheckCodeDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_UOESupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_UOEShipSectGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_UOESalSectGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_UOEReservSectGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_MakerGuide = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.SupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.SupplierNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Maker_ultraTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.Mazda_AnswerAutoDiv_ultraLabel = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd6_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd5_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd4_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd3_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd2_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd1_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd6_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd5_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd4_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm1_tEdit)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HondaSectionCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEItemCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETestMode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaSectionCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmergencyDiv_tComboEditor)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsPassWord_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsUserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEePartsItemCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTimeoutVal_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InqOrdDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEForcedTermUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEStockCheckUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOELoginUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebConnectCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebUserID_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebPassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerAutoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolderOfTOYOTA_tEdit)).BeginInit();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MazdaSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nissan_AnswerAutoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NissanAnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MitsubishiAnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeSystemUseType_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoePassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeTerminalID_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeCoCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeJigyousyoCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoFlag_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoCode_tEdit)).BeginInit();
            this.ultraTabPageControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HondaSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaAnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLMngUserCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOut_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestoreAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Domain_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Connection_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Protocol_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCdAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETerminalCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEHostCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectPassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectUserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEIDNum_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectVersionDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEResvdSection_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderRate_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveCondition_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubstPartsNoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceUseDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipDtRecvDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCodeDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_ultraTabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mazda_AnswerAutoDiv_ultraLabel)).BeginInit();
            this.Mazda_AnswerAutoDiv_ultraLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.MakerCd6_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd5_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd4_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd3_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd2_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd1_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd6_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd5_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd4_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker6Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker5Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker4Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker3Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker2Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker1Guide);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd3_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd2_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd1_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm6_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm5_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm4_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm3_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm2_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm1_tEdit);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 21);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(938, 195);
            // 
            // MakerCd6_tComboEditor
            // 
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance124.ForeColor = System.Drawing.Color.Black;
            appearance124.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd6_tComboEditor.ActiveAppearance = appearance124;
            appearance161.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance161.ForeColor = System.Drawing.Color.Black;
            appearance161.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd6_tComboEditor.Appearance = appearance161;
            this.MakerCd6_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd6_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd6_tComboEditor.ItemAppearance = appearance162;
            this.MakerCd6_tComboEditor.Location = new System.Drawing.Point(283, 163);
            this.MakerCd6_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd6_tComboEditor.Name = "MakerCd6_tComboEditor";
            this.MakerCd6_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd6_tComboEditor.TabIndex = 46;
            this.MakerCd6_tComboEditor.Visible = false;
            // 
            // MakerCd5_tComboEditor
            // 
            appearance285.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance285.ForeColor = System.Drawing.Color.Black;
            appearance285.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd5_tComboEditor.ActiveAppearance = appearance285;
            appearance286.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance286.ForeColor = System.Drawing.Color.Black;
            appearance286.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd5_tComboEditor.Appearance = appearance286;
            this.MakerCd5_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd5_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance287.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd5_tComboEditor.ItemAppearance = appearance287;
            this.MakerCd5_tComboEditor.Location = new System.Drawing.Point(283, 133);
            this.MakerCd5_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd5_tComboEditor.Name = "MakerCd5_tComboEditor";
            this.MakerCd5_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd5_tComboEditor.TabIndex = 43;
            this.MakerCd5_tComboEditor.Visible = false;
            // 
            // MakerCd4_tComboEditor
            // 
            appearance288.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance288.ForeColor = System.Drawing.Color.Black;
            appearance288.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd4_tComboEditor.ActiveAppearance = appearance288;
            appearance289.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance289.ForeColor = System.Drawing.Color.Black;
            appearance289.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd4_tComboEditor.Appearance = appearance289;
            this.MakerCd4_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd4_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance290.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd4_tComboEditor.ItemAppearance = appearance290;
            this.MakerCd4_tComboEditor.Location = new System.Drawing.Point(283, 103);
            this.MakerCd4_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd4_tComboEditor.Name = "MakerCd4_tComboEditor";
            this.MakerCd4_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd4_tComboEditor.TabIndex = 40;
            this.MakerCd4_tComboEditor.Visible = false;
            // 
            // MakerCd3_tComboEditor
            // 
            appearance276.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance276.ForeColor = System.Drawing.Color.Black;
            appearance276.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd3_tComboEditor.ActiveAppearance = appearance276;
            appearance277.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance277.ForeColor = System.Drawing.Color.Black;
            appearance277.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd3_tComboEditor.Appearance = appearance277;
            this.MakerCd3_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd3_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance278.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd3_tComboEditor.ItemAppearance = appearance278;
            this.MakerCd3_tComboEditor.Location = new System.Drawing.Point(283, 73);
            this.MakerCd3_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd3_tComboEditor.Name = "MakerCd3_tComboEditor";
            this.MakerCd3_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd3_tComboEditor.TabIndex = 37;
            this.MakerCd3_tComboEditor.Visible = false;
            // 
            // MakerCd2_tComboEditor
            // 
            appearance279.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance279.ForeColor = System.Drawing.Color.Black;
            appearance279.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd2_tComboEditor.ActiveAppearance = appearance279;
            appearance280.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance280.ForeColor = System.Drawing.Color.Black;
            appearance280.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd2_tComboEditor.Appearance = appearance280;
            this.MakerCd2_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd2_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance281.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd2_tComboEditor.ItemAppearance = appearance281;
            this.MakerCd2_tComboEditor.Location = new System.Drawing.Point(283, 43);
            this.MakerCd2_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd2_tComboEditor.Name = "MakerCd2_tComboEditor";
            this.MakerCd2_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd2_tComboEditor.TabIndex = 34;
            this.MakerCd2_tComboEditor.Visible = false;
            // 
            // MakerCd1_tComboEditor
            // 
            appearance282.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance282.ForeColor = System.Drawing.Color.Black;
            appearance282.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd1_tComboEditor.ActiveAppearance = appearance282;
            appearance283.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance283.ForeColor = System.Drawing.Color.Black;
            appearance283.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd1_tComboEditor.Appearance = appearance283;
            this.MakerCd1_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd1_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance284.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd1_tComboEditor.ItemAppearance = appearance284;
            this.MakerCd1_tComboEditor.Location = new System.Drawing.Point(283, 13);
            this.MakerCd1_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd1_tComboEditor.Name = "MakerCd1_tComboEditor";
            this.MakerCd1_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd1_tComboEditor.TabIndex = 31;
            this.MakerCd1_tComboEditor.Visible = false;
            // 
            // EnableOdrMakerCd6_tNedit
            // 
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance72.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd6_tNedit.ActiveAppearance = appearance72;
            appearance92.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            appearance92.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd6_tNedit.Appearance = appearance92;
            this.EnableOdrMakerCd6_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd6_tNedit.DataText = "";
            this.EnableOdrMakerCd6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd6_tNedit.Location = new System.Drawing.Point(26, 163);
            this.EnableOdrMakerCd6_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd6_tNedit.Name = "EnableOdrMakerCd6_tNedit";
            this.EnableOdrMakerCd6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd6_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd6_tNedit.TabIndex = 44;
            // 
            // EnableOdrMakerCd5_tNedit
            // 
            appearance130.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance130.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd5_tNedit.ActiveAppearance = appearance130;
            appearance91.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance91.ForeColorDisabled = System.Drawing.Color.Black;
            appearance91.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd5_tNedit.Appearance = appearance91;
            this.EnableOdrMakerCd5_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd5_tNedit.DataText = "";
            this.EnableOdrMakerCd5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd5_tNedit.Location = new System.Drawing.Point(26, 133);
            this.EnableOdrMakerCd5_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd5_tNedit.Name = "EnableOdrMakerCd5_tNedit";
            this.EnableOdrMakerCd5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd5_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd5_tNedit.TabIndex = 41;
            // 
            // EnableOdrMakerCd4_tNedit
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance131.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd4_tNedit.ActiveAppearance = appearance131;
            appearance90.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance90.ForeColorDisabled = System.Drawing.Color.Black;
            appearance90.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd4_tNedit.Appearance = appearance90;
            this.EnableOdrMakerCd4_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd4_tNedit.DataText = "";
            this.EnableOdrMakerCd4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd4_tNedit.Location = new System.Drawing.Point(26, 103);
            this.EnableOdrMakerCd4_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd4_tNedit.Name = "EnableOdrMakerCd4_tNedit";
            this.EnableOdrMakerCd4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd4_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd4_tNedit.TabIndex = 38;
            // 
            // uButton_EnableOdrMaker6Guide
            // 
            appearance142.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance142.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker6Guide.Appearance = appearance142;
            this.uButton_EnableOdrMaker6Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker6Guide.Location = new System.Drawing.Point(228, 163);
            this.uButton_EnableOdrMaker6Guide.Name = "uButton_EnableOdrMaker6Guide";
            this.uButton_EnableOdrMaker6Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker6Guide.TabIndex = 45;
            this.uButton_EnableOdrMaker6Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker6Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker6Guide_Click);
            // 
            // uButton_EnableOdrMaker5Guide
            // 
            appearance144.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance144.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker5Guide.Appearance = appearance144;
            this.uButton_EnableOdrMaker5Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker5Guide.Location = new System.Drawing.Point(228, 133);
            this.uButton_EnableOdrMaker5Guide.Name = "uButton_EnableOdrMaker5Guide";
            this.uButton_EnableOdrMaker5Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker5Guide.TabIndex = 42;
            this.uButton_EnableOdrMaker5Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker5Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker5Guide_Click);
            // 
            // uButton_EnableOdrMaker4Guide
            // 
            appearance145.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance145.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker4Guide.Appearance = appearance145;
            this.uButton_EnableOdrMaker4Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker4Guide.Location = new System.Drawing.Point(228, 103);
            this.uButton_EnableOdrMaker4Guide.Name = "uButton_EnableOdrMaker4Guide";
            this.uButton_EnableOdrMaker4Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker4Guide.TabIndex = 39;
            this.uButton_EnableOdrMaker4Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker4Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker4Guide_Click);
            // 
            // uButton_EnableOdrMaker3Guide
            // 
            appearance146.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance146.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker3Guide.Appearance = appearance146;
            this.uButton_EnableOdrMaker3Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker3Guide.Location = new System.Drawing.Point(228, 73);
            this.uButton_EnableOdrMaker3Guide.Name = "uButton_EnableOdrMaker3Guide";
            this.uButton_EnableOdrMaker3Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker3Guide.TabIndex = 36;
            this.uButton_EnableOdrMaker3Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker3Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker3Guide_Click);
            // 
            // uButton_EnableOdrMaker2Guide
            // 
            appearance147.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance147.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker2Guide.Appearance = appearance147;
            this.uButton_EnableOdrMaker2Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker2Guide.Location = new System.Drawing.Point(228, 43);
            this.uButton_EnableOdrMaker2Guide.Name = "uButton_EnableOdrMaker2Guide";
            this.uButton_EnableOdrMaker2Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker2Guide.TabIndex = 33;
            this.uButton_EnableOdrMaker2Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker2Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker2Guide_Click);
            // 
            // uButton_EnableOdrMaker1Guide
            // 
            appearance200.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance200.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker1Guide.Appearance = appearance200;
            this.uButton_EnableOdrMaker1Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker1Guide.Location = new System.Drawing.Point(228, 13);
            this.uButton_EnableOdrMaker1Guide.Name = "uButton_EnableOdrMaker1Guide";
            this.uButton_EnableOdrMaker1Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker1Guide.TabIndex = 30;
            this.uButton_EnableOdrMaker1Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker1Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker1Guide_Click);
            // 
            // EnableOdrMakerCd3_tNedit
            // 
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance132.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd3_tNedit.ActiveAppearance = appearance132;
            appearance89.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance89.ForeColorDisabled = System.Drawing.Color.Black;
            appearance89.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd3_tNedit.Appearance = appearance89;
            this.EnableOdrMakerCd3_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd3_tNedit.DataText = "";
            this.EnableOdrMakerCd3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd3_tNedit.Location = new System.Drawing.Point(26, 73);
            this.EnableOdrMakerCd3_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd3_tNedit.Name = "EnableOdrMakerCd3_tNedit";
            this.EnableOdrMakerCd3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd3_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd3_tNedit.TabIndex = 35;
            // 
            // EnableOdrMakerCd2_tNedit
            // 
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance133.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd2_tNedit.ActiveAppearance = appearance133;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            appearance88.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd2_tNedit.Appearance = appearance88;
            this.EnableOdrMakerCd2_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd2_tNedit.DataText = "";
            this.EnableOdrMakerCd2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd2_tNedit.Location = new System.Drawing.Point(26, 43);
            this.EnableOdrMakerCd2_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd2_tNedit.Name = "EnableOdrMakerCd2_tNedit";
            this.EnableOdrMakerCd2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd2_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd2_tNedit.TabIndex = 32;
            // 
            // EnableOdrMakerCd1_tNedit
            // 
            appearance181.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance181.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd1_tNedit.ActiveAppearance = appearance181;
            appearance182.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance182.ForeColorDisabled = System.Drawing.Color.Black;
            appearance182.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd1_tNedit.Appearance = appearance182;
            this.EnableOdrMakerCd1_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd1_tNedit.DataText = "";
            this.EnableOdrMakerCd1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd1_tNedit.Location = new System.Drawing.Point(26, 13);
            this.EnableOdrMakerCd1_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd1_tNedit.Name = "EnableOdrMakerCd1_tNedit";
            this.EnableOdrMakerCd1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd1_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd1_tNedit.TabIndex = 29;
            // 
            // EnableOdrMakerNm6_tEdit
            // 
            this.EnableOdrMakerNm6_tEdit.ActiveAppearance = appearance35;
            appearance140.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance140.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm6_tEdit.Appearance = appearance140;
            this.EnableOdrMakerNm6_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm6_tEdit.DataText = "";
            this.EnableOdrMakerNm6_tEdit.Enabled = false;
            this.EnableOdrMakerNm6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm6_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm6_tEdit.Location = new System.Drawing.Point(75, 163);
            this.EnableOdrMakerNm6_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm6_tEdit.Name = "EnableOdrMakerNm6_tEdit";
            this.EnableOdrMakerNm6_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm6_tEdit.TabIndex = 48;
            this.EnableOdrMakerNm6_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm5_tEdit
            // 
            this.EnableOdrMakerNm5_tEdit.ActiveAppearance = appearance109;
            appearance139.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance139.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm5_tEdit.Appearance = appearance139;
            this.EnableOdrMakerNm5_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm5_tEdit.DataText = "";
            this.EnableOdrMakerNm5_tEdit.Enabled = false;
            this.EnableOdrMakerNm5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm5_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm5_tEdit.Location = new System.Drawing.Point(75, 133);
            this.EnableOdrMakerNm5_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm5_tEdit.Name = "EnableOdrMakerNm5_tEdit";
            this.EnableOdrMakerNm5_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm5_tEdit.TabIndex = 49;
            this.EnableOdrMakerNm5_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm4_tEdit
            // 
            this.EnableOdrMakerNm4_tEdit.ActiveAppearance = appearance106;
            appearance138.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance138.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm4_tEdit.Appearance = appearance138;
            this.EnableOdrMakerNm4_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm4_tEdit.DataText = "";
            this.EnableOdrMakerNm4_tEdit.Enabled = false;
            this.EnableOdrMakerNm4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm4_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm4_tEdit.Location = new System.Drawing.Point(75, 103);
            this.EnableOdrMakerNm4_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm4_tEdit.Name = "EnableOdrMakerNm4_tEdit";
            this.EnableOdrMakerNm4_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm4_tEdit.TabIndex = 50;
            this.EnableOdrMakerNm4_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm3_tEdit
            // 
            this.EnableOdrMakerNm3_tEdit.ActiveAppearance = appearance108;
            appearance137.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance137.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm3_tEdit.Appearance = appearance137;
            this.EnableOdrMakerNm3_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm3_tEdit.DataText = "";
            this.EnableOdrMakerNm3_tEdit.Enabled = false;
            this.EnableOdrMakerNm3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm3_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm3_tEdit.Location = new System.Drawing.Point(75, 73);
            this.EnableOdrMakerNm3_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm3_tEdit.Name = "EnableOdrMakerNm3_tEdit";
            this.EnableOdrMakerNm3_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm3_tEdit.TabIndex = 45;
            this.EnableOdrMakerNm3_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm2_tEdit
            // 
            this.EnableOdrMakerNm2_tEdit.ActiveAppearance = appearance107;
            appearance136.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm2_tEdit.Appearance = appearance136;
            this.EnableOdrMakerNm2_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm2_tEdit.DataText = "";
            this.EnableOdrMakerNm2_tEdit.Enabled = false;
            this.EnableOdrMakerNm2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm2_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm2_tEdit.Location = new System.Drawing.Point(75, 43);
            this.EnableOdrMakerNm2_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm2_tEdit.Name = "EnableOdrMakerNm2_tEdit";
            this.EnableOdrMakerNm2_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm2_tEdit.TabIndex = 46;
            this.EnableOdrMakerNm2_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm1_tEdit
            // 
            this.EnableOdrMakerNm1_tEdit.ActiveAppearance = appearance198;
            appearance199.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance199.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm1_tEdit.Appearance = appearance199;
            this.EnableOdrMakerNm1_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm1_tEdit.DataText = "";
            this.EnableOdrMakerNm1_tEdit.Enabled = false;
            this.EnableOdrMakerNm1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm1_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm1_tEdit.Location = new System.Drawing.Point(75, 13);
            this.EnableOdrMakerNm1_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm1_tEdit.Name = "EnableOdrMakerNm1_tEdit";
            this.EnableOdrMakerNm1_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm1_tEdit.TabIndex = 47;
            this.EnableOdrMakerNm1_tEdit.TabStop = false;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox2);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox4);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox5);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(938, 195);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.HondaSectionCode_Label);
            this.ultraGroupBox2.Controls.Add(this.UOEItemCd_Label);
            this.ultraGroupBox2.Controls.Add(this.UOETestMode_Label);
            this.ultraGroupBox2.Controls.Add(this.instrumentNo_Label);
            this.ultraGroupBox2.Controls.Add(this.instrumentNo_tEdit);
            this.ultraGroupBox2.Controls.Add(this.HondaSectionCode_tEdit);
            this.ultraGroupBox2.Controls.Add(this.UOEItemCd_tEdit);
            this.ultraGroupBox2.Controls.Add(this.UOETestMode_tEdit);
            this.ultraGroupBox2.Location = new System.Drawing.Point(614, 3);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(300, 157);
            this.ultraGroupBox2.TabIndex = 43;
            this.ultraGroupBox2.Text = "�z���_����";
            // 
            // HondaSectionCode_Label
            // 
            appearance93.TextVAlignAsString = "Middle";
            this.HondaSectionCode_Label.Appearance = appearance93;
            this.HondaSectionCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.HondaSectionCode_Label.Location = new System.Drawing.Point(6, 120);
            this.HondaSectionCode_Label.Name = "HondaSectionCode_Label";
            this.HondaSectionCode_Label.Size = new System.Drawing.Size(105, 23);
            this.HondaSectionCode_Label.TabIndex = 28;
            this.HondaSectionCode_Label.Text = "�S�����_";
            // 
            // UOEItemCd_Label
            // 
            appearance94.TextVAlignAsString = "Middle";
            this.UOEItemCd_Label.Appearance = appearance94;
            this.UOEItemCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEItemCd_Label.Location = new System.Drawing.Point(6, 90);
            this.UOEItemCd_Label.Name = "UOEItemCd_Label";
            this.UOEItemCd_Label.Size = new System.Drawing.Size(105, 23);
            this.UOEItemCd_Label.TabIndex = 28;
            this.UOEItemCd_Label.Text = "�A�C�e��";
            // 
            // UOETestMode_Label
            // 
            appearance95.TextVAlignAsString = "Middle";
            this.UOETestMode_Label.Appearance = appearance95;
            this.UOETestMode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOETestMode_Label.Location = new System.Drawing.Point(6, 60);
            this.UOETestMode_Label.Name = "UOETestMode_Label";
            this.UOETestMode_Label.Size = new System.Drawing.Size(105, 23);
            this.UOETestMode_Label.TabIndex = 28;
            this.UOETestMode_Label.Text = "�e�X�g���[�h";
            // 
            // instrumentNo_Label
            // 
            appearance96.TextVAlignAsString = "Middle";
            this.instrumentNo_Label.Appearance = appearance96;
            this.instrumentNo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.instrumentNo_Label.Location = new System.Drawing.Point(6, 30);
            this.instrumentNo_Label.Name = "instrumentNo_Label";
            this.instrumentNo_Label.Size = new System.Drawing.Size(105, 23);
            this.instrumentNo_Label.TabIndex = 28;
            this.instrumentNo_Label.Text = "���@";
            // 
            // instrumentNo_tEdit
            // 
            appearance97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.instrumentNo_tEdit.ActiveAppearance = appearance97;
            appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance81.ForeColorDisabled = System.Drawing.Color.Black;
            this.instrumentNo_tEdit.Appearance = appearance81;
            this.instrumentNo_tEdit.AutoSelect = true;
            this.instrumentNo_tEdit.DataText = "";
            this.instrumentNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.instrumentNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.instrumentNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.instrumentNo_tEdit.Location = new System.Drawing.Point(117, 30);
            this.instrumentNo_tEdit.MaxLength = 1;
            this.instrumentNo_tEdit.Name = "instrumentNo_tEdit";
            this.instrumentNo_tEdit.Size = new System.Drawing.Size(28, 24);
            this.instrumentNo_tEdit.TabIndex = 1;
            // 
            // HondaSectionCode_tEdit
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.HondaSectionCode_tEdit.ActiveAppearance = appearance98;
            appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            this.HondaSectionCode_tEdit.Appearance = appearance84;
            this.HondaSectionCode_tEdit.AutoSelect = true;
            this.HondaSectionCode_tEdit.DataText = "";
            this.HondaSectionCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.HondaSectionCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.HondaSectionCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HondaSectionCode_tEdit.Location = new System.Drawing.Point(117, 120);
            this.HondaSectionCode_tEdit.MaxLength = 5;
            this.HondaSectionCode_tEdit.Name = "HondaSectionCode_tEdit";
            this.HondaSectionCode_tEdit.Size = new System.Drawing.Size(59, 24);
            this.HondaSectionCode_tEdit.TabIndex = 4;
            // 
            // UOEItemCd_tEdit
            // 
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEItemCd_tEdit.ActiveAppearance = appearance99;
            appearance83.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance83.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEItemCd_tEdit.Appearance = appearance83;
            this.UOEItemCd_tEdit.AutoSelect = true;
            this.UOEItemCd_tEdit.DataText = "";
            this.UOEItemCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEItemCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.UOEItemCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEItemCd_tEdit.Location = new System.Drawing.Point(117, 90);
            this.UOEItemCd_tEdit.MaxLength = 5;
            this.UOEItemCd_tEdit.Name = "UOEItemCd_tEdit";
            this.UOEItemCd_tEdit.Size = new System.Drawing.Size(59, 24);
            this.UOEItemCd_tEdit.TabIndex = 3;
            // 
            // UOETestMode_tEdit
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOETestMode_tEdit.ActiveAppearance = appearance100;
            appearance82.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOETestMode_tEdit.Appearance = appearance82;
            this.UOETestMode_tEdit.AutoSelect = true;
            this.UOETestMode_tEdit.DataText = "";
            this.UOETestMode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOETestMode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOETestMode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOETestMode_tEdit.Location = new System.Drawing.Point(117, 60);
            this.UOETestMode_tEdit.MaxLength = 1;
            this.UOETestMode_tEdit.Name = "UOETestMode_tEdit";
            this.UOETestMode_tEdit.Size = new System.Drawing.Size(28, 24);
            this.UOETestMode_tEdit.TabIndex = 2;
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.MazdaSectionCode_Label);
            this.ultraGroupBox4.Controls.Add(this.MazdaSectionCode_tEdit);
            this.ultraGroupBox4.Location = new System.Drawing.Point(308, 3);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(300, 66);
            this.ultraGroupBox4.TabIndex = 42;
            this.ultraGroupBox4.Text = "�V�}�c�_����";
            // 
            // MazdaSectionCode_Label
            // 
            appearance103.TextVAlignAsString = "Middle";
            this.MazdaSectionCode_Label.Appearance = appearance103;
            this.MazdaSectionCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MazdaSectionCode_Label.Location = new System.Drawing.Point(6, 30);
            this.MazdaSectionCode_Label.Name = "MazdaSectionCode_Label";
            this.MazdaSectionCode_Label.Size = new System.Drawing.Size(84, 23);
            this.MazdaSectionCode_Label.TabIndex = 28;
            this.MazdaSectionCode_Label.Text = "�����_";
            // 
            // MazdaSectionCode_tEdit
            // 
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MazdaSectionCode_tEdit.ActiveAppearance = appearance104;
            appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            this.MazdaSectionCode_tEdit.Appearance = appearance86;
            this.MazdaSectionCode_tEdit.AutoSelect = true;
            this.MazdaSectionCode_tEdit.DataText = "";
            this.MazdaSectionCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MazdaSectionCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.MazdaSectionCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MazdaSectionCode_tEdit.Location = new System.Drawing.Point(96, 30);
            this.MazdaSectionCode_tEdit.MaxLength = 3;
            this.MazdaSectionCode_tEdit.Name = "MazdaSectionCode_tEdit";
            this.MazdaSectionCode_tEdit.Size = new System.Drawing.Size(59, 24);
            this.MazdaSectionCode_tEdit.TabIndex = 1;
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.EmergencyDiv_Label);
            this.ultraGroupBox5.Controls.Add(this.EmergencyDiv_tComboEditor);
            this.ultraGroupBox5.Location = new System.Drawing.Point(3, 3);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(299, 66);
            this.ultraGroupBox5.TabIndex = 41;
            this.ultraGroupBox5.Text = "�O�H����";
            // 
            // EmergencyDiv_Label
            // 
            appearance55.TextVAlignAsString = "Middle";
            this.EmergencyDiv_Label.Appearance = appearance55;
            this.EmergencyDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EmergencyDiv_Label.Location = new System.Drawing.Point(6, 30);
            this.EmergencyDiv_Label.Name = "EmergencyDiv_Label";
            this.EmergencyDiv_Label.Size = new System.Drawing.Size(84, 23);
            this.EmergencyDiv_Label.TabIndex = 28;
            this.EmergencyDiv_Label.Text = "�ً}�敪";
            // 
            // EmergencyDiv_tComboEditor
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            this.EmergencyDiv_tComboEditor.ActiveAppearance = appearance47;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            this.EmergencyDiv_tComboEditor.Appearance = appearance48;
            this.EmergencyDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EmergencyDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EmergencyDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EmergencyDiv_tComboEditor.ItemAppearance = appearance49;
            this.EmergencyDiv_tComboEditor.Location = new System.Drawing.Point(96, 30);
            this.EmergencyDiv_tComboEditor.MaxDropDownItems = 18;
            this.EmergencyDiv_tComboEditor.Name = "EmergencyDiv_tComboEditor";
            this.EmergencyDiv_tComboEditor.Size = new System.Drawing.Size(141, 24);
            this.EmergencyDiv_tComboEditor.TabIndex = 1;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.EPartsPassWord_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.EPartsPassWord_Label);
            this.ultraTabPageControl3.Controls.Add(this.EPartsUserId_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.EPartsUserId_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOEePartsItemCd_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEePartsItemCd_Label);
            this.ultraTabPageControl3.Controls.Add(this.LoginTimeoutVal_Label2);
            this.ultraTabPageControl3.Controls.Add(this.LoginTimeoutVal_Label1);
            this.ultraTabPageControl3.Controls.Add(this.LoginTimeoutVal_tNedit);
            this.ultraTabPageControl3.Controls.Add(this.uButton_AnswerSaveFolder);
            this.ultraTabPageControl3.Controls.Add(this.InqOrdDivCd_Label);
            this.ultraTabPageControl3.Controls.Add(this.InqOrdDivCd_tComboEditor);
            this.ultraTabPageControl3.Controls.Add(this.UOEForcedTermUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEForcedTermUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOEStockCheckUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEStockCheckUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOEOrderUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEOrderUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOELoginUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOELoginUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.AnswerSaveFolder_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.AnswerSaveFolder_Label);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(938, 195);
            // 
            // EPartsPassWord_tEdit
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EPartsPassWord_tEdit.ActiveAppearance = appearance76;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.EPartsPassWord_tEdit.Appearance = appearance78;
            this.EPartsPassWord_tEdit.AutoSelect = true;
            this.EPartsPassWord_tEdit.DataText = "";
            this.EPartsPassWord_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EPartsPassWord_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.EPartsPassWord_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EPartsPassWord_tEdit.Location = new System.Drawing.Point(757, 132);
            this.EPartsPassWord_tEdit.MaxLength = 16;
            this.EPartsPassWord_tEdit.Name = "EPartsPassWord_tEdit";
            this.EPartsPassWord_tEdit.Size = new System.Drawing.Size(136, 24);
            this.EPartsPassWord_tEdit.TabIndex = 54;
            // 
            // EPartsPassWord_Label
            // 
            appearance135.TextVAlignAsString = "Middle";
            this.EPartsPassWord_Label.Appearance = appearance135;
            this.EPartsPassWord_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EPartsPassWord_Label.Location = new System.Drawing.Point(608, 133);
            this.EPartsPassWord_Label.Name = "EPartsPassWord_Label";
            this.EPartsPassWord_Label.Size = new System.Drawing.Size(143, 23);
            this.EPartsPassWord_Label.TabIndex = 50;
            this.EPartsPassWord_Label.Text = "�p�X���[�h";
            // 
            // EPartsUserId_tEdit
            // 
            appearance188.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EPartsUserId_tEdit.ActiveAppearance = appearance188;
            appearance189.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance189.ForeColorDisabled = System.Drawing.Color.Black;
            this.EPartsUserId_tEdit.Appearance = appearance189;
            this.EPartsUserId_tEdit.AutoSelect = true;
            this.EPartsUserId_tEdit.DataText = "";
            this.EPartsUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EPartsUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.EPartsUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EPartsUserId_tEdit.Location = new System.Drawing.Point(757, 102);
            this.EPartsUserId_tEdit.MaxLength = 8;
            this.EPartsUserId_tEdit.Name = "EPartsUserId_tEdit";
            this.EPartsUserId_tEdit.Size = new System.Drawing.Size(82, 24);
            this.EPartsUserId_tEdit.TabIndex = 53;
            // 
            // EPartsUserId_Label
            // 
            appearance190.TextVAlignAsString = "Middle";
            this.EPartsUserId_Label.Appearance = appearance190;
            this.EPartsUserId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EPartsUserId_Label.Location = new System.Drawing.Point(608, 103);
            this.EPartsUserId_Label.Name = "EPartsUserId_Label";
            this.EPartsUserId_Label.Size = new System.Drawing.Size(143, 23);
            this.EPartsUserId_Label.TabIndex = 48;
            this.EPartsUserId_Label.Text = "���[�UID";
            // 
            // UOEePartsItemCd_tEdit
            // 
            appearance185.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEePartsItemCd_tEdit.ActiveAppearance = appearance185;
            appearance186.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance186.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEePartsItemCd_tEdit.Appearance = appearance186;
            this.UOEePartsItemCd_tEdit.AutoSelect = true;
            this.UOEePartsItemCd_tEdit.DataText = "";
            this.UOEePartsItemCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEePartsItemCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.UOEePartsItemCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEePartsItemCd_tEdit.Location = new System.Drawing.Point(757, 72);
            this.UOEePartsItemCd_tEdit.MaxLength = 5;
            this.UOEePartsItemCd_tEdit.Name = "UOEePartsItemCd_tEdit";
            this.UOEePartsItemCd_tEdit.Size = new System.Drawing.Size(59, 24);
            this.UOEePartsItemCd_tEdit.TabIndex = 52;
            // 
            // UOEePartsItemCd_Label
            // 
            appearance187.TextVAlignAsString = "Middle";
            this.UOEePartsItemCd_Label.Appearance = appearance187;
            this.UOEePartsItemCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEePartsItemCd_Label.Location = new System.Drawing.Point(608, 73);
            this.UOEePartsItemCd_Label.Name = "UOEePartsItemCd_Label";
            this.UOEePartsItemCd_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEePartsItemCd_Label.TabIndex = 46;
            this.UOEePartsItemCd_Label.Text = "�A�C�e��";
            // 
            // LoginTimeoutVal_Label2
            // 
            appearance120.TextVAlignAsString = "Middle";
            this.LoginTimeoutVal_Label2.Appearance = appearance120;
            this.LoginTimeoutVal_Label2.BackColorInternal = System.Drawing.Color.Transparent;
            this.LoginTimeoutVal_Label2.Location = new System.Drawing.Point(815, 43);
            this.LoginTimeoutVal_Label2.Name = "LoginTimeoutVal_Label2";
            this.LoginTimeoutVal_Label2.Size = new System.Drawing.Size(25, 23);
            this.LoginTimeoutVal_Label2.TabIndex = 44;
            this.LoginTimeoutVal_Label2.Text = "�b";
            // 
            // LoginTimeoutVal_Label1
            // 
            appearance184.TextVAlignAsString = "Middle";
            this.LoginTimeoutVal_Label1.Appearance = appearance184;
            this.LoginTimeoutVal_Label1.BackColorInternal = System.Drawing.Color.Transparent;
            this.LoginTimeoutVal_Label1.Location = new System.Drawing.Point(607, 43);
            this.LoginTimeoutVal_Label1.Name = "LoginTimeoutVal_Label1";
            this.LoginTimeoutVal_Label1.Size = new System.Drawing.Size(143, 23);
            this.LoginTimeoutVal_Label1.TabIndex = 43;
            this.LoginTimeoutVal_Label1.Text = "���O�C���F�؎���";
            // 
            // LoginTimeoutVal_tNedit
            // 
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance105.TextHAlignAsString = "Right";
            this.LoginTimeoutVal_tNedit.ActiveAppearance = appearance105;
            appearance87.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance87.ForeColorDisabled = System.Drawing.Color.Black;
            appearance87.TextHAlignAsString = "Right";
            this.LoginTimeoutVal_tNedit.Appearance = appearance87;
            this.LoginTimeoutVal_tNedit.AutoSelect = true;
            this.LoginTimeoutVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.LoginTimeoutVal_tNedit.DataText = "";
            this.LoginTimeoutVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.LoginTimeoutVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.LoginTimeoutVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LoginTimeoutVal_tNedit.Location = new System.Drawing.Point(757, 41);
            this.LoginTimeoutVal_tNedit.MaxLength = 3;
            this.LoginTimeoutVal_tNedit.Name = "LoginTimeoutVal_tNedit";
            this.LoginTimeoutVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.LoginTimeoutVal_tNedit.Size = new System.Drawing.Size(51, 24);
            this.LoginTimeoutVal_tNedit.TabIndex = 51;
            // 
            // uButton_AnswerSaveFolder
            // 
            appearance201.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance201.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_AnswerSaveFolder.Appearance = appearance201;
            this.uButton_AnswerSaveFolder.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_AnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_AnswerSaveFolder.Name = "uButton_AnswerSaveFolder";
            this.uButton_AnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_AnswerSaveFolder.TabIndex = 45;
            this.uButton_AnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AnswerSaveFolder.Click += new System.EventHandler(this.uButton_AnswerSaveFolder_Click);
            // 
            // InqOrdDivCd_Label
            // 
            appearance183.TextVAlignAsString = "Middle";
            this.InqOrdDivCd_Label.Appearance = appearance183;
            this.InqOrdDivCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.InqOrdDivCd_Label.Location = new System.Drawing.Point(608, 12);
            this.InqOrdDivCd_Label.Name = "InqOrdDivCd_Label";
            this.InqOrdDivCd_Label.Size = new System.Drawing.Size(143, 23);
            this.InqOrdDivCd_Label.TabIndex = 40;
            this.InqOrdDivCd_Label.Text = "�ڑ����";
            // 
            // InqOrdDivCd_tComboEditor
            // 
            appearance168.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance168.ForeColor = System.Drawing.Color.Black;
            appearance168.ForeColorDisabled = System.Drawing.Color.Black;
            this.InqOrdDivCd_tComboEditor.ActiveAppearance = appearance168;
            appearance169.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance169.ForeColor = System.Drawing.Color.Black;
            appearance169.ForeColorDisabled = System.Drawing.Color.Black;
            this.InqOrdDivCd_tComboEditor.Appearance = appearance169;
            this.InqOrdDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.InqOrdDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance170.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InqOrdDivCd_tComboEditor.ItemAppearance = appearance170;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "0:��������";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "1:�݌Ɋm�F";
            this.InqOrdDivCd_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.InqOrdDivCd_tComboEditor.Location = new System.Drawing.Point(757, 12);
            this.InqOrdDivCd_tComboEditor.MaxDropDownItems = 18;
            this.InqOrdDivCd_tComboEditor.Name = "InqOrdDivCd_tComboEditor";
            this.InqOrdDivCd_tComboEditor.Size = new System.Drawing.Size(124, 24);
            this.InqOrdDivCd_tComboEditor.TabIndex = 50;
            this.InqOrdDivCd_tComboEditor.Text = "0:��������";
            // 
            // UOEForcedTermUrl_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEForcedTermUrl_tEdit.ActiveAppearance = appearance19;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEForcedTermUrl_tEdit.Appearance = appearance26;
            this.UOEForcedTermUrl_tEdit.AutoSelect = true;
            this.UOEForcedTermUrl_tEdit.DataText = "";
            this.UOEForcedTermUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEForcedTermUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOEForcedTermUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEForcedTermUrl_tEdit.Location = new System.Drawing.Point(163, 131);
            this.UOEForcedTermUrl_tEdit.MaxLength = 255;
            this.UOEForcedTermUrl_tEdit.Name = "UOEForcedTermUrl_tEdit";
            this.UOEForcedTermUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEForcedTermUrl_tEdit.TabIndex = 49;
            // 
            // UOEForcedTermUrl_Label
            // 
            appearance77.TextVAlignAsString = "Middle";
            this.UOEForcedTermUrl_Label.Appearance = appearance77;
            this.UOEForcedTermUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEForcedTermUrl_Label.Location = new System.Drawing.Point(14, 132);
            this.UOEForcedTermUrl_Label.Name = "UOEForcedTermUrl_Label";
            this.UOEForcedTermUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEForcedTermUrl_Label.TabIndex = 38;
            this.UOEForcedTermUrl_Label.Text = "�����I���pURL";
            // 
            // UOEStockCheckUrl_tEdit
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEStockCheckUrl_tEdit.ActiveAppearance = appearance122;
            appearance123.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance123.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEStockCheckUrl_tEdit.Appearance = appearance123;
            this.UOEStockCheckUrl_tEdit.AutoSelect = true;
            this.UOEStockCheckUrl_tEdit.DataText = "";
            this.UOEStockCheckUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEStockCheckUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOEStockCheckUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEStockCheckUrl_tEdit.Location = new System.Drawing.Point(163, 101);
            this.UOEStockCheckUrl_tEdit.MaxLength = 255;
            this.UOEStockCheckUrl_tEdit.Name = "UOEStockCheckUrl_tEdit";
            this.UOEStockCheckUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEStockCheckUrl_tEdit.TabIndex = 48;
            // 
            // UOEStockCheckUrl_Label
            // 
            appearance127.TextVAlignAsString = "Middle";
            this.UOEStockCheckUrl_Label.Appearance = appearance127;
            this.UOEStockCheckUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEStockCheckUrl_Label.Location = new System.Drawing.Point(14, 102);
            this.UOEStockCheckUrl_Label.Name = "UOEStockCheckUrl_Label";
            this.UOEStockCheckUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEStockCheckUrl_Label.TabIndex = 36;
            this.UOEStockCheckUrl_Label.Text = "�݌Ɋm�F�pURL";
            // 
            // UOEOrderUrl_tEdit
            // 
            appearance191.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEOrderUrl_tEdit.ActiveAppearance = appearance191;
            appearance192.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance192.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEOrderUrl_tEdit.Appearance = appearance192;
            this.UOEOrderUrl_tEdit.AutoSelect = true;
            this.UOEOrderUrl_tEdit.DataText = "";
            this.UOEOrderUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEOrderUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOEOrderUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEOrderUrl_tEdit.Location = new System.Drawing.Point(163, 71);
            this.UOEOrderUrl_tEdit.MaxLength = 255;
            this.UOEOrderUrl_tEdit.Name = "UOEOrderUrl_tEdit";
            this.UOEOrderUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEOrderUrl_tEdit.TabIndex = 47;
            // 
            // UOEOrderUrl_Label
            // 
            appearance193.TextVAlignAsString = "Middle";
            this.UOEOrderUrl_Label.Appearance = appearance193;
            this.UOEOrderUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEOrderUrl_Label.Location = new System.Drawing.Point(14, 72);
            this.UOEOrderUrl_Label.Name = "UOEOrderUrl_Label";
            this.UOEOrderUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEOrderUrl_Label.TabIndex = 34;
            this.UOEOrderUrl_Label.Text = "�����pURL";
            // 
            // UOELoginUrl_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOELoginUrl_tEdit.ActiveAppearance = appearance11;
            appearance128.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance128.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOELoginUrl_tEdit.Appearance = appearance128;
            this.UOELoginUrl_tEdit.AutoSelect = true;
            this.UOELoginUrl_tEdit.DataText = "";
            this.UOELoginUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOELoginUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOELoginUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOELoginUrl_tEdit.Location = new System.Drawing.Point(163, 41);
            this.UOELoginUrl_tEdit.MaxLength = 255;
            this.UOELoginUrl_tEdit.Name = "UOELoginUrl_tEdit";
            this.UOELoginUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOELoginUrl_tEdit.TabIndex = 46;
            // 
            // UOELoginUrl_Label
            // 
            appearance134.TextVAlignAsString = "Middle";
            this.UOELoginUrl_Label.Appearance = appearance134;
            this.UOELoginUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOELoginUrl_Label.Location = new System.Drawing.Point(14, 42);
            this.UOELoginUrl_Label.Name = "UOELoginUrl_Label";
            this.UOELoginUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOELoginUrl_Label.TabIndex = 32;
            this.UOELoginUrl_Label.Text = "���O�C���pURL";
            // 
            // AnswerSaveFolder_tEdit
            // 
            appearance202.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AnswerSaveFolder_tEdit.ActiveAppearance = appearance202;
            appearance203.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance203.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerSaveFolder_tEdit.Appearance = appearance203;
            this.AnswerSaveFolder_tEdit.AutoSelect = true;
            this.AnswerSaveFolder_tEdit.DataText = "";
            this.AnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.AnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.AnswerSaveFolder_tEdit.MaxLength = 80;
            this.AnswerSaveFolder_tEdit.Name = "AnswerSaveFolder_tEdit";
            this.AnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.AnswerSaveFolder_tEdit.TabIndex = 44;
            // 
            // AnswerSaveFolder_Label
            // 
            appearance204.TextVAlignAsString = "Middle";
            this.AnswerSaveFolder_Label.Appearance = appearance204;
            this.AnswerSaveFolder_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AnswerSaveFolder_Label.Location = new System.Drawing.Point(14, 12);
            this.AnswerSaveFolder_Label.Name = "AnswerSaveFolder_Label";
            this.AnswerSaveFolder_Label.Size = new System.Drawing.Size(143, 23);
            this.AnswerSaveFolder_Label.TabIndex = 30;
            this.AnswerSaveFolder_Label.Text = "�񓚕ۑ��t�H���_";
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.WebConnectCode_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.WebConnectCode_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.WebUserID_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.WebUserID_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.WebPassword_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.WebPassword_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.AnswerAutoDiv_tComboEditor);
            this.ultraTabPageControl4.Controls.Add(this.AnswerAutoDiv_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.uButton_AnswerSaveFolderOfTOYOTA);
            this.ultraTabPageControl4.Controls.Add(this.AnswerSaveFolderOfTOYOTA_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(938, 195);
            // 
            // WebConnectCode_tEdit
            // 
            appearance226.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WebConnectCode_tEdit.ActiveAppearance = appearance226;
            appearance233.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance233.ForeColorDisabled = System.Drawing.Color.Black;
            this.WebConnectCode_tEdit.Appearance = appearance233;
            this.WebConnectCode_tEdit.AutoSelect = true;
            this.WebConnectCode_tEdit.DataText = "";
            this.WebConnectCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WebConnectCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.WebConnectCode_tEdit.Location = new System.Drawing.Point(163, 131);
            this.WebConnectCode_tEdit.MaxLength = 20;
            this.WebConnectCode_tEdit.Name = "WebConnectCode_tEdit";
            this.WebConnectCode_tEdit.Size = new System.Drawing.Size(182, 24);
            this.WebConnectCode_tEdit.TabIndex = 56;
            // 
            // WebConnectCode_ultraLabel
            // 
            appearance230.TextVAlignAsString = "Middle";
            this.WebConnectCode_ultraLabel.Appearance = appearance230;
            this.WebConnectCode_ultraLabel.Location = new System.Drawing.Point(14, 132);
            this.WebConnectCode_ultraLabel.Name = "WebConnectCode_ultraLabel";
            this.WebConnectCode_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.WebConnectCode_ultraLabel.TabIndex = 55;
            this.WebConnectCode_ultraLabel.Text = "WEB�ڑ���R�[�h";
            // 
            // WebUserID_tEdit
            // 
            appearance225.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WebUserID_tEdit.ActiveAppearance = appearance225;
            appearance232.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance232.ForeColorDisabled = System.Drawing.Color.Black;
            this.WebUserID_tEdit.Appearance = appearance232;
            this.WebUserID_tEdit.AutoSelect = true;
            this.WebUserID_tEdit.DataText = "";
            this.WebUserID_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WebUserID_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.WebUserID_tEdit.Location = new System.Drawing.Point(163, 101);
            this.WebUserID_tEdit.MaxLength = 5;
            this.WebUserID_tEdit.Name = "WebUserID_tEdit";
            this.WebUserID_tEdit.Size = new System.Drawing.Size(59, 24);
            this.WebUserID_tEdit.TabIndex = 54;
            // 
            // WebUserID_ultraLabel
            // 
            appearance229.TextVAlignAsString = "Middle";
            this.WebUserID_ultraLabel.Appearance = appearance229;
            this.WebUserID_ultraLabel.Location = new System.Drawing.Point(14, 102);
            this.WebUserID_ultraLabel.Name = "WebUserID_ultraLabel";
            this.WebUserID_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.WebUserID_ultraLabel.TabIndex = 53;
            this.WebUserID_ultraLabel.Text = "WEB���[�U�[ID";
            // 
            // WebPassword_tEdit
            // 
            appearance224.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WebPassword_tEdit.ActiveAppearance = appearance224;
            appearance231.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance231.ForeColorDisabled = System.Drawing.Color.Black;
            this.WebPassword_tEdit.Appearance = appearance231;
            this.WebPassword_tEdit.AutoSelect = true;
            this.WebPassword_tEdit.DataText = "";
            this.WebPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WebPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.WebPassword_tEdit.Location = new System.Drawing.Point(163, 71);
            this.WebPassword_tEdit.MaxLength = 3;
            this.WebPassword_tEdit.Name = "WebPassword_tEdit";
            this.WebPassword_tEdit.Size = new System.Drawing.Size(43, 24);
            this.WebPassword_tEdit.TabIndex = 52;
            // 
            // WebPassword_ultraLabel
            // 
            appearance228.TextVAlignAsString = "Middle";
            this.WebPassword_ultraLabel.Appearance = appearance228;
            this.WebPassword_ultraLabel.Location = new System.Drawing.Point(14, 72);
            this.WebPassword_ultraLabel.Name = "WebPassword_ultraLabel";
            this.WebPassword_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.WebPassword_ultraLabel.TabIndex = 51;
            this.WebPassword_ultraLabel.Text = "WEB�p�X���[�h";
            // 
            // AnswerAutoDiv_tComboEditor
            // 
            appearance236.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance236.ForeColor = System.Drawing.Color.Black;
            appearance236.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerAutoDiv_tComboEditor.ActiveAppearance = appearance236;
            appearance237.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance237.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance237.ForeColor = System.Drawing.Color.Black;
            appearance237.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerAutoDiv_tComboEditor.Appearance = appearance237;
            this.AnswerAutoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AnswerAutoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance238.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AnswerAutoDiv_tComboEditor.ItemAppearance = appearance238;
            this.AnswerAutoDiv_tComboEditor.Location = new System.Drawing.Point(163, 41);
            this.AnswerAutoDiv_tComboEditor.MaxLength = 1;
            this.AnswerAutoDiv_tComboEditor.Name = "AnswerAutoDiv_tComboEditor";
            this.AnswerAutoDiv_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.AnswerAutoDiv_tComboEditor.TabIndex = 50;
            this.AnswerAutoDiv_tComboEditor.ValueMember = "";
            // 
            // AnswerAutoDiv_ultraLabel
            // 
            appearance227.TextVAlignAsString = "Middle";
            this.AnswerAutoDiv_ultraLabel.Appearance = appearance227;
            this.AnswerAutoDiv_ultraLabel.Location = new System.Drawing.Point(14, 42);
            this.AnswerAutoDiv_ultraLabel.Name = "AnswerAutoDiv_ultraLabel";
            this.AnswerAutoDiv_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.AnswerAutoDiv_ultraLabel.TabIndex = 49;
            this.AnswerAutoDiv_ultraLabel.Text = "�񓚎����捞�敪";
            // 
            // uButton_AnswerSaveFolderOfTOYOTA
            // 
            appearance239.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance239.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_AnswerSaveFolderOfTOYOTA.Appearance = appearance239;
            this.uButton_AnswerSaveFolderOfTOYOTA.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_AnswerSaveFolderOfTOYOTA.Location = new System.Drawing.Point(506, 12);
            this.uButton_AnswerSaveFolderOfTOYOTA.Name = "uButton_AnswerSaveFolderOfTOYOTA";
            this.uButton_AnswerSaveFolderOfTOYOTA.Size = new System.Drawing.Size(24, 24);
            this.uButton_AnswerSaveFolderOfTOYOTA.TabIndex = 48;
            this.uButton_AnswerSaveFolderOfTOYOTA.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AnswerSaveFolderOfTOYOTA.Click += new System.EventHandler(this.uButton_AnswerSaveFolder1_Click);
            // 
            // AnswerSaveFolderOfTOYOTA_tEdit
            // 
            appearance240.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AnswerSaveFolderOfTOYOTA_tEdit.ActiveAppearance = appearance240;
            appearance241.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance241.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerSaveFolderOfTOYOTA_tEdit.Appearance = appearance241;
            this.AnswerSaveFolderOfTOYOTA_tEdit.AutoSelect = true;
            this.AnswerSaveFolderOfTOYOTA_tEdit.DataText = "";
            this.AnswerSaveFolderOfTOYOTA_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AnswerSaveFolderOfTOYOTA_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.AnswerSaveFolderOfTOYOTA_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AnswerSaveFolderOfTOYOTA_tEdit.Location = new System.Drawing.Point(163, 11);
            this.AnswerSaveFolderOfTOYOTA_tEdit.MaxLength = 80;
            this.AnswerSaveFolderOfTOYOTA_tEdit.Name = "AnswerSaveFolderOfTOYOTA_tEdit";
            this.AnswerSaveFolderOfTOYOTA_tEdit.Size = new System.Drawing.Size(330, 24);
            this.AnswerSaveFolderOfTOYOTA_tEdit.TabIndex = 47;
            // 
            // ultraLabel1
            // 
            appearance242.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance242;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(14, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(143, 23);
            this.ultraLabel1.TabIndex = 46;
            this.ultraLabel1.Text = "�񓚕ۑ��t�H���_";
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.tEdit_MazdaSectionCode);
            this.ultraTabPageControl5.Controls.Add(this.ultraLabel_MazdaSectionCode);
            this.ultraTabPageControl5.Controls.Add(this.Nissan_AnswerAutoDiv_tComboEditor);
            this.ultraTabPageControl5.Controls.Add(this.Nissan_AnswerAutoDiv_ultraLabel);
            this.ultraTabPageControl5.Controls.Add(this.uButton_NissanAnswerSaveFolder);
            this.ultraTabPageControl5.Controls.Add(this.NissanAnswerSaveFolder_tEdit);
            this.ultraTabPageControl5.Controls.Add(this.Nissan_ultraLabel);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(938, 195);
            // 
            // tEdit_MazdaSectionCode
            // 
            appearance175.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MazdaSectionCode.ActiveAppearance = appearance175;
            appearance176.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance176.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance176.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_MazdaSectionCode.Appearance = appearance176;
            this.tEdit_MazdaSectionCode.AutoSelect = true;
            this.tEdit_MazdaSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MazdaSectionCode.DataText = "";
            this.tEdit_MazdaSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MazdaSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_MazdaSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MazdaSectionCode.Location = new System.Drawing.Point(163, 71);
            this.tEdit_MazdaSectionCode.MaxLength = 3;
            this.tEdit_MazdaSectionCode.Name = "tEdit_MazdaSectionCode";
            this.tEdit_MazdaSectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_MazdaSectionCode.TabIndex = 53;
            // 
            // ultraLabel_MazdaSectionCode
            // 
            appearance235.TextVAlignAsString = "Middle";
            this.ultraLabel_MazdaSectionCode.Appearance = appearance235;
            this.ultraLabel_MazdaSectionCode.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_MazdaSectionCode.Location = new System.Drawing.Point(14, 71);
            this.ultraLabel_MazdaSectionCode.Name = "ultraLabel_MazdaSectionCode";
            this.ultraLabel_MazdaSectionCode.Size = new System.Drawing.Size(143, 23);
            this.ultraLabel_MazdaSectionCode.TabIndex = 53;
            this.ultraLabel_MazdaSectionCode.Text = "WEB�_�~�[�i��";
            // 
            // Nissan_AnswerAutoDiv_tComboEditor
            // 
            appearance243.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance243.ForeColor = System.Drawing.Color.Black;
            appearance243.ForeColorDisabled = System.Drawing.Color.Black;
            this.Nissan_AnswerAutoDiv_tComboEditor.ActiveAppearance = appearance243;
            appearance244.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance244.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance244.ForeColor = System.Drawing.Color.Black;
            appearance244.ForeColorDisabled = System.Drawing.Color.Black;
            this.Nissan_AnswerAutoDiv_tComboEditor.Appearance = appearance244;
            this.Nissan_AnswerAutoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Nissan_AnswerAutoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance245.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Nissan_AnswerAutoDiv_tComboEditor.ItemAppearance = appearance245;
            this.Nissan_AnswerAutoDiv_tComboEditor.Location = new System.Drawing.Point(163, 41);
            this.Nissan_AnswerAutoDiv_tComboEditor.MaxLength = 1;
            this.Nissan_AnswerAutoDiv_tComboEditor.Name = "Nissan_AnswerAutoDiv_tComboEditor";
            this.Nissan_AnswerAutoDiv_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.Nissan_AnswerAutoDiv_tComboEditor.TabIndex = 52;
            this.Nissan_AnswerAutoDiv_tComboEditor.ValueMember = "";
            // 
            // Nissan_AnswerAutoDiv_ultraLabel
            // 
            appearance246.TextVAlignAsString = "Middle";
            this.Nissan_AnswerAutoDiv_ultraLabel.Appearance = appearance246;
            this.Nissan_AnswerAutoDiv_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Nissan_AnswerAutoDiv_ultraLabel.Location = new System.Drawing.Point(14, 41);
            this.Nissan_AnswerAutoDiv_ultraLabel.Name = "Nissan_AnswerAutoDiv_ultraLabel";
            this.Nissan_AnswerAutoDiv_ultraLabel.Size = new System.Drawing.Size(144, 24);
            this.Nissan_AnswerAutoDiv_ultraLabel.TabIndex = 1;
            this.Nissan_AnswerAutoDiv_ultraLabel.Text = "�񓚎����捞�敪";
            // 
            // uButton_NissanAnswerSaveFolder
            // 
            this.uButton_NissanAnswerSaveFolder.Appearance = appearance239;
            this.uButton_NissanAnswerSaveFolder.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_NissanAnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_NissanAnswerSaveFolder.Name = "uButton_NissanAnswerSaveFolder";
            this.uButton_NissanAnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_NissanAnswerSaveFolder.TabIndex = 51;
            this.uButton_NissanAnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_NissanAnswerSaveFolder.Click += new System.EventHandler(this.uButton_NissanAnswerSaveFolder_Click);
            // 
            // NissanAnswerSaveFolder_tEdit
            // 
            this.NissanAnswerSaveFolder_tEdit.ActiveAppearance = appearance240;
            this.NissanAnswerSaveFolder_tEdit.Appearance = appearance241;
            this.NissanAnswerSaveFolder_tEdit.AutoSelect = true;
            this.NissanAnswerSaveFolder_tEdit.DataText = "";
            this.NissanAnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NissanAnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.NissanAnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NissanAnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.NissanAnswerSaveFolder_tEdit.MaxLength = 80;
            this.NissanAnswerSaveFolder_tEdit.Name = "NissanAnswerSaveFolder_tEdit";
            this.NissanAnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.NissanAnswerSaveFolder_tEdit.TabIndex = 50;
            // 
            // Nissan_ultraLabel
            // 
            this.Nissan_ultraLabel.Appearance = appearance242;
            this.Nissan_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Nissan_ultraLabel.Location = new System.Drawing.Point(14, 12);
            this.Nissan_ultraLabel.Name = "Nissan_ultraLabel";
            this.Nissan_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.Nissan_ultraLabel.TabIndex = 49;
            this.Nissan_ultraLabel.Text = "�񓚕ۑ��t�H���_";
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.uButton_MitsubishiAnswerSaveFolder);
            this.ultraTabPageControl6.Controls.Add(this.MitsubishiAnswerSaveFolder_tEdit);
            this.ultraTabPageControl6.Controls.Add(this.Mitsubishi_ultraLabel);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(938, 195);
            // 
            // uButton_MitsubishiAnswerSaveFolder
            // 
            this.uButton_MitsubishiAnswerSaveFolder.Appearance = appearance239;
            this.uButton_MitsubishiAnswerSaveFolder.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MitsubishiAnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_MitsubishiAnswerSaveFolder.Name = "uButton_MitsubishiAnswerSaveFolder";
            this.uButton_MitsubishiAnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_MitsubishiAnswerSaveFolder.TabIndex = 53;
            this.uButton_MitsubishiAnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MitsubishiAnswerSaveFolder.Click += new System.EventHandler(this.uButton_MitsubishiAnswerSaveFolder_Click);
            // 
            // MitsubishiAnswerSaveFolder_tEdit
            // 
            this.MitsubishiAnswerSaveFolder_tEdit.ActiveAppearance = appearance240;
            this.MitsubishiAnswerSaveFolder_tEdit.Appearance = appearance241;
            this.MitsubishiAnswerSaveFolder_tEdit.AutoSelect = true;
            this.MitsubishiAnswerSaveFolder_tEdit.DataText = "";
            this.MitsubishiAnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MitsubishiAnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MitsubishiAnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MitsubishiAnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.MitsubishiAnswerSaveFolder_tEdit.MaxLength = 80;
            this.MitsubishiAnswerSaveFolder_tEdit.Name = "MitsubishiAnswerSaveFolder_tEdit";
            this.MitsubishiAnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.MitsubishiAnswerSaveFolder_tEdit.TabIndex = 52;
            // 
            // Mitsubishi_ultraLabel
            // 
            this.Mitsubishi_ultraLabel.Appearance = appearance242;
            this.Mitsubishi_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Mitsubishi_ultraLabel.Location = new System.Drawing.Point(14, 12);
            this.Mitsubishi_ultraLabel.Name = "Mitsubishi_ultraLabel";
            this.Mitsubishi_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.Mitsubishi_ultraLabel.TabIndex = 52;
            this.Mitsubishi_ultraLabel.Text = "�񓚕ۑ��t�H���_";
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeSystemUseType_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeSystemUseType_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoePassword_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoePassword_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeTerminalID_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeTerminalID_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeCoCode_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeCoCode_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeJigyousyoCode_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeJigyousyoCode_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoFlag_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoFlag_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoCode_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoCode_Label);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(938, 195);
            // 
            // MeiJiUoeSystemUseType_tEdit
            // 
            appearance155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeSystemUseType_tEdit.ActiveAppearance = appearance155;
            appearance156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance156.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance156.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeSystemUseType_tEdit.Appearance = appearance156;
            this.MeiJiUoeSystemUseType_tEdit.AutoSelect = true;
            this.MeiJiUoeSystemUseType_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MeiJiUoeSystemUseType_tEdit.DataText = "";
            this.MeiJiUoeSystemUseType_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeSystemUseType_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeSystemUseType_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeSystemUseType_tEdit.Location = new System.Drawing.Point(165, 18);
            this.MeiJiUoeSystemUseType_tEdit.MaxLength = 1;
            this.MeiJiUoeSystemUseType_tEdit.Name = "MeiJiUoeSystemUseType_tEdit";
            this.MeiJiUoeSystemUseType_tEdit.Size = new System.Drawing.Size(35, 24);
            this.MeiJiUoeSystemUseType_tEdit.TabIndex = 1;
            // 
            // MeiJiUoeSystemUseType_Label
            // 
            appearance174.TextVAlignAsString = "Middle";
            this.MeiJiUoeSystemUseType_Label.Appearance = appearance174;
            this.MeiJiUoeSystemUseType_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeSystemUseType_Label.Location = new System.Drawing.Point(25, 19);
            this.MeiJiUoeSystemUseType_Label.Name = "MeiJiUoeSystemUseType_Label";
            this.MeiJiUoeSystemUseType_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeSystemUseType_Label.TabIndex = 50;
            this.MeiJiUoeSystemUseType_Label.Text = "�V�X�e�����p�`��";
            // 
            // MeiJiUoePassword_tEdit
            // 
            appearance148.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoePassword_tEdit.ActiveAppearance = appearance148;
            appearance205.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance205.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoePassword_tEdit.Appearance = appearance205;
            this.MeiJiUoePassword_tEdit.AutoSelect = true;
            this.MeiJiUoePassword_tEdit.DataText = "";
            this.MeiJiUoePassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoePassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoePassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoePassword_tEdit.Location = new System.Drawing.Point(165, 156);
            this.MeiJiUoePassword_tEdit.MaxLength = 10;
            this.MeiJiUoePassword_tEdit.Name = "MeiJiUoePassword_tEdit";
            this.MeiJiUoePassword_tEdit.Size = new System.Drawing.Size(314, 24);
            this.MeiJiUoePassword_tEdit.TabIndex = 7;
            // 
            // MeiJiUoePassword_Label
            // 
            appearance206.TextVAlignAsString = "Middle";
            this.MeiJiUoePassword_Label.Appearance = appearance206;
            this.MeiJiUoePassword_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoePassword_Label.Location = new System.Drawing.Point(25, 157);
            this.MeiJiUoePassword_Label.Name = "MeiJiUoePassword_Label";
            this.MeiJiUoePassword_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoePassword_Label.TabIndex = 56;
            this.MeiJiUoePassword_Label.Text = "�p�X���[�h";
            // 
            // MeiJiUoeTerminalID_tEdit
            // 
            appearance207.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeTerminalID_tEdit.ActiveAppearance = appearance207;
            appearance208.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance208.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeTerminalID_tEdit.Appearance = appearance208;
            this.MeiJiUoeTerminalID_tEdit.AutoSelect = true;
            this.MeiJiUoeTerminalID_tEdit.DataText = "";
            this.MeiJiUoeTerminalID_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeTerminalID_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeTerminalID_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeTerminalID_tEdit.Location = new System.Drawing.Point(165, 133);
            this.MeiJiUoeTerminalID_tEdit.MaxLength = 5;
            this.MeiJiUoeTerminalID_tEdit.Name = "MeiJiUoeTerminalID_tEdit";
            this.MeiJiUoeTerminalID_tEdit.Size = new System.Drawing.Size(144, 24);
            this.MeiJiUoeTerminalID_tEdit.TabIndex = 6;
            // 
            // MeiJiUoeTerminalID_Label
            // 
            appearance209.TextVAlignAsString = "Middle";
            this.MeiJiUoeTerminalID_Label.Appearance = appearance209;
            this.MeiJiUoeTerminalID_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeTerminalID_Label.Location = new System.Drawing.Point(25, 134);
            this.MeiJiUoeTerminalID_Label.Name = "MeiJiUoeTerminalID_Label";
            this.MeiJiUoeTerminalID_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeTerminalID_Label.TabIndex = 55;
            this.MeiJiUoeTerminalID_Label.Text = "�[��ID";
            // 
            // MeiJiUoeCoCode_tEdit
            // 
            this.MeiJiUoeCoCode_tEdit.AcceptsReturn = true;
            appearance210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeCoCode_tEdit.ActiveAppearance = appearance210;
            appearance211.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance211.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeCoCode_tEdit.Appearance = appearance211;
            this.MeiJiUoeCoCode_tEdit.AutoSelect = true;
            this.MeiJiUoeCoCode_tEdit.DataText = "";
            this.MeiJiUoeCoCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeCoCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeCoCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeCoCode_tEdit.Location = new System.Drawing.Point(165, 110);
            this.MeiJiUoeCoCode_tEdit.MaxLength = 6;
            this.MeiJiUoeCoCode_tEdit.Name = "MeiJiUoeCoCode_tEdit";
            this.MeiJiUoeCoCode_tEdit.Size = new System.Drawing.Size(175, 24);
            this.MeiJiUoeCoCode_tEdit.TabIndex = 5;
            // 
            // MeiJiUoeCoCode_Label
            // 
            appearance212.TextVAlignAsString = "Middle";
            this.MeiJiUoeCoCode_Label.Appearance = appearance212;
            this.MeiJiUoeCoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeCoCode_Label.Location = new System.Drawing.Point(25, 111);
            this.MeiJiUoeCoCode_Label.Name = "MeiJiUoeCoCode_Label";
            this.MeiJiUoeCoCode_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeCoCode_Label.TabIndex = 54;
            this.MeiJiUoeCoCode_Label.Text = "��ЃR�[�h";
            // 
            // MeiJiUoeJigyousyoCode_tEdit
            // 
            this.MeiJiUoeJigyousyoCode_tEdit.AcceptsReturn = true;
            appearance213.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeJigyousyoCode_tEdit.ActiveAppearance = appearance213;
            appearance214.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance214.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeJigyousyoCode_tEdit.Appearance = appearance214;
            this.MeiJiUoeJigyousyoCode_tEdit.AutoSelect = true;
            this.MeiJiUoeJigyousyoCode_tEdit.DataText = "";
            this.MeiJiUoeJigyousyoCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeJigyousyoCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeJigyousyoCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeJigyousyoCode_tEdit.Location = new System.Drawing.Point(165, 87);
            this.MeiJiUoeJigyousyoCode_tEdit.MaxLength = 10;
            this.MeiJiUoeJigyousyoCode_tEdit.Name = "MeiJiUoeJigyousyoCode_tEdit";
            this.MeiJiUoeJigyousyoCode_tEdit.Size = new System.Drawing.Size(314, 24);
            this.MeiJiUoeJigyousyoCode_tEdit.TabIndex = 4;
            // 
            // MeiJiUoeJigyousyoCode_Label
            // 
            appearance215.TextVAlignAsString = "Middle";
            this.MeiJiUoeJigyousyoCode_Label.Appearance = appearance215;
            this.MeiJiUoeJigyousyoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeJigyousyoCode_Label.Location = new System.Drawing.Point(25, 88);
            this.MeiJiUoeJigyousyoCode_Label.Name = "MeiJiUoeJigyousyoCode_Label";
            this.MeiJiUoeJigyousyoCode_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeJigyousyoCode_Label.TabIndex = 53;
            this.MeiJiUoeJigyousyoCode_Label.Text = "���Ə��R�[�h";
            // 
            // MeiJiUoeEigyousyoFlag_tEdit
            // 
            appearance216.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance216.TextHAlignAsString = "Right";
            this.MeiJiUoeEigyousyoFlag_tEdit.ActiveAppearance = appearance216;
            appearance217.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance217.ForeColorDisabled = System.Drawing.Color.Black;
            appearance217.TextHAlignAsString = "Right";
            this.MeiJiUoeEigyousyoFlag_tEdit.Appearance = appearance217;
            this.MeiJiUoeEigyousyoFlag_tEdit.AutoSelect = true;
            this.MeiJiUoeEigyousyoFlag_tEdit.DataText = "";
            this.MeiJiUoeEigyousyoFlag_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeEigyousyoFlag_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MeiJiUoeEigyousyoFlag_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeEigyousyoFlag_tEdit.Location = new System.Drawing.Point(165, 64);
            this.MeiJiUoeEigyousyoFlag_tEdit.MaxLength = 1;
            this.MeiJiUoeEigyousyoFlag_tEdit.Name = "MeiJiUoeEigyousyoFlag_tEdit";
            this.MeiJiUoeEigyousyoFlag_tEdit.Size = new System.Drawing.Size(35, 24);
            this.MeiJiUoeEigyousyoFlag_tEdit.TabIndex = 3;
            // 
            // MeiJiUoeEigyousyoFlag_Label
            // 
            appearance218.TextVAlignAsString = "Middle";
            this.MeiJiUoeEigyousyoFlag_Label.Appearance = appearance218;
            this.MeiJiUoeEigyousyoFlag_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeEigyousyoFlag_Label.Location = new System.Drawing.Point(25, 65);
            this.MeiJiUoeEigyousyoFlag_Label.Name = "MeiJiUoeEigyousyoFlag_Label";
            this.MeiJiUoeEigyousyoFlag_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeEigyousyoFlag_Label.TabIndex = 52;
            this.MeiJiUoeEigyousyoFlag_Label.Text = "�c�Ə��t���O";
            // 
            // MeiJiUoeEigyousyoCode_tEdit
            // 
            appearance219.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeEigyousyoCode_tEdit.ActiveAppearance = appearance219;
            appearance220.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance220.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance220.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeEigyousyoCode_tEdit.Appearance = appearance220;
            this.MeiJiUoeEigyousyoCode_tEdit.AutoSelect = true;
            this.MeiJiUoeEigyousyoCode_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MeiJiUoeEigyousyoCode_tEdit.DataText = "";
            this.MeiJiUoeEigyousyoCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeEigyousyoCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeEigyousyoCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeEigyousyoCode_tEdit.Location = new System.Drawing.Point(165, 41);
            this.MeiJiUoeEigyousyoCode_tEdit.MaxLength = 5;
            this.MeiJiUoeEigyousyoCode_tEdit.Name = "MeiJiUoeEigyousyoCode_tEdit";
            this.MeiJiUoeEigyousyoCode_tEdit.Size = new System.Drawing.Size(144, 24);
            this.MeiJiUoeEigyousyoCode_tEdit.TabIndex = 2;
            // 
            // MeiJiUoeEigyousyoCode_Label
            // 
            appearance221.TextVAlignAsString = "Middle";
            this.MeiJiUoeEigyousyoCode_Label.Appearance = appearance221;
            this.MeiJiUoeEigyousyoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeEigyousyoCode_Label.Location = new System.Drawing.Point(25, 42);
            this.MeiJiUoeEigyousyoCode_Label.Name = "MeiJiUoeEigyousyoCode_Label";
            this.MeiJiUoeEigyousyoCode_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeEigyousyoCode_Label.TabIndex = 51;
            this.MeiJiUoeEigyousyoCode_Label.Text = "�c�Ə��R�[�h";
            // 
            // ultraTabPageControl8
            // 
            this.ultraTabPageControl8.Controls.Add(this.tEdit_HondaSectionCode);
            this.ultraTabPageControl8.Controls.Add(this.ultraLabel_HondaSectionCode);
            this.ultraTabPageControl8.Controls.Add(this.uButton_MazdaAnswerSaveFolder);
            this.ultraTabPageControl8.Controls.Add(this.MazdaAnswerSaveFolder_tEdit);
            this.ultraTabPageControl8.Controls.Add(this.Mazda_ultraLabel);
            this.ultraTabPageControl8.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabPageControl8.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new System.Drawing.Size(938, 195);
            // 
            // tEdit_HondaSectionCode
            // 
            this.tEdit_HondaSectionCode.ActiveAppearance = appearance175;
            this.tEdit_HondaSectionCode.Appearance = appearance176;
            this.tEdit_HondaSectionCode.AutoSelect = true;
            this.tEdit_HondaSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_HondaSectionCode.DataText = "";
            this.tEdit_HondaSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_HondaSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_HondaSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_HondaSectionCode.Location = new System.Drawing.Point(163, 41);
            this.tEdit_HondaSectionCode.MaxLength = 3;
            this.tEdit_HondaSectionCode.Name = "tEdit_HondaSectionCode";
            this.tEdit_HondaSectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_HondaSectionCode.TabIndex = 58;
            // 
            // ultraLabel_HondaSectionCode
            // 
            appearance177.TextVAlignAsString = "Middle";
            this.ultraLabel_HondaSectionCode.Appearance = appearance177;
            this.ultraLabel_HondaSectionCode.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_HondaSectionCode.Location = new System.Drawing.Point(14, 41);
            this.ultraLabel_HondaSectionCode.Name = "ultraLabel_HondaSectionCode";
            this.ultraLabel_HondaSectionCode.Size = new System.Drawing.Size(144, 24);
            this.ultraLabel_HondaSectionCode.TabIndex = 57;
            this.ultraLabel_HondaSectionCode.Text = "WEB�_�~�[�i��";
            // 
            // uButton_MazdaAnswerSaveFolder
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_MazdaAnswerSaveFolder.Appearance = appearance12;
            this.uButton_MazdaAnswerSaveFolder.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MazdaAnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_MazdaAnswerSaveFolder.Name = "uButton_MazdaAnswerSaveFolder";
            this.uButton_MazdaAnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_MazdaAnswerSaveFolder.TabIndex = 56;
            this.uButton_MazdaAnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MazdaAnswerSaveFolder.Click += new System.EventHandler(this.uButton_MazdaAnswerSaveFolder_Click);
            // 
            // MazdaAnswerSaveFolder_tEdit
            // 
            appearance222.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MazdaAnswerSaveFolder_tEdit.ActiveAppearance = appearance222;
            appearance223.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance223.ForeColorDisabled = System.Drawing.Color.Black;
            this.MazdaAnswerSaveFolder_tEdit.Appearance = appearance223;
            this.MazdaAnswerSaveFolder_tEdit.AutoSelect = true;
            this.MazdaAnswerSaveFolder_tEdit.DataText = "";
            this.MazdaAnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MazdaAnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MazdaAnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MazdaAnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.MazdaAnswerSaveFolder_tEdit.MaxLength = 80;
            this.MazdaAnswerSaveFolder_tEdit.Name = "MazdaAnswerSaveFolder_tEdit";
            this.MazdaAnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.MazdaAnswerSaveFolder_tEdit.TabIndex = 55;
            // 
            // Mazda_ultraLabel
            // 
            this.Mazda_ultraLabel.Appearance = appearance235;
            this.Mazda_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Mazda_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.Mazda_ultraLabel.Location = new System.Drawing.Point(14, 12);
            this.Mazda_ultraLabel.Name = "Mazda_ultraLabel";
            this.Mazda_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.Mazda_ultraLabel.TabIndex = 54;
            this.Mazda_ultraLabel.Text = "�񓚕ۑ��t�H���_";
            // 
            // ultraTabPageControl9
            // 
            this.ultraTabPageControl9.Controls.Add(this.CarMaker_uButton);
            this.ultraTabPageControl9.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl9.Controls.Add(this.BLMngUserCode_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.TimeOut_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.PurchaseAddress_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.RestoreAddress_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.OrderAddress_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.Domain_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.Connection_tComboEditor);
            this.ultraTabPageControl9.Controls.Add(this.Protocol_tComboEditor);
            this.ultraTabPageControl9.Controls.Add(this.CarMaker_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.Connection_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.BLMngUserCode_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.TimeOut_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.PurchaseAddress_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.RestoreAddress_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.OrderAddress_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.Domain_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.Protocol_uLabel);
            this.ultraTabPageControl9.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new System.Drawing.Size(938, 195);
            // 
            // CarMaker_uButton
            // 
            this.CarMaker_uButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CarMaker_uButton.Location = new System.Drawing.Point(704, 10);
            this.CarMaker_uButton.Name = "CarMaker_uButton";
            this.CarMaker_uButton.Size = new System.Drawing.Size(80, 25);
            this.CarMaker_uButton.TabIndex = 16;
            this.CarMaker_uButton.Text = "�o�^";
            this.CarMaker_uButton.Click += new System.EventHandler(this.CarMaker_uButton_Click);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(228, 162);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(32, 21);
            this.ultraLabel2.TabIndex = 15;
            this.ultraLabel2.Text = "�b";
            // 
            // BLMngUserCode_tEdit
            // 
            appearance258.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLMngUserCode_tEdit.ActiveAppearance = appearance258;
            appearance269.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance269.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance269.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLMngUserCode_tEdit.Appearance = appearance269;
            this.BLMngUserCode_tEdit.AutoSelect = true;
            this.BLMngUserCode_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BLMngUserCode_tEdit.DataText = "";
            this.BLMngUserCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLMngUserCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BLMngUserCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BLMngUserCode_tEdit.Location = new System.Drawing.Point(434, 157);
            this.BLMngUserCode_tEdit.MaxLength = 9;
            this.BLMngUserCode_tEdit.Name = "BLMngUserCode_tEdit";
            this.BLMngUserCode_tEdit.Size = new System.Drawing.Size(82, 24);
            this.BLMngUserCode_tEdit.TabIndex = 15;
            // 
            // TimeOut_tEdit
            // 
            appearance270.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance270.TextHAlignAsString = "Right";
            this.TimeOut_tEdit.ActiveAppearance = appearance270;
            appearance271.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance271.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance271.ForeColorDisabled = System.Drawing.Color.Black;
            appearance271.TextHAlignAsString = "Right";
            this.TimeOut_tEdit.Appearance = appearance271;
            this.TimeOut_tEdit.AutoSelect = true;
            this.TimeOut_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.TimeOut_tEdit.DataText = "";
            this.TimeOut_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TimeOut_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.TimeOut_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TimeOut_tEdit.Location = new System.Drawing.Point(156, 159);
            this.TimeOut_tEdit.MaxLength = 3;
            this.TimeOut_tEdit.Name = "TimeOut_tEdit";
            this.TimeOut_tEdit.Size = new System.Drawing.Size(66, 24);
            this.TimeOut_tEdit.TabIndex = 14;
            // 
            // PurchaseAddress_tEdit
            // 
            appearance257.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PurchaseAddress_tEdit.ActiveAppearance = appearance257;
            appearance268.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance268.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance268.ForeColorDisabled = System.Drawing.Color.Black;
            this.PurchaseAddress_tEdit.Appearance = appearance268;
            this.PurchaseAddress_tEdit.AutoSelect = true;
            this.PurchaseAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PurchaseAddress_tEdit.DataText = "";
            this.PurchaseAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PurchaseAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.PurchaseAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PurchaseAddress_tEdit.Location = new System.Drawing.Point(156, 129);
            this.PurchaseAddress_tEdit.MaxLength = 255;
            this.PurchaseAddress_tEdit.Name = "PurchaseAddress_tEdit";
            this.PurchaseAddress_tEdit.Size = new System.Drawing.Size(360, 24);
            this.PurchaseAddress_tEdit.TabIndex = 13;
            // 
            // RestoreAddress_tEdit
            // 
            appearance256.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RestoreAddress_tEdit.ActiveAppearance = appearance256;
            appearance267.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance267.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance267.ForeColorDisabled = System.Drawing.Color.Black;
            this.RestoreAddress_tEdit.Appearance = appearance267;
            this.RestoreAddress_tEdit.AutoSelect = true;
            this.RestoreAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RestoreAddress_tEdit.DataText = "";
            this.RestoreAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RestoreAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.RestoreAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RestoreAddress_tEdit.Location = new System.Drawing.Point(156, 99);
            this.RestoreAddress_tEdit.MaxLength = 255;
            this.RestoreAddress_tEdit.Name = "RestoreAddress_tEdit";
            this.RestoreAddress_tEdit.Size = new System.Drawing.Size(360, 24);
            this.RestoreAddress_tEdit.TabIndex = 12;
            // 
            // OrderAddress_tEdit
            // 
            appearance249.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OrderAddress_tEdit.ActiveAppearance = appearance249;
            appearance266.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance266.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance266.ForeColorDisabled = System.Drawing.Color.Black;
            this.OrderAddress_tEdit.Appearance = appearance266;
            this.OrderAddress_tEdit.AutoSelect = true;
            this.OrderAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OrderAddress_tEdit.DataText = "";
            this.OrderAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OrderAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.OrderAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.OrderAddress_tEdit.Location = new System.Drawing.Point(156, 69);
            this.OrderAddress_tEdit.MaxLength = 255;
            this.OrderAddress_tEdit.Name = "OrderAddress_tEdit";
            this.OrderAddress_tEdit.Size = new System.Drawing.Size(360, 24);
            this.OrderAddress_tEdit.TabIndex = 11;
            // 
            // Domain_tEdit
            // 
            appearance234.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Domain_tEdit.ActiveAppearance = appearance234;
            appearance265.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance265.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance265.ForeColorDisabled = System.Drawing.Color.Black;
            this.Domain_tEdit.Appearance = appearance265;
            this.Domain_tEdit.AutoSelect = true;
            this.Domain_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Domain_tEdit.DataText = "";
            this.Domain_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Domain_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.Domain_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Domain_tEdit.Location = new System.Drawing.Point(156, 41);
            this.Domain_tEdit.MaxLength = 255;
            this.Domain_tEdit.Name = "Domain_tEdit";
            this.Domain_tEdit.Size = new System.Drawing.Size(360, 24);
            this.Domain_tEdit.TabIndex = 10;
            // 
            // Connection_tComboEditor
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            this.Connection_tComboEditor.ActiveAppearance = appearance51;
            appearance263.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance263.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance263.ForeColor = System.Drawing.Color.Black;
            appearance263.ForeColorDisabled = System.Drawing.Color.Black;
            this.Connection_tComboEditor.Appearance = appearance263;
            this.Connection_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Connection_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Connection_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance264.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Connection_tComboEditor.ItemAppearance = appearance264;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "A�^�C�v";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "B�^�C�v";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "C�^�C�v";
            this.Connection_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.Connection_tComboEditor.Location = new System.Drawing.Point(379, 10);
            this.Connection_tComboEditor.MaxLength = 1;
            this.Connection_tComboEditor.Name = "Connection_tComboEditor";
            this.Connection_tComboEditor.Size = new System.Drawing.Size(93, 24);
            this.Connection_tComboEditor.TabIndex = 9;
            this.Connection_tComboEditor.Text = "A�^�C�v";
            this.Connection_tComboEditor.SelectionChanged += new System.EventHandler(this.Connection_tComboEditor_SelectionChanged);
            // 
            // Protocol_tComboEditor
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            this.Protocol_tComboEditor.ActiveAppearance = appearance36;
            appearance261.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance261.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance261.ForeColor = System.Drawing.Color.Black;
            appearance261.ForeColorDisabled = System.Drawing.Color.Black;
            this.Protocol_tComboEditor.Appearance = appearance261;
            this.Protocol_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Protocol_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Protocol_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance262.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Protocol_tComboEditor.ItemAppearance = appearance262;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "HTTP";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "HTTPS";
            this.Protocol_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.Protocol_tComboEditor.Location = new System.Drawing.Point(156, 11);
            this.Protocol_tComboEditor.MaxLength = 1;
            this.Protocol_tComboEditor.Name = "Protocol_tComboEditor";
            this.Protocol_tComboEditor.Size = new System.Drawing.Size(84, 24);
            this.Protocol_tComboEditor.TabIndex = 8;
            this.Protocol_tComboEditor.Text = "HTTP";
            // 
            // CarMaker_uLabel
            // 
            appearance260.TextVAlignAsString = "Middle";
            this.CarMaker_uLabel.Appearance = appearance260;
            this.CarMaker_uLabel.Location = new System.Drawing.Point(543, 10);
            this.CarMaker_uLabel.Name = "CarMaker_uLabel";
            this.CarMaker_uLabel.Size = new System.Drawing.Size(137, 23);
            this.CarMaker_uLabel.TabIndex = 7;
            this.CarMaker_uLabel.Text = "�O�ԑΉ����[�J�[";
            // 
            // Connection_uLabel
            // 
            appearance259.TextVAlignAsString = "Middle";
            this.Connection_uLabel.Appearance = appearance259;
            this.Connection_uLabel.Location = new System.Drawing.Point(257, 10);
            this.Connection_uLabel.Name = "Connection_uLabel";
            this.Connection_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Connection_uLabel.TabIndex = 6;
            this.Connection_uLabel.Text = "�ڑ��敪";
            // 
            // BLMngUserCode_uLabel
            // 
            appearance255.TextVAlignAsString = "Middle";
            this.BLMngUserCode_uLabel.Appearance = appearance255;
            this.BLMngUserCode_uLabel.Location = new System.Drawing.Point(264, 159);
            this.BLMngUserCode_uLabel.Name = "BLMngUserCode_uLabel";
            this.BLMngUserCode_uLabel.Size = new System.Drawing.Size(164, 23);
            this.BLMngUserCode_uLabel.TabIndex = 5;
            this.BLMngUserCode_uLabel.Text = "BL�Ǘ����[�U�[�R�[�h";
            // 
            // TimeOut_uLabel
            // 
            appearance272.TextVAlignAsString = "Middle";
            this.TimeOut_uLabel.Appearance = appearance272;
            this.TimeOut_uLabel.Location = new System.Drawing.Point(3, 157);
            this.TimeOut_uLabel.Name = "TimeOut_uLabel";
            this.TimeOut_uLabel.Size = new System.Drawing.Size(100, 23);
            this.TimeOut_uLabel.TabIndex = 5;
            this.TimeOut_uLabel.Text = "�^�C���A�E�g";
            // 
            // PurchaseAddress_uLabel
            // 
            appearance254.TextVAlignAsString = "Middle";
            this.PurchaseAddress_uLabel.Appearance = appearance254;
            this.PurchaseAddress_uLabel.Location = new System.Drawing.Point(3, 128);
            this.PurchaseAddress_uLabel.Name = "PurchaseAddress_uLabel";
            this.PurchaseAddress_uLabel.Size = new System.Drawing.Size(145, 23);
            this.PurchaseAddress_uLabel.TabIndex = 4;
            this.PurchaseAddress_uLabel.Text = "�d����M�p�A�h���X";
            // 
            // RestoreAddress_uLabel
            // 
            appearance253.TextVAlignAsString = "Middle";
            this.RestoreAddress_uLabel.Appearance = appearance253;
            this.RestoreAddress_uLabel.Location = new System.Drawing.Point(3, 99);
            this.RestoreAddress_uLabel.Name = "RestoreAddress_uLabel";
            this.RestoreAddress_uLabel.Size = new System.Drawing.Size(112, 23);
            this.RestoreAddress_uLabel.TabIndex = 3;
            this.RestoreAddress_uLabel.Text = "�����p�A�h���X";
            // 
            // OrderAddress_uLabel
            // 
            appearance252.TextVAlignAsString = "Middle";
            this.OrderAddress_uLabel.Appearance = appearance252;
            this.OrderAddress_uLabel.Location = new System.Drawing.Point(3, 70);
            this.OrderAddress_uLabel.Name = "OrderAddress_uLabel";
            this.OrderAddress_uLabel.Size = new System.Drawing.Size(112, 23);
            this.OrderAddress_uLabel.TabIndex = 2;
            this.OrderAddress_uLabel.Text = "�����p�A�h���X";
            // 
            // Domain_uLabel
            // 
            appearance251.TextVAlignAsString = "Middle";
            this.Domain_uLabel.Appearance = appearance251;
            this.Domain_uLabel.Location = new System.Drawing.Point(3, 44);
            this.Domain_uLabel.Name = "Domain_uLabel";
            this.Domain_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Domain_uLabel.TabIndex = 1;
            this.Domain_uLabel.Text = "�h���C��";
            // 
            // Protocol_uLabel
            // 
            appearance250.TextVAlignAsString = "Middle";
            this.Protocol_uLabel.Appearance = appearance250;
            this.Protocol_uLabel.Location = new System.Drawing.Point(3, 10);
            this.Protocol_uLabel.Name = "Protocol_uLabel";
            this.Protocol_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Protocol_uLabel.TabIndex = 0;
            this.Protocol_uLabel.Text = "�v���g�R��";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 675);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(962, 23);
            this.ultraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraStatusBar1.TabIndex = 26;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(850, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 27;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // UOESupplierCd_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.UOESupplierCd_Label.Appearance = appearance4;
            this.UOESupplierCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESupplierCd_Label.Location = new System.Drawing.Point(12, 22);
            this.UOESupplierCd_Label.Name = "UOESupplierCd_Label";
            this.UOESupplierCd_Label.Size = new System.Drawing.Size(123, 23);
            this.UOESupplierCd_Label.TabIndex = 28;
            this.UOESupplierCd_Label.Text = "������R�[�h";
            // 
            // UOESupplierName_tEdit
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOESupplierName_tEdit.ActiveAppearance = appearance45;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESupplierName_tEdit.Appearance = appearance6;
            this.UOESupplierName_tEdit.AutoSelect = true;
            this.UOESupplierName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOESupplierName_tEdit.DataText = "";
            this.UOESupplierName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESupplierName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOESupplierName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.UOESupplierName_tEdit.Location = new System.Drawing.Point(206, 22);
            this.UOESupplierName_tEdit.MaxLength = 30;
            this.UOESupplierName_tEdit.Name = "UOESupplierName_tEdit";
            this.UOESupplierName_tEdit.Size = new System.Drawing.Size(407, 24);
            this.UOESupplierName_tEdit.TabIndex = 1;
            // 
            // GoodsMakerCd_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.GoodsMakerCd_Label.Appearance = appearance7;
            this.GoodsMakerCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.GoodsMakerCd_Label.Location = new System.Drawing.Point(12, 62);
            this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
            this.GoodsMakerCd_Label.Size = new System.Drawing.Size(123, 23);
            this.GoodsMakerCd_Label.TabIndex = 28;
            this.GoodsMakerCd_Label.Text = "���[�J�[�R�[�h";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel8.Location = new System.Drawing.Point(10, 52);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(940, 4);
            this.ultraLabel8.TabIndex = 30;
            // 
            // TelNo_Label
            // 
            appearance85.TextVAlignAsString = "Middle";
            this.TelNo_Label.Appearance = appearance85;
            this.TelNo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.TelNo_Label.Location = new System.Drawing.Point(12, 182);
            this.TelNo_Label.Name = "TelNo_Label";
            this.TelNo_Label.Size = new System.Drawing.Size(123, 23);
            this.TelNo_Label.TabIndex = 28;
            this.TelNo_Label.Text = "�d�b�ԍ�";
            // 
            // UOETerminalCd_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.UOETerminalCd_Label.Appearance = appearance9;
            this.UOETerminalCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOETerminalCd_Label.Location = new System.Drawing.Point(12, 212);
            this.UOETerminalCd_Label.Name = "UOETerminalCd_Label";
            this.UOETerminalCd_Label.Size = new System.Drawing.Size(123, 23);
            this.UOETerminalCd_Label.TabIndex = 28;
            this.UOETerminalCd_Label.Text = "�[���R�[�h";
            // 
            // UOEHostCode_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.UOEHostCode_Label.Appearance = appearance10;
            this.UOEHostCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEHostCode_Label.Location = new System.Drawing.Point(12, 242);
            this.UOEHostCode_Label.Name = "UOEHostCode_Label";
            this.UOEHostCode_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEHostCode_Label.TabIndex = 28;
            this.UOEHostCode_Label.Text = "�z�X�g�R�[�h";
            // 
            // UOEConnectPassword_Label
            // 
            appearance196.TextVAlignAsString = "Middle";
            this.UOEConnectPassword_Label.Appearance = appearance196;
            this.UOEConnectPassword_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEConnectPassword_Label.Location = new System.Drawing.Point(12, 272);
            this.UOEConnectPassword_Label.Name = "UOEConnectPassword_Label";
            this.UOEConnectPassword_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEConnectPassword_Label.TabIndex = 28;
            this.UOEConnectPassword_Label.Text = "�p�X���[�h";
            // 
            // UOEConnectUserId_Label
            // 
            appearance143.TextVAlignAsString = "Middle";
            this.UOEConnectUserId_Label.Appearance = appearance143;
            this.UOEConnectUserId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEConnectUserId_Label.Location = new System.Drawing.Point(12, 302);
            this.UOEConnectUserId_Label.Name = "UOEConnectUserId_Label";
            this.UOEConnectUserId_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEConnectUserId_Label.TabIndex = 28;
            this.UOEConnectUserId_Label.Text = "���[�U�[�R�[�h";
            // 
            // UOEIDNum_Label
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.UOEIDNum_Label.Appearance = appearance13;
            this.UOEIDNum_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEIDNum_Label.Location = new System.Drawing.Point(12, 332);
            this.UOEIDNum_Label.Name = "UOEIDNum_Label";
            this.UOEIDNum_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEIDNum_Label.TabIndex = 28;
            this.UOEIDNum_Label.Text = "�h�c�ԍ�";
            // 
            // CommAssemblyId_Label
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.CommAssemblyId_Label.Appearance = appearance18;
            this.CommAssemblyId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CommAssemblyId_Label.Location = new System.Drawing.Point(12, 362);
            this.CommAssemblyId_Label.Name = "CommAssemblyId_Label";
            this.CommAssemblyId_Label.Size = new System.Drawing.Size(123, 23);
            this.CommAssemblyId_Label.TabIndex = 28;
            this.CommAssemblyId_Label.Text = "�v���O����";
            // 
            // GoodsMakerNm_tEdit
            // 
            this.GoodsMakerNm_tEdit.ActiveAppearance = appearance163;
            appearance164.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance164.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsMakerNm_tEdit.Appearance = appearance164;
            this.GoodsMakerNm_tEdit.AutoSelect = true;
            this.GoodsMakerNm_tEdit.DataText = "";
            this.GoodsMakerNm_tEdit.Enabled = false;
            this.GoodsMakerNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsMakerNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GoodsMakerNm_tEdit.Location = new System.Drawing.Point(141, 92);
            this.GoodsMakerNm_tEdit.MaxLength = 30;
            this.GoodsMakerNm_tEdit.Name = "GoodsMakerNm_tEdit";
            this.GoodsMakerNm_tEdit.Size = new System.Drawing.Size(159, 24);
            this.GoodsMakerNm_tEdit.TabIndex = 5;
            this.GoodsMakerNm_tEdit.TabStop = false;
            // 
            // TelNo_tEdit
            // 
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TelNo_tEdit.ActiveAppearance = appearance101;
            appearance102.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance102.ForeColorDisabled = System.Drawing.Color.Black;
            this.TelNo_tEdit.Appearance = appearance102;
            this.TelNo_tEdit.AutoSelect = true;
            this.TelNo_tEdit.DataText = "";
            this.TelNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TelNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TelNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TelNo_tEdit.Location = new System.Drawing.Point(141, 182);
            this.TelNo_tEdit.MaxLength = 16;
            this.TelNo_tEdit.Name = "TelNo_tEdit";
            this.TelNo_tEdit.Size = new System.Drawing.Size(144, 24);
            this.TelNo_tEdit.TabIndex = 7;
            // 
            // UOESupplierCd_tNedit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.UOESupplierCd_tNedit.ActiveAppearance = appearance20;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            this.UOESupplierCd_tNedit.Appearance = appearance2;
            this.UOESupplierCd_tNedit.AutoSelect = true;
            this.UOESupplierCd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOESupplierCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.UOESupplierCd_tNedit.DataText = "";
            this.UOESupplierCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESupplierCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.UOESupplierCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOESupplierCd_tNedit.Location = new System.Drawing.Point(141, 22);
            this.UOESupplierCd_tNedit.MaxLength = 6;
            this.UOESupplierCd_tNedit.Name = "UOESupplierCd_tNedit";
            this.UOESupplierCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.UOESupplierCd_tNedit.Size = new System.Drawing.Size(59, 24);
            this.UOESupplierCd_tNedit.TabIndex = 0;
            // 
            // tNedit_GoodsMakerCdAllowZero
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCdAllowZero.ActiveAppearance = appearance111;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCdAllowZero.Appearance = appearance14;
            this.tNedit_GoodsMakerCdAllowZero.AutoSelect = true;
            this.tNedit_GoodsMakerCdAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCdAllowZero.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCdAllowZero.DataText = "";
            this.tNedit_GoodsMakerCdAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCdAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCdAllowZero.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCdAllowZero.Location = new System.Drawing.Point(141, 62);
            this.tNedit_GoodsMakerCdAllowZero.MaxLength = 4;
            this.tNedit_GoodsMakerCdAllowZero.Name = "tNedit_GoodsMakerCdAllowZero";
            this.tNedit_GoodsMakerCdAllowZero.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCdAllowZero.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCdAllowZero.TabIndex = 3;
            // 
            // UOETerminalCd_tEdit
            // 
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOETerminalCd_tEdit.ActiveAppearance = appearance79;
            appearance126.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance126.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOETerminalCd_tEdit.Appearance = appearance126;
            this.UOETerminalCd_tEdit.AutoSelect = true;
            this.UOETerminalCd_tEdit.DataText = "";
            this.UOETerminalCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOETerminalCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOETerminalCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOETerminalCd_tEdit.Location = new System.Drawing.Point(141, 212);
            this.UOETerminalCd_tEdit.MaxLength = 7;
            this.UOETerminalCd_tEdit.Name = "UOETerminalCd_tEdit";
            this.UOETerminalCd_tEdit.Size = new System.Drawing.Size(82, 24);
            this.UOETerminalCd_tEdit.TabIndex = 8;
            // 
            // UOEHostCode_tEdit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEHostCode_tEdit.ActiveAppearance = appearance22;
            appearance42.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEHostCode_tEdit.Appearance = appearance42;
            this.UOEHostCode_tEdit.AutoSelect = true;
            this.UOEHostCode_tEdit.DataText = "";
            this.UOEHostCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEHostCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEHostCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEHostCode_tEdit.Location = new System.Drawing.Point(141, 242);
            this.UOEHostCode_tEdit.MaxLength = 7;
            this.UOEHostCode_tEdit.Name = "UOEHostCode_tEdit";
            this.UOEHostCode_tEdit.Size = new System.Drawing.Size(82, 24);
            this.UOEHostCode_tEdit.TabIndex = 9;
            // 
            // UOEConnectPassword_tEdit
            // 
            appearance153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEConnectPassword_tEdit.ActiveAppearance = appearance153;
            appearance154.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance154.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEConnectPassword_tEdit.Appearance = appearance154;
            this.UOEConnectPassword_tEdit.AutoSelect = true;
            this.UOEConnectPassword_tEdit.DataText = "";
            this.UOEConnectPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEConnectPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.UOEConnectPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEConnectPassword_tEdit.Location = new System.Drawing.Point(141, 272);
            this.UOEConnectPassword_tEdit.MaxLength = 6;
            this.UOEConnectPassword_tEdit.Name = "UOEConnectPassword_tEdit";
            this.UOEConnectPassword_tEdit.Size = new System.Drawing.Size(59, 24);
            this.UOEConnectPassword_tEdit.TabIndex = 10;
            // 
            // UOEConnectUserId_tEdit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEConnectUserId_tEdit.ActiveAppearance = appearance3;
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEConnectUserId_tEdit.Appearance = appearance44;
            this.UOEConnectUserId_tEdit.AutoSelect = true;
            this.UOEConnectUserId_tEdit.DataText = "";
            this.UOEConnectUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEConnectUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEConnectUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEConnectUserId_tEdit.Location = new System.Drawing.Point(141, 302);
            this.UOEConnectUserId_tEdit.MaxLength = 12;
            this.UOEConnectUserId_tEdit.Name = "UOEConnectUserId_tEdit";
            this.UOEConnectUserId_tEdit.Size = new System.Drawing.Size(105, 24);
            this.UOEConnectUserId_tEdit.TabIndex = 11;
            // 
            // UOEIDNum_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEIDNum_tEdit.ActiveAppearance = appearance16;
            appearance46.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEIDNum_tEdit.Appearance = appearance46;
            this.UOEIDNum_tEdit.AutoSelect = true;
            this.UOEIDNum_tEdit.DataText = "";
            this.UOEIDNum_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEIDNum_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEIDNum_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEIDNum_tEdit.Location = new System.Drawing.Point(141, 332);
            this.UOEIDNum_tEdit.MaxLength = 15;
            this.UOEIDNum_tEdit.Name = "UOEIDNum_tEdit";
            this.UOEIDNum_tEdit.Size = new System.Drawing.Size(144, 24);
            this.UOEIDNum_tEdit.TabIndex = 12;
            // 
            // CommAssemblyId_tEdit
            // 
            appearance247.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CommAssemblyId_tEdit.ActiveAppearance = appearance247;
            appearance248.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance248.ForeColorDisabled = System.Drawing.Color.Black;
            this.CommAssemblyId_tEdit.Appearance = appearance248;
            this.CommAssemblyId_tEdit.AutoSelect = true;
            this.CommAssemblyId_tEdit.DataText = "";
            this.CommAssemblyId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CommAssemblyId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, false, false, false, false, true));
            this.CommAssemblyId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CommAssemblyId_tEdit.Location = new System.Drawing.Point(141, 362);
            this.CommAssemblyId_tEdit.MaxLength = 4;
            this.CommAssemblyId_tEdit.Name = "CommAssemblyId_tEdit";
            this.CommAssemblyId_tEdit.Size = new System.Drawing.Size(51, 24);
            this.CommAssemblyId_tEdit.TabIndex = 13;
            // 
            // ConnectVersionDiv_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ConnectVersionDiv_Label.Appearance = appearance5;
            this.ConnectVersionDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ConnectVersionDiv_Label.Location = new System.Drawing.Point(199, 362);
            this.ConnectVersionDiv_Label.Name = "ConnectVersionDiv_Label";
            this.ConnectVersionDiv_Label.Size = new System.Drawing.Size(52, 23);
            this.ConnectVersionDiv_Label.TabIndex = 28;
            this.ConnectVersionDiv_Label.Text = "Ver";
            // 
            // ConnectVersionDiv_tComboEditor
            // 
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance113.ForeColor = System.Drawing.Color.Black;
            appearance113.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConnectVersionDiv_tComboEditor.ActiveAppearance = appearance113;
            appearance114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance114.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance114.ForeColor = System.Drawing.Color.Black;
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConnectVersionDiv_tComboEditor.Appearance = appearance114;
            this.ConnectVersionDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ConnectVersionDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConnectVersionDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConnectVersionDiv_tComboEditor.ItemAppearance = appearance115;
            this.ConnectVersionDiv_tComboEditor.Location = new System.Drawing.Point(257, 362);
            this.ConnectVersionDiv_tComboEditor.MaxDropDownItems = 18;
            this.ConnectVersionDiv_tComboEditor.Name = "ConnectVersionDiv_tComboEditor";
            this.ConnectVersionDiv_tComboEditor.Size = new System.Drawing.Size(63, 24);
            this.ConnectVersionDiv_tComboEditor.TabIndex = 14;
            // 
            // UOEShipSectCd_Label
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.UOEShipSectCd_Label.Appearance = appearance27;
            this.UOEShipSectCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEShipSectCd_Label.Location = new System.Drawing.Point(326, 62);
            this.UOEShipSectCd_Label.Name = "UOEShipSectCd_Label";
            this.UOEShipSectCd_Label.Size = new System.Drawing.Size(107, 23);
            this.UOEShipSectCd_Label.TabIndex = 28;
            this.UOEShipSectCd_Label.Text = "�o�ɋ��_";
            // 
            // UOESalSectCd_Label
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.UOESalSectCd_Label.Appearance = appearance28;
            this.UOESalSectCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESalSectCd_Label.Location = new System.Drawing.Point(326, 92);
            this.UOESalSectCd_Label.Name = "UOESalSectCd_Label";
            this.UOESalSectCd_Label.Size = new System.Drawing.Size(107, 23);
            this.UOESalSectCd_Label.TabIndex = 28;
            this.UOESalSectCd_Label.Text = "���㋒�_";
            // 
            // UOEReservSectCd_Label
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.UOEReservSectCd_Label.Appearance = appearance29;
            this.UOEReservSectCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEReservSectCd_Label.Location = new System.Drawing.Point(326, 122);
            this.UOEReservSectCd_Label.Name = "UOEReservSectCd_Label";
            this.UOEReservSectCd_Label.Size = new System.Drawing.Size(107, 23);
            this.UOEReservSectCd_Label.TabIndex = 28;
            this.UOEReservSectCd_Label.Text = "�w�苒�_";
            // 
            // ReceiveCondition_Label
            // 
            appearance31.TextVAlignAsString = "Middle";
            this.ReceiveCondition_Label.Appearance = appearance31;
            this.ReceiveCondition_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ReceiveCondition_Label.Location = new System.Drawing.Point(326, 152);
            this.ReceiveCondition_Label.Name = "ReceiveCondition_Label";
            this.ReceiveCondition_Label.Size = new System.Drawing.Size(107, 23);
            this.ReceiveCondition_Label.TabIndex = 28;
            this.ReceiveCondition_Label.Text = "��M�L���敪";
            // 
            // SubstPartsNoDiv_Label
            // 
            appearance50.TextVAlignAsString = "Middle";
            this.SubstPartsNoDiv_Label.Appearance = appearance50;
            this.SubstPartsNoDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SubstPartsNoDiv_Label.Location = new System.Drawing.Point(326, 182);
            this.SubstPartsNoDiv_Label.Name = "SubstPartsNoDiv_Label";
            this.SubstPartsNoDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.SubstPartsNoDiv_Label.TabIndex = 28;
            this.SubstPartsNoDiv_Label.Text = "��֕i�ԋ敪";
            // 
            // PartsNoPrtCd_Label
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.PartsNoPrtCd_Label.Appearance = appearance33;
            this.PartsNoPrtCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PartsNoPrtCd_Label.Location = new System.Drawing.Point(326, 212);
            this.PartsNoPrtCd_Label.Name = "PartsNoPrtCd_Label";
            this.PartsNoPrtCd_Label.Size = new System.Drawing.Size(107, 23);
            this.PartsNoPrtCd_Label.TabIndex = 28;
            this.PartsNoPrtCd_Label.Text = "�i�Ԉ���敪";
            // 
            // ListPriceUseDiv_Label
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ListPriceUseDiv_Label.Appearance = appearance34;
            this.ListPriceUseDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ListPriceUseDiv_Label.Location = new System.Drawing.Point(326, 242);
            this.ListPriceUseDiv_Label.Name = "ListPriceUseDiv_Label";
            this.ListPriceUseDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.ListPriceUseDiv_Label.TabIndex = 28;
            this.ListPriceUseDiv_Label.Text = "�艿�g�p�敪";
            // 
            // StockSlipDtRecvDiv_Label
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.StockSlipDtRecvDiv_Label.Appearance = appearance37;
            this.StockSlipDtRecvDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.StockSlipDtRecvDiv_Label.Location = new System.Drawing.Point(326, 272);
            this.StockSlipDtRecvDiv_Label.Name = "StockSlipDtRecvDiv_Label";
            this.StockSlipDtRecvDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.StockSlipDtRecvDiv_Label.TabIndex = 28;
            this.StockSlipDtRecvDiv_Label.Text = "�d����M�敪";
            // 
            // CheckCodeDiv_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.CheckCodeDiv_Label.Appearance = appearance8;
            this.CheckCodeDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CheckCodeDiv_Label.Location = new System.Drawing.Point(326, 302);
            this.CheckCodeDiv_Label.Name = "CheckCodeDiv_Label";
            this.CheckCodeDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.CheckCodeDiv_Label.TabIndex = 28;
            this.CheckCodeDiv_Label.Text = "�`�F�b�N�敪";
            // 
            // UOEShipSectCd_tEdit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEShipSectCd_tEdit.ActiveAppearance = appearance38;
            appearance52.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance52.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEShipSectCd_tEdit.Appearance = appearance52;
            this.UOEShipSectCd_tEdit.AutoSelect = true;
            this.UOEShipSectCd_tEdit.DataText = "";
            this.UOEShipSectCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEShipSectCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEShipSectCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEShipSectCd_tEdit.Location = new System.Drawing.Point(439, 62);
            this.UOEShipSectCd_tEdit.MaxLength = 3;
            this.UOEShipSectCd_tEdit.Name = "UOEShipSectCd_tEdit";
            this.UOEShipSectCd_tEdit.Size = new System.Drawing.Size(35, 24);
            this.UOEShipSectCd_tEdit.TabIndex = 15;
            // 
            // UOEShipSectNm_tEdit
            // 
            this.UOEShipSectNm_tEdit.ActiveAppearance = appearance39;
            appearance71.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance71.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEShipSectNm_tEdit.Appearance = appearance71;
            this.UOEShipSectNm_tEdit.AutoSelect = true;
            this.UOEShipSectNm_tEdit.DataText = "";
            this.UOEShipSectNm_tEdit.Enabled = false;
            this.UOEShipSectNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEShipSectNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEShipSectNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEShipSectNm_tEdit.Location = new System.Drawing.Point(481, 62);
            this.UOEShipSectNm_tEdit.MaxLength = 30;
            this.UOEShipSectNm_tEdit.Name = "UOEShipSectNm_tEdit";
            this.UOEShipSectNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.UOEShipSectNm_tEdit.TabIndex = 29;
            this.UOEShipSectNm_tEdit.TabStop = false;
            // 
            // UOESalSectCd_tEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOESalSectCd_tEdit.ActiveAppearance = appearance40;
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESalSectCd_tEdit.Appearance = appearance53;
            this.UOESalSectCd_tEdit.AutoSelect = true;
            this.UOESalSectCd_tEdit.DataText = "";
            this.UOESalSectCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESalSectCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOESalSectCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOESalSectCd_tEdit.Location = new System.Drawing.Point(439, 92);
            this.UOESalSectCd_tEdit.MaxLength = 3;
            this.UOESalSectCd_tEdit.Name = "UOESalSectCd_tEdit";
            this.UOESalSectCd_tEdit.Size = new System.Drawing.Size(35, 24);
            this.UOESalSectCd_tEdit.TabIndex = 17;
            // 
            // UOESalSectNm_tEdit
            // 
            this.UOESalSectNm_tEdit.ActiveAppearance = appearance41;
            appearance74.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESalSectNm_tEdit.Appearance = appearance74;
            this.UOESalSectNm_tEdit.AutoSelect = true;
            this.UOESalSectNm_tEdit.DataText = "";
            this.UOESalSectNm_tEdit.Enabled = false;
            this.UOESalSectNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESalSectNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOESalSectNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOESalSectNm_tEdit.Location = new System.Drawing.Point(481, 92);
            this.UOESalSectNm_tEdit.MaxLength = 30;
            this.UOESalSectNm_tEdit.Name = "UOESalSectNm_tEdit";
            this.UOESalSectNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.UOESalSectNm_tEdit.TabIndex = 29;
            this.UOESalSectNm_tEdit.TabStop = false;
            // 
            // UOEReservSectCd_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEReservSectCd_tEdit.ActiveAppearance = appearance17;
            appearance54.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEReservSectCd_tEdit.Appearance = appearance54;
            this.UOEReservSectCd_tEdit.AutoSelect = true;
            this.UOEReservSectCd_tEdit.DataText = "";
            this.UOEReservSectCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEReservSectCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEReservSectCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEReservSectCd_tEdit.Location = new System.Drawing.Point(439, 122);
            this.UOEReservSectCd_tEdit.MaxLength = 3;
            this.UOEReservSectCd_tEdit.Name = "UOEReservSectCd_tEdit";
            this.UOEReservSectCd_tEdit.Size = new System.Drawing.Size(35, 24);
            this.UOEReservSectCd_tEdit.TabIndex = 19;
            // 
            // UOEReservSectNm_tEdit
            // 
            this.UOEReservSectNm_tEdit.ActiveAppearance = appearance21;
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEReservSectNm_tEdit.Appearance = appearance75;
            this.UOEReservSectNm_tEdit.AutoSelect = true;
            this.UOEReservSectNm_tEdit.DataText = "";
            this.UOEReservSectNm_tEdit.Enabled = false;
            this.UOEReservSectNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEReservSectNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEReservSectNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEReservSectNm_tEdit.Location = new System.Drawing.Point(481, 122);
            this.UOEReservSectNm_tEdit.MaxLength = 30;
            this.UOEReservSectNm_tEdit.Name = "UOEReservSectNm_tEdit";
            this.UOEReservSectNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.UOEReservSectNm_tEdit.TabIndex = 29;
            this.UOEReservSectNm_tEdit.TabStop = false;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.UOEOrderRate_Label);
            this.ultraGroupBox1.Controls.Add(this.BoCode_Label);
            this.ultraGroupBox1.Controls.Add(this.DeliveredGoodsDiv_Label);
            this.ultraGroupBox1.Controls.Add(this.EmployeeCode_Label);
            this.ultraGroupBox1.Controls.Add(this.uButton_EmployeeGuide);
            this.ultraGroupBox1.Controls.Add(this.UOEResvdSection_Label);
            this.ultraGroupBox1.Controls.Add(this.BusinessCode_Label);
            this.ultraGroupBox1.Controls.Add(this.BoCode_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.DeliveredGoodsDiv_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.UOEResvdSection_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.BusinessCode_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.tEdit_EmployeeCode);
            this.ultraGroupBox1.Controls.Add(this.UOEOrderRate_tEdit);
            this.ultraGroupBox1.Controls.Add(this.tEdit_EmployeeName);
            this.ultraGroupBox1.Location = new System.Drawing.Point(642, 62);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(296, 255);
            this.ultraGroupBox1.TabIndex = 27;
            this.ultraGroupBox1.Text = "�����l�ݒ荀��";
            // 
            // UOEOrderRate_Label
            // 
            appearance116.TextVAlignAsString = "Middle";
            this.UOEOrderRate_Label.Appearance = appearance116;
            this.UOEOrderRate_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEOrderRate_Label.Location = new System.Drawing.Point(6, 210);
            this.UOEOrderRate_Label.Name = "UOEOrderRate_Label";
            this.UOEOrderRate_Label.Size = new System.Drawing.Size(79, 23);
            this.UOEOrderRate_Label.TabIndex = 28;
            this.UOEOrderRate_Label.Text = "���[�g";
            // 
            // BoCode_Label
            // 
            appearance117.TextVAlignAsString = "Middle";
            this.BoCode_Label.Appearance = appearance117;
            this.BoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BoCode_Label.Location = new System.Drawing.Point(6, 180);
            this.BoCode_Label.Name = "BoCode_Label";
            this.BoCode_Label.Size = new System.Drawing.Size(79, 23);
            this.BoCode_Label.TabIndex = 28;
            this.BoCode_Label.Text = "�a�n�敪";
            // 
            // DeliveredGoodsDiv_Label
            // 
            appearance118.TextVAlignAsString = "Middle";
            this.DeliveredGoodsDiv_Label.Appearance = appearance118;
            this.DeliveredGoodsDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DeliveredGoodsDiv_Label.Location = new System.Drawing.Point(6, 150);
            this.DeliveredGoodsDiv_Label.Name = "DeliveredGoodsDiv_Label";
            this.DeliveredGoodsDiv_Label.Size = new System.Drawing.Size(79, 23);
            this.DeliveredGoodsDiv_Label.TabIndex = 28;
            this.DeliveredGoodsDiv_Label.Text = "�[�i�敪";
            // 
            // EmployeeCode_Label
            // 
            appearance119.TextVAlignAsString = "Middle";
            this.EmployeeCode_Label.Appearance = appearance119;
            this.EmployeeCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EmployeeCode_Label.Location = new System.Drawing.Point(6, 90);
            this.EmployeeCode_Label.Name = "EmployeeCode_Label";
            this.EmployeeCode_Label.Size = new System.Drawing.Size(79, 23);
            this.EmployeeCode_Label.TabIndex = 28;
            this.EmployeeCode_Label.Text = "�˗���";
            // 
            // uButton_EmployeeGuide
            // 
            appearance180.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance180.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EmployeeGuide.Appearance = appearance180;
            this.uButton_EmployeeGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EmployeeGuide.Location = new System.Drawing.Point(163, 90);
            this.uButton_EmployeeGuide.Name = "uButton_EmployeeGuide";
            this.uButton_EmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EmployeeGuide.TabIndex = 4;
            this.uButton_EmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EmployeeGuide.Click += new System.EventHandler(this.uButton_EmployeeGuide_Click);
            // 
            // UOEResvdSection_Label
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.UOEResvdSection_Label.Appearance = appearance43;
            this.UOEResvdSection_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEResvdSection_Label.Location = new System.Drawing.Point(6, 60);
            this.UOEResvdSection_Label.Name = "UOEResvdSection_Label";
            this.UOEResvdSection_Label.Size = new System.Drawing.Size(79, 23);
            this.UOEResvdSection_Label.TabIndex = 28;
            this.UOEResvdSection_Label.Text = "�w�苒�_";
            // 
            // BusinessCode_Label
            // 
            appearance121.TextVAlignAsString = "Middle";
            this.BusinessCode_Label.Appearance = appearance121;
            this.BusinessCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BusinessCode_Label.Location = new System.Drawing.Point(6, 30);
            this.BusinessCode_Label.Name = "BusinessCode_Label";
            this.BusinessCode_Label.Size = new System.Drawing.Size(79, 23);
            this.BusinessCode_Label.TabIndex = 28;
            this.BusinessCode_Label.Text = "�Ɩ��敪";
            // 
            // BoCode_tComboEditor
            // 
            appearance273.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance273.ForeColor = System.Drawing.Color.Black;
            appearance273.ForeColorDisabled = System.Drawing.Color.Black;
            this.BoCode_tComboEditor.ActiveAppearance = appearance273;
            appearance274.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance274.ForeColor = System.Drawing.Color.Black;
            appearance274.ForeColorDisabled = System.Drawing.Color.Black;
            this.BoCode_tComboEditor.Appearance = appearance274;
            this.BoCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BoCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance275.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BoCode_tComboEditor.ItemAppearance = appearance275;
            this.BoCode_tComboEditor.Location = new System.Drawing.Point(91, 180);
            this.BoCode_tComboEditor.MaxDropDownItems = 18;
            this.BoCode_tComboEditor.Name = "BoCode_tComboEditor";
            this.BoCode_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.BoCode_tComboEditor.TabIndex = 6;
            // 
            // DeliveredGoodsDiv_tComboEditor
            // 
            appearance165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance165.ForeColor = System.Drawing.Color.Black;
            appearance165.ForeColorDisabled = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv_tComboEditor.ActiveAppearance = appearance165;
            appearance166.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance166.ForeColor = System.Drawing.Color.Black;
            appearance166.ForeColorDisabled = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv_tComboEditor.Appearance = appearance166;
            this.DeliveredGoodsDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DeliveredGoodsDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance167.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DeliveredGoodsDiv_tComboEditor.ItemAppearance = appearance167;
            this.DeliveredGoodsDiv_tComboEditor.Location = new System.Drawing.Point(91, 150);
            this.DeliveredGoodsDiv_tComboEditor.MaxDropDownItems = 18;
            this.DeliveredGoodsDiv_tComboEditor.Name = "DeliveredGoodsDiv_tComboEditor";
            this.DeliveredGoodsDiv_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.DeliveredGoodsDiv_tComboEditor.TabIndex = 5;
            // 
            // UOEResvdSection_tComboEditor
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance73.ForeColor = System.Drawing.Color.Black;
            appearance73.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEResvdSection_tComboEditor.ActiveAppearance = appearance73;
            appearance178.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance178.ForeColor = System.Drawing.Color.Black;
            appearance178.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEResvdSection_tComboEditor.Appearance = appearance178;
            this.UOEResvdSection_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UOEResvdSection_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance179.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEResvdSection_tComboEditor.ItemAppearance = appearance179;
            this.UOEResvdSection_tComboEditor.Location = new System.Drawing.Point(91, 60);
            this.UOEResvdSection_tComboEditor.MaxDropDownItems = 18;
            this.UOEResvdSection_tComboEditor.Name = "UOEResvdSection_tComboEditor";
            this.UOEResvdSection_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.UOEResvdSection_tComboEditor.TabIndex = 2;
            // 
            // BusinessCode_tComboEditor
            // 
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance158.ForeColor = System.Drawing.Color.Black;
            appearance158.ForeColorDisabled = System.Drawing.Color.Black;
            this.BusinessCode_tComboEditor.ActiveAppearance = appearance158;
            appearance159.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance159.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance159.ForeColor = System.Drawing.Color.Black;
            appearance159.ForeColorDisabled = System.Drawing.Color.Black;
            this.BusinessCode_tComboEditor.Appearance = appearance159;
            this.BusinessCode_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BusinessCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BusinessCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BusinessCode_tComboEditor.ItemAppearance = appearance160;
            this.BusinessCode_tComboEditor.Location = new System.Drawing.Point(91, 30);
            this.BusinessCode_tComboEditor.MaxDropDownItems = 18;
            this.BusinessCode_tComboEditor.Name = "BusinessCode_tComboEditor";
            this.BusinessCode_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.BusinessCode_tComboEditor.TabIndex = 1;
            // 
            // tEdit_EmployeeCode
            // 
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance125.TextHAlignAsString = "Right";
            this.tEdit_EmployeeCode.ActiveAppearance = appearance125;
            appearance80.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_EmployeeCode.Appearance = appearance80;
            this.tEdit_EmployeeCode.AutoSelect = true;
            this.tEdit_EmployeeCode.DataText = "";
            this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_EmployeeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_EmployeeCode.Location = new System.Drawing.Point(91, 90);
            this.tEdit_EmployeeCode.MaxLength = 5;
            this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
            this.tEdit_EmployeeCode.Size = new System.Drawing.Size(66, 24);
            this.tEdit_EmployeeCode.TabIndex = 3;
            // 
            // UOEOrderRate_tEdit
            // 
            appearance171.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEOrderRate_tEdit.ActiveAppearance = appearance171;
            appearance172.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance172.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEOrderRate_tEdit.Appearance = appearance172;
            this.UOEOrderRate_tEdit.AutoSelect = true;
            this.UOEOrderRate_tEdit.DataText = "L1000";
            this.UOEOrderRate_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEOrderRate_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEOrderRate_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEOrderRate_tEdit.Location = new System.Drawing.Point(91, 210);
            this.UOEOrderRate_tEdit.MaxLength = 5;
            this.UOEOrderRate_tEdit.Name = "UOEOrderRate_tEdit";
            this.UOEOrderRate_tEdit.Size = new System.Drawing.Size(66, 24);
            this.UOEOrderRate_tEdit.TabIndex = 7;
            this.UOEOrderRate_tEdit.Text = "L1000";
            // 
            // tEdit_EmployeeName
            // 
            this.tEdit_EmployeeName.ActiveAppearance = appearance129;
            appearance152.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance152.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_EmployeeName.Appearance = appearance152;
            this.tEdit_EmployeeName.AutoSelect = true;
            this.tEdit_EmployeeName.DataText = "";
            this.tEdit_EmployeeName.Enabled = false;
            this.tEdit_EmployeeName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_EmployeeName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_EmployeeName.Location = new System.Drawing.Point(91, 120);
            this.tEdit_EmployeeName.MaxLength = 30;
            this.tEdit_EmployeeName.Name = "tEdit_EmployeeName";
            this.tEdit_EmployeeName.Size = new System.Drawing.Size(159, 24);
            this.tEdit_EmployeeName.TabIndex = 29;
            this.tEdit_EmployeeName.TabStop = false;
            // 
            // ReceiveCondition_tComboEditor
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.ForeColor = System.Drawing.Color.Black;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            this.ReceiveCondition_tComboEditor.ActiveAppearance = appearance56;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance57.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.ForeColorDisabled = System.Drawing.Color.Black;
            this.ReceiveCondition_tComboEditor.Appearance = appearance57;
            this.ReceiveCondition_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ReceiveCondition_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ReceiveCondition_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ReceiveCondition_tComboEditor.ItemAppearance = appearance58;
            this.ReceiveCondition_tComboEditor.Location = new System.Drawing.Point(438, 152);
            this.ReceiveCondition_tComboEditor.MaxDropDownItems = 18;
            this.ReceiveCondition_tComboEditor.Name = "ReceiveCondition_tComboEditor";
            this.ReceiveCondition_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.ReceiveCondition_tComboEditor.TabIndex = 21;
            // 
            // SubstPartsNoDiv_tComboEditor
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.SubstPartsNoDiv_tComboEditor.ActiveAppearance = appearance59;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance60.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.ForeColorDisabled = System.Drawing.Color.Black;
            this.SubstPartsNoDiv_tComboEditor.Appearance = appearance60;
            this.SubstPartsNoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SubstPartsNoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SubstPartsNoDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SubstPartsNoDiv_tComboEditor.ItemAppearance = appearance61;
            this.SubstPartsNoDiv_tComboEditor.Location = new System.Drawing.Point(439, 182);
            this.SubstPartsNoDiv_tComboEditor.MaxDropDownItems = 18;
            this.SubstPartsNoDiv_tComboEditor.Name = "SubstPartsNoDiv_tComboEditor";
            this.SubstPartsNoDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.SubstPartsNoDiv_tComboEditor.TabIndex = 22;
            // 
            // PartsNoPrtCd_tComboEditor
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance62.ForeColor = System.Drawing.Color.Black;
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsNoPrtCd_tComboEditor.ActiveAppearance = appearance62;
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsNoPrtCd_tComboEditor.Appearance = appearance63;
            this.PartsNoPrtCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PartsNoPrtCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsNoPrtCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsNoPrtCd_tComboEditor.ItemAppearance = appearance64;
            this.PartsNoPrtCd_tComboEditor.Location = new System.Drawing.Point(439, 212);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsNoPrtCd_tComboEditor.Name = "PartsNoPrtCd_tComboEditor";
            this.PartsNoPrtCd_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.PartsNoPrtCd_tComboEditor.TabIndex = 23;
            // 
            // ListPriceUseDiv_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.ListPriceUseDiv_tComboEditor.ActiveAppearance = appearance65;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            this.ListPriceUseDiv_tComboEditor.Appearance = appearance66;
            this.ListPriceUseDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ListPriceUseDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ListPriceUseDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPriceUseDiv_tComboEditor.ItemAppearance = appearance67;
            this.ListPriceUseDiv_tComboEditor.Location = new System.Drawing.Point(439, 242);
            this.ListPriceUseDiv_tComboEditor.MaxDropDownItems = 18;
            this.ListPriceUseDiv_tComboEditor.Name = "ListPriceUseDiv_tComboEditor";
            this.ListPriceUseDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.ListPriceUseDiv_tComboEditor.TabIndex = 24;
            // 
            // StockSlipDtRecvDiv_tComboEditor
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance68.ForeColor = System.Drawing.Color.Black;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockSlipDtRecvDiv_tComboEditor.ActiveAppearance = appearance68;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance69.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockSlipDtRecvDiv_tComboEditor.Appearance = appearance69;
            this.StockSlipDtRecvDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.StockSlipDtRecvDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StockSlipDtRecvDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockSlipDtRecvDiv_tComboEditor.ItemAppearance = appearance70;
            this.StockSlipDtRecvDiv_tComboEditor.Location = new System.Drawing.Point(439, 272);
            this.StockSlipDtRecvDiv_tComboEditor.MaxDropDownItems = 18;
            this.StockSlipDtRecvDiv_tComboEditor.Name = "StockSlipDtRecvDiv_tComboEditor";
            this.StockSlipDtRecvDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.StockSlipDtRecvDiv_tComboEditor.TabIndex = 25;
            // 
            // CheckCodeDiv_tComboEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.CheckCodeDiv_tComboEditor.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.CheckCodeDiv_tComboEditor.Appearance = appearance24;
            this.CheckCodeDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CheckCodeDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CheckCodeDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CheckCodeDiv_tComboEditor.ItemAppearance = appearance25;
            this.CheckCodeDiv_tComboEditor.Location = new System.Drawing.Point(439, 302);
            this.CheckCodeDiv_tComboEditor.MaxDropDownItems = 18;
            this.CheckCodeDiv_tComboEditor.Name = "CheckCodeDiv_tComboEditor";
            this.CheckCodeDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.CheckCodeDiv_tComboEditor.TabIndex = 26;
            // 
            // ultraLabel26
            // 
            this.ultraLabel26.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel26.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel26.Location = new System.Drawing.Point(10, 392);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(940, 4);
            this.ultraLabel26.TabIndex = 30;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(825, 635);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 60;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(694, 635);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 58;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(566, 635);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 57;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(694, 635);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 59;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraLabel33
            // 
            this.ultraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel33.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel33.Location = new System.Drawing.Point(12, 625);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(940, 4);
            this.ultraLabel33.TabIndex = 30;
            // 
            // uButton_UOESupplierGuide
            // 
            appearance149.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance149.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOESupplierGuide.Appearance = appearance149;
            this.uButton_UOESupplierGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOESupplierGuide.Location = new System.Drawing.Point(619, 22);
            this.uButton_UOESupplierGuide.Name = "uButton_UOESupplierGuide";
            this.uButton_UOESupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOESupplierGuide.TabIndex = 2;
            this.uButton_UOESupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOESupplierGuide.Click += new System.EventHandler(this.uButton_UOESupplierGuide_Click);
            // 
            // uButton_UOEShipSectGuide
            // 
            appearance150.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance150.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOEShipSectGuide.Appearance = appearance150;
            this.uButton_UOEShipSectGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOEShipSectGuide.Location = new System.Drawing.Point(600, 62);
            this.uButton_UOEShipSectGuide.Name = "uButton_UOEShipSectGuide";
            this.uButton_UOEShipSectGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOEShipSectGuide.TabIndex = 16;
            this.uButton_UOEShipSectGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOEShipSectGuide.Click += new System.EventHandler(this.uButton_UOEShipSectGuide_Click);
            // 
            // uButton_UOESalSectGuide
            // 
            appearance151.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance151.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOESalSectGuide.Appearance = appearance151;
            this.uButton_UOESalSectGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOESalSectGuide.Location = new System.Drawing.Point(600, 92);
            this.uButton_UOESalSectGuide.Name = "uButton_UOESalSectGuide";
            this.uButton_UOESalSectGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOESalSectGuide.TabIndex = 18;
            this.uButton_UOESalSectGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOESalSectGuide.Click += new System.EventHandler(this.uButton_UOESalSectGuide_Click);
            // 
            // uButton_UOEReservSectGuide
            // 
            appearance173.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance173.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOEReservSectGuide.Appearance = appearance173;
            this.uButton_UOEReservSectGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOEReservSectGuide.Location = new System.Drawing.Point(600, 122);
            this.uButton_UOEReservSectGuide.Name = "uButton_UOEReservSectGuide";
            this.uButton_UOEReservSectGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOEReservSectGuide.TabIndex = 20;
            this.uButton_UOEReservSectGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOEReservSectGuide.Click += new System.EventHandler(this.uButton_UOEReservSectGuide_Click);
            // 
            // uButton_MakerGuide
            // 
            appearance157.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance157.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_MakerGuide.Appearance = appearance157;
            this.uButton_MakerGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MakerGuide.Location = new System.Drawing.Point(190, 62);
            this.uButton_MakerGuide.Name = "uButton_MakerGuide";
            this.uButton_MakerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_MakerGuide.TabIndex = 4;
            this.uButton_MakerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MakerGuide.Click += new System.EventHandler(this.uButton_MakerGuide_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // SupplierCd_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SupplierCd_Label.Appearance = appearance30;
            this.SupplierCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SupplierCd_Label.Location = new System.Drawing.Point(12, 122);
            this.SupplierCd_Label.Name = "SupplierCd_Label";
            this.SupplierCd_Label.Size = new System.Drawing.Size(123, 23);
            this.SupplierCd_Label.TabIndex = 61;
            this.SupplierCd_Label.Text = "�d����R�[�h";
            // 
            // tNedit_SupplierCd
            // 
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance112.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.ActiveAppearance = appearance112;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_SupplierCd.Appearance = appearance32;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(141, 122);
            this.tNedit_SupplierCd.MaxLength = 9;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd.TabIndex = 5;
            // 
            // uButton_SupplierGuide
            // 
            appearance141.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance141.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SupplierGuide.Appearance = appearance141;
            this.uButton_SupplierGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SupplierGuide.Location = new System.Drawing.Point(206, 122);
            this.uButton_SupplierGuide.Name = "uButton_SupplierGuide";
            this.uButton_SupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SupplierGuide.TabIndex = 6;
            this.uButton_SupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SupplierGuide.Click += new System.EventHandler(this.ultraButton_SupplierGuide_Click);
            // 
            // SupplierNm_tEdit
            // 
            this.SupplierNm_tEdit.ActiveAppearance = appearance110;
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.SupplierNm_tEdit.Appearance = appearance15;
            this.SupplierNm_tEdit.AutoSelect = true;
            this.SupplierNm_tEdit.DataText = "";
            this.SupplierNm_tEdit.Enabled = false;
            this.SupplierNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SupplierNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SupplierNm_tEdit.Location = new System.Drawing.Point(141, 152);
            this.SupplierNm_tEdit.MaxLength = 30;
            this.SupplierNm_tEdit.Name = "SupplierNm_tEdit";
            this.SupplierNm_tEdit.Size = new System.Drawing.Size(159, 24);
            this.SupplierNm_tEdit.TabIndex = 7;
            this.SupplierNm_tEdit.TabStop = false;
            // 
            // Maker_ultraTabControl
            // 
            this.Maker_ultraTabControl.Location = new System.Drawing.Point(0, 0);
            this.Maker_ultraTabControl.Name = "Maker_ultraTabControl";
            this.Maker_ultraTabControl.SharedControlsPage = null;
            this.Maker_ultraTabControl.Size = new System.Drawing.Size(200, 100);
            this.Maker_ultraTabControl.TabIndex = 0;
            // 
            // Mazda_AnswerAutoDiv_ultraLabel
            // 
            appearance194.BackColor = System.Drawing.Color.White;
            appearance194.BackColor2 = System.Drawing.Color.LightPink;
            appearance194.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Mazda_AnswerAutoDiv_ultraLabel.ActiveTabAppearance = appearance194;
            appearance195.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.Mazda_AnswerAutoDiv_ultraLabel.Appearance = appearance195;
            appearance197.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Mazda_AnswerAutoDiv_ultraLabel.ClientAreaAppearance = appearance197;
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl1);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl2);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl3);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl4);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl5);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl6);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl7);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl8);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl9);
            this.Mazda_AnswerAutoDiv_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mazda_AnswerAutoDiv_ultraLabel.Location = new System.Drawing.Point(10, 402);
            this.Mazda_AnswerAutoDiv_ultraLabel.Name = "Mazda_AnswerAutoDiv_ultraLabel";
            this.Mazda_AnswerAutoDiv_ultraLabel.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Mazda_AnswerAutoDiv_ultraLabel.Size = new System.Drawing.Size(940, 217);
            this.Mazda_AnswerAutoDiv_ultraLabel.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Mazda_AnswerAutoDiv_ultraLabel.TabIndex = 28;
            this.Mazda_AnswerAutoDiv_ultraLabel.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowFixed;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "�����\���[�J�[";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "�O�H���ځE�V�}�c�_���ځE�z���_����";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "�z���_e-Parts����";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "�g���^�d�q�J�^���O�A������";
            ultraTab5.TabPage = this.ultraTabPageControl5;
            ultraTab5.Text = "���YWeb-UOE�A������";
            ultraTab6.TabPage = this.ultraTabPageControl6;
            ultraTab6.Text = "�O�HWebUOE�A������";
            ultraTab7.TabPage = this.ultraTabPageControl7;
            ultraTab7.Text = "����UOEWeb����";
            ultraTab8.TabPage = this.ultraTabPageControl8;
            ultraTab8.Text = "�}�c�_WEB-UOE�A������";
            ultraTab9.TabPage = this.ultraTabPageControl9;
            ultraTab9.Text = "��NET-WEB����";
            this.Mazda_AnswerAutoDiv_ultraLabel.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4,
            ultraTab5,
            ultraTab6,
            ultraTab7,
            ultraTab8,
            ultraTab9});
            this.Mazda_AnswerAutoDiv_ultraLabel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Mazda_AnswerAutoDiv_ultraLabel.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(938, 195);
            // 
            // PMUOE09020UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(962, 698);
            this.Controls.Add(this.Mazda_AnswerAutoDiv_ultraLabel);
            this.Controls.Add(this.SupplierNm_tEdit);
            this.Controls.Add(this.uButton_SupplierGuide);
            this.Controls.Add(this.tNedit_SupplierCd);
            this.Controls.Add(this.SupplierCd_Label);
            this.Controls.Add(this.uButton_UOEReservSectGuide);
            this.Controls.Add(this.uButton_UOESalSectGuide);
            this.Controls.Add(this.uButton_MakerGuide);
            this.Controls.Add(this.uButton_UOEShipSectGuide);
            this.Controls.Add(this.uButton_UOESupplierGuide);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.CheckCodeDiv_tComboEditor);
            this.Controls.Add(this.StockSlipDtRecvDiv_tComboEditor);
            this.Controls.Add(this.ListPriceUseDiv_tComboEditor);
            this.Controls.Add(this.PartsNoPrtCd_tComboEditor);
            this.Controls.Add(this.SubstPartsNoDiv_tComboEditor);
            this.Controls.Add(this.ReceiveCondition_tComboEditor);
            this.Controls.Add(this.ConnectVersionDiv_tComboEditor);
            this.Controls.Add(this.tNedit_GoodsMakerCdAllowZero);
            this.Controls.Add(this.UOESupplierCd_tNedit);
            this.Controls.Add(this.ultraLabel33);
            this.Controls.Add(this.ultraLabel26);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.UOESupplierName_tEdit);
            this.Controls.Add(this.GoodsMakerNm_tEdit);
            this.Controls.Add(this.UOEConnectUserId_tEdit);
            this.Controls.Add(this.UOEReservSectCd_tEdit);
            this.Controls.Add(this.UOESalSectCd_tEdit);
            this.Controls.Add(this.UOEShipSectCd_tEdit);
            this.Controls.Add(this.CommAssemblyId_tEdit);
            this.Controls.Add(this.UOEConnectPassword_tEdit);
            this.Controls.Add(this.UOEHostCode_tEdit);
            this.Controls.Add(this.UOEReservSectNm_tEdit);
            this.Controls.Add(this.UOESalSectNm_tEdit);
            this.Controls.Add(this.UOEShipSectNm_tEdit);
            this.Controls.Add(this.UOETerminalCd_tEdit);
            this.Controls.Add(this.UOEIDNum_tEdit);
            this.Controls.Add(this.TelNo_tEdit);
            this.Controls.Add(this.ConnectVersionDiv_Label);
            this.Controls.Add(this.CommAssemblyId_Label);
            this.Controls.Add(this.UOEIDNum_Label);
            this.Controls.Add(this.UOEConnectUserId_Label);
            this.Controls.Add(this.UOEConnectPassword_Label);
            this.Controls.Add(this.UOEHostCode_Label);
            this.Controls.Add(this.UOETerminalCd_Label);
            this.Controls.Add(this.CheckCodeDiv_Label);
            this.Controls.Add(this.StockSlipDtRecvDiv_Label);
            this.Controls.Add(this.ListPriceUseDiv_Label);
            this.Controls.Add(this.PartsNoPrtCd_Label);
            this.Controls.Add(this.SubstPartsNoDiv_Label);
            this.Controls.Add(this.ReceiveCondition_Label);
            this.Controls.Add(this.UOEReservSectCd_Label);
            this.Controls.Add(this.UOESalSectCd_Label);
            this.Controls.Add(this.UOEShipSectCd_Label);
            this.Controls.Add(this.TelNo_Label);
            this.Controls.Add(this.GoodsMakerCd_Label);
            this.Controls.Add(this.UOESupplierCd_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOE������}�X�^�ݒ�";
            this.Load += new System.EventHandler(this.PMUOE09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMUOE09020UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMUOE09020UA_Closing);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd6_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd5_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd4_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd3_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd2_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd1_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd6_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd5_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd4_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm1_tEdit)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HondaSectionCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEItemCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETestMode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaSectionCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ultraGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmergencyDiv_tComboEditor)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsPassWord_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsUserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEePartsItemCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTimeoutVal_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InqOrdDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEForcedTermUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEStockCheckUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOELoginUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebConnectCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebUserID_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebPassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerAutoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolderOfTOYOTA_tEdit)).EndInit();
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MazdaSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nissan_AnswerAutoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NissanAnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl6.ResumeLayout(false);
            this.ultraTabPageControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MitsubishiAnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl7.ResumeLayout(false);
            this.ultraTabPageControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeSystemUseType_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoePassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeTerminalID_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeCoCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeJigyousyoCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoFlag_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoCode_tEdit)).EndInit();
            this.ultraTabPageControl8.ResumeLayout(false);
            this.ultraTabPageControl8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HondaSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaAnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl9.ResumeLayout(false);
            this.ultraTabPageControl9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLMngUserCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOut_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestoreAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Domain_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Connection_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Protocol_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCdAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETerminalCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEHostCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectPassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectUserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEIDNum_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectVersionDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEResvdSection_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderRate_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveCondition_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubstPartsNoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceUseDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipDtRecvDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCodeDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_ultraTabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mazda_AnswerAutoDiv_ultraLabel)).EndInit();
            this.Mazda_AnswerAutoDiv_ultraLabel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region << Private Members >>

        private UOESupplierAcs _uoeSupplierAcs;                         // UOE������}�X�^�e�[�u���A�N�Z�X�N���X

        // 2008.11.05 30413 �A�N�Z�X�N���X�̒ǉ� >>>>>>START
        private EmployeeAcs _employeeAcs;
        private MakerAcs _makerAcs;
        private SupplierAcs _supplierInfoAcs;
        private UOEGuideNameAcs _uoeGuideNameAcs;
        // 2008.11.05 30413 �A�N�Z�X�N���X�̒ǉ� <<<<<<END

        private string _enterpriseCode;                                 // ��ƃR�[�h
        private string _sectionCode;

        // ��r�p�N���[��
        private UOESupplier _uoeSupplierClone;

        private int _totalCount;
        private Hashtable _uoeSupplierTable;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        
        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        // ---ADD 2011/10/26 ------------->>>>>
        //��NET-WEB����
        private PMUOE09020UB _pmuoe09020ub = null;
        // ---ADD 2011/10/26 -------------<<<<<
        # endregion

        # region ��Consts

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string UOESUPPLIERCD_TITLE = "������R�[�h";
        private const string UOESUPPLIERNAME_TITLE = "�����於��";
        private const string GOODSMAKERCD_TITLE = "���[�J�[�R�[�h";
        private const string GOODSMAKERNM_TITLE = "���[�J�[����";
        private const string SUPPLIERCD_TITLE = "�d����R�[�h";
        private const string SUPPLIERNM_TITLE = "�d���於��";
        private const string TELNO_TITLE = "�d�b�ԍ�";
        private const string UOETERMINALCD_TITLE = "�[���R�[�h";
        private const string UOEHOSTCODE_TITLE = "�z�X�g�R�[�h";
        private const string UOECONNECTPASSWORD_TITLE = "�p�X���[�h";
        private const string UOECONNECTUSERID_TITLE = "���[�U�[�R�[�h";
        private const string UOEIDNUM_TITLE = "�h�c�ԍ�";
        private const string COMMASSEMBLYID_TITLE = "�v���O����";
        private const string CONNECTVERSIONDIV_TITLE = "Ver";
        private const string UOESHIPSECTCD_TITLE = "�o�ɋ��_�R�[�h";
        private const string UOESHIPSECTNM_TITLE = "�o�ɋ��_����";
        private const string UOESALSECTCD_TITLE = "���㋒�_�R�[�h";
        private const string UOESALSECTNM_TITLE = "���㋒�_����";
        private const string UOERESERVSECTCD_TITLE = "�w�苒�_�R�[�h";
        private const string UOERESERVSECTNM_TITLE = "�w�苒�_����";
        private const string RECEIVECONDITION_TITLE = "��M�L���敪";
        private const string SUBSTPARTSNODIV_TITLE = "��֕i�ԋ敪";
        private const string PARTSNOPRTCD_TITLE = "�i�Ԉ���敪";
        private const string LISTPRICEUSEDIV_TITLE = "�艿�g�p�敪";
        private const string STOCKSLIPDTRECVDIV_TITLE = "�d����M�敪";
        private const string CHECKCODEDIV_TITLE = "�`�F�b�N�敪";
        private const string BUSINESSCODE_TITLE = "�Ɩ��敪";
        private const string UOERESVDSECTION_TITLE = "�w�苒�_";
        private const string EMPLOYEECODE_TITLE = "�˗���";
        private const string EMPLOYEENAME_TITLE = "�˗��Җ�";
        private const string DELIVEREDGOODSDIV_TITLE = "�[�i�敪";
        private const string BOCODE_TITLE = "�a�n�敪";
        private const string UOEORDERRATE_TITLE = "���[�g";
        private const string INSTRUMENTNO_TITLE = "���@";
        private const string UOETESTMODE_TITLE = "�e�X�g���[�h";
        private const string UOEITEMCD_TITLE = "�A�C�e��";
        private const string HONDASECTIONCODE_TITLE = "�S�����_";
        private const string ANSWERSAVEFOLDER_TITLE = "�񓚕ۑ��t�H���_";
        private const string MAZDASECTIONCODE_TITLE = "�����_";
        private const string EMERGENCYDIV_TITLE = "�ً}�敪";
        private const string ENABLEODRMAKERCD1_TITLE = "�����\���[�J�[�R�[�h�P";
        private const string ENABLEODRMAKERNM1_TITLE = "�����\���[�J�[���̂P";
        private const string ENABLEODRMAKERCD2_TITLE = "�����\���[�J�[�R�[�h�Q";
        private const string ENABLEODRMAKERNM2_TITLE = "�����\���[�J�[���̂Q";
        private const string ENABLEODRMAKERCD3_TITLE = "�����\���[�J�[�R�[�h�R";
        private const string ENABLEODRMAKERNM3_TITLE = "�����\���[�J�[���̂R";
        private const string ENABLEODRMAKERCD4_TITLE = "�����\���[�J�[�R�[�h�S";
        private const string ENABLEODRMAKERNM4_TITLE = "�����\���[�J�[���̂S";
        private const string ENABLEODRMAKERCD5_TITLE = "�����\���[�J�[�R�[�h�T";
        private const string ENABLEODRMAKERNM5_TITLE = "�����\���[�J�[���̂T";
        private const string ENABLEODRMAKERCD6_TITLE = "�����\���[�J�[�R�[�h�U";
        private const string ENABLEODRMAKERNM6_TITLE = "�����\���[�J�[���̂U";
        // ---ADD 2009/06/01 ------------------------------------------->>>>>
        private const string UOELOGINURL_TITLE = "�t�n�d���O�C���t�q�k";
        private const string UOEORDERURL_TITLE = "�t�n�d�����t�q�k";
        private const string UOESTOCKCHECKURL_TITLE = "�t�n�d�݌Ɋm�F�t�q�k";
        private const string UOEFORCEDTERMURL_TITLE = "�t�n�d�����I���t�q�k";
        private const string INQORDDIVCD_TITLE = "�⍇���E�������";
        private const string LOGINTIMEOUTVAL_TITLE = "���O�C���^�C���A�E�g";
        private const string EPARTSUSERID_TITLE = "���|�o�����������[�U�h�c";
        private const string EPARTSPASSWORD_TITLE = "���|�o���������p�X���[�h";
        // ---ADD 2009/06/01 -------------------------------------------<<<<<
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        private const string BLMNGUSERCODE_TITLE = "BL�Ǘ����[�U�[�R�[�h";
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

        private const string GUID_TITLE = "GUID";
        private const string UOE_SUPPLIER_TABLE = "UOESUPPLIER";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string REFERENCE_MODE = "�Q�ƃ��[�h";

        // ���[�J�[����
        private const string MAKER_CODE_ZERO = "����";

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMUOE09020U";
        private const string PG_NM = "UOE������}�X�^";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        // ---ADD 2010/03/08 ------------------------------------------->>>>>
        // �ʐM�A�Z���u��ID 
        private const string NISSAN_COMMASSEMBLY_ID = "0203";
        // ---ADD 2010/03/08 -------------------------------------------<<<<<
		// ---ADD 2010/04/23 ------------------------------------------->>>>>
		// �ʐM�A�Z���u��ID 
		private const string MITSUBISHI_COMMASSEMBLY_ID = "0302";
		// ---ADD 2010/04/23 -------------------------------------------<<<<<

        // ---ADD 2010/12/31 ------------------------------------------->>>>>
        // �ʐM�A�Z���u��ID 
        private const string AUTONISSAN_COMMASSEMBLY_ID = "0204";
        // �ʐM�A�Z���u��ID 
        private const string AUTOMITSUBISHI_COMMASSEMBLY_ID = "0303";
        // ---ADD 2010/12/31 -------------------------------------------<<<<<
        // ---ADD 2011/03/01 ------------------------------------------->>>>>
        private const string AUTONISSAN_COMMASSEMBLY_ID_0205 = "0205";
        private const string AUTONISSAN_COMMASSEMBLY_ID_0206 = "0206";
        // ---ADD 2011/03/01 -------------------------------------------<<<<<
        // ---ADD 2011/05/10 ------------------------------------------->>>>>
        // �ʐM�A�Z���u��ID 
        private const string MAZDA_COMMASSEMBLY_ID = "0403";
        // ---ADD 2011/05/10 -------------------------------------------<<<<<
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
        private const string MEKA_KUBUN_NASI = "�n�C�t������";
        private const string MEKA_KUBUN_ARI = "�n�C�t���L��";
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
        #endregion

        # region ��Constructor
		/// <summary>
        /// UOE������}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : UOE������}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.06.26</br>
        /// <br>UpdateNote : 2010/03/08 �k���r ���YWeb-UOE�A�����ڂ̑Ή�</br>
		/// <br>UpdateNote : 2010/04/23 jiangk �O�HWeb-UOE�A�����ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/05/10 �{�z�� �񓚕ۑ��t�H���_�i�}�c�_WebUOE�p�A�g�t�@�C���̊i�[�ꏊ�j�̒ǉ�</br>
		/// </remarks>
        public PMUOE09020UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// �f�t�H���g:true�Œ�
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            // �K�C�h�{�^���̉摜�C���[�W�ǉ�
            this.uButton_UOESupplierGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_MakerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_UOEShipSectGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_UOESalSectGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_UOEReservSectGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker1Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker2Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker3Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker4Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker5Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker6Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EmployeeGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2009/06/01 ------------------------------------------------>>>>>
            this.uButton_AnswerSaveFolder.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2009/06/01 ------------------------------------------------<<<<<
            // ---------------------------- ADD 2009/12/29 xuxh ----------------->>>>>
            this.uButton_AnswerSaveFolderOfTOYOTA.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---------------------------- ADD 2009/12/29 xuxh -----------------<<<<<
            // ---ADD 2010/03/08 ------------------------------------------------>>>>>
            this.uButton_NissanAnswerSaveFolder.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2010/03/08 ------------------------------------------------<<<<<
			// ---ADD 2010/04/23 ------------------------------------------------>>>>>
			this.uButton_MitsubishiAnswerSaveFolder.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			// ---ADD 2010/04/23 ------------------------------------------------<<<<<
            // ---ADD 2011/05/10 ------------------------------------------------>>>>>
            this.uButton_MazdaAnswerSaveFolder.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2011/05/10 ------------------------------------------------<<<<<

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			// �ϐ�������
			this._dataIndex = -1;

            this._uoeSupplierAcs = new UOESupplierAcs();
            
            // 2008.11.05 30413 ���� �A�N�Z�X�N���X�̒ǉ� >>>>>>START
            this._employeeAcs = new EmployeeAcs();
            this._makerAcs = new MakerAcs();
            this._supplierInfoAcs = new SupplierAcs();
            this._uoeGuideNameAcs = new UOEGuideNameAcs();
            // 2008.11.05 30413 ���� �A�N�Z�X�N���X�̒ǉ� <<<<<<END

            this._totalCount = 0;
            this._uoeSupplierTable = new Hashtable();

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;
		}

		# endregion

        # region ��Dispose
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
        # endregion

        # region ��Main
        /// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09020UA());
        }
        # endregion

        # region ��Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region ��Properties
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        # endregion

        # region ��Public Methods
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = UOE_SUPPLIER_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList uoeSupplierList = null;


            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._uoeSupplierAcs.SearchAll(out uoeSupplierList, this._enterpriseCode, this._sectionCode);

                this._totalCount = uoeSupplierList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (UOESupplier wkUOESupplier in uoeSupplierList)
                        {
                            UOESupplierToDataSet(wkUOESupplier.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:      // ��������0��
                    {
                        // ��������0���́A�X�e�[�^�X���m�[�}���ŕԂ�
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Search",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._uoeSupplierAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;
            
            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;
            string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
            UOESupplier uoeSupplier = ((UOESupplier)this._uoeSupplierTable[guid]).Clone();

            status = this._uoeSupplierAcs.LogicalDelete(ref uoeSupplier);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeSupplierAcs);
                        return status;
                    }

                case -2:
                    {
                        //���Ɛݒ�Ŏg�p��
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }

                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._uoeSupplierAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            UOESupplierToDataSet(uoeSupplier.Clone(), this._dataIndex);
            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(UOESUPPLIERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(UOESUPPLIERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SUPPLIERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(SUPPLIERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(TELNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOETERMINALCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEHOSTCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOECONNECTPASSWORD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOECONNECTUSERID_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEIDNUM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(COMMASSEMBLYID_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CONNECTVERSIONDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESHIPSECTCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESHIPSECTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESALSECTCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESALSECTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOERESERVSECTCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOERESERVSECTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(RECEIVECONDITION_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SUBSTPARTSNODIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(PARTSNOPRTCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(LISTPRICEUSEDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(STOCKSLIPDTRECVDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CHECKCODEDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(BUSINESSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOERESVDSECTION_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMPLOYEECODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMPLOYEENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
            //appearanceTable.Add(DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            appearanceTable.Add(BOCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEORDERRATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(INSTRUMENTNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOETESTMODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEITEMCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(HONDASECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ANSWERSAVEFOLDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(MAZDASECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMERGENCYDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD1_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD2_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD3_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD4_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD5_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD6_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---ADD 2009/06/01 ----------------------------------------------------------------------->>>>>
            appearanceTable.Add(UOELOGINURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEORDERURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESTOCKCHECKURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEFORCEDTERMURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(INQORDDIVCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(LOGINTIMEOUTVAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(EPARTSUSERID_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EPARTSPASSWORD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---ADD 2009/06/01 -----------------------------------------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            appearanceTable.Add(BLMNGUSERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            return appearanceTable;
        }
        # endregion

        # region ��Private Methods
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
        /// <summary>
        /// �n�C�t���̃Z�b�g����
        /// </summary>
        /// <param name="combo">TComboEditor �I�u�W�F�N�g</param>
        /// <param name="flag">�n�C�t�����邩�ǂ����t���O</param>
        /// <remarks>
        /// <br>Note       : �n�C�t���̃Z�b�g����</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/12/15</br>
        private void mekaKubenSet(TComboEditor combo, bool flag)
        {
            if (flag)
            {
                combo.Enabled = true;
                combo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
                if (combo.Items.Count == 0)
                {
                    combo.Items.Add(0, MEKA_KUBUN_NASI);
                    combo.Items.Add(1, MEKA_KUBUN_ARI);
                    combo.SelectedIndex = 0;
                }
            }
            else
            {
                combo.Enabled = false;
                combo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
                combo.Items.Clear();
            }
        }
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
        /// <summary>
        /// UOE������}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="uoeSupplier">UOE������}�X�^ �I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UPDATE Note: 2009/12/29 xuxh �񓚕ۑ��t�H���_�i�g���^�d�q�J�^���O�p�������M�f�[�^�̊i�[�ꏊ�j��ǉ�����B</br>
        /// <br>Update Note: 2010/01/19 杍^ Redmine#2505�̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/07/27 ��� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/01/28 �{�w�C�� �񓚎����捞�敪�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/01 liyp �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/10/26 ������ PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// </remarks>
        private void UOESupplierToDataSet(UOESupplier uoeSupplier, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].NewRow();
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Count - 1;
            }

            if (uoeSupplier.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELETE_DATE] = uoeSupplier.UpdateDateTimeJpInFormal;
            }

            // ������R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESUPPLIERCD_TITLE] = uoeSupplier.UOESupplierCd.ToString("d06");
            // �����於��
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESUPPLIERNAME_TITLE] = uoeSupplier.UOESupplierName;
            // ���[�J�[�R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GOODSMAKERCD_TITLE] = uoeSupplier.GoodsMakerCd;
            // ���[�J�[����
            if (uoeSupplier.GoodsMakerCd == 0)
            {
                // ����
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GOODSMAKERNM_TITLE] = MAKER_CODE_ZERO;
            }
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GOODSMAKERNM_TITLE] = GetMakerName(uoeSupplier.GoodsMakerCd);
            }
            // �d����R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUPPLIERCD_TITLE] = uoeSupplier.SupplierCd;
            // �d���於��
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUPPLIERNM_TITLE] = GetSupplierName(uoeSupplier.SupplierCd);
            // �d�b�ԍ�
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][TELNO_TITLE] = uoeSupplier.TelNo;
            // �[���R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOETERMINALCD_TITLE] = uoeSupplier.UOETerminalCd;
            // �z�X�g�R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEHOSTCODE_TITLE] = uoeSupplier.UOEHostCode;
            // �p�X���[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOECONNECTPASSWORD_TITLE] = uoeSupplier.UOEConnectPassword;
            // ���[�U�[�R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOECONNECTUSERID_TITLE] = uoeSupplier.UOEConnectUserId;
            // �h�c�ԍ�
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEIDNUM_TITLE] = uoeSupplier.UOEIDNum;
            // �v���O����
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][COMMASSEMBLYID_TITLE] = uoeSupplier.CommAssemblyId;
            // Ver
            switch (uoeSupplier.ConnectVersionDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CONNECTVERSIONDIV_TITLE] = "��";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CONNECTVERSIONDIV_TITLE] = "�V";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CONNECTVERSIONDIV_TITLE] = "";
                        break;
                    }
            }
            // �o�ɋ��_�R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESHIPSECTCD_TITLE] = uoeSupplier.UOEShipSectCd;
            // �o�ɋ��_����
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESHIPSECTNM_TITLE] = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEShipSectCd);
            // ���㋒�_�R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESALSECTCD_TITLE] = uoeSupplier.UOESalSectCd;
            // ���㋒�_����
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESALSECTNM_TITLE] = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOESalSectCd);
            // �w�苒�_�R�[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOERESERVSECTCD_TITLE] = uoeSupplier.UOEReservSectCd;
            // �w�苒�_����
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOERESERVSECTNM_TITLE] = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEReservSectCd);
            // ��M�L���敪
            switch (uoeSupplier.ReceiveCondition)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][RECEIVECONDITION_TITLE] = "����M�\";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][RECEIVECONDITION_TITLE] = "���M�̂�";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][RECEIVECONDITION_TITLE] = "";
                        break;
                    }
            }
            // ��֕i�ԋ敪
            switch (uoeSupplier.SubstPartsNoDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUBSTPARTSNODIV_TITLE] = "��֕i�ԍ̗p";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUBSTPARTSNODIV_TITLE] = "�����i�ԍ̗p";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUBSTPARTSNODIV_TITLE] = "";
                        break;
                    }
            }
            // �i�Ԉ���敪
            switch (uoeSupplier.PartsNoPrtCd)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = "��֕i�ԍ̗p";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = "�����i�ԍ̗p";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = "";
                        break;
                    }
            }
            // �艿�g�p�敪
            switch (uoeSupplier.ListPriceUseDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "������";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "���͗D��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "�I�����C���D��";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "";
                        break;
                    }
            }
            // �d����M�敪
            switch (uoeSupplier.StockSlipDtRecvDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][STOCKSLIPDTRECVDIV_TITLE] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][STOCKSLIPDTRECVDIV_TITLE] = "����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][STOCKSLIPDTRECVDIV_TITLE] = "";
                        break;
                    }
            }
            // �`�F�b�N�敪
            switch (uoeSupplier.CheckCodeDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "�q��(4)�{�I��(6)";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "�q��(2)�{�I��(8)";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "�I�Ԃ̂�";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "";
                        break;
                    }
            }
            // �Ɩ��敪
            switch (uoeSupplier.BusinessCode)
            {
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "����";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "�݌�";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "";
                        break;
                    }
            }
            // �w�苒�_
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOERESVDSECTION_TITLE] = uoeSupplier.UOEResvdSection;
            // �˗���
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMPLOYEECODE_TITLE] = uoeSupplier.EmployeeCode;
            // �˗��Җ�
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMPLOYEENAME_TITLE] = GetEmployeeName(uoeSupplier.EmployeeCode);
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
            //// �[�i�敪
            //this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELIVEREDGOODSDIV_TITLE] = uoeSupplier.DeliveredGoodsDiv;
            // �[�i�敪
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELIVEREDGOODSDIV_TITLE] = uoeSupplier.UOEDeliGoodsDiv;
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            // �a�n�敪
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BOCODE_TITLE] = uoeSupplier.BoCode;
            // ���[�g
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERRATE_TITLE] = uoeSupplier.UOEOrderRate;
            // ���@
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INSTRUMENTNO_TITLE] = uoeSupplier.instrumentNo;
            // �e�X�g���[�h
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOETESTMODE_TITLE] = uoeSupplier.UOETestMode;
            // �A�C�e��
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEITEMCD_TITLE] = uoeSupplier.UOEItemCd;
            // �S�����_
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][HONDASECTIONCODE_TITLE] = uoeSupplier.HondaSectionCode;
            // �񓚕ۑ��t�H���_
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ANSWERSAVEFOLDER_TITLE] = uoeSupplier.AnswerSaveFolder;
            // �����_
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][MAZDASECTIONCODE_TITLE] = uoeSupplier.MazdaSectionCode;
            // �ً}�敪
            if (uoeSupplier.EmergencyDiv.Equals("C"))
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMERGENCYDIV_TITLE] = "���ً}";
            }
            else if (uoeSupplier.EmergencyDiv.Equals("E"))
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMERGENCYDIV_TITLE] = "�ً}";
            }
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMERGENCYDIV_TITLE] = "";
            }
            // �����\���[�J�[�R�[�h�P
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD1_TITLE] = uoeSupplier.EnableOdrMakerCd1;
            // �����\���[�J�[���̂P
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM1_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd1);
            // �����\���[�J�[�R�[�h�Q
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD2_TITLE] = uoeSupplier.EnableOdrMakerCd2;
            // �����\���[�J�[���̂Q
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM2_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd2);
            // �����\���[�J�[�R�[�h�R
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD3_TITLE] = uoeSupplier.EnableOdrMakerCd3;
            // �����\���[�J�[���̂R
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM3_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd3);
            // �����\���[�J�[�R�[�h�S
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD4_TITLE] = uoeSupplier.EnableOdrMakerCd4;
            // �����\���[�J�[���̂S
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM4_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd4);
            // �����\���[�J�[�R�[�h�T
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD5_TITLE] = uoeSupplier.EnableOdrMakerCd5;
            // �����\���[�J�[���̂T
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM5_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd5);
            // �����\���[�J�[�R�[�h�U
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD6_TITLE] = uoeSupplier.EnableOdrMakerCd6;
            // �����\���[�J�[���̂U
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM6_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd6);
            
            // GUID
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GUID_TITLE] = CreateHashKey(uoeSupplier);
            
            if (this._uoeSupplierTable.ContainsKey(CreateHashKey(uoeSupplier)))
            {
                this._uoeSupplierTable.Remove(CreateHashKey(uoeSupplier));
            }
            this._uoeSupplierTable.Add(CreateHashKey(uoeSupplier), uoeSupplier);

            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            // �v���O������Int�^�ɕϊ�
            int commAssemblyId = 0;
            if (uoeSupplier.CommAssemblyId.Trim() != "")
            {
                commAssemblyId = int.Parse(uoeSupplier.CommAssemblyId.Trim());
            }
            if (commAssemblyId == 502)
            {
                // ���O�C���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = uoeSupplier.UOELoginUrl;
                // �����pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // �݌Ɋm�F�pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // �����I���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // ���O�C���F�؎���
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = uoeSupplier.LoginTimeoutVal;
                // ���[�UID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = uoeSupplier.EPartsUserId;
                // �p�X���[�h
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = uoeSupplier.EPartsPassWord;

                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:��������";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:�݌Ɋm�F";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            else if (commAssemblyId == 1004)
            {
                // ���O�C���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = uoeSupplier.UOELoginUrl;
                // �����pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = "";
                // �݌Ɋm�F�pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = "";
                // �����I���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // ���O�C���F�؎���
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = DBNull.Value;
                // ���[�UID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = uoeSupplier.EPartsUserId;
                // �p�X���[�h
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = uoeSupplier.EPartsPassWord;

                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:��������";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:�݌Ɋm�F";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }

            }
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            else if (commAssemblyId == 1003)
            {
                // ���O�C���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = uoeSupplier.UOELoginUrl;
                // �����pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // �݌Ɋm�F�pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // �����I���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // ���O�C���F�؎���
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = uoeSupplier.LoginTimeoutVal;
                // ���[�UID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = uoeSupplier.EPartsUserId;
                // �p�X���[�h
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = uoeSupplier.EPartsPassWord;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                // BL�Ǘ����[�U�[�R�[�h
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BLMNGUSERCODE_TITLE] = uoeSupplier.BLMngUserCode;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:��������";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:�݌Ɋm�F";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2011/10/26 ----------------------------------------<<<<<
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = "";                   // ���O�C���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = "";                   // �����pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = "";              // �݌Ɋm�F�pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = "";              // �����I���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = DBNull.Value;     // ���O�C���F�؎���
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = "";                  // ���[�UID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = "";                // �p�X���[�h
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";                   // �ڑ����
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BLMNGUSERCODE_TITLE] = "";                 // BL�Ǘ����[�U�[�R�[�h
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            // ---------------------------- DEL 2010/01/19 -------------------------------->>>>>
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            //if (commAssemblyId == 103)
            //{
            //    //this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ANSWERSAVEFOLDER_TITLE] = AnswerSaveFolderOfTOYOTA_tEdit.Text;
            //}
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
            // ---------------------------- DEL 2010/01/19 -------------------------------------<<<<<
            // ---ADD 2010/07/27 ---------------------------------------->>>>>
            if ("0103".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // UOE�����pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // UOE�݌Ɋm�F�pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // UOE�����I���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:�蓮";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:����";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2010/07/27 ----------------------------------------<<<<<

          // ---ADD 2011/01/28 ---------------------------------------->>>>>
            if ("0104".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // UOE�����pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // UOE�݌Ɋm�F�pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // UOE�����I���pURL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] =  "1:����";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2011/01/28 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (AUTONISSAN_COMMASSEMBLY_ID_0205.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:�蓮";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:����";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            if (AUTONISSAN_COMMASSEMBLY_ID_0206.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:����";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            if (NISSAN_COMMASSEMBLY_ID.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:�蓮";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            if (AUTONISSAN_COMMASSEMBLY_ID.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // �ڑ����
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:����";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            // ---ADD 2011/03/01 ----------------------------------------<<<<<
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable uoeSupplierTable = new DataTable(UOE_SUPPLIER_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            uoeSupplierTable.Columns.Add(DELETE_DATE, typeof(string));

            // ������R�[�h
            uoeSupplierTable.Columns.Add(UOESUPPLIERCD_TITLE, typeof(string));
            // �����於��
            uoeSupplierTable.Columns.Add(UOESUPPLIERNAME_TITLE, typeof(string));
            //���[�J�[�R�[�h
            uoeSupplierTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(int));
            //���[�J�[����
            uoeSupplierTable.Columns.Add(GOODSMAKERNM_TITLE, typeof(string));
            // �d����R�[�h
            uoeSupplierTable.Columns.Add(SUPPLIERCD_TITLE, typeof(int));
            // �d���於��
            uoeSupplierTable.Columns.Add(SUPPLIERNM_TITLE, typeof(string));
            // �d�b�ԍ�
            uoeSupplierTable.Columns.Add(TELNO_TITLE, typeof(string));
            // �[���R�[�h
            uoeSupplierTable.Columns.Add(UOETERMINALCD_TITLE, typeof(string));
            // �z�X�g�R�[�h
            uoeSupplierTable.Columns.Add(UOEHOSTCODE_TITLE, typeof(string));
            // �p�X���[�h
            uoeSupplierTable.Columns.Add(UOECONNECTPASSWORD_TITLE, typeof(string));
            // ���[�U�[�R�[�h
            uoeSupplierTable.Columns.Add(UOECONNECTUSERID_TITLE, typeof(string));
            // �h�c�ԍ�
            uoeSupplierTable.Columns.Add(UOEIDNUM_TITLE, typeof(string));
            // �v���O����
            uoeSupplierTable.Columns.Add(COMMASSEMBLYID_TITLE, typeof(string));
            // Ver
            uoeSupplierTable.Columns.Add(CONNECTVERSIONDIV_TITLE, typeof(string));
            // �o�ɋ��_�R�[�h
            uoeSupplierTable.Columns.Add(UOESHIPSECTCD_TITLE, typeof(string));
            // �o�ɋ��_����
            uoeSupplierTable.Columns.Add(UOESHIPSECTNM_TITLE, typeof(string));
            // ���㋒�_�R�[�h
            uoeSupplierTable.Columns.Add(UOESALSECTCD_TITLE, typeof(string));
            // ���㋒�_����
            uoeSupplierTable.Columns.Add(UOESALSECTNM_TITLE, typeof(string));
            // �w�苒�_�R�[�h
            uoeSupplierTable.Columns.Add(UOERESERVSECTCD_TITLE, typeof(string));
            // �w�苒�_����
            uoeSupplierTable.Columns.Add(UOERESERVSECTNM_TITLE, typeof(string));
            // ��M�L���敪
            uoeSupplierTable.Columns.Add(RECEIVECONDITION_TITLE, typeof(string));
            // ��֕i�ԋ敪
            uoeSupplierTable.Columns.Add(SUBSTPARTSNODIV_TITLE, typeof(string));
            // �i�Ԉ���敪
            uoeSupplierTable.Columns.Add(PARTSNOPRTCD_TITLE, typeof(string));
            // �艿�g�p�敪
            uoeSupplierTable.Columns.Add(LISTPRICEUSEDIV_TITLE, typeof(string));
            // �d����M�敪
            uoeSupplierTable.Columns.Add(STOCKSLIPDTRECVDIV_TITLE, typeof(string));
            // �`�F�b�N�敪
            uoeSupplierTable.Columns.Add(CHECKCODEDIV_TITLE, typeof(string));
            // �Ɩ��敪
            uoeSupplierTable.Columns.Add(BUSINESSCODE_TITLE, typeof(string));
            // �w�苒�_
            uoeSupplierTable.Columns.Add(UOERESVDSECTION_TITLE, typeof(string));
            // �˗���
            uoeSupplierTable.Columns.Add(EMPLOYEECODE_TITLE, typeof(string));
            // �˗��Җ�
            uoeSupplierTable.Columns.Add(EMPLOYEENAME_TITLE, typeof(string));
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
            //// �[�i�敪
            //uoeSupplierTable.Columns.Add(DELIVEREDGOODSDIV_TITLE, typeof(int));
            // UOE�[�i�敪
            uoeSupplierTable.Columns.Add(DELIVEREDGOODSDIV_TITLE, typeof(string));
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            // �a�n�敪
            uoeSupplierTable.Columns.Add(BOCODE_TITLE, typeof(string));
            // ���[�g
            uoeSupplierTable.Columns.Add(UOEORDERRATE_TITLE, typeof(string));
            // ���@
            uoeSupplierTable.Columns.Add(INSTRUMENTNO_TITLE, typeof(string));
            // �e�X�g���[�h
            uoeSupplierTable.Columns.Add(UOETESTMODE_TITLE, typeof(string));
            // �A�C�e��
            uoeSupplierTable.Columns.Add(UOEITEMCD_TITLE, typeof(string));
            // �S�����_
            uoeSupplierTable.Columns.Add(HONDASECTIONCODE_TITLE, typeof(string));
            // �񓚕ۑ��t�H���_
            uoeSupplierTable.Columns.Add(ANSWERSAVEFOLDER_TITLE, typeof(string));
            // �����_
            uoeSupplierTable.Columns.Add(MAZDASECTIONCODE_TITLE, typeof(string));
            // �ً}�敪
            uoeSupplierTable.Columns.Add(EMERGENCYDIV_TITLE, typeof(string));
            // �����\���[�J�[�R�[�h�P
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD1_TITLE, typeof(int));
            // �����\���[�J�[���̂P
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM1_TITLE, typeof(string));
            // �����\���[�J�[�R�[�h�Q
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD2_TITLE, typeof(int));
            // �����\���[�J�[���̂Q
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM2_TITLE, typeof(string));
            // �����\���[�J�[�R�[�h�R
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD3_TITLE, typeof(int));
            // �����\���[�J�[���̂R
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM3_TITLE, typeof(string));
            // �����\���[�J�[�R�[�h�S
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD4_TITLE, typeof(int));
            // �����\���[�J�[���̂S
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM4_TITLE, typeof(string));
            // �����\���[�J�[�R�[�h�T
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD5_TITLE, typeof(int));
            // �����\���[�J�[���̂T
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM5_TITLE, typeof(string));
            // �����\���[�J�[�R�[�h�U
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD6_TITLE, typeof(int));
            // �����\���[�J�[���̂U
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM6_TITLE, typeof(string));
 
            // GUID
            uoeSupplierTable.Columns.Add(GUID_TITLE, typeof(string));

            // ---ADD 2009/06/01 ---------------------------------------->>>>>
            // ���O�C���pURL
            uoeSupplierTable.Columns.Add(UOELOGINURL_TITLE, typeof(string));
            // �����pURL
            uoeSupplierTable.Columns.Add(UOEORDERURL_TITLE, typeof(string));
            // �݌Ɋm�F�pURL
            uoeSupplierTable.Columns.Add(UOESTOCKCHECKURL_TITLE, typeof(string));
            // �����I���pURL
            uoeSupplierTable.Columns.Add(UOEFORCEDTERMURL_TITLE, typeof(string));
            // �ڑ����
            uoeSupplierTable.Columns.Add(INQORDDIVCD_TITLE, typeof(string));
            // ���O�C���F�؎���
            uoeSupplierTable.Columns.Add(LOGINTIMEOUTVAL_TITLE, typeof(int));
            // ���[�UID
            uoeSupplierTable.Columns.Add(EPARTSUSERID_TITLE, typeof(string));
            // �p�X���[�h
            uoeSupplierTable.Columns.Add(EPARTSPASSWORD_TITLE, typeof(string));
            // ---ADD 2009/06/01 ----------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            //BL�Ǘ����[�U�[�R�[�h
            uoeSupplierTable.Columns.Add(BLMNGUSERCODE_TITLE, typeof(string));
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            this.Bind_DataSet.Tables.Add(uoeSupplierTable);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/07/27 �� �� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/03/01 liyp �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �R���{�{�b�N�X������

            // Ver
            this.ConnectVersionDiv_tComboEditor.Items.Clear();
            this.ConnectVersionDiv_tComboEditor.Items.Add(0, "��");
            this.ConnectVersionDiv_tComboEditor.Items.Add(1, "�V");
            this.ConnectVersionDiv_tComboEditor.MaxDropDownItems = this.ConnectVersionDiv_tComboEditor.Items.Count;

            // ��M�L���敪
            this.ReceiveCondition_tComboEditor.Items.Clear();
            this.ReceiveCondition_tComboEditor.Items.Add(0, "����M�\");
            this.ReceiveCondition_tComboEditor.Items.Add(1, "���M�̂�");
            this.ReceiveCondition_tComboEditor.MaxDropDownItems = this.ReceiveCondition_tComboEditor.Items.Count;

            // ��֕i�ԋ敪
            this.SubstPartsNoDiv_tComboEditor.Items.Clear();
            this.SubstPartsNoDiv_tComboEditor.Items.Add(0, "��֕i�ԍ̗p");
            this.SubstPartsNoDiv_tComboEditor.Items.Add(1, "�����i�ԍ̗p");
            this.SubstPartsNoDiv_tComboEditor.MaxDropDownItems = this.SubstPartsNoDiv_tComboEditor.Items.Count;

            // �i�Ԉ���敪
            this.PartsNoPrtCd_tComboEditor.Items.Clear();
            this.PartsNoPrtCd_tComboEditor.Items.Add(0, "��֕i�ԍ̗p");
            this.PartsNoPrtCd_tComboEditor.Items.Add(1, "�����i�ԍ̗p");
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = this.PartsNoPrtCd_tComboEditor.Items.Count;

            // �艿�g�p�敪
            this.ListPriceUseDiv_tComboEditor.Items.Clear();
            this.ListPriceUseDiv_tComboEditor.Items.Add(0, "������");
            this.ListPriceUseDiv_tComboEditor.Items.Add(1, "���͗D��");
            this.ListPriceUseDiv_tComboEditor.Items.Add(2, "�I�����C���D��");
            this.ListPriceUseDiv_tComboEditor.MaxDropDownItems = this.ListPriceUseDiv_tComboEditor.Items.Count;

            // �d����M�敪
            this.StockSlipDtRecvDiv_tComboEditor.Items.Clear();
            this.StockSlipDtRecvDiv_tComboEditor.Items.Add(0, "�Ȃ�");
            this.StockSlipDtRecvDiv_tComboEditor.Items.Add(1, "����");
            this.StockSlipDtRecvDiv_tComboEditor.MaxDropDownItems = this.StockSlipDtRecvDiv_tComboEditor.Items.Count;

            // �`�F�b�N�敪
            this.CheckCodeDiv_tComboEditor.Items.Clear();
            this.CheckCodeDiv_tComboEditor.Items.Add(0, "�q��(4)�{�I��(6)");
            this.CheckCodeDiv_tComboEditor.Items.Add(1, "�q��(2)�{�I��(8)");
            this.CheckCodeDiv_tComboEditor.Items.Add(2, "�I�Ԃ̂�");
            this.CheckCodeDiv_tComboEditor.MaxDropDownItems = this.CheckCodeDiv_tComboEditor.Items.Count;

            // �Ɩ��敪
            this.BusinessCode_tComboEditor.Items.Clear();
            this.BusinessCode_tComboEditor.Items.Add(1, "����");
            this.BusinessCode_tComboEditor.Items.Add(2, "����");
            this.BusinessCode_tComboEditor.Items.Add(3, "�݌�");
            this.BusinessCode_tComboEditor.MaxDropDownItems = this.BusinessCode_tComboEditor.Items.Count;

            // �ً}�敪
            this.EmergencyDiv_tComboEditor.Items.Clear();
            this.EmergencyDiv_tComboEditor.Items.Add("C", "���ً}");
            this.EmergencyDiv_tComboEditor.Items.Add("E", "�ً}");
            this.EmergencyDiv_tComboEditor.MaxDropDownItems = this.EmergencyDiv_tComboEditor.Items.Count;

            // ---ADD 2009/06/01 ---------------------------------------------------------------->>>>>
            // �ڑ����
            this.InqOrdDivCd_tComboEditor.Items.Clear();
            this.InqOrdDivCd_tComboEditor.Items.Add(0, "0:��������");
            this.InqOrdDivCd_tComboEditor.Items.Add(1, "1:�݌Ɋm�F");
            this.InqOrdDivCd_tComboEditor.MaxDropDownItems = this.InqOrdDivCd_tComboEditor.Items.Count;
            // ---ADD 2009/06/01 ----------------------------------------------------------------<<<<<

            // ---ADD 2010/07/27 ---------------------------------------------------------------->>>>>
            // �񓚎����捞�敪
            this.AnswerAutoDiv_tComboEditor.Items.Clear();
            this.AnswerAutoDiv_tComboEditor.Items.Add(0, "�蓮");
            this.AnswerAutoDiv_tComboEditor.Items.Add(1, "����");
            this.AnswerAutoDiv_tComboEditor.MaxDropDownItems = this.AnswerAutoDiv_tComboEditor.Items.Count;
            // ---ADD 2010/07/27 ----------------------------------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------------------------------->>>>>
            // �񓚎����捞�敪(���YWEBUOE�p)
            this.Nissan_AnswerAutoDiv_tComboEditor.Items.Clear();
            this.Nissan_AnswerAutoDiv_tComboEditor.Items.Add(0, "�蓮");
            this.Nissan_AnswerAutoDiv_tComboEditor.Items.Add(1, "����");
            this.Nissan_AnswerAutoDiv_tComboEditor.MaxDropDownItems = this.Nissan_AnswerAutoDiv_tComboEditor.Items.Count;
            // ---ADD 2011/03/01 ----------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/03/08 �k���r ���YWeb-UOE�A�����ڂ̑Ή�</br>
		/// <br>UpdateNote : 2010/04/23 jiangk �O�HWeb-UOE�A�����ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/07/27 �� �� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/03/15 liyp �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���</br>
        /// <br>UpdateNote : 2011/05/10 �{�z�� �}�c�_UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote : 2011/10/26 ������ PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ� </br>
        /// </remarks>
        private void ScreenClear()
        {
            this.UOESupplierCd_tNedit.Clear();                          // ������R�[�h
            this.UOESupplierName_tEdit.Clear();                         // �����於��
            this.tNedit_GoodsMakerCdAllowZero.SetInt(0);                // ���[�J�[�R�[�h
            this.GoodsMakerNm_tEdit.Text = "����";                      // ���[�J�[����
            this.tNedit_SupplierCd.Clear();                             // �d����R�[�h
            this.SupplierNm_tEdit.Clear();                              // �d���於��
            this.TelNo_tEdit.Clear();                                   // �d�b�ԍ�
            this.UOETerminalCd_tEdit.Clear();                           // �[���R�[�h
            this.UOEHostCode_tEdit.Clear();                             // �z�X�g�R�[�h
            this.UOEConnectPassword_tEdit.Clear();                      // �p�X���[�h
            this.UOEConnectUserId_tEdit.Clear();                        // ���[�U�[�R�[�h
            this.UOEIDNum_tEdit.Clear();                                // �h�c�ԍ�
            this.CommAssemblyId_tEdit.Clear();                          // �v���O����
            this.ConnectVersionDiv_tComboEditor.Value = 0;              // Ver
            this.UOEShipSectCd_tEdit.Clear();                           // �o�ɋ��_�R�[�h
            this.UOEShipSectNm_tEdit.Clear();                           // �o�ɋ��_����
            this.UOESalSectCd_tEdit.Clear();                            // ���㋒�_�R�[�h
            this.UOESalSectNm_tEdit.Clear();                            // ���㋒�_����
            this.UOEReservSectCd_tEdit.Clear();                         // �w�苒�_�R�[�h
            this.UOEReservSectNm_tEdit.Clear();                         // �w�苒�_����
            this.ReceiveCondition_tComboEditor.Value = 0;               // ��M�L���敪
            this.SubstPartsNoDiv_tComboEditor.Value = 0;                // ��֕i�ԋ敪
            this.PartsNoPrtCd_tComboEditor.Value = 0;                   // �i�Ԉ���敪
            this.ListPriceUseDiv_tComboEditor.Value = 0;                // �艿�g�p�敪
            this.StockSlipDtRecvDiv_tComboEditor.Value = 0;             // �d����M�敪
            this.CheckCodeDiv_tComboEditor.Value = 0;                   // �`�F�b�N�敪
            this.BusinessCode_tComboEditor.Value = 1;                   // �Ɩ��敪
            this.UOEResvdSection_tComboEditor.Items.Clear();            // �w�苒�_
            this.tEdit_EmployeeCode.Clear();                            // �˗��҃R�[�h
            this.tEdit_EmployeeName.Clear();                            // �˗��Җ���
            this.DeliveredGoodsDiv_tComboEditor.Items.Clear();          // �[�i�敪
            this.BoCode_tComboEditor.Items.Clear();                     // �a�n�敪
            // 2008.11.05 30413 ���� �폜 >>>>>>START
            //this.UOEResvdSection_tEdit.Clear();                         // �w�苒�_
            //this.EmployeeCode_tEdit.Clear();                            // �˗���
            //this.DeliveredGoodsDiv_tNedit.Clear();                      // �[�i�敪
            //this.BoCode_tEdit.Clear();                                  // �a�n�敪
            this.UOEOrderRate_tEdit.Text = "L1000";                     // ���[�g
            this.instrumentNo_tEdit.Clear();                            // ���@
            this.UOETestMode_tEdit.Clear();                             // �e�X�g���[�h
            this.UOEItemCd_tEdit.Clear();                               // �A�C�e��
            this.HondaSectionCode_tEdit.Clear();                        // �S�����_
            //this.AnswerSaveFolder_tEdit.Clear();                        // �񓚕ۑ��t�H���_
            // 2008.11.05 30413 ���� �폜 <<<<<<END
            this.MazdaSectionCode_tEdit.Clear();                        // �����_
            this.EmergencyDiv_tComboEditor.Value = null;                // �ً}�敪
            this.EnableOdrMakerCd1_tNedit.Clear();                      // �����\���[�J�[�R�[�h�P
            this.EnableOdrMakerNm1_tEdit.Clear();                       // �����\���[�J�[���̂P
            this.EnableOdrMakerCd2_tNedit.Clear();                      // �����\���[�J�[�R�[�h�Q
            this.EnableOdrMakerNm2_tEdit.Clear();                       // �����\���[�J�[���̂Q
            this.EnableOdrMakerCd3_tNedit.Clear();                      // �����\���[�J�[�R�[�h�R
            this.EnableOdrMakerNm3_tEdit.Clear();                       // �����\���[�J�[���̂R
            this.EnableOdrMakerCd4_tNedit.Clear();                      // �����\���[�J�[�R�[�h�S
            this.EnableOdrMakerNm4_tEdit.Clear();                       // �����\���[�J�[���̂S
            this.EnableOdrMakerCd5_tNedit.Clear();                      // �����\���[�J�[�R�[�h�T
            this.EnableOdrMakerNm5_tEdit.Clear();                       // �����\���[�J�[���̂T
            this.EnableOdrMakerCd6_tNedit.Clear();                      // �����\���[�J�[�R�[�h�U
            this.EnableOdrMakerNm6_tEdit.Clear();                       // �����\���[�J�[���̂U
            // ---ADD 2009/06/01 ---------------------------------------->>>>>
            this.AnswerSaveFolder_tEdit.Clear();                        // �񓚕ۑ��t�H���_
            this.UOELoginUrl_tEdit.Clear();                             // ���O�C���pURL
            this.UOEOrderUrl_tEdit.Clear();                             // �����pURL
            this.UOEStockCheckUrl_tEdit.Clear();                        // �݌Ɋm�F�pURL
            this.UOEForcedTermUrl_tEdit.Clear();                        // �����I���pURL
            this.InqOrdDivCd_tComboEditor.Value = null;                 // �ڑ����
            this.LoginTimeoutVal_tNedit.Clear();                        // ���O�C���F�؎���
            this.UOEePartsItemCd_tEdit.Clear();                         // �A�C�e��[�z���_e-Parts����]
            this.EPartsUserId_tEdit.Clear();                            // ���[�UID
            this.EPartsPassWord_tEdit.Clear();                          // �p�X���[�h
            // ---ADD 2009/06/01 ----------------------------------------<<<<<
            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            // ����UOEWeb����
            this.MeiJiUoeSystemUseType_tEdit.Clear();                             // �V�X�e�����p�`��
            this.MeiJiUoeEigyousyoCode_tEdit.Clear();                              // �c�Ə��R�[�h
            this.MeiJiUoeEigyousyoFlag_tEdit.Clear();                             // �c�Ə��t���O
            this.MeiJiUoeJigyousyoCode_tEdit.Clear();                          // ���Ə��R�[�h
            this.MeiJiUoeCoCode_tEdit.Clear();                             // ��ЃR�[�h
            this.MeiJiUoeTerminalID_tEdit.Clear();                              // �[��ID
            this.MeiJiUoePassword_tEdit.Clear();                              // �p�X���[�h
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            //��NET-WEB����
            this.Protocol_tComboEditor.Value = 0;                       //�v���g�R��
            this.Connection_tComboEditor.Value = 0;                     //�ڑ��敪
            this.CarMaker_uButton.Enabled = true;                       //�O�ԑΉ����[�J�[
            this.Domain_tEdit.Clear();                                  //�h���C��
            this.OrderAddress_tEdit.Clear();                            //�����p�A�h���X
            this.RestoreAddress_tEdit.Clear();                          //�����p�A�h���X
            this.PurchaseAddress_tEdit.Clear();                         //�d����M�p�A�h���X
            this.TimeOut_tEdit.Clear();                                 //�^�C���A�E�g
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            this.BLMngUserCode_tEdit.Clear();
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            // ---ADD 2011/10/26 ----------------------------------------<<<<<
            this.AnswerSaveFolderOfTOYOTA_tEdit.Clear();                        // �񓚕ۑ��t�H���_ // ADD 2009/12/29 xuxh
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            this.NissanAnswerSaveFolder_tEdit.Clear();                        // ���Y�񓚕ۑ��t�H���_
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			this.MitsubishiAnswerSaveFolder_tEdit.Clear();                    // �O�H�񓚕ۑ��t�H���_
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            // ---ADD 2010/07/27 ---------------------------------------------------------------->>>>>
            // ---ADD 2011/05/10 ---------------------------------------->>>>>
            this.MazdaAnswerSaveFolder_tEdit.Clear();                    // �}�c�_�񓚕ۑ��t�H���_
            this.tEdit_HondaSectionCode.Text = "";
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            // �񓚎����捞�敪
            this.AnswerAutoDiv_tComboEditor.Value = null;
            // WEB�p�X���[�h
            this.WebPassword_tEdit.Clear();
            // WEB���[�U�[ID
            this.WebUserID_tEdit.Clear();
            // WEB�ڑ���R�[�h
            this.WebConnectCode_tEdit.Clear();
            // ---ADD 2010/07/27 ----------------------------------------------------------------<<<<<
            // �񓚎����捞�敪 (���YWEBUOE�p)
            this.Nissan_AnswerAutoDiv_tComboEditor.Value = null; // ADD 2011/03/01
            this.tEdit_MazdaSectionCode.Text = ""; // ADD 2011/03/15
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                //�N���[���쐬
                UOESupplier uoeSupplier = new UOESupplier();
                this._uoeSupplierClone = uoeSupplier.Clone();

                DispToUOESupplier(ref this._uoeSupplierClone);

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);
                
                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                // �t�H�[�J�X�ݒ�
                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
                UOESupplier uoeSupplier = (UOESupplier)this._uoeSupplierTable[guid];

                if (uoeSupplier.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓW�J����
                    UOESupplierToScreen(uoeSupplier);

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    //�N���[���쐬
                    this._uoeSupplierClone = uoeSupplier.Clone();
                    DispToUOESupplier(ref this._uoeSupplierClone);

                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_GoodsMakerCdAllowZero.Focus();
                    this.tNedit_GoodsMakerCdAllowZero.SelectAll();
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓW�J����
                    UOESupplierToScreen(uoeSupplier);

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// ��ʋ����䏈��
        /// </summary>
        /// <param name="screenMode">��ʃ��[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h���ɓ��́^�{�^���̋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/03/08 �k���r ���YWeb-UOE�A�����ڂ̑Ή�</br>
		/// <br>UpdateNote : 2010/04/23 jiangk �O�HWeb-UOE�A�����ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/07/27 ��� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/03/15 liyp �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���</br>
        /// <br>UpdateNote : 2011/05/10 �{�z�� �}�c�_UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote : 2011/10/26 ������ PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string screenMode)
        {
            // �V�K
            if (screenMode.Equals(INSERT_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_UOESupplierGuide.Enabled = true;
                this.uButton_MakerGuide.Enabled = true;
                this.uButton_UOEShipSectGuide.Enabled = true;
                this.uButton_UOESalSectGuide.Enabled = true;
                this.uButton_UOEReservSectGuide.Enabled = true;
                // 2008.11.05 30413 ���� �d����ƈ˗��҂̃K�C�h�{�^����ǉ� >>>>>>START
                this.uButton_SupplierGuide.Enabled = true;
                this.uButton_EmployeeGuide.Enabled = true;
                // 2008.11.05 30413 ���� �d����ƈ˗��҂̃K�C�h�{�^����ǉ� <<<<<<END
                

                // ���͐ݒ�
                this.UOESupplierCd_tNedit.Enabled = true;                   // ������R�[�h
                this.UOESupplierName_tEdit.Enabled = true;                  // �����於��
                this.tNedit_GoodsMakerCdAllowZero.Enabled = true;           // ���[�J�[�R�[�h
                this.tNedit_SupplierCd.Enabled = true;                      // �d����R�[�h
                this.TelNo_tEdit.Enabled = true;                            // �d�b�ԍ�
                this.UOETerminalCd_tEdit.Enabled = true;                    // �[���R�[�h
                this.UOEHostCode_tEdit.Enabled = true;                      // �z�X�g�R�[�h
                this.UOEConnectPassword_tEdit.Enabled = true;               // �p�X���[�h
                this.UOEConnectUserId_tEdit.Enabled = true;                 // ���[�U�[�R�[�h
                this.UOEIDNum_tEdit.Enabled = true;                         // �h�c�ԍ�
                this.CommAssemblyId_tEdit.Enabled = true;                   // �v���O����
                this.ConnectVersionDiv_tComboEditor.Enabled = true;         // Ver
                this.UOEShipSectCd_tEdit.Enabled = true;                    // �o�ɋ��_�R�[�h
                this.UOESalSectCd_tEdit.Enabled = true;                     // ���㋒�_�R�[�h
                this.UOEReservSectCd_tEdit.Enabled = true;                  // �w�苒�_�R�[�h
                this.ReceiveCondition_tComboEditor.Enabled = true;          // ��M�L���敪
                this.SubstPartsNoDiv_tComboEditor.Enabled = true;           // ��֕i�ԋ敪
                this.PartsNoPrtCd_tComboEditor.Enabled = true;              // �i�Ԉ���敪
                this.ListPriceUseDiv_tComboEditor.Enabled = true;           // �艿�g�p�敪
                this.StockSlipDtRecvDiv_tComboEditor.Enabled = true;        // �d����M�敪
                this.BusinessCode_tComboEditor.Enabled = true;              // �Ɩ��敪
                this.UOEResvdSection_tComboEditor.Enabled = true;           // �w�苒�_
                this.tEdit_EmployeeCode.Enabled = true;                     // �˗���
                this.DeliveredGoodsDiv_tComboEditor.Enabled = true;         // �[�i�敪
                this.BoCode_tComboEditor.Enabled = true;                    // �a�n�敪
                // 2008.11.05 30413 ���� �폜 >>>>>>START
                //this.UOEResvdSection_tEdit.Enabled = true;                  // �w�苒�_
                //this.EmployeeCode_tEdit.Enabled = true;                     // �˗���
                //this.DeliveredGoodsDiv_tNedit.Enabled = true;               // �[�i�敪
                //this.BoCode_tEdit.Enabled = true;                           // �a�n�敪
                // 2008.11.05 30413 ���� �폜 <<<<<<END
                this.UOEOrderRate_tEdit.Enabled = true;                     // ���[�g
                this.EnableOdrMakerNm1_tEdit.Enabled = false;               // �����\���[�J�[���̂P
                this.EnableOdrMakerNm2_tEdit.Enabled = false;               // �����\���[�J�[���̂Q
                this.EnableOdrMakerNm3_tEdit.Enabled = false;               // �����\���[�J�[���̂R
                this.EnableOdrMakerNm4_tEdit.Enabled = false;               // �����\���[�J�[���̂S
                this.EnableOdrMakerNm5_tEdit.Enabled = false;               // �����\���[�J�[���̂T
                this.EnableOdrMakerNm6_tEdit.Enabled = false;               // �����\���[�J�[���̂U

                // ���͍��ڂ̗L�������`�F�b�N
                InputEnableCheck();
            
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_UOESupplierGuide.Enabled = false;
                this.uButton_MakerGuide.Enabled = true;
                this.uButton_UOEShipSectGuide.Enabled = true;
                this.uButton_UOESalSectGuide.Enabled = true;
                this.uButton_UOEReservSectGuide.Enabled = true;
                // 2008.11.05 30413 ���� �d����ƈ˗��҂̃K�C�h�{�^����ǉ� >>>>>>START
                this.uButton_SupplierGuide.Enabled = true;
                this.uButton_EmployeeGuide.Enabled = true;
                // 2008.11.05 30413 ���� �d����ƈ˗��҂̃K�C�h�{�^����ǉ� <<<<<<END

                // ���͐ݒ�
                this.UOESupplierCd_tNedit.Enabled = false;                  // ������R�[�h
                this.UOESupplierName_tEdit.Enabled = true;                  // �����於��
                this.tNedit_GoodsMakerCdAllowZero.Enabled = true;           // ���[�J�[�R�[�h
                this.tNedit_SupplierCd.Enabled = true;                      // �d����R�[�h
                this.TelNo_tEdit.Enabled = true;                            // �d�b�ԍ�
                this.UOETerminalCd_tEdit.Enabled = true;                    // �[���R�[�h
                this.UOEHostCode_tEdit.Enabled = true;                      // �z�X�g�R�[�h
                this.UOEConnectPassword_tEdit.Enabled = true;               // �p�X���[�h
                this.UOEConnectUserId_tEdit.Enabled = true;                 // ���[�U�[�R�[�h
                this.UOEIDNum_tEdit.Enabled = true;                         // �h�c�ԍ�
                this.CommAssemblyId_tEdit.Enabled = true;                   // �v���O����
                this.ConnectVersionDiv_tComboEditor.Enabled = true;         // Ver
                this.UOEShipSectCd_tEdit.Enabled = true;                    // �o�ɋ��_�R�[�h
                this.UOESalSectCd_tEdit.Enabled = true;                     // ���㋒�_�R�[�h
                this.UOEReservSectCd_tEdit.Enabled = true;                  // �w�苒�_�R�[�h
                this.ReceiveCondition_tComboEditor.Enabled = true;          // ��M�L���敪
                this.SubstPartsNoDiv_tComboEditor.Enabled = true;           // ��֕i�ԋ敪
                this.PartsNoPrtCd_tComboEditor.Enabled = true;              // �i�Ԉ���敪
                this.ListPriceUseDiv_tComboEditor.Enabled = true;           // �艿�g�p�敪
                this.StockSlipDtRecvDiv_tComboEditor.Enabled = true;        // �d����M�敪
                this.BusinessCode_tComboEditor.Enabled = true;              // �Ɩ��敪
                this.UOEResvdSection_tComboEditor.Enabled = true;           // �w�苒�_
                this.tEdit_EmployeeCode.Enabled = true;                     // �˗���
                this.DeliveredGoodsDiv_tComboEditor.Enabled = true;         // �[�i�敪
                this.BoCode_tComboEditor.Enabled = true;                    // �a�n�敪
                // 2008.11.05 30413 ���� �폜 >>>>>>START
                //this.UOEResvdSection_tEdit.Enabled = true;                  // �w�苒�_
                //this.EmployeeCode_tEdit.Enabled = true;                     // �˗���
                //this.DeliveredGoodsDiv_tNedit.Enabled = true;               // �[�i�敪
                //this.BoCode_tEdit.Enabled = true;                           // �a�n�敪
                // 2008.11.05 30413 ���� �폜 <<<<<<END
                this.UOEOrderRate_tEdit.Enabled = true;                     // ���[�g
                this.EnableOdrMakerNm1_tEdit.Enabled = false;               // �����\���[�J�[���̂P
                this.EnableOdrMakerNm2_tEdit.Enabled = false;               // �����\���[�J�[���̂Q
                this.EnableOdrMakerNm3_tEdit.Enabled = false;               // �����\���[�J�[���̂R
                this.EnableOdrMakerNm4_tEdit.Enabled = false;               // �����\���[�J�[���̂S
                this.EnableOdrMakerNm5_tEdit.Enabled = false;               // �����\���[�J�[���̂T
                this.EnableOdrMakerNm6_tEdit.Enabled = false;               // �����\���[�J�[���̂U

                // ���͍��ڂ̗L�������`�F�b�N
                InputEnableCheck();

            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.uButton_UOESupplierGuide.Enabled = false;
                this.uButton_MakerGuide.Enabled = false;
                this.uButton_UOEShipSectGuide.Enabled = false;
                this.uButton_UOESalSectGuide.Enabled = false;
                this.uButton_UOEReservSectGuide.Enabled = false;
                this.uButton_EnableOdrMaker1Guide.Enabled = false;
                this.uButton_EnableOdrMaker2Guide.Enabled = false;
                this.uButton_EnableOdrMaker3Guide.Enabled = false;
                this.uButton_EnableOdrMaker4Guide.Enabled = false;
                this.uButton_EnableOdrMaker5Guide.Enabled = false;
                this.uButton_EnableOdrMaker6Guide.Enabled = false;
                // 2008.11.05 30413 ���� �d����ƈ˗��҂̃K�C�h�{�^����ǉ� >>>>>>START
                this.uButton_SupplierGuide.Enabled = false;
                this.uButton_EmployeeGuide.Enabled = false;
                // 2008.11.05 30413 ���� �d����ƈ˗��҂̃K�C�h�{�^����ǉ� <<<<<<END
                this.uButton_AnswerSaveFolder.Enabled = false;          //ADD 2009/06/01

                // ���͐ݒ�
                this.UOESupplierCd_tNedit.Enabled = false;                  // ������R�[�h
                this.UOESupplierName_tEdit.Enabled = false;                 // �����於��
                this.tNedit_GoodsMakerCdAllowZero.Enabled = false;          // ���[�J�[�R�[�h
                this.tNedit_SupplierCd.Enabled = false;                     // �d����R�[�h
                this.TelNo_tEdit.Enabled = false;                           // �d�b�ԍ�
                this.UOETerminalCd_tEdit.Enabled = false;                   // �[���R�[�h
                this.UOEHostCode_tEdit.Enabled = false;                     // �z�X�g�R�[�h
                this.UOEConnectPassword_tEdit.Enabled = false;              // �p�X���[�h
                this.UOEConnectUserId_tEdit.Enabled = false;                // ���[�U�[�R�[�h
                this.UOEIDNum_tEdit.Enabled = false;                        // �h�c�ԍ�
                this.CommAssemblyId_tEdit.Enabled = false;                  // �v���O����
                this.ConnectVersionDiv_tComboEditor.Enabled = false;        // Ver
                this.UOEShipSectCd_tEdit.Enabled = false;                   // �o�ɋ��_�R�[�h
                this.UOESalSectCd_tEdit.Enabled = false;                    // ���㋒�_�R�[�h
                this.UOEReservSectCd_tEdit.Enabled = false;                 // �w�苒�_�R�[�h
                this.ReceiveCondition_tComboEditor.Enabled = false;         // ��M�L���敪
                this.SubstPartsNoDiv_tComboEditor.Enabled = false;          // ��֕i�ԋ敪
                this.PartsNoPrtCd_tComboEditor.Enabled = false;             // �i�Ԉ���敪
                this.ListPriceUseDiv_tComboEditor.Enabled = false;          // �艿�g�p�敪
                this.StockSlipDtRecvDiv_tComboEditor.Enabled = false;       // �d����M�敪
                this.CheckCodeDiv_tComboEditor.Enabled = false;             // �`�F�b�N�敪
                this.BusinessCode_tComboEditor.Enabled = false;             // �Ɩ��敪
                this.UOEResvdSection_tComboEditor.Enabled = false;          // �w�苒�_
                this.tEdit_EmployeeCode.Enabled = false;                    // �˗���
                this.DeliveredGoodsDiv_tComboEditor.Enabled = false;        // �[�i�敪
                this.BoCode_tComboEditor.Enabled = false;                   // �a�n�敪
                // 2008.11.05 30413 ���� �폜 >>>>>>START
                //this.UOEResvdSection_tEdit.Enabled = false;                 // �w�苒�_
                //this.EmployeeCode_tEdit.Enabled = false;                    // �˗���
                //this.DeliveredGoodsDiv_tNedit.Enabled = false;              // �[�i�敪
                //this.BoCode_tEdit.Enabled = false;                          // �a�n�敪
                this.UOEOrderRate_tEdit.Enabled = false;                    // ���[�g
                this.instrumentNo_tEdit.Enabled = false;                    // ���@
                this.UOETestMode_tEdit.Enabled = false;                     // �e�X�g���[�h
                this.UOEItemCd_tEdit.Enabled = false;                       // �A�C�e��
                this.HondaSectionCode_tEdit.Enabled = false;                // �S�����_
                //this.AnswerSaveFolder_tEdit.Enabled = false;                // �񓚕ۑ��t�H���_
                // 2008.11.05 30413 ���� �폜 <<<<<<END
                this.MazdaSectionCode_tEdit.Enabled = false;                // �����_
                this.EmergencyDiv_tComboEditor.Enabled = false;             // �ً}�敪
                this.EnableOdrMakerCd1_tNedit.Enabled = false;              // �����\���[�J�[�R�[�h�P
                this.EnableOdrMakerNm1_tEdit.Enabled = false;               // �����\���[�J�[���̂P
                this.EnableOdrMakerCd2_tNedit.Enabled = false;              // �����\���[�J�[�R�[�h�Q
                this.EnableOdrMakerNm2_tEdit.Enabled = false;               // �����\���[�J�[���̂Q
                this.EnableOdrMakerCd3_tNedit.Enabled = false;              // �����\���[�J�[�R�[�h�R
                this.EnableOdrMakerNm3_tEdit.Enabled = false;               // �����\���[�J�[���̂R
                this.EnableOdrMakerCd4_tNedit.Enabled = false;              // �����\���[�J�[�R�[�h�S
                this.EnableOdrMakerNm4_tEdit.Enabled = false;               // �����\���[�J�[���̂S
                this.EnableOdrMakerCd5_tNedit.Enabled = false;              // �����\���[�J�[�R�[�h�T
                this.EnableOdrMakerNm5_tEdit.Enabled = false;               // �����\���[�J�[���̂T
                this.EnableOdrMakerCd6_tNedit.Enabled = false;              // �����\���[�J�[�R�[�h�U
                this.EnableOdrMakerNm6_tEdit.Enabled = false;               // �����\���[�J�[���̂U
                // ---ADD 2009/06/01 --------------------------------------->>>>>
                this.AnswerSaveFolder_tEdit.Enabled = false;                // �񓚕ۑ��t�H���_
                this.UOELoginUrl_tEdit.Enabled = false;                     // ���O�C���pURL
                this.UOEOrderUrl_tEdit.Enabled = false;                     // �����pURL
                this.UOEStockCheckUrl_tEdit.Enabled = false;                // �݌Ɋm�F�pURL
                this.UOEForcedTermUrl_tEdit.Enabled = false;                // �����I���pURL
                this.InqOrdDivCd_tComboEditor.Enabled = false;              // �ڑ����
                this.LoginTimeoutVal_tNedit.Enabled = false;                // ���O�C���F�؎���
                this.UOEePartsItemCd_tEdit.Enabled = false;                 // �A�C�e��[�z���_e-Parts����]
                this.EPartsUserId_tEdit.Enabled = false;                    // ���[�UID
                this.EPartsPassWord_tEdit.Enabled = false;                  // �p�X���[�h
                this.AnswerSaveFolderOfTOYOTA_tEdit.Enabled = false;                // �g���^�d�q�J�^���O�̉񓚕ۑ��t�H���_�@// ADD 2009/12/29 xuxh
                // ---ADD 2010/03/08 ---------------------------------------->>>>>
                this.NissanAnswerSaveFolder_tEdit.Enabled = false;          // ���Y�̉񓚕ۑ��t�H���_
                // ---ADD 2010/03/08 ----------------------------------------<<<<<
				// ---ADD 2010/04/23 ---------------------------------------->>>>>
				this.MitsubishiAnswerSaveFolder_tEdit.Enabled = false;      // �O�H�̉񓚕ۑ��t�H���_
				// ---ADD 2010/04/23 ----------------------------------------<<<<<
                // ---ADD 2011/05/10 ---------------------------------------->>>>>
                this.MazdaAnswerSaveFolder_tEdit.Enabled = false;           // �}�c�_�񓚕ۑ��t�H���_
                this.uButton_MazdaAnswerSaveFolder.Enabled = false;
                // ---ADD 2011/05/10 ----------------------------------------<<<<<
                int commAssemblyId = 0;
                if (CommAssemblyId_tEdit.Text.Trim() != "")
                {
                    commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
                }
                if (commAssemblyId != 502)
                {
                    this.InqOrdDivCd_tComboEditor.Value = null;

                    // ---ADD 2011/01/28 --------------------------------------->>>>>
                    this.AnswerSaveFolder_tEdit.Clear(); // �񓚕ۑ��t�H���_
                    this.UOEOrderUrl_tEdit.Clear(); // �����pURL
                    this.UOEStockCheckUrl_tEdit.Clear(); // �݌Ɋm�F�pURL
                    this.UOEForcedTermUrl_tEdit.Clear(); // �����I���pURL
                    // ---ADD 2011/01/28 ---------------------------------------<<<<<
                }
                // ---ADD 2009/06/01 ---------------------------------------<<<<<

                // ---ADD 2010/05/14 --------------------------------------->>>>>
                this.MeiJiUoeSystemUseType_tEdit.Enabled = false;       // �V�X�e�����p�`��
                this.MeiJiUoeEigyousyoCode_tEdit.Enabled = false;        // �c�Ə��R�[�h
                this.MeiJiUoeEigyousyoFlag_tEdit.Enabled = false;       // �c�Ə��t���O
                this.MeiJiUoeJigyousyoCode_tEdit.Enabled = false;    // ���Ə��R�[�h
                this.MeiJiUoeCoCode_tEdit.Enabled = false;       // ��ЃR�[�h
                this.MeiJiUoeTerminalID_tEdit.Enabled = false;        // �[��ID
                this.MeiJiUoePassword_tEdit.Enabled = false;        // �p�X���[�h
                // ---ADD 2010/05/14 ---------------------------------------<<<<<
                // ---ADD 2011/10/26 --------------------------------------->>>>>
                this.Protocol_tComboEditor.Enabled = false;         // �v���g�R��
                this.Connection_tComboEditor.Enabled = false;       // �ڑ��敪
                this.CarMaker_uButton.Enabled = false;              // �O�ԑΉ����[�J�[
                this.Domain_tEdit.Enabled = false;                  // �h���C��
                this.OrderAddress_tEdit.Enabled = false;            // �����p�A�h���X
                this.RestoreAddress_tEdit.Enabled = false;          // �����p�A�h���X
                this.PurchaseAddress_tEdit.Enabled = false;         // �d����M�p�A�h���X
                this.TimeOut_tEdit.Enabled = false;                 // �^�C���A�E�g
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Enabled = false;          // BL�Ǘ����[�U�[�R�[�h
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                // ---ADD 2011/10/26 ---------------------------------------<<<<<
                // ---ADD 2010/07/27 --------------------------------------->>>>>
                // �񓚎����捞�敪
                this.AnswerAutoDiv_tComboEditor.Enabled = false;
                // WEB�p�X���[�h
                this.WebPassword_tEdit.Enabled = false;
                // WEB���[�U�[ID
                this.WebUserID_tEdit.Enabled = false;
                // WEB�ڑ���R�[�h
                this.WebConnectCode_tEdit.Enabled = false;
                // ---ADD 2010/07/27 ---------------------------------------<<<<<

                // ---ADD 2010/12/31 --------------------------------------->>>>>
                this.uButton_AnswerSaveFolderOfTOYOTA.Enabled = false;
                this.uButton_NissanAnswerSaveFolder.Enabled = false;
                this.uButton_MitsubishiAnswerSaveFolder.Enabled = false;
                // ---ADD 2010/12/31 ---------------------------------------<<<<<
                // �񓚎����捞�敪(���YWEBUOE�p)
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;//ADD 2011/03/01
                this.tEdit_MazdaSectionCode.Enabled = false; // ADD 2011/03/15
                // ---ADD 2011/05/10 --------------------------------------->>>>>
                this.tEdit_HondaSectionCode.Enabled = false;
                // ---ADD 2011/05/10 ---------------------------------------<<<<<
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                this.MakerCd1_tComboEditor.Enabled = false;
                this.MakerCd2_tComboEditor.Enabled = false;
                this.MakerCd3_tComboEditor.Enabled = false;
                this.MakerCd4_tComboEditor.Enabled = false;
                this.MakerCd5_tComboEditor.Enabled = false;
                this.MakerCd6_tComboEditor.Enabled = false;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            }
        }

        /// <summary>
        /// UOE������}�X�^ �N���X��ʓW�J����
        /// </summary>
        /// <param name="uoeSupplier">UOE������}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>Update Note: 2010/01/19 杍^ Redmine#2505�̑Ή�</br>
        /// <br>Update Note: 2010/03/08 �k���r ���YWeb-UOE�A�����ڂ̑Ή�</br>
		/// <br>Update Note: 2010/04/23 jiangk �O�HWeb-UOE�A�����ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/07/27 �� �� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/01/28 �{�z�� �񓚎����捞�敪�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/01 liyp �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/15 liyp �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���</br>       
        /// <br>UpdateNote : 2011/05/10 �{�z�� �}�c�_UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote : 2011/10/26 ������ PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// </remarks>
        private void UOESupplierToScreen(UOESupplier uoeSupplier)
        {
            this.UOESupplierCd_tNedit.SetInt(uoeSupplier.UOESupplierCd);                        // ������R�[�h
            this.UOESupplierName_tEdit.Text = uoeSupplier.UOESupplierName;                      // �����於��
            this.tNedit_GoodsMakerCdAllowZero.SetInt(uoeSupplier.GoodsMakerCd);                 // ���[�J�[�R�[�h
            if (uoeSupplier.GoodsMakerCd == 0)
            {
                this.GoodsMakerNm_tEdit.Text = MAKER_CODE_ZERO;                                 // ���[�J�[���́i�����j
            }
            else
            {
                this.GoodsMakerNm_tEdit.Text = GetMakerName(uoeSupplier.GoodsMakerCd);          // ���[�J�[����
            }
            this.tNedit_SupplierCd.SetInt(uoeSupplier.SupplierCd);                              // �d����R�[�h
            this.SupplierNm_tEdit.Text = GetSupplierName(uoeSupplier.SupplierCd);               // �d���於��
            this.TelNo_tEdit.Text = uoeSupplier.TelNo;                                          // �d�b�ԍ�
            this.UOETerminalCd_tEdit.Text = uoeSupplier.UOETerminalCd;                          // �[���R�[�h
            this.UOEHostCode_tEdit.Text = uoeSupplier.UOEHostCode;                              // �z�X�g�R�[�h
            this.UOEConnectPassword_tEdit.Text = uoeSupplier.UOEConnectPassword;                // �p�X���[�h
            this.UOEConnectUserId_tEdit.Text = uoeSupplier.UOEConnectUserId;                    // ���[�U�[�R�[�h
            this.UOEIDNum_tEdit.Text = uoeSupplier.UOEIDNum;                                    // �h�c�ԍ�
            this.CommAssemblyId_tEdit.Text = uoeSupplier.CommAssemblyId;                        // �v���O����
            this.ConnectVersionDiv_tComboEditor.Value = uoeSupplier.ConnectVersionDiv;          // Ver
            this.UOEShipSectCd_tEdit.Text = uoeSupplier.UOEShipSectCd;                          // �o�ɋ��_�R�[�h
            this.UOEShipSectNm_tEdit.Text = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEShipSectCd);         // �o�ɋ��_����
            this.UOESalSectCd_tEdit.Text = uoeSupplier.UOESalSectCd;                            // ���㋒�_�R�[�h
            this.UOESalSectNm_tEdit.Text = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOESalSectCd);           // ���㋒�_����
            this.UOEReservSectCd_tEdit.Text = uoeSupplier.UOEReservSectCd;                      // �w�苒�_�R�[�h
            this.UOEReservSectNm_tEdit.Text = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEReservSectCd);     // �w�苒�_����
            this.ReceiveCondition_tComboEditor.Value = uoeSupplier.ReceiveCondition;            // ��M�L���敪
            this.SubstPartsNoDiv_tComboEditor.Value = uoeSupplier.SubstPartsNoDiv;              // ��֕i�ԋ敪
            this.PartsNoPrtCd_tComboEditor.Value = uoeSupplier.PartsNoPrtCd;                    // �i�Ԉ���敪
            this.ListPriceUseDiv_tComboEditor.Value = uoeSupplier.ListPriceUseDiv;              // �艿�g�p�敪
            this.StockSlipDtRecvDiv_tComboEditor.Value = uoeSupplier.StockSlipDtRecvDiv;        // �d����M�敪
            this.CheckCodeDiv_tComboEditor.Value = uoeSupplier.CheckCodeDiv;                    // �`�F�b�N�敪

            // 2008.11.05 30413 ���� �����l�ݒ荀�ڂ̃R���{�{�b�N�X�ǉ� >>>>>>START            
            // �w�苒�_
            this.InitialSettingUOEResvdSection();

            // �[�i�敪
            this.InitialSettingDeliveredGoodsDiv();

            // �a�n�敪
            this.InitialSettingBoCode();
            // 2008.11.05 30413 ���� �����l�ݒ荀�ڂ̃R���{�{�b�N�X�ǉ� <<<<<<END

            this.BusinessCode_tComboEditor.Value = uoeSupplier.BusinessCode;                    // �Ɩ��敪

            // 2009/09/14 �g���������s����悤�ɕύX >>>
            //this.UOEResvdSection_tComboEditor.Value = uoeSupplier.UOEResvdSection;              // �w�苒�_
            this.UOEResvdSection_tComboEditor.Value = uoeSupplier.UOEResvdSection.TrimEnd();              // �w�苒�_
            // 2009/09/14 <<<
         
            // 2009.02.04 30413 �˗��҃R�[�h�̓g���������{ >>>>>>START
            //this.tEdit_EmployeeCode.Text = uoeSupplier.EmployeeCode;                            // �˗���
            this.tEdit_EmployeeCode.Text = uoeSupplier.EmployeeCode.TrimEnd();                  // �˗���
            // 2009.02.04 30413 �˗��҃R�[�h�̓g���������{ <<<<<<END
            this.tEdit_EmployeeName.Text = GetEmployeeName(uoeSupplier.EmployeeCode);           // �˗��Җ���
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
            //this.DeliveredGoodsDiv_tComboEditor.Value = uoeSupplier.DeliveredGoodsDiv;          // �[�i�敪
            this.DeliveredGoodsDiv_tComboEditor.Value = uoeSupplier.UOEDeliGoodsDiv;          // UOE�[�i�敪
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            this.BoCode_tComboEditor.Value = uoeSupplier.BoCode;                                // �a�n�敪
            // 2008.11.05 30413 ���� �폜 >>>>>>START
            //this.UOEResvdSection_tEdit.Text = uoeSupplier.UOEResvdSection;                      // �w�苒�_
            //this.EmployeeCode_tEdit.Text = uoeSupplier.EmployeeCode;                            // �˗���
            //this.DeliveredGoodsDiv_tNedit.SetInt(uoeSupplier.DeliveredGoodsDiv);                // �[�i�敪
            //this.BoCode_tEdit.Text = uoeSupplier.BoCode;                                        // �a�n�敪
            this.UOEOrderRate_tEdit.Text = uoeSupplier.UOEOrderRate;                            // ���[�g
            this.instrumentNo_tEdit.Text = uoeSupplier.instrumentNo;                            // ���@
            this.UOETestMode_tEdit.Text = uoeSupplier.UOETestMode;                              // �e�X�g���[�h
            //this.UOEItemCd_tEdit.Text = uoeSupplier.UOEItemCd;                                  // �A�C�e��       //DEL 2009/06/01
            this.HondaSectionCode_tEdit.Text = uoeSupplier.HondaSectionCode;                    // �S�����_
            //this.AnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;                    // �񓚕ۑ��t�H���_
            // 2008.11.05 30413 ���� �폜 <<<<<<END
            this.MazdaSectionCode_tEdit.Text = uoeSupplier.MazdaSectionCode;                    // �����_
            this.EmergencyDiv_tComboEditor.Value = uoeSupplier.EmergencyDiv;                    // �ً}�敪
            this.EnableOdrMakerCd1_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd1);                // �����\���[�J�[�R�[�h�P
            this.EnableOdrMakerNm1_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd1);    // �����\���[�J�[���̂P
            this.EnableOdrMakerCd2_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd2);                // �����\���[�J�[�R�[�h�Q
            this.EnableOdrMakerNm2_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd2);    // �����\���[�J�[���̂Q
            this.EnableOdrMakerCd3_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd3);                // �����\���[�J�[�R�[�h�R
            this.EnableOdrMakerNm3_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd3);    // �����\���[�J�[���̂R
            this.EnableOdrMakerCd4_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd4);                // �����\���[�J�[�R�[�h�S
            this.EnableOdrMakerNm4_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd4);    // �����\���[�J�[���̂S
            this.EnableOdrMakerCd5_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd5);                // �����\���[�J�[�R�[�h�T
            this.EnableOdrMakerNm5_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd5);    // �����\���[�J�[���̂T
            this.EnableOdrMakerCd6_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd6);                // �����\���[�J�[�R�[�h�U
            this.EnableOdrMakerNm6_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd6);    // �����\���[�J�[���̂U
            // ---ADD 2009/06/01 ------------------------------------------------------------>>>>>
            this.AnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;                    // �񓚕ۑ��t�H���_
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            //if (this.CommAssemblyId_tEdit.Text == "0103" || this.CommAssemblyId_tEdit.Text == "103")   // DEL 2010/01/19
            if ("0103".Equals(this.CommAssemblyId_tEdit.Text))                                           // ADD 2010/01/19
            {
                this.AnswerSaveFolderOfTOYOTA_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // ---ADD 2010/07/27 ----------------------------------------------------------->>>>>
                // �񓚎����捞�敪
                if ((uoeSupplier.InqOrdDivCd != 0) && (uoeSupplier.InqOrdDivCd) != 1)
                {
                    this.AnswerAutoDiv_tComboEditor.Value = 0;
                }
                else
                {
                    this.AnswerAutoDiv_tComboEditor.Value = uoeSupplier.InqOrdDivCd;
                }
                // WEB�p�X���[�h
                this.WebPassword_tEdit.Text = uoeSupplier.UOEOrderUrl;
                // WEB���[�U�[ID
                this.WebUserID_tEdit.Text = uoeSupplier.UOEStockCheckUrl;
                // WEB�ڑ���R�[�h
                this.WebConnectCode_tEdit.Text = uoeSupplier.UOEForcedTermUrl;
                // ---ADD 2010/07/27 -----------------------------------------------------------<<<<<

                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                this.MakerCd1_tComboEditor.Visible = true;
                this.MakerCd2_tComboEditor.Visible = true;
                this.MakerCd3_tComboEditor.Visible = true;
                this.MakerCd4_tComboEditor.Visible = true;
                this.MakerCd5_tComboEditor.Visible = true;
                this.MakerCd6_tComboEditor.Visible = true;
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd1_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd2_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd3_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd4_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd5_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd6_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, false);
                }
                this.MakerCd1_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd1;
                this.MakerCd2_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd2;
                this.MakerCd3_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd3;
                this.MakerCd4_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd4;
                this.MakerCd5_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd5;
                this.MakerCd6_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd6;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            }
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<

             // --- ADD 2011/01/28  -------------------------------->>>>>
            if ("0104".Equals(this.CommAssemblyId_tEdit.Text))                                          
            {
                this.AnswerSaveFolderOfTOYOTA_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // �񓚎����捞�敪
                //if ((uoeSupplier.InqOrdDivCd) != 1) // DEL 2011/01/28
                //{ // DEL 2011/01/28
                //    this.AnswerAutoDiv_tComboEditor.Value = 1; // DEL 2011/01/28
                //} // DEL 2011/01/28
                //else // DEL 2011/01/28
                //{ // DEL 2011/01/28
                    this.AnswerAutoDiv_tComboEditor.Value = uoeSupplier.InqOrdDivCd;
                //} // DEL 2011/01/28
                // WEB�p�X���[�h
                this.WebPassword_tEdit.Text = uoeSupplier.UOEOrderUrl;
                // WEB���[�U�[ID
                this.WebUserID_tEdit.Text = uoeSupplier.UOEStockCheckUrl;
                // WEB�ڑ���R�[�h
                this.WebConnectCode_tEdit.Text = uoeSupplier.UOEForcedTermUrl;
            }
            // --- ADD 2011/01/28  --------------------------------<<<<<

            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            if (NISSAN_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))                                           // ADD 2010/01/19
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;// ADD 2011/03/01
            }
            // ---ADD 2010/03/08 ---------------------------------------->>>>>

            // ---ADD 2010/12/31 ---------------------------------------->>>>>
            if (AUTONISSAN_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))                                 
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;// ADD 2011/03/01
            }

            if (AUTOMITSUBISHI_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.MitsubishiAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
            }
            // ---ADD 2010/12/31 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (AUTONISSAN_COMMASSEMBLY_ID_0205.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // �񓚎����捞�敪
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = true;
                if ((uoeSupplier.InqOrdDivCd != 0) && (uoeSupplier.InqOrdDivCd) != 1)
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;
                }
                else
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = uoeSupplier.InqOrdDivCd;
                }
                this.tEdit_MazdaSectionCode.Enabled = false;                 // ADD 2011/03/15
            }
            else if (AUTONISSAN_COMMASSEMBLY_ID_0206.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // �񓚎����捞�敪
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;
                this.tEdit_MazdaSectionCode.Enabled = true;                 // ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = uoeSupplier.MazdaSectionCode; // ADD 2011/03/15
            }
            else 
            {
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                this.tEdit_MazdaSectionCode.Enabled = false;                 // ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			if (MITSUBISHI_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))                                       
			{
				this.MitsubishiAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
			}
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            this.UOELoginUrl_tEdit.Text = uoeSupplier.UOELoginUrl;                              // ���O�C���pURL
            this.UOEOrderUrl_tEdit.Text = uoeSupplier.UOEOrderUrl;                              // �����pURL
            this.UOEStockCheckUrl_tEdit.Text = uoeSupplier.UOEStockCheckUrl;                    // �݌Ɋm�F�pURL
            this.UOEForcedTermUrl_tEdit.Text = uoeSupplier.UOEForcedTermUrl;                    // �����I���pURL
            this.InqOrdDivCd_tComboEditor.Value = uoeSupplier.InqOrdDivCd;                      // �ڑ����
            this.LoginTimeoutVal_tNedit.SetInt(uoeSupplier.LoginTimeoutVal);                    // ���O�C���F�؎���
            this.EPartsUserId_tEdit.Text = uoeSupplier.EPartsUserId;                            // ���[�UID
            this.EPartsPassWord_tEdit.Text = uoeSupplier.EPartsPassWord;                        // �p�X���[�h

            // �v���O������Int�^�ɕϊ�
            int commAssemblyId = 0;
            if (CommAssemblyId_tEdit.Text.Trim() != "")
            {
                commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
            }

            // ---ADD 2010/05/14 ------------------------------------------------------------>>>>>
            //����UOEWeb���ڏꍇ
            if (commAssemblyId == 1004)
            {
                this.MeiJiUoeSystemUseType_tEdit.Text = uoeSupplier.UOETestMode;                // �V�X�e�����p�`��
                this.MeiJiUoeEigyousyoCode_tEdit.Text = uoeSupplier.UOEItemCd;                  // �c�Ə��R�[�h
                this.MeiJiUoeEigyousyoFlag_tEdit.Text = uoeSupplier.InqOrdDivCd.ToString();     // �c�Ə��t���O
                this.MeiJiUoeJigyousyoCode_tEdit.Text = uoeSupplier.UOELoginUrl;                // ���Ə��R�[�h
                this.MeiJiUoeCoCode_tEdit.Text = uoeSupplier.UOEForcedTermUrl;                  // ��ЃR�[�h
                this.MeiJiUoeTerminalID_tEdit.Text = uoeSupplier.EPartsUserId;                  // �[��ID
                this.MeiJiUoePassword_tEdit.Text = uoeSupplier.EPartsPassWord;                  // �p�X���[�h
            }
            // ---ADD 2010/05/14 ------------------------------------------------------------<<<<<
            // ---ADD 2011/10/26 ------------------------------------------------------------>>>>>
            //��NET-WEB����
            if (commAssemblyId == 1003)
            {
                this.Protocol_tComboEditor.Value = uoeSupplier.DaihatsuOrdreDiv;        // �v���g�R��
                this.Connection_tComboEditor.Value = uoeSupplier.InqOrdDivCd;           // �ڑ��敪
                this.Domain_tEdit.Text = uoeSupplier.UOEOrderUrl;                       // �h���C��
                this.OrderAddress_tEdit.Text = uoeSupplier.UOEStockCheckUrl;            // �����p�A�h���X
                this.RestoreAddress_tEdit.Text = uoeSupplier.UOEForcedTermUrl;          // �����p�A�h���X
                this.PurchaseAddress_tEdit.Text = uoeSupplier.UOELoginUrl;              // �d����M�p�A�h���X
                this.TimeOut_tEdit.Text = uoeSupplier.LoginTimeoutVal.ToString();       // �^�C���A�E�g    
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Text = uoeSupplier.BLMngUserCode.ToString();  // BL�Ǘ����[�U�[�R�[�h
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2011/10/26 ------------------------------------------------------------<<<<<
            if (commAssemblyId == 501)
            {
                this.UOEItemCd_tEdit.Text = uoeSupplier.UOEItemCd;          // �A�C�e��[�z���_����]
                this.UOEePartsItemCd_tEdit.Text = "";                       // �A�C�e��[�z���_e-Parts����]
            }
            else if (commAssemblyId == 502)
            {
                this.UOEItemCd_tEdit.Text = "";                             // �A�C�e��[�z���_����]
                this.UOEePartsItemCd_tEdit.Text = uoeSupplier.UOEItemCd;    // �A�C�e��[�z���_e-Parts����]
            }
            else
            {
                this.UOEItemCd_tEdit.Text = "";                             // �A�C�e��[�z���_����]
                this.UOEePartsItemCd_tEdit.Text = "";                       // �A�C�e��[�z���_e-Parts����]
            }
            // ---ADD 2009/06/01 ------------------------------------------------------------>>>>>
            // ---ADD 2011/05/10 ---------------------------------------->>>>
            if (MAZDA_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.MazdaAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                this.tEdit_HondaSectionCode.Enabled = true;
                this.tEdit_HondaSectionCode.Text = uoeSupplier.HondaSectionCode.Trim().PadRight(3, ' ');
            }
            else
            {
                this.MazdaAnswerSaveFolder_tEdit.Enabled = false;
                this.uButton_MazdaAnswerSaveFolder.Enabled = false;
                this.tEdit_HondaSectionCode.Enabled = false;      
            }
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʏ��UOE������}�X�^ �N���X�i�[����
        /// </summary>
        /// <param name="uoeSupplier">UOE������}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�UOE������}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/03/08 �k���r ���YWeb-UOE�A�����ڂ̑Ή�</br>
		/// <br>UpdateNote : 2010/04/23 jiangk �O�HWeb-UOE�A�����ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/07/27 �� �� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/01/28 �{�w�C�� �񓚎����捞�敪�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/01 liyp �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/15 liyp �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���</br>
        /// <br>UpdateNote : 2011/05/10 �{�w�C�� �}�c�_UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// </remarks>
        private void DispToUOESupplier(ref UOESupplier uoeSupplier)
        {
            if (uoeSupplier == null)
            {
                // �V�K�̏ꍇ
                uoeSupplier = new UOESupplier();
            }

            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            // �v���O����:1003 ���� ��NET-WEB���ڂ̐ڑ��敪��C�^�C�v�̏ꍇ�̂�BL�Ǘ����[�U�[�R�[�h���Z�b�g����
            // ���̂��߁A�\��BL�Ǘ����[�U�[�R�[�h�ɋ󔒂��Z�b�g���Ă����A�������������Ƃ��̂ݒl���Z�b�g����
            uoeSupplier.BLMngUserCode = string.Empty;
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            uoeSupplier.EnterpriseCode = this._enterpriseCode;                                  // ��ƃR�[�h
            uoeSupplier.SectionCode = this._sectionCode;                                        // ���_�R�[�h
            uoeSupplier.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();                     // ������R�[�h
            uoeSupplier.UOESupplierName = this.UOESupplierName_tEdit.Text;                      // �����於��
            uoeSupplier.GoodsMakerCd = this.tNedit_GoodsMakerCdAllowZero.GetInt();              // ���[�J�[�R�[�h
            uoeSupplier.SupplierCd = this.tNedit_SupplierCd.GetInt();                           // �d����R�[�h
            uoeSupplier.TelNo = this.TelNo_tEdit.Text;                                          // �d�b�ԍ�
            uoeSupplier.UOETerminalCd = this.UOETerminalCd_tEdit.Text;                          // �[���R�[�h
            uoeSupplier.UOEHostCode = this.UOEHostCode_tEdit.Text;                              // �z�X�g�R�[�h
            uoeSupplier.UOEConnectPassword = this.UOEConnectPassword_tEdit.Text;                // �p�X���[�h
            uoeSupplier.UOEConnectUserId = this.UOEConnectUserId_tEdit.Text;                    // ���[�U�[�R�[�h
            uoeSupplier.UOEIDNum = this.UOEIDNum_tEdit.Text;                                    // �h�c�ԍ�
            uoeSupplier.CommAssemblyId = this.CommAssemblyId_tEdit.Text;                        // �v���O����
            uoeSupplier.ConnectVersionDiv = (int)this.ConnectVersionDiv_tComboEditor.Value;     // Ver
            uoeSupplier.UOEShipSectCd = this.UOEShipSectCd_tEdit.Text;                          // �o�ɋ��_�R�[�h
            uoeSupplier.UOESalSectCd = this.UOESalSectCd_tEdit.Text;                            // ���㋒�_�R�[�h
            uoeSupplier.UOEReservSectCd = this.UOEReservSectCd_tEdit.Text;                      // �w�苒�_�R�[�h
            uoeSupplier.ReceiveCondition = (int)this.ReceiveCondition_tComboEditor.Value;       // ��M�L���敪
            uoeSupplier.SubstPartsNoDiv = (int)this.SubstPartsNoDiv_tComboEditor.Value;         // ��֕i�ԋ敪
            uoeSupplier.PartsNoPrtCd = (int)this.PartsNoPrtCd_tComboEditor.Value;               // �i�Ԉ���敪
            uoeSupplier.ListPriceUseDiv = (int)this.ListPriceUseDiv_tComboEditor.Value;         // �艿�g�p�敪
            uoeSupplier.StockSlipDtRecvDiv = (int)this.StockSlipDtRecvDiv_tComboEditor.Value;   // �d����M�敪
            uoeSupplier.CheckCodeDiv = (int)this.CheckCodeDiv_tComboEditor.Value;               // �`�F�b�N�敪
            if (this.BusinessCode_tComboEditor.Value != null)
            {
                uoeSupplier.BusinessCode = (int)this.BusinessCode_tComboEditor.Value;               // �Ɩ��敪
            }
            if (this.UOEResvdSection_tComboEditor.Value != null)
            {
                uoeSupplier.UOEResvdSection = (string)this.UOEResvdSection_tComboEditor.Value;      // �w�苒�_
            }
            // 2009.02.04 30413 ���� �����͂̏ꍇ�͋󕶎���ݒ肷��悤�ɏC�� >>>>>>START
            //uoeSupplier.EmployeeCode = this.tEdit_EmployeeCode.Text.TrimEnd().PadLeft(4, '0');  // �˗���
            if (this.tEdit_EmployeeCode.Text.TrimEnd() == "")
            {
                uoeSupplier.EmployeeCode = "";
            }
            else
            {
                uoeSupplier.EmployeeCode = this.tEdit_EmployeeCode.Text.TrimEnd().PadLeft(4, '0');  // �˗���
            }
            // 2009.02.04 30413 ���� �����͂̏ꍇ�͋󕶎���ݒ肷��悤�ɏC�� <<<<<<END
            if (this.DeliveredGoodsDiv_tComboEditor.Value != null)
            {
                // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
                //uoeSupplier.DeliveredGoodsDiv = (int)this.DeliveredGoodsDiv_tComboEditor.Value;     // �[�i�敪
                uoeSupplier.UOEDeliGoodsDiv = (string)this.DeliveredGoodsDiv_tComboEditor.Value;     // UOE�[�i�敪
                // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            }
            if (this.BoCode_tComboEditor.Value != null)
            {
                uoeSupplier.BoCode = (string)this.BoCode_tComboEditor.Value;                        // �a�n�敪
            }
            // 2008.11.05 30413 ���� �폜 >>>>>>START
            //uoeSupplier.UOEResvdSection = this.UOEResvdSection_tEdit.Text;                      // �w�苒�_
            //uoeSupplier.EmployeeCode = this.EmployeeCode_tEdit.Text;                            // �˗���
            //uoeSupplier.DeliveredGoodsDiv = this.DeliveredGoodsDiv_tNedit.GetInt();             // �[�i�敪
            //uoeSupplier.BoCode = this.BoCode_tEdit.Text;                                        // �a�n�敪
            uoeSupplier.UOEOrderRate = this.UOEOrderRate_tEdit.Text;                            // ���[�g
            uoeSupplier.instrumentNo = this.instrumentNo_tEdit.Text;                            // ���@
            uoeSupplier.UOETestMode = this.UOETestMode_tEdit.Text;                              // �e�X�g���[�h
            uoeSupplier.UOEItemCd = this.UOEItemCd_tEdit.Text;                                  // �A�C�e��
            uoeSupplier.HondaSectionCode = this.HondaSectionCode_tEdit.Text;                    // �S�����_
            //uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolder_tEdit.Text;                    // �񓚕ۑ��t�H���_
            // 2008.11.05 30413 ���� �폜 <<<<<<END
            uoeSupplier.MazdaSectionCode = this.MazdaSectionCode_tEdit.Text;                    // �����_
            if (this.EmergencyDiv_tComboEditor.Value == null)
            {
                uoeSupplier.EmergencyDiv = "";                                                  // �ً}�敪
            }
            else
            {
                uoeSupplier.EmergencyDiv = (String)this.EmergencyDiv_tComboEditor.Value;        // �ً}�敪
            }
            uoeSupplier.EnableOdrMakerCd1 = this.EnableOdrMakerCd1_tNedit.GetInt();             // �����\���[�J�[�R�[�h�P
            uoeSupplier.EnableOdrMakerCd2 = this.EnableOdrMakerCd2_tNedit.GetInt();             // �����\���[�J�[�R�[�h�Q
            uoeSupplier.EnableOdrMakerCd3 = this.EnableOdrMakerCd3_tNedit.GetInt();             // �����\���[�J�[�R�[�h�R
            uoeSupplier.EnableOdrMakerCd4 = this.EnableOdrMakerCd4_tNedit.GetInt();             // �����\���[�J�[�R�[�h�S
            uoeSupplier.EnableOdrMakerCd5 = this.EnableOdrMakerCd5_tNedit.GetInt();             // �����\���[�J�[�R�[�h�T
            uoeSupplier.EnableOdrMakerCd6 = this.EnableOdrMakerCd6_tNedit.GetInt();             // �����\���[�J�[�R�[�h�U
            // ---ADD 2009/06/01 --------------------------------------------------->>>>>
            uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolder_tEdit.Text;                    // �񓚕ۑ��t�H���_
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == "0103" || uoeSupplier.CommAssemblyId == "103")
            {
                uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolderOfTOYOTA_tEdit.Text;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                if (this.MakerCd1_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd1 = (int)this.MakerCd1_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // �f�t�H�[���g�̓n�C�t�������ƃZ�b�g
                    uoeSupplier.OdrPrtsNoHyphenCd1 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd2_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd2 = (int)this.MakerCd2_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // �f�t�H�[���g�̓n�C�t�������ƃZ�b�g
                    uoeSupplier.OdrPrtsNoHyphenCd2 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd3_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd3 = (int)this.MakerCd3_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // �f�t�H�[���g�̓n�C�t�������ƃZ�b�g
                    uoeSupplier.OdrPrtsNoHyphenCd3 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd4_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd4 = (int)this.MakerCd4_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // �f�t�H�[���g�̓n�C�t�������ƃZ�b�g
                    uoeSupplier.OdrPrtsNoHyphenCd4 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd5_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd5 = (int)this.MakerCd5_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // �f�t�H�[���g�̓n�C�t�������ƃZ�b�g
                    uoeSupplier.OdrPrtsNoHyphenCd5 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd6_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd6 = (int)this.MakerCd6_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // �f�t�H�[���g�̓n�C�t�������ƃZ�b�g
                    uoeSupplier.OdrPrtsNoHyphenCd6 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            }
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<

            // --- ADD 2011/01/28 -------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == "0104" || uoeSupplier.CommAssemblyId == "104")
            {
                uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolderOfTOYOTA_tEdit.Text;
            }
            // --- ADD 2011/01/28  --------------------------------<<<<<

            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == NISSAN_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "203")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
            }

            // ---ADD 2010/12/31 ---------------------------------------->>>>>
            // ---ADD 2011/05/10 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == MAZDA_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "403")
            {
                uoeSupplier.AnswerSaveFolder = this.MazdaAnswerSaveFolder_tEdit.Text;
                uoeSupplier.HondaSectionCode = this.tEdit_HondaSectionCode.Text.PadRight(3, ' ');
            }

            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "204")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
            }

            if (uoeSupplier.CommAssemblyId == AUTOMITSUBISHI_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "303")
            {
                uoeSupplier.AnswerSaveFolder = this.MitsubishiAnswerSaveFolder_tEdit.Text;
            }
            // ---ADD 2010/12/31 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0205 || uoeSupplier.CommAssemblyId == "205")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0206 || uoeSupplier.CommAssemblyId == "206")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
                uoeSupplier.MazdaSectionCode = this.tEdit_MazdaSectionCode.Text.PadRight(3,' '); // ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			if (uoeSupplier.CommAssemblyId == MITSUBISHI_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "302")
			{
				uoeSupplier.AnswerSaveFolder = this.MitsubishiAnswerSaveFolder_tEdit.Text;
			}
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            uoeSupplier.UOELoginUrl = this.UOELoginUrl_tEdit.Text;                              // ���O�C���pURL
            uoeSupplier.UOEOrderUrl = this.UOEOrderUrl_tEdit.Text;                              // �����pURL
            uoeSupplier.UOEStockCheckUrl = this.UOEStockCheckUrl_tEdit.Text;                    // �݌Ɋm�F�pURL
            uoeSupplier.UOEForcedTermUrl = this.UOEForcedTermUrl_tEdit.Text;                    // �����I���pURL
            if (this.InqOrdDivCd_tComboEditor.Value == null)
            {
                uoeSupplier.InqOrdDivCd = 0;
            }
            else
            {
                uoeSupplier.InqOrdDivCd = (int)this.InqOrdDivCd_tComboEditor.Value;             // �ڑ����
            }
            uoeSupplier.LoginTimeoutVal = this.LoginTimeoutVal_tNedit.GetInt();                 // ���O�C���F�؎���
            uoeSupplier.EPartsUserId = this.EPartsUserId_tEdit.Text;                            // ���[�UID
            uoeSupplier.EPartsPassWord = this.EPartsPassWord_tEdit.Text;                        // �p�X���[�h

            //�v���O������Int�^�ɕϊ�
            int commAssemblyId = 0;
            if (CommAssemblyId_tEdit.Text.Trim() != "")
            {
                commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
            }

            if (commAssemblyId == 501)
            {
                uoeSupplier.UOEItemCd = this.UOEItemCd_tEdit.Text;                              // �A�C�e��[�z���_����]
            }
            else if (commAssemblyId == 502)
            {
                uoeSupplier.UOEItemCd = this.UOEePartsItemCd_tEdit.Text;                        // �A�C�e��[�z���_e-Parts����]
            }
            else
            {
                uoeSupplier.UOEItemCd = "";
            }
            // ---ADD 2009/06/01 ---------------------------------------------------<<<<<

            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            //����UOEWeb����
            if (commAssemblyId == 1004)
            {
                uoeSupplier.UOETestMode = this.MeiJiUoeSystemUseType_tEdit.Text;       // �V�X�e�����p�`��
                uoeSupplier.UOEItemCd = this.MeiJiUoeEigyousyoCode_tEdit.Text;        // �c�Ə��R�[�h
                uoeSupplier.UOELoginUrl = this.MeiJiUoeJigyousyoCode_tEdit.Text;    // ���Ə��R�[�h
                uoeSupplier.UOEForcedTermUrl = this.MeiJiUoeCoCode_tEdit.Text;       // ��ЃR�[�h
                uoeSupplier.EPartsUserId = this.MeiJiUoeTerminalID_tEdit.Text;        // �[��ID
                uoeSupplier.EPartsPassWord = this.MeiJiUoePassword_tEdit.Text;        // �p�X���[�h
                // �c�Ə��t���O
                int meiJiUoeEigyousyoFlag_tEdit = 0;
                int.TryParse(this.MeiJiUoeEigyousyoFlag_tEdit.Text.Trim(), out meiJiUoeEigyousyoFlag_tEdit);
                uoeSupplier.InqOrdDivCd = meiJiUoeEigyousyoFlag_tEdit;
            }
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ------------------------------------------------------------>>>>>
            //��NET-WEB����
            if (commAssemblyId == 1003)
            {
                uoeSupplier.DaihatsuOrdreDiv = (int)this.Protocol_tComboEditor.Value;   // �v���g�R��
                uoeSupplier.InqOrdDivCd = (int)this.Connection_tComboEditor.Value;      // �ڑ��敪
                uoeSupplier.UOEOrderUrl = this.Domain_tEdit.Text;                       // �h���C��
                if (this.OrderAddress_tEdit.Text != string.Empty && !this.OrderAddress_tEdit.Text.Substring(0, 1).Equals("/"))
                {
                    this.OrderAddress_tEdit.Text ="/" + this.OrderAddress_tEdit.Text;
                }
                if (this.RestoreAddress_tEdit.Text != string.Empty && !this.RestoreAddress_tEdit.Text.Substring(0, 1).Equals("/"))
                {
                    this.RestoreAddress_tEdit.Text = "/" + this.RestoreAddress_tEdit.Text;
                }
                if (this.PurchaseAddress_tEdit.Text != string.Empty && !this.PurchaseAddress_tEdit.Text.Substring(0, 1).Equals("/"))
                {
                    this.PurchaseAddress_tEdit.Text = "/" + this.PurchaseAddress_tEdit.Text;
                }
                uoeSupplier.UOEStockCheckUrl = this.OrderAddress_tEdit.Text;            // �����p�A�h���X
                uoeSupplier.UOEForcedTermUrl = this.RestoreAddress_tEdit.Text;          // �����p�A�h���X
                uoeSupplier.UOELoginUrl = this.PurchaseAddress_tEdit.Text;              // �d����M�p�A�h���X
                // �^�C���A�E�g 
                int timeOut_tEdit = 0;
                int.TryParse(this.TimeOut_tEdit.Text.Trim(), out timeOut_tEdit);
                uoeSupplier.LoginTimeoutVal = timeOut_tEdit;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                // BL�Ǘ����[�U�[�R�[�h
                if (uoeSupplier.InqOrdDivCd == 2)   //�ڑ��敪��C�^�C�v�̏ꍇ�̂�
                {
                    uoeSupplier.BLMngUserCode = this.BLMngUserCode_tEdit.Text;
                }
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2011/10/26 ------------------------------------------------------------<<<<<
            // ---ADD 2010/07/27 ---------------------------------------->>>>>
            //�g���^UOEWeb����
            if ("0103".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // �⍇���E�������
                uoeSupplier.InqOrdDivCd = (int)this.AnswerAutoDiv_tComboEditor.Value;
                // UOE����URL
                uoeSupplier.UOEOrderUrl = this.WebPassword_tEdit.Text;
                // UOE�݌Ɋm�FURL
                uoeSupplier.UOEStockCheckUrl = this.WebUserID_tEdit.Text;
                // UOE�����I��URL
                uoeSupplier.UOEForcedTermUrl = this.WebConnectCode_tEdit.Text;
            }
            // ---ADD 2010/07/27 ----------------------------------------<<<<<

             // ---ADD 2011/01/28 ---------------------------------------->>>>>
            if ("0104".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // �⍇���E�������
                uoeSupplier.InqOrdDivCd = (int)this.AnswerAutoDiv_tComboEditor.Value;
                // UOE����URL
                uoeSupplier.UOEOrderUrl = this.WebPassword_tEdit.Text;
                // UOE�݌Ɋm�FURL
                uoeSupplier.UOEStockCheckUrl = this.WebUserID_tEdit.Text;
                // UOE�����I��URL
                uoeSupplier.UOEForcedTermUrl = this.WebConnectCode_tEdit.Text;
            }
            // ---ADD 2011/01/28 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == NISSAN_COMMASSEMBLY_ID)
            {
                // �⍇���E�������
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID)
            {
                // �⍇���E�������
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0205)
            {
                // �⍇���E�������
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0206)
            {
                // �⍇���E�������
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="loginID">���O�C��ID</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/07/27 ��� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/10/26 ������ PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // ������R�[�h
            if (this.UOESupplierCd_tNedit.Text == "0" || this.UOESupplierCd_tNedit.Text == "")
            {
                control = this.UOESupplierCd_tNedit;
                message = this.UOESupplierCd_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �����於��
            if (this.UOESupplierName_tEdit.Text.Trim() == "")
            {
                control = this.UOESupplierName_tEdit;
                message = "�����於�̂���͂��ĉ������B";
                return false;
            }

            // ���[�J�[�R�[�h
            if (this.tNedit_GoodsMakerCdAllowZero.Text == "")
            {
                control = this.tNedit_GoodsMakerCdAllowZero;
                message = this.GoodsMakerCd_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �d����R�[�h
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                control = this.tNedit_GoodsMakerCdAllowZero;
                message = this.SupplierCd_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �Ɩ��敪
            if (this.BusinessCode_tComboEditor.Value == null)
            {
                control = this.BusinessCode_tComboEditor;
                message = this.BusinessCode_Label.Text + "��I�����ĉ������B";
                return false;
            }

            // �񓚎����捞�敪
            if (this.AnswerAutoDiv_tComboEditor.Enabled == true)
            {
                if (this.AnswerAutoDiv_tComboEditor.Value == null)
                {
                    control = this.AnswerAutoDiv_tComboEditor;
                    message = this.AnswerAutoDiv_ultraLabel.Text + "��I�����ĉ������B";
                    return false;
                }
            }
            // ------------ADD 2011/03/15 ------------------------------>>>>>
            // WEB�_�~�[�i��
            if (this.tEdit_MazdaSectionCode.Enabled == true)
            {
                if (string.IsNullOrEmpty(this.tEdit_MazdaSectionCode.Text.Trim()))
                {
                    control = this.tEdit_MazdaSectionCode;
                    message = this.ultraLabel_MazdaSectionCode.Text + "����͂��ĉ������B";
                    return false;
                }
            }
            // ------------ADD 2011/03/15 ------------------------------<<<<<

            // ------------ADD 2011/05/10 ------------------------------>>>>>
            // WEB�_�~�[�i��
            if (this.tEdit_HondaSectionCode.Enabled == true)
            {
                if (string.IsNullOrEmpty(this.tEdit_HondaSectionCode.Text.Trim()))
                {
                    control = this.tEdit_HondaSectionCode;
                    message = this.ultraLabel_HondaSectionCode.Text + "����͂��ĉ������B";
                    return false;
                }
            }
            // ------------ADD 2011/05/10 ------------------------------<<<<<

            // ---DEL 2009/08/12 --------------------------------------->>>>>
            // // ---ADD 2009/06/01 --------------------------------------->>>>>
            // // �񓚕ۑ��t�H���_
            // if (this.AnswerSaveFolder_tEdit.Enabled == true)
            // {
            //     if (System.IO.Directory.Exists(this.AnswerSaveFolder_tEdit.Text) == false)
            //     {
            //         control = this.AnswerSaveFolder_tEdit;
            //         message = "�t�H���_�����݂��܂���B";
            //         return false;
            //     }
            // }
            // // ---ADD 2009/06/01 --------------------------------------->>>>>
            // ---DEL 2009/08/12 --------------------------------------->>>>>

            // ---------ADD 2010/05/14 --------->>>>>
            //����UOEWeb����
            if ("1004".Equals(this.CommAssemblyId_tEdit.Text))
            {
                // �V�X�e�����p�`��
                if (string.IsNullOrEmpty(MeiJiUoeSystemUseType_tEdit.Text))
                {
                    control = this.MeiJiUoeSystemUseType_tEdit;
                    message = this.MeiJiUoeSystemUseType_Label.Text + "����͂��ĉ������B";
                    return false;
                }

                // �c�Ə��R�[�h
                if (string.IsNullOrEmpty(MeiJiUoeEigyousyoCode_tEdit.Text))
                {
                    control = this.MeiJiUoeEigyousyoCode_tEdit;
                    message = this.MeiJiUoeEigyousyoCode_Label.Text + "����͂��ĉ������B";
                    return false;
                }
            }
            
            // ---------ADD 2010/05/14 ---------<<<<<
            // ---------ADD 2011/10/26 --------->>>>>
            //��NET-WEB����
            if ("1003".Equals(this.CommAssemblyId_tEdit.Text))
            {
                //�v���g�R��
                if (this.Protocol_tComboEditor.Value == null)
                {
                    control = this.Protocol_tComboEditor;
                    message = this.Protocol_uLabel.Text + "��I�����ĉ������B";
                    return false;
                }
                //�ڑ��敪
                if (this.Connection_tComboEditor.Value == null)
                {
                    control = this.Connection_tComboEditor;
                    message = this.Connection_uLabel.Text + "��I�����ĉ������B";
                    return false;
                }
                if (string.IsNullOrEmpty(this.Domain_tEdit.Text))
                {
                    control = this.Domain_tEdit;
                    message = this.Domain_uLabel.Text + "����͂��ĉ������B";
                    return false;
                }
                if (string.IsNullOrEmpty(this.OrderAddress_tEdit.Text))
                {
                    control = this.OrderAddress_tEdit;
                    message = this.OrderAddress_uLabel.Text + "����͂��ĉ������B";
                    return false;
                }
                if (string.IsNullOrEmpty(this.RestoreAddress_tEdit.Text))
                {
                    control = this.RestoreAddress_tEdit;
                    message = this.RestoreAddress_uLabel.Text + "����͂��ĉ������B";
                    return false;
                }
                if (string.IsNullOrEmpty(this.PurchaseAddress_tEdit.Text))
                {
                    control = this.PurchaseAddress_tEdit;
                    message = this.PurchaseAddress_uLabel.Text + "����͂��ĉ������B";
                    return false;
                }
                if (string.IsNullOrEmpty(this.TimeOut_tEdit.Text))
                {
                    control = this.TimeOut_tEdit;
                    message = this.TimeOut_uLabel.Text + "����͂��ĉ������B";
                    return false;
                }
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                // �ڑ��敪��C�^�C�v�̏ꍇ�̂�BL�Ǘ����[�U�[�R�[�h���̓`�F�b�N
                if ((this.Connection_tComboEditor.SelectedIndex == 2) && (string.IsNullOrEmpty(this.BLMngUserCode_tEdit.Text)))
                {
                    control = this.BLMngUserCode_tEdit;
                    message = this.BLMngUserCode_uLabel.Text + "����͂��Ă��������B";
                    return false;
                }
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---------ADD 2011/10/26 ---------<<<<<
            return true;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="UOESupplier">UOESupplier�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note      : UOESupplier�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UPDATE Note: 2009/12/29 xuxh �񓚕ۑ��t�H���_�i�g���^�d�q�J�^���O�p�������M�f�[�^�̊i�[�ꏊ�j��ǉ�����B</br>
        /// </remarks>
        private string CreateHashKey(UOESupplier uoeSupplier)
        {
            return uoeSupplier.UOESupplierCd.ToString("d9");
        }

        /// <summary>
        /// ���͍��ڂ̗L�������`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���O�������ڂ̒l�œ��͍��ڗL�������̐ݒ��ύX</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>Update Note: 2010/01/19 杍^ Redmine#2505�̑Ή�</br>
        /// <br>Update Note: 2010/03/08 �k���r ���YWeb-UOE�A�����ڂ̑Ή�</br>
		/// <br>Update Note: 2010/04/23 jiangk �O�HWeb-UOE�A�����ڂ̑Ή�</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br> 
        /// <br>UpdateNote : 2010/07/27 �� �� �g���^UOEWeb���ڂ̑Ή�</br>
        /// <br>UpdateNote : 2011/01/28 �{�w�C�� �񓚎����捞�敪�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/01 liyp �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/15 liyp �v���O�����u0206�v�̒ǉ��d�l���̑g�ݍ���</br>
        /// <br>UpdateNote : 2011/05/10 �{�w�C�� �}�c�_UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote : 2011/10/26 ������ PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote : 2011/12/15 yangmj Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�</br>
        /// </remarks>
        private void InputEnableCheck()
        {
            int commAssemblyId = 0;

            if (CommAssemblyId_tEdit.Text.Trim() != "")
            {
                commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
            }

            // �`�F�b�N�敪 �L���^�����؂�ւ�
            if ((commAssemblyId < 1001) || (1099 < commAssemblyId))
            {
                this.CheckCodeDiv_tComboEditor.Enabled = false;                 // �`�F�b�N�敪�i�����j
            }
            else
            {
                this.CheckCodeDiv_tComboEditor.Enabled = true;                  // �`�F�b�N�敪�i�L���j
            }

            // �z���_�ݒ� �L���^�����؂�ւ�
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()))
            {
                this.MakerCd1_tComboEditor.Visible = true;
                this.MakerCd2_tComboEditor.Visible = true;
                this.MakerCd3_tComboEditor.Visible = true;
                this.MakerCd4_tComboEditor.Visible = true;
                this.MakerCd5_tComboEditor.Visible = true;
                this.MakerCd6_tComboEditor.Visible = true;
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd1_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd2_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd3_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd4_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd5_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd6_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, false);
                }
            }
            else
            {
                this.MakerCd1_tComboEditor.Visible = false;
                this.MakerCd2_tComboEditor.Visible = false;
                this.MakerCd3_tComboEditor.Visible = false;
                this.MakerCd4_tComboEditor.Visible = false;
                this.MakerCd5_tComboEditor.Visible = false;
                this.MakerCd6_tComboEditor.Visible = false;
                mekaKubenSet(this.MakerCd1_tComboEditor, false);
                mekaKubenSet(this.MakerCd2_tComboEditor, false);
                mekaKubenSet(this.MakerCd3_tComboEditor, false);
                mekaKubenSet(this.MakerCd4_tComboEditor, false);
                mekaKubenSet(this.MakerCd5_tComboEditor, false);
                mekaKubenSet(this.MakerCd6_tComboEditor, false);
            }
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            //if ((commAssemblyId == 501) || (commAssemblyId == 502))       //DEL 2009/06/01
            if (commAssemblyId == 501)                                      //ADD 2009/06/01
            {
                this.instrumentNo_tEdit.Enabled = true;                         // ���@�i�L���j
                this.UOETestMode_tEdit.Enabled = true;                          // �e�X�g���[�h�i�L���j
                this.UOEItemCd_tEdit.Enabled = true;                            // �A�C�e���i�L���j
                this.HondaSectionCode_tEdit.Enabled = true;                     // �S�����_�i�L���j
            }
            else
            {
                this.instrumentNo_tEdit.Enabled = false;                        // ���@�i�����j
                this.instrumentNo_tEdit.Clear();
                this.UOETestMode_tEdit.Enabled = false;                         // �e�X�g���[�h�i�����j
                this.UOETestMode_tEdit.Clear();
                this.UOEItemCd_tEdit.Enabled = false;                           // �A�C�e���i�����j
                this.UOEItemCd_tEdit.Clear();
                this.HondaSectionCode_tEdit.Enabled = false;                    // �S�����_�i�����j
                this.HondaSectionCode_tEdit.Clear();
            }
            // ---ADD 2009/06/01 ----------------------------------------------->>>>>
            if (commAssemblyId == 502)
            {
                if (this.LoginTimeoutVal_tNedit.Enabled == false)
                {
                    this.LoginTimeoutVal_tNedit.SetValue(10);
                }

                this.AnswerSaveFolder_tEdit.Enabled = true;                     // �񓚕ۑ��t�H���_
                this.uButton_AnswerSaveFolder.Enabled = true;                   // �񓚕ۑ��t�H���_�{�^��
                this.UOELoginUrl_tEdit.Enabled = true;                          // ���O�C���pURL
                this.UOEOrderUrl_tEdit.Enabled = true;                          // �����pURL
                this.UOEStockCheckUrl_tEdit.Enabled = true;                     // �݌Ɋm�F�pURL
                this.UOEForcedTermUrl_tEdit.Enabled = true;                     // �����I���pURL
                this.InqOrdDivCd_tComboEditor.Enabled = true;                   // �ڑ����
                this.LoginTimeoutVal_tNedit.Enabled = true;                     // ���O�C���F�؎���
                this.UOEePartsItemCd_tEdit.Enabled = true;                      // �A�C�e��[�z���_e-Parts����]
                this.EPartsUserId_tEdit.Enabled = true;                         // ���[�UID
                this.EPartsPassWord_tEdit.Enabled = true;                       // �p�X���[�h

                if (this.InqOrdDivCd_tComboEditor.Value == null)
                {
                    // �R���{�{�b�N�X�̏����l�ݒ�
                    this.InqOrdDivCd_tComboEditor.Value = 0;
                }
            }
            else
            {
                this.AnswerSaveFolder_tEdit.Enabled = false;                    // �񓚕ۑ��t�H���_
                this.AnswerSaveFolder_tEdit.Clear();
                this.uButton_AnswerSaveFolder.Enabled = false;                  // �񓚕ۑ��t�H���_�{�^��
                this.UOELoginUrl_tEdit.Enabled = false;                         // ���O�C���pURL
                this.UOELoginUrl_tEdit.Clear();
                this.UOEOrderUrl_tEdit.Enabled = false;                         // �����pURL
                this.UOEOrderUrl_tEdit.Clear();
                this.UOEStockCheckUrl_tEdit.Enabled = false;                    // �݌Ɋm�F�pURL
                this.UOEStockCheckUrl_tEdit.Clear();
                this.UOEForcedTermUrl_tEdit.Enabled = false;                    // �����I���pURL
                this.UOEForcedTermUrl_tEdit.Clear();
                this.InqOrdDivCd_tComboEditor.Enabled = false;                  // �ڑ����
                this.InqOrdDivCd_tComboEditor.Value = null;
                this.LoginTimeoutVal_tNedit.Enabled = false;                    // ���O�C���F�؎���
                this.LoginTimeoutVal_tNedit.Clear();
                this.UOEePartsItemCd_tEdit.Enabled = false;                     // �A�C�e��[�z���_e-Parts����]
                this.UOEePartsItemCd_tEdit.Clear();
                this.EPartsUserId_tEdit.Enabled = false;                        // ���[�UID
                this.EPartsUserId_tEdit.Clear();
                this.EPartsPassWord_tEdit.Enabled = false;                      // �p�X���[�h
                this.EPartsPassWord_tEdit.Clear();
            }
            // ---ADD 2009/06/01 -----------------------------------------------<<<<<

            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            //����UOEWeb����
            if (commAssemblyId == 1004)
            {
                if (this.MeiJiUoeEigyousyoFlag_tEdit.Enabled == false)
                {
                    this.MeiJiUoeEigyousyoFlag_tEdit.Text = "0";
                }
                this.MeiJiUoeSystemUseType_tEdit.Enabled = true;       // �V�X�e�����p�`��
                this.MeiJiUoeEigyousyoCode_tEdit.Enabled = true;        // �c�Ə��R�[�h
                this.MeiJiUoeEigyousyoFlag_tEdit.Enabled = true;       // �c�Ə��t���O
                this.MeiJiUoeJigyousyoCode_tEdit.Enabled = true;    // ���Ə��R�[�h
                this.MeiJiUoeCoCode_tEdit.Enabled = true;       // ��ЃR�[�h
                this.MeiJiUoeTerminalID_tEdit.Enabled = true;        // �[��ID
                this.MeiJiUoePassword_tEdit.Enabled = true;        // �p�X���[�h
            }
            else
            {
                this.MeiJiUoeSystemUseType_tEdit.Enabled = false;       // �V�X�e�����p�`��
                this.MeiJiUoeSystemUseType_tEdit.Clear();
                this.MeiJiUoeEigyousyoCode_tEdit.Enabled = false;        // �c�Ə��R�[�h
                this.MeiJiUoeEigyousyoCode_tEdit.Clear();
                this.MeiJiUoeEigyousyoFlag_tEdit.Enabled = false;       // �c�Ə��t���O
                this.MeiJiUoeEigyousyoFlag_tEdit.Clear();
                this.MeiJiUoeJigyousyoCode_tEdit.Enabled = false;    // ���Ə��R�[�h
                this.MeiJiUoeJigyousyoCode_tEdit.Clear();
                this.MeiJiUoeCoCode_tEdit.Enabled = false;       // ��ЃR�[�h
                this.MeiJiUoeCoCode_tEdit.Clear();
                this.MeiJiUoeTerminalID_tEdit.Enabled = false;        // �[��ID
                this.MeiJiUoeTerminalID_tEdit.Clear();
                this.MeiJiUoePassword_tEdit.Enabled = false;        // �p�X���[�h
                this.MeiJiUoePassword_tEdit.Clear();
            }
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            //��NET-WEB����
            if (commAssemblyId == 1003)
            {
                this.Protocol_tComboEditor.Enabled = true;          // �v���g�R��
                this.Connection_tComboEditor.Enabled = true;        // �ڑ��敪
                this.CarMaker_uButton.Enabled = true;               // �O�ԑΉ����[�J�[
                this.Domain_tEdit.Enabled = true;                   // �h���C��
                this.OrderAddress_tEdit.Enabled = true;             // �����p�A�h���X
                this.RestoreAddress_tEdit.Enabled = true;           // �����p�A�h���X
                this.PurchaseAddress_tEdit.Enabled = true;          // �d����M�p�A�h���X
                this.TimeOut_tEdit.Enabled = true;                  // �^�C���A�E�g
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Enabled = true;           // BL�Ǘ����[�U�[�R�[�h
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                this.Protocol_tComboEditor.Enabled = false;         // �v���g�R��
                this.Connection_tComboEditor.Enabled = false;       // �ڑ��敪
                this.CarMaker_uButton.Enabled = false;              // �O�ԑΉ����[�J�[
                this.Domain_tEdit.Enabled = false;                  // �h���C��
                this.Domain_tEdit.Clear();
                this.OrderAddress_tEdit.Enabled = false;            // �����p�A�h���X
                this.OrderAddress_tEdit.Clear();
                this.RestoreAddress_tEdit.Enabled = false;          // �����p�A�h���X
                this.RestoreAddress_tEdit.Clear();
                this.PurchaseAddress_tEdit.Enabled = false;         // �d����M�p�A�h���X
                this.PurchaseAddress_tEdit.Clear();
                this.TimeOut_tEdit.Enabled = false;                 // �^�C���A�E�g
                this.TimeOut_tEdit.Clear();
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Enabled = false;          // BL�Ǘ����[�U�[�R�[�h
                this.BLMngUserCode_tEdit.Clear();
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2011/10/26 ----------------------------------------<<<<<


            // 2008.11.05 30413 ���� �폜 >>>>>>START
            //// �z���_e-Parts�ݒ� �L���^�����؂�ւ�
            //if (commAssemblyId == 502)
            //{
            //    this.AnswerSaveFolder_tEdit.Enabled = true;                     // �񓚕ۑ��t�H���_�i�L���j
            //}
            //else
            //{
            //    this.AnswerSaveFolder_tEdit.Enabled = false;                    // �񓚕ۑ��t�H���_�i�����j
            //    this.AnswerSaveFolder_tEdit.Clear();
            //}
            // 2008.11.05 30413 ���� �폜 <<<<<<END
                
            // �V�}�c�_�ݒ� �L���^�����؂�ւ�
            // ---UPD 2011/05/10 ------------------------------------------->>>>>
            //if (commAssemblyId == 402)
            if (commAssemblyId == 402 || commAssemblyId == 403)
            // ---UPD 2011/05/10 -------------------------------------------<<<<<
            {
                this.MazdaSectionCode_tEdit.Enabled = true;                     // �����_�i�L���j
            }
            else
            {
                this.MazdaSectionCode_tEdit.Enabled = false;                    // �����_�i�����j
                this.MazdaSectionCode_tEdit.Clear();
            }

            // �O�H�ݒ� �L���^�����؂�ւ�
            if (commAssemblyId == 301)
            {
                this.EmergencyDiv_tComboEditor.Enabled = true;                  // �ً}�敪�i�L���j
                if (this.EmergencyDiv_tComboEditor.Value == null)
                {
                    // �R���{�{�b�N�X�̏����l�ݒ�
                    this.EmergencyDiv_tComboEditor.Value = "E";
                }
            }
            else
            {
                this.EmergencyDiv_tComboEditor.Enabled = false;                 // �ً}�敪�i�����j
                this.EmergencyDiv_tComboEditor.Value = null;
            }

            // �����\���[�J�[ �L���^�����؂�ւ�
            if ((commAssemblyId < 1001) || (1099 < commAssemblyId))
            {
                this.uButton_EnableOdrMaker1Guide.Enabled = true;               // �����\���[�J�[�K�C�h�P�i�L���j
                this.uButton_EnableOdrMaker2Guide.Enabled = true;               // �����\���[�J�[�K�C�h�Q�i�L���j
                this.uButton_EnableOdrMaker3Guide.Enabled = true;               // �����\���[�J�[�K�C�h�R�i�L���j
                this.uButton_EnableOdrMaker4Guide.Enabled = true;               // �����\���[�J�[�K�C�h�S�i�L���j
                this.uButton_EnableOdrMaker5Guide.Enabled = true;               // �����\���[�J�[�K�C�h�T�i�L���j
                this.uButton_EnableOdrMaker6Guide.Enabled = true;               // �����\���[�J�[�K�C�h�U�i�L���j
                this.EnableOdrMakerCd1_tNedit.Enabled = true;                   // �����\���[�J�[�R�[�h�P�i�L���j
                this.EnableOdrMakerCd2_tNedit.Enabled = true;                   // �����\���[�J�[�R�[�h�Q�i�L���j
                this.EnableOdrMakerCd3_tNedit.Enabled = true;                   // �����\���[�J�[�R�[�h�R�i�L���j
                this.EnableOdrMakerCd4_tNedit.Enabled = true;                   // �����\���[�J�[�R�[�h�S�i�L���j
                this.EnableOdrMakerCd5_tNedit.Enabled = true;                   // �����\���[�J�[�R�[�h�T�i�L���j
                this.EnableOdrMakerCd6_tNedit.Enabled = true;                   // �����\���[�J�[�R�[�h�U�i�L���j
            }
            else
            {
                this.uButton_EnableOdrMaker1Guide.Enabled = false;              // �����\���[�J�[�K�C�h�P�i�����j
                this.uButton_EnableOdrMaker2Guide.Enabled = false;              // �����\���[�J�[�K�C�h�Q�i�����j
                this.uButton_EnableOdrMaker3Guide.Enabled = false;              // �����\���[�J�[�K�C�h�R�i�����j
                this.uButton_EnableOdrMaker4Guide.Enabled = false;              // �����\���[�J�[�K�C�h�S�i�����j
                this.uButton_EnableOdrMaker5Guide.Enabled = false;              // �����\���[�J�[�K�C�h�T�i�����j
                this.uButton_EnableOdrMaker6Guide.Enabled = false;              // �����\���[�J�[�K�C�h�U�i�����j
                this.EnableOdrMakerCd1_tNedit.Enabled = false;                  // �����\���[�J�[�R�[�h�P�i�����j
                this.EnableOdrMakerCd2_tNedit.Enabled = false;                  // �����\���[�J�[�R�[�h�Q�i�����j
                this.EnableOdrMakerCd3_tNedit.Enabled = false;                  // �����\���[�J�[�R�[�h�R�i�����j
                this.EnableOdrMakerCd4_tNedit.Enabled = false;                  // �����\���[�J�[�R�[�h�S�i�����j
                this.EnableOdrMakerCd5_tNedit.Enabled = false;                  // �����\���[�J�[�R�[�h�T�i�����j
                this.EnableOdrMakerCd6_tNedit.Enabled = false;                  // �����\���[�J�[�R�[�h�U�i�����j
            }
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            //if (commAssemblyId == 0103)                                // DEL 2010/01/19
            // --- UPD 2011/01/28-------------------------------->>>>>
            //if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()))         // ADD 2010/01/19
              if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()) || "0104".Equals(CommAssemblyId_tEdit.Text.Trim()))
            // --- UPD 2011/01/28---------------------------<<<<<
              {
                AnswerSaveFolderOfTOYOTA_tEdit.Enabled = true;
                uButton_AnswerSaveFolderOfTOYOTA.Enabled = true;
            // --- UPD 2011/01/28-------------------------------->>>>>
                if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()))
                {
                    // �񓚎����捞�敪
                    this.AnswerAutoDiv_tComboEditor.Enabled = true;
                    if (this.AnswerAutoDiv_tComboEditor.Value == null)
                    {
                        this.AnswerAutoDiv_tComboEditor.Value = 0;
                    }
                }
                else
                {
                    // �񓚎����捞�敪
                    this.AnswerAutoDiv_tComboEditor.Enabled = false;
                    //if (this.AnswerAutoDiv_tComboEditor.Value == null) // DEL 2011/01/28
                    //{ // DEL 2011/01/28
                        this.AnswerAutoDiv_tComboEditor.Value = 1;
                    //} // DEL 2011/01/28

                  }
                // --- UPD 2011/01/28-------------------------------->>>>>
                //uButton_AnswerSaveFolderOfTOYOTA.Enabled = true;
                //// ---ADD 2010/07/27 ---------------------------------------->>>>>
                //// �񓚎����捞�敪
                //this.AnswerAutoDiv_tComboEditor.Enabled = true;
                //if (this.AnswerAutoDiv_tComboEditor.Value == null)
                //{
                //    this.AnswerAutoDiv_tComboEditor.Value = 0;
                //}
                // --- UPD 2011/01/28--------------------------------<<<<
                // WEB�p�X���[�h
                this.WebPassword_tEdit.Enabled = true;
                // WEB���[�U�[ID
                this.WebUserID_tEdit.Enabled = true;
                // WEB�ڑ���R�[�h
                this.WebConnectCode_tEdit.Enabled = true;
                // ---ADD 2010/07/27 ----------------------------------------<<<<<
            }
            else
            {
                AnswerSaveFolderOfTOYOTA_tEdit.Enabled = false;
                uButton_AnswerSaveFolderOfTOYOTA.Enabled = false;
                AnswerSaveFolderOfTOYOTA_tEdit.Text = "";
                // ---ADD 2010/07/27 ---------------------------------------->>>>>
                // �񓚎����捞�敪
                this.AnswerAutoDiv_tComboEditor.Enabled = false;
                this.AnswerAutoDiv_tComboEditor.Text = "";
                // WEB�p�X���[�h
                this.WebPassword_tEdit.Enabled = false;
                this.WebPassword_tEdit.Text = "";
                // WEB���[�U�[ID
                this.WebUserID_tEdit.Enabled = false;
                this.WebUserID_tEdit.Text = "";
                // WEB�ڑ���R�[�h
                this.WebConnectCode_tEdit.Enabled = false;
                this.WebConnectCode_tEdit.Text = "";
                // ---ADD 2010/07/27 ----------------------------------------<<<<<
            }
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            if (NISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())
                || AUTONISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim()))   // ADD 2010/12/31
            {
                NissanAnswerSaveFolder_tEdit.Enabled = true;
                uButton_NissanAnswerSaveFolder.Enabled = true;
                // ---ADD 2011/03/01 ---------------------------------------->>>>>
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                if(NISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim()))
                {
                     this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;
                }
                if (AUTONISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim()))
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;
                }
                // ---ADD 2011/03/01 ----------------------------------------<<<<<
                this.tEdit_MazdaSectionCode.Enabled = false; //ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = ""; //ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            else if (AUTONISSAN_COMMASSEMBLY_ID_0205.Equals(CommAssemblyId_tEdit.Text.Trim()))
            {
                NissanAnswerSaveFolder_tEdit.Enabled = true;
                uButton_NissanAnswerSaveFolder.Enabled = true;
                // �񓚎����捞�敪
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = true;
                if (this.Nissan_AnswerAutoDiv_tComboEditor.Value == null)
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;
                }
                this.tEdit_MazdaSectionCode.Enabled = false; //ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = ""; //ADD 2011/03/15
            }
            else if (AUTONISSAN_COMMASSEMBLY_ID_0206.Equals(CommAssemblyId_tEdit.Text.Trim()))
            {
                NissanAnswerSaveFolder_tEdit.Enabled = true;
                uButton_NissanAnswerSaveFolder.Enabled = true;
                // �񓚎����捞�敪
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;
                this.tEdit_MazdaSectionCode.Enabled = true; //ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
            else
            {
                NissanAnswerSaveFolder_tEdit.Enabled = false;
                uButton_NissanAnswerSaveFolder.Enabled = false;
                NissanAnswerSaveFolder_tEdit.Text = "";
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;// ADD 2011/03/01
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = null;// ADD 2011/03/01
                this.tEdit_MazdaSectionCode.Enabled = false; //ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = ""; //ADD 2011/03/15
            }
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			if (MITSUBISHI_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())
                || AUTOMITSUBISHI_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())) // ADD 2010/12/31
			{
				MitsubishiAnswerSaveFolder_tEdit.Enabled = true;
				uButton_MitsubishiAnswerSaveFolder.Enabled = true;
			}
			else
			{
				MitsubishiAnswerSaveFolder_tEdit.Enabled = false;
				uButton_MitsubishiAnswerSaveFolder.Enabled = false;
				MitsubishiAnswerSaveFolder_tEdit.Text = "";
			}

			// ---ADD 2011/05/10 ----------------------------------------<<<<<
            if (MAZDA_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())) // ADD 2010/12/31
            {
                MazdaAnswerSaveFolder_tEdit.Enabled = true;
                uButton_MazdaAnswerSaveFolder.Enabled = true;
                this.tEdit_HondaSectionCode.Enabled = true;
            }
            else
            {
                MazdaAnswerSaveFolder_tEdit.Enabled = false;
                uButton_MazdaAnswerSaveFolder.Enabled = false;
                MazdaAnswerSaveFolder_tEdit.Text = "";
                tEdit_HondaSectionCode.Text = "";
                this.tEdit_HondaSectionCode.Enabled = false;
            }
            // ---ADD 2011/05/10 ----------------------------------------<<<<<

        }

        /// <summary>
        /// UOE������K�C�h�N������
        /// </summary>
        /// <param name="uoeSupplier">UOE������}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : UOE������K�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowUOESupplierGuide(out UOESupplier uoeSupplier)
        {
            uoeSupplier = new UOESupplier();

            return this._uoeSupplierAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode,LoginInfoAcquisition.Employee.BelongSectionCode, out uoeSupplier);
        }

        /// <summary>
        /// ���[�J�[�K�C�h�N������
        /// </summary>
        /// <param name="makerUMnt">���[�J�[�}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowMakerUMntGuide(out MakerUMnt makerUMnt)
        {
            MakerAcs makerAcs = new MakerAcs();

            makerUMnt = new MakerUMnt();

            return makerAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out makerUMnt);
        }

        /// <summary>
        /// �d����K�C�h�N������
        /// </summary>
        /// <param name="SupplierAcs">�d����}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : �d����K�C�h�N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowSupplierGuide(out Supplier supplier)
        {
            SupplierAcs supplierAcs = new SupplierAcs();

            supplier = new Supplier();

            return supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
        }

        /// <summary>
        /// UOE�K�C�h���̃K�C�h�N������
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃K�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowUOEGuideNameGuide(out UOEGuideName uoeGuideName)
        {
            UOEGuideName inUOEGuideName = new UOEGuideName();
            UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();

            uoeGuideName = new UOEGuideName();

            inUOEGuideName.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �K�C�h�敪�͋��_�敪
            inUOEGuideName.UOEGuideDivCd = 3;
            // ��ʂ��甭����R�[�h���擾
            inUOEGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();
            // ���_�R�[�h
            inUOEGuideName.SectionCode = this._sectionCode;

            if (inUOEGuideName.UOESupplierCd != 0)
            {
                return uoeGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/30</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;
            //ArrayList makerUMntRetArray;
            //MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;

            try
            {
                // 2008.11.06 30413 ���� ���[�J�[�}�X�^�̎擾��Read�ɕύX >>>>>>START
                //status = makerAcs.SearchAll(out makerUMntRetArray, this._enterpriseCode);
                //if (status == 0)
                //{
                    //if (makerUMntRetArray.Count <= 0)
                    //{
                    //    return makerName;
                    //}

                    //foreach (MakerUMnt makerUMnt in makerUMntRetArray)
                    //{
                    //    if (makerUMnt.GoodsMakerCd == makerCode)
                    //    {
                    //        makerName = makerUMnt.MakerName.Trim();
                    //        return makerName;
                    //    }
                    //}
                //}
                status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
                if ((status == 0) && (makerUMnt.LogicalDeleteCode == 0))
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
                // 2008.11.06 30413 ���� ���[�J�[�}�X�^�̎擾��Read�ɕύX <<<<<<END                    
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// UOE�K�C�h���̎擾����
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <param name="uoeGuideCode">�K�C�h�R�[�h</param>
        /// <returns>UOE�K�C�h����</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/30</br>
        /// </remarks>
        private string GetUOEGuideName(int uoeSupplierCd, string uoeGuideCode)
        {
            string uoeGuideNm = "";

            int status;
            //ArrayList uoeGuideNameArray;
            //UOEGuideName uoeGuideName = new UOEGuideName();
            UOEGuideName uoeGuideName;
            //UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();

            try
            {
                // 2008.11.06 30413 ���� UOE�K�C�h�}�X�^�̎擾��Read�ɕύX >>>>>>START
                //uoeGuideName.EnterpriseCode = this._enterpriseCode;
                //uoeGuideName.SectionCode = this._sectionCode;
                //uoeGuideName.UOEGuideDivCd = 3;
                //uoeGuideName.UOEGuideCode = uoeGuideCode;
                
                //status = uoeGuideNameAcs.SearchAll(out uoeGuideNameArray, uoeGuideName);
                //if (status == 0)
                //{
                //    if (uoeGuideNameArray.Count <= 0)
                //    {
                //        return uoeGuideNm;
                //    }

                //    foreach (UOEGuideName wkUOEGuideName in uoeGuideNameArray)
                //    {
                //        if (wkUOEGuideName.UOEGuideCode.Equals(uoeGuideCode))
                //        {
                //            uoeGuideNm = wkUOEGuideName.UOEGuideNm.Trim();
                //            return uoeGuideNm;
                //        }
                //    }
                //}

                status = this._uoeGuideNameAcs.Read(out uoeGuideName, this._enterpriseCode, 3, uoeSupplierCd, uoeGuideCode, this._sectionCode);
                if ((status == 0) && (uoeGuideName.LogicalDeleteCode == 0))
                {
                    uoeGuideNm = uoeGuideName.UOEGuideNm.Trim();
                }
                // 2008.11.06 30413 ���� UOE�K�C�h�}�X�^�̎擾��Read�ɕύX <<<<<<END
            }
            catch
            {
                uoeGuideNm = "";
            }

            return uoeGuideNm;
        }

        /// <summary>
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>�d���於��</returns>
        /// <remarks>
        /// <br>Note       : �d���於�̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetSupplierName(int supplierCd)
        {
            string supplierName = "";

            int status;
            //SupplierAcs supplierInfoAcs = new SupplierAcs();
            Supplier supplier;

            try
            {
                status = this._supplierInfoAcs.Read(out supplier, this._enterpriseCode, supplierCd);
                if ((status == 0) && (supplier.LogicalDeleteCode == 0))
                {
                    supplierName = supplier.SupplierSnm.Trim();
                }
            }
            catch
            {
                supplierName = "";
            }

            return supplierName;
        }

        /// <summary>
        /// �˗��Җ��̎擾����
        /// </summary>
        /// <param name="employeeCode">�˗��҃R�[�h</param>
        /// <returns>�˗��Җ���</returns>
        /// <remarks>
        /// <br>Note       : �˗��Җ��̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            int status;
            Employee employee;

            try
            {
                status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
                if ((status == 0) && (employee.LogicalDeleteCode == 0))
                {
                    employeeName = employee.Name.Trim();
                }
            }
            catch
            {
                employeeName = "";
            }

            return employeeName;
        }

        /// <summary>
        /// �w�苒�_�R���{�{�b�N�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�苒�_�R���{�{�b�N�X��ݒ肵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void InitialSettingUOEResvdSection()
        {
            int status = -1;
            ArrayList retList;
            UOEGuideName uoeGuideName = new UOEGuideName();
            
            // �w�苒�_�̃A�C�e���N���A
            this.UOEResvdSection_tComboEditor.Items.Clear();

            if (this.UOESupplierCd_tNedit.GetInt() == 0)
            {
                // ������R�[�h��������
                return;
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            uoeGuideName.UOEGuideDivCd = 3; // �w�苒�_
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();
            
            status = this._uoeSupplierAcs.GetUOEGuideData(out retList, uoeGuideName);
            if (status == 0)
            {
                foreach (UOEGuideName wkUOEGuideName in retList)
                {
                    this.UOEResvdSection_tComboEditor.Items.Add(wkUOEGuideName.UOEGuideCode, wkUOEGuideName.UOEGuideNm);
                }
                this.UOEResvdSection_tComboEditor.MaxDropDownItems = this.UOEResvdSection_tComboEditor.Items.Count;
            }
        }

        /// <summary>
        /// �[�i�敪�R���{�{�b�N�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �[�i�敪�R���{�{�b�N�X��ݒ肵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void InitialSettingDeliveredGoodsDiv()
        {
            int status = -1;
            ArrayList retList;
            UOEGuideName uoeGuideName = new UOEGuideName();

            // �[�i�敪�̃A�C�e���N���A
            this.DeliveredGoodsDiv_tComboEditor.Items.Clear();

            if (this.UOESupplierCd_tNedit.GetInt() == 0)
            {
                // ������R�[�h��������
                return;
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            uoeGuideName.UOEGuideDivCd = 2; // �[�i�敪
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();

            status = this._uoeSupplierAcs.GetUOEGuideData(out retList, uoeGuideName);
            if (status == 0)
            {
                foreach (UOEGuideName wkUOEGuideName in retList)
                {
                    this.DeliveredGoodsDiv_tComboEditor.Items.Add(wkUOEGuideName.UOEGuideCode, wkUOEGuideName.UOEGuideNm);
                }
                this.DeliveredGoodsDiv_tComboEditor.MaxDropDownItems = this.DeliveredGoodsDiv_tComboEditor.Items.Count;
            }
        }

        /// <summary>
        /// �a�n�敪�R���{�{�b�N�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �a�n�敪�R���{�{�b�N�X��ݒ肵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void InitialSettingBoCode()
        {
            int status = -1;
            ArrayList retList;
            UOEGuideName uoeGuideName = new UOEGuideName();

            // �a�n�敪�̃A�C�e���N���A
            this.BoCode_tComboEditor.Items.Clear();

            if (this.UOESupplierCd_tNedit.GetInt() == 0)
            {
                // ������R�[�h��������
                return;
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            uoeGuideName.UOEGuideDivCd = 1; // �a�n�敪
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();

            status = this._uoeSupplierAcs.GetUOEGuideData(out retList, uoeGuideName);
            if (status == 0)
            {
                foreach (UOEGuideName wkUOEGuideName in retList)
                {
                    this.BoCode_tComboEditor.Items.Add(wkUOEGuideName.UOEGuideCode, wkUOEGuideName.UOEGuideNm);
                }
                this.BoCode_tComboEditor.MaxDropDownItems = this.BoCode_tComboEditor.Items.Count;
            }
        }

        # endregion

        #region ��Control Events
        /// <summary>
        /// Form.Load �C�x���g(PMUOE09020UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void PMUOE09020UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMUOE09020UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void PMUOE09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMUOE09020UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void PMUOE09020UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            Initial_Timer.Enabled = true;
            ScreenClear();
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            if (SaveProc() == false)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// UOE������}�X�^ ���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";
            
            UOESupplier uoeSupplier = null;

            if (this.DataIndex >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
                uoeSupplier = ((UOESupplier)this._uoeSupplierTable[guid]).Clone();
            }

            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            this.DispToUOESupplier(ref uoeSupplier);

            status = this._uoeSupplierAcs.Write(ref uoeSupplier);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��

                        this.UOESupplierCd_tNedit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._uoeSupplierAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._uoeSupplierAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet�W�J����
            UOESupplierToDataSet(uoeSupplier, this.DataIndex);

            return true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                UOESupplier compareUOESupplier = new UOESupplier();
                compareUOESupplier = this._uoeSupplierClone.Clone();
                //���݂̉�ʏ����擾����
                DispToUOESupplier(ref compareUOESupplier);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._uoeSupplierClone.Equals(compareUOESupplier)))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    UOESupplierCd_tNedit.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2);						// �����\���{�^��


            if (result == DialogResult.OK)
            {
                string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
                UOESupplier uoeSupplier = ((UOESupplier)this._uoeSupplierTable[guid]).Clone();

                status = this._uoeSupplierAcs.Delete(uoeSupplier);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this.DataIndex].Delete();
                            this._uoeSupplierTable.Remove(CreateHashKey(uoeSupplier));
                            
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeSupplierAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								  // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                                ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,							  // �v���O��������
                                "Delete_Button_Click",				  // ��������
                                TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                                ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
                                status,								  // �X�e�[�^�X�l
                                this._uoeSupplierAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
            UOESupplier uoeSupplier = ((UOESupplier)_uoeSupplierTable[guid]).Clone();

            status = this._uoeSupplierAcs.Revival(ref uoeSupplier);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._uoeSupplierAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Revive_Button_Click",				  // ��������
                            TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                            ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._uoeSupplierAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // DataSet�W�J����
            UOESupplierToDataSet(uoeSupplier, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// UOE������K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : UOE������K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
        {
            UOESupplier uoeSupplier = null;
            int status = this.ShowUOESupplierGuide(out uoeSupplier);

            if (status == 0)
            {
                // �I������������ʂɐݒ�
                UOESupplierToScreen(uoeSupplier);
                // ���͍��ڂ̗L�������`�F�b�N
                InputEnableCheck();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_MakerGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                // �I�����������擾
                this.tNedit_GoodsMakerCdAllowZero.SetInt(makerUMnt.GoodsMakerCd);
                this.GoodsMakerNm_tEdit.Text = makerUMnt.MakerName;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �d����K�C�h�����C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �d����K�C�h�������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void ultraButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            Supplier supplier = null;
            int status = this.ShowSupplierGuide(out supplier);

            if (status == 0)
            {
                // �I�����������擾
                this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                this.SupplierNm_tEdit.Text = supplier.SupplierSnm;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �o�ɋ��_�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �o�ɋ��_�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOEShipSectGuide_Click(object sender, EventArgs e)
        {
            UOEGuideName uoeGuideName = null;
            string message;
            int status = this.ShowUOEGuideNameGuide(out uoeGuideName);

            if (status == 0)
            {
                // �I�����������擾
                this.UOEShipSectCd_tEdit.Text = uoeGuideName.UOEGuideCode;
                this.UOEShipSectNm_tEdit.Text = uoeGuideName.UOEGuideNm;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (status == -1)
            {
                // ������R�[�h��������
                message = this.UOESupplierCd_Label.Text + "����͂��ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// ���㋒�_�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���㋒�_�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOESalSectGuide_Click(object sender, EventArgs e)
        {
            UOEGuideName uoeGuideName = null;
            string message;
            int status = this.ShowUOEGuideNameGuide(out uoeGuideName);

            if (status == 0)
            {
                // �I�����������擾
                this.UOESalSectCd_tEdit.Text = uoeGuideName.UOEGuideCode;
                this.UOESalSectNm_tEdit.Text = uoeGuideName.UOEGuideNm;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (status == -1)
            {
                // ������R�[�h��������
                message = this.UOESupplierCd_Label.Text + "����͂��ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �w�苒�_�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �w�苒�_�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOEReservSectGuide_Click(object sender, EventArgs e)
        {
            UOEGuideName uoeGuideName = null;
            string message;
            int status = this.ShowUOEGuideNameGuide(out uoeGuideName);

            if (status == 0)
            {
                // �I�����������擾
                this.UOEReservSectCd_tEdit.Text = uoeGuideName.UOEGuideCode;
                this.UOEReservSectNm_tEdit.Text = uoeGuideName.UOEGuideNm;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (status == -1)
            {
                // ������R�[�h��������
                message = this.UOESupplierCd_Label.Text + "����͂��ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �����\���[�J�[�P�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����\���[�J�[�P�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker1Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // �����\���[�J�[���d��
                    message = "�I�����������\���[�J�[�͏d�����Ă��܂��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    this.EnableOdrMakerCd1_tNedit.Focus();
                }
                else
                {
                    // �I�����������擾
                    this.EnableOdrMakerCd1_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm1_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd1_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �����\���[�J�[�Q�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����\���[�J�[�Q�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker2Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // �����\���[�J�[���d��
                    message = "�I�����������\���[�J�[�͏d�����Ă��܂��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    this.EnableOdrMakerCd2_tNedit.Focus();
                }
                else
                {
                    // �I�����������擾
                    this.EnableOdrMakerCd2_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm2_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd2_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �����\���[�J�[�R�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����\���[�J�[�R�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker3Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // �����\���[�J�[���d��
                    message = "�I�����������\���[�J�[�͏d�����Ă��܂��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    this.EnableOdrMakerCd3_tNedit.Focus();
                }
                else
                {
                    // �I�����������擾
                    this.EnableOdrMakerCd3_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm3_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd3_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �����\���[�J�[�S�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����\���[�J�[�S�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker4Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // �����\���[�J�[���d��
                    message = "�I�����������\���[�J�[�͏d�����Ă��܂��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    this.EnableOdrMakerCd4_tNedit.Focus();
                }
                else
                {
                    // �I�����������擾
                    this.EnableOdrMakerCd4_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm4_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd4_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �����\���[�J�[�T�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����\���[�J�[�T�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker5Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // �����\���[�J�[���d��
                    message = "�I�����������\���[�J�[�͏d�����Ă��܂��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    this.EnableOdrMakerCd5_tNedit.Focus();
                }
                else
                {
                    // �I�����������擾
                    this.EnableOdrMakerCd5_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm5_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd5_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �����\���[�J�[�U�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����\���[�J�[�U�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker6Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // �����\���[�J�[���d��
                    message = "�I�����������\���[�J�[�͏d�����Ă��܂��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    this.EnableOdrMakerCd6_tNedit.Focus();
                }
                else
                {
                    // �I�����������擾
                    this.EnableOdrMakerCd6_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm6_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd6_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        // ---ADD 2009/06/01 ------------------------------------------------------------->>>>>
        /// <summary>
        /// �񓚕ۑ��t�H���_�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �񓚕ۑ��t�H���_�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_AnswerSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.AnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
                this.UOELoginUrl_tEdit.Focus();
            }
        }
        // ---ADD 2009/06/01 -------------------------------------------------------------<<<<<

        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// <br>UpdateNote : 2010/05/14 ������ ����UOEWeb���ڂ̑Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool canChangeFocus = true;

            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = new ArrayList();

            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            
            switch (e.PrevCtrl.Name)
            {
                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                case "UOESupplierCd_tNedit":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = UOESupplierCd_tNedit;
                            }
                        }
                        break;
                    }
                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                // ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCdAllowZero":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        if (this.tNedit_GoodsMakerCdAllowZero.GetInt() == 0)
                        {
                            // ���[�J�[���̐ݒ�
                            this.GoodsMakerNm_tEdit.Text = MAKER_CODE_ZERO;
                            break;
                        }
                        
                        // �����ݒ�
                        inParamObj = this.tNedit_GoodsMakerCdAllowZero.GetInt();
                        // ���[�J�[���̎擾
                        outParamObj = this.GetMakerName((int)inParamObj);

                        // ���[�J�[���̂̑��݃`�F�b�N
                        if (!outParamObj.Equals(""))
                        {
                            // ���[�J�[���̐ݒ�
                            this.GoodsMakerNm_tEdit.Text = (string)outParamObj;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // �t�H�[�J�X���d����R�[�h�ɑJ��
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            // �Y���f�[�^����
                            TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                            this.tNedit_GoodsMakerCdAllowZero.Clear();
                            this.GoodsMakerNm_tEdit.Clear();

                            // �t�H�[�J�X�͑J�ڂ��Ȃ�
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // �v���O����
                case "CommAssemblyId_tEdit":
                    {
                        // ���͍��ڂ̗L�������`�F�b�N
                        InputEnableCheck();

                        break;
                    }
                // �o�ɋ��_
                case "UOEShipSectCd_tEdit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        if (this.UOEShipSectCd_tEdit.Text.TrimEnd() != "")
                        {
                            // UOE������R�[�h�̃`�F�b�N
                            if (this.UOESupplierCd_tNedit.Text.Trim() == "")
                            {
                                // ������
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "������R�[�h����͂��Ă��������B",
                                    -1,
                                    MessageBoxButtons.OK);

                                // �t�H�[�J�X��UOE������R�[�h�ɑJ��
                                e.NextCtrl = this.UOESupplierCd_tNedit;
                                break;
                            }

                            // �����ݒ�
                            inParamObj = this.UOEShipSectCd_tEdit.Text.TrimEnd();
                            // �K�C�h���̎擾
                            outParamObj = this.GetUOEGuideName(this.UOESupplierCd_tNedit.GetInt(), (string)inParamObj);

                            // �K�C�h���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �o�ɋ��_���̐ݒ�
                                this.UOEShipSectNm_tEdit.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X�𔄏㋒�_�R�[�h�ɑJ��
                                                e.NextCtrl = this.UOESalSectCd_tEdit;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.UOEShipSectCd_tEdit.Clear();
                                this.UOEShipSectNm_tEdit.Clear();

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.UOEShipSectCd_tEdit.Clear();
                            this.UOEShipSectNm_tEdit.Clear();
                        }
                        break;
                    }
                // ���㋒�_
                case "UOESalSectCd_tEdit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.UOEShipSectCd_tEdit.Text.Trim() != "")
                            {
                                // �o�ɋ��_�R�[�h�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.UOEShipSectCd_tEdit;
                                break;
                            }
                        }

                        if (this.UOESalSectCd_tEdit.Text.TrimEnd() != "")
                        {
                            // UOE������R�[�h�̃`�F�b�N
                            if (this.UOESupplierCd_tNedit.Text.Trim() == "")
                            {
                                // ������
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "������R�[�h����͂��Ă��������B",
                                    -1,
                                    MessageBoxButtons.OK);

                                // �t�H�[�J�X��UOE������R�[�h�ɑJ��
                                e.NextCtrl = this.UOESupplierCd_tNedit;
                                break;
                            }

                            // �����ݒ�
                            inParamObj = this.UOESalSectCd_tEdit.Text.TrimEnd();
                            // �K�C�h���̎擾
                            outParamObj = this.GetUOEGuideName(this.UOESupplierCd_tNedit.GetInt(), (string)inParamObj);

                            // �K�C�h���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // ���㋒�_���̐ݒ�
                                this.UOESalSectNm_tEdit.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X���w�苒�_�R�[�h�ɑJ��
                                                e.NextCtrl = this.UOEReservSectCd_tEdit;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.UOESalSectCd_tEdit.Clear();
                                this.UOESalSectNm_tEdit.Clear();

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.UOESalSectCd_tEdit.Clear();
                            this.UOESalSectNm_tEdit.Clear();
                        }
                        break;
                    }
                // �w�苒�_
                case "UOEReservSectCd_tEdit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.UOESalSectCd_tEdit.Text.Trim() != "")
                            {
                                // ���㋒�_�R�[�h�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.UOESalSectCd_tEdit;
                                break;
                            }
                        }


                        if (this.UOEReservSectCd_tEdit.Text.TrimEnd() != "")
                        {
                            // UOE������R�[�h�̃`�F�b�N
                            if (this.UOESupplierCd_tNedit.Text.Trim() == "")
                            {
                                // ������
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "������R�[�h����͂��Ă��������B",
                                    -1,
                                    MessageBoxButtons.OK);

                                // �t�H�[�J�X��UOE������R�[�h�ɑJ��
                                e.NextCtrl = this.UOESupplierCd_tNedit;
                                break;
                            }

                            // �����ݒ�
                            inParamObj = this.UOEReservSectCd_tEdit.Text.TrimEnd();
                            // �K�C�h���̎擾
                            outParamObj = this.GetUOEGuideName(this.UOESupplierCd_tNedit.GetInt(), (string)inParamObj);

                            // �K�C�h���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �w�苒�_���̐ݒ�
                                this.UOEReservSectNm_tEdit.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X����M�L���敪�ɑJ��
                                                e.NextCtrl = this.ReceiveCondition_tComboEditor;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.UOEReservSectCd_tEdit.Clear();
                                this.UOEReservSectNm_tEdit.Clear();

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.UOEReservSectCd_tEdit.Clear();
                            this.UOEReservSectNm_tEdit.Clear();
                        }
                        break;
                    }
                // �����\���[�J�[�P
                case "EnableOdrMakerCd1_tNedit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        if (e.Key == Keys.Up)
                        {
                            if (this.UOEOrderRate_tEdit.Enabled)
                            {
                                // ���[�g�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.UOEOrderRate_tEdit;
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd1_tNedit.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.EnableOdrMakerCd1_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // �����\���[�J�[���d��
                                TMsgDisp.Show(
                                    this,								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                                    ASSEMBLY_ID,      					            // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�I�����������\���[�J�[�͏d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                    0,          									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // ���[�J�[���̎擾
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // ���[�J�[���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �����\���[�J�[���̂P�ݒ�
                                this.EnableOdrMakerNm1_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd1_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X�𔭒��\���[�J�[�Q�R�[�h�ɑJ��
                                                //e.NextCtrl = this.EnableOdrMakerCd2_tNedit;//DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd1_tComboEditor.Visible && this.MakerCd1_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd1_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd2_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd1_tNedit.Clear();
                                this.EnableOdrMakerNm1_tEdit.Clear();
                                mekaKubenSet(this.MakerCd1_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.EnableOdrMakerCd1_tNedit.Clear();
                            this.EnableOdrMakerNm1_tEdit.Clear();
                            mekaKubenSet(this.MakerCd1_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                        }
                        break;
                    }
                // �����\���[�J�[�Q
                case "EnableOdrMakerCd2_tNedit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd1_tNedit.Text.Trim() != "")
                            {
                                // �����\���[�J�[�R�[�h�P�Ƀt�H�[�J�X�J��
                                //e.NextCtrl = this.EnableOdrMakerCd1_tNedit;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                                if (this.MakerCd1_tComboEditor.Visible && this.MakerCd1_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd1_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd2_tNedit.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.EnableOdrMakerCd2_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // �����\���[�J�[���d��
                                TMsgDisp.Show(
                                    this,								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                                    ASSEMBLY_ID,      					            // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�I�����������\���[�J�[�͏d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                    0,          									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // ���[�J�[���̎擾
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // ���[�J�[���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �����\���[�J�[���̂Q�ݒ�
                                this.EnableOdrMakerNm2_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd2_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X�𔭒��\���[�J�[�R�R�[�h�ɑJ��
                                                //e.NextCtrl = this.EnableOdrMakerCd3_tNedit;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd2_tComboEditor.Visible && this.MakerCd2_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd2_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd3_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd2_tNedit.Clear();
                                this.EnableOdrMakerNm2_tEdit.Clear();
                                mekaKubenSet(this.MakerCd2_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.EnableOdrMakerCd2_tNedit.Clear();
                            this.EnableOdrMakerNm2_tEdit.Clear();
                            mekaKubenSet(this.MakerCd2_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                        }
                        break;
                    }
                // �����\���[�J�[�R
                case "EnableOdrMakerCd3_tNedit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd2_tNedit.Text.Trim() != "")
                            {
                                // �����\���[�J�[�R�[�h�Q�Ƀt�H�[�J�X�J��
                                //e.NextCtrl = this.EnableOdrMakerCd2_tNedit;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                                if (this.MakerCd2_tComboEditor.Visible && this.MakerCd2_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd2_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd2_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd3_tNedit.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.EnableOdrMakerCd3_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // �����\���[�J�[���d��
                                TMsgDisp.Show(
                                    this,								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                                    ASSEMBLY_ID,      					            // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�I�����������\���[�J�[�͏d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                    0,          									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // ���[�J�[���̎擾
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // ���[�J�[���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �����\���[�J�[���̂R�ݒ�
                                this.EnableOdrMakerNm3_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd3_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X�𔭒��\���[�J�[�S�R�[�h�ɑJ��
                                                //e.NextCtrl = this.EnableOdrMakerCd4_tNedit;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd3_tComboEditor.Visible && this.MakerCd3_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd3_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd4_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd3_tNedit.Clear();
                                this.EnableOdrMakerNm3_tEdit.Clear();
                                mekaKubenSet(this.MakerCd3_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.EnableOdrMakerCd3_tNedit.Clear();
                            this.EnableOdrMakerNm3_tEdit.Clear();
                            mekaKubenSet(this.MakerCd3_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                        }
                        break;
                    }
                // �����\���[�J�[�S
                case "EnableOdrMakerCd4_tNedit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd3_tNedit.Text.Trim() != "")
                            {
                                // �����\���[�J�[�R�[�h�R�Ƀt�H�[�J�X�J��
                                //e.NextCtrl = this.EnableOdrMakerCd3_tNedit;//DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                                if (this.MakerCd3_tComboEditor.Visible && this.MakerCd3_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd3_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd3_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd4_tNedit.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.EnableOdrMakerCd4_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // �����\���[�J�[���d��
                                TMsgDisp.Show(
                                    this,								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                                    ASSEMBLY_ID,      					            // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�I�����������\���[�J�[�͏d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                    0,          									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // ���[�J�[���̎擾
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // ���[�J�[���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �����\���[�J�[���̂S�ݒ�
                                this.EnableOdrMakerNm4_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd4_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X�𔭒��\�T�R�[�h�ɑJ��
                                                //e.NextCtrl = this.EnableOdrMakerCd5_tNedit;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd4_tComboEditor.Visible && this.MakerCd4_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd4_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd5_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd4_tNedit.Clear();
                                this.EnableOdrMakerNm4_tEdit.Clear();
                                mekaKubenSet(this.MakerCd4_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.EnableOdrMakerCd4_tNedit.Clear();
                            this.EnableOdrMakerNm4_tEdit.Clear();
                            mekaKubenSet(this.MakerCd4_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                        }
                        break;
                    }
                // �����\���[�J�[�T
                case "EnableOdrMakerCd5_tNedit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd4_tNedit.Text.Trim() != "")
                            {
                                // �����\���[�J�[�R�[�h�S�Ƀt�H�[�J�X�J��
                                //e.NextCtrl = this.EnableOdrMakerCd4_tNedit;//DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                                if (this.MakerCd4_tComboEditor.Visible && this.MakerCd4_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd4_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd4_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd5_tNedit.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.EnableOdrMakerCd5_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // �����\���[�J�[���d��
                                TMsgDisp.Show(
                                    this,								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                                    ASSEMBLY_ID,      					            // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�I�����������\���[�J�[�͏d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                    0,          									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // ���[�J�[���̎擾
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // ���[�J�[���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �����\���[�J�[���̂T�ݒ�
                                this.EnableOdrMakerNm5_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd5_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X�𔭒��\�U�R�[�h�ɑJ��
                                                //e.NextCtrl = this.EnableOdrMakerCd6_tNedit;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd5_tComboEditor.Visible && this.MakerCd5_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd5_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd5_tNedit.Clear();
                                this.EnableOdrMakerNm5_tEdit.Clear();
                                mekaKubenSet(this.MakerCd5_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.EnableOdrMakerCd5_tNedit.Clear();
                            this.EnableOdrMakerNm5_tEdit.Clear();
                            mekaKubenSet(this.MakerCd5_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                        }
                        break;
                    }
                // �����\���[�J�[�U
                case "EnableOdrMakerCd6_tNedit":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd5_tNedit.Text.Trim() != "")
                            {
                                // �����\���[�J�[�R�[�h�T�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.EnableOdrMakerCd5_tNedit;//DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                                if (this.MakerCd5_tComboEditor.Visible && this.MakerCd5_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd5_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd5_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd6_tNedit.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.EnableOdrMakerCd6_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj))
                            {
                                // �����\���[�J�[���d��
                                TMsgDisp.Show(
                                    this,								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                                    ASSEMBLY_ID,      					            // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�I�����������\���[�J�[�͏d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                    0,          									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // ���[�J�[���̎擾
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // ���[�J�[���̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �����\���[�J�[���̂U�ݒ�
                                this.EnableOdrMakerNm6_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd6_tComboEditor, true);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X��ۑ��{�^���ɑJ��
                                                //e.NextCtrl = this.Ok_Button;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd6_tComboEditor.Visible && this.MakerCd6_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd6_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.Ok_Button;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd6_tNedit.Clear();
                                this.EnableOdrMakerNm6_tEdit.Clear();
                                mekaKubenSet(this.MakerCd6_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.EnableOdrMakerCd6_tNedit.Clear();
                            this.EnableOdrMakerNm6_tEdit.Clear();
                            mekaKubenSet(this.MakerCd6_tComboEditor, false);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                        }
                        break;
                    }
                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                // �����\���[�J�[�P�̃n�C�t���ݒ�
                case "MakerCd1_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd1_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                        }
                        break;
                    }
                // �����\���[�J�[�Q�̃n�C�t���ݒ�
                case "MakerCd2_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd2_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd2_tNedit;
                        }
                        break;
                    }
                // �����\���[�J�[�R�̃n�C�t���ݒ�
                case "MakerCd3_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd3_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd3_tNedit;
                        }
                        break;
                    }
                // �����\���[�J�[�S�̃n�C�t���ݒ�
                case "MakerCd4_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd4_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd4_tNedit;
                        }
                        break;
                    }
                // �����\���[�J�[�T�̃n�C�t���ݒ�
                case "MakerCd5_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd5_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd5_tNedit;
                        }
                        break;
                    }
                // �����\���[�J�[�U�̃n�C�t���ݒ�
                case "MakerCd6_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd6_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                        }
                        break;
                    }
                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                #region �d����
                case "tNedit_SupplierCd":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if ((this.tNedit_GoodsMakerCdAllowZero.Text.Trim() != "") && (this.tNedit_GoodsMakerCdAllowZero.GetInt() != 0))
                            {
                                // ���[�J�[�R�[�h�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.tNedit_GoodsMakerCdAllowZero;
                                break;
                            }
                        }

                        if (this.tNedit_SupplierCd.GetInt() != 0)
                        {
                            // �����ݒ�
                            inParamObj = this.tNedit_SupplierCd.GetInt();
                            // �d���於�̎擾
                            outParamObj = this.GetSupplierName((int)inParamObj);

                            // �d���於�̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �d���於�̂̐ݒ�
                                this.SupplierNm_tEdit.DataText = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X��d�b�ԍ��ɑJ��
                                                e.NextCtrl = this.TelNo_tEdit;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������d����R�[�h�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_SupplierCd.Clear();
                                this.SupplierNm_tEdit.Clear();

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.tNedit_SupplierCd.Clear();
                            this.SupplierNm_tEdit.Clear();
                        }

                        // 2008.11.06 30413 ���� ���ł����̎擾���s���̂ō폜 >>>>>>START
                        #region < ���̓`�F�b�N >
                        //if (this.tNedit_SupplierCd.GetInt() != 0)
                        //{
                        //    // ������f�[�^�N���X
                        //    Supplier supplier;
                        //    // ������f�[�^�N���X�C���X�^���X��
                        //    SupplierAcs supplierInfoAcs = new SupplierAcs();

                        //    #region < �������擾���� >
                        //    int status = supplierInfoAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCd.GetInt());
                        //    #endregion

                        //    #region < ��ʕ\������ >

                        //    // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                        //    if ((status == 0) && (supplier.LogicalDeleteCode != 1))

                        //    // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
                        //    {
                        //        #region -- �擾�f�[�^�W�J --
                        //        // �擾�f�[�^�\��
                        //        // ��������ʕ\��
                        //        this.SupplierNm_tEdit.DataText = supplier.SupplierSnm;

                        //        // �t�H�[�J�X��d�b�ԍ��ɑJ��
                        //        e.NextCtrl = this.TelNo_tEdit;
                        //        #endregion
                        //    }
                        //    else
                        //    {
                        //        #region -- �擾���s --
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_INFO,
                        //            this.Name,
                        //            "�Y������d����R�[�h�����݂��܂���B",
                        //            -1,
                        //            MessageBoxButtons.OK);

                        //        this.tNedit_SupplierCd.Clear();
                        //        this.SupplierNm_tEdit.Clear();

                        //        // �t�H�[�J�X�͑J�ڂ��Ȃ�
                        //        e.NextCtrl = e.PrevCtrl;
                        //        #endregion
                        //    }
                        //    #endregion
                        //}
                        //else
                        //{
                        //    // ������
                        //    this.tNedit_SupplierCd.Clear();
                        //    this.SupplierNm_tEdit.Clear();
                        //}
                        #endregion
                        // 2008.11.06 30413 ���� ���ł����̎擾���s���̂ō폜 <<<<<<END
                        break;
                    }
                #endregion
                // �˗��҃R�[�h
                case "tEdit_EmployeeCode":
                    {
                        if (this.tEdit_EmployeeCode.Text.Trim() != "")
                        {
                            // �����ݒ�
                            inParamObj = this.tEdit_EmployeeCode.Text.Trim().PadLeft(4, '0');
                            // �d���於�̎擾
                            outParamObj = this.GetEmployeeName((string)inParamObj);

                            // �d���於�̂̑��݃`�F�b�N
                            if (!outParamObj.Equals(""))
                            {
                                // �˗��Җ��̐ݒ�
                                this.tEdit_EmployeeName.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // �t�H�[�J�X��[�i�敪�ɑJ��
                                                e.NextCtrl = this.DeliveredGoodsDiv_tComboEditor;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // �Y���f�[�^����
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������˗��҃R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.tEdit_EmployeeCode.Clear();
                                this.tEdit_EmployeeName.Clear();

                                // �t�H�[�J�X�͑J�ڂ��Ȃ�
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            this.tEdit_EmployeeCode.Clear();
                            this.tEdit_EmployeeName.Clear();
                        }
                        break;
                    }
                // �d�b�ԍ�
                case "TelNo_tEdit":
                    {
                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.tNedit_SupplierCd.Text.Trim() != "")
                            {
                                // �d����R�[�h�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.tNedit_SupplierCd;
                                break;
                            }
                        }
                        break;
                    }
                // ��M�L���R�[�h
                case "ReceiveCondition_tComboEditor":
                    {
                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.UOEReservSectCd_tEdit.Text.Trim() != "")
                            {
                                // �w�苒�_�R�[�h�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.UOEReservSectCd_tEdit;
                                break;
                            }
                        }
                        break;
                    }
                // �[�i�敪
                case "DeliveredGoodsDiv_tComboEditor":
                    {
                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.tEdit_EmployeeCode.Text.Trim() != "")
                            {
                                // �˗��҃R�[�h�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.tEdit_EmployeeCode;
                                break;
                            }
                        }
                        break;
                    }
                // �ۑ��{�^��
                case "Ok_Button":
                    {
                        // Shift+Tab�̃t�H�[�J�X����
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd6_tNedit.Text.Trim() != "")
                            {
                                // �����\���[�J�[�R�[�h�U�Ƀt�H�[�J�X�J��
                                //e.NextCtrl = this.EnableOdrMakerCd6_tNedit; // DEL 2011/12/15 yangmj for Redmine#27386
                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                if (this.MakerCd6_tComboEditor.Visible && this.MakerCd6_tComboEditor.Enabled)
                                {
                                    e.NextCtrl = this.MakerCd6_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                                }
                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                break;
                            }
                        }
                        else if (e.Key == Keys.Up)
                        {
                            if (this.EnableOdrMakerCd6_tNedit.Enabled)
                            {
                                // �����\���[�J�[�R�[�h�U�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                                break;
                            }
                            else if (this.UOEOrderRate_tEdit.Enabled)
                            {
                                // ���[�g�Ƀt�H�[�J�X�J��
                                e.NextCtrl = this.UOEOrderRate_tEdit;
                                break;
                            }
                        }
                        break;
                    }
                // ���[�g
                case "UOEOrderRate_tEdit":
                    {
                        // ---DEL 2009/06/01 --------------------------------->>>>>
                        //if (e.Key == Keys.Down)
                        //{
                        //    if (this.EnableOdrMakerCd1_tNedit.Enabled)
                        //    {
                        //        // �����\���[�J�[�R�[�h�P�Ƀt�H�[�J�X�J��
                        //        e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                        //        break;
                        //    }
                        //}
                        // ---DEL 2009/06/01 ---------------------------------<<<<<
                        // ---ADD 2009/06/01 --------------------------------->>>>>
                        if (((e.Key == Keys.Enter) && (e.ShiftKey == false)) ||
                            ((e.Key == Keys.Tab) && (e.ShiftKey == false)))
                        {
                            // �����\���[�J�[�^�u�̏ꍇ
                            if (this.Mazda_AnswerAutoDiv_ultraLabel.SelectedTab.Index == 0)
                            {
                                if (this.EnableOdrMakerCd1_tNedit.Enabled)
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                                }
                            }
                            // �O�H�E�V�}�c�_�E�z���_���ڃ^�u�̏ꍇ
                            else if (this.Mazda_AnswerAutoDiv_ultraLabel.SelectedTab.Index == 1)
                            {
                                if (this.EmergencyDiv_tComboEditor.Enabled)
                                {
                                    e.NextCtrl = this.EmergencyDiv_tComboEditor;
                                }
                                else if (this.MazdaSectionCode_tEdit.Enabled)
                                {
                                    e.NextCtrl = this.MazdaSectionCode_tEdit;
                                }
                                else if (this.instrumentNo_tEdit.Enabled)
                                {
                                    e.NextCtrl = this.instrumentNo_tEdit;
                                }
                            }
                            // �z���_e-Parts���ڃ^�u�̏ꍇ
                            else
                            {
                                if (this.AnswerSaveFolder_tEdit.Enabled)
                                {
                                    e.NextCtrl = this.AnswerSaveFolder_tEdit;
                                }
                            }
                        }
                        // ---ADD 2009/06/01 ---------------------------------<<<<<

                        break;
                    }
                // ---ADD 2009/06/01 -------------------------------------------------->>>>>
                case "AnswerSaveFolder_tEdit":
                    {
                        if (((e.Key == Keys.Enter) && (e.ShiftKey == false)) ||
                            ((e.Key == Keys.Tab) && (e.ShiftKey == false)))
                        {
                            if (System.IO.Directory.Exists(this.AnswerSaveFolder_tEdit.Text.Trim()))
                            {
                                e.NextCtrl = this.UOELoginUrl_tEdit;
                            }
                            else
                            {
                                e.NextCtrl = this.uButton_AnswerSaveFolder;
                            }
                        }
                        break;
                    }
                // ---ADD 2009/06/01 --------------------------------------------------<<<<<
                // ---ADD 2010/05/14 -------------------------------------------------->>>>>
                // �c�Ə��t���O
                case "MeiJiUoeEigyousyoFlag_tEdit":
                    {
                        int eigyousyoFlag = 0;
                        int.TryParse(this.MeiJiUoeEigyousyoFlag_tEdit.Text.Trim(), out eigyousyoFlag);
                        if (eigyousyoFlag != 0 && eigyousyoFlag != 1)
                        {
                            this.MeiJiUoeEigyousyoFlag_tEdit.Text = "0";
                        }
                        break;
                    }
                // ---ADD 2010/05/14 --------------------------------------------------<<<<<
            }

            // �t�H�[�J�X����
            if (canChangeFocus == false)
            {
                e.NextCtrl = e.PrevCtrl;

                // ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
                e.NextCtrl.Select();
            }

        }

        // 2008.11.06 30413 ���� �C�x���g���ꊇ�ݒ肵���̂ō폜 >>>>>>START
        #region �ꊇ�ݒ�̂��ߍ폜
        ///// <summary>
        ///// GoodsMakerCd_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void GoodsMakerCd_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// UOEShipSectCd_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void UOEShipSectCd_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// UOESalSectCd_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void UOESalSectCd_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// UOEReservSectCd_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void UOEReservSectCd_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd1_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd1_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd2_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd2_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd3_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd3_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd4_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd4_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd5_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd5_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd6_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd6_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// CommAssemblyId_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.07.02</br>
        ///// </remarks>
        //private void CommAssemblyId_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocus�C�x���g�ꎞ��~
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocus�C�x���g�ĊJ
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}
        #endregion
        // 2008.11.06 30413 ���� �C�x���g���ꊇ�ݒ肵���̂ō폜 <<<<<<END
        
        /// <summary>
        /// �˗��҃K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �˗��҃K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.11.05</br>
        /// </remarks>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.TrimEnd();
                this.tEdit_EmployeeName.DataText = employee.Name;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        # endregion

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // UOE������R�[�h
            int uoeSupplierCd = UOESupplierCd_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsUOESupplierCd = int.Parse((string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[i][UOESUPPLIERCD_TITLE]);
                if (uoeSupplierCd == dsUOESupplierCd)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��UOE��������͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // UOE������R�[�h�̃N���A
                        UOESupplierCd_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��UOE�������񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // UOE������R�[�h�̃N���A
                                UOESupplierCd_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
        /// <summary>
        /// �񓚕ۑ��t�H���_�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �񓚕ۑ��t�H���_�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : xuxh</br>
        /// <br>Date       : 2009/12/29</br>
        /// </remarks>
        private void uButton_AnswerSaveFolder1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.AnswerSaveFolderOfTOYOTA_tEdit.Text = fbd.SelectedPath;
                this.Revive_Button.Focus();
            }
        }

        // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
        // ---ADD 2010/03/08 ---------------------------------------->>>>>
        /// <summary>
        /// �񓚕ۑ��t�H���_�{�^�������C�x���g(���Y)
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �񓚕ۑ��t�H���_�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void uButton_NissanAnswerSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.NissanAnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
                this.Revive_Button.Focus();
            }
        }
        // ---ADD 2010/03/08 ----------------------------------------<<<<<

        // ---ADD 2011/05/10 ----------------------------------------<<<<<
        /// <summary>
        /// �񓚕ۑ��t�H���_�{�^�������C�x���g(�}�c�_)
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �񓚕ۑ��t�H���_�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : �{�z��</br>
        /// <br>Date       : 2011/05/10</br>
        /// </remarks>
        private void uButton_MazdaAnswerSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.MazdaAnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
                this.Revive_Button.Focus();
            }
        }
        // ---ADD 2011/05/10 ----------------------------------------<<<<<
        // ---ADD 2011/10/26 ----------------------------------------<<<<<
        /// <summary>
        /// �o�^�_�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �o�^�_�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void CarMaker_uButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.UOESupplierCd_tNedit.Text.Trim()))
            {
                TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "������R�[�h�������͂ł��B",           // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.OK);                  // �\������{�^��

            }
            else
            {
                this._pmuoe09020ub = new PMUOE09020UB();
                this._pmuoe09020ub.ShowDialog(this.UOESupplierCd_tNedit.Text);
            }

        }
        /// <summary>
        /// SelectionChanged �C�x���g(Connection_tComboEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : SelectionChanged�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void Connection_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (Connection_tComboEditor.SelectedIndex == 0)
            {
                this.CarMaker_uLabel.Visible = true;
                this.CarMaker_uButton.Visible = true;
            }
            else
            {
                this.CarMaker_uLabel.Visible = false;
                this.CarMaker_uButton.Visible = false;
            }
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            // �ڑ��敪��C�^�C�v�̏ꍇ�̂�BL�Ǘ����[�U�[�R�[�h��\��������
            if (Connection_tComboEditor.SelectedIndex == 2)
            {
                this.BLMngUserCode_uLabel.Visible = true;
                this.BLMngUserCode_tEdit.Visible = true;
            }
            else
            {
                this.BLMngUserCode_uLabel.Visible = false;
                this.BLMngUserCode_tEdit.Visible = false;
            }
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        }
        // ---ADD 2011/10/26 ----------------------------------------<<<<<
		// ---ADD 2010/04/23 ---------------------------------------->>>>>
		/// <summary>
		/// �񓚕ۑ��t�H���_�{�^�������C�x���g(�O�H)
		/// </summary>
		/// <param name="sender">�R���g���[��</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note       : �񓚕ۑ��t�H���_�{�^���������̏������s���܂��B</br>
		/// <br>Programmer : jiangk</br>
		/// <br>Date       : 2010/04/23</br>
		/// </remarks>
		private void uButton_MitsubishiAnswerSaveFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult dialogResult = fbd.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.MitsubishiAnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
				this.Revive_Button.Focus();
			}
        }

		// ---ADD 2010/04/23 ----------------------------------------<<<<<
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

       
    }
}
