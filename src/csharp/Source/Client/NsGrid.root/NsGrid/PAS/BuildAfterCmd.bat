echo %BDSCOMMONDIR%

copy "%BDSCOMMONDIR%\Bpl\%1.bpl" "C:\Program Files\Recycle\SFNETASM\%1.bpl"
copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\�z�z�p�t�@�C��\�W���p�b�P�[�W\�݌v���p�b�P�[�W(�J���p)\%1.bpl"
copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\�z�z�p�t�@�C��\�W���p�b�P�[�W\���s���p�b�P�[�W(�C���X�g�[���[�p)\%1.bpl"
copy "%BDSCOMMONDIR%\Dcp\%1.dcp" ".\�z�z�p�t�@�C��\�W���p�b�P�[�W\LIB\%1.dcp"

copy "%BDSCOMMONDIR%\Bpl\%1.bpl" "C:\Program Files\Embarcadero\RAD Studio\7.0\lib\Hss\%1.bpl"
copy "%BDSCOMMONDIR%\Dcp\%1.dcp" "C:\Program Files\Embarcadero\RAD Studio\7.0\lib\Hss\%1.dcp"

REM 2010/09/10 �e�X�g�p ---------------------------------------------------------------------------------
REM copy "%BDSCOMMONDIR%\Bpl\%1.bpl" "C:\HSS100\%1.bpl"
REM copy "%BDSCOMMONDIR%\Dcp\%1.dcp" "C:\Program Files\Embarcadero\RAD Studio\7.0\lib\%1.dcp"
REM -----------------------------------------------------------------------------------------------------

REM �Â��̂���������Ȃ��l�Ɉ�x���ׂč폜
del /Q ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\DCU\*.*"
del /Q ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\LIB\*.*"
del /Q ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\PAS\*.*"
del /Q ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\�݌v���p�b�P�[�W(�J���p)\*.*"
del /Q ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\���s���p�b�P�[�W(�C���X�g�[���[�p)\*.*"

copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\�݌v���p�b�P�[�W(�J���p)\%1.bpl"
copy "%BDSCOMMONDIR%\Bpl\%1.bpl" ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\���s���p�b�P�[�W(�C���X�g�[���[�p)\%1.bpl"
copy "%BDSCOMMONDIR%\Dcp\%1.dcp" ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\LIB\%1.dcp"

copy *.dcu ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\DCU\*.*"
copy *.*   ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\PAS\*.*"
del /Q ".\�z�z�p�t�@�C��\�\�[�X�Ǘ�\PAS\*.dcu"

if exist .\�z�z�p�t�@�C��\*.zip del .\�z�z�p�t�@�C��\*.zip
if exist .\�z�z�p�t�@�C��\*.txt del .\�z�z�p�t�@�C��\*.txt

set time2=%time: =0%
echo ���̃t�@�C����%DATE% %TIME%�� %2 �ō쐬����Ă��܂��B > .\�z�z�p�t�@�C��\%2_%date:~-10,4%%date:~-5,2%%date:~-2,2%_%time2:~0,2%%time2:~3,2%%time2:~6,2%.txt
set time2=

if "%2"=="RELEASE" goto ZIP
goto END

:ZIP
goto END
"C:\Program Files\Lhaplus\Lhaplus.exe" /c:zip /o:.\�z�z�p�t�@�C�� /p:rcns .\�z�z�p�t�@�C��\�W���p�b�P�[�W
ren .\�z�z�p�t�@�C��\�W���p�b�P�[�W.zip %date:~-10,4%%date:~-5,2%%date:~-2,2%_�W���p�b�P�[�W.zip

"C:\Program Files\Lhaplus\Lhaplus.exe" /c:zip /o:.\�z�z�p�t�@�C�� /p:rcns .\�z�z�p�t�@�C��\�\�[�X�Ǘ�
ren .\�z�z�p�t�@�C��\�\�[�X�Ǘ�.zip %date:~-10,4%%date:~-5,2%%date:~-2,2%_THNsGrid.zip

start Explorer .\�z�z�p�t�@�C��

:END