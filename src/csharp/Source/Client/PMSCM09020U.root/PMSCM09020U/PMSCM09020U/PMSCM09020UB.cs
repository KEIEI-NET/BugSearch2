//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : PCC�S�̐ݒ�}�X�^
// �v���O�����T�v   : PCC�S�̐ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/09/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �C����    2011/09/16  �C�����e : Redmine 25177 PCCUOE�^PM���@PCC�S�̐ݒ�}�X�^�̎d�l�ύX                            
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C����    2012/04/20  �C�����e : �̔��敪�ݒ�A�̔��敪�R�[�h�̒ǉ� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2012/08/31  �C�����e : 2012/10���z�M�\�� SCM��Q��76�̑Ή� 
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;  
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text; 

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC�S�̐ݒ�}�X�^�\���ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�S�̐ݒ�}�X�^���̐ݒ�̐ݒ���s���܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.09.13</br>
    /// <br>Update Note: 2011/09/16 ���N�n��</br>
    /// <br>             ��Q�� #25177 PCCUOE�^PM���@PCC�S�̐ݒ�}�X�^�̎d�l�ύX</br>
    /// </remarks>
	public partial class PMSCM09020UB : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Constructor --
		/// <summary>
        /// PCC�S�̐ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note		: PCC�S�̐ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// <br></br>
		/// </remarks>
        public PMSCM09020UB()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._scmTtlStAcs = new SCMTtlStAcs();
            this._totalCount = 0;
            this._scmTtlStTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���_�ݒ�A�N�Z�X�N���X
            this._secInfoAcs = new SecInfoAcs();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this._userGuideAcs = new UserGuideAcs();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // �[���Ǘ����L���b�V��
            this._scmTtlStAcs.CachePosTerminalMg(this._enterpriseCode);
        }
		#endregion

		#region -- Events --
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		private SCMTtlStAcs _scmTtlStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _scmTtlStTable;

        private SecInfoAcs _secInfoAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// �ۑ���r�pClone
		private SCMTtlSt _scmTtlStClone;
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

        // �V�K���[�h���烂�[�h�ύX�Ή�
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMSCM09020U";    // �v���O����ID

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

		// Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";

        private const string VIEW_SECTION_CODE_TITLE = "���_�R�[�h";
        private const string VIEW_SECTION_NAME_TITLE = "���_����";

        private const string VIEW_SALES_SLIP_PRT_DIV_TITLE = "����`�[���s�敪";
        private const string VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE = "�󒍓`�[���s�敪";
        private const string VIEW_ESTIMATE_PRT_DIV_TITLE = "���Ϗ����s�敪";
        //---DEL 2011/09/16 --------------------------->>>>>
        //private const string VIEW_OLD_SYS_COOPERAT_DIV_TITLE = "���V�X�e���A�g�敪";
        //private const string VIEW_OLD_SYS_COOP_FOLDER_TITLE = "���V�X�e���A�g�p�t�H���_";
        //---DEL 2011/09/16 ---------------------------<<<<<
        private const string VIEW_BL_CODE_CHG_DIV_TITLE = "BL�R�[�h�ϊ�";
        private const string VIEW_AUTO_ANSWER_DIV = "�����񓚋敪";
        private const string VIEW_DISCOUNT_APPLY_CD_TITLE = "�l���K�p�敪";
        private const string VIEW_AUTO_COOPERAT_DIS_TITLE = "�����A�g�l��";
        private const string VIEW_CASHREGISTERNO_TITLE = "��M�����N���[���ԍ�";
        private const string VIEW_CASHREGISTERNONM_TITLE = "��M�����N���[���ԍ�����";
        private const string VIEW_RCVPROCSTINTERVAL_TITLE = "��M�����N���Ԋu";
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private const string VIEW_SALESCD_ST_AUTO_ANS_TITLE = "�̔��敪�ݒ�";
        private const string VIEW_SALES_CODE_TITLE = "�̔��敪";
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private const string VIEW_AUTO_ANSWER_PRICE_DIV = "�����񓚎��\���敪";
        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        private const string VIEW_GUID_KEY_TITLE = "Guid";
		
		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";	   
		private const string DELETE_MODE = "�폜���[�h";

        // �S�Ћ���
        private const string ALL_SECTIONCODE = "00";
        
		#endregion

		#region -- Main --
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMSCM09020UA());
		}
		# endregion

		#region -- Properties --
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{ 
				return this._canPrint; 
			}
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{ 
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{ 
				this._canClose = value; 
			}
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get
			{ 
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{ 
				return this._defaultAutoFillToColumn;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}
		#endregion

		#region -- Public Methods --
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}
		
		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._scmTtlStTable.Clear();

            // �S����
            status = this._scmTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (SCMTtlSt scmTtlSt in retList)
					{
                        // SCM�S�̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        SCMTtlStToDataSet(scmTtlSt.Clone(), index);
						++index;
					}
					break;
				}

				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}

				default:
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
                        this.Text,              �@�@            // �v���O��������
						"Search",                               // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._scmTtlStAcs,					    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��

					break;
				}
			}
			return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
        /// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // �����Ȃ�
            return 9;
        }

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int Delete()
		{
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

            // �S�Ћ��ʃf�[�^�͍폜�s��
            if (scmTtlSt.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
                        "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                return (0);
            }
            
            int status;

            // SCM�S�̐ݒ���̘_���폜����
            status = this._scmTtlStAcs.LogicalDelete(ref scmTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._scmTtlStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // SCM�S�̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            SCMTtlStToDataSet(scmTtlSt.Clone(), this.DataIndex);

            return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// <br>Update Note: 2011/09/16 ���N�n��</br>
        /// <br>             ��Q�� #25177 PCCUOE�^PM���@PCC�S�̐ݒ�}�X�^�̎d�l�ύX</br>
        /// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���_�R�[�h
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // ����`�[���s�敪
            appearanceTable.Add(VIEW_SALES_SLIP_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));
            // �󒍓`�[���s�敪
            appearanceTable.Add(VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ϗ����s�敪
            appearanceTable.Add(VIEW_ESTIMATE_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //---DEL 2011/09/16 --------------------------->>>>>
            //// ���V�X�e���A�g�敪
            //appearanceTable.Add(VIEW_OLD_SYS_COOPERAT_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// ���V�X�e���A�g�p�t�H���_
            //appearanceTable.Add(VIEW_OLD_SYS_COOP_FOLDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //---DEL 2011/09/16 ---------------------------<<<<<
            // BL�R�[�h�ϊ�
            appearanceTable.Add(VIEW_BL_CODE_CHG_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2010/05/21 Add >>>
            // �����񓚋敪
            //appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �����񓚋敪�́ASCM�����񓚃I�v�V�������_�񂳂�Ă���ꍇ�̂ݕ\������
            PurchaseStatus psAutoAnswer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCMAutoAnswer);
            if (psAutoAnswer == PurchaseStatus.Contract || psAutoAnswer == PurchaseStatus.Trial_Contract)
            {
                appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            else
            {
                appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            // 2010/05/21 Add <<<

            // �l���K�p�敪
            appearanceTable.Add(VIEW_DISCOUNT_APPLY_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // �����A�g�l��
            appearanceTable.Add(VIEW_AUTO_COOPERAT_DIS_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ��M�����N���[���ԍ�
            appearanceTable.Add(VIEW_CASHREGISTERNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ��M�����N���[���ԍ�
            appearanceTable.Add(VIEW_CASHREGISTERNONM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ��M�����N���Ԋu
            appearanceTable.Add(VIEW_RCVPROCSTINTERVAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // �̔��敪�ݒ�
            appearanceTable.Add(VIEW_SALESCD_ST_AUTO_ANS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �̔��敪�R�[�h
            appearanceTable.Add(VIEW_SALES_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            appearanceTable.Add(VIEW_AUTO_ANSWER_PRICE_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SCMTtlSt scmTtlSt = new SCMTtlSt();
                //�N���[���쐬
                this._scmTtlStClone = scmTtlSt.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSCMTtlSt(ref this._scmTtlStClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCodeAllowZero.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

                // SCM�S�̐ݒ�N���X��ʓW�J����
                SCMTtlStToScreen(scmTtlSt);

                if (scmTtlSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_CashRegisterNo.Focus();

                    // �N���[���쐬
                    this._scmTtlStClone = scmTtlSt.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSCMTtlSt(ref this._scmTtlStClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.SectionName_tEdit.Enabled = false;

                        this.tEdit_CashRegisterNo.Enabled = true;
                        this.tEdit_CashRegisterNoNm.Enabled = true;
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        this.SalesCdStAutoAns_tComboEditor.Enabled = true;
                        if (SalesCdStAutoAns_tComboEditor.SelectedIndex == 0)
                        {
                            this.SalesCode_tNedit.Enabled = false;
                            this.uButton_SalesCode.Enabled = false;
                        }
                        else
                        {
                            this.SalesCode_tNedit.Enabled = true;
                            this.uButton_SalesCode.Enabled = true;
                        }
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        if (mode == INSERT_MODE)
                        {
                            // �V�K���[�h
                            this.tEdit_SectionCodeAllowZero.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // �X�V���[�h
                            this.tEdit_SectionCodeAllowZero.Enabled = false;
                            this.SectionGuide_Button.Enabled = false;
                        }
                        //ADD START BY wujun FOR Redmine#25181 ON 2011.09.15
                        this.tEdit_CashRegisterNo.Enabled = true;
                        this.tEdit_RcvProcStInterval.Enabled = true;
                        //ADD END BY wujun FOR Redmine#25181 ON 2011.09.15

                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.AutoAnsHourDspDiv_tComboEditor.Enabled = true;
                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.tEdit_CashRegisterNo.Enabled = false;
                        this.tEdit_CashRegisterNoNm.Enabled = false;
                        this.tEdit_RcvProcStInterval.Enabled = false;
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        this.SalesCode_tNedit.Enabled = false;
                        this.uButton_SalesCode.Enabled = false;
                        this.SalesCdStAutoAns_tComboEditor.Enabled = false;
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.AutoAnsHourDspDiv_tComboEditor.Enabled = false;
                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        break;
                    }
            }
        }

		/// <summary>
		/// SCM�S�̐ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// <br>Update Note: 2011/09/16 ���N�n��</br>
        /// <br>             ��Q�� #25177 PCCUOE�^PM���@PCC�S�̐ݒ�}�X�^�̎d�l�ύX</br>
        /// </remarks>
		private void SCMTtlStToDataSet(SCMTtlSt scmTtlSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (scmTtlSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmTtlSt.UpdateDateTimeJpInFormal;
            }

			// ���_�R�[�h
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmTtlSt.SectionCode;
            // ���_����
            string sectionName = GetSectionName(scmTtlSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // ����`�[���s�敪
            switch (scmTtlSt.SalesSlipPrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_SLIP_PRT_DIV_TITLE] = "���Ȃ�";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_SLIP_PRT_DIV_TITLE] = "����";
                    break;
            }

            // �󒍓`�[���s�敪
            switch (scmTtlSt.AcpOdrrSlipPrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE] = "���Ȃ�";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE] = "����";
                    break;
            }

            // ���Ϗ����s�敪
            switch (scmTtlSt.EstimatePrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATE_PRT_DIV_TITLE] = "����";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATE_PRT_DIV_TITLE] = "���Ȃ�";
                    break;
            }

            //---DEL 2011/09/16 --------------------------->>>>>
            //// ���V�X�e���A�g�敪
            //switch (scmTtlSt.OldSysCooperatDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOPERAT_DIV_TITLE] = "���Ȃ�(PM.NS)";
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOPERAT_DIV_TITLE] = "����(PM7SP)";
            //        break;
            //}

            //// ���V�X�e���A�g�p�t�H���_
            //switch (scmTtlSt.OldSysCooperatDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOP_FOLDER_TITLE] = string.Empty;
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOP_FOLDER_TITLE] = scmTtlSt.OldSysCoopFolder;
            //        break;
            //}
            //---DEL 2011/09/16 ---------------------------<<<<<
            // BL�R�[�h�ϊ�
			switch(scmTtlSt.BLCodeChgDiv)
			{
				case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BL_CODE_CHG_DIV_TITLE] = "����";
					break;
				case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BL_CODE_CHG_DIV_TITLE] = "���Ȃ�";
					break;
			}

            // �����񓚋敪
            switch (scmTtlSt.AutoAnswerDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "���Ȃ�";
                    break;
                case 1:
                   this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "����(�ϑ��݌ɕ��̂�)";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "����(�݌ɕ��̂�)";
                    break;
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "����(�S��)";
                    break;
            }

            // �l���K�p�敪
			switch(scmTtlSt.DiscountApplyCd)
			{
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "���Ȃ�";
                    break;
				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "�S��";
					break;
				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "�O���i����";
					break;
				case 3:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "�d�_�i��";
					break;
			}

            // �����A�g�l��
            switch (scmTtlSt.DiscountApplyCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_COOPERAT_DIS_TITLE] = string.Empty;
                    break;
                case 1:
                case 2:
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_COOPERAT_DIS_TITLE] = scmTtlSt.AutoCooperatDis.ToString("#0.00");
                    break;
            }
            //��M�����N���[���ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO_TITLE] = scmTtlSt.CashRegisterNo;
            
            //��M�����N���[���ԍ�����
             PosTerminalMg posTerminalMg = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, scmTtlSt.CashRegisterNo);
             if (posTerminalMg != null)
             {
                 this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNONM_TITLE] = posTerminalMg.MachineName;
             }
            //��M�����N���Ԋu
             this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RCVPROCSTINTERVAL_TITLE] = scmTtlSt.RcvProcStInterval;
             //2012/04/20 ADD T.Nishi >>>>>>>>>>
             //�̔��敪�ݒ�(�����񓚎�)
             switch (scmTtlSt.SalesCdStAutoAns)
             {
                 case 0:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESCD_ST_AUTO_ANS_TITLE] = "���Ȃ�";
                     //�̔��敪
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_CODE_TITLE] = "";
                     break;
                 case 1:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESCD_ST_AUTO_ANS_TITLE] = "����";
                     //�̔��敪
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_CODE_TITLE] = String.Format("{0:0000}", scmTtlSt.SalesCode);
                     break;
             }
             //2012/04/20 ADD T.Nishi <<<<<<<<<<

             // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
             //�����񓚎��\���敪
             switch (scmTtlSt.AutoAnsHourDspDiv)
             {
                 case 0:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "�g�p���Ȃ�";
                     break;
                 case 1:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "PM�ݒ�ɏ]��";
                     break;
                 case 2:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "�D��";
                     break;
                 case 3:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "����";
                     break;
                 case 4:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "������(1:N)";
                     break;
                 case 5:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "������(1:1)";
                     break;
             }
             // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmTtlSt.FileHeaderGuid;
			
			if (this._scmTtlStTable.ContainsKey(scmTtlSt.FileHeaderGuid) == true)
			{
				this._scmTtlStTable.Remove(scmTtlSt.FileHeaderGuid);
			}
			this._scmTtlStTable.Add(scmTtlSt.FileHeaderGuid, scmTtlSt);

		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// <br>Update Note: 2011/09/16 ���N�n��</br>
        /// <br>             ��Q�� #25177 PCCUOE�^PM���@PCC�S�̐ݒ�}�X�^�̎d�l�ύX</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable scmTtlStTable = new DataTable(VIEW_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            scmTtlStTable.Columns.Add(DELETE_DATE, typeof(string));			                // �폜��
            
            scmTtlStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));             // ���_�R�[�h
			scmTtlStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));             // ���_����

            scmTtlStTable.Columns.Add(VIEW_SALES_SLIP_PRT_DIV_TITLE, typeof(string));       // ����`�[���s�敪
            scmTtlStTable.Columns.Add(VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE, typeof(string));    // �󒍓`�[���s�敪
            scmTtlStTable.Columns.Add(VIEW_ESTIMATE_PRT_DIV_TITLE, typeof(string));         // ���Ϗ����s�敪
            //---DEL 2011/09/16 --------------------------->>>>>
            //scmTtlStTable.Columns.Add(VIEW_OLD_SYS_COOPERAT_DIV_TITLE, typeof(string));     // ���V�X�e���A�g�敪
            //scmTtlStTable.Columns.Add(VIEW_OLD_SYS_COOP_FOLDER_TITLE, typeof(string));      // ���V�X�e���A�g�p�t�H���_
            //---DEL 2011/09/16 ---------------------------<<<<<
            scmTtlStTable.Columns.Add(VIEW_BL_CODE_CHG_DIV_TITLE, typeof(string));          // BL�R�[�h�ϊ�
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSWER_DIV, typeof(string));                // �����񓚋敪
            scmTtlStTable.Columns.Add(VIEW_DISCOUNT_APPLY_CD_TITLE, typeof(string));        // �l���K�p�敪
            scmTtlStTable.Columns.Add(VIEW_AUTO_COOPERAT_DIS_TITLE, typeof(string));        // �����A�g�l��
            scmTtlStTable.Columns.Add(VIEW_CASHREGISTERNO_TITLE, typeof(int));        // ��M�����N���[���ԍ�
            scmTtlStTable.Columns.Add(VIEW_CASHREGISTERNONM_TITLE, typeof(string));        // ��M�����N���[���ԍ�
            scmTtlStTable.Columns.Add(VIEW_RCVPROCSTINTERVAL_TITLE, typeof(int));        // ��M�����N���Ԋu
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlStTable.Columns.Add(VIEW_SALESCD_ST_AUTO_ANS_TITLE, typeof(string));        // �̔��敪�ݒ�
            scmTtlStTable.Columns.Add(VIEW_SALES_CODE_TITLE, typeof(string));        // �̔��敪�R�[�h
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSWER_PRICE_DIV, typeof(string));          // �����񓚎��\���敪
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            scmTtlStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid

			this.Bind_DataSet.Tables.Add(scmTtlStTable);
		}

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            //�̔��敪�ݒ�(�����񓚎�)
            SalesCdStAutoAns_tComboEditor.Items.Clear();
            SalesCdStAutoAns_tComboEditor.Items.Add(0, "���Ȃ�");
            SalesCdStAutoAns_tComboEditor.Items.Add(1, "����");
            SalesCdStAutoAns_tComboEditor.MaxDropDownItems = SalesCdStAutoAns_tComboEditor.Items.Count;

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            AutoAnsHourDspDiv_tComboEditor.Items.Clear();
            AutoAnsHourDspDiv_tComboEditor.Items.Add(0, "�g�p���Ȃ�");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(1, "PM�ݒ�ɏ]��");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(2, "�D��");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(3, "����");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(4, "������(1:N)");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(5, "������(1:1)");
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        /// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.SectionName_tEdit.DataText = "";

            this.tEdit_CashRegisterNo.DataText = string.Empty;          // ��M�����N���[���ԍ�
            this.tEdit_CashRegisterNoNm.DataText = string.Empty;        // ��M�����N���[���ԍ�����
            this.tEdit_RcvProcStInterval.DataText = string.Empty;       // ��M�����N���Ԋu
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this.SalesCdStAutoAns_tComboEditor.SelectedIndex = 0;          // �̔��敪�ݒ�(�����񓚎�)
            this.SalesCode_tNedit.DataText = "";               // �̔��敪�R�[�h
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this.AutoAnsHourDspDiv_tComboEditor.SelectedIndex = 0;     //�����񓚎��\���敪
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
        /// SCM�S�̐ݒ�N���X��ʓW�J����
		/// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void SCMTtlStToScreen(SCMTtlSt scmTtlSt)
		{
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = scmTtlSt.SectionCode;
            // ���_����
            string sectionName = string.Empty;
            if (scmTtlSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "�S�Ћ���";
            }
            else
            {
                sectionName = this.GetSectionName(scmTtlSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;
            
            // ��M�����N���[���ԍ�
            if (scmTtlSt.CashRegisterNo != 0) this.tEdit_CashRegisterNo.DataText = scmTtlSt.CashRegisterNo.ToString();
            PosTerminalMg posTerminalMg = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, scmTtlSt.CashRegisterNo);
            if (posTerminalMg != null) this.tEdit_CashRegisterNoNm.Text = posTerminalMg.MachineName;

            // ��M�����N���Ԋu
            this.tEdit_RcvProcStInterval.DataText = scmTtlSt.RcvProcStInterval.ToString();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // �̔��敪�ݒ�(�����񓚎�)
            this.SalesCdStAutoAns_tComboEditor.SelectedIndex = scmTtlSt.SalesCdStAutoAns;

            // �̔��敪�R�[�h
            this.SalesCode_tNedit.DataText = scmTtlSt.SalesCode.ToString();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            this.AutoAnsHourDspDiv_tComboEditor.SelectedIndex = scmTtlSt.AutoAnsHourDspDiv;
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
        /// ��ʏ��SCM�S�̐ݒ�N���X�i�[����
		/// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂�SCM�S�̐ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void ScreenToSCMTtlSt(ref SCMTtlSt scmTtlSt)
		{
			if (scmTtlSt == null)
			{
				// �V�K�̏ꍇ
                scmTtlSt = new SCMTtlSt();
			}

            //��ƃR�[�h
            scmTtlSt.EnterpriseCode = this._enterpriseCode; 
            // ���_�R�[�h
            scmTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;
            // ��M�����N���[���ԍ�
            scmTtlSt.CashRegisterNo = TStrConv.StrToIntDef(this.tEdit_CashRegisterNo.DataText, 0);
            // ��M�����N���Ԋu
            scmTtlSt.RcvProcStInterval = TStrConv.StrToIntDef(this.tEdit_RcvProcStInterval.DataText, 0);
            //��ʏ�ɖ������ڂ̐ݒ�
            // ����`�[���s�敪:���Ȃ�
            scmTtlSt.SalesSlipPrtDiv = 0;

            // �󒍓`�[���s�敪:���Ȃ�
            scmTtlSt.AcpOdrrSlipPrtDiv = 0;

            // ���Ϗ����s�敪:���Ȃ�
            scmTtlSt.EstimatePrtDiv = 1;

            // ���V�X�e���A�g�敪:���Ȃ��iPM.NS�j
            scmTtlSt.OldSysCooperatDiv = 0;

            // ���V�X�e���A�g�p�t�H���_:��
            scmTtlSt.OldSysCoopFolder = string.Empty;

            // BL�R�[�h�ϊ�:���Ȃ�
            scmTtlSt.BLCodeChgDiv = 1;

            // �����񓚋敪:����(�S��)
            scmTtlSt.AutoAnswerDiv = 3;

            // �l���K�p�敪:���Ȃ�
            scmTtlSt.DiscountApplyCd = 0;

            // �����A�g�l����:0
            scmTtlSt.AutoCooperatDis = 0;

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // �̔��敪�ݒ�(�����񓚎�)
            scmTtlSt.SalesCdStAutoAns = (int)this.SalesCdStAutoAns_tComboEditor.Value;
            // �̔��敪�R�[�h
            scmTtlSt.SalesCode = this.SalesCode_tNedit.GetInt();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            scmTtlSt.AutoAnsHourDspDiv = (int)this.AutoAnsHourDspDiv_tComboEditor.Value;
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<


		}

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ��r�p�N���[���N���A
            this._scmTtlStClone = null;

            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
		{
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
		}

		/// <summary>
		///	SCM�S�̐ݒ��ʓ��̓`�F�b�N����
		/// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM�S�̐ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            bool result = true;

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                message = this.Section_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_SectionCodeAllowZero;
                result = false;
            }

            //ADD START BY wujun FOR Redmine#25181 ON 2011.09.15
            // ��M�����N���[���ԍ�
            if (string.IsNullOrEmpty(this.tEdit_CashRegisterNo.DataText.Trim()))
            {
                message = this.ultraLabel7.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_CashRegisterNo;
                result = false;
            }
            //ADD END BY wujun FOR Redmine#25181 ON 2011.09.15
            //ADD START BY wujun FOR Redmine#25181 ON 2011.09.20
            // ��M�����N���Ԋu
            else if (string.IsNullOrEmpty(this.tEdit_RcvProcStInterval.DataText.Trim()))
            {
                message = this.ultraLabel9.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_RcvProcStInterval;
                result = false;
            }
            //ADD END BY wujun FOR Redmine#25181 ON 2011.09.20

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //�̔��敪�ݒ�(�����񓚎�)
            if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
            {
                //�̔��敪�R�[�h
                if (this.SalesCode_tNedit.GetValue() == 0)
                {
                    message = this.ultraLabel13.Text + "��ݒ肵�ĉ������B";
                    control = this.SalesCode_tNedit;
                    result = false;
                }
            }
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            return result;
		}
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        #region �̔��敪

        /// <summary>
        /// �̔��敪�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2012/04/20 �� �B</br>
        /// <br>              ���o��������͌�̕\���̓R�[�h�{���̂ŕ\������B</br>
        private void uButton_SalesCode_Click(object sender, EventArgs e)
        {
            int userGuideDivCd_SalesCode = 71;  // �̔��敪�F71

            // �R�[�h���疼�̂֕ϊ�
            UserGdHd userGuideHdInfo;
            UserGdBd userGuideBdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (userGuideBdInfo.GuideCode != 0)
                {
                    this.SalesCode_tNedit.DataText = String.Format("{0:0000}", userGuideBdInfo.GuideCode);
                }
                //�ŐV���Ƀt�H�[�J�X�Z�b�g
                Renewal_Button.Focus();

            }
        }

        #endregion // �̔��敪

        //2012/04/20 ADD T.Nishi <<<<<<<<<<

		/// <summary>
        ///�@�ۑ�����(SaveProc())
		/// </summary>
		/// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            
			//��ʃf�[�^���̓`�F�b�N����
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }
	
			SCMTtlSt scmTtlSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmTtlSt = ((SCMTtlSt)this._scmTtlStTable[guid]).Clone();
			}

            // ��ʏ����擾
			ScreenToSCMTtlSt(ref scmTtlSt);
            // �o�^�E�X�V����
			int status = this._scmTtlStAcs.Write(ref scmTtlSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                {
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                }
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // �r������
                    ExclusiveTransaction(status, true);					
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}
				default:
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
						this.Text,  �@�@                        // �v���O��������
                        "SaveProc",                             // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._scmTtlStAcs,				    	// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,			  		// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // SCM�S�̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
			SCMTtlStToDataSet(scmTtlSt, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
			result = true;
			return result;
		}


        /// <summary>
        ///�@���������b�Z�[�W�\��
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �Y���R�[�h���g�p����Ă���ꍇ�Ƀ��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�" ,// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
                tEdit_SectionCodeAllowZero.Focus();

                control = tEdit_SectionCodeAllowZero;
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(190, 24);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_���� �����݂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ћ��ʃ`�F�b�N
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "�S�Ћ���";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note		: ���[�h�ύX����</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2011.09.13</br>
        /// </remarks>  
        private bool ModeChangeProc()
        {
            string msg = "���͂��ꂽ�R�[�h��SCM�S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��SCM�S�̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h��SCM�S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PROGRAM_ID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�A���̂̃N���A
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        # endregion

        # region -- Control Events --
       	/// <summary>
        ///	Form.Load �C�x���g(PMSCM09020UB)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void PMSCM09020UB_Load(object sender, System.EventArgs e)
		{
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this.uButton_SalesCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //2012/04/20 ADD T.Nishi <<<<<<<<<<
            
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

		}

		/// <summary>
        ///	Form.Closing �C�x���g(PMSCM09020UB)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void PMSCM09020UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}		
		}

		/// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSCM09020UB)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
		///					  ���Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09020UB_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			
            // ��ʃN���A
			ScreenClear();

            Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // �o�^�E�X�V����
			if (!SaveProc())
			{
				return;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SCMTtlSt compareSCMTtlSt = new SCMTtlSt();

                compareSCMTtlSt = this._scmTtlStClone.Clone();
                ScreenToSCMTtlSt(ref compareSCMTtlSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._scmTtlStClone.Equals(compareSCMTtlSt))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PROGRAM_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                return;
                            }
                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                // �V�K���[�h���烂�[�h�ύX�Ή�
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                return;
                            }
                    }
                }
            }
            
            this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Timer.Tick �C�x���g(timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;

            // ��ʕ\������
			ScreenReconstruction();
		}

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.tEdit_CashRegisterNo.Focus();

                    // �V�K���[�h���烂�[�h�ύX�Ή�
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
                else if (status == 1)
                {
                    // [�߂�]�̏ꍇ
                    if (ModeChangeProc())
                    {
                        SectionGuide_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

            // ���S�폜����
            int status = this._scmTtlStAcs.Delete(scmTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmTtlStTable.Remove(scmTtlSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // ���S�폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._scmTtlStAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = ((SCMTtlSt)this._scmTtlStTable[guid]).Clone();

            // ��������
            status = this._scmTtlStAcs.Revival(ref scmTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM�S�̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        SCMTtlStToDataSet(scmTtlSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._scmTtlStAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        ///  <br>Note�@�@�@ : ChangeFocus �C�x���g�������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // �V�K���[�h���烂�[�h�ύX�Ή�
            _modeFlg = false;

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;

                // ���_���̎擾
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���_�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_SectionCodeAllowZero.Clear();
                    this.SectionName_tEdit.Clear();
                    //e.NextCtrl = SectionGuide_Button;
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                    e.NextCtrl.Select();
                    return;
                }
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // �t�H�[�J�X�ݒ�
                            e.NextCtrl = this.tEdit_CashRegisterNo;
                        }
                    }
                }

                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tEdit_SectionCodeAllowZero
                            &&
                        e.NextCtrl == this.SectionGuide_Button
                            &&
                        string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim())
                    )
                    {
                        // �������Ȃ� ��V�K���[�h�ŋN������ɋ��_�̃K�C�h�{�^�����N���b�N�����ꍇ�ɑ���
                    }
                    else
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // �ŐV���{�^������̑J�ڎ��A�X�V�`�F�b�N��ǉ�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            // ��M�����N���[��
            else if (e.PrevCtrl == tEdit_CashRegisterNo)
            {
                int cashRegisterno = TStrConv.StrToIntDef(tEdit_CashRegisterNo.DataText, 0);
                if (cashRegisterno != 0)
                {
                    PosTerminalMg pos = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, cashRegisterno);
                    if (pos == null)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�Y������[���ԍ������݂��܂���",
                            -1,
                            MessageBoxButtons.OK
                        );
                        this.tEdit_CashRegisterNo.Clear();
                        this.tEdit_CashRegisterNoNm.Clear();
                        e.NextCtrl = this.tEdit_CashRegisterNo;
                        e.NextCtrl.Select();
                        return;
                    }
                    else
                    {
                        this.tEdit_CashRegisterNoNm.DataText = pos.MachineName;
                    }
                }
                else
                {
                    this.tEdit_CashRegisterNo.Clear();
                    this.tEdit_CashRegisterNoNm.Clear();
                }
            }
            // ��M�����N���Ԋu
            else if (e.PrevCtrl == tEdit_RcvProcStInterval)
            {
                int rcvProcStInterval = TStrConv.StrToIntDef(tEdit_RcvProcStInterval.DataText, 0);
                if (rcvProcStInterval < 1)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "1���ȏ�Őݒ肵�ĉ�����",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_RcvProcStInterval.Clear();
                    e.NextCtrl = this.tEdit_RcvProcStInterval;
                    e.NextCtrl.Select();
                    return;
                }
            }

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            else if (e.PrevCtrl == SalesCode_tNedit)
            {
                //�̔��敪�ݒ�(�����񓚎�)
                if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
                {
                    //�̔��敪�R�[�h
                    if (this.SalesCode_tNedit.GetValue() != 0)
                    {
                        //�}�X�^���݃`�F�b�N
                        int SalesCode = this.SalesCode_tNedit.GetInt();
                        UserGdBd userGdBd = null;
                        UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                        int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 71, SalesCode, ref acsDataType);

                        if (userGdBd == null || status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || userGdBd.LogicalDeleteCode != 0)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                this.ultraLabel13.Text + "[" + SalesCode + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK
                            );
                            this.SalesCode_tNedit.Clear();
                            e.NextCtrl = this.SalesCode_tNedit;
                            e.NextCtrl.Select();
                            return;
                        }
                    }
                }

            }
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

        }

        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        /// <remarks>
        ///  <br>Note�@�@�@: �ŐV���{�^���N���b�N�������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
      
		#endregion

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private void SalesCdStAutoAns_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (SalesCdStAutoAns_tComboEditor.SelectedIndex == 0)
            {
                // �̔��敪�ݒ�����Ȃ�
                SalesCode_tNedit.DataText = "";
                SalesCode_tNedit.Enabled = false;
                uButton_SalesCode.Enabled = false;
            }
            else
            {
                // �̔��敪�ݒ肪��L�ȊO
                SalesCode_tNedit.Enabled = true;
                uButton_SalesCode.Enabled = true;
            }
        }
        //2012/04/20 ADD T.Nishi <<<<<<<<<<


	}
}
