//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AnswerDateMazdaPara
    /// <summary>
    ///                      �}�c�_�񓚃f�[�^�捞�����������o�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �}�c�_�񓚃f�[�^�捞�����������o�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ������</br>
    /// <br>Date             :   2011/05/18</br>
    /// </remarks>
    public class AnswerDateMazdaPara
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        /// <summary>UOE������R�[�h</summary>
        private int _uOESupplierCd;

        /// <summary>�񓚕ۑ��t�H���_</summary>
        private string _answerSaveFolder;

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
    }
}
