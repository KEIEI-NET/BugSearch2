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

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����쐬���C���t���[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������������/��������X�V�̊e�q��ʂ𐧌䂷�郁�C���t���[���ł��B</br>
    /// <br>Programer  : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br>Update Note: 2009/01/26 30414 �E �K�j ��QID:10498�Ή�</br>
    /// <br>Update Note: 2009/01/30 30414 �E �K�j ��QID:10741�Ή�</br>
    /// <br>Update Note: 2009/02/26 30414 �E �K�j ��QID:12049�Ή�</br>
    /// <br>Update Note: 2009/02/27 30414 �E �K�j ��QID:12043�Ή�</br>
    /// <br>Update Note: 2009/03/02 30414 �E �K�j ��QID:12051�Ή�</br>
    /// <br>Update Note: 2009/03/23 30414 �E �K�j ��QID:12532�Ή�</br>
    /// <br>Update Note: 2009/11/17 30517 �Ė� �x�� CSV���t�@�C�����Ȃ��Ă��N���A�������s���悤�ɏC��</br>
    /// <br>Update Note: 2011/09/06 ����� �A��991�ARedmine#23658�̑Ή�</br>
    /// <br>Update Note: 2012/11/09 zhangy3 PM.NS�̃C���|�[�g���ɑҋ@���[�h��ǉ���PM7SP���̏I���t�@�C�����Ď����Ď����Ŏ�荞�߂�悤�ɂ��܂��B</br>
    /// <br>Update Note: 2012/11/28 zhangy3 Redmine #33660 �R���o�[�g���ǂ̏�Q�C���˗��B</br>
    /// </remarks>
    public partial class PMKHN08000UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN08000UA()
        {
            InitializeComponent();
            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            // �c�[���o�[�̐ݒ�
            this.SettingToolbar();

            uButton_DirGuide.ImageList = IconResourceManagement.ImageList16;
            uButton_DirGuide.Appearance.Image = (int)Size16_Index.STAR1;
            uBtn_DirGuide2.ImageList = IconResourceManagement.ImageList16;
            uBtn_DirGuide2.Appearance.Image = (int)Size16_Index.STAR1;
            Refresh();

            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            ConvertDataList = new ConvertList.ListDataTable();
            _ConvertProcAcs = new ConvertProcAcs();
            configData = new DataSet();

            lstTblNm.Add("SALESSLIP", "����f�[�^");
            lstTblNm.Add("DEPSITMAIN", "�����}�X�^");
            lstTblNm.Add("STOCKSLIP", "�d���f�[�^");
            lstTblNm.Add("PAYMENTSLP", "�x���`�[�}�X�^");
            lstTblNm.Add("STOCKADJUST", "�݌ɒ����f�[�^");

            try
            {
                configData.ReadXml(ctCONFIGFILE);
                ConvertDataList.Merge(configData.Tables[0], false, MissingSchemaAction.Ignore);
                ConvertDataList.AcceptChanges();
                ConvertList.ListRow rowParent = null;
                for (int i = 0; i < ConvertDataList.Count; i++)
                {
                    if (lstInvisible.Contains(ConvertDataList[i].TableId))
                        ConvertDataList[i].Visible = false;

                    rowParent = GetParentRow(ConvertDataList[i].TableId.Replace("RF", ""));
                    //if (ConvertDataList[i].PrevResult >= ConvertDataList[i].CsvCount)
                    //{
                    //    ConvertDataList[i].Result = "�R���o�[�g�ς�";
                    //}
                    //else if (ConvertDataList[i].PrevResult == -1)
                    //{
                    //    ConvertDataList[i].Result = "�O��R���o�[�g���s";
                    //    if (rowParent != null)
                    //    {
                    //        rowParent.Result = ConvertDataList[i].Result;
                    //    }
                    //}
                    //else
                    //{
                    //    if (rowParent != null)
                    //    {
                    //        rowParent.Result = string.Empty;
                    //    }
                    //}

                    // --- CHG 2009/01/30 ��QID:10741�Ή�------------------------------------------------------>>>>>
                    //if (ConvertDataList[i].ConvKind != 2) // ���шȊO��[�R���o�[�g�O�폜����]���f�t�H���g�Ƃ���B
                    //{
                    //    ConvertDataList[i].TruncateFlg = true;
                    //}
                    ConvertDataList[i].TruncateFlg = true;
                    // --- CHG 2009/01/30 ��QID:10741�Ή�------------------------------------------------------<<<<<
                }
                gridConvData.BeginUpdate();
                gridConvData.DataSource = ConvertDataList.DefaultView;
                ConvertDataList.DefaultView.RowFilter = "Visible = True";
                gridConvData.EndUpdate();

                SetEnabledStockAcPayHist();
            }
            catch
            {
                //MessageBox.Show("�R���o�[�g�p�ݒ�t�@�C����p�ӂ��ĉ������B", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    "�R���o�[�g�p�ݒ�t�@�C����p�ӂ��ĉ������B", 0, MessageBoxButtons.OK);
                Close();
            }
            convFilter = ConvKindFilter.All;
        }
        # endregion

        # region �v���C�x�C�g�����o
        private int selectedCnt = 0;
        private SFCMN00299CA _progressForm;
        private bool cancelFlg = false;
        private bool isRemoteOnProcess = false;
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        private DataSet configData;
        private ConvertList.ListDataTable ConvertDataList;
        private ConvertProcAcs _ConvertProcAcs;

        // --- ADD 2011/09/06---------->>>>>
        private static readonly string PROGRAM_ID = "PMKHN08000U";
        private static readonly string PROGRAM_NAME = "PM7��PM.NS�R���o�[�g";
        // --- ADD 2011/09/06----------<<<<<
        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
        private int wait_SelModelType = -1;
        private List<string> wait_FileLst = null;
        private bool IsStartWaitFlg = false;
        //-----Add End   2012/11/09 zhangy3 -----<<<<<
        private Dictionary<List<string>, bool> InfoShowList = new Dictionary<List<string>, bool>();//Add  2012/11/28 zhangy3

        private enum ConvKindFilter
        {
            All = 4,
            Master = 0,
            Data = 1,
            Jisseki = 2
        }
        private ConvKindFilter convFilter;
        # endregion

        # region �萔�錾
        /// <summary>PGID</summary>
        private const string ctPGID = "PMKHN08000U";
        private const string ctCONFIGFILE = "Conv.config";
        /// <summary>��\�����ڃ��X�g</summary>
        private List<string> lstInvisible = new List<string>(new string[]{"SALESDETAILRF",
                                                "SALESHISTORYRF",
                                                "SALESHISTDTLRF",
                                                "ACCEPTODRCARRF",
                                                "CNVCARPARTSRF",
                                                "DEPSITDTLRF",
                                                "STOCKDETAILRF",
                                                "STOCKSLIPHISTRF",
                                                "STOCKSLHISTDTLRF",
                                                "PAYMENTDTLRF",
                                                "STOCKADJUSTDTLRF"});

        /// <summary>�w�b�_�E���ד����I�𐧌�p���X�g</summary>
        private List<string> lstHeaderTbl = new List<string>(new string[]{"SALESSLIPRF",
                                                "DEPSITMAINRF",
                                                "STOCKSLIPRF",
                                                "PAYMENTSLPRF",
                                                "STOCKADJUSTRF"});

        /// <summary>�݌Ɏ󕥏����p�`�F�b�N���X�g</summary>
        private List<string> lstSAPHistInfoChk = new List<string>(new string[]{"SALESSLIPRF",
                                                "SALESDETAILRF",
                                                "SALESHISTORYRF",
                                                "SALESHISTDTLRF",
                                                "STOCKSLIPRF",
                                                "STOCKDETAILRF",
                                                "STOCKSLIPHISTRF",
                                                "STOCKSLHISTDTLRF",
                                                "STOCKMOVERF",
                                                "STOCKADJUSTRF",
                                                "STOCKADJUSTDTLRF" });

        private List<string> listChkExcpt = new List<string>(
                new string[] {
                    "USERGDBDU",      // ���[�U�[�K�C�h(��s�̎x�X�R�[�h�ɂ��d������P�[�X�j
                    "PARTSPOSCODEU",  // ���ʁiBL�R�[�h����O�I�ɏd������P�[�X�j
                    "JOINPARTSU",     // �����}�X�^(���[�U�[�o�^�j�i�\�����ʈႢ�Ō�����i���d������P�[�X�j
                    "GOODSSET"        // ���i�Z�b�g�}�X�^�i�\�����ʈႢ�ŃZ�b�g�q���d������P�[�X�j
                });

        private List<string> listLastTbl = new List<string>(
                new string[] {
                    "CNVCARPARTS",      // ���q���i�f�[�^
                    "DEPSITDTL",        // �������׃f�[�^
                    "STOCKSLHISTDTL",   // �d�����𖾍׃f�[�^
                    "PAYMENTDTL",       // �x�����׃f�[�^
                    "STOCKADJUSTDTL"    // �݌ɒ������׃f�[�^
                });

        private string[] lstSAP = new string[] { 
                "����f�[�^",
                "���㗚���f�[�^",
                "�d���f�[�^",
                "�d�������f�[�^",
                "�݌Ɉړ��f�[�^",
                "�݌ɒ����f�[�^",
            };

        private Dictionary<string, string> lstTblNm = new Dictionary<string, string>();
        # endregion

        # region �R���g���[���C�x���g�n���h��

        /// <summary>
        /// �t�H�[��Close�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����I������O�ɔ������܂��B</br>
        /// <br>Programer  : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void PMKHN08000UA_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: PM.NS�̃C���|�[�g���ɑҋ@���[�h��ǉ���PM7SP���̏I���t�@�C�����Ď����Ď����Ŏ�荞�߂�悤�ɂ��܂��B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012.11.09</br>
        /// </remarks>
        private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    //--------------------------------------------------------------
                    // �I���{�^��
                    //--------------------------------------------------------------
                    // ���C����ʂ̃N���[�Y
                    this.Close();
                    break;

                case "Button_Convert":
                    DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                "���s���܂����H", 0, MessageBoxButtons.OKCancel);
                    if (ret == DialogResult.OK && ValidateInput())
                    {
                        SetCounter();//Add 2012/11/28 zhangy3
                        ConvertData();
                    }
                    break;

                case "Button_Cancel":
                    txtDir.Clear();
                    txtLogDir.Clear();
                    SetDeploy(false);
                    break;

                case "Btn_StockAcPay":
                    // 20081128 �{�^������͂Ȃ�
                    //try
                    //{
                    //    _ConvertProcAcs.BeginTransaction();
                    //    int status = _ConvertProcAcs.SetStockAcPayHist(0);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(1);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(2);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(3);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(4);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(5);
                    //    if (status == 0)
                    //    {
                    //        _ConvertProcAcs.EndTransaction(true);
                    //        //MessageBox.Show("OK");
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                    //            "�󕥏������I�����܂����B", 0, MessageBoxButtons.OK);
                    //    }
                    //    else
                    //    {
                    //        _ConvertProcAcs.EndTransaction(false);
                    //        //MessageBox.Show("FAILED");
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    //            "�󕥏����Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (!(ex is RemotingException))
                    //    {
                    //        _ConvertProcAcs.EndTransaction(false);
                    //        //MessageBox.Show("FAILED");
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    //            "�󕥏����Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                    //    }
                    //}
                    break;
                //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                case "Button_Wait":
                    IsStartWaitFlg = true;
                    if (ValidateInput())
                    {
                        IsStartWaitFlg = false;
                        PMKHN08000UB wait = new PMKHN08000UB(this.txtDir.Text, GetSelectedRows());
                        if (DialogResult.OK == wait.ShowDialog())
                        {
                            
                            this.wait_FileLst = new List<string>();
                            if (wait.FileLst != null)
                            {
                                this.wait_FileLst.AddRange(wait.FileLst);
                            }
                            this.wait_SelModelType = wait.SelModelType;
                            if(ValidateInput())
                            //-----Add Start 2012/11/28 zhangy3 ----->>>>>
                            {
                                SetCounter();
                                ConvertData();
                            }
                            //-----Add End  2012/11/28 zhangy3 -----<<<<<
                                //ConvertData();//Del 2012/11/28 zhangy3
                            ClearDataFromWait();
                        }
                    }
                    break;
                //-----Add End  2012/11/09 zhangy3 -----<<<<<

            }

        }
        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
        /// <summary>
        /// �ҋ@�𔻒f����
        /// </summary>
        /// <returns>FLG</returns>
        /// <remarks>
        /// <br>Note        : �ҋ@�̏�Ԃ𔻒f����B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private bool IsFromWait()
        {
            //�C���|�[�g�t�@�C���̃��W���b���𔻒f����[(0,1)�̓C���|�[�g�t�@�C���̃��W���b��]
            if (wait_SelModelType == -1)
                return false;
            else
                return true;
        }

        /// <summary>
        ///�@�R���o�[�g�Ώۂ̎擾����
        /// </summary>
        /// <returns>FLG</returns>
        /// <remarks>
        /// <br>Note        : �R���o�[�g�Ώۂ̎擾����B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private bool GetSelectedRows()
        {
            string query = "Deploy = '��' ";
            if (convFilter != ConvKindFilter.All) // �t�B���^�����O����Ă���ꍇ�͂��̃f�[�^�̂݃R���o�[�g����
            {
                query += "AND " + ConvertDataList.DefaultView.RowFilter;
            }
            // �R���o�[�g�Ώۂ̃e�[�u������
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);
            if (rows.Length > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// �ҋ@�̑I����Ԃ��폜����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ҋ@�̑I����Ԃ��폜����B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private void ClearDataFromWait()
        {
            this.wait_SelModelType = -1;
            this.wait_FileLst = null;
            ClearStatus();//Add 2012/11/28 zhangy3 
        }

        /// <summary>
        /// �I���t�@�C���ɂ���ăR���o�[�g�̑Ώۂ�I������
        /// </summary>
        /// <returns>�R���o�[�g�̑Ώۃ��X�g</returns>
        /// <br>Note        : �I���t�@�C���ɂ���ăR���o�[�g�̑Ώۂ�I������B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private ConvertList.ListRow[] GetRows()
        {
            // ------ Add Start 2012/11/28 zhangy3 ------>>>>> 
            if (InfoShowList.Count==0)
            {
                InfoShowList.Add(new List<string>(new string[] { "SALESSLIP", "SALESDETAIL", "SALESHISTORY", "SALESHISTDTL", "ACCEPTODRCAR", "CNVCARPARTS" }), false);
                InfoShowList.Add(new List<string>(new string[] { "DEPSITMAIN", "DEPSITDTL" }), false);
                InfoShowList.Add(new List<string>(new string[] { "STOCKSLIP", "STOCKDETAIL", "STOCKSLIPHIST", "STOCKSLHISTDTL" }), false);
                InfoShowList.Add(new List<string>(new string[] { "PAYMENTSLP", "PAYMENTDTL" }), false);
                InfoShowList.Add(new List<string>(new string[] { "STOCKADJUST", "STOCKADJUSTDTL" }), false);
            }
            // ------ Add End   2012/11/28 zhangy3 ------<<<<<
            List<ConvertList.ListRow> rows = new List<ConvertList.ListRow>();
            string tmp = string.Empty;
            Regex reg = null;
            Match mat = null;
            bool flg = false;
            foreach (ConvertList.ListRow row in ConvertDataList)
            {
                flg = false;                
                tmp = row.TableId.Trim().Replace("RF", "").ToUpper();//Add 2012/11/28 zhangy3 
                if (wait_FileLst.Exists(delegate(string x)
                {
                    x = x.ToUpper();
                    //PMNS_**_00.CSV
                    reg = new Regex(@"^PMNS_([a-zA-Z]+)(_\d{1,2})?.CSV$");
                    if (reg.IsMatch(x))
                    {
                        mat = reg.Match(x);
                        //tmp = row.TableId.Trim().Replace("RF", "").ToUpper();//Del 2012/11/28 zhangy3 
                        if (mat.Groups[1].Value.ToUpper().Equals(tmp))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                  
                }))
                {
                    flg = true;
                    row.Deploy = "��";
                    rows.Add(row);
                    // ------ Add Start 2012/11/28 zhangy3 ------>>>>>
                    SetInfoShowDic(tmp);
                    SetRowSelectByInfoShow(tmp);
                    // ------ Add End   2012/11/28 zhangy3 ------<<<<<
                }
                // ------ Add Start 2012/11/28 zhangy3 ------>>>>>
                else
                {
                    if (!GetCurStatusFromInfoShowDic(tmp))
                    {
                        row.Deploy = "";
                    }
                }
                // ------ Add End  2012/11/28 zhangy3 ------<<<<<

                /* ------ Del Start 2012/11/28 zhangy3 ------>>>>>
                if (mat != null && flg == true)
                {
                    switch (mat.Groups[1].Value.ToUpper())
                    {
                        case "SALESSLIP":
                        case "SALESDETAIL":
                        case "SALESHISTORY":
                        case "SALESHISTDTL":
                        case "ACCEPTODRCAR":
                        case "CNVCARPARTS":
                            {
                                ConvertDataList.FindByTableId("SALESSLIPRF").Deploy = "��"; // ����f�[�^
                                ConvertDataList.FindByTableId("SALESDETAILRF").Deploy = "��"; // ���㖾�׃f�[�^
                                ConvertDataList.FindByTableId("SALESHISTORYRF").Deploy = "��"; // ���㗚���f�[�^
                                ConvertDataList.FindByTableId("SALESHISTDTLRF").Deploy = "��"; // ���㗚�𖾍׃f�[�^
                                ConvertDataList.FindByTableId("ACCEPTODRCARRF").Deploy = "��"; // �󒍃}�X�^�i�ԗ��j
                                ConvertDataList.FindByTableId("CNVCARPARTSRF").Deploy = "��"; // ���q���i�f�[�^�i�R���o�[�g�j
                            }
                            break;
                        case "DEPSITMAIN":
                        case "DEPSITDTL":
                            {
                                ConvertDataList.FindByTableId("DEPSITMAINRF").Deploy = "��"; // �����f�[�^
                                ConvertDataList.FindByTableId("DEPSITDTLRF").Deploy = "��"; // �������׃f�[�^
                            }
                            break;
                        case "STOCKSLIP":
                        case "STOCKDETAIL":
                        case "STOCKSLIPHIST":
                        case "STOCKSLHISTDTL":
                            {
                                ConvertDataList.FindByTableId("STOCKSLIPRF").Deploy = "��"; // �d���f�[�^
                                ConvertDataList.FindByTableId("STOCKDETAILRF").Deploy = "��"; // �d�����׃f�[�^
                                ConvertDataList.FindByTableId("STOCKSLIPHISTRF").Deploy = "��"; // �d�������f�[�^
                                ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").Deploy = "��"; // �d�����𖾍׃f�[�^
                            }
                            break;
                        case "PAYMENTSLP":
                        case "PAYMENTDTL":
                            {
                                ConvertDataList.FindByTableId("PAYMENTSLPRF").Deploy = "��"; // �x���f�[�^
                                ConvertDataList.FindByTableId("PAYMENTDTLRF").Deploy = "��"; // �x�����׃f�[�^
                            }
                            break;
                        case "STOCKADJUST":
                        case "STOCKADJUSTDTL":
                            {
                                ConvertDataList.FindByTableId("STOCKADJUSTRF").Deploy = "��"; // �݌ɒ����f�[�^
                                ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").Deploy = "��"; // �݌ɒ������׃f�[�^
                            }
                            break;
                    }
                }                
                ------ Del End  2012/11/28 zhangy3 ------<<<<<*/
                
            }
            SetCounter();
            return rows.ToArray();
        }
        //-----Add End  2012/11/09 zhangy3 -----<<<<<
        // ------ Add Start 2012/11/28 zhangy3 ------>>>>>
        /// <summary>
        /// ���X�g�̏�Ԃɂ���ĉ�ʂ̍���ݒ肷��
        /// </summary>
        /// <param name="tmp">�e�b�u����</param>
        /// <remarks>
        /// <br>Note        : ���X�g�̏�Ԃɂ���ĉ�ʂ̍���ݒ肷��B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private void SetRowSelectByInfoShow(string tmp)
        {
            foreach (List<string> key in InfoShowList.Keys)
            {
                if (key.Exists(delegate(string x)
                {
                    if (x.Equals(tmp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    key.ForEach(delegate(string x)
                    {

                        ConvertDataList.FindByTableId(x + "RF").Deploy = "��";
                    });
                }
            }
        }

        /// <summary>
        /// �t�@�C���̓��e�ɂ���ă��X�g�̏�Ԃ�ݒ肷��
        /// </summary>
        /// <param name="tmp">�t�@�C���̓��e</param>
        /// <remarks>
        /// <br>Note        : �t�@�C���̓��e�ɂ���ă��X�g�̏�Ԃ�ݒ肷��B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private void SetInfoShowDic(string tmp)
        {
            Dictionary<List<string>, bool> dicTmp = new Dictionary<List<string>, bool>();
            foreach (List<string> key in InfoShowList.Keys)
            {
                if (key.Exists(delegate(string x)
                {
                    if (x.Equals(tmp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    dicTmp.Add(key, true);
                }
                else
                {
                    dicTmp.Add(key, InfoShowList[key]);
                }
            }
            InfoShowList = dicTmp;
        }

        /// <summary>
        /// ���X�g�̏�Ԃ��擾����
        /// </summary>
        /// <param name="tmp">�t�@�C���̓��e</param>
        /// <remarks>
        /// <br>Note        : �t�@�C���̓��e�ɂ���ă��X�g�̏�Ԃ�ݒ肷��B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private bool GetCurStatusFromInfoShowDic(string tmp)
        {
            foreach (List<string> key in InfoShowList.Keys)
            {
                if (key.Exists(delegate(string x)
                {
                    if (x.Equals(tmp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    return InfoShowList[key];
                }
            }
            return false;
        }

        /// <summary>
        /// ���X�g�̏�Ԃ��N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �t�@�C���̓��e�ɂ���ă��X�g�̏�Ԃ�ݒ肷��B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private void ClearStatus()
        {
            Dictionary<List<string>, bool> dicTmp = new Dictionary<List<string>, bool>();
            foreach (List<string> key in InfoShowList.Keys)
            {
                dicTmp.Add(key, false);
            }
            InfoShowList = dicTmp;
        }
        // ------ Add End   2012/11/28 zhangy3 ------<<<<<
       
        /// <summary>
        /// ���̓o���f�[�V��������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: PM.NS�̃C���|�[�g���ɑҋ@���[�h��ǉ���PM7SP���̏I���t�@�C�����Ď����Ď����Ŏ�荞�߂�悤�ɂ��܂��B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012.11.09</br>
        /// </remarks>
        private bool ValidateInput()
        {
            #region [ �o���f�[�V�������� ]
            if (txtDir.Text == string.Empty)
            {
                //MessageBox.Show("�R���o�[�g���i�[�t�H���_����͂��ĉ������B", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�R���o�[�g���i�[�t�H���_����͂��ĉ������B", 0, MessageBoxButtons.OK);
                txtDir.Focus();
                return false;
            }
            if (Directory.Exists(txtDir.Text) == false)
            {
                //MessageBox.Show("�f�B���N�g�������݂��܂���B", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�w��̺��ްČ��i�[̫��ނ͑��݂��܂���B", 0, MessageBoxButtons.OK);
                return false;
            }
            
            if (txtLogDir.Text == string.Empty)
            {
                txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
            }
            else
            {
                if (txtDir.Text == txtLogDir.Text)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                    "�G���[���O�i�[̫��ނ̓R���o�[�g��CSV�i�[̫��ނƈႤ�t�H���_�ɂ��ĉ������B", 0, MessageBoxButtons.OK);
                    return false;
                }
                if (txtLogDir.Text != Path.Combine(txtDir.Text, "ConvertErrorLog")
                    && Directory.Exists(txtLogDir.Text) == false)
                {
                    DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                    "�w��̴װ۸ފi�[̫��ނ͑��݂��܂���B\r\n̫��ނ��쐬���܂����H", 0, MessageBoxButtons.YesNo);
                    if (ret == DialogResult.No)
                    {
                        txtLogDir.Select();
                        return false;
                    }
                    try
                    {
                        Directory.CreateDirectory(txtLogDir.Text);
                    }
                    catch
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                    "�w���̫��ނ̍쐬�Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            //�ҋ@�����A�R���o�[�g�Ώۂ��`�F�b�N���Ȃ�
            if (IsStartWaitFlg)
                return true;
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            string query = "Deploy = '��' ";
            if (convFilter != ConvKindFilter.All) // �t�B���^�����O����Ă���ꍇ�͂��̃f�[�^�̂݃R���o�[�g����
            {
                query += "AND " + ConvertDataList.DefaultView.RowFilter;
            }
            // �R���o�[�g�Ώۂ̃e�[�u������
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);

            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            //�ҋ@���A���̃`�F�b�N�̕K�v���Ȃ�
            if (!IsFromWait())
            {
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            if (rows.Length == 0)
            {
                //MessageBox.Show("�R���o�[�g�Ώۂ�I��ŉ������B", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�R���o�[�g�Ώۂ�I��ŉ������B", 0, MessageBoxButtons.OK);
                return false;
            }
            }//Add 2012/11/09 zhangy3

            if ((rows.Length == 1) && (rows[0].TableId == "STOCKACPAYHISTRF"))
            {
            }
            else
            {
                if (Directory.GetFiles(txtDir.Text, "*.csv", SearchOption.TopDirectoryOnly).Length == 0)
                {
                    // 2009/11/17 Add >>>
                    bool truncateFlg = false;
                    for (int i = 0; i < rows.Length; i++)
                    {
                        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                        //�t�@�C�����Ȃ����A�R���o�[�g�Ώۂ��폜����
                        if (IsFromWait())
                            rows[i].Deploy = "";
                        else
                        {
                            if (rows[i].TruncateFlg == true)
                            {
                                // 1�ł��폜�Ώۂ�����Ȃ�폜�������s�����m�F����
                                truncateFlg = true;
                                break;
                            }
                        }
                        //-----Add End   2012/11/09 zhangy3 -----<<<<<
                        /*-----Del Start 2012/11/09 zhangy3 ----->>>>>
                        if (rows[i].TruncateFlg == true)
                        {
                            // 1�ł��폜�Ώۂ�����Ȃ�폜�������s�����m�F����
                            truncateFlg = true;
                            break;
                        }
                         *-----Del Start 2012/11/09 zhangy3 ----->>>>> */
                    }
                    //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                    //�������Ȃ�
                    if (IsFromWait())
                        return false;
                    //-----Add End   2012/11/09 zhangy3 -----<<<<<
                    if (truncateFlg == false)
                    {
                        // 2009/11/17 Add <<<
                        //MessageBox.Show("�f�B���N�g�����ɃR���o�[�g���t�@�C�������݂��܂���B", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                        "�f�B���N�g�����ɃR���o�[�g���t�@�C�������݂��܂���B", 0, MessageBoxButtons.OK);
                        return false;
                        // 2009/11/17 Add >>>
                    }
                    else
                    {
                        DialogResult resurt = DialogResult.OK;
                        resurt = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                        "�f�B���N�g�����ɃR���o�[�g���t�@�C�������݂��܂���B\n�폜�Ώۂ̃f�[�^���폜���܂��B��낵���ł����H", 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                        if (resurt == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // 2009/11/17 Add <<<

                }
            }

            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            //�C���|�[�g�t�@�C���̃��W���b����1���A�R���o�[�g�Ώۂ�ݒ肷��
            if (IsFromWait() && wait_SelModelType == 1)
            {
                rows = GetRows();
                if (rows.Length == 0)
                    return false;
            }
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------>>>>>
            for (int i = 0; i < rows.Length; i++)
            {
                if ((rows[i].TableId == "STOCKMOVERF") || (rows[i].TableId == "STOCKACPAYHISTRF"))
                {
                    string[] files = Directory.GetFiles(txtDir.Text, "PMNS_STOCKMOVE*.csv", SearchOption.TopDirectoryOnly);

                    if (files.Length > 1)
                    {
                        /* -----Del Start 2012/11/09 zhangy3 ----->>>>>
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�Ώۃt�H���_���ɍ݌Ɉړ��f�[�^���������݂��܂��B" + "\r\n" + 
                                "�Ώۃt�H���_����ɂ��āAPM7�ō쐬����CSV�t�@�C�����ēx�R�s�[���ĉ������B", 0, MessageBoxButtons.OK);
                        return false;
                         * -----Del End   2012/11/09 zhangy3 -----<<<<<*/
                        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                        //�ҋ@���A�݌Ɉړ��f�[�^�̑Ώۂ�I�����Ȃ��ɂ���
                        if (IsFromWait())
                        {
                            rows[i].Deploy = "";
                        }
                        else
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�Ώۃt�H���_���ɍ݌Ɉړ��f�[�^���������݂��܂��B" + "\r\n" +
                                "�Ώۃt�H���_����ɂ��āAPM7�ō쐬����CSV�t�@�C�����ēx�R�s�[���ĉ������B", 0, MessageBoxButtons.OK);
                            return false;
                        }
                        //-----Add End   2012/11/09 zhangy3 -----<<<<<
                    }
                }
            }
            // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------<<<<<

            return true;
            #endregion
        }

        /// <summary>
        /// �R���o�[�g����
        /// </summary>
        private void ConvertData()
        {
            // --- ADD 2011/09/06---------->>>>>
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�R���o�[�g�����J�n", "");
            // --- ADD 2011/09/06----------<<<<<

            bool noErrorFlg = true;
            string query = "Deploy = '��' ";
            string table = string.Empty;
            ConvertList.ListRow rowParent = null;
            ConvertDataList.AcceptChanges();
            if (convFilter != ConvKindFilter.All) // �t�B���^�����O����Ă���ꍇ�͂��̃f�[�^�̂݃R���o�[�g����
            {
                query = string.Format("{0} AND ConvKind = {1}", query, (int)convFilter);
            }
            // �R���o�[�g�Ώۂ̃e�[�u������
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);
            if (rows.Length == 0)
                return;

            cancelFlg = false;
            _progressForm = new SFCMN00299CA();
            _progressForm.DispCancelButton = true;
            _progressForm.CancelButtonClick += new EventHandler(this.CancelButtonClick);

            _progressForm.Title = "�R���o�[�g��";
            _progressForm.Message = "�����A�R���o�[�g���ł��D�D�D";
            FileStream fs = null;
            try
            {
                for (int ind = 0; ind < rows.Length; ind++)
                {
                    rows[ind].ReadDataCnt = 0; // ���[�h�J�E���^�N���A
                    rows[ind].WriteDataCnt = 0; // ���C�g�J�E���^�N���A
                    rows[ind].Result = string.Empty; // �������ʃN���A
                    rows[ind].StartTm = string.Empty;
                    rows[ind].EndTm = string.Empty;
                }

                _progressForm.Show(this);
                // �I�����ꂽ�e�[�u�����R���o�[�g�������s���B
                int i = 0;
                int status = 0;
                for (int procCnt = 0; i < rows.Length; i++)
                {
                    // --- ADD 2011/09/06---------->>>>>
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog,
                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, rows[i].TableNm + "�����J�n", "");
                    // --- ADD 2011/09/06----------<<<<<
                    try
                    {
                        ReDrawGrid();
                        lblCnt.Text = string.Format("���������F{0} �^ �I�������F{1}", procCnt, selectedCnt);
                        Refresh();
                        if (rows[i].TableId == "STOCKACPAYHISTRF") // �݌Ɏ󕥂̃R���o�[�g��
                        {
                            // --- CHG 2009/01/26 ��QID:10498�Ή�------------------------------------------------------>>>>>
                            //StockAcPayHistInfoProc(rows[i]);
                            status = StockAcPayHistInfoProc(rows[i]);
                            if (status == 1)
                            {
                                procCnt++;
                                lblCnt.Text = string.Format("���������F{0} �^ �I�������F{1}", procCnt, selectedCnt);
                            }
                            // --- CHG 2009/01/26 ��QID:10498�Ή�------------------------------------------------------<<<<<
                        }
                        else // ��ʂ�CSV����̃R���o�[�g��
                        {
                            ArrayList lstData = null;
                            int readCnt = 0;
                            int updateCnt = 0;
                            table = rows[i].TableId.Replace("RF", "");
                            // --- CHG 2009/02/27 ��QID:12043�Ή�------------------------------------------------------>>>>>
                            //string pattern = string.Format("PMNS_{0}*.csv", table);
                            string pattern;
                            if (rows[i].TableId == "ACCEPTODRRF")
                            {
                                pattern = string.Format("PMNS_{0}_*.csv", table);
                            }
                            else
                            {
                                pattern = string.Format("PMNS_{0}*.csv", table);
                            }
                            // --- CHG 2009/02/27 ��QID:12043�Ή�------------------------------------------------------<<<<<
                            string[] files = Directory.GetFiles(txtDir.Text, pattern, SearchOption.TopDirectoryOnly);
                            //string errLogFolder = Path.Combine(txtDir.Text, "ConvertErrorLog");
                            string errMsg = string.Empty;

                            rowParent = GetParentRow(table);
                            if (rowParent != null && noErrorFlg == false) // �Z�ߏ������G���[���������ꍇ���̎q�����͂��Ȃ�
                            {
                                continue;
                            }

                            if (cancelFlg)
                            {
                                cancelFlg = false;
                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                break;
                            }
                            if (files.Length > 0)
                            {
                                //rows[i].ReadDataCnt = 0; // ���[�h�J�E���^�N���A
                                //rows[i].WriteDataCnt = 0; // ���C�g�J�E���^�N���A
                                //rows[i].Result = string.Empty; // �������ʃN���A
                                //rows[i].EndTm = string.Empty;
                                rows[i].StartTm = DateTime.Now.ToString("HH:mm:ss");
                                Refresh();
                                if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                {
                                    noErrorFlg = true;
                                }
                                status = _ConvertProcAcs.BeginTransaction(); // �e�[�u�����̃g�����U�N�V����
                                if (status != 0)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, "�g�����U�N�V�����J�n�Ɏ��s���܂����B", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = "�W�J���s[�g�����U�N�V�����J�n�Ɏ��s���܂����B]";
                                    rows[i].PrevResult = -1;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.PrevResult = rows[i].PrevResult;
                                        noErrorFlg = false;
                                    }
                                    else if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                    {
                                        noErrorFlg = false;
                                    }
                                    break;
                                    //_ConvertProcAcs.EndTransaction(false);
                                }
                                int j = 0;
                                #region [ �e�[�u���̃t�@�C�����̃R���o�[�g���� ]
                                for (j = 0; j < files.Length; j++)
                                {
                                    #region [ �t�@�C���ǂݍ��� ]
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�t�@�C���ǂݍ��݊J�n", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    if (files[j][files[j].ToUpper().IndexOf(table) + table.Length] != '.'
                                        && files[j][files[j].ToUpper().IndexOf(table) + table.Length] != '_')
                                        continue;
                                    lstData = new ArrayList();
                                    fs = new FileStream(files[j], FileMode.Open, FileAccess.Read, FileShare.Read);
                                    StreamReader sr = new StreamReader(fs, Encoding.Default);
                                    int cnt = 0;
                                    bool truncateFlg = rows[i].TruncateFlg;
                                    if (j > 0) // CSV�t�@�C������������ꍇ��2�ڂ���͍폜���Ȃ����߁B
                                        truncateFlg = false;
                                    do
                                    {
                                        string data = sr.ReadLine();
                                        if (string.IsNullOrEmpty(data) == false)
                                            lstData.Add(data);
                                        if (string.IsNullOrEmpty(data) == false && data.Length * lstData.Count >= 50000000) // �ǂݍ��񂾕�����50MB�𒴂���ƈ�U�R���o�[�g�������s���āA�ǂݍ��݂𑱂��B
                                        {
                                            readCnt += lstData.Count;
                                            rows[i].ReadDataCnt = readCnt;
                                            Thread.Sleep(0);
                                            gridConvData.Refresh();
                                            Refresh();

                                            isRemoteOnProcess = true;
                                            status = _ConvertProcAcs.DeployConvertData(rows[i].TableId, truncateFlg, ref lstData, out cnt, out errMsg);
                                            truncateFlg = false; // �����s���Ă���͍폜�t���O�����Z�b�g���Ă����B
                                            isRemoteOnProcess = false;
                                            if (lstData.Count > 0)
                                            {
                                                string errLogFileNm = files[j].Substring(files[j].LastIndexOf('\\') + 1);
                                                errLogFileNm = errLogFileNm.Insert(errLogFileNm.IndexOf('.'), "_FailedData");
                                                WriteErrorLog(lstData, errLogFileNm);
                                                errMsg = string.Format("�G���[���O{0}���m�F���ĉ������B", errLogFileNm);
                                            }
                                            if (cancelFlg)
                                            {
                                                cancelFlg = false;
                                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                                break;
                                            }

                                            updateCnt += cnt;
                                            rows[i].WriteDataCnt = updateCnt;
                                            lstData.Clear();
                                            lstData = new ArrayList();
                                            if (status != 0)
                                                break;

                                        }
                                    } while (sr.EndOfStream == false);
                                    fs.Close();

                                    if (cancelFlg)
                                    {
                                        cancelFlg = false;
                                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                        break;
                                    }

                                    readCnt += lstData.Count;
                                    rows[i].ReadDataCnt = readCnt;
                                    Refresh();
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, 
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�t�@�C���ǂݍ��ݏI��", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    #endregion

                                    // 2009/11/17 >>>
                                    // ��̃t�@�C���������[�g�ɓn���č폜�������s��
                                    if (lstData.Count != 0 || j == 0)
                                    // 2009/11/17 <<<
                                    {
                                        isRemoteOnProcess = true;
                                        status = _ConvertProcAcs.DeployConvertData(rows[i].TableId, truncateFlg, ref lstData, out cnt, out errMsg);
                                        isRemoteOnProcess = false;
                                        if (lstData.Count > 0)
                                        {
                                            string errLogFileNm = files[j].Substring(files[j].LastIndexOf('\\') + 1);
                                            errLogFileNm = errLogFileNm.Insert(errLogFileNm.IndexOf('.'), "_FailedData");
                                            WriteErrorLog(lstData, errLogFileNm);
                                            errMsg = string.Format("�G���[���O{0}���m�F���ĉ������B", errLogFileNm);
                                        }
                                        //if (cancelFlg)
                                        //{
                                        //    cancelFlg = false;
                                        //    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                        //    break;
                                        //}
                                    }
                                    updateCnt += cnt;
                                    rows[i].WriteDataCnt = updateCnt;
                                    if (status != 0)
                                        break;
                                }
                                #endregion
                                rows[i].EndTm = DateTime.Now.ToString("HH:mm:ss");

                                if (rowParent != null)
                                {
                                    rowParent.EndTm = rows[i].EndTm;
                                }
                                Refresh();
                                rows[i].WriteDataCnt = updateCnt;
                                if (status == 0)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, 
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�W�J����I�����܂����B", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<

                                    if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                    {
                                        rows[i].Result = string.Format("OK[{0}]", lstTblNm[table]);
                                    }
                                    else
                                    {
                                        rows[i].Result = "OK";
                                    }

                                    if (listChkExcpt.Contains(table) && errMsg != string.Empty)
                                    {
                                        rows[i].Result += "[" + errMsg + "]";
                                    }

                                    if (rows[i].TruncateFlg) // �폜���Ă���̃R���o�[�g�̏ꍇ
                                    {
                                        // --- CHG 2009/03/23 ��QID:12532�Ή�------------------------------------------------------>>>>>
                                        if (rows[i].TableId == "STOCKMOVERF")
                                        {
                                            if (files.Length > 0)
                                            {
                                                // �ǂ����CSV����R���o�[�g���������f�ł��Ȃ����߁A�����I�ɒl���Z�b�g
                                                if (files[0] == txtDir.Text + "\\" + "PMNS_StockMove_Normal.CSV")
                                                {
                                                    rows[i].PrevResult = 10;
                                                }
                                                else
                                                {
                                                    rows[i].PrevResult = 100;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            rows[i].PrevResult = j; // �O����s�J�E���^���㏑������
                                        }
                                        // --- CHG 2009/03/23 ��QID:12532�Ή�------------------------------------------------------<<<<<
                                    }
                                    else
                                    {
                                        // --- CHG 2009/03/23 ��QID:12532�Ή�------------------------------------------------------>>>>>
                                        if (rows[i].TableId == "STOCKMOVERF")
                                        {
                                            if (files.Length > 0)
                                            {
                                                // �ǂ����CSV����R���o�[�g���������f�ł��Ȃ����߁A�����I�ɒl���Z�b�g
                                                if (files[0] == txtDir.Text + "\\" + "PMNS_StockMove_Normal.CSV")
                                                {
                                                    rows[i].PrevResult = 10;
                                                }
                                                else
                                                {
                                                    rows[i].PrevResult = 100;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            rows[i].PrevResult += j; // �O����s�J�E���^�ɍ���̃J�E���^�𑫂��B
                                        }
                                        // --- CHG 2009/03/23 ��QID:12532�Ή�------------------------------------------------------<<<<<
                                    }

                                    if (rowParent != null && noErrorFlg)
                                    {
                                        //if (table == "CNVCARPARTS" || table == "DEPSITDTL" || table == "STOCKSLHISTDTL"
                                        //     || table == "PAYMENTDTL" || table == "STOCKADJUSTDTL")
                                        if (listLastTbl.Contains(table))
                                        {
                                            rowParent.Result = "OK";
                                        }
                                        else
                                        {
                                            rowParent.Result = string.Format("OK[{0}]", rows[i].TableNm); //rows[i].Result;
                                        }
                                        rowParent.ReadDataCnt += rows[i].ReadDataCnt;
                                        rowParent.WriteDataCnt += rows[i].WriteDataCnt;
                                    }
                                    rows[i].Deploy = string.Empty; // �R���o�[�g�f�[�^�W�J����I�����@�I����ԉ���
                                    _ConvertProcAcs.EndTransaction(true);
                                    if (rowParent == null && lstTblNm.ContainsKey(table) == false)
                                        procCnt++;
                                    else if (rowParent != null && listLastTbl.Contains(table))
                                        procCnt++;
                                    lblCnt.Text = string.Format("���������F{0} �^ �I�������F{1}", procCnt, selectedCnt);
                                    Refresh();
                                }
                                else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, "�W�J���s[�L�����Z������܂����B]", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = "�W�J���s[�L�����Z������܂����B]";
                                    //if (rows[i].TruncateFlg)
                                    //    rows[i].PrevResult = 0;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.EndTm = rows[i].EndTm;
                                        rowParent.Deploy = rows[i].Deploy;
                                    }
                                    _ConvertProcAcs.EndTransaction(false);
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                                        "�R���o�[�g�����̓L�����Z������܂����B", 0, MessageBoxButtons.OK);
                                    break;
                                }
                                else
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, string.Format("�W�J���s[{0}]", errMsg), string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = string.Format("�W�J���s[{0}]", errMsg);
                                    //rows[i].PrevResult = -1;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.EndTm = rows[i].EndTm;
                                        rowParent.PrevResult = rows[i].PrevResult;
                                        rowParent.Deploy = rows[i].Deploy;
                                        noErrorFlg = false;
                                    }
                                    else if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                    {
                                        noErrorFlg = false;
                                    }
                                    _ConvertProcAcs.EndTransaction(false);
                                }
                            }
                            else
                            {
                                // 2009/11/17 Del >>>
                                // �S�Ẵt�@�C���ɑ΂��đ��݂��Ȃ��Ă��폜�������s���悤�ɏC��
                                //// --- ADD 2009/03/02 ��QID:12051�Ή�------------------------------------------------------>>>>>
                                //// ���q�Ǘ��̓I�v�V�����̂��߁A�t�@�C�������݂��Ȃ��Ă��G���[�Ƃ��Ȃ�
                                //if (rows[i].TableId == "CNVCARPARTSRF")
                                //{
                                //    if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                //    {
                                //        rows[i].Result = string.Format("OK[{0}]", lstTblNm[table]);
                                //    }
                                //    else
                                //    {
                                //        rows[i].Result = "OK";
                                //    }

                                //    if (listChkExcpt.Contains(table) && errMsg != string.Empty)
                                //    {
                                //        rows[i].Result += "[" + errMsg + "]";
                                //    }

                                //    if (rowParent != null && noErrorFlg)
                                //    {
                                //        if (listLastTbl.Contains(table))
                                //        {
                                //            rowParent.Result = "OK";
                                //        }
                                //        else
                                //        {
                                //            rowParent.Result = string.Format("OK[{0}]", rows[i].TableNm);
                                //        }
                                //        rowParent.ReadDataCnt += rows[i].ReadDataCnt;
                                //        rowParent.WriteDataCnt += rows[i].WriteDataCnt;
                                //    }
                                //    rows[i].Deploy = string.Empty; // �R���o�[�g�f�[�^�W�J����I�����@�I����ԉ���
                                //    _ConvertProcAcs.EndTransaction(true);
                                //    if (rowParent == null && lstTblNm.ContainsKey(table) == false)
                                //        procCnt++;
                                //    else if (rowParent != null && listLastTbl.Contains(table))
                                //        procCnt++;
                                //    lblCnt.Text = string.Format("���������F{0} �^ �I�������F{1}", procCnt, selectedCnt);
                                //    Refresh();

                                //    continue;
                                //}
                                //// --- ADD 2009/03/02 ��QID:12051�Ή�------------------------------------------------------<<<<<
                                // 2009/11/17 Del <<<

                                // 2009/11/17 Del >>>
                                //rows[i].Result = "�W�J���s[�R���o�[�g���t�@�C�������݂��܂���B]";
                                //if (rowParent != null)
                                //{
                                //    rowParent.Result = rows[i].Result;
                                //    noErrorFlg = false;
                                //}
                                //else if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                //{
                                //    noErrorFlg = false;
                                //}
                                // 2009/11/17 Del <<<
                                // 2009/11/17 Add >>>
                                rows[i].StartTm = DateTime.Now.ToString("HH:mm:ss");
                                bool truncateFlg = rows[i].TruncateFlg;
                                int cnt = 0;
                                status = _ConvertProcAcs.BeginTransaction(); // �e�[�u�����̃g�����U�N�V����
                                if (status != 0)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, "�W�J���s[�g�����U�N�V�����J�n�Ɏ��s���܂����B]", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = "�W�J���s[�g�����U�N�V�����J�n�Ɏ��s���܂����B]";
                                    rows[i].PrevResult = -1;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.PrevResult = rows[i].PrevResult;
                                        noErrorFlg = false;
                                    }
                                    else if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                    {
                                        noErrorFlg = false;
                                    }
                                    break;
                                    //_ConvertProcAcs.EndTransaction(false);
                                }
                                if (truncateFlg == true)
                                {
                                    isRemoteOnProcess = true;
                                    status = _ConvertProcAcs.DeployConvertData(rows[i].TableId, truncateFlg, ref lstData, out cnt, out errMsg);
                                    isRemoteOnProcess = false;
                                }
                                updateCnt += cnt;
                                rows[i].WriteDataCnt = updateCnt;
                                rows[i].EndTm = DateTime.Now.ToString("HH:mm:ss");
                                if (status == 0)
                                {
                                    if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                                    {
                                        rows[i].Result = string.Format("OK[{0}]", lstTblNm[table]);
                                    }
                                    else
                                    {
                                        rows[i].Result = "OK";
                                    }

                                    if (listChkExcpt.Contains(table) && errMsg != string.Empty)
                                    {
                                        rows[i].Result += "[" + errMsg + "]";
                                    }

                                    if (rowParent != null && noErrorFlg)
                                    {
                                        if (listLastTbl.Contains(table))
                                        {
                                            rowParent.Result = "OK";
                                        }
                                        else
                                        {
                                            rowParent.Result = string.Format("OK[{0}]", rows[i].TableNm);
                                        }
                                        rowParent.ReadDataCnt += rows[i].ReadDataCnt;
                                        rowParent.WriteDataCnt += rows[i].WriteDataCnt;
                                    }

                                    rows[i].Deploy = string.Empty; // �R���o�[�g�f�[�^�W�J����I�����@�I����ԉ���
                                    _ConvertProcAcs.EndTransaction(true);
                                    if (rowParent == null && lstTblNm.ContainsKey(table) == false)
                                        procCnt++;
                                    else if (rowParent != null && listLastTbl.Contains(table))
                                        procCnt++;
                                    lblCnt.Text = string.Format("���������F{0} �^ �I�������F{1}", procCnt, selectedCnt);
                                    Refresh();
                                }
                                // 2009/11/17 Add <<<
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isRemoteOnProcess = false;
                        rows[i].EndTm = DateTime.Now.ToString("HH:mm:ss");
                        if (ex is RemotingException)
                        {
                            rows[i].Result = "�W�J���s[�����[�g�������G���[���������܂����B�B]";
                        }
                        else if (ex.Message.Contains("CSV") && ex.Message.Contains("�A�N�Z�X"))
                        {
                            rows[i].Result = ex.Message;
                        }
                        else
                        {
                            rows[i].Result = "�W�J���s[�������N���C�A���g���ŃG���[���������܂����B]";
                        }
                        //rows[i].PrevResult = -1;
                        if (rowParent != null)
                        {
                            rowParent.Result = rows[i].Result;
                            rowParent.EndTm = rows[i].EndTm;
                            rowParent.PrevResult = rows[i].PrevResult;
                            rowParent.Deploy = rows[i].Deploy;
                            noErrorFlg = false;
                        }
                        else if (lstTblNm.ContainsKey(table)) // �Z�ߏ����̐擪�e�[�u��
                        {
                            noErrorFlg = false;
                        }
                        _ConvertProcAcs.EndTransaction(false);

                        // --- ADD 2011/09/06---------->>>>>
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                            PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, rows[i].Result, string.Empty);
                        // --- ADD 2011/09/06----------<<<<<
                    }

                    // --- ADD 2011/09/06---------->>>>>
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, 
                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, rows[i].TableNm + "�����I��", "");
                    // --- ADD 2011/09/06----------<<<<<
                }
                if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {
                    for (; i < rows.Length; i++)
                    {
                        rows[i].RejectChanges();
                    }
                }
                // �Z�ߏ����̎q�s��e�s�Ɠ�����ԂƂ�����B
                for (int ind = 0; ind < lstInvisible.Count; ind++)
                {
                    ConvertList.ListRow rowChild = ConvertDataList.FindByTableId(lstInvisible[ind]);
                    rowParent = GetParentRow(rowChild.TableId.Replace("RF", ""));
                    rowChild.Deploy = rowParent.Deploy;
                }
                operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�R���o�[�g������XML�t�@�C���֕ۑ��J�n", ""); // ADD 2011/09/06
                // �R���o�[�g������XML�t�@�C���֕ۑ�
                configData.Tables[0].Clear();
                configData.Tables[0].Merge(ConvertDataList, false, MissingSchemaAction.Ignore);
                configData.WriteXml(ctCONFIGFILE);
                operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�R���o�[�g������XML�t�@�C���֕ۑ��I��", ""); // ADD 2011/09/06
            }
            catch { }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (_progressForm != null)
                {
                    _progressForm.Close();
                    //_progressForm.Dispose();
                    _progressForm = null;
                }
            }

            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�R���o�[�g�����I��", ""); // ADD 2011/09/06
        }

        private void ReDrawGrid()
        {
            int sz = gridConvData.Rows.Count;
            for (int i = 0; i < sz; i++)
            {
                if (gridConvData.Rows[i].Cells[ConvertDataList.DeployColumn.ColumnName].Value.Equals(""))
                    continue;
                if (string.Compare(gridConvData.Rows[i].Cells[ConvertDataList.StartTmColumn.ColumnName].Value.ToString(),
                    DateTime.Now.ToString("HH:mm:ss")) > 0)
                    continue;
                if (!gridConvData.Rows[i].Cells[ConvertDataList.ResultColumn.ColumnName].Value.Equals("")
                    && !gridConvData.Rows[i].Cells[ConvertDataList.ResultColumn.ColumnName].Value.Equals("OK"))
                    continue;

                gridConvData.Rows[i].Activate();
                gridConvData.Rows[i].Selected = true;
                break;

            }
        }

        /// <summary>
        /// �Z�߂ď�������e�[�u���Ȃ炻�̐e�e�[�u����Ԃ�
        /// </summary>
        /// <param name="table">�e�[�u��ID</param>
        /// <returns>null:�Z�ߏ����ΏۊO</returns>
        private ConvertList.ListRow GetParentRow(string table)
        {
            if (table == "SALESDETAIL" || table == "SALESHISTORY" || table == "SALESHISTDTL"
                                            || table == "ACCEPTODRCAR" || table == "CNVCARPARTS")
            {
                return ConvertDataList.FindByTableId("SALESSLIPRF");
            }
            if (table == "DEPSITDTL")
            {
                return ConvertDataList.FindByTableId("DEPSITMAINRF");
            }
            if (table == "STOCKDETAIL" || table == "STOCKSLIPHIST" || table == "STOCKSLHISTDTL")
            {
                return ConvertDataList.FindByTableId("STOCKSLIPRF");
            }
            if (table == "PAYMENTDTL")
            {
                return ConvertDataList.FindByTableId("PAYMENTSLPRF");
            }
            if (table == "STOCKADJUSTDTL")
            {
                return ConvertDataList.FindByTableId("STOCKADJUSTRF");
            }
            return null;
        }

        #region < CancelButtonClick >

        /// <summary>
        /// CancelButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            cancelFlg = true;

            _progressForm.Close();
            _progressForm = null;

            if (isRemoteOnProcess)
            {
                int status = _ConvertProcAcs.StopProcess();

                //if (status == 1)
                //{
                //    // �����̓X���b�h����TMsgDisp�͎g���Ȃ��B
                //    MessageBox.Show("�����𒆎~����O�ɏ������I������܂����B", "<���>" + Text,
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else if (status != 0)
                //{
                //    MessageBox.Show("�����𒆎~�o���܂���ł����B", "<����>" + Text, MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //}
            }
        }

        #endregion

        /// <summary>
        /// �݌Ɏ󕥃f�[�^����
        /// </summary>
        /// <param name="rowSAP">�݌Ɏ󕥍s</param>
        /// <returns>-1:�󕥐ݒ菈�����s/1:�󕥐ݒ菈������/0:�󕥐ݒ菈���Ȃ�</returns>
        private int StockAcPayHistInfoProc(ConvertList.ListRow rowSAP)
        {
            // --- ADD 2011/09/06---------->>>>>
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�݌Ɏ󕥃f�[�^����(StockAcPayHistInfoProc)�J�n", "");
            // --- ADD 2011/09/06----------<<<<<
            // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------>>>>>
            bool stockMoveNormalFlg = true;
            // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------<<<<<

            int ret = 0;
            int resultCnt;
            int status = 0;
            bool isComplete = true;
            for (int i = 0; i < lstSAPHistInfoChk.Count; i++)
            {
                ConvertList.ListRow row = ConvertDataList.FindByTableId(lstSAPHistInfoChk[i]);
                // --- CHG 2009/02/26 ��QID:12049�Ή�------------------------------------------------------>>>>>
                //if (row != null && row.PrevResult < row.CsvCount) // �����łȂ��ꍇ
                //{
                //    isComplete = false;
                //    rowSAP.ReadDataCnt = 0;
                //    rowSAP.WriteDataCnt = 0;
                //    rowSAP.Result = "���ɂȂ�e�[�u�����S�Đ��튮�����Ă���ēx�݌Ɏ󕥏������s���ĉ������B";
                //    rowSAP.PrevResult = -1;
                //    break;
                //}
                if (row != null) // �����łȂ��ꍇ
                {
                    switch (row.TableId)
                    {
                        case "SALESSLIPRF":
                        case "SALESDETAILRF":
                            {
                                if (row.PrevResult < 2)
                                {
                                    isComplete = false;
                                }
                                break;
                            }
                        case "SALESHISTORYRF":
                        case "SALESHISTDTLRF":
                        case "STOCKSLIPRF":
                        case "STOCKDETAILRF":
                        case "STOCKSLIPHISTRF":
                        case "STOCKSLHISTDTLRF":
                            {
                                if (row.PrevResult < 1)
                                {
                                    isComplete = false;
                                }
                                break;
                            }
                        // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------>>>>>
                        case "STOCKMOVERF":
                            {
                                if (row.PrevResult < row.CsvCount)
                                {
                                    isComplete = false;
                                }
                                if (row.PrevResult == 10)
                                {
                                    stockMoveNormalFlg = true;
                                }
                                else if (row.PrevResult == 100)
                                {
                                    stockMoveNormalFlg = false;
                                }
                                break;
                            }
                        // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------<<<<<
                        default:
                            {
                                if (row.PrevResult < row.CsvCount)
                                {
                                    isComplete = false;
                                }
                                break;
                            }
                    }
                    if (!isComplete)
                    {
                        rowSAP.ReadDataCnt = 0;
                        rowSAP.WriteDataCnt = 0;
                        rowSAP.Result = "���ɂȂ�e�[�u�����S�Đ��튮�����Ă���ēx�݌Ɏ󕥏������s���ĉ������B";
                        rowSAP.PrevResult = -1;
                        break;
                    }
                }
                // --- CHG 2009/02/26 ��QID:12049�Ή�------------------------------------------------------<<<<<
            }

            if (isComplete == false) // ���ɂȂ�f�[�^�̈ꕔ�ł������łȂ�
                return status;

            try
            {
                int i = 0;
                List<int> lstSource = new List<int>();
                rowSAP.StartTm = DateTime.Now.ToString("HH:mm:ss");
                if (rowSAP.TruncateFlg)
                    _ConvertProcAcs.BeginTransaction();
                if (rowSAP.TruncateFlg)
                    lstSource.Add(-1); // �폜�����p�t���O��ݒ肷��
                for (i = 0; i < 7; i++)
                {
                    if (i == 2) // �d���f�[�^����͍݌Ɏ󕥏������Ȃ��B
                        continue;

                    // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------>>>>>
                    if (i == 4)
                    {
                        if (!stockMoveNormalFlg)
                        {
                            continue;
                        }
                    }
                    if (i == 6)
                    {
                        if (stockMoveNormalFlg)
                        {
                            continue;
                        }
                    }
                    // --- ADD 2009/03/23 ��QID:12532�Ή�------------------------------------------------------<<<<<
                    lstSource.Add(i);
                }

                status = _ConvertProcAcs.SetStockAcPayHist(LoginInfoAcquisition.EnterpriseCode, lstSource, out resultCnt);
                if (status == 0)
                {
                    _ConvertProcAcs.EndTransaction(true);
                    rowSAP.ReadDataCnt = resultCnt;
                    rowSAP.WriteDataCnt = resultCnt;
                    rowSAP.Result = "OK";
                    rowSAP.PrevResult = 1;
                    rowSAP.Deploy = string.Empty; // �R���o�[�g�f�[�^�W�J����I�����@�I����ԉ���
                    ret = 1;
                }
                else
                {
                    if (i < 6)
                        rowSAP.Result = string.Format("{0}����̍݌Ɏ󕥏��������s���܂����B", lstSAP[i]);
                    else
                        rowSAP.Result = "�݌Ɏ󕥏����Ɏ��s���܂����B";
                    rowSAP.ReadDataCnt = 0;
                    rowSAP.WriteDataCnt = 0;
                    rowSAP.PrevResult = -1;
                    _ConvertProcAcs.EndTransaction(false);
                    ret = -1;
                }
                rowSAP.EndTm = DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                if (!(ex is RemotingException))
                {
                    _ConvertProcAcs.EndTransaction(false);
                }
                rowSAP.Result = "�݌Ɏ󕥏����Ɏ��s���܂����B";
                rowSAP.ReadDataCnt = 0;
                rowSAP.WriteDataCnt = 0;
                rowSAP.PrevResult = -1;
                ret = -1;

                operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�݌Ɏ󕥏����Ɏ��s���܂����B", ""); // ADD 2011/09/06
            }

            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�݌Ɏ󕥃f�[�^����(StockAcPayHistInfoProc)�I��", ""); // ADD 2011/09/06

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData">���s�����f�[�^���X�g</param>
        /// <param name="errLogFileNm">�쐬���郍�O�t�@�C����</param>
        /// <param name="errLogFolder">�G���[���O�ۑ��t�H���_</param>
        private void WriteErrorLog(ArrayList lstData, string errLogFileNm)
        {
            string errLogFolder = txtLogDir.Text;
            //string errLogFileNm = fileNm.Substring(fileNm.LastIndexOf('\\') + 1);
            //errLogFileNm = errLogFileNm.Insert(errLogFileNm.IndexOf('.'), "_FailedData");
            if (Directory.Exists(errLogFolder) == false)
                Directory.CreateDirectory(errLogFolder);
            StreamWriter writer = new StreamWriter(Path.Combine(errLogFolder, errLogFileNm), false, Encoding.Default);
            for (int i = 0; i < lstData.Count; i++)
            {
                writer.WriteLine(lstData[i]);
            }
            writer.Close();
        }
        # endregion

        # region �v���C�x�[�g���\�b�h(��ʐݒ�֘A)

        /// <summary>
        /// �c�[���o�[�̃A�C�R���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t���[���̃c�[���o�[�̐ݒ���s���܂��B</br>
        /// <br>Programer  : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void SettingToolbar()
        {
            //--------------------------------------------------------------
            // ���C���c�[���o�[
            //--------------------------------------------------------------
            // �C���[�W���X�g��ݒ肷��
            this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

            //// ���_�̃A�C�R���ݒ�
            //ToolbarsManager_Main.Tools["LabelTool_SectionTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            //// ���O�C���S���҂̃A�C�R���ݒ�
            //ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // �I���̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �m��̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["Button_Convert"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // �L�����Z���̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["Button_Cancel"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            // �ҋ@�̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["Button_Wait"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            //// �݌Ɏ󕥂̃A�C�R���ݒ�
            //ToolbarsManager_Main.Tools["Btn_StockAcPay"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;
        }

        # endregion

        #region [ �{�^���C�x���g���� ]
        private void uButton_DirGuide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.Description = "�R���o�[�g�f�[�^�̃t�H���_���w�肵�ĉ������B";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                txtDir.Text = dlg.SelectedPath;
                txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
                btn_ClearAll.Select();
            }
        }

        private void uBtn_DirGuide2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.Description = "�R���o�[�g���̃G���[���O���i�[����t�H���_���w�肵�ĉ������B";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                txtLogDir.Text = dlg.SelectedPath;
                btn_ClearAll.Select();
            }
        }

        /// <summary>
        /// [�S�ĉ���]�{�^�������C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
            lblCnt.Text = string.Empty;
            //SetCounter();
        }

        /// <summary>
        /// [�S�đI��]�{�^�������C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
            SetDeploy(true);
            SetCounter();
        }

        private void btn_SelectAll2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                ConvertDataList[i].Deploy = "��";
            }
            SetCounter();
        }

        private void btnDelUnchk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                if (ConvertDataList[i].TableId != "STOCKACPAYHISTRF")
                {
                    ConvertDataList[i].TruncateFlg = false;
                }
            }
        }

        private void btnDelChk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                ConvertDataList[i].TruncateFlg = true;
            }
        }

        /// <summary>
        /// �W�J�敪�ݒ�
        /// </summary>
        /// <param name="flg">true: �S�I��/false: �S����</param>
        private void SetDeploy(bool flg)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                if (flg)
                {
                    if (ConvertDataList[i].PrevResult < ConvertDataList[i].CsvCount)
                    {
                        ConvertDataList[i].Deploy = "��";
                        switch (ConvertDataList[i].TableId)
                        {
                            case "SALESSLIPRF": // ����E�󒍁E�ݏo�E���q�f�[�^
                                ConvertDataList.FindByTableId("SALESDETAILRF").Deploy = "��"; // ���㖾�׃f�[�^
                                ConvertDataList.FindByTableId("SALESHISTORYRF").Deploy = "��"; // ���㗚���f�[�^
                                ConvertDataList.FindByTableId("SALESHISTDTLRF").Deploy = "��"; // ���㗚�𖾍׃f�[�^
                                ConvertDataList.FindByTableId("ACCEPTODRCARRF").Deploy = "��"; // �󒍃}�X�^�i�ԗ��j
                                ConvertDataList.FindByTableId("CNVCARPARTSRF").Deploy = "��"; // ���q���i�f�[�^�i�R���o�[�g�j
                                break;
                            case "DEPSITMAINRF": // �����f�[�^
                                ConvertDataList.FindByTableId("DEPSITDTLRF").Deploy = "��"; // �������׃f�[�^
                                break;
                            case "STOCKSLIPRF": // �d���f�[�^
                                ConvertDataList.FindByTableId("STOCKDETAILRF").Deploy = "��"; // �d�����׃f�[�^
                                ConvertDataList.FindByTableId("STOCKSLIPHISTRF").Deploy = "��"; // �d�������f�[�^
                                ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").Deploy = "��"; // �d�����𖾍׃f�[�^
                                break;
                            case "PAYMENTSLPRF": // �x���f�[�^
                                ConvertDataList.FindByTableId("PAYMENTDTLRF").Deploy = "��"; // �x�����׃f�[�^
                                break;
                            case "STOCKADJUSTRF": // �݌ɒ����f�[�^
                                ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").Deploy = "��"; // �݌ɒ������׃f�[�^
                                break;
                        }
                    }
                }
                else
                {
                    ConvertDataList[i].Deploy = string.Empty;
                }
            }
        }

        private void btn_FilterMaster_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "ConvKind = 0 AND Visible = True"; // �R���o�[�g��ʂ� 0:�}�X�^
            Mode_Label.Text = "�}�X�^�\��";
            convFilter = ConvKindFilter.Master;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void btn_FilterData_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "ConvKind = 1 AND Visible = True"; // �R���o�[�g��ʂ� 1:�f�[�^
            Mode_Label.Text = "�f�[�^�\��";
            convFilter = ConvKindFilter.Data;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void btn_FilterJisseki_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "ConvKind = 2 AND Visible = True"; // �R���o�[�g��ʂ� 2:����
            Mode_Label.Text = "���ѕ\��";
            convFilter = ConvKindFilter.Jisseki;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void btn_NoFilter_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "Visible = True";
            Mode_Label.Text = "�S�\��";
            convFilter = ConvKindFilter.All;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

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

        #region [ �O���b�h�C�x���g���� ]
        private void gridConvData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            UltraGridBand band0 = e.Layout.Bands[0];
            //band0.UseRowLayout = true;            
            band0.Columns[ConvertDataList.TableIdColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.ConvKindColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.PrevResultColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.CsvCountColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.VisibleColumn.ColumnName].Hidden = true;

            //SetColInfo(band0, ConvertDataList.DeployColumn.ColumnName, 2, 0, 30);
            //SetColInfo(band0, ConvertDataList.TableNmColumn.ColumnName, 4, 0, 350);
            //SetColInfo(band0, ConvertDataList.TruncateFlgColumn.ColumnName, 13, 0, 40);
            //SetColInfo(band0, ConvertDataList.StartTmColumn.ColumnName, 15, 0, 100);
            //SetColInfo(band0, ConvertDataList.EndTmColumn.ColumnName, 19, 0, 100);
            //SetColInfo(band0, ConvertDataList.ReadDataCntColumn.ColumnName, 23, 0, 60);
            //SetColInfo(band0, ConvertDataList.WriteDataCntColumn.ColumnName, 26, 0, 60);
            //SetColInfo(band0, ConvertDataList.ResultColumn.ColumnName, 29, 0, 800);

            band0.Columns[ConvertDataList.DeployColumn.ColumnName].Width = 30;
            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Width = 350;
            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Width = 40;
            band0.Columns[ConvertDataList.StartTmColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.EndTmColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Width = 800;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;

            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
            band0.Columns[ConvertDataList.DeployColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Format = "###,###,##0";
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Format = "###,###,##0";

            //e.Layout.UseFixedHeaders = true;
            band0.Columns[ConvertDataList.DeployColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Header.Fixed = true;
            //band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.VisibleRows;
        }

        private void gridConvData_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetValue(e.Row);

            gridConvData.UpdateData();
        }

        private void gridConvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridConvData.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SetValue(gridConvData.ActiveRow);

                    gridConvData.UpdateData();

                    UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                }
                // ADD 2009/04/01 �s��Ή�[12898]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
                else if (e.KeyCode == Keys.Space)
                {
                    // [�폜]�J�����̒l��ݒ�
                    bool truncateFlag = (bool)this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value;
                    this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value = !truncateFlag;
                }
                // ADD 2009/04/01 �s��Ή�[12898]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<
            }
        }

        /// <summary>
        /// �I����ԍX�V����
        /// </summary>
        /// <param name="row"></param>
        private void SetValue(UltraGridRow row)
        {
            UltraGridCell cell = row.Cells[ConvertDataList.DeployColumn.ColumnName];
            string val = string.Empty;
            if (cell.Value.Equals("��"))
            {
                val = "";
            }
            else
            {
                val = "��";
            }
            cell.Value = val;

            // �Z�߂ď�������e�[�u���ɑ΂��鏈��
            switch (row.Cells[ConvertDataList.TableIdColumn.ColumnName].Value.ToString())
            {
                case "SALESSLIPRF": // ����E�󒍁E�ݏo�E���q�f�[�^
                    ConvertDataList.FindByTableId("SALESDETAILRF").Deploy = val; // ���㖾�׃f�[�^
                    ConvertDataList.FindByTableId("SALESHISTORYRF").Deploy = val; // ���㗚���f�[�^
                    ConvertDataList.FindByTableId("SALESHISTDTLRF").Deploy = val; // ���㗚�𖾍׃f�[�^
                    ConvertDataList.FindByTableId("ACCEPTODRCARRF").Deploy = val; // �󒍃}�X�^�i�ԗ��j
                    ConvertDataList.FindByTableId("CNVCARPARTSRF").Deploy = val; // ���q���i�f�[�^�i�R���o�[�g�j
                    break;
                case "DEPSITMAINRF": // �����f�[�^
                    ConvertDataList.FindByTableId("DEPSITDTLRF").Deploy = val; // �������׃f�[�^
                    break;
                case "STOCKSLIPRF": // �d���f�[�^
                    ConvertDataList.FindByTableId("STOCKDETAILRF").Deploy = val; // �d�����׃f�[�^
                    ConvertDataList.FindByTableId("STOCKSLIPHISTRF").Deploy = val; // �d�������f�[�^
                    ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").Deploy = val; // �d�����𖾍׃f�[�^
                    break;
                case "PAYMENTSLPRF": // �x���f�[�^
                    ConvertDataList.FindByTableId("PAYMENTDTLRF").Deploy = val; // �x�����׃f�[�^
                    break;
                case "STOCKADJUSTRF": // �݌ɒ����f�[�^
                    ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").Deploy = val; // �݌ɒ������׃f�[�^
                    break;
            }
            SetCounter();
        }

        private void gridConvData_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            bool val = !((bool)e.Cell.Value);
            e.Cell.Value = val;
            // �Z�߂ď�������e�[�u���ɑ΂��鏈��
            switch (e.Cell.Row.Cells[ConvertDataList.TableIdColumn.ColumnName].Value.ToString())
            {
                case "SALESSLIPRF": // ����E�󒍁E�ݏo�E���q�f�[�^
                    ConvertDataList.FindByTableId("SALESDETAILRF").TruncateFlg = val; // ���㖾�׃f�[�^
                    ConvertDataList.FindByTableId("SALESHISTORYRF").TruncateFlg = val; // ���㗚���f�[�^
                    ConvertDataList.FindByTableId("SALESHISTDTLRF").TruncateFlg = val; // ���㗚�𖾍׃f�[�^
                    ConvertDataList.FindByTableId("ACCEPTODRCARRF").TruncateFlg = val; // �󒍃}�X�^�i�ԗ��j
                    ConvertDataList.FindByTableId("CNVCARPARTSRF").TruncateFlg = val; // ���q���i�f�[�^�i�R���o�[�g�j
                    break;
                case "DEPSITMAINRF": // �����f�[�^
                    ConvertDataList.FindByTableId("DEPSITDTLRF").TruncateFlg = val; // �������׃f�[�^
                    break;
                case "STOCKSLIPRF": // �d���f�[�^
                    ConvertDataList.FindByTableId("STOCKDETAILRF").TruncateFlg = val; // �d�����׃f�[�^
                    ConvertDataList.FindByTableId("STOCKSLIPHISTRF").TruncateFlg = val; // �d�������f�[�^
                    ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").TruncateFlg = val; // �d�����𖾍׃f�[�^
                    break;
                case "PAYMENTSLPRF": // �x���f�[�^
                    ConvertDataList.FindByTableId("PAYMENTDTLRF").TruncateFlg = val; // �x�����׃f�[�^
                    break;
                case "STOCKADJUSTRF": // �݌ɒ����f�[�^
                    ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").TruncateFlg = val; // �݌ɒ������׃f�[�^
                    break;
            }
            if (gridConvData.Selected.Rows.Count == 0 || e.Cell.Row != gridConvData.Selected.Rows[0])
                e.Cell.Row.Selected = true;
            e.Cancel = true;
        }

        private void gridConvData_Enter(object sender, EventArgs e)
        {
            if (gridConvData.Selected.Rows.Count == 0)
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
        }

        private void gridConvData_Leave(object sender, EventArgs e)
        {
            gridConvData.Selected.Rows.Clear();
        }

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

        /// <summary>
        /// �����J�E���^�\��
        /// </summary>        
        private void SetCounter()
        {
            selectedCnt = 0;
            for (int i = 0; i < ConvertDataList.DefaultView.Count; i++)
            {
                ConvertList.ListRow row = ConvertDataList.DefaultView[i].Row as ConvertList.ListRow;
                //if (ConvertDataList[i].Deploy == "��" && ConvertDataList[i].Visible)
                //if (row.Deploy == "��")
                if (ConvertDataList.DefaultView[i]["Deploy"].Equals("��"))
                {
                    selectedCnt++;
                }
            }
            if (selectedCnt == 0)
            {
                lblCnt.Text = string.Empty;
            }
            else
            {
                lblCnt.Text = string.Format("�I�������F{0}", selectedCnt);
            }
            Refresh();
        }
        #endregion

        #region [ �t�H�[�J�X���� ]
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.NextCtrl == uButton_DirGuide)
            {
                if (txtDir.Text != string.Empty)
                {
                    txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
                    e.NextCtrl = btn_ClearAll;
                }
            }
            else if (e.NextCtrl == uBtn_DirGuide2)
            {
                if (txtLogDir.Text == string.Empty)
                {
                    if (txtDir.Text != string.Empty)
                    {
                        txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
                        e.NextCtrl = btn_ClearAll;
                    }
                }
                else
                {
                    e.NextCtrl = btn_ClearAll;
                }
            }
            else if (e.PrevCtrl == gridConvData)
            {
                if (gridConvData.ActiveRow != null)
                {
                    SetValue(gridConvData.ActiveRow);
                    gridConvData.UpdateData();

                    UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                    e.NextCtrl = gridConvData;
                }
            }
        }
        #endregion

    }
}