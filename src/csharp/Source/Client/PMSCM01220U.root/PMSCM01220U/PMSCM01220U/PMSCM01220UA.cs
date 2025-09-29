//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : �}�X�^�捞����                                          //
// �v���O�����T�v   : �}�X�^�捞����                                          //
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : qianl                                     //
// �� �� ��  2011/08/01  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gaoy                                      //
// �C �� ��  2011/08/20  �C�����e : �}�X�^�捞�����ɂĂ̏C��(Redmine#23848)   //
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �}�X�^�捞�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�X�^�捞�������s���܂��B</br>
    /// <br>Programer  : qianl</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br>Update Note: ��Q�� #23848�Ή�</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.08.20</br>
    /// </remarks>
    public partial class PMSCM01220UA : Form
    {
        # region << Private Members >>

        private SFCMN00299CA _progressForm;

        private string _enterpriseCode;        //��ƃR�[�h
        private string _sectionCode;           //���_�R�[�h

        private PM7RkSetting _pM7RkSetting;            //PM7�A�g�S�̐ݒ�}�X�^
        private PM7RkSettingAcs _pM7RkSettingAcs;      //PM7�A�g�S�̐ݒ�A�N�Z�X�N���X

        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;        // ���O�C���S����Title
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;         // ���O�C���S����Name

        private ConvertList.ListDataTable ConvertDataList;

        private const string ctPGID = "PMSCM01220U";        //�v���O����ID

        private Dictionary<string, string> lstTblNm = new Dictionary<string, string>();

        private Dictionary<string, string> lstTableName = new Dictionary<string, string>();
        private ArrayList tableIdList = new ArrayList();
        private ArrayList tableNmList = new ArrayList();

        private StringBuilder TableIdString = null;

        # endregion

        # region << Constructor >>

        /// <summary>
        /// �}�X�^�捞�����t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^�捞�����t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        public PMSCM01220UA()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;              //��ƃR�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //���_�R�[�h

            this._pM7RkSetting = new PM7RkSetting();            //PM7�A�g�S�̐ݒ�}�X�^
            this._pM7RkSettingAcs = new PM7RkSettingAcs();      //PM7�A�g�S�̐ݒ�A�N�Z�X�N���X

            this._pM7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pM7RkSetting.SectionCode = this._sectionCode;

        }

        # endregion

        # region << �R���g���[���C�x���g�n���h�� >>

        /// <summary>
        /// �t�H�[��Close�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����I������O�ɔ������܂��B</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMSCM01220UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// �}�X�^�捞�����t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �}�X�^�捞�����t�H�[�������������܂��B</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMSCM01220UA_Load(object sender, EventArgs e)
        {
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)ToolbarsManager_Main.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)ToolbarsManager_Main.Tools["LabelTool_LoginName"];
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // �c�[���o�[�̐ݒ�
            this.SettingToolbar();

            //PM7�A�g�ݒ�}�X�^����e�L�X�g�i�[�t�H���_����������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                status = this._pM7RkSettingAcs.Read(ref this._pM7RkSetting);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.TextSaveFolder_tEdit.Text = this._pM7RkSetting.TextSaveFolder;

                }
                else
                {
                    this.TextSaveFolder_tEdit.Text = "";
                }
            }
            catch (Exception)
            {
                this.TextSaveFolder_tEdit.Text = "";
            }

            ConvertDataList = new ConvertList.ListDataTable();

            DataTable CustomersTable = new DataTable("Customers");
            DataRow row;
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TableId";
            CustomersTable.Columns.Add(column);


            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TableNm";
            CustomersTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ReadDataCnt";
            CustomersTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "WriteDataCnt";
            CustomersTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Result";
            CustomersTable.Columns.Add(column);

            tableIdList.Add("GOODSMNG");
            tableIdList.Add("GOODSU");
            tableIdList.Add("GOODSPRICEU");
            tableIdList.Add("JOINPARTSU");
            tableIdList.Add("GOODSSET");
            tableIdList.Add("PRMSETTINGU");
            tableIdList.Add("PARTSSUBSTU");
            tableIdList.Add("RATE");
            tableIdList.Add("STOCK");
            tableIdList.Add("CARMANAGEMENT");
            tableIdList.Add("USERGDBDU");
            tableNmList.Add("���i�Ǘ����}�X�^");
            tableNmList.Add("���i�}�X�^�i���[�U�[�o�^���j");
            tableNmList.Add("���i�}�X�^");
            tableNmList.Add("�����}�X�^(���[�U�[�o�^�j");
            tableNmList.Add("���i�Z�b�g�}�X�^");
            tableNmList.Add("�D�ǐݒ�}�X�^�i���[�U�[�o�^���j");
            tableNmList.Add("���i��փ}�X�^�i���[�U�[�o�^���j");
            tableNmList.Add("�|���}�X�^");
            tableNmList.Add("�݌Ƀ}�X�^");
            tableNmList.Add("�ԗ��Ǘ��}�X�^");
            tableNmList.Add("���[�U�[�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j");
            try
            {
                for (int i = 0; i < tableIdList.Count; i++)
                {
                    row = CustomersTable.NewRow();
                    row["TableID"] = tableIdList[i].ToString();
                    row["TableNm"] = tableNmList[i].ToString();
                    row["ReadDataCnt"] = 0;
                    row["WriteDataCnt"] = 0;
                    row["Result"] = "";
                    CustomersTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                   ex.Message, 0, MessageBoxButtons.OK);
            }

            try
            {
                ConvertDataList.Merge(CustomersTable, false, MissingSchemaAction.Ignore);
                ConvertDataList.AcceptChanges();

                gridConvData.BeginUpdate();
                gridConvData.DataSource = ConvertDataList.DefaultView;

                //�I���`�F�b�N�{�b�N�X�̏����l��ON�ɂ��܂��B
                for (int i = 0; i < gridConvData.Rows.Count; i++)
                {
                    this.gridConvData.Rows[i].Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value = true;
                }

                ConvertDataList.DefaultView.RowFilter = "Visible = True";
                gridConvData.EndUpdate();

                SetEnabledStockAcPayHist();
            }
            catch (Exception ex)
            {

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    ex.Message, 0, MessageBoxButtons.OK);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    "�}�X�^�捞�����p�ݒ�t�@�C����p�ӂ��ĉ������B", 0, MessageBoxButtons.OK);
                Close();
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Close_buttonTool":
                    // �I���{�^��
                    // ���C����ʂ̃N���[�Y
                    this.Close();
                    break;

                case "OK_buttonTool":
                    // �X�V�{�^��
                    if (ValidateInput())
                    {
                        ConvertData();
                    }
                    break;
            }

        }

        /// <summary>
        /// ���̓o���f�[�V��������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private bool ValidateInput()
        {
            bool returnbl = false;
            string query = "";

            if (TextSaveFolder_tEdit.Text.Trim() == "")
            {
                this.TextSaveFolder_tEdit.Clear();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                                "�e�L�X�g�i�[�t�H���_����͂��ĉ������B", 0, MessageBoxButtons.OK);
                TextSaveFolder_tEdit.Focus();
                return returnbl;
            }
            if (Directory.Exists(TextSaveFolder_tEdit.Text) == false)
            {
                this.TextSaveFolder_tEdit.Clear();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�w�肵���e�L�X�g�i�[�t�H���_�����݂��܂���B", 0, MessageBoxButtons.OK);
                TextSaveFolder_tEdit.Focus();
                return returnbl;
            }

            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);

            for (int ind = 0; ind < rows.Length; ind++)
            {
                if (rows[ind].TruncateFlg == true)
                {
                    returnbl = true;
                    break;
                }
            }
            if (returnbl==false)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                                "�}�X�^�捞�����Ώۂ�I��ŉ������B", 0, MessageBoxButtons.OK);
                return returnbl;
            }
            return returnbl;
        }


        /// <summary>
        /// �R���o�[�g����
        /// </summary>
        /// <remarks>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: ��Q�� #23848�Ή�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.08.20</br>
        /// </remarks>
        private void ConvertData()
        {
            string query = "";
            string table = string.Empty;
            ConvertDataList.AcceptChanges();
            string SaveFolder = this.TextSaveFolder_tEdit.Text.Trim();
            // �R���o�[�g�Ώۂ̃e�[�u������
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);
            if (rows.Length == 0)
                return;

            try
            {
                _progressForm = new SFCMN00299CA();

                _progressForm.Title = "�}�X�^�捞����";
                _progressForm.Message = "�����A�}�X�^�捞�������ł��D�D�D";


                StringBuilder selTableId = new StringBuilder();
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].ReadDataCnt = 0; // ���[�h�J�E���^�N���A
                    rows[i].WriteDataCnt = 0; // ���C�g�J�E���^�N���A
                    rows[i].Result = string.Empty; // �������ʃN���A
                }

                _progressForm.Show(this);

                Refresh();

                string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");

                for (int ind = 0; ind < rows.Length; ind++)
                {
                    int readCnt = 0;

                    int updateCnt = 0;

                    string errMsg = "";

                    if (rows[ind].TruncateFlg == true)
                    {
                        SndAndRcvProcAcs sndAndRcvProcAcs = new SndAndRcvProcAcs();

                        int status = sndAndRcvProcAcs.SearchAndTextin(0, datetime, rows[ind].TableId, TextSaveFolder_tEdit.Text.Trim(), this._enterpriseCode, ref readCnt, ref updateCnt, ref errMsg);

                        if (readCnt == 0)
                        {
                            rows[ind].ReadDataCnt = readCnt;
                            rows[ind].WriteDataCnt = updateCnt;
                            if (errMsg != "" && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                rows[ind].Result = "�X�V" + updateCnt.ToString("#,##0") + "���B" + errMsg;
                            }
                            else
                            {
                                rows[ind].Result = "�X�V" + updateCnt.ToString("#,##0") + "���B�Ώ�CSV�t�@�C�������݂��܂���B";
                            }
                        }

                        if (readCnt != updateCnt && readCnt != 0)
                        {
                            int errCnt = readCnt - updateCnt;
                            rows[ind].ReadDataCnt = readCnt;
                            rows[ind].WriteDataCnt = updateCnt;
                            if (errMsg != "")
                            {
                                rows[ind].Result = "�X�V" + updateCnt.ToString("#,##0") + "���A�G���[" + errCnt.ToString("#,##0") + "���B" + errMsg;

                            }
                            else
                            {
                                rows[ind].Result = "�X�V" + updateCnt.ToString("#,##0") + "���A�G���[" + errCnt.ToString("#,##0") + "���B�������G���[���������܂����B";
                            }
                        }

                        if (readCnt == updateCnt && readCnt != 0)
                        {
                            rows[ind].ReadDataCnt = readCnt;
                            rows[ind].WriteDataCnt = updateCnt;
                            //rows[ind].Result = "�X�V" + updateCnt.ToString("#,##0") + "���B�G���[������܂���B";       // DEL 2011.08.20 gaoy FOR ��Q�� #23848
                            rows[ind].Result = "�X�V" + updateCnt.ToString("#,##0") + "���B����I���B";                   // ADD 2011.08.20 gaoy FOR ��Q�� #23848
                            
                        }
                    }
                }
            }
            finally
            {
                if (_progressForm != null)
                {
                    _progressForm.Close();
                    _progressForm = null;
                }
            }
        }

        /// <summary>
        /// Control.MouseHover �C�x���g(uButton_DirGuide)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �e�L�X�g�i�[�t�H���_�{�^���R���g���[����MouseHover���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void uButton_DirGuide_MouseHover(object sender, EventArgs e)
        {
            this.uButton_DirGuide.Refresh();
            this.toolTip1.SetToolTip(this.uButton_DirGuide, "�e�L�X�g�i�[�t�H���_�K�C�h");
        }

        # endregion

        # region << �v���C�x�[�g���\�b�h >>

        /// <summary>
        /// �c�[���o�[�̃A�C�R���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t���[���̃c�[���o�[�̐ݒ���s���܂��B</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SettingToolbar()
        {
            //--------------------------------------------------------------
            // ���C���c�[���o�[
            //--------------------------------------------------------------
            // �C���[�W���X�g��ݒ肷��
            this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

            uButton_DirGuide.ImageList = IconResourceManagement.ImageList16;
            uButton_DirGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // �I���̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["Close_buttonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �m��̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["OK_buttonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

        }

        # endregion

        #region  << �{�^���C�x���g���� >>

        /// <summary>
        /// Button.Click �C�x���g(uButton_DirGuide_Click)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �e�L�X�g�i�[�t�H���_�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void uButton_DirGuide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            dlg.Description = "�e�L�X�g�i�[�t�H���_���w�肵�ĉ������B";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TextSaveFolder_tEdit.Text = dlg.SelectedPath;
            }
        }

        /// <summary>
        /// �O���b�h�Z�b�g
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@ :�Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void SetEnabledStockAcPayHist()
        {
            for (int rowIndex = 0; rowIndex < gridConvData.Rows.Count; rowIndex++)
            {
                if ((string)gridConvData.Rows[rowIndex].Cells["TableId"].Value == "STOCKACPAYHISTRF")
                {
                    gridConvData.Rows[rowIndex].Cells["TruncateFlg"].Activation = Activation.Disabled;
                }
                else
                {
                    gridConvData.Rows[rowIndex].Cells["TruncateFlg"].Activation = Activation.AllowEdit;
                }
            }
        }

        #endregion

        #region  << �O���b�h�C�x���g���� >>

        /// <summary>
        /// �O���b�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            TableIdString = new StringBuilder();

            e.Layout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            UltraGridBand band0 = e.Layout.Bands[0];
            band0.Columns[ConvertDataList.TableIdColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.ConvKindColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.PrevResultColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.CsvCountColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.VisibleColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.DeployColumn.ColumnName].Hidden = true;

            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Width = 40;
            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Width = 370;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Width = 420;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;

            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Format = "###,###,##0";
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Format = "###,###,##0";

            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.VisibleRows;

        }

        /// <summary>
        /// �O���b�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridConvData.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    // [�폜]�J�����̒l��ݒ�
                    bool truncateFlag = (bool)this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value;
                    this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value = !truncateFlag;
                }
            }
        }

        /// <summary>
        /// �O���b�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            
            bool val = !((bool)e.Cell.Value);
            e.Cell.Value = val;

            if (gridConvData.Selected.Rows.Count == 0 || e.Cell.Row != gridConvData.Selected.Rows[0])
                e.Cell.Row.Selected = true;
            e.Cancel = true;
        }

        /// <summary>
        /// �O���b�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_Enter(object sender, EventArgs e)
        {
            if (gridConvData.ActiveRow != null)
            {
                gridConvData.ActiveRow.Selected = true;
            }
            else
            {
                if (gridConvData.Rows.Count > 0)
                {
                    gridConvData.Rows[0].Activate();
                    gridConvData.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// �O���b�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_Leave(object sender, EventArgs e)
        {
            gridConvData.Selected.Rows.Clear();
        }

        /// <summary>
        /// �O���b�h �C���t�H�Z�b�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
        {
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

            Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
            Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
            Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

            sizeCell.Height = 20;
            sizeCell.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            sizeHeader.Height = 20;
            sizeHeader.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

        }

        #endregion

        #region  << �t�H�[�J�X���� >> 

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == uButton_DirGuide)
            {
                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    gridConvData.Rows[0].Activate();
                }
            }
            if (e.PrevCtrl == TextSaveFolder_tEdit)
            {
                if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    gridConvData.Rows[gridConvData.Rows.Count - 1].Activate();
                }
            }
           
            if (e.PrevCtrl == gridConvData)
            {
                if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    if (gridConvData.ActiveRow != null && gridConvData.ActiveRow.Index > 0)
                    {
                        UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Previous);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        if (gridConvData.ActiveRow.Index >= 0)
                        {
                            e.NextCtrl = gridConvData;
                        }
                    }
                }

                else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    if (gridConvData.ActiveRow != null
                    && gridConvData.ActiveRow.Index < gridConvData.Rows.Count - 1)
                    {
                        UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        if (gridConvData.ActiveRow.Index <= gridConvData.Rows.Count - 1)
                        {
                            e.NextCtrl = gridConvData;
                        }
                    }
                }
            }
        }

        #endregion

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           