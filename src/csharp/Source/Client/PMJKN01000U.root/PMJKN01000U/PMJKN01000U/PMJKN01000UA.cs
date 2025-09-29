using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���R�������i�����o�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�����o�^�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br></br>
    /// </remarks>
    public partial class PMJKN01000UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;

        private AutoEntryFreeSearchPartsAcs _autoEntryFSPartsAcs;
        private AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable _autoEntryFSPartsDataTable;
        private AutoEntryFreeSearchPartsDataSet.CarModelDataTable _carModelDataTable;

        private int _carSelectNo;
        private DataView _autoEntryGoodsView = null;
        private ImageList _imageList16 = null;									// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// �m��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _prevButton;		// �O�փ{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextButton;		// ���փ{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _countLabel;        // �I��ԍ����x��

        private DialogResult _dialogRes = DialogResult.Cancel;                  // �_�C�A���O���U���g

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMJKN01000UA()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._autoEntryFSPartsAcs = AutoEntryFreeSearchPartsAcs.GetInsctance();

            this._autoEntryFSPartsDataTable = null;
            this._carModelDataTable = null;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];

            this._prevButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Prev"];
            this._nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Next"];

            this._countLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LblCntDisplay"];
        }
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// �t�H�[��Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMJKN01000UI_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------
            // �c�[���o�[�{�^�������ݒ�
            //---------------------------------------------------------
            this.ButtonInitialSetting();

            //---------------------------------------------------------
            // �����ݒ�^�C�}�[�N��
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;

            //---------------------------------------------------------
            // �����o�^�f�[�^�e�[�u��
            //---------------------------------------------------------
            
            // ���ďo����AutoEntryCheck���\�b�h�����s���Ă���A
            //   ���̂t�h��ShowDialog���Ăяo��������z�肵�Ă��邪�A
            //   �O�̂��߁AAutoEntryCheck�����s���Ȃ��Ă��Ăяo����悤�ɂ���B
            if ( _autoEntryFSPartsDataTable == null )
            {
                CreateAutoEntryFSPartsDataTable( this._salesSlipInputAcs );
            }

            //---------------------------------------------------------
            // �O���b�h���ݒ�
            //---------------------------------------------------------
            this._autoEntryGoodsView = this._autoEntryFSPartsDataTable.DefaultView;
            this.uGrid_AutoEntryFSParts.DataSource = this._autoEntryGoodsView;

            // �\���X�V
            _carSelectNo = 1;
            if ( _autoEntryFSPartsDataTable.Rows.Count > 0 )
            {
                this.DisplayCarModel( _carSelectNo );
            }
        }

        /// <summary>
        /// �^�����\��
        /// </summary>
        /// <param name="dataRow"></param>
        private void DisplayCarModel( int carSelectNo )
        {
            // �Y���̌^��row���擾
            AutoEntryFreeSearchPartsDataSet.CarModelRow[] carModelRows
                = (AutoEntryFreeSearchPartsDataSet.CarModelRow[])_carModelDataTable.Select(
                    string.Format( "{0}={1}", _carModelDataTable.CarSelectNoColumn.ColumnName, carSelectNo ) 
                  );
            if ( carModelRows.Length == 0 )
            {
                return;
            }

            // �w�b�_���̌^������\��
            tNedit_ModelDesignationNo.SetInt( carModelRows[0].ModelDesignationNo );
            tNedit_CategoryNo.SetInt( carModelRows[0].CategoryNo );
            tEdit_EngineModelNm.Text = carModelRows[0].EngineModelNm;
            tEdit_FullModel.Text = carModelRows[0].FullModel;
            tNedit_MakerCode.SetInt( carModelRows[0].MakerCode );
            tNedit_ModelCode.SetInt( carModelRows[0].ModelCode );
            tNedit_ModelSubCode.SetInt( carModelRows[0].ModelSubCode );
            tEdit_ModelFullName.Text = carModelRows[0].ModelFullName;
            tDateEdit_FirstEntryDate.SetDateTime( carModelRows[0].FirstEntryDate );
            tEdit_ProduceFrameNo.Text = carModelRows[0].ProduceFrameNo;

            // ���ׂɃt�B���^��������
            _autoEntryGoodsView.RowFilter = string.Format( "{0}={1}", _autoEntryFSPartsDataTable.CarSelectNoColumn.ColumnName, carSelectNo );

            // ���x���\���ύX
            SetCountLabel( carSelectNo );
        }

        /// <summary>
        /// �^���I��ԍ����x���X�V
        /// </summary>
        /// <param name="carSelectNo"></param>
        private void SetCountLabel( int carSelectNo )
        {
            // ���x���L���v�V�����X�V
            this._countLabel.SharedProps.Caption = string.Format( "{0} / {1}", carSelectNo, _carModelDataTable.Rows.Count );

            // �߂�/�i�� �{�^���L���E�����؂�ւ�
            _prevButton.SharedProps.Enabled = (carSelectNo > 1);
            _nextButton.SharedProps.Enabled = (carSelectNo < _carModelDataTable.Rows.Count);
        }

        /// <summary>
        /// ���R�������i�����o�^�e�[�u������
        /// </summary>
        /// <param name="salesSlipInputAcs"></param>
        /// <returns></returns>
        private void CreateAutoEntryFSPartsDataTable( SalesSlipInputAcs salesSlipInputAcs )
        {
            // �f�[�^������
            _autoEntryFSPartsAcs.ClearTables();
            _autoEntryFSPartsDataTable = _autoEntryFSPartsAcs.AutoEntryFSPartsDataTable;
            _carModelDataTable = _autoEntryFSPartsAcs.CarModelDataTable;

            AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow newRow;

            foreach ( SalesInputDataSet.SalesDetailRow row in salesSlipInputAcs.SalesDetailDataTable.Rows )
            {
                // BL�R�[�h���ݒ�͏���
                if ( row.BLGoodsCode == 0 ) continue;
                // �s�l���͏����iBL�R�[�h=0�̂͂������O�̂��߃`�F�b�N�j
                if ( row.SalesSlipCdDtl == 2 && row.ShipmentCnt == 0 ) continue;
                // ���ߍs�͏����iBL�R�[�h=0�̂͂������O�̂��߃`�F�b�N�j
                if ( row.SalesSlipCdDtl == 3 ) continue;
                // BL�R�[�h�����œ��͂������ׂ͏���
                if ( row.SearchPartsModeState == (int)SalesSlipInputAcs.SearchPartsModeState.BLCodeSearch ) continue;


                // ���㖾�ׂɕR�t���^�����̈ꗗ���擾
                PMKEN01010E carInfo = salesSlipInputAcs.GetCarInfoFromDic( row.SalesRowNo );
                SalesInputDataSet.CarInfoRow carInfoRow = salesSlipInputAcs.GetCarInfoRow( row.SalesRowNo, SalesSlipInputAcs.GetCarInfoMode.ExistGetMode );

                // ���q�Ɋւ����񂪖����ꍇ�͏���
                if ( carInfo == null ) continue;
                if ( carInfoRow == null ) continue;


                // ���R�������i�}�X�^���݃`�F�b�N
                if ( _autoEntryFSPartsAcs.CheckFreeSearchParts( LoginInfoAcquisition.EnterpriseCode.Trim(), carInfo, row.BLGoodsCode, row.GoodsNo, row.GoodsMakerCd ) )
                {
                    // ���R�������i�}�X�^���q�b�g����ꍇ�́A�����o�^�͕s�v
                    continue;
                }

                foreach ( PMKEN01010E.CarModelInfoRow carModelInfoRow in carInfo.CarModelInfo.Rows )
                {
                    // �^���I���`�F�b�N(���������^�������őI�����ꂽ�^���Ȃ̂����`�F�b�N����)
                    if ( carModelInfoRow.SelectionState == false ) continue;

                    // �d���`�F�b�N(DataTable)
                    # region [�d���`�F�b�N(DataTable)]
                    // ...���ɒǉ��p�e�[�u���Ɋi�[����Ă�����̂͏��O����
                    AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[] targetRows
                        = (AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[])_autoEntryFSPartsDataTable.Select( string.Format( "{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}='{9}' AND {10}='{11}' AND {12}='{13}'",
                              _autoEntryFSPartsDataTable.MakerCodeColumn.ColumnName, carModelInfoRow.MakerCode,
                              _autoEntryFSPartsDataTable.ModelCodeColumn.ColumnName, carModelInfoRow.ModelCode,
                              _autoEntryFSPartsDataTable.ModelSubCodeColumn.ColumnName, carModelInfoRow.ModelSubCode,
                              _autoEntryFSPartsDataTable.FullModelColumn.ColumnName, carModelInfoRow.FullModel,
                              _autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName, row.BLGoodsCode,
                              _autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName, row.GoodsNo,
                              _autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName, row.GoodsMakerCd ) );
                    // ���݃`�F�b�N
                    if ( targetRows.Length > 0 )
                    {
                        continue;
                    }
                    # endregion

                    // �s��(RowNo)�擾�ׁ̈A���v���閾�הz����擾
                    targetRows
                        = (AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[])_autoEntryFSPartsDataTable.Select( string.Format( "{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}'",
                              _autoEntryFSPartsDataTable.MakerCodeColumn.ColumnName, carModelInfoRow.MakerCode,
                              _autoEntryFSPartsDataTable.ModelCodeColumn.ColumnName, carModelInfoRow.ModelCode,
                              _autoEntryFSPartsDataTable.ModelSubCodeColumn.ColumnName, carModelInfoRow.ModelSubCode,
                              _autoEntryFSPartsDataTable.FullModelColumn.ColumnName, carModelInfoRow.FullModel ) );


                    // ���ו\�����e����
                    # region [���㖾�ׁ{�^�����ˎ��R�������i�����o�^�pRow]
                    newRow = _autoEntryFSPartsDataTable.NewAutoEntryFreeSearchPartsRow();

                    // ���i���
                    newRow.Checked = false;
                    newRow.RowNo = (targetRows.Length + 1);
                    newRow.BLGoodsCode = row.BLGoodsCode;
                    newRow.BLGoodsFullName = row.BLGoodsFullName;
                    newRow.DtlRelationGuid = row.DtlRelationGuid;
                    newRow.GoodsMakerCd = row.GoodsMakerCd;
                    newRow.GoodsName = row.GoodsName;
                    newRow.GoodsNo = row.GoodsNo;

                    // �ޕʌ^���E�N���E�ԑ�ԍ�
                    if ( carInfoRow != null )
                    {
                        newRow.ModelDesignationNo = carInfoRow.ModelDesignationNo;
                        newRow.CategoryNo = carInfoRow.CategoryNo;
                        newRow.FirstEntryDate = TDateTime.LongDateToDateTime( carInfoRow.FirstEntryDate );
                        newRow.ProduceFrameNo = carInfoRow.FrameNo;
                    }

                    // �^�����
                    newRow.EngineModelNm = carModelInfoRow.EngineModelNm;
                    newRow.FullModel = carModelInfoRow.FullModel;
                    newRow.MakerCode = carModelInfoRow.MakerCode;
                    newRow.ModelCode = carModelInfoRow.ModelCode;
                    newRow.ModelSubCode = carModelInfoRow.ModelSubCode;
                    newRow.ModelFullName = carModelInfoRow.ModelFullName;


                    // �^���I��No.(UI����p)
                    int carSelectNo;
                    AddCarModel( newRow, out carSelectNo );
                    newRow.CarSelectNo = carSelectNo;


                    _autoEntryFSPartsDataTable.Rows.Add( newRow );
                    # endregion
                }
            }
        }

        /// <summary>
        /// �^���e�[�u��(UI����p)�ւ̒ǉ��{�I��ԍ��̎擾
        /// </summary>
        /// <param name="newRow"></param>
        /// <param name="carSelectNo"></param>
        private void AddCarModel( AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow partsRow, out int carSelectNo )
        {
            AutoEntryFreeSearchPartsDataSet.CarModelRow[] rows;
            rows = (AutoEntryFreeSearchPartsDataSet.CarModelRow[])_carModelDataTable.Select( string.Format( "{0}={1} AND {2}={3} AND {4}={5} AND {6}='{7}'",
                                                            _carModelDataTable.MakerCodeColumn.ColumnName, partsRow.MakerCode,
                                                            _carModelDataTable.ModelCodeColumn.ColumnName, partsRow.ModelCode,
                                                            _carModelDataTable.ModelSubCodeColumn.ColumnName, partsRow.ModelSubCode,
                                                            _carModelDataTable.FullModelColumn.ColumnName, partsRow.FullModel ) );
            if ( rows.Length > 0 )
            {
                // ��������
                carSelectNo = rows[0].CarSelectNo;
            }
            else
            {
                // �����Ȃ��˒ǉ�
                AutoEntryFreeSearchPartsDataSet.CarModelRow newRow = _carModelDataTable.NewCarModelRow();
                carSelectNo = (_carModelDataTable.Rows.Count + 1);
                newRow.CarSelectNo = carSelectNo;

                # region [���R�������i�����o�^row�ˌ^��row]
                newRow.CategoryNo = partsRow.CategoryNo;
                newRow.EngineModelNm = partsRow.EngineModelNm;
                newRow.FirstEntryDate = partsRow.FirstEntryDate;
                newRow.FullModel = partsRow.FullModel;
                newRow.MakerCode = partsRow.MakerCode;
                newRow.ModelCode = partsRow.ModelCode;
                newRow.ModelDesignationNo = partsRow.ModelDesignationNo;
                newRow.ModelFullName = partsRow.ModelFullName;
                newRow.ModelSubCode = partsRow.ModelSubCode;
                newRow.ProduceFrameNo = partsRow.ProduceFrameNo;
                # endregion

                _carModelDataTable.Rows.Add( newRow );
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///	                 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///	                 �X���b�h�Ŏ��s����܂��B</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �����ݒ�^�C�}�[����
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�ʒu�w��
            this.uGrid_AutoEntryFSParts.Focus();
            if ( uGrid_AutoEntryFSParts.Rows.Count > 0 )
            {
                this.uGrid_AutoEntryFSParts.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // ���ו�
                //---------------------------------------------------------------
                case "uGrid_AutoEntryFSParts":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // �A�N�e�B�u�s�I���^�C�}�[�N��
                                    this.timer_SelectRow.Enabled = true;
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //--------------------------------------------
                // �I��
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // �S�I��
                //--------------------------------------------
                case "ButtonTool_AllSelect":
                    {
                        this.SetRowSelectedAll(true);
                        this.ChangedSelectColorAll(true);
                        break;
                    }
                //--------------------------------------------
                // �S����
                //--------------------------------------------
                case "ButtonTool_AllCancel":
                    {
                        this.SetRowSelectedAll(false);
                        this.ChangedSelectColorAll(false);
                        break;
                    }
                //--------------------------------------------
                // �߂�
                //--------------------------------------------
                case "ButtonTool_Prev":
                    {
                        this.CarModelSelectPrev();
                        break;
                    }
                //--------------------------------------------
                // �i��
                //--------------------------------------------
                case "ButtonTool_Next":
                    {
                        this.CarModelSelectNext();
                        break;
                    }
                //--------------------------------------------
                // �m��
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// �߂�{�^������
        /// </summary>
        private void CarModelSelectPrev()
        {
            if ( _carSelectNo > 0 )
            {
                _carSelectNo--;
                this.DisplayCarModel( _carSelectNo );
            }
        }
        /// <summary>
        /// �i�ރ{�^������
        /// </summary>
        private void CarModelSelectNext()
        {
            if ( _carSelectNo < _carModelDataTable.Rows.Count )
            {
                _carSelectNo++;
                this.DisplayCarModel( _carSelectNo );
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMJKN01000UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            this.uGrid_AutoEntryFSParts.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // ��
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �I���t���O
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Header.Fixed = true;		    // �Œ荀��
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Width = 30;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].AutoEdit = true;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // �a�k�R�[�h
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Width = 40;
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �i��
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Width = 150;
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // �i��
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Width = 120;
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ���[�J�[
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Width = 50;
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �Œ���؂���ݒ�
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryFSParts_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾����B
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

           
            // �I���`�F�b�N
            if ( objCell == objRow.Cells[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName] )
            {
                this.ChangedSelect(objRow);
            }
        }

        /// <summary>
        /// �O���b�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryFSParts_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾����B
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // �`�F�b�N���]
            this.ChangedSelect(objRow);
        }

        /// <summary>
        /// �I���s���擾�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_AutoEntryFSParts.ActiveRow != null)
            {
                // �I�� or ����
                this.ChangedSelect(this.uGrid_AutoEntryFSParts.ActiveRow);
            }
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryFSParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    // �A�N�e�B�u�s�I���^�C�}�[�N��
                    this.timer_SelectRow.Enabled = true;
                    break;
            }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._prevButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        private void CloseForm()
        {
            // �t�h����ł�DataTable�ύX��K�p����(Check��Ԃ̔��f)
            this._autoEntryFSPartsDataTable.AcceptChanges();

            this.Close();
        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        #region �I���E��I��ύX����
        /// <summary>
        /// �I���E���I��ύX�����i���]�j
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Value;

            // �e�[�u���X�V
            gridRow.Cells[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Value = newSelectedValue;

            // �w�i�F��ύX
            ChangedSelectColor(newSelectedValue, gridRow);
        }
        /// <summary>
        /// �I���E��I��ύX�����i�w�i�F�̂݁j
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="gridRow"></param>
        private void ChangedSelectColor(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // �Ώۍs�̑I��F��ݒ肷��
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            }
        }
        /// <summary>
        /// �S�Ă̍s�̔w�i�F�ύX
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChangedSelectColorAll(bool isSelected)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_AutoEntryFSParts.Rows)
            {
                ChangedSelectColor(isSelected, row);
            }
        }
        /// <summary>
        /// �S�Ă̍s�̑I���`�F�b�N���Z�b�g
        /// </summary>
        public void SetRowSelectedAll(bool rowSelected)
        {
            // �S�Ă̍s�̑I���`�F�b�N��ݒ�
            foreach ( DataRow row in this._autoEntryFSPartsDataTable.Rows )
            {
                row[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName] = rowSelected;
            }
        }
        # endregion

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �����o�^�`�F�b�N�i���ďo����ShowDialog���Ăяo���O�Ƀf�[�^�L�����`�F�b�N����j
        /// </summary>
        public bool AutoEntryCheck()
        {
            // �����o�^�f�[�^�e�[�u���̐���
            CreateAutoEntryFSPartsDataTable( this._salesSlipInputAcs );

            // �����o�^�I���\�f�[�^�����`�F�b�N
            return (_autoEntryFSPartsDataTable != null && _autoEntryFSPartsDataTable.Rows.Count > 0);
        }
        # endregion
    }
}