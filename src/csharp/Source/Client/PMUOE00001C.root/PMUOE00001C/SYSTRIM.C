/***********************************************************************/
/*	system			: パーツマン Ⅳシステム							   */
/*	library name	: PMSYS.LIB  SYSTEM 共通ライブラリ			   	   */
/*	file name		: PMSYS.C										   */
/*	programer		: 首藤　敬章									   */
/*	date			: 1993-10-12									   */
/*---------------------------------------------------------------------*/
/*	P980812	立花裕輔	３２ビット対応							  	   */
/*---------------------------------------------------------------------*/
/*			Copyright 1993 Hokkaido Tsubasa Software Lab. Co.		   */
/***********************************************************************/

//#include	"sysdef.h"
//#include	"common.h"
#include 	<conio.h>
#include 	<ctype.h>
#include 	<dos.h>
#include 	<stdio.h>
#include 	<stdlib.h>
#include 	<string.h>
#include	<mbstring.h>

static char work_string[256];

/***********************************************************************/
/*	module name : 文字列の指定バイト目の漢字チェック				   */
/*	module id	: st_ktest										   	   */
/*	return code : ０：漢字以外、１：漢字						   	   */
/*	programer	: Kazuo Kudou										   */
/*	date		: 1993-10-05										   */
/***********************************************************************/
short st_ktest( char *str, short pos ){
	short  st_ret = 0;
	short  st_cnt = 0;

	while( st_cnt <= pos ){
		if( _ismbblead( *(str+st_cnt) ) ){
			if( st_cnt == pos ){
				st_ret = 1;
				break;
			}
			st_cnt += 2;
		}else{
			st_cnt++;
		}
	}
	return st_ret;
}

/***********************************************************************/
/*	module name : 文字列のスペースを先頭からカットする				   */
/*	module id	: *ltrim											   */
/*	return code : 対象文字列									   	   */
/*	programer	: Kazuo Kudou										   */
/*	date		: 1993-10-05										   */
/***********************************************************************/
char *ltrim( char *str ){
	short  length;
	char c;
	char *save;
	save = str;
	for(;;){
		c = *str;
		if( !c ) break;
		if( _ismbblead(c) ){
			if( c != 0x81 || *(str+1) != 0x40 ) break;
			str++;
		}else{
			if( c != ' ' ) break;
		}
		str++;
	}
	length = strlen(str);
	memmove( work_string, str, length );
	work_string[length] = 0x00;
	memmove( save, work_string, length+1 );
	return save;
}

/***********************************************************************/
/*	module name : 文字列の終端のスペースをカットする				   */
/*	module id	: *rtrim  										 	   */
/*	return code : 対象文字列									   	   */
/*	programer	: Kazuo Kudou										   */
/*	date		: 1993-10-05										   */
/***********************************************************************/
char *rtrim( char *str ){
	if( work_string != str ) strcpy( work_string, str );
	_mbsrev(work_string);
	ltrim(work_string);
	_mbsrev(work_string);
	if( work_string != str ) strcpy( str, work_string);
	return str;
}

/***********************************************************************/
/*	module name : 指定長の文字列を作成する							   */
/*	module id	: char *st_make										   */
/*	return code : 対象文字列									   	   */
/*	programer	: Kazuo Kudou										   */
/*	date		: 1993-10-05										   */
/***********************************************************************/
char *st_make( char *str, short len){
	short  wklen;
	if( len > 255){
		strcpy( work_string, "String too long!!" );
	}else{
		memset( work_string, ' ', 255);
		wklen = strlen( str );
		if( wklen > len ) wklen = len;
		if( wklen ) memcpy( work_string, str, wklen );
/* P980812 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
//		if( st_ktest( work_string,len - 1 ) ) work_string[len-1] = ' ';
		if( st_ktest( work_string,(short)(len - 1) ) ) work_string[len-1] = ' ';
/* P980812 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*/
		work_string[len] = 0x00;
	}
	return work_string;
}

/***********************************************************************/
/*	module name : 文字列を繰り返す									   */
/*	module id	: char *st_rep										   */
/*	return code : 繰り返し処理後の文字列						   	   */
/*	programer	: Kazuo Kudou										   */
/*	date		: 1993-10-05										   */
/***********************************************************************/
char *st_rep( char *str, short rep){
	if( (strlen(str) * rep) > 255 ){
		strcpy( work_string, "String repeat too long!!" );
	}else{
		memset( work_string, 0x00, 255);
		if( rep ) while( rep-- ) strcat( work_string, str );
	}
	return work_string;
}

