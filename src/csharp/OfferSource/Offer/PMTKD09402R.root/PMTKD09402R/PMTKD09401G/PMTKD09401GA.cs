//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良部品バーコード情報抽出リモート
// プログラム概要   : 優良部品バーコード情報抽出DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 優良部品バーコード情報抽出DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIOfferPrmPartsBrcdInfoクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接OfferPrmPartsBrcdInfoDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30757 佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferPrmPartsWidthBrcdInfo
	{
		/// <summary>
        /// 優良部品バーコード情報抽出DB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public MediationOfferPrmPartsWidthBrcdInfo()
		{
			
		}
		
		/// <summary>
        /// 優良部品バーコード情報抽出インターフェース取得
		/// </summary>
        /// <remarks>
        /// <br>Note       : OfferAPプロキシサービスより優良部品バーコード情報抽出インターフェース型のオブジェクトを取得する</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        /// <returns>優良部品バーコード情報抽出インターフェース型オブジェクト</returns>
        public static IOfferPrmPartsBrcdInfo GetOfferPrmPartsWidthBrcdInfo()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9012";
#endif
            return (IOfferPrmPartsBrcdInfo)Activator.GetObject( typeof( IOfferPrmPartsBrcdInfo ), string.Format( "{0}/MyAppOfferPrmPartsWidthBrcdInfo", wkStr ) );
        }

	}
}
