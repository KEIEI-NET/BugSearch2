// --- DEL m.suzuki 2010/04/06 ---------->>>>>
# region // DEL
//using System;
//using System.Collections.Generic;
//using System.Text;

//using Broadleaf.Application.UIData;
//using System.IO;
//using System.Security.Cryptography;
//using Broadleaf.Application.Controller;
//using Broadleaf.Library.Net;
//using System.Net;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace Broadleaf.Windows.Forms
//{
//    /// <summary>
//    /// ネットワーク通信テスト機能
//    /// </summary>
//    /// <remarks>
//    /// <br>Note       : ネットワーク通信テスト機能</br>
//    /// <br>Programmer : 23002 上野 耕平</br>
//    /// <br>Date       : 2008.04.04</br>
//    /// <br></br>
//    /// <br>Update Note:</br>
//    /// <br>Programmer :</br>
//    /// <br>Date       :</br>
//    /// </remarks>
//    public class NetWorkTest
//    {
//        #region コンストラクタ
//        /// <summary>
//        /// コンストラクタ
//        /// </summary>
//        public NetWorkTest()
//        {
//        }
//        #endregion

//        #region 通信テスト処理
//        /// <summary>
//        /// 通信テスト開始
//        /// </summary>
//        public void TestStart(object para)
//        {
//            #region 【処理時間計測】デバッグ用
//#if DEBUG
//            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
//            st.Start();
//#endif
//            #endregion

//            if( para == null )
//            {
//                return;
//            }

//            try
//            {
//                object[] paraArray = (object[])para;

//                string enterpriseCode = paraArray[0].ToString();
//                string productName    = paraArray[1].ToString();
//                string accessTicket   = paraArray[2].ToString();
//                string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath , "MenuSettings\\AppSettingData");
//                //テスト結果アップロードWEBサービスURL
//                string upLoadWebServiceUrl = "";

//                //テスト項目情報を取得する。
//                List<NSNetworkTestInfo> nSNetworkTestInfoList;
//                if( !NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, filePath, "SFNETMENU_Config2.dat") )
//                {
//                    return;
//                }

//                #region テスト項目毎にリスト分け
//                List<NSNetworkTestInfo> proxyTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.PROXY; });
//                List<NSNetworkTestInfo> netWorkTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType != NSNetworkTestInfo.ServerType.PROXY; });
//                #endregion

//                #region プロキシ
//                //●プロキシテスト・設定取得
//                ProxyInfo proxyInfo = NSNetworkTestAccess.CheckProxy();
//                foreach( NSNetworkTestInfo nSNetworkTestInfo in proxyTestList )
//                {
//                    if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST )
//                    {
//                        upLoadWebServiceUrl = nSNetworkTestInfo.NSNetworkTestTargetUri.ToString();
//                        continue;
//                    }
//                    nSNetworkTestInfo.ProxyInfo = proxyInfo;
//                    nSNetworkTestInfo.Ex = proxyInfo.Ex;
//                    if( proxyInfo.Ex != null )
//                    {
//                        WebException webex = (WebException)proxyInfo.Ex;
//                        if( webex.Response == null )
//                        {
//                            //ステータスコードが分からない例外は全て「-1」とする。
//                            nSNetworkTestInfo.WebRequestStatusNo = -1;
//                        }
//                        else
//                        {
//                            //HTTPリクエストのステータスをセット
//                            nSNetworkTestInfo.WebRequestStatusNo = (int)( (HttpWebResponse)webex.Response ).StatusCode;
//                        }
//                    }
//                }
//                #endregion

//                //テスト実行
//                TestProc(proxyInfo, netWorkTestList);
                
//                string accessKey = string.Format("{0}_{1}_{2}", enterpriseCode, productName, accessTicket);

