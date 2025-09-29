using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// 得意先マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 電帳.DXに請求書の情報を連携するにあたり、取引先CSVを作成するクラス</br>
    /// <br>Programmer   : 鈴木 創</br>
    /// <br>Date         : 2022.03.01</br>
    /// </remarks>
    public class DenchoDXCustomerExportAcs
    {
        #region ■ Private Member

        private bool _needsEncryption;
        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;
        private const string header = "businessPartnerCode,businessPartnerCodePrefix,businessPartnerName1,businessPartnerName2,businessPartnerNameKana1,businessPartnerNameKana2,postalCode,addressStateCity,addressStreet,addressBuildingName,PhoneNumber1,PhoneNumber2,emailAddress,contactInformationOther,customerDiv,supplierDiv,businessPartnerRemarks,lastUpdateDateTime";
        private const string businessPartnerCodePrefix = "PM得意先";
        private const string userXMLName = "PMCMN00190A_UserSetting.xml";

        #endregion

        # region ■Constracter
        /// <summary>
        /// コンストラクタ(暗号化ON)
        /// </summary>
        public DenchoDXCustomerExportAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
            _needsEncryption = true;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="needsEncryption">暗号化フラグ(true:する, false:しない)</param>
        public DenchoDXCustomerExportAcs(bool needsEncryption)
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
            _needsEncryption = needsEncryption;
        }
        # endregion

        #region ■ Main
        /// <summary>
        /// 得意先CSV全件出力
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFilePath">出力先ファイルパス</param>
        /// <returns>
        /// DB取得失敗の場合、サーチメソッドの戻り値
        /// 出力するCSVが0件の場合、ConstantManagement.MethodResult.ctFNC_NO_RETURN
        /// 正常終了の場合、ConstantManagement.MethodResult.ctFNC_NORMAL
        /// </returns>
        public int MakeCustomerCSVAll(string enterpriseCode, string outputFilePath)
        {
            // XML情報の読み込み
            PMCMN00190A_XML userXML;
            int retDeserialize = Deserialize(out userXML);

            if (retDeserialize == 0)
            {
                // XML読み込みに成功した場合、XMLに現在時刻の書き込みを行う
                
                // メイン処理の呼び出し
                int retOutput = outputCSVAll(enterpriseCode, outputFilePath);
                if (retOutput != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return retOutput;

                // 正常終了の場合、現在時刻をXMLに書き込む
                userXML.UpdateDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                Serialize(userXML);

                return retOutput;

            }
            else
            {
                // XML読み込みに失敗した場合、XML書き込みを行わない
                
                // メイン処理の呼び出し
                int retOutput = outputCSVAll(enterpriseCode, outputFilePath);

                return retOutput;
            }  
        }

        /// <summary>
        /// 得意先CSV差分出力
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFilePath">出力先ファイルパス</param>
        /// <returns>
        /// DB取得失敗の場合、サーチメソッドの戻り値
        /// 出力するCSVが0件の場合、ConstantManagement.MethodResult.ctFNC_NO_RETURN
        /// 正常終了の場合、ConstantManagement.MethodResult.ctFNC_NORMAL
        /// </returns>
        public int MakeCustomerCSVDifference(string enterpriseCode, string outputFilePath)
        {
            
            // XML情報の読み込み
            PMCMN00190A_XML userXML;
            int retDeserialize = Deserialize(out userXML);

            if (retDeserialize == 0)
            {
                // XML読み込みに成功した場合、差分出力を行う

                // メイン処理の呼び出し
                int retOutput = outputCSVDifference(enterpriseCode, outputFilePath, userXML);
                if (retOutput != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return retOutput;

                // 正常終了の場合、現在時刻をXMLに書き込む
                userXML.UpdateDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                Serialize(userXML);

                return retOutput;

            }
            else
            {
                // XML読み込みに失敗した場合、全件出力を行う

                // メイン処理の呼び出し
                int retOutput = outputCSVAll(enterpriseCode, outputFilePath);

                return retOutput;
            }  
        }  

        /// <summary>
        /// 得意先CSV全件出力
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFilePath">出力先ファイルパス</param>
        /// <returns>
        /// DB取得失敗の場合、サーチメソッドの戻り値
        /// 出力するCSVが0件の場合、ConstantManagement.MethodResult.ctFNC_NO_RETURN
        /// 正常終了の場合、ConstantManagement.MethodResult.ctFNC_NORMAL
        /// </returns>
        private int outputCSVAll(string enterpriseCode, string outputFilePath)
        {

            // 「得意先エクスポート画面にて無条件で抽出」と同様の設定でサーチを行う
            CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
            customerCustomerChangeParamWork.EnterpriseCode = enterpriseCode;
            customerCustomerChangeParamWork.StCustomerCode = 0;
            customerCustomerChangeParamWork.EdCustomerCode = 0;
            customerCustomerChangeParamWork.StMngSectionCode = string.Empty;
            customerCustomerChangeParamWork.EdMngSectionCode = string.Empty;
            customerCustomerChangeParamWork.SearchDiv = 1;

            // 得意先エクスポートのサーチ機能を用いる
            object al = null;
            int status = _iCustomerCustomerChangeDB.Search(ref al, customerCustomerChangeParamWork, 0, ConstantManagement.LogicalMode.GetData0);

            // 正常終了以外の場合、戻り値をそのまま返す
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            ArrayList retReatList = (ArrayList)al;
            Dictionary<int, CustomerCustomerChangeResultWork> dict = new Dictionary<int, CustomerCustomerChangeResultWork>();
            List<string> csvStr = new List<string>();

            foreach (CustomerCustomerChangeResultWork c in retReatList)
            {

                // 得意先掛率Gが複数ある場合、同じ得意先コードのレコードが続く場合がある
                // その場合、得意先掛率G以外の項目の値は変わらないため、最初のレコードの情報のみを出力する
                if (dict.ContainsKey(c.CustomerCode)) continue;

                //　レコード作成
                string record = MakeCustomerCSVRecord(c);
                csvStr.Add(record);

                // 得意先コードの重複チェックのため、Dictionaryに追加
                dict.Add(c.CustomerCode, c);
            }

            // データ0件の場合、戻り値を返して処理終了
            if (csvStr.Count == 0) return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 各レコードを改行文字で結合後、ヘッダーを追加
            string outputText = string.Join(Environment.NewLine, csvStr.ToArray());
            outputText = header + Environment.NewLine + outputText;

            // 暗号化フラグがTrueならば暗号化を実施
            if (_needsEncryption)
            {
                byte[] cipher = { };
                DenchoDXIndexCSVEncrypt denchoDXIndexCSVEncrypt = new DenchoDXIndexCSVEncrypt(DenchoDXIndexCSVEncrypt.SystemType.N2, DenchoDXIndexCSVEncrypt.CSVType.Suppliers);
                cipher = denchoDXIndexCSVEncrypt.Encrypt(outputText);
                // csv出力
                WriteCSV(outputFilePath, cipher);
            }
            else
            {
                // csv出力
                WriteCSV(outputFilePath, outputText);
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 得意先CSV差分出力
        /// 前回出力した時間をXMLに保持し、それより更新されたレコードのみを出力する
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFilePath">出力先ファイルパス</param>
        /// <returns>
        /// DB取得失敗の場合、サーチメソッドの戻り値
        /// 出力するCSVが0件の場合、ConstantManagement.MethodResult.ctFNC_NO_RETURN
        /// 正常終了の場合、ConstantManagement.MethodResult.ctFNC_NORMAL
        /// </returns>
        private int outputCSVDifference(string enterpriseCode, string outputFilePath, PMCMN00190A_XML userXML)
        {

            // 「得意先エクスポート画面にて無条件で抽出」と同様の設定でサーチを行う
            CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
            customerCustomerChangeParamWork.EnterpriseCode = enterpriseCode;
            customerCustomerChangeParamWork.StCustomerCode = 0;
            customerCustomerChangeParamWork.EdCustomerCode = 0;
            customerCustomerChangeParamWork.StMngSectionCode = string.Empty;
            customerCustomerChangeParamWork.EdMngSectionCode = string.Empty;
            customerCustomerChangeParamWork.SearchDiv = 1;

            // 得意先エクスポートのサーチ機能を用いる
            object al = null;
            int status = _iCustomerCustomerChangeDB.Search(ref al, customerCustomerChangeParamWork, 0, ConstantManagement.LogicalMode.GetData0);

            // 正常終了以外の場合、戻り値をそのまま返す
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            ArrayList retReatList = (ArrayList)al;
            Dictionary<int, CustomerCustomerChangeResultWork> dict = new Dictionary<int, CustomerCustomerChangeResultWork>();
            List<string> csvStr = new List<string>();

            foreach (CustomerCustomerChangeResultWork c in retReatList)
            {

                // 得意先掛率Gが複数ある場合、同じ得意先コードのレコードが続く場合がある
                // その場合、得意先掛率G以外の項目の値は変わらないため、最初のレコードの情報のみを出力する
                if (dict.ContainsKey(c.CustomerCode)) continue;

                // 得意先マスタの更新日時が前回出力日時より後の場合、処理を行う
                // それ以外はスキップする
                if (c.UpdateDateTime.ToString("yyyyMMddHHmmss").CompareTo(userXML.UpdateDateTime) != 1) continue;

                //　レコード作成
                string record = MakeCustomerCSVRecord(c);
                csvStr.Add(record);

                // 得意先コードの重複チェックのため、Dictionaryに追加
                dict.Add(c.CustomerCode, c);
            }

            // データ0件の場合、戻り値を返して処理終了
            if (csvStr.Count == 0) return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 各レコードを改行文字で結合後、ヘッダーを追加
            string outputText = string.Join(Environment.NewLine, csvStr.ToArray());
            outputText = header + Environment.NewLine + outputText;

            // 暗号化フラグがTrueならば暗号化を実施
            if (_needsEncryption)
            {
                byte[] cipher = { };
                DenchoDXIndexCSVEncrypt denchoDXIndexCSVEncrypt = new DenchoDXIndexCSVEncrypt(DenchoDXIndexCSVEncrypt.SystemType.N2, DenchoDXIndexCSVEncrypt.CSVType.Suppliers);
                cipher = denchoDXIndexCSVEncrypt.Encrypt(outputText);
                // csv出力
                WriteCSV(outputFilePath, cipher);
            }
            else
            {
                // csv出力
                WriteCSV(outputFilePath, outputText);
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 得意先インデックスのレコード作成
        /// </summary>
        /// <param name="c">顧客エンティティ</param>
        /// <returns>レコード</returns>
        private string MakeCustomerCSVRecord(CustomerCustomerChangeResultWork c)
        {
            List<string> csvRecordStr = new List<string>();

            // 得意先コード → 取引先コード
            csvRecordStr.Add(PreProcessing(c.CustomerCode.ToString("d8")));
            // 得意先コード → 取引先コード接頭辞
            csvRecordStr.Add(businessPartnerCodePrefix);
            // 得意先名１ → 取引先名称１
            csvRecordStr.Add(PreProcessing(c.Name));
            // 得意先名２ → 取引先名称２
            csvRecordStr.Add(PreProcessing(c.Name2));
            // 得意先名カナ → 取引先名称カナ１
            csvRecordStr.Add(PreProcessing(c.Kana));
            // 空白 → 取引先名称カナ２
            csvRecordStr.Add(string.Empty);
            // 郵便番号 → 郵便番号
            csvRecordStr.Add(PreProcessing(EditPostNo(c.PostNo)));
            // 住所１ → 住所(都道府県・市町村)
            csvRecordStr.Add(PreProcessing(c.Address1));
            // 住所２ → 住所(番地)
            csvRecordStr.Add(PreProcessing(c.Address3));
            // 住所３ → 住所(建物名)
            csvRecordStr.Add(PreProcessing(c.Address4));

            // 連絡先（電話番号１）と連絡先（電話番号２）は以下の優先順位で上から二つの電話番号を設定する。
            // 設定する電話番号が存在しない場合は、ブランクを設定する。
            //   自宅電話　→　勤務先電話　→　携帯電話　→　その他電話
            List<string> phoneNumbers = new List<string>();

            if (c.HomeTelNo != string.Empty) phoneNumbers.Add(c.HomeTelNo);
            if (c.OfficeTelNo != string.Empty) phoneNumbers.Add(c.OfficeTelNo);
            if (c.PortableTelNo != string.Empty) phoneNumbers.Add(c.PortableTelNo);
            if (c.OthersTelNo != string.Empty) phoneNumbers.Add(c.OthersTelNo);

            if (phoneNumbers.Count >= 2)
            {
                // 電話番号１ → 連絡先（電話番号１）
                csvRecordStr.Add(PreProcessing(phoneNumbers[0]));
                // 電話番号２ → 連絡先（電話番号２）
                csvRecordStr.Add(PreProcessing(phoneNumbers[1]));
            }
            else if (phoneNumbers.Count == 1)
            {
                // 電話番号１ → 連絡先（電話番号１）
                csvRecordStr.Add(PreProcessing(phoneNumbers[0]));
                // 空白 → 連絡先（電話番号２）
                csvRecordStr.Add(string.Empty);
            }
            else if (phoneNumbers.Count == 0)
            {
                // 空白 → 連絡先（電話番号１）
                csvRecordStr.Add(string.Empty);
                // 空白 → 連絡先（電話番号２）
                csvRecordStr.Add(string.Empty);
            }

            // メールアドレス１ → 連絡先（メールアドレス）
            csvRecordStr.Add(PreProcessing(c.MailAddress1));
            // 電話番号（その他） → 連絡先（その他）
            csvRecordStr.Add(string.Empty);
            // 1:得意先 → 得意先区分
            csvRecordStr.Add(1.ToString());
            // 0:指定なし → 仕入先区分
            csvRecordStr.Add(0.ToString());
            // 空白 → 取引先備考
            csvRecordStr.Add(string.Empty);
            // 最終更新日時　→　最終更新日時
            csvRecordStr.Add(PreProcessing(c.UpdateDateTime.ToString("yyyy-MM-dd HH:mm:ss")));

            return string.Join(",", csvRecordStr.ToArray());
        }

        /// <summary>
        /// CSV書き出し(文字列)
        /// </summary>
        /// <param name="outputFilePath">ファイルパス</param>
        /// <param name="csv">csv文字列</param>
        private void WriteCSV(string outputFilePath, string csv)
        {
            string directoryPath = Path.GetDirectoryName(outputFilePath);

            // フォルダが存在しない場合、作成する。
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            // 対象のパスに書き出し
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            File.WriteAllText(outputFilePath, csv, enc);

        }

        /// <summary>
        /// CSV書き出し(バイト配列)
        /// </summary>
        /// <param name="outputFilePath">ファイルパス</param>
        /// <param name="csv">csv文字列</param>
        private void WriteCSV(string outputFilePath, byte[] csv)
        {
            string directoryPath = Path.GetDirectoryName(outputFilePath);

            // フォルダが存在しない場合、作成する。
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            // 対象のパスに書き出し
            File.WriteAllBytes(outputFilePath, csv);

        }
        #endregion

        # region ■ 文字列操作 ■
        /// <summary>
        /// 文字列出力の前処理
        /// </summary>
        /// <param name="token">文字列</param>
        /// <returns></returns>
        private string PreProcessing(string token)
        {
            if (string.IsNullOrEmpty(token)) return string.Empty;

            string ret = token;

            ret = EncloseInDQ(ret);
            ret = RemoveMarks(ret);

            return ret;
        }

        /// <summary>
        /// 与えらえた文字列に以下が含まれれば、
        /// ・カンマ
        /// ・Cr(改行文字)
        /// ・Lf(改行文字)
        /// ・"(ダブルクォテーション)
        /// があればダブルクォテーションで囲む
        /// </summary>
        /// <param name="token">文字列</param>
        /// <returns>カンマ付き文字列もしくは文字列そのまま</returns>
        private string EncloseInDQ(string token)
        {
            if (string.IsNullOrEmpty(token)) return string.Empty;

            if (token.Contains(@""""))
            {
                // ダブルクォテーションのエスケープ
                token = token.Replace(@"""", @"""""");
                return (@"""" + token + @"""");
            }

            if (token.Contains(",")) return (@"""" + token + @"""");

            if (token.Contains("\r")) return (@"""" + token + @"""");

            if (token.Contains("\n")) return (@"""" + token + @"""");

            return token;
        }

        /// <summary>
        /// 記号削除
        /// </summary>
        /// <param name="token">文字列</param>
        /// <returns>
        /// 電帳DX側でチェックエラーとなる文字列をブランクにReplaceする
        /// </returns>
        private string RemoveMarks(string token)
        {
            if (string.IsNullOrEmpty(token)) return string.Empty;

            token = token.Replace("｣", "");

            token = token.Replace("｢", "");

            token = token.Replace("､", "");

            token = token.Replace("｡", "");

            return token;

        }

        /// <summary>
        /// 郵便番号編集
        /// </summary>
        /// <param name="token">郵便番号</param>
        /// <returns>
        /// 郵便番号が8桁で(数字3桁)-(数字4桁)の形式であることをチェックする
        /// そうでなく、7桁の場合、(数字7桁)であればハイフンを追記する
        /// それ以外の場合、ブランクを返す
        /// </returns>
        private string EditPostNo(string token)
        {
            string ret;

            ret = string.Empty;

            if (token.Length == 8)
            {
                // 形式が(数字3桁)-(数字4桁)ならばそのまま返す
                if (System.Text.RegularExpressions.Regex.IsMatch(token, @"\d\d\d-\d\d\d\d"))
                {
                    ret = token;
                }
                else
                {
                    ret = string.Empty;
                }
            }
            else if (token.Length == 7)
            {
                // 形式が(数字7桁)ならば3桁目にハイフンを挿入し返す
                if (System.Text.RegularExpressions.Regex.IsMatch(token, @"\d\d\d\d\d\d\d"))
                {
                    ret = token.Insert(3,"-");
                }
                else
                {
                    ret = string.Empty;
                }
            }

            return ret;

        }
        # endregion

        #region ■ XML関連
        /// <summary>
        /// シリアライズ(XML書き込み)
        /// </summary>
        /// <param name="userXML">XMLクラス</param>
        private void Serialize(PMCMN00190A_XML userXML)
        {
            UserSettingController.SerializeUserSetting(userXML, Path.Combine(ConstantManagement_ClientDirectory.UISettings, userXMLName));
        }

        /// <summary>
        /// デシリアライズ(XML読み込み)
        /// </summary>
        /// <param name="userXML">読み込んだXMLクラス</param>
        /// <returns>
        /// 0:正常終了
        /// -1:読み込み失敗
        /// </returns>
        private int Deserialize(out PMCMN00190A_XML userXML)
        {
            userXML = null;

            if (!UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, userXMLName))) return -1;

            try
            {
                userXML = UserSettingController.DeserializeUserSetting<PMCMN00190A_XML>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, userXMLName));
                return 0;
            }
            catch
            {
                userXML = null;
                return -1;
            }

        }

        /// <summary>
        /// 取引先リスト出力日時XMLエンティティクラス
        /// </summary>
        public class PMCMN00190A_XML
        {
            /// <summary>取引先リスト出力日時</summary>
            private string _updateDateTime = string.Empty;

            /// <summary>
            /// 取引先リスト出力日時
            /// </summary>
            public string UpdateDateTime
            {
                get { return this._updateDateTime; }
                set { this._updateDateTime = value; }
            }

        }
        #endregion
    }
}
