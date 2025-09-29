using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����c�N���A�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c�N���A�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.10.23</br>
    /// <br>Update Note: 2008.11.19 30452 ��� �r��</br>
    /// <br>            �E��ʃp�l����Dock.Fill�ɏC��</br>
    /// <br>            �E�ő剻�{�^���𖳌��ɏC��</br>
    /// <br>            �EuiSetControl��changeFocus�C�x���g��ݒ�</br>
    /// <br>            �ETab�AEnter�L�[�ł̃K�C�h�J�ڂ�s�ɏC��</br>
    /// <br>Update Note: 2009.01.23 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�9137(�ő剻��L�����BUltraExplorerBar�ǉ��B)</br>
    /// <br>Update Note: 2009.02.02 30452 ��� �r��</br>
    /// <br>            �E�r�����䏈���ǉ��B</br>
    /// <br>Update Note: 2009.02.18 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11640(�r���G���[���̃G���[���x����ERR_LEVEL_STOPDISP�ɕύX)</br>
    /// <br>Update Note: 2009.02.18 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11675</br>
    /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
    /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
    /// </remarks>
    public partial class PMZAI02031UA : Form
    {
        #region �� �R���X�g���N�^
        public PMZAI02031UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �e��K�C�h�A�N�Z�X�̃C���X�^���X��
            this._warehouseAcs = new WarehouseAcs();
            this._supplierAcs = new SupplierAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
        }
        #endregion

        #region �� private�ϐ�

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private ExtrInfo_SalesOrderRemainClear _extrInfo_SalesOrderRemainClear;

        // �����c�N���A�A�N�Z�X�N���X
        private SalesOrderRemainClearAcs _salesOrderRemainClearAcs;

        // �q�ɃK�C�h
        private WarehouseAcs _warehouseAcs;
        // �d����K�C�h
        private SupplierAcs _supplierAcs;
        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;
        #endregion

        #region �� private���\�b�h
        /// <summary>
        /// ��ʏ����ݒ�
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            // �c�[���o�[�A�C�R���ݒ�
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // �K�C�h�A�C�R���ݒ�
            this.SetIconImage(this.uButton_WarehouseCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_WarehouseCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_SupplierCdStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_SupplierCdEdGuid, Size16_Index.STAR1);
            // -------DEL 2010/06/08------->>>>>
            //this.SetIconImage(this.uButton_GoodsMakerCdStGuide, Size16_Index.STAR1);
            //this.SetIconImage(this.uButton_GoodsMakerCdEdGuide, Size16_Index.STAR1);
            //this.SetIconImage(this.uButton_BLGoodsCodeStGuid, Size16_Index.STAR1);
            //this.SetIconImage(this.uButton_BLGoodsCodeEdGuid, Size16_Index.STAR1);
            // -------DEL 2010/06/08-------<<<<<

            // �����t�H�[�J�X�Z�b�g
            this.uButton_WarehouseCodeStGuid.Focus();

            return status;
        }

        /// <summary>
        /// �N���A���s�O ���̓`�F�b�N
        /// </summary>
        /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        private bool DecisionBeforeCheck()
        {
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            string errMessage = "";
            Control errComponent = null;

            bool status = true;

            // �q��
            if (this.tEdit_WarehouseCode_Ed.DataText != string.Empty
                && (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0))
            {
                errMessage = string.Format("�q��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // �d����
            else if (this.tNedit_SupplierCd_Ed.GetInt() != 0
                && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("�d����{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // -------DEL 2010/06/08------->>>>>
            //// ���[�J�[
            //else if (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0
            //    && (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            //{
            //    errMessage = string.Format("���[�J�[{0}", ct_RangeError);
            //    errComponent = this.tNedit_GoodsMakerCd_St;
            //    status = false;
            //}
            //else if (this.tNedit_BLGoodsCode_Ed.GetInt() != 0
            //    && (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            //{
            //    errMessage = string.Format("BL�R�[�h{0}", ct_RangeError);
            //    errComponent = this.tNedit_BLGoodsCode_St;
            //    status = false;
            //}
            // -------DEL 2010/06/08-------<<<<<

            if (!status)
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

            }

            return status;
        }

        /// <summary>
        /// �N���A�����ݒ菈��
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                this._extrInfo_SalesOrderRemainClear = new ExtrInfo_SalesOrderRemainClear();

                // ��ƃR�[�h
                this._extrInfo_SalesOrderRemainClear.EnterpriseCode = this._enterpriseCode;

                // �q�ɃR�[�h
                if (this.tEdit_WarehouseCode_St.DataText == "") this._extrInfo_SalesOrderRemainClear.St_WarehouseCode = "0000";
                else this._extrInfo_SalesOrderRemainClear.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.PadLeft(4, '0');

                if (this.tEdit_WarehouseCode_Ed.DataText == "") this._extrInfo_SalesOrderRemainClear.Ed_WarehouseCode = "9999";
                else this._extrInfo_SalesOrderRemainClear.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.PadLeft(4, '0');

                // �d����
                this._extrInfo_SalesOrderRemainClear.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                this._extrInfo_SalesOrderRemainClear.Ed_SupplierCd = this.GetEndCode(this.tNedit_SupplierCd_Ed);

                // -------DEL 2010/06/08------->>>>>
                //// ���[�J�[
                //this._extrInfo_SalesOrderRemainClear.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                //this._extrInfo_SalesOrderRemainClear.Ed_GoodsMakerCd = this.GetEndCode(this.tNedit_GoodsMakerCd_Ed);

                //// BL�R�[�h
                //this._extrInfo_SalesOrderRemainClear.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                //this._extrInfo_SalesOrderRemainClear.Ed_BLGoodsCode = this.GetEndCode(this.tNedit_BLGoodsCode_Ed);

                // -------DEL 2010/06/08-------<<<<<
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �N���A�������s
        /// </summary>
        private void ExecuteClear()
        {
            int status = 0;
            this._salesOrderRemainClearAcs = new SalesOrderRemainClearAcs();

            string msg; // ADD 2009/02/02
            status = this._salesOrderRemainClearAcs.Clear(this._extrInfo_SalesOrderRemainClear, out msg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ����I��
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO, 
                                      this.Name,
                                      "�X�V���܂���",
                                      status,
                                      MessageBoxButtons.OK);
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // ���݂��Ȃ�
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "�Ώۃf�[�^�����݂��܂���",
                                      status,
                                      MessageBoxButtons.OK);
                    }
                    break;
                // --- ADD 2009/02/02 -------------------------------->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        // --- DEL 2009/02/18 -------------------------------->>>>>
                        //TMsgDisp.Show(this,
                        //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //    this.Name,
                        //    msg,
                        //    status,
                        //    MessageBoxButtons.OK);
                        // --- DEL 2009/02/18 --------------------------------<<<<<
                        // --- ADD 2009/02/18 -------------------------------->>>>>
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "�ۑ��Ɏ��s���܂����B" + "\r\n" + "\r\n" + msg,
                        status,
                        MessageBoxButtons.OK);
                        // --- ADD 2009/02/18 --------------------------------<<<<<
                    }
                    break;
                // --- ADD 2009/02/02 --------------------------------<<<<<
                default:
                    {
                        // ���̑��G���[
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "�X�V�Ɏ��s���܂���" ,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMZAI02031UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�����c�N���A", 					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �R���g���[���C�x���g
        /// <summary>
        /// PMZAI02031UA_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02031UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);

            // ��ʃC���[�W����
			this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX
        }

        /// <summary>
        /// tToolbarsManager1_ToolClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        private void tToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I���{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                // �m��{�^��
                case "ButtonTool_Update":
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�N���A���Ă���낵���ł����H ",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult != DialogResult.Yes)
                        {
                            return;
                        }

                        // ���͏����`�F�b�N
                        if (!this.DecisionBeforeCheck())
                        {
                            return;
                        }

                        // ���͏������o
                        if (this.SetExtraInfoFromScreen() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            return;
                        }

                        // �����[�g�����ďo
                        this.ExecuteClear();

                        break;
                    }
                // �N���A�{�^��
                case "ButtonTool_Clear":
                    {
                        // ���������̃N���A
                        this.tEdit_WarehouseCode_St.DataText = "";
                        this.tEdit_WarehouseCode_Ed.DataText = "";
                        this.tNedit_SupplierCd_St.SetInt(0);
                        this.tNedit_SupplierCd_Ed.SetInt(0);
                        // -------DEL 2010/06/08------->>>>>
                        //this.tNedit_GoodsMakerCd_St.SetInt(0);
                        //this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                        //this.tNedit_BLGoodsCode_St.SetInt(0);
                        //this.tNedit_BLGoodsCode_Ed.SetInt(0);
                        // -------DEL 2010/06/08-------<<<<<

                        // �t�H�[�J�X�ݒ�
                        this.tEdit_WarehouseCode_St.Focus();

                        break;
                    }
            }
        }

        // --- ADD 2008/11/19 -------------------------------->>>>>
        /// <summary>
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // �^�u�L�[�A�G���^�[�L�[�ł̃K�C�h�J�ڂ͕s�Ƃ���
            if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                // -------UPD 2010/06/08------->>>>>
                //if (e.NextCtrl == this.uButton_BLGoodsCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                //{
                //    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                //}
                //else if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter)) //DEL 2010/06/08
                //{
                //    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                //}

                if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
                else if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter)) //DEL 2010/06/08
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }

                // -------UPD 2010/06/08-------<<<<<
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_St;
                }
                else if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }
                else if (e.NextCtrl == this.uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                if (e.NextCtrl == this.uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
                else if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    // -------UPD 2010/06/08------->>>>>
                    //e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    e.NextCtrl = this.tEdit_WarehouseCode_St;
                    // -------UPD 2010/06/08-------<<<<<
                }
            }
            // -------DEL 2010/06/08------->>>>>
            //else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //{
            //    if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_SupplierCd_Ed;
            //    }
            //    else if (e.NextCtrl == this.uButton_GoodsMakerCdStGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //{
            //    if (e.NextCtrl == this.uButton_GoodsMakerCdStGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
            //    }
            //    else if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_BLGoodsCode_St;
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            //{
            //    if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //    }
            //    else if (e.NextCtrl == this.uButton_BLGoodsCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            //{
            //    if (e.NextCtrl == this.uButton_BLGoodsCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_BLGoodsCode_St;
            //    }
            //    else if (e.NextCtrl == this.uButton_BLGoodsCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tEdit_WarehouseCode_St;
            //    }
            //}
            // -------DEL 2010/06/08-------<<<<<
        }
        // --- ADD 2008/11/19 --------------------------------<<<<<

        /// <summary>
        /// �q��(�J�n)�{�^�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCodeStGuid_Click(object sender, EventArgs e)
        {
            // �q�ɃK�C�h�N��
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseCode_Ed.Focus();
            }
        }

        /// <summary>
        /// �q��(�I��)�{�^�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCodeEdGuid_Click(object sender, EventArgs e)
        {
            // �q�ɃK�C�h�N��
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tNedit_SupplierCd_St.Focus();
            }
        }

        /// <summary>
        /// �d����(�J�n)�{�^�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdStGuid_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�N��
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tNedit_SupplierCd_Ed.Focus();
            }
        }

        /// <summary>
        /// �d����(�I��)�{�^�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        /// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        private void uButton_SupplierCdEdGuid_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�N��
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                //this.tNedit_GoodsMakerCd_St.Focus(); DEL 2010/06/08
                this.tEdit_WarehouseCode_St.Focus(); // ADD 2010/06/08
            }
        }

        // -------DEL 2010/06/08------->>>>>

        ///// <summary>
        ///// ���[�J�[�K�C�h�i�J�n�j
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_GoodsMakerCdStGuide_Click(object sender, EventArgs e)
        //{
        //    MakerUMnt makerUMnt;

        //    int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
        //        this.tNedit_GoodsMakerCd_Ed.Focus();
        //    }
        //}

        ///// <summary>
        ///// ���[�J�[�K�C�h�i�I���j
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_GoodsMakerCdEdGuide_Click(object sender, EventArgs e)
        //{
        //    MakerUMnt makerUMnt;

        //    int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
        //        this.tNedit_BLGoodsCode_St.Focus();
        //    }
        //}

        ///// <summary>
        ///// �a�k�K�C�h�i�J�n�j
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <br>Update Note: 2010/06/08 ���M ��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
        ///// <br>            �E�d�����ׂ�ǂݍ��݁A�d�����ׂ̔����c���̐��ʂ�Ώۍ݌Ƀ}�X�^�̔����c����}�C�i�X����悤�ɂ���B</br>
        //private void uButton_BLGoodsCodeStGuid_Click(object sender, EventArgs e)
        //{
        //    BLGoodsCdAcs BLGoodsCdAcs = new BLGoodsCdAcs();
        //    BLGoodsCdUMnt bLGoodsCdUMnt;
        //    int status = BLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
        //        this.tNedit_BLGoodsCode_Ed.Focus();
        //    }
        //}

        ///// <summary>
        ///// �a�k�K�C�h�i�I���j
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_BLGoodsCodeEdGuid_Click(object sender, EventArgs e)
        //{
        //    BLGoodsCdAcs BLGoodsCdAcs = new BLGoodsCdAcs();
        //    BLGoodsCdUMnt bLGoodsCdUMnt;
        //    int status = BLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
        //        this.tEdit_WarehouseCode_St.Focus();
        //    }
        //}

        // -------DEL 2010/06/08-------<<<<<

        // --- ADD 2009/01/23 -------------------------------->>>>>
        /// <summary>
        /// ultraExplorerBar1_GroupCollapsing�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == "ClearInfoGroup")
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ultraExplorerBar1_GroupExpanding�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == "ClearInfoGroup")
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }
        // --- ADD 2009/01/23 --------------------------------<<<<<
        #endregion
    }
}