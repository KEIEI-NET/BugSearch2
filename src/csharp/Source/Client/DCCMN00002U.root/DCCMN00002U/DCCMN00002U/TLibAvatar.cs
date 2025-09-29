using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// TLib��s�N���X
    /// </summary>
    /// <remarks>SFCMN00001U��Internal�N���X TLib �Ɠ����ȕ����`�F�b�N������񋟂��܂��B</remarks>
    public class TLibAvatar
    {
        # region [�������p�^�[��]
        /// <summary>
        /// �������p�^�[��
        /// </summary>
        public struct EnableChars
        {
            /// <summary>�X�y�[�X����</summary>
            private bool _space;
            /// <summary>�L������</summary>
            private bool _sign;
            /// <summary>�p������</summary>
            private bool _alpha;
            /// <summary>�J�i����</summary>
            private bool _kana;
            /// <summary>���l����</summary>
            private bool _num;
            /// <summary>���l�L������</summary>
            private bool _numSign;
            /// <summary>�S�p��������</summary>
            private bool _word;
            /// <summary>
            /// �X�y�[�X����
            /// </summary>
            public bool Space
            {
                get { return _space; }
                set { _space = value; }
            }
            /// <summary>
            /// �L������
            /// </summary>
            public bool Sign
            {
                get { return _sign; }
                set { _sign = value; }
            }
            /// <summary>
            /// �p������
            /// </summary>
            public bool Alpha
            {
                get { return _alpha; }
                set { _alpha = value; }
            }
            /// <summary>
            /// �J�i����
            /// </summary>
            public bool Kana
            {
                get { return _kana; }
                set { _kana = value; }
            }
            /// <summary>
            /// ���l����
            /// </summary>
            public bool Num
            {
                get { return _num; }
                set { _num = value; }
            }
            /// <summary>
            /// ���l�L������
            /// </summary>
            public bool NumSign
            {
                get { return _numSign; }
                set { _numSign = value; }
            }
            /// <summary>
            /// �S�p��������
            /// </summary>
            public bool Word
            {
                get { return _word; }
                set { _word = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="space">�X�y�[�X����</param>
            /// <param name="sign">�L������</param>
            /// <param name="alpha">�p������</param>
            /// <param name="kana">�J�i����</param>
            /// <param name="num">���l����</param>
            /// <param name="numSign">���l�L������</param>
            /// <param name="word">�S�p��������</param>
            public EnableChars( bool space, bool sign, bool alpha, bool kana, bool num, bool numSign, bool word )
            {
                _space = space;
                _sign = sign;
                _alpha = alpha;
                _kana = kana;
                _num = num;
                _numSign = numSign;
                _word = word;
            }
        }
        # endregion

        # region [public static methods]
        /// <summary>
        /// �������`�F�b�N����
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="enableChars">�������p�^�[��</param>
        /// <returns>true: ���v���� / false: ���v���Ȃ�</returns>
        public static bool CheckCharactor( char key, EnableChars enableChars )
        {
            // �󔒏��O
            if ( !enableChars.Space && (key == ' ') )
            {
                return false;
            }
            // �L�����O
            if ( !enableChars.Sign && TLibAvatar.IsSign( key ) )
            {
                return false;
            }
            // �p�����O
            if ( !enableChars.Alpha && TLibAvatar.IsAlpha( key ) )
            {
                return false;
            }
            // ���p�J�i���O
            if ( !enableChars.Kana && TLibAvatar.IsKana( key ) )
            {
                return false;
            }
            // �������O
            if ( !enableChars.Num && TLibAvatar.IsNum( key ) )
            {
                return false;
            }
            // ���l�L�����O
            if ( !enableChars.NumSign && TLibAvatar.IsNumSign( key ) )
            {
                return false;
            }
            // �S�p�������O
            if ( !enableChars.Word && TLibAvatar.IsWord( key ) )
            {
                return false;
            }
            // �V���O���N�H�[�e�[�V�����͏�ɏ��O
            if ( key == '\'' )
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// �A���t�@�x�b�g����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsAlpha( char key )
        {
            char[] arChk = new char[] 
            { 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 
                'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
                'w', 'x', 'y', 'z'
            };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// ���䕶������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsCtrl( char key )
        {
            return char.IsControl( key );
        }
        /// <summary>
        /// ���p�Ŕ���
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKana( char key )
        {
            char[] arChk = new char[] 
            { 
                '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', 
                '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', 
                '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', 
                '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�'
            };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// ���l����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsNum( char key )
        {
            char[] arChk = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// ���l�L������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsNumSign( char key )
        {
            char[] arChk = new char[] { '-', '/', '*', '+', '=', '.', ',' };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// �L������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsSign( char key )
        {
            char[] arChk = new char[] 
            { 
                '!', '"', '#', '$', '%', '&', '\'', '(', ')', ':', ';', '<', '>', '?', '@', '[', 
                '\\', ']', '^', '{', '|', '}', '~', '_'
            };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// �S�p��������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsWord( char key )
        {
            return ((((!IsSign( key ) && (key != ' ')) && (!IsKana( key ) && !IsAlpha( key ))) && (!IsNumSign( key ) && !IsNum( key ))) && !IsCtrl( key ));
        }
        # endregion

        # region [private static methods]
        /// <summary>
        /// �����`�F�b�N��������
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arChk"></param>
        /// <returns></returns>
        private static bool IsCharCheck( char key, char[] arChk )
        {
            if ( arChk != null )
            {
                for ( int i = 0; i < arChk.Length; i++ )
                {
                    if ( arChk[i] == key )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        # endregion
    }
}
