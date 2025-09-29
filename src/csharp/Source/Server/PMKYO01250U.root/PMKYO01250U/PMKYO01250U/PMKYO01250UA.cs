//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M�����N������
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/16  �C�����e : PVCS�[��158�̓���f�B���N�g���ݒ�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/25  �C�����e : PVCS�[��284�̓���f�B���N�g���ݒ�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011/07/25  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/31  �C�����e : Redmine #24278: �f�[�^������M�������N�����܂���
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��M�������N��
    /// </summary>
    public partial class PMKYO01250UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region [ Private Member ]
        private MstUpdCountAcs _mstUpdCountAcs;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// ��M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKYO01250UA()
        {
            // ����������
            InitializeComponent();
            this._mstUpdCountAcs = MstUpdCountAcs.GetInstance();
        }
        #endregion

        #region [ �z�M�A�������}�[�W���� ]
        internal void MergeOfferToUser(string parameter)
        {
            try
            {
                // ��ƃR�[�h
                string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // ���M�V���N����
                DateTime _startTime = new DateTime();
                // ���M���_�R�[�h���X�g
                ArrayList baseCodeNameList = new ArrayList();
                // �}�X�^���̋敪���X�g
                ArrayList masterDivList = new ArrayList();
                // ���_�R�[�h
                string baseCode = string.Empty;
                // ��M�V���N����
                //DateTime _recStartTime = new DateTime();//DEL 2011/07/25 �g���Y
                // ��M���_�R�[�h���X�g
                ArrayList recBaseCodeNameList = new ArrayList();
                // ���M�}�X�^���̃��X�g
                ArrayList masterNameList = new ArrayList();
                // ��M�}�X�^���̃��X�g
                ArrayList recMasterNameList = new ArrayList();
                // ��M�}�X�^���̋敪���X�g
                ArrayList recMasterDivList = new ArrayList();
                // ��M���_��񃊃X�g
                ArrayList secMngSetArrList = new ArrayList();
                // ��M�}�X�^���̖��׋敪���X�g
                ArrayList masterDtlDivList = new ArrayList();
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //����M�������O�f�[�^���X�g
                ArrayList sndRcvHisList = new ArrayList();
                //����M���o�����������O�f�[�^���X�g
                ArrayList sndRcvEtrList = new ArrayList();
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                // ��M���_�R�[�h
                string recBaseCode = string.Empty;
                // PM��ƃR�[�h
                string pmCode = string.Empty;
                // �G���[���b�Z�[�W
                string errMsg = string.Empty;
                // �ڑ���敪
                Int32 _connectPointDiv = 0;

                // �� 2009.06.22 ���m add PVCS.231
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // �� 2009.06.22 ���m add PVCS.231

                if ("0".Equals(parameter))
                {
                    // ���M���}�X�^���̎擾
                    status = _mstUpdCountAcs.LoadMstName(_enterpriseCode, out masterNameList);
                    // ���_������������
                    //status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList);//DEL 2011/07/25
                    status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList, 0);//ADD 2011/07/25
                    // ���M���_�R�[�h���擾����B
                    foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
                    {
                        baseCode = baseCodeNameWork.SectionCode;
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        _startTime = baseCodeNameWork.SyncExecDate;
                        // ���_�R�[�h��̈ȊO�̏ꍇ�A���M�����n�܂�܂��B
                        if (!string.IsNullOrEmpty(baseCode))
                        {
                            // ���M�}�X�^�敪���擾����B
                            status = _mstUpdCountAcs.LoadMstDoDiv(_enterpriseCode, out masterDivList);
                            if (masterDivList.Count != 0)
                            {
                                // �ڑ���`�F�b�N����
                                if (_mstUpdCountAcs.AutoServersCheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
                                {
                                    long beginDtLong = _startTime.Ticks;
                                    long endDtLong = System.DateTime.Now.Ticks;                                   

                                    // ���M����
                                    status = _mstUpdCountAcs.AutoServersSendProc(_connectPointDiv, masterNameList, masterDivList, beginDtLong, endDtLong, _startTime, _enterpriseCode, string.Empty, baseCode);
                                }
                            }
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    }
                    #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                    //// ���_�R�[�h��̈ȊO�̏ꍇ�A���M�����n�܂�܂��B
                    //if (!string.IsNullOrEmpty(baseCode))
                    //{
                    //    // ���M�}�X�^�敪���擾����B
                    //    status = _mstUpdCountAcs.LoadMstDoDiv(_enterpriseCode, out masterDivList);
                    //    if (masterDivList.Count != 0)
                    //    {
                    //        // �ڑ���`�F�b�N����
                    //        if (_mstUpdCountAcs.AutoServersCheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
                    //        {
                    //            long beginDtLong = _startTime.Ticks;
                    //            long endDtLong = System.DateTime.Now.Ticks;

                    //            // ���M����
                    //            status = _mstUpdCountAcs.AutoServersSendProc(_connectPointDiv, masterNameList, masterDivList, beginDtLong, endDtLong, _startTime, _enterpriseCode, string.Empty, baseCode);
                    //        }
                    //    }
                    //}
                    #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                }
                else if ("1".Equals(parameter))
                {
                    // ���_�R�[�h��̏ꍇ�A��M�����n�܂�܂��B
                    // ���_������������
                    _mstUpdCountAcs.AutoSendRecvDiv = true;//ADD 2011/08/31 Redmine #24278: �f�[�^������M�������N�����܂���
                    //status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out secMngSetArrList, out recBaseCodeNameList);//DEL 2011/07/25
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                    status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out secMngSetArrList, out recBaseCodeNameList, out sndRcvHisList, out sndRcvEtrList);
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                    //if (recBaseCodeNameList.Count == 0)//DEL 2011/07/25
                    if (sndRcvHisList.Count == 0)//ADD 2011/07/25
                    {
                        return;
                    }

                    // �ڑ���`�F�b�N����
                    if (!_mstUpdCountAcs.AutoServersCheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
                    {
                        return;
                    }

                    status = _mstUpdCountAcs.LoadReceMstName(_enterpriseCode, out recMasterNameList);
                    // ��M�}�X�^�敪���擾����B
                    status = _mstUpdCountAcs.LoadReceMstDoDiv(_enterpriseCode, out masterDivList);
                    // ��M�}�X�^���׋敪���擾����B
                    status = _mstUpdCountAcs.LoadReceMstDtlDoDiv(_enterpriseCode, out masterDtlDivList);
                    // ��̔��f
                    bool isEmpty = false;
                    bool isNotLogOut = true;
                    // ���_����M����
                    #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                    //foreach (BaseCodeNameWork recBaseCodeNameWork in recBaseCodeNameList)
                    //{
                    //    recBaseCode = recBaseCodeNameWork.SectionCode;
                    //    // PM��ƃR�[�h���擾����B
                    //    status = _mstUpdCountAcs.SeachPmCode(_enterpriseCode, recBaseCode, out pmCode);

                    //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        break;
                    //    }

                    //    foreach (APMSTSecMngSetWork apMSTSecMngSetWork in secMngSetArrList)
                    //    {
                    //        if (recBaseCode.Equals(apMSTSecMngSetWork.SectionCode))
                    //        {
                    //            _recStartTime = apMSTSecMngSetWork.SyncExecDate;
                    //            break;
                    //        }
                    //    }

                    //    long recBeginDtLong = _recStartTime.Ticks;
                    //    long recEndDtLong = System.DateTime.Now.Ticks;

                    //    // ������M�����n�܂�܂��B
                    //    status = _mstUpdCountAcs.AutoServersReceProc(_enterpriseCode, recMasterNameList, masterDivList, masterDtlDivList, _connectPointDiv, recBeginDtLong, recEndDtLong, secMngSetArrList, pmCode, string.Empty, recBaseCode, out isEmpty);

                    //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        isNotLogOut = false;
                    //    }
                    //    else
                    //    {
                    //        if (!isEmpty)
                    //        {
                    //            isNotLogOut = false;
                    //        }
                    //    }
                    //}
                    #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                    foreach (SndRcvHisWork recSndRcvHisWork in sndRcvHisList)
                    {
                        //���M�����_�R�[�h
                        recBaseCode = recSndRcvHisWork.SectionCode;
                        //���M����ƃR�[�h
                        pmCode = recSndRcvHisWork.EnterpriseCode;
                        //����M���o�����������O�f�[�^���擾
                        ArrayList paramList = new ArrayList();
                        foreach (SndRcvEtrWork recSndRcvEtrWork in sndRcvEtrList)
                        {
                            if (recSndRcvEtrWork.EnterpriseCode.Equals(pmCode) && recSndRcvEtrWork.SectionCode.Equals(recBaseCode)
                                && recSndRcvEtrWork.SndRcvHisConsNo == recSndRcvHisWork.SndRcvHisConsNo)
                            {
                                paramList.Add(recSndRcvEtrWork);
                            }
                        }

                        long recBeginDtLong = recSndRcvHisWork.SndObjStartDate.Ticks;
                        long recEndDtLong = recSndRcvHisWork.SndObjEndDate.Ticks;

                        // ������M�����n�܂�܂��B
                        status = _mstUpdCountAcs.AutoServersReceProc(_enterpriseCode, recMasterNameList, masterDivList, masterDtlDivList, _connectPointDiv, recBeginDtLong, recEndDtLong, secMngSetArrList, paramList, recSndRcvHisWork, pmCode, string.Empty, recBaseCode, out isEmpty);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isNotLogOut = false;
                        }
                        else
                        {
                            if (!isEmpty)
                            {
                                isNotLogOut = false;
                            }
                        }
                    }
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    // �S�ăf�[�^���������Ȃ��A���O���o�͂���B
                    if (isNotLogOut)
                    {
                        _mstUpdCountAcs.ReceLogOutProc();
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.Message);
            }
        }
        #endregion
    }
}