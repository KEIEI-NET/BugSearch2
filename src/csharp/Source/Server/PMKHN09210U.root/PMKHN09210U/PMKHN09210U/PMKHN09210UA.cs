using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
//using System.ServiceProcess;
using Microsoft.Win32;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/22 機能追加

namespace Broadleaf.Windows.Forms
{
    using LatestPair = Pair<DateTime, int>;

    /// <summary>
    /// サーバ側の価格改正処理を行う。
    /// </summary>
    public partial class PMKHN09210UA : Form
    {
        #region [ Private Member ]
        private OfferMergeAcs _OfferMergeAcs;
        private string enterpriseCode;
        private conf _dtHist;
        private const string ct_cfgFile = "PriceUpdCfg.xml";
        private readonly string[] lstCaption = new string[5] { "ﾁｪｯｸ開始時刻\r  [HHMM]", "ﾁｪｯｸ終了時刻\r  [HHMM]", 
                                    "実行Pg名","起動ﾊﾟﾗﾒｰﾀ", "ﾁｪｯｸ間隔\r(時間）" };

        private string workDir = string.Empty;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public PMKHN09210UA()
        {
            InitializeComponent();
            _OfferMergeAcs = new OfferMergeAcs();
        }

        private void PMKHN09210UA_Shown(object sender, EventArgs e)
        {
            if (ReadCfgFile() != 0)
            {
                //MessageBox.Show("設定ファイルの読み込みに失敗しました。", Text, MessageBoxButtons.OK);
            }
            gridConf.DataSource = _dtHist.Conf;
            for (int i = 0; i < gridConf.Columns.Count; i++)
            {
                gridConf.Columns[i].HeaderText = lstCaption[i];
            }

            gridConf.Columns[0].Width = 125; // ﾁｪｯｸ開始時刻
            gridConf.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[0].ValueType = typeof(int);
            gridConf.Columns[1].Width = 125; // ﾁｪｯｸ終了時刻
            gridConf.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[2].Width = 200; // 実行Pg名
            gridConf.Columns[3].Width = 80;  // 起動ﾊﾟﾗﾒｰﾀ
            gridConf.Columns[4].Width = 100; // ﾁｪｯｸ間隔
            gridConf.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void PMKHN09210UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteCfgFile();
        }

        #region [ XMLリード・ライト ]
        /// <summary>
        /// 設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        private int ReadCfgFile()
        {
            int status = 0;
            _dtHist = new conf();
            try
            {
                FileStream fs = new FileStream(ct_cfgFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] tmp = new byte[fs.Length];
                int cnt = fs.Read(tmp, 0, (int)fs.Length);
                for (int i = 0; i < cnt; i++)
                {
                    tmp[i] += 8;
                }
                fs.Close();
                MemoryStream ms = new MemoryStream(tmp);
                _dtHist.ReadXml(ms);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 設定ファイル書込み
        /// </summary>
        /// <returns></returns>
        private int WriteCfgFile()
        {
            int status = 0;
            string xml = _dtHist.GetXml();
            try
            {
                byte[] tmp = Encoding.Default.GetBytes(xml);
                FileStream fs = new FileStream(ct_cfgFile, FileMode.Create);
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] -= 8;
                }
                fs.Write(tmp, 0, tmp.Length);
                fs.Close();
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        #endregion

        /// <summary>マージデータの取得者</summary>
        private IMergeDataGet _iMergeDataGetter;
        // ADD 2009/02/02 機能追加：対象日付取得 ---------->>>>>
        /// <summary>
        /// マージデータの取得者を取得します。
        /// </summary>
        private IMergeDataGet MergeDataGetter
        {
            get
            {
                if (_iMergeDataGetter == null)
                {
                    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
                }
                return _iMergeDataGetter;
            }
        }
        // ADD 2008/02/02 機能追加：対象日付取得 ----------<<<<<


        /// <summary>マージの実行者</summary>
        private IOfferMerge _iOfferMerger;
        // ADD 2009/02/02 機能追加：対象日付取得 ---------->>>>>
        /// <summary>
        /// マージの実行者を取得します。
        /// </summary>
        private IOfferMerge OfferMerger
        {
            get
            {
                if (_iOfferMerger == null)
                {
                    _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
                }
                return _iOfferMerger;
            }
        }

        /// <summary>
        /// 値のペアクラス
        /// </summary>
        /// <typeparam name="TFirst">1番目の値の型</typeparam>
        /// <typeparam name="TSecond">2番目の値の型</typeparam>
        public class Pair<TFirst, TSecond>
        {
            /// <summary>1番目の値</summary>
            private readonly TFirst _first;
            /// <summary>
            /// 1番目の値を取得します。
            /// </summary>
            /// <value>1番目の値</value>
            public TFirst First { get { return _first; } }

            /// <summary>2番目の値を取得します。</summary>
            private readonly TSecond _second;
            /// <summary>
            /// 2番目の値を取得します。
            /// </summary>
            /// <value>2番目の値</value>
            public TSecond Second { get { return _second; } }

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="first">1番目の値</param>
            /// <param name="second">2番目の値</param>
            public Pair(
                TFirst first,
                TSecond second
            )
            {
                _first = first;
                _second = second;
            }

            #region <object override/>

            /// <summary>
            /// 文字列に変換します。
            /// </summary>
            /// <returns>文字列</returns>
            public override string ToString()
            {
                return First.ToString() + "," + Second.ToString();
            }

            #endregion  // <object override/>
        }

        #region [ 配信連動自動マージ処理 ]
        internal void MergeOfferToUser()
        {
            try
            {
                // ﾚｼﾞｽﾄﾘｷｰ取得
                StreamWriter writer = null;                          // テキストログ用
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // ログ書き込みﾌｫﾙﾀﾞ指定
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");

                // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " 自動処理起動 " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                object objLatestList = null;
                enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // テスト用
                //MessageBox.Show("価格改正", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);



                int status = OfferMerger.GetLatestHistory(enterpriseCode, out objLatestList);
                ArrayList latestList = objLatestList as ArrayList;

                DateTime InstallOfferDate = DateTime.MinValue;
                _OfferMergeAcs.getInstallDate(ref InstallOfferDate);

                // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " インストール日付 " + InstallOfferDate + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                //****************************************************************
                // Dictionary<ﾃｰﾌﾞﾙID,<日付(DateTime),対象件数(int)>>で用意する
                //****************************************************************
                if (latestList.Count != 0)
                {
                    IDictionary<string, LatestPair> latestMap = new Dictionary<string, LatestPair>();
                    foreach (PriUpdTblUpdHisWork history in latestList)
                    {
                        string tableId = this.ConvertSyncTableNameToTableId(history.SyncTableName);
                        if (!latestMap.ContainsKey(tableId))
                        {
                            // 前回処理日
                            int offerDate = history.OfferDate;
                            DateTime dateTime = DateTime.MinValue;
                            //if (!offerDate.Equals(0))
                            //{
                            //history.OfferDate = 0;
                            if (history.OfferDate == 0)
                            {
                                // 優良･部位はﾚｼﾞｽﾄﾘより日付取得
                                if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID) || tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID) || tableId.Equals(ProcessConfig.GOODS_MASTER_ID))
                                {
                                    dateTime = InstallOfferDate.AddMonths(-1);
                                }
                                // その他はMinvalue
                                else
                                {
                                    dateTime = DateTime.MinValue;
                                }
                            }
                            else
                            {
                                // 2回目以降
                                dateTime = DateTime.Parse(history.OfferDate.ToString("0000/00/00"));
                            }
                            // テスト用

                            //dateTime = DateTime.MinValue;
                            //}
                            int updatedCount = history.AddUpdateRowsNo;

                            latestMap.Add(tableId, new LatestPair(dateTime, updatedCount));

                            // 優良設定変更マスタ用
                            if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                            {
                                latestMap.Add(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID, new LatestPair(dateTime, updatedCount));
                            }
                        }
                    }
                    //if (latestList)

                    ConvertPriceSyncTableNameToTableId(ref latestMap, InstallOfferDate);

                    #region Delete
                    //MessageBox.Show(dateTime.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ////}
                    //return;

                    //if (IsNewVersion() == false)
                    //    return;
                    //int offerDate;
                    #endregion

                    _OfferMergeAcs.Initialize(enterpriseCode);
                    if (status == 0)
                    {
                        string msg = string.Empty;
                        bool isMerged = _OfferMergeAcs.Checker.IsMerged(out msg);
                        if (!isMerged)
                        {
                            // ﾃｷｽﾄﾛｸﾞ書込み (ﾏｰｼﾞﾁｪｯｸあり)
                            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                            writer.Write(DateTime.Now + " ﾏｰｼﾞﾁｪｯｸ差異あり 自動更新開始" + "\r\n");
                            writer.Flush();
                            if (writer != null) writer.Close();

                            // DEL 2009/11/11 MANTIS対応[14363]：提供データ更新処理インターロックの追加 ---------->>>>>
                            //// 引数でMergeOfferToUserにﾃﾞｨｸｼｮﾅﾘ持って行ってアクセスクラスのprivateで保管する作戦
                            //status = _OfferMergeAcs.MergeOfferToUser(enterpriseCode, 0, latestMap);
                            // DEL 2009/11/11 MANTIS対応[14363]：提供データ更新処理インターロックの追加 ----------<<<<<
                            // ADD 2009/11/11 MANTIS対応[14363]：提供データ更新処理インターロックの追加 ---------->>>>>
                            if (OfferMergeInterlock.CanUpdate())
                            {
                                // 引数でMergeOfferToUserにﾃﾞｨｸｼｮﾅﾘ持って行ってアクセスクラスのprivateで保管する作戦
                                status = _OfferMergeAcs.MergeOfferToUser(enterpriseCode, 0, latestMap);
                            }
                            else
                            {
                                // ﾃｷｽﾄﾛｸﾞ書込み (CurrentVersion と TargetVersion が不一致)
                                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                                writer.Write(DateTime.Now + " CurrentVersion と TargetVersion が不一致のため自動更新を中止" + "\r\n");
                                writer.Flush();
                                if (writer != null) writer.Close();
                            }
                            // ADD 2009/11/11 MANTIS対応[14363]：提供データ更新処理インターロックの追加 ----------<<<<<

                            #region Delete
                            //if (status == 0 || status == 4) // マージ正常又はマージ対象なしか
                            //{
                            //    // USER_APに提供バージョン書き込み
                            //    //_VersionCheckAcs.UpdateVersion(ref CurrentVersion);

                            //    //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
                            //    //object currentVer = key.GetValue("CurrentVersion", "8.10.1.0");
                            //    //key.SetValue("MergedVersion", currentVer, RegistryValueKind.String);
                            //}
                            #endregion
                        }
                        else
                        {
                            // ﾃｷｽﾄﾛｸﾞ書込み (ﾏｰｼﾞﾁｪｯｸなし)
                            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                            writer.Write(DateTime.Now + " ﾏｰｼﾞﾁｪｯｸ差異なし 自動更新なし" + "\r\n");
                            writer.Flush();
                            if (writer != null) writer.Close();
                        }
                    }
                }
                Close();

                // ﾃｷｽﾄﾛｸﾞ書込み (終了)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " 自動処理終了 " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
            //}
            catch { }
        }

