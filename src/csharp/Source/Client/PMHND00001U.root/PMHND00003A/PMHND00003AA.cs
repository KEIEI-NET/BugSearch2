//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐
// プログラム概要   : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : ハンディターミナル二次開発の対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 譚洪
// 作 成 日  2020/03/09  修正内容 : PMKOBETSU-3268の対応
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐
    /// </summary>
    /// <remarks>
    /// <br>Note       : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐アクセスクラス</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/06</br>
    /// <br>Update Note : 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>           : ハンディターミナル二次開発の対応</br>
    /// </remarks>
    public class PmHandy : MarshalByRefObject, IPmHandy
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region コンスト Memebers
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // 情報が見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // 検品対象伝票ではありませんのステータス
        private const int StatusNonTarget = 6;
        // 仕入先伝票番号の重複チェックステータス
        private const int StatusRegists = 7;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>他でデータが変更済みの場合、（ST_ARSET）のステータス</summary>
        private const int StatusArset = -2;

        /// <summary>ログイン情報取得プログラムID</summary>
        private const string AssemblyIdPmhnd00010a = "PMHND00010A";
        /// <summary>ログイン情報取得プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd00010aClassName = "Broadleaf.Application.Controller.HandyLoginInfoAcs";
        /// <summary>ログイン情報取得条件プログラムID</summary>
        private const string AssemblyIdPmhnd00014d = "PMHND00014D";
        /// <summary>ログイン情報取得条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd00014dClassName = "Broadleaf.Application.Remoting.ParamData.HandyLoginInfoCondWork";
        /// <summary>ログイン情報取得結果プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd00014dResultClassName = "Broadleaf.Application.Remoting.ParamData.HandyLoginInfoWork";
        /// <summary>ログイン情報取得メソッド名</summary>
        private const string AssemblyIdPmhnd00010aMethodName = "SearchHandyLoginInfo";

        /// <summary>在庫情報取得(通常)プログラムID</summary>
        private const string AssemblyIdPmhnd04100a = "PMHND04100A";
        /// <summary>在庫情報取得(通常)プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04100aClassName = "Broadleaf.Application.Controller.HandyStockInfoAcs";
        /// <summary>在庫情報取得(通常)取得条件プログラムID</summary>
        private const string AssemblyIdPmhnd04104d = "PMHND04104D";
        /// <summary>在庫情報取得(通常)取得条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04104dClassName = "Broadleaf.Application.Remoting.ParamData.HandyStockCondWork";
        /// <summary>在庫情報取得(通常)取得メソッド名</summary>
        private const string AssemblyIdPmhnd04100aMethodName = "SearchHandyStockInfo";

        /// <summary>在庫情報取得(先行検品)プログラムID</summary>
        private const string AssemblyIdPmhnd04110a = "PMHND04110A";
        /// <summary>在庫情報取得(先行検品)プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04110aClassName = "Broadleaf.Application.Controller.HandyStockInspectAcs";
        /// <summary>在庫情報取得(先行検品)取得メソッド名</summary>
        private const string AssemblyIdPmhnd04110aMethodName = "SearchHandyStockInspect";

        /// <summary>検品対象取得(伝票番号)プログラムID</summary>
        private const string AssemblyIdPmhnd04000a = "PMHND04000A";
        /// <summary>検品対象取得(伝票番号)プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04000aClassName = "Broadleaf.Application.Controller.HandyInspectSlipNumAcs";
        /// <summary>検品対象取得(伝票番号)取得条件プログラムID</summary>
        private const string AssemblyIdPmhnd04004d = "PMHND04004D";
        /// <summary>検品対象取得(伝票番号)取得条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04004dClassName = "Broadleaf.Application.Remoting.ParamData.HandyInspectCondWork";
        /// <summary>検品対象取得(伝票番号)取得メソッド名</summary>
        private const string AssemblyIdPmhnd04000aMethodName = "SearchHandyInspectData";

        /// <summary>検品対象取得(一括検品)プログラムID</summary>
        private const string AssemblyIdPmhnd04010a = "PMHND04010A";
        /// <summary>検品対象取得(一括検品)プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04010aClassName = "Broadleaf.Application.Controller.HandyInspectTotalAcs";
        /// <summary>検品対象取得(一括検品)取得メソッド名</summary>
        private const string AssemblyIdPmhnd04010aMethodName = "SearchHandyInspectData";

        /// <summary>検品データ登録処理プログラムID</summary>
        private const string AssemblyIdPmhnd01000a = "PMHND01000A";
        /// <summary>検品データ登録処理プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01000aClassName = "Broadleaf.Application.Controller.HandyInspectDataAcs";
        /// <summary>検品データ登録処理ワークプログラムID</summary>
        private const string AssemblyIdPmhnd00213d = "PMHND00213D";
        /// <summary>検品データ登録処理ワークプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd00213dClassName = "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork";
        /// <summary>検品データ登録処理登録メソッド名</summary>
        private const string AssemblyIdPmhnd01000aMethodName = "WriteInspectData";

        /// <summary>検品データ登録(先行検品)プログラムID</summary>
        private const string AssemblyIdPmhnd01010a = "PMHND01010A";
        /// <summary>検品データ登録(先行検品)プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01010aClassName = "Broadleaf.Application.Controller.HandySenKouInspectAcs";
        /// <summary>検品データ登録(先行検品)メソッド名</summary>
        private const string AssemblyIdPmhnd01010aMethodName = "WriteSenKouInspect";

        /// <summary>商品バーコード関連付けマスタ登録プログラムID</summary>
        private const string AssemblyIdPmhnd09301a = "PMHND09301A";
        /// <summary>商品バーコード関連付けマスタ登録プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd09301aClassName = "Broadleaf.Application.Controller.HandyGoodsBarCodeAcs";
        /// <summary>商品バーコード関連付けマスタ登録ワークプログラムID</summary>
        private const string AssemblyIdPmhnd09308d = "PMHND09308D";
        /// <summary>商品バーコード関連付けマスタ登録ワークプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd09308dClassName = "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork";
        /// <summary>商品バーコード関連付けマスタ登録メソッド名</summary>
        private const string AssemblyIdPmhnd09301aMethodName = "InsertHandyGoodsBarCode";

        // ------ ADD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>ハンディターミナル発注先ガイドプログラムID</summary>
        private const string AssemblyIdPmhnd04300a = "PMHND04300A";
        /// <summary>ハンディターミナル発注先ガイドプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04300aClassName = "Broadleaf.Application.Controller.HandySupplierGuideAcs";
        /// <summary>ハンディターミナル発注先ガイドワークプログラムID</summary>
        private const string AssemblyIdPmhnd04304d = "PMHND04304D";
        /// <summary>ハンディターミナル発注先ガイドワークプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd04304dClassName = "Broadleaf.Application.Remoting.ParamData.SupplierGuideParamWork";
        /// <summary>ハンディターミナル発注先ガイドメソッド名</summary>
        private const string AssemblyIdPmhnd04300aMethodName = "SearchHandySupplierGuide";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）プログラムID</summary>
        private const string AssemblyIdPmhnd01100a = "PMHND01100A";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）一覧抽出の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01100a1 = "PMHND01100A1";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）明細抽出の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01100a2 = "PMHND01100A2";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01100a3 = "PMHND01100A3";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01100aClassName = "Broadleaf.Application.Controller.HandyStockSupplierAcs";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムIDのクラス名(Fw:ForWriteの略称)</summary>
        private const string AssemblyIdPmhnd01114dClassNameFw = "Broadleaf.Application.Remoting.ParamData.InspectDataAddWork";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムIDのクラス名(Fsl:ForSearchListの略称)</summary>
        private const string AssemblyIdPmhnd01114dClassNameFsl = "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderListParamWork";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムIDのクラス名(Fsd:ForSearchDetailの略称)</summary>
        private const string AssemblyIdPmhnd01114dClassNameFsd = "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderDtlParamWork";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）メソッド名(Fsl:ForSearchListの略称)</summary>
        private const string AssemblyIdPmhnd01100aMethodNameFsl = "SearchHandyStockSupplierList";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）メソッド名(Fsd:ForSearchDetailの略称)</summary>
        private const string AssemblyIdPmhnd01100aMethodNameFsd = "SearchHandyStockSupplierSlipNum";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）メソッド名(Fw:ForWriteの略称)</summary>
        private const string AssemblyIdPmhnd01100aMethodNameFw = "WriteHandyStockSupplier";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）ワークプログラムIDのクラス名(Fnsd:ForNoUoeSearchDetailの略称)</summary>
        private const string AssemblyIdPmhnd01114dClassNameFnsd = "Broadleaf.Application.Remoting.ParamData.HandyNonUOEStockParamWork";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）ワークプログラムIDのクラス名(Fnw:ForNoUoeWriteの略称)</summary>
        private const string AssemblyIdPmhnd01114dClassNameFnw = "Broadleaf.Application.Remoting.ParamData.HandyNonUOEInspectParamWork";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）プログラムID</summary>
        private const string AssemblyIdPmhnd01110a = "PMHND01110A";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）明細抽出の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01110a1 = "PMHND01110A1";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01110a2 = "PMHND01110A2";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01110aClassName = "Broadleaf.Application.Controller.HandyNonUOEInspectAcs";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）メソッド名(Fw:ForWriteの略称)</summary>
        private const string AssemblyIdPmhnd01110aMethodNameFw = "WriteHandyNonUOEInspect";
        /// <summary>ハンディターミナル在庫仕入（UOE以外）メソッド名(Fnsd:ForNoUoeSearchDetailの略称)</summary>
        private const string AssemblyIdPmhnd01110aMethodNameFnsd = "SearchHandyNonUOEStockSupplier";
        /// <summary>ハンディターミナル発注先ガイドプログラム名称</summary>
        private const string AssemblyNamePmhnd04300a = "発注先ガイド";
        /// <summary>在庫仕入（入庫更新）　登録プログラム名称(Fw:ForWriteの略称)</summary>
        private const string AssemblyNamePmhnd01100aFw = "在庫仕入（入庫更新）　登録";
        /// <summary>在庫仕入（入庫更新）　選択プログラム名称(Fsl:ForSearchListの略称)</summary>
        private const string AssemblyNamePmhnd01100aFsl = "在庫仕入（入庫更新）　選択";
        /// <summary>在庫仕入（入庫更新）　検品プログラム名称(Fsd:ForSearchDetailの略称)</summary>
        private const string AssemblyNamePmhnd01100aFsd = "在庫仕入（入庫更新）　検品";
        /// <summary>在庫仕入（入庫更新）　登録プログラム名称(Fw:ForWriteの略称)</summary>
        private const string AssemblyNamePmhnd01110aFw = "在庫仕入（UOE以外）　登録";
        /// <summary>在庫仕入（入庫更新）　選択プログラム名称(Fnsd:ForNoUoeSearchDetailの略称)</summary>
        private const string AssemblyNamePmhnd01110aFnsd = "在庫仕入（UOE以外）　検品";

        /// <summary>ハンディターミナル委託在庫補充プログラムID</summary>
        private const string AssemblyIdPmhnd01300a = "PMHND01300A";
        /// <summary>ハンディターミナル委託在庫補充_倉庫情報抽出の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01300a1 = "PMHND01300A1";
        /// <summary>ハンディターミナル委託在庫補充_検品情報抽出の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01300a2 = "PMHND01300A2";
        /// <summary>ハンディターミナル委託在庫補充_検品情報登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01300a3 = "PMHND01300A3";
        /// <summary>ハンディターミナル委託在庫補充プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01300aClassName = "Broadleaf.Application.Controller.HandyConsStockRepAcs";
        /// <summary>ハンディターミナル委託在庫補充ワークプログラムID</summary>
        private const string AssemblyIdPmhnd01304d = "PMHND01304D";
        /// <summary>ハンディターミナル委託在庫補充_倉庫情報抽出条件ワークプログラムIDのクラス名(Fsw:ForSearchWarehouseの略称)</summary>
        private const string AssemblyIdPmhnd01304dClassNameFsw = "Broadleaf.Application.Remoting.ParamData.ConsStockRepWarehouseParamWork";
        /// <summary>ハンディターミナル委託在庫補充_検品情報抽出ワークプログラムIDのクラス名(Fsi:ForSearchInspectの略称)</summary>
        private const string AssemblyIdPmhnd01304dClassNameFsi = "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectParamWork";
        /// <summary>ハンディターミナル委託在庫補充_検品情報登録条件ワークプログラムIDのクラス名(Fiw:ForInspectWriteの略称)</summary>
        private const string AssemblyIdPmhnd01304dClassNameFiw = "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectDataParamWork";
        /// <summary>ハンディターミナル委託在庫補充_倉庫情報抽出メソッド名(Fsw:ForSearchWarehouseの略称)</summary>
        private const string AssemblyIdPmhnd01300aMethodNameFsw = "SearchHandyWarehouseInfo";
        /// <summary>ハンディターミナル委託在庫補充_検品情報抽出メソッド名(Fsi:ForSearchInspectの略称)</summary>
        private const string AssemblyIdPmhnd01300aMethodNameFsi = "SearchHandyInspectInfo";
        /// <summary>ハンディターミナル委託在庫補充_検品情報登録メソッド名(Fiw:ForInspectWriteの略称)</summary>
        private const string AssemblyIdPmhnd01300aMethodNameFiw = "WriteHandyConsStockRepInspect";
        /// <summary>ハンディターミナル委託在庫補充_倉庫情報抽出プログラム名称(Fsw:ForSearchWarehouseの略称)</summary>
        private const string AssemblyNamePmhnd01300aFsw = "委託在庫補充　選択";
        /// <summary>ハンディターミナル委託在庫補充_検品情報抽出プログラム名称(Fsi:ForSearchInspectの略称)</summary>
        private const string AssemblyNamePmhnd01300aFsi = "委託在庫補充　検品";
        /// <summary>ハンディターミナル委託在庫補充_検品情報登録プログラム名称(Fiw:ForInspectWriteの略称)</summary>
        private const string AssemblyNamePmhnd01300aFiw = "委託在庫補充　登録";

        /// <summary>登録パラメータnullメッセージ</summary>
        private const string InsertConditionsError = "登録条件がnullです。";
        /// <summary>従業員情報エラーメッセージ</summary>
        private const string EmployeeError = "従業員コードが登録していない。";
        /// <summary>指定のアセンブリのワークタイプエラーメッセージ</summary>
        private const string AssemblyWorkError = "指定のアセンブリのワークが存在しません。";
        // ------ ADD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// <summary>ハンディターミナル在庫仕入プログラムID</summary>
        private const string AssemblyIdPmhnd01200a = "PMHND01200A";
        /// <summary>ハンディターミナル在庫仕入（入荷）　検品の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01200a1 = "PMHND01200A1";
        /// <summary>ハンディターミナル在庫仕入（入荷）　登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01200a2 = "PMHND01200A2";
        /// <summary>ハンディターミナル在庫仕入（出荷）　検品の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01200a3 = "PMHND01200A3";
        /// <summary>ハンディターミナル在庫仕入（出荷）　登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01200a4 = "PMHND01200A4";
        /// <summary>ハンディターミナル在庫仕入プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01200aClassName = "Broadleaf.Application.Controller.HandyStockAcs";
        /// <summary>ハンディターミナル在庫仕入在庫情報取得メソッド名(Sel:Selectの略称)</summary>
        private const string AssemblyIdPmhnd01200aSelMethodName = "SearchStock";
        /// <summary>ハンディターミナル在庫仕入検品データ登録(先行検品)メソッド名(Wt:Writeの略称)</summary>
        private const string AssemblyIdPmhnd01200aWtMethodName = "WriteHandyInspect";

        /// <summary>ハンディターミナル在庫移動プログラムID</summary>
        private const string AssemblyIdPmhnd01210a = "PMHND01210A";
        /// <summary>ハンディターミナル在庫移動（出荷）　検品の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01210a1 = "PMHND01210A1";
        /// <summary>ハンディターミナル在庫移動（出荷）　登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01210a2 = "PMHND01210A2";
        /// <summary>ハンディターミナル在庫移動（入荷）　検品の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01210a3 = "PMHND01210A3";
        /// <summary>ハンディターミナル在庫移動（入荷）　登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd01210a4 = "PMHND01210A4";
        /// <summary>ハンディターミナル在庫移動プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01210aClassName = "Broadleaf.Application.Controller.HandyStockMoveAcs";
        /// <summary>ハンディターミナル在庫移動取得条件プログラムID</summary>
        private const string AssemblyIdPmhnd01214d = "PMHND01214D";
        /// <summary>ハンディターミナル在庫移動取得条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01214dClassName = "Broadleaf.Application.Remoting.ParamData.HandyStockMoveCondWork";
        /// <summary>ハンディターミナル在庫移動取得メソッド名(Sel:Selectの略称)</summary>
        private const string AssemblyIdPmhnd01210aSelMethodName = "SearchStockMoveData";
        /// <summary>ハンディターミナル在庫移動検品データ登録メソッド名(Wt:Writeの略称)</summary>
        private const string AssemblyIdPmhnd01210aWtMethodName = "WriteStockMoveInspect";

        /// <summary>在庫仕入（入荷）　検品プログラム名称(ES:EnterSearchの略称)</summary>
        private const string AssemblyNamePmhnd01200ES = "在庫仕入（入荷）　検品";
        /// <summary>在庫仕入（入荷）　登録プログラム名称(EW:EnterWriteの略称)</summary>
        private const string AssemblyNamePmhnd01200EW = "在庫仕入（入荷）　登録";
        /// <summary>在庫仕入（出荷）　検品プログラム名称(S:Searchの略称)</summary>
        private const string AssemblyNamePmhnd01200S = "在庫仕入（出荷）　検品";
        /// <summary>在庫仕入（出荷）　登録プログラム名称(W:Writeの略称)</summary>
        private const string AssemblyNamePmhnd01200W = "在庫仕入（出荷）　登録";
        /// <summary>在庫移動（出荷）　検品プログラム名称(S:Searchの略称)</summary>
        private const string AssemblyNamePmhnd01210S = "在庫移動（出荷）　検品";
        /// <summary>在庫移動（出荷）　登録プログラム名称(W:Writeの略称)</summary>
        private const string AssemblyNamePmhnd01210W = "在庫移動（出荷）　登録";
        /// <summary>在庫移動（入荷）　検品プログラム名称(ES:EnterSearchの略称)</summary>
        private const string AssemblyNamePmhnd01210ES = "在庫移動（入荷）　検品";
        /// <summary>在庫移動（入荷）　登録プログラム名称(EW:EnterWriteの略称)</summary>
        private const string AssemblyNamePmhnd01210EW = "在庫移動（入荷）　登録";

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2017/08/16 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// <summary>ハンディターミナル棚卸処理(一斉)プログラムID</summary>
        private const string AssemblyIdPmhnd05400a = "PMHND05400A";
        /// <summary>ハンディターミナル棚卸処理（一斉）　選択の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd05400a1 = "PMHND05400A1";
        /// <summary>ハンディターミナル棚卸処理（一斉）　検品の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd05400a2 = "PMHND05400A2";
        /// <summary>ハンディターミナル棚卸処理（一斉）　登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd05400a3 = "PMHND05400A3";
        /// <summary>ハンディターミナル棚卸処理(一斉)プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd05400aClassName = "Broadleaf.Application.Controller.HandyInventAcs";
        /// <summary>ハンディターミナル棚卸処理(一斉)取得条件プログラムID</summary>
        private const string AssemblyIdPmhnd05504d = "PMHND05504D";
        /// <summary>ハンディターミナル棚卸処理(一斉)取得条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd05504dClassName = "Broadleaf.Application.Remoting.ParamData.HandyInventoryCondWork";

        /// <summary>ハンディターミナル棚卸処理(一斉)_棚卸存在確認処理メソッド名(SelC:SelectCountの略称)</summary>
        private const string AssemblyIdPmhnd05400aSelCMethodName = "SearchCount";
        /// <summary>ハンディターミナル棚卸処理(一斉)_棚卸対象取得メソッド名(Sel:Selectの略称)</summary>
        private const string AssemblyIdPmhnd05400aSelIMethodName = "SearchInventory";
        /// <summary>ハンディターミナル棚卸処理(一斉)_棚卸データ更新メソッド名(Wt:Writeの略称)</summary>
        private const string AssemblyIdPmhnd05400aWrtMethodName = "WriteInventoryData";

        /// <summary>ハンディターミナル循環棚卸プログラムID</summary>
        private const string AssemblyIdPmhnd05500a = "PMHND05500A";
        /// <summary>ハンディターミナル棚卸処理（循環）　選択の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd05500a1 = "PMHND05500A1";
        /// <summary>ハンディターミナル棚卸処理（循環）　検品の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd05500a2 = "PMHND05500A2";
        /// <summary>ハンディターミナル棚卸処理（循環）　登録の操作履歴ログ登録用のプログラムID</summary>
        private const string AssemblyIdPmhnd05500a3 = "PMHND05500A3";
        /// <summary>ハンディターミナル循環棚卸プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd05500aClassName = "Broadleaf.Application.Controller.HandyCirculInventAcs";

        /// <summary>ハンディターミナル棚卸処理(循環)_倉庫存在確認処理メソッド名(SelC:SelectCountの略称)</summary>
        private const string AssemblyIdPmhnd05500aSelCMethodName = "SearchStockCount";
        /// <summary>ハンディターミナル棚卸処理(循環)_在庫情報取得処理メソッド名(Sel:Selectの略称)</summary>
        private const string AssemblyIdPmhnd05500aSelMethodName = "SearchStock";
        /// <summary>ハンディターミナル棚卸処理(循環)_棚卸情報登録メソッド名(Wt:Writeの略称)</summary>
        private const string AssemblyIdPmhnd05500aWrtIMethodName = "WriteCirculInventoryData";

        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ---------->>>>>
        /// <summary>メーカー品番パターン制御部品プログラムID</summary>
        private const string AssemblyIdPmhnd01230b = "PMHND01230B";
        /// <summary>メーカー品番パターン制御部品プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01230bClassName = "Broadleaf.Application.Controller.HandyMakerGoodsContrAcs";
        /// <summary>ハンディ品番検索条件プログラムID</summary>
        private const string AssemblyIdPmhnd01234d = "PMHND01234D";
        /// <summary>ハンディ品番検索条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01234dClassName = "Broadleaf.Application.Remoting.ParamData.HandyGoodsSearchCondWork";
        /// <summary>ハンディ在庫更新検索条件プログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01234dClassName1 = "Broadleaf.Application.Remoting.ParamData.HandyGoodsUpdateCondWork";
        /// <summary>パターン検索メソッド名</summary>
        private const string AssemblyIdPmhnd01230bMethodName1 = "SearchHandyStockPaturn";
        /// <summary>品番検索メソッド名</summary>
        private const string AssemblyIdPmhnd01230bMethodName2 = "SearchHandyStockGoodsNo";
        /// <summary>在庫登録メソッド名</summary>
        private const string AssemblyIdPmhnd01230bMethodName3 = "WriteHandyStock";
        /// <summary>UOE発注データ存在チェックメソッド名</summary>
        private const string AssemblyIdPmhnd01230bMethodName4 = "SearchHandyUOEOrder";

        /// <summary>メーカーマスタプログラムID</summary>
        private const string AssemblyIdMakhn09112a = "MAKHN09112A";
        /// <summary>メーカーマスタプログラムIDのクラス名</summary>
        private const string AssemblyIdMakhn09112aClassName = "Broadleaf.Application.Controller.MakerAcs";
        /// <summary>仕入先マスタプログラムID</summary>
        private const string AssemblyIdMakhn09022a = "PMKHN09022A";
        /// <summary>仕入先マスタプログラムIDのクラス名</summary>
        private const string AssemblyIdMakhn09022aClassName = "Broadleaf.Application.Controller.SupplierAcs";
        /// <summary>マスタ全検索メソッド名</summary>
        private const string MasterMethodName = "SearchAll";
        // -- ADD 2020/04/10 M.KISHI ---------->>>>>
        /// <summary>情報取得メソッド名</summary>
        private const string ReadHandyMethodName = "ReadHandy";
        // -- ADD 2020/04/10 M.KISHI ----------<<<<<

        /// <summary>パターン検索プログラム名称</summary>
        private const string AssemblyNamePmhnd01230b1 = "メーカー品番パターン制御部品 パターン検索";
        /// <summary>品番検索プログラム名称</summary>
        private const string AssemblyNamePmhnd01230b2 = "メーカー品番パターン制御部品 品番検索";
        /// <summary>UOE発注データ検索プログラム名称</summary>
        private const string AssemblyNamePmhnd01230b3 = "メーカー品番パターン制御部品 UOE発注データ検索";
        /// <summary>在庫登録プログラム名称</summary>
        private const string AssemblyNamePmhnd01230b4 = "メーカー品番パターン制御部品 在庫登録";
        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ----------<<<<<

        /// <summary>棚卸処理(一斉)_棚卸対象確認プログラム名称</summary>
        private const string AssemblyNamePmhnd05400a = "棚卸処理（一斉）　選択";
        /// <summary>棚卸処理(一斉)_棚卸対象取得プログラム名称</summary>
        private const string AssemblyNamePmhnd05400b = "棚卸処理（一斉）　検品";
        /// <summary>棚卸処理(一斉)_棚卸データ更新プログラム名称</summary>
        private const string AssemblyNamePmhnd05400c = "棚卸処理（一斉）　登録";

        /// <summary>棚卸処理(循環)_倉庫存在確認処理プログラム名称</summary>
        private const string AssemblyNamePmhnd05500a = "棚卸処理（循環）　選択";
        /// <summary>棚卸処理(循環)_在庫情報取得処理プログラム名称</summary>
        private const string AssemblyNamePmhnd05500b = "棚卸処理（循環）　検品";
        /// <summary>棚卸処理(循環)_棚卸情報登録プログラム名称</summary>
        private const string AssemblyNamePmhnd05500c = "棚卸処理（循環）　登録";
        // ------ ADD 2017/08/16 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2019/11/13 岸 ハンディ６次改良 ---------->>>>>
        /// <summary>ハンディターミナル倉庫プログラムID</summary>
        private const string AssemblyIdMakhn09332a = "MAKHN09332A";
        /// <summary>ハンディターミナル倉庫プログラムIDのクラス名</summary>
        private const string AssemblyIdMakhn09332aClassName = "Broadleaf.Application.Controller.WarehouseAcs";
        /// <summary>ハンディターミナル倉庫ワークプログラムID</summary>
        private const string AssemblyIdMakhn09336d = "MAKHN09336D";
        /// <summary>ハンディターミナル倉庫ワークプログラムIDのクラス名</summary>
        private const string AssemblyIdMakhn09336dClassName = "Broadleaf.Application.Remoting.ParamData.WarehouseWork";
        // ------ ADD 2019/11/13 岸 ハンディ６次改良 ----------<<<<<

        /// <summary>プログラム名称</summary>
        private const string AssemblyNamePmhnd00010a = "ハンディ ログイン";
        /// <summary>検品対象取得(伝票番号)プログラム名称</summary>
        private const string AssemblyNamePmhnd04000a = "検品対象取得(伝票番号)";
        /// <summary>検品対象取得(伝票番号)プログラム名称</summary>
        private const string AssemblyNamePmhnd04000a1 = "ハンディ 販売業務（出荷）";
        /// <summary>検品対象取得(伝票番号)プログラム名称</summary>
        private const string AssemblyNamePmhnd04000a2 = "ハンディ 貸出業務（出荷）";
        /// <summary>検品対象取得(伝票番号)プログラム名称</summary>
        private const string AssemblyNamePmhnd04000a3 = "ハンディ 販売業務（入荷）";
        /// <summary>検品対象取得(伝票番号)プログラム名称</summary>
        private const string AssemblyNamePmhnd04000a4 = "ハンディ 貸出返却検品";

        /// <summary>在庫情報取得(一括検品)プログラム名称</summary>
        private const string AssemblyNamePmhnd04010a = "検品対象取得(一括検品)";

        /// <summary>在庫情報取得(通常)プログラム名称</summary>
        private const string AssemblyNamePmhnd04100a = "ハンディ 在庫照会";
        /// <summary>在庫情報取得(先行検品)プログラム名称</summary>
        private const string AssemblyNamePmhnd04110a = "ハンディ 販売業務（入荷）";

        /// <summary>商品バーコード関連付けマスタ登録プログラム名称</summary>
        private const string AssemblyNamePmhnd09301a = "ハンディ 商品バーコード";

        /// <summary>検品データ登録プログラム名称</summary>
        private const string AssemblyNamePmhnd01000a = "検品データ登録";
        /// <summary>検品データ登録(先行検品)登録プログラム名称</summary>
        private const string AssemblyNamePmhnd01010a = "ハンディ 販売業務（入荷）";

        /// <summary>エラーメッセージ（正常終了）</summary>
        private const string MessageOk = "正常終了しました。";
        /// <summary>エラーメッセージ（正常終了）</summary>
        private const string MessageNotFound = "抽出対象のデータが存在しません。";
        /// <summary>エラーメッセージ（正常終了）</summary>
        private const string MessageTimeout = "タイムアウトエラーが発生しました。";
        /// <summary>エラーメッセージ（正常終了）</summary>
        private const string MessageNonTarget = "検品対象伝票ではありません。";
        /// <summary>エラーメッセージ（正常終了）</summary>
        private const string MessageError = "エラーが発生しました。";
        /// <summary>排他エラーメッセージ（正常終了）</summary>
        private const string MessageArsetError = "排他エラーが発生しました。";
        /// <summary>仕入先伝票番号重複エラーメッセージ</summary>
        private const string MessageRegistsError = "仕入先伝票番号が既に登録されています。";
        /// <summary>エラーメッセージ</summary>
        private const string MessageThreadTimeout = "スレッド待ち時間タイムアウトが発生しました。{0}機能名：{1}";
        /// <summary>エラーメッセージ（読込）</summary>
        private const string MessageRead = "読込";
        /// <summary>エラーメッセージ（読込）</summary>
        private const string MessageWrite = "書込";
        /// <summary>オペレーションコード（1:ログイン）</summary>
        private const int OperationCodeLogin = 1;
        // オペレーションコード（データ読込）
        private const int OperationCodeRead = 2;
        // オペレーションコード（データ追加）
        private const int OperationCodeAdd = 3;
        // オペレーションコード（検品）
        private const int OperationCodeInspect = 4;
        /// <summary>最大処理レベル</summary>
        private const int MaxLevel = 99;
        /// <summary>ログインID</summary>
        private const string LoginId = "LoginId";
        /// <summary>従業員コード</summary>
        private const string EmployeeCode = "EmployeeCode";
        /// <summary>端末名</summary>
        private const string MachineName = "MachineName";
        /// <summary>企業コード</summary>
        private const string EnterpriseCode = "EnterpriseCode";
        /// <summary>ログイン拠点コード</summary>
        private const string BelongSectionCode = "BelongSectionCode";
        /// <summary>ログイン担当者名</summary>
        private const string Name = "Name";
        /// <summary>ログイン権限レベル1</summary>
        private const string AuthorityLevel1 = "AuthorityLevel1";
        /// <summary>ログイン権限レベル2</summary>
        private const string AuthorityLevel2 = "AuthorityLevel2";
        /// <summary>処理区分（検品検索用）</summary>
        private const string ProcDiv = "ProcDiv";
        /// <summary>処理区分（検品登録用）</summary>
        private const string AcPaySlipCd = "AcPaySlipCd";
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND00003A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-20} {3,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgAssembly = "指定のアセンブリが存在しません。";

        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ---------->>>>>
        /// <summary>商品メーカー</summary>
        private const string GoodsMakerCd = "GoodsMakerCd";
        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ----------<<<<<

        #endregion

        // ===================================================================================== //
        // Static 変数
        // ===================================================================================== //
        #region Static Members
        /// <summary>読込最大件数</summary>
        static int ReadMaxCount = 0;
        /// <summary>書込最大件数</summary>
        static int WriteMaxCount = 0;
        /// <summary>読込中件数</summary>
        static int ReadingCount = 0;
        /// <summary>書込中件数</summary>
        static int WritingCount = 0;
        /// <summary>スレッド待ち時間</summary>
        static int ThreadWaitTime = 0;
        /// <summary>終了フラグ</summary>
        static bool CloseFlg = false;
        /// <summary>企業コード</summary>
        static string StaticEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        /// <summary>従業員情報DIC</summary>
        static Dictionary<string, OprtnHisLogWork> LoginInfoDic = new Dictionary<string, OprtnHisLogWork>();
        /// <summary>ログ用ロック</summary>
        static object LogLockObj = null;
        #endregion


        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public PmHandy()
        {
            LogLockObj = new object();
        }
        #endregion

        // ===================================================================================== //
        // ログイン情報取得処理
        // ===================================================================================== //
        #region ログイン情報取得処理
        /// <summary>
        /// ログイン情報取得
        /// </summary>
        /// <param name="paraHandyLoginInfoCondObj">ログイン情報抽出条件リスト</param>
        /// <param name="resultHandyLoginInfoObj">ログイン情報結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ログイン情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public int SearchHandyLoginInfo(ref object paraHandyLoginInfoCondObj, out object resultHandyLoginInfoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyLoginInfoObj = null;

            // ログイン情報取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // インスタンス生成
                string errMessage = string.Empty;
                object acsObj = this.LoadAssembly(AssemblyIdPmhnd00010a, AssemblyIdPmhnd00010aClassName, out errMessage);
                // ログイン情報取得アクセスオブジェクトがない場合、「-1」を戻ります。
                if (acsObj == null)
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd00010a, ErrorMsgAssembly);
                    return StatusError;
                }

                object condObj = LoadAssembly(AssemblyIdPmhnd00014d, AssemblyIdPmhnd00014dClassName, out errMessage);
                // ログイン情報取得条件オブジェクトがない場合、「-1」を戻ります。
                if (condObj == null)
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd00014d, ErrorMsgAssembly);
                    return StatusError;
                } 

                Type condType = condObj.GetType();
                // （ログインIDとコンピュータ名）操作履歴ログ用
                string loginId = condType.GetProperty(LoginId).GetValue(paraHandyLoginInfoCondObj, null).ToString();
                string machineName = condType.GetProperty(MachineName).GetValue(paraHandyLoginInfoCondObj, null).ToString();
                
                // 企業コードを設定します。
                condType.GetProperty(EnterpriseCode).SetValue(paraHandyLoginInfoCondObj, StaticEnterpriseCode, null);

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ログイン情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd00010aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyLoginInfoCondObj;
                paramValue[1] = resultHandyLoginInfoObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ログイン情報取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;
                    // ログイン情報取得ステータスが正常の場合、ログイン情報結果リストを設定します。
                    if (status == StatusNomal)
                    {
                        resultHandyLoginInfoObj = paramValue[1];

                        // ログイン情報取得後、操作履歴ログを登録します。
                        this.WriteLoginHistoryLog(acsObj, resultHandyLoginInfoObj, machineName);
                    }
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd00010a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch(Exception ex)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd00010a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 在庫情報取得(通常)
        // ===================================================================================== //
        #region 在庫情報取得(通常)
        /// <summary>
        /// 在庫情報(通常)取得
        /// </summary>
        /// <param name="paraHandyStockCondObj">在庫情報(通常)抽出条件リスト</param>
        /// <param name="resultHandyStockObj">在庫情報(通常)結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報(通常)を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public int SearchHandyStock(ref object paraHandyStockCondObj, out object resultHandyStockObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd04104d, AssemblyIdPmhnd04104dClassName, out errMessage);
            // 在庫情報(通常)取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04104d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd04100a, AssemblyIdPmhnd04100aClassName, out errMessage);
            // 在庫情報(通常)取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04100a, AssemblyNamePmhnd04100a, AssemblyIdPmhnd04100aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04100a, ErrorMsgAssembly);
                return StatusError;
            } 

            // 在庫情報(通常)取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04100a, AssemblyNamePmhnd04100a, AssemblyIdPmhnd04100aMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd04100a), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 在庫情報(通常)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd04100aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockCondObj;
                paramValue[1] = resultHandyStockObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 在庫情報(通常)取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 在庫情報(通常)取得ステータスが正常の場合、在庫情報(通常)結果リストを設定します。
                        resultHandyStockObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04100a, AssemblyNamePmhnd04100a, AssemblyIdPmhnd04100aMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04100a, AssemblyNamePmhnd04100a, AssemblyIdPmhnd04100aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd04100a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04100a, AssemblyNamePmhnd04100a, AssemblyIdPmhnd04100aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04100a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 在庫情報取得(先行検品)
        // ===================================================================================== //
        #region 在庫情報取得(先行検品)
        /// <summary>
        /// 在庫情報取得(先行検品)取得
        /// </summary>
        /// <param name="paraHandyStockCondObj">在庫情報取得(先行検品)抽出条件リスト</param>
        /// <param name="resultHandyStockObj">在庫情報取得(先行検品)結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報取得(先行検品)を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public int SearchHandyStockInspect(ref object paraHandyStockCondObj, out object resultHandyStockObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd04104d, AssemblyIdPmhnd04104dClassName, out errMessage);
            // 在庫情報(先行検品)取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04104d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd04110a, AssemblyIdPmhnd04110aClassName, out errMessage);
            // 在庫情報(先行検品)取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04110a, AssemblyNamePmhnd04110a, AssemblyIdPmhnd04110aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04110a, ErrorMsgAssembly);
                return StatusError;
            } 

            // 在庫情報(先行検品)取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04110a, AssemblyNamePmhnd04110a, AssemblyIdPmhnd04110aMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd04110a), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 在庫情報(先行検品)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd04110aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockCondObj;
                paramValue[1] = resultHandyStockObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 在庫情報(先行検品)取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 在庫情報(先行検品)取得ステータスが正常の場合、在庫情報(先行検品)結果リストを設定します。
                        resultHandyStockObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04110a, AssemblyNamePmhnd04110a, AssemblyIdPmhnd04110aMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04110a, AssemblyNamePmhnd04110a, AssemblyIdPmhnd04110aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd04110a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04110a, AssemblyNamePmhnd04110a, AssemblyIdPmhnd04110aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04110a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 検品対象取得(伝票番号)
        // ===================================================================================== //
        #region 検品対象取得(伝票番号)
        /// <summary>
        /// 検品対象取得(伝票番号)処理
        /// </summary>
        /// <param name="paraHandyInspectCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyInspectObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象取得(伝票番号)を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public int SearchHandyInspectDataSlipNum(ref object paraHandyInspectCondObj, out object resultHandyInspectObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyInspectObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd04004d, AssemblyIdPmhnd04004dClassName, out errMessage);
            // 検品対象取得(伝票番号)取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04004d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyInspectCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyInspectCondObj, null).ToString();
            int procDiv = (int)condType.GetProperty(ProcDiv).GetValue(paraHandyInspectCondObj, null);

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyInspectCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd04000a, AssemblyIdPmhnd04000aClassName, out errMessage);
            // 検品対象取得(伝票番号)取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04000a, GetAssemblyName(AssemblyIdPmhnd04000a, procDiv), AssemblyIdPmhnd04000aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04000a, ErrorMsgAssembly);
                return StatusError;
            }

            

            // 検品対象取得(伝票番号)取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04000a, GetAssemblyName(AssemblyIdPmhnd04000a, procDiv), AssemblyIdPmhnd04000aMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, GetAssemblyName(AssemblyIdPmhnd04000a, procDiv)), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 検品対象取得(伝票番号)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd04000aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyInspectCondObj;
                paramValue[1] = resultHandyInspectObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 検品対象取得(伝票番号)取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 検品対象取得(伝票番号)取得ステータスが正常の場合、検品対象取得(伝票番号)結果リストを設定します。
                        resultHandyInspectObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04000a, GetAssemblyName(AssemblyIdPmhnd04000a, procDiv), AssemblyIdPmhnd04000aMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04000a, GetAssemblyName(AssemblyIdPmhnd04000a, procDiv), AssemblyIdPmhnd04000aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd04000a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04000a, GetAssemblyName(AssemblyIdPmhnd04000a, procDiv), AssemblyIdPmhnd04000aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04000a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 検品対象取得(一括検品)
        // ===================================================================================== //
        #region 検品対象取得(一括検品)
        /// <summary>
        /// 検品対象取得(一括検品)処理
        /// </summary>
        /// <param name="paraHandyInspectCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyInspectObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象取得(一括検品)を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public int SearchHandyInspectDataTotal(ref object paraHandyInspectCondObj, out object resultHandyInspectObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyInspectObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd04004d, AssemblyIdPmhnd04004dClassName, out errMessage);
            // 検品対象取得(一括検品)取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04004d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyInspectCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyInspectCondObj, null).ToString();
            int procDiv = (int)condType.GetProperty(ProcDiv).GetValue(paraHandyInspectCondObj, null);

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyInspectCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd04010a, AssemblyIdPmhnd04010aClassName, out errMessage);
            // 検品対象情報取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04010a, GetAssemblyName(AssemblyIdPmhnd04010a, procDiv), AssemblyIdPmhnd04010aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04010a, ErrorMsgAssembly);
                return StatusError;
            }

            // 検品対象情報取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04010a, GetAssemblyName(AssemblyIdPmhnd04010a, procDiv), AssemblyIdPmhnd04010aMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd04010a), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                //// 検品対象情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd04010aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyInspectCondObj;
                paramValue[1] = resultHandyInspectObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 検品対象情報取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;
                    // 検品対象情報取得ステータスが正常の場合、検品対象情報結果リストを設定します。
                    if (status == StatusNomal)
                    {
                        resultHandyInspectObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04010a, GetAssemblyName(AssemblyIdPmhnd04010a, procDiv), AssemblyIdPmhnd04010aMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04010a, GetAssemblyName(AssemblyIdPmhnd04010a, procDiv), AssemblyIdPmhnd04010aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd04010a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04010a, GetAssemblyName(AssemblyIdPmhnd04010a, procDiv), AssemblyIdPmhnd04010aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04010a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 商品バーコード関連付けマスタ登録
        // ===================================================================================== //
        #region 商品バーコード関連付けマスタ登録
        /// <summary>
        /// 商品バーコード関連付けマスタ登録
        /// </summary>
        /// <param name="paraHandyGoodsBarCodeObj">登録オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ登録を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public int InsertHandyGoodsBarCode(ref object paraHandyGoodsBarCodeObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd09308d, AssemblyIdPmhnd09308dClassName, out errMessage);
            // 商品バーコード関連付けマスタ登録条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd09308d, ErrorMsgAssembly);
                return StatusError;
            }

            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = insertType.GetProperty(EmployeeCode).GetValue(paraHandyGoodsBarCodeObj, null).ToString();
            string machineName = insertType.GetProperty(MachineName).GetValue(paraHandyGoodsBarCodeObj, null).ToString();

            // 企業コードを設定します。
            insertType.GetProperty(EnterpriseCode).SetValue(paraHandyGoodsBarCodeObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd09301a, AssemblyIdPmhnd09301aClassName, out errMessage);
            // 商品バーコード関連付けマスタ情報登録アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd09301a, AssemblyNamePmhnd09301a, AssemblyIdPmhnd09301aMethodName, OperationCodeAdd, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd09301a, ErrorMsgAssembly);
                return StatusError;
            } 

            // 商品バーコード関連付け情報登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd09301a, AssemblyNamePmhnd09301a, AssemblyIdPmhnd09301aMethodName, OperationCodeAdd, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd09301a), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 商品バーコード関連付け情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd09301aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = paraHandyGoodsBarCodeObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 商品バーコード関連付け情報登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd09301a, AssemblyNamePmhnd09301a, AssemblyIdPmhnd09301aMethodName, OperationCodeAdd, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd09301a, AssemblyNamePmhnd09301a, AssemblyIdPmhnd09301aMethodName, OperationCodeAdd, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd09301a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd09301a, AssemblyNamePmhnd09301a, AssemblyIdPmhnd09301aMethodName, OperationCodeAdd, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd09301a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 検品データ登録処理
        // ===================================================================================== //
        #region 検品データ登録処理
        /// <summary>
        /// 検品データ登録処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データを登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int WriteInspectData(ref object inspectDataObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;
            string machineName = string.Empty;
            string employeeCode = string.Empty;
            int acPaySlipCd = 0;

            object insertObj = LoadAssembly(AssemblyIdPmhnd00213d, AssemblyIdPmhnd00213dClassName, out errMessage);
            // 商品バーコード関連付けマスタ登録条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd00213d, ErrorMsgAssembly);
                return StatusError;
            }

            if (inspectDataObj is ArrayList)
            {
                ArrayList inspectDataArr = inspectDataObj as ArrayList;
                foreach (object inspectDataSubObj in inspectDataArr)
                {
                    Type insertSubType = inspectDataSubObj.GetType();
                    // （従業員コードとコンピュータ名）操作履歴ログ用
                    employeeCode = insertSubType.GetProperty(EmployeeCode).GetValue(inspectDataSubObj, null).ToString();
                    machineName = insertSubType.GetProperty(MachineName).GetValue(inspectDataSubObj, null).ToString();
                    acPaySlipCd = (int)insertSubType.GetProperty(AcPaySlipCd).GetValue(inspectDataSubObj, null);

                    // 企業コードを設定します。
                    insertSubType.GetProperty(EnterpriseCode).SetValue(inspectDataSubObj, StaticEnterpriseCode, null);
                }
            }
            else
            {
                return StatusError;
            }

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01000a, AssemblyIdPmhnd01000aClassName, out errMessage);
            // 検品データ情報登録アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01000a, GetAssemblyName(AssemblyIdPmhnd01000a, acPaySlipCd), AssemblyIdPmhnd01000aMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01000a, ErrorMsgAssembly);
                return StatusError;
            }

            // 検品データ情報登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01000a, GetAssemblyName(AssemblyIdPmhnd01000a, acPaySlipCd), AssemblyIdPmhnd01000aMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, GetAssemblyName(AssemblyIdPmhnd01000a, acPaySlipCd)), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 検品データ情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01000aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = inspectDataObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 検品データ情報登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01000a, GetAssemblyName(AssemblyIdPmhnd01000a, acPaySlipCd), AssemblyIdPmhnd01000aMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01000a, GetAssemblyName(AssemblyIdPmhnd01000a, acPaySlipCd), AssemblyIdPmhnd01000aMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01000a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01000a, GetAssemblyName(AssemblyIdPmhnd01000a, acPaySlipCd), AssemblyIdPmhnd01000aMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01000a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 検品データ登録(先行検品)処理
        // ===================================================================================== //
        #region 検品データ登録(先行検品)処理
        /// <summary>
        /// 検品データ登録処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int WriteSenKouInspect(ref object inspectDataObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd00213d, AssemblyIdPmhnd00213dClassName, out errMessage);
            // 検品データ(先行検品)登録条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd00213d, ErrorMsgAssembly);
                return StatusError;
            }

            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = insertType.GetProperty(EmployeeCode).GetValue(inspectDataObj, null).ToString();
            string machineName = insertType.GetProperty(MachineName).GetValue(inspectDataObj, null).ToString();

            // 企業コードを設定します。
            insertType.GetProperty(EnterpriseCode).SetValue(inspectDataObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01010a, AssemblyIdPmhnd01010aClassName, out errMessage);
            // 検品データ(先行検品)情報登録アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01010a, AssemblyNamePmhnd01010a, AssemblyIdPmhnd01010aMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01010a, ErrorMsgAssembly);
                return StatusError;
            }

            // 検品データ(先行検品)情報登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01010a, AssemblyNamePmhnd01010a, AssemblyIdPmhnd01010aMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd01010a), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 検品データ(先行検品)情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01010aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = inspectDataObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 検品データ(先行検品)情報登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01010a, AssemblyNamePmhnd01010a, AssemblyIdPmhnd01010aMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01010a, AssemblyNamePmhnd01010a, AssemblyIdPmhnd01010aMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01010a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01010a, AssemblyNamePmhnd01010a, AssemblyIdPmhnd01010aMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01010a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ------ ADD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- >>>>
        // ===================================================================================== //
        // ハンディターミナル発注先ガイド情報抽出
        // ===================================================================================== //
        #region ハンディターミナル発注先ガイド情報
        /// <summary>
        /// ハンディターミナル発注先ガイド情報抽出
        /// </summary>
        /// <param name="paraHandySupplierGuideCondObj">ハンディターミナル発注先ガイド情報抽出条件リスト</param>
        /// <param name="resultHandySupplierGuideObj">ハンディターミナル発注先ガイド情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル発注先ガイド情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchHandySupplierGuide(ref object paraHandySupplierGuideCondObj, out object resultHandySupplierGuideObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandySupplierGuideObj = null;

            // インスタンス生成
            string errMessage = string.Empty;
            object condObj = LoadAssembly(AssemblyIdPmhnd04304d, AssemblyIdPmhnd04304dClassName, out errMessage);
            // ハンディターミナル発注先ガイド抽出条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04304d, ErrorMsgAssembly);
                return StatusError;
            }

            // 検索条件ワークタイプを取得します。
            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandySupplierGuideCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandySupplierGuideCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandySupplierGuideCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd04300a, AssemblyIdPmhnd04300aClassName, out errMessage);
            // ハンディターミナル発注先ガイド抽出アクセスがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04300a, AssemblyNamePmhnd04300a, AssemblyIdPmhnd04300aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04300a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル発注先ガイド抽出処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04300a, AssemblyNamePmhnd04300a, AssemblyIdPmhnd04300aMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd04300a), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル発注先ガイド抽出アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd04300aMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandySupplierGuideCondObj;
                paramValue[1] = resultHandySupplierGuideObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル発注先ガイド抽出結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル発注先ガイド抽出ステータスが正常の場合、ハンディターミナル発注先ガイド抽出結果リストを設定します。
                        resultHandySupplierGuideObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04300a, AssemblyNamePmhnd04300a, AssemblyIdPmhnd04300aMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04300a, AssemblyNamePmhnd04300a, AssemblyIdPmhnd04300aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd04300a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd04300a, AssemblyNamePmhnd04300a, AssemblyIdPmhnd04300aMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04300a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫仕入（入庫更新）_一覧抽出
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入（入庫更新）_一覧抽出
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧抽出
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_一覧情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchHandyStockSupplierList(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockSupplierObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassNameFsl, out errMessage);
            // ハンディターミナル在庫仕入（入庫更新）_一覧抽出条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, ErrorMsgAssembly);
                return StatusError;
            }

            // 検索条件ワークタイプを取得します。
            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockSupplierCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockSupplierCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockSupplierCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01100a, AssemblyIdPmhnd01100aClassName, out errMessage);
            // ハンディターミナル在庫仕入（入庫更新）_一覧抽出アクセスがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a1, AssemblyNamePmhnd01100aFsl, AssemblyIdPmhnd01100aMethodNameFsl, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a1, AssemblyNamePmhnd01100aFsl, AssemblyIdPmhnd01100aMethodNameFsl, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01100aFsl), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル在庫仕入（入庫更新）_一覧抽出アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01100aMethodNameFsl, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockSupplierCondObj;
                paramValue[1] = resultHandyStockSupplierObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル在庫仕入（入庫更新）_一覧抽出結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル在庫仕入（入庫更新）_一覧抽出ステータスが正常の場合、ハンディターミナル在庫仕入（入庫更新）_一覧抽出結果リストを設定します。
                        resultHandyStockSupplierObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a1, AssemblyNamePmhnd01100aFsl, AssemblyIdPmhnd01100aMethodNameFsl, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a1, AssemblyNamePmhnd01100aFsl, AssemblyIdPmhnd01100aMethodNameFsl, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a1, AssemblyNamePmhnd01100aFsl, AssemblyIdPmhnd01100aMethodNameFsl, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01100a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫仕入（入庫更新）_明細抽出
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入（入庫更新）_明細抽出
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_明細抽出
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（入庫更新）_明細抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（入庫更新）_明細抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_明細情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchHandyStockSupplierSlipNum(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockSupplierObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassNameFsd, out errMessage);
            // ハンディターミナル在庫仕入（入庫更新）_明細抽出条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, ErrorMsgAssembly);
                return StatusError;
            }

            // 検索条件ワークタイプを取得します。
            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockSupplierCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockSupplierCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockSupplierCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01100a, AssemblyIdPmhnd01100aClassName, out errMessage);
            // ハンディターミナル在庫仕入（入庫更新）_明細取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a2, AssemblyNamePmhnd01100aFsd, AssemblyIdPmhnd01100aMethodNameFsd, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（入庫更新）_明細取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a2, AssemblyNamePmhnd01100aFsd, AssemblyIdPmhnd01100aMethodNameFsd, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01100aFsd), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル在庫仕入（入庫更新）_明細取得アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01100aMethodNameFsd, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockSupplierCondObj;
                paramValue[1] = resultHandyStockSupplierObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル在庫仕入（入庫更新）_明細取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル在庫仕入（入庫更新）_明細取得ステータスが正常の場合、ハンディターミナル在庫仕入（入庫更新）_明細結果リストを設定します。
                        resultHandyStockSupplierObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a2, AssemblyNamePmhnd01100aFsd, AssemblyIdPmhnd01100aMethodNameFsd, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a2, AssemblyNamePmhnd01100aFsd, AssemblyIdPmhnd01100aMethodNameFsd, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a2, AssemblyNamePmhnd01100aFsd, AssemblyIdPmhnd01100aMethodNameFsd, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01100a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫仕入（入庫更新）_登録
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入（入庫更新）_登録
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_登録
        /// </summary>
        /// <param name="paraHandyStockSupplierListObj">登録パラメータオブジェクト</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteHandyStockSupplier(ref object paraHandyStockSupplierListObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassNameFw, out errMessage);
            // ハンディターミナル在庫仕入（入庫更新）登録パラメータオブジェクトアセンブリがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（入庫更新）登録パラメータがない場合
            if (paraHandyStockSupplierListObj == null || !(paraHandyStockSupplierListObj is ArrayList))
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, InsertConditionsError);
                return StatusError;
            }

            // 登録ワークタイプを取得します。
            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = string.Empty;
            string machineName = string.Empty;

            ArrayList paraHandyStockSupplierList = paraHandyStockSupplierListObj as ArrayList;
            // 在庫仕入登録リスト件数＞０、又、登録ワークのタイプと一致の場合
            if (paraHandyStockSupplierList.Count > 0 && paraHandyStockSupplierList[0].GetType() == insertObj.GetType())
            {
                // 従業員コード
                employeeCode = insertType.GetProperty(EmployeeCode).GetValue(paraHandyStockSupplierList[0], null).ToString();
                // コンピュータ名
                machineName = insertType.GetProperty(MachineName).GetValue(paraHandyStockSupplierList[0], null).ToString();

                // 従業員の所属拠点コードを取得します。
                string SectionCode = string.Empty;
                if (LoginInfoDic.ContainsKey(employeeCode.Trim()))
                {
                    OprtnHisLogWork OprtnHisLogWorkData = LoginInfoDic[employeeCode.Trim()];
                    // 拠点コードを設定します。
                    SectionCode = OprtnHisLogWorkData.LoginSectionCd;
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01114d, EmployeeError);
                    return StatusError;
                }

                // 企業コードと従業員の所属拠点コードをセットします。
                for (int i = 0; i < paraHandyStockSupplierList.Count; i++)
                {
                    // 企業コードを設定します。
                    insertType.GetProperty(EnterpriseCode).SetValue(paraHandyStockSupplierList[i], StaticEnterpriseCode, null);
                    // 拠点コードを設定します。
                    insertType.GetProperty(BelongSectionCode).SetValue(paraHandyStockSupplierList[i], SectionCode, null);
                }
            }
            else
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, AssemblyWorkError);
                return StatusError;
            }


            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01100a, AssemblyIdPmhnd01100aClassName, out errMessage);
            // ハンディターミナル在庫仕入（入庫更新）登録アクセスアセンブリがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a3, AssemblyNamePmhnd01100aFw, AssemblyIdPmhnd01100aMethodNameFw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（入庫更新）登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a3, AssemblyNamePmhnd01100aFw, AssemblyIdPmhnd01100aMethodNameFw, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd01100aFw), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // ハンディターミナル在庫仕入（入庫更新）登録アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01100aMethodNameFw, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = paraHandyStockSupplierListObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル在庫仕入（入庫更新）登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a3, AssemblyNamePmhnd01100aFw, AssemblyIdPmhnd01100aMethodNameFw, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a3, AssemblyNamePmhnd01100aFw, AssemblyIdPmhnd01100aMethodNameFw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01100a3, AssemblyNamePmhnd01100aFw, AssemblyIdPmhnd01100aMethodNameFw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01100a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫仕入（UOE以外）_明細抽出
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入（UOE以外）_明細抽出
        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）_明細抽出
        /// </summary>
        /// <param name="paraHandyNonUOEStockSupplierCondObj">ハンディターミナル在庫仕入（UOE以外）_明細抽出条件リスト</param>
        /// <param name="resultHandyNonUOEStockSupplierObj">ハンディターミナル在庫仕入（UOE以外）_明細抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（UOE以外）_明細情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchHandyNonUOEStockSupplier(ref object paraHandyNonUOEStockSupplierCondObj, out object resultHandyNonUOEStockSupplierObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyNonUOEStockSupplierObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassNameFnsd, out errMessage);
            // ハンディターミナル在庫仕入（UOE以外）_明細抽出条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, ErrorMsgAssembly);
                return StatusError;
            }

            // 検索条件ワークタイプを取得します。
            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyNonUOEStockSupplierCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyNonUOEStockSupplierCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyNonUOEStockSupplierCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01110a, AssemblyIdPmhnd01110aClassName, out errMessage);
            // ハンディターミナル在庫仕入（UOE以外）_明細取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a1, AssemblyNamePmhnd01110aFnsd, AssemblyIdPmhnd01110aMethodNameFnsd, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01110a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（UOE以外）_明細取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a1, AssemblyNamePmhnd01110aFnsd, AssemblyIdPmhnd01110aMethodNameFnsd, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01110aFnsd), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル在庫仕入（UOE以外）_明細取得アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01110aMethodNameFnsd, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyNonUOEStockSupplierCondObj;
                paramValue[1] = resultHandyNonUOEStockSupplierObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル在庫仕入（UOE以外）_明細取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル在庫仕入（UOE以外）_明細取得ステータスが正常の場合、ハンディターミナル在庫仕入（UOE以外）_明細結果リストを設定します。
                        resultHandyNonUOEStockSupplierObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a1, AssemblyNamePmhnd01110aFnsd, AssemblyIdPmhnd01110aMethodNameFnsd, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a1, AssemblyNamePmhnd01110aFnsd, AssemblyIdPmhnd01110aMethodNameFnsd, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01110a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a1, AssemblyNamePmhnd01110aFnsd, AssemblyIdPmhnd01110aMethodNameFnsd, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01110a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫仕入（UOE以外）_登録
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入（UOE以外）_登録
        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）_登録
        /// </summary>
        /// <param name="paraHandyNonUOEInspectListObj">登録パラメータオブジェクト</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（UOE以外）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteHandyNonUOEInspect(ref object paraHandyNonUOEInspectListObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassNameFnw, out errMessage);
            // ハンディターミナル在庫仕入（UOE以外）登録パラメータオブジェクトアセンブリがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（UOE以外）登録パラメータがない場合
            if (paraHandyNonUOEInspectListObj == null || !(paraHandyNonUOEInspectListObj is ArrayList))
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, InsertConditionsError);
                return StatusError;
            }

            // 登録ワークタイプを取得します。
            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = string.Empty;
            string machineName = string.Empty;

            ArrayList paraHandyNonUOEInspectList = paraHandyNonUOEInspectListObj as ArrayList;
            // 在庫仕入登録リスト件数＞０、又、登録ワークのタイプと一致の場合
            if (paraHandyNonUOEInspectList.Count > 0 && paraHandyNonUOEInspectList[0].GetType() == insertObj.GetType())
            {
                // 従業員コード
                employeeCode = insertType.GetProperty(EmployeeCode).GetValue(paraHandyNonUOEInspectList[0], null).ToString();
                // コンピュータ名
                machineName = insertType.GetProperty(MachineName).GetValue(paraHandyNonUOEInspectList[0], null).ToString();

                // 従業員の所属拠点コードを取得します。
                string SectionCode = string.Empty;
                if (LoginInfoDic.ContainsKey(employeeCode.Trim()))
                {
                    OprtnHisLogWork OprtnHisLogWorkData = LoginInfoDic[employeeCode.Trim()];
                    // 拠点コードを設定します。
                    SectionCode = OprtnHisLogWorkData.LoginSectionCd;
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01114d, EmployeeError);
                    return StatusError;
                }

                // 企業コードと従業員の所属拠点コードをセットします。
                for (int i = 0; i < paraHandyNonUOEInspectList.Count; i++)
                {
                    // 企業コードを設定します。
                    insertType.GetProperty(EnterpriseCode).SetValue(paraHandyNonUOEInspectList[i], StaticEnterpriseCode, null);
                    // 拠点コードを設定します。
                    insertType.GetProperty(BelongSectionCode).SetValue(paraHandyNonUOEInspectList[i], SectionCode, null);
                }
            }
            else
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, AssemblyWorkError);
                return StatusError;
            }


            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01110a, AssemblyIdPmhnd01110aClassName, out errMessage);
            // ハンディターミナル在庫仕入（UOE以外）登録アクセスアセンブリがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a2, AssemblyNamePmhnd01110aFw, AssemblyIdPmhnd01110aMethodNameFw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01110a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入（UOE以外）登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a2, AssemblyNamePmhnd01110aFw, AssemblyIdPmhnd01110aMethodNameFw, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd01110aFw), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // ハンディターミナル在庫仕入（UOE以外）登録アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01110aMethodNameFw, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = paraHandyNonUOEInspectList;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル在庫仕入（UOE以外）登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a2, AssemblyNamePmhnd01110aFw, AssemblyIdPmhnd01110aMethodNameFw, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a2, AssemblyNamePmhnd01110aFw, AssemblyIdPmhnd01110aMethodNameFw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01100a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01110a2, AssemblyNamePmhnd01110aFw, AssemblyIdPmhnd01110aMethodNameFw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01110a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル委託在庫補充_倉庫情報抽出
        // ===================================================================================== //
        #region ハンディターミナル委託在庫補充_倉庫情報抽出
        /// <summary>
        /// ハンディターミナル委託在庫補充_倉庫情報抽出
        /// </summary>
        /// <param name="paraHandyWarehouseInfoCondObj">ハンディターミナル委託在庫補充_倉庫情報抽出条件リスト</param>
        /// <param name="resultHandyWarehouseInfoObj">ハンディターミナル委託在庫補充_倉庫情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_倉庫情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchHandyWarehouseInfo(ref object paraHandyWarehouseInfoCondObj, out object resultHandyWarehouseInfoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyWarehouseInfoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01304d, AssemblyIdPmhnd01304dClassNameFsw, out errMessage);
            // ハンディターミナル委託在庫補充_倉庫情報抽出条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01304d, ErrorMsgAssembly);
                return StatusError;
            }

            // 検索条件ワークタイプを取得します。
            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyWarehouseInfoCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyWarehouseInfoCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyWarehouseInfoCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01300a, AssemblyIdPmhnd01300aClassName, out errMessage);
            // ハンディターミナル委託在庫補充_倉庫情報抽出アクセスがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a1, AssemblyNamePmhnd01300aFsw, AssemblyIdPmhnd01300aMethodNameFsw, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01300a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル委託在庫補充_倉庫情報抽出処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a1, AssemblyNamePmhnd01300aFsw, AssemblyIdPmhnd01300aMethodNameFsw, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01300aFsw), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル委託在庫補充_倉庫情報抽出アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01300aMethodNameFsw, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyWarehouseInfoCondObj;
                paramValue[1] = resultHandyWarehouseInfoObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル委託在庫補充_倉庫情報抽出結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル委託在庫補充_倉庫情報抽出ステータスが正常の場合、ハンディターミナル委託在庫補充_倉庫情報抽出結果リストを設定します。
                        resultHandyWarehouseInfoObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a1, AssemblyNamePmhnd01300aFsw, AssemblyIdPmhnd01300aMethodNameFsw, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a1, AssemblyNamePmhnd01300aFsw, AssemblyIdPmhnd01300aMethodNameFsw, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01300a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a1, AssemblyNamePmhnd01300aFsw, AssemblyIdPmhnd01300aMethodNameFsw, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01300a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル委託在庫補充_検品情報抽出
        // ===================================================================================== //
        #region ハンディターミナル委託在庫補充_検品情報抽出
        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報抽出
        /// </summary>
        /// <param name="paraHandyInspectInfoCondObj">ハンディターミナル委託在庫補充_検品情報抽出条件リスト</param>
        /// <param name="resultHandyInspectInfoObj">ハンディターミナル委託在庫補充_検品情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchHandyInspectInfo(ref object paraHandyInspectInfoCondObj, out object resultHandyInspectInfoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyInspectInfoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01304d, AssemblyIdPmhnd01304dClassNameFsi, out errMessage);
            // ハンディターミナル委託在庫補充_検品情報抽出条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01304d, ErrorMsgAssembly);
                return StatusError;
            }

            // 検索条件ワークタイプを取得します。
            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyInspectInfoCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyInspectInfoCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyInspectInfoCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01300a, AssemblyIdPmhnd01300aClassName, out errMessage);
            // ハンディターミナル委託在庫補充_検品情報抽出アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a2, AssemblyNamePmhnd01300aFsi, AssemblyIdPmhnd01300aMethodNameFsi, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01300a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル委託在庫補充_検品情報抽出処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a2, AssemblyNamePmhnd01300aFsi, AssemblyIdPmhnd01300aMethodNameFsi, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01300aFsi), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル委託在庫補充_検品情報抽出アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01300aMethodNameFsi, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyInspectInfoCondObj;
                paramValue[1] = resultHandyInspectInfoObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル委託在庫補充_検品情報抽出結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル委託在庫補充_検品情報抽出ステータスが正常の場合、ハンディターミナル委託在庫補充_検品情報抽出結果リストを設定します。
                        resultHandyInspectInfoObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a2, AssemblyNamePmhnd01300aFsi, AssemblyIdPmhnd01300aMethodNameFsi, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a2, AssemblyNamePmhnd01300aFsi, AssemblyIdPmhnd01300aMethodNameFsi, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01300a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a2, AssemblyNamePmhnd01300aFsi, AssemblyIdPmhnd01300aMethodNameFsi, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01300a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル委託在庫補充_検品情報_登録
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入（入庫更新）_登録
        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報_登録
        /// </summary>
        /// <param name="inspectDataListObj">登録パラメータオブジェクト</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteHandyConsStockRepInspect(ref object inspectDataListObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd01304d, AssemblyIdPmhnd01304dClassNameFiw, out errMessage);
            // ハンディターミナル委託在庫補充_検品情報_登録パラメータオブジェクトアセンブリがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01304d, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル委託在庫補充_検品情報_登録パラメータがない場合
            if (inspectDataListObj == null || !(inspectDataListObj is ArrayList))
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01304d, InsertConditionsError);
                return StatusError;
            }

            // 登録ワークタイプを取得します。
            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = string.Empty;
            string machineName = string.Empty;

            ArrayList inspectDataList = inspectDataListObj as ArrayList;
            // 委託在庫補充_検品情報_登録リスト件数＞０、又、登録ワークのタイプと一致の場合
            if (inspectDataList.Count > 0 && inspectDataList[0].GetType() == insertObj.GetType())
            {
                // 従業員コード
                employeeCode = insertType.GetProperty(EmployeeCode).GetValue(inspectDataList[0], null).ToString();
                // コンピュータ名
                machineName = insertType.GetProperty(MachineName).GetValue(inspectDataList[0], null).ToString();

                // 企業コードをセットします。
                for (int i = 0; i < inspectDataList.Count; i++)
                {
                    // 企業コードを設定します。
                    insertType.GetProperty(EnterpriseCode).SetValue(inspectDataList[i], StaticEnterpriseCode, null);
                }
            }
            else
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01304d, AssemblyWorkError);
                return StatusError;
            }


            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01300a, AssemblyIdPmhnd01300aClassName, out errMessage);
            // ハンディターミナル委託在庫補充_検品情報_登録アクセスアセンブリがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a3, AssemblyNamePmhnd01300aFiw, AssemblyIdPmhnd01300aMethodNameFiw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01300a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル委託在庫補充_検品情報_登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a3, AssemblyNamePmhnd01300aFiw, AssemblyIdPmhnd01300aMethodNameFiw, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd01300aFiw), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // ハンディターミナル委託在庫補充_検品情報_登録アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01300aMethodNameFiw, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = inspectDataListObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル委託在庫補充_検品情報_登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a3, AssemblyNamePmhnd01300aFiw, AssemblyIdPmhnd01300aMethodNameFiw, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a3, AssemblyNamePmhnd01300aFiw, AssemblyIdPmhnd01300aMethodNameFiw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01300a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01300a3, AssemblyNamePmhnd01300aFiw, AssemblyIdPmhnd01300aMethodNameFiw, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01300a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion
        // ------ ADD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        // ===================================================================================== //
        // ハンディターミナル在庫仕入取得処理
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入_在庫情報取得処理
        /// <summary>
        /// ハンディターミナル在庫仕入_在庫情報取得処理
        /// </summary>
        /// <param name="paraHandyStockCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyStockObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入の在庫情報取得処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStock(ref object paraHandyStockCondObj, out object resultHandyStockObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd04104d, AssemblyIdPmhnd04104dClassName, out errMessage);
            // ハンディターミナル在庫仕入の在庫情報取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd04104d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockCondObj, null).ToString();
            int procDiv = (int)condType.GetProperty("OpDiv").GetValue(paraHandyStockCondObj, null);
            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01200a, AssemblyIdPmhnd01200aClassName, out errMessage);
            // ハンディターミナル在庫仕入の在庫情報取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv), AssemblyIdPmhnd01200aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01200a, ErrorMsgAssembly);
                return StatusError;
            }

            // ハンディターミナル在庫仕入の在庫情報取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv), AssemblyIdPmhnd01200aSelMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, GetAssemblyName(AssemblyIdPmhnd01200a, procDiv)), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // ハンディターミナル在庫仕入の在庫情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01200aSelMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockCondObj;
                paramValue[1] = resultHandyStockObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // ハンディターミナル在庫仕入の在庫情報取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // ハンディターミナル在庫仕入の在庫情報取得ステータスが正常の場合、ハンディターミナル在庫仕入の在庫情報結果リストを設定します。
                        resultHandyStockObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv), AssemblyIdPmhnd01200aSelMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv), AssemblyIdPmhnd01200aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01200a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv), AssemblyIdPmhnd01200aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01200a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫仕入検品データ登録(先行検品)処理
        // ===================================================================================== //
        #region ハンディターミナル在庫仕入検品データ登録(先行検品)処理
        /// <summary>
        /// ハンディターミナル在庫仕入検品データ登録処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteHandyInspect(ref object inspectDataObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd00213d, AssemblyIdPmhnd00213dClassName, out errMessage);
            // 検品データ(先行検品)登録条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd00213d, ErrorMsgAssembly);
                return StatusError;
            }

            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = insertType.GetProperty(EmployeeCode).GetValue(inspectDataObj, null).ToString();
            string machineName = insertType.GetProperty(MachineName).GetValue(inspectDataObj, null).ToString();
            int procDiv = (int)insertType.GetProperty(ProcDiv).GetValue(inspectDataObj, null);
            // 企業コードを設定します。
            insertType.GetProperty(EnterpriseCode).SetValue(inspectDataObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01200a, AssemblyIdPmhnd01200aClassName, out errMessage);
            // 検品データ(先行検品)情報登録アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv + 100), AssemblyIdPmhnd01200aWtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01200a, ErrorMsgAssembly);
                return StatusError;
            }

            // 検品データ(先行検品)情報登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv + 100), AssemblyIdPmhnd01200aWtMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, GetAssemblyName(AssemblyIdPmhnd01200a, procDiv + 100)), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 検品データ(先行検品)情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01200aWtMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = inspectDataObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 検品データ(先行検品)情報登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv + 100), AssemblyIdPmhnd01200aWtMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv + 100), AssemblyIdPmhnd01200aWtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01200a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01200a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01200a, procDiv + 100), AssemblyIdPmhnd01200aWtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01200a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // ハンディターミナル在庫移動情報取得処理
        // ===================================================================================== //
        #region ハンディターミナル在庫移動情報取得処理
        /// <summary>
        /// ハンディターミナル在庫移動伝票情報取得処理
        /// </summary>
        /// <param name="paraHandyStockCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyStockObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫移動情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStockMoveData(ref object paraHandyStockCondObj, out object resultHandyStockObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01214d, AssemblyIdPmhnd01214dClassName, out errMessage);
            // ハンディターミナル在庫移動伝票情報取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01214d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockCondObj, null).ToString();
            int procDiv = (int)condType.GetProperty(ProcDiv).GetValue(paraHandyStockCondObj, null);
            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01210a, AssemblyIdPmhnd01210aClassName, out errMessage);
            // 在庫移動情報取得アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv), AssemblyIdPmhnd01210aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01210a, ErrorMsgAssembly);
                return StatusError;
            }

            // 在庫移動情報取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv), AssemblyIdPmhnd01210aSelMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, GetAssemblyName(AssemblyIdPmhnd01210a, procDiv)), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 在庫移動情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01210aSelMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockCondObj;
                paramValue[1] = resultHandyStockObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 在庫移動情報取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 在庫移動情報取得ステータスが正常の場合、在庫移動情報結果リストを設定します。
                        resultHandyStockObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv), AssemblyIdPmhnd01210aSelMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv), AssemblyIdPmhnd01210aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01210a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv), AssemblyIdPmhnd01210aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01210a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 在庫移動（出荷・入荷）検品データ登録処理
        // ===================================================================================== //
        #region 在庫移動（出荷・入荷）検品データ登録処理
        /// <summary>
        /// 在庫移動（出荷・入荷）検品データ登録処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :在庫移動（出荷・入荷）検品データを登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteStockMoveInspect(ref object inspectDataObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd00213d, AssemblyIdPmhnd00213dClassName, out errMessage);
            // 検品データ登録条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd00213d, ErrorMsgAssembly);
                return StatusError;
            }

            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = string.Empty;
            string machineName = string.Empty;
            int procDiv = 0;

            ArrayList paraInspectDataList = inspectDataObj as ArrayList;
            // 在庫移動登録リスト件数＞０、又、登録ワークのタイプと一致の場合
            if (paraInspectDataList.Count > 0 && paraInspectDataList[0].GetType() == insertObj.GetType())
            {
                // 従業員コード
                employeeCode = insertType.GetProperty(EmployeeCode).GetValue(paraInspectDataList[0], null).ToString();
                // コンピュータ名
                machineName = insertType.GetProperty(MachineName).GetValue(paraInspectDataList[0], null).ToString();
                procDiv = (int)insertType.GetProperty(ProcDiv).GetValue(paraInspectDataList[0], null);
                // 従業員の所属拠点コードを取得します。
                string SectionCode = string.Empty;
                if (LoginInfoDic.ContainsKey(employeeCode.Trim()))
                {
                    OprtnHisLogWork OprtnHisLogWorkData = LoginInfoDic[employeeCode.Trim()];
                    // 拠点コードを設定します。
                    SectionCode = OprtnHisLogWorkData.LoginSectionCd;
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd00213d, EmployeeError);
                    return StatusError;
                }

                // 企業コードと従業員の所属拠点コードをセットします。
                for (int i = 0; i < paraInspectDataList.Count; i++)
                {
                    // 企業コードを設定します。
                    insertType.GetProperty(EnterpriseCode).SetValue(paraInspectDataList[i], StaticEnterpriseCode, null);
                    // 拠点コードを設定します。
                    insertType.GetProperty(BelongSectionCode).SetValue(paraInspectDataList[i], SectionCode, null);
                }
            }
            else
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01114d, AssemblyWorkError);
                return StatusError;
            }

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01210a, AssemblyIdPmhnd01210aClassName, out errMessage);
            // 在庫移動（出荷・入荷）検品データ情報登録アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv + 100), AssemblyIdPmhnd01210aWtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01210a, ErrorMsgAssembly);
                return StatusError;
            }

            // 検品データ情報登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv + 100), AssemblyIdPmhnd01210aWtMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, GetAssemblyName(AssemblyIdPmhnd01210a, procDiv + 100)), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                //検品データ情報アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01210aWtMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = inspectDataObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 検品データ情報登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv + 100), AssemblyIdPmhnd01210aWtMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv + 100), AssemblyIdPmhnd01210aWtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01210a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, GetAssemblyId(AssemblyIdPmhnd01210a, procDiv + 100), GetAssemblyName(AssemblyIdPmhnd01210a, procDiv + 100), AssemblyIdPmhnd01210aWtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01210a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2017/08/16 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        // ===================================================================================== //
        // 棚卸処理(一斉)_棚卸対象確認
        // ===================================================================================== //
        #region 棚卸処理(一斉)_棚卸対象確認
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象確認
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理(一斉)の棚卸対象情報が存在するかを確認します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCount(ref object condObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj1 = LoadAssembly(AssemblyIdPmhnd05504d, AssemblyIdPmhnd05504dClassName, out errMessage);
            // 棚卸対象確認条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj1 == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05504d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj1.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(condObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(condObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(condObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd05400a, AssemblyIdPmhnd05400aClassName, out errMessage);
            // 棚卸処理(一斉)アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a1, AssemblyNamePmhnd05400a, AssemblyIdPmhnd05400aSelCMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05400a, ErrorMsgAssembly);
                return StatusError;
            }

            // 棚卸対象確認処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a1, AssemblyNamePmhnd05400a, AssemblyIdPmhnd05400aSelCMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd05400a), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 棚卸処理(一斉)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd05400aSelCMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = condObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 棚卸対象確認結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a1, AssemblyNamePmhnd05400a, AssemblyIdPmhnd05400aSelCMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a1, AssemblyNamePmhnd05400a, AssemblyIdPmhnd05400aSelCMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05400a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a1, AssemblyNamePmhnd05400a, AssemblyIdPmhnd05400aSelCMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05400a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion
        // ===================================================================================== //
        // 棚卸処理(一斉)_棚卸対象取得
        // ===================================================================================== //
        #region 棚卸処理(一斉)_棚卸対象取得
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理(一斉)の棚卸対象情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchInventory(ref object condObj, out object retObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            retObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj1 = LoadAssembly(AssemblyIdPmhnd05504d, AssemblyIdPmhnd05504dClassName, out errMessage);
            // 棚卸対象取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05504d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj1.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(condObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(condObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(condObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd05400a, AssemblyIdPmhnd05400aClassName, out errMessage);
            // 棚卸処理(一斉)アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a2, AssemblyNamePmhnd05400b, AssemblyIdPmhnd05400aSelIMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05400a, ErrorMsgAssembly);
                return StatusError;
            }

            // 棚卸対象取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a2, AssemblyNamePmhnd05400b, AssemblyIdPmhnd05400aSelIMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd05400b), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 棚卸処理(一斉)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd05400aSelIMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = condObj;
                paramValue[1] = retObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 棚卸対象取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 棚卸対象取得ステータスが正常の場合、在棚卸対象取得結果リストを設定します。
                        retObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a2, AssemblyNamePmhnd05400b, AssemblyIdPmhnd05400aSelIMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a2, AssemblyNamePmhnd05400b, AssemblyIdPmhnd05400aSelIMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05400a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a2, AssemblyNamePmhnd05400b, AssemblyIdPmhnd05400aSelIMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05400a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 棚卸処理(一斉)_棚卸データ更新
        // ===================================================================================== //
        #region 棚卸処理(一斉)_棚卸データ更新
        /// <summary>
        /// 棚卸処理(一斉)_棚卸データ更新
        /// </summary>
        /// <param name="inventoryDataObj">登録パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理(一斉)の棚卸情報を棚卸データに登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteInventoryData(ref object inventoryDataObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object insertObj = LoadAssembly(AssemblyIdPmhnd05504d, AssemblyIdPmhnd05504dClassName, out errMessage);
            // 棚卸データ更新条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05504d, ErrorMsgAssembly);
                return StatusError;
            }

            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = insertType.GetProperty(EmployeeCode).GetValue(inventoryDataObj, null).ToString();
            string machineName = insertType.GetProperty(MachineName).GetValue(inventoryDataObj, null).ToString();

            // 企業コードを設定します。
            insertType.GetProperty(EnterpriseCode).SetValue(inventoryDataObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd05400a, AssemblyIdPmhnd05400aClassName, out errMessage);
            // 棚卸処理(一斉)アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a3, AssemblyNamePmhnd05400c, AssemblyIdPmhnd05400aWrtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05400a, ErrorMsgAssembly);
                return StatusError;
            }

            // 棚卸データ更新処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a3, AssemblyNamePmhnd05400c, AssemblyIdPmhnd05400aWrtMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd05400c), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 棚卸処理(一斉)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd05400aWrtMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = inventoryDataObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 棚卸データ更新結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a3, AssemblyNamePmhnd05400c, AssemblyIdPmhnd05400aWrtMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a3, AssemblyNamePmhnd05400c, AssemblyIdPmhnd05400aWrtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05400a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05400a3, AssemblyNamePmhnd05400c, AssemblyIdPmhnd05400aWrtMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05400a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 棚卸処理(循環)_倉庫存在確認処理
        // ===================================================================================== //
        #region 棚卸処理(循環)_倉庫存在確認処理
        /// <summary>
        /// 棚卸処理(循環)_倉庫存在確認処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理（循環)指定倉庫に在庫情報が存在しているかを確認します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStockCount(ref object condObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj1 = LoadAssembly(AssemblyIdPmhnd05504d, AssemblyIdPmhnd05504dClassName, out errMessage);
            // 倉庫存在確認条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj1 == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05504d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj1.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(condObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(condObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(condObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd05500a, AssemblyIdPmhnd05500aClassName, out errMessage);
            // 棚卸処理(循環)アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a1, AssemblyNamePmhnd05500a, AssemblyIdPmhnd05500aSelCMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05500a, ErrorMsgAssembly);
                return StatusError;
            }

            // 倉庫存在確認処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a1, AssemblyNamePmhnd05500a, AssemblyIdPmhnd05500aSelCMethodName, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd05500a), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();

                // 棚卸処理(循環)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd05500aSelCMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = condObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 倉庫存在確認結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a1, AssemblyNamePmhnd05500a, AssemblyIdPmhnd05500aSelCMethodName, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion
                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a1, AssemblyNamePmhnd05500a, AssemblyIdPmhnd05500aSelCMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05500a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a1, AssemblyNamePmhnd05500a, AssemblyIdPmhnd05500aSelCMethodName, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05500a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion

        // ===================================================================================== //
        // 棚卸処理（循環)_在庫情報取得処理
        // ===================================================================================== //
        #region 棚卸処理（循環)_在庫情報取得処理
        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理（循環)の指定在庫品の在庫情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStockCircul(ref object condObj, out object retObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            retObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj1 = LoadAssembly(AssemblyIdPmhnd05504d, AssemblyIdPmhnd05504dClassName, out errMessage);
            // 在庫情報取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05504d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj1.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(condObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(condObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(condObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd05500a, AssemblyIdPmhnd05500aClassName, out errMessage);
            // 棚卸処理（循環)アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a2, AssemblyNamePmhnd05500b, AssemblyIdPmhnd05500aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05500a, ErrorMsgAssembly);
                return StatusError;
            }

            // 在庫情報取得処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a2, AssemblyNamePmhnd05500b, AssemblyIdPmhnd05500aSelMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd05500b), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 棚卸処理（循環)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd05500aSelMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = condObj;
                paramValue[1] = retObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 在庫情報取得結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 在庫情報取得ステータスが正常の場合、在庫情報取得処理結果リストを設定します。
                        retObj = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a2, AssemblyNamePmhnd05500b, AssemblyIdPmhnd05500aSelMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a2, AssemblyNamePmhnd05500b, AssemblyIdPmhnd05500aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05500a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a2, AssemblyNamePmhnd05500b, AssemblyIdPmhnd05500aSelMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05500a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 棚卸処理（循環)_棚卸情報登録
        // ===================================================================================== //
        #region 棚卸処理（循環)_棚卸情報登録
        /// <summary>
        /// 棚卸処理（循環)_棚卸情報登録
        /// </summary>
        /// <param name="inventoryDataObj">棚卸情報データオブジェクト</param>
        /// <param name="retObj">循環棚卸通番オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸情報を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteCirculInventoryData(ref object inventoryDataObj, out object retObj)
        {
            int status = StatusError;
            // インスタンス生成
            string errMessage = string.Empty;
            retObj = null;
            object insertObj = LoadAssembly(AssemblyIdPmhnd05504d, AssemblyIdPmhnd05504dClassName, out errMessage);
            // 棚卸情報登録条件オブジェクトがない場合、「-1」を戻ります。
            if (insertObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05504d, ErrorMsgAssembly);
                return StatusError;
            }

            Type insertType = insertObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = insertType.GetProperty(EmployeeCode).GetValue(inventoryDataObj, null).ToString();
            string machineName = insertType.GetProperty(MachineName).GetValue(inventoryDataObj, null).ToString();
            // 従業員の所属拠点コードを取得します。
            string SectionCode = string.Empty;
            if (!String.IsNullOrEmpty(employeeCode))
            {
                if (LoginInfoDic.ContainsKey(employeeCode.Trim()))
                {
                    OprtnHisLogWork OprtnHisLogWorkData = LoginInfoDic[employeeCode.Trim()];
                    // 拠点コードを設定します。
                    SectionCode = OprtnHisLogWorkData.LoginSectionCd;
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05504d, EmployeeError);
                    return StatusError;
                }
            }
            // 企業コードを設定します。
            insertType.GetProperty(EnterpriseCode).SetValue(inventoryDataObj, StaticEnterpriseCode, null);
            // 拠点コードを設定します。
            insertType.GetProperty(BelongSectionCode).SetValue(inventoryDataObj, SectionCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd05500a, AssemblyIdPmhnd05500aClassName, out errMessage);
            // 棚卸処理（循環)アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a3, AssemblyNamePmhnd05500c, AssemblyIdPmhnd05500aWrtIMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05500a, ErrorMsgAssembly);
                return StatusError;
            }

            // 棚卸情報登録実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetWriteAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a3, AssemblyNamePmhnd05500c, AssemblyIdPmhnd05500aWrtIMethodName, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageWrite, AssemblyNamePmhnd05500c), employeeCode);
                #endregion

                return StatusTimeout;
            }

            // 登録中件数+1
            System.Threading.Interlocked.Increment(ref WritingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();

                // 棚卸処理（循環)アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd05500aWrtIMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = inventoryDataObj;
                paramValue[1] = retObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 棚卸情報登録結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;
                    if (status == StatusNomal)
                    {
                        // 在庫情報取得ステータスが正常の場合、在庫情報取得処理結果リストを設定します。
                        retObj = paramValue[1];
                    }
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a3, AssemblyNamePmhnd05500c, AssemblyIdPmhnd05500aWrtIMethodName, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a, AssemblyNamePmhnd05500c, AssemblyIdPmhnd05500aWrtIMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd05500a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd05500a3, AssemblyNamePmhnd05500c, AssemblyIdPmhnd05500aWrtIMethodName, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd05500a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 登録中件数-1
                System.Threading.Interlocked.Decrement(ref WritingCount);
            }

            return status;
        }
        #endregion
        // ------ ADD 2017/08/16 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        // ===================================================================================== //
        // 操作履歴ログデータの登録
        // ===================================================================================== //
        #region 操作履歴ログデータの登録
        /// <summary>
        /// 初回ログイン成功後操作履歴ログデータの登録
        /// </summary>
        /// <param name="acsObj">ログイン情報取得アクセスオブジェクト</param>
        /// <param name="resultHandyLoginInfoObj">ログイン情報取得結果オブジェクト</param>
        /// <param name="machineName">端末名</param>
        /// <remarks>
        /// <br>Note       : 初回ログイン成功後操作履歴ログデータを登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private void WriteLoginHistoryLog(object acsObj, object resultHandyLoginInfoObj, string machineName)
        {
            string errMsg = string.Empty;

            try
            {
                object retObj = LoadAssembly(AssemblyIdPmhnd00014d, AssemblyIdPmhnd00014dResultClassName, out errMsg);
                // ログイン情報検索結果オブジェクトがない場合、
                if (retObj == null)
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd00014d, ErrorMsgAssembly);
                    return;
                } 

                Type retType = retObj.GetType();
                // ログイン拠点コード
                string belongSectionCode = retType.GetProperty(BelongSectionCode).GetValue(resultHandyLoginInfoObj, null).ToString();
                // ログイン担当者コード
                string employeeCode = retType.GetProperty(EmployeeCode).GetValue(resultHandyLoginInfoObj, null).ToString();
                // ログイン担当者名
                string name = retType.GetProperty(Name).GetValue(resultHandyLoginInfoObj, null).ToString();
                // ログイン権限レベル1
                int authorityLevel1 = (int)retType.GetProperty(AuthorityLevel1).GetValue(resultHandyLoginInfoObj, null);
                // ログイン権限レベル2
                int authorityLevel2 = (int)retType.GetProperty(AuthorityLevel2).GetValue(resultHandyLoginInfoObj, null);
                // 対象アセンブリID
                string logDataObjAssemblyID = string.Empty;
                // 対象アセンブリシステムバージョン
                string logDataSystemVersion = string.Empty;
                // 対象アセンブリクラスID
                string logDataObjClassID = string.Empty;

                if (acsObj != null)
                {
                    AssemblyName assemblyName = acsObj.GetType().Assembly.GetName();

                    // 対象アセンブリオブジェクトがある場合、
                    if (assemblyName != null)
                    {
                        // 対象アセンブリID
                        logDataObjAssemblyID = assemblyName.Name;
                        // 対象アセンブリシステムバージョン
                        logDataSystemVersion = assemblyName.Version.ToString();
                    }

                    // 対象アセンブリクラスID
                    if (acsObj.GetType() != null) logDataObjClassID = acsObj.GetType().Name;
                }

                // 履歴ログワーク
                OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
                // 企業コード
                oprtnHisLogWork.EnterpriseCode = StaticEnterpriseCode;
                // ログデータ作成日時
                oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
                // ログイン拠点コード
                oprtnHisLogWork.LoginSectionCd = belongSectionCode.Trim();
                // ログデータ種別区分コード
                oprtnHisLogWork.LogDataKindCd = (int)LogDataKind.OperationLog;
                // ログデータ端末名
                if (!string.IsNullOrEmpty(machineName) && machineName.Length > 80)
                {
                    machineName = machineName.Substring(0, 80);
                }
                oprtnHisLogWork.LogDataMachineName = machineName;
                // ログデータ担当者コード
                oprtnHisLogWork.LogDataAgentCd = employeeCode.Trim();
                // ログデータ担当者名
                oprtnHisLogWork.LogDataAgentNm = name;
                // ログデータ対象起動プログラム名称
                oprtnHisLogWork.LogDataObjBootProgramNm = AssemblyNamePmhnd00010a;

                // ログデータ対象アセンブリID
                oprtnHisLogWork.LogDataObjAssemblyID = logDataObjAssemblyID;
                // ログデータ対象アセンブリ名称
                oprtnHisLogWork.LogDataObjAssemblyNm = AssemblyNamePmhnd00010a;
                // ログデータ対象クラスID
                oprtnHisLogWork.LogDataObjClassID = logDataObjClassID;
                // ログデータ対象処理名
                oprtnHisLogWork.LogDataObjProcNm = AssemblyIdPmhnd00010aMethodName;
                // ログデータオペレーションコード
                oprtnHisLogWork.LogDataOperationCd = OperationCodeLogin;
                // ログデータオペレーターデータ処理レベル
                if (authorityLevel1 <= MaxLevel)
                {
                    oprtnHisLogWork.LogOperaterDtProcLvl = authorityLevel1.ToString();
                }
                else
                {
                    oprtnHisLogWork.LogOperaterDtProcLvl = MaxLevel.ToString();
                }
                // ログデータオペレーター機能処理レベル
                if (authorityLevel2 <= MaxLevel)
                {
                    oprtnHisLogWork.LogOperaterFuncLvl = authorityLevel2.ToString();
                }
                else
                {
                    oprtnHisLogWork.LogOperaterFuncLvl = MaxLevel.ToString();
                }

                // ログデータシステムバージョン
                oprtnHisLogWork.LogDataSystemVersion = logDataSystemVersion;
                // ログオペレーションステータス
                oprtnHisLogWork.LogOperationStatus = 0;
                // ログデータメッセージ
                oprtnHisLogWork.LogDataMassage = MessageOk;
                // ログオペレーションデータ
                oprtnHisLogWork.LogOperationData = string.Empty;

                // 従業員情報DIC
                lock (LoginInfoDic)
                {
                    // 従業員情報DIC中に該当従業員がない場合、
                    if (!LoginInfoDic.ContainsKey(employeeCode.Trim()))
                    {
                        // 該当従業員情報は従業員情報DIC中に追加します。
                        LoginInfoDic.Add(employeeCode.Trim(), oprtnHisLogWork);
                    }
                }

                object oprtnHisLogWorkObj = (object)oprtnHisLogWork;

                // 履歴ログを登録します。
                IOprtnHisLogDB iOprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();
                iOprtnHisLogDB.Write(ref oprtnHisLogWorkObj);
            }
            finally
            {
                // 履歴ログを登録失敗場合、処理なし。
            }
        }

        /// <summary>
        /// ログイン以外操作履歴ログデータの登録
        /// </summary>
        /// <param name="acsObj">呼び出し元オブジェクト</param>
        /// <param name="logDataKind">ログ種別</param>
        /// <param name="machineName">端末名</param>
        /// <param name="programId">プログラムID</param>
        /// <param name="programName">プログラム名</param>
        /// <param name="methodName">メソッド名</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="status">ステータス</param>
        /// <param name="message">メッセージ</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <remarks>
        /// <br>Note       : ログイン以外操作履歴ログデータを登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private void WriteOtherHistoryLog(object acsObj,
            LogDataKind logDataKind, 
            string machineName,
            string programId,
            string programName,
            string methodName,
            int operationCode,
            int status,
            string message,
            string employeeCode)
        {
            try
            {
                // 履歴ログワーク
                OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();

                // 従業員情報DIC
                lock (LoginInfoDic)
                {
                    // 従業員情報DIC中に該当従業員がある場合、
                    if (LoginInfoDic.ContainsKey(employeeCode.Trim()))
                    {
                        // 該当従業員情報は履歴ログワーク中に設定します。
                        oprtnHisLogWork = LoginInfoDic[employeeCode.Trim()];
                    }
                    else
                    {
                        // 従業員情報DIC中に該当従業員がない場合、戻ります。
                        return;
                    }
                }

                // 対象アセンブリID
                // ------ UPD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- >>>>
                //string logDataObjAssemblyID = string.Empty;
                string logDataObjAssemblyID = programId;
                // ------ UPD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- <<<<
                // 対象アセンブリシステムバージョン
                string logDataSystemVersion = string.Empty;
                // 対象アセンブリクラスID
                string logDataObjClassID = string.Empty;

                if (acsObj != null)
                {
                    AssemblyName assemblyName = acsObj.GetType().Assembly.GetName();

                    // 対象アセンブリオブジェクトがある場合、
                    if (assemblyName != null)
                    {
                        // ------ DEL 2017/08/02 譚洪 ハンディターミナル二次開発 --------- >>>>
                        //// 対象アセンブリID
                        //logDataObjAssemblyID = assemblyName.Name;
                        // ------ DEL 2017/08/02 譚洪 ハンディターミナル二次開発 --------- <<<<
                        // 対象アセンブリシステムバージョン
                        logDataSystemVersion = assemblyName.Version.ToString();
                    }

                    // 対象アセンブリクラスID
                    if (acsObj.GetType() != null) logDataObjClassID = acsObj.GetType().Name;

                }

                // ------ DEL 2017/08/02 譚洪 ハンディターミナル二次開発 --------- >>>>
                //// アセンブリID取得できない場合、パラメータのアセンブリIDを設定します。
                //if (string.IsNullOrEmpty(logDataObjAssemblyID))
                //{
                //    logDataObjAssemblyID = programId;
                //}
                // ------ DEL 2017/08/02 譚洪 ハンディターミナル二次開発 --------- <<<<
                
                // ログデータ作成日時
                oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
                // ログデータ種別区分コード
                oprtnHisLogWork.LogDataKindCd = (int)logDataKind;
                // ログデータ端末名
                if (!string.IsNullOrEmpty(machineName) && machineName.Length > 80)
                {
                    machineName = machineName.Substring(0, 80);
                }
                oprtnHisLogWork.LogDataMachineName = machineName;
                // ログデータ対象起動プログラム名称
                oprtnHisLogWork.LogDataObjBootProgramNm = programName;

                // ログデータ対象アセンブリID
                oprtnHisLogWork.LogDataObjAssemblyID = logDataObjAssemblyID;
                // ログデータ対象アセンブリ名称
                oprtnHisLogWork.LogDataObjAssemblyNm = programName;
                // ログデータ対象クラスID
                oprtnHisLogWork.LogDataObjClassID = logDataObjClassID;
                // ログデータ対象処理名
                oprtnHisLogWork.LogDataObjProcNm = methodName;
                // ログデータオペレーションコード
                oprtnHisLogWork.LogDataOperationCd = operationCode;
                // ログデータシステムバージョン
                oprtnHisLogWork.LogDataSystemVersion = logDataSystemVersion;
                // ログオペレーションステータス
                oprtnHisLogWork.LogOperationStatus = status;
                // ログデータメッセージ
                oprtnHisLogWork.LogDataMassage = message;
                // ログオペレーションデータ
                oprtnHisLogWork.LogOperationData = string.Empty;

                object oprtnHisLogWorkObj = (object)oprtnHisLogWork;

                // 履歴ログを登録します。
                IOprtnHisLogDB iOprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();
                iOprtnHisLogDB.Write(ref oprtnHisLogWorkObj);
            }
            finally
            {
                // 履歴ログを登録失敗場合、処理なし。
            }
        }
        #endregion

        // ===================================================================================== //
        // 設定と計算など処理
        // ===================================================================================== //
        #region 設定と計算など処理
        /// <summary>
        /// 処理実行可能判断
        /// </summary>
        /// <returns>True:検索実行可 False:実行タイムアウト</returns>
        /// <remarks>
        /// <br>Note       : 処理実行可能を判断します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private bool GetReadAccessFlg()
        {
            bool accessFlg = true;

            // スレッド開始時間
            DateTime threadStartTime = DateTime.Now;
            DateTime threadEndTime;

            // 読込中件数＞＝読込最大件数場合、スレッド待ち
            while (ReadingCount >= ReadMaxCount)
            {
                // 終了フラグがTrue場合、False:実行タイムアウトを戻ります。
                if (CloseFlg)
                {
                    return false;
                }

                // スレッド完了時間
                threadEndTime = DateTime.Now;

                // スレッド待ち時間＞＝XML設定時間の場合、False:実行タイムアウトを戻ります。
                if (DateDiff(threadStartTime, threadEndTime) >= ThreadWaitTime)
                {
                    return false;
                }

                // スレッド待ち
                System.Threading.Thread.Sleep(1000);
            }

            return accessFlg;
        }

        /// <summary>
        /// 処理実行可能判断
        /// </summary>
        /// <returns>True:検索実行可 False:実行タイムアウト</returns>
        /// <remarks>
        /// <br>Note       : 処理実行可能を判断します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private bool GetWriteAccessFlg()
        {
            bool accessFlg = true;

            // スレッド開始時間
            DateTime threadStartTime = DateTime.Now;
            DateTime threadEndTime;

            // 書込中件数＞＝書込最大件数場合、スレッド待ち
            while (WritingCount >= WriteMaxCount)
            {
                // 終了フラグがTrue場合、False:実行タイムアウトを戻ります。
                if (CloseFlg)
                {
                    return false;
                }

                // スレッド完了時間
                threadEndTime = DateTime.Now;

                // スレッド待ち時間＞＝XML設定時間の場合、False:実行タイムアウトを戻ります。
                if (DateDiff(threadStartTime, threadEndTime) >= ThreadWaitTime)
                {
                    return false;
                }

                // スレッド待ち
                System.Threading.Thread.Sleep(1000);
            }

            return accessFlg;
        }

        /// <summary>
        /// 時間差計算
        /// </summary>
        /// <param name="dtStart">開始時間</param>
        /// <param name="dtEnd">終了時間</param>
        /// <returns>時間差</returns>
        /// <remarks>
        /// <br>Note       : 時間差を計算します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private int DateDiff(DateTime dtStart, DateTime dtEnd)
        {
            // 開始時間
            TimeSpan timeSpanStart = new TimeSpan(dtStart.Ticks);
            // 終了時間
            TimeSpan timeSpanEnd = new TimeSpan(dtEnd.Ticks);
            // 時間差
            TimeSpan timeSpanDiff = timeSpanStart.Subtract(timeSpanEnd).Duration();

            return (int)timeSpanDiff.TotalSeconds;
        }

        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // インスタンスタイプがある場合、インスタンスオブジェクトを生成します。
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// 読込中件数取得
        /// </summary>
        /// <returns>読込中件数</returns>
        /// <remarks>
        /// <br>Note       : 読込中件数を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public int GetReadingCount()
        {
            return ReadingCount;
        }

        /// <summary>
        /// 書込中件数取得
        /// </summary>
        /// <returns>書込中件数</returns>
        /// <remarks>
        /// <br>Note       : 書込中件数を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public int GetWritingCount()
        {
            return WritingCount;
        }

        /// <summary>
        /// 読込最大件数設定
        /// </summary>
        /// <param name="readMaxCount">読込最大件数</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : 読込最大件数を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public void SetReadMaxCount(int readMaxCount)
        {
            ReadMaxCount = readMaxCount;
        }

        /// <summary>
        /// 書込最大件数設定
        /// </summary>
        /// <param name="writeMaxCount">書込最大件数</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : 書込最大件数を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public void SetWriteMaxCount(int writeMaxCount)
        {
            WriteMaxCount = writeMaxCount;
        }

        /// <summary>
        /// スレッド待ち時間設定
        /// </summary>
        /// <param name="threadWaitTime">スレッド待ち時間</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : スレッド待ち時間を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public void SetThreadWaitTime(int threadWaitTime)
        {
            ThreadWaitTime = threadWaitTime;
        }

        /// <summary>
        /// 終了フラグ設定
        /// </summary>
        /// <param name="closeFlg">終了フラグ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : 終了フラグを設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        public void SetCloseFlg(bool closeFlg)
        {
            CloseFlg = closeFlg;
        }
        #endregion

        // ===================================================================================== //
        // アセンブリ名取得処理
        // ===================================================================================== //
        #region アセンブリ名取得処理
        /// <summary>
        /// アセンブリ名取得処理
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <param name="opDiv">処理区分</param>
        /// <returns>アセンブリ名</returns>
        /// <remarks>
        /// <br>Note       : アセンブリ名を取得処理する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private string GetAssemblyName(string assemblyId, int opDiv)
        {
            string assemblyName = string.Empty;

            switch (assemblyId)
            {
                // 検品対象取得(伝票番号)
                case AssemblyIdPmhnd04000a:
                    switch (opDiv)
                    {
                        // 引数.処理区分が「1」の場合、ハンディ 販売業務（出荷）
                        case 1:
                            assemblyName = AssemblyNamePmhnd04000a1;
                            break;
                        // 引数.処理区分が「2」の場合、ハンディ 貸出業務（出荷）
                        case 2:
                            assemblyName = AssemblyNamePmhnd04000a2;
                            break;
                        // 引数.処理区分が「3」の場合、ハンディ 販売業務（入荷）
                        case 3:
                            assemblyName = AssemblyNamePmhnd04000a3;
                            break;
                        // 引数.処理区分が「4」の場合、ハンディ 貸出返却検品
                        case 4:
                            assemblyName = AssemblyNamePmhnd04000a4;
                            break;
                        // 引数.処理区分が「1,2,3,4」以外の場合、検品対象取得(伝票番号)
                        default:
                            assemblyName = AssemblyNamePmhnd04000a;
                            break;
                    }
                    break;
                // 検品対象取得(伝票番号)
                case AssemblyIdPmhnd04010a:
                    switch (opDiv)
                    {
                        // 引数.処理区分が「1」の場合、ハンディ 販売業務（出荷）
                        case 1:
                            assemblyName = AssemblyNamePmhnd04000a1;
                            break;
                        // 引数.処理区分が「2」の場合、ハンディ 貸出業務（出荷）
                        case 2:
                            assemblyName = AssemblyNamePmhnd04000a2;
                            break;
                        // 引数.処理区分が「1,2」以外の場合、検品対象取得(一括検品)
                        default:
                            assemblyName = AssemblyNamePmhnd04010a;
                            break;
                    }
                    break;
                // 検品データ登録
                case AssemblyIdPmhnd01000a:
                    switch (opDiv)
                    {
                        // 引数.処理区分が「1」の場合、ハンディ 販売業務（出荷）
                        case 1:
                            assemblyName = AssemblyNamePmhnd04000a1;
                            break;
                        // 引数.処理区分が「2」の場合、ハンディ 貸出業務（出荷）
                        case 2:
                            assemblyName = AssemblyNamePmhnd04000a2;
                            break;
                        // 引数.処理区分が「3」の場合、ハンディ 販売業務（入荷）
                        case 3:
                            assemblyName = AssemblyNamePmhnd04000a3;
                            break;
                        // 引数.処理区分が「4」の場合、ハンディ 貸出返却検品
                        case 4:
                            assemblyName = AssemblyNamePmhnd04000a4;
                            break;
                        // 引数.処理区分が「1,2,3,4」以外の場合、検品データ登録
                        default:
                            assemblyName = AssemblyNamePmhnd01000a;
                            break;
                    }
                    break;
                // 在庫仕入
                case AssemblyIdPmhnd01200a:
                    switch (opDiv)
                    {
                        // 処理区分が「13」の場合、在庫仕入（入荷）　検品
                        case 13:
                            assemblyName = AssemblyNamePmhnd01200ES;
                            break;
                        // 処理区分が「14」の場合、在庫仕入（出荷）　検品
                        case 14:
                            assemblyName = AssemblyNamePmhnd01200S;
                            break;
                        // 処理区分が「113」の場合、在庫仕入（入荷）　登録
                        case 113:
                            assemblyName = AssemblyNamePmhnd01200EW;
                            break;
                        // 処理区分が「114」の場合、在庫仕入（出荷）　登録
                        case 114:
                            assemblyName = AssemblyNamePmhnd01200W;
                            break;
                        default:
                            break;
                    }
                    break;
                // 在庫移動
                case AssemblyIdPmhnd01210a:
                    switch (opDiv)
                    {
                        // 処理区分が「15」の場合、在庫移動（出荷）　検品
                        case 15:
                            assemblyName = AssemblyNamePmhnd01210S;
                            break;
                        // 処理区分が「16」の場合、在庫移動（出荷）　登録
                        case 16:
                            assemblyName = AssemblyNamePmhnd01210ES;
                            break;
                        // 処理区分が「115」の場合、在庫移動（出荷）　登録
                        case 115:
                            assemblyName = AssemblyNamePmhnd01210W;
                            break;
                        // 処理区分が「116」の場合、在庫移動（入荷）　登録
                        case 116:
                            assemblyName = AssemblyNamePmhnd01210EW;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;

            }

            return assemblyName;
        }
        #endregion
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        // ===================================================================================== //
        // 履歴ログ登録用のプログラムID取得処理
        // ===================================================================================== //
        #region 履歴ログ登録用のプログラムID取得処理
        /// <summary>
        /// 履歴ログ登録用のプログラムID取得処理
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <param name="opDiv">処理区分</param>
        /// <returns>アセンブリ名</returns>
        /// <remarks>
        /// <br>Note       : アセンブリ名を取得処理する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private string GetAssemblyId(string assemblyId, int opDiv)
        {
            string logDataObjAssemblyID = string.Empty;

            switch (assemblyId)
            {
                // 在庫仕入
                case AssemblyIdPmhnd01200a:
                    switch (opDiv)
                    {
                        // 処理区分が「13」の場合、在庫仕入（入荷）　検品
                        case 13:
                            logDataObjAssemblyID = AssemblyIdPmhnd01200a1;
                            break;
                        // 処理区分が「14」の場合、在庫仕入（出荷）　検品
                        case 14:
                            logDataObjAssemblyID = AssemblyIdPmhnd01200a3;
                            break;
                        // 処理区分が「113」の場合、在庫仕入（入荷）　登録
                        case 113:
                            logDataObjAssemblyID = AssemblyIdPmhnd01200a2;
                            break;
                        // 処理区分が「114」の場合、在庫仕入（出荷）　登録
                        case 114:
                            logDataObjAssemblyID = AssemblyIdPmhnd01200a4;
                            break;
                        default:
                            break;
                    }
                    break;
                // 在庫移動
                case AssemblyIdPmhnd01210a:
                    switch (opDiv)
                    {
                        // 処理区分が「15」の場合、在庫移動（出荷）　検品
                        case 15:
                            logDataObjAssemblyID = AssemblyIdPmhnd01210a1;
                            break;
                        // 処理区分が「16」の場合、在庫移動（入荷）　検品
                        case 16:
                            logDataObjAssemblyID = AssemblyIdPmhnd01210a3;
                            break;
                        // 処理区分が「115」の場合、在庫移動（出荷）　登録
                        case 115:
                            logDataObjAssemblyID = AssemblyIdPmhnd01210a2;
                            break;
                        // 処理区分が「116」の場合、在庫移動（入荷）　登録
                        case 116:
                            logDataObjAssemblyID = AssemblyIdPmhnd01210a4;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;

            }

            return logDataObjAssemblyID;
        }
        #endregion
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        // ===================================================================================== //
        // 操作履歴ログ用メッセージ内容取得処理
        // ===================================================================================== //
        #region 操作履歴ログ用メッセージ内容取得処理
        /// <summary>
        /// 操作履歴ログ用メッセージ内容取得処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <returns>操作履歴ログ用メッセージ内容</returns>
        /// <remarks>
        /// <br>Note       : 操作履歴ログ用メッセージ内容を取得処理する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private string GetStatusMessage(int status)
        {
            string message = string.Empty;

            switch (status)
            {
                // 正常終了しました。
                case StatusNomal:
                    message = MessageOk;
                    break;
                // 抽出対象のデータが存在しません。
                case StatusNotFound:
                    message = MessageNotFound;
                    break;
                // タイムアウトエラーが発生しました。
                case StatusTimeout:
                    message = MessageTimeout;
                    break;
                // 検品対象伝票ではありません。
                case StatusNonTarget:
                    message = MessageNonTarget;
                    break;
                // エラーが発生しました。
                case StatusError:
                    message = MessageError;
                    break;
                // 排他エラーが発生しました。
                case StatusArset:
                    message = MessageArsetError;
                    break;
                // 仕入先伝票番号の重複エラー
                case StatusRegists:
                    message = MessageRegistsError;
                    break;
                // エラーが発生しました。
                default:
                    message = MessageError;
                    break;
            }

            return message;
        }

        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(string assemblyId, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + PathLog;

            lock (LogLockObj)
            {
                // フォルダが存在しない場合、
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, assemblyId, errMsg));

                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion

        // --- ADD 2019/11/13 ---------->>>>>
        // ===================================================================================== //
        // 倉庫リスト取得
        // ===================================================================================== //
        #region 倉庫リスト取得
        /// <summary>
        /// 倉庫リスト取得処理
        /// </summary>
        /// <param name="paraHandyWarehouseListCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyWarehouseListObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象取得(伝票番号)を取得します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/14</br>
        /// </remarks>
        public int SearchHandyWarehouseList(ref object paraHandyWarehouseListCondObj, out object resultHandyWarehouseListObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyWarehouseListObj = null;

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // インスタンス生成
                string errMessage = string.Empty;
                object acsObj = this.LoadAssembly("MAKHN09332A", "Broadleaf.Application.Controller.WarehouseAcs", out errMessage);
                // 検品対象取得(伝票番号)取得アクセスオブジェクトがない場合、「-1」を戻ります。
                if (acsObj == null) return StatusError;

                object condObj = LoadAssembly(AssemblyIdPmhnd01304d, AssemblyIdPmhnd01304dClassNameFsw, out errMessage);
                // ハンディターミナル委託在庫補充_倉庫情報抽出条件オブジェクトがない場合、「-1」を戻ります。
                if (condObj == null)
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01304d, ErrorMsgAssembly);
                    return StatusError;
                }

                // 検索条件ワークタイプを取得します。
                Type condType = condObj.GetType();
                // （従業員コードとコンピュータ名）操作履歴ログ用
                string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyWarehouseListCondObj, null).ToString();
                string machineName = condType.GetProperty(MachineName).GetValue(paraHandyWarehouseListCondObj, null).ToString();

                // 企業コードを設定します。
                condType.GetProperty(EnterpriseCode).SetValue(paraHandyWarehouseListCondObj, StaticEnterpriseCode, null);

                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(ArrayList).MakeByRefType();
                paramTypes[1] = typeof(String);

                // 倉庫リスト取得アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod("SearchHandy", paramTypes);
                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = resultHandyWarehouseListObj;
                paramValue[1] = StaticEnterpriseCode;

                object retVal = myMethod.Invoke(acsObj, paramValue);


                // 倉庫リスト取得結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == 0)
                    {
                        // 倉庫リスト取得ステータスが正常の場合、倉庫リストを設定します。
                        resultHandyWarehouseListObj = paramValue[0];
                    }
                }
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion
        // --- ADD 2019/11/13 ----------<<<<<<<<<<
        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ---------->>>>>
        // ===================================================================================== //
        // パターン検索
        // ===================================================================================== //
        #region パターン検索
        /// <summary>
        /// パターン検索
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyStockInfoListObj">検索結果オブジェクト</param>
        /// <param name="makerGoodsSerchHisNoObj">パターン検索履歴通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : パターン検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyStockPaturn(ref object paraHandyStockInfoCondObj, out object resultHandyStockInfoListObj, out object makerGoodsSerchHisNoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockInfoListObj = null;
            makerGoodsSerchHisNoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01234d, AssemblyIdPmhnd01234dClassName, out errMessage);
            // パターン検索取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01234d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockInfoCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockInfoCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockInfoCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01230b, AssemblyIdPmhnd01230bClassName, out errMessage);
            // メーカー品番パターン制御部品アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b1, AssemblyIdPmhnd01230bMethodName1, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                return StatusError;
            }

            // パターン検索処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b1, AssemblyIdPmhnd01230bMethodName1, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01230b1), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[3];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                paramTypes[2] = typeof(object).MakeByRefType();
                // パターン検索アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01230bMethodName1, paramTypes);

                // 処理実行
                object[] paramValue = new object[3];
                paramValue[0] = paraHandyStockInfoCondObj;
                paramValue[1] = resultHandyStockInfoListObj;
                paramValue[2] = makerGoodsSerchHisNoObj;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // パターン検索結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // パターン検索取得ステータスが正常の場合、パターン検索取得結果リストを設定します。
                        resultHandyStockInfoListObj = paramValue[1];
                        makerGoodsSerchHisNoObj = paramValue[2];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b1, AssemblyIdPmhnd01230bMethodName1, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b1, AssemblyIdPmhnd01230bMethodName1, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b1, AssemblyIdPmhnd01230bMethodName1, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion

        // ===================================================================================== //
        // 品番検索
        // ===================================================================================== //
        #region 品番検索
        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyStockInfoListObj">検索結果オブジェクト</param>
        /// <param name="makerGoodsSerchHisNoObj">パターン検索履歴通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 品番検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyStockGoodsNo(ref object paraHandyStockInfoCondObj, out object resultHandyStockInfoListObj, out object makerGoodsSerchHisNoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyStockInfoListObj = null;
            makerGoodsSerchHisNoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01234d, AssemblyIdPmhnd01234dClassName, out errMessage);
            // パターン検索取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01234d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockInfoCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockInfoCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockInfoCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01230b, AssemblyIdPmhnd01230bClassName, out errMessage);
            // メーカー品番パターン制御部品アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b2, AssemblyIdPmhnd01230bMethodName2, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                return StatusError;
            }

            // 品番検索処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b2, AssemblyIdPmhnd01230bMethodName2, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01230b2), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[3];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                paramTypes[2] = typeof(object).MakeByRefType();
                // 品番検索アクセスを起動する。
                System.Reflection.MethodInfo myMethod;
                myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01230bMethodName2, paramTypes);

                // 処理実行
                object[] paramValue = new object[3];
                paramValue[0] = paraHandyStockInfoCondObj;
                paramValue[1] = resultHandyStockInfoListObj;
                paramValue[2] = makerGoodsSerchHisNoObj;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // パターン検索結果がある場合、
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // パターン検索取得ステータスが正常の場合、パターン検索取得結果リストを設定します。
                        resultHandyStockInfoListObj = paramValue[1];
                        makerGoodsSerchHisNoObj = paramValue[2];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b2, AssemblyIdPmhnd01230bMethodName2, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b2, AssemblyIdPmhnd01230bMethodName2, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b2, AssemblyIdPmhnd01230bMethodName2, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion

        // ===================================================================================== //
        // UOE発注データ検索処理
        // ===================================================================================== //
        #region UOE発注データ検索処理
        /// <summary>
        /// UOE発注データ検索処理
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件オブジェクト</param>
        /// <param name="count">戻り件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データ検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int CheckHandyUOEOrder(ref object paraHandyStockInfoCondObj, out object count)
        {
            int status = StatusError;
            count = 0;
            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01234d, AssemblyIdPmhnd01234dClassName1, out errMessage);
            // UOE発注データ検索取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01234d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockInfoCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockInfoCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockInfoCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01230b, AssemblyIdPmhnd01230bClassName, out errMessage);
            // メーカー品番パターン制御部品アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b3, AssemblyIdPmhnd01230bMethodName4, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                return StatusError;
            }

            // UOE発注データ検索処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b3, AssemblyIdPmhnd01230bMethodName4, OperationCodeRead, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01230b3), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // UOE発注データ検索アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01230bMethodName4, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = paraHandyStockInfoCondObj;
                paramValue[1] = count;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // UOE発注データ検索結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // UOE発注データ検索取得ステータスが正常の場合、UOE発注データ検索取得結果リストを設定します。
                        count = paramValue[1];
                    }

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b3, AssemblyIdPmhnd01230bMethodName4, OperationCodeRead, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b3, AssemblyIdPmhnd01230bMethodName4, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b3, AssemblyIdPmhnd01230bMethodName4, OperationCodeRead, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion

        // ===================================================================================== //
        // 在庫登録処理
        // ===================================================================================== //
        #region 在庫登録処理
        /// <summary>
        /// 在庫登録処理
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫登録を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int WriteHandyStock(ref object paraHandyStockInfoCondObj)
        {
            int status = StatusError;

            // インスタンス生成
            string errMessage = string.Empty;

            object condObj = LoadAssembly(AssemblyIdPmhnd01234d, AssemblyIdPmhnd01234dClassName1, out errMessage);
            // 在庫登録処理取得条件オブジェクトがない場合、「-1」を戻ります。
            if (condObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01234d, ErrorMsgAssembly);
                return StatusError;
            }

            Type condType = condObj.GetType();
            // （従業員コードとコンピュータ名）操作履歴ログ用
            string employeeCode = condType.GetProperty(EmployeeCode).GetValue(paraHandyStockInfoCondObj, null).ToString();
            string machineName = condType.GetProperty(MachineName).GetValue(paraHandyStockInfoCondObj, null).ToString();

            // 企業コードを設定します。
            condType.GetProperty(EnterpriseCode).SetValue(paraHandyStockInfoCondObj, StaticEnterpriseCode, null);

            object acsObj = this.LoadAssembly(AssemblyIdPmhnd01230b, AssemblyIdPmhnd01230bClassName, out errMessage);
            // メーカー品番パターン制御部品アクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b4, AssemblyIdPmhnd01230bMethodName3, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                return StatusError;
            }

            // 在庫登録処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b4, AssemblyIdPmhnd01230bMethodName3, OperationCodeInspect, StatusTimeout, String.Format(MessageThreadTimeout, MessageRead, AssemblyNamePmhnd01230b4), employeeCode);
                #endregion
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[1];
                paramTypes[0] = typeof(object).MakeByRefType();
                // 在庫登録処理アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(AssemblyIdPmhnd01230bMethodName3, paramTypes);

                // 処理実行
                object[] paramValue = new object[1];
                paramValue[0] = paraHandyStockInfoCondObj;

                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 在庫登録処理結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b4, AssemblyIdPmhnd01230bMethodName3, OperationCodeInspect, status, GetStatusMessage(status), employeeCode);
                    #endregion

                }
                else
                {
                    #region 操作履歴ログデータの登録
                    this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b4, AssemblyIdPmhnd01230bMethodName3, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                    #endregion
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdPmhnd01230b, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                #region 操作履歴ログデータの登録
                this.WriteOtherHistoryLog(acsObj, LogDataKind.OperationLog, machineName, AssemblyIdPmhnd01230b, AssemblyNamePmhnd01230b4, AssemblyIdPmhnd01230bMethodName3, OperationCodeInspect, StatusError, GetStatusMessage(StatusError), employeeCode);
                #endregion
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdPmhnd01230b, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion

        // ===================================================================================== //
        // メーカーマスタ全検索
        // ===================================================================================== //
        #region メーカーマスタ全検索
        /// <summary>
        /// メーカーマスタ全検索
        /// </summary>
        /// <param name="resultHandyMakerInfoObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタ全検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyMakerList(out object resultHandyMakerInfoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyMakerInfoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object acsObj = this.LoadAssembly(AssemblyIdMakhn09112a, AssemblyIdMakhn09112aClassName, out errMessage);
            // メーカーマスタアクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09112a, ErrorMsgAssembly);
                return StatusError;
            }

            // メーカーマスタ処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // メーカーマスタ全検索処理アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(MasterMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = resultHandyMakerInfoObj;
                paramValue[1] = (object)StaticEnterpriseCode;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // メーカーマスタ全検索処理結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // メーカーマスタ全検索取得ステータスが正常の場合、取得結果リストを設定します。
                        resultHandyMakerInfoObj = paramValue[0];
                    }

                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdMakhn09112a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09112a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // 仕入先マスタ全検索
        // ===================================================================================== //
        #region 仕入先マスタ全検索
        /// <summary>
        /// 仕入先マスタ全検索
        /// </summary>
        /// <param name="resultHandySupplierInfoObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ全検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandySupplierList(out object resultHandySupplierInfoObj)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandySupplierInfoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object acsObj = this.LoadAssembly(AssemblyIdMakhn09022a, AssemblyIdMakhn09022aClassName, out errMessage);
            // 仕入先マスタアクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09022a, ErrorMsgAssembly);
                return StatusError;
            }

            // 仕入先マスタ処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[2];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                // 仕入先マスタ全検索処理アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(MasterMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[2];
                paramValue[0] = resultHandySupplierInfoObj;
                paramValue[1] = (object)StaticEnterpriseCode;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 仕入先マスタ全検索処理結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 仕入先マスタ全検索取得ステータスが正常の場合、取得結果リストを設定します。
                        resultHandySupplierInfoObj = paramValue[0];
                    }
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdMakhn09022a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09022a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion
        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ----------<<<<<
        // --- ADD 2020/04/10 M.KISHI ハンディ仕入れ時在庫登録対応 ---------->>>>>
        // ===================================================================================== //
        // 倉庫名取得
        // ===================================================================================== //
        #region 倉庫名取得
        /// <summary>
        /// 倉庫名取得
        /// </summary>
        /// <param name="resultWarehouseName">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="warehousecode">倉庫コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名を取得する。</br>
        /// <br>Programmer : M.KISHI</br>
        /// <br>Date       : 2020/04/10</br>
        /// </remarks>
        public int SearchHandyWarehouseInfoForStock(out object resultWarehouseName, object enterpriseCode, object warehousecode)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultWarehouseName = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object acsObj = this.LoadAssembly(AssemblyIdMakhn09332a, AssemblyIdMakhn09332aClassName, out errMessage);
            // 倉庫マスタアクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09022a, ErrorMsgAssembly);
                return StatusError;
            }

            // 倉庫マスタ処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[4];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                paramTypes[2] = typeof(object).MakeByRefType();
                paramTypes[3] = typeof(object).MakeByRefType();
                // 倉庫アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(ReadHandyMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[4];
                paramValue[0] = resultWarehouseName;
                paramValue[1] = (object)StaticEnterpriseCode;
                paramValue[2] = (object)string.Empty;
                paramValue[3] = warehousecode;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 倉庫マスタ検索処理結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 倉庫マスタ検索取得ステータスが正常の場合、取得結果リストを設定します。
                        resultWarehouseName = paramValue[0];
                    }
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdMakhn09332a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09332a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }
        // ===================================================================================== //
        // 仕入先情報取得
        // ===================================================================================== //

        #endregion
        #region 仕入先マスタ検索
        /// <summary>
        /// 仕入先マスタ検索
        /// </summary>
        /// <param name="resultHandySupplierInfoObj">検索結果</param>
        /// <param name="paraEnterpriseCode">企業コード</param>
        /// <param name="paraSupplierCode">仕入先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ全検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandySupplierInfo(out object resultHandySupplierInfoObj, string paraEnterpriseCode, int paraSupplierCode)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandySupplierInfoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object acsObj = this.LoadAssembly(AssemblyIdMakhn09022a, AssemblyIdMakhn09022aClassName, out errMessage);
            // 仕入先マスタアクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09022a, ErrorMsgAssembly);
                return StatusError;
            }

            // 仕入先マスタ処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[3];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                paramTypes[2] = typeof(object).MakeByRefType();
                // 仕入先マスタ読込処理アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(ReadHandyMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[3];
                paramValue[0] = resultHandySupplierInfoObj;
                paramValue[1] = (object)StaticEnterpriseCode;
                paramValue[2] = (object)paraSupplierCode;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 仕入先マスタ読み込み処理結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 仕入先マスタ取得ステータスが正常の場合、取得結果リストを設定します。
                        resultHandySupplierInfoObj = paramValue[0];
                    }
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdMakhn09022a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09022a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion
        // ===================================================================================== //
        // メーカー情報取得
        // ===================================================================================== //
        #region メーカー情報検索
        /// <summary>
        /// メーカー情報検索
        /// </summary>
        /// <param name="resultHandyMakerInfoObj">検索結果</param>
        /// <param name="paraEnterpriseCode">企業コード</param>
        /// <param name="paraMakerCd">メーカーコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタ検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyMakerInfo(out object resultHandyMakerInfoObj,string paraEnterpriseCode,int paraMakerCd)
        {
            int status = StatusError;
            // 結果リストの初期化
            resultHandyMakerInfoObj = null;

            // インスタンス生成
            string errMessage = string.Empty;

            object acsObj = this.LoadAssembly(AssemblyIdMakhn09112a, AssemblyIdMakhn09112aClassName, out errMessage);
            // 仕入先マスタアクセスオブジェクトがない場合、「-1」を戻ります。
            if (acsObj == null)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09112a, ErrorMsgAssembly);
                return StatusError;
            }

            // 仕入先マスタ処理実行可能の判断 True:検索実行可 False:実行タイムアウト
            if (!this.GetReadAccessFlg())
            {
                return StatusTimeout;
            }

            // 読込中件数+1
            System.Threading.Interlocked.Increment(ref ReadingCount);

            try
            {
                // メソッド取得
                Type[] paramTypes = new Type[3];
                paramTypes[0] = typeof(object).MakeByRefType();
                paramTypes[1] = typeof(object).MakeByRefType();
                paramTypes[2] = typeof(object).MakeByRefType();
                // 仕入先マスタ全検索処理アクセスを起動する。
                System.Reflection.MethodInfo myMethod = acsObj.GetType().GetMethod(ReadHandyMethodName, paramTypes);

                // 処理実行
                object[] paramValue = new object[3];
                paramValue[0] = resultHandyMakerInfoObj;
                paramValue[1] = (object)StaticEnterpriseCode;
                paramValue[2] = (object)paraMakerCd;
                object retVal = myMethod.Invoke(acsObj, paramValue);

                // 仕入先マスタ全検索処理結果がある場合
                if (retVal != null)
                {
                    status = (int)retVal;

                    if (status == StatusNomal)
                    {
                        // 仕入先マスタ全検索取得ステータスが正常の場合、取得結果リストを設定します。
                        resultHandyMakerInfoObj = paramValue[0];
                    }
                }
                else
                {
                    // エラーメッセージにアセンブリの名前をログ出力します。
                    this.WriteLog(AssemblyIdMakhn09112a, ErrorMsgAssembly);
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージにアセンブリの名前をログ出力します。
                this.WriteLog(AssemblyIdMakhn09112a, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 読込中件数-1
                System.Threading.Interlocked.Decrement(ref ReadingCount);
            }

            return status;
        }

        #endregion
        // --- ADD 2020/04/10 M.KISHI ハンディ仕入れ時在庫登録対応 ----------<<<<<

    }
}
