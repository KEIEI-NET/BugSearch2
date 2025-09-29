//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �I���ߕs���X�V
// �v���O�����T�v   : �I���ߕs���X�V�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ȓ��@����Y
// �� �� ��  2007.06.13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007.09.20  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008.02.26  �C�����e : �d�l�ύX�Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/09/10  �C�����e : �d�l�ύX�Ή��iPartsman�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/02/02  �C�����e : �r�����䏈���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : ��Q�Ή�13105
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/22  �C�����e : �s��Ή�[13263]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �C �� ��  2009/09/14  �C�����e : �s��Ή�[13920]
//                                  �I��Edit��AutoWidth��True�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �C �� ��  2009/09/24  �C�����e : �s��Ή�[14320]
//                                  �I�ԍX�V�敪���t�ɂȂ��Ă���s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : �k���r
// �C �� ��  2010/03/12  �C�����e : PM1005�o�l�D�m�r�T������
//                                  Redmine#3772�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/03/15  �C�����e : PM1005�s��Ή�
//                                  Redmine#3827�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/03/16  �C�����e : PM1005�s��Ή�
//                                  Redmine#3827�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2010/12/03  �C�����e : �ߕs���X�V�{�^���̐���ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/01/11  �C�����e : �I����Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ��
// �C �� ��  K2015/08/21  �C�����e : redmine#46790  �I���ߕs���X�V�@�������A�E�g�̏C��
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;
using System.Threading; // ADD 20011/01/11

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �I���ߕs���X�V�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I���ߕs���X�V�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2007.06.13</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2007.06.13 men �V�K�쐬</br>
    /// <br>Update Note: 2007.09.20 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.02.26 980035 ���� ��`</br>
    /// <br>			 �E�d�l�ύX�Ή��iDC.NS�Ή��j</br>
    /// <br>Update Note: 2008/09/10 30414 �E �K�j</br>
    /// <br>			 �E�d�l�ύX�Ή��iPartsman�Ή��j</br>
    /// <br>Update Note: 2009/02/02 30452 ��� �r��</br>
    /// <br>			 �E�r�����䏈���ǉ�</br>
    /// <br>Update Note: 2009/04/13 30452 ��� �r��</br>
    /// <br>			 �E��Q�Ή�13105</br>
    /// <br>Update Note: 2009/05/22       �Ɠc �M�u</br>
    /// <br>			 �E�s��Ή�[13263]</br>
    /// <br>Update Note: 2010/03/12 �k���r PM1005�o�l�D�m�r�T������</br>
    /// <br>              Redmine#3772�̑Ή�</br>
    /// <br>Update Note: 2010/03/15 �k���r �s��Ή�</br>
    /// <br>              Redmine#3827�̑Ή�</br>
    /// <br>Update Note: 2010/03/16 �k���r �s��Ή�</br>
    /// <br>              Redmine#3827�̑Ή�</br>
    /// <br>Update Note: 2010/12/03 �c����</br>
    /// <br>             �ߕs���X�V�{�^���̐���ύX</br>
    /// <br>Update Note: 2011/01/11 ����</br>
    /// <br>             �I����Q�Ή�</br>
    /// </remarks>
	public partial class MAZAI05160UA : Form
	{
		# region Inner Class
		/// <summary>
		/// �Z�����������N���X�iIMergedCellEvaluator �C���^�t�F�[�X���C���v�������g�j
		/// </summary>
		private class CustomMergedCellEvaluatorGoodsCode : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
		{
			/// <summary>
			/// �Z�������������菈��
			/// </summary>
			/// <param name="row1">�s�P</param>
			/// <param name="row2">�s�Q</param>
			/// <param name="column">��</param>
			/// <returns>��Ɋ֘A�t����ꂽrow1��row2�̃Z�������������ꍇ�ATrue��Ԃ��܂�</returns>
			public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
			{
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
				//int makerCode1 = Convert.ToInt32(row1.Cells["MakerCode"].Value);
				//int makerCode2 = Convert.ToInt32(row2.Cells["MakerCode"].Value);

                //string goodsCode1 = row1.Cells["GoodsCode"].Value.ToString();
				//string goodsCode2 = row2.Cells["GoodsCode"].Value.ToString();
                int makerCode1 = Convert.ToInt32(row1.Cells["GoodsMakerCd"].Value);
                int makerCode2 = Convert.ToInt32(row2.Cells["GoodsMakerCd"].Value);

                string goodsCode1 = row1.Cells["GoodsNo"].Value.ToString();
				string goodsCode2 = row2.Cells["GoodsNo"].Value.ToString();
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

				if ((goodsCode1.Trim() == "") || (goodsCode2.Trim() == "")) return false;
				return ((makerCode1 == makerCode2) && (goodsCode1 == goodsCode2));
			}
		}

		/// <summary>
		/// �Z�����������N���X�iIMergedCellEvaluator �C���^�t�F�[�X���C���v�������g�j
		/// </summary>
		private class CustomMergedCellEvaluatorWarehouseCode : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
		{
			/// <summary>
			/// �Z�������������菈��
			/// </summary>
			/// <param name="row1">�s�P</param>
			/// <param name="row2">�s�Q</param>
			/// <param name="column">��</param>
			/// <returns>��Ɋ֘A�t����ꂽrow1��row2�̃Z�������������ꍇ�ATrue��Ԃ��܂�</returns>
			public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
			{
				string sectionCode1 = row1.Cells["SectionCode"].Value.ToString();
				string sectionCode2 = row2.Cells["SectionCode"].Value.ToString();

				string warehouseCode1 = row1.Cells["WarehouseCode"].Value.ToString();
				string warehouseCode2 = row2.Cells["WarehouseCode"].Value.ToString();

				if ((warehouseCode1.Trim() == "") || (warehouseCode2.Trim() == "")) return false;
				return ((sectionCode1 == sectionCode2) && (warehouseCode1 == warehouseCode2));
			}
		}
		# endregion

		# region �R���X�g���N�^
		/// <summary>
		/// �I���ߕs���X�V�̃R���X�g���N�^�ł��B
		/// </summary>
		public MAZAI05160UA()
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			this._loginEmployeeLabel = (LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			this._loginNameLabel = (LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
			this._closeButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._saveButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			this._clearButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
			this._searchButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			this._showErrorButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ShowError"];
			this._printButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
			   --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            
            this._controlScreenSkin = new ControlScreenSkin();
			this._inventoryUpdateAcs = new InventoryUpdateAcs();
			this._dataSet = this._inventoryUpdateAcs.DataSet;

            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //�I�����������A�N�Z�X�N���X
            this._inventoryPrepareAcs = new InventoryPrepareAcs();
            // 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseGuide = new WarehouseAcs();
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

            // ---------- ADD 20011/01/11 ---------->>>>>
            // �O���b�h�ݒ胍�[�h
            this._gridStateController = new GridStateController();
            this._gridStateController.LoadGridState(ctFILENAME_COLDISPLAYSTATUS);
            // ---------- ADD 20011/01/11 ----------<<<<<
        }
		# endregion

		# region �v���C�x�[�g�ϐ�
		private InventoryUpdateAcs _inventoryUpdateAcs;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private DateTime _baseDate = DateTime.MinValue;
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private ImageList _imageList16 = null;
		private ControlScreenSkin _controlScreenSkin;
		private InventoryUpdateDataSet _dataSet;
		private ColDisplayStatusList _colDisplayStatusList;						// ��\����ԃR���N�V�����N���X
		private Image _guideButtonImage;
        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
        private WarehouseAcs _warehouseGuide = null;                            //�q�ɃK�C�h
        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
        // 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private InventoryPrepareAcs _inventoryPrepareAcs = null;                // �I�����������A�N�Z�X�N���X
        // 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        private SecInfoSetAcs _secInfoSetAcs;
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        private ButtonTool _closeButton;				// �I���{�^��
        private ButtonTool _saveButton;					// �ۑ��{�^��
        private ButtonTool _clearButton;				// �I�������{�^��
        private ButtonTool _searchButton;				// �����{�^��
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private ButtonTool _showErrorButton;			// �G���[�\���{�^��
		private ButtonTool _printButton;				// �G���[������{�^��
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private LabelTool _loginEmployeeLabel;			// ���O�C���S���҃^�C�g��
		private LabelTool _loginNameLabel;				// ���O�C���S���Җ���

		private const string ctFILENAME_COLDISPLAYSTATUS = "MAZAI05150U_ColSetting.DAT";	// ��\����ԃZ�b�e�B���OXML�t�@�C����

        // �O���b�h�R���g���[���N���X                    
        private GridStateController _gridStateController = null; // ADD 2011/01/11

        # endregion

		# region �v���C�x�[�g���\�b�h

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �I���f�[�^�̌������s���܂��B
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="inventoryDay">���{��</param>
		/// <param name="difCntExtraDiv">0:�S�ĕ\�� 1:�ߕs���������̂ݕ\��</param>
		/// <returns>STATUS</returns>
        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
		//private int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv)
        // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
        //private int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv, string warehouseCdSta, string warehouseCdEnd, string shelfNoSta, string shelfNoEnd)
        private int Search(string sectionCode, DateTime inventoryDay, int difCntExtraDiv, string warehouseCdSta, string warehouseCdEnd, string shelfNoSta, string shelfNoEnd)
        // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<
        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
		{
            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((inventoryDayEnd != DateTime.MinValue) && (inventoryDaySta > inventoryDayEnd))
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_INFO,
            //        this.Name,
            //        "�I�����͈͎̔w�肪�s���ł��B",
            //        -1,
            //        MessageBoxButtons.OK);

            //    this.tDateEdit_InventoryDayEnd.Focus();
            //}
            if (inventoryDay == DateTime.MinValue)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�I�����̎w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tDateEdit_InventoryDay.Focus();
                return -1;
            }
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //�q�ɃR�[�h
            else if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != "") &&
                (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�q�ɃR�[�h�͈͎̔w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_WarehouseCode_Ed.Focus();
                return -1;
            }
            //�I��
            else if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != "") &&
                (this.tEdit_WarehouseShelfNo_St.DataText.CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText) > 0))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�I�Ԃ͈͎̔w�肪�s���ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_WarehouseCode_Ed.Focus();
                return -1;
            }
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

            this.ErrorListVisibleControl(false);

			int status = -1;

			SFCMN00299CA msgForm = new SFCMN00299CA();
			msgForm.Title  = "���o��";
			msgForm.Message = "�I���f�[�^�̒��o���ł��B";
			try
			{
				msgForm.Show();	// �_�C�A���O�\��

                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //status = this._inventoryUpdateAcs.Search(sectionCode, inventoryDaySta, inventoryDayEnd, difCntExtraDiv);
                // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
                //status = this._inventoryUpdateAcs.Search(sectionCode, inventoryDaySta, inventoryDayEnd, difCntExtraDiv, warehouseCdSta, warehouseCdEnd, shelfNoSta, shelfNoEnd);
                status = this._inventoryUpdateAcs.Search(sectionCode, inventoryDay, DateTime.MaxValue, difCntExtraDiv, warehouseCdSta, warehouseCdEnd, shelfNoSta, shelfNoEnd);
                // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            }
			catch (Exception ex)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					ex.Message,
					-1,
					MessageBoxButtons.OK);

				return -1;
			}
			finally
			{
				msgForm.Close();
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �I���f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���B
				this.SettingGridRow();

				if (this.uGrid_Result.Rows.Count > 0)
				{
					this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
					this.uGrid_Result.ActiveRow.Selected = true;
				}

				this.ultraOptionSet_DifCntExtraDiv_ValueChanged(this.ultraOptionSet_DifCntExtraDiv, EventArgs.Empty);
			}
            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            //else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
            //            (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            else
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<
            {
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�Y���f�[�^�����݂��܂���B",
					-1,
					MessageBoxButtons.OK);

				this.timer_InitFocusSetting.Enabled = true;
			}
            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            //else
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_STOPDISP,
            //        this.Name,
            //        "����f�[�^�̎擾�Ɏ��s���܂����B",
            //        status,
            //        MessageBoxButtons.OK);

            //    this.timer_InitFocusSetting.Enabled = true;
            //}
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<
		
			this.SettingGridRow();

			// �c�[���o�[�{�^��Enabled�ݒ菈��
			this.SettingToolBarButtonEnabled();

			// �s�ԍ����̔Ԃ��܂��B
			this.NumberingRowNo();
			
			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I���f�[�^��������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�̌������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2010/03/12 �k���r PM1005�o�l�D�m�r�T������</br>
        /// <br>              Redmine#3772�̑Ή�</br>
        /// <br>Update Note: 2010/03/15 �k���r �s��Ή�</br>
        /// <br>              Redmine#3827�̑Ή�</br>
        /// <br>Update Note: 2010/03/16 �k���r �s��Ή�</br>
        /// <br>              Redmine#3827�̑Ή�</br>
        /// <br>Update Note: 2010/12/03 �c����</br>
        /// <br>             �ߕs���X�V�{�^���̐���ύX</br>
        /// <br>Update Note: K2015/08/21 �� �I���ߕs���X�V�@�������A�E�g�̏C��</br>
        /// <br>             Redmine#46790�̑Ή�</br>
        /// </remarks>
        private int Search()
        {
            // ���o�����`�F�b�N
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return (-1);
            }

            // �G���[��\��
            ErrorListVisibleControl(false);

            // ��ʏ��i�[
            InventInputSearchCndtn inventInputSearchCndtn = new InventInputSearchCndtn();
            SetInventInputSearchCndtn(ref inventInputSearchCndtn);

            int status = -1;
            
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "�I���f�[�^�̒��o���ł��B";
            
            try
            {
                // �_�C�A���O�\��
                msgForm.Show();	

                // ����
                status = this._inventoryUpdateAcs.Search(inventInputSearchCndtn);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_STOPDISP,
                              this.Name,
                              ex.Message,
                              -1,
                              MessageBoxButtons.OK);

                return -1;
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �I���f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���B
                        this.SettingGridRow();

                        if (this.uGrid_Result.Rows.Count > 0)
                        {
                            this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                            this.uGrid_Result.ActiveRow.Selected = true;
                        }
                        // -- DEL 2010/03/15 ----------------------------------->>>>>
                        // -- UPD 2010/03/12 ----------------------------------->>>>>
                        //else
                        //{
                        //    TMsgDisp.Show(this,
                        //                  emErrorLevel.ERR_LEVEL_INFO,
                        //                  this.Name,
                        //                  "�Y���f�[�^�����݂��܂���B",
                        //                  -1,
                        //                  MessageBoxButtons.OK);

                        //    this.timer_InitFocusSetting.Enabled = true;
                        //}
                        // -- UPD 2010/03/12 -----------------------------------<<<<<
                        // -- DEL 2010/03/15 -----------------------------------<<<<<
                        this.ultraOptionSet_DifCntExtraDiv_ValueChanged(this.ultraOptionSet_DifCntExtraDiv, EventArgs.Empty);
                        // -- ADD 2010/03/16 ----------------------------------->>>>>
                        if (this.uGrid_Result.Rows.Count <= 0)
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "�Y���f�[�^�����݂��܂���B",
                                          -1,
                                          MessageBoxButtons.OK);

                            this.timer_InitFocusSetting.Enabled = true;
                        }
                        // -- ADD 2010/03/16 ----------------------------------->>>>>
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        //this._saveButton.SharedProps.Enabled = false; // ADD 2010/12/03 // DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
                        this._saveButton.SharedProps.Enabled = true;  // ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�Y���f�[�^�����݂��܂���B",
                                      -1,
                                      MessageBoxButtons.OK);

                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "�I���f�[�^�̌����Ɏ��s���܂����B",
                                      -1,
                                      MessageBoxButtons.OK);

                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
            }
            
            // �O���b�h�ݒ�
            SettingGridRow();

            // �s�ԍ����̔Ԃ��܂��B
            NumberingRowNo();

            if (status == 0)
            {
                this.uGrid_Result.Focus();
                if (this.uGrid_Result.Rows.Count > 0)       //ADD 2009/05/22 �s��Ή�[13263]
                {                                           //ADD 2009/05/22 �s��Ή�[13263]
                    this.uGrid_Result.Rows[0].Activate();
                }                                           //ADD 2009/05/22 �s��Ή�[13263]
            }
            else
            {
                //this.tEdit_SectionCode.Focus();       //DEL 2009/05/22 �s��Ή�[13263]
                this.tDateEdit_InventoryDay.Focus();    //ADD 2009/05/22 �s��Ή�[13263]
            }

            return (status);
        }

        /// <summary>
        /// �I���f�[�^���������ݒ菈��
        /// </summary>
        /// <param name="inventInputSearchCndtn">�I���f�[�^���������N���X</param>
        /// <remarks>
        /// <br>Note       : �I���f�[�^���������N���X��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void SetInventInputSearchCndtn(ref InventInputSearchCndtn inventInputSearchCndtn)
        {
            // ��ƃR�[�h
            inventInputSearchCndtn.EnterpriseCode = this._enterpriseCode;
            // ���ٕ����o�敪(�����͕��̂�)   
            inventInputSearchCndtn.DifCntExtraDiv = 2;
            // ---DEL 2009/05/22 �s��Ή�[13263] ------------------------------------------------------>>>>>
            // ���_�R�[�h
            //inventInputSearchCndtn.St_SectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            //inventInputSearchCndtn.Ed_SectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // ---DEL 2009/05/22 �s��Ή�[13263] ------------------------------------------------------<<<<<
            // �q�ɃR�[�h
            if (this.tEdit_WarehouseCode_St.DataText.Trim() == "")
            {
                inventInputSearchCndtn.St_WarehouseCode = "";
            }
            else
            {
                inventInputSearchCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0');
            }
            if (this.tEdit_WarehouseCode_Ed.DataText.Trim() == "")
            {
                inventInputSearchCndtn.Ed_WarehouseCode = "";
            }
            else
            {
                inventInputSearchCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0');
            }
            // �I��
            inventInputSearchCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText.Trim();
            inventInputSearchCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText.Trim();
            // �d����R�[�h
            inventInputSearchCndtn.St_SupplierCd = 0;
            inventInputSearchCndtn.Ed_SupplierCd = 999999;
            // BL�R�[�h
            inventInputSearchCndtn.St_BLGoodsCode = 0;
            inventInputSearchCndtn.Ed_BLGoodsCode = 99999;
            // �O���[�v�R�[�h
            inventInputSearchCndtn.St_BLGroupCode = 0;
            inventInputSearchCndtn.Ed_BLGroupCode = 99999;
            // ���[�J�[�R�[�h
            inventInputSearchCndtn.St_MakerCode = 0;
            inventInputSearchCndtn.Ed_MakerCode = 9999;
            // �ʔ�
            inventInputSearchCndtn.St_InventorySeqNo = 0;
            inventInputSearchCndtn.Ed_InventorySeqNo = 999999;
            // �I����
            inventInputSearchCndtn.InventoryDate = this.tDateEdit_InventoryDay.GetDateTime();
        }

        /// <summary>
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";
            try
            {
                // ---DEL 2009/05/22 �s��Ή�[13263] --------------------------------->>>>>
                //// ���_�R�[�h
                //if (this.tEdit_SectionCode.DataText.Trim() == "")
                //{
                //    errMsg = "���_�R�[�h�������͂ł��B";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}

                //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                //if (this._inventoryUpdateAcs.GetSectionName(sectionCode) == "")
                //{
                //    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}
                // ---DEL 2009/05/22 �s��Ή�[13263] ---------------------------------<<<<<

                // �I����
                if (this.tDateEdit_InventoryDay.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "�I�����̎w�肪�s���ł��B";
                    this.tDateEdit_InventoryDay.Focus();
                    return (false);
                }

                //�q�ɃR�[�h
                if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
                {
                    if (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0)
                    {
                        errMsg = "�q�ɃR�[�h�͈͎̔w�肪�s���ł��B";
                        this.tEdit_WarehouseCode_Ed.Focus();
                        return (false);
                    }
                }

                //�I��
                if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != ""))
                {
                    if (this.tEdit_WarehouseShelfNo_St.DataText.CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText) > 0)
                    {
                        errMsg = "�I�Ԃ͈͎̔w�肪�s���ł��B";
                        this.tEdit_WarehouseCode_Ed.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  -1,
                                  MessageBoxButtons.OK);
                }
            }

            return (true);
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �I������f�[�^��ۑ����܂��B
		/// </summary>
		/// <param name="isShowSaveCompletionDialog">�ۑ������_�C�A���O�\���t���O</param>
		/// <returns>true:�ۑ����� false:���ۑ�</returns>
		private bool Save(bool isShowSaveCompletionDialog)
		{
			string message;
			bool isSaved;
            int shelfNoDiv;
            if (this.ultraOptionSet_ShelfNoDiv.CheckedIndex == 0)
            {
                shelfNoDiv = 1;
            }
            else
            {
                shelfNoDiv = 0;
            }
            int status = this._inventoryUpdateAcs.Save(out isSaved, out message, shelfNoDiv);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (isShowSaveCompletionDialog)
				{
					SaveCompletionDialog dialog = new SaveCompletionDialog();
					dialog.ShowDialog(2);
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�X�V�Ώۃf�[�^�����݂��܂���B",
					-1,
					MessageBoxButtons.OK);

			}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// �r���i�ʒ[���X�V�ρj
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// �r���i�ʒ[�������폜�ρj
			//{
			//}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)					// �x��
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�ߕs���X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" +
					"�G���[����\�����܂��B",
					-1,
					MessageBoxButtons.OK);

				this.ErrorListVisibleControl(true);
			}
			else if (status == -1)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�X�V�Ώۃf�[�^�����݂��܂���B",
					status,
					MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�ߕs���X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" +
					message,
					status,
					MessageBoxButtons.OK);
			}

			this.SettingGridRow();

			// �c�[���o�[�{�^��Enabled�ݒ菈��
			this.SettingToolBarButtonEnabled();

			return isSaved;
		}

		/// <summary>
		/// �I������f�[�^�ߕs���X�V�̃`�F�b�N���s���܂��B
		/// </summary>
		private bool ErrorCheck(bool showOkMessage)
		{
			bool isError = false;
			int status = this._inventoryUpdateAcs.ErrorCheck();

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (showOkMessage)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�ߕs���X�V�̃G���[�`�F�b�N������Ɋ������܂����B" + "\r\n" + "\r\n" +
						"�G���[����������I���f�[�^�͑��݂��܂���B",
						-1,
						MessageBoxButtons.OK);
				}

				this.ErrorListVisibleControl(false);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�G���[�`�F�b�N�Ώۃf�[�^�����݂��܂���B",
					-1,
					MessageBoxButtons.OK);

				isError = true;
			}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// �r���i�ʒ[���X�V�ρj
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// �r���i�ʒ[�������폜�ρj
			//{
			//}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)					// �x��
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�G���[����������I���f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
					"�G���[����\�����܂��B",
					-1,
					MessageBoxButtons.OK);

				this.ErrorListVisibleControl(true);
				isError = true;
			}
			else if (status == -1)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�G���[�`�F�b�N�Ώۃf�[�^�����݂��܂���B",
					status,
					MessageBoxButtons.OK);
				isError = true;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�G���[�`�F�b�N�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);
				isError = true;
			}

			if (isError)
			{
				this.SettingGridRow();

				// �c�[���o�[�{�^��Enabled�ݒ菈��
				this.SettingToolBarButtonEnabled();
			}

			if (isError)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I������ۑ�����
        /// </summary>
        /// <returns>true:�ۑ����� false:���ۑ�</returns>
        /// <remarks>
        /// <br>Note       : �I������f�[�^��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2010/03/12 �k���r PM1005�o�l�D�m�r�T������</br>
        /// <br>              Redmine#3772�̑Ή�</br>
        /// <br>Update Note: K2015/08/21 �� �I���ߕs���X�V�@�������A�E�g�̏C��</br>
        /// <br>             Redmine#46790�̑Ή�</br>
        /// </remarks>
        private bool Save()
        {
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            this.Name,
                                            "�o�^���Ă���낵���ł����H",
                                            0,
                                            MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                return (false);
            }

            string message;
            bool isSaved;
            int shelfNoDiv;

            // -- UPD 2009/09/24 ----------------------------------->>>
            //if (this.ultraOptionSet_ShelfNoDiv.CheckedIndex == 0)
            //{
            //    shelfNoDiv = 1;
            //}
            //else
            //{
            //    shelfNoDiv = 0;
            //}
            shelfNoDiv = this.ultraOptionSet_ShelfNoDiv.CheckedIndex;
            // -- UPD 2009/09/24 -----------------------------------<<<
            // -- UPD 2010/03/12 ----------------------------------->>>>>
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�I���ߕs���X�V";
            msgForm.Message = "���݁A�I���ߕs���X�V�������ł��B";
            int status = -1;
            try
            {
                // �_�C�A���O�\��
                msgForm.Show();
                this.Cursor = Cursors.WaitCursor;

                // �ۑ�����
                status = this._inventoryUpdateAcs.Save(out isSaved, out message, shelfNoDiv);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                msgForm.Close();
            }

            //// �ۑ�����
            //int status = this._inventoryUpdateAcs.Save(out isSaved, out message, shelfNoDiv);
            // -- UPD 2010/03/12 -----------------------------------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // -- UPD 2010/03/12 ----------------------------------->>>>>
                        // �������b�Z�[�W�\��
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�X�V���܂���",
                                      status,
                                      MessageBoxButtons.OK);
                        //SaveCompletionDialog dialog = new SaveCompletionDialog();
                        //dialog.ShowDialog(2);
                        // -- UPD 2010/03/12 -----------------------------------<<<<<
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "�X�V�Ώۃf�[�^�����݂��܂���B",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WARNING:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "�ߕs���X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" +
                                      "�G���[����\�����܂��B",
                                      status,
                                      MessageBoxButtons.OK);

                        // �G���[�\��
                        ErrorListVisibleControl(true);
                        break;
                    }
                // --- ADD 2009/02/02 -------------------------------->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                            + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                            + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                // --- ADD 2009/02/02 --------------------------------<<<<<
                // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
                case (-100): // �������A�E�g�Ή�
                    {
                        // �ߕs���X�V���s���b�Z�[�W�\��
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�ߕs���X�V�Ɏ��s���܂����B\n�ēx�ߕs���X�V�����s���ĉ������B\n�����o�����s���邱�ƂŃ������g�p�ʂ��������܂��̂ŁA\n�@�݌ɓo�^�������ꍇ�́A���o�����Ɏ��s���ĉ������B",
                                      status,
                                      MessageBoxButtons.OK);
                        this.Clear();
                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
                // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "�ߕs���X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" +
                                      message,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
            }

            // �O���b�h�ݒ�
            SettingGridRow();

            return isSaved;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        /// <summary>
        /// �ߕs���X�V����
        /// </summary>
        /// <returns>true:�ۑ����� false:���ۑ�</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^��0���擾�����ꍇ�́A�ߕs���X�V�������s���B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private bool TolerancUpdate()
        {
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            this.Name,
                                            "�ߕs���X�V�O�ɓ��e���m�F�������ꍇ�́A��x���o�����s���ĉ������B\n���A���A���o�����s���邱�ƂŃ������g�p�ʂ��������܂��̂ŁA\n�@�݌ɓo�^�������ꍇ�́A���o�����Ɏ��s���ĉ������B\n\n�ߕs���X�V�𑱍s���܂����H",
                                            0,
                                            MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return (false);
            }
            // ���o�����`�F�b�N
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return (false);
            }

            // �G���[��\��
            ErrorListVisibleControl(false);
            // ��ʏ��i�[
            InventInputSearchCndtn inventInputSearchCndtn = new InventInputSearchCndtn();
            SetInventInputSearchCndtn(ref inventInputSearchCndtn);
            
            string message = string.Empty;
            bool isSaved = false;
            int shelfNoDiv;
            shelfNoDiv = this.ultraOptionSet_ShelfNoDiv.CheckedIndex;
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�I���ߕs���X�V";
            msgForm.Message = "���݁A�I���ߕs���X�V�������ł��B";
            int status = -1;
            try
            {
                // �_�C�A���O�\��
                msgForm.Show();
                this.Cursor = Cursors.WaitCursor;
                // ����
                status = this._inventoryUpdateAcs.SearchAndUpdate(inventInputSearchCndtn, shelfNoDiv, out isSaved, out message);
                
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                msgForm.Close();
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �������b�Z�[�W�\��
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�X�V���܂���",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "�X�V�Ώۃf�[�^�����݂��܂���B",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WARNING:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "�ߕs���X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" +
                                      "�G���[����\�����܂��B",
                                      status,
                                      MessageBoxButtons.OK);

                        // �G���[�\��
                        ErrorListVisibleControl(true);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                            + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                            + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "�ߕs���X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" +
                                      message,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
            }

            return isSaved;
        }
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private void Print()
		{
			SFCMN06002C printInfo = new SFCMN06002C();						// ������p�����[�^
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;	// ��ƃR�[�h
			printInfo.kidopgid = "MAZAI05150U";								// �N���o�f�h�c
			printInfo.printmode = 1;										// ������[�h(1:�ʏ���,2:PDF,3:����)
			printInfo.prevkbn = 0;											// ���

            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._inventoryUpdateAcs.SettingErrorDataHeaderInfo(this.tComboEditor_SectionCode.Value.ToString(), this.tComboEditor_SectionCode.Text, this.tDateEdit_InventoryDay.GetDateTime(), this.tDateEdit_InventoryDayEnd.GetDateTime());
            // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            //this._inventoryUpdateAcs.SettingErrorDataHeaderInfo(this.tComboEditor_SectionCode.Value.ToString(), this.tComboEditor_SectionCode.Text, this.tDateEdit_InventoryDay.GetDateTime(), DateTime.MaxValue);

            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
            string sectionName = this._inventoryUpdateAcs.GetSectionName(sectionCode);
            DateTime inventoryDay = this.tDateEdit_InventoryDay.GetDateTime();

            this._inventoryUpdateAcs.SettingErrorDataHeaderInfo(sectionCode, sectionName, inventoryDay, DateTime.MaxValue);
            // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<
            
            printInfo.rdData = this._inventoryUpdateAcs.DataSet.ErrorData;

			SFCMN06001U printDialog = new SFCMN06001U();
			printDialog.PrintInfo = printInfo;

			// ���[�I���K�C�h
			DialogResult dialogResult = printDialog.ShowDialog();

			if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�Y������f�[�^������܂���",
					0,
					MessageBoxButtons.OK);
			}
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ��ʂ����������܂��B
		/// </summary>
		private void Clear()
		{
			this._inventoryUpdateAcs.Clear();
			this.tDateEdit_InventoryDay.Clear();
            // 2008.02.26 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.tDateEdit_InventoryDayEnd.SetDateTime(DateTime.Today);
            // 2008.02.26 �폜 <<<<<<<<<<<<<<<<<<<<

            this.tComboEditor_SectionCode.Value = LoginInfoAcquisition.Employee.BelongSectionCode;
            
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            this.tEdit_WarehouseCode_St.Clear();
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseShelfNo_St.Clear();
            this.tEdit_WarehouseShelfNo_Ed.Clear();
            this.ultraOptionSet_ShelfNoDiv.CheckedIndex = 0;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

			// �G���[�\���^��\���R���g���[������
			this.ErrorListVisibleControl(false);

			// �c�[���o�[�{�^��Enabled�ݒ菈��
			this.SettingToolBarButtonEnabled();
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2010/12/03 �c����</br>
        /// <br>             �ߕs���X�V�{�^���̐���ύX</br>
        /// <br>Update Note: K2015/08/21 �� �I���ߕs���X�V�@�������A�E�g�̏C��</br>
        /// <br>             Redmine#46790�̑Ή�</br>
        /// </remarks>
        private void Clear()
        {
            this._inventoryUpdateAcs.Clear();
            this.tDateEdit_InventoryDay.Clear();
            //this._saveButton.SharedProps.Enabled = false; // DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
            // ---DEL 2009/05/22 �s��Ή�[13263] ------------------------------------------------------------------------------------->>>>>
            //this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this.tEdit_SectionName.DataText = this._inventoryUpdateAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // ---DEL 2009/05/22 �s��Ή�[13263] -------------------------------------------------------------------------------------<<<<<
            this.tEdit_WarehouseCode_St.Clear();
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseShelfNo_St.Clear();
            this.tEdit_WarehouseShelfNo_Ed.Clear();
            this.ultraOptionSet_ShelfNoDiv.CheckedIndex = 1;

            // �G���[�\���^��\���R���g���[������
            this.ErrorListVisibleControl(false);
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// ����f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���܂��B
		/// </summary>
		private void SettingGridRow()
		{
			try
			{
				// �`����ꎞ��~
				this.uGrid_Result.BeginUpdate();

				// �`�悪�K�v�Ȗ��׌������擾����B
				int cnt = this.uGrid_Result.Rows.Count;

				// �e�s���Ƃ̐ݒ�
				for (int i = 0; i < cnt; i++)
				{
					this.SettingGridRow(i);
				}
			}
			finally
			{
				// �`����J�n
				this.uGrid_Result.EndUpdate();
			}
		}

		/// <summary>
		/// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
		/// </summary>
		/// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
		private void SettingGridRow(int rowIndex)
		{
			UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
			if (editBand == null) return;

			// �s�ԍ����擾
			int rowNo = Convert.ToInt32(this.uGrid_Result.Rows[rowIndex].Cells[this._dataSet.Inventory.RowNoColumn.ColumnName].Value);

			// �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
			foreach (UltraGridColumn col in editBand.Columns)
			{
				// �Z�������擾
				UltraGridCell cell = this.uGrid_Result.Rows[rowIndex].Cells[col];
				if (cell == null) continue;
			}
		}

		/// <summary>
		/// ��\����ԃN���X���X�g���\�z���܂��B
		/// </summary>
		/// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
		/// <returns>��\����ԃN���X���X�g</returns>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction(ColumnsCollection columns)
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// �O���b�h�����\����ԃN���X���X�g���\�z
			foreach (UltraGridColumn column in columns)
			{
				if (column.Hidden) continue;

				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;

				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
        }

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �R���g���[���L�������ݒ菈��
		/// </summary>
		private void SettingEnabledControl()
		{
			//
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �s�ԍ����̔Ԃ��܂��B
		/// </summary>
		private void NumberingRowNo()
		{
			int rowNo = 1;
			foreach (UltraGridRow row in this.uGrid_Result.Rows)
			{
				row.Cells[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].Value = rowNo;
				rowNo++;
			}

			this.uGrid_Result.UpdateData();
        }

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �c�[���o�[�{�^��Enabled�ݒ菈��
		/// </summary>
		private void SettingToolBarButtonEnabled()
		{
			if (this._inventoryUpdateAcs.DataSet.ErrorData.Rows.Count > 0)
			{
				this._printButton.SharedProps.Enabled = true;
			}
			else
			{
				this._printButton.SharedProps.Enabled = false;
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �G���[�\���^��\���R���g���[������
		/// </summary>
		/// <param name="visible">true:�\�� false:��\��</param>
		private void ErrorListVisibleControl(bool visible)
		{
			this.panel_ErrorListContainer.Visible = visible;
			this.splitter_ErrorSplitter.Visible = visible;
		}

		# endregion

		# region �e��R���g���[���C�x���g����
		/// <summary>
		/// �I���ߕs���X�V���[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void MAZAI05150UA_Load(object sender, EventArgs e)
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			this._showErrorButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NOTPRINTOUT;
			this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

			// �X�L�����[�h
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			List<string> controlNameList = new List<string>();
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            //this._controlScreenSkin.LoadSkin();
            //this._controlScreenSkin.SettingScreenSkin(this);

			this.uGrid_Result.DataSource = this._inventoryUpdateAcs.DataView;
			this.uGrid_ErrorList.DataSource = this._inventoryUpdateAcs.ErrorDataView;

            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			// ���_�R���{�{�b�N�X�̃A�C�e����ݒ肷��
			this._inventoryUpdateAcs.SetSectionComboEditor(ref this.tComboEditor_SectionCode, false);
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/

            // �{�Ћ@�\�`�F�b�N
            // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            //if (this._inventoryUpdateAcs.IsMainOfficeFunc())
            //{
            //    this.tComboEditor_SectionCode.Enabled = true;
            //}
            //else
            //{
            //    this.tComboEditor_SectionCode.Enabled = false;
            //}

            // 2008.12.25 [9572]
            //if (this._inventoryUpdateAcs.IsMainOfficeFunc())
            //{
                // ---DEL 2009/05/22 �s��Ή�[13263] ------------->>>>>
                //this.tEdit_SectionCode.Enabled = true;
                //this.SectionGuide_Button.Enabled = true;
                // ---DEL 2009/05/22 �s��Ή�[13263] -------------<<<<<
            //}
            //else
            //{
            //    this.tEdit_SectionCode.Enabled = false;
            //    this.SectionGuide_Button.Enabled = false;
            //}
            // 2008.12.25 [9572]
            // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

			/// ��ʂ�����������B
			this.Clear();

			this.timer_InitFocusSetting.Enabled = true;
        }

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				// �I����
				case "tDateEdit_InventoryDay":
				{
					break;
				}
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �������ʃO���b�h���C�A�E�g�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
			{
				// �S�Ă̗�����������\���ɂ���B
				col.Hidden = true;
				col.CellAppearance.TextHAlign = HAlign.Left;
				col.CellAppearance.ImageHAlign = HAlign.Left;
				col.CellAppearance.ImageVAlign = VAlign.Middle;
			}

			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockUnitPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockTotalColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            // 2008.02.26 �ǉ� >>>>>>>>>>>>>>>>>>>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockTotalColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            // 2008.02.26 �ǉ� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;

			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.FontData.Bold = DefaultableBoolean.True;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            //string moneyFormat = "#,##0;-#,##0;0";
            string moneyFormat = "#,##0.00;-#,##0.00;0.00";
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockUnitPriceColumn.ColumnName].Format = moneyFormat;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockTotalColumn.ColumnName].Format = moneyFormat;
            // 2008.02.26 �ǉ� >>>>>>>>>>>>>>>>>>>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockTotalColumn.ColumnName].Format = moneyFormat;
            // 2008.02.26 �ǉ� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockCntColumn.ColumnName].Format = moneyFormat;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName].Format = moneyFormat;

			// ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

			// ��\����ԃR���N�V�����N���X���C���X�^���X��
			this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.Inventory);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Result.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Hidden = false;
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
				}
			}

			// �Z���̌���
			List<string> mergedColumnList = new List<string>();
			mergedColumnList.Add(this._dataSet.Inventory.GoodsNoColumn.ColumnName);
			mergedColumnList.Add(this._dataSet.Inventory.GoodsNameColumn.ColumnName);

			foreach (string key in mergedColumnList)
			{
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorGoodsCode();
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}

			List<string> mergedColumnListWarehouseCode = new List<string>();
			mergedColumnListWarehouseCode.Add(this._dataSet.Inventory.WarehouseNameColumn.ColumnName);

			foreach (string key in mergedColumnListWarehouseCode)
			{
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorWarehouseCode();
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}

            //�O���b�h�ݒ�
            this.ResultGridDisp(); // ADD 2011/01/11
        }

		/// <summary>
		/// �G���[�\���O���b�h���C�A�E�g�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_ErrorList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns)
			{
				// �S�Ă̗�����������\���ɂ���B
				col.Hidden = true;
				col.CellAppearance.TextHAlign = HAlign.Left;
				col.CellAppearance.ImageHAlign = HAlign.Left;
				col.CellAppearance.ImageVAlign = VAlign.Middle;
			}

			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].Hidden = false;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].Hidden = false;
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].Hidden = false;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].Hidden = false;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].Hidden = false;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].Hidden = false;

			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].Width = 150;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].Width = 220;
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].Width = 170;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].Width = 170;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].Width = 100;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].Width = 345;

			int visiblePosition = 0;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;

			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;

			// �Z���̌���
			List<string> mergedColumnListErrorGoodsCode = new List<string>();
			mergedColumnListErrorGoodsCode.Add(this._dataSet.ErrorData.GoodsNoColumn.ColumnName);
			mergedColumnListErrorGoodsCode.Add(this._dataSet.ErrorData.GoodsNameColumn.ColumnName);

			foreach (string key in mergedColumnListErrorGoodsCode)
			{
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorGoodsCode();
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}

			List<string> mergedColumnListWarehouseCode = new List<string>();
			mergedColumnListWarehouseCode.Add(this._dataSet.ErrorData.WarehouseNameColumn.ColumnName);

			foreach (string key in mergedColumnListWarehouseCode)
			{
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorWarehouseCode();
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}
        }

		/// <summary>
		/// �c�[���o�[�c�[���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
                // �I���{�^��
				case "ButtonTool_Close":
				{
					this.Close();
					break;
				}
                // �ߕs���X�V�{�^��
				case "ButtonTool_Save":
				{
                    // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
                    //if (this.ErrorCheck(false))
                    //{
                    //    if (this.Save(true))
                    //    {
                    //        this.Clear();
                    //        this.timer_InitFocusSetting.Enabled = true;
                    //    }
                    //}
                    // --- DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
                    //if (Save())
                    //{
                    //    Clear();
                    //    this.timer_InitFocusSetting.Enabled = true;
                    //}
                    // --- DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<
                    // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
                    //�u���o�v�{�^���ɂ��A�f�[�^���P���ȏ�擾�����ꍇ�́A�����̗���ɏ]���A��ʒ��o�f�[�^�����ɉߕs���X�V�������s���B
                    if (this.uGrid_Result.Rows.Count != 0)
                    {
                        if (Save())
                        {
                            Clear();
                            this.timer_InitFocusSetting.Enabled = true;
                        }
                    }
                    // �f�[�^��0���擾�����ꍇ�́A�ߕs���X�V�������s���B
                    else 
                    {
                        if (TolerancUpdate())
                        {
                            Clear();
                            this.timer_InitFocusSetting.Enabled = true;
                        }
                    }
                    // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<
                    // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

					break;
				}
                // �N���A�{�^��
				case "ButtonTool_Clear":
				{
					this.Clear();
					this.timer_InitFocusSetting.Enabled = true;
					break;
				}
                // ���o�{�^��
				case "ButtonTool_Search":
				{
                    // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
                    //// 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    ////this.Search(this.tComboEditor_SectionCode.Value.ToString(), this.tDateEdit_InventoryDay.GetDateTime(), this.tDateEdit_InventoryDayEnd.GetDateTime(), Convert.ToInt32(this.ultraOptionSet_DifCntExtraDiv.Value));
                    //this.Search(this.tComboEditor_SectionCode.Value.ToString(),
                    //            this.tDateEdit_InventoryDay.GetDateTime(),
                    //            // 2008.02.26 �폜 >>>>>>>>>>>>>>>>>>>>
                    //            //this.tDateEdit_InventoryDayEnd.GetDateTime(),
                    //            // 2008.02.26 �폜 <<<<<<<<<<<<<<<<<<<<
                    //            Convert.ToInt32(this.ultraOptionSet_DifCntExtraDiv.Value),
                    //            this.tEdit_WarehouseCode_St.DataText,
                    //            this.tEdit_WarehouseCode_Ed.DataText,
                    //            this.tEdit_WarehouseShelfNo_St.DataText,
                    //            this.tEdit_WarehouseShelfNo_Ed.DataText);
                    //// 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

                    Search();
                    // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

					break;
				}
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // �G���[�`�F�b�N�{�^��
            case "ButtonTool_ShowError":
            {
                this.ErrorCheck(true);
                break;
            }
            // �G���[������{�^��
            case "ButtonTool_Print":
            {
                this.Print();
                break;
            }
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        }
		}

		/// <summary>
		/// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �I�����̏����\�����@�̕ύX</br>
		private void timer_InitFocusSetting_Tick(object sender, EventArgs e)
		{
			this.timer_InitFocusSetting.Enabled = false;

            // ---DEL 2009/05/22 �s��Ή�[13263] --------------------------------------------------------->>>>>
            //// --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            ////this.tDateEdit_InventoryDay.Focus();
            //this.tEdit_SectionCode.Focus();
            //// --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<
            // ---DEL 2009/05/22 �s��Ή�[13263] ---------------------------------------------------------<<<<<
            this.tDateEdit_InventoryDay.Focus();        //ADD 2009/05/22 �s��Ή�[13263]

            // 2007.09.20 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // ��ʏ����ݒ菈��
            //�A�C�R��(��) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            //�q�ɃK�C�h
            this.WarehouseGuideSt_Button.ImageList = imageList16;
            this.WarehouseGuideEd_Button.ImageList = imageList16;
            this.WarehouseGuideSt_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuideEd_Button.Appearance.Image = Size16_Index.STAR1;
            // ---DEL 2009/05/22 �s��Ή�[13263] --------------------------------------------------------->>>>>
            //// --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            //this.SectionGuide_Button.ImageList = imageList16;
            //this.SectionGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //// --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<
            // ---DEL 2009/05/22 �s��Ή�[13263] ---------------------------------------------------------<<<<<
            // 2007.09.20 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // �R���g���[���T�C�Y�ݒ�
            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            //this.tEdit_SectionCode.Size = new Size(28, 24);               //DEL 2009/05/22 �s��Ή�[13263]
            //this.tEdit_SectionName.Size = new Size(131, 24);              //DEL 2009/05/22 �s��Ή�[13263]
            this.tEdit_WarehouseCode_St.Size = new Size(52, 24);
            this.tEdit_WarehouseCode_Ed.Size = new Size(52, 24);
            this.tEdit_WarehouseShelfNo_St.Size = new Size(76, 24);
            this.tEdit_WarehouseShelfNo_Ed.Size = new Size(76, 24);
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

            // 2008.02.26 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //�Ώ۔N�����ɍŏI�I�������������t���Z�b�g
            //�����f�[�^�擾
            DataSet prtIvntHisDataSet;
            DataView dv = new DataView();
            DataView dvSection = new DataView(); // ADD 2009/12/03
            this._inventoryPrepareAcs.Read(out prtIvntHisDataSet);
            dv.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            dvSection.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table]; // ADD 2009/12/03

            // --- DEL 2009/12/03 ---------->>>>>
            //for (int ix = 0; ix < dv.Count; ix++)
            //{
            //    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
            //    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
            //        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
            //    {
            //        this.tDateEdit_InventoryDay.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
            //        break;
            //    }
            //}
            // --- DEL 2009/12/03 ----------<<<<<

            // --- ADD 2009/12/03 ---------->>>>>
            // ���O�C�����_
            dvSection.RowFilter = String.Format("{0}={1}", InventoryPrepareAcs.ctSectionCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            // �\�[�g���F�X�V���t
            dvSection.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";
            // ���O�C�����_�ɊY������f�[�^�L��F���O�C�����_�ɊY������ŐV�f�[�^����I�������擾
            if (dvSection.Count > 0)
            {
                foreach (DataRowView drv in dvSection)
                {
                    // �폜���������f�[�^�͑ΏۊO
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.tDateEdit_InventoryDay.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // ���O�C�����_�ɊY������f�[�^�����F���_�Ɋ֌W�Ȃ��ŐV�f�[�^����I�������擾
            else
            {
                // �\�[�g���F�X�V���t
                dv.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";

                for (int ix = 0; ix < dv.Count; ix++)
                {
                    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.tDateEdit_InventoryDay.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // 2008.02.26 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // --- ADD 2009/12/03 ----------<<<<<
        }

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ����f�[�^�O���b�h�Z���A�N�e�B�u��C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
		{
			//
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// ����f�[�^�O���b�h�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_Enter(object sender, EventArgs e)
		{
			UltraGridRow row = this.uGrid_Result.ActiveRow;

			//if (row != null)
			{
				if (this.uGrid_Result.Rows.Count > 0)
				{
					this.uGrid_Result.Selected.Rows.Clear();
					this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
					this.uGrid_Result.ActiveRow.Selected = true;
				}
			}
        }

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ����f�[�^�O���b�h���[�u�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_Leave(object sender, EventArgs e)
		{
			this.uStatusBar_Main.Text = "";
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �t�H�[���I���O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note: 2011/01/11 ����</br>
        /// <br>             �I����Q�Ή�</br>
		private void MAHNB04110UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// ��\����ԃN���X���X�g�\�z����
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
			//ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);		// ��

            // �O���b�h�ݒ�ۑ�
            this.SaveGridState(); // ADD 2011/01/11
		}

        // ---------- ADD 2011/01/11 ---------->>>>>
        /// <summary>
        /// �O���b�h�ݒ�ۑ�
        /// </summary>
        public void SaveGridState()
        {
            // �O���b�h�ݒ�ۑ�
            if (this._gridStateController != null)
            {
                this._gridStateController.GetGridStateFromGrid(ref this.uGrid_Result);
                this._gridStateController.SaveGridState(ctFILENAME_COLDISPLAYSTATUS);
            }
        }
        // ---------- ADD 2011/01/11 ----------<<<<<

		/// <summary>
		/// ����f�[�^�O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				{
					if (this.uGrid_Result.ActiveRow != null)
					{
						if (this.uGrid_Result.ActiveRow.Index == 0)
						{
							this.tDateEdit_InventoryDay.Focus();
						}
					}

					break;
				}
			}
		}

		/// <summary>
		/// �O���b�h�\�[�g�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_AfterSortChange(object sender, BandEventArgs e)
		{
			this.NumberingRowNo();
			this.SettingGridRow();
		}

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �O���b�h�}�E�X�G���^�[�G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(UltraGridCell));

			if (oContextCell != null)
			{
			}
        }
        
		/// <summary>
		/// �O���b�h�}�E�X���[���G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Result_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �\���敪�I�v�V�����Z�b�g�I��l�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note: 2010/12/03 �c����</br>
        /// <br>             �ߕs���X�V�{�^���̐���ύX</br>
        /// <br>Update Note: K2015/08/21 �� �I���ߕs���X�V�@�������A�E�g�̏C��</br>
        /// <br>             Redmine#46790�̑Ή�</br>
        private void ultraOptionSet_DifCntExtraDiv_ValueChanged(object sender, EventArgs e)
        {
            //this.ultraOptionSet_DifCntExtraDiv.ValueChanged -= new System.EventHandler(this.ultraOptionSet_DifCntExtraDiv_ValueChanged);

            // ---------- UPD 2010/12/03 ------------------------>>>>>
            //if (this._inventoryUpdateAcs.GetRowCount() == 0) return;
            if (this._inventoryUpdateAcs.GetRowCount() == 0)
            {
               // this._saveButton.SharedProps.Enabled = false;// DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
                this._saveButton.SharedProps.Enabled = true; // ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��
                return;
            }
            else 
            {
                this._saveButton.SharedProps.Enabled = true;
            }
            // ---------- UPD 2010/12/03 ------------------------<<<<<

			int difCntExtraDiv = Convert.ToInt32(this.ultraOptionSet_DifCntExtraDiv.Value);
			this._inventoryUpdateAcs.Filtering(difCntExtraDiv);
			this.NumberingRowNo();

			if ((difCntExtraDiv == 1) && (this._inventoryUpdateAcs.GetViewRowCount() == 0))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�ߕs�����������Ă���I���f�[�^�͑��݂��܂���B",
					0,
					MessageBoxButtons.OK);
			}

			//this.ultraOptionSet_DifCntExtraDiv.ValueChanged -= new System.EventHandler(this.ultraOptionSet_DifCntExtraDiv_ValueChanged);
		}

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
		# endregion

        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
        #region �K�C�h�{�^���N���b�N�C�x���g

        #region �q�ɃK�C�h
        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.20</br>
        /// </remarks>    
        private void WarehouseGuideButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouseData = null;

                // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
                //if (this._warehouseGuide == null)
                //{
                //    this._warehouseGuide = new WarehouseAcs();
                //}

                //int status = this._warehouseGuide.ExecuteGuid(out warehouseData, this._enterpriseCode, this.tComboEditor_SectionCode.Value.ToString());
                int status = this._warehouseGuide.ExecuteGuid(out warehouseData, this._enterpriseCode);
                // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

                if (status == 0)
                {
                    if (warehouseData != null)
                    {
                        //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                        if ((UltraButton)sender == this.WarehouseGuideSt_Button)
                        {
                            //�J�n
                            this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                            this.tEdit_WarehouseCode_Ed.Focus();
                        }
                        else
                        {
                            //�I��
                            this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                            this.tEdit_WarehouseShelfNo_St.Focus();
                        }
                    }
                }
                else
                {
                    //�L�����Z���Ȃ̂łȂɂ����Ȃ�
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        #region ���_�K�C�h
        /// <summary>
        /// Button_Click �C�x���g(���_�K�C�h)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            // ---DEL 2009/05/22 �s��Ή�[13263] ---------------------------------------------->>>>>
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    SecInfoSet secInfoSet;

            //    int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            //    if (status == 0)
            //    {
            //        // ���_�R�[�h�ݒ�
            //        this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
            //        // ���_���̐ݒ�
            //        this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

            //        // �t�H�[�J�X�ݒ�
            //        this.tDateEdit_InventoryDay.Focus();
            //    }
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            // ---DEL 2009/05/22 �s��Ή�[13263] ----------------------------------------------<<<<<
        }

        #endregion ���_�K�C�h

        #endregion 
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �R���g���[������t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2011/01/11 ����</br>
        /// <br>    
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ---DEL 2009/05/22 �s��Ή�[13263] --------------------------------------------->>>>>
                //case "tEdit_SectionCode":
                //    if (this.tEdit_SectionCode.DataText.Trim() == "")
                //    {
                //        this.tEdit_SectionName.Clear();
                //        return;
                //    }

                //    string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                //    // ���_���̐ݒ�
                //    this.tEdit_SectionName.DataText = this._inventoryUpdateAcs.GetSectionName(sectionCode);

                //    if (e.ShiftKey == false)
                //    {
                //        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //        {
                //            // �t�H�[�J�X�ݒ�
                //            if (this.tEdit_SectionName.DataText.Trim() != "")
                //            {
                //                e.NextCtrl = this.tDateEdit_InventoryDay;
                //            }
                //        }
                //    }
                //    break;
                // ---DEL 2009/05/22 �s��Ή�[13263] --------------------------------------------->>>>>
                case "tEdit_WarehouseCode_St":
                    // �q�ɃR�[�h�擾
                    string warehouseCodeSt = this.tEdit_WarehouseCode_St.DataText.Trim();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // �t�H�[�J�X�ݒ�
                            //if (warehouseCodeSt != "")
                            //{
                            //    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                            //}
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                    }
                    break;
                case "tEdit_WarehouseCode_Ed":
                    // �q�ɃR�[�h�擾
                    string warehouseCodeEd = this.tEdit_WarehouseCode_Ed.DataText.Trim();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // �t�H�[�J�X�ݒ�
                            //if (warehouseCodeEd != "")
                            //{
                            //    e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                            //}
                            e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            e.NextCtrl = tEdit_WarehouseCode_St;
                        }
                    }
                    break;
                case "tEdit_WarehouseShelfNo_St":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tEdit_WarehouseCode_Ed;
                            }
                        }
                        break;
                    }
                case "uGrid_Result":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.uGrid_Result.ActiveRow == null)
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;          //DEL 2009/05/22 �s��Ή�[13263]
                                    //e.NextCtrl = this.tDateEdit_InventoryDay;       //ADD 2009/05/22 �s��Ή�[13263] //DEL 2011/01/11
                                    e.NextCtrl = this.ckdDepositAutoColumnSize; //ADD 2011/01/11
                                    return;
                                }

                                int rowIndex = this.uGrid_Result.ActiveRow.Index;

                                if (rowIndex == this.uGrid_Result.Rows.Count - 1)
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;          //DEL 2009/05/22 �s��Ή�[13263]
                                    //e.NextCtrl = this.tDateEdit_InventoryDay;       //ADD 2009/05/22 �s��Ή�[13263] //DEL 2011/01/11
                                    e.NextCtrl = this.ckdDepositAutoColumnSize; //ADD 2011/01/11
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Result.Rows[rowIndex].Selected = false;
                                    this.uGrid_Result.Rows[rowIndex + 1].Activate();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Result.ActiveRow == null)
                                {
                                    e.NextCtrl = this.ultraOptionSet_ShelfNoDiv;
                                    return;
                                }

                                int rowIndex = this.uGrid_Result.ActiveRow.Index;

                                if (rowIndex == 0)
                                {
                                    e.NextCtrl = this.ultraOptionSet_ShelfNoDiv;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Result.Rows[rowIndex].Selected = false;
                                    this.uGrid_Result.Rows[rowIndex - 1].Activate();
                                    return;
                                }
                            }
                        }
                        break;
                    }
                // ---------- ADD 2011/01/11 ---------->>>>>
                case "ckdDepositAutoColumnSize":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.uGrid_Result;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.FontSize_tComboEditor;
                            }
                        }
                        break;
                    }
                case "FontSize_tComboEditor":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.ckdDepositAutoColumnSize;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.tDateEdit_InventoryDay;
                            }
                        }
                        break;
                    }
                case "tDateEdit_InventoryDay":
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = ultraOptionSet_DifCntExtraDiv;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab || (e.Key == Keys.Enter))
                        {
                            e.NextCtrl = FontSize_tComboEditor;
                        }
                    }
                    break;
                case "ultraOptionSet_ShelfNoDiv":
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.uGrid_Result.Rows.Count == 0)
                            {
                                e.NextCtrl = ckdDepositAutoColumnSize;
                            }
                            else
                            {
                                e.NextCtrl = this.uGrid_Result;
                            }
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            e.NextCtrl = tEdit_WarehouseShelfNo_Ed;
                        }
                    }
                    break;
                // ---------- ADD 2011/01/11 ----------<<<<<
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "uGrid_Result":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (uGrid_Result.Rows.Count == 0)
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;          //DEL 2009/05/22 �s��Ή�[13263]
                                    e.NextCtrl = this.tDateEdit_InventoryDay;       //ADD 2009/05/22 �s��Ή�[13263]
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (uGrid_Result.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.ultraOptionSet_ShelfNoDiv;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        private void uGrid_Result_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveRow == null)
            {
                return;
            }

            this.uGrid_Result.Rows[this.uGrid_Result.ActiveRow.Index].Selected = false;
            this.uGrid_Result.ActiveRow = null;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // ---------- ADD 2011/01/11 ---------->>>>>
        /// <summary>
        /// CheckedChanged�C�x���g(ckdDepositAutoColumnSize)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">KeyPress�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
        private void ckdDepositAutoColumnSize_CheckedChanged(object sender, EventArgs e)
        {
            // �O���b�h��T�C�Y�ύX�X���b�h�X�^�[�g
            Thread depositGridColumnSizeChangeThread = new Thread(new ParameterizedThreadStart(DepositGridColumnSizeChange));
            depositGridColumnSizeChangeThread.Start((object)this.ckdDepositAutoColumnSize.Checked);
        }

        #region �O���b�h�\����T�C�Y�ύX����
        /// <summary>
        /// �O���b�h�\����T�C�Y�ύX����
        /// </summary>
        private void DepositGridColumnSizeChange(object parameter)
        {
            bool check = (bool)parameter;

            // �O���b�h�񕝂̃I�[�g�ݒ�
            if (check == true)
            {
                this.uGrid_Result.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                return;
            }
            else
            {
                this.uGrid_Result.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }

            // �񕝂̒���
            try
            {
                this.uGrid_Result.BeginUpdate();

                for (int i = 0; i < this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(PerformAutoSizeType.VisibleRows, true);
                }
            }
            finally
            {
                this.uGrid_Result.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region ValueChanged�C�x���g(FontSize_tComboEditor)
        /// <summary>
        /// FontSize_tComboEditor.ValueChanged�C�x���g(FontSize_tComboEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">ValueChanged�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �����T�C�Y��ύX
            this.uGrid_Result.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.FontSize_tComboEditor.SelectedItem.DataValue;
        }

        #region InitializeRow�C�x���g(PrepareHistory_Grid)

        /// <summary>
        /// InitializeRow�C�x���g(uGrid_Result)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">KeyPress�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
        private void UGrid_Result_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            //�O���b�h�̂P�s����
            e.Row.Height = 10;
            e.Row.Appearance.BackGradientStyle = GradientStyle.Vertical;

            e.Row.Activation = Activation.NoEdit;
            e.Row.Appearance.Cursor = Cursors.Arrow;
        }
        #endregion

        #region �O���b�h�`��ݒ�
        /// <summary>
        /// �O���b�h�`��ݒ�
        /// </summary>
        private void ResultGridDisp()
        {
            // ���̏����́A�O���b�h�Ƀf�[�^���o�C���h���ăv���p�e�B�̐ݒ��S�ďI������ɍs���B
            // �O���b�h�̐ݒ������O�ɂ��̏������s���Ɛݒ肪�����������B
            // �O���b�h�ݒ���擾
            GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Result);

            if (gridStateInfo != null)
            {
                // �O���b�h�ݒ�
                this._gridStateController.SetGridStateToGrid(ref this.uGrid_Result);
                this.FontSize_tComboEditor.Value = (int)gridStateInfo.FontSize;
                this.ckdDepositAutoColumnSize.Checked = gridStateInfo.AutoFit;
            }
            else
            {
                this.FontSize_tComboEditor.Value = 11;
                this.ckdDepositAutoColumnSize.Checked = false;
            }
        }
        #endregion

        // ---------- ADD 2011/01/11 ----------<<<<<

        #endregion
    }
}