#include "ｼﾓﾅｲｻﾞｰ.h"

const std::map<std::string, const char*> ｼﾓﾅｲｻﾞｰ::ｼﾓﾅｲｽﾞﾃｰﾌﾞﾙ =
{
  { "ガ", "ｶﾞ" },{ "ギ", "ｷﾞ" },{ "グ", "ｸﾞ" },{ "ゲ", "ｹﾞ" },{ "ゴ", "ｺﾞ" },
  { "ザ", "ｻﾞ" },{ "ジ", "ｼﾞ" },{ "ズ", "ｽﾞ" },{ "ゼ", "ｾﾞ" },{ "ゾ", "ｿﾞ" },
  { "ダ", "ﾀﾞ" },{ "ヂ", "ﾁﾞ" },{ "ヅ", "ﾂﾞ" },{ "デ", "ﾃﾞ" },{ "ド", "ﾄﾞ" },
  { "バ", "ﾊﾞ" },{ "ビ", "ﾋﾞ" },{ "ブ", "ﾌﾞ" },{ "ベ", "ﾍﾞ" },{ "ボ", "ﾎﾞ" },
  { "パ", "ﾊﾟ" },{ "ピ", "ﾋﾟ" },{ "プ", "ﾌﾟ" },{ "ペ", "ﾍﾟ" },{ "ポ", "ﾎﾟ" },
  { "ヴ", "ｳﾞ" },
  { "ア", "ｱ" },{ "イ", "ｲ" },{ "ウ", "ｳ" },{ "エ", "ｴ" },{ "オ", "ｵ" },
  { "カ", "ｶ" },{ "キ", "ｷ" },{ "ク", "ｸ" },{ "ケ", "ｹ" },{ "コ", "ｺ" },
  { "サ", "ｻ" },{ "シ", "ｼ" },{ "ス", "ｽ" },{ "セ", "ｾ" },{ "ソ", "ｿ" },
  { "タ", "ﾀ" },{ "チ", "ﾁ" },{ "ツ", "ﾂ" },{ "テ", "ﾃ" },{ "ト", "ﾄ" },
  { "ナ", "ﾅ" },{ "ニ", "ﾆ" },{ "ヌ", "ﾇ" },{ "ネ", "ﾈ" },{ "ノ", "ﾉ" },
  { "ハ", "ﾊ" },{ "ヒ", "ﾋ" },{ "フ", "ﾌ" },{ "ヘ", "ﾍ" },{ "ホ", "ﾎ" },
  { "マ", "ﾏ" },{ "ミ", "ﾐ" },{ "ム", "ﾑ" },{ "メ", "ﾒ" },{ "モ", "ﾓ" },
  { "ヤ", "ﾔ" },{ "ユ", "ﾕ" },{ "ヨ", "ﾖ" },
  { "ラ", "ﾗ" },{ "リ", "ﾘ" },{ "ル", "ﾙ" },{ "レ", "ﾚ" },{ "ロ", "ﾛ" },
  { "ワ", "ﾜ" },{ "ヲ", "ｦ" },{ "ン", "ﾝ" },
  { "ァ", "ｧ" },{ "ィ", "ｨ" },{ "ゥ", "ｩ" },{ "ェ", "ｪ" },{ "ォ", "ｫ" },
  { "ャ", "ｬ" },{ "ュ", "ｭ" },{ "ョ", "ｮ" },
  { "ッ", "ｯ" }
};

const char* ｼﾓﾅｲｻﾞｰ::ｼﾓﾅｲｽﾞ(const char* ﾓｼﾞﾚﾂ)
{
  std::string ﾌﾙｲ = ﾓｼﾞﾚﾂ;
  std::string ｱﾀﾗｼｲ;
  unsigned char ｾﾝﾄｳ;
  int ﾊﾞｲﾄｽｳ = 0;
  for (std::string::iterator ｲﾃﾚﾀ = ﾌﾙｲ.begin(); ｲﾃﾚﾀ != ﾌﾙｲ.end(); ｲﾃﾚﾀ += ﾊﾞｲﾄｽｳ) {
    ｾﾝﾄｳ = *ｲﾃﾚﾀ;
    if (ｾﾝﾄｳ < 0x80) {
      ﾊﾞｲﾄｽｳ = 1;
    } else if (ｾﾝﾄｳ < 0xE0) {
      ﾊﾞｲﾄｽｳ = 2;
    } else if (ｾﾝﾄｳ < 0xF0) {
      ﾊﾞｲﾄｽｳ = 3;
    } else {
      ﾊﾞｲﾄｽｳ = 4;
    }

    std::string ﾏｴ = ﾌﾙｲ.substr( distance( ﾌﾙｲ.begin(), ｲﾃﾚﾀ ), ﾊﾞｲﾄｽｳ );
    std::map<std::string, const char*>::const_iterator ｱﾄ = ｼﾓﾅｲｽﾞﾃｰﾌﾞﾙ.find(ﾏｴ);

    if ( ｱﾄ == ｼﾓﾅｲｽﾞﾃｰﾌﾞﾙ.end() )
    {
      ｱﾀﾗｼｲ += ﾏｴ;
      continue;
    }
    ｱﾀﾗｼｲ += ｱﾄ->second;
  }
  return ｱﾀﾗｼｲ.c_str();
}