        // インストール日付取得
        private DateTime GetInstallDate()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
            if (key == null)
            {
                return DateTime.MinValue;
            }
            string InstalOfferDate = key.GetValue("InstallOfferDate").ToString();
            int InstDateint = Int32.Parse(InstalOfferDate.Trim());

            DateTime instalOfferDate = DateTime.Parse(InstDateint.ToString("0000/00/00"));

            // インストール日付より1ヶ月前からマージ処理するため
            return instalOfferDate.AddMonths(-1);
        }

        // 価格改正リスト格納
        private void ConvertPriceSyncTableNameToTableId(ref IDictionary<string, Broadleaf.Application.Controller.Util.Pair<DateTime, int>> latestMap, DateTime InstallOfferDate)
        {
            // 価格改正用
            if (!latestMap.ContainsKey(ProcessConfig.GOODS_MASTER_ID))
            {
                latestMap.Add(ProcessConfig.GOODS_MASTER_ID, new LatestPair(InstallOfferDate.AddMonths(-1), 0));
            }
            //if (!latestMap.ContainsKey(ProcessConfig.GOODS_PRICE_MASTER_ID))
            //{
            //    latestMap.Add(ProcessConfig.GOODS_PRICE_MASTER_ID, new LatestPair(GetInstallDate(), 0));
            //}

            //string key = string.Empty;
            //if (latestMap[ProcessConfig.GOODS_MASTER_ID].First >= latestMap[ProcessConfig.GOODS_PRICE_MASTER_ID].First)
            //{
            //    key = ProcessConfig.GOODS_MASTER_ID;
            //}
            //else
            //{
            //    key = ProcessConfig.GOODS_PRICE_MASTER_ID;
            //}

            //latestMap.Add(ProcessConfig.PRICE_REVISION_ID, new LatestPair(latestMap[key].First, latestMap[key].Second));
        }

