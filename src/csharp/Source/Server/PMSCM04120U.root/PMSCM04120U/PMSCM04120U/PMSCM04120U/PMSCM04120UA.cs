//****************************************************************************//
// �V�X�e��         : �o�l.�m�r
// �v���O��������   : PM�f�[�^���������N�����
// �v���O�����T�v   : �A�N�Z�X�N���X�̓����������R�[������
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ђ��}
// �� �� ��  2014/08/12  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Common;
using System.Collections;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��M�������N��
    /// </summary>
    public partial class PMSCM04120UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region [ Private Member ]
        private SynchExecuteAcs _synchExecuteAcs;
        
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// ��M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMSCM04120UA()
        {
            // ����������
            InitializeComponent();
            this._synchExecuteAcs = new SynchExecuteAcs();
        }
        #endregion

        #region [ PM�f�[�^���������N����� ]
        internal void RegularStart()
        {
            try
            {
                _synchExecuteAcs.RegularStart();
            }
            catch
            {
            }
        }

        internal void TranslateExecute()
        {
            try
            {
                _synchExecuteAcs.TranslateExecute();
            }
            catch
            {
            }
        }
        #endregion
    }
}