//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^���M���O�ꗗ���o�����p�����[�^
// �v���O�����T�v   : ����f�[�^���M���O�ꗗ���o�����p�����[�^�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2019/12/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalCprtSndLogListCndtnWork
    /// <summary>
    /// ����f�[�^���M���O�ꗗ���o�����p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����f�[�^���M���O�ꗗ���o�����p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2019/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalCprtSndLogListCndtnWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h</remarks>
        private string[] _sectionCodes;

        /// <summary>���M�����i�J�n�j</summary>
        /// <remarks>���M�����i�J�n�j</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>���M�����i�I���j</summary>
        /// <remarks>���M�����i�I���j</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>�������M�敪</summary>
        /// <remarks>0:�蓮,1:����</remarks>
        private Int32 _sAndEAutoSendDiv;

        /// <summary>���o�ő匏���ݒ�</summary>
        /// <remarks>���o�ő匏���ݒ�</remarks>
        private Int32 _maxSearchCt;

        /// <summary>���o�������߃t���O</summary>
        /// <remarks>���o�������߃t���O</remarks>
        private bool _searchOverFlg;

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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h</summary>
        /// <value>���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SendDateTimeStart
        /// <summary>���M�����i�J�n�j</summary>
        /// <value>���M�����i�J�n�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�����i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>���M�����i�I���j</summary>
        /// <value>���M�����i�I���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�����i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
        }

        /// public propaty name  :  SAndEAutoSendDiv
        /// <summary>�������M�敪</summary>
        /// <value>0:�蓮,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������M�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SAndEAutoSendDiv
        {
            get { return _sAndEAutoSendDiv; }
            set { _sAndEAutoSendDiv = value; }
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
        /// ����f�[�^���M���O�ꗗ���o�����p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalCprtSndLogListCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtSndLogListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalCprtSndLogListCndtnWork()
        {
        }
    }
}
