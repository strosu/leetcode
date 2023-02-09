﻿using System.Diagnostics;
using System.Numerics;

namespace SubstringHashValue;
class Program
{
    static void Main(string[] args)
    {
        var x = new Solution().SubStrHash("leetcode", 7, 20, 2, 0);
        //var x2 = new Solution().SubStrHash("xqgfatvtlwnnkxipmipcpqwbxihxblaplpfckvxtihonijhtezdnkjmmk", 22, 51, 41, 9);

        //Stopwatch w1 = new Stopwatch();
        //w1.Start();
        //var x3 = new Solution().SubStrHash("xvgvednpdymdueibaajtteuonorekecszwtznqnncqzmkiglvuzkvmiourabqrvkamtykwonqqnhscnqlpxsovpjftnstrubudrhypugbhinrcjatqixxnfcntyuxjjkvhdycmtfnwxsgfqntccppfxiaulhedjanavqzflocxgsulejjscsczlhkbuukuezuoaeyasnftzqxtllgqpcdtsmavesczcnvsydcyvyligntvjyowsnqwxkwdghhdvfesrvpyrwefjxfkzhgtqchoinffaspsmzwdzhwioudzedaqqdagohxldefznbnvxmzsuayzejjwbzrtfnmaktlbaauwhxtacdmrgrbkehrfbvghaeleeepbxsilvdgohwlcdyegzsceankyrfkwjpofdaollzfzrxzxkmkdutjhzqdjyxmlzavmpaerlbmkoqdvprgelpomqdjvkpxxnvhhxdaioudpcafdwltduudfrtzbfkkkonuchrdertgtakjatfobjqcvlktrhkclzlsmejtiozemrrwuqsasflxjuzkkzilitkqabynowdllilmhhiqfuxmilgfsvmnvvribnmvpvhtgbtldzhgstazfgwtklxylgjdqtvrguxpqaigceeulptrbihsyyhlpjjhmdselzniboglnlnjurlsqhrttwgtcivmbarahyaezgttaduotrabnbobwqursulnjgztghgxlcngodwsrusfnjzwcuzwvlporfrtpbeacvtbvoqrkmvrnbdtbflqbxublxkkzmfmjtftytkkngimtrppsogrqykotwcdvegkudttrpiqflvzuopuahltzsktksntdmtztxevrjivsjgfurypstbxprjdldxuhjobwfzqcnqurrqddzypzgozzgzvjkfhdjoaeotjiqoicsponotrjuwuipkgetlbhyzzooxvuikhpxbpgmaresgkvqzpgqiwuuxxqnmmwezwrzyzfepqouxsqtrctjjbscnvezxgnkdtichmlkfcktuhdbgkuowjlmcujvnjulmgpdgkmylpwmhrpitnxtlyoyjzxtxwxhnfakhxsdahciswuwrqrlknmqaxtgrnmptlhgvrsdyksaxbjssnqdvedppevaorflmtofgbdfaolwzrqqqjykcgtmnvyndngviyhllefkmqgajqrgakyghlledibvdqscnhjgbqnvlyukxjbipjncccmslfrrphpqxsyzqdjhdsifsiekgvlmatpkjwmrtjqwgzzolcflyuyqdqovgbavixcjbyifefrwtvwdhzxngxocthwkmqrklnjxpqcyaewrsppxiodpvobjwcdtrubmxgjiysjncdrxelmflcybljfkmwtxvnkjdvsnovodsvdvoqzymilcmhyotmuruttvgyxrbmomizfnigflrjteofbseqmzmcapjwowcjktgwyjquppuhqlnrbjwjdlapvitndiszwqnshzqazkxdlpdvzasfwmaktgrzyotmoxywurqbkmurlsiktboyzblkesrmbsgtdstkdcoyniyvblkxeiuxxrhkcfbhteaalrrbmzfbtxuimcfmktmkerifsfydrajabhypadrtzblexazdjsukncjkvjnczzdzvvunpebxftxsqiiegxwtieqbuhbrwwcrrcirhgevkddcnhyfxejtjtkywssffmdocxuxxwpvoftsswzwrglxfqzihawkpsfvoqwfskcdxhclqwawrcjiupbtzvevzrkmepfmhkcbtwmteyfdicydjtbqhdfyxjphgesveomauuxfaodeqbalkqhjotlmxhctaklehgwmqtvwdpecyfosrggulhmwkjjuqqzcyfejneyfsolhpermfusccteqdysrqigdfwmrjxqxeskzjipxfqhrhdnqanqtklawupddbannnrifvvncqecnfjtbukufitczrehsswaapbugvaaibenzniamgnokgrvvavceruerkxzxdpqioqjvdcymirezqsimhbdgkoqkeveffjeyuqzzcabnlneeunevzffzqrdqzpvrotauivsqoobyhhfrovmarbmiwkozsbxzgtlkqogxhgpiwaoohxgtudxbmgriieckkynwdrvtiphhexyjiffiftlusqfbjbhynwkgsgwomimghcoofqwncbyrwqvrpnakfnmwpjgoinjbjgzbhdwxphxzssjemoxbocbeplpjxofbclimmfzesayvjyvevmbzwnjpkbmixdndyviirqslmngejneutpurowunzulpirfhjwelexxewlhpvnuaogdyhreijboipuvlxyhcflbzeafrwbzwvctpiaawqnumzjyyhcuyhszlqnxqhyyzsbnfperufymvbdowzcjxdextmvpvvmyvaqltcfiuyevtnrvptbkrycjhffxqvtojzjrjjsbvmewjyjbhfqbezmhnvfaejnoxjyptpqhfnefaocructpdgdlqccgponcmvueyjveegflqbpntuwhragimcwrsclhugwvchxzejpedhssfbsobxhaaczpzesuwfwwibtgcubdouqzaajlmgddnikurslqekcrvfxzcseauvzxwhsmmegwwzvmqbrgnyycnsgbfstrexhlrljnvfszzdrhpcytwliawwxwuyarvwyxpabrenbnfawplxgguxrzjczxbovcsffnofeohgmmuuaaxjmfdokahdyrxluqkveyapicxdixcdnpmanygurkwihdznvexfqwuydylbmrjqyzwzceseqgwuhwfbcqavpooatzbjtvbjxxtjnnnpfclvrntodjjztkaitwvohdsvhubrrwabrgyjbxeolllqidfinfmxwbatlsbdmcmgkupnlkgraghjpgnpimsefmceojfbqhmetuwmuumdejbqfdmqkhivdxznirpaafeksvcxxuafbzajmgqaanxguasoftiytfpiroqrdnglihljdtwenkmazzsbpzesekhdgeqdqnangfpsdnqvpushjdfvefofwqhycxzfdpcoqteceycijdmqdmsbqitgupbtijlftnntpchbovrdujncmptdewjjvzbxstvlyhafshcxaxtgaorcgjnkernhboyjfhlskmgteyghuumcatmomdwcwmniwigrqfxwrqqdsvtlcsdcunvmqdggvlqobceqfcpvrouxsbzsxzunrcnroxwkfgxisskggyqlankgrcqlfzrsspyqwvjzflllpvgrlfokhsymvycqyuppvkfjqwbhzmqhysgpsfgvnltqwwtpdmzvhtzkwjggdxqkxjsrrhuihhsyufgjocrnbrrkesrlvbztkziuhngdnznfnybssklhhqfgthdgwkympqbnqgqvkdypqrlzzbwwzvplttfnrzzpedhmgebbnbvsshspejosdpljvkqzdtdgkzrpcrxkcclzrdzjdnawpedncbrwjfcwgjkhzddobqpywtsdmcqamcremktjenljyssirevynzdgsuifkgkunkaisxyzyvybbmspicmzwacbfmpjmziaakdibegfetrirgzvyemzpotkvczhzljltrqacdojtstvfnpsgvcyluxeeivkyhymqebdpbmcaxhdjquxplrutkwevfjtyxlxhnkqlkuopgxbqitkstgvggdyuxgkspbdluuznspgsnydworberrhgaubwvgrgwfpiwrwmxprpaqdbvqjbfvxahlvblldbuitdqciaishzwuxwcuhsunnfpdwiqrdnkwpguujylpjykjbjbdstgulffdtbolqhptlpyrnbvsobyksvesesibsvmvxldotlwrgylpizuqrpziyaywtvqmnfsipazhfwrqqmgrcfxrzakfmpedziealknutbdhhrrewajhmheqgfvhizyoylkczjynzndzhsxqoivwmzhygqjrjsaybcfjtavbcvcxnemuevceponuyebtkeyjcijjnaawyvszpdajlqoyowjsboetlbekxortdhdbkfsaigebgoklijbydfwfzxdbqojjzjmmreylauoiclzirpaihjkwcfrjiaoqhsuxyysuipgvhkvceypwosyluhilnrfrrzjbpiairftacdvpjztisdhhqcanvvyxrlbcslogboqajxosjlvsxkwyebjjwaasqriqvbaltydlsnydlayjdlcfdwhiypplikuayqphorbhisjygelgwqigjastycmzofdcknqmzbkgcmmaazvthbsoatoekyljydcpiuvjnzxcamynwyrsqwoopbejnkrkytbzeznztnkpmdnvxqwneetzeetaginzycycdsvoeyxbqahaamxigzcihywewwurnxonhhaeftrkhtdwbjehwnjltoveeanbhxmzprdwhqbyapwzbhcyprfucqqmvwrskyqnhkgfleukltbwvzautqnttdjitkswwsyaqedyophlauwhxzuadecqvtfautthqbzscnqexwraftvrglyfsjsvbqpddzqallwojkscciqmuwlcdtwmlqiokkpsvtlethiajtqtiiferyemnaxpsnhocwdinodgqmxlifxytzofeshurocidbwnndkknrachokvfroixeysrgqtxjcphnccxypizexztvtcyxxdjecpkutymhbrwbyhxyubrzbebyeickdfdthfzolredsqtazwuliwivmvlzegknjvcjutxlclyaselehcytbkbqncuplzarbyjfopigzohvmsggcsnptmvrdlfghaqiuquxusesbbcgmlumcyefgelsyvqafwcrbmycajmrlpnaefdhvwybrrxexubtidlcgyupnygpdgsyxpajgitqdcanxifeurmtgddsidvzbzfpgugvmmvfcvqmoclrwotxjjujshjkjyozgvbvvhkudbcppedyfmzelyphvzbhsvnsgvfammgxefykdpcbwbmdyfqfspofrmffkxwwjfiujephhurfljckcpeuxmzuidmkqgaoaxsbafycrctdkiabzbrsungdvhcgxebbvzaafnxylclischnmvyrpgxhtssvvezcinbdqcegzkaerrrxxitlubnhdlbamhficdbzxtsncixqmhfoneuvapzamewurzhjvmdxxbcoetyrvtetamnzawxxohmtvfwekennjinzlkjfayfumleqrtghjvwednfcrtvllynymywdwyxtkftxhqfscovsnimxcatomdelxskojnvfbqlqcbchizojeenzkpeewglrzlkoxjonlsdnhyfeuimhrsdhoxaaavfswtvzvilxycwjqnbimmtbzskcqggzvncptvkynawbqugztpbvtpfoteseozslzkxhfsepqhanhajldafdfmxsegcnfgkclkzsnitgjovvrklstxcihzctpilyfsmsktgksgjfpnvybdysvukxvuccfcfovkqsoukcwvftfeisaikgkjquhpcnnkvjqlgtjpfdhzuiqsierjxnuqppypfodlexzbwxablagfpjnsaathgipjvmbggiwrftmzjfbafwlsvaglhxmoudkbsqjvlvgvamodcclmksglqhefuicaexqeawitffonyxxjiehgfemeetianfcyoiglwiathxislbnfkqhowyesbsquqntxxvpkgetxbrnumeggtbtxbgqrsotfkbqpxmusgduujcffwrznzziwmztdhjpkcgaurnomlnncwaggcytlmnxynmaykcoschnozutxmjidvjbipywexztwnsdknbdahemvnqwdrasmrxrukearxqoqilkgzeddrplvooiffakwdvwbcpxvjkfdemajtddybcdvwauhcpeopqttogrydqyalnatiorvzqbtcchtyyeiffrrjfeuqichsinfnytdadfreimtcofuygnpmiuitntjuitlyjtcbrktqyszfqurnabotjqkdwldumknflohdvtxugvrivpbiwwhruzypaocuudozntlnhwnasfzunsccpahaejjsvsoiihfsoxntfdkxqhvjfjispvibnzokzfsptsvleaewjepsnnrnlpblhlzzvqyqpkesnirpvqypgxzczkxqojzuzddgooxosgpxenjazgwiognyfldppbvqktwbvtpstwbkkpjxngeqwdwigwmeqshcjmtuzwsdhijfiqtiaokzocrksakffzuzhsraxrrtpzwhrsaboqgbyqmmxhasxznuakuwdgabakgclkpfnyppiyqbnsstntemuoahifwltvgrgcootvvpwgunxiwpedeswbsaacastxkdroborpwwyjggwkwpumtpjigrqftnabeuxvzhdbxawpzidwudcfkgiaoyyslnntdikeibtoiraeofypprrkiuvqsjjahcpxwlczhutruzwblqddiyraqqigrcoxipoasnpijgoxvhcpinwjgmckahfapspuyqamtqajskuokbueijopqpefkzooovxfdxtehidfommgvkpvocdiwqspn",
        //    64740, 10415, 5446, 6635);

        //var c = w1.ElapsedMilliseconds;
        //w1.Reset();

        //var xj = new Solution().SubStrHashJ("xvgvednpdymdueibaajtteuonorekecszwtznqnncqzmkiglvuzkvmiourabqrvkamtykwonqqnhscnqlpxsovpjftnstrubudrhypugbhinrcjatqixxnfcntyuxjjkvhdycmtfnwxsgfqntccppfxiaulhedjanavqzflocxgsulejjscsczlhkbuukuezuoaeyasnftzqxtllgqpcdtsmavesczcnvsydcyvyligntvjyowsnqwxkwdghhdvfesrvpyrwefjxfkzhgtqchoinffaspsmzwdzhwioudzedaqqdagohxldefznbnvxmzsuayzejjwbzrtfnmaktlbaauwhxtacdmrgrbkehrfbvghaeleeepbxsilvdgohwlcdyegzsceankyrfkwjpofdaollzfzrxzxkmkdutjhzqdjyxmlzavmpaerlbmkoqdvprgelpomqdjvkpxxnvhhxdaioudpcafdwltduudfrtzbfkkkonuchrdertgtakjatfobjqcvlktrhkclzlsmejtiozemrrwuqsasflxjuzkkzilitkqabynowdllilmhhiqfuxmilgfsvmnvvribnmvpvhtgbtldzhgstazfgwtklxylgjdqtvrguxpqaigceeulptrbihsyyhlpjjhmdselzniboglnlnjurlsqhrttwgtcivmbarahyaezgttaduotrabnbobwqursulnjgztghgxlcngodwsrusfnjzwcuzwvlporfrtpbeacvtbvoqrkmvrnbdtbflqbxublxkkzmfmjtftytkkngimtrppsogrqykotwcdvegkudttrpiqflvzuopuahltzsktksntdmtztxevrjivsjgfurypstbxprjdldxuhjobwfzqcnqurrqddzypzgozzgzvjkfhdjoaeotjiqoicsponotrjuwuipkgetlbhyzzooxvuikhpxbpgmaresgkvqzpgqiwuuxxqnmmwezwrzyzfepqouxsqtrctjjbscnvezxgnkdtichmlkfcktuhdbgkuowjlmcujvnjulmgpdgkmylpwmhrpitnxtlyoyjzxtxwxhnfakhxsdahciswuwrqrlknmqaxtgrnmptlhgvrsdyksaxbjssnqdvedppevaorflmtofgbdfaolwzrqqqjykcgtmnvyndngviyhllefkmqgajqrgakyghlledibvdqscnhjgbqnvlyukxjbipjncccmslfrrphpqxsyzqdjhdsifsiekgvlmatpkjwmrtjqwgzzolcflyuyqdqovgbavixcjbyifefrwtvwdhzxngxocthwkmqrklnjxpqcyaewrsppxiodpvobjwcdtrubmxgjiysjncdrxelmflcybljfkmwtxvnkjdvsnovodsvdvoqzymilcmhyotmuruttvgyxrbmomizfnigflrjteofbseqmzmcapjwowcjktgwyjquppuhqlnrbjwjdlapvitndiszwqnshzqazkxdlpdvzasfwmaktgrzyotmoxywurqbkmurlsiktboyzblkesrmbsgtdstkdcoyniyvblkxeiuxxrhkcfbhteaalrrbmzfbtxuimcfmktmkerifsfydrajabhypadrtzblexazdjsukncjkvjnczzdzvvunpebxftxsqiiegxwtieqbuhbrwwcrrcirhgevkddcnhyfxejtjtkywssffmdocxuxxwpvoftsswzwrglxfqzihawkpsfvoqwfskcdxhclqwawrcjiupbtzvevzrkmepfmhkcbtwmteyfdicydjtbqhdfyxjphgesveomauuxfaodeqbalkqhjotlmxhctaklehgwmqtvwdpecyfosrggulhmwkjjuqqzcyfejneyfsolhpermfusccteqdysrqigdfwmrjxqxeskzjipxfqhrhdnqanqtklawupddbannnrifvvncqecnfjtbukufitczrehsswaapbugvaaibenzniamgnokgrvvavceruerkxzxdpqioqjvdcymirezqsimhbdgkoqkeveffjeyuqzzcabnlneeunevzffzqrdqzpvrotauivsqoobyhhfrovmarbmiwkozsbxzgtlkqogxhgpiwaoohxgtudxbmgriieckkynwdrvtiphhexyjiffiftlusqfbjbhynwkgsgwomimghcoofqwncbyrwqvrpnakfnmwpjgoinjbjgzbhdwxphxzssjemoxbocbeplpjxofbclimmfzesayvjyvevmbzwnjpkbmixdndyviirqslmngejneutpurowunzulpirfhjwelexxewlhpvnuaogdyhreijboipuvlxyhcflbzeafrwbzwvctpiaawqnumzjyyhcuyhszlqnxqhyyzsbnfperufymvbdowzcjxdextmvpvvmyvaqltcfiuyevtnrvptbkrycjhffxqvtojzjrjjsbvmewjyjbhfqbezmhnvfaejnoxjyptpqhfnefaocructpdgdlqccgponcmvueyjveegflqbpntuwhragimcwrsclhugwvchxzejpedhssfbsobxhaaczpzesuwfwwibtgcubdouqzaajlmgddnikurslqekcrvfxzcseauvzxwhsmmegwwzvmqbrgnyycnsgbfstrexhlrljnvfszzdrhpcytwliawwxwuyarvwyxpabrenbnfawplxgguxrzjczxbovcsffnofeohgmmuuaaxjmfdokahdyrxluqkveyapicxdixcdnpmanygurkwihdznvexfqwuydylbmrjqyzwzceseqgwuhwfbcqavpooatzbjtvbjxxtjnnnpfclvrntodjjztkaitwvohdsvhubrrwabrgyjbxeolllqidfinfmxwbatlsbdmcmgkupnlkgraghjpgnpimsefmceojfbqhmetuwmuumdejbqfdmqkhivdxznirpaafeksvcxxuafbzajmgqaanxguasoftiytfpiroqrdnglihljdtwenkmazzsbpzesekhdgeqdqnangfpsdnqvpushjdfvefofwqhycxzfdpcoqteceycijdmqdmsbqitgupbtijlftnntpchbovrdujncmptdewjjvzbxstvlyhafshcxaxtgaorcgjnkernhboyjfhlskmgteyghuumcatmomdwcwmniwigrqfxwrqqdsvtlcsdcunvmqdggvlqobceqfcpvrouxsbzsxzunrcnroxwkfgxisskggyqlankgrcqlfzrsspyqwvjzflllpvgrlfokhsymvycqyuppvkfjqwbhzmqhysgpsfgvnltqwwtpdmzvhtzkwjggdxqkxjsrrhuihhsyufgjocrnbrrkesrlvbztkziuhngdnznfnybssklhhqfgthdgwkympqbnqgqvkdypqrlzzbwwzvplttfnrzzpedhmgebbnbvsshspejosdpljvkqzdtdgkzrpcrxkcclzrdzjdnawpedncbrwjfcwgjkhzddobqpywtsdmcqamcremktjenljyssirevynzdgsuifkgkunkaisxyzyvybbmspicmzwacbfmpjmziaakdibegfetrirgzvyemzpotkvczhzljltrqacdojtstvfnpsgvcyluxeeivkyhymqebdpbmcaxhdjquxplrutkwevfjtyxlxhnkqlkuopgxbqitkstgvggdyuxgkspbdluuznspgsnydworberrhgaubwvgrgwfpiwrwmxprpaqdbvqjbfvxahlvblldbuitdqciaishzwuxwcuhsunnfpdwiqrdnkwpguujylpjykjbjbdstgulffdtbolqhptlpyrnbvsobyksvesesibsvmvxldotlwrgylpizuqrpziyaywtvqmnfsipazhfwrqqmgrcfxrzakfmpedziealknutbdhhrrewajhmheqgfvhizyoylkczjynzndzhsxqoivwmzhygqjrjsaybcfjtavbcvcxnemuevceponuyebtkeyjcijjnaawyvszpdajlqoyowjsboetlbekxortdhdbkfsaigebgoklijbydfwfzxdbqojjzjmmreylauoiclzirpaihjkwcfrjiaoqhsuxyysuipgvhkvceypwosyluhilnrfrrzjbpiairftacdvpjztisdhhqcanvvyxrlbcslogboqajxosjlvsxkwyebjjwaasqriqvbaltydlsnydlayjdlcfdwhiypplikuayqphorbhisjygelgwqigjastycmzofdcknqmzbkgcmmaazvthbsoatoekyljydcpiuvjnzxcamynwyrsqwoopbejnkrkytbzeznztnkpmdnvxqwneetzeetaginzycycdsvoeyxbqahaamxigzcihywewwurnxonhhaeftrkhtdwbjehwnjltoveeanbhxmzprdwhqbyapwzbhcyprfucqqmvwrskyqnhkgfleukltbwvzautqnttdjitkswwsyaqedyophlauwhxzuadecqvtfautthqbzscnqexwraftvrglyfsjsvbqpddzqallwojkscciqmuwlcdtwmlqiokkpsvtlethiajtqtiiferyemnaxpsnhocwdinodgqmxlifxytzofeshurocidbwnndkknrachokvfroixeysrgqtxjcphnccxypizexztvtcyxxdjecpkutymhbrwbyhxyubrzbebyeickdfdthfzolredsqtazwuliwivmvlzegknjvcjutxlclyaselehcytbkbqncuplzarbyjfopigzohvmsggcsnptmvrdlfghaqiuquxusesbbcgmlumcyefgelsyvqafwcrbmycajmrlpnaefdhvwybrrxexubtidlcgyupnygpdgsyxpajgitqdcanxifeurmtgddsidvzbzfpgugvmmvfcvqmoclrwotxjjujshjkjyozgvbvvhkudbcppedyfmzelyphvzbhsvnsgvfammgxefykdpcbwbmdyfqfspofrmffkxwwjfiujephhurfljckcpeuxmzuidmkqgaoaxsbafycrctdkiabzbrsungdvhcgxebbvzaafnxylclischnmvyrpgxhtssvvezcinbdqcegzkaerrrxxitlubnhdlbamhficdbzxtsncixqmhfoneuvapzamewurzhjvmdxxbcoetyrvtetamnzawxxohmtvfwekennjinzlkjfayfumleqrtghjvwednfcrtvllynymywdwyxtkftxhqfscovsnimxcatomdelxskojnvfbqlqcbchizojeenzkpeewglrzlkoxjonlsdnhyfeuimhrsdhoxaaavfswtvzvilxycwjqnbimmtbzskcqggzvncptvkynawbqugztpbvtpfoteseozslzkxhfsepqhanhajldafdfmxsegcnfgkclkzsnitgjovvrklstxcihzctpilyfsmsktgksgjfpnvybdysvukxvuccfcfovkqsoukcwvftfeisaikgkjquhpcnnkvjqlgtjpfdhzuiqsierjxnuqppypfodlexzbwxablagfpjnsaathgipjvmbggiwrftmzjfbafwlsvaglhxmoudkbsqjvlvgvamodcclmksglqhefuicaexqeawitffonyxxjiehgfemeetianfcyoiglwiathxislbnfkqhowyesbsquqntxxvpkgetxbrnumeggtbtxbgqrsotfkbqpxmusgduujcffwrznzziwmztdhjpkcgaurnomlnncwaggcytlmnxynmaykcoschnozutxmjidvjbipywexztwnsdknbdahemvnqwdrasmrxrukearxqoqilkgzeddrplvooiffakwdvwbcpxvjkfdemajtddybcdvwauhcpeopqttogrydqyalnatiorvzqbtcchtyyeiffrrjfeuqichsinfnytdadfreimtcofuygnpmiuitntjuitlyjtcbrktqyszfqurnabotjqkdwldumknflohdvtxugvrivpbiwwhruzypaocuudozntlnhwnasfzunsccpahaejjsvsoiihfsoxntfdkxqhvjfjispvibnzokzfsptsvleaewjepsnnrnlpblhlzzvqyqpkesnirpvqypgxzczkxqojzuzddgooxosgpxenjazgwiognyfldppbvqktwbvtpstwbkkpjxngeqwdwigwmeqshcjmtuzwsdhijfiqtiaokzocrksakffzuzhsraxrrtpzwhrsaboqgbyqmmxhasxznuakuwdgabakgclkpfnyppiyqbnsstntemuoahifwltvgrgcootvvpwgunxiwpedeswbsaacastxkdroborpwwyjggwkwpumtpjigrqftnabeuxvzhdbxawpzidwudcfkgiaoyyslnntdikeibtoiraeofypprrkiuvqsjjahcpxwlczhutruzwblqddiyraqqigrcoxipoasnpijgoxvhcpinwjgmckahfapspuyqamtqajskuokbueijopqpefkzooovxfdxtehidfommgvkpvocdiwqspn",
        //    64740, 10415, 5446, 6635);

        //var j = w1.ElapsedMilliseconds;

        Console.ReadLine();
    }

