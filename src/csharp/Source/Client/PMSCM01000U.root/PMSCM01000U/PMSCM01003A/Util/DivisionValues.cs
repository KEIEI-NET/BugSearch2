using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �敪�l�ێ��N���X
    /// </summary>
    public static class DivisionValues
    {
        #region �󒍃f�[�^
        /// <summary>
        /// �񓚋敪
        /// </summary>
        public enum AnswerDivCd : int
        {
            /// <summary>����</summary>
            NoAction = 0,
            /// <summary>�񓚒�(Web���݂̂̃X�e�[�^�X)</summary>
            OnAnswer = 1,
            //>>>2011/05/25
            /// <summary>��t�ς�</summary>
            AccComplete = 2,
            //<<<2011/05/25
            /// <summary>�ꕔ��</summary>
            AnsParts = 10,
            /// <summary>�񓚊���</summary>
            AnsComplete = 20,
            /// <summary>�L�����Z��</summary>
            Cancel = 99
        }

        /// <summary>
        /// �󒍃X�e�[�^�X
        /// </summary>
        public enum AcptAnOdrStatus : int
        {
            /// <summary>���ݒ�</summary>
            NoSet = 0,
            /// <summary>����</summary>
            Estimate = 10,
            /// <summary>��</summary>
            Accept = 20,
            /// <summary>����</summary>
            Sales = 30
        }

        /// <summary>
        /// �┭�E�񓚎��
        /// </summary>
        public enum InqOrdAnsDivCd : int
        {
            /// <summary>�⍇������</summary>
            Inquiry = 1,
            /// <summary>��</summary>
            Answer = 2
        }

        /// <summary>
        /// �񓚍쐬�敪
        /// </summary>
        public enum AnswerCreateDiv : int
        {
            /// <summary>����</summary>
            Auto = 0,
            /// <summary>�蓮(Web)</summary>
            ManualWeb = 1,
            /// <summary>�蓮(���̑�)</summary>
            ManualOther = 2
        }
        #endregion

        #region �󔭒��f�[�^(Web)
        /// <summary>
        /// �ŐV���ʋ敪
        /// </summary>
        public enum LatestDiscCode : int
        {
            /// <summary>�w�薳��</summary>
            All = -1,
            /// <summary>�ŐV�f�[�^</summary>
            New = 0,
            /// <summary>��</summary>
            Old = 1
        }

        #endregion
    }
}