        //テーブルID照合
        private string ConvertSyncTableNameToTableId(string syncTableName)
        {
            if (syncTableName.Equals("BLGROUPURF"))
            {
                return ProcessConfig.BL_GROUP_MASTER_ID;        // BLグループマスタ
            }
            if (syncTableName.Equals("GOODSGROUPURF"))
            {
                return ProcessConfig.MIDDLE_GENRE_MASTER_ID;    // 中分類マスタ
            }
            if (syncTableName.Equals("MODELNAMEURF"))
            {
                return ProcessConfig.MODEL_NAME_MASTER_ID;      // 車種マスタ
            }
            if (syncTableName.Equals("PARTSPOSCODEURF"))
            {
                return ProcessConfig.PARTS_POS_CODE_MASTER_ID;  // 部位マスタ
            }
            if (syncTableName.Equals("BLGOODSCDURF"))
            {
                return ProcessConfig.BL_CODE_MASTER_ID;         // BLコードマスタ
            }
            if (syncTableName.Equals("PRMSETTINGURF"))
            {
                return ProcessConfig.PRIME_SETTING_MASTER_ID;   // 優良設定マスタ
            }
            //if (syncTableName.Equals("GOODSMNGURF"))
            if (syncTableName.Equals("GOODSURF"))
            {
                return ProcessConfig.GOODS_MASTER_ID;           // 商品マスタ
            }
            if (syncTableName.Equals("PRICEURF"))
            {
                return ProcessConfig.GOODS_PRICE_MASTER_ID;     // 価格マスタ
            }
            if (syncTableName.Equals("MAKERURF"))
            {
                return ProcessConfig.MAKER_MASTER_ID;           // メーカーマスタ
            }

            return string.Empty;
        }

        /// <summary>
        /// 日付変換処理(int -> DateTime)
        /// </summary>
        /// <param name="date">変換する日付データ(YYYYMMDD)</param>
        /// <returns></returns>
        private DateTime ConverIntToDateTime(int date)
        {
            if (date < 0)
                return DateTime.MinValue;
            int year = date / 10000;
            int month = (date % 10000) / 100;
            int day = (date % 10000) % 100;
            if (year == 0 || month == 0 || day == 0)
                return DateTime.MinValue;
            return new DateTime(year, month, day);
        }


        /// <summary>
        /// 新しい配信があるかチェック
        /// </summary>
        /// <returns>true:新しい配信あり／false:新しい配信なし</returns>
        private bool IsNewVersion()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
                if (key == null) // 配信処理が一回もなかった？
                {
                    return false;
                }
                string currentVer = key.GetValue("CurrentVersion", "8.10.1.0").ToString();
                object objMergedVer = key.GetValue("MergedVersion");
                if (objMergedVer == null) // マージ処理をしたことないか？
                    return true;
                string mergedVer = objMergedVer.ToString();

