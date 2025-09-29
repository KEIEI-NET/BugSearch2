//****************************************************************************//
// �V�X�e��         : ���M�O���X�g
// �v���O��������   : ���M�O���X�g �e�[�u���A�N�Z�X�N���X
// �v���O�����T�v   : ���M�O���X�g �e�[�u���A�N�Z�X�N���X���������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/09/11  �C�����e : MAHNB02015A�F�����m�F�\���Q�l�ɐV�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.ReportData;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���M�O���X�g �e�[�u���A�N�Z�X�N���X
    /// </summary>
    public sealed class SendBeforeAcs
    {
        #region <���O�C���]�ƈ�/>

        /// <summary>���O�C���]�ƈ�</summary>
        private static readonly Employee _loginEmployee;
        /// <summary>
        /// ���O�C���]�ƈ����擾���܂��B
        /// </summary>
        /// <value>���O�C���]�ƈ�</value>
        private static Employee LoginEmployee { get { return SendBeforeAcs._loginEmployee; } }

        #endregion  // <���O�C���]�ƈ�/>

        #region <���[�o�͐ݒ�/>

        /// <summary>���[�o�͐ݒ�f�[�^</summary>
        private static PrtOutSet _printtOutSet;

        /// <summary>���[�o�͐ݒ�A�N�Z�X</summary>
        private static readonly PrtOutSetAcs _printOutSetAcs;
        /// <summary>
        /// ���[�o�͐ݒ�A�N�Z�X���擾���܂��B
        /// </summary>
        /// <value>���[�o�͐ݒ�A�N�Z�X</value>
        private static PrtOutSetAcs PrintOutSetAcs { get { return _printOutSetAcs; } }

        #endregion  // <���[�o�͐ݒ�/>

        #region <���M�O���X�gDB�����[�g/>

        /// <summary>���M�O���X�gDB�����[�g</summary>
        private readonly ISendBeforOrdeWorkDB _sendBeforeDBRemote;
        /// <summary>
        /// ���M�O���X�gDB�����[�g���擾���܂��B
        /// </summary>
        /// <value>���M�O���X�gDB�����[�g</value>
        private ISendBeforOrdeWorkDB SendBeforeDBRemote { get { return _sendBeforeDBRemote; } }

        #endregion  // <���M�O���X�gDB�����[�g/>

        #region <��������/>

        /// <summary>���M�O���X�gDB�̌������ʂ̃f�[�^�e�[�u����</summary>
        private const string SEARCHED_DATA_TABLE_NAME = "SendBefore";   // TODO:�e�[�u������ύX�����ꍇ�A�{�萔���ύX���邱��
        /// <summary>
        /// ���M�O���X�gDB�̌������ʂ̃f�[�^�e�[�u�������擾���܂��B
        /// </summary>
        /// <value>���M�O���X�gDB�̌������ʂ̃f�[�^�e�[�u����</value>
        public static string SearchedDataTableName { get { return SEARCHED_DATA_TABLE_NAME; } }

        /// <summary>���M�O���X�gDB�̌�������</summary>
        private SendBeforeDataSet _searchedResult;
        /// <summary>
        /// ���M�O���X�gDB�̌������ʂ��擾���܂��B
        /// </summary>
        /// <value>���M�O���X�gDB�̌�������</value>
        public SendBeforeDataSet SearchedResult
        {
            get
            {
                if (_searchedResult == null)
                {
                    _searchedResult = new SendBeforeDataSet();
                }
                return _searchedResult;
            }
        }

        #endregion  // <��������/>

        #region <Constructor/>

        /// <summary>
        /// �ÓI�R���X�g���N�^
        /// </summary>
        static SendBeforeAcs()
        {
            // ���O�C���]�ƈ�
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null) _loginEmployee = loginEmployee;

            // ���[�o�͐ݒ�f�[�^
            _printtOutSet = null;

            // ���[�o�͐ݒ�A�N�Z�X
            _printOutSetAcs = new PrtOutSetAcs();
        }

		/// <summary>
        /// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public SendBeforeAcs()
		{
            _sendBeforeDBRemote = (ISendBeforOrdeWorkDB)MediationSendBeforOrderWorkDB.GetSendBeforOrderWorkDB();
        }

		#endregion  // <Constructor/>

        #region <���[�ݒ�f�[�^�擾/>

        /// <summary>
        /// �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B
        /// </summary>
        /// <remarks>
        /// PMUOE02034P���Ă΂�܂��B
        /// </remarks>
        /// <param name="prtOutSet">���[�o�͐ݒ�f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃR�[�h</returns>
        public static int ReadPrtOutSet(
            out PrtOutSet prtOutSet,
            out string errMsg
        )
        {
            prtOutSet = new PrtOutSet();
            errMsg = string.Empty;
            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (_printtOutSet != null)
                {
                    prtOutSet = _printtOutSet.Clone();
                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    int status = PrintOutSetAcs.Read(
                        out _printtOutSet,
                        LoginInfoAcquisition.EnterpriseCode,
                        LoginEmployee.BelongSectionCode
                    );
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = _printtOutSet.Clone();
                            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";    // LITERAL:
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                prtOutSet = new PrtOutSet();
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }

        #endregion  // <���[�ݒ�f�[�^�擾/>

        #region <���M�O���X�g����/>

        /// <summary>
        /// ���M�O���X�g���������܂��B
        /// </summary>
        /// <param name="extractingCondition">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃR�[�h</returns>
        public int SearchSendBeforeList(
            SendBeforeOrderCondition extractingCondition,
            out string errMsg
        )
        {
            return SearchSendBeforeListProc(extractingCondition, out errMsg);
        }

        /// <summary>
        /// ���M�O���X�g���������܂��B
        /// </summary>
        /// <param name="extractingCondition">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃR�[�h</returns>
        private int SearchSendBeforeListProc(
            SendBeforeOrderCondition extractingCondition,
            out string errMsg
        )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                ArrayList sendBeforeResultWorkList = new ArrayList();
                object objSendBeforeResultWorkList = (object)sendBeforeResultWorkList;
                object objSendBeforeOrderCondition = (object)extractingCondition.CreateSendBeforOrderCndtnWork();
                
                status = SendBeforeDBRemote.Search(
                    out objSendBeforeResultWorkList,
                    objSendBeforeOrderCondition,
                    0,  // HACK:readMode
                    ConstantManagement.LogicalMode.GetData0
                );
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �������ʂ�W�J
                        sendBeforeResultWorkList = (ArrayList)objSendBeforeResultWorkList;  // MEMO:�����[�g����new�����
                        InitializeSearchedResult(extractingCondition, sendBeforeResultWorkList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���M�O���X�g�f�[�^�̎擾�Ɏ��s���܂����B";    // LITERAL:
                        break;
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// �������ʂ����������܂��B
        /// </summary>
        /// <param name="extractingCondition">���o����</param>
        /// <param name="searchedRecordList">�������ꂽ���R�[�h�̃��X�g</param>
        /// <returns>Status</returns>
        private void InitializeSearchedResult(
            SendBeforeOrderCondition extractingCondition,
            ArrayList searchedRecordList
        )
        {
            Debug.WriteLine("�������F" + searchedRecordList.Count.ToString());

            SendBeforeDataSet searchedDataSet = new SendBeforeDataSet();
            foreach (object searchedRecord in searchedRecordList)
            {
                SendBeforResultWork searchedResult = (SendBeforResultWork)searchedRecord;
                PrintsSearchedResult(searchedResult);

                searchedDataSet.SendBefore.AddSendBeforeRow(
                    searchedResult.SectionCode,
                    searchedResult.SectionGuideSnm,
                    searchedResult.UOESupplierCd,
                    searchedResult.UOESupplierName,
                    searchedResult.OnlineNo,
                    searchedResult.CustomerCode,
                    searchedResult.EmployeeCode,
                    searchedResult.GoodsNo,
                    searchedResult.GoodsName,
                    searchedResult.GoodsMakerCd,
                    searchedResult.AcceptAnOrderCnt,
                    searchedResult.BoCode,
                    searchedResult.UoeRemark1,
                    searchedResult.UoeRemark2,
                    searchedResult.UOEDeliGoodsDiv,
                    searchedResult.FollowDeliGoodsDiv,
                    searchedResult.UOEResvdSection,
                    (int)extractingCondition.PrintOrder
                );
            }

            // �e�[�u�����\�[�g
            StringBuilder orderBy = new StringBuilder(SendBeforeDataSet.ClmIdx.SectionCode.ToString());
            switch (extractingCondition.PrintOrder)
            {
                case SendBeforeOrderCondition.PrintOrderType.ByOnlineNo:        // �����ԍ���
                {
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.OnlineNo.ToString());       // �����ԍ�
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.CustomerCode.ToString());   // ���Ӑ�
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.EmployeeCode.ToString());   // �˗���
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.UOESupplierCd.ToString());  // ������
                    break;
                }
                case SendBeforeOrderCondition.PrintOrderType.ByUOESupplierCode: // �������
                {
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.UOESupplierCd.ToString());  // ������
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.OnlineNo.ToString());       // �����ԍ�
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.CustomerCode.ToString());   // ���Ӑ�
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.EmployeeCode.ToString());   // �˗���
                    break;
                }
            }
            SendBeforeDataSet.SendBeforeRow[] sortedDataRows = ADOUtil.ConvertAll<SendBeforeDataSet.SendBeforeRow>(
                searchedDataSet.SendBefore.Select(string.Empty, orderBy.ToString())
            );
            Debug.WriteLine("�\�[�g���F" + orderBy.ToString());

            // TODO:�������ʂ��X�V �������ƌ����̂����������@������̂ł́H
            SearchedResult.Clear();
            foreach (SendBeforeDataSet.SendBeforeRow searchedDataRow in sortedDataRows)
            {
                SearchedResult.SendBefore.AddSendBeforeRow(
                    searchedDataRow.SectionCode,
                    searchedDataRow.SectionGuideSnm,
                    searchedDataRow.UOESupplierCd,
                    searchedDataRow.UOESupplierName,
                    searchedDataRow.OnlineNo,
                    searchedDataRow.CustomerCode,
                    searchedDataRow.EmployeeCode,
                    searchedDataRow.GoodsNo,
                    searchedDataRow.GoodsName,
                    searchedDataRow.GoodsMakerCd,
                    searchedDataRow.AcceptAnOrderCnt,
                    searchedDataRow.BoCode,
                    searchedDataRow.UoeRemark1,
                    searchedDataRow.UoeRemark2,
                    searchedDataRow.UOEDeliGoodsDiv,
                    searchedDataRow.FollowDeliGoodsDiv,
                    searchedDataRow.UOEResvdSection,
                    searchedDataRow.PrintOrder
                );
                PrintSearchedDataRow(searchedDataRow);
            }
        }

        #endregion  // <���M�O���X�g����/>

        #region <Debug/>

        /// <summary>
        /// �������ʂ�\�����܂��B
        /// </summary>
        /// <param name="searchedResult">��������</param>
        [Conditional("DEBUG")]
        private static void PrintsSearchedResult(SendBeforResultWork searchedResult)
        {
            Debug.Write("���_�R�[�h�F" + searchedResult.SectionCode + ",");
            //searchedResult.SectionGuideSnm,
            //Debug.Write("������F" + searchedResult.UOESupplierCd + ",");
            //searchedResult.UOESupplierName,
            Debug.Write("�����ԍ��F" + searchedResult.OnlineNo + ",");
            Debug.Write("���Ӑ�R�[�h�F" + searchedResult.CustomerCode + ",");
            Debug.Write("�˗��ҁF" + searchedResult.EmployeeCode + ",");
            //searchedResult.GoodsNo,
            //searchedResult.GoodsName,
            //searchedResult.GoodsMakerCd,
            //searchedResult.AcceptAnOrderCnt,
            //searchedResult.BoCode,
            //searchedResult.UoeRemark1,
            //searchedResult.UoeRemark2,
            //searchedResult.UOEDeliGoodsDiv,
            //searchedResult.FollowDeliGoodsDiv,
            //searchedResult.UOEResvdSection,
            //(int)extractingCondition.PrintOrder
            Debug.WriteLine("������F" + searchedResult.UOESupplierCd + ",");
        }

        /// <summary>
        /// �������ʂ�\�����܂��B
        /// </summary>
        /// <param name="searchedDataRow">��������</param>
        [Conditional("DEBUG")]
        private static void PrintSearchedDataRow(SendBeforeDataSet.SendBeforeRow searchedDataRow)
        {
            Debug.Write("���_�R�[�h�F" + searchedDataRow.SectionCode + ",");
            //searchedDataRow.SectionGuideSnm,
            //Debug.Write("������F" + searchedDataRow.UOESupplierCd + ",");
            //searchedDataRow.UOESupplierName,
            Debug.Write("�����ԍ��F" + searchedDataRow.OnlineNo + ",");
            Debug.Write("���Ӑ�R�[�h�F" + searchedDataRow.CustomerCode + ",");
            Debug.Write("�˗��ҁF" + searchedDataRow.EmployeeCode + ",");
            //searchedDataRow.GoodsNo,
            //searchedDataRow.GoodsName,
            //searchedDataRow.GoodsMakerCd,
            //searchedDataRow.AcceptAnOrderCnt,
            //searchedDataRow.BoCode,
            //searchedDataRow.UoeRemark1,
            //searchedDataRow.UoeRemark2,
            //searchedDataRow.UOEDeliGoodsDiv,
            //searchedDataRow.FollowDeliGoodsDiv,
            //searchedDataRow.UOEResvdSection,
            //(int)extractingCondition.PrintOrder
            Debug.WriteLine("������F" + searchedDataRow.UOESupplierCd + ",");
        }

        #endregion  // <Debug/>
    }
}
