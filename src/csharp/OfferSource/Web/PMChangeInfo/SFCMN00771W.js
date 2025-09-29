/* Maki Del
DetailSearchExpand = function() {
	var itemCount = 5
	var listItems = new Array( itemCount );
	listItems[ 0 ] = document.all ? document.all[ "search_list_multicast_date"    ] : document.getElementById( "search_list_multicast_date" );
	listItems[ 1 ] = document.all ? document.all[ "search_list_multicast_version" ] : document.getElementById( "search_list_multicast_version" );
	listItems[ 2 ] = document.all ? document.all[ "search_list_multicast_sysdiv"  ] : document.getElementById( "search_list_multicast_sysdiv" );
	listItems[ 3 ] = document.all ? document.all[ "search_list_multicast_pgname"  ] : document.getElementById( "search_list_multicast_pgname" );
	listItems[ 4 ] = document.all ? document.all[ "search_list_multicast_regionnm"] : document.getElementById( "search_list_multicast_regionnm" );

	var detailSearchDisp = document.all ? document.all[ "detailsearch_disp"  ] : document.getElementById( "detailsearch_disp" );
	
	detailSearchDisp.style.display = "none";
	
	for( ix = 0; ix < itemCount; ix++ ) {
		listItems[ ix ].style.display = "block";
	}
}
*/

/* ↓ 2007.12.11 Maki Add */
/* ウインドウロード */
//window.onload = function() {
////    var newMulticast = document.getElementById("newMulticast");
////        newMulticast.onclick =multicastExpand;
////    var newMainte = document.getElementById("newMainte");
////        newMainte.onclick =serverMainteExpand;
////    var printPoint = document.getElementById("printPoint");
////        printPoint.onclick =print_outputExpand;
//}  

/* 新着.NS配信情報展開 */
var multicastExpand = function() {
    var multicast = document.all ? document.all[ "multicast" ] : document.getElementById( "multicast" );

    // 表示切替処理(展開or収納)
    displayChg(multicast);
}

/* 新着 メンテナンス情報 */
var serverMainteExpand = function() {
    var serverMainte = document.all ? document.all[ "serverMainte" ] : document.getElementById( "serverMainte" );

    // 表示切替処理(展開or収納)
    displayChg(serverMainte);
}

/* 新着 印字位置リリース情報 */
var print_outputExpand = function() {
    var print_output = document.all ? document.all[ "printPointInfo" ] : document.getElementById( "printPointInfo" );

    // 表示切替処理(展開or収納)
    displayChg(print_output);
}

/* 新着情報 表示切替処理(展開or収納) */
function displayChg( target ) {
    if( target.style.display == "none" ) {
        target.style.display = "block";
    }
    else {
        target.style.display = "none";
    }
}

/* 変更区分 selectChange Script */
function DtlSearchMcasExpand( dropDownListId ) {
    // ドロップダウンコントロール
    var mcastInfoDivChg =document.all ? document.all[ dropDownListId ] : document.getElementById( dropDownListId );
    if( ! mcastInfoDivChg ) {
		// 取得失敗
		return;
	}
    //初期化 非表示をセット
    displayClear();

    // 変更区分 0:共通の時はセットしない
    if( mcastInfoDivChg.value != "0" ) {
        // 変更区分毎に表示するコントロールをセットする
        var listItems = blockDisplay( mcastInfoDivChg.value );
        var itemCount = listItems.length;
    
        // ▼詳細検索コントロール
        var detailSearchDisp = document.all ? document.all[ "detailsearch_disp"  ] : document.getElementById( "detailsearch_disp" );

        // ▼詳細検索コントロールがある場合(トップページ)
        if(detailSearchDisp != null) {
            // ▼詳細検索が表示されている時は、検索条件を表示しない
            if( detailSearchDisp.style.display == "block" ) {
                for( ix = 0; ix < itemCount; ix++ ) {
                    listItems[ ix ].style.display = "none";
                }
            }
            else{	    
                for( ix = 0; ix < itemCount; ix++ ) {
                    listItems[ ix ].style.display = "block";
                }
            }
        }
        // ▼詳細検索コントロールがない場合(お知らせ検索)
        else {
            for( ix = 0; ix < itemCount; ix++ ) {
                listItems[ ix ].style.display = "block";
            }
        }
    }
}

/* 各変更区分にあった検索項目をセットする */
function blockDisplay( selectIndex ) {
    var itemCount = 0;
    var listItems;

    switch( selectIndex ) {
        //共通
        case "0":
            //初期化
            displayClear();
            itemCount = 0;
            break;
        //プログラム配信
        case "1":
            itemCount = 4
            listItems = new Array( itemCount );
            listItems[ 0 ] = document.all ? document.all[ "search_list_multicast_date"    ] : document.getElementById( "search_list_multicast_date" );
            listItems[ 1 ] = document.all ? document.all[ "search_list_multicast_version" ] : document.getElementById( "search_list_multicast_version" );
            listItems[ 2 ] = document.all ? document.all[ "search_list_multicast_sysdiv"  ] : document.getElementById( "search_list_multicast_sysdiv" );
            listItems[ 3 ] = document.all ? document.all[ "search_list_multicast_pgname"  ] : document.getElementById( "search_list_multicast_pgname" );
            break;
        //サーバーメンテ
        case "2":
            itemCount = 1
            listItems = new Array( itemCount );
            listItems[ 0 ] = document.all ? document.all[ "search_list_mainte_date"         ] : document.getElementById( "search_list_mainte_date" );
            break;
        //印字位置データ
        case "3":
            itemCount = 4
            listItems = new Array( itemCount );
            listItems[ 0 ] = document.all ? document.all[ "search_list_printname"           ] : document.getElementById( "search_list_printname" );
            listItems[ 1 ] = document.all ? document.all[ "search_list_mcast_rereace_date"  ] : document.getElementById( "search_list_mcast_rereace_date" );
            //listItems[ 1 ] = document.all ? document.all[ "search_list_multicast_date"      ] : document.getElementById( "search_list_multicast_date" );
            listItems[ 2 ] = document.all ? document.all[ "search_list_multicast_regionnm"  ] : document.getElementById( "search_list_multicast_regionnm" );
            listItems[ 3 ] = document.all ? document.all[ "search_list_multicast_sysdiv"    ] : document.getElementById( "search_list_multicast_sysdiv" );
            break;
        default:
            //初期化
            displayClear();
            itemCount = 0;
            break;
    }
    return listItems;
}

/* ▼詳細検索をクリックした時のScript */
function detailExpand() {

    // ▼詳細検索
    var detailSearchDisp = document.all ? document.all[ "detailsearch_disp"  ] : document.getElementById( "detailsearch_disp" );
    // ▲簡易検索
    var simpleSearchDisp = document.all ? document.all[ "simplesearch_disp"  ] : document.getElementById( "simplesearch_disp" );
    // 変更区分を特定(登録済クライアントスクリプトで指定)
    var mcastInfoDivList = document.all ? document.all[ ID_MulticastInfoDivCd_dropDownList  ] : document.getElementById( ID_MulticastInfoDivCd_dropDownList );

    // ▼詳細検索を非表示
    detailSearchDisp.style.display = "none";
    // ▲簡易検索を表示
    simpleSearchDisp.style.display = "block";
    
    if( mcastInfoDivList.value =="0" ) {
        return;
    }
    else {
        //detailSearchDisp.style.display = "none";
        
        var listItems = blockDisplay( mcastInfoDivList.value );
        var itemCount = listItems.length;
    
        for ( ix = 0; ix < itemCount; ix++ ) {
            listItems[ ix ].style.display = "block";
        }
    }
}

/* ▲簡易検索をクリックした時のScript */
function simpleExpand() {

    // ▼詳細検索
    var detailSearchDisp = document.all ? document.all[ "detailsearch_disp"  ] : document.getElementById( "detailsearch_disp" );
    // ▲簡易検索
    var simpleSearchDisp = document.all ? document.all[ "simplesearch_disp"  ] : document.getElementById( "simplesearch_disp" );
    // 変更区分を特定(登録済クライアントスクリプトで指定)
    var mcastInfoDivList = document.all ? document.all[ ID_MulticastInfoDivCd_dropDownList  ] : document.getElementById( ID_MulticastInfoDivCd_dropDownList );

    // ▼簡易検索を非表示
    simpleSearchDisp.style.display = "none";
    // ▲詳細検索を表示
    detailSearchDisp.style.display = "block";
    
    displayClear();
//    var listItems = blockDisplay( mcastInfoDivList.value );
//    var itemCount = listItems.length;

//    for ( ix = 0; ix < itemCount; ix++ ) {
//        listItems[ ix ].style.display = "none";
//    }
}

/* 検索条件コントロールを初期化 */
function displayClear() {
    // 表示を初期化
    var itemCount = 8
    var listItems = new Array( itemCount );
    listItems[ 0 ] = document.all ? document.all[ "search_list_multicast_date"      ] : document.getElementById( "search_list_multicast_date" );
    listItems[ 1 ] = document.all ? document.all[ "search_list_multicast_version"   ] : document.getElementById( "search_list_multicast_version" );
    listItems[ 2 ] = document.all ? document.all[ "search_list_multicast_sysdiv"    ] : document.getElementById( "search_list_multicast_sysdiv" );
    listItems[ 3 ] = document.all ? document.all[ "search_list_multicast_pgname"    ] : document.getElementById( "search_list_multicast_pgname" );
    listItems[ 4 ] = document.all ? document.all[ "search_list_multicast_regionnm"  ] : document.getElementById( "search_list_multicast_regionnm" );
    listItems[ 5 ] = document.all ? document.all[ "search_list_printname"           ] : document.getElementById( "search_list_printname" );
    listItems[ 6 ] = document.all ? document.all[ "search_list_mcast_rereace_date"  ] : document.getElementById( "search_list_mcast_rereace_date" );
    listItems[ 7 ] = document.all ? document.all[ "search_list_mainte_date"         ] : document.getElementById( "search_list_mainte_date" );

    for( ix = 0; ix < itemCount; ix++ ) {
        listItems[ ix ].style.display = "none";
    }
}