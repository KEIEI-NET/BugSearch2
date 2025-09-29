using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 電帳.DX連携用CSV出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 電帳.DXに請求書の情報を連携するにあたり、付随するCSVを作成するクラス</br>
    /// <br>Programmer   : 鈴木 創</br>
    /// <br>Date         : 2022.02.07</br>
    /// </remarks>
    public class DenchoDXIndexCSV
    {

        private List<DenchoDXIndexCSVEntity> _denchoInvoiceIndexCSV;
        private bool _needsEncryption;

        private const string header = "mcd,blcustomercd,filename,doctype,customercd,customername,docnumber,transactiondate ,transactiontime,price_tax_included,price_tax_excluded,total_tax,memo,aojcorporatenumber,companyname,sectioncd,sectionname,ext1,ext2,ext3,ext4,currencyunit,taxrate1,price_taxrate1_included,price_taxrate1_excluded,tax1,taxrate2,price_taxrate2_included,price_taxrate2_excluded,tax2,taxrate3,price_taxrate3_included,price_taxrate3_excluded,tax3";
        private const string logHeader = "エラー種類,エラー項目,システム区分,取引先コード(自社),ファイル名,書類分類,取引先コード,取引先名称,書類番号,取引年月日,取引時間,取引金額合計(税込み),取引金額合計(税抜き),消費税金額合計,備考,登録番号(発行者),発行者名称,発行拠点コード,発行拠点名称,拡張(予備)1,拡張(予備)2,拡張(予備)3,拡張(予備)4,通貨単位,税率(1),税率(1)対象金額合計(税込み),税率(1)対象金額合計(税抜き),税額(1),税率(2),税率(2)対象金額合計(税込み),税率(2)対象金額合計(税抜き),税額(2),税率(3),税率(3)対象金額合計(税込み),税率(3)対象金額合計(税抜き),税額(3)";
        private const string logFolderName = @"\Log\PMCMN00180C";

        # region ■ Constructor ■
        /// <summary>
        /// 電帳.DX連携用CSV出力クラス(暗号化ON)
        /// </summary>
        /// <param name="csv">csvデータ</param>
        public DenchoDXIndexCSV(List<DenchoDXIndexCSVEntity> csv)
        {

            _denchoInvoiceIndexCSV = csv;
            _needsEncryption = true;

        }

        /// <summary>
        /// 電帳.DX連携用CSV出力クラス
        /// </summary>
        /// <param name="csv">csvデータ</param>
        /// <param name="needsEncryption">暗号化フラグ(true:する, false:しない)</param>
        public DenchoDXIndexCSV(List<DenchoDXIndexCSVEntity> csv, bool needsEncryption)
        {

            _denchoInvoiceIndexCSV = csv;
            _needsEncryption = needsEncryption;

        }
        # endregion

        # region ■ メイン処理 ■
        /// <summary>
        /// 電帳.DX連携用CSVエンティティクラスより、インデックスCSVを作成し、ファイルとして出力する。
        /// </summary>
        /// <param name="outputFilePath">出力先ファイルパス</param>
        /// <returns>
        /// 0:エラーなし
        /// -1:必須/項目チェックエラーレコードあり
        /// </returns>
        public int MakeIndexCSV(string outputFilePath){

            List<string> csvStr = new List<string>();
            List<string> logStr = new List<string>();
            int Ret = 0;
            string logFileName = "ErrorRecord_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            foreach (DenchoDXIndexCSVEntity c in _denchoInvoiceIndexCSV)
            {

                // 必須エラー発生フラグ 
                bool occurredErrorR = false;
                // 桁数エラー発生フラグ 
                bool occurredErrorN = false;

                // 必須チェック
                string errorItemR;
                if (CheckRequiredItems(c, out errorItemR) == false) occurredErrorR = true;

                // 出力用の電帳.DX連携用CSVエンティティクラスに変換
                DenchoDXIndexCSVStringEntity outputEntity = MakeOutputEntity(c);

                // 項目桁数チェック
                string errorItemN;
                if (CheckNumberOfDigits(outputEntity, out errorItemN) == false) occurredErrorN = true;

                // レコードの作成
                string csvRecord = MakeCSVRecord(outputEntity);

                // エラーが発生していた場合、ログを出力し、処理をスキップ
                // また、戻り値を-1とし、エラーの発生を呼び出し元に通知
                if (occurredErrorR == true)
                {
                    logStr.Add(MakeLogRecord( csvRecord, 1, errorItemR));
                    Ret = -1;
                    continue;
                }
                if (occurredErrorN == true)
                {
                    logStr.Add(MakeLogRecord( csvRecord, 2, errorItemN));
                    Ret = -1;
                    continue;
                }

                // 後にレコードを結合するため、リストに格納
                csvStr.Add(csvRecord);
            }

            // エラーレコードがある場合、ログを出力する。
            if (Ret == -1) WriteLog(logFileName, logStr);

            // 各レコードを改行文字で結合後、ヘッダーを追加
            string outputText = string.Join(Environment.NewLine, csvStr.ToArray());
            outputText = header + Environment.NewLine + outputText;

            // 暗号化フラグがTrueならば暗号化を実施
            if (_needsEncryption)
            {
                byte[] cipher = { };
                DenchoDXIndexCSVEncrypt denchoDXIndexCSVEncrypt = new DenchoDXIndexCSVEncrypt(DenchoDXIndexCSVEncrypt.SystemType.N2, DenchoDXIndexCSVEncrypt.CSVType.Index);
                cipher = denchoDXIndexCSVEncrypt.Encrypt(outputText);
                // csv出力
                WriteCSV(outputFilePath, cipher);
            }
            else
            {
                // csv出力
                WriteCSV(outputFilePath, outputText);
            }

            return Ret;
        }
        
        /// <summary>
        /// 電帳.DX連携用CSVエンティティクラスより、インデックスCSVを作成し、テキストとして返却する。
        /// </summary>
        /// <param name="output">返却テキスト(Byte配列をBase64形式でエンコード)</param>
        /// <returns>
        /// 0:エラーなし
        /// -1:必須チェックエラーレコードあり
        /// 返却テキストは暗号文(Byte配列)をBase64形式文字列として変換している
        /// 生の暗号文を取得する場合は、System.Convert.FromBase64String()でバイト配列にデコードすること
        /// </returns>
        public int MakeIndexCSVAsText(out string output)
        {
            List<string> csvStr = new List<string>();
            List<string> logStr = new List<string>();
            int Ret = 0;
            string logFileName = "ErrorRecord_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            foreach (DenchoDXIndexCSVEntity c in _denchoInvoiceIndexCSV)
            {

                // 必須エラー発生フラグ 
                bool occurredErrorR = false;
                // 桁数エラー発生フラグ 
                bool occurredErrorN = false;

                // 必須チェック
                string errorItemR;
                if (CheckRequiredItems(c, out errorItemR) == false) occurredErrorR = true;

                // 出力用の電帳.DX連携用CSVエンティティクラスに変換
                DenchoDXIndexCSVStringEntity outputEntity = MakeOutputEntity(c);

                // 項目桁数チェック
                string errorItemN;
                if (CheckNumberOfDigits(outputEntity, out errorItemN) == false) occurredErrorN = true;

                // レコードの作成
                string csvRecord = MakeCSVRecord(outputEntity);

                // エラーが発生していた場合、ログを出力し、処理をスキップ
                // また、戻り値を-1とし、エラーの発生を呼び出し元に通知
                if (occurredErrorR == true)
                {
                    logStr.Add(MakeLogRecord( csvRecord, 1, errorItemR));
                    Ret = -1;
                    continue;
                }
                if (occurredErrorN == true)
                {
                    logStr.Add(MakeLogRecord( csvRecord, 2, errorItemN));
                    Ret = -1;
                    continue;
                }

                // 後にレコードを結合するため、リストに格納
                csvStr.Add(csvRecord);
            }

            // エラーレコードがある場合、ログを出力する。
            if (Ret == -1) WriteLog(logFileName, logStr);

            // 各レコードを改行文字で結合後、ヘッダーを追加
            string outputText = string.Join(Environment.NewLine, csvStr.ToArray());
            outputText = header + Environment.NewLine + outputText;

            // 暗号化フラグがTrueならば暗号化を実施
            if (_needsEncryption)
            {
                byte[] cipher = { };
                DenchoDXIndexCSVEncrypt denchoDXIndexCSVEncrypt = new DenchoDXIndexCSVEncrypt(DenchoDXIndexCSVEncrypt.SystemType.N2, DenchoDXIndexCSVEncrypt.CSVType.Index);
                cipher = denchoDXIndexCSVEncrypt.Encrypt(outputText);
                // Byte配列をBase64形式でエンコード
                output = Convert.ToBase64String(cipher);
            }
            else
            {
                output = outputText;
            }

            return Ret;
        }

        /// <summary>
        /// 必須チェック
        /// </summary>
        /// <param name="c">電帳.DX連携用CSVエンティティクラス</param>
        /// <returns>
        /// true:チェックOK
        /// false:チェックNG
        /// </returns>
        private bool CheckRequiredItems(DenchoDXIndexCSVEntity c, out string errorItem)
        {

            errorItem = string.Empty;

            // 必須チェック
            // 必須項目がデフォルト値である(=何も入力されていない)場合、falseを返す
            // 但し、「取引金額合計(税込み)」「取引金額合計(税抜き)」「消費税金額合計」は0がありえるため、必須チェックを行わない

            // システム区分
            if (c.Mcd == 0)
            {
                errorItem = "システム区分";
                return false;
            }
            // 取引先コード(自社)
            if (string.IsNullOrEmpty(c.Blcustomercd))
            {
                errorItem = "取引先コード(自社)";
                return false;
            }
            // ファイル名
            if (string.IsNullOrEmpty(c.Filename))
            {
                errorItem = "ファイル名";
                return false;
            }
            // 書類分類
            if (c.Doctype == 0)
            {
                errorItem = "書類分類";
                return false;
            }
            // 取引先コード
            if (string.IsNullOrEmpty(c.Customercd))
            {
                errorItem = "取引先コード";
                return false;
            }
            // 書類番号
            if (string.IsNullOrEmpty(c.Docnumber))
            {
                errorItem = "書類番号";
                return false;
            }
            // 取引年月日
            if (c.Transactiondate == default(DateTime))
            {
                errorItem = "取引年月日";
                return false;
            }

            return true;
        }

        /// <summary>
        /// CSV出力用の電帳.DX連携用CSVエンティティクラスを作成する
        /// 主に行うの処理は以下の通り
        /// ・文字列であれば、","が含まれればダブルクォテーションで囲む
        /// ・必須項目でないならば、デフォルト値ならブランクに変換
        /// </summary>
        /// <param name="c">電帳.DX連携用CSVエンティティクラス</param>
        /// <returns>CSV出力用の電帳.DX連携用CSVエンティティ(文字列)クラス</returns>
        private DenchoDXIndexCSVStringEntity MakeOutputEntity(DenchoDXIndexCSVEntity c)
        {

            DenchoDXIndexCSVStringEntity outputEntity = new DenchoDXIndexCSVStringEntity();

            // システム区分
            outputEntity.Mcd = ((int)c.Mcd).ToString();
            // 取引先コード(自社)
            outputEntity.Blcustomercd = c.Blcustomercd;
            // ファイル名
            outputEntity.Filename = c.Filename;
            // 書類分類
            outputEntity.Doctype = ((int)c.Doctype).ToString();
            // 取引先コード
            outputEntity.Customercd = c.Customercd.ToString();
            // 取引先名称
            outputEntity.Customername = c.Customername;
            // 書類番号
            outputEntity.Docnumber = c.Docnumber;
            // 取引年月日 
            outputEntity.Transactiondate = c.Transactiondate.ToString("yyyyMMdd");
            // 取引時間　デフォルト値ならブランクに変換
            outputEntity.Transactiontime = ConvertDefaultToEmptyDateTime(c.Transactiontime, "HHmmss");
            // 取引金額合計(税込み)
            outputEntity.Price_tax_included = c.Price_tax_included.ToString();
            // 取引金額合計(税抜き)
            outputEntity.Price_tax_excluded = c.Price_tax_excluded.ToString();
            // 消費税金額合計
            outputEntity.Total_tax = c.Total_tax.ToString();
            // 備考
            outputEntity.Memo = c.Memo;
            // 登録番号(発行者)
            outputEntity.Aojcorporatenumber = c.Aojcorporatenumber;
            // 発行者名称
            outputEntity.Companyname = c.Companyname;
            // 発行拠点コード デフォルト値ならブランクに変換
            outputEntity.Sectioncd = ConvertDefaultToEmpty<ulong>(c.Sectioncd);
            // 発行拠点名称
            outputEntity.Sectionname = c.Sectionname;
            // 拡張1(予備)
            outputEntity.Ext1 = c.Ext1;
            // 拡張2(予備)
            outputEntity.Ext2 = c.Ext2;
            // 拡張3(予備)
            outputEntity.Ext3 = c.Ext3;
            // 拡張4(予備)
            outputEntity.Ext4 = c.Ext4;
            // 通貨単位
            outputEntity.Currencyunit = c.Currencyunit.ToString();
            // 税率(1)　デフォルト値ならブランクに変換
            outputEntity.Taxrate1 = ConvertDefaultToEmpty<int>(c.Taxrate1);
            // 税率(1)対象金額合計(税込み)　デフォルト値ならブランクに変換
            outputEntity.Price_taxrate1_included = ConvertDefaultToEmpty<decimal>(c.Price_taxrate1_included);
            // 税率(1)対象金額合計(税抜き)　デフォルト値ならブランクに変換
            outputEntity.Price_taxrate1_excluded = ConvertDefaultToEmpty<decimal>(c.Price_taxrate1_excluded);
            // 税額(1)　デフォルト値ならブランクに変換
            outputEntity.Tax1 = ConvertDefaultToEmpty<decimal>(c.Tax1);
            // 税率(2)　デフォルト値ならブランクに変換
            outputEntity.Taxrate2 = ConvertDefaultToEmpty<int>(c.Taxrate2);
            // 税率(2)対象金額合計(税込み)　デフォルト値ならブランクに変換
            outputEntity.Price_taxrate2_included = ConvertDefaultToEmpty<decimal>(c.Price_taxrate2_included);
            // 税率(2)対象金額合計(税抜き)　デフォルト値ならブランクに変換
            outputEntity.Price_taxrate2_excluded = ConvertDefaultToEmpty<decimal>(c.Price_taxrate2_excluded);
            // 税額(2)　デフォルト値ならブランクに変換
            outputEntity.Tax2 = ConvertDefaultToEmpty<decimal>(c.Tax2);
            // 税率(3)　デフォルト値ならブランクに変換
            outputEntity.Taxrate3 = ConvertDefaultToEmpty<int>(c.Taxrate3);
            // 税率(3)対象金額合計(税込み)　デフォルト値ならブランクに変換
            outputEntity.Price_taxrate3_included = ConvertDefaultToEmpty<decimal>(c.Price_taxrate3_included);
            // 税率(3)対象金額合計(税抜き)　デフォルト値ならブランクに変換
            outputEntity.Price_taxrate3_excluded = ConvertDefaultToEmpty<decimal>(c.Price_taxrate3_excluded);
            // 税額(3)　デフォルト値ならブランクに変換
            outputEntity.Tax3 = ConvertDefaultToEmpty<decimal>(c.Tax3);

            // 各項目をカンマで結合
            return outputEntity;
        }

        /// <summary>
        /// 桁数チェック
        /// </summary>
        /// <param name="c">CSV出力用の電帳.DX連携用CSVエンティティ(文字列)クラス</param>
        /// <param name="errorItem">チェックエラー発生時の項目名</param>
        /// <returns>
        /// true:チェックOK
        /// false:チェックNG
        /// </returns>
        private bool CheckNumberOfDigits(DenchoDXIndexCSVStringEntity c, out string errorItem)
        {
            errorItem = string.Empty;

            if (!string.IsNullOrEmpty(c.Mcd) && c.Mcd.Length > DenchoDXIndexCSVStringEntity.MaxMcd)
            {
                errorItem = "システム区分";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Blcustomercd) && c.Blcustomercd.Length > DenchoDXIndexCSVStringEntity.MaxBlcustomercd)
            {
                errorItem = "取引先コード(自社)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Filename) && c.Filename.Length > DenchoDXIndexCSVStringEntity.MaxFilename)
            {
                errorItem = "ファイル名";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Doctype) && c.Doctype.Length > DenchoDXIndexCSVStringEntity.MaxDoctype)
            {
                errorItem = "書類分類";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Customercd) && c.Customercd.Length > DenchoDXIndexCSVStringEntity.MaxCustomercd)
            {
                errorItem = "取引先コード";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Customername) && c.Customername.Length > DenchoDXIndexCSVStringEntity.MaxCustomername)
            {
                errorItem = "取引先名称";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Docnumber) && c.Docnumber.Length > DenchoDXIndexCSVStringEntity.MaxDocnumber)
            {
                errorItem = "書類番号";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Transactiondate) && c.Transactiondate.Length > DenchoDXIndexCSVStringEntity.MaxTransactiondate)
            {
                errorItem = "取引年月日";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Transactiontime) && c.Transactiontime.Length > DenchoDXIndexCSVStringEntity.MaxTransactiontime)
            {
                errorItem = "取引時間";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_tax_included) && c.Price_tax_included.Length > DenchoDXIndexCSVStringEntity.MaxPrice_tax_included)
            {
                errorItem = "取引金額合計(税込み)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_tax_excluded) && c.Price_tax_excluded.Length > DenchoDXIndexCSVStringEntity.MaxPrice_tax_excluded)
            {
                errorItem = "取引金額合計(税抜き)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Total_tax) && c.Total_tax.Length > DenchoDXIndexCSVStringEntity.MaxTotal_tax)
            {
                errorItem = "消費税金額合計";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Memo) && c.Memo.Length > DenchoDXIndexCSVStringEntity.MaxMemo)
            {
                errorItem = "備考";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Aojcorporatenumber) && c.Aojcorporatenumber.Length > DenchoDXIndexCSVStringEntity.MaxAojcorporatenumber)
            {
                errorItem = "登録番号(発行者)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Companyname) && c.Companyname.Length > DenchoDXIndexCSVStringEntity.MaxCompanyname)
            {
                errorItem = "発行者名称";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Sectioncd) && c.Sectioncd.Length > DenchoDXIndexCSVStringEntity.MaxSectioncd)
            {
                errorItem = "発行拠点コード";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Sectionname) && c.Sectionname.Length > DenchoDXIndexCSVStringEntity.MaxSectionname)
            {
                errorItem = "発行拠点名称";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Ext1) && c.Ext1.Length > DenchoDXIndexCSVStringEntity.MaxExt1)
            {
                errorItem = "拡張1(予備)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Ext2) && c.Ext2.Length > DenchoDXIndexCSVStringEntity.MaxExt2)
            {
                errorItem = "拡張2(予備)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Ext3) && c.Ext3.Length > DenchoDXIndexCSVStringEntity.MaxExt3)
            {
                errorItem = "拡張3(予備)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Ext4) && c.Ext4.Length > DenchoDXIndexCSVStringEntity.MaxExt4)
            {
                errorItem = "拡張4(予備)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Currencyunit) && c.Currencyunit.Length > DenchoDXIndexCSVStringEntity.MaxCurrencyunit)
            {
                errorItem = "通貨単位";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Taxrate1) && c.Taxrate1.Length > DenchoDXIndexCSVStringEntity.MaxTaxrate1)
            {
                errorItem = "税率(1)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_taxrate1_included) && c.Price_taxrate1_included.Length > DenchoDXIndexCSVStringEntity.MaxPrice_taxrate1_included)
            {
                errorItem = "税率(1)対象金額合計(税込み)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_taxrate1_excluded) && c.Price_taxrate1_excluded.Length > DenchoDXIndexCSVStringEntity.MaxPrice_taxrate1_excluded)
            {
                errorItem = "税率(1)対象金額合計(税抜き)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Tax1) && c.Tax1.Length > DenchoDXIndexCSVStringEntity.MaxTax1)
            {
                errorItem = "税額(1)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Taxrate2) && c.Taxrate2.Length > DenchoDXIndexCSVStringEntity.MaxTaxrate2)
            {
                errorItem = "税率(2)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_taxrate2_included) && c.Price_taxrate2_included.Length > DenchoDXIndexCSVStringEntity.MaxPrice_taxrate2_included)
            {
                errorItem = "税率(2)対象金額合計(税込み)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_taxrate2_excluded) && c.Price_taxrate2_excluded.Length > DenchoDXIndexCSVStringEntity.MaxPrice_taxrate2_excluded)
            {
                errorItem = "税率(2)対象金額合計(税抜き)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Tax2) && c.Tax2.Length > DenchoDXIndexCSVStringEntity.MaxTax2)
            {
                errorItem = "税額(2)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Taxrate3) && c.Taxrate3.Length > DenchoDXIndexCSVStringEntity.MaxTaxrate3)
            {
                errorItem = "税率(3)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_taxrate3_included) && c.Price_taxrate3_included.Length > DenchoDXIndexCSVStringEntity.MaxPrice_taxrate3_included)
            {
                errorItem = "税率(3)対象金額合計(税込み)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Price_taxrate3_excluded) && c.Price_taxrate3_excluded.Length > DenchoDXIndexCSVStringEntity.MaxPrice_taxrate3_excluded)
            {
                errorItem = "税率(3)対象金額合計(税抜き)";
                return false;
            }

            if (!string.IsNullOrEmpty(c.Tax3) && c.Tax3.Length > DenchoDXIndexCSVStringEntity.MaxTax3)
            {
                errorItem = "税額(3)";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 電帳.DX連携用CSVエンティティクラスよりCSVのレコードを作成する
        /// </summary>
        /// <param name="c">電帳.DX連携用CSVエンティティ(文字列)クラス</param>
        /// <returns>レコードの文字列</returns>
        private string MakeCSVRecord(DenchoDXIndexCSVStringEntity c)
        {

            List<string> csvRecordStr = new List<string>();

            // システム区分
            csvRecordStr.Add(EncloseInDQ(c.Mcd));
            // 取引先コード(自社)
            csvRecordStr.Add(EncloseInDQ(c.Blcustomercd));
            // ファイル名
            csvRecordStr.Add(EncloseInDQ(c.Filename));
            // 書類分類
            csvRecordStr.Add(EncloseInDQ(c.Doctype));
            // 取引先コード
            csvRecordStr.Add(EncloseInDQ(c.Customercd));
            // 取引先名称
            csvRecordStr.Add(EncloseInDQ(c.Customername));
            // 書類番号
            csvRecordStr.Add(EncloseInDQ(c.Docnumber));
            // 取引年月日 
            csvRecordStr.Add(EncloseInDQ(c.Transactiondate));
            // 取引時間
            csvRecordStr.Add(EncloseInDQ(c.Transactiontime));
            // 取引金額合計(税込み)
            csvRecordStr.Add(EncloseInDQ(c.Price_tax_included));
            // 取引金額合計(税抜き)
            csvRecordStr.Add(EncloseInDQ(c.Price_tax_excluded));
            // 消費税金額合計
            csvRecordStr.Add(EncloseInDQ(c.Total_tax));
            // 備考
            csvRecordStr.Add(EncloseInDQ(c.Memo));
            // 登録番号(発行者)
            csvRecordStr.Add(EncloseInDQ(c.Aojcorporatenumber));
            // 発行者名称
            csvRecordStr.Add(EncloseInDQ(c.Companyname));
            // 発行拠点コード
            csvRecordStr.Add(EncloseInDQ(c.Sectioncd));
            // 発行拠点名称
            csvRecordStr.Add(EncloseInDQ(c.Sectionname));
            // 拡張1(予備)
            csvRecordStr.Add(EncloseInDQ(c.Ext1));
            // 拡張2(予備)
            csvRecordStr.Add(EncloseInDQ(c.Ext2));
            // 拡張3(予備)
            csvRecordStr.Add(EncloseInDQ(c.Ext3));
            // 拡張4(予備)
            csvRecordStr.Add(EncloseInDQ(c.Ext4));
            // 通貨単位
            csvRecordStr.Add(EncloseInDQ(c.Currencyunit));
            // 税率(1)
            csvRecordStr.Add(EncloseInDQ(c.Taxrate1));
            // 税率(1)対象金額合計(税込み)
            csvRecordStr.Add(EncloseInDQ(c.Price_taxrate1_included));
            // 税率(1)対象金額合計(税抜き)
            csvRecordStr.Add(EncloseInDQ(c.Price_taxrate1_excluded));
            // 税額(1)
            csvRecordStr.Add(EncloseInDQ(c.Tax1));
            // 税率(2)
            csvRecordStr.Add(EncloseInDQ(c.Taxrate2));
            // 税率(2)対象金額合計(税込み)
            csvRecordStr.Add(EncloseInDQ(c.Price_taxrate2_included));
            // 税率(2)対象金額合計(税抜き)
            csvRecordStr.Add(EncloseInDQ(c.Price_taxrate2_excluded));
            // 税額(2)
            csvRecordStr.Add(EncloseInDQ(c.Tax2));
            // 税率(3)
            csvRecordStr.Add(EncloseInDQ(c.Taxrate3));
            // 税率(3)対象金額合計(税込み)
            csvRecordStr.Add(EncloseInDQ(c.Price_taxrate3_included));
            // 税率(3)対象金額合計(税抜き)
            csvRecordStr.Add(EncloseInDQ(c.Price_taxrate3_excluded));
            // 税額(3)
            csvRecordStr.Add(EncloseInDQ(c.Tax3));

            // 各項目をカンマで結合
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
        # endregion

        # region ■ 文字列操作 ■
        /// <summary>
        /// 与えられたT型の値がデフォルト値であるならば、空文字を返す。
        /// それ以外ならT型をToString()した値を返す。
        /// </summary>
        /// <typeparam name="T">値型</typeparam>
        /// <param name="token"></param>
        /// <returns>空文字もしくはToString()した値</returns>
        private string ConvertDefaultToEmpty<T>(T token) where T : struct
        {
            
            if (token.Equals(default(T))) return string.Empty;

            return token.ToString();
        }

        /// <summary>
        /// 与えられたT型の値がデフォルト値であるならば、空文字を返す。
        /// それ以外ならT型をToString()した値を返す。(DateTime型)
        /// </summary>
        /// <typeparam name="T">値型</typeparam>
        /// <param name="token"></param>
        /// <param name="argToString">Tostringの引数</param>
        /// <returns>空文字もしくはToString()した値</returns>
        private string ConvertDefaultToEmptyDateTime(DateTime token, string argToString)
        {

            if (token.Equals(default(DateTime))) return string.Empty;

            return token.ToString(argToString);
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
        # endregion

        # region ■ ログ出力 ■
        /// <summary>
        /// ログレコード作成処理
        /// </summary>
        /// <param name="errorRecord">エラー発生レコード</param>
        /// <param name="errorLevel">
        /// 1:必須エラー
        /// 2:桁数エラー
        /// </param>
        /// <param name="errorItem">エラー項目</param>
        /// <returns>ログレコード</returns>
        private string MakeLogRecord(string errorRecord,int errorLevel,string errorItem)
        {

            // ログレコードの作成
            string errorMessage = string.Empty;
            if (errorLevel == 1) errorMessage = "必須エラー," + errorItem + "," + errorRecord;
            else if (errorLevel == 2) errorMessage = "桁数エラー," + errorItem + "," + errorRecord;

            return errorMessage;
        }

        /// <summary>
        /// ログ書き出し
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="errorRecords">エラーレコード</param>
        private void WriteLog(string fileName, List<string> errorRecords)
        {

            // エラーレコードが1件もない場合、処理終了
            if (errorRecords == null || errorRecords.Count == 0) return;

            string path = System.IO.Directory.GetCurrentDirectory() + logFolderName;

            // フォルダが存在しない場合、作成する。
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            // ログCSVの作成
            string LogCSV = string.Join(Environment.NewLine, errorRecords.ToArray());
            LogCSV = logHeader + Environment.NewLine + LogCSV;

            // ファイルの出力(追記モード)
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            File.AppendAllText(path + @"\" + fileName, LogCSV, enc);

        }
        # endregion

        # region ■ private Entity Class ■
        /// <summary>
        /// 電帳.DX連携用CSVエンティティクラス(文字列)
        /// </summary>
        /// <remarks>
        /// CSV出力用の文字列を格納するクラス
        /// </remarks>
        private class DenchoDXIndexCSVStringEntity
        {

            # region ■ public const ■
            /// <summary>システム区分　最大桁数</summary>
            public const int MaxMcd = 8;

            /// <summary>取引先コード(自社)　最大桁数</summary>
            public const int MaxBlcustomercd = 30;

            /// <summary>ファイル名　最大桁数</summary>
            public const int MaxFilename = 256;

            /// <summary>書類分類　最大桁数</summary>
            public const int MaxDoctype = 8;

            /// <summary>取引先コード　最大桁数</summary>
            public const int MaxCustomercd = 20;

            /// <summary>取引先名称　最大桁数</summary>
            public const int MaxCustomername = 120;

            /// <summary>書類番号　最大桁数</summary>
            public const int MaxDocnumber = 30;

            /// <summary>取引年月日　最大桁数</summary>
            public const int MaxTransactiondate = 8;

            /// <summary>取引時間　最大桁数</summary>
            public const int MaxTransactiontime = 6;

            /// <summary>取引金額合計(税込み)　最大桁数</summary>
            public const int MaxPrice_tax_included = 12;

            /// <summary>取引金額合計(税抜き)　最大桁数</summary>
            public const int MaxPrice_tax_excluded = 12;

            /// <summary>消費税金額合計　最大桁数</summary>
            public const int MaxTotal_tax = 12;

            /// <summary>備考　最大桁数</summary>
            public const int MaxMemo = 256;

            /// <summary>登録番号(発行者)　最大桁数</summary>
            public const int MaxAojcorporatenumber = 20;

            /// <summary>発行者名称　最大桁数</summary>
            public const int MaxCompanyname = 60;

            /// <summary>発行拠点コード　最大桁数</summary>
            public const int MaxSectioncd = 10;

            /// <summary>発行拠点名称　最大桁数</summary>
            public const int MaxSectionname = 20;

            /// <summary>拡張(予備)　最大桁数</summary>
            public const int MaxExt1 = 1;

            /// <summary>拡張(予備)　最大桁数</summary>
            public const int MaxExt2 = 1;

            /// <summary>拡張(予備)　最大桁数</summary>
            public const int MaxExt3 = 1;

            /// <summary>拡張(予備)　最大桁数</summary>
            public const int MaxExt4 = 1;

            /// <summary>通貨単位　最大桁数</summary>
            public const int MaxCurrencyunit = 5;

            /// <summary>税率(1)　最大桁数</summary>
            public const int MaxTaxrate1 = 4;

            /// <summary>税率(1)対象金額合計(税込み)　最大桁数</summary>
            public const int MaxPrice_taxrate1_included = 12;

            /// <summary>税率(1)対象金額合計(税抜き)　最大桁数</summary>
            public const int MaxPrice_taxrate1_excluded = 12;

            /// <summary>税額(1)　最大桁数</summary>
            public const int MaxTax1 = 12;

            /// <summary>税率(2)　最大桁数</summary>
            public const int MaxTaxrate2 = 4;

            /// <summary>税率(2)対象金額合計(税込み)　最大桁数</summary>
            public const int MaxPrice_taxrate2_included = 12;

            /// <summary>税率(2)対象金額合計(税抜き)　最大桁数</summary>
            public const int MaxPrice_taxrate2_excluded = 12;

            /// <summary>税額(2)　最大桁数</summary>
            public const int MaxTax2 = 12;

            /// <summary>税率(3)　最大桁数</summary>
            public const int MaxTaxrate3 = 4;

            /// <summary>税率(3)対象金額合計(税込み)　最大桁数</summary>
            public const int MaxPrice_taxrate3_included = 12;

            /// <summary>税率(3)対象金額合計(税抜き)　最大桁数</summary>
            public const int MaxPrice_taxrate3_excluded = 12;

            /// <summary>税額(3)　最大桁数</summary>
            public const int MaxTax3 = 12;
            # endregion

            # region ■ private field ■
            /// <summary>システム区分</summary>
            private string _mcd;

            /// <summary>取引先コード(自社)</summary>
            private string _blcustomercd;

            /// <summary>ファイル名</summary>
            private string _filename;

            /// <summary>書類分類</summary>
            private string _doctype;

            /// <summary>取引先コード</summary>
            private string _customercd;

            /// <summary>取引先名称</summary>
            private string _customername;

            /// <summary>書類番号</summary>
            private string _docnumber;

            /// <summary>取引年月日</summary>
            private string _transactiondate;

            /// <summary>取引時間</summary>
            private string _transactiontime;

            /// <summary>取引金額合計(税込み)</summary>
            private string _price_tax_included;

            /// <summary>取引金額合計(税抜き)</summary>
            private string _price_tax_excluded;

            /// <summary>消費税金額合計</summary>
            private string _total_tax;

            /// <summary>備考</summary>
            private string _memo;

            /// <summary>登録番号(発行者)</summary>
            private string _aojcorporatenumber;

            /// <summary>発行者名称</summary>
            private string _companyname;

            /// <summary>発行拠点コード</summary>
            private string _sectioncd;

            /// <summary>発行拠点名称</summary>
            private string _sectionname;

            /// <summary>拡張1(予備)</summary>
            private string _ext1;

            /// <summary>拡張2(予備)</summary>
            private string _ext2;

            /// <summary>拡張3(予備)</summary>
            private string _ext3;

            /// <summary>拡張4(予備)</summary>
            private string _ext4;

            /// <summary>通貨単位</summary>
            private string _currencyunit;

            /// <summary>税率(1)</summary>
            private string _taxrate1;

            /// <summary>税率(1)対象金額合計(税込み)</summary>
            private string _price_taxrate1_included;

            /// <summary>税率(1)対象金額合計(税抜き)</summary>
            private string _price_taxrate1_excluded;

            /// <summary>税額(1)</summary>
            private string _tax1;

            /// <summary>税率(2)</summary>
            private string _taxrate2;

            /// <summary>税率(2)対象金額合計(税込み)</summary>
            private string _price_taxrate2_included;

            /// <summary>税率(2)対象金額合計(税抜き)</summary>
            private string _price_taxrate2_excluded;

            /// <summary>税額(2)</summary>
            private string _tax2;

            /// <summary>税率(3)</summary>
            private string _taxrate3;

            /// <summary>税率(3)対象金額合計(税込み)</summary>
            private string _price_taxrate3_included;

            /// <summary>税率(3)対象金額合計(税抜き)</summary>
            private string _price_taxrate3_excluded;

            /// <summary>税額(3)</summary>
            private string _tax3;
            # endregion

            # region ■ public property ■
            /// <summary>取引先コード(自社)のプロパティ</summary>
            public string Mcd
            {
                get { return _mcd; }
                set { _mcd = value; }
            }

            /// <summary>取引先コード(自社)のプロパティ</summary>
            public string Blcustomercd
            {
                get { return _blcustomercd; }
                set { _blcustomercd = value; }
            }

            /// <summary>ファイル名のプロパティ</summary>
            public string Filename
            {
                get { return _filename; }
                set { _filename = value; }
            }

            /// <summary>取引先コード(自社)のプロパティ</summary>
            public string Doctype
            {
                get { return _doctype; }
                set { _doctype = value; }
            }

            /// <summary>取引先コードのプロパティ</summary>
            public string Customercd
            {
                get { return _customercd; }
                set { _customercd = value; }
            }

            /// <summary>取引先名称のプロパティ</summary>
            public string Customername
            {
                get { return _customername; }
                set { _customername = value; }
            }

            /// <summary>書類番号のプロパティ</summary>
            public string Docnumber
            {
                get { return _docnumber; }
                set { _docnumber = value; }
            }

            /// <summary>取引年月日のプロパティ</summary>
            public string Transactiondate
            {
                get { return _transactiondate; }
                set { _transactiondate = value; }
            }

            /// <summary>取引時間のプロパティ</summary>
            public string Transactiontime
            {
                get { return _transactiontime; }
                set { _transactiontime = value; }
            }

            /// <summary>取引金額合計(税込み)のプロパティ</summary>
            public string Price_tax_included
            {
                get { return _price_tax_included; }
                set { _price_tax_included = value; }
            }

            /// <summary>取引金額合計(税抜き)のプロパティ</summary>
            public string Price_tax_excluded
            {
                get { return _price_tax_excluded; }
                set { _price_tax_excluded = value; }
            }

            /// <summary>消費税金額合計のプロパティ</summary>
            public string Total_tax
            {
                get { return _total_tax; }
                set { _total_tax = value; }
            }

            /// <summary>備考のプロパティ</summary>
            public string Memo
            {
                get { return _memo; }
                set { _memo = value; }
            }

            /// <summary>登録番号(発行者)のプロパティ</summary>
            public string Aojcorporatenumber
            {
                get { return _aojcorporatenumber; }
                set { _aojcorporatenumber = value; }
            }

            /// <summary>発行者名称のプロパティ</summary>
            public string Companyname
            {
                get { return _companyname; }
                set { _companyname = value; }
            }

            /// <summary>発行拠点コードのプロパティ</summary>
            public string Sectioncd
            {
                get { return _sectioncd; }
                set { _sectioncd = value; }
            }

            /// <summary>発行拠点名称のプロパティ</summary>
            public string Sectionname
            {
                get { return _sectionname; }
                set { _sectionname = value; }
            }

            /// <summary>拡張(予備)のプロパティ</summary>
            public string Ext1
            {
                get { return _ext1; }
                set { _ext1 = value; }
            }

            /// <summary>拡張(予備)のプロパティ</summary>
            public string Ext2
            {
                get { return _ext2; }
                set { _ext2 = value; }
            }

            /// <summary>拡張(予備)のプロパティ</summary>
            public string Ext3
            {
                get { return _ext3; }
                set { _ext3 = value; }
            }

            /// <summary>拡張(予備)のプロパティ</summary>
            public string Ext4
            {
                get { return _ext4; }
                set { _ext4 = value; }
            }

            /// <summary>通貨単位のプロパティ</summary>
            public string Currencyunit
            {
                get { return _currencyunit; }
                set { _currencyunit = value; }
            }

            /// <summary>税率(1)のプロパティ</summary>
            public string Taxrate1
            {
                get { return _taxrate1; }
                set { _taxrate1 = value; }
            }

            /// <summary>税率(1)対象金額合計(税込み)のプロパティ</summary>
            public string Price_taxrate1_included
            {
                get { return _price_taxrate1_included; }
                set { _price_taxrate1_included = value; }
            }

            /// <summary>税率(1)対象金額合計(税抜き)のプロパティ</summary>
            public string Price_taxrate1_excluded
            {
                get { return _price_taxrate1_excluded; }
                set { _price_taxrate1_excluded = value; }
            }

            /// <summary>税額(1)のプロパティ</summary>
            public string Tax1
            {
                get { return _tax1; }
                set { _tax1 = value; }
            }

            /// <summary>税率(2)のプロパティ</summary>
            public string Taxrate2
            {
                get { return _taxrate2; }
                set { _taxrate2 = value; }
            }

            /// <summary>税率(2)対象金額合計(税込み)のプロパティ</summary>
            public string Price_taxrate2_included
            {
                get { return _price_taxrate2_included; }
                set { _price_taxrate2_included = value; }
            }

            /// <summary>税率(2)対象金額合計(税抜き)のプロパティ</summary>
            public string Price_taxrate2_excluded
            {
                get { return _price_taxrate2_excluded; }
                set { _price_taxrate2_excluded = value; }
            }

            /// <summary>税額(2)のプロパティ</summary>
            public string Tax2
            {
                get { return _tax2; }
                set { _tax2 = value; }
            }

            /// <summary>税率(3)のプロパティ</summary>
            public string Taxrate3
            {
                get { return _taxrate3; }
                set { _taxrate3 = value; }
            }

            /// <summary>税率(3)対象金額合計(税込み)のプロパティ</summary>
            public string Price_taxrate3_included
            {
                get { return _price_taxrate3_included; }
                set { _price_taxrate3_included = value; }
            }

            /// <summary>税率(3)対象金額合計(税抜き)のプロパティ</summary>
            public string Price_taxrate3_excluded
            {
                get { return _price_taxrate3_excluded; }
                set { _price_taxrate3_excluded = value; }
            }

            /// <summary>税額(3)のプロパティ</summary>
            public string Tax3
            {
                get { return _tax3; }
                set { _tax3 = value; }
            }
            # endregion

        }
        # endregion
    }
}
