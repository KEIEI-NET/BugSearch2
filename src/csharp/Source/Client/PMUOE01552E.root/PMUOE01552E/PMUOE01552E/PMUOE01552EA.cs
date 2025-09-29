//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꗗ�X�V����
// �v���O�����T�v   : �z���_e-Parts�V�X�e�����u�������ꗗCSV�v����荞�݁A
//                    �񓚏����X�V���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESupplierInfo
    /// <summary>
    ///                      �����ꗗ�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����ꗗ�f�[�^�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �����</br>
    /// <br>Date             :   2009/06/01</br>
    /// <br>Update Note      : �@2009/06/25 �����</br>
    /// <br>                   �@PVCS#273�ɂ��āA�A�C�e����ǉ����܂��B</br>
    /// </remarks>
    public class UOESupplierInfo
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        /// <summary>UOE������R�[�h</summary>
        private int _uOESupplierCd;

        /// <summary>�񓚕ۑ��t�H���_</summary>
        private string _answerSaveFolder;

        // --- ADD 2009/06/25 ------------------------------->>>>>
        /// <summary>�A�C�e��</summary>
        private string _uOEItemCd;
        // --- ADD 2009/06/25 ------------------------------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public int UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  AnswerSaveFolder
        /// <summary>�񓚕ۑ��t�H���_</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕ۑ��t�H���_</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string AnswerSaveFolder
        {
            get { return _answerSaveFolder; }
            set { _answerSaveFolder = value; }
        }

        // --- ADD 2009/06/25 ------------------------------->>>>>
        /// public propaty name  :  UOEItemCd
        /// <summary>�A�C�e��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�C�e��</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string UOEItemCd
        {
            get { return _uOEItemCd; }
            set { _uOEItemCd = value; }
        }
        // --- ADD 2009/06/25 ------------------------------<<<<<
    }
}
