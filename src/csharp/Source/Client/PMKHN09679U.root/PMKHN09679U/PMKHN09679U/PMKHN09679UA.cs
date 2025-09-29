//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���i�}�X�^�X�V(�T�|�[�g)����
//                  :   PMKHN09679U.EXE
// Name Space       :   Broadleaf.Windows.Forms
// Programmer       :   杍^
// Date             :   2021/08/09
// Update Note      :   �V�K�쐬
//----------------------------------------------------------------------
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�}�X�^�X�V(�T�|�[�g)�����t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�X�V(�T�|�[�g)���s���t�h�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2021/08/09</br>
    /// </remarks>
    public partial class PMKHN09679U : Form
    {
        /// <summary>���i�A�N�Z�X�N���X</summary>
        private GoodsAcs _goodsAcs;
        /// <summary>���[�J�[�A�N�Z�X�N���X</summary>
        private MakerAcs _makerAcs;
        /// <summary>�a�k���i�R�[�h�����K�C�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>�����ތ����K�C�h</summary>
        private GoodsGroupUAcs _goodsGroupUAcs;
        /// <summary>���i�}�X�^�X�V�����A�N�Z�X�N���X</summary>
        private GoodsUAcs _goodsMngAcs;
        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null; 
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���[�J�[</summary>
        private MakerUMnt _maker;
        /// <summary>������</summary>
        private GoodsGroupU _goodsGroupU;
        /// <summary>BL�R�[�h</summary>
        private BLGoodsCdUMnt _blGoodsCdUMnt;

        #region Const
        private const string UpdateErrMsg = "���i�}�X�^�̍X�V�Ɏ��s���܂����B";
        private const string ProcessNm = "���i�}�X�^�X�V(�T�|�[�g)";
        private const string LogUpdateMsg = "{0} ���A���i�}�X�^�ɂ́A{1}�����X�V���܂����B";
        private const string LogUpdateErr = "{0} ���A���i�}�X�^�̍X�V�Ɏ��s���܂����B";
        private const string GetMakerErr = "���[�J�[�擾�擾���s";
        private const string CntZero = "0";
        private const int MakerDiv = 1000;
        private const int CntZeroInt = 0;
        #endregion

        #region �����ݒ菈��
        /// <summary>
        /// ���i�}�X�^�X�V(�T�|�[�g)����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���i�}�X�^�X�V�����̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2021/08/09</br>
        /// </remarks>
        public PMKHN09679U()
        {
            InitializeComponent();
            ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            if (_goodsMngAcs == null)
                _goodsMngAcs = new GoodsUAcs();
            //���[�J�[
            if (_maker == null)
                _maker = new MakerUMnt();
            //������
            if (_goodsGroupU == null)
                _goodsGroupU = new GoodsGroupU();
            //BL�R�[�h
            if (_blGoodsCdUMnt == null)
                _blGoodsCdUMnt = new BLGoodsCdUMnt();
        }
        #endregion

        #region �C�x���g
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h�C�x���g�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void PMKHN09679U_Load(object sender, EventArgs e)
        {
            this._goodsMngAcs.Write("�N��", "�N��", "");
            _goodsAcs = new GoodsAcs();
            _blGoodsCdAcs = new BLGoodsCdAcs();
            _goodsGroupUAcs = new GoodsGroupUAcs();
            _makerAcs = new MakerAcs();

            this.Name_tComboEditor.Items.Clear();
            this.Name_tComboEditor.Items.Add(0, "���Ȃ�");
            this.Name_tComboEditor.Items.Add(1, "����");

            this.Rate_tComboEditor.Items.Clear();
            this.Rate_tComboEditor.Items.Add(0, "���Ȃ�");
            this.Rate_tComboEditor.Items.Add(1, "����i�񋟖��ݒ蕪�͍X�V���j");
            this.Rate_tComboEditor.Items.Add(2, "����i�������X�V�j");

            this.BLCode_tComboEditor.Items.Clear();
            this.BLCode_tComboEditor.Items.Add(0, "���Ȃ�");
            this.BLCode_tComboEditor.Items.Add(1, "����");

            this.Price_tComboEditor.Items.Clear();
            this.Price_tComboEditor.Items.Add(0, "���Ȃ�");
            this.Price_tComboEditor.Items.Add(1, "����");

            this.Name_tComboEditor.SelectedIndex = 0;
            this.Rate_tComboEditor.SelectedIndex = 0;
            this.BLCode_tComboEditor.SelectedIndex = 0;
            this.Price_tComboEditor.SelectedIndex = 0;

            this._imageList16 = IconResourceManagement.ImageList16;

            this.MakerGuide_Button.ImageList = this._imageList16;
            this.MGroupGuide_Button.ImageList = this._imageList16;
            this.BLGoodsCodeGuide_Button.ImageList = this._imageList16;

            this.MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.MGroupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.BLGoodsCodeGuide_Button.Appearance.Image = Size16_Index.STAR1;
            
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case "Btn_Close":
                    {
                        this._goodsMngAcs.Write("�I��", "�I��", "");

                        // �I������
                        Close();
                        break;
                    }
                //�X�V
                case "Btn_Update":
                    {

                        //_goodsAcs
                        #region �����o�����`�F�b�N
                        if ((int)this.Name_tComboEditor.Value == 0 &&
                            (int)this.Rate_tComboEditor.Value == 0 &&
                            (int)this.BLCode_tComboEditor.Value == 0 &&
                            ((int)this.Price_tComboEditor.Value == 0))
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                "�����ꂩ�̍X�V�敪��ݒ肵�ĉ������B", -1, MessageBoxButtons.OK);
                            this.Name_tComboEditor.Focus();
                            return;
                        }
                        #endregion

                        
                        //���ʏ�������ʐ���
                        SFCMN00299CA processingDialog = new SFCMN00299CA();
                        processingDialog.DispCancelButton = false;
                        processingDialog.Title = "�X�V����";
                        processingDialog.Message = "���݁A�f�[�^���o�A�X�V���ł��c";
                        processingDialog.Show((Form)this.Parent);

                        #region ���[�J�[�擾
                        ArrayList makerList = new ArrayList();
                        if (this.tNedit_GoodsMakerCd.Text.Trim() == string.Empty)
                        {
                            // ���[�J�[�������͏ꍇ�A���[�J�[�擾
                            int status = _makerAcs.SearchAll(out makerList, this._enterpriseCode);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this._goodsMngAcs.Write(ProcessNm, GetMakerErr, string.Empty);
                                processingDialog.Close();
                                this.UpdateCountLabel.Text = CntZero;
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                UpdateErrMsg, -1, MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else
                        {
                            MakerUMnt sgMakerUWork = new MakerUMnt();
                            sgMakerUWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                            makerList.Add(sgMakerUWork);
                        }
                        #endregion

                        int totalCnt = CntZeroInt;
                        foreach (MakerUMnt sgMakerUWork in makerList)
                        {
                            // �������[�J�[���X�V�ΏۊO
                            if (sgMakerUWork.GoodsMakerCd < MakerDiv)
                            {
                                continue;
                            }

                            #region �����o�����ݒ�
                            //-----------------------------------------------------------------------------
                            // ���o�����ݒ�
                            //-----------------------------------------------------------------------------
                            GoodsUpdate goodsUpdate = new GoodsUpdate();
                            goodsUpdate.EnterpriseCode = this._enterpriseCode;
                            goodsUpdate.GoodsNameUpdateDivCd = (int)this.Name_tComboEditor.Value;
                            goodsUpdate.RateRankUpdateDivCd = (int)this.Rate_tComboEditor.Value;
                            goodsUpdate.BLCodeUpdateDivCd = (int)this.BLCode_tComboEditor.Value;
                            goodsUpdate.PriceUpdateDivCd = (int)this.Price_tComboEditor.Value;
                            goodsUpdate.GoodsMakerCd = sgMakerUWork.GoodsMakerCd;
                            goodsUpdate.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                            goodsUpdate.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                            #endregion

                            int updCnt = 0;
                            int status = this._goodsMngAcs.Update(out updCnt, goodsUpdate);
                            string logDataMessage = string.Empty;
                            if (goodsUpdate.GoodsMakerCd > 0)
                                logDataMessage += "���[�J�F" + goodsUpdate.GoodsMakerCd;
                            if (goodsUpdate.GoodsMGroup > 0)
                                logDataMessage += " �����ށF" + goodsUpdate.GoodsMGroup;
                            if (goodsUpdate.BLGoodsCode > 0)
                                logDataMessage += " BL�R�[�h�F" + goodsUpdate.BLGoodsCode;
                            this._goodsMngAcs.Write("���i�}�X�^�X�V", logDataMessage + " ���A���i�}�X�^�ɂ́A" + updCnt.ToString() + "�����X�V���܂����B", "");

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                totalCnt = totalCnt + updCnt;
                            }
                            else
                            {
                                this._goodsMngAcs.Write(ProcessNm, string.Format(LogUpdateErr, logDataMessage), string.Empty);
                                processingDialog.Close();
                                this.UpdateCountLabel.Text = "0";
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                UpdateErrMsg, -1, MessageBoxButtons.OK);
                                return;
                            }
                        }
                        //����������\��
                        this.UpdateCountLabel.Text = totalCnt.ToString();
                        //���ʏ�������ʕ���
                        processingDialog.Close();
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                       "���i�}�X�^�X�V�������I�����܂����B", 0, MessageBoxButtons.OK);

                        break;
                    }
            }
        }
        #endregion

         /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^�����N���b�N�����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {

                MakerUMnt maker;

                // �K�C�h�N��
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);
                if (status != 0) return;
                if (maker.GoodsMakerCd < 1000)
                {
                    // �x�����o��
                    TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_INFO,
                              this.Name,
                              "�������[�J�[�͑I���ł��܂���B",
                              -1,
                              MessageBoxButtons.OK);
                    if (this._maker.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd.Text = "";
                    }
                    this.MakerCode_uLabel.Text = this._maker.MakerName;
                    this.tNedit_GoodsMakerCd.Focus();
                    return;
                }
                this.tNedit_GoodsMakerCd.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_uLabel.Text = maker.MakerName;
                this._maker = maker;
                this.tNedit_GoodsMGroup.Focus();
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�K�C�h�{�^�����N���b�N�����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            if (status != 0) return;
            this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
            if (blGoodsCdUMnt.BLGoodsCode > 0)
            {
                this.Price_tComboEditor.Focus();
            }
            else 
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            this._blGoodsCdUMnt = blGoodsCdUMnt;
        }

        /// <summary>
        /// �����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����ރK�C�h�{�^�����N���b�N�����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;
            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
            if (status != 0) return;
            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
            if (goodsGroupU.GoodsMGroup > 0)
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            else
            {
                this.tNedit_GoodsMGroup.Focus();
            }
            this._goodsGroupU = goodsGroupU;
        }

        /// <summary>
        /// tArrowKeyControl1�`�F���W�t�H�[�J�X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�J�X���J�ڂ����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMakerCd":
                    {
                        if (this.tNedit_GoodsMakerCd.Text.Trim() == "")
                        {
                            this.MakerCode_uLabel.Text = "";
                            this._maker = new MakerUMnt();
                            return;
                        }
                        if (this.tNedit_GoodsMakerCd.GetInt() < 1000)
                        {
                            // �x�����o��
                            TMsgDisp.Show(
                                      this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�������[�J�[�͑I���ł��܂���B",
                                      -1,
                                      MessageBoxButtons.OK);
                            if (this._maker.GoodsMakerCd != 0)
                            {
                                this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.Text = "";
                            }
                            this.MakerCode_uLabel.Text = this._maker.MakerName;
                            e.NextCtrl = e.PrevCtrl;
                            this.tNedit_GoodsMakerCd.Focus();
                            return;
                        }
                        try
                        {
                            MakerUMnt maker;

                            // �R�[�h���̂̎擾
                            int status = this._makerAcs.Read(out maker, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MakerCode_uLabel.Text = maker.MakerName;
                                this._maker = maker;
                            }
                            else
                            {
                                // �x�����o��
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "���͂��ꂽ���[�J�[�R�[�h�͑��݂��܂���B",
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this._maker.GoodsMakerCd != 0)
                                {
                                    this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Text = "";
                                }
                                this.MakerCode_uLabel.Text = this._maker.MakerName;
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_GoodsMakerCd.Focus();
                                return;
                            }
                        }
                        catch
                        {

                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMakerCd.Text.Trim() == "")
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = MakerGuide_Button;
                                        }
                                        else
                                        {
                                            // �����ރR�[�h
                                            e.NextCtrl = this.tNedit_GoodsMGroup;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // ���i�X�V�敪
                                        e.NextCtrl = this.Price_tComboEditor;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_GoodsMGroup":
                    {
                        if (this.tNedit_GoodsMGroup.Text.Trim() == "")
                        {
                            this.MGroup_uLabel.Text = "";
                            this._goodsGroupU = new GoodsGroupU();
                            return;
                        }
                        try
                        {
                            GoodsGroupU goodsGroupU;
                            int status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
                                this._goodsGroupU = goodsGroupU;
                            }
                            else
                            {
                                // �x�����o��
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "���͂��ꂽ�����ރR�[�h�͑��݂��܂���B",
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this._goodsGroupU.GoodsMGroup != 0)
                                {
                                    this.tNedit_GoodsMGroup.Text = this._goodsGroupU.GoodsMGroup.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMGroup.Text = "";
                                }
                                this.MGroup_uLabel.Text = this._goodsGroupU.GoodsMGroupName;
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_GoodsMGroup.Focus();
                                return;
                            }
                        }
                        catch
                        {
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMGroup.Text.Trim() == "")
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = MGroupGuide_Button;
                                        }
                                        else
                                        {
                                            // BL�R�[�h
                                            e.NextCtrl = this.tNedit_BLGoodsCode;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_BLGoodsCode":
                    {
                        if (this.tNedit_BLGoodsCode.Text.Trim() == "")
                        {
                            this.BLGoodsCode_uLabel.Text = "";
                            this._blGoodsCdUMnt = new BLGoodsCdUMnt();
                            return;
                        }
                        try
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt;
                            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
                                this._blGoodsCdUMnt = blGoodsCdUMnt;
                            }
                            else
                            {
                                // �x�����o��
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "���͂��ꂽBL�R�[�h�͑��݂��܂���B",
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this._blGoodsCdUMnt.BLGoodsCode != 0)
                                {
                                    this.tNedit_BLGoodsCode.Text = this._blGoodsCdUMnt.BLGoodsCode.ToString();
                                }
                                else
                                {
                                    this.tNedit_BLGoodsCode.Text = "";
                                }
                                this.BLGoodsCode_uLabel.Text = this._blGoodsCdUMnt.BLGoodsHalfName;
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGoodsCode.Focus();
                                return;
                            }
                        }
                        catch
                        {
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_BLGoodsCode.Text.Trim() == "")
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = BLGoodsCodeGuide_Button;
                                        }
                                        else
                                        {
                                            // ���i�X�V�敪
                                            e.NextCtrl = this.Price_tComboEditor;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// PMKHN09679U_KeyDown�t�H�[�J�X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/09/16</br>
        /// </remarks>
        private void PMKHN09679U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (this.tNedit_GoodsMakerCd.Focused)
                { 
                    MakerGuide_Button_Click(sender, e);
                    return;
                }
                if (this.tNedit_GoodsMGroup.Focused)
                {
                    MGroupGuide_Button_Click(sender, e);
                    return;
                }
                if (this.tNedit_BLGoodsCode.Focused)
                {
                    BLGoodsCodeGuide_Button_Click(sender, e);
                    return;
                }
            }
        }

    }

}