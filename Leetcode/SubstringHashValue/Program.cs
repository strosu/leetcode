using System.Diagnostics;
using System.Numerics;

namespace SubstringHashValue;
class Program
{
    static void Main(string[] args)
    {
        //var x = new Solution().SubStrHash("leetcode", 7, 20, 2, 0);
        //var x2 = new Solution().SubStrHash("xqgfatvtlwnnkxipmipcpqwbxihxblaplpfckvxtihonijhtezdnkjmmk", 22, 51, 41, 9);

        Stopwatch w1 = new Stopwatch();
        w1.Start();
        var x3 = new Solution().SubStrHash("kfedcbdngvlykqyrbvwbnaassgjifjxtawlafhcpjtpzfnbsqfasohevbbhkwmtnmixolfepkjmcbadqcljmsbonrngsgfqwzqiisbiwiqgtqtqddukgtjymbxzmtxrobuhkdxmdmqccrauzkrjisstznnkhupiandekzcchsrzwintkkzhvqomqmnbasynmvtxwydcvwoukqmgrpmgzqancuzapgncasxnbyznlrdvcbomdptjftgxdzeqzyavfdpseoxpvohpxtikyjfvskxyqbubgnseraxtrcrwjxloxymhqgaxwbbvzhjsbncqrlpdbiuakdjzjrbclhxgnjjyfrqyjchlsdrcwtdoktviqwjctlmzqemumgmjufcbixkfhzkugsvnkrrakccguybwhmuexiemqusltaaqrswsezccqzaputgaabrjdeihmkpzbojnusmhkwjdxvgiexwdkkazhhmlalgzvxgqgncfytrxuhkwhwcxhmlbvkhjcnyztepwnlpthozdqexvhxpvheopjrsjzkqrstczffkhkikelwydcbnghfiibeyabgegdgaqvasujmggltkvokmnsmontjzsmzoeeqenafvurbnbwqbizvaqxfgnoxasctfrwvqmoufvpajdkethlvbhbehxahcpcizocbchwfznhuqtblwepeqdhycrovqosmxxeeqaffjvvclmpcqdugndexexcykyusetuamymszlteobxkestwbzubpstbwrstuovlybycevedzgurqvlgkouvavcukccgixixsrndurvrkfegegnchbhockujlafxexlxhgysraviztkjymiqxrlldcixvfnzrpserrqycbfmesqbltywmandcqtluccbisfqzosbvedqhsxepdjevaasylvjmfpvyxqvclaalgxytiukyarojmzyovmiunkvqhkouhxxhbemavagrhteofpowvlpdunjjpwgcjibagfswrzwkgrwklppchvtukzncvoqorlsskyghkhrazwvyqqjfygmduhsfkrseddgmtdvlqeruxogmyttdqmdpmscspatkoifauivwjtbwisiiqztrllfqnjvbagrfylrpjudjmvwhdkhahyxlsfbkuuyofryfgblllzeacfiqqawridcbtqnroxwuqhyspqmwhxmjztqokofnkfvupcykszthicdgjbrgafpztktrcwtayoulnjaazigkinnpttghhyboiczvtswenshlmqyelnwhzqlswblqssiiynypfcxerlykpiyimkoodimdfdlzbwmlwflylcqwaflivqeonjswvowxgeoafmppodmfbvooodtnzgmhfnchenaaywqevklrpgajbmbxgiopofghlouhjfarjxlclcullsgyzhohowtragbkaebrvbkmxfxughlirtikheojbrrgxtqldfdnqxndzvfgajiltnqnuwavxbrvuiycsizunlglwnivpseyfwmgydmmpzhxkdtpuzpddacjmjhvncdoicedkimdgaqobdfagpggvjemstqbsshynyvhdyslgldvkapqgusmnuroqxcivjifkhrotomxodficktxmcytkbqitrlalpbtphowfgtzgfacabjodvivgykorvmxhzpqvskolkbfpbdgowlighossrlwiomgohfhgklmlnekniqfjmvvqvmimkeddfxnxwzzroospxvndynetghkgrakuslukqsrdtmjkblwrmwhzzojcwwogrjvnftdwwpoqcjqimvjbwgqgpeffjnwlzdyhkhwmvpwpcmjmdqneexqwcrvdxsfsnidwyflwxwngczklprhoazeeqwclrqvnicfvrtbqailbwrqxadxslouwdjycidupemdwhpkqekaxxprtdtmjficrhlvqidvgwkllaowyyajkxugqiztbpzvjqtpuyugkvdfcaczzruskvucsxtvroljnjojuzncatgnypbzwvilbajqqnjovqxcfunwwbxgshrjlajwveaswqegidfnedpxqdreddvawrpbllkcshlafnxyocbmwacytvgtoonlkukqhxwbfxcfnbgmrfcnkvtxmygiyjoyoljd",
            71717, 94536, 1149, 39999);

        //var c = w1.ElapsedMilliseconds;
        //w1.Reset();

        //var xj = SubStrHashJ("xvgvednpdymdueibaajtteuonorekecszwtznqnncqzmkiglvuzkvmiourabqrvkamtykwonqqnhscnqlpxsovpjftnstrubudrhypugbhinrcjatqixxnfcntyuxjjkvhdycmtfnwxsgfqntccppfxiaulhedjanavqzflocxgsulejjscsczlhkbuukuezuoaeyasnftzqxtllgqpcdtsmavesczcnvsydcyvyligntvjyowsnqwxkwdghhdvfesrvpyrwefjxfkzhgtqchoinffaspsmzwdzhwioudzedaqqdagohxldefznbnvxmzsuayzejjwbzrtfnmaktlbaauwhxtacdmrgrbkehrfbvghaeleeepbxsilvdgohwlcdyegzsceankyrfkwjpofdaollzfzrxzxkmkdutjhzqdjyxmlzavmpaerlbmkoqdvprgelpomqdjvkpxxnvhhxdaioudpcafdwltduudfrtzbfkkkonuchrdertgtakjatfobjqcvlktrhkclzlsmejtiozemrrwuqsasflxjuzkkzilitkqabynowdllilmhhiqfuxmilgfsvmnvvribnmvpvhtgbtldzhgstazfgwtklxylgjdqtvrguxpqaigceeulptrbihsyyhlpjjhmdselzniboglnlnjurlsqhrttwgtcivmbarahyaezgttaduotrabnbobwqursulnjgztghgxlcngodwsrusfnjzwcuzwvlporfrtpbeacvtbvoqrkmvrnbdtbflqbxublxkkzmfmjtftytkkngimtrppsogrqykotwcdvegkudttrpiqflvzuopuahltzsktksntdmtztxevrjivsjgfurypstbxprjdldxuhjobwfzqcnqurrqddzypzgozzgzvjkfhdjoaeotjiqoicsponotrjuwuipkgetlbhyzzooxvuikhpxbpgmaresgkvqzpgqiwuuxxqnmmwezwrzyzfepqouxsqtrctjjbscnvezxgnkdtichmlkfcktuhdbgkuowjlmcujvnjulmgpdgkmylpwmhrpitnxtlyoyjzxtxwxhnfakhxsdahciswuwrqrlknmqaxtgrnmptlhgvrsdyksaxbjssnqdvedppevaorflmtofgbdfaolwzrqqqjykcgtmnvyndngviyhllefkmqgajqrgakyghlledibvdqscnhjgbqnvlyukxjbipjncccmslfrrphpqxsyzqdjhdsifsiekgvlmatpkjwmrtjqwgzzolcflyuyqdqovgbavixcjbyifefrwtvwdhzxngxocthwkmqrklnjxpqcyaewrsppxiodpvobjwcdtrubmxgjiysjncdrxelmflcybljfkmwtxvnkjdvsnovodsvdvoqzymilcmhyotmuruttvgyxrbmomizfnigflrjteofbseqmzmcapjwowcjktgwyjquppuhqlnrbjwjdlapvitndiszwqnshzqazkxdlpdvzasfwmaktgrzyotmoxywurqbkmurlsiktboyzblkesrmbsgtdstkdcoyniyvblkxeiuxxrhkcfbhteaalrrbmzfbtxuimcfmktmkerifsfydrajabhypadrtzblexazdjsukncjkvjnczzdzvvunpebxftxsqiiegxwtieqbuhbrwwcrrcirhgevkddcnhyfxejtjtkywssffmdocxuxxwpvoftsswzwrglxfqzihawkpsfvoqwfskcdxhclqwawrcjiupbtzvevzrkmepfmhkcbtwmteyfdicydjtbqhdfyxjphgesveomauuxfaodeqbalkqhjotlmxhctaklehgwmqtvwdpecyfosrggulhmwkjjuqqzcyfejneyfsolhpermfusccteqdysrqigdfwmrjxqxeskzjipxfqhrhdnqanqtklawupddbannnrifvvncqecnfjtbukufitczrehsswaapbugvaaibenzniamgnokgrvvavceruerkxzxdpqioqjvdcymirezqsimhbdgkoqkeveffjeyuqzzcabnlneeunevzffzqrdqzpvrotauivsqoobyhhfrovmarbmiwkozsbxzgtlkqogxhgpiwaoohxgtudxbmgriieckkynwdrvtiphhexyjiffiftlusqfbjbhynwkgsgwomimghcoofqwncbyrwqvrpnakfnmwpjgoinjbjgzbhdwxphxzssjemoxbocbeplpjxofbclimmfzesayvjyvevmbzwnjpkbmixdndyviirqslmngejneutpurowunzulpirfhjwelexxewlhpvnuaogdyhreijboipuvlxyhcflbzeafrwbzwvctpiaawqnumzjyyhcuyhszlqnxqhyyzsbnfperufymvbdowzcjxdextmvpvvmyvaqltcfiuyevtnrvptbkrycjhffxqvtojzjrjjsbvmewjyjbhfqbezmhnvfaejnoxjyptpqhfnefaocructpdgdlqccgponcmvueyjveegflqbpntuwhragimcwrsclhugwvchxzejpedhssfbsobxhaaczpzesuwfwwibtgcubdouqzaajlmgddnikurslqekcrvfxzcseauvzxwhsmmegwwzvmqbrgnyycnsgbfstrexhlrljnvfszzdrhpcytwliawwxwuyarvwyxpabrenbnfawplxgguxrzjczxbovcsffnofeohgmmuuaaxjmfdokahdyrxluqkveyapicxdixcdnpmanygurkwihdznvexfqwuydylbmrjqyzwzceseqgwuhwfbcqavpooatzbjtvbjxxtjnnnpfclvrntodjjztkaitwvohdsvhubrrwabrgyjbxeolllqidfinfmxwbatlsbdmcmgkupnlkgraghjpgnpimsefmceojfbqhmetuwmuumdejbqfdmqkhivdxznirpaafeksvcxxuafbzajmgqaanxguasoftiytfpiroqrdnglihljdtwenkmazzsbpzesekhdgeqdqnangfpsdnqvpushjdfvefofwqhycxzfdpcoqteceycijdmqdmsbqitgupbtijlftnntpchbovrdujncmptdewjjvzbxstvlyhafshcxaxtgaorcgjnkernhboyjfhlskmgteyghuumcatmomdwcwmniwigrqfxwrqqdsvtlcsdcunvmqdggvlqobceqfcpvrouxsbzsxzunrcnroxwkfgxisskggyqlankgrcqlfzrsspyqwvjzflllpvgrlfokhsymvycqyuppvkfjqwbhzmqhysgpsfgvnltqwwtpdmzvhtzkwjggdxqkxjsrrhuihhsyufgjocrnbrrkesrlvbztkziuhngdnznfnybssklhhqfgthdgwkympqbnqgqvkdypqrlzzbwwzvplttfnrzzpedhmgebbnbvsshspejosdpljvkqzdtdgkzrpcrxkcclzrdzjdnawpedncbrwjfcwgjkhzddobqpywtsdmcqamcremktjenljyssirevynzdgsuifkgkunkaisxyzyvybbmspicmzwacbfmpjmziaakdibegfetrirgzvyemzpotkvczhzljltrqacdojtstvfnpsgvcyluxeeivkyhymqebdpbmcaxhdjquxplrutkwevfjtyxlxhnkqlkuopgxbqitkstgvggdyuxgkspbdluuznspgsnydworberrhgaubwvgrgwfpiwrwmxprpaqdbvqjbfvxahlvblldbuitdqciaishzwuxwcuhsunnfpdwiqrdnkwpguujylpjykjbjbdstgulffdtbolqhptlpyrnbvsobyksvesesibsvmvxldotlwrgylpizuqrpziyaywtvqmnfsipazhfwrqqmgrcfxrzakfmpedziealknutbdhhrrewajhmheqgfvhizyoylkczjynzndzhsxqoivwmzhygqjrjsaybcfjtavbcvcxnemuevceponuyebtkeyjcijjnaawyvszpdajlqoyowjsboetlbekxortdhdbkfsaigebgoklijbydfwfzxdbqojjzjmmreylauoiclzirpaihjkwcfrjiaoqhsuxyysuipgvhkvceypwosyluhilnrfrrzjbpiairftacdvpjztisdhhqcanvvyxrlbcslogboqajxosjlvsxkwyebjjwaasqriqvbaltydlsnydlayjdlcfdwhiypplikuayqphorbhisjygelgwqigjastycmzofdcknqmzbkgcmmaazvthbsoatoekyljydcpiuvjnzxcamynwyrsqwoopbejnkrkytbzeznztnkpmdnvxqwneetzeetaginzycycdsvoeyxbqahaamxigzcihywewwurnxonhhaeftrkhtdwbjehwnjltoveeanbhxmzprdwhqbyapwzbhcyprfucqqmvwrskyqnhkgfleukltbwvzautqnttdjitkswwsyaqedyophlauwhxzuadecqvtfautthqbzscnqexwraftvrglyfsjsvbqpddzqallwojkscciqmuwlcdtwmlqiokkpsvtlethiajtqtiiferyemnaxpsnhocwdinodgqmxlifxytzofeshurocidbwnndkknrachokvfroixeysrgqtxjcphnccxypizexztvtcyxxdjecpkutymhbrwbyhxyubrzbebyeickdfdthfzolredsqtazwuliwivmvlzegknjvcjutxlclyaselehcytbkbqncuplzarbyjfopigzohvmsggcsnptmvrdlfghaqiuquxusesbbcgmlumcyefgelsyvqafwcrbmycajmrlpnaefdhvwybrrxexubtidlcgyupnygpdgsyxpajgitqdcanxifeurmtgddsidvzbzfpgugvmmvfcvqmoclrwotxjjujshjkjyozgvbvvhkudbcppedyfmzelyphvzbhsvnsgvfammgxefykdpcbwbmdyfqfspofrmffkxwwjfiujephhurfljckcpeuxmzuidmkqgaoaxsbafycrctdkiabzbrsungdvhcgxebbvzaafnxylclischnmvyrpgxhtssvvezcinbdqcegzkaerrrxxitlubnhdlbamhficdbzxtsncixqmhfoneuvapzamewurzhjvmdxxbcoetyrvtetamnzawxxohmtvfwekennjinzlkjfayfumleqrtghjvwednfcrtvllynymywdwyxtkftxhqfscovsnimxcatomdelxskojnvfbqlqcbchizojeenzkpeewglrzlkoxjonlsdnhyfeuimhrsdhoxaaavfswtvzvilxycwjqnbimmtbzskcqggzvncptvkynawbqugztpbvtpfoteseozslzkxhfsepqhanhajldafdfmxsegcnfgkclkzsnitgjovvrklstxcihzctpilyfsmsktgksgjfpnvybdysvukxvuccfcfovkqsoukcwvftfeisaikgkjquhpcnnkvjqlgtjpfdhzuiqsierjxnuqppypfodlexzbwxablagfpjnsaathgipjvmbggiwrftmzjfbafwlsvaglhxmoudkbsqjvlvgvamodcclmksglqhefuicaexqeawitffonyxxjiehgfemeetianfcyoiglwiathxislbnfkqhowyesbsquqntxxvpkgetxbrnumeggtbtxbgqrsotfkbqpxmusgduujcffwrznzziwmztdhjpkcgaurnomlnncwaggcytlmnxynmaykcoschnozutxmjidvjbipywexztwnsdknbdahemvnqwdrasmrxrukearxqoqilkgzeddrplvooiffakwdvwbcpxvjkfdemajtddybcdvwauhcpeopqttogrydqyalnatiorvzqbtcchtyyeiffrrjfeuqichsinfnytdadfreimtcofuygnpmiuitntjuitlyjtcbrktqyszfqurnabotjqkdwldumknflohdvtxugvrivpbiwwhruzypaocuudozntlnhwnasfzunsccpahaejjsvsoiihfsoxntfdkxqhvjfjispvibnzokzfsptsvleaewjepsnnrnlpblhlzzvqyqpkesnirpvqypgxzczkxqojzuzddgooxosgpxenjazgwiognyfldppbvqktwbvtpstwbkkpjxngeqwdwigwmeqshcjmtuzwsdhijfiqtiaokzocrksakffzuzhsraxrrtpzwhrsaboqgbyqmmxhasxznuakuwdgabakgclkpfnyppiyqbnsstntemuoahifwltvgrgcootvvpwgunxiwpedeswbsaacastxkdroborpwwyjggwkwpumtpjigrqftnabeuxvzhdbxawpzidwudcfkgiaoyyslnntdikeibtoiraeofypprrkiuvqsjjahcpxwlczhutruzwblqddiyraqqigrcoxipoasnpijgoxvhcpinwjgmckahfapspuyqamtqajskuokbueijopqpefkzooovxfdxtehidfommgvkpvocdiwqspn",
        //    64740, 10415, 5446, 6635);

        //var j = w1.ElapsedMilliseconds;

        Console.ReadLine();

    }

