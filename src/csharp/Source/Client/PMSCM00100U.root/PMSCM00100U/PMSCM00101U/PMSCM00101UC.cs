using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ��\����ԃN���X�R���N�V�����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ��\����ԃN���X�̃R���N�V�����N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ� ����Y</br>
	/// <br>Date       : 2006.06.21</br>
	/// </remarks>
	internal class ColDisplayStatusList
	{
		#region Constructor
		/// <summary>
		/// ��\����ԃN���X�R���N�V�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="colDisplayStatusList">ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public ColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList, SimpleInqCTIDataSet.SalesSlipDataTable salesSlipDataTable)
		{
			// �e��C���X�^���X��
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusKeyList = new List<string>();
			this._salesSlipDataTable = salesSlipDataTable;

			// ������\����ԃ��X�g����
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SearchSlipNumColumn.ColumnName, visiblePosition++, true, 80));

			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DetailRowCountColumn.ColumnName, visiblePosition++, false, 80));
			
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSlipKindNameColumn.ColumnName, visiblePosition++, false, 60));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSlipCdNameColumn.ColumnName, visiblePosition++, false, 85));
#if False
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AcptAnOdrStatusNameColumn.ColumnName, visiblePosition++, false, 80));
#endif
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesFormalNameColumn.ColumnName, visiblePosition++, false, 85));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SlipDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AddUpADateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesTotalTaxIncColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.FrontEmployeeNmColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesEmployeeNmColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CustomerCodeColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CustomerNameColumn.ColumnName, visiblePosition++, false, 200));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.EstimateDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AcceptAnOrderDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DeliGdsCmpltDueDateStringColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ShipmentDayStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DebitNoteDivNameColumn.ColumnName, visiblePosition++, false, 60));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.WayToOrderNameColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AccRecDivNameColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.TotalAmountDispWayNameColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesTotalTaxExcColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSubtotalTaxIncColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSubtotalTaxExcColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalSubttlSubToTaxFreColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSubtotalTaxColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.TotalCostColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ServiceDepositsColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.TaxAdjustColumn.ColumnName, visiblePosition++, false, 110));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.BalanceAdjustColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DemandableTtlColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ClaimCodeColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ClaimNameColumn.ColumnName, visiblePosition++, false, 200));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SlipNoteColumn.ColumnName, visiblePosition++, false, 200));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CorporateDivCodeNameColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesGoodsCdNameColumn.ColumnName, visiblePosition++, false, 115));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AcceptAnOrderNoColumn.ColumnName, visiblePosition++, false, 80));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.RegiProcDateStringColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CashRegisterNoColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.PosReceiptNoColumn.ColumnName, visiblePosition++, false, 110));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DemandAddUpSecNameColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesInpSecNameColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ResultsAddUpSecNameColumn.ColumnName, visiblePosition++, false, 120));

			// ������\����ԃ��X�g�i�[����
			foreach (ColDisplayStatus initStatus in initStatusList)
			{
				this._colDisplayStatusKeyList.Add(initStatus.Key);
				this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
			}

			// ��\����ԃN���X���X�g�������̏ꍇ�́A������\����ԃ��X�g��ݒ�
			if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
			{
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
					ColDisplayStatus colDisplayStatus = null;

					try
					{
						colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
					}
					catch (KeyNotFoundException)
					{
						//
					}

					if (colDisplayStatus != null)
					{
						this._colDisplayStatusList.Add(colDisplayStatus);
					}
				}

				// ��\����ԃN���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
				this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
			}
			else
			{
				// ��\����ԃN���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
				this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

				// ������\����ԃ��X�g�Ɨ�\����ԃN���X�i�[Dictionary�̒l���r���A�s�������[����
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
					if (!this.ContainsKey(colKey))
					{
						ColDisplayStatus colDisplayStatus = null;

						try
						{
							colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
						}
						catch (KeyNotFoundException)
						{
							//
						}

						if (colDisplayStatus != null)
						{
							colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
							this.Add(colDisplayStatus);
						}
					}
				}
			}

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
		}
		#endregion

		#region Private Members
		/// <summary>��\����ԃN���X���X�g</summary>
		private List<ColDisplayStatus> _colDisplayStatusList = null;

		/// <summary>��\����ԃN���X�i�[Dictionary</summary>
		private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;

		/// <summary>������\����ԃN���X�i�[Dictionary</summary>
		private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;

		/// <summary>��\����ԃL�[���X�g</summary>
		private List<string> _colDisplayStatusKeyList = null;

		/// <summary>����f�[�^�e�[�u��</summary>
		private SimpleInqCTIDataSet.SalesSlipDataTable _salesSlipDataTable;
		#endregion

		#region Public Methods
		/// <summary>
		/// ��\����ԃL�[�i�[���f����
		/// </summary>
		/// <param name="key">�Ώۗ�\����ԃL�[</param>
		/// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public bool ContainsKey(string key)
		{
			return this._colDisplayStatusDictionary.ContainsKey(key);
		}

		/// <summary>
		/// ���בւ�����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g��\���ʒu�����בւ��܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public void Sort()
		{
			this._colDisplayStatusList.Sort();
		}

		/// <summary>
		/// ��\����ԃN���X���X�g�擾����
		/// </summary>
		/// <returns>ColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g���擾���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public List<ColDisplayStatus> GetColDisplayStatusList()
		{
			// �\���ʒu�ɂ��\�[�g����
			this.Sort();

			return this._colDisplayStatusList;
		}

		/// <summary>
		/// ��\����ԃN���X���X�g�ݒ菈��
		/// </summary>
		/// <param name="colDisplayStatusList">�ݒ肷��ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g��ݒ肵�܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public void SetColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList)
		{
			this._colDisplayStatusList = colDisplayStatusList;

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
		}

		/// <summary>
		/// ��\����ԃN���X���X�g�V���A���C�Y����
		/// </summary>
		/// <param name="displayStatusList">�V���A���C�Y�Ώ�ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <param name="fileName">�V���A���C�Y��t�@�C������</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g���V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public static void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
		{
			ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
			colDisplayStatusList.CopyTo(colDisplayStatusArray);

			UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

		}

		/// <summary>
		/// ��\����ԃN���X���X�g�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y���t�@�C������</param>
		/// <returns>�f�V���A���C�Y���ꂽColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note       : �f�V���A���C�Y������\����ԃN���X���X�g��Ԃ��܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public static List<ColDisplayStatus> Deserialize(string fileName)
		{
			List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
			{
				try
				{
					ColDisplayStatus[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

					foreach (ColDisplayStatus colDisplayStatus in retArray)
					{
						retList.Add(colDisplayStatus);
					}
				}
				catch (System.InvalidOperationException)
				{
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
				}
			}

			return retList;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// ��\����ԃN���X�ǉ�����
		/// </summary>
		/// <param name="colDisplayStatus">�ǉ�����ColDisplayStatus�N���X�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary�ɒǉ����܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		private void Add(ColDisplayStatus colDisplayStatus)
		{
			// ���ɓ���L�[�����݂���ꍇ�͏������Ȃ�
			if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key))
			{
				return;
			}

			this._colDisplayStatusList.Add(colDisplayStatus);
			this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
		}

		/// <summary>
		/// ��\����ԃN���X�폜����
		/// </summary>
		/// <param name="colDisplayStatus">�폜����ColDisplayStatus�N���X�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		private void Remove(ColDisplayStatus colDisplayStatus)
		{
			// ����L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
			if (!(this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key)))
			{
				return;
			}

			ColDisplayStatus status = null;

			try
			{
				status = this._colDisplayStatusDictionary[colDisplayStatus.Key];
			}
			catch (KeyNotFoundException)
			{
				//
			}

			if (status == null)
			{
				return;
			}

			this._colDisplayStatusList.Remove(status);
			this._colDisplayStatusDictionary.Remove(colDisplayStatus.Key);

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
		}

		/// <summary>
		/// ��\����ԃN���X���X�g��Dictionary�i�[����
		/// </summary>
		/// <param name="colDisplayStatusList">�i�[����ColDisplayStatus�N���X�̃��X�g�̃C���X�^���X</param>
		/// <returns>��\����ԃN���X�i�[Dictionary�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ� ����Y</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatus> colDisplayStatusList)
		{
			Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

			foreach (ColDisplayStatus status in colDisplayStatusList)
			{
				retDictionary.Add(status.Key, status);
			}

			return retDictionary;
		}
		#endregion
	}
}