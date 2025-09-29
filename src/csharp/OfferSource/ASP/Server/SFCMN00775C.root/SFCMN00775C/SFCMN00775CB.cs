using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Resources
{
	/// <summary>
	/// .NS 配信案内 定数定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : .NS 配信案内の共通定数定義クラスです。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.07</br>
	/// <br>Update     : 2007.12.06  Kouguchi  新レイアウト対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.19  21024　佐々木 健</br>
    /// <br>           : PMを追加,印字位置リリースを削除</br>
    /// </remarks>
	public class ConstantManagement_NS_MGD
	{
		#region << Constructor >>

		/// <summary>
		/// .NS 配信案内 定数定義クラスコンストラクタ
		/// </summary>
		public ConstantManagement_NS_MGD()
		{
		}

		#endregion



		#region << 配信案内　新規・改良区分 >>

		#region ●配信案内　新規・改良区分

		/// <summary>
		/// 配信案内　新規・改良区分
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public enum McastGidncNewCustmCd : int 
		{
			/// <summary>
			/// 新規追加
			/// </summary>
			NewProgram         = 1,  //0, 
			/// <summary>
			/// 改良
			/// </summary>
			Upgrading          = 2,  //1, 
			/// <summary>
			/// 障害解除
			/// </summary>
			BugFix             = 3,  //2,
		}

		#endregion

		#region ■配信案内　新規・改良区分名称取得処理

		/// <summary>
		/// 配信案内　新規・改良区分名称取得処理
		/// </summary>
		/// <param name="mcastGidncNewCustmCd">配信案内　新規・改良区分</param>
		/// <returns>配信案内　新規・改良区分名称</returns>
		/// <remarks>
		/// <br>Note       : 配信案内　新規・改良区分から配信案内　新規・改良区分名称の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public static string GetMcastGidncNewCustmCdNm( int mcastGidncNewCustmCd )
		{
			string mcastGidncNewCustmCdNm = "";

			switch( mcastGidncNewCustmCd ) {
				// 新規追加
				case ( int )McastGidncNewCustmCd.NewProgram:
				{
					mcastGidncNewCustmCdNm = "新規";
					break;
				}
				// 改良
				case ( int )McastGidncNewCustmCd.Upgrading:
				{
					mcastGidncNewCustmCdNm = "改良";
					break;
				}
				// 障害解除
				case ( int )McastGidncNewCustmCd.BugFix:
				{
					mcastGidncNewCustmCdNm = "障害";
					break;
				}
			}

			return mcastGidncNewCustmCdNm;
		}

		#endregion

		#endregion



		#region << パッケージ区分 >>

		#region ★パッケージ区分

		/// <summary>
		/// パッケージ区分
		/// </summary>
		public class ProductCode
		{
            // 2008.11.19 Del >>>
            ///// <summary>
            ///// 自動車パッケージ
            ///// </summary>
            //public const string SF = "SuperFrontman";
            // 2008.11.19 Del <<<

            // 2008.11.19 Add >>>
            /// <summary>
            /// パーツマン
            /// </summary>
            public const string PM = "Partsman";
            // 2008.11.19 Add <<<

			/// <summary>
			/// パッケージ区分リスト
			/// </summary>
            // 2008.11.19 Update >>>
            //public readonly static string[] ProductCodeList = new string[] { SF };
            public readonly static string[] ProductCodeList = new string[] { PM };
            // 2008.11.19 Update <<<
        }

		#endregion

		#endregion



		#region << システム区分 >>

		#region ●システム区分

		/// <summary>
		/// システム区分
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.11.19  21024　佐々木 健</br>
        /// <br>           : PM用に修正</br>
        /// </remarks>
		public enum SystemDiv : int
		{
			/// <summary>
			/// 共通
			/// </summary>
			Common             = 0, 
        }

		#endregion

		#region ■システム区分名称取得処理

		/// <summary>
		/// システム区分名称取得処理
		/// </summary>
		/// <param name="productCode">パッケージ区分</param>
		/// <param name="systemDivCd">システム区分</param>
		/// <returns>システム区分名称</returns>
		/// <remarks>
		/// <br>Note       : パッケージ区分、システム区分からシステム区分名称の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.11.19  21024　佐々木 健</br>
        /// <br>           : PM用に修正</br>
        /// </remarks>
		public static string GetMulticastSystemDivNm( string productCode, int systemDivCd )
		{
			string systemDivNm = "";

			switch( productCode ) {
                // 2008.11.19 Del <<<
                //case ProductCode.SF:
                //{
                //    switch( systemDivCd ) {
                //        case ( int )SystemDiv.Common:
                //        {
                //            systemDivNm = "共通";
                //            break;
                //        }
                //        case ( int )SystemDiv.SF:
                //        {
                //            systemDivNm = "整備";
                //            break;
                //        }
                //        case ( int )SystemDiv.BK:
                //        {
                //            systemDivNm = "鈑金";
                //            break;
                //        }
                //        case ( int )SystemDiv.CS:
                //        {
                //            systemDivNm = "車販";
                //            break;
                //        }
                //    }
                //    break;
                //}
                // 2008.11.19 Del <<<

                // 2008.11.19 Add >>>
                case ProductCode.PM:
                {
                    switch (systemDivCd)
                    {
                        case (int)SystemDiv.Common:
                            systemDivNm = "共通";
                            break;
                    }
                    break;
                }
                // 2008.11.19 Add <<<
			}

			return systemDivNm;
		}

		#endregion

		#endregion



		#region << 配信案内　メンテ区分 >>

		#region ●配信案内　メンテ区分

		/// <summary>
		/// 配信案内　メンテ区分
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public enum MainteDiv : int 
		{
			/// <summary>
			/// 定期メンテナンス
			/// </summary>
			Periodic           = 1, 
			/// <summary>
			/// データメンテナンス
			/// </summary>
			Data               = 2, 
			/// <summary>
			/// 緊急メンテナンス
			/// </summary>
			Emergency          = 9,
		}

		#endregion

		#region ■配信案内　メンテ区分名称取得処理

		/// <summary>
		/// 配信案内　メンテ区分名称取得処理
		/// </summary>
		/// <param name="mainteDivCd">配信案内　メンテ区分</param>
		/// <returns>配信案内　メンテ区分名称</returns>
		/// <remarks>
		/// <br>Note       : 配信案内　メンテ区分から配信案内　メンテ区分名称の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public static string GetServerMainteDivNm( int mainteDivCd )
		{
			string mainteDivNm = "";

			switch( mainteDivCd ) {
				case ( int )MainteDiv.Periodic:
				{
					mainteDivNm = "定期メンテナンス";
					break;
				}
				case ( int )MainteDiv.Data:
				{
					mainteDivNm = "データメンテナンス";
					break;
				}
				case ( int )MainteDiv.Emergency:
				{
					mainteDivNm = "緊急メンテナンス";
					break;
				}
			}

			return mainteDivNm;
		}

		#endregion

		#endregion



		#region << 配信案内　案内内容区分 >>

		#region ●配信案内　案内内容区分

		/// <summary>
		/// 配信案内　案内内容区分
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027 高口　勝</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public enum McastGidncCntntsCd : int 
		{
			/// <summary>
			/// 共通
			/// </summary>
			Common           = 0, 
			/// <summary>
			/// プログラム配信
			/// </summary>
			PgDelivery       = 1, 
			/// <summary>
			/// サーバーメンテナンス
			/// </summary>
			SvMaintenance    = 2,
            // 2008.11.19 Del >>>
            ///// <summary>
            ///// 印字位置リリース
            ///// </summary>
            //PrPosition       = 3,
            // 2008.11.19 Del <<<
        }

		#endregion

		#region ■配信案内　案内内容区分名称取得処理

		/// <summary>
		/// 配信案内　案内内容区分名称取得処理
		/// </summary>
		/// <param name="mcastGidncCntntsCd">配信案内　案内内容区分</param>
		/// <returns>配信案内　案内内容区分名称</returns>
		/// <remarks>
		/// <br>Note       : 配信案内　案内内容区分から配信案内　案内内容区分名称の取得を行います。</br>
		/// <br>Programmer : 90027 高口　勝</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public static string GetMcastGidncCntntsCdNm( int mcastGidncCntntsCd )
		{
			string mcastGidncCntntsCdNm = "";

			switch( mcastGidncCntntsCd ) {
				case ( int )McastGidncCntntsCd.Common:
				{
					mcastGidncCntntsCdNm = "共通";
					break;
				}
				case ( int )McastGidncCntntsCd.PgDelivery:
				{
					mcastGidncCntntsCdNm = "プログラム配信";
					break;
				}
				case ( int )McastGidncCntntsCd.SvMaintenance:
				{
					mcastGidncCntntsCdNm = "サーバーメンテナンス";
					break;
				}
                // 2008.11.19 Del >>>
                //case ( int )McastGidncCntntsCd.PrPosition:
                //{
                //    mcastGidncCntntsCdNm = "印字位置リリース";
                //    break;
                //}
                // 2008.11.19 Del <<<
        }

			return mcastGidncCntntsCdNm;
		}

		#endregion

		#endregion

    }
}
