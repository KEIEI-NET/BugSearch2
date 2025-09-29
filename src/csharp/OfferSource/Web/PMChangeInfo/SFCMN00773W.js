// --------------------------------------------------
// 配信日付入力チェック処理
// --------------------------------------------------
function McasDateTimeValidator( source, arguments )
{
	if( ! source ) {
		// 無効な入力
		arguments.IsValid = false;
		return;
	}

	// 日付入力フォームのオブジェクトを取得
	var objStMulticastDate_textBox           = document.all ? document.all[ ID_StMulticastDate_textBox ] : document.getElementById( ID_StMulticastDate_textBox );
	var objEdMulticastDate_textBox           = document.all ? document.all[ ID_EdMulticastDate_textBox ] : document.getElementById( ID_EdMulticastDate_textBox );

    // 取得に失敗した場合は、無効な入力とする
    if( ( ! objStMulticastDate_textBox ) || ( ! objEdMulticastDate_textBox ) ) {
        // 無効な入力
        arguments.IsValid = false;
        return;
    }
	
	// 入力値を日付に変換
	var stMulticastDate    = new Object();
	var edMulticastDate    = new Object();
	
	stMulticastDate.date       = null;
	edMulticastDate.date       = null;
	stMulticastDate.isEmpty    = true;
	edMulticastDate.isEmpty    = true;

    // 開始日付をチェック
    if( ! GetDateFromString( objStMulticastDate_textBox, stMulticastDate ) ) {
        // 無効な入力
        arguments.IsValid = false;
        // メッセージをセット
        source.innerText = "開始日付が不正です。";
        return;
    }
    // 終了日付をチェック
    if( ! GetDateFromString( objEdMulticastDate_textBox, edMulticastDate ) ) {
        // 無効な入力
        arguments.IsValid = false;
        // メッセージをセット
        source.innerText = "終了日付が不正です。";
        return;
    }
    // 両方の日付が入力されている場合
    if( ( ! stMulticastDate.isEmpty ) && ( ! edMulticastDate.isEmpty ) ) {
        // 日付の範囲をチェック
        if( stMulticastDate.date > edMulticastDate.date ) {
            // 開始日付が終了日付より大きい場合は不正
			
            // 無効な入力
            arguments.IsValid = false;
            // メッセージをセット
            source.innerText = "日付の範囲が不正です。";
            return;
        }
    }
	// 正しい入力	
	arguments.IsValid = true;
}

// --------------------------------------------------
// サーバーメンテ予定日付入力チェック処理
// --------------------------------------------------
function MainteDateTimeValidator( source, arguments )
{
	if( ! source ) {
		// 無効な入力
		arguments.IsValid = false;
		return;
	}

	// サーバーメンテ予定日入力フォームのオブジェクトを取得
	var objStMainteDate_textBox      = document.all ? document.all[ ID_StMainteDate_textBox ] : document.getElementById( ID_StMainteDate_textBox );
	var objEdMainteDate_textBox      = document.all ? document.all[ ID_EdMainteDate_textBox ] : document.getElementById( ID_EdMainteDate_textBox );

    // 取得に失敗した場合は、無効な入力とする
    if( ( ! objStMainteDate_textBox ) || ( ! objEdMainteDate_textBox ) ) {
        // 無効な入力
        arguments.IsValid = false;
        return;
    }
	
	// 入力値を日付に変換
	var stMainteDate       = new Object();
	var edMainteDate       = new Object();
	
	stMainteDate.date          = null;
	edMainteDate.date          = null;
	stMainteDate.isEmpty       = true;
	edMainteDate.isEmpty       = true;

    // 開始サーバーメンテ予定日をチェック
    if( ! GetDateFromString( objStMainteDate_textBox, stMainteDate ) ) {
        // 無効な入力
        arguments.IsValid = false;
        // メッセージをセット
        source.innerText = "開始日付が不正です。";
        return;
    }
    // 終了サーバーメンテ予定日をチェック
    if( ! GetDateFromString( objEdMainteDate_textBox, edMainteDate ) ) {
        // 無効な入力
        arguments.IsValid = false;
        // メッセージをセット
        source.innerText = "終了日付が不正です。";
        return;
    }
	
    // 両方の日付が入力されている場合
    if( ( ! stMainteDate.isEmpty ) && ( ! edMainteDate.isEmpty ) ) {
        // 日付の範囲をチェック
        if( stMainteDate.date > edMainteDate.date ) {
            // 開始日付が終了日付より大きい場合は不正
			
            // 無効な入力
            arguments.IsValid = false;
            // メッセージをセット
            source.innerText = "日付の範囲が不正です。";
            return;
        }
    }
	// 正しい入力	
	arguments.IsValid = true;
}

// --------------------------------------------------
// リリース日付入力チェック処理
// --------------------------------------------------
function McasReDateTimeValidator( source, arguments )
{
	if( ! source ) {
		// 無効な入力
		arguments.IsValid = false;
		return;
	}

	// リリース日付入力フォームのオブジェクトを取得
	var objStMcastRereaceDate_textBox        = document.all ? document.all[ ID_StMcastRereaceDate_textBox ] : document.getElementById( ID_StMcastRereaceDate_textBox );
	var objEdMcastRereaceDate_textBox        = document.all ? document.all[ ID_EdMcastRereaceDate_textBox ] : document.getElementById( ID_EdMcastRereaceDate_textBox );

    // 取得に失敗した場合は、無効な入力とする
    if( ( ! objStMcastRereaceDate_textBox ) || ( ! objEdMcastRereaceDate_textBox ) ) {
        // 無効な入力
        arguments.IsValid = false;
        return;
    }
	
	// 入力値を日付に変換
	var stMcastRereaceDate = new Object();
	var edMcastRereaceDate = new Object();

	stMcastRereaceDate.date    = null;
	edMcastRereaceDate.date    = null;
	stMcastRereaceDate.isEmpty = true;
	edMcastRereaceDate.isEmpty = true;

    // 開始リリース日をチェック
    if( ! GetDateFromString( objStMcastRereaceDate_textBox, stMcastRereaceDate ) ) {
        // 無効な入力
        arguments.IsValid = false;
        // メッセージをセット
        source.innerText = "開始日付が不正です。";
        return;
    }
    // 終了リリース日をチェック
    if( ! GetDateFromString( objEdMcastRereaceDate_textBox, edMcastRereaceDate ) ) {
        // 無効な入力
        arguments.IsValid = false;
        // メッセージをセット
        source.innerText = "終了日付が不正です。";
        return;
    }
	
    // 両方の日付が入力されている場合
    if( ( ! stMcastRereaceDate.isEmpty ) && ( ! edMcastRereaceDate.isEmpty ) ) {
        // 日付の範囲をチェック
        if( stMcastRereaceDate.date > edMcastRereaceDate.date ) {
            // 開始日付が終了日付より大きい場合は不正
			
            // 無効な入力
            arguments.IsValid = false;
            // メッセージをセット
            source.innerText = "日付の範囲が不正です。";
            return;
        }
    }
	// 正しい入力	
	arguments.IsValid = true;
}

