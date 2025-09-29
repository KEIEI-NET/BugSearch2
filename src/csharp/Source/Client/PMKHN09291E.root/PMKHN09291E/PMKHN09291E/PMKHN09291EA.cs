using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BackUpExecutionCndtn
    /// <summary>
    ///                      �o�b�N�A�b�v�����擾����
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�b�N�A�b�v�����擾���ʃw�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2011/06/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class BackUpExecutionCndtn
    {
        /// <summary>�����J�n����</summary>
        /// <remarks>�����J�n���ԁistring:���x��100�i�m�b�j</remarks>
        private string _startDateTime;

        /// <summary>�����I������</summary>
        /// <remarks>�����I�����ԁistring:���x��100�i�m�b�j</remarks>
        private string _endDateTime;

        /// <summary>�o�b�N�A�b�v�t�@�C����</summary>
        private string _fileName = "";

        /// <summary>DBVersion</summary>
        private string _dBVersion = "";

        /// <summary>��������</summary>
        private string _resultContent = "";

        /// <summary>�X�e�[�^�X</summary>
        private Int32 _status;


        /// public propaty name  :  StartDateTime
        /// <summary>�����J�n���ԃv���p�e�B</summary>
        /// <value>�����J�n���ԁiDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����J�n���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>�����I�����ԃv���p�e�B</summary>
        /// <value>�����I�����ԁiDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I�����ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>�o�b�N�A�b�v�t�@�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  DBVersion
        /// <summary>DBVersion�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DBVersion�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DBVersion
        {
            get { return _dBVersion; }
            set { _dBVersion = value; }
        }

        /// public propaty name  :  ResultContent
        /// <summary>�������ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultContent
        {
            get { return _resultContent; }
            set { _resultContent = value; }
        }

        /// public propaty name  :  Status
        /// <summary>�X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }


        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʃR���X�g���N�^
        /// </summary>
        /// <returns>BackUpExecutionCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BackUpExecutionCndtn()
        {
        }

        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʃR���X�g���N�^
        /// </summary>
        /// <param name="startDateTime">�����J�n����(�����J�n���ԁiDateTime:���x��100�i�m�b�j)</param>
        /// <param name="endDateTime">�����I������(�����I�����ԁiDateTime:���x��100�i�m�b�j)</param>
        /// <param name="fileName">�o�b�N�A�b�v�t�@�C����</param>
        /// <param name="dBVersion">DBVersion</param>
        /// <param name="resultContent">��������</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <returns>BackUpExecutionCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BackUpExecutionCndtn(string startDateTime, string endDateTime, string fileName, string dBVersion, string resultContent, Int32 status)
        {
            this._startDateTime = startDateTime;
            this._endDateTime = endDateTime;
            this._fileName = fileName;
            this._dBVersion = dBVersion;
            this._resultContent = resultContent;
            this._status = status;

        }

        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʕ�������
        /// </summary>
        /// <returns>BackUpExecutionCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BackUpExecutionCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BackUpExecutionCndtn Clone()
        {
            return new BackUpExecutionCndtn(this._startDateTime, this._endDateTime, this._fileName, this._dBVersion, this._resultContent, this._status);
        }

        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʔ�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BackUpExecutionCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(BackUpExecutionCndtn target)
        {
            return ((this.StartDateTime == target.StartDateTime)
                 && (this.EndDateTime == target.EndDateTime)
                 && (this.FileName == target.FileName)
                 && (this.DBVersion == target.DBVersion)
                 && (this.ResultContent == target.ResultContent)
                 && (this.Status == target.Status));
        }

        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʔ�r����
        /// </summary>
        /// <param name="backUpExecutionCndtn1">
        ///                    ��r����BackUpExecutionCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="backUpExecutionCndtn2">��r����BackUpExecutionCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(BackUpExecutionCndtn backUpExecutionCndtn1, BackUpExecutionCndtn backUpExecutionCndtn2)
        {
            return ((backUpExecutionCndtn1.StartDateTime == backUpExecutionCndtn2.StartDateTime)
                 && (backUpExecutionCndtn1.EndDateTime == backUpExecutionCndtn2.EndDateTime)
                 && (backUpExecutionCndtn1.FileName == backUpExecutionCndtn2.FileName)
                 && (backUpExecutionCndtn1.DBVersion == backUpExecutionCndtn2.DBVersion)
                 && (backUpExecutionCndtn1.ResultContent == backUpExecutionCndtn2.ResultContent)
                 && (backUpExecutionCndtn1.Status == backUpExecutionCndtn2.Status));
        }
        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʔ�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BackUpExecutionCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(BackUpExecutionCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.StartDateTime != target.StartDateTime) resList.Add("StartDateTime");
            if (this.EndDateTime != target.EndDateTime) resList.Add("EndDateTime");
            if (this.FileName != target.FileName) resList.Add("FileName");
            if (this.DBVersion != target.DBVersion) resList.Add("DBVersion");
            if (this.ResultContent != target.ResultContent) resList.Add("ResultContent");
            if (this.Status != target.Status) resList.Add("Status");

            return resList;
        }

        /// <summary>
        /// �o�b�N�A�b�v�����擾���ʔ�r����
        /// </summary>
        /// <param name="backUpExecutionCndtn1">��r����BackUpExecutionCndtn�N���X�̃C���X�^���X</param>
        /// <param name="backUpExecutionCndtn2">��r����BackUpExecutionCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(BackUpExecutionCndtn backUpExecutionCndtn1, BackUpExecutionCndtn backUpExecutionCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (backUpExecutionCndtn1.StartDateTime != backUpExecutionCndtn2.StartDateTime) resList.Add("StartDateTime");
            if (backUpExecutionCndtn1.EndDateTime != backUpExecutionCndtn2.EndDateTime) resList.Add("EndDateTime");
            if (backUpExecutionCndtn1.FileName != backUpExecutionCndtn2.FileName) resList.Add("FileName");
            if (backUpExecutionCndtn1.DBVersion != backUpExecutionCndtn2.DBVersion) resList.Add("DBVersion");
            if (backUpExecutionCndtn1.ResultContent != backUpExecutionCndtn2.ResultContent) resList.Add("ResultContent");
            if (backUpExecutionCndtn1.Status != backUpExecutionCndtn2.Status) resList.Add("Status");

            return resList;
        }
    }
}
