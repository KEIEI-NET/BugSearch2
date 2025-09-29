//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���M�e�L�X�g�i���M�d���j�N���X
    /// </summary>
    public class SendingText
    {
        #region <�d��/>

        /// <summary>�d��</summary>
        private readonly byte[] _telegram;
        /// <summary>
        /// �d�����擾���܂��B
        /// </summary>
        /// <value>�d��</value>
        protected byte[] Telegram { get { return _telegram; } }

        #endregion  // <�d��/>

        /// <summary>�d���敪</summary>
        private readonly byte[] _telegramDivs = new byte[1];
        /// <summary>�d���敪</summary>
        protected byte[] TelegramDivs { get { return _telegramDivs; } }

        /// <summary>�����敪</summary>
        private readonly byte[] _processDivs = new byte[1];
        /// <summary>�����敪</summary>
        protected byte[] ProcessDivs { get { return _processDivs; } }

        /// <summary>�[�����R�[�h</summary>
        private readonly byte[] _terminalCodes = new byte[7];
        /// <summary>�[�����R�[�h</summary>
        protected byte[] TerminalCodes { get { return _terminalCodes; } }

        /// <summary>�z�X�g�R�[�h</summary>
        private readonly byte[] _hostCodes = new byte[7];
        /// <summary>�z�X�g�R�[�h</summary>
        protected byte[] HostCodes { get { return _hostCodes; } }

        /// <summary>�p�X���[�h</summary>
        private readonly byte[] _passwords = new byte[6];
        /// <summary>�p�X���[�h</summary>
        protected byte[] Passwords { get { return _passwords; } }

        /// <summary>���M���t</summary>
        private readonly byte[] _sendDates = new byte[6];
        /// <summary>���M���t</summary>
        protected byte[] SendDates { get { return _sendDates; } }

        /// <summary>���M����</summary>
        private readonly byte[] _sendTimes = new byte[6];
        /// <summary>���M����</summary>
        protected byte[] SendTimes { get { return _sendTimes; } }

        /// <summary>����</summary>
        private readonly byte[] _results = new byte[2];
        /// <summary>����</summary>
        protected byte[] Results { get { return _results; } }

        /// <summary>�����敪</summary>
        private readonly byte[] _orderDivs = new byte[1];
        /// <summary>�����敪</summary>
        protected byte[] OrderDivs { get { return _orderDivs; } }

        /// <summary>���b�Z�[�W</summary>
        private readonly byte[] _messages = new byte[32];
        /// <summary>���b�Z�[�W</summary>
        protected byte[] Messages { get { return _messages; } } 

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="telegram">�d��</param>
        public SendingText(byte[] telegram)
        {
            _telegram = telegram;

            Initialize();
        }

        /// <summary>
        /// ���������܂��B
        /// </summary>
        private void Initialize()
        {
            int currentPos = 0;

            // �d���敪
            for (int i = 0; i < TelegramDivs.Length; i++)
            {
                TelegramDivs[i] = Telegram[currentPos];
                currentPos++;
            }

            // �����敪
            for (int i = 0; i < ProcessDivs.Length; i++)
            {
                ProcessDivs[i] = Telegram[currentPos];
                currentPos++;
            }

            // �[�����R�[�h
            for (int i = 0; i < TerminalCodes.Length; i++)
            {
                TerminalCodes[i] = Telegram[currentPos];
                currentPos++;
            }

            // �z�X�g�R�[�h
            for (int i = 0; i < HostCodes.Length; i++)
            {
                HostCodes[i] = Telegram[currentPos];
                currentPos++;
            }

            // �p�X���[�h
            for (int i = 0; i < Passwords.Length; i++)
            {
                Passwords[i] = Telegram[currentPos];
                currentPos++;
            }

            // ���M���t
            for (int i = 0; i < SendDates.Length; i++)
            {
                SendDates[i] = Telegram[currentPos];
                currentPos++;
            }

            // ���M����
            for (int i = 0; i < SendTimes.Length; i++)
            {
                SendTimes[i] = Telegram[currentPos];
                currentPos++;
            }

            // ����
            for (int i = 0; i < Results.Length; i++)
            {
                Results[i] = Telegram[currentPos];
                currentPos++;
            }

            // �����敪
            for (int i = 0; i < OrderDivs.Length; i++)
            {
                OrderDivs[i] = Telegram[currentPos];
                currentPos++;
            }

            // ���b�Z�[�W
            for (int i = 0; i < Messages.Length; i++)
            {
                Messages[i] = Telegram[currentPos];
                currentPos++;
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>������</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            {
                str.Append("�d���敪�F").Append(ConvertString(TelegramDivs)).Append(Environment.NewLine);
                str.Append("�����敪�F").Append(ConvertString(ProcessDivs)).Append(Environment.NewLine);
                str.Append("�[�����R�[�h�F").Append(ConvertString(TerminalCodes)).Append(Environment.NewLine);
                str.Append("�z�X�g�R�[�h�F").Append(ConvertString(HostCodes)).Append(Environment.NewLine);
                str.Append("�p�X���[�h�F").Append(ConvertString(Passwords)).Append(Environment.NewLine);
                str.Append("���M���t�F").Append(ConvertString(SendDates)).Append(Environment.NewLine);
                str.Append("���M�����F").Append(ConvertString(SendTimes)).Append(Environment.NewLine);
                str.Append("���ʁF").Append(ConvertString(Results)).Append(Environment.NewLine);
                str.Append("�����敪�F").Append(ConvertString(OrderDivs)).Append(Environment.NewLine);
                str.Append("���b�Z�[�W�F").Append(ConvertString(Messages)).Append(Environment.NewLine);
            }
            return str.ToString();
        }

        #endregion  // <Override/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <param name="jisCodes">JIS�R�[�h�z��</param>
        /// <returns>������</returns>
        private static string ConvertString(byte[] jisCodes)
        {
            StringBuilder str = new StringBuilder();

            foreach (byte jisCode in jisCodes)
            {
                char aCharacter = Convert.ToChar(jisCode);
                if (aCharacter.Equals('\0'))
                {
                    aCharacter = ' ';
                }
                str.Append("<" + aCharacter.ToString() + ">");
            }

            return str.ToString().Trim();
        }
    }
}
