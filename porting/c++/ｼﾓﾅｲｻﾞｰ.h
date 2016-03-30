#ifndef ｼﾓﾅｲｻﾞｰ_h
#define ｼﾓﾅｲｻﾞｰ_h

#include <string>
#include <map>

class ｼﾓﾅｲｻﾞｰ
{
public:
  const char* ｼﾓﾅｲｽﾞ(const char*);

private:
  static const std::map<std::string, const char*> ｼﾓﾅｲｽﾞﾃｰﾌﾞﾙ;

};

#endif
