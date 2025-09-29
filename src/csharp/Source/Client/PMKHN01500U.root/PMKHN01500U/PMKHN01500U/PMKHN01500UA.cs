//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�ǃf�[�^�폜����
// �v���O�����T�v   : �D�ǃf�[�^�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���X��
// �� �� ��  2011/07/13  �C�����e : �A��No.2 �V�K�쐬                      
//----------------------------------------------------------------------------//
//<br>Update Note: 2011/08/30  �A��2 ���X��</br>
// <br>            : REDMINE#23820�̑Ή�</br>
// --------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���N�n��
// �C �� ��  2011/09/06  �C�����e : �D�ǃf�[�^�폜�����̃��b�Z�[�W�{�b�N�X�ɂ��Ă̏C�� FOR redmine #24507
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100068-00 �쐬�S�� : ���t
// �C �� ��  2015/06/08  �C�����e : REDMINE#45792�̑Ή�"���i�}�X�^�폜" �Ɠ�����
//                                  �|���}�X�^�́A�폜����E�폜���Ȃ��𐧌�ł���悤�ɏC������B
//---------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100068-00 �쐬�S�� : ���t
// �C �� ��  2015/08/20  �C�����e : REDMINE#45792�̑Ή�"���i�}�X�^�폜" �Ɠ�����
//                                  �|���}�X�^�́A�폜����E�폜���Ȃ��𐧌�ł���悤�ɏC������B
//---------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinGrid;
using PMKHN01504E;
using Broadleaf.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Application.Controller;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �D�ǃf�[�^�폜����
    /// </summary>
    /// <remarks>
    /// <br>Note        : �D�ǃf�[�^�폜�������s���܂��B</br>
    /// <br>Programmer	: ���X��</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br>Update Nota : 2011/07/21 caohh</br>
    /// <br>            : �D�ǃf�[�^�폜�`�F�b�N���X�g�Ή�</br>
    /// <br>Update Note : 2011/09/06 ���N�n���@</br>
    /// <br>            : �D�ǃf�[�^�폜�����̃��b�Z�[�W�{�b�N�X�ɂ��Ă̏C�� FOR redmine #24507</br>
    /// <br>Update Note : 2015/06/08 ���t</br>
    /// <br>�Ǘ��ԍ�    : 11100068-00 </br>
    /// <br>            : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
    /// </remarks>
    public partial class PMKHN01500UA : Form
    {
        # region Private Constant
        // �N���X��
        private string ct_PRINTNAME = "�D�ǃf�[�^�폜����";
        // ---- ADD caohh 2011/07/21 ----->>>>
        // �v���O����ID
        private const string ct_PGID = "PMKHN01500U";
        // ���[����
        private string _printName = "�D�ǃf�[�^�폜�`�F�b�N���X�g(�폜)";
        // ���[�L�[	
        private string _printKey = "09333d0ef6624f7e8d87f7d191c467e4";
        // ���o�����N���X
        private DeleteCondition _deleteConditionBak;
        // ---- ADD caohh 2011/07/21 -----<<<<
        # endregion

        # region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGroupU> _bLGroupUDic;
        private string _enterpriseCode;
        private DeleteConditionAcs _deleteConditionAcs = null;
        private SearchResultDataSet.ResultTableDataTable _resultTableMaker;
        private SearchResultDataSet.ResultTableDataTable _resultTableMGroup;
        private SearchResultDataSet.ResultTableDataTable _resultTableGroup;
        private DeleteCondition _deleteCondition;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ���O�C���S���Җ���
        private SecInfoAcs _secInfoAcs;                                                                                   // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;                                                            // ���_�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;					                                                        // ���[�J�[�A�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs = null;                                              //���i�����ރA�N�Z�X�N���X
        private BLGroupUAcs _bLGroupUAcs = null;                                                             //BL�O���[�v�A�N�Z�X�N���X
        private Control _prevControl = null;									                                        // ���݂̃R���g���[��
        private int selectCount = 0;
        #endregion

        #region �����ݒ菈��
        /// <summary>
        /// �D�ǃf�[�^�폜����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �D�ǃf�[�^�폜�����̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks>
        public PMKHN01500UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_End"];
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Delete"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            //this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];//DEL by Liangsd     2011/08/30
            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._bLGroupUAcs = new BLGroupUAcs();
            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            // ���[�J�[�}�X�^�Ǎ�����
            LoadMakerUMnt();
            //���i�����ރ}�X�^�Ǎ�����
            LoadGoodsGroupU();
            //BL�O���[�v�Ǎ�����
            LoadBLGroupU();
            GetGridDate();
            this.dataGrid.DataSource = this._resultTableMaker;
        }
        # endregion

        #region �c�[���o�[�����ݒ菈��
        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer	: ���X��</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;

            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }
        # endregion

        #region �C�x���g
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h�C�x���g�������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void PMKHN01500U_Load(object sender, EventArgs e)
        {
            ToolBarInitilSetting();
            //this.tEdit_SectionCode.Text = "00";//DEL by Liangsd     2011/08/30
            //this.tEdit_SectionName.Text = "�S��";//DEL by Liangsd     2011/08/30
            this.deleteCombo.SelectedIndex = 0;
            this.ultraLabelMaker.Visible = false;
            this.tNedit_MakerCode.Visible = false;
            this.tNedit_MakerName.Visible = false;
            this.ultraLabel_Change.Text = "���[�J�[";
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            textClear();
            this.MaximizeBox = false;
        }
        #endregion

        #region ���_���̎擾����
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_���̎擾�������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');
            // 00�� ���_���̂͑S��
            if (sectionCode == "00")
            {
                return "�S��";
            }
            //���_���̎擾
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }
            return "";
        }
        # endregion

        #region ���_���}�X�^�Ǎ�����
        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            // ���_���}�X�^�Ǎ�
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }
        # endregion

        #region ���[�J�[�}�X�^�Ǎ�����
        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;
                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }
        #endregion

        #region Ұ�����擾����
        /// <summary>
        /// Ұ�����擾����
        /// </summary>
        /// <param name="goodsMakerCd">Ұ���R�[�h</param>
        /// <returns>Ұ����</returns>
        /// <remarks>
        /// <br>Note       : Ұ�����擾�������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetGoodsMakerNm(int goodsMakerCd)
        {
            if (this._makerUMntDic.ContainsKey(goodsMakerCd))
            {
                return this._makerUMntDic[goodsMakerCd].MakerName.Trim();
            }

            return "";
        }
        #endregion

        #region ���i�����ރ}�X�^�Ǎ�����
        /// <summary>
        /// ���i�����ރ}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    //�Ǎ�����
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }
        #endregion

        #region ���i�����ޖ��擾����
        /// <summary>
        /// ���i�����ޖ��擾����
        /// </summary>
        /// <param name="goodsGroupcode">���i�����ރR�[�h</param>
        /// <returns>���i�����ޖ�</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ޖ��擾�������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetGoodsGroupName(int goodsGroupcode)
        {
            if (this._goodsGroupUDic.ContainsKey(goodsGroupcode))
            {
                return this._goodsGroupUDic[goodsGroupcode].GoodsMGroupName.Trim();
            }

            return "";
        }
        #endregion

        #region BL�O���[�v�}�X�^�Ǎ�����
        /// <summary>
        /// BL�O���[�v�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void LoadBLGroupU()
        {
            this._bLGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._bLGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            this._bLGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._bLGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }
        #endregion

        #region BL�O���[�v���擾����
        /// <summary>
        /// BL�O���[�v���擾����
        /// </summary>
        /// <param name="bLGroupcode">BL�O���[�v�R�[�h</param>
        /// <returns> BL�O���[�v��</returns>
        /// <remarks>
        /// <br>Note       :  BL�O���[�v���擾�������s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetBLGroupName(int bLGroupcode)
        {
            if (this._bLGroupUDic.ContainsKey(bLGroupcode))
            {
                return this._bLGroupUDic[bLGroupcode].BLGroupName.Trim();
            }

            return "";
        }
        #endregion

        #region ChangeFocus �C�x���g
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2011/09/06 ���N�n���@</br>
        /// <br>           : �D�ǃf�[�^�폜�����̃��b�Z�[�W�{�b�N�X�ɂ��Ă̏C�� FOR redmine #24507</br>
        /// <br>Update Note: 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�   : 11100068-00 </br>
        /// <br>           : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                //#region ���_
                ////���_
                //case "tEdit_SectionCode":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                if (this.tEdit_SectionCode.Text == "")
                //                {
                //                    e.NextCtrl = this.SectionGuide_Button;
                //                }
                //                else
                //                {
                //                    e.NextCtrl = this.deleteCombo;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                e.NextCtrl = this.tEdit_SectionCode;
                //            }
                //        }
                //        string code = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
                //        // ���͖���
                //        if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                //        {
                //            this.tEdit_SectionName.Text = "";
                //            return;
                //        }
                //        if (GetSectionName(code) == "" && this.tEdit_SectionCode.Text != "")
                //        {
                //            this.tEdit_SectionCode.Text = "";
                //            this.tEdit_SectionName.Text = "";
                //            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y�����鋒�_�����݂��Ȃ�",0);
                //            this.tEdit_SectionCode.Focus();
                //        }
                //        this.tEdit_SectionName.Text = GetSectionName(code);
                //        break;
                //    }
                //#endregion
                //#region �K�C�h�o�[�e��
                ////�K�C�h�o�[�e��
                //case "SectionGuide_Button":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                    e.NextCtrl = this.deleteCombo;
                //            }
                //        }
                //        else
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                //e.NextCtrl = this.tEdit_SectionCode;
                //            }
                //        }
                //        break;
                //    }
                //#endregion
                //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<

                #region �폜�敪
                case "deleteCombo":
                    {
                        if (this.deleteCombo.SelectedIndex == 0)
                        {
                            // �t�H�[�J�X�ݒ�
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.tNedit_Code1;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;//DEL by Liangsd     2011/08/30
                                    e.NextCtrl = this.deleteCombo;//ADD by Liangsd    2011/08/30
                                }
                            }
                            this.ultraLabelMaker.Visible = false;
                            this.tNedit_MakerCode.Visible = false;
                            this.tNedit_MakerName.Visible = false;
                            this.ultraLabel_Change.Text = "���[�J�[";
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.tNedit_MakerCode;
                                    ChangeToMakerData();
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;//DEL by Liangsd     2011/08/30
                                    e.NextCtrl = this.deleteCombo;//ADD by Liangsd    2011/08/30
                                }
                            }
                            this.ultraLabelMaker.Visible = true;
                            this.tNedit_MakerCode.Visible = true;
                            this.tNedit_MakerName.Visible = true;
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                this.ultraLabel_Change.Text = "������";
                            }
                            else
                            {
                                this.ultraLabel_Change.Text = "�O���[�v�R�[�h";
                            }

                        }
                        break;
                    }
                #endregion

                #region ���[�J�[
                //���[�J�[
                case "tNedit_MakerCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code1;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.deleteCombo;
                            }
                        }
                        int code = this.tNedit_MakerCode.GetInt();
                        // ���͖���
                        if (code == 0)
                        {
                            this.tNedit_MakerCode.Text = "";
                            this.tNedit_MakerName.Text = "";
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            return;
                        }
                        else
                        {
                            if (GetGoodsMakerNm(code) == "")
                            {
                                e.NextCtrl = this.tNedit_MakerCode;
                                this.tNedit_MakerCode.Text = "";
                                this.tNedit_MakerName.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                            }
                        }
                        this.tNedit_MakerName.Text = GetGoodsMakerNm(code);
                        CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        break;
                    }
                #endregion

                #region �R�[�h�P
                case "tNedit_Code1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code2;
                            }
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.deleteCombo;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.tNedit_MakerCode;
                                }
                            }
                        }
                        int code = this.tNedit_Code1.GetInt();
                        // ���͖����ƌJ��Ԃ�
                        if (code == this.tNedit_Code2.GetInt() || code == this.tNedit_Code3.GetInt() || code == this.tNedit_Code4.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code1.Text = "";
                                this.tEdit_Name1.Text = "";
                                this.tNedit_Code1.Focus();
                            }
                            else
                            {
                                this.tNedit_Code1.Text = "";
                                this.tEdit_Name1.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                if (this.ultraLabel_Change.Text == "���[�J�[")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "������")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code1.Focus();
                            }
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {

                                if (GetGoodsMakerNm(this.tNedit_Code1.GetInt()) == "" && this.tNedit_Code1.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code1;
                                    this.tNedit_Code1.Text = "";
                                    this.tEdit_Name1.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name1.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);

                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code1.GetInt()) == "" && this.tNedit_Code1.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code1;
                                    this.tNedit_Code1.Text = "";
                                    this.tEdit_Name1.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name1.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code1.GetInt()) == "" && this.tNedit_Code1.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code1;
                                    this.tNedit_Code1.Text = "";
                                    this.tEdit_Name1.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name1.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region �R�[�h�Q
                case "tNedit_Code2":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code3;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code1;
                            }
                        }
                        int code = this.tNedit_Code2.GetInt();
                        // ���͖����ƌJ��Ԃ�
                        if (code == this.tNedit_Code1.GetInt() || code == this.tNedit_Code3.GetInt() || code == this.tNedit_Code4.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code2.Text = "";
                                this.tEdit_Name2.Text = "";
                                this.tNedit_Code2.Focus();
                            }
                            else
                            {
                                this.tNedit_Code2.Text = "";
                                this.tEdit_Name2.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                if (this.ultraLabel_Change.Text == "���[�J�[")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "������")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code2.Focus();
                            }
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {

                                if (GetGoodsMakerNm(this.tNedit_Code2.GetInt()) == "" && this.tNedit_Code2.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code2;
                                    this.tNedit_Code2.Text = "";
                                    this.tEdit_Name2.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name2.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);

                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code2.GetInt()) == "" && this.tNedit_Code2.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code2;
                                    this.tNedit_Code2.Text = "";
                                    this.tEdit_Name2.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name2.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code2.GetInt()) == "" && this.tNedit_Code2.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code2;
                                    this.tNedit_Code2.Text = "";
                                    this.tEdit_Name2.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name2.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region �R�[�h 3
                case "tNedit_Code3":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code4;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code2;
                            }
                        }
                        int code = this.tNedit_Code3.GetInt();
                        // ���͖����ƌJ��Ԃ�
                        if (code == this.tNedit_Code1.GetInt() || code == this.tNedit_Code2.GetInt() || code == this.tNedit_Code4.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code3.Text = "";
                                this.tEdit_Name3.Text = "";
                                this.tNedit_Code3.Focus();
                            }
                            else
                            {
                                this.tNedit_Code3.Text = "";
                                this.tEdit_Name3.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                if (this.ultraLabel_Change.Text == "���[�J�[")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "������")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code3.Focus();
                            }
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {
                                if (GetGoodsMakerNm(this.tNedit_Code3.GetInt()) == "" && this.tNedit_Code3.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code3;
                                    this.tNedit_Code3.Text = "";
                                    this.tEdit_Name3.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name3.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);

                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code3.GetInt()) == "" && this.tNedit_Code3.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code3;
                                    this.tNedit_Code3.Text = "";
                                    this.tEdit_Name3.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name3.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code3.GetInt()) == "" && this.tNedit_Code3.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code3;
                                    this.tNedit_Code3.Text = "";
                                    this.tEdit_Name3.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name3.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region �R�[�h 4
                case "tNedit_Code4":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.goodsComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code3;
                            }
                        }
                        int code = this.tNedit_Code4.GetInt();
                        // ���͖����ƌJ��Ԃ�
                        if (code == this.tNedit_Code1.GetInt() || code == this.tNedit_Code2.GetInt() || code == this.tNedit_Code3.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code4.Text = "";
                                this.tEdit_Name4.Text = "";
                                this.tNedit_Code4.Focus();
                            }
                            else
                            {
                                this.tNedit_Code4.Text = "";
                                this.tEdit_Name4.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                if (this.ultraLabel_Change.Text == "���[�J�[")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "������")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code4.Focus();
                            }
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {
                                if (GetGoodsMakerNm(this.tNedit_Code4.GetInt()) == "" && this.tNedit_Code4.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code4;
                                    this.tNedit_Code4.Text = "";
                                    this.tEdit_Name4.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name4.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code4.GetInt()) == "" && this.tNedit_Code4.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code4;
                                    this.tNedit_Code4.Text = "";
                                    this.tEdit_Name4.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name4.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code4.GetInt()) == "" && this.tNedit_Code4.Text != "")
                                {
                                    e.NextCtrl = this.tNedit_Code4;
                                    this.tNedit_Code4.Text = "";
                                    this.tEdit_Name4.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂���܂�", 0);
                                    if (this.ultraLabel_Change.Text == "���[�J�[")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������[�J�[�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "������")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂������i�����ރR�[�h�͑��݂��܂���B", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���͂����O���[�v�R�[�h�͑��݂��܂���B", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name4.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region Grid
                //Grid
                case "dataGrid":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.goodsComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code4;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���i�}�X�^
                case "goodsComboEditor":
                    {
                        if (this.goodsComboEditor.SelectedIndex == 1)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.joinComboEditor;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.tNedit_Code4;
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.goodsStockComboEditor;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.tNedit_Code4;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���i�݌ɕi�戵��
                case "goodsStockComboEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.joinComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.goodsComboEditor;
                            }
                        }
                        break;
                    }
                #endregion

                #region �����}�X�^
                case "joinComboEditor":
                    {
                        if (this.joinComboEditor.SelectedIndex == 1)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // e.NextCtrl = this.joinComboEditor; // Del 2015/06/08 ���t for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                                    e.NextCtrl = this.rateComboEditor; // Add 2015/06/08 ���t for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                                }
                            }
                            else
                            {
                                if (this.goodsComboEditor.SelectedIndex == 1)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsComboEditor;
                                    }
                                }
                                else
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsStockComboEditor;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.joinStockComboEditor;
                                }
                            }
                            else
                            {
                                if (this.goodsComboEditor.SelectedIndex == 1)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsComboEditor;
                                    }
                                }
                                else
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsStockComboEditor;
                                    }
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �����݌ɕi�戵��
                case "joinStockComboEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // e.NextCtrl = this.joinComboEditor; // Del ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                                e.NextCtrl = this.rateComboEditor; // Add ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.joinComboEditor;
                            }
                        }
                        break;
                    }
                #endregion

                // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                #region �|���}�X�^
                case "rateComboEditor":
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.rateComboEditor.SelectedIndex == 1)
                            {
                                if (e.ShiftKey == false)
                                {
                                    e.NextCtrl = this.rateComboEditor;
                                }
                                else if (this.joinComboEditor.SelectedIndex == 1)
                                {
                                    e.NextCtrl = this.joinComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.joinStockComboEditor;
                                }
                            }
                            else
                            {
                                if (e.ShiftKey == false)
                                {
                                    //e.NextCtrl = this.rateStockComboEditor; // DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                                    e.NextCtrl = this.rateComboEditor; // ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                                }
                                else if (this.joinComboEditor.SelectedIndex == 1)
                                {
                                    e.NextCtrl = this.joinComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.joinStockComboEditor;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                //#region �|���݌ɕi�戵��
                //case "rateStockComboEditor":
                //    {
                //        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //        {
                //            if (e.ShiftKey == false)
                //            {
                //                e.NextCtrl = this.rateStockComboEditor;
                //            }
                //            else
                //            {
                //                e.NextCtrl = this.rateComboEditor;
                //            }
                //        }
                //        break;
                //    }
                //#endregion
                // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<
                // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
            }
        }
        #endregion

        #region �O���b�h�񏉊��ݒ菈��
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void dataGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMaker;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            // �I���`�F�b�N�{�b�N�X
            columns[table.ChooseColColumn.ColumnName].Header.Caption = "�I��";
            columns[table.ChooseColColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.ChooseColColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            columns[table.ChooseColColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            columns[table.ChooseColColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[table.ChooseColColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;

            // ����
            columns[table.CodeColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "���[�J�[����";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;

            // �\�����ݒ�
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;

        }
        #endregion

        #region �O���b�h��Click
        /// <summary>
        /// �O���b�h��Click
        /// </summary>
        /// <remarks>
        /// <br>Note		: �O���b�hClick�̎��A�f�[�^�ݒ菈�����s���܂��B</br> 
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void dataGrid_Click(object sender, EventArgs e)
        {
            // �C�x���g�\�[�X�̎擾
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            try
            {
                // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElement���擾����B
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                    return;

                // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                    (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                if (objHeader != null) return;

                // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                    (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                if (objRow == null) return;

                // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                    (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                // �I���E��I���Z���ȊO�̓L�����Z��
                if (objCell == null || objCell.Column.Key != "ChooseCol") return;
                GridClick(objRow, false, true);
            }
            catch
            {
            }
        }
        #endregion

        #region �O���b�h��DoubleClick
        /// <summary>
        /// �O���b�h��DoubleClick
        /// </summary>
        /// <remarks>
        /// <br>Note		: �O���b�hsDoubleClick�̎��A�f�[�^�ݒ菈�����s���܂��B</br> 
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            // �C�x���g�\�[�X�̎擾
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾����B
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
            UltraGridRow dr = dataGrid.ActiveRow;
            GridClick(dr, false, true);
        }
        #endregion

        #region �폜�敪ValueChange �C�x���g
        /// <summary>
        /// �폜�敪ValueChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �폜�敪ValueChange �C�x���g���s���܂�</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void DeleteComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //���[�J�[
            if (this.deleteCombo.SelectedIndex == 0)
            {
                this.ultraLabelMaker.Visible = false;
                this.tNedit_MakerCode.Visible = false;
                this.tNedit_MakerName.Visible = false;
                this.ultraLabel_Change.Text = "���[�J�[";
                this.tNedit_Code1.Focus();
                this.selectCount = 0;
                textClear();
            }
            else
            {
                textClear();
                this.ultraLabelMaker.Visible = true;
                this.tNedit_MakerCode.Visible = true;
                this.tNedit_MakerName.Visible = true;
                //������
                if (this.deleteCombo.SelectedIndex == 1)
                {
                    this.selectCount = 0;
                    this.ultraLabel_Change.Text = "������";
                    this.tNedit_MakerCode.Focus();
                }
                //�O���[�v�R�[�h
                else
                {
                    this.selectCount = 0;
                    this.ultraLabel_Change.Text = "�O���[�v�R�[�h";
                    this.tNedit_MakerCode.Focus();
                }
            }
        }
        #endregion

        #region ���i�}�X�^ValueChange �C�x���g
        /// <summary>
        /// ���i�}�X�^ValueChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^ValueChange �C�x���g���s���܂�</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void goodsComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.goodsComboEditor.SelectedIndex == 1)
            {
                this.goodsStockComboEditor.Text = "";
                this.goodsStockComboEditor.Enabled = false;
            }
            else
            {
                this.goodsStockComboEditor.Enabled = true;
                this.goodsStockComboEditor.SelectedIndex = 0;
            }
        }
        #endregion

        #region �����}�X�^ValueChange �C�x���g
        /// <summary>
        /// �����}�X�^ValueChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����}�X�^ValueChange �C�x���g���s���܂�</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void joinComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.joinComboEditor.SelectedIndex == 1)
            {
                this.joinStockComboEditor.Text = "";
                this.joinStockComboEditor.Enabled = false;
            }
            else
            {
                this.joinStockComboEditor.SelectedIndex = 0;
                this.joinStockComboEditor.Enabled = true;
            }
        }
        #endregion

        // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
        //// ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��---->>>>>
        //#region �|���}�X�^ValueChange �C�x���g
        ///// <summary>
        ///// �|���}�X�^ValueChange �C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�n���h��</param>
        ///// <remarks>
        ///// <br>Note       : �|���}�X�^ValueChange �C�x���g���s���܂�</br>
        ///// <br>Programmer : ���t</br>
        ///// <br>Date       : 2015/06/08</br>
        ///// </remarks>
        //private void rateComboEditor_ValueChanged(object sender, EventArgs e)
        //{
        //    if (this.rateComboEditor.SelectedIndex == 1)
        //    {
        //        this.rateStockComboEditor.Text = "";
        //        this.rateStockComboEditor.Enabled = false;
        //    }
        //    else
        //    {
        //        this.rateStockComboEditor.SelectedIndex = 0;
        //        this.rateStockComboEditor.Enabled = true;
        //    }
        //}
        //#endregion
        //// ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��----<<<<<
        // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<

        #region ���i�����ޖ��擾
        /// <summary>
        /// ���i�����ޖ��擾
        /// </summary>
        /// <param name="codeNum">����code</param>
        /// <param name="outName">���i�����ޖ�</param>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// <returns></returns>
        private string GetMNameCommon(int codeNum)
        {
            string outName = "";
            int code = codeNum;
            // ���͖���
            if (string.IsNullOrEmpty(codeNum.ToString()))
            {
                outName = "";
            }
            else
            {
                outName = GetGoodsGroupName(code);
            }
            return outName;
        }
        #endregion

        #region  BL�O���[�v���擾
        /// <summary>
        /// BL�O���[�v���擾
        /// </summary>
        /// <param name="codeNum">����code</param>
        /// <param name="outName">BL�O���[�v��</param>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// <returns></returns>
        private string GetBLGroupNameCommon(int codeNum)
        {
            string outName = "";
            int code = codeNum;
            // ���͖���
            if (string.IsNullOrEmpty(codeNum.ToString()))
            {
                outName = "";
            }
            else
            {
                outName = GetBLGroupName(code);
            }
            return outName;
        }
        #endregion

        #region �c�[���o�[�N���b�N�C�x���g
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case "ButtonTool_End":
                    {
                        // �I������
                        Close();
                        break;
                    }
                //�폜
                case "ButtonTool_Delete":
                    {
                        //�폜����
                        DeleteAll();
                        break;
                    }
            }
        }
        #endregion

        #region �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �폜�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�   : 11100068-00 </br>
        /// <br>           : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
        /// </remarks>
        private void DeleteAll()
        {
            if (BeforeDeleteCheck())
            {
                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                if (this._prevControl != null)
                {
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                    this.tArrowKeyControl1_ChangeFocus(this, e);
                }
                // �m�F���b�Z�[�W��\������B
                DialogResult result = TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,             // �G���[���x��
                            "PMKHN01500UA",						            // �A�Z���u���h�c�܂��̓N���X�h�c
                            ct_PRINTNAME,				                    // �v���O��������
                            "", 								            // ��������
                            "",									            // �I�y���[�V����
                            "�폜�������J�n���Ă���낵���ł����H",		// �\�����郁�b�Z�[�W
                            -1, 							                // �X�e�[�^�X�l
                            null, 								            // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.YesNo, 				        // �\������{�^��
                            MessageBoxDefaultButton.Button1);	            // �����\���{�^��
                // ���͉�ʂ֖߂�B
                if (result == DialogResult.No)
                {
                    return;
                }

                // ���o����ʕ��i�̃C���X�^���X���쐬
                SFCMN00299CA msgForm = new SFCMN00299CA();
                msgForm.Title = "�폜��";
                msgForm.Message = "�폜���ł��B";
                try
                {
                    msgForm.Show();

                    string msg = string.Empty;
                    //�폜�O�f�[�^�ݒ�
                    _deleteCondition = new DeleteCondition();
                    _deleteConditionAcs = DeleteConditionAcs.GetInstance();
                    _deleteCondition.DeleteCode = this.deleteCombo.SelectedIndex;
                    //�f�[�^�N���A
                    this.goodsNotDelLabel.Text = "0 ��";
                    this.joinNotDelLabel.Text = "0 ��";
                    this.joinDeleteLabel.Text = "0 ��";
                    this.goodsDeleteLabel.Text = "0 ��";
                    this.stockNotDelLabel.Text = "0 ��";
                    this.stockDeleteLabel.Text = "0 ��";
                    // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                    //this.rateNotDelLabel.Text = "0 ��";//DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    this.rateDeleteLabel.Text = "0 ��";
                    // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                    this._deleteCondition.StockDeleteCnt = 0;
                    this._deleteCondition.GoodsDeleteCnt = 0;
                    this._deleteCondition.JoinDeleteCnt = 0;
                    this._deleteCondition.RateDeleteCnt = 0; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    this._deleteCondition.StockNotDeleteCnt = 0;
                    this._deleteCondition.GoodsNotDeleteCnt = 0;
                    this._deleteCondition.JoinNotDeleteCnt = 0;
                    this._deleteCondition.RateNotDeleteCnt = 0; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                    /* ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    //�폜�敪 = ���[�J�[
                    if (this.deleteCombo.SelectedIndex == 0)
                    {
                       ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                        _deleteCondition.EnterpriseCode = this._enterpriseCode;
                        //_deleteCondition.SectionCode = this.tEdit_SectionCode.Text;//DEL by Liangsd     2011/08/30
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                        //�폜�敪 <> ���[�J�[
                        if (this.deleteCombo.SelectedIndex != 0)
                        {
                            _deleteCondition.GoodsMakerCode = this.tNedit_MakerCode.GetInt();
                        }
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                        _deleteCondition.Code1 = this.tNedit_Code1.GetInt();
                        _deleteCondition.Code2 = this.tNedit_Code2.GetInt();
                        _deleteCondition.Code3 = this.tNedit_Code3.GetInt();
                        _deleteCondition.Code4 = this.tNedit_Code4.GetInt();
                        //���i�}�X�^�폜�敪
                        if (this.goodsComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.GoodsDeleteCode = this.goodsStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //�폜���Ȃ�
                            _deleteCondition.GoodsDeleteCode = 9;
                        }
                        //�����}�X�^�폜�敪
                        if (this.joinComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.JoinDeleteCode = this.joinStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //�폜���Ȃ�
                            _deleteCondition.JoinDeleteCode = 9;
                        }
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                        //�|���}�X�^�폜�敪
                        if (this.rateComboEditor.SelectedIndex == 0)
                        {
                            //_deleteCondition.RateDeleteCode = this.rateStockComboEditor.SelectedIndex + 1; //DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                            _deleteCondition.RateDeleteCode = 0; //ADD ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                        }
                        else
                        {
                            //�폜���Ȃ�
                            _deleteCondition.RateDeleteCode = 9;
                        }
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                    /* ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                    }
                    else
                    {
                        _deleteCondition.EnterpriseCode = this._enterpriseCode;
                        //_deleteCondition.SectionCode = this.tEdit_SectionCode.Text;//DEL by Liangsd     2011/08/30
                        _deleteCondition.GoodsMakerCode = this.tNedit_MakerCode.GetInt();
                        _deleteCondition.Code1 = this.tNedit_Code1.GetInt();
                        _deleteCondition.Code2 = this.tNedit_Code2.GetInt();
                        _deleteCondition.Code3 = this.tNedit_Code3.GetInt();
                        _deleteCondition.Code4 = this.tNedit_Code4.GetInt();
                        //���i�}�X�^�폜�敪
                        if (this.goodsComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.GoodsDeleteCode = this.goodsStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //�폜���Ȃ�
                            _deleteCondition.GoodsDeleteCode = 9;
                        }
                        //�����}�X�^�폜�敪
                        if (this.joinComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.JoinDeleteCode = this.joinStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //�폜���Ȃ�
                            _deleteCondition.JoinDeleteCode = 9;
                        }
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
                        //�|���}�X�^�폜�敪
                        if (this.rateComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.RateDeleteCode = this.rateStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //�폜���Ȃ�
                            _deleteCondition.RateDeleteCode = 9;
                        }
                        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                    }
                       ----- DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<*/
                    // �폜����
                    // ---- ADD caohh 2011/07/21 ---->>>>
                    _deleteConditionBak = new DeleteCondition();
                    _deleteConditionBak = _deleteCondition;
                    // �D�ǃf�[�^�폜�`�F�b�N���X�g���o�͂���ꍇ
                    if (_deleteCondition.GoodsDeleteCode == 3 || _deleteCondition.GoodsDeleteCode == 4)
                    {
                        status = this._deleteConditionAcs.SearchMain(ref msg, ref this._deleteCondition);
                    }
                    // ---- ADD caohh 2011/07/21 ----<<<<

                    status = this._deleteConditionAcs.DeleteData(ref msg, ref _deleteCondition);

                    switch (status)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            this.stockDeleteLabel.Text = this._deleteCondition.StockDeleteCnt + " ��";
                            this.goodsDeleteLabel.Text = this._deleteCondition.GoodsDeleteCnt + " ��";
                            this.joinDeleteLabel.Text = this._deleteCondition.JoinDeleteCnt + " ��";
                            this.rateDeleteLabel.Text = this._deleteCondition.RateDeleteCnt + " ��"; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                            if (this.goodsComboEditor.SelectedIndex != 1)
                            {
                                this.stockNotDelLabel.Text = this._deleteCondition.StockNotDeleteCnt + " ��";
                            }
                            if (this.goodsStockComboEditor.SelectedIndex == 1 || this.goodsStockComboEditor.SelectedIndex == 3)
                            {
                                this.goodsNotDelLabel.Text = this._deleteCondition.GoodsNotDeleteCnt + " ��";
                            }
                            if (this.joinStockComboEditor.SelectedIndex == 1)
                            {
                                this.joinNotDelLabel.Text = this._deleteCondition.JoinNotDeleteCnt + " ��";
                            }
                            // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----->>>>>
                            //// ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� --->>>>>
                            //if (this.rateStockComboEditor.SelectedIndex == 1)
                            //{
                            //    this.rateNotDelLabel.Text = this._deleteCondition.RateNotDeleteCnt + " ��";
                            //}
                            //// ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<
                            // --- DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� -----<<<<<
                            // �t�H�[�J�X�͋��_�ɖ߂�
                            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
                            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30
                            msgForm.Close();
                            // if (this._deleteCondition.StockDeleteCnt != 0 || this._deleteCondition.GoodsDeleteCnt != 0 || this._deleteCondition.JoinDeleteCnt != 0) // DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                            if (this._deleteCondition.StockDeleteCnt != 0 || this._deleteCondition.GoodsDeleteCnt != 0 || this._deleteCondition.JoinDeleteCnt != 0 || this._deleteCondition.RateDeleteCnt != 0) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�폜����", 0);
                            }
                            else
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�폜�Ώۂ�����܂���", 0);
                            }
                            // ---- ADD caohh 2011/07/21 ---->>>>
                            // �D�ǃf�[�^�폜�`�F�b�N���X�g���o�͂���ꍇ
                            if ((_deleteConditionBak.GoodsDeleteCode == 3 || _deleteConditionBak.GoodsDeleteCode == 4) && (this._deleteCondition.StockDeleteCnt != 0 || this._deleteCondition.GoodsDeleteCnt != 0))
                            {
                                SFCMN06002C parameter = new SFCMN06002C();
                                status = Print(ref parameter);
                            }
                            // ---- ADD caohh 2011/07/21 ----<<<<
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            "PMKHN01500UA",							// �A�Z���u��ID
                            "�D�ǃf�[�^�폜����\n���ɑ��[���ɂ��X�V����Ă���ׁA�����𒆒f���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B",	    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                            // �t�H�[�J�X�͋��_�ɖ߂�
                            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
                            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30

                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            "PMKHN01500UA",							// �A�Z���u��ID
                            "�D�ǃf�[�^�폜������\n���ɑ��[���ɂ��폜����Ă���ׁA�����𒆒f���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B",	    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                            // �t�H�[�J�X�͋��_�ɖ߂�
                            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
                            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30
                            break;

                        default:
                            MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�폜�Ɏ��s���܂����B", 0);
                            break;
                    }
                }
                finally
                {
                    msgForm.Close();
                }


            }
        }
        #endregion

        #region �폜�O�`�F�b�N
        /// <summary>
        /// �폜�O�`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �폜�O�`�F�b�N���s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�   : 11100068-00 </br>
        /// <br>           : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>     
        /// </remarks>
        private bool BeforeDeleteCheck()
        {
            //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
            //// ���_���̓`�F�b�N
            //if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
            //{
            //    // �Y���Ȃ�
            //    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
            //                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
            //                    this.Name,											// �A�Z���u��ID
            //                    "���_���ݒ肳��Ă��܂���B",                       // �\�����郁�b�Z�[�W
            //                    -1,													// �X�e�[�^�X�l
            //                    MessageBoxButtons.OK);

            //    // �t�H�[�J�X�ݒ�
            //    this.tEdit_SectionCode.Focus();
            //    return false;
            //}
            // ���[�J�[���̓`�F�b�N
            //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
            if (this.deleteCombo.SelectedIndex != 0)
            {
                if (this.tNedit_MakerCode.GetInt() == 0)
                {
                    // �Y���Ȃ�
                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���[�J�[�R�[�h����͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_MakerCode.Focus();
                    ChangeToMakerData();
                    return false;
                }
            }
            if (this.tNedit_Code1.GetInt() == 0 && this.tNedit_Code2.GetInt() == 0 && this.tNedit_Code3.GetInt() == 0 && this.tNedit_Code4.GetInt() == 0)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�R�[�h����͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tNedit_Code1.Focus();
                if (deleteCombo.SelectedIndex == 0)
                {
                    ChangeToMakerData();
                }
                if (deleteCombo.SelectedIndex == 1)
                {
                    ChangeToMGroupData();
                }
                if (deleteCombo.SelectedIndex == 2)
                {
                    ChangeToGroupData();
                }
                return false;
            }
            // if (this.joinComboEditor.SelectedIndex == 1 && this.goodsComboEditor.SelectedIndex == 1) // DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (this.joinComboEditor.SelectedIndex == 1 && this.goodsComboEditor.SelectedIndex == 1 && this.rateComboEditor.SelectedIndex == 1) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�폜����Ώۂ�����܂���B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.goodsComboEditor.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ���i���[�J�[�R�[�hFocus���b�h��ݒ菈������
        /// <summary>
        /// ���i���[�J�[�R�[�hFocus���b�h��ݒ菈������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       :���i���[�J�[�R�[�hFocus���b�h��ݒ菈���������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_MakerCode_Enter(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMaker;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableMaker;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.NameColumn.ColumnName].Width = 260;
            columns[table.CodeColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "���[�J�[����";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
        }
        #endregion

        #region �R�[�h1Focus�擾����
        /// <summary>
        /// �R�[�hFocus�擾����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �R�[�h1Focus�擾�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code1_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region �R�[�h2Focus�擾����
        /// <summary>
        /// �R�[�hFocus�擾����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �R�[�h2Focus�擾�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code2_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region �R�[�h3Focus�擾����
        /// <summary>
        /// �R�[�hFocus�擾����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �R�[�h3Focus�擾�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code3_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region �R�[�h4Focus�擾����
        /// <summary>
        /// �R�[�hFocus�擾����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �R�[�h4Focus�擾�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code4_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region  �R�[�h�ύX���O���b�h��ݒ菈������
        /// <summary>
        /// �R�[�h�ύX���O���b�h��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R�[�h�ύX���O���b�h��ݒ菈�����s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void ColumnChange()
        {
            //�폜�敪 = ���[�J�[
            if (this.deleteCombo.SelectedIndex == 0)
            {
                ChangeToMakerData();
                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            }
            //�폜�敪 = ���[�J�[+������
            if (this.deleteCombo.SelectedIndex == 1)
            {
                ChangeToMGroupData();
                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            }
            //�폜�敪 = ���[�J�[+�O���[�v�R�[�h
            if (this.deleteCombo.SelectedIndex == 2)
            {
                ChangeToGroupData();
                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            }
        }
        #endregion

        #region  �O���b�h�f�[�^�Ǎ�����
        /// <summary>
        /// �O���b�h�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�f�[�^�Ǎ��������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void GetGridDate()
        {
            GetMakerTable();
            GetMGroupTable();
            GetGroupTable();
        }
        /// <summary>
        /// ���[�J�[�O���b�h�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�O���b�h�f�[�^�Ǎ��������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void GetMakerTable()
        {
            _resultTableMaker = new SearchResultDataSet.ResultTableDataTable();
            SearchResultDataSet.ResultTableRow rowMaker = _resultTableMaker.NewResultTableRow();
            try
            {
                ArrayList retListMaker;
                int status = this._makerAcs.SearchAll(out retListMaker, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retListMaker)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            rowMaker = _resultTableMaker.NewResultTableRow();
                            rowMaker.ChooseCol = false;
                            rowMaker.Code = makerUMnt.GoodsMakerCd.ToString();
                            rowMaker.Name = makerUMnt.MakerName.ToString();
                            _resultTableMaker.AddResultTableRow(rowMaker);
                        }
                    }
                }
            }
            catch
            {
                _resultTableMaker = new SearchResultDataSet.ResultTableDataTable();
            }
        }
        /// <summary>
        /// �����ރO���b�h�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ރO���b�h�f�[�^�Ǎ��������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void GetMGroupTable()
        {
            _resultTableMGroup = new SearchResultDataSet.ResultTableDataTable();
            SearchResultDataSet.ResultTableRow rowMGroup = _resultTableMGroup.NewResultTableRow();
            try
            {
                ArrayList retListMGroup;
                int status = this._goodsGroupUAcs.SearchAll(out retListMGroup, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retListMGroup)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            rowMGroup = _resultTableMGroup.NewResultTableRow();
                            rowMGroup.ChooseCol = false;
                            rowMGroup.Code = goodsGroupU.GoodsMGroup.ToString();
                            rowMGroup.Name = goodsGroupU.GoodsMGroupName.ToString();
                            _resultTableMGroup.AddResultTableRow(rowMGroup);
                        }
                    }
                }
            }
            catch
            {
                _resultTableMGroup = new SearchResultDataSet.ResultTableDataTable();
            }
        }

        /// <summary>
        /// �O���[�v�O���b�h�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���[�v�O���b�h�f�[�^�Ǎ��������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void GetGroupTable()
        {
            _resultTableGroup = new SearchResultDataSet.ResultTableDataTable();
            SearchResultDataSet.ResultTableRow rowGroup = _resultTableGroup.NewResultTableRow();
            try
            {
                ArrayList retListGroup;
                int status = this._bLGroupUAcs.SearchAll(out retListGroup, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retListGroup)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            rowGroup = _resultTableGroup.NewResultTableRow();
                            rowGroup.ChooseCol = false;
                            rowGroup.Code = bLGroupU.BLGroupCode.ToString();
                            rowGroup.Name = bLGroupU.BLGroupName.ToString();
                            _resultTableGroup.AddResultTableRow(rowGroup);
                        }
                    }
                }
            }
            catch
            {
                _resultTableGroup = new SearchResultDataSet.ResultTableDataTable();
            }
        }









        #endregion

        #region �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMKHN01500UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PRINTNAME,				        // �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �����f�[�^�N���A
        /// <summary>
        /// �����f�[�^�N���A
        /// </summary>
        /// <remarks>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2015/06/08 ���t</br>
        /// <br>�Ǘ��ԍ�   : 11100068-00 </br>
        /// <br>           : REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>    
        /// </remarks>
        private void textClear()
        {
            this.tNedit_Code1.Text = "";
            this.tNedit_Code2.Text = "";
            this.tNedit_Code3.Text = "";
            this.tNedit_Code4.Text = "";
            this.tEdit_Name1.Text = "";
            this.tEdit_Name2.Text = "";
            this.tEdit_Name3.Text = "";
            this.tEdit_Name4.Text = "";
            this.tNedit_MakerCode.Text = "";
            this.tNedit_MakerName.Text = "";
            this.goodsNotDelLabel.Text = "0 ��";
            this.joinNotDelLabel.Text = "0 ��";
            this.joinDeleteLabel.Text = "0 ��";
            this.goodsDeleteLabel.Text = "0 ��";
            this.stockNotDelLabel.Text = "0 ��";
            this.stockDeleteLabel.Text = "0 ��";
            // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��---->>>>>
            //this.rateNotDelLabel.Text = "0 ��";//DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            this.rateDeleteLabel.Text = "0 ��";
            // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��----<<<<<
            this.goodsComboEditor.SelectedIndex = 0;
            this.joinComboEditor.SelectedIndex = 0;
            this.goodsStockComboEditor.SelectedIndex = 0;
            this.joinStockComboEditor.SelectedIndex = 0;
            // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��---->>>>>
            this.rateComboEditor.SelectedIndex = 0;
            //this.rateStockComboEditor.SelectedIndex = 0; //DEL ���t 2015/08/20 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��----<<<<<
        }
        #endregion

        #region DataChange
        /// <summary>
        /// �O���b�h��ύX = ���[�J�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h��ύX = ���[�J�[���s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void ChangeToMakerData()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMaker;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableMaker;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;
        }

        /// <summary>
        /// �O���b�h��ύX = ������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h��ύX = �����ނ��s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void ChangeToMGroupData()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMGroup;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableMGroup;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.CodeColumn.ColumnName].Header.Caption = "�����ރR�[�h";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "�����ޖ���";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;

        }

        /// <summary>
        /// �O���b�h��ύX = �O���[�v
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h��ύX = �O���[�v���s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void ChangeToGroupData()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableGroup;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableGroup;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.CodeColumn.ColumnName].Header.Caption = "�O���[�v�R�[�h";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "�O���[�v����";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;
        }
        #endregion

        #region ���_�K�C�h��Click
        /// <summary>
        ///  ���_�K�C�h��Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		:  ���_�K�C�hClick�̎��A�f�[�^�ݒ菈�����s���܂��B</br> 
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            //DEL by Liangsd   2011/08/30----------------->>>>>>>>>
            //SecInfoSet sectionInfo;
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this.tEdit_SectionCode.Text = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0'); 
            //    this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
            //}
            //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
        }
        #endregion

        #region �O���b�h��Click����
        /// <summary>
        /// �O���b�h��Click����
        /// </summary>
        /// <param name="dr">���݂̍s</param>
        /// <param name="flag1">�敪�P</param>
        /// <param name="flag2">�敪�Q</param>        /// <remarks>
        /// <br>Note		:  �O���b�h��Click���ʂ��s���܂��B</br> 
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void GridClick(UltraGridRow dr, bool flag1, bool flag2)
        {
            //�R�[�h����
            if (this.deleteCombo.SelectedIndex != 0 && dr.Cells[1].Value.ToString() == this.tNedit_MakerCode.Text)
            {
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code1.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code1.Text = "";
                this.tEdit_Name1.Text = "";
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code2.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code2.Text = "";
                this.tEdit_Name2.Text = "";
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code3.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code3.Text = "";
                this.tEdit_Name3.Text = "";
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code4.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code4.Text = "";
                this.tEdit_Name4.Text = "";
                return;
            }
            if (this.deleteCombo.SelectedIndex != 0 && this.tNedit_MakerCode.Text == "" && this.dataGrid.DataSource == this._resultTableMaker)
            {
                dr.Cells[0].Value = flag2;
                this.tNedit_MakerCode.Text = dr.Cells[1].Value.ToString();
                this.tNedit_MakerName.Text = dr.Cells[2].Value.ToString();
            }
            if (selectCount <= 4)
            {

                if (this.deleteCombo.SelectedIndex != 0 && this.dataGrid.DataSource == this._resultTableMaker)
                {
                    return;
                }
                else
                {
                    if (this.tNedit_Code1.Text == "")
                    {
                        dr.Cells[0].Value = flag2;
                        selectCount++;
                        this.tNedit_Code1.Text = dr.Cells[1].Value.ToString();
                        this.tEdit_Name1.Text = dr.Cells[2].Value.ToString();
                    }
                    else
                    {
                        if (this.tNedit_Code2.Text == "")
                        {
                            dr.Cells[0].Value = flag2;
                            selectCount++;
                            this.tNedit_Code2.Text = dr.Cells[1].Value.ToString();
                            this.tEdit_Name2.Text = dr.Cells[2].Value.ToString();
                        }
                        else
                        {
                            if (this.tNedit_Code3.Text == "")
                            {
                                dr.Cells[0].Value = flag2;
                                selectCount++;
                                this.tNedit_Code3.Text = dr.Cells[1].Value.ToString();
                                this.tEdit_Name3.Text = dr.Cells[2].Value.ToString();
                            }
                            else
                            {
                                if (this.tNedit_Code4.Text == "")
                                {
                                    dr.Cells[0].Value = flag2;
                                    selectCount++;
                                    this.tNedit_Code4.Text = dr.Cells[1].Value.ToString();
                                    this.tEdit_Name4.Text = dr.Cells[2].Value.ToString();
                                }
                                else
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN01500UA",
                                        "����ȏ�w��o���܂���",
                                        -1,
                                        MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region ������Focus����
        /// <summary>
        /// ������Focus����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ������Focus�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void PMKHN01500UA_Shown(object sender, EventArgs e)
        {
            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30
        }
        #endregion

        #region �`�F�b�N�{�b�N�X����
        /// <summary>
        /// �`�F�b�N�{�b�N�X����
        /// </summary>
        /// <param name="table">���O���b�h�̃f�[�^</param>
        /// <remarks>
        /// <br>Note       : �`�F�b�N�{�b�N�X�������s��</br>
        /// <br>Programmer : ���X��</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void CheckBoxAuto(SearchResultDataSet.ResultTableDataTable table)
        {
            ArrayList codeList = new ArrayList();
            if (table == this._resultTableMaker && this.deleteCombo.SelectedIndex != 0)
            {
                if (tNedit_MakerCode.GetInt() != 0)
                {
                    codeList.Add(tNedit_MakerCode.GetInt().ToString().Trim());
                }
            }

            if (tNedit_Code1.GetInt() != 0)
            {
                codeList.Add(tNedit_Code1.GetInt().ToString().Trim());
            }

            if (tNedit_Code2.GetInt() != 0)
            {
                codeList.Add(tNedit_Code2.GetInt().ToString().Trim());
            }

            if (tNedit_Code3.GetInt() != 0)
            {
                codeList.Add(tNedit_Code3.GetInt().ToString().Trim());
            }

            if (tNedit_Code4.GetInt() != 0)
            {
                codeList.Add(tNedit_Code4.GetInt().ToString().Trim());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {


                if (table.Rows[i][1] != null
                    && codeList.Contains(table.Rows[i][1].ToString()))
                {
                    table.Rows[i][0] = true;
                }
                else
                {
                    table.Rows[i][0] = false;
                }
            }

        }
        #endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        public int Print(ref SFCMN06002C parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter;

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				       // �N��PGID
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;
            printInfo.rdData = this._deleteConditionAcs.DeleteListDataView;

            // ���o�����̐ݒ�
            printInfo.jyoken = this._deleteConditionBak;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        private void rateComboEditor_ValueChanged(object sender, EventArgs e)
        {

        }
        // ---- ADD caohh 2011/07/21 ----<<<<

    }
}
