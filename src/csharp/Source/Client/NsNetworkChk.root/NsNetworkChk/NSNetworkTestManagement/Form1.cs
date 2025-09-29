using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Broadleaf.NSNetworkChk.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Reflection;

namespace Broadleaf.NSNetworkChk.UI
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();
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

        #region データクラス保存、読み込み処理
        /*
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
                using( FileStream fileStream = new FileStream(fileName, FileMode.Open) )
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(fileStream);
                }
                result = true;
            }
            catch( Exception ex )
            {
                nSNetworkTestInfoList = null;
                MessageBox.Show("設定ファイル取得中にエラーが発生しました。");
            }
            return result;
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
            string saveFileName = Path.Combine(resultPath, fileName);

            try
            {
                if( !Directory.Exists(resultPath) )
                {
                    Directory.CreateDirectory(resultPath);
                }

                using( FileStream fileStream = new FileStream(saveFileName, FileMode.Create) )
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, nSNetworkTestInfoList);
                }
                result = true;
            }
            catch( Exception ex )
            {
                MessageBox.Show("設定ファイル更新中にエラーが発生しました。");
            }

            return result;
        }
         * */
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.openFileDialog1.FileName = "設定ファイル";
            this.openFileDialog1.Filter = "設定ファイル(*.dat)|*.dat|All file(*.*)|*.*";
            this.openFileDialog1.InitialDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            this.openFileDialog1.RestoreDirectory = false;
            DialogResult res = this.openFileDialog1.ShowDialog();
            string fileName = string.Empty;
            if (res == DialogResult.OK)
            {
                fileName = this.openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            List<NSNetworkTestInfo> nSNetworkTestInfoList;
            NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, fileName);

            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
            {
                this.listBox1.Items.Add(nSNetworkTestInfo);
            }

            //this.listBox1.Items.Add("新規追加...");

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = this.listBox1.SelectedItem;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NSNetworkTestInfo nSNetworkTestInfo = new NSNetworkTestInfo();
            this.listBox1.Items.Add(nSNetworkTestInfo);
            this.propertyGrid1.SelectedObject = nSNetworkTestInfo;
            
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if( e.NewSelection.Value != null)
            {
                if( e.NewSelection.Value is ProxyInfo )
                {
                    this.propertyGrid2.SelectedObject = (ProxyInfo)e.NewSelection.Value;
                }
                else if( e.NewSelection.Value is Exception )
                {
                    this.propertyGrid2.SelectedObject = (Exception)e.NewSelection.Value;
                    this.textBox1.Text =  ((Exception)e.NewSelection.Value).ToString();
                }
                else
                {
                    this.propertyGrid2.SelectedObject = null;
                    this.textBox1.Text = "";
                }
            }
            else
            {
                this.propertyGrid2.SelectedObject = null;
                this.textBox1.Text = "";
            }
        }

        private void propertyGrid2_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if( e.NewSelection.Value is Exception )
            {
                this.textBox1.Text = ((Exception)e.NewSelection.Value).ToString();
            }
            else
            {
                this.textBox1.Text = "";
            }
        }

        private void propertyGrid1_Enter(object sender, EventArgs e)
        {
            if( ( (PropertyGrid)sender ).SelectedGridItem != null && ((PropertyGrid)sender).SelectedGridItem.Value is Exception )
            {
                this.textBox1.Text = ( (Exception)( (PropertyGrid)sender ).SelectedGridItem.Value ).ToString();
            }
        }
    }
}