//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ� 
// �v���O�����T�v   : ���Е��i���������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// SCM�⍇�����O�e�[�u�����������N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�⍇�����O�e�[�u�����������N���X</br>
    /// <br>Programmer       :   �� ��</br>
    /// <br>Date             :   2010/11/19</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ScmInqLogInquirySearchPara
    {
        /// <summary>�J�n����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _beginDateTime;

        /// <summary>�I������</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _endDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�A�����ƃR�[�h</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>���o�ő匏���ݒ�</summary>
        private Int32 _maxSearchCt;

        /// <summary>���o�������߃t���O</summary>
        private bool _searchOverFlg;

        /// public propaty name  :  BeginDateTime
        /// <summary>�J�n�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BeginDateTime
        {
            get { return _beginDateTime; }
            set { _beginDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�I�������v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  CnectOtherEpCd
        /// <summary>�A�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherEpCd
        {
            get { return _cnectOtherEpCd; }
            set { _cnectOtherEpCd = value; }
        }

        /// public propaty name  :  MaxSearchCt
        /// <summary>���o�ő匏���ݒ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�ő匏���ݒ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MaxSearchCt
        {
            get { return _maxSearchCt; }
            set { _maxSearchCt = value; }
        }

        /// public propaty name  :  SearchOverFlg
        /// <summary>���o�������߃t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�������߃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool SearchOverFlg
        {
            get { return _searchOverFlg; }
            set { _searchOverFlg = value; }
        }

        /// <summary>
        /// SSCM�⍇�����O�e�[�u�����������N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SCM�⍇�����O�e�[�u�����������N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquirySearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programmer       :   �� ��</br>
        /// <br>Date             :   2010/11/17</br>
        /// </remarks>
        public ScmInqLogInquirySearchPara()
        {
        }
    }
}
