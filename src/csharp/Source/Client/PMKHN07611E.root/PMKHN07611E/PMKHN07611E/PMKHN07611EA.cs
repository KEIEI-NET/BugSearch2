//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �����}�X�^�i�C���|�[�g�j���o�����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_JoinImportWorkTbl
    /// <summary>
    ///                      �����}�X�^�i�C���|�[�g�j���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����}�X�^�i�C���|�[�g�j���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ExtrInfo_JoinImportWorkTbl
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�����敪</summary>
        private Int32 _processKbn;

        /// <summary>CSV�f�[�^��񃊃X�g</summary>
        private List<string[]> _csvDataInfoList;

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

        /// <summary>
        /// �����}�X�^�i�C���|�[�g�j���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_JoinImportWorkTbl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_JoinImportWorkTbl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_JoinImportWorkTbl()
        {
        }
    }
}
