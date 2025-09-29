using System;

namespace Broadleaf.Application.Common
{
	#region ���@���[�Ɩ�(�������̓^�C�v)���ʃC���^�[�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)���ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�Ɩ�(�������̓^�C�v)�̋��ʃC���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.16</br>
	/// <br>Update Note: 2006.09.01 Y.Sasaki</br>
	/// <br>           : �P.�e�L�X�g�o�̓C���^�t�F�[�X�̒ǉ�</br>
	/// </remarks>
	public interface IPrintConditionInpType
	{
		#region evrnt
		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.16</br>
		/// </remarks>
		event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion
        
		#region property
		/// <summary>����{�^���L�������ݒ�v���p�e�B</summary>
		/// <value>[True:�L��,False:����]</value>
		/// <remarks>����������邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool CanPrint{get;}
        
		/// <summary>���o�{�^���L�������ݒ�v���p�e�B</summary>
		/// <value>[True:�L��,False:����]</value>
		/// <remarks>���o�������邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool CanExtract{get;}

		/// <summary>PDF�{�^���L�������ݒ�v���p�e�B</summary>
		/// <value>[True:�L��,False:����]</value>
		/// <remarks>PDF�{�^���������邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool CanPdf{get;}
        
		/// <summary>����{�^���\���ݒ�v���p�e�B</summary>
		/// <value>[True:�\��,False:��\��]</value>
		/// <remarks>����{�^����\�����邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool VisibledPrintButton{get;}
        
		/// <summary>���o�{�^���\���ݒ�v���p�e�B</summary>
		/// <value>[True:�\��,False:��\��]</value>
		/// <remarks>���o�{�^����\�����邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool VisibledExtractButton{get;}
		
		/// <summary>PDF�o�̓{�^���\���ݒ�v���p�e�B</summary>
		/// <value>[True:�\��,False:��\��]</value>
		/// <remarks>PDF�o�̓{�^����\�����邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool VisibledPdfButton{get;}
		#endregion
        
