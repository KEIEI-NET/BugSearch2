//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�}�X�^
// �v���O�����T�v   �F���Ӑ�̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2008/04/23     �C�����e�FPartsman�p�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V�m��
// �C����    2008/12/02     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2009/02/03     �C�����e�F��QID:9391�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2009.02.17     �C�����e�FRead���̖��̐ݒ�敪�ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2009.04.03     �C�����e�F������z�[�������擾�ŃL���b�V���ɊY���Ȃ����R�Ăяo������悤�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y12493�z�̎����o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/03     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/26     �C�����e�FMantis�y13295�z���Ӑ於�̂Ɨ��̂̕K�{�`�F�b�N���珜�O
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2009/07/30     �C�����e�FLoginInfoAcquisition.OnlineFlag���Q�Ƃ��ď������s��Ȃ��B
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22008 ����
// �C����    2010/04/06     �C�����e�F�i�Ԍ������x�A�b�v�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �揬��
// �C����    2010/06/26     �C�����e�FSCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S��: �����
// �� �� ��  2010/09/26     �C�����e: Redmine��Q�� #14483�̏C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F21024�@���X�� ��
// �C����    2010/10/28     �C�����e�FMANTIS[0016523]�Ή�
//                                   �@�Ǘ����_���̂̓����[�g����擾�����f�[�^�����̂܂܎g�p����
//                                   �A�n��A�E��A�Ǝ�̘_���폜�`�F�b�N�̍폜�i�����[�g���őΉ��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970681-00    �쐬�S���F��
// �C����    K2014/02/06    �C�����e�F�O�����a����� ���Ӑ�}�X�^���ǑΉ�
// ------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00    �쐬�S���F���J�M�m
// �C����    2021/05/10     �C�����e�F���Ӑ���K�C�h�\��PKG�Ή�
// ------------------------------------------------------------------------//
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Resources;  // ADD �� K2014/02/06

namespace Broadleaf.Application.Controller
{
	// ========================================================================================= //
	// �f���Q�[�g
	// ========================================================================================= //
	# region Delegate
	/// <summary>���Ӑ���ύX�f���Q�[�g</summary>
	public delegate void CustomerInfoChangeEventHandler(object sender, string frameKey, ref CustomerInfo customerInfo);

	/// <summary>���Ӑ���폜�f���Q�[�g</summary>
	public delegate void CustomerInfoDeleteEventHandler(object sender, string frameKey, ref CustomerInfo customerInfo);
	# endregion

	/// <summary>
	/// ���Ӑ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2008.04.23</br>
    /// <br>UpdateNote  : 2008/12/02 30462 �s�V�m���@�o�O�C��</br>
    /// <br>UpdateNote  : 2009/02/03 30414 �E�K�j�@��QID:9391�Ή�</br>
    /// <br>UpdateNote  : 2009.02.17 20056 ���n ���@Read���̖��̐ݒ�敪�ǉ�</br>
    /// <br>UpdateNote  : 2009.04.03 22018 ��� ���b�@������z�[�������擾�ŃL���b�V���ɊY���Ȃ����R�Ăяo������悤�C��</br>
    /// <br>UpdateNote  : 2021/05/10 32653 ���J �M�m�@���Ӑ���K�C�h�\��PKG�Ή��ɂē��Ӑ���K�C�h�\���敪��ǉ�</br>
    /// </remarks>
	public class CustomerInfoAcs
	{
		// ===================================================================================== //
		// �X�^�e�B�b�N�ȕϐ��Q
		// ===================================================================================== //
		#region Static Informain
		private static int  _uniqidCounter;										// �A�N�Z�X�R���g���[������ID���s�p
		private static Hashtable _infoChange;									// ���Ӑ���ύX�f���Q�[�g�p
		private static Hashtable _infoDelete;									// ���Ӑ���폜���f���Q�[�g�p
		private static Dictionary<string, CustomerInfo> _customerDictionary;	// ���Ӑ���o�b�t�@(MainMemory)�i�[�pDictionary
		private static Dictionary<string, CustomerInfo> __customerDictionary;	// ���Ӑ���o�b�t�@(UndoMemory)�i�[�pDictionary
		# endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
		# region Const
        private const string OFFLINE_DATA_IDENTIFIER = "CUSTOMER";
		# endregion

        // ===================================================================================== //
        // �p�u���b�N Enum
        // ===================================================================================== //
        # region [public Enum]
        /// <summary>
        /// ���z�[�������敪
        /// </summary>
        public enum FracProcMoneyDiv
        {
            /// <summary>�P��</summary>
            UnPrcFrcProcCd = 0,
            /// <summary>���z</summary>
            MoneyFrcProcCd = 1,
            /// <summary>�����</summary>
            CnsTaxFrcProcCd = 2,
        }

        // ADD ���J�M�m 2021/05/10 -------------------------------------------------->>>>>
        /// <summary>
        /// ���Ӑ���K�C�h�\���敪
        /// </summary>
        public enum DisplayDivCode
        {
            /// <summary>�\��</summary>
            ShowDisplayDivCode = 0,
            /// <summary>��\��</summary>
            HideDisplayDivCode = 1,
        }
        // ADD ���J�M�m 2021/05/10 --------------------------------------------------<<<<<
        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private int _uniqid;													// �A�N�Z�X�R���g���[������ID
		private string _key = string.Empty;												// �L�[�o�b�t�@
		private ICustomerInfoDB _iCustomerInfoDB = null;
		private string _enterpriseCode = string.Empty;									// ��ƃR�[�h
        private CustomerLcDB _customerInfoLcDB = null;
        private static bool _isLocalDBRead = false;
        // DEL ���J�M�m 2021/05/10 ------------------------------------->>>>>
        // ADD �� K2014/02/06 -------------------------->>>>>
        //private int _opt_Maehashi;
        // ADD �� K2014/02/06 --------------------------<<<<<
        // DEL ���J�M�m 2021/05/10 -------------------------------------<<<<<

        // 2010/10/28 Del >>>
        //// --- ADD 2010/08/10 ------------------------------------>>>>>
        //// ���[�U�}�X�^�A�N�Z�X�N���X
        //private UserGuideAcs _userGuideAcs;
        //// --- ADD 2010/08/10 ------------------------------------<<<<<
        //// 2010/10/28 Del <<<
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�@�v���p�e�B
        // ===================================================================================== //
        # region [public Propaties]
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // ADD �� K2014/02/06 -------------------------------------->>>>>
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        // ADD �� K2014/02/06 --------------------------------------<<<<<
        # endregion

        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���Ӑ���A�N�Z�X�N���X�̃R���X�g���N�^
		/// </summary>
		public CustomerInfoAcs()
		{
            // ���j�[�N��ID��this�ɐݒ�
			this._uniqid = ++_uniqidCounter;

			// �ϐ�������
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			if (_customerDictionary == null)
			{
				_customerDictionary = new Dictionary<string, CustomerInfo>();
			}

			if (__customerDictionary == null)
			{
				__customerDictionary = new Dictionary<string, CustomerInfo>();
			}

			// �����[�g�I�u�W�F�N�g�擾
			this._iCustomerInfoDB = (ICustomerInfoDB)MediationCustomerInfoDB.GetCustomerInfoDB();
            this._customerInfoLcDB = new CustomerLcDB();

            // ���ύX�f���Q�[�g�p
			if (_infoChange == null)
			{
				_infoChange = new Hashtable();
			}

			// ���Ӑ���폜�f���Q�[�g�p
			if (_infoDelete == null)
			{
				_infoDelete = new Hashtable();
			}

            // 2010/10/28 Del >>>
            //// --- ADD 2010/08/10 ------------------------------------>>>>>
            //// ���[�U�}�X�^�A�N�Z�X�N���X
            //if (_userGuideAcs == null)
            //{
            //    _userGuideAcs = new UserGuideAcs();
            //}
            //// --- ADD 2010/08/10 ------------------------------------<<<<<
            // 2010/10/28 Del <<<
            // ADD �� K2014/02/06 ------------------------------------->>>>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region ��
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // DEL ���J�M�m 2021/05/10 ------------------------------------->>>>>
                //this._opt_Maehashi = (int)Option.ON;
                // DEL ���J�M�m 2021/05/10 -------------------------------------<<<<<
            }
            else
            {
                // DEL ���J�M�m 2021/05/10 ------------------------------------->>>>>
                //this._opt_Maehashi = (int)Option.OFF;
                // DEL ���J�M�m 2021/05/10 -------------------------------------<<<<<
            }
            #endregion
            // ADD �� K2014/02/06 -------------------------------------<<<<<
        }

        /// <summary>
		/// ���Ӑ�}�X�^�A�N�Z�X�N���X �R���X�g���N�^
		/// </summary>
		public CustomerInfoAcs(string key): this()
		{
			this._key = key;
		}
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g�֘A���\�b�h
		// ===================================================================================== //
		#region ���Ӑ���ύX�f���Q�[�g�֘A���\�b�h��`
		/// <summary>
		/// ���Ӑ���ύX�ʒm�o�^����
		/// </summary>
		/// <param name="handler">�o�^����f���Q�[�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ����ύX�����ۂɔ�������C�x���g��o�^���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void AddInfoCustomerChangeEvent(CustomerInfoChangeEventHandler handler)
		{
            // �n�b�V���e�[�u�����A�Y���f���Q�[�g���擾
			CustomerInfoChangeEventHandler pstHandler = (CustomerInfoChangeEventHandler)_infoChange[this._uniqid];
			
			// ���݂��Ȃ��H
			if (pstHandler == null)
			{
				// �n�b�V���e�[�u���ɑ��݂��邩�H
				pstHandler = handler;
				if (_infoChange.ContainsKey(this._uniqid) == true)
				{
					// ���݂���΍X�V
					_infoChange[this._uniqid] = pstHandler;
				}
				else
				{
					// ���݂��Ȃ���Βǉ�
					_infoChange.Add(this._uniqid, pstHandler);
				}
			}
			else
			{
				// ���݂���Βǉ�
				pstHandler  += handler;
				_infoChange[this._uniqid] = pstHandler;
			}
		}

		/// <summary>
		/// ���Ӑ���ύX�ʒm�폜����
		/// </summary>
		/// <param name="handler">�폜����f���Q�[�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�����擾�����ۂɔ�������C�x���g���폜���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void RemoveInfoCustomerChange(CustomerInfoChangeEventHandler handler)
		{
            CustomerInfoChangeEventHandler pstHandler = (CustomerInfoChangeEventHandler)_infoChange[this._uniqid];
			if (pstHandler != null)
			{
				pstHandler  -= handler;
				if (pstHandler == null)
				{
					_infoChange.Remove(this._uniqid);
				}
				else
				{
					_infoChange[this._uniqid] = pstHandler;
				}
			}
		}

		/// <summary>
		/// ���Ӑ���ύX�w��
		/// </summary>
		/// <param name="sender">�ύX�w����΂����̃N���X</param>
		/// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
		/// <param name="customerInfo">���Ӑ���</param>
		/// <returns>true=����,false=���s</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ��񂪕ύX���ꂽ�|��ʒm���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private bool InstructionInfoCustomerChange(object sender, bool forceEvent, ref CustomerInfo customerInfo)
		{
			// ���ύX�ʒm����
			foreach(int key in _infoChange.Keys)
			{
				// ����̃L�[�̏ꍇ�́A�������Ȃ�! (�A���A�����C�x���g�̏ꍇ�́A�R�[�����ɂ��C�x���g�𔭐�������j
				if ((forceEvent) || (key != this._uniqid))
				{
					CustomerInfo ci = customerInfo.Clone();

					CustomerInfoChangeEventHandler dlghandler = (CustomerInfoChangeEventHandler)_infoChange[key];
					dlghandler(sender, this._key, ref customerInfo);
				}
			}
			return true;
		}

		/// <summary>
		/// ���Ӑ���폜�w��
		/// </summary>
		/// <param name="sender">�w����΂����̃N���X</param>
		/// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
		/// <param name="customerInfo">���Ӑ���</param>
		/// <returns>true=����,false=���s</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ��񂪍폜���ꂽ�|��ʒm���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
        private bool InstructionCustomerInfoDelete ( object sender, bool forceEvent, ref CustomerInfo customerInfo )
		{
			// �폜�ʒm����
			foreach (int key in _infoDelete.Keys)
			{
				// ����̃L�[�̏ꍇ�́A�������Ȃ�! (�A���A�����C�x���g�̏ꍇ�́A�R�[�����ɂ��C�x���g�𔭐�������j
				if ((forceEvent) || (key != _uniqid))
				{
					CustomerInfoDeleteEventHandler dlghandler = (CustomerInfoDeleteEventHandler)_infoDelete[key];
					dlghandler(sender, this._key, ref customerInfo);
				}
			}
			return true;
		}
		# endregion

		#region ���Ӑ���폜 �f���Q�[�g�֘A���\�b�h��`
		/// <summary>
		/// ���Ӑ���폜�ʒm�o�^����
		/// </summary>
		/// <param name="handler">�o�^����f���Q�[�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�����폜����ۂɔ�������C�x���g��o�^���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void AddInfoDeleteCustomerEvent(CustomerInfoDeleteEventHandler handler)
		{
            // �n�b�V���e�[�u�����A�Y���f���Q�[�g���擾
			CustomerInfoDeleteEventHandler pstHandler = (CustomerInfoDeleteEventHandler)_infoDelete[this._uniqid];
			// ���݂��Ȃ��H
			if (pstHandler == null)
			{
				// �n�b�V���e�[�u���ɑ��݂��邩�H
				pstHandler = handler;
				if (_infoDelete.ContainsKey(this._uniqid) == true)
				{
					// ���݂���΍X�V
					_infoDelete[this._uniqid] = pstHandler;
				}
				else
				{
					// ���݂��Ȃ���Βǉ�
					_infoDelete.Add(this._uniqid, pstHandler);
				}
			}
			else
			{
				// ���݂���Βǉ�
				pstHandler  += handler;
				_infoDelete[this._uniqid] = pstHandler;
			}
		}

