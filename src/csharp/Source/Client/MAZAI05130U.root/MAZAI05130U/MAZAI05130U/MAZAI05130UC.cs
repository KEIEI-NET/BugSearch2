using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �I�������� ���Ԗ��I�������͉��
	/// </summary>
	/// <remarks>
	/// <br>Note		: �I�������� ���Ԗ��I�������͉��</br>
	/// <br>Programmer	: 22013 kubo</br>
	/// <br>date		: 2007.07.25</br>
	/// </remarks>
	public partial class ProductNumInput : Form
	{
		#region �� Constructor
		/// <summary>
		/// �I�������� ���Ԗ��I�������͉�ʃR���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�������� ���Ԗ��I�������͉�ʂ̃C���X�^���X�𐶐�</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		public ProductNumInput ()
		{
			InitializeComponent();

			// Private member������ -----------------------------------
			this._firstFlag		= true;							// ����N���׸ޏ�����

			this._inventInputAcs = new InventInputAcs();
		}
		#endregion

		#region �� Private Member
		/// <summary> ����N���׸� </summary>
		private bool _firstFlag;
		DataTable _productDTable;// ���͗pTable

		InventInputAcs _inventInputAcs;

		ArrayList _defPrdTelList = new ArrayList();
		#endregion �� Private Member

		#region �� Private Const
		// Toolbar Button Name -----------------------------------
		// MainToolbar Button -----------------------------------
		/// <summary> �m��{�^�� </summary>
		private const string ct_Tool_Enter		= "Tool_Enter";
		/// <summary> �߂�{�^�� </summary>
		private const string ct_Tool_Close		= "Tool_Close";

		// DataViewToolbar Button -----------------------------------
		/// <summary> �I�����ꊇ���̓|�b�v�A�b�v���j���[ </summary>
		private const string ct_tool_BatchInvCnt = "tool_BatchInvCnt";
		/// <summary> �I���ꊇ���� - �S�ē��� </summary>
		private const string ct_tool_BIC_AllInput = "tool_BIC_AllInput";
		/// <summary> �I���ꊇ���� - �����͂̂� </summary>
		private const string ct_tool_BIC_NoInput = "tool_BIC_NoInput";
		/// <summary> �I���ꊇ���� - �S�č폜 </summary>
		private const string ct_tool_BIC_AllCansel = "tool_BIC_AllCansel";

		/// <summary> �I�����ꊇ�ݒ�|�b�v�A�b�v���j���[ </summary>
		private const string ct_tool_BatchInvDay = "tool_BatchInvDay";
		/// <summary> �I�����ꊇ�ݒ� - �S�ē��� </summary>
		private const string ct_tool_BID_AllInput = "tool_BID_AllInput";
		/// <summary> �I�����ꊇ�ݒ� - �����͂̂� </summary>
		private const string ct_tool_BID_NoInput = "tool_BID_NoInput";
		/// <summary> �I�����ꊇ�ݒ� - �S�č폜 </summary>
		private const string ct_tool_BID_AllCansel = "tool_BID_AllCansel";
	
		// Sort Order -----------------------------------
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> �\�[�g�擪����(����Asc) </summary>
		//private const string ct_SortOrder = InventInputResult.ct_Col_ProductNumber;
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

		// else -----------------------------------
		/// <summary> Class FullName </summary>
		private const string ct_ClassFullName = "Broadleaf.Windows.Forms.MAZAI05130UC";
		/// <summary> Class Name </summary>
		private const string ct_ClassName = "MAZAI05130UC";

		private Form _parentForm;
		#endregion �� Private Const

		#region �� Public Property
		/// <summary>
		/// �ύX�O���ԁA�d�b�ԍ����X�g
		/// </summary>
		public ArrayList DefPrdTelList
		{
			set{this._defPrdTelList = value;}
		}
		#endregion

		#region �� Public Method
		#region �� ���Ԗ��I�������͉�ʋN�����\�b�h
		/// <summary>
		/// ���Ԗ��I�������͉�ʋN�����\�b�h
		/// </summary>
		/// <param name="productNumArray">���Ԋi�[</param>
		/// <param name="addNewRowCount">�V�K�ǉ��s��</param>
		/// <param name="parent">�e�t�H�[��</param>
		/// <returns>Status(MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: ���Ԗ��I�������͉�ʂ��N������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		public int ShowProductInventInput ( out ArrayList productNumArray, double addNewRowCount, Form parent )
		{
            productNumArray = new ArrayList();
			
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			try
			{
				this._parentForm = parent;

				string message = string.Empty;

				InventInputResult.CreateDataTable( ref this._productDTable );
				DataRow addRow = null;
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //InventoryDataUpdateWork invWork = null;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                for (int tableIndex = 0; tableIndex < addNewRowCount; tableIndex++)
				{
					addRow = this._productDTable.NewRow();
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //addRow[InventInputResult.ct_Col_ProductStockGuid] = Guid.NewGuid();
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    addRow[InventInputResult.ct_Col_RowSelf] = addRow;

                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if (this._defPrdTelList != null && this._defPrdTelList.Count > 0 && tableIndex < this._defPrdTelList.Count)
					//{
					//	invWork = (InventoryDataUpdateWork)this._defPrdTelList[tableIndex];
					//	addRow[InventInputResult.ct_Col_ProductNumber] = invWork.ProductNumber;
					//	addRow[InventInputResult.ct_Col_StockTelNo1] = invWork.StockTelNo1;
					//	addRow[InventInputResult.ct_Col_StockTelNo2] = invWork.StockTelNo2;
					//}
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    this._productDTable.Rows.Add(addRow);
				}

				// �����\���ʒu��e�R���g���[���̒��S�ɔz�u�B���̌�TMemPos���i�ɂ��z�u�ꏊ�͕ύX�����B
				this.StartPosition = FormStartPosition.CenterParent;
				
//				this.InitialScreen( );

				// �[�������͉�ʋN��
				DialogResult formResult = this.ShowDialog();

				foreach( UltraGridRow ultraGridRow in this.ug_ProductInventInput.Rows )
				{
					productNumArray.Add ( (DataRow)ultraGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value );
				}
				// DialogResult����߂�l��ݒ�
				switch ( formResult )
				{
					case DialogResult.OK:		
						{
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						}
					case DialogResult.Cancel:	{ status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;	break; }
					default:					{ status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;	break; }
				}
            }
			catch( Exception ex )
			{
				status = -1;
				MsgDispProc( 
					"�����ԍ����͏����ɂăG���[���������܂����B\r\n", 
					status, 
					"ShowProductInventInput", 
					ex, 
					emErrorLevel.ERR_LEVEL_STOPDISP);
			}
			return status;
		}
		#endregion
		#endregion  �� Public Method

		#region �� Private Method
		#region �� �������������C��
		/// <summary>
		/// �������������C��
		/// </summary>
		/// <returns>Status(MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: ��ʏ��������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private int InitialScreen ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				// ����N�����̂݉�ʐݒ�
				if ( this._firstFlag  )
				{
					// Toolbars Setting
					InitialToolBarsSetting();

					// StatusBarsSetting
					InitializeStatusBarSetting();

					// UIGrid�Ƀf�[�^���o�C���h
					this.ug_ProductInventInput.DataSource = this._productDTable;

					// �O���b�h�L�[�}�b�s���O�쐬
					this.MakeGridKeyMapping( this.ug_ProductInventInput);

					// Grid Setting
					this.InitialInventInputGrid( this.ug_ProductInventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput] );

			        // �񕝂��I�[�g�ɐݒ�
			        this.ug_ProductInventInput.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

					// �C���N�������g���ď����������Ȃ��悤�ɂ���B
					this._firstFlag = false;
				}

                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //if (this.ug_ProductInventInput.Rows.Count > 0)
				//{
				//    //this.ug_ProductInventInput.Focus();
				//	this.ug_ProductInventInput.Rows[0].Cells[InventInputResult.ct_Col_ProductNumber].Activate();
                //
				//	//this.ug_ProductInventInput.PerformAction(UltraGridAction.EnterEditMode);
				//}
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			}
			finally
			{
			}

			return status;
		}
		#endregion

		#region �� �c�[���o�[�ݒ菈��
		/// <summary>
		/// �c�[���o�[�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̐ݒ���s���B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialToolBarsSetting ()
		{
			// �A�C�R�����X�g�o�^ ==============================================================3
			this.utm_MainToolBarsMng.ImageListSmall = IconResourceManagement.ImageList16;		// MainToolbar

			// MainToolBar ButtonImage Setting -----------------------------------------------
			// �m��{�^��
			ToolBarButtonToolImageSetting(utm_MainToolBarsMng, ct_Tool_Enter,		Size16_Index.DECISION);
			// �߂�{�^��
			ToolBarButtonToolImageSetting(utm_MainToolBarsMng, ct_Tool_Close,		Size16_Index.BEFORE);

			// DataViewToolBar ButtonImage Setting -----------------------------------------------

		}
		#endregion

		#region �� �c�[���o�[�{�^���A�C�R���ݒ菈��
		/// <summary>
		/// �c�[���o�[�{�^���A�C�R���ݒ菈��
		/// </summary>
		/// <param name="targetToolBar">�ݒ�Ώۃc�[���o�[</param>
		/// <param name="buttonName">�{�^������</param>
		/// <param name="iconIndex">IconResourceManagement</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�{�^���̃A�C�R���̐ݒ���s���B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ToolBarButtonToolImageSetting ( 
			Infragistics.Win.UltraWinToolbars.UltraToolbarsManager targetToolBar, string buttonName, Size16_Index iconIndex )
		{
			// �{�^���I�u�W�F�N�g�̎擾
			Infragistics.Win.UltraWinToolbars.ButtonTool btnObject = targetToolBar.Tools[buttonName] as Infragistics.Win.UltraWinToolbars.ButtonTool;
			if ( btnObject != null )
			{
				btnObject.SharedProps.AppearancesSmall.Appearance.Image = iconIndex;
			}
		}
		#endregion

		#region �� �X�e�[�^�X�o�[��������
		/// <summary>
		/// �X�e�[�^�X�o�[����������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �X�e�[�^�X�o�[���������s��</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitializeStatusBarSetting ()
		{
			// �t�H���g�T�C�Y�ύX�R���{�{�b�N�X�̐ݒ�
			this.tce_FontSize.MaxDropDownItems = this.tce_FontSize.Items.Count;
			this.tce_FontSize.Value = 11;
		}

		#endregion

		#region �� �f�[�^�\��UltraGrid��������
		/// <summary>
		/// �f�[�^�\��UltraGrid��������
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			// ��U���ׂĂ̗���\���ɂ��A�\���ʒu�𓝈ꂳ����
			foreach( UltraGridColumn column in band.Columns ) {
				column.Hidden = true;
				column.CellAppearance.TextHAlign  = HAlign.Left;
				column.CellAppearance.ImageHAlign = HAlign.Left;
				column.CellAppearance.ImageVAlign = VAlign.Middle;
			}

			//band.Columns[ InventInputResult.ct_Col_ProductNumber ]

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
			this.InitialInventInputGrid_Hidden( band );				// �\����Ԑݒ�
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
            this.InitialInventInputGrid_Tag( band );				// Tag
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
			this.InitialInventInputGrid_CellActivation( band );		// ���͐ݒ�
			this.InitialInventInputGrid_Width( band );				// ���ݒ�
			this.InitialInventInputGrid_CellClickAction( band );	// CellClickAction
			this.InitialInventInputGrid_TabStop( band );			// TabStop
            this.InitialInventInputGrid_GroupSetting( band );		// GroupSetting
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            // ��w�b�_���\���ɂ���B
			band.ColHeadersVisible = false;

			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].CharacterCasing = CharacterCasing.Upper;

			this.ug_ProductInventInput.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
			this.ug_ProductInventInput.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;

			
			//// ��w�b�_���\���ɂ���B
			//band.ColHeadersVisible = false;
		}
		#endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� �f�[�^�\��UltraGrid��������(Hidden�v���p�e�B)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(Hidden�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_Hidden( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// �\����Ԑݒ�(Hidden)
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �\������ ------------------------------------------------------
			//// �����ԍ�
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Hidden = false;
			//// �d�b�ԍ�1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Hidden = false;
			//// �d�b�ԍ�2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Hidden = false;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			#endregion
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� �f�[�^�\��UltraGrid��������(Tag�v���p�e�B)
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(Tag�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_Tag( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// �\����Ԑݒ�(Tag)
			// �\������ ------------------------------------------------------
			// �쐬����
			band.Columns[ InventInputResult.ct_Col_CreateDateTime ].Tag = InventInputResult.ct_Col_CreateDateTime;
			// �X�V����
			band.Columns[ InventInputResult.ct_Col_UpdateDateTime ].Tag = InventInputResult.ct_Col_UpdateDateTime;
			// ��ƃR�[�h
			band.Columns[ InventInputResult.ct_Col_EnterpriseCode ].Tag = InventInputResult.ct_Col_EnterpriseCode;
			// GUID
			band.Columns[ InventInputResult.ct_Col_FileHeaderGuid ].Tag = InventInputResult.ct_Col_FileHeaderGuid;
			// �X�V�]�ƈ��R�[�h
			band.Columns[ InventInputResult.ct_Col_UpdEmployeeCode ].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
			// �X�V�A�Z���u��ID1
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId1 ].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
			// �X�V�A�Z���u��ID2
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId2 ].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
			// �_���폜�敪
			band.Columns[ InventInputResult.ct_Col_LogicalDeleteCode ].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
			// ���_�R�[�h
			band.Columns[ InventInputResult.ct_Col_SectionCode ].Tag = InventInputResult.ct_Col_SectionCode;
			// ���_�K�C�h����
			band.Columns[ InventInputResult.ct_Col_SectionGuideNm ].Tag = InventInputResult.ct_Col_SectionGuideNm;
			// �I���ʔ�
			band.Columns[ InventInputResult.ct_Col_InventorySeqNo ].Tag = InventInputResult.ct_Col_InventorySeqNo;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԍ݌Ƀ}�X�^GUID
			//band.Columns[ InventInputResult.ct_Col_ProductStockGuid ].Tag = InventInputResult.ct_Col_ProductStockGuid;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // �q�ɃR�[�h
			band.Columns[ InventInputResult.ct_Col_WarehouseCode ].Tag = InventInputResult.ct_Col_WarehouseCode;
			// �q�ɖ���
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Tag = InventInputResult.ct_Col_WarehouseName;
            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // �d���I�ԂP
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // �d���I�ԂQ
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // ���[�J�[�R�[�h
			band.Columns[ InventInputResult.ct_Col_MakerCode ].Tag = InventInputResult.ct_Col_MakerCode;
			// ���[�J�[����
			band.Columns[ InventInputResult.ct_Col_MakerName ].Tag = InventInputResult.ct_Col_MakerName;
			// �i��
			band.Columns[ InventInputResult.ct_Col_GoodsNo ].Tag = InventInputResult.ct_Col_GoodsNo;
			// �i��
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Tag = InventInputResult.ct_Col_GoodsName;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �@��R�[�h
            //band.Columns[ InventInputResult.ct_Col_CellphoneModelCode ].Tag = InventInputResult.ct_Col_CellphoneModelCode;
            //// �@�햼��
            //band.Columns[ InventInputResult.ct_Col_CellphoneModelName ].Tag = InventInputResult.ct_Col_CellphoneModelName;
            //// �L�����A�R�[�h
            //band.Columns[ InventInputResult.ct_Col_CarrierCode ].Tag = InventInputResult.ct_Col_CarrierCode;
            //// �L�����A����
            //band.Columns[ InventInputResult.ct_Col_CarrierName ].Tag = InventInputResult.ct_Col_CarrierName;
            //// �n���F�R�[�h
            //band.Columns[ InventInputResult.ct_Col_SystematicColorCd ].Tag = InventInputResult.ct_Col_SystematicColorCd;
            //// �n���F����
            //band.Columns[ InventInputResult.ct_Col_SystematicColorNm ].Tag = InventInputResult.ct_Col_SystematicColorNm;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���i�啪�ރR�[�h
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreCode ].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
			// ���i�啪�ޖ���
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreName ].Tag = InventInputResult.ct_Col_LargeGoodsGanreName;
			// ���i�����ރR�[�h
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreCode ].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
			// ���i�����ޖ���
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreName ].Tag = InventInputResult.ct_Col_MediumGoodsGanreName;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ҃R�[�h
            //band.Columns[ InventInputResult.ct_Col_CarrierEpCode ].Tag = InventInputResult.ct_Col_CarrierEpCode;
            //// ���ƎҖ���
            //band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Tag = InventInputResult.ct_Col_CarrierEpName;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���Ӑ�R�[�h
			band.Columns[ InventInputResult.ct_Col_CustomerCode ].Tag = InventInputResult.ct_Col_CustomerCode;
			// ���Ӑ於��
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Tag = InventInputResult.ct_Col_CustomerName;
			// ���Ӑ於��2
			band.Columns[ InventInputResult.ct_Col_CustomerName2 ].Tag = InventInputResult.ct_Col_CustomerName2;
			// �ϑ���R�[�h
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// �ϑ��於��
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// �ϑ��於��2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d����
            //band.Columns[ InventInputResult.ct_Col_StockDate ].Tag = InventInputResult.ct_Col_StockDate;
            //// ���ד�
            //band.Columns[ InventInputResult.ct_Col_ArrivalGoodsDay ].Tag = InventInputResult.ct_Col_ArrivalGoodsDay;
            //// �����ԍ�
            //band.Columns[ InventInputResult.ct_Col_ProductNumber ].Tag = InventInputResult.ct_Col_ProductNumber;
            //// ���i�d�b�ԍ�1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Tag = InventInputResult.ct_Col_StockTelNo1;
            //// �ύX�O���i�d�b�ԍ�1
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ].Tag = InventInputResult.ct_Col_BfStockTelNo1;
            //// ���i�d�b�ԍ�1�ύX�t���O
            //band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo1ChgFlg;
            //// ���i�d�b�ԍ�2
            //band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Tag = InventInputResult.ct_Col_StockTelNo2;
            //// �ύX�O���i�d�b�ԍ�2
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ].Tag = InventInputResult.ct_Col_BfStockTelNo2;
			//// ���i�d�b�ԍ�2�ύX�t���O
			//band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo2ChgFlg;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // JAN�R�[�h
			band.Columns[ InventInputResult.ct_Col_Jan ].Tag = InventInputResult.ct_Col_Jan;
			// �d���P��
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].Tag = InventInputResult.ct_Col_StockUnitPrice;
			// �ύX�O�d���P��
			band.Columns[ InventInputResult.ct_Col_BfStockUnitPrice ].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
			// �d���P���ύX�t���O
			band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
			// �݌ɋ敪
			band.Columns[ InventInputResult.ct_Col_StockDiv ].Tag = InventInputResult.ct_Col_StockDiv;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �݌ɏ��
			//band.Columns[ InventInputResult.ct_Col_StockState ].Tag = InventInputResult.ct_Col_StockState;
			//// �ړ����
			//band.Columns[ InventInputResult.ct_Col_MoveStatus ].Tag = InventInputResult.ct_Col_MoveStatus;
			//// ���i���
			//band.Columns[ InventInputResult.ct_Col_GoodsCodeStatus ].Tag = InventInputResult.ct_Col_GoodsCodeStatus;
			//// ���ԊǗ��敪
			//band.Columns[ InventInputResult.ct_Col_PrdNumMngDiv ].Tag = InventInputResult.ct_Col_PrdNumMngDiv;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // �ŏI�d���N����
			band.Columns[ InventInputResult.ct_Col_LastStockDate ].Tag = InventInputResult.ct_Col_LastStockDate;
			// �݌ɐ�
			band.Columns[ InventInputResult.ct_Col_StockTotal ].Tag = InventInputResult.ct_Col_StockTotal;
			// �ϑ���R�[�h
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// �ϑ��於��
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// �ϑ��於��2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
			// �I���݌ɐ�
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Tag = InventInputResult.ct_Col_InventoryStockCnt;
			// �I���ߕs����
			band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
			// �I�������������t
            band.Columns[InventInputResult.ct_Col_InventoryPreprDay].Tag = InventInputResult.ct_Col_InventoryPreprDay;
            // �I��������������
			band.Columns[ InventInputResult.ct_Col_InventoryPreprTim ].Tag = InventInputResult.ct_Col_InventoryPreprTim;
			// �I�����{��
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// �I�����{��
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// �I�����{��(DateTime)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Datetime ].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
			// �I�����{��(�N ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].Tag = InventInputResult.ct_Col_InventoryDay_Year;
			// �I�����{��(�N ���x��)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
			// �I�����{��(�� ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Tag = InventInputResult.ct_Col_InventoryDay_Month;
			// �I�����{��(�� ���x��)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
			// �I�����{��(�� ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Tag = InventInputResult.ct_Col_InventoryDay_Day;
			// �I�����{��(�� ���x��)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Tag = InventInputResult.ct_Col_InventoryDay_DayL;

			// �I���X�V��
			band.Columns[ InventInputResult.ct_Col_LastInventoryUpdate ].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
			// �I���V�K�ǉ��敪
			band.Columns[ InventInputResult.ct_Col_InventoryNewDiv ].Tag = InventInputResult.ct_Col_InventoryNewDiv;
			// �I���V�K�ǉ��敪����
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].Tag = InventInputResult.ct_Col_InventoryNewDivName;
			// �݌Ɉϑ�����敪
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
			// �݌Ɉϑ�����敪����
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
			// �W�v�敪
			band.Columns[ InventInputResult.ct_Col_GrossDiv ].Tag = InventInputResult.ct_Col_GrossDiv;
			// �{�^���p�J����
			band.Columns[ InventInputResult.ct_Col_Button ].Tag = InventInputResult.ct_Col_Button;
			// ���s
			band.Columns[ InventInputResult.ct_Col_RowSelf ].Tag = InventInputResult.ct_Col_RowSelf;
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(Tag�v���p�e�B)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>date		: 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_Tag(Infragistics.Win.UltraWinGrid.UltraGridBand band)
        {
            #region// �\����Ԑݒ�(Tag)
            // �\������ ------------------------------------------------------
            // �쐬����
            band.Columns[InventInputResult.ct_Col_CreateDateTime].Tag = InventInputResult.ct_Col_CreateDateTime;
            // �X�V����
            band.Columns[InventInputResult.ct_Col_UpdateDateTime].Tag = InventInputResult.ct_Col_UpdateDateTime;
            // ��ƃR�[�h
            band.Columns[InventInputResult.ct_Col_EnterpriseCode].Tag = InventInputResult.ct_Col_EnterpriseCode;
            // GUID
            band.Columns[InventInputResult.ct_Col_FileHeaderGuid].Tag = InventInputResult.ct_Col_FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            band.Columns[InventInputResult.ct_Col_UpdEmployeeCode].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId1].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId2].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
            // �_���폜�敪
            band.Columns[InventInputResult.ct_Col_LogicalDeleteCode].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
            // ���_�R�[�h
            band.Columns[InventInputResult.ct_Col_SectionCode].Tag = InventInputResult.ct_Col_SectionCode;
            // �I���ʔ�
            band.Columns[InventInputResult.ct_Col_InventorySeqNo].Tag = InventInputResult.ct_Col_InventorySeqNo;
            // �q�ɃR�[�h
            band.Columns[InventInputResult.ct_Col_WarehouseCode].Tag = InventInputResult.ct_Col_WarehouseCode;
            // �q�ɖ���
            band.Columns[InventInputResult.ct_Col_WarehouseName].Tag = InventInputResult.ct_Col_WarehouseName;
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // ���[�J�[�R�[�h
            band.Columns[InventInputResult.ct_Col_MakerCode].Tag = InventInputResult.ct_Col_MakerCode;
            // ���[�J�[����
            band.Columns[InventInputResult.ct_Col_MakerName].Tag = InventInputResult.ct_Col_MakerName;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].Tag = InventInputResult.ct_Col_GoodsNo;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].Tag = InventInputResult.ct_Col_GoodsName;
            // ���i�啪�ރR�[�h
            band.Columns[InventInputResult.ct_Col_LargeGoodsGanreCode].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
            // ���i�����ރR�[�h
            band.Columns[InventInputResult.ct_Col_MediumGoodsGanreCode].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
            // �d����R�[�h
            band.Columns[InventInputResult.ct_Col_SupplierCode].Tag = InventInputResult.ct_Col_SupplierCode;
            // �d���於��
            band.Columns[InventInputResult.ct_Col_SupplierName].Tag = InventInputResult.ct_Col_SupplierName;
            // �d���於��2
            band.Columns[InventInputResult.ct_Col_SupplierName2].Tag = InventInputResult.ct_Col_SupplierName2;
            // JAN�R�[�h
            band.Columns[InventInputResult.ct_Col_Jan].Tag = InventInputResult.ct_Col_Jan;
            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Tag = InventInputResult.ct_Col_StockUnitPrice;
            // �ύX�O�d���P��
            band.Columns[InventInputResult.ct_Col_BfStockUnitPrice].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
            // �d���P���ύX�t���O
            band.Columns[InventInputResult.ct_Col_StkUnitPriceChgFlg].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
            // �݌ɋ敪
            band.Columns[InventInputResult.ct_Col_StockDiv].Tag = InventInputResult.ct_Col_StockDiv;
            // �ŏI�d���N����
            band.Columns[InventInputResult.ct_Col_LastStockDate].Tag = InventInputResult.ct_Col_LastStockDate;
            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Tag = InventInputResult.ct_Col_StockTotal;
            // �ϑ���R�[�h
            band.Columns[InventInputResult.ct_Col_ShipCustomerCode].Tag = InventInputResult.ct_Col_ShipCustomerCode;
            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Tag = InventInputResult.ct_Col_InventoryStockCnt;
            // �I���ߕs����
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            // �I�������������t
            band.Columns[InventInputResult.ct_Col_InventoryPreprDay_Datetime].Tag = InventInputResult.ct_Col_InventoryPreprDay_Datetime;
            // �I��������������
            band.Columns[InventInputResult.ct_Col_InventoryPreprTim].Tag = InventInputResult.ct_Col_InventoryPreprTim;
            // �I�����{��
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // �I�����{��
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // �I�����{��(DateTime)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Tag = InventInputResult.ct_Col_InventoryDay_Year;
            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Tag = InventInputResult.ct_Col_InventoryDay_Month;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Tag = InventInputResult.ct_Col_InventoryDay_Day;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Tag = InventInputResult.ct_Col_InventoryDay_DayL;
            // �I���X�V��
            band.Columns[InventInputResult.ct_Col_LastInventoryUpdate].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDiv].Tag = InventInputResult.ct_Col_InventoryNewDiv;
            // �I���V�K�ǉ��敪����
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Tag = InventInputResult.ct_Col_InventoryNewDivName;
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDiv].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
            // �݌Ɉϑ�����敪����
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
            // �W�v�敪
            band.Columns[InventInputResult.ct_Col_GrossDiv].Tag = InventInputResult.ct_Col_GrossDiv;
            // �{�^���p�J����
            band.Columns[InventInputResult.ct_Col_Button].Tag = InventInputResult.ct_Col_Button;
            // ���s
            band.Columns[InventInputResult.ct_Col_RowSelf].Tag = InventInputResult.ct_Col_RowSelf;
            #endregion
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� �f�[�^�\��UltraGrid��������(CellActivation�v���p�e�B)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(CellActivation�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_CellActivation( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// ���͐ݒ�
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���͐ݒ� ------------------------------------------------------
            //// �����ԍ�
            //SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_ProductNumber );
            //// ���i�d�b�ԍ�1
            //SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo1 );
            //// ���i�d�b�ԍ�2
			//SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(Width�v���p�e�B)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(Width�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_Width( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// ���ݒ�(�R�����g�A�E�g�� )

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// Todo:���ݒ�R�����g�A�E�g�� ------------------------------------------------------
            //// �����ԍ�
            //band.Columns[ InventInputResult.ct_Col_ProductNumber ].Width = 200;
            //// ���i�d�b�ԍ�1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Width = 200;
            //// ���i�d�b�ԍ�2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Width = 200;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion

		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(CellClickAction�v���p�e�B)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(CellClickAction�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_CellClickAction( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// CellClickAction
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// CellClickAction ------------------------------------------------------
            //// �����ԍ�
            //SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_ProductNumber );
            //// ���i�d�b�ԍ�1
            //SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo1 );
            //// ���i�d�b�ԍ�2
			//SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(TabStop�v���p�e�B)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(TabStop�v���p�e�B�֘A)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void InitialInventInputGrid_TabStop( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// TabStop
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
            //band.Columns[ InventInputResult.ct_Col_ProductNumber ].TabStop = true;
            //// �d�b�ԍ�1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].TabStop = true;
            //// �d�b�ԍ�2
            //band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].TabStop = true;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

        #region �� �J�����v���p�e�B�ݒ菈��
        #region �� CellActivation�v���p�e�B�ݒ菈��
        /// <summary>
		/// CellActivation�v���p�e�B�ݒ菈��
		/// </summary>
		/// <param name="columns">�ݒ�ΏۃJ����</param>
		/// <param name="action">�ݒ�l</param>
		/// <param name="columnName">�J������</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void SetCellActivation( ColumnsCollection columns, Infragistics.Win.UltraWinGrid.CellClickAction action, string columnName )
		{
			columns[ columnName ].CellClickAction = action;
		}
		#endregion

		#region �� CellClickAction�v���p�e�B�ݒ菈��
		/// <summary>
		/// CellClickAction�v���p�e�B�ݒ菈��
		/// </summary>
		/// <param name="columns">�ݒ�ΏۃJ����</param>
		/// <param name="activation">�ݒ�l</param>
		/// <param name="columnName">�J������</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void SetCellClickAction( ColumnsCollection columns, Infragistics.Win.UltraWinGrid.Activation activation, string columnName )
		{
			columns[ columnName ].CellActivation = activation;
		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(GroupSetting�v���p�e�B�֘A)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(GroupSetting�v���p�e�B�֘A)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_GroupSetting( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// GroupSetting
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup;
            //
            //// �����ԍ�
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_ProductNumber ), band.Columns[InventInputResult.ct_Col_ProductNumber ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ProductNumber ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_ProductNumber;
            //
            //// �d�b�ԍ�1
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo1 ), band.Columns[InventInputResult.ct_Col_StockTelNo1 ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo1 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo1;
            //
            //// �d�b�ԍ�2
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo2 ), band.Columns[InventInputResult.ct_Col_StockTelNo2 ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo2 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo2;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion
        #endregion �� �J�����v���p�e�B�ݒ菈��
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� �c�[���N���b�N����
        /// <summary>
		/// �c�[���N���b�N����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�c�[���N���b�N�C�x���g�Ŕ��������C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[���N���b�N���ꂽ�Ƃ��̏��������s����B�B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ToolBarsClickProc ( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			string clickButtonKey = e.Tool.Key;
			this.ug_ProductInventInput.PerformAction(UltraGridAction.ExitEditMode);
			try
			{
				switch ( e.Tool.Key )
				{
					case ct_Tool_Enter:			// MainToolBar - �m��
						{
							// ���C����ʂ̃N���[�Y
							this.DialogResult = DialogResult.OK;
							return;
						}
					case ct_Tool_Close:			// MainToolBar - �߂�
						{
							this.Close();
							break;
						}
				}
			}
			catch ( Exception ex )
			{
				this.MsgDispProc( ex.Message, (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "SetAllRowSelecting", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
			}

		}
		#endregion

		#region �� �L�[�}�b�s���O�ݒ菈��
		/// <summary>
		/// �O���b�h�L�[�}�b�s���O�쐬����
		/// </summary>
		/// <param name="grid">�ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�ɑ΂��ăL�[�}�b�s���O���쐬���܂��B</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void MakeGridKeyMapping( UltraGrid grid )
		{
			// wkKeyMapping = new GridKeyActionMapping( 
			//		Keys.Enter,							// �ΏۂƂȂ�Key�B����Key���w�肵���Ƃ��̓�������߂�
			//		UltraGridAction.NextCellByTab,		// �Ώۂ�Key�������ꂽ�Ƃ��̓���
			//		UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox,	// Key��������Ă��ΏۊO�ƂȂ�ꍇ�̎w��
			//		UltraGridState.Cell,				// �����ꂽ��̃O���b�h�̏��
			//		SpecialKeys.All,					// �����ɉ�����Ă���������Key�B(����Key��������Ă���Ɠ�������s���Ȃ��B)
			//		SpecialKeys.Shift );				// �����ɉ�����Ȃ��Ɠ�������Ȃ�Key�B(����Key�𓯎��ɉ������Ƃ���������s����B)

//			grid.KeyActionMappings.Add( wkKeyMapping );

			
			GridKeyActionMapping wkKeyMapping = null;

			// Enter�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.NextCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Shift + Enter�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.PrevCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.AltCtrl, 
				SpecialKeys.Shift );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ���L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Up, 
				UltraGridAction.AboveCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ���L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Down, 
				UltraGridAction.BelowCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageUp�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Prior, 
				UltraGridAction.PageUpCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageDown�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Next, 
				UltraGridAction.PageDownCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Space�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Space, 
				UltraGridAction.ToggleRowSel, 
				0, 
				0, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

		}
		#endregion

		#region �� ���b�Z�[�W�\������
		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="iLevel">�G���[���x��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private DialogResult MsgDispProc( string message, emErrorLevel iLevel )
		{
			// ���b�Z�[�W�\��
			return TMsgDisp.Show( 
				this,                            // �e�E�B���h�E�t�H�[��
				iLevel,                             // �G���[���x��
				this.GetType().ToString(),          // �A�Z���u���h�c�܂��̓N���X�h�c
				message,                            // �\�����郁�b�Z�[�W
				0,                                  // �X�e�[�^�X�l
				MessageBoxButtons.OK );             // �\������{�^��
		}

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="msg">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="proc">���������\�b�hID</param>
		/// <param name="iLevel">�G���[���x��</param>
		/// <remarks>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, emErrorLevel iLevel )
		{
			return TMsgDisp.Show(
				iLevel,						        //�G���[���x��
				"MAZAI05130UC",                       //UNIT�@ID
				"�I������",                            //�v���O��������
				proc,                               //�v���Z�XID
				"",                                 //�I�y���[�V����
				msg,                                //���b�Z�[�W
				status,                             //�X�e�[�^�X
				null,                               //�I�u�W�F�N�g
				MessageBoxButtons.OK,               //�_�C�A���O�{�^���w��
				MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
				);
		}

		/// <summary>
		/// �G���[MSG�\������(Exception)
		/// </summary>
		/// <param name="msg">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="proc">���������\�b�hID</param>
		/// <param name="ex">��O���</param>
		/// <param name="iLevel">�G���[���x��</param>
		/// <remarks>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, Exception ex, emErrorLevel iLevel )
		{
			return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
		}
		#endregion

        #region DEl 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� KeyPress����
		/// <summary>
		/// KeyPress����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g(Grid KeyDown Event��sender)</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		public void KeyPressProc( object sender, ref KeyPressEventArgs e )
		{
			//�A�N�e�B�u�Z��
			Infragistics.Win.UltraWinGrid.UltraGridCell	activeCell = ((UltraGrid)sender).ActiveCell;

			// �O���X�敪
			//�A�N�e�B�u�Z������������
			if (activeCell != null)
			{
				if (activeCell.IsInEditMode == false) return;


                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //switch (activeCell.Column.Key)
				//{
				//	case InventInputResult.ct_Col_ProductNumber			:	// �����ԍ�
				//		// ���͕�������������
				//		if ( Char.IsLower( e.KeyChar ) )
				//		{
				//			e.KeyChar = Char.ToUpper( e.KeyChar );
				//		}
				//		if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false ) == false)
				//		{
				//			e.Handled = true;
				//			return;
				//		}
				//		break;
				//	case InventInputResult.ct_Col_StockTelNo1			:	// �d�b�ԍ�1
				//	case InventInputResult.ct_Col_StockTelNo2			:	// �d�b�ԍ�2
				//		if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false ) == false)
				//		{
				//			e.Handled = true;
				//			return;
				//		}
				//		break;
				//}
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            }	
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEl 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� KeyDownProc����
        /// <summary>
		/// KeyDownProc����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g(Grid KeyDown Event��sender)</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		public void KeyDownProc( object sender, ref KeyEventArgs e )
		{
			// �ҏW���̏ꍇ
			UltraGrid targetGrid = (UltraGrid)sender;
			if( ( targetGrid.ActiveCell != null ) && ( targetGrid.ActiveCell.IsInEditMode == true ) ) 
			{
				// �Z���X�^�C���Ŕ���
				switch( e.KeyData ) 
				{
					case Keys.Up	:	// ���L�[
					{								
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
						// �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Down:
					{
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
						// �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					// ���L�[
					case Keys.Left:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// �ҏW���Ȃ牽�����Ȃ�
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart != 0)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab );
						e.Handled = true;
						break;
					}
					// ���L�[
					case Keys.Right:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// �ҏW���Ȃ牽�����Ȃ�
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart < targetGrid.ActiveCell.Text.Length)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab );
						e.Handled = true;
						break;
					}
					case Keys.Enter:
					{
						// EnterKey�������ꂽ�Ƃ���TRetKeyContorol�Ő��䂳���
						// �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Escape:	// ESC�L�[
					{
						break;
					}
				}
			}
			else
			{
				switch( e.KeyData )
				{
					case Keys.Escape:	// ESC�L�[
					{
						break;
					}

				}
			}
		}
		#endregion

		#region �� ���l���̓`�F�b�N����
		/// <summary>
		/// ���l���̓`�F�b�N����
		/// </summary>
		/// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
		/// <param name="priod">�����_�ȉ�����</param>
		/// <param name="prevVal">���݂̕�����</param>
		/// <param name="key">���͂��ꂽ�L�[�l</param>
		/// <param name="selstart">�J�[�\���ʒu</param>
		/// <param name="sellength">�I�𕶎���</param>
		/// <param name="minusFlg">�}�C�i�X���͉H</param>
		/// <returns>true=���͉�,false=���͕s��</returns>
		public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(key) == true)
			{
			    return true;
			}
			//// ���l�ȊO�́A�m�f
			//if (Char.IsNumber(key) == false)
			//{
			//    return false;
			//}

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string	_strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			//// �}�C�i�X�̃`�F�b�N
			//if (key == '-')
			//{
			//    if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
			//    {
			//        return false;
			//    }
			//}

			// �L�[�������ꂽ���ʂ̕�����𐶐�����B
			_strResult = prevVal.Substring(0, selstart) 
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));

			// �����`�F�b�N�I
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// �����_�ȉ��̃`�F�b�N
			if (priod > 0)
			{
				// �����_�̈ʒu����
				int _pointPos = _strResult.IndexOf('.');

				// �������ɓ��͉\�Ȍ���������I
				int	_Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					// �������̌������v�Z
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion

		#endregion �� Private Method

		#region �� Private Event
		#region �� MAZAI05130UC Event
		#region �� Load Event
		/// <summary>
		/// Load Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void MAZAI05130UC_Load ( object sender, EventArgs e )
		{
			// ��ʏ�������
			InitialScreen();

			this.timer1.Enabled = true;
		}
		#endregion

		#region �� FormClosing Event
		/// <summary>
		/// MAZAI05130UC_FormClosing Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[�����邽�тɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void MAZAI05130UC_FormClosing ( object sender, FormClosingEventArgs e )
		{
		}
		#endregion
		#endregion �� MainForm Event

		#region �� tce_Fontsize ComboBox Event
		#region �� tce_FontSize_ValueChanged Event
		/// <summary>
		/// ValueChanged Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̒l���ύX���ꂽ�Ƃ���������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void tce_FontSize_ValueChanged ( object sender, EventArgs e )
		{
			// �����T�C�Y��ύX
			this.ug_ProductInventInput.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tce_FontSize.Value;
		}
		#endregion
		#endregion �� Timer Event

		#region �� utm_MainToolBarsMng ToolBarsManage Event
		#region �� utm_DataViewToolBarsMng_ToolClick Event
		/// <summary>
		/// utm_DataViewToolBarsMng_ToolClick Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �c�[�����N���b�N���ꂽ�Ƃ���������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void utm_MainToolBarsMng_ToolClick ( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			this.ToolBarsClickProc( sender, e );
		}
		#endregion
		#endregion �� utm_MainToolBarsMng ToolBarsManage Event

		#region �� utm_DataViewToolBarsMng ToolBarsManage Event
		#region �� utm_DataViewToolBarsMng_ToolClick Event
		/// <summary>
		/// utm_DataViewToolBarsMng_ToolClick Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �c�[�����N���b�N���ꂽ�Ƃ���������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void utm_DataViewToolBarsMng_ToolClick ( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			this.ToolBarsClickProc( sender, e );
		}
		#endregion
		#endregion �� utm_DataViewToolBarsMng ToolBarsManage Event

		#region �� ug_ProductInventInput Event
		#region �� InitializeRow
		/// <summary>
		/// InitializeRow Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <returns>�݌ɏ�</returns>
		/// <remarks>
		/// <br>Note		: �s�����������ꂽ�Ƃ��ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_InitializeRow ( object sender, InitializeRowEventArgs e )
		{
		}
		#endregion

		#region �� CellChange Event
		/// <summary>
		/// CellChange Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �ҏW���[�h�ɂ���Z���̒l�����[�U�[���ύX�����Ƃ��ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_CellChange ( object sender, CellEventArgs e )
		{
			//// �A�N�e�B�u�Z�����L��
			//if( this.ug_ProductInventInput.ActiveCell != null )
			//{
			//    // NetAdvantage �s��̂��߂̃��W�b�N
				
			//    // ���݂̃Z�����擾
			//    UltraGridCell currentCell = this.ug_ProductInventInput.ActiveCell;

			//    // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit�̏ꍇ
			//    if ( currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit )
			//    {
			//        // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
			//        if( ( currentCell.Text == null ) || ( currentCell.Text.Trim() == "" ) ) 
			//        {
			//            // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
			//            if ((currentCell.Column.DataType == typeof(Int32)) ||
			//                (currentCell.Column.DataType == typeof(Int64)) ||
			//                (currentCell.Column.DataType == typeof(double)))
			//            {
			//                // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
			//                currentCell.Value = 0;
			//            }
			//        }
			//    }

			//    // �I�������ύX����Ă���ꍇ�ɕύX�t���O��True�ɂ���
			//    if ( currentCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt ) == 0 )
			//    {
			//        this._isChangeInventStcCnt = true;
			//        this._isChangeInventDate = false;
			//    }
			//    // �I�������ύX����Ă���ꍇ�ɂ͕ύX�t���O��True�ɂ���
			//    else if ( ( currentCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year ) == 0 ) || 
			//        ( currentCell.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Month ) == 0 ) || 
			//        ( currentCell.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day ) == 0 ) )
			//    {
			//        this._isChangeInventStcCnt = false;
			//        this._isChangeInventDate = true;
			//    }

			//}
		}
		#endregion

		#region �� CellDataError Event
		/// <summary>
		/// uce_ColSizeAutoSetting_CheckedChanged Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s���Ȓl�����͂��ꂽ��ԂŃZ�����X�V���悤�Ƃ���Ɣ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_CellDataError ( object sender, CellDataErrorEventArgs e )
		{
			// �A�N�e�B�u�Z�����L��
			if( this.ug_ProductInventInput.ActiveCell != null )
			{
				// NetAdvantage �s��̂��߂̃��W�b�N
				
				// ���݂̃Z�����擾
				UltraGridCell currentCell = this.ug_ProductInventInput.ActiveCell;

				// ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit�̏ꍇ
				if ( currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit )
				{
					// �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
					if( ( currentCell.Text == null ) || ( currentCell.Text.Trim() == "" ) ) 
					{
						// ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
						if ((currentCell.Column.DataType == typeof(Int32)) ||
							(currentCell.Column.DataType == typeof(Int64)) ||
							(currentCell.Column.DataType == typeof(double)))
						{
							// �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
							currentCell.Value = 0;
							// �l���󔒂Ƃ�����0���Z�b�g����
							e.RaiseErrorEvent		= false;
							e.RestoreOriginalValue	= true;
							e.StayInEditMode		= true;

						}
					}
				}
			}
		}
		#endregion

		#region �� AfterPerformAction Event
		/// <summary>
		/// AfterPerformAction Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: AfterPerformAction�C�x���g�́A�L�[�A�N�V�����̃}�b�s���O�Ɋ֘A�t����ꂽ�A�N�V���������s���ꂽ��ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_AfterPerformAction ( object sender, AfterUltraGridPerformActionEventArgs e )
		{
			switch( e.UltraGridAction ) 
			{
				case UltraGridAction.ActivateCell:
				case UltraGridAction.AboveCell:
				case UltraGridAction.BelowCell:
				case UltraGridAction.PrevCell:
				case UltraGridAction.NextCell:
				case UltraGridAction.PageUpCell:
				case UltraGridAction.PageDownCell:
				{
					// �A�N�e�B�u�Z�����L��
					if( this.ug_ProductInventInput.ActiveCell != null )
					{
						// �ҏW���[�h�ֈڍs
						this.ug_ProductInventInput.PerformAction( UltraGridAction.EnterEditMode );
					}

					break;
				}
			}
		}

		#endregion

		#region �� KeyDown Event
		/// <summary>
		/// KeyDown Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���Ƀt�H�[�J�X������Ƃ��ɃL�[���������Ɣ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_KeyDown ( object sender, KeyEventArgs e )
		{
			KeyDownProc( sender, ref e );
		}
		#endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� KeyPress Event
		/// <summary>
		/// KeyPress Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ug_ProductInventInput_KeyPress ( object sender, KeyPressEventArgs e )
		{
			KeyPressProc( sender, ref e );	
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� Enter Event
        /// <summary>
		/// Enter Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�������͂����Ɣ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_Enter ( object sender, EventArgs e )
		{
			if( this.ug_ProductInventInput.ActiveCell == null ) {
				this.ug_ProductInventInput.PerformAction( UltraGridAction.EnterEditMode );
			}
		}
		#endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� ug_ProductInventInput_AfterExitEditMode
		/// <summary>
		/// ug_ProductInventInput_AfterExitEditMode
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Z�����ҏW���[�h���I�������Ƃ��ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_AfterExitEditMode ( object sender, EventArgs e )
		{
			//Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.ug_ProductInventInput.ActiveCell;

			//if ( activeCell == null ) return;
			//try
			//{
			//    bool isShowProduct = false;

			//    ((MAZAI05130UB)this._parentForm).AfterExitEditModeProc( activeCell, sender, this._isChangeInventStcCnt, this._isChangeInventDate, isShowProduct );
			//}
			//finally
			//{
			//    this.ug_ProductInventInput.UpdateData();	// �O���b�h���X�V
			//    this.ug_ProductInventInput.DataBind();		// �f�[�^�\�[�X�̍ăo�C���h
			//    this.ug_ProductInventInput.UpdateMode = UpdateMode.OnCellChange;
			//    this._isChangeInventStcCnt = false;
			//    this._isChangeInventDate = false;
			//}

		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        
        #region �� ug_ProductInventInput_AfterCellActivate
        /// <summary>
		/// ug_ProductInventInput_AfterCellActivate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note		: �Z�����A�N�e�B�u�ɂȂ�����ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void ug_ProductInventInput_AfterCellActivate ( object sender, EventArgs e )
		{
			if ((((UltraGrid)sender).ActiveCell != null) &&
				(((UltraGrid)sender).ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
			{
				// �ҏW���[�h�ɂ���
				((UltraGrid)sender).PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
			}
		}
		#endregion
		#endregion ug_ProductInventInput Event

		#region �� tRetKeyControl�@Event
		#region �� ChangeFocus Event
		/// <summary>
		/// ChangeFocus Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X���J�ڂ���ꍇ�ɔ�������B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>date		: 2007.07.25</br>
		/// </remarks>
		private void tRetKeyControl_ChangeFocus ( object sender, ChangeFocusEventArgs e )
		{
			
			if( ( e.PrevCtrl == null ) || 
			    ( e.NextCtrl == null ) ) {
			    return;
			}

			try
			{
			
				this.ug_ProductInventInput.BeginUpdate();

				// ���o���ʃO���b�h�̏ꍇ
				if( e.PrevCtrl.Equals( this.ug_ProductInventInput ) == true )
				{
					// �A�N�e�B�u�Z�����L��
					if( this.ug_ProductInventInput.ActiveCell != null ) 
					{
						// ���͂��ꂽ�L�[�Ŕ���
						// Enter�L�[
						if( ( e.Key == Keys.Enter ) && 
							( ( e.ShiftKey == false ) && ( e.ControlKey == false ) && ( e.AltKey == false ) ) ) 
						{

							if ( this.ug_ProductInventInput.ActiveRow.Index == this.ug_ProductInventInput.Rows.Count -1 )
							{
								// �ŏI�s�̓d�b�ԍ�2��������J�����T�C�Y�R���{�{�b�N�X�Ɉړ�
                                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                //if (this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockTelNo2) == 0)
								//{
								//	this.tce_FontSize.Focus();
								//}
								//else
								//{
                                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                    //// ���̃Z���ֈړ�
									//this.ug_ProductInventInput.PerformAction( UltraGridAction.BelowCell );
									// �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
									switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
									{
                                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                        //case InventInputResult.ct_Col_ProductNumber:	// ���ԍ݌�
										//case InventInputResult.ct_Col_StockTelNo1:	// �d�b�ԍ�1
										//	this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell );	// ���Ɉړ�
										//	break;
										//case InventInputResult.ct_Col_StockTelNo2:	// �d�b�ԍ�2
										//	// �����ԍ����A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
										//	if ( this.ug_ProductInventInput.ActiveRow != null )
										//	{
										//		this.ug_ProductInventInput.ActiveRow.Cells[ InventInputResult.ct_Col_ProductNumber ].Activate();
                                        //		this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
                                        //	}
                                        //	break;
                                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                        default:
											this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
										break;
									}
								//}
							}
							else
							{
								//// ���̃Z���ֈړ�
								// �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
								switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
								{
                                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                    //case InventInputResult.ct_Col_ProductNumber:	// ���ԍ݌�
                                    //case InventInputResult.ct_Col_StockTelNo1:	// �d�b�ԍ�1
                                    //	this.ug_ProductInventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);	// ���Ɉړ�
                                    //	break;
									//case InventInputResult.ct_Col_StockTelNo2:	// �d�b�ԍ�2
									//	// �����ԍ����A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
									//	if ( this.ug_ProductInventInput.ActiveRow != null )
									//	{
                                    //		this.ug_ProductInventInput.ActiveRow.Cells[InventInputResult.ct_Col_ProductNumber].Activate();
                                    //		this.ug_ProductInventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                    //	}
                                    //	break;
                                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                    default:
										this.ug_ProductInventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
										break;
								}
							}
							e.NextCtrl = null;
						}
					}
					// Shift + Enter�L�[
					else if( ( e.Key == Keys.Enter ) && 
						( ( e.ShiftKey == true ) && ( e.ControlKey == false ) && ( e.AltKey == false ) ) ) 
					{
						if ( this.ug_ProductInventInput.ActiveRow.Index == 0 )
						{
							if ( ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year ) == 0 ) ||
								( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryTolerancCnt ) == 0 ))
							{
								// �擪�s�̏ꍇ
								this.tce_FontSize.Focus();
							}
							else
							{
								//// �O�̃Z���ֈړ�
								//this.ug_ProductInventInput.PerformAction( UltraGridAction.AboveCell );
								// �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
								switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
								{
                                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                    //case InventInputResult.ct_Col_ProductNumber:	// ���ԍ݌�
									//	// �d�b�ԍ�2���A�N�e�B�u�ɂ��Ă����Ɉړ�
									//	if ( this.ug_ProductInventInput.ActiveRow != null )
									//	{
                                    //		this.ug_ProductInventInput.ActiveRow.Cells[ InventInputResult.ct_Col_StockTelNo2 ].Activate();
                                    //		this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
                                    //	}
                                    //	break;
                                    //case InventInputResult.ct_Col_StockTelNo1:	// �d�b�ԍ�1
                                    //case InventInputResult.ct_Col_StockTelNo2:	// �d�b�ԍ�2
                                    //	this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell );	// ���Ɉړ�
                                    //	break;
                                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                    default:
										this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
										break;
								}
							}
						}
						else
						{
							//// �O�̃Z���ֈړ�
							//this.ug_ProductInventInput.PerformAction( UltraGridAction.AboveCell );
							// �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
							switch ( this.ug_ProductInventInput.ActiveCell.Column.Tag.ToString() )
							{
                                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                //case InventInputResult.ct_Col_ProductNumber:	// ���ԍ݌�
								//	// �d�b�ԍ�2���A�N�e�B�u�ɂ��Ă����Ɉړ�
								//	if ( this.ug_ProductInventInput.ActiveRow != null )
								//	{
                                //		this.ug_ProductInventInput.ActiveRow.Cells[ InventInputResult.ct_Col_StockTelNo2 ].Activate();
                                //		this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
                                //	}
                                //	break;
                                //case InventInputResult.ct_Col_StockTelNo1:	// �d�b�ԍ�1
                                //case InventInputResult.ct_Col_StockTelNo2:	// �d�b�ԍ�2
                                //	this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell );	// ���Ɉړ�
                                //	break;
                                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                default:
									this.ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
									break;
							}
						}
						e.NextCtrl = null;
					}
				}
				else if ( e.NextCtrl.Equals( this.ug_ProductInventInput ) )
				{
					if ( e.PrevCtrl.Equals( this.tce_FontSize ) )
					{
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //// �ŏI�s�̒I����
						//if( this.ug_ProductInventInput.ActiveCell == null ) 
						//{
						//	this.ug_ProductInventInput.ActiveCell = 
						//		this.ug_ProductInventInput.Rows[ 0 ].Cells[InventInputResult.ct_Col_ProductNumber];
						//}
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        this.ug_ProductInventInput.PerformAction(UltraGridAction.EnterEditMode);
					}
				}
			}
			finally
			{
				this.ug_ProductInventInput.EndUpdate();
			}
			return;

		}
		#endregion
		#endregion ���@tRetKeyControl�@Event

		private void timer1_Tick ( object sender, EventArgs e )
		{
			this.timer1.Enabled = false;
			if (this.ug_ProductInventInput.ActiveCell != null)
			{
				if (ug_ProductInventInput.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
				{
					ug_ProductInventInput.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
				}
			}
		}

		#endregion �� Private Event
	}
}