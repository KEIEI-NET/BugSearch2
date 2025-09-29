using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 最終印刷プリンタのI/Oクラスです
    /// </summary>
    class LastPrtPrinterAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region private member
        private string _xmlLastPrterFileName;                           // 最終印刷プリンタ保存用XMLのフルパス
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region private constant
        private const string XML_FNAME_LASTPRTER = "FrePLastPrter.xml";  // 最終印刷プリンタのＸＭＬファイル名を設定

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region constructor
        public LastPrtPrinterAcs()
        {
            //最終印刷プリンタ保存用のXMLパス
            this._xmlLastPrterFileName = ConstantManagement_ClientDirectory.Temp_UserTemp + "\\" + XML_FNAME_LASTPRTER;
        }
        #endregion

        #region 自由帳票最終印刷プリンタ登録・更新処理(Write)
        /// <summary>
        /// 自由帳票最終印刷プリンタ登録・更新処理
        /// </summary>
        /// <param name="lastTimes">自由帳票最終印刷プリンタディクショナリ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票最終印刷プリンタ情報の登録・更新を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2008.01.25</br>
        /// </remarks>
        public int Write(List<LastPrtPrinter> lastTimes)
        {
            // ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // ＸＭＬの書き込み（自由帳票最終印刷プリンタListシリアライズ処理）
                this.Serialize(lastTimes, this._xmlLastPrterFileName);

            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }
        #endregion

        #region 自由帳票最終印刷プリンタ検索処理(SearchAll)
        /// <summary>
        /// 自由帳票最終印刷プリンタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票最終印刷プリンタの全検索処理を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2008.01.25</br>
        /// </remarks>
        public int Search(out List<LastPrtPrinter> retList)
        {
            retList = null;

            int status = 0;
            try
            {
                // ＸＭＬの読み込み
                retList = XmlDeserialize();

                // 読込結果なしの場合はEOFを返す
                if ((retList == null) || (retList.Count <= 0))
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                return -1;
            }
            return status;
        }
        #endregion

        #region 最終印刷プリンタリストサーチ
        /// <summary>
        /// 最終印刷プリンタリストから指定のデータをサーチします
        /// </summary>
        /// <param name="lastTimes">最終印刷プリンタリスト</param>
        /// <param name="dialogMode">ダイアログモード</param>
        /// <param name="selectFlag">選択フラグ</param>
        /// <param name="lastPrinters">帳票使用区分</param>
        /// <returns>最終印刷プリンタ(見つからなかったときはNullを返す)</returns>
        public LastPrtPrinter FindLastPrtPrinter(List<LastPrtPrinter> lastPrinters, Int32 dialogMode, Int32 selectFlag, Int32 printPaperUseDivcd)
        {
            if (lastPrinters == null) return null;
            return lastPrinters.Find(delegate(LastPrtPrinter ptm) { return ((ptm.DialogMode == dialogMode) && (ptm.SelectFlag == selectFlag) && (ptm.PrintPaperUseDivcd == printPaperUseDivcd)); });
        }
        #endregion

        #region private methods

        #region 自由帳表最終印刷プリンタデシリアライズ処理
        /// <summary>
        /// XMLから自由帳表最終印刷プリンタクラスへデシリアライズします
        /// </summary>
        /// <returns>Dictionary<string,DateTime></returns>
        private List<LastPrtPrinter> XmlDeserialize()
        {
            return (List<LastPrtPrinter>)UserSettingController.DeserializeUserSetting(this._xmlLastPrterFileName, typeof(List<LastPrtPrinter>));
        }
        #endregion

        #region 自由帳票抽出条件明細Listシリアライズ処理
        /// <summary>
        /// 自由帳票抽出条件Listシリアライズ処理
        /// </summary>
        /// <param name="lastTimes">シリアライズ対象自由帳票最終印刷プリンタディクショナリ</param>
        /// <param name="fileName">シリアライズファイル名</param>
        private void Serialize(List<LastPrtPrinter> lastTimes, string fileName)
        {
            try
            {
                //格納ディレクトリがなければ作成
                if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.Temp_UserTemp) == false)
                {
                    System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.Temp_UserTemp);
                }
                UserSettingController.SerializeUserSetting(lastTimes, _xmlLastPrterFileName);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #endregion

    }

    /// <summary>
    /// 最終印刷プリンタ保持用のデータクラス
    /// </summary>
    public class LastPrtPrinter
    {
        public LastPrtPrinter()
        {
        }
        public Int32 DialogMode;           // ダイアログ表示モード0:プリンタ、帳票選択可　1:プリンタ設定のみ（一括印刷用）
        public Int32 SelectFlag;           // 選択フラグ（10:帳票,20:DM）
        public Int32 PrinterMngNo;         // プリンタ管理番号
        public Int32 PrintPaperUseDivcd;   // 帳票使用区分 (1:帳票,2:伝票,3:DM一覧表,4:DMはがき)
        public string PrinterName;
    }
}