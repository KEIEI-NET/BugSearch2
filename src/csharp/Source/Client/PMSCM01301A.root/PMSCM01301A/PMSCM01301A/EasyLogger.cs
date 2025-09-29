//****************************************************************************//
// �V�X�e��         : BLP���Аݒ�}�X�^�q�Ɉڍs
// �v���O��������   : BLP���Аݒ�}�X�^�q�Ɉڍs
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/12/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �ȈՃ��O�N���X
    /// </summary>
    /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()���Q�l</remarks>
    public static class EasyLogger
    {
        /// <summary>�f�t�H���g�����ݎҖ���(BLP���Аݒ�}�X�^�q�Ɉڍs)</summary>
        private const string DEFAULT_NAME = "PMSCM01300U";

        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        #region <��{���>

        /// <summary>���O�����ݎ҂̖���</summary>
        private static string _name = DEFAULT_NAME;
        /// <summary>���O�����ݎ҂̖��̂��擾���܂��B</summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// �t�@�C�����̂��擾���܂��B
        /// </summary>
        public static string FileName { get { return Name + ".log"; } }

        /// <summary>�G���R�[�h</summary>
        private static string _encode = DEFAULT_ENCODE;
        /// <summary>
        /// �G���R�[�h���擾���܂��B
        /// </summary>
        public static string Encode { get { return _encode; } }

        #endregion // </��{���>

        /// <summary>
        /// ���O���o�͂��܂��B
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()���Q�l</remarks>
        /// <param name="msg">���b�Z�[�W</param>
        public static void Write(
            string msg
        )
        {
            FileStream fileStream = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            writer.WriteLine(msg);
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }
    }
}
