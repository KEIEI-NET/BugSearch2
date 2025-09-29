using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   JoinPartsUProcParamWork
    /// <summary>
    ///                      �����}�X�^���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����}�X�^���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APJoinPartsUProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>�������i��(�J�n)</summary>
        private string _JoinSourPartsNoWithHBegin = "";

        /// <summary>�������i��(�I��)</summary>
        private string _JoinSourPartsNoWithHEnd = "";

        /// <summary>���������[�J�[�R�[�h(�J�n)</summary>
        private Int32 _joinSourceMakerCodeBegin;

        /// <summary>���������[�J�[�R�[�h(�I��)</summary>
        private Int32 _joinSourceMakerCodeEnd;

        /// <summary>�����\������(�J�n)</summary>
        private Int32 _joinDispOrderBegin;

        /// <summary>�����\������(�I��)</summary>
        private Int32 _joinDispOrderEnd;

        /// <summary>�����惁�[�J�[�R�[�h(�J�n)</summary>
        private Int32 _joinDestMakerCodeBegin;

        /// <summary>�����惁�[�J�[�R�[�h(�I��)</summary>
        private Int32 _joinDestMakerCodeEnd;


        /// public propaty name  :  BeginningDate
        /// <summary>�J�n�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>�I�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHBegin
        /// <summary>�������i��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSourPartsNoWithHBeginRF
        {
            get { return _JoinSourPartsNoWithHBegin; }
            set { _JoinSourPartsNoWithHBegin = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHEnd
        /// <summary>�������i��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSourPartsNoWithHEndRF
        {
            get { return _JoinSourPartsNoWithHEnd; }
            set { _JoinSourPartsNoWithHEnd = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeBegin
        /// <summary>���������[�J�[�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������[�J�[�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeBeginRF
        {
            get { return _joinSourceMakerCodeBegin; }
            set { _joinSourceMakerCodeBegin = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeEnd
        /// <summary>���������[�J�[�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������[�J�[�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeEndRF
        {
            get { return _joinSourceMakerCodeEnd; }
            set { _joinSourceMakerCodeEnd = value; }
        }

        /// public propaty name  :  JoinDispOrderBegin
        /// <summary>�����\������(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDispOrderBeginRF
        {
            get { return _joinDispOrderBegin; }
            set { _joinDispOrderBegin = value; }
        }

        /// public propaty name  :  JoinDispOrderEnd
        /// <summary>�����\������(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDispOrderEndRF
        {
            get { return _joinDispOrderEnd; }
            set { _joinDispOrderEnd = value; }
        }

        /// public propaty name  :  JoinDestMakerCodeBegin
        /// <summary>�����惁�[�J�[�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDestMakerCodeBeginRF
        {
            get { return _joinDestMakerCodeBegin; }
            set { _joinDestMakerCodeBegin = value; }
        }

        /// public propaty name  :  JoinDestMakerCodeEnd
        /// <summary>�����惁�[�J�[�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDestMakerCodeEndRF
        {
            get { return _joinDestMakerCodeEnd; }
            set { _joinDestMakerCodeEnd = value; }
        }


        /// <summary>
        /// �����}�X�^���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>JoinPartsUProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   JoinPartsUProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APJoinPartsUProcParamWork()
        {
        }

    }
}