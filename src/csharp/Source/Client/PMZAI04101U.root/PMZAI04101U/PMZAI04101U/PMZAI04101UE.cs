using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�͏����^�o�͐�ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �o�͏����^�o�͐�ݒ�UI�t�H�[���N���X</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date        : 2010/07/20</br>
    /// <br>Update Note : 2010/10/09 ������</br>
    /// <br>            �E��QID:15882 PM1010F�e�L�X�g�o�͑Ή�</br>
    /// </remarks>
    public partial class PMZAI04101UE : Form
    {
        #region �v���C�x�[�g�ϐ�
        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;

        /// <summary>�o�͌`��</summary>
        private bool _excelFlg;

        /// <summary>��ƃR�[�h</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>�o�̓t�@�C����</summary>
        private string _settingFileName = string.Empty;

        /// <summary>�q�ɃR�[�h���X�g</summary>
        private List<string> _warehouseCodeList = new List<string>();
        private string _preWarehouseCodeFrom = string.Empty;
        private string _preWareHouseCodeTo = string.Empty;

        /// <summary>�I�ԃR�[�h���X�g</summary>
        private List<string> _warehouseShelfNoList = new List<string>();

        /// <summary>���[�J�[�R�[�h���X�g</summary>
        private List<Int32> _makerCodeList = new List<Int32>();
        private string _preMakerCodeFrom = string.Empty;
        private string _preMakerCodeTo = string.Empty;

        /// <summary>BL�R�[�h���X�g</summary>
        private List<Int32> _blGoodsCodeList = new List<Int32>();
        private string _preBlGoodsCodeFrom = string.Empty;
        private string _preBlGoodsCodeTo = string.Empty;

        /// <summary>�i�ԃ��X�g</summary>
        private List<string> _goodsNoList = new List<string>();

        /// <summary>MAKHN09332A �q��</summary>
        private WarehouseAcs _warehouseAcs;

        /// <summary>MAKHN09112A)���[�J�[</summary>
        private MakerAcs _makerAcs;

        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        // --- ADD 2010/10/09 ---------->>>>>
        # region Delegate
        /// <summary>
        /// �f�[�^���o��
        /// </summary>
        /// <returns>�o�͌���</returns>
        internal delegate bool OutputDataEvent();
        #endregion

        # region Event
        /// <summary>�f�[�^���o�̓C�x���g</summary>
        internal event OutputDataEvent OutputData;
        #endregion
        // --- ADD 2010/10/09 ----------<<<<<
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �o�͏����^�o�͐�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�͏����^�o�͐�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMZAI04101UE()
        {
            InitializeComponent();
        }
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// �o�̓t�@�C����
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

        /// <summary>
        /// �t�H�[���I���X�e�[�^�X
        /// </summary>
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { this._dialogResult = value; }
        }

        /// <summary>
        /// �o�͌`��
        /// </summary>
        public bool ExcelFlg
        {
            get { return _excelFlg; }
            set { this._excelFlg = value; }
        }

        /// <summary>
        /// �q�ɃR�[�h
        /// </summary>
        public List<string> WarehouseCodeList
        {
            get { return this._warehouseCodeList; }
            set { this._warehouseCodeList = value; }
        }

        /// <summary>
        /// �I��
        /// </summary>
        public List<string> WarehouseShelfNoList
        {
            get { return this._warehouseShelfNoList; }
            set { this._warehouseShelfNoList = value; }
        }

        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        public List<Int32> MakerCodeList
        {
            get { return this._makerCodeList; }
            set { this._makerCodeList = value; }
        }

        /// <summary>
        /// BL�R�[�h
        /// </summary>
        public List<Int32> BlGoodsCodeList
        {
            get { return this._blGoodsCodeList; }
            set { this._blGoodsCodeList = value; }
        }

        /// <summary>
        /// �i��
        /// </summary>
        public List<string> GoodsNoList
        {
            get { return this._goodsNoList; }
            set { this._goodsNoList = value; }
        }
        #endregion

        #region �C�x���g
        /// <summary>Form.Load �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : Form.Load ���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void PMZAI04101UE_Load(object sender, System.EventArgs e)
        {
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            _imageList16 = IconResourceManagement.ImageList16;

            this.uButton_WarehouseCd_From.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseCd_To.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_MakerCd_From.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_MakerCd_To.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BlGoodsCode_From.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BlGoodsCode_To.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_OutputFileName.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];

            ChangeFileName();
        }

        /// <summary>
        /// �q�ɃK�C�h�J�n�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �q�ɃK�C�h�J�n�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_WarehouseCd_From_Click(object sender, EventArgs e)
        {
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status == 0)
            {
                this.tEdit_WarehouseCd_From.Text = warehouse.WarehouseCode.Trim();
                this._preWarehouseCodeFrom = warehouse.WarehouseCode.Trim();
                this.tEdit_WarehouseCd_To.Focus();
            }
        }

        /// <summary>
        /// �q�ɃK�C�h�I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �q�ɃK�C�h�J�n�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_WarehouseCd_To_Click(object sender, EventArgs e)
        {
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status == 0)
            {
                this.tEdit_WarehouseCd_To.Text = warehouse.WarehouseCode.Trim();
                this._preWareHouseCodeTo = warehouse.WarehouseCode.Trim();
                this.tEdit_WarehouseShelfNo_From.Focus();
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_MakerCd_From_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
            if (status == 0)
            {
                this.tNedit_MakerCd_From.Text = makerUmnt.GoodsMakerCd.ToString();
                this._preMakerCodeFrom = makerUmnt.GoodsMakerCd.ToString();
                // �t�H�[�J�X�ݒ�
                this.tNedit_MakerCd_To.Focus();
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_MakerCd_To_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
            if (status == 0)
            {
                this.tNedit_MakerCd_To.Text = makerUmnt.GoodsMakerCd.ToString();
                this._preMakerCodeTo = makerUmnt.GoodsMakerCd.ToString();
                // �t�H�[�J�X�ݒ�
                this.tNedit_BlGoodsCode_From.Focus();
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_BlGoodsCode_From_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUmnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUmnt);
            if (status == 0)
            {
                this.tNedit_BlGoodsCode_From.Text = bLGoodsCdUmnt.BLGoodsCode.ToString();
                this._preBlGoodsCodeFrom = bLGoodsCdUmnt.BLGoodsCode.ToString();
                // �t�H�[�J�X�ݒ�
                this.tNedit_BlGoodsCode_To.Focus();
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_BlGoodsCode_To_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUmnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUmnt);
            if (status == 0)
            {
                this.tNedit_BlGoodsCode_To.Text = bLGoodsCdUmnt.BLGoodsCode.ToString();
                this._preBlGoodsCodeTo = bLGoodsCdUmnt.BLGoodsCode.ToString();
                // �t�H�[�J�X�ݒ�
                this.tEdit_GoodsNo_From.Focus();
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 gaofeng</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                // �q�ɃR�[�hFrom
                case "tEdit_WarehouseCd_From":
                    {
                        string inputValue = this.tEdit_WarehouseCd_From.Text.Trim().PadLeft(4, '0');

                        if (string.IsNullOrEmpty(this.tEdit_WarehouseCd_From.Text.Trim()))
                        {
                            break;
                        }

                        Warehouse warehouse;
                        int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouse.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (String.IsNullOrEmpty(this.tEdit_WarehouseCd_From.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_WarehouseCd_From;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseCd_To;
                                        }
                                        break;
                                }
                            }

                            this._preWarehouseCodeFrom = this.tEdit_WarehouseCd_From.Text.Trim().PadLeft(4, '0');
                            this.tEdit_WarehouseCd_From.Text = this.tEdit_WarehouseCd_From.Text.Trim().PadLeft(4, '0');
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɃR�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�N���A����
                            this.tEdit_WarehouseCd_From.Text = this._preWarehouseCodeFrom;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // �q�ɃR�[�hTo
                case "tEdit_WarehouseCd_To":
                    {
                        string inputValue = this.tEdit_WarehouseCd_To.Text.Trim().PadLeft(4, '0');

                        if (string.IsNullOrEmpty(this.tEdit_WarehouseCd_To.Text.Trim()))
                        {
                            break;
                        }

                        Warehouse warehouse;
                        int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouse.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (String.IsNullOrEmpty(this.tEdit_WarehouseCd_To.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_WarehouseCd_To;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseShelfNo_From;
                                        }
                                        break;
                                }
                            }

                            this._preWareHouseCodeTo = this.tEdit_WarehouseCd_To.Text.Trim().PadLeft(4, '0');
                            this.tEdit_WarehouseCd_To.Text = this.tEdit_WarehouseCd_To.Text.Trim().PadLeft(4, '0');
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɃR�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�N���A����B
                            this.tEdit_WarehouseCd_To.Text = this._preWareHouseCodeTo;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // ���[�J�[From
                case "tNedit_MakerCd_From":
                    {
                        Int32 inputValue = this.tNedit_MakerCd_From.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }

                        MakerUMnt makerUmnt;
                        int status = _makerAcs.Read(out makerUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_MakerCd_From.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_MakerCd_From;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_MakerCd_To;
                                        }
                                        break;
                                }
                            }

                            this._preMakerCodeFrom = this.tNedit_MakerCd_From.Text;
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���[�J�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�N���A����B
                            this.tNedit_MakerCd_From.Text = this._preMakerCodeFrom;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // ���[�J�[To
                case "tNedit_MakerCd_To":
                    {
                        Int32 inputValue = this.tNedit_MakerCd_To.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }
                        MakerUMnt makerUmnt;
                        int status = _makerAcs.Read(out makerUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_MakerCd_To.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_MakerCd_To;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_BlGoodsCode_From;
                                        }
                                        break;
                                }
                            }

                            this._preMakerCodeTo = this.tNedit_MakerCd_To.Text;
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���[�J�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�N���A����B
                            this.tNedit_MakerCd_To.Text = this._preMakerCodeTo;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // BL�R�[�hFrom
                case "tNedit_BlGoodsCode_From":
                    {
                        Int32 inputValue = this.tNedit_BlGoodsCode_From.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }

                        BLGoodsCdUMnt blGoodsCdUmnt;
                        int status = _blGoodsCdAcs.Read(out blGoodsCdUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_BlGoodsCode_From.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_BlGoodsCode_From;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_BlGoodsCode_To;
                                        }
                                        break;
                                }
                            }

                            this._preBlGoodsCodeFrom = this.tNedit_BlGoodsCode_From.Text;
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BL�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�N���A����B
                            this.tNedit_BlGoodsCode_From.Text = this._preBlGoodsCodeFrom;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // BL�R�[�hTo
                case "tNedit_BlGoodsCode_To":
                    {
                        Int32 inputValue = this.tNedit_BlGoodsCode_To.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }

                        BLGoodsCdUMnt blGoodsCdUmnt;
                        int status = _blGoodsCdAcs.Read(out blGoodsCdUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_BlGoodsCode_To.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_BlGoodsCode_To;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_GoodsNo_From;
                                        }
                                        break;
                                }
                            }

                            this._preBlGoodsCodeTo = this.tNedit_BlGoodsCode_To.Text;
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BL�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�N���A����B
                            this.tNedit_BlGoodsCode_To.Text = this._preBlGoodsCodeTo;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                case "tEdit_OutputFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_OutputFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = uButton_OK;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_OutputFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �L�����Z���{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OK�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : OK�{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             �E��Q�� #14643 �e�L�X�g�o�͑Ή�</br>
        /// <br>UpdateNote  : 2010/10/09 ������</br>
        /// <br>             �E��QID:15882 PM1010F�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            #region ���̓`�F�b�N

            // �q��
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tEdit_WarehouseCd_From.Text.CompareTo(this.tEdit_WarehouseCd_To.Text) > 0)
            if (this.tEdit_WarehouseCd_To.Text != "" && (this.tEdit_WarehouseCd_From.Text.CompareTo(this.tEdit_WarehouseCd_To.Text) > 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n�q�ɂ̒l���I���q�ɂ̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // �I��
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tEdit_WarehouseShelfNo_From.Text.CompareTo(this.tEdit_WarehouseShelfNo_To.Text) > 0)
            if (this.tEdit_WarehouseShelfNo_To.Text != "" && (this.tEdit_WarehouseShelfNo_From.Text.CompareTo(this.tEdit_WarehouseShelfNo_To.Text) > 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n�I�Ԃ̒l���I���I�Ԃ̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // ���[�J�[
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tNedit_MakerCd_From.GetInt() > this.tNedit_MakerCd_To.GetInt())
            if (this.tNedit_MakerCd_To.Text != "" && (this.tNedit_MakerCd_From.GetInt() > this.tNedit_MakerCd_To.GetInt()))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n���[�J�[�̒l���I�����[�J�[�̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // BL�R�[�h
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tNedit_BlGoodsCode_From.GetInt() > this.tNedit_BlGoodsCode_To.GetInt())
            if (this.tNedit_BlGoodsCode_To.Text != "" && (this.tNedit_BlGoodsCode_From.GetInt() > this.tNedit_BlGoodsCode_To.GetInt()))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�nBL�R�[�h�̒l���I��BL�R�[�h�̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // �i��
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tEdit_GoodsNo_From.Text.CompareTo(this.tEdit_GoodsNo_To.Text) > 0)
            if (this.tEdit_GoodsNo_To.Text != "" && (this.tEdit_GoodsNo_From.Text.CompareTo(this.tEdit_GoodsNo_To.Text) > 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n�i�Ԃ̒l���I���i�Ԃ̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // �o�̓t�@�C����
            if (string.IsNullOrEmpty(this.tEdit_OutputFileName.Text))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�o�̓t�@�C������ݒ肵�Ă��������B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            #endregion  // ���̓`�F�b�N

            SetExtratConst();

            this.DResult = DialogResult.OK;
            // --- UPD 2010/10/09 ---------->>>>>
            //this.Close();
            bool outputRslt = true;
            if (this.OutputData != null)
            {
                outputRslt = this.OutputData();
            }
            if (outputRslt)
            {
                this.Close();
            }
            // --- UPD 2010/10/09 ----------<<<<<
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\���{�^���N���b�N
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�@�C���_�C�A���O�\���{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_OutputFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_OutputFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_OutputFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excel�t�@�C��(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("�e�L�X�g�t�@�C��(*.CSV) | *.CSV");
            }

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_OutputFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }
        #endregion // �C�x���g

        #region �v���C�x�[�g�����o
        /// <summary>
        /// ���o�����Z�b�g
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���o�������Z�b�g���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void SetExtratConst()
        {
            List<string> warehouseCodeList = new List<string>();
            List<string> warehouseShelfNoList = new List<string>();
            List<Int32> makerCodeList = new List<Int32>();
            List<Int32> blGoodsCodeList = new List<Int32>();
            List<string> goodsNoList = new List<string>();

            string selectConditionFrom = string.Empty;
            string selectConditionTo = string.Empty;

            Int32 intSelectConditionFrom;
            Int32 intSelectConditionTo;

            // �q��
            if (!string.IsNullOrEmpty(this.tEdit_WarehouseCd_From.Text)
                || !string.IsNullOrEmpty(this.tEdit_WarehouseCd_To.Text))
            {
                selectConditionFrom = this.tEdit_WarehouseCd_From.Text;
                warehouseCodeList.Add(selectConditionFrom);

                selectConditionTo = this.tEdit_WarehouseCd_To.Text;
                warehouseCodeList.Add(selectConditionTo);
            }
            this.WarehouseCodeList = warehouseCodeList;

            // �I��
            if (!string.IsNullOrEmpty(this.tEdit_WarehouseShelfNo_From.Text)
                || !string.IsNullOrEmpty(this.tEdit_WarehouseShelfNo_To.Text))
            {
                selectConditionFrom = this.tEdit_WarehouseShelfNo_From.Text;
                warehouseShelfNoList.Add(selectConditionFrom);

                selectConditionTo = this.tEdit_WarehouseShelfNo_To.Text;
                warehouseShelfNoList.Add(selectConditionTo);
            }
            this.WarehouseShelfNoList = warehouseShelfNoList;

            // ���[�J�[
            if (this.tNedit_MakerCd_From.GetInt() != 0
                || this.tNedit_MakerCd_To.GetInt() != 0)
            {
                intSelectConditionFrom = this.tNedit_MakerCd_From.GetInt();
                makerCodeList.Add(intSelectConditionFrom);

                intSelectConditionTo = this.tNedit_MakerCd_To.GetInt();
                makerCodeList.Add(intSelectConditionTo);
            }
            this.MakerCodeList = makerCodeList;

            // BL�R�[�h
            if (this.tNedit_BlGoodsCode_From.GetInt() != 0
                || this.tNedit_BlGoodsCode_To.GetInt() != 0)
            {
                intSelectConditionFrom = this.tNedit_BlGoodsCode_From.GetInt();
                blGoodsCodeList.Add(intSelectConditionFrom);

                intSelectConditionTo = this.tNedit_BlGoodsCode_To.GetInt();
                blGoodsCodeList.Add(intSelectConditionTo);
            }
            this.BlGoodsCodeList = blGoodsCodeList;

            // �i��
            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo_From.Text)
                || !string.IsNullOrEmpty(this.tEdit_GoodsNo_To.Text))
            {
                selectConditionFrom = this.tEdit_GoodsNo_From.Text;
                goodsNoList.Add(selectConditionFrom);

                selectConditionTo = this.tEdit_GoodsNo_To.Text;
                goodsNoList.Add(selectConditionTo);
            }
            this.GoodsNoList = goodsNoList;

            // �o�͐�t�@�C����
            this.SettingFileName = this.tEdit_OutputFileName.Text;
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�̓t�@�C�����ύX�������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void ChangeFileName()
        {
            PMZAI04101UC userSettingForm = new PMZAI04101UC();
            string fileName = string.Empty;
            string path = string.Empty;
            userSettingForm.AnalysisTextSettingAcs.Deserialize();

            fileName = userSettingForm.AnalysisTextSettingAcs.StockFileNameValue;

            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (_excelFlg)
                {
                    // �g���q��XLS�ɂ���
                    fileName += ".xls";
                }
                else
                {
                    // �g���q��CSV�ɂ���
                    fileName += ".csv";
                }
            }
            this.tEdit_OutputFileName.Text = fileName;
        }
        #endregion // �v���C�x�[�g�����o
    }
}
