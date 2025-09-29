//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�Ǘ��}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���q�Ǘ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� �� 2009/10/10   �C�����e : ��Q��Redmine#537�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� �� 2009/10/16   �C�����e : ��Q��Redmine#679�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� �� 2009/10/26   �C�����e : ��Q��Redmine#831,878�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�w�C��
// �C �� �� 2010/12/22   �C�����e : PM1015B�@���q�Ǘ��}�X�^�̎��R�����^���Œ�ԍ��z����R�s�[����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10900269-00  �쐬�S�� : FSI���� ����
// �C �� �� 2013/03/22   �C�����e : SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �C �� ��  2013/05/08  �C�����e : �S�̏����\���ݒ�̌����\���敪�i�N���j�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070091-00 �쐬�S�� : 杍^
// �C �� ��  2014/08/01  �C�����e : �S�̏����l�ݒ�}�X�^�f�[�^�擾��Q���C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;  // ADD 2013/05/08 Y.Wakita

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���q�Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�Ǘ��}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note : ���� 2009.10.10</br>
    /// <br>            : ��Q��Redmine#537�̏C��</br>
    /// <br>Update Note : ���� 2009.10.16</br>
    /// <br>            : ��Q��Redmine#679�̏C��</br>
    /// <br>Update Note: 2013/03/22 FSI���� ����</br>
    /// <br>�Ǘ��ԍ�   : 10900269-00</br>
    /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
    /// </remarks>
    public class CarMngListInputAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��private�ϐ�
        private static CarMngListInputAcs _carMngInputAcs;

        private CarMngInputDataSet _carMngInputDataSet;
        private CarMngInputDataSet.CarInfoDataTable _carInfoDataTable;
        private DataTable _originalCarInfoDataTable;
        private DataTable _csvCarInfoDataTable;

        private ICarManagementDB _iCarManagementDB;

        private string _enterpriseCode;

        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        // ���[�U�[�K�C�h�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;

        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, UserGdBd> _numberPlate1CodeDic;

        private CarMngInputAcs carMngInputAcs; // ADD 2013/05/08 Y.Wakita

        private int _index = 1;

        // ���q�Ǘ��敪
        Hashtable carMngDivHt = new Hashtable(); // ADD 2009/10/26
        # endregion

        // ===================================================================================== //
        // private�萔
        // ===================================================================================== //
        # region ��private�萔
        // �e��X�e�[�^�X
        /// <summary>
        /// �s��ԁA����
        /// </summary>
        public const int ROWSTATUS_NORMAL = 0;
        /// <summary>
        /// �s��ԁA�R�s�[
        /// </summary>
        public const int ROWSTATUS_COPY = 1;

        /// <summary>
        /// �s����
        /// </summary>
        public const int DELETE_FLAG0 = 0;

        /// <summary>
        /// �s�_���폜
        /// </summary>
        public const int DELETE_FLAG1 = 1;
        /// <summary>
        /// �V�K�s
        /// </summary>
        public const string ROWNO_NEW = "�V�K";

        // --- ADD 2009/10/26 ----->>>>>
        /// <summary>
        /// �ۑ��\�s
        /// </summary>
        public const int SAVECAN_FLAG0 = 0;
        /// <summary>
        /// �ۑ��s�s
        /// </summary>
        public const int SAVECAN_FLAG1 = 1;
        // --- ADD 2009/10/26 -----<<<<<

        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��public�v���p�e�B
        /// <summary>
        /// ���q�Ǘ��}�X�^�e�[�u���v���p�e�B
        /// </summary>
        public CarMngInputDataSet.CarInfoDataTable CarInfoDataTable
        {
            get { return _carInfoDataTable; }
        }

        /// <summary>
        /// �������̏��i�݌Ƀf�[�^�e�[�u���v���p�e�B
        /// </summary>
        public DataTable OriginalCarInfoDataTable
        {
            get { return _originalCarInfoDataTable; }
        }

        /// <summary>
        /// ���Ӑ挟���}�X�^�v���p�e�B
        /// </summary>
        public Dictionary<int, CustomerSearchRet> CustomerSearchRetDic
        {
            get { return _customerSearchRetDic; }
        }

        /// <summary>
        /// ���^�������ԍ��v���p�e�B
        /// </summary>
        public Dictionary<int, UserGdBd> NumberPlate1CodeDic
        {
            get { return _numberPlate1CodeDic; }
        }
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ���R���X�g���N�^
        /// <summary>
        /// ���q�Ǘ��}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private CarMngListInputAcs()
        {
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._carMngInputDataSet = new CarMngInputDataSet();
            this._carInfoDataTable = this._carMngInputDataSet.CarInfo;
            this._originalCarInfoDataTable = this._carInfoDataTable.Clone();
            this._csvCarInfoDataTable = new DataTable();

            this._carInfoDataTable.CaseSensitive = true;
            this._originalCarInfoDataTable.CaseSensitive = true;
            this._csvCarInfoDataTable.CaseSensitive = true;

            this._iCarManagementDB = MediationCarManagementDB.GetCarManagementDB();

            this._customerInfoAcs = new CustomerInfoAcs();

            this._userGuideAcs = new UserGuideAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            this.LoadCustomerSearchRet();
            this.LoadNumberPlate1Code();
        }

        /// <summary>
        /// ���q�Ǘ��}�X�^�A�N�Z�X�N���X�̃C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X�̃C���X�^���X���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public static CarMngListInputAcs GetInstance()
        {
            if (_carMngInputAcs == null)
            {
                _carMngInputAcs = new CarMngListInputAcs();
            }

            return _carMngInputAcs;
        }

        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ��public���\�b�h
        #region �� ��������
        /// <summary>
        /// �ԗ��Ǘ��}�X�^�����������܂��B
        /// </summary>
        /// <param name="extractInfo">��������</param>
        /// <param name="errMsg">�G���[message</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int Search(CarManagementExtractInfo extractInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            // �����f�[�^�N���A
            this._carInfoDataTable.Clear();
            this._originalCarInfoDataTable.Clear();
            this._csvCarInfoDataTable.Clear();

            try
            {
                // ��������
                CarManagementWork carManagementObj = this.CopyToCarManagementWorkFromExtractInfo(extractInfo);
                carManagementObj.EnterpriseCode = extractInfo.EnterpriseCode;
                carManagementObj.LogicalDeleteCode = 1;

                // ��������
                ArrayList carManagementList = new ArrayList();
                object objCarManagementList = (object)carManagementList;

                // ����
                status = this._iCarManagementDB.Search(ref objCarManagementList, carManagementObj, 0, ConstantManagement.LogicalMode.GetData01);

                // ����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = objCarManagementList as ArrayList;
                    
                    // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
                    // �S�̏����l�ݒ�}�X�^
                    carMngInputAcs = new CarMngInputAcs();

                    this.carMngInputAcs.ReadInitData(this._enterpriseCode, "00");
                    // --- ADD 2013/05/08 Y.Wakita ----------<<<<<
                    
                    this._index = 1;
                    foreach (CarManagementWork work in resultList)
                    {
                        CarMngInputDataSet.CarInfoRow row = this._carInfoDataTable.NewCarInfoRow();
                        row = this.CopyToRowFromCarManagementWork(work);

                        // RowNo�̏���
                        if (row["DeleteDate"] != DBNull.Value)
                        {
                            // �_���폜�����f�[�^
                            row.RowNo = "-";
                        }
                        else
                        {
                            // ����f�[�^
                            row.RowNo = Convert.ToString(this._index);
                            this._index++;
                        }

                        this._carInfoDataTable.AddCarInfoRow(row);
                    }

                    this._originalCarInfoDataTable = this._carInfoDataTable.Copy();
                    this._csvCarInfoDataTable = this._carInfoDataTable.Copy();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                // ���ʂȂ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    this._carInfoDataTable.Clear();
                    this._originalCarInfoDataTable.Clear();
                    this._csvCarInfoDataTable.Clear();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                // ���̑��G���[�ꍇ
                else
                {
                    this._carInfoDataTable.Clear();
                    this._originalCarInfoDataTable.Clear();
                    this._csvCarInfoDataTable.Clear();
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }
        #endregion

        #region �� �ۑ�����
        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="msg">message</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int Write(out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = string.Empty;

            try
            {
                CustomSerializeArrayList carManagementList = new CustomSerializeArrayList();
                CustomSerializeArrayList updateDataList = new CustomSerializeArrayList();
                CustomSerializeArrayList logicDeleteDataList = new CustomSerializeArrayList();

                // �ԗ��Ǘ��}�X�^���̍X�V�f�[�^�̎捞����
                status = this.GetDataListFromGoodsStockDataTable(out updateDataList, out logicDeleteDataList);

                // �捞����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    carManagementList.Add(updateDataList);
                    carManagementList.Add(logicDeleteDataList);

                    object carManagementListObj = (object)carManagementList;
                    // �����Ƙ_���폜�����B
                    status = this._iCarManagementDB.WriteAndLogicDelete(ref carManagementListObj);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̍X�V�f�[�^�̎捞�����B
        /// </summary>
        /// <param name="logicDeleteDataList">�X�V�f�[�^</param>
        /// <param name="updateDataList">�폜�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ԗ��Ǘ��}�X�^���̍X�V�f�[�^���捞���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private int GetDataListFromGoodsStockDataTable(out CustomSerializeArrayList updateDataList, out CustomSerializeArrayList logicDeleteDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            updateDataList = new CustomSerializeArrayList();
            logicDeleteDataList = new CustomSerializeArrayList();

            try
            {
                // �V�K�s
                CarMngInputDataSet.CarInfoRow[] newRows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.RowNoColumn.ColumnName + " = '" + ROWNO_NEW + "'");
                
                if ((newRows != null) && (newRows.Length > 0))
                {
                    foreach (CarMngInputDataSet.CarInfoRow row in newRows)
                    {
                        updateDataList.Add(this.CopyToCarManagementWorkFromRow(row));
                    }
                }

                // �C���s
                foreach (DataRow row in this._originalCarInfoDataTable.Rows)
                {
                    Guid key = (Guid)row[this._carInfoDataTable.CarRelationGuidColumn.ColumnName];
                    CarMngInputDataSet.CarInfoRow ultraRow = this._carInfoDataTable.FindByCarRelationGuid(key);

                    if (ultraRow == null)
                    {
                        continue;
                    }
                    for (int j = 8; j < this._carInfoDataTable.Columns.Count; j++)
                    {
                        if (ultraRow[j].ToString() != row[j].ToString())
                        {
                            updateDataList.Add(this.CopyToCarManagementWorkFromRow(ultraRow));
                            break;
                        }
                    }
                }

                // �_���폜�s
                CarMngInputDataSet.CarInfoRow[] logicRows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.DeleteFlagColumn.ColumnName + " = " + DELETE_FLAG1.ToString());
                if ((logicRows != null) && (logicRows.Length > 0))
                {
                    foreach (CarMngInputDataSet.CarInfoRow row in logicRows)
                    {
                        logicDeleteDataList.Add(this.CopyToCarManagementWorkFromRow(row));
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region �� ���̑�����
        /// <summary>
        /// ���׃f�[�^�e�[�u��CarInfoRow�񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃f�[�^�e�[�u��CarInfoRow�񏉊����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void InitializeCarInfoRowNoColumn()
        {
            this._carInfoDataTable.BeginLoadData();
            for (int i = 0; i < this._carInfoDataTable.Rows.Count; i++)
            {
                this._carInfoDataTable[i].RowNo = Convert.ToString(i + 1);
            }
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u��RowStatus�񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃f�[�^�e�[�u��RowStatus�񏉊����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void InitializeCarInfoRowStatusColumn()
        {
            CarMngInputDataSet.CarInfoRow[] rows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.RowStatusColumn.ColumnName + " <> " + ROWSTATUS_NORMAL.ToString());

            this._carInfoDataTable.BeginLoadData();
            foreach (CarMngInputDataSet.CarInfoRow row in rows)
            {
                row.RowStatus = ROWSTATUS_NORMAL;
            }
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u��RowStatus��l�ݒ菈��
        /// </summary>
        /// <param name="rowIndexList">���׍s�ԍ����X�g</param>
        /// <param name="rowStatus">RowStatus�l</param>
        /// <remarks>
        /// <br>Note       : ���׃f�[�^�e�[�u��RowStatus��l�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SetCarInfoRowStatusColumn(List<Guid> rowIndexList, int rowStatus)
        {
            this._carInfoDataTable.BeginLoadData();
            foreach (Guid key in rowIndexList)
            {
                CarMngInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid(key);

                //if (row.RowStatus == ROWSTATUS_LOGICDELETE)
                //{
                //    continue;
                //}

                row.RowStatus = rowStatus;
            }
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// �R�s�[���׍s�ԍ��擾����
        /// </summary>
        /// <returns>�s�ԍ����X�g</returns>
        /// <remarks>
        /// <br>Note       : �R�s�[���׍s�ԍ��擾�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public List<Guid> GetCopyCarInfoRowNo()
        {
            CarMngInputDataSet.CarInfoRow[] rows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.RowStatusColumn.ColumnName + " = " + ROWSTATUS_COPY.ToString());

            if ((rows != null) && (rows.Length > 0))
            {
                List<Guid> carInfoRowNoList = new List<Guid>();
                foreach (CarMngInputDataSet.CarInfoRow row in rows)
                {
                    carInfoRowNoList.Add(row.CarRelationGuid);
                }

                return carInfoRowNoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ���׍s�\��t������
        /// </summary>
        /// <param name="copyCarInfoRowNoList">�R�s�[���s�ԍ����X�g</param>
        /// <remarks>
        /// <br>Note       : ���׍s�\��t���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void PasteInsertCarInfoRow(List<Guid> copyCarInfoRowNoList)
        {
            foreach (Guid key in copyCarInfoRowNoList)
            {
                CarMngInputDataSet.CarInfoRow sourceRow = this._carInfoDataTable.FindByCarRelationGuid(key);
                CarMngInputDataSet.CarInfoRow targetRow = this._carInfoDataTable.NewCarInfoRow();
                
                this.CopyCarInfoRow(sourceRow, targetRow);

                // �u���Ӑ�R�[�h�v�́u�󔒁v�Ƃ���B
                targetRow.SaveCanFlag = SAVECAN_FLAG1;  // 2009/10/26 ADD
                targetRow.CarRelationGuid = Guid.NewGuid();
                targetRow.UpdateDateTime = DateTime.MinValue;
                targetRow.LogicalDeleteCode = 0;
                targetRow.CustomerCode = string.Empty;
                targetRow.CarMngNo = "0";

                this._carInfoDataTable.AddCarInfoRow(targetRow);
            }
        }

        /// <summary>
        /// �sADD����
        /// </summary>
        /// <param name="sourceRow">�R�s�[���s</param>
        /// <remarks>
        /// <br>Note       : ���׍s�\��t���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void InsertCarInfoRow(CarMngInputDataSet.CarInfoRow sourceRow)
        {
            this._carInfoDataTable.BeginLoadData(); 
            this._originalCarInfoDataTable.BeginLoadData();

            CarMngInputDataSet.CarInfoRow targetRow = this._carInfoDataTable.NewCarInfoRow();

            this.CopyCarInfoRow(sourceRow, targetRow);

            targetRow.CarRelationGuid = Guid.NewGuid();
            // No
            // --- ADD 2009/10/16 ------>>>>>
            if (this._carInfoDataTable.Count == 0)
            {
                this._index = 1;
            }
            // --- ADD 2009/10/16 ------<<<<<
            targetRow.RowNo = Convert.ToString(this._index++);

            this._carInfoDataTable.AddCarInfoRow(targetRow);

            this._originalCarInfoDataTable.ImportRow(targetRow);

            this._carInfoDataTable.EndLoadData();
            this._originalCarInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// �sUPDATE����
        /// </summary>
        /// <param name="sourceRow">CarInfoRow�s</param>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�i�f�[�^���́j�̕ۑ��ꍇ�A���̏������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void UpdateOriginalRow(CarMngInputDataSet.CarInfoRow sourceRow)
        {
            this._originalCarInfoDataTable.BeginLoadData();

            DataRow row = this._originalCarInfoDataTable.Rows.Find(sourceRow.CarRelationGuid);

            if (row == null) return;

            for (int j = 0; j < this._originalCarInfoDataTable.Columns.Count; j++)
            {
                row[j] = sourceRow[j];
            }

            this._originalCarInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// �sDELETE����
        /// </summary>
        /// <param name="sourceRow">CarInfoRow�s</param>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�i�f�[�^���́j�̊��S�폜�ꍇ�A���̏������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void DeleteOriginalTableRow(CarMngInputDataSet.CarInfoRow sourceRow)
        {
            this._originalCarInfoDataTable.BeginLoadData();

            DataRow row = this._originalCarInfoDataTable.Rows.Find(sourceRow.CarRelationGuid);

            if (row == null) return;
            this._originalCarInfoDataTable.Rows.Remove(row);

            this._originalCarInfoDataTable.AcceptChanges();
            this._originalCarInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׍s�폜����
        /// </summary>
        /// <param name="carInfoRowNoList">�폜�sStockRowNo���X�g</param>
        /// <remarks>
        /// <br>Note       : ���׍s�폜�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void DeleteCarInfoRow(List<Guid> carInfoRowNoList)
        {
            this._carInfoDataTable.BeginLoadData();
            foreach (Guid key in carInfoRowNoList)
            {
                CarMngInputDataSet.CarInfoRow targetRow = this._carInfoDataTable.FindByCarRelationGuid(key);
                if (targetRow == null) continue;

                if (targetRow[this._carInfoDataTable.RowNoColumn.ColumnName].ToString() == ROWNO_NEW)
                {
                    // �ǉ��s�̏ꍇ�A�폜����
                    this._carInfoDataTable.RemoveCarInfoRow(targetRow);
                    continue;
                }
                else
                {
                    targetRow.DeleteFlag = DELETE_FLAG1;
                }
            }

            // ���׃f�[�^�e�[�u��RowNo�񏉊�������
            //this.InitializeCarInfoRowNoColumn();
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׃R�s�[�s����
        /// </summary>
        /// <param name="sourceRow">�R�s�[�sFrom</param>
        /// <param name="targetRow">�R�s�[�sTo</param>
        /// <remarks>
        /// <br>Note       : ���׃R�s�[�s�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>update Note  : PM1015B�@���q�Ǘ��}�X�^�̎��R�����^���Œ�ԍ��z����R�s�[����悤�ɏC��</br>
        /// <br>             �@�{�w�C��</br>
        /// <br>Date       �@: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        public void CopyCarInfoRow(CarMngInputDataSet.CarInfoRow sourceRow, CarMngInputDataSet.CarInfoRow targetRow)
        {
            //targetRow.CarRelationGuid = sourceRow.CarRelationGuid;
            targetRow.FileHeaderGuid = sourceRow.FileHeaderGuid;
            targetRow.CreateDateTime = sourceRow.CreateDateTime;
            targetRow.UpdateDateTime = sourceRow.UpdateDateTime;

            targetRow.RowStatus = ROWSTATUS_NORMAL;
            targetRow.DeleteFlag = DELETE_FLAG0;
            targetRow.SaveCanFlag = sourceRow.SaveCanFlag; // 2009/10/26 ADD

            targetRow.LogicalDeleteCode = sourceRow.LogicalDeleteCode;
            targetRow.CustomerCode = this.StrPadLeft0(sourceRow.CustomerCode, 8);
            targetRow.CarMngNo = sourceRow.CarMngNo;
            targetRow.CarMngCode = sourceRow.CarMngCode;
            targetRow.NumberPlate1Code = this.StrPadLeft0(sourceRow.NumberPlate1Code, 4);
            // ----ADD 2009/10/10 ------>>>>>
            if (sourceRow.NumberPlate1Name.Length > 4)
            {
                targetRow.NumberPlate1Name = sourceRow.NumberPlate1Name.Substring(0, 4);
            }
            else
            {
                targetRow.NumberPlate1Name = sourceRow.NumberPlate1Name;
            }
            // ----ADD 2009/10/10 ------<<<<<
            targetRow.NumberPlate2 = sourceRow.NumberPlate2;
            targetRow.NumberPlate3 = sourceRow.NumberPlate3;
            targetRow.NumberPlate4 = sourceRow.NumberPlate4;

            if (sourceRow[this._carInfoDataTable.EntryDateColumn.ColumnName] != DBNull.Value
                && sourceRow.EntryDate != string.Empty)
            {
                targetRow.EntryDate = sourceRow.EntryDate;
            }

            if (sourceRow[this._carInfoDataTable.FirstEntryDateColumn.ColumnName] != DBNull.Value
                //&& sourceRow.FirstEntryDate != DateTime.MinValue)
                && sourceRow.FirstEntryDate != string.Empty)  // ADD 2009/10/10
            {
                targetRow.FirstEntryDate = sourceRow.FirstEntryDate;
            }
            targetRow.MakerCode = sourceRow.MakerCode;
            targetRow.MakerFullName = sourceRow.MakerFullName;
            targetRow.MakerHalfName = sourceRow.MakerHalfName;
            targetRow.ModelCode = sourceRow.ModelCode;
            targetRow.ModelSubCode = sourceRow.ModelSubCode;
            targetRow.ModelFullName = sourceRow.ModelFullName;
            targetRow.ModelHalfName = sourceRow.ModelHalfName;
            targetRow.SystematicCode = sourceRow.SystematicCode;
            targetRow.SystematicName = sourceRow.SystematicName;
            targetRow.ProduceTypeOfYearCd = sourceRow.ProduceTypeOfYearCd;
            targetRow.ProduceTypeOfYearNm = sourceRow.ProduceTypeOfYearNm;
            targetRow.StProduceTypeOfYear = sourceRow.StProduceTypeOfYear;
            targetRow.EdProduceTypeOfYear = sourceRow.EdProduceTypeOfYear;
            targetRow.DoorCount = sourceRow.DoorCount;
            targetRow.BodyNameCode = sourceRow.BodyNameCode;
            targetRow.BodyName = sourceRow.BodyName;
            targetRow.ExhaustGasSign = sourceRow.ExhaustGasSign;
            targetRow.SeriesModel = sourceRow.SeriesModel;
            targetRow.CategorySignModel = sourceRow.CategorySignModel;
            targetRow.FullModel = sourceRow.FullModel;
            targetRow.ModelDesignationNo = this.StrPadLeft0(sourceRow.ModelDesignationNo, 5);
            targetRow.CategoryNo = this.StrPadLeft0(sourceRow.CategoryNo, 4);
            targetRow.FrameModel = sourceRow.FrameModel;
            targetRow.FrameNo = sourceRow.FrameNo;
            targetRow.SearchFrameNo = sourceRow.SearchFrameNo;
            targetRow.StProduceFrameNo = sourceRow.StProduceFrameNo;
            targetRow.EdProduceFrameNo = sourceRow.EdProduceFrameNo;
            targetRow.EngineModel = sourceRow.EngineModel;
            targetRow.ModelGradeNm = sourceRow.ModelGradeNm;
            targetRow.EngineModelNm = sourceRow.EngineModelNm;
            targetRow.EngineDisplaceNm = sourceRow.EngineDisplaceNm;
            targetRow.EDivNm = sourceRow.EDivNm;
            targetRow.TransmissionNm = sourceRow.TransmissionNm;
            targetRow.ShiftNm = sourceRow.ShiftNm;
            targetRow.WheelDriveMethodNm = sourceRow.WheelDriveMethodNm;
            targetRow.AddiCarSpec1 = sourceRow.AddiCarSpec1;
            targetRow.AddiCarSpec2 = sourceRow.AddiCarSpec2;
            targetRow.AddiCarSpec3 = sourceRow.AddiCarSpec3;
            targetRow.AddiCarSpec4 = sourceRow.AddiCarSpec4;
            targetRow.AddiCarSpec5 = sourceRow.AddiCarSpec5;
            targetRow.AddiCarSpec6 = sourceRow.AddiCarSpec6;
            targetRow.AddiCarSpecTitle1 = sourceRow.AddiCarSpecTitle1;
            targetRow.AddiCarSpecTitle2 = sourceRow.AddiCarSpecTitle2;
            targetRow.AddiCarSpecTitle3 = sourceRow.AddiCarSpecTitle3;
            targetRow.AddiCarSpecTitle4 = sourceRow.AddiCarSpecTitle4;
            targetRow.AddiCarSpecTitle5 = sourceRow.AddiCarSpecTitle5;
            targetRow.AddiCarSpecTitle6 = sourceRow.AddiCarSpecTitle6;
            targetRow.RelevanceModel = sourceRow.RelevanceModel;
            targetRow.SubCarNmCd = sourceRow.SubCarNmCd;
            targetRow.ModelGradeSname = sourceRow.ModelGradeSname;
            targetRow.BlockIllustrationCd = sourceRow.BlockIllustrationCd;
            targetRow.ThreeDIllustNo = sourceRow.ThreeDIllustNo;
            targetRow.PartsDataOfferFlag = sourceRow.PartsDataOfferFlag;
            if (sourceRow[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName] != DBNull.Value
                && sourceRow.InspectMaturityDate != string.Empty)
            {
                targetRow.InspectMaturityDate = sourceRow.InspectMaturityDate;
            }
            if (sourceRow[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName] != DBNull.Value
                && sourceRow.LTimeCiMatDate != string.Empty)
            {
                targetRow.LTimeCiMatDate = sourceRow.LTimeCiMatDate;
            }
            targetRow.CarInspectYear = sourceRow.CarInspectYear;
            targetRow.Mileage = sourceRow.Mileage;
            targetRow.CarNo = sourceRow.CarNo;
            targetRow.ColorCode = sourceRow.ColorCode;
            targetRow.ColorName1 = sourceRow.ColorName1;
            targetRow.TrimCode = sourceRow.TrimCode;
            targetRow.TrimName = sourceRow.TrimName;
            targetRow.FullModelFixedNoAry = sourceRow.FullModelFixedNoAry;
            targetRow.CategoryObjAry = sourceRow.CategoryObjAry;
            targetRow.CarAddInfo1 = sourceRow.CarAddInfo1;
            targetRow.CarAddInfo2 = sourceRow.CarAddInfo2;
            targetRow.CarNote = sourceRow.CarNote;
            // ----ADD 2010/12/22 ------>>>>>
            if (null == sourceRow.FreeSrchMdlFxdNoAry || sourceRow.FreeSrchMdlFxdNoAry.Length == 0)
            {
                targetRow.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                targetRow.FreeSrchMdlFxdNoAry = sourceRow.FreeSrchMdlFxdNoAry;
            }
            // ----ADD 2010/12/22 ------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            targetRow.DomesticForeignCode = sourceRow.DomesticForeignCode;  // ���Y/�O�ԋ敪
            targetRow.HandleInfoCode = sourceRow.HandleInfoCode;  // �n���h���ʒu���
            // ADD 2013/03/22 --------------------<<<<<
        }

        /// <summary>
        /// ÷�ďo�͂̃f�[�^����
        /// </summary>
        /// <param name="table">�o�͂̃f�[�^</param>
        /// <remarks>
        /// <br>Note       : ÷�ďo�͂̃f�[�^�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void GetTextOutData(out DataTable table)
        {
            table = this.CreateColumn();
            DataTable table2 = new DataTable();

            // ���q�Ǘ��}�X�^.�_���폜�敪��0�̃f�[�^���o�͑ΏۂƂ���B
            string filer = this._carInfoDataTable.LogicalDeleteCodeColumn.ColumnName + " = 0";

            // ���q�Ǘ��}�X�^.�_���폜�敪��0�̃f�[�^���o�͑ΏۂƂ���B
            DataView dv = this._csvCarInfoDataTable.DefaultView;
            dv.RowFilter = filer;
            // �\�[�g����
            dv.Sort = "CustomerCode, CarMngCode, CarMngNo";

            table2 = dv.ToTable();

            foreach (DataRow row2 in table2.Rows)
            {
                DataRow row = table.NewRow();

                // ���Ӑ�R�[�h
                row["CustomerCode"] = this.StrPadLeft0(row2["CustomerCode"].ToString(), 8);
                row["CarMngCode"] = row2["CarMngCode"];                         // �Ǘ��ԍ�
                // �^���w��ԍ�  
                row["ModelDesignationNo"] = this.StrPadLeft0(row2["ModelDesignationNo"].ToString(), 5);
                // �ޕʔԍ�
                row["CategoryNo"] = this.StrPadLeft0(row2["CategoryNo"].ToString(), 4);
                row["EngineModelNm"] = row2["EngineModelNm"];                   // �G���W���^��
                // ���[�J�[�R�[�h
                row["MakerCode"] = this.StrPadLeft0(row2["MakerCode"].ToString(), 3);
                // �Ԏ�R�[�h
                row["ModelCode"] = this.StrPadLeft0(row2["ModelCode"].ToString(), 3);
                // �ď̃R�[�h         
                row["ModelSubCode"] = this.StrPadLeft0(row2["ModelSubCode"].ToString(), 3);
                row["ModelFullName"] = row2["ModelFullName"];                   // �Ԏ햼��
                row["FullModel"] = row2["FullModel"];                           // �^��
                // �N�x
                if (row2["FirstEntryDate"] != DBNull.Value && !string.Empty.Equals(row2["FirstEntryDate"].ToString()))  // UPD 2009/10/10
                {
                    // ---UPD 2009/10/10 ----->>>>>
                    try
                    {
                        DateTime time = DateTime.Parse(row2["FirstEntryDate"].ToString());
                        // --- UPD 2013/05/08 Y.Wakita ---------->>>>>
                        //row["FirstEntryDate"] = time.ToString("yyyyMM");
                        string firstEntryDateEStr = row2["FirstEntryDate"].ToString().Substring(row2["FirstEntryDate"].ToString().Length - 1, 1);
                        if (firstEntryDateEStr == "�N")
                            row["FirstEntryDate"] = time.ToString("yyyy");
                        else
                            row["FirstEntryDate"] = time.ToString("yyyyMM");
                        // --- UPD 2013/05/08 Y.Wakita ----------<<<<<
                    }
                    catch
                    {
                        row["FirstEntryDate"] = row2["FirstEntryDate"].ToString().Substring(0,4);
                    }
                    // ---UPD 2009/10/10 -----<<<<<
                }
                row["FrameNo"] = row2["FrameNo"];                               // �ԑ�ԍ�
                row["ColorCode"] = row2["ColorCode"];                           // �J���[�R�[�h
                row["ColorName1"] = row2["ColorName1"];                         // �J���[����1
                row["TrimCode"] = row2["TrimCode"];                             // �g�����R�[�h
                row["TrimName"] = row2["TrimName"];                             // �g��������
                row["EngineModel"] = row2["EngineModel"];                       // �����@�^��
                row["CarAddInfo1"] = row2["CarAddInfo1"];                       // �ǉ����P
                row["CarAddInfo2"] = row2["CarAddInfo2"];                       // �ǉ����Q
                // ���^�������ԍ�
                row["NumberPlate1Code"] = this.StrPadLeft0(row2["NumberPlate1Code"].ToString(), 4);
                row["NumberPlate1Name"] = row2["NumberPlate1Name"];             // ���^����������
                row["NumberPlate2"] = row2["NumberPlate2"];                     // �ԗ��o�^�ԍ��i��ʁj
                row["NumberPlate3"] = row2["NumberPlate3"];                     // �ԗ��o�^�ԍ��i�J�i�j
                row["NumberPlate4"] = row2["NumberPlate4"];                     // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                //row["Mileage"] = row2["Mileage"];
                row["Mileage"] = string.Format("{0:##,##0}",row2["Mileage"]);    // ���s���� // ADD 2009/10/10
                

                
                // �o�^�N����
                if (row2["EntryDate"] != DBNull.Value)
                {
                    DateTime time = DateTime.Parse(row2["EntryDate"].ToString());
                    row["EntryDate"] = time.ToString("yyyyMMdd");
                }

                // �O��Ԍ���
                if (row2["LTimeCiMatDate"] != DBNull.Value)
                {
                    DateTime time = DateTime.Parse(row2["LTimeCiMatDate"].ToString());
                    row["LTimeCiMatDate"] = time.ToString("yyyyMMdd");
                }

                // ����Ԍ���
                if (row2["InspectMaturityDate"] != DBNull.Value)
                {
                    DateTime time = DateTime.Parse(row2["InspectMaturityDate"].ToString());
                    row["InspectMaturityDate"] = time.ToString("yyyyMMdd");
                }
                // �Ԍ�����
                row["CarInspectYear"] = this.StrPadLeft0(row2["CarInspectYear"].ToString(), 2);
                row["CarNote"] = row2["CarNote"];                               // ���l
                row["CarMngDivName"] = row2["CarMngDivName"];                   // ���q�Ǘ��敪

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// �O���b�h��쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h����쐬���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public DataTable CreateColumn()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CustomerCode", typeof(string));
            dataTable.Columns.Add("CarMngCode", typeof(string));
            dataTable.Columns.Add("ModelDesignationNo", typeof(string));
            dataTable.Columns.Add("CategoryNo", typeof(string));
            dataTable.Columns.Add("EngineModelNm", typeof(string));
            dataTable.Columns.Add("MakerCode", typeof(string));
            dataTable.Columns.Add("ModelCode", typeof(string));
            dataTable.Columns.Add("ModelSubCode", typeof(string));
            dataTable.Columns.Add("ModelFullName", typeof(string));
            dataTable.Columns.Add("FullModel", typeof(string));
            dataTable.Columns.Add("FirstEntryDate", typeof(string));
            dataTable.Columns.Add("FrameNo", typeof(string));
            dataTable.Columns.Add("ColorCode", typeof(string));
            dataTable.Columns.Add("ColorName1", typeof(string));
            dataTable.Columns.Add("TrimCode", typeof(string));
            dataTable.Columns.Add("TrimName", typeof(string));
            dataTable.Columns.Add("EngineModel", typeof(string));
            dataTable.Columns.Add("CarAddInfo1", typeof(string));
            dataTable.Columns.Add("CarAddInfo2", typeof(string));
            dataTable.Columns.Add("NumberPlate1Code", typeof(string));
            dataTable.Columns.Add("NumberPlate1Name", typeof(string));
            dataTable.Columns.Add("NumberPlate2", typeof(string));
            dataTable.Columns.Add("NumberPlate3", typeof(string));
            dataTable.Columns.Add("NumberPlate4", typeof(string));
            dataTable.Columns.Add("Mileage", typeof(string));
            dataTable.Columns.Add("EntryDate", typeof(string));
            dataTable.Columns.Add("LTimeCiMatDate", typeof(string));
            dataTable.Columns.Add("InspectMaturityDate", typeof(string));
            dataTable.Columns.Add("CarInspectYear", typeof(string));
            dataTable.Columns.Add("CarNote", typeof(string));
            dataTable.Columns.Add("CarMngDivName", typeof(string));

            return dataTable;
        }

        /// <summary>
        /// ���Ӑ�R�[�h���A���Ӑ�}�X�^�̃f�[�^�̎捞
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerInfo">����</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̃f�[�^�̎捞���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int GetCustomerInfo(int customerCode, string enterpriseCode, out CustomerInfo customerInfo)
        {
            int status = 0;
            status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, false, out customerInfo);
            return status;
        }
        #endregion

        #region �� �Z���l�ϊ�
        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/10</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
                {
                    return 0;
                }

                return int.Parse((string)cellValue);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/10</br>
        /// </remarks>
        public string IntObjToStr(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || ((int)cellValue == 0))
                {
                    return string.Empty;
                }

                return cellValue.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// string�Z���l�ϊ�����(�t�H���g)
        /// </summary>
        /// <param name="s">string�l</param>
        /// <param name="number">number</param>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/10</br>
        /// </remarks>
        public string StrPadLeft0(string s, int number)
        {
            if (s == string.Empty || s == "0")
            {
                return string.Empty;
            }

            return s.Trim().PadLeft(number, '0');
        }
        #endregion
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��private���\�b�h
        /// <summary>
        /// ���Ӑ挟���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ挟���}�X�^�Ǎ��������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void LoadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retList;

                int status = this._customerSearchAcs.Serch(out retList, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retList)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// ���^�������ԍ��Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���^�������ԍ��ꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void LoadNumberPlate1Code()
        {
            this._numberPlate1CodeDic = new Dictionary<int, UserGdBd>();

            ArrayList retList = new ArrayList();

            try
            {
                // ���[�U�[�K�C�h�f�[�^�擾(���^�������ԍ�)
                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                 80, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._numberPlate1CodeDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            catch
            {
                this._numberPlate1CodeDic = new Dictionary<int, UserGdBd>();
            }

            return;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���q�Ǘ��}�X�^Row�ˎ��q�Ǘ��}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="extractInfo">���q�Ǘ��}�X�^Row</param>
        /// <returns>���q�Ǘ��}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^Row������q�Ǘ��}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.09.07</br>
        /// </remarks>
        private CarManagementWork CopyToCarManagementWorkFromExtractInfo(CarManagementExtractInfo extractInfo)
        {
            CarManagementWork work = new CarManagementWork();

            work.CustomerCode = extractInfo.CustomerCode;
            work.CustomerCodeSt = extractInfo.CustomerCodeSt;
            work.CustomerCodeEd = extractInfo.CustomerCodeEd;
            work.CarMngCode = extractInfo.CarMngCode;
            work.CarMngCodeSearchDiv = extractInfo.SearchDiv;

            return work;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���q�Ǘ��}�X�^���[�N�N���X�ˎ��q�Ǘ��}�X�^Row�j
        /// </summary>
        /// <param name="carManagementWork">���q�Ǘ��}�X�^���[�N�N���X</param>
        /// <returns>���q�Ǘ��}�X�^Row</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^���[�N�N���X������q�Ǘ��}�X�^Row�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.09.07</br>
        /// <br>update Note  : PM1015B�@���q�Ǘ��}�X�^�̎��R�����^���Œ�ԍ��z����R�s�[����悤�ɏC��</br>
        /// <br>             �{�w�C��</br>
        /// <br>Date       �@: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private CarMngInputDataSet.CarInfoRow CopyToRowFromCarManagementWork(CarManagementWork carManagementWork)
        {
            CarMngInputDataSet.CarInfoRow row = this._carInfoDataTable.NewCarInfoRow();

            row.CarRelationGuid = Guid.NewGuid();

            row.UpdateDateTime = carManagementWork.UpdateDateTime;
            row.CreateDateTime = carManagementWork.CreateDateTime;
            row.FileHeaderGuid = carManagementWork.FileHeaderGuid;
            row.LogicalDeleteCode = carManagementWork.LogicalDeleteCode;

            // �_���폜
            if (carManagementWork.LogicalDeleteCode == 1)
            {
                row.DeleteDate = carManagementWork.UpdateDateTime;
            }
            row.DeleteFlag = DELETE_FLAG0;

            row.SaveCanFlag = SAVECAN_FLAG0;  // 2009/10/26 ADD

            row.RowStatus = ROWSTATUS_NORMAL;

            row.CustomerCode = this.StrPadLeft0(IntObjToStr(carManagementWork.CustomerCode), 8);
            row.CarMngNo = carManagementWork.CarMngNo.ToString();
            row.CarMngCode = carManagementWork.CarMngCode;
            if (carManagementWork.NumberPlate1Code == 0)
            {
                row.NumberPlate1Code = string.Empty;
            }
            else
            {
                row.NumberPlate1Code = this.StrPadLeft0(IntObjToStr(carManagementWork.NumberPlate1Code), 4);
            }
            // ----ADD 2009/10/10 ------>>>>>
            if (carManagementWork.NumberPlate1Name.Length > 4)
            {
                row.NumberPlate1Name = carManagementWork.NumberPlate1Name.Substring(0,4);
            }
            else
            {
                row.NumberPlate1Name = carManagementWork.NumberPlate1Name;
            }
            // ----ADD 2009/10/10 ------<<<<<
            row.NumberPlate2 = carManagementWork.NumberPlate2;
            row.NumberPlate3 = carManagementWork.NumberPlate3;
            row.NumberPlate4 = IntObjToStr(carManagementWork.NumberPlate4);
            if (carManagementWork.EntryDate != DateTime.MinValue)
            {
                row.EntryDate = carManagementWork.EntryDate.ToString();
            }

            // --- DEL 2013/05/08 Y.Wakita ---------->>>>>
            //// ----ADD 2009/10/10 ----->>>>>
            ////// �N��
            ////if (carManagementWork.FirstEntryDate != 0)
            ////{
            ////    row.FirstEntryDate = DateTime.ParseExact(carManagementWork.FirstEntryDate.ToString(), "yyyyMM", null);
            ////}

            //DateTime tempFirstEntryDate = DateTime.MinValue;
            //try
            //{
            //    if (carManagementWork.FirstEntryDate != 0)
            //    {
            //        tempFirstEntryDate = DateTime.ParseExact(carManagementWork.FirstEntryDate.ToString(), "yyyyMM", null); // ���N�x
            //    }
            //}
            //catch
            //{
            //    tempFirstEntryDate = DateTime.MinValue;
            //}

            //// �N��
            //if (carManagementWork.FirstEntryDate != 0 )
            //{
            //    if (tempFirstEntryDate != DateTime.MinValue)
            //    {
            //        row.FirstEntryDate = tempFirstEntryDate.ToString("yyyy�NMM��");
            //    }
            //    else
            //    {
            //        row.FirstEntryDate = carManagementWork.FirstEntryDate.ToString().Substring(0, 4) + "�N";
            //    }
                
            //}
            //else
            //{
            //    row.FirstEntryDate = string.Empty;
            //}
            //// ----ADD 2009/10/10 -----<<<<<
            // --- DEL 2013/05/08 Y.Wakita ----------<<<<<

            // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
            // �N��[NULL�̂Ƃ��͋�]
            if (carManagementWork.FirstEntryDate == 0)
            {
                row.FirstEntryDate = string.Empty;
            }
            else
            {
                string firstEntryDate = "";

                if (carManagementWork.FirstEntryDate.ToString().Length < 6)
                {
                    firstEntryDate = "0000" + "/" + carManagementWork.FirstEntryDate.ToString("D2");
                }
                else
                {
                    firstEntryDate = carManagementWork.FirstEntryDate.ToString().Substring(0, 4) + "/" +
                                     carManagementWork.FirstEntryDate.ToString().Substring(4, 2);
                }

                firstEntryDate = firstEntryDate.Replace(@"/00", "");

                if (this.carMngInputAcs.GetAllDefSet().EraNameDispCd1 == 1)
                {
                    string date, stTarget;
                    int StartTotalUnitYm;

                    if (carManagementWork.FirstEntryDate.ToString().Substring(4, 2) == "00")
                    {
                        date = carManagementWork.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                        StartTotalUnitYm = Convert.ToInt32(date);
                        stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);
                    }
                    else
                    {
                        date = carManagementWork.FirstEntryDate.ToString() + "01";
                        StartTotalUnitYm = Convert.ToInt32(date);
                        stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                    }

                    row.FirstEntryDate = stTarget;
                }
                else
                {
                    row.FirstEntryDate = firstEntryDate;
                }
            }
            // --- ADD 2013/05/08 Y.Wakita ----------<<<<<

            row.MakerCode = carManagementWork.MakerCode;
            row.MakerFullName = carManagementWork.MakerFullName;
            row.MakerHalfName = carManagementWork.MakerHalfName;
            row.ModelCode = carManagementWork.ModelCode.ToString();
            row.ModelSubCode = carManagementWork.ModelSubCode.ToString();
            row.ModelFullName = carManagementWork.ModelFullName;
            row.ModelHalfName = carManagementWork.ModelHalfName;
            row.SystematicCode = carManagementWork.SystematicCode;
            row.SystematicName = carManagementWork.SystematicName;
            row.ProduceTypeOfYearCd = carManagementWork.ProduceTypeOfYearCd;
            row.ProduceTypeOfYearNm = carManagementWork.ProduceTypeOfYearNm;
            row.StProduceTypeOfYear = carManagementWork.StProduceTypeOfYear;
            row.EdProduceTypeOfYear = carManagementWork.EdProduceTypeOfYear;
            row.DoorCount = carManagementWork.DoorCount;
            row.BodyNameCode = carManagementWork.BodyNameCode;
            row.BodyName = carManagementWork.BodyName;
            row.ExhaustGasSign = carManagementWork.ExhaustGasSign;
            row.SeriesModel = carManagementWork.SeriesModel;
            row.CategorySignModel = carManagementWork.CategorySignModel;
            row.FullModel = carManagementWork.FullModel;
            row.ModelDesignationNo = this.StrPadLeft0(IntObjToStr(carManagementWork.ModelDesignationNo), 5);
            row.CategoryNo = this.StrPadLeft0(IntObjToStr(carManagementWork.CategoryNo), 4);
            row.FrameModel = carManagementWork.FrameModel;
            row.FrameNo = carManagementWork.FrameNo;
            row.SearchFrameNo = carManagementWork.SearchFrameNo;
            row.StProduceFrameNo = carManagementWork.StProduceFrameNo;
            row.EdProduceFrameNo = carManagementWork.EdProduceFrameNo;
            row.EngineModel = carManagementWork.EngineModel;
            row.ModelGradeNm = carManagementWork.ModelGradeNm;
            row.EngineModelNm = carManagementWork.EngineModelNm;
            row.EngineDisplaceNm = carManagementWork.EngineDisplaceNm;
            row.EDivNm = carManagementWork.EDivNm;
            row.TransmissionNm = carManagementWork.TransmissionNm;
            row.ShiftNm = carManagementWork.ShiftNm;
            row.WheelDriveMethodNm = carManagementWork.WheelDriveMethodNm;
            row.AddiCarSpec1 = carManagementWork.AddiCarSpec1;
            row.AddiCarSpec2 = carManagementWork.AddiCarSpec2;
            row.AddiCarSpec3 = carManagementWork.AddiCarSpec3;
            row.AddiCarSpec4 = carManagementWork.AddiCarSpec4;
            row.AddiCarSpec5 = carManagementWork.AddiCarSpec5;
            row.AddiCarSpec6 = carManagementWork.AddiCarSpec6;
            row.AddiCarSpecTitle1 = carManagementWork.AddiCarSpecTitle1;
            row.AddiCarSpecTitle2 = carManagementWork.AddiCarSpecTitle2;
            row.AddiCarSpecTitle3 = carManagementWork.AddiCarSpecTitle3;
            row.AddiCarSpecTitle4 = carManagementWork.AddiCarSpecTitle4;
            row.AddiCarSpecTitle5 = carManagementWork.AddiCarSpecTitle5;
            row.AddiCarSpecTitle6 = carManagementWork.AddiCarSpecTitle6;
            row.RelevanceModel = carManagementWork.RelevanceModel;
            row.SubCarNmCd = carManagementWork.SubCarNmCd;
            row.ModelGradeSname = carManagementWork.ModelGradeSname;
            row.BlockIllustrationCd = carManagementWork.BlockIllustrationCd;
            row.ThreeDIllustNo = carManagementWork.ThreeDIllustNo;
            row.PartsDataOfferFlag = carManagementWork.PartsDataOfferFlag;
            if (carManagementWork.InspectMaturityDate != DateTime.MinValue)
            {
                row.InspectMaturityDate = carManagementWork.InspectMaturityDate.ToString();
            }
            if (carManagementWork.LTimeCiMatDate != DateTime.MinValue)
            {
                row.LTimeCiMatDate = carManagementWork.LTimeCiMatDate.ToString();
            }
            row.CarInspectYear = carManagementWork.CarInspectYear;
            row.Mileage = carManagementWork.Mileage;
            row.CarNo = carManagementWork.CarNo;
            row.ColorCode = carManagementWork.ColorCode;
            row.ColorName1 = carManagementWork.ColorName1;
            row.TrimCode = carManagementWork.TrimCode;
            row.TrimName = carManagementWork.TrimName;
            row.FullModelFixedNoAry = carManagementWork.FullModelFixedNoAry;
            // ----ADD 2010/12/22 ------>>>>>
            if (null == carManagementWork.FreeSrchMdlFxdNoAry || carManagementWork.FreeSrchMdlFxdNoAry.Length == 0)
            {
                row.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                byte[] bfrom = carManagementWork.FreeSrchMdlFxdNoAry;
                string[] freeAry = new string[bfrom.Length];
                for (int i = 0; i < bfrom.Length; i++)
                {
                    freeAry[i] = bfrom[i].ToString();  
                }
                row.FreeSrchMdlFxdNoAry = freeAry;
            }
            // ----ADD 2010/12/22 ------<<<<<
            //row.CategoryObjAry = Encoding.Default.GetString(carManagementWork.CategoryObjAry);
            row.CategoryObjAry = carManagementWork.CategoryObjAry;
            row.CarAddInfo1 = carManagementWork.CarAddInfo1;
            row.CarAddInfo2 = carManagementWork.CarAddInfo2;
            row.CarNote = carManagementWork.CarNote;

            // ADD 2013/03/22 -------------------->>>>>		           
            row.DomesticForeignCode = carManagementWork.DomesticForeignCode; // ���Y/�O�ԋ敪
            row.HandleInfoCode = carManagementWork.HandleInfoCode;  // �n���h���ʒu���
            // ADD 2013/03/22 --------------------<<<<<

            // --- UPD 2009/10/26 ----->>>>>
            //CustomerInfo customerInfo;
            //this.GetCustomerInfo(carManagementWork.CustomerCode, this._enterpriseCode, out customerInfo);
            //if (customerInfo != null)
            //{
            //    if (customerInfo.CarMngDivCd == 0)
            //    {
            //        row.CarMngDivName = "���Ȃ�";
            //    }
            //    else if (customerInfo.CarMngDivCd == 1 || customerInfo.CarMngDivCd == 2)
            //    {
            //        row.CarMngDivName = "�o�^�L";
            //    }
            //    else if (customerInfo.CarMngDivCd == 3)
            //    {
            //        row.CarMngDivName = "�o�^��";
            //    }
            //    else
            //    {
            //        row.CarMngDivName = "���Ȃ�";
            //    }
            //}
            //else
            //{
            //    row.CarMngDivName = "���Ȃ�";
            //}
            int carMngDivCd = 0;
            if (!carMngDivHt.Contains(carManagementWork.CustomerCode))
            {
                // ���q�Ǘ��敪
                CustomerInfo customerInfo;
                this.GetCustomerInfo(carManagementWork.CustomerCode, this._enterpriseCode, out customerInfo);
                if (customerInfo != null)
                {
                    carMngDivCd = customerInfo.CarMngDivCd;
                    carMngDivHt.Add(carManagementWork.CustomerCode, carMngDivCd);
                }
            }
            else
            {
                carMngDivCd =(int) carMngDivHt[carManagementWork.CustomerCode];
            }

            if (carMngDivCd == 0)
            {
                row.CarMngDivName = "���Ȃ�";
            }
            else if (carMngDivCd == 1 || carMngDivCd == 2)
            {
                row.CarMngDivName = "�o�^�L";
            }
            else if (carMngDivCd == 3)
            {
                row.CarMngDivName = "�o�^��";
            }
            else
            {
                row.CarMngDivName = "���Ȃ�";
            }
            // --- UPD 2009/10/26 -----<<<<<

            // ADD 2013/03/22 -------------------->>>>>	           
            row.DomesticForeignCode = carManagementWork.DomesticForeignCode;    // ���Y/�O�ԋ敪
            row.HandleInfoCode = carManagementWork.HandleInfoCode;  // �n���h���ʒu���
            // ADD 2013/03/22 --------------------<<<<<
            return row;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���q�Ǘ��}�X�^Row�ˎ��q�Ǘ��}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="row">���q�Ǘ��}�X�^Row</param>
        /// <returns>���q�Ǘ��}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^Row������q�Ǘ��}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.09.07</br>
        /// <br>update Note  : PM1015B�@���q�Ǘ��}�X�^�̎��R�����^���Œ�ԍ��z����R�s�[����悤�ɏC��</br>
        /// <br>             �@�{�w�C��</br>
        /// <br>Date       �@: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private CarManagementWork CopyToCarManagementWorkFromRow(CarMngInputDataSet.CarInfoRow row)
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.LogicalDeleteCode = row.LogicalDeleteCode;
            carManagementWork.CreateDateTime = row.CreateDateTime;
            carManagementWork.UpdateDateTime = row.UpdateDateTime;
            carManagementWork.FileHeaderGuid = row.FileHeaderGuid;

            carManagementWork.LogicalDeleteCode = row.LogicalDeleteCode;
            carManagementWork.EnterpriseCode = this._enterpriseCode;
            carManagementWork.CustomerCode = StrObjToInt(row.CustomerCode);
            carManagementWork.CarMngNo = StrObjToInt(row.CarMngNo);
            carManagementWork.CarMngCode = row.CarMngCode;
            carManagementWork.NumberPlate1Code = StrObjToInt(row.NumberPlate1Code);
            // ---- ADD 2009/10/10 ------>>>>> 
            if (row.NumberPlate1Name.Length > 4)
            {
                carManagementWork.NumberPlate1Name = row.NumberPlate1Name.Substring(0,4);
            }
            else
            {
                carManagementWork.NumberPlate1Name = row.NumberPlate1Name;
            }
            // ---- ADD 2009/10/10 ------<<<<<
            carManagementWork.NumberPlate2 = row.NumberPlate2;
            carManagementWork.NumberPlate3 = row.NumberPlate3;
            carManagementWork.NumberPlate4 = StrObjToInt(row.NumberPlate4);

            if (!string.Empty.Equals(row[this._carInfoDataTable.EntryDateColumn.ColumnName])
                && !row[this._carInfoDataTable.EntryDateColumn.ColumnName].ToString().Equals("�@")
                &&row[this._carInfoDataTable.EntryDateColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.EntryDate = Convert.ToDateTime(row.EntryDate);
            }
            if (row[this._carInfoDataTable.FirstEntryDateColumn.ColumnName] != DBNull.Value
                && !row[this._carInfoDataTable.FirstEntryDateColumn.ColumnName].ToString().Equals("�@")
                && !string.Empty.Equals(row[this._carInfoDataTable.FirstEntryDateColumn.ColumnName]))
            {
                // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
                double d;
                if (!(Double.TryParse(row.FirstEntryDate.Substring(0, 1), out d)))
                {
                    int firstEntryDt_i;
                    string firstEntryDt_s = row.FirstEntryDate.Replace(" ", "");
                    int firstEntryDtLength = firstEntryDt_s.Length;

                    if (firstEntryDt_s.Substring(firstEntryDtLength - 1, 1) == "��")
                    {
                        firstEntryDt_s = firstEntryDt_s + "1��";
                        firstEntryDtLength = 6;
                    }
                    else
                    {
                        firstEntryDt_s = firstEntryDt_s + "1��1��";
                        firstEntryDtLength = 4;
                    }
                    firstEntryDt_i = TDateTime.JapaneseDateStringToLongDate(firstEntryDt_s);
                    if (firstEntryDtLength == 6)
                    {
                        firstEntryDt_s = firstEntryDt_i.ToString().Substring(0, firstEntryDtLength);
                        firstEntryDt_s = firstEntryDt_s.Substring(0, 4) + "/" + firstEntryDt_s.Substring(4, 2);
                    }
                    else
                    {
                        firstEntryDt_s = firstEntryDt_i.ToString().Substring(0, firstEntryDtLength);
                    }
                    row.FirstEntryDate = firstEntryDt_s;
                }
                // --- ADD 2013/05/08 Y.Wakita ----------<<<<<

                // ---UPD 2009/10/16 ----->>>>>
                // carManagementWork.FirstEntryDate = StrObjToInt(row.FirstEntryDate.ToString("yyyyMM"));
                string mon = "00";
                if (row.FirstEntryDate.Length > 5
                    && !row.FirstEntryDate.Substring(5, 1).Equals(" "))
                {
                    mon = row.FirstEntryDate.Substring(5, 2);
                }
                string firstEntryDt = row.FirstEntryDate.Substring(0, 4) + mon;
                carManagementWork.FirstEntryDate = StrObjToInt(firstEntryDt);
                // ---UPD 2009/10/16 -----<<<<<
            }

            carManagementWork.MakerCode = row.MakerCode;
            carManagementWork.MakerFullName = row.MakerFullName;
            carManagementWork.MakerHalfName = row.MakerHalfName;
            carManagementWork.ModelCode = StrObjToInt(row.ModelCode);
            carManagementWork.ModelSubCode = StrObjToInt(row.ModelSubCode);
            carManagementWork.ModelFullName = row.ModelFullName;
            carManagementWork.ModelHalfName = row.ModelHalfName;
            carManagementWork.SystematicCode = row.SystematicCode;
            carManagementWork.SystematicName = row.SystematicName;
            carManagementWork.ProduceTypeOfYearCd = row.ProduceTypeOfYearCd;
            carManagementWork.ProduceTypeOfYearNm = row.ProduceTypeOfYearNm;
            carManagementWork.StProduceTypeOfYear = row.StProduceTypeOfYear;
            carManagementWork.EdProduceTypeOfYear = row.EdProduceTypeOfYear;
            carManagementWork.DoorCount = row.DoorCount;
            carManagementWork.BodyNameCode = row.BodyNameCode;
            carManagementWork.BodyName = row.BodyName;
            carManagementWork.ExhaustGasSign = row.ExhaustGasSign;
            carManagementWork.SeriesModel = row.SeriesModel;
            carManagementWork.CategorySignModel = row.CategorySignModel;
            carManagementWork.FullModel = row.FullModel;
            carManagementWork.ModelDesignationNo = StrObjToInt(row.ModelDesignationNo);
            carManagementWork.CategoryNo = StrObjToInt(row.CategoryNo);
            carManagementWork.FrameModel = row.FrameModel;
            carManagementWork.FrameNo = row.FrameNo;
            carManagementWork.SearchFrameNo = row.SearchFrameNo;
            carManagementWork.StProduceFrameNo = row.StProduceFrameNo;
            carManagementWork.EdProduceFrameNo = row.EdProduceFrameNo;
            carManagementWork.EngineModel = row.EngineModel;
            carManagementWork.ModelGradeNm = row.ModelGradeNm;
            carManagementWork.EngineModelNm = row.EngineModelNm;
            carManagementWork.EngineDisplaceNm = row.EngineDisplaceNm;
            carManagementWork.EDivNm = row.EDivNm;
            carManagementWork.TransmissionNm = row.TransmissionNm;
            carManagementWork.ShiftNm = row.ShiftNm;
            carManagementWork.WheelDriveMethodNm = row.WheelDriveMethodNm;
            carManagementWork.AddiCarSpec1 = row.AddiCarSpec1;
            carManagementWork.AddiCarSpec2 = row.AddiCarSpec2;
            carManagementWork.AddiCarSpec3 = row.AddiCarSpec3;
            carManagementWork.AddiCarSpec4 = row.AddiCarSpec4;
            carManagementWork.AddiCarSpec5 = row.AddiCarSpec5;
            carManagementWork.AddiCarSpec6 = row.AddiCarSpec6;
            carManagementWork.AddiCarSpecTitle1 = row.AddiCarSpecTitle1;
            carManagementWork.AddiCarSpecTitle2 = row.AddiCarSpecTitle2;
            carManagementWork.AddiCarSpecTitle3 = row.AddiCarSpecTitle3;
            carManagementWork.AddiCarSpecTitle4 = row.AddiCarSpecTitle4;
            carManagementWork.AddiCarSpecTitle5 = row.AddiCarSpecTitle5;
            carManagementWork.AddiCarSpecTitle6 = row.AddiCarSpecTitle6;
            carManagementWork.RelevanceModel = row.RelevanceModel;
            carManagementWork.SubCarNmCd = row.SubCarNmCd;
            carManagementWork.ModelGradeSname = row.ModelGradeSname;
            carManagementWork.BlockIllustrationCd = row.BlockIllustrationCd;
            carManagementWork.ThreeDIllustNo = row.ThreeDIllustNo;
            carManagementWork.PartsDataOfferFlag = row.PartsDataOfferFlag;
            // ----ADD 2010/12/22 ------>>>>>
            if (null == row.FreeSrchMdlFxdNoAry || row.FreeSrchMdlFxdNoAry.Length == 0)
            {
                carManagementWork.FreeSrchMdlFxdNoAry =  new byte[0] ;
            }
            else
            {
                string[] bfrom = row.FreeSrchMdlFxdNoAry;
                byte[] freeAry = new byte[bfrom.Length];
                for (int i = 0; i < bfrom.Length; i++)
                {
                    freeAry[i] = Convert.ToByte(bfrom[i]);
                }
                carManagementWork.FreeSrchMdlFxdNoAry = freeAry;
            }
            // ----ADD 2010/12/22 ------<<<<<
            if (!string.Empty.Equals(row[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName])
                &&!row[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName].ToString().Equals("�@")
                &&row[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.InspectMaturityDate = Convert.ToDateTime(row.InspectMaturityDate);
            }
            if (!string.Empty.Equals(row[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName])
                && !row[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName].ToString().Equals("�@")
                &&row[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.LTimeCiMatDate = Convert.ToDateTime(row.LTimeCiMatDate);
            }

            if (!string.Empty.Equals(row[this._carInfoDataTable.CarInspectYearColumn.ColumnName])
                && !row[this._carInfoDataTable.CarInspectYearColumn.ColumnName].ToString().Equals("�@")
                &&row[this._carInfoDataTable.CarInspectYearColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.CarInspectYear = row.CarInspectYear;
            }

            if (row[this._carInfoDataTable.MileageColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.Mileage = row.Mileage;
            }
            carManagementWork.CarNo = row.CarNo;
            carManagementWork.ColorCode = row.ColorCode;
            carManagementWork.ColorName1 = row.ColorName1;
            carManagementWork.TrimCode = row.TrimCode;
            carManagementWork.TrimName = row.TrimName;
            carManagementWork.FullModelFixedNoAry = row.FullModelFixedNoAry;
            //carManagementWork.CategoryObjAry = Encoding.Default.GetBytes(row.CategoryObjAry);
            carManagementWork.CategoryObjAry = row.CategoryObjAry;
            carManagementWork.CarAddInfo1 = row.CarAddInfo1;
            carManagementWork.CarAddInfo2 = row.CarAddInfo2;
            if (row[this._carInfoDataTable.CarNoteColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.CarNote = row.CarNote;
            }
            else
            {
                carManagementWork.CarNote = string.Empty;
            }
            // ADD 2013/03/22 -------------------->>>>>	           
            carManagementWork.DomesticForeignCode = row.DomesticForeignCode;    // ���Y/�O�ԋ敪
            carManagementWork.HandleInfoCode = row.HandleInfoCode;  // �n���h���ʒu���
            // ADD 2013/03/22 --------------------<<<<<

            return carManagementWork;
        }
        # endregion
    }
}