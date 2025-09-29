using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// CSV�`�F�b�N�c�[���@�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ʏ�����</br>
    /// <br>Programmer	: 23006  ���� ���q</br>
    /// <br>Date		: 2014.08.27</br>
    /// </remarks>
    public class PMKHN09951A_Common
    {
        /// <summary>�o�̓��[�h</summary>
        public enum OutputMode
        {
            /// <summary>�L�[�P�ʂɗ���</summary>
            ctByTheKey = 1,
            /// <summary>�x�[�X�Ƃ̔�r�`�F�b�N</summary>
            ctForCompCheck = 2,
            /// <summary>�����p</summary>
            ctForConsolidate = 3,
        }

        /// <summary>CSV�`�F�b�N�c�[���p�����[�^�N���X</summary>
        public class CSVCheckToolPara
        {
            #region
            /// <summary>�v���C�}���[�L�[���X�g</summary>
            private SortedList<int, int> _primaryKeyList = null;

            /// <summary>�Ώۃt�@�C�����C���@�p�X</summary>
            private string _mainFilePath = null;

            /// <summary>�Ώۃt�@�C�����C���@�t�@�C���\������</summary>
            private string _mainFileDispName = "���C��";

            /// <summary>�Ώۃt�@�C���T�u�@�p�XList</summary>
            private Dictionary<string, string> _subFilePathList = null;

            /// <summary>�o�̓��[�h</summary>
            private OutputMode _outputMode = OutputMode.ctForCompCheck;

            /// <summary>��r����List</summary>
            private List<int> _comparItemList = null;

            /// <summary>�\�[�g����List</summary>
            private SortedList<int, int> _sortItemList = null;

            /// <summary>�o�̓t�@�C���p�X</summary>
            private string _outputFilePath = null;

            /// <summary>�w�b�_�[�s�L���敪</summary>
            private bool _headerLineExistDiv = false;

            /// public propaty name  :  PrimaryKeyList
            /// <summary>�v���C�}���[�L�[���X�g�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �v���C�}���[�L�[���X�g�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public SortedList<int, int> PrimaryKeyList
            {
                get { return _primaryKeyList; }
                set { _primaryKeyList = value; }
            }

            /// public propaty name  :  MainFilePath
            /// <summary>�Ώۃt�@�C�����C���@�p�X�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �Ώۃt�@�C�����C���@�p�X�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public string MainFilePath
            {
                get { return _mainFilePath; }
                set { _mainFilePath = value; }
            }

            /// public propaty name  :  MainFileDispName
            /// <summary>�Ώۃt�@�C�����C���@�t�@�C���\�����̃v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �Ώۃt�@�C�����C���@�t�@�C���\�����̃v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public string MainFileDispName
            {
                get { return _mainFileDispName; }
                set { _mainFileDispName = value; }
            }

            /// public propaty name  :  SubFilePathList
            /// <summary>�Ώۃt�@�C���T�u�@�p�XList�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �Ώۃt�@�C���T�u�@�p�XList�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Dictionary<string, string> SubFilePathList
            {
                get { return _subFilePathList; }
                set { _subFilePathList = value; }
            }

            /// public propaty name  :  OutputMode
            /// <summary>�o�̓��[�h�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �o�̓��[�h�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public OutputMode OutputMode
            {
                get { return _outputMode; }
                set { _outputMode = value; }
            }

            /// public propaty name  :  ComparItemList
            /// <summary>��r����List�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ��r����List�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public List<int> ComparItemList
            {
                get { return _comparItemList; }
                set { _comparItemList = value; }
            }


            /// public propaty name  :  SortItemList
            /// <summary>�\�[�g����List�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �\�[�g����List�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public SortedList<int, int> SortItemList
            {
                get { return _sortItemList; }
                set { _sortItemList = value; }
            }

            /// public propaty name  :  OutputFilePath
            /// <summary>�o�̓t�@�C���p�X�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �o�̓t�@�C���p�X�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public string OutputFilePath
            {
                get { return _outputFilePath; }
                set { _outputFilePath = value; }
            }

            /// public propaty name  :  HeaderLineExistDiv
            /// <summary>�w�b�_�[�s�L���敪�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �w�b�_�[�s�L���敪�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public bool HeaderLineExistDiv
            {
                get { return _headerLineExistDiv; }
                set { _headerLineExistDiv = value; }
            }

            /// <summary>
            /// CSV�`�F�b�N�c�[�� �p�����[�^
            /// </summary>
            /// <returns>ExportImportAcsPgInfoClass�N���X�̃C���X�^���X</returns>
            /// <remarks>
            /// <br>Note�@�@�@�@�@�@ :   CSVCheckToolPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public CSVCheckToolPara()
            {
            }
            #endregion
        }
    }
}
