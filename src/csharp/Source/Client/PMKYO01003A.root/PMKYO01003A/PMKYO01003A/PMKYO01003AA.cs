//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q 
// �C �� ��  2009/04/28  �C�����e : �݌Ɍn�f�[�^�̏����ƏW�v�@�Ή��̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q 
// �C �� ��  2009/06/17  �C�����e : PVCS�[#161 ���o�Ώۃf�[�^�����݂��Ȃ��ꍇ�̃��O�ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ���� ���n 
// �C �� ��  2011/02/01  �C�����e : �X�V�����擾�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� 
// �C �� ��  2011/07/25  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� 
// �C �� ��  2011/08/19  �C�����e : redmine #23692,#23807�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/25  �C�����e : Redmine #23980���M���ʌ����s���ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/31  �C�����e : Redmine #24278 �f�[�^������M�������N�����܂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/14  �C�����e : Redmine #25009 ���M��������M���̕����J�n���t�������Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : dingjx
// �C �� ��  2011/11/01  �C�����e : Redmine #26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/10  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/06  �C�����e : Redmine#8293 ��ʂ̏I�����t�{�V�X�e�������d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/07  �C�����e : Redmine#8293 ��ʂ̏I�����t�d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/12/22  �C�����e : Redmine#27395 ���_�Ǘ�/���M�f�[�^�̘R��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : zhlj
// �C �� ��  2013/02/07  �C�����e : 10900690-00 2013/3/13�z�M���ً̋}�Ή�
//                                  Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : 杍^
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
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
    /// �f�[�^���M�����X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �f�[�^���M�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// Update     : dingjx</br>
    /// Note       : Redmine #26228</br>
    /// Update Note: 2020/09/25 杍^<br />
    /// �Ǘ��ԍ�   : 11600006-00<br />
    ///            : PMKOBETSU-3877�̑Ή�<br />
    /// </remarks>
    public class UpdateCountInputAcs
    {
        # region �� Constructor ��

        #region �� Const Memebers ��
        private const int MAXCOUNT_16 = 16;
        private const string ZERO_0 = "0";
        private const string MARK_1 = ":";
        private const string MARK_2 = "�A";
        private const string MARK_3 = " ";
        private const string PROGRAM_ID = "PMKYO01001UA";
        private const string PROGRAM_NAME = "�f�[�^���M����";
        private const string COUNTNAME = "��";
        #endregion �� Const Memebers ��

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private UpdateCountInputAcs()
        {
            // �ϐ�������
            this._dataSet = new UpdateResultDataSet();
            this._extractionConditionDataSet = new ExtractionConditionDataSet();
            this._updateResultDataTable = this._dataSet.UpdateResult;
            this._extractionConditionDataTable = this._extractionConditionDataSet.ExtractionCondition;
            this._baseDataExtraDefSetDB = APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
            this._secMngConnectStAcs = new SecMngConnectStAcs();
            this._sendSetAcs = new SendSetAcs();
        }
        # endregion �� Constructor ��

        # region �� Properties ��
        /// <summary>
        /// �f�[�^���M�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public UpdateResultDataSet.UpdateResultDataTable UpdateResultDataTable
        {
            get { return _updateResultDataTable; }
        }

        /// <summary>
        /// �f�[�^���M�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public ExtractionConditionDataSet.ExtractionConditionDataTable ExtractionConditionDataTable
        {
            get { return _extractionConditionDataTable; }
        }
        # endregion �� Properties ��

        # region �� Private Members ��
        // �X�V���ʃf�[�^�Z�b�g
        private UpdateResultDataSet _dataSet;
        // ���o�����f�[�^�Z�b�g
        private ExtractionConditionDataSet _extractionConditionDataSet;
        // �X�V���ʃf�[�^�e�[�u��
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // ���o�����f�[�^�e�[�u��
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        private static UpdateCountInputAcs _updateCountInsts;
        private IAPSendMessageDB _baseDataExtraDefSetDB;
        private IDCControlDB _idcControlDB;
        private ISKControlDB _iskControlDB;
        // ���_�Ǘ��ڑ���ݒ�A�N�Z�X
        private SecMngConnectStAcs _secMngConnectStAcs;
        // ����M�Ώېݒ�̃A�N�Z�X
        SendSetAcs _sendSetAcs;

        private int _extractCondDiv; //ADD 2011/11/01 xupz

        # endregion �� Private Members ��

        # region �� �f�[�^���M�����A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// �f�[�^���M�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�f�[�^���M�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static UpdateCountInputAcs GetInstance()
        {
            if (_updateCountInsts == null)
            {
                _updateCountInsts = new UpdateCountInputAcs();
            }

            return _updateCountInsts;
        }
        # endregion �� �f�[�^���M�����A�N�Z�X�N���X �C���X�^���X�擾���� ��

        # region �� �f�[�^���M���� ��
        /// <summary>
        /// �f�[�^���M����
        /// </summary>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="startTime">�J�n����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="updSectionCode">upd��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
		/// <param name="baseCode">���_�R�[�h</param>
		/// <param name="sendCode">send���_�R�[�h</param>
        /// <param name="isEmpty">�f�[�^�����邩�ǂ���</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="fileIds">�t�@�C��ID�z��</param>
		/// <param name="fileNms">�t�@�C�����̔z��</param>
		/// <param name="sendDestEpCodeList">sendDestEpCodeList</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�ɂ��A�f�[�^���M��������B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        //public SearchCountWork UpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty, int connectPointDiv, string[] fileIds)
		//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
		//public SearchCountWork UpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms)
		//{
		//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        //  DEL dingjx  2011/11/01  ------------------------------------->>>>>>
        //-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        //public SearchCountWork UpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updSectionCode, string updEmployeeCode,
        //    string baseCode,string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList)
        //{
		//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        //  DEL dingjx  2011/11/01  -------------------------------------<<<<<<<

        //  ADD dingjx  2011/11/01  ------------------------------------->>>>>>
        public SearchCountWork UpdateProc(int extractCondDiv, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updSectionCode, string updEmployeeCode,
            // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            //string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList)
            string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList, int acptAnOdrSendDiv, int shipmentSendDiv, int estimateSendDiv)
        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
        {
        //  ADD dingjx  2011/11/01  -------------------------------------<<<<<<
            string retMessage;
            isEmpty = false;
            SearchCountWork searchCountWork = new SearchCountWork();
			CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            DateTime syncExecDtTemp = new DateTime(); // ADD 2011/12/06
            DateTime syncExecDtLogTemp = new DateTime(); // ADD 2011/12/06
            bool updateFlg = true; // ADD 2011/12/07
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
			
			DateTime minSyncExecDt = new DateTime();//ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j

            // �f�[�^�X�V����
            if (connectPointDiv == 0)
            {
                if (this._idcControlDB == null)
                {
                    this._idcControlDB = MediationDCControlDB.GetDCControlDB();
                }
            }
            else
            {
                if (this._iskControlDB == null)
                {
                    this._iskControlDB = MediationSKControlDB.GetSKControlDB();
                }
            }

            // ���o�E�X�V�R���g���[�����������[�g���Ăяo���Ē��o�f�[�^���擾���A���o���ʃN���X��Ԃ��܂��B
			//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayList(enterpriseCode, beginningTime, endingTime, ref retCSAList, fileIds, out retMessage);
			//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			APSendDataWork paraSendDataWork = new APSendDataWork();
			paraSendDataWork.EndDateTime = endingTime;
			paraSendDataWork.StartDateTime = beginningTime;
			paraSendDataWork.PmEnterpriseCode = enterpriseCode;
			paraSendDataWork.PmSectionCode = baseCode;
            paraSendDataWork.SndMesExtraCondDiv = extractCondDiv;   //  ADD dingjx  2011/11/01                  
            paraSendDataWork.SyncExecDate = startTime.Ticks;
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            paraSendDataWork.AcptAnOdrSendDiv = acptAnOdrSendDiv;
            paraSendDataWork.ShipmentSendDiv = shipmentSendDiv;
            paraSendDataWork.EstimateSendDiv = estimateSendDiv;
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

            // ADD 2011/12/06 ----------->>>>>>
            // ADD 2011/12/07 ----------->>>>>>
            if (extractCondDiv == 1)
            {
                // �V�X�e�����t
                long endTimeTemp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));

                // ��ʏI�����t���ߋ����t�̏ꍇ�F
                if (endTimeTemp > endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // ��ʏI�������V�X�e�����t�̏ꍇ�F
                else if (endTimeTemp == endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DateTime endTimeLog = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                            int.Parse(endTimeStr.Substring(4, 2)),
                            int.Parse(endTimeStr.Substring(6, 2)),
                            23, 59, 59);

                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTimeLog;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // ��ʏI�������������t�̏ꍇ�F
                else
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }

                    updateFlg = false;
                }



            }
            // ADD 2011/12/06 -----------<<<<<<
            // ADD 2011/12/07 -----------<<<<<<
            
            this._extractCondDiv = extractCondDiv; // ADD 2011/11/01 xupz
			int no = 0;
			int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayListSCM(out retCSAList, paraSendDataWork, baseCode, fileIds, out retMessage, out no, updSectionCode);
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // ���o���ʐ���̏ꍇ�A�f�[�^�ϊ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();
                
                // �f�[�^�ϊ�����
				//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				//// -- UPD 2011/02/01 ---------------------------------------->>>
				////syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds);
				//syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//// -- UPD 2011/02/01 ----------------------------------------<<<
				//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
				//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                if (isEmpty)
                {
                    // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                    // MOD 2009/06/23 ---->>>
                    // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                    // MOD 2009/06/23 ----<<<
                    return searchCountWork;
                }
                else
                {
                    try
                    {
                        // �f�[�^�X�V����
                        if (connectPointDiv == 0)
                        {
                            // DC�X�V
							//status = _idcControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);//DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j

							//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
							//����M�������O�f�[�^�̐ݒ�
							ArrayList objList = new ArrayList();
							SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
							//��ƃR�[�h:���O�C�����[�U�[�̊�ƃR�[�h
							sndRcvHisWork.EnterpriseCode = enterpriseCode;
							//�_���폜�敪
							sndRcvHisWork.LogicalDeleteCode = 0;
							//���_�R�[�h:���O�C�����[�U�[�̋��_�R�[�h
							sndRcvHisWork.SectionCode = updSectionCode;
							//����M�������O���M�ԍ�
							sndRcvHisWork.SndRcvHisConsNo = no;
							//���M����:�V�X�e�����t
							// del by ���� 2011.08.19  redmine #23692 �̑Ή� ----------->>>>>>>
							//string sdate = DateTime.Now.ToShortDateString().Replace("/", "");
							//string stime = DateTime.Now.ToShortTimeString().Replace(":", "");
							//sndRcvHisWork.SendDateTime = long.Parse(sdate) * 10000 + long.Parse(stime);
							// del by ���� 2011.08.19  redmine #23692 �̑Ή� -----------<<<<<<<
							sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));// ADD by ���� 2011.08.19 redmine #23692 �̑Ή�
							//����M���O���p�敪:�0:���_�Ǘ��
							sndRcvHisWork.SndLogUseDiv = 0;
							//����M�敪:�0:���M�
							sndRcvHisWork.SendOrReceiveDivCd = 0;
							//���:�0:�f�[�^�
							sndRcvHisWork.Kind = 0;
							//����M���O���o�����敪�u0:����(����)�v
                            //sndRcvHisWork.SndLogExtraCondDiv = 0;   //  DEL dingjx  2011/11/01
                            sndRcvHisWork.SndLogExtraCondDiv = extractCondDiv;  //  ADD dingjx  2011/11/01
							//���M�Ώۋ��_�R�[�h
							sndRcvHisWork.ExtraObjSecCode = baseCode;

                            sndRcvHisWork.SyncExecDate = startTime;  // ADD 2011/11/30
							//���M�ΏۊJ�n�����A���M�ΏۏI������
                            // ----- DEL 2011/11/01 xupz---------->>>>>
                            //sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                            //sndRcvHisWork.SndObjEndDate = syncExecDt;
                            // ----- DEL 2011/11/01 xupz----------<<<<<
                            // ----- ADD 2011/11/01 xupz---------->>>>>
                             if (extractCondDiv == 0)
                            {
                                sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvHisWork.SndObjEndDate = syncExecDt;
                            }
                            else
                            {
                               sndRcvHisWork.SndObjStartDate = minSyncExecDt;
                               //sndRcvHisWork.SndObjEndDate = syncExecDt.AddDays(1).AddTicks(-1); // DEL 2011/12/06
                               //sndRcvHisWork.SndObjEndDate = syncExecDtTemp; // ADD 2011/12/06 // DEL 2011/12/07
                               sndRcvHisWork.SndObjEndDate = syncExecDtLogTemp;  // ADD 2011/12/07
                            }
                            // ----- ADD 2011/11/01 xupz----------<<<<<
							//���M���ƃR�[�h
							for (int i = 0; i < sendDestEpCodeList.Count; i++)
							{
								if (((EnterpriseSet)sendDestEpCodeList[i]).SectionCode.Trim().Equals(sendCode.Trim()))
								{
									sndRcvHisWork.SendDestEpCode = ((EnterpriseSet)sendDestEpCodeList[i]).PmEnterpriseCode;
									break;
								}
							}
							//���M�拒�_�R�[�h
							sndRcvHisWork.SendDestSecCode = sendCode;
							objList.Add(sndRcvHisWork);
							ArrayList paraList = new ArrayList();
							paraList.Add(objList);
							status = _idcControlDB.UpdateSCM(ref updCSAList, enterpriseCode, paraList, out retMessage);

							//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        }
                        else
                        {
                            // �W�v�@�X�V
                            status = _iskControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        retMessage = e.Message;
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = -1;
                return searchCountWork;
            }

            // status��0����̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                // MOD 2009/06/23 ---->>>
                //foreach (string fileId in fileIds)
                for (int i = 0; i < fileIds.Length; i++)
                // MOD 2009/06/23 ----<<<
                {
                    // MOD 2009/06/23 ---->>>
                    /*
                    if (logStr == string.Empty)
                    {
                        logStr += fileId + MARK_3;
                    }
                    else
                    {
                        logStr += MARK_2 + fileId + MARK_3;
                    }
                    */
                    string fileId = fileIds[i];
                    if (!string.IsNullOrEmpty(logStr))
                    {
                        logStr += MARK_2;
                    }
                    // MOD 2009/06/23 ----<<<
                    switch (fileId)
                    {
                        // ����f�[�^
                        case "SalesSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // ���㖾�׃f�[�^
                        case "SalesDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // ���㗚���f�[�^
                        case "SalesHistoryRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistoryCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistoryCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // ���㗚�𖾍׃f�[�^
                        case "SalesHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �����f�[�^
                        case "DepsitMainRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitMainCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitMainCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �������׃f�[�^
                        case "DepsitDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d���f�[�^
                        case "StockSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d�����׃f�[�^
                        case "StockDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d�������f�[�^
                        case "StockSlipHistRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipHistCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipHistCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d�����𖾍׃f�[�^
                        case "StockSlHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �x���`�[�}�X�^
                        case "PaymentSlpRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentSlpCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentSlpCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �x�����׃f�[�^
                        case "PaymentDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �󒍃}�X�^
                        case "AcceptOdrRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �󒍃}�X�^�i�ԗ��j
                        case "AcceptOdrCarRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            // MOD 2009/06/23 ----<<<
                            break;
						// DEL 2011.08.19 ------->>>>>
						//// ���㌎���W�v�f�[�^
						//case "MTtlSalesSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// ���i�ʔ��㌎���W�v�f�[�^
						//case "GoodsMTtlSaSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// �d�������W�v�f�[�^
						//case "MTtlStockSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
                        // �݌ɒ����f�[�^
                        case "StockAdjustRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �݌ɒ������׃f�[�^
                        case "StockAdjustDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �݌Ɉړ��f�[�^
                        case "StockMoveRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockMoveCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockMoveCount);
                            // MOD 2009/06/23 ----<<<
							break;
						// DEL 2011.08.19 ------->>>>>
						//// �݌Ɏ󕥗����f�[�^
						//case "StockAcPayHistRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
						//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
						// ���������}�X�^
						case "DepositAlwRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepositAlwCount);
							break;
						// ����`�}�X�^
						case "RcvDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.RcvDraftDataCount);
							break;
						// ����`�}�X�^
						case "PayDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PayDraftDataCount);
							break;
						//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    }
                }

                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                    logStr, "����(���_�F" + baseCode + ")");
                searchCountWork.Status = 0;
            }
            // AP���b�N�̃^�C���A�E�g�̏ꍇ�A
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT) 
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = -2;
                return searchCountWork;
            }
            // DB��SQL�G���[�̏ꍇ�A
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = -3;
                return searchCountWork;
            }
            // �V�X�e���Ƃ��̑��G���[�̏ꍇ�A
            else 
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = status;
                return searchCountWork;
            }
            // ���_�Ǘ��ݒ�}�X�^�̍X�V
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ------ DEL 2011/11/01 ------>>>>>>
                //// ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                //if (startTime < syncExecDt)
                //{
                //    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                //    status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDt, out retMessage, baseCode, sendCode);
                //}
                //------ DEL 2011/11/01 ------<<<<<<
                //------ ADD 2011/11/01 ------>>>>>>
                //���o�����敪���u�����v�̏ꍇ
                if (extractCondDiv == 0)
                {
                    // ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                    if (startTime < syncExecDt)
                    {
                        // ���_�Ǘ��ݒ�}�X�^�̍X�V
                        status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDt, out retMessage, baseCode, sendCode);
                    }
                }
                // ----- ADD 2011/11/10 xupz---------->>>>>
                //���o�����敪���u�`�[���t�v�̏ꍇ
                if (extractCondDiv == 1)
                {
                    //DateTime syncExecReplDt = syncExecDt.AddDays(1).AddTicks(-1);  // DEL 2011/11/30
                    //DateTime syncExecReplDt = new DateTime(syncExecDt.Year, syncExecDt.Month, syncExecDt.Day, 23, 59, 59); // ADD 2011/11/30  // DEL 2011/12/06
                    if (updateFlg) // ADD 2011/12/07
                    {
                        if (startTime < syncExecDtTemp) // ADD 2011/12/06
                        {
                    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                            //status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecReplDt, out retMessage, baseCode, sendCode); // DEL 2011/12/06
                            status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDtTemp, out retMessage, baseCode, sendCode);// ADD 2011/12/06
                        }
                    }
                }
                // ----- ADD 2011/11/10 xupz----------<<<<<
                //------ ADD 2011/11/01 ------<<<<<<
            }
            return searchCountWork;

        }

        /// <summary>
        /// �f�[�^���M�������N���p
        /// </summary>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="startTime">�J�n����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
		/// <param name="baseCode">���_�R�[�h</param>
		/// <param name="sendCode">���_�R�[�h</param>
        /// <param name="isEmpty">�f�[�^�����邩�ǂ���</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�ɂ��A�f�[�^���M��������B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2020/09/25 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
		//public int ServsUpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty, int connectPointDiv)
        public int ServsUpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode,string sendCode, out bool isEmpty, int connectPointDiv)
        {
            string retMessage;
            isEmpty = false;
            SearchCountWork searchCountWork = new SearchCountWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            //string updSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂��� ---------->>>>>
            string updSectionCode = string.Empty;
            int ret = GetBelongSectionCodeFormXml(ref updSectionCode);
            if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return ret;
            }            
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂��� ----------<<<<<
			ArrayList sendDestEpCodeList = new ArrayList();
			EnterpriseSetAcs _enterpriseSetAcs = new EnterpriseSetAcs();
			_enterpriseSetAcs.SearchAll(out sendDestEpCodeList, enterpriseCode);
			int no;
			DateTime minSyncExecDt = new DateTime();
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // �f�[�^�X�V����
            if (connectPointDiv == 0)
            {
                if (this._idcControlDB == null)
                {
                    this._idcControlDB = MediationDCControlDB.GetDCControlDB();
                }
            }
            else
            {
                if (this._iskControlDB == null)
                {
                    this._iskControlDB = MediationSKControlDB.GetSKControlDB();
                }
            }

            // ���M�Ώۃf�[�^�̎擾����
            ArrayList sendDataList = new ArrayList();
            this.GetSecMngSendData(enterpriseCode, out sendDataList);
            if (sendDataList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            // �t�@�C��ID�z��
            string[] fileIds = new string[sendDataList.Count];
            // ADD 2009/06/23 ---->>>
            string[] fileNms = new string[sendDataList.Count];
            // ADD 2009/06/23 ----<<<
            for (int i = 0; i < sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)sendDataList[i];
                fileIds[i] = secMngSndRcv.FileId;
                // ADD 2009/06/23 ---->>>
                fileNms[i] = secMngSndRcv.FileNm;
                // ADD 2009/06/23 ----<<<
            }

            // ���o�E�X�V�R���g���[�����������[�g���Ăяo���Ē��o�f�[�^���擾���A���o���ʃN���X��Ԃ��܂��B
			//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			//int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayList(enterpriseCode, beginningTime, endingTime, ref retCSAList, fileIds, out retMessage);
			//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			APSendDataWork paraSendDataWork = new APSendDataWork();
			paraSendDataWork.EndDateTime = endingTime;
			paraSendDataWork.StartDateTime = beginningTime;
			paraSendDataWork.PmEnterpriseCode = enterpriseCode;
			paraSendDataWork.PmSectionCode = baseCode;
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            // ���M�敪�擾
            for (int i = 0; i < sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)sendDataList[i];
                fileIds[i] = secMngSndRcv.FileId;
                if (fileIds[i].Equals("SalesSlipRF"))
                {
                    //�󒍃f�[�^���M�敪
                    paraSendDataWork.AcptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                    //�ݏo�f�[�^���M�敪
                    paraSendDataWork.ShipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                    //���σf�[�^���M�敪
                    paraSendDataWork.EstimateSendDiv = secMngSndRcv.EstimateSendDiv;
                }
            }
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
			int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayListSCM(out retCSAList, paraSendDataWork, baseCode, fileIds, out retMessage, out no, updSectionCode);
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            // ���o���ʐ���̏ꍇ�A�f�[�^�ϊ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

				//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				//// -- UPD 2011/02/01 ---------------------------------------->>>
				////syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds);
				//syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//// -- UPD 2011/02/01 ----------------------------------------<<<
				//-----DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
				//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                if (isEmpty)
                {
                    // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                    // MOD 2009/06/17 ---->>>
                    // operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                    // MOD 2009/06/17 ----<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                    return status;
                }
                else
                {
                    // �f�[�^�X�V����
                    if (connectPointDiv == 0)
                    {
						// DC�X�V
						//status = _idcControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);//DEL 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j

						//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
						//����M�������O�f�[�^�̐ݒ�
						ArrayList objList = new ArrayList();
						SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
						//��ƃR�[�h:���O�C�����[�U�[�̊�ƃR�[�h
						sndRcvHisWork.EnterpriseCode = enterpriseCode;
						//�_���폜�敪
						sndRcvHisWork.LogicalDeleteCode = 0;
						//���_�R�[�h:���O�C�����[�U�[�̋��_�R�[�h
						sndRcvHisWork.SectionCode = updSectionCode;
						//����M�������O���M�ԍ�
						sndRcvHisWork.SndRcvHisConsNo = no;
						//���M����:�V�X�e�����t
						// del by ���� 2011.08.19  redmine #23692 �̑Ή� ----------->>>>>>>
						//string sdate = DateTime.Now.ToShortDateString().Replace("/", "");
						//string stime = DateTime.Now.ToShortTimeString().Replace(":", "");
						//sndRcvHisWork.SendDateTime = long.Parse(sdate) * 10000 + long.Parse(stime);
						// del by ���� 2011.08.19  redmine #23692 �̑Ή� -----------<<<<<<<
						sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));// ADD by ���� 2011.08.19 redmine #23692 �̑Ή�
						//����M���O���p�敪:�0:���_�Ǘ��
						sndRcvHisWork.SndLogUseDiv = 0;
						//����M�敪:�0:���M�
						sndRcvHisWork.SendOrReceiveDivCd = 0;
						//���:�0:�f�[�^�
						sndRcvHisWork.Kind = 0;
						//����M���O���o�����敪�u0:����(����)�v
						sndRcvHisWork.SndLogExtraCondDiv = 0;
						//���M�Ώۋ��_�R�[�h
						sndRcvHisWork.ExtraObjSecCode = baseCode;
						//���M�ΏۊJ�n�����A���M�ΏۏI������
						sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
						sndRcvHisWork.SndObjEndDate = syncExecDt;
						//���M���ƃR�[�h
						for (int i = 0; i < sendDestEpCodeList.Count; i++)
						{
							if (((EnterpriseSet)sendDestEpCodeList[i]).SectionCode.Trim().Equals(sendCode.Trim()))
							{
								sndRcvHisWork.SendDestEpCode = ((EnterpriseSet)sendDestEpCodeList[i]).PmEnterpriseCode;
								break;
							}
						}
						//���M�拒�_�R�[�h
						sndRcvHisWork.SendDestSecCode = sendCode;
						objList.Add(sndRcvHisWork);
						ArrayList paraList = new ArrayList();
						paraList.Add(objList);
						status = _idcControlDB.UpdateSCM(ref updCSAList, enterpriseCode, paraList, out retMessage);

						//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    }
                    else
                    {
                        // �W�v�@�X�V
                        status = _iskControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                    }
                }
            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                // MOD 2009/06/17 ---->>>
                // operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + baseCode.Trim() + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCode.Trim() + ")", string.Empty);
                // MOD 2009/06/17 ----<<<

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }

            // status��0����̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                // MOD 2009/06/23 ---->>>
                //foreach (string fileId in fileIds)
                for (int i = 0; i < fileIds.Length; i++)
                // MOD 2009/06/23 ----<<<
                {
                    // MOD 2009/06/23 ---->>>
                    /*
                    if (logStr == string.Empty)
                    {
                        logStr += fileId + MARK_3;
                    }
                    else
                    {
                        logStr += MARK_2 + fileId + MARK_3;
                    }
                    */
                    string fileId = fileIds[i];
                    if (!string.IsNullOrEmpty(logStr))
                    {
                        logStr += MARK_2;
                    }
                    // MOD 2009/06/23 ----<<<
                    switch (fileId)
                    {
                        // ����f�[�^
                        case "SalesSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // ���㖾�׃f�[�^
                        case "SalesDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // ���㗚���f�[�^
                        case "SalesHistoryRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistoryCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistoryCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // ���㗚�𖾍׃f�[�^
                        case "SalesHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �����f�[�^
                        case "DepsitMainRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitMainCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitMainCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �������׃f�[�^
                        case "DepsitDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d���f�[�^
                        case "StockSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d�����׃f�[�^
                        case "StockDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d�������f�[�^
                        case "StockSlipHistRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipHistCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipHistCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �d�����𖾍׃f�[�^
                        case "StockSlHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �x���`�[�}�X�^
                        case "PaymentSlpRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentSlpCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentSlpCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �x�����׃f�[�^
                        case "PaymentDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �󒍃}�X�^
                        case "AcceptOdrRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �󒍃}�X�^�i�ԗ��j
                        case "AcceptOdrCarRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            // MOD 2009/06/23 ----<<<
							break;
						// DEL 2011.08.19 ------->>>>>
						//// ���㌎���W�v�f�[�^
						//case "MTtlSalesSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// ���i�ʔ��㌎���W�v�f�[�^
						//case "GoodsMTtlSaSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// �d�������W�v�f�[�^
						//case "MTtlStockSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
                        // �݌ɒ����f�[�^
                        case "StockAdjustRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �݌ɒ������׃f�[�^
                        case "StockAdjustDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // �݌Ɉړ��f�[�^
                        case "StockMoveRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockMoveCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockMoveCount);
                            // MOD 2009/06/23 ----<<<
							break;
						// DEL 2011.08.19 ------->>>>>
						//// �݌Ɏ󕥗����f�[�^
						//case "StockAcPayHistRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
						//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
						// ���������}�X�^
						case "DepositAlwRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepositAlwCount);
							break;
						// ����`�}�X�^
						case "RcvDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.RcvDraftDataCount);
							break;
						// ����`�}�X�^
						case "PayDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PayDraftDataCount);
							break;
						//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    }
                }

                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                   logStr, "����(���_�F" + baseCode.Trim() + ")");

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                // MOD 2009/06/17 ---->>>
                // operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCode.Trim() + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCode.Trim() + ")", string.Empty);
                // MOD 2009/06/17 ----<<<

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            // ���_�Ǘ��ݒ�}�X�^�̍X�V
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                if (startTime < syncExecDt)
                {
                    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                    status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDt, out retMessage, baseCode, sendCode);
                }
            }
            return status;
        }

        /// <summary>
        /// �����_�R�[�h���擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>		
        /// <br>Note		: �����_�R�[�h�擾�������s���B</br>
        /// <br>Programmer	: ������</br>	
        /// <br>Date		: 2011.09.01</br>
        /// </remarks>
        private int GetBelongSectionCodeFormXml(ref string belongSectionCode)
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ServiceFilesInputAcs sfInputAcs = ServiceFilesInputAcs.GetInstance();
            string msg = string.Empty;
            int flg = 0;
            stauts = sfInputAcs.SearchForAutoSendRecv(ref msg, ref flg);
            if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                belongSectionCode = sfInputAcs.SecInfo.SecInfo.Rows[0][0].ToString();
            }
            return stauts;
        }
        /// <summary>
        /// ���������t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���������t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + COUNTNAME;
            }
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            return searchCountStr;
        }

        # endregion �� �f�[�^���M���� ��

        # region �� �f�[�^�ϊ����� ��
        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="updCSAList">�X�V�f�[�^</param>
        /// <param name="searchCountWork">�X�V�����I�u�W�F�N�g</param>
        /// <param name="isEmpty">�f�[�^�����邩�ǂ���</param>
        /// <param name="retCSAList">���o�f�[�^</param>
		/// <param name="fileIds">�t�@�C��ID�z��</param>
		/// <param name="beginningTime">beginningTime</param>
		/// <param name="endingTime">endingTime</param>
		/// <param name="syncExecDt">syncExecDt</param>
		/// <param name="minSyncExecDt">minSyncExecDt</param>
        /// <remarks>		
        /// <br>Note		: �f�[�^�ϊ��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        // -- UPD 2011/02/01 ------------------------------------------------>>>
        //private DateTime DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out SearchCountWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList, string[] fileIds)
		//private DateTime DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out SearchCountWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList, string[] fileIds, Int64 beginningTime, Int64 endingTime)
        // -- UPD 2011/02/01 ------------------------------------------------<<<
		private void DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out SearchCountWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList, string[] fileIds, Int64 beginningTime, Int64 endingTime, out DateTime syncExecDt, out DateTime minSyncExecDt)
        {
            // ����f�[�^
            ArrayList dcSalesSlipList = new ArrayList();                       
            Int32 salesSlipCount = 0;
            // ���㖾�׃f�[�^
            ArrayList dcSalesDetailList = new ArrayList();
            Int32 salesDetailCount = 0;
            // ���㗚���f�[�^
            ArrayList dcSalesHistoryList = new ArrayList();
            Int32 salesHistoryCount = 0;
            // ���㗚�𖾍׃f�[�^
            ArrayList dcSalesHistDtlList = new ArrayList();
            Int32 salesHistDtlCount = 0;
            // �����f�[�^   
            ArrayList dcDepsitMainList = new ArrayList();
            Int32 depsitMainCount = 0;
            // �������׃f�[�^         
            ArrayList dcDepsitDtlList = new ArrayList();
            Int32 depsitDtlCount = 0;
            // �d���f�[�^           
            ArrayList dcStockSlipList = new ArrayList();
            Int32 stockSlipCount = 0;
            // �d�����׃f�[�^           
            ArrayList dcStockDetailList = new ArrayList();
            Int32 stockDetailCount = 0;
            // �d�������f�[�^        
            ArrayList dcStockSlipHistList = new ArrayList();
            Int32 stockSlipHistCount = 0;
            // �d�����𖾍׃f�[�^      
            ArrayList dcStockSlHistDtlList = new ArrayList();
            Int32 stockSlHistDtlCount = 0;
            // �x���`�[�}�X�^     
            ArrayList dcPaymentSlpList = new ArrayList();
            Int32 paymentSlpCount = 0;
            // �x�����׃f�[�^          
            ArrayList dcPaymentDtlList = new ArrayList();
            Int32 paymentDtlCount = 0;
            // �󒍃}�X�^         
            ArrayList dcAcceptOdrList = new ArrayList();
            Int32 acceptOdrCount = 0;
            // �󒍃}�X�^�i�ԗ��j          
            ArrayList dcAcceptOdrCarList = new ArrayList();
			Int32 acceptOdrCarCount = 0;
			// DEL 2011.08.19 ------->>>>>
			//// ���㌎���W�v�f�[�^        
			//ArrayList dcMTtlSalesSlipList = new ArrayList();
			//Int32 mTtlSalesSlipCount = 0;
			//// ���i�ʔ��㌎���W�v�f�[�^       
			//ArrayList dcGoodsMTtlSaSlipList = new ArrayList();
			//Int32 goodsMTtlSaSlipCount = 0;
			//// �d�������W�v�f�[�^
			//ArrayList dcMTtlStockSlipList = new ArrayList();
			//Int32 mTtlStockSlipCount = 0;
			// DEL 2011.08.19 -------<<<<<
            // �݌ɒ����f�[�^
            ArrayList dcStockAdjustList = new ArrayList();
            Int32 stockAdjustCount = 0;
            // �݌ɒ������׃f�[�^
            ArrayList dcStockAdjustDtlList = new ArrayList();
            Int32 stockAdjustDtlCount = 0;
            // �݌Ɉړ��f�[�^
            ArrayList dcStockMoveList = new ArrayList();
            Int32 stockMoveCount = 0;
			// DEL 2011.08.19 ------->>>>>
			//// �݌Ɏ󕥗����f�[�^
			//ArrayList dcStockAcPayHistList = new ArrayList();
			//Int32 stockAcPayHistCount = 0;
			// DEL 2011.08.19 -------<<<<<

			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			// ���������}�X�^
			ArrayList dcDepositAlwList = new ArrayList();
			Int32 depositAlwCount = 0;
			// ����`�f�[�^
			ArrayList dcRcvDraftDataList = new ArrayList();
			Int32 rcvDraftDataCount = 0;
			// �x����`�f�[�^
			ArrayList dcPayDraftDataList = new ArrayList();
			Int32 payDraftDataCount = 0;

			syncExecDt = new DateTime();
            minSyncExecDt = System.DateTime.Now;
			//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            updCSAList = new CustomSerializeArrayList();
            searchCountWork = new SearchCountWork();
			//DateTime syncExecDt = new DateTime(); //DEL 2011/07/25
			
            isEmpty = true;

            //���p�����[�^�`�F�b�N
            if (retCSAList == null || retCSAList.Count <= 0)
            {
				//return syncExecDt; //DEL 2011/07/25
				return; //ADD 2011/07/25
            }

            for (int i = 0; i < retCSAList.Count; i++)
            {
                ArrayList retCSATemList = (ArrayList)retCSAList[i];
                for (int j = 0; j < retCSATemList.Count; j++)
                {
                    isEmpty = false;

                    Type wktype = retCSATemList[j].GetType();

                    // DC����f�[�^�ϊ�����
                    if (wktype.Equals(typeof(APSalesSlipWork)))
                    {
                        APSalesSlipWork salesSlipWork = (APSalesSlipWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (salesSlipWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = salesSlipWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (salesSlipWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesSlipWork.UpdateDateTime;
                        //}
						//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (salesSlipWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = salesSlipWork.UpdateDateTime;
                            }
                            if (salesSlipWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesSlipWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (salesSlipWork.SalesDate > syncExecDt)
                        //    {
                        //        syncExecDt = salesSlipWork.SalesDate;
                        //    }
                        //    if (salesSlipWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesSlipWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesSlipWork dcSalesSlipWork = ConvertReceive.SearchDataFromUpdateData(salesSlipWork);
                        dcSalesSlipList.Add(dcSalesSlipWork);
                        salesSlipCount++;

                    }
                    // DC���㖾�׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APSalesDetailWork)))
                    {
                        APSalesDetailWork salesDetailWork = (APSalesDetailWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //// -- UPD 2011/02/01 -------------------------------->>>
                        ////if (salesDetailWork.UpdateDateTime > syncExecDt)
                        //if ((salesDetailWork.UpdateDateTime > syncExecDt) && (salesDetailWork.UpdateDateTime.Ticks > beginningTime && salesDetailWork.UpdateDateTime.Ticks <= endingTime))
                        //// -- UPD 2011/02/01 --------------------------------<<<
                        //{
                        //    syncExecDt = salesDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (salesDetailWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if ((salesDetailWork.UpdateDateTime > syncExecDt) && (salesDetailWork.UpdateDateTime.Ticks > beginningTime && salesDetailWork.UpdateDateTime.Ticks <= endingTime))
                            {
                                syncExecDt = salesDetailWork.UpdateDateTime;
                            }
                            if (salesDetailWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesDetailWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if ((salesDetailWork.SalesDate > syncExecDt))
                        //    {
                        //        syncExecDt = salesDetailWork.SalesDate;
                        //    }
                        //    if (salesDetailWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesDetailWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesDetailWork dcSalesDetailWork = ConvertReceive.SearchDataFromUpdateData(salesDetailWork);
                        dcSalesDetailList.Add(dcSalesDetailWork);
                        salesDetailCount++;
                    }
                    // DC���㗚���f�[�^�X�V����
                    else if (wktype.Equals(typeof(APSalesHistoryWork)))
                    {
                        APSalesHistoryWork salesHistoryWork = (APSalesHistoryWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A

                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (salesHistoryWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = salesHistoryWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (salesHistoryWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesHistoryWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                       
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (salesHistoryWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = salesHistoryWork.UpdateDateTime;
                            }
                            if (salesHistoryWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesHistoryWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (salesHistoryWork.SalesDate > syncExecDt)
                        //    {
                        //        syncExecDt = salesHistoryWork.SalesDate;
                        //    }
                        //    if (salesHistoryWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesHistoryWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesHistoryWork dcSalesHistoryWork = ConvertReceive.SearchDataFromUpdateData(salesHistoryWork);
                        dcSalesHistoryList.Add(dcSalesHistoryWork);
                        salesHistoryCount++;
                    }
                    // DC���㗚�𖾍׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APSalesHistDtlWork)))
                    {
                        APSalesHistDtlWork salesHistDtlWork = (APSalesHistDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (salesHistDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = salesHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (salesHistDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (salesHistDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = salesHistDtlWork.UpdateDateTime;
                            }
                            if (salesHistDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesHistDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (salesHistDtlWork.SalesDate > syncExecDt)
                        //    {
                        //        syncExecDt = salesHistDtlWork.SalesDate;
                        //    }
                        //    if (salesHistDtlWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesHistDtlWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesHistDtlWork dcSalesHistDtlWork = ConvertReceive.SearchDataFromUpdateData(salesHistDtlWork);
                        dcSalesHistDtlList.Add(dcSalesHistDtlWork);
                        salesHistDtlCount++;
                    }
                    // DC�����f�[�^�X�V����
                    else if (wktype.Equals(typeof(APDepsitMainWork)))
                    {
                        APDepsitMainWork depsitMainWork = (APDepsitMainWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (depsitMainWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = depsitMainWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (depsitMainWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = depsitMainWork.UpdateDateTime;
                        //}
                        //-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (depsitMainWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = depsitMainWork.UpdateDateTime;
                            }
                            if (depsitMainWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = depsitMainWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (depsitMainWork.DepositDate > syncExecDt)
                        //    {
                        //        syncExecDt = depsitMainWork.DepositDate;
                        //    }
                        //    if (depsitMainWork.DepositDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = depsitMainWork.DepositDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCDepsitMainWork dcDepsitMainWork = ConvertReceive.SearchDataFromUpdateData(depsitMainWork);
                        dcDepsitMainList.Add(dcDepsitMainWork);
                        depsitMainCount++;
                    }
                    // DC�������׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APDepsitDtlWork)))
                    {
                        APDepsitDtlWork depsitDtlWork = (APDepsitDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (depsitDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = depsitDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (depsitDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = depsitDtlWork.UpdateDateTime;
                        //}
                        //-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (depsitDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = depsitDtlWork.UpdateDateTime;
                            }
                            if (depsitDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = depsitDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCDepsitDtlWork dcDepsitDtlWork = ConvertReceive.SearchDataFromUpdateData(depsitDtlWork);
                        dcDepsitDtlList.Add(dcDepsitDtlWork);
                        depsitDtlCount++;
                    }
                    // DC�d���f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockSlipWork)))
                    {
                        APStockSlipWork stockSlipWork = (APStockSlipWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockSlipWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockSlipWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockSlipWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockSlipWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockSlipWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockSlipWork.UpdateDateTime;
                            }
                            if (stockSlipWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockSlipWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (stockSlipWork.StockDate > syncExecDt)
                        //    {
                        //        syncExecDt = stockSlipWork.StockDate;
                        //    }
                        //    if (stockSlipWork.StockDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = stockSlipWork.StockDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCStockSlipWork dcStockSlipWork = ConvertReceive.SearchDataFromUpdateData(stockSlipWork);
                        dcStockSlipList.Add(dcStockSlipWork);
                        stockSlipCount++;
                    }
                    // DC�d�����׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockDetailWork)))
                    {
                        APStockDetailWork stockDetailWork = (APStockDetailWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockDetailWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockDetailWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockDetailWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockDetailWork.UpdateDateTime;
                            }
                            if (stockDetailWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockDetailWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCStockDetailWork dcStockDetailWork = ConvertReceive.SearchDataFromUpdateData(stockDetailWork);
                        dcStockDetailList.Add(dcStockDetailWork);
                        stockDetailCount++;
                    }
                    // DC�d�������f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockSlipHistWork)))
                    {
                        APStockSlipHistWork stockSlipHistWork = (APStockSlipHistWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockSlipHistWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockSlipHistWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockSlipHistWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockSlipHistWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockSlipHistWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockSlipHistWork.UpdateDateTime;
                            }
                            if (stockSlipHistWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockSlipHistWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (stockSlipHistWork.StockDate > syncExecDt)
                        //    {
                        //        syncExecDt = stockSlipHistWork.StockDate;
                        //    }
                        //    if (stockSlipHistWork.StockDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = stockSlipHistWork.StockDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockSlipHistWork dcStockSlipHistWork = ConvertReceive.SearchDataFromUpdateData(stockSlipHistWork);
                        dcStockSlipHistList.Add(dcStockSlipHistWork);
                        stockSlipHistCount++;
                    }
                    // DC�d�����𖾍׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockSlHistDtlWork)))
                    {
                        APStockSlHistDtlWork stockSlHistDtlWork = (APStockSlHistDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockSlHistDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockSlHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockSlHistDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockSlHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockSlHistDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockSlHistDtlWork.UpdateDateTime;
                            }
                            if (stockSlHistDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockSlHistDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockSlHistDtlWork dcStockSlHistDtlWork = ConvertReceive.SearchDataFromUpdateData(stockSlHistDtlWork);
                        dcStockSlHistDtlList.Add(dcStockSlHistDtlWork);
                        stockSlHistDtlCount++;
                    }
                    // DC�x���`�[�}�X�^�X�V����
                    else if (wktype.Equals(typeof(APPaymentSlpWork)))
                    {
                        APPaymentSlpWork paymentSlpWork = (APPaymentSlpWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (paymentSlpWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = paymentSlpWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (paymentSlpWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = paymentSlpWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (paymentSlpWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = paymentSlpWork.UpdateDateTime;
                            }
                            if (paymentSlpWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = paymentSlpWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (paymentSlpWork.PaymentDate > syncExecDt)
                        //    {
                        //        syncExecDt = paymentSlpWork.PaymentDate;
                        //    }
                        //    if (paymentSlpWork.PaymentDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = paymentSlpWork.PaymentDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        
                        DCPaymentSlpWork dcPaymentSlpWork = ConvertReceive.SearchDataFromUpdateData(paymentSlpWork);
                        dcPaymentSlpList.Add(dcPaymentSlpWork);
                        paymentSlpCount++;
                    }
                    // DC�x�����׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APPaymentDtlWork)))
                    {
                        APPaymentDtlWork paymentDtlWork = (APPaymentDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (paymentDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = paymentDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (paymentDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = paymentDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (paymentDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = paymentDtlWork.UpdateDateTime;
                            }
                            if (paymentDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = paymentDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCPaymentDtlWork dcPaymentDtlWork = ConvertReceive.SearchDataFromUpdateData(paymentDtlWork);
                        dcPaymentDtlList.Add(dcPaymentDtlWork);
                        paymentDtlCount++;
                    }
                    // DC�󒍃}�X�^�X�V����
                    else if (wktype.Equals(typeof(APAcceptOdrWork)))
                    {
                        APAcceptOdrWork acceptOdrWork = (APAcceptOdrWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (acceptOdrWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = acceptOdrWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (acceptOdrWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = acceptOdrWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (acceptOdrWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = acceptOdrWork.UpdateDateTime;
                            }
                            if (acceptOdrWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = acceptOdrWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                     
                        DCAcceptOdrWork dcAcceptOdrWork = ConvertReceive.SearchDataFromUpdateData(acceptOdrWork);
                        dcAcceptOdrList.Add(dcAcceptOdrWork);
                        acceptOdrCount++;
                    }
                    // DC�󒍃}�X�^�i�ԗ��j�X�V����
                    else if (wktype.Equals(typeof(APAcceptOdrCarWork)))
                    {
                        APAcceptOdrCarWork acceptOdrCarWork = (APAcceptOdrCarWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (acceptOdrCarWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = acceptOdrCarWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (acceptOdrCarWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = acceptOdrCarWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                         if (this._extractCondDiv == 0)
                        {
                            if (acceptOdrCarWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = acceptOdrCarWork.UpdateDateTime;
                            }
                            if (acceptOdrCarWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = acceptOdrCarWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCAcceptOdrCarWork dcAcceptOdrCarWork = ConvertReceive.SearchDataFromUpdateData(acceptOdrCarWork);
                        dcAcceptOdrCarList.Add(dcAcceptOdrCarWork);
                        acceptOdrCarCount++;
					}
					// DEL 2011.08.19 ------->>>>>
					//// DC���㌎���W�v�f�[�^�X�V����
					//else if (wktype.Equals(typeof(APMTtlSalesSlipWork)))
					//{
					//    APMTtlSalesSlipWork mTtlSalesSlipWork = (APMTtlSalesSlipWork)retCSATemList[j];
					//    // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
					//    if (mTtlSalesSlipWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = mTtlSalesSlipWork.UpdateDateTime;
					//    }
					//    DCMTtlSalesSlipWork dcMTtlSalesSlipWork = ConvertReceive.SearchDataFromUpdateData(mTtlSalesSlipWork);
					//    dcMTtlSalesSlipList.Add(dcMTtlSalesSlipWork);
					//    mTtlSalesSlipCount++;
					//}
					//// DC���i�ʔ��㌎���W�v�f�[�^�X�V����
					//else if (wktype.Equals(typeof(APGoodsMTtlSaSlipWork)))
					//{
					//    APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork = (APGoodsMTtlSaSlipWork)retCSATemList[j];
					//    // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
					//    if (goodsMTtlSaSlipWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = goodsMTtlSaSlipWork.UpdateDateTime;
					//    }
					//    DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork = ConvertReceive.SearchDataFromUpdateData(goodsMTtlSaSlipWork);
					//    dcGoodsMTtlSaSlipList.Add(dcGoodsMTtlSaSlipWork);
					//    goodsMTtlSaSlipCount++;
					//}
					//// DC�d�������W�v�f�[�^�X�V����
					//else if (wktype.Equals(typeof(APMTtlStockSlipWork)))
					//{
					//    APMTtlStockSlipWork mTtlStockSlipWork = (APMTtlStockSlipWork)retCSATemList[j];
					//    // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
					//    if (mTtlStockSlipWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = mTtlStockSlipWork.UpdateDateTime;
					//    }
					//    DCMTtlStockSlipWork dcMTtlStockSlipWork = ConvertReceive.SearchDataFromUpdateData(mTtlStockSlipWork);
					//    dcMTtlStockSlipList.Add(dcMTtlStockSlipWork);
					//    mTtlStockSlipCount++;
					//}
					// DEL 2011.08.19 -------<<<<<
                    // DC�݌ɒ����f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockAdjustWork)))
                    {
                        APStockAdjustWork stockAdjustWork = (APStockAdjustWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>  
                        //if (stockAdjustWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockAdjustWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockAdjustWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockAdjustWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockAdjustWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockAdjustWork.UpdateDateTime;
                            }
                            if (stockAdjustWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockAdjustWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime adjustDate = new DateTime(int.Parse(stockAdjustWork.AdjustDate.ToString().Substring(0, 4)), int.Parse(stockAdjustWork.AdjustDate.ToString().Substring(4, 2)), int.Parse(stockAdjustWork.AdjustDate.ToString().Substring(6, 2)));
                        //    if (adjustDate > syncExecDt)
                        //    {
                        //        syncExecDt = adjustDate;
                        //    }
                        //    if (adjustDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = adjustDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCStockAdjustWork dcStockAdjustWork = ConvertReceive.SearchDataFromUpdateData(stockAdjustWork);
                        dcStockAdjustList.Add(dcStockAdjustWork);
                        stockAdjustCount++;
                    }
                    // DC�݌ɒ������׃f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockAdjustDtlWork)))
                    {
                        APStockAdjustDtlWork stockAdjustDtl = (APStockAdjustDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockAdjustDtl.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockAdjustDtl.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockAdjustDtl.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockAdjustDtl.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockAdjustDtl.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockAdjustDtl.UpdateDateTime;
                            }
                            if (stockAdjustDtl.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockAdjustDtl.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime adjustDate = new DateTime(int.Parse(stockAdjustDtl.AdjustDate.ToString().Substring(0, 4)), int.Parse(stockAdjustDtl.AdjustDate.ToString().Substring(4, 2)), int.Parse(stockAdjustDtl.AdjustDate.ToString().Substring(6, 2)));
                        //    if (adjustDate > syncExecDt)
                        //    {
                        //        syncExecDt = adjustDate;
                        //    }
                        //    if (adjustDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = adjustDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockAdjustDtlWork dcStockAdjustDtlWork = ConvertReceive.SearchDataFromUpdateData(stockAdjustDtl);
                        dcStockAdjustDtlList.Add(dcStockAdjustDtlWork);
                        stockAdjustDtlCount++;
                    }
                    // DC�݌Ɉړ��f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockMoveWork)))
                    {
                        APStockMoveWork stockMoveWork = (APStockMoveWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockMoveWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockMoveWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (stockMoveWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockMoveWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockMoveWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockMoveWork.UpdateDateTime;
                            }
                            if (stockMoveWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockMoveWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime arrivalGoodsDay = new DateTime(int.Parse(stockMoveWork.ArrivalGoodsDay.ToString().Substring(0, 4)), int.Parse(stockMoveWork.ArrivalGoodsDay.ToString().Substring(4, 2)), int.Parse(stockMoveWork.ArrivalGoodsDay.ToString().Substring(6, 2)));
                        //    if (arrivalGoodsDay > syncExecDt)
                        //    {
                        //        syncExecDt = arrivalGoodsDay;
                        //    }
                        //    if (arrivalGoodsDay < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = arrivalGoodsDay;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockMoveWork dcStockMoveWork = ConvertReceive.SearchDataFromUpdateData(stockMoveWork);
                        dcStockMoveList.Add(dcStockMoveWork);
                        stockMoveCount++;
					}
					// DEL 2011.08.19 ------->>>>>
					//// DC�݌Ɏ󕥗����f�[�^�X�V����
					//else if (wktype.Equals(typeof(APStockAcPayHistWork)))
					//{
					//    APStockAcPayHistWork stockAcPayHisWork = (APStockAcPayHistWork)retCSATemList[j];
					//    // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
					//    if (stockAcPayHisWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = stockAcPayHisWork.UpdateDateTime;
					//    }
					//    //-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
					//    if (stockAcPayHisWork.UpdateDateTime < minSyncExecDt)
					//    {
					//        minSyncExecDt = stockAcPayHisWork.UpdateDateTime;
					//    }
					//    //-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
					//    DCStockAcPayHistWork dcStockAcPayHisWork = ConvertReceive.SearchDataFromUpdateData(stockAcPayHisWork);
					//    dcStockAcPayHistList.Add(dcStockAcPayHisWork);
					//    stockAcPayHistCount++;
					//}
					// DEL 2011.08.19 -------<<<<<
					//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
					// ���������}�X�^
					else if (wktype.Equals(typeof(APDepositAlwWork)))
                    {
						APDepositAlwWork depositAlwWork = (APDepositAlwWork)retCSATemList[j];
						// �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (depositAlwWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = depositAlwWork.UpdateDateTime;
                        //}
                        //if (depositAlwWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = depositAlwWork.UpdateDateTime;
                        //}
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (depositAlwWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = depositAlwWork.UpdateDateTime;
                            }
                            if (depositAlwWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = depositAlwWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime reconcileDate = new DateTime(int.Parse(depositAlwWork.ReconcileDate.ToString().Substring(0, 4)), int.Parse(depositAlwWork.ReconcileDate.ToString().Substring(4, 2)), int.Parse(depositAlwWork.ReconcileDate.ToString().Substring(6, 2)));
                        //    if (reconcileDate > syncExecDt)
                        //    {
                        //        syncExecDt = reconcileDate;
                        //    }
                        //    if (reconcileDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = reconcileDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
					
						DCDepositAlwWork dcDepositAlwWork = ConvertReceive.SearchDataFromUpdateData(depositAlwWork);
						dcDepositAlwList.Add(dcDepositAlwWork);
						depositAlwCount++;
                    }
					// ����`�f�[�^
					else if (wktype.Equals(typeof(APRcvDraftDataWork)))
					{
						APRcvDraftDataWork rcvDraftDataWork = (APRcvDraftDataWork)retCSATemList[j];
						// �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (rcvDraftDataWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = rcvDraftDataWork.UpdateDateTime;
                        //}
                        //if (rcvDraftDataWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = rcvDraftDataWork.UpdateDateTime;
                        //}
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (rcvDraftDataWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = rcvDraftDataWork.UpdateDateTime;
                            }
                            if (rcvDraftDataWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = rcvDraftDataWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime depositDate = new DateTime(int.Parse(rcvDraftDataWork.DepositDate.ToString().Substring(0, 4)), int.Parse(rcvDraftDataWork.DepositDate.ToString().Substring(4, 2)), int.Parse(rcvDraftDataWork.DepositDate.ToString().Substring(6, 2)));
                        //    if (depositDate > syncExecDt)
                        //    {
                        //        syncExecDt = depositDate;
                        //    }
                        //    if (depositDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = depositDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
					
						DCRcvDraftDataWork dcRcvDraftDataWork = ConvertReceive.SearchDataFromUpdateData(rcvDraftDataWork);
						dcRcvDraftDataList.Add(dcRcvDraftDataWork);
						rcvDraftDataCount++;
					}
					// �x����`�f�[�^
					else if (wktype.Equals(typeof(APPayDraftDataWork)))
					{
						APPayDraftDataWork payDraftDataWork = (APPayDraftDataWork)retCSATemList[j];
						// �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (payDraftDataWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = payDraftDataWork.UpdateDateTime;
                        //}
                        //if (payDraftDataWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = payDraftDataWork.UpdateDateTime;
                        //}
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (payDraftDataWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = payDraftDataWork.UpdateDateTime;
                            }
                            if (payDraftDataWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = payDraftDataWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime paymentDate = new DateTime(int.Parse(payDraftDataWork.PaymentDate.ToString().Substring(0, 4)), int.Parse(payDraftDataWork.PaymentDate.ToString().Substring(4, 2)), int.Parse(payDraftDataWork.PaymentDate.ToString().Substring(6, 2)));
                        //    if (paymentDate > syncExecDt)
                        //    {
                        //        syncExecDt = paymentDate;
                        //    }
                        //    if (paymentDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = paymentDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
						
						DCPayDraftDataWork dcPayDraftDataWork = ConvertReceive.SearchDataFromUpdateData(payDraftDataWork);
						dcPayDraftDataList.Add(dcPayDraftDataWork);
						payDraftDataCount++;
					}
					//-----ADD 2011/07/25 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                }
            }
            // ----- DEL 2011/11/01 xupz---------->>>>>
            //// ADD 2011.09.14 ---------->>>>>
            //if (syncExecDt.Ticks > endingTime)
            //{
            //    syncExecDt = new DateTime(endingTime);
            //}

            //if (minSyncExecDt.Ticks < beginningTime)
            //{
            //    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
            //}
            //// ADD 2011.09.14 ----------<<<<<
            // ----- DEL 2011/11/01 xupz----------<<<<<
            // ----- ADD 2011/11/01 xupz---------->>>>>
            if (this._extractCondDiv == 0)
            {
                if (syncExecDt.Ticks > endingTime)
                {
                    syncExecDt = new DateTime(endingTime);
                }
                if (minSyncExecDt.Ticks < beginningTime)
                {
                    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
                }
            }
            // ----- ADD 2011/11/10 xupz---------->>>>>
            if (this._extractCondDiv == 1)
            {
                DateTime startTime = new DateTime(int.Parse(beginningTime.ToString().Substring(0, 4)), int.Parse(beginningTime.ToString().Substring(4, 2)), int.Parse(beginningTime.ToString().Substring(6, 2)));
                DateTime endTime = new DateTime(int.Parse(endingTime.ToString().Substring(0, 4)), int.Parse(endingTime.ToString().Substring(4, 2)), int.Parse(endingTime.ToString().Substring(6, 2)));

                syncExecDt = endTime;
                minSyncExecDt = startTime;
            }
            // ----- ADD 2011/11/10 xupz----------<<<<<
            // ----- ADD 2011/11/01 xupz----------<<<<<

            foreach (string fileId in fileIds)
            {
                switch (fileId)
				{
					# region [DEL]
					//// ����f�[�^
					//case "SalesSlipRF":
					//    // ����f�[�^
					//    updCSAList.Add(dcSalesSlipList);
					//    searchCountWork.SalesSlipCount = salesSlipCount;
					//    break;
					//// ���㖾�׃f�[�^
					//case "SalesDetailRF":
					//    // ���㖾�׃f�[�^
					//    updCSAList.Add(dcSalesDetailList);
					//    searchCountWork.SalesDetailCount = salesDetailCount;
					//    break;
					//// ���㗚���f�[�^
					//case "SalesHistoryRF":
					//    // ���㗚���f�[�^
					//    updCSAList.Add(dcSalesHistoryList);
					//    searchCountWork.SalesHistoryCount = salesHistoryCount;
					//    break;
					//// ���㗚�𖾍׃f�[�^
					//case "SalesHistDtlRF":
					//    // ���㗚�𖾍׃f�[�^
					//    updCSAList.Add(dcSalesHistDtlList);
					//    searchCountWork.SalesHistDtlCount = salesHistDtlCount;
					//    break;
					//// �����f�[�^
					//case "DepsitMainRF":
					//    // �����f�[�^
					//    updCSAList.Add(dcDepsitMainList);
					//    searchCountWork.DepsitMainCount = depsitMainCount;
					//    break;
					//// �������׃f�[�^
					//case "DepsitDtlRF":
					//    // �������׃f�[�^
					//    updCSAList.Add(dcDepsitDtlList);
					//    searchCountWork.DepsitDtlCount = depsitDtlCount;
					//    break;
					//// �d���f�[�^
					//case "StockSlipRF":
					//    // �d���f�[�^
					//    updCSAList.Add(dcStockSlipList);
					//    searchCountWork.StockSlipCount = stockSlipCount;
					//    break;
					//// �d�����׃f�[�^
					//case "StockDetailRF":
					//    // �d�����׃f�[�^
					//    updCSAList.Add(dcStockDetailList);
					//    searchCountWork.StockDetailCount = stockDetailCount;
					//    break;
					//// �d�������f�[�^
					//case "StockSlipHistRF":
					//    // �d�������f�[�^
					//    updCSAList.Add(dcStockSlipHistList);
					//    searchCountWork.StockSlipHistCount = stockSlipHistCount;
					//    break;
					//// �d�����𖾍׃f�[�^
					//case "StockSlHistDtlRF":
					//    // �d�����𖾍׃f�[�^
					//    updCSAList.Add(dcStockSlHistDtlList);
					//    searchCountWork.StockSlHistDtlCount = stockSlHistDtlCount;
					//    break;
					//// �x���`�[�}�X�^
					//case "PaymentSlpRF":
					//    // �x���`�[�}�X�^
					//    updCSAList.Add(dcPaymentSlpList);
					//    searchCountWork.PaymentSlpCount = paymentSlpCount;
					//    break;
					//// �x�����׃f�[�^
					//case "PaymentDtlRF":
					//    // �x�����׃f�[�^
					//    updCSAList.Add(dcPaymentDtlList);
					//    searchCountWork.PaymentDtlCount = paymentDtlCount;
					//    break;
					//// �󒍃}�X�^
					//case "AcceptOdrRF":
					//    // �󒍃}�X�^
					//    updCSAList.Add(dcAcceptOdrList);
					//    searchCountWork.AcceptOdrCount = acceptOdrCount;
					//    break;
					//// �󒍃}�X�^�i�ԗ��j
					//case "AcceptOdrCarRF":
					//    // �󒍃}�X�^�i�ԗ��j
					//    updCSAList.Add(dcAcceptOdrCarList);
					//    searchCountWork.AcceptOdrCarCount = acceptOdrCarCount;
					//    break;
					//// ���㌎���W�v�f�[�^
					//case "MTtlSalesSlipRF":
					//    // ���㌎���W�v�f�[�^
					//    updCSAList.Add(dcMTtlSalesSlipList);
					//    searchCountWork.MTtlSalesSlipCount = mTtlSalesSlipCount;
					//    break;
					//// ���i�ʔ��㌎���W�v�f�[�^
					//case "GoodsMTtlSaSlipRF":
					//    // ���i�ʔ��㌎���W�v�f�[�^
					//    updCSAList.Add(dcGoodsMTtlSaSlipList);
					//    searchCountWork.GoodsMTtlSaSlipCount = goodsMTtlSaSlipCount;
					//    break;
					//// �d�������W�v�f�[�^
					//case "MTtlStockSlipRF":
					//    // �d�������W�v�f�[�^
					//    updCSAList.Add(dcMTtlStockSlipList);
					//    searchCountWork.MTtlStockSlipCount = mTtlStockSlipCount;
					//    break;
					//// �݌ɒ����f�[�^
					//case "StockAdjustRF":
					//    // �݌ɒ����f�[�^
					//    updCSAList.Add(dcStockAdjustList);
					//    searchCountWork.StockAdjustCount = stockAdjustCount;
					//    break;
					//// �݌ɒ������׃f�[�^
					//case "StockAdjustDtlRF":
					//    // �݌ɒ������׃f�[�^
					//    updCSAList.Add(dcStockAdjustDtlList);
					//    searchCountWork.StockAdjustDtlCount = stockAdjustDtlCount;
					//    break;
					//// �݌Ɉړ��f�[�^
					//case "StockMoveRF":
					//    // �݌Ɉړ��f�[�^
					//    updCSAList.Add(dcStockMoveList);
					//    searchCountWork.StockMoveCount = stockMoveCount;
					//    break;
					//// �݌Ɏ󕥗����f�[�^
					//case "StockAcPayHistRF":
					//    // �݌Ɏ󕥗����f�[�^
					//    updCSAList.Add(dcStockAcPayHistList);
					//    searchCountWork.StockAcPayHistCount = stockAcPayHistCount;
					//    break;
					# endregion
					// ����f�[�^
					case "SalesSlipRF":
						// ����f�[�^
						updCSAList.Add(dcSalesSlipList);
						searchCountWork.SalesSlipCount = salesSlipCount;
						// ���㖾�׃f�[�^
						updCSAList.Add(dcSalesDetailList);
						searchCountWork.SalesDetailCount = salesDetailCount;
						// �󒍃}�X�^
						updCSAList.Add(dcAcceptOdrList);
						searchCountWork.AcceptOdrCount = acceptOdrCount;
						// �󒍃}�X�^�i�ԗ��j
						updCSAList.Add(dcAcceptOdrCarList);
						searchCountWork.AcceptOdrCarCount = acceptOdrCarCount;
						break;
					// ���㗚���f�[�^
					case "SalesHistoryRF":
						// ���㗚���f�[�^
						updCSAList.Add(dcSalesHistoryList);
						searchCountWork.SalesHistoryCount = salesHistoryCount;
						// ���㗚�𖾍׃f�[�^
						updCSAList.Add(dcSalesHistDtlList);
						searchCountWork.SalesHistDtlCount = salesHistDtlCount;
						break;
					// �����f�[�^
					case "DepsitMainRF":
						// �����f�[�^
						updCSAList.Add(dcDepsitMainList);
						searchCountWork.DepsitMainCount = depsitMainCount;
						// �������׃f�[�^
						updCSAList.Add(dcDepsitDtlList);
						searchCountWork.DepsitDtlCount = depsitDtlCount;
						break;
					// �d���f�[�^
					case "StockSlipRF":
						// �d���f�[�^
						updCSAList.Add(dcStockSlipList);
						searchCountWork.StockSlipCount = stockSlipCount;
						// �d�����׃f�[�^
						updCSAList.Add(dcStockDetailList);
						searchCountWork.StockDetailCount = stockDetailCount;
						break;
					// �d�������f�[�^
					case "StockSlipHistRF":
						// �d�������f�[�^
						updCSAList.Add(dcStockSlipHistList);
						searchCountWork.StockSlipHistCount = stockSlipHistCount;
						// �d�����𖾍׃f�[�^
						updCSAList.Add(dcStockSlHistDtlList);
						searchCountWork.StockSlHistDtlCount = stockSlHistDtlCount;
						break;
					// �x���`�[�}�X�^
					case "PaymentSlpRF":
						// �x���`�[�}�X�^
						updCSAList.Add(dcPaymentSlpList);
						searchCountWork.PaymentSlpCount = paymentSlpCount;
						// �x�����׃f�[�^
						updCSAList.Add(dcPaymentDtlList);
						searchCountWork.PaymentDtlCount = paymentDtlCount;
						break;
					// �݌ɒ����f�[�^
					case "StockAdjustRF":
						// �݌ɒ����f�[�^
						updCSAList.Add(dcStockAdjustList);
						searchCountWork.StockAdjustCount = stockAdjustCount;
						break;
					// �݌ɒ������׃f�[�^
					case "StockAdjustDtlRF":
						// �݌ɒ������׃f�[�^
						updCSAList.Add(dcStockAdjustDtlList);
						searchCountWork.StockAdjustDtlCount = stockAdjustDtlCount;
						break;
					// �݌Ɉړ��f�[�^
					case "StockMoveRF":
						// �݌Ɉړ��f�[�^
						updCSAList.Add(dcStockMoveList);
						searchCountWork.StockMoveCount = stockMoveCount;
						break;
					// DEL 2011.08.19---------->>>>>
					//// �݌Ɏ󕥗����f�[�^
					//case "StockAcPayHistRF":
					//    // �݌Ɏ󕥗����f�[�^
					//    updCSAList.Add(dcStockAcPayHistList);
					//    searchCountWork.StockAcPayHistCount = stockAcPayHistCount;
					//    break;
					// DEL 2011.08.19----------<<<<<
					//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
					// ���������}�X�^
					case "DepositAlwRF":
						// ���������}�X�^
						updCSAList.Add(dcDepositAlwList);
						searchCountWork.DepositAlwCount = depositAlwCount;
						break;
					// ����`�f�[�^
					case "RcvDraftDataRF":
						// ����`�f�[�^
						updCSAList.Add(dcRcvDraftDataList);
						searchCountWork.RcvDraftDataCount = rcvDraftDataCount;
						break;
					// �x����`�f�[�^
					case "PayDraftDataRF":
						// �x����`�f�[�^
						updCSAList.Add(dcPayDraftDataList);
						searchCountWork.PayDraftDataCount = payDraftDataCount;
						break;
					//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                }
            }
			//return syncExecDt; 
        }
        # endregion �� �f�[�^�ϊ����� ��

        # region �� �X�V���`�F�b�N ��
        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA�X�V���`�F�b�N���s���B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="baseCode">���M�Ώۋ��_�R�[�h</param>
		/// <param name="sendCode">���M�拒�_�R�[�h</param>
        /// <param name="startDt">�J�n����</param>
        /// <returns>�V�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA�X�V���`�F�b�N���s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
		//public bool UpdateOverProc(string enterpriseCode, string baseCode, out DateTime startDt) // DEL 2011.08.25
		public bool UpdateOverProc(string enterpriseCode, string baseCode,string sendCode, out DateTime startDt)// ADD 2011.08.25
        {
            string retMessage = string.Empty;
			//bool isUpdate = true;
			bool isUpdate = false;
			startDt = new DateTime();

			// DEL 2011.08.25 ---------->>>>>>
			//APSecMngSetWork secMngSetWork = new APSecMngSetWork();
			// ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
			//int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWork, out retMessage);
			//// ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
			//if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || string.IsNullOrEmpty(secMngSetWork.SectionCode)
			//    || !secMngSetWork.SectionCode.Equals(baseCode))
			//{
			//    isUpdate = false;
			//    return isUpdate;
			//}
			//startDt = secMngSetWork.SyncExecDate;
			// DEL 2011.08.25 ----------<<<<<<

			ArrayList secMngSetWorkList = new ArrayList();
			// ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
			int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWorkList, out retMessage);

			// ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (APSecMngSetWork secMngSetWork in secMngSetWorkList)
				{
					if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
						&& sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
					{
						isUpdate = true;
						startDt = secMngSetWork.SyncExecDate;
						return isUpdate;
					}
				}
			}
			else
			{
				return isUpdate;
			}

            return isUpdate;

        }
        # endregion �� �X�V���`�F�b�N ��

        # region �� ���������� ��
        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA�������������s���B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="baseCode">���_�R�[�h</param>
		/// <param name="secMngSetWorkList">secMngSetWorkList</param>
        /// <returns>�V�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA�������������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
		public DateTime LoadProc(string enterpriseCode, out string baseCode, out ArrayList secMngSetWorkList)
        {
            string retMessage = string.Empty;
            baseCode = string.Empty;
            DateTime startDt = new DateTime();
			//APSecMngSetWork secMngSetWork = new APSecMngSetWork();
			secMngSetWorkList = new ArrayList();
            // ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
			//int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWork, out retMessage);
			int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWorkList, out retMessage);
            // ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
			//if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || string.IsNullOrEmpty(secMngSetWork.SectionCode))
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return startDt;
            }
			foreach (APSecMngSetWork secMngSetWork in secMngSetWorkList)
			{
				// �������ʂ�ݒ���s��
				ExtractionConditionDataSet.ExtractionConditionRow row = _extractionConditionDataTable.NewExtractionConditionRow();
				// ���_�R�[�h
				row.BaseCode = secMngSetWork.SectionCode;
				baseCode = secMngSetWork.SectionCode;
				// ���_����
				
				//row.BaseName = secMngSetWork.SectionGuideNm;
				row.BaseName = GetSectionName(baseCode);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				row.SendCode = secMngSetWork.SendDestSecCode;
				row.SendName = GetSectionName(secMngSetWork.SendDestSecCode);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<


				DateTime syncExecDate = secMngSetWork.SyncExecDate;
				// ���A���A�b�A2���⑫
				String syncExecDateHour = syncExecDate.Hour.ToString();
				String syncExecDateMinute = syncExecDate.Minute.ToString();
				String syncExecDateSecond = syncExecDate.Second.ToString();
				// ��2���⑫
				if (syncExecDateHour.Length == 1)
				{
					syncExecDateHour = ZERO_0 + syncExecDateHour;
				}
				// ��2���⑫
				if (syncExecDateMinute.Length == 1)
				{
					syncExecDateMinute = ZERO_0 + syncExecDateMinute;
				}
				// �b2���⑫
				if (syncExecDateSecond.Length == 1)
				{
					syncExecDateSecond = ZERO_0 + syncExecDateSecond;
				}
				// �J�n���t
				row.BeginningDate = syncExecDate;
				startDt = syncExecDate;
				// �J�n����
				row.BeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;

				// �V�X�e������
                //DateTime endDate = System.DateTime.Now; // DEL 2011/12/22 xupz for redmine#27395
                // ----- ADD 2011/12/22 xupz for redmine#27395---------->>>>>
                DateTime systemDate = System.DateTime.Now;
                DateTime endDate = systemDate.AddMinutes(-5); 
                // ----- ADD 2011/12/22 xupz for redmine#27395----------<<<<<
				String endDateHour = endDate.Hour.ToString();
				String endDateMinute = endDate.Minute.ToString();
				String endDateSecond = endDate.Second.ToString();
				// ��2���⑫
				if (endDateHour.Length == 1)
				{
					endDateHour = ZERO_0 + endDateHour;
				}
				// ��2���⑫
				if (endDateMinute.Length == 1)
				{
					endDateMinute = ZERO_0 + endDateMinute;
				}
				// �b2���⑫
				if (endDateSecond.Length == 1)
				{
					endDateSecond = ZERO_0 + endDateSecond;
				}
				// �I�����t
				row.EndDate = endDate;
				// �I������
				row.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;

				_extractionConditionDataTable.Rows.Add(row);
			}
           

            return startDt;

        }

        // Add 2011/09/06 zhujc ------------>>>>>>
        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA�������������s���B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetWorkList">secMngSetWorkList</param>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA�������������s���B</br>      
        /// <br>Programmer : ��r��</br>                                  
        /// <br>Date       : 2011.09.06</br> 
        /// </remarks>
        public int LoadProcAuto(string enterpriseCode, out ArrayList secMngSetWorkList)
        {
            string retMessage = string.Empty;
            secMngSetWorkList = new ArrayList();
            // ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
            int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWorkList, out retMessage);

            return status;
        }
        // Add 2011/09/06 zhujc ------------<<<<<<

        # endregion �� ���������� ��

        #region �� �I�t���C����ԃ`�F�b�N���� ��

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
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
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
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

        #region �� �ڑ���`�F�b�N���� ��
        /// <summary>
        /// �ڑ���`�F�b�N����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="isAutoRun">���N�����ǂ���</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڑ���`�F�b�N�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�`�F�b�N��������</returns>
        public bool CheckConnect(string enterpriseCode, bool isAutoRun, out int connectPointDiv, out string errMsg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);
            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;

                // ���N���̏ꍇ�A���W�X�g���`�F�b�N�������s��Ȃ�
                if (isAutoRun)
                {
                    return true;
                }
                else
                {
                    if (connectPointDiv == 0)
                    {
                        // �ڑ��悪�u�f�[�^�Z���^�[�v�̏ꍇ�A����Ƃ��Ė߂�B
                        retResult = true;
                    }
                    else
                    {
                        // �ڑ��悪�u�W�v�@�v�̏ꍇ
                        retResult = CheckRegistryKey(secMngConnectSt);
                        if (retResult == false)
                        {
                            errMsg = "�ڑ���̐ݒ肪�s���ł��B";
                        }
                    }
                }
            }
            else
            {
                errMsg = "�ڑ�����̎擾�����Ɏ��s���܂����B";
                retResult = false;
            }

            return retResult;
        }

        /// <summary>���W�X�g������`�F�b�N����
        /// <param name="secMngConnectSt">���_�Ǘ��ڑ���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���W�X�g������`�F�b�N�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        private bool CheckRegistryKey(SecMngConnectSt secMngConnectSt)
        {
            bool retResult = false;
            try
            {
                string rKeyName1 = rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 != null && rKey2 != null)
                {
                    // ���W�X�g���捞
                    string apServerIpAddress = rKey1.GetValue("%Domain%").ToString();
                    string dbServerIpAddress = rKey2.GetValue("%DataSource%").ToString();

                    if (String.IsNullOrEmpty(apServerIpAddress) || String.IsNullOrEmpty(dbServerIpAddress))
                    {
                        retResult = false;
                    }
                    else
                    {
                        retResult = (secMngConnectSt.ApServerIpAddress == apServerIpAddress) && (secMngConnectSt.DbServerIpAddress == dbServerIpAddress);
                    }
                }
                else
                {
                    // ���W�X�g����񂪖��ݒ�̏ꍇ
                    retResult = false;
                }
            }
            catch (Exception)
            {
                retResult = false;
            }

            return retResult;
        }
        #endregion �� �ڑ���`�F�b�N���� ��

        #region �� ���M�Ώۃf�[�^�̎擾���� ��
        /// <summary>
        /// ���M�Ώۃf�[�^�̎擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sendDataList">���M�Ώۃf�[�^���X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M�Ώۃf�[�^�̎擾�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.05.25</br> 
        /// </remarks>
        /// <returns>�`�F�b�N��������</returns>
        public int GetSecMngSendData(string enterpriseCode, out ArrayList sendDataList)
        {
            sendDataList = new ArrayList();
            List<SecMngSndRcv> sendList = new List<SecMngSndRcv>();
            List<SecMngSndRcvDtl> sendDtlList = new List<SecMngSndRcvDtl>();
            // �S������
            int status = this._sendSetAcs.SearchAll(out sendList, out sendDtlList, enterpriseCode);

            // ���M�f�[�^�̎擾
            foreach (SecMngSndRcv secMngSndRcv in sendList)
            {
                if (secMngSndRcv.DisplayOrder <= 99 && secMngSndRcv.SecMngSendDiv == 1)
                {
                    sendDataList.Add(secMngSndRcv);
                }
            }

            return status;
        }
        #endregion

		/// <summary>
		/// ���_���̎擾����
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>���_����</returns>
		/// <remarks>
		/// </remarks>
		private string GetSectionName(string sectionCode)
		{
			string sectionName = string.Empty;

			if (sectionCode.Trim().PadLeft(2, '0') == "00")
			{
				sectionName = "�S�Ћ���";
				return sectionName;
			}

			ArrayList retList = new ArrayList();
			SecInfoAcs secInfoAcs = new SecInfoAcs();

			try
			{
				foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
					{
						sectionName = secInfoSet.SectionGuideNm.Trim();
						return sectionName;
					}
				}
			}
			catch
			{
				sectionName = string.Empty;
			}

			return sectionName;
		}

		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
		/// <summary>
		/// ���M���񃊃��[�h
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sendDataList">���_���X�g</param>
		/// <returns>�Ǎ����ʃX�e�[�^�X</returns>
		public int ReloadSecMngSetInfo(string enterpriseCode, out ArrayList sendDataList)
		{
			sendDataList = new ArrayList();
			string retMessage = string.Empty;
			ArrayList secMngInfoList = new ArrayList();
			// ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
			int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngInfoList, out retMessage);
			// ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				return status;
			}
			foreach (APSecMngSetWork secMngSetWork in secMngInfoList)
			{
				if (!sendDataList.Contains(secMngSetWork.SendDestSecCode.Trim()))
				{
					sendDataList.Add(secMngSetWork.SendDestSecCode.Trim());
				}
			}
			return status;

		}
		//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        #region �� ���M�Ώۃf�[�^�����̎擾���� ��
        /// <summary>
        /// ���M�Ώۃf�[�^�����̎擾����
        /// </summary>
        /// <param name="extractCondDiv">���o�����敪</param>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="startTime">�J�n����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updSectionCode">upd��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="sendCode">send���_�R�[�h</param>
        /// <param name="isEmpty">�f�[�^�����邩�ǂ���</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="fileIds">�t�@�C��ID�z��</param>
        /// <param name="fileNms">�t�@�C�����̔z��</param>
        /// <param name="sendDestEpCodeList">���M�拒�_���X�g</param>
        /// <returns>���M�������[�N</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�ɂ��A���M�f�[�^�̌������擾����B</br> 
        /// <br>           : 10900690-00 2013/3/13�z�M���ً̋}�Ή�</br>
        /// <br>           : Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�</br>
        /// <br>Programmer : zhlj</br>                                  
        /// <br>Date       : 2013/02/07</br>
        /// <br>Update Note: 2020/09/25 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
        public SearchCountWork SearchDataProc(int extractCondDiv, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updSectionCode, string updEmployeeCode,
                    // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                    //string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList)
                    string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList, int acptAnOdrSendDiv, int shipmentSendDiv, int estimateSendDiv)
                    // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        {
            string retMessage;
            isEmpty = false;
            // ���M�������[�N
            SearchCountWork searchCountWork = new SearchCountWork();
            // ���M�f�[�^�̒��o����
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();
            // �V���N��
            DateTime syncExecDt = new DateTime();
            DateTime syncExecDtTemp = new DateTime();
            DateTime syncExecDtLogTemp = new DateTime(); 
            // ���엚�����O�f�[�^
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            DateTime minSyncExecDt = new DateTime();
            // ���M�f�[�^���[�N
            APSendDataWork paraSendDataWork = new APSendDataWork();
            paraSendDataWork.EndDateTime = endingTime;
            paraSendDataWork.StartDateTime = beginningTime;
            paraSendDataWork.PmEnterpriseCode = enterpriseCode;
            paraSendDataWork.PmSectionCode = baseCode;
            paraSendDataWork.SndMesExtraCondDiv = extractCondDiv;                  
            paraSendDataWork.SyncExecDate = startTime.Ticks;
            // ����M�������O���M�ԍ�(SndNoCreateDiv==1:���M�ԍ��𐶐����Ȃ�)
            paraSendDataWork.SndNoCreateDiv = 1;

            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            paraSendDataWork.AcptAnOdrSendDiv = acptAnOdrSendDiv;
            paraSendDataWork.ShipmentSendDiv = shipmentSendDiv;
            paraSendDataWork.EstimateSendDiv = estimateSendDiv;
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

            // ���o�����敪���u�`�[���t�v�̏ꍇ
            if (extractCondDiv == 1)
            {
                // �V�X�e�����t
                long endTimeTemp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));

                // ��ʏI�����t���ߋ����t�̏ꍇ
                if (endTimeTemp > endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // ��ʏI�������V�X�e�����t�̏ꍇ
                else if (endTimeTemp == endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DateTime endTimeLog = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                            int.Parse(endTimeStr.Substring(4, 2)),
                            int.Parse(endTimeStr.Substring(6, 2)),
                            23, 59, 59);

                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTimeLog;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // ��ʏI�������������t�̏ꍇ
                else
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
            }

            this._extractCondDiv = extractCondDiv;
            // ���M�ԍ�
            int no = 0;
            // ���M�f�[�^�̒��o����
            int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayListSCM(out retCSAList, paraSendDataWork, baseCode, fileIds, out retMessage, out no, updSectionCode);

            // ���o����������̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);

                if (isEmpty)
                {
                    // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                }
            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCode + ")", string.Empty);
                searchCountWork.Status = -1;
            }

            return searchCountWork;
        }

        #endregion
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

    }
}
