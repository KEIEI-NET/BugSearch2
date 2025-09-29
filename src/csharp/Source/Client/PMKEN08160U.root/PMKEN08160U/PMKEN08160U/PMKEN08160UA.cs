using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// ���ꉿ�i�I���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2010/06/17</br>
    /// </remarks>
    public partial class SelectionMarketPrice : Form
    {
        #region [ Private �t�B�[���h ]
        private int _searchStatus;
        private SelectionMarketPriceAcs _selectionMarketPriceAcs;

        private List<int> _makerList = null;
        private bool isDialogShown = false;
        private List<MarketPriceInfo> _marketPriceInfoList;
        private MarketPriceAcqCond _condition;
        # endregion

        # region [ public �v���p�e�B ]
        /// <summary> 
        /// �_�C�A���O�\���ۃt���O�i�f�[�^���ɂ�莩������j 
        /// </summary>
        public bool IsDialogShown
        {
            get 
            { 
                return isDialogShown; 
            }
        }
        /// <summary>
        /// �I�����ʂ̑��ꉿ�i��񃊃X�g
        /// </summary>
        public List<MarketPriceInfo> MarketPriceInfoList
        {
            get 
            {
                if ( _marketPriceInfoList == null )
                {
                    _marketPriceInfoList = new List<MarketPriceInfo>();
                }
                return _marketPriceInfoList; 
            }
        }
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="cndtn"></param>
        public SelectionMarketPrice( MarketPriceAcqCond cndtn )
        {
            // �������s
            _selectionMarketPriceAcs = new SelectionMarketPriceAcs();
            string errMsg;
            _condition = cndtn;
            _searchStatus = _selectionMarketPriceAcs.MarketPriceSearch( cndtn, out errMsg );
            
            // �t�H�[���\������(�f�[�^���������͔�\��)
            isDialogShown = (_searchStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL);

            if ( IsDialogShown )
            {
                // UI������
                InitializeComponent();
            }
        }
        # endregion

        # region [�\��]
        /// <summary>
        /// ���ꉿ�i�I��UI��\������
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog( IWin32Window owner )
        {
            if ( !IsDialogShown )
            {
                return DialogResult.Cancel;
            }
            Initialize();
            return base.ShowDialog( owner );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            if ( !IsDialogShown )
            {
                return DialogResult.Cancel;
            }
            Initialize();
            return base.ShowDialog();
        }
        # endregion

        # region [����������]
        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            // ����������ɏI�����Ă��Ȃ��ꍇ�͏������Ȃ�
            if ( _searchStatus != 0 )
            {
                return;
            }

            // ��ʕ\���i�w�b�_���j
            txtBLCode.Text = _condition.BLGoodsCode.ToString( "00000" );
            txtPartName.Text = _condition.BLGoodsName.Trim();

            # region [�c�[���o�[�̏�����]
            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            # endregion

            # region [Grid������]
            const string ct_PriceFormat = "#,##0;-#,##0;;";

            // Grid�X�V�J�n������
            gridSoba.BeginUpdate();

            // �f�[�^�\�[�X�ݒ�
            gridSoba.DataSource = _selectionMarketPriceAcs.PriceInfoDataTable.DefaultView;

            # region [�J�����ݒ�]
            // �I��p�J�����ǉ�
            UltraGridColumn col = gridSoba.DisplayLayout.Bands[0].Columns.Add( "SelectState", "�I��" );
            col.DataType = typeof( Image );
            col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            // �J������\��
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.PriorityColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceAreaCdColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceAreaNmColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceKindCdColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceQualityCdColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.DstrMarketPriceColumn.ColumnName].Hidden = true;

            // �\����
            int position = 0;
            gridSoba.DisplayLayout.Bands[0].Columns["SelectState"].Header.VisiblePosition = position++;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceKindNmColumn.ColumnName].Header.VisiblePosition = position++;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceQualityNmColumn.ColumnName].Header.VisiblePosition = position++;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceColumn.ColumnName].Header.VisiblePosition = position++;

            // �J������
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Width = 50;

            // ���E�ʒu
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �t�H�[�}�b�g
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceColumn.ColumnName].Format = ct_PriceFormat;
            # endregion

            // Grid�X�V�I��������
            gridSoba.EndUpdate();
            # endregion
        }
        # endregion

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSamePartsNoParts_Shown( object sender, EventArgs e )
        {
            if ( gridSoba.Rows.Count == 0 )
                return;
            // �擪�s�Ƀt�H�[�J�X�Z�b�g����
            gridSoba.Focus();
            gridSoba.Rows[0].Activate();
            gridSoba.Rows[0].Selected = true;
        }
        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSamePartsNoParts_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Escape )
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            UltraGridRow activeRow = gridSoba.ActiveRow;
            switch ( e.Tool.Key )
            {
                case "Button_Select":
                    // �I������Ă���s���m�肷��
                    SetSelectDecision();
                    // �m��
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
        #endregion

        #region [ ���C���O���b�h�C�x���g���� ]
        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridParts_InitializeLayout( object sender, InitializeLayoutEventArgs e )
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �s�Z���N�^�̕�
            e.Layout.Override.RowSelectorWidth = 25;
        }

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_AfterSelectChange( object sender, AfterSelectChangeEventArgs e )
        {
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridParts_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelect( false );
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    SetSelect( true );
                    break;
                case Keys.Space:
                    SetSelect( true );
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ ���̑����\�b�h ]
        /// <summary>
        /// �I����Ԑݒ菈��
        /// </summary>
        private void SetSelect( bool moveNext )
        {
            UltraGridRow activeRow = gridSoba.ActiveRow;
            if ( activeRow != null )
            {
                try
                {
                    // �I�𔽓]����
                    bool selectState = (bool)activeRow.Cells[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Value;
                    activeRow.Cells[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Value = !selectState;

                    // �`�F�b�N�}�[�N�\��
                    if ( !selectState == true )
                    {
                        activeRow.Cells["SelectState"].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        activeRow.Cells["SelectState"].Value = DBNull.Value;
                    }


                    // ���s�ֈړ�
                    if ( moveNext )
                    {
                        int rowIndex = activeRow.Index;
                        if ( gridSoba.Rows.Count > rowIndex + 1 )
                        {
                            gridSoba.Rows[rowIndex + 1].Activate();
                            gridSoba.Rows[rowIndex + 1].Selected = true;
                        }
                    }
                }
                catch
                {
                }
                // �ύX��K�p
                _selectionMarketPriceAcs.PriceInfoDataTable.AcceptChanges();
            }
        }

        /// <summary>
        /// �I���m�菈��
        /// </summary>
        private void SetSelectDecision()
        {
            // ���X�g������
            _marketPriceInfoList = new List<MarketPriceInfo>();

            // �ύX�K�p
            _selectionMarketPriceAcs.PriceInfoDataTable.AcceptChanges();

            // �I���ς݂����ōi�荞��
            _selectionMarketPriceAcs.PriceInfoDataTable.DefaultView.RowFilter = string.Format( "{0} = {1}",
                    _selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName, true );

            // ���X�g�Ɋi�[
            foreach ( DataRowView rowView in _selectionMarketPriceAcs.PriceInfoDataTable.DefaultView )
            {
                MarketPriceInfoDataSet.MarketPriceInfoRow row = (MarketPriceInfoDataSet.MarketPriceInfoRow)rowView.Row;
                _marketPriceInfoList.Add( CopyToMarketPriceInfoFromRow( row ) );
            }
        }
        /// <summary>
        /// DataRow �� Result�ϊ�
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private MarketPriceInfo CopyToMarketPriceInfoFromRow( MarketPriceInfoDataSet.MarketPriceInfoRow row )
        {
            MarketPriceInfo data = new MarketPriceInfo();

            data.DstrMarketPrice = row.DstrMarketPrice;
            data.MarketPrice = row.MarketPrice;
            data.MarketPriceAreaCd = row.MarketPriceAreaCd;
            data.MarketPriceAreaNm = row.MarketPriceAreaNm;
            data.MarketPriceKindCd = row.MarketPriceKindCd;
            data.MarketPriceKindNm = row.MarketPriceKindNm;
            data.MarketPriceQualityCd = row.MarketPriceQualityCd;
            data.MarketPriceQualityNm = row.MarketPriceQualityNm;

            data.BLGoodsCode = _condition.BLGoodsCode;
            data.BLGoodsName = _condition.BLGoodsName;

            string goodsName = GetSobaGoodsName( _condition, row ); // �i��
            data.GoodsNameKana = ToKanaHalf( goodsName ); // �i���J�i

            return data;
        }
        /// <summary>
        /// ������ �i���擾
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetSobaGoodsName( MarketPriceAcqCond cndtn, MarketPriceInfoDataSet.MarketPriceInfoRow row )
        {
            StringBuilder sb = new StringBuilder();

            // <BL���ޖ�> + <��߰�> + <��ʖ�> + <�i����>
            // "�t�����g�o���p ���r���h�ɏ�i"
            sb.Append( cndtn.BLGoodsName.Trim() );
            sb.Append( " " );
            sb.Append( row.MarketPriceKindNm.Trim() );
            sb.Append( row.MarketPriceQualityNm.Trim() );
            
            return sb.ToString();
        }
        /// <summary>
        /// ���p�J�i�ϊ�
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private string ToKanaHalf( string orgString )
        {
            // �S�p�˔��p�ϊ��i�r���Ɋ܂܂��ϊ��ł��Ȃ������͂��̂܂܁j
            return Microsoft.VisualBasic.Strings.StrConv( orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        #endregion
    }
}
