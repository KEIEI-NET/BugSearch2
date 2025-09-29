using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���i���͒��o�����ݒ�R���N�V�����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i���͂̒��o�����ݒ�N���X�̃R���N�V�����N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.1.9</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 ���n ���</br>
    /// <br>           : PM.NS�Ή�(�R�����g����)</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/13 30517 �Ė� �x��</br>
    /// <br>           : ���o�����E���o���ʃf�[�^�O���b�h����i���J�i���폜</br>
    /// </remarks>
	internal class GoodsExtractConditionItems : ExtractConditionItemsBase
	{
		#region Constructor

		/// <summary>
		/// ���i���͒��o�����ݒ�R���N�V�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="extractConditionItemList">���o�����A�C�e���N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : ���i���͒��o�����ݒ�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public GoodsExtractConditionItems(List<ExtractConditionItem> extractConditionItemList)
			: base(extractConditionItemList)
		{
		}

		#endregion

		#region Protected Methods

		/// <summary>
		/// �������o�����ݒ�N���X���X�g�ݒ�ǉ�����
		/// </summary>
		/// <param name="initItemList">���o�����ݒ�N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : �������o�����ݒ�N���X���X�g�ɐݒ��ǉ����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		protected override void SetInitExtractConditionItemList( List<ExtractConditionItem> initItemList )
		{
			int itemNo = 0;

            initItemList.Add(new ExtractConditionItem(CT_ITEM_MAKER, ++itemNo, "���[�J�[", true));
            initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSCODE, ++itemNo, "�i��", true));
            initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSNAME, ++itemNo, "�i��", true));
            //initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSNAMEKANA, ++itemNo, "�i����", true));    // 2010/07/13 Del
			initItemList.Add(new ExtractConditionItem(CT_ITEM_LARGEGOODSGANRE, ++itemNo, "���i�啪��", true));
			initItemList.Add(new ExtractConditionItem(CT_ITEM_MEDIUMGOODSGANRE, ++itemNo, "���i������", true));
			initItemList.Add(new ExtractConditionItem(CT_ITEM_DETAILGOODSGANRE, ++itemNo, "�O���[�v�R�[�h", true));
            initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSKINDCODE, ++itemNo, "���i����", true));
		}

		#endregion
	}


	/// <summary>
	/// ���o�����ݒ�R���N�V�������N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���o�����ݒ�N���X�̃R���N�V�����̊��N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.1.9</br>
	/// </remarks>
	internal class ExtractConditionItemsBase
	{
		#region Constructor

		/// <summary>
		/// ���o�����ݒ�R���N�V�������N���X�R���X�g���N�^
		/// </summary>
		/// <param name="extractConditionItemList">���o�����A�C�e���N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�R���N�V�������N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public ExtractConditionItemsBase( List< ExtractConditionItem> extractConditionItemList )
		{
			// �C���X�^���X������
			this._extractConditionItemList           = extractConditionItemList;
			this._extractConditionItemDictionary     = new Dictionary<string, ExtractConditionItem>();
			this._extractConditionItemInitDictionary = new Dictionary<string, ExtractConditionItem>();
			this._extractConditionKeyList            = new List<string>();

			// �������o�����A�C�e�����X�g�쐬
			List<ExtractConditionItem> initItemList = new List<ExtractConditionItem>();

			this.SetInitExtractConditionItemList( initItemList );

			foreach( ExtractConditionItem item in initItemList ) {
				this._extractConditionKeyList.Add( item.Key );
				this._extractConditionItemInitDictionary.Add( item.Key, item );
			}

			// ���o�����ݒ�N���X���X�g�������̏ꍇ�́A�����l��ݒ�
			if( ( this._extractConditionItemList == null ) || ( this._extractConditionItemList.Count == 0 ) ) {
				foreach( string key in this._extractConditionKeyList ) {
					ExtractConditionItem item = null;

					try {
						item = this._extractConditionItemInitDictionary[ key ];
					}
					catch( KeyNotFoundException ) {
						// 
					}

					if( item != null ) {
						this._extractConditionItemList.Add( item );
					}
				}

				// ���o�����ݒ�N���X�i�[Dictionary���ŐV�̏��ɂčĐ���
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList( this._extractConditionItemList );
			}
			else {
				// ���o�����ݒ�N���X�i�[Dictionary���ŐV�̏��ɂčĐ���
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList( this._extractConditionItemList );

				// �f�t�H���g�l�ƈ����̒l���r���A�s�������[����
				foreach( string key in this._extractConditionKeyList ) {
					if( this.ContainsKey( key ) == false ) {
						ExtractConditionItem item = null;

						try {
							item = this._extractConditionItemInitDictionary[ key ];
						}
						catch( KeyNotFoundException ) {
							// 
						}

						if( item != null ) {
							item.No = this._extractConditionItemList.Count + 1;
							this.Add( item );
						}
					}
				}
			}

			this.Sort();
		}

		#endregion

		#region Constant

        /// <summary>���[�J�[</summary>
        public const string CT_ITEM_MAKER = "MakerCode";
        /// <summary>���i�啪��</summary>
		public const string CT_ITEM_LARGEGOODSGANRE = "GoodsLGroup";
        /// <summary>���i������</summary>
        public const string CT_ITEM_MEDIUMGOODSGANRE = "GoodsMGroup";
        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string CT_ITEM_DETAILGOODSGANRE = "BLGroupCode";
        /// <summary>�i��</summary>
		public const string CT_ITEM_GOODSCODE = "GoodsNo";
        /// <summary>�i��</summary>
        public const string CT_ITEM_GOODSNAME = "GoodsName";
        /// <summary>�i���J�i</summary>
		public const string CT_ITEM_GOODSNAMEKANA = "GoodsNameKana";
		/// <summary>���i���</summary>
		public const string CT_ITEM_GOODSKINDCODE = "GoodsKindCode";

		#endregion

		#region Private Members

		/// <summary>���o�����ݒ�N���X���X�g</summary>
		private List<ExtractConditionItem>              _extractConditionItemList           = null;
		private Dictionary<string,ExtractConditionItem> _extractConditionItemDictionary     = null;
		private Dictionary<string,ExtractConditionItem> _extractConditionItemInitDictionary = null;
		private List<string>                            _extractConditionKeyList            = null;

		#endregion

		#region Protected Methods

		/// <summary>
		/// �������o�����ݒ�N���X���X�g�ݒ�ǉ�����
		/// </summary>
		/// <param name="initItemList">���o�����ݒ�N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : ���z���\�b�h�B�������o�����ݒ�N���X���X�g�ɐݒ��ǉ����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		protected virtual void SetInitExtractConditionItemList( List<ExtractConditionItem> initItemList )
		{
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// ���o�����ݒ�N���X���X�g���o�����ݒ�N���X�i�[Dictionary�R�s�[����
		/// </summary>
		/// <param name="extractConditionItemList">���o�����ݒ�N���X���X�g</param>
		/// <returns>���o�����ݒ�N���X�i�[Dictionary</returns>
		private Dictionary<string, ExtractConditionItem> ToItemDictionaryFromItemList( List<ExtractConditionItem> extractConditionItemList )
		{
			// �C���X�^���X���쐬
			Dictionary<string,ExtractConditionItem> retDictionary = new Dictionary<string,ExtractConditionItem>();

			// ���X�g�̓��e��o�^
			foreach( ExtractConditionItem item in extractConditionItemList ) {
				retDictionary.Add( item.Key, item );
			}

			return retDictionary;
		}

		/// <summary>
		/// ���o�����ݒ�N���X�ǉ�����
		/// </summary>
		/// <param name="extractConditionItem">�ǉ��Ώے��o�����ݒ�N���X</param>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���R���N�V�����ɒǉ����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		private void Add( ExtractConditionItem extractConditionItem )
		{
			// ���ɓ���L�[�����݂���ꍇ�͏������Ȃ�
			if( this._extractConditionItemDictionary.ContainsKey( extractConditionItem.Key ) == true ) {
				return;
			}

			this._extractConditionItemList.Add( extractConditionItem );
			this._extractConditionItemDictionary.Add( extractConditionItem.Key, extractConditionItem );

			this.Sort();
		}

		/// <summary>
		/// ���o�����ݒ�N���X�폜����
		/// </summary>
		/// <param name="extractConditionItem">�폜�Ώے��o�����ݒ�N���X</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�I�u�W�F�N�g�ƈ�v����I�u�W�F�N�g���R���N�V��������폜���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		private void Remove( ExtractConditionItem extractConditionItem )
		{
			// ����L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
			if( this._extractConditionItemDictionary.ContainsKey( extractConditionItem.Key ) == false ) {
				return;
			}

			ExtractConditionItem item = this._extractConditionItemDictionary[ extractConditionItem.Key ];

			if( item == null ) {
				return;
			}

			this._extractConditionItemList.Remove( item );
			this._extractConditionItemDictionary.Remove( item.Key );

			this.Sort();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// ���o�����ݒ�N���X�R���N�V�����\�[�g����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X�R���N�V�����̃\�[�g���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public void Sort()
		{
			this._extractConditionItemList.Sort();
		}

		/// <summary>
		/// ���o�����ݒ�N���X���X�g�擾����
		/// </summary>
		/// <returns>���o�����ݒ�N���X���X�g</returns>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���X�g�̎擾���s���܂� �B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public List<ExtractConditionItem> GetExtractConditionItemList()
		{
			return this._extractConditionItemList;
		}

		/// <summary>
		/// ���o�����ݒ�N���X���X�g�ݒ菈��
		/// </summary>
		/// <param name="extractConditionItemList">���o�����ݒ�N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���X�g�̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public void SetExtractConditionItemList( List<ExtractConditionItem> extractConditionItemList )
		{
			this._extractConditionItemList = extractConditionItemList;
			this._extractConditionItemList.Sort();
		}

		/// <summary>
		/// �L�[���݃`�F�b�N����
		/// </summary>
		/// <param name="key">�R���N�V�������Ō��������L�[</param>
		/// <returns>�`�F�b�N����(true:���݂���, false:���݂��Ȃ�)</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�L�[���R���N�V�������ɑ��݂��邩�ǂ����𔻒f���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public bool ContainsKey( string key )
		{
			return this._extractConditionItemDictionary.ContainsKey( key );
		}

		#endregion

		#region Public Static Methods

		/// <summary>
		/// ���o�����ݒ�N���X���X�g�V���A���C�Y����
		/// </summary>
		/// <param name="extractConditionItemList">���o�����ݒ�N���X���X�g</param>
		/// <param name="fileName">�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���X�g�̃V���A���C�Y�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public static void Serialize( List<ExtractConditionItem> extractConditionItemList, string fileName )
		{
			ExtractConditionItem[] extractConditionItemArray = new ExtractConditionItem[ extractConditionItemList.Count ];
			extractConditionItemList.CopyTo( extractConditionItemArray );

			UserSettingController.SerializeUserSetting(extractConditionItemArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
		}

		/// <summary>
		/// ���o�����ݒ�N���X���X�g�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�t�@�C����</param>
		/// <returns>���o�����ݒ�N���X���X�g</returns>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���X�g�̃f�V���A���C�Y�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public static List<ExtractConditionItem> Deserialize( string fileName )
		{
			List<ExtractConditionItem> retList = new List<ExtractConditionItem>();

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)) == true)
			{
				try {
					ExtractConditionItem[] retArray = UserSettingController.DeserializeUserSetting<ExtractConditionItem[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));

					foreach( ExtractConditionItem extractConditionItem in retArray ) {
						retList.Add( extractConditionItem );
					}
				}
				catch( System.InvalidOperationException ) {
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
			}

			return retList;
		}

		#endregion
	}
}
