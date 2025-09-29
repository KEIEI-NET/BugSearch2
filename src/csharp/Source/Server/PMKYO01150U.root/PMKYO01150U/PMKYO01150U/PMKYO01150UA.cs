//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/06/16  �C�����e : PVCS�[��158�̓���f�B���N�g���ݒ�̑Ή�
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
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��M�������N��
    /// </summary>
    public partial class PMKYO01150UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region [ Private Member ]
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private string enterpriseCode;

        /// <summary>�R���g���[��</summary>
        private IAPSendMessageDB _extraAddUpdControlDB;
        // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ---------->>>>>
        /// <summary>
        /// �}�[�W�̎��s�҂��擾���܂��B
        /// </summary>
        private IAPSendMessageDB ExtraAddUpdControlDB
        {
            get
            {
                if (_extraAddUpdControlDB == null)
                {
                    _extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
                }
                return _extraAddUpdControlDB;
            }
        }

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// ��M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKYO01150UA()
        {
            // ����������
            InitializeComponent();
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();
        }
        #endregion

        #region [ �z�M�A�������}�[�W���� ]
        internal void MergeOfferToUser()
        {
            try
            {
                // �ڑ���`�F�b�N
                string errMsg = null;
                int _connectPointDiv = 1;
                if (!_dataReceiveInputAcs.CheckConnect(LoginInfoAcquisition.EnterpriseCode, out _connectPointDiv, out errMsg, 1))
                {
                    return;
                }

                // ��ƃR�[�h
                enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                ArrayList secMngSetWork = null;
                string msg = "";
                // ���_������������
                int status = ExtraAddUpdControlDB.SearchSecMngSetData(enterpriseCode, out secMngSetWork, out msg);
                //// �ُ�̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._dataReceiveInputAcs.AutoSendRecvDiv = true;//2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                    // �X�V����
                    status = this._dataReceiveInputAcs.MergeOfferToUserUpdate(secMngSetWork, _connectPointDiv, enterpriseCode);
                }


            }
            catch (Exception e){ 
                MessageBox.Show("Exception:" + e.Message);
            }
        }
        #endregion
    }
}