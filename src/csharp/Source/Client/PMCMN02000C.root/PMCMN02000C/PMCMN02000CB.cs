using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Broadleaf.Drawing.Printing
{
    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
    # region [�p�q�R�[�h�p�f�[�^�����N���X]
    /// <summary>
    /// �p�q�R�[�h�p�f�[�^�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �p�q�R�[�h�Ɉ������f�[�^������𐶐�����N���X�ł��B</br>
    /// <br>               </br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2010/03/24</br>
    /// <br></br>
    /// </remarks>
    public class QRDataCreator
    {
        /// <summary>
        /// �p�q�f�[�^�����i�Í����j
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public static string CreateData( string csvData )
        {
            string qrData = csvData;

            // ���ʃp�X���[�h�擾
            int month = DateTime.Now.Month;
            string passWord = GetPassWord( month );

            // �������x�N�^
            string vector = "BRLFQRNS";

            // �f�[�^�Í����{BASE64�G���R�[�h
            qrData = DataEncrypt( qrData, passWord, vector, CipherMode.CBC );

            // �擪��SF���亰��+����t������
            // �i����:^��10�i��:94��16�i��:5E�j
            qrData = new string( '\x5E', 1 ) + "0010" + month.ToString( "00" ) + qrData;

            return qrData;
        }
        // --- ADD m.suzuki 2010/05/27 ---------->>>>>
        /// <summary>
        /// �p�q�f�[�^�����i�Í����j
        /// </summary>
        /// <param name="csvData"></param>
        /// <param name="isTest"></param>
        /// <returns></returns>
        public static string CreateDataForMail( string csvData, bool isTest )
        {
            string qrData = csvData;

            // ���ʃp�X���[�h�擾
            int month;
            string passWord;
            if ( !isTest )
            {
                month = DateTime.Now.Month;
                passWord = GetPassWord( month );
            }
            else
            {
                month = 0;
                passWord = string.Empty;
            }
            
            // �������x�N�^
            string vector = "BRLFQRNS";

            // �f�[�^�Í����{BASE64�G���R�[�h
            qrData = DataEncrypt( qrData, passWord, vector, CipherMode.CBC );

            // �擪��SF���亰��+����t������
            // �i����:^��10�i��:94��16�i��:5E�j
            qrData = new string( '\x5E', 1 ) + "0011" + month.ToString( "00" ) + qrData;

            return qrData;

        }
        // --- ADD m.suzuki 2010/05/27 ----------<<<<<
        /// <summary>
        /// �Í��������i�g���v��DES + BASE64�G���R�[�h�j
        /// </summary>
        /// <param name="qrData"></param>
        /// <param name="passWord"></param>
        /// <param name="vector"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private static string DataEncrypt( string qrData, string passWord, string vector, CipherMode mode )
        {
            Encoding enc = Encoding.GetEncoding( "Shift_JIS" );

            //---------------------------------------------
            // �o�C�g���̒���
            //---------------------------------------------

            // ���̕�������o�C�g�z��Ɋi�[
            byte[] buffer = enc.GetBytes( qrData );

            // �s���o�C�g������ǉ�����ׂɃ��X�g�Ɉڂ�
            List<byte> bufList = new List<byte>( buffer );

            // 8�޲ĂŊ���؂�Ȃ��ꍇ�͕s������ǉ�����B
            // 8�޲ĂŊ���؂��ꍇ��8�޲Ēǉ�����B�i���ʓI�ɓ��������ŗǂ��j
            int addCount = 8 - (buffer.Length % 8);
            for ( int i = 0; i < addCount; i++ )
            {
                bufList.Add( 0 );
            }
            byte[] buffer2 = bufList.ToArray();

            using ( MemoryStream mem = new MemoryStream( buffer2, true ) )
            {
                // �ŏI�o�C�g(�̎�)�ֈړ�
                mem.Seek( buffer.Length, SeekOrigin.Begin );

                // 8�޲ĂŊ���؂�Ȃ�����,�s������"�s�����Ă����޲Đ��l"�Ŗ��߂�B
                // 8�޲ĂŊ���؂�鎞��,8�޲ĕ�"08"�𖄂߂�B(���ʓI�ɓ��������ŗǂ�)
                for ( int i = 0; i < addCount; i++ )
                {
                    // 0�`8�Ȃ̂�byte�ɃL���X�g�ł���
                    mem.WriteByte( (byte)addCount );
                }

                // �|�W�V������擪�ɖ߂�
                mem.Position = 0;


                //---------------------------------------------
                // �g���v���c�d�r�Í���
                //---------------------------------------------

                // �g���v���c�d�r�Í����T�[�r�X�v���o�C�_����
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Mode = mode;
                tdes.Key = enc.GetBytes( passWord );
                tdes.IV = enc.GetBytes( vector );

                //DES�������I�u�W�F�N�g�̍쐬
                System.Security.Cryptography.ICryptoTransform encryptor = tdes.CreateEncryptor();
                using ( MemoryStream outMem = new MemoryStream() )
                {
                    // �������ނ��߂�CryptoStream�̍쐬
                    CryptoStream cryptStreem = new CryptoStream( outMem, encryptor, CryptoStreamMode.Write );
                    // ��������
                    cryptStreem.Write( mem.ToArray(), 0, (int)mem.Length );

                    //---------------------------------------------
                    // BASE64�G���R�[�h
                    //---------------------------------------------

                    // �Í����������ʂ�BASE64�G���R�[�h����
                    qrData = System.Convert.ToBase64String( outMem.ToArray() );


                    cryptStreem.Close();
                }
            }

            return qrData;
        }

        /// <summary>
        /// �Í����p�X���[�h�擾�i���ʁj
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private static string GetPassWord( int month )
        {
            switch ( month )
            {
                default:
                case 1: return "gksjasQey�dA�3ts";
                case 2: return "ejgafkflw��4q6gw";
                case 3: return "prhqjgsLt�dDe�gr";
                case 4: return "skjddwJhe�5wdBdq";
                case 5: return "ihro7ycHnko�8g�p";
                case 6: return "4fcplbMsbquU�8y5";
                case 7: return "pescvnb6v�xeFcTe";
                case 8: return "l9rg2xuvR�v9za�9";
                case 9: return "za58xs3nSzc�ejsf";
                case 10: return "psk3gq68CqMnVhmb";
                case 11: return "lr1gaAh99�s�o�ft";
                case 12: return "c5shmBsz2�Zk0hs�";
            }
        }
    }
    # endregion

    # region [�p�q�f�[�^��������N���X]
    /// <summary>
    /// �p�q�f�[�^��������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �p�q�R�[�h�̃f�[�^�����񐶐��N���X���Ăяo���ׂ̃N���X�ł��B</br>
    /// <br>               ���ۂ�QRDataCreator���Ăяo���ӏ��́A�p����Ŏ������܂��B</br>
    /// <br>               </br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2010/03/24</br>
    /// <br></br>
    /// </remarks>
    public class QRDataCreateMediator
    {
        # region [�o�l���[�U�[�R�[�h�擾����]
        /// <summary>
        /// �o�l���[�U�[�R�[�h�擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        protected static string GetUserCode( string enterpriseCode )
        {
            const int userCodeLength = 9;

            if ( enterpriseCode.Length >= userCodeLength )
            {
                string userCodeText = GetRight( enterpriseCode, userCodeLength );
                int userCodeNum = 0;
                try
                {
                    userCodeNum = Int32.Parse( userCodeText );
                }
                catch
                {
                }
                return userCodeNum.ToString( new string( '0', userCodeLength ) );
            }
            else
            {
                return new string( '0', userCodeLength );
            }
        }
        # endregion

        # region [public���\�b�h]
        /// <summary>
        /// �f�[�^�o�C�g���擾
        /// </summary>
        /// <param name="qrData"></param>
        /// <returns></returns>
        public static int GetByteCount( string qrData )
        {
            Encoding encoding = Encoding.GetEncoding( "Shift_JIS" );
            return encoding.GetByteCount( qrData );
        }
        /// <summary>
        /// �p�q�R�[�h�T�C�Y�g�嗦�擾����
        /// </summary>
        /// <param name="qrData"></param>
        /// <param name="maxByteCount"></param>
        /// <returns>�g�嗦(0.0�`1.0)</returns>
        public static float GetQRCodeSizeRate( string qrData, int maxByteCount )
        {
            // �o�C�g�����擾
            int byteCount = GetByteCount( qrData );

            // �o�C�g���ɉ����ė���Ԃ�
            if ( byteCount > maxByteCount )
            {
                // 100%
                return 1.0f;
            }
            else
            {
                return (float)byteCount / (float)maxByteCount;
            }
        }
        # endregion

        # region [�ėp����]
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        protected static string SubStringOfByte( string orgString, int byteCount )
        {
            Encoding encoding = Encoding.GetEncoding( "Shift_JIS" );

            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight( byteCount ).Substring( 0, byteCount );

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // �u�������v�����炷
                resultString = orgString.Substring( 0, i );

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }

            // �I�[�̋󔒂͍폜
            return resultString.TrimEnd();
        }
        /// <summary>
        /// ������ː��l�ϊ�
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        protected static int ToInt( string orgValue )
        {
            try
            {
                return Int32.Parse( orgValue );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// ����(�E��)�擾����
        /// </summary>
        /// <param name="orgValue"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected static string GetRight( string orgValue, int length )
        {
            if ( length < orgValue.Length )
            {
                return orgValue.Substring( orgValue.Length - length, length );
            }
            else
            {
                return orgValue;
            }
        }
        /// <summary>
        /// �ǉ������i���l�j
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="intValue"></param>
        protected static void AppendTo( ref StringBuilder sb, int intValue )
        {
            sb.Append( "," );
            sb.Append( intValue );
        }
        /// <summary>
        /// �ǉ������i������j
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="stringValue"></param>
        protected static void AppendTo( ref StringBuilder sb, string stringValue )
        {
            sb.Append( ",\"" );
            sb.Append( stringValue );
            sb.Append( "\"" );
        }
        # endregion
    }
    # endregion
    // --- ADD m.suzuki 2010/03/24 ----------<<<<<
}
