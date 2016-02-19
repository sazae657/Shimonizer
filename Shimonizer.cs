using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ﾒｲﾝ {
    public static class ｼﾓﾅｲｻﾞーExtension
    {
        static Dictionary<char, string> ｼﾓﾅｲｽﾞﾃーﾌﾞﾙ = new Dictionary<char, string>{
            {'ガ',"ｶﾞ"},{'ギ',"ｷﾞ"},{'グ',"ｸﾞ"},{'ゲ',"ｹﾞ"},{'ゴ',"ｺﾞ"},
            {'ザ',"ｻﾞ"},{'ジ',"ｼﾞ"},{'ズ',"ｽﾞ"},{'ゼ',"ｾﾞ"},{'ゾ',"ｿﾞ"},
            {'ダ',"ﾀﾞ"},{'ヂ',"ﾁﾞ"},{'ヅ',"ﾂﾞ"},{'デ',"ﾃﾞ"},{'ド',"ﾄﾞ"},
            {'バ',"ﾊﾞ"},{'ビ',"ﾋﾞ"},{'ブ',"ﾌﾞ"},{'ベ',"ﾍﾞ"},{'ボ',"ﾎﾞ"},
            {'パ',"ﾊﾟ"},{'ピ',"ﾋﾟ"},{'プ',"ﾌﾟ"},{'ペ',"ﾍﾟ"},{'ポ',"ﾎﾟ"},
            {'ヴ',"ｳﾞ"},
            {'ア',"ｱ"},{'イ',"ｲ"},{'ウ',"ｳ"},{'エ',"ｴ"},{'オ',"ｵ"},
            {'カ',"ｶ"},{'キ',"ｷ"},{'ク',"ｸ"},{'ケ',"ｹ"},{'コ',"ｺ"},
            {'サ',"ｻ"},{'シ',"ｼ"},{'ス',"ｽ"},{'セ',"ｾ"},{'ソ',"ｿ"},
            {'タ',"ﾀ"},{'チ',"ﾁ"},{'ツ',"ﾂ"},{'テ',"ﾃ"},{'ト',"ﾄ"},
            {'ナ',"ﾅ"},{'ニ',"ﾆ"},{'ヌ',"ﾇ"},{'ネ',"ﾈ"},{'ノ',"ﾉ"},
            {'ハ',"ﾊ"},{'ヒ',"ﾋ"},{'フ',"ﾌ"},{'ヘ',"ﾍ"},{'ホ',"ﾎ"},
            {'マ',"ﾏ"},{'ミ',"ﾐ"},{'ム',"ﾑ"},{'メ',"ﾒ"},{'モ',"ﾓ"},
            {'ヤ',"ﾔ"},{'ユ',"ﾕ"},{'ヨ',"ﾖ"},
            {'ラ',"ﾗ"},{'リ',"ﾘ"},{'ル',"ﾙ"},{'レ',"ﾚ"},{'ロ',"ﾛ"},
            {'ワ',"ﾜ"},{'ヲ',"ｦ"},{'ン',"ﾝ"},
            {'ァ',"ｧ"},{'ィ',"ｨ"},{'ゥ',"ｩ"},{'ェ',"ｪ"},{'ォ',"ｫ"},
            {'ャ',"ｬ"},{'ュ',"ｭ"},{'ョ',"ｮ"},{'ッ',"ｯ"}
        };

        public static string ｼﾓﾅｲｽﾞ(this string 閣下)
        {
            foreach(var 相当 in ｼﾓﾅｲｽﾞﾃーﾌﾞﾙ) {
                if (閣下.Contains(相当.Key)) {
                    閣下 = 閣下.Replace(相当.Key.ToString(), 相当.Value);
                }
            }
            return 閣下;
        }
    }

    class ｸﾗｽﾒｲﾝ {
        static readonly string 改行 = "\n";
        static readonly string 虚無 = null;

        enum その後 {
            何もしないんですよ,
            書き込むんですよ
        }

        static bool 読み書き(string ﾌｧｲﾙの場所, Encoding 文字ｺーﾄﾞ, その後 どうするんですか) {
            var 読み込みﾊﾞｯﾌｧー = new StringBuilder();

            using (var ｽﾄﾘーﾑﾘーﾀﾞー =
                    ((虚無 != ﾌｧｲﾙの場所) ? new StreamReader(ﾌｧｲﾙの場所, 文字ｺーﾄﾞ) : Console.In))
            {
                string 行;
                while ((行 = ｽﾄﾘーﾑﾘーﾀﾞー.ReadLine()) != null) {
                   読み込みﾊﾞｯﾌｧー.Append(行.ｼﾓﾅｲｽﾞ()).Append(改行);
                }
            }

            if (その後.何もしないんですよ == どうするんですか) {
                Console.Write(読み込みﾊﾞｯﾌｧー.ToString());
                return true;
            }

            using(var ｽﾄﾘーﾑﾗｲﾀー =new StreamWriter(ﾌｧｲﾙの場所, false, 文字ｺーﾄﾞ)) {
                ｽﾄﾘーﾑﾗｲﾀー.Write(読み込みﾊﾞｯﾌｧー);
            }
            return true;
        }

        static void Main(string[] ｺﾏﾝﾄﾞﾗｲﾝ引数)
        {
            var 文字ｺーﾄﾞ = new System.Text.UTF8Encoding(false);
            その後 どうするんですか = その後.何もしないんですよ;
            if (0 == ｺﾏﾝﾄﾞﾗｲﾝ引数.Length) {
                読み書き(虚無, 文字ｺーﾄﾞ, その後.何もしないんですよ);
                return;
            }

            foreach(var 分離された引数 in ｺﾏﾝﾄﾞﾗｲﾝ引数) {
                if (分離された引数.StartsWith("-")){
                     if(分離された引数.Equals("-w")) {
                         どうするんですか = その後.書き込むんですよ;
                     }
                     else if(分離された引数.Equals("-bom")) {
                         文字ｺーﾄﾞ = new System.Text.UTF8Encoding(true);
                     }
                     continue;
                }
                読み書き(分離された引数, 文字ｺーﾄﾞ, どうするんですか);
            }
        }
    }
}
