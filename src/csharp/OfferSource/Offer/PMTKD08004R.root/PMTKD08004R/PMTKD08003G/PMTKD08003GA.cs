using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// FrePSalesSlipOfferDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: このクラスはIFrePSalesSlipOfferDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			  完全スタンドアロンにする場合にはこのクラスで直接FrePSalesSlipOfferDBを</br>
	/// <br>			  インスタンス化して戻します。</br>
	/// <br>Programmer	: 22018 鈴木 正臣</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFrePSalesSlipOfferDB
	{
		/// <summary>
        /// FrePSalesSlipOfferDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
        public MediationFrePSalesSlipOfferDB()
		{
		}

		/// <summary>
        /// IFrePSalesSlipOfferDBインターフェース取得
		/// </summary>
		/// <returns>IPrtItemSetDBオブジェクト</returns>
		/// <remarks>
		/// <br>Note       : リモートオブジェクト取得用のプロキシを作成します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
        public static IFrePSalesSlipOfferDB GetFrePSalesSlipOfferDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain( ConstantManagement_SF_PRO.ServerCode_OfferAP );
# if DEBUG
            wkStr = "http://localhost:9002";
# endif
            return (IFrePSalesSlipOfferDB)Activator.GetObject( typeof( IFrePSalesSlipOfferDB ), string.Format( "{0}/MyAppFrePSalesSlipOffer", wkStr ) );
        }
	}
}
