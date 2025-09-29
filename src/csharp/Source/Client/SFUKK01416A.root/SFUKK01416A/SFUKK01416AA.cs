using System;
using System.Data;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���������\���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���������\���t�h�N���X�𑀍삷��A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.19</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS�p�ɕύX</br>
	/// <br>                                         1. �󒍁E����p���폜</br>
    /// <br>                                         2. ��ʃf�U�C���ύX�Ή�</br>
    /// <br>Update Note: 2007.10.05 20081 �D�c �E�l DC.NS�p�ɕύX</br>
    /// <br></br>
	/// </remarks>
	public class DepositAlwViewAcs
	{
		# region Constructor
		/// <summary>
		/// ���������\���A�N�Z�X�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���������\���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public DepositAlwViewAcs()
		{
			// �������� DataSet
			this._dsDepositAlwInfo = new DataSet();

			// ������������A�N�Z�X�N���X
			this.controlDepsitAlwAcs = new ControlDepsitAlwAcs(); 
		}
		# endregion

		# region Private Menbers
		//***************************************************************
		// ��ʃo�C���h�p DataSet
		//***************************************************************
		/// <summary>�������� DataSet</summary>
		private DataSet _dsDepositAlwInfo;

		//***************************************************************
		// �����o�[
		//***************************************************************
		/// <summary>������������A�N�Z�X�N���X</summary>
		private ControlDepsitAlwAcs controlDepsitAlwAcs;
		# endregion

		# region public const Menbers
		//***************************************************************
		// ��������DataSet�p�萔�錾
		//***************************************************************
		/// <summary>�������Table����</summary>
		public const string ctDepositAlwDataTable = "DepositAlwDataTable";

		/// <summary>�����`�[�ԍ�</summary>
		public const string ctDepositSlipNo = "DepositSlipNo";

		///// <summary>�󒍓`�[�ԍ�</summary>
		//public const string ctAcceptAnOrderNo = "AcceptAnOrderNo";  // 2007.10.05 hikita del
        
        // �� 20070131 18322 d MA.NS�p�ɕύX
		///// <summary>���������z ��</summary>
		//public const string ctAcpOdrDepositAlwc = "AcpOdrDepositAlwc";
        //
		///// <summary>���������z ����p</summary>
		//public const string ctVarCostDepoAlwc = "VarCostDepoAlwc";
        // �� 20070131 18322 d

		/// <summary>���������z ����</summary>
		public const string ctDepositAllowance = "DepositAllowance";

		/// <summary>������(�\���p)</summary>
		public const string ctReconcileDateDisp = "ReconcileDateDisp";

		/// <summary>������</summary>
		public const string ctReconcileDate = "ReconcileDate";

		/// <summary>�����v����t</summary>
		public const string ctReconcileAddUpADate = "ReconcileAddUpADate";
		# endregion

		# region public Methods
		/// <summary>
		/// ��������DataSet����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : DataSet�����������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		public void ClearDsDepositAlwInfo()
		{
			// DataSet������
			_dsDepositAlwInfo.Clear();
		}

		/// <summary>
		/// ��������DataSet�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : DataSet���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		public DataSet GetDsDepositAlwInfo()
		{
			return _dsDepositAlwInfo;
		}

		/// <summary>
		/// �������� DataSet Table �쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���������f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
		///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.26</br>
		/// </remarks>
		public void CreateDepositAlwDataTable()
		{
			// �f�[�^�e�[�u���̗��`
			DataTable dtDepositAlwTable = new DataTable(ctDepositAlwDataTable);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			dtDepositAlwTable.Columns.Add(ctDepositSlipNo, typeof(int));					// �����`�[�ԍ�
			//dtDepositAlwTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));					// �󒍓`�[�ԍ�    // 2007.10.05 hikita del
            // �� 20070131 18322 d MA.NS�p�ɕύX
			//dtDepositAlwTable.Columns.Add(ctAcpOdrDepositAlwc, typeof(Int64));				// ���������z ��
			//dtDepositAlwTable.Columns.Add(ctVarCostDepoAlwc, typeof(Int64));				// ���������z ����p
            // �� 20070131 18322 d
			dtDepositAlwTable.Columns.Add(ctDepositAllowance, typeof(Int64));				// ���������z ����
			dtDepositAlwTable.Columns.Add(ctReconcileDateDisp, typeof(string));				// ������(�\���p)
			dtDepositAlwTable.Columns.Add(ctReconcileDate, typeof(int));					// ������
			dtDepositAlwTable.Columns.Add(ctReconcileAddUpADate, typeof(int));				// �����v���

			// �f�[�^�Z�b�g�ɒǉ�
			_dsDepositAlwInfo.Tables.Add(dtDepositAlwTable.Clone());
		}

		/// <summary>
		/// ���������f�[�^�擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�󒍔ԍ��̓��������f�[�^���擾���܂��B
		///	                :   �� Method : GetDsDepositAlwInfo ��茋�ʎ擾</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
        public int SearchAllowanceOfAcceptOdrNo(string enterpriseCode, int customerCode, int acptAnOdrStatus, string salesSlipNum, out string message)
		{
			message = "";
			DepositAlwWork[] depositAlwWorkList;

            int st = controlDepsitAlwAcs.ReadDB(enterpriseCode, customerCode, acptAnOdrStatus, salesSlipNum, out depositAlwWorkList, out message);
			switch (st)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

					// ���������f�[�^�e�[�u�� �f�[�^�Z�b�g����
					foreach(DepositAlwWork depositAlwWork in depositAlwWorkList)
					{
						// ��������DataSet�̍s��ǉ�����
						DataRow drNew = this._dsDepositAlwInfo.Tables[ctDepositAlwDataTable].NewRow();
						this._dsDepositAlwInfo.Tables[ctDepositAlwDataTable].Rows.Add(drNew);

						// ��������DataRow�Z�b�g����
						SetDepositAlw(drNew, depositAlwWork);
					}

					break;

				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    // �� 20070131 18322 c MA.NS�p�ɕύX
					//message = "�w�肳�ꂽ�󒍔ԍ��ɑ΂�����������͑��݂��܂���ł����B";

					message = "�w�肳�ꂽ����ԍ��ɑ΂�����������͑��݂��܂���ł����B";
                    // �� 20070131 18322 c
					break;

				default :

					break;
			}

			return st;
		}

		/// <summary>
		/// ���������f�[�^�擾����
		/// </summary>
		/// <returns>�����������v�z</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �����������v�z���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		public Int64 GetTotalDepositAllowance()
		{
			Int64 total = 0;

			foreach (System.Data.DataRow dr in _dsDepositAlwInfo.Tables[ctDepositAlwDataTable].Rows)
			{
				total += Convert.ToInt64(dr[ctDepositAllowance]);
			}

			return total;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// ��������DetaRow�Z�b�g����
		/// </summary>
		/// <param name="drNew">��������DataRow</param>
		/// <param name="depositAlwWork">���������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����������DataRow�ɃZ�b�g���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDepositAlw(System.Data.DataRow drNew, DepositAlwWork depositAlwWork)
		{
			// �����`�[�ԍ�
			drNew[ctDepositSlipNo] = depositAlwWork.DepositSlipNo;

			// �󒍓`�[�ԍ�
			// drNew[ctAcceptAnOrderNo] = depositAlwWork.AcceptAnOrderNo;  // 2007.10.05 hikita del

            // �� 20070131 18322 d MA.NS�p�ɕύX
			//// ���������z ��
			//drNew[ctAcpOdrDepositAlwc] = depositAlwWork.AcpOdrDepositAlwc;
            //
			//// ���������z ����p
			//drNew[ctVarCostDepoAlwc] = depositAlwWork.VarCostDepoAlwc;
            // �� 20070131 18322 d

			// ���������z ����
			drNew[ctDepositAllowance] = depositAlwWork.DepositAllowance;

            // �� 20070418 18322 c MA.NS�Ή�
			//// ������(�\���p)
			//drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", depositAlwWork.ReconcileDate);

			// ������(�\���p)
			drNew[ctReconcileDateDisp] = depositAlwWork.ReconcileDate.ToString("yyyy/MM/dd");
            // �� 20070418 18322 c

			// ������
			drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(depositAlwWork.ReconcileDate);

			// �����v����t
			drNew[ctReconcileAddUpADate] = TDateTime.DateTimeToLongDate(depositAlwWork.ReconcileAddUpDate);
		}
		# endregion
	}
}
