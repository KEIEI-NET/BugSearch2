using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g���� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �R���o�[�g���� �A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: 30290</br>
    /// <br>Date		: 2008.09.22</br>
    /// <br>Update Note : 2011/09/06 ����� �A��991�ARedmine#23658�̑Ή�</br>
    /// </remarks>
    public class ConvertProcAcs
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IConvertProcessDB _IConvertProcessDB = null;

        // --- ADD 2011/09/06---------->>>>>
        private static readonly string PROGRAM_ID = "PMKHN08001A";
        private static readonly string PROGRAM_NAME = "PM7��PM.NS�R���o�[�g";
        // --- ADD 2011/09/06----------<<<<<
        # endregion

        # region ��Constracter
        /// <summary>
        /// �R���o�[�g���� �A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�����A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2006.12.19</br>
        /// </remarks>
        public ConvertProcAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._IConvertProcessDB = (IConvertProcessDB)MediationConverProcessDB.GetConvertProcessDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._IConvertProcessDB = null;
            }
        }
        # endregion

        #region [ �R���o�[�g���� ]
        /// <summary>
        /// �g�����U�N�V�������J�n���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �g�����U�N�V�������J�n���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int BeginTransaction()
        {
            return _IConvertProcessDB.BeginTransaction();
        }

        /// <summary>
        /// �g�����U�N�V�������I�����܂��B
        /// </summary>
        /// <param name="commitFlg">true : �R�~�b�g�@false : ���[���o�b�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �g�����U�N�V�������I�����܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int EndTransaction(bool commitFlg)
        {
            return _IConvertProcessDB.EndTransaction(commitFlg);
        }

        /// <summary>
        /// �R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J���܂��B
        /// </summary>
        /// <param name="tableID">�Ώۂ̃e�[�u��ID</param>
        /// <param name="truncateFlg">�폜�t���O</param>
        /// <param name="deployDataList">�f�[�^�̃��X�g(ArrayList)</param>
        /// <param name="updateCnt">�A�b�v�f�[�g�f�[�^�J�E���g</param>
        /// <param name="errMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int DeployConvertData(string tableID, bool truncateFlg, ref ArrayList deployDataList, out int updateCnt, out string errMsg)
        {
            // --- ADD 2011/09/06---------->>>>>
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J�J�n", string.Empty);
            // --- ADD 2011/09/06----------<<<<<

            ConvertResultWork ret;
            ArrayList retList = new ArrayList();
            CustomSerializeArrayList list = new CustomSerializeArrayList();
            CustomSerializeArrayList errList = new CustomSerializeArrayList();
            //ArrayList errList = new ArrayList();
            list.Add(deployDataList);

            _IConvertProcessDB.StartProcess();
            int status = _IConvertProcessDB.DeployConvertData(tableID, truncateFlg, list, ref errList, out ret);
            updateCnt = ret.UpdateCnt;
            errMsg = ret.ErrMsg;
            if (ret.FailedRowCnt > 0 && errList.Count > 0)
            {
                for (int i = 0; i < errList.Count; i++)
                {
                    ErrorReportWork err = errList[i] as ErrorReportWork;
                    string failedQuery = string.Format("���f�[�^ [{0}]\r\n\t�˃G���[���b�Z�[�W [{1}]", err.ProcessingData, err.ErrMsg);
                    if (string.IsNullOrEmpty(failedQuery) == false)
                    {
                        retList.Add(failedQuery);
                    }
                }
            }
            deployDataList = retList;

            // --- ADD 2011/09/06---------->>>>>
            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, 
                PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J�I��", string.Empty);
            // --- ADD 2011/09/06----------<<<<<
            return status;
        }

        /// <summary>
        /// �݌Ɏ󕥐ݒ菈��
        /// </summary>
        /// <param name="source">�݌Ɏ󕥐ݒ茳�f�[�^[0:����/1:���㗚��/2:�d��/3:�d������/4:�݌Ɉړ�/5:�݌ɒ���]</param>
        /// <returns></returns>
        public int SetStockAcPayHist(string enterpriseCode, List<int> lstSource, out int resultCnt)
        {
            int status = _IConvertProcessDB.SetStockAcPayHist(enterpriseCode, lstSource, out resultCnt);
            return status;
        }

        /// <summary>
        /// �������~
        /// </summary>        
        /// <returns></returns>
        public int StopProcess()
        {
            int status = _IConvertProcessDB.StopProcess();
            if (status == 0)
                _IConvertProcessDB.EndTransaction(false);
            return status;
        }
        #endregion
    }
}
