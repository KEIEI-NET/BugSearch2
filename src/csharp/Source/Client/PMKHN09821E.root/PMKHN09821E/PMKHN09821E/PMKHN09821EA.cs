//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �|���}�X�^�i�C���|�[�g�j���o�����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   DepsitMainRfImportWorkTbl
    /// <summary>
    ///                      �|���}�X�^�i�C���|�[�g�j���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^�i�C���|�[�g�j���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class DepsitMainRfImportWorkTbl
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

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
        /// �|���}�X�^�i�C���|�[�g�j���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>DepsitMainRfImportWorkTbl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepsitMainRfImportWorkTbl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepsitMainRfImportWorkTbl()
        {
        }
    }
}
