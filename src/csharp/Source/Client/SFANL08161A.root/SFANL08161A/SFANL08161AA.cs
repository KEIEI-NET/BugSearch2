using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;

using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票印字位置Importアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置Exportのアクセス制御を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.11.08</br>
    /// <br></br>
    /// <br>UpdateNote	: 2008.06.09 22018 鈴木 正臣</br>
    /// <br>             :   PM.NS向け変更。</br>
    /// <br></br>
    /// <br>UpdateNote	: 2009.06.01 22018 鈴木 正臣</br>
    /// <br>             :   区分＝帳票のインポートに対応する為、一部修正。</br>
    /// </remarks>
	public class FrePrtPSetImportAcs
	{
		#region Delegate
		/// <summary>
		/// 自由帳票Exportイベントハンドラ
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <param name="frePrtExport">自由帳票Exportクラス</param>
		/// <remarks>自由帳票印字位置設定がExportされる度に発生します。</remarks>
		public delegate void FrePrtPSetImportEventHandler(int status, string errMsg, FrePrtExport frePrtExport, bool newWrite, List<int> slipKindList );
		#endregion

		#region Event
		/// <summary>自由帳票Exportイベント</summary>
		public event FrePrtPSetImportEventHandler FrePrtPSetImported;
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ☆☆☆ 各種アクセスクラス ☆☆☆
		// --------------------------------------------------------
		// 自由帳票印字位置ローカルアクセスクラス
		private FrePrtPosLocalAcs		_frePrtPosLocalAcs;
		// 自由帳票印字位置アクセスクラス
		private FrePrtPSetAcs			_frePrtPSetAcs;

		// --------------------------------------------------------
		// ☆☆☆ データクラス ☆☆☆
		// --------------------------------------------------------
		// 自由帳票ExportクラスList
		private List<FrePrtExport>		_frePrtExportList;
		//
		private List<PrtItemGrpWork>	_prtItemGrpList;

		// --------------------------------------------------------
		// ☆☆☆ その他ワーク変数 ☆☆☆
		// --------------------------------------------------------
		// エラーメッセージ
		private string					_errorStr;
		// 透かし画像共通制御部品
		private SFANL08235CF			_watermarkCmn;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrePrtPSetImportAcs()
		{
			// 自由帳票印字位置ローカルアクセスクラス
			_frePrtPosLocalAcs	= new FrePrtPosLocalAcs();
			// 自由帳票印字位置アクセスクラス
			_frePrtPSetAcs		= new FrePrtPSetAcs();
		}
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		/// <remarks>読み取り専用</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>自由帳票ExportクラスList</summary>
		public List<FrePrtExport> FrePrtExportList
		{
			get {
				if (_frePrtExportList == null)
					return new List<FrePrtExport>();
				else
					return _frePrtExportList;
			}
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// Exportファイル読込処理
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>ステータス</returns>
		public int ReadExportFile(string filePath)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				if (File.Exists(filePath))
				{
					_frePrtExportList = (List<FrePrtExport>)XmlByteSerializer.Deserialize(filePath, typeof(List<FrePrtExport>));
				}
				else
				{
					_errorStr = "指定したエクスポートファイルが見つかりませんでした。";
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票Export情報読込処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 自由帳票印字位置設定Import処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="directory">Import対象ファイルのディレクトリ</param>
        /// <param name="exchangeDic">帳票ID変換ディクショナリ</param>
		/// <returns>ステータス</returns>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
        //public int Import(string enterpriseCode, string directory)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        public int Import( string enterpriseCode, string directory, Dictionary<string,string> exchangeDic )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
            bool updateFlag;
            List<int> slipPrtKindList = new List<int>();
            ArrayList retList;

            // 伝票印刷設定の取得
            # region [伝票印刷設定の取得]
            SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
            List<SlipPrtSet> existsSlipPrtSetList = new List<SlipPrtSet>();

            if ( slipPrtSetAcs.SearchAllSlipPrtSet( out retList, enterpriseCode ) == 0)
            {
                foreach ( object obj in retList )
                {
                    if ( obj is SlipPrtSet )
                    {
                        existsSlipPrtSetList.Add( obj as SlipPrtSet );
                    }
                }
            }
            # endregion

            // 請求書印刷パターン
            # region [請求書印刷パターン]
            DmdPrtPtnAcs dmdPrtPtnAcs = new DmdPrtPtnAcs();
            List<DmdPrtPtn> existsDmdPrtPtnList = new List<DmdPrtPtn>();

            if ( dmdPrtPtnAcs.SearchAll( out retList, enterpriseCode ) == 0 )
            {
                foreach ( object obj in retList )
                {
                    if ( obj is DmdPrtPtn )
                    {
                        existsDmdPrtPtnList.Add( obj as DmdPrtPtn );
                    }
                }
            }
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD

            try
            {
                // 保存対象を取得
                List<FrePrtExport> targetFrePrtExportList
                    = _frePrtExportList.FindAll(
                        delegate( FrePrtExport frePrtExport )
                        {
                            if ( frePrtExport.ExtractionItdedFlg == 1 )
                                return true;
                            else
                                return false;
                        }
                    );

                if ( targetFrePrtExportList != null && targetFrePrtExportList.Count > 0 )
                {
                    foreach ( FrePrtExport frePrtExport in targetFrePrtExportList )
                    {
                        string errMsg = string.Empty;
                        FrePrtPSet frePrtPSet;
                        List<FrePprECnd> frePprECndList;
                        List<FrePprSrtO> frePprSrtOList;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
                        updateFlag = false;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD

                        try
                        {
                            string filePath = Path.Combine( directory, frePrtExport.ExportDataFilePath );
                            status = _frePrtPosLocalAcs.ReadLocalFrePrtPSet( out frePrtPSet, out frePprECndList, out frePprSrtOList, filePath );
                            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                int userPrtPprIdDerivNo = _frePrtPSetAcs.GetUserPrtPprIdDerivNo( enterpriseCode, frePrtPSet.OutputFormFileName );
                                // 自由帳票印字位置設定
                                frePrtPSet.EnterpriseCode = enterpriseCode;
                                frePrtPSet.UpdateDateTime = DateTime.MinValue;
                                frePrtPSet.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                // 【帳票ＩＤ変換】
                                # region [帳票ＩＤ変換]
                                if ( exchangeDic != null )
                                {
                                    if ( exchangeDic.ContainsKey( frePrtPSet.OutputFormFileName ) )
                                    {
                                        frePrtPSet.OutputFormFileName = exchangeDic[frePrtPSet.OutputFormFileName];
                                    }
                                }
                                # endregion

                                // 【上書き更新対応】
                                # region [上書き更新対応]
                                // ＤＢの既存データ読み込み
                                FrePrtPSet dbFrePrtPSet = new FrePrtPSet();
                                dbFrePrtPSet.EnterpriseCode = enterpriseCode;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                                //dbFrePrtPSet.OutputFormFileName = frePrtExport.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 ADD
                                dbFrePrtPSet.OutputFormFileName = frePrtPSet.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 ADD
                                dbFrePrtPSet.UserPrtPprIdDerivNo = frePrtExport.UserPrtPprIdDerivNo;

                                List<FrePprECnd> dbFrePprECndList;
                                List<FrePprSrtO> dbFrePprSrtOList;
                                
                                int dbStatus = _frePrtPSetAcs.ReadDBFrePrtPSet( ref dbFrePrtPSet, out dbFrePprECndList, out dbFrePprSrtOList );
                                if ( dbStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // 共通ファイルヘッダ書き換え
                                    frePrtPSet.CreateDateTime = dbFrePrtPSet.CreateDateTime;
                                    frePrtPSet.UpdateDateTime = dbFrePrtPSet.UpdateDateTime;
                                    frePrtPSet.EnterpriseCode = dbFrePrtPSet.EnterpriseCode;
                                    frePrtPSet.FileHeaderGuid = dbFrePrtPSet.FileHeaderGuid;
                                    frePrtPSet.UpdEmployeeCode = dbFrePrtPSet.UpdEmployeeCode;
                                    frePrtPSet.UpdAssemblyId1 = dbFrePrtPSet.UpdAssemblyId1;
                                    frePrtPSet.UpdAssemblyId2 = dbFrePrtPSet.UpdAssemblyId2;
                                    frePrtPSet.LogicalDeleteCode = dbFrePrtPSet.LogicalDeleteCode;
                                    // 更新フラグ
                                    updateFlag = true;
                                }
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
                                // 対象伝票種別リスト
                                slipPrtKindList = new List<int>();

                                if ( frePrtExport.PrintPaperUseDivcd == 2 )
                                {
                                    # region [伝票印刷設定]
                                    // 既に登録済みの伝票種別
                                    List<int> existsKindList = new List<int>();
                                    foreach ( SlipPrtSet slipPrtSet in existsSlipPrtSetList )
                                    {
                                        int derivNo;
                                        try
                                        {
                                            derivNo = Int32.Parse( slipPrtSet.SpecialPurpose2 );
                                        }
                                        catch
                                        {
                                            derivNo = 0;
                                        }

                                        if ( slipPrtSet.OutputFormFileName == frePrtPSet.OutputFormFileName &&
                                             derivNo == frePrtPSet.UserPrtPprIdDerivNo )
                                        {
                                            existsKindList.Add( slipPrtSet.SlipPrtKind );
                                        }
                                    }
                                    // 画面のチェック結果から伝票種別を取得（既存の伝票種別は除外する）
                                    switch ( frePrtExport.FreePrtPprSpPrpseCd )
                                    {
                                        case 1:
                                            if ( !existsKindList.Contains( 10 ) ) slipPrtKindList.Add( 10 ); // 見積書
                                            break;
                                        case 15:
                                            if ( !existsKindList.Contains( 150 ) ) slipPrtKindList.Add( 150 ); // 在庫移動伝票
                                            break;
                                        case 16:
                                            if ( !existsKindList.Contains( 160 ) ) slipPrtKindList.Add( 160 ); // ＵＯＥ伝票
                                            break;
                                        case 0:
                                        default:
                                            if ( frePrtExport.SlipKindEntryDiv1 == 1 && !existsKindList.Contains( 140 ) ) slipPrtKindList.Add( 140 ); // 見積伝票
                                            if ( frePrtExport.SlipKindEntryDiv2 == 1 && !existsKindList.Contains( 120 ) ) slipPrtKindList.Add( 120 ); // 受注伝票
                                            if ( frePrtExport.SlipKindEntryDiv3 == 1 && !existsKindList.Contains( 130 ) ) slipPrtKindList.Add( 130 ); // 貸出伝票
                                            if ( frePrtExport.SlipKindEntryDiv4 == 1 && !existsKindList.Contains( 30 ) ) slipPrtKindList.Add( 30 ); // 売上伝票
                                            break;
                                    }
                                    # endregion
                                }
                                else if ( frePrtExport.PrintPaperUseDivcd == 5 )
                                {
                                    # region [請求書印刷パターン]
                                    // 既に登録済みの伝票種別(請求書)
                                    List<int> existsKindList = new List<int>();

                                    foreach ( DmdPrtPtn dmdPrtPtn in existsDmdPrtPtnList )
                                    {
                                        if ( dmdPrtPtn.OutputFormFileName == frePrtPSet.OutputFormFileName )
                                        {
                                            existsKindList.Add( dmdPrtPtn.SlipPrtKind );
                                        }
                                    }

                                    switch ( frePrtExport.FreePrtPprSpPrpseCd )
                                    {
                                        case 50:
                                            // 合計請求書
                                            if ( !existsKindList.Contains( 50 ) ) slipPrtKindList.Add( 50 );
                                            break;
                                        case 60:
                                            // 明細請求書
                                            if ( !existsKindList.Contains( 60 ) ) slipPrtKindList.Add( 60 );
                                            break;
                                        case 70:
                                            // 伝票合計請求書
                                            if ( !existsKindList.Contains( 70 ) ) slipPrtKindList.Add( 70 );
                                            break;
                                        case 80:
                                            // 領収書
                                            if ( !existsKindList.Contains( 80 ) ) slipPrtKindList.Add( 80 );
                                            break;
                                    }
                                    # endregion
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                                //if ( frePprECndList == null ) frePprECndList = new List<FrePprECnd>();
                                //if ( frePprSrtOList == null ) frePprSrtOList = new List<FrePprSrtO>();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 ADD
                                frePprECndList = new List<FrePprECnd>();
                                frePprSrtOList = new List<FrePprSrtO>();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 ADD

                                // ----------------------------------------------------
                                // 他法人登録用に一部データの書き換え
                                // ----------------------------------------------------

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //int userPrtPprIdDerivNo = _frePrtPSetAcs.GetUserPrtPprIdDerivNo(enterpriseCode, frePrtPSet.OutputFormFileName);
                                //// 自由帳票印字位置設定
                                //frePrtPSet.EnterpriseCode = enterpriseCode;
                                //frePrtPSet.UpdateDateTime = DateTime.MinValue;
                                //frePrtPSet.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                                //// 自由帳票抽出条件
                                //foreach ( FrePprECnd frePprECnd in frePprECndList )
                                //{
                                //    frePprECnd.EnterpriseCode = enterpriseCode;
                                //    frePprECnd.UpdateDateTime = DateTime.MinValue;
                                //    frePprECnd.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                //}
                                //// 自由帳票ソート順位
                                //foreach ( FrePprSrtO frePprSrtO in frePprSrtOList )
                                //{
                                //    frePprSrtO.EnterpriseCode = enterpriseCode;
                                //    frePprSrtO.UpdateDateTime = DateTime.MinValue;
                                //    frePprSrtO.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL

                                // ----------------------------------------------------
                                // リモーティング
                                // ----------------------------------------------------
                                // 帳票区分が伝票の場合は伝票印刷設定マスタも同時に登録
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //if ( frePrtExport.PrintPaperUseDivcd == 2 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                if ( frePrtExport.PrintPaperUseDivcd == 2 && slipPrtKindList.Count > 0)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                {
                                    if ( _prtItemGrpList == null )
                                    {
                                        PrtItemGrpAcs prtItemGrpAcs = new PrtItemGrpAcs();
                                        status = prtItemGrpAcs.SearchPrtItemGrpWork( out _prtItemGrpList );
                                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            errMsg = prtItemGrpAcs.ErrorMessage;
                                    }

                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        List<SlipPrtSetWork> slipPrtSetList = FrePrtPSetAcs.CreateSlipPrtSet( slipPrtKindList, frePrtPSet, _prtItemGrpList );

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 DEL
                                        //status = _frePrtPSetAcs.WriteDBFrePrtPSet(ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, slipPrtSetList, true);
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 DEL
                                        status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, slipPrtSetList, new List<DmdPrtPtnWork>(), true );
                                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            errMsg = _frePrtPSetAcs.ErrorMessage;
                                    }
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                                // 帳票区分が請求書の場合は請求書印刷パターン設定も同時に登録
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //else if ( frePrtExport.PrintPaperUseDivcd == 5 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                else if ( frePrtExport.PrintPaperUseDivcd == 5 && slipPrtKindList.Count > 0 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                {
                                    if ( _prtItemGrpList == null )
                                    {
                                        PrtItemGrpAcs prtItemGrpAcs = new PrtItemGrpAcs();
                                        status = prtItemGrpAcs.SearchPrtItemGrpWork( out _prtItemGrpList );
                                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            errMsg = prtItemGrpAcs.ErrorMessage;
                                    }

                                    List<DmdPrtPtnWork> dmdPrtPtnList = FrePrtPSetAcs.CreateDmdPrtPtnList( frePrtPSet, _prtItemGrpList );

                                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, new List<SlipPrtSetWork>(), dmdPrtPtnList, true );
                                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                        errMsg = _frePrtPSetAcs.ErrorMessage;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                    //status = _frePrtPSetAcs.WriteDBFrePrtPSet(ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, true);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, !updateFlag );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                        errMsg = _frePrtPSetAcs.ErrorMessage;
                                }
                            }
                            else
                            {
                                errMsg = _frePrtPosLocalAcs.ErrorMessage;
                            }
                        }
                        catch ( Exception ex )
                        {
                            errMsg = "自由帳票Import処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        finally
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 DEL
                            //this.FrePrtPSetImported(status, errMsg, frePrtExport);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
                            this.FrePrtPSetImported( status, errMsg, frePrtExport, !updateFlag, slipPrtKindList );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "自由帳票Import処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
		#endregion
	}
}
