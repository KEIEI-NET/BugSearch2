using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    // <summary>
    /// �݌Ƀ}�X�^�ꗗ���UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�ꗗ���UI�t�H�[���N���X</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009.01.13</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMZAI02020UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {

        #region �� Constructor
        /// <summary>
        /// �݌Ƀ}�X�^�ꗗ���UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�ꗗ���UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// <br></br>
        /// </remarks>
        public PMZAI02020UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �݌Ƀ}�X�^�ꗗ����A�N�Z�X�N���X
            this._stockMasterTblAcs = new StockMasterTblAcs();

            // �q�Ƀ}�X�^�A�N�Z�X�N���X
            this._wareHouseAcs = new WarehouseAcs();
            // �d����}�X�^�A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();
            // ���[�J�[�}�X�^�A�N�Z�X�N���X
            this._makerAcs = new MakerAcs();
            // ���[�U�[�K�C�h�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();
            // ���i�����ރA�N�Z�X�N���X
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            // BL�O���[�v�A�N�Z�X�N���X
            this._blGroupUAcs = new BLGroupUAcs();
            // BL�R�[�h�A�N�Z�X�N���X
            this._blGoodsCdAcs = new BLGoodsCdAcs();
        }
        #endregion

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        #endregion �� Interface member

        // ���_�R�[�h
        private string _enterpriseCode = "";
        // �݌Ƀ}�X�^�ꗗ����A�N�Z�X�N���X
        private StockMasterTblAcs _stockMasterTblAcs;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �K�C�h�A�N�Z�X�N���X
        // �q�Ƀ}�X�^�A�N�Z�X�N���X
        private WarehouseAcs _wareHouseAcs;
        // �d����}�X�^�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;
        // ���[�J�[�}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs;
        // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;
        // ���i�����ރA�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs;
        // BL�O���[�v�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs;
        // BL�R�[�h�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs;
        
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMZAI02020UA";
        // �v���O����ID
        private const string ct_PGID = "PMZAI02020U";
        // ���[����
        private const string ct_PrintName = "�݌Ƀ}�X�^�ꗗ���";
        // ���[�L�[	
        private const string ct_PrintKey = "86aa7f12-55e0-4988-8585-1645e2ffbb5a";
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // ���o�����N���X
            ExtrInfo_StockMasterTbl extrInfo = new ExtrInfo_StockMasterTbl();

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }

            // ���[�I���K�C�h
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // ������f�[�^���X�g���擾
            ArrayList retMList = null;
            status = this._stockMasterTblAcs.SearchMasterData(out retMList, this._enterpriseCode, printInfo.prpid, printInfo.prinm);
            if (status != 0)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���[���C�A�E�g�̎擾�Ɏ��s���܂����B", 0);
                return -1;
            }
            extrInfo.PrintInfoList = (ArrayList)retMList.Clone();

            // ���o�����̐ݒ�
            printInfo.jyoken = extrInfo;
            
            // ���o�Ăяo��
            PMZAI02021EA freePrint = new PMZAI02021EA(printInfo);
            status = freePrint.ExtrPrintData();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
                return -1;
            }

            // ����Ăяo��
            object prtObj = LoadAssemblyFrom("PMZAI02022P", "Broadleaf.Drawing.Printing.PMZAI02022PA");
            if (prtObj is IPrintProc)
            {
                (prtObj as IPrintProc).Printinfo = freePrint.Printinfo;
                (prtObj as IPrintProc).StartPrint();
            }

            return printInfo.status;
        }
        #endregion

        #region �� �N���X�C���X�^���X��
        /// <summary>
        /// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note �@�@  : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.15</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

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
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
            this.Show();
            return;
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �q��
                this.tEdit_WarehouseCode_St.Clear();
                this.tEdit_WarehouseCode_Ed.Clear();
                // �I��
                this.tEdit_WarehouseShelfNo_St.Clear();
                this.tEdit_WarehouseShelfNo_Ed.Clear();
                // �d����
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();
                // ���[�J�[
                this.tNedit_GoodsMakerCd_St.Clear();
                this.tNedit_GoodsMakerCd_Ed.Clear();
                // ���i�啪��
                this.tNedit_GoodsLGroup_St.Clear();
                this.tNedit_GoodsLGroup_Ed.Clear();
                // ���i������
                this.tNedit_GoodsMGroup_St.Clear();
                this.tNedit_GoodsMGroup_Ed.Clear();
                // �O���[�v�R�[�h
                this.tNedit_BLGloupCode_St.Clear();
                this.tNedit_BLGloupCode_Ed.Clear();
                // BL�R�[�h
                this.tNedit_BLGoodsCode_St.Clear();
                this.tNedit_BLGoodsCode_Ed.Clear();
                // �i��
                this.tEdit_GoodsNo_St.Clear();
                this.tEdit_GoodsNo_Ed.Clear();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            
            errMessage = "";
            errComponent = null;

            // �q�Ƀ`�F�b�N
            if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            {
                errMessage = string.Format("�q��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // �I�ԃ`�F�b�N
            else if ((this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�I��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseShelfNo_St;
                status = false;
            }
            // �d����`�F�b�N
            else if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("�d����{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // ���[�J�[�`�F�b�N
            else if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // ���i�啪�ރ`�F�b�N
            else if ((this.tNedit_GoodsLGroup_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsLGroup_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()))
            {
                errMessage = string.Format("���i�啪��{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // ���i�����ރ`�F�b�N
            else if ((this.tNedit_GoodsMGroup_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("���i������{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // �O���[�v�R�[�h�`�F�b�N
            else if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            {
                errMessage = string.Format("�O���[�v�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // BL�R�[�h�`�F�b�N
            else if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("BL�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // �i�ԃ`�F�b�N
            else if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�i��{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            
            return status;
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">���o�����N���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                extrInfo_StockMasterTbl.EnterpriseCode = this._enterpriseCode;
                // �q��
                // �J�n
                if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                {
                    extrInfo_StockMasterTbl.St_WarehouseCode = "";
                }
                else
                {
                    extrInfo_StockMasterTbl.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                }
                // �I��
                if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                {
                    extrInfo_StockMasterTbl.Ed_WarehouseCode = "";
                }
                else
                {
                    extrInfo_StockMasterTbl.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                }
                // �I��
                extrInfo_StockMasterTbl.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text.Trim();
                extrInfo_StockMasterTbl.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text.Trim();
                // �d����
                extrInfo_StockMasterTbl.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                extrInfo_StockMasterTbl.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
                // ���[�J�[�R�[�h
                extrInfo_StockMasterTbl.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                extrInfo_StockMasterTbl.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // ���i�啪��
                extrInfo_StockMasterTbl.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                extrInfo_StockMasterTbl.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();
                // ���i������
                extrInfo_StockMasterTbl.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                extrInfo_StockMasterTbl.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // �O���[�v�R�[�h
                extrInfo_StockMasterTbl.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                extrInfo_StockMasterTbl.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // BL�R�[�h
                extrInfo_StockMasterTbl.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                extrInfo_StockMasterTbl.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                // �i��
                extrInfo_StockMasterTbl.St_GoodsNo = this.tEdit_GoodsNo_St.Text.Trim();
                extrInfo_StockMasterTbl.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text.Trim();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� �G���[���b�Z�[�W�\��
        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMZAI02020UA
        #region �� PMZAI02020UA_Load Event
        /// <summary>
        /// PMZAI02020UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        /// 
        private void PMZAI02020UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion
        #endregion �� PMZAI02020UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region �� GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }
        #endregion
        #endregion �� ueb_MainExplorerBar Event


        #region �� �J�n�q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n�q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // �K�C�h�N��
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = wareHouse.WarehouseCode.TrimEnd();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I���q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I���q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // �K�C�h�N��
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = wareHouse.WarehouseCode.TrimEnd();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n�d����K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n�d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I���d����K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I���d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I�����[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I�����[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;
            
            // �K�C�h�N��
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n���i�啪�ރK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n���i�啪�ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            UserGdBd userGdBd;
            UserGdHd userGdHd;
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                this.tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I�����i�啪�ރK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I�����i�啪�ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            UserGdBd userGdBd;
            UserGdHd userGdHd;
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n���i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n���i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            GoodsGroupU goodgroupU;            
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I�����i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I�����i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            GoodsGroupU goodgroupU;
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n�O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n�O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I���O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I���O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�nBL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�nBL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I��BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I��BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // �q��(�J�n)���q��(�I��)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // �q��(�I��)���I��(�J�n)
                        e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // ���[�J�[(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // ���[�J�[(�I��)�����i�啪��(�J�n)
                        e.NextCtrl = this.tNedit_GoodsLGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
                    {
                        // ���i�啪��(�J�n)�����i�啪��(�I��)
                        e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
                    {
                        // ���i�啪��(�I��)�����i������(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        // ���i������(�J�n)�����i������(�I��)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        // ���i������(�I��)���O���[�v�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // �O���[�v�R�[�h(�J�n)���O���[�v�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // �O���[�v�R�[�h(�I��)��BL�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BL�R�[�h(�J�n)��BL�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BL�R�[�h(�I��)���i��(�J�n)
                        e.NextCtrl = this.tEdit_GoodsNo_St;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_GoodsNo_St)
                    {
                        // �i��(�J�n)��BL�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BL�R�[�h(�I��)��BL�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BL�R�[�h(�J�n)���O���[�v�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // �O���[�v�R�[�h(�I��)���O���[�v�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // �O���[�v�R�[�h(�J�n)�����i������(�I��)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        // ���i������(�I��)�����i������(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        // ���i������(�J�n)�����i�啪��(�I��)
                        e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
                    {
                        // ���i�啪��(�I��)�����i�啪��(�J�n)
                        e.NextCtrl = this.tNedit_GoodsLGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
                    {
                        // ���i�啪��(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // ���[�J�[(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // ���[�J�[(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
                    {
                        // �I��(�J�n)���q��(�I��)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // �q��(�I��)���q��(�J�n)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                }
            }
        }
        #endregion
        #endregion �� Control Event

        #region �� Initialize_Timer
        #region �� Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R���g���[��������
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // �K�C�h�{�^���̃A�C�R���ݒ�
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                ParentToolbarSettingEvent(this);	// �c�[���o�[�ݒ�C�x���g
            }
            finally
            {
                // �����t�H�[�J�X
                this.tEdit_WarehouseCode_St.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion �� Initialize_Timer

    }
}
