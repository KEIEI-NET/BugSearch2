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
    /// 最終印刷日時のI/Oクラスです
    /// </summary>
	class LastPrtTimeAcs
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region private member
        private string _xmlLastPrtFileName;                           // 最終印刷日時保存用XMLのフルパス
        
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region private constant
        private const string XML_FNAME_LASTPRT = "FrePLastPrt.xml";  // 最終印刷日時のＸＭＬファイル名を設定
        
        #endregion

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region constructor
        public LastPrtTimeAcs()
        {
            //最終印刷日時保存用のXMLパス
            this._xmlLastPrtFileName = ConstantManagement_ClientDirectory.Temp_UserTemp + "\\" + XML_FNAME_LASTPRT;
        }
        //public LastPrtTimeAcs(SerializationInfo info, StreamingContext context)
        //{
        //}
        #endregion

        #region 自由帳票最終印刷日時登録・更新処理(Write)
        /// <summary>
        /// 自由帳票最終印刷日時登録・更新処理
        /// </summary>
        /// <param name="lastTimes">自由帳票最終印刷日時ディクショナリ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票最終印刷日時情報の登録・更新を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        public int Write(List<LastPrtTime> lastTimes)
        {
            // ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // ＸＭＬの書き込み（自由帳票最終印刷日時Listシリアライズ処理）
                this.Serialize(lastTimes, this._xmlLastPrtFileName);

            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }
        #endregion

        #region 自由帳票最終印刷日時検索処理(SearchAll)
        /// <summary>
        /// 自由帳票最終印刷日時検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票最終印刷日時の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        public int SearchAll(out List<LastPrtTime> retList)
        {
            retList = null;

            int status = 0;
            try
            {
                // ＸＭＬの読み込み
                retList = XmlDeserialize();

                // 読込結果なしの場合はEOFを返す
                if ((retList == null)||(retList.Count <= 0))
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

        #region キー作成
        //public string KeyGenerate(FrePprGrTr frePprGrTr)
        //{
        //    string keystring = string.Empty;
        //    if (frePprGrTr != null)
        //    {
        //        keystring = frePprGrTr.FreePrtPprGroupCd.ToString() + "," + frePprGrTr.TransferCode.ToString();
        //    }
        //    return keystring;
        //}
        #endregion

        #region 最終印刷日時リストサーチ
        /// <summary>
        /// 最終印刷日時リストから指定のデータをサーチします
        /// </summary>
        /// <param name="lastTimes">最終印刷日時リスト</param>
        /// <param name="frePprGrTr">自由帳票グループ振替</param>
        /// <returns>最終印刷日時(見つからなかったときはNullを返す)</returns>
        public LastPrtTime FindLastPrtTime(List<LastPrtTime> lastTimes, FrePprGrTr frePprGrTr)
        {
            return lastTimes.Find(delegate(LastPrtTime ptm) { return ((ptm.freePrtPprGroupCd == frePprGrTr.FreePrtPprGroupCd) && (ptm.transferCode == frePprGrTr.TransferCode)); });
        }              
        #endregion

        #region 最終印刷日時セット
        /// <summary>
        /// 最終印刷日時セット
        /// </summary>
        /// <param name="lastTime">最終印刷日時</param>
        /// <param name="frePprGrTr">自由帳票グループ振替</param>
        public void SetLastPrtTime(out LastPrtTime lastTime, FrePprGrTr frePprGrTr)
        {
            //if (lastTime == null) 
            lastTime = new LastPrtTime();
            lastTime.freePrtPprGroupCd = frePprGrTr.FreePrtPprGroupCd;
            lastTime.transferCode = frePprGrTr.TransferCode;
        }
        #endregion

        #region private methods

        #region 自由帳表最終印刷日時デシリアライズ処理
        /// <summary>
        /// XMLから自由帳表最終印刷日時クラスへデシリアライズします
        /// </summary>
        /// <returns>Dictionary(string,DateTime)</returns>
        private List<LastPrtTime> XmlDeserialize()
        {
            return (List<LastPrtTime>)UserSettingController.DeserializeUserSetting(this._xmlLastPrtFileName, typeof(List<LastPrtTime>));
        }
        #endregion

        #region 自由帳票抽出条件明細Listシリアライズ処理
        /// <summary>
        /// 自由帳票抽出条件Listシリアライズ処理
        /// </summary>
        /// <param name="lastTimes">シリアライズ対象自由帳票最終印刷日時ディクショナリ</param>
        /// <param name="fileName">シリアライズファイル名</param>
        private void Serialize(List<LastPrtTime> lastTimes, string fileName)
        {
            try
            {
                //格納ディレクトリがなければ作成
                if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.Temp_UserTemp) == false)
                {
                    System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.Temp_UserTemp);
                }
                UserSettingController.SerializeUserSetting(lastTimes, _xmlLastPrtFileName);
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
    /// 最終印刷日時保持用のデータクラス
    /// </summary>
    public class LastPrtTime
    {
        /// <summary>
        /// 
        /// </summary>
        public LastPrtTime()
        {
        }
        /// <summary></summary>
        public int freePrtPprGroupCd;
        /// <summary></summary>
        public int transferCode;
        /// <summary></summary>
        public DateTime lastPrtTime = DateTime.Now;
    }
}