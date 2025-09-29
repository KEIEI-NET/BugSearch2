//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形データメンテナンス
// プログラム概要   : 手形データ設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受取手形データマスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受取手形データマスタDBインターフェースです。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRcvDraftDataDB
    {
        /// <summary>
        /// 受取手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="paraRcvDraftDataWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタのキー値が一致する、全ての受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// 受取手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="paraRcvDraftDataWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データ番号値が一致する、受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithoutBabCd([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 受取手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="paraRcvDraftDataWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データ番号値と銀行・支店コード値が一致する、受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithBabCd([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 受取手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="paraRcvDraftDataWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データ番号値と銀行・支店コード値が一致する、受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithDrawingDate([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
                  out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        // ----- ADD zhuhh 2013/01/10 for Redmime #34123 -----<<<<<

        /// <summary>
        /// 受取手形データマスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">RcvDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタを追加・更新します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);

        /// <summary>
        /// 受取手形データマスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">RcvDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報を論理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);

        /// <summary>
        /// 論理削除受取手形データマスタ情報情報を復活します
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">RcvDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除受取手形データマスタ情報情報を復活します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);

        /// <summary>
        /// 受取手形データマスタ情報を物理削除します
        /// </summary>
        /// <param name="outRcvDraftDataList">RcvDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタ情報を物理削除します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork")]
            ref object outRcvDraftDataList);
    }


    /// <summary>
    /// 支払手形データマスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払手形データマスタDBインターフェースです。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPayDraftDataDB
    {
        /// <summary>
        /// 支払手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="paraPayDraftDataList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// 支払手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="paraPayDraftDataList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithoutBab([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 支払手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="paraPayDraftDataList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithBab([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 支払手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="paraPayDraftDataList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchWithDrawingDate([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
                  out object outPayDraftDataList, object paraPayDraftDataList, int readMode, ConstantManagement.LogicalMode logicalMode);
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

        /// <summary>
        /// 支払手形データマスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">PayDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタを追加・更新します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);

        /// <summary>
        /// 支払手形データマスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">PayDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタ情報を論理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);

        /// <summary>
        /// 論理削除支払手形データマスタ情報情報を復活します
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">PayDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除支払手形データマスタ情報情報を復活します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);

        /// <summary>
        /// 支払手形データマスタ情報を物理削除します
        /// </summary>
        /// <param name="outPayDraftDataList">PayDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタ情報を物理削除します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork")]
            ref object outPayDraftDataList);
    }
}
