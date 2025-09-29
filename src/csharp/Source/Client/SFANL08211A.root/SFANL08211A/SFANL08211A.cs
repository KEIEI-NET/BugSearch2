using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;				
using Broadleaf.Application.Remoting.ParamData;	
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票グループテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票グループテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 22011 柏原 頼人</br>
	/// <br>Date       : 2007.07.27</br>
    /// <br>Update Note: </br>
    /// <br>             </br>
    /// </remarks>
	public class FrePprDailyAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IFrePDailyExtRetDB _iFrePDailyExtRetDB = null;
		
        #region Constructor
        /// <summary>
		/// 自由帳票グループテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票グループテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.07.27</br>
		/// </remarks>
        public FrePprDailyAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iFrePDailyExtRetDB = MediationFrePDailyExtRetDB.GetFrePDailyExtRetDB();
         	}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iFrePDailyExtRetDB = null;
			}
        }
        #endregion

        #region 自由帳票グループ検索処理（論理削除区分は無視）
        /// <summary>
		/// 自由帳票グループ検索処理（論理削除区分は無視）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="frePExtPrmWk">自由帳票共通抽出パラメータクラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.07.27</br>
		/// </remarks>
		public int Search(out List<FrePDailyExtRetWork> retList, FrePrtCmnExtPrmWork frePExtPrmWk)
		{
			return SearchProc(out retList, frePExtPrmWk, ConstantManagement.LogicalMode.GetData01);
        }
        #endregion

        #region 自由帳票グループ検索処理
        /// <summary>
		/// 自由帳票グループ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="frePExtPrmWk"></param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループの検索処理を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.07.27</br>
		/// </remarks>
		private int SearchProc(out List<FrePDailyExtRetWork> retList,
			FrePrtCmnExtPrmWork frePExtPrmWk,
			ConstantManagement.LogicalMode logicalMode)
		{
            retList = new List<FrePDailyExtRetWork>();
            Object retObj;
            Object paraObj = XmlByteSerializer.Serialize(frePExtPrmWk);

            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列

            // 自由帳票グループ検索
            int status = 0;
            status = this._iFrePDailyExtRetDB.Search(paraObj, out retObj, out msgDiv, out errMsg);

            if (status == 0)
            {
                // パラメータが渡って来ているか確認
                retList = retObj as List<FrePDailyExtRetWork>;
            }
            if (msgDiv == true)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP, 		                // エラーレベル
                    "FrePprDailyAcs", 				                    // アセンブリＩＤまたはクラスＩＤ
                    "自由帳票日次帳票グループアクセスクラス", 	        // プログラム名称
                    "SearchProc", 			                            // 処理名称
                    TMsgDisp.OPE_READ, 		    		                // オペレーション
                    "検索に失敗しました。\r\n\r\n*詳細 = " + errMsg, 	// 表示するメッセージ
                    status, 							                // ステータス値
                    this._iFrePDailyExtRetDB, 				            // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				                // 表示するボタン
                    MessageBoxDefaultButton.Button1);	                // 初期表示ボタン
            }
			return status;
        }
        #endregion

        #region 自由帳票グループListクラスデシリアライズ処理 DEL
        ///// ********************************************************************
        ///// <summary>
        ///// 自由帳票グループListクラスデシリアライズ処理
        ///// </summary>
        ///// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        ///// <returns>自由帳票グループクラスLIST</returns>
        ///// <remarks>
        ///// <br>Note       : 自由帳票グループリストクラスをデシリアライズします。</br>
        ///// <br>Programmer : 22011 柏原 頼人</br>
        ///// <br>Date       : 2007.07.27</br>
        ///// </remarks>
        ///// ********************************************************************
        //public List<FrePDailyExtRetWork> FreePprGrpListDeserialize(string fileName)
        //{
        //    ArrayList al = new ArrayList();

        //    // ファイル名を渡して自由帳票グループワーククラスをデシリアライズする
        //    FrePDailyExtRetWork[] frePDailyExtRetWorks;
        //    frePDailyExtRetWorks = (FrePDailyExtRetWork[])XmlByteSerializer.Deserialize(fileName, typeof(FrePDailyExtRetWork[]));

        //    //デシリアライズ結果を自由帳票グループＵＩクラスへコピー
        //    if (frePDailyExtRetWorks != null) 
        //    {
        //        al.Capacity = frePDailyExtRetWorks.Length;
        //        for(int i=0; i < frePDailyExtRetWorks.Length; i++)
        //        {
        //            al.Add(frePDailyExtRetWorks[i]);
        //        }
        //    }
        //    return al;
        //}
        //#endregion

        //#region 自由帳票グループListシリアライズ処理
        ///// *****************************************************************
        ///// <summary>
        ///// 自由帳票グループListシリアライズ処理
        ///// </summary>
        ///// <param name="frePDailyExtRetWork">シリアライズ対象自由帳票グループListクラス</param>
        ///// <param name="fileName">シリアライズファイル名</param>
        ///// <remarks>
        ///// <br>Note       : 自由帳票グループList情報のシリアライズを行います。</br>
        ///// <br>Programmer : 22011 柏原 頼人</br>
        ///// <br>Date       : 2007.04.27</br>
        ///// </remarks>
        ///// ******************************************************************
        //public void FreePprGrpListSerialize(List<FrePDailyExtRetWork> frePDailyExtRetWork, string fileName)
        //{
        //    FrePDailyExtRetWork[] frePDailyExtRetWorks = new FrePDailyExtRetWork[frePDailyExtRetWork.Count];
        //    //自由帳票グループワーカークラスをシリアライズ
        //    XmlByteSerializer.Serialize(frePDailyExtRetWorks, fileName);
        //}
        #endregion
	}
}