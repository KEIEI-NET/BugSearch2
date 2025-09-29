using System;
using System.IO;
using System.Text;
using System.Collections;
using System.IO.Compression;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

using ar=DataDynamics.ActiveReports;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒu���ւ̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.04</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	public class FrePrtPSetAcs
	{
		#region PrivateMember
		// �󎚈ʒu�ݒ�n�����[�g�C���^�[�t�F�[�X
		private IFrePrtPSetDB	_iFrePrtPSetDB;
		// �G���[���b�Z�[�W
		private string			_errorStr;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public FrePrtPSetAcs()
		{
			_iFrePrtPSetDB	= MediationFrePrtPSetDB.GetFrePrtPSetDB();
		}
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���O�o�͏���
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="logMessage">���O���b�Z�[�W</param>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���O���b�Z�[�W��ۑ����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		internal void WriteLog(string enterpriseCode, string employeeCode, string logMessage)
		{
			_iFrePrtPSetDB.WriteLog(enterpriseCode, employeeCode, logMessage);
		}

		/// <summary>
		/// ���[�U�[���[ID�}�ԍ��擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <returns>���[�U�[���[ID�}�ԍ�</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu���̎}�ԍ����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int GetUserPrtPprIdDerivNo(string enterpriseCode, string outputFormFileName)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// �ŏI���[�U�[���[ID�}�ԍ��擾����
            //int userPrtPprIdDerivNo = _iFrePrtPSetDB.GetLastUserPrtPprIdDerivNo(enterpriseCode, outputFormFileName);

            //return ++userPrtPprIdDerivNo;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // �}�Ԃ̓[���Œ�
            return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�Ǎ�����
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <param name="frePprECndList">���R���[���o����LIST</param>
		/// <param name="frePprSrtOList">���R���[�\�[�g����LIST</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int ReadDBFrePrtPSet(ref FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			frePprECndList	= new List<FrePprECnd>();
			frePprSrtOList	= new List<FrePprSrtO>();

			try
			{
				object retObj;
				bool msgDiv;
				byte[] printPosClassData;
				string errMsg;
				// �����[�e�B���O
				status = _iFrePrtPSetDB.Read(
					frePrtPSet.EnterpriseCode,
					frePrtPSet.OutputFormFileName,
					frePrtPSet.UserPrtPprIdDerivNo,
					out retObj,
					out printPosClassData,
					out msgDiv,
					out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList customRetList = (CustomSerializeArrayList)retObj;
						for (int ix = 0 ; ix != customRetList.Count ; ix++)
						{
							ArrayList retList = (ArrayList)customRetList[ix];
							if (retList[0] is FrePrtPSetWork)
							{
								frePrtPSet = (FrePrtPSet)DBAndXMLDataMergeParts.CopyPropertyInClass(retList[0], typeof(FrePrtPSet));
								frePrtPSet.PrintPosClassData = printPosClassData;

								FrePrtSettingController.DecryptPrintPosClassData(frePrtPSet);
							}
							else if (retList[0] is FrePprECndWork)
							{
								ArrayList wkList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(FrePprECnd));
								frePprECndList.AddRange((FrePprECnd[])wkList.ToArray(typeof(FrePprECnd)));
							}
							else if (retList[0] is FrePprSrtOWork)
							{
								ArrayList wkList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(FrePprSrtO));
								frePprSrtOList.AddRange((FrePprSrtO[])wkList.ToArray(typeof(FrePprSrtO)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorStr = "���R���[�󎚈ʒu�ݒ�̓Ǎ��Ɏ��s���܂����B";
						_errorStr += "\r\n" + "�w�肳�ꂽ�f�[�^�͑��݂��܂���B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "�u���R���[�󎚈ʒu�ݒ�v�f�[�^�̎擾�Ɏ��s���܂����B\r\n\r\n*�ڍ�=" + errMsg;
						else
							_errorStr = "���R���[�󎚈ʒu�ݒ�̓Ǎ��Ɏ��s���܂����B";
						break;
					}
					default:
					{
						_errorStr = "���R���[�󎚈ʒu�ݒ�̓Ǎ��Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[�󎚈ʒu�ݒ�̓Ǎ������ɂė�O���������܂����B";
				_errorStr += "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ菑�����ݏ���
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <param name="frePprECndList">���R���[���o����LIST</param>
		/// <param name="frePprSrtOList">���R���[�\�[�g����LIST</param>
		/// <param name="isNewWrite">�V�K�o�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu����o�^���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int WriteDBFrePrtPSet(ref FrePrtPSet frePrtPSet, ref List<FrePprECnd> frePprECndList, ref List<FrePprSrtO> frePprSrtOList, bool isNewWrite)
		{
            //return WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, null, isNewWrite );
            return WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, null, null, isNewWrite );
        }

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ菑�����ݏ���
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <param name="frePprECndList">���R���[���o����LIST</param>
		/// <param name="frePprSrtOList">���R���[�\�[�g����LIST</param>
		/// <param name="slipPrtSetList">�`�[����ݒ�LIST</param>
        /// <param name="dmdPrtPtnList">����������p�^�[���ݒ�LIST</param>
		/// <param name="isNewWrite">�V�K�o�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu����o�^���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public int WriteDBFrePrtPSet(ref FrePrtPSet frePrtPSet, ref List<FrePprECnd> frePprECndList, ref List<FrePprSrtO> frePprSrtOList, List<SlipPrtSetWork> slipPrtSetList, bool isNewWrite)
        public int WriteDBFrePrtPSet(ref FrePrtPSet frePrtPSet, ref List<FrePprECnd> frePprECndList, ref List<FrePprSrtO> frePprSrtOList, List<SlipPrtSetWork> slipPrtSetList, List<DmdPrtPtnWork> dmdPrtPtnList, bool isNewWrite)
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// ������ �p�����[�^�̍쐬 ������
				// �p�����[�^�pCustomSerializeArrayList���쐬
				CustomSerializeArrayList writeList = new CustomSerializeArrayList();

				// �`�[����ݒ�LIST�i�`�[�̐V�K�o�^�������珈���j
				if (slipPrtSetList != null && slipPrtSetList.Count > 0)
				{
					ArrayList slipPrtSetWorkList = new ArrayList(slipPrtSetList);
					writeList.Add(slipPrtSetWorkList);
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                // ����������p�^�[���ݒ�LIST�i�������̐V�K�o�^�������珈���j
                if ( dmdPrtPtnList != null && dmdPrtPtnList.Count > 0 )
                {
                    ArrayList dmdPrtPtnWorkList = new ArrayList( dmdPrtPtnList );
                    writeList.Add( dmdPrtPtnWorkList );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
				
				// ���R���[�󎚈ʒu�ݒ�}�X�^
				byte[] buffPrintPosClassData = frePrtPSet.PrintPosClassData;
				// �o�C�i���f�[�^�̈Í���
				FrePrtSettingController.EncryptPrintPosClassData(frePrtPSet);
				ArrayList frePrtPSetWorkList = new ArrayList();
				frePrtPSetWorkList.Add((FrePrtPSetWork)DBAndXMLDataMergeParts.CopyPropertyInClass(frePrtPSet, typeof(FrePrtPSetWork)));
				writeList.Add(frePrtPSetWorkList);
				
				// ���R���[���o�����ݒ�LIST
				if (frePprECndList != null && frePprECndList.Count > 0)
				{
					ArrayList frePprECndWorkList = DBAndXMLDataMergeParts.CopyPropertyInArray(frePprECndList.ToArray(), typeof(FrePprECndWork));
					writeList.Add(frePprECndWorkList);
				}
				
				// ���R���[�\�[�g����LIST
				if (frePprSrtOList != null && frePprSrtOList.Count > 0)
				{
					ArrayList frePprSrtOWorkList = DBAndXMLDataMergeParts.CopyPropertyInArray(frePprSrtOList.ToArray(), typeof(FrePprSrtOWork));
					writeList.Add(frePprSrtOWorkList);
				}
				object writeObj = (object)writeList;

				// �����[�e�B���O
				bool msgDiv;
				string errMsg;
				status = _iFrePrtPSetDB.Write(ref writeObj, frePrtPSet.PrintPosClassData, isNewWrite, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						writeList = (CustomSerializeArrayList)writeObj;
						for (int ix = 0 ; ix != writeList.Count ; ix++)
						{
							ArrayList wkList = (ArrayList)writeList[ix];
							if (wkList[0] is FrePrtPSetWork)
							{
								frePrtPSet = (FrePrtPSet)DBAndXMLDataMergeParts.CopyPropertyInClass(wkList[0], typeof(FrePrtPSet));
								frePrtPSet.PrintPosClassData	= buffPrintPosClassData;
							}
							else if (wkList[0] is FrePprECndWork)
							{
								frePprECndList.Clear();
								wkList = DBAndXMLDataMergeParts.CopyPropertyInList(wkList, typeof(FrePprECnd));
								frePprECndList.AddRange((FrePprECnd[])wkList.ToArray(typeof(FrePprECnd)));
							}
							else if (wkList[0] is FrePprSrtOWork)
							{
								frePprSrtOList.Clear();
								wkList = DBAndXMLDataMergeParts.CopyPropertyInList(wkList, typeof(FrePprSrtO));
								frePprSrtOList.AddRange((FrePprSrtO[])wkList.ToArray(typeof(FrePprSrtO)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					{
						_errorStr = "���ɑ��[�����X�V����Ă��܂��B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						_errorStr = "���ɑ��[�����폜����Ă��܂��B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "�u���R���[�󎚈ʒu�ݒ�v�f�[�^�̕ۑ��Ɏ��s���܂����B\r\n\r\n*�ڍ�=" + errMsg;
						else
							_errorStr = "���R���[�󎚈ʒu�ݒ�̕ۑ��Ɏ��s���܂����B";
						break;
					}
					default:
					{
						_errorStr = "���R���[�󎚈ʒu�ݒ�̕ۑ������Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[�󎚈ʒu�ݒ�̕ۑ������ɂė�O���������܂����B";
				_errorStr += "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// ���R���[���o��������LIST�擾�����i�S���j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="frePExCndDList">���R���[���o��������LIST</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���o�������׃��[�N�}�X�^�z���S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchFrePExCndDList(string enterpriseCode, out List<FrePExCndD> frePExCndDList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			frePExCndDList = null;

			try
			{
				// �����[�e�B���O
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iFrePrtPSetDB.SearchFrePExCndD(enterpriseCode, ConstantManagement.LogicalMode.GetData0, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						ArrayList wkFrePExCndDList = DBAndXMLDataMergeParts.CopyPropertyInArray((FrePExCndDWork[])retObj, typeof(FrePExCndD));
						frePExCndDList = new List<FrePExCndD>((FrePExCndD[])wkFrePExCndDList.ToArray(typeof(FrePExCndD)));
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "�u���R���[���o�������ׁv�f�[�^�̕ۑ��Ɏ��s���܂����B\r\n\r\n*�ڍ�=" + errMsg;
						else
							_errorStr = "���R���[���o�������ׂ̌����Ɏ��s���܂����B";
						break;
					}
					default:
					{
						_errorStr = "���R���[���o�������ׂ̌����Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[���o�������ׂ̌��������ɂė�O���������܂����B";
				_errorStr += "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region PublicStaticMethod
		/// <summary>
		/// �`�[����ݒ�LIST�쐬����
		/// </summary>
		/// <param name="slipPrtKindList">�`�[������LIST</param>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <param name="prtItemGrpList">�󎚍��ڃO���[�v�}�X�^���X�g</param>
		/// <returns>�`�[����ݒ�LIST</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚈ʒu�ݒ���`�[����ݒ��Create���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public static List<SlipPrtSetWork> CreateSlipPrtSet(List<int> slipPrtKindList, FrePrtPSet frePrtPSet, List<PrtItemGrpWork> prtItemGrpList)
		{
			List<SlipPrtSetWork> slipPrtSetList = new List<SlipPrtSetWork>();

			// �󎚍��ڃO���[�v�R�[�h���擾
			PrtItemGrpWork prtItemGrpWork = prtItemGrpList.Find(
					delegate(PrtItemGrpWork wkPrtItemGrpWork)
					{
						if (wkPrtItemGrpWork.FreePrtPprItemGrpCd == frePrtPSet.FreePrtPprItemGrpCd)
							return true;
						else
							return false;
					}
				);

			ar.ActiveReport3 rpt = new ar.ActiveReport3();
			using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
			{
				rpt.LoadLayout(stream);

				foreach (int slipPrtKind in slipPrtKindList)
				{
					SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
					// �V�K�o�^�p�Ȃ̂ŋ��ʃt�@�C���w�b�_�[�͊�ƃR�[�h�ȊO�ݒ肵�Ȃ�
					slipPrtSetWork.EnterpriseCode		= frePrtPSet.EnterpriseCode;		// ��ƃR�[�h
					slipPrtSetWork.SlipPrtKind			= slipPrtKind;						// �`�[���
					slipPrtSetWork.DataInputSystem		= frePrtPSet.DataInputSystem;		// �f�[�^���̓V�X�e��
					// �`�[����ݒ�p���[ID
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                    //slipPrtSetWork.SlipPrtSetPaperId	= frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/02/19 ADD
                    slipPrtSetWork.SlipPrtSetPaperId = GetPaperId( slipPrtKind, frePrtPSet );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/02/19 ADD
					slipPrtSetWork.OutputPgId			= frePrtPSet.OutputPgId;			// �o�̓v���O����ID
					slipPrtSetWork.OutputPgClassId		= frePrtPSet.OutputPgClassId;		// �o�̓v���O�����N���XID
					slipPrtSetWork.OutputFormFileName	= frePrtPSet.OutputFormFileName;	// �o�̓t�@�C����
					slipPrtSetWork.OutConfimationMsg	= frePrtPSet.OutConfimationMsg;		// �o�͊m�F���b�Z�[�W
					slipPrtSetWork.OptionCode			= frePrtPSet.OptionCode;			// �I�v�V�����R�[�h
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //slipPrtSetWork.ExtractionPgId		= frePrtPSet.ExtractionPgId;		// ���o�v���O����ID
                    //slipPrtSetWork.ExtractionPgClassId	= frePrtPSet.ExtractionPgClassId;	// ���o�v���O�����N���XID
                    //slipPrtSetWork.UserPrtPprIdDerivNo	= frePrtPSet.UserPrtPprIdDerivNo;	// ���[�U�[���[ID�}�ԍ�
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					slipPrtSetWork.SlipComment			= frePrtPSet.DisplayName;			// �`�[�R�����g
					slipPrtSetWork.PrtCirculation		= 1;								// �������
					//slipPrtSetWork.PrinterMngNo			= 1;								// �v�����^�Ǘ�No
					slipPrtSetWork.PrtPreviewExistCode	= 0;								// ����v���r���L���敪
					slipPrtSetWork.SlipFontName			= "�l�r ����";						// �`�[�t�H���g����
					slipPrtSetWork.CopyCount			= 1;								// ���ʖ���
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 DEL
                    //slipPrtSetWork.TitleName1			= frePrtPSet.DisplayName;			// �^�C�g��1
                    //slipPrtSetWork.TitleName2			= frePrtPSet.DisplayName;			// �^�C�g��2
                    //slipPrtSetWork.TitleName3			= frePrtPSet.DisplayName;			// �^�C�g��3
                    //slipPrtSetWork.TitleName4			= frePrtPSet.DisplayName;			// �^�C�g��4
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
                    slipPrtSetWork.TitleName1 = GetTitle( slipPrtKind, frePrtPSet ); // �^�C�g��1
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
					slipPrtSetWork.SpecialPurpose1		= "20";								// ����p�r1
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                    //slipPrtSetWork.SpecialPurpose2 = frePrtPSet.UserPrtPprIdDerivNo.ToString(); // ����p�r2
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 DEL
					slipPrtSetWork.EnterpriseNamePrtCd	= 0;								// ���Ж�����敪
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //slipPrtSetWork.CustTelNoPrtDivCd	= 1;								// ���Ӑ�d�b�ԍ��󎚋敪�i0:�󎚂��Ȃ�,1:�󎚂���j
                    //slipPrtSetWork.MainWorkLinePrtDivCd	= 1;								// ���ƍs�󎚋敪�i0:���,1:�󎚁j
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					if (prtItemGrpWork != null)
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //slipPrtSetWork.LinkSlipDataInputSys	= prtItemGrpWork.LinkSlipDataInputSys;	// �����N�`�[�f�[�^���̓V�X�e��
                        //slipPrtSetWork.LinkSlipPrtKind		= prtItemGrpWork.LinkSlipPrtKind;		// �����N�`�[������
                        //slipPrtSetWork.LinkSlipPrtSetPprId	= prtItemGrpWork.LinkSlipPrtSetPprId;	// �����N�`�[����ݒ�p���[ID
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
                    slipPrtSetWork.DetailRowCount = frePrtPSet.FormFeedLineCount; // ���׍s��
                    slipPrtSetWork.ReissueMark = "�Ĕ��s";
                    slipPrtSetWork.HonorificTitle = "�l";
                    slipPrtSetWork.RefConsTaxDivCd = 1;
                    slipPrtSetWork.RefConsTaxPrtNm = "�Q�l�����";
                    slipPrtSetWork.ConsTaxPrtCd = 1; // ?
                    slipPrtSetWork.ConsTaxPrtCdRF = 1; // ?
                    slipPrtSetWork.TimePrintDivCd = 1;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD

					if (rpt != null)
					{
						// ��]��
						slipPrtSetWork.TopMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Top), 0);
						// ���]��
						slipPrtSetWork.LeftMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Left), 0);
						// ���]��
						slipPrtSetWork.BottomMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Bottom), 0);
						// �E�]��
						slipPrtSetWork.RightMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Right), 0);
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 ADD
                    switch ( slipPrtKind )
                    {
                        // ���Ϗ�
                        case 10:
                            {
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "�i��", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BL����", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "�W�����i", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "SalesPrice", "����", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "Cost", "����", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesEmployee", "�S����", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "FrontEmployee", "�󒍎�", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "SalesInput", "���s��", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "SalesOrderDiv", "���}�[�N(*)", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        // �d���ԕi
                        case 40:
                            {
                            }
                            break;
                        // ����
                        case 30:
                        // ��
                        case 120:
                        // �ݏo
                        case 130:
                        // ����
                        case 140:
                            {
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "�i��", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BL����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "�W�����i", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "SalesPrice", "����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "Cost", "����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesEmployee", "�S����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "FrontEmployee", "�󒍎�", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "SalesInput", "���s��", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "SalesOrderDiv", "���}�[�N(*)", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        // �t�n�d�`�[
                        case 160:
                            {
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "�i��", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BL����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "�W�����i", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "SalesPrice", "����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "Cost", "����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesEmployee", "�S����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "FrontEmployee", "�󒍎�", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "SalesInput", "���s��", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "SalesOrderDiv", "���}�[�N(*)", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        // �݌Ɉړ�
                        case 150:
                            {
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "�i��", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BL����", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "�W�����i", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice1", "�W�����i", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "Cost", "����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "SalesEmployee", "�S����", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesInput", "���s��", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "", "", 0 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "", "", 0 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "", "", 0 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        default:
                            break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 ADD

					slipPrtSetList.Add(slipPrtSetWork);
				}
				stream.Close();
			}

			return slipPrtSetList;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
        /// <summary>
        /// �`�[ID�擾����
        /// </summary>
        /// <param name="slipPrtKind"></param>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private static string GetPaperId( int slipPrtKind, FrePrtPSet frePrtPSet )
        {
            //------------------------------------------------------
            // �`�[����p�^�[���ݒ�̒��[ID��Ԃ��܂��B
            //------------------------------------------------------
            switch ( slipPrtKind )
            {
                // ����
                case 30:
                default:
                    return frePrtPSet.OutputFormFileName;
                // ��
                case 120:
                    return GetPaperIdProc( "J", frePrtPSet.OutputFormFileName );
                // �ݏo
                case 130:
                    return GetPaperIdProc( "K", frePrtPSet.OutputFormFileName );
                // ����
                case 140:
                    return GetPaperIdProc( "M", frePrtPSet.OutputFormFileName );
                // ���Ϗ�
                case 10:
                // �d���ԕi
                case 40:
                // �t�n�d�`�[
                case 160:
                // �݌Ɉړ�
                case 150:
                    return frePrtPSet.OutputFormFileName;
            }
        }
        /// <summary>
        /// �`�[ID�擾�����T�u
        /// </summary>
        /// <param name="head"></param>
        /// <param name="originName"></param>
        /// <returns></returns>
        private static string GetPaperIdProc( string head, string originName )
        {
            // A�Ŏn�܂�ꍇ�̂�J,K,M�Ȃǂƍ����ւ���
            if ( originName.StartsWith( "A" ) )
            {
                return (head + originName.Substring( 1, originName.Length - 1 ));
            }
            else
            {
                return originName;
            }
        }
        /// <summary>
        /// �`�[�^�C�g���i�����l�j�擾����
        /// </summary>
        /// <param name="slipPrtKind"></param>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private static string GetTitle( int slipPrtKind, FrePrtPSet frePrtPSet )
        {
            switch ( slipPrtKind )
            {
                // ���Ϗ�
                case 10:
                    return "���Ϗ�";
                // �d���ԕi
                case 40:
                    return "�ԕi�`�[";
                // ����
                case 30:
                default:
                    return "�[�i��";
                // ��
                case 120:
                    return "�󒍓`�[";
                // �ݏo
                case 130:
                    return "�ݏo�`�[";
                // ����
                case 140:
                    return "���ϓ`�[";
                // �t�n�d�`�[
                case 160:
                    return "�t�n�d�`�[";
                // �݌Ɉړ�
                case 150:
                    return "�݌Ɉړ��`�[";
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        /// <summary>
        /// �`�[�^�C�v�ʐݒ荀�ڂ̃Z�b�g����
        /// </summary>
        /// <param name="slipPrtSetWork"></param>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="printDiv"></param>
        private static void ReflectSlipPrtSetEachSlipTypeCol( ref SlipPrtSetWork slipPrtSetWork, int index, string id, string name, int printDiv )
        {
            switch ( index )
            {
                case 1:
                    {
                        slipPrtSetWork.EachSlipTypeColId1 = id;
                        slipPrtSetWork.EachSlipTypeColNm1 = name;
                        slipPrtSetWork.EachSlipTypeColPrt1 = printDiv;
                    }
                    break;
                case 2:
                    {
                        slipPrtSetWork.EachSlipTypeColId2 = id;
                        slipPrtSetWork.EachSlipTypeColNm2 = name;
                        slipPrtSetWork.EachSlipTypeColPrt2 = printDiv;
                    }
                    break;
                case 3:
                    {
                        slipPrtSetWork.EachSlipTypeColId3 = id;
                        slipPrtSetWork.EachSlipTypeColNm3 = name;
                        slipPrtSetWork.EachSlipTypeColPrt3 = printDiv;
                    }
                    break;
                case 4:
                    {
                        slipPrtSetWork.EachSlipTypeColId4 = id;
                        slipPrtSetWork.EachSlipTypeColNm4 = name;
                        slipPrtSetWork.EachSlipTypeColPrt4 = printDiv;
                    }
                    break;
                case 5:
                    {
                        slipPrtSetWork.EachSlipTypeColId5 = id;
                        slipPrtSetWork.EachSlipTypeColNm5 = name;
                        slipPrtSetWork.EachSlipTypeColPrt5 = printDiv;
                    }
                    break;
                case 6:
                    {
                        slipPrtSetWork.EachSlipTypeColId6 = id;
                        slipPrtSetWork.EachSlipTypeColNm6 = name;
                        slipPrtSetWork.EachSlipTypeColPrt6 = printDiv;
                    }
                    break;
                case 7:
                    {
                        slipPrtSetWork.EachSlipTypeColId7 = id;
                        slipPrtSetWork.EachSlipTypeColNm7 = name;
                        slipPrtSetWork.EachSlipTypeColPrt7 = printDiv;
                    }
                    break;
                case 8:
                    {
                        slipPrtSetWork.EachSlipTypeColId8 = id;
                        slipPrtSetWork.EachSlipTypeColNm8 = name;
                        slipPrtSetWork.EachSlipTypeColPrt8 = printDiv;
                    }
                    break;
                case 9:
                    {
                        slipPrtSetWork.EachSlipTypeColId9 = id;
                        slipPrtSetWork.EachSlipTypeColNm9 = name;
                        slipPrtSetWork.EachSlipTypeColPrt9 = printDiv;
                    }
                    break;
                case 10:
                    {
                        slipPrtSetWork.EachSlipTypeColId10 = id;
                        slipPrtSetWork.EachSlipTypeColNm10 = name;
                        slipPrtSetWork.EachSlipTypeColPrt10 = printDiv;
                    }
                    break;
                default:
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
        /// <summary>
        /// ����������p�^�[���ݒ�LIST�쐬����
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="prtItemGrpList">�󎚍��ڃO���[�v�}�X�^���X�g</param>
        /// <returns>����������p�^�[���ݒ�LIST</returns>
        /// <remarks>
        /// <br>Note         : ���R���[�󎚈ʒu�ݒ��萿��������p�^�[���ݒ��Create���܂��B</br>
        /// <br>               �@�Ȃ��A�ԋp�l��List�ɂȂ��Ă���͓̂`�[����ݒ�쐬���\�b�h�ɍ��킹��ׂŁA</br>
        /// <br>               �@���ۂɂ͂P���R�[�h�����������܂���B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2007.06.11</br>
        /// </remarks>
        public static List<DmdPrtPtnWork> CreateDmdPrtPtnList( FrePrtPSet frePrtPSet, List<PrtItemGrpWork> prtItemGrpList )
        {
            List<DmdPrtPtnWork> dmdPrtPtnWorkList = new List<DmdPrtPtnWork>();

            // �󎚍��ڃO���[�v�R�[�h���擾
            PrtItemGrpWork prtItemGrpWork = prtItemGrpList.Find(
                    delegate( PrtItemGrpWork wkPrtItemGrpWork )
                    {
                        if ( wkPrtItemGrpWork.FreePrtPprItemGrpCd == frePrtPSet.FreePrtPprItemGrpCd )
                            return true;
                        else
                            return false;
                    }
                );

            ar.ActiveReport3 rpt = new ar.ActiveReport3();
            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            {
                rpt.LoadLayout( stream );

                DmdPrtPtnWork dmdPrtPtnWork = new DmdPrtPtnWork();
                // �V�K�o�^�p�Ȃ̂ŋ��ʃt�@�C���w�b�_�[�͊�ƃR�[�h�ȊO�ݒ肵�Ȃ�
                dmdPrtPtnWork.EnterpriseCode = frePrtPSet.EnterpriseCode;		// ��ƃR�[�h
                dmdPrtPtnWork.SlipPrtKind = frePrtPSet.FreePrtPprSpPrpseCd;     // �`�[�����ʁi����������ʂ��i�[�j
                dmdPrtPtnWork.DataInputSystem = frePrtPSet.DataInputSystem;		// �f�[�^���̓V�X�e��
                // �`�[����ݒ�p���[ID
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 DEL
                //dmdPrtPtnWork.SlipPrtSetPaperId = frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 ADD
                dmdPrtPtnWork.SlipPrtSetPaperId = frePrtPSet.OutputFormFileName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 ADD
                dmdPrtPtnWork.OutputFormFileName = frePrtPSet.OutputFormFileName;	// �o�̓t�@�C����
                dmdPrtPtnWork.SlipComment = frePrtPSet.DisplayName;			// �`�[�R�����g
                dmdPrtPtnWork.CopyCount = 1;								// ���ʖ���

                if ( rpt != null )
                {
                    // ��]��
                    dmdPrtPtnWork.TopMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Top ), 1 );
                    // ���]��
                    dmdPrtPtnWork.LeftMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Left ), 1 );
                    // ���]��
                    dmdPrtPtnWork.BottomMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Bottom ), 1 );
                    // �E�]��
                    dmdPrtPtnWork.RightMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Right ), 1 );
                }


                // �������ӁI �ȉ��̊Ӎ��ڂ̃^�C�g���E�敪�l�͕ێ炪�K�v�ɂȂ�\��������܂��B
                //     �ύX�ɂȂ����ꍇ�́A����������p�^�[���}�X�������Q�l�ɂ��ĉ������B
                dmdPrtPtnWork.DmdTtlFormTitle1 = "�O�񐿋��z";
                dmdPrtPtnWork.DmdTtlFormTitle2 = "��������z";
                dmdPrtPtnWork.DmdTtlFormTitle3 = "�J�z�����z";
                dmdPrtPtnWork.DmdTtlFormTitle4 = "����Ŕ����E�����z";
                dmdPrtPtnWork.DmdTtlFormTitle5 = "���񑊎E����Ŋz";
                dmdPrtPtnWork.DmdTtlFormTitle6 = "����ō����E�����z";
                dmdPrtPtnWork.DmdTtlFormTitle7 = "�䐿���z";
                dmdPrtPtnWork.DmdTtlFormTitle8 = string.Empty;
                dmdPrtPtnWork.DmdTtlSetItemDiv1 = 1;    // �O�񐿋��z
                dmdPrtPtnWork.DmdTtlSetItemDiv2 = 2;    // ��������z
                dmdPrtPtnWork.DmdTtlSetItemDiv3 = 3;    // �J�z�����z
                dmdPrtPtnWork.DmdTtlSetItemDiv4 = 6;    // ����Ŕ����E�����z
                dmdPrtPtnWork.DmdTtlSetItemDiv5 = 9;    // ���񑊎E����Ŋz
                dmdPrtPtnWork.DmdTtlSetItemDiv6 = 12;   // ����ō����E�����z
                dmdPrtPtnWork.DmdTtlSetItemDiv7 = 13;   // �䐿���z
                dmdPrtPtnWork.DmdTtlSetItemDiv8 = 0;    // ���g�p

                //---------------------------------
                // �����̑��̍��ڂ͏����l���g�p���܂��B
                //---------------------------------

                dmdPrtPtnWorkList.Add( dmdPrtPtnWork );
                stream.Close();
            }

            return dmdPrtPtnWorkList;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
		#endregion

    }
}