//                //テスト結果の保存（True:WEBサービス経由、False：ローカル保存）
//                bool status = NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList,upLoadWebServiceUrl, accessKey, true, "", "");
//                if( status )
//                {
//                    //
//                    List<NSNetworkTestInfo> workList = new List<NSNetworkTestInfo>();
//                    //WEB経由での保存が成功した場合、次回からテストを行わないように空のDATを上書きする。
//                    //テスト結果の保存（True:WEBサービス経由、False：ローカル保存）
//                    NSNetworkTestInfoList_Serialize(workList, upLoadWebServiceUrl, accessKey, false, filePath, "SFNETMENU_Config2.dat");
//                }
//            }
//            catch(Exception ex)
//            {
//                //ここでのエラーは無視する。
//                #region 【エラーメッセージ表示】デバッグ用
//#if DEBUG
//            System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
//#endif
//                #endregion
//            }

//            #region 【処理時間計測】デバッグ用
//            #if DEBUG
//            st.Stop();
//            System.Windows.Forms.MessageBox.Show(st.Elapsed.TotalSeconds.ToString());
//            #endif
//            #endregion
//        }

//        /// <summary>
//        /// 通信テスト実行部
//        /// </summary>
//        /// <param rKeyName="proxyInfo"></param>
//        /// <param rKeyName="nSNetworkTestInfoList"></param>
//        /// <returns></returns>
//        private bool TestProc(ProxyInfo proxyInfo, List<NSNetworkTestInfo> nSNetworkTestInfoList)
//        {
//            bool result = true;

//            //各種テストを行う。
//            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
//            {
//                //●テストを行わない。
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST )
//                {
//                    nSNetworkTestInfo.CheckResult = false;
//                    continue;
//                }

//                #region BITS
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS )
//                {
//                    //BITS（WINHTTP)のプロキシ設定を取得
//                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
//                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
//                }
//                else
//                {
//                    nSNetworkTestInfo.ProxyInfo = proxyInfo;
//                }

//                #endregion

//                #region HTTP
//                //●HTTPリクエストテストを行う。
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.HTTPREQUEST )
//                {
//                    if( NSNetworkTestAccess.HttpRequest(nSNetworkTestInfo) )
//                    {
//                        nSNetworkTestInfo.CheckResult = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        nSNetworkTestInfo.CheckResult = false;
//                    }
//                }
//                #endregion

//                #region ポート
//                //●ポート接続テストを行う。
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.PORTCONNECT )
//                {
//                    if( NSNetworkTestAccess.CheckPort(nSNetworkTestInfo) )
//                    {
//                        nSNetworkTestInfo.CheckResult = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        nSNetworkTestInfo.CheckResult = false;
//                    }
//                }
//                #endregion

//                #region BITS
//                //●BITS配信テストを行う。
//                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS )
//                {
//                    //BITS（WINHTTP)のプロキシ設定を取得
//                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
//                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
//                    if( BitsMng.Download(nSNetworkTestInfo) )
//                    {
//                        nSNetworkTestInfo.CheckResult = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        nSNetworkTestInfo.CheckResult = false;
//                    }
//                }
//                #endregion

//            }
//            return result;
//        }

//        #endregion

//        #region データクラス保存、読み込み処理
//        /// <summary>
//        /// データクラス読み込み
//        /// </summary>
//        /// <param rKeyName="nSNetworkTestInfoList"></param>
//        /// <param rKeyName="filePath"></param>
//        /// <param rKeyName="fileName"></param>
//        /// <returns></returns>
//        private bool NSNetworkTestInfoList_Deserialize(out List<NSNetworkTestInfo> nSNetworkTestInfoList,string filePath, string fileName)
//        {
//            bool result = false;
//            nSNetworkTestInfoList = null;
//            //読込対象ファイルのフルパス
//            string fileFullName = Path.Combine(filePath, fileName);
//            try
//            {
//                if( !File.Exists(fileFullName) )
//                {
//                    return result;
//                }

//                byte[] desKey;
//                byte[] desIv;
//                byte[] resultBytes;
//                byte[] dataBytes;

