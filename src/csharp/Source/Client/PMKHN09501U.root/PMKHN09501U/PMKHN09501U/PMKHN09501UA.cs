//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi�s�ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/29  �C�����e : PVCS#299 ��ʂ̃��[�h�\�� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/10  �C�����e : PVCS#327 �N���A������̃��[�h�ύX 
//                                  PVCS#328 ����`�[�ԍ��̓��͕s��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ԕi�s�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi�s�ݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.20</br>
    /// </remarks>
    public partial class PMKHN09501UA : Form
    {
        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region ��Const Members
        private const string PGID = "PMKHN09500U.EXE(PMKHN09501UA)";
        private const string MARK_1 = "/";
        private const string MARK_2 = "";
        private const string MARK_3 = ":";
        private const int MAXCOUNT = 99;
        private const int COLUMN_COUNT = 6;                    // ��
        //private const int ROW_COUNT = 20;                       // �s��
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;
        private PMKHN09501UB _goodsNotReturnInput;
        private GoodsNotReturnAcs _goodsNotReturnAcs;
        private GoodsNotReturnDataSet _dataSet;
        private GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable _goodsNotReturnDetailDataTable;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private Control _prevControl = null;
        private SecInfoAcs _secInfoAcs = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private string salesSlipNumberTemp = string.Empty;
        ArrayList goodsNotReturnList = null;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// �ԕi�s�ݒ�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ԕi�s�ݒ�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        public PMKHN09501UA()
        {
            InitializeComponent();
            // �ϐ�������
            _goodsNotReturnInput = new PMKHN09501UB(this);
            this._goodsNotReturnAcs = GoodsNotReturnAcs.GetInstance();
            this._controlScreenSkin = new ControlScreenSkin();
            this._dataSet = new GoodsNotReturnDataSet();
            this._goodsNotReturnDetailDataTable = this._goodsNotReturnAcs.GoodsNotReturnDetailDataTable;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Cancel"];
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            _goodsNotReturnInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            _secInfoAcs = new SecInfoAcs();
            goodsNotReturnList = new ArrayList();
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.uButton_SalesSlipNumber.ImageList = this._imageList16;
            this.uButton_SalesSlipNumber.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// �ԕi�s�ݒ�N���A����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	   : �ԕi�s�ݒ����������B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        private bool Clear()
        {
            // ��ʏ���������
            this.InitializeScreen();
            // ADD 杍^ 2009/07/10 --->>>
            this.Mode_Label.Text = "�V�K���[�h";
            // ADD 杍^ 2009/07/10 ---<<<

            // �o�׎�����׃N���A����
            this._goodsNotReturnInput.Clear();
            salesSlipNumberTemp = string.Empty;
            this.tEdit_SalesSlipNumber.Focus();

            return true;
        }

        /// <summary>
        /// ��ʃf�[�^�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̂��s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private void InitializeScreen()
        {

            // ����`�[�ԍ�
            this.tEdit_SalesSlipNumber.Text = MARK_2;

            // ���_�R�[�h
            this.uLabel_SectionCode.Text = MARK_2;

            // ���_����
            this.uLabel_SectionName.Text = MARK_2;

            // ���Ӑ�R�[�h
            this.uLabel_CustomerCode.Text = MARK_2;

            // ���Ӑ於��
            this.uLabel_CustomerName.Text = MARK_2;

            // �����
            this.uLabel_Year.Text = MARK_2;
            this.uLabel_Month.Text = MARK_2;
            this.uLabel_Day.Text = MARK_2;

            this._goodsNotReturnInput.Enabled = false;
        }

        /// <summary>
        /// ��ʃf�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̌������s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private bool SearchSalesSlip(string enterpriseCode, string salesSlipNum)
        {

            bool isSearch = true;
            this.InitializeScreen();
            this._goodsNotReturnInput.Clear();
            string retMessage = string.Empty;
            salesSlipNumberTemp = string.Empty;

            bool retupperCntFlag = false;

            int salesSlipNumLen = 0;
            // ADD 杍^ 2009/07/10 --->>>
            if (salesSlipNum.Length < 9)
            {
                salesSlipNumLen = 9 - salesSlipNum.Length;
                for (int i = 0; i < salesSlipNumLen; i++)
                {
                    salesSlipNum = "0" + salesSlipNum;
                }
            }
            // ADD 杍^ 2009/07/10 ---<<<

            // ����`�[�f�[�^��������
            this.Cursor = Cursors.WaitCursor;
            int status = this._goodsNotReturnAcs.ReadDBData(enterpriseCode, salesSlipNum, out goodsNotReturnList, out retMessage);
            this.Cursor = Cursors.Default;

            foreach (GoodsNotReturnWork work in goodsNotReturnList)
            {
                if (work.UpdateDateTime == DateTime.MinValue)
                {
                    work.RetUpperCnt = work.ShipmentCnt;
                }
                else
                {
                    retupperCntFlag = true;
                }
            }

            // ADD 2009/06/29 --->>>
            if (!retupperCntFlag)
            {
                this.Mode_Label.Text = "�V�K���[�h";
            }
            else
            {
                this.Mode_Label.Text = "�C�����[�h";
            }
            // ADD 2009/06/29 ---<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (null != goodsNotReturnList && goodsNotReturnList.Count > 0)
                {
                    GoodsNotReturnWork goodsNotReturnWork = (GoodsNotReturnWork)goodsNotReturnList[0];
                    // ����`�[���폜�f�[�^�̏ꍇ�́u�폜�`�[�͌Ăяo���܂���B�v
                    if (0 != goodsNotReturnWork.LogicalDeleteCode)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�폜�`�[�͌Ăяo���܂���B",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    // �擾��������`�[���ԕi�`�[���ԕi�`�[�̏ꍇ�́u�ԕi�`�[�͌Ăяo���܂���B�v
                    if (1 == goodsNotReturnWork.SalesSlipCd)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�ԕi�`�[�͌Ăяo���܂���B",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    // �擾��������`�[���׏�񖈂ɂ̎󒍎c����0�̏ꍇ�A�u���ɕԕi�ς݂̔���`�[�ł��B�v
                    bool isReturn = true;
                    // �l�����ׂ����O�������ʁA�Ώۖ��ׂ��P�����Ȃ��ꍇ��
                    // ���ʂ��}�C�i�X�̖��ׂ����O�������ʁA�Ώۖ��ׂ��P�����Ȃ��ꍇ��
                    bool isDiscount = true;

                    foreach (GoodsNotReturnWork work in goodsNotReturnList)
                    {
                        // �l�����ׂ����O�������ʁA���ʂ��}�C�i�X�̖��ׂ����O��������
                        if (work.SalesSlipCdDtl != 2 && work.ShipmentCnt >= 0)
                        {
                            isDiscount = false;
                            // �󒍎c����0�̏ꍇ
                            if (work.AcptAnOdrRemainCnt != 0)
                            {
                                isReturn = false;
                            }
                        }
                    }
                    if (isDiscount)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�S���ׂ��ݒ�s�\�Ȃ��ߌĂяo���܂���B",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    if (isReturn)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���ɕԕi�ς݂̔���`�[�ł��B",
                        -1,
                        MessageBoxButtons.OK);
                        isSearch = false;
                        return isSearch;
                    }
                    // ����`�[�ԍ�
                    this.tEdit_SalesSlipNumber.Text = salesSlipNum;
                    // ���_�R�[�h
                    this.uLabel_SectionCode.Text = goodsNotReturnWork.SectionCode;
                    // ���_����
                    this.uLabel_SectionName.Text = goodsNotReturnWork.SectionGuideNm;
                    // ���Ӑ�R�[�h
                    string customerCode = Convert.ToString(goodsNotReturnWork.CustomerCode);
                    if ("0".Equals(customerCode))
                    {
                        customerCode = string.Empty;
                    }
                    else
                    {
                        int customerCodeLen = customerCode.Length;

                        for (int i = customerCodeLen; i < 8; i++)
                        {
                            customerCode = "0" + customerCode;
                        }
                    }


                    this.uLabel_CustomerCode.Text = customerCode;
                    // ���Ӑ於��
                    this.uLabel_CustomerName.Text = goodsNotReturnWork.CustomerName;
                    // �����
                    DateTime salesDt = goodsNotReturnWork.SalesDate;
                    string salesStr = Convert.ToString(salesDt);

                    if (salesDt == DateTime.MinValue)
                    {
                        this.uLabel_Year.Text = string.Empty;
                        this.uLabel_Month.Text = string.Empty;
                        this.uLabel_Day.Text = string.Empty;
                    }
                    else
                    {
                        salesStr = salesStr.Replace(MARK_1, MARK_2);
                        salesStr = salesStr.Replace(MARK_3, MARK_2);
                        this.uLabel_Year.Text = salesStr.Substring(0, 4);
                        this.uLabel_Month.Text = salesStr.Substring(4, 2);
                        this.uLabel_Day.Text = salesStr.Substring(6, 2);
                    }


                    this._goodsNotReturnInput.Enabled = true;
                    ArrayList goodsNotReturnListTmp = this._goodsNotReturnAcs.goodsNotReturnCache(goodsNotReturnList);

                    for (int i = 0; i < goodsNotReturnListTmp.Count; i++)
                    {
                        GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnListTmp[i];
                        if (work.AcptAnOdrRemainCnt == 0)
                        {
                            this._goodsNotReturnInput.uGrid_Details.DisplayLayout.Rows[i].Cells[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Activation = Activation.NoEdit;
                        }
                        if (i == MAXCOUNT)
                        {
                            break;
                        }
                    }

                    salesSlipNumberTemp = salesSlipNum;
                }
            }
            // �������ʁ�0���̏ꍇ�A
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Y������f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_SalesSlipNumber.Focus();
                isSearch = false;
                return isSearch;
            }
            // �����G���[�̏ꍇ�A
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "����f�[�^�̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);
                isSearch = false;
                return isSearch;
            }
            return isSearch;
        }

        /// <summary>
        /// ����`�[�Ɖ��ʏ���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ����`�[�Ɖ��ʏ������s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private void uButton_SalesSlipNumber_Click(object sender, EventArgs e)
        {
            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            salesSlipGuide.TComboEditor_SalesFormalCode = false;
            salesSlipGuide.AcptAnOdrStatus = 30;
            SalesSlipSearchResult searchResult;
            DialogResult result;
            string retMessage = string.Empty;
            // ����`�[�Ɖ���
            result = salesSlipGuide.ShowGuide(this, _enterpriseCode, 30, 0, out searchResult);

            if (result == DialogResult.OK)
            {
                if (searchResult != null)
                {

                    if (!salesSlipNumberTemp.Equals(searchResult.SalesSlipNum))
                    {
                        GoodsNotReturnWork goodsNotReturnWork = null;
                        ArrayList updGoodsNotReturnList = new ArrayList();
                        // ����`�[�ԍ��������ʌ���
                        int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                        // �ԕi�����
                        string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                        for (int i = 0; i < rowNo; i++)
                        {
                            goodsNotReturnWork = new GoodsNotReturnWork();
                            // �ԕi����f�[�^�̍X�V����
                            goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                            // ��ƃR�[�h
                            goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                            // �󒍃X�e�[�^�X
                            goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                            // �ԕi�����
                            if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                            {
                                goodsNotReturnWork.RetUpperCnt = -1;
                            }
                            else
                            {
                                goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                            }
                            // ���㖾�גʔ�
                            goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;
                            updGoodsNotReturnList.Add(goodsNotReturnWork);
                        }

                        int acptAnOdrStatus = 0;
                        long salesSlipDtlNum = 0;
                        double retUpperCnt = 0;
                        bool isChange = false;
                        for (int i = 0; i < updGoodsNotReturnList.Count; i++)
                        {
                            GoodsNotReturnWork updWork = (GoodsNotReturnWork)updGoodsNotReturnList[i];
                            acptAnOdrStatus = updWork.AcptAnOdrStatus;
                            salesSlipDtlNum = updWork.SalesSlipDtlNum;
                            retUpperCnt = updWork.RetUpperCnt;

                            for (int j = 0; j < goodsNotReturnList.Count; j++)
                            {
                                GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnList[j];
                                if (acptAnOdrStatus == work.AcptAnOdrStatus
                                    && salesSlipDtlNum == work.SalesSlipDtlNum)
                                {
                                    if (retUpperCnt == work.RetUpperCnt)
                                    {
                                        isChange = false;
                                    }
                                    else
                                    {
                                        isChange = true;
                                        break;
                                    }
                                }
                            }

                            if (isChange)
                            {
                                break;
                            }
                        }

                        if (isChange)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                "�o�^���Ă���낵���ł����H",
                                0,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // �X�V����
                                int status = this.UpdateProcess(updGoodsNotReturnList);

                                // ���ɑ��[���X�V�̏ꍇ�A
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���ɑ��[�����X�V����Ă��܂��B",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // ���ɑ��[���폜�̏ꍇ�A
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���ɑ��[�����폜����Ă��܂��B",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // �X�V�����̏ꍇ�A
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    bool isSearch = this.SearchSalesSlip(_enterpriseCode, searchResult.SalesSlipNum);
                                    this.tEdit_SalesSlipNumber.Text = searchResult.SalesSlipNum;
                                    this.tEdit_SalesSlipNumber.Focus();
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    salesSlipNumberTemp = searchResult.SalesSlipNum;


                                    return;
                                }
                                // �X�V�G���[�̏ꍇ�A
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    PGID + "�ԕi����f�[�^�̕ۑ��Ɏ��s���܂����BST=" + Convert.ToString(status),
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                bool isSearch = this.SearchSalesSlip(_enterpriseCode, searchResult.SalesSlipNum);
                                if (!isSearch)
                                {
                                    this.tEdit_SalesSlipNumber.Text = searchResult.SalesSlipNum;
                                    this.tEdit_SalesSlipNumber.Focus();
                                }
                            }
                            // �L�����Z���̏ꍇ�A
                            else
                            {
                                this.tEdit_SalesSlipNumber.Text = salesSlipNumberTemp;
                                this.tEdit_SalesSlipNumber.Focus();
                            }
                        }
                        // �f�[�^���ύX�Ȃ��ꍇ�A
                        else
                        {
                            bool isSearch = this.SearchSalesSlip(_enterpriseCode, searchResult.SalesSlipNum);
                            if (!isSearch)
                            {
                                //this.tEdit_SalesSlipNumber.Text = searchResult.SalesSlipNum;
                                this.tEdit_SalesSlipNumber.Text = string.Empty;
                                salesSlipNumberTemp = string.Empty;
                                this.tEdit_SalesSlipNumber.Focus();
                            }
                        }
                    }

                    //// ����`�[�f�[�^��������
                    //bool isSearch = this.SearchSalesSlip(searchResult.EnterpriseCode, searchResult.SalesSlipNum);
                }
            }

        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g���s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this._goodsNotReturnInput.uGrid_Details.ActiveCell != null)
                        {
                            this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // �I������
                        GoodsNotReturnWork goodsNotReturnWork = null;
                        ArrayList updGoodsNotReturnList = new ArrayList();
                        // ����`�[�ԍ��������ʌ���
                        int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                        // �ԕi�����
                        string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                        for (int i = 0; i < rowNo; i++)
                        {
                            goodsNotReturnWork = new GoodsNotReturnWork();
                            // �ԕi����f�[�^�̍X�V����
                            goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                            // ��ƃR�[�h
                            goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                            // �󒍃X�e�[�^�X
                            goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                            // �ԕi�����
                            if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                            {
                                goodsNotReturnWork.RetUpperCnt = -1;
                            }
                            else
                            {
                                goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                            }
                            // ���㖾�גʔ�
                            goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;
                            updGoodsNotReturnList.Add(goodsNotReturnWork);
                        }

                        int acptAnOdrStatus = 0;
                        long salesSlipDtlNum = 0;
                        double retUpperCnt = 0;
                        bool isChange = false;
                        for (int i = 0; i < updGoodsNotReturnList.Count; i++)
                        {
                            GoodsNotReturnWork updWork = (GoodsNotReturnWork)updGoodsNotReturnList[i];
                            acptAnOdrStatus = updWork.AcptAnOdrStatus;
                            salesSlipDtlNum = updWork.SalesSlipDtlNum;
                            retUpperCnt = updWork.RetUpperCnt;

                            for (int j = 0; j < goodsNotReturnList.Count; j++)
                            {
                                GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnList[j];
                                if (acptAnOdrStatus == work.AcptAnOdrStatus
                                    && salesSlipDtlNum == work.SalesSlipDtlNum)
                                {
                                    if (retUpperCnt == work.RetUpperCnt)
                                    {
                                        isChange = false;
                                    }
                                    else
                                    {
                                    isChange = true;
                                    break;
                                    }

                                }

                            }

                            if (isChange)
                            {
                                break;
                            }
                        }

                        if (isChange)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                "�o�^���Ă���낵���ł����H",
                                0,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // �X�V����
                                int status = this.UpdateProcess(updGoodsNotReturnList);

                                // ���ɑ��[���X�V�̏ꍇ�A
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���ɑ��[�����X�V����Ă��܂��B",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // ���ɑ��[���폜�̏ꍇ�A
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���ɑ��[�����폜����Ă��܂��B",
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                                // �X�V�����̏ꍇ�A
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // �o�^����
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    this.Close();
                                    return;
                                }
                                // �X�V�G���[�̏ꍇ�A
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    PGID + "�ԕi����f�[�^�̕ۑ��Ɏ��s���܂����BST=" + Convert.ToString(status),
                                    0,
                                    MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.tEdit_SalesSlipNumber.Focus();
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // ����`�[�ԍ��𖢓��͂���ꍇ�A�G���[�Ƃ���B
                        if (string.IsNullOrEmpty(this.tEdit_SalesSlipNumber.Text.Trim()))
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "����`�[�ԍ����w�肵�Ă��������B",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }
                        // ����`�[�ԍ��������ʂ��Ȃ��̏ꍇ�A�G���[�Ƃ���B
                        if (this._goodsNotReturnInput.uGrid_Details.Rows.Count == 0)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�ۑ��Ώۃf�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }


                        if (this._prevControl != null)
                        {
                            ChangeFocusEventArgs e2 = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                            this.tArrowKeyControl1_ChangeFocus(this, e2);
                        }

                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this._goodsNotReturnInput.uGrid_Details.ActiveCell != null)
                        {
                            this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        GoodsNotReturnWork goodsNotReturnWork = null;
                        ArrayList updGoodsNotReturnList = new ArrayList();
                        // ����`�[�ԍ��������ʌ���
                        int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                        double shipmentNo = 0;
                        double returnNo = 0;
                        // �ԕi�����
                        string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                        for (int i = 0; i < rowNo; i++)
                        {
                            goodsNotReturnWork = new GoodsNotReturnWork();
                            // �ԕi����f�[�^�̍X�V����
                            goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                            // ��ƃR�[�h
                            goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                            // �󒍃X�e�[�^�X
                            goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                            // �ԕi�����
                            if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                            {
                                goodsNotReturnWork.RetUpperCnt = -1;
                            }
                            else
                            {
                                goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                            }
                            // ���㖾�גʔ�
                            goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;

                            shipmentNo = this._goodsNotReturnDetailDataTable[i].ShipmentNo;
                            if (goodsNotReturnWork.RetUpperCnt > shipmentNo)
                            {
                                //DialogResult dialogResult = TMsgDisp.Show(
                                //   this,
                                //   emErrorLevel.ERR_LEVEL_INFO,
                                //   this.Name,
                                //   "�ԕi��������o�א��𒴂��Ă��܂��B",
                                //   -1,
                                //   MessageBoxButtons.OK);

                                return;
                            }
                            returnNo = this._goodsNotReturnDetailDataTable[i].ReturnNo;
                            // ���͕ԕi��������ԕi�ϐ��̏ꍇ�A�u�ԕi������͕ԕi�ϐ��ȏ�̒l����͂��ĉ������B�v�Ƃ������b�Z�[�W�_�C�A���O�iOK�̂݁j���\�������B
                            if (goodsNotReturnWork.RetUpperCnt < returnNo)
                            {
                                //TMsgDisp.Show(
                                //   this,
                                //   emErrorLevel.ERR_LEVEL_INFO,
                                //   this.Name,
                                //   "�ԕi������͕ԕi�ϐ��ȏ�̒l����͂��ĉ������B",
                                //   -1,
                                //   MessageBoxButtons.OK);
                                //this._goodsNotReturnInput.uGrid_Details.Rows[i].Cells[6].Activated = true;
                                //this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                return;
                            }
                            // ���͕ԕi�������0�̏ꍇ�A�u�ԕi�������0�ȏ�̒l����͂��ĉ������B�v�Ƃ������b�Z�[�W�_�C�A���O�iOK�̂݁j���\�������B
                            if (goodsNotReturnWork.RetUpperCnt < 0)
                            {
                                //TMsgDisp.Show(
                                //   this,
                                //   emErrorLevel.ERR_LEVEL_INFO,
                                //   this.Name,
                                //   "�ԕi�������0�ȏ�̒l����͂��ĉ������B",
                                //   -1,
                                //   MessageBoxButtons.OK);

                                return;
                            }
                            updGoodsNotReturnList.Add(goodsNotReturnWork);
                        }

                        // �X�V����
                        int status = this.UpdateProcess(updGoodsNotReturnList);

                        // ���ɑ��[���X�V�̏ꍇ�A
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���ɑ��[�����X�V����Ă��܂��B",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }
                        // ���ɑ��[���폜�̏ꍇ�A
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���ɑ��[�����폜����Ă��܂��B",
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }
                        // �X�V�����̏ꍇ�A
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ����`�[�ԍ�
                            this.tEdit_SalesSlipNumber.Text = MARK_2;

                            // ���_�R�[�h
                            this.uLabel_SectionCode.Text = MARK_2;

                            // ���_����
                            this.uLabel_SectionName.Text = MARK_2;

                            // ���Ӑ�R�[�h
                            this.uLabel_CustomerCode.Text = MARK_2;

                            // ���Ӑ於��
                            this.uLabel_CustomerName.Text = MARK_2;

                            // �����
                            this.uLabel_Year.Text = MARK_2;
                            this.uLabel_Month.Text = MARK_2;
                            this.uLabel_Day.Text = MARK_2;

                            this._goodsNotReturnInput.Clear();
                            this.tEdit_SalesSlipNumber.Focus();

                        }
                        // �X�V�G���[�̏ꍇ�A
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            PGID + "�ԕi����f�[�^�̕ۑ��Ɏ��s���܂����BST=" + Convert.ToString(status),
                            0,
                            MessageBoxButtons.OK);
                            return;
                        }

                        // �o�^����
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        salesSlipNumberTemp = string.Empty;

                        break;
                    }
                case "ButtonTool_Cancel":
                    {
                        // �N���A����
                        this.Clear();
                        this._goodsNotReturnInput.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// �I���̊m�F�_�C�A���O�\������
        /// </summary>
        /// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
        /// <returns>�m�F��OK �m�F��NG</returns>
        /// <remarks>		
        /// <br>Note		: �I���̊m�F�_�C�A���O�\���������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private bool ShowSaveCheckDialog(bool isConfirm)
        {
            bool checkedValue = false;

            if ((isConfirm) && (!"".Equals(this.tEdit_SalesSlipNumber.Text.Trim())
                || this._goodsNotReturnInput.uGrid_Details.Rows.Count != 0))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    checkedValue = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    checkedValue = true;
                }
            }
            else
            {
                checkedValue = true;
            }

            return checkedValue;
        }

        /// <summary>
        /// �ԕi����f�[�^�X�V����
        /// </summary>
        /// <remarks>
        /// <param name="updGoodsNotReturnList">�X�V�f�[�^���X�g</param>
        /// <br>Note		: �ԕi����f�[�^�X�V�������s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.04.20</br>
        /// </remarks>
        private int UpdateProcess(ArrayList updGoodsNotReturnList)
        {
            string retMessage = string.Empty;
            // �ԕi����f�[�^���X�V����
            int status = _goodsNotReturnAcs.UpdateReturnUpper(updGoodsNotReturnList, out retMessage);

            return status;
        }

        /// <summary>
        /// �ڍ׃O���b�h�ŏ�ʍs�A�v�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ڍ׃O���b�h�ŏ�ʍs�A�v�E�����ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            Control control = this.tEdit_SalesSlipNumber;

            if (control != null)
            {
                control.Focus();
            }

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this._goodsNotReturnInput.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this._goodsNotReturnInput.uGrid_Details.ActiveCell != null))
            {
                if ((!this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.Hidden) &&
                    (this._goodsNotReturnInput.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                if (performActionResult)
                {
                    if ((this._goodsNotReturnInput.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this._goodsNotReturnInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this._goodsNotReturnInput.uGrid_Details.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// �t�H�J�X�ύX���ɃC�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�J�X�ύX���ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                case "uGrid_Details":
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                        {
                            if (this._goodsNotReturnInput.uGrid_Details.ActiveCell == null)
                            {
                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.NextCell);
                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                                return;
                            }

                            int activeRowIndex = this._goodsNotReturnInput.uGrid_Details.ActiveCell.Row.Index;
                            int activeColumnIndex = this._goodsNotReturnInput.uGrid_Details.ActiveCell.Column.Index;

                            if (e.ShiftKey == false)
                            {
                                for (int rowIndex = activeRowIndex; rowIndex < this._goodsNotReturnInput.uGrid_Details.Rows.Count - 1; rowIndex++)
                                {
                                    if (rowIndex == activeRowIndex)
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                }

                                // grid�̍Ō��cell
                                if ((activeRowIndex + 1 == this._goodsNotReturnInput.uGrid_Details.Rows.Count) && (activeColumnIndex == COLUMN_COUNT))
                                {
                                    this._goodsNotReturnInput.uGrid_Details.Rows[activeRowIndex].Cells[6].Activated = false;
                                    this._goodsNotReturnInput.uGrid_Details.Rows[activeRowIndex].Cells[6].Selected = false;
                                    e.NextCtrl = this.tEdit_SalesSlipNumber;
                                    return;
                                }
                                else
                                {
                                    this._goodsNotReturnInput.uGrid_Details.Rows[activeRowIndex].Cells[6].Activate();
                                    this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    e.NextCtrl = null;
                                    return;
                                }
                            }
                            else
                            {
                                for (int rowIndex = activeRowIndex; rowIndex >= 0; rowIndex--)
                                {
                                    if (rowIndex == 0)
                                    {
                                        if (activeColumnIndex == COLUMN_COUNT)
                                        {
                                            e.NextCtrl = this.tEdit_SalesSlipNumber;
                                            return;
                                        }
                                        else
                                        {
                                            if (this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit)
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SalesSlipNumber;
                                                return;
                                            }

                                        }
                                    }

                                    if (rowIndex == activeRowIndex)
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if (this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activation == Activation.AllowEdit)
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (activeColumnIndex == 6)
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex - 1].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if ((this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activation == Activation.AllowEdit))
                                            {
                                                this._goodsNotReturnInput.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                                this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "uButton_SalesSlipNumber":
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Down:
                            case Keys.Return:
                                if (this._goodsNotReturnDetailDataTable.Rows.Count > 0)
                                {
                                    for (int i = 0; i < this._goodsNotReturnDetailDataTable.Rows.Count; i++ )
                                    {
                                        // �ԕi�s�ݒ�O���b�h
                                        if (this._goodsNotReturnInput.uGrid_Details.Rows[i].Cells[6].Activation == Activation.AllowEdit)
                                        {
                                            this._goodsNotReturnInput.uGrid_Details.Rows[i].Cells[6].Activate();
                                            this._goodsNotReturnInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // �ԕi�s�ݒ�O���b�h
                                    e.NextCtrl = this.tEdit_SalesSlipNumber;
                                }
                                break;
                        }
                        break;
                    }
                case "tEdit_SalesSlipNumber":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesSlipNumber.Text))
                        {
                            int salesslipNo = 0;
                            if (int.TryParse(this.tEdit_SalesSlipNumber.Text, out salesslipNo))
                            {
                                if (salesslipNo == 0)
                                {
                                    this.tEdit_SalesSlipNumber.Text = string.Empty;
                                    // ��ʏ���������
                                    this.InitializeScreen();

                                    // �ԕi�s�ݒ�N���A����
                                    this._goodsNotReturnInput.Clear();

                                    salesSlipNumberTemp = string.Empty;
                                    return;
                                }
                            }

                            if (!this.tEdit_SalesSlipNumber.Text.Equals(salesSlipNumberTemp))
                            {
                                string retMessage = string.Empty;
                                GoodsNotReturnWork goodsNotReturnWork = null;
                                ArrayList updGoodsNotReturnList = new ArrayList();
                                // ����`�[�ԍ��������ʌ���
                                int rowNo = this._goodsNotReturnInput.uGrid_Details.Rows.Count;
                                // �ԕi�����
                                string limitReturnName = this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName;
                                for (int i = 0; i < rowNo; i++)
                                {
                                    goodsNotReturnWork = new GoodsNotReturnWork();
                                    // �ԕi����f�[�^�̍X�V����
                                    goodsNotReturnWork.UpdateDateTime = this._goodsNotReturnDetailDataTable[i].UpdateTime;
                                    // ��ƃR�[�h
                                    goodsNotReturnWork.EnterpriseCode = _enterpriseCode;
                                    // �󒍃X�e�[�^�X
                                    goodsNotReturnWork.AcptAnOdrStatus = this._goodsNotReturnDetailDataTable[i].AcptAnOdrStatus;
                                    // �ԕi�����
                                    if ((this._goodsNotReturnDetailDataTable.Rows[i][limitReturnName] == DBNull.Value))
                                    {
                                        goodsNotReturnWork.RetUpperCnt = -1;
                                    }
                                    else
                                    {
                                        goodsNotReturnWork.RetUpperCnt = this._goodsNotReturnDetailDataTable[i].LimitReturnNo;
                                    }
                                    // ���㖾�גʔ�
                                    goodsNotReturnWork.SalesSlipDtlNum = this._goodsNotReturnDetailDataTable[i].SalesSlipDtlNum;
                                    updGoodsNotReturnList.Add(goodsNotReturnWork);
                                }

                                int acptAnOdrStatus = 0;
                                long salesSlipDtlNum = 0;
                                double retUpperCnt = 0;
                                bool isChange = false;
                                for (int i = 0; i < updGoodsNotReturnList.Count; i++)
                                {
                                    GoodsNotReturnWork updWork = (GoodsNotReturnWork)updGoodsNotReturnList[i];
                                    acptAnOdrStatus = updWork.AcptAnOdrStatus;
                                    salesSlipDtlNum = updWork.SalesSlipDtlNum;
                                    retUpperCnt = updWork.RetUpperCnt;

                                    for (int j = 0; j < goodsNotReturnList.Count; j++)
                                    {
                                        GoodsNotReturnWork work = (GoodsNotReturnWork)goodsNotReturnList[j];
                                        if (acptAnOdrStatus == work.AcptAnOdrStatus
                                            && salesSlipDtlNum == work.SalesSlipDtlNum)
                                        {
                                            if (retUpperCnt == work.RetUpperCnt)
                                            {
                                                isChange = false;
                                            }
                                            else
                                            {
                                                isChange = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (isChange)
                                    {
                                        break;
                                    }
                                }

                                if (isChange)
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                        "�o�^���Ă���낵���ł����H",
                                        0,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button1);

                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        // �X�V����
                                        int status = this.UpdateProcess(updGoodsNotReturnList);

                                        // ���ɑ��[���X�V�̏ꍇ�A
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "���ɑ��[�����X�V����Ă��܂��B",
                                            0,
                                            MessageBoxButtons.OK);
                                            return;
                                        }
                                        // ���ɑ��[���폜�̏ꍇ�A
                                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "���ɑ��[�����폜����Ă��܂��B",
                                            0,
                                            MessageBoxButtons.OK);
                                            return;
                                        }
                                        // �X�V�����̏ꍇ�A
                                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            bool isSearch = this.SearchSalesSlip(_enterpriseCode, this.tEdit_SalesSlipNumber.Text);
                                            e.NextCtrl = this.tEdit_SalesSlipNumber;
                                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                                            dialog.ShowDialog(2);
                                            salesSlipNumberTemp = string.Empty;

                                            return;
                                        }
                                        // �X�V�G���[�̏ꍇ�A
                                        else
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            PGID + "�ԕi����f�[�^�̕ۑ��Ɏ��s���܂����BST=" + Convert.ToString(status),
                                            0,
                                            MessageBoxButtons.OK);
                                            return;
                                        }
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                        bool isSearch = this.SearchSalesSlip(_enterpriseCode, this.tEdit_SalesSlipNumber.Text);
                                        if (!isSearch)
                                        {
                                            e.NextCtrl = this.tEdit_SalesSlipNumber;
                                        }
                                    }
                                    // �L�����Z���̏ꍇ�A
                                    else
                                    {
                                        this.tEdit_SalesSlipNumber.Text = salesSlipNumberTemp;
                                        e.NextCtrl = this.tEdit_SalesSlipNumber;
                                    }
                                }
                                // �f�[�^���ύX�Ȃ��ꍇ�A
                                else
                                {
                                    bool isSearch = this.SearchSalesSlip(_enterpriseCode, this.tEdit_SalesSlipNumber.Text);
                                    if (!isSearch)
                                    {
                                        this.tEdit_SalesSlipNumber.Text = string.Empty;
                                        salesSlipNumberTemp = string.Empty;
                                        e.NextCtrl = this.tEdit_SalesSlipNumber;
                                        // �� 2009.07.07 ���m �ǋL
                                        return;
                                        // �� 2009.07.07 ���m
                                    }
                                }
                            }

                        }
                        // �f�[�^���Ȃ��ꍇ�A
                        else
                        {
                            // ��ʏ���������
                            this.InitializeScreen();

                            // �o�׎�����׃N���A����
                            this._goodsNotReturnInput.Clear();

                            salesSlipNumberTemp = string.Empty;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.uButton_SalesSlipNumber;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this._goodsNotReturnInput.uGrid_Details.Rows.Count > 0)
                                {
                                    e.NextCtrl = this._goodsNotReturnInput.uGrid_Details;
                                    this._goodsNotReturnInput.uGrid_Details.Rows[this._goodsNotReturnInput.uGrid_Details.Rows.Count - 1].Cells[6].Activate();
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_SalesSlipNumber;
                                }
                            }
                        }

                        break;
                    }
            }
        }
        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region ��Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�J�X�ύX���ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks> 
        private void PMKHN09501UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._goodsNotReturnInput);

            this.ButtonInitialSetting();

            panel_Detail.Controls.Add(this._goodsNotReturnInput);
            this._goodsNotReturnInput.Dock = DockStyle.Fill;

            // �N���A����
            this.Clear();

            Infragistics.Win.UltraWinToolbars.LabelTool sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_SectionName"];
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // ���O�C�����_�̐ݒ�
                sectionNameLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
            }

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            this._goodsNotReturnInput.Enabled = false;
        }
        #endregion
    }
}