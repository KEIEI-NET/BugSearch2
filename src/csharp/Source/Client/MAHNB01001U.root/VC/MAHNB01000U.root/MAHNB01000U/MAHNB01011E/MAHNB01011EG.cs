using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region [LogData]
    /// <summary>
    /// �����I�Ƀ��O�o�͗\��̓��e���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����I�Ƀ��O�o�͗\��̓��e���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/02/11</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class LogData
    {
        /// <summary>����</summary>
        private Int64 _sysDateTime;
        /// <summary>���O�ԍ�</summary>
        private Byte _logNo;
        /// <summary>����`�[�ԍ�</summary>
        private Int32 _salesSlipNo;
        /// <summary>�󒍃X�e�[�^�X</summary>
        private Byte _acptAnOdrStatus;

        /// <summary>
        /// ����
        /// </summary>
        public Int64 SysDateTime
        {
            get { return _sysDateTime; }
            set { _sysDateTime = value; }
        }
        /// <summary>
        /// ���O�ԍ�
        /// </summary>
        public Byte LogNo
        {
            get { return _logNo; }
            set { _logNo = value; }
        }
        /// <summary>
        /// ����`�[�ԍ�
        /// </summary>
        public Int32 SalesSlipNo
        {
            get { return _salesSlipNo; }
            set { _salesSlipNo = value; }
        }
        /// <summary>
        /// �󒍃X�e�[�^�X
        /// </summary>
        public Byte AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public LogData()
        {
        }
    }
    # endregion

}
