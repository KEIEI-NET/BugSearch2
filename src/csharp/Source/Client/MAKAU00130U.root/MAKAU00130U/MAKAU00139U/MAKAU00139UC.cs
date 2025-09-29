using System;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
	/// <summary>
	/// �d�����ח�\���󋵃N���X
	/// </summary>
	internal class ProductStockDisplayStatus
	{
		//====================================================================================================
		//  �v���C�x�[�g�萔
		//====================================================================================================
		#region �v���C�x�[�g�萔
		/// <summary>
		/// �N���XID(TEMP�ۑ��p)
		/// </summary>
		private const string CT_CLASSID = "MAZAI04380UC";
		/// <summary>
		/// KEYLIST(TEMP�ۑ��p)
		/// </summary>
//		private const string CT_KEYLIST = "PtSupSlipDtlStatus";
        #endregion
        #region �񏇒�`�萔
        /// <summary>�s�ԍ�</summary>
        public const int ctINDX_RowNum = 0;
		/// <summary>���i�R�[�h</summary>
		public const int ctINDX_GoodsCode = ctINDX_RowNum + 1;
        /// <summary>���i�K�C�h</summary>
        public const int ctINDX_GoodsGuide = ctINDX_GoodsCode + 1;
		/// <summary>���i����</summary>
		public const int ctINDX_GoodsName = ctINDX_GoodsGuide + 1;
		/// <summary>�@��</summary>
		public const int ctINDX_CellphoneModelName = ctINDX_GoodsName + 1;
		/// <summary>�����ԍ�</summary>
		public const int ctINDX_ProductNumber = ctINDX_CellphoneModelName + 1;
		/// <summary>�g�єԍ�</summary>
		public const int ctINDX_StockTelNo1 = ctINDX_ProductNumber + 1;
		/// <summary>�d����</summary>
        public const int ctINDX_CustomerName = ctINDX_StockTelNo1 + 1;
		#endregion

		#region �񖼒�`�萔
        /// <summary>�s�ԍ�</summary>
        public const string ctCOL_RowNum = "RowNum";
        /// <summary>���i�R�[�h</summary>
        public const string ctCOL_GoodsCode = "GoodsCode";
        /// <summary>���i�K�C�h</summary>
        public const string ctCOL_GoodsGuide = "GoodsGuide";
        /// <summary>���i����</summary>
        public const string ctCOL_GoodsName = "GoodsName";
        /// <summary>�@��</summary>
        public const string ctCOL_CellphoneModelName = "CellphoneModelName";
        /// <summary>�����ԍ�</summary>
        public const string ctCOL_ProductNumber = "ProductNumber";
        /// <summary>�g�єԍ�</summary>
        public const string ctCOL_StockTelNo1 = "StockTelNo1";
        /// <summary>�d����</summary>
        public const string ctCOL_CustomerName = "CustomerName";

        /// <summary>�����T�C�Y</summary>
		private const string ctCOL_FontSize = "FontSize";
		/// <summary>���ŊO�ŗ��\��</summary>
//		private const string ctCOL_TaxDisplay = "TaxDisplay";
		#endregion

		#region �񏉊��l�e�[�u��
		/// <summary>
		/// ���ח�\���X�e�[�^�X�̏����l
		/// </summary>
		private SlipDtlDisplayStatus[] CT_DEFAULTSTATUS = new SlipDtlDisplayStatus[]
			{
                //                       ����             �C���f�b�N�X     ��  Visible
                new SlipDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,30,true),
				new SlipDtlDisplayStatus(ctCOL_GoodsCode, ctINDX_GoodsCode, 160, true),          	            // ���i�R�[�h
                new SlipDtlDisplayStatus(ctCOL_GoodsGuide,ctINDX_GoodsGuide,30,true),                           // ���i�K�C�h
				new SlipDtlDisplayStatus(ctCOL_GoodsName, ctINDX_GoodsName, 160, true),			        	    // ���i����
				new SlipDtlDisplayStatus(ctCOL_CellphoneModelName, ctINDX_CellphoneModelName, 160, true),	    // �@��
				new SlipDtlDisplayStatus(ctCOL_ProductNumber, ctINDX_ProductNumber, 140, true),			        // �����ԍ�
				new SlipDtlDisplayStatus(ctCOL_StockTelNo1, ctINDX_StockTelNo1, 140, true),  	// �g�єԍ�
				new SlipDtlDisplayStatus(ctCOL_CustomerName, ctINDX_CustomerName, 160, true),					// �d����
			};
		#endregion


		//====================================================================================================
		//  �v���C�x�[�g�ϐ��錾
		//====================================================================================================
		#region �v���C�x�[�g�ϐ�
		/// <summary>
		/// �d�����ח�X�e�[�^�X
		/// </summary>
		private ArrayList mDetailStatus;
		/// <summary>
		/// �t�H���g�T�C�Y
		/// </summary>
		private int _fontSize = 11;
		/// <summary>
		/// ���ŊO�ŗ��\��
		/// </summary>
//		private bool _dispBothTaxway = false;
		#endregion

		//====================================================================================================
		//  �R���X�g���N�^
		//====================================================================================================
		#region �R���X�g���N�^
		/// <summary>
		/// ���ԍ݌ɃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ԍ݌ɃN���X�̃C���X�^���X���쐬���A���������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public ProductStockDisplayStatus()
		{
			mDetailStatus = new ArrayList();

            InitializeStatus(ctCOL_RowNum);
			// ���i�R�[�h
			InitializeStatus(ctCOL_GoodsCode);
            // ���i�K�C�h
            
			// ���i����
			InitializeStatus(ctCOL_GoodsName);
			// �@��
			InitializeStatus(ctCOL_CellphoneModelName);
			// �����ԍ�
			InitializeStatus(ctCOL_ProductNumber);
			// �g�єԍ�
			InitializeStatus(ctCOL_StockTelNo1);
			// �d����
			InitializeStatus(ctCOL_CustomerName);

		}
		#endregion

		//====================================================================================================
		//  �p�u���b�N�v���p�e�B
		//====================================================================================================
		#region �p�u���b�N�v���p�e�B
		#region [�\���ʒu]�v���p�e�B

        /// <summary>
        /// [�\���ʒu]�s�ԍ�
        /// </summary>
        public int Order_RowNum
        {
            get { return GetVisiblePosition(ctCOL_RowNum); }
            set { SetVisiblePosition(ctCOL_RowNum, value); }
        }

        /// <summary>
		/// [�\���ʒu]���i�R�[�h
		/// </summary>
		public int Order_GoodsCode
		{
			get { return GetVisiblePosition(ctCOL_GoodsCode); }
			set { SetVisiblePosition(ctCOL_GoodsCode, value); }
		}
        /// <summary>
        /// [�\���ʒu]���i�K�C�h
        /// </summary>
        public int Order_GoodsGuide
        {
            get { return GetVisiblePosition(ctCOL_GoodsGuide); }
            set { SetVisiblePosition(ctCOL_GoodsGuide, value); }
        }

		/// <summary>
		/// [�\���ʒu]���i����
		/// </summary>
		public int Order_GoodsName
		{
			get { return GetVisiblePosition(ctCOL_GoodsName); }
			set { SetVisiblePosition(ctCOL_GoodsName, value); }
		}
		/// <summary>
		/// [�\���ʒu]�@��
		/// </summary>
		public int Order_CellphoneModelName
		{
			get { return GetVisiblePosition(ctCOL_CellphoneModelName); }
			set { SetVisiblePosition(ctCOL_CellphoneModelName, value); }
		}
		/// <summary>
		/// [�\���ʒu]�����ԍ�
		/// </summary>
		public int Order_ProductNumber
		{
			get { return GetVisiblePosition(ctCOL_ProductNumber); }
			set { SetVisiblePosition(ctCOL_ProductNumber, value); }
		}
		/// <summary>
		/// [�\���ʒu]�g�єԍ�
		/// </summary>
		public int Order_StockTelNo1
		{
			get { return GetVisiblePosition(ctCOL_StockTelNo1); }
			set { SetVisiblePosition(ctCOL_StockTelNo1, value); }
		}
		/// <summary>
		/// [�\���ʒu]�d����
		/// </summary>
		public int Order_CustomerName
		{
			get { return GetVisiblePosition(ctCOL_CustomerName); }
			set { SetVisiblePosition(ctCOL_CustomerName, value); }
		}
		#endregion

		#region [�\��]�v���p�e�B

        /// <summary>
        /// [�\��]�s�ԍ�
        /// </summary>
        public bool Visible_RowNum
        {
            get { return GetVisible(ctCOL_RowNum); }
            set { SetVisible(ctCOL_RowNum, value); }
        }
		/// <summary>
		/// [�\��]���i�R�[�h
		/// </summary>
		public bool Visible_GoodsCode
		{
			get { return GetVisible(ctCOL_GoodsCode); }
			set { SetVisible(ctCOL_GoodsCode, value); }
		}
        /// <summary>
        /// [�\��]���i�K�C�h
        /// </summary>
        public bool Visible_GoodsGuide
        {
            get { return GetVisible(ctCOL_GoodsGuide); }
            set { SetVisible(ctCOL_GoodsGuide, value); }
        }
        /// <summary>
		/// [�\��]���i����
		/// </summary>
		public bool Visible_GoodsName
		{
			get { return GetVisible(ctCOL_GoodsName); }
			set { SetVisible(ctCOL_GoodsName, value); }
		}
		/// <summary>
		/// [�\��]�@��
		/// </summary>
		public bool Visible_CellphoneModelName
		{
			get { return GetVisible(ctCOL_CellphoneModelName); }
			set { SetVisible(ctCOL_CellphoneModelName, value); }
		}
		/// <summary>
		/// [�\��]�����ԍ�
		/// </summary>
		public bool Visible_ProductNumber
		{
			get { return GetVisible(ctCOL_ProductNumber); }
			set { SetVisible(ctCOL_ProductNumber, value); }
		}
		/// <summary>
		/// [�\��]�g�єԍ�
		/// </summary>
		public bool Visible_StockTelNo1
		{
			get { return GetVisible(ctCOL_StockTelNo1); }
			set { SetVisible(ctCOL_StockTelNo1, value); }
		}
		/// <summary>
		/// [�\��]�d����
		/// </summary>
		public bool Visible_CustomerName
		{
			get { return GetVisible(ctCOL_CustomerName); }
			set { SetVisible(ctCOL_CustomerName, value); }
		}
		#endregion

		#region [��]�v���p�e�B
        /// <summary>
        /// [��]�s�ԍ�
        /// </summary>
        public int Width_RowNum
        {
            get { return GetWidth(ctCOL_RowNum); }
            set { SetWidth(ctCOL_RowNum, value); }
        }
		/// <summary>
		/// [��]���i�R�[�h
		/// </summary>
		public int Width_GoodsCode
		{
			get { return GetWidth(ctCOL_GoodsCode); }
			set { SetWidth(ctCOL_GoodsCode, value); }
		}
        /// <summary>
        /// [��]���i�K�C�h
        /// </summary>
        public int Width_GoodsGuide
        {
            get { return GetWidth(ctCOL_GoodsGuide); }
            set { SetWidth(ctCOL_GoodsGuide, value); }
        }
        /// <summary>
		/// [��]���i����
		/// </summary>
		public int Width_GoodsName
		{
			get { return GetWidth(ctCOL_GoodsName); }
			set { SetWidth(ctCOL_GoodsName, value); }
		}
		/// <summary>
		/// [��]�@��
		/// </summary>
		public int Width_CellphoneModelName
		{
			get { return GetWidth(ctCOL_CellphoneModelName); }
			set { SetWidth(ctCOL_CellphoneModelName, value); }
		}
		/// <summary>
		/// [��]�����ԍ�
		/// </summary>
		public int Width_ProductNumber
		{
			get { return GetWidth(ctCOL_ProductNumber); }
			set { SetWidth(ctCOL_ProductNumber, value); }
		}
		/// <summary>
		/// [��]�g�єԍ�
		/// </summary>
		public int Width_StockTelNo1
		{
			get { return GetWidth(ctCOL_StockTelNo1); }
			set { SetWidth(ctCOL_StockTelNo1, value); }
		}
		/// <summary>
		/// [��]�d����
		/// </summary>
		public int Width_CustomerName
		{
			get { return GetWidth(ctCOL_CustomerName); }
			set { SetWidth(ctCOL_CustomerName, value); }
		}
		#endregion

		/// <summary>
		/// �t�H���g�T�C�Y
		/// </summary>
		public int FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		/// <summary>
		/// ���ŊO�ŗ��\��
		/// </summary>
		public bool DispBothTaxway
		{
			get { return _dispBothTaxway; }
			set { _dispBothTaxway = value; }
		}
  
		#endregion

		//====================================================================================================
		//  �p�u���b�N���\�b�h
		//====================================================================================================
		#region �p�u���b�N���\�b�h
		/// <summary>
		/// ���ח�\���X�e�[�^�X�f�[�^���������ݒ肵�Ă��邩���`�F�b�N
		/// </summary>
		/// <returns>true=����,false=�ُ�</returns>
		/// <remarks>
		/// <br>Note       : ���ח�\���X�e�[�^�X������ɐݒ肵�Ă��邩���`�F�b�N���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public Boolean CheckDisplayStatus()
		{
			SlipDtlDisplayStatus _temp;

            // �s�ԍ�
            _temp = SearchDisplayStatus(ctCOL_RowNum);
            if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            // ���i�R�[�h
			_temp = SearchDisplayStatus(ctCOL_GoodsCode);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            // ���i�K�C�h
            _temp = SearchDisplayStatus(ctCOL_GoodsGuide);
            if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// ���i����
			_temp = SearchDisplayStatus(ctCOL_GoodsName);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// �@��
			_temp = SearchDisplayStatus(ctCOL_CellphoneModelName);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// �����ԍ�
			_temp = SearchDisplayStatus(ctCOL_ProductNumber);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// �g�єԍ�
			_temp = SearchDisplayStatus(ctCOL_StockTelNo1);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// �d����
			_temp = SearchDisplayStatus(ctCOL_CustomerName);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			return true;
		}

		/// <summary>
		/// ���ו\���X�e�[�^�X�f�[�^�������l�ɐݒ肷��B
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ו\���X�e�[�^�X��������Ԃɂ���B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public void SetDefaultValue()
		{
			SlipDtlDisplayStatus _temp;

            // �s�ԍ�
            _temp = SearchDisplayStatus(ctCOL_RowNum); if (_temp == null) _temp = InitializeStatus(ctCOL_RowNum);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_RowNum].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_RowNum].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_RowNum].Visible;            
            // ���i�R�[�h
			_temp = SearchDisplayStatus(ctCOL_GoodsCode); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsCode);
			_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsCode].VisiblePosition;
			_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Width;
			_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Visible;
            // ���i�K�C�h
            _temp = SearchDisplayStatus(ctCOL_GoodsGuide); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsGuide);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Visible;
            // ���i����
			_temp = SearchDisplayStatus(ctCOL_GoodsName); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsName);
			_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsName].VisiblePosition;
			_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsName].Width;
			_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsName].Visible;
			// �@��
			_temp = SearchDisplayStatus(ctCOL_CellphoneModelName); if (_temp == null) _temp = InitializeStatus(ctCOL_CellphoneModelName);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_CellphoneModelName].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_CellphoneModelName].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_CellphoneModelName].Visible;
			// �����ԍ�
            _temp = SearchDisplayStatus(ctCOL_ProductNumber); if (_temp == null) _temp = InitializeStatus(ctCOL_ProductNumber);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_ProductNumber].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Visible;
			// �g�єԍ�
            _temp = SearchDisplayStatus(ctCOL_StockTelNo1); if (_temp == null) _temp = InitializeStatus(ctCOL_StockTelNo1);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Visible;
			// �d����
			_temp = SearchDisplayStatus(ctCOL_CustomerName); if (_temp == null) _temp = InitializeStatus(ctCOL_CustomerName);
			_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_CustomerName].VisiblePosition;
			_temp.Width = CT_DEFAULTSTATUS[ctINDX_CustomerName].Width;
			_temp.Visible = CT_DEFAULTSTATUS[ctINDX_CustomerName].Visible;
			// �t�H���g�T�C�Y
			_fontSize = 11;

			// ���ŊO�ŗ��\��
//			_dispBothTaxway = false;
		}

		/// <summary>
		/// �N���X�f�[�^���V���A���C�Y����B
		/// </summary>
		/// <param name="_filename">�o�͂���t�@�C������</param>
		/// <remarks>
		/// <br>Note       : ���ח�X�e�[�^�X�����V���A���C�Y����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public void SerializeData(string _filename)
		{
			try
			{
				// �V���A���C�Y����O�ɁA�t�H���g�T�C�Y��ǉ����Ă���
				SlipDtlDisplayStatus _temp = SearchDisplayStatus(ctCOL_FontSize);

				// �܂������ێ����X�g�̒��ɂȂ�(�ԈႢ�Ȃ��Ȃ��͂��ł��I�I�I)
				if (_temp == null)
				{
					_temp = new SlipDtlDisplayStatus(ctCOL_FontSize, 9999, 11, false);
					mDetailStatus.Add(_temp);
				}

				// �t�H���g�T�C�Y�𕝂ɓ����
				_temp.Width = _fontSize;

				// �ێ����Ă�������o�C�g�z��ɕϊ�����
				SlipDtlDisplayStatus[] dtlStat = (SlipDtlDisplayStatus[])mDetailStatus.ToArray(typeof(SlipDtlDisplayStatus));

				Broadleaf.Application.Common.UserSettingController.ByteSerializeUserSetting(dtlStat, ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);
			}
			catch
			{
				// �����Ȃ��Ƃ���B
			}
		}

		/// <summary>
		/// �N���X�f�[�^���f�V���A���C�Y����B
		/// </summary>
		/// <param name="_filename">�擾����t�@�C������</param>
		/// <remarks>
		/// <br>Note       : ���ח�X�e�[�^�X�����f�V���A���C�Y����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public void DeserializeData(string _filename)
		{
			try
			{
				// �ݒ�f�[�^��READ����
				SlipDtlDisplayStatus[] dtl = Broadleaf.Application.Common.UserSettingController.ByteDeserializeUserSetting<SlipDtlDisplayStatus[]>(ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);

				// �f�[�^���������ꍇ
				if (dtl != null)
				{
					// ��U���X�g���폜
					mDetailStatus.Clear();

					foreach (SlipDtlDisplayStatus wk in dtl)
					{
						mDetailStatus.Add(wk.Clone());
					}
				}

				// �f�V���A���C�Y�����Ƃ��ɁA�t�H���g�f�[�^�E���ŊO�ŗ��\���͎擾�ナ�X�g����͍폜����
				// (Grid�̗�ł͂Ȃ��̂ł��̂܂܂���Ɩ��׉�ʂ��C������K�v�����邽��)
				if (mDetailStatus != null)
				{
					int[] delIndex = new int[] { -1, -1 };
					int ix = 0;

					foreach (SlipDtlDisplayStatus _st in mDetailStatus)
					{
						// �t�H���g�T�C�Y
						if (_st.ColName == ctCOL_FontSize)
						{
							_fontSize = _st.Width;
							delIndex[0] = ix;
						}
						// ���ŊO�ŗ��\��
//						else if (_st.ColName == ctCOL_TaxDisplay)
//						{
//							_dispBothTaxway = _st.Visible;
							delIndex[1] = ix;
//						}

						if ((delIndex[0] != -1) && (delIndex[1] != -1)) break;
						ix++;
					}

					// ���X�g���폜(��납��)
					Array.Sort(delIndex);
					for (int i = delIndex.Length -1; i >= 0; i--)
					{
						if (delIndex[i] != -1)
						{
							mDetailStatus.RemoveAt(delIndex[i]);
						}
					}
				}
			}
			catch
			{
				// �����Ȃ��Ƃ���B
			}
		}

		/// <summary>
		/// �\�����ɕ��ёւ���ꂽ�J�������̃��X�g���擾���܂��B
		/// </summary>
		/// <returns>�\�����̃J�������̃��X�g</returns>
		/// <remarks>
		/// <br>Note       : ���ח�\���X�e�[�^�X��\�����ɕ��ёւ��A���̃J�������̃��X�g���擾���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public System.Collections.ArrayList GetVisiblePositionList()
		{
			mDetailStatus.Sort(new VisibleCompare());

			System.Collections.ArrayList _retList = new System.Collections.ArrayList();
			for (int i = 0; i < mDetailStatus.Count; i++)
			{
				_retList.Add(((SlipDtlDisplayStatus)mDetailStatus[i]).ColName);
			}
			return _retList;
		}

		/// <summary>
		/// ���ו\����X�e�[�^�X��r
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ו\�����\�����ɕ��ёւ��܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		internal class VisibleCompare : System.Collections.IComparer
		{
			#region IComparer �����o
			/// <summary>
			/// ���ёւ�������
			/// </summary>
			/// <param name="x">����r�I�u�W�F�N�g</param>
			/// <param name="y">����r�I�u�W�F�N�g</param>
			/// <returns>0����:������,0:������,0����:x����</returns>
			/// <remarks>
			/// <br>Note       : �I�u�W�F�N�g���m���r���܂��B</br>
			/// <br>Programer  : 19077 �n糋M�T</br>
			/// <br>Date       : 2006.05.30</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				if ((x is SlipDtlDisplayStatus) && (y is SlipDtlDisplayStatus))
				{
					return ((SlipDtlDisplayStatus)x).VisiblePosition - ((SlipDtlDisplayStatus)y).VisiblePosition;
				}

				return 0;
			}

			#endregion
		}
		#endregion

		//====================================================================================================
		//  �v���C�x�[�g���\�b�h
		//====================================================================================================
		#region �v���C�x�[�g���\�b�h
		/// <summary>
		/// ���ח�\���X�e�[�^�X����
		/// </summary>
		/// <param name="_key">�J��������</param>
		/// <returns>�����������ח�\���X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���ח�\���X�e�[�^�X���������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private SlipDtlDisplayStatus SearchDisplayStatus(string _key)
		{
			if (mDetailStatus != null)
			{
				foreach (SlipDtlDisplayStatus _st in mDetailStatus)
				{
					if (_st.ColName == _key)
					{
						return _st;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// �w�肳�ꂽ���ח�̕\���󋵃X�e�[�^�X�����������܂��B
		/// </summary>
		/// <param name="_key">�����������</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���ו\����̕\���󋵃X�e�[�^�X�����������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private SlipDtlDisplayStatus InitializeStatus(string _key)
		{
			int _index = -1;

            // ���i�R�[�h
            if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }
            // ���i�R�[�h
			else if (_key == ctCOL_GoodsCode) { _index = ctINDX_GoodsCode; }
            // ���i�K�C�h
            else if (_key == ctCOL_GoodsGuide) { _index = ctINDX_GoodsGuide; }
            // ���i����
			else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }
			// �@��
			else if (_key == ctCOL_CellphoneModelName) { _index = ctINDX_CellphoneModelName; }
			// �����ԍ�
			else if (_key == ctCOL_ProductNumber) { _index = ctINDX_ProductNumber; }
			// �g�єԍ�
			else if (_key == ctCOL_StockTelNo1) { _index = ctINDX_StockTelNo1; }
			// �d����
			else if (_key == ctCOL_CustomerName) { _index = ctINDX_CustomerName; }

            int _width = 0;
			Boolean _visible = false;

			if (_index != -1)
			{
				_width = CT_DEFAULTSTATUS[_index].Width;
				_visible = CT_DEFAULTSTATUS[_index].Visible;
			}

			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			if (_temp == null)
			{
				_temp = new SlipDtlDisplayStatus(_key, -1, _width, _visible);
				mDetailStatus.Add(_temp);
			}
			else
			{
				_temp.Width = _width;
				_temp.Visible = _visible;
				_temp.VisiblePosition = -1;
			}
			return _temp;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���X�e�[�^�X���擾����B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <returns>true=�\��,false=��\��</returns>
		/// <remarks>
		/// <br>Note       : ��̕\���X�e�[�^�X�擾</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private Boolean GetVisible(string _key)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);

			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��߂��B
			return _temp.Visible;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���X�e�[�^�X��ݒ肷��B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <param name="_value">true=�\��,false=��\��</param>
		/// <remarks>
		/// <br>Note       : ��̕\���X�e�[�^�X�ݒ�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private void SetVisible(string _key, Boolean _value)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��ݒ肷��B
			_temp.Visible = _value;
		}

		/// <summary>
		/// �w�肳�ꂽ��̗񕝂��擾����B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <returns>�擾������</returns>
		/// <remarks>
		/// <br>Note       : ��̗񕝎擾</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private int GetWidth(string _key)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��߂��B
			return _temp.Width;
		}

		/// <summary>
		/// �w�肳�ꂽ��̗񕝂�ݒ肷��B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <param name="_width">��</param>
		/// <remarks>
		/// <br>Note       : ��̗񕝐ݒ�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private void SetWidth(string _key, int _width)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��ݒ肷��B
			_temp.Width = _width;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���ʒu���擾����B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <returns>�擾������ʒu</returns>
		/// <remarks>
		/// <br>Note       : ��̗�ʒu�擾</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private int GetVisiblePosition(string _key)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��߂��B
			return _temp.VisiblePosition;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���ʒu��ݒ肷��B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <param name="_position">�\���ʒu</param>
		/// <remarks>
		/// <br>Note       : ��̕\���ʒu�ݒ�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private void SetVisiblePosition(string _key, int _position)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��ݒ肷��B
			_temp.VisiblePosition = _position;
		}
		#endregion
	}
       --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
	
    /// <summary>
	/// ���ו\���󋵃N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`�[���ׂ̕\���󋵂������N���X</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2006.05.30</br>
	/// </remarks>
	[Serializable]
	public class SlipDtlDisplayStatus : ICloneable
	{
		#region �R���X�g���N�^
		/// <summary>
		/// ���ו\���󋵃N���X�R���X�g���N�^
		/// </summary>
		public SlipDtlDisplayStatus()
		{ }

		/// <summary>
		/// ���ו\���󋵃N���X�R���X�g���N�^
		/// </summary>
		/// <param name="_colName">�J��������</param>
		/// <param name="_position">�\���ʒu</param>
		/// <param name="_width">��</param>
		/// <param name="_visible">�\���^��\��</param>
		/// <remarks>
		/// <br>Note       : ���ו\���󋵃N���X�̃C���X�^���X���쐬���A���������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public SlipDtlDisplayStatus(string _colName, int _position, int _width, Boolean _visible)
		{
			mColName = _colName;
			mOrder = _position;
			mWidth = _width;
			mVisible = _visible;
		}
		#endregion

		#region	�v���C�x�[�g�ϐ�
		/// <summary>
		/// �\���ʒu
		/// </summary>
		private int mOrder = -1;
		/// <summary>
		/// ��
		/// </summary>
		private int mWidth = -1;
		/// <summary>
		/// �\��/��\��
		/// </summary>
		private Boolean mVisible = false;
		/// <summary>
		/// �J��������
		/// </summary>
		private string mColName = "";
		#endregion

		#region �p�u���b�N�v���p�e�B
		/// <summary>
		/// �\���ʒu
		/// </summary>
		public int VisiblePosition
		{
			get { return this.mOrder; }
			set { this.mOrder = value; }
		}
		/// <summary>
		/// ��
		/// </summary>
		public int Width
		{
			get { return this.mWidth; }
			set { this.mWidth = value; }
		}
		/// <summary>
		/// �\���^��\��
		/// </summary>
		public Boolean Visible
		{
			get { return this.mVisible; }
			set { this.mVisible = value; }
		}
		/// <summary>
		/// �J��������
		/// </summary>
		public string ColName
		{
			get { return this.mColName; }
			set { this.mColName = value; }
		}
		#endregion

		#region ICloneable �����o
		/// <summary>
		/// �{�N���X�̃R�s�[����
		/// </summary>
		/// <returns>���̃N���X�̃N���[��</returns>
		/// <remarks>
		/// <br>Note       : �N���X�̃N���[������</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public object Clone()
		{
			return new SlipDtlDisplayStatus(this.mColName, this.mOrder, this.mWidth, this.mVisible); ;
		}
		#endregion
	}
}
