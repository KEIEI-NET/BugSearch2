using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Broadleaf.Application.Control;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

using ChangGidncCache = 
	System.Collections.Generic.SortedList<
		string, Broadleaf.Application.Remoting.ParamData.ChangGidncWork>;
using ChgGidncDtCacheDtl = System.Collections.Generic.SortedList<
			int, Broadleaf.Application.Remoting.ParamData.ChgGidncDtWork>;
using ChgGidncDtCache = 
	System.Collections.Generic.SortedList<
		string,	System.Collections.Generic.SortedList<
            int, Broadleaf.Application.Remoting.ParamData.ChgGidncDtWork>>;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ύX�ē�(.NS�z�M�ē�)���וҏW�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ύX�ē�(.NS�z�M�ē�)�̖��ׂ̕ҏW���s���܂��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	public partial class MulticastInfoEditor : Form, ISimpleMasterMaintenanceMulti
	{

		#region << Constructor >>

		/// <summary>
		/// �ύX�ē�(.NS�z�M�ē�)�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ύX�ē�(.NS�z�M�ē�)�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public MulticastInfoEditor()
		{
			InitializeComponent();

			// �V�K�E�폜�L��
			this._allowNew    = true;
			this._allowDelete = true;

			this._dataIndex    = 0;
			this._dataIndexBuf = -2;

			this._changGidncWorkClone     = null;
			this._chgGidncDtWorkListClone = null;

			// �f�[�^�\�[�X��������
			this._dataSet = new ChangGidncDataSet();
			// �L���b�V����������
			this._changGidncCache = new SortedList<string,ChangGidncWork>();
			this._chgGidncDtCache = new SortedList<string,SortedList<int,ChgGidncDtWork>>();

			// �ݒ�t�@�C���ǂݍ���
			this._setting = MulticastInfoEditorSetting.Load( ctSetting_FileName );
			if( this._setting == null ) {
				this._setting = new MulticastInfoEditorSetting();
			}
		}

		#endregion


		#region << Private Members >>

		/// <summary>.NS�z�M�ē��ꗗ�\���pDataSet</summary>
		private ChangGidncDataSet  _dataSet             = null;

		/// <summary>.NS�z�M�ē�DB�A�N�Z�X�N���X</summary>
		private ChangePgGuideDBAcs _changePgGuideDBAcs  = null;

		/// <summary>�ύX�ē����[�N�L���b�V��</summary>
        private ChangGidncCache _changGidncCache        = null;
		/// <summary>�ύX�ē����׃��[�N�L���b�V��</summary>
        private ChgGidncDtCache _chgGidncDtCache        = null;

		/// <summary>.NS�z�M�ē��ݒ��ʐݒ�N���X</summary>
		private MulticastInfoEditorSetting _setting     = null;

		/// <summary>.NS�z�M�ē��ݒ��ʐݒ�t�H�[��</summary>
		private MulticastInfoSettingForm   _settingForm = null;

		// INSChangeInfoEditor �p
		/// <summary>�V�K�ǉ�����</summary>
		private bool               _allowNew           = false;
		/// <summary>�폜����</summary>
		private bool               _allowDelete        = false;
		/// <summary>�N���[�Y��</summary>
		private bool               _canClose           = false;
		/// <summary>�I���f�[�^�C���f�b�N�X</summary>
		private int                _dataIndex;
		/// <summary>�I���f�[�^�C���f�b�N�X�ێ��p</summary>
		private int                _dataIndexBuf;

		/// <summary>�ҏW�O�f�[�^�ޔ�p</summary>
        private ChangGidncWork  _changGidncWorkClone            = null;
		/// <summary>�ҏW�O�f�[�^�ޔ�p</summary>
        private List<ChgGidncDtWork> _chgGidncDtWorkListClone   = null;

		/// <summary>�ύX�O�o�[�W����</summary>
		private string _beforeMulticastVersion                  = "";

		#endregion


		#region << Private Constant >>

		/// <summary>�I�v�V�����c�[���L�[ : �ݒ�</summary>
		private const string ctOptionToolKey_Setting = "Setting";

		/// <summary>�ݒ�t�@�C����</summary>
		private const string ctSetting_FileName      = "NSChangeInfoEditor_MulticastInfo.xml";

		#endregion


		#region << Private Methods >>

		#region ����ʏ���������

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏��������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void ScreenInitialize()
		{
			// �ē��敪
			this.McastGidncCntntsCd_comboBox.Items.Clear();
            //Del ������ 2008.01.28 Kouguchi
            //foreach ( int mcastGidncCntntsCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.McastGidncCntntsCd ) ) )
            //{
            //    this.McastGidncCntntsCd_comboBox.Items.Add(
            //        new ComboItem<int>( mcastGidncCntntsCd,ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm( mcastGidncCntntsCd ) ) );
            //}
            //Del ������ 2008.01.28 Kouguchi
            this.McastGidncCntntsCd_comboBox.Items.Add( new ComboItem<int>( 1, ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm(1) ) );  //Add 2008.01.28 Kouguchi


            // �z�M�񋟋敪
			this.McastOfferDivCd_comboBox.Items.Clear();
			this.McastOfferDivCd_comboBox.Items.Add( new ComboItem<int>( 0, "�W��" ) );
			this.McastOfferDivCd_comboBox.Items.Add( new ComboItem<int>( 1, "��" ) );

			// �v���O�����ύX�敪
			this.ProgramChgDivCd_comboBox.Items.Clear();
			this.ProgramChgDivCd_comboBox.Items.Add( new ComboItem<int>( 1, "�V�K" ) );
			this.ProgramChgDivCd_comboBox.Items.Add( new ComboItem<int>( 2, "����" ) );
			this.ProgramChgDivCd_comboBox.Items.Add( new ComboItem<int>( 3, "��Q" ) );

			// �z�M�V�X�e���敪(�����ԃp�b�P�[�W)  SF,BK,SH,���ʂ̏�
			this.MulticastSystemDivCd_comboBox.Items.Clear();
            // 2008.11.20 Update >>>
            //this.MulticastSystemDivCd_comboBox.Items.Add( new ComboItem<int>( 1, ConstantManagement_NS_MGD.GetMulticastSystemDivNm( ConstantManagement_NS_MGD.ProductCode.SF, 1 ) ) );
            //foreach (int multicastSystemDivCd in Enum.GetValues(typeof(ConstantManagement_NS_MGD.SystemDiv)))
            //{
            //    if ( multicastSystemDivCd > 1 ) {
            //        this.MulticastSystemDivCd_comboBox.Items.Add(
            //            new ComboItem<int>( multicastSystemDivCd,
            //            ConstantManagement_NS_MGD.GetMulticastSystemDivNm( ConstantManagement_NS_MGD.ProductCode.SF, multicastSystemDivCd ) ) );
            //    }
            //}
            //this.MulticastSystemDivCd_comboBox.Items.Add(new ComboItem<int>(0, ConstantManagement_NS_MGD.GetMulticastSystemDivNm(ConstantManagement_NS_MGD.ProductCode.SF, 0)));

            foreach (int multicastSystemDivCd in Enum.GetValues(typeof(ConstantManagement_NS_MGD.SystemDiv)))
            {
                this.MulticastSystemDivCd_comboBox.Items.Add(
                    new ComboItem<int>(multicastSystemDivCd,
                    ConstantManagement_NS_MGD.GetMulticastSystemDivNm(ConstantManagement_NS_MGD.ProductCode.PM, multicastSystemDivCd)));
            }
            // 2008.11.20 Update <<<
        }

		#endregion

		#region ���L�[������쐬����

		/// <summary>
		/// �L�[������쐬����
		/// </summary>
		/// <param name="productCode">�p�b�P�[�W�敪</param>
		/// <param name="mcastOfferDivCd">�z�M�񋟋敪</param>
		/// <param name="UpdateGroupCode">�X�V�O���[�v�R�[�h</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="multicastVersion">�z�M�o�[�W����</param>
		/// <param name="multicastConsNo">�z�M�A��</param>
		/// <returns>�L�[������</returns>
		/// <remarks>
		/// <br>Note       : �L�[������̍쐬���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.30</br>
		/// </remarks>
		private string GetChangGidncKey( int mcastGidncCntntsCd, string productCode, int mcastOfferDivCd, string UpdateGroupCode, string enterpriseCode, string multicastVersion, int multicastConsNo )
		{
            return String.Format( "{0,2:00}{1,-32}{2,2:00}{3,-32}{4,-16}{5,-32}{6,8:0000}", mcastGidncCntntsCd, productCode, mcastOfferDivCd, UpdateGroupCode, enterpriseCode, multicastVersion, multicastConsNo );
		}

		/// <summary>
		/// �L�[������쐬����
		/// </summary>
        /// <param name="changGidncWork">�ύX�ē����[�N�N���X</param>
		/// <returns>�L�[������</returns>
		/// <remarks>
		/// <br>Note       : �L�[������̍쐬���s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2008.01.16</br>
		/// </remarks>
        private string GetChangGidncKey( ChangGidncWork changGidncWork )
		{
            return this.GetChangGidncKey( changGidncWork.McastGidncCntntsCd, changGidncWork.ProductCode, changGidncWork.McastOfferDivCd, changGidncWork.UpdateGroupCode, changGidncWork.EnterpriseCode, changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo );
		}

		/// <summary>
		/// �L�[������쐬����
		/// </summary>
        /// <param name="chgGidncDtWork">�ύX�ē����׃��[�N�N���X</param>
		/// <returns>�L�[������</returns>
		/// <remarks>
		/// <br>Note       : �L�[������̍쐬���s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2008.01.16</br>
		/// </remarks>
        private string GetChangGidncKey(ChgGidncDtWork chgGidncDtWork)
		{
            return this.GetChangGidncKey( chgGidncDtWork.McastGidncCntntsCd, chgGidncDtWork.ProductCode, chgGidncDtWork.McastOfferDivCd, chgGidncDtWork.UpdateGroupCode, chgGidncDtWork.EnterpriseCode, chgGidncDtWork.McastGidncVersionCd, chgGidncDtWork.MulticastConsNo );
		}

		#endregion

		#region ���ύX�ē����[�NDataSet�i�[����

		/// <summary>
		/// �ύX�ē����[�NDataSet�i�[����
		/// </summary>
        /// <param name="changGidncWork">�ύX�ē����[�N�N���X</param>
		/// <param name="index">�i�[�C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �ύX�ē����[�N�̏���DataSet�Ɋi�[���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2008.01.16</br>
		/// </remarks>
        private void SetChangGidncWorkToDataSet( ChangGidncWork changGidncWork, int index )
		{
			if( ( index < 0 ) || ( index >= this._dataSet.ChangGidnc.Count ) ) {
				// �V�K�s��ǉ�
                ChangGidncDataSet.ChangGidncRow newRow = this._dataSet.ChangGidnc.NewChangGidncRow();
                this._dataSet.ChangGidnc.AddChangGidncRow( newRow );

				// �C���f�b�N�X���ŏI�s�ɃZ�b�g
                index = this._dataSet.ChangGidnc.Count - 1;
			}

            ChangGidncDataSet.ChangGidncRow row = this._dataSet.ChangGidnc[ index ];

            // �ē��敪
            row.McastGidncCntntsCd   = changGidncWork.McastGidncCntntsCd;
            // �ē��敪����
            row.McastGidncCntntsNm   = ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm(changGidncWork.McastGidncCntntsCd);
            // �p�b�P�[�W�敪
			row.ProductCode          = changGidncWork.ProductCode;
			// �z�M�񋟋敪
			row.McastOfferDivCd      = changGidncWork.McastOfferDivCd;
			// �z�M�񋟋敪����
			string mcastOfferDivNm = "";
			switch( changGidncWork.McastOfferDivCd ) {
				case 0:
				{
					mcastOfferDivNm = "�W��";
					break;
				}
				case 1:
				{
					mcastOfferDivNm = "��";
					break;
				}
			}
			row.McastOfferDivNm      = mcastOfferDivNm;
			// �X�V�O���[�v�R�[�h
			row.UpdateGroupCode      = changGidncWork.UpdateGroupCode;
			// ��ƃR�[�h
			row.EnterpriseCode       = changGidncWork.EnterpriseCode;
			// �z�M�o�[�W����
			row.MulticastVersion     = changGidncWork.McastGidncVersionCdZeroSup;
			// �z�M�A��
			row.MulticastConsNo      = changGidncWork.MulticastConsNo;
			// �z�M��
			row.MulticastDate        = changGidncWork.MulticastDate;
			// �z�M�V�X�e���敪
			row.MulticastSystemDivCd = changGidncWork.SystemDivCd;
			// �z�M�V�X�e���敪����
			row.MulticastSystemDivNm = ConstantManagement_NS_MGD.GetMulticastSystemDivNm( changGidncWork.ProductCode, changGidncWork.SystemDivCd );
			// �z�M�v���O��������
			row.Guidance             = changGidncWork.Guidance1;

			// �L�[���擾
			string key = this.GetChangGidncKey( changGidncWork );

			// ���j�[�N�L�[
			row.UniqueKey            = key;

			// �L���b�V�����X�V
			if( this._changGidncCache.ContainsKey( key ) ) {
                this._changGidncCache[key] = changGidncWork;
			}
			else {
                this._changGidncCache.Add(key, changGidncWork);
			}
		}

		#endregion

		#region ����ʃN���A����

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <param name="easyMode">�ȈՃ��[�h</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̃N���A���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void ScreenClear( bool easyMode )
		{

			if( ! easyMode ) {
				// �`�F�b�N�{�b�N�X�����Z�b�g
				this.MulticastVersion_checkBox.Checked      = true;
				this.MulticastConsNo_checkBox.Checked       = true;
				this.MulticastDate_checkBox.Checked         = true;
				this.SupportOpenTime_checkBox.Checked       = true;
				this.CustomerOpenTime_checkBox.Checked      = true;
				this.ProgramChgDivCd_checkBox.Checked       = false;
				this.MulticastSystemDivCd_checkBox.Checked  = false;
				this.MulticastProgramName_checkBox.Checked  = false;
			}

            //�ē��敪
            this.McastGidncCntntsCd_comboBox.SelectedIndex = 0;
            // �p�b�P�[�W�敪
			this.ProductCode_textBox.Clear();
			// �z�M�񋟋敪
			this.McastOfferDivCd_comboBox.SelectedIndex = 0;
			// �z�M�O���[�v�R�[�h
			this.UpdateGroupCode_textBox.Clear();
            // ��ƃR�[�h
			this.EnterpriseCode_textBox.Clear();
            // �z�M�o�[�W����
			this.MulticastVersion_textBox.Clear();
			// �z�M�A��
			this.MulticastConsNo_textBox.Clear();
			// �z�M��
			this.MulticastDate_maskedTextBox.Clear();
			// �T�|�[�g���J����
			this.SupportOpenTime_maskedTextBox.Clear();
			// ���[�U�[���J����
			this.CustomerOpenTime_maskedTextBox.Clear();
			// �v���O�����ύX�敪
			this.ProgramChgDivCd_comboBox.SelectedIndex = 0;
			// �z�M�V�X�e���敪
			this.MulticastSystemDivCd_comboBox.SelectedIndex = 0;
			// �z�M�v���O��������
			this.MulticastProgramName_textBox.Clear();
			// �ύX���e
			this.ChangeContents_textBox.Clear();
			// �ʎ��t�@�C������
			this.AnothersheetFileName_listView.Items.Clear();
			// �ʎ��t�@�C���R�s�[��
			this.CopyAnothersheetFile_checkBox.Checked = true;

			// �ύX�O�z�M�o�[�W����
			this._beforeMulticastVersion = "";
		}

		#endregion

		#region ���z�M�A�ԍŏI�ԍ��擾����

		/// <summary>
		/// �z�M�A�ԍŏI�ԍ��擾����
		/// </summary>
        /// <param name="mcastGidncCntntsCd">�ē��敪</param>
		/// <param name="productCode">�p�b�P�[�W�敪</param>
		/// <param name="mcastOfferDivCd">�z�M�񋟋敪</param>
		/// <param name="updateGroupCode">�X�V�O���[�v�R�[�h</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="multicastVersionZeroSup">�z�M�o�[�W����</param>
		/// <returns>�z�M�A�ԍŏI�ԍ�</returns>
		private int GetLastMulticastConsNo(int mcastGidncCntntsCd, string productCode, int mcastOfferDivCd, 
			string updateGroupCode, string enterpriseCode, string multicastVersionZeroSup )
		{
			int lastMulticastConsNo = 0;

			// �ŏI�ԍ��擾
			string expression = String.Format( "MAX( {0} )", this._dataSet.ChangGidnc.MulticastConsNoColumn.ColumnName );
			string filter     =
                String.Format( "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' AND {8} = '{9}' AND {10} = '{11}'",
                this._dataSet.ChangGidnc.McastGidncCntntsCdColumn.ColumnName, mcastGidncCntntsCd,
				this._dataSet.ChangGidnc.ProductCodeColumn.ColumnName, productCode, 
				this._dataSet.ChangGidnc.McastOfferDivCdColumn.ColumnName, mcastOfferDivCd, 
				this._dataSet.ChangGidnc.UpdateGroupCodeColumn.ColumnName, updateGroupCode, 
				this._dataSet.ChangGidnc.EnterpriseCodeColumn.ColumnName, enterpriseCode, 
				this._dataSet.ChangGidnc.MulticastVersionColumn.ColumnName, multicastVersionZeroSup );
			object multicastConsNoObj = this._dataSet.ChangGidnc.Compute( expression, filter );
			if( ( multicastConsNoObj != null ) && 
				( multicastConsNoObj != DBNull.Value ) && 
				( multicastConsNoObj is int ) ) {
				lastMulticastConsNo = ( int )multicastConsNoObj;
			}

			return lastMulticastConsNo + 1;
		}

		#endregion

		#region ����ʍč\�z����

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		private void ScreenReconstruction()
		{
			// �V�K
			if( this._dataIndex < 0 ) {
				ChangGidncWork       changGidncWork     = new ChangGidncWork();
                // 2008.11.20 Update >>>
				//changGidncWork.ProductCode              = ConstantManagement_NS_MGD.ProductCode.SF;
                changGidncWork.ProductCode = ConstantManagement_NS_MGD.ProductCode.PM;
                // 2008.11.20 Update <<<
                List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();

				// ��ʂɃf�[�^��\��
				this.SetChangGidncWorkToScreen( changGidncWork, chgGidncDtWorkList, this._dataIndex);

				// �N���[���쐬
				this._changGidncWorkClone     = changGidncWork.Clone();
				this._chgGidncDtWorkListClone = new List<ChgGidncDtWork>();
				// ��ʂ̃f�[�^���擾
				List<ChgGidncDtWork> delList  = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList );

				// ��ʓ��͐��䏈��
				this.ScreenInputPermissionControl( 0 );

                // �V�Kor�X�V���x���̕\���ؑ�
                this.Update_label.Text = "�V�K���[�h";
			}
			// �X�V
			else {
				// �L�[���擾
				string key = this._dataSet.ChangGidnc[ this._dataIndex ].UniqueKey;

				ChangGidncWork       changGidncWork     = null;
				List<ChgGidncDtWork> chgGidncDtWorkList = null;
				// �e�I�u�W�F�N�g���擾
				if( this._changGidncCache.ContainsKey( key ) ) {
					changGidncWork = this._changGidncCache[ key ];
				}
				if( this._chgGidncDtCache.ContainsKey( key ) ) {
					chgGidncDtWorkList = new List<ChgGidncDtWork>( this._chgGidncDtCache[ key ].Values );
				}

				if( changGidncWork == null ) {
					this.Close();
					return;
				}

				// ��ʂɃf�[�^��\��
                this.SetChangGidncWorkToScreen(changGidncWork, chgGidncDtWorkList, this._dataIndex);

				// �N���[���쐬
				this._changGidncWorkClone     = changGidncWork.Clone();
                if (chgGidncDtWorkList != null)
                {
                    this._chgGidncDtWorkListClone = new List<ChgGidncDtWork>(chgGidncDtWorkList);
                    for (int ix = 0; ix < this._chgGidncDtWorkListClone.Count; ix++)
                    {
                        this._chgGidncDtWorkListClone[ix] = this._chgGidncDtWorkListClone[ix].Clone();
                    }
                }
				// ��ʂ̃f�[�^���擾
				List<ChgGidncDtWork> delList  = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList );

				// ��ʓ��͐��䏈��
				this.ScreenInputPermissionControl( 2 );

                // �V�Kor�X�V���x���̕\���ؑ�
                this.Update_label.Text = "�X�V���[�h";
			}

			// �f�[�^�I���C���f�b�N�X�ޔ�
			this._dataIndexBuf = this._dataIndex;
		}

		#endregion

		#region ����ʓW�J����

		/// <summary>
		/// ��ʓW�J����
		/// </summary>
		/// <param name="changGidncWork">�v���O�����z�M�ē����[�N�N���X</param>
		/// <param name="chgGidncDtWorkList">�v���O�����z�M�ē����׃��[�N���X�g</param>
		/// <remarks>
		/// <br>Note       : �v���O�����z�M�ē��f�[�^����ʂɓW�J���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
        private void SetChangGidncWorkToScreen(ChangGidncWork changGidncWork, List<ChgGidncDtWork> chgGidncDtWorkList, int dataIndex)
		{
			if( changGidncWork == null ) {
				return;
			}

            // �ē��敪
            this.McastGidncCntntsCd_comboBox.SelectedItem   = new ComboItem<int>(changGidncWork.McastGidncCntntsCd);
            // �p�b�P�[�W�敪
			this.ProductCode_textBox.Text                   = changGidncWork.ProductCode;
			// �z�M�񋟋敪
			this.McastOfferDivCd_comboBox.SelectedItem      = new ComboItem<int>( changGidncWork.McastOfferDivCd );
			// �z�M�O���[�v�R�[�h
			this.UpdateGroupCode_textBox.Text               = changGidncWork.UpdateGroupCode;
			// ��ƃR�[�h
			this.EnterpriseCode_textBox.Text                = changGidncWork.EnterpriseCode;
			// �z�M�o�[�W����
			this.MulticastVersion_textBox.Text              = changGidncWork.McastGidncVersionCdZeroSup;
			// �z�M�A��
			this.MulticastConsNo_textBox.Text               = changGidncWork.MulticastConsNo.ToString();
			// �z�M��
			if( changGidncWork.MulticastDate == DateTime.MinValue ) {
				this.MulticastDate_maskedTextBox.Clear();
			}
			else {
				this.MulticastDate_maskedTextBox.Text       = changGidncWork.MulticastDate.ToString( this.MulticastDate_maskedTextBox.FormatProvider );
			}
			// �T�|�[�g���J����
			if( changGidncWork.SupportOpenTime == 0 ) {
				this.SupportOpenTime_maskedTextBox.Clear();
			}
			else {
				this.SupportOpenTime_maskedTextBox.Text     = changGidncWork.SupportOpenTime.ToString();
			}
			// ���[�U�[���J����
			if( changGidncWork.CustomerOpenTime == 0 ) {
				this.CustomerOpenTime_maskedTextBox.Clear();
			}
			else {
				this.CustomerOpenTime_maskedTextBox.Text    = changGidncWork.CustomerOpenTime.ToString();
			}
			// �v���O�����ύX�敪
			this.ProgramChgDivCd_comboBox.SelectedItem      = new ComboItem<int>( changGidncWork.McastGidncNewCustmCd );
            // �z�M�V�X�e���敪
            if (dataIndex < 0) {
            }
            else {
                this.MulticastSystemDivCd_comboBox.SelectedItem = new ComboItem<int>(changGidncWork.SystemDivCd); 
            }
			// �z�M�v���O��������
			this.MulticastProgramName_textBox.Text          = changGidncWork.Guidance1;

			// ���ׂ���̏ꍇ
			if( ( chgGidncDtWorkList != null ) && 
				( chgGidncDtWorkList.Count > 0 ) ) {
				StringBuilder changeContents       = new StringBuilder();

				foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) {
					// �ύX���e
					if( ! String.IsNullOrEmpty( chgGidncDtWork.ChangeContents ) ) {
						changeContents.Append( chgGidncDtWork.ChangeContents );
					}
					// �ʎ��t�@�C������
					if( ( chgGidncDtWork.AnothersheetFileExst == 1 ) && 
						( ! String.IsNullOrEmpty( chgGidncDtWork.AnothersheetFileName ) ) ) {
						// ���X�g�r���[�A�C�e���쐬
						ListViewItem newItem = new ListViewItem( new string[] { chgGidncDtWork.AnothersheetFileName, "" } );
						// �t�@�C���̑��݂��`�F�b�N���A�A�C�R�����Z�b�g
						newItem.StateImageIndex = ( this.CheckAnothersheetFileExists( chgGidncDtWork.AnothersheetFileName ) ? 0 : 1 );
						this.AnothersheetFileName_listView.Items.Add( newItem );
					}
				}
				// �ύX���e
				this.ChangeContents_textBox.Text            = changeContents.ToString();
			}
		}

		#endregion

		#region ����ʎ擾����

		/// <summary>
		/// ��ʎ擾����
		/// </summary>
		/// <param name="changGidncWork">�v���O�����z�M�ē����[�N�N���X</param>
		/// <param name="chgGidncDtWorkList">�v���O�����z�M�ē����׃��[�N���X�g</param>
		/// <param name="chgGidncDtWorkDelList">�폜�Ώۃv���O�����z�M�ē����׃��[�N���X�g</param>
		/// <remarks>
		/// <br>Note       : �v���O�����z�M�ē��f�[�^����ʂ���擾���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
        private void GetChangGidncWorkFormScreen(ref ChangGidncWork changGidncWork, ref List<ChgGidncDtWork> chgGidncDtWorkList, ref List<ChgGidncDtWork> chgGidncDtWorkDelList)
		{
			if( changGidncWork == null ) {
				changGidncWork = new ChangGidncWork();
			}

			if( chgGidncDtWorkList == null ) {
				chgGidncDtWorkList = new List<ChgGidncDtWork>();
			}

			if( chgGidncDtWorkDelList == null ) {
				chgGidncDtWorkDelList = new List<ChgGidncDtWork>();
			}

            // �ē��敪
            ComboItem<int> mcastGidncCntntsCd            = this.McastGidncCntntsCd_comboBox.SelectedItem as ComboItem<int>;
            if ( mcastGidncCntntsCd == null ) {
                changGidncWork.McastGidncCntntsCd        = 0;
            }
            else {
                changGidncWork.McastGidncCntntsCd        = mcastGidncCntntsCd.Value;
            }
            // �p�b�P�[�W�敪
			changGidncWork.ProductCode                   = this.ProductCode_textBox.Text;
			// �z�M�񋟋敪
			ComboItem<int> mcastOfferDivCd = this.McastOfferDivCd_comboBox.SelectedItem as ComboItem<int>;
			if( mcastOfferDivCd == null ) {
				changGidncWork.McastOfferDivCd           = 0;
			}
			else {
				changGidncWork.McastOfferDivCd           = mcastOfferDivCd.Value;
			}
			// �z�M�O���[�v�R�[�h
			changGidncWork.UpdateGroupCode               = this.UpdateGroupCode_textBox.Text;
			// ��ƃR�[�h
			changGidncWork.EnterpriseCode                = this.EnterpriseCode_textBox.Text;
			// �z�M�o�[�W����
			changGidncWork.McastGidncVersionCdZeroSup    = this.MulticastVersion_textBox.Text;
			// �z�M�A��
			int multicastConsNo = 0;
			if( Int32.TryParse( this.MulticastConsNo_textBox.Text, out multicastConsNo ) ) {
				changGidncWork.MulticastConsNo           = multicastConsNo;
			}
			else {
				changGidncWork.MulticastConsNo           = 0;
			}
			// �z�M��
			if( ( this.MulticastDate_maskedTextBox.MaskCompleted ) && 
				( this.MulticastDate_maskedTextBox.ValidateText() != null ) ) {
				changGidncWork.MulticastDate             = ( DateTime )this.MulticastDate_maskedTextBox.ValidateText();
			}
			else {
				changGidncWork.MulticastDate             = DateTime.MinValue;
			}
			// �T�|�[�g���J����
			if( ( this.SupportOpenTime_maskedTextBox.MaskCompleted ) && 
				( this.SupportOpenTime_maskedTextBox.ValidateText() != null ) ) {
				changGidncWork.SupportOpenTime           = this.DateTimeToLongDate( ( DateTime )this.SupportOpenTime_maskedTextBox.ValidateText() );
			}
			else {
				changGidncWork.SupportOpenTime           = 0;
			}
			// ���[�U�[���J����
			if( ( this.CustomerOpenTime_maskedTextBox.MaskCompleted ) && 
				( this.CustomerOpenTime_maskedTextBox.ValidateText() != null ) ) {
				changGidncWork.CustomerOpenTime          = this.DateTimeToLongDate( ( DateTime )this.CustomerOpenTime_maskedTextBox.ValidateText() );
			}
			else {
				changGidncWork.CustomerOpenTime          = 0;
			}
			// �v���O�����ύX�敪
            ComboItem<int> McastGidncNewCustmCd = this.ProgramChgDivCd_comboBox.SelectedItem as ComboItem<int>;
            if (McastGidncNewCustmCd == null) {
				changGidncWork.McastGidncNewCustmCd      = 0;
			}
			else {
                changGidncWork.McastGidncNewCustmCd      = McastGidncNewCustmCd.Value;
			}
			// �z�M�V�X�e���敪
            ComboItem<int> SystemDivCd                   = this.MulticastSystemDivCd_comboBox.SelectedItem as ComboItem<int>;
            if (SystemDivCd == null) {
				changGidncWork.SystemDivCd               = 0;
			}
			else {
                changGidncWork.SystemDivCd               = SystemDivCd.Value;
			}
			// �z�M�v���O��������
            changGidncWork.Guidance1                     = this.MulticastProgramName_textBox.Text;

			// �ύX���e�𕪊�
			List<string> changeContentsList = new List<string>();
			string changeContents = this.ChangeContents_textBox.Text;

			while( changeContents.Length > 0 ) {
				int maxLengh = ( changeContents.Length > 500 ? 500 : changeContents.Length );
				// �ύX���e���X�g�ɒǉ�
				changeContentsList.Add( changeContents.Substring( 0, maxLengh ) );
				// �ǉ�����������菜��
				changeContents = changeContents.Substring( maxLengh, changeContents.Length - maxLengh );
			}

			// �ʎ��t�@�C�������X�g
			List<string> anothersheetFileNameList = new List<string>();
			foreach( ListViewItem item in this.AnothersheetFileName_listView.Items ) {
				// �e�s���`�F�b�N
				if( item.SubItems[ 0 ].Text.Trim() != String.Empty ) {
					// �ʎ��t�@�C�������X�g�ɒǉ�
					anothersheetFileNameList.Add( item.SubItems[ 0 ].Text.Trim() );
				}
			}

			// ���[�v�񐔂��擾( �v���O�����z�M�ē����׃��[�N���X�g�̌����A�ύX���e���X�g�̌����A�ʎ��t�@�C�������X�g�̌����̒��ł̍ő�l )
			int loopCount = Math.Max( chgGidncDtWorkList.Count, Math.Max( changeContentsList.Count, anothersheetFileNameList.Count ) );

			for( int ix = 0; ix < loopCount; ix++ ) {
				ChgGidncDtWork chgGidncDtWork = null;
				if( ix < chgGidncDtWorkList.Count ) {
					chgGidncDtWork = chgGidncDtWorkList[ ix ];
				}
				else {
					chgGidncDtWork = new ChgGidncDtWork();
					// �L�[�l���R�s�[
					this.CopyKeyValue( changGidncWork, chgGidncDtWork );
					// �T�u�R�[�h���Z�b�g
					chgGidncDtWork.MulticastSubCode = ix + 1;

					// ���X�g�ɒǉ�
					chgGidncDtWorkList.Add( chgGidncDtWork );
				}

				// �o�^�����񂪑��݂���
				if( ( ix < changeContentsList.Count ) || 
					( ix < anothersheetFileNameList.Count ) ) {
					// �ύX���e���X�g�̌����͈͓̔�
					if( ix < changeContentsList.Count ) {
						chgGidncDtWork.ChangeContents = changeContentsList[ ix ];
					}
					else {
						chgGidncDtWork.ChangeContents = String.Empty;
					}

					// �ʎ��t�@�C�������X�g�̌����͈͓̔�
					if( ix < anothersheetFileNameList.Count ) {
						chgGidncDtWork.AnothersheetFileExst = 1;
						chgGidncDtWork.AnothersheetFileName = anothersheetFileNameList[ ix ];
					}
					else {
						chgGidncDtWork.AnothersheetFileExst = 0;
						chgGidncDtWork.AnothersheetFileName = String.Empty;
					}
				}
				// �o�^�����񂪑��݂��Ȃ�
				else {
					// �폜���X�g�ɒǉ�
					chgGidncDtWorkDelList.Add( chgGidncDtWork );
				}
			}

			// �폜���X�g�Ȃ��f�[�^���������X�g���珜�O
			foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkDelList ) {
				chgGidncDtWorkList.Remove( chgGidncDtWork );
			}
		}

		#endregion

		#region ���ʎ��t�@�C�����݃`�F�b�N����

		/// <summary>
		/// �ʎ��t�@�C�����݃`�F�b�N����
		/// </summary>
		/// <param name="anothersheetFileName">�ʎ��t�@�C����</param>
		/// <returns>�`�F�b�N����(true:���݂���, false:���݂��Ȃ�)</returns>
		private bool CheckAnothersheetFileExists( string anothersheetFileName )
		{
			bool isExists = false;

			string anothersheetFilePath = Path.Combine( this._setting.AnothersheetFileDirPath, anothersheetFileName );

			isExists = File.Exists( anothersheetFilePath );

			return isExists;
		}

		#endregion

		#region ���L�[�l�R�s�[����

		/// <summary>
		/// �L�[�l�R�s�[����(�v���O�����ύX�ē����[�N���v���O�����ύX�ē����׃��[�N)
		/// </summary>
		/// <param name="changGidncWork">�v���O�����ύX�ē����[�N�N���X</param>
		/// <param name="chgGidncDtWork">�v���O�����ύX�ē����׃��[�N�N���X</param>
		/// <br>Note       : �v���O�����z�M�ē����[�N�N���X����A�v���O�����z�M�ē����׃��[�N�N���X�փL�[���ڂ��R�s�[���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
        private void CopyKeyValue(ChangGidncWork changGidncWork, ChgGidncDtWork chgGidncDtWork)
		{
            // �ē��敪
            chgGidncDtWork.McastGidncCntntsCd   = changGidncWork.McastGidncCntntsCd;
            // �p�b�P�[�W�敪
			chgGidncDtWork.ProductCode          = changGidncWork.ProductCode;
			// �z�M�񋟋敪
			chgGidncDtWork.McastOfferDivCd      = changGidncWork.McastOfferDivCd;
			// �z�M�O���[�v�R�[�h
			chgGidncDtWork.UpdateGroupCode      = changGidncWork.UpdateGroupCode;
			// ��ƃR�[�h
			chgGidncDtWork.EnterpriseCode       = changGidncWork.EnterpriseCode;
			// �z�M�o�[�W����
			chgGidncDtWork.McastGidncVersionCd  = changGidncWork.McastGidncVersionCd;
			// �z�M�A��
			chgGidncDtWork.MulticastConsNo      = changGidncWork.MulticastConsNo;
		}

		#endregion

		#region ��DateTime��LongDate(yyyyMMddHHmm)�ϊ�����

		/// <summary>
		/// DateTime��LongDate(yyyyMMddHHmm)�ϊ�����
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>LongDate</returns>
		/// <remarks>
		/// <br>Note       : DateTime����LongDate(yyyyMMddHHmm)�֕ϊ����܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private long DateTimeToLongDate( DateTime dateTime )
		{
			return ( dateTime.Year * 100000000L + dateTime.Month * 1000000L + dateTime.Day * 10000L + dateTime.Hour * 100L + dateTime.Minute );
		}

		#endregion

		#region ����ʓ��͐��䏈��

		/// <summary>
		/// ��ʓ��͐��䏈��
		/// </summary>
		/// <param name="mode">�o�^���[�h(0:�V�K, 1:�A���V�K, 2:�X�V</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͐�����s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void ScreenInputPermissionControl( int mode )
		{
			this.McastOfferDivCd_comboBox.Enabled = ( mode < 2 );
			this.UpdateGroupCode_textBox.Enabled  = ( mode < 2 );
			this.EnterpriseCode_textBox.Enabled   = ( mode < 2 );
			this.MulticastVersion_textBox.Enabled = ( mode < 2 );
			this.MulticastConsNo_textBox.Enabled  = ( mode < 2 );

			this.MulticastVersion_checkBox.Enabled     = ( mode < 2 );
			this.MulticastConsNo_checkBox.Enabled      = ( mode < 2 );
			this.MulticastDate_checkBox.Enabled        = ( mode < 2 );
			this.SupportOpenTime_checkBox.Enabled      = ( mode < 2 );
			this.CustomerOpenTime_checkBox.Enabled     = ( mode < 2 );
			this.ProgramChgDivCd_checkBox.Enabled      = ( mode < 2 );
			this.MulticastSystemDivCd_checkBox.Enabled = ( mode < 2 );
			this.MulticastProgramName_checkBox.Enabled = ( mode < 2 );

			switch( mode ) {
				// �V�K�̏ꍇ
				case 0:
				{
                    this.UpdateGroupCode_textBox.Enabled = false;
                    this.EnterpriseCode_textBox.Enabled = false;

                    // �z�M�o�[�W�����Ƀt�H�[�J�X���Z�b�g
                    this.MulticastVersion_textBox.Focus();
					this.ActiveControl = this.MulticastVersion_textBox;
					this.MulticastVersion_textBox.SelectAll();
					break;
				}
				// �A���V�K�̏ꍇ
				case 1:
				{
                    this.UpdateGroupCode_textBox.Enabled = false;
                    this.EnterpriseCode_textBox.Enabled = false;

                    Control focusControl = null;
					if( ! this.MulticastVersion_checkBox.Checked ) {
						focusControl = this.MulticastVersion_textBox;
					}
					else if( ! this.MulticastConsNo_checkBox.Checked ) {
						focusControl = this.MulticastConsNo_textBox;
					}
					else if( ! this.MulticastDate_checkBox.Checked ) {
						focusControl = this.MulticastDate_maskedTextBox;
					}
					else if( ! this.SupportOpenTime_checkBox.Checked ) {
						focusControl = this.SupportOpenTime_maskedTextBox;
					}
					else if( ! this.CustomerOpenTime_checkBox.Checked ) {
						focusControl = this.CustomerOpenTime_maskedTextBox;
					}
					else if( ! this.ProgramChgDivCd_checkBox.Checked ) {
						focusControl = this.ProgramChgDivCd_comboBox;
					}
					else if( ! this.MulticastSystemDivCd_checkBox.Checked ) {
						focusControl = this.MulticastSystemDivCd_comboBox;
					}
					else if( ! this.MulticastProgramName_checkBox.Checked ) {
						focusControl = this.MulticastProgramName_textBox;
					}
					else {
						focusControl = this.ChangeContents_textBox;
					}
					// �t�H�[�J�X���Z�b�g
					if( focusControl != null ) {
						focusControl.Focus();
						this.ActiveControl = focusControl;
						if( focusControl is TextBox ) {
							( ( TextBox )focusControl ).SelectAll();
						}
						if( focusControl is MaskedTextBox ) {
							( ( MaskedTextBox )focusControl ).SelectAll();
						}
					}
					break;
				}
				// �X�V�̏ꍇ
				case 2:
				{
					// �z�M���Ƀt�H�[�J�X���Z�b�g
					this.MulticastDate_maskedTextBox.Focus();
					this.ActiveControl = this.MulticastDate_maskedTextBox;
					this.MulticastDate_maskedTextBox.SelectAll();
					break;
				}
			}
		}

		#endregion

		#region ���ۑ�����

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�ۑ�����</returns>
		/// <remarks>
		/// <br>Note       : �ۑ��������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
			string errMsg = "";

			// ���̓`�F�b�N
			Control control = null;
			string  message = null;
			if( ! this.ScreenDataCheck( ref control, ref message ) ) {
				MessageBox.Show( this, message, "���̓`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1 );

				if( control != null ) {
					control.Focus();
				}

				return result;
			}

			ChangGidncWork       changGidncWork        = null;
			List<ChgGidncDtWork> chgGidncDtWorkList    = null;
			if( this._dataIndex >= 0 ) {
				string key = this._dataSet.ChangGidnc[ this._dataIndex ].UniqueKey;
				changGidncWork = this._changGidncCache[ key ].Clone();
                try {
                    chgGidncDtWorkList = new List<ChgGidncDtWork>(this._chgGidncDtCache[key].Values);
                    for (int ix = 0; ix < chgGidncDtWorkList.Count; ix++)
                    {
                        chgGidncDtWorkList[ix] = chgGidncDtWorkList[ix].Clone();
                    }
                }
                catch (Exception e) {
                }
            }

			// ��ʃf�[�^�̎擾
			List<ChgGidncDtWork> chgGidncDtWorkDelList = new List<ChgGidncDtWork>();    // �폜���X�g
			this.GetChangGidncWorkFormScreen( ref changGidncWork, ref chgGidncDtWorkList, ref chgGidncDtWorkDelList );

			// �t�@�C�����R�s�[
			if( this.CopyAnothersheetFile_checkBox.Checked ) {
				string copyMessage = "";
				if( ! this.CopyNewAnothersheetFile( ref copyMessage ) ) {
					if( String.IsNullOrEmpty( copyMessage ) ) {
						copyMessage = "�t�@�C���̃R�s�[�Ɏ��s���܂����B\r\n\r\n�o�^�𑱍s���܂����H";
					}
					else {
						copyMessage = "�t�@�C���̃R�s�[�Ɏ��s���܂����B\r\n\r\n" + copyMessage + "\r\n\r\n�o�^�𑱍s���܂����H";
					}
					DialogResult res = MessageBox.Show( this, copyMessage, "�ۑ��m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					if( res == DialogResult.Yes ) {
					}
					else {
						MessageBox.Show( this, "�ۑ������𒆒f���܂����B", "���", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1 );
						return result;
					}
				}
			}

			// DB�A�N�Z�X�N���X�̃C���X�^���X���쐬
			if( this._changePgGuideDBAcs == null ) {
				this._changePgGuideDBAcs = new ChangePgGuideDBAcs();
			}

			// �ۑ����s
			int status = this._changePgGuideDBAcs.WriteChangGidnc( ref changGidncWork, ref chgGidncDtWorkList, chgGidncDtWorkDelList, out errMsg );
			switch( status ) {
				// �o�^����
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// DataSet���X�V
					this.SetChangGidncWorkToDataSet( changGidncWork, this._dataIndex );

					// �L�[���擾
					string updKey = this.GetChangGidncKey( changGidncWork );

                    ChgGidncDtCacheDtl chgGidncDtCacheDtl = null;
					// �L�[�����ɓo�^�ς�
					if( this._chgGidncDtCache.ContainsKey( updKey ) ) {
						chgGidncDtCacheDtl = this._chgGidncDtCache[ updKey ];
					}
					else {
                        chgGidncDtCacheDtl = new ChgGidncDtCacheDtl();
						this._chgGidncDtCache.Add( updKey, chgGidncDtCacheDtl );
					}
					chgGidncDtCacheDtl.Clear();

					// �v���O�����z�M�ē����׃��[�N���X�g�� Cache �Ɋi�[
					foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) {
						if( chgGidncDtCacheDtl.ContainsKey( chgGidncDtWork.MulticastSubCode ) ) {
							chgGidncDtCacheDtl[ chgGidncDtWork.MulticastSubCode ] = chgGidncDtWork;
						}
						else {
							chgGidncDtCacheDtl.Add( chgGidncDtWork.MulticastSubCode, chgGidncDtWork );
						}
					}

					result = true;
					break;
				}
				// �L�[�d��
				case ( int )ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					MessageBox.Show( this, "�R�[�h�����Ɏg�p����Ă��܂��B", "�o�^���s", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					// �z�M�A�ԂɃt�H�[�J�X���Z�b�g
					this.MulticastConsNo_textBox.Focus();
					break;
				}
				// ���[���X�V
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					MessageBox.Show( this, "���[���ɂčX�V�ς݂ł��B", "�o�^���s", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					break;
				}
				// ���[���폜
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					MessageBox.Show( this, "���[���ɂč폜�ςł��B", "�o�^���s", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					break;
				}
				// �G���[
				default:
				{
					MessageBox.Show( this, "�f�[�^�̓o�^���ɃG���[���������܂����B ST=" + status.ToString(), "�o�^���s", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );
					break;
				}
			}

			return result;
		}

		#endregion

		#region �����̓`�F�b�N

		/// <summary>
		/// ���̓`�F�b�N
		/// </summary>
		/// <param name="control">�ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N�̉�</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.30</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

			ComboItem<int> mcastOfferDivCd = this.McastOfferDivCd_comboBox.SelectedItem as ComboItem<int>;
			Regex multicastVersionRegex = new Regex( "^[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}$" );
            
            int multicastConsNo = 0;
			if( ! Int32.TryParse( this.MulticastConsNo_textBox.Text.TrimEnd(), out multicastConsNo ) ) 
            {
				multicastConsNo = 0;
			}

			
			if( mcastOfferDivCd == null )  // �ʂ̏ꍇ
            {
				message = "�z�M�񋟋敪��I�����Ă��������B";
				control = this.McastOfferDivCd_comboBox;
				result  = false;
			}
			else 
            if( ( mcastOfferDivCd.Value == 1 ) && 
				( ( this.UpdateGroupCode_textBox.Text.TrimEnd() == String.Empty ) && ( this.EnterpriseCode_textBox.Text.TrimEnd() == String.Empty ) ) ) 
            {
				message = "�z�M�񋟋敪���u�ʁv�̏ꍇ�́A�u�X�V�O���[�v�R�[�h�v���́u��ƃR�[�h�v����͂��Ă��������B";
				control = this.UpdateGroupCode_textBox;
				result  = false;
			}
			else 
            if( this.MulticastVersion_textBox.Text.TrimEnd() == String.Empty ) 
            {
				message = "�z�M�o�[�W��������͂��Ă��������B";
				control = this.MulticastVersion_textBox;
				result  = false;
			}
			else 
            if( ! multicastVersionRegex.IsMatch( this.MulticastVersion_textBox.Text.Trim() ) ) 
            {
				message = "�z�M�o�[�W�������s���ł��B";
				control = this.MulticastVersion_textBox;
				result  = false;
			}
			else 
            if( multicastConsNo == 0 ) 
            {
				message = "�z�M�A�Ԃ���͂��Ă��������B";
				control = this.MulticastConsNo_textBox;
				result  = false;
			}
			else 
            if( ( ! this.MulticastDate_maskedTextBox.MaskCompleted ) || ( this.MulticastDate_maskedTextBox.ValidateText() == null ) ) 
            {
				message = "�z�M������͂��Ă��������B";
				control = this.MulticastDate_maskedTextBox;
				result  = false;
			}

			return result;
		}

		#endregion

		#region ��CopyNewAnothersheetFile

		/// <summary>
		/// �ʎ��t�B�����ݗL���`�F�b�N&�R�s�[����
		/// </summary>
		/// <returns>����</returns>
		private bool CopyNewAnothersheetFile( ref string message )
		{
			bool result = true;

			try {
				foreach( ListViewItem item in this.AnothersheetFileName_listView.Items ) {
					string pathFrom = item.SubItems[ 1 ].Text.Trim();
					string pathTo   = Path.Combine( this._setting.AnothersheetFileDirPath, item.SubItems[ 0 ].Text.Trim() );

					if( pathFrom == String.Empty ) {
						continue;
					}

					// �R�s�[���t�@�C�������݂��Ȃ��ꍇ
					if( ! File.Exists( pathFrom ) ) {
						result = false;
						DialogResult res = MessageBox.Show( this, "�R�s�[���t�@�C��\r\n�u" + pathFrom + "�v\r\n�͑��݂��܂���B\r\n\r\n�����𑱍s���܂����H", "�t�@�C���R�s�[", 
							MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
						if( res == DialogResult.Yes ) {
							continue;
						}
						else {
							message = "�R�s�[�����f����܂����B";
							break;
						}
					}

					bool runCopy = true;

					// ���ɃR�s�[��Ƀt�@�C�������݂���ꍇ
					if( File.Exists( pathTo ) ) {
						DialogResult res = MessageBox.Show( this, 
							"�R�s�[��t�@�C��\r\n�u" + pathTo + "�v\r\n�͊��ɑ��݂��܂��B\r\n\r\n�㏑�����Ă���낵���ł����H", 
							"�m�F", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
						if( res == DialogResult.Yes ) {
						}
						else if( res == DialogResult.No ) {
							runCopy = false;
						}
						else {
							message = "�R�s�[�����f����܂����B";
							result = false;
							break;
						}
					}

					if( runCopy ) {
						// �R�s�[���s
						try {
							File.Copy( pathFrom, pathTo, true );
						}
						catch( Exception ex ) {
							result = false;
							DialogResult res = MessageBox.Show( this, 
								"�R�s�[���t�@�C��\r\n�u" + pathFrom + "�v\r\n���R�s�[���ɃG���[���������܂����B\r\n" + 
								ex.Message + "\r\n\r\n�����𑱍s���܂����H", "�t�@�C���R�s�[", 
								MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
							if( res == DialogResult.Yes ) {
								continue;
							}
							else {
								message = "�R�s�[�����f����܂����B";
								break;
							}
						}
					}
				}
			}
			catch( Exception ex ) {
				MessageBox.Show( this, ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
				message = "�R�s�[���ɃG���[���������܂����B";
				result = false;
			}

			return result;
		}

		#endregion

		#endregion


		#region << INSChangeInfoEditor �����o >>

		#region ���I���f�[�^�C���f�b�N�X�v���p�e�B

		/// <summary>
		/// �I���f�[�^�C���f�b�N�X�v���p�e�B
		/// </summary>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		#endregion

		#region ���V�K�ǉ����v���p�e�B

		/// <summary>
		/// �V�K�ǉ����v���p�e�B
		/// </summary>
		public bool AllowNew
		{
			get {
				return this._allowNew;
			}
		}

		#endregion

		#region ���폜���v���p�e�B

		/// <summary>
		/// �폜���v���p�e�B
		/// </summary>
		public bool AllowDelete
		{
			get {
				return this._allowDelete;
			}
		}

		#endregion

		#region ���N���[�Y�ۃv���p�e�B

		/// <summary>
		/// �N���[�Y�ۃv���p�e�B
		/// </summary>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		#endregion

		#region ���f�[�^�Z�b�g�擾����

		/// <summary>
		/// �f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="dataSet">�f�[�^�Z�b�g</param>
		/// <param name="dataMember">�f�[�^�����o�[</param>
		public void GetDataSet( ref DataSet dataSet, ref string dataMember )
		{
			dataSet    = this._dataSet;
			dataMember = this._dataSet.ChangGidnc.TableName;
		}

		#endregion

		#region ���I�v�V�����c�[���擾����

		/// <summary>
		/// �I�v�V�����c�[���擾����
		/// </summary>
		/// <param name="optionTools">�I�v�V�����c�[��</param>
		public void GetOptionTools( ref SortedList<string,ToolStripItem> optionTools )
		{
			optionTools = new SortedList<string,ToolStripItem>();

			ToolStripMenuItem settingMenuItem = new ToolStripMenuItem( "�ݒ�(&S)" );
			optionTools.Add( ctOptionToolKey_Setting, settingMenuItem );
		}

		#endregion

		#region ���O���b�h��O�ϐݒ�擾����

		/// <summary>
		/// �O���b�h��O�ϐݒ�擾����
		/// </summary>
		/// <returns>�O���b�h��O�ϐݒ�f�B�N�V���i���[</returns>
		public Dictionary<string,GridColAppearance> GetGridColAppearance()
		{
			Dictionary<string,GridColAppearance> gridColAppearanceDictionary = new Dictionary<string,GridColAppearance>();

			int displayIndex = 0;
            gridColAppearanceDictionary.Add("McastGidncCntntsNm",
                new GridColAppearance( displayIndex++, "�ē��敪", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black));
            gridColAppearanceDictionary.Add("ProductCode", 
				new GridColAppearance( displayIndex++, "�p�b�P�[�W�敪", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "MulticastVersion", 
				new GridColAppearance( displayIndex++, "�z�M�o�[�W����", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "MulticastConsNo", 
				new GridColAppearance( displayIndex++, "�z�M�A��", DataGridViewContentAlignment.MiddleRight, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "MulticastDate", 
				new GridColAppearance( displayIndex++, "�z�M��", DataGridViewContentAlignment.MiddleLeft, "yyyy�NMM��dd��", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "MulticastSystemDivNm", 
				new GridColAppearance( displayIndex++, "�z�M�V�X�e���敪", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "MulticastProgramName", 
				new GridColAppearance( displayIndex++, "�z�M�v���O��������", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "McastOfferDivNm", 
				new GridColAppearance( displayIndex++, "�z�M�񋟋敪", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "UpdateGroupCode", 
				new GridColAppearance( displayIndex++, "�X�V�O���[�v�R�[�h", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );
			gridColAppearanceDictionary.Add( "EnterpriseCode", 
				new GridColAppearance( displayIndex++, "��ƃR�[�h", DataGridViewContentAlignment.MiddleLeft, "", Color.Black, Color.Black ) );

			return gridColAppearanceDictionary;
		}

		#endregion

		#region ����������

		/// <summary>
		/// ��������
		/// </summary>
		/// <returns>STATUS</returns>
		public int Search()
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

			try {
				if( this._changePgGuideDBAcs == null ) {
					this._changePgGuideDBAcs = new ChangePgGuideDBAcs();
				}

				// �e�[�u���E�L���b�V�����N���A
				this._dataSet.ChangGidnc.Clear();
				this._changGidncCache.Clear();
				this._chgGidncDtCache.Clear();

				List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();    // �v���O�����z�M�ē����[�N���X�g
				List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();    // �v���O�����z�M�ē����׃��[�N���X�g
				int                  totalCount         = 0;                             // ������
				string               errMsg             = "";                            // �G���[���b�Z�[�W

				// �����p�����[�^����
                ChangGidncParaWork changGidncParaWork   = new ChangGidncParaWork();
                changGidncParaWork.McastGidncCntntsCd   = 1;     // �ē��敪�敪(�v���O�����z�M)
                // 2008.11.20 Update >>>
				//changGidncParaWork.ProductCode          = ConstantManagement_NS_MGD.ProductCode.SF;
                changGidncParaWork.ProductCode = ConstantManagement_NS_MGD.ProductCode.PM;
                // 2008.11.20 Update <<<
                // �����ԃp�b�P�[�W
				changGidncParaWork.McastOfferDivCd      = -2;    // �z�M�񋟋敪�E�X�V�O���[�v�R�[�h�E��ƃR�[�h�𖳎����邽�߂Ɏw��
				changGidncParaWork.MulticastSystemDivCd = -1;    // �S�V�X�e���敪

				// DB�������s
				status = this._changePgGuideDBAcs.ChangGidnc( changGidncParaWork, out changGidncWorkList, out chgGidncDtWorkList, 0, Int32.MaxValue, out totalCount, out errMsg );
				switch( status ) {
					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �v���O�����z�M�ē����[�N���X�g��DataSet�ɓW�J���ACache �Ɋi�[
						foreach( ChangGidncWork changGidncWork in changGidncWorkList ) {
							this.SetChangGidncWorkToDataSet( changGidncWork, -1 );
						}

						// �v���O�����z�M�ē����׃��[�N���X�g�� Cache �Ɋi�[
						foreach( ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList ) {
							// �L�[���擾
							string key = this.GetChangGidncKey( chgGidncDtWork );

							ChgGidncDtCacheDtl chgGidncDtCacheDtl = null;
							// �L�[�����ɓo�^�ς�
							if( this._chgGidncDtCache.ContainsKey( key ) ) {
								chgGidncDtCacheDtl = this._chgGidncDtCache[ key ];
							}
							else {
                                chgGidncDtCacheDtl = new ChgGidncDtCacheDtl();
								this._chgGidncDtCache.Add( key, chgGidncDtCacheDtl );
							}

							if( ! chgGidncDtCacheDtl.ContainsKey( chgGidncDtWork.MulticastSubCode ) ) {
								chgGidncDtCacheDtl.Add( chgGidncDtWork.MulticastSubCode, chgGidncDtWork );
							}
						}
						break;
					}
					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						break;
					}
					default:
					{
						// TODO : �G���[�\��
						MessageBox.Show( this, errMsg, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
						break;
					}
				}
			}
			catch( Exception ex ) {
				// TODO : �G���[���b�Z�[�W�\��
				MessageBox.Show( this, ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
			}

			return status;
		}

		#endregion

		#region ���폜����

		/// <summary>
		/// �폜����
		/// </summary>
		/// <returns>STATUS</returns>
		public int Delete()
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;

			if( this._dataIndex < 0 ) {
				return status;
			}

			ChangGidncWork changGidncWork = null;
			// �L�[���擾
			string key = this._dataSet.ChangGidnc[ this._dataIndex ].UniqueKey;
			// �I������Ă���I�u�W�F�N�g���擾
			if( this._changGidncCache.ContainsKey( key ) ) {
				changGidncWork = this._changGidncCache[ key ];
			}

			if( changGidncWork == null ) {
				return status;
			}

			string errMsg = "";

			// �폜���s
			status = this._changePgGuideDBAcs.DeleteChangGidnc( changGidncWork, out errMsg );
			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				// �L���b�V������폜
				this._changGidncCache.Remove( key );
				this._chgGidncDtCache.Remove( key );
				// DataTable ����폜
				this._dataSet.ChangGidnc[ this._dataIndex ].Delete();
			}
			else {
				MessageBox.Show( this, errMsg, "�폜���s", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
			}

			return status;
		}

		#endregion

		#region ���I�v�V�����c�[���R�}���h����

		/// <summary>
		/// �I�v�V�����c�[���R�}���h����
		/// </summary>
		/// <param name="key">�R�}���h�L�[</param>
		/// <param name="owner">System.Forms.IWin32Window ���������A���̃t�H�[�������L����g�b�v���x�� �E�B���h�E��\���I�u�W�F�N�g�B</param>
		public void OptionToolCommand( string key, IWin32Window owner )
		{
			if( this._settingForm == null ) {
				this._settingForm = new MulticastInfoSettingForm();
			}

			// �p�����[�^�Z�b�g
			this._settingForm.Setting = this._setting.Clone();
			// �ݒ��ʋN��
			DialogResult result = this._settingForm.ShowDialog( owner );
			if( result == DialogResult.OK ) {
				this._setting = this._settingForm.Setting;
				// �ۑ�
				MulticastInfoEditorSetting.Save( ctSetting_FileName, this._setting );
			}
		}

		#endregion

		#endregion


		#region << Public Methods >>

		#endregion


		#region << Control Eventts >>

		#region ��Load �C�x���g (MulticastInfoEditor)

		/// <summary>
		/// Load �C�x���g (MulticastInfoEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������߂ĕ\�������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MulticastInfoEditor_Load( object sender, EventArgs e )
		{
			// ��ʏ�����
			this.ScreenInitialize();
		}

		#endregion

		#region ��FormClosing �C�x���g (MulticastInfoEditor)

		/// <summary>
		/// FormClosing �C�x���g (MulticastInfoEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[��������O�ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MulticastInfoEditor_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( ( e.CloseReason == CloseReason.UserClosing ) && 
				( ! this._canClose ) ) {
				e.Cancel = true;
				this.Hide();
			}

			this._dataIndexBuf = -2;
		}

		#endregion

		#region ��VisibleChanged �C�x���g (MulticastInfoEditor)

		/// <summary>
		/// VisibleChanged �C�x���g (MulticastInfoEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : Visible �v���p�e�B�̒l���ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MulticastInfoEditor_VisibleChanged( object sender, EventArgs e )
		{
			if( this.Visible == false ) {
				return;
			}

			if( this._dataIndex == this._dataIndexBuf ) {
				return;
			}

			// ��ʂ��N���A
			this.ScreenClear( false );

			// ��ʕ\��
			this.Initial_timer.Enabled = true;
		}

		#endregion

		#region ��Tick �C�x���g (Initial_timer)

		/// <summary>
		/// Tick �C�x���g (Initial_timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �w�肵���^�C�}�̊Ԋu���o�߂��A�^�C�}���L���ł���ꍇ�ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Initial_timer_Tick( object sender, EventArgs e )
		{
			this.Initial_timer.Enabled = false;

			this.ScreenReconstruction();
		}

		#endregion

		#region ��Click �C�x���g (Save_toolStripButton)

		/// <summary>
		/// Click �C�x���g (Save_toolStripButton)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Save_toolStripButton_Click( object sender, EventArgs e )
		{
			if( ! this.SaveProc() ) {
				return;
			}

			// �V�K�̏ꍇ�͘A�����͂��\�ɂ���
			if( this._dataIndex < 0 ) {
				// �\���f�[�^���擾
				ChangGidncWork       wkChangGidncWork     = new ChangGidncWork();
				List<ChgGidncDtWork> wkChgGidncDtWorkList = new List<ChgGidncDtWork>();
				List<ChgGidncDtWork> wkDelList              = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref wkChangGidncWork, ref wkChgGidncDtWorkList, ref wkDelList );

				// ��ʂ��N���A
				this.ScreenClear( true );

				// �A�����͗p�ɒl���Z�b�g
				ChangGidncWork       changGidncWork     = new ChangGidncWork();
                changGidncWork.McastGidncCntntsCd       = 1;  //wkChangGidncWork.McastGidncCntntsCd;  //2008.01.28 Kouguchi
				changGidncWork.ProductCode              = wkChangGidncWork.ProductCode;
				changGidncWork.McastOfferDivCd          = wkChangGidncWork.McastOfferDivCd;
				changGidncWork.UpdateGroupCode          = wkChangGidncWork.UpdateGroupCode;
				changGidncWork.EnterpriseCode           = wkChangGidncWork.EnterpriseCode;
				// �z�M�o�[�W����
				if( this.MulticastVersion_checkBox.Checked ) {
                    changGidncWork.McastGidncVersionCd  = wkChangGidncWork.McastGidncVersionCd;
				}
				// �z�M�A��
				if( ( this.MulticastVersion_checkBox.Checked ) && 
					( this.MulticastConsNo_checkBox.Checked ) ) {
					changGidncWork.MulticastConsNo          = this.GetLastMulticastConsNo(
                        wkChangGidncWork.McastGidncCntntsCd, wkChangGidncWork.ProductCode, wkChangGidncWork.McastOfferDivCd, 
                        wkChangGidncWork.UpdateGroupCode, wkChangGidncWork.EnterpriseCode, wkChangGidncWork.McastGidncVersionCdZeroSup );
				}
				else {
				}
				// �z�M��
				if( this.MulticastDate_checkBox.Checked ) {
					this.MulticastDate_maskedTextBox.Clear();
					changGidncWork.MulticastDate            = wkChangGidncWork.MulticastDate;
				}
				// �T�|�[�g���J����
				if( this.SupportOpenTime_checkBox.Checked ) {
					this.SupportOpenTime_maskedTextBox.Clear();
					changGidncWork.SupportOpenTime          = wkChangGidncWork.SupportOpenTime;
				}
				// ���[�U�[���J����
				if( this.CustomerOpenTime_checkBox.Checked ) {
					this.CustomerOpenTime_maskedTextBox.Clear();
					changGidncWork.CustomerOpenTime         = wkChangGidncWork.CustomerOpenTime;
				}
				// �v���O�����ύX�敪
				if( this.ProgramChgDivCd_checkBox.Checked ) {
					this.ProgramChgDivCd_comboBox.SelectedIndex = 0;
                    changGidncWork.McastGidncNewCustmCd     = wkChangGidncWork.McastGidncNewCustmCd;
				}
				// �z�M�V�X�e���敪
				if( this.MulticastSystemDivCd_checkBox.Checked ) {
					this.MulticastSystemDivCd_comboBox.SelectedIndex = 0;
					changGidncWork.SystemDivCd              = wkChangGidncWork.SystemDivCd;
				}
				// �z�M�v���O��������
				if( this.MulticastProgramName_checkBox.Checked ) {
					this.MulticastProgramName_textBox.Clear();
                    changGidncWork.Guidance1                = wkChangGidncWork.Guidance1;
				}
				List<ChgGidncDtWork> chgGidncDtWorkList     = new List<ChgGidncDtWork>();

				// ��ʂɃf�[�^��\��
                this.SetChangGidncWorkToScreen(changGidncWork, chgGidncDtWorkList, this._dataIndex);

				// �N���[���쐬
				this._changGidncWorkClone     = changGidncWork.Clone();
				this._chgGidncDtWorkListClone = new List<ChgGidncDtWork>();
				// ��ʂ̃f�[�^���擾
				List<ChgGidncDtWork> delList  = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref this._changGidncWorkClone, ref this._chgGidncDtWorkListClone, ref delList );

				// ��ʓ��͐��䏈��
				this.ScreenInputPermissionControl( 1 );

				this._dataIndex = this._dataIndexBuf = -1;
			}
			// �X�V�̏ꍇ�͕���
			else {
				// �ۑ��ɐ��������̂ŕ���
				this.DialogResult = DialogResult.OK;

				this.Close();
			}
		}

		#endregion

		#region ��Click �C�x���g (Cancel_toolStripButton)

		/// <summary>
		/// Click �C�x���g (Cancel_toolStripButton)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Cancel_toolStripButton_Click( object sender, EventArgs e )
		{
			// ���̓f�[�^���擾
			ChangGidncWork       changGidncWorkChanged     = this._changGidncWorkClone.Clone();
			List<ChgGidncDtWork> chgGidncDtWorkListChanged = new List<ChgGidncDtWork>( this._chgGidncDtWorkListClone );
			for( int ix = 0; ix < chgGidncDtWorkListChanged.Count; ix++ ) {
				chgGidncDtWorkListChanged[ ix ] = chgGidncDtWorkListChanged[ ix ].Clone();
			}

			List<ChgGidncDtWork> delList = new List<ChgGidncDtWork>();
			this.GetChangGidncWorkFormScreen( ref changGidncWorkChanged, ref chgGidncDtWorkListChanged, ref delList );

			bool isChanged = false;

			// �ύX�`�F�b�N
			if( ! changGidncWorkChanged.Equals( this._changGidncWorkClone ) ) {
				isChanged = true;
			}
			else if( chgGidncDtWorkListChanged.Count != this._chgGidncDtWorkListClone.Count ) {
				isChanged = true;
			}
			else if( delList.Count > 0 ) {
				isChanged = true;
			}
			else {
				for( int ix = 0; ix < chgGidncDtWorkListChanged.Count; ix++ ) {
					if( ! chgGidncDtWorkListChanged[ ix ].Equals( this._chgGidncDtWorkListClone[ ix ] ) ) {
						isChanged = true;
						break;
					}
				}
			}

			// �ύX���������ꍇ
			if( isChanged ) {
				DialogResult result = MessageBox.Show( this, "���e���ύX����܂����B\r\n�ۑ����܂����H", "�m�F", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
				switch( result ) {
					case DialogResult.Yes:
					{
						if( ! this.SaveProc() ) {
							return;
						}
						break;
					}
					case DialogResult.No:
					{
						break;
					}
					case DialogResult.Cancel:
					{
						return;
					}
				}
			}
			this.DialogResult = DialogResult.Cancel;

			this.Close();
		}

		#endregion

		#region ��Click �C�x���g (CreateGuid_button)

		/// <summary>
		/// Click �C�x���g (CreateGuid_button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void CreateGuid_button_Click( object sender, EventArgs e )
		{
			if( this.AnothersheetFileName_listView.SelectedItems.Count < 1 ) {
				return;
			}
			ListViewItem item = this.AnothersheetFileName_listView.SelectedItems[ 0 ];

			item.SubItems[ 0 ].Text = "Announce_" + Guid.NewGuid().ToString( "N" ) + ".pdf";
		}

		#endregion

		#region ��Click �C�x���g (AddAnothersheetFileName_button)

		/// <summary>
		/// Click �C�x���g (AddAnothersheetFileName_button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void AddAnothersheetFileName_button_Click( object sender, EventArgs e )
		{
			// �t�@�C�����J��
			DialogResult result = this.Anothersheet_openFileDialog.ShowDialog( this );
			if( result == DialogResult.OK ) {
				string anothersheetFileName = "Announce_" + Guid.NewGuid().ToString( "N" ) + ".pdf";
				ListViewItem newItem = new ListViewItem( new string[] { anothersheetFileName, this.Anothersheet_openFileDialog.FileName } );
				newItem.StateImageIndex = 2;    // �ǉ��A�C�R��
				this.AnothersheetFileName_listView.Items.Add( newItem );
			}
		}

		#endregion

		#region ��Click �C�x���g (DelAnothersheetFileName_button)

		/// <summary>
		/// Click �C�x���g (DelAnothersheetFileName_button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void DelAnothersheetFileName_button_Click( object sender, EventArgs e )
		{
			if( this.AnothersheetFileName_listView.SelectedIndices.Count < 1 ) {
				return;
			}
            // �폜�m�F
            DialogResult result = MessageBox.Show(
                this, "�I������Ă���ʎ��t�@�C�����폜���܂��B��낵���ł����H", "�m�F",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result != DialogResult.Yes)
            {
                // �폜���Ȃ�
                return;
            }
            int index = this.AnothersheetFileName_listView.SelectedIndices[0];

			this.AnothersheetFileName_listView.Items.RemoveAt( index );
		}

		#endregion

		#region ��AfterLabelEdit �C�x���g (AnothersheetFileName_listView)

		/// <summary>
		/// AfterLabelEdit �C�x���g (AnothersheetFileName_listView)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���ڂ̃��x�������[�U�[�ɂ���ĕҏW�����Ɣ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void AnothersheetFileName_listView_AfterLabelEdit( object sender, LabelEditEventArgs e )
		{
			if( e.Label == null ) {
				return;
			}
			// ��̏ꍇ�̓L�����Z��
			if( e.Label.Trim() == String.Empty ) {
				e.CancelEdit = true;
			}
		}

		#endregion 

		#region ��BeforeLabelEdit �C�x���g (AnothersheetFileName_listView)

		/// <summary>
		/// BeforeLabelEdit �C�x���g (AnothersheetFileName_listView)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�����ڂ̃��x���̕ҏW���J�n����Ɣ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void AnothersheetFileName_listView_BeforeLabelEdit( object sender, LabelEditEventArgs e )
		{
		}

		#endregion

        #region ��Enter �C�x���g (MulticastVersion_textBox_Enter)

        /// <summary>
		/// Enter �C�x���g (MulticastVersion_textBox)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.06.21</br>
		/// </remarks>
		private void MulticastVersion_textBox_Enter( object sender, EventArgs e )
		{
			this._beforeMulticastVersion = this.MulticastVersion_textBox.Text.Trim();
		}

		#endregion

        #region ��Leave �C�x���g (MulticastVersion_textBox)

        /// <summary>
		/// Leave �C�x���g (MulticastVersion_textBox)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.06.21</br>
		/// </remarks>
		private void MulticastVersion_textBox_Leave( object sender, EventArgs e )
		{
			if( this.MulticastVersion_textBox.Text.Trim() == this._beforeMulticastVersion ) {
				return;
			}
			Regex multicastVersionRegex = new Regex( "^[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}$" );
			if( multicastVersionRegex.IsMatch( this.MulticastVersion_textBox.Text.Trim() ) ) {
				ChangGidncWork       changGidncWork        = new ChangGidncWork();
				List<ChgGidncDtWork> chgGidncDtWorkList    = new List<ChgGidncDtWork>();
				List<ChgGidncDtWork> chgGidncDtWorkDelList = new List<ChgGidncDtWork>();
				this.GetChangGidncWorkFormScreen( ref changGidncWork, ref chgGidncDtWorkList, ref chgGidncDtWorkDelList );

				this.MulticastConsNo_textBox.Text = this.GetLastMulticastConsNo(
                    changGidncWork.McastGidncCntntsCd, changGidncWork.ProductCode, changGidncWork.McastOfferDivCd, 
					changGidncWork.UpdateGroupCode, changGidncWork.EnterpriseCode, changGidncWork.McastGidncVersionCdZeroSup ).ToString();
			}
		}

		#endregion

        #region ��SelectedIndexChanged �C�x���g (McastOfferDivCd_comboBox)

        /// <summary>
        /// SelectedIndexChanged �C�x���g (McastOfferDivCd_comboBox)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void McastOfferDivCd_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._dataIndex < 0)
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    this.UpdateGroupCode_textBox.Enabled    = false;
                    this.EnterpriseCode_textBox.Enabled     = false;
                }
                else
                {
                    this.UpdateGroupCode_textBox.Enabled    = true;
                    this.EnterpriseCode_textBox.Enabled     = true;
                }
            }
        }
        #endregion

        #endregion

    }
}