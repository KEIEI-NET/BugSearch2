using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���[�����M����\���������� �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�����M����\���������� �f�[�^�N���X</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/05/25</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class QrMailHistSearchCond
    {
        /// <summary>���M���t(�J�n)</summary>
        private DateTime _transmitDateSt;

        /// <summary>���M���t(�I��)</summary>
        private DateTime _transmitDateEd;

        /// <summary>���M���t(�J�n)</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TransmitDateSt
        {
            get { return _transmitDateSt; }
            set { _transmitDateSt = value; }
        }

        /// <summary>���M���t(�I��)</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TransmitDateEd
        {
            get { return _transmitDateEd; }
            set { _transmitDateEd = value; }
        }

        /// <summary>
        /// ���[�����M����\�����������f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>DispatchInsts�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���[�����M����\���������� �f�[�^�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public QrMailHistSearchCond()
        {
        }
    }
}
