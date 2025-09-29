//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �S���ҕʎ��яƉ�R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ�\�����s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public partial class PMHNB04161UB : UserControl
    {
        #region �� Private Members

        /// <summary>�S���ҕʎ��яƉ�f�[�^�Z�b�g</summary>
        /// <remarks></remarks>
        private EmployeeResultsDataSet _dataSet;

        /// <summary>�S���ҕʎ��яƉ�A�N�Z�X</summary>
        /// <remarks></remarks>
        private EmployeeResultsAcs _employeeResultsAcs;

        #endregion

        #region �� Constroctors
        /// <summary>
        /// �S���ҕʎ��яƉ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ�N���X�R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public PMHNB04161UB()
        {
            InitializeComponent();
            this._employeeResultsAcs = EmployeeResultsAcs.GetInstance();
            this._dataSet = this._employeeResultsAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.EmployeeResults;

        }
        #endregion

        #region �� Event
        /// <summary>
        /// �R���g���[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����[�h�C�x���g���s��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void InputDetails_Load(object sender, EventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol(1);

            // �O���b�h�s�����ݒ菈��
            this.GridRowInitialSetting();

        }

        /// <summary>
        /// �O���b�h�s�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[�����[�h�C�x���g���s��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void GridRowInitialSetting()
        {
            this._dataSet.EmployeeResults.Rows.Clear();
        }

        /// <summary>
        /// �O���b�h�̏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏������C�x���g���s��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol(1);

        }
        #endregion

        #region �� Private Methods
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�񏉊��ݒ菈�����s��</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void InitialSettingGridCol(int flg)
        {
            const string moneyFormat = "#,##0;-#,##0;''";

            const string pctFormat = "0.00%;-0.00%;''";

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            band.UseRowLayout = true;
            int visiblePosition = 0;

            if (band == null)
            {
                return;
            }

            // --- ADD 2010/07/20-------------------------------->>>>>
            // ���_�R�[�h
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Hidden = true;
            // ���_����
            band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Hidden = true;
            // �J�n�N����
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Hidden = true;
            // �I���N����
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Hidden = true;
            // --- ADD 2010/07/20--------------------------------<<<<<

            # region [�J�����ݒ�]
            //head
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Width = 30;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Header.Caption = "No.";
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.OriginX = 0;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.SpanX = 2;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.SpanY = 4;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


            //����
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "����";
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].RowLayoutColumnInfo.OriginX = 2;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;




            //������z
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.Caption = "������z";
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginX = 4;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;



            //�ԕi�z
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.Caption = "�ԕi�z";
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginX = 6;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�l���z
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.Caption = "�l���z";
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginX = 8;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //������
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.Caption = "������";
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].RowLayoutColumnInfo.OriginX = 10;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


            //�`�[����

            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Hidden = false;
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Header.Caption = "�`�[����";
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Header.Caption = string.Empty;
            }
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Width = 50;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].RowLayoutColumnInfo.OriginX = 12;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //����ڕW
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.Caption = "����ڕW�z";
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].RowLayoutColumnInfo.OriginX = 14;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //����\��
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.Caption = "����\��";
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Width = 50;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].RowLayoutColumnInfo.OriginX = 16;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //����
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "����";
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 2;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //����
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.Caption = "����";
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].RowLayoutColumnInfo.OriginX = 4;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //�ԕi��
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.Caption = "�ԕi��";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 6;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�l����
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.Caption = "�l����";
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 8;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�e���z
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.Caption = "�e���z";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].RowLayoutColumnInfo.OriginX = 10;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�e����
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.Caption = "�e����";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 12;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�ڕW�B����
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.Caption = "�ڕW�B����";
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 14;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�ԕi�\��
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.Caption = "�ԕi�\��";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].RowLayoutColumnInfo.OriginX = 16;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            # endregion

        }
        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��(�o�͗p)
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�񏉊��ݒ菈�����s��</br>
        /// <br>Programer  : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        // --- UPD 2010/09/09 ---------->>>>>
        //public void InitialSettingGridColForOutput(int flg)
        public void InitialSettingGridColForOutput(int flg, int referDiv)
        // --- UPD 2010/09/09 ----------<<<<<
        {
            const string moneyFormat = "#,##0;-#,##0;''";

            const string pctFormat = "0.00%;-0.00%;''";

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            band.UseRowLayout = false;
            int visiblePosition = 1;

            if (band == null)
            {
                return;
            }

            # region [�J�����ݒ�]

            //No.
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Hidden = true;

            // --- UPD 2010/09/09 ---------->>>>>
            //���_
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Hidden = false;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Header.Caption = "���_";
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Width = 150;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Header.Caption = "���_";
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Width = 150;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            // --- UPD 2010/09/09 ----------<<<<<


            //�S���Һ���
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Hidden = false;
            // --- UPD 2010/09/09 ---------->>>>>
            //band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "�S����";
            if (referDiv == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "�S����";
            }
            else if (referDiv == 2)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "�󒍎�";
            }
            else if (referDiv == 3)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "���s��";
            }
            // --- UPD 2010/09/09 ----------<<<<<
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            
            //�S���Җ�
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Hidden = false;
            // --- UPD 2010/09/09 ---------->>>>>
            //band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "�S���Җ�";
            if (referDiv == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "�S���Җ�";
            }
            else if (referDiv == 2)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "�󒍎Җ�";
            }
            else if (referDiv == 3)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "���s�Җ�";
            }
            // --- UPD 2010/09/09 ----------<<<<<
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Width = 420;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            
            //�J�n�N����
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Hidden = false;
            if (flg == 1)
                band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Header.Caption = "�J�n�N����";
            else
                band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Header.Caption = "�J�n�N��";
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�I���N����
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Hidden = false;
            if (flg == 1)
                band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Header.Caption = "�I���N����";
            else
                band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Header.Caption = "�I���N��";
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //������z
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.Caption = "������z";
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�ԕi�z
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.Caption = "�ԕi�z";
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�ԕi��
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.Caption = "�ԕi��";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�l���z
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.Caption = "�l���z";
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            
            //�l����
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.Caption = "�l����";
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //������
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.Caption = "������";
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �`�[�������B��
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Hidden = true;

            //����ڕW
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.Caption = "����ڕW�z";
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�ڕW�B����
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.Caption = "����ڕW�B����";
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�e���z
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.Caption = "�e���z";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�e����
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.Caption = "�e����";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //����
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.Caption = "����";
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //����\����
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.Caption = "����\����";
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //�ԕi�\����
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.Caption = "�ԕi�\����";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            # endregion

        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s��</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\���菈�����s��</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}