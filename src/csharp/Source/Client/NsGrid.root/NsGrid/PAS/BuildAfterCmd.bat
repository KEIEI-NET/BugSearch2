echo %BDSCOMMONDIR%

copy "%BDSCOMMONDIR%\Bpl\%1.bpl" "C:\Program Files\Recycle\SFNETASM\%1.bpl"
copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\配布用ファイル\標準パッケージ\設計時パッケージ(開発用)\%1.bpl"
copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\配布用ファイル\標準パッケージ\実行時パッケージ(インストーラー用)\%1.bpl"
copy "%BDSCOMMONDIR%\Dcp\%1.dcp" ".\配布用ファイル\標準パッケージ\LIB\%1.dcp"

copy "%BDSCOMMONDIR%\Bpl\%1.bpl" "C:\Program Files\Embarcadero\RAD Studio\7.0\lib\Hss\%1.bpl"
copy "%BDSCOMMONDIR%\Dcp\%1.dcp" "C:\Program Files\Embarcadero\RAD Studio\7.0\lib\Hss\%1.dcp"

REM 2010/09/10 テスト用 ---------------------------------------------------------------------------------
REM copy "%BDSCOMMONDIR%\Bpl\%1.bpl" "C:\HSS100\%1.bpl"
REM copy "%BDSCOMMONDIR%\Dcp\%1.dcp" "C:\Program Files\Embarcadero\RAD Studio\7.0\lib\%1.dcp"
REM -----------------------------------------------------------------------------------------------------

REM 古いのを引きずらない様に一度すべて削除
del /Q ".\配布用ファイル\ソース管理\DCU\*.*"
del /Q ".\配布用ファイル\ソース管理\LIB\*.*"
del /Q ".\配布用ファイル\ソース管理\PAS\*.*"
del /Q ".\配布用ファイル\ソース管理\設計時パッケージ(開発用)\*.*"
del /Q ".\配布用ファイル\ソース管理\実行時パッケージ(インストーラー用)\*.*"

copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\配布用ファイル\ソース管理\設計時パッケージ(開発用)\%1.bpl"
copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\配布用ファイル\ソース管理\実行時パッケージ(インストーラー用)\%1.bpl"
copy "%BDSCOMMONDIR%\Dcp\%1.dcp" ".\配布用ファイル\ソース管理\LIB\%1.dcp"

copy *.dcu ".\配布用ファイル\ソース管理\DCU\*.*"
copy *.*   ".\配布用ファイル\ソース管理\PAS\*.*"
del /Q ".\配布用ファイル\ソース管理\PAS\*.dcu"

if exist .\配布用ファイル\*.zip del .\配布用ファイル\*.zip
if exist .\配布用ファイル\*.txt del .\配布用ファイル\*.txt

set time2=%time: =0%
echo このファイルは%DATE% %TIME%に %2 で作成されています。 > .\配布用ファイル\%2_%date:~-10,4%%date:~-5,2%%date:~-2,2%_%time2:~0,2%%time2:~3,2%%time2:~6,2%.txt
set time2=

if "%2"=="RELEASE" goto ZIP
goto END

:ZIP
goto END
"C:\Program Files\Lhaplus\Lhaplus.exe" /c:zip /o:.\配布用ファイル /p:rcns .\配布用ファイル\標準パッケージ
ren .\配布用ファイル\標準パッケージ.zip %date:~-10,4%%date:~-5,2%%date:~-2,2%_標準パッケージ.zip

"C:\Program Files\Lhaplus\Lhaplus.exe" /c:zip /o:.\配布用ファイル /p:rcns .\配布用ファイル\ソース管理
ren .\配布用ファイル\ソース管理.zip %date:~-10,4%%date:~-5,2%%date:~-2,2%_THNsGrid.zip

start Explorer .\配布用ファイル

:END