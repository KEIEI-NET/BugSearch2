using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.LocalAccess; // ADD 2010/05/18

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �󎚍��ڃO���[�v�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �󎚍��ڃO���[�v���ւ̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.04</br>
	/// <br></br>
    /// <br>Update Note : 2010/05/18 22008 ���� ���n</br>
    /// <br>            : ���[�J���c�a�Ή�</br>
    /// </remarks>
	public class PrtItemGrpAcs : IGeneralGuideData
	{
		#region Const
		// �ėp�K�C�h���o��������
		private const string ctFreePrtPprItemGrpCd	= "FreePrtPprItemGrpCd";
		private const string ctTotalItemDivCd		= "TotalItemDivCd";
		private const string ctFormFeedItemDivCd	= "FormFeedItemDivCd";
		// �ėp�K�C�h�eXML�t�@�C����
		private const string ctDifinitionFileName	= "PRTITEMSETGUIDEPARENT.XML";
		#endregion

		#region PrivateMember
        // -- UPD 2010/05/18 ------------------------------>>>
        //// �󎚍��ڐݒ�n�����[�g�C���^�[�t�F�[�X
        //private IPrtItemSetDB			_iPrtItemSetDB;
        // �󎚍��ڐݒ�n���[�J���A�N�Z�X
        private PrtItemSetLcDB			_iPrtItemSetDB;
        // -- UPD 2010/05/18 ------------------------------<<<
        // �G���[���b�Z�[�W
		private string					_errorStr;
		//
		private List<PrtItemSetWork>	_prtItemSetList;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PrtItemGrpAcs()
		{
            // -- UPD 2010/05/18 ------------------------------>>>
            //_iPrtItemSetDB	= MediationPrtItemSetDB.GetPrtItemSetDB();
            _iPrtItemSetDB	= new PrtItemSetLcDB();
            // -- UPD 2010/05/18 ------------------------------<<<
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
		/// �󎚍��ڃO���[�v�擾����
		/// </summary>
		/// <param name="prtItemGrpList">�󎚍��ڃO���[�vLIST</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚍��ڃO���[�vLIST���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchPrtItemGrpWork(out List<PrtItemGrpWork> prtItemGrpList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			prtItemGrpList = null;

			try
			{
				// �����[�e�B���O
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iPrtItemSetDB.SearchPrtItemGrp(out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						PrtItemGrpWork[] prtItemGrpWorkArray = retObj as PrtItemGrpWork[];
						if (prtItemGrpWorkArray != null)
							prtItemGrpList = new List<PrtItemGrpWork>(prtItemGrpWorkArray);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "�󎚍��ڃO���[�v�̌����Ɏ��s���܂����B\r\n�Y���f�[�^������܂���B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "�u�󎚍��ڃO���[�v�v�f�[�^�̎擾�Ɏ��s���܂����B\r\n\r\n*�ڍ�=" + errMsg;
						else
							_errorStr = "�󎚍��ڃO���[�v�̌����Ɏ��s���܂����B";
						break;
					}
					default:
					{
						_errorStr = "�󎚍��ڃO���[�v�̌����Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "�󎚍��ڃO���[�v���������ɂė�O���������܂����B" + "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �󎚍��ڐݒ�擾����
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚍��ڐݒ�LIST���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchPrtItemSetWork(int freePrtPprItemGrpCd, out List<PrtItemSetWork> prtItemSetList, out List<FPSortInitWork> fPSortInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			prtItemSetList = new List<PrtItemSetWork>();
			fPSortInitList = new List<FPSortInitWork>();

			try
			{
				// �����[�e�B���O
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iPrtItemSetDB.SearchPrtItemSet(freePrtPprItemGrpCd, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;
						if (retList != null)
						{
							for (int ix = 0 ; ix != retList.Count ; ix++)
							{
								ArrayList wkList = (ArrayList)retList[ix];
								if (wkList[0] is PrtItemSetWork)
									prtItemSetList = new List<PrtItemSetWork>((PrtItemSetWork[])wkList.ToArray(typeof(PrtItemSetWork)));
								else if (wkList[0] is FPSortInitWork)
									fPSortInitList = new List<FPSortInitWork>((FPSortInitWork[])wkList.ToArray(typeof(FPSortInitWork)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "�󎚍��ڐݒ�̌����Ɏ��s���܂����B\r\n�Y���f�[�^������܂���B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "�u�󎚍��ڐݒ�v�f�[�^�̎擾�Ɏ��s���܂����B\r\n\r\n*�ڍ�=" + errMsg;
						else
							_errorStr = "�󎚍��ڐݒ�̌����Ɏ��s���܂����B";
						break;
					}
					default:
					{
						_errorStr = "�󎚍��ڐݒ�̌����Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "�󎚍��ڐݒ茟�������ɂė�O���������܂����B" + "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}


		/// <summary>
		/// �󎚍��ڐݒ�擾����
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="freePrtPprSchmGrpCd">���R���[�X�L�[�}�O���[�v�R�[�h</param>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <param name="fPprSchmCvList">���R���[�X�L�[�}�R���o�[�gLIST</param>
		/// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
		/// <param name="fPECndInitList">���R���[���o���������l�}�X�^���X�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�󎚍��ڐݒ�LIST�y�ю��R���[�X�L�[�}�R���o�[�gLIST���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchPrtItemSetWithFPprSchmCv(int freePrtPprItemGrpCd, int freePrtPprSchmGrpCd, out List<PrtItemSetWork> prtItemSetList, out List<FPprSchmCvWork> fPprSchmCvList, out List<FPSortInitWork> fPSortInitList, out List<FPECndInitWork> fPECndInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			prtItemSetList = new List<PrtItemSetWork>();
			fPprSchmCvList = new List<FPprSchmCvWork>();
			fPSortInitList = new List<FPSortInitWork>();
			fPECndInitList = new List<FPECndInitWork>();

			try
			{
				// �����[�e�B���O
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iPrtItemSetDB.SearchPrtItemSetWithFPprSchmCv(freePrtPprItemGrpCd, freePrtPprSchmGrpCd, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;
						if (retList != null)
						{
							for (int ix = 0 ; ix != retList.Count ; ix++)
							{
								ArrayList wkList = (ArrayList)retList[ix];
								if (wkList[0] is PrtItemSetWork)
									prtItemSetList = new List<PrtItemSetWork>((PrtItemSetWork[])wkList.ToArray(typeof(PrtItemSetWork)));
								else if (wkList[0] is FPprSchmCvWork)
									fPprSchmCvList = new List<FPprSchmCvWork>((FPprSchmCvWork[])wkList.ToArray(typeof(FPprSchmCvWork)));
								else if (wkList[0] is FPSortInitWork)
									fPSortInitList = new List<FPSortInitWork>((FPSortInitWork[])wkList.ToArray(typeof(FPSortInitWork)));
								else if (wkList[0] is FPECndInitWork)
									fPECndInitList = new List<FPECndInitWork>((FPECndInitWork[])wkList.ToArray(typeof(FPECndInitWork)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "�󎚍��ڐݒ�̌����Ɏ��s���܂����B\r\n�Y���f�[�^������܂���B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "�u�󎚍��ڐݒ�v�f�[�^�̎擾�Ɏ��s���܂����B\r\n\r\n*�ڍ�=" + errMsg;
						else
							_errorStr = "�󎚍��ڐݒ�̌����Ɏ��s���܂����B";
						break;
					}
					default:
					{
						_errorStr = "�󎚍��ڐݒ�̌����Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "�󎚍��ڐݒ茟�������ɂė�O���������܂����B" + "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �󎚍��ڐݒ�K�C�h�N��
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">�󎚍��ڃO���[�v�R�[�h</param>
		/// <param name="totalItemDivCd">�W�񍀖ڋ敪</param>
		/// <param name="formFeedItemDivCd">���ō��ڋ敪</param>
		/// <param name="prtItemSetList">�󎚍��ڐݒ胊�X�g(null�̏ꍇ�����[�g���s���܂�)</param>
		/// <param name="prtItemSetWork">���ʈ󎚍��ڐݒ�}�X�^</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ�I���K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public DialogResult ExecuteGuide(int freePrtPprItemGrpCd, int totalItemDivCd, int formFeedItemDivCd, List<PrtItemSetWork> prtItemSetList, out PrtItemSetWork prtItemSetWork)
		{
			DialogResult dlgRet = DialogResult.Abort;

			_prtItemSetList = prtItemSetList;

			prtItemSetWork = null;

			TableGuideParent tableGuideParent = new TableGuideParent(ctDifinitionFileName);

			Hashtable outObj	= new Hashtable();
			Hashtable inObj		= new Hashtable();
			inObj[ctFreePrtPprItemGrpCd]	= freePrtPprItemGrpCd;
			inObj[ctTotalItemDivCd]			= totalItemDivCd;
			inObj[ctFormFeedItemDivCd]		= formFeedItemDivCd;

			// �ėp�K�C�h�N������
			if (tableGuideParent.Execute(0, inObj, ref outObj))
			{
				Object prtItemSetObj = new PrtItemSetWork();
				TableGuideParent.HashTableToClassProperty(outObj, ref prtItemSetObj);
				prtItemSetWork = (PrtItemSetWork)prtItemSetObj;

				dlgRet = DialogResult.OK;
			}
			else
			{
				dlgRet = DialogResult.Cancel;
			}

			return dlgRet;
		}
		#endregion

		#region IGeneralGuideData �����o
		/// <summary>
		/// �K�C�h�f�[�^�擾����
		/// </summary>
		/// <param name="mode">���[�h</param>
		/// <param name="inParm">��������</param>
		/// <param name="guideList">�K�C�h�\���f�[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �K�C�h�ɕ\������f�[�^���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			int freePrtPprItemGrpCd	= (int)inParm[ctFreePrtPprItemGrpCd];
			int totalItemDivCd		= (int)inParm[ctTotalItemDivCd];
			int formFeedItemDivCd	= (int)inParm[ctFormFeedItemDivCd];

			if (_prtItemSetList == null)
			{
				List<FPSortInitWork> dummyFPSortInitList;
				status = SearchPrtItemSetWork(freePrtPprItemGrpCd, out _prtItemSetList, out dummyFPSortInitList);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				List<PrtItemSetWork> prtItemSetList
					= _prtItemSetList.FindAll(
						delegate(PrtItemSetWork prtItemSetWork)
						{
							if (totalItemDivCd != 0)
							{
								if (prtItemSetWork.TotalItemDivCd == totalItemDivCd)
									return true;
								else
									return false;
							}
							else if (formFeedItemDivCd != 0)
							{
								if (prtItemSetWork.FormFeedItemDivCd == formFeedItemDivCd)
									return true;
								else
									return false;
							}
							else
							{
								if (prtItemSetWork.AddItemUseDivCd == 1)
									return true;
								else
									return true;
							}
						}
					);

				if (prtItemSetList != null && prtItemSetList.Count > 0)
				{
					byte[] wkByte = XmlByteSerializer.Serialize(prtItemSetList);
					XmlByteSerializer.ReadXml(ref guideList, wkByte);
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			return status;
		}
		#endregion
	}
}
