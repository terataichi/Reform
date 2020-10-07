#pragma once
#include <Windows.h>
#include <Xinput.h>
#pragma comment(lib, "Xinput.lib")
#include <vector>
#include "Input.h"

#define MAX_PAD_NUM 4

// ºÝÄÛ°×°“ü—Í¸×½(Žè”²‚«)
class PadState :
	public Input
{
public:
	void Update(void)override final;
	void Setting(const int& p_id, const int& pad_id)override;
private:
	std::vector<XINPUT_STATE> gamePadState_;
	static std::map<int, keyData> _keyCon;
};

