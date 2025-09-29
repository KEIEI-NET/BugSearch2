using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Broadleaf.Web.UI
{
	/// <summary>
	/// .NS 配信情報一覧表示用テンプレートクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : .NS配信情報の一覧を表示するためのテンプレートクラスです。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.02.20</br>
    /// <br></br>
    /// <br>Note       : マスタ統合によりSFCMN00771WDを合体</br>
    /// <br>Programmer : 23013 牧　将人</br>
    /// <br>Date       : 2007.12.12</br>
	/// </remarks>
	public class SFCMN00771WC : ITemplate
	{
		#region << Constructor >>

		/// <summary>
		/// .NS 配信情報一覧表示用テンプレートクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : .NS 配信情報一覧表示用テンプレートクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public SFCMN00771WC() : this( TemplateMode.Simple )
		{
		}

		/// <summary>
		/// .NS 配信情報一覧表示用テンプレートクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : .NS 配信情報一覧表示用テンプレートクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public SFCMN00771WC( TemplateMode templateMode ) : this( templateMode, 200 )
		{
		}

        /// <summary>
		/// .NS 配信情報一覧表示用テンプレートクラスコンストラクタ
		/// </summary>
		/// <param name="templateMode">テンプレートモード</param>
		/// <param name="maxChangeContents">変更内容最大表示文字数</param>
		/// <remarks>
		/// <br>Note       : .NS 配信情報一覧表示用テンプレートクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public SFCMN00771WC( TemplateMode templateMode, int maxChangeContentsLength )
		{
			this._templateMode            = templateMode;
			this._maxChangeContentsLength = maxChangeContentsLength;
		}

        // 2007.12.12 Maki Add ---------------------------------------------------------------------------------->>>>>
        /// <summary>
        /// お客様へのお知らせ 一覧表示用テンプレートクラスコンストラクタ
        /// </summary>
        /// <param name="templateMode">テンプレートモード</param>
        /// <param name="maxChangeContentsLength">変更内容最大表示文字数</param>
        /// <param name="mcastGidncCntntsCd">変更内容区分</param>
        /// <remarks>
        /// <br>Note       : お客様へのお知らせ 一覧表示用テンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.12</br>
        /// </remarks>
        public SFCMN00771WC(TemplateMode templateMode, int maxChangeContentsLength, int mcastGidncCntntsCd)
        {
            this._templateMode              = templateMode;
            this._maxChangeContentsLength   = maxChangeContentsLength;
            this._mcastGidncCntntsCd        = mcastGidncCntntsCd;
        }

        /// <summary>
        /// お客様へのお知らせ 一覧表示用テンプレートクラスコンストラクタ
        /// </summary>
        /// <param name="templateMode">テンプレートモード</param>
        /// <param name="maxChangeContentsLength">変更内容最大表示文字数</param>
        /// <param name="mcastGidncCntntsCd">変更内容区分</param>
        /// <param name="mcastGidncMainteCd">メンテナンス区分</param>
        /// <remarks>
        /// <br>Note       : お客様へのお知らせ 一覧表示用テンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2008.02.04</br>
        /// </remarks>
        public SFCMN00771WC(TemplateMode templateMode, int maxChangeContentsLength, int mcastGidncCntntsCd, int mcastGidncMainteCd)
        {
            this._templateMode              = templateMode;
            this._maxChangeContentsLength   = maxChangeContentsLength;
            this._mcastGidncCntntsCd        = mcastGidncCntntsCd;
            this._mcastGidncMainteCd        = mcastGidncMainteCd;
        }
        // ------------------------------------------------------------------------------------------------------<<<<<

		#endregion

		#region << TemplateMode 列挙体 >>

		/// <summary>
		/// テンプレートモード列挙体
		/// </summary>
		public enum TemplateMode
		{
			/// <summary>簡易モード</summary>
			Simple, 
			/// <summary>詳細モード</summary>
			Detail
		}

		#endregion

		#region << Private Members >>

		/// <summary>テンプレートモード</summary>
		private TemplateMode _templateMode;

		/// <summary>変更内容最大表示文字数</summary>
		private int          _maxChangeContentsLength = 0;

        // 2007.12.12 Maki Add ------------------------------------------------>>>>>
        /// <summary>案内内容区分</summary>
        /// <br>0:共通 1:プログラム配信 2:サーバーメンテナンス 3:印字位置配信</br>
        private int          _mcastGidncCntntsCd = 0;

        /// <summary>メンテナンス区分</summary>
        /// <br>1:定期メンテ 2:データメンテ 3:緊急メンテ</br>
        private int          _mcastGidncMainteCd = 0;

        /// <summary>サーバーメンテナンス表示Flg</summary>
        private bool         _checkFlg = false;
        // --------------------------------------------------------------------<<<<<

		#endregion

		#region << ITemplate メンバ >>

		/// <summary>
		/// ITemplate.InstantiateIn メソッド
		/// </summary>
		/// <param name="container">インライン テンプレートからインスタンス化されたコントロールを格納する Control オブジェクト。</param>
		/// <remarks>
		/// <br>Note       : 子コントロールとテンプレートが属する Control オブジェクトを定義します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public void InstantiateIn( Control container )
		{
			Literal lc = new Literal();
			lc.DataBinding += new EventHandler( this.Literal_DataBinding );
			container.Controls.Add( lc );
		}

		#endregion

		#region << Private Methods >>
        #region Del
        /*
		/// <summary>
		/// バインドデータHTMLテキスト生成処理
		/// </summary>
		/// <param name="drView">バインドデータ</param>
		/// <returns>HTMLテキスト</returns>
		/// <remarks>
		/// <br>Note       : 指定されたデータの内容を整形し、HTMLとして返します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		private string GenerateDataToHtml( DataRowView drView )
		{
			StringBuilder outputText = new StringBuilder();

			outputText.Append(       "<div class=\"sub_section\">\n" );
            if (this._mcastGidncCntntsCd != 2)
            {
                // 配信バージョン
                outputText.AppendFormat( "<h3>バージョン {0}</h3>\n", ( string )drView[ SFCMN00771WB.ctColumnName_McastGidncVersionCd ] );

                // バージョン内変更内容
                outputText.Append(       "<div class=\"sub_section_contents\">\n" );

                // 配信日
                outputText.Append(       "<dl class=\"multicast_date\">\n" );
                outputText.Append(       "<dt>配信日</dt>\n" );
                outputText.AppendFormat( "<dd>{0}</dd>\n", ( ( DateTime )drView[ SFCMN00771WB.ctColumnName_MulticastDate ] ).ToString( "yyyy/MM/dd" ) );
                outputText.Append( "</dl>\n" );
            }
            else
            {
                // 2007.12.27 Maki Add
                outputText.AppendFormat(    "<h3><a href=\"{0}\">{1}</a></h3>", drView[ SFCMN00771WB.ctColumnName_DetailPageUrl ], drView[ SFCMN00771WB.ctColumnName_McastGidncMainteCd ] );
                outputText.Append(          "<div class=\"sub_section_contents\">\n" );
                outputText.AppendFormat(    "<p class=\"server_mainte_message\">{0}</p>\n", drView[ SFCMN00771WB.ctColumnName_ServerMainteOutputMessage ] );
                if ( this._templateMode == TemplateMode.Detail )
                {
                    outputText.AppendFormat( "<p class=\"server_mainte_message\">{0}</p>\n", drView[ SFCMN00771WB.ctColumnName_Guidance1 ] );
                }
            }
            // ---------------------<<<<<

			// 各連番のデータを出力
			this.GenerateDetailDataToHtml( drView, outputText );

			outputText.Append(       "</div>\n" );
			outputText.Append(       "</div>\n" );

			return outputText.ToString();
		}*/
        #endregion

        /// <summary>
		/// 明細バインドデータHTMLテキスト生成処理
		/// </summary>
		/// <param name="drView">バインドデータ</param>
		/// <returns>HTMLテキスト</returns>
		/// <remarks>
		/// <br>Note       : 指定されたデータの明細データの内容を整形し、HTMLとして返します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.06</br>
		/// </remarks>
		private void GenerateDetailDataToHtml( DataRowView drView, StringBuilder outputText, int mcastGidncCnt )
		{
			// 連番単位のデータを取得
            DataRow[] changeGidncRows = drView.Row.GetChildRows(SFCMN00771WB.ctRelationName_ChangeGidncRoot_ChangeGidnc);

			if( changeGidncRows.Length == 0 ) {
				return;
			}

			outputText.Append(       "<ul class=\"malticast_info\">\n" );

			// 各連番ごとに出力
			foreach( DataRow changeGidncRow in changeGidncRows ) {
				// ----------------------------------------
				// プログラム配信案内明細データの取得

				// 各連番内の明細データを取得
				DataRow[] chgGidncDtRows = changeGidncRow.GetChildRows( SFCMN00771WB.ctRelationName_ChangeGidnc_ChgGidncDt );
				// 変更内容 & 別紙リストを作成
				StringBuilder changeContents = new StringBuilder();
				List<string> anothersheetList = new List<string>();
				foreach( DataRow chgGidncDtRow in chgGidncDtRows ) {
					if( ( chgGidncDtRow[ SFCMN00771WB.ctColumnName_ChangeContents ] != null ) && 
						( chgGidncDtRow[ SFCMN00771WB.ctColumnName_ChangeContents ] != DBNull.Value ) ) {
						string contents = chgGidncDtRow[ SFCMN00771WB.ctColumnName_ChangeContents ] as string;

						// 変更内容がある場合
						if( ! String.IsNullOrEmpty( contents ) ) {
							changeContents.AppendLine( contents );
						}
					}
					if( ( chgGidncDtRow[ SFCMN00771WB.ctColumnName_AnothersheetFileExst ] != null ) && 
						( chgGidncDtRow[ SFCMN00771WB.ctColumnName_AnothersheetFileExst ] != DBNull.Value ) && 
						( ( int )chgGidncDtRow[ SFCMN00771WB.ctColumnName_AnothersheetFileExst ] == 1 ) ) {
						// 別紙がある場合

						string anothersheetFileName = chgGidncDtRow[ SFCMN00771WB.ctColumnName_AnothersheetFileName ] as string;
						if( ! String.IsNullOrEmpty( anothersheetFileName ) ) {
							// 別紙リストに追加
							anothersheetList.Add( anothersheetFileName );
						}
					}
				}

				// ----------------------------------------
                if ( mcastGidncCnt != 2 )
                {
                    // プログラム配信案内データの出力
                    outputText.Append("<li>");
                    // システム
                    outputText.Append(       "<dl class=\"multicast_system_div\">\n" );
                    outputText.Append(       "<dt>システム</dt>\n" );
                    outputText.AppendFormat(       "<dd>{0}/{1}</dd>\n",
                        changeGidncRow[ SFCMN00771WB.ctColumnName_SystemDivNm ],
                        changeGidncRow[ SFCMN00771WB.ctColumnName_McastGidncNewCustmNm ] );
                    outputText.Append(       "</dl>\n" );
                    // 別紙有りありの場合
                    if (anothersheetList.Count > 0 && mcastGidncCnt != 3)
                    {
                        outputText.Append(       "<dl class=\"another_sheet\">\n" );
                        outputText.Append(       "<dt>別紙</dt>\n" );
                        outputText.Append(       "<dd>" );
                        foreach ( string anothersheetFileName in anothersheetList )
                        {
                            outputText.AppendFormat(       "<a href=\"javascript: window.open('{0}');void(0);\" tabindex=\"99\"><img src=\"Images/another_paper_16.png\" alt=\"別紙へ\" /></a>\n", HttpUtility.UrlEncode( anothersheetFileName ) );
                        }
                        outputText.Append(       "</dd>\n" );
                        outputText.Append(       "</dl>\n" );
                    }
                    if (mcastGidncCnt != 3)
                    {
                        // 配信プログラム名称
                        outputText.Append(       "<dl class=\"multicast_pg_name\">\n" );
                        outputText.Append(       "<dt>配信プログラム</dt>\n" );
                        outputText.AppendFormat(       "<dd><a href=\"{0}\" tabindex=\"99\">{1}</a></dd>\n", changeGidncRow[ SFCMN00771WB.ctColumnName_DetailPageUrl ], HttpUtility.HtmlEncode( ( string )changeGidncRow[ SFCMN00771WB.ctColumnName_Guidance1 ] ) );
                        outputText.Append(       "</dl>" );
                    }
                    else
                    {
                        // 帳票名称
                        outputText.Append(       "<dl class=\"multicast_pg_name\">\n" );
                        outputText.Append(       "<dt>帳票名称</dt>\n" );
                        outputText.AppendFormat(       "<dd><a href=\"{0}\" tabindex=\"99\">{1}</a></dd>\n", changeGidncRow[SFCMN00771WB.ctColumnName_DetailPageUrl], HttpUtility.HtmlEncode(
                            (string)changeGidncRow[ SFCMN00771WB.ctColumnName_Guidance1 ] + "  " + ( string )changeGidncRow[ SFCMN00771WB.ctColumnName_Area ] + "版" ) );
                        outputText.Append(       "</dl>" );
                    }

                    // 詳細モードの場合、変更内容を表示する
                    if ((this._templateMode == TemplateMode.Detail) &&
                        (changeContents.Length > 0))
                    {
                        // 最大表示文字数よりも多い場合
                        if (changeContents.Length > this._maxChangeContentsLength)
                        {
                            // 長さをカット
                            changeContents.Length = this._maxChangeContentsLength;
                            // 「続き」文字列を追加
                            changeContents.Append("...");
                        }
                        // HTMLエンコード後改行を<br />タグに変換し出力
                        outputText.AppendFormat(       "<p class=\"change_contents\">{0}</p>\n",
                            HttpUtility.HtmlEncode(changeContents.ToString()).Replace("\r\n", "<br />"));
                    }

                    outputText.Append(       "</li>\n" );
                }
                else
                {
                    // 別紙有りありの場合
                    if ( anothersheetList.Count > 0 )
                    {
                        outputText.Append("<dl class=\"another_sheet\">\n");
                        outputText.Append("<dt>別紙</dt>\n");
                        outputText.Append(       "<dd>" );
                        foreach (string anothersheetFileName in anothersheetList)
                        {
                            outputText.AppendFormat(       "<a href=\"javascript: window.open('{0}');void(0);\" tabindex=\"99\"><img src=\"Images/another_paper_16.png\" alt=\"別紙へ\" /></a>\n", HttpUtility.UrlEncode(anothersheetFileName));
                        }
                        outputText.Append(       "</dd>\n" );
                        outputText.Append(       "</dl>\n");
                    }
                }
			}
			outputText.Append(       "</ul>\n" );
		}

        // 2007.12.12 Maki Add
        /// <summary>
        /// バインドデータHTMLテキスト生成処理
        /// </summary>
        /// <param name="drView">バインドデータ</param>
        /// <returns>HTMLテキスト</returns>
        /// <remarks>
        /// <br>Note       : 指定されたデータの内容を整形し、HTMLとして返します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.12</br>
        /// </remarks>
        private string GenerateDataToHtml( DataRowView drView, string literal_Id )
        {
            bool titleDispflg = false;
            bool dataMainteflg = false;

            StringBuilder outputText = new StringBuilder();

            outputText.Append( "<div class=\"sub_section\">\n" );

            // 変更区分が違えば保持(drViewは変更区分でソートされている)
            if ((this._mcastGidncCntntsCd != Convert.ToInt32(drView.Row.ItemArray.GetValue(0))) && (literal_Id == "MulticastInfo_repeater"))
            {
                this._mcastGidncCntntsCd = Convert.ToInt32(drView.Row.ItemArray.GetValue(0));
                titleDispflg = true;
            }
            // 変更区分が違えば保持(drViewは変更区分でソートされている)
            if (this._mcastGidncCntntsCd == 2 && this._mcastGidncMainteCd != Convert.ToInt32(drView.Row.ItemArray.GetValue(9)))
            {
                this._mcastGidncMainteCd = Convert.ToInt32(drView.Row.ItemArray.GetValue(9));
                dataMainteflg = true;
            }

            switch (Convert.ToInt32(drView.Row.ItemArray.GetValue(0)))
            {
                case 1:
                    if (titleDispflg) {
                        outputText.Append("<h3 class=\"subh3\">プログラム配信</h3>\n");
                        outputText.Append("</div>\n");
                        outputText.Append("<div class=\"sub_section\">\n");
                    }
                    if (literal_Id == "MulticastInfo_repeater")
                    { outputText.Append("<ul class=\"malticast_info\">\n"); }
                    // 配信バージョン
                    outputText.AppendFormat( "<h3>バージョン {0}</h3>\n", ( string )drView[ SFCMN00771WB.ctColumnName_McastGidncVersionCd ] );

                    // バージョン内変更内容
                    outputText.Append( "<div class=\"sub_section_contents\">\n" );

                    // 配信日
                    outputText.Append( "<dl class=\"multicast_date\">\n" );
                    outputText.Append( "<dt>配信日</dt>\n" );
                    outputText.AppendFormat( "<dd>{0}</dd>\n", ( ( DateTime )drView[ SFCMN00771WB.ctColumnName_MulticastDate ] ).ToString( "yyyy/MM/dd" ) );
                    outputText.Append( "</dl>\n" );

                    // 各連番のデータを出力
                    this.GenerateDetailDataToHtml( drView, outputText, 1 );
                    break;
                case 2:
                    if (titleDispflg)
                    {
                        outputText.Append("<h3 class=\"subh3\">サーバーメンテナンス</h3>\n");
                        outputText.Append("</div>\n");
                        outputText.Append("<div class=\"sub_section\">\n");
                    }
                    else if (dataMainteflg)
                    {
                        if (this._mcastGidncMainteCd == 2) { 
                            outputText.Append("<h3 class=\"subh3\">データメンテナンス</h3>\n"); 
                        }
                        else if (!this._checkFlg) { 
                            outputText.Append("<h3 class=\"subh3\">サーバーメンテナンス</h3>\n");
                            this._checkFlg = true;
                        }
                        
                        outputText.Append("</div>\n");
                        outputText.Append("<div class=\"sub_section\">\n");
                    }

                    if (literal_Id == "MulticastInfo_repeater")
                    {
                        outputText.Append("<ul class=\"malticast_info\">\n");
                        outputText.AppendFormat("<h3><a href=\"{0}\" tabindex=\"99\">{1}</a></h3>", drView[SFCMN00771WB.ctColumnName_DetailPageUrl], drView[SFCMN00771WB.ctColumnName_McastGidncMainteNm]);
                    }
                    else if (literal_Id == "NewServerMainteInfo_repeater" && this._mcastGidncMainteCd == 2)
                    {
                        outputText.Append("<ul class=\"malticast_info\">\n");
                        outputText.AppendFormat("<h3><a href=\"{0}\" tabindex=\"99\">メンテナンス詳細</a></h3>", drView[SFCMN00771WB.ctColumnName_DetailPageUrl]);
                    }
                    else if (literal_Id == "NewServerMainteInfo_repeater" && this._mcastGidncMainteCd != 2)
                    {
                        outputText.Append("<ul class=\"malticast_info\">\n");
                        outputText.AppendFormat("<h3><a href=\"{0}\" tabindex=\"99\">{1}</a></h3>", drView[SFCMN00771WB.ctColumnName_DetailPageUrl], drView[SFCMN00771WB.ctColumnName_McastGidncMainteNm]);
                    }
                    else
                    { 
                        outputText.AppendFormat("<h3><a href=\"{0}\" tabindex=\"99\">{1}</a></h3>", drView[SFCMN00771WB.ctColumnName_DetailPageUrl], drView[SFCMN00771WB.ctColumnName_McastGidncMainteNm]); 
                    }
                    
                    outputText.Append( "<div class=\"sub_section_contents\">\n" );
                    outputText.AppendFormat( "<p class=\"server_mainte_message\">{0}</p>\n", drView[ SFCMN00771WB.ctColumnName_ServerMainteOutputMessage ] );
                    if ( this._templateMode == TemplateMode.Detail )
                    {
                        outputText.AppendFormat( "<p class=\"server_mainte_message\">{0}</p>\n", drView[ SFCMN00771WB.ctColumnName_Guidance1 ] );
                    }
                    // 別紙がある場合別紙を出力
                    this.GenerateDetailDataToHtml( drView, outputText, 2 );
                    break;
                //case 3:
                //    if (titleDispflg)
                //    {
                //        outputText.Append("<h3 class=\"subh3\">印字位置リリース</h3>\n");
                //        outputText.Append("</div>\n");
                //        outputText.Append("<div class=\"sub_section\">\n");
                //    }
                //    if (literal_Id == "MulticastInfo_repeater")
                //    { outputText.Append("<ul class=\"malticast_info\">\n"); }

                //    // 配信日
                //    outputText.AppendFormat( "<h3>リリース日 {0}</h3>\n", ( ( DateTime )drView[ SFCMN00771WB.ctColumnName_MulticastDate ] ).ToString( "yyyy/MM/dd" ) );
                //    outputText.Append( "<div class=\"sub_section_contents\">\n" );

                //    // 各連番のデータを出力
                //    this.GenerateDetailDataToHtml( drView, outputText, 3 );

                //    break;
                default:
                    break;
            }

            outputText.Append( "</div>\n" );

            if (literal_Id == "MulticastInfo_repeater" || literal_Id == "NewServerMainteInfo_repeater")
            { outputText.Append("</ul>\n"); }

            outputText.Append("</div>\n");

            return outputText.ToString();
        }
        #endregion

		#region << Control Events >>

		/// <summary>
		/// DataBinding イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : サーバー コントロールがデータ ソースにバインドすると発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		public void Literal_DataBinding( object sender, EventArgs e )
		{
			// イベント発生対象リテラルコントロールを取得
			Literal literal = sender as Literal;
			if( literal == null ) {
				return;
			}

			// 名前付きコンテナを取得
            RepeaterItem container = literal.NamingContainer as RepeaterItem;
            if( container == null ) {
				return;
			}

			// バインドされるデータを取得
			DataRowView drView = container.DataItem as DataRowView;
			if( drView == null ) {
				return;
			}

            string literalId = ((System.Web.UI.Control)(literal)).NamingContainer.BindingContainer.ID;
			// 出力データを作成
            literal.Text = this.GenerateDataToHtml(drView, literalId);
		}

		#endregion
	}
}
