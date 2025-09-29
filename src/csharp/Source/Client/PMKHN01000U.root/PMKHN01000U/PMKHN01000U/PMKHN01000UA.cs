//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� PJTASDNO004  �쐬�S�� : LDNS wangqx
// �� �� ��  2011/07/14  �C�����e : �������f�[�^�N���A�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/14 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
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
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �f�[�^���M����
    /// </summary>
    /// <remarks>
    /// Note       : �f�[�^���M�����ł��B<br />
    /// Programmer : ���w�q<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public partial class PMKHN01000UA : Form
    {
        #region �� Const Memebers ��
        private const string ct_PGID = "PMKHN01000UA";
        private const string ct_PGName = "�f�[�^�N���A����";
        #endregion �� Const Memebers ��

        #region �� private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _enterButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private DataClearDataSet.DataClearDataTable _dataClearDataTable;
        private DataClearAcs _dataClearAcs;
        private PMKHN01000UB _gridDetails;
        private string _enterpriseCode;
        private DateGetAcs _dateGetAcs;
        // -- ADD 2011/07/14 ------------------------------------------->>>
        private CompanyInfAcs _companyInfAcs;
        // -- ADD 2011/07/14 -------------------------------------------<<<
        #endregion �� private field ��

        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN01000UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._enterButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Enter"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._dataClearAcs = DataClearAcs.GetInstance();
            this._dataClearDataTable = this._dataClearAcs.DataClearDataTable;
            this._gridDetails = new PMKHN01000UB();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._dateGetAcs = DateGetAcs.GetInstance();
            // -- ADD 2011/07/14 ------------------------------------------->>>
            this._companyInfAcs = new CompanyInfAcs();
            // -- ADD 2011/07/14 -------------------------------------------<<<
        }
        #endregion �� �R���X�g���N�^ ��

        #region �� Control Event
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: ���w�q</br>	
        /// <br>Date		: 2009.06.16</br>
        /// </remarks>
        private void PMKHN01000UA_Load(object sender, EventArgs e)
        {
            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this.ButtonInitialSetting();

            this.panel_Detail.Controls.Add(this._gridDetails);
            this._gridDetails.Dock = DockStyle.Fill;
            this._gridDetails.InitialSettingGridCol();

            // �c���ݒ茎�̏������ݒ�
            this.InitClearYM();

            // �O���b�h�̏���������
            this.InitialDataGridCol();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �^�C���N��
            this.timer_Initial.Enabled = true;
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: ���w�q</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Enter":
                    {
                        // ���t�̖����̓`�F�b�N
                        if (this.CheckDateNoInput(this.tDateEdit_DataClearYM))
                        {
                            this.tDateEdit_DataClearYM.Clear();
                        }
                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_PGID,
                            "�f�[�^�N���A���������s���܂��B\r\n��낵���ł����H", 0, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            string errMsg = string.Empty;
                            // �`�F�b�N����
                            if (this.ClearBeforeCheck(out errMsg))
                            {
                                // �f�[�^�N���A����
                                this.DataClear();
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// ��������̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ��������̏����ł��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.06.18</br>
        /// </remarks>
        private void timer_Initial_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tDateEdit_DataClearYM.Select();
            this.timer_Initial.Enabled = false;
        }

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ���L�[�ł̃t�H�[�J�X�ړ��C�x���g�ł��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.06.18</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
			// ADD 2011.09.14 ------->>>>>
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				case "tEdit_SecCode":
					{
						// ���_�R�[�h�擾
						string sectionCode = this.tEdit_SecCode.DataText.Trim();
						if (!sectionCode.Trim().Equals(""))
						{
							this.tEdit_SecCode.DataText = sectionCode.PadLeft(2, '0');
						}
					}
					break;
			}
			// ADD 2011.09.14 -------<<<<<

            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tDateEdit_DataClearYM)
                    {
                        //e.NextCtrl = this._gridDetails.uGrid_Details;//DEL by Liangsd     2011/09/06
                        //this._gridDetails.uGrid_Details.Rows[0].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();//DEL by Liangsd     2011/09/06
						e.NextCtrl = this.tEdit_SecCode;//ADD by Liangsd    2011/09/06
                    }
                    //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
					else if (e.PrevCtrl == this.tEdit_SecCode)
                    {
                        e.NextCtrl = this._gridDetails.uGrid_Details;
                        this._gridDetails.uGrid_Details.Rows[0].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();
                    }
                    //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
                    else if (e.PrevCtrl == this._gridDetails.uGrid_Details)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:

                                if (this._gridDetails.uGrid_Details.ActiveCell != null)
                                {
                                    if (this._gridDetails.ReturnKeyDown(false))
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_DataClearYM;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tDateEdit_DataClearYM)
                    {
                        e.NextCtrl = this._gridDetails.uGrid_Details;
                        int rowCnt = this._gridDetails.uGrid_Details.Rows.Count;
                        this._gridDetails.uGrid_Details.Rows[rowCnt - 1].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();
                    }
                    //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
					else if (e.PrevCtrl == this.tEdit_SecCode)
                    {
                        e.NextCtrl = this.tDateEdit_DataClearYM;
                    }
                    //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
                    else if (e.PrevCtrl == this._gridDetails.uGrid_Details)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:

                                if (this._gridDetails.uGrid_Details.ActiveCell != null)
                                {
                                    if (this._gridDetails.ReturnKeyDown(true))
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else
                                    {
                                        //e.NextCtrl = this.tDateEdit_DataClearYM;//DEL by Liangsd     2011/09/06
										e.NextCtrl = this.tEdit_SecCode;//ADD by Liangsd    2011/09/06
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���t�̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ���t�̃t�H�[�J�X�ړ��C�x���g�ł��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.06.18</br>
        /// </remarks>
        private void tDateEdit_DataClearYM_Leave(object sender, EventArgs e)
        {
            // ���t�̖����̓`�F�b�N
            if (this.CheckDateNoInput(this.tDateEdit_DataClearYM))
            {
                this.tDateEdit_DataClearYM.Clear();
            }
        }
        #endregion �� Control Event

        #region  �� private method ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._enterButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }

        /// <summary>
        /// �c���ݒ茎�̏������ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c���ݒ茎�̏������ݒ菈�����s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns></returns>
        private void InitClearYM()
        {
            string sectionCode = string.Empty;
            DateTime prevTotalDay = new DateTime();
            DateTime currentTotalDay = new DateTime();
            DateTime prevTotalMonth = new DateTime();
            DateTime currentTotalMonth = new DateTime();

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            // �O�񌎎��X�V���擾���\�b�h
            totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            this.tDateEdit_DataClearYM.SetDateTime(prevTotalMonth);
        }

        /// <summary>
        /// �O���b�h�̏���������
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h�̏������������s���B</br>
        /// <br>Programmer	: ���w�q</br>	
        /// <br>Date		: 2009.06.16</br>
        /// </remarks>
        private void InitialDataGridCol()
        {
            DataClear _dataClear = new DataClear();
            ArrayList dataClearList = _dataClear.GetDataClearList();
            // ���M�Ώۃf�[�^���O���b�h�֐ݒ肷��
            for (int i = 0; i < dataClearList.Count; i++)
            {
                DataClearWork dataClearWork = (DataClearWork)dataClearList[i];
                DataClearDataSet.DataClearRow row = this._dataClearDataTable.NewDataClearRow();
                row.RowNo = i + 1;
                row.TableId = dataClearWork.TableId;
                row.TableNm = dataClearWork.TableNm;
#if DEBUG
                row.IsChecked = false;
#else
                row.IsChecked = true;
#endif
                row.ClearCode = dataClearWork.ClearCode;
                row.FileId = dataClearWork.FileId;
                this._dataClearDataTable.AddDataClearRow(row);
            }
        }

        /// <summary>
        /// �N���A�O�̃`�F�b�N����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �N���A�O�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private bool ClearBeforeCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // ���t�̖����̓`�F�b�N
            if (this.CheckDateNoInput(this.tDateEdit_DataClearYM))
            {
                errMsg = "�c���ݒ茎����͂��ĉ������B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                this.tDateEdit_DataClearYM.Select();
                return false;
            }

            // ���t�̕s�����̓`�F�b�N
            if (this.CheckDateInvalid(this.tDateEdit_DataClearYM))
            {
                errMsg = "�c���ݒ茎���s���ł��B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                this.tDateEdit_DataClearYM.Select();
                return false;
            }

            // �����Ώۂ̑I���`�F�b�N
            if (!this._dataClearAcs.IsGridDetailSelected())
            {
                errMsg = "�����Ώۂ�I�����ĉ������B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                this._gridDetails.ActivateCheckBox(0);
                return false;
            }
			// DEL 2011.09.14 ------->>>>>
			//ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
			//���_�Ǘ�����M�f�[�^�I�𔻒�
			//if (this._dataClearAcs.IsSelected() && this.tEdit_SecCode.Text == "")
			//{
			//    errMsg = "�����Ώۂ̋��_�R�[�h����͂��ĉ������B";
			//    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
			//    this._gridDetails.ActivateCheckBox(0);
			//    this.tEdit_SecCode.Focus();
			//    return false;
			//}
			//ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
			// DEL 2011.09.14 -------<<<<<
            // �I�t���C����ԃ`�F�b�N
            if (!this._dataClearAcs.CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʃN���A�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���t�̖����̓`�F�b�N
        /// </summary>
        /// <param name="targetDateEdit">���t</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ���t�̖����̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private bool CheckDateNoInput(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfNoInput);
        }

        /// <summary>
        /// ���t�̕s�����̓`�F�b�N
        /// </summary>
        /// <param name="targetDateEdit">���t</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ���t�̕s�����̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private bool CheckDateInvalid(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfInvalid);
        }

        /// <summary>
        /// �f�[�^�N���A����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�N���A�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private void DataClear()
        {
            // �폜�N��
            DateTime delYM = this.tDateEdit_DataClearYM.GetDateTime().AddMonths(1);
            Int32 intDelYM = Convert.ToInt32(delYM.ToString("yyyyMM"));

            // �폜�N���J�n��
            DateTime startMonthDate, endMonthDate;
            this._dateGetAcs.GetDaysFromMonth(delYM, out startMonthDate, out endMonthDate);
            Int32 intDelYMD = Convert.ToInt32(startMonthDate.ToString("yyyyMMdd"));

            // �������_�C�A���O
            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�f�[�^�N���A����";
            form.Message = "���݁A�f�[�^�N���A�������ł��B";
            // �_�C�A���O�\��
            form.Show();

            // ���s����
            string errMsg = string.Empty;
            //int status = this._dataClearAcs.DataClear(this._enterpriseCode, intDelYM, intDelYMD, out errMsg);//DEL by Liangsd     2011/09/06
			int status = this._dataClearAcs.DataClear(this.tEdit_SecCode.Text, this._enterpriseCode, intDelYM, intDelYMD, out errMsg);//ADD by Liangsd     2011/09/06
            // -- ADD 2011/07/14 ------------------------------------------->>>
            // ���Џ��}�X�^�Ɂu�f�[�^�N���A�������s�N�����v�A�u�f�[�^�N���A�������s�����b�~���b�v��ݒ肷��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string errMsg2 = string.Empty;
                CompanyInf companyInf = new CompanyInf();
                System.DateTime currentTime = DateTime.Now;
                string DelYMD = currentTime.ToString("yyyyMMdd ");
                string DelHMSXXX = currentTime.ToString("HHmmssfff");
                companyInf.EnterpriseCode = this._enterpriseCode;
                int status2 = this._companyInfAcs.WriteClearTime(companyInf, DelYMD, DelHMSXXX, out errMsg2);
            }
            // -- ADD 2011/07/14 -------------------------------------------<<<
            // �_�C�A���O�����
            form.Close();

            System.Threading.Thread.Sleep(1);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�f�[�^�N���A�������������܂����B", status);
            }
            else
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
            }

        }

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
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_PGID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PGName,						    // �v���O��������
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
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_PGID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PGName,						    // �v���O��������
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
        #endregion �� private method ��
    }
}