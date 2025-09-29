//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2010/02/01  �C�����e : MANTIS�Ή�[14952]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/06/12  �C�����e : 10801804-00 ��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/03  �C�����e �F10801804-00 ��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/09  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.46�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/11  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.62�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/13  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.7�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/20  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.108�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>Update Note: 2012/06/12 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
    /// <br>Update Note: 2012/07/03 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
    /// <br>Update Note: 2012/07/09 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.46�̑Ή�</br>
    /// <br>Update Note: 2012/07/11 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.62�̑Ή�</br>
    /// <br>Update Note: 2012/07/13 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�̑Ή�</br>
    /// <br>Update Note: 2012/07/20 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
    /// </remarks>
    public class CustomerImportAcs
    {
        #region �� Constructor
		/// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ���w�q</br>
	    /// <br>Date       : 2009.05.13</br>
        /// </remarks>
		public CustomerImportAcs()
		{
            this._iCustomerImportDB = (ICustomerImportDB)MediationCustomerImportDB.GetCustomerImportDB();
        }

		/// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static CustomerImportAcs()
		{
		}
		#endregion �� Constructor

        #region �� Private Member
        // ���Ӑ�}�X�^�i�C���|�[�g�j�̃����[�g�C���^�t�F�[�X
        private ICustomerImportDB _iCustomerImportDB;
        private const string ERROR_LOG_FILENAME = "PMKHN07100U_ERRORLOG.xml";// ADD  2012/06/12  ������ Redmine#30393
        #endregion �� Private Member

        #region �� Public Method
        #region �� �C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="logCnt">�G���[���O����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// </remarks>
        //public int Import(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)// DEL  2012/06/12  ������ Redmine#30393
        public int Import(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out string errMsg)// ADD  2012/06/12  ������ Redmine#30393 
        {
           //return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);// DEL  2012/06/12  ������ Redmine#30393
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out logCnt, out errMsg);// ADD  2012/06/12  ������ Redmine#30393	
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="logCnt">�G���[���O����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2012/07/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        /// </remarks>
        //private int ImportProc(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)// DEL  2012/06/12  ������ Redmine#30393
        private int ImportProc(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out string errMsg)// ADD  2012/06/12  ������ Redmine#30393 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;
            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
            DataTable logTable = new DataTable();
            //ArrayList logList = new ArrayList();// ADD  2012/07/03  ������ Redmine#30393// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            object logList = null;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            logCnt = 0;
            // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
            try
            {
                //ArrayList importWorkList = null;// DEL  2012/06/12  ������ Redmine#30393
                // �C���|�[�g���[�N�̕ϊ�����
                //status = ConvertToImportWorkList(importWorkTbl, out importWorkList, out errMsg);// DEL  2012/06/12  ������ Redmine#30393
                // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
                ArrayList importWorkList = null;
                 //�C���|�[�g���[�N�̕ϊ�����
                status = ConvertToImportWorkArrayList(importWorkTbl, out importWorkList, out errMsg);
                // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<

                // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
                // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                //DataTable dataTable = new DataTable();
                // CreateDataTable(ref dataTable);
                //status = ConvertToDataTable(ref dataTable, importWorkTbl, out errMsg);
                // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    //Object objImportWorkList = (object)importWorkList;// DEL  2012/06/12  ������ Redmine#30393
                    //Object objImportWorkTable = (object)dataTable;// // ADD  2012/06/12  ������ Redmine#30393 // DEL  2012/07/03  ������ Redmine#30393
                    Object objImportWorkList = (object)importWorkList;// ADD  2012/07/03  ������ Redmine#30393
                    // �����[�g�N���X���Ăяo���B
                    // status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);// DEL  2012/06/12  ������ Redmine#30393
                    //status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logTable, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/06/12  ������ Redmine#30393 // DEL  2012/07/03  ������ Redmine#30393

                    // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.62�̑Ή�-------->>>>
                     CustomerInputAcs cust = new CustomerInputAcs();
                     Int32 consTaxLay = cust.GetConsTaxLayMethod(importWorkTbl.EnterpriseCode, 0); // �ŗ��}�X�^�������œ]�ŕ������擾
                    // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.62�̑Ή�--------<<<<

                     //status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out logCnt, out logList, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
                     //status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, consTaxLay, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out logCnt, out logList, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                     status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn,importWorkTbl.CheckKbn, consTaxLay, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out logCnt, out logList, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                    // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
                    CreateDataTable(ref logTable);
                    //foreach (CustomerGroupWork customerGroupWork in logList)// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                    // ------ ADD START 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.7�̑Ή�-------->>>>
                    ArrayList logArrayList = new ArrayList();
                    logArrayList = logList as ArrayList;
                    foreach (CustomerGroupWork customerGroupWork in logArrayList)
                    // ------ ADD END 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.7�̑Ή�--------<<<<
                    {
                        //ConverToDataSetCustomerLog(customerGroupWork, ref logTable);// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                        // ------ ADD START 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.7�̑Ή�-------->>>>
                        if (!string.IsNullOrEmpty(customerGroupWork.ErrorLog.Trim()))
                        {
                        ConverToDataSetCustomerLog(customerGroupWork, ref logTable);
                        }
                        // ------ ADD END 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.7�̑Ή�--------<<<<
                    }
                    // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
                    // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                    if (logTable.Rows.Count > 0)
                    {
                        this.DoOutPut(importWorkTbl.ErrorLogFileName, logTable);
                    }
                    // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        /// <summary>
        /// �C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="dataTable">�C���|�[�g�e�[�u��</param>
        /// <param name="errMsg">�G���[���</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int ConvertToDataTable(ref DataTable dataTable, ExtrInfo_CustomerImportWorkTbl importWorkTbl, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            DataRow row = null;
            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    row = dataTable.NewRow();
                    row.ItemArray = csvDataArr;
                    dataTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
      
        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="errorLogFileName">�G���[���O�t�@�C����</param>
        /// <param name="logTable">�f�[�^�e�[�u��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName, DataTable logTable)
        {
            int status = 0;

            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.prpid = ERROR_LOG_FILENAME;
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            // �o�̓p�X�Ɩ��O
            customTextProviderInfo.OutPutFileName = errorLogFileName;

            // �㏑���^�ǉ��t���O���Z�b�g(true:�ǉ�����Afalse:�㏑������)
            customTextProviderInfo.AppendMode = false;
            // �X�L�[�}�擾
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            // �f�[�^�\�[�X��ݒ�
            DataSet dsOutData = new DataSet();
            DataView dv = logTable.DefaultView;
            dsOutData.Tables.Add(dv.ToTable());

            try
            {
                status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = -1;
            }
            dsOutData.Tables.Clear();

            return status;
        }

    
        /// <summary>
        /// �G���[���O�e�[�u��
        /// </summary>
        /// <param name="dataTable">�e�[�u��</param>
        /// <remarks>
        /// <br>Note	   : �G���[���O�e�[�u�����s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/09 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.46�̑Ή�</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));           //  ���Ӑ�R�[�h
            dataTable.Columns.Add("CustomerSubCodeRF", typeof(string));	      //  ���Ӑ�T�u�R�[�h
            dataTable.Columns.Add("NameRF", typeof(string));	              //  ����
            dataTable.Columns.Add("Name2RF", typeof(string));	              //  ����2
            dataTable.Columns.Add("CustomerSnmRF", typeof(string));	          //  ���Ӑ旪��
            dataTable.Columns.Add("KanaRF", typeof(string));	              //  �J�i
            dataTable.Columns.Add("HonorificTitleRF", typeof(string));	      //  �h��
            dataTable.Columns.Add("OutputNameCodeRF", typeof(string));	      //  �����R�[�h
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));	      //  �Ǘ����_�R�[�h
            dataTable.Columns.Add("CustomerAgentCdRF", typeof(string));	      //  �ڋq�S���]�ƈ��R�[�h
            dataTable.Columns.Add("OldCustomerAgentCdRF", typeof(string));	  //  ���ڋq�S���]�ƈ��R�[�h
            dataTable.Columns.Add("CustAgentChgDateRF", typeof(string));       //  �ڋq�S���ύX��
            dataTable.Columns.Add("TransStopDateRF", typeof(string));	      //  ������~��	
            dataTable.Columns.Add("CarMngDivCdRF", typeof(string));	          //  ���q�Ǘ��敪
            dataTable.Columns.Add("CorporateDivCodeRF", typeof(string));       //  �l�E�@�l�敪
            dataTable.Columns.Add("AcceptWholeSaleRF", typeof(string));	      //  �Ɣ̐�敪
            dataTable.Columns.Add("CustomerAttributeDivRF", typeof(string));	  //  ���Ӑ摮���敪
            dataTable.Columns.Add("CustWarehouseCdRF", typeof(string));	      //  ���Ӑ�D��q�ɃR�[�h
            dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));       //  �Ǝ�R�[�h
            dataTable.Columns.Add("JobTypeCodeRF", typeof(string));	          //  �E��R�[�h
            dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	      //  �̔��G���A�R�[�h
            dataTable.Columns.Add("CustAnalysCode1RF", typeof(string));        //  ���Ӑ敪�̓R�[�h1
            dataTable.Columns.Add("CustAnalysCode2RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h2
            dataTable.Columns.Add("CustAnalysCode3RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h3
            dataTable.Columns.Add("CustAnalysCode4RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h4
            dataTable.Columns.Add("CustAnalysCode5RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h5
            dataTable.Columns.Add("CustAnalysCode6RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h6
            dataTable.Columns.Add("ClaimSectionCodeRF", typeof(string));	  //  �������_�R�[�h
            dataTable.Columns.Add("ClaimCodeRF", typeof(string));              //  ������R�[�h
            dataTable.Columns.Add("TotalDayRF", typeof(string));	              //  ����
            dataTable.Columns.Add("CollectMoneyCodeRF", typeof(string));	      //  �W�����敪�R�[�h
            dataTable.Columns.Add("CollectMoneyDayRF", typeof(string));	      //  �W����
            dataTable.Columns.Add("CollectCondRF", typeof(string));	          //  �������
            dataTable.Columns.Add("CollectSightRF", typeof(string));	          //  ����T�C�g
            dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));        //  ���񊨒�J�n��
            dataTable.Columns.Add("BillCollecterCdRF", typeof(string));	      //  �W���S���]�ƈ��R�[�h
            dataTable.Columns.Add("CustCTaXLayRefCdRF", typeof(string));	      //  ���Ӑ����œ]�ŕ����Q�Ƌ敪
            dataTable.Columns.Add("ConsTaxLayMethodRF", typeof(string));	      //  ����œ]�ŕ���
            dataTable.Columns.Add("SalesUnPrcFrcProcCdRF", typeof(string));	  //  ����P���[�������R�[�h
            dataTable.Columns.Add("SalesMoneyFrcProcCdRF", typeof(string));	  //  ������z�[�������R�[�h
            dataTable.Columns.Add("SalesCnsTaxFrcProcCdRF", typeof(string));   //  �������Œ[�������R�[�h
            dataTable.Columns.Add("CreditMngCodeRF", typeof(string));	      //  �^�M�Ǘ��敪 
            dataTable.Columns.Add("DepoDelCodeRF", typeof(string));	          //  ���������敪
            dataTable.Columns.Add("AccRecDivCdRF", typeof(string));	          //  ���|�敪
            dataTable.Columns.Add("PostNoRF", typeof(string));	              //  �X�֔ԍ�
            dataTable.Columns.Add("Address1RF", typeof(string));	          //  �Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("Address3RF", typeof(string));	          //  �Z��3�i�Ԓn�j
            dataTable.Columns.Add("Address4RF", typeof(string));	          //  �Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("CustomerAgentRF", typeof(string));         //  ���Ӑ�S����
            dataTable.Columns.Add("HomeTelNoRF", typeof(string));             //  �d�b�ԍ��i����j
            dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	          //  �d�b�ԍ��i�Ζ���j
            dataTable.Columns.Add("PortableTelNoRF", typeof(string));	      //  �d�b�ԍ��i�g�сj
            dataTable.Columns.Add("OthersTelNoRF", typeof(string));	          //  �d�b�ԍ��i���̑��j
            dataTable.Columns.Add("HomeFaxNoRF", typeof(string));	          //  FAX�ԍ��i����j
            dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	          //  FAX�ԍ��i�Ζ���j
            dataTable.Columns.Add("SearchTelNoRF", typeof(string));	          //  �d�b�ԍ��i�����p��4���j
            dataTable.Columns.Add("MainContactCodeRF", typeof(string));	      //  ��A����敪
            dataTable.Columns.Add("Note1RF", typeof(string));	              //  ���l�P
            dataTable.Columns.Add("Note2RF", typeof(string));	              //  ���l�Q
            dataTable.Columns.Add("Note3RF", typeof(string));	              //  ���l�R
            dataTable.Columns.Add("Note4RF", typeof(string));	              //  ���l�S
            dataTable.Columns.Add("Note5RF", typeof(string));	              //  ���l�T 
            dataTable.Columns.Add("Note6RF", typeof(string));	              //  ���l�U
            dataTable.Columns.Add("Note7RF", typeof(string));	              //  ���l�V
            dataTable.Columns.Add("Note8RF", typeof(string));	              //  ���l�W
            dataTable.Columns.Add("Note9RF", typeof(string));	              //  ���l�X
            dataTable.Columns.Add("Note10RF", typeof(string));	              // ���l�P�O
            dataTable.Columns.Add("MainSendMailAddrCdRF", typeof(string));	  //  �呗�M�惁�[���A�h���X�敪
            dataTable.Columns.Add("MailAddress1RF", typeof(string));	      //  ���[���A�h���X1	
            dataTable.Columns.Add("MailSendCode1RF", typeof(string));	      //  ���[�����M�敪�R�[�h1
            dataTable.Columns.Add("MailAddrKindCode1RF", typeof(string));	  //  ���[���A�h���X��ʃR�[�h1
            dataTable.Columns.Add("MailAddress2RF", typeof(string));	      // ���[���A�h���X�Q 
            dataTable.Columns.Add("MailSendCode2RF", typeof(string));	      //  ���[�����M�敪�R�[�h�Q
            dataTable.Columns.Add("MailAddrKindCode2RF", typeof(string));	  //  ���[���A�h���X��ʃR�[�h�Q
            dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	      //  ��s�����P
            dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	      //  ��s�����Q
            dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	      //  ��s�����R
            dataTable.Columns.Add("ReceiptOutputCodeRF", typeof(string));	  // �̎����o�͋敪�R�[�h
            dataTable.Columns.Add("DmOutCodeRF", typeof(string));	          //  DM�o�͋敪
            dataTable.Columns.Add("SalesSlipPrtDivRF", typeof(string));	      //  ����`�[���s�敪
            dataTable.Columns.Add("AcpOdrrSlipPrtDivRF", typeof(string));	  //  �󒍓`�[���s�敪
            dataTable.Columns.Add("ShipmSlipPrtDivRF", typeof(string));	      //  �o�ד`�[���s�敪
            dataTable.Columns.Add("EstimatePrtDivRF", typeof(string));	      //  ���Ϗ����s�敪	
            dataTable.Columns.Add("UOESlipPrtDivRF", typeof(string));	      // UOE�`�[���s�敪	
            dataTable.Columns.Add("QrcodePrtCdRF", typeof(string));	          //  QR�R�[�h���
            dataTable.Columns.Add("CustSlipNoMngCdRF", typeof(string));	      //  ����`�[�ԍ��Ǘ��敪
            dataTable.Columns.Add("CustomerSlipNoDivRF", typeof(string));	  //  ���Ӑ�`�[�ԍ��敪
            dataTable.Columns.Add("TotalBillOutputDivRF", typeof(string));      // ���v�������o�͋敪
            dataTable.Columns.Add("DetailBillOutputCodeRF", typeof(string));    // ���א������o�͋敪
            dataTable.Columns.Add("SlipTtlBillOutputDivRF", typeof(string));    // �`�[���v�������o�͋敪

            //dataTable.Columns.Add("CustRateGrpFine", typeof(string));          //���Ӑ�|���O���[�v(�D��)// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            dataTable.Columns.Add("CustRateGrpFineAll", typeof(string));          //���Ӑ�|���O���[�v(�D��ALL)// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            dataTable.Columns.Add("CustRateGrpPureAll", typeof(string));       //���Ӑ�|���O���[�v(����ALL)
            dataTable.Columns.Add("CustRateGrpPure1", typeof(string));         //���Ӑ�|���O���[�v�����P
            dataTable.Columns.Add("CustRateGrpPure2", typeof(string));         //���Ӑ�|���O���[�v����2
            dataTable.Columns.Add("CustRateGrpPure3", typeof(string));         //���Ӑ�|���O���[�v����3
            dataTable.Columns.Add("CustRateGrpPure4", typeof(string));         //���Ӑ�|���O���[�v����4
            dataTable.Columns.Add("CustRateGrpPure5", typeof(string));         //���Ӑ�|���O���[�v����5
            dataTable.Columns.Add("CustRateGrpPure6", typeof(string));         //���Ӑ�|���O���[�v����6
            dataTable.Columns.Add("CustRateGrpPure7", typeof(string));         //���Ӑ�|���O���[�v����7
            dataTable.Columns.Add("CustRateGrpPure8", typeof(string));         //���Ӑ�|���O���[�v����8
            dataTable.Columns.Add("CustRateGrpPure9", typeof(string));         //���Ӑ�|���O���[�v����9
            dataTable.Columns.Add("CustRateGrpPure10", typeof(string));        //���Ӑ�|���O���[�v�����P0
            dataTable.Columns.Add("CustRateGrpPure11", typeof(string));        //���Ӑ�|���O���[�v�����P1
            dataTable.Columns.Add("CustRateGrpPure12", typeof(string));        //���Ӑ�|���O���[�v�����P2
            dataTable.Columns.Add("CustRateGrpPure13", typeof(string));        //���Ӑ�|���O���[�v�����P3
            dataTable.Columns.Add("CustRateGrpPure14", typeof(string));        //���Ӑ�|���O���[�v�����P4
            dataTable.Columns.Add("CustRateGrpPure15", typeof(string));        //���Ӑ�|���O���[�v�����P5
            dataTable.Columns.Add("CustRateGrpPure16", typeof(string));        //���Ӑ�|���O���[�v�����P6
            dataTable.Columns.Add("CustRateGrpPure17", typeof(string));        //���Ӑ�|���O���[�v�����P7
            dataTable.Columns.Add("CustRateGrpPure18", typeof(string));        //���Ӑ�|���O���[�v�����P8
            dataTable.Columns.Add("CustRateGrpPure19", typeof(string));        //���Ӑ�|���O���[�v�����P9
            dataTable.Columns.Add("CustRateGrpPure20", typeof(string));        //���Ӑ�|���O���[�v����20
            dataTable.Columns.Add("CustRateGrpPure21", typeof(string));        //���Ӑ�|���O���[�v����21
            dataTable.Columns.Add("CustRateGrpPure22", typeof(string));        //���Ӑ�|���O���[�v����22
            dataTable.Columns.Add("CustRateGrpPure23", typeof(string));        //���Ӑ�|���O���[�v����23
            dataTable.Columns.Add("CustRateGrpPure24", typeof(string));        //���Ӑ�|���O���[�v����24
            dataTable.Columns.Add("CustRateGrpPure25", typeof(string));        //���Ӑ�|���O���[�v����25
            dataTable.Columns.Add("ErrorLog", typeof(string)); // ADD  2012/07/03  ������ Redmine#30393
        }
        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<

        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
        /// <summary>
        /// �C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/03</br>
        /// <br>Update Note: 2012/07/09 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.46�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�̑Ή�</br>
        /// </remarks>
        private int ConvertToImportWorkArrayList(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            CustomerGroupWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new CustomerGroupWork();
                    int index = 0;
                    work.CustomerCode = ConvertToEmpty(csvDataArr, index++);            // ���Ӑ�R�[�h
                    work.CustomerSubCode = ConvertToEmpty(csvDataArr, index++);         // �T�u�R�[�h
                    work.Name = ConvertToEmpty(csvDataArr, index++);                    // ���Ӑ於�P
                    work.Name2 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ於�Q
                    work.CustomerSnm = ConvertToEmpty(csvDataArr, index++);             // ���Ӑ旪��
                    work.Kana = ConvertToEmpty(csvDataArr, index++);                    // ���Ӑ於�J�i
                    work.HonorificTitle = ConvertToEmpty(csvDataArr, index++);          // �h��
                    work.OutputNameCode = ConvertToEmpty(csvDataArr, index++);          // ����
                    work.MngSectionCode = ConvertToEmpty(csvDataArr, index++);          // �Ǘ����_
                    work.CustomerAgentCd = ConvertToEmpty(csvDataArr, index++);         // ���Ӑ�S��
                    work.OldCustomerAgentCd = ConvertToEmpty(csvDataArr, index++);      // ���S��
                    work.CustAgentChgDate = ConvertToEmpty(csvDataArr, index++);        // �S���ҕύX��
                    work.TransStopDate = ConvertToEmpty(csvDataArr, index++);           // ������~��
                    work.CarMngDivCd = ConvertToEmpty(csvDataArr, index++);             // ���p�Ǘ�
                    work.CorporateDivCode = ConvertToEmpty(csvDataArr, index++);        // �l�E�@�l
                    work.AcceptWholeSale = ConvertToEmpty(csvDataArr, index++);         // ���Ӑ���
                    work.CustomerAttributeDiv = ConvertToEmpty(csvDataArr, index++);    // ���Ӑ摮��
                    work.CustWarehouseCd = ConvertToEmpty(csvDataArr, index++);         // �D��q��
                    work.BusinessTypeCode = ConvertToEmpty(csvDataArr, index++);        // �Ǝ�
                    work.JobTypeCode = ConvertToEmpty(csvDataArr, index++);             // �E��
                    work.SalesAreaCode = ConvertToEmpty(csvDataArr, index++);           // �n��
                    work.CustAnalysCode1 = ConvertToEmpty(csvDataArr, index++);         // ���̓R�[�h�P
                    work.CustAnalysCode2 = ConvertToEmpty(csvDataArr, index++);         // ���̓R�[�h�Q
                    work.CustAnalysCode3 = ConvertToEmpty(csvDataArr, index++);         // ���̓R�[�h�R
                    work.CustAnalysCode4 = ConvertToEmpty(csvDataArr, index++);         // ���̓R�[�h�S
                    work.CustAnalysCode5 = ConvertToEmpty(csvDataArr, index++);         // ���̓R�[�h�T
                    work.CustAnalysCode6 = ConvertToEmpty(csvDataArr, index++);         // ���̓R�[�h�U
                    work.ClaimSectionCode = ConvertToEmpty(csvDataArr, index++);        // �������_
                    work.ClaimCode = ConvertToEmpty(csvDataArr, index++);               // �����R�[�h
                    work.TotalDay = ConvertToEmpty(csvDataArr, index++);                // ����
                    work.CollectMoneyCode = ConvertToEmpty(csvDataArr, index++);        // �W����
                    work.CollectMoneyDay = ConvertToEmpty(csvDataArr, index++);         // �W����
                    work.CollectCond = ConvertToEmpty(csvDataArr, index++);             // �������
                    work.CollectSight = ConvertToEmpty(csvDataArr, index++);            // ����T�C�g
                    work.NTimeCalcStDate = ConvertToEmpty(csvDataArr, index++);         // ���񊨒�
                    work.BillCollecterCd = ConvertToEmpty(csvDataArr, index++);         // �W���S��
                    work.CustCTaXLayRefCd = ConvertToEmpty(csvDataArr, index++);        // �]�ŕ����Q�Ƌ敪
                    work.ConsTaxLayMethod = ConvertToEmpty(csvDataArr, index++);        // ����œ]�ŕ���
                    work.SalesUnPrcFrcProcCd = ConvertToEmpty(csvDataArr, index++);     // �P���[������
                    work.SalesMoneyFrcProcCd = ConvertToEmpty(csvDataArr, index++);     // ���z�[������
                    work.SalesCnsTaxFrcProcCd = ConvertToEmpty(csvDataArr, index++);    // ����Œ[������
                    work.CreditMngCode = ConvertToEmpty(csvDataArr, index++);           // �^�M�Ǘ�
                    work.DepoDelCode = ConvertToEmpty(csvDataArr, index++);             // ��������
                    work.AccRecDivCd = ConvertToEmpty(csvDataArr, index++);             // ���|�敪
                    work.PostNo = ConvertToEmpty(csvDataArr, index++);                  // �X�֔ԍ�
                    work.Address1 = ConvertToEmpty(csvDataArr, index++);                // �Z��
                    work.Address3 = ConvertToEmpty(csvDataArr, index++);                // �Z���Q
                    work.Address4 = ConvertToEmpty(csvDataArr, index++);                // �Z���R
                    work.CustomerAgent = ConvertToEmpty(csvDataArr, index++);           // ���Ӑ�S����
                    work.HomeTelNo = ConvertToEmpty(csvDataArr, index++);               // ����s�d�k
                    work.OfficeTelNo = ConvertToEmpty(csvDataArr, index++);             // �Ζ���d�b�P
                    work.PortableTelNo = ConvertToEmpty(csvDataArr, index++);           // �Ζ���d�b�Q
                    work.OthersTelNo = ConvertToEmpty(csvDataArr, index++);             // ���̑��d�b
                    work.HomeFaxNo = ConvertToEmpty(csvDataArr, index++);               // ����e�`�w
                    work.OfficeFaxNo = ConvertToEmpty(csvDataArr, index++);             // �Ζ���e�`�w
                    work.SearchTelNo = ConvertToEmpty(csvDataArr, index++);             // �����ԍ�
                    work.MainContactCode = ConvertToEmpty(csvDataArr, index++);         // ��A����
                    work.Note1 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�P
                    work.Note2 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�Q
                    work.Note3 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�R
                    work.Note4 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�S
                    work.Note5 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�T
                    work.Note6 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�U
                    work.Note7 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�V
                    work.Note8 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�W
                    work.Note9 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�X
                    work.Note10 = ConvertToEmpty(csvDataArr, index++);                  // ���Ӑ���l�P�O
                    work.MainSendMailAddrCd = ConvertToEmpty(csvDataArr, index++);      // �呗�M�惁�[���A�h���X�敪
                    work.MailAddress1 = ConvertToEmpty(csvDataArr, index++);            // ���[���A�h���X�P
                    work.MailSendCode1 = ConvertToEmpty(csvDataArr, index++);           // ���[�����M�敪�R�[�h�P
                    work.MailAddrKindCode1 = ConvertToEmpty(csvDataArr, index++);       // ���[���A�h���X��ʃR�[�h�P
                    work.MailAddress2 = ConvertToEmpty(csvDataArr, index++);            // ���[���A�h���X�Q
                    work.MailSendCode2 = ConvertToEmpty(csvDataArr, index++);           // ���[�����M�敪�R�[�h�Q
                    work.MailAddrKindCode2 = ConvertToEmpty(csvDataArr, index++);       // ���[���A�h���X��ʃR�[�h�Q
                    work.AccountNoInfo1 = ConvertToEmpty(csvDataArr, index++);          // ��s�����P
                    work.AccountNoInfo2 = ConvertToEmpty(csvDataArr, index++);          // ��s�����Q
                    work.AccountNoInfo3 = ConvertToEmpty(csvDataArr, index++);          // ��s�����R
                    work.ReceiptOutputCode = ConvertToEmpty(csvDataArr, index++);       // �̎����o��
                    work.DmOutCode = ConvertToEmpty(csvDataArr, index++);               // �c�l�o��
                    work.SalesSlipPrtDiv = ConvertToEmpty(csvDataArr, index++);         // �[�i���o��
                    work.AcpOdrrSlipPrtDiv = ConvertToEmpty(csvDataArr, index++);       // �󒍓`�[�o��
                    work.ShipmSlipPrtDiv = ConvertToEmpty(csvDataArr, index++);         // �ݏo�`�[�o��
                    work.EstimatePrtDiv = ConvertToEmpty(csvDataArr, index++);          // ���ϓ`�[�o��
                    work.UOESlipPrtDiv = ConvertToEmpty(csvDataArr, index++);           // �t�n�d�`�[�o��
                    work.QrcodePrtCd = ConvertToEmpty(csvDataArr, index++);             // �p�q�R�[�h���
                    work.CustSlipNoMngCd = ConvertToEmpty(csvDataArr, index++);         // ����`�[�ԍ��Ǘ�
                    work.CustomerSlipNoDiv = ConvertToEmpty(csvDataArr, index++);       // ����`�[�ԍ��敪
                    work.TotalBillOutputDiv = ConvertToEmpty(csvDataArr, index++);      // ���v�������o��
                    work.DetailBillOutputCode = ConvertToEmpty(csvDataArr, index++);    // ���א������o��
                    work.SlipTtlBillOutputDiv = ConvertToEmpty(csvDataArr, index++);    // �`�[���v�������o��
                    //work.CustRateGrpFine = ConvertToEmpty(csvDataArr, index++);         //���Ӑ�|���O���[�v(�D��) // DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                    work.CustRateGrpFineAll = ConvertToEmpty(csvDataArr, index++);         //���Ӑ�|���O���[�v(�D��ALL)// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή� 
                    work.CustRateGrpPureAll = ConvertToEmpty(csvDataArr, index++);      //���Ӑ�|���O���[�v(����ALL)
                    work.CustRateGrpPure1 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����1        
                    work.CustRateGrpPure2 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����2  
                    work.CustRateGrpPure3 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����3      
                    work.CustRateGrpPure4 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����4
                    work.CustRateGrpPure5 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����5
                    work.CustRateGrpPure6 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����6
                    work.CustRateGrpPure7 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����7
                    work.CustRateGrpPure8 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����8
                    work.CustRateGrpPure9 = ConvertToEmpty(csvDataArr, index++);        //���Ӑ�|���O���[�v����9
                    work.CustRateGrpPure10 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����10
                    work.CustRateGrpPure11 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����11
                    work.CustRateGrpPure12 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����12
                    work.CustRateGrpPure13 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����13
                    work.CustRateGrpPure14 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����14
                    work.CustRateGrpPure15 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����15
                    work.CustRateGrpPure16 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����16
                    work.CustRateGrpPure17 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����17
                    work.CustRateGrpPure18 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����18
                    work.CustRateGrpPure19 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����19
                    work.CustRateGrpPure20 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����20
                    work.CustRateGrpPure21 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����21
                    work.CustRateGrpPure22 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����22
                    work.CustRateGrpPure23 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����23
                    work.CustRateGrpPure24 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����24
                    work.CustRateGrpPure25 = ConvertToEmpty(csvDataArr, index++);       //���Ӑ�|���O���[�v����25
                    work.ErrorLog = string.Empty;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���O�e�[�u��
        /// </summary>
        /// <param name="customerGroupWork">���Ӑ�|�����[�N</param>
        /// <param name="logTable">���O�e�[�u��</param>
        private void ConverToDataSetCustomerLog(CustomerGroupWork customerGroupWork, ref DataTable logTable)
        {
            DataRow dataRow = logTable.NewRow();
            dataRow["CustomerCodeRF"] = customerGroupWork.CustomerCode;
            dataRow["CustomerSubCodeRF"] = customerGroupWork.CustomerSubCode;
            dataRow["NameRF"] = customerGroupWork.Name;
            dataRow["Name2RF"] = customerGroupWork.Name2;
            dataRow["CustomerSnmRF"] = customerGroupWork.CustomerSnm;
            dataRow["KanaRF"] = customerGroupWork.Kana;
            dataRow["HonorificTitleRF"] = customerGroupWork.HonorificTitle;
            dataRow["OutputNameCodeRF"] = customerGroupWork.OutputNameCode;
            dataRow["MngSectionCodeRF"] = customerGroupWork.MngSectionCode;
            dataRow["CustomerAgentCdRF"] = customerGroupWork.CustomerAgentCd;
            dataRow["OldCustomerAgentCdRF"] = customerGroupWork.OldCustomerAgentCd;
            dataRow["CustAgentChgDateRF"] = customerGroupWork.CustAgentChgDate;
            dataRow["TransStopDateRF"] = customerGroupWork.TransStopDate;
            dataRow["CarMngDivCdRF"] = customerGroupWork.CarMngDivCd;
            dataRow["CorporateDivCodeRF"] = customerGroupWork.CorporateDivCode;
            dataRow["AcceptWholeSaleRF"] = customerGroupWork.AcceptWholeSale;
            dataRow["CustomerAttributeDivRF"] = customerGroupWork.CustomerAttributeDiv;
            dataRow["CustWarehouseCdRF"] = customerGroupWork.CustWarehouseCd;
            dataRow["BusinessTypeCodeRF"] = customerGroupWork.BusinessTypeCode;
            dataRow["JobTypeCodeRF"] = customerGroupWork.JobTypeCode;
            dataRow["SalesAreaCodeRF"] = customerGroupWork.SalesAreaCode;
            dataRow["CustAnalysCode1RF"] = customerGroupWork.CustAnalysCode1;
            dataRow["CustAnalysCode2RF"] = customerGroupWork.CustAnalysCode2;
            dataRow["CustAnalysCode3RF"] = customerGroupWork.CustAnalysCode3;
            dataRow["CustAnalysCode4RF"] = customerGroupWork.CustAnalysCode4;
            dataRow["CustAnalysCode5RF"] = customerGroupWork.CustAnalysCode5;
            dataRow["CustAnalysCode6RF"] = customerGroupWork.CustAnalysCode6;
            dataRow["ClaimSectionCodeRF"] = customerGroupWork.ClaimSectionCode;
            dataRow["ClaimCodeRF"] = customerGroupWork.ClaimCode;
            dataRow["TotalDayRF"] = customerGroupWork.TotalDay;
            dataRow["CollectMoneyCodeRF"] = customerGroupWork.CollectMoneyCode;
            dataRow["CollectMoneyDayRF"] = customerGroupWork.CollectMoneyDay;
            dataRow["CollectCondRF"] = customerGroupWork.CollectCond;
            dataRow["CollectSightRF"] = customerGroupWork.CollectSight;
            dataRow["NTimeCalcStDateRF"] = customerGroupWork.NTimeCalcStDate;
            dataRow["BillCollecterCdRF"] = customerGroupWork.BillCollecterCd;
            dataRow["CustCTaXLayRefCdRF"] = customerGroupWork.CustCTaXLayRefCd;
            dataRow["ConsTaxLayMethodRF"] = customerGroupWork.ConsTaxLayMethod;
            dataRow["SalesUnPrcFrcProcCdRF"] = customerGroupWork.SalesUnPrcFrcProcCd;
            dataRow["SalesMoneyFrcProcCdRF"] = customerGroupWork.SalesMoneyFrcProcCd;
            dataRow["SalesCnsTaxFrcProcCdRF"] = customerGroupWork.SalesCnsTaxFrcProcCd;
            dataRow["CreditMngCodeRF"] = customerGroupWork.CreditMngCode;
            dataRow["DepoDelCodeRF"] = customerGroupWork.DepoDelCode;
            dataRow["AccRecDivCdRF"] = customerGroupWork.AccRecDivCd;
            dataRow["PostNoRF"] = customerGroupWork.PostNo;
            dataRow["Address1RF"] = customerGroupWork.Address1;
            dataRow["Address3RF"] = customerGroupWork.Address3;
            dataRow["Address4RF"] = customerGroupWork.Address4;
            dataRow["CustomerAgentRF"] = customerGroupWork.CustomerAgent;
            dataRow["HomeTelNoRF"] = customerGroupWork.HomeTelNo;
            dataRow["OfficeTelNoRF"] = customerGroupWork.OfficeTelNo;
            dataRow["PortableTelNoRF"] = customerGroupWork.PortableTelNo;
            dataRow["OthersTelNoRF"] = customerGroupWork.OthersTelNo;
            dataRow["HomeFaxNoRF"] = customerGroupWork.HomeFaxNo;
            dataRow["OfficeFaxNoRF"] = customerGroupWork.OfficeFaxNo;
            dataRow["SearchTelNoRF"] = customerGroupWork.SearchTelNo;
            dataRow["MainContactCodeRF"] = customerGroupWork.MainContactCode;
            dataRow["Note1RF"] = customerGroupWork.Note1;
            dataRow["Note2RF"] = customerGroupWork.Note2;
            dataRow["Note3RF"] = customerGroupWork.Note3;
            dataRow["Note4RF"] = customerGroupWork.Note4;
            dataRow["Note5RF"] = customerGroupWork.Note5;
            dataRow["Note6RF"] = customerGroupWork.Note6;
            dataRow["Note7RF"] = customerGroupWork.Note7;
            dataRow["Note8RF"] = customerGroupWork.Note8;
            dataRow["Note9RF"] = customerGroupWork.Note9;
            dataRow["Note10RF"] = customerGroupWork.Note10;
            dataRow["MainSendMailAddrCdRF"] = customerGroupWork.MainSendMailAddrCd;
            dataRow["MailAddress1RF"] = customerGroupWork.MailAddress1;
            dataRow["MailSendCode1RF"] = customerGroupWork.MailSendCode1;
            dataRow["MailAddrKindCode1RF"] = customerGroupWork.MailAddrKindCode1;
            dataRow["MailAddress2RF"] = customerGroupWork.MailAddress2;
            dataRow["MailSendCode2RF"] = customerGroupWork.MailSendCode2;
            dataRow["MailAddrKindCode2RF"] = customerGroupWork.MailAddrKindCode2;
            dataRow["AccountNoInfo1RF"] = customerGroupWork.AccountNoInfo1;
            dataRow["AccountNoInfo2RF"] = customerGroupWork.AccountNoInfo2;
            dataRow["AccountNoInfo3RF"] = customerGroupWork.AccountNoInfo3;
            dataRow["ReceiptOutputCodeRF"] = customerGroupWork.ReceiptOutputCode;
            dataRow["DmOutCodeRF"] = customerGroupWork.DmOutCode;
            dataRow["SalesSlipPrtDivRF"] = customerGroupWork.SalesSlipPrtDiv;
            dataRow["AcpOdrrSlipPrtDivRF"] = customerGroupWork.AcpOdrrSlipPrtDiv;
            dataRow["ShipmSlipPrtDivRF"] = customerGroupWork.ShipmSlipPrtDiv;
            dataRow["EstimatePrtDivRF"] = customerGroupWork.EstimatePrtDiv;
            dataRow["UOESlipPrtDivRF"] = customerGroupWork.UOESlipPrtDiv;
            dataRow["QrcodePrtCdRF"] = customerGroupWork.QrcodePrtCd;
            dataRow["CustSlipNoMngCdRF"] = customerGroupWork.CustSlipNoMngCd;
            dataRow["CustomerSlipNoDivRF"] = customerGroupWork.CustomerSlipNoDiv;
            dataRow["TotalBillOutputDivRF"] = customerGroupWork.TotalBillOutputDiv;
            dataRow["DetailBillOutputCodeRF"] = customerGroupWork.DetailBillOutputCode;
            dataRow["SlipTtlBillOutputDivRF"] = customerGroupWork.SlipTtlBillOutputDiv;
            //dataRow["CustRateGrpFine"] = customerGroupWork.CustRateGrpFine;// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            dataRow["CustRateGrpFineAll"] = customerGroupWork.CustRateGrpFineAll;// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            dataRow["CustRateGrpPureAll"] = customerGroupWork.CustRateGrpPureAll;
            dataRow["CustRateGrpPure1"] = customerGroupWork.CustRateGrpPure1;
            dataRow["CustRateGrpPure2"] = customerGroupWork.CustRateGrpPure2;
            dataRow["CustRateGrpPure3"] = customerGroupWork.CustRateGrpPure3;
            dataRow["CustRateGrpPure4"] = customerGroupWork.CustRateGrpPure4;
            dataRow["CustRateGrpPure5"] = customerGroupWork.CustRateGrpPure5;
            dataRow["CustRateGrpPure6"] = customerGroupWork.CustRateGrpPure6;
            dataRow["CustRateGrpPure7"] = customerGroupWork.CustRateGrpPure7;
            dataRow["CustRateGrpPure8"] = customerGroupWork.CustRateGrpPure8;
            dataRow["CustRateGrpPure9"] = customerGroupWork.CustRateGrpPure9;
            dataRow["CustRateGrpPure10"] = customerGroupWork.CustRateGrpPure10;
            dataRow["CustRateGrpPure11"] = customerGroupWork.CustRateGrpPure11;
            dataRow["CustRateGrpPure12"] = customerGroupWork.CustRateGrpPure12;
            dataRow["CustRateGrpPure13"] = customerGroupWork.CustRateGrpPure13;
            dataRow["CustRateGrpPure14"] = customerGroupWork.CustRateGrpPure14;
            dataRow["CustRateGrpPure15"] = customerGroupWork.CustRateGrpPure15;
            dataRow["CustRateGrpPure16"] = customerGroupWork.CustRateGrpPure16;
            dataRow["CustRateGrpPure17"] = customerGroupWork.CustRateGrpPure17;
            dataRow["CustRateGrpPure18"] = customerGroupWork.CustRateGrpPure18;
            dataRow["CustRateGrpPure19"] = customerGroupWork.CustRateGrpPure19;
            dataRow["CustRateGrpPure20"] = customerGroupWork.CustRateGrpPure20;
            dataRow["CustRateGrpPure21"] = customerGroupWork.CustRateGrpPure21;
            dataRow["CustRateGrpPure22"] = customerGroupWork.CustRateGrpPure22;
            dataRow["CustRateGrpPure23"] = customerGroupWork.CustRateGrpPure23;
            dataRow["CustRateGrpPure24"] = customerGroupWork.CustRateGrpPure24;
            dataRow["CustRateGrpPure25"] = customerGroupWork.CustRateGrpPure25;
            dataRow["ErrorLog"] = customerGroupWork.ErrorLog;
            logTable.Rows.Add(dataRow);
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
        #region �� �f�[�^�ϊ�����
        #region �� �C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// �C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToImportWorkList(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            CustomerWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new CustomerWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.CustomerCode = ConvertToInt32(csvDataArr, index++);            // ���Ӑ�R�[�h
                    work.CustomerSubCode = ConvertToEmpty(csvDataArr, index++);         // �T�u�R�[�h
                    work.Name = ConvertToEmpty(csvDataArr, index++);                    // ���Ӑ於�P
                    work.Name2 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ於�Q
                    work.CustomerSnm = ConvertToEmpty(csvDataArr, index++);             // ���Ӑ旪��
                    work.Kana = ConvertToEmpty(csvDataArr, index++);                    // ���Ӑ於�J�i
                    work.HonorificTitle = ConvertToEmpty(csvDataArr, index++);          // �h��
                    work.OutputNameCode = ConvertToInt32(csvDataArr, index++);          // ����
                    work.MngSectionCode = ConvertToStrCode(csvDataArr, index++, 2);     // �Ǘ����_
                    work.CustomerAgentCd = ConvertToStrCode(csvDataArr, index++, 4);    // ���Ӑ�S��
                    work.OldCustomerAgentCd = ConvertToStrCode(csvDataArr, index++, 4); // ���S��
                    work.CustAgentChgDate = ConvertToDateTime(csvDataArr, index++);     // �S���ҕύX��
                    work.TransStopDate = ConvertToDateTime(csvDataArr, index++);        // ������~��
                    work.CarMngDivCd = ConvertToInt32(csvDataArr, index++);             // ���p�Ǘ�
                    work.CorporateDivCode = ConvertToInt32(csvDataArr, index++);        // �l�E�@�l
                    work.AcceptWholeSale = ConvertToInt32(csvDataArr, index++);         // ���Ӑ���
                    work.CustomerAttributeDiv = ConvertToInt32(csvDataArr, index++);    // ���Ӑ摮��
                    work.CustWarehouseCd = ConvertToStrCode(csvDataArr, index++, 4);    // �D��q��
                    work.BusinessTypeCode = ConvertToInt32(csvDataArr, index++);        // �Ǝ�
                    work.JobTypeCode = ConvertToInt32(csvDataArr, index++);             // �E��
                    work.SalesAreaCode = ConvertToInt32(csvDataArr, index++);           // �n��
                    work.CustAnalysCode1 = ConvertToInt32(csvDataArr, index++);         // ���̓R�[�h�P
                    work.CustAnalysCode2 = ConvertToInt32(csvDataArr, index++);         // ���̓R�[�h�Q
                    work.CustAnalysCode3 = ConvertToInt32(csvDataArr, index++);         // ���̓R�[�h�R
                    work.CustAnalysCode4 = ConvertToInt32(csvDataArr, index++);         // ���̓R�[�h�S
                    work.CustAnalysCode5 = ConvertToInt32(csvDataArr, index++);         // ���̓R�[�h�T
                    work.CustAnalysCode6 = ConvertToInt32(csvDataArr, index++);         // ���̓R�[�h�U
                    work.ClaimSectionCode = ConvertToStrCode(csvDataArr, index++, 2);   // �������_
                    work.ClaimCode = ConvertToInt32(csvDataArr, index++);               // �����R�[�h
                    work.TotalDay = ConvertToInt32(csvDataArr, index++);                // ����
                    work.CollectMoneyCode = ConvertToInt32(csvDataArr, index++);        // �W����
                    work.CollectMoneyDay = ConvertToInt32(csvDataArr, index++);         // �W����
                    work.CollectCond = ConvertToInt32(csvDataArr, index++);             // �������
                    work.CollectSight = ConvertToInt32(csvDataArr, index++);            // ����T�C�g
                    work.NTimeCalcStDate = ConvertToInt32(csvDataArr, index++);         // ���񊨒�
                    work.BillCollecterCd = ConvertToStrCode(csvDataArr, index++, 4);    // �W���S��
                    work.CustCTaXLayRefCd = ConvertToInt32(csvDataArr, index++);        // �]�ŕ����Q�Ƌ敪
                    work.ConsTaxLayMethod = ConvertToInt32(csvDataArr, index++);        // ����œ]�ŕ���
                    work.SalesUnPrcFrcProcCd = ConvertToInt32(csvDataArr, index++);     // �P���[������
                    work.SalesMoneyFrcProcCd = ConvertToInt32(csvDataArr, index++);     // ���z�[������
                    work.SalesCnsTaxFrcProcCd = ConvertToInt32(csvDataArr, index++);    // ����Œ[������
                    work.CreditMngCode = ConvertToInt32(csvDataArr, index++);           // �^�M�Ǘ�
                    work.DepoDelCode = ConvertToInt32(csvDataArr, index++);             // ��������
                    work.AccRecDivCd = ConvertToInt32(csvDataArr, index++);             // ���|�敪
                    work.PostNo = ConvertToEmpty(csvDataArr, index++);                  // �X�֔ԍ�
                    work.Address1 = ConvertToEmpty(csvDataArr, index++);                // �Z��
                    work.Address3 = ConvertToEmpty(csvDataArr, index++);                // �Z���Q
                    work.Address4 = ConvertToEmpty(csvDataArr, index++);                // �Z���R
                    work.CustomerAgent = ConvertToEmpty(csvDataArr, index++);           // ���Ӑ�S����
                    work.HomeTelNo = ConvertToEmpty(csvDataArr, index++);               // ����s�d�k
                    work.OfficeTelNo = ConvertToEmpty(csvDataArr, index++);             // �Ζ���d�b�P
                    work.PortableTelNo = ConvertToEmpty(csvDataArr, index++);           // �Ζ���d�b�Q
                    work.OthersTelNo = ConvertToEmpty(csvDataArr, index++);             // ���̑��d�b
                    work.HomeFaxNo = ConvertToEmpty(csvDataArr, index++);               // ����e�`�w
                    work.OfficeFaxNo = ConvertToEmpty(csvDataArr, index++);             // �Ζ���e�`�w
                    work.SearchTelNo = ConvertToEmpty(csvDataArr, index++);             // �����ԍ�
                    work.MainContactCode = ConvertToInt32(csvDataArr, index++);         // ��A����
                    work.Note1 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�P
                    work.Note2 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�Q
                    work.Note3 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�R
                    work.Note4 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�S
                    work.Note5 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�T
                    work.Note6 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�U
                    work.Note7 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�V
                    work.Note8 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�W
                    work.Note9 = ConvertToEmpty(csvDataArr, index++);                   // ���Ӑ���l�X
                    work.Note10 = ConvertToEmpty(csvDataArr, index++);                  // ���Ӑ���l�P�O
                    work.MainSendMailAddrCd = ConvertToInt32(csvDataArr, index++);      // �呗�M�惁�[���A�h���X�敪
                    work.MailAddress1 = ConvertToEmpty(csvDataArr, index++);            // ���[���A�h���X�P
                    work.MailSendCode1 = ConvertToInt32(csvDataArr, index++);           // ���[�����M�敪�R�[�h�P
                    work.MailAddrKindCode1 = ConvertToInt32(csvDataArr, index++);       // ���[���A�h���X��ʃR�[�h�P
                    work.MailAddress2 = ConvertToEmpty(csvDataArr, index++);            // ���[���A�h���X�Q
                    work.MailSendCode2 = ConvertToInt32(csvDataArr, index++);           // ���[�����M�敪�R�[�h�Q
                    work.MailAddrKindCode2 = ConvertToInt32(csvDataArr, index++);       // ���[���A�h���X��ʃR�[�h�Q
                    work.AccountNoInfo1 = ConvertToEmpty(csvDataArr, index++);          // ��s�����P
                    work.AccountNoInfo2 = ConvertToEmpty(csvDataArr, index++);          // ��s�����Q
                    work.AccountNoInfo3 = ConvertToEmpty(csvDataArr, index++);          // ��s�����R
                    // DEL 2010/02/01 MANTIS�Ή�[14952]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
                    // TODO:�g�p���Ȃ��c�������o��
                    //work.BillOutputCode = ConvertToInt32(csvDataArr, index++);          // �������o��
                    // DEL 2010/02/01 MANTIS�Ή�[14952]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<
                    work.ReceiptOutputCode = ConvertToInt32(csvDataArr, index++);       // �̎����o��
                    work.DmOutCode = ConvertToInt32(csvDataArr, index++);               // �c�l�o��
                    work.SalesSlipPrtDiv = ConvertToInt32(csvDataArr, index++);         // �[�i���o��
                    work.AcpOdrrSlipPrtDiv = ConvertToInt32(csvDataArr, index++);       // �󒍓`�[�o��
                    work.ShipmSlipPrtDiv = ConvertToInt32(csvDataArr, index++);         // �ݏo�`�[�o��
                    work.EstimatePrtDiv = ConvertToInt32(csvDataArr, index++);          // ���ϓ`�[�o��
                    work.UOESlipPrtDiv = ConvertToInt32(csvDataArr, index++);           // �t�n�d�`�[�o��
                    work.QrcodePrtCd = ConvertToInt32(csvDataArr, index++);             // �p�q�R�[�h���
                    work.CustSlipNoMngCd = ConvertToInt32(csvDataArr, index++);         // ����`�[�ԍ��Ǘ�
                    work.CustomerSlipNoDiv = ConvertToInt32(csvDataArr, index++);       // ����`�[�ԍ��敪

                    // ADD 2010/02/01 MANTIS�Ή�[14952]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
                    work.TotalBillOutputDiv = ConvertToInt32(csvDataArr, index++);      // ���v�������o��
                    work.DetailBillOutputCode = ConvertToInt32(csvDataArr, index++);    // ���א������o��
                    work.SlipTtlBillOutputDiv = ConvertToInt32(csvDataArr, index++);    // �`�[���v�������o��
                    // ADD 2010/02/01 MANTIS�Ή�[14952]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region �� ���l���ڂ֕ϊ�����
        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int32 ConvertToInt32(string[] csvDataArr, Int32 index)
        {
            Int32 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt32(csvDataArr[index]);
                }
                catch
                {
                    retNum = 0;
                }
            }

            return retNum;
        }
        #endregion


        #region �� �������ڂ֕ϊ�����
        /// <summary>
        /// �������ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͍ŏ������֕ϊ������������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private DateTime ConvertToDateTime(string[] csvDataArr, Int32 index)
        {
            DateTime retDt = DateTime.MinValue;

            if (index < csvDataArr.Length)
            {
                Int32 tmpNumber = ConvertToInt32(csvDataArr, index);
                if (tmpNumber != 0)
                {
                    retDt = TDateTime.LongDateToDateTime(tmpNumber);
                }
            }

            return retDt;
        }
        #endregion

        #region �� �󔒍��ڂ֕ϊ�����
        /// <summary>
        /// �󔒍��ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion

        #region �� �R�[�h�����񍀖ڂ̕ϊ�����
        /// <summary>
        /// �R�[�h�����񍀖ڂ̕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <param name="maxLength">MAX����</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�����񍀖ڂ̕ϊ��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToStrCode(string[] csvDataArr, Int32 index, Int32 maxLength)
        {
            return ConvertToEmpty(csvDataArr, index).PadLeft(maxLength, '0');
        }
        #endregion
        #endregion

        #endregion �� Private Method
    }
}
