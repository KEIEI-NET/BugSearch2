//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���_�R�[�h�ϊ���ʃf�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionConvertDispInfo
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>���_�R�[�h(�J�n)</summary>
        private string sectionCdStart = String.Empty;
        /// <summary>���_�R�[�h(�I��)</summary>
        private string sectionCdEnd = String.Empty;        

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>���_�R�[�h(�J�n)�v���p�e�B</summary>
        public string SectionCdStart
        {
            get { return this.sectionCdStart; }
            set { this.sectionCdStart = value; }
        }

        /// <summary>���_�R�[�h(�I��)�v���p�e�B</summary>
        public string SectionCdEnd
        {
            get { return this.sectionCdEnd; }
            set { this.sectionCdEnd = value; }
        }

        #endregion
    }
}