// --------------------------------------------------
/* 日付取得 */
function GetDateFromString( dateForm, dateObj )
{
	var result = false;
	
	var year  = 0;
	var month = 0;
	var day   = 0;
	
	var dateStringArray = null;
	
	var dateString = dateForm.value;
	
	// 入力されていない場合
	if( ( dateString === "" ) || 
		( dateString.match( /^[ 　\t]+$/ ) ) ) {
		dateObj.isEmpty = true;
		result = true;
		return result;
	}
	
	// 入力値が不正
	if( ! dateString ) {
		// 無効な入力
		return result;
	}
	// 正規表現で入力をチェック
	// yyyy/mm/dd
	if( dateString.match( /^[ 　\t]*[0-9]{4}\/([0-9]|0[0-9]|1[0-2])\/([0-9]|0[0-9]|1[0-9]|2[0-9]|3[0-1])[ 　\t]*$/) ) {
		// 入力値を分解
		dateStringArray = dateString.split( "/" );
	}
	// yyyy.mm.dd
	else if( dateString.match(/^[ 　\t]*[0-9]{4}\.([0-9]|0[0-9]|1[0-2])\.([0-9]|0[0-9]|1[0-9]|2[0-9]|3[0-1])[ 　\t]*$/) ) {
		// 入力値を分解
		dateStringArray = dateString.split( "." );
	}
	// yyyymmdd
	else if( dateString.match(/^[ 　\t]*[0-9]{4}(0[0-9]|1[0-2])(0[0-9]|1[0-9]|2[0-9]|3[0-1])[ 　\t]*$/) ) {
		// 入力値を分解
		dateStringArray      = new Array( 3 );
		dateStringArray[ 0 ] = dateString.substr( 0, 4 );
		dateStringArray[ 1 ] = dateString.substr( 4, 2 );
		dateStringArray[ 2 ] = dateString.substr( 6, 2 );
	}
	// その他無効な入力
	else {
		// 無効な入力
		return result;
	}
	
	if( dateStringArray ) {
		// 数値に変換	
		try {
			year  = parseInt( dateStringArray[ 0 ], 10 );
			month = parseInt( dateStringArray[ 1 ], 10 );
			day   = parseInt( dateStringArray[ 2 ], 10 );
		}
		catch( e ) {
			// 無効な入力
			return result;
		}
	}
	else {
		// 無効な入力
		return result;
	}
	
	// --------------------------------------------------
	// 不正な入力ではないか?
	if( ( isNaN( year ) ) || ( isNaN( month ) ) || ( isNaN( day ) ) ) {
		// 無効な入力
		return result;
	}
	
	// --------------------------------------------------
	// 開始配信日付の各項目のチェック
	// 開始配信日付(年)の判定
	if( year < 1900 ) {
		// 無効な入力
		return result;
	}
	// 開始配信日付(月)の判定
	if( ( month < 1 ) || ( month > 12 ) ) {
		// 無効な入力
		return result;
	}
	// 開始配信日付(日)の判定
	// 指定の年月を取得
	var stMonth = new Date( year, month - 1, 1 );
	if( stMonth == null ) {
		// 無効な入力
		return result;
	}
	// 次の月を取得
	var stMonthNext = new Date( ( month < 12 ? year : year - 0 + 1 ), ( month < 12 ? month : 0 ), 1 );
	if( stMonthNext == null ) {
		// 無効な入力
		return result;
	}
	// 日数を取得
	var stDateCount = Math.floor( ( stMonthNext.getTime() - stMonth.getTime() ) / ( 1000 * 60 * 60 * 24 ) );
	// 範囲をチェック
	if( ( day < 1 ) || ( day > stDateCount ) ) {
		// 無効な入力
		return result;
	}
	
	// 日付オブジェクトを取得
	try {
		dateObj.date    = new Date( year, month - 1, day );
		dateObj.isEmpty = false;
	}
	catch( e ) {
		// 無効な入力
		return result;
	}
	
	dateForm.value = 
		String( dateObj.date.getFullYear() ) + "/" + 
		String( dateObj.date.getMonth() + 1 ).PadLeft( 2, "0" ) + "/" + 
		String( dateObj.date.getDate() ).PadLeft( 2, "0" );

	result = true;	
	// 結果を返す
	return result;
}

