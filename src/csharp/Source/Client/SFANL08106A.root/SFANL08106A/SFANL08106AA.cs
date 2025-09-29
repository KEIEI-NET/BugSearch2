using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Drawing.Imaging;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;

using Broadleaf.Library.Text;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒu�ݒ�ւ̃A�N�Z�X������s���܂��B</br>
	/// <br>			: �O������e�f�[�^�ւ̃A�N�Z�X�̓v���p�e�B��ʂ��čs���܂��B</br>
	/// <br>			: ���A�{�N���X���璼�ڃ����[�g�N���X��Call���鎖�͂���܂���B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>Update Note : 2008.05.22 22018 ��ؐ��b</br>
    /// <br>            : �@PM.NS�Ή�</br>
	/// </remarks>
	public class FrePrtPosAcs
	{
		#region Enum
		/// <summary>���R���[�ۑ����[�h</summary>
		public enum FreeSheet_SaveMode
		{
			/// <summary>�V�K�o�^</summary>
			NewWrite,
			/// <summary>�㏑���ۑ�</summary>
			OverWrite,
		}
		#endregion

		#region Const
		private const string ctExtendXML = ".xml";
		// ���R���[�v���p�e�B�\�����t�@�C����
		private const string ctARCtrlPropertyDispInfo_FileNm		= "SFANL08105U_DispInfo";
		// �󎚍��ڃO���[�v�\�����̃t�@�C����
		private const string ctPrtItemGroupingDispTitle_FileName	= "SFANL08105U_ItemTitle";
		// ���R���[�v���p�e�B�\�����Dictionary�쐬�p
		/// <summary>TextBox</summary>
		public const string TBL_TEXTBOX	= "TextBox";
		/// <summary>Label</summary>
		public const string TBL_LABEL	= "Label";
		/// <summary>Picture</summary>
		public const string TBL_PICTURE	= "Picture";
		/// <summary>Shape</summary>
		public const string TBL_SHAPE	= "Shape";
		/// <summary>Line</summary>
		public const string TBL_LINE	= "Line";
		/// <summary>Barcode</summary>
		public const string TBL_BARCODE	= "Barcode";
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ������ �e��A�N�Z�X�N���X ������
		// --------------------------------------------------------
		// �󎚈ʒu�ݒ�n�A�N�Z�X�N���X
		private FrePrtPSetAcs			_frePrtPSetAcs;
		// �󎚍��ڐݒ�n�A�N�Z�X�N���X
		private PrtItemGrpAcs			_prtItemSetAcs;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
        //// ���[�J���f�[�^�A�N�Z�X�N���X
        //private FrePrtPosLocalAcs		_localDataAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
        //// DM�ē����ݒ�A�N�Z�X�N���X
        //private DmGuideSntAcs			_dmGuideSntAcs;
        //// DM�v���O�����Ǘ��A�N�Z�X�N���X
        //private DmPgMngAcs				_dmPgMngAcs;

		// --------------------------------------------------------
		// ������ �o�b�N�A�b�v��� ������
		// --------------------------------------------------------
		// ���R���[�󎚈ʒu�ݒ�}�X�^
		private FrePrtPSet				_buf_frePrtPSet;
		// ���R���[���o�����ݒ�}�X�^
		private List<FrePprECnd>		_buf_frePprECndList;
		// ���R���[�\�[�g���ʃ}�X�^
		private List<FrePprSrtO>		_buf_frePprSrtOList;
		// �摜�O���[�v�}�X�^
		private ImageGroup				_buf_imageGroup;
		// �摜�Ǘ��}�X�^
		private ImgManage				_buf_imgManage;

		// --------------------------------------------------------
		// ������ �N�����Ɏ擾������ ������
		// --------------------------------------------------------
		// �󎚍��ڃO���[�v�}�X�^
		private List<PrtItemGrpWork>	_prtItemGrpList;
		// �󎚍��ڃO���[�v�\������
		private List<PrtItemGroupingDispTitle> _prtItemGroupingDispTitle;
		// ���R���[�Ǘ��I�v�V�����t���O
		private bool					_freeSheetMngOpt;

		// --------------------------------------------------------
		// ������ ���|�[�g�̕ҏW�Ώۂ��m�肵�����_�Ŏ擾������ ������
		// --------------------------------------------------------
		// �󎚍��ڐݒ�}�X�^
		private List<PrtItemSetWork>	_prtItemSetList;
		// ���R���[�󎚈ʒu�ݒ�}�X�^
		private FrePrtPSet				_frePrtPSet;
		// ���R���[���o�����ݒ�}�X�^
		private List<FrePprECnd>		_frePprECndList;
		// ���R���[���o�������׃}�X�^
		private List<FrePExCndD>		_frePExCndDList;
		// ���R���[�\�[�g���ʃ}�X�^
		private List<FrePprSrtO>		_frePprSrtOList;
		// �摜�O���[�v�}�X�^
		private ImageGroup				_imageGroup;
		// �摜�Ǘ��}�X�^
		private ImgManage				_imgManage;
		// ���R���[�v���p�e�B�\�����
		private List<ARCtrlPropertyDispInfo> _aRCtrlDispList;

		// --------------------------------------------------------
		// ������ ���̑����[�N�ϐ� ������
		// --------------------------------------------------------
		// �G���[���b�Z�[�W
		private string					_errorStr;
		// �`�[���LIST
		private List<int>				_slipPrtKindList;
		// �������摜���䕔�i
		private SFANL08235CF			_watermarkCmnCtrl;
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>���R���[�Ǘ��I�v�V�����t���O</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public bool FreeSheetMngOpt
		{
			get { return _freeSheetMngOpt; }
		}

		/// <summary>�󎚍��ڃO���[�v�}�X�^</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public List<PrtItemGrpWork> PrtItemGrpList
		{
			get {
				if (_prtItemGrpList != null)
					return _prtItemGrpList;
				else
					return new List<PrtItemGrpWork>();
			}
		}

		/// <summary>���R���[�󎚍��ڐݒ�}�X�^</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public List<PrtItemSetWork> PrtItemSetList
		{
			get { return _prtItemSetList; }
		}

		/// <summary>���R���[�󎚈ʒu�ݒ�}�X�^</summary>
		public FrePrtPSet FrePrtPSet
		{
			get { return _frePrtPSet; }
			set { _frePrtPSet = value; }
		}

		/// <summary>���R���[���o�����ݒ�}�X�^</summary>
		public List<FrePprECnd> FrePprECndList
		{
			get { return _frePprECndList; }
			set { _frePprECndList = value; }
		}

		/// <summary>���R���[���o�������׃}�X�^</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public List<FrePExCndD> FrePExCndDList
		{
			get {
				if (_frePExCndDList != null)
					return _frePExCndDList;
				else
					return new List<FrePExCndD>();
			}
		}

		/// <summary>���R���[�\�[�g���ʃ}�X�^</summary>
		public List<FrePprSrtO> FrePprSrtOList
		{
			get { return _frePprSrtOList; }
			set { _frePprSrtOList = value; }
		}

		/// <summary>���R���[�v���p�e�B�\�����</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public List<ARCtrlPropertyDispInfo> ARCtrlPropertyDispInfo
		{
			get {
				if (_aRCtrlDispList != null)
					return _aRCtrlDispList;
				else
					return new List<ARCtrlPropertyDispInfo>();
			}
		}

		/// <summary>�󎚍��ڃO���[�v�\������</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public List<PrtItemGroupingDispTitle> PrtItemGroupingDispTitle
		{
			get {
				if (_prtItemGroupingDispTitle != null)
					return _prtItemGroupingDispTitle;
				else
					return new List<PrtItemGroupingDispTitle>();
			}
		}

		/// <summary>�������摜</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public Image WaterMark
		{
			get {
				if (_imgManage != null)
					return _imgManage.TakeInImage;
				else
					return null;
			}
		}

		/// <summary>�`�[���LIST</summary>
		public List<int> SlipPrtKindList
		{
			set { _slipPrtKindList = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public FrePrtPosAcs()
		{
			try
			{
				_frePrtPSetAcs		= new FrePrtPSetAcs();
				_prtItemSetAcs		= new PrtItemGrpAcs();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //_localDataAcs		= new FrePrtPosLocalAcs();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
				_watermarkCmnCtrl	= new SFANL08235CF();

				// ���R���[�Ǘ��I�v�V�����̗L�����`�F�b�N
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki�@�ۗ��E�Ή��K�v  615C
                //PurchaseStatus status
                //    = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FreeSheetgMng);
                PurchaseStatus status
                = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB( ConstantManagement_SF_PRO.SoftwareCode_PAC_PM );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki�@�ۗ��E�Ή��K�v�@615C
				if (status >= PurchaseStatus.Contract)
					_freeSheetMngOpt = true;

			}
			catch
			{
				_frePrtPSetAcs		= null;
				_prtItemSetAcs		= null;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //_localDataAcs		= null;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
				_watermarkCmnCtrl	= null;
			}
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �����������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int Initialize(string enterpriseCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// ���O�o�́i�����[�g�Łj
				_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit Start");

				// �󎚍��ڃO���[�vLIST�擾
				List<PrtItemGrpWork> prtItemGrpList;
				status = _prtItemSetAcs.SearchPrtItemGrpWork(out prtItemGrpList);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						_prtItemGrpList = prtItemGrpList;
						break;
					}
					default:
					{
						_errorStr = _prtItemSetAcs.ErrorMessage;
						break;
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���o��������LIST�擾
					List<FrePExCndD> frePExCndDList;
					status = _frePrtPSetAcs.SearchFrePExCndDList(enterpriseCode, out frePExCndDList);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							_frePExCndDList = frePExCndDList;
							break;
						}
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							break;
						}
						default:
						{
							_errorStr = _prtItemSetAcs.ErrorMessage;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �I�����O�o�͏���
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <remarks>
		/// <br>Note		: �ҏW�I�����̃��O���o�͂��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void WriteLog(string enterpriseCode, string message)
		{
			// ���O�o�́i�����[�g�Łj
			_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, message);
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ���Ǎ�����
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚈ʒu�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int ReadReportInfo(FrePrtPSet frePrtPSet)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// �X�V�`�F�b�N�̈בޔ�
				DateTime updateDateTime = frePrtPSet.UpdateDateTime;

				PrtItemGrpWork prtItemGrpWork = _prtItemGrpList.Find(
					delegate(PrtItemGrpWork prtItemGrp)
					{
						if (prtItemGrp.FreePrtPprItemGrpCd == frePrtPSet.FreePrtPprItemGrpCd)
							return true;
						else
							return false;
					}
				);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/19 DEL
                //// ���[�J���f�[�^�̎擾
                //bool isExistLclData = false;
                //FrePrtPSet frePrtPSetClone = frePrtPSet.Clone();
                //List<FrePprECnd> frePprECndList;
                //List<FrePprSrtO> frePprSrtOList;
                //List<FPSortInitWork> fPSortInitList = new List<FPSortInitWork>();
                //status = _localDataAcs.ReadLocalFrePrtPSet(ref frePrtPSetClone, out frePprECndList, out frePprSrtOList);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    isExistLclData = true;

                //    // �X�V���t���������ꍇ�̓��[�J���f�[�^���g�p
                //    if (!updateDateTime.Equals(frePrtPSetClone.UpdateDateTime))
                //        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    else
                //        frePrtPSet = frePrtPSetClone;
                //}

                //// ���[�J���f�[�^���Â������͎擾�o���Ȃ��ꍇ�̓����[�e�B���O
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = _frePrtPSetAcs.ReadDBFrePrtPSet(ref frePrtPSet, out frePprECndList, out frePprSrtOList);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        // ���[�J���f�[�^���擾�o���Ȃ����̂݃��[�J���ۑ�
                //        if (!isExistLclData)
                //            _localDataAcs.WriteLocalFrePrtPSet(frePrtPSet, frePprECndList, frePprSrtOList);
                //    }
                //    else
                //    {
                //        _errorStr = _frePrtPSetAcs.ErrorMessage;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/19 ADD
                FrePrtPSet frePrtPSetClone = frePrtPSet.Clone();
                List<FrePprECnd> frePprECndList;
                List<FrePprSrtO> frePprSrtOList;
                List<FPSortInitWork> fPSortInitList = new List<FPSortInitWork>();

                status = _frePrtPSetAcs.ReadDBFrePrtPSet( ref frePrtPSet, out frePprECndList, out frePprSrtOList );
                
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    _errorStr = _frePrtPSetAcs.ErrorMessage;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/19 ADD


				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// �󎚍��ڐݒ茟������
					status = SearchPrtItemSet(prtItemGrpWork, out fPSortInitList);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// -------------------------------------------------
						// ���R���[�󎚈ʒu�ݒ�
						// -------------------------------------------------
						_frePrtPSet = frePrtPSet;

						// -------------------------------------------------
						// ���R���[���o����
						// -------------------------------------------------
						// �󎚍��ڐݒ��蒊�o�����ݒ���쐬
						List<FrePprECnd> wkFrePprECndList
							= CreateFrePprECndFromPrtItemSet(frePrtPSet.EnterpriseCode, frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo);
						// �����̒��o�����ݒ�ƁA���ō쐬�������o�����ݒ���}�[�W
						_frePprECndList = MergeFrePprECnd(wkFrePprECndList, frePprECndList);

						// -------------------------------------------------
						// ���R���[�\�[�g����
						// -------------------------------------------------
						// �󎚍��ڐݒ���\�[�g���ʂ��쐬
						List<FrePprSrtO> wkFrePprSrtOList
							= CreateFrePprSrtO(frePrtPSet.EnterpriseCode, frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo, fPSortInitList);
						// �����̃\�[�g���ʂƁA���ō쐬�����\�[�g���ʂ��}�[�W
						_frePprSrtOList = MergeFrePprSrtO(wkFrePprSrtOList, frePprSrtOList);

						// -------------------------------------------------
						// ���̑�
						// -------------------------------------------------
						// �������摜�����N���A
						_imageGroup = null;
						_imgManage = null;
						// �������摜�̎擾
						SearchImage();

						// ActiveReport�\���v���p�e�B�ݒ�擾
						_aRCtrlDispList = GetDispPropertyList();

						// �o�b�t�@�ɃR�s�[
						CopyPrtPosDataToBuffer();

						// ���O�o�́i�����[�g�Łj
						_frePrtPSetAcs.WriteLog(frePrtPSet.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit ReadReportInfo");
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[�󎚈ʒu�ݒ���Ǎ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�ۑ�����
		/// </summary>
		/// <param name="saveMode">���R���[�ۑ����[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚈ʒu�ݒ��o�^���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int WriteDBFrePrtPSet(FreeSheet_SaveMode saveMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				List<FrePprECnd> writeFrePprECndList = null;
				List<FrePprSrtO> writeFrePprSrtOList = null;

				bool isNewWrite = false;
				switch (saveMode)
				{
					case FreeSheet_SaveMode.NewWrite:
					{
						isNewWrite = true;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //// �}�Ԃ̓����[�g�Ŏ擾
                        //int userPrtPprIdDerivNo = _frePrtPSetAcs.GetUserPrtPprIdDerivNo(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                        // �}�Ԃ̓[���Œ�
                        int userPrtPprIdDerivNo = 0;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

						// �X�V���t���N���A����i�r���΍�j
						_frePrtPSet.UpdateDateTime = DateTime.MinValue;
						// �}�Ԃ��̔�
						_frePrtPSet.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;

						if (_frePprECndList != null)
						{
							foreach (FrePprECnd frePprECnd in _frePprECndList)
							{
								// �X�V���t���N���A����i�r���΍�j
								frePprECnd.UpdateDateTime = DateTime.MinValue;
								// �}�Ԃ��̔�
								frePprECnd.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                                // ���[�h�c��������(���O��t���ĕۑ��΍�)
                                frePprECnd.OutputFormFileName = _frePrtPSet.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
							}
						}
						if (_frePprSrtOList != null)
						{
							foreach (FrePprSrtO frePprSrtO in _frePprSrtOList)
							{
								// �X�V���t���N���A����i�r���΍�j
								frePprSrtO.UpdateDateTime = DateTime.MinValue;
								// �}�Ԃ��̔�
								frePprSrtO.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                                // ���[�h�c��������(���O��t���ĕۑ��΍�)
                                frePprSrtO.OutputFormFileName = _frePrtPSet.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
							}
						}

						// �V�K�Ȃ̂őS�f�[�^�����[�e�B���O
						writeFrePprECndList = _frePprECndList;
						writeFrePprSrtOList = _frePprSrtOList;
						break;
					}
					default:
					{
						// �X�V���ꂽ�f�[�^�̂݃����[�e�B���O
						if (IsFrePprECndListChanged()) writeFrePprECndList = _frePprECndList;
						if (IsFrePprSrtOListChanged()) writeFrePprSrtOList = _frePprSrtOList;
						break;
					}
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                //if (isNewWrite && _frePrtPSet.PrintPaperUseDivcd == 2)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                if ( _frePrtPSet.PrintPaperUseDivcd == 2 && _slipPrtKindList != null && _slipPrtKindList.Count > 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				{
					// �`�[�̐V�K�o�^���͓`�[����ݒ�̓o�^���s��
					List<SlipPrtSetWork> slipPrtSetList = FrePrtPSetAcs.CreateSlipPrtSet(_slipPrtKindList, _frePrtPSet, _prtItemGrpList);
					//status = _frePrtPSetAcs.WriteDBFrePrtPSet(ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, slipPrtSetList, isNewWrite);
                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, slipPrtSetList, null, isNewWrite );
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                //else if ( isNewWrite && _frePrtPSet.PrintPaperUseDivcd == 5 )
                else if ( _frePrtPSet.PrintPaperUseDivcd == 5 && _slipPrtKindList != null && _slipPrtKindList.Count > 0 )
                {
                    // �������̐V�K�o�^���͐���������p�^�[���ݒ�̓o�^���s��
                    List<DmdPrtPtnWork> dmdPrtPtnList = FrePrtPSetAcs.CreateDmdPrtPtnList( _frePrtPSet, _prtItemGrpList );
                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, null, dmdPrtPtnList, isNewWrite );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
                else
                {
                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, isNewWrite );
                }
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �摜�f�[�^�̍X�V
						UpdateImage();

						// �o�b�t�@�ɃR�s�[
						CopyPrtPosDataToBuffer();

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //// ���[�J���f�[�^�ۑ�
                        //status = _localDataAcs.WriteLocalFrePrtPSet(_frePrtPSet, _frePprECndList, _frePprSrtOList);
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    _errorStr = _localDataAcs.ErrorMessage;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //// �d���̏ꍇ�͌�ōēo�^���Ă��炤���b�Z�[�W
                        //if (isNewWrite)
                        //    _errorStr = _frePrtPSetAcs.ErrorMessage + Environment.NewLine + "���΂炭���Ă���ēx�ۑ����Ă��������B";
                        //else
                        //    _errorStr = _frePrtPSetAcs.ErrorMessage;
                        //break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                        if ( isNewWrite )
                        {
                            _errorStr = string.Format( "���[�h�c={0}�͊��ɓo�^����Ă��܂��B", _frePrtPSet.OutputFormFileName );
                        }
                        else
                        {
                            _errorStr = _frePrtPSetAcs.ErrorMessage;
                        }
                        break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
					}
					default:
					{
						_errorStr = _frePrtPSetAcs.ErrorMessage;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[�󎚈ʒu�ݒ�ۑ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �V�K�f�[�^�쐬����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prtFormId">���[ID</param>
		/// <param name="displayName">�o�͖���</param>
		/// <param name="prtItemGrpWork">�󎚍��ڃO���[�v</param>
		/// <remarks>
		/// <br>Note		: �V�K�f�[�^���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
        //public int CreateNewData(string enterpriseCode, string displayName, PrtItemGrpWork prtItemGrpWork)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        public int CreateNewData( string enterpriseCode, string prtFormId, string displayName, PrtItemGrpWork prtItemGrpWork )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// �󎚍��ڐݒ���擾
				List<FPSortInitWork> fPSortInitList;
				status = SearchPrtItemSet(prtItemGrpWork, out fPSortInitList);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// -------------------------------------------------
					// ���R���[�󎚈ʒu�ݒ�
					// -------------------------------------------------
					// �n���ꂽ�f�[�^��莩�R���[�󎚈ʒu�ݒ�𐶐�
					_frePrtPSet = CreateFrePrtPSetFromPrtItemGrp(prtItemGrpWork, enterpriseCode, prtFormId, displayName, prtItemGrpWork.FormFeedLineCount, prtItemGrpWork.CrCharCnt, null);


					// -------------------------------------------------
					// ���R���[���o����
					// -------------------------------------------------
					// �󎚍��ڐݒ��蒊�o�����𐶐�
					List<FrePprECnd> frePprECndList
						= CreateFrePprECndFromPrtItemSet(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo);

					// �\������ASC,�K�{���o�����敪DESC,���R���[���o�����}��ASC���Ń\�[�g
					frePprECndList.Sort(new FrePprECndCompare());

					// ���o�����̕\�����ʂ��̔�
					int displayOrder = 1;
					foreach (FrePprECnd frePprECnd in frePprECndList)
					{
						if (frePprECnd.NecessaryExtraCondCd == 1)
							frePprECnd.DisplayOrder = displayOrder++;
					}
					_frePprECndList = frePprECndList;


					// -------------------------------------------------
					// ���R���[�\�[�g����
					// -------------------------------------------------
					// �󎚍��ڐݒ���\�[�g���ʂ𐶐�
					List<FrePprSrtO> frePprSrtOList
						= CreateFrePprSrtO(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo, fPSortInitList);
					_frePprSrtOList = frePprSrtOList;


					// -------------------------------------------------
					// ���̑�
					// -------------------------------------------------
					// ActiveReport�\���v���p�e�B�ݒ�擾
					_aRCtrlDispList = GetDispPropertyList();

					// �������摜�����N���A
					_imageGroup	= null;
					_imgManage	= null;

					// �o�b�t�@�ɃR�s�[
					CopyPrtPosDataToBuffer();
				}

				// ���O�o�́i�����[�g�Łj
				_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit CreateNewData");
			}
			catch (Exception ex)
			{
				_errorStr = "�V�K�f�[�^�쐬�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �V�K�f�[�^�쐬�����i�������[�Q�ƐV�K�j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="frePrtGuideSearchRet">���R���[�K�C�h�������ʃN���X</param>
		/// <remarks>
		/// <br>Note		: �V�K�f�[�^���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int CreateNewData(string enterpriseCode, FrePrtGuideSearchRet frePrtGuideSearchRet)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				PrtItemGrpWork prtItemGrpWork = _prtItemGrpList.Find(
					delegate(PrtItemGrpWork prtItemGrp)
					{
						if (prtItemGrp.FreePrtPprItemGrpCd == frePrtGuideSearchRet.FreePrtPprItemGrpCd)
							return true;
						else
							return false;
					}
				);

				if (prtItemGrpWork != null)
				{
					FPprSchmGrWork fPprSchmGrWork = DBAndXMLDataMergeParts.CopyPropertyInClass<FPprSchmGrWork>(frePrtGuideSearchRet);

					List<FPprSchmCvWork> fPprSchmCvList;
					List<FPSortInitWork> fPSortInitList;
					List<FPECndInitWork> fPECndInitList;
					status = SearchPrtItemSetWithFPprSchmCv(prtItemGrpWork, fPprSchmGrWork, out fPprSchmCvList, out fPSortInitList, out fPECndInitList);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						SFANL08132CG cnv = new SFANL08132CG();
						string errMsg = string.Empty;
						ar.ActiveReport3 rpt = null;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki�@�ۗ��E�Ή��K�v�@SFANL08132C �\�[�X���肵�āAActiveReports3�Ń��R���p�C��
                        //// ����R���o�[�g�g�p�敪(0:��,1:�}�N��,2:�t�H���g�̂�)
                        //if (frePrtGuideSearchRet.SpecialConvtUseDivCd != 0)
                        //{
                        //    List<DmGuideSnt> dmGuideSntList;
                        //    DmPgMng dmPgMng;
                        //    // DM����R���o�[�g�p�f�[�^�擾����
                        //    status = SearchDMSpecialConvData(enterpriseCode, frePrtGuideSearchRet, out dmGuideSntList, out dmPgMng, out errMsg);

                        //    // DM�ē����R���o�[�g����
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        rpt = cnv.CvtExistingDMGuidanceLayout(frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.OutputFileClassId, _prtItemSetList, fPprSchmCvList, dmGuideSntList, dmPgMng.EffectiveMacroSign, frePrtGuideSearchRet.SpecialConvtUseDivCd, out errMsg);
                        //}
                        //else
                        //{
                        //    // �������C�A�E�g�R���o�[�g����
                        //    rpt = cnv.CvtExistingLayout(frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.OutputFileClassId, _prtItemSetList, fPprSchmCvList, out errMsg);
                        //}

                       
                        //status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki�@�ۗ��E�Ή��K�v�@SFANL08132C �\�[�X���肵�āAActiveReports3�Ń��R���p�C��
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/12 ADD
                        if ( frePrtGuideSearchRet.SpecialConvtUseDivCd != 0 )
                        {
                        }
                        else
                        {
                            // �������C�A�E�g�R���o�[�g����
                            rpt = cnv.CvtExistingLayout(frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.OutputFileClassId, _prtItemSetList, fPprSchmCvList, out errMsg);
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/12 ADD


						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rpt != null && string.IsNullOrEmpty(errMsg))
						{
							// �f�t�H���g�̗]���ݒ�
							rpt.PageSettings.Margins.Top	= ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.TopMargin);
							rpt.PageSettings.Margins.Bottom = ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.BottomMargin);
							rpt.PageSettings.Margins.Left	= ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.LeftMargin);
							rpt.PageSettings.Margins.Right	= ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.RightMargin);

							// Stream�ɕۑ�
							MemoryStream stream = new MemoryStream();
							rpt.SaveLayout(stream);


							// -------------------------------------------------
							// ���R���[�󎚈ʒu�ݒ�
							// -------------------------------------------------
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                            //_frePrtPSet = CreateFrePrtPSetFromPrtItemGrp(prtItemGrpWork, enterpriseCode, frePrtGuideSearchRet.DisplayName, frePrtGuideSearchRet.FormFeedLineCount, frePrtGuideSearchRet.CrCharCnt, stream.ToArray());
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                            _frePrtPSet = CreateFrePrtPSetFromPrtItemGrp( prtItemGrpWork, enterpriseCode, frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.DisplayName, frePrtGuideSearchRet.FormFeedLineCount, frePrtGuideSearchRet.CrCharCnt, stream.ToArray() );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
							// �I�v�V�����R�[�h���Z�b�g����
							_frePrtPSet.OptionCode = frePrtGuideSearchRet.OptionCode;


							// -------------------------------------------------
							// ���R���[���o����
							// -------------------------------------------------
							// �󎚍��ڐݒ��蒊�o�����𐶐�
							List<FrePprECnd> frePprECndList
								= CreateFrePprECndFromPrtItemSet(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo);

							// �����l�ݒ�}�X�^���}�[�W
							MergeFrePprECnd(frePprECndList, fPECndInitList);

							// �\������ASC,�K�{���o�����敪DESC,���R���[���o�����}��ASC���Ń\�[�g
							frePprECndList.Sort(new FrePprECndCompare());

							// ���o�����̕\�����ʂ��̔�
							int displayOrder = 1;
							foreach (FrePprECnd frePprECnd in frePprECndList)
							{
								if (frePprECnd.NecessaryExtraCondCd == 1)
									frePprECnd.DisplayOrder = displayOrder;
								
								displayOrder++;
							}
							_frePprECndList = frePprECndList;


							// -------------------------------------------------
							// ���R���[�\�[�g����
							// -------------------------------------------------
							// �󎚍��ڐݒ���\�[�g���ʂ𐶐�
							List<FrePprSrtO> frePprSrtOList
								= CreateFrePprSrtO(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo, fPSortInitList);
							_frePprSrtOList = frePprSrtOList;


							// -------------------------------------------------
							// ���̑�
							// -------------------------------------------------
							// ActiveReport�\���v���p�e�B�ݒ�擾
							_aRCtrlDispList = GetDispPropertyList();

							// �������摜�����N���A
							_imageGroup	= null;
							_imgManage	= null;

							// �o�b�t�@�ɃR�s�[
							CopyPrtPosDataToBuffer();
						}
						else
						{
							_errorStr = "�����f�[�^�̃R���o�[�g�����Ɏ��s���܂����B" + Environment.NewLine + errMsg;
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
						}
					}

					// ���O�o�́i�����[�g�Łj
					_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit CreateNewData");
				}
				else
				{
					_errorStr = "�Y������󎚍��ڃO���[�v������܂���B";
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
			}
			catch (Exception ex)
			{
				_errorStr = "�V�K�f�[�^�쐬�����i�������C�A�E�g�j�ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �f�[�^�ύX�`�F�b�N����
		/// </summary>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: �f�[�^���ύX����Ă��Ȃ����`�F�b�N���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public bool CheckDataChange()
		{
			// ���R���[�󎚈ʒu�ݒ�̃`�F�b�N
			if (_frePrtPSet != null && _buf_frePrtPSet != null)
			{
				if (!_buf_frePrtPSet.Equals(_frePrtPSet))
					return true;

				// �󎚈ʒu�f�[�^�̔�r
				if (!_frePrtPSet.EqualsPrintPosClassData(_buf_frePrtPSet.PrintPosClassData))
					return true;
			}

			if (IsFrePprECndListChanged())
				return true;

			if (IsFrePprSrtOListChanged())
				return true;

			return false;
		}

		/// <summary>
		/// �V�K�摜�f�[�^�Z�b�g����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="image">�摜�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �V�K�摜�f�[�^���摜�Ǘ��}�X�^�ŕێ����܂��B</br>
		/// <br>			: ��null���Z�b�g�����ꍇ�摜�̍폜�ƂȂ�܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void SetNewImageData(string enterpriseCode, Image image)
		{
            //if (image != null)
            //{
            //    _watermarkCmnCtrl.CreateNewWatermarkImgManage(enterpriseCode, image, out _imageGroup, out _imgManage);
            //    _frePrtPSet.TakeInImageGroupCd	= _imageGroup.TakeInImageGroupCd;
            //}
            //else
            //{
            //    _imageGroup	= null;
            //    _imgManage	= null;
            //    _frePrtPSet.TakeInImageGroupCd	= Guid.Empty;
            //}
		}

		/// <summary>
		/// �󎚈ʒu���o�b�t�@�ޔ�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���ݓW�J���Ă���󎚈ʒu�����o�b�t�@�ɑޔ����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void CopyPrtPosDataToBuffer()
		{
			if (_frePrtPSet != null)
				_buf_frePrtPSet = _frePrtPSet.Clone();

			if (_frePprECndList != null)
			{
				_buf_frePprECndList = new List<FrePprECnd>();
				foreach (FrePprECnd frePprECnd in _frePprECndList)
					_buf_frePprECndList.Add(frePprECnd.Clone());
			}

			if (_frePprSrtOList != null)
			{
				_buf_frePprSrtOList = new List<FrePprSrtO>();
				foreach (FrePprSrtO frePprSrtO in _frePprSrtOList)
					_buf_frePprSrtOList.Add(frePprSrtO.Clone());
			}

			if (_imageGroup != null)
				_buf_imageGroup = _imageGroup.Clone();

			if (_imgManage != null)
			{
				_buf_imgManage = _imgManage.Clone();
				if (_imgManage.TakeInImage != null)
					_buf_imgManage.TakeInImage = (Image)_imgManage.TakeInImage.Clone();
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �󎚍��ڐݒ茟������
		/// </summary>
		/// <param name="prtItemGrpWork">�󎚍��ڃO���[�v�}�X�^</param>
		/// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚍��ڐݒ���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchPrtItemSet(PrtItemGrpWork prtItemGrpWork, out List<FPSortInitWork> fPSortInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			fPSortInitList = new List<FPSortInitWork>();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// -------------------------------------------------
            //// ���[�J���f�[�^�擾�i�󎚍��ڌn�j
            //// -------------------------------------------------
            //// �X�V�`�F�b�N�̈בޔ�
            //DateTime updateDateTime = prtItemGrpWork.UpdateDateTime;

            //PrtItemGrpWork wkPrtItemGrpWork;
            //status = _localDataAcs.ReadLocalPrtItemGrpWork(prtItemGrpWork.FreePrtPprItemGrpCd, out wkPrtItemGrpWork, out _prtItemSetList, out fPSortInitList);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // �X�V���t���قȂ�ꍇ�͖��������R
            //    if (!updateDateTime.Equals(wkPrtItemGrpWork.UpdateDateTime))
            //        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			// -------------------------------------------------
			// �����[�g����
			// -------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// ���[�J���f�[�^���Â������͎擾�o���Ȃ��ꍇ�̓����[�e�B���O
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = _prtItemSetAcs.SearchPrtItemSetWork(prtItemGrpWork.FreePrtPprItemGrpCd, out _prtItemSetList, out fPSortInitList);
            //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //        // �擾�f�[�^�����[�J���ۑ�
            //        _localDataAcs.WriteLocalPrtItemGrpWork( prtItemGrpWork, _prtItemSetList, fPSortInitList );
            //    else
            //        _errorStr = _prtItemSetAcs.ErrorMessage;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            status = _prtItemSetAcs.SearchPrtItemSetWork( prtItemGrpWork.FreePrtPprItemGrpCd, out _prtItemSetList, out fPSortInitList );
            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                _errorStr = _prtItemSetAcs.ErrorMessage;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

			// �󎚍��ڃO���[�s���O���擾
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �������I�v�V�����f�[�^�폜����
				RemoveUnContactData(_prtItemSetList);

				_prtItemGroupingDispTitle = GetDispItemTitleList();
			}

			return status;
		}

		/// <summary>
		/// �󎚍��ڐݒ茟������
		/// </summary>
		/// <param name="prtItemGrpWork">�󎚍��ڃO���[�v�}�X�^</param>
		/// <param name="fPprSchmGrWork">���R���[�X�L�[�}�O���[�v�}�X�^</param>
		/// <param name="fPprSchmCvList">���R���[�X�L�[�}�R���o�[�g�}�X�^���X�g</param>
		/// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
		/// <param name="fPECndInitList">���R���[���o���������l�}�X�^���X�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚍��ڐݒ���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchPrtItemSetWithFPprSchmCv(PrtItemGrpWork prtItemGrpWork, FPprSchmGrWork fPprSchmGrWork, out List<FPprSchmCvWork> fPprSchmCvList, out List<FPSortInitWork> fPSortInitList, out List<FPECndInitWork> fPECndInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //bool isExistLclPrtItemGrp = false;
            //bool isExistLclFPprSchmGr = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
			fPprSchmCvList = new List<FPprSchmCvWork>();
			fPSortInitList = new List<FPSortInitWork>();
			fPECndInitList = new List<FPECndInitWork>();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// -------------------------------------------------
            //// ���[�J���f�[�^�擾�i�󎚍��ڌn�j
            //// -------------------------------------------------
            //// �X�V�`�F�b�N�̈בޔ�
            //DateTime updateDateTime = prtItemGrpWork.UpdateDateTime;

            //PrtItemGrpWork wkPrtItemGrpWork;
            //status = _localDataAcs.ReadLocalPrtItemGrpWork(prtItemGrpWork.FreePrtPprItemGrpCd, out wkPrtItemGrpWork, out _prtItemSetList, out fPSortInitList);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // �X�V���t���قȂ�ꍇ�͖��������R
            //    if (updateDateTime.Equals(wkPrtItemGrpWork.UpdateDateTime))
            //        isExistLclPrtItemGrp = true;
            //}

            //// -------------------------------------------------
            //// ���[�J���f�[�^�擾�i���R���[�X�L�[�}�n�j
            //// -------------------------------------------------
            //// �X�V�`�F�b�N�̈בޔ�
            //updateDateTime = fPprSchmGrWork.UpdateDateTime;

            //FPprSchmGrWork wkFPprSchmGrWork;
            //status = _localDataAcs.ReadLocalFPprSchmGrWork(fPprSchmGrWork.FreePrtPprSchmGrpCd, out wkFPprSchmGrWork, out fPprSchmCvList, out fPSortInitList, out fPECndInitList);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // �X�V���t���قȂ�ꍇ�͖��������R
            //    if (updateDateTime.Equals(wkFPprSchmGrWork.UpdateDateTime))
            //        isExistLclFPprSchmGr = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			// -------------------------------------------------
			// �����[�g����
			// -------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //if (!isExistLclPrtItemGrp && !isExistLclFPprSchmGr)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
			{
				List<FPSortInitWork> wkFPSortInitList;
				List<FPECndInitWork> wkFPECndInitList;
				status = _prtItemSetAcs.SearchPrtItemSetWithFPprSchmCv(prtItemGrpWork.FreePrtPprItemGrpCd, fPprSchmGrWork.FreePrtPprSchmGrpCd, out _prtItemSetList, out fPprSchmCvList, out wkFPSortInitList, out wkFPECndInitList);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���R���[�X�L�[�}�n
					fPSortInitList = wkFPSortInitList.FindAll(
							delegate(FPSortInitWork fPSortInit)
							{
								if (fPSortInit.FreePrtPprSchmGrpCd == fPprSchmGrWork.FreePrtPprSchmGrpCd)
									return true;
								else
									return false;
							}
						);

					fPECndInitList = wkFPECndInitList.FindAll(
							delegate(FPECndInitWork fPECndInit)
							{
								if (fPECndInit.FreePrtPprSchmGrpCd == fPprSchmGrWork.FreePrtPprSchmGrpCd)
									return true;
								else
									return false;
							}
						);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                    //// �擾�f�[�^�����[�J���ۑ��i�󎚍��ځj
                    //_localDataAcs.WriteLocalFPprSchmGrWork(fPprSchmGrWork, fPprSchmCvList, fPSortInitList, fPECndInitList);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

					// �󎚍��ڌn
					List<FPSortInitWork> writeFPSortInit = wkFPSortInitList.FindAll(
							delegate(FPSortInitWork fPSortInit)
							{
								if (fPSortInit.FreePrtPprSchmGrpCd == 0)
									return true;
								else
									return false;
							}
						);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                    //// �擾�f�[�^�����[�J���ۑ��i�󎚍��ځj
                    //_localDataAcs.WriteLocalPrtItemGrpWork(prtItemGrpWork, _prtItemSetList, writeFPSortInit);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
				}
				else
				{
					_errorStr = _prtItemSetAcs.ErrorMessage;
				}
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //else if (!isExistLclPrtItemGrp)
            //{
            //    status = _prtItemSetAcs.SearchPrtItemSetWork(prtItemGrpWork.FreePrtPprItemGrpCd, out _prtItemSetList, out fPSortInitList);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //        //// �擾�f�[�^�����[�J���ۑ��i�󎚍��ځj
            //        //_localDataAcs.WriteLocalPrtItemGrpWork(prtItemGrpWork, _prtItemSetList, fPSortInitList);
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            //    }
            //    else
            //    {
            //        _errorStr = _prtItemSetAcs.ErrorMessage;
            //    }
            //}
            //else if (!isExistLclFPprSchmGr)
            //{
            //    FPprSchmGrAcs fPprSchmGrAcs = new FPprSchmGrAcs();
            //    status = fPprSchmGrAcs.SearchFPprSchmCv(prtItemGrpWork.FreePrtPprItemGrpCd, new int[] { fPprSchmGrWork.FreePrtPprSchmGrpCd });
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        fPprSchmCvList = fPprSchmGrAcs.FPprSchmCvWorkList;
            //        if (fPprSchmGrAcs.FPSortInitWorkList != null)
            //            fPSortInitList = fPprSchmGrAcs.FPSortInitWorkList;
            //        if (fPprSchmGrAcs.FPECndInitWorkList != null)
            //            fPECndInitList = fPprSchmGrAcs.FPECndInitWorkList;

            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //        //// �擾�f�[�^�����[�J���ۑ��i���R���[�X�L�[�}�j
            //        //_localDataAcs.WriteLocalFPprSchmGrWork(fPprSchmGrWork, fPprSchmCvList, fPSortInitList, fPECndInitList);
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            //    }
            //    else
            //    {
            //        _errorStr = fPprSchmGrAcs.ErrorMessage;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			// �󎚍��ڃO���[�s���O���擾
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �������I�v�V�����f�[�^�폜����
				RemoveUnContactData(_prtItemSetList);

				_prtItemGroupingDispTitle = GetDispItemTitleList();
			}

			return status;
		}

        ///// <summary>
        ///// DM����R���o�[�g�p�f�[�^�擾����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="frePrtGuideSearchRet">���R���[�K�C�h��������</param>
        ///// <param name="dmGuideSntList">DM�ē����ݒ�}�X�^���X�g</param>
        ///// <param name="dmPgMng">DM�v���O�����Ǘ��}�X�^���X�g</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note		: DM�ē����֌W�̃f�[�^���擾���܂��B</br>
        ///// <br>Programmer	: 22024 ����@�_�u</br>
        ///// <br>Date		: 2007.05.10</br>
        ///// </remarks>
        //private int SearchDMSpecialConvData(string enterpriseCode, FrePrtGuideSearchRet frePrtGuideSearchRet, out List<DmGuideSnt> dmGuideSntList, out DmPgMng dmPgMng, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    errMsg			= string.Empty;
        //    dmGuideSntList	= new List<DmGuideSnt>();
        //    dmPgMng			= null;

        //    // -------------------------------------------------
        //    // DM�ē����ݒ�
        //    // -------------------------------------------------
        //    if (_dmGuideSntAcs == null) _dmGuideSntAcs = new DmGuideSntAcs();

        //    ArrayList wkList;
        //    status = _dmGuideSntAcs.DetailsSearch(out wkList, enterpriseCode, frePrtGuideSearchRet.PgId, frePrtGuideSearchRet.DmNo);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        dmGuideSntList = DBAndXMLDataMergeParts.CopyProperty<DmGuideSnt>(wkList);
        //        if (dmGuideSntList.Count > 0)
        //        {
        //            if (dmGuideSntList[0].LogicalDeleteCode != 0)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                errMsg = "���ɑ��[�����DM�ē����ݒ肪�폜����Ă��܂��B";
        //            }
        //        }
        //    }
        //    else
        //        errMsg = "DM�ē����ݒ�̌����Ɏ��s���܂����B";

        //    // -------------------------------------------------
        //    // DM�v���O�����Ǘ�
        //    // -------------------------------------------------
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if (_dmPgMngAcs == null) _dmPgMngAcs = new DmPgMngAcs();

        //        status = _dmPgMngAcs.Read(out dmPgMng, enterpriseCode, frePrtGuideSearchRet.PgId, frePrtGuideSearchRet.PgSequenceNo);
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            errMsg = "DM�v���O�����Ǘ��̓Ǎ��Ɏ��s���܂����B";
        //    }

        //    return status;
        //}

		/// <summary>
		/// �摜�X�V����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�摜���摜�T�[�o�[�֑��M���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void UpdateImage()
		{
            //if (_buf_frePrtPSet.TakeInImageGroupCd != _frePrtPSet.TakeInImageGroupCd)
            //{
            //    // �ȑO�ɉ摜��ݒ肵�Ă����ꍇ�́A�폜����
            //    if (_buf_frePrtPSet.TakeInImageGroupCd != null && _buf_frePrtPSet.TakeInImageGroupCd != Guid.Empty)
            //        _watermarkCmnCtrl.DeleteWatermark(_buf_imageGroup);

            //    if (_imageGroup != null && _imgManage != null)
            //        _watermarkCmnCtrl.WriteWatermarkImage(ref _imageGroup, ref _imgManage);
            //}
		}

		/// <summary>
		/// �摜��������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�摜���摜�T�[�o�[���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void SearchImage()
		{
            //if (_frePrtPSet.TakeInImageGroupCd != null && _frePrtPSet.TakeInImageGroupCd != Guid.Empty)
            //{
            //    int status = _watermarkCmnCtrl.GetWatermarkImage(_frePrtPSet.EnterpriseCode, _frePrtPSet.TakeInImageGroupCd);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        _imageGroup	= _watermarkCmnCtrl.ImageGroup;
            //        _imgManage	= _watermarkCmnCtrl.ImgManage;
            //    }
            //}
		}

		/// <summary>
		/// ���R���[�v���p�e�B�\�����擾����
		/// </summary>
		/// <returns>���R���[�v���p�e�B�\�����Dictionary</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�v���p�e�B�\�����̑S���擾�s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<ARCtrlPropertyDispInfo> GetDispPropertyList()
		{
			// ���[�g�p�敪�ɉ������t�@�C�����𐶐�
			string fileNm = ctARCtrlPropertyDispInfo_FileNm + ctExtendXML;

			List<ARCtrlPropertyDispInfo> aRCtrlDispList;
			if (File.Exists(fileNm))
				aRCtrlDispList = (List<ARCtrlPropertyDispInfo>)XmlByteSerializer.Deserialize(fileNm, typeof(List<ARCtrlPropertyDispInfo>));
			else
				aRCtrlDispList = new List<ARCtrlPropertyDispInfo>();

			if (!_freeSheetMngOpt)
			{
				// �Ǘ��Ҍ����������ꍇ�͈ꕔ�v���p�e�B�ύX�ݒ��s�Ƃ���
				aRCtrlDispList = aRCtrlDispList.FindAll(
					delegate(ARCtrlPropertyDispInfo dispInfo)
					{
						if (dispInfo.UserAdminFlag == 0)
							return true;
						else
							return false;
					}
				);
			}

			return aRCtrlDispList;
		}

		/// <summary>
		/// �󎚍��ڃO���[�v�\�����̎擾����
		/// </summary>
		/// <returns>�󎚍��ڃO���[�v�\������LIST</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڃO���[�v�\�����̂̑S���擾�s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<PrtItemGroupingDispTitle> GetDispItemTitleList()
		{
			List<PrtItemGroupingDispTitle> prtItemGroupingDispTitleList = new List<PrtItemGroupingDispTitle>();

			string fileNm = ctPrtItemGroupingDispTitle_FileName + ctExtendXML;
			if (File.Exists(fileNm))
				prtItemGroupingDispTitleList = (List<PrtItemGroupingDispTitle>)XmlByteSerializer.Deserialize(fileNm, typeof(List<PrtItemGroupingDispTitle>));
			else
				prtItemGroupingDispTitleList = new List<PrtItemGroupingDispTitle>();

			return prtItemGroupingDispTitleList;
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�}�[�W����
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="fPECndInitList">���R���[���o���������l�}�X�^</param>
		/// <remarks>
		/// <br>Note		: ���R���[���o�����ݒ�Ǝ��R���[���o���������l�̃}�[�W�������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void MergeFrePprECnd(List<FrePprECnd> frePprECndList, List<FPECndInitWork> fPECndInitList)
		{
			// �����l�ݒ�}�X�^���}�[�W
			if (frePprECndList != null && frePprECndList.Count > 0 && fPECndInitList != null)
			{
				foreach (FrePprECnd frePprECnd in frePprECndList)
				{
					FPECndInitWork fPECndInit = fPECndInitList.Find(
							delegate(FPECndInitWork fPECndInitWork)
							{
								if (fPECndInitWork.FrePrtPprExtraCondCd == frePprECnd.FrePrtPprExtraCondCd)
									return true;
								else
									return false;
							}
						);
					if (fPECndInit != null)
					{
						frePprECnd.DisplayOrder			= fPECndInit.DisplayOrder;
						frePprECnd.StExtraNumCode		= fPECndInit.StExtraNumCode;
						frePprECnd.EdExtraNumCode		= fPECndInit.EdExtraNumCode;
						frePprECnd.StExtraCharCode		= fPECndInit.StExtraCharCode;
						frePprECnd.EdExtraCharCode		= fPECndInit.EdExtraCharCode;
						frePprECnd.StExtraDateBaseCd	= fPECndInit.StExtraDateBaseCd;
						frePprECnd.StExtraDateSignCd	= fPECndInit.StExtraDateSignCd;
						frePprECnd.StExtraDateNum		= fPECndInit.StExtraDateNum;
						frePprECnd.StExtraDateUnitCd	= fPECndInit.StExtraDateUnitCd;
						frePprECnd.StartExtraDate		= fPECndInit.StartExtraDate;
						frePprECnd.EdExtraDateBaseCd	= fPECndInit.EdExtraDateBaseCd;
						frePprECnd.EdExtraDateSignCd	= fPECndInit.EdExtraDateSignCd;
						frePprECnd.EdExtraDateNum		= fPECndInit.EdExtraDateNum;
						frePprECnd.EdExtraDateUnitCd	= fPECndInit.EdExtraDateUnitCd;
						frePprECnd.EndExtraDate			= fPECndInit.EndExtraDate;
						frePprECnd.CheckItemCode1		= fPECndInit.CheckItemCode1;
						frePprECnd.CheckItemCode2		= fPECndInit.CheckItemCode2;
						frePprECnd.CheckItemCode3		= fPECndInit.CheckItemCode3;
						frePprECnd.CheckItemCode4		= fPECndInit.CheckItemCode4;
						frePprECnd.CheckItemCode5		= fPECndInit.CheckItemCode5;
						frePprECnd.CheckItemCode6		= fPECndInit.CheckItemCode6;
						frePprECnd.CheckItemCode7		= fPECndInit.CheckItemCode7;
						frePprECnd.CheckItemCode8		= fPECndInit.CheckItemCode8;
						frePprECnd.CheckItemCode9		= fPECndInit.CheckItemCode9;
						frePprECnd.CheckItemCode10		= fPECndInit.CheckItemCode10;
					}
				}
			}
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�}�[�W����
		/// </summary>
		/// <param name="baseFrePprECndList">�}�[�W�Ώێ��R���[���o�����ݒ�}�X�^</param>
		/// <param name="overWriteFrePprECndList">�㏑���Ώێ��R���[���o�����ݒ�}�X�^</param>
		/// <returns>�}�[�W�ςݎ��R���[���o�����ݒ�}�X�^</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ���Create�����f�[�^�Ɗ����f�[�^�̃}�[�W�������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprECnd> MergeFrePprECnd(List<FrePprECnd> baseFrePprECndList, List<FrePprECnd> overWriteFrePprECndList)
		{
			if (overWriteFrePprECndList == null) overWriteFrePprECndList = new List<FrePprECnd>();

			int maxDisplayOrder = 1;
			List<FrePprECnd> retList = new List<FrePprECnd>();
			foreach (FrePprECnd baseFrePprECnd in baseFrePprECndList)
			{
				int listIndex = overWriteFrePprECndList.FindIndex(
					delegate(FrePprECnd frePprECnd)
					{
						if ((baseFrePprECnd.EnterpriseCode			== frePprECnd.EnterpriseCode) &&
							(baseFrePprECnd.OutputFormFileName		== frePprECnd.OutputFormFileName) &&
							(baseFrePprECnd.UserPrtPprIdDerivNo		== frePprECnd.UserPrtPprIdDerivNo) &&
							(baseFrePprECnd.FrePrtPprExtraCondCd	== frePprECnd.FrePrtPprExtraCondCd))
							return true;
						else
							return false;
					});
				if (listIndex >= 0)
				{
					retList.Add(overWriteFrePprECndList[listIndex]);
					maxDisplayOrder = Math.Max(maxDisplayOrder, overWriteFrePprECndList[listIndex].DisplayOrder);
				}
				else
				{
					retList.Add(baseFrePprECnd);
					if (baseFrePprECnd.DisplayOrder < 999)
						maxDisplayOrder = Math.Max(maxDisplayOrder, baseFrePprECnd.DisplayOrder);
				}
			}

			foreach (FrePprECnd frePprECnd in retList)
			{
				if (frePprECnd.NecessaryExtraCondCd == 1 && frePprECnd.DisplayOrder == 999)
					frePprECnd.DisplayOrder = ++maxDisplayOrder;
			}

			return retList;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^�쐬����
		/// </summary>
		/// <param name="prtItemGrp">�󎚍��ڃO���[�v�}�X�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prtFormId"></param>
		/// <param name="displayName"></param>
		/// <param name="formFeedLineCount"></param>
		/// <param name="crCharCnt"></param>
		/// <param name="printPosClassData"></param>
		/// <returns>���R���[�󎚈ʒu�ݒ�</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڃO���[�v��莩�R���[�󎚍��ڐݒ��Create���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
        //private FrePrtPSet CreateFrePrtPSetFromPrtItemGrp(PrtItemGrpWork prtItemGrp, string enterpriseCode, string displayName, int formFeedLineCount, int crCharCnt, byte[] printPosClassData)
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        private FrePrtPSet CreateFrePrtPSetFromPrtItemGrp( PrtItemGrpWork prtItemGrp, string enterpriseCode, string prtFormId, string displayName, int formFeedLineCount, int crCharCnt, byte[] printPosClassData )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
        {
			FrePrtPSet frePrtPSet = new FrePrtPSet();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// �`�[����ݒ�}�X�^�ɓo�^����ۂɃL�[�ƂȂ�SlipPrtSetPaperId��24���̈�
            //// OutputFormFileName�ɐݒ肷����e��24���܂łƂ���
            //frePrtPSet.OutputFormFileName	= string.Format("{0:D4}_{1}", prtItemGrp.FreePrtPprItemGrpCd, enterpriseCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            frePrtPSet.OutputFormFileName = prtFormId;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			frePrtPSet.EnterpriseCode		= enterpriseCode;
			frePrtPSet.DisplayName			= displayName;
			frePrtPSet.FreePrtPprItemGrpCd	= prtItemGrp.FreePrtPprItemGrpCd;
			frePrtPSet.PrintPaperUseDivcd	= prtItemGrp.PrintPaperUseDivcd;
			frePrtPSet.ExtractionPgId		= prtItemGrp.ExtractionPgId;
			frePrtPSet.ExtractionPgClassId	= prtItemGrp.ExtractionPgClassId;
			frePrtPSet.OutputPgId			= prtItemGrp.OutputPgId;
			frePrtPSet.OutputPgClassId		= prtItemGrp.OutputPgClassId;
			frePrtPSet.DataInputSystem		= prtItemGrp.DataInputSystem;
			frePrtPSet.ExtraSectionKindCd	= prtItemGrp.ExtraSectionKindCd;
			frePrtPSet.ExtraSectionSelExist = prtItemGrp.ExtraSectionSelExist;
			frePrtPSet.FormFeedLineCount	= formFeedLineCount;
			frePrtPSet.CrCharCnt			= crCharCnt;
			frePrtPSet.FreePrtPprSpPrpseCd	= prtItemGrp.FreePrtPprSpPrpseCd;
			frePrtPSet.PrintPosClassData	= printPosClassData;

			if (prtItemGrp.PrintPaperUseDivcd == 1)
				frePrtPSet.PrintPaperDivCd	= prtItemGrp.FreePrtPprItemGrpCd;

			return frePrtPSet;
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�쐬����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <returns>���R���[���o�����ݒ�}�X�^���X�g</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚍��ڐݒ��莩�R���[���o�����ݒ��Create���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprECnd> CreateFrePprECndFromPrtItemSet(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
		{
			List<FrePprECnd> frePprECndList = new List<FrePprECnd>();
			foreach (PrtItemSetWork prtItemSet in _prtItemSetList)
			{
				if (prtItemSet.ExtraConditionDivCd != 0)
				{
					FrePprECnd frePprECnd = new FrePprECnd();
					frePprECnd.EnterpriseCode		= enterpriseCode;					// ��ƃR�[�h
					frePprECnd.OutputFormFileName	= outputFormFileName;				// �o�̓t�@�C����
					frePprECnd.UserPrtPprIdDerivNo	= userPrtPprIdDerivNo;				// ���[�U�[���[ID�}�ԍ�
					frePprECnd.FrePrtPprExtraCondCd = prtItemSet.FreePrtPaperItemCd;	// ���R���[���o�����}��
					frePprECnd.ExtraConditionDivCd	= prtItemSet.ExtraConditionDivCd;	// ���o�����敪
					frePprECnd.ExtraConditionTypeCd	= prtItemSet.ExtraConditionTypeCd;	// ���o�����^�C�v
					frePprECnd.ExtraConditionTitle	= prtItemSet.FreePrtPaperItemNm;	// ���o�����^�C�g��
					frePprECnd.DDName				= prtItemSet.DDName;				// DD����
					frePprECnd.DDCharCnt			= prtItemSet.DDCharCnt;				// DD����
					frePprECnd.ExtraCondDetailGrpCd = prtItemSet.ExtraCondDetailGrpCd;	// ���o�������׃O���[�v�R�[�h
					frePprECnd.StExtraDateBaseCd	= 2;								// ���o�J�n���t�i��j
					frePprECnd.EdExtraDateBaseCd	= 2;								// ���o�I�����t�i��j
					frePprECnd.DisplayOrder			= 999;
					frePprECnd.NecessaryExtraCondCd = prtItemSet.NecessaryExtraCondCd;	// �K�{���o�����敪
					frePprECnd.FileNm				= prtItemSet.FileNm;				// �t�@�C������
					frePprECnd.InputCharCnt			= prtItemSet.InputCharCnt;			// ���͌���
					frePprECndList.Add(frePprECnd);
				}
			}

			return frePprECndList;
		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^�}�[�W����
		/// </summary>
		/// <param name="baseFrePprSrtOList">�}�[�W�Ώێ��R���[�\�[�g����LIST</param>
		/// <param name="overWriteFrePprSrtOList">�㏑���Ώێ��R���[�\�[�g����LIST</param>
		/// <returns>�}�[�W�ςݎ��R���[�\�[�g����LIST</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚍��ڐݒ���Create�����f�[�^�Ɗ����f�[�^�̃}�[�W�������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprSrtO> MergeFrePprSrtO(List<FrePprSrtO> baseFrePprSrtOList, List<FrePprSrtO> overWriteFrePprSrtOList)
		{
			if (overWriteFrePprSrtOList == null) overWriteFrePprSrtOList = new List<FrePprSrtO>();
			List<FrePprSrtO> retList = new List<FrePprSrtO>();
			foreach (FrePprSrtO baseFrePprSrtO in baseFrePprSrtOList)
			{
				FrePprSrtO findFrePprSrtO = overWriteFrePprSrtOList.Find(
					delegate(FrePprSrtO frePprSrtO)
					{
						if ((baseFrePprSrtO.EnterpriseCode		== frePprSrtO.EnterpriseCode) &&
							(baseFrePprSrtO.OutputFormFileName	== frePprSrtO.OutputFormFileName) &&
							(baseFrePprSrtO.UserPrtPprIdDerivNo	== frePprSrtO.UserPrtPprIdDerivNo) &&
							(baseFrePprSrtO.SortingOrderCode	== frePprSrtO.SortingOrderCode))
							return true;
						else
							return false;
					}
				);

				if (findFrePprSrtO != null)
					retList.Add(findFrePprSrtO);
				else
					retList.Add(baseFrePprSrtO);
			}

			return retList;
		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^�쐬����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
		/// <returns>���R���[�\�[�g����LIST</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚍��ڐݒ��莩�R���[�\�[�g���ʂ�Create���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprSrtO> CreateFrePprSrtO(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, List<FPSortInitWork> fPSortInitList)
		{
			List<FrePprSrtO> frePprSrtOList = new List<FrePprSrtO>();
			foreach (FPSortInitWork fPSortInit in fPSortInitList)
			{
				FrePprSrtO frePprSrtO = new FrePprSrtO();
				frePprSrtO.EnterpriseCode		= enterpriseCode;					// ��ƃR�[�h
				frePprSrtO.OutputFormFileName	= outputFormFileName;				// �o�̓t�@�C����
				frePprSrtO.UserPrtPprIdDerivNo	= userPrtPprIdDerivNo;				// ���[�U�[���[ID�}�ԍ�
				frePprSrtO.SortingOrderCode		= fPSortInit.SortingOrderCode;		// �\�[�g���ʃR�[�h
				frePprSrtO.SortingOrder			= fPSortInit.SortingOrder;			// �\�[�g����
				frePprSrtO.FreePrtPaperItemNm	= fPSortInit.FreePrtPaperItemNm;	// ���R���[���ږ���
				frePprSrtO.DDName				= fPSortInit.DDName;				// DD����
				frePprSrtO.FileNm				= fPSortInit.FileNm;				// �t�@�C������
				frePprSrtO.SortingOrderDivCd	= fPSortInit.SortingOrderDivCd;		// �����~���敪
				frePprSrtOList.Add(frePprSrtO);
			}

			return frePprSrtOList;
		}

		/// <summary>
		/// ���R���[���o����LIST�ύX�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���R���[���o�����f�[�^���ύX����Ă��Ȃ����`�F�b�N���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private bool IsFrePprECndListChanged()
		{
			// ���R���[���o�����ݒ�̃`�F�b�N
			if (_frePprECndList != null && _buf_frePprECndList != null)
			{
				// LIST���̌������ύX����Ă��邩
				if (_frePprECndList.Count != _buf_frePprECndList.Count)
					return true;

				// LIST���̃f�[�^���ύX����Ă��邩
				foreach (FrePprECnd buf_frePprECnd in _buf_frePprECndList)
				{
					FrePprECnd findFrePprECnd = _frePprECndList.Find(
						delegate(FrePprECnd frePprECnd)
						{
							if ((buf_frePprECnd.EnterpriseCode == frePprECnd.EnterpriseCode) &&
								(buf_frePprECnd.OutputFormFileName == frePprECnd.OutputFormFileName) &&
								(buf_frePprECnd.UserPrtPprIdDerivNo == frePprECnd.UserPrtPprIdDerivNo) &&
								(buf_frePprECnd.FrePrtPprExtraCondCd == frePprECnd.FrePrtPprExtraCondCd))
							{
								return true;
							}
							else
							{
								return false;
							}
						}
					);

////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//					if (findFrePprECnd == null || !findFrePprECnd.Equals(buf_frePprECnd))
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
					if (findFrePprECnd == null || !findFrePprECnd.EqualsWithoutSystemDate(buf_frePprECnd))
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// ���R���[�\�[�g����LIST�ύX�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���R���[�\�[�g���ʃf�[�^���ύX����Ă��Ȃ����`�F�b�N���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private bool IsFrePprSrtOListChanged()
		{
			// ���R���[���o�����ݒ�̃`�F�b�N
			if (_frePprSrtOList != null && _buf_frePprSrtOList != null)
			{
				// LIST���̃f�[�^���ύX����Ă��邩
				foreach (FrePprSrtO buf_frePprSrtO in _buf_frePprSrtOList)
				{
					FrePprSrtO findFrePprSrtO = _frePprSrtOList.Find(
						delegate(FrePprSrtO frePprSrtO)
						{
							if ((buf_frePprSrtO.EnterpriseCode == frePprSrtO.EnterpriseCode) &&
								(buf_frePprSrtO.OutputFormFileName == frePprSrtO.OutputFormFileName) &&
								(buf_frePprSrtO.UserPrtPprIdDerivNo == frePprSrtO.UserPrtPprIdDerivNo) &&
								(buf_frePprSrtO.SortingOrderCode == frePprSrtO.SortingOrderCode))
							{
								return true;
							}
							else
							{
								return false;
							}
						}
					);

					if (findFrePprSrtO == null || !findFrePprSrtO.Equals(buf_frePprSrtO))
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// �������I�v�V�����f�[�^�폜����
		/// </summary>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ�LIST���̃I�v�V�����`�F�b�N���s���܂��B</br>
		/// <br>			: �������̃I�v�V�����p���ڂ�LIST���폜���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void RemoveUnContactData(List<PrtItemSetWork> prtItemSetList)
		{
			for (int ix = 0 ; ix != prtItemSetList.Count ; ix++)
			{
				PurchaseStatus status = PurchaseStatus.Uncontract;
				// �����V�X�e���̃`�F�b�N
				switch (prtItemSetList[ix].SystemDivCd)
				{
					case 1: status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF); break;
					case 2: status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK); break;
					case 3: status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS); break;
					default: status = PurchaseStatus.Contract; break;
				}

				if (status < PurchaseStatus.Contract)
				{
					prtItemSetList.Remove(prtItemSetList[ix]);
					ix--;
				}
				else
				{
					// �I�v�V�����R�[�h�̃`�F�b�N
					if (!string.IsNullOrEmpty(prtItemSetList[ix].OptionCode))
					{
						status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(prtItemSetList[ix].OptionCode);
						if (status < PurchaseStatus.Contract)
						{
							prtItemSetList.Remove(prtItemSetList[ix]);
							ix--;
						}
					}
				}
			}
		}
		#endregion
	}

	/// <summary>
	/// �󎚍��ڐݒ��r�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �󎚍��ڐݒ���\�[�g����ۂɎg�p����Compare�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class FrePprECndCompare : IComparer<FrePprECnd>
	{
		#region PublicMethod
		/// <summary>
		/// ��r����
		/// </summary>
		/// <param name="x">��r�Ώ�1</param>
		/// <param name="y">��r�Ώ�2</param>
		/// <returns>��r����</returns>
		public int Compare(FrePprECnd x, FrePprECnd y)
		{
			int retCompare = 0;
			retCompare = x.DisplayOrder - y.DisplayOrder;
			if (retCompare == 0)
			{
				retCompare = y.NecessaryExtraCondCd - x.NecessaryExtraCondCd;
				if (retCompare == 0)
				{
					retCompare = x.FrePrtPprExtraCondCd - y.FrePrtPprExtraCondCd;
				}
			}
			return retCompare;
		}
		#endregion
	}
}
