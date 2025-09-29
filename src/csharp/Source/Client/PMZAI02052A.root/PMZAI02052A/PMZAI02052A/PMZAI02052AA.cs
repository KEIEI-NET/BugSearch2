using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌ɊŔ���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �݌ɊŔ���Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.12.12</br>
    /// <br>Update Note  : 2009.01.06 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�9625(����^�C�v�u�݌ɐ����v�̏ꍇ�A�݌ɐ����������悤�C��)</br>
    /// <br>Update Note  : 2009/03/24 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�12717</br>
    /// </remarks>
    public class StockSignPrintAcs
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// �݌ɊŔ���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌ɊŔ���A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
		/// </remarks>
		public StockSignPrintAcs()
		{
            this._iStockSignOrderWorkDB = (IStockSignOrderWorkDB)MediationStockSignOrderWorkDB.GetStockSignOrderWorkDB();
		}

		/// <summary>
        /// ������e���͕\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ������e���͕\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.11</br>
		/// </remarks>
        static StockSignPrintAcs()
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
        IStockSignOrderWorkDB _iStockSignOrderWorkDB;

        private DataTable _stockSignResultDt; // �����[�g���o����DataTable
        private DataTable _printDt;           // ���DataTable (���[�P�s�f�[�^)
        private DataView _stockSignResultDv;  // ���DataView

        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView StockSignResultDataView
        {
            get { return this._stockSignResultDv; }
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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        public int SearchMain(StockSignOrderCndtn stockSignOrderCndtn, out string errMsg)
        {
            return this.SearchProc(stockSignOrderCndtn, out errMsg);
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
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private int SearchProc(StockSignOrderCndtn stockSignOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMZAI02059EA.CreateDataTable(ref this._stockSignResultDt);
                PMZAI02059EB.CreateDataTable(ref this._printDt);

                StockSignOrderCndtnWork stockSignOrderCndtnWork = new StockSignOrderCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(stockSignOrderCndtn, out stockSignOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iStockSignOrderWorkDB.Search(out retWorkList, stockSignOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(stockSignOrderCndtn, (ArrayList)retWorkList);
                        if (this._printDt.Rows.Count != 0) // ADD 2009/03/23
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�݌ɊŔ���f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private int DevListCndtn(StockSignOrderCndtn stockSignOrderCndtn, out StockSignOrderCndtnWork stockSignOrderCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSignOrderCndtnWork = new StockSignOrderCndtnWork();
            try
            {
                stockSignOrderCndtnWork.EnterpriseCode = stockSignOrderCndtn.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (stockSignOrderCndtn.SectionCodes.Length != 0)
                {
                    if (stockSignOrderCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        stockSignOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        stockSignOrderCndtnWork.SectionCodes = stockSignOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    stockSignOrderCndtnWork.SectionCodes = null;
                }

                stockSignOrderCndtnWork.St_WarehouseCode = stockSignOrderCndtn.St_WarehouseCode; // �q�ɃR�[�h(�J�n)
                stockSignOrderCndtnWork.Ed_WarehouseCode = stockSignOrderCndtn.Ed_WarehouseCode; // �q�ɃR�[�h(�I��)
                stockSignOrderCndtnWork.St_GoodsMakerCd = stockSignOrderCndtn.St_GoodsMakerCd; // ���i���[�J�[�R�[�h(�J�n)
                if (stockSignOrderCndtn.Ed_GoodsMakerCd == 0) stockSignOrderCndtnWork.Ed_GoodsMakerCd = 9999;
                else stockSignOrderCndtnWork.Ed_GoodsMakerCd = stockSignOrderCndtn.Ed_GoodsMakerCd; // ���i���[�J�[�R�[�h(�I��)
                stockSignOrderCndtnWork.St_WarehouseShelfNo = stockSignOrderCndtn.St_WarehouseShelfNo; // �q�ɒI��(�J�n)
                stockSignOrderCndtnWork.Ed_WarehouseShelfNo = stockSignOrderCndtn.Ed_WarehouseShelfNo; // �q�ɒI��(�I��)
                stockSignOrderCndtnWork.St_GoodsNo = stockSignOrderCndtn.St_GoodsNo; // ���i�ԍ�(�J�n)
                stockSignOrderCndtnWork.Ed_GoodsNo = stockSignOrderCndtn.Ed_GoodsNo; // ���i�ԍ�(�I��)
                stockSignOrderCndtnWork.PrintType = (int)stockSignOrderCndtn.PrintType; // �����


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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private void DevListData(StockSignOrderCndtn stockSignOrderCndtn, ArrayList resultWork)
        {
            // �����[�g���o���ʂ�DataTable�ɓW�J
            DataRow dr;

            foreach (StockSignResultWork stockSignResultWork in resultWork)
            {
                dr = this._stockSignResultDt.NewRow();

                dr[PMZAI02059EA.ct_Col_EnterpriseCode] = stockSignResultWork.EnterpriseCode; // ��ƃR�[�h
                dr[PMZAI02059EA.ct_Col_WarehouseCode] = stockSignResultWork.WarehouseCode; // �q�ɃR�[�h
                dr[PMZAI02059EA.ct_Col_WarehouseShelfNo] = stockSignResultWork.WarehouseShelfNo; // �q�ɒI��
                dr[PMZAI02059EA.ct_Col_GoodsNo] = stockSignResultWork.GoodsNo; // ���i�ԍ�
                dr[PMZAI02059EA.ct_Col_GoodsNameKana] = stockSignResultWork.GoodsNameKana; // ���i���̃J�i
                dr[PMZAI02059EA.ct_Col_MinimumStockCnt] = stockSignResultWork.MinimumStockCnt; // �Œ�݌ɐ�
                dr[PMZAI02059EA.ct_Col_MaximumStockCnt] = stockSignResultWork.MaximumStockCnt; // �ō��݌ɐ�
                dr[PMZAI02059EA.ct_Col_StockCreateDate] = stockSignResultWork.StockCreateDate; // �݌ɓo�^��
                dr[PMZAI02059EA.ct_Col_PriceStartDate] = stockSignResultWork.PriceStartDate; // ���i�J�n��
                dr[PMZAI02059EA.ct_Col_ListPrice] = stockSignResultWork.ListPrice; // �艿�i�����j
                dr[PMZAI02059EA.ct_Col_GoodsMakerCd] = stockSignResultWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
                dr[PMZAI02059EA.ct_Col_SectionCode] = stockSignResultWork.SectionCode; // ���_�R�[�h
                dr[PMZAI02059EA.ct_Col_SupplierStock] = stockSignResultWork.SupplierStock; // �d���݌ɐ� // ADD 2009/01/06

                this._stockSignResultDt.Rows.Add(dr);
            }

            // ���i�J�n���`�F�b�N
            DateTime now = DateTime.Now;

            foreach (DataRow row in this._stockSignResultDt.Rows)
            {
                if (((DateTime)row[PMZAI02059EA.ct_Col_PriceStartDate]).CompareTo(now) > 0)
                {
                    // ���i�J�n�������݂���ł���Β艿��0
                    row[PMZAI02059EA.ct_Col_ListPrice] = 0;
                }
            }

            // --- ADD 2009/01/06 -------------------------------->>>>>
            // ����^�C�v�u�݌ɖ������v�̏ꍇ�A���݌ɐ����ݒ�
            this.AddRowByStockNum(stockSignOrderCndtn);
            // --- ADD 2009/01/06 --------------------------------<<<<<
            // --- ADD 2009/03/23 -------------------------------->>>>>
            if (this._stockSignResultDt.Rows.Count == 0)
            {
                return;
            }
            // --- ADD 2009/03/23 --------------------------------<<<<<

            // �\�[�g����
            DataTable newTable = this._stockSignResultDt.Copy();
            this._stockSignResultDt.Clear();

            DataRow[] sortRowList = newTable.Select("", this.GetSortStr(stockSignOrderCndtn));

            foreach (DataRow sortRow in sortRowList)
            {
                this._stockSignResultDt.ImportRow(sortRow);
            }

            // �󎚂����
            int columnNum;

            if (stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine
                || stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine)
            {
                columnNum = 3;
            }
            else if (stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_FourByEleven)
            {
                columnNum = 4;
            }
            else
            {
                columnNum = 5;
            }

            // ���[�󎚂P�s�f�[�^DataTable�ւ̋l�֏���
            // �J�n�s�̐ݒ�
            if (stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_FourByEleven
                || stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine)
            {
                // ���[�U�[�̏ꍇ�A��ʎw�蕪��s��ݒ�
                for (int j = 0; j < (int)stockSignOrderCndtn.PrintStartRow; j++)
                {
                    // ��s���쐬
                    DataRow newRow = this._printDt.NewRow();
                    this._printDt.Rows.Add(newRow);
                }
            }
            else
            {
                // �h�b�g�̏ꍇ�A���[���1�s�ڂ��󂯂Ă���̂�
                // �i��ʎw��-1�j����s��ݒ�
                for (int j = 0; j < (int)stockSignOrderCndtn.PrintStartRow - 1; j++)
                {
                    // ��s���쐬
                    DataRow newRow = this._printDt.NewRow();
                    this._printDt.Rows.Add(newRow);
                }
            }

            // �����[�g���o���ʂ��璠�[�P�s�f�[�^�ɋl�ւ�
            for (int i = 0; i < this._stockSignResultDt.Rows.Count; i++)
            {
                DataRow stockSignRow = this._stockSignResultDt.Rows[i];

                if (i == 0
                    || i % columnNum == 0)
                {
                    // �񐔂Ŋ���؂���1���
                    DataRow newRow = this._printDt.NewRow();

                    newRow[PMZAI02059EB.ct_Col_InvisibleRow] = 1;
                    newRow[PMZAI02059EB.ct_Col_DataNum] = 1;
                    newRow[PMZAI02059EB.ct_Col_SectionCode1] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // ���_�R�[�h
                    newRow[PMZAI02059EB.ct_Col_WarehouseCode1] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// �q�ɃR�[�h
                    newRow[PMZAI02059EB.ct_Col_GoodsMakerCd1] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// ���[�J�[�R�[�h
                    newRow[PMZAI02059EB.ct_Col_WarehouseShelfNo1] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// �q�ɒI��
                    newRow[PMZAI02059EB.ct_Col_GoodsNo1] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// �i��
                    newRow[PMZAI02059EB.ct_Col_GoodsNameKana1] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// �i��
                    newRow[PMZAI02059EB.ct_Col_MinimumStockCnt1] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// �Œ�݌ɐ�
                    newRow[PMZAI02059EB.ct_Col_MaximumStockCnt1] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// �ō��݌ɐ�
                    newRow[PMZAI02059EB.ct_Col_StockCreateDate1] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// �݌ɓo�^��
                    newRow[PMZAI02059EB.ct_Col_ListPrice1] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// �艿�i�����j

                    this._printDt.Rows.Add(newRow);
                }
                else if (i % columnNum == 1)
                {
                    // �񐔂̏�]��1�ł����1���
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 2;
                    row[PMZAI02059EB.ct_Col_SectionCode2] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // ���_�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseCode2] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// �q�ɃR�[�h
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd2] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// ���[�J�[�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo2] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// �q�ɒI��
                    row[PMZAI02059EB.ct_Col_GoodsNo2] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// �i��
                    row[PMZAI02059EB.ct_Col_GoodsNameKana2] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// �i��
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt2] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// �Œ�݌ɐ�
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt2] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// �ō��݌ɐ�
                    row[PMZAI02059EB.ct_Col_StockCreateDate2] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// �݌ɓo�^��
                    row[PMZAI02059EB.ct_Col_ListPrice2] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// �艿�i�����j
                }
                else if (i % columnNum == 2)
                {
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 3;
                    row[PMZAI02059EB.ct_Col_SectionCode3] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // ���_�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseCode3] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// �q�ɃR�[�h
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd3] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// ���[�J�[�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo3] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// �q�ɒI��
                    row[PMZAI02059EB.ct_Col_GoodsNo3] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// �i��
                    row[PMZAI02059EB.ct_Col_GoodsNameKana3] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// �i��
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt3] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// �Œ�݌ɐ�
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt3] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// �ō��݌ɐ�
                    row[PMZAI02059EB.ct_Col_StockCreateDate3] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// �݌ɓo�^��
                    row[PMZAI02059EB.ct_Col_ListPrice3] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// �艿�i�����j
                }
                else if (i % columnNum == 3)
                {
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 4;
                    row[PMZAI02059EB.ct_Col_SectionCode4] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // ���_�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseCode4] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// �q�ɃR�[�h
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd4] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// ���[�J�[�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo4] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// �q�ɒI��
                    row[PMZAI02059EB.ct_Col_GoodsNo4] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// �i��
                    row[PMZAI02059EB.ct_Col_GoodsNameKana4] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// �i��
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt4] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// �Œ�݌ɐ�
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt4] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// �ō��݌ɐ�
                    row[PMZAI02059EB.ct_Col_StockCreateDate4] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// �݌ɓo�^��
                    row[PMZAI02059EB.ct_Col_ListPrice4] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// �艿�i�����j
                }
                else if (i % columnNum == 4)
                {
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 5;
                    row[PMZAI02059EB.ct_Col_SectionCode5] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // ���_�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseCode5] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// �q�ɃR�[�h
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd5] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// ���[�J�[�R�[�h
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo5] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// �q�ɒI��
                    row[PMZAI02059EB.ct_Col_GoodsNo5] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// �i��
                    row[PMZAI02059EB.ct_Col_GoodsNameKana5] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// �i��
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt5] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// �Œ�݌ɐ�
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt5] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// �ō��݌ɐ�
                    row[PMZAI02059EB.ct_Col_StockCreateDate5] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// �݌ɓo�^��
                    row[PMZAI02059EB.ct_Col_ListPrice5] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// �艿�i�����j
                }
            }

            // DataView�쐬
            // ���s�^�C�v�ɂ��\�[�g
            this._stockSignResultDv = new DataView(this._printDt, "", "", DataViewRowState.CurrentRows);
        }

        // --- ADD 2009/01/06 -------------------------------->>>>>
        /// <summary>
        /// �݌ɐ���Row�ǉ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       �@: �݌ɐ����s���𑝂₷</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2009.01.06</br>
        /// </remarks>
        private void AddRowByStockNum(StockSignOrderCndtn stockSignOrderCndtn)
        {
            if (stockSignOrderCndtn.PrintType == StockSignOrderCndtn.PrintTypeState.StockNum)
            {
                DataTable tmpDt = this._stockSignResultDt.Copy();
                this._stockSignResultDt.Clear();

                // �d���݌ɐ�(int)
                int stockNum;

                foreach (DataRow dr in tmpDt.Rows)
                {
                    // int�^�ɕϊ�(�؎̂�)
                    stockNum = (int)((double)dr[PMZAI02059EA.ct_Col_SupplierStock]);

                    // �݌ɐ����s�ǉ�
                    // �؎̂Č��ʂ�0�ɂȂ�ꍇ�͈󎚂��Ȃ�
                    for (int i = 0; i < stockNum; i++)
                    {
                        this._stockSignResultDt.ImportRow(dr);
                    }
                }
            }
        }
        // --- ADD 2009/01/06 --------------------------------<<<<<

        /// <summary>
        /// DataView�p�\�[�g������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       �@: �\�[�g��������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private string GetSortStr(StockSignOrderCndtn stockSignOrderCndtn)
        {
            StringBuilder sortStr = new StringBuilder();

            sortStr.Append(PMZAI02059EA.ct_Col_SectionCode);
            sortStr.Append(", ");

            sortStr.Append(PMZAI02059EA.ct_Col_WarehouseCode);
            sortStr.Append(", ");

            sortStr.Append(PMZAI02059EA.ct_Col_GoodsMakerCd);
            sortStr.Append(", ");

            if (stockSignOrderCndtn.PrintOrder == StockSignOrderCndtn.PrintOrderState.ShelfNo)
            {
                // ���_-�q��-���[�J�[-�I��-�i�ԏ�
                sortStr.Append(PMZAI02059EA.ct_Col_WarehouseShelfNo);
                sortStr.Append(", ");
            }
            else
            {
                // ���_-�q��-���[�J�[-�i�ԏ�
            }

            sortStr.Append(PMZAI02059EA.ct_Col_GoodsNo);

            return sortStr.ToString();

        }
        #endregion
    }
}
