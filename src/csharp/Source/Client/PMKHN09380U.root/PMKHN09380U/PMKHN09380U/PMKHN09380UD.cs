//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���i�݌Ƀ}�X�^
// �v���O�����T�v   : ���i�݌ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : caohh
// �C �� ��  2011/08/02  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  2013/01/16�z�M�� �쐬�S�� : zhangy3
// �C �� ��  2012/12/01  �@�@ �C�����e : ��Q��#33231 ���i�݌Ƀ}�X�^
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/02</br>
    /// <br>Update Note: 2012/12/01 zhangy3�@</br>
    /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
    /// </remarks>
    public partial class PMKHN09380UD : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09380UD()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._goodsStockInputConstructionAcs = new GoodsStockInputConstructionAcs1();

            this.tComboEditor1.SelectedIndex = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this.ul_GoodsNoMaker.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[0] == 1;
            this.ul_GoodsInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[1] == 1;
            this.ul_PriceInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[2] == 1;
            this.ul_UnitPrice.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[3] == 1;
            this.ul_StockInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[4] == 1;
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            radioBtnLst.Value = this._goodsStockInputConstructionAcs.KeepOnInfo[5];
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<

            this._saveInfoDiv = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this._keepOnInfo = this._goodsStockInputConstructionAcs.KeepOnInfo;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private int _saveInfoDiv;  // �ۑ��O���敪
        private List<int> _keepOnInfo;�@// �ۑ��O���ێ�
        private GoodsStockInputConstructionAcs1 _goodsStockInputConstructionAcs = null;
        # endregion

        # region Properties
        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        /// <summary>�ۑ��O���敪�v���p�e�B</summary>
        public int SaveInfoDiv
        {
            get { return this._saveInfoDiv; }
            set { this._saveInfoDiv = value; }
        }
        /// <summary>�ۑ��O���ێ��v���p�e�B</summary>
        public List<int> KeepOnInfo
        {
            get { return this._keepOnInfo; }
            set { this._keepOnInfo = value; }
        }
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �A��265 ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
        /// </remarks>
        private void PMKHN09380UD_Load(object sender, EventArgs e)
        {
            this.OK_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.OK_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.BEFORE;

            this.tComboEditor1.SelectedIndex = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this.ul_GoodsNoMaker.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[0] == 1;
            this.ul_GoodsInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[1] == 1;
            this.ul_PriceInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[2] == 1;
            this.ul_UnitPrice.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[3] == 1;
            this.ul_StockInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[4] == 1;

            // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            this.radioBtnLst.Value = this._goodsStockInputConstructionAcs.KeepOnInfo[5];
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
            this._saveInfoDiv = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this._keepOnInfo = this._goodsStockInputConstructionAcs.KeepOnInfo;
        }

        /// <summary>
        /// tComboEditor1_ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �A��265 �R���{�{�b�N�X�̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/02</br>
        /// </remarks>
        private void tComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            //�u0:�N���A���Ȃ��v�ꍇ
            if (this.tComboEditor1.SelectedIndex == 0) 
            {
                this.ul_GoodsNoMaker.Enabled = false;
                this.ul_GoodsInfo.Enabled = false;
                this.ul_PriceInfo.Enabled = false;
                this.ul_UnitPrice.Enabled = false;
                this.ul_StockInfo.Enabled = false;
            }
            //�u1:�N���A����v�ꍇ
            else if (this.tComboEditor1.SelectedIndex == 1) 
            {
                this.ul_GoodsNoMaker.Enabled = true;
                this.ul_GoodsInfo.Enabled = true;
                this.ul_PriceInfo.Enabled = true;
                this.ul_UnitPrice.Enabled = true;
                this.ul_StockInfo.Enabled = true;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �A��265 �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
        /// </remarks>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this._keepOnInfo = new List<int>();
            //for (int index = 0; index < 5; index++) //Del 2012/12/01 zhangy3 for Redmine#33231
            for (int index = 0; index < 6; index++) //Add 2012/12/01 zhangy3 for Redmine#33231
            {
                this._keepOnInfo.Add(0);
            }

            //�u0:�N���A���Ȃ��v�ꍇ
            if (this.tComboEditor1.SelectedIndex == 0)
            {
                this._saveInfoDiv = 0;  
            }
            //�u0:�N���A����v�ꍇ
            else
            {
                this._saveInfoDiv = 1;
                // �i�ԁE���[�J�[
                if (this.ul_GoodsNoMaker.Checked)
                {
                    this._keepOnInfo[0] = 1;
                }
                // ���i���
                if (this.ul_GoodsInfo.Checked)
                {
                    this._keepOnInfo[1] = 1;
                }
                // ���i���
                if (this.ul_PriceInfo.Checked) 
                {
                    this._keepOnInfo[2] = 1;
                }
                // �P�i����
                if (this.ul_UnitPrice.Checked) 
                {
                    this._keepOnInfo[3] = 1;
                }
                // �݌ɏ��
                if (this.ul_StockInfo.Checked) 
                {
                    this._keepOnInfo[4] = 1;
                }
            }
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            this._keepOnInfo[5] = Convert.ToInt32(radioBtnLst.Value);
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
            this._goodsStockInputConstructionAcs.SaveInfoDiv = this._saveInfoDiv;
            this._goodsStockInputConstructionAcs.KeepOnInfo = this._keepOnInfo;
            this._goodsStockInputConstructionAcs.Serialize();
        }
        # endregion
    }
}