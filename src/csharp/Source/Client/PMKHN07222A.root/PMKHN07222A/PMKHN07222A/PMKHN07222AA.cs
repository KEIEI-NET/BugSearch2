//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �q�Ƀ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �q�Ƀ}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class WarehouseExportAcs
    {
        #region �� Private Member
        private IWarehouseDB _iwarehouseDB = null;
        private const string PRINTSET_TABLE = "WarehouseExp";
        #endregion

        # region ��Constracter
        /// <summary>
        /// �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public WarehouseExportAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iwarehouseDB = (IWarehouseDB)MediationWarehouseDB.GetWarehouseDB();
        }
        #endregion

        #region �� �q�Ƀ}�X�^��񌟍�
        /// <summary>
        /// �q�Ƀ}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(WarehouseExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);
            object retobj = null;
            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = condition.EnterpriseCode;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            // ����
            status = this._iwarehouseDB.Search(out retobj, warehouseWork, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ConverToDataSetWarehouseInf((ArrayList)retobj, condition, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region �� Private Methods
        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("WarehouseCodeRF", typeof(string));           //  �q�ɃR�[�h
            dataTable.Columns.Add("WarehouseNameRF", typeof(string));	        //  �q�ɖ���
            dataTable.Columns.Add("SectionCodeRF", typeof(string));	            //  ���_�R�[�h
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));	            //  ���Ӑ�R�[�h
            dataTable.Columns.Add("MainMngWarehouseCdRF", typeof(string));	    //  ��Ǒq�ɃR�[�h
            dataTable.Columns.Add("StockBlnktRemark1RF", typeof(string));	    //  �݌Ɉꊇ���}�[�N�i�R�j
            dataTable.Columns.Add("StockBlnktRemark2RF", typeof(string));	    //  �݌Ɉꊇ���}�[�N�i�T�j
            dataTable.Columns.Add("WarehouseNote1RF", typeof(string));	        //  �q�ɔ��l1
        }



        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�߂錋��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(ArrayList retList, WarehouseExportWork condition, ref DataTable dataTable)
        {
            foreach (WarehouseWork warehouseWork in retList)
            {
                if (DataCheck(warehouseWork, condition) == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    // �q�ɃR�[�h
                    dataRow["WarehouseCodeRF"] = AppendStrZero(warehouseWork.WarehouseCode.Trim(), 4);
                    // �q�ɖ���
                    dataRow["WarehouseNameRF"] = GetSubString(warehouseWork.WarehouseName.Trim(), 20);
                    // ���_�R�[�h
                    dataRow["SectionCodeRF"] = AppendStrZero(warehouseWork.SectionCode.Trim(), 2);
                    // ���Ӑ�R�[�h
                    dataRow["CustomerCodeRF"] = AppendZero(warehouseWork.CustomerCode.ToString(),8);
                    // ��Ǒq�ɃR�[�h
                    dataRow["MainMngWarehouseCdRF"] = AppendStrZero(warehouseWork.MainMngWarehouseCd.Trim(), 4);

                    if (!String.IsNullOrEmpty(warehouseWork.StockBlnktRemark.Trim()) && warehouseWork.StockBlnktRemark.Trim().Length >= 3)
                    {
                        // �݌Ɉꊇ���}�[�N�i�R�j
                        dataRow["StockBlnktRemark1RF"] = warehouseWork.StockBlnktRemark.Substring(0, 3).Trim();
                    }
                    else
                    {
                        dataRow["StockBlnktRemark1RF"] = warehouseWork.StockBlnktRemark.Trim();
                    }
                    if (!String.IsNullOrEmpty(warehouseWork.StockBlnktRemark.Trim()) && warehouseWork.StockBlnktRemark.Trim().Length >= 4)
                    {
                        // �݌Ɉꊇ���}�[�N�i�T�j
                        if (warehouseWork.StockBlnktRemark.Length > 8)
                        {
                            dataRow["StockBlnktRemark2RF"] = warehouseWork.StockBlnktRemark.Substring(3, 5).Trim();
                        }
                        else
                        {
                            dataRow["StockBlnktRemark2RF"] = warehouseWork.StockBlnktRemark.Substring(3, warehouseWork.StockBlnktRemark.Length - 3).Trim();
                        }

                    }
                    else
                    {
                        dataRow["StockBlnktRemark2RF"] = "";
                    }

                    // �q�ɔ��l1
                    dataRow["WarehouseNote1RF"] = GetSubString(warehouseWork.WarehouseNote1.Trim(), 40);

                    dataTable.Rows.Add(dataRow);
                }

            }
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="warehouseWork">�q�Ƀf�[�^</param>
        /// <param name="condition">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataCheck(WarehouseWork warehouseWork, WarehouseExportWork condition)
        {
            int status = 0;
            int warehouseCd = Int32.Parse(warehouseWork.WarehouseCode.Trim());
            if (!String.IsNullOrEmpty(condition.WarehouseCdSt.Trim()) && warehouseCd < Int32.Parse(condition.WarehouseCdSt.Trim()))
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(condition.WarehouseCdEd.Trim()) && warehouseCd > Int32.Parse(condition.WarehouseCdEd.Trim()))
            {
                status = -1;
                return status;
            }
            return status;
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString();
        }
        #endregion
    }
}
