#include <stdio.h>
#include <string.h>

extern int shimonize(const char*, char*, int);

int main(void) {
    char vip[124];
    int siz = (int)sizeof(vip);
    memset(vip, 0x00, sizeof(vip));
    shimonize("ハイパーメディアクリエイター", vip, siz); printf("%s\n", vip);

	memset(vip, 0x00, sizeof(vip));
    shimonize("魔法使いプリキュア", vip, siz); printf("%s\n", vip);

	memset(vip, 0x00, sizeof(vip));
    shimonize("シモーネ", vip, siz); printf("%s\n", vip);
    return 0;
}

