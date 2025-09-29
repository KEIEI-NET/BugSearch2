//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\�A�N�Z�X�N���X
// �v���O�����T�v   : ���׍��ٕ\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00  �쐬�S�� : 杍^
// �� �� ��  K2019/08/14  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���׍��ٕ\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���׍��ٕ\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class ArrGoodsDiffAcs
    {
        #region �� Constructor
		/// <summary>
		/// ���׍��ٕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���׍��ٕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : K2019/08/14</br>
        /// </remarks>
        public ArrGoodsDiffAcs()
		{
            this.ArrGoodsDiffResultDB = (IArrGoodsDiffResultDB)MediationArrGoodsDiffResultDB.GetArrGoodsDiffResultDB();

            this.EnterpriseCd = LoginInfoAcquisition.EnterpriseCode;

            SPrtOutSet = null;                  // ���[�o�͐ݒ�f�[�^�N���X
            SPrtOutSetAcs = new PrtOutSetAcs(); // ���[�o�͐ݒ�A�N�Z�X�N���X
            this.UoeSndRcvJnlAccess = UoeSndRcvJnlAcs.GetInstance();
		}

		/// <summary>
		/// ���׍��ٕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���׍��ٕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public ArrGoodsDiffAcs(string param)
        {
            if (param.Equals("NUnit"))
            {
                //�@�Ȃ�
            }
        }
        #endregion �� Constructor

        #region �� Private Member
        // ���׍��ٕ\�C���^�t�F�[�X
        private IArrGoodsDiffResultDB ArrGoodsDiffResultDB;

        // DataSet�I�u�W�F�N�g
        private DataSet ArrGoodsDiffDataSet;

        // ��ƃR�[�h
        private string EnterpriseCd;

        // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSet SPrtOutSet;
        // ���[�o�͐ݒ�A�N�Z�X�N���X
        private static PrtOutSetAcs SPrtOutSetAcs;

        // �o�͐ݒ�̓Ǎ����s�G���[���b�Z�[�W
        private const string SettingFail = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";

        private const string ErrorMessage = "���׍��ٕ\�̏o�̓f�[�^�̎擾�Ɏ��s���܂����B";

        private UoeSndRcvJnlAcs UoeSndRcvJnlAccess;

        // �y�[�W���Ƀf�[�^�s��
        private const int RowCountPerPage = 50;

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// �f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet DataSet
        {
            get { return this.ArrGoodsDiffDataSet; }
        }

        /// <summary>
        /// UOE������}�X�^�A�N�Z�X�N���X
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return UoeSndRcvJnlAccess.uOESupplierAcs; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� ���׍��ٕ\�f�[�^�擾
        /// <summary>
        /// ���׍��ٕ\�f�[�^�擾
        /// </summary>
        /// <param name="arrGoodsDiffCndtnWork">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���������׍��ٕ\�f�[�^���擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : K2019/08/14</br>
        /// </remarks>
        public int SearchArrGoodsDiffProcMain(ArrGoodsDiffCndtnWork arrGoodsDiffCndtnWork, out string errMsg)
        {
            return this.SearchArrGoodsDiffProc(arrGoodsDiffCndtnWork, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾

        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�o�͐ݒ�擾����</returns>
        /// <remarks>
        /// <br>Note       : ���[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (SPrtOutSet != null)
                {
                    retPrtOutSet = SPrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = SPrtOutSetAcs.Read(out SPrtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = SPrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = SettingFail;
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                WriteErrorLog(ex, "ArrGoodsDiffAcs.ReadPrtOutSet", status);
            }
            return status;
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="arrGoodsDiffCndtnWork">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���������׍��ٕ\�f�[�^���擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : K2019/08/14</br>
        /// </remarks>
        private int SearchArrGoodsDiffProc(ArrGoodsDiffCndtnWork arrGoodsDiffCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            ArrayList arrGoodsDiffList = null;

            try
            {
                #region [���׍��ٕ\����]

                // DataTable���쐬
                PMKOU02354EA.CreateDataTable(ref ArrGoodsDiffDataSet);

                // R�N���X��Search���\�b�h�R�[���p�ɐ��`
                object retList = null;
                object paraWorkRef = arrGoodsDiffCndtnWork;

                // Search���\�b�h�R�[��
                status = ArrGoodsDiffResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        arrGoodsDiffList = (ArrayList)retList;
                        if (arrGoodsDiffList.Count <= 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        retList = null;
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = ErrorMessage;
                        break;
                }

                #endregion

                #region [���̕ҏW�̂��߂̃f�[�^������DataSet�ւ̃f�[�^�W�J]

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    ConverToDataSet(ArrGoodsDiffDataSet.Tables[PMKOU02354EA.ct_Tbl_ArrGoodsDiffReportData], arrGoodsDiffList);
                }

                #endregion

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

        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// DataTable�Ƀf�[�^��ݒ菈��
        /// </summary>
        /// <param name="dataTable">���[�pDataTable</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <remarks>
        /// <br>Note       : DataTable�Ƀf�[�^��ݒ菈�����s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void ConverToDataSet(DataTable dataTable, ArrayList retList)
        {
            DataRow dr = null;
            ArrGoodsDiffResultWork rsltInfo = null;
            double difNum = 0;

            for (int cnt = 0; cnt < retList.Count; cnt++)
            {
                // ���Y�s
                rsltInfo = (ArrGoodsDiffResultWork)retList[cnt];

                difNum = rsltInfo.OrderCnt - rsltInfo.OrderRemainCnt - rsltInfo.InspectCnt;
                if (difNum == 0) continue;

                // �O�s�f�[�^
                ArrGoodsDiffResultWork preArrGoodsDifWork = null;

                if (cnt > 0)
                {
                    preArrGoodsDifWork = retList[cnt - 1] as ArrGoodsDiffResultWork;
                }

                dr = dataTable.NewRow();

                // ������R�[�h
                dr[PMKOU02354EA.ct_Col_UOESupplierCd] = SetGroupValue(0, cnt, rsltInfo, preArrGoodsDifWork);
                // �����於
                dr[PMKOU02354EA.ct_Col_UOESupplierNm] = SetGroupValue(1, cnt, rsltInfo, preArrGoodsDifWork);
                // �`�[�ԍ�
                dr[PMKOU02354EA.ct_Col_SupplierSlipNo] = SetGroupValue(2, cnt, rsltInfo, preArrGoodsDifWork);
                // �i��
                dr[PMKOU02354EA.ct_Col_GoodsNo] = rsltInfo.GoodsNo;
                // �i��
                dr[PMKOU02354EA.ct_Col_GoodsName] = rsltInfo.GoodsName;
                // ���[�J�[
                dr[PMKOU02354EA.ct_Col_MakerName] = rsltInfo.MakerName;
                // ������
                dr[PMKOU02354EA.ct_Col_OrderCnt] = rsltInfo.OrderCnt;
                // �����c
                dr[PMKOU02354EA.ct_Col_OrderRemainCnt] = rsltInfo.OrderRemainCnt;
                // ���i��
                dr[PMKOU02354EA.ct_Col_InspectCnt] = rsltInfo.InspectCnt;
                // ���ِ�
                dr[PMKOU02354EA.ct_Col_DiffCnt] = difNum;
                // �q��
                dr[PMKOU02354EA.ct_Col_WarehouseName] = rsltInfo.WarehouseName;
                // ������
                dr[PMKOU02354EA.ct_Col_StockAgentName] = rsltInfo.EmployeeName;

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #region �� �G���[���O�o�͏���
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorText">�G���[���e</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note	   : �G���[���O�o�͂��s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                new ClientLogTextOut().Output(ex.Source, message, status, ex);
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }
        #endregion �� �G���[���O�o�͏���

        # region �� UOE��������L���b�V�����䏈��
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�����於��</returns>
        /// <remarks>
        /// <br>Note	   : �G���[���O�o�͂��s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public string GetName_FromUOESupplier(int uOESupplierCd)
        {
            UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);

            if (uOESupplier == null)
            {
                return "";
            }
            else
            {
                return uOESupplier.UOESupplierName;
            }
        }

        /// <summary>
        /// UOE������N���X�擾
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <returns>UOE������N���X</returns>
        /// <remarks>
        /// <br>Note	   : �G���[���O�o�͂��s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        public UOESupplier GetUOESupplier(int uOESupplierCd)
        {
            UOESupplier uOESupplier = UoeSndRcvJnlAccess.SearchUOESupplier(uOESupplierCd);
            return (uOESupplier);
        }

        /// <summary>
        /// UOE�����摶�݃`�F�b�N
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : �G���[���O�o�͂��s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        public bool UOESupplierExists(int uOESupplierCd)
        {
            UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);
            return (uOESupplier != null);
        }
        # endregion �� UOE��������L���b�V�����䏈��

        # region �� �O�s�Ɠ��O�s�l���ڒl��r����
        /// <summary>
        /// �O�s�Ɠ��O�s�l���ڒl��r���ݒ菈��
        /// </summary>
        /// <param name="mode">0:������R�[�h 1:�����於 2:�`�[�ԍ�</param>
        /// <param name="rowNo">�s��</param>
        /// <param name="currWork">���O�s�f�[�^</param>
        /// <param name="prevWork">�O�s�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �O�s�Ɠ��O�s�l���ڒl��r���ݒ菈�����s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public string SetGroupValue(int mode, int rowNo, ArrGoodsDiffResultWork currWork, ArrGoodsDiffResultWork prevWork)
        {
            string resultStr = string.Empty;

            switch (mode)
            {
                // ������R�[�h
                case 0:
                    if (rowNo % RowCountPerPage == 0 || (rowNo % RowCountPerPage != 0 && currWork.UOESupplierCd != prevWork.UOESupplierCd))
                    {
                        resultStr = currWork.UOESupplierCd.ToString("000000");
                    }
                    break;
                // �����於
                case 1:
                    if (rowNo % RowCountPerPage == 0 || (rowNo % RowCountPerPage != 0 && currWork.UOESupplierCd != prevWork.UOESupplierCd))
                    {
                        resultStr = currWork.UOESupplierName.Trim();
                    }
                    break;
                // �`�[�ԍ�
                case 2:
                    if (rowNo % RowCountPerPage == 0 || (rowNo % RowCountPerPage != 0 && currWork.SupplierSlipNo != prevWork.SupplierSlipNo))
                    {
                        resultStr = currWork.SupplierSlipNo.ToString("000000000");
                    }
                    break;
                default:
                    // �Ȃ�
                    break;
            }

            return resultStr;
        }
        # endregion �� �O�s�Ɠ��O�s�l���ڒl��r����

        #endregion �� Private Method
    }
}
