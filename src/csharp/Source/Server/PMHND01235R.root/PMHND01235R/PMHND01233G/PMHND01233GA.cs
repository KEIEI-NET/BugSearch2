//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー品番パターンマスタ
// プログラム概要   : メーカー品番パターンマスタ DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// IHandyMakerGoodsPtrnDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIHandyMakerGoodsPtrnDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接IHandyMakerGoodsPtrnDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 陳艶丹</br>
	/// <br>Date       : 2020/03/09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationHandyMakerGoodsPtrnDB
	{
		/// <summary>
        /// IHandyMakerGoodsPtrnDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 陳艶丹</br>
		/// <br>Date       : 2020/03/09</br>
		/// </remarks>
        public MediationHandyMakerGoodsPtrnDB()
		{
		}
		/// <summary>
        /// IHandyMakerGoodsPtrnDBインターフェース取得
		/// </summary>
        /// <returns>IHandyMakerGoodsPtrnDBオブジェクト</returns>
        public static IHandyMakerGoodsPtrnDB GetHandyMakerGoodsPtrnDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8001";
#endif
			
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyMakerGoodsPtrnDB)Activator.GetObject(typeof(IHandyMakerGoodsPtrnDB), string.Format("{0}/MyAppHandyMakerGoodsPtrn", wkStr));
		}
	}
}
