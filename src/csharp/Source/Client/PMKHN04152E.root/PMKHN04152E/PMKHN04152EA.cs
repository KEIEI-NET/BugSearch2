//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����M����\��
// �v���O�����T�v   : ���[�����M����\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2010/05/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  2010/06/02  �쐬�S�� : ������
// �C �� ��              �C�����e : Redmine#8992�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���[�����M����\�� �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�����M����\��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/05/25</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/06/02 ������ Redmine#8992�Ή�</br>
    /// </remarks>
    public class QrMailHist
    {
        /// <summary>���[���t�@�C����</summary>
        private string _fileName;

        /// <summary>QR�R�[�h�t�@�C����</summary>
        private string _qRCode;

        /// <summary>���M���t</summary>
        private string _transmitDate;

        /// <summary>���M����</summary>
        private string _transmitTime;

        /// <summary>��M�Җ���</summary>
        private string _employeeName;

        /// <summary>CC���</summary>
        private string _cCInfo;

        /// <summary>����</summary>
        private string _title;

        /// <summary>���[�����e</summary>
        private string _mailText;

        /// <summary>QR�R�[�h(�\���p)</summary>
        private string _qRCodeDisplay;

        /// <summary>���[���t�@�C����</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>QR�R�[�h�t�@�C����</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string QRCode
        {
            get { return _qRCode; }
            set { _qRCode = value; }
        }

        /// <summary>���M���t</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransmitDate
        {
            get { return _transmitDate; }
            set { _transmitDate = value; }
        }

        /// <summary>���M����</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransmitTime
        {
            get { return _transmitTime; }
            set { _transmitTime = value; }
        }

        /// <summary>��M�Җ���</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// <summary>CC���</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CCInfo
        {
            get { return _cCInfo; }
            set { _cCInfo = value; }
        }

        /// <summary>����</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>���[�����e</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailText
        {
            get { return _mailText; }
            set { _mailText = value; }
        }

        /// <summary>QR�R�[�h(�\���p)</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string QRCodeDisplay
        {
            get { return _qRCodeDisplay; }
            set { _qRCodeDisplay = value; }
        }


        /// <summary>
        /// ���[�����M����\���f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>DispatchInsts�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���[�����M����\�� �f�[�^�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public QrMailHist()
        {
        }

        /// <summary>
        /// ���[�����M����\���f�[�^��r�N���X(���M���t(�~��))
        /// </summary>
        /// <br>Update Note :2010/06/02 ������ Redmine#8992�Ή�</br>
        public class QrMailHistComparer : Comparer<QrMailHist>
        {
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            /// <br>Update Note :2010/06/02 ������ Redmine#8992�Ή�</br>
            public override int Compare(QrMailHist x, QrMailHist y)
            {
                int result = y.TransmitDate.CompareTo(x.TransmitDate);
                // --------UPD 2010/06/02-------->>>>>
                //return result;
                if (result == 0)
                {
                    result = y.TransmitTime.CompareTo(x.TransmitTime);
                }
                return result;
                // --------UPD 2010/06/02--------<<<<<
            }
        }

    }
}
