using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Broadleaf.Drawing.Printing
{
    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
    # region [ＱＲコード用データ生成クラス]
    /// <summary>
    /// ＱＲコード用データ生成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : ＱＲコードに印刷するデータ文字列を生成するクラスです。</br>
    /// <br>               </br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2010/03/24</br>
    /// <br></br>
    /// </remarks>
    public class QRDataCreator
    {
        /// <summary>
        /// ＱＲデータ生成（暗号化）
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public static string CreateData( string csvData )
        {
            string qrData = csvData;

            // 月別パスワード取得
            int month = DateTime.Now.Month;
            string passWord = GetPassWord( month );

            // 初期化ベクタ
            string vector = "BRLFQRNS";

            // データ暗号化＋BASE64エンコード
            qrData = DataEncrypt( qrData, passWord, vector, CipherMode.CBC );

            // 先頭にSF制御ｺｰﾄﾞ+月を付加する
            // （文字:^＝10進数:94＝16進数:5E）
            qrData = new string( '\x5E', 1 ) + "0010" + month.ToString( "00" ) + qrData;

            return qrData;
        }
        // --- ADD m.suzuki 2010/05/27 ---------->>>>>
        /// <summary>
        /// ＱＲデータ生成（暗号化）
        /// </summary>
        /// <param name="csvData"></param>
        /// <param name="isTest"></param>
        /// <returns></returns>
        public static string CreateDataForMail( string csvData, bool isTest )
        {
            string qrData = csvData;

            // 月別パスワード取得
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
            
            // 初期化ベクタ
            string vector = "BRLFQRNS";

            // データ暗号化＋BASE64エンコード
            qrData = DataEncrypt( qrData, passWord, vector, CipherMode.CBC );

            // 先頭にSF制御ｺｰﾄﾞ+月を付加する
            // （文字:^＝10進数:94＝16進数:5E）
            qrData = new string( '\x5E', 1 ) + "0011" + month.ToString( "00" ) + qrData;

            return qrData;

        }
        // --- ADD m.suzuki 2010/05/27 ----------<<<<<
        /// <summary>
        /// 暗号化処理（トリプルDES + BASE64エンコード）
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
            // バイト数の調整
            //---------------------------------------------

            // 元の文字列をバイト配列に格納
            byte[] buffer = enc.GetBytes( qrData );

            // 不足バイト数分を追加する為にリストに移す
            List<byte> bufList = new List<byte>( buffer );

            // 8ﾊﾞｲﾄで割り切れない場合は不足分を追加する。
            // 8ﾊﾞｲﾄで割り切れる場合は8ﾊﾞｲﾄ追加する。（結果的に同じ処理で良い）
            int addCount = 8 - (buffer.Length % 8);
            for ( int i = 0; i < addCount; i++ )
            {
                bufList.Add( 0 );
            }
            byte[] buffer2 = bufList.ToArray();

            using ( MemoryStream mem = new MemoryStream( buffer2, true ) )
            {
                // 最終バイト(の次)へ移動
                mem.Seek( buffer.Length, SeekOrigin.Begin );

                // 8ﾊﾞｲﾄで割り切れない時は,不足分を"不足しているﾊﾞｲﾄ数値"で埋める。
                // 8ﾊﾞｲﾄで割り切れる時は,8ﾊﾞｲﾄ分"08"を埋める。(結果的に同じ処理で良い)
                for ( int i = 0; i < addCount; i++ )
                {
                    // 0～8なのでbyteにキャストできる
                    mem.WriteByte( (byte)addCount );
                }

                // ポジションを先頭に戻す
                mem.Position = 0;


                //---------------------------------------------
                // トリプルＤＥＳ暗号化
                //---------------------------------------------

                // トリプルＤＥＳ暗号化サービスプロバイダ生成
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Mode = mode;
                tdes.Key = enc.GetBytes( passWord );
                tdes.IV = enc.GetBytes( vector );

                //DES復号化オブジェクトの作成
                System.Security.Cryptography.ICryptoTransform encryptor = tdes.CreateEncryptor();
                using ( MemoryStream outMem = new MemoryStream() )
                {
                    // 書き込むためのCryptoStreamの作成
                    CryptoStream cryptStreem = new CryptoStream( outMem, encryptor, CryptoStreamMode.Write );
                    // 書き込み
                    cryptStreem.Write( mem.ToArray(), 0, (int)mem.Length );

                    //---------------------------------------------
                    // BASE64エンコード
                    //---------------------------------------------

                    // 暗号化した結果をBASE64エンコードする
                    qrData = System.Convert.ToBase64String( outMem.ToArray() );


                    cryptStreem.Close();
                }
            }

            return qrData;
        }

        /// <summary>
        /// 暗号化パスワード取得（月別）
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private static string GetPassWord( int month )
        {
            switch ( month )
            {
                default:
                case 1: return "gksjasQeyｳdAｲ3ts";
                case 2: return "ejgafkflwｻﾁ4q6gw";
                case 3: return "prhqjgsLtﾙdDeﾏgr";
                case 4: return "skjddwJheﾜ5wdBdq";
                case 5: return "ihro7ycHnkoｹ8gﾋp";
                case 6: return "4fcplbMsbquUｻ8y5";
                case 7: return "pescvnb6vﾍxeFcTe";
                case 8: return "l9rg2xuvRｱv9zaｳ9";
                case 9: return "za58xs3nSzcﾗejsf";
                case 10: return "psk3gq68CqMnVhmb";
                case 11: return "lr1gaAh99ﾀsｻoﾛft";
                case 12: return "c5shmBsz2ﾌZk0hsﾄ";
            }
        }
    }
    # endregion

    # region [ＱＲデータ生成仲介クラス]
    /// <summary>
    /// ＱＲデータ生成仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : ＱＲコードのデータ文字列生成クラスを呼び出す為のクラスです。</br>
    /// <br>               実際にQRDataCreatorを呼び出す箇所は、継承先で実装します。</br>
    /// <br>               </br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2010/03/24</br>
    /// <br></br>
    /// </remarks>
    public class QRDataCreateMediator
    {
        # region [ＰＭユーザーコード取得処理]
        /// <summary>
        /// ＰＭユーザーコード取得
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

        # region [publicメソッド]
        /// <summary>
        /// データバイト数取得
        /// </summary>
        /// <param name="qrData"></param>
        /// <returns></returns>
        public static int GetByteCount( string qrData )
        {
            Encoding encoding = Encoding.GetEncoding( "Shift_JIS" );
            return encoding.GetByteCount( qrData );
        }
        /// <summary>
        /// ＱＲコードサイズ拡大率取得処理
        /// </summary>
        /// <param name="qrData"></param>
        /// <param name="maxByteCount"></param>
        /// <returns>拡大率(0.0～1.0)</returns>
        public static float GetQRCodeSizeRate( string qrData, int maxByteCount )
        {
            // バイト数を取得
            int byteCount = GetByteCount( qrData );

            // バイト数に応じて率を返す
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

        # region [汎用処理]
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        protected static string SubStringOfByte( string orgString, int byteCount )
        {
            Encoding encoding = Encoding.GetEncoding( "Shift_JIS" );

            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight( byteCount ).Substring( 0, byteCount );

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // 「文字数」を減らす
                resultString = orgString.Substring( 0, i );

                // バイト数を取得して判定
                count = encoding.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }

            // 終端の空白は削除
            return resultString.TrimEnd();
        }
        /// <summary>
        /// 文字列⇒数値変換
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
        /// 下桁(右側)取得処理
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
        /// 追加処理（数値）
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="intValue"></param>
        protected static void AppendTo( ref StringBuilder sb, int intValue )
        {
            sb.Append( "," );
            sb.Append( intValue );
        }
        /// <summary>
        /// 追加処理（文字列）
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
