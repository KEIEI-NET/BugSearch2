using System;
using System.Data;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// 共通定数管理クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 共通定数管理クラスです。</br>
	/// <br>Programmer : 96137　久保田　信一</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note: 2008/12/19 PM.NS用に一部追加</br>
    /// <br></br>
    /// <br>Update Note: 2010/08/16 22018 鈴木 正臣  締次ロックタイムアウト追加</br>
    /// </remarks>
	public class ConstantManagement
	{
		/// <summary>
		/// 共通定数管理クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.03.17</br>
		/// </remarks>
		public ConstantManagement()
		{
		}

		/// <summary>
		/// ステータス
		/// </summary>
		public enum DB_Status
		{
			/// <summary>
			/// 正常終了
			/// </summary>
			ctDB_NORMAL	= 0,
			/// <summary>
			/// 検索結果無し
			/// </summary>
			ctDB_NOT_FOUND	= 4,
			/// <summary>
			/// 検索でEOFに達した 
			/// </summary>
			ctDB_EOF		= 9,
			/// <summary>
			/// INSERT時に重複
			/// </summary>
			ctDB_DUPLICATE	= 5,
			//↓↓↓↓↓保留
			//			ctDB_AGNST_REC		= 80,		// レコード矛盾
			//			ctDB_LOCK_ERR		= 81,		// ロックエラー
			//			ctDB_ALRDY_LOCKREC	= 84,		// レコードがロック済み
			//			ctDB_ALRDY_LOCKFILE	= 85,		// ファイルがロック済み
			//↑↑↑↑↑保留
			/// <summary>
			/// 排他（別端末更新済）
			/// </summary>
			ctDB_ALRDY_UPDATE	= 800,
			/// <summary>
			/// 排他（別端末物理削除済）
			/// </summary>
			ctDB_ALRDY_DELETE	= 801,
			/// <summary>
			/// 接続タイムアウト
			/// </summary>
			ctDB_CONCT_TIMEOUT  = 810,
            /// <summary>
            /// SQLコマンドタイムアウト
            /// </summary>
            ctDB_SQLCMD_TIMEOUT = 811,

            //--- ADD 2008/12/19 M.Kubota --->>>
            /// <summary>企業ロックタイムアウト</summary>
            ctDB_ENT_LOCK_TIMEOUT = 850,
            /// <summary>拠点ロックタイムアウト</summary>
            ctDB_SEC_LOCK_TIMEOUT = 851,
            /// <summary>倉庫ロックタイムアウト</summary>
            ctDB_WAR_LOCK_TIMEOUT = 852,
            //--- ADD 2008/12/19 M.Kubota ---<<<
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            /// <summary>締次ロックタイムアウト(集計側)</summary>
            ctDB_ADU_LOCK_TIMEOUT = 853,
            /// <summary>締次ロックタイムアウト(伝票側)</summary>
            ctDB_ADS_LOCK_TIMEOUT = 854,
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

			/// <summary>
			/// オフライン アクセス不可
			/// </summary>
			ctDB_OFFLINE		= OnlineMode.Offline,
            /// <summary>
            /// 警告発生
            /// </summary>
            ctDB_WARNING        = 999,
			/// <summary>
			/// エラー発生
			/// </summary>
			ctDB_ERROR			= 1000
		}


		/// <summary>
		/// オンラインモード
		/// </summary>
		public enum OnlineMode
		{
			/// <summary>
			/// オフライン
			/// </summary>
			Offline = 900,
			/// <summary>
			/// オンライン
			/// </summary>
			Online = 901
		}

		/// <summary>
		/// 論理削除データ取得区分
		/// </summary>
		public enum LogicalMode
		{
			/// <summary>
			/// 未削除データのみ取得
			/// </summary>
			GetData0   = 0,
			/// <summary>
			/// 論理削除データのみ取得
			/// </summary>
			GetData1   = 1,
			/// <summary>
			/// 保留データのみ取得
			/// </summary>
			GetData2   = 2,
			/// <summary>
			/// 削除確定データのみ取得
			/// </summary>
			GetData3   = 3,
			/// <summary>
			/// 全データ取得
			/// </summary>
			GetDataAll = 4,
			/// <summary>
			/// 未削除・論理削除データ取得
			/// </summary>
			GetData01  = 5,
			/// <summary>
			/// 未削除・論理削除・保留データ取得
			/// </summary>
			GetData012 = 6
		}

		/// <summary>
		/// メソッド戻り値定義
		/// </summary>
		/// <remarks>
		/// <br>Note       : メソッドの処理結果を定義します。</br>
		/// <br>Programer  : 980152  宮富 孝洋</br>
		/// <br>Date       : 2005.07.20</br>
		/// </remarks>
		public enum MethodResult: int
		{
			/// <summary>
			/// 正常終了
			/// </summary>
			ctFNC_NORMAL		= 0,
			/// <summary>
			/// メソッド処理結果無し  (メソッド本来の処理結果として戻すべき値が無い - 検索メソッドで検索結果0件など)
			/// </summary>
			ctFNC_NO_RETURN		= 1,
			/// <summary>
			/// 値取得部分失敗    (一部の値取得に失敗した - 名称取得には成功したが、値(金額・数量など)の取得には失敗した時など)
			/// </summary>
			ctFNC_PART_VAL_RTN	= 3,
			/// <summary>
			/// 警告・注意        (エラーでは有るが、PG終了には至らないor仕様により終了の場合)
			/// </summary>
			ctFNC_WARNING		= 5,
			/// <summary>
			/// 異常              (エラー発生の為、PG終了の場合)
			/// </summary>
			ctFNC_ERROR			= 9,
			/// <summary>
			/// キャンセル or 中断
			/// </summary>
			ctFNC_CANCEL		= -1,
			/// <summary>
			/// 子画面・機能関数系からの命令として、親ＥＸＥの終了要求を行う戻り値
			/// </summary>
			ctFNC_DO_END		= 9999
		}

        /// <summary>
        /// トランザクション分離レベル定義
        /// </summary>
        /// <remarks>
        /// <br>Note       : トランザクションの分離レベルを定義します。</br>
        /// <br>Programer  : 23002  上野　耕平</br>
        /// <br>Date       : 2006.10.10</br>
        /// </remarks>
        public enum DB_IsolationLevel
        {
            ctDB_Default = IsolationLevel.RepeatableRead,
            ctDB_ReadUnCommitted = IsolationLevel.ReadUncommitted,
            ctDB_ReadCommitted = IsolationLevel.ReadCommitted,
            ctDB_RepeatableRead = IsolationLevel.RepeatableRead,
            ctDB_SnapShot = IsolationLevel.Snapshot,
            ctDB_Serializable = IsolationLevel.Serializable
        }
	}
}
