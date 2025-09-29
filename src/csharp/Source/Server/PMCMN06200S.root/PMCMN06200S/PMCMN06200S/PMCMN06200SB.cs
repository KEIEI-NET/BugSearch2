using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.ServiceProcess
{
    /// public class name:   CheckCondWork
    /// <summary>
    ///                      �`�F�b�N�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �`�F�b�N�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/31</br>
    /// <br>Genarated Date   :   2008/10/31  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   ���s�L����ǉ�</br>
    /// <br>Programmer       :   21024�@���X�� ��</br>
    /// <br>Date             :   2010/05/19</br>
    /// </remarks>
    [Serializable]
    public class CheckCondWork
    {
        /// <summary>�`�F�b�N�J�n�����P</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkStTime1;

        /// <summary>�`�F�b�N�I�������P</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkEdTime1;

        /// <summary>�`�F�b�N�J�n�����Q</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkStTime2;

        /// <summary>�`�F�b�N�I�������Q</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkEdTime2;

        /// <summary>���s�v���O����</summary>
        private string _pgId = "";

        /// <summary>���s�p�����[�^</summary>
        private string _pgParam = "";

        /// <summary>�`�F�b�N�Ԋu</summary>
        /// <remarks>����</remarks>
        private Int32 _chkInterval;

        /// <summary>�`�F�b�N�܂Ŏc��</summary>
        /// <remarks>����</remarks>
        private Int32 _remainedTm;

        /// <summary>�`�F�b�N�Ԋu�`�F�b�N�p</summary>        
        private Int32 _hourCnt;

        // 2010/05/19 Add >>>
        /// <summary>���s�敪</summary>        
        private Int32 _processExecuteDiv;
        // 2010/05/19 Add <<<

        /// public propaty name  :  ChkStTime1
        /// <summary>�`�F�b�N�J�n�����P�v���p�e�B</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�J�n�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChkStTime1
        {
            get { return _chkStTime1; }
            set { _chkStTime1 = value; }
        }

        /// public propaty name  :  ChkEdTime1
        /// <summary>�`�F�b�N�I�������P�v���p�e�B</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�I�������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChkEdTime1
        {
            get { return _chkEdTime1; }
            set { _chkEdTime1 = value; }
        }

        /// public propaty name  :  ChkStTime2
        /// <summary>�`�F�b�N�J�n�����Q�v���p�e�B</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�J�n�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChkStTime2
        {
            get { return _chkStTime2; }
            set { _chkStTime2 = value; }
        }

        /// public propaty name  :  ChkEdTIme2
        /// <summary>�`�F�b�N�I�������Q�v���p�e�B</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�I�������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChkEdTime2
        {
            get { return _chkEdTime2; }
            set { _chkEdTime2 = value; }
        }

        /// public propaty name  :  PgId
        /// <summary>���s�v���O�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�v���O�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PgId
        {
            get { return _pgId; }
            set { _pgId = value; }
        }

        /// public propaty name  :  PgParam
        /// <summary>���s�p�����[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�p�����[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PgParam
        {
            get { return _pgParam; }
            set { _pgParam = value; }
        }

        /// public propaty name  :  ChkInterval
        /// <summary>�`�F�b�N�Ԋu�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�Ԋu�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChkInterval
        {
            get { return _chkInterval; }
            set { _chkInterval = value; }
        }

        /// public propaty name  :  RemainedTm
        /// <summary>�`�F�b�N�܂Ŏc��v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�܂Ŏc��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RemainedTm
        {
            get { return _remainedTm; }
            set { _remainedTm = value; }
        }

        /// <summary>�`�F�b�N�Ԋu�`�F�b�N�p</summary>        
        public Int32 HourCnt
        {
            get { return _hourCnt; }
            set { _hourCnt = value; }
        }

        // 2010/05/19 Add >>>
        /// public propaty name  :  ProcessExecuteDiv
        /// <summary>���s�敪</summary>
        /// <value>0:����A1:���Ȃ�</value>
        public Int32 ProcessExecuteDiv
        {
            get { return _processExecuteDiv; }
            set { _processExecuteDiv = value; }
        }
        // 2010/05/19 Add <<<

        /// <summary>
        /// �`�F�b�N�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CheckCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CheckCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CheckCondWork()
        {
        }

    }
}
