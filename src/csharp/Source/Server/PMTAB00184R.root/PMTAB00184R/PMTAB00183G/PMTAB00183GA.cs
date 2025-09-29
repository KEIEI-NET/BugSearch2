//**********************************************************************//
// システム         ：PM.NS                                             //
// プログラム名称   ：PMTABアップロード排他制御検索マスタ仲介クラス     // 
// プログラム概要   ：PMTABアップロード排他制御検索マスタ仲介クラス     //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴                                                                 //
//----------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 鄭慕鈞                              //
// 作 成 日  2013/06/24  作成内容 : 新規作成                            //
//----------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// PmTabUpldExclsvDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIPmTabUpldExclsvDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接PmTabUpldExclsvDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 鄭慕鈞 </br>
    /// <br>Date       : 2013/06/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPmTabUpldExclsvDB
	{
		/// <summary>
		/// PmTabUpldExclsvDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 鄭慕鈞 </br>
        /// <br>Date       : 2013/06/24</br>
		/// </remarks>
        public MediationPmTabUpldExclsvDB()
		{
		}
		/// <summary>
        /// IPmTabUpldExclsvDBインターフェース取得
		/// </summary>
        /// <returns>IPmTabUpldExclsvDBオブジェクト</returns>
        public static IPmTabUpldExclsvDB GetPmtUpldExclsvDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9020";
#endif
			
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPmTabUpldExclsvDB)Activator.GetObject(typeof(IPmTabUpldExclsvDB), string.Format("{0}/MyAppPmTabUpldExclsv", wkStr));
		}
	}
}
