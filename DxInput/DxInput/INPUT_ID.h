#pragma once
enum class INPUT_ID
{
	A,
	B,
	Y,
	X,
	MAX
};

// autofor���p�֐��Q
INPUT_ID begin(INPUT_ID);
INPUT_ID end(INPUT_ID);
INPUT_ID operator*(INPUT_ID key);
INPUT_ID operator++(INPUT_ID& key);
INPUT_ID operator--(INPUT_ID& key);
