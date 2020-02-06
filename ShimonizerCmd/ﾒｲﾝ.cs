using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using 文字列 = System.String;
using 文字 = System.Char;
using 文字ｺーﾄﾞー = System.Text.Encoding;
using その結果 = System.Boolean;
using 妄想配列 = System.Collections.Generic.Dictionary<char, string>;
using ｼﾓﾅｲｻﾞー;

namespace ﾒｲﾝ
{
    class ｸﾗｽﾒｲﾝ
    {
        static readonly 文字列 改行 = "\n";
        static readonly 文字列 虚無 = null;

        static readonly その結果 真 = true;
        static readonly その結果 偽 = false;

        enum その後
        {
            何もしないんですよ,
            書き込むんですよ
        }

        static その結果 読み書き(文字列 ﾌｧｲﾙの場所, 文字ｺーﾄﾞー 文字ｺーﾄﾞ, その後 どうするんですか) {
            var 読み込みﾊﾞｯﾌｧー = new StringBuilder();

            using (var ｽﾄﾘーﾑﾘーﾀﾞー =
                    ((虚無 != ﾌｧｲﾙの場所) ? new StreamReader(ﾌｧｲﾙの場所, 文字ｺーﾄﾞ) : Console.In)) {
                文字列 行;
                while ((行 = ｽﾄﾘーﾑﾘーﾀﾞー.ReadLine()) != 虚無) {
                    読み込みﾊﾞｯﾌｧー.Append(行.ｼﾓﾅｲｽﾞ()).Append(改行);
                }
            }

            if (その後.何もしないんですよ == どうするんですか) {
                Console.Write(読み込みﾊﾞｯﾌｧー.ToString());
                return 真;
            }

            using (var ｽﾄﾘーﾑﾗｲﾀー = new StreamWriter(ﾌｧｲﾙの場所, 偽, 文字ｺーﾄﾞ)) {
                ｽﾄﾘーﾑﾗｲﾀー.Write(読み込みﾊﾞｯﾌｧー);
            }
            return 真;
        }

        static void Main(文字列[] ｺﾏﾝﾄﾞﾗｲﾝ引数) {
            var 文字ｺーﾄﾞ = new System.Text.UTF8Encoding(偽);
            その後 どうするんですか = その後.何もしないんですよ;
            if (0 == ｺﾏﾝﾄﾞﾗｲﾝ引数.Length) {
                読み書き(虚無, 文字ｺーﾄﾞ, その後.何もしないんですよ);
                return;
            }

            foreach (var 分離された引数 in ｺﾏﾝﾄﾞﾗｲﾝ引数) {
                if (分離された引数.StartsWith("-")) {
                    if (分離された引数.Equals("-w")) {
                        どうするんですか = その後.書き込むんですよ;
                    }
                    else if (分離された引数.Equals("-bom")) {
                        文字ｺーﾄﾞ = new System.Text.UTF8Encoding(真);
                    }
                    continue;
                }
                読み書き(分離された引数, 文字ｺーﾄﾞ, どうするんですか);
            }
        }
    }
}