		/// <summary>
		/// ���Ӑ���폜�ʒm�폜����
		/// </summary>
		/// <param name="handler">�폜����f���Q�[�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ����o�^����ۂɔ�������C�x���g���폜���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void RemoveInfoDeleteCustomerEvent(CustomerInfoDeleteEventHandler handler)
		{
            CustomerInfoDeleteEventHandler pstHandler = (CustomerInfoDeleteEventHandler)_infoDelete[this._uniqid];
			if (pstHandler != null)
			{
				pstHandler  -= handler;
				if (pstHandler == null)
				{
					_infoDelete.Remove(this._uniqid);
				}
				else
				{
					_infoDelete[this._uniqid] = pstHandler;
				}
			}
		}
	
		/// <summary>
		/// ���Ӑ���폜�w��
		/// </summary>
		/// <param name="sender">�w����΂����̃N���X</param>
		/// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
		/// <param name="customerInfo">���Ӑ���</param>
		/// <returns>true=����,false=���s</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ����DB�ɍ폜����|��ʒm���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private bool InstructionInfoDeleteCustomerInfo(object sender, bool forceEvent, ref CustomerInfo customerInfo)
		{
			// �폜�ʒm����
			foreach (int key in _infoDelete.Keys)
			{
				// ����̃L�[�̏ꍇ�́A�������Ȃ�! (�A���A�����C�x���g�̏ꍇ�́A�R�[�����ɂ��C�x���g�𔭐�������j
				if ((forceEvent) || (key != _uniqid))
				{
					CustomerInfoDeleteEventHandler dlghandler = (CustomerInfoDeleteEventHandler)_infoDelete[key];
					dlghandler(sender, this._key, ref customerInfo);
				}
			}
			return true;
		}
		#endregion

		// ===================================================================================== //
		// Static�̈摀��
		// ===================================================================================== //
		# region StaticMemory Control
		/// <summary>
		/// Static���̕ύX����
		/// </summary>
		/// <param name="sender">�ύX���錳�̃N���X�i�N���ύX���邩�j</param>
		/// <param name="customerInfo">�ύX����f�[�^�i�߂�l�Ƃ��ĕύX��̃f�[�^�j</param>
		/// <returns>STATUS[0:�X�V����,1:�X�V�����I��]</returns>
		/// <remarks>
		/// <br>Note		: Static�ȃG���A�ɏ���ݒ肵�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int WriteStaticMemoryData(object sender, CustomerInfo customerInfo)
		{
            if ((_customerDictionary == null) || (customerInfo == null))
			{
				return 1;
			}

			// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
			this.AddMainMemoryDictionary(customerInfo);

			// ���Ӑ���ύX�ʒm�𔭗߂���
			this.InstructionInfoCustomerChange(sender, false, ref customerInfo);

			return 0;
		}

		/// <summary>
		/// Static���̘_���폜����
		/// </summary>
		/// <param name="sender">�ύX���錳�̃N���X�i�N���ύX���邩�j</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:�X�V����,0�ȊO:�X�V�����I��]</returns>
		public int DeleteStaticMemoryData(object sender, string enterpriseCode, int customerCode)
		{
            CustomerInfo customerInfo;
			int status = this.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if ((_customerDictionary == null) || (customerInfo == null))
				{
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}

				// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
				this.RemoveMainMemoryTable(customerInfo);

				// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
				this.RemoveUndoMemoryTable(customerInfo);

				// ���Ӑ���폜�ʒm�𔭗߂���
				this.InstructionCustomerInfoDelete(this, true, ref customerInfo);

				return status;
			}
			else
			{
				return status;
			}
		}

        // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Static���̍폜����
        /// </summary>
        /// <returns></returns>
        public int DeleteStaticMemoryData()
        {
            if ((_customerDictionary == null) || (__customerDictionary == null))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            _customerDictionary.Clear();
            __customerDictionary.Clear();

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// Static���̎擾����
		/// </summary>
		/// <param name="customerInfo">�擾�����f�[�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:�擾����,4:StaticData���݂���]</returns>
		public int ReadStaticMemoryData(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
            // �L�[��񐶐�����
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			if (_customerDictionary == null)
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else if (_customerDictionary.ContainsKey(key))
			{
				customerInfo = (_customerDictionary[key]).Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
		}

		/// <summary>
		/// Static���̎擾����
		/// </summary>
		/// <param name="customerInfo">�擾�����f�[�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:�擾����,4:StaticData���݂���]</returns>
		public int ReadCacheMemoryData(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
            // �L�[��񐶐�����
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			if (__customerDictionary == null)
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else if (__customerDictionary.ContainsKey(key))
			{
				customerInfo = (__customerDictionary[key]).Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
		}

		/// <summary>
		/// StaticMemory���������ۑ�����
		/// </summary>
		/// <param name="mode">���[�h[0:����,1:MainStaticMemory,2:UndoStaticMemory]</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>0:����</returns>
		public int WriteInitStaticMemory(int mode, CustomerInfo customerInfo)
		{
            // ���A��static�̈�̏�����
			if (mode == 0 || mode == 1)
			{
				// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
				this.AddMainMemoryDictionary(customerInfo);
			}

			// ��static�̈�̏�����
			if (mode == 0 || mode == 2)
			{
				// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
				this.AddUndoMemoryDictionary(customerInfo);
			}

			// ���Ӑ���ύX�ʒm�𔭗߂���
			this.InstructionInfoCustomerChange(this, false, ref customerInfo);

			return 0;
		}

		/// <summary>
		/// StaticMemory�ύX�L���`�F�b�N
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>��r���� [0:��v���� 0�ȊO:��v���Ȃ�]</returns>
		public int CompareStaticMemory(string enterpriseCode, int customerCode)
		{
            // �L�[��񐶐�����
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ɊY���f�[�^�����݂��Ȃ��ꍇ�͈�v���Ȃ�
			if (!_customerDictionary.ContainsKey(key))
			{
				return 2;
			}

			// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ɊY���f�[�^�����݂��Ȃ��ꍇ�͈�v���Ȃ�
			if (!__customerDictionary.ContainsKey(key))
			{
				return 3;
			}

			CustomerInfo _customerInfo  = (_customerDictionary[key]).Clone();
			CustomerInfo __customerInfo = (__customerDictionary[key]).Clone();

			if (_customerInfo.Equals(__customerInfo))
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// StaticMemory�ύX���ډ�ʕ\�������i�f�o�b�O�p�j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>��r���� [0:��v���� 0�ȊO:��v���Ȃ�]</returns>
		public int ShowCompareStaticMemory(string enterpriseCode, int customerCode)
		{
            // �L�[��񐶐�����
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ɊY���f�[�^�����݂��Ȃ��ꍇ�͈�v���Ȃ�
			if (!_customerDictionary.ContainsKey(key))
			{
				return 2;
			}

			// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ɊY���f�[�^�����݂��Ȃ��ꍇ�͈�v���Ȃ�
			if (!__customerDictionary.ContainsKey(key))
			{
				return 3;
			}

			CustomerInfo _customerInfo  = (_customerDictionary[key]).Clone();
			CustomerInfo __customerInfo = (__customerDictionary[key]).Clone();

			if (_customerInfo.Equals(__customerInfo))
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// StaticMemory�̓��e��ʂ�StaticMemory�ɃR�s�[
		/// </summary>
		/// <param name="mode">���[�h[0:MainStaticMemory��UndoStaticMemory,1:UndoStaticMemory��MainStaticMemory]</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:����]</returns>
		public int CopyStaticMemory(int mode, string enterpriseCode, int customerCode)
		{
            // �L�[��񐶐�����
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			switch(mode)
			{
				case 0: // MainStaticMemory �� UndoStaticMemory
				{
					// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ɊY���f�[�^�����݂��Ȃ��ꍇ�͏����s�\
					if (!_customerDictionary.ContainsKey(key))
					{
						return 1;
					}

					CustomerInfo _customerInfo  = _customerDictionary[key].Clone();

					// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
					this.AddUndoMemoryDictionary(_customerInfo);

					// ���Ӑ���ύX�ʒm�𔭗߂���
					this.InstructionInfoCustomerChange(this, false, ref _customerInfo);

					break;
				}
				case 1: // UndoStaticMemory �� MainStaticMemory
				{				
					// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ɊY���f�[�^�����݂��Ȃ��ꍇ�͈�v���Ȃ�
					if (!__customerDictionary.ContainsKey(key))
					{
						return 1;
					}

					CustomerInfo __customerInfo = __customerDictionary[key].Clone();

					// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
					this.AddMainMemoryDictionary(__customerInfo);

					// ���Ӑ���ύX�ʒm�𔭗߂���
					this.InstructionInfoCustomerChange(this, false, ref __customerInfo);

					break;
				}
			}

			return 0;
		}

        // 2010/10/28 Add >>>
        /// <summary>
        /// ���Ӑ���o�b�t�@(MainMemory)�i�[�pDictionary�ǉ�����
        /// </summary>
        /// <param name="customerInfo">���Ӑ�I�u�W�F�N�g</param>
        private void AddMainMemoryDictionary(CustomerInfo customerInfo)
        {
            this.AddMainMemoryDictionary(customerInfo, true);
        }
        // 2010/10/28 Add <<<

		/// <summary>
		/// ���Ӑ���o�b�t�@(MainMemory)�i�[�pDictionary�ǉ�����
		/// </summary>
		/// <param name="customerInfo">���Ӑ�I�u�W�F�N�g</param>
        /// <param name="getMngSectionName">True:�Ǘ����_���̂��擾����</param>
        // 2010/10/28 >>>
		//private void AddMainMemoryDictionary(CustomerInfo customerInfo)
        private void AddMainMemoryDictionary(CustomerInfo customerInfo, bool getMngSectionName)
        // 2010/10/28 <<<
        {
			this.RemoveMainMemoryTable(customerInfo);

            if (getMngSectionName)   // 2010/10/28 Add
            {                       // 2010/10/28 Add
                // �Ǘ����_���̎擾
                SecInfoSet secInfoSet;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;

                if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
                {
                    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                }
            }                       // 2010/10/28 Add


			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

			_customerDictionary.Add(key, customerInfo.Clone());
		}

		/// <summary>
		/// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
		/// </summary>
		/// <param name="customerInfo">���Ӑ�I�u�W�F�N�g</param>
		private void AddUndoMemoryDictionary(CustomerInfo customerInfo)
		{
			this.RemoveUndoMemoryTable(customerInfo);

			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);
			__customerDictionary.Add(key, customerInfo.Clone());
		}

		/// <summary>
		/// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���폜����
		/// </summary>
		/// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
		private void RemoveMainMemoryTable(CustomerInfo customerInfo)
		{
			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);
			CustomerInfo customerInfoBuff = customerInfo.Clone();

			if (_customerDictionary.ContainsKey(key))
			{
				_customerDictionary.Remove(key);
			}
		}

		/// <summary>
		/// ���Ӑ���o�b�t�@(UndoMemory)�i�[�p�n�b�V���e�[�u���폜����
		/// </summary>
		/// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
		private void RemoveUndoMemoryTable(CustomerInfo customerInfo)
		{
			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);
			CustomerInfo customerInfoBuff = customerInfo.Clone();

			if (__customerDictionary.ContainsKey(key))
			{
				__customerDictionary.Remove(key);
			}
		}

		/// <summary>
		/// �L�[��񐶐�����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">����_��Ǘ��R�[�h</param>
		/// <returns>���������L�[���</returns>
		public string ConstructionKey(string enterpriseCode, int customerCode)
		{
            string key = string.Empty;
			if (customerCode == 0)
			{
				key = enterpriseCode.Trim() + "-" + this._key.ToString();
			}
			else
			{
				key = enterpriseCode.Trim() + "-" + customerCode.ToString();
			}
			return key;
		}
		# endregion

		// ===================================================================================== //
		// DB����
		// ===================================================================================== //
		# region DataBase Control
		/// <summary>
		/// DB����StaticMemory�ɍŐV�f�[�^��ݒ�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>STATUS</returns>
		public int ReadDBData(string enterpriseCode, int customerCode, out CustomerInfo customerInfo)
		{
            return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, out customerInfo);
		}

		/// <summary>
		/// DB���瓾�Ӑ�f�[�^���擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="cacheFlg">�L���b�V���t���O[true:�L���b�V������ false:�L���b�V�����Ȃ�]</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>STATUS</returns>
		public int ReadDBData(string enterpriseCode, int customerCode,  bool cacheFlg, out CustomerInfo customerInfo)
		{
            return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, out customerInfo);
		}

		/// <summary>
		/// DB���瓾�Ӑ�f�[�^���擾
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerInfo">���Ӑ���</param>
		public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, out CustomerInfo customerInfo)
		{
            return this.ReadDBData(logicalMode, enterpriseCode, customerCode, true, out customerInfo);
		}

        // 2009.02.17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region �폜
        ///// <summary>
        ///// DB���瓾�Ӑ�f�[�^���擾
        ///// </summary>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="cacheFlg">�L���b�V���t���O[true:�L���b�V������ false:�L���b�V�����Ȃ�]</param>
        ///// <param name="customerInfo">���Ӑ���</param>
        ///// <returns>STATUS</returns>
        //public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode,  bool cacheFlg, out CustomerInfo customerInfo)
        //{
        //    // ���Ӑ�f�[�^�擾�i�����[�g�e�B���O���N������j
        //    customerInfo = null;
        //    //CustSuppli custSuppli = null;
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    if (LoginInfoAcquisition.OnlineFlag)
        //    {
        //        status = this.Read(logicalMode, enterpriseCode, customerCode, out customerInfo);
        //    }
        //    else
        //    {
        //        status = this.ReadOfflineData(enterpriseCode, customerCode, out customerInfo, this);
        //    }

        //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
        //    {
        //        // �Ǘ����_���̎擾
        //        SecInfoSet secInfoSet;
        //        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
        //        secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
        //        if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
        //        {
        //            customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
        //        }

        //        // �L�[��񐶐�����
        //        string key = this.ConstructionKey(enterpriseCode, customerCode);

        //        // ���łɓ��Ӑ��񂪃L���b�V���O����Ă���ꍇ�͍X�V���̔�r���s���A��������̏ꍇ��
        //        // �ăL���b�V���O�͍s��Ȃ�
        //        if ((_customerDictionary.ContainsKey(key)) && ((_customerDictionary[key]).UpdateDateTime == customerInfo.UpdateDateTime))
        //        {
        //            customerInfo = (_customerDictionary[key]).Clone();
        //        }
        //        else
        //        {
        //            if (cacheFlg)
        //            {
        //                // ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
        //                this.AddMainMemoryDictionary(customerInfo);

        //                // ���A���X�V�ɃR�s�[��Undo�o�b�t�@
        //                this.CopyStaticMemory(0, enterpriseCode, customerCode);
        //            }
        //        }
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// ���Ӑ���ǂݍ��ݏ���(DB���ǂݍ��݂Ȃ����܂�)
        ///// </summary>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="customerInfo">���Ӑ���N���X</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private int Read( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, out CustomerInfo customerInfo )
        //{
        //    customerInfo = null;
        //    //custSuppli = null;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    // �ʏ�̓��Ӑ���擾�̏ꍇ�́A�L���b�V�����Ƃc�a���̍X�V�����r���A
        //    // �X�V��������̏ꍇ�̓L���b�V������߂��B
        //    if ( (logicalMode == ConstantManagement.LogicalMode.GetData0) && (LoginInfoAcquisition.OnlineFlag) )
        //    {
        //        CustomerInfo customerInfoBuff;
        //        //CustSuppli custSuppliBuff;
        //        status = this.ReadStaticMemoryData( out customerInfoBuff, enterpriseCode, customerCode );

        //        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
        //        {
        //            if ( _isLocalDBRead )
        //            {
        //                //  �X�V���ύX�`�F�b�N����
        //                if ( !(this._customerInfoLcDB.IsUpdateDateTimeChange( customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode )) )
        //                {
        //                    if ( customerInfoBuff != null )
        //                    {
        //                        customerInfo = customerInfoBuff.Clone();
        //                    }
        //                    return status;
        //                }
        //            }
        //            else
        //            {
        //                //  �X�V���ύX�`�F�b�N����
        //                if ( !(this._iCustomerInfoDB.IsUpdateDateTimeChange( customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode )) )
        //                {
        //                    if ( customerInfoBuff != null )
        //                    {
        //                        customerInfo = customerInfoBuff.Clone();
        //                    }
        //                    return status;
        //                }
        //            }
        //        }
        //    }

        //    // ���Ӑ�}�X�^�p�����[�^�ݒ�
        //    CustomerWork customerWork = new CustomerWork();
        //    customerWork.EnterpriseCode = enterpriseCode;
        //    customerWork.CustomerCode = customerCode;

        //    // CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
        //    CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
        //    paraCustomerArray.Add( customerWork );

        //    object paraList = paraCustomerArray;

        //    //���Ӑ�ǂݍ���
        //    status = this._iCustomerInfoDB.Read( logicalMode, ref paraList );

        //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
        //    {
        //        customerInfo = null;

        //        CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
        //        foreach ( object obj in retCustomerArrayList )
        //        {
        //            if ( obj is CustomerWork )
        //            {
        //                customerWork = (CustomerWork)obj;

        //                // �N���X�������o�R�s�[
        //                customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork( customerWork );

        //                // �e�}�X�^���̐ݒ�
        //                ReflectDisplayName( ref customerInfo );

        //                // �\�����̐ݒ菈��
        //                this.SetDspName( ref customerInfo );
        //            }
        //        }
        //    }

        //    return status;
        //}
        #endregion

        /// <summary>
        /// DB���瓾�Ӑ�f�[�^���擾
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="cacheFlg">�L���b�V���t���O[true:�L���b�V������ false:�L���b�V�����Ȃ�]</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <returns>STATUS</returns>
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, bool cacheFlg, out CustomerInfo customerInfo)
        {
            return this.ReadDBData(logicalMode, enterpriseCode, customerCode, cacheFlg, true, out customerInfo);
        }
            
        /// <summary>
        /// DB���瓾�Ӑ�f�[�^���擾
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="cacheFlg">�L���b�V���t���O[true:�L���b�V������ false:�L���b�V�����Ȃ�]</param>
        /// <param name="isSettingName">���̐ݒ�敪(ture:�ݒ肠�� false:�ݒ薳��)</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <returns></returns>
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, bool cacheFlg, bool isSettingName, out CustomerInfo customerInfo)
        {
            // ���Ӑ�f�[�^�擾�i�����[�g�e�B���O���N������j
            customerInfo = null;
            //CustSuppli custSuppli = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = this.Read(logicalMode, enterpriseCode, customerCode, isSettingName, out customerInfo);
            //}
            //else
            //{
            //    status = this.ReadOfflineData(enterpriseCode, customerCode, isSettingName, out customerInfo, this);
            //}

            status = this.Read(logicalMode, enterpriseCode, customerCode, isSettingName, out customerInfo);
            // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
            {
                if (isSettingName)
                {
                    // 2010/10/28 Del �Ǘ����_���̂́A�����[�g��JOIN����̂ō폜 >>>
                    //// �Ǘ����_���̎擾
                    //SecInfoSet secInfoSet;
                    //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    //secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                    //if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
                    //{
                    //    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                    //}
                    // 2010/10/28 Del <<<
                }

                // �L�[��񐶐�����
                string key = this.ConstructionKey(enterpriseCode, customerCode);

                // ���łɓ��Ӑ��񂪃L���b�V���O����Ă���ꍇ�͍X�V���̔�r���s���A��������̏ꍇ��
                // �ăL���b�V���O�͍s��Ȃ�
                if ((_customerDictionary.ContainsKey(key)) && ((_customerDictionary[key]).UpdateDateTime == customerInfo.UpdateDateTime))
                {
                    customerInfo = (_customerDictionary[key]).Clone();
                }
                else
                {
                    if (cacheFlg)
                    {
                        // ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
                        // 2010/10/28 >>>
                        //this.AddMainMemoryDictionary(customerInfo);
                        this.AddMainMemoryDictionary(customerInfo, false);
                        // 2010/10/28 <<<

                        // ���A���X�V�ɃR�s�[��Undo�o�b�t�@
                        this.CopyStaticMemory(0, enterpriseCode, customerCode);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ���Ӑ���ǂݍ��ݏ���(DB���ǂݍ��݂Ȃ����܂�)
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="isSettingName">���̐ݒ�敪(ture:�ݒ肠�� false:�ݒ薳��)</param>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <returns></returns>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              ���Ӑ�}�X�^��Q���ǑΉ�</br>
        private int Read(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, bool isSettingName, out CustomerInfo customerInfo)
        {
            customerInfo = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �ʏ�̓��Ӑ���擾�̏ꍇ�́A�L���b�V�����Ƃc�a���̍X�V�����r���A
            // �X�V��������̏ꍇ�̓L���b�V������߂��B
            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) && (LoginInfoAcquisition.OnlineFlag)) // 2009/07/30
            if (logicalMode == ConstantManagement.LogicalMode.GetData0) // 2009/07/30
            {
                CustomerInfo customerInfoBuff;
                status = this.ReadStaticMemoryData(out customerInfoBuff, enterpriseCode, customerCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (_isLocalDBRead)
                    {
                        //  �X�V���ύX�`�F�b�N����
                        if (!(this._customerInfoLcDB.IsUpdateDateTimeChange(customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode)))
                        {
                            if (customerInfoBuff != null)
                            {
                                customerInfo = customerInfoBuff.Clone();
                            }
                            return status;
                        }
                    }
                    else
                    {
                        //  �X�V���ύX�`�F�b�N����
                        if (!(this._iCustomerInfoDB.IsUpdateDateTimeChange(customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode)))
                        {
                            if (customerInfoBuff != null)
                            {
                                customerInfo = customerInfoBuff.Clone();
                            }
                            return status;
                        }
                    }
                }
            }

            // ���Ӑ�}�X�^�p�����[�^�ݒ�
            CustomerWork customerWork = new CustomerWork();
            customerWork.EnterpriseCode = enterpriseCode;
            customerWork.CustomerCode = customerCode;

            // CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
            CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
            paraCustomerArray.Add(customerWork);

            object paraList = paraCustomerArray;

            // UPD �� K2014/02/06 -------------------------------------------------->>>>>
            //���Ӑ�ǂݍ���
            // UPD ���J�M�m 2021/05/10 -------------------------------------------------->>>>>
            //if (_opt_Maehashi == (int)Option.ON)
            //{
            // UPD ���J�M�m 2021/05/10 --------------------------------------------------<<<<<
                status = this._iCustomerInfoDB.MaehashiRead(logicalMode, ref paraList);
            // UPD ���J�M�m 2021/05/10 -------------------------------------------------->>>>>
            //}
            //else
            //{
                //status = this._iCustomerInfoDB.Read(logicalMode, ref paraList);
            //}
                // UPD ���J�M�m 2021/05/10 --------------------------------------------------<<<<<
            // UPD �� K2014/02/06 --------------------------------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                customerInfo = null;

                CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
                foreach (object obj in retCustomerArrayList)
                {
                    if (obj is CustomerWork)
                    {
                        customerWork = (CustomerWork)obj;

                        // 2010/10/28 Del >>>
                        //// --- ADD 2010/08/10 ------------------------------------>>>>>
                        //UserGdBd userGdBd = null;
                        //UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                        //int statusFlag1 = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 33, customerWork.BusinessTypeCode, ref acsDataType);
                        //if ((statusFlag1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd != null && userGdBd.LogicalDeleteCode != 0) || statusFlag1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    customerWork.BusinessTypeName = string.Empty;
                        //}

                        //int statusFlag2 = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 34, customerWork.JobTypeCode, ref acsDataType);
                        //if ((statusFlag2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd != null && userGdBd.LogicalDeleteCode != 0) || statusFlag2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    customerWork.JobTypeName = string.Empty;
                        //}

                        //int statusFlag3 = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 21, customerWork.SalesAreaCode, ref acsDataType);
                        //if ((statusFlag3 == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd != null && userGdBd.LogicalDeleteCode != 0) || statusFlag3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    customerWork.SalesAreaName = string.Empty;
                        //}
                        //// --- ADD 2010/08/10 ------------------------------------<<<<<
                        // 2010/10/28 Del <<<

                        // �N���X�������o�R�s�[
                        customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                        if (isSettingName)
                        {
                            // �e�}�X�^���̐ݒ�
                            ReflectDisplayName(ref customerInfo);

                            // �\�����̐ݒ菈��
                            this.SetDspName(ref customerInfo);
                        }
                    }
                }
            }

            return status;
        }
        // 2009.02.17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �e�}�X�^���̓K�p����
        /// </summary>
        /// <param name="customerInfo"></param>
        private void ReflectDisplayName( ref CustomerInfo customerInfo )
        {
            //-------------------------------------------------
            // �Ǘ����_���̎擾
            //-------------------------------------------------
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            SecInfoSet secInfoSet;
            _secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
            if ( _secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode.TrimEnd() ) == 0 )
            {
                customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
            }

            //-------------------------------------------------
            // �W���S���Җ��̎擾
            //-------------------------------------------------
            if ( _employeeAcs == null )
            {
                _employeeAcs = new EmployeeAcs();
            }
            Employee employee;
            _employeeAcs.IsLocalDBRead = _isLocalDBRead;
            if ( _employeeAcs.Read( out employee, this._enterpriseCode, customerInfo.BillCollecterCd.TrimEnd() ) == 0 )
            {
                customerInfo.BillCollecterNm = employee.Name;
            }
        }
        private SecInfoSetAcs _secInfoSetAcs;
        private EmployeeAcs _employeeAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// StaticMemory�̓��e���c�a�ɏ�������
		/// </summary>
		/// <param name="sender">�������ݎw�߂𔭍s�����N���X</param>
		/// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <param name="duplicationItemList">�G���[���b�Z�[�W�N���X</param>
		/// <returns>STATUS</returns>
		public int WriteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo, out ArrayList duplicationItemList)
		{
            return this.WriteDBData(sender, forceEvent, ref customerInfo, out duplicationItemList, 0);
		}

		/// <summary>
		/// StaticMemory�̓��e���c�a�ɏ�������
		/// </summary>
		/// <param name="sender">�������ݎw�߂𔭍s�����N���X</param>
		/// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <param name="duplicationItemList">�G���[���b�Z�[�W�N���X</param>
		/// <param name="carMngNo">���Ӑ�Ǝ��q�𓯎��o�^����ۂ̎��q�Ǘ��ԍ�</param>
		/// <returns>STATUS</returns>
		public int WriteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo, out ArrayList duplicationItemList, int carMngNo)
		{
            int status;

			ArrayList dupList = new ArrayList();
			duplicationItemList = new ArrayList();

			CustomerInfo _customerInfo = null;
			CustomerInfo __customerInfo = null;

			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

			if (_customerDictionary.ContainsKey(key))
			{
				_customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();
			}
			else
			{
				return -1;
			}

			if (__customerDictionary.ContainsKey(key))
			{
				__customerInfo = __customerDictionary[key].Clone();
			}

			status = this.Write(ref _customerInfo, out dupList, carMngNo);

			if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
				this.AddMainMemoryDictionary(_customerInfo);

				// ���A���X�V�ɃR�s�[��Undo�o�b�t�@�i���Ӑ���ύX�ʒm�j
				this.CopyStaticMemory(0, _customerInfo.EnterpriseCode, _customerInfo.CustomerCode);

				customerInfo = _customerInfo.Clone();
			}
			
			if (dupList.Count > 0 )
			{
				foreach(string strItem in dupList)
				{
					duplicationItemList.Add(strItem);
				}
			}
			return status;
		}

		/// <summary>
		/// �����̓��Ӑ�����c�a�ɏ�������
		/// </summary>
		/// <param name="customerInfo">���Ӑ���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note�@	  : �����̓��Ӑ����DB�ɏ������ށi�f�[�^�̃`�F�b�N�͍s��Ȃ��̂ŕK����Ƀ`�F�b�N���s���Ă������Ɓj</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int WriteDBData(ref CustomerInfo customerInfo)
		{
            int status;
			ArrayList dupList;

			status = this.Write(ref customerInfo, out dupList, 0);
			return status;
		}

		/// <summary>
		/// ���Ӑ�o�^�E�X�V����
		/// </summary>
		/// <param name="customerInfo">���Ӑ�N���X</param>
		/// <param name="duplicationItemList">�d���G���[���̃G���[����</param>
		/// <param name="carMngNo">���Ӑ�Ǝ��q�𓯎��o�^����ۂ̎��q�Ǘ��ԍ�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int Write(ref CustomerInfo customerInfo,  out ArrayList duplicationItemList, int carMngNo)
		{
			duplicationItemList = new ArrayList();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
            int targetCustomerCode = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

			try
			{
				// �d���G���[��񃊃X�g���N���A
				duplicationItemList.Clear();

				// ���Ӑ�N���X���瓾�Ӑ惏�[�J�[�N���X�Ƀ����o�R�s�[
				CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

                // CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
                CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                //paraCustomerArray.Add( customerWork );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD

                if ( customerWork.CustomerCode == customerWork.ClaimCode )
                {
                    //---------------------------------------------------
                    // �e���Ӑ恨�e�ƑS�Ă̎q���X�V
                    //---------------------------------------------------
                    # region [�e���Ӑ�]
                    Dictionary<int, CustomerWork> customerDic = new Dictionary<int, CustomerWork>();
                    ArrayList searchParaList = new ArrayList();
                    searchParaList.Add( customerWork );
                    object searchObj = searchParaList;

                    // ���Ӑ恨�e�ƑS�Ă̎q����
                    int searchStatus = this._iCustomerInfoDB.Search( ConstantManagement.LogicalMode.GetDataAll, ref searchObj );
                    //if ( searchObj == null || (searchObj is ArrayList) == false || (searchObj as ArrayList).Count == 0 )
                    //{
                    //    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    //}
                    searchParaList = (ArrayList)searchObj;


                    // �e���Ӑ���i�[
                    paraCustomerArray.Add( customerWork );
                    customerDic.Add( customerWork.CustomerCode, customerWork );
                    targetCustomerCode = customerWork.CustomerCode;


                    // �e���S�Ă̎q��������
                    //foreach ( CustomerWork childCustomer in searchParaList )
                    for ( int index = 0; index < searchParaList.Count; index++ )
                    {
                        CustomerWork childCustomer = (CustomerWork)searchParaList[index];

                        if ( childCustomer.CustomerCode == customerWork.CustomerCode )
                        {
                            continue;
                        }
                        else
                        {
                            if ( !customerDic.ContainsKey( childCustomer.CustomerCode ) )
                            {
                                // �q���e�̏���copy
                                ReflectChildCustomerFromParent( ref childCustomer, customerWork );

                                // CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
                                paraCustomerArray.Add( childCustomer );
                                customerDic.Add( childCustomer.CustomerCode, childCustomer );
                            }
                        }
                    }
                    # endregion
                }
                else
                {
                    //---------------------------------------------------
                    // �q���Ӑ恨�q�̂ݍX�V
                    //---------------------------------------------------
                    # region [�q���Ӑ�]
                    // CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
                    paraCustomerArray.Add( customerWork );
                    # endregion
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

                object paraList = paraCustomerArray;

                // UPD �� K2014/02/06 ------------------------------------------------------------------->>>>>
				// ���Ӑ揑������
                int status;
                // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
                //if (_opt_Maehashi == (int)Option.ON)
                //{
                // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
                    status = this._iCustomerInfoDB.MaehashiWrite(ref paraList, out duplicationItemList, carMngNo);
                // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
                //}
                //else
                //{
                //    status = this._iCustomerInfoDB.Write(ref paraList, out duplicationItemList, carMngNo);
                //}
                // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
                // UPD �� K2014/02/06 -------------------------------------------------------------------<<<<<

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
					foreach(object obj in retCustomerArrayList)
					{
						if(obj is CustomerWork)
						{
    						customerWork = (CustomerWork)obj;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                            if ( customerWork.CustomerCode != targetCustomerCode ) continue;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

							// �N���X�������o�R�s�[
							customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                            // �e�}�X�^���̐ݒ�
                            ReflectDisplayName( ref customerInfo );

							// �\�����̐ݒ菈��
							this.SetDspName(ref customerInfo);
						}
					}
				}
				return status;
			}
			catch (Exception e)
			{
				// ���O�f���o��
				System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
				eventLog.Source = "Customer Write";
				eventLog.WriteEntry("���Ӑ���̓o�^�Ɏ��s���܂����B" + "\r\n" + this.ToString() + "\r\n" + e.Message,
					System.Diagnostics.EventLogEntryType.Error,
					1);

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
        /// <summary>
        /// �e���Ӑ���Ɋ�Â��q���Ӑ���̍X�V
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        private void ReflectChildCustomerFromParent( ref CustomerWork child, CustomerWork parent )
        {
            child.TotalDay = parent.TotalDay; // ����
            child.CollectMoneyCode = parent.CollectMoneyCode; // �W�����敪�R�[�h
            child.CollectMoneyName = parent.CollectMoneyName; // �W�����敪����
            child.CollectMoneyDay = parent.CollectMoneyDay; // �W����
            child.CollectCond = parent.CollectCond; // �������
            child.CollectSight = parent.CollectSight; // ����T�C�g
            child.NTimeCalcStDate = parent.NTimeCalcStDate; // ���񊨒�J�n��
            child.CustCTaXLayRefCd = parent.CustCTaXLayRefCd; // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            child.ConsTaxLayMethod = parent.ConsTaxLayMethod; // ����œ]�ŕ���
            child.CreditMngCode = parent.CreditMngCode; // �^�M�Ǘ��敪
            child.DepoDelCode = parent.DepoDelCode; // ���������敪
            child.SalesCnsTaxFrcProcCd = parent.SalesCnsTaxFrcProcCd; // �������Œ[�������R�[�h
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

		/// <summary>
		/// ���Ӑ�}�X�^�_���폜����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="carDeleteFlg">���q�폜�t���O</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: �����̊�ƃR�[�h�A���Ӑ�R�[�h�ɊY�����链�Ӑ�𓾈Ӑ�}�X�^����_���폜���܂��B
		///					�@���q�폜�t���O��true�̏ꍇ�́A���q�������ɍ폜���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int LogicalDeleteDBData(string enterpriseCode, int customerCode, bool carDeleteFlg)
		{
            int status;

			if ((enterpriseCode.Trim() == "") || (customerCode == 0)) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			string key = this.ConstructionKey(enterpriseCode, customerCode);
			CustomerInfo customerInfo;

			if (!_customerDictionary.ContainsKey(key))
			{
				status = this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, out customerInfo);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
			}
			else
			{
				customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();
			}

			status = this.LogicalDelete(ref customerInfo, carDeleteFlg);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				customerInfo = customerInfo.Clone();

				// Hashtable����f�[�^���L���b�V�������폜����
				if (_customerDictionary.ContainsKey(key))
				{
					_customerDictionary.Remove(key);
				}

				if (__customerDictionary.ContainsKey(key))
				{
					__customerDictionary.Remove(key);
				}

				// ���Ӑ�폜�ʒm�𔭗߂���
				this.InstructionInfoDeleteCustomerInfo(this, false, ref customerInfo);
			}
			return status;
		}

		/// <summary>
		/// StaticMemory�̓��e���c�a����폜�i�_���폜�j
		/// </summary>
		/// <param name="sender">�������ݎw�߂𔭍s�����N���X</param>
		/// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <param name="carDeleteFlg">���q�폜�t���O</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: StaticMemory�̓��e����̃f�[�^���c�a����_���폜���܂��B
		///					�@���q�폜�t���O��true�̏ꍇ�́A���q�������ɍ폜���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int LogicalDeleteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo, bool carDeleteFlg)
		{
            int status;

			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

			if (!_customerDictionary.ContainsKey(key))
			{
				return 1;
			}

			CustomerInfo _customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();

			status = this.LogicalDelete(ref _customerInfo, carDeleteFlg);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				customerInfo = _customerInfo.Clone();

				// Hashtable����f�[�^���L���b�V�������폜����
				_customerDictionary.Remove(key);

				if (__customerDictionary.ContainsKey(key))
				{
					__customerDictionary.Remove(key);
				}

				// ���Ӑ�폜�ʒm�𔭗߂���
				this.InstructionInfoDeleteCustomerInfo(this, forceEvent, ref customerInfo);
			}
			return status;
		}

		/// <summary>
		/// ���Ӑ�_���폜����
		/// </summary>
		/// <param name="customerInfo">���Ӑ�I�u�W�F�N�g</param>
		/// <param name="carDeleteFlg">���q�폜�t���O</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ���̘_���폜���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int LogicalDelete(ref CustomerInfo customerInfo, bool carDeleteFlg)
		{
			try
			{
				// ���Ӑ�N���X���瓾�Ӑ惏�[�J�[�N���X�Ƀ����o�R�s�[
				CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

				// CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
				CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
				paraCustomerArray.Add(customerWork);

				object paraList = paraCustomerArray;

                // UPD �� K2014/02/06 ------------------------------------------------------------------->>>>>
                int status;
				// ���Ӑ���_���폜
                // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
                //if (_opt_Maehashi == (int)Option.ON)
                //{
                // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
                    status = this._iCustomerInfoDB.MaehashiLogicalDelete(ref paraList, carDeleteFlg);
                // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
                //}
                //else
                //{
                //    status = this._iCustomerInfoDB.LogicalDelete(ref paraList, carDeleteFlg);
                //}
                // UPD �� K2014/02/06 -------------------------------------------------------------------<<<<<
                // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
						foreach(object obj in retCustomerArrayList)
						{
							if(obj is CustomerWork)
							{
								customerWork = (CustomerWork)obj;

								// �N���X�������o�R�s�[
								customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                                // �e�}�X�^���̐ݒ�
                                ReflectDisplayName( ref customerInfo );

								// �\�����̐ݒ菈��
								this.SetDspName(ref customerInfo);
							}
						}
					}
				}

				return status;
			}
			catch (Exception e)
			{
				// ���O�f���o��
				System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
				eventLog.Source = "Customer LogicalDelete";
				eventLog.WriteEntry("���Ӑ���̘_���폜�Ɏ��s���܂����B" + "\r\n" + this.ToString() + "\r\n" + e.Message,
					System.Diagnostics.EventLogEntryType.Error, 1, 0);

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// ���Ӑ�}�X�^�폜�`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^�̍폜�`�F�b�N�������s���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
		{
            CustomerInfo customerInfo;
			int status = this.ReadDBData(enterpriseCode, customerCode, true, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				bool showDialog = false;
				string name = string.Empty;

				if (showDialog)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						"PMKHN09012A",
						"�폜�Ώۓ��Ӑ�́u" + name + "�v�ł��B" + "\r\n" + "�폜���Ă���낵���ł����H",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult != DialogResult.Yes)
					{
						checkFlg = false;
						message = string.Empty;
						return -1;
					}
				}
			}

			checkFlg = true;
			message = string.Empty;

			try
			{
				// ���Ӑ�폜�`�F�b�N����
				return this._iCustomerInfoDB.DeleteCheck(enterpriseCode, customerCode, out message, out checkFlg);
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					"PMKHN09012A",
					"���Ӑ���̍폜�`�F�b�N�Ɏ��s���܂����B" + "\r\n" + this.ToString() + "\r\n" + e.Message,
					(int)ConstantManagement.DB_Status.ctDB_ERROR,
					e,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// StaticMemory�̓��e���c�a����폜�i���S�폜�j
        /// </summary>
        /// <param name="sender">�������ݎw�߂𔭍s�����N���X</param>
        /// <param name="forceEvent">true:�������g�ɂ��C�x���g�𔭐�������,false:�������g�ɂ̓C�x���g�𔭐������Ȃ�</param>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: StaticMemory�̓��e����̃f�[�^���c�a����_���폜���܂��B</br>
        /// <br>Programmer : 30452 ���r��</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        public int CompleteDeleteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo)
        {
            int status;

            string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

            if (!_customerDictionary.ContainsKey(key))
            {
                return 1;
            }

            CustomerInfo _customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();

            status = this.CompleteDelete(ref _customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                customerInfo = _customerInfo.Clone();

                // Hashtable����f�[�^���L���b�V�������폜����
                _customerDictionary.Remove(key);

                if (__customerDictionary.ContainsKey(key))
                {
                    __customerDictionary.Remove(key);
                }

                // ���Ӑ�폜�ʒm�𔭗߂���
                this.InstructionInfoDeleteCustomerInfo(this, forceEvent, ref customerInfo);
            }
            return status;
        }

        /// <summary>
        /// ���Ӑ�폜����(���S�폜)
        /// </summary>
        /// <param name="customerInfo">���Ӑ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���̊��S�폜���s���܂��B</br>
        /// <br>Programmer : 30452 ���r��</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private int CompleteDelete(ref CustomerInfo customerInfo)
        {
            try
            {
                // ���Ӑ�N���X���瓾�Ӑ惏�[�J�[�N���X�Ƀ����o�R�s�[
                CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

                // CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
                CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
                paraCustomerArray.Add(customerWork);

                object paraList = paraCustomerArray;

                // ���Ӑ���_���폜
                // UPD �� K2014/02/06 ------------------------------------------------------------------->>>>>
                int status;
                // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
                //if (_opt_Maehashi == (int)Option.ON)
                //{
                // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
                    status = this._iCustomerInfoDB.MaehashiDelete(ref paraList);
                // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
                //}
                //else
                //{
                //    status = this._iCustomerInfoDB.Delete(ref paraList);
                //}
                // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
                // UPD �� K2014/02/06 -------------------------------------------------------------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
                    foreach (object obj in retCustomerArrayList)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = (CustomerWork)obj;

                            // �N���X�������o�R�s�[
                            customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                            // �e�}�X�^���̐ݒ�
                            ReflectDisplayName( ref customerInfo );

                            // �\�����̐ݒ菈��
                            this.SetDspName(ref customerInfo);
                        }
                    }
                }

                return status;
            }
            catch (Exception e)
            {
                // ���O�f���o��
                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                eventLog.Source = "Customer LogicalDelete";
                eventLog.WriteEntry("���Ӑ���̊��S�폜�Ɏ��s���܂����B" + "\r\n" + this.ToString() + "\r\n" + e.Message,
                    System.Diagnostics.EventLogEntryType.Error, 1, 0);

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^���S�폜�`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̊��S�폜�`�F�b�N�������s���܂�</br>
        /// <br>Programmer : 30452 ���r��</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        public int CompleteDeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
        {
            CustomerInfo customerInfo;

            // ���S�폜�ΏۂɂȂ�̂͘_���폜�s�̂�
            int status = this.ReadDBData(ConstantManagement.LogicalMode.GetData1, enterpriseCode, customerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                bool showDialog = false;
                string name = string.Empty;

                if (showDialog)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        "PMKHN09012A",
                        "�폜�Ώۓ��Ӑ�́u" + name + "�v�ł��B" + "\r\n" + "�폜���Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes)
                    {
                        checkFlg = false;
                        message = string.Empty;
                        return -1;
                    }
                }
            }

            // ���S�폜�̏ꍇ��DeleteCheck���Ă΂Ȃ��ėǂ��B
            checkFlg = true;
            message = string.Empty;

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		/// <summary>
		/// ���Ӑ�}�X�^��������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: �����̊�ƃR�[�h�A���Ӑ�R�[�h�ɊY�����链�Ӑ�𓾈Ӑ�}�X�^���畜�����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int RevivalDBData(string enterpriseCode, int customerCode)
		{
            int status;

			if ((enterpriseCode.Trim() == "") || (customerCode == 0)) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // UPD �� K2014/02/06 ------------------------------------------------------------------->>>>>
            // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
            //if (_opt_Maehashi == (int)Option.ON)
            //{
            // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
                status = this._iCustomerInfoDB.MaehashiRevivalLogicalDelete(enterpriseCode, customerCode);
            // DEL ���J�M�m 2021/05/10 ------------------------------------------------------------------->>>>>
            //}
            //else
            //{
            //    status = this._iCustomerInfoDB.RevivalLogicalDelete(enterpriseCode, customerCode);
            //}
            // DEL ���J�M�m 2021/05/10 -------------------------------------------------------------------<<<<<
            // UPD �� K2014/02/06 -------------------------------------------------------------------<<<<<

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				string key = this.ConstructionKey(enterpriseCode, customerCode);

				// Hashtable����f�[�^���L���b�V�������폜����
				if (_customerDictionary.ContainsKey(key))
				{
					_customerDictionary.Remove(key);
				}

				if (__customerDictionary.ContainsKey(key))
				{
					__customerDictionary.Remove(key);
				}
			}
			return status;
		}

		/// <summary>
		/// ���Ӑ於�̎擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCodeArray">���Ӑ�R�[�h�z��</param>
		/// <param name="nameTable">����Hashtable</param>
		/// <param name="name2Table">����2Hashtable</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h�𕡐��w�肵�A���̂Ɩ��̂Q��Hashtable�Ŏ擾���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int GetName(string enterpriseCode, int[] customerCodeArray, out Hashtable nameTable, out Hashtable name2Table)
		{
            if (_isLocalDBRead)
            {
                return this._customerInfoLcDB.GetName(enterpriseCode, customerCodeArray, out nameTable, out name2Table);
            }
            else
            {
                return this._iCustomerInfoDB.GetName(enterpriseCode, customerCodeArray, out nameTable, out name2Table);
            }
        }
		# endregion

		// ===================================================================================== //
		// �I�t���C���f�[�^����
		// ===================================================================================== //
		# region Offline Data Control
		/// <summary>
		/// �I�t���C���f�[�^�ۑ�����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int WriteOfflineData(string enterpriseCode, int customerCode, object sender)
		{
            CustomerInfo customerInfo;
			int status = this.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);

			// Static�̈�ɓ��Ӑ��񂪑��݂��Ȃ��ꍇ�͍ēx�擾
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				status = this.ReadDBData(enterpriseCode, customerCode, out customerInfo);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// ���Ӑ�N���X���瓾�Ӑ惏�[�J�[�N���X�Ƀ����o�R�s�[
				CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

				// CustomeSerializeArrayList�Ƀp�����[�^��ݒ�
				CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
				paraCustomerArray.Add(customerWork);

				// �I�t���C���f�[�^�ۑ�����
				status = this.WriteOfflineData(paraCustomerArray, sender);
			}

			return status;
		}

		/// <summary>
		/// �I�t���C���f�[�^�ۑ�����
		/// </summary>
		/// <param name="customSerializeArrayList">�J�X�^���V���A���C�YArrayList</param>
		/// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int WriteOfflineData(CustomSerializeArrayList customSerializeArrayList, object sender)
		{
            CustomerWork customerWork;
            //CusCarNoteWork cusCarNoteWork;
            //ArrayList familyWorkList;
            this.DivisionCustomSerializeArrayList( customSerializeArrayList, out customerWork );

			if (customerWork == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// ���Ӑ�I�t���C����񎯕ʎq�擾����
			string identifier = GetOfflineDataIdentifier(customerWork.EnterpriseCode, customerWork.CustomerCode);

			if (identifier == "") return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// ���Ӑ惍�[�J���C���f�b�N�XKeyList�ݒ�
			string[] keys = new string[2];
			keys[0] = customerWork.EnterpriseCode;
			keys[1] = customerWork.CustomerCode.ToString();

			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

			return offlineDataSerializer.Serialize(identifier, keys, customSerializeArrayList);
		}

        // 2009.02.17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �I�t���C���f�[�^�Ǎ�����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="customerInfo">���Ӑ���N���X</param>
        ///// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        ///// <returns>STATUS</returns>
        //public int ReadOfflineData(string enterpriseCode, int customerCode, out CustomerInfo customerInfo, object sender)
        /// <summary>
        /// �I�t���C���f�[�^�Ǎ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="isSettingName">���̐ݒ�敪(ture:�ݒ肠�� false:�ݒ薳��)</param>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <returns></returns>
        public int ReadOfflineData(string enterpriseCode, int customerCode, bool isSettingName, out CustomerInfo customerInfo, object sender)
        // 2009.02.17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            CustomSerializeArrayList retCustomerArrayList;
			customerInfo = null;

			// �I�t���C���f�[�^�Ǎ�����
			int status = this.ReadOfflineData(enterpriseCode, customerCode, out retCustomerArrayList, sender);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (object obj in retCustomerArrayList)
				{
					if (obj is CustomerWork)
					{
						CustomerWork customerWork = (CustomerWork)obj;

						// �N���X�������o�R�s�[
						customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                        // 2009.02.17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// �e�}�X�^���̐ݒ�
                        //ReflectDisplayName(ref customerInfo);

                        //// �\�����̐ݒ菈��
                        //this.SetDspName(ref customerInfo);
                        if (isSettingName)
                        {
                            // �e�}�X�^���̐ݒ�
                            ReflectDisplayName(ref customerInfo);

                            // �\�����̐ݒ菈��
                            this.SetDspName(ref customerInfo);
                        }
                        // 2009.02.17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
				}
			}

			return status;
		}

		/// <summary>
		/// �I�t���C���f�[�^�Ǎ�����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customSerializeArrayList">�J�X�^���V���A���C�YArrayList</param>
		/// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int ReadOfflineData(string enterpriseCode, int customerCode, out CustomSerializeArrayList customSerializeArrayList, object sender)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			customSerializeArrayList = null;

			// ���Ӑ�I�t���C����񎯕ʎq�擾����
			string identifier = GetOfflineDataIdentifier(enterpriseCode, customerCode);

			if (identifier == "") return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// ���Ӑ惍�[�J���C���f�b�N�XKeyList�ݒ�
			string[] keys = new string[2];
			keys[0] = enterpriseCode;
			keys[1] = customerCode.ToString();

			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			object retObject = offlineDataSerializer.DeSerialize(identifier, keys);

			customSerializeArrayList = retObject as CustomSerializeArrayList;

			if ((customSerializeArrayList == null) || (customSerializeArrayList.Count == 0))
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else
			{
				CustomerWork customerWork;
                this.DivisionCustomSerializeArrayList( customSerializeArrayList, out customerWork );

				if (customerWork == null)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}

			return status;
		}

		/// <summary>
		/// �I�t���C���f�[�^�폜����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int DeleteOfflineData(string enterpriseCode, int customerCode, object sender)
		{
            // ���Ӑ�I�t���C����񎯕ʎq�擾����
			string identifier = GetOfflineDataIdentifier(enterpriseCode, customerCode);

			if (identifier == "") return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// ���Ӑ惍�[�J���C���f�b�N�XKeyList�ݒ�
			string[] keys = new string[2];
			keys[0] = enterpriseCode;
			keys[1] = customerCode.ToString();

			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			return offlineDataSerializer.Delete(identifier, keys);
		}

		/// <summary>
		/// ���Ӑ�I�t���C����񎯕ʎq�擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�Ǘ��ԍ�</param>
		/// <returns>���Ӑ�I�t���C����񎯕ʎq</returns>
		public static string GetOfflineDataIdentifier(string enterpriseCode, int customerCode)
		{
            if ((enterpriseCode == "") || (customerCode == 0))
			{
				return string.Empty;
			}

			return OFFLINE_DATA_IDENTIFIER + enterpriseCode + "-" + customerCode;
		}

		/// <summary>
		/// CustomSerializeArrayList��������
		/// </summary>
		/// <param name="paraList">�J�X�^���V���A���C�Y���X�g</param>
		/// <param name="customerWork">���Ӑ�}�X�^���[�N�N���X�z��</param>
		private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out CustomerWork customerWork)
		{
			customerWork = null;

			for (int i = 0; i < paraList.Count; i++)
			{
				if (paraList[i] is CustomerWork)
				{
					customerWork = (CustomerWork)paraList[i];
				}
			}
		}
		# endregion

		// ===================================================================================== //
		// ���̑� �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region ���Ӑ�N���X�����̓f�[�^�`�F�b�N����
		/// <summary>
		/// ���Ӑ�N���X�����̓f�[�^�`�F�b�N����
		/// </summary>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <param name="messageList">���b�Z�[�W���X�g</param>
		/// <param name="itemList">�A�C�e�����X�g</param>
		/// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
		public bool CustomerInputDataCheck(CustomerInfo customerInfo, out ArrayList messageList, out ArrayList itemList)
		{
            messageList = new ArrayList();
			itemList = new ArrayList();

            if ( customerInfo.CustomerCode == 0 )
            {
                messageList.Add( "���Ӑ�R�[�h" );
                itemList.Add( "CustomerCode" );
            }
            // DEL 2009/06/26 ------>>>
            //if (customerInfo.Name.Trim() == "")
            //{
            //    messageList.Add("���Ӑ於");
            //    itemList.Add("Name");
            //}
            // DEL 2009/06/26 ------<<<
            
            // �[����łȂ��ꍇ�`�F�b�N���鍀��
            if ( !customerInfo.IsReceiver )
            {
                // DEL 2009/06/26 ------>>>
                //if ( customerInfo.CustomerSnm.Trim() == "" )
                //{
                //    messageList.Add( "���Ӑ旪��" );
                //    itemList.Add( "CustomerSnm" );
                //}
                // DEL 2009/06/26 ------<<<
                if (customerInfo.Kana.Trim() == "")
                {
                    messageList.Add( "���Ӑ�(��)" );
                    itemList.Add( "Kana" );
                }
                if ( customerInfo.MngSectionCode == "" )
                {
                    messageList.Add( "�Ǘ����_" );
                    itemList.Add( "MngSectionCode" );
                }
                // ADD 2008/12/02 �s��Ή�[8548] ---------->>>>>
                if (customerInfo.MngSectionCode != "" &&
                    customerInfo.MngSectionName.Trim() == "")
                {
                    messageList.Add("�Ǘ����_");
                    itemList.Add("MngSectionCode");
                }
                // ADD 2008/12/02 �s��Ή�[8548] ----------<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                //if ( customerInfo.CustomerAgentCd.TrimEnd() == string.Empty )
                //{
                //    messageList.Add( "���Ӑ�S��" );
                //    itemList.Add( "CustomerAgentNm" );
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                if ( customerInfo.ClaimSectionCode == "" )
                {
                    messageList.Add( "�������_" );
                    itemList.Add( "ClaimSectionCode" );
                }

                // ADD 2008/12/02 �s��Ή�[8548] ---------->>>>>
                if (customerInfo.ClaimSectionCode != "" &&
                    customerInfo.ClaimSectionName.Trim() == "")
                {
                    messageList.Add("�������_");
                    itemList.Add("ClaimSectionCode");
                }
                // ADD 2008/12/02 �s��Ή�[8548] ----------<<<<<
                //if ( customerInfo.ClaimName.Trim() == "" )    // DEL 2009/06/26
                if (customerInfo.ClaimCode == 0)    // ADD 2009/06/26
                {
                    messageList.Add("������R�[�h");
                    //itemList.Add( "ClaimName" );  // DEL 2009/06/26
                    itemList.Add("ClaimCode");  // ADD 2009/06/26
                }
                if ( customerInfo.TotalDay == 0 )
                {
                    messageList.Add( "����" );
                    itemList.Add( "TotalDay" );
                }
                if ( customerInfo.CollectMoneyDay == 0 )
                {
                    messageList.Add( "�W����" );
                    itemList.Add( "CollectMoneyDay" );
                }
            }

			if (messageList.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// ���Ӑ�N���X�����̓f�[�^�`�F�b�N����
		/// </summary>
		/// <param name="customerCodeCheck">���Ӑ�R�[�h�`�F�b�N�t���O</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <param name="messageList">���b�Z�[�W���X�g</param>
		/// <param name="itemList">�A�C�e�����X�g</param>
		/// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
		public bool CustomerInputDataCheck(bool customerCodeCheck, CustomerInfo customerInfo, out ArrayList messageList, out ArrayList itemList)
		{
            messageList = new ArrayList();
			itemList = new ArrayList();

			if ((customerCodeCheck) && (customerInfo.CustomerCode == 0))
			{
				messageList.Add("���Ӑ�R�[�h");
				itemList.Add("CustomerCode");

				ArrayList messageList2 = new ArrayList();
				ArrayList itemList2 = new ArrayList();

				this.CustomerInputDataCheck(customerInfo, out messageList2, out itemList2);

				foreach(string message in messageList2)
				{
					messageList.Add(message);
				}

				foreach(string item in itemList2)
				{
					itemList.Add(item);
				}
			}
			else
			{
				this.CustomerInputDataCheck(customerInfo, out messageList, out itemList);
			}

			if (messageList.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// ���Ӑ�}�X�^���݃`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <returns>�X�e�[�^�X</returns>
		public int ExistData(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
		{
            if (_isLocalDBRead)
            {
                return this._customerInfoLcDB.ExistData(enterpriseCode, customerCode, logicalMode);
            }
            else
            {
                return this._iCustomerInfoDB.ExistData(enterpriseCode, customerCode, logicalMode);
            }
        }
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
        //# region ���Ӑ�N���X�f�[�^�s���`�F�b�N����
        ///// <summary>
        ///// ���Ӑ�N���X�f�[�^�s���`�F�b�N����
        ///// </summary>
        ///// <param name="customerInfo">���Ӑ���N���X</param>
        ///// <param name="messageList">���b�Z�[�W���X�g</param>
        ///// <param name="itemList">�A�C�e�����X�g</param>
        ///// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
        //public bool CustomerUnJustDataCheck(CustomerInfo customerInfo, out ArrayList messageList, out ArrayList itemList)
        //{
        //    messageList = new ArrayList();
        //    itemList = new ArrayList();

        //    if (customerInfo.TotalDay > 31)
        //    {
        //        messageList.Add("����");
        //        itemList.Add("TotalDay");
        //    }

        //    if (customerInfo.CollectMoneyDay > 31)
        //    {
        //        messageList.Add("�W����");
        //        itemList.Add("CollectMoneyDay");
        //    }

        //    if ( customerInfo.NTimeCalcStDate > 31 )
        //    {
        //        messageList.Add( "���񊨒�J�n��" );
        //        itemList.Add( "NTimeCalcStDate" );
        //    }
        //    if (messageList.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //# endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL

		# region ���Ӑ惏�[�N�N���X�˓��Ӑ���N���X
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���Ӑ惏�[�N�N���X�˓��Ӑ���N���X�j
		/// </summary>
		/// <param name="customerWork">���Ӑ惏�[�N�N���X</param>
		/// <returns>���Ӑ���N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ惏�[�N�N���X���瓾�Ӑ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             ���Ӑ�}�X�^��Q���ǑΉ�</br>
        /// <br>Update Note: 2021/05/10 ���J�M�m</br>
        /// <br>             ���Ӑ���K�C�h�\��PKG�Ή�</br>
        /// </remarks>
		public static CustomerInfo CopyToCustomerInfoFromCustomerWork(CustomerWork customerWork)
		{
			CustomerInfo customerInfo = new CustomerInfo();

            # region [�����o�R�s�[�i���������j]
            customerInfo.CreateDateTime = customerWork.CreateDateTime; // �쐬����
            customerInfo.UpdateDateTime = customerWork.UpdateDateTime; // �X�V����
            customerInfo.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
            customerInfo.FileHeaderGuid = customerWork.FileHeaderGuid; // GUID
            customerInfo.UpdEmployeeCode = customerWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            customerInfo.UpdAssemblyId1 = customerWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            customerInfo.UpdAssemblyId2 = customerWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            customerInfo.LogicalDeleteCode = customerWork.LogicalDeleteCode; // �_���폜�敪
            customerInfo.CustomerCode = customerWork.CustomerCode; // ���Ӑ�R�[�h
            customerInfo.CustomerSubCode = customerWork.CustomerSubCode; // ���Ӑ�T�u�R�[�h
            customerInfo.Name = customerWork.Name; // ����
            customerInfo.Name2 = customerWork.Name2; // ����2
            customerInfo.HonorificTitle = customerWork.HonorificTitle; // �h��
            customerInfo.Kana = customerWork.Kana; // �J�i
            customerInfo.CustomerSnm = customerWork.CustomerSnm; // ���Ӑ旪��
            customerInfo.OutputNameCode = customerWork.OutputNameCode; // �����R�[�h
            customerInfo.OutputName = customerWork.OutputName; // ��������
            customerInfo.CorporateDivCode = customerWork.CorporateDivCode; // �l�E�@�l�敪
            customerInfo.CustomerAttributeDiv = customerWork.CustomerAttributeDiv; // ���Ӑ摮���敪
            customerInfo.JobTypeCode = customerWork.JobTypeCode; // �E��R�[�h
            customerInfo.BusinessTypeCode = customerWork.BusinessTypeCode; // �Ǝ�R�[�h
            customerInfo.SalesAreaCode = customerWork.SalesAreaCode; // �̔��G���A�R�[�h
            customerInfo.PostNo = customerWork.PostNo; // �X�֔ԍ�
            customerInfo.Address1 = customerWork.Address1; // �Z��1�i�s���{���s��S�E�����E���j
            customerInfo.Address3 = customerWork.Address3; // �Z��3�i�Ԓn�j
            customerInfo.Address4 = customerWork.Address4; // �Z��4�i�A�p�[�g���́j
            customerInfo.HomeTelNo = customerWork.HomeTelNo; // �d�b�ԍ��i����j
            customerInfo.OfficeTelNo = customerWork.OfficeTelNo; // �d�b�ԍ��i�Ζ���j
            customerInfo.PortableTelNo = customerWork.PortableTelNo; // �d�b�ԍ��i�g�сj
            customerInfo.HomeFaxNo = customerWork.HomeFaxNo; // FAX�ԍ��i����j
            customerInfo.OfficeFaxNo = customerWork.OfficeFaxNo; // FAX�ԍ��i�Ζ���j
            customerInfo.OthersTelNo = customerWork.OthersTelNo; // �d�b�ԍ��i���̑��j
            customerInfo.MainContactCode = customerWork.MainContactCode; // ��A����敪
            customerInfo.SearchTelNo = customerWork.SearchTelNo; // �d�b�ԍ��i�����p��4���j
            customerInfo.MngSectionCode = customerWork.MngSectionCode; // �Ǘ����_�R�[�h
            customerInfo.InpSectionCode = customerWork.InpSectionCode; // ���͋��_�R�[�h
            customerInfo.CustAnalysCode1 = customerWork.CustAnalysCode1; // ���Ӑ敪�̓R�[�h1
            customerInfo.CustAnalysCode2 = customerWork.CustAnalysCode2; // ���Ӑ敪�̓R�[�h2
            customerInfo.CustAnalysCode3 = customerWork.CustAnalysCode3; // ���Ӑ敪�̓R�[�h3
            customerInfo.CustAnalysCode4 = customerWork.CustAnalysCode4; // ���Ӑ敪�̓R�[�h4
            customerInfo.CustAnalysCode5 = customerWork.CustAnalysCode5; // ���Ӑ敪�̓R�[�h5
            customerInfo.CustAnalysCode6 = customerWork.CustAnalysCode6; // ���Ӑ敪�̓R�[�h6
            customerInfo.BillOutputCode = customerWork.BillOutputCode; // �������o�͋敪�R�[�h
            customerInfo.BillOutputName = customerWork.BillOutputName; // �������o�͋敪����
            customerInfo.TotalDay = customerWork.TotalDay; // ����
            customerInfo.CollectMoneyCode = customerWork.CollectMoneyCode; // �W�����敪�R�[�h
            customerInfo.CollectMoneyName = customerWork.CollectMoneyName; // �W�����敪����
            customerInfo.CollectMoneyDay = customerWork.CollectMoneyDay; // �W����
            customerInfo.CollectCond = customerWork.CollectCond; // �������
            customerInfo.CollectSight = customerWork.CollectSight; // ����T�C�g
            customerInfo.ClaimCode = customerWork.ClaimCode; // ������R�[�h
            customerInfo.TransStopDate = customerWork.TransStopDate; // ������~��
            customerInfo.DmOutCode = customerWork.DmOutCode; // DM�o�͋敪
            customerInfo.DmOutName = customerWork.DmOutName; // DM�o�͋敪����
            customerInfo.MainSendMailAddrCd = customerWork.MainSendMailAddrCd; // �呗�M�惁�[���A�h���X�敪
            customerInfo.MailAddrKindCode1 = customerWork.MailAddrKindCode1; // ���[���A�h���X��ʃR�[�h1
            customerInfo.MailAddrKindName1 = customerWork.MailAddrKindName1; // ���[���A�h���X��ʖ���1
            customerInfo.MailAddress1 = customerWork.MailAddress1; // ���[���A�h���X1
            customerInfo.MailSendCode1 = customerWork.MailSendCode1; // ���[�����M�敪�R�[�h1
            customerInfo.MailSendName1 = customerWork.MailSendName1; // ���[�����M�敪����1
            customerInfo.MailAddrKindCode2 = customerWork.MailAddrKindCode2; // ���[���A�h���X��ʃR�[�h2
            customerInfo.MailAddrKindName2 = customerWork.MailAddrKindName2; // ���[���A�h���X��ʖ���2
            customerInfo.MailAddress2 = customerWork.MailAddress2; // ���[���A�h���X2
            customerInfo.MailSendCode2 = customerWork.MailSendCode2; // ���[�����M�敪�R�[�h2
            customerInfo.MailSendName2 = customerWork.MailSendName2; // ���[�����M�敪����2
            customerInfo.CustomerAgentCd = customerWork.CustomerAgentCd; // �ڋq�S���]�ƈ��R�[�h
            customerInfo.BillCollecterCd = customerWork.BillCollecterCd; // �W���S���]�ƈ��R�[�h
            customerInfo.OldCustomerAgentCd = customerWork.OldCustomerAgentCd; // ���ڋq�S���]�ƈ��R�[�h
            customerInfo.CustAgentChgDate = customerWork.CustAgentChgDate; // �ڋq�S���ύX��
            customerInfo.AcceptWholeSale = customerWork.AcceptWholeSale; // �Ɣ̐�敪
            customerInfo.CreditMngCode = customerWork.CreditMngCode; // �^�M�Ǘ��敪
            customerInfo.DepoDelCode = customerWork.DepoDelCode; // ���������敪
            customerInfo.AccRecDivCd = customerWork.AccRecDivCd; // ���|�敪
            customerInfo.CustSlipNoMngCd = customerWork.CustSlipNoMngCd; // ����`�[�ԍ��Ǘ��敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
            //customerInfo.PureCode = customerWork.PureCode; // �����敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
            customerInfo.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd; // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            customerInfo.ConsTaxLayMethod = customerWork.ConsTaxLayMethod; // ����œ]�ŕ���
            customerInfo.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd; // ���z�\�����@�敪
            customerInfo.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef; // ���z�\�����@�Q�Ƌ敪
            customerInfo.AccountNoInfo1 = customerWork.AccountNoInfo1; // ��s����1
            customerInfo.AccountNoInfo2 = customerWork.AccountNoInfo2; // ��s����2
            customerInfo.AccountNoInfo3 = customerWork.AccountNoInfo3; // ��s����3
            customerInfo.SalesUnPrcFrcProcCd = customerWork.SalesUnPrcFrcProcCd; // ����P���[�������R�[�h
            customerInfo.SalesMoneyFrcProcCd = customerWork.SalesMoneyFrcProcCd; // ������z�[�������R�[�h
            customerInfo.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd; // �������Œ[�������R�[�h
            customerInfo.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv; // ���Ӑ�`�[�ԍ��敪
            customerInfo.NTimeCalcStDate = customerWork.NTimeCalcStDate; // ���񊨒�J�n��
            customerInfo.CustomerAgent = customerWork.CustomerAgent; // ���Ӑ�S����
            customerInfo.ClaimSectionCode = customerWork.ClaimSectionCode; // �������_�R�[�h
            customerInfo.CarMngDivCd = customerWork.CarMngDivCd; // ���q�Ǘ��敪
            customerInfo.BillPartsNoPrtCd = customerWork.BillPartsNoPrtCd; // �i�Ԉ󎚋敪(������)
            customerInfo.DeliPartsNoPrtCd = customerWork.DeliPartsNoPrtCd; // �i�Ԉ󎚋敪(�[�i���j
            customerInfo.DefSalesSlipCd = customerWork.DefSalesSlipCd; // �`�[�敪�����l
            customerInfo.LavorRateRank = customerWork.LavorRateRank; // �H�����o���[�g�����N
            customerInfo.SlipTtlPrn = customerWork.SlipTtlPrn; // �`�[�^�C�g���p�^�[��
            customerInfo.DepoBankCode = customerWork.DepoBankCode; // ������s�R�[�h
            customerInfo.CustWarehouseCd = customerWork.CustWarehouseCd; // ���Ӑ�D��q�ɃR�[�h
            customerInfo.QrcodePrtCd = customerWork.QrcodePrtCd; // QR�R�[�h���
            customerInfo.DeliHonorificTtl = customerWork.DeliHonorificTtl; // �[�i���h��
            customerInfo.BillHonorificTtl = customerWork.BillHonorificTtl; // �������h��
            customerInfo.EstmHonorificTtl = customerWork.EstmHonorificTtl; // ���Ϗ��h��
            customerInfo.RectHonorificTtl = customerWork.RectHonorificTtl; // �̎����h��
            customerInfo.DeliHonorTtlPrtDiv = customerWork.DeliHonorTtlPrtDiv; // �[�i���h�̈󎚋敪
            customerInfo.BillHonorTtlPrtDiv = customerWork.BillHonorTtlPrtDiv; // �������h�̈󎚋敪
            customerInfo.EstmHonorTtlPrtDiv = customerWork.EstmHonorTtlPrtDiv; // ���Ϗ��h�̈󎚋敪
            customerInfo.RectHonorTtlPrtDiv = customerWork.RectHonorTtlPrtDiv; // �̎����h�̈󎚋敪
            customerInfo.Note1 = customerWork.Note1; // ���l1
            customerInfo.Note2 = customerWork.Note2; // ���l2
            customerInfo.Note3 = customerWork.Note3; // ���l3
            customerInfo.Note4 = customerWork.Note4; // ���l4
            customerInfo.Note5 = customerWork.Note5; // ���l5
            customerInfo.Note6 = customerWork.Note6; // ���l6
            customerInfo.Note7 = customerWork.Note7; // ���l7
            customerInfo.Note8 = customerWork.Note8; // ���l8
            customerInfo.Note9 = customerWork.Note9; // ���l9
            customerInfo.Note10 = customerWork.Note10; // ���l10
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerInfo.JobTypeName = customerWork.JobTypeName; // �E�햼��
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.SalesAreaName = customerWork.SalesAreaName; // �̔��G���A����
            customerInfo.ClaimName = customerWork.ClaimName; // �����於��
            customerInfo.ClaimName2 = customerWork.ClaimName2; // �����於�̂Q
            customerInfo.ClaimSnm = customerWork.ClaimSnm; // �����旪��
            customerInfo.CustomerAgentNm = customerWork.CustomerAgentNm; // �ڋq�S���]�ƈ�����
            customerInfo.OldCustomerAgentNm = customerWork.OldCustomerAgentNm; // ���ڋq�S���]�ƈ�����
            customerInfo.ClaimSectionName = customerWork.ClaimSectionName; // �������_����
            customerInfo.DepoBankName = customerWork.DepoBankName; // ������s����
            customerInfo.CustWarehouseName = customerWork.CustWarehouseName; // ���Ӑ�D��q�ɖ���
            customerInfo.MngSectionName = customerWork.MngSectionName; // �Ǘ����_����
            customerInfo.BusinessTypeName = customerWork.BusinessTypeName; // �Ǝ햼��

            // --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------>>>>>
            customerInfo.SalesSlipPrtDiv = customerWork.SalesSlipPrtDiv;
            customerInfo.AcpOdrrSlipPrtDiv = customerWork.AcpOdrrSlipPrtDiv;
            customerInfo.ShipmSlipPrtDiv = customerWork.ShipmSlipPrtDiv;
            customerInfo.EstimatePrtDiv = customerWork.EstimatePrtDiv;
            customerInfo.UOESlipPrtDiv = customerWork.UOESlipPrtDiv;
            // --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------<<<<<

            // ADD 2009/04/07 ------>>>
            customerInfo.ReceiptOutputCode = customerWork.ReceiptOutputCode; // �̎����o�͋敪�R�[�h
            // ADD 2009/04/07 ------<<<

            // ADD 2009/06/03 ------>>>
            customerInfo.CustomerEpCode = customerWork.CustomerEpCode;      // ���Ӑ��ƃR�[�h
            customerInfo.CustomerSecCode = customerWork.CustomerSecCode;    // ���Ӑ拒�_�R�[�h
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
            customerInfo.SimplInqAcntAcntGrId = customerWork.SimplInqAcntAcntGrId;  // �ȒP�⍇���A�J�E���g�O���[�vID
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
            customerInfo.OnlineKindDiv = customerWork.OnlineKindDiv;        // �I�����C����ʋ敪
            // ADD 2009/06/03 ------<<<
            // --- ADD  ���r��  2010/01/04 ---------->>>>>
            customerInfo.TotalBillOutputDiv = customerWork.TotalBillOutputDiv;  // ���v�������o�͋敪
            customerInfo.DetailBillOutputCode = customerWork.DetailBillOutputCode;  // ���א������o�͋敪
            customerInfo.SlipTtlBillOutputDiv = customerWork.SlipTtlBillOutputDiv;  // �`�[���v�������o�͋敪
            // --- ADD  ���r��  2010/01/04 ----------<<<<<
            // ADD �� K2014/02/06 ---------------------------------->>>>>
            customerInfo.NoteInfo = customerWork.NoteInfo;  // ����
            // ADD �� K2014/02/06 ----------------------------------<<<<<
            // ADD ���J�M�m 2021/05/10 ---------------------------------->>>>>
            customerInfo.DisplayDivCode = customerWork.DisplayDivCode;  //���Ӑ���K�C�h�\���敪
            // ADD ���J�M�m 2021/05/10 ----------------------------------<<<<<
            # endregion

            return customerInfo;
		}
		# endregion

		# region ���Ӑ�N���X�˓��Ӑ惏�[�N�N���X
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���Ӑ�N���X�˓��Ӑ惏�[�N�N���X�j
		/// </summary>
		/// <param name="customerInfo">���Ӑ惏�[�N�N���X</param>
		/// <returns>���Ӑ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�N���X���瓾�Ӑ惏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             ���Ӑ�}�X�^��Q���ǑΉ�</br>
        /// <br>Update Note: 2021/05/10 ���J�M�m</br>
        /// <br>             ���Ӑ���K�C�h�\��PKG�Ή�</br>
        /// </remarks>
		public static CustomerWork CopyToCustomerWorkFromCustomerInfo(CustomerInfo customerInfo)
		{
			CustomerWork customerWork = new CustomerWork();

            # region [�����o�R�s�[�i���������j]
            customerWork.CreateDateTime = customerInfo.CreateDateTime; // �쐬����
            customerWork.UpdateDateTime = customerInfo.UpdateDateTime; // �X�V����
            customerWork.EnterpriseCode = customerInfo.EnterpriseCode; // ��ƃR�[�h
            customerWork.FileHeaderGuid = customerInfo.FileHeaderGuid; // GUID
            customerWork.UpdEmployeeCode = customerInfo.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            customerWork.UpdAssemblyId1 = customerInfo.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            customerWork.UpdAssemblyId2 = customerInfo.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            customerWork.LogicalDeleteCode = customerInfo.LogicalDeleteCode; // �_���폜�敪
            customerWork.CustomerCode = customerInfo.CustomerCode; // ���Ӑ�R�[�h
            customerWork.CustomerSubCode = customerInfo.CustomerSubCode; // ���Ӑ�T�u�R�[�h
            customerWork.Name = customerInfo.Name; // ����
            customerWork.Name2 = customerInfo.Name2; // ����2
            customerWork.HonorificTitle = customerInfo.HonorificTitle; // �h��
            customerWork.Kana = customerInfo.Kana; // �J�i
            customerWork.CustomerSnm = customerInfo.CustomerSnm; // ���Ӑ旪��
            customerWork.OutputNameCode = customerInfo.OutputNameCode; // �����R�[�h
            customerWork.OutputName = customerInfo.OutputName; // ��������
            customerWork.CorporateDivCode = customerInfo.CorporateDivCode; // �l�E�@�l�敪
            customerWork.CustomerAttributeDiv = customerInfo.CustomerAttributeDiv; // ���Ӑ摮���敪
            customerWork.JobTypeCode = customerInfo.JobTypeCode; // �E��R�[�h
            customerWork.BusinessTypeCode = customerInfo.BusinessTypeCode; // �Ǝ�R�[�h
            customerWork.SalesAreaCode = customerInfo.SalesAreaCode; // �̔��G���A�R�[�h
            customerWork.PostNo = customerInfo.PostNo; // �X�֔ԍ�
            customerWork.Address1 = customerInfo.Address1; // �Z��1�i�s���{���s��S�E�����E���j
            customerWork.Address3 = customerInfo.Address3; // �Z��3�i�Ԓn�j
            customerWork.Address4 = customerInfo.Address4; // �Z��4�i�A�p�[�g���́j
            customerWork.HomeTelNo = customerInfo.HomeTelNo; // �d�b�ԍ��i����j
            customerWork.OfficeTelNo = customerInfo.OfficeTelNo; // �d�b�ԍ��i�Ζ���j
            customerWork.PortableTelNo = customerInfo.PortableTelNo; // �d�b�ԍ��i�g�сj
            customerWork.HomeFaxNo = customerInfo.HomeFaxNo; // FAX�ԍ��i����j
            customerWork.OfficeFaxNo = customerInfo.OfficeFaxNo; // FAX�ԍ��i�Ζ���j
            customerWork.OthersTelNo = customerInfo.OthersTelNo; // �d�b�ԍ��i���̑��j
            customerWork.MainContactCode = customerInfo.MainContactCode; // ��A����敪
            customerWork.SearchTelNo = customerInfo.SearchTelNo; // �d�b�ԍ��i�����p��4���j
            customerWork.MngSectionCode = customerInfo.MngSectionCode; // �Ǘ����_�R�[�h
            customerWork.InpSectionCode = customerInfo.InpSectionCode; // ���͋��_�R�[�h
            customerWork.CustAnalysCode1 = customerInfo.CustAnalysCode1; // ���Ӑ敪�̓R�[�h1
            customerWork.CustAnalysCode2 = customerInfo.CustAnalysCode2; // ���Ӑ敪�̓R�[�h2
            customerWork.CustAnalysCode3 = customerInfo.CustAnalysCode3; // ���Ӑ敪�̓R�[�h3
            customerWork.CustAnalysCode4 = customerInfo.CustAnalysCode4; // ���Ӑ敪�̓R�[�h4
            customerWork.CustAnalysCode5 = customerInfo.CustAnalysCode5; // ���Ӑ敪�̓R�[�h5
            customerWork.CustAnalysCode6 = customerInfo.CustAnalysCode6; // ���Ӑ敪�̓R�[�h6
            customerWork.BillOutputCode = customerInfo.BillOutputCode; // �������o�͋敪�R�[�h
            customerWork.BillOutputName = customerInfo.BillOutputName; // �������o�͋敪����
            customerWork.TotalDay = customerInfo.TotalDay; // ����
            customerWork.CollectMoneyCode = customerInfo.CollectMoneyCode; // �W�����敪�R�[�h
            customerWork.CollectMoneyName = customerInfo.CollectMoneyName; // �W�����敪����
            customerWork.CollectMoneyDay = customerInfo.CollectMoneyDay; // �W����
            customerWork.CollectCond = customerInfo.CollectCond; // �������
            customerWork.CollectSight = customerInfo.CollectSight; // ����T�C�g
            customerWork.ClaimCode = customerInfo.ClaimCode; // ������R�[�h
            customerWork.TransStopDate = customerInfo.TransStopDate; // ������~��
            customerWork.DmOutCode = customerInfo.DmOutCode; // DM�o�͋敪
            customerWork.DmOutName = customerInfo.DmOutName; // DM�o�͋敪����
            customerWork.MainSendMailAddrCd = customerInfo.MainSendMailAddrCd; // �呗�M�惁�[���A�h���X�敪
            customerWork.MailAddrKindCode1 = customerInfo.MailAddrKindCode1; // ���[���A�h���X��ʃR�[�h1
            customerWork.MailAddrKindName1 = customerInfo.MailAddrKindName1; // ���[���A�h���X��ʖ���1
            customerWork.MailAddress1 = customerInfo.MailAddress1; // ���[���A�h���X1
            customerWork.MailSendCode1 = customerInfo.MailSendCode1; // ���[�����M�敪�R�[�h1
            customerWork.MailSendName1 = customerInfo.MailSendName1; // ���[�����M�敪����1
            customerWork.MailAddrKindCode2 = customerInfo.MailAddrKindCode2; // ���[���A�h���X��ʃR�[�h2
            customerWork.MailAddrKindName2 = customerInfo.MailAddrKindName2; // ���[���A�h���X��ʖ���2
            customerWork.MailAddress2 = customerInfo.MailAddress2; // ���[���A�h���X2
            customerWork.MailSendCode2 = customerInfo.MailSendCode2; // ���[�����M�敪�R�[�h2
            customerWork.MailSendName2 = customerInfo.MailSendName2; // ���[�����M�敪����2
            customerWork.CustomerAgentCd = customerInfo.CustomerAgentCd; // �ڋq�S���]�ƈ��R�[�h
            customerWork.BillCollecterCd = customerInfo.BillCollecterCd; // �W���S���]�ƈ��R�[�h
            customerWork.OldCustomerAgentCd = customerInfo.OldCustomerAgentCd; // ���ڋq�S���]�ƈ��R�[�h
            customerWork.CustAgentChgDate = customerInfo.CustAgentChgDate; // �ڋq�S���ύX��
            customerWork.AcceptWholeSale = customerInfo.AcceptWholeSale; // �Ɣ̐�敪
            customerWork.CreditMngCode = customerInfo.CreditMngCode; // �^�M�Ǘ��敪
            customerWork.DepoDelCode = customerInfo.DepoDelCode; // ���������敪
            customerWork.AccRecDivCd = customerInfo.AccRecDivCd; // ���|�敪
            customerWork.CustSlipNoMngCd = customerInfo.CustSlipNoMngCd; // ����`�[�ԍ��Ǘ��敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
            //customerWork.PureCode = customerInfo.PureCode; // �����敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
            customerWork.CustCTaXLayRefCd = customerInfo.CustCTaXLayRefCd; // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            customerWork.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; // ����œ]�ŕ���
            customerWork.TotalAmountDispWayCd = customerInfo.TotalAmountDispWayCd; // ���z�\�����@�敪
            customerWork.TotalAmntDspWayRef = customerInfo.TotalAmntDspWayRef; // ���z�\�����@�Q�Ƌ敪
            customerWork.AccountNoInfo1 = customerInfo.AccountNoInfo1; // ��s����1
            customerWork.AccountNoInfo2 = customerInfo.AccountNoInfo2; // ��s����2
            customerWork.AccountNoInfo3 = customerInfo.AccountNoInfo3; // ��s����3
            customerWork.SalesUnPrcFrcProcCd = customerInfo.SalesUnPrcFrcProcCd; // ����P���[�������R�[�h
            customerWork.SalesMoneyFrcProcCd = customerInfo.SalesMoneyFrcProcCd; // ������z�[�������R�[�h
            customerWork.SalesCnsTaxFrcProcCd = customerInfo.SalesCnsTaxFrcProcCd; // �������Œ[�������R�[�h
            customerWork.CustomerSlipNoDiv = customerInfo.CustomerSlipNoDiv; // ���Ӑ�`�[�ԍ��敪
            customerWork.NTimeCalcStDate = customerInfo.NTimeCalcStDate; // ���񊨒�J�n��
            customerWork.CustomerAgent = customerInfo.CustomerAgent; // ���Ӑ�S����
            customerWork.ClaimSectionCode = customerInfo.ClaimSectionCode; // �������_�R�[�h
            customerWork.CarMngDivCd = customerInfo.CarMngDivCd; // ���q�Ǘ��敪
            customerWork.BillPartsNoPrtCd = customerInfo.BillPartsNoPrtCd; // �i�Ԉ󎚋敪(������)
            customerWork.DeliPartsNoPrtCd = customerInfo.DeliPartsNoPrtCd; // �i�Ԉ󎚋敪(�[�i���j
            customerWork.DefSalesSlipCd = customerInfo.DefSalesSlipCd; // �`�[�敪�����l
            customerWork.LavorRateRank = customerInfo.LavorRateRank; // �H�����o���[�g�����N
            customerWork.SlipTtlPrn = customerInfo.SlipTtlPrn; // �`�[�^�C�g���p�^�[��
            customerWork.DepoBankCode = customerInfo.DepoBankCode; // ������s�R�[�h
            customerWork.CustWarehouseCd = customerInfo.CustWarehouseCd; // ���Ӑ�D��q�ɃR�[�h
            customerWork.QrcodePrtCd = customerInfo.QrcodePrtCd; // QR�R�[�h���
            customerWork.DeliHonorificTtl = customerInfo.DeliHonorificTtl; // �[�i���h��
            customerWork.BillHonorificTtl = customerInfo.BillHonorificTtl; // �������h��
            customerWork.EstmHonorificTtl = customerInfo.EstmHonorificTtl; // ���Ϗ��h��
            customerWork.RectHonorificTtl = customerInfo.RectHonorificTtl; // �̎����h��
            customerWork.DeliHonorTtlPrtDiv = customerInfo.DeliHonorTtlPrtDiv; // �[�i���h�̈󎚋敪
            customerWork.BillHonorTtlPrtDiv = customerInfo.BillHonorTtlPrtDiv; // �������h�̈󎚋敪
            customerWork.EstmHonorTtlPrtDiv = customerInfo.EstmHonorTtlPrtDiv; // ���Ϗ��h�̈󎚋敪
            customerWork.RectHonorTtlPrtDiv = customerInfo.RectHonorTtlPrtDiv; // �̎����h�̈󎚋敪
            customerWork.Note1 = customerInfo.Note1; // ���l1
            customerWork.Note2 = customerInfo.Note2; // ���l2
            customerWork.Note3 = customerInfo.Note3; // ���l3
            customerWork.Note4 = customerInfo.Note4; // ���l4
            customerWork.Note5 = customerInfo.Note5; // ���l5
            customerWork.Note6 = customerInfo.Note6; // ���l6
            customerWork.Note7 = customerInfo.Note7; // ���l7
            customerWork.Note8 = customerInfo.Note8; // ���l8
            customerWork.Note9 = customerInfo.Note9; // ���l9
            customerWork.Note10 = customerInfo.Note10; // ���l10
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerWork.JobTypeName = customerInfo.JobTypeName; // �E�햼��
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerWork.SalesAreaName = customerInfo.SalesAreaName; // �̔��G���A����
            customerWork.ClaimName = customerInfo.ClaimName; // �����於��
            customerWork.ClaimName2 = customerInfo.ClaimName2; // �����於�̂Q
            customerWork.ClaimSnm = customerInfo.ClaimSnm; // �����旪��
            customerWork.CustomerAgentNm = customerInfo.CustomerAgentNm; // �ڋq�S���]�ƈ�����
            customerWork.OldCustomerAgentNm = customerInfo.OldCustomerAgentNm; // ���ڋq�S���]�ƈ�����
            customerWork.ClaimSectionName = customerInfo.ClaimSectionName; // �������_����
            customerWork.DepoBankName = customerInfo.DepoBankName; // ������s����
            customerWork.CustWarehouseName = customerInfo.CustWarehouseName; // ���Ӑ�D��q�ɖ���
            customerWork.MngSectionName = customerInfo.MngSectionName; // �Ǘ����_����
            customerWork.BusinessTypeName = customerInfo.BusinessTypeName; // �Ǝ햼��

            // --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------>>>>>
            customerWork.SalesSlipPrtDiv = customerInfo.SalesSlipPrtDiv;
            customerWork.AcpOdrrSlipPrtDiv = customerInfo.AcpOdrrSlipPrtDiv;
            customerWork.ShipmSlipPrtDiv = customerInfo.ShipmSlipPrtDiv;
            customerWork.EstimatePrtDiv = customerInfo.EstimatePrtDiv;
            customerWork.UOESlipPrtDiv = customerInfo.UOESlipPrtDiv;
            // --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------<<<<<

            // ADD 2009/04/07 ------>>>
            customerWork.ReceiptOutputCode = customerInfo.ReceiptOutputCode; // �̎����o�͋敪�R�[�h
            // ADD 2009/04/07 ------<<<

            // ADD 2009/06/03 ------>>>
            customerWork.CustomerEpCode = customerInfo.CustomerEpCode;      // ���Ӑ��ƃR�[�h
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
            customerWork.SimplInqAcntAcntGrId = customerInfo.SimplInqAcntAcntGrId;  // �ȒP�⍇���A�J�E���g�O���[�vID
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
            customerWork.CustomerSecCode = customerInfo.CustomerSecCode;    // ���Ӑ拒�_�R�[�h
            customerWork.OnlineKindDiv = customerInfo.OnlineKindDiv;        // �I�����C����ʋ敪
            // ADD 2009/06/03 ------<<<
            // --- ADD  ���r��  2010/01/04 ---------->>>>>
            customerWork.TotalBillOutputDiv = customerInfo.TotalBillOutputDiv;  // ���v�������o�͋敪
            customerWork.DetailBillOutputCode = customerInfo.DetailBillOutputCode;  // ���א������o�͋敪
            customerWork.SlipTtlBillOutputDiv = customerInfo.SlipTtlBillOutputDiv;  // �`�[���v�������o�͋敪

            // --- ADD  ���r��  2010/01/04 ----------<<<<<
            // ADD ���J�M�m 2021/05/10 ----------------------------->>>>>
            customerWork.DisplayDivCode = customerInfo.DisplayDivCode;  // ���Ӑ���K�C�h�\���敪
            // ADD ���J�M�m 2021/05/10 -----------------------------<<<<<
            // ADD �� K2014/02/06 ----------------------------->>>>>
            customerWork.NoteInfo = customerInfo.NoteInfo;  // ����
            // ADD �� K2014/02/06 -----------------------------<<<<<
            # endregion

            return customerWork;
		}
		# endregion

		# region �S�̍��ڕ\�����̃}�X�^�擾����
		/// <summary>
		/// �S�̍��ڕ\�����̃}�X�^�擾����
		/// </summary>
		/// <param name="alItmDspNm">�S�̍��ڕ\�����̃}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		public int GetAlItmDspNm(out AlItmDspNm alItmDspNm)
		{
			// �\�����̐ݒ�
			AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
            int status = alItmDspNmAcs.ReadStatic(out alItmDspNm, this._enterpriseCode);

			if (alItmDspNm == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			return status;
		}
		# endregion

		# region �\�����̐ݒ菈��
		/// <summary>
		/// �\�����̐ݒ菈��
		/// </summary>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		public void SetDspName(ref CustomerInfo customerInfo)
		{
			AlItmDspNm alItmDspNm;
			if (this.GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				customerInfo.HomeTelNoDspName = alItmDspNm.HomeTelNoDspName;
				customerInfo.OfficeTelNoDspName = alItmDspNm.OfficeTelNoDspName;
				customerInfo.MobileTelNoDspName = alItmDspNm.MobileTelNoDspName;
				customerInfo.OtherTelNoDspName = alItmDspNm.OtherTelNoDspName;
				customerInfo.HomeFaxNoDspName = alItmDspNm.HomeFaxNoDspName;
				customerInfo.OfficeFaxNoDspName = alItmDspNm.OfficeFaxNoDspName;
			}
		}
		# endregion

        # region ���z�[�������敪�擾����
        /// <summary>
        /// ������z�[�������敪�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="fracProcMoneyDiv">0:����P��,1:������z,2:��������</param>
        /// <returns>�[�������敪</returns>
        public int GetSalesFractionProcCd ( string enterpriseCode, int customerCode, FracProcMoneyDiv fracProcMoneyDiv )
        {
            int fractionProcCd = 0;
            // -- ADD 2010/04/06 ---------------------------------->>>
            //�p�����[�^���s���ȏꍇ�́A���Ӑ�}�X�^�̎擾�������s��Ȃ��B
            if (string.IsNullOrEmpty(enterpriseCode) || customerCode == 0)
            {
                return fractionProcCd;
            }
            // -- ADD 2010/04/06 ---------------------------------->>>

            CustomerInfo customerInfo;
            int status = this.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/03 ADD
            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                status = this.ReadDBData( enterpriseCode, customerCode, out customerInfo );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/03 ADD

            if ( ( status == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) && ( customerInfo != null ) && ( customerInfo.CustomerCode != 0 ) ) {
                switch ( fracProcMoneyDiv ) {
                    case FracProcMoneyDiv.UnPrcFrcProcCd :
                        fractionProcCd = customerInfo.SalesUnPrcFrcProcCd;
                        break;
                    case FracProcMoneyDiv.MoneyFrcProcCd :
                        fractionProcCd = customerInfo.SalesMoneyFrcProcCd;
                        break;
                    case FracProcMoneyDiv.CnsTaxFrcProcCd :
                        fractionProcCd = customerInfo.SalesCnsTaxFrcProcCd;
                        break;
                }
            }
            return fractionProcCd;
        }
        # endregion

        // --- ADD 2010/09/26 ---------->>>>>
        /// <summary>
        /// DB���瓾�Ӑ�f�[�^���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="cacheFlg">�L���b�V���t���O[true:�L���b�V������ false:�L���b�V�����Ȃ�]</param>
        /// <param name="isSettingName">���̐ݒ�敪(ture:�ݒ肠�� false:�ݒ薳��)</param>
        /// <param name="customerInfoList">���Ӑ��񃊃X�g</param>
        /// <returns></returns>
        public int Search(string enterpriseCode, bool cacheFlg, bool isSettingName, out List<CustomerInfo> customerInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            customerInfoList = new List<CustomerInfo>();

            object retList = null;
            
            CustomerWork customerWorkPra = new CustomerWork();
            customerWorkPra.EnterpriseCode = enterpriseCode;

            object customerWorkObj = customerWorkPra;

            //���Ӑ�ǂݍ���
            status = this._iCustomerInfoDB.Search(customerWorkObj, out retList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retList as ArrayList;

                foreach (CustomerWork customerWork in list)
                {
                    // �N���X�������o�R�s�[
                    CustomerInfo customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                    int customerCode = customerInfo.CustomerCode;

                    if (isSettingName)
                    {
                        // 2010/10/28 Del >>>
                        //// �Ǘ����_���̎擾
                        //SecInfoSet secInfoSet;
                        //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        //secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                        //if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
                        //{
                        //    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                        //}
                        // 2010/10/28 Del <<<
                    }

                    // �L�[��񐶐�����
                    string key = this.ConstructionKey(enterpriseCode, customerCode);

                    // ���łɓ��Ӑ��񂪃L���b�V���O����Ă���ꍇ�͍X�V���̔�r���s���A��������̏ꍇ��
                    // �ăL���b�V���O�͍s��Ȃ�
                    if ((_customerDictionary.ContainsKey(key)) && ((_customerDictionary[key]).UpdateDateTime == customerInfo.UpdateDateTime))
                    {
                        customerInfo = (_customerDictionary[key]).Clone();
                    }
                    else
                    {
                        if (cacheFlg)
                        {
                            // ���Ӑ���o�b�t�@(MainMemory)�i�[�p�n�b�V���e�[�u���ǉ�����
                            // 2010/10/28 >>>
                            //this.AddMainMemoryDictionary(customerInfo);
                            this.AddMainMemoryDictionary(customerInfo, false);
                            // 2010/10/28 <<<

                            // ���A���X�V�ɃR�s�[��Undo�o�b�t�@
                            this.CopyStaticMemory(0, enterpriseCode, customerCode);
                        }
                    }

                    customerInfoList.Add(customerInfo);
                }
            }

            return status;
        }
        // --- ADD 2010/09/26 ----------<<<<<
	}
}
