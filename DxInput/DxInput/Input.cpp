#include "pch.h"
#include <DxLib.h>
#include "Input.h"


Input::Input()
{
	Init();
}

void Input::Setting(const int& p_id, const int& pad_id)
{
	p_id_ = p_id;
	pad_id_ = pad_id;
}

bool Input::GetKeyTrg(INPUT_ID key)
{
	// MAX��n���ꂽ���̂��߂̶ް��
	if (key == INPUT_ID::MAX)
	{
		return false;
	}
	return _input[key].first && !_input[key].second;
}

bool Input::GetKeySty(INPUT_ID key)
{
	// MAX��n���ꂽ���̂��߂̶ް��
	if (key == INPUT_ID::MAX)
	{
		return false;
	}
	return _input[key].first && _input[key].second;
}

bool Input::GetKey(INPUT_ID key)
{
	if (key == INPUT_ID::MAX)
	{
		return false;
	}
	return _input[key].first;
}

Vector2 Input::GetRStickData(void)
{
	return RStickData_;
}

Vector2 Input::GetLStickData(void)
{
	return LStickData_;
}

void Input::SetPadNum(int&& num)
{
	pad_id_ = num;
}

void Input::Reset(void)
{
	for (auto id : INPUT_ID())
	{
		_input[id] = { false,false };
	}
}

void Input::Init()
{
	for (auto id : INPUT_ID())
	{
		_input.try_emplace(id, std::pair<bool, bool>{ false, false });
	}
	LStickData_ = {};
	RStickData_ = {};
}
