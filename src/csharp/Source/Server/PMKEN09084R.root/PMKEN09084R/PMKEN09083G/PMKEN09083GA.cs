using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PartsSubstDspDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsSubstDspDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PartsSubstDspDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPartsSubstDspDB
    {
        /// <summary>
        /// PartsSubstDspDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        /// </remarks>
        public MediationPartsSubstDspDB()
        {
        }
        /// <summary>
        /// IPartsSubstDspDBインターフェース取得
        /// </summary>
        /// <returns>IPartsSubstDspDBオブジェクト</returns>
        public static IPartsSubstDspDB GetPartsSubstDspDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPartsSubstDspDB)Activator.GetObject(typeof(IPartsSubstDspDB), string.Format("{0}/MyAppPartsSubstDsp", wkStr));
        }
    }
}
