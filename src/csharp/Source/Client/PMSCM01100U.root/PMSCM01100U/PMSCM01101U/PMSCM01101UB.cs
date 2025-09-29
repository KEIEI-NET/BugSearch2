//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����̉��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/10/10  �C�����e : �V�K�쐬�F�s�r�o����M�����y�o�l���z(SFMIT02850U)
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/29  �C�����e : SCM�p�ɃA�����W
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M����(���ו\��)�t�H�[��
    /// </summary>
	public partial class PMSCM01101UB : Form
	{
        /// <summary>�f�t�H���gx���W</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>�f�t�H���gy���W</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>���׃O���b�h�̃^�C�g���t�H�[�}�b�g</summary>
        const string DETAIL_GRID_TITLE_FORMAT = "�`�[�ԍ�[{0}] �`�[���v���z[ \\{1}]";  // LITERAL:

        #region <�񓚑��M����>

        /// <summary>�񓚑��M����</summary>
        private readonly SCMSendController _scmController;
        /// <summary>�񓚑��M�������擾���܂��B</summary>
        private SCMSendController SCMController { get { return _scmController; } }

        #endregion // </�񓚑��M����>

        #region <���݂̑��M�`�[���X�g��ID>

        /// <summary>���݂̑��M�`�[���X�g��ID</summary>
        private long _currentHeaderID;
        /// <summary>���݂̑��M�`�[���X�g��ID���擾�܂��͐ݒ肵�܂��B</summary>
        public long CurrentHeaderID
        {
            get { return _currentHeaderID; }
            set { _currentHeaderID = value; }
        }

        #endregion // </���݂̑��M�`�[���X�g��ID>

        #region <Constructor>

        /// <summary>
		/// �J�X�^���R���X�g���N�^
		/// </summary>
        public PMSCM01101UB(SCMSendController scmController)
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _scmController = scmController;
            this.sendingAnswerGrid.DataSource = _scmController.SendingDetailTable.DefaultView;
        }

        #endregion // </Constructor>

        /// <summary>
        /// ���M����(���ו\��)�t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
		private void PMSCM01101UB_Load(object sender, EventArgs e)
        {
            //// �����ʒu��ݒ�i������h�~�ׁ̈A10000�ɂ��Ă��܂��j
            //SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            // �^�C�g����ݒ�
            DataRow[] foundHeaderRows = SCMController.SendingHeaderTable.Select(
                SCMController.SendingHeaderTable.IDColumn.ColumnName + " = " + CurrentHeaderID.ToString()
            );
            if (foundHeaderRows.Length.Equals(0))
            {
                Debug.Assert(false, "�Y������SCM�󒍃f�[�^�����݂��܂���B(ID=" + CurrentHeaderID.ToString() + ")");
                return;
            }
            this.sendingAnswerGrid.Text = string.Format(
                DETAIL_GRID_TITLE_FORMAT,
                ((SCMSendViewDataSet.SendingSlipHeaderRow)foundHeaderRows[0]).SalesSlipNum,
                ((SCMSendViewDataSet.SendingSlipHeaderRow)foundHeaderRows[0]).SalesTotal.ToString("n0")
            );

            // ���݂̓`�[(SCM�󒍃f�[�^)�Ńt�B���^�����O
            string rowFilter = SCMController.SendingDetailTable.HeaderIDColumn.ColumnName + "=" + CurrentHeaderID.ToString();
            SCMController.SendingDetailTable.DefaultView.RowFilter = rowFilter;
        }

        /// <summary>
        /// ���׃O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingAnswerGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sendingAnswerGrid;

            // �o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            // �񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // �J�����̃L�[
            string idKey        = SCMController.SendingDetailTable.IDColumn.ColumnName;         // ID�J�����̃L�[
            string headerIdKey  = SCMController.SendingDetailTable.HeaderIDColumn.ColumnName;   // HeaderID�J�����̃L�[
            string blCodeKey    = SCMController.SendingDetailTable.BLGoodsCodeColumn.ColumnName;// BL�R�[�h�J�����̃L�[
            string goodsNoKey   = SCMController.SendingDetailTable.GoodsNoColumn.ColumnName;    // �i�ԃJ�����̃L�[
            string goodsNameKey = SCMController.SendingDetailTable.GoodsNameColumn.ColumnName;  // �i���J�����̃L�[
            string deliveredGoodsCountKey = SCMController.SendingDetailTable.DeliveredGoodsCountColumn.ColumnName;   // ���ʃJ�����̃L�[
            string unitPriceKey = SCMController.SendingDetailTable.UnitPriceColumn.ColumnName;  // �P���J�����̃L�[
            string salesTotalKey= SCMController.SendingDetailTable.SalesTotalColumn.ColumnName; // ���z�J�����̃L�[

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                // �\���ʒu(vertical)
                column.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                // �N���b�N���͍s�Z���N�g
                column.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

                // �ҏW�s��
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

                // �\�[�g�s��
                column.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;

                // ��x�S�Ĕ�\���ɂ���B
                column.Hidden = true;
            }
            
            // �\������
            band.Columns[blCodeKey].Hidden = false;     	// BL�R�[�h
            band.Columns[goodsNoKey].Hidden = false;    	// �i��
            band.Columns[goodsNameKey].Hidden = false;      // �i��
            band.Columns[deliveredGoodsCountKey].Hidden = false;    // ����
            band.Columns[unitPriceKey].Hidden = false;  	// �P��
            band.Columns[salesTotalKey].Hidden = false;	    // ���v

            // �\����
            band.Columns[blCodeKey].Header.VisiblePosition      = 0;	// BL�R�[�h
            band.Columns[goodsNoKey].Header.VisiblePosition     = 1;	// �i��
            band.Columns[goodsNameKey].Header.VisiblePosition   = 2;    // �i��
            band.Columns[deliveredGoodsCountKey].Header.VisiblePosition = 3;    // ����
            band.Columns[unitPriceKey].Header.VisiblePosition   = 4;	// �P��
            band.Columns[salesTotalKey].Header.VisiblePosition  = 5;	// ���v

            // �J������
            band.Columns[blCodeKey].Width       = 80;   // BL�R�[�h
            band.Columns[goodsNoKey].Width      = 180;	// �i��
            band.Columns[goodsNameKey].Width    = 240;	// �i��
            band.Columns[deliveredGoodsCountKey].Width = 50;	// ����
            band.Columns[unitPriceKey].Width    = 90;	// �P��
            band.Columns[salesTotalKey].Width   = 90;	// ���v

            // ����
            band.Columns[blCodeKey].Format      = "00000";// "#####;";  // BL�R�[�h
            band.Columns[unitPriceKey].Format   = "#,##0;-#,##0;";	    // �P��
            band.Columns[salesTotalKey].Format  = "#,##0;-#,##0;";	    // ���v

            // �\���ʒu
            band.Columns[blCodeKey].CellAppearance.TextHAlign       = Infragistics.Win.HAlign.Right;// BL�R�[�h
            band.Columns[goodsNoKey].CellAppearance.TextHAlign      = Infragistics.Win.HAlign.Left;	// �i��
            band.Columns[goodsNameKey].CellAppearance.TextHAlign    = Infragistics.Win.HAlign.Left;	// �i��
            band.Columns[deliveredGoodsCountKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// ����
            band.Columns[unitPriceKey].CellAppearance.TextHAlign    = Infragistics.Win.HAlign.Right;// �P��
            band.Columns[salesTotalKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Right;// ���v

            // �L�[����}�b�s���O��ǉ�
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	// Enter�L�[
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0
                )
            );
        }
	}
}