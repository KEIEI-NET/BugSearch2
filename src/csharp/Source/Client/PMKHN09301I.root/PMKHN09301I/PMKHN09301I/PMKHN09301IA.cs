using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 掛率マスタインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note		: 掛率マスタ用インターフェースの定義</br>
    /// <br>Programer	: 30414 忍 幸史</br>
    /// <br>Date		: 2008/09/25</br>
    /// <br>Update Note : 2010/08/10 楊明俊 PM1012対応</br>
    /// <br>              ガイドを「Ｆ５」ボタンで表示するように変更</br>
    /// <br>Update Note : 2011/08/05 連番265 caohh</br>
    /// <br>              NSユーザー改良要望一覧連番265の対応</br>
    /// </remarks>
    public interface IRateMDIChild
    {
        #region ◆ イベント
        /// <summary>
        /// ツールバーボタン制御イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        event ParentToolbarRateSettingEventHandler ParentToolbarRateSettingEvent;
        #endregion

        /// <summary> 保存ボタンEnableプロパティ </summary>
        bool IsClose { get; }

        /// <summary> 保存ボタンEnableプロパティ </summary>
        bool IsNew { get; }

        /// <summary> 保存ボタンEnableプロパティ </summary>
        bool IsSave { get; }

        /// <summary> 保存ボタンEnableプロパティ </summary>
        bool IsDelete { get; }

        /// <summary> 保存ボタンEnableプロパティ </summary>
        bool IsRevival { get; }

        /// <summary> 保存ボタンEnableプロパティ </summary>
        bool IsRenewal { get; }
        //-----ADD 2010/08/10---------->>>>>
        /// <summary> GuideボタンEnableプロパティ </summary>
        bool IsGuide { get; }
        //-----ADD 2010/08/10----------<<<<<
        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary> SetUpボタンEnableプロパティ </summary>
        bool IsSetUp { get; }
        //-----ADD caohh 2011/08/05 ----------<<<<<

        #region ◆ Public Method
        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int BeforeClose(object parameter);

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 保存処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Save(object parameter);

        /// <summary>
        /// 新規処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 新規処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int New(object parameter);

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 削除処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Delete(object parameter);

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 復活処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Revival(object parameter);

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 最新情報を取得する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Renewal(object parameter);

        //-----ADD 2010/08/10---------->>>>>
        /// <summary>
        /// ガイド取得処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : ガイドを取得する</br>
        /// <br>Programer  : 楊明俊</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        int Guide(object parameter);
        //-----ADD 2010/08/10----------<<<<<

        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary>
        /// 設定取得処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 設定を取得する</br>
        /// <br>Programer  : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        int SetUp(object parameter);
        //-----ADD caohh 2011/08/05 ----------<<<<<
        #endregion ◆ Public Method
    }
    #region ◆ デリゲート
    /// <summary>
    /// ツールバーボタン制御
    /// </summary>
    /// <param name="targetForm">パラメータ</param>
    /// <remarks>
    /// <br>Note       : ツールバーの制御を行います。</br>
    /// <br>Programer  : 30414 忍 幸史</br>
    /// <br>Date       : 2008/09/25</br>
    /// </remarks>
    public delegate void ParentToolbarRateSettingEventHandler(object targetForm);
    #endregion

}
