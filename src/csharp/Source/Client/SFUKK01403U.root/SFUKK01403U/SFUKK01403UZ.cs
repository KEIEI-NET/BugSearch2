using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �����`�[���́i�����^�j�t�h�f�o�b�O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����`�[���́i�����^�j�t�h�̃f�o�b�O�@�\���������܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
	/// </remarks>
	public class SFUKK01403UZ : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �����`�[���́i�����^�j�t�h�f�o�b�O�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01403UZ()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01403UZ));
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGrid2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraGrid2.Location = new System.Drawing.Point(0, 144);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(1000, 174);
            this.ultraGrid2.TabIndex = 82;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGrid1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1000, 144);
            this.ultraGrid1.TabIndex = 83;
            // 
            // SFUKK01403UZ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1000, 318);
            this.Controls.Add(this.ultraGrid2);
            this.Controls.Add(this.ultraGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK01403UZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�ύX���@����/���������f�[�^";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �\������
		/// </summary>
		/// <param name="dr1">�������</param>
		/// <param name="dr2">�����������</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/��������������ʂ֕\�����܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void DataSetBinding(System.Data.DataRow dr1, ArrayList dr2)
		{

			System.Data.DataTable dt1 = dr1.Table.Clone();
			System.Data.DataRow newRow1 = dt1.NewRow();
			newRow1.ItemArray = dr1.ItemArray;
			dt1.Rows.Add(newRow1);
			ultraGrid1.DataSource = dt1;
			ultraGrid1.Rows.ExpandAll(true);

			Infragistics.Win.UltraWinGrid.UltraGridBand bdDeposit = ultraGrid1.DisplayLayout.Bands[InputDepositNormalTypeAcs.ctDepositDataTable];
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDebitNoteNm].Header.Caption			= "�ԍ����";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositSlipNo].Header.Caption				= "�����ԍ�";
			// 2007.10.10 upd start ------------------------------------------------------------------------->>
            // �����v�����\��
            //bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDateDisp].Header.Caption				= "������";
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].Header.Caption = "������";
            // 2007.10.10 upd end ---------------------------------------------------------------------------<<

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositCd].Header.Caption					= "�敪�R�[�h";
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositNm].Header.Caption					= "�敪";

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindDivCd].Header.Caption				= "����敪";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindCode].Header.Caption				= "����R�[�h";
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindName].Header.Caption				= "����";
            // �� 20070125 18322 d MA.NS�p�ɕύX
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDeposit].Header.Caption				= "�����z(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrChargeDeposit].Header.Caption			= "�萔��(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDisDeposit].Header.Caption				= "�l��(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepositTotal].Header.Caption			= "�������v(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVariousCostDeposit].Header.Caption			= "�����z(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostChargeDeposit].Header.Caption			= "�萔��(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostDisDeposit].Header.Caption			= "�l��(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVariousCostDepositTotal].Header.Caption		= "�������v(��)";
            // �� 20070125 18322 d
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit].Header.Caption						= "�����z";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctFeeDeposit].Header.Caption					= "�萔��";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDiscountDeposit].Header.Caption				= "�l��";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositTotal].Header.Caption					= "�������v";
            // �� 20070125 18322 d MA.NS�p�ɕύX
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepositAlwc_Deposit].Header.Caption	= "�����z(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepoAlwcBlnce_Deposit].Header.Caption	= "�������z(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostDepoAlwc_Deposit].Header.Caption		= "�����z(��)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostDepoAlwcBlnce_Deposit].Header.Caption	= "�������z(��)";
            // �� 20070125 18322 d
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAllowance_Deposit].Header.Caption		= "�����z";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAlwcBlnce_Deposit].Header.Caption		= "�������z";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctOutline].Header.Caption						= "�E�v";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Header.Caption				= "��";

			if (dr2.Count == 0) return;
			System.Data.DataTable dt2 = ((System.Data.DataRow)dr2[0]).Table.Clone();
			foreach (System.Data.DataRow dr in dr2)
			{
				System.Data.DataRow newRow2 = dt2.NewRow();
				newRow2.ItemArray = dr.ItemArray;
				dt2.Rows.Add(newRow2);
			}
			ultraGrid2.DataSource = dt2;
			ultraGrid2.Rows.ExpandAll(true);

			Infragistics.Win.UltraWinGrid.UltraGridBand bdAllowance = ultraGrid2.DisplayLayout.Bands[0];
			bdAllowance.Columns[InputDepositNormalTypeAcs.ctDepositSlipNo_Alw].Header.Caption		= "�����ԍ�";		// �����ԍ�
            // �� 20070125 18322 d MA.NS�p�ɕύX
			//bdAllowance.Columns[InputDepositNormalTypeAcs.ctAcceptAnOrderNo_Alw].Header.Caption	= "�󒍔ԍ�";		// �󒍔ԍ�
			//bdAllowance.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepositAlwc].Header.Caption		= "�����z(��)";		// ���������z ��
			//bdAllowance.Columns[InputDepositNormalTypeAcs.ctVarCostDepoAlwc].Header.Caption		= "�����z(��)";		// ���������z ����p
            // �� 20070125 18322 d
			bdAllowance.Columns[InputDepositNormalTypeAcs.ctDepositAllowance].Header.Caption		= "�����z";			// ���������z ����
			bdAllowance.Columns[InputDepositNormalTypeAcs.ctReconcileDateDisp].Header.Caption		= "������";			// ������
		}
	}
}
