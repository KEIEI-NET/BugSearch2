//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ʃ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���ʃ}�X�^�i�G�N�X�|�[�g�j���s��
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
using System.Text;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���ʃ}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ʃ}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class PartsPosCodeExportAcs
    {
        #region �� Private Member
        private IPartsPosCodeUDB _iPartsPosCodeUDB;
        private const string PRINTSET_TABLE = "PartsPosExp";
        #endregion

        # region ��Constracter
        /// <summary>
        /// ���ʃ}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ʃ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public PartsPosCodeExportAcs()
        {
            _iPartsPosCodeUDB = (IPartsPosCodeUDB)MediationPartsPosCodeUDB.GetPartsPosCodeUDB();
        }
        # endregion

        #region �� ���ʃ}�X�^��񌟍�
        /// <summary>
        /// ���ʃ}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���ʃ}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(PartsPosCodeExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);
            Object retobj = new ArrayList();
            //retobj = (ArrayList)retobj;
            
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
            partsPosCodeUWork.EnterpriseCode = condition.EnterpriseCode;
            partsPosCodeUWork.LogicalDeleteCode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            // ����
            status = this._iPartsPosCodeUDB.Search(ref retobj, partsPosCodeUWork, 0, logicalMode);

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
        # endregion

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
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));                 //  ���Ӑ�R�[�h
            dataTable.Columns.Add("SearchPartsPosCodeRF", typeof(string));	        //  �������ʃR�[�h
            dataTable.Columns.Add("SearchPartsPosNameRF", typeof(string));	        //  �������ʃR�[�h����
            dataTable.Columns.Add("PosDispOrderRF", typeof(Int32));	                //  �������ʕ\������
            dataTable.Columns.Add("TbsPartsCodeRF", typeof(string));	                //  BL���i�R�[�h
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(ArrayList retList, PartsPosCodeExportWork condition, ref DataTable dataTable)
        {
            foreach (PartsPosCodeUWork partsPosCodeU in retList)
            {
                if (DataCheck(partsPosCodeU, condition) == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["CustomerCodeRF"] = AppendZero(partsPosCodeU.CustomerCode.ToString(), 8);
                    dataRow["SearchPartsPosCodeRF"] = AppendZero(partsPosCodeU.SearchPartsPosCode.ToString(), 2);
                    dataRow["SearchPartsPosNameRF"] = GetSubString(partsPosCodeU.SearchPartsPosName, 20);
                    dataRow["PosDispOrderRF"] = partsPosCodeU.PosDispOrder;
                    dataRow["TbsPartsCodeRF"] = AppendZero(partsPosCodeU.TbsPartsCode.ToString(), 5);
                    dataTable.Rows.Add(dataRow);
                }

            }
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="partsPosCodeU">���ʃf�[�^</param>
        /// <param name="condition">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(PartsPosCodeUWork partsPosCodeU, PartsPosCodeExportWork condition)
        {
            int status = 0;
            if (partsPosCodeU.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }
            if (partsPosCodeU.OfferDataDiv != 0)
            {
                status = -1;
                return status;
            }
            int customerCd = partsPosCodeU.CustomerCode;
            if (condition.CustomerCodeSt != 0 && customerCd < condition.CustomerCodeSt)
            {
                status = -1;
                return status;

            }
            if (condition.CustomerCodeEd != 0 && customerCd > condition.CustomerCodeEd)
            {
                status = -1;
                return status;
            }
            int partsPosCode = partsPosCodeU.SearchPartsPosCode;
            if (condition.SearchPartsPosCodeSt != 0 && partsPosCode < condition.SearchPartsPosCodeSt)
            {
                status = -1;
                return status;

            }
            if (condition.SearchPartsPosCodeEd != 0 && partsPosCode > condition.SearchPartsPosCodeEd)
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
            StringBuilder tempBuild = new StringBuilder();
            bfString = bfString.Trim();
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
            bfString = bfString.Trim();
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
        # endregion
    }
}
