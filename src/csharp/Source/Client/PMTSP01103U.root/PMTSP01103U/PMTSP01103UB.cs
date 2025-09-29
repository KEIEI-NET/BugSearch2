using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using System.Collections.Specialized;

namespace Broadleaf.Windows.Forms
{
	public partial class PMTSP01103UB : Form
	{
		#region �R���X�g���N�^
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
        public PMTSP01103UB(TspSdRvDt dt,TspSdRvDtl[] dtl)
		{
			InitializeComponent();
            this._TspSdRvDtl = dtl;
            this.DetailGrid.Text = String.Format("�`�[�ԍ�[{0}] �`�[���v���z[ \\{1}]", dt.PmSlipNo, dt.TspTotalSlipPrice.ToString("n0")  );
		}

		#endregion

		#region �t�B�[���h

		/// <summary>
		/// ���׃f�[�^
		/// </summary>
        private Broadleaf.Application.UIData.TspSdRvDtl[] _TspSdRvDtl = null;
		
		#endregion

		#region �v���p�e�B

        private const string BLPartsCode = "DTL_0001";	//BL�R�[�h
        private const string PartsNoWithHyphen = "DTL_0002";	//�i�ԁi�n�C�t���t�j
        private const string PmPartsNameKana = "DTL_0003";//�i��
        private const string DeliveredGoodsCount = "DTL_0004";//����
        private const string UnitPrice = "DTL_0005";	//�P��
        private const string LinePrice = "DTL_0006";	//���z�i���ʁ~�P���j
		
		#endregion

		#region �E�R���g���[���C�x���g

		private void PMTSP01103UB_Load(object sender, EventArgs e)
        {
            SetTSPDtlList();
            DetailGrid_InitializeLayout();
        }

        private void SetTSPDtlList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CreateColumn(BLPartsCode, typeof(int), "BL����"));	
            dt.Columns.Add(CreateColumn(PartsNoWithHyphen, typeof(string), "�i��"));
            dt.Columns.Add(CreateColumn(PmPartsNameKana, typeof(string), "�i��"));
            dt.Columns.Add(CreateColumn(DeliveredGoodsCount, typeof(int), "����"));
            dt.Columns.Add(CreateColumn(UnitPrice, typeof(int), "�P��"));
            dt.Columns.Add(CreateColumn(LinePrice, typeof(int), "���z"));

            foreach (Broadleaf.Application.UIData.TspSdRvDtl td in _TspSdRvDtl)
            {
                DataRow dtl_dr = dt.NewRow();
                if (td.TbsPartsCode < 0) dtl_dr[BLPartsCode] = 0;
                else dtl_dr[BLPartsCode] = td.TbsPartsCode;
                dtl_dr[PartsNoWithHyphen] = td.PartsNoWithHyphen;
                dtl_dr[PmPartsNameKana] = td.PmPartsNameKana;
                dtl_dr[DeliveredGoodsCount] = td.DeliveredGoodsCount;
                dtl_dr[UnitPrice] = td.UnitPrice;
                dtl_dr[LinePrice] = (td.UnitPrice * td.DeliveredGoodsCount);

                dt.Rows.Add(dtl_dr);

            }

            DetailGrid.DataSource = dt;

        }

        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }

        private void DetailGrid_InitializeLayout()
        {

            Infragistics.Win.UltraWinGrid.UltraGrid grid = DetailGrid;

            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //�񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            band.Columns[BLPartsCode].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;//BL�R�[�h
            band.Columns[PartsNoWithHyphen].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//�i��
            band.Columns[PmPartsNameKana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//�i��
            band.Columns[DeliveredGoodsCount].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//����
            band.Columns[UnitPrice].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//�P��
            band.Columns[LinePrice].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//���v

            band.Columns[BLPartsCode].Width = 60;	//BL�R�[�h
            band.Columns[PartsNoWithHyphen].Width = 180;	//�i��
            band.Columns[PmPartsNameKana].Width = 240;	//�i��
            band.Columns[DeliveredGoodsCount].Width = 50;	//����
            band.Columns[UnitPrice].Width = 90;	//�P��
            band.Columns[LinePrice].Width = 90;	//���v

            // �\����
            band.Columns[BLPartsCode].Header.VisiblePosition = 0;	//BL�R�[�h
            band.Columns[PartsNoWithHyphen].Header.VisiblePosition = 1;	//�i��
            band.Columns[PmPartsNameKana].Header.VisiblePosition = 2;	//�i��
            band.Columns[DeliveredGoodsCount].Header.VisiblePosition = 3;	//����
            band.Columns[UnitPrice].Header.VisiblePosition = 4;	//�P��
            band.Columns[LinePrice].Header.VisiblePosition = 5;	//���v

            // ����
            band.Columns[UnitPrice].Format = "#,##0;-#,##0;";	//�P��
            band.Columns[LinePrice].Format = "#,##0;-#,##0;";	//���v
            band.Columns[BLPartsCode].Format = "#####;";	//BL�R�[�h

            // �\���ʒu
            band.Columns[BLPartsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//BL�R�[�h
            band.Columns[PartsNoWithHyphen].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//�i��
            band.Columns[PmPartsNameKana].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//�i��
            band.Columns[DeliveredGoodsCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//����
            band.Columns[UnitPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//�P��
            band.Columns[LinePrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//���v

            // �L�[����}�b�s���O��ǉ�
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	//Enter�L�[
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0)
                );

        }

		#endregion
	}
}