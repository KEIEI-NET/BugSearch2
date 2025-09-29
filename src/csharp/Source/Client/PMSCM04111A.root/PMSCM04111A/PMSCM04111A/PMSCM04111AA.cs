//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����󋵊m�F �A�N�Z�X�N���X
// �v���O�����T�v   : �����󋵊m�F �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/08/01   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/09/03   �C�����e : Redmine#43408
//                                   �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����󋵊m�F �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����󋵊m�F �A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/01</br>
    /// <br>Update Note : 2014/09/03 �c����</br>
    /// <br>�Ǘ��ԍ�    : 11070136-00 Redmine#43408</br>
    /// <br>            : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
    /// </remarks>
    public class SynchConfirmAcs
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ISynchConfirmDB _iSynchConfirmDB;
        /// <summary>�����v���Ǘ� �A�N�Z�X�N���X</summary>
        private SynchExecuteAcs _synchExecuteAcs;

        /// <summary>��ʂɊ֘A������</summary>
        private SynchConfirmDataSet.SynchConfirmDataTable _synchConfirmDataTable;
        /// <summary>XML����̊֘A����}�X�^���</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOn;
        /// <summary>XML����̊֘A����}�X�^���</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOff;
        /// <summary>�������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j</summary>
        private int _syncMode;
        /// <summary>�����G���[�L���itrue�F�G���[����@false�F�G���[�Ȃ��j</summary>
        private bool _isError;
        /// <summary>�G���[���������ԌÂ����ԁi��ʂŕ\���p�j</summary>
        private DateTime _errStTime;
        /// <summary>�G���[�X�e�[�^�X�i��ʂŕ\���p�j</summary>
        private int _errStatus;
        /// <summary>�G���[���e�i��ʂŕ\���p�j</summary>
        private string _errMessage;
        /// <summary>�����v���f�[�^���</summary>
        private Dictionary<string, SyncReqDataWork> _syncReqDataDic;
        /// <summary>�����v���f�[�^�Ɋe��Ԃ̃f�[�^����</summary>
        private Dictionary<string, int> _syncReqDataCntDic;
        /// <summary>�ő厎�s��</summary>
        private int _maxRetryCount;
        /// <summary>�����v���f�[�^�Ƀe�[�u�����X�g</summary>
        private List<string> _syncTalbeList;
        /// <summary>��ʍ����ɕ\���p�����v���f�[�^</summary>
        private SyncReqDataWork _syncDataForDisplay;

        /// <summary>�֘A�}�X�^�ݒ��XML</summary>
        private const string XML_FILE_NAME = "SyncAssociatedDataList.xml";
        /// <summary>�����̏��(2:����M����)</summary>
        private const string SYNC_STATUS_FINISHED = "���M��";
        /// <summary>�����̏��(1:����M��)</summary>
        private const string SYNC_STATUS_EXECUTING = "���M��...";
        /// <summary>�����̏��(0:����M�ҋ@��)</summary>
        private const string SYNC_STATUS_WAITING = "���M�ҋ@��";

        /// <summary>�f�[�^�����v�Z�p�L�[(������/�Ď��s�񐔁��ő�l)</summary>
        private const string DATACALC_NOSYNC = "-0";
        /// <summary>�f�[�^�����v�Z�p�L�[(����M��)</summary>
        private const string DATACALC_SYNCING = "-1"; 
        /// <summary>�f�[�^�����v�Z�p�L�[(�Ď��s�񐔂��ő�l�ɂȂ�)</summary>
        private const string DATACALC_SYNCERROR = "-2";
        # endregion

        #region �v���p�e�B
        /// <summary>
        /// ��ʂɊ֘A������
        /// </summary>
        public SynchConfirmDataSet.SynchConfirmDataTable SynchConfirmDataTable
        {
            get { return _synchConfirmDataTable; }
            set { this._synchConfirmDataTable = value; }
        }

        /// <summary>
        /// XML����̊֘A����}�X�^���
        /// </summary>
        public Dictionary<string, List<ReferenceTable>> TableIDDicForCheckOn
        {
            get { return _tableIDDicForCheckOn; }
        }

        /// <summary>
        /// XML����̊֘A����}�X�^���
        /// </summary>
        public Dictionary<string, List<ReferenceTable>> TableIDDicForCheckOff
        {
            get { return _tableIDDicForCheckOff; }
            set { _tableIDDicForCheckOff = value; }
        }

        /// <summary>
        /// �������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j
        /// </summary>
        public int SyncMode
        {
            get { return _syncMode; }
        }

        /// <summary>
        /// �����G���[�L���itrue�F�G���[����@false�F�G���[�Ȃ��j
        /// </summary>
        public bool IsError
        {
            get { return _isError; }
        }

        /// <summary>
        /// �G���[���������ԌÂ����ԁi��ʂŕ\���p�j
        /// </summary>
        public DateTime ErrStTime
        {
            get { return _errStTime; }
        }

        /// <summary>
        /// �G���[�X�e�[�^�X�i��ʂŕ\���p�j
        /// </summary>
        public int ErrStatus
        {
            get { return _errStatus; }
        }

        /// <summary>
        /// �G���[���e�i��ʂŕ\���p�j
        /// </summary>
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        #endregion

        # region ��Constracter
        /// <summary>
        /// �����󋵊m�F �A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����󋵊m�F�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchConfirmAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                _iSynchConfirmDB = (ISynchConfirmDB)MediationSynchConfirmDB.GetSynchConfirmDB();
                /// <summary>�����v���Ǘ� �A�N�Z�X�N���X</summary>
                _synchExecuteAcs = new SynchExecuteAcs();

                //��ʂɊ֘A������
                _synchConfirmDataTable = new SynchConfirmDataSet.SynchConfirmDataTable();
                //XML����̊֘A����}�X�^���
                _tableIDDicForCheckOn = new Dictionary<string, List<ReferenceTable>>();
                //XML����̊֘A����}�X�^���
                _tableIDDicForCheckOff = new Dictionary<string, List<ReferenceTable>>();
                //�����v���f�[�^���
                _syncReqDataDic = new Dictionary<string, SyncReqDataWork>();
                //�����v���f�[�^�Ɋe��Ԃ̃f�[�^����
                _syncReqDataCntDic = new Dictionary<string, int>();
                //�����v���f�[�^�Ƀe�[�u�����X�g
                _syncTalbeList = new List<string>();

                //�ő厎�s�񐔂̎擾
                _synchExecuteAcs.GetMaxRetryCount(out _maxRetryCount);
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                _iSynchConfirmDB = null;
            }
        }
        #endregion

        #region �����v���f�[�^�̌���
        /// <summary>
        /// �����v���f�[�^�̌���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="maxRetryCount">�ő厎�s��</param>
        /// <param name="list">��������</param>
        /// <param name="err">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �����v���f�[�^�̌����̌������s���܂��B</br>
        /// <br>Programmer	: chenyk</br>
        /// <br>Date		: 2014/08/14</br>
        /// <br>Update Note : 2014/09/03 �c����</br>
        /// <br>�Ǘ��ԍ�    : 11070136-00 Redmine#43408</br>
        /// <br>            : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
        /// </remarks>
        public int SerachErr(string enterpriseCode, int maxRetryCount, DateTime requireDateTime, ref ArrayList list, out string err)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            err = string.Empty;
            list = new ArrayList();

            try
            {
                SyncReqDataWork syncReqDataWork = new SyncReqDataWork();
                syncReqDataWork.EnterpriseCode = enterpriseCode;
                syncReqDataWork.CreateDateTime = requireDateTime;

                object syncReqDataParam = (object)syncReqDataWork;
                object syncReqDataOutObj1 = null;
                err = string.Empty;

                //�����v���G���[���̎擾
                status = _iSynchConfirmDB.SearchSyncReqErrData(out syncReqDataOutObj1, out err, syncReqDataParam, maxRetryCount);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    ArrayList list1 = (ArrayList)syncReqDataOutObj1;
                    if (list1 != null)
                    {
                        list.AddRange(list1);
                    }

                    /*
                    object syncReqDataOutObj2 = null;
                    status = _iSynchConfirmDB.SearchSyncReqErrDataByCreateDateTime(out syncReqDataOutObj2, out err, maxRetryCount, syncReqDataParam); // ADD 2014/09/03 �c���� Redmine#43408

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        ArrayList list2 = (ArrayList)syncReqDataOutObj2;

                        if (list2 != null)
                        {
                            list.AddRange(list2);
                        }

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    */
                }

                //�쐬�����ɂ��\�[�g
                if (list != null && list.Count > 0)
                {
                    SortSyncReqDataCompare sortSyncReqDataCompare = new SortSyncReqDataCompare();
                    list.Sort(sortSyncReqDataCompare);
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                list = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                err = ex.Message;
            }

            return status;
        }
        #endregion

        #region �����󋵊m�F�̌���
        /// <summary>
        /// �����󋵊m�F�̌���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="errMessaage"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �����󋵊m�F�̌������s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        public int Search(string enterpriseCode, out string errMessaage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMessaage = string.Empty;

            try
            {
                _synchConfirmDataTable.Clear();

                SyncMngWork syncMngParamWork = new SyncMngWork();
                syncMngParamWork.EnterpriseCode = enterpriseCode;

                object param = (object)syncMngParamWork;
                object outObj = null;

                status = _iSynchConfirmDB.SearchSyncMngData(out outObj, out errMessaage, param, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�����v���f�[�^�̌���
                    status = SerachSyncReqData(enterpriseCode, ref errMessaage);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        ArrayList resultList = (ArrayList)outObj;

                        //DataTable�փf�[�^�̊i�[
                        SetDataToDataTable(resultList);

                        //�֘A����}�X�^��XML�̓ǂݍ���
                        GetTableIDFromXML();
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //����
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessaage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �����v���f�[�^�̌���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="errMessaage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: �����v���f�[�^�̌������s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private int SerachSyncReqData(string enterpriseCode, ref string errMessaage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMessaage = string.Empty;

            try
            {
                //�������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j
                _syncMode = 0;
                //�����G���[�L���itrue�F�G���[����@false�F�G���[�Ȃ��j
                _isError = false;
                //�����v���f�[�^Dictionary
                _syncReqDataDic = new Dictionary<string, SyncReqDataWork>();
                //�����v���f�[�^�Ɋe��Ԃ̃f�[�^����
                _syncReqDataCntDic = new Dictionary<string, int>();
                //�����v���f�[�^�Ƀe�[�u�����X�g
                _syncTalbeList = new List<string>();

                #region �������T���擾(�e��Ԃ̌������擾����)
                SyncReqDataWork syncReqDataWork = new SyncReqDataWork();
                syncReqDataWork.EnterpriseCode = enterpriseCode;

                object syncReqDataParam = (object)syncReqDataWork;
                object syncReqDataCountOutObj = null;

                status = _iSynchConfirmDB.GetSyncReqDataCount(out syncReqDataCountOutObj, out errMessaage, syncReqDataParam);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList syncReqDataCountList = (ArrayList)syncReqDataCountOutObj;

                    foreach (SyncReqDataWork work in syncReqDataCountList)
                    {
                        //�����v���f�[�^�Ƀe�[�u�����i�[����(����M�����̏�Ԃ̔��f�p)
                        if (!_syncTalbeList.Contains(work.SyncTableID))
                        {
                            _syncTalbeList.Add(work.SyncTableID);
                        }

                        //�����v���f�[�^�Ɋe��Ԃ̃f�[�^����Dictionary�̍\���F
                        //�e�[�u��ID-���s���ʏ��
                        // ���f�[�^����
                        string dicKey = string.Empty;
                        if ((work.SyncExecRslt == 0) || (work.SyncExecRslt == 2 && work.RetryCount < _maxRetryCount))
                        {
                            dicKey = DATACALC_NOSYNC;
                        }
                        else if (work.SyncExecRslt == 1)
                        {
                            dicKey = DATACALC_SYNCING;
                        }
                        else if ((work.SyncExecRslt == 2 && work.RetryCount >= _maxRetryCount))
                        {
                            dicKey = DATACALC_SYNCERROR;
                        }

                        string key = work.SyncTableID + dicKey;
                        if (!_syncReqDataCntDic.ContainsKey(key))
                        {
                            _syncReqDataCntDic.Add(key, work.SyncDataCount);
                        }
                        else
                        {
                            _syncReqDataCntDic[key] += work.SyncDataCount;
                        }
                    }

                    //�����v���G���[���̎擾
                    object syncReqErrDataOutObj = null;
                    status = _iSynchConfirmDB.SearchSyncReqErrData(out syncReqErrDataOutObj, out errMessaage, syncReqDataParam, _maxRetryCount);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList syncReqErrDataList = (ArrayList)syncReqErrDataOutObj;

                        int index = 0;
                        foreach (SyncReqDataWork work in syncReqErrDataList)
                        {
                            if (index == 0)
                            {
                                _syncDataForDisplay = work;
                            }
                            index++;

                            if (!_syncReqDataDic.ContainsKey(work.SyncTableID))
                            {
                                _syncReqDataDic.Add(work.SyncTableID, work);
                            }
                        }
                    }

                }
                #endregion
            }
            catch(Exception ex)
            {
                errMessaage = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //�������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j
                _syncMode = 0;
                //�����G���[�L���itrue�F�G���[����@false�F�G���[�Ȃ��j
                _isError = false;
                //�����v���f�[�^Dictionary
                _syncReqDataDic = new Dictionary<string, SyncReqDataWork>();
                //�����v���f�[�^�Ɋe��Ԃ̃f�[�^����
                _syncReqDataCntDic = new Dictionary<string, int>();
                //�����v���f�[�^�Ƀe�[�u�����X�g
                _syncTalbeList = new List<string>();
            }

            return status;
 
        }

        /// <summary>
        /// DataTable�֓����Ǘ��}�X�^�̊i�[
        /// </summary>
        /// <param name="resultList"></param>
        /// <remarks>
        /// <br>Note		: DataTable�֓����Ǘ��}�X�^�̊i�[���s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private void SetDataToDataTable(ArrayList resultList)
        {
            if (resultList.Count > 0)
            {
                //�������[�h�̔��f
                foreach (SyncMngWork syncMngWork in resultList)
                {
                    string SyncErrorKey = syncMngWork.SyncTableID + DATACALC_SYNCERROR; //�G���[�A�Ď��s�񐔁��ő�l

                    if (_syncReqDataCntDic.ContainsKey(SyncErrorKey))
                    {
                        //�������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j
                        _syncMode = 1;

                        _isError = true;

                        if (_syncDataForDisplay != null)
                        {
                            _errStTime = _syncDataForDisplay.CreateDateTime;
                            _errStatus = _syncDataForDisplay.ErrorStatus;
                            _errMessage = _syncDataForDisplay.ErrorContents;
                        }
                        break;
                    }
                }


                DataRow row;

                foreach (SyncMngWork syncMngWork in resultList)
                {
                    row = _synchConfirmDataTable.NewRow();

                    row[_synchConfirmDataTable.TableIDColumn.ColumnName] = syncMngWork.SyncTableID;
                    row[_synchConfirmDataTable.TableNameColumn.ColumnName] = syncMngWork.SyncTableName;

                    string lastSyncUpdDtTm = string.Empty;
                    if (syncMngWork.LastSyncUpdDtTm.ToString().Length == 14) // YYYYMMDDHHMMSS => yyyy�NMM��dd���@xx:xx:xx
                    {
                        lastSyncUpdDtTm = syncMngWork.LastSyncUpdDtTm.ToString().Substring(0, 4) + "�N" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(4, 2) + "��" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(6, 2) + "���@" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(8, 2) + ":" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(10, 2) + ":" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(12, 2);
                    }

                    row[_synchConfirmDataTable.LastSyncUpdDtTmColumn.ColumnName] = lastSyncUpdDtTm;

                    int syncCndtinSta = 2;
                    string syncCndtinDiv = SYNC_STATUS_FINISHED;

                    //�������T���ɂ��A�e����M��Ԃ𔻒f����
                    if (_syncTalbeList == null || !_syncTalbeList.Contains(syncMngWork.SyncTableID))
                    {
                        //�����̏��(2:����M����)
                        syncCndtinSta = 2;
                        syncCndtinDiv = SYNC_STATUS_FINISHED;
                    }
                    else
                    {
                        string syncNormalKey = syncMngWork.SyncTableID + DATACALC_NOSYNC;  //������/�Ď��s��<�ő�l
                        string syncErrorKey = syncMngWork.SyncTableID + DATACALC_SYNCERROR; //�G���[�A�Ď��s�񐔁��ő�l
                        string syncIngKey = syncMngWork.SyncTableID + DATACALC_SYNCING; //����M��

                        if (!_syncReqDataCntDic.ContainsKey(syncErrorKey) && _syncReqDataCntDic.ContainsKey(syncIngKey))
                        {
                            //�����̏��(1:����M��)
                            syncCndtinSta = 1;
                            syncCndtinDiv = SYNC_STATUS_EXECUTING;
                        }
                        else
                        { 
                            //�����̏��(0:����M�ҋ@��)
                            syncCndtinSta = 0;
                            syncCndtinDiv = SYNC_STATUS_WAITING;

                            if (_syncReqDataCntDic.ContainsKey(syncErrorKey))
                            {
                                int dataTotalCount = _syncReqDataCntDic[syncErrorKey]; //������
                                int errDataCount = _syncReqDataCntDic[syncErrorKey]; //�G���[����
                                string errorMeaage = string.Empty; //�G���[���b�Z�[�W

                                if (_syncReqDataCntDic.ContainsKey(syncNormalKey))
                                {
                                    dataTotalCount += _syncReqDataCntDic[syncNormalKey];
                                }

                                if (_syncReqDataCntDic.ContainsKey(syncIngKey))
                                {
                                    dataTotalCount += _syncReqDataCntDic[syncIngKey];
                                }

                                //�G���[���b�Z�[�W
                                if (_syncReqDataDic.ContainsKey(syncMngWork.SyncTableID))
                                {
                                    errorMeaage = _syncReqDataDic[syncMngWork.SyncTableID].ErrorContents;
                                }

                                string addMessage = "(�f�[�^�����F" + dataTotalCount + "���A�G���[�����F" + errDataCount + "���A�G���[���b�Z�[�W�F" + errorMeaage + ")";
                                syncCndtinDiv += addMessage;
                            }
                        }
                    }

                    row[_synchConfirmDataTable.SyncCndtinStaColumn.ColumnName] = syncCndtinSta;
                    row[_synchConfirmDataTable.SyncCndtinDivColumn.ColumnName] = syncCndtinDiv;

                    row[_synchConfirmDataTable.SelectionColumn.ColumnName] = false;

                    _synchConfirmDataTable.Rows.Add(row);
                }

                _synchConfirmDataTable.DefaultView.Sort = string.Format("{0}", _synchConfirmDataTable.SyncCndtinStaColumn.ColumnName);
            }
        }

        /// <summary>
        /// �쐬�����ɂ�蓯���v���f�[�^�̃\�[�g
        /// </summary>
        /// <param name="obj1">�����v���f�[�^1</param>
        /// <param name="obj2">�����v���f�[�^2</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �쐬�����ɂ�蓯���v���f�[�^�̃\�[�g���s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private int SortSyncReqDataCompare(SyncReqDataWork obj1, SyncReqDataWork obj2)
        {
            int res = 0;

            if ((obj1 == null) && (obj2 == null))
            {
                return 0;
            }
            else if ((obj1 != null) && (obj2 == null))
            {
                return 1;
            }
            else if ((obj1 == null) && (obj2 != null))
            {
                return -1;
            }

            //�쐬�����ɂ�蔻�f
            if (obj1.CreateDateTime > obj2.CreateDateTime)
            {
                res = 1;
            }
            else if (obj1.CreateDateTime < obj2.CreateDateTime)
            {
                res = -1;
            }

            return res;
        }

        /// <summary>
        /// XML����֘A����e�[�u���̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: XML����֘A����e�[�u�����擾����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private void GetTableIDFromXML()
        {
            _tableIDDicForCheckOn = new Dictionary<string, List<ReferenceTable>>();
            _tableIDDicForCheckOff = new Dictionary<string, List<ReferenceTable>>();
            string XMLFileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

            if (UserSettingController.ExistUserSetting(XMLFileName))
            {
                TableInfo tableInfo = UserSettingController.DeserializeUserSetting<TableInfo>(XMLFileName);

                if (tableInfo != null && tableInfo.TableList != null && tableInfo.TableList.Count > 0)
                {
                    foreach (TableItem tableItem in tableInfo.TableList)
                    {
                        //XML����̊֘A����}�X�^FOR�@CHECKON
                        if (!_tableIDDicForCheckOn.ContainsKey(tableItem.TableID))
                        {
                            _tableIDDicForCheckOn.Add(tableItem.TableID, tableItem.ReferenceTableList);
                        }

                        //XML����̊֘A����}�X�^FOR�@CHECKOFF
                        if (tableItem.ReferenceTableList.Count > 0)
                        {
                            foreach (ReferenceTable subTableID in tableItem.ReferenceTableList)
                            {
                                if (!_tableIDDicForCheckOff.ContainsKey(subTableID.ReferenceTableID))
                                {
                                    List<ReferenceTable> list = new List<ReferenceTable>();
                                    ReferenceTable referenceTable = new ReferenceTable();
                                    referenceTable.ReferenceTableID = tableItem.TableID;

                                    list.Add(referenceTable);
                                    _tableIDDicForCheckOff.Add(subTableID.ReferenceTableID, list);
                                }
                                else
                                {
                                    ReferenceTable referenceTable = new ReferenceTable();
                                    referenceTable.ReferenceTableID = tableItem.TableID;

                                    if (!_tableIDDicForCheckOff[subTableID.ReferenceTableID].Contains(referenceTable))
                                    {
                                        _tableIDDicForCheckOff[subTableID.ReferenceTableID].Add(referenceTable);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        # endregion
    }

    #region ��r�p�N���X

    /// <summary>
    ///�쐬�����ɂ�蓯���v���f�[�^�̃\�[�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �쐬�����ɂ�蓯���v���f�[�^�̃\�[�g���s���܂��B</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class SortSyncReqDataCompare : IComparer
    {
        #region IComparer �����o

        /// <summary>
        /// ��r�p���\�b�h
        /// </summary>
        /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
        /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
        /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        public int Compare(object x, object y)
        {
            SyncReqDataWork obj1 = x as SyncReqDataWork;
            SyncReqDataWork obj2 = y as SyncReqDataWork;

            // �`�[�����ʂŔ�r
            return obj1.CreateDateTime.CompareTo(obj2.CreateDateTime);
        }

        #endregion
    }

    #endregion

    #region XML�\��
    /// <summary>
    /// XML�\���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: XML�\���N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class TableInfo
    {
        private List<TableItem> _tableList;

        public List<TableItem> TableList
        {
            get
            {
                if (_tableList == null)
                {
                    _tableList = new List<TableItem>();
                }
                return _tableList;
            }
            set
            {
                _tableList = value;
                if (_tableList == null)
                {
                    _tableList = new List<TableItem>();
                }
            }
        }
    }

    /// <summary>
    /// XML�\���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: XML�\���N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class TableItem
    {
        private string _tableID;
        private List<ReferenceTable> _referenceTableList;

        public string TableID
        {
            get
            {
                return _tableID;
            }
            set
            {
                _tableID = value;
            }
        }

        public List<ReferenceTable> ReferenceTableList
        {
            get
            {
                if (_referenceTableList == null)
                {
                    _referenceTableList = new List<ReferenceTable>();
                }
                return _referenceTableList;
            }
            set
            {
                _referenceTableList = value;
                if (_referenceTableList == null)
                {
                    _referenceTableList = new List<ReferenceTable>();
                }
            }
        }
    }

    /// <summary>
    /// XML�\���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: XML�\���N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class ReferenceTable
    {
        private string _referenceTableID;

        public string ReferenceTableID
        {
            get
            {
                return _referenceTableID;
            }
            set
            {
                _referenceTableID = value;
            }
        }
    }
    #endregion
}
