#include "stdafx.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;
using namespace Broadleaf::Library;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��̑����Z�b�g���Ƃ����Đ��䂳��܂��B
// �A�Z���u���Ɋ֘A�t�����Ă������ύX����ɂ́A
// �����̑����l��ύX���Ă��������B
//
[assembly:AssemblyTitleAttribute("MAHNB01012M")];
[assembly:AssemblyDescriptionAttribute("")];
[assembly:AssemblyConfigurationAttribute("")];
[assembly:AssemblyCompanyAttribute("Broadleaf Co.,Ltd.")];
[assembly:AssemblyProductAttribute("Recycle")];
[assembly:AssemblyCopyrightAttribute("(c)2010 Broadleaf Co.,Ltd.")];
[assembly:AssemblyTrademarkAttribute("Recycle")];
[assembly:AssemblyCultureAttribute("")];
[assembly:AssemblyDeploymentAttribute(DeployPosition::Client)]

//
// �A�Z���u���̃o�[�W�������́A�ȉ��� 4 �̒l�ō\������Ă��܂�:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// ���ׂĂ̒l���w�肷�邩�A���̂悤�� '*' ���g���ă��r�W��������уr���h�ԍ���
// ����l�ɂ��邱�Ƃ��ł��܂�:

[assembly:AssemblyVersionAttribute("8.10.1.0")];
[assembly:AssemblyFileVersionAttribute("8.10.1.0")]

[assembly:ComVisible(false)];

[assembly:CLSCompliantAttribute(true)];

[assembly:SecurityPermission(SecurityAction::RequestMinimum, UnmanagedCode = true)];
