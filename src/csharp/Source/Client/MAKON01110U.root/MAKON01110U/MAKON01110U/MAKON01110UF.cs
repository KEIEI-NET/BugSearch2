using System;
using System.Collections;
using System.IO;
using System.Data;
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
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2008.05.21</br>
    /// </remarks>
    internal class ColDisplayStatusList
	{
		//-----------------------------------------------------------
		// �R���X�g���N�^
		//-----------------------------------------------------------
		#region ��Constructor
		/// <summary>
		/// ��\����ԃN���X�R���N�V�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="colDisplayStatusList">ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024�@���X�؁@��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public ColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			// �e��C���X�^���X��
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatusExp>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatusExp>();
			this._colDisplayStatusKeyList = new List<string>();
			this._stockDetailDataTable = stockDetailDataTable;
			this._colDisplayStatusTable = new DataTable();

			// �\���Œ�񃊃X�g����
			this._visibleFixedColList = new List<string>();
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName);		// �s�ԍ�
			this._visibleFixedColList.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName);					// ���i�R�[�h
			this._visibleFixedColList.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName);				// ���i����
			this._visibleFixedColList.Add(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName);			// ���[�J�[
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName);		// ����(�\��)
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName);	// �P��(�\��)
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName);		// �d�����z(�\��)

			// ���͌Œ�񃊃X�g����
			this._enterStopFixedColList = new List<string>();
			this._enterStopFixedColList.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName);     // �s�ԍ�
			this._enterStopFixedColList.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName);               // ���i�R�[�h
			this._enterStopFixedColList.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName);             // ���i����
			this._enterStopFixedColList.Add(this._stockDetailDataTable.OpenPriceColumn.ColumnName);             // OP
            this._enterStopFixedColList.Add(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName);     // ����(�\��)
            this._enterStopFixedColList.Add(this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName);      // �I��
			this._enterStopFixedColList.Add(this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName); // ���݌ɐ�
			this._enterStopFixedColList.Add(this._stockDetailDataTable.MemoExistColumn.ColumnName);             // ����
            //this._enterStopFixedColList.Add(this._stockDetailDataTable.OrderNumberColumn.ColumnName);           // �����ԍ�
            //this._enterStopFixedColList.Add(this._stockDetailDataTable.SalesInfoExistColumn.ColumnName);		// ����

			// �w�b�_�Œ胊�X�g
			//int headervisiblePosition = 0;
			//this._headerFixedColList = new Dictionary<string, int>();
			this._headerFixedColList = new List<string>();
			this._headerFixedColList.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName);	// �s�ԍ�
			this._headerFixedColList.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName);				// ���i�R�[�h
            //this._headerFixedColList.Add(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName);				// ���[�J�[�R�[�h
            //this._headerFixedColList.Add(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName);				// BL�R�[�h
            this._headerFixedColList.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName);			// ���i����

			// ������\����ԃ��X�g����
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;

			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName, visiblePosition++, true, 44, true, true, false));		// ��
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, 130, false, true, true));				// ���i    
            //initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 45, false, true, false));		// ���[�J�[�R�[�h
            //initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 53, false, true, false));			// BL�R�[�h
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, 140, false, true, true));			// ���i��
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 45, false, true, false));        // ���[�J�[�R�[�h
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 53, false, true, false));         // BL�R�[�h
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, 90, false, true, false));	// �艿
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.OpenPriceColumn.ColumnName, visiblePosition++, false, 38, false, true, false));			// OP
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName, visiblePosition++, false, 65, false, true, true));	// ����
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockRateColumn.ColumnName, visiblePosition++, false, 60, false, true, false));			// �d����
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName, visiblePosition++, false, 90, false, true, true));// �P���i�\���p�j
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName, visiblePosition++, false, 105, false, true, true));	// �d�����z�i�\���p�j
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 45, false, true, true));		// �q��
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 65, false, true, false));	// �I��
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName, visiblePosition++, false, 65, false, true, false));// ���݌ɐ�
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName, visiblePosition++, false, 366, false, true, true));	// �d���`�[���ה��l1
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName, visiblePosition++, false, 76, false, true, true));	// ���Ӑ�
            //initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.OrderNumberColumn.ColumnName, visiblePosition++, false, 70, false, false, false));		// �����ԍ�
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.MemoExistColumn.ColumnName, visiblePosition++, false, 38, false, true, false));			// ����
			//initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.SalesInfoExistColumn.ColumnName, visiblePosition++, false, 40, false, true, false));		// ����

			// ������\����ԃ��X�g�i�[����
			foreach (ColDisplayStatusExp initStatus in initStatusList)
			{
				this._colDisplayStatusKeyList.Add(initStatus.Key);
				this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
			}

			// ��\����ԃN���X���X�g�������̏ꍇ�́A������\����ԃ��X�g��ݒ�
			if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
			{
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
					ColDisplayStatusExp colDisplayStatus = null;

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
						ColDisplayStatusExp colDisplayStatus = null;

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
					else
					{
						ColDisplayStatusExp colDisplayStatusExp = this.GetColDisplayStatus(colKey);
						if (this._headerFixedColList.Contains(colKey))
						{
							colDisplayStatusExp.HeaderFixed = true;
							colDisplayStatusExp.VisiblePosition = _headerFixedColList.IndexOf(colKey);
						}
						else
						{
							colDisplayStatusExp.HeaderFixed = false;
						}
					}

					// �e�[�u���Ɋ܂܂�Ȃ����ڂ̓��X�g����폜�i���ׂ����炵�Ă��G���[�ɂ����Ȃ��j
					if (!stockDetailDataTable.Columns.Contains(colKey))
					{
						if (this.ContainsKey(colKey))
						{
							ColDisplayStatusExp colDisplayStatusExp = this.GetColDisplayStatus(colKey);
							if (colDisplayStatusExp != null)
							{
								this.Remove(colDisplayStatusExp);
							}
						}
					}
				}
			}

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
		}
		#endregion

		//-----------------------------------------------------------
		// �v���C�x�[�g�ϐ�
		//-----------------------------------------------------------
		#region ��Private Members
		/// <summary>��\����ԃN���X���X�g</summary>
		private List<ColDisplayStatusExp> _colDisplayStatusList = null;

		/// <summary>��\����ԃN���X�i�[Dictionary</summary>
		private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusDictionary = null;

		/// <summary>������\����ԃN���X�i�[Dictionary</summary>
		private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusInitDictionary = null;

		/// <summary>��\����ԃL�[���X�g</summary>
		private List<string> _colDisplayStatusKeyList = null;

		/// <summary>�d�����׃f�[�^�e�[�u��</summary>
		StockInputDataSet.StockDetailDataTable _stockDetailDataTable;

		/// <summary>��\����ԃN���X�e�[�u��</summary>
		private DataTable _colDisplayStatusTable;

		/// <summary>�\���Œ�񃊃X�g</summary>
		private List<string> _visibleFixedColList;

		/// <summary>Enter���͌Œ�񃊃X�g</summary>
		private List<string> _enterStopFixedColList;

		/// <summary>�\���Œ�񃊃X�g</summary>
		private List<string> _headerFixedColList;
		//private Dictionary<string,int> _headerFixedColList;
		
		#endregion

		//-----------------------------------------------------------
		// �p�u���b�N���\�b�h
		//-----------------------------------------------------------
		#region ��Public Methods
		/// <summary>
        /// ��\����ԃL�[�i�[���f����
        /// </summary>
        /// <param name="key">�Ώۗ�\����ԃL�[</param>
        /// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
        public bool ContainsKey( string key )
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

		/// <summary>
		/// ��\����ԃL�[�i�[���f����
		/// </summary>
		/// <param name="key">�Ώۗ�\����ԃL�[</param>
		/// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public ColDisplayStatusExp GetColDisplayStatus( string key )
		{
			if (this.ContainsKey(key))
			{
				foreach (ColDisplayStatusExp colDisplayStatusExp in this._colDisplayStatusList)
				{
					if (colDisplayStatusExp.Key == key)
					{
						//return this._colDisplayStatusDictionary[key];
						return colDisplayStatusExp;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// ��\���e�[�u���擾
		/// </summary>
		/// <returns></returns>
		public List<ColDisplayInfo> GetColDisplayInfoList()
		{
			List<ColDisplayInfo> colDisplayInfoList = new List<ColDisplayInfo>();
			foreach (ColDisplayStatusExp colDisplayStatusExp in this._colDisplayStatusList)
			{
				if (colDisplayStatusExp.ReadOnly == false)
				{
					colDisplayInfoList.Add(ColDisplayInfoFromColDisplayStatus(colDisplayStatusExp));
				}
			}
			return colDisplayInfoList;
		}

		/// <summary>
		/// ��\���e�[�u���擾
		/// </summary>
		/// <returns></returns>
		public List<ColDisplayInfo> GetColDisplayInfoInitList()
		{
			List<ColDisplayInfo> colDisplayInfoList = new List<ColDisplayInfo>();
			foreach (ColDisplayStatusExp colDisplayStatusExp in this._colDisplayStatusInitDictionary.Values)
			{
				if (colDisplayStatusExp.ReadOnly == false)
				{
					colDisplayInfoList.Add(ColDisplayInfoFromColDisplayStatus(colDisplayStatusExp));
				}
			}
			return colDisplayInfoList;
		}
		/// <summary>
		/// ��\���e�[�u������\����ԃN���X���X�g�ɃZ�b�g���܂��B
		/// </summary>
		/// <param name="colDisplayInfoList"></param>
		public void SetColDisplayStatusListFromColDisplayInfoList( List<ColDisplayInfo> colDisplayInfoList )
		{
			foreach (ColDisplayInfo colDisplayInfo in colDisplayInfoList)
			{
				if (this.ContainsKey(colDisplayInfo.Key))
				{
					ColDisplayStatusExp colDisplayStatusExp = this.GetColDisplayStatus(colDisplayInfo.Key);
					colDisplayStatusExp.VisiblePosition = colDisplayInfo.VisiblePosition;
					colDisplayStatusExp.EnterStop = colDisplayInfo.EnterStop;
					colDisplayStatusExp.Visible = colDisplayInfo.Visible;
				}
			}
			this.Sort();
		}

        /// <summary>
        /// ���בւ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��\���ʒu�����בւ��܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�擾����
        /// </summary>
		/// <returns>ColDisplayStatusExp�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public List<ColDisplayStatusExp> GetColDisplayStatusList()
        {
            // �\���ʒu�ɂ��\�[�g����
            this.Sort();

            return this._colDisplayStatusList;
        }

		/// <summary>
		/// ��\����ԃN���X���X�g�ݒ菈��
		/// </summary>
		/// <param name="colDisplayStatusList">�ݒ肷��ColDisplayStatusExp�N���X���X�g�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g��ݒ肵�܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void SetColDisplayStatusList( List<ColDisplayStatusExp> colDisplayStatusList,bool saveHidden )
		{
			foreach (ColDisplayStatusExp colDisplayStatusExp in colDisplayStatusList)
			{
				if (this.ContainsKey(colDisplayStatusExp.Key))
				{
					colDisplayStatusExp.ReadOnly = this.GetColDisplayStatus(colDisplayStatusExp.Key).ReadOnly;
					colDisplayStatusExp.EnterStop = this.GetColDisplayStatus(colDisplayStatusExp.Key).EnterStop;
					if (!saveHidden)
					{
						colDisplayStatusExp.Visible = this.GetColDisplayStatus(colDisplayStatusExp.Key).Visible;
					}
				}
			}

			this._colDisplayStatusList = colDisplayStatusList;

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
		}
		
		/// <summary>
		/// ��\����ԃN���X��ReadOnly�v���p�e�B��ݒ肵�܂��B
		/// </summary>
		/// <param name="key">��\����ԃN���X�L�[</param>
		/// <param name="readOnly">ReadOnly�v���p�e�B</param>
		public void SetColDisplayStatusReadOnly( string key, bool readOnly )
		{
		}

        /// <summary>
        /// ��\����ԃN���X���X�g�V���A���C�Y����
        /// </summary>
		/// <param name="displayStatusList">�V���A���C�Y�Ώ�ColDisplayStatusExp�N���X���X�g�̃C���X�^���X</param>
        /// <param name="fileName">�V���A���C�Y��t�@�C������</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���V���A���C�Y���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public static void Serialize( List<ColDisplayStatusExp> colDisplayStatusList, string fileName )
        {
			ColDisplayStatusExp[] colDisplayStatusArray = new ColDisplayStatusExp[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y���t�@�C������</param>
		/// <returns>�f�V���A���C�Y���ꂽColDisplayStatusExp�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �f�V���A���C�Y������\����ԃN���X���X�g��Ԃ��܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public static List<ColDisplayStatusExp> Deserialize( string fileName )
        {
			List<ColDisplayStatusExp> retList = new List<ColDisplayStatusExp>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatusExp[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatusExp[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

					foreach (ColDisplayStatusExp colDisplayStatus in retArray)
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

		//-----------------------------------------------------------
		// �v���C�x�[�g���\�b�h
		//-----------------------------------------------------------
		#region ��Private Methods
        /// <summary>
        /// ��\����ԃN���X�ǉ�����
        /// </summary>
		/// <param name="colDisplayStatus">�ǉ�����ColDisplayStatusExp�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary�ɒǉ����܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		private void Add( ColDisplayStatusExp colDisplayStatus )
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
		/// <param name="colDisplayStatus">�폜����ColDisplayStatusExp�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		private void Remove( ColDisplayStatusExp colDisplayStatus )
        {
            // ����L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
            if (!( this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) ))
            {
                return;
            }

			ColDisplayStatusExp status = null;

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
		/// <param name="colDisplayStatusList">�i�[����ColDisplayStatusExp�N���X�̃��X�g�̃C���X�^���X</param>
        /// <returns>��\����ԃN���X�i�[Dictionary�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		private Dictionary<string, ColDisplayStatusExp> ToColStatusDictionaryFromColStatusList( List<ColDisplayStatusExp> colDisplayStatusList )
        {
			Dictionary<string, ColDisplayStatusExp> retDictionary = new Dictionary<string, ColDisplayStatusExp>();

			foreach (ColDisplayStatusExp status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }

		/// <summary>
		/// ��\����ԃN���X������N���X�i�[����
		/// </summary>
		/// <param name="colDisplayStatus"></param>
		/// <returns></returns>
		private ColDisplayInfo ColDisplayInfoFromColDisplayStatus( ColDisplayStatusExp colDisplayStatus )
		{
			ColDisplayInfo colDisplayInfo = new ColDisplayInfo();

			colDisplayInfo.Key = colDisplayStatus.Key;
			colDisplayInfo.FixedCol = colDisplayStatus.HeaderFixed;
			colDisplayInfo.Visible = colDisplayStatus.Visible;
			colDisplayInfo.VisiblePosition = colDisplayStatus.VisiblePosition;
			colDisplayInfo.EnterStop = colDisplayStatus.EnterStop;
			colDisplayInfo.VisibleControl = !( _visibleFixedColList.Contains(colDisplayStatus.Key) );
			colDisplayInfo.EnterStopControl = !( _enterStopFixedColList.Contains(colDisplayStatus.Key) );

			if (this._stockDetailDataTable.Columns.Contains(colDisplayStatus.Key))
			{
				colDisplayInfo.Caption = this._stockDetailDataTable.Columns[colDisplayStatus.Key].Caption;
			}

			return colDisplayInfo;
		}

        #endregion
	}
}