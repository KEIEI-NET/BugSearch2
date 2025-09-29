using System;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	# region Delegate
	/// <summary>��ʔ�\���C�x���g�p�f���Q�[�g</summary>
	/// <param name="sender">�C�x���g�̃\�[�X</param>
	/// <param name="me">��ʔ�\���C�x���g�p�����[�^�N���X<see cref="MasterMaintenanceUnDisplayingEventArgs"/></param>
	public delegate void MasterMaintenanceAccDmdTypeUnDisplayingEventHandler(object sender, MasterMaintenanceUnDisplayingEventArgs me);
	# endregion

	/// **********************************************************************
	/// public class name:	MAKAU09110UE
	///						MAKAU09110U.DLL                                    
	/// <summary>
	///						�}�X�^�����e�i���X���Ӑ���яC���p�C���^�[�t�F�C�X
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks> 
	/// <br>note			:	�}�X�^�����e�i���X���Ӑ���яC���p�z��^�C�v�̃C���^�[�t�F�C�X�ł��B</br>
	/// <br>note			:	�� �}�X�^�����e����𗬗p���܂����B</br>
    /// <br>Programmer      : 30154 �����@���m</br>
    /// <br>Date            : 2007.04.18</br>
    /// </remarks>
	/// **********************************************************************
	public interface IMasterMaintenanceAccDmdType
	{
		# region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>�}�X�^�����e�i���X���Ӑ���яC���^�C�v�̉�ʔ�\���C�x���g�ł��B</remarks>
		event MasterMaintenanceAccDmdTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		bool CanPrint
		{
			get;
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		bool CanNew
		{
			get;
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		bool CanDelete
		{
			get;
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		bool CanClose
		{
			get;
			set;
		}

		/// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
		/// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
		MGridDisplayLayout DefaultGridDisplayLayout
		{
			get;
		}

		/// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
		/// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		string TargetTableName
		{
			get;
			set;
		}

		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>�I���������_�R�[�h���擾�܂��͐ݒ肵�܂��B</value>
		string SectionCodeData
		{
			get;
			set;
		}
		
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>�I���������Ӑ�R�[�h���擾�܂��͐ݒ肵�܂��B</value>
		int TargetCustomerCode
		{
			get;
			set;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>�I������������R�[�h���擾�܂��͐ݒ肵�܂��B</value>
        int TargetClaimCode
        {
            get;
            set;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>���_���\���\�ݒ�v���p�e�B</summary>
		/// <value>���_���\���\���ǂ����̐ݒ���擾���܂��B</value>
		bool Opt_SectionInfo
		{
			get;
		}
		/// <summary>�����_���_���ݒ�v���p�e�B</summary>
		/// <value>�����_���_���ݒ���擾���܂��B</value>
		string GetCompanySectionCode
		{
			get;
		}

		/// <summary>�{�Ћ@�\�t���O�v���p�e�B</summary>
		/// <value>�{�Ћ@�\�t���O���擾���܂��B</value>
		bool GetMainOfficeFuncMode
		{
			get;
		}
		# endregion

		# region Methods
		/// <summary>
		/// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetCanLogicalDeleteDataExtractionList();

		/// <summary>
		/// �O���b�h�^�C�g�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�^�C�g�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		string[] GetGridTitleList();

		/// <summary>
		/// �O���b�h�A�C�R�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�A�C�R�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		System.Drawing.Image[] GetGridIconList();

		/// <summary>
		/// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
		/// </summary>
		/// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetDefaultAutoFillToGridColumnList();

		/// <summary>
		/// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
		/// </summary>
		/// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void SetDataIndexList(int[] indexList);


		/// <summary>
		/// �V�K�{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetNewButtonEnabledList();

		/// <summary>
		/// �C���{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetModifyButtonEnabledList();

		/// <summary>
		/// �폜�{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetDeleteButtonEnabledList();

		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�f�[�^�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string[] tableName);
			
		/// <summary>
		/// ���Ӑ�f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������܂��B�܂��A�S�Y���������擾���邱�Ƃ��ł��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int CustomerData_Search(ref int totalCount, int readCount);

		/// <summary>
		/// �w�蓾�Ӑ���擾����
		/// </summary>
        /// <param name="customerRet">���Ӑ���</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�����������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int ReadCustomerData(out CustomerSearchRet customerRet, int customerCode);

		/// <summary>
		/// ���_��񌟍�����
		/// </summary>
		/// <param name="retSecInfSetList">���_���z��i�[</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���_����S�Ď擾���AArrayList�ɂČ��ʂ�Ԃ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int SecInf_Search(out ArrayList retSecInfSetList);


		/// <summary>
		/// �������z���f�[�^��������
		/// </summary>
        /// <param name="claimCode">������R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpSecCode">���_�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�E���_�̐������z���f�[�^���������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //int DmdRec_Data_Search(int customerCode,string addUpSecCode);
        int DmdRec_Data_Search ( int claimCode, int customerCode, string addUpSecCode, int TargetDivType );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// ���|���z���f�[�^��������
		/// </summary>
        /// <param name="claimCode">������R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpSecCode">���_�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�E���_�̔��|���z���f�[�^���������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //int AccRec_Data_Search(int customerCode,string addUpSecCode);
        int AccRec_Data_Search(int claimCode, int customerCode, string addUpSecCode, int TargetDivType);
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		
		/// <summary>
		/// �����ӂ̗񖼎擾����
		/// </summary>
		/// <param name="LABELList">�ӂɎg�p�����</param>
		/// <remarks>
		/// <br>Note       : �ӂɎg�p����񖼂�Ԃ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void  ReadTabelData_claim_panelSet( out string[] LABELList);

		/// <summary>
		/// Label�\���p�̋��z�J���}�ҏW
		/// </summary>
		/// <param name="val">���z</param>
		/// <param name="checkMode">�ҏW���������� true�F�������� false:�������Ȃ�</param>
		/// <returns>���z�����Ή�����</returns>
		/// <remarks>
		/// <br>Note       : Label�ɕ\��������z�̃J���}�ҏW���s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		string Claim_panelDataFormat(Int64 val , bool checkMode);
		
		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int Delete();

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int Print();

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void GetAppearanceTable(out System.Collections.Hashtable[] appearanceTable);

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void GetDisPlayDisplayLayoutTable(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid,string TABLE_NAME);
	

		# endregion
	}


}