// --------------------------------------------------
// 配信バージョン入力チェック処理
// --------------------------------------------------
function VersionValidator( source, arguments )
{
	if( ! source ) {
		// 無効な入力
		arguments.IsValid = false;
		return;
	}
	
	// バージョン入力フォームのオブジェクトを取得
	var objStMulticastVersion_textBox        = document.all ? document.all[ ID_StMulticastVersion_textBox ] : document.getElementById( ID_StMulticastVersion_textBox );
	var objEdMulticastVersion_textBox        = document.all ? document.all[ ID_EdMulticastVersion_textBox ] : document.getElementById( ID_EdMulticastVersion_textBox );
	
	// 取得に失敗した場合は、無効な入力とする
	if( ( ! objStMulticastVersion_textBox ) || ( ! objEdMulticastVersion_textBox ) ) {
		// 無効な入力
		arguments.IsValid = false;
		return;
	}
	
	// 入力値をバージョン情報に変換
	var stMulticastVersion = new Object();
	var edMulticastVersion = new Object();
	
	stMulticastVersion.major    = 0;
	stMulticastVersion.minor    = 0;
	stMulticastVersion.build    = 0;
	stMulticastVersion.revision = 0;
	
	edMulticastVersion.major    = 0;
	edMulticastVersion.minor    = 0;
	edMulticastVersion.build    = 0;
	edMulticastVersion.revision = 0;
	
	stMulticastVersion.isEmpty = true;
	edMulticastVersion.isEmpty = true;

	// 開始バージョンをチェック
	if( ! GetVersionFromString( objStMulticastVersion_textBox, stMulticastVersion ) ) {
		// 無効な入力
		arguments.IsValid = false;
		// メッセージをセット
		source.innerText = "開始バージョンが不正です。";
		return;
	}
	// 終了バージョンをチェック
	if( ! GetVersionFromString( objEdMulticastVersion_textBox, edMulticastVersion ) ) {
		// 無効な入力
		arguments.IsValid = false;
		// メッセージをセット
		source.innerText = "終了バージョンが不正です。";
		return;
	}
	
	// 両方のバージョンが入力されている場合
	if( ( ! stMulticastVersion.isEmpty ) && ( ! edMulticastVersion.isEmpty ) ) {
		// バージョンの範囲をチェック
		
		if( stMulticastVersion.major > edMulticastVersion.major ) {
			// 開始バージョンが終了バージョンより大きい場合は不正
			
			// 無効な入力
			arguments.IsValid = false;
			// メッセージをセット
			source.innerText = "バージョンの範囲が不正です。";
			return;
		}
		
		if( stMulticastVersion.minor > edMulticastVersion.minor ) {
			// 開始バージョンが終了バージョンより大きい場合は不正
			
			// 無効な入力
			arguments.IsValid = false;
			// メッセージをセット
			source.innerText = "バージョンの範囲が不正です。";
			return;
		}
		
		if( stMulticastVersion.build > edMulticastVersion.build ) {
			// 開始バージョンが終了バージョンより大きい場合は不正
			
			// 無効な入力
			arguments.IsValid = false;
			// メッセージをセット
			source.innerText = "バージョンの範囲が不正です。";
			return;
		}
		
		if( stMulticastVersion.revision > edMulticastVersion.revision ) {
			// 開始バージョンが終了バージョンより大きい場合は不正
			
			// 無効な入力
			arguments.IsValid = false;
			// メッセージをセット
			source.innerText = "バージョンの範囲が不正です。";
			return;
		}
	}

	// 正しい入力	
	arguments.IsValid = true;
}

// --------------------------------------------------
/* バージョン取得 */
function GetVersionFromString( versionForm, versionObj )
{
	var result = false;

	var versionStringArray = null;
	
	var versionString = versionForm.value;
	
	// 入力されていない場合
	if( ( versionString === "" ) || 
		( versionString.match( /^[ 　\t]+$/ ) ) ) {
		versionObj.isEmpty = true;
		result = true;
		return result;
	}
	
	// 入力値が不正
	if( ! versionString ) {
		// 無効な入力
		return result;
	}
	
	// 正規表現で入力をチェック
	// xxxxx.xxxxx.xxxxx.xxxxx
	if( ! versionString.match( /^[ 　\t]*[0-9]{1,5}\.[0-9]{1,5}\.[0-9]{1,5}\.[0-9]{1,5}[ 　\t]*$/ ) ) {
		// 無効な入力
		return result;
	}
	
	// 入力値を分解
	versionStringArray = versionString.split( "." );
	
	if( versionStringArray ) {
		// 数値に変換
		try {
			versionObj.major    = parseInt( versionStringArray[ 0 ], 10 );
			versionObj.minor    = parseInt( versionStringArray[ 1 ], 10 );
			versionObj.build    = parseInt( versionStringArray[ 2 ], 10 );
			versionObj.revision = parseInt( versionStringArray[ 3 ], 10 );
			versionObj.isEmpty  = false;
		}
		catch( e ) {
			// 無効な入力
			return result;
		}
	}
	else {
		// 無効な入力
		return result;
	}
	
	versionForm.value = 
		String( versionObj.major ) + "." + 
		String( versionObj.minor ) + "." + 
		String( versionObj.build ) + "." + 
		String( versionObj.revision );
	
	result = true;	
	// 結果を返す
	return result;
}

