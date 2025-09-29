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
// �C �� ��  2009/06/16  �C�����e : PVCS�[��158�̓���f�B���N�g���ݒ�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/06/25  �C�����e : PVCS�[��282�̓���f�B���N�g���ݒ�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/25  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
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
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M�������N��
    /// </summary>
    public partial class PMKYO01050UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region [ Private Member ]
        private UpdateCountInputAcs _updateCountInputAcs;
        //private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        // ��ƃR�[�h
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        // �ڑ���敪
        private int _connectPointDiv = 0;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// ���M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKYO01050UA()
        {
            // ����������
            InitializeComponent();
            this._updateCountInputAcs = UpdateCountInputAcs.GetInstance();
            _connectPointDiv = 0;
        }
        #endregion

        #region [ �z�M�A�������}�[�W���� ]
        internal void MergeOfferToUser()
        {
            try
            {
                //DateTime _startTime = new DateTime(); //Del 2011/09/06 zhujc
                string baseCode = string.Empty;
                bool isEmpty = false;
				ArrayList secMngSetWorkList = new ArrayList();
                // ���_������������
				//_startTime = _updateCountInputAcs.LoadProc(_enterpriseCode, out baseCode, out secMngSetWorkList); //Del 2011/09/06 zhujc
                // Add 2011/09/06 zhujc -------------->>>>>>
                int status = _updateCountInputAcs.LoadProcAuto(_enterpriseCode, out secMngSetWorkList);
                
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }
                // Add 2011/09/06 zhujc --------------<<<<<<
                //DEL 2011/09/06 zhujc --------------->>>>>>
                //if (string.IsNullOrEmpty(baseCode))
                //{
                //    return;
                //}
                //DEL 2011/09/06 zhujc ---------------<<<<<<

                // �ڑ���`�F�b�N����
                string errMsg = null;
                if (!_updateCountInputAcs.CheckConnect(_enterpriseCode, true, out _connectPointDiv, out errMsg))
                {
                    // return;
                }

                //long beginDtLong = _startTime.Ticks; //Del 2011/09/06 zhujc
                long endDtLong = System.DateTime.Now.Ticks;

                // �X�V����
				// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				//int status = _updateCountInputAcs.ServsUpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, string.Empty, baseCode, out isEmpty, _connectPointDiv);
				// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
                //int status = 0; //Del 2011/09/06 zhujc
				foreach (APSecMngSetWork secMngSetWork in secMngSetWorkList)
				{
					//�����f�[�^���M�̏ꍇ
                    //if (secMngSetWork.AutoSendFlg == 0) //Del 2011/09/06 zhujc
                    if (secMngSetWork.AutoSendFlg == 0 && secMngSetWork.Kind == 0) //Add 2011/09/06 zhujc
					{
                        //status = _updateCountInputAcs.ServsUpdateProc(secMngSetWork.SyncExecDate.Ticks, endDtLong, _startTime, _enterpriseCode, string.Empty, secMngSetWork.SectionCode.Trim(), secMngSetWork.SendDestSecCode.Trim(), out isEmpty, _connectPointDiv); //Del 2011/09/06 zhujc
                        status = _updateCountInputAcs.ServsUpdateProc(secMngSetWork.SyncExecDate.Ticks, endDtLong, secMngSetWork.SyncExecDate, _enterpriseCode, string.Empty, secMngSetWork.SectionCode.Trim(), secMngSetWork.SendDestSecCode.Trim(), out isEmpty, _connectPointDiv); // Add 2011/09/06 zhujc
					}
				}
                // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}