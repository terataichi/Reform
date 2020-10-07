#pragma once
#include<utility>
#include<array>
#include<map>
#include"INPUT_ID.h"


using InputData = std::map<INPUT_ID, std::pair<bool, bool>>;

using keyPair = std::pair<INPUT_ID, int>;
using keyData = std::array<keyPair,static_cast<size_t>(INPUT_ID::MAX)>;

struct Vector2
{
	short x;
	short y;
};

class Input
{
public:
	Input();
	virtual void Update(void) = 0;					// Update継承元
	virtual void Setting(const int& p_id, const int& pad_id);									// 初期化後個別ｾﾃｨﾝｸﾞ必要な場合のみ継承先に記述
	bool GetKeyTrg(INPUT_ID key);								// 指定IDのﾄﾘｶﾞｰ判定
	bool GetKeySty(INPUT_ID key);								// 指定IDのおしっぱ判定
	bool GetKey(INPUT_ID key);									// 指定IDの現在入力情報
	Vector2 GetRStickData(void);
	Vector2 GetLStickData(void);
	virtual void SetPadNum(int&& num);
	void Reset(void);
private:
	void Init(void);											// 初期化
protected:
	InputData _input;											// 押下ﾃﾞｰﾀ格納先
	Vector2 LStickData_;
	Vector2 RStickData_;
	int p_id_;
	int pad_id_;
};