    public static String SubStrHashJ(String s, int p, int m, int k, int hashValue)
    {
        long cur = 0, pk = 1;
        int res = 0, n = s.Length;
        for (int i = n - 1; i >= 0; --i)
        {
            cur = (cur * p + s[i] - 'a' + 1) % m;
            if (i + k >= n)
                pk = pk * p % m;
            else
                cur = (cur - (s[i + k] - 'a' + 1) * pk % m + m) % m;
            if (cur == hashValue)
                res = i;
        }
        return s.Substring(res, res + k);
    }

    public class Solution
    {
        public string SubStrHash(string s, int power, int modulo, int k, int hashValue)
        {
            var lastFirst = int.MaxValue;

            var map = new Dictionary<char, int>();
            for (var i = 1; i <= 26; i++)
            {
                map.Add((char)('a' + i - 1), i % modulo);
            }

            long kthPower = 1;
            for (var i = 1; i < k; i++)
            {
                kthPower = (kthPower * power) % modulo;
            }

            //var kthPower = BigInteger.Pow(power, k - 1) % modulo;
            var powerModulo = power % modulo;

            // Compute the first substring
            long current = 0;
            var start = s.Length - k;

            for (var i = s.Length - 1; i >= start; i--)
            {
                current = (current * powerModulo) % modulo;
                current = (current + map[s[i]]) % modulo;
            }

            if (current == hashValue)
            {
                lastFirst = start;
            }

            while (start >= 0)
            {
                current = ((current + modulo - ((map[s[start + k - 1]] * kthPower) % modulo))) % modulo;
                current = (current * powerModulo) % modulo;

                start--;

                if (start < 0)
                {
                    break;
                }

                current = (current + map[s[start]]) % modulo;

                if (current == hashValue)
                {
                    lastFirst = start;
                }
            }

            if (lastFirst == int.MaxValue)
            {
                return string.Empty;
            }

            return s.Substring(lastFirst, k);
        }
    }
}

