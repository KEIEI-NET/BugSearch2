//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �݌Ƀ}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/06/13  �C�����e : ��z�Č��ARedmine#30391 �݌Ƀ}�X�^�C���{�[�g�`�F�b�N�̒ǉ�//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/03  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ�//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/05  �C�����e : ��z�Č��ARedmine#30387��Q�ꗗ�̎w�ENO.19�̑Ή�//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�//
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using System.Text.RegularExpressions;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌Ƀ}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>Update Note: 2012/07/20 zhangy3 </br>
    /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
    /// </remarks>
    public class StockImportAcs
    {
        #region �� Constructor
        /// <summary>
        /// �݌Ƀ}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public StockImportAcs()
        {
            /* DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 --------------->>>>>>
            this._iStockDB = (IStockDB)MediationStockDB.GetStockDB();
            this._iStockAdjustDB = MediationStockAdjustDB.GetStockAdjustDB();
             * DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 ---------------<<<<<<*/
            //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
            //�C���|�[�gDB�����[�g
            this._iStockImportDB = MediationStockImportDB.GetStockImportDB();
            //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
            this._secInfoAcs = new SecInfoAcs();

            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //���O�C�����_�R�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //���O�C�����_����
            //this._loginSectionGuideNm = LoginInfoAcquisition.Employee.BelongSectionName;
            this._loginSectionGuideNm = this.LoadSecInfoSet();

            //���O�C���]�ƈ��R�[�h
            this._employeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            //���O�C���]�ƈ�����
            this._employeeName = LoginInfoAcquisition.Employee.Name;

            this._goodsAcs = new GoodsAcs();

            _warehouseAcs = new WarehouseAcs();

            //�q�Ƀ}�X�^�̃��[�J���L���b�V��
            CacheWarehouseData();

            //���_�}�X�^�̃��[�J���L���b�V��
            CacheSecInfoSetData();
        }

        /// <summary>
        /// �݌Ƀ}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static StockImportAcs()
        {

        }
        #endregion �� Constructor

        #region �� Static Member

        #endregion �� Static Member

        #region �� Private Member
        /* DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        // �݌Ƀf�[�^
        private IStockDB _iStockDB;

        // �݌ɒ����f�[�^
        private IStockAdjustDB _iStockAdjustDB;
        * DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 ---------------<<<<<<*/

        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        //�݌Ƀ}�X�^�C���|�[�g�f�[�^
        private IStockImportDB _iStockImportDB;//
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        private string _enterpriseCode;
        private string _loginSectionCode;
        private string _loginSectionGuideNm;
        private string _employeeCode;
        private string _employeeName;

        // ���_�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs = null;


        // ���i�}�X�^�A�N�Z�X
        private GoodsAcs _goodsAcs;

        /// <summary>���i���}�X�^�L���b�V��</summary>
        private static List<List<GoodsUnitData>> _goodsUnitDataListList;

        //�q�Ƀ}�X�^�A�N�Z�X
        private WarehouseAcs _warehouseAcs;
        Dictionary<string, Warehouse> _warehouseDic;

        Dictionary<string, SecInfoSet> _secInfoSetDic;

        #endregion �� Private Member

        #region �� Const Member

        #endregion �� Const Member

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
        /// <param name="logPath">�G���[���O�̃t�@�C��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        //public int Import(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, string logPath, out string errMsg)//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
        public int Import(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, string logPath, out string errMsg)//ADD ZHANGY3 2012/06/13 FOR REDMINE#30391
        {
            //return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errCnt,logPath, out errMsg);//ADD ZHANGY3 2012/06/13 FOR REDMINE#30391
        }
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        /// <summary>
        /// �݌Ƀ}�X�^�i�C���|�[�g�j�������s���B
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="logPath">�G���[���O�̃t�@�C��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012.06.13</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt,string logPath, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            //DataTable errTable=new DataTable();//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            object errStockCheckWorks = null; //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
            errMsg = string.Empty;
            try
            {
                ArrayList importWorkList = null;
                ArrayList importWorkCheckList = null;
                // �C���|�[�g���[�N�̕ϊ�����
                status = ConvertToImportWorkList(importWorkTbl, out importWorkList,out importWorkCheckList, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && importWorkList != null && importWorkList.Count != 0)
                {
                    object objImportWork = (object)importWorkList;
                    object objImportWorkCheck = (object)importWorkCheckList;
                    //�C���|�[�g�̎��s
                    //status = _iStockImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWork, ref objImportWorkCheck, this._enterpriseCode, this._loginSectionCode, this._loginSectionGuideNm, this._employeeCode, this._employeeName, out readCnt, out addCnt, out updCnt, out errCnt, out errTable, out errMsg);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                    //status = _iStockImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWork, ref objImportWorkCheck, this._enterpriseCode, this._loginSectionCode, this._loginSectionGuideNm, this._employeeCode, this._employeeName, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                    status = _iStockImportDB.Import(importWorkTbl.ProcessKbn, importWorkTbl.DataCheckKbn, ref objImportWork, ref objImportWorkCheck, this._enterpriseCode, this._loginSectionCode, this._loginSectionGuideNm, this._employeeCode, this._employeeName, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                }
                //csv�o�͏���
                //if (null != errTable && errTable.Rows.Count != 0)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                if (null != errStockCheckWorks)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                {
                    //DoOutPut(logPath, errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                    DoOutPut(logPath, errStockCheckWorks);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        
        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="errorLogFileName">�G���[�t�@�C����</param>
        /// <param name="errStockCheckWorks">�G���[�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// </remarks>
        //private int DoOutPut(string errorLogFileName, DataTable table)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        private int DoOutPut(string errorLogFileName, object errStockCheckWorks)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
        {
            int status = 0;

            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
            DataTable table = new DataTable();
            CreateDataTable(ref table);
            ArrayList arrList =(ArrayList) errStockCheckWorks;
            InsertDataIntoTable(arrList, ref table);
            if (table.Rows.Count == 0)
                return status;
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<
            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.prpid = "PMKHN07600U_ERRORLOG.xml";
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
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387   --------------->>>>>>     
        # region OutPut Table
        /// <summary>
        /// �e�[�u���ɒl��ǉ�
        /// </summary>
        /// <param name="workList">�G���[���X�g</param>
        /// <param name="errTable">�G���[�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �e�[�u���ɒl��ǉ�</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void InsertDataIntoTable(ArrayList workList, ref DataTable errTable)
        {
            foreach (StockCheckWork stockCheckWork in workList)
            {
                DataRow dr = errTable.NewRow();
                //----- �݌Ƀ}�X�^�̓��e���e�[�u���ɒǉ����� -----
                //���_�R�[�h
                dr["SectionCode"] = stockCheckWork.SectionCode;
                
                //�q�ɃR�[�h
                dr["WarehouseCode"] = stockCheckWork.WarehouseCode;

                //���i���[�J�[�R�[�h
                dr["GoodsMakerCd"] = stockCheckWork.GoodsMakerCd;

                //���i�ԍ�
                dr["GoodsNo"] = stockCheckWork.GoodsNo;

                //�d���P���i�Ŕ�,�����j
                dr["StockUnitPriceFl"] = stockCheckWork.StockUnitPriceFl;

                //�d���݌ɐ�
                dr["SupplierStock"] = stockCheckWork.SupplierStock;

                //���א��i���v��j
                dr["ArrivalCnt"] = stockCheckWork.ArrivalCnt;

                //�o�א��i���v��j
                dr["ShipmentCnt"] = stockCheckWork.ShipmentCnt;

                //�󒍐�
                dr["AcpOdrCount"] = stockCheckWork.AcpOdrCount;

                //�ړ����d���݌ɐ�
                dr["MovingSupliStock"] = stockCheckWork.MovingSupliStock;

                //�o�׉\��
                dr["ShipmentPosCnt"] = stockCheckWork.ShipmentPosCnt;

                //������
                dr["SalesOrderCount"] = stockCheckWork.SalesOrderCount;

                //�݌ɋ敪
                dr["StockDiv"] = stockCheckWork.StockDiv;

                //�Œ�݌ɐ�
                dr["MinimumStockCnt"] = stockCheckWork.MinimumStockCnt;

                //�ō��݌ɐ�
                dr["MaximumStockCnt"] = stockCheckWork.MaximumStockCnt;

                //�����P��
                dr["SalesOrderUnit"] = stockCheckWork.SalesOrderUnit;

                //�݌ɔ�����R�[�h
                dr["StockSupplierCode"] = stockCheckWork.StockSupplierCode;

                //�q�ɒI��
                dr["WarehouseShelfNo"] = stockCheckWork.WarehouseShelfNo;

                //�d���I�ԂP
                dr["DuplicationShelfNo1"] = stockCheckWork.DuplicationShelfNo1;

                //�d���I�ԂQ
                dr["DuplicationShelfNo2"] = stockCheckWork.DuplicationShelfNo2;

                //���i�Ǘ��敪�P
                dr["PartsManagementDivide1"] = stockCheckWork.PartsManagementDivide1;

                //���i�Ǘ��敪�Q
                dr["PartsManagementDivide2"] = stockCheckWork.PartsManagementDivide2;

                //�݌ɔ��l�P
                dr["StockNote1"] = stockCheckWork.StockNote1;

                //�݌ɔ��l�Q
                dr["StockNote2"] = stockCheckWork.StockNote2;

                //----- �G���[���b�Z�[�W��ǉ����� -----
                //���b�Z�[�W
                dr["ErrMsg"] = stockCheckWork.ERRMESSAGE;

                errTable.Rows.Add(dr);
            }
        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            //���_�R�[�h
            dataTable.Columns.Add("SectionCode", typeof(string));

            //�q�ɃR�[�h
            dataTable.Columns.Add("WarehouseCode", typeof(string));

            //���i���[�J�[�R�[�h
            dataTable.Columns.Add("GoodsMakerCd", typeof(string));

            //���i�ԍ�
            dataTable.Columns.Add("GoodsNo", typeof(string));

            //�d���P���i�Ŕ�,�����j
            dataTable.Columns.Add("StockUnitPriceFl", typeof(string));

            //�d���݌ɐ�
            dataTable.Columns.Add("SupplierStock", typeof(string));

            //���א��i���v��j
            dataTable.Columns.Add("ArrivalCnt", typeof(string));

            //�o�א��i���v��j
            dataTable.Columns.Add("ShipmentCnt", typeof(string));

            //�󒍐�
            dataTable.Columns.Add("AcpOdrCount", typeof(string));

            //�ړ����d���݌ɐ�
            dataTable.Columns.Add("MovingSupliStock", typeof(string));

            //�o�׉\��
            dataTable.Columns.Add("ShipmentPosCnt", typeof(string));

            //������
            dataTable.Columns.Add("SalesOrderCount", typeof(string));

            //�݌ɋ敪
            dataTable.Columns.Add("StockDiv", typeof(string));

            //�Œ�݌ɐ�
            dataTable.Columns.Add("MinimumStockCnt", typeof(string));

            //�ō��݌ɐ�
            dataTable.Columns.Add("MaximumStockCnt", typeof(string));

            //�����P��
            dataTable.Columns.Add("SalesOrderUnit", typeof(string));

            //�݌ɔ�����R�[�h
            dataTable.Columns.Add("StockSupplierCode", typeof(string));

            //�q�ɒI��
            dataTable.Columns.Add("WarehouseShelfNo", typeof(string));

            //�d���I�ԂP
            dataTable.Columns.Add("DuplicationShelfNo1", typeof(string));

            //�d���I�ԂQ
            dataTable.Columns.Add("DuplicationShelfNo2", typeof(string));

            //���i�Ǘ��敪�P
            dataTable.Columns.Add("PartsManagementDivide1", typeof(string));

            //���i�Ǘ��敪�Q
            dataTable.Columns.Add("PartsManagementDivide2", typeof(string));

            //�݌ɔ��l�P
            dataTable.Columns.Add("StockNote1", typeof(string));

            //�݌ɔ��l�Q
            dataTable.Columns.Add("StockNote2", typeof(string));

            //���b�Z�[�W
            dataTable.Columns.Add("ErrMsg", typeof(string));

        }
        # endregion
        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387   ---------------<<<<<<
        /* DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        #region �� �݌Ƀ}�X�^�i�C���|�[�g�j�̃C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            try
            {
                ArrayList importWorkList = null;

                // �݌Ƀ}�X�^�ǉ����X�g
                ArrayList addList = new ArrayList();
                // �݌Ƀ}�X�^�X�V���X�g
                ArrayList updList = new ArrayList();

                // �C���|�[�g���[�N�̕ϊ�����
                status = ConvertToImportWorkList(importWorkTbl, out importWorkList, out errMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && importWorkList != null && importWorkList.Count != 0)
                {
                    // �݌ɏ��S�ăf�[�^�̌�������

                    ArrayList stockWorkList = new ArrayList();

                    object objectstockWork = stockWorkList as object;

                    StockWork stockWork = new StockWork();

                    stockWork.EnterpriseCode = importWorkTbl.EnterpriseCode;

                    object objectparastockWork = stockWork as object;

                    status = this._iStockDB.Search(out objectstockWork, objectparastockWork, 0, ConstantManagement.LogicalMode.GetData01);

                    stockWorkList = objectstockWork as ArrayList;

                    // Dictionary�̍쐬
                    Dictionary<StockSearchUImportWorkWrap, StockWork> dict = new Dictionary<StockSearchUImportWorkWrap, StockWork>();

                    foreach (StockWork work in stockWorkList)
                    {
                        work.WarehouseCode = work.WarehouseCode.Trim();
                        StockSearchUImportWorkWrap warp = new StockSearchUImportWorkWrap(work);
                        dict.Add(warp, work);
                    }

                    foreach (StockWork importWork in importWorkList)
                    {
                        StockSearchUImportWorkWrap importWarp = new StockSearchUImportWorkWrap(importWork);

                        if (!dict.ContainsKey(importWarp))
                        {
                            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                            addList.Add(ConvertToImportWork(importWork, null, false));
                        }
                        else
                        {
                            // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                            updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
                        }
                    }

                    // �Ǎ�����
                    readCnt = importWorkList.Count;

                    CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();

                    // �����敪���u�ǉ��v�̏ꍇ
                    if (importWorkTbl.ProcessKbn == 1)
                    {
                        if (addList.Count > 0)
                        {
                            saveDataList = this.CreateSaveData(addList, new ArrayList(), dict);

                            object objSaveData = (object)saveDataList;

                            status = _iStockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                        }
                    }
                    else if (importWorkTbl.ProcessKbn == 2)
                    {
                        // �����敪���u�X�V�v�̏ꍇ
                        if (updList.Count > 0)
                        {
                            saveDataList = this.CreateSaveData(new ArrayList(), updList, dict);

                            object objSaveData = (object)saveDataList;

                            status = _iStockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            updCnt = updList.Count;
                        }
                    }
                    else
                    {
                        // �����敪���u�ǉ��X�V�v�̏ꍇ

                        saveDataList = this.CreateSaveData(addList, updList, dict);

                        object objSaveData = (object)saveDataList;

                        status = _iStockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }

                }
                else
                {
                    //
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
        * DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 ---------------<<<<<<*/

        #region �� �f�[�^�ϊ�����
        #region �� �C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// �C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="importWorkCheckList">�����[�g�p�̃C���|�[�g�`�F�b�N���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        //private int ConvertToImportWorkList(ExtrInfo_StockImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)//DEL ZHANGY3  2012/06/13 FOR REDMINE#30391
        private int ConvertToImportWorkList(ExtrInfo_StockImportWorkTbl importWorkTbl, out ArrayList importWorkList,out ArrayList importWorkCheckList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            importWorkCheckList = new ArrayList();//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391
            StockWork work = null;
            StockCheckWork workCheck = null;//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new StockWork();
                    workCheck = new StockCheckWork();//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391
                    int index = 0;
                    work.EnterpriseCode = importWorkTbl.EnterpriseCode;

                    //���_�R�[�h
                    //workCheck.SectionCode = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SectionCode = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SectionCode = ConvertToStrCode(csvDataArr, index++, 2);
                    //�q�ɃR�[�h
                    //workCheck.WarehouseCode = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.WarehouseCode = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.WarehouseCode = ConvertToStrCode(csvDataArr, index++, 4);
                    //���i���[�J�[�R�[�h
                    //workCheck.GoodsMakerCd = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.GoodsMakerCd = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);
                    //���i�ԍ�
                    //workCheck.GoodsNo = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.GoodsNo = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);
                    //�d���P���i�Ŕ�,�����j
                    //workCheck.StockUnitPriceFl = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockUnitPriceFl = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockUnitPriceFl = ConvertToDouble(csvDataArr, index++);
                    //�d���݌ɐ�
                    //workCheck.SupplierStock = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SupplierStock = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SupplierStock = ConvertToDouble(csvDataArr, index++);
                    //���א��i���v��j
                    //workCheck.ArrivalCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.ArrivalCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.ArrivalCnt = ConvertToDouble(csvDataArr, index++);
                    //�o�א��i���v��j
                    //workCheck.ShipmentCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.ShipmentCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.ShipmentCnt = ConvertToDouble(csvDataArr, index++);
                    //�󒍐�
                    //workCheck.AcpOdrCount = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.AcpOdrCount = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.AcpOdrCount = ConvertToDouble(csvDataArr, index++);
                    //�ړ����d���݌ɐ�
                    //workCheck.MovingSupliStock = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.MovingSupliStock = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.MovingSupliStock = ConvertToDouble(csvDataArr, index++);
                    //�o�׉\��
                    //workCheck.ShipmentPosCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.ShipmentPosCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.ShipmentPosCnt = ConvertToDouble(csvDataArr, index++);
                    //������
                    //workCheck.SalesOrderCount = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SalesOrderCount = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SalesOrderCount = ConvertToDouble(csvDataArr, index++);
                    //�݌ɋ敪
                    //workCheck.StockDiv = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockDiv = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockDiv = ConvertToInt32(csvDataArr, index++);
                    //�Œ�݌ɐ�
                    //workCheck.MinimumStockCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.MinimumStockCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.MinimumStockCnt = ConvertToDouble(csvDataArr, index++);
                    //�ō��݌ɐ�
                    //workCheck.MaximumStockCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.MaximumStockCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.MaximumStockCnt = ConvertToDouble(csvDataArr, index++);
                    //�����P��
                    //workCheck.SalesOrderUnit = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SalesOrderUnit = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SalesOrderUnit = ConvertToInt32(csvDataArr, index++);
                    //�݌ɔ�����R�[�h
                    //workCheck.StockSupplierCode = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockSupplierCode = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockSupplierCode = ConvertToInt32(csvDataArr, index++);
                    //�q�ɒI��
                    //workCheck.WarehouseShelfNo = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.WarehouseShelfNo = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.WarehouseShelfNo = ConvertToEmpty(csvDataArr, index++);
                    //�d���I�ԂP
                    //workCheck.DuplicationShelfNo1 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.DuplicationShelfNo1 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.DuplicationShelfNo1 = ConvertToEmpty(csvDataArr, index++);
                    //�d���I�ԂQ
                    //workCheck.DuplicationShelfNo2 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.DuplicationShelfNo2 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.DuplicationShelfNo2 = ConvertToEmpty(csvDataArr, index++);
                    //���i�Ǘ��敪�P
                    //workCheck.PartsManagementDivide1 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.PartsManagementDivide1 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.PartsManagementDivide1 = ConvertToEmpty(csvDataArr, index++);
                    //���i�Ǘ��敪�Q
                    //workCheck.PartsManagementDivide2 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.PartsManagementDivide2 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.PartsManagementDivide2 = ConvertToEmpty(csvDataArr, index++);
                    //�݌ɔ��l�P
                    //workCheck.StockNote1 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockNote1 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockNote1 = ConvertToEmpty(csvDataArr, index++);
                    //�݌ɔ��l�Q
                    //workCheck.StockNote2 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockNote2 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockNote2 = ConvertToEmpty(csvDataArr, index++);
                    importWorkCheckList.Add(workCheck);//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391

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
        /// <br>Programmer : ���M</br>
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

        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">���l���ڂ̕���</param>
        /// <param name="index">���l���ڂ̕���</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���l���ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int64 ConvertToInt64(string[] csvDataArr, Int32 index)
        {
            Int64 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt64(csvDataArr[index]);
                }
                catch
                {
                    retNum = 0;
                }
            }
            return retNum;
        }

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
        private double ConvertToDouble(string[] csvDataArr, Int32 index)
        {
            double reDouble = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    reDouble = Convert.ToDouble(csvDataArr[index]);
                }
                catch
                {
                    reDouble = 0;
                }
            }

            return reDouble;
        }

        /// <summary>
        /// �󔒍��ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : ���M</br>
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

        #region �� DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// <summary>
        /// DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private StockWork ConvertToImportWork(StockWork csvWork, StockWork searchWork, bool isUpdFlg)
        {
            StockWork importWork = new StockWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = System.DateTime.Now;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // �L��
                importWork.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
                importWork.UpdAssemblyId1 = searchWork.UpdAssemblyId1;
                importWork.UpdAssemblyId2 = searchWork.UpdAssemblyId2;

                //M/O������
                importWork.MonthOrderCount = searchWork.MonthOrderCount;
                //�݌ɕۗL���z
                importWork.StockTotalPrice = searchWork.StockTotalPrice;
                //�ŏI�d���N����
                importWork.LastStockDate = searchWork.LastStockDate;
                //�ŏI�����
                importWork.LastSalesDate = searchWork.LastSalesDate;
                //�ŏI�I���X�V��
                importWork.LastInventoryUpdate = searchWork.LastInventoryUpdate;
                //�������
                importWork.NmlSalOdrCount = searchWork.NmlSalOdrCount;
                //�n�C�t�������i�ԍ�
                importWork.GoodsNoNoneHyphen = searchWork.GoodsNoNoneHyphen;
                //�݌ɓo�^��
                importWork.StockCreateDate = searchWork.StockCreateDate;

            }
            else
            {

                //M/O������
                importWork.MonthOrderCount = 0;
                //�݌ɕۗL���z
                importWork.StockTotalPrice = 0;
                //�ŏI�d���N����
                //importWork.LastStockDate = 0;
                //�ŏI�����
                //importWork.LastSalesDate = 0;
                //�ŏI�I���X�V��
                //importWork.LastInventoryUpdate = 0;
                //�������
                importWork.NmlSalOdrCount = 0;
                //�n�C�t�������i�ԍ�
                importWork.GoodsNoNoneHyphen = string.Empty;
                //�݌ɓo�^��
                importWork.StockCreateDate = System.DateTime.Now;
            }

            importWork.EnterpriseCode = csvWork.EnterpriseCode;                  // ��ƃR�[�h

            //���_�R�[�h
            importWork.SectionCode = csvWork.SectionCode;
            //�q�ɃR�[�h
            importWork.WarehouseCode = csvWork.WarehouseCode;
            //���i���[�J�[�R�[�h
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;
            //���i�ԍ�
            importWork.GoodsNo = csvWork.GoodsNo;
            //�d���P���i�Ŕ�,�����j
            importWork.StockUnitPriceFl = csvWork.StockUnitPriceFl;
            //�d���݌ɐ�
            importWork.SupplierStock = csvWork.SupplierStock;
            //�󒍐�
            importWork.AcpOdrCount = csvWork.AcpOdrCount;
            //������
            importWork.SalesOrderCount = csvWork.SalesOrderCount;
            //�݌ɋ敪
            importWork.StockDiv = csvWork.StockDiv;
            //�ړ����d���݌ɐ�
            importWork.MovingSupliStock = csvWork.MovingSupliStock;
            //�o�׉\��
            importWork.ShipmentPosCnt = csvWork.ShipmentPosCnt;
            //�Œ�݌ɐ�
            importWork.MinimumStockCnt = csvWork.MinimumStockCnt;
            //�ō��݌ɐ�
            importWork.MaximumStockCnt = csvWork.MaximumStockCnt;
            //�����P��
            importWork.SalesOrderUnit = csvWork.SalesOrderUnit;
            //�݌ɔ�����R�[�h
            importWork.StockSupplierCode = csvWork.StockSupplierCode;
            //�q�ɒI��
            importWork.WarehouseShelfNo = csvWork.WarehouseShelfNo;
            //�d���I�ԂP
            importWork.DuplicationShelfNo1 = csvWork.DuplicationShelfNo1;
            //�d���I�ԂQ
            importWork.DuplicationShelfNo2 = csvWork.DuplicationShelfNo2;
            //���i�Ǘ��敪�P
            importWork.PartsManagementDivide1 = csvWork.PartsManagementDivide1;
            //���i�Ǘ��敪�Q
            importWork.PartsManagementDivide2 = csvWork.PartsManagementDivide2;
            //�݌ɔ��l�P
            importWork.StockNote1 = csvWork.StockNote1;
            //�݌ɔ��l�Q
            importWork.StockNote2 = csvWork.StockNote2;
            //�o�א��i���v��j
            importWork.ShipmentCnt = csvWork.ShipmentCnt;
            //���א��i���v��j
            importWork.ArrivalCnt = csvWork.ArrivalCnt;
            //�X�V�N����
            importWork.UpdateDate = System.DateTime.Now;

            return importWork;
        }

        #endregion

        #region �� �ۑ��p�f�[�^�̍쐬

        /// <summary>
        /// �ۑ��p�f�[�^��������
        /// </summary>
        /// <returns>�ۑ��p�f�[�^(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��p�f�[�^���쐬���܂��B</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(ArrayList addList, ArrayList updList, Dictionary<StockSearchUImportWorkWrap, StockWork> dict)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();

            //���i��������
            ArrayList searchList = new ArrayList();
            if (null != updList && updList.Count > 0)
            {
                searchList.AddRange(updList.GetRange(0, updList.Count));
            }
            if (null != addList && addList.Count > 0)
            {
                searchList.AddRange(addList.GetRange(0, addList.Count));
            }
            SetCacheGoodsUnitDataList(searchList);

            //�X�V�̏���
            foreach (StockWork updWork in updList)
            {
                ArrayList stockAdjustWorkList = new ArrayList();
                ArrayList stockAdjustDtlWorkList = new ArrayList();
                ArrayList dataList = new ArrayList();
                CustomSerializeArrayList tempList = new CustomSerializeArrayList();

                StockSearchUImportWorkWrap updWarp = new StockSearchUImportWorkWrap(updWork);

                updWork.SupplierStock = updWork.SupplierStock - dict[updWarp].SupplierStock;
                double adjustCount = updWork.SupplierStock;
                updWork.AcpOdrCount = updWork.AcpOdrCount - dict[updWarp].AcpOdrCount;
                updWork.SalesOrderCount = updWork.SalesOrderCount - dict[updWarp].SalesOrderCount;
                updWork.MovingSupliStock = updWork.MovingSupliStock - dict[updWarp].MovingSupliStock;
                updWork.ShipmentCnt = updWork.ShipmentCnt - dict[updWarp].ShipmentCnt;
                updWork.ArrivalCnt = updWork.ArrivalCnt - dict[updWarp].ArrivalCnt;

                if (Math.Abs(updWork.SupplierStock) != 0)
                {
                    GoodsPrice goodsPriceUp;
                    GoodsUnitData goodsUnitDataUp;

                    // ���i���̎擾
                    GetListPrice(updWork, out goodsPriceUp, out goodsUnitDataUp);
                    //�݌ɒ���
                    StockAdjustWork targetStockAdjustWorkUp = CreateStockAdjust(updWork);
                    //�݌ɒ�������
                    Int64 wkStockSubttlPriceUp = CreateStockAdjustDtl(ref stockAdjustDtlWorkList, updWork, adjustCount, goodsPriceUp, goodsUnitDataUp);

                    // �d�����z���v�Z�o
                    targetStockAdjustWorkUp.StockSubttlPrice = wkStockSubttlPriceUp;
                    stockAdjustWorkList.Add(targetStockAdjustWorkUp);
                }

                if (stockAdjustWorkList.Count > 0)
                {
                    // �݌ɒ����f�[�^�ǉ�
                    tempList.Add(stockAdjustWorkList);
                }

                if (stockAdjustDtlWorkList.Count > 0)
                {
                    // �݌ɒ������׃f�[�^�ǉ�
                    tempList.Add(stockAdjustDtlWorkList);
                }

                if (updList.Count > 0)
                {
                    dataList.Add(updWork);
                }

                if (dataList.Count > 0)
                {
                    // �݌Ƀ}�X�^�ǉ�
                    tempList.Add(dataList);
                }

                saveDataList.Add(tempList);
            }

            //�V�K�̏���
            foreach (StockWork addwork in addList)
            {
                ArrayList stockAdjustWorkListIt = new ArrayList();
                ArrayList stockAdjustDtlWorkListIt = new ArrayList();
                ArrayList dataListIt = new ArrayList();
                CustomSerializeArrayList tempListIt = new CustomSerializeArrayList();

                if (!string.IsNullOrEmpty(addwork.SupplierStock.ToString()) && addwork.SupplierStock > 0)
                {
                    GoodsPrice goodsPriceIt;
                    GoodsUnitData goodsUnitDataIt;

                    // ���i���̎擾
                    GetListPrice(addwork, out goodsPriceIt, out goodsUnitDataIt);
                    //�݌ɒ���
                    StockAdjustWork targetStockAdjustWorkIt = CreateStockAdjust(addwork);
                    //�݌ɒ�������
                    Int64 wkStockSubttlPriceIt = CreateStockAdjustDtl(ref stockAdjustDtlWorkListIt, addwork, addwork.SupplierStock, goodsPriceIt, goodsUnitDataIt);
                    // �d�����z���v�Z�o
                    targetStockAdjustWorkIt.StockSubttlPrice = wkStockSubttlPriceIt;
                    stockAdjustWorkListIt.Add(targetStockAdjustWorkIt);
                }

                if (stockAdjustWorkListIt.Count > 0)
                {
                    // �݌ɒ����f�[�^�ǉ�
                    tempListIt.Add(stockAdjustWorkListIt);
                }

                if (stockAdjustDtlWorkListIt.Count > 0)
                {
                    // �݌ɒ������׃f�[�^�ǉ�
                    tempListIt.Add(stockAdjustDtlWorkListIt);
                }

                if (addList.Count > 0)
                {
                    dataListIt.Add(addwork);
                }

                if (dataListIt.Count > 0)
                {
                    // �݌Ƀ}�X�^�ǉ�
                    tempListIt.Add(dataListIt);
                }

                saveDataList.Add(tempListIt);
            }

            return saveDataList;
        }

        /// <summary>
        /// �݌ɒ����f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="stockWork">�����敪</param>
        /// <returns>�݌ɒ����f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(StockWork stockWork)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            workData.SectionCode = this._loginSectionCode;
            // ���_����
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // �󕥌��`�[�敪(42�F�}�X�^�����e)
            workData.AcPaySlipCd = 42;
            // �󕥌�����敪(30�F�݌ɐ�����)
            workData.AcPayTransCd = 30;
            // �������t
            workData.AdjustDate = DateTime.Today;
            // ���͓��t
            workData.InputDay = DateTime.Today;
            // �d�����_�R�[�h
            workData.StockSectionCd = stockWork.SectionCode;
            // �d�����_����
            workData.StockSectionGuideNm = GetSectionName(stockWork.SectionCode);
            // �d�����͎҃R�[�h
            workData.StockInputCode = this._employeeCode;
            // �d���S���҃R�[�h
            workData.StockAgentCode = this._employeeCode;
            if (this._employeeName.Length > 16)
            {
                // �d�����͎Җ���
                workData.StockInputName = this._employeeName.Substring(0, 16);
                // �d���S���Җ���
                workData.StockAgentName = this._employeeName.Substring(0, 16);
            }
            else
            {
                // �d�����͎Җ���
                workData.StockInputName = this._employeeName;
                // �d���S���Җ���
                workData.StockAgentName = this._employeeName;
            }

            return workData;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">�����敪</param>
        /// <param name="work">�������t</param>
        /// <param name="adjustCount">�݌ɒ������׃f�[�^�p�����^�[</param>
        /// <param name="goodsPrice">�݌ɒ������׃f�[�^�p�����^�[</param>
        /// <param name="goodsUnitData">�݌ɒ������׃f�[�^�p�����^�[</param>
        /// <returns>�݌ɒ������׃f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// </remarks>
        private Int64 CreateStockAdjustDtl(ref ArrayList stockAdjustDtlWorkList, StockWork work, double adjustCount,
            GoodsPrice goodsPrice, GoodsUnitData goodsUnitData)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();
            // ��ƃR�[�h
            workData.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            workData.SectionCode = this._loginSectionCode; ;
            // ���_����
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // �݌ɒ����`�[�ԍ�
            workData.StockAdjustSlipNo = 0;
            // �݌ɒ����s�ԍ�
            workData.StockAdjustRowNo = stockAdjustDtlWorkList.Count + 1;
            // �󕥌��`�[�敪(42�F�}�X�^�����e)
            workData.AcPaySlipCd = 42;
            // �󕥌�����敪(30�F�݌ɐ�����)
            workData.AcPayTransCd = 30;
            // �������t
            workData.AdjustDate = DateTime.Today;
            // ���͓��t
            workData.InputDay = DateTime.Today;
            // ���[�J�[�R�[�h
            workData.GoodsMakerCd = work.GoodsMakerCd;
            // ���i�ԍ�
            workData.GoodsNo = work.GoodsNo;
            //������
            workData.AdjustCount = adjustCount;
            // �q�ɃR�[�h
            workData.WarehouseCode = work.WarehouseCode;
            // ���[�J�[����
            workData.MakerName = goodsUnitData.MakerName;
            //���i����
            workData.GoodsName = goodsUnitData.GoodsName;
            //�d���P���i�Ŕ�,�����j
            workData.StockUnitPriceFl = goodsPrice.SalesUnitCost;
            //�ύX�O�d���P���i�����j
            workData.BfStockUnitPriceFl = goodsPrice.SalesUnitCost;
            //�艿�i�����j
            workData.ListPriceFl = goodsPrice.ListPrice;
            //BL���i�R�[�h
            workData.BLGoodsCode = goodsUnitData.BLGoodsCode;
            //BL���i�R�[�h���́i�S�p�j
            workData.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
            // �q�ɖ���
            workData.WarehouseName = GetWarehouseName(work.WarehouseCode);
            // �q�ɒI��
            workData.WarehouseShelfNo = work.WarehouseShelfNo;
            //�I�[�v�����i�敪
            workData.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            // �d�����z�i�Ŕ����j
            Int64 wkStockPrice = (Int64)(workData.StockUnitPriceFl * workData.AdjustCount * 100);
            if ((wkStockPrice % 100) >= 50) wkStockPrice = (wkStockPrice / 100) + 1;
            else if ((wkStockPrice % 100) <= -50) wkStockPrice = (wkStockPrice / 100) - 1;
            else wkStockPrice = wkStockPrice / 100;
            workData.StockPriceTaxExc = wkStockPrice;
            stockAdjustDtlWorkList.Add(workData);

            return wkStockPrice;
        }

        #endregion

        #endregion

        #endregion �� Private Method

        #region ���_���}�X�^�Ǎ�����
        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        private string LoadSecInfoSet()
        {
            SecInfoSet secInfoSet;

            int status = this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

            string sectionName = string.Empty;
            if (status == 0)
            {
                sectionName = secInfoSet.SectionGuideNm;
            }

            return sectionName;
        }
        #endregion

        #region �݌Ɍ������I�u�W�F�N�g
        /// <summary>
        /// �݌Ɍ������I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɍ������I�u�W�F�N�g�ł��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        class StockSearchUImportWorkWrap
        {
            #region Public Field
            public StockWork stockWork;
            #endregion

            #region �N���X�R���X�g���N�^
            /// <summary>
            /// �݌Ɍ������I�u�W�F�N�g
            /// </summary>
            /// <remarks>
            /// <br>Note       : �݌Ɍ������I�u�W�F�N�g���擾���܂��B</br>
            /// <br>Programmer : ���M</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public StockSearchUImportWorkWrap(StockWork stockWork)
            {
                this.stockWork = stockWork;
            }
            #endregion

            #region �����������I�u�W�F�N�g�̃C�R�[���̔�r
            /// <summary>
            /// �݌Ɍ������I�u�W�F�N�g�̃C�R�[���̔�r
            /// </summary>
            /// <param name="obj">�݌Ɍ������I�u�W�F�N�g</param>
            /// <returns>��r����</returns>
            /// <remarks>
            /// <br>Note       : �݌Ɍ������I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
            /// <br>Programmer : ���M</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public override bool Equals(object obj)
            {
                StockSearchUImportWorkWrap target = obj as StockSearchUImportWorkWrap;
                if (target == null) return false;
                // �q�ɃR�[�h�A���i�ԍ��A���i���[�J�[�R�[�h
                // �������ꍇ�A�݌ɏ��I�u�W�F�N�g�̓C�R�[���ɂ���B
                return target.stockWork.EnterpriseCode == stockWork.EnterpriseCode
                         && target.stockWork.WarehouseCode == stockWork.WarehouseCode
                         && target.stockWork.GoodsNo == stockWork.GoodsNo
                         && target.stockWork.GoodsMakerCd == stockWork.GoodsMakerCd;
            }
            #endregion

            #region �݌Ɍ������I�u�W�F�N�g�̃n�V�R�[�h
            /// <summary>
            /// �݌Ɍ������I�u�W�F�N�g�̃n�V�R�[�h
            /// </summary>
            /// <returns>�n�V�R�[�h</returns>
            /// <remarks>
            /// <br>Note       : �݌Ɍ������I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
            /// <br>Programmer : ���M</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public override int GetHashCode()
            {
                return stockWork.EnterpriseCode.GetHashCode()
                         + stockWork.WarehouseCode.GetHashCode()
                         + stockWork.GoodsNo.GetHashCode()
                         + stockWork.GoodsMakerCd.GetHashCode();
            }
            #endregion
        }
        #endregion

        #region ���i�����i�Z�b�g���擾�j�I�u�W�F�N�g
        private void SetCacheGoodsUnitDataList(ArrayList printList)
        {
            GoodsAcs goodsAcs = new GoodsAcs();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            string message = "";
            goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);

            foreach (StockWork stockWork in printList)
            {
                // ���i�A�N�Z�X�N���X�̒��o������ݒ�
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                workGoodsCndtn.SectionCode = stockWork.SectionCode.Trim();
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = stockWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = stockWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

                goodsCndtnList.Add(workGoodsCndtn);
            }

            // ���[�J���L���b�V��������
            _goodsUnitDataListList = new List<List<GoodsUnitData>>();

            // ���������������S��v�ŏ��i�����擾
            int status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out _goodsUnitDataListList, out message);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _goodsUnitDataListList = null;
            }
        }

        #endregion

        #region ���i���̎擾
        /// <summary>
        /// ���i���̎擾
        /// </summary>
        /// <param name="stockWork">���o����</param>
        /// <param name="goodsPrice">���o����</param>
        /// <param name="goodsUnitData">���o����</param>
        /// <remarks>
        /// <br>Note       : ���i���}�X�^���擾���܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private void GetListPrice(StockWork stockWork, out GoodsPrice goodsPrice, out GoodsUnitData goodsUnitData)
        {
            goodsPrice = new GoodsPrice();
            goodsUnitData = new GoodsUnitData();

            if (_goodsUnitDataListList == null)
            {
                return;
            }

            string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);

            foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
            {
                foreach (GoodsUnitData wkGoodsUnitData in wkGoodsUnitDataList)
                {
                    List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

                    foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
                    {
                        if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
                            (wkGoodsPrice.GoodsMakerCd == stockWork.GoodsMakerCd) &&
                            (wkGoodsPrice.GoodsNo == stockWork.GoodsNo))
                        {
                            goodsPrice = wkGoodsPrice.Clone();
                            goodsUnitData = wkGoodsUnitData.Clone();
                            return;
                        }
                    }
                }
            }
            return;
        }
        #endregion

        #region ���i���̎擾
        /// <summary>
        /// �q�Ƀ}�X�^�̃��[�J���L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^�̃��[�J���L���b�V�����쐬���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private void CacheWarehouseData()
        {
            int status;
            ArrayList retList;

            // �q�Ƀ}�X�^�̃��[�J���L���b�V�����N���A
            _warehouseDic = new Dictionary<string, Warehouse>();

            // �d����}�X�^�̎擾
            status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Warehouse wkWarehouse in retList)
                {
                    if (wkWarehouse.LogicalDeleteCode == 0)
                    {
                        string key = wkWarehouse.WarehouseCode.TrimEnd().PadLeft(4, '0');
                        if (_warehouseDic.ContainsKey(key))
                        {
                            // ���ɃL���b�V���ɑ��݂��Ă���ꍇ�͍폜
                            _warehouseDic.Remove(key);
                        }
                        _warehouseDic.Add(key, wkWarehouse);
                    }
                }
            }
        }

        /// <summary>
        /// �q�ɖ��̎擾
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string name = string.Empty;

            string key = warehouseCode.TrimEnd().PadLeft(4, '0');
            if (_warehouseDic.ContainsKey(key))
            {
                name = _warehouseDic[key].WarehouseName;
            }

            return name;
        }

        /// <summary>
        /// ���_�}�X�^�̃��[�J���L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^�̃��[�J���L���b�V�����쐬���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private void CacheSecInfoSetData()
        {
            _secInfoSetDic = new Dictionary<string, SecInfoSet>();
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    _secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���_���̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string name = string.Empty;

            if (string.IsNullOrEmpty(sectionCode))
            {
                name = string.Empty;
            }
            else
            {
                if (_secInfoSetDic.ContainsKey(sectionCode.Trim()))
                {
                    name = _secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
                }
            }

            return name;
        }
        #endregion
    }
}
