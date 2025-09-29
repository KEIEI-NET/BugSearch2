using System;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using System.Xml.Serialization;
using System.IO;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// public class name:   UiSetByAssembly
    /// <summary>
    ///                      XML�V���A���C�Y�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   XML�V���A���C�Y�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [XmlRoot("UiSetByAssembly")]
    public class UiSetByAssembly
    {
        /// <summary>
        /// �o�b�N�A�b�v���������擾���ʃ��X�g
        /// </summary>
        public List<BackUpExecution> BackUpExecutions = new List<BackUpExecution>();

        /// <summary>
        /// XML�V���A���C�Y�R���X�g���N�^
        /// </summary>
        public UiSetByAssembly()
        { 
        }

        /// <summary>
        /// XML�V���A�ǂ�
        /// </summary>
        /// <param name="wklist"> XML�L�^�̃��X�g</param>
        /// <summary>�����I������</summary>
        /// <remarks>
        /// <br>note             :   XML�V���A��ǂ�</br>
        /// <br>Programer        :   ���C��</br>
        /// </remarks>
        public UiSetByAssembly(ArrayList wklist)
        {
            for (int i = 0; i < wklist.Count; i++)
            {
                BackUpExecutionWork wk = wklist[i] as BackUpExecutionWork;
                BackUpExecution bk = new BackUpExecution();
                bk.StartDateTime = wk.StartDateTime;
                bk.EndDateTime = wk.EndDateTime;
                bk.FileName = wk.FileName;
                bk.DBVersion = wk.DBVersion;
                bk.ResultContent = wk.ResultContent;
                bk.Status = wk.Status;
                BackUpExecutions.Add(bk);
            }
        }
   
    }


    /// public class name:   BackUpExecution
    /// <summary>
    ///                      �o�b�N�A�b�v�����������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�b�N�A�b�v�����������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// </remarks>
    [XmlType("BackUpExecution")]
    public class BackUpExecution
    {
        /// <summary>�����J�n����</summary>
        /// <remarks>�����J�n���ԁiDateTime:���x��100�i�m�b�j</remarks>
        private string _startDateTime;

        /// <summary>�����I������</summary>
        /// <remarks>�����I�����ԁiDateTime:���x��100�i�m�b�j</remarks>
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
        /// <summary>�����J�n����</summary>
        /// <value>�����J�n���ԁiDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����J�n����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>�����I������</summary>
        /// <value>�����I�����ԁiDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>�o�b�N�A�b�v�t�@�C����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�t�@�C����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  DBVersion
        /// <summary>DBVersion</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DBVersion</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DBVersion
        {
            get { return _dBVersion; }
            set { _dBVersion = value; }
        }

        /// public propaty name  :  ResultContent
        /// <summary>��������</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultContent
        {
            get { return _resultContent; }
            set { _resultContent = value; }
        }

        /// public propaty name  :  Status
        /// <summary>�X�e�[�^�X</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�e�[�^�X</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }

    /// public class name:   myReverserClass
    /// <summary>
    ///                      ���X�g�̔�r�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���X�g�̔�r�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// </remarks>
    public class myReverserClass : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(((BackUpExecutionWork)y).StartDateTime, ((BackUpExecutionWork)x).StartDateTime));
        }

    }

    /// public class name:   myReverserClass
    /// <summary>
    ///                      XML�����N���X 
    /// </summary>
    /// <remarks>
    /// <br>note             :   XML�����N���X �w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class XmlSerial
    {
        /// <summary>
        ///XML����
        /// </summary>
        /// <param name="filePath">�t�@�C���p�[�X</param>
        /// <param name="work">�o�b�N�A�b�v�����������[�N</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public int Serialiaze(String filePath,BackUpExecutionWork work)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                IComparer myComparer = new myReverserClass();
                ArrayList wklist = Deserialize(filePath);
                wklist.Add(work);
                if (wklist.Count > 1)
                {
                    wklist.Sort(myComparer);
                }
                int count = wklist.Count - 10;
                if (wklist.Count > 10)
                {
                    for (int i = 0; i < count; i++)
                    {
                        wklist.RemoveAt(10 + i);
                    }
                }
                UiSetByAssembly u = new UiSetByAssembly(wklist);
                XmlSerializer xs = new XmlSerializer(typeof(UiSetByAssembly));

                Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                xs.Serialize(stream, u);
                stream.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch(Exception ex)
            {
                work.ResultContent = ex.Message;
            }
            
            return status;

        }

        /// <summary>
        ///XML�ǂ�
        /// </summary>
        /// <param name="filePath">�t�@�C���p�[�X</param>
        /// <returns>�b�N�A�b�v�����������[�N���X�g</returns>
        /// <remarks>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public ArrayList Deserialize(String filePath)
        {
            ArrayList list = new ArrayList();
            Stream stream = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(UiSetByAssembly));
                stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                UiSetByAssembly p = (UiSetByAssembly)xs.Deserialize(stream);
                stream.Close();

                foreach (BackUpExecution back in p.BackUpExecutions)
                {
                    BackUpExecutionWork wk = new BackUpExecutionWork();
                    wk.Status = back.Status;
                    wk.StartDateTime = back.StartDateTime;
                    wk.EndDateTime = back.EndDateTime;
                    wk.DBVersion = back.DBVersion;
                    wk.FileName = back.FileName;
                    wk.ResultContent = back.ResultContent;
                    list.Add(wk);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                stream.Close();
            }
            
            return list;

        }

    }
}
