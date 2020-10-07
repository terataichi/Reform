#include "pch.h"
#include "PadState.h"

std::map<int, keyData> PadState::_keyCon =
{
	{
		0,
		keyData{
		keyPair{ INPUT_ID::A,XINPUT_GAMEPAD_A },
		keyPair{ INPUT_ID::B,XINPUT_GAMEPAD_B },
		keyPair{ INPUT_ID::Y,XINPUT_GAMEPAD_Y },
		keyPair{ INPUT_ID::X,XINPUT_GAMEPAD_X },
		}
	}
	,
	{
		1,
		keyData{
		keyPair{ INPUT_ID::A,XINPUT_GAMEPAD_A },
		keyPair{ INPUT_ID::B,XINPUT_GAMEPAD_B },
		keyPair{ INPUT_ID::Y,XINPUT_GAMEPAD_Y },
		keyPair{ INPUT_ID::X,XINPUT_GAMEPAD_X },
		}
	}
};

void PadState::Update(void)
{
	Vector2 input = { 0.0f, 0.0f };
	// DxLibPower
	for (auto id : _keyCon[p_id_])
	{
		_input[id.first].second = _input[id.first].first;
		_input[id.first].first = (gamePadState_[pad_id_].Gamepad.wButtons & id.second);
	}
	if (gamePadState_[pad_id_].Gamepad.sThumbLY >= 50)
	{
		input.y += 1.0f;
	}
	else if (gamePadState_[pad_id_].Gamepad.sThumbLY <= -50)
	{
		input.y -= 1.0f;
	}

	if (gamePadState_[pad_id_].Gamepad.sThumbLX >= 50)
	{
		input.x += 1.0f;
	}
	else if (gamePadState_[pad_id_].Gamepad.sThumbLX <= -50)
	{
		input.x -= 1.0f;
	}
	LStickData_ = { input.x,input.y };

	Vector2 inputR = { 0.0f, 0.0f };
	if (gamePadState_[pad_id_].Gamepad.sThumbRY >= XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE)
	{
		inputR.y += 1.0f;
	}
	else if (gamePadState_[pad_id_].Gamepad.sThumbRY <= -XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE)
	{
		inputR.y -= 1.0f;
	}

	if (gamePadState_[pad_id_].Gamepad.sThumbRX >= XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE)
	{
		inputR.x += 1.0f;
	}
	else if (gamePadState_[pad_id_].Gamepad.sThumbRX <= -XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE)
	{
		inputR.x -= 1.0f;
	}
	RStickData_ = { inputR.x,inputR.y };
}

void PadState::Setting(const int& p_id, const int& pad_id)
{
	p_id_ = p_id;
	pad_id_ = pad_id;
	XINPUT_STATE gamePadState;
	ZeroMemory(&gamePadState, sizeof(XINPUT_STATE));
	DWORD dwResult = XInputGetState(pad_id, &gamePadState);
	if (dwResult == ERROR_SUCCESS)
	{
		gamePadState_.push_back(gamePadState);
	}
}
