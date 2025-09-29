//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�w�ʕϊ�����
// �v���O�����T�v   : �a�k�R�[�h�w�ʕϊ��������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/01/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :
// �C �� ��              �C�����e :
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateParaCWork
    /// <summary>
    ///                      �|���p�����[�^�b���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���p�����[�^�b���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/01/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RateParaCWork
    {
        /// <summary>�t�@�C����</summary>
        private string _fileName = "";

        /// <summary>�Z�N�V������</summary>
        private string _sectionName = "";

        /// <summary>Ұ������</summary>
        private string _makerCd = "";

        /// <summary>�ϊ��OBL����</summary>
        private string _beforeBlCd = "";

        /// <summary>�ϊ���BL����ؽ�</summary>
        private ArrayList _afterBlList = null;


        /// public propaty name  :  FileName
        /// <summary>�t�@�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>�Z�N�V�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�N�V�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  MakerCd
        /// <summary>Ұ�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ұ�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerCd
        {
            get { return _makerCd; }
            set { _makerCd = value; }
        }

        /// public propaty name  :  BeforeBlCd
        /// <summary>�ϊ��OBL���ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��OBL���ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BeforeBlCd
        {
            get { return _beforeBlCd; }
            set { _beforeBlCd = value; }
        }

        /// public propaty name  :  AfterBlList
        /// <summary>�ϊ���BL����ؽăv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ���BL����ؽăv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList AfterBlList
        {
            get
            {
                if (_afterBlList == null)
                    _afterBlList = new ArrayList();
                return _afterBlList;
            }
            set { _afterBlList = value; }
        }


        /// <summary>
        /// �|���p�����[�^�b���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RateParaCWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateParaCWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RateParaCWork()
        {
        }

    }
}
