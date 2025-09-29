//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品・入荷予約
// プログラム概要   : 出品・入荷予約 外部設定ファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 陳艶丹
// 作 成 日 : 2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Application.Common;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 外部設定ファイル用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 外部設定ファイル用クラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public class PMMAX02000UC
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        // 設定XMLファイル名
        private string XML_FILE_NAME = "UISettings_PMMAX02000U.xml";
        // ユーザー設定リスト
        private OutAndInPutUserData _exportSalesDataList;
        // 設定DATファイル名
        private const string DAT_FILE_NAME = @"AppSettingData\BuhinMax.dat";
        // 設定DATコピーファイル名
        private const string DAT_FILE_NAME_COPY = @"AppSettingData\BuhinMaxCopy.dat";
        // DATを作成するクラス
        private FileEncryptgraphy _saveInDat;
        // DATファイルのパースの設定
        private string filePath;
        // コピーファイルのパースの設定
        private string filePathTemp;
        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ログイン拠点コード
        /// </summary>
        public string LoginSectionCode
        {
            get { return _loginSectionCode; }
            set { _loginSectionCode = value; }
        }
        # endregion

        // ===================================================================================== //
        // ユーザー情報用テーブル
        // ===================================================================================== //
        #region ユーザー情報用テーブル
        /// <summary>ユーザー情報用テーブル名称</summary>
        public const string ct_Tbl_Users = "Tbl_User";

        /// <summary>企業コード</summary>
        public const string ct_Col_EnterPriseCode = "EnterPriseCode";
        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>ユーザーID</summary>
        public const string ct_Col_UserID = "UserID";
        /// <summary>ユーザーパースワード</summary>
        public const string ct_Col_UserPassWord = "UserPassWord";
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>
        /// 当面のユーザー
        /// </summary>
        public OutAndInPutUserData ExportSalesDataList
        {
            get { return _exportSalesDataList; }
            set { _exportSalesDataList = value; }
        }
        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// 出品・入荷予約共通クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出品・入荷予約共通クラスコンストラクタを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UC()
        {
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0');
            // DATファイルの暗号化
            _saveInDat = new FileEncryptgraphy(this._enterpriseCode);
            // DATファイルのパースの設定
            filePath = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData, DAT_FILE_NAME));
            // コピーファイルのパースの設定
            filePathTemp = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData, DAT_FILE_NAME_COPY));
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : シリアライズ処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // シリアライズ処理
                UserSettingController.SerializeUserSetting(_exportSalesDataList, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : デシリアライズ処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._exportSalesDataList = UserSettingController.DeserializeUserSetting<OutAndInPutUserData>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                }
                catch
                {
                    this._exportSalesDataList = new OutAndInPutUserData();
                }
            }
            else
            {
                this._exportSalesDataList = new OutAndInPutUserData();
            }
        }

        /// <summary>
        /// ユーザー情報保存用DateTableの作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー情報保存用DateTableの作成</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void CreatUserDateTable(ref DataSet menuDataSet, string userID, string userPassWord)
        {
            // DateTableがない場合
            if (menuDataSet.Tables.Count == 0)
            {
                DataTable userDataTable = new DataTable(PMMAX02000UC.ct_Tbl_Users);

                // 企業コード
                DataColumn columnEnterPriseCode = new DataColumn(PMMAX02000UC.ct_Col_EnterPriseCode, typeof(string));
                columnEnterPriseCode.Caption = "企業コード";
                userDataTable.Columns.Add(columnEnterPriseCode);

                // 拠点コード
                DataColumn columnSectionCode = new DataColumn(PMMAX02000UC.ct_Col_SectionCode, typeof(string));
                columnSectionCode.Caption = "拠点コード";
                userDataTable.Columns.Add(columnSectionCode);

                // ユーザーID
                DataColumn columnUserId = new DataColumn(PMMAX02000UC.ct_Col_UserID, typeof(string));
                columnUserId.Caption = "ユーザーID";
                userDataTable.Columns.Add(columnUserId);

                // ユーザーパースワード
                DataColumn columnUserPassWord = new DataColumn(PMMAX02000UC.ct_Col_UserPassWord, typeof(string));
                columnUserPassWord.Caption = "ユーザーパースワード";
                userDataTable.Columns.Add(columnUserPassWord);

                menuDataSet.Tables.Add(userDataTable);
            }
            // 新しい行を追加する
            DataRow row = menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].NewRow();

            row[PMMAX02000UC.ct_Col_EnterPriseCode] = this._enterpriseCode;
            row[PMMAX02000UC.ct_Col_SectionCode] = this._loginSectionCode;
            row[PMMAX02000UC.ct_Col_UserID] = userID;
            row[PMMAX02000UC.ct_Col_UserPassWord] = userPassWord;

            menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].Rows.Add(row);
        }

        /// <summary>
        /// ユーザー情報保存用DateTableの再設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー情報保存用DateTableの再設定</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void ReSetDateTable(ref DataSet menuDataSet, string userID, string userPassWord)
        {
            // 該当ユーザー情報はDATファイルに保存した場合
            if (menuDataSet != null && menuDataSet.Tables.Count > 0 && menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].Rows.Count > 0)
            {
                foreach (DataRow stdRow in menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].Rows)
                {
                    // 企業コードと拠点をキーとして、該当するユーザー情報を取得する
                    if (this._enterpriseCode == stdRow[PMMAX02000UC.ct_Col_EnterPriseCode].ToString() && this._loginSectionCode == stdRow[PMMAX02000UC.ct_Col_SectionCode].ToString())
                    {
                        // 該当するユーザー情報を取得した
                        stdRow[PMMAX02000UC.ct_Col_UserID] = userID;
                        stdRow[PMMAX02000UC.ct_Col_UserPassWord] = userPassWord;
                    }
                }
            }
        }

        /// <summary>
        /// DATファイルの書く込む
        /// </summary>
        /// <remarks>
        /// <br>Note       : DATファイルの書く込む</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void SetDateToDat(DataSet menuDataSet)
        {
            // IDとパースワードはDatファイルにセットする
            using (MemoryStream ms = new MemoryStream())
            {
                // ユーザー情報をDATファイルへセットする
                menuDataSet.WriteXml(ms, XmlWriteMode.WriteSchema);

                this._saveInDat.EncryptFile(filePath, ms);
            }
        }

        /// <summary>
        /// DATファイルの読み込む
        /// </summary>
        /// <remarks>
        /// <br>Note       : DATファイルの読み込む</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public DataSet ReadDatFile(string tableName, string enterPriseCode, string sectionCode, out string userID, out string userPassWord, out bool userExistFlag)
        {
            userExistFlag = false;
            DataSet menuDataSet = new DataSet();
            // ユーザー情報
            userID = string.Empty;
            userPassWord = string.Empty;
            // DATファイルを存在しない場合
            if (!File.Exists(filePath))
            {
                // 戻る
                return menuDataSet;
            }
            // コピーファイルを存在する場合
            if (File.Exists(filePathTemp))
            {
                // コピーファイルを削除する
                File.Delete(filePathTemp);
            }
            // ファイルのコピー
            File.Copy(filePath, filePathTemp);
            // 復号処理
            MemoryStream readMs = this._saveInDat.DecryptFile(filePathTemp);

            if (readMs != null)
            {
                try
                {
                    // DATファイルから、データを取得する
                    menuDataSet.ReadXml(readMs, XmlReadMode.Auto);
                    // DateSetからユーザー情報を取得する
                    if (menuDataSet != null && menuDataSet.Tables[tableName].Rows.Count > 0)
                    {
                        foreach (DataRow stdRow in menuDataSet.Tables[tableName].Rows)
                        {
                            // 企業コードと拠点をキーとして、該当するユーザー情報を取得する
                            if (this._enterpriseCode == stdRow[ct_Col_EnterPriseCode].ToString() && this._loginSectionCode == stdRow[ct_Col_SectionCode].ToString())
                            {
                                // 該当するユーザー情報を取得した
                                userID = stdRow[ct_Col_UserID].ToString();
                                userPassWord = stdRow[ct_Col_UserPassWord].ToString();
                                userExistFlag = true;
                                break;
                            }
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    readMs.Dispose();
                    // コピーファイルを存在する場合
                    if (File.Exists(filePathTemp))
                    {
                        // コピーファイルを削除する
                        File.Delete(filePathTemp);
                    }
                }
            }

            return menuDataSet;
        }
        # endregion
    }

    #region [XMLファイル出力用]
    /// <summary>
    /// 出品・入荷予約用ユーザー設定リスト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品・入荷予約のユーザー設定情報を管理するリスト</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OutAndInPutUserData
    {
        private List<OutAndInPutUserSaveItems> _exportSalesDataList;

        /// <summary>
        /// 出品・入荷予約用ユーザー設定リスト
        /// </summary>
        public List<OutAndInPutUserSaveItems> ExportSalesDataList
        {
            get
            {
                if (_exportSalesDataList == null) _exportSalesDataList = new List<OutAndInPutUserSaveItems>();
                return _exportSalesDataList;
            }
            set
            {
                _exportSalesDataList = value;
            }
        }
    }

    /// <summary>
    /// 出品・入荷予約用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品・入荷予約のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OutAndInPutUserSaveItems
    {
        # region コンストラクタ

        /// <summary>
        /// 得意先電子元帳ユーザー設定情報クラス
        /// </summary>
        public OutAndInPutUserSaveItems()
        {

        }

        # endregion // コンストラクタ

        # region プライベート変数

        // 企業コード
        private string _enterpriseCode = "";

        // 拠点コード
        private string _sectionCode = ""; 

        // 得意先コード
        private Int32 _customerCode;

        // 出庫拠点コード
        private string _bfSectionCode = "";

        // 入庫拠点コード
        private string _afSectionCode = "";

        // 出庫倉庫コードリスト
        private string _bfWarehouseCodeList = "";
        
        // 入庫倉庫コードリスト
        private string _afWarehouseCodeList = "";
        
        //出荷日付 
        private int _shipDateInit;

        // 発送日数
        private int _salesOrderCount;

        // 売価率下限値
        private int _salesRate;

        // 販売単価下限値
        private int _salesPrice;

        // チェックリスト出力選択
        private int _moveChecked;

        // チェックリスト出力先
        private string _moveFileName = ""; 

        # endregion // プライベート変数

        # region プロパティ

        /// <summary>
        /// 得意先コード
        /// </summary>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// 出庫拠点コード
        /// </summary>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// <summary>
        /// 入庫拠点コード
        /// </summary>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// <summary>
        /// 出荷日付
        /// </summary>
        public int ShipDateInit
        {
            get { return _shipDateInit; }
            set { _shipDateInit = value; }
        }

        /// <summary>
        /// 出庫倉庫コードリスト
        /// </summary>
        public string BfWarehouseCodeList
        {
            get { return _bfWarehouseCodeList; }
            set { _bfWarehouseCodeList = value; }
        }

        /// <summary>
        /// 入庫倉庫コードリスト
        /// </summary>
        public string AfWarehouseCodeList
        {
            get { return _afWarehouseCodeList; }
            set { _afWarehouseCodeList = value; }
        }

        /// <summary>
        /// 発注数
        /// </summary>
        public int SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// <summary>
        /// 売価率下限値
        /// </summary>
        public int SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// <summary>
        /// 販売単価下限値
        /// </summary>
        public int SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        /// <summary>
        /// チェックリスト出力選択
        /// </summary>
        public int MoveChecked
        {
            get { return _moveChecked; }
            set { _moveChecked = value; }
        }

        /// <summary>
        /// チェックリスト出力先
        /// </summary>
        public string MoveFileName
        {
            get { return _moveFileName; }
            set { _moveFileName = value; }
        }

        # endregion
    }
    #endregion

    #region [暗号化処理用クラス]
    /// <summary>
    /// 暗号化処理用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 暗号化処理用クラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public class FileEncryptgraphy
    {
        RijndaelManaged aes;

        /// <summary>
        /// 暗号化処理用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 暗号化処理用クラス。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public FileEncryptgraphy(string PassKey)
        {
            aes = new RijndaelManaged();

            byte[] bKey = System.Text.Encoding.UTF8.GetBytes(PassKey);

            aes.Key = ResizeBytesArray(bKey, aes.Key.Length);
            aes.IV = ResizeBytesArray(bKey, aes.IV.Length);
        }

        /// <summary>
        /// 暗号化処理
        /// </summary>
        /// <param name="sFileName">出力先名称</param>
        /// <param name="ms"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 暗号化処理用クラス。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public int EncryptFile(string sFileName, MemoryStream ms)
        {
            try
            {
                string strPath = Path.GetDirectoryName(sFileName);
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }

                ms.Position = 0;
                byte[] source = new byte[ms.Length];
                ms.Read(source, 0, (int)ms.Length);

                using (FileStream streamWrite = new FileStream(sFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (CryptoStream cs = new CryptoStream(streamWrite, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(source, 0, source.Length);
                        cs.FlushFinalBlock();
                        streamWrite.Close();
                    }
                }

                return 0; ;
            }
            catch
            { 
                return -1;
            }
        }

        /// <summary>
        /// 復号処理
        /// </summary>
        /// <param name="sFileName">出力先名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 暗号化処理用クラス。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public MemoryStream DecryptFile(string sFileName)
        {
            if (File.Exists(sFileName) == false)
        {
                return null;
            }

            try
            {
                MemoryStream ms = new MemoryStream();

                using (FileStream streamRead = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
                {
                    using (CryptoStream cs = new CryptoStream(streamRead, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] source = new byte[256];
                        int readLen;
                        while ((readLen = cs.Read(source, 0, source.Length)) > 0)
                {
                            ms.Write(source, 0, readLen);
                        }
                    }
                }

                ms.Position = 0;

                return ms;
                }
            catch
                {
                return null;
            }
                }

        /// <summary>
        /// 共有キー用に、バイト配列のサイズを変更する
        /// </summary>
        /// <param name="bytes">サイズを変更するバイト配列</param>
        /// <param name="newSize">バイト配列の新しい大きさ</param>
        /// <returns>サイズが変更されたバイト配列</returns>
        /// <remarks>
        /// <br>Note       : 暗号化処理用クラス。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];

            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
            {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
            }
        }

            return newBytes;
        }
    }
    # endregion
}
