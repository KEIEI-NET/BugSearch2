//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  2010/01/21  �쐬�S�� : ��� �r��
// �C �� ��              �C�����e : �������^�C�v���̏o�͋敪�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S���F������
// �C �� ��  2012/06/12  �C�����e�F��z�Č��ARedmine#30393 
//                                 ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/03  �C�����e �F��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/05  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.30�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/09  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.39�ANO.46�ANO.47�ANO.48�ANO.49�ANO.51�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/11  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/13  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/20  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.94�ANO.106�ANO.107�ANO.108�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/24  �C�����e �F��z�Č��ARedmine#30387
//                                  ���쌟�؁A��Q�ꗗ�̎w�ENO.61�ANO.106�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F���
// �C �� ��  2012/8/3    �C�����e �F���[���A�h���X��ʃR�[�h�̃`�F�b�N�������P������Q���֕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �Fwangl2
// �C �� ��  2013/03/25  �C�����e �FRedmine#35047  No.1841���Ӑ�C���|�[�g�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00 �쐬�S�� �F�c������
// �C �� ��  2022/03/04  �C�����e �F�d�q����A�g�Ή� ���x�����ڂ̕ύX�iDM�o�́��d�q����o�́j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11900025-00 �쐬�S�� �F3H ����
// �C �� ��  2023/06/28  �C�����e �F�C���|�[�g�s��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;// ADD  2012/06/12  ������ Redmine#30393
using Broadleaf.Library.Globarization;// ADD  2012/06/12  ������ Redmine#30393

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br>Update Note: 2012/06/12 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
    /// <br>Update Note: 2012/07/03 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
    /// <br>Update Note: 2012/07/05 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�̑Ή�</br>
    /// <br>Update Note: 2012/07/09 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.39�ANO.46�ANO.47�ANO.48�ANO.49�ANO.51�̑Ή�</br>
    /// <br>Update Note: 2012/07/11 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�</br>
    /// <br>Update Note: 2012/07/13 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�</br>
    /// <br>Update Note: 2012/07/20 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.94�ANO.106�ANO.107�ANO.108�̑Ή�</br>
    /// <br>Update Note: 2012/07/24 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ���쌟�؁A��Q�ꗗ�̎w�ENO.61�ANO.106�̑Ή�</br>
    /// <br>Update Note: 2013/03/25 wangl2</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             Redmine#35047  No.1841���Ӑ�C���|�[�g�̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CustomerImportDB : RemoteDB, ICustomerImportDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public CustomerImportDB()
            : base("PMKHN07644R", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "CustomerRF")
        {
        }

        # region [Import]
        /// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="checkDiv">�`�F�b�N�敪</param>
        /// <param name="consTaxLay">����œ]�ŕ���</param>
        /// <param name="importWorkTable">�C���|�[�g�f�[�^�e�[�u��</param>// ADD  2012/06/12  ������ Redmine#30393
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="logCnt">���O����</param>// ADD  2012/06/12  ������ Redmine#30393
        /// <param name="logArrayList">���O���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        /// <param name="enterpriseCode">��ƃR�[�h</param>// ADD  2012/06/12  ������ Redmine#30393
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2012/07/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        // public int Import(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)// DEL  2012/06/12  ������ Redmine#30393
        // public int Import(Int32 processKbn, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out DataTable logTable, string enterpriseCode, out string errMsg)// ADD  2012/06/12  ������ Redmine#30393  // DEL  2012/07/03  ������ Redmine#30393
        //public int Import(Int32 processKbn, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
        //public int Import(Int32 processKbn, Int32 consTaxLay, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
        //public int Import(Int32 processKbn, Int32 consTaxLay, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        public int Import(Int32 processKbn,Int32 checkDiv, Int32 consTaxLay, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            // ------- ADD START 2012/06/12 Redmine#30393 ������---->>>>
            logCnt = 0;
            //logTable = new DataTable();  // DEL  2012/07/03  ������ Redmine#30393
            //logArrayList = new ArrayList(); // ADD  2012/07/03  ������ Redmine#30393// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            // ------- ADD END 2012/06/12 Redmine#30393 ������---->>>>
            logArrayList = null; // ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            errMsg = string.Empty;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // �C���|�[�g����
                // status = this.ImportProc(processKbn, ref importWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction);// DEL  2012/06/12  ������ Redmine#30393
                //status = this.ImportProc(processKbn, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logTable, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction);// ADD  2012/06/12  ������ Redmine#30393  // DEL  2012/07/03  ������ Redmine#30393
                //status = this.ImportProc(processKbn, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logArrayList, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction);  // ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
                //status = this.ImportProc(processKbn, consTaxLay, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logArrayList, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction); // ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                status = this.ImportProc(processKbn,checkDiv ,consTaxLay, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logArrayList, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // --------------- DEL START 2012/06/12 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        ///// </summary>
        ///// <param name="processKbn">�����敪</param>
        ///// <param name="importWorkList">�C���|�[�g�f�[�^���X�g</param>
        ///// <param name="readCnt">�Ǎ�����</param>
        ///// <param name="addCnt">�ǉ�����</param>
        ///// <param name="updCnt">��������</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <param name="sqlConnection">�R���N�V����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V����</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        ///// <br>Programmer : ���w�q</br>
        ///// <br>Date       : 2009.05.15</br>
        //private int ImportProc(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    readCnt = 0;
        //    addCnt = 0;
        //    updCnt = 0;
        //    errMsg = string.Empty;

        //    // ���Ӑ��DB�����[�g�N���X
        //    CustomerDB customerDB = new CustomerDB();

        //    try
        //    {
        //        // ��ƃR�[�h
        //        string enterpriseCode = null;
        //        // ���Ӑ�R�[�h�z��
        //        int[] customerCodeArray = null;
        //        // ���Ӑ���N���X�z��
        //        CustomerWork[] customerWorkArray = null;
        //        // �X�e�[�^�X�z��
        //        int[] statusArray = null;

        //        // �����p�����[�^�̐ݒ�
        //        ArrayList importWorkArray = importWorkList as ArrayList;
        //        if (importWorkArray == null)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //            return status;
        //        }
        //        else
        //        {
        //            customerCodeArray = new int[importWorkArray.Count];
        //            for (int i = 0; i < importWorkArray.Count; i++)
        //            {
        //                CustomerWork customerWork = (CustomerWork)importWorkArray[i];
        //                enterpriseCode = customerWork.EnterpriseCode;
        //                customerCodeArray[i] = customerWork.CustomerCode;
        //            }
        //        }

        //        // �S�ăf�[�^�̌�������
        //        customerDB.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //        }

        //        // Dictionary�̍쐬
        //        Dictionary<CustomerImportWorkWrap, CustomerWork> dict = new Dictionary<CustomerImportWorkWrap, CustomerWork>();
        //        foreach (CustomerWork work in customerWorkArray)
        //        {
        //            // ���݂���f�[�^��Dictionary�֊i�[����i���C���|�[�gPG�Ə������@���Ⴂ�܂��B�j
        //            if (work.CreateDateTime != DateTime.MinValue)
        //            {
        //               CustomerImportWorkWrap warp = new CustomerImportWorkWrap(work);
        //                dict.Add(warp, work);
        //            }
        //        }

        //        // �ǉ����X�g
        //        ArrayList addList = new ArrayList();
        //        // �X�V���X�g
        //        ArrayList updList = new ArrayList();

        //        foreach (CustomerWork importWork in importWorkArray)
        //        {
        //            CustomerImportWorkWrap importWarp = new CustomerImportWorkWrap(importWork);

        //            if (!dict.ContainsKey(importWarp))
        //            {
        //                if (importWarp.customerWork.CustomerCode != 0)
        //                {
        //                    // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
        //                    addList.Add(ConvertToImportWork(importWork, null, false));
        //                }
        //            }
        //            else
        //            {
        //                // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
        //                updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
        //            }
        //        }

        //        // �Ǎ�����
        //        readCnt = importWorkArray.Count;

        //        // �d���G���[���̏d������
        //        ArrayList duplicationItemList = new ArrayList();

        //        // �����敪���u�ǉ��v�̏ꍇ
        //        if (processKbn == 1)
        //        {
        //            if (addList != null && addList.Count > 0)
        //            {
        //                Object objAddList = addList as object;
        //                // �o�^����
        //                status = customerDB.Write(ref objAddList, out duplicationItemList);
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    addCnt = addList.Count;
        //                }
        //            }
        //        }
        //        // �����敪���u�X�V�v�̏ꍇ
        //        else if (processKbn == 2)
        //        {
        //            if (updList != null && updList.Count > 0)
        //            {
        //                Object objUpdList = updList as object;
        //                // �X�V����
        //                status = customerDB.Write(ref objUpdList, out duplicationItemList);
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    updCnt = updList.Count;
        //                }
        //            }
        //        }
        //        // �����敪���u�ǉ��X�V�v�̏ꍇ
        //        else
        //        {
        //            // �o�^�X�V���X�g�̍쐬
        //            ArrayList addUpdList = new ArrayList();
        //            if (addList.Count > 0)
        //            {
        //                addUpdList.AddRange(addList.GetRange(0, addList.Count));
        //            }
        //            if (updList.Count > 0)
        //            {
        //                addUpdList.AddRange(updList.GetRange(0, updList.Count));
        //            }
        //            if (addUpdList.Count > 0)
        //            {
        //                Object objAddUpdList = addUpdList as object;
        //                // �o�^�X�V����
        //                status = customerDB.Write(ref objAddUpdList, out duplicationItemList);
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    addCnt = addList.Count;
        //                    updCnt = updList.Count;
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        errMsg = ex.Message;
        //        base.WriteSQLErrorLog(ex, errMsg, ex.Number);
        //        // ���[���o�b�N
        //        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                sqlTransaction.Commit();
        //            }

        //            sqlTransaction.Dispose();
        //        }

        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // --------------- DEL END 2012/06/12 Redmine#30393 ������--------<<<<

        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        /// <summary>
        /// ���Ӑ�}�X�^�|���O���[�v�̎擾����B
        /// </summary>
        /// <param name="customerWork">�C���|�[�g�f�[�^</param>
        /// <param name="PureCode">�����敪</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="custRateGrpPure">���Ӑ�|���O���[�v</param>
        /// <returns>csvCustRateGroupWork</returns>
        /// <br>Note       : ���Ӑ�}�X�^�|���O���[�v�̎擾����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        private CustRateGroupWork GetcsvCustRateGroup(CustomerRateWork customerWork, int PureCode, int goodsMakerCd, int custRateGrpPure)
        {
            CustRateGroupWork csvCustRateGroupWork = new CustRateGroupWork();

            csvCustRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode;
            csvCustRateGroupWork.CustomerCode = customerWork.CustomerCode;
            csvCustRateGroupWork.PureCode = PureCode;
            csvCustRateGroupWork.GoodsMakerCd = goodsMakerCd;
            csvCustRateGroupWork.CustRateGrpCode = custRateGrpPure;

            return csvCustRateGroupWork;
        }


        /// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="checkDiv">�`�F�b�N�敪</param>
        /// <param name="csvObj">�C���|�[�g�f�[�^�e�[�u��</param>
        /// <param name="consTaxLay">����œ]�ŕ���</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="logCnt">���O����</param>
        /// <param name="logArrayListWork">���O���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R���N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        //private int ImportProc(Int32 processKbn, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out DataTable logTable, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/06/12  ������ Redmine#30393  // DEL  2012/07/03  ������ Redmine#30393
        //private int ImportProc(Int32 processKbn, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
        //private int ImportProc(Int32 processKbn, Int32 consTaxLay, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
        //private int ImportProc(Int32 processKbn, Int32 consTaxLay, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayListWork, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        private int ImportProc(Int32 processKbn, Int32 checkDiv, Int32 consTaxLay, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayListWork, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            logCnt = 0;
            //logTable = new DataTable();  // DEL  2012/07/03  ������ Redmine#30393
            //logArrayList = new ArrayList();// ADD  2012/07/03  ������ Redmine#30393// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            ArrayList logArrayList = new ArrayList();// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            logArrayListWork = null;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            errMsg = string.Empty;

            // ���Ӑ��DB�����[�g�N���X
            CustomerDB customerDB = new CustomerDB();

            //���Ӑ�|���O���[�v��DB�����[�g�N���X
            CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
            try
            {
                // ���Ӑ�R�[�h�z��
                int[] customerCodeArray = null;
                // ���Ӑ���N���X�z��
                CustomerWork[] customerWorkArray = null;

                // �X�e�[�^�X�z��
                int[] statusArray = null;

                //�C���|�[�g�f�[�^�e�[�u��
                //DataTable csvDataTable = csvObj as DataTable;  // DEL  2012/07/03  ������ Redmine#30393
                ArrayList csvArrayList = csvObj as ArrayList;  // ADD  2012/07/03  ������ Redmine#30393
                //string msg = null; // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                Dictionary<int, int> rightCustCdDic = new Dictionary<int, int>();
                //CreateDataTable( ref logTable);  // DEL  2012/07/03  ������ Redmine#30393
                //if (csvDataTable == null)// DEL  2012/07/03  ������ Redmine#30393
                if (csvArrayList == null)// ADD  2012/07/03  ������ Redmine#30393
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
                    //customerCodeArray = new int[csvDataTable.Rows.Count];
                    //for (int i = 0; i < csvDataTable.Rows.Count; i++)
                    //{
                    //    //���Ӑ�R�[�h
                    //    string customerCd = csvDataTable.Rows[i][0].ToString();

                    //    if (!Check_IsNull("���Ӑ�R�[�h", customerCd, out msg))
                    //    {
                    //        ConverToDataSetCustomerLog(csvDataTable.Rows[i], ref logTable, msg);
                    //        continue;
                    //    }

                    //    if (!Check_ZeroIntAndLen("���Ӑ�R�[�h", customerCd, 8, out msg))
                    //    {
                    //        ConverToDataSetCustomerLog(csvDataTable.Rows[i], ref logTable, msg);
                    //        continue;
                    //    }

                    //    if (!rightCustCdDic.ContainsKey(Convert.ToInt32(csvDataTable.Rows[i][0])))
                    //    {
                    //        rightCustCdDic.Add(i, Convert.ToInt32(csvDataTable.Rows[i][0]));
                    //    }

                    //    customerCodeArray[i] = Convert.ToInt32(csvDataTable.Rows[i][0]);
                    //}
                    // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
                    // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
                    customerCodeArray = new int[csvArrayList.Count];



                    for (int i = 0; i < csvArrayList.Count; i++)
                    {
                        // ------ DEL START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                        //CustomerGroupWork customerGroupWork = (CustomerGroupWork)csvArrayList[i];
                        //if (!Check_IsNull("���Ӑ�R�[�h", customerGroupWork.CustomerCode, out msg))
                        //{
                        //    customerGroupWork.ErrorLog = msg;
                        //    logArrayList.Add(customerGroupWork);
                        //    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                        //    continue;
                        //}

                        //if (!Check_ZeroIntAndLen("���Ӑ�R�[�h", customerGroupWork.CustomerCode, 8, out msg))
                        //{
                        //    customerGroupWork.ErrorLog = msg;
                        //    logArrayList.Add(customerGroupWork);
                        //    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                        //    continue;
                        //}
                        //if (!rightCustCdDic.ContainsKey(Convert.ToInt32(customerGroupWork.CustomerCode)))
                        //{
                        //    rightCustCdDic.Add(i, Convert.ToInt32(customerGroupWork.CustomerCode));
                        //}
                        //customerCodeArray[i] = Convert.ToInt32(customerGroupWork.CustomerCode);
                        // ------ DEL END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<


                        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                        CustomerGroupWork customerGroupWork = (CustomerGroupWork)csvArrayList[i];
                        if (!rightCustCdDic.ContainsKey(i))
                        {
                            rightCustCdDic.Add(i, ConvertToInt32(customerGroupWork.CustomerCode.Trim()));
                        }
                        customerCodeArray[i] = ConvertToInt32(customerGroupWork.CustomerCode.Trim());

                        // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<

                    }
                    // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
                }

                // �S�ăf�[�^�̌�������
                customerDB.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Dictionary�̍쐬
                Dictionary<int, CustomerWork> dict = new Dictionary<int, CustomerWork>();

                foreach (CustomerWork workArray in customerWorkArray)
                {
                    // ���݂���f�[�^��Dictionary�֊i�[����i���C���|�[�gPG�Ə������@���Ⴂ�܂��B�j
                    if (workArray.CreateDateTime != DateTime.MinValue && !dict.ContainsKey(workArray.CustomerCode))
                    {
                        dict.Add(workArray.CustomerCode, workArray);
                    }
                }
                // �ǉ����X�g
                ArrayList addList = new ArrayList();
                // �X�V���X�g
                ArrayList updList = new ArrayList();
                // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
                //for (int index = 0; index < csvDataTable.Rows.Count; index++)
                //{
                //    if (!rightCustCdDic.ContainsKey(index))
                //    {
                //        continue;
                //    }
                //    if (!dict.ContainsKey(Convert.ToInt32(csvDataTable.Rows[index][0])))
                //    {
                //        if (Convert.ToInt32(csvDataTable.Rows[index][0]) != 0)
                //        {
                //            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                //            addList.Add(index);
                //        }
                //    }
                //    else
                //    {
                //        // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                //        updList.Add(index);
                //    }
                //}
                // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
                // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>

                for (int index = 0; index < csvArrayList.Count; index++)
                {
                    if (!rightCustCdDic.ContainsKey(index))
                    {
                        continue;
                    }
                    CustomerGroupWork custom = csvArrayList[index] as CustomerGroupWork;

                    // ------ DEL START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                    //if (!dict.ContainsKey(Convert.ToInt32(custom.CustomerCode)))
                    //{
                    //    if (Convert.ToInt32(custom.CustomerCode) != 0)
                    //    {
                    //        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                    //        addList.Add(index);
                    //    }
                    //}
                    // ------ DEL END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<

                    // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                    if (!dict.ContainsKey(ConvertToInt32(custom.CustomerCode.Trim())))
                    {

                        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�-------->>>>
                        if (checkDiv == 1)
                        {
                            // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�--------<<<<

                            if (ConvertToInt32(custom.CustomerCode.Trim()) != 0)
                            {
                                // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                                addList.Add(index);
                            }
                        }
                        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�-------->>>>
                        else
                        {
                            addList.Add(index);
                        }
                        // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�--------<<<<

                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<
                    else
                    {
                        // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                        updList.Add(index);
                    }
                }
                // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
                // �Ǎ�����
                //readCnt = csvDataTable.Rows.Count;  // DEL  2012/07/03  ������ Redmine#30393
                readCnt = csvArrayList.Count; // ADD  2012/07/03  ������ Redmine#30393

                // �d���G���[���̏d������
                ArrayList duplicationItemList = new ArrayList();

                ArrayList addImportWorkArray = new ArrayList();

                ArrayList updImportWorkArray = new ArrayList();
                //���Ӑ�|���O���[�v�ǉ����X�g
                ArrayList addrateList = new ArrayList();
                // ���Ӑ�|���O���[�v�X�V���X�g
                ArrayList updrateList = new ArrayList();

                ArrayList workList = new ArrayList();

                // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�-------->>>>
                ArrayList importCustWorkArray = csvObj as ArrayList;
                List<CustomerGroupWork> importCustWorCheckList = new List<CustomerGroupWork>();
                CustomerGroupWork[] arr = (CustomerGroupWork[])importCustWorkArray.ToArray(typeof(CustomerGroupWork));
                importCustWorCheckList.AddRange(arr);

                // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�--------<<<<
                // �����敪���u�ǉ��v�̏ꍇ
                if (processKbn == 1)
                {
                    if (addList != null && addList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in addList)
                        {
                            int cust = -1;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            // GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, false, null);// DEL  2012/07/03  ������ Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            {
                                addImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, false));
                            }
                        }
                    }
                    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                    addList = workList;
                } // �����敪���u�X�V�v�̏ꍇ
                else if (processKbn == 2)
                {
                    if (updList != null && updList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in updList)
                        {
                            int cust = -1;
                            CustomerWork custWork = null;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            dict.TryGetValue((int)cust, out custWork);
                            //GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, true, custWork);// DEL  2012/07/03  ������ Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            {
                                updImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, true));
                            }
                        }
                    }
                    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
                    updList = workList;
                }
                // �����敪���u�ǉ��X�V�v�̏ꍇ
                else
                {
                    if (addList != null && addList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in addList)
                        {
                            int cust = -1;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            //GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, false, null);// DEL  2012/07/03  ������ Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            //logArrayListWork = (object)logArrayList;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            {
                                addImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, false));
                            }
                        }
                        addList = workList;
                    }

                    if (updList != null && updList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in updList)
                        {
                            int cust = -1;
                            CustomerWork custWork = null;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            dict.TryGetValue((int)cust, out custWork);
                            //GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, true, custWork);// DEL  2012/07/03  ������ Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/03  ������ Redmine#30393 // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            //logArrayListWork = (object)logArrayList;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
                            {
                                updImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, true));
                            }
                        }
                        updList = workList;// ADD  2012/07/10  ������ Redmine#30393
                    }
                    //updList = workList;// DEL  2012/07/10  ������ Redmine#30393
                }
                //�G���[����
                //logCnt = logTable.Rows.Count;// DEL  2012/07/03  ������ Redmine#30393
                logCnt = logArrayList.Count;// ADD  2012/07/03  ������ Redmine#30393
                logArrayListWork = (object)logArrayList; // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                // �����敪���u�ǉ��v�̏ꍇ
                if (processKbn == 1)
                {
                    if (addList != null && addList.Count > 0)
                    {

                        Object objAddList = addList as object;
                        // �o�^����
                        status = customerDB.Write(ref objAddList, out duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            GetRateList(addImportWorkArray, addrateList, updrateList, enterpriseCode);
                            addCnt = addList.Count;
                        }

                    }
                }

                // �����敪���u�X�V�v�̏ꍇ
                else if (processKbn == 2)
                {
                    if (updList != null && updList.Count > 0)
                    {
                        Object objUpdList = updList as object;
                        // �X�V����
                        status = customerDB.Write(ref objUpdList, out duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            GetRateList(updImportWorkArray, addrateList, updrateList, enterpriseCode);
                            updCnt = updList.Count;
                        }
                    }
                }
                // �����敪���u�ǉ��X�V�v�̏ꍇ
                else
                {
                    // �o�^�X�V���X�g�̍쐬
                    ArrayList addUpdList = new ArrayList();
                    if (addList.Count > 0)
                    {
                        addUpdList.AddRange(addList.GetRange(0, addList.Count));
                    }
                    if (updList.Count > 0)
                    {
                        addUpdList.AddRange(updList.GetRange(0, updList.Count));
                    }


                    if (addUpdList.Count > 0)
                    {
                        Object objAddUpdList = addUpdList as object;
                        // �o�^�X�V����
                        status = customerDB.Write(ref objAddUpdList, out duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            ArrayList addUpdRateList = new ArrayList();
                            if (addImportWorkArray.Count > 0)
                            {
                                addUpdRateList.AddRange(addImportWorkArray.GetRange(0, addList.Count));
                            }
                            if (updImportWorkArray.Count > 0)
                            {
                                addUpdRateList.AddRange(updImportWorkArray.GetRange(0, updList.Count));
                            }

                            GetRateList(addUpdRateList, addrateList, updrateList, enterpriseCode);
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        /// <summary>
        ///  ���Ӑ惏�[�N�����B
        /// </summary>
        /// <param name="custrate">���Ӑ�|���O���[�v���[�N</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���O�e�[�u�������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/09 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.39�ANO.46�ANO.47�ANO.48�ANO.49�ANO.51�̑Ή�</br>
        /// <br>Update Note: 2023/06/28 3H ����</br>
        /// <br>�Ǘ��ԍ�   : 11900025-00 �C���|�[�g�s��Ή�</br>
        /// <br>           : �@�W�����敪����</br>
        /// <br>           : �A��������</br>
        /// <br>           : �B���͋��_�R�[�h</br>
        /// <br>           : �CDM�o�͋敪����</br>
        /// <br>           : �D���[���A�h���X��ʖ���1</br>
        /// <br>           : �E���[�����M�敪����1</br>
        /// <br>           : �F���[���A�h���X��ʖ���2</br>
        /// <br>           : �G���[�����M�敪����2</br>
        private CustomerWork GetCustomerWork(CustomerRateWork custrate, bool isUpdFlg)
        {
            CustomerWork work = new CustomerWork();
            if (isUpdFlg)
            {
                // �X�V�̏ꍇ
                work.CreateDateTime = custrate.CreateDateTime;              // �쐬����
                work.UpdateDateTime = custrate.UpdateDateTime;              // �X�V����
                work.FileHeaderGuid = custrate.FileHeaderGuid;              // GUID
                work.LogicalDeleteCode = 0;                                 // �_���폜�敪
                work.PureCode = custrate.PureCode;                          // �����敪
                work.TotalAmountDispWayCd = custrate.TotalAmountDispWayCd;  // ���z�\�����@�敪
                work.TotalAmntDspWayRef = custrate.TotalAmntDspWayRef;      // ���z�\�����@�Q�Ƌ敪
                work.BillPartsNoPrtCd = custrate.BillPartsNoPrtCd;          // �i�Ԉ󎚋敪(������)
                work.DeliPartsNoPrtCd = custrate.DeliPartsNoPrtCd;          // �i�Ԉ󎚋敪(�[�i���j
                work.DefSalesSlipCd = custrate.DefSalesSlipCd;              // �`�[�敪�����l
                work.LavorRateRank = custrate.LavorRateRank;                // �H�����o���[�g�����N
                work.SlipTtlPrn = custrate.SlipTtlPrn;                      // �`�[�^�C�g���p�^�[��
                work.DepoBankCode = custrate.DepoBankCode;                  // ������s�R�[�h
                work.DeliHonorificTtl = custrate.DeliHonorificTtl;          // �[�i���h��
                work.BillHonorificTtl = custrate.BillHonorificTtl;          // �������h��
                work.EstmHonorificTtl = custrate.EstmHonorificTtl;          // ���Ϗ��h��
                work.RectHonorificTtl = custrate.RectHonorificTtl;          // �̎����h��
                work.DeliHonorTtlPrtDiv = custrate.DeliHonorTtlPrtDiv;      // �[�i���h�̈󎚋敪
                work.BillHonorTtlPrtDiv = custrate.BillHonorTtlPrtDiv;      // �������h�̈󎚋敪
                work.EstmHonorTtlPrtDiv = custrate.EstmHonorTtlPrtDiv;      // ���Ϗ��h�̈󎚋敪
                work.RectHonorTtlPrtDiv = custrate.RectHonorTtlPrtDiv;      // �̎����h�̈󎚋敪
                work.CustomerEpCode = custrate.CustomerEpCode;              // ���Ӑ��ƃR�[�h
                work.CustomerSecCode = custrate.CustomerSecCode;            // ���Ӑ拒�_�R�[�h
                work.OnlineKindDiv = custrate.OnlineKindDiv;                // �I�����C����ʋ敪
                work.SimplInqAcntAcntGrId = custrate.SimplInqAcntAcntGrId;  // �I�����C���A�J�E���gID  ADD  2012/07/09  ������ Redmine#30393 for  ��Q�ꗗ�̎w�ENO.47�̑Ή�
            }
            else
            {
                // �V�K�̏ꍇ
                work.PureCode = 0;                                            // �����敪
                work.TotalAmountDispWayCd = 0;                                // ���z�\�����@�敪
                work.TotalAmntDspWayRef = 0;                                  // ���z�\�����@�Q�Ƌ敪
                work.BillPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(������)
                work.DeliPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(�[�i���j
                work.DefSalesSlipCd = 0;                                      // �`�[�敪�����l
                work.LavorRateRank = 0;                                       // �H�����o���[�g�����N
                work.SlipTtlPrn = 0;                                          // �`�[�^�C�g���p�^�[��
                work.DepoBankCode = 0;                                        // ������s�R�[�h
                work.DeliHonorificTtl = string.Empty;                         // �[�i���h��
                work.BillHonorificTtl = string.Empty;                         // �������h��
                work.EstmHonorificTtl = string.Empty;                         // ���Ϗ��h��
                work.RectHonorificTtl = string.Empty;                         // �̎����h��
                work.DeliHonorTtlPrtDiv = 0;                                  // �[�i���h�̈󎚋敪
                work.BillHonorTtlPrtDiv = 0;                                  // �������h�̈󎚋敪
                work.EstmHonorTtlPrtDiv = 0;                                  // ���Ϗ��h�̈󎚋敪
                work.RectHonorTtlPrtDiv = 0;                                  // �̎����h�̈󎚋敪
                work.CustomerEpCode = string.Empty;                           // ���Ӑ��ƃR�[�h
                work.CustomerSecCode = string.Empty;                          // ���Ӑ拒�_�R�[�h
                work.OnlineKindDiv = 0;                                       // �I�����C����ʋ敪

            }
            work.EnterpriseCode = custrate.EnterpriseCode;
            work.CustomerCode = custrate.CustomerCode;                        // ���Ӑ�R�[�h
            work.CustomerSubCode = custrate.CustomerSubCode;                  // �T�u�R�[�h
            work.Name = custrate.Name;                                        // ���Ӑ於�P
            work.Name2 = custrate.Name2;                                      // ���Ӑ於�Q
            work.CustomerSnm = custrate.CustomerSnm;                          // ���Ӑ旪��
            work.Kana = custrate.Kana;                                        // ���Ӑ於�J�i
            work.HonorificTitle = custrate.HonorificTitle;                    // �h��
            work.OutputNameCode = custrate.OutputNameCode;                    // ����
            work.OutputName = GetOutputNameNew(custrate.OutputNameCode);      // �������� // ADD 2023/06/28 3H ����
            work.MngSectionCode = custrate.MngSectionCode;                    // �Ǘ����_
            work.InpSectionCode = custrate.MngSectionCode;                    // ���͋��_�R�[�h // ADD 2023/06/28 3H ����
            work.CustomerAgentCd = custrate.CustomerAgentCd;                  // ���Ӑ�S��
            work.OldCustomerAgentCd = custrate.OldCustomerAgentCd;            // ���S��
            work.CustAgentChgDate = custrate.CustAgentChgDate;                // �S���ҕύX��
            work.TransStopDate = custrate.TransStopDate;                      // ������~��
            work.CarMngDivCd = custrate.CarMngDivCd;                          // ���p�Ǘ�
            work.CorporateDivCode = custrate.CorporateDivCode;                // �l�E�@�l
            work.AcceptWholeSale = custrate.AcceptWholeSale;                  // ���Ӑ���
            work.CustomerAttributeDiv = custrate.CustomerAttributeDiv;        // ���Ӑ摮��
            work.CustWarehouseCd = custrate.CustWarehouseCd;                  // �D��q��
            work.BusinessTypeCode = custrate.BusinessTypeCode;                // �Ǝ�
            work.JobTypeCode = custrate.JobTypeCode;                          // �E��
            work.SalesAreaCode = custrate.SalesAreaCode;                      // �n��
            work.CustAnalysCode1 = custrate.CustAnalysCode1;                  // ���̓R�[�h�P
            work.CustAnalysCode2 = custrate.CustAnalysCode2;                  // ���̓R�[�h�Q
            work.CustAnalysCode3 = custrate.CustAnalysCode3;                  // ���̓R�[�h�R
            work.CustAnalysCode4 = custrate.CustAnalysCode4;                  // ���̓R�[�h�S
            work.CustAnalysCode5 = custrate.CustAnalysCode5;                  // ���̓R�[�h�T
            work.CustAnalysCode6 = custrate.CustAnalysCode6;                  // ���̓R�[�h�U
            work.ClaimSectionCode = custrate.ClaimSectionCode;                // �������_
            work.ClaimCode = custrate.ClaimCode;                              // �����R�[�h
            work.TotalDay = custrate.TotalDay;                                // ����
            work.CollectMoneyCode = custrate.CollectMoneyCode;                // �W����
            work.CollectMoneyName = GetCollectMoneyName(custrate.CollectMoneyCode);// �W�����敪���� // ADD 2023/06/28 3H ����
            work.CollectMoneyDay = custrate.CollectMoneyDay;                  // �W����
            work.CollectCond = custrate.CollectCond;                          // �������
            work.CollectSight = custrate.CollectSight;                        // ����T�C�g
            work.NTimeCalcStDate = custrate.NTimeCalcStDate;                  // ���񊨒�
            work.BillCollecterCd = custrate.BillCollecterCd;                  // �W���S��
            work.CustCTaXLayRefCd = custrate.CustCTaXLayRefCd;                // �]�ŕ����Q�Ƌ敪
            work.ConsTaxLayMethod = custrate.ConsTaxLayMethod;                // ����œ]�ŕ���
            work.SalesUnPrcFrcProcCd = custrate.SalesUnPrcFrcProcCd;          // �P���[������
            work.SalesMoneyFrcProcCd = custrate.SalesMoneyFrcProcCd;          // ���z�[������
            work.SalesCnsTaxFrcProcCd = custrate.SalesCnsTaxFrcProcCd;        // ����Œ[������
            work.CreditMngCode = custrate.CreditMngCode;                      // �^�M�Ǘ�
            work.DepoDelCode = custrate.DepoDelCode;                          // ��������
            work.AccRecDivCd = custrate.AccRecDivCd;                          // ���|�敪
            work.PostNo = custrate.PostNo;                                    // �X�֔ԍ�
            work.Address1 = custrate.Address1;                                // �Z��
            work.Address3 = custrate.Address3;                                // �Z���Q
            work.Address4 = custrate.Address4;                                // �Z���R
            work.CustomerAgent = custrate.CustomerAgent;                      // ���Ӑ�S����
            work.HomeTelNo = custrate.HomeTelNo;                              // ����s�d�k
            work.OfficeTelNo = custrate.OfficeTelNo;                          // �Ζ���d�b�P
            work.PortableTelNo = custrate.PortableTelNo;                      // �Ζ���d�b�Q
            work.OthersTelNo = custrate.OthersTelNo;                          // ���̑��d�b
            work.HomeFaxNo = custrate.HomeFaxNo;                              // ����e�`�w
            work.OfficeFaxNo = custrate.OfficeFaxNo;                          // �Ζ���e�`�w
            work.SearchTelNo = custrate.SearchTelNo;                          // �����ԍ�
            work.MainContactCode = custrate.MainContactCode;                  // ��A����
            work.Note1 = custrate.Note1;                                      // ���Ӑ���l�P
            work.Note2 = custrate.Note2;                                      // ���Ӑ���l�Q
            work.Note3 = custrate.Note3;                                      // ���Ӑ���l�R
            work.Note4 = custrate.Note4;                                      // ���Ӑ���l�S
            work.Note5 = custrate.Note5;                                      // ���Ӑ���l�T
            work.Note6 = custrate.Note6;                                      // ���Ӑ���l�U
            work.Note7 = custrate.Note7;                                      // ���Ӑ���l�V
            work.Note8 = custrate.Note8;                                      // ���Ӑ���l�W
            work.Note9 = custrate.Note9;                                      // ���Ӑ���l�X
            work.Note10 = custrate.Note10;                                    // ���Ӑ���l�P�O
            work.MainSendMailAddrCd = custrate.MainSendMailAddrCd;            // �呗�M�惁�[���A�h���X�敪
            work.MailAddress1 = custrate.MailAddress1;                        // ���[���A�h���X�P
            work.MailSendCode1 = custrate.MailSendCode1;                      // ���[�����M�敪�R�[�h�P
            work.MailSendName1 = GetMailSendName1(custrate.MailSendCode1);    // ���[�����M�敪����1  // ADD 2023/06/28 3H ����
            work.MailAddrKindCode1 = custrate.MailAddrKindCode1;              // ���[���A�h���X��ʃR�[�h�P
            work.MailAddrKindName1 = GetMailAddrKindName1(custrate.MailAddrKindCode1); // ���[���A�h���X��ʖ���1 // ADD 2023/06/28 3H ����
            work.MailAddress2 = custrate.MailAddress2;                        // ���[���A�h���X�Q
            work.MailSendCode2 = custrate.MailSendCode2;                      // ���[�����M�敪�R�[�h�Q
            work.MailSendName2 = GetMailSendName2(custrate.MailSendCode2);    // ���[�����M�敪����2  // ADD 2023/06/28 3H ����
            work.MailAddrKindCode2 = custrate.MailAddrKindCode2;              // ���[���A�h���X��ʃR�[�h�Q
            work.MailAddrKindName2 = GetMailAddrKindName2(custrate.MailAddrKindCode2); // ���[���A�h���X��ʖ���2 // ADD 2023/06/28 3H ����
            work.AccountNoInfo1 = custrate.AccountNoInfo1;                    // ��s�����P
            work.AccountNoInfo2 = custrate.AccountNoInfo2;                    // ��s�����Q
            work.AccountNoInfo3 = custrate.AccountNoInfo3;                    // ��s�����R
            work.ReceiptOutputCode = custrate.ReceiptOutputCode;              // �̎����o��
            work.DmOutCode = custrate.DmOutCode;                              // �c�l�o��
            work.DmOutName = GetDmOutName(custrate.DmOutCode);                    // DM�o�͋敪���� // ADD 2023/06/28 3H ����
            work.SalesSlipPrtDiv = custrate.SalesSlipPrtDiv;                  // �[�i���o��
            work.AcpOdrrSlipPrtDiv = custrate.AcpOdrrSlipPrtDiv;              // �󒍓`�[�o��
            work.ShipmSlipPrtDiv = custrate.ShipmSlipPrtDiv;                  // �ݏo�`�[�o��
            work.EstimatePrtDiv = custrate.EstimatePrtDiv;                    // ���ϓ`�[�o��
            work.UOESlipPrtDiv = custrate.UOESlipPrtDiv;                      // �t�n�d�`�[�o��
            work.QrcodePrtCd = custrate.QrcodePrtCd;                          // �p�q�R�[�h���
            work.CustSlipNoMngCd = custrate.CustSlipNoMngCd;                  // ����`�[�ԍ��Ǘ�
            work.CustomerSlipNoDiv = custrate.CustomerSlipNoDiv;              // ����`�[�ԍ��敪

            work.TotalBillOutputDiv = custrate.TotalBillOutputDiv;            // ���v�������o��
            work.DetailBillOutputCode = custrate.DetailBillOutputCode;        // ���א������o��
            work.SlipTtlBillOutputDiv = custrate.SlipTtlBillOutputDiv;        // �`�[���v�������o�͋敪
            return work;
        }
        /// <summary>
        /// ���O�e�[�u�������B
        /// </summary>
        /// <param name="index">�������f�[�^�̍s��</param>
        /// <param name="checkDiv">�`�F�b�N�敪</param>
        /// <param name="consTaxLay">����œ]�ŕ���</param>
        /// <param name="importCustWorCheckList">�`�F�b�N���X�g</param>
        /// <param name="csvArrayList">�C���|�[�g�f�[�^���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        /// <param name="logArrayList">���O���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="isUpdFlag">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <param name="work">CustomerWork</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���O�e�[�u�������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.94�ANO.106�ANO.107�ANO.108�̑Ή�</br>
        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        //private void GetLogTable(int index, DataTable csvDataTable, ref DataTable logTable,
        //    string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)
        //{

        //    CheckData(csvDataTable.Rows[index], ref work, ref logTable, enterpriseCode, isUpdFlag, searchWork);
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
        //private void GetLogTable(int index, ArrayList csvArrayList, ref ArrayList logArrayList,
        //    string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
        //private void GetLogTable(int index, Int32 consTaxLay, ArrayList csvArrayList, ref ArrayList logArrayList,
        //      string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        private void GetLogTable(int index, Int32 checkDiv, Int32 consTaxLay, List<CustomerGroupWork> importCustWorCheckList, ArrayList csvArrayList, ref ArrayList logArrayList,
               string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        {

            //CheckData((CustomerGroupWork)csvArrayList[index], ref work, ref logArrayList, enterpriseCode, isUpdFlag, searchWork);// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
            //CheckData((CustomerGroupWork)csvArrayList[index], consTaxLay, ref work, ref logArrayList, enterpriseCode, isUpdFlag, searchWork); // ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�   // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
            CheckData((CustomerGroupWork)csvArrayList[index], checkDiv, consTaxLay, importCustWorCheckList, ref work, ref logArrayList, enterpriseCode, isUpdFlag, searchWork);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
        /// <summary>
        /// ���Ӑ�|���O���[�v���X�gWrite�����B
        /// </summary>
        /// <param name="newImportWorkArray">�������f�[�^�̍s��</param>
        /// <param name="addrateList">���Ӑ�|���O���[�v�ǉ����X�g</param>
        /// <param name="updrateList">���Ӑ�|���O���[�v�X�V���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <br>Note       : ���Ӑ�|���O���[�v���X�gWrite�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/09 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.39�ANO.46�ANO.47�ANO.48�ANO.49�ANO.51�̑Ή�</br>
        /// <br>Update Note: 2012/07/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ���쌟�؁A��Q�ꗗ�̎w�ENO.61�ANO.106�̑Ή�</br>
        private void GetRateList(ArrayList newImportWorkArray, ArrayList addrateList, ArrayList updrateList, string enterpriseCode)
        {
            Dictionary<CustomerRateImportWorkWrap, CustRateGroupWork> dictrate = new Dictionary<CustomerRateImportWorkWrap, CustRateGroupWork>();
            CustRateGroupDB custRateGroupDB = new CustRateGroupDB();

            // �S�ē��Ӑ�|���O���[�v�̌�������
            CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
            custRateGroupWork.EnterpriseCode = enterpriseCode;
            object custRateGroupObj = new object();
            object paramCustRateObj = (object)custRateGroupWork;
            custRateGroupDB.Search(ref custRateGroupObj, paramCustRateObj, 0, ConstantManagement.LogicalMode.GetDataAll);
            ArrayList searchCustRateGroupList = (ArrayList)custRateGroupObj;

            foreach (CustRateGroupWork workrate in searchCustRateGroupList)
            {
                // ���݂���f�[�^��Dictionary�֊i�[����i���C���|�[�gPG�Ə������@���Ⴂ�܂��B�j
                if (workrate.CreateDateTime != DateTime.MinValue)
                {
                    CustomerRateImportWorkWrap warprate = new CustomerRateImportWorkWrap(workrate);
                    dictrate.Add(warprate, workrate);
                }
            }
            foreach (CustomerRateWork customerWork in newImportWorkArray)
            {
                ArrayList csvCustRateGroupList = new ArrayList();
                addrateList = new ArrayList();
                updrateList = new ArrayList();

                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFine)); //���Ӑ�|���O���[�v(�D��)// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                #region  DEL 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�
                // --------------- DEL START 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�-------->>>>
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//���Ӑ�|���O���[�v(�D��ALL)// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 0, customerWork.CustRateGrpPureAll));//���Ӑ�|���O���[�v(����ALL)
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 1, customerWork.CustRateGrpPure1));  //���Ӑ�|���O���[�v����1
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 2, customerWork.CustRateGrpPure2));  //���Ӑ�|���O���[�v����2
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 3, customerWork.CustRateGrpPure3));  //���Ӑ�|���O���[�v����3
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 4, customerWork.CustRateGrpPure4));  //���Ӑ�|���O���[�v����4
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 5, customerWork.CustRateGrpPure5));  //���Ӑ�|���O���[�v����5
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 6, customerWork.CustRateGrpPure6));  //���Ӑ�|���O���[�v����6
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 7, customerWork.CustRateGrpPure7));  //���Ӑ�|���O���[�v����7
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 8, customerWork.CustRateGrpPure8));  //���Ӑ�|���O���[�v����8
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 9, customerWork.CustRateGrpPure9));  //���Ӑ�|���O���[�v����9
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 10, customerWork.CustRateGrpPure10));//���Ӑ�|���O���[�v����10
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 11, customerWork.CustRateGrpPure11));//���Ӑ�|���O���[�v����11
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 12, customerWork.CustRateGrpPure12));//���Ӑ�|���O���[�v����12
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 13, customerWork.CustRateGrpPure13));//���Ӑ�|���O���[�v����13
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 14, customerWork.CustRateGrpPure14));//���Ӑ�|���O���[�v����14
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 15, customerWork.CustRateGrpPure15));//���Ӑ�|���O���[�v����15
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 16, customerWork.CustRateGrpPure16));//���Ӑ�|���O���[�v����16
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 17, customerWork.CustRateGrpPure17));//���Ӑ�|���O���[�v����17
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 18, customerWork.CustRateGrpPure18));//���Ӑ�|���O���[�v����18
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 19, customerWork.CustRateGrpPure19));//���Ӑ�|���O���[�v����19
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 20, customerWork.CustRateGrpPure20));//���Ӑ�|���O���[�v����20
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 21, customerWork.CustRateGrpPure21));//���Ӑ�|���O���[�v����21
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 22, customerWork.CustRateGrpPure22));//���Ӑ�|���O���[�v����22
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 23, customerWork.CustRateGrpPure23));//���Ӑ�|���O���[�v����23
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 24, customerWork.CustRateGrpPure24));//���Ӑ�|���O���[�v����24
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 25, customerWork.CustRateGrpPure25));//���Ӑ�|���O���[�v����25
                // --------------- DEL END 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�--------<<<<
                #endregion

                #region  ADD 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�
                // --------------- ADD START 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�-------->>>>
                if (!(customerWork.CustRateGrpPure1 == -1 && customerWork.CustRateGrpPure2 == -1 && customerWork.CustRateGrpPure3 == -1 && customerWork.CustRateGrpPure4 == -1 && customerWork.CustRateGrpPure5 == -1 &&
                        customerWork.CustRateGrpPure6 == -1 && customerWork.CustRateGrpPure7 == -1 && customerWork.CustRateGrpPure8 == -1 && customerWork.CustRateGrpPure9 == -1 && customerWork.CustRateGrpPure10 == -1 &&
                        customerWork.CustRateGrpPure11 == -1 && customerWork.CustRateGrpPure12 == -1 && customerWork.CustRateGrpPure13 == -1 && customerWork.CustRateGrpPure14 == -1 && customerWork.CustRateGrpPure15 == -1 &&
                        customerWork.CustRateGrpPure16 == -1 && customerWork.CustRateGrpPure17 == -1 && customerWork.CustRateGrpPure18 == -1 && customerWork.CustRateGrpPure19 == -1 && customerWork.CustRateGrpPure20 == -1 &&
                        customerWork.CustRateGrpPure21 == -1 && customerWork.CustRateGrpPure22 == -1 && customerWork.CustRateGrpPure23 == -1 && customerWork.CustRateGrpPure24 == -1 && customerWork.CustRateGrpPure25 == -1 &&
                        customerWork.CustRateGrpFineAll == -1 && customerWork.CustRateGrpPureAll == -1))
                {
                    // ���Ӑ�|���O���[�v(����ALL)����ꍇ
                    if (customerWork.CustRateGrpPureAll != -1)
                    {
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 0, customerWork.CustRateGrpPureAll));//���Ӑ�|���O���[�v(����ALL)
                        csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//���Ӑ�|���O���[�v(�D��ALL)
                        // �폜���X�g
                        ArrayList delCustRateGroupWorkList = new ArrayList();
                        // �폜�f�[�^�擾
                        foreach (CustRateGroupWork wk in searchCustRateGroupList)
                        {
                            if (wk.EnterpriseCode == customerWork.EnterpriseCode &&
                                wk.CustomerCode == customerWork.CustomerCode &&
                                wk.PureCode == 0 && wk.GoodsMakerCd != 0)
                            {
                                delCustRateGroupWorkList.Add(wk);
                            }
                        }
                        // �f�[�^�̍폜
                        if (delCustRateGroupWorkList != null && delCustRateGroupWorkList.Count > 0)
                        {
                            // ArrayList����z��𐶐�
                            CustRateGroupWork[] works = (CustRateGroupWork[])delCustRateGroupWorkList.ToArray(typeof(CustRateGroupWork));

                            // XML�֕ϊ����A������̃o�C�i����
                            byte[] parabyte = XmlByteSerializer.Serialize(works);

                            custRateGroupDB.Delete(parabyte);
                        }

                    }
                    else
                    {
                        // ���Ӑ�|���O���[�v�������ꍇ
                        if (customerWork.CustRateGrpPure1 == -1 && customerWork.CustRateGrpPure2 == -1 && customerWork.CustRateGrpPure3 == -1 && customerWork.CustRateGrpPure4 == -1 && customerWork.CustRateGrpPure5 == -1 &&
                            customerWork.CustRateGrpPure6 == -1 && customerWork.CustRateGrpPure7 == -1 && customerWork.CustRateGrpPure8 == -1 && customerWork.CustRateGrpPure9 == -1 && customerWork.CustRateGrpPure10 == -1 &&
                            customerWork.CustRateGrpPure11 == -1 && customerWork.CustRateGrpPure12 == -1 && customerWork.CustRateGrpPure13 == -1 && customerWork.CustRateGrpPure14 == -1 && customerWork.CustRateGrpPure15 == -1 &&
                            customerWork.CustRateGrpPure16 == -1 && customerWork.CustRateGrpPure17 == -1 && customerWork.CustRateGrpPure18 == -1 && customerWork.CustRateGrpPure19 == -1 && customerWork.CustRateGrpPure20 == -1 &&
                            customerWork.CustRateGrpPure21 == -1 && customerWork.CustRateGrpPure22 == -1 && customerWork.CustRateGrpPure23 == -1 && customerWork.CustRateGrpPure24 == -1 && customerWork.CustRateGrpPure25 == -1)
                        {
                            csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 0, customerWork.CustRateGrpPureAll));// ���Ӑ�|���O���[�v(����ALL)
                            csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//���Ӑ�|���O���[�v(�D��ALL)
                            // �폜���X�g
                            ArrayList delCustRateGroupWorkList = new ArrayList();
                            // �폜�f�[�^�擾
                            foreach (CustRateGroupWork wk in searchCustRateGroupList)
                            {
                                if (wk.EnterpriseCode == customerWork.EnterpriseCode &&
                                    wk.CustomerCode == customerWork.CustomerCode &&
                                    wk.PureCode == 0 && wk.GoodsMakerCd != 0)
                                {
                                    delCustRateGroupWorkList.Add(wk);
                                }
                            }
                            // �f�[�^�̍폜
                            if (delCustRateGroupWorkList != null && delCustRateGroupWorkList.Count > 0)
                            {
                                // ArrayList����z��𐶐�
                                CustRateGroupWork[] works = (CustRateGroupWork[])delCustRateGroupWorkList.ToArray(typeof(CustRateGroupWork));

                                // XML�֕ϊ����A������̃o�C�i����
                                byte[] parabyte = XmlByteSerializer.Serialize(works);

                                custRateGroupDB.Delete(parabyte);
                            }
                        }
                        else
                        {
                            csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//���Ӑ�|���O���[�v(�D��ALL)
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 1, customerWork.CustRateGrpPure1));  //���Ӑ�|���O���[�v����1
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 2, customerWork.CustRateGrpPure2));  //���Ӑ�|���O���[�v����2
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 3, customerWork.CustRateGrpPure3));  //���Ӑ�|���O���[�v����3
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 4, customerWork.CustRateGrpPure4));  //���Ӑ�|���O���[�v����4
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 5, customerWork.CustRateGrpPure5));  //���Ӑ�|���O���[�v����5
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 6, customerWork.CustRateGrpPure6));  //���Ӑ�|���O���[�v����6
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 7, customerWork.CustRateGrpPure7));  //���Ӑ�|���O���[�v����7
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 8, customerWork.CustRateGrpPure8));  //���Ӑ�|���O���[�v����8
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 9, customerWork.CustRateGrpPure9));  //���Ӑ�|���O���[�v����9
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 10, customerWork.CustRateGrpPure10));//���Ӑ�|���O���[�v����10
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 11, customerWork.CustRateGrpPure11));//���Ӑ�|���O���[�v����11
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 12, customerWork.CustRateGrpPure12));//���Ӑ�|���O���[�v����12
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 13, customerWork.CustRateGrpPure13));//���Ӑ�|���O���[�v����13
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 14, customerWork.CustRateGrpPure14));//���Ӑ�|���O���[�v����14
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 15, customerWork.CustRateGrpPure15));//���Ӑ�|���O���[�v����15
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 16, customerWork.CustRateGrpPure16));//���Ӑ�|���O���[�v����16
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 17, customerWork.CustRateGrpPure17));//���Ӑ�|���O���[�v����17
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 18, customerWork.CustRateGrpPure18));//���Ӑ�|���O���[�v����18
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 19, customerWork.CustRateGrpPure19));//���Ӑ�|���O���[�v����19
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 20, customerWork.CustRateGrpPure20));//���Ӑ�|���O���[�v����20
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 21, customerWork.CustRateGrpPure21));//���Ӑ�|���O���[�v����21
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 22, customerWork.CustRateGrpPure22));//���Ӑ�|���O���[�v����22
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 23, customerWork.CustRateGrpPure23));//���Ӑ�|���O���[�v����23
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 24, customerWork.CustRateGrpPure24));//���Ӑ�|���O���[�v����24
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 25, customerWork.CustRateGrpPure25));//���Ӑ�|���O���[�v����25
                            // �폜���X�g
                            ArrayList delCustRateGroupWorkList = new ArrayList();
                            // �폜�f�[�^�擾
                            foreach (CustRateGroupWork wk in searchCustRateGroupList)
                            {
                                if (wk.EnterpriseCode == customerWork.EnterpriseCode &&
                                    wk.CustomerCode == customerWork.CustomerCode &&
                                    wk.PureCode == 0 && wk.GoodsMakerCd == 0)
                                {
                                    delCustRateGroupWorkList.Add(wk);
                                }
                            }
                            // �f�[�^�̍폜
                            if (delCustRateGroupWorkList != null && delCustRateGroupWorkList.Count > 0)
                            {
                                // ArrayList����z��𐶐�
                                CustRateGroupWork[] works = (CustRateGroupWork[])delCustRateGroupWorkList.ToArray(typeof(CustRateGroupWork));

                                // XML�֕ϊ����A������̃o�C�i����
                                byte[] parabyte = XmlByteSerializer.Serialize(works);

                                custRateGroupDB.Delete(parabyte);
                            }
                        }
                    }
                }
                // --------------- ADD END 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�--------<<<<
                #endregion
                foreach (CustRateGroupWork importRateWork in csvCustRateGroupList)
                {
                    CustomerRateImportWorkWrap importRateWarp = new CustomerRateImportWorkWrap(importRateWork);
                    if (!dictrate.ContainsKey(importRateWarp))
                    {
                        if (importRateWarp.custRateGroupWork.CustomerCode != 0)
                        {
                            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                            addrateList.Add(ConvertToImportRateWork(importRateWork, null, false));
                        }
                    }
                    else
                    {
                        // ------ ADD START 2012/07/24 Redmine#30393 ������ for ���쌟��-------->>>>
                        if (dictrate[importRateWarp].LogicalDeleteCode == 0)
                        {
                            // ------ ADD END 2012/07/24 Redmine#30393 ������ for ���쌟��--------<<<<
                            // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                            updrateList.Add(ConvertToImportRateWork(importRateWork, dictrate[importRateWarp], true));
                        }
                    }// ADD  2012/07/24  ������ Redmine#30393 for ���쌟��
                }
                #region DEL 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�
                // --------------- DEL START 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�-------->>>>
                //// --------------- ADD START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.49�̑Ή�-------->>>>
                //int total=0;
                //if (addrateList.Count > 0)
                //{
                //    foreach (CustRateGroupWork custRate in addrateList)
                //    {
                //        total = total + custRate.CustRateGrpCode;
                //    }
                //    if (total == -addrateList.Count)
                //    {
                //        addrateList = new ArrayList();
                //    }
                //}
                //// --------------- ADD END 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.49�̑Ή�--------<<<<
                // --------------- DEL END 2013/03/25 Redmine#35047 wangl2 for No.1841���Ӑ�C���|�[�g�̑Ή�--------<<<<
                #endregion
                ArrayList addUpdRateList = new ArrayList();
                if (addrateList.Count > 0)
                {
                    addUpdRateList.AddRange(addrateList.GetRange(0, addrateList.Count));
                }
                if (updrateList.Count > 0)
                {
                    addUpdRateList.AddRange(updrateList.GetRange(0, updrateList.Count));
                }
                if (addUpdRateList.Count > 0)
                {
                    Object objAddUppRateList = addUpdRateList;
                    int status = custRateGroupDB.Write(ref objAddUppRateList);
                }
            }
        }
        # region �`�F�b�N

        # region ���b�Z�[�W

        //private const string FORMAT_ERRMSG_LEN = "{0}��{1}���ȓ��œ��͂��Ă��������B";// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.30�̑Ή�
        private const string FORMAT_ERRMSG_LEN = "{0}��{1}���ȓ��œ��͂��Ă��������B";// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.30�̑Ή�

        //private const string FORMAT_ERRMSG_TYPE = "{0}��{1}����͂��Ă��������B";// DEL  2012/07/05  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.30�̑Ή�
        private const string FORMAT_ERRMSG_TYPE = "{0}��{1}����͂��Ă��������B";// ADD  2012/07/05  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.30�̑Ή�

        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}����͂��Ă��������B";

        private const string FORMAT_ERRMSG_ERRORVAL = "{0}���s���ł��B";

        //private const string FORMAT_ERRMSG = "���Ӑ�|���O���[�v(����ALL)����͂��܂����B";// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή� // DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
        private const string FORMAT_ERRMSG = "���Ӑ�|���O���[�v(����ALL)��ݒ肵���ꍇ�A���Ӑ�|���O���[�v�P�`�Q�T�͐ݒ�ł��܂���B";// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�

        //private const string ERRMSG_DUPLICATE = "�d���f�[�^���Ă��邽�ߓo�^�ł��܂���B";// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή� DEL  2012/07/24  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�
        private const string ERRMSG_DUPLICATE = "�d���f�[�^�����邽�ߓo�^�ł��܂���B";//ADD  2012/07/24  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.106�̑Ή�

        # endregion

        # region ����

        /// <summary>
        /// �����A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_IntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([-0-9]{1,})$") && val.Trim() != "-")
            {
                string regexStrLen = @"^([-0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���l");// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                return false;
            }
        }
        /// <summary>
        /// �����A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_CorIntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))
            {
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���l");// DEL  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "������"); // ADD  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                return false;
            }
        }
        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�-------->>>>
        /// <summary>
        /// �������A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_IntAndLenth(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))
            {
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");
                return false;
            }
        }
        // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�--------<<<<

        /// <summary>
        /// �������A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_ZeroIntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))
            {
                // --------------- DEL START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.51�̑Ή�-------->>>>
                //if (Convert.ToInt32(val.Trim()) == 0)
                //{
                //    msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                //    return false;
                //}
                // --------------- DEL END 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.51�̑Ή�--------<<<<
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                // --------------- ADD START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.51�̑Ή�-------->>>>
                if (Convert.ToInt32(val.Trim()) == 0)
                {
                    msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                    return false;
                }
                // --------------- ADD END 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.51�̑Ή�--------<<<<
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���l");// DEL  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "������");// ADD  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                return false;
            }
        }
        /// <summary>
        /// �������A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_ZerIntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            //if (Regex.IsMatch(val, @"^([0-9]{1,})$") && Convert.ToInt32(val.Trim()) != 0)// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.51�̑Ή�
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.51�̑Ή�
            {
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                // ------ DEL START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�-------->>>>
                // --------------- ADD START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.51�̑Ή�-------->>>>
                //if (Convert.ToInt32(val.Trim()) == 0)
                //{
                //    //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "������");// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //    //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�  // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //    msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //    return false;
                //}
                // --------------- ADD END 2012/07/09 Redmine#30393 ������  for ��Q�ꗗ�̎w�ENO.51�̑Ή�--------<<<<
                // ------ DEL END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�--------<<<<
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���l");// DEL  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "������");// ADD  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή� // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                return false;
            }
        }
        /// <summary>
        /// NULL���f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �������w�肵�Ȃ��̕�����`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            if (val.Trim().Length > len)
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, len);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���p�p�����A���p�J�^�J�i�̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //���p
            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                if (Regex.IsMatch(val, "[0-9a-zA-Z\uff70-\uff9d\uff9e\uff9f\uff67-\uff6f]{1,}"))
                {
                    if (val.Length > len)
                    {
                        msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, len.ToString());
                        return false;
                    }
                    return true;
                }
                else
                {
                    msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���p�p�����A���p�J�^�J�i");
                    return false;
                }
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���p�p�����A���p�J�^�J�i");
                return false;
            }
        }
        /// <summary>
        /// ���p�����̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_HalfNumFixedLength(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            //���p
            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                if (Regex.IsMatch(val, @"^([-0-9]{1,})$") && val.Trim() != "-")
                {
                    string regexStrLen = @"^([-0-9]{1," + numLen.ToString() + "})$";
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                        return false;
                    }
                    return true;
                }
                else
                {
                    //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���l");// DEL  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                    msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/09  ������ Redmine#30393  for ��Q�ꗗ�̎w�ENO.39�̑Ή�
                    return false;
                }
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���p����");
                return false;

            }
        }
        /// <summary>
        /// �����`�F�b�N(20120201)
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        private bool Check_YYYYMMDD(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            try
            {
                if (Convert.ToInt32(val) != 0)
                {
                    DateTime dt = DateTime.ParseExact(val, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }

            return true;
        }

        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// �G���[���O�e�[�u��
        ///// </summary>
        ///// <param name="dataTable">�e�[�u��</param>
        //private void CreateDataTable(ref DataTable dataTable)
        //{
        //    dataTable.Columns.Add("CustomerCodeRF", typeof(string));           //  ���Ӑ�R�[�h
        //    dataTable.Columns.Add("CustomerSubCodeRF", typeof(string));	      //  ���Ӑ�T�u�R�[�h
        //    dataTable.Columns.Add("NameRF", typeof(string));	              //  ����
        //    dataTable.Columns.Add("Name2RF", typeof(string));	              //  ����2
        //    dataTable.Columns.Add("CustomerSnmRF", typeof(string));	          //  ���Ӑ旪��
        //    dataTable.Columns.Add("KanaRF", typeof(string));	              //  �J�i
        //    dataTable.Columns.Add("HonorificTitleRF", typeof(string));	      //  �h��
        //    dataTable.Columns.Add("OutputNameCodeRF", typeof(string));	      //  �����R�[�h
        //    dataTable.Columns.Add("MngSectionCodeRF", typeof(string));	      //  �Ǘ����_�R�[�h
        //    dataTable.Columns.Add("CustomerAgentCdRF", typeof(string));	      //  �ڋq�S���]�ƈ��R�[�h

        //    dataTable.Columns.Add("OldCustomerAgentCdRF", typeof(string));	  //  ���ڋq�S���]�ƈ��R�[�h
        //    dataTable.Columns.Add("CustAgentChgDateRF", typeof(string));       //  �ڋq�S���ύX��
        //    dataTable.Columns.Add("TransStopDateRF", typeof(string));	      //  ������~��	
        //    dataTable.Columns.Add("CarMngDivCdRF", typeof(string));	          //  ���q�Ǘ��敪
        //    dataTable.Columns.Add("CorporateDivCodeRF", typeof(string));       //  �l�E�@�l�敪
        //    dataTable.Columns.Add("AcceptWholeSaleRF", typeof(string));	      //  �Ɣ̐�敪
        //    dataTable.Columns.Add("CustomerAttributeDivRF", typeof(string));	  //  ���Ӑ摮���敪
        //    dataTable.Columns.Add("CustWarehouseCdRF", typeof(string));	      //  ���Ӑ�D��q�ɃR�[�h
        //    dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));       //  �Ǝ�R�[�h
        //    dataTable.Columns.Add("JobTypeCodeRF", typeof(string));	          //  �E��R�[�h

        //    dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	      //  �̔��G���A�R�[�h
        //    dataTable.Columns.Add("CustAnalysCode1RF", typeof(string));        //  ���Ӑ敪�̓R�[�h1
        //    dataTable.Columns.Add("CustAnalysCode2RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h2
        //    dataTable.Columns.Add("CustAnalysCode3RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h3
        //    dataTable.Columns.Add("CustAnalysCode4RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h4
        //    dataTable.Columns.Add("CustAnalysCode5RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h5
        //    dataTable.Columns.Add("CustAnalysCode6RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h6
        //    dataTable.Columns.Add("ClaimSectionCodeRF", typeof(string));	  //  �������_�R�[�h
        //    dataTable.Columns.Add("ClaimCodeRF", typeof(string));              //  ������R�[�h
        //    dataTable.Columns.Add("TotalDayRF", typeof(string));	              //  ����

        //    dataTable.Columns.Add("CollectMoneyCodeRF", typeof(string));	      //  �W�����敪�R�[�h
        //    dataTable.Columns.Add("CollectMoneyDayRF", typeof(string));	      //  �W����
        //    dataTable.Columns.Add("CollectCondRF", typeof(string));	          //  �������
        //    dataTable.Columns.Add("CollectSightRF", typeof(string));	          //  ����T�C�g
        //    dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));        //  ���񊨒�J�n��
        //    dataTable.Columns.Add("BillCollecterCdRF", typeof(string));	      //  �W���S���]�ƈ��R�[�h
        //    dataTable.Columns.Add("CustCTaXLayRefCdRF", typeof(string));	      //  ���Ӑ����œ]�ŕ����Q�Ƌ敪
        //    dataTable.Columns.Add("ConsTaxLayMethodRF", typeof(string));	      //  ����œ]�ŕ���
        //    dataTable.Columns.Add("SalesUnPrcFrcProcCdRF", typeof(string));	  //  ����P���[�������R�[�h
        //    dataTable.Columns.Add("SalesMoneyFrcProcCdRF", typeof(string));	  //  ������z�[�������R�[�h

        //    dataTable.Columns.Add("SalesCnsTaxFrcProcCdRF", typeof(string));   //  �������Œ[�������R�[�h
        //    dataTable.Columns.Add("CreditMngCodeRF", typeof(string));	      //  �^�M�Ǘ��敪 
        //    dataTable.Columns.Add("DepoDelCodeRF", typeof(string));	          //  ���������敪
        //    dataTable.Columns.Add("AccRecDivCdRF", typeof(string));	          //  ���|�敪
        //    dataTable.Columns.Add("PostNoRF", typeof(string));	              //  �X�֔ԍ�
        //    dataTable.Columns.Add("Address1RF", typeof(string));	          //  �Z��1�i�s���{���s��S�E�����E���j
        //    dataTable.Columns.Add("Address3RF", typeof(string));	          //  �Z��3�i�Ԓn�j
        //    dataTable.Columns.Add("Address4RF", typeof(string));	          //  �Z��4�i�A�p�[�g���́j
        //    dataTable.Columns.Add("CustomerAgentRF", typeof(string));         //  ���Ӑ�S����

        //    dataTable.Columns.Add("HomeTelNoRF", typeof(string));             //  �d�b�ԍ��i����j
        //    dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	          //  �d�b�ԍ��i�Ζ���j
        //    dataTable.Columns.Add("PortableTelNoRF", typeof(string));	      //  �d�b�ԍ��i�g�сj
        //    dataTable.Columns.Add("OthersTelNoRF", typeof(string));	          //  �d�b�ԍ��i���̑��j
        //    dataTable.Columns.Add("HomeFaxNoRF", typeof(string));	          //  FAX�ԍ��i����j
        //    dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	          //  FAX�ԍ��i�Ζ���j

        //    dataTable.Columns.Add("SearchTelNoRF", typeof(string));	          //  �d�b�ԍ��i�����p��4���j
        //    dataTable.Columns.Add("MainContactCodeRF", typeof(string));	      //  ��A����敪
        //    dataTable.Columns.Add("Note1RF", typeof(string));	              //  ���l�P
        //    dataTable.Columns.Add("Note2RF", typeof(string));	              //  ���l�Q
        //    dataTable.Columns.Add("Note3RF", typeof(string));	              //  ���l�R

        //    dataTable.Columns.Add("Note4RF", typeof(string));	              //  ���l�S
        //    dataTable.Columns.Add("Note5RF", typeof(string));	              //  ���l�T 
        //    dataTable.Columns.Add("Note6RF", typeof(string));	              //  ���l�U
        //    dataTable.Columns.Add("Note7RF", typeof(string));	              //  ���l�V
        //    dataTable.Columns.Add("Note8RF", typeof(string));	              //  ���l�W
        //    dataTable.Columns.Add("Note9RF", typeof(string));	              //  ���l�X
        //    dataTable.Columns.Add("Note10RF", typeof(string));	              // ���l�P�O
        //    dataTable.Columns.Add("MainSendMailAddrCdRF", typeof(string));	  //  �呗�M�惁�[���A�h���X�敪
        //    dataTable.Columns.Add("MailAddress1RF", typeof(string));	      //  ���[���A�h���X1	
        //    dataTable.Columns.Add("MailSendCode1RF", typeof(string));	      //  ���[�����M�敪�R�[�h1

        //    dataTable.Columns.Add("MailAddrKindCode1RF", typeof(string));	  //  ���[���A�h���X��ʃR�[�h1
        //    dataTable.Columns.Add("MailAddress2RF", typeof(string));	      // ���[���A�h���X�Q 
        //    dataTable.Columns.Add("MailSendCode2RF", typeof(string));	      //  ���[�����M�敪�R�[�h�Q
        //    dataTable.Columns.Add("MailAddrKindCode2RF", typeof(string));	  //  ���[���A�h���X��ʃR�[�h�Q
        //    dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	      //  ��s�����P
        //    dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	      //  ��s�����Q
        //    dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	      //  ��s�����R
        //    dataTable.Columns.Add("ReceiptOutputCodeRF", typeof(string));	  // �̎����o�͋敪�R�[�h
        //    dataTable.Columns.Add("DmOutCodeRF", typeof(string));	          //  DM�o�͋敪

        //    dataTable.Columns.Add("SalesSlipPrtDivRF", typeof(string));	      //  ����`�[���s�敪
        //    dataTable.Columns.Add("AcpOdrrSlipPrtDivRF", typeof(string));	  //  �󒍓`�[���s�敪
        //    dataTable.Columns.Add("ShipmSlipPrtDivRF", typeof(string));	      //  �o�ד`�[���s�敪
        //    dataTable.Columns.Add("EstimatePrtDivRF", typeof(string));	      //  ���Ϗ����s�敪	
        //    dataTable.Columns.Add("UOESlipPrtDivRF", typeof(string));	      // UOE�`�[���s�敪	
        //    dataTable.Columns.Add("QrcodePrtCdRF", typeof(string));	          //  QR�R�[�h���
        //    dataTable.Columns.Add("CustSlipNoMngCdRF", typeof(string));	      //  ����`�[�ԍ��Ǘ��敪
        //    dataTable.Columns.Add("CustomerSlipNoDivRF", typeof(string));	  //  ���Ӑ�`�[�ԍ��敪

        //    dataTable.Columns.Add("TotalBillOutputDivRF", typeof(string));      // ���v�������o�͋敪
        //    dataTable.Columns.Add("DetailBillOutputCodeRF", typeof(string));    // ���א������o�͋敪
        //    dataTable.Columns.Add("SlipTtlBillOutputDivRF", typeof(string));    // �`�[���v�������o�͋敪

        //    dataTable.Columns.Add("CustRateGrpFine", typeof(string));          //���Ӑ�|���O���[�v(�D��)
        //    dataTable.Columns.Add("CustRateGrpPureAll", typeof(string));       //���Ӑ�|���O���[�v(����ALL)
        //    dataTable.Columns.Add("CustRateGrpPure1", typeof(string));         //���Ӑ�|���O���[�v�����P
        //    dataTable.Columns.Add("CustRateGrpPure2", typeof(string));         //���Ӑ�|���O���[�v����2
        //    dataTable.Columns.Add("CustRateGrpPure3", typeof(string));         //���Ӑ�|���O���[�v����3
        //    dataTable.Columns.Add("CustRateGrpPure4", typeof(string));         //���Ӑ�|���O���[�v����4
        //    dataTable.Columns.Add("CustRateGrpPure5", typeof(string));         //���Ӑ�|���O���[�v����5
        //    dataTable.Columns.Add("CustRateGrpPure6", typeof(string));         //���Ӑ�|���O���[�v����6
        //    dataTable.Columns.Add("CustRateGrpPure7", typeof(string));         //���Ӑ�|���O���[�v����7
        //    dataTable.Columns.Add("CustRateGrpPure8", typeof(string));         //���Ӑ�|���O���[�v����8
        //    dataTable.Columns.Add("CustRateGrpPure9", typeof(string));         //���Ӑ�|���O���[�v����9
        //    dataTable.Columns.Add("CustRateGrpPure10", typeof(string));        //���Ӑ�|���O���[�v�����P0
        //    dataTable.Columns.Add("CustRateGrpPure11", typeof(string));        //���Ӑ�|���O���[�v�����P1
        //    dataTable.Columns.Add("CustRateGrpPure12", typeof(string));        //���Ӑ�|���O���[�v�����P2
        //    dataTable.Columns.Add("CustRateGrpPure13", typeof(string));        //���Ӑ�|���O���[�v�����P3
        //    dataTable.Columns.Add("CustRateGrpPure14", typeof(string));        //���Ӑ�|���O���[�v�����P4
        //    dataTable.Columns.Add("CustRateGrpPure15", typeof(string));        //���Ӑ�|���O���[�v�����P5
        //    dataTable.Columns.Add("CustRateGrpPure16", typeof(string));        //���Ӑ�|���O���[�v�����P6
        //    dataTable.Columns.Add("CustRateGrpPure17", typeof(string));        //���Ӑ�|���O���[�v�����P7
        //    dataTable.Columns.Add("CustRateGrpPure18", typeof(string));        //���Ӑ�|���O���[�v�����P8
        //    dataTable.Columns.Add("CustRateGrpPure19", typeof(string));        //���Ӑ�|���O���[�v�����P9
        //    dataTable.Columns.Add("CustRateGrpPure20", typeof(string));        //���Ӑ�|���O���[�v����20
        //    dataTable.Columns.Add("CustRateGrpPure21", typeof(string));        //���Ӑ�|���O���[�v����21
        //    dataTable.Columns.Add("CustRateGrpPure22", typeof(string));        //���Ӑ�|���O���[�v����22
        //    dataTable.Columns.Add("CustRateGrpPure23", typeof(string));        //���Ӑ�|���O���[�v����23
        //    dataTable.Columns.Add("CustRateGrpPure24", typeof(string));        //���Ӑ�|���O���[�v����24
        //    dataTable.Columns.Add("CustRateGrpPure25", typeof(string));        //���Ӑ�|���O���[�v����25
        //    dataTable.Columns.Add("ErrorLog", typeof(string));                 //�G���[���e
        //}
        ///// <summary>
        ///// �f�[�^�̌���
        ///// </summary>
        ///// <param name="customerGroupWork">CSV�t�@�C���̍s</param>// ADD  2012/07/03  ������ Redmine#30393
        ///// <param name="work">CustomerWork</param>
        ///// <param name="logArrayList">���O���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        ///// <param name="enterpriseCode"> ��ƃR�[�h</param>
        ///// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        ///// <param name="searchWork">���������I�u�W�F�N�g</param>
        //private void CheckData(DataRow csvRow, ref CustomerRateWork work, ref DataTable logTable, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)
        //{

        //    string msg = string.Empty;
        //    int mark = 1;
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("�T�u�R�[�h", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ於�P", csvRow[mark++].ToString(), 30, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ於�Q", csvRow[mark++].ToString(), 30, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ旪��", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("���Ӑ於�J�i", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_HalfEngNumFixedLength("���Ӑ於�J�i", csvRow[mark++].ToString(), 30, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("�h��", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("����", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("����", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�Ǘ����_", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("�Ǘ����_", csvRow[mark++].ToString(), 2, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���Ӑ�S��", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���S��", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_YYYYMMDD("�S���ҕύX��", csvRow[mark].ToString(), out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }

        //        if (!Check_StrUnFixedLen("�S���ҕύX��", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_YYYYMMDD("������~��", csvRow[mark].ToString(), out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //        if (!Check_StrUnFixedLen("������~��", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("���q�Ǘ�", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���q�Ǘ�", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�l�E�@�l", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�l�E�@�l", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���Ӑ���", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���Ӑ���", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }

        //    if (!Check_IsNull("���Ӑ摮��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���Ӑ摮��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�D��q��", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�Ǝ�", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�E��", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�n��", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���̓R�[�h�P", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���̓R�[�h�Q", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���̓R�[�h�R", csvRow[mark++].ToString(), 3, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���̓R�[�h�S", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���̓R�[�h�T", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���̓R�[�h�U", csvRow[mark++].ToString(), 3, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("�������_", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("�������_", csvRow[mark++].ToString(), 2, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�����R�[�h", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("�����R�[�h", csvRow[mark++].ToString(), 8, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("����", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("����", csvRow[mark++].ToString(), 2, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�W����", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�W����", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�W����", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("�W����", csvRow[mark++].ToString(), 2, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�������", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZerIntAndLen("�������", csvRow[mark++].ToString(), 2, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("����T�C�g", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���񊨒�", csvRow[mark++].ToString(), 2, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�W���S��", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("�]�ŕ����Q�Ƌ敪", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�]�ŕ����Q�Ƌ敪", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("����œ]�ŕ���", csvRow[mark++].ToString(), 1, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�P���[������", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("���z�[������", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("����Œ[������", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("�^�M�Ǘ�", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�^�M�Ǘ�", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("��������", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("��������", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���|�敪", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���|�敪", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("�X�֔ԍ�", csvRow[mark++].ToString(), 10, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("�Z��", csvRow[mark++].ToString(), 30, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("�Z���Q", csvRow[mark++].ToString(), 22, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("�Z���R", csvRow[mark++].ToString(), 30, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ�S����", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("����s�d�k", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("�Ζ���d�b�P", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("�Ζ���d�b�Q", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("���̑��d�b", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("����e�`�w", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("�Ζ���e�`�w", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("�����ԍ�", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("��A����", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("��A����", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�P", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�Q", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�R", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�S", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�T", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�U", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�V", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�W", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�X", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���Ӑ���l�P�O", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("�呗�M�惁�[���A�h���X�敪", csvRow[mark++].ToString(), 1, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���[���A�h���X�P", csvRow[mark++].ToString(), 64, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("���[�����M�敪�R�[�h�P", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���[�����M�敪�R�[�h�P", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���[���A�h���X��ʃR�[�h�P", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�P", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("���[���A�h���X�Q", csvRow[mark++].ToString(), 64, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("���[�����M�敪�R�[�h�Q", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���[�����M�敪�R�[�h�Q", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���[���A�h���X��ʃR�[�h�Q", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�Q", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("��s�����P", csvRow[mark++].ToString(), 60, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("��s�����Q", csvRow[mark++].ToString(), 60, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("��s�����R", csvRow[mark++].ToString(), 60, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("�̎����o��", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�̎����o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�c�l�o��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�c�l�o��", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�[�i���o��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�[�i���o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�󒍓`�[�o��", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�󒍓`�[�o��", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�ݏo�`�[�o��", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�ݏo�`�[�o��", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���ϓ`�[�o��", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���ϓ`�[�o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�t�n�d�`�[�o��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�t�n�d�`�[�o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�p�q�R�[�h���", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�p�q�R�[�h���", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }

        //    if (!Check_IsNull("����`�[�ԍ��Ǘ�", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("����`�[�ԍ��Ǘ�", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("����`�[�ԍ��敪", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("����`�[�ԍ��敪", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���v�������o��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���v�������o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("���א������o��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("���א������o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("�`�[���v�������o��", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("�`�[���v�������o��", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v(�D��)", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v(����ALL)", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����R", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����S", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����T", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����U", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����V", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����W", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����X", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�O", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�P", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�Q", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�R", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�S", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�T", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�U", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�V", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�W", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�X", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�O", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�P", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�Q", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�R", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�S", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString()))
        //    {
        //        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�T", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    int index = 0;
        //    if (isUpdFlg)
        //    {
        //        // �X�V�̏ꍇ
        //        work.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
        //        work.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
        //        work.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
        //        work.LogicalDeleteCode = 0;                                   // �_���폜�敪
        //        work.PureCode = searchWork.PureCode;                          // �����敪
        //        work.TotalAmountDispWayCd = searchWork.TotalAmountDispWayCd;  // ���z�\�����@�敪
        //        work.TotalAmntDspWayRef = searchWork.TotalAmntDspWayRef;      // ���z�\�����@�Q�Ƌ敪
        //        work.BillPartsNoPrtCd = searchWork.BillPartsNoPrtCd;          // �i�Ԉ󎚋敪(������)
        //        work.DeliPartsNoPrtCd = searchWork.DeliPartsNoPrtCd;          // �i�Ԉ󎚋敪(�[�i���j
        //        work.DefSalesSlipCd = searchWork.DefSalesSlipCd;              // �`�[�敪�����l
        //        work.LavorRateRank = searchWork.LavorRateRank;                // �H�����o���[�g�����N
        //        work.SlipTtlPrn = searchWork.SlipTtlPrn;                      // �`�[�^�C�g���p�^�[��
        //        work.DepoBankCode = searchWork.DepoBankCode;                  // ������s�R�[�h
        //        work.DeliHonorificTtl = searchWork.DeliHonorificTtl;          // �[�i���h��
        //        work.BillHonorificTtl = searchWork.BillHonorificTtl;          // �������h��
        //        work.EstmHonorificTtl = searchWork.EstmHonorificTtl;          // ���Ϗ��h��
        //        work.RectHonorificTtl = searchWork.RectHonorificTtl;          // �̎����h��
        //        work.DeliHonorTtlPrtDiv = searchWork.DeliHonorTtlPrtDiv;      // �[�i���h�̈󎚋敪
        //        work.BillHonorTtlPrtDiv = searchWork.BillHonorTtlPrtDiv;      // �������h�̈󎚋敪
        //        work.EstmHonorTtlPrtDiv = searchWork.EstmHonorTtlPrtDiv;      // ���Ϗ��h�̈󎚋敪
        //        work.RectHonorTtlPrtDiv = searchWork.RectHonorTtlPrtDiv;      // �̎����h�̈󎚋敪
        //        work.CustomerEpCode = searchWork.CustomerEpCode;              // ���Ӑ��ƃR�[�h
        //        work.CustomerSecCode = searchWork.CustomerSecCode;            // ���Ӑ拒�_�R�[�h
        //        work.OnlineKindDiv = searchWork.OnlineKindDiv;                // �I�����C����ʋ敪
        //    }
        //    else
        //    {
        //        // �V�K�̏ꍇ
        //        work.PureCode = 0;                                            // �����敪
        //        work.TotalAmountDispWayCd = 0;                                // ���z�\�����@�敪
        //        work.TotalAmntDspWayRef = 0;                                  // ���z�\�����@�Q�Ƌ敪
        //        work.BillPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(������)
        //        work.DeliPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(�[�i���j
        //        work.DefSalesSlipCd = 0;                                      // �`�[�敪�����l
        //        work.LavorRateRank = 0;                                       // �H�����o���[�g�����N
        //        work.SlipTtlPrn = 0;                                          // �`�[�^�C�g���p�^�[��
        //        work.DepoBankCode = 0;                                        // ������s�R�[�h
        //        work.DeliHonorificTtl = string.Empty;                         // �[�i���h��
        //        work.BillHonorificTtl = string.Empty;                         // �������h��
        //        work.EstmHonorificTtl = string.Empty;                         // ���Ϗ��h��
        //        work.RectHonorificTtl = string.Empty;                         // �̎����h��
        //        work.DeliHonorTtlPrtDiv = 0;                                  // �[�i���h�̈󎚋敪
        //        work.BillHonorTtlPrtDiv = 0;                                  // �������h�̈󎚋敪
        //        work.EstmHonorTtlPrtDiv = 0;                                  // ���Ϗ��h�̈󎚋敪
        //        work.RectHonorTtlPrtDiv = 0;                                  // �̎����h�̈󎚋敪
        //        work.CustomerEpCode = string.Empty;                           // ���Ӑ��ƃR�[�h
        //        work.CustomerSecCode = string.Empty;                          // ���Ӑ拒�_�R�[�h
        //        work.OnlineKindDiv = 0;                                       // �I�����C����ʋ敪

        //    }
        //    work.EnterpriseCode = enterpriseCode;
        //    work.CustomerCode = ConvertToInt32(csvRow, index++);            // ���Ӑ�R�[�h
        //    work.CustomerSubCode = ConvertToEmpty(csvRow, index++);         // �T�u�R�[�h
        //    work.Name = ConvertToEmpty(csvRow, index++);                    // ���Ӑ於�P
        //    work.Name2 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ於�Q
        //    work.CustomerSnm = ConvertToEmpty(csvRow, index++);             // ���Ӑ旪��
        //    work.Kana = ConvertToEmpty(csvRow, index++);                    // ���Ӑ於�J�i
        //    work.HonorificTitle = ConvertToEmpty(csvRow, index++);          // �h��
        //    work.OutputNameCode = ConvertToInt32(csvRow, index++);          // ����
        //    work.MngSectionCode = ConvertToStrCode(csvRow, index++, 2);     // �Ǘ����_
        //    work.CustomerAgentCd = ConvertToStrCode(csvRow, index++, 4);    // ���Ӑ�S��
        //    work.OldCustomerAgentCd = ConvertToStrCode(csvRow, index++, 4); // ���S��
        //    work.CustAgentChgDate = ConvertToDateTime(csvRow, index++);     // �S���ҕύX��
        //    work.TransStopDate = ConvertToDateTime(csvRow, index++);        // ������~��
        //    work.CarMngDivCd = ConvertToInt32(csvRow, index++);             // ���p�Ǘ�
        //    work.CorporateDivCode = ConvertToInt32(csvRow, index++);        // �l�E�@�l
        //    work.AcceptWholeSale = ConvertToInt32(csvRow, index++);         // ���Ӑ���
        //    work.CustomerAttributeDiv = ConvertToInt32(csvRow, index++);    // ���Ӑ摮��
        //    work.CustWarehouseCd = ConvertToStrCode(csvRow, index++, 4);    // �D��q��
        //    work.BusinessTypeCode = ConvertToInt32(csvRow, index++);        // �Ǝ�
        //    work.JobTypeCode = ConvertToInt32(csvRow, index++);             // �E��
        //    work.SalesAreaCode = ConvertToInt32(csvRow, index++);           // �n��
        //    work.CustAnalysCode1 = ConvertToInt32(csvRow, index++);         // ���̓R�[�h�P
        //    work.CustAnalysCode2 = ConvertToInt32(csvRow, index++);         // ���̓R�[�h�Q
        //    work.CustAnalysCode3 = ConvertToInt32(csvRow, index++);         // ���̓R�[�h�R
        //    work.CustAnalysCode4 = ConvertToInt32(csvRow, index++);         // ���̓R�[�h�S
        //    work.CustAnalysCode5 = ConvertToInt32(csvRow, index++);         // ���̓R�[�h�T
        //    work.CustAnalysCode6 = ConvertToInt32(csvRow, index++);         // ���̓R�[�h�U
        //    work.ClaimSectionCode = ConvertToStrCode(csvRow, index++, 2);   // �������_
        //    work.ClaimCode = ConvertToInt32(csvRow, index++);               // �����R�[�h
        //    work.TotalDay = ConvertToInt32(csvRow, index++);                // ����
        //    work.CollectMoneyCode = ConvertToInt32(csvRow, index++);        // �W����
        //    work.CollectMoneyDay = ConvertToInt32(csvRow, index++);         // �W����
        //    work.CollectCond = ConvertToInt32(csvRow, index++);             // �������
        //    work.CollectSight = ConvertToInt32(csvRow, index++);            // ����T�C�g
        //    work.NTimeCalcStDate = ConvertToInt32(csvRow, index++);         // ���񊨒�
        //    work.BillCollecterCd = ConvertToStrCode(csvRow, index++, 4);    // �W���S��
        //    work.CustCTaXLayRefCd = ConvertToInt32(csvRow, index++);        // �]�ŕ����Q�Ƌ敪
        //    work.ConsTaxLayMethod = ConvertToInt32(csvRow, index++);        // ����œ]�ŕ���
        //    work.SalesUnPrcFrcProcCd = ConvertToInt32(csvRow, index++);     // �P���[������
        //    work.SalesMoneyFrcProcCd = ConvertToInt32(csvRow, index++);     // ���z�[������
        //    work.SalesCnsTaxFrcProcCd = ConvertToInt32(csvRow, index++);    // ����Œ[������
        //    work.CreditMngCode = ConvertToInt32(csvRow, index++);           // �^�M�Ǘ�
        //    work.DepoDelCode = ConvertToInt32(csvRow, index++);             // ��������
        //    work.AccRecDivCd = ConvertToInt32(csvRow, index++);             // ���|�敪
        //    work.PostNo = ConvertToEmpty(csvRow, index++);                  // �X�֔ԍ�
        //    work.Address1 = ConvertToEmpty(csvRow, index++);                // �Z��
        //    work.Address3 = ConvertToEmpty(csvRow, index++);                // �Z���Q
        //    work.Address4 = ConvertToEmpty(csvRow, index++);                // �Z���R
        //    work.CustomerAgent = ConvertToEmpty(csvRow, index++);           // ���Ӑ�S����
        //    work.HomeTelNo = ConvertToEmpty(csvRow, index++);               // ����s�d�k
        //    work.OfficeTelNo = ConvertToEmpty(csvRow, index++);             // �Ζ���d�b�P
        //    work.PortableTelNo = ConvertToEmpty(csvRow, index++);           // �Ζ���d�b�Q
        //    work.OthersTelNo = ConvertToEmpty(csvRow, index++);             // ���̑��d�b
        //    work.HomeFaxNo = ConvertToEmpty(csvRow, index++);               // ����e�`�w
        //    work.OfficeFaxNo = ConvertToEmpty(csvRow, index++);             // �Ζ���e�`�w
        //    work.SearchTelNo = ConvertToEmpty(csvRow, index++);             // �����ԍ�
        //    work.MainContactCode = ConvertToInt32(csvRow, index++);         // ��A����
        //    work.Note1 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�P
        //    work.Note2 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�Q
        //    work.Note3 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�R
        //    work.Note4 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�S
        //    work.Note5 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�T
        //    work.Note6 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�U
        //    work.Note7 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�V
        //    work.Note8 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�W
        //    work.Note9 = ConvertToEmpty(csvRow, index++);                   // ���Ӑ���l�X
        //    work.Note10 = ConvertToEmpty(csvRow, index++);                  // ���Ӑ���l�P�O
        //    work.MainSendMailAddrCd = ConvertToInt32(csvRow, index++);      // �呗�M�惁�[���A�h���X�敪
        //    work.MailAddress1 = ConvertToEmpty(csvRow, index++);            // ���[���A�h���X�P
        //    work.MailSendCode1 = ConvertToInt32(csvRow, index++);           // ���[�����M�敪�R�[�h�P
        //    work.MailAddrKindCode1 = ConvertToInt32(csvRow, index++);       // ���[���A�h���X��ʃR�[�h�P
        //    work.MailAddress2 = ConvertToEmpty(csvRow, index++);            // ���[���A�h���X�Q
        //    work.MailSendCode2 = ConvertToInt32(csvRow, index++);           // ���[�����M�敪�R�[�h�Q
        //    work.MailAddrKindCode2 = ConvertToInt32(csvRow, index++);       // ���[���A�h���X��ʃR�[�h�Q
        //    work.AccountNoInfo1 = ConvertToEmpty(csvRow, index++);          // ��s�����P
        //    work.AccountNoInfo2 = ConvertToEmpty(csvRow, index++);          // ��s�����Q
        //    work.AccountNoInfo3 = ConvertToEmpty(csvRow, index++);          // ��s�����R
        //    work.ReceiptOutputCode = ConvertToInt32(csvRow, index++);       // �̎����o��
        //    work.DmOutCode = ConvertToInt32(csvRow, index++);               // �c�l�o��
        //    work.SalesSlipPrtDiv = ConvertToInt32(csvRow, index++);         // �[�i���o��
        //    work.AcpOdrrSlipPrtDiv = ConvertToInt32(csvRow, index++);       // �󒍓`�[�o��
        //    work.ShipmSlipPrtDiv = ConvertToInt32(csvRow, index++);         // �ݏo�`�[�o��
        //    work.EstimatePrtDiv = ConvertToInt32(csvRow, index++);          // ���ϓ`�[�o��
        //    work.UOESlipPrtDiv = ConvertToInt32(csvRow, index++);           // �t�n�d�`�[�o��
        //    work.QrcodePrtCd = ConvertToInt32(csvRow, index++);             // �p�q�R�[�h���
        //    work.CustSlipNoMngCd = ConvertToInt32(csvRow, index++);         // ����`�[�ԍ��Ǘ�
        //    work.CustomerSlipNoDiv = ConvertToInt32(csvRow, index++);       // ����`�[�ԍ��敪

        //    work.TotalBillOutputDiv = ConvertToInt32(csvRow, index++);      // ���v�������o��
        //    work.DetailBillOutputCode = ConvertToInt32(csvRow, index++);    // ���א������o��
        //    work.SlipTtlBillOutputDiv = ConvertToInt32(csvRow, index++);    // �`�[���v�������o�͋敪

        //    work.CustRateGrpFine = ConvertRateToInt32(csvRow, index++);        //���Ӑ�|���O���[�v(�D��)
        //    work.CustRateGrpPureAll = ConvertRateToInt32(csvRow, index++);     //���Ӑ�|���O���[�v(����ALL)
        //    work.CustRateGrpPure1 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v�����P
        //    work.CustRateGrpPure2 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����2
        //    work.CustRateGrpPure3 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����3
        //    work.CustRateGrpPure4 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����4
        //    work.CustRateGrpPure5 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����5
        //    work.CustRateGrpPure6 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����6
        //    work.CustRateGrpPure7 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����7
        //    work.CustRateGrpPure8 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����8
        //    work.CustRateGrpPure9 = ConvertRateToInt32(csvRow, index++);       //���Ӑ�|���O���[�v����9
        //    work.CustRateGrpPure10 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P0
        //    work.CustRateGrpPure11 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P1
        //    work.CustRateGrpPure12 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P2
        //    work.CustRateGrpPure13 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P3
        //    work.CustRateGrpPure14 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P4
        //    work.CustRateGrpPure15 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P5
        //    work.CustRateGrpPure16 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P6
        //    work.CustRateGrpPure17 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P7
        //    work.CustRateGrpPure18 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P8
        //    work.CustRateGrpPure19 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v�����P9
        //    work.CustRateGrpPure20 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v����20
        //    work.CustRateGrpPure21 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v����2�P
        //    work.CustRateGrpPure22 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v����22
        //    work.CustRateGrpPure23 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v����23
        //    work.CustRateGrpPure24 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v����24
        //    work.CustRateGrpPure25 = ConvertRateToInt32(csvRow, index++);      //���Ӑ�|���O���[�v����25
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>

        /// <summary>
        /// �f�[�^�̌���
        /// </summary>
        /// <param name="customerGroupWork">CSV�t�@�C���̍s</param>
        /// <param name="checkDiv">�`�F�b�N�敪</param>
        /// <param name="consTaxLay">����œ]�ŕ���</param>
        /// <param name="importCustWorCheckList">�`�F�b�N���X�g</param>
        /// <param name="work">CustomerWork</param>
        /// <param name="logArrayList">���O���X�g</param>
        /// <param name="enterpriseCode"> ��ƃR�[�h</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/05 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�̑Ή�</br>
        /// <br>Update Note: 2012/07/09 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.39�ANO.46�ANO.47�ANO.48�ANO.49�ANO.51�̑Ή�</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.94�ANO.106�ANO.107�ANO.108�̑Ή�</br>
        /// <br>Update Note: 2012/07/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ���쌟�؁A��Q�ꗗ�̎w�ENO.61�ANO.106�̑Ή�</br>
        /// <br>Update Note: 2012/8/3 ���</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             ���[���A�h���X��ʃR�[�h�̃`�F�b�N�������P������Q���֕ύX</br>
        /// <br>Update Note: 2022/03/04 �c������</br>
        /// <br>�Ǘ��ԍ�   : 11570183-00 �d�q����A�g�Ή�</br>
        /// <br>             ���x�����ڂ̕ύX�iDM�o�́��d�q����o�́j</br>
        /// </remarks>
        //private void CheckData(CustomerGroupWork customerGroupWork, ref CustomerRateWork work, ref ArrayList logArrayList, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
        //private void CheckData(CustomerGroupWork customerGroupWork, Int32 consTaxLay, ref CustomerRateWork work, ref ArrayList logArrayList, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�  // DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        private void CheckData(CustomerGroupWork customerGroupWork, Int32 checkDiv, Int32 consTaxLay, List<CustomerGroupWork> importCustWorCheckList, ref CustomerRateWork work, ref ArrayList logArrayList, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
        {
            // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
            if (checkDiv == 0)
            {
                string msg = string.Empty;
                // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<

                // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.107�̑Ή�-------->>>>
                if (ConvertToInt32(customerGroupWork.AcceptWholeSale) == 1 || ConvertToInt32(customerGroupWork.AcceptWholeSale) == 2)//���Ӑ��ʂ�:�[����
                {

                    if (!Check_IsNull("���Ӑ�R�[�h", customerGroupWork.CustomerCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_ZeroIntAndLen("���Ӑ�R�[�h", customerGroupWork.CustomerCode, 8, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                      
                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSubCode.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�T�u�R�[�h", customerGroupWork.CustomerSubCode.Trim(), 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ於�P", customerGroupWork.Name, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ於�Q", customerGroupWork.Name2, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSnm.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ旪��", customerGroupWork.CustomerSnm, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Kana.Trim()))
                    {
                        if (!Check_HalfEngNumFixedLength("���Ӑ於�J�i", customerGroupWork.Kana, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HonorificTitle.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�h��", customerGroupWork.HonorificTitle, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OutputNameCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("����", customerGroupWork.OutputNameCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MngSectionCode.Trim()))
                    {
                        if (!Check_IntAndLenth("�Ǘ����_", customerGroupWork.MngSectionCode, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���Ӑ�S��", customerGroupWork.CustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OldCustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���S��", customerGroupWork.OldCustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAgentChgDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("�S���ҕύX��", customerGroupWork.CustAgentChgDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }

                        if (!Check_StrUnFixedLen("�S���ҕύX��", customerGroupWork.CustAgentChgDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TransStopDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("������~��", customerGroupWork.TransStopDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        if (!Check_StrUnFixedLen("������~��", customerGroupWork.TransStopDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CarMngDivCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���q�Ǘ�", customerGroupWork.CarMngDivCd, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CorporateDivCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�l�E�@�l", customerGroupWork.CorporateDivCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CorporateDivCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("���Ӑ���", customerGroupWork.CorporateDivCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAttributeDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("���Ӑ摮��", customerGroupWork.CustomerAttributeDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustWarehouseCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�D��q��", customerGroupWork.CustWarehouseCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BusinessTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�Ǝ�", customerGroupWork.BusinessTypeCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.JobTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�E��", customerGroupWork.JobTypeCode, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesAreaCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�n��", customerGroupWork.SalesAreaCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode1.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�P", customerGroupWork.CustAnalysCode1, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode2.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�Q", customerGroupWork.CustAnalysCode2, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode3.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�R", customerGroupWork.CustAnalysCode3, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode4.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�S", customerGroupWork.CustAnalysCode4, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode5.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�T", customerGroupWork.CustAnalysCode5, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode6.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�U", customerGroupWork.CustAnalysCode6, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ClaimSectionCode.Trim()))
                    {
                        if (!Check_IntAndLenth("�������_", customerGroupWork.ClaimSectionCode, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ClaimCode.Trim()))
                    {
                        if (!Check_IntAndLenth("�����R�[�h", customerGroupWork.ClaimCode, 8, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TotalDay.Trim()))
                    {
                        if (!Check_IntAndLenth("����", customerGroupWork.TotalDay, 2, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CollectMoneyCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�W����", customerGroupWork.CollectMoneyCode, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CollectMoneyDay.Trim()))
                    {
                        if (!Check_IntAndLenth("�W����", customerGroupWork.CollectMoneyDay, 2, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CollectCond.Trim()))
                    {
                        if (!Check_ZerIntAndLen("�������", customerGroupWork.CollectCond, 2, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CollectSight.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("����T�C�g", customerGroupWork.CollectSight, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.NTimeCalcStDate.Trim()))
                    {
                        if (!Check_CorIntAndLen("���񊨒�", customerGroupWork.NTimeCalcStDate, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BillCollecterCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�W���S��", customerGroupWork.BillCollecterCd, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustCTaXLayRefCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�]�ŕ����Q�Ƌ敪", customerGroupWork.CustCTaXLayRefCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ConsTaxLayMethod.Trim()))
                    {
                        if (!Check_CorIntAndLen("����œ]�ŕ���", customerGroupWork.ConsTaxLayMethod, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.SalesUnPrcFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�P���[������", customerGroupWork.SalesUnPrcFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesMoneyFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���z�[������", customerGroupWork.SalesMoneyFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesCnsTaxFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("����Œ[������", customerGroupWork.SalesCnsTaxFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CreditMngCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�^�M�Ǘ�", customerGroupWork.CreditMngCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.DepoDelCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("��������", customerGroupWork.DepoDelCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.AccRecDivCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���|�敪", customerGroupWork.AccRecDivCd, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.PostNo.Trim()))
                    {
                        if (!Check_IntAndLen("�X�֔ԍ�", customerGroupWork.PostNo, 10, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�Z��", customerGroupWork.Address1, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�Z���Q", customerGroupWork.Address3, 22, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�Z���R", customerGroupWork.Address4, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgent.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ�S����", customerGroupWork.CustomerAgent, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("����s�d�k", customerGroupWork.HomeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�Ζ���d�b�P", customerGroupWork.OfficeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.PortableTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�Ζ���d�b�Q", customerGroupWork.PortableTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OthersTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("���̑��d�b", customerGroupWork.OthersTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("����e�`�w", customerGroupWork.HomeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�Ζ���e�`�w", customerGroupWork.OfficeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SearchTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�����ԍ�", customerGroupWork.SearchTelNo, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MainContactCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("��A����", customerGroupWork.MainContactCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�P", customerGroupWork.Note1, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�Q", customerGroupWork.Note2, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�R", customerGroupWork.Note3, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�S", customerGroupWork.Note4, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note5.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�T", customerGroupWork.Note5, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note6.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�U", customerGroupWork.Note6, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note7.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�V", customerGroupWork.Note7, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note8.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�W", customerGroupWork.Note8, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note9.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�X", customerGroupWork.Note9, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note10.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�P�O", customerGroupWork.Note10, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MainSendMailAddrCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�呗�M�惁�[���A�h���X�敪", customerGroupWork.MainSendMailAddrCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���[���A�h���X�P", customerGroupWork.MailAddress1, 64, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailSendCode1.Trim()))
                    {
                        if (!Check_CorIntAndLen("���[�����M�敪�R�[�h�P", customerGroupWork.MailSendCode1, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddrKindCode1.Trim()))
                    {
                        //if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�P", customerGroupWork.MailAddrKindCode1, 1, out  msg)) // DEL BY ��� ON 2012/8/3 FOR �����`�F�b�N���P������Q���֕ύX
                        if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�P", customerGroupWork.MailAddrKindCode1, 2, out  msg)) // ADD BY ��� ON 2012/8/3 FOR �����`�F�b�N���P������Q���֕ύX
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���[���A�h���X�Q", customerGroupWork.MailAddress2, 64, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.MailSendCode2.Trim()))
                    {
                        if (!Check_CorIntAndLen("���[�����M�敪�R�[�h�Q", customerGroupWork.MailSendCode2, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddrKindCode2.Trim()))
                    {
                        //if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�Q", customerGroupWork.MailAddrKindCode2, 1, out msg)) // DEL BY ��� ON 2012/8/3 FOR �����`�F�b�N���P������Q���֕ύX
                        if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�Q", customerGroupWork.MailAddrKindCode2, 2, out msg)) // ADD BY ��� ON 2012/8/3 FOR �����`�F�b�N���P������Q���֕ύX
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("��s�����P", customerGroupWork.AccountNoInfo1, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("��s�����Q", customerGroupWork.AccountNoInfo2, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("��s�����R", customerGroupWork.AccountNoInfo3, 60, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ReceiptOutputCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�̎����o��", customerGroupWork.ReceiptOutputCode, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.DmOutCode.Trim()))
                    {
//                        if (!Check_CorIntAndLen("�c�l�o��", customerGroupWork.DmOutCode, 1, out msg)) // DEL 2022/03/04 �c�������@�d�q����A�g
                        if (!Check_CorIntAndLen("�d�q����o��", customerGroupWork.DmOutCode, 1, out msg)) // ADD 2022/03/04 �c�������@�d�q����A�g 
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesSlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("�[�i���o��", customerGroupWork.SalesSlipPrtDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AcpOdrrSlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("�󒍓`�[�o��", customerGroupWork.AcpOdrrSlipPrtDiv, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ShipmSlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("�ݏo�`�[�o��", customerGroupWork.ShipmSlipPrtDiv, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.EstimatePrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("���ϓ`�[�o��", customerGroupWork.EstimatePrtDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.UOESlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("�t�n�d�`�[�o��", customerGroupWork.UOESlipPrtDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.QrcodePrtCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�p�q�R�[�h���", customerGroupWork.QrcodePrtCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CustSlipNoMngCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("����`�[�ԍ��Ǘ�", customerGroupWork.CustSlipNoMngCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSlipNoDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("����`�[�ԍ��敪", customerGroupWork.CustomerSlipNoDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TotalBillOutputDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("���v�������o��", customerGroupWork.TotalBillOutputDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }

                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.DetailBillOutputCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("���א������o��", customerGroupWork.DetailBillOutputCode, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SlipTtlBillOutputDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("�`�[���v�������o��", customerGroupWork.SlipTtlBillOutputDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                   
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpFineAll.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v(�D��ALL)", customerGroupWork.CustRateGrpFineAll, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v(����ALL)", customerGroupWork.CustRateGrpPureAll, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P", customerGroupWork.CustRateGrpPure1, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q", customerGroupWork.CustRateGrpPure2, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����R", customerGroupWork.CustRateGrpPure3, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����S", customerGroupWork.CustRateGrpPure4, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����T", customerGroupWork.CustRateGrpPure5, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����U", customerGroupWork.CustRateGrpPure6, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����V", customerGroupWork.CustRateGrpPure7, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����W", customerGroupWork.CustRateGrpPure8, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����X", customerGroupWork.CustRateGrpPure9, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�O", customerGroupWork.CustRateGrpPure10, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�P", customerGroupWork.CustRateGrpPure11, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�Q", customerGroupWork.CustRateGrpPure12, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�R", customerGroupWork.CustRateGrpPure13, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�S", customerGroupWork.CustRateGrpPure14, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�T", customerGroupWork.CustRateGrpPure15, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�U", customerGroupWork.CustRateGrpPure16, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�V", customerGroupWork.CustRateGrpPure17, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�W", customerGroupWork.CustRateGrpPure18, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�X", customerGroupWork.CustRateGrpPure19, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�O", customerGroupWork.CustRateGrpPure20, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�P", customerGroupWork.CustRateGrpPure21, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�Q", customerGroupWork.CustRateGrpPure22, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�R", customerGroupWork.CustRateGrpPure23, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�S", customerGroupWork.CustRateGrpPure24, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�T", customerGroupWork.CustRateGrpPure25, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                }
                else
                {
                    // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.107�̑Ή�--------<<<<

                    // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.107�̑Ή�-------->>>>
                    if (!Check_IsNull("���Ӑ�R�[�h", customerGroupWork.CustomerCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_ZeroIntAndLen("���Ӑ�R�[�h", customerGroupWork.CustomerCode, 8, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.107�̑Ή�--------<<<<
                   
                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSubCode.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�T�u�R�[�h", customerGroupWork.CustomerSubCode.Trim(), 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ於�P", customerGroupWork.Name, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ於�Q", customerGroupWork.Name2, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSnm.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ旪��", customerGroupWork.CustomerSnm, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("���Ӑ於�J�i", customerGroupWork.Kana, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_HalfEngNumFixedLength("���Ӑ於�J�i", customerGroupWork.Kana, 30, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.HonorificTitle.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�h��", customerGroupWork.HonorificTitle, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("����", customerGroupWork.OutputNameCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("����", customerGroupWork.OutputNameCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�Ǘ����_", customerGroupWork.MngSectionCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("�Ǘ����_", customerGroupWork.MngSectionCode, 2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���Ӑ�S��", customerGroupWork.CustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OldCustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���S��", customerGroupWork.OldCustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAgentChgDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("�S���ҕύX��", customerGroupWork.CustAgentChgDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }

                        if (!Check_StrUnFixedLen("�S���ҕύX��", customerGroupWork.CustAgentChgDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TransStopDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("������~��", customerGroupWork.TransStopDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        if (!Check_StrUnFixedLen("������~��", customerGroupWork.TransStopDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("���q�Ǘ�", customerGroupWork.CarMngDivCd, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���q�Ǘ�", customerGroupWork.CarMngDivCd, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�l�E�@�l", customerGroupWork.CorporateDivCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�l�E�@�l", customerGroupWork.CorporateDivCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���Ӑ���", customerGroupWork.AcceptWholeSale, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���Ӑ���", customerGroupWork.AcceptWholeSale, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_IsNull("���Ӑ摮��", customerGroupWork.CustomerAttributeDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���Ӑ摮��", customerGroupWork.CustomerAttributeDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustWarehouseCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�D��q��", customerGroupWork.CustWarehouseCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BusinessTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�Ǝ�", customerGroupWork.BusinessTypeCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.JobTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�E��", customerGroupWork.JobTypeCode, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesAreaCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("�n��", customerGroupWork.SalesAreaCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode1.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�P", customerGroupWork.CustAnalysCode1, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode2.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�Q", customerGroupWork.CustAnalysCode2, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode3.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�R", customerGroupWork.CustAnalysCode3, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode4.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�S", customerGroupWork.CustAnalysCode4, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode5.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�T", customerGroupWork.CustAnalysCode5, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode6.Trim()))
                    {
                        if (!Check_CorIntAndLen("���̓R�[�h�U", customerGroupWork.CustAnalysCode6, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("�������_", customerGroupWork.ClaimSectionCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("�������_", customerGroupWork.ClaimSectionCode, 2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�����R�[�h", customerGroupWork.ClaimCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("�����R�[�h", customerGroupWork.ClaimCode, 8, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("����", customerGroupWork.TotalDay, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("����", customerGroupWork.TotalDay, 2, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�W����", customerGroupWork.CollectMoneyCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�W����", customerGroupWork.CollectMoneyCode, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�W����", customerGroupWork.CollectMoneyDay, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("�W����", customerGroupWork.CollectMoneyDay, 2, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�������", customerGroupWork.CollectCond, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZerIntAndLen("�������", customerGroupWork.CollectCond, 2, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CollectSight.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("����T�C�g", customerGroupWork.CollectSight, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.NTimeCalcStDate.Trim()))
                    {
                        if (!Check_CorIntAndLen("���񊨒�", customerGroupWork.NTimeCalcStDate, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BillCollecterCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�W���S��", customerGroupWork.BillCollecterCd, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("�]�ŕ����Q�Ƌ敪", customerGroupWork.CustCTaXLayRefCd, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�]�ŕ����Q�Ƌ敪", customerGroupWork.CustCTaXLayRefCd, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.ConsTaxLayMethod.Trim()))
                    {
                        if (!Check_CorIntAndLen("����œ]�ŕ���", customerGroupWork.ConsTaxLayMethod, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.62�̑Ή�-------->>>>
                    if (ConvertToInt32(customerGroupWork.CustCTaXLayRefCd.Trim()) == 0)
                    {
                        if (ConvertToInt32(customerGroupWork.ConsTaxLayMethod.Trim()) != consTaxLay)
                        {
                            customerGroupWork.ErrorLog = string.Format(FORMAT_ERRMSG_ERRORVAL, "����œ]�ŕ���");
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.62�̑Ή�--------<<<<
                    if (!string.IsNullOrEmpty(customerGroupWork.SalesUnPrcFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�P���[������", customerGroupWork.SalesUnPrcFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesMoneyFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("���z�[������", customerGroupWork.SalesMoneyFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesCnsTaxFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("����Œ[������", customerGroupWork.SalesCnsTaxFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("�^�M�Ǘ�", customerGroupWork.CreditMngCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�^�M�Ǘ�", customerGroupWork.CreditMngCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("��������", customerGroupWork.DepoDelCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("��������", customerGroupWork.DepoDelCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���|�敪", customerGroupWork.AccRecDivCd, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���|�敪", customerGroupWork.AccRecDivCd, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.62�̑Ή�-------->>>>
                    if (ConvertToInt32(customerGroupWork.CustCTaXLayRefCd.Trim()) == 1 && (ConvertToInt32(customerGroupWork.ConsTaxLayMethod.Trim()) == 2 || ConvertToInt32(customerGroupWork.ConsTaxLayMethod.Trim()) == 3))
                    {
                        if (ConvertToInt32(customerGroupWork.AccRecDivCd.Trim()) != 1)
                        {
                            customerGroupWork.ErrorLog = string.Format(FORMAT_ERRMSG_ERRORVAL, "���|�敪");
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.62�̑Ή�--------<<<<
                    if (!string.IsNullOrEmpty(customerGroupWork.PostNo.Trim()))
                    {
                        if (!Check_IntAndLen("�X�֔ԍ�", customerGroupWork.PostNo, 10, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�Z��", customerGroupWork.Address1, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�Z���Q", customerGroupWork.Address3, 22, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("�Z���R", customerGroupWork.Address4, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgent.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ�S����", customerGroupWork.CustomerAgent, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("����s�d�k", customerGroupWork.HomeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�Ζ���d�b�P", customerGroupWork.OfficeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.PortableTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�Ζ���d�b�Q", customerGroupWork.PortableTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OthersTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("���̑��d�b", customerGroupWork.OthersTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("����e�`�w", customerGroupWork.HomeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�Ζ���e�`�w", customerGroupWork.OfficeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SearchTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("�����ԍ�", customerGroupWork.SearchTelNo, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("��A����", customerGroupWork.MainContactCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("��A����", customerGroupWork.MainContactCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.Note1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�P", customerGroupWork.Note1, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�Q", customerGroupWork.Note2, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�R", customerGroupWork.Note3, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�S", customerGroupWork.Note4, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note5.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�T", customerGroupWork.Note5, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note6.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�U", customerGroupWork.Note6, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note7.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�V", customerGroupWork.Note7, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note8.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�W", customerGroupWork.Note8, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note9.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�X", customerGroupWork.Note9, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note10.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���Ӑ���l�P�O", customerGroupWork.Note10, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MainSendMailAddrCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("�呗�M�惁�[���A�h���X�敪", customerGroupWork.MainSendMailAddrCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���[���A�h���X�P", customerGroupWork.MailAddress1, 64, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("���[�����M�敪�R�[�h�P", customerGroupWork.MailSendCode1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���[�����M�敪�R�[�h�P", customerGroupWork.MailSendCode1, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���[���A�h���X��ʃR�[�h�P", customerGroupWork.MailAddrKindCode1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�P", customerGroupWork.MailAddrKindCode1, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("���[���A�h���X�Q", customerGroupWork.MailAddress2, 64, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!Check_IsNull("���[�����M�敪�R�[�h�Q", customerGroupWork.MailSendCode2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���[�����M�敪�R�[�h�Q", customerGroupWork.MailSendCode2, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���[���A�h���X��ʃR�[�h�Q", customerGroupWork.MailAddrKindCode2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���[���A�h���X��ʃR�[�h�Q", customerGroupWork.MailAddrKindCode2, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("��s�����P", customerGroupWork.AccountNoInfo1, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("��s�����Q", customerGroupWork.AccountNoInfo2, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("��s�����R", customerGroupWork.AccountNoInfo3, 60, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("�̎����o��", customerGroupWork.ReceiptOutputCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�̎����o��", customerGroupWork.ReceiptOutputCode, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
//                    if (!Check_IsNull("�c�l�o��", customerGroupWork.DmOutCode, out  msg)) // DEL 2022/03/04 �c�������@�d�q����A�g
                    if (!Check_IsNull("�d�q����o��", customerGroupWork.DmOutCode, out  msg)) // ADD 2022/03/04 �c�������@�d�q����A�g
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
//                    if (!Check_CorIntAndLen("�c�l�o��", customerGroupWork.DmOutCode, 1, out msg)) // DEL 2022/03/04 �c�������@�d�q����A�g
                    if (!Check_CorIntAndLen("�d�q����o��", customerGroupWork.DmOutCode, 1, out msg)) // ADD 2022/03/04 �c�������@�d�q����A�g
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�[�i���o��", customerGroupWork.SalesSlipPrtDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�[�i���o��", customerGroupWork.SalesSlipPrtDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�󒍓`�[�o��", customerGroupWork.AcpOdrrSlipPrtDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�󒍓`�[�o��", customerGroupWork.AcpOdrrSlipPrtDiv, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�ݏo�`�[�o��", customerGroupWork.ShipmSlipPrtDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�ݏo�`�[�o��", customerGroupWork.ShipmSlipPrtDiv, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���ϓ`�[�o��", customerGroupWork.EstimatePrtDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���ϓ`�[�o��", customerGroupWork.EstimatePrtDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�t�n�d�`�[�o��", customerGroupWork.UOESlipPrtDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�t�n�d�`�[�o��", customerGroupWork.UOESlipPrtDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�p�q�R�[�h���", customerGroupWork.QrcodePrtCd, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�p�q�R�[�h���", customerGroupWork.QrcodePrtCd, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_IsNull("����`�[�ԍ��Ǘ�", customerGroupWork.CustSlipNoMngCd, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("����`�[�ԍ��Ǘ�", customerGroupWork.CustSlipNoMngCd, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("����`�[�ԍ��敪", customerGroupWork.CustomerSlipNoDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("����`�[�ԍ��敪", customerGroupWork.CustomerSlipNoDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���v�������o��", customerGroupWork.TotalBillOutputDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���v�������o��", customerGroupWork.TotalBillOutputDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("���א������o��", customerGroupWork.DetailBillOutputCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("���א������o��", customerGroupWork.DetailBillOutputCode, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("�`�[���v�������o��", customerGroupWork.SlipTtlBillOutputDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("�`�[���v�������o��", customerGroupWork.SlipTtlBillOutputDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpFine.Trim()))// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpFineAll.Trim()))// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                    {
                        //if (!Check_IntAndLen("���Ӑ�|���O���[�v(�D��)", customerGroupWork.CustRateGrpFine, 4, out  msg))// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v(�D��ALL)", customerGroupWork.CustRateGrpFineAll, 4, out  msg))// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v(����ALL)", customerGroupWork.CustRateGrpPureAll, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P", customerGroupWork.CustRateGrpPure1, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q", customerGroupWork.CustRateGrpPure2, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  ������ Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3.Trim()))// ADD  2012/07/05  ������ Redmine#30393
                    {
                        //if (!Check_IntAndLen("���Ӑ�|���O���[�v�����R", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  ������ Redmine#30393
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����R", customerGroupWork.CustRateGrpPure3, 4, out  msg))// ADD  2012/07/05  ������ Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  ������ Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4.Trim()))// ADD  2012/07/05  ������ Redmine#30393
                    {
                        //if (!Check_IntAndLen("���Ӑ�|���O���[�v�����S", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  ������ Redmine#30393
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����S", customerGroupWork.CustRateGrpPure4, 4, out msg))// ADD  2012/07/05  ������ Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  ������ Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5.Trim()))// ADD  2012/07/05  ������ Redmine#30393
                    {
                        //if (!Check_IntAndLen("���Ӑ�|���O���[�v�����T", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  ������ Redmine#30393
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����T", customerGroupWork.CustRateGrpPure5, 4, out  msg))// ADD  2012/07/05  ������ Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  ������ Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6.Trim()))// ADD  2012/07/05  ������ Redmine#30393
                    {
                        //if (!Check_IntAndLen("���Ӑ�|���O���[�v�����U", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  ������ Redmine#30393
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����U", customerGroupWork.CustRateGrpPure6, 4, out  msg))// ADD  2012/07/05  ������ Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  ������ Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7.Trim()))// ADD  2012/07/05  ������ Redmine#30393
                    {
                        //if (!Check_IntAndLen("���Ӑ�|���O���[�v�����V", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  ������ Redmine#30393
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����V", customerGroupWork.CustRateGrpPure7, 4, out  msg))// ADD  2012/07/05  ������ Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����W", customerGroupWork.CustRateGrpPure8, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����X", customerGroupWork.CustRateGrpPure9, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�O", customerGroupWork.CustRateGrpPure10, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�P", customerGroupWork.CustRateGrpPure11, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�Q", customerGroupWork.CustRateGrpPure12, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�R", customerGroupWork.CustRateGrpPure13, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�S", customerGroupWork.CustRateGrpPure14, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�T", customerGroupWork.CustRateGrpPure15, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�U", customerGroupWork.CustRateGrpPure16, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�V", customerGroupWork.CustRateGrpPure17, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�W", customerGroupWork.CustRateGrpPure18, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����P�X", customerGroupWork.CustRateGrpPure19, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�O", customerGroupWork.CustRateGrpPure20, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�P", customerGroupWork.CustRateGrpPure21, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�Q", customerGroupWork.CustRateGrpPure22, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�R", customerGroupWork.CustRateGrpPure23, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�S", customerGroupWork.CustRateGrpPure24, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25.Trim()))
                    {
                        if (!Check_IntAndLen("���Ӑ�|���O���[�v�����Q�T", customerGroupWork.CustRateGrpPure25, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // --------------- ADD START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.48�̑Ή�-------->>>>
                    //if (Convert.ToInt32(customerGroupWork.CustRateGrpPureAll.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll) && Convert.ToInt32(customerGroupWork.CustRateGrpPureAll.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                    {
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure1.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1) && Convert.ToInt32(customerGroupWork.CustRateGrpPure1.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure2.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2) && Convert.ToInt32(customerGroupWork.CustRateGrpPure2.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure3.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3) && Convert.ToInt32(customerGroupWork.CustRateGrpPure3.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure4.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4) && Convert.ToInt32(customerGroupWork.CustRateGrpPure4.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure5.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5) && Convert.ToInt32(customerGroupWork.CustRateGrpPure5.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure6.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6) && Convert.ToInt32(customerGroupWork.CustRateGrpPure6.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure7.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7) && Convert.ToInt32(customerGroupWork.CustRateGrpPure7.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure8.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8) && Convert.ToInt32(customerGroupWork.CustRateGrpPure8.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure9.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9) && Convert.ToInt32(customerGroupWork.CustRateGrpPure9.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure10.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10) && Convert.ToInt32(customerGroupWork.CustRateGrpPure10.Trim()) >= 0) // ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure11.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11) && Convert.ToInt32(customerGroupWork.CustRateGrpPure11.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure12.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12) && Convert.ToInt32(customerGroupWork.CustRateGrpPure12.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure13.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13) && Convert.ToInt32(customerGroupWork.CustRateGrpPure13.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure14.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14) && Convert.ToInt32(customerGroupWork.CustRateGrpPure14.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure15.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15) && Convert.ToInt32(customerGroupWork.CustRateGrpPure15.Trim()) >= 0) // ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure16.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16) && Convert.ToInt32(customerGroupWork.CustRateGrpPure16.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure17.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17) && Convert.ToInt32(customerGroupWork.CustRateGrpPure17.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure18.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18) && Convert.ToInt32(customerGroupWork.CustRateGrpPure18.Trim()) >= 0) // ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure19.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19) && Convert.ToInt32(customerGroupWork.CustRateGrpPure19.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure20.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20) && Convert.ToInt32(customerGroupWork.CustRateGrpPure20.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure21.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21) && Convert.ToInt32(customerGroupWork.CustRateGrpPure21.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure22.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22) && Convert.ToInt32(customerGroupWork.CustRateGrpPure22.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure23.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23) && Convert.ToInt32(customerGroupWork.CustRateGrpPure23.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure24.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24) && Convert.ToInt32(customerGroupWork.CustRateGrpPure24.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure25.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25))// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25) && Convert.ToInt32(customerGroupWork.CustRateGrpPure25.Trim()) >= 0)// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.48�̑Ή�
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    // --------------- ADD END 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.48�̑Ή�--------<<<<
                } // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.107�̑Ή�
            }// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή� 

            // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�-------->>>>
            int count = importCustWorCheckList.FindAll(
                       delegate(CustomerGroupWork p)
                       {
                           return (!string.IsNullOrEmpty(customerGroupWork.CustomerCode) && ConvertToInt32( p.CustomerCode) == ConvertToInt32(customerGroupWork.CustomerCode));
                       }).Count;

            if (count > 1)
            {
                customerGroupWork.ErrorLog = ERRMSG_DUPLICATE;
                logArrayList.Add(customerGroupWork);
                return;
            }
            // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.106�̑Ή�--------<<<<


            if (isUpdFlg)
            {
                // �X�V�̏ꍇ
                work.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                work.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                work.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                work.LogicalDeleteCode = 0;                                   // �_���폜�敪
                work.PureCode = searchWork.PureCode;                          // �����敪
                work.TotalAmountDispWayCd = searchWork.TotalAmountDispWayCd;  // ���z�\�����@�敪
                work.TotalAmntDspWayRef = searchWork.TotalAmntDspWayRef;      // ���z�\�����@�Q�Ƌ敪
                work.BillPartsNoPrtCd = searchWork.BillPartsNoPrtCd;          // �i�Ԉ󎚋敪(������)
                work.DeliPartsNoPrtCd = searchWork.DeliPartsNoPrtCd;          // �i�Ԉ󎚋敪(�[�i���j
                work.DefSalesSlipCd = searchWork.DefSalesSlipCd;              // �`�[�敪�����l
                work.LavorRateRank = searchWork.LavorRateRank;                // �H�����o���[�g�����N
                work.SlipTtlPrn = searchWork.SlipTtlPrn;                      // �`�[�^�C�g���p�^�[��
                work.DepoBankCode = searchWork.DepoBankCode;                  // ������s�R�[�h
                work.DeliHonorificTtl = searchWork.DeliHonorificTtl;          // �[�i���h��
                work.BillHonorificTtl = searchWork.BillHonorificTtl;          // �������h��
                work.EstmHonorificTtl = searchWork.EstmHonorificTtl;          // ���Ϗ��h��
                work.RectHonorificTtl = searchWork.RectHonorificTtl;          // �̎����h��
                work.DeliHonorTtlPrtDiv = searchWork.DeliHonorTtlPrtDiv;      // �[�i���h�̈󎚋敪
                work.BillHonorTtlPrtDiv = searchWork.BillHonorTtlPrtDiv;      // �������h�̈󎚋敪
                work.EstmHonorTtlPrtDiv = searchWork.EstmHonorTtlPrtDiv;      // ���Ϗ��h�̈󎚋敪
                work.RectHonorTtlPrtDiv = searchWork.RectHonorTtlPrtDiv;      // �̎����h�̈󎚋敪
                work.CustomerEpCode = searchWork.CustomerEpCode;              // ���Ӑ��ƃR�[�h
                work.CustomerSecCode = searchWork.CustomerSecCode;            // ���Ӑ拒�_�R�[�h
                work.OnlineKindDiv = searchWork.OnlineKindDiv;                // �I�����C����ʋ敪
                work.SimplInqAcntAcntGrId = searchWork.SimplInqAcntAcntGrId;  // �I�����C���A�J�E���gID  ADD  2012/07/09  ������ Redmine#30393 for  ��Q�ꗗ�̎w�ENO.47�̑Ή�
            }
            else
            {
                // �V�K�̏ꍇ
                work.PureCode = 0;                                            // �����敪
                work.TotalAmountDispWayCd = 0;                                // ���z�\�����@�敪
                work.TotalAmntDspWayRef = 0;                                  // ���z�\�����@�Q�Ƌ敪
                work.BillPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(������)
                work.DeliPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(�[�i���j
                work.DefSalesSlipCd = 0;                                      // �`�[�敪�����l
                work.LavorRateRank = 0;                                       // �H�����o���[�g�����N
                work.SlipTtlPrn = 0;                                          // �`�[�^�C�g���p�^�[��
                work.DepoBankCode = 0;                                        // ������s�R�[�h
                work.DeliHonorificTtl = string.Empty;                         // �[�i���h��
                work.BillHonorificTtl = string.Empty;                         // �������h��
                work.EstmHonorificTtl = string.Empty;                         // ���Ϗ��h��
                work.RectHonorificTtl = string.Empty;                         // �̎����h��
                work.DeliHonorTtlPrtDiv = 0;                                  // �[�i���h�̈󎚋敪
                work.BillHonorTtlPrtDiv = 0;                                  // �������h�̈󎚋敪
                work.EstmHonorTtlPrtDiv = 0;                                  // ���Ϗ��h�̈󎚋敪
                work.RectHonorTtlPrtDiv = 0;                                  // �̎����h�̈󎚋敪
                work.CustomerEpCode = string.Empty;                           // ���Ӑ��ƃR�[�h
                work.CustomerSecCode = string.Empty;                          // ���Ӑ拒�_�R�[�h
                work.OnlineKindDiv = 0;                                       // �I�����C����ʋ敪

            }
            work.EnterpriseCode = enterpriseCode;
            work.CustomerCode = ConvertToInt32(customerGroupWork.CustomerCode);                    // ���Ӑ�R�[�h
            work.CustomerSubCode = customerGroupWork.CustomerSubCode;                              // �T�u�R�[�h
            work.Name = customerGroupWork.Name;                                                    // ���Ӑ於�P
            work.Name2 = customerGroupWork.Name2;                                                  // ���Ӑ於�Q
            work.CustomerSnm = customerGroupWork.CustomerSnm;                                      // ���Ӑ旪��
            work.Kana = customerGroupWork.Kana;                                                    // ���Ӑ於�J�i
            work.HonorificTitle = customerGroupWork.HonorificTitle;                                // �h��
            work.OutputNameCode = ConvertToInt32(customerGroupWork.OutputNameCode);                // ����
            work.MngSectionCode = ConvertToStrCode(customerGroupWork.MngSectionCode, 2);           // �Ǘ����_
            work.CustomerAgentCd = ConvertToStrCode(customerGroupWork.CustomerAgentCd, 4);         // ���Ӑ�S��
            work.OldCustomerAgentCd = ConvertToStrCode(customerGroupWork.OldCustomerAgentCd, 4);   // ���S��
            work.CustAgentChgDate = ConvertToDateTime(customerGroupWork.CustAgentChgDate);         // �S���ҕύX��
            work.TransStopDate = ConvertToDateTime(customerGroupWork.TransStopDate);               // ������~��
            work.CarMngDivCd = ConvertToInt32(customerGroupWork.CarMngDivCd);                      // ���p�Ǘ�
            work.CorporateDivCode = ConvertToInt32(customerGroupWork.CorporateDivCode);            // �l�E�@�l
            work.AcceptWholeSale = ConvertToInt32(customerGroupWork.AcceptWholeSale);            // ���Ӑ���// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.61�̑Ή� // ADD  2012/07/24  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.61�̑Ή�
            // ------ DEL START 2012/07/24 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.61�̑Ή�-------->>>>
            //// ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.61�̑Ή�-------->>>>
            //if (ConvertToInt32(customerGroupWork.AcceptWholeSale) == 0)
            //{
            //    work.AcceptWholeSale = 1;
            //}
            //else if (ConvertToInt32(customerGroupWork.AcceptWholeSale) == 1)
            //{
            //    work.AcceptWholeSale = 2;
            //}
            //else
            //{
            //    work.AcceptWholeSale = ConvertToInt32(customerGroupWork.AcceptWholeSale);
            //}
            //// ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.61�̑Ή�--------<<<<
            // ------ DEL END 2012/07/24 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.61�̑Ή�--------<<<<
            //work.CustomerAttributeDiv = ConvertToInt32(customerGroupWork.CustomerAttributeDiv);    // ���Ӑ摮��// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.59�̑Ή�
            // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.59�̑Ή�-------->>>>
            if (ConvertToInt32(customerGroupWork.CustomerAttributeDiv) == 1)
            {
                work.CustomerAttributeDiv = 8;
            }
            else if (ConvertToInt32(customerGroupWork.CustomerAttributeDiv) == 2)
            {
                work.CustomerAttributeDiv = 9;
            }
            else
            {
                work.CustomerAttributeDiv = ConvertToInt32(customerGroupWork.CustomerAttributeDiv);
            }
            // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.59�̑Ή�--------<<<<
            work.CustWarehouseCd = ConvertToStrCode(customerGroupWork.CustWarehouseCd, 4);         // �D��q��
            work.BusinessTypeCode = ConvertToInt32(customerGroupWork.BusinessTypeCode);            // �Ǝ�
            work.JobTypeCode = ConvertToInt32(customerGroupWork.JobTypeCode);                      // �E��
            work.SalesAreaCode = ConvertToInt32(customerGroupWork.SalesAreaCode);                  // �n��
            work.CustAnalysCode1 = ConvertToInt32(customerGroupWork.CustAnalysCode1);              // ���̓R�[�h�P
            work.CustAnalysCode2 = ConvertToInt32(customerGroupWork.CustAnalysCode2);              // ���̓R�[�h�Q
            work.CustAnalysCode3 = ConvertToInt32(customerGroupWork.CustAnalysCode3);              // ���̓R�[�h�R
            work.CustAnalysCode4 = ConvertToInt32(customerGroupWork.CustAnalysCode4);              // ���̓R�[�h�S
            work.CustAnalysCode5 = ConvertToInt32(customerGroupWork.CustAnalysCode5);              // ���̓R�[�h�T
            work.CustAnalysCode6 = ConvertToInt32(customerGroupWork.CustAnalysCode6);              // ���̓R�[�h�U
            work.ClaimSectionCode = ConvertToStrCode(customerGroupWork.ClaimSectionCode, 2);       // �������_
            work.ClaimCode = ConvertToInt32(customerGroupWork.ClaimCode);                          // �����R�[�h
            work.TotalDay = ConvertToInt32(customerGroupWork.TotalDay);                            // ����
            work.CollectMoneyCode = ConvertToInt32(customerGroupWork.CollectMoneyCode);            // �W����
            work.CollectMoneyDay = ConvertToInt32(customerGroupWork.CollectMoneyDay);              // �W����
            work.CollectCond = ConvertToInt32(customerGroupWork.CollectCond);                      // �������
            work.CollectSight = ConvertToInt32(customerGroupWork.CollectSight);                    // ����T�C�g
            work.NTimeCalcStDate = ConvertToInt32(customerGroupWork.NTimeCalcStDate);              // ���񊨒�
            work.BillCollecterCd = ConvertToStrCode(customerGroupWork.BillCollecterCd, 4);         // �W���S��
            work.CustCTaXLayRefCd = ConvertToInt32(customerGroupWork.CustCTaXLayRefCd);            // �]�ŕ����Q�Ƌ敪
            work.ConsTaxLayMethod = ConvertToInt32(customerGroupWork.ConsTaxLayMethod);            // ����œ]�ŕ���
            work.SalesUnPrcFrcProcCd = ConvertToInt32(customerGroupWork.SalesUnPrcFrcProcCd);      // �P���[������
            work.SalesMoneyFrcProcCd = ConvertToInt32(customerGroupWork.SalesMoneyFrcProcCd);      // ���z�[������
            work.SalesCnsTaxFrcProcCd = ConvertToInt32(customerGroupWork.SalesCnsTaxFrcProcCd);    // ����Œ[������
            work.CreditMngCode = ConvertToInt32(customerGroupWork.CreditMngCode);                  // �^�M�Ǘ�
            work.DepoDelCode = ConvertToInt32(customerGroupWork.DepoDelCode);                      // ��������
            work.AccRecDivCd = ConvertToInt32(customerGroupWork.AccRecDivCd);                      // ���|�敪
            work.PostNo = customerGroupWork.PostNo;                                                // �X�֔ԍ�
            work.Address1 = customerGroupWork.Address1;                                            // �Z��
            work.Address3 = customerGroupWork.Address3;                                            // �Z���Q
            work.Address4 = customerGroupWork.Address4;                                            // �Z���R
            work.CustomerAgent = customerGroupWork.CustomerAgent;                                  // ���Ӑ�S����
            work.HomeTelNo = customerGroupWork.HomeTelNo;                                          // ����s�d�k
            work.OfficeTelNo = customerGroupWork.OfficeTelNo;                                      // �Ζ���d�b�P
            work.PortableTelNo = customerGroupWork.PortableTelNo;                                  // �Ζ���d�b�Q
            work.OthersTelNo = customerGroupWork.OthersTelNo;                                      // ���̑��d�b
            work.HomeFaxNo = customerGroupWork.HomeFaxNo;                                          // ����e�`�w
            work.OfficeFaxNo = customerGroupWork.OfficeFaxNo;                                      // �Ζ���e�`�w
            work.SearchTelNo = customerGroupWork.SearchTelNo;                                      // �����ԍ�
            work.MainContactCode = ConvertToInt32(customerGroupWork.MainContactCode);              // ��A����
            work.Note1 = customerGroupWork.Note1;                                                  // ���Ӑ���l�P
            work.Note2 = customerGroupWork.Note2;                                                  // ���Ӑ���l�Q
            work.Note3 = customerGroupWork.Note3;                                                  // ���Ӑ���l�R
            work.Note4 = customerGroupWork.Note4;                                                  // ���Ӑ���l�S
            work.Note5 = customerGroupWork.Note5;                                                  // ���Ӑ���l�T
            work.Note6 = customerGroupWork.Note6;                                                  // ���Ӑ���l�U
            work.Note7 = customerGroupWork.Note7;                                                  // ���Ӑ���l�V
            work.Note8 = customerGroupWork.Note8;                                                  // ���Ӑ���l�W
            work.Note9 = customerGroupWork.Note9;                                                  // ���Ӑ���l�X
            work.Note10 = customerGroupWork.Note10;                                                // ���Ӑ���l�P�O
            work.MainSendMailAddrCd = ConvertToInt32(customerGroupWork.MainSendMailAddrCd);        // �呗�M�惁�[���A�h���X�敪
            work.MailAddress1 = customerGroupWork.MailAddress1;                                    // ���[���A�h���X�P
            work.MailSendCode1 = ConvertToInt32(customerGroupWork.MailSendCode1);                  // ���[�����M�敪�R�[�h�P
            //work.MailAddrKindCode1 = ConvertToInt32(customerGroupWork.MailAddrKindCode1);          // ���[���A�h���X��ʃR�[�h�P// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.60�̑Ή�
            // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.60�̑Ή�-------->>>>
            if (ConvertToInt32(customerGroupWork.MailAddrKindCode1) == 4)
            {
                work.MailAddrKindCode1 = 99;
            }
            else
            {
                work.MailAddrKindCode1 = ConvertToInt32(customerGroupWork.MailAddrKindCode1);
            }
            // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.60�̑Ή�--------<<<<
            work.MailAddress2 = customerGroupWork.MailAddress2;                                    // ���[���A�h���X�Q
            work.MailSendCode2 = ConvertToInt32(customerGroupWork.MailSendCode2);                  // ���[�����M�敪�R�[�h�Q
            //work.MailAddrKindCode2 = ConvertToInt32(customerGroupWork.MailAddrKindCode2);          // ���[���A�h���X��ʃR�[�h�Q// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.60�̑Ή�
            // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.60�̑Ή�-------->>>>
            if (ConvertToInt32(customerGroupWork.MailAddrKindCode2) == 4)
            {
                work.MailAddrKindCode2 = 99;
            }
            else
            {
                work.MailAddrKindCode2 = ConvertToInt32(customerGroupWork.MailAddrKindCode2);
            }
            // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.60�̑Ή�--------<<<<
            work.AccountNoInfo1 = customerGroupWork.AccountNoInfo1;                                // ��s�����P
            work.AccountNoInfo2 = customerGroupWork.AccountNoInfo2;                                // ��s�����Q
            work.AccountNoInfo3 = customerGroupWork.AccountNoInfo3;                                // ��s�����R
            work.ReceiptOutputCode = ConvertToInt32(customerGroupWork.ReceiptOutputCode);          // �̎����o��
            work.DmOutCode = ConvertToInt32(customerGroupWork.DmOutCode);                          // �c�l�o��
            work.SalesSlipPrtDiv = ConvertToInt32(customerGroupWork.SalesSlipPrtDiv);              // �[�i���o��
            work.AcpOdrrSlipPrtDiv = ConvertToInt32(customerGroupWork.AcpOdrrSlipPrtDiv);          // �󒍓`�[�o��
            work.ShipmSlipPrtDiv = ConvertToInt32(customerGroupWork.ShipmSlipPrtDiv);              // �ݏo�`�[�o��
            work.EstimatePrtDiv = ConvertToInt32(customerGroupWork.EstimatePrtDiv);                // ���ϓ`�[�o��
            work.UOESlipPrtDiv = ConvertToInt32(customerGroupWork.UOESlipPrtDiv);                  // �t�n�d�`�[�o��
            work.QrcodePrtCd = ConvertToInt32(customerGroupWork.QrcodePrtCd);                      // �p�q�R�[�h���
            work.CustSlipNoMngCd = ConvertToInt32(customerGroupWork.CustSlipNoMngCd);              // ����`�[�ԍ��Ǘ�
            work.CustomerSlipNoDiv = ConvertToInt32(customerGroupWork.CustomerSlipNoDiv);          // ����`�[�ԍ��敪

            work.TotalBillOutputDiv = ConvertToInt32(customerGroupWork.TotalBillOutputDiv);        // ���v�������o��
            work.DetailBillOutputCode = ConvertToInt32(customerGroupWork.DetailBillOutputCode);    // ���א������o��
            work.SlipTtlBillOutputDiv = ConvertToInt32(customerGroupWork.SlipTtlBillOutputDiv);    // �`�[���v�������o�͋敪

            //work.CustRateGrpFine = ConvertRateToInt32(customerGroupWork.CustRateGrpFine);        //���Ӑ�|���O���[�v(�D��)// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            work.CustRateGrpFineAll = ConvertRateToInt32(customerGroupWork.CustRateGrpFineAll);    //���Ӑ�|���O���[�v(�D��ALL)// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            work.CustRateGrpPureAll = ConvertRateToInt32(customerGroupWork.CustRateGrpPureAll);    //���Ӑ�|���O���[�v(����ALL)
            work.CustRateGrpPure1 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure1);        //���Ӑ�|���O���[�v�����P
            work.CustRateGrpPure2 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure2);        //���Ӑ�|���O���[�v����2
            work.CustRateGrpPure3 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure3);        //���Ӑ�|���O���[�v����3
            work.CustRateGrpPure4 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure4);        //���Ӑ�|���O���[�v����4
            work.CustRateGrpPure5 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure5);        //���Ӑ�|���O���[�v����5
            work.CustRateGrpPure6 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure6);        //���Ӑ�|���O���[�v����6
            work.CustRateGrpPure7 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure7);        //���Ӑ�|���O���[�v����7
            work.CustRateGrpPure8 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure8);        //���Ӑ�|���O���[�v����8
            work.CustRateGrpPure9 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure9);        //���Ӑ�|���O���[�v����9
            work.CustRateGrpPure10 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure10);      //���Ӑ�|���O���[�v�����P0
            work.CustRateGrpPure11 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure11);      //���Ӑ�|���O���[�v�����P1
            work.CustRateGrpPure12 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure12);      //���Ӑ�|���O���[�v�����P2
            work.CustRateGrpPure13 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure13);      //���Ӑ�|���O���[�v�����P3
            work.CustRateGrpPure14 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure14);      //���Ӑ�|���O���[�v�����P4
            work.CustRateGrpPure15 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure15);      //���Ӑ�|���O���[�v�����P5
            work.CustRateGrpPure16 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure16);      //���Ӑ�|���O���[�v�����P6
            work.CustRateGrpPure17 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure17);      //���Ӑ�|���O���[�v�����P7
            work.CustRateGrpPure18 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure18);      //���Ӑ�|���O���[�v�����P8
            work.CustRateGrpPure19 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure19);      //���Ӑ�|���O���[�v�����P9
            work.CustRateGrpPure20 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure20);      //���Ӑ�|���O���[�v����20
            work.CustRateGrpPure21 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure21);      //���Ӑ�|���O���[�v����2�P
            work.CustRateGrpPure22 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure22);      //���Ӑ�|���O���[�v����22
            work.CustRateGrpPure23 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure23);      //���Ӑ�|���O���[�v����23
            work.CustRateGrpPure24 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure24);      //���Ӑ�|���O���[�v����24
            work.CustRateGrpPure25 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure25);      //���Ӑ�|���O���[�v����25
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// ���O�e�[�u��
        ///// </summary>
        ///// <param name="row">CSV�t�@�C���̍s</param>
        ///// <param name="logTable">���O�e�[�u��</param>
        ///// <param name="msg">�G���[���b�Z�[�W</param>
        //private void ConverToDataSetCustomerLog(DataRow row, ref DataTable logTable, string msg)
        //{
        //    DataRow dataRow = logTable.NewRow();
        //    int index = 0;

        //    dataRow["CustomerCodeRF"] = row[index++].ToString();
        //    dataRow["CustomerSubCodeRF"] = row[index++].ToString();
        //    dataRow["NameRF"] = row[index++].ToString();
        //    dataRow["Name2RF"] = row[index++].ToString();
        //    dataRow["CustomerSnmRF"] = row[index++].ToString();
        //    dataRow["KanaRF"] = row[index++].ToString();
        //    dataRow["HonorificTitleRF"] = row[index++].ToString();
        //    dataRow["OutputNameCodeRF"] = row[index++].ToString();
        //    dataRow["MngSectionCodeRF"] = row[index++].ToString();
        //    dataRow["CustomerAgentCdRF"] = row[index++].ToString();
        //    dataRow["OldCustomerAgentCdRF"] = row[index++].ToString();
        //    dataRow["CustAgentChgDateRF"] = row[index++].ToString();
        //    dataRow["TransStopDateRF"] = row[index++].ToString();
        //    dataRow["CarMngDivCdRF"] = row[index++].ToString();
        //    dataRow["CorporateDivCodeRF"] = row[index++].ToString();
        //    dataRow["AcceptWholeSaleRF"] = row[index++].ToString();
        //    dataRow["CustomerAttributeDivRF"] = row[index++].ToString();
        //    dataRow["CustWarehouseCdRF"] = row[index++].ToString();
        //    dataRow["BusinessTypeCodeRF"] = row[index++].ToString();
        //    dataRow["JobTypeCodeRF"] = row[index++].ToString();
        //    dataRow["SalesAreaCodeRF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode1RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode2RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode3RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode4RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode5RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode6RF"] = row[index++].ToString();
        //    dataRow["ClaimSectionCodeRF"] = row[index++].ToString();
        //    dataRow["ClaimCodeRF"] = row[index++].ToString();
        //    dataRow["TotalDayRF"] = row[index++].ToString();
        //    dataRow["CollectMoneyCodeRF"] = row[index++].ToString();
        //    dataRow["CollectMoneyDayRF"] = row[index++].ToString();
        //    dataRow["CollectCondRF"] = row[index++].ToString();
        //    dataRow["CollectSightRF"] = row[index++].ToString();
        //    dataRow["NTimeCalcStDateRF"] = row[index++].ToString();
        //    dataRow["BillCollecterCdRF"] = row[index++].ToString();
        //    dataRow["CustCTaXLayRefCdRF"] = row[index++].ToString();
        //    dataRow["ConsTaxLayMethodRF"] = row[index++].ToString();
        //    dataRow["SalesUnPrcFrcProcCdRF"] = row[index++].ToString();
        //    dataRow["SalesMoneyFrcProcCdRF"] = row[index++].ToString();
        //    dataRow["SalesCnsTaxFrcProcCdRF"] = row[index++].ToString();
        //    dataRow["CreditMngCodeRF"] = row[index++].ToString();
        //    dataRow["DepoDelCodeRF"] = row[index++].ToString();
        //    dataRow["AccRecDivCdRF"] = row[index++].ToString();
        //    dataRow["PostNoRF"] = row[index++].ToString();
        //    dataRow["Address1RF"] = row[index++].ToString();
        //    dataRow["Address3RF"] = row[index++].ToString();
        //    dataRow["Address4RF"] = row[index++].ToString();
        //    dataRow["CustomerAgentRF"] = row[index++].ToString();
        //    dataRow["HomeTelNoRF"] = row[index++].ToString();
        //    dataRow["OfficeTelNoRF"] = row[index++].ToString();
        //    dataRow["PortableTelNoRF"] = row[index++].ToString();
        //    dataRow["OthersTelNoRF"] = row[index++].ToString();
        //    dataRow["HomeFaxNoRF"] = row[index++].ToString();
        //    dataRow["OfficeFaxNoRF"] = row[index++].ToString();
        //    dataRow["SearchTelNoRF"] = row[index++].ToString();
        //    dataRow["MainContactCodeRF"] = row[index++].ToString();
        //    dataRow["Note1RF"] = row[index++].ToString();
        //    dataRow["Note2RF"] = row[index++].ToString();
        //    dataRow["Note3RF"] = row[index++].ToString();
        //    dataRow["Note4RF"] = row[index++].ToString();
        //    dataRow["Note5RF"] = row[index++].ToString();
        //    dataRow["Note6RF"] = row[index++].ToString();
        //    dataRow["Note7RF"] = row[index++].ToString();
        //    dataRow["Note8RF"] = row[index++].ToString();
        //    dataRow["Note9RF"] = row[index++].ToString();
        //    dataRow["Note10RF"] = row[index++].ToString();
        //    dataRow["MainSendMailAddrCdRF"] = row[index++].ToString();
        //    dataRow["MailAddress1RF"] = row[index++].ToString();
        //    dataRow["MailSendCode1RF"] = row[index++].ToString();
        //    dataRow["MailAddrKindCode1RF"] = row[index++].ToString();
        //    dataRow["MailAddress2RF"] = row[index++].ToString();
        //    dataRow["MailSendCode2RF"] = row[index++].ToString();
        //    dataRow["MailAddrKindCode2RF"] = row[index++].ToString();
        //    dataRow["AccountNoInfo1RF"] = row[index++].ToString();
        //    dataRow["AccountNoInfo2RF"] = row[index++].ToString();
        //    dataRow["AccountNoInfo3RF"] = row[index++].ToString();
        //    dataRow["ReceiptOutputCodeRF"] = row[index++].ToString();
        //    dataRow["DmOutCodeRF"] = row[index++].ToString();
        //    dataRow["SalesSlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["AcpOdrrSlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["ShipmSlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["EstimatePrtDivRF"] = row[index++].ToString();
        //    dataRow["UOESlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["QrcodePrtCdRF"] = row[index++].ToString();
        //    dataRow["CustSlipNoMngCdRF"] = row[index++].ToString();
        //    dataRow["CustomerSlipNoDivRF"] = row[index++].ToString();
        //    dataRow["TotalBillOutputDivRF"] = row[index++].ToString();
        //    dataRow["DetailBillOutputCodeRF"] = row[index++].ToString();
        //    dataRow["SlipTtlBillOutputDivRF"] = row[index++].ToString();
        //    dataRow["CustRateGrpFine"] = row[index++].ToString();
        //    dataRow["CustRateGrpPureAll"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure1"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure2"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure3"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure4"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure5"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure6"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure7"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure8"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure9"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure10"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure11"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure12"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure13"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure14"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure15"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure16"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure17"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure18"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure19"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure20"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure21"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure22"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure23"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure24"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure25"] = row[index++].ToString();
        //    dataRow["ErrorLog"] = msg;

        //    logTable.Rows.Add(dataRow);
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        # endregion

        # endregion

        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<

        #region �� �������ڂ֕ϊ�����
        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// �������ڂ֕ϊ�����
        ///// </summary>
        ///// <param name="csvDataArr">CSV���ڔz��</param>
        ///// <param name="index">�C���f�b�N�X</param>
        ///// <returns>�ύX��������</returns>
        ///// <remarks>
        ///// <br>Note       : ���ڐ�������Ȃ��ꍇ�͍ŏ������֕ϊ������������s���B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private DateTime ConvertToDateTime(DataRow csvDataArr, Int32 index)
        //{
        //    DateTime retDt = DateTime.MinValue;

        //    if (index < csvDataArr.ItemArray.Length)
        //    {
        //        Int32 tmpNumber = ConvertToInt32(csvDataArr, index);
        //        if (tmpNumber != 0)
        //        {
        //            retDt = TDateTime.LongDateToDateTime(tmpNumber);
        //        }
        //    }

        //    return retDt;
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
        /// <summary>
        /// �������ڂ֕ϊ�����
        /// </summary>
        /// <param name="str">CSV���ڔz��</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͍ŏ������֕ϊ������������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private DateTime ConvertToDateTime(string str)
        {
            DateTime retDt = DateTime.MinValue;

            Int32 tmpNumber = ConvertToInt32(str);
            if (tmpNumber != 0)
            {
                retDt = TDateTime.LongDateToDateTime(tmpNumber);
            }

            return retDt;
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private string ConvertToEmpty(DataRow csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.ItemArray.Length)
            {
                retContent = csvDataArr[index].ToString();
            }

            return retContent;
        }
     
        #endregion

        #region �� �R�[�h�����񍀖ڂ̕ϊ�����
        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// �R�[�h�����񍀖ڂ̕ϊ�����
        ///// </summary>
        ///// <param name="csvDataArr">CSV���ڔz��</param>
        ///// <param name="index">�C���f�b�N�X</param>
        ///// <param name="maxLength">MAX����</param>
        ///// <returns>�ύX��������</returns>
        ///// <remarks>
        ///// <br>Note       : �R�[�h�����񍀖ڂ̕ϊ��������s���B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private string ConvertToStrCode(DataRow csvDataArr, Int32 index, Int32 maxLength)
        //{
        //    return ConvertToEmpty(csvDataArr, index).PadLeft(maxLength, '0');
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
        /// <summary>
        /// �R�[�h�����񍀖ڂ̕ϊ�����
        /// </summary>
        /// <param name="str">CSV���ڔz��</param>
        /// <param name="maxLength">MAX����</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�����񍀖ڂ̕ϊ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/03</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.94�ANO.106�ANO.107�ANO.108�̑Ή�</br>
        /// </remarks>
        private string ConvertToStrCode(string str, Int32 maxLength)
        {
            //return str.PadLeft(maxLength, '0');// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.56�̑Ή�
            // ------ ADD START 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.56�̑Ή�-------->>>>
            //if (!string.IsNullOrEmpty(str) && Convert.ToInt32(str.Trim()) != 0)// DEL  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
            if (!string.IsNullOrEmpty(str) && ConvertToInt32(str.Trim()) != 0)// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
            {
                return str.PadLeft(maxLength, '0');
            }
            else
            {
                // ------ DEL START 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.95�̑Ή�-------->>>>
                //if (Convert.ToInt32(str.Trim()) == 0)
                //{
                //    return string.Empty;
                //}
                //else
                //{
                //    return str;
                //}
                // ------ DEL END 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.95�̑Ή�--------<<<<
                return string.Empty;// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.95�̑Ή�
            }
            // ------ ADD END 2012/07/11 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.56�̑Ή�--------<<<<
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
        #endregion
        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// ���l���ڂ֕ϊ�����
        ///// </summary>
        ///// <param name="csvDataArr">CSV���ڔz��</param>
        ///// <param name="index">�C���f�b�N�X</param>
        ///// <returns>�ύX�������l</returns>
        ///// <remarks>
        ///// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private Int32 ConvertToInt32(DataRow csvDataArr, Int32 index)
        //{
        //    Int32 retNum = 0;

        //    if (index < csvDataArr.ItemArray.Length)
        //    {
        //        try
        //        {
        //            retNum = Convert.ToInt32(csvDataArr[index]);
        //        }
        //        catch
        //        {
        //            retNum = 0;
        //        }
        //    }

        //    return retNum;
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="str">CSV���ڔz��</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private Int32 ConvertToInt32(string str)
        {
            Int32 retNum = 0;
            try
            {
                retNum = Convert.ToInt32(str);
            }
            catch
            {
                retNum = 0;
            }
            return retNum;
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        ///// <summary>
        ///// ���l���ڂ֕ϊ�����
        ///// </summary>
        ///// <param name="csvDataArr">CSV���ڔz��</param>
        ///// <param name="index">�C���f�b�N�X</param>
        ///// <returns>�ύX�������l</returns>
        ///// <remarks>
        ///// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        
        //private Int32 ConvertRateToInt32(DataRow csvDataArr, Int32 index)
        //{
        //    Int32 retNum = 0;

        //    if (index < csvDataArr.ItemArray.Length)
        //    {
        //        try
        //        {
        //            if (Convert.ToInt32(csvDataArr[index]) >= 0)
        //            {
        //                retNum = Convert.ToInt32(csvDataArr[index]);
        //            }
        //            else
        //            {
        //                retNum = -1;
        //            }
        //        }
        //        catch
        //        {
        //            retNum = -1;
        //        }
        //    }

        //    return retNum;
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 ������-------->>>>
        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="str">CSV���ڔz��</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private Int32 ConvertRateToInt32(string str)
        {
            Int32 retNum = 0;

            try
            {
                if (Convert.ToInt32(str) >= 0)
                {
                    retNum = Convert.ToInt32(str);
                }
                else
                {
                    retNum = -1;
                }
            }
            catch
            {
                retNum = -1;
            }

            return retNum;
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 ������--------<<<<

        // --------------- DEL START 2012/07/03 Redmine#30393 ������-------->>>>
        //#region DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        ///// <summary>
        ///// DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        ///// </summary>
        ///// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        ///// <param name="searchWork">���������I�u�W�F�N�g</param>
        ///// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private CustomerWork ConvertToImportWork(CustomerWork csvWork, CustomerWork searchWork, bool isUpdFlg)
        //{
        //    CustomerWork importWork = new CustomerWork();
        //    if (isUpdFlg)
        //    {
        //        // �X�V�̏ꍇ
        //        importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
        //        importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
        //        importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
        //        importWork.LogicalDeleteCode = 0;                                   // �_���폜�敪
        //        importWork.PureCode = searchWork.PureCode;                          // �����敪
        //        importWork.TotalAmountDispWayCd = searchWork.TotalAmountDispWayCd;  // ���z�\�����@�敪
        //        importWork.TotalAmntDspWayRef = searchWork.TotalAmntDspWayRef;      // ���z�\�����@�Q�Ƌ敪
        //        importWork.BillPartsNoPrtCd = searchWork.BillPartsNoPrtCd;          // �i�Ԉ󎚋敪(������)
        //        importWork.DeliPartsNoPrtCd = searchWork.DeliPartsNoPrtCd;          // �i�Ԉ󎚋敪(�[�i���j
        //        importWork.DefSalesSlipCd = searchWork.DefSalesSlipCd;              // �`�[�敪�����l
        //        importWork.LavorRateRank = searchWork.LavorRateRank;                // �H�����o���[�g�����N
        //        importWork.SlipTtlPrn = searchWork.SlipTtlPrn;                      // �`�[�^�C�g���p�^�[��
        //        importWork.DepoBankCode = searchWork.DepoBankCode;                  // ������s�R�[�h
        //        importWork.DeliHonorificTtl = searchWork.DeliHonorificTtl;          // �[�i���h��
        //        importWork.BillHonorificTtl = searchWork.BillHonorificTtl;          // �������h��
        //        importWork.EstmHonorificTtl = searchWork.EstmHonorificTtl;          // ���Ϗ��h��
        //        importWork.RectHonorificTtl = searchWork.RectHonorificTtl;          // �̎����h��
        //        importWork.DeliHonorTtlPrtDiv = searchWork.DeliHonorTtlPrtDiv;      // �[�i���h�̈󎚋敪
        //        importWork.BillHonorTtlPrtDiv = searchWork.BillHonorTtlPrtDiv;      // �������h�̈󎚋敪
        //        importWork.EstmHonorTtlPrtDiv = searchWork.EstmHonorTtlPrtDiv;      // ���Ϗ��h�̈󎚋敪
        //        importWork.RectHonorTtlPrtDiv = searchWork.RectHonorTtlPrtDiv;      // �̎����h�̈󎚋敪
        //        importWork.CustomerEpCode = searchWork.CustomerEpCode;              // ���Ӑ��ƃR�[�h
        //        importWork.CustomerSecCode = searchWork.CustomerSecCode;            // ���Ӑ拒�_�R�[�h
        //        importWork.OnlineKindDiv = searchWork.OnlineKindDiv;                // �I�����C����ʋ敪
        //    }
        //    else
        //    {
        //        // �V�K�̏ꍇ
        //        importWork.PureCode = 0;                                            // �����敪
        //        importWork.TotalAmountDispWayCd = 0;                                // ���z�\�����@�敪
        //        importWork.TotalAmntDspWayRef = 0;                                  // ���z�\�����@�Q�Ƌ敪
        //        importWork.BillPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(������)
        //        importWork.DeliPartsNoPrtCd = 0;                                    // �i�Ԉ󎚋敪(�[�i���j
        //        importWork.DefSalesSlipCd = 0;                                      // �`�[�敪�����l
        //        importWork.LavorRateRank = 0;                                       // �H�����o���[�g�����N
        //        importWork.SlipTtlPrn = 0;                                          // �`�[�^�C�g���p�^�[��
        //        importWork.DepoBankCode = 0;                                        // ������s�R�[�h
        //        importWork.DeliHonorificTtl = string.Empty;                         // �[�i���h��
        //        importWork.BillHonorificTtl = string.Empty;                         // �������h��
        //        importWork.EstmHonorificTtl = string.Empty;                         // ���Ϗ��h��
        //        importWork.RectHonorificTtl = string.Empty;                         // �̎����h��
        //        importWork.DeliHonorTtlPrtDiv = 0;                                  // �[�i���h�̈󎚋敪
        //        importWork.BillHonorTtlPrtDiv = 0;                                  // �������h�̈󎚋敪
        //        importWork.EstmHonorTtlPrtDiv = 0;                                  // ���Ϗ��h�̈󎚋敪
        //        importWork.RectHonorTtlPrtDiv = 0;                                  // �̎����h�̈󎚋敪
        //        importWork.CustomerEpCode = string.Empty;                           // ���Ӑ��ƃR�[�h
        //        importWork.CustomerSecCode = string.Empty;                          // ���Ӑ拒�_�R�[�h
        //        importWork.OnlineKindDiv = 0;                                       // �I�����C����ʋ敪

        //    }
        //    importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // ��ƃR�[�h
        //    importWork.CustomerCode = csvWork.CustomerCode;                         // ���Ӑ�R�[�h
        //    importWork.CustomerSubCode = csvWork.CustomerSubCode;                   // �T�u�R�[�h
        //    importWork.Name = csvWork.Name;                                         // ����
        //    importWork.Name2 = csvWork.Name2;                                       // ���̂Q
        //    importWork.CustomerSnm = csvWork.CustomerSnm;                           // ���Ӑ旪��
        //    importWork.Kana = csvWork.Kana;                                         // �J�i
        //    importWork.HonorificTitle = csvWork.HonorificTitle;                     // �h��
        //    importWork.OutputNameCode = csvWork.OutputNameCode;                     // �����R�[�h
        //    importWork.OutputName = GetOutputName(csvWork.OutputNameCode);          // ��������
        //    importWork.MngSectionCode = csvWork.MngSectionCode;                     // �Ǘ����_�R�[�h
        //    importWork.InpSectionCode = csvWork.MngSectionCode;                     // ���͋��_�R�[�h
        //    importWork.CustomerAgentCd = csvWork.CustomerAgentCd;                   // �ڋq�S���]�ƈ��R�[�h
        //    importWork.OldCustomerAgentCd = csvWork.OldCustomerAgentCd;             // ���ڋq�S���]�ƈ��R�[�h
        //    importWork.CustAgentChgDate = csvWork.CustAgentChgDate;                 // �ڋq�S���ύX��
        //    importWork.TransStopDate = csvWork.TransStopDate;                       // ������~��
        //    importWork.CarMngDivCd = csvWork.CarMngDivCd;                           // ���q�Ǘ��敪
        //    importWork.CorporateDivCode = csvWork.CorporateDivCode;                 // �l�E�@�l�敪
        //    importWork.AcceptWholeSale = csvWork.AcceptWholeSale;                   // �Ɣ̐�敪
        //    importWork.CustomerAttributeDiv = csvWork.CustomerAttributeDiv;         // ���Ӑ摮���敪
        //    importWork.CustWarehouseCd = csvWork.CustWarehouseCd;                   // ���Ӑ�D��q�ɃR�[�h
        //    importWork.BusinessTypeCode = csvWork.BusinessTypeCode;                 // �Ǝ�R�[�h
        //    importWork.JobTypeCode = csvWork.JobTypeCode;                           // �E��R�[�h
        //    importWork.SalesAreaCode = csvWork.SalesAreaCode;                       // �̔��G���A�R�[�h
        //    importWork.CustAnalysCode1 = csvWork.CustAnalysCode1;                   // ���Ӑ敪�̓R�[�h�P
        //    importWork.CustAnalysCode2 = csvWork.CustAnalysCode2;                   // ���Ӑ敪�̓R�[�h�Q
        //    importWork.CustAnalysCode3 = csvWork.CustAnalysCode3;                   // ���Ӑ敪�̓R�[�h�R
        //    importWork.CustAnalysCode4 = csvWork.CustAnalysCode4;                   // ���Ӑ敪�̓R�[�h�S
        //    importWork.CustAnalysCode5 = csvWork.CustAnalysCode5;                   // ���Ӑ敪�̓R�[�h�T
        //    importWork.CustAnalysCode6 = csvWork.CustAnalysCode6;                   // ���Ӑ敪�̓R�[�h�U
        //    importWork.ClaimSectionCode = csvWork.ClaimSectionCode;                 // �������_�R�[�h
        //    importWork.ClaimCode = csvWork.ClaimCode;                               // ������R�[�h
        //    importWork.TotalDay = csvWork.TotalDay;                                 // ����
        //    importWork.CollectMoneyCode = csvWork.CollectMoneyCode;                 // �W�����敪�R�[�h
        //    importWork.CollectMoneyName = GetCollectMoneyName(csvWork.CollectMoneyCode);// �W�����敪����
        //    importWork.CollectMoneyDay = csvWork.CollectMoneyDay;                   // �W����
        //    importWork.CollectCond = csvWork.CollectCond;                           // �������
        //    importWork.CollectSight = csvWork.CollectSight;                         // ����T�C�g
        //    importWork.NTimeCalcStDate = csvWork.NTimeCalcStDate;                   // ���񊨒�J�n��
        //    importWork.BillCollecterCd = csvWork.BillCollecterCd;                   // �W���S���]�ƈ��R�[�h
        //    importWork.CustCTaXLayRefCd = csvWork.CustCTaXLayRefCd;                 // ���Ӑ����œ]�ŕ����Q�Ƌ敪
        //    importWork.ConsTaxLayMethod = csvWork.ConsTaxLayMethod;                 // ����œ]�ŕ���
        //    importWork.SalesUnPrcFrcProcCd = csvWork.SalesUnPrcFrcProcCd;           // ����P���[�������R�[�h
        //    importWork.SalesMoneyFrcProcCd = csvWork.SalesMoneyFrcProcCd;           // ������z�[�������R�[�h
        //    importWork.SalesCnsTaxFrcProcCd = csvWork.SalesCnsTaxFrcProcCd;         // �������Œ[�������R�[�h
        //    importWork.CreditMngCode = csvWork.CreditMngCode;                       // �^�M�Ǘ��敪
        //    importWork.DepoDelCode = csvWork.DepoDelCode;                           // ���������敪
        //    importWork.AccRecDivCd = csvWork.AccRecDivCd;                           // ���|�敪
        //    importWork.PostNo = csvWork.PostNo;                                     // �X�֔ԍ�
        //    importWork.Address1 = csvWork.Address1;                                 // �Z��1(�s���{���s��S�E�����E���j
        //    importWork.Address3 = csvWork.Address3;                                 // �Z��3(�Ԓn�j
        //    importWork.Address4 = csvWork.Address4;                                 // �Z��4(�A�p�[�g���́j
        //    importWork.CustomerAgent = csvWork.CustomerAgent;                       // ���Ӑ�S����
        //    importWork.HomeTelNo = csvWork.HomeTelNo;                               // �d�b�ԍ�(����j
        //    importWork.OfficeTelNo = csvWork.OfficeTelNo;                           // �d�b�ԍ�(�Ζ���j
        //    importWork.PortableTelNo = csvWork.PortableTelNo;                       // �d�b�ԍ�(�g�сj
        //    importWork.OthersTelNo = csvWork.OthersTelNo;                           // �d�b�ԍ�(���̑��j
        //    importWork.HomeFaxNo = csvWork.HomeFaxNo;                               // FAX�ԍ�(����j
        //    importWork.OfficeFaxNo = csvWork.OfficeFaxNo;                           // FAX�ԍ�(�Ζ���j
        //    importWork.SearchTelNo = csvWork.SearchTelNo;                           // �d�b�ԍ�(�����p��4���j
        //    importWork.MainContactCode = csvWork.MainContactCode;                   // ��A����敪
        //    importWork.Note1 = csvWork.Note1;                                       // ���l�P
        //    importWork.Note2 = csvWork.Note2;                                       // ���l�Q
        //    importWork.Note3 = csvWork.Note3;                                       // ���l�R
        //    importWork.Note4 = csvWork.Note4;                                       // ���l�S
        //    importWork.Note5 = csvWork.Note5;                                       // ���l�T
        //    importWork.Note6 = csvWork.Note6;                                       // ���l�U
        //    importWork.Note7 = csvWork.Note7;                                       // ���l�V
        //    importWork.Note8 = csvWork.Note8;                                       // ���l�W
        //    importWork.Note9 = csvWork.Note9;                                       // ���l�X
        //    importWork.Note10 = csvWork.Note10;                                     // ���l�P�O
        //    importWork.MainSendMailAddrCd = csvWork.MainSendMailAddrCd;             // �呗�M�惁�[���A�h���X�敪
        //    importWork.MailAddress1 = csvWork.MailAddress1;                         // ���[���A�h���X1
        //    importWork.MailSendCode1 = csvWork.MailSendCode1;                       // ���[�����M�敪�R�[�h1
        //    importWork.MailSendName1 = GetMailSendName1(csvWork.MailSendCode1);     // ���[�����M�敪����1
        //    importWork.MailAddrKindCode1 = csvWork.MailAddrKindCode1;               // ���[���A�h���X��ʃR�[�h1
        //    importWork.MailAddrKindName1 = GetMailAddrKindName1(csvWork.MailAddrKindCode1); // ���[���A�h���X��ʖ���1
        //    importWork.MailAddress2 = csvWork.MailAddress2;                         // ���[���A�h���X�Q
        //    importWork.MailSendCode2 = csvWork.MailSendCode2;                       // ���[�����M�敪�R�[�h�Q
        //    importWork.MailSendName2 = GetMailSendName2(csvWork.MailSendCode2);     // ���[�����M�敪����1
        //    importWork.MailAddrKindCode2 = csvWork.MailAddrKindCode2;               // ���[���A�h���X��ʃR�[�h�Q
        //    importWork.MailAddrKindName2 = GetMailAddrKindName2(csvWork.MailAddrKindCode2); // ���[���A�h���X��ʖ���1
        //    importWork.AccountNoInfo1 = csvWork.AccountNoInfo1;                     // ��s�����P
        //    importWork.AccountNoInfo2 = csvWork.AccountNoInfo2;                     // ��s�����Q
        //    importWork.AccountNoInfo3 = csvWork.AccountNoInfo3;                     // ��s�����R
        //    importWork.BillOutputCode = csvWork.BillOutputCode;                     // �������o�͋敪�R�[�h
        //    importWork.BillOutputName = GetBillOutputName(csvWork.BillOutputCode);  // �������o�͋敪����
        //    importWork.ReceiptOutputCode = csvWork.ReceiptOutputCode;               // �̎����o�͋敪�R�[�h
        //    importWork.DmOutCode = csvWork.DmOutCode;                               // DM�o�͋敪
        //    importWork.DmOutName = GetDmOutName(csvWork.DmOutCode);                 // DM�o�͋敪����
        //    importWork.SalesSlipPrtDiv = csvWork.SalesSlipPrtDiv;                   // ����`�[���s�敪
        //    importWork.AcpOdrrSlipPrtDiv = csvWork.AcpOdrrSlipPrtDiv;               // �󒍓`�[���s�敪
        //    importWork.ShipmSlipPrtDiv = csvWork.ShipmSlipPrtDiv;                   // �o�ד`�[���s�敪
        //    importWork.EstimatePrtDiv = csvWork.EstimatePrtDiv;                     // ���Ϗ����s�敪
        //    importWork.UOESlipPrtDiv = csvWork.UOESlipPrtDiv;                       // UOE�`�[���s�敪
        //    importWork.QrcodePrtCd = csvWork.QrcodePrtCd;                           // QR�R�[�h���
        //    importWork.CustSlipNoMngCd = csvWork.CustSlipNoMngCd;                   // ����`�[�ԍ��Ǘ��敪
        //    importWork.CustomerSlipNoDiv = csvWork.CustomerSlipNoDiv;               // ���Ӑ�`�[�ԍ��敪
        //    importWork.TotalBillOutputDiv = csvWork.TotalBillOutputDiv;             // ���v�������o�͋敪
        //    importWork.DetailBillOutputCode = csvWork.DetailBillOutputCode;         // ���א������o�͋敪
        //    importWork.SlipTtlBillOutputDiv = csvWork.SlipTtlBillOutputDiv;         // �`�[���v�������o�͋敪

        //    return importWork;
        //}
        //#endregion
        // --------------- DEL END 2012/07/03 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        #region DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// <summary>
        /// DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private CustRateGroupWork ConvertToImportRateWork(CustRateGroupWork csvWork, CustRateGroupWork searchWork, bool isUpdFlg)
        {
            CustRateGroupWork importWork = new CustRateGroupWork();
            if (isUpdFlg)
            {
                // �X�V�̏ꍇ
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // �_���폜�敪
            }
            importWork.CustRateGrpCode = csvWork.CustRateGrpCode;                   //���Ӑ�|���O���[�v�R�[�h
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // ��ƃR�[�h
            importWork.CustomerCode = csvWork.CustomerCode;                         // ���Ӑ�R�[�h
            importWork.PureCode = csvWork.PureCode;                                 // �����敪
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         //���i���[�J�[�R�[�h
            return importWork;
        }
        #endregion
        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
        // --------------- ADD START 2023/06/28 3H ���� -------->>>>
        #region �������̂̎擾
        /// <summary>
        /// �������̂̎擾
        /// </summary>
        /// <param name="code">�����R�[�h</param>
        /// <returns>����</returns>
        /// <br>Note       : �������̂̎擾�������s��</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2023/06/28</br>
        private string GetOutputNameNew(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "���Ӑ於�̂P�E�Q";
                    break;
                case 1:
                    retName = "���Ӑ於�̂P";
                    break;
                case 2:
                    retName = "���Ӑ於�̂Q";
                    break;
                case 3:
                    retName = "��������";
                    break;
            }
            return retName;
        }
        #endregion
        // --------------- ADD END 2023/06/28 3H ����--------<<<<
        #region �������̂̎擾
        /// <summary>
        /// �������̂̎擾
        /// </summary>
        /// <param name="code">�����R�[�h</param>
        /// <returns>����</returns>
        /// <br>Note       : �������̂̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetOutputName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "�ڋq���̂P�E�Q";
                    break;
                case 1:
                    retName = "�ڋq���̂P";
                    break;
                case 2:
                    retName = "�ڋq���̂Q";
                    break;
                case 3:
                    retName = "��������";
                    break;
            }
            return retName;
        }
        #endregion

        #region �������o�͋敪���̂̎擾
        /// <summary>
        /// �������o�͋敪���̂̎擾
        /// </summary>
        /// <param name="code">�������o�͋敪�R�[�h</param>
        /// <returns>����</returns>
        /// <br>Note       : �������o�͋敪���̂̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetBillOutputName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "����";
                    break;
                case 1:
                    retName = "���Ȃ�";
                    break;
            }
            return retName;
        }
        #endregion

        #region �W�����敪���̂̎擾
        /// <summary>
        /// �W�����敪���̂̎擾
        /// </summary>
        /// <param name="code">�W�����敪�R�[�h</param>
        /// <returns>����</returns>
        /// <br>Note       : �W�����敪���̂̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetCollectMoneyName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "����";
                    break;
                case 1:
                    retName = "����";
                    break;
                case 2:
                    retName = "���X��";
                    break;
                case 3:
                    retName = "���X�X��";
                    break;
            }
            return retName;
        }
        #endregion

        #region DM�o�͋敪���̂̎擾
        /// <summary>
        /// DM�o�͋敪���̂̎擾
        /// </summary>
        /// <param name="code">DM�o�͋敪</param>
        /// <returns>����</returns>
        /// <br>Note       : DM�o�͋敪���̂̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetDmOutName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "����";
                    break;
                case 1:
                    retName = "���Ȃ�";
                    break;
            }
            return retName;
        }
        #endregion

        #region ���[���A�h���X��ʖ���1�̎擾
        /// <summary>
        /// ���[���A�h���X��ʖ���1�̎擾
        /// </summary>
        /// <param name="code">���[���A�h���X��ʃR�[�h�P</param>
        /// <returns>����</returns>
        /// <br>Note       : ���[���A�h���X��ʖ���1�̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailAddrKindName1(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "����";
                    break;
                case 1:
                    retName = "���";
                    break;
                case 2:
                    retName = "�g�ђ[��";
                    break;
                case 3:
                    retName = "�{�l�ȊO";
                    break;
                case 99:
                    retName = "���̑�";
                    break;
            }
            return retName;
        }
        #endregion

        #region ���[�����M�敪����1�̎擾
        /// <summary>
        /// ���[�����M�敪����1�̎擾
        /// </summary>
        /// <param name="code">���[�����M�敪�R�[�h�P</param>
        /// <returns>����</returns>
        /// <br>Note       : ���[�����M�敪����1�̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailSendName1(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "���M���Ȃ�";
                    break;
                case 1:
                    retName = "���M����";
                    break;
            }
            return retName;
        }
        #endregion

        #region ���[���A�h���X��ʖ���2�̎擾
        /// <summary>
        /// ���[���A�h���X��ʖ���2�̎擾
        /// </summary>
        /// <param name="code">���[���A�h���X��ʃR�[�h�Q</param>
        /// <returns>����</returns>
        /// <br>Note       : ���[���A�h���X��ʖ���2�̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailAddrKindName2(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "����";
                    break;
                case 1:
                    retName = "���";
                    break;
                case 2:
                    retName = "�g�ђ[��";
                    break;
                case 3:
                    retName = "�{�l�ȊO";
                    break;
                case 99:
                    retName = "���̑�";
                    break;
            }
            return retName;
        }
        #endregion

        #region ���[�����M�敪����2�̎擾
        /// <summary>
        /// ���[�����M�敪����2�̎擾
        /// </summary>
        /// <param name="code">���[�����M�敪�R�[�h�Q</param>
        /// <returns>����</returns>
        /// <br>Note       : ���[�����M�敪����2�̎擾�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailSendName2(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "���M���Ȃ�";
                    break;
                case 1:
                    retName = "���M����";
                    break;
            }
            return retName;
        }
        #endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion
    }

    #region ���Ӑ���I�u�W�F�N�g
    /// <summary>
    /// ���Ӑ���I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ���I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class CustomerImportWorkWrap
    {
        #region Public Field
        public CustomerWork customerWork;
        #endregion

        #region �N���X�R���X�g���N�^
        /// <summary>
        /// ���Ӑ���I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ���I�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public CustomerImportWorkWrap(CustomerWork customer)
        {
            this.customerWork = customer;
        }
        #endregion

        #region ���Ӑ���I�u�W�F�N�g�̃C�R�[���̔�r
        /// <summary>
        /// ���Ӑ���I�u�W�F�N�g�̃C�R�[���̔�r
        /// </summary>
        /// <param name="obj">���Ӑ���I�u�W�F�N�g</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            CustomerImportWorkWrap target = obj as CustomerImportWorkWrap;
            if (target == null) return false;
            // ��ƃR�[�h�A���Ӑ�R�[�h
            // �������ꍇ�A���Ӑ���I�u�W�F�N�g�̓C�R�[���ɂ���B
            return target.customerWork.EnterpriseCode == customerWork.EnterpriseCode
                     && target.customerWork.CustomerCode == customerWork.CustomerCode;
        }
        #endregion

        #region ���Ӑ���I�u�W�F�N�g�̃n�V�R�[�h
        /// <summary>
        /// ���Ӑ���I�u�W�F�N�g�̃n�V�R�[�h
        /// </summary>
        /// <returns>�n�V�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return customerWork.EnterpriseCode.GetHashCode()
                     + customerWork.CustomerCode.GetHashCode();
        }
        #endregion
    }
    #endregion

    // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
    #region ���Ӑ�|���O���[�v�I�u�W�F�N�g
    /// <summary>
    /// ���Ӑ�|���O���[�v�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�|���O���[�v�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class CustomerRateImportWorkWrap
    {
        #region Public Field
        public CustRateGroupWork custRateGroupWork;
        #endregion

        #region �N���X�R���X�g���N�^
        /// <summary>
        /// ���Ӑ�|���O���[�v�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�I�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public CustomerRateImportWorkWrap(CustRateGroupWork custRateGroup)
        {
            this.custRateGroupWork = custRateGroup;
        }
        #endregion

        #region ���Ӑ�|���O���[�v�I�u�W�F�N�g�̃C�R�[���̔�r
        /// <summary>
        /// ���Ӑ�|���O���[�v�I�u�W�F�N�g�̃C�R�[���̔�r
        /// </summary>
        /// <param name="obj">���Ӑ�|���O���[�v�I�u�W�F�N�g</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            CustomerRateImportWorkWrap target = obj as CustomerRateImportWorkWrap;
            if (target == null) return false;
            // ��ƃR�[�h�A���Ӑ�R�[�h
            // �������ꍇ�A���Ӑ���I�u�W�F�N�g�̓C�R�[���ɂ���B
            return target.custRateGroupWork.EnterpriseCode == custRateGroupWork.EnterpriseCode
                     && target.custRateGroupWork.CustomerCode == custRateGroupWork.CustomerCode
                     && target.custRateGroupWork.PureCode == custRateGroupWork.PureCode
                     && target.custRateGroupWork.GoodsMakerCd == custRateGroupWork.GoodsMakerCd;
        }
        #endregion

        #region ���Ӑ�|���O���[�v�I�u�W�F�N�g�̃n�V�R�[�h
        /// <summary>
        /// ���Ӑ�|���O���[�v�I�u�W�F�N�g�̃n�V�R�[�h
        /// </summary>
        /// <returns>�n�V�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return custRateGroupWork.EnterpriseCode.GetHashCode()
                     + custRateGroupWork.CustomerCode.GetHashCode()
                     + custRateGroupWork.PureCode.GetHashCode()
                     + custRateGroupWork.GoodsMakerCd.GetHashCode();
        }
        #endregion
    }
    #endregion
    // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
}
