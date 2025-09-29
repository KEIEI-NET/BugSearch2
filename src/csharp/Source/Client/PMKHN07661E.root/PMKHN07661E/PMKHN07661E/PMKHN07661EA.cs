//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�C���|�[�g�j���o�����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/06/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/19  �C�����e : ��Q�ꗗ�̎w�ENO.110�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_GoodsUImportWorkTbl
    /// <summary>
    ///                      ���i�}�X�^�i�C���|�[�g�j���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�}�X�^�i�C���|�[�g�j���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note : 2012/07/19 �L�w�� </br>
    /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
    /// </remarks>
    public class ExtrInfo_GoodsMngImportWorkTbl
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�����敪</summary>
        private Int32 _processKbn;

        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
        ///<summary>�`�F�b�N�敪</summary>
        private Int32 _checkKbn;
        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<

        /// <summary>CSV�f�[�^��񃊃X�g</summary>
        private List<string[]> _csvDataInfoList;

        /// <summary>�G���[���O�t�@�C����</summary>
        private string _errorLogFileName;
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

        /// public propaty name  :  ProcessKbn
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcessKbn
        {
            get { return _processKbn; }
            set { _processKbn = value; }
        }

        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
        /// public propaty name  :  CheckKbn
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckKbn
        {
            get { return _checkKbn; }
            set { _checkKbn = value; }
        }
        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<

        /// public propaty name  :  CsvDataInfoList
        /// <summary>CSV�f�[�^��񃊃X�g</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CSV�f�[�^��񃊃X�g</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string[]> CsvDataInfoList
        {
            get { return _csvDataInfoList; }
            set { _csvDataInfoList = value; }
        }

        /// public propaty name  :  ErrorLogFileName
        /// <summary>�G���[���O�t�@�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���O�t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorLogFileName
        {
            get { return _errorLogFileName; }
            set { _errorLogFileName = value; }
        }

        /// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_GoodsUImportWorkTbl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_GoodsUImportWorkTbl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_GoodsMngImportWorkTbl()
        {
        }
    }
}
