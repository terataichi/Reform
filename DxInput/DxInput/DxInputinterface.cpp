#include "pch.h"
#include "DxInputinterface.h"




Input* _stdcall PadState_Create()
{
	return new PadState();
}

void _stdcall PadState_Destory(Input* instance)
{
	if (instance == nullptr)
	{
		return;
	}
	delete instance;
	instance = nullptr;
}

void _stdcall DxInput_Setting(Input* instance, const int p_id, const int pad_id)
{
	if (instance == nullptr)
	{
		return;
	}
	instance->Setting(p_id, pad_id);
}

void _stdcall DxInput_Update(Input* instance)
{
	if (instance == nullptr)
	{
		return;
	}
	instance->Update();
}

bool _stdcall DxInput_GetKeyTrg(Input* instance, int id)
{
	if (instance == nullptr)
	{
		return false;
	}
	return instance->GetKeyTrg(static_cast<INPUT_ID>(id));
}

bool _stdcall DxInput_GetKeySty(Input* instance, int id)
{
	if (instance == nullptr)
	{
		return false;
	}
	return instance->GetKeySty(static_cast<INPUT_ID>(id));
}

bool _stdcall DxInput_GetKey(Input* instance, int id)
{
	if (instance == nullptr)
	{
		return false;
	}
	return instance->GetKey(static_cast<INPUT_ID>(id));
}

Vector2 _stdcall DxInput_LStickData(Input* instance)
{
	if (instance == nullptr)
	{
		return Vector2{};
	}
	return instance->GetLStickData();
}

Vector2 _stdcall DxInput_RStickData(Input* instance)
{
	if (instance == nullptr)
	{
		return Vector2{};
	}
	return instance->GetRStickData();
}
