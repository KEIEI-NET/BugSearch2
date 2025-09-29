//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�Ǘ����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
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
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/09/24�@�C�����e : 2012/10/17�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή�                             
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
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�Ǘ����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br>Update Note: 2012/07/03 ���� </br>
    /// <br>           : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
    /// <br>Update Note: 2012/09/24 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
    /// <br></br>
    /// </remarks>
    public class GoodsMngImportAcs
    {
        #region �� Constructor
        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public GoodsMngImportAcs()
        {
            this._iGoodsMngImportDB = (IGoodsMngImportDB)MediationGoodsMngImportDB.GetGoodsMngImportDB();
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        static GoodsMngImportAcs()
        {
        }
        #endregion �� Constructor

        #region �� Private Member
        // --- ADD 2012/07/03 ���� ----- >>>>>
        // ���_�R�[�h
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // ���i�ԍ�
        private const string GOODSNO_COLUMN = "GoodsNoRF";
        // ���i���[�J�[�R�[�h
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
        //BL���i�R�[�h
        private const string BLGOODSCODE_COLUMN = "BLGoodsCodeRF";
        //���i�����ރR�[�h
        private const string GOODSMGROUP_COLUMN = "GoodsMGrouptRF";
        // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
        // �d����R�[�h
        private const string SUPPLIERCD_COLUMN = "SupplierCdRF";
        // �������b�g
        private const string SUPPLIERLOT_COLUMN = "SupplierLotRF";
        //�G���[���b�Z�[�W
        private const string GOODS_ERROR = "GoodsErrorRF";
        // --- ADD 2012/07/03 ���� ----- <<<<<
        // �e�[�u������
        private const string PRINTSET_TABLE = "GoodsMngExp";
        private const string ERROR_LOG_FILENAME = "PMKHN07660U_ERRORLOG.xml";

        // ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃����[�g�C���^�t�F�[�X
        private IGoodsMngImportDB _iGoodsMngImportDB;
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
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public int Import(ExtrInfo_GoodsMngImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errCnt, out errMsg);
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03 ���� </br>
        /// <br>           : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_GoodsMngImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            object dataObjectList = null; // --- ADD ���� 2012/07/13
            ArrayList dataList = new ArrayList();// --- ADD ���� 2012/07/03
            DataTable dataTable = new DataTable(PRINTSET_TABLE);
            errMsg = string.Empty;

            try
            {
                ArrayList importGoodsMngWorkList = null;
                // ���i�Ǘ����}�X�^�̃C���|�[�g���[�N�̕ϊ�����
                status = ConvertToGoodsMngImportWorkList(importWorkTbl, out importGoodsMngWorkList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    Object objGoodsMngImportWorkList = (object)importGoodsMngWorkList;
                    // �����[�g�N���X���Ăяo���B                    
                    //status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataTable, out errMsg);// ---DEL 2012/07/03 ����
                    // ---ADD 2012/07/03 ���� ----- >>>>>
                    //status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataList, out errMsg); // ---DEL 2012/07/13 ����
                    // ---ADD 2012/07/13 ���� ----- >>>>>
                    //status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataObjectList, out errMsg);  // DEL 2012/07/19 �L�w�� 
                    status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, importWorkTbl.CheckKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataObjectList, out errMsg);  // ADD 2012/07/19 �L�w��    
                    dataList = dataObjectList as ArrayList;
                    // ------------DEL �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                    // ---ADD 2012/07/13 ���� ----- <<<<< 
                    //CreateDataTable(ref dataTable);
                    //ConverToDataSetCustomerInf(dataList, ref dataTable);
                    // ---ADD 2012/07/03 ���� ----- <<<<< 
                    // ------------DEL �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
                    // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                    if (dataList != null && dataList.Count > 0)
                    {
                        CreateDataTable(ref dataTable);
                        ConverToDataSetCustomerInf(dataList, ref dataTable);
                    }
                    // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
                    if (dataTable.Rows.Count > 0)
                    {
                        errCnt = dataTable.Rows.Count;
                        this.DoOutPut(importWorkTbl.ErrorLogFileName, dataTable);
                    }
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
        #endregion

        #region �� �f�[�^�ϊ�����
        #region �� ���i�Ǘ����}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// ���i�Ǘ����}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�̃C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/09/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
        /// </remarks>
        private int ConvertToGoodsMngImportWorkList(ExtrInfo_GoodsMngImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            ImportGoodsMngWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new ImportGoodsMngWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.SectionCode = ConvertToEmpty(csvDataArr, index++);             //���_�R�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 //���i�ԍ�
                    work.GoodsMakerCd = ConvertToEmpty(csvDataArr, index++);            //���i���[�J�[�R�[�h
                    // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
                    work.BLGoodsCode = ConvertToEmpty(csvDataArr, index++);             // BL���i�R�[�h
                    work.GoodsMGroup = ConvertToEmpty(csvDataArr, index++);             // ���i�����ރR�[�h
                    // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
                    work.SupplierCd = ConvertToEmpty(csvDataArr, index++);              //�d����R�[�h
                    work.SupplierLot = ConvertToEmpty(csvDataArr, index++);             //�������b�g
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

        #region �� �󔒍��ڂ֕ϊ�����
        /// <summary>
        /// �󔒍��ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
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
        #endregion

        #region �� CSV�o�͏���
        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="errorLogFileName">�G���[���O�t�@�C�����v���p�e�B</param>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : ���ց@�@�@�@�@�@�@</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName, DataTable table)
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
            DataView dv = table.DefaultView;
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
        #endregion �� Private Method

        // ---ADD 2012/07/03 ���� ----- >>>>>
        #region �G���[�f�[�^�e�[�u���ւ���
        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/09/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (ImportGoodsMngWork goodsMng in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // ���_�R�[�h
                dataRow[SECTIONCODE_COLUMN] = goodsMng.SectionCode;
                // �i��
                dataRow[GOODSNO_COLUMN] = goodsMng.GoodsNo.Trim();
                // ���i���[�J�[�R�[�h
                dataRow[GOODSMAKERCD_COLUMN] = goodsMng.GoodsMakerCd.ToString();
                // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
                //BL���i�R�[�h
                dataRow[BLGOODSCODE_COLUMN] = goodsMng.BLGoodsCode;
                //���i�����ރR�[�h
                dataRow[GOODSMGROUP_COLUMN] = goodsMng.GoodsMGroup;
                // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
                // �d����R�[�h
                dataRow[SUPPLIERCD_COLUMN] = goodsMng.SupplierCd.ToString();
                // �������b�g
                dataRow[SUPPLIERLOT_COLUMN] = goodsMng.SupplierLot.ToString();
                // �G���[���b�Z�[�W
                dataRow[GOODS_ERROR] = goodsMng.ErroLogMessage;

                dataTable.Rows.Add(dataRow);
            }
        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/09/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             2012/10/17�z�M���ARedmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                  //  ���_�R�[�h
            dataTable.Columns.Add(GOODSNO_COLUMN, typeof(string));                      //  ���i�ԍ�
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  ���i���[�J�[�R�[�h
            // --- ADD ������ 2012/09/24 for Redmine#32367---------->>>>>
            dataTable.Columns.Add(BLGOODSCODE_COLUMN, typeof(string));                  //  BL���i�R�[�h
            dataTable.Columns.Add(GOODSMGROUP_COLUMN, typeof(string));                  //  ���i�����ރR�[�h
            // --- ADD ������ 2012/09/24 for Redmine#32367----------<<<<<
            dataTable.Columns.Add(SUPPLIERCD_COLUMN, typeof(string));                   //  �d����R�[�h
            dataTable.Columns.Add(SUPPLIERLOT_COLUMN, typeof(string));                  //  �������b�g
            dataTable.Columns.Add(GOODS_ERROR, typeof(string));                         //  �G���[���b�Z�[�W
        }
        #endregion
        // ---ADD 2012/07/03 ���� ----- <<<<< 

        #endregion �� Private Method
    }
}
