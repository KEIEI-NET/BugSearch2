//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ��ԗ��ꗗ�A�N�Z�X�N���X
// �v���O�����T�v   : �����Ԍ��ԗ��ꗗ�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// Update Note  : 2010/05/08 ���C�� redmine #7156�̑Ή�
//�@�@�@�@�@�@�@: �Ԏ�Ɠ��Ӑ�R�[�h�̒��[�̈�
//----------------------------------------------------------------------------//
/// Update Note : 2010.05.18 zhangsf Redmine #7784�̑Ή�
///             : �E���[���C�A�E�g�C��
//----------------------------------------------------------------------------//
/// Update Note : 2010.05.24 �I�M Redmine #7784�̑Ή�
///             : �E�󎚏��C��
//----------------------------------------------------------------------------//
// Update Note : 2013.04.11 FSI�֓� �a�G 10900269-00 SPK�ԑ�ԍ�������Ή�
//              : �E�ԑ�No.��VIN�R�[�h�Ƃ���17���܂ŕ\���\�ɂ���Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �����Ԍ��ԗ��ꗗ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����Ԍ��ԗ��ꗗ�Ŏg�p����f�[�^���擾����</br>
	/// <br>Programmer : �L�Q</br>
	/// <br>Date       : 2010.04.21</br>
	/// </remarks>
	public class MonthCarInspectListAcs
	{
		#region �� Constructor
		/// <summary>
		/// �����Ԍ��ԗ��ꗗ�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����Ԍ��ԗ��ꗗ�A�N�Z�X�N���X�̏��������s���B</br>
		/// <br>Programmer : �L�Q</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		public MonthCarInspectListAcs()
		{
			this._iMonthCarInspectListResultDB = (IMonthCarInspectListResultDB)MediationMonthCarInspectListResultDB.GetMonthCarInspectListResultDB();
		}
		#endregion �� Constructor

		#region �� Private Member
		// �����Ԍ��ԗ��ꗗ�����C���^�t�F�[�X
		IMonthCarInspectListResultDB _iMonthCarInspectListResultDB;

		// DataSet�I�u�W�F�N�g
		private DataSet _dataSet;

		#endregion �� Private Member

		#region �� Public Property
		/// <summary>
		/// �f�[�^�Z�b�g(�ǂݎ���p)
		/// </summary>
		public DataSet DataSet
		{
			get { return this._dataSet; }
		}
		#endregion �� Public Property

		#region �� Public Method
		#region �� �o�̓f�[�^�擾
		#region �� �����Ԍ��ԗ��ꗗ�f�[�^�擾
		/// <summary>
		/// �����Ԍ��ԗ��ꗗ�f�[�^�擾
		/// </summary>
		/// <param name="monthCarInspectListPara">���o����</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ������铖���Ԍ��ԗ��ꗗ�f�[�^���擾����B</br>
		/// <br>Programmer : �L�Q</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		public int SearchMonthCarInspectListProcMain(MonthCarInspectListPara monthCarInspectListPara, out string errMsg)
		{
			return this.SearchMonthCarInspectListProc(monthCarInspectListPara, out errMsg);
		}
		#endregion
		#endregion �� �o�̓f�[�^�擾
		#endregion �� Public Method

		#region �� Private Method
		#region �� ���[�f�[�^�擾
		#region �� �f�[�^�擾
		/// <summary>
		/// �f�[�^�擾
		/// </summary>
		/// <param name="monthCarInspectListPara">���o����</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ������铖���Ԍ��ԗ��ꗗ�f�[�^���擾����B</br>
		/// <br>Programmer : �L�Q</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		private int SearchMonthCarInspectListProc(MonthCarInspectListPara monthCarInspectListPara, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = String.Empty;
			try
			{
				// DataTable Create
				PMSYA02105EA.CreateDataTable(ref _dataSet);

				// ���o�����W�J
				MonthCarInspectListParaWork monthCarInspectListParaWork = new MonthCarInspectListParaWork();
				// ��ʌ������->remoteDean>s
				status = this.SetCondInfo(ref monthCarInspectListPara, out monthCarInspectListParaWork, out errMsg);

				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					return status;
				}

				// �f�[�^�擾  ----------------------------------------------------------------
				object retList = null;
				object paraWorkRef = monthCarInspectListParaWork;
				status = _iMonthCarInspectListResultDB.Search(out retList, paraWorkRef);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// �f�[�^�W�J����
						// --- UPD 2010/05/24 ---------->>>>>
						// ConverToDataSetForPdf(_dataSet.Tables[PMSYA02105EA.ct_Tbl_MonthCarInspectListReportData], (ArrayList)retList, monthCarInspectListParaWork);
						ConverToDataSetForPdf(_dataSet.Tables[PMSYA02105EA.ct_Tbl_MonthCarInspectListReportData], (ArrayList)retList, monthCarInspectListParaWork, monthCarInspectListPara);
						// --- UPD 2010/05/24 ----------<<<<<
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

						if (this._dataSet.Tables[PMSYA02105EA.ct_Tbl_MonthCarInspectListReportData].Rows.Count < 1)
						{
							status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						}
						else
						{
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						}
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "�����Ԍ��ԗ��ꗗ�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
						break;
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion �� ���[�f�[�^�擾

		#region �� �f�[�^�W�J����
		#region �� ���o�����W�J����
		/// <summary>
		/// ���o�����W�J����
		/// </summary>
		/// <param name="monthCarInspectListPara">UI���o�����N���X</param>
		/// <param name="monthCarInspectListParaWork">�����[�g���o�����N���X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �Ȃ�</br>
		/// <br>Programmer : �L�Q</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		private int SetCondInfo(ref MonthCarInspectListPara monthCarInspectListPara, out MonthCarInspectListParaWork monthCarInspectListParaWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			monthCarInspectListParaWork = new MonthCarInspectListParaWork();
			try
			{
				// ��ƃR�[�h
				monthCarInspectListParaWork.EnterpriseCode = monthCarInspectListPara.EnterpriseCode;

				// ���_
				if (monthCarInspectListPara.SectionCodes.Length != 0)
				{
					if (monthCarInspectListPara.IsSelectAllSection)
					{
						// �S�Ђ̎�
						monthCarInspectListParaWork.MngSectionCode = null;
					}
					else
					{
						monthCarInspectListParaWork.MngSectionCode = monthCarInspectListPara.SectionCodes;
					}
				}
				else
				{
					monthCarInspectListParaWork.MngSectionCode = null;
				}

				// �J�n���Ӑ�R�[�h
				monthCarInspectListParaWork.StCustomerCode = monthCarInspectListPara.StCustomerCode;
				// �I�����Ӑ�R�[�h
				monthCarInspectListParaWork.EdCustomerCode = monthCarInspectListPara.EdCustomerCode;

				// �J�n���q�Ǘ��R�[�h
				monthCarInspectListParaWork.StCarMngCode = monthCarInspectListPara.StCarMngCode;
				// �I�����q�Ǘ��R�[�h
				monthCarInspectListParaWork.EdCarMngCode = monthCarInspectListPara.EdCarMngCode;

				// �Ԍ�������
				monthCarInspectListParaWork.InspectMaturityDate = monthCarInspectListPara.InspectMaturityDate;
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region �� �擾�f�[�^�W�J����
		/// <summary>
		/// DataTable�Ƀf�[�^��ݒ菈��
		/// </summary>
		/// <param name="dataTable">���[�pDataTable</param>
		/// <param name="retList">������񃊃X�g</param>
		/// <param name="paraWork">paraWork</param>
		/// <remarks>
		/// <br>Note       : �Ȃ�</br>
		/// <br>Programmer : �L�Q</br>
		/// <br>Date       : 2010.04.21</br>
		/// <br>Update Note: 2010/05/10 ���C�� �Ԏ�Ɠ��Ӑ�R�[�h�̒��[�̈�</br>
		/// </remarks>
		// --- UPD 2010/05/24 ---------->>>>>
		//private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, MonthCarInspectListParaWork paraWork)
		private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, MonthCarInspectListParaWork paraWork, MonthCarInspectListPara monthCarInspectListPara)
		{

			// ��r�p�̓��Ӑ�R�[�h
			string nextCustomerCode = string.Empty;
			// ��r�p�̓��Ӑ�R�[�h+�Ԍ�������
			string nextCustomerCode_InspectMaturityDate = string.Empty;
			// ���� = �ׂ��ł��̏ꍇ�A��y�[�W��30���͕\�����܂��B
			int pageRow = 30;
			// ���� = 1�s��s�̏ꍇ�A��y�[�W��15���͕\�����܂��B
			int pageRow2 = 15;

			if ((int)monthCarInspectListPara.ChangeRowDiv == 1)
			{
				// ���� = 1�s��s�̏ꍇ�A��y�[�W��15���͕\�����܂��B
				pageRow = pageRow2;
			}
			// --- UPD 2010/05/24 ----------<<<<<

			for (int i = 0; i < retList.Count; i++)
			{
				MonthCarInspectListResultWork rsltInfo = (MonthCarInspectListResultWork)retList[i];
				DataRow dr = null;
				dr = dataTable.NewRow();

				// ���꓾�Ӑ�͈󎚂��Ȃ��A�y�[�W���ς�����Ƃ��͈󎚂���B
				if ((!nextCustomerCode.Equals(string.Format("{0:D8}", rsltInfo.CustomerCode)))
					|| (((int)monthCarInspectListPara.ChangePageDiv == 0) && (i % pageRow == 0)))
				{
					// ���Ӑ�R�[�h
					dr[PMSYA02105EA.ct_Col_CustomerCode] = string.Format("{0:D8}", rsltInfo.CustomerCode);
					// ���Ӑ旪��
					dr[PMSYA02105EA.ct_Col_CustomerSnm] = rsltInfo.CustomerSnm;
				}
				else
				{
					// ���Ӑ�R�[�h
					dr[PMSYA02105EA.ct_Col_CustomerCode] = string.Empty;
					// ���Ӑ旪��
					dr[PMSYA02105EA.ct_Col_CustomerSnm] = string.Empty;
				}

				// �Ǘ����_�R�[�h
				dr[PMSYA02105EA.ct_Col_MngSectionCode] = rsltInfo.MngSectionCode;
				// ��ƃR�[�h
				dr[PMSYA02105EA.ct_Col_EnterpriseCode] = rsltInfo.EnterpriseCode;
				// �_���폜�敪
				dr[PMSYA02105EA.ct_Col_LogicalDeleteCode] = rsltInfo.LogicalDeleteCode;
				// --- UPD 2010/05/24 ---------->>>>>
				// ���Ӑ�R�[�h
				// --- UPD 2010/05/10 ---------->>>>>
				//dr[PMSYA02105EA.ct_Col_CustomerCode] = rsltInfo.CustomerCode;
				//dr[PMSYA02105EA.ct_Col_CustomerCode] = string.Format("{0:D8}", rsltInfo.CustomerCode);
				// --- UPD 2010/05/10 ----------<<<<<
				// ��r�p�̓��Ӑ�R�[�h
				nextCustomerCode = string.Format("{0:D8}", rsltInfo.CustomerCode);
				// --- UPD 2010/05/24 ----------<<<<<
				// �ԗ��Ǘ��ԍ�
				dr[PMSYA02105EA.ct_Col_CarMngNo] = rsltInfo.CarMngNo;
				// ���q�Ǘ��R�[�h
				dr[PMSYA02105EA.ct_Col_CarMngCode] = rsltInfo.CarMngCode;
				// �o�^�ԍ�
				StringBuilder numberPlate = new StringBuilder();
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate1Name))
				{
					// ���^�����ǖ���
					//numberPlate.Append(rsltInfo.NumberPlate1Name);// DEL 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append(rsltInfo.NumberPlate1Name.PadRight(4, '�@'));// ADD 2010.05.18 zhangsf FOR Redmine #7784
				}
				else // ADD 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append("�@�@�@�@");// ADD 2010.05.18 zhangsf FOR Redmine #7784
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate2))
				{
					if (!string.IsNullOrEmpty(numberPlate.ToString()))
					{
						numberPlate.Append(" ");
					}
					// �ԗ��o�^�ԍ��i��ʁj
					//numberPlate.Append(rsltInfo.NumberPlate2);// DEL 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append(rsltInfo.NumberPlate2.PadLeft(3, ' '));// ADD 2010.05.18 zhangsf FOR Redmine #7784
				}
				else // ADD 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append("   ");// ADD 2010.05.18 zhangsf FOR Redmine #7784
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate3))
				{
					if (!string.IsNullOrEmpty(numberPlate.ToString()))
					{
						numberPlate.Append(" ");
					}
					// �ԗ��o�^�ԍ��i�J�i�j
					numberPlate.Append(rsltInfo.NumberPlate3);
				}
				else // ADD 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append("�@");// ADD 2010.05.18 zhangsf FOR Redmine #7784
				if (!string.IsNullOrEmpty(numberPlate.ToString()))
				{
					numberPlate.Append(" ");
				}
				if (rsltInfo.NumberPlate4 != 0)// ADD 2010.05.18 zhangsf FOR Redmine #7784
					// �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
					//numberPlate.Append(rsltInfo.NumberPlate4.ToString());// DEL 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append((rsltInfo.NumberPlate4.ToString()).PadLeft(4, ' '));// ADD 2010.05.18 zhangsf FOR Redmine #7784

				dr[PMSYA02105EA.ct_Col_NumberPlate] = numberPlate.ToString();
				// ���N�x 
				if (rsltInfo.FirstEntryDate == "0")
				{
					// 0�̂Ƃ��͋�
					dr[PMSYA02105EA.ct_Col_FirstEntryDate] = string.Empty;
				}
				else if (rsltInfo.FirstEntryDate.Length == 6)
				{

					dr[PMSYA02105EA.ct_Col_FirstEntryDate] = rsltInfo.FirstEntryDate.Substring(0, 4) + "/" + rsltInfo.FirstEntryDate.Substring(4, 2);
				}

				// �Ԏ�R�[�h
				// --- UPD 2010/05/10 ---------->>>>>
				//dr[PMSYA02105EA.ct_Col_ModelCode] = rsltInfo.MakerCode + "-" + rsltInfo.ModelCode + "-" + rsltInfo.ModelSubCode;
				dr[PMSYA02105EA.ct_Col_ModelCode] = string.Format("{0:D3}", rsltInfo.MakerCode) + "-" + string.Format("{0:D3}", rsltInfo.ModelCode) + "-" + string.Format("{0:D3}", rsltInfo.ModelSubCode);
				// --- UPD 2010/05/10 ----------<<<<<
				// �Ԏ피�p����
				dr[PMSYA02105EA.ct_Col_ModelHalfName] = rsltInfo.ModelHalfName;
				// �^���i�t���^�j
				dr[PMSYA02105EA.ct_Col_FullModel] = rsltInfo.FullModel;
				// �ԑ�ԍ�
				//dr[PMSYA02105EA.ct_Col_FrameNo] = rsltInfo.FrameNo;// DEL 2010.05.18 zhangsf FOR Redmine #7784
				// ADD 2010.05.18 zhangsf FOR Redmine #7784 *-------------------->>>
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate1Name))
				{
					string frameNo;
                    // --- DEL 2013/04/11 ---------->>>>>
                    //if (rsltInfo.FrameNo.Length >= 8)
                    //    frameNo = rsltInfo.FrameNo.Substring(0, 8);
                    //else
                    //    frameNo = rsltInfo.FrameNo.PadLeft(8, ' ');
                    // --- DEL 2013/04/11 ----------<<<<<
                    // --- ADD 2013/04/11 ---------->>>>>
                    // ������Ƃ��Ĉ����̂ŁA�E�l�ߕ\���͍s��Ȃ��B
                    if (rsltInfo.FrameNo.Length >= 17)
                        frameNo = rsltInfo.FrameNo.Substring(0, 17);
                    else
                        frameNo = rsltInfo.FrameNo;
                    // --- ADD 2013/04/11 ----------<<<<<

					dr[PMSYA02105EA.ct_Col_FrameNo] = frameNo;
				}
				else
				{
					dr[PMSYA02105EA.ct_Col_FrameNo] = "";
				}
				// ADD 2010.05.18 zhangsf FOR Redmine #7784 <<<--------------------*
				// --- UPD 2010/05/24 ---------->>>>>
				// ���꓾�Ӑ�R�[�h+�Ԍ��������͈󎚂��Ȃ�
				if (!nextCustomerCode_InspectMaturityDate.Equals(string.Format("{0:D8}", rsltInfo.CustomerCode)
					+ "|" + rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd")))
				{
					// �Ԍ�������
					dr[PMSYA02105EA.ct_Col_InspectMaturityDate] = rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd");
				}
				else
				{
					// �Ԍ�������
					dr[PMSYA02105EA.ct_Col_InspectMaturityDate] = string.Empty;
				}
				// ��r�p�̓��Ӑ�R�[�h+�Ԍ�������
				nextCustomerCode_InspectMaturityDate = string.Format("{0:D8}", rsltInfo.CustomerCode) + "|"
					+ rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd");
				// --- UPD 2010/05/24 ----------<<<<<

				// �Ԍ�����
				dr[PMSYA02105EA.ct_Col_CarInspectYear] = rsltInfo.CarInspectYear;
				// Group (�Ԍ������� +
				//dr[PMSYA02105EA.ct_Col_Group] = rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd") + rsltInfo.CustomerCode;// DEL 2010.05.18 zhangsf FOR Redmine #7784
				dr[PMSYA02105EA.ct_Col_Group] = rsltInfo.CustomerCode;// ADD 2010.05.18 zhangsf FOR Redmine #7784

				dataTable.Rows.Add(dr);
			}
		}
		#endregion
		#endregion �� �f�[�^�W�J����

		#endregion �� Private Method
	}
}
