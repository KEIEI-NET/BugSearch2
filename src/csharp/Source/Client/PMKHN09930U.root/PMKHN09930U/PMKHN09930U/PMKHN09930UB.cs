using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���D��ݒ莩���o�^�@�D��ݒ�ҏW���
    /// </summary>
    /// <remarks>
    /// <br>Note		: �|���D��ݒ莩���o�^UI�N���X��\�����܂��B</br>
    /// <br>Programmer  : Miwa Honda</br>
    /// <br>Date        : 2013/11/06</br>
    /// <br>UpDate        : 2014/9/19 Miwa Honda�@�T�|�[�g�̊Ǘ����_(1)���Ȃ��Ƃ��G���[</br>
    /// </remarks>
    internal partial class RateProtyMngConvertClass : Form
    {
        #region �� Constructor
        internal RateProtyMngConvertClass()
        {
            InitializeComponent();
        }
        # endregion

        #region Contants

        //�e�[�u�����
        private const string ctSellingPriceTable = "SellingPriceTable";
        private const string ctCostpriceTable = "CostpriceTable";
        private const string ctSelect = "Select";     �@�@�@    �@�@�@�@�@�@�@�@�@ // �I��L��
        private const string ctPriorityOrder = "PriorityOrder"; �@�@�@�@�@�@�@�@ // �|���D�揇��
        private const string ctRateSettingDivideName = "RateSettingDivideName";  // �|���ݒ�敪����
        private const string ctRateCount = "RateCount";       �@�@�@�@�@�@�@�@�@�@// �|������

        private const string ctRateSettingDivide = "RateSettingDivide";       // �|���ݒ�敪
        private const string ctRateMngGoodsCd = "RateMngGoodsCd";       // �|���ݒ�敪�i���i�j
        private const string ctRateMngGoodsNm = "RateMngGoodsNm";       // �|���ݒ薼�́i���i�j
        private const string ctRateMngCustCd = "RateMngCustCd";       // �|���ݒ�敪�i���Ӑ�j
        private const string ctRateMngCustNm = "RateMngCustNm";       // �|���ݒ薼�́i���Ӑ�j

        // �O���b�h�I��F�ݒ� 255, 255, 192
        private readonly Color _selectedBackColor = Color.FromArgb(255, 224, 192);
        private readonly Color _selectedBackColor2 = Color.FromArgb(255, 224, 192);
        # endregion

        # region �v���C�x�C�g�����o
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;
        /// <summary>�]�ƈ�</summary>
        private Employee _employee = null;
        /// <summary>�G���[���b�Z�[�W</summary>
        private string _errMsg = string.Empty;
        /// <summary>���_��񃊃X�g</summary>
        private SecInfoSet[] _secInfoSetList;

        // ���ݑI�����Ă��錏�����J�E���g���Ă������
        /// <summary>�I�������i�����j</summary>
        private int _sellingSelectCnt = 0;
        /// <summary>�I�������i�����j</summary>
        private int _costSelectCnt = 0;

        //�@DataTable�֘A
        /// <summary>DataSet�i�O���b�h�ɔ��f���Ă���Tabel���i�[���Ă���f�[�^�Z�b�g�j</summary>
        private DataSet _dataSet = null;
        /// <summary>����View(�O���b�h�ɔ��f���Ă���VIEW)</summary>
        private DataView _sellingPriceView = null;
        /// <summary>����View(�O���b�h�ɔ��f���Ă���VIEW)</summary>
        private DataView _costPriceView = null;

        /// <summary>���ʎ擾View</summary>
        private DataView _retDispView = null;

        /// <summary>�|���ݒ�Ǘ�Dic</summary>
        Dictionary<string, DataRow> _rateMngOfferDic = null;

        // �A�N�Z�X�N���X�֘A
        /// <summary>�|���D��R���o�[�g�A�N�Z�X�N���X</summary>
        private PMKHN09932AA _rateProtyMngConvertAcs = null;
        /// <summary>�|���ݒ�Ǘ��}�X�^�A�N�Z�X�N���X</summary>
        private RateMngGoodsCust _rateMngGoodsCust = null;
        /// <summary>�|���D��Ǘ��}�X�^�A�N�Z�X�N���X</summary>
        private RateProtyMngAcs _rateProtyMngAcs;

        // �K�C�h
        private PMKHN09931UA.PMKHN09931U_Para _rateDitailFormPara = null;
        private PMKHN09931UA _rateDitailForm = null;

        // �t���O�֘A
        /// <summary>�S�БI���t���O true:�S��</summary>
        private bool _selectAllSecFlg;
        /// <summary>��ʋN���������t���O true:��ʋN��������</summary>
        private bool _showingFlag = false;


        # endregion

        #region �v���p�e�B
        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        internal string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>
        /// ���_���X�g
        /// </summary>
        internal SecInfoSet[] SecInfoSetList 
        {
            get { return _secInfoSetList; }
            set { _secInfoSetList = value; }
        }

        /// <summary>
        /// �u�S�Ёv�I���t���O true:�S��
        /// </summary>
        internal bool SelectAllSecFlg
        {
            get { return _selectAllSecFlg; }
            set { _selectAllSecFlg = value; }
        }

        /// <summary>
        /// �`�F�b�N�{�b�N�X�i�K����ʋN��)
        /// </summary>
        internal bool Confirmation_checkBox
        {
            get { return _confirmation_checkBox; }
            set { _confirmation_checkBox = value; }
        }
        private bool _confirmation_checkBox;

        #endregion


        //#region Public Method
        //================================================================================
        //  internal Method
        //================================================================================

        /// <summary>
        /// �J�n����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �D��ݒ�R���o�[�g���C���v���O�����J�n�B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        internal int StartProc(Form form)
        {
            int status = 0;
            // ��ƃR�[�h�̕\��
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �]�ƈ�
            this._employee = LoginInfoAcquisition.Employee;

            Dictionary<string, RateAddingUpResultsPara> resultsParaDic = null;

            try
            {
                // ���o����ʕ��i�̃C���X�^���X���쐬
                SFCMN00299CA msgForm = new SFCMN00299CA();
                msgForm.Title = "���o��";
                msgForm.Message = "�|���D��Ǘ��}�X�^�쐬���c�B";
                msgForm.Show();

                try
                {
                    //�|������Dictionary�쐬����
                    status = this.RateSetDivCdAddingUp(out resultsParaDic);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;
                }
                finally
                {
                    //form.Visible = false;
                    msgForm.Close();
                }

                bool formShowFlg = false;

                //�@���_���X�g�̍쐬
                this.UtilityDiv_tComboEditor.Items.Clear();
                this.UtilityDiv_tComboEditor.Items.Add(RateProtyMngCnvConst.COM_SECTION_CODE, RateProtyMngCnvConst.COMMON_MODE);
                foreach (SecInfoSet secInfoSet in this._secInfoSetList)
                {
                    this.UtilityDiv_tComboEditor.Items.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet.SectionGuideNm);
                }

                // ��ʋN�������J�n�t���O�Ftrue
                this._showingFlag = true;

                // �K����ʂ��N�����܂�
                if (this.Confirmation_checkBox)
                {
                    formShowFlg = true;�@// ��ʋN��
                }
                else  // ���Ȃ���Ή�ʂ��N�����Ȃ�
                {

                    // ���݃`�F�b�N
                    if (this.ExistsRateProtyMngData() == true) // ���Ȃ���Ώ������s
                    {
                        // �|���ݒ�Ǘ��f�[�^�擾����
                        this.SearchRateMngGoodsCust();

                        RateAddingUpResultsPara resultsPara;

                        // �S�БI�����c�S���_���o�^�A�`�F�b�N���s��
                        if (this._selectAllSecFlg)
                        {
                            // �|���D��Ǘ��f�[�^���݃`�F�b�N
                            foreach (SecInfoSet secInfoSet in this._secInfoSetList)
                            {
                                if (resultsParaDic.TryGetValue(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), out resultsPara))
                                {
                                    // ���̂܂ܓo�^OK�t���O true:���Ȃ��o�^�\
                                    if (resultsPara.countFlg)
                                    {
                                        //�|���D��ݒ�ۑ�����
                                        status = this.SaveRateProtyMng(resultsPara.resultsTbl, secInfoSet.SectionCode.Trim().PadLeft(2, '0'));
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            return status;

                                        // �R���{�{�b�N�X�̔w�i���O���[�ɂ���
                                        this.UtilityDiv_tComboEditor.Value = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                                        this.UtilityDiv_tComboEditor.Items[this.UtilityDiv_tComboEditor.SelectedIndex].Appearance.BackColor = System.Drawing.Color.Gray;
                                    }
                                    else
                                        formShowFlg = true;�@// ��ʋN��
                                }
                                else
                                    // �Ώۂ̊|�����Ȃ��ꍇ����ʂ�\������ΏۂƂ���
                                    formShowFlg = true;
                            }
                        }

                        else // ���_�I�����c�I�����_���o�^�ł���Ή�ʂ�\�������ɏI������
                        {
                            if (resultsParaDic.TryGetValue(this._sectionCode.PadLeft(2, '0'), out resultsPara))
                            {
                                // ���̂܂ܓo�^OK�t���O true:���Ȃ��o�^�\
                                if (resultsPara.countFlg)
                                {
                                    //�|���D��ݒ�ۑ�����
                                    status = this.SaveRateProtyMng(resultsPara.resultsTbl, this._sectionCode);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        return status;
                                }
                                else
                                    formShowFlg = true;�@// ��ʋN��
                            }
                            else
                                formShowFlg = true;�@// ��ʋN��
                        }
                    }
                    else //���݃`�F�b�N�ŃL�����Z���̏ꍇ�͏����I��
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // ��ʋN�������J�n�t���O�Ffalse
                this._showingFlag = false;


                // ��ʋN���̕K�v����
                if (formShowFlg)
                {
                    // ��ʕ\������
                    this.ShowSelectRateProtyMngForm();
                    Close();
                    return status;
                }
                else
                {
                    // ��ʂȂ����X�V�Ώۂ�����΍X�V�ł����I
                    if (resultsParaDic.Count != 0)
                    {
                        TMsgDisp.Show(
                           emErrorLevel.ERR_LEVEL_INFO, 			    �@�@	     // �G���[���x��
                           RateProtyMngCnvConst.ctPGID,							// �A�Z���u��ID
                            "�|���D��Ǘ��}�X�^�̍X�V���������܂����B",               // �\�����郁�b�Z�[�W
                           0,													�@�@     // �X�e�[�^�X�l
                           MessageBoxButtons.OK);							�@�@	// �\������{�^��
                    }
                }
                
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���}�X�^�擾�Ɏ��s���܂����B\r\n" + ex, status, MessageBoxButtons.OK);
                return status;
            }

            return status;

        }


        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int ShowSelectRateProtyMngForm()
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string errMsg;

            Note1.Text = "���ő�20���I���\�ł��B";
            Note2.Text = "���O���[�̋��_�͊��ɓo�^�ς݂̋��_�ł��B";


            //---------------------------------
            // �A�C�R���ݒ�
            //---------------------------------
            ImageList imageList16 = IconResourceManagement.ImageList16;

            //�c�[���o�[�̐ݒ�
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.SAVE];
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Detail"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.DETAILS];

            this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.BASE];
            this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.EMPLOYEE];

            // ���_��
            foreach (SecInfoSet secInfoSet in this._secInfoSetList)
            {
                if (_employee.BelongSectionCode.Trim().PadLeft(2, '0') == secInfoSet.SectionCode.Trim().PadLeft(2, '0'))
                {
                    this.tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"].SharedProps.Caption = secInfoSet.SectionGuideNm;
                    break;
                }
            }

            // ���O�C����
            this.tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();

            //---------------------------------
            // �O���b�h�ݒ�
            //---------------------------------
            // �f�[�^�Z�b�g�X�L�[�}�쐬
            this._dataSet = new DataSet();
            this.DataSetColumnConstruction(ctSellingPriceTable); // �����p�X�L�[�}�쐬
            this.DataSetColumnConstruction(ctCostpriceTable);    // �����p�X�L�[�}�쐬
             
            //�O���b�h�Ƀf�[�^��R�t����
            this._sellingPriceView = _dataSet.Tables[ctSellingPriceTable].DefaultView;
            this._costPriceView = _dataSet.Tables[ctCostpriceTable].DefaultView;

            // GRID�̏����ݒ�
            this.SettingGrid(SellingPrice_Grid, ctSellingPriceTable, this._sellingPriceView); // �����p
            this.SettingGrid(CostPrice_Grid, ctCostpriceTable, this._costPriceView);   // �����p


            // ��ʂ̕\��
            switch (this.ShowDialog())
            {
                case DialogResult.OK:
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;

                case DialogResult.Cancel:
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    break;

                case DialogResult.Abort:
                    errMsg = this._errMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    break;
                default:
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ��ʕ\���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 20089 Miwa Honda</br>
        /// <br>Date       : 2008.12.15</br>
        /// </remarks>
        private void SelectRateProtyMngForm_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        /// <summary>
        /// ��ʕ\���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 20089 Miwa Honda</br>
        /// <br>Date       : 2008.12.15</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "�|���D��Ǘ��}�X�^�쐬���c�B";
            msgForm.Show();

            try
            {
                //�@�D��Ǘ��f�[�^�Z�b�g����
                this.SettingRateProtyMngData();

                // �S�Ђ̏ꍇ�́A�����_�������\������
                if (this._selectAllSecFlg)
                {
                    // �ŏ����玩���_�̏ꍇ�A�o�����[�`�F���W������Ȃ����߈�U�S�Ћ��ʂ�I������
                    this.UtilityDiv_tComboEditor.Value = RateProtyMngCnvConst.COM_SECTION_CODE;
                    // �����_�������\������
                    // this.UtilityDiv_tComboEditor.Value = _employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 2014.09.19 del honda
                }
                else // ���_�I�����͑I�����_�̂܂�
                {
                    this.UtilityDiv_tComboEditor.Value = this._sectionCode;
                }

                // �t�H�[�J�X�̓O���b�h�Ɏ����Ă����i���_�R���{�ς���Ə�������j
                SellingPrice_Grid.Focus();
                CostPrice_Grid.ActiveRow = null;
            }
            finally
            {
                //form.Visible = false;
                msgForm.Close();
            }
        }

        /// <summary>
        /// �|���}�X�^�W�v�����擾����
        /// </summary>
        /// <param name="resultsParaDic">��������</param>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// <returns>status</returns>
        private int RateSetDivCdAddingUp(out Dictionary<string, RateAddingUpResultsPara> resultsParaDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (this._rateProtyMngConvertAcs == null)
                this._rateProtyMngConvertAcs = new PMKHN09932AA();

            string errMsg;
            RateAddingUpResultsPara resultsPara = null;
            resultsParaDic = null;

            // �|���}�X�^�����擾����
            status = this._rateProtyMngConvertAcs.RateSetDivCdAddingUp(out resultsParaDic, this._enterpriseCode, this._sectionCode, out errMsg);
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                 (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {

                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���}�X�^�擾�Ɏ��s���܂����B", status, MessageBoxButtons.OK);
                return status;
            }
            if (resultsParaDic == null)
                return (int)ConstantManagement.DB_Status.ctDB_EOF;

            //�@���_������ꍇ
            if (this._sectionCode != "") 
            {
                // ���_�����肳��Ă���ꍇ�͂��������
                if (resultsParaDic.TryGetValue(this._sectionCode.Trim().PadLeft(2, '0'), out resultsPara))
                {
                    // �\������VIEW
                    this._retDispView = resultsPara.resultsTbl.DefaultView;
                }
            }
            else
            {
                // �S�Ђ̏ꍇ�͎����_����View�ɂ���Ă������Ƃɂ��悤
                if (resultsParaDic.TryGetValue(_employee.BelongSectionCode.Trim().PadLeft(2, '0'), out resultsPara))
                {
                    // �\������VIEW
                    this._retDispView = resultsPara.resultsTbl.DefaultView;
                }
            }
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {

                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���}�X�^�擾�Ɏ��s���܂����B", status, MessageBoxButtons.OK);
                return status;
            }

            return status;
        }

        /// <summary>
        /// �|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g�����i�����E�I���j
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// <returns>status</returns>
        private int SettingRateCount()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "�|�������擾���c�B";
            msgForm.Show();

            Dictionary<string, RateAddingUpResultsPara> resultsParaDic = new Dictionary<string, RateAddingUpResultsPara>();

            try
            {
                // �|���}�X�^�W�v�����擾�����i�A�N�Z�X�N���X���j
                status = this.RateSetDivCdAddingUp(out resultsParaDic);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // �D��Ǘ��f�[�^�Z�b�g����
                // �O���b�h�̐F�ς�������
                for (int i = 0; i < SellingPrice_Grid.Rows.Count; i++)
                {
                    //�@�|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g���� �i�����ݒ�j
                    this.SettingRateCountProc(_sellingPriceView, SellingPrice_Grid.Rows[i]);
                    // �I���E��I��ύX����
                    this.ChangedSelect((bool)SellingPrice_Grid.Rows[i].Cells[ctSelect].Value, SellingPrice_Grid.Rows[i]);

                }
                for (int i = 0; i < CostPrice_Grid.Rows.Count; i++)
                {
                    //�@�|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g���� �i�����ݒ�j
                    this.SettingRateCountProc(_costPriceView, CostPrice_Grid.Rows[i]);
                    // �I���E��I��ύX����
                    this.ChangedSelect((bool)CostPrice_Grid.Rows[i].Cells[ctSelect].Value, CostPrice_Grid.Rows[i]);
                }

                SellingPrice_Grid.UpdateData();
                CostPrice_Grid.UpdateData();

                // �O���b�h�E��̌����擾����
                // �����ݒ�
                GetSelectCount(SellingPrice_Grid);
                //�����ݒ�
                GetSelectCount(CostPrice_Grid);

            }
            finally
            {

                SellingPrice_Grid.Focus();
                CostPrice_Grid.Rows[0].Selected = true;
                SellingPrice_Grid.Rows[0].Selected = true;
                SellingPrice_Grid.Rows[0].Activate();
                CostPrice_Grid.ActiveRow = null;

                msgForm.Close();
            }

            return status;
        }
        #region �C�x���g

        /// <summary>
        /// �|���}�X�^�ڍו\�����
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <param name="rateSettingDivideName">�|���ݒ�敪����</param>
        /// <param name="rateCount">�|������</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �|���}�X�^�̏ڍ׉�ʂ�\�����܂��B</br>
        /// </remarks>
        private void ShowRateDetailForm(int unitPriceKind, string rateSettingDivide, string rateSettingDivideName, string rateCount)
        {
            if ((rateCount == "") || (rateCount == "0"))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�|���ڍ׏�񂪑��݂��܂���B",
                        0, MessageBoxButtons.OK);
                return;
            }

            if (this._rateDitailFormPara == null)
                this._rateDitailFormPara = new PMKHN09931UA.PMKHN09931U_Para();

            this._rateDitailFormPara.SectionCode = this._sectionCode;                //���_�R�[�h
            this._rateDitailFormPara.UnitPriceKind = unitPriceKind;                 //�P�����
            this._rateDitailFormPara.RateSettingDivide = rateSettingDivide;         //�|���ݒ�敪
            this._rateDitailFormPara.RateSettingDivideName = rateSettingDivideName; //�|���ݒ�敪����


            if (this._rateDitailForm == null)
                this._rateDitailForm = new PMKHN09931UA(_rateDitailFormPara);
            
            // �|���ڍ׉�ʋN������
            this._rateDitailForm.Disp_CreditRateDtGuid(this._rateDitailFormPara);

        }

        /// <summary>
        /// ToolClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        Close();
                        break;
                    }
                case "ButtonTool_Search": �@// �����擾����
                    {

                        break;
                    }
                case "ButtonTool_Detail": �@// �I���s�ڍ�
                    {

                        int unitPriceKind = 0;          // �P�����
                        string rateSettingDivide = "";�@// �|���ݒ�敪
                        string rateSettingDivideName = "";�@// �|���ݒ�敪���́@
                        string rateCount = "";

                        if (SellingPrice_Grid.ActiveRow != null)
                        {
                            unitPriceKind = 1;
                            rateSettingDivide = SellingPrice_Grid.ActiveRow.Cells[ctRateSettingDivide].Value.ToString();
                            rateSettingDivideName = SellingPrice_Grid.ActiveRow.Cells[ctRateSettingDivideName].Value.ToString();
                            rateCount = SellingPrice_Grid.ActiveRow.Cells[ctRateCount].Value.ToString();
                        }
                        else if (CostPrice_Grid.ActiveRow != null)
                        {
                            unitPriceKind = 2;
                            rateSettingDivide = CostPrice_Grid.ActiveRow.Cells[ctRateSettingDivide].Value.ToString();
                            rateSettingDivideName = CostPrice_Grid.ActiveRow.Cells[ctRateSettingDivideName].Value.ToString();
                            rateCount = CostPrice_Grid.ActiveRow.Cells[ctRateCount].Value.ToString();
                        }
                        else
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�ڍו\������s��I�����Ă��������B",
                                    0, MessageBoxButtons.OK);
                            return;
                        }

                        // �|���ڍ׉�ʋN��
                        this.ShowRateDetailForm(unitPriceKind, rateSettingDivide, rateSettingDivideName, rateCount);
                        break;
                    }
                case "ButtonTool_Save": �@// �D��ݒ�쐬����
                    {
                        // ���̓`�F�b�N
                        bool chkStatus = this.InputCheckProc();
                        if (!chkStatus)
                            return;

                        DialogResult dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name, "�|���D��Ǘ��}�X�^���쐬���܂��B��낵���ł����H",
                            0, MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.Cancel)
                            return;

                        if (this.ExistsRateProtyMngData() == true)
                        {
                            string msg = "";
                            // �|���D��Ǘ��}�X�^�ۑ�����(��ʑI���f�[�^)
                            int status = this.SaveRateProtyMngFromFormSelect();

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                msg = "�|���D��Ǘ��}�X�^�̍X�V���������܂����B";                        // �R���{�{�b�N�X�̔w�i���O���[�ɂ���
                                this.UtilityDiv_tComboEditor.Items[this.UtilityDiv_tComboEditor.SelectedIndex].Appearance.BackColor = System.Drawing.Color.Gray;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                msg = "�X�V�f�[�^�����݂��܂���ł����B";

                            if (msg != "")
                            {

                                SellingPrice_Grid.Focus();
                                CostPrice_Grid.Rows[0].Selected = true;
                                SellingPrice_Grid.Rows[0].Selected = true;
                                SellingPrice_Grid.Rows[0].Activate();
                                CostPrice_Grid.ActiveRow = null;

                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_INFO, 			    �@�@	     // �G���[���x��
                                RateProtyMngCnvConst.ctPGID,											�@�@    // �A�Z���u��ID
                                msg,                    // �\�����郁�b�Z�[�W
                                0,													�@�@     // �X�e�[�^�X�l
                                MessageBoxButtons.OK);							�@�@	// �\������{�^��
                            }

                        }

                        break;
                    }
            }
        }

        #endregion

        /// <summary>
        ///�@�|���D��Ǘ��}�X�^�ۑ�����(��ʑI���f�[�^)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �|���D��Ǘ��ݒ��ۑ����܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SaveRateProtyMngFromFormSelect()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string compKey;
            DataRow targetRow;

            // --------------------
            // �|���D��Ǘ��̍쐬
            // --------------------
            RateProtyMng rateProtyMng;
            ArrayList retList = new ArrayList();
            // �X�V�f�[�^�̎擾
            // �����ݒ�
            this.SellingPrice_Grid.BeginUpdate();
            this._sellingPriceView.RowFilter = ctSelect;
            for (int i = 0; i < _sellingPriceView.Count; i++)
            {
                compKey = _sellingPriceView[i].Row[ctRateSettingDivide].ToString().Trim();
                if (_rateMngOfferDic.TryGetValue(compKey, out targetRow) == true)
                {
                    // �X�V�|���D��Ǘ��f�[�^�擾����
                    this.GetRateProtyMngWriteData(targetRow, out  rateProtyMng, 1, this._sectionCode);
                    retList.Add(rateProtyMng);
                }
            }
            this._sellingPriceView.RowFilter = "";
            this.SellingPrice_Grid.EndUpdate();

            // �����ݒ�
            this.CostPrice_Grid.BeginUpdate();
            this._costPriceView.RowFilter = ctSelect;
            for (int i = 0; i < _costPriceView.Count; i++)
            {
                compKey = _costPriceView[i].Row[ctRateSettingDivide].ToString().Trim();
                if (_rateMngOfferDic.TryGetValue(compKey, out targetRow) == true)
                {
                    // �X�V�|���D��Ǘ��f�[�^�擾����
                    this.GetRateProtyMngWriteData(targetRow, out  rateProtyMng, 2, this._sectionCode);
                    retList.Add(rateProtyMng);
                }
            }
            this._costPriceView.RowFilter = "";
            this.CostPrice_Grid.EndUpdate();

            // �|���D��Ǘ��̓o�^
            string msg;
            status = this._rateProtyMngAcs.Write(ref retList, out msg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���D��Ǘ��}�X�^�̓o�^�Ɏ��s���܂����B", status, MessageBoxButtons.OK);
                return status;
            }
            if (retList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

        /// <summary>
        ///�@�|���D��Ǘ��}�X�^�ۑ�����()
        /// </summary>
        /// <param name="rateProtyMngList">�X�V�Ώۃf�[�^</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note	   : �|���D��Ǘ��ݒ��ۑ����܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SaveRateProtyMng(DataTable rateProtyMngList,string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList retList = new ArrayList();


            // �X�V�f�[�^�쐬
            if (rateProtyMngList.Rows.Count == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "�|���}�X�^�����݂��܂���ł����B\r\n�|���D��Ǘ��}�X�^���o�^���Ă�������",
                    0, MessageBoxButtons.OK);
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            RateProtyMng rateProtyMng = null;
            // 
            for (int i = 0; i < rateProtyMngList.Rows.Count; i++)
            {
                DataRow dr = rateProtyMngList.Rows[i];
                DataRow targetRow;
                string compKey = dr[PMKHN09932AA.RATESETTINGDIVIDE_TITLE].ToString().Trim();
                if (_rateMngOfferDic.TryGetValue(compKey, out targetRow) == true)
                {
                    // �X�V�|���D��Ǘ��f�[�^�擾����
                    this.GetRateProtyMngWriteData(targetRow, out rateProtyMng, Convert.ToInt32(dr[PMKHN09932AA.UNITPRICEKIND_TITLE]), sectionCode);

                    retList.Add(rateProtyMng);
                }
            }

            // �|���D��Ǘ��̓o�^
            string msg;
            status = this._rateProtyMngAcs.Write(ref retList, out msg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���D��Ǘ��}�X�^�̓o�^�Ɏ��s���܂����B", status, MessageBoxButtons.OK);
                return status;
            }

            return status;
        }


        /// <summary>
        /// �X�V�|���D��Ǘ��f�[�^�擾����
        /// </summary>
        /// <param name="writeList">�X�V�Ώۃf�[�^</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�����͂���Ă��邩�`�F�b�N���܂��B</br>
        /// </remarks>
        private void GetRateProtyMngWriteData(DataRow targetRow, out RateProtyMng rateProtyMng, int unitPriceKind, string sectionCode)
        {
            rateProtyMng = new RateProtyMng();

            // ��ƃR�[�h
            rateProtyMng.EnterpriseCode = this._enterpriseCode;
            // �_���폜�敪
            rateProtyMng.LogicalDeleteCode = 0;
            // ���_�R�[�h
            rateProtyMng.SectionCode = sectionCode;
            // �P�����
            rateProtyMng.UnitPriceKind = unitPriceKind;
            // �|���D�揇��
            rateProtyMng.RatePriorityOrder = Convert.ToInt32(targetRow[11]);
            // �|���ݒ�敪
            rateProtyMng.RateSettingDivide = targetRow[4].ToString();
            // �|���ݒ�敪�i���i�j
            rateProtyMng.RateMngGoodsCd = targetRow[5].ToString();
            // �|���ݒ薼�́i���i�j
            rateProtyMng.RateMngGoodsNm = targetRow[7].ToString();
            // �|���ݒ�敪�i���Ӑ�j
            rateProtyMng.RateMngCustCd = targetRow[6].ToString();
            // �|���ݒ薼�́i���Ӑ�j
            rateProtyMng.RateMngCustNm = targetRow[8].ToString();

        }

        /// <summary>
        /// �|���D��Ǘ��f�[�^���݃`�F�b�N
        /// </summary>
        /// <remarks>
        /// <returns>true:OK�Afalse:NG</returns>
        /// <br>Note		: �o�͗D��Ǘ��f�[�^�����݂��邩�`�F�b�N���܂��B</br>
        /// </remarks>
        private bool ExistsRateProtyMngData()
        {
            int status;
            bool exitChk = true;
            DialogResult dialogResult;

            // �|���D��Ǘ����ݒ肳��ĂȂ����`�F�b�N����
            // �����D��ݒ肪���łɂ���΁A�폜���č�蒼���@���ʏ킠�肦�Ȃ����c�[������
            if (this._rateProtyMngAcs == null)
                this._rateProtyMngAcs = new RateProtyMngAcs();
            ArrayList retList = null;
            int retTotalCnt;
            bool nextData;
            string msg;

            // �S���_���擾�ł��邩�H�@�����_���w�肵�Ă��S���擾����܂��I�I�I
            status = this._rateProtyMngAcs.Search(out retList, out retTotalCnt, out nextData, this._enterpriseCode, this._sectionCode, out msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList delList = new ArrayList();
                if (this._sectionCode != "")
                {
                    foreach (RateProtyMng rateProtyMng in retList)
                    {
                        if (rateProtyMng.SectionCode == this._sectionCode.Trim())
                        {
                            delList.Add(rateProtyMng);
                        }
                    }
                }
                else //�@�S�Ђ̏ꍇ ���S�f�[�^���Ώ�
                    delList.AddRange(retList);

                if (delList.Count > 0)
                {
                    dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "�|���D��Ǘ��}�X�^�����ɐݒ肳��Ă��܂��B\r\n�ȑO�̃f�[�^���폜���Ă�낵���ł����H", 0, MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return false;
                    }

                    // �|���D��Ǘ����폜����
                    status = this._rateProtyMngAcs.Delete(0, ref delList, out msg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���D��Ǘ��}�X�^�̍폜�Ɏ��s���܂����B\r\n�|���D��Ǘ��}�X�^���폜���čēx�ݒ肵�Ă�������", 0, MessageBoxButtons.OK);
                        exitChk = false;
                    }
                    exitChk = true;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                exitChk= true;
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "�|���D��Ǘ��}�X�^�̎擾�Ɏ��s���܂����B\r\n�|���D��Ǘ��}�X�^���폜���čēx�ݒ肵�Ă�������", 0, MessageBoxButtons.OK);
                exitChk = false;
            }


            return exitChk;
        }




        /// <summary>
        /// ValueChanged �C�x���g(UnitPriceKind_tComboEditor)
        /// </summary>
        /// <param name="checkMode">�`�F�b�N���x��</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�����͂���Ă��邩�`�F�b�N���܂��B</br>
        /// </remarks>
        private bool InputCheckProc()
        {
            bool chkFlag = true;  
            string checkMsg = string.Empty;

            try
            {
                if (this.UtilityDiv_tComboEditor.Value.ToString() == string.Empty)
                {
                    chkFlag = false;
                    checkMsg = "���_��I�����Ă��������B";
                }

                // �����O���b�h�������O���b�h
                else if ((this._sellingSelectCnt == 0) && (this._costSelectCnt == 0))
                {
                    chkFlag = false;
                    checkMsg = "�ۑ��Ώۂ�I�����Ă��������B";
                }
                // �����O���b�h
                else if (this._sellingSelectCnt > 20)
                {
                    chkFlag = false;
                    checkMsg = "�����ݒ�̑I����20���𒴂��Ă��܂��B\r\n20���ȓ��Őݒ肵�Ă��������B";
                }
                // �����O���b�h
                else if (this._costSelectCnt > 20)
                {
                    chkFlag = false;
                    checkMsg = "�����ݒ�̑I����20���𒴂��Ă��܂��B\r\n20���ȓ��Őݒ肵�Ă��������B";
                }
            }
            finally
            {
                if (!chkFlag)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, checkMsg, 0, MessageBoxButtons.OK);
                }

                this._sellingPriceView.RowFilter = "";
                this.SellingPrice_Grid.EndUpdate();
                this._costPriceView.RowFilter = "";
                this.CostPrice_Grid.EndUpdate();
            }

            return chkFlag;
        }


        /// <summary>
        /// �|���ݒ�Ǘ� �f�[�^�Z�b�g�i�����E�I���ȊO�j
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̏����\���ݒ���s���܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SettingRateProtyMngData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �|���ݒ�Ǘ��f�[�^ DataRow�Z�b�g����
            this._dataSet.Tables[ctSellingPriceTable].Clear();
            this._dataSet.Tables[ctCostpriceTable].Clear();

            // �|���ݒ�Ǘ��f�[�^�擾���� �܂����擾�Ȃ�擾
            if (this._rateMngOfferDic == null)
                status = SearchRateMngGoodsCust();


            foreach (DataRow dr in _rateMngOfferDic.Values)
            {
                //�@�|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g���� �i�����ݒ�j
                this.SettingTableRow(ctSellingPriceTable, dr);
                //�@�|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g���� �i�����ݒ�j
                this.SettingTableRow(ctCostpriceTable, dr);
            }

            return status;
        }

        /// <summary>
        /// �I�������擾����
        /// </summary>
        /// <param name="cntFlg">true:�J�E���gUP,false:�J�E���g�_�E��</param>
        /// <param name="targetGrid"></param>
        /// <remarks>
        /// <br>Note	   : GRID�̑I���������擾���܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void GetSelectCount(bool cntFlg, Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (targetGrid.Name == "SellingPrice_Grid")
            {
                if (cntFlg)
                    this._sellingSelectCnt++;
                else if (!cntFlg)
                    this._sellingSelectCnt--;

                this.sellingCnt_label.Text = GetCntLabelName(this._sellingSelectCnt);
            }
            else if (targetGrid.Name == "CostPrice_Grid")
            {
                if (cntFlg)
                    this._costSelectCnt++;
                else if (!cntFlg)
                    this._costSelectCnt--;

                this.costCnt_label.Text = GetCntLabelName(this._costSelectCnt);
            }
        }

        /// <summary>
        /// �I�������擾����
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <remarks>
        /// <br>Note	   : GRID�̑I���������擾���܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void GetSelectCount(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (targetGrid.Name == "SellingPrice_Grid")
            {
                targetGrid.BeginUpdate();
                this._sellingPriceView.RowFilter = ctSelect;
                this._sellingSelectCnt = this._sellingPriceView.Count;
                this.sellingCnt_label.Text = GetCntLabelName(this._sellingSelectCnt);
                this._sellingPriceView.RowFilter = "";
                targetGrid.EndUpdate();

            }
            else if (targetGrid.Name == "CostPrice_Grid")
            {
                targetGrid.BeginUpdate();
                this._costPriceView.RowFilter = ctSelect;
                this._costSelectCnt = this._costPriceView.Count;
                this.costCnt_label.Text = GetCntLabelName(this._costSelectCnt);
                this._costPriceView.RowFilter = "";
                targetGrid.EndUpdate();
            }
        }


        /// <summary>
        /// �������x�����擾
        /// </summary>
        private string GetCntLabelName(int cnt)
        {
            return "�I��" + cnt + "��";
        }

        /// <summary>
        /// �|���ݒ�Ǘ��f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �|���ݒ�}�X�^�Ǘ��f�[�^���擾���܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SearchRateMngGoodsCust()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //�܂��f�[�^���擾���Ă��Ȃ��Ȃ�
            if (this._rateMngOfferDic == null)
            {
                // �|���ݒ�Ǘ��}�X�^�A�N�Z�X�N���X
                if (this._rateMngGoodsCust == null)
                    this._rateMngGoodsCust = new RateMngGoodsCust();

                
                DataTable retTable = null;
                int retCount;
                bool nextData;
                string message;
                status = this._rateMngGoodsCust.SearchAll(out retTable, out retCount, out nextData,
                    this._enterpriseCode, this._sectionCode, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                    }

                    // �񋟃f�[�^�T�[�`
                    TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrLvl,                           // �G���[���x��
                            this.Name,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,			                // �v���O��������
                            "SearchAll", 							// ��������
                            TMsgDisp.OPE_GET,                   // �I�y���[�V����
                            "�|���ݒ�Ǘ��f�[�^�̎擾�Ɏ��s���܂����B",					    // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._rateMngGoodsCust,    	        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��

                    return status;
                }

                this._rateMngOfferDic = new Dictionary<string, DataRow>();

                string key;
                for (int i = 0; i < retTable.Rows.Count; i++)
                {
                    key = retTable.Rows[i][4].ToString().Trim();   // �|���ݒ�敪
                    _rateMngOfferDic.Add(key, retTable.Rows[i]);
                }

               
            }

            return status;
        }

        /// <summary>
        /// �|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ݒ�Ǘ��}�X�^�̃f�[�^���Z�b�g���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void SettingTableRow(string dataTableName, DataRow getRow)
        {
            // �����ݒ�̏ꍇ
            if ((string)dataTableName == ctCostpriceTable)
            {
                if ((int)getRow[11] < 51 && (int)getRow[11] != 6)
                {
                    return;
                }
            }

            // ���C���e�[�u���ւ̓o�^
            DataRow dataRow = this._dataSet.Tables[dataTableName].NewRow();

            // �I���`�F�b�N
            dataRow[ctSelect] = false;
            // �|���ݒ�敪
            dataRow[ctRateSettingDivide] = getRow[4];
            // �|���ݒ�敪�i���i�j
            dataRow[ctRateMngGoodsCd] = getRow[5];  //dr[RateProtyMngAcs.RATEMNGGOODSCD];
            // �|���ݒ�敪�i���Ӑ�j
            dataRow[ctRateMngCustCd] = getRow[6];   //dr[RateProtyMngAcs.RATEMNGCUSTCD];
            // �|���ݒ薼�́i���i�j
            dataRow[ctRateMngGoodsNm] = getRow[7];  //dr[RateProtyMngAcs.RATEMNGGOODSNM];
            // �|���ݒ薼�́i���Ӑ�j
            dataRow[ctRateMngCustNm] = getRow[8];  //dr[RateProtyMngAcs.RATEMNGCUSTNM];
            // �D�揇��
            dataRow[ctPriorityOrder] = getRow[11];

            // �|���ݒ�敪����
            dataRow[ctRateSettingDivideName] = getRow[12];

            this._dataSet.Tables[dataTableName].Rows.Add(dataRow);

        }

        /// <summary>
        /// �|���ݒ�Ǘ��}�X�^�@DataRow�Z�b�g�����i�����E�I���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : Grid�́u�����v��Ɓu�I���v��ɒl���Z�b�g���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void SettingRateCountProc(DataView targetView, Infragistics.Win.UltraWinGrid.UltraGridRow targetRow)
        {

            // �P����ނ̎擾
            string unitPriceKind = "";
            if (targetView == this._sellingPriceView)
            {
                unitPriceKind = "1";
            }
            else if (targetView == this._costPriceView)
            {
                unitPriceKind = "2";
            }

            // �����̎擾 
            this._retDispView.RowFilter =
                 PMKHN09932AA.RATESETTINGDIVIDE_TITLE + " = " + " '" + targetRow.Cells[ctRateSettingDivide].Value.ToString() + "' " + " AND " +
                 PMKHN09932AA.UNITPRICEKIND_TITLE + " = " + unitPriceKind;
            if (this._retDispView.Count != 0)
            {
                // ����
                //targetRow.Cells[ctRateCount].Value = (Convert.ToInt32(_retDispView[0][PMKHN09932AA.COUNT_TITLE])).ToString();
                targetRow.Cells[ctRateCount].Value = _retDispView[0][PMKHN09932AA.COUNT_TITLE].ToString();
                // �I��
                targetRow.Cells[ctSelect].Value = (bool)true;
            }
            else
            {
                // ����
                targetRow.Cells[ctRateCount].Value = "";
                // �I��
                targetRow.Cells[ctSelect].Value = (bool)false;
            }

        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
		/// </remarks>
        private void DataSetColumnConstruction(string dataTableName)
        {

            DataTable targetTable = new DataTable(dataTableName);

            //�J�����̐ݒ�
            targetTable.Columns.Add(ctSelect, typeof(bool));                 // �I��    
            targetTable.Columns.Add(ctPriorityOrder, typeof(int));          // �D�揇�� 
            targetTable.Columns.Add(ctRateSettingDivideName, typeof(string));        �@�@// �|���ݒ�敪����  
            targetTable.Columns.Add(ctRateCount, typeof(string));               // ����
            targetTable.Columns.Add(ctRateSettingDivide, typeof(string));          // �|���ݒ�敪
            targetTable.Columns.Add(ctRateMngGoodsCd, typeof(string));          // �|���ݒ�敪�i���i�j
            targetTable.Columns.Add(ctRateMngGoodsNm, typeof(string));          // �|���ݒ薼�́i���i�j
            targetTable.Columns.Add(ctRateMngCustCd, typeof(int));          // �|���ݒ�敪�i���Ӑ�j
            targetTable.Columns.Add(ctRateMngCustNm, typeof(string));          // �|���ݒ薼�́i���Ӑ�j
            _dataSet.Tables.Add(targetTable);
        }

        /// <summary>
        /// GRID�̏����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̏����\���ݒ���s���܂�</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void SettingGrid(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid,  string dataTableName, DataView tarGetDataView)
        {
            targetGrid.DataSource = tarGetDataView;

            //�\�[�g����ݒ肷��(�D�揇�ʏ��j
            tarGetDataView.Sort = ctPriorityOrder;

            // ��U�S�ẴJ�������\���ɐݒ肷��
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn clmn in targetGrid.DisplayLayout.Bands[dataTableName].Columns)
            {
                clmn.Hidden = true;
            }

            // �O���b�h�̐ݒ�
            Infragistics.Win.UltraWinGrid.UltraGridColumn column;

            // ----- GRID�̃J�����ݒ� ----- //
            //�I��
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctSelect];
            column.Header.Caption = "�I��";
            column.Hidden = false;
            column.Width = 10;
            column.MaxWidth = 30;
            column.MinWidth = 30;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.CellAppearance.Cursor = Cursors.Hand;

            //�D�揇��
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctPriorityOrder];
            column.Header.Caption = "�D�揇��";
            column.Hidden = false;
            column.Width = 80;
            column.MaxWidth = 80;
            column.MinWidth = 80;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //�|���ݒ�敪����
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctRateSettingDivideName];
            column.Header.Caption = "�|���ݒ�敪����";
            column.Hidden = false;
            column.Width = 400;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //�|������
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctRateCount];
            column.Header.Caption = "�|������";
            column.Hidden = false;
            column.Width = 80;
            column.MaxWidth = 80;
            column.MinWidth = 80;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            // ----- GRID�̊O�ϐݒ� ----- //

            //�I����@���s�I���ɐݒ�B
            targetGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //1�s�I��ݒ�
            targetGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            // �����X�N���[�����ŏI���ڂ��\�����ꂽ���_�ŏI������ɐݒ�
            targetGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            // �s�̊O�ϐݒ�
            targetGrid.DisplayLayout.Override.RowAppearance.BackColor = System.Drawing.Color.White;

            // �Œ��͔�\���Ƃ���
            targetGrid.DisplayLayout.Bands[0].Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            // 1�s�����̊O�ϐݒ�
            targetGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.Lavender;

            targetGrid.DisplayLayout.Override.RowAppearance.ForeColorDisabled = System.Drawing.Color.Black;

            //�O���b�h���K�w�\�����Ȃ��i�o�C���h�����f�[�^�Z�b�g���Ŕz�񓙂��L��ꍇ�O���b�h���K�w�ŕ\������邽�߁j
            targetGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

            // �I���s�̊O�ϐݒ�
            // �I�����W
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Black;
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColorDisabled = Color.Black;

            // �A�N�e�B�u�Z���̊O�ϐݒ�
            // �I�����W
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColorDisabled = Color.Black;

            // �w�b�_�[�̊O�ϐݒ�
            targetGrid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            targetGrid.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            targetGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            targetGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            targetGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            targetGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            targetGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            targetGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            //�s�Z���N�^�[�̊O�ϐݒ�
            targetGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            targetGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            targetGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;


            // �񕝂̎�������
            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }


        /// <summary>
        /// �I���E��I��ύX����
        /// </summary>
        /// <param name="isSelected">[T:�I��,F:��I��]</param>
        /// <param name="gridRow">�Ώۂ̃O���b�h�s</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �I���E��I����Ԃ�ύX���܂��B</br>
        /// </remarks>
        private void ChangedSelect(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // �Ώۍs�̑I��F��ݒ肷��
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                gridRow.Cells[ctSelect].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
                gridRow.Cells[ctSelect].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.Default;

            }
        }

        /// <summary>
        /// UltraGrid KeyDown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Select_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // �C�x���g�\�[�X�̎擾
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            //����������Ă��Ȃ�������Ȃɂ����Ȃ�
            if (e.KeyCode == Keys.Up)
            {
                // �O���b�h�̈�ԏ�ƌ�������
                if (targetGrid.ActiveRow.Index == 0)
                {
                    UtilityDiv_tComboEditor.Focus();
                    targetGrid.ActiveRow = null;
                    return;
                }
            }   
          
            if (e.KeyCode == Keys.Right)
            {
                if (sender == SellingPrice_Grid)
                {
                    CostPrice_Grid.Focus();
                    CostPrice_Grid.Rows[0].Activate();
                    CostPrice_Grid.Rows[0].Selected = true;
                    SellingPrice_Grid.ActiveRow = null;
                    return;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (sender == CostPrice_Grid)
                {
                    SellingPrice_Grid.Focus();
                    SellingPrice_Grid.Rows[0].Activate();
                    SellingPrice_Grid.Rows[0].Selected = true;
                    CostPrice_Grid.ActiveRow = null;
                    return;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                // �I���t���O��ύX����
                targetGrid.ActiveRow.Cells[ctSelect].Value = !(Boolean)targetGrid.ActiveRow.Cells[ctSelect].Value;
                // �F��ς���
                this.ChangedSelect((bool)targetGrid.ActiveRow.Cells[ctSelect].Value, targetGrid.ActiveRow);
                // �������擾����
                GetSelectCount((bool)targetGrid.ActiveRow.Cells[ctSelect].Value, targetGrid);
                // �f�[�^�m��
                targetGrid.UpdateData();
            }

            if (sender == SellingPrice_Grid)
                CostPrice_Grid.ActiveRow = null;
            else if (sender == CostPrice_Grid)
                SellingPrice_Grid.ActiveRow = null;


        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �O���b�h��ŃN���b�N���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void Select_Grid_Click(object sender, EventArgs e)
        {
            // �C�x���g�\�[�X�̎擾
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            if (sender == SellingPrice_Grid)
                CostPrice_Grid.ActiveRow = null;
            else if (sender == CostPrice_Grid)
                SellingPrice_Grid.ActiveRow = null;

            try
            {
                Infragistics.Win.UltraWinGrid.UltraGrid ugSender = sender as Infragistics.Win.UltraWinGrid.UltraGrid;

                // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
                Point point = System.Windows.Forms.Cursor.Position;
                Infragistics.Win.UltraWinGrid.UltraGridCell ugCell = this.getClickCell(point, ugSender);

                //�Z������Ȃ��Ƃ��낪�N���b�N����Ă����ꍇ
                if (ugCell == null)
                {
                    return;
                }

                //�N���b�N�����������I���̗񂶂�Ȃ������ꍇ
                if (ugCell.Column.Key != ctSelect)
                {
                    return;
                }

                //�ύX�ł��Ȃ��O���b�h���N���b�N�����Ƃ��@// �S�Ћ��ʂ��g�����������Ȃ̂Ń`�F�b�N���͂����Ă��悢�I
                //if ((ugCell.Row.Cells[ctRateSettingDivide].Value.ToString() == "2A") ||
                //    (ugCell.Row.Cells[ctRateSettingDivide].Value.ToString() == "4A") ||
                //    (ugCell.Row.Cells[ctRateSettingDivide].Value.ToString() == "6A"))
                //{
                //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, ugCell.Row.Cells[ctRateSettingDivideName].Value.ToString() + "�͕K�{���ڂł��B", 0, MessageBoxButtons.OK);
                //    return;
                //}

                ugCell.Row.Cells[ctSelect].Value = !(bool)ugCell.Row.Cells[ctSelect].Value;
                
                // �F��ς���
                this.ChangedSelect((bool)ugCell.Row.Cells[ctSelect].Value, ugCell.Row);

                // �������擾����
                GetSelectCount((bool)ugCell.Row.Cells[ctSelect].Value, targetGrid);

                // �f�[�^�m��
                targetGrid.UpdateData();

            }
            catch
            {

            }
        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �O���b�h��Ń_�u���N���b�N���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void Select_Grid_DoubleClick(object sender, EventArgs e)
        {
            // �C�x���g�\�[�X�̎擾
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            try
            {
                Infragistics.Win.UltraWinGrid.UltraGrid ugSender = sender as Infragistics.Win.UltraWinGrid.UltraGrid;

                // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
                Point point = System.Windows.Forms.Cursor.Position;
                Infragistics.Win.UltraWinGrid.UltraGridCell ugCell = this.getClickCell(point, ugSender);

                //�Z������Ȃ��Ƃ��낪�N���b�N����Ă����ꍇ
                if (ugCell == null)
                {
                    return;
                }

                // �|���}�X�^�ڍו\�����
                int unitPriceKind = 0; // �P�����
                if (targetGrid.Name == "SellingPrice_Grid")
                    unitPriceKind = 1;
                else
                    unitPriceKind = 2;

                
                string rateSettingDivide = ugCell.Row.Cells[ctRateSettingDivide].Value.ToString(); // �|���ݒ�敪
                string rateSettingDivideName = ugCell.Row.Cells[ctRateSettingDivideName].Value.ToString(); // �|���ݒ�敪
                string rateCount = ugCell.Row.Cells[ctRateCount].Value.ToString(); // �|���ݒ�敪
                // �|���ڍ׉�ʋN��
                this.ShowRateDetailForm(unitPriceKind, rateSettingDivide, rateSettingDivideName, rateCount);

            }
            catch
            {

            }
        }


        /// <summary>
        /// ���_�R���{�{�b�N�X�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void UtilityDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._showingFlag == true) return;

            this._sectionCode = UtilityDiv_tComboEditor.Value.ToString();

            // �|���}�X�^�W�v�����擾����
            this.SettingRateCount();
        }


        private void UtilityDiv_tComboEditor_KeyDown(object sender, KeyEventArgs e)
        {

        }


        /// <summary>
        /// �N���b�N�ʒu�̃Z�����擾����
        /// �Z���ȊO���N���b�N����Ă�����null��Ԃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //if (e.PrevCtrl == UtilityDiv_tComboEditor)
            //{
            //    e.NextCtrl = SellingPrice_Grid;
            //    SellingPrice_Grid.Rows[0].Activate();
            //    SellingPrice_Grid.Rows[0].Selected = true;
            //}

        }

        /// <summary>
        /// �N���b�N�ʒu�̃Z�����擾����
        /// �Z���ȊO���N���b�N����Ă�����null��Ԃ�
        /// </summary>
        /// <param name="point">���W</param>
        /// <param name="ugClick">UltraGrid</param>
        /// <returns></returns>
        private Infragistics.Win.UltraWinGrid.UltraGridCell getClickCell(Point point, Infragistics.Win.UltraWinGrid.UltraGrid ugClick)
        {
            point = ugClick.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = ugClick.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement == null)
            {
                return null;
            }
            objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

            // �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z�����܂��B
            if (objRowCellAreaUIElement == null)
            {
                return null;
            }

            Infragistics.Win.UltraWinGrid.UltraGridCell ugCell;

            //�N���b�N�����������񂶂�Ȃ������ꍇ
            if ((ugCell = objElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell)) as Infragistics.Win.UltraWinGrid.UltraGridCell) == null)
            {
                return null;
            }

            return ugCell;
        }




    }
}