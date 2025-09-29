using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 売上目標設定インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上目標設定用インターフェースの定義</br>
    /// <br>Programer	: 30414 忍 幸史</br>
    /// <br>Date		: 2008/10/08</br>
    /// </remarks>
    public interface ISalesTargetMDIChild
    {
        #region ◆ イベント
        /// <summary>
        /// ツールバーボタン制御イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        event ParentToolbarSalesTargetEventHandler ParentToolbarSalesTargetEvent;
        #endregion

        /// <summary> 終了ボタンVisibleプロパティ </summary>
        bool IsClose { get; }

        /// <summary> 新規ボタンVisibleプロパティ </summary>
        bool IsNew { get; }

        /// <summary> 保存ボタンVisibleプロパティ </summary>
        bool IsSave { get; }

        /// <summary> 論理削除ボタンVisibleプロパティ </summary>
        bool IsLogicalDelete { get; }

        /// <summary> 完全削除ボタンVisibleプロパティ </summary>
        bool IsDelete { get; }

        /// <summary> 復活ボタンVisibleプロパティ </summary>
        bool IsRevival { get; }

        /// <summary> 元に戻すボタンVisibleプロパティ </summary>
        bool IsUndo { get; }

        /// <summary> 比率から計算ボタンVisibleプロパティ </summary>
        bool IsCalc { get; }

        /// <summary> 最新情報ボタンVisibleプロパティ </summary>
        bool IsRenewal { get; }

        #region ◆ Public Method
        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int BeforeClose();

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 保存処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Save();

        /// <summary>
        /// 新規処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 新規処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int New();

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int LogicalDelete();

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 削除処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Delete();

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 復活処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Revival();

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 元に戻す処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Undo();

        /// <summary>
        /// 比率から計算処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 比率から計算処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Calc();

        /// <summary>
        /// 最新情報処理
        /// </summary>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : キャッシュ保持しているデータの最新情報を取得</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Renewal();

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期フォーカス設定を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        void SetFocus();

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
    /// <br>Date       : 2008/10/08</br>
    /// </remarks>
    public delegate void ParentToolbarSalesTargetEventHandler(object targetForm);
    #endregion

}
