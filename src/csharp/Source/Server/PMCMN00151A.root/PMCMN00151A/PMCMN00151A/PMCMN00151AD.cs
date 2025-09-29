//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������
// �v���O�����T�v   : �������A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15   �C�����e : �d�a�d�΍�
//----------------------------------------------------------------------------//
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.IO;
using System.Xml;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �e�������f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �e�������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: ���X�ؘj</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvDataParam
    {
        #region �� Private Members

        /// <summary>���O�o�͓��e</summary>
        /// <remarks>���O�o�͓��e</remarks>
        private string _logOutputMsg = string.Empty;

        #endregion // �� Private Members

        /// public propaty name  :  LogOutputMsg
        /// <summary>���O�o�͓��e�v���p�e�B</summary>
        /// <value>���O�o�͓��e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�o�͓��e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogOutputMsg
        {
            get { return _logOutputMsg; }
            set { _logOutputMsg = value; }
        }

        # region �� Constructor

        /// <summary>
        /// �e�������f�[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�������f�[�^�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvDataParam()
        {
        }

        /// <summary>
        /// �e�������f�[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="logOutputMsg">���O�o�͓��e</param>
        /// <remarks>
        /// <br>Note       : �e�������f�[�^�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvDataParam(string logOutputMsg)
        {
            this._logOutputMsg = logOutputMsg;
        }

        # endregion // �� Constructor

        #region �� Public Methods

        #endregion // �� Public Methods
    }
}
