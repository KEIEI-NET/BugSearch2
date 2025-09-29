using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.NSNetworkChk.Data;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Broadleaf.NSNetworkTest.UI
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();

            ((DataGridViewComboBoxColumn)this.dataGridView1.Columns[2]).Items.AddRange(new object[] {NSNetworkTestInfo.ServerType.AP,
            NSNetworkTestInfo.ServerType.BITS,
            NSNetworkTestInfo.ServerType.PROXY,
            NSNetworkTestInfo.ServerType.WEB});

            ((DataGridViewComboBoxColumn)this.dataGridView1.Columns[3]).Items.AddRange(new object[] {NSNetworkTestInfo.TestType.BITS,
            NSNetworkTestInfo.TestType.HTTPREQUEST,
            NSNetworkTestInfo.TestType.NONE_TEST,
            NSNetworkTestInfo.TestType.PORTCONNECT});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<NSNetworkTestInfo> nSNetworkTestInfoList = new List<NSNetworkTestInfo>();

            NSNetworkTestInfo nSNetworkTestInfo = new NSNetworkTestInfo();
            #region SF
            
            /*
            //開発用
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト", new Uri("http://www.broadleaf.co.jp")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "認証AP接続テスト", new Uri("http://10.20.150.168/ubawebservice/ubawebservice.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://10.20.150.168/bauwebservice/bauwebservice.asmx")));

            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://10.20.150.168/bauwebservice/bauwebservice.asx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("http://10.20.150.207:20001")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://10.20.152.209:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("http://10.20.150.207:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://10.20.150.209:20000")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト", new Uri("http://10.20.150.211:20000")));

            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://10.20.150.130/BAUContents/2e3ee5ce580c45a1a1afb1b23328c15c.zip")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://tsubasa-sfauth")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "変更PG案内AP接続テスト", new Uri("http://tsubasa-sfauth/NSChangeInfo")));
            */

            ////本番用
            
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト", new Uri("http://www.broadleaf.co.jp")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "認証AP接続テスト", new Uri("http://www32.superfrontman.net/ubawebservice/ubawebservice.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://www31.superfrontman.net/bauwebservice/bauwebservice.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("https://www34.superfrontman.net:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト２", new Uri("http://www34.superfrontman.net:20001")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://www33.superfrontman.net:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト", new Uri("http://www36.superfrontman.net:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://www35.superfrontman.net")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "変更PG案内AP接続テスト", new Uri("http://www35.superfrontman.net/NSChangeInfo")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "コンバートAP接続テスト", new Uri("http://www37.superfrontman.net")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "DPLAP接続テスト", new Uri("https://www42.superfrontman.net/DPLroot/SFMIT07160W.aspx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "TSPAP接続テスト", new Uri("http://www41.superfrontman.net/TSProot/TSPService.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXWEB01接続テスト", new Uri("http://www8.vxns.net/vxroot/err403.html")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXWEB02接続テスト", new Uri("http://www.vxns.net/salescar/err403.html")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "carpod接続テスト", new Uri("http://www.carpod.jp/error.html")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://www31.superfrontman.net/BAUContents/bfa16f20b6b546f1b32587575f106381.zip")));
            

            ////新サーバー用
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト", new Uri("http://www.broadleaf.co.jp")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "認証AP接続テスト", new Uri("http://210.174.179.36/ubawebservice/ubawebservice.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://210.174.179.39/bauwebservice/bauwebservice.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("http://210.174.179.57:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://210.174.179.60:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト", new Uri("http://210.174.179.66:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://210.174.179.48")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "変更PG案内AP接続テスト", new Uri("http://210.174.179.48/NSChangeInfo")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "コンバートAP接続テスト", new Uri("http://210.174.179.69/SCIWebService/SCIWEBSERVICE.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "DPLAP接続テスト", new Uri("http://210.174.179.63/TSProot/TSPservice.asmx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "TSPAP接続テスト", new Uri("http://210.174.179.63/DPLroot/SFMIT07160W.aspx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXWEB01接続テスト", new Uri("http://www8.vxns.net/vxroot/err403.html")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXWEB02接続テスト", new Uri("http://www.vxns.net/salescar/err403.html")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "carpod接続テスト", new Uri("http://www.carpod.jp/error.html")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://www31.superfrontman.net/BAUContents/bfa16f20b6b546f1b32587575f106381.zip")));


            //ＦＥ環境用
            /*
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト", new Uri("http://www.broadleaf.co.jp")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "認証AP接続テスト", new Uri("http://www40.superfrontman.net/ubawebservice/ubawebservice.asmx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://www40.superfrontman.net/bauwebservice/bauwebservice.asmx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("http://www40.superfrontman.net:20001")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://www40.superfrontman.net:20002")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト", new Uri("http://www40.superfrontman.net:20003")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://www40.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "変更PG案内AP接続テスト", new Uri("http://www40.superfrontman.net/NSChangeInfo")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "コンバートAP接続テスト", new Uri("http://www37.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "DPLAP接続テスト", new Uri("http://www42.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "TSPAP接続テスト", new Uri("http://www41.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXWEB01接続テスト", new Uri("http://www8.vxns.net/vxroot/err403.html")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXWEB02接続テスト", new Uri("http://www.vxns.net/salescar/err403.html")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "carpod接続テスト", new Uri("http://www.carpod.jp/error.html")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://www40.superfrontman.net/BAUContents/11393f53b2824804b1eb2b3fb47f219e.zip")));
            */


            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.TestType.FULL_TEST, "テストAP接続テスト",           new Uri("http://www40.superfrontman.net:20000")));
            
            #endregion

            #region TR
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト"     , new Uri("http://www.broadleaf.co.jp")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST  , "認証AP接続テスト"       , new Uri("http://www32.superfrontman.net/ubawebservice/ubawebservice.asmx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST  , "配信AP接続テスト"       , new Uri("http://www31.superfrontman.net/bauwebservice/bauwebservice.asmx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("https://user01.traveroute.jp:20001")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト２", new Uri("https://user01.traveroute.jp:443")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://off01.traveroute.jp:20001")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト２", new Uri("http://off01.traveroute.jp:80")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト", new Uri("http://useroffimg01.traveroute.jp:20001")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト２", new Uri("http://useroffimg01.traveroute.jp:80")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://blc.norikae-xml.jp:80")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://www31.superfrontman.net/BAUContents/7be88b8006e94321a38754c24e2b9753.zip")));

            #endregion


            NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList, "NSNetworkTest.bin");


            List<NSNetworkTestInfo> loadTestList;
            NSNetworkTestInfoList_Deserialize(out loadTestList, Path.Combine(Application.StartupPath, "Result") + "\\NSNetworkTest.bin");

            if( nSNetworkTestInfoList.Count == loadTestList.Count )
            {
                MessageBox.Show("OK");
            }
            else
            {

                MessageBox.Show("NG");
            }
        }





        #region データクラス保存、読み込み処理
        /// <summary>
        /// データクラス読み込み
        /// </summary>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool NSNetworkTestInfoList_Deserialize(out List<NSNetworkTestInfo> nSNetworkTestInfoList, string fileName)
        {
            bool result = false;
            nSNetworkTestInfoList = null;
            try
            {
                //using( FileStream fileStream = new FileStream(fileName, FileMode.Open) )
                //{
                //    BinaryFormatter binaryFormatter = new BinaryFormatter();
                //    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(fileStream);
                //}

                byte[] desKey;
                byte[] desIv;
                byte[] resultBytes;
                byte[] dataBytes;

                resultBytes = FileReadProc("", fileName, out desKey, out desIv);
                dataBytes = CompoundDataProc(resultBytes, desKey, desIv);
                using( MemoryStream r = new MemoryStream() )
                {
                    r.Write(dataBytes, 0, dataBytes.Length);
                    r.Position = 0;
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(r);
                }
                result = true;
            }
            catch( Exception ex )
            {
                nSNetworkTestInfoList = null;
                MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIGLOAD_NG);
            }
            return result;
        }

        /// <summary>
        /// ファイル読込処理
        /// </summary>
        /// <param name="logFilePath">保存ファイルパス</param>
        /// <param name="logFileName">保存ファイル名称</param>
        /// <param name="desKey">暗号化キー</param>
        /// <param name="desIv">暗号化キー</param>
        /// <returns>読込結果</returns>
        private byte[] FileReadProc(string logFilePath, string logFileName, out byte[] desKey, out byte[] desIv)
        {
            desKey = null;
            desIv = null;
            byte[] result = null;

            //フルパス取得
            string logFileFullPath = logFileName;

            ////保存用ディレクトリが無い場合は終了
            //if( !Directory.Exists(logFilePath) )
            //    return result;

            ////フルパス取得
            //string logFileFullPath = Path.Combine(logFilePath, logFileName);

            //①画像情報が存在しない場合終了
            if( !File.Exists(logFileFullPath) )
                return result;

            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();

                fs = new FileStream(logFileFullPath, FileMode.Open);
                //①ファイル読み込み
                br = new BinaryReader(fs);
                desKey = br.ReadBytes((int)rijndaelManaged.Key.Length);
                desIv = br.ReadBytes((int)rijndaelManaged.IV.Length);
                result = br.ReadBytes((int)( fs.Length - ( rijndaelManaged.Key.Length + rijndaelManaged.IV.Length ) ));
                br.Close();
                br = null;
                fs.Close();
                fs = null;
            }
            catch( Exception ex )
            {
                if( br != null )
                    br.Close();
                if( fs != null )
                    fs.Close();
                throw new Exception(string.Format("ファイルの読込に失敗しました。Exception:{0}  FilePath:{1}", ex.Message, logFileFullPath), ex);
            }
            finally
            {
                if( br != null )
                    br.Close();
                if( fs != null )
                    fs.Close();
            }
            return result;
        }

        /// <summary>
        /// 複合化処理
        /// </summary>
        /// <param name="data">複合化対象データ</param>
        /// <param name="desKey">暗号化KEY</param>
        /// <param name="desIv">暗号化KEY</param>
        /// <returns>複合結果</returns>
        private byte[] CompoundDataProc(byte[] data, byte[] desKey, byte[] desIv)
        {
            // Trippe DES のサービス プロバイダを生成します
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] destination;

            // 入出力用のストリームを生成します
            using( MemoryStream ms = new MemoryStream() )
            {
                CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateDecryptor(desKey, desIv), CryptoStreamMode.Write);

                // ストリームに暗号化されたデータを書き込みます
                cs.Write(data, 0, data.Length);
                cs.Close();

                // 復号化されたデータを byte 配列で取得します
                destination = ms.ToArray();
                ms.Close();
            }
            return destination;
        }

        /// <summary>
        /// データクラス保存
        /// </summary>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool NSNetworkTestInfoList_Serialize(List<NSNetworkTestInfo> nSNetworkTestInfoList, string fileName)
        {
            bool result = false;
            string resultPath = Path.Combine(Application.StartupPath, "Result");
            //string saveFileName = Path.Combine(resultPath, fileName);

            try
            {
                //if( !Directory.Exists(resultPath) )
                //{
                //    Directory.CreateDirectory(resultPath);
                //}

                using( MemoryStream memoryStream = new MemoryStream() )
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(memoryStream, nSNetworkTestInfoList);

                    byte[] g;
                    byte[] h;
                    byte[] i;

                    i = EncryptionDataProc(memoryStream.ToArray(), out g, out h);
                    FileSaveProc(i, resultPath, fileName, g, h);
                }
                result = true;
            }
            catch( Exception ex )
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIGSAVE_NG);
            }

            return result;
        }

        /// <summary>
        /// 暗号化処理
        /// </summary>
        /// <param name="data">暗号化対象データ</param>
        /// <param name="desKey">暗号化KEY</param>
        /// <param name="desIv">暗号化KEY</param>
        /// <returns>暗号結果</returns>
        private byte[] EncryptionDataProc(byte[] data, out byte[] aesKey, out byte[] aesIv)
        {
            // AES暗号化部品を生成します
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            aesKey = rijndaelManaged.Key;
            aesIv = rijndaelManaged.IV;

            // 入出力用のストリームを生成します
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateEncryptor(aesKey, aesIv), CryptoStreamMode.Write);

            // ストリームに暗号化するデータを書き込みます
            cs.Write(data, 0, data.Length);
            cs.Close();

            // 暗号化されたデータを byte 配列で取得します
            byte[] destination = ms.ToArray();
            ms.Close();

            return destination;
        }

        /// <summary>
        /// ファイル保存処理
        /// </summary>
        /// <param name="encryptionData">保存データ</param>
        /// <param name="logFilePath">保存ファイルパス</param>
        /// <param name="logFileName">保存ファイル名称</param>
        /// <param name="desKey">暗号化キー</param>
        /// <param name="desIv">暗号化キー</param>
        private void FileSaveProc(byte[] encryptionData, string logFilePath, string logFileName, byte[] desKey, byte[] desIv)
        {
            //保存用ディレクトリが無い場合は作成
            if( !Directory.Exists(logFilePath) )
                Directory.CreateDirectory(logFilePath);

            //フルパス取得
            string logFileFullPath = Path.Combine(logFilePath, logFileName);

            //①画像情報が既に存在する場合
            if( File.Exists(logFileFullPath) )
            {
                //②属性を書き込み可能に変更
                File.SetAttributes(logFileFullPath, FileAttributes.Normal);
            }

            //ファイル保存
            FileStream fs = null;
            try
            {
                //③ファイル書き込み
                fs = File.Create(logFileFullPath);
                fs.Write(desKey, 0, desKey.Length);
                fs.Write(desIv, 0, desIv.Length);
                fs.Write(encryptionData, 0, encryptionData.Length);
                fs.Close();
                fs = null;
            }
            catch( Exception ex )
            {
                if( fs != null )
                    fs.Close();
                throw ex;
            }
            finally
            {
                if( fs != null )
                    fs.Close();
            }
        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            List<NSNetworkTestInfo> nSNetworkTestInfoList = null;
            if(NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, "新本番用_NSNetworkTest.bin"))
            {
                foreach(NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList)
                {
                    object[] addDataObj = new object[] { 
                        nSNetworkTestInfo.NSNetworkTestName,
                        nSNetworkTestInfo.NSNetworkTestTargetUri,
                        nSNetworkTestInfo.NSNetworkServerType,
                        nSNetworkTestInfo.NSNetworkTestType};

                    this.dataGridView1.Rows.Add(addDataObj);
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<NSNetworkTestInfo> nSNetworkTestInfoList = new List<NSNetworkTestInfo>();
            foreach(DataGridViewRow dr in this.dataGridView1.Rows)
            {
                nSNetworkTestInfoList.Add(new NSNetworkTestInfo(
                    (NSNetworkTestInfo.ServerType)dr.Cells["ServerType"].Value,
                    (NSNetworkTestInfo.TestType)dr.Cells["TestType"].Value,
                     dr.Cells["TestName"].Value.ToString(),
                    new Uri(dr.Cells["TestUrl"].Value.ToString()))
                    );
            }

            NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList, "NSNetworkTest.bin");


            List<NSNetworkTestInfo> loadTestList;
            NSNetworkTestInfoList_Deserialize(out loadTestList, Path.Combine(Application.StartupPath, "Result") + "\\NSNetworkTest.bin");

            if(nSNetworkTestInfoList.Count == loadTestList.Count)
            {
                MessageBox.Show("OK");
            }
            else
            {

                MessageBox.Show("NG");
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[2].Value = NSNetworkTestInfo.ServerType.WEB;
            this.dataGridView1.Rows[e.RowIndex].Cells[3].Value = NSNetworkTestInfo.TestType.HTTPREQUEST;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string product = "";
            List<NSNetworkTestInfo> nSNetworkTestInfoList = new List<NSNetworkTestInfo>();

            foreach(string line in this.textBox1.Text.Split(new string[] {"\r\n"},  StringSplitOptions.RemoveEmptyEntries))
            {
                string[] splitdata = line.Split(new string[] { "\t" }, StringSplitOptions.None);
                if(splitdata[0] != null && splitdata[0] != "")
                {
                    nSNetworkTestInfoList.Add(new NSNetworkTestInfo(
                         (NSNetworkTestInfo.ServerType)Enum.Parse(typeof(NSNetworkTestInfo.ServerType), splitdata[2])
                        , (NSNetworkTestInfo.TestType)Enum.Parse(typeof(NSNetworkTestInfo.TestType), splitdata[3])
                        , splitdata[4]
                        , new Uri(splitdata[5])));

                    if(product == "")
                    {
                        product = splitdata[0];
                    }
                    else if(product != splitdata[0])
                    {
                        NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList, product + "_NSNetworkTest.bin");
                        nSNetworkTestInfoList.Clear();
                        product = "";
                    }
                }
            }

            if(nSNetworkTestInfoList.Count > 0)
            {
                NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList, product + "_NSNetworkTest.bin");
            }
        }
    }
}