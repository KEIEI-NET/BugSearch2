//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�̕ێ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/01/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/10  �C�����e : �B���_���͎��ɃX�y�[�X�J�b�g
//                                  �C�ݒ�}�X�^�Y���������̃T���v���捞��ʂ�
//                                    ��{�����̋��_�E���Ӑ�������\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c���V
// �� �� ��  2015/02/16  �C�����e : �V�X�e���e�X�g��Q#218
//                                  �E�T���v���捞�Ŗ����͂Ȃǂ̃��b�Z�[�W���\������邱�Ƃ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/03  �C�����e : Redmine#308 ���Ӑ�̑S���Ӑ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/04  �C�����e : Redmine#323 �T���v���捞���ɑS���Ӑ���w�肵���ꍇ��
//                                              �����f�[�^�����������C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/06  �C�����e : Redmine#338 �S���Ӑ�ݒ���e��萔��
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    public partial class PMREC09011UC : Form
    {
        # region Private Members
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private RecGoodsLkStAcs _recGoodsLkStAcs = null;

        // ���Ӑ�֘A
        private bool _cusotmerGuideSelected; // ���Ӑ�K�C�h�I���t���O
        private int _prevCusotmerCd = 0;

        //���_�֘A
        private bool _sectionGuideSelected; // ���_�K�C�h�I���t���O
        private string _prevSectionCd = string.Empty;

        private string _sampleSecCd = string.Empty;
        private string _sampleSecNm = string.Empty;
        private CustomerInfo _sampleCustomerInfo = null;

        public string SampleSecCd
        {
            get { return this._sampleSecCd; }
            set { this._sampleSecCd = value; }
        }
        public string SampleSecNm
        {
            get { return this._sampleSecNm; }
            set { this._sampleSecNm = value; }
        }
        public CustomerInfo SampleCustomerInfo
        {
            get { return this._sampleCustomerInfo; }
            set { this._sampleCustomerInfo = value; }
        }

        #endregion


        #region [ �R���X�g���N�^ ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        public PMREC09011UC()
        {
            InitializeComponent();
            InitializeForm();

            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._recGoodsLkStAcs = new RecGoodsLkStAcs();
            this._recGoodsLkStAcs.LoadMstData();

            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------>>>>>
            while (this._recGoodsLkStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------<<<<<
        }
        #endregion

        #region [ �������� ]
        private void InitializeForm()
        {
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            #region �K�C�h�{�^��
            this.uButton_SectionGuide.ImageList = IconResourceManagement.ImageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.ImageList = IconResourceManagement.ImageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion
        }
        #endregion


        #region [ �t�H�[���C�x���g���� ]
        // --- ADD 2015/02/10�C T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// FormShown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09011UC_Shown(object sender, EventArgs e)
        {
            this.tEdit_SectionCodeAllowZero.Text = this._sampleSecCd;
            this.uLabel_SectionName.Text = this._sampleSecNm;
            // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
            //this.tNedit_CustomerCodeAllowZero.DataText = this._sampleCustomerInfo.CustomerCode.ToString();
            if (this._sampleCustomerInfo.CustomerCode >= 0)
            {
                this.tNedit_CustomerCodeAllowZero.DataText = this._sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0');
            }
            // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
            this.uLabel_CustomerName.Text = this._sampleCustomerInfo.CustomerSnm;
        }
        // --- ADD 2015/02/10�C T.Miyamoto ------------------------------<<<<<
        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09011UC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region [ �c�[���o�[�C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select": // �m��
                    if (this.SetResult())
                    {
                        DialogResult = DialogResult.OK;
                    }
                    break;

                case "Button_Back":   // �߂�
                    DialogResult = DialogResult.Cancel;
                    break;
                case "Button_Guide":   // �K�C�h
                    this.GuideStart();
                    break;
            }
        }
        #endregion

        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�N���������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void GuideStart()
        {
            // ���_
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
            }
            // ���Ӑ�
            else if (this.tNedit_CustomerCodeAllowZero.Focused)
            {
                this.uButton_CustomerGuide_Click(this.tNedit_CustomerCodeAllowZero, new EventArgs());
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^��</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        /// <summary>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                    tNedit_CustomerCodeAllowZero.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^��</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        /// <summary>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.CustomerCheck_sample(this.tNedit_CustomerCodeAllowZero.GetInt(), false);
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCodeAllowZero.SetInt(customerSearchRet.CustomerCode);

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// �t�H�[�J�X�ϊ�����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ϊ������B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                #region ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
                        if (!this.SectionCheck_sample(sectionCode))
                        {
                            e.NextCtrl = e.PrevCtrl; //�t�H�[�J�X�ړ�����
                            this.tEdit_SectionCodeAllowZero.SelectAll();
                            break;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���_�K�C�h�{�^��
                case "uButton_SectionGuide":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���Ӑ�R�[�h
                case "tNedit_CustomerCodeAllowZero":
                    {
                        if (!this.CustomerCheck_sample(this.tNedit_CustomerCodeAllowZero.GetInt(), false))
                        {
                            e.NextCtrl = e.PrevCtrl; //�t�H�[�J�X�ړ�����
                            break;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_CustomerGuide;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���Ӑ�K�C�h�{�^��
                case "uButton_CustomerGuide":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// ���_�`�F�b�N����
        /// </summary>
        public bool SectionCheck_sample(string sectionCode)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                //���_�N���A
                this.tEdit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";
                this._prevSectionCd = "";

                if (sectionCode == "00")
                {
                    this._prevSectionCd = sectionCode;
                    this.tEdit_SectionCodeAllowZero.Text = sectionCode; //���_�R�[�h
                    this.uLabel_SectionName.Text = "�S�Ћ���";  //���_����

                    this._sampleSecCd = sectionCode;
                    this._sampleSecNm = "�S�Ћ���";
                }
                else
                {
                    if (retSectionInfo != null)
                    {
                        this._prevSectionCd = sectionCode;
                        // --- UPD 2015/02/10�B T.Miyamoto ------------------------------>>>>>
                        //this.tEdit_SectionCodeAllowZero.Text = retSectionInfo.SectionCode; //���_�R�[�h
                        //this.uLabel_SectionName.Text = retSectionInfo.SectionGuideNm;      //���_��
                        this.tEdit_SectionCodeAllowZero.Text = retSectionInfo.SectionCode.Trim(); //���_�R�[�h
                        this.uLabel_SectionName.Text = retSectionInfo.SectionGuideNm.Trim();      //���_��
                        // --- UPD 2015/02/10�B T.Miyamoto ------------------------------<<<<<

                        this._sampleSecCd = retSectionInfo.SectionCode;
                        this._sampleSecNm = retSectionInfo.SectionGuideNm;
                    }
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tEdit_SectionCodeAllowZero.Text = this._prevSectionCd; //���_�R�[�h
            }
            return checkResult;
        }

        /// <summary>
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        public bool CustomerCheck_sample(int customerCode, bool chkFlg)
        {
            string errMsg;
            CustomerInfo retCustomerInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckCustomer(customerCode, chkFlg, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                //���Ӑ�N���A
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";

                this._prevCusotmerCd = 0;
                if (retCustomerInfo != null)
                {
                    this._prevCusotmerCd = customerCode;
                    // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //���Ӑ�R�[�h
                    this.tNedit_CustomerCodeAllowZero.DataText = customerCode.ToString().PadLeft(8, '0'); //���Ӑ�R�[�h
                    // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    this.uLabel_CustomerName.Text = retCustomerInfo.CustomerSnm; //���Ӑ旪��

                    this._sampleCustomerInfo = retCustomerInfo;
                }
                // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                if (customerCode == 0)
                {
                    this._prevCusotmerCd = customerCode;
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.DataText = "00000000";
                    //this.uLabel_CustomerName.Text = "�S���Ӑ�";

                    //this._sampleCustomerInfo.CustomerCode = 0;
                    //// --- ADD 2015/03/04 T.Miyamoto Redmine#323 ------------------------------>>>>>
                    //// �S���Ӑ�̏ꍇ�A�ȉ��̒l���⍇������ƁE���_�R�[�h�ɐݒ肳���
                    //this._sampleCustomerInfo.CustomerEpCode  = "0000000000000000"; //���Ӑ��ƃR�[�h
                    //this._sampleCustomerInfo.CustomerSecCode = "000000";           //���Ӑ拒�_�R�[�h
                    //// --- ADD 2015/03/04 T.Miyamoto Redmine#323 ------------------------------<<<<<
                    this.tNedit_CustomerCodeAllowZero.DataText = RecGoodsLkStAcs.ALL_CUSTOMERCODE;
                    this.uLabel_CustomerName.Text = RecGoodsLkStAcs.ALL_CUSTOMERNAME;
                    this._sampleCustomerInfo.CustomerCode = 0;
                    // �S���Ӑ�̏ꍇ�A�ȉ��̒l���⍇������ƁE���_�R�[�h�ɐݒ肳���
                    this._sampleCustomerInfo.CustomerEpCode  = RecGoodsLkStAcs.ALL_ORIGINALEPCD;  //���Ӑ��ƃR�[�h
                    this._sampleCustomerInfo.CustomerSecCode = RecGoodsLkStAcs.ALL_ORIGINALSECCD; //���Ӑ拒�_�R�[�h
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tNedit_CustomerCodeAllowZero.SetInt(this._prevCusotmerCd);
            }
            return checkResult;
        }

        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �m�菈���B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private bool SetResult()
        {
            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
            if (!this.SectionCheck_sample(sectionCode))
            {
                this.tEdit_SectionCodeAllowZero.Focus();
                return false;
            }
            if (!this.CustomerCheck_sample(this.tNedit_CustomerCodeAllowZero.GetInt(), true))
            {
                this.tNedit_CustomerCodeAllowZero.Focus();
                return false;
            }
            return true;
        }
    }
}