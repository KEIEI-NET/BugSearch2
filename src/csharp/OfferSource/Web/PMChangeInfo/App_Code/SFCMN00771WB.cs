using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Broadleaf.Web.UI
{
	/// <summary>
	/// .NS 配信情報・メンテナンス情報テーブルスキーマ設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : .NS 配信情報テーブル・メンテナンス情報テーブルのスキーマの設定を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.02.20</br>
	/// </remarks>
	public class SFCMN00771WB
	{
		#region << Private Constant >>

		#region ■テーブル情報
        #region Del
        /*
		// リレーションシップ名
		/// <summary>プログラム配信案内ルート・プログラム配信案内リレーション</summary>
		public const string ctRelationName_PgMulcasGdRoot_PgMulcasGd    = "PGMULCASGDROOT_PGMULCASGD";
		/// <summary>プログラム配信案内・プログラム配信案内明細リレーション</summary>
		public const string ctRelationName_PgMulcasGd_PgMulcsGdD        = "PGMULCASGD_PGMULCSGDD";

		// プログラム配信案内ルートテーブル
		/// <summary>プログラム配信案内ルートテーブル</summary>
		public const string ctTableName_PgMulcasGdRoot                  = "PGMULCASGDROOT";
        /// <summary>パッケージ区分</summary>
        public const string ctColumnName_ProductCode                    = "PRODUCTCODE";
        /// <summary>配信提供区分</summary>
        public const string ctColumnName_McastOfferDivCd                = "MCASTOFFERDIVCD";
        /// <summary>更新グループコード</summary>
        public const string ctColumnName_UpdateGroupCode                = "UPDATEGROUPCODE";
        /// <summary>企業コード</summary>
        public const string ctColumnName_EnterpriseCode                 = "ENTERPRISECODE";
        /// <summary>配信バージョン</summary>
        public const string ctColumnName_MulticastVersion               = "MULTICASTVERSION";
        /// <summary>配信日</summary>
        public const string ctColumnName_MulticastDate                  = "MULTICASTDATE";
        /// <summary>サポート公開日時</summary>
        public const string ctColumnName_SupportOpenTime                = "SUPPORTOPENTIME";
        /// <summary>ユーザー公開日時</summary>
        public const string ctColumnName_CustomerOpenTime               = "CUSTOMEROPENTIME";

		// プログラム配信案内テーブル
		/// <summary>プログラム配信案内テーブル</summary>
		public const string ctTableName_PgMulcasGd                      = "PGMULCASGD";
		/// <summary>配信連番</summary>
		public const string ctColumnName_MulticastConsNo                = "MULTICASTCONSNO";
		/// <summary>プログラム変更区分</summary>
		public const string ctColumnName_ProgramChgDivCd                = "PROGRAMCHGDIVCD";
		/// <summary>プログラム変更区分名称</summary>
		public const string ctColumnName_ProgramChgDivNm                = "PROGRAMCHGDIVNM";
		/// <summary>配信システム区分</summary>
		public const string ctColumnName_MulticastSystemDivCd           = "MULTICASTSYSTEMDIVCD";
		/// <summary>配信システム区分名称</summary>
		public const string ctColumnName_MulticastSystemDivNm           = "MULTICASTSYSTEMDIVNM";
		/// <summary>配信プログラム名称</summary>
		public const string ctColumnName_MulticastProgramName           = "MULTICASTPROGRAMNAME";

		// プログラム配信案内明細テーブル
		/// <summary>プログラム配信案内明細テーブル</summary>
		public const string ctTableName_PgMulcsGdD                      = "PGMULCSGDD";
		/// <summary>配信サブコード</summary>
		public const string ctColumnName_MulticastSubCode               = "MULTICASTSUBCODE";
		/// <summary>変更内容</summary>
		public const string ctColumnName_ChangeContents                 = "CHANGECONTENTS";
		/// <summary>別紙ファイル有無区分</summary>
		public const string ctColumnName_AnothersheetFileExst           = "ANOTHERSHEETFILEEXST";
		/// <summary>別紙ファイル名</summary>
		public const string ctColumnName_AnothersheetFileName           = "ANOTHERSHEETFILENAME";

		// サーバーメンテナンス情報テーブル
		/// <summary>サーバーメンテナンス情報テーブル</summary>
		public const string ctTableName_SvrMntInfo                      = "SVRMNTINFO";
		/// <summary>サーバーメンテナンス連番</summary>
		public const string ctColumnName_ServerMainteConsNo             = "SERVERMAINTECONSNO";
		/// <summary>サーバーメンテナンス区分</summary>
		public const string ctColumnName_ServerMainteDivCd              = "SERVERMAINTEDIVCD";
		/// <summary>サーバーメンテナンス区分名称</summary>
		public const string ctColumnName_ServerMainteDivNm              = "SERVERMAINTEDIVNM";
		/// <summary>サーバーメンテナンス開始予定日時</summary>
		public const string ctColumnName_ServerMainteStScdl             = "SERVERMAINTESTSCDL";
		/// <summary>サーバーメンテナンス終了予定日時</summary>
		public const string ctColumnName_ServerMainteEdScdl             = "SERVERMAINTEEDSCDL";
		/// <summary>サーバーメンテナンス開始日時</summary>
		public const string ctColumnName_ServerMainteStTime             = "SERVERMAINTESTTIME";
		/// <summary>サーバーメンテナンス終了日時</summary>
		public const string ctColumnName_ServerMainteEdTime             = "SERVERMAINTEEDTIME";
		/// <summary>サーバーメンテナンス内容</summary>
		public const string ctColumnName_ServerMainteCntnts             = "SERVERMAINTECNTNTS";
		/// <summary>サーバーメンテナンス案内文</summary>
		public const string ctColumnName_ServerMainteGidnc              = "SERVERMAINTEGIDNC";
		/// <summary>サーバーメンテナンス出力メッセージ</summary>
		public const string ctColumnName_ServerMainteOutputMessage      = "ServerMainteOutputMessage";

		/// <summary>詳細ページURL</summary>
		public const string ctColumnName_DetailPageUrl                  = "DETAILPAGEURL";
        */
        #endregion

        // 2007.12.06 Maki Add 
		/// <summary>変更案内ルート・変更案内リレーション</summary>
		public const string ctRelationName_ChangeGidncRoot_ChangeGidnc  = "CHANGEGIDNCROOT_CHANGEGIDNC";
		/// <summary>変更案内・変更案内明細リレーション</summary>
		public const string ctRelationName_ChangeGidnc_ChgGidncDt       = "CHANGEGIDNC_CHGGIDNCDT";
        
        // 変更案内ルートテーブル
        /// <summary>変更案内ルートテーブル</summary>
        public const string ctTableName_ChangeGidncRoot                 = "CHANGEGIDNCROOT";
        /// <summary>案内内容区分</summary>
        public const string ctColumnName_McastGidncCntntsCd             = "MCASTGIDNCCNTNTSCD";
        /// <summary>パッケージ区分</summary>
        public const string ctColumnName_ProductCode                    = "PRODUCTCODE";
        /// <summary>配信バージョン</summary>
        public const string ctColumnName_McastGidncVersionCd            = "MCASTGIDNCVERSIONCD";
        /// <summary>配信提供区分</summary>
        public const string ctColumnName_McastOfferDivCd                = "MCASTOFFERDIVCD";
        /// <summary>更新グループコード</summary>
        public const string ctColumnName_UpdateGroupCode                = "UPDATEGROUPCODE";
        /// <summary>企業コード</summary>
        public const string ctColumnName_EnterpriseCode                 = "ENTERPRISECODE";
        /// <summary>配信日</summary>
        public const string ctColumnName_MulticastDate                  = "MULTICASTDATE";
        /// <summary>サポート公開日時</summary>
        public const string ctColumnName_SupportOpenTime                = "SUPPORTOPENTIME";
        /// <summary>ユーザー公開日時</summary>
        public const string ctColumnName_CustomerOpenTime               = "CUSTOMEROPENTIME";

        // 変更案内テーブル
        /// <summary>変更案内テーブル</summary>
        public const string ctTableName_ChangeGidnc                     = "CHANGEGIDNC";
        /// <summary>連番</summary>
        public const string ctColumnName_MulticastConsNo                = "MULTICASTCONSNO";
        /// <summary>メンテナンス予定日時 開始</summary>
        public const string ctColumnName_ServerMainteStScdl             = "SERVERMAINTESTSCDL";
        /// <summary>メンテナンス予定日時 終了</summary>
        public const string ctColumnName_ServerMainteEdScdl             = "SERVERMAINTEEDSCDL";
        /// <summary>メンテナンス日時 開始</summary>
        public const string ctColumnName_ServerMainteStTime             = "SERVERMAINTESTTIME";
        /// <summary>メンテナンス日時 終了</summary>
        public const string ctColumnName_ServerMainteEdTime             = "SERVERMAINTEEDTIME";
        /// <summary>配信案内　新規・改良区分</summary>
        public const string ctColumnName_McastGidncNewCustmCd           = "MCASTGIDNCNEWCUSTMCD";
        /// <summary>配信案内　新規・改良区分名称</summary>
        public const string ctColumnName_McastGidncNewCustmNm           = "MCASTGIDNCNEWCUSTMNM";
        /// <summary>配信案内　メンテ区分</summary>
        public const string ctColumnName_McastGidncMainteCd             = "MCASTGIDNCMAINTECD";
        /// <summary>配信案内　メンテ区分名称</summary>
        public const string ctColumnName_McastGidncMainteNm             = "MCASTGIDNCMAINTENM";
        /// <summary>システム区分</summary>
        public const string ctColumnName_SystemDivCd                    = "SYSTEMDIVCD";
        /// <summary>システム区分名称</summary>
        public const string ctColumnName_SystemDivNm                    = "SYSTEMDIVNM";
        /// <summary>案内文1</summary>
        public const string ctColumnName_Guidance1                      = "GUIDANCE1";
        /// <summary>地域</summary>
        public const string ctColumnName_Area                           = "AREA";
        /// <summary>サーバーメンテナンス出力メッセージ</summary>
        public const string ctColumnName_ServerMainteOutputMessage      = "SERVERMAINTEOUTPUTMESSAGE";
        
        // 変更案内明細テーブル
        /// <summary>変更案内明細テーブル</summary>
        public const string ctTableName_ChgGidncDt                      = "CHGGIDNCDT";
        /// <summary>連番配信サブコード</summary>
        public const string ctColumnName_MulticastSubCode               = "MULTICASTSUBCODE";
        /// <summary>変更内容</summary>
        public const string ctColumnName_ChangeContents                 = "CHANGECONTENTS";
        /// <summary>別紙ファイル有無区分</summary>
        public const string ctColumnName_AnothersheetFileExst           = "ANOTHERSHEETFILEEXST";
        /// <summary>別紙ファイル名</summary>
        public const string ctColumnName_AnothersheetFileName           = "ANOTHERSHEETFILENAME";
        
        /// <summary>詳細ページURL</summary>
		public const string ctColumnName_DetailPageUrl                  = "DETAILPAGEURL";
        
        #endregion

        #endregion

        #region << Private Static Methods >>
        #region Del
        /*
        #region ■プログラム配信案内ルートテーブル・プログラム配信案内テーブルリレーション作成処理

        /// <summary>
		/// プログラム配信案内ルートテーブル・プログラム配信案内テーブルリレーション作成処理
		/// </summary>
		/// <param name="ds">作成対象DataSet</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内ルートテーブルとプログラム配信案内テーブルにリレーションを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		private static void CreatePgMulcasGdRootPgMulcasGdRelation( DataSet ds )
		{
			if( ds == null ) {
				return;
			}

			DataTable dtPgMulcasGdRoot = null;
			DataTable dtPgMulcasGd = null;

			// プログラム配信案内テーブル取得
			if( ds.Tables.Contains( ctTableName_PgMulcasGdRoot ) ) {
				dtPgMulcasGdRoot = ds.Tables[ ctTableName_PgMulcasGdRoot ];
			}
			// プログラム配信案内明細テーブル取得
			if( ds.Tables.Contains( ctTableName_PgMulcasGd ) ) {
				dtPgMulcasGd     = ds.Tables[ ctTableName_PgMulcasGd ];
			}

			// テーブルが作成されていない場合
			if( ( dtPgMulcasGdRoot == null ) || ( dtPgMulcasGd == null ) ) {
				return;
			}

			// 既にリレーションが作成されている場合
			if( ds.Relations.Contains( ctRelationName_PgMulcasGdRoot_PgMulcasGd ) ) {
				return;
			}

			// リレーション作成
			ds.Relations.Add( 
				ctRelationName_PgMulcasGdRoot_PgMulcasGd, 
				new DataColumn[] {
					dtPgMulcasGdRoot.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtPgMulcasGdRoot.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtPgMulcasGdRoot.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtPgMulcasGdRoot.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
					dtPgMulcasGdRoot.Columns[ ctColumnName_MulticastVersion     ]      // 配信バージョン
				}, 
				new DataColumn[] {
					dtPgMulcasGd.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtPgMulcasGd.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtPgMulcasGd.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtPgMulcasGd.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
					dtPgMulcasGd.Columns[ ctColumnName_MulticastVersion     ]      // 配信バージョン
				}, 
				false );
		}

		#endregion

		#region ■プログラム配信案内テーブル・プログラム配信案内明細テーブルリレーション作成処理

		/// <summary>
		/// プログラム配信案内テーブル・プログラム配信案内明細テーブルリレーション作成処理
		/// </summary>
		/// <param name="ds">作成対象DataSet</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内テーブルとプログラム配信案内明細テーブルにリレーションを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		private static void CreatePgMulcasGdPgMulcsGdDRelation( DataSet ds )
		{
			if( ds == null ) {
				return;
			}

			DataTable dtPgMulcasGd = null;
			DataTable dtPgMulcsGdD = null;

			// プログラム配信案内テーブル取得
			if( ds.Tables.Contains( ctTableName_PgMulcasGd ) ) {
				dtPgMulcasGd = ds.Tables[ ctTableName_PgMulcasGd ];
			}
			// プログラム配信案内明細テーブル取得
			if( ds.Tables.Contains( ctTableName_PgMulcsGdD ) ) {
				dtPgMulcsGdD = ds.Tables[ ctTableName_PgMulcsGdD ];
			}

			// テーブルが作成されていない場合
			if( ( dtPgMulcasGd == null ) || ( dtPgMulcsGdD == null ) ) {
				return;
			}

			// 既にリレーションが作成されている場合
			if( ds.Relations.Contains( ctRelationName_PgMulcasGd_PgMulcsGdD ) ) {
				return;
			}

			// リレーション作成
			ds.Relations.Add( 
				ctRelationName_PgMulcasGd_PgMulcsGdD, 
				new DataColumn[] {
					dtPgMulcasGd.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtPgMulcasGd.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtPgMulcasGd.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtPgMulcasGd.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
					dtPgMulcasGd.Columns[ ctColumnName_MulticastVersion     ],     // 配信バージョン
					dtPgMulcasGd.Columns[ ctColumnName_MulticastConsNo      ]      // 配信連番
				}, 
				new DataColumn[] {
					dtPgMulcsGdD.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtPgMulcsGdD.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtPgMulcsGdD.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtPgMulcsGdD.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
					dtPgMulcsGdD.Columns[ ctColumnName_MulticastVersion     ],     // 配信バージョン
					dtPgMulcsGdD.Columns[ ctColumnName_MulticastConsNo      ]      // 配信連番
				}, 
				false );
		}

		#endregion
        */
        #endregion
        // 2007.12.06 Maki Add ----------------------------------------------->>>>> Start
        #region ■変更案内ルートテーブル・変更案内テーブルリレーション作成処理
        /// <summary>
        /// 変更案内ルートテーブル・変更案内テーブルリレーション作成処理
        /// </summary>
        /// <param name="ds">作成対象DataSet</param>
        /// <remarks>
        /// <br>Note       : 変更案内ルートテーブルと変更案内テーブルにリレーションを作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        private static void CreateChangGidncRootChangGidncRelation( DataSet ds )
        {
            if ( ds == null )
            {
                return;
            }

            DataTable dtChangGidncRoot  = null;
            DataTable dtChangGidnc      = null;

            // 変更案内ルートテーブル取得
            if (ds.Tables.Contains( ctTableName_ChangeGidncRoot ) )
            {
                dtChangGidncRoot = ds.Tables[ ctTableName_ChangeGidncRoot ];
            }
            // 変更案内テーブル取得
            if (ds.Tables.Contains( ctTableName_ChangeGidnc ) )
            {
                dtChangGidnc = ds.Tables[ ctTableName_ChangeGidnc ];
            }

            // テーブルが作成されていない場合
            if ( ( dtChangGidncRoot == null ) || ( dtChangGidnc == null ) )
            {
                return;
            }

            // 既にリレーションが作成されている場合
            if ( ds.Relations.Contains( ctRelationName_ChangeGidncRoot_ChangeGidnc ) )
            {
                return;
            }

            // リレーション作成
            ds.Relations.Add(
                ctRelationName_ChangeGidncRoot_ChangeGidnc,
                new DataColumn[] {
					dtChangGidncRoot.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 案内区分
					dtChangGidncRoot.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtChangGidncRoot.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
					dtChangGidncRoot.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtChangGidncRoot.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtChangGidncRoot.Columns[ ctColumnName_EnterpriseCode       ]      // 企業コード
				},
                new DataColumn[] {
					dtChangGidnc.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 案内区分
					dtChangGidnc.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtChangGidnc.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
					dtChangGidnc.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtChangGidnc.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtChangGidnc.Columns[ ctColumnName_EnterpriseCode       ]      // 企業コード
				},
                false );
        }
        #endregion

        #region ■変更案内テーブル・変更案内明細テーブルリレーション作成処理
        /// <summary>
        /// 変更案内テーブル・変更案内明細テーブルリレーション作成処理
        /// </summary>
        /// <param name="ds">作成対象DataSet</param>
        /// <remarks>
        /// <br>Note       : 変更案内テーブルと変更案内明細テーブルにリレーションを作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        private static void CreateChangGidncChgGidncDtRelation( DataSet ds )
        {
            if ( ds == null )
            {
                return;
            }

            DataTable dtChangGidnc = null;
            DataTable dtChgGidncDt = null;

            // プログラム配信案内テーブル取得
            if ( ds.Tables.Contains( ctTableName_ChangeGidnc ) )
            {
                dtChangGidnc = ds.Tables[ ctTableName_ChangeGidnc ];
            }
            // プログラム配信案内明細テーブル取得
            if ( ds.Tables.Contains( ctTableName_ChgGidncDt ) )
            {
                dtChgGidncDt = ds.Tables[ctTableName_ChgGidncDt];
            }

            // テーブルが作成されていない場合
            if ( ( dtChangGidnc == null ) || ( dtChgGidncDt == null ) )
            {
                return;
            }

            // 既にリレーションが作成されている場合
            if ( ds.Relations.Contains( ctRelationName_ChangeGidnc_ChgGidncDt ) )
            {
                return;
            }

            // リレーション作成
            ds.Relations.Add(
                ctRelationName_ChangeGidnc_ChgGidncDt,
                new DataColumn[] {
					dtChangGidnc.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 案内区分
					dtChangGidnc.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtChangGidnc.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
					dtChangGidnc.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtChangGidnc.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtChangGidnc.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
					dtChangGidnc.Columns[ ctColumnName_MulticastConsNo      ]      // 連番
				},
                new DataColumn[] {
					dtChgGidncDt.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 案内区分
					dtChgGidncDt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
					dtChgGidncDt.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
					dtChgGidncDt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
					dtChgGidncDt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
					dtChgGidncDt.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
					dtChgGidncDt.Columns[ ctColumnName_MulticastConsNo      ]      // 配信連番
				},
                false );
        }
        #endregion
        // -------------------------------------------------------------------<<<<< End
		#endregion

		#region << Public Static Methods >>
        #region Del
        /*
		#region ■.NS 配信情報表示用DataSet作成処理

		/// <summary>
		/// プログラム配信案内DataSet作成処理
		/// </summary>
		/// <param name="ds">プログラム配信案内DataSet</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内DataSetを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public static void CreatePgMulcasGdDataSet( ref DataSet ds )
		{
			// DataSet インスタンス生成
			if( ds == null ) {
				ds = new DataSet();
			}

			// プログラム配信案内ルートテーブル作成
			CreatePgMulcasGdRootTable( ds );
			// プログラム配信案内テーブル作成
			CreatePgMulcasGdTable( ds );
			// プログラム配信案内明細テーブル作成
			CreatePgMulcsGdDTable( ds );

			// リレーションシップ作成
			CreatePgMulcasGdRootPgMulcasGdRelation( ds );
			CreatePgMulcasGdPgMulcsGdDRelation( ds );
        }

        #endregion

		#region ■プログラム配信案内ルートテーブル作成処理

		/// <summary>
		/// プログラム配信案内ルートテーブル作成処理
		/// </summary>
		/// <param name="ds">対象DataSet</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内ルートテーブルを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		public static void CreatePgMulcasGdRootTable( DataSet ds )
		{
			if( ds == null ) {
				return;
			}

			if( ds.Tables.Contains( ctTableName_PgMulcasGdRoot ) ) {
				// 既にテーブルが生成済み
				ds.Tables.Clear();
				return;
			}

			DataTable dt = ds.Tables.Add( ctTableName_PgMulcasGdRoot );

			// パッケージ区分
			dt.Columns.Add( ctColumnName_ProductCode         , typeof( string ) );
			dt.Columns[ ctColumnName_ProductCode          ].DefaultValue = String.Empty;
			// 配信提供区分
			dt.Columns.Add( ctColumnName_McastOfferDivCd     , typeof( string ) );
			dt.Columns[ ctColumnName_McastOfferDivCd      ].DefaultValue = String.Empty;
			// 更新グループコード
			dt.Columns.Add( ctColumnName_UpdateGroupCode     , typeof( string ) );
			dt.Columns[ ctColumnName_UpdateGroupCode      ].DefaultValue = String.Empty;
			// 企業コード
			dt.Columns.Add( ctColumnName_EnterpriseCode      , typeof( string ) );
			dt.Columns[ ctColumnName_EnterpriseCode       ].DefaultValue = String.Empty;
			// 配信バージョン
			dt.Columns.Add( ctColumnName_MulticastVersion    , typeof( string ) );
			dt.Columns[ ctColumnName_MulticastVersion     ].DefaultValue = String.Empty;
			// 配信日
			dt.Columns.Add( ctColumnName_MulticastDate       , typeof( DateTime ) );
			dt.Columns[ ctColumnName_MulticastDate        ].DefaultValue = DateTime.MinValue;
			// サポート公開日時
			dt.Columns.Add( ctColumnName_SupportOpenTime     , typeof( DateTime ) );
			dt.Columns[ ctColumnName_SupportOpenTime      ].DefaultValue = DateTime.MinValue;
			// ユーザー公開日時
			dt.Columns.Add( ctColumnName_CustomerOpenTime    , typeof( DateTime ) );
			dt.Columns[ ctColumnName_CustomerOpenTime     ].DefaultValue = DateTime.MinValue;

			// プライマリーキーを設定
			dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
				dt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
				dt.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
				dt.Columns[ ctColumnName_MulticastVersion     ]      // 配信バージョン
			};
		}

		#endregion

		#region ■プログラム配信案内テーブル作成処理

		/// <summary>
		/// プログラム配信案内テーブル作成処理
		/// </summary>
		/// <param name="ds">対象DataSet</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内テーブルを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		public static void CreatePgMulcasGdTable( DataSet ds )
		{
			if( ds == null ) {
				return;
			}

			if( ds.Tables.Contains( ctTableName_PgMulcasGd ) ) {
				// 既にテーブルが生成済み
				ds.Tables.Clear();
				return;
			}

			DataTable dt = ds.Tables.Add( ctTableName_PgMulcasGd );

			// パッケージ区分
			dt.Columns.Add( ctColumnName_ProductCode         , typeof( string ) );
			dt.Columns[ ctColumnName_ProductCode          ].DefaultValue = String.Empty;
			// 配信提供区分
			dt.Columns.Add( ctColumnName_McastOfferDivCd     , typeof( string ) );
			dt.Columns[ ctColumnName_McastOfferDivCd      ].DefaultValue = String.Empty;
			// 更新グループコード
			dt.Columns.Add( ctColumnName_UpdateGroupCode     , typeof( string ) );
			dt.Columns[ ctColumnName_UpdateGroupCode      ].DefaultValue = String.Empty;
			// 企業コード
			dt.Columns.Add( ctColumnName_EnterpriseCode      , typeof( string ) );
			dt.Columns[ ctColumnName_EnterpriseCode       ].DefaultValue = String.Empty;
			// 配信バージョン
			dt.Columns.Add( ctColumnName_MulticastVersion    , typeof( string ) );
			dt.Columns[ ctColumnName_MulticastVersion     ].DefaultValue = String.Empty;
			// 配信連番
			dt.Columns.Add( ctColumnName_MulticastConsNo     , typeof( int ) );
			dt.Columns[ ctColumnName_MulticastConsNo      ].DefaultValue = 0;
			// プログラム変更区分
			dt.Columns.Add( ctColumnName_ProgramChgDivCd     , typeof( int ) );
			dt.Columns[ ctColumnName_ProgramChgDivCd      ].DefaultValue = 0;
			// プログラム変更区分名称
			dt.Columns.Add( ctColumnName_ProgramChgDivNm     , typeof( string ) );
			dt.Columns[ ctColumnName_ProgramChgDivNm      ].DefaultValue = String.Empty;
			// 配信システム区分
			dt.Columns.Add( ctColumnName_MulticastSystemDivCd, typeof( int ) );
			dt.Columns[ ctColumnName_MulticastSystemDivCd ].DefaultValue = 0;
			// 配信システム区分名称
			dt.Columns.Add( ctColumnName_MulticastSystemDivNm, typeof( string ) );
			dt.Columns[ ctColumnName_MulticastSystemDivNm ].DefaultValue = String.Empty;
			// 配信プログラム名称
			dt.Columns.Add( ctColumnName_MulticastProgramName, typeof( string ) );
			dt.Columns[ ctColumnName_MulticastProgramName ].DefaultValue = String.Empty;

			// 詳細ページURL
			dt.Columns.Add( ctColumnName_DetailPageUrl       , typeof( string ) );
			dt.Columns[ ctColumnName_DetailPageUrl        ].DefaultValue = String.Empty;

			// プライマリーキーを設定
			dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
				dt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
				dt.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
				dt.Columns[ ctColumnName_MulticastVersion     ],     // 配信バージョン
				dt.Columns[ ctColumnName_MulticastConsNo      ]      // 配信連番
			};
		}

		#endregion

		#region ■プログラム配信案内明細テーブル作成処理

		/// <summary>
		/// プログラム配信案内明細テーブル作成処理
		/// </summary>
		/// <param name="ds">対象DataSet</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内明細テーブルを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		public static void CreatePgMulcsGdDTable( DataSet ds )
		{
			if( ds == null ) {
				return;
			}

			if( ds.Tables.Contains( ctTableName_PgMulcsGdD ) ) {
				// 既にテーブルが生成済み
				ds.Tables.Clear();
				return;
			}

			DataTable dt = ds.Tables.Add( ctTableName_PgMulcsGdD );

			// パッケージ区分
			dt.Columns.Add( ctColumnName_ProductCode         , typeof( string ) );
			dt.Columns[ ctColumnName_ProductCode          ].DefaultValue = String.Empty;
			// 配信提供区分
			dt.Columns.Add( ctColumnName_McastOfferDivCd     , typeof( string ) );
			dt.Columns[ ctColumnName_McastOfferDivCd      ].DefaultValue = String.Empty;
			// 更新グループコード
			dt.Columns.Add( ctColumnName_UpdateGroupCode     , typeof( string ) );
			dt.Columns[ ctColumnName_UpdateGroupCode      ].DefaultValue = String.Empty;
			// 企業コード
			dt.Columns.Add( ctColumnName_EnterpriseCode      , typeof( string ) );
			dt.Columns[ ctColumnName_EnterpriseCode       ].DefaultValue = String.Empty;
			// 配信バージョン
			dt.Columns.Add( ctColumnName_MulticastVersion    , typeof( string ) );
			dt.Columns[ ctColumnName_MulticastVersion     ].DefaultValue = String.Empty;
			// 配信連番
			dt.Columns.Add( ctColumnName_MulticastConsNo     , typeof( int ) );
			dt.Columns[ ctColumnName_MulticastConsNo      ].DefaultValue = 0;

			// 配信サブコード
			dt.Columns.Add( ctColumnName_MulticastSubCode    , typeof( int ) );
			dt.Columns[ ctColumnName_MulticastSubCode     ].DefaultValue = 0;
			// 変更内容
			dt.Columns.Add( ctColumnName_ChangeContents      , typeof( string ) );
			dt.Columns[ ctColumnName_ChangeContents       ].DefaultValue = String.Empty;
			// 別紙ファイル有無区分
			dt.Columns.Add( ctColumnName_AnothersheetFileExst, typeof( int ) );
			dt.Columns[ ctColumnName_AnothersheetFileExst ].DefaultValue = 0;
			// 別紙ファイル名
			dt.Columns.Add( ctColumnName_AnothersheetFileName, typeof( string ) );
			dt.Columns[ ctColumnName_AnothersheetFileName ].DefaultValue = String.Empty;

			// プライマリーキーを設定
			dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
				dt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
				dt.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
				dt.Columns[ ctColumnName_MulticastVersion     ],     // 配信バージョン
				dt.Columns[ ctColumnName_MulticastConsNo      ],     // 配信連番
				dt.Columns[ ctColumnName_MulticastSubCode     ]      // 配信サブコード
			};
		}

		#endregion

		#region ■サーバーメンテナンス情報DataSet作成処理

		/// <summary>
		/// サーバーメンテナンス情報DataSet作成処理
		/// </summary>
		/// <param name="ds">サーバーメンテナンス情報DataSet</param>
		/// <remarks>
		/// <br>Note       : サーバーメンテナンス情報DataSetを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public static void CreateSvrMntInfoDataSet( ref DataSet ds )
		{
			// DataSet インスタンス生成
			if( ds == null ) {
				ds = new DataSet();
			}

			if( ds.Tables.Contains( ctTableName_SvrMntInfo ) ) {
				// 既にテーブルが生成済み
				ds.Tables.Clear();
				return;
			}

			DataTable dt = ds.Tables.Add( ctTableName_SvrMntInfo );

			// パッケージ区分
			dt.Columns.Add( ctColumnName_ProductCode              , typeof( string ) );
			dt.Columns[ ctColumnName_ProductCode               ].DefaultValue = String.Empty;
			// サーバーメンテナンス連番
			dt.Columns.Add( ctColumnName_ServerMainteConsNo       , typeof( int ) );
			dt.Columns[ ctColumnName_ServerMainteConsNo        ].DefaultValue = 0;
			// サーバーメンテナンス区分
			dt.Columns.Add( ctColumnName_ServerMainteDivCd        , typeof( int ) );
			dt.Columns[ ctColumnName_ServerMainteDivCd         ].DefaultValue = 0;
			// サーバーメンテナンス区分名称
			dt.Columns.Add( ctColumnName_ServerMainteDivNm        , typeof( string ) );
			dt.Columns[ ctColumnName_ServerMainteDivNm         ].DefaultValue = String.Empty;
			// サーバーメンテナンス開始予定日時
			dt.Columns.Add( ctColumnName_ServerMainteStScdl       , typeof( DateTime ) );
			dt.Columns[ ctColumnName_ServerMainteStScdl        ].DefaultValue = DateTime.MinValue;
			// サーバーメンテナンス終了予定日時
			dt.Columns.Add( ctColumnName_ServerMainteEdScdl       , typeof( DateTime ) );
			dt.Columns[ ctColumnName_ServerMainteEdScdl        ].DefaultValue = DateTime.MinValue;
			// サーバーメンテナンス開始日時
			dt.Columns.Add( ctColumnName_ServerMainteStTime       , typeof( DateTime ) );
			dt.Columns[ ctColumnName_ServerMainteStTime        ].DefaultValue = DateTime.MinValue;
			// サーバーメンテナンス終了日時
			dt.Columns.Add( ctColumnName_ServerMainteEdTime       , typeof( DateTime ) );
			dt.Columns[ ctColumnName_ServerMainteEdTime        ].DefaultValue = DateTime.MinValue;
			// サーバーメンテナンス内容
			dt.Columns.Add( ctColumnName_ServerMainteCntnts       , typeof( string ) );
			dt.Columns[ ctColumnName_ServerMainteCntnts        ].DefaultValue = String.Empty;
			// サーバーメンテナンス案内文
			dt.Columns.Add( ctColumnName_ServerMainteGidnc        , typeof( string ) );
			dt.Columns[ ctColumnName_ServerMainteGidnc         ].DefaultValue = String.Empty;
			// サーバーメンテナンス出力メッセージ
			dt.Columns.Add( ctColumnName_ServerMainteOutputMessage, typeof( string ) );
			dt.Columns[ ctColumnName_ServerMainteOutputMessage ].DefaultValue = String.Empty;

			// 詳細ページURL
			dt.Columns.Add( ctColumnName_DetailPageUrl            , typeof( string ) );
			dt.Columns[ ctColumnName_DetailPageUrl             ].DefaultValue = String.Empty;

			dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_ServerMainteConsNo   ]      // サーバーメンテナンス連番
			};
		}

		#endregion
        */
        #endregion
        // 2007.12.06 Maki Add ----------------->>>>> Start
        #region ■変更案内表示用DataSet作成処理
        
        /// <summary>
        /// 変更案内DataSet作成処理
        /// </summary>
        /// <param name="ds">変更案内DataSet</param>
        /// <remarks>
        /// <br>Note       : 変更案内DataSetを作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        public static void CreateChangGidncDataSet( ref DataSet ds )
        {
            // DataSet インスタンス生成
            if ( ds == null )
            {
                ds = new DataSet();
            }

            // 変更案内ルートテーブル作成
            CreateChangGidncRootTable( ds );
            // 変更案内テーブル作成
            CreateChangGidncTable( ds );
            // 変更案内明細テーブル作成
            CreateChgGidncDtTable( ds );

            // リレーションシップ作成
            CreateChangGidncRootChangGidncRelation( ds );
            CreateChangGidncChgGidncDtRelation( ds );
        }
        #endregion

        #region ■変更案内ルートテーブル作成処理
        /// <summary>
        /// 変更案内ルートテーブル作成処理
        /// </summary>
        /// <param name="ds">対象DataSet</param>
        /// <remarks>
        /// <br>Note       : 変更案内ルートテーブルを作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        public static void CreateChangGidncRootTable( DataSet ds )
        {
            if ( ds == null )
            {
                return;
            }

            if ( ds.Tables.Contains( ctTableName_ChangeGidncRoot ) )
            {
                // 既にテーブルが生成済み
                ds.Tables.Clear();
                return;
            }

            DataTable dt = ds.Tables.Add( ctTableName_ChangeGidncRoot );

            // 配信案内 案内内容区分
            dt.Columns.Add( ctColumnName_McastGidncCntntsCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncCntntsCd ].DefaultValue          = String.Empty;
            // パッケージ区分
            dt.Columns.Add( ctColumnName_ProductCode, typeof( string ) );
            dt.Columns[ ctColumnName_ProductCode ].DefaultValue                 = String.Empty;
            // 配信案内 バージョン区分
            dt.Columns.Add( ctColumnName_McastGidncVersionCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncVersionCd ].DefaultValue         = String.Empty;
            // 配信提供区分
            dt.Columns.Add( ctColumnName_McastOfferDivCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastOfferDivCd ].DefaultValue             = String.Empty;
            // 更新グループコード
            dt.Columns.Add( ctColumnName_UpdateGroupCode, typeof( string ) );
            dt.Columns[ ctColumnName_UpdateGroupCode ].DefaultValue             = String.Empty;
            // 企業コード
            dt.Columns.Add( ctColumnName_EnterpriseCode, typeof( string ) );
            dt.Columns[ ctColumnName_EnterpriseCode ].DefaultValue              = String.Empty;
            // 配信日
            dt.Columns.Add( ctColumnName_MulticastDate, typeof( DateTime ) );
            dt.Columns[ ctColumnName_MulticastDate ].DefaultValue               = DateTime.MinValue;
            // サポート公開日時
            dt.Columns.Add( ctColumnName_SupportOpenTime, typeof( DateTime ) );
            dt.Columns[ ctColumnName_SupportOpenTime ].DefaultValue             = DateTime.MinValue;
            // ユーザー公開日時
            dt.Columns.Add( ctColumnName_CustomerOpenTime, typeof( DateTime ) );
            dt.Columns[ ctColumnName_CustomerOpenTime ].DefaultValue            = DateTime.MinValue;
            // 2008.01.07 Maki Add ------------------------------------------------------------>>>>>
            // 配信案内 メンテ区分
            dt.Columns.Add( ctColumnName_McastGidncMainteCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncMainteCd ].DefaultValue          = String.Empty;
            // 配信案内 メンテ区分名称
            dt.Columns.Add( ctColumnName_McastGidncMainteNm, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncMainteNm ].DefaultValue          = String.Empty;
            /// サーバーメンテナンス出力メッセージ
            dt.Columns.Add( ctColumnName_ServerMainteOutputMessage, typeof( string ) );
            dt.Columns[ ctColumnName_ServerMainteOutputMessage ].DefaultValue   = string.Empty;
            // 案内文1 案内区分 1:配信プログラム名称セット 2:サーバーメンテナンス内容セット
            dt.Columns.Add( ctColumnName_Guidance1, typeof( string ) );
            dt.Columns[ ctColumnName_Guidance1 ].DefaultValue                   = String.Empty;
            // 詳細ページURL
            dt.Columns.Add( ctColumnName_DetailPageUrl, typeof( string ) );
            dt.Columns[ ctColumnName_DetailPageUrl ].DefaultValue               = String.Empty;
            // --------------------------------------------------------------------------------<<<<<

            // プライマリーキーを設定
            dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 配信案内 案内内容区分
				dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
				dt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
				dt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
				dt.Columns[ ctColumnName_EnterpriseCode       ]      // 企業コード
			};
        }
        #endregion

        #region ■変更案内テーブル作成処理
        /// <summary>
        /// 変更案内テーブル作成処理
        /// </summary>
        /// <param name="ds">対象DataSet</param>
        /// <remarks>
        /// <br>Note       : 変更案内テーブルを作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        public static void CreateChangGidncTable( DataSet ds )
        {
            if ( ds == null )
            {
                return;
            }

            if ( ds.Tables.Contains( ctTableName_ChangeGidnc ) )
            {
                // 既にテーブルが生成済み
                ds.Tables.Clear();
                return;
            }

            DataTable dt = ds.Tables.Add( ctTableName_ChangeGidnc );

            // 配信案内 案内内容区分
            dt.Columns.Add( ctColumnName_McastGidncCntntsCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncCntntsCd ].DefaultValue          = String.Empty;
            // パッケージ区分
            dt.Columns.Add( ctColumnName_ProductCode, typeof( string ) );
            dt.Columns[ ctColumnName_ProductCode ].DefaultValue                 = String.Empty;
            // 配信案内 バージョン区分
            dt.Columns.Add( ctColumnName_McastGidncVersionCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncVersionCd ].DefaultValue         = String.Empty;
            // 配信提供区分
            dt.Columns.Add( ctColumnName_McastOfferDivCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastOfferDivCd ].DefaultValue             = String.Empty;
            // 更新グループコード
            dt.Columns.Add( ctColumnName_UpdateGroupCode, typeof( string ) );
            dt.Columns[ ctColumnName_UpdateGroupCode ].DefaultValue             = String.Empty;
            // 企業コード
            dt.Columns.Add( ctColumnName_EnterpriseCode, typeof( string ) );
            dt.Columns[ ctColumnName_EnterpriseCode ].DefaultValue              = String.Empty;
            // 連番
            dt.Columns.Add( ctColumnName_MulticastConsNo, typeof( int ) );
            dt.Columns[ ctColumnName_MulticastConsNo ].DefaultValue             = 0;
            // メンテナンス予定日時 開始
            dt.Columns.Add( ctColumnName_ServerMainteStScdl, typeof( DateTime ) );
            dt.Columns[ ctColumnName_ServerMainteStScdl ].DefaultValue          = DateTime.MinValue;
            // メンテナンス予定日時 終了
            dt.Columns.Add( ctColumnName_ServerMainteEdScdl, typeof( DateTime ) );
            dt.Columns[ ctColumnName_ServerMainteEdScdl ].DefaultValue          = DateTime.MinValue;
            // メンテナンス日時 開始
            dt.Columns.Add( ctColumnName_ServerMainteStTime, typeof( DateTime ) );
            dt.Columns[ ctColumnName_ServerMainteStTime ].DefaultValue          = DateTime.MinValue;
            // メンテナンス日時 終了
            dt.Columns.Add( ctColumnName_ServerMainteEdTime, typeof( DateTime ) );
            dt.Columns[ ctColumnName_ServerMainteEdTime ].DefaultValue          = DateTime.MinValue;
            // 配信案内 新規・改良区分
            dt.Columns.Add( ctColumnName_McastGidncNewCustmCd, typeof( int ) );
            dt.Columns[ ctColumnName_McastGidncNewCustmCd ].DefaultValue        = 0;
            // 配信案内 新規・改良区分名称
            dt.Columns.Add( ctColumnName_McastGidncNewCustmNm, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncNewCustmNm ].DefaultValue        = String.Empty;
            // 配信案内 メンテ区分
            dt.Columns.Add( ctColumnName_McastGidncMainteCd, typeof( int ) );
            dt.Columns[ ctColumnName_McastGidncMainteCd ].DefaultValue          = 0;
            // 配信案内 メンテ区分名称
            dt.Columns.Add( ctColumnName_McastGidncMainteNm, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncMainteNm ].DefaultValue          = String.Empty;
            // システム区分
            dt.Columns.Add( ctColumnName_SystemDivCd, typeof( int ) );
            dt.Columns[ ctColumnName_SystemDivCd ].DefaultValue                 = 0;
            // システム区分名称
            dt.Columns.Add( ctColumnName_SystemDivNm, typeof( string ) );
            dt.Columns[ ctColumnName_SystemDivNm ].DefaultValue                 = String.Empty;
            // 案内文1 案内区分 1:配信プログラム名称セット 2:サーバーメンテナンス内容セット
            dt.Columns.Add( ctColumnName_Guidance1, typeof( string ) );
            dt.Columns[ ctColumnName_Guidance1 ].DefaultValue                   = String.Empty;
            // 地域
            dt.Columns.Add( ctColumnName_Area, typeof( string ) );
            dt.Columns[ ctColumnName_Area ].DefaultValue                        = String.Empty;
            /// サーバーメンテナンス出力メッセージ
            dt.Columns.Add( ctColumnName_ServerMainteOutputMessage, typeof( string ) );
            dt.Columns[ ctColumnName_ServerMainteOutputMessage ].DefaultValue   = string.Empty;

            // 詳細ページURL
            dt.Columns.Add( ctColumnName_DetailPageUrl, typeof( string ) );
            dt.Columns[ ctColumnName_DetailPageUrl ].DefaultValue               = String.Empty;

            // プライマリーキーを設定
            dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 配信案内 案内内容区分
                dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
				dt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
				dt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
				dt.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
				dt.Columns[ ctColumnName_MulticastConsNo      ]      // 配信連番
			};
        }
        #endregion

        #region ■変更案内明細テーブル作成処理
        /// <summary>
        /// 変更案内明細テーブル作成処理
        /// </summary>
        /// <param name="ds">対象DataSet</param>
        /// <remarks>
        /// <br>Note       : 変更案内明細テーブルを作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        public static void CreateChgGidncDtTable( DataSet ds )
        {
            if ( ds == null )
            {
                return;
            }

            if ( ds.Tables.Contains( ctTableName_ChgGidncDt ) )
            {
                // 既にテーブルが生成済み
                ds.Tables.Clear();
                return;
            }

            DataTable dt = ds.Tables.Add( ctTableName_ChgGidncDt );

            // 配信案内 案内内容区分
            dt.Columns.Add( ctColumnName_McastGidncCntntsCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncCntntsCd ].DefaultValue      = String.Empty;
            // パッケージ区分
            dt.Columns.Add( ctColumnName_ProductCode, typeof( string ) );
            dt.Columns[ ctColumnName_ProductCode ].DefaultValue             = String.Empty;
            // 配信案内 バージョン区分
            dt.Columns.Add( ctColumnName_McastGidncVersionCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastGidncVersionCd ].DefaultValue     = String.Empty;
            // 配信提供区分
            dt.Columns.Add( ctColumnName_McastOfferDivCd, typeof( string ) );
            dt.Columns[ ctColumnName_McastOfferDivCd ].DefaultValue         = String.Empty;
            // 更新グループコード
            dt.Columns.Add( ctColumnName_UpdateGroupCode, typeof( string ) );
            dt.Columns[ ctColumnName_UpdateGroupCode ].DefaultValue         = String.Empty;
            // 企業コード
            dt.Columns.Add( ctColumnName_EnterpriseCode, typeof( string ) );
            dt.Columns[ ctColumnName_EnterpriseCode ].DefaultValue          = String.Empty;
            // 連番
            dt.Columns.Add( ctColumnName_MulticastConsNo, typeof( int ) );
            dt.Columns[ ctColumnName_MulticastConsNo ].DefaultValue         = 0;

            // 連番サブコード
            dt.Columns.Add( ctColumnName_MulticastSubCode, typeof( int ) );
            dt.Columns[ ctColumnName_MulticastSubCode ].DefaultValue        = 0;
            // 変更内容
            dt.Columns.Add( ctColumnName_ChangeContents, typeof( string ) );
            dt.Columns[ ctColumnName_ChangeContents ].DefaultValue          = String.Empty;
            // 別紙ファイル有無区分
            dt.Columns.Add( ctColumnName_AnothersheetFileExst, typeof( int ) );
            dt.Columns[ ctColumnName_AnothersheetFileExst ].DefaultValue    = 0;
            // 別紙ファイル名
            dt.Columns.Add( ctColumnName_AnothersheetFileName, typeof( string ) );
            dt.Columns[ ctColumnName_AnothersheetFileName ].DefaultValue    = String.Empty;

            // プライマリーキーを設定
            dt.PrimaryKey = new DataColumn[] {
				dt.Columns[ ctColumnName_McastGidncCntntsCd   ],     // 配信案内 案内内容区分
                dt.Columns[ ctColumnName_ProductCode          ],     // パッケージ区分
				dt.Columns[ ctColumnName_McastGidncVersionCd  ],     // 配信案内 バージョン区分
				dt.Columns[ ctColumnName_McastOfferDivCd      ],     // 配信提供区分
				dt.Columns[ ctColumnName_UpdateGroupCode      ],     // 更新グループコード
				dt.Columns[ ctColumnName_EnterpriseCode       ],     // 企業コード
				dt.Columns[ ctColumnName_MulticastConsNo      ],     // 配信連番
				dt.Columns[ ctColumnName_MulticastSubCode     ]      // 配信サブコード
			};
        }
        #endregion
        #endregion
        // -------------------------------------<<<<< End
	}
}
