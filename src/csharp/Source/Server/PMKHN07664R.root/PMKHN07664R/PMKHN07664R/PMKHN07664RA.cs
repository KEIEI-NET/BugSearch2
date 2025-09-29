//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�Ǘ����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/06/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2012/07/03  �C�����e : ���q�l�̎w�E�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2012/07/13  �C�����e : ���q�l�̎w�E�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/19  �C�����e : ��Q�ꗗ�̎w�ENO.110�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/25  �C�����e : ��Q�ꗗ�̎w�ENO.106�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� :������
// �C �� ��  2012/07/26  �C�����e :��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.94�̑Ή� �G���[���b�Z�[�W�̕ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/09/24�@�C�����e : 2012/10/17�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B                             
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Ǘ����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/26 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.94�̑Ή� �G���[���b�Z�[�W�̕ύX�̑Ή�</br>
    /// <br>Update Note: 2012/09/24 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
    /// </remarks>
    [Serializable]
    public class GoodsMngImportDB : RemoteDB, IGoodsMngImportDB
    {
        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// </remarks>
        public GoodsMngImportDB()
            : base("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "GOODSMNGRF")
        {
        }
        /* --- DEL 2012/07/03 ���� ----- >>>>>
        #region �� Private Member
        // �e�[�u������
        private const string PRINTSET_TABLE = "GoodsMngExp";
        // ���_�R�[�h
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // ���i�ԍ�
        private const string GOODSNO_COLUMN = "GoodsNoRF";
        // ���i���[�J�[�R�[�h
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        // �d����R�[�h
        private const string SUPPLIERCD_COLUMN = "SupplierCdRF";
        // �������b�g
        private const string SUPPLIERLOT_COLUMN = "SupplierLotRF";
        //�G���[���b�Z�[�W
        private const string GOODS_ERROR = "GoodsErrorRF";

        #endregion
           --- DEL 2012/07/03 ���� ----- <<<<<*/

        # region [Import]
        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="checkKbn">�`�F�b�N�敪</param>
        /// <param name="importGoodsWorkList">���i�Ǘ����}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataList">�G���[�e�[�u���p</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// </remarks>
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt,out Int32 errCnt, out DataTable dataTable, out string errMsg) // DEL 2012/07/03 ����
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out ArrayList dataList, out string errMsg)   // ADD 2012/07/03 ���� // ---DEL 2012/07/13 ����
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataList, out string errMsg)   // ---ADD 2012/07/13 ����  // DEL 2012/07/19 �L�w��
        public int Import(Int32 processKbn, Int32 checkKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataList, out string errMsg)   // ADD 2012/07/19 �L�w��
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;
            //dataTable = null;// DEL 2012/07/03 ����
            dataList = null;   // ADD 2012/07/03 ����

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // �C���|�[�g����
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataTable, out errMsg, ref sqlConnection, ref sqlTransaction);// DEL 2012/07/03 ����
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataList, out errMsg, ref sqlConnection, ref sqlTransaction);   // ADD 2012/07/03 ����   // DEL 2012/07/19 �L�w��
                status = this.ImportProc(processKbn, checkKbn, ref importGoodsWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataList, out errMsg, ref sqlConnection, ref sqlTransaction);    // ADD 2012/07/19 �L�w��
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

        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="checkKbn">�`�F�b�N�敪</param>
        /// <param name="importGoodsWorkList">���i�Ǘ����}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataObjectList">�G���[�e�[�u���p</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R���N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// <br>Update Note: 2012/09/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
        /// </remarks>
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out DataTable dataTable, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) // DEL 2012/07/03 ����
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out ArrayList dataList, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)    // ADD 2012/07/03 ���� // ---DEL 2012/07/13 ����
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataObjectList, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)    // ---ADD 2012/07/13 ����  //DEL �L�w�� 2012/07/19 
        private int ImportProc(Int32 processKbn, Int32 checkKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataObjectList, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)    //ADD �L�w�� 2012/07/19 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            //dataTable = null;// DEL 2012/07/03 ����
            //dataList = null;   // ADD 2012/07/03 ���� // ---DEL 2012/07/13 ����
            dataObjectList = null; // ---ADD 2012/07/13 ����
            errMsg = string.Empty;

            ArrayList GoodsMngList = new ArrayList();
            GoodsMngWork paraGoodsMngWork = new GoodsMngWork();

            // ���i�Ǘ����}�X�^��DB�����[�g�N���X
            GoodsMngDB GoodsMngDB = new GoodsMngDB();

            string enterpriseCode = string.Empty;

            try
            {
                // �p�����[�^�̐ݒ�
                // ���i�Ǘ����}�X�^�̃p�����[�^�̐ݒ�
                ArrayList importGoodsWorkArray = importGoodsWorkList as ArrayList;
                if (importGoodsWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    enterpriseCode = ((ImportGoodsMngWork)importGoodsWorkArray[0]).EnterpriseCode;
                    paraGoodsMngWork.EnterpriseCode = enterpriseCode;
                }

                // �S�������������s��
                // �S�ď��i�Ǘ����}�X�^�̃f�[�^�̌�������
                GoodsMngDB.SearchGoodsMngProc(out GoodsMngList, paraGoodsMngWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
                ArrayList secList = new ArrayList();
                // �S���������ʂ�Dictionary�Ɋi�[����
                // ���i�Ǘ����}�X�^��Dictionary�̍쐬
                Dictionary<string, GoodsMngWork> goodsMngDict = new Dictionary<string, GoodsMngWork>();
                foreach (GoodsMngWork work in GoodsMngList)
                {
                    // --- DEL ������ 2012/09/24 for Redmine#32367---------->>>>>
                    //string key = work.EnterpriseCode + "-" + work.SectionCode.Trim() + "-"
                    //             + work.GoodsMGroup.ToString() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0')
                    //             + "-" + work.BLGoodsCode.ToString() + "-" + work.GoodsNo.Trim();
                    // --- DEL ������ 2012/09/24 for Redmine#32367----------<<<<<
                    // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
                    string key = work.EnterpriseCode + "-" + work.SectionCode.Trim() + "-"
                                 + work.GoodsMGroup.ToString().PadLeft(4, '0') + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0')
                                 + "-" + work.BLGoodsCode.ToString().PadLeft(5, '0') + "-" + work.GoodsNo.Trim();
                    // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
                    goodsMngDict.Add(key, work);
                }

                // �ǉ��ƍX�V�f�[�^�̍쐬
                // ���i�Ǘ����}�X�^�̒ǉ����X�g
                ArrayList addGoodsMngList = new ArrayList();
                // ���i�Ǘ����}�X�^�̍X�V���X�g
                ArrayList updGoodsMngList = new ArrayList();

                // ���i�Ǘ����}�X�^�̃G���[table 
                //dataList = new ArrayList();                 // ADD 2012/07/03 ���� // ---DEL 2012/07/13 ����
                ArrayList dataList = new ArrayList();         // ---ADD 2012/07/13 ����
                //dataTable = new DataTable(PRINTSET_TABLE);// DEL 2012/07/03 ����
                //CreateDataTable(ref dataTable);           // DEL 2012/07/03 ����

                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                // ���i�Ǘ����}�X�^�`�F�b�N
                ArrayList importCheckWorkList = importGoodsWorkList as ArrayList;
                List<ImportGoodsMngWork> lst = new List<ImportGoodsMngWork>();
                ImportGoodsMngWork[] GoodsMngArray = (ImportGoodsMngWork[])importCheckWorkList.ToArray(typeof(ImportGoodsMngWork));
                lst.AddRange(GoodsMngArray);
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<

                foreach (ImportGoodsMngWork importWork in importGoodsWorkArray)
                {
                    string sectionCd = "";
                    string goodsMk = "";
                    // --- ADD ������ 2012/09/24 for Redmine#32367-->>>>>
                    string blGoodsCd = "";
                    string goodsMGroup = "";
                    // --- ADD ������ 2012/09/24 for Redmine#32367--<<<<<
                    //���_�R�[�h
                    if (!string.IsNullOrEmpty(importWork.SectionCode.Trim()))
                    {
                        sectionCd = importWork.SectionCode.Trim().PadLeft(2, '0');
                    }
                    else
                    {
                        sectionCd = importWork.SectionCode.Trim();
                    }
                    //���[�J�[�R�[�h
                    if (!string.IsNullOrEmpty(importWork.GoodsMakerCd.ToString().Trim()))
                    {
                        goodsMk = importWork.GoodsMakerCd.Trim().PadLeft(4, '0');
                    }
                    else
                    {
                        goodsMk = importWork.GoodsMakerCd.Trim();
                    }

                    // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
                    //BL���i�R�[�h
                    if (!string.IsNullOrEmpty(importWork.BLGoodsCode.ToString().Trim()))
                    {
                        blGoodsCd = importWork.BLGoodsCode.Trim().PadLeft(5, '0');
                    }
                    else
                    {
                        blGoodsCd = importWork.BLGoodsCode.Trim();
                    }
                    //���i�����ރR�[�h
                    if (!string.IsNullOrEmpty(importWork.GoodsMGroup.ToString().Trim()))
                    {
                        goodsMGroup = importWork.GoodsMGroup.Trim().PadLeft(4, '0');
                    }
                    else
                    {
                        goodsMGroup = importWork.GoodsMGroup.Trim();
                    }

                    string key = importWork.EnterpriseCode + "-" + sectionCd + "-"
                                 + goodsMGroup + "-" + goodsMk + "-"
                                 + blGoodsCd + "-" + importWork.GoodsNo.Trim();
                    // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
                    // --- DEL ������ 2012/09/24 for Redmine#32367---------->>>>>
                    //string key = importWork.EnterpriseCode + "-" + sectionCd + "-"
                    //             + importWork.GoodsMGroup.ToString() + "-" + goodsMk + "-"
                    //             + importWork.BLGoodsCode.ToString() + "-" + importWork.GoodsNo.Trim();
                    // --- DEL ������ 2012/09/24 for Redmine#32367----------<<<<<
                    if (!goodsMngDict.ContainsKey(key))
                    {
                        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                        addGoodsMngList.Add(ConvertToGoodsMngImportWork(importWork, null, false));
                    }
                    else
                    {
                        // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                        updGoodsMngList.Add(ConvertToGoodsMngImportWork(importWork, goodsMngDict[key], true));
                    }
                }

                // �Ǎ�����
                readCnt = importGoodsWorkArray.Count;

                // �R���N�V�����ƃg�����U�N�V����
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                ArrayList addUpdList = new ArrayList();
                ArrayList addUpdWorkList = new ArrayList();

                // �����敪���u�ǉ��v�̏ꍇ
                if (processKbn == 1)
                {
                    if (addGoodsMngList != null && addGoodsMngList.Count > 0)
                    {
                        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                        //AddUpdListCheck(addGoodsMngList, out addUpdList, ref errCnt, ref dataTable);// DEL 2012/07/03 ����
                        //AddUpdListCheck(addGoodsMngList, out addUpdList, ref errCnt, ref dataList);   // ADD 2012/07/03 ����  // DEL 2012/07/19 �L�w��
                        AddUpdListCheck(addGoodsMngList, out addUpdList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 �L�w��
                        dataObjectList = dataList; // ---ADD 2012/07/13 ����

                        WriteAddUpdListCheck(addUpdList, out addUpdWorkList);

                        // ���i�Ǘ����}�X�^�̓o�^����
                        status = GoodsMngDB.WriteGoodsMngProc(ref addUpdWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addUpdList.Count;
                        }
                    }
                }
                // �����敪���u�X�V�v�̏ꍇ
                else if (processKbn == 2)
                {
                    if (updGoodsMngList != null && updGoodsMngList.Count > 0)
                    {

                        // ���R�[�h�����݂��Ȃ���΁A�X�V���X�g�֒ǉ�����B
                        //AddUpdListCheck(updGoodsMngList, out addUpdList, ref errCnt, ref dataTable);// DEL 2012/07/03 ����
                        //AddUpdListCheck(updGoodsMngList, out addUpdList, ref errCnt, ref dataList);   // ADD 2012/07/03 ����  // DEL 2012/07/19 �L�w��
                        AddUpdListCheck(updGoodsMngList, out addUpdList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 �L�w��
                        dataObjectList = dataList; // ---ADD 2012/07/13 ����
                        WriteAddUpdListCheck(addUpdList, out addUpdWorkList);

                        // ���i�Ǘ����}�X�^�̍X�V����
                        status = GoodsMngDB.WriteGoodsMngProc(ref addUpdWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            updCnt = addUpdList.Count;
                        }
                    }
                }
                // �����敪���u�ǉ��X�V�v�̏ꍇ
                else
                {
                    // �o�^�X�V���X�g�̍쐬
                    ArrayList addUpdGoodsMngList = new ArrayList();
                    ArrayList addList = new ArrayList();
                    ArrayList updList = new ArrayList();

                    // �ǉ�
                    if (addGoodsMngList != null && addGoodsMngList.Count > 0)
                    {
                        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                        //AddUpdListCheck(addGoodsMngList, out addList, ref errCnt, ref dataTable);// DEL 2012/07/03 ����
                        //AddUpdListCheck(addGoodsMngList, out addList, ref errCnt, ref dataList);   // ADD 2012/07/03 ����  // DEL 2012/07/19 �L�w��
                        AddUpdListCheck(addGoodsMngList, out addList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 �L�w��
                    }

                    if (addList.Count > 0)
                    {
                        addUpdGoodsMngList.AddRange(addList.GetRange(0, addList.Count));
                    }

                    // �X�V
                    if (updGoodsMngList != null && updGoodsMngList.Count > 0)
                    {
                        // ���R�[�h�����݂��Ȃ���΁A�X�V���X�g�֒ǉ�����B
                        //AddUpdListCheck(updGoodsMngList, out updList, ref errCnt, ref dataTable);// DEL 2012/07/03 ����
                        //AddUpdListCheck(updGoodsMngList, out updList, ref errCnt, ref dataList);   // ADD 2012/07/03 ����  // DEL 2012/07/19 �L�w��
                        AddUpdListCheck(updGoodsMngList, out updList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 �L�w��
                    }
                    dataObjectList = dataList; // ---ADD 2012/07/13 ����

                    if (updList.Count > 0)
                    {
                        addUpdGoodsMngList.AddRange(updList.GetRange(0, updList.Count));
                    }
                    if (addUpdGoodsMngList.Count > 0)
                    {
                        WriteAddUpdListCheck(addUpdGoodsMngList, out addUpdWorkList);

                        // ���i�Ǘ����}�X�^�̓o�^�X�V����
                        status = GoodsMngDB.WriteGoodsMngProc(ref addUpdWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null)
                    {
                        readCnt = 0;
                        addCnt = 0;
                        updCnt = 0;
                        sqlTransaction.Rollback();
                    }
                }

            }
            catch (SqlException ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errCnt = 0;
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// ���i�Ǘ����}�X�^��DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/09/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
        /// </remarks>
        private ImportGoodsMngWork ConvertToGoodsMngImportWork(ImportGoodsMngWork csvWork, GoodsMngWork searchWork, bool isUpdFlg)
        {
            ImportGoodsMngWork importWork = new ImportGoodsMngWork();
            if (isUpdFlg)
            {
                // �X�V�̏ꍇ
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // �_���폜�敪
            }

            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // ��ƃR�[�h
            importWork.SectionCode = csvWork.SectionCode;                           // ���_�R�[�h
            //importWork.GoodsMGroup = 0;                                            // ���i�����ރR�[�h// DEL 2012/09/24 ������ for Redmine#32367 
            importWork.GoodsMGroup = csvWork.GoodsMGroup;                           // ���i�����ރR�[�h// ADD 2012/09/24 ������ for Redmine#32367 
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         // ���i���[�J�[�R�[�h
            //importWork.BLGoodsCode = 0;                                             // BL���i�R�[�h// DEL 2012/09/24 ������ for Redmine#32367 
            importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BL���i�R�[�h// ADD 2012/09/24 ������ for Redmine#32367 
            importWork.GoodsNo = csvWork.GoodsNo;                                   // ���i�ԍ�
            importWork.SupplierCd = csvWork.SupplierCd;                             // �d����R�[�h
            importWork.SupplierLot = csvWork.SupplierLot;                           // �������b�g

            return importWork;
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
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

        # region �`�F�b�N

        #region �f�[�^�捞�`�F�b�N
        //private bool ImportCheck(ImportGoodsMngWork importWork, out string msg)   // DEL 2012/07/19 �L�w�� 
        private bool ImportCheck(ImportGoodsMngWork importWork, out string msg, List<ImportGoodsMngWork> lst, Int32 checkKbn)   // ADD 2012/07/19 �L�w��
        {
            // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
            msg = string.Empty;
            // �G���[�`�F�b�N����
            if (checkKbn == 0)  
            {
            // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
                //���_�`�F�b�N
                if (!Check_IsNull("���_", importWork.SectionCode.Trim(), out msg))
                    return false;
                else if (!Check_IntAndLen("���_", importWork.SectionCode.Trim(), importWork.SectionCode.Trim().Length, out msg))
                    return false;
                else if (!Check_StrUnFixedLen("���_", importWork.SectionCode.Trim(), 2, out msg))
                    return false;

                //�i�ԃ`�F�b�N
                if (!string.IsNullOrEmpty(importWork.GoodsNo.Trim().Trim()))
                {
                    if (!Check_HalfEngNumFixedLength("�i��", importWork.GoodsNo.Trim(), out msg))
                        return false;
                    else if (!Check_StrUnFixedLen("�i��", importWork.GoodsNo.Trim(), 24, out msg))
                        return false;
                }

                //���[�J�[�`�F�b�N
                if (!Check_IsNull("���[�J�[", importWork.GoodsMakerCd.Trim(), out msg) || !Check_IsN("���[�J�[", importWork.GoodsMakerCd.Trim(), out msg))
                    return false;
                else if (!Check_IntAndLen("���[�J�[", importWork.GoodsMakerCd.Trim(), importWork.GoodsMakerCd.Trim().Length, out msg))
                    return false;
                else if (!Check_StrUnFixedLen("���[�J�[", importWork.GoodsMakerCd.Trim(), 4, out msg))
                    return false;

                // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
                //BL���i�R�[�h�`�F�b�N
                if (!Check_IsNull("BL�R�[�h", importWork.BLGoodsCode, out msg))
                    return false;
                else if (!Check_IntAndLen("BL�R�[�h", importWork.BLGoodsCode.Trim(), 5, out msg))
                    return false;

                //���i�����ރR�[�h�`�F�b�N 
                if (!Check_IsNull("������", importWork.GoodsMGroup, out msg))
                    return false;
                else if (!Check_IntAndLen("������", importWork.GoodsMGroup.Trim(), 4, out msg))
                    return false;

                // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<

                //�d����`�F�b�N
                if (!Check_IsNull("�d����", importWork.SupplierCd.Trim(), out msg) || !Check_IsN("�d����", importWork.SupplierCd.Trim(), out msg))
                    return false;
                else if (!Check_IntAndLen("�d����", importWork.SupplierCd.Trim(), importWork.SupplierCd.Trim().Length, out msg))
                    return false;
                else if (!Check_StrUnFixedLen("�d����", importWork.SupplierCd.Trim(), 6, out msg))
                    return false;

                //�������b�g�`�F�b�N
                if (!string.IsNullOrEmpty(importWork.SupplierLot.Trim()))
                {
                    if (!Check_IntAndLen("�������b�g", importWork.SupplierLot.Trim(), importWork.SupplierLot.Trim().Length, out msg))
                        return false;
                    else if (!Check_StrUnFixedLen("�������b�g", importWork.SupplierLot.Trim(), 4, out msg))
                        return false;
                }
            }   // ADD 2012/07/19 �L�w��

            // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
            int countGoodU = lst.FindAll(delegate(ImportGoodsMngWork tmp)
                            {
                                //return (importWork.SectionCode == tmp.SectionCode && importWork.GoodsMakerCd == tmp.GoodsMakerCd && importWork.GoodsNo == tmp.GoodsNo);// DEL 2012/09/24 ������ for Redmine#32367 
                                return (importWork.SectionCode == tmp.SectionCode && importWork.GoodsMakerCd == tmp.GoodsMakerCd && importWork.GoodsNo == tmp.GoodsNo && importWork.BLGoodsCode == tmp.BLGoodsCode && importWork.GoodsMGroup == tmp.GoodsMGroup);// ADD 2012/09/24 ������ for Redmine#32367 
                            }).Count;
            if (countGoodU > 1)
            {
                msg = ERRMSG_DUPLICATE;
                return false;
            }
            // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
            return true; 
        }
        #endregion

        # region ���b�Z�[�W

        private const string FORMAT_ERRMSG_LEN = "{0}�̌���{1}���ȓ��œ��͂��Ă��������B";

        private const string FORMAT_ERRMSG_TYPE = "{0}��{1}���͂̂݉\�ł��B";

        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}����͂��Ă��������B";

        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
        //private const string ERRMSG_DUPLICATE = "�d���f�[�^���Ă��邽�ߓo�^�ł��܂���B";   // DEL 2012/07/25 �L�w�� 
        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<

        private const string ERRMSG_DUPLICATE = "�d���f�[�^�����邽�ߓo�^�ł��܂���B";   // ADD 2012/07/25 �L�w��

        # endregion

        # region ����

        /// <summary>
        /// �����A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen"></param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns></returns>
        private bool Check_IntAndLen(string fieldNm, string val, int numLen, out string msg)
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
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���l");// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                return false;
            }
        }

        /// <summary>
        /// NULL���f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
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
        /// 0���f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        private bool Check_IsN(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (val.Trim() == "0")
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
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
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
        /// ���p�p�����A�����̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;

            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���p�p�����A����");
                return false;
            }

        }
        // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="str">CSV���ڔz��</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/09/24</br>
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
        // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<


        /// <summary>
        /// ���i�Ǘ����}�X�^�̒ǉ����X�g�Y���̃f�[�^�����݂��邩�`�F�b�N���s���܂��B
        /// </summary>
        /// <param name="ImportAddUpdList">�`�F�b�N���X�g</param>
        /// <param name="addUpdList">�ǉ����X�g</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataList">�G���[�e�[�u���p</param>
        /// <param name="lst">���i�Ǘ����}�X�^�`�F�b�N���X�g</param>
        /// <param name="checkKbn">�`�F�b�N�敪</param>
        /// <remarks>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// </remarks>
        //private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref DataTable dataTable)// DEL 2012/07/03 ����
        //private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref ArrayList dataList)   // ADD 2012/07/03 ����   // DEL 2012/07/19 �L�w�� 
        private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref ArrayList dataList, List<ImportGoodsMngWork> lst, Int32 checkKbn)   // ADD 2012/07/19 �L�w�� 
        {
            string message = string.Empty;
            addUpdList = new ArrayList();

            foreach (ImportGoodsMngWork addUpdwork in ImportAddUpdList)
            {
                //bool checkRes = ImportCheck(addUpdwork, out message);    // DEL 2012/07/19 �L�w��
                bool checkRes = ImportCheck(addUpdwork, out message, lst, checkKbn);    // ADD 2012/07/19 �L�w��

                if (!checkRes)
                {
                    //ConverToDataSetCustomerInf(addUpdwork, message, ref dataTable);// DEL 2012/07/03 ����
                    ConverToDataSetCustomerInf(addUpdwork, message, ref dataList);   // ADD 2012/07/03 ���� 
                    errCnt++;
                }
                else
                {
                    addUpdList.Add(addUpdwork);
                }
            }
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^�`�l
        /// </summary>
        /// <param name="addUpdList">ImportGoodsMngWork</param>
        /// <param name="addUpdWorkList">GoodsMngWork</param>
        private void WriteAddUpdListCheck(ArrayList addUpdList, out ArrayList addUpdWorkList)
        {
            addUpdWorkList = new ArrayList();
            foreach (ImportGoodsMngWork importWork in addUpdList)
            {
                GoodsMngWork work = new GoodsMngWork();
                work.CreateDateTime = importWork.CreateDateTime;        // �쐬�����v���p�e�B
                work.UpdateDateTime = importWork.UpdateDateTime;        // �X�V�����v���p�e�B
                work.EnterpriseCode = importWork.EnterpriseCode;        // ��ƃR�[�h�v���p�e�B
                work.FileHeaderGuid = importWork.FileHeaderGuid;        // GUID�v���p�e�B
                work.UpdEmployeeCode = importWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h�v���p�e�B
                work.UpdAssemblyId1 = importWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1�v���p�e�B
                work.UpdAssemblyId2 = importWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2�v���p�e�B
                work.LogicalDeleteCode = importWork.LogicalDeleteCode;  // �_���폜�敪�v���p�e�B
                work.SectionCode = importWork.SectionCode.Trim().PadLeft(2, '0');         // ���_�R�[�h�v���p�e�B               
                //work.GoodsMGroup = importWork.GoodsMGroup;              // ���i�����ރR�[�h�v���p�e�B// DEL 2012/09/24 ������ for Redmine#32367 
                work.GoodsMGroup = ConvertToInt32(importWork.GoodsMGroup);  // ���i�����ރR�[�h�v���p�e�B // ADD 2012/09/24 ������ for Redmine#32367 
                work.GoodsMakerCd = Convert.ToInt32(importWork.GoodsMakerCd);// ���i���[�J�[�R�[�h�v���p�e�B
                //work.BLGoodsCode = importWork.BLGoodsCode;              // BL���i�R�[�h�v���p�e�B// DEL 2012/09/24 ������ for Redmine#32367 
                work.BLGoodsCode = ConvertToInt32(importWork.BLGoodsCode);  // BL���i�R�[�h�v���p�e�B// ADD 2012/09/24 ������ for Redmine#32367 
                work.GoodsNo = importWork.GoodsNo;                      // ���i�ԍ��v���p�e�B
                work.SupplierCd = Convert.ToInt32(importWork.SupplierCd);// �d����R�[�h�v���p�e�B
                if (!string.IsNullOrEmpty(importWork.SupplierLot.Trim()))
                {
                    work.SupplierLot = Convert.ToInt32(importWork.SupplierLot);// �������b�g�v���p�e�B
                }
                else
                {
                    work.SupplierLot = 0;
                }
                work.GoodsMGroupName = importWork.GoodsMGroupName;      // ���i�����ޖ��̃v���p�e�B
                work.MakerName = importWork.MakerName;                  // ���[�J�[���̃v���p�e�B
                work.GoodsName = importWork.GoodsName;                  // ���i���̃v���p�e�B
                work.BLGoodsFullName = importWork.BLGoodsFullName;      // BL���i�R�[�h���́i�S�p�j�v���p�e�B
                work.SupplierSnm = importWork.SupplierSnm;              // �d���旪�̃v���p�e�B
                work.SectionGuideNm = importWork.SectionGuideNm;        // ���_�K�C�h���̃v���p�e�B
                addUpdWorkList.Add(work);
            }
        }
        # endregion

        #region �G���[�f�[�^�e�[�u���ւ���
        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="goodsMng">���i�Ǘ��f�[�^</param>
        /// <param name="dataList">�e�[�v������</param>
        ///<param name="message">����[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/09/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
        /// </remarks>
        // --- ADD 2012/07/03 ���� ----->>>>>
        private void ConverToDataSetCustomerInf(ImportGoodsMngWork goodsMng, string message, ref ArrayList dataList)
        {

            ImportGoodsMngWork tempWork = new ImportGoodsMngWork();

            // ���_�R�[�h
            tempWork.SectionCode = goodsMng.SectionCode;
            // �i��
            tempWork.GoodsNo = goodsMng.GoodsNo;
            // ���i���[�J�[�R�[�h
            tempWork.GoodsMakerCd = goodsMng.GoodsMakerCd;
            // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
            //BL���i�R�[�h
            tempWork.BLGoodsCode = goodsMng.BLGoodsCode;
            //���i�����ރR�[�h
            tempWork.GoodsMGroup = goodsMng.GoodsMGroup;
            // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
            // �d����R�[�h
            tempWork.SupplierCd = goodsMng.SupplierCd;
            // �������b�g
            tempWork.SupplierLot = goodsMng.SupplierLot;
            // �G���[���b�Z�[�W
            tempWork.ErroLogMessage = message;
            dataList.Add(tempWork);
        }
        // --- ADD 2012/07/03 ���� -----<<<<<

        /*DEL 2012/07/03 ���� ----->>>>>
        private void ConverToDataSetCustomerInf(ImportGoodsMngWork goodsMng, string message, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            // ���_�R�[�h
            dataRow[SECTIONCODE_COLUMN] = goodsMng.SectionCode;
            // �i��
            dataRow[GOODSNO_COLUMN] = goodsMng.GoodsNo.Trim();
            // ���i���[�J�[�R�[�h
            dataRow[GOODSMAKERCD_COLUMN] = goodsMng.GoodsMakerCd.ToString();
            // �d����R�[�h
            dataRow[SUPPLIERCD_COLUMN] = goodsMng.SupplierCd.ToString();
            // �������b�g
            dataRow[SUPPLIERLOT_COLUMN] = goodsMng.SupplierLot.ToString();
            // �G���[���b�Z�[�W
            dataRow[GOODS_ERROR] = message;

            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                  //  ���_�R�[�h
            dataTable.Columns.Add(GOODSNO_COLUMN, typeof(string));                      //  ���i�ԍ�
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add(SUPPLIERCD_COLUMN, typeof(string));                   //  �d����R�[�h
            dataTable.Columns.Add(SUPPLIERLOT_COLUMN, typeof(string));                  //  �������b�g
            dataTable.Columns.Add(GOODS_ERROR, typeof(string));                         //  �G���[���b�Z�[�W
        }
         --- DEL 2012/07/03 ���� -----<<<<<*/

        # endregion

        # endregion
    }
}