                if (currentVer.CompareTo(mergedVer) > 0)
                    return true;
            }
            catch
            {
            }
            return false;

        }
        #endregion

        private void gridConf_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                int st;
                int ed;
                int interval;
                int st_ed_intval;
                if (int.TryParse(gridConf[0, row].Value.ToString(), out st) == false
                    || int.TryParse(gridConf[1, row].Value.ToString(), out ed) == false
                    || int.TryParse(gridConf[4, row].Value.ToString(), out interval) == false)
                {
                    e.Cancel = true;
                    return;
                }
                if (ed > st)
                {
                    st_ed_intval = ((ed / 100) * 60) + (ed % 100) - (((st / 100) * 60) + (st % 100));
                }
                else
                {
                    st_ed_intval = 24 * 60 - (((st / 100) * 60) + (st % 100));
                    st_ed_intval += ((ed / 100) * 60) + (ed % 100);
                }
                if (interval * 60 >= st_ed_intval)
                {
                    //MessageBox.Show("チェック間隔をチェック開始時刻とチェック終了時刻の間隔より小さめにして下さい。",
                    //    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }

        }

        private void gridConf_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int tmp;
            switch (e.ColumnIndex)
            {
                case 0:
                case 1:
                case 4:
                    if (int.TryParse(e.FormattedValue.ToString(), out tmp) == false)
                    {
                        //MessageBox.Show("整数のみ入力可能な項目です。", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    if (e.ColumnIndex != 4 && (tmp < 0 || tmp > 2400))
                    {
                        //MessageBox.Show("HHMM形式で0~2400の間の値を入力して下さい。", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    if (e.ColumnIndex == 4 && tmp <= 0)
                    {
                        //MessageBox.Show("0より大きい間隔にして下さい。", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    break;

                //case 2:
                //    if (e.FormattedValue.Equals(string.Empty))
                //    {
                //        MessageBox.Show("必須項目です。", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        e.Cancel = true;
                //    }
                //    break;
            }
        }
    }

    // ADD 2009/11/11 MANTIS対応[14363]：提供データ更新処理インターロックの追加 ---------->>>>>
    #region 提供データ更新処理インターロック

    /// <summary>
    /// 提供データ更新処理インターロッククラス
    /// </summary>
    internal static class OfferMergeInterlock
    {
        #region レジストリ情報

        /// <summary>バージョンを格納しているレジストリキー</summary>
        private const string VERSION_REGISTRY_KEY = @"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB";
        /// <summary>バージョンを格納しているレジストリキーを取得します。</summary>
        private static string VersionRegistryKey { get { return VERSION_REGISTRY_KEY; } }

        /// <summary>現在のバージョンのレジストリ値</summary>
        private const string CURRENT_VERSION_REGISTRY_VALUE = "CurrentVersion";
        /// <summary>現在のバージョンのレジストリ値を取得します。</summary>
        private static string CurrentVersionRegistryValue { get { return CURRENT_VERSION_REGISTRY_VALUE; } }

        /// <summary>対象バージョンのレジストリ値</summary>
        private const string TARGET_VERSION_REGISTRY_VALUE = "TargetVersion";
        /// <summary>対象バージョンのレジストリ値を取得します。</summary>
        private static string TargetVersionRegistryValue { get { return TARGET_VERSION_REGISTRY_VALUE; } }

        #endregion // レジストリ情報

        /// <summary>
        /// 更新処理を行えるか判断します。(サーバ用レジストリを参照します)
        /// </summary>
        /// <remarks>CurrentVersionとTargetVersionが同じ値であれば<c>true</c>を返します。</remarks>
        /// <returns>
        /// <c>true</c> :更新処理を行えます。<br/>
        /// <c>false</c>:更新処理を行えません。
        /// </returns>
        public static bool CanUpdate()
        {
            try
            {
                string currentVersion= string.Empty;
                string targetVersion = string.Empty;
                Microsoft.Win32.RegistryKey versionKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(VersionRegistryKey);
                {
                    currentVersion= (string)versionKey.GetValue(CurrentVersionRegistryValue);
                    targetVersion = (string)versionKey.GetValue(TargetVersionRegistryValue);
                }
                versionKey.Close();

                return currentVersion.Equals(targetVersion);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }

    #endregion // 提供データ更新処理インターロック
    // ADD 2008/11/11 MANTIS対応[14363]：提供データ更新処理インターロックの追加 ----------<<<<<
}
