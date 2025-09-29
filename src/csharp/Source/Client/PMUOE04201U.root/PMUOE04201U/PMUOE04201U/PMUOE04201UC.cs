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
	/// <br>Programmer : �Ɠc �M�u</br>
	/// <br>Date       : 2008/11/10</br>
	/// </remarks>
	internal class ColDisplayStatusList
	{
        #region ���萔�A�ϐ��A�\����
        private List<ColDisplayStatus> _colDisplayStatusList = null;                            // ��\����ԃN���X���X�g
        private List<string> _colDisplayStatusKeyList = null;                                   // ��\����ԃL�[���X�g
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;        // ��\����ԃN���X�i�[Dictionary
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;    // ������\����ԃN���X�i�[Dictionary
        #endregion

		#region ��Constructor
		/// <summary>
		/// ��\����ԃN���X�R���N�V�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="colDisplayStatusList">ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public ColDisplayStatusList( List<ColDisplayStatus> colDisplayStatusList)
		{
			// �e��C���X�^���X��
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusKeyList = new List<string>();

			// ������\����ԃ��X�g����
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_No, visiblePosition++, false, 10));                     // No
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SelectFlg, visiblePosition++, true, 48));               // �I��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_ReceiveDate, visiblePosition++, false, 92));            // ��M���t
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_ReceiveTime, visiblePosition++, false, 92));            // ��M����
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESalesOrderNo, visiblePosition++, false, 92));        // �����ԍ�
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESalesOrderRowNo, visiblePosition++, false, 108));    // �����s�ԍ�
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESupplierCd, visiblePosition++, false, 108));         // ������R�[�h
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESupplierName, visiblePosition++, false, 166));       // �����於��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOEDeliGoodsDiv, visiblePosition++, false, 92));        // UOE�[�i�敪
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_FollowDeliGoodsDiv, visiblePosition++, false, 124));    // �t�H���[�[�i�敪
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOCode, visiblePosition++, false, 76));                 // BO�敪
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_EmployeeCode, visiblePosition++, false, 108));          // �˗��҃R�[�h
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_EmployeeName, visiblePosition++, false, 166));          // �˗��Җ���
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_CustomerCode, visiblePosition++, false, 108));          // ���Ӑ�R�[�h
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_CustomerSnm, visiblePosition++, false, 166));           // ���Ӑ於��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_GoodsNo, visiblePosition++, false, 196));               // �i��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_GoodsMakerCd, visiblePosition++, false, 60));           // ���[�J�[
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_GoodsName, visiblePosition++, false, 166));             // �i��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOERemark1, visiblePosition++, false, 166));            // ���}�[�N1
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOERemark2, visiblePosition++, false, 88));             // ���}�[�N2
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_AcceptAnOrderCnt, visiblePosition++, false, 92));       // ��������
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESectOutGoodsCnt, visiblePosition++, false, 108));    // ���_�o�ɐ�
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESectionSlipNo, visiblePosition++, false, 124));      // ���_�`�[�ԍ�
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOShipmentCnt1, visiblePosition++, false, 70));         // �t�H���[1
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOSlipNo1, visiblePosition++, false, 132));             // �t�H���[�`�[�ԍ�1
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOShipmentCnt2, visiblePosition++, false, 70));         // �t�H���[2
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOSlipNo2, visiblePosition++, false, 132));             // �t�H���[�`�[�ԍ�2
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOShipmentCnt3, visiblePosition++, false, 70));         // �t�H���[3
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOSlipNo3, visiblePosition++, false, 132));             // �t�H���[�`�[�ԍ�3
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MakerFollowCnt, visiblePosition++, false, 108));        // ���[�J�[�t�H���[��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_ListPrice, visiblePosition++, false, 96));              // �艿
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SalesUnitCost, visiblePosition++, false, 92));          // �d�ؒP��
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESubstMark, visiblePosition++, false, 92));           // ��֋敪
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_PartsLayerCd, visiblePosition++, false, 108));          // �w��(���Y)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOManagementNo, visiblePosition++, false, 156));        // EO�Ǘ��ԍ�(���Y)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_EOAlwcCount, visiblePosition++, false, 140));           // EO������(���Y)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1, visiblePosition++, false, 140));   // ���_�R�[�h(�}�c�_)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2, visiblePosition++, false, 146));   // �t�H���[�R�[�h1(�}�c�_)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3, visiblePosition++, false, 146));   // �t�H���[�R�[�h2(�}�c�_)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_LineErrorMessage, visiblePosition++, false, 320));      // �G���[���b�Z�[�W
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SourceShipment, visiblePosition++, false, 156));        // �o�׌��R�[�h(�z���_)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SectionCode, visiblePosition++, false, 10));            // ���_�R�[�h(�����[�p����)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SectionName, visiblePosition++, false, 10));            // ���_����(�����[�p����)

			// ������\����ԃ��X�g�i�[����
			foreach (ColDisplayStatus initStatus in initStatusList)
			{
				this._colDisplayStatusKeyList.Add(initStatus.Key);
				this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
			}

			// ��\����ԃN���X���X�g�������̏ꍇ�́A������\����ԃ��X�g��ݒ�
			if (( this._colDisplayStatusList == null ) || ( this._colDisplayStatusList.Count == 0 ))
			{
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
                    if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                    {
                        this._colDisplayStatusList.Add(this._colDisplayStatusInitDictionary[colKey]);
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
                        if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                        {
                            ColDisplayStatus colDisplayStatus = null;
                            colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];

                            colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colDisplayStatus);
                        }
					}
				}
			}

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
        }
        #endregion ��Constructor - end

        #region ��Public
        #region ��GetColDisplayStatusList(��\����ԃN���X���X�g-�擾)
        /// <summary>
		/// ��\����ԃN���X���X�g�擾����
		/// </summary>
		/// <returns>ColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g���擾���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public List<ColDisplayStatus> GetColDisplayStatusList()
		{
			// �\���ʒu�ɂ��\�[�g����
			this.Sort();

			return this._colDisplayStatusList;
		}
        #endregion

        #region ��SetColDisplayStatusList(��\����ԃN���X���X�g-�ݒ�)
        /// <summary>
		/// ��\����ԃN���X���X�g�ݒ菈��
		/// </summary>
		/// <param name="colDisplayStatusList">�ݒ肷��ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g��ݒ肵�܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public void SetColDisplayStatusList( List<ColDisplayStatus> colDisplayStatusList )
		{
			this._colDisplayStatusList = colDisplayStatusList;

			// �\���ʒu�ɂ��\�[�g����
			this.Sort();
        }
        #endregion

        #region ��Serialize(��\����ԃN���X���X�g-�V���A���C�Y)
        /// <summary>
		/// ��\����ԃN���X���X�g�V���A���C�Y����
		/// </summary>
		/// <param name="displayStatusList">�V���A���C�Y�Ώ�ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
		/// <param name="fileName">�V���A���C�Y��t�@�C������</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g���V���A���C�Y���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public static void Serialize( List<ColDisplayStatus> colDisplayStatusList, string fileName )
		{
			ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
			colDisplayStatusList.CopyTo(colDisplayStatusArray);

			UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }
        #endregion

        #region ��Deserialize(��\����ԃN���X���X�g-�f�V���A���C�Y)
        /// <summary>
		/// ��\����ԃN���X���X�g�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y���t�@�C������</param>
		/// <returns>�f�V���A���C�Y���ꂽColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note       : �f�V���A���C�Y������\����ԃN���X���X�g��Ԃ��܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public static List<ColDisplayStatus> Deserialize( string fileName )
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
        #endregion ��Public - end

        #region ��Private
        #region ��Add(��\����ԃN���X����\����ԃN���X�i�[Dicrionary�ǉ�)
        /// <summary>
		/// ��\����ԃN���X�ǉ�����
		/// </summary>
		/// <param name="colDisplayStatus">�ǉ�����ColDisplayStatus�N���X�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary�ɒǉ����܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private void Add( ColDisplayStatus colDisplayStatus )
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
        #endregion

        #region ��ContainsKey(��\����ԃN���X�i�[Dictionary-�ΏۃL�[�L������)
        /// <summary>
        /// ��\����ԃL�[�i�[���f����
        /// </summary>
        /// <param name="key">�Ώۗ�\����ԃL�[</param>
        /// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }
        #endregion

        #region ��Sort(��\����ԃN���X���X�g-���בւ�)
        /// <summary>
        /// ���בւ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��\���ʒu�����בւ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void Sort()
        {
            this._colDisplayStatusList.Sort();
        }
        #endregion

        #region ��ToColStatusDictionaryFromColStatusList(��\����ԃN���X���X�g��Dictionary�f�[�^�R�s�[)
        /// <summary>
		/// ��\����ԃN���X���X�g��Dictionary�R�s�[����
		/// </summary>
		/// <param name="colDisplayStatusList">�i�[����ColDisplayStatus�N���X�̃��X�g�̃C���X�^���X</param>
		/// <returns>��\����ԃN���X�i�[Dictionary�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note       : ��\����ԃN���X���X�g�̃f�[�^��Dictionary�ɃR�s�[���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList( List<ColDisplayStatus> colDisplayStatusList )
		{
			Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

			foreach (ColDisplayStatus status in colDisplayStatusList)
			{
				retDictionary.Add(status.Key, status);
			}

			return retDictionary;
        }
        #endregion
        #endregion ��Private - end
    }
}