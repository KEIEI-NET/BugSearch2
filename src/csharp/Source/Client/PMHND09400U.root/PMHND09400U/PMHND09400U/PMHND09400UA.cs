//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�X�V�����i�蓮�j
// �v���O�����T�v   : ���i�o�[�R�[�h�X�V�����i�蓮�j�t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00  �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/09/20   �C�����e : �n���f�B�^�[�~�i���񎟑Ή��i�V�K�쐬�j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�o�[�R�[�h�X�V�����i�蓮�j�t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�X�V�̃��C���t�h�N���X�̒�`�Ǝ���</br>
    /// <br>Programmer : 30757�@���X�؁@�M�p</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    public partial class PMHND09400U : Form
    {
        #region �^�錾

        /// <summary>
        /// ���i�o�[�R�[�h�X�V�����i�蓮�j�t�h�Ǝ��̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum StatusCode
        {
              /// <summary>����</summary>
              Normal = 0
            , /// <summary>�n���f�B�[�^�[�~�i��OP�o�[�R�[�h�񋟃I�v�V��������</summary>
              OptPmHndBarcodeOfferInvalid = -1
            , /// <summary>�v���I�G���[</summary>
              Error = -1000
        };

        #endregion //�^�錾

        #region �萔��`

        /// <summary>
        /// �I�y���[�V�������O������F�N��
        /// </summary>
        private static readonly string OperationLogTextStart = "�N��";

        /// <summary>
        /// �I�y���[�V�������O������F�I��
        /// </summary>
        private static readonly string OperationLogTextEnd = "�I��"; 

        /// <summary>
        /// �o�[�R�[�h�X�V�敪�v�f������F���[�U�[�X�V�ȊO
        /// </summary>
        private static readonly string BarcodeUpdateKndNameWithoutUserUpdate = "���[�U�[�X�V�ȊO";

        /// <summary>
        /// �o�[�R�[�h�X�V�敪�v�f������F�S��
        /// </summary>
        private static readonly string BarcodeUpdateKndNameAll = "�S��";

        /// <summary>
        /// �i���_�C�A���O�^�C�g��
        /// </summary>
        private static readonly string ProcessingDialogTitleUpdate = "�X�V����";

        /// <summary>
        /// �i���_�C�A���O�\������
        /// </summary>
        private static readonly string ProcessingDialogMessageDefault = "���݁A�f�[�^���o�A�X�V���ł��c";

        /// <summary>
        /// �G���[���b�Z�[�W�F���o�^�����ރR�[�h����
        /// </summary>
        private static readonly string GoodsMGroupInfoNotExists = "���͂��ꂽ�����ރR�[�h�͑��݂��܂���B";

        /// <summary>
        /// �G���[���b�Z�[�W�F���o�^BL�R�[�h����
        /// </summary>
        private static readonly string BLCodeInfoNotExists = "���͂��ꂽBL�R�[�h�͑��݂��܂���B";

        /// <summary>
        /// �G���[���b�Z�[�W�F�������[�J�[�R�[�h����
        /// </summary>
        private static readonly string CannotSelectGenuineMaker = "�������[�J�[�͑I���ł��܂���B";

        /// <summary>
        /// �G���[���b�Z�[�W�F���[�J�[�͈͎w��s��
        /// </summary>
        private static readonly string ErrorTextIlligalMakerCodeRenge = "���[�J�[�͈͎̔w��Ɍ�肪����܂��B";

        /// <summary>
        /// �G���[���b�Z�[�W�F������������
        /// </summary>
        private static readonly string UpdateResultTextReadCountMaxOrver = "�����Ώۂ�2�����𒴂��܂����A������ύX���čēx�������s���Ă��������B";

        /// <summary>
        /// �G���[���b�Z�[�W�F�������s
        /// </summary>
        private static readonly string UpdateResultTextError = "���i�o�[�R�[�h�X�V�����Ɏ��s���܂����B";

        /// <summary>
        /// �����I�������b�Z�[�W
        /// </summary>
        private static readonly string UpdateResultTextNormal = "���i�o�[�R�[�h�X�V�������I�����܂����B";

        /// <summary>
        /// ���o�^�}�X�^�R�[�h���͎����̕�����
        /// </summary>
        private static readonly string NoRecodeInfoName = "���o�^";

        #endregion //�萔��`

        #region �����o�[�t�B�[���h

        /// <summary>���[�J�[�A�N�Z�X�N���X</summary>
        private MakerAcs GoodsMakerGuidAcs;

        /// <summary>�a�k���i�R�[�h�����K�C�h</summary>
        private BLGoodsCdAcs BlGoodsCdGuidAcs;

        /// <summary>�����ތ����K�C�h</summary>
        private GoodsGroupUAcs GoodsGroupUGuidAcs;

        /// <summary>���i�o�[�R�[�h�X�V�A�N�Z�T�N���X</summary>
        private PrmGoodsBarCodeRevnUpdateAcs PrmGoodsBrcdAcs;
        
        /// <summary>�C���[�W���X�g</summary>
        private ImageList ImageList16 = null; 
        /// <summary>��ƃR�[�h</summary>
        private string ExecEnterpriseCode;
        /// <summary>���[�J�[�i�J�n�j</summary>
        private MakerUMnt MakerSt;
        /// <summary>���[�J�[�i�I���j</summary>
        private MakerUMnt MakerEd;
        /// <summary>������</summary>
        private GoodsGroupU GoodsGroupUInfo;
        /// <summary>BL�R�[�h</summary>
        private BLGoodsCdUMnt BlGoodsCdUInfo;

        /// <summary>
        /// �@�\��
        /// </summary>
        private string AssemblyTitle;

        #endregion �����o�[�t�B�[���h

        #region �R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���i�o�[�R�[�h�X�V�����i�蓮�j�t�h�̐V�����C���X�^���X�̐����Ə�����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public PMHND09400U()
        {
            InitializeComponent();
            this.ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this.ExecEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //���i�o�[�R�[�h�X�V�A�N�Z�T�N���X�C���X�^���X����
            if (this.PrmGoodsBrcdAcs == null)
                this.PrmGoodsBrcdAcs = new PrmGoodsBarCodeRevnUpdateAcs();
            
            //���[�J�[�i�J�n�j
            if (MakerSt == null)
                MakerSt = new MakerUMnt();
            //���[�J�[�i�I���j
            if (MakerEd == null)
                MakerEd = new MakerUMnt();
            //������
            if (GoodsGroupUInfo == null)
                GoodsGroupUInfo = new GoodsGroupU();
            //BL�R�[�h
            if (BlGoodsCdUInfo == null)
                BlGoodsCdUInfo = new BLGoodsCdUMnt();

            //�@�\���̎擾
            System.Reflection.AssemblyTitleAttribute assemblyTitle = 
                (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof( AssemblyTitleAttribute ) );
            this.AssemblyTitle = assemblyTitle.Title;

            //�C�x���g�n���h���̐ݒ�
            base.FormClosing += new FormClosingEventHandler( PMHND09400U_FormClosing );
        }
        #endregion //�R���X�g���N�^

        #region �C�x���g
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h���Ɏ��s����鏈��</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void PMHND09400U_Load(object sender, EventArgs e)
        {
            this.PrmGoodsBrcdAcs.WriteOperationLog( PMHND09400U.OperationLogTextStart, PMHND09400U.OperationLogTextStart, string.Empty );
            this.BlGoodsCdGuidAcs = new BLGoodsCdAcs();
            this.GoodsGroupUGuidAcs = new GoodsGroupUAcs();
            this.GoodsMakerGuidAcs = new MakerAcs();

            this.BarCode_tComboEditor.Items.Clear();
            this.BarCode_tComboEditor.Items.Add(
                (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.WithoutUserUpdate, PMHND09400U.BarcodeUpdateKndNameWithoutUserUpdate );
            this.BarCode_tComboEditor.Items.Add( 
                (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.ALL, PMHND09400U.BarcodeUpdateKndNameAll );

            this.BarCode_tComboEditor.SelectedIndex = 0;

            this.ImageList16 = IconResourceManagement.ImageList16;

            this.MakerGuide_St_Button.ImageList = this.ImageList16;
            this.MakerGuide_Ed_Button.ImageList = this.ImageList16;
            this.MGroupGuide_Button.ImageList = this.ImageList16;
            this.BLGoodsCodeGuide_Button.ImageList = this.ImageList16;

            this.MakerGuide_St_Button.Appearance.Image = Size16_Index.STAR1;
            this.MakerGuide_Ed_Button.Appearance.Image = Size16_Index.STAR1;
            this.MGroupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.BLGoodsCodeGuide_Button.Appearance.Image = Size16_Index.STAR1;
            
        }
    
        #region �c�[���o�[�N���b�N�C�x���g
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɔ���</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case "Btn_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                //�X�V
                case "Btn_Update":
                    {
                        try
                        {
                            #region �����o�����`�F�b�N
                            if (this.tNedit_GoodsMakerCd_St.GetInt() > this.GetEndCode( this.tNedit_GoodsMakerCd_Ed ))
                            {
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        PMHND09400U.ErrorTextIlligalMakerCodeRenge, -1, MessageBoxButtons.OK );
                                this.tNedit_GoodsMakerCd_St.Focus();
                                return;
                            }
                            #endregion

                            #region �����o�����ݒ�
                            //-----------------------------------------------------------------------------
                            // ���o�����ݒ�
                            //-----------------------------------------------------------------------------
                            PrmGoodsBrcdUpdateParamWork updateParam = new PrmGoodsBrcdUpdateParamWork();
                            updateParam.EnterpriseCode = this.ExecEnterpriseCode;
                            int uiValue = this.tNedit_GoodsMakerCd_St.GetInt();
                            updateParam.MakerCdST = uiValue < PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum ? 
                                PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum : uiValue;
                            uiValue = this.tNedit_GoodsMakerCd_Ed.GetInt();
                            updateParam.MakerCdED = uiValue == 0 ? PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMaximum : uiValue;
                            updateParam.BarcodeUpdateKndDiv = (int)this.BarCode_tComboEditor.Value;
                            updateParam.GoodMGroup = this.tNedit_GoodsMGroup.GetInt();
                            updateParam.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                            updateParam.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
                            updateParam.RecordCnt = 0;
                            #endregion

                            //���ʏ�������ʐ���
                            SFCMN00299CA processingDialog = new SFCMN00299CA();
                            processingDialog.DispCancelButton = false;
                            processingDialog.Title = PMHND09400U.ProcessingDialogTitleUpdate;
                            processingDialog.Message = PMHND09400U.ProcessingDialogMessageDefault;
                            processingDialog.Show( (Form)this.Parent );

                            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            try
                            {

                                status = this.PrmGoodsBrcdAcs.Update( ref updateParam, false);
                                string logDataMessage = this.PrmGoodsBrcdAcs.CreateUpdateLogText( ref updateParam );
                                this.PrmGoodsBrcdAcs.WriteOperationLog( this.AssemblyTitle, logDataMessage, string.Empty );

                                this.UpdateCountLabel.Text = updateParam.RecordCnt.ToString();
                            }
                            finally
                            {
                                processingDialog.Close();
                            }
                            if (status == (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver)
                            {
                                // ���������I�[�o�[
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name, PMHND09400U.UpdateResultTextReadCountMaxOrver, -1, MessageBoxButtons.OK );
                            }
                            else if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ���������I�[�o�[�ȊO�̃G���[
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, PMHND09400U.UpdateResultTextError, status, MessageBoxButtons.OK );
                            }
                            else
                            {
                                // ����܂��͍X�V�ΏۂȂ�
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name, PMHND09400U.UpdateResultTextNormal, 0, MessageBoxButtons.OK );
                            }
                        }
                        catch(Exception exp)
                        {
                            // ��O�G���[
                            this.WriteErrorLog( exp, PMHND09400U.UpdateResultTextError, (int)ConstantManagement.DB_Status.ctDB_ERROR );
                            TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_STOP, this.Name, exp.Message, (int)ConstantManagement.DB_Status.ctDB_ERROR, MessageBoxButtons.OK );
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// �N���C�A���g���O�o��
        /// </summary>
        /// <param name="ex">��O</param>
        /// <param name="errorText">�G���[���b�Z�[�W</param>
        /// <param name="status">�����X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���g���O�Ƀ��O���o�͂���</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void WriteErrorLog( Exception ex, string errorText, int status )
        {
            ClientLogTextOut clientLogTextOut = new ClientLogTextOut();
            if (ex != null)
            {
                string message = string.Concat( new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" } );
                clientLogTextOut.Output( ex.Source, message, status, ex );
            }
            else
            {
                clientLogTextOut.Output( base.GetType().Assembly.GetName().Name, errorText, status );
            }
        }

        #endregion

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N�����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {

                MakerUMnt maker;

                // �K�C�h�N��
                int status = this.GoodsMakerGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out maker);
                if (status != 0) return;

                if (chkPrime(maker.GoodsMakerCd) == false)
                {
                    if (this.MakerSt.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd_St.Text = this.MakerSt.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_St.Text = string.Empty;
                    }
                    this.MakerCode_St_uLabel.Text = this.MakerSt.MakerName;
                    this.tNedit_GoodsMakerCd_St.Focus();
                    return;
                }
                this.tNedit_GoodsMakerCd_St.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_St_uLabel.Text = maker.MakerName;
                this.MakerSt = maker;
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N�����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void MakerGuide_Ed_Button_Click(object sender, EventArgs e)
        {
            try
            {

                MakerUMnt maker;

                // �K�C�h�N��
                int status = this.GoodsMakerGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out maker);
                if (status != 0) return;

                if (chkPrime(maker.GoodsMakerCd) == false)
                {
                    if (this.MakerEd.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd_Ed.Text = this.MakerEd.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_Ed.Text = string.Empty;
                    }
                    this.MakerCode_Ed_uLabel.Text = this.MakerEd.MakerName;
                    this.tNedit_GoodsMakerCd_Ed.Focus();
                    return;
                }
                this.tNedit_GoodsMakerCd_Ed.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_Ed_uLabel.Text = maker.MakerName;
                this.MakerEd = maker;
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
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this.BlGoodsCdGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out blGoodsCdUMnt);
            if (status != 0) return;
            this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
            if (blGoodsCdUMnt.BLGoodsCode > 0)
            {
                this.BarCode_tComboEditor.Focus();
            }
            else 
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            this.BlGoodsCdUInfo = blGoodsCdUMnt;
        }

        /// <summary>
        /// �����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����ރK�C�h�{�^�����N���b�N�����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;
            int status = this.GoodsGroupUGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out goodsGroupU);
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
            this.GoodsGroupUInfo = goodsGroupU;
        }

        /// <summary>
        /// tArrowKeyControl1�`�F���W�t�H�[�J�X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X���J�ڂ����^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMakerCd_St":
                    {
                        int status = this.SetGoodsMakerValues(
                              ref this.tNedit_GoodsMakerCd_St
                            , ref this.MakerSt
                            , ref this.MakerCode_St_uLabel
                            , e );
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            return;
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMakerCd_St.Text.Trim() == string.Empty)
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = MakerGuide_St_Button;
                                        }
                                        else
                                        {
                                            // ���[�J�[�R�[�h�i�I���j
                                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
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
                                        // �o�[�R�[�h�X�V�敪
                                        e.NextCtrl = this.BarCode_tComboEditor;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        int status = this.SetGoodsMakerValues(
                              ref this.tNedit_GoodsMakerCd_Ed
                            , ref this.MakerEd
                            , ref this.MakerCode_Ed_uLabel
                            , e );
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            return;
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMakerCd_Ed.Text.Trim() == string.Empty)
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = MakerGuide_Ed_Button;
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
                                        // ���[�J�[�R�[�h�i�J�n�j
                                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_GoodsMGroup":
                    {
                        int goodsMGroupCode = 0;
                        if (!string.IsNullOrEmpty( this.tNedit_GoodsMGroup.Text ))
                        {
                            goodsMGroupCode = this.tNedit_GoodsMGroup.GetInt();
                        }
                        if (goodsMGroupCode == 0)
                        {
                            this.MGroup_uLabel.Text = string.Empty;
                            this.GoodsGroupUInfo = new GoodsGroupU();
                            return;
                        }
                        try
                        {
                            GoodsGroupU goodsGroupU;
                            int status = this.GoodsGroupUGuidAcs.Search(out goodsGroupU, this.ExecEnterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
                                this.GoodsGroupUInfo = goodsGroupU;
                            }
                            else
                            {
                                // �x�����o��
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          PMHND09400U.GoodsMGroupInfoNotExists,
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this.GoodsGroupUInfo.GoodsMGroup != 0)
                                {
                                    this.tNedit_GoodsMGroup.Text = this.GoodsGroupUInfo.GoodsMGroup.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMGroup.Text = string.Empty;
                                }
                                this.MGroup_uLabel.Text = this.GoodsGroupUInfo.GoodsMGroupName;
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
                                        if (this.tNedit_GoodsMGroup.Text.Trim() == string.Empty)
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = MGroupGuide_Button;
                                        }
                                        else
                                        {
                                            // �����ރR�[�h
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
                        int blCode = 0;
                        if (!string.IsNullOrEmpty( this.tNedit_BLGoodsCode.Text ))
                        {
                            blCode = this.tNedit_BLGoodsCode.GetInt();
                        }
                        if (blCode == 0)
                        {
                            this.BLGoodsCode_uLabel.Text = string.Empty;
                            this.BlGoodsCdUInfo = new BLGoodsCdUMnt();
                            return;
                        }
                        try
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt;
                            int status = this.BlGoodsCdGuidAcs.Read(out blGoodsCdUMnt, this.ExecEnterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
                                this.BlGoodsCdUInfo = blGoodsCdUMnt;
                            }
                            else
                            {
                                // �x�����o��
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          PMHND09400U.BLCodeInfoNotExists,
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this.BlGoodsCdUInfo.BLGoodsCode != 0)
                                {
                                    this.tNedit_BLGoodsCode.Text = this.BlGoodsCdUInfo.BLGoodsCode.ToString();
                                }
                                else
                                {
                                    this.tNedit_BLGoodsCode.Text = string.Empty;
                                }
                                this.BLGoodsCode_uLabel.Text = this.BlGoodsCdUInfo.BLGoodsHalfName;
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
                                        if (this.tNedit_BLGoodsCode.Text.Trim() == string.Empty)
                                        {
                                            // ���͂��Ȃ���΃K�C�h�{�^����
                                            e.NextCtrl = BLGoodsCodeGuide_Button;
                                        }
                                        else
                                        {
                                            // �����ރR�[�h
                                            e.NextCtrl = this.BarCode_tComboEditor;
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
        /// ���i�o�[�R�[�h�X�V�����i�蓮�j�t�h�L�[�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�X�V�����i�蓮�j�t�h�ŃL�[���������ꂽ�ꍇ�ɔ���</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void PMHND09400U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (this.tNedit_GoodsMakerCd_St.Focused)
                { 
                    MakerGuide_Button_Click(sender, e);
                    return;
                }
                if (this.tNedit_GoodsMakerCd_Ed.Focused)
                {
                    this.MakerGuide_Ed_Button_Click( sender, e );
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

        /// <summary>
        /// �t�H�[���N���[�Y�O�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">FormClosingEventArgs�^�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[��������O�ɔ���</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void PMHND09400U_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (this.PrmGoodsBrcdAcs == null)
                this.PrmGoodsBrcdAcs = new PrmGoodsBarCodeRevnUpdateAcs();
            this.PrmGoodsBrcdAcs.WriteOperationLog( PMHND09400U.OperationLogTextEnd, PMHND09400U.OperationLogTextEnd, string.Empty );
        }
        #endregion //�C�x���g�n���h��

        #region �v���C�x�[�g���\�b�h

        /// <summary>
        /// �������[�J�[�`�F�b�N
        /// </summary>
        /// <param name="goodsMakerCd">���胁�[�J�[�R�[�h</param>
        /// <returns>���茋��[true:�D�ǃ��[�J�[�Afalse:�������[�J�[]</returns>
        /// <remarks>
        /// <br>Note       : ���胁�[�J�[�R�[�h���������[�J�[�̃R�[�h���ۂ��𔻒�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private bool chkPrime( int goodsMakerCd )
        {
            bool status = true;

            if (0 < goodsMakerCd && goodsMakerCd < PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum)
            {
                status = false;

                // �x�����o��
                TMsgDisp.Show(
                          this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          PMHND09400U.CannotSelectGenuineMaker,
                          -1,
                          MessageBoxButtons.OK);
            }
            return status;
        }

        /// <summary>
        /// �ő�l����t���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit">�����Ώۓ��̓R���g���[��</param>
        /// <returns>�擾�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �����Ώۓ��̓R���g���[���̓��͒l�ɑΉ�����R�[�h���擾����</br>
        /// <br>             ���͒l��0�̏ꍇ�͏����Ώۓ��̓R���g���[���œ��͉\�ȍő�l���A0�ȊO�̏ꍇ�͓��͒l��Ԃ�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// �ő�l����t���R�[�h�擾����(�ő�l�w��)
        /// </summary>
        /// <param name="tNedit">�����Ώۓ��̓R���g���[��</param>
        /// <param name="endCodeOnDB">�ő�l</param>
        /// <returns>�擾�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �����Ώۓ��̓R���g���[���̓��͒l�ɑΉ�����R�[�h���擾����</br>
        /// <br>             ���͒l��0�̏ꍇ�͈����Ŏw�肳�ꂽ�ő�l���A0�ȊO�̏ꍇ�͓��͒l��Ԃ�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
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
        /// ���[�J�[���ݒ菈��
        /// </summary>
        /// <param name="tNeditCode">���[�J�[�R�[�h�擾/�ݒ��</param>
        /// <param name="makerBuffer">���[�J�[���擾/�ݒ��</param>
        /// <param name="label">���[�J�[���ݒ��</param>
        /// <param name="e">�t�H�[�J�X��ݒ�p�C�x���g�p�����[�^</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h���͗��̒l�ɑΉ����郁�[�J�[���̃Z�b�g���s��</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SetGoodsMakerValues( ref TNedit tNeditCode, ref MakerUMnt makerBuffer, ref Infragistics.Win.Misc.UltraLabel label, ChangeFocusEventArgs e )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string code = tNeditCode.Text;
            int codeValue = 0;

            if (!string.IsNullOrEmpty( tNeditCode.Text ))
            {
                codeValue = tNeditCode.GetInt();
            }

            if (codeValue == 0)
            {
                // ���[�J�[�R�[�h�ɋ󔒂�������0���Z�b�g����Ă����ꍇ
                label.Text = string.Empty;
                makerBuffer = new MakerUMnt();
                return status;
            }

            if (!this.chkPrime( codeValue ))
            {
                // �������[�J�[�̏ꍇ�A�O����͒l�ɖ߂�
                if (makerBuffer.GoodsMakerCd != 0)
                {
                    tNeditCode.Text = makerBuffer.GoodsMakerCd.ToString();
                }
                else
                {
                    tNeditCode.Text = string.Empty;
                }
                label.Text = this.MakerSt.MakerName;
                e.NextCtrl = e.PrevCtrl;
                tNeditCode.Focus();
                return status;
            }

            // �D�ǃ��[�J�[�̏ꍇ
            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                MakerUMnt maker;

                // �R�[�h���̂̎擾
                int dbStatus = this.GoodsMakerGuidAcs.Read( out maker, this.ExecEnterpriseCode, codeValue );
                if (dbStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    label.Text = maker.MakerName;
                    makerBuffer = maker;
                }
                else
                {
                    makerBuffer.GoodsMakerCd = codeValue;
                    makerBuffer.MakerName = PMHND09400U.NoRecodeInfoName;
                    label.Text = makerBuffer.MakerName;
                }
            }
            catch
            {

            }

            return status;
        }

        #endregion //�v���C�x�[�g���\�b�h
    }

}