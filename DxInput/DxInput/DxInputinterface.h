#pragma once
#include "PadState.h"

extern "C"
{
	__declspec(dllexport) Input* __stdcall PadState_Create();

	__declspec(dllexport) void __stdcall PadState_Destory(Input* instance);

	__declspec(dllexport) void __stdcall DxInput_Setting(Input* instance,const int p_id, const int pad_id);
	__declspec(dllexport) void __stdcall DxInput_Update(Input* instance);

	__declspec(dllexport) bool __stdcall DxInput_GetKeyTrg(Input* instance, int id);
	__declspec(dllexport) bool __stdcall DxInput_GetKeySty(Input* instance, int id);
	__declspec(dllexport) bool __stdcall DxInput_GetKey(Input* instance, int id);

	__declspec(dllexport) Vector2 __stdcall DxInput_LStickData(Input* instance);
	__declspec(dllexport) Vector2 __stdcall DxInput_RStickData(Input* instance);
}

