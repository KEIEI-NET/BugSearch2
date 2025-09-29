using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{

    /// <summary>
	/// UOE発注回答一覧データ変換クラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : UOE発注回答一覧データ変換クラス</br>
    /// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/11/10</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE04204EA : IExtrProc
    {
        #region ■定数、変数等
        // 定数
        private const string ct_PGID = "PMUOE04204E";                   // プログラムID
        // 変数
        private SFCMN06002C _printInfo = null;			                // 印刷情報クラス
        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion

        #region ■Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
        /// <param name="printInfo">印刷情報</param>
		/// <remarks>
		/// <br>Note       : 初期化を行います。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
		/// <br></br>
		/// </remarks>
        public PMUOE04204EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
        }

		static PMUOE04204EA()
		{
			stc_SecInfoAcs = new SecInfoAcs(1);    // 拠点アクセスクラス
			stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey(secInfoSet.SectionCode) )
                {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
		}
        #endregion ■Constructor - end

        #region ■IExtrProc メンバ
        #region ◆Public Property
        /// <summary> 印刷情報クラスプロパティ </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion ◆Public Property - end

        #region ▼ExtrPrintData(抽出処理)
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public int ExtrPrintData()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            
			try
			{
                form.Show();			    // ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
		}
		#endregion
        #endregion ■IExtrProc メンバ - end

        #region ■Private
        #region ▼ExtraProc(抽出メイン処理)
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private int ExtraProc()
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;      // 異常
			string errMsg = "";

            try
            {
                // DataTable取得　※.ToTable()で抽出されたデータのみ取得
                DataView dataView = (DataView)this.Printinfo.rdData;
                DataTable dataTable = dataView.ToTable();

                // DataTableに対する処理
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    dataRow[PMUOE04202EA.ct_Col_SectionName] = GetSectionGuideNm(dataRow[PMUOE04202EA.ct_Col_SectionCode].ToString());      // 拠点名称
                }

                // DataTable→DataView変換
                this.Printinfo.rdData = new DataView(dataTable);
                if (this._printInfo.rdData == null)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;      // データなし
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;         // 正常
                }
			}
			catch (Exception ex)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
							// ステータスが異常のときはメッセージを表示
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
            }
            return status;
		}
		#endregion

        #region ▼GetSectionGuideNm(拠点ガイド名称取得)
        /// <summary>
		/// 拠点ガイド名称取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点ガイド名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点ガイド名称の取得を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private string GetSectionGuideNm(string sectionCode)
		{
			if (stc_SectionDic.ContainsKey(sectionCode))
			{
				return stc_SectionDic[sectionCode].SectionGuideNm;
			}
			else
			{
				return string.Empty;
			}
        }
        #endregion

        #region ▼MsgDispProc(エラーメッセージ表示)
        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion
        #endregion ■Private - end
    }
}
