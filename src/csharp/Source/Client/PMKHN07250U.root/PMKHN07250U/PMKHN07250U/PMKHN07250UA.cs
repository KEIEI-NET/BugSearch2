//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �݌Ƀ}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/23  �C�����e : PVCS245 �\�[�g���s��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ƀ}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�i�G�N�X�|�[�g�jUI�t�H�[���N���X</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07250UA : Form, IExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �݌Ƀ}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07250UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //���O�C�����_�R�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._stockSetExpAcs = new StockSetExpAcs();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            DataSetColumnConstruction();
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // �N���XID
        private const string ct_ClassID = "PMKHN07150UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07150U";
        // CSV����
        private string _printName = "�݌Ƀ}�X�^�i�G�N�X�|�[�g�j";
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // ���O�C�����_(�����_)
        private string _loginSectionCode;

        private GoodsAcs _goodsAcs;

        //�q�ɃK�C�h
        private WarehouseAcs _warehouseGuideAcs = null;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private StockExpWork _stockExpWork;

        // �f�[�^�A�N�Z�X
        private StockSetExpAcs _stockSetExpAcs;

        #endregion �� Private Member

        #region �� Private Const

        // dataview���̗p
        private const string SECTIONCODE = "SectionCode"; // �Ǘ����_
        private const string WAREHOUSECODE = "WarehouseCode"; // �q��
        private const string GOODSMAKERCD = "GoodsMakerCd"; // ���[�J�[
        private const string GOODSNO = "GoodsNo"; // �i��
        private const string STOCKUNITPRICEFL = "StockUnitPriceFl";// �I���]���P��
        private const string SUPPLIERSTOCK = "SupplierStock";// �d���݌ɐ�
        private const string SHIPMENTCNT = "ShipmentCnt";// ���א��i���v��j
        private const string ARRIVALCNT = "ArrivalCnt";// �ݏo���i���v��j
        private const string ACPODRCOUNT = "AcpOdrCount";// �󒍐�
        private const string MOVINGSUPLISTOCK = "MovingSupliStock";// �ړ����݌Ɏd����
        private const string SHIPMENTPOSCNT = "ShipmentPosCnt";// ���݌ɐ�
        private const string SALESORDERCOUNT = "SalesOrderCount";// �����c
        private const string STOCKDIV = "StockDiv";// �݌ɋ敪
        private const string MINIMUMSTOCKCNT = "MinimumStockCnt";// �Œ�݌ɐ�
        private const string MAXIMUMSTOCKCNT = "MaximumStockCnt";// �ō��݌ɐ�
        private const string SALESORDERUNIT = "SalesOrderUnit";// �������b�g
        private const string STOCKSUPPLIERCODE = "StockSupplierCode";// ������
        private const string WAREHOUSESHELFNO = "WarehouseShelfNo";// �I��
        private const string DUPLICATIONSHELFNO1 = "DuplicationShelfNo1";// �d���I�ԂP
        private const string DUPLICATIONSHELFNO2 = "DuplicationShelfNo2";// �d���I�ԂQ
        private const string PARTSMANAGEMENTDIVIDE1 = "PartsManagementDivide1";// �Ǘ��敪�P
        private const string PARTSMANAGEMENTDIVIDE2 = "PartsManagementDivide2";// �Ǘ��敪�Q
        private const string STOCKNOTE1 = "StockNote1";// �݌ɔ��l�P
        private const string STOCKNOTE2 = "StockNote2";// �݌ɔ��l�Q

        private const string PRINTSET_TABLE = "STOCKRF";
        private const string PMKHN07250U_PRPID = "PMKHN07250U.xml";

        private const string NUMBER_FORMAT9 = "##0.00";
        private const string NUMBER_FORMAT8 = "##0.00";
        #endregion

        #region �� IExportConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Method
        /// <summary>
        /// ����߰đO�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ����߰đO�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public bool ExportBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            // ���̓`�F�b�N����
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���o�f�[�^����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = 0;

            this.uLabel_OutPutNum.Text = "0";

            ArrayList exportSets = null;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�G�N�X�|�[�g��";
            form.Message = "���݁A�f�[�^���G�N�X�|�[�g���ł��B";

            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._stockSetExpAcs.Search(
                    out exportSets,
                    this._enterpriseCode,
                    this._stockExpWork);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // �݌Ƀ}�X�^�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (StockSetExp stockSetExp in exportSets)
                        {
                            SecExportSetToDataSet(stockSetExp.Clone(), index);
                            ++index;
                        }
                        // ADD 2009/06/23 --->>>
                        // �\�[�g���s��
                        this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = SECTIONCODE + "," + WAREHOUSECODE + "," + GOODSMAKERCD + "," + GOODSNO;
                        // ADD 2009/06/23 ---<<<
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN07250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�݌Ƀ}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._stockSetExpAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07250U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return 0;
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._stockExpWork = new StockExpWork();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.uiMemInput1.OptionCode = "0";

            // ��ʕ\��
            this.Show();
            return;
        }

        /// <summary>
        /// ����߰Ċ�������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ����߰Ċ����������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");
        }
        #endregion  �� Public Method
        #endregion �� IExportConditionInpType �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tEdit_TextFileName.DataText = string.Empty;

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_MarkerGuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MarkerGuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

                // �����t�H�[�J�X�Z�b�g
                this.tEdit_WarehouseCode_St.Focus();

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion �� ��ʏ���������

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note	   : �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion �� �{�^���A�C�R���ݒ菈��
        #endregion �� ��ʏ������֌W

        #region �� ����߰đO����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : �����</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // �q��
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_St.DataText.TrimEnd()) && !r.IsMatch(this.tEdit_WarehouseCode_St.DataText))
            {
                this.tEdit_WarehouseCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tEdit_WarehouseCode_Ed.DataText))
            {
                this.tEdit_WarehouseCode_Ed.Text = String.Empty;
            }

            // ���[�J�[
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_St.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_St.DataText))
            {
                this.tNedit_GoodsMakerCd_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_Ed.DataText))
            {
                this.tNedit_GoodsMakerCd_Ed.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_St.DataText.Contains("�@") || this.tEdit_GoodsNo_St.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_Ed.DataText.Contains("�@") || this.tEdit_GoodsNo_Ed.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
            Regex r1 = new Regex(@"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$");
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_St.DataText))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_Ed.DataText))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // Coopy�`�F�b�N
            WordCoopyCheck();

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";

            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = "�e�L�X�g�t�@�C��������͂��Ă��������B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            {
                errMessage = "CSV�t�@�C���p�X���s���ł��B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            // �q�Ɂi�J�n�`�I���j
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_St.DataText.TrimEnd()) &&
                !String.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) &&
                Int32.Parse(this.tEdit_WarehouseCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("�q��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
                return status;
            }

            // ���[�J�[
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // �i��
            if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty &&
                this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�i��{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            return status;
        }
        #endregion �� ���̓`�F�b�N����

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ����߰ď����ݒ菈��(��ʁ�����߰ď���)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		 : ��ʁ�����߰ď����֐ݒ肷��B</br>
        /// <br>Programmer �@: �����</br>
        /// <br>Date       �@: 2009.05.14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �J�n�q�ɃR�[�h
                this._stockExpWork.WarehouseCodeSt = this.tEdit_WarehouseCode_St.DataText.Trim();
                // �I���q�ɃR�[�h
                this._stockExpWork.WarehouseCodeEd = this.tEdit_WarehouseCode_Ed.DataText.Trim();
                // �J�n���[�J�[
                this._stockExpWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // �I�����[�J�[
                this._stockExpWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // �J�n���[�J�[
                this._stockExpWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;
                // �I�����[�J�[
                this._stockExpWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� ���o�����ݒ菈��(��ʁ����o����)
        #endregion �� ����߰đO����

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion �� �G���[���b�Z�[�W�\������

        #region DataSet�֘A
        /// <summary>
        /// �݌Ƀ}�X�^�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="stockSetExp">�݌Ƀ}�X�^�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SecExportSetToDataSet(StockSetExp stockSetExp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (String.IsNullOrEmpty(stockSetExp.SectionCode.Trim()))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = "00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = stockSetExp.SectionCode; // �Ǘ����_
            }
            if (String.IsNullOrEmpty(stockSetExp.WarehouseCode.Trim()))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSECODE] = "0000";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSECODE] = stockSetExp.WarehouseCode; // �q��
            }

            if (stockSetExp.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = "0"; // ���[�J�[
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = stockSetExp.GoodsMakerCd.ToString("0000"); // ���[�J�[
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = stockSetExp.GoodsNo;// �i��
            if (stockSetExp.StockUnitPriceFl == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKUNITPRICEFL] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKUNITPRICEFL] = stockSetExp.StockUnitPriceFl.ToString(NUMBER_FORMAT9); // �I���]���P��
            }
            if (stockSetExp.SupplierStock == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERSTOCK] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SUPPLIERSTOCK] = stockSetExp.SupplierStock.ToString(NUMBER_FORMAT9); // �d���݌ɐ�
            }
            if (stockSetExp.ShipmentCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTCNT] = stockSetExp.ShipmentCnt.ToString(NUMBER_FORMAT9); // ���א��i���v��j
            }
            if (stockSetExp.ArrivalCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ARRIVALCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ARRIVALCNT] = stockSetExp.ArrivalCnt.ToString(NUMBER_FORMAT8); // �ݏo���i���v��j
            }

            if (stockSetExp.AcpOdrCount == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ACPODRCOUNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ACPODRCOUNT] = stockSetExp.AcpOdrCount.ToString(NUMBER_FORMAT8); // �󒍐�
            }
            if (stockSetExp.MovingSupliStock == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MOVINGSUPLISTOCK] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MOVINGSUPLISTOCK] = stockSetExp.MovingSupliStock.ToString(NUMBER_FORMAT8); // �ړ����݌Ɏd����
            }
            if (stockSetExp.ShipmentPosCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTPOSCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SHIPMENTPOSCNT] = stockSetExp.ShipmentPosCnt.ToString(NUMBER_FORMAT8); // ���݌ɐ�
            }
            if (stockSetExp.SalesOrderCount == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESORDERCOUNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESORDERCOUNT] = stockSetExp.SalesOrderCount.ToString(NUMBER_FORMAT8); // �����c
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKDIV] = stockSetExp.StockDiv.ToString(); // �݌ɋ敪

            if (stockSetExp.MinimumStockCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MINIMUMSTOCKCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MINIMUMSTOCKCNT] = stockSetExp.MinimumStockCnt.ToString(NUMBER_FORMAT8); // �Œ�݌ɐ�
            }
            if (stockSetExp.MaximumStockCnt == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAXIMUMSTOCKCNT] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAXIMUMSTOCKCNT] = stockSetExp.MaximumStockCnt.ToString(NUMBER_FORMAT8); // �ō��݌ɐ�
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESORDERUNIT] = stockSetExp.SalesOrderUnit.ToString(); // �������b�g

            if (stockSetExp.StockSupplierCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKSUPPLIERCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKSUPPLIERCODE] = stockSetExp.StockSupplierCode.ToString("000000"); // ������
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][WAREHOUSESHELFNO] = stockSetExp.WarehouseShelfNo; // �I��
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DUPLICATIONSHELFNO1] = stockSetExp.DuplicationShelfNo1; // �d���I�ԂP
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DUPLICATIONSHELFNO2] = stockSetExp.DuplicationShelfNo2; // �d���I�ԂQ
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSMANAGEMENTDIVIDE1] = stockSetExp.PartsManagementDivide1; // �Ǘ��敪�P
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PARTSMANAGEMENTDIVIDE2] = stockSetExp.PartsManagementDivide2; // �Ǘ��敪�Q
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKNOTE1] = stockSetExp.StockNote1; // �݌ɔ��l�P
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][STOCKNOTE2] = stockSetExp.StockNote2; // �݌ɔ��l�Q
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));// �Ǘ����_
            PrintSetTable.Columns.Add(WAREHOUSECODE, typeof(string));// �q��
            PrintSetTable.Columns.Add(GOODSMAKERCD, typeof(string));// ���[�J�[
            PrintSetTable.Columns.Add(GOODSNO, typeof(string));// �i��
            PrintSetTable.Columns.Add(STOCKUNITPRICEFL, typeof(string));// �I���]���P��
            PrintSetTable.Columns.Add(SUPPLIERSTOCK, typeof(string));// �d���݌ɐ�
            PrintSetTable.Columns.Add(ARRIVALCNT, typeof(string));// ���א��i���v��j
            PrintSetTable.Columns.Add(SHIPMENTCNT, typeof(string));// �ݏo���i���v��j
            PrintSetTable.Columns.Add(ACPODRCOUNT, typeof(string));// �󒍐�
            PrintSetTable.Columns.Add(MOVINGSUPLISTOCK, typeof(string));// �ړ����݌Ɏd����
            PrintSetTable.Columns.Add(SHIPMENTPOSCNT, typeof(string));// ���݌ɐ�
            PrintSetTable.Columns.Add(SALESORDERCOUNT, typeof(string));// �����c
            PrintSetTable.Columns.Add(STOCKDIV, typeof(string));// �݌ɋ敪
            PrintSetTable.Columns.Add(MINIMUMSTOCKCNT, typeof(string));// �Œ�݌ɐ�
            PrintSetTable.Columns.Add(MAXIMUMSTOCKCNT, typeof(string));// �ō��݌ɐ�
            PrintSetTable.Columns.Add(SALESORDERUNIT, typeof(string));// �������b�g
            PrintSetTable.Columns.Add(STOCKSUPPLIERCODE, typeof(string));// ������
            PrintSetTable.Columns.Add(WAREHOUSESHELFNO, typeof(string));// �I��
            PrintSetTable.Columns.Add(DUPLICATIONSHELFNO1, typeof(string));// �d���I�ԂP
            PrintSetTable.Columns.Add(DUPLICATIONSHELFNO2, typeof(string));// �d���I�ԂQ
            PrintSetTable.Columns.Add(PARTSMANAGEMENTDIVIDE1, typeof(string));// �Ǘ��敪�P
            PrintSetTable.Columns.Add(PARTSMANAGEMENTDIVIDE2, typeof(string));// �Ǘ��敪�Q
            PrintSetTable.Columns.Add(STOCKNOTE1, typeof(string));// �݌ɔ��l�P
            PrintSetTable.Columns.Add(STOCKNOTE2, typeof(string));// �݌ɔ��l�Q

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }
        #endregion DataSet�֘A
        #endregion �� Private Method

        #region �� Control Event
        /// <summary>
        /// PMKHN07250U_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void PMKHN07150U_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;


            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�K�C�h���N���b�N�Ƃ��ɔ�������</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void MakerGuideCode_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();

            // �t�H�[�J�X�ړ�
            nextControl.Focus();
        }

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>  
        private void WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // �q�ɃK�C�h�N��
            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._loginSectionCode);

            TEdit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tEdit_WarehouseCode_St;
                nextControl = this.tEdit_WarehouseCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tEdit_WarehouseCode_Ed;
                nextControl = this.tNedit_GoodsMakerCd_St;
            }
            else
            {
                return;
            }

            if (status != 0)
            {
                return;
            }
            targetControl.DataText = warehouseData.WarehouseCode.TrimEnd();

            // �t�H�[�J�X�ړ�
            nextControl.Focus();
        }

        /// <summary>
        /// CSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : CSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // �^�C�g���o�[�̕�����
                saveFileDialog.Title = "�o�̓t�@�C���I��";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.OverwritePrompt = false;

                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
                {
                    saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }

                //�u�t�@�C���̎�ށv���w��
                saveFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion �� Control Event
    }
}