//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �O�H�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : �я���
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �C �� ��  2010/05/07  �C�����e : redmine#7034 �񓚕i�ԃo�C�g�̏C��																																																																											
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �C �� ��  2010/05/07  �C�����e : redmine#7035 B/O���̓��[�J�[�t�H���[���ɃZ�b�g																																																																											
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ���N�n��
// �C �� ��  2010/12/31  �C�����e : �����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B																																																																											
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/12/02  �C�����e : Redmine#8304�̑Ή�																																																																										
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �O�HWeb-UOE�����񓚃f�[�^�̍\�z�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O�HWeb-UOE�����񓚃f�[�^�̍\�z�N���X���s���܂��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010/04/21</br>
	/// <br>UpdateNote : 2010/05/07 �I�M</br>
	/// <br>           �@redmine#7034 �񓚕i�ԃo�C�g�̏C��</br>
	/// <br>UpdateNote : 2010/05/07 �I�M</br>
	/// <br>           �@redmine#7035 B/O���̓��[�J�[�t�H���[���ɃZ�b�g</br>
    /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
    /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>      
    /// </remarks>
    public sealed class MitsubishiWebUOEOrderDtlInfoBuilder : UOEOrderDtlInfoBuilder
    {
        # region -- �v���C�x�[�g�ϐ� --
        private DataTable _dataTable;
        # endregion

        # region -- �v���C�x�[�g�萔 --
        // datatable���̗p
        /// <summary>
        /// datatable����
        /// </summary>
        public static string TABLE_ID = "DETAIL_TABLE";
        /// <summary>
        /// No.
        /// </summary>
        public static string NO = "No";
        /// <summary>
        /// �i��
        /// </summary>
        public static string GOODSNO = "GoodsNo";
        /// <summary>
        /// Ұ��(�^�C�g��)	
        /// </summary>
        public static string GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>
        /// �i��(�^�C�g��)	
        /// </summary>
        public static string GOODSNAME = "GoodsName";
        /// <summary>
        /// ����(�^�C�g��)	
        /// </summary>
        public static string COUNT = "Count";
        /// <summary>
        /// �񓚕i��(�^�C�g��)	
        /// </summary>
        public static string ANSWERPARTSNO = "AnswerPartsNo";
        /// <summary>
        /// �艿(�^�C�g��)	
        /// </summary>
        public static string LISTPRICE = "ListPrice";
        /// <summary>
        /// �P��(�^�C�g��)	
        /// </summary>
        public static string SALESUNITCOST = "SalesUnitCost";
        /// <summary>
        /// �R�����g(�^�C�g��)	
        /// </summary>
        public static string COMMENT = "Comment";
        /// <summary>
        /// ���_�`�[�ԍ�(�^�C�g��)	
        /// </summary>
        public static string UOESECTIONSLIPNO = "UOESectionSlipNo";
        /// <summary>
        /// �o�א�(�^�C�g��)	
        /// </summary>
        public static string UOESECTOUTGOODSCNT = "UOESectOutGoodsCnt";
        /// <summary>
        /// BO�`�[�ԍ�1(�^�C�g��)
        /// </summary>
        public static string BOSLIPNO1 = "BOSlipNo1";
        /// <summary>
        /// �o�א�(�^�C�g��)		
        /// </summary>
        public static string BOSHIPMENTCNT1 = "BOShipmentCnt1";
        /// <summary>
        /// BO�`�[�ԍ�2(�^�C�g��)	
        /// </summary>
        public static string BOSLIPNO2 = "BOSlipNo2";
        /// <summary>
        /// �o�א�(�^�C�g��)		
        /// </summary>
        public static string BOSHIPMENTCNT2 = "BOShipmentCnt2";
        /// <summary>
        /// Ұ��̫۰��(�^�C�g��)	
        /// </summary>
        public static string MAKERFOLLOWCNT = "MakerFollowCnt";
        private const string COMMASSEMBLY_ID = "0302";
        private const string AUTOCOMMASSEMBLY_ID = "0303";   // ADD 2010/12/31
        //---ADD 2010/12/31----------------------------------------------->>>>>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //�t�n�d������A�N�Z�X�N���X
        private UOESupplierAcs _uoeSupplierAcs; 
        //�t�n�d������
        private List<UOESupplier> _uoeSupplier01633;
        private  int UOESupplierFlag = 0;
        //---ADD 2010/12/31-----------------------------------------------<<<<<
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        public MitsubishiWebUOEOrderDtlInfoBuilder()
            : base()
        {
            //---ADD 2010/12/31----------------------------------------------->>>>>
            this._uoeSupplierAcs = new UOESupplierAcs();
            this.CacheUOESupplier_01633();
            //---ADD 2010/12/31-----------------------------------------------<<<<<
        }
        # endregion        

        # region  -- �\�z�N���X�̎��� --

        //---ADD 2010/12/31----------------------------------------------->>>>>
        /// <summary>
        /// �蓮�Ǝ�����Falg���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �蓮�Ǝ�����Falg���</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        public void GetSupplierFlag()
        {
            foreach (UOESupplier uoeSupplier in _uoeSupplier01633)
            {

                if (("0303").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 1;
                    break;
                }
            }
        
        }
        //---ADD 2010/12/31-----------------------------------------------<<<<<

        //---ADD 2010/12/31----------------------------------------------->>>>>
        /// <summary>
        /// �t�n�d��������L���b�V�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�n�d��������L���b�V�����䏈�����s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        public void CacheUOESupplier_01633()
        {
            _uoeSupplier01633 = new List<UOESupplier>();
            List<UOESupplier> resultList = new List<UOESupplier>();
            try
            {
                ArrayList retList;
                int status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._loginSectionCode.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UOESupplier uoeSupplier in retList)
                    {
                        if (uoeSupplier.LogicalDeleteCode == 0)
                        {
                            resultList.Add(uoeSupplier);
                        }
                    }
                }

                resultList = resultList.FindAll(delegate(UOESupplier target)
                {
                    if (UOESupplierCd==target.UOESupplierCd)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (resultList != null && resultList.Count > 0)
                {
                    _uoeSupplier01633 = resultList;
                }
            }
            catch (Exception)
            {
                _uoeSupplier01633 = new List<UOESupplier>();
            }

        }
        //---ADD 2010/12/31-----------------------------------------------<<<<<
       
        /// <summary>
        /// �t�@�C�����擾����
        /// </summary>
        /// <param name="filesDataDtlList">�t�@�C�������</param>
        /// <param name="answerSaveFolder">�񓚕ۑ��t�H���_</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�������擾��������B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        protected override int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this._dataTable.Clear();

            CacheUOESupplier_01633(); // ADD 2010/12/31

            GetSupplierFlag();// ADD 2010/12/31
            // �t�@�C�����
            filesDataDtlList = new List<UOEOrderDtlInfo>();

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            FileStream fileStream = null;
            try
            {
                string filePathName = "";

				#region UOE_Out.csv���捞
				List<UOEOrderDtlInfo> orderDataDtlList = new List<UOEOrderDtlInfo>();
				filePathName = answerSaveFolder + "\\UOE_Out.csv";
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                string timeFormat = "yyyyMMddHHmmss";
                DateTime dt = DateTime.Now;
                string bakFilePathName = answerSaveFolder + "\\UOE_Out_" + dt.ToString(timeFormat)+".csv";
                File.Copy(filePathName, bakFilePathName);
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                if (File.Exists(filePathName))
				{
					try
					{
						// UOE_Out.csv�t�@�C���g�p�����f
                        fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
					}
					catch (IOException)
					{
						errMessage = "�����񓚃t�@�C�����g�p���ł��B";
						// �ُ�ꍇ
						return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
					}
					finally
					{
						if (fileStream != null)
						{
							fileStream.Close();
						}
					}

					List<string[]> csvDataList;
                    status = this.GetCSVData(out csvDataList, filePathName);

					string uoeRemark2 = "";
					for (int row = 0; row < csvDataList.Count; row++)
					{
						string[] detailInfo = csvDataList[row];

						if (detailInfo.Length == 40)
						{
                            //---UPD 2010/12/31----------------------------------------------->>>>>
                               if (UOESupplierFlag == 1)
                                {
                                    uoeRemark2 = detailInfo[7].Trim(); 
                                    UOEOrderDtlInfo uOEOrderDtlMitsubishiInfo = new UOEOrderDtlInfo();
                                    // �t�n�d���}�[�N�Q
                                    uOEOrderDtlMitsubishiInfo.UoeRemark2 = uoeRemark2; // ���}�[�N
                                    if (!this.CheckUoeRemark2(uoeRemark2))
                                    {
                                        continue;
                                    }
                                    int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlMitsubishiInfo, detailInfo);

                                    if (ret == -1)
                                    {
                                        continue;
                                    }
                                    orderDataDtlList.Add(uOEOrderDtlMitsubishiInfo);
                                }
                                else
                                {
                                    uoeRemark2 = detailInfo[6].Trim(); // ���}�[�N
                                    UOEOrderDtlInfo uOEOrderDtlMitsubishiInfo = new UOEOrderDtlInfo();

                                    // �t�n�d���}�[�N�Q
                                    uOEOrderDtlMitsubishiInfo.UoeRemark2 = uoeRemark2; // ���}�[�N
                                    if (!this.CheckUoeRemark2(uoeRemark2))
                                    {
                                        continue;
                                    }
                                    int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlMitsubishiInfo, detailInfo);

                                    if (ret == -1)
                                    {
                                        continue;
                                    }
                                    orderDataDtlList.Add(uOEOrderDtlMitsubishiInfo);
                                }
                            }
                            //---UPD 2010/12/31-----------------------------------------------<<<<<
						
					}
				}

				foreach (UOEOrderDtlInfo orderInfo in orderDataDtlList)
				{
					string uoeRemark2 = orderInfo.UoeRemark2;
					if (!uoeRemarkDic.ContainsKey(uoeRemark2))
					{
						List<UOEOrderDtlInfo> tempList = orderDataDtlList.FindAll(
											delegate(UOEOrderDtlInfo info)
											{
												if (info.UoeRemark2 == uoeRemark2)
												{
													return true;
												}
												else
												{
													return false;
												}
											}
						);

						filesDataDtlList.AddRange(tempList);

						uoeRemarkDic.Add(uoeRemark2.Trim(), null);
					}
				}
				#endregion
			}
            catch
            {
                // �ُ�ꍇ
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// �O�H���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">RCV���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �O�H���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        protected override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            // UPD 2010/12/31 ------------- >>>>>>>>>>>>>>>
            if (UOESupplierFlag == 1)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            else
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == COMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            // UPD 2010/12/31 ------------- <<<<<<<<<<<<<

            return retList;
        }

        /// <summary>
        /// �����񓚃f�[�^��UOE�����f�[�^�ɔ��f�̏���
        /// </summary>
        /// <param name="workList">UOE�����f�[�^</param>
        /// <param name="dateList">�����񓚃f�[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����񓚃f�[�^��UOE�����f�[�^�ɔ��fނ�����</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : 2010/05/07 �I�M</br>
		/// <br>           �@redmine#7035 B/O���̓��[�J�[�t�H���[���ɃZ�b�g</br>
        /// </remarks>
        protected override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                for (int i = 0; i < workList.Count; i++)
                {
                    if (i < dateList.Count)
                    {
                        // ��M���t	
                        workList[i].ReceiveDate = dateList[i].ReceiveDate;
                        //��M����
                        workList[i].ReceiveTime = dateList[i].ReceiveTime;
                        //�񓚕i��
                        workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                        //�񓚕i��
                        workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                        //��֕i��
                        workList[i].SubstPartsNo = dateList[i].SubstPartsNo;
                        //���_�o�ɐ�							
                        workList[i].UOESectOutGoodsCnt = dateList[i].UOESectOutGoodsCnt;
                        //BO�o�ɐ�1	
                        workList[i].BOShipmentCnt1 = dateList[i].BOShipmentCnt1;
                        //BO�o�ɐ�2							
                        workList[i].BOShipmentCnt2 = dateList[i].BOShipmentCnt2;
						// --- ADD 2010/05/07 ---------->>>>>
						// ���[�J�[�t�H���[��
						workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
						// --- ADD 2010/05/07 ----------<<<<<
						//���_�݌ɐ�				
						workList[i].UOESectStockCnt = dateList[i].UOESectStockCnt;
						//BO�݌ɐ�1					
						workList[i].BOStockCount1 = dateList[i].BOStockCount1;
						//BO�݌ɐ�2					
						workList[i].BOStockCount2 = dateList[i].BOStockCount2;
                        //UOE���_�`�[�ԍ�							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO�`�[��1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO�`�[��2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;
                        //�񓚒艿				
                        workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        //�񓚌����P��							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
						// --- DEL 2010/05/07 ---------->>>>>
						//// �a�n��
						//workList[i].BOCount = dateList[i].BOCount;
						// --- DEL 2010/05/07 ----------<<<<<
                        //���C���G���[���b�Z�[�W	
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // �f�[�^���M�敪
                        workList[i].DataSendCode = dateList[i].DataSendCode;
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        protected override void DataTableColumnConstruction()
        {
            DataTable table = new DataTable(TABLE_ID);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            table.Columns.Add(NO, typeof(string));   // No.
            table.Columns.Add(GOODSNO, typeof(string)); // �i��
            table.Columns.Add(GOODSMAKERCD, typeof(Int32)); // Ұ��(�^�C�g��)				
            table.Columns.Add(GOODSNAME, typeof(string)); // �i��(�^�C�g��)	
            table.Columns.Add(COUNT, typeof(Double)); // ����(�^�C�g��)		
            table.Columns.Add(ANSWERPARTSNO, typeof(string)); // �񓚕i��(�^�C�g��)		
            table.Columns.Add(LISTPRICE, typeof(Double)); // �艿(�^�C�g��)				
            table.Columns.Add(SALESUNITCOST, typeof(Double)); // �P��(�^�C�g��)				
            table.Columns.Add(COMMENT, typeof(string)); // �R�����g(�^�C�g��)				
            table.Columns.Add(UOESECTIONSLIPNO, typeof(string)); // ���_�`�[�ԍ�(�^�C�g��)				
            table.Columns.Add(UOESECTOUTGOODSCNT, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(BOSLIPNO1, typeof(string)); // BO�`�[�ԍ�1(�^�C�g��)				
            table.Columns.Add(BOSHIPMENTCNT1, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(BOSLIPNO2, typeof(string)); // BO�`�[�ԍ�2(�^�C�g��)				
            table.Columns.Add(BOSHIPMENTCNT2, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(MAKERFOLLOWCNT, typeof(Int32)); // Ұ��̫۰��(�^�C�g��)				


            table.Columns[NO].Caption = "No.";
            table.Columns[GOODSNO].Caption = "�i��"; // �i��
            table.Columns[GOODSMAKERCD].Caption = "Ұ��"; // �i��(�^�C�g��)				
            table.Columns[GOODSNAME].Caption = "�i��"; // �i��(�^�C�g��)				
            table.Columns[COUNT].Caption = "����"; // ����(�^�C�g��)				
            table.Columns[ANSWERPARTSNO].Caption = "�񓚕i��"; // �񓚕i��(�^�C�g��)				
            table.Columns[LISTPRICE].Caption = "�艿"; // �艿(�^�C�g��)				
            table.Columns[SALESUNITCOST].Caption = "�P��"; // �P��(�^�C�g��)				
            table.Columns[COMMENT].Caption = "�R�����g"; // �R�����g(�^�C�g��)				
			table.Columns[UOESECTIONSLIPNO].Caption = "���_"; // ���_�`�[�ԍ�(�^�C�g��)				
            table.Columns[UOESECTOUTGOODSCNT].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO1].Caption = "�T�u"; // BO�`�[�ԍ�1(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT1].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
			table.Columns[BOSLIPNO2].Caption = "�{��"; // BO�`�[�ԍ�2(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT2].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
			table.Columns[MAKERFOLLOWCNT].Caption = "�l�e"; // Ұ��̫۰��(�^�C�g��)	

            this._dataTable = table;
        }

        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        protected override void DataTableAddRow(List<UOEOrderDtlWork> workList)
        {
            int rowIndex = 1;
            foreach (UOEOrderDtlWork work in workList)
            {
                DataRow row = this._dataTable.NewRow();

                row[NO] = rowIndex.ToString();
                //�i��		
                row[GOODSNO] = work.GoodsNo;
                //Ұ��	
                row[GOODSMAKERCD] = work.GoodsMakerCd;
                //�i��	
                row[GOODSNAME] = work.GoodsName;
                //����
                row[COUNT] = work.AcceptAnOrderCnt;
                //�񓚕i��	
                row[ANSWERPARTSNO] = work.AnswerPartsNo;
                //�艿	
                row[LISTPRICE] = work.AnswerListPrice;
                //�P��	
                row[SALESUNITCOST] = work.AnswerSalesUnitCost;
                //�R�����g
                if (string.IsNullOrEmpty(work.HeadErrorMassage))
                {
                    row[COMMENT] = work.LineErrorMassage;
                }
                else
                {
                    row[COMMENT] = work.HeadErrorMassage;
                }
                //���_								
                row[UOESECTIONSLIPNO] = work.UOESectionSlipNo;
                //�o�א�
                row[UOESECTOUTGOODSCNT] = work.UOESectOutGoodsCnt;
                //�T�u								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //�o�א�								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //�{��								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //�o�א�								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //�l�e								
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;

                this._dataTable.Rows.Add(row);
                rowIndex++;
            }
        }
        # endregion

        # region -- DataTable�̏��� --
        /// <summary>
        /// ��������
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>�������ʂ����擾</remarks>
        public DataTable DetailDataTable
        {
            get { return this._dataTable; }
        }

        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�N���A�������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public override void DataTableClear()
        {
            this._dataTable.Clear();
        }
        #endregion

        # region -- �f�[�^�ϊ� --

        /// <summary>
        /// �O�H�����񓚃t�@�C����ں��ނ̏���
        /// </summary>
        /// <param name="uOEOrderDtlMitsubishiInfo">�����񓚃f�[�^</param>
        /// <param name="detailInfo">CSV��line�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �O�H�����񓚃t�@�C����ں��ނ�����</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : 2010/05/07 �I�M</br>
		/// <br>           �@redmine#7034 �񓚕i�ԃo�C�g�̏C��</br>
		/// <br>UpdateNote : 2010/05/07 �I�M</br>
		/// <br>           �@redmine#7035 B/O���̓��[�J�[�t�H���[���ɃZ�b�g</br>
        /// </remarks>
        private int ConverStringToUOEOrderDtlInfo(ref UOEOrderDtlInfo uOEOrderDtlMitsubishiInfo, string[] detailInfo)
        {
            // ��M���t
            uOEOrderDtlMitsubishiInfo.ReceiveDate = DateTime.Today; // �V�X�e�����t
            // ��M����
            uOEOrderDtlMitsubishiInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss")); // �V�X�e������
			// �񓚕i��
			uOEOrderDtlMitsubishiInfo.AnswerPartsNo = this.GetPartsNo(detailInfo[12]);  // ���i�ԍ�
			if (uOEOrderDtlMitsubishiInfo.AnswerPartsNo.Trim() == string.Empty)
			{
				return -1;
			}
			// �񓚕i��
			uOEOrderDtlMitsubishiInfo.AnswerPartsName = detailInfo[19]; // �i��
			// ���͕��i�ԍ��̓X�y�[�X�ȊO�̏ꍇ
			if (!string.IsNullOrEmpty(detailInfo[13]))
			{
				// ��֕i��
				//uOEOrderDtlMitsubishiInfo.SubstPartsNo = detailInfo[12];   // ���i�ԍ�  �@��1   DEL 2010/05/07
				uOEOrderDtlMitsubishiInfo.SubstPartsNo = this.GetPartsNo(detailInfo[12]);   // ���i�ԍ�  �@��1  ADD 2010/05/07
			}
			// ���_�o�ɐ�
			uOEOrderDtlMitsubishiInfo.UOESectOutGoodsCnt = this.StringToInt(detailInfo[22]); // ���_1�o�א�
			// BO�o�ɐ�1
			uOEOrderDtlMitsubishiInfo.BOShipmentCnt1 = this.StringToInt(detailInfo[26]);  // ���_2�o�א�
            // BO�o�ɐ�2
			uOEOrderDtlMitsubishiInfo.BOShipmentCnt2 = this.StringToInt(detailInfo[30]);  // ���_3�o�א�
			// ���_�݌ɐ�
			uOEOrderDtlMitsubishiInfo.UOESectStockCnt = this.StringToInt(detailInfo[23]); // ���_1�c�݌ɐ�
			// BO�݌ɐ�1
			uOEOrderDtlMitsubishiInfo.BOStockCount1 = this.StringToInt(detailInfo[27]);  // ���_2�c�݌ɐ�
			// BO�݌ɐ�2
			uOEOrderDtlMitsubishiInfo.BOStockCount2 = this.StringToInt(detailInfo[31]);  // ���_3�c�݌ɐ�
			// --- ADD 2010/05/07 ---------->>>>>
			// ���[�J�[�t�H���[��
			uOEOrderDtlMitsubishiInfo.MakerFollowCnt = this.StringToInt(detailInfo[33]);  // B/O��
			// --- ADD 2010/05/07 ----------<<<<<
            // UOE���_�`�[�ԍ�
			uOEOrderDtlMitsubishiInfo.UOESectionSlipNo = detailInfo[24]; // ���_1�`�[No.
            // BO�`�[��1
			uOEOrderDtlMitsubishiInfo.BOSlipNo1 = detailInfo[28]; // ���_2�`�[No.
			// BO�`�[��2
			uOEOrderDtlMitsubishiInfo.BOSlipNo2 = detailInfo[32]; // ���_3�`�[No.
            // �񓚒艿
			uOEOrderDtlMitsubishiInfo.AnswerListPrice = this.StringToDouble(detailInfo[18]);// L/P
            // �񓚌����P��
            uOEOrderDtlMitsubishiInfo.AnswerSalesUnitCost = this.StringToDouble(detailInfo[17]);// �d��
			// --- DEL 2010/05/07 ---------->>>>>
			//// �a�n��
			//uOEOrderDtlMitsubishiInfo.BOCount = this.GetBONum(detailInfo[33]);// B/O��
			// --- DEL 2010/05/07 ----------<<<<<
			// ���C���G���[���b�Z�[�W
			uOEOrderDtlMitsubishiInfo.LineErrorMassage = detailInfo[20];// ���b�Z�[�W
            // �f�[�^���M�敪
            uOEOrderDtlMitsubishiInfo.DataSendCode = 5;// 5:�񓚖���

            return 0;
        }
        #endregion

        # region -- �f�[�^�̏��� --
        /// <summary>
        /// �i�Ԃ̏���
        /// </summary>
        /// <param name="filePartsNo">���i�ԍ��P�Q���{�n�C�t���~�Q</param>
        /// <returns>�i��</returns>
        /// <remarks>
        /// <br>Note       : �i�Ԃ̏������s��</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : 2010/05/07 �I�M</br>
		/// <br>           �@redmine#7034 �񓚕i�ԃo�C�g�̏C��</br>
        /// </remarks>
		private string GetPartsNo(string filePartsNo)
		{
			if (string.IsNullOrEmpty(filePartsNo))
			{
				return "";
			}
			// --- DEL 2010/05/07 ---------->>>>>
			//if (filePartsNo.Length > 12)
			//{
			//    return filePartsNo.Substring(0, 12);
			//}
			// --- DEL 2010/05/07 ----------<<<<<
			// --- ADD 2010/05/07 ---------->>>>>
			if (filePartsNo.Length > 20)
			{
				return filePartsNo.Substring(0, 20);
			}
			// --- ADD 2010/05/07 ----------<<<<<
			else
			{
				return filePartsNo;
            }
        }

        /// <summary>
        /// B/O���̏���
        /// </summary>
        /// <param name="fileBONum">*-ZZZ (BO�敪�{"-"�{BO��)</param>
        /// <returns>B/O��</returns>
        /// <remarks>
        /// <br>Note       : �i�Ԃ̏������s��</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private int GetBONum(string fileBONum)
        {
            if (string.IsNullOrEmpty(fileBONum))
            {
                return 0;
            }

            int indexStr = fileBONum.IndexOf("-");

            return this.StringToInt(fileBONum.Substring(indexStr + 1));
        }

        /// <summary>
        /// �J���}�폜����
        /// </summary>
        /// <param name="targetText">�J���}�폜�O�e�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : �Ώۂ̃e�L�X�g����J���}���폜���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private string RemoveComma(string targetText)
        {
            if (string.IsNullOrEmpty(targetText))
            {
                return "";
            }
            // �Z���l�ҏW�p�ɃJ���}�E�s���I�h�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // �J���}�̂ݍ폜
                if (targetText[i].ToString() == ",")
                {
                    targetText = targetText.Remove(i, 1);
                }
            }

            return targetText;
        }
        #endregion

		# region -- �m�菈�� --
		/// <summary>
		/// �m�菈��
		/// </summary>
		/// <param name="answerDateMitsubishiPara">��ʏ��</param>
		/// <param name="errMessage">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
		/// <remarks>
		/// <br>Note       : �m�菈������B</br>
		/// <br>Programmer : �я���</br>
		/// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : </br>
		/// </remarks>
		public override int DoConfirm(AnswerDateMitsubishiPara answerDateMitsubishiPara, out string errMessage)
		{
			errMessage = string.Empty;
			// ���̊m�F�������ďo��
			int status = base.DoConfirm(answerDateMitsubishiPara, out errMessage);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �O�HWebUOE�����񓚃t�@�C�����폜
				string filePathName = answerDateMitsubishiPara.AnswerSaveFolder + "\\UOE_Out.csv";
				if (File.Exists(filePathName))
					File.Delete(filePathName);
			}
			return status;
		}
		#endregion
	}
}