		#region methods		
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : object�^�̈������󂯎��A�R���g���[�������[�U�[�ɑ΂��ĕ\�����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.16</br>
		/// </remarks>
		void Show(object parameter);
    
		/// <summary>
		/// ����O���̓`�F�b�N
		/// </summary>
		/// <param></param>
		/// <returns>[True:OK,False:NG]</returns>
		/// <remarks>
		/// <br>Note       : ����O�̉�ʏ����̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.16</br>
		/// </remarks>
		bool PrintBeforeCheck();
    
		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">������p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.16</br>
		/// </remarks>
		int Print(ref object parameter);
		
		/// <summary>
		/// ���o����
		/// </summary>
		/// <param name="parameter">������p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���o�������s���܂��B
		///                : ���o���������݂���ꍇ�ȂǂɎ������ĉ������B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.16</br>
		/// </remarks>
		int Extract(ref object parameter);
		#endregion
	}
	#endregion
	
	#region ���@���[�Ɩ�(�������̓^�C�v)���_�I���C���^�[�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)���_�I���C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_�I��������ꍇ�̋��ʃC���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br>Update Note: 2006.03.22 Y.Sasaki</br>
	/// <br>           : �P.���_OP�L���v���p�e�B�ǉ�</br>
	/// <br>           : �Q.�{�Ћ@�\�L���v���p�e�B�ǉ� </br>
	/// </remarks>
	public interface IPrintConditionInpTypeSelectedSection
	{
		#region property
		/// <summary>�v�㋒�_�I��\���ݒ�v���p�e�B</summary>
		/// <value>[True:�\��,False:��\��]</value>
		/// <remarks>�v�㋒�_��I�����邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool VisibledSelectAddUpCd{get;}
		
		/// <summary>���_�I�v�V�����v���p�e�B</summary>
		/// <value>[True:���_OP�L,False:���_OP��]</value>
		/// <remarks>���_�I�v�V�����L����ݒ肵�܂��B</remarks>
		bool IsOptSection{get; set;}
		
		/// <summary>�{�Ћ@�\�v���p�e�B</summary>
		/// <value>[True:�{�Ћ@�\,False:���_�@�\]</value>
		/// <remarks>�{�Ћ@�\��ݒ肵�܂��B</remarks>
		bool IsMainOfficeFunc{get; set;}

//		/// <summary>�u�S�Ёv�\���v���p�e�B</summary>
//		/// <value>[True:�\��,False:��\��]</value>
//		/// <remarks>���_���X�g���Ɂu�S�Ёv��\���E��\�����擾���܂��B</remarks>
//		bool IsSectionALL{get;}
		#endregion

		#region methods		
		/// <summary>
		/// �������_�I��\���`�F�b�N����
		/// </summary>
		/// <param name="isDefaultState">�f�t�H���g�\�����</param>
		/// <returns>[True:�\��,False:��\��]</returns>
		/// <remarks>
		/// <br>Note       : ���_�I���X���C�_�[�̕\���L���𔻒肵�܂��B</br>
		///                : ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���܂��B
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		bool InitVisibleCheckSection(bool isDefaultState);
		
		/// <summary>
		/// �����I���v�㋒�_�ݒ菈��
		/// </summary>
		/// <param name="addUpCd">�v�㋒�_[1:���� 2:����]</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �����I������ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.19</br>
		/// </remarks>
		void InitSelectAddUpCd(int addUpCd);

		/// <summary>
		/// �������_�ݒ菈��
		/// </summary>
		/// <param name="sectionCodeLst">�I�����_���X�g</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �����I������ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.19</br>
		/// </remarks>
		void InitSelectSection(string[] sectionCodeLst);
		
		/// <summary>
		/// �v�㋒�_�I������
		/// </summary>
		/// <param name="addUpCd">�v�㋒�_[1:���� 2:����]</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �v�㋒�_�̑I����ԕύX���ɏ������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		void SelectedAddUpCd(int addUpCd);
		
		/// <summary>
		/// ���_�I������
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="checkState">�I�����</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ���_���̑I����ԕύX���ɏ������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		void CheckedSection(string sectionCode, System.Windows.Forms.CheckState checkState);
		#endregion
	}
	#endregion

	#region ���@���[�Ɩ�(�������̓^�C�v)�J�X�^�����_��ޑI���C���^�[�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)�J�X�^�����_��ޑI���C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���䋒�_�ɕ\���������e���J�X�^�}�C�Y�������ꍇ�̃C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.28</br>
	/// </remarks>
	public interface IPrintConditionInpTypeCustomSelectSectionKind
	{
		#region property
		/// <summary>�^�C�g���v���p�e�B</summary>
		/// <remarks>�\������^�C�g�����擾���܂��B</remarks>
		string Title{get;}
		
		
		/// <summary>���䋒�_��ރ��X�g</summary>
		/// <value>���_��ރN���X���X�g</value>
		SectionKind[] CustomSectionKindList{get;}
		#endregion
	}
	
	#region ���@���_��ރN���X
	/// <summary>
	/// ���_��ރN���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_��ނ̃N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.28</br>
	/// </remarks>
	public class SectionKind
	{
		#region Private Members
		private int _ctrlFuncCode;
		private string _ctrlFuncName = "";
		#endregion
	
		#region Constructor
		/// <summary>
		/// ���_��ރN���X�R���X�g���N�^
		/// </summary>
		public SectionKind()
		{
		}
		
		/// <summary>
		/// ���_��ރN���X�R���X�g���N�^
		/// </summary>
		/// <param name="CtrlFuncCode">����@�\�R�[�h</param>
		/// <param name="CtrlFuncName">���䋒�_�R�[�h</param>
		/// <remarks>
		/// <br>Note       : ���_��ނ̃N���X�ł��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.28</br>
		/// </remarks>
		public SectionKind(int ctrlFuncCode, string ctrlFuncName)
		{
			this._ctrlFuncCode = ctrlFuncCode;
			this._ctrlFuncName = ctrlFuncName;
		}
		#endregion
	
		#region Propertys
		/// <summary>����@�\�R�[�h</summary>
		public int CtrlFuncCode
		{
			get{ return this._ctrlFuncCode; }
			set{ this._ctrlFuncCode = value;}
		}
	
		/// <summary>����@�\����</summary>
		public string CtrlFuncName
		{
			get{ return this._ctrlFuncName; }
			set{ this._ctrlFuncName = value;}
		}
		#endregion
	}
	#endregion
	
	#endregion

	#region ���@���[�Ɩ�(�������̓^�C�v)�V�X�e���I���C���^�[�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)�V�X�e���I���C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �V�X�e���I��������ꍇ�̋��ʃC���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeSelectedSystem
	{
		#region property
//		/// <summary>�u�S�V�X�e���v�\���v���p�e�B</summary>
//		/// <value>[True:�\��,False:��\��]</value>
//		/// <remarks>�V�X�e�����X�g���Ɂu�S�V�X�e���v��\���E��\�����擾���܂��B</remarks>
//		bool IsSystemALL{get;}
		#endregion
		
		#region methods		
		/// <summary>
		/// �����V�X�e���I��\���`�F�b�N����
		/// </summary>
		/// <param name="isDefaultState">�f�t�H���g�\�����</param>
		/// <returns>[True:�\��,False:��\��]</returns>
		/// <remarks>
		/// <br>Note       : �V�X�e���I���X���C�_�[�̕\���L���𔻒肵�܂��B</br>
		///                : �����V�X�e���ȊO�̌ʂ̕\���L��������s���܂��B
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		bool InitVisibleCheckSystem(bool isDefaultState);
		
		/// <summary>
		/// �����I���V�X�e���ݒ菈��
		/// </summary>
		/// <param name="sysCodeLst">�I���V�X�e�����X�g</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �����I���V�X�e������ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.19</br>
		/// </remarks>
		void InitSelectSystem(int[] sysCodeLst);
		
		/// <summary>
		/// �V�X�e���I������
		/// </summary>
		/// <param name="sysCode">�V�X�e���R�[�h</param>
		/// <param name="checkState">�I�����</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �V�X�e���̑I����ԕύX���ɏ������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		void CheckedSystem(int sysCode, System.Windows.Forms.CheckState checkState);
		#endregion
	}
	#endregion
	
	#region ���@���[�Ɩ�(�������̓^�C�v)PDF�o�͗����C���^�[�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)PDF�o�͗����C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : PDF�o�͗���������ꍇ�̋��ʃC���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypePdfCareer
	{
		#region property
		/// <summary>���[KEY�v���p�e�B</summary>
		/// <remarks>���[�̏o�͗����擾�p��KEY�l���擾���܂��B</remarks>
		string PrintKey{get;}
		
		/// <summary>���[���v���p�e�B</summary>
		/// <remarks>���[�����擾���܂��B</remarks>
		string PrintName{get;}
		#endregion

		#region methods		
		#endregion
	}
	#endregion

	#region ���@���[�Ɩ�(�������̓^�C�v)���o�����擾�E�ݒ�C���^�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)���o�����擾�C���^�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�Ɩ�(�������̓^�C�v)�̒��o�����擾�C���^�[�t�F�[�X�ł��B</br>
	/// <br> �P. ���o�����N���X�� ExtractionCondtnUI ���p�����Ă���ꍇ�A���̃C���^�t�F�[�X��</br>
	/// <br>     �������鎖�Ńt���[�����Ł@ExtractionCondtnUI ���ݒ肳��܂��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.27</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeCondition
	{
		object ObjExtract{get;}
	}
	#endregion
	
	#region ���@���[�Ɩ�(�������̓^�C�v)���o�����Ǘ��C���^�[�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)���o�����Ǘ��C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���o�������Ǘ�����ꍇ�̃C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.24</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeConditionCtrl : IPrintConditionInpTypeCondition 
	{
		#region property
		/// <summary>���o�����ۑ��t���O[T: �ۑ�, F: ���ۑ�]</summary>
		/// <remarks>���o����ۑ����邩�ǂ������擾���܂��B</remarks>
		bool IsConditionSave{get;}
		
		/// <summary>���o�����^�v���p�e�B</summary>
		/// <remarks>���o�����N���X��Type���擾���܂��B</remarks>
		Type ObjType{get;}
		#endregion
	
		#region methods
		/// <summary>
		/// �O�񒊏o�����ݒ菈��
		/// </summary>
		/// <param name="target">���o�����N���X(�O�񒊏o���������݂��Ȃ��ꍇ: null)</param>
		/// <remarks>
		/// <br>Note       : ���o��������ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		void SetExtractCondition(object target);
		#endregion
	}
	#endregion�@

	#region ���@�c�[���o�[�{�^������f���Q�[�g
	/// <summary>
	/// �c�[���o�[�{�^������
	/// </summary>
	/// <param name="sender"></param>
	/// <remarks>
	/// <br>Note       : 
	/// <br>Programer  : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.16</br>
	/// </remarks>
	public delegate void ParentToolbarSettingEventHandler(object sender);
	#endregion

	// >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
	#region ���@���[�Ɩ�(�������̓^�C�v)�e�L�X�g�o�̓C���^�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)�e�L�X�g�o�̓C���^�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �e�L�X�g�o�͂�����ꍇ�̋��ʃC���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.09.01</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeTextOutPut
	{
		/// <summary>�e�L�X�g�o�̓{�^���L�������ݒ�v���p�e�B</summary>
		/// <value>[True:�L��,False:����]</value>
		/// <remarks>�e�L�X�g�o�̓{�^���������邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool CanTextOutPut { get;}

		/// <summary>
		/// �e�L�X�g�o�͏���
		/// </summary>
		/// <param name="parameter">������p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e�L�X�g�o�͏������s���܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.09.01</br>
		/// </remarks>
		int OutPutText(ref object parameter);
	}
	#endregion
	// <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

    // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
    #region ���@���[�Ɩ�(�������̓^�C�v)���s�C���^�t�F�[�X
    /// <summary>
    /// ���[�Ɩ�(�������̓^�C�v)���s�C���^�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �X�V����������ꍇ�̋��ʃC���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30414 Y.Shinobu</br>
    /// <br>Date       : 2008.11.12</br>
    /// <br></br>
    /// </remarks>
    public interface IPrintConditionInpTypeUpdate
    {
        /// <summary>���s�{�^���L�������ݒ�v���p�e�B</summary>
        /// <value>[True:�L��,False:����]</value>
        /// <remarks>���s�{�^���������邩�ǂ����̐ݒ���擾���܂��B</remarks>
        bool CanUpdate { get;}

        /// <summary>
        /// ���s����
        /// </summary>
        /// <param name="parameter">������p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �X�V�������s���܂��B
        //// <br>Programmer : 30414 Y.Shinobu</br>
        /// <br>Date       : 2008.11.12</br>
        /// </remarks>
        int Update(ref object parameter);
    }
    #endregion
    // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

    // --- 2010/08/16 ---------->>>>>
    /// <summary>
    /// ParentToolbarGuideSettingEventHandler
    /// </summary>
    /// <param name="sender"></param>
    public delegate void ParentToolbarGuideSettingEventHandler(bool enabled);

    /// <summary>
    /// ParentPrint
    /// </summary>
    /// <br>Note       : �v�����g�p</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2010/08/26</br>
    public delegate void ParentPrint();

    #region ���@F5�F�K�C�h�̃C���^�t�F�[�X
    /// <summary>
    /// F5�F�K�C�h�̃C���^�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : F5�F�K�C�h�̃C���^�t�F�[�X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2010/08/16</br>
    /// <br></br>
    /// </remarks>
    public interface IPrintConditionInpTypeGuidExecuter
    {
        /// <summary>
        /// �K�C�h�̕\����\���̐ݒ�
        /// </summary>
        event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;

        // --- ADD 2010/08/26 ---------->>>>>
        /// <summary>
        /// �v�����g
        /// </summary>
        event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<

        /// <summary>
        /// �K�C�h���������s����
        /// </summary>
        void ExcuteGuide(object sender, EventArgs e);
    }
    #endregion

    // --- 2010/08/16 ----------<<<<<

    // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
    #region �e�L�X�g�o�̓{�^���𐧌�
    /// <summary>
    /// TextOutControl
    /// </summary>
    /// <br>Note       : �M�z�e�L�X�g�o�̓{�^������p</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : K2014/03/10</br>
    public delegate void TextOutControl();

    /// <summary>
    /// �M�z�p�̃C���^�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �M�z�p�̃C���^�t�F�[�X�ł��B</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : K2014/03/10</br>
    /// <br></br>
    /// </remarks>
    public interface IPrintConditionInpTypeTextOutControl
    {

        /// <summary>
        /// ����p�C�x���g
        /// </summary>
        event TextOutControl TextOutControlCall;
    }
    #endregion �e�L�X�g�o�̓{�^���𐧌�
    // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

}