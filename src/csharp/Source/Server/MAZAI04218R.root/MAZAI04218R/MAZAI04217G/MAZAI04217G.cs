using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// InventInputSearchDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIInventDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接InventInputSearchDBDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.04.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationInventInputSearchDB
    {
        /// <summary>
		/// InventInputSearchDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.07</br>
		/// </remarks>
		public MediationInventInputSearchDB()
		{
		}
		/// <summary>
		/// IInventInputSearchDBインターフェース取得
		/// </summary>
		/// <returns>IInventInputSearchDBオブジェクト</returns>
		/// <br>Note       : IInventInputSearchDBインターフェースを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.06</br>
		public static IInventInputSearchDB GetInventInputSearchDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IInventInputSearchDB)Activator.GetObject(typeof(IInventInputSearchDB),string.Format("{0}/MyAppInventInputSearch",wkStr));
		}
    }
}
