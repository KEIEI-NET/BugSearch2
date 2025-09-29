//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�`�[�ԍ��ϊ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@�`�[�ԍ��ϊ��f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓`�[�ԍ��ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/12</br>
    /// </remarks>
    public class SlipNOConvertDispInfo
    {
        #region -- Member --

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        private int noCode = 0;
        /// <summary>�ԍ��R�[�h����(�����Ώ۔ԍ�)</summary>
        private string noCodeName = String.Empty;
        /// <summary>�ԍ����ݒl</summary>
        private Int64 noPresentVal = 0;
        /// <summary>�ݒ�J�n�ԍ�</summary>
        private Int64 settingStartNo = 0;
        /// <summary>�ݒ�I���ԍ�</summary>
        private Int64 settingEndNo = 0;
        /// <summary>�ԍ������l</summary>
        private Int64 noIncDecWidth = 0;

        #endregion

        #region -- Property --

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        public int NoCode
        {
            get { return noCode; }
            set { noCode = value; }
        }
        
        /// <summary>�ԍ��R�[�h����(�����Ώ۔ԍ�)</summary>
        public string NoCodeName
        {
            get { return noCodeName; }
            set { noCodeName = value; }
        }

        /// <summary>�ԍ����ݒl</summary>
        public Int64 NoPresentVal
        {
            get { return noPresentVal; }
            set { noPresentVal = value; }
        }

        /// <summary>�ݒ�J�n�ԍ�</summary>
        public Int64 SettingStartNo
        {
            get { return settingStartNo; }
            set { settingStartNo = value; }
        }

        /// <summary>�ݒ�I���ԍ�</summary>
        public Int64 SettingEndNo
        {
            get { return settingEndNo; }
            set { settingEndNo = value; }
        }

        /// <summary>�ԍ������l</summary>
        public Int64 NoIncDecWidth
        {
            get { return noIncDecWidth; }
            set { noIncDecWidth = value; }
        }


        #endregion
    }
}