//                resultBytes = FileReadProc(fileFullName, out desKey, out desIv);
//                dataBytes = CompoundDataProc(resultBytes, desKey, desIv);
//                using( MemoryStream r = new MemoryStream() )
//                {
//                    r.Write(dataBytes, 0, dataBytes.Length);
//                    r.Position = 0;
//                    BinaryFormatter binaryFormatter = new BinaryFormatter();
//                    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(r);
//                }
//                if( nSNetworkTestInfoList != null && nSNetworkTestInfoList.Count > 0 )
//                {
//                    result = true;
//                }
//                else
//                {
//                    result = false;
//                }
//            }
//            catch( Exception ex )
//            {
//                result = false;
//                nSNetworkTestInfoList = null;
//            }
//            return result;
//        }

//        /// <summary>
//        /// ファイル読込処理
//        /// </summary>
//        /// <param rKeyName="fileFullName">読込ファイルフルパス</param>
//        /// <param rKeyName="desKey">暗号化キー</param>
//        /// <param rKeyName="desIv">暗号化キー</param>
//        /// <returns>読込結果</returns>
//        private byte[] FileReadProc(string fileFullName, out byte[] desKey, out byte[] desIv)
//        {
//            desKey = null;
//            desIv = null;
//            byte[] result = null;

//            //ファイルが存在しない場合終了
//            if( !File.Exists(fileFullName) )
//            {
//                return result;
//            }

//            using( FileStream fileStream = new FileStream(fileFullName, FileMode.Open) )
//            {
//                using(BinaryReader binaryReader = new BinaryReader(fileStream))
//                {
//                    RijndaelManaged rijndaelManaged = new RijndaelManaged();
                    
//                    desKey = binaryReader.ReadBytes((int)rijndaelManaged.Key.Length);
//                    desIv  = binaryReader.ReadBytes((int)rijndaelManaged.IV.Length);
//                    result = binaryReader.ReadBytes((int)( fileStream.Length - ( rijndaelManaged.Key.Length + rijndaelManaged.IV.Length ) ));
//                    binaryReader.Close();
//                }
//                fileStream.Close();
//            }

//            return result;
//        }

//        /// <summary>
//        /// 複合化処理
//        /// </summary>
//        /// <param rKeyName="data">複合化対象データ</param>
//        /// <param rKeyName="desKey">暗号化KEY</param>
//        /// <param rKeyName="desIv">暗号化KEY</param>
//        /// <returns>複合結果</returns>
//        private byte[] CompoundDataProc(byte[] data, byte[] desKey, byte[] desIv)
//        {
//            // Trippe DES のサービス プロバイダを生成します
//            RijndaelManaged rijndaelManaged = new RijndaelManaged();
//            byte[] destination;

//            // 入出力用のストリームを生成します
//            using( MemoryStream ms = new MemoryStream() )
//            {
//                CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateDecryptor(desKey, desIv), CryptoStreamMode.Write);

//                // ストリームに暗号化されたデータを書き込みます
//                cs.Write(data, 0, data.Length);
//                cs.Close();

//                // 復号化されたデータを byte 配列で取得します
//                destination = ms.ToArray();
//                ms.Close();
//            }
//            return destination;
//        }

//        /// <summary>
//        /// データクラス保存
//        /// </summary>
//        /// <param rKeyName="nSNetworkTestInfoList"></param>
//        /// <returns></returns>
//        private bool NSNetworkTestInfoList_Serialize(List<NSNetworkTestInfo> nSNetworkTestInfoList,string upLoadWebServiceUrl, string accessKey, bool saveType, string filePath, string fileName)
//        {
//            bool result = false;
            
//            try
//            {
//                using( MemoryStream memoryStream = new MemoryStream() )
//                {
//                    BinaryFormatter binaryFormatter = new BinaryFormatter();
//                    binaryFormatter.Serialize(memoryStream, nSNetworkTestInfoList);

//                    byte[] aeskey;
//                    byte[] aesIV;
//                    byte[] encryptByts;

//                    //暗号化処理
//                    encryptByts = EncryptionDataProc(memoryStream.ToArray(), out aeskey, out aesIV);


//                    //WEBサービスでアップロードを行うかどうか
//                    if( saveType )
//                    {
//                        //WEBサービスに渡す用
//                        byte[] output = new byte[aeskey.Length + aesIV.Length + encryptByts.Length];
//                        for( int ix = 0; ix < aeskey.Length; ix++ )
//                        {
//                            output[ix] = aeskey[ix];
//                        }
//                        for( int ix = 0; ix < aesIV.Length; ix++ )
//                        {
//                            output[aeskey.Length + ix] = aesIV[ix];
//                        }
//                        for( int ix = 0; ix < encryptByts.Length; ix++ )
//                        {
//                            output[aeskey.Length + aesIV.Length + ix] = encryptByts[ix];
//                        }


//                        //テスト結果送信用WEBサービス
//                        SFCMN07000AService nsNetworkTestService = new SFCMN07000AService(upLoadWebServiceUrl);
//                        //BASIC認証用USERとPASSWORDをセットする。
//                        //nsNetworkTestService.Credentials = new NetworkCredential("SFCMN07001UA_Up", "JqSn/2E7snMiU");

//                        //テスト結果のアップロード
//                        result = nsNetworkTestService.NSNetworkTestUpload(accessKey, output);
//                    }
//                    else
//                    {
//                        if( !Directory.Exists(filePath) )
//                        {
//                            Directory.CreateDirectory(filePath);
//                        }
//                        result = FileSaveProc(encryptByts, filePath, fileName, aeskey, aesIV);
//                    }
//                }
//            }
//            catch( Exception ex )
//            {
//                result = false;
//                //MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIGSAVE_NG);
//            }

//            return result;
//        }

//        /// <summary>
//        /// 暗号化処理
//        /// </summary>
//        /// <param rKeyName="data">暗号化対象データ</param>
//        /// <param rKeyName="desKey">暗号化KEY</param>
//        /// <param rKeyName="desIv">暗号化KEY</param>
//        /// <returns>暗号結果</returns>
//        private byte[] EncryptionDataProc(byte[] data, out byte[] aesKey, out byte[] aesIv)
//        {
//            // AES暗号化部品を生成します
//            RijndaelManaged rijndaelManaged = new RijndaelManaged();
//            aesKey = rijndaelManaged.Key;
//            aesIv = rijndaelManaged.IV;

//            // 入出力用のストリームを生成します
//            MemoryStream ms = new MemoryStream();
//            CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateEncryptor(aesKey, aesIv), CryptoStreamMode.Write);

//            // ストリームに暗号化するデータを書き込みます
//            cs.Write(data, 0, data.Length);
//            cs.Close();

//            // 暗号化されたデータを byte 配列で取得します
//            byte[] destination = ms.ToArray();
//            ms.Close();

//            return destination;
//        }

//        /// <summary>
//        /// ファイル保存処理
//        /// </summary>
//        /// <param rKeyName="encryptionData">保存データ</param>
//        /// <param rKeyName="logFilePath">保存ファイルパス</param>
//        /// <param rKeyName="logFileName">保存ファイル名称</param>
//        /// <param rKeyName="desKey">暗号化キー</param>
//        /// <param rKeyName="desIv">暗号化キー</param>
//        private bool FileSaveProc(byte[] encryptionData, string filePath, string fileName, byte[] desKey, byte[] desIv)
//        {
//            bool result = false;
//            //保存用ディレクトリが無い場合は作成
//            if( !Directory.Exists(filePath) )
//            {
//                Directory.CreateDirectory(filePath);
//            }

//            //フルパス取得
//            string fileFullPath = Path.Combine(filePath, fileName);

//            //①既に存在する場合
//            if( File.Exists(fileFullPath) )
//            {
//                //②属性を書き込み可能に変更
//                File.SetAttributes(fileFullPath, FileAttributes.Normal);
//            }

//            //ファイル保存
//            using( FileStream fileStream = File.Create(fileFullPath) )
//            {
//                //③ファイル書き込み
//                fileStream.Write(desKey, 0, desKey.Length);
//                fileStream.Write(desIv, 0, desIv.Length);
//                fileStream.Write(encryptionData, 0, encryptionData.Length);
//                fileStream.Close();
//                result = true;
//            }
//            return result;
//        }

//        #endregion
//    }
//}
# endregion
// --- DEL m.suzuki 2010/04/06 ----------<<<<<
