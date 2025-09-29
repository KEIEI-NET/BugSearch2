//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PMNS-HTT通信サービス
// プログラム概要   : PMNS-HTT間の通信を行うサービスプログラムです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 佐藤　智之
// 作 成 日  2017/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace PMHND00100S
{
    /// public class name:   Program
    /// <summary>
    ///                      メインクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   アプリケーションのメインクラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // 複数のユーザー サービスが同じプロセスで実行されている可能性があります。
            // このプロセスにもう 1 つサービスを追加するには、次の行を変更して 2 番目の
            // サービス オブジェクトを作成してください。たとえば、以下のとおりです。
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new PMHND00100S() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}