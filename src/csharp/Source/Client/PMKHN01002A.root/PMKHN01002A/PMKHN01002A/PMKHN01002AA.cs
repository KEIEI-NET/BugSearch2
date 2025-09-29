//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^�N���A����
// �v���O�����T�v   : �f�[�^�N���A�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �f�[�^�N���A�����X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �f�[�^�N���A�����ł��B<br />
    /// Programmer : ���w�q<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public class DataClearAcs
    {
        #region �� Constructor ��

        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMKHN01000UA";
        private const string PROGRAM_NAME = "�f�[�^�N���A����";
        #endregion �� Const Memebers ��

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DataClearAcs()
        {
            // �ϐ�������
            this._dataSet = new DataClearDataSet();
            this._dataClearDataTable = this._dataSet.DataClear;
            this._iDataClearDB = MediationDataClearDB.GetDataClearDB();
			this._iDCControlDB = MediationDCControlDB.GetDCControlDB(); // ADD 2011.08.26
			this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();// ADD 2011.08.26
        }
        #endregion �� Constructor ��

        #region �� Properties ��
        /// <summary>
        /// �f�[�^�N���A�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public DataClearDataSet.DataClearDataTable DataClearDataTable
        {
            get { return _dataClearDataTable; }
        }
        #endregion �� Properties ��

        #region �� Private Members ��
        // �f�[�^�N���A�f�[�^�Z�b�g
        private DataClearDataSet _dataSet;
        // �f�[�^�N���A�f�[�^�e�[�u��
        private DataClearDataSet.DataClearDataTable _dataClearDataTable;
        // ���t�`�F�b�N�p�̃A�N�Z�X
        private static DataClearAcs _dataClearInsts;
        // �����[�g�p�̃N���X
        private IDataClearDB _iDataClearDB;
		private IDCControlDB _iDCControlDB; // ADD 2011.08.26
		private IMstDCControlDB _iMstDCControlDB; // ADD 2011.08.26
        #endregion �� Private Members ��

        #region �� �f�[�^�N���A�����A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// �f�[�^�N���A�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�f�[�^�N���A�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static DataClearAcs GetInstance()
        {
            if (_dataClearInsts == null)
            {
                _dataClearInsts = new DataClearAcs();
            }

            return _dataClearInsts;
        }
        #endregion �� �f�[�^�N���A�����A�N�Z�X�N���X �C���X�^���X�擾���� ��

        #region �I���E��I����ԏ���(�w��^)
        /// <summary>
        /// �I���E��I����ԏ���(�w��^)
        /// </summary>
        /// <param name="_uniqueID">���j�[�NID</param>
        /// <param name="selected">true:�I��,false:��I��</param>
        /// <remarks>
        /// <br>Note       : �I���E��I����ԏ������s���܂��B</br>
        /// <br>Programmer : 2009</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        public void SelectCheckbox(string _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = this._dataClearDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this._dataClearDataTable.IsCheckedColumn.ColumnName] = selected;
                _row.EndEdit();
            }
        }
        # endregion

        #region �����Ώۂ̑I���`�F�b�N����
        /// <summary>
        /// �����Ώۂ̑I���`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �����Ώۂ̑I���`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public bool IsGridDetailSelected()
        {
            bool isSelected = true;
            int count = 0;

            foreach (DataRow row in this._dataClearDataTable.Rows)
            {
                DataClearDataSet.DataClearRow dataRow = (DataClearDataSet.DataClearRow)row;
                dataRow.ClearResult = string.Empty;
            }

            try
            {
                DataView orderDataView = new DataView(this._dataClearDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this._dataClearDataTable.IsCheckedColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }

            if (count == this._dataClearDataTable.Rows.Count)
            {
                isSelected = false;
            }

            return isSelected;
        }
        #endregion �����Ώۂ̑I���`�F�b�N����

        #region �f�[�^�N���A����
        /// <summary>
        /// �f�[�^�N���A����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�N���A�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>�f�[�^�N���A������������</returns>
        //public int DataClear(string enterpriseCode, Int32 delYM, Int32 delYMD, out string errMsg)//DEL by Liangsd     2011/09/06
        public int DataClear(string sectionCode, string enterpriseCode, Int32 delYM, Int32 delYMD, out string errMsg)//ADD by Liangsd    2011/09/06
        {
            ArrayList dataList = new ArrayList();
            errMsg = string.Empty;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ADD 2011.08.26 ���� ---------->>>>>
			bool dcDataClearFlg = false;
			bool dcMustClearFlg = false;
		    int status1 = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
		    int status2 = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ADD 2011.08.26 ���� ----------<<<<<
            try
            {
                foreach (DataRow row in this._dataClearDataTable.Rows)
                {
                    DataClearDataSet.DataClearRow dataRow = (DataClearDataSet.DataClearRow)row;

                    if (dataRow.IsChecked)
                    {
                        // �����[�g�p�̃��[�N���X�g�쐬
						//dataList.Add(CopyDataClearWork(dataRow)); // DEL 2011.08.26 ����
						// ADD 2011.08.26 ���� ---------->>>>>
						if (dataRow.TableId.Equals("DCDATAINFO"))
						{
							dcDataClearFlg = true;
						}
                        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                        //else if (dataRow.TableId.Equals("DCMUSTINFO"))
                        //{
                        //    dcMustClearFlg = true;
                        //}
                        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
						else
						{
							dataList.Add(CopyDataClearWork(dataRow));
						}
						// ADD 2011.08.26 ���� ----------<<<<<
                    }
                }
                Object objDataClearList = dataList as object;

                // �f�[�^�N���A����
                status = this._iDataClearDB.Clear(enterpriseCode, delYM, delYMD, ref objDataClearList, out errMsg);

                foreach (DataClearWork work in objDataClearList as ArrayList)
                {
                    DataRow _row = this._dataClearDataTable.Rows.Find(work.TableId);

                    // ��v����s�����݂���I
                    if (_row != null)
                    {
                        string message = work.TableNm + " �N���A���� ";
                        OperationHistoryLog log = new OperationHistoryLog();
                        _row.BeginEdit();
                        if (work.Result.Equals("OK"))
                        {
                            message += "����I��";
                            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "����I��";
                        }
                        else
                        {
                            message += "�G���[";
                            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "�������ɃG���[���������܂����B";
                        }
                        log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, message, string.Empty);
                        _row.EndEdit();
                    }
                }

				// ADD 2011.08.26 ���� ---------->>>>>
				// ���_�Ǘ�����M�f�[�^�iDC�jclear
				if(dcDataClearFlg)
				{
                    status1 = this._iDCControlDB.DCDataClear(sectionCode,LoginInfoAcquisition.EnterpriseCode);

					DataRow _row = this._dataClearDataTable.Rows.Find("DCDATAINFO");
					// ��v����s�����݂���I
					if (_row != null)
					{
						string message = "���_�Ǘ�����M�f�[�^�iDC�j�N���A���� ";
						OperationHistoryLog log = new OperationHistoryLog();
						_row.BeginEdit();
						if (status1 == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							message += "����I��";
							_row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "����I��";
						}
						else
						{
							message += "�G���[";
							_row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "�������ɃG���[���������܂����B";
						}
						log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, message, string.Empty);
						_row.EndEdit();
					}
				}

                #region DEL by Liangsd     2011/09/06
                //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                // ���_�Ǘ�����M�}�X�^�iDC�jclear
                //if (dcMustClearFlg)
                //{
                //    status1 = this._iMstDCControlDB.DCMSDataClear(LoginInfoAcquisition.EnterpriseCode);

                //    DataRow _row = this._dataClearDataTable.Rows.Find("DCMUSTINFO");
                //    // ��v����s�����݂���I
                //    if (_row != null)
                //    {
                //        string message = "���_�Ǘ�����M�}�X�^�iDC�j�N���A���� ";
                //        OperationHistoryLog log = new OperationHistoryLog();
                //        _row.BeginEdit();
                //        if (status1 == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                //        {
                //            message += "����I��";
                //            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "����I��";
                //        }
                //        else
                //        {
                //            message += "�G���[";
                //            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "�������ɃG���[���������܂����B";
                //        }
                //        log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, message, string.Empty);
                //        _row.EndEdit();
                //    }
                //}
                //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
                #endregion
                // ADD 2011.08.26 ���� ----------<<<<<
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�N���A����
        /// </summary>
        /// <param name="dataRow">�f�[�^�s���</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�N���A�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>�f�[�^�N���A���[�N</returns>
        private DataClearWork CopyDataClearWork(DataClearDataSet.DataClearRow dataRow)
        {
            DataClearWork work = new DataClearWork();
            work.TableId = dataRow.TableId;
            work.TableNm = dataRow.TableNm;
            work.IsChecked = dataRow.IsChecked;
            work.ClearCode = dataRow.ClearCode;
            work.FileId = dataRow.FileId;

            return work;
        }
        #endregion �f�[�^�N���A����

        #region �� �I�t���C����ԃ`�F�b�N���� ��

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>�`�F�b�N��������</returns>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>���茋��</returns>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion �� �I�t���C����ԃ`�F�b�N���� ��

        //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
        /// <summary>
        /// ���_�Ǘ�����M�f�[�^����
        /// </summary>
        /// <returns></returns>
        public bool IsSelected()
        {
            bool flag = false;
            foreach (DataRow row in this._dataClearDataTable.Rows)
            {
                DataClearDataSet.DataClearRow dataRow = (DataClearDataSet.DataClearRow)row;

                if (dataRow.IsChecked)
                {
                    if (dataRow.TableId.Equals("DCDATAINFO"))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
    }
}
