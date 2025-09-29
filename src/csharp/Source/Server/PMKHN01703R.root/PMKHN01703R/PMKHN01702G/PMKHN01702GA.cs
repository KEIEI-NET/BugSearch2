//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業MeijiGoodsChgAllDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// MeijiGoodsChgAllDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIMeijiGoodsChgAllDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接MeijiGoodsChgAllDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2015/01/26</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationMeijiGoodsChgAllDB
	{
		/// <summary>
		/// GoodsNoChangeDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
		public MediationMeijiGoodsChgAllDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
        public static IMeijiGoodsChgAllDB GetMeijiGoodsChgAllDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMeijiGoodsChgAllDB)Activator.GetObject(typeof(IMeijiGoodsChgAllDB), string.Format("{0}/MyAppMeijiGoodsChgAll", wkStr));
		}
	}
}
