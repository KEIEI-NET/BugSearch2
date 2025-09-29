//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/06/24  �C�����e : �g�p�t�@�C���̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/03/31  �C�����e : Mantis.15256 ���i�}�X�^�C���|�[�g�̑Ώۍ��ڐݒ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/12  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�
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
using Broadleaf.Library.Text; // ADD wangf 2012/06/12 FOR Redmine#30387
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// </remarks>
    public class GoodsUImportAcs
    {
        #region �� Constructor
		/// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ���w�q</br>
	    /// <br>Date       : 2009.05.13</br>
		/// </remarks>
		public GoodsUImportAcs()
		{
            this._iGoodsUImportDB = (IGoodsUImportDB)MediationGoodsUImportDB.GetGoodsUImportDB();
        }

		/// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static GoodsUImportAcs()
		{
		}
		#endregion �� Constructor

        #region �� Private Member
        // ���i�}�X�^�i�C���|�[�g�j�̃����[�g�C���^�t�F�[�X
        private IGoodsUImportDB _iGoodsUImportDB;
        private const string ERROR_LOG_FILENAME = "PMKHN07630U_ERRORLOG.xml"; // ADD wangf 2012/06/12 FOR Redmine#30387
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
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// </remarks>
        //public int Import(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg) // DEL wangf 2012/06/12 FOR Redmine#30387
        public int Import(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg) // ADD wangf 2012/06/12 FOR Redmine#30387
        {
            //return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg); // DEL wangf 2012/06/12 FOR Redmine#30387
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errCnt, out errMsg); // ADD wangf 2012/06/12 FOR Redmine#30387
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g����
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
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/03 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        //private int ImportProc(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg) // DEL wangf 2012/06/12 FOR Redmine#30387
        private int ImportProc(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg) // ADD wangf 2012/06/12 FOR Redmine#30387
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0; // ADD wangf 2012/06/12 FOR Redmine#30387
            errMsg = string.Empty;

            try
            {
                ArrayList importGoodsUWorkList = null;
                ArrayList importGoodsPriceUWorkList = null;
                ArrayList importGoodsUGoodsPriceUWorkList = null; // ADD wangf 2012/06/12 FOR Redmine#30387
                Object importSetUpInfoList = (object)importWorkTbl.SetUpInfoList;   // 2010/03/31 Add
                //DataTable table = null; // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                DataTable table = new DataTable();
                CreateDataTable(ref table);
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                // ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
                status = ConvertToGoodsUImportWorkList(importWorkTbl, out importGoodsUWorkList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
                    status = ConvertToGoodsPriceUImportWorkList(importWorkTbl, out importGoodsPriceUWorkList, out errMsg);
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    ConvertToGoodsUGoodsPriceUImportWorkList(importWorkTbl, out importGoodsUGoodsPriceUWorkList, out errMsg);
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        Object objGoodsUImportWorkList = (object)importGoodsUWorkList;
                        Object objGoodsPriceUImportWorkList = (object)importGoodsPriceUWorkList;
                        Object objGoodsUGoodsPriceUImportWorkList = (object)importGoodsUGoodsPriceUWorkList; // ADD wangf 2012/06/12 FOR Redmine#30387
                        // �����[�g�N���X���Ăяo���B
                        // 2010/03/31 >>>
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList); // DEL wangf 2012/06/12 FOR Redmine#30387
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, ref objGoodsUGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList, ref table, importWorkTbl.PriceStartDate); // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, ref objGoodsUGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList, importWorkTbl.PriceStartDate); // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
                        status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, importWorkTbl.DataCheckKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, ref objGoodsUGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList, importWorkTbl.PriceStartDate); // ADD wangf 2012/07/20 FOR Redmine#30387
                        // 2010/03/31 <<<
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        //if (table.Rows.Count > 0) // DEL wangf 2012/07/03 FOR Redmine#30387
                        // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                        if (objGoodsUGoodsPriceUImportWorkList != null && ((ArrayList)objGoodsUGoodsPriceUImportWorkList).Count > 0)
                        {
                            ArrayList exportGoodsUGoodsPriceUImportWorkArray = objGoodsUGoodsPriceUImportWorkList as ArrayList;
                            foreach (GoodsUGoodsPriceUWork goodsUGoodsPriceUWork in exportGoodsUGoodsPriceUImportWorkArray)
                            {
                                if (!string.IsNullOrEmpty(goodsUGoodsPriceUWork.ErrorMsg))
                                {
                                    ConverToDataSetCustomerInf(goodsUGoodsPriceUWork, ref table);
                                }
                            }
                            if (table.Rows.Count > 0){
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                            errCnt = table.Rows.Count;
                            this.DoOutPut(importWorkTbl.ErrorLogFileName, table);
                            } // ADD wangf 2012/07/03 FOR Redmine#30387
                        }
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
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
        #region �� ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToGoodsUImportWorkList(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // ���[�J�[
                    work.GoodsName = ConvertToEmpty(csvDataArr, index++);               // �i��
                    work.GoodsNameKana = ConvertToEmpty(csvDataArr, index++);           // �i���J�i
                    work.Jan = ConvertToEmpty(csvDataArr, index++);                     // JAN�R�[�h
                    work.BLGoodsCode = ConvertToInt32(csvDataArr, index++);             // BL�R�[�h
                    work.EnterpriseGanreCode = ConvertToInt32(csvDataArr, index++);     // ���i�敪
                    work.GoodsRateRank = ConvertToEmpty(csvDataArr, index++);           // �w��
                    work.GoodsKindCode = ConvertToInt32(csvDataArr, index++);           // ���D�敪
                    work.TaxationDivCd = ConvertToInt32(csvDataArr, index++);           // �ېŋ敪
                    work.GoodsNote1 = ConvertToEmpty(csvDataArr, index++);              // ���i���l�P
                    work.GoodsNote2 = ConvertToEmpty(csvDataArr, index++);              // ���i���l�Q
                    work.GoodsSpecialNote = ConvertToEmpty(csvDataArr, index++);        // ���i�K�i�E���L����

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

        #region �� ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�̃C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// </remarks>
        private int ConvertToGoodsPriceUImportWorkList(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsPriceUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsPriceUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // ���[�J�[
                    index = 13;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // ���i�J�n�N����
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // ���i
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // �I�[�v�����i�敪
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // �d����
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // ���P��
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // �����̓T�[�o�[���ړ�����
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387

                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // ���[�J�[
                    index = 18;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // ���i�J�n�N����
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // ���i
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // �I�[�v�����i�敪
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // �d����
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // ���P��
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // �����̓T�[�o�[���ړ�����
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387

                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // ���[�J�[
                    index = 23;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // ���i�J�n�N����
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // ���i
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // �I�[�v�����i�敪
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // �d����
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // ���P��
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // �����̓T�[�o�[���ړ�����
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387
                    // ADD 2009/06/24 --->>>
                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // ���[�J�[
                    index = 28;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // ���i�J�n�N����
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // ���i
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // �I�[�v�����i�敪
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // �d����
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // ���P��
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // �����̓T�[�o�[���ړ�����
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387
                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // ���[�J�[
                    index = 33;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // ���i�J�n�N����
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // ���i
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // �I�[�v�����i�敪
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // �d����
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // ���P��
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // �����̓T�[�o�[���ړ�����
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387
                    // ADD 2009/06/24 ---<<<
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
        // ------------ADD START wangf 2012/06/12 FOR Redmine#30387--------->>>>
        #region �� ���i�}�X�^�E���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// ���i�}�X�^�E���i�}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�E���i�}�X�^�̃C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int ConvertToGoodsUGoodsPriceUImportWorkList(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsUGoodsPriceUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsUGoodsPriceUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // �i��
                    work.GoodsMakerCd = ConvertToEmpty(csvDataArr, index++);            // ���[�J�[
                    work.GoodsName = ConvertToEmpty(csvDataArr, index++);               // �i��
                    work.GoodsNameKana = ConvertToEmpty(csvDataArr, index++);           // �i���J�i
                    work.Jan = ConvertToEmpty(csvDataArr, index++);                     // JAN�R�[�h
                    work.BLGoodsCode = ConvertToEmpty(csvDataArr, index++);             // BL�R�[�h
                    work.EnterpriseGanreCode = ConvertToEmpty(csvDataArr, index++);     // ���i�敪
                    work.GoodsRateRank = ConvertToEmpty(csvDataArr, index++);           // �w��
                    work.GoodsKindCode = ConvertToEmpty(csvDataArr, index++);           // ���D�敪
                    work.TaxationDivCd = ConvertToEmpty(csvDataArr, index++);           // �ېŋ敪
                    work.GoodsNote1 = ConvertToEmpty(csvDataArr, index++);              // ���i���l�P
                    work.GoodsNote2 = ConvertToEmpty(csvDataArr, index++);              // ���i���l�Q
                    work.GoodsSpecialNote = ConvertToEmpty(csvDataArr, index++);        // ���i�K�i�E���L����

                    work.PriceStartDate1 = ConvertToEmpty(csvDataArr, index++);       // ���i�J�n�N�����P
                    work.ListPrice1 = ConvertToEmpty(csvDataArr, index++);              // ���i�P
                    work.OpenPriceDiv1 = ConvertToEmpty(csvDataArr, index++);            // �I�[�v�����i�敪�P
                    work.StockRate1 = ConvertToEmpty(csvDataArr, index++);              // �d�����P
                    work.SalesUnitCost1 = ConvertToEmpty(csvDataArr, index++);          // ���P���P

                    work.PriceStartDate2 = ConvertToEmpty(csvDataArr, index++);       // ���i�J�n�N�����Q
                    work.ListPrice2 = ConvertToEmpty(csvDataArr, index++);              // ���i�Q
                    work.OpenPriceDiv2 = ConvertToEmpty(csvDataArr, index++);            // �I�[�v�����i�敪�Q
                    work.StockRate2 = ConvertToEmpty(csvDataArr, index++);              // �d�����Q
                    work.SalesUnitCost2 = ConvertToEmpty(csvDataArr, index++);          // ���P���Q

                    work.PriceStartDate3 = ConvertToEmpty(csvDataArr, index++);       // ���i�J�n�N�����R
                    work.ListPrice3 = ConvertToEmpty(csvDataArr, index++);              // ���i�R
                    work.OpenPriceDiv3 = ConvertToEmpty(csvDataArr, index++);            // �I�[�v�����i�敪�R
                    work.StockRate3 = ConvertToEmpty(csvDataArr, index++);              // �d�����R
                    work.SalesUnitCost3 = ConvertToEmpty(csvDataArr, index++);          // ���P���R

                    work.PriceStartDate4 = ConvertToEmpty(csvDataArr, index++);       // ���i�J�n�N�����S
                    work.ListPrice4 = ConvertToEmpty(csvDataArr, index++);              // ���i�S
                    work.OpenPriceDiv4 = ConvertToEmpty(csvDataArr, index++);            // �I�[�v�����i�敪�S
                    work.StockRate4 = ConvertToEmpty(csvDataArr, index++);              // �d�����S
                    work.SalesUnitCost4 = ConvertToEmpty(csvDataArr, index++);          // ���P���S

                    work.PriceStartDate5 = ConvertToEmpty(csvDataArr, index++);       // ���i�J�n�N�����T
                    work.ListPrice5 = ConvertToEmpty(csvDataArr, index++);              // ���i�T
                    work.OpenPriceDiv5 = ConvertToEmpty(csvDataArr, index++);            // �I�[�v�����i�敪�T
                    work.StockRate5 = ConvertToEmpty(csvDataArr, index++);              // �d�����T
                    work.SalesUnitCost5 = ConvertToEmpty(csvDataArr, index++);          // ���P���T

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
        // ------------ADD END wangf 2012/06/12 FOR Redmine#30387---------<<<<

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
        #endregion
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="errorLogFileName">�G���[���O�o�̓t�@�C���o�X</param>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
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
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
        #region �G���[�f�[�^�e�[�u���ւ���
        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                  //  ���i�ԍ�
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add("GoodsNameRF", typeof(string));                //  ���i����
            dataTable.Columns.Add("GoodsNameKanaRF", typeof(string));            //  ���i���̃J�i
            dataTable.Columns.Add("JanRF", typeof(string));                      //  JAN�R�[�h

            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL���i�R�[�h
            dataTable.Columns.Add("EnterpriseGanreCodeRF", typeof(string));      // ���Е��ރR�[�h
            dataTable.Columns.Add("GoodsRateRankRF", typeof(string));            //  ���i�|�������N
            dataTable.Columns.Add("GoodsKindCodeRF", typeof(string));            //  ���i����
            dataTable.Columns.Add("TaxationDivCdRF", typeof(string));            //  �ېŋ敪
            dataTable.Columns.Add("GoodsNote1RF", typeof(string));               //  ���i���l�P
            dataTable.Columns.Add("GoodsNote2RF", typeof(string));               //  ���i���l�Q
            dataTable.Columns.Add("GoodsSpecialNoteRF", typeof(string));         //  ���i�K�i�E���L����

            dataTable.Columns.Add("PriceStartDateRF1", typeof(string));           //  ���i�J�n���P
            dataTable.Columns.Add("ListPriceRF1", typeof(string));                //  �艿�i�����j�P
            dataTable.Columns.Add("OpenPriceDivRF1", typeof(string));             //  �I�[�v�����i�敪�P
            dataTable.Columns.Add("StockRateRF1", typeof(string));                //  �d�����P
            dataTable.Columns.Add("SalesUnitCostRF1", typeof(string));            //  �����P���P

            dataTable.Columns.Add("PriceStartDateRF2", typeof(string));           //  ���i�J�n���Q
            dataTable.Columns.Add("ListPriceRF2", typeof(string));                //  �艿�i�����j�Q
            dataTable.Columns.Add("OpenPriceDivRF2", typeof(string));             //  �I�[�v�����i�敪�Q
            dataTable.Columns.Add("StockRateRF2", typeof(string));                //  �d�����Q
            dataTable.Columns.Add("SalesUnitCostRF2", typeof(string));            //  �����P���Q

            dataTable.Columns.Add("PriceStartDateRF3", typeof(string));           //  ���i�J�n���R
            dataTable.Columns.Add("ListPriceRF3", typeof(string));                //  �艿�i�����j�R
            dataTable.Columns.Add("OpenPriceDivRF3", typeof(string));             //  �I�[�v�����i�敪�R
            dataTable.Columns.Add("StockRateRF3", typeof(string));                //  �d�����R
            dataTable.Columns.Add("SalesUnitCostRF3", typeof(string));            //  �����P���R

            dataTable.Columns.Add("PriceStartDateRF4", typeof(string));           //  ���i�J�n���S
            dataTable.Columns.Add("ListPriceRF4", typeof(string));                //  �艿�i�����j�S
            dataTable.Columns.Add("OpenPriceDivRF4", typeof(string));             //  �I�[�v�����i�敪�S
            dataTable.Columns.Add("StockRateRF4", typeof(string));                //  �d�����S
            dataTable.Columns.Add("SalesUnitCostRF4", typeof(string));            //  �����P���S

            dataTable.Columns.Add("PriceStartDateRF5", typeof(string));           //  ���i�J�n���T
            dataTable.Columns.Add("ListPriceRF5", typeof(string));                //  �艿�i�����j�T
            dataTable.Columns.Add("OpenPriceDivRF5", typeof(string));             //  �I�[�v�����i�敪�T
            dataTable.Columns.Add("StockRateRF5", typeof(string));                //  �d�����T
            dataTable.Columns.Add("SalesUnitCostRF5", typeof(string));            //  �����P���T

            dataTable.Columns.Add("ErrorMessage", typeof(string));            //  �G���[���e
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="goodsUWork">��������</param>
        /// <param name="dataTable">����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsUGoodsPriceUWork goodsUWork, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["GoodsNoRF"] = goodsUWork.GoodsNo;
            dataRow["GoodsMakerCdRF"] = goodsUWork.GoodsMakerCd;
            dataRow["GoodsNameRF"] = goodsUWork.GoodsName;
            dataRow["GoodsNameKanaRF"] = goodsUWork.GoodsNameKana;
            dataRow["JanRF"] = goodsUWork.Jan;
            dataRow["BLGoodsCodeRF"] = goodsUWork.BLGoodsCode;
            dataRow["EnterpriseGanreCodeRF"] = goodsUWork.EnterpriseGanreCode;
            dataRow["GoodsRateRankRF"] = goodsUWork.GoodsRateRank;
            dataRow["GoodsKindCodeRF"] = goodsUWork.GoodsKindCode;
            dataRow["TaxationDivCdRF"] = goodsUWork.TaxationDivCd;
            dataRow["GoodsNote1RF"] = goodsUWork.GoodsNote1;
            dataRow["GoodsNote2RF"] = goodsUWork.GoodsNote2;
            dataRow["GoodsSpecialNoteRF"] = goodsUWork.GoodsSpecialNote;
            Type type = goodsUWork.GetType();
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                dataRow["PriceStartDateRF" + index] = type.GetProperty("PriceStartDate" + index).GetValue(goodsUWork, null);
                dataRow["ListPriceRF" + index] = type.GetProperty("ListPrice" + index).GetValue(goodsUWork, null);
                dataRow["OpenPriceDivRF" + index] = type.GetProperty("OpenPriceDiv" + index).GetValue(goodsUWork, null);
                dataRow["StockRateRF" + index] = type.GetProperty("StockRate" + index).GetValue(goodsUWork, null);
                dataRow["SalesUnitCostRF" + index] = type.GetProperty("SalesUnitCost" + index).GetValue(goodsUWork, null);
            }
            dataRow["ErrorMessage"] = goodsUWork.ErrorMsg;
            dataTable.Rows.Add(dataRow);
        }
        #endregion
        // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<

        #endregion �� Private Method
    }
}