    public class Solution
    {
        public String SubStrHashJ(String s, int p, int m, int k, int hashValue)
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

        public string SubStrHash(string s, int power, int modulo, int k, int hashValue)
        {
            var watch = new Stopwatch();
            watch.Start();
            Console.WriteLine(watch.ElapsedMilliseconds);

            var lastFirst = int.MaxValue;

            var map = new Dictionary<char, int>();
            for (var i = 1; i <= 26; i++)
            {
                map.Add((char)('a' + i - 1), i % modulo);
            }

            var kthPower = 1;
            for (var i = 1; i < k; i++)
            {
                kthPower = (kthPower * (power % modulo)) % modulo;
            }

            //var kthPower = BigInteger.Pow(power, k - 1) % modulo;
            var powerModulo = power % modulo;

            // Compute the first substring

            int current = 0;
            var start = s.Length - k;

            for (var i = start; i < s.Length; i++)
            {
                current = (current * powerModulo) % modulo;
                current = (current + (map[s[i]]) % modulo) % modulo;
            }

            if (current % modulo == hashValue)
            {
                lastFirst = start;
            }

            while (start >= 0)
            {
                current = (current + modulo - ((map[s[start + k - 1]] * kthPower) % modulo));
                current = (current * powerModulo) % modulo;

                if (start < 0)
                {
                    break;
                }

                current = (current + (map[s[start]]) % modulo) % modulo;

                if (current == hashValue)
                {
                    lastFirst = start;
                }
            }

            return s.Substring(lastFirst, k);
        }
    }
}