// --------------------------------------------------
// 条件未入力チェック処理
// --------------------------------------------------
function EmptyValidator( source, arguments )
{
	var isValid = false
	var objChangeContents_textBox            = document.all ? document.all[ ID_ChangeContents_textBox ] : document.getElementById( ID_ChangeContents_textBox );
	var objStMulticastDate_textBox           = document.all ? document.all[ ID_StMulticastDate_textBox ] : document.getElementById( ID_StMulticastDate_textBox );
	var objEdMulticastDate_textBox           = document.all ? document.all[ ID_EdMulticastDate_textBox ] : document.getElementById( ID_EdMulticastDate_textBox );
	var objStMulticastVersion_textBox        = document.all ? document.all[ ID_StMulticastVersion_textBox ] : document.getElementById( ID_StMulticastVersion_textBox );
	var objEdMulticastVersion_textBox        = document.all ? document.all[ ID_EdMulticastVersion_textBox ] : document.getElementById( ID_EdMulticastVersion_textBox );
	var objMulticastSystemDivCd_dropDownList = document.all ? document.all[ ID_MulticastSystemDivCd_dropDownList ] : document.getElementById( ID_MulticastSystemDivCd_dropDownList );
	var objMulticastProgramName_textBox      = document.all ? document.all[ ID_MulticastProgramName_textBox ] : document.getElementById( ID_MulticastProgramName_textBox );
	// 2007.12.19 Maki Add ---------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
	var objMulticastInfoDivCd_dropDownList   = document.all ? document.all[ ID_MulticastInfoDivCd_dropDownList ] : document.getElementById( ID_MulticastInfoDivCd_dropDownList );
	var objArea_textBox                      = document.all ? document.all[ ID_Area_textBox ] : document.getElementById( ID_Area_textBox );
	var objPrintName_textBox                 = document.all ? document.all[ ID_PrintName_textBox ] : document.getElementById( ID_PrintName_textBox );
	var objStMcastRereaceDate_textBox        = document.all ? document.all[ ID_StMcastRereaceDate_textBox ] : document.getElementById( ID_StMcastRereaceDate_textBox );
	var objEdMcastRereaceDate_textBox        = document.all ? document.all[ ID_EdMcastRereaceDate_textBox ] : document.getElementById( ID_EdMcastRereaceDate_textBox );
	var objStMainteDate_textBox              = document.all ? document.all[ ID_StMainteDate_textBox ] : document.getElementById( ID_StMainteDate_textBox );
	var objEdMainteDate_textBox              = document.all ? document.all[ ID_EdMainteDate_textBox ] : document.getElementById( ID_EdMainteDate_textBox );
	// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

    // 変更内容
	if( ( ! isValid ) && 
		( objChangeContents_textBox ) && 
		( objChangeContents_textBox.value !== "" ) && 
		( ! objChangeContents_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
		isValid = true
	}
//    // 配信日 開始
//    if( ( ! isValid ) && 
//        ( objStMulticastDate_textBox ) && 
//        ( objStMulticastDate_textBox.value !== "" ) && 
//        ( ! objStMulticastDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
//        isValid = true
//    }
//    // 配信日 終了
//    if( ( ! isValid ) && 
//        ( objEdMulticastDate_textBox ) && 
//        ( objEdMulticastDate_textBox.value !== "" ) && 
//        ( ! objEdMulticastDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
//        isValid = true
//    }

	if ( objMulticastInfoDivCd_dropDownList ) {
	    switch( objMulticastInfoDivCd_dropDownList.value ) {
	        case "1":
                // 配信日 開始
                if( ( ! isValid ) && 
                    ( objStMulticastDate_textBox ) && 
                    ( objStMulticastDate_textBox.value !== "" ) && 
                    ( ! objStMulticastDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
                    isValid = true
                }
                // 配信日 終了
                if( ( ! isValid ) && 
                    ( objEdMulticastDate_textBox ) && 
                    ( objEdMulticastDate_textBox.value !== "" ) && 
                    ( ! objEdMulticastDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
                    isValid = true
                }
	            // バージョン 開始
                if( ( ! isValid ) && 
	                ( objStMulticastVersion_textBox ) && 
	                ( objStMulticastVersion_textBox.value !== "" ) && 
	                ( ! objStMulticastVersion_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
	                isValid = true
                }
	            // バージョン 終了
                if( ( ! isValid ) && 
	                ( objEdMulticastVersion_textBox ) && 
	                ( objEdMulticastVersion_textBox.value !== "" ) && 
	                ( ! objEdMulticastVersion_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
	                isValid = true
                }
    	        // システム区分
                if( ( objMulticastSystemDivCd_dropDownList ) && 
	                ( objMulticastSystemDivCd_dropDownList.selectedIndex > 0 ) ) {
	                isValid = true
                }
    	        // プログラム名称
                if( ( ! isValid ) && 
	                ( objMulticastProgramName_textBox ) && 
	                ( objMulticastProgramName_textBox.value !== "" ) && 
	                ( ! objMulticastProgramName_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
	                isValid = true
                }
	            break;
	        case "2":
                // サーバーメンテ予定日 開始
                if( ( ! isValid ) && 
                    ( objStMainteDate_textBox ) && 
                    ( objStMainteDate_textBox.value !== "" ) && 
                    ( ! objStMainteDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
                    isValid = true
                }
                // サーバーメンテ予定日 終了
                if( ( ! isValid ) && 
                    ( objEdMainteDate_textBox ) && 
                    ( objEdMainteDate_textBox.value !== "" ) && 
                    ( ! objEdMainteDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
                    isValid = true
                }
	            break;
            case "3":
                // 帳票名称
                if( ( ! isValid ) && 
	                ( objPrintName_textBox ) && 
	                ( objPrintName_textBox.value !== "" ) && 
	                ( ! objPrintName_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
	                isValid = true
                }
                // 地域
                if( ( ! isValid ) && 
	                ( objArea_textBox ) && 
	                ( objArea_textBox.value !== "" ) && 
	                ( ! objArea_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
	                isValid = true
                }
                // リリース日 開始
                if( ( ! isValid ) && 
                    ( objStMcastRereaceDate_textBox ) && 
                    ( objStMcastRereaceDate_textBox.value !== "" ) && 
                    ( ! objStMcastRereaceDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
                    isValid = true
                }
                // リリース日 終了
                if( ( ! isValid ) && 
                    ( objEdMcastRereaceDate_textBox ) && 
                    ( objEdMcastRereaceDate_textBox.value !== "" ) && 
                    ( ! objEdMcastRereaceDate_textBox.value.match( /^[ 　\t]+$/ ) ) ) {
                    isValid = true
                }
    	        // システム区分
                if( ( objMulticastSystemDivCd_dropDownList ) && 
	                ( objMulticastSystemDivCd_dropDownList.selectedIndex > 0 ) ) {
	                isValid = true
                }
                break;
            default:
                break;
        }
	}
	// 検証結果をセット
	arguments.IsValid = isValid;
}

// --------------------------------------------------
// 右詰→指定文字詰め込み処理
// --------------------------------------------------
String.prototype.PadLeft = function( totalWidth, paddingChar )
{
	var retStr = this;
	while( retStr.length < totalWidth ) {
		retStr = paddingChar + retStr;
	}
	
	return retStr;
}

// --------------------------------------------------
// 左詰→指定文字詰め込み処理
// --------------------------------------------------
String.prototype.PadRight = function( totalWidth, paddingChar )
{
	var retStr = this;
	while( retStr.length < totalWidth ) {
		retStr = retStr + paddingChar;
	}
	
	return retStr;
}

// --------------------------------------------------
// 非同期 PostBack 開始時処理
// --------------------------------------------------
function InitializeRequest( sender, args ) {
//	if( prm.get_isInAsyncPostBack() ) {
//		args.set_cancel( true );
//	}
	// PostBack 要素を取得
	postBackElement = args.get_postBackElement();
	// 検索ボタンの場合
	if( postBackElement.id == ID_Search_imageButton ) {
		// 検索中プログレスを表示
		$get( ID_Searching_updateProgress ).style.display = "block";
	}
}

// --------------------------------------------------
// 非同期 PostBack 終了時処理
// --------------------------------------------------
function EndRequest( sender, args ) {
	// 検索ボタンの場合
	if( postBackElement.id == ID_Search_imageButton ) {
		// 検索中プログレスを非表示
		$get( ID_Searching_updateProgress ).style.display = "none";
	}
}

// --------------------------------------------------
// 画面クリア処理
// --------------------------------------------------
function ClearSearchBox()
{
	var objChangeContents_textBox            = document.all ? document.all[ ID_ChangeContents_textBox ] : document.getElementById( ID_ChangeContents_textBox );
	var objStMulticastDate_textBox           = document.all ? document.all[ ID_StMulticastDate_textBox ] : document.getElementById( ID_StMulticastDate_textBox );
	var objEdMulticastDate_textBox           = document.all ? document.all[ ID_EdMulticastDate_textBox ] : document.getElementById( ID_EdMulticastDate_textBox );
	var objStMulticastVersion_textBox        = document.all ? document.all[ ID_StMulticastVersion_textBox ] : document.getElementById( ID_StMulticastVersion_textBox );
	var objEdMulticastVersion_textBox        = document.all ? document.all[ ID_EdMulticastVersion_textBox ] : document.getElementById( ID_EdMulticastVersion_textBox );
	var objMulticastSystemDivCd_dropDownList = document.all ? document.all[ ID_MulticastSystemDivCd_dropDownList ] : document.getElementById( ID_MulticastSystemDivCd_dropDownList );
	var objMulticastProgramName_textBox      = document.all ? document.all[ ID_MulticastProgramName_textBox ] : document.getElementById( ID_MulticastProgramName_textBox );
	// 2007.12.19 Maki Add ---------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
	//var objMulticastInfoDivCd_dropDownList   = document.all ? document.all[ ID_MulticastInfoDivCd_dropDownList ] : document.getElementById( ID_MulticastInfoDivCd_dropDownList );
	var objArea_textBox                      = document.all ? document.all[ ID_Area_textBox ] : document.getElementById( ID_Area_textBox );
	var objPrintName_textBox                 = document.all ? document.all[ ID_PrintName_textBox ] : document.getElementById( ID_PrintName_textBox );
	var objStMcastRereaceDate_textBox        = document.all ? document.all[ ID_StMcastRereaceDate_textBox ] : document.getElementById( ID_StMcastRereaceDate_textBox );
	var objEdMcastRereaceDate_textBox        = document.all ? document.all[ ID_EdMcastRereaceDate_textBox ] : document.getElementById( ID_EdMcastRereaceDate_textBox );
	var objStMainteDate_textBox              = document.all ? document.all[ ID_StMainteDate_textBox ] : document.getElementById( ID_StMainteDate_textBox );
	var objEdMainteDate_textBox              = document.all ? document.all[ ID_EdMainteDate_textBox ] : document.getElementById( ID_EdMainteDate_textBox );
	// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<
	
	if( objChangeContents_textBox ) {
		objChangeContents_textBox.value = "";
	}
	
	if( objStMulticastDate_textBox ) {
		objStMulticastDate_textBox.value = "";
	}
	
	if( objEdMulticastDate_textBox ) {
		objEdMulticastDate_textBox.value = "";
	}
	
	if( objStMulticastVersion_textBox ) {
		objStMulticastVersion_textBox.value = "";
	}
	
	if( objEdMulticastVersion_textBox ) {
		objEdMulticastVersion_textBox.value = "";
	}
	
	if( objMulticastSystemDivCd_dropDownList ) {
		objMulticastSystemDivCd_dropDownList.selectedIndex = 0;
	}
	
	if( objMulticastProgramName_textBox ) {
		objMulticastProgramName_textBox.value = "";
	}
	
	if( objChangeContents_textBox ) {
		objChangeContents_textBox.focus();
	}

    // 2007.12.19 Maki Add ----------------------------------->>>>>
	/*if( objMulticastInfoDivCd_dropDownList ) {
		objMulticastInfoDivCd_dropDownList.selectedIndex = 0;
	}*/ //DEL 検索範囲をクリアしない(クリアしてもJavaScriptが発生しないため)
	
	if( objArea_textBox ) {
		objArea_textBox.value = "";
	}
	
	if( objPrintName_textBox ) {
		objPrintName_textBox.value = "";
	}
	
	if( objStMcastRereaceDate_textBox ) {
		objStMcastRereaceDate_textBox.value = "";
	}
	
	if( objEdMcastRereaceDate_textBox ) {
		objEdMcastRereaceDate_textBox.value = "";
	}

	if( objStMainteDate_textBox ) {
		objStMainteDate_textBox.value = "";
	}
	
	if( objEdMainteDate_textBox ) {
		objEdMainteDate_textBox.value = "";
	}
	// -------------------------------------------------------<<<<<
}

/* グローバル変数  2007.12.19 Maki ADD */
var broadleafParams =
{
	tabStopTable : []
};

// --------------------------------------------------
/* リターンキーフォーカス移動制御登録処理 */
// --------------------------------------------------
/* 2007.12.19 Maki Del
function RegistKeyDownEvent( prevId, nextId, dispChkId, chkStyle, chkValue, altNextId )
{
	// 移動前フォームを取得
	var prevForm = document.all ? document.all[ prevId ] : document.getElementById( prevId );
	if( ! prevForm ) {
		// 取得失敗
		return;
	}
	
	// イベント登録
	prevForm.onkeydown = function () {
		var key = 0
		if( typeof( event.keyCode ) != 'undefined' ) {
			key = event.keyCode;
		}
		else if( typeof( e.which ) != 'undefined' ) {
			key = e.which;
		}
		if( key == 0x0d ) {
			var setFocus = false;
			
			// チェック用エレメントIdが有効
			if( dispChkId && chkStyle && chkValue && altNextId ) {
				// チェック用エレメント取得
				var dispChkForm = document.all ? document.all[ dispChkId ] : document.getElementById( dispChkId );
				if( dispChkForm ) {
					if( dispChkForm.style[ chkStyle ] == chkValue ) {
						// 代替エレメント取得
						var altNextForm = document.all ? document.all[ altNextId ] : document.getElementById( altNextId );
						if( altNextForm ) {
							altNextForm.focus();
							return false;
						}
					}
				}
				
			}
			
			var nextForm = document.all ? document.all[ nextId ] : document.getElementById( nextId );
			if( nextForm ) {
				nextForm.focus();
				return false;
			}
		}
	}
}
*/
// 2007.12.19 Maki Add
function RegistKeyDownEvent( prevId, chkId )
{
	// 移動前フォームを取得
	var prevForm = document.all ? document.all[ prevId ] : document.getElementById( prevId );
	if( ! prevForm ) {
		// 取得失敗
		return;
	}
	
	var chkForm = null;
	// 
	if( chkId ) {
	    var wkChkForm = document.all ? document.all[ chkId ] : document.getElementById( chkId );
	    if( wkChkForm ) {
	        chkForm = wkChkForm;
	    }
    }
	
	var tabIndex = broadleafParams.tabStopTable.length;
	
	prevForm.tabIndex = tabIndex;
	
	if( chkForm ) {
		prevForm.checkElement = chkForm;
	}
	else {
		prevForm.checkElement = prevForm;
	}
	broadleafParams.tabStopTable[ tabIndex ] = prevForm;
	
	// フォーカス遷移先のエレメントをみつける
	prevForm.getNextElement = function()
	{
		var nextElement = null;
		
		for( var i = 0; i < broadleafParams.tabStopTable.length; i++ ) {
			var nextTabIndex = ( this.tabIndex + i + 1 ) % broadleafParams.tabStopTable.length;
			var wkElement    = broadleafParams.tabStopTable[ nextTabIndex ];
			
			if( ( ! wkElement.checkElement.style ) || 
					( ! wkElement.checkElement.style.display ) || 
					( wkElement.checkElement.style.display != 'none' ) ) {
				nextElement = wkElement;
				break;
			}
		}
		if( nextElement == null ) {
			nextElement = this;
		}
		return nextElement;
	}
	
	// イベント登録
	prevForm.onkeydown = function( e )
	{
		var key = 0
		if( window.event && typeof( window.event.keyCode ) != 'undefined' ) {
			key = window.event.keyCode;
		}
		else if(e && typeof( e.which ) != 'undefined' ) {
			key = e.which;
		}
		if( key == 0x0d || key == 0x09) {
			var nextElement = this.getNextElement();
			nextElement.focus();
			return false;
		}
	}	
}