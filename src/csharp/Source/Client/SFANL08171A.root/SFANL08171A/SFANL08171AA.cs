using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;

using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[�󎚈ʒuExport�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒuExport�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.11.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class FrePrtPSetExportAcs
	{
		#region Delegate
		/// <summary>
		/// ���R���[Export�C�x���g�n���h��
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <param name="frePrtExport">���R���[Export�N���X</param>
		/// <remarks>���R���[�󎚈ʒu�ݒ肪Export�����x�ɔ������܂��B</remarks>
		public delegate void FrePrtPSetExportEventHandler(int status, string errMsg, FrePrtExport frePrtExport);
		#endregion

		#region Event
		/// <summary>���R���[Export�C�x���g</summary>
		public event FrePrtPSetExportEventHandler FrePrtPSetExported;
		#endregion

		#region Const
		// �g���q
		private const string ctExtension = ".dat";
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ������ �e��A�N�Z�X�N���X ������
		// --------------------------------------------------------
		// �󎚈ʒu�_�E�����[�h�A�N�Z�X�N���X
		private SFANL08230AE		_frePrtPSetDLAcs;

		// --------------------------------------------------------
		// ������ �f�[�^�N���X ������
		// --------------------------------------------------------
		// ���R���[Export�N���XList
		private List<FrePrtExport>	_frePrtExportList;
		// �摜�Ǘ��}�X�^
		private ImgManage			_imgManage;
		// �`�[����ݒ�}�X�^List
		private List<SlipPrtSet>	_slipPrtSetList;

		// --------------------------------------------------------
		// ������ ���̑����[�N�ϐ� ������
		// --------------------------------------------------------
		// �G���[���b�Z�[�W
		private string				_errorStr;
		// �摜�T�[�o�[�A�N�Z�X�t���O
		private bool				_isImageAccess;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public FrePrtPSetExportAcs()
		{
			_frePrtPSetDLAcs = new SFANL08230AE();
		}
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>���R���[Export�N���XList</summary>
		public List<FrePrtExport> FrePrtExportList
		{
			get {
				if (_frePrtExportList == null)
					return new List<FrePrtExport>();
				else
					return _frePrtExportList;
			}
		}

		/// <summary>�`�[����ݒ�}�X�^List</summary>
		public List<SlipPrtSet> SlipPrtSetList
		{
			get {
				if (_slipPrtSetList == null)
					return new List<SlipPrtSet>();
				else
					return _slipPrtSetList;
			}
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���R���[Export��񌟍�����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: </br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		public int Search(string enterpriseCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			string errMsg = string.Empty;

			try
			{
				FrePrtPSetWork[] frePrtPSetArray;
				status = _frePrtPSetDLAcs.Search(enterpriseCode, string.Empty, out frePrtPSetArray, 0, ConstantManagement.LogicalMode.GetData0, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						_frePrtExportList = DBAndXMLDataMergeParts.CopyProperty<FrePrtExport>(frePrtPSetArray);
						// ���[�g�p�敪���`�[�̂��̂�����ꍇ�͓`�[����ݒ�}�X�^���擾
						if (_frePrtExportList.Exists(
								delegate(FrePrtExport frePrtExport)
								{
									if (frePrtExport.PrintPaperUseDivcd == 2)
										return true;
									else
										return false;
								}
							))
						{
							SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
							System.Collections.ArrayList retList;
							status = slipPrtSetAcs.SearchSlipPrtSet(out retList, enterpriseCode);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								_slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])retList.ToArray(typeof(SlipPrtSet)));
							}
							else
							{
								_errorStr = "�`�[����ݒ�̌����Ɏ��s���܂����B";
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "���R���[�󎚈ʒu�ݒ�̌����Ɏ��s���܂����B" + Environment.NewLine + "�Y���f�[�^������܂���B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						_errorStr = "�u���R���[�󎚈ʒu�ݒ�v�f�[�^�̎擾�Ɏ��s���܂����B" + Environment.NewLine + Environment.NewLine + "*�ڍ�=" + errMsg;
						break;
					}
					default:
					{
						_errorStr = "���R���[�󎚈ʒu�ݒ�̌��������ɂė�O���������܂����B" + Environment.NewLine + errMsg;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[Export��񌟍������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// ���R���[Export����
		/// </summary>
		/// <param name="filePath">�ۑ���t�@�C���p�X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: </br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		public int Export(string filePath)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// �ۑ��Ώۂ��擾
				List<FrePrtExport> targetFrePrtExportList
					= _frePrtExportList.FindAll(
						delegate(FrePrtExport frePrtExport)
						{
							if (frePrtExport.ExtractionItdedFlg == 1)
								return true;
							else
								return false;
						}
					);

				if (targetFrePrtExportList != null && targetFrePrtExportList.Count > 0)
				{
					List<FrePrtExport> writeFrePrtExportList;
					if (File.Exists(filePath))
						writeFrePrtExportList = (List<FrePrtExport>)XmlByteSerializer.Deserialize(filePath, typeof(List<FrePrtExport>));
					else
						writeFrePrtExportList = new List<FrePrtExport>();

					// ----------------------------------------------------
					// ���R���[�󎚈ʒu�ݒ�n�̕ۑ�����
					// ----------------------------------------------------
					// ���R���[���[�J���f�[�^�A�N�Z�X�N���X
					FrePrtPosLocalAcs frePrtPosLocalAcs = new FrePrtPosLocalAcs();
					foreach (FrePrtExport frePrtExport in targetFrePrtExportList)
					{
						FrePrtPSet frePrtPSet = DBAndXMLDataMergeParts.CopyPropertyInClass<FrePrtPSet>(frePrtExport);

						string errMsg = string.Empty;
						try
						{
							List<FrePprECnd> frePprECndList;
							List<FrePprSrtO> frePprSrtOList;
							status = _frePrtPSetDLAcs.Read(ref frePrtPSet, out frePprECndList, out frePprSrtOList, out errMsg);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								if (frePrtPSet.PrintPaperUseDivcd == 2 && frePrtExport.SlipPrtKind != 0)
									MergeSlipPrtSetMargin(frePrtPSet, frePrtExport.SlipPrtKind);

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //string fileName = frePrtPSet.OutputFormFileName + "_" + frePrtPSet.UserPrtPprIdDerivNo + ctExtension;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                string fileName = string.Empty;
                                if ( frePrtPSet.UserPrtPprIdDerivNo == 0 )
                                {
                                    fileName = frePrtPSet.OutputFormFileName + ctExtension;
                                }
                                else
                                {
                                    fileName = frePrtPSet.OutputFormFileName + "_" + frePrtPSet.UserPrtPprIdDerivNo + ctExtension;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
								string prtPosFilePath = Path.Combine(Path.GetDirectoryName(filePath), fileName);
								// ���[�J���ۑ�
								status = frePrtPosLocalAcs.WriteLocalFrePrtPSet(frePrtPSet, frePprECndList, frePprSrtOList, prtPosFilePath);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									// ���[�J���ۑ��p�X�𑊑΃p�X�ɕϊ�����Export�N���X�ɃZ�b�g
									Uri uri1 = new Uri(filePath);
									Uri uri2 = new Uri(uri1, prtPosFilePath);
									string uriStr = uri1.MakeRelativeUri(uri2).ToString();
									frePrtExport.ExportDataFilePath = System.Web.HttpUtility.UrlDecode(uriStr).Replace('/', '\\');

									// ����KEY��Export��񂪂���ꍇ��Remove
									writeFrePrtExportList.RemoveAll(
										delegate(FrePrtExport wkFrePrtExport)
										{
											if (wkFrePrtExport.EnterpriseCode == frePrtExport.EnterpriseCode &&
												wkFrePrtExport.OutputFormFileName == frePrtExport.OutputFormFileName &&
												wkFrePrtExport.UserPrtPprIdDerivNo == frePrtExport.UserPrtPprIdDerivNo)
												return true;
											else
												return false;
										}
									);
									// ���R���[Export���֒ǉ�
									writeFrePrtExportList.Add(frePrtExport);

									// �摜�f�[�^�̎擾
									if (frePrtPSet.TakeInImageGroupCd != Guid.Empty)
									{
										if (SearchImage(frePrtPSet.EnterpriseCode, frePrtPSet.TakeInImageGroupCd) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
											frePrtExport.SetPrintPprBgImageDataImage(_imgManage.TakeInImage);
									}
								}
								else
								{
									errMsg = frePrtPosLocalAcs.ErrorMessage;
								}
							}
							else if (status != (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
							{
								errMsg = "�u" + frePrtPSet.DisplayName + "�v�̓Ǎ��Ɏ��s���܂����Bst=" + status;
							}
						}
						catch (Exception ex)
						{
							errMsg = "�u" + frePrtPSet.DisplayName + "�v��Export�����ɂė�O���������܂����B" + Environment.NewLine + Environment.NewLine + "*�ڍ�=" + ex.Message;
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
						}
						finally
						{
							this.FrePrtPSetExported(status, errMsg, frePrtExport);
						}
					}

					// ----------------------------------------------------
					// ���R���[Export���n�̕ۑ�����
					// ----------------------------------------------------
					if (writeFrePrtExportList.Count > 0)
					{
						XmlByteSerializer.Serialize(writeFrePrtExportList, filePath);
					}
					else
					{
						status		= (int)ConstantManagement.DB_Status.ctDB_EOF;
						_errorStr	= "���R���[Export�Ɏ��s���܂����B" + Environment.NewLine + "Export�o����f�[�^������܂���B";
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[Export�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �`�[����ݒ�]���}�[�W����
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�</param>
		/// <param name="slipPrtKind">�`�[������</param>
		/// <remarks>
		/// <br>Note		: ���R���[�̗]���ݒ���w��`�[�����ʂ̓`�[����ݒ�ŏ㏑�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void MergeSlipPrtSetMargin(FrePrtPSet frePrtPSet, int slipPrtKind)
		{
			SlipPrtSet slipPrtSet = _slipPrtSetList.Find(
				delegate(SlipPrtSet wkSlipPrtSet)
				{
					if (wkSlipPrtSet.EnterpriseCode == frePrtPSet.EnterpriseCode &&
						wkSlipPrtSet.DataInputSystem == frePrtPSet.DataInputSystem &&
						wkSlipPrtSet.SlipPrtKind == slipPrtKind &&
						wkSlipPrtSet.SlipPrtSetPaperId == frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo)
						return true;
					else
						return false;
				}
			);

			if (slipPrtSet != null)
			{
				ActiveReport3 rpt = new ActiveReport3();
				// ���C�A�E�g�����Ăяo��
				using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
				{
					stream.Position = 0;
					rpt.LoadLayout(stream);
					stream.Close();
				}
				
				// �`�[����ݒ�̗]���ݒ��K�p
				rpt.PageSettings.Margins.Top	= ActiveReport3.CmToInch((float)slipPrtSet.TopMargin);
				rpt.PageSettings.Margins.Bottom	= ActiveReport3.CmToInch((float)slipPrtSet.BottomMargin);
				rpt.PageSettings.Margins.Left	= ActiveReport3.CmToInch((float)slipPrtSet.LeftMargin);
				rpt.PageSettings.Margins.Right	= ActiveReport3.CmToInch((float)slipPrtSet.RightMargin);

				// ���C�A�E�g����ۑ�
				using (MemoryStream stream = new MemoryStream())
				{
					rpt.SaveLayout(stream);
					stream.Position = 0;
					frePrtPSet.PrintPosClassData = stream.ToArray();
					stream.Close();
				}
			}
		}

		/// <summary>
		/// �摜��������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�摜���摜�T�[�o�[���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private int SearchImage(string enterpriseCode, Guid takeInImageGroupCd)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_imgManage = new ImgManage();

			if (takeInImageGroupCd != null && takeInImageGroupCd != Guid.Empty)
			{
				// �摜�Ǘ��A�N�Z�X�N���X
				ImageImgAcs imageImgAcs = new ImageImgAcs();
				imageImgAcs.FileReceived += new EventHandler(ImageImgAcs_FileReceived);

				ImageGroup[] imageGroupArray;
				ImgManage[] imgManageArray;
				_isImageAccess = true;
				status = imageImgAcs.Search(out imageGroupArray, out imgManageArray, enterpriseCode, takeInImageGroupCd, 0, 100, true);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// �摜�O���[�v�}�X�^
					if (imageGroupArray == null || imageGroupArray.Length == 0)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						_isImageAccess = false;
					}
					// �摜�Ǘ��}�X�^
					if (imgManageArray != null && imgManageArray.Length > 0)
					{
						_imgManage = imgManageArray[0];
					}
					else
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						_isImageAccess = false;
					}

					// �񓯊���������������܂�Wait����
					while (_isImageAccess) Thread.Sleep(100);
				}
			}

			return status;
		}

		/// <summary>
		/// ImageImgAcs_FileReceived�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �摜�T�[�o�[���t�@�C�����擾�����������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ImageImgAcs_FileReceived(object sender, EventArgs e)
		{
			try
			{
				ImgManage[] imgManageArray = sender as ImgManage[];
				if (imgManageArray != null && imgManageArray.Length > 0)
				{
					_imgManage = imgManageArray[0];
				}
			}
			finally
			{
				_isImageAccess = false;
			}
		}
		#endregion
	}
}
