using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����f�[�^�ꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �����f�[�^�ꗗ�\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.12.02</br>
    /// <br>             : </br>
    /// </remarks>
    public class RecoveryDataOrderAcs
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// �����f�[�^�ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �����f�[�^�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.02</br>
		/// </remarks>
		public RecoveryDataOrderAcs()
		{
            this._iRecoveryDataOrderWorkDB = (IRecoveryDataOrderWorkDB)MediationRecoveryDataOrderWorkDB.GetRecoveryDataOrderWorkDB();
		}

		/// <summary>
        /// �����f�[�^�ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �����f�[�^�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.02</br>
		/// </remarks>
        static RecoveryDataOrderAcs()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs      = new SecInfoAcs(1);    // ���_�A�N�Z�X�N���X
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // ���_Dictionary

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // �����łȂ����
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // �ǉ�
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
		#endregion

        #region �� Static�ϐ�
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X

        private static SecInfoAcs stc_SecInfoAcs;               // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary

        #endregion

        #region �� Private�ϐ�

        IRecoveryDataOrderWorkDB _iRecoveryDataOrderWorkDB;

        private DataTable _recoveryDataOrderDt; // ���DataTable
        private DataView _recoveryDataOrderDv; // ���DataView

        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView RecoveryDataOrderDataView
        {
            get { return this._recoveryDataOrderDv; }
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        public int SearchMain(RecoveryDataOrderCndtn recoveryDataOrderCndtn, out string errMsg)
        {
            return this.SearchProc(recoveryDataOrderCndtn, out errMsg);
        }

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
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
            }
            return status;
        }
        #endregion

        #region �� Private���\�b�h
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="recoveryDataOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private int SearchProc(RecoveryDataOrderCndtn recoveryDataOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMUOE02059EA.CreateDataTable(ref this._recoveryDataOrderDt);

                RecoveryDataOrderCndtnWork recoveryDataOrderCndtnWork = new RecoveryDataOrderCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(recoveryDataOrderCndtn, out recoveryDataOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iRecoveryDataOrderWorkDB.Search(out retWorkList, recoveryDataOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // �e�X�g�p
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(recoveryDataOrderCndtn, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�����f�[�^�ꗗ�\�f�[�^�̎擾�Ɏ��s���܂����B";
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

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="salesRsltListCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ��ʒ��o�����������[�g���o�����֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private int DevListCndtn(RecoveryDataOrderCndtn recoveryDataOrderCndtn, out RecoveryDataOrderCndtnWork recoveryDataOrderCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            recoveryDataOrderCndtnWork = new RecoveryDataOrderCndtnWork();
            try
            {
                recoveryDataOrderCndtnWork.EnterpriseCode = recoveryDataOrderCndtn.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (recoveryDataOrderCndtn.SectionCodes.Length != 0)
                {
                    if (recoveryDataOrderCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        recoveryDataOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        recoveryDataOrderCndtnWork.SectionCodes = recoveryDataOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    recoveryDataOrderCndtnWork.SectionCodes = null;
                }

                recoveryDataOrderCndtnWork.SystemDivCd = (int)recoveryDataOrderCndtn.SystemDivCd; // �V�X�e���敪

                recoveryDataOrderCndtnWork.St_UOESupplierCd = recoveryDataOrderCndtn.St_UOESupplierCd; // �J�nUOE������R�[�h
                if (recoveryDataOrderCndtn.Ed_UOESupplierCd == 0) recoveryDataOrderCndtnWork.Ed_UOESupplierCd = 999999;
                else recoveryDataOrderCndtnWork.Ed_UOESupplierCd = recoveryDataOrderCndtn.Ed_UOESupplierCd; // �I��UOE������R�[�h


                
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       �@: �����[�g���o���ʂ𒠕[�󎚗pDataTable�֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private void DevListData(RecoveryDataOrderCndtn recoveryDataOrderCndtn, ArrayList resultWork)
        {
            // �����[�g���o���ʂ�DataTable�ɓW�J
            DataRow dr;

            // ���o�����̍쐬
            string extractConditions = this.GetExtractConditions(recoveryDataOrderCndtn);

            foreach (RecoveryDataResultWork recoveryDataResultWork in resultWork)
            {
                dr = this._recoveryDataOrderDt.NewRow();

                dr[PMUOE02059EA.ct_Col_SectionCode] = recoveryDataResultWork.SectionCode; // ���_�R�[�h
                dr[PMUOE02059EA.ct_Col_SectionGuideSnm] = recoveryDataResultWork.SectionGuideSnm; // ���_�K�C�h����
                dr[PMUOE02059EA.ct_Col_UOESupplierCd] = recoveryDataResultWork.UOESupplierCd; // UOE������R�[�h
                dr[PMUOE02059EA.ct_Col_UOESupplierName] = recoveryDataResultWork.UOESupplierName; // UOE�����於��
                dr[PMUOE02059EA.ct_Col_OnlineNo] = recoveryDataResultWork.OnlineNo; // �I�����C��No
                dr[PMUOE02059EA.ct_Col_GoodsNo] = recoveryDataResultWork.GoodsNo; // ���i�ԍ�
                dr[PMUOE02059EA.ct_Col_GoodsName] = recoveryDataResultWork.GoodsName; // ���i����
                dr[PMUOE02059EA.ct_Col_GoodsMakerCd] = recoveryDataResultWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
                dr[PMUOE02059EA.ct_Col_AcceptAnOrderCnt] = recoveryDataResultWork.AcceptAnOrderCnt; // �󒍐���
                dr[PMUOE02059EA.ct_Col_BoCode] = recoveryDataResultWork.BoCode; // Bo�敪
                dr[PMUOE02059EA.ct_Col_UoeRemark1] = recoveryDataResultWork.UoeRemark1; // �t�n�d���}�[�N1
                dr[PMUOE02059EA.ct_Col_DataSendCode] = recoveryDataResultWork.DataSendCode; // �f�[�^���M�敪
                dr[PMUOE02059EA.ct_Col_OnlineRowNo] = recoveryDataResultWork.OnlineRowNo; // �I�����C���s�ԍ�
                dr[PMUOE02059EA.ct_Col_SystemDivCd] = recoveryDataResultWork.SystemDivCd;// �V�X�e���敪

                // ���o����
                dr[PMUOE02059EA.ct_Col_ExtractCondition] = extractConditions;
                // �V�X�e���敪����
                dr[PMUOE02059EA.ct_Col_SystemDivName] = this.GetSystemDivName(recoveryDataResultWork.SystemDivCd);
                // �G���[���e(�f�[�^���M�敪����)
                dr[PMUOE02059EA.ct_Col_DataSendName] = this.GetDataSendName(recoveryDataResultWork.DataSendCode);

                this._recoveryDataOrderDt.Rows.Add(dr);
            }

            // DataView�쐬
            // ���s�^�C�v�ɂ��\�[�g
            this._recoveryDataOrderDv = new DataView(this._recoveryDataOrderDt, "", this.GetSortStr(), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// ���o�����擾
        /// </summary>
        /// <param name="recoveryDataOrderCndtn"></param>
        /// <returns>���o����������</returns>
        /// <remarks>
        /// <br>Note       �@: ���[�Ɉ󎚂��钊�o������������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetExtractConditions(RecoveryDataOrderCndtn recoveryDataOrderCndtn)
        {
            StringBuilder extractConditions = new StringBuilder(); ;

            string stCode;
            string edCode;

            // �V�X�e���敪
            extractConditions.Append(string.Format("�V�X�e���敪�F{0}",
                                                recoveryDataOrderCndtn.SystemDivStateTitle));

            extractConditions.Append("�@");

            // ������
            if ((recoveryDataOrderCndtn.St_UOESupplierCd != 0) ||
                ((recoveryDataOrderCndtn.Ed_UOESupplierCd != 0) &&
                 (!string.IsNullOrEmpty(recoveryDataOrderCndtn.Ed_UOESupplierCd.ToString()))))
            {
                stCode = recoveryDataOrderCndtn.St_UOESupplierCd.ToString("000000");
                edCode = recoveryDataOrderCndtn.Ed_UOESupplierCd.ToString("000000");
                if (recoveryDataOrderCndtn.St_UOESupplierCd == 0) stCode = "�ŏ�����";

                if ((recoveryDataOrderCndtn.Ed_UOESupplierCd == 0) ||
                    (string.IsNullOrEmpty(recoveryDataOrderCndtn.Ed_UOESupplierCd.ToString())))
                {
                    edCode = "�Ō�܂�";
                }

                extractConditions.Append(string.Format("������F{0} �` {1}", stCode, edCode));
            }

            return extractConditions.ToString();
        }

        /// <summary>
        /// �V�X�e���敪���̎擾
        /// </summary>
        /// <param name="SystemDivCd"></param>
        /// <returns>�V�X�e���敪����</returns>
        /// <remarks>
        /// <br>Note       �@: ���[�Ɉ󎚂���V�X�e���敪���̕�������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetSystemDivName(int SystemDivCd)
        {
            switch ((RecoveryDataOrderCndtn.SystemDivState)SystemDivCd)
            {
                case RecoveryDataOrderCndtn.SystemDivState.Manual:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Manual;
                    }
                    case RecoveryDataOrderCndtn.SystemDivState.Slip:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Slip;
                    }
                    case RecoveryDataOrderCndtn.SystemDivState.Search:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Search;
                    }
                    case RecoveryDataOrderCndtn.SystemDivState.Lump:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Lump;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }

        }

        /// <summary>
        /// �G���[���e(�f�[�^���M�敪����)
        /// </summary>
        /// <param name="SystemDivCd"></param>
        /// <returns>�f�[�^���M�敪����</returns>
        /// <remarks>
        /// <br>Note       �@: ���[�Ɉ󎚂���f�[�^���M�敪���̕�������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetDataSendName(int DataSendCd)
        {
            switch ((RecoveryDataOrderCndtn.DataSendCodeState)DataSendCd)
            {
                case RecoveryDataOrderCndtn.DataSendCodeState.SendErr:
                    {
                        return RecoveryDataOrderCndtn.ct_DataSendCode_SendErr;
                    }
                case RecoveryDataOrderCndtn.DataSendCodeState.ReceiveErr:
                    {
                        return RecoveryDataOrderCndtn.ct_DataSendCode_ReceiveErr;
                    }
                case RecoveryDataOrderCndtn.DataSendCodeState.AbnormalErr:
                    {
                        return RecoveryDataOrderCndtn.ct_DataSendCode_AbnormalErr;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// DataView�p�\�[�g������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       �@: �\�[�g��������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetSortStr()
        {
            // ���_-�V�X�e���敪-������-�I�����C���ԍ�(�ďo�ԍ�)-�I�����C���s�ԍ�-�i�ԏ� 
            return PMUOE02059EA.ct_Col_SectionCode + ", " + PMUOE02059EA.ct_Col_SystemDivCd + ", "
                 + PMUOE02059EA.ct_Col_UOESupplierCd + ", " + PMUOE02059EA.ct_Col_OnlineNo + ", "
                 + PMUOE02059EA.ct_Col_OnlineRowNo + ", " + PMUOE02059EA.ct_Col_GoodsNo;
        }
        #endregion

        #region �e�X�g�f�[�^
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            RecoveryDataResultWork param1 = new RecoveryDataResultWork();

            param1.SectionCode = "";
            param1.SectionGuideSnm = "";
            param1.UOESupplierCd = 0;
            param1.UOESupplierName = "";
            param1.OnlineNo = 0;
            param1.GoodsNo = "";
            param1.GoodsName = "";
            param1.GoodsMakerCd = 0;
            param1.AcceptAnOrderCnt = 0;
            param1.BoCode = "";
            param1.UoeRemark1 = "";
            param1.DataSendCode = 0;
            param1.OnlineRowNo = 0;
            param1.SystemDivCd = 0;

            paramlist.Add(param1);

            RecoveryDataResultWork param2 = new RecoveryDataResultWork();

            param2.SectionCode = "01";
            param2.SectionGuideSnm = "���_���̂͂P�O���ł�";
            param2.UOESupplierCd = 1;
            param2.UOESupplierName = "������R�[�h���͑S�p�P�T���ł�";
            param2.OnlineNo = 1;
            param2.GoodsNo = "123456789012345678901234";
            param2.GoodsName = "12345678901234567890";
            param2.GoodsMakerCd = 12;
            param2.AcceptAnOrderCnt = 11.1;
            param2.BoCode = "1";
            param2.UoeRemark1 = "12345678901234567890";
            param2.DataSendCode = 3;
            param2.OnlineRowNo = 1;
            param2.SystemDivCd = 1;

            paramlist.Add(param2);

            RecoveryDataResultWork param3 = new RecoveryDataResultWork();

            param3.SectionCode = "01";
            param3.SectionGuideSnm = "���_���̂͂P�O���ł�";
            param3.UOESupplierCd = 1;
            param3.UOESupplierName = "������R�[�h���͑S�p�P�T���ł�";
            param3.OnlineNo = 1;
            param3.GoodsNo = "123456789012345678901234";
            param3.GoodsName = "12345678901234567890";
            param3.GoodsMakerCd = 12;
            param3.AcceptAnOrderCnt = 11.1;
            param3.BoCode = "1";
            param3.UoeRemark1 = "12345678901234567890";
            param3.DataSendCode = 4;
            param3.OnlineRowNo = 1;
            param3.SystemDivCd = 2;

            paramlist.Add(param3);

            RecoveryDataResultWork param4 = new RecoveryDataResultWork();

            param4.SectionCode = "01";
            param4.SectionGuideSnm = "���_���̂͂P�O���ł�";
            param4.UOESupplierCd = 1;
            param4.UOESupplierName = "������R�[�h���͑S�p�P�T���ł�";
            param4.OnlineNo = 1;
            param4.GoodsNo = "123456789012345678901234";
            param4.GoodsName = "12345678901234567890";
            param4.GoodsMakerCd = 12;
            param4.AcceptAnOrderCnt = 11.1;
            param4.BoCode = "1";
            param4.UoeRemark1 = "12345678901234567890";
            param4.DataSendCode = 4;
            param4.OnlineRowNo = 1;
            param4.SystemDivCd = 3;

            paramlist.Add(param4);

            RecoveryDataResultWork param5 = new RecoveryDataResultWork();

            param5.SectionCode = "02";
            param5.SectionGuideSnm = "���_���̂͂P�O���ł�";
            param5.UOESupplierCd = 1;
            param5.UOESupplierName = "������R�[�h���͑S�p�P�T���ł�";
            param5.OnlineNo = 1;
            param5.GoodsNo = "123456789012345678901234";
            param5.GoodsName = "12345678901234567890";
            param5.GoodsMakerCd = 12;
            param5.AcceptAnOrderCnt = 11.1;
            param5.BoCode = "1";
            param5.UoeRemark1 = "12345678901234567890";
            param5.DataSendCode = 4;
            param5.OnlineRowNo = 1;
            param5.SystemDivCd = 4;

            paramlist.Add(param5);

            RecoveryDataResultWork param6 = new RecoveryDataResultWork();

            param6.SectionCode = "02";
            param6.SectionGuideSnm = "���_���̂͂P�O���ł�";
            param6.UOESupplierCd = 1;
            param6.UOESupplierName = "������R�[�h���͑S�p�P�T���ł�";
            param6.OnlineNo = 1;
            param6.GoodsNo = "123456789012345678901234";
            param6.GoodsName = "12345678901234567890";
            param6.GoodsMakerCd = 12;
            param6.AcceptAnOrderCnt = 11.1;
            param6.BoCode = "1";
            param6.UoeRemark1 = "12345678901234567890";
            param6.DataSendCode = 4;
            param6.OnlineRowNo = 1;
            param6.SystemDivCd = 4;

            paramlist.Add(param6);


            retList = (object)paramlist;

            return 0;
        }
        #endregion 
    }
}
