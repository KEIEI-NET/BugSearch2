//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�֘A�f�[�^�f�[�^�p�����[�^
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   IOWriteSCMReadWork
    /// <summary>
    ///                      SCMRead�f�[�^(IOWriteSCMRead)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCMRead�f�[�^(IOWriteSCMRead)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/06/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/02/26 �r�b�l�����s��C��</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteSCMReadWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>�⍇���ԍ�</summary>
        /// <remarks>����`�[�ԍ����Z�b�g����Ă����ꍇ�͔���`�[�ԍ��D��</remarks>
        private Int64 _inquiryNumber;

        /// <summary>�񓚋敪</summary>
        /// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
        private Int32[] _answerDivCds;

        // -- ADD 2010/02/26 ---------------------------->>>
        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇���E�������</summary>
        private Int32 _inqOrdDivCd = 0;

        /// <summary>�⍇���E�񓚎��</summary>
        private Int32 _inqOrdAnsDivCd = 0;

        /// <summary>�X�V�N����(�ȍ~���o)</summary>
        /// <remarks>�w��N�����ȍ~�̍X�V�N�����̃f�[�^���o(��M����ScmSearch�p)</remarks>
        private DateTime _updateDateOver = DateTime.MinValue;

        /// <summary>��M�����w��敪</summary>
        /// <remarks>1:��M������MinValue�̃f�[�^�𒊏o(��M����ScmSearch�p)</remarks>
        private Int32 _receiveDTZeroDiv = 0;
        // -- ADD 2010/02/26 ----------------------------<<<

        // 2011/02/18 Add >>>
        /// <summary>�L�����Z���敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
        private Int16[] _cancelDivs;
        // 2011/02/18 Add <<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B</summary>
        /// <value>����`�[�ԍ����Z�b�g����Ă����ꍇ�͔���`�[�ԍ��D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  AnswerDivCd
        /// <summary>�񓚋敪�v���p�e�B</summary>
        /// <value>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AnswerDivCds
        {
            get { return _answerDivCds; }
            set { _answerDivCds = value; }
        }

        // -- ADD 2010/02/26 -------------------->>>
        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// <value>1:�⍇�� 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  InqOrdAnsDivCd
        /// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
        /// <value>1:�⍇���E���� 2:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOrdAnsDivCd
        {
            get { return _inqOrdAnsDivCd; }
            set { _inqOrdAnsDivCd = value; }
        }

        /// public propaty name  :  UpdateDateOver
        /// <summary>�X�V�N����(�ȍ~���o)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateOver
        {
            get { return _updateDateOver; }
            set { _updateDateOver = value; }
        }

        /// public propaty name  :  ReceiveDTZeroDiv
        /// <summary>��M�����w��敪�v���p�e�B</summary>
        /// <value>1:��M������MinValue�̃f�[�^�𒊏o(��M����ScmSearch�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiveDTZeroDiv
        {
            get { return _receiveDTZeroDiv; }
            set { _receiveDTZeroDiv = value; }
        }

        // -- ADD 2010/02/26 --------------------<<<

        // 2011/02/18 Add >>>
        /// public propaty name  :  ReceiveDTZeroDiv
        /// <summary>��M�����w��敪�v���p�e�B</summary>
        /// <value>1:��M������MinValue�̃f�[�^�𒊏o(��M����ScmSearch�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16[] CancelDivs
        {
            get { return _cancelDivs; }
            set { _cancelDivs = value; }
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// SCMRead�f�[�^(IOWriteSCMRead)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>IOWriteSCMReadWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteSCMReadWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IOWriteSCMReadWork()
        {
        }

    }
}
