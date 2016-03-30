/*
 * ｼﾓﾅｲｻﾞｰを使って引数をｼﾓﾅｲｽﾞ
 * ex ./a.out バズ
 * ﾊﾞｽﾞ
 */

#include "ｼﾓﾅｲｻﾞｰ.h"

int main( int ｻｲﾀﾞｲ, char *ﾋｷｽｳ[] )
{
  char *ﾏｴ;
  int ｲﾏ = 1;
  ｼﾓﾅｲｻﾞｰ ｼﾓ;

  while (ｲﾏ < ｻｲﾀﾞｲ)
  {
    ﾏｴ = ﾋｷｽｳ[ｲﾏ];
    std::string ｱﾄ = ｼﾓ.ｼﾓﾅｲｽﾞ(ﾏｴ);
    printf("%s ", ｱﾄ.c_str());
    ++ｲﾏ;
  }

  printf("\n");

  return 0;
}

