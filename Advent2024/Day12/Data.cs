﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day12
{
    internal class Data
    {
        public static string InputDataXX = @"AAAA
BBCD
BBCC
EEEC";

        public static string InputDataDD = @"OOOOO
OXOXO
OOOOO
OXOXO
OOOOO";

        public static string InputDataRR = @"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE";

        public static string InputData = @"KKKKKKZZZZZZZZDDQQQQXXXXXXXXXXXXTTTTTTTTTTTTDHHHHHHHHHHHHHHHHHGGGGGGPPPGUUGGXXGGGGGGJJJJJJJJJIIIIIIIIIIIIIIIIIIIIDIIIIIIIIIIIKIIIIIIIIIIIIIM
KKKKKKZZZZZZZDDDQQQQXXCXXXXXXXXXTTTTTTTTTTTTTHHHHHHHHHHHHHHHHHGGGGGGGGPGUUGGGGGGGGGJJJJJJJJIIIIIIIIIIIIIIIIIIVVVIDDIIIIIIIKKKKIIIIIIIIIIIIMM
KKKKKZZZZZZZZZZQQQQQQXCCCXXXXXXTTTTTTTTTTTTTTTHHHHHHHHHHHHHHHGGGGGGGGGGGGGGGGGGGGJJJJJJJJJJIIIIIIIIIIIIIIIIIIVIIIIDIHIIIIIIIKKIIIIIIIIIIIIMM
KKKKKZZZZZZZZEEHQQQYQQZCCCCXXXTTTTTTTTTTTTTTHHHIIIIHHHHHHHHHHGGGGGGGGGGGGGGGGGGGGGJJJJJJJJIIIIIIIIKKKKKKIIIIIVIIIIDHHIIIIIIIIKIIIIIIIIIIIIIM
KKKKKKOOEZEEEEHHQQQYYCCCCCCTTTTTTTTTTTTTTTTTVVVIIIIHHHHHHBBBBGGGGGGGGGGGGGGGGGGGGJJJJJJJJJIIIIIIIBCKKKKKIIIIIIIIHHHHHIIIIIIIIIIIIIIIIIIIMMMM
KKKKKOOEEEEEEEHHHQQYYCCCCCCCCCTTTTTTTTTTTOOTTIIIIIHHHHHHHHHBBBGGGGGGGGGGGGGGGGGGGJJJJJJJJJIIIIIBBBCKKKKKKKIIIIIHHHHHIIIIIIIIIIIIIIIIIIIIIIMM
KKKKKKOGGEEEGHHHHQDDYYCCCCCCCOOTTTTTTTTTTTIDIIIIIIIHHHHHHBBBBBGGGGGGGGGGGGGGGGGGGGJJJJJJJJIIIIBBBBKKKKKKKKIKIIIBHHHHHIIIIIIIIIIIIIIIIIIIIIIM
KKKKTKOOGEGGGHGHDDDDDYYYCCCCCOOTTTTTTTTTTIIIIIIIIIIHHHHHBBBBBBGGGGGJGGGQGGLGGGGGGJJJJJJRRJJJBBBBKKKKKKKKKKKKKKFHHHHHHHIHHIIIIIRIIIIIIIIIIMMM
KRRRVOOGGGGGGGGGDDDDPDDYDSSCCCOOOTTOTTTTTIIIIIIIIIIHHHBHBBBBBBGGGGGJGJJGGGGGGGGGGJJJJJRRRRRWBBBBBBVKKKKKKKKKKTHHHHHHHHHHIIIIIIIIIIIIIIGIIMMM
YVRVVOOGGGGGGGDDDDDDDDDDDSSCCOOOOOOOTOOOIIIIIIIIIIIHHBBBBBBBBBGGGGGJJJJJGGGCGGFFGFFJRRRRRRRWWBBBBBBKKKKKKKKKKKHHHHHHHHHFFIIIIIIIIIIIIIGIVVMM
YVRVVVVGGGGGGGDDDDDDDDDDDDDCCOOOOOOOOOOOIIIIIIIIIIIHHHBBBBBBBBBBGGJJJJJJJJJGGGFFFFRRRRRRRRRRRBBBBBKKKKKKKKKKKKKHHHHHHHHFIIIIIIIIIIIIIIIIVVVM
YVVVVVVVVGGGGGGDDDDDDDDDDDDOOOOOOOOOOOOOOIIIIIIEEIIHHHOBBBBBBBBBBGJJJJJJJJJFFFFFFFFFRRRRRRRRRRBBBBKBKKKKKKKKKKKHHHHHHFFFFIIFIIIIZIIAIIIIVVMM
VVVVVVVVVGGGGGGDDDDDDDDDDDOOOOOOOOOOOOOOOOOOOIOOEJJHHHOBBBBBBBBBBEEJEEEEEFFFFFFFFFFFRRRRRRRNBBBBBBBBKKKKKKKKKKRHHHHHHFFFFFFFIIIIIIIIBBIIVMMM
VVVVVVVVVGGGGGDDDDDDDDDDDDEOOOOOOOOOOOOOOOOOOOOOEEJHHOOOBBBBGGGGBEEEHEEXFFFFFFFFFFFFRRRRRRBNBBBBBBBBKKKKKKKKKKHHHHHHHFFFFFFFIIIIIIIIBBVVVMMM
VVVVVVVVGGGGGDPDDDDDDDDDDDEEOOOOOOOOOOOOOOOOOOOOEEJEOOOOBGGGGGGGHEEEEEEFFFLFFFFFFFFRRRRRRRBBBBBBBBBBBKKKKKKKKFHHHHHFFFFFFFFIIIIIIIIIIVVVVVMM
VVVVVVVVGGGGGDDDDDDDDDDDDDDEOOOOOOOOGOOOOOEOIIOOEEEEOOOOOGGGGGGGEEEEEEEFFFFFFFFFFFFFRDRRXXBBBBBBBBBBBKKKKKKKKKBBHHHHFFFFFFFIIIIIIIIIVVVVVVLM
VVVVVVVVWGGGGDDDDDDDDDDDDEEEOOOOOOGGGOOOOOOIIIIIEEOOOOBOOGGGGGGGUEEEEEGUFFFFFFFFFFFFDDDDMMSBBBBBBBBBBBBBKKKKKKBBBHHFFFFFFFFIIIIINNWIVVVVVVLL
VVVVVVZZZFGGGRDDDDDDDDDDDEOOOOOOOFFFGOGOOIIIBIBBBEOBBBBBBGGGGGGGEEEEEGGUUFFFFFFFFFFFDDDDDMMMBBBBBBBBBBBKKKKKKBBBBHHFFFFFFFFFIINNNNNPPVVVVLLL
VVVZZZZZZZIGRRADADDDDDDDDEOEEOYYGFFGGOGGGIIIBBBBBEBBBBBBBGGGGGGGFEEEGGGGUUFFFFFFFFFHDVVVVVVMBBBBBBBBBBBKKKKBBBBBBBBBFFFFFFFRRRRNNNNPPVVLLLLL
VVZZZZZZZZZRRRADAADEEEDDDEEEEOYYGGGGGGGGGGIBBBBBBBBBBBBBBGGGGGGGEEEEBGGGUUFFFFFFFFFHHVVVVVVMBBBBBBBBBPBKKBBBBBBBBBBFFFFFFFFFRBRNNNNNNNVLLLLL
VZZZZZBZZZNAAAAAAAAEEEEEEEEEGGYYGGGGGGGGGIIBBBBBBBBBBBBBBGGGGGFFFEEBBGGGGCFFFFFFFFFHHVVVVVVMBBBBBBBMMMMMBBBBBBBGBBBFFFFFFFGGBBBNNNNNLLLLLLLL
BBBBBBBZZNNNAAAAAAEEEEEEGEEEEGYYGGGGGGGIIIIBBBBBBBBBBBBBBGGGGGFFCCCBGGGCCCFCCWWWWWWWHVVVVVVMMBBBMMMMMMMMBBBBBBBGBGGTTFFFFFFFFBBNNNNNLLLLLLLL
JBBBBBBBZZNAAAAAAAAAAGGGGGGEGGGGGGGGGGGGGIHDBBBBBBBBBBBBBBFFFFFCCCCCGGGCCKCCCWHHHHHHHVVVVVVMMVVVVVVMMMMMBBBBBBGGBGGTFFFFTFFFFBBBBBBBBBLLLLLL
JJJBBBBBBAAAAAAAAAAAGGGGGGGEGGGGGGGGGGGGIIHDBBBBBBBBBBBBBBBBFFFCZCCCCCCCCCCCCHHHHHHHHVVVVVVMMVVVVVVMMMMMBBBBBBGGGGGTTFFTTFFFBBBBBBBBBBLLLLLL
JJJBBBBAAAAAAAAAAAAAGGGGGGGGGGGGGGGGGGGGIHHDHHHHBBBBBBSSSSFFFFFCCCCCCCCCCCCCCHHHHHHHHVVVVVVHHVVVVVVMMMMMBBBBBBGGGGGTTTTTTFHFBBBBBBBBBBBLBBLV
JJJJJJAAAAAAAAAAAAAAGGGGGGGGGGGGGGGGGGGHHHHHHHHHHIJJJJJSSSSFFFCCFFCCCCCCCCCCCHHHHHHHHVVVVVVVVVVVVVVMMMMMMBBBBGGGGGGGGGTTTLLBBBBBBBBBBBBBBBBV
JJJJJJAAAAAAAAAAAAAAGAAGGGGGGGGGGGGGGGGHHHHHHHHHHJJJHJSSSSSFFFFFFCCCCCCCCCCCCHRHHHHHHVVVVVVVVVVVVVVGMMMMMBBBBGGGGGGGGGTTLLLLLLBBBBBBBBBBBBBB
JJJJJJAAAAAAAAAAAAAAAAGGGGGGGGHGGGGGGGGHHHHHHHHHHJJJJJJJSJSFFFFFCCCCCCCCCCCCCCHHHHHHHVVVVVVVVVVVVVVGGMMCMBBBGGGGGGGGPGGGLLZLLLBBBBBBBBBBBBBB
JJJJJJAAAAAAAAAAAAAAGAGGGGGGGGGGGGZZGHGHHHHHHHHHJJJJJJJJJJSFFFFFCCCCCCCCCCCCCCHHHHHHHHHOHHOOMVVVVVVGGJGGIBBBTGGGGGGTGGGLLLLLLLLBBBBBBBBBBBBB
JJJJJAAAAXAAAAAAAAAAGGGGGGGGGGGGGGZEEEEEEEHHHHHHJJJJJJJJJJFFFFRFFFFCCCCCCCCCCCCHHHHHHHHOOOOOMVVVVVVGGGGGGKKKGGGGGGGTGGGLLLLLLLLLBBBBBBZBZBBB
JJJJJJJJXXAAAAAAAAAAGGGGGGGGGGGGGGZEEEEEEEHHHHHHJJJJJJJJJJJFFFRRFFFCCCCCCCCCICCHHHHHHIIOOOOOOGGGGGGGGGGGKKKKKGGFGGGGGGGLLLLLLLLLLBBBBZZBZZZE
JJJJJJJJJJAAAAAAAARGGGGGGGGGGGGGZZZEEEEEEEHHHHHJJJJJJJJJJJJFRRRRRRFFIICCCCIIIICHCCHYYIIOOOOOGGGGGGGGGGGGGGKKKGGGGGDDDDDPLLLLLLLBBBBBBZZZZZZZ
JJJJJJJJJJAARRRRRRRRGGGGGGGGGGGGZZZEEEEEEEHHHHHJJJJJJJJJJJJJRRRRRRFFFIIIIIIICICCCCCIIIIOOOOOGGGGGGGGGOJJJKKKYRGYLLLLLLLPPLLLLILBBBBBBZZZZZZZ
JJJJJJJJJJJRRRRRRRRRRGGGGGGGGGGGZRZEEEEEEEHHHHHHHJJJJJJJJJJWRRRRRRFRFIIIIISSSSSSSSSCIIIIIIIOOOGGGGGGGGJJJKYYYRYYLLLLLLLPLLLRLLLLBBBBBZZZZZGU
JJJJJJJJJJRRRRRRRRRRGGGGGGGGGGGRRRREEEEEEEHHHHHHHHHJJTJJJWWWRRRRRRRRRIIIIISSSSSSSSSIIIIIIIIOOOGGGGGYYGJJYYYYYYYLLLLLLLLPPRRRLLPYBBBBBZZZZZZU
IJJJJJJJJJRRRRRRRRRRRRRGGGGGGGGGRRREEEEEEEHHHHHHHHHJJTJTJWWRRRRRRRQQQIIIISSSSSSSSSSIIIIIIOOOOOOOJYYYGGJJJYYYYYLLLLLLLLLPPPPRLYYYYBBBBZZZZZZU
IJJJCCCJJRRRPRRRRRRRRRGGGGGGGRRRRRREEEEEEEHHHHHHHHHHJTTTAWAAAARRRRRIIIIIISSSSSSSSSSIIIIIIIIIOOJJJJJJGJJJJLLLLLLLLLLLLLLPPPPPYYYYBBBBUZZZZUUU
IJJJCCCPPPPPPPPRRRDDDRGGRGGRRRRRRRCEEEEEEEHHHHHHHHHHJJTTAAAAAARRRRRIIIIIISSSSSSSSSSIIIDDDDDXFOJJJJJJJJJJYLLLLLLLLLLLLLLPPYYYYYYYYYUUUUZUUUUU
IJIJCPPPPPPPPPDRRDDDDRRRRRRRRRRRRRGGGGGCCHHHHHHHHHIIJJAAAAAAAAAARRIIIIIIISSSSSSSSSSIIIDDDDDIFOJJJJJJJJJJJLLLLLLLLLLLLLLPYYYYYYYYYYUUUUUUUUUU
IIIIPPPPPPPPPPDDRRDDDDRRRRRRRRRRRRWWGGGGCHHHHHHHHHHIIIAIIAAIIIIIIIIIIISSSSSSSIIIIIIIIIDDDDDFFJJJJJJJJJJJJJHYYYYLLLLLLLLYYYYYYYYYYUUFUUUUUUUU
IIIIIIPPYPPPPPPDDDDDDDRRRNRRRRRRRWWWUUPPHHHHHHHHHHHIIIIIIAAIIIIIIIIIIISSSSSSSIIIRRIIIIDDDDDFFJJJJJJJJJJJJJHHCYYLLLLLLLLYYYYYYXXYKKTTTUTTUUUU
IIIIIIIXPPPPPPPDDDDDDDDDRNNRRRRRRWWUUUUPHHHHHHHHHHIIIIICIIIIIIIIISSSSSSSSSSSSIISUUIIIIDDDDDFFJJJJJJJJJJJJJJHCCCLLLLLLLLLLYYYXXXXKKTTTTTTUUUU
IIIIIIIXPPPPPPPPDDDDDDDDNNNNGUBBBUWWUUUPUHHHHHHHHHIIIICCIIIIIIIIISSSSSSSSSSSSIUUUUDDDDDDDDDDEJJJJJJJJJJJHHHHCCCLLLLLLLLQLYYYXXXXTTTTTTTTUUUU
IIIIIIIXPPPPPPPPDWWWWWDNNNNNGUUUUUUUUUUUUDHHHHHHHHHIICCCCCIIIIIIISSSSSSSSSSSSIIHUVDDDDDDDDDDFVVRRRRRRJJHHHHHHCCCCCLLLLLLLLYLXXXTTTTTTTTTUUUU
IIIIIIXXXPPPPPPPPPWWWWNNNNNNNUUUUUUUUUUUUUPPHHHHHHHLLLCCCCCCIIIIISSSSSSSSXIIIIIHHIDDDDDDDDDDVVVRRRRRRJHHHHHCHCCCCLLLLLLLLLLLLXXXXXTTTTTTUUUU
IIIXXXXXXOXPPPPPPPPPNNNNNNNNNUUUUUUUUUUUUBPPPHPPHLLLLLLCCCCCIIIIISSSSSSSSXXIXIIHHHDDDDDDDDDDKKVRRRRRRRRHHHHCCCCCCLLLLLLLLLLLLLXXXXTTTTTTTUUU
IIIXXXXXXXXPPPPPPPNNNNNNNNNNNNUUUUUUUUUPPPPPPHPPHLLLLLLCCCCIIIIIISSSSSSSSXFFXHHHHHDDDDDDDDDDKKKKKKKKRRRHRRRRRRRRCLLLLLLLLLLLLXXXXTTTTTUUUUUU
IIIXXXXXXTTPPPPPPPPNNNNNNNNNNNNUUUUUUUPPPPPPPPPPPTLLLLLCCCCCRIIIISSSSSSSSXFXXXHHHHDDDDDIIIIIKRKKKKKKRRRCRRRRRRRRCCLLLLLLLLLLLXXXXXTTTUUUUUUU
IIIIXXXXXXTTTPPTTTTTXNNNNNNNNNNNUUUUUDPPPPPPTTPPTTLLLLLCLLCRRRIRRSSSSSSSSXXXOXXHWHDDDDDHINNNKKKKKKKKRRRCRRRRRRRRCCCLLLLLLLLLLXXXXXXTLLLLUUUU
IIIIXXXXXXTTTTTTTTTTXNNNNNNNNNNNNUUUUUHHHHPPPTTTTTTLLLLLLCCRRRIRRSSSSSSSSXXXWWWWWWDDDDDHDNNNKKKKKKKKRRRCRRRRRRRRRRRRRLLLLLLLXXXXXXXXLLLUUUUU
IIIIXXXXXXTTTTTTTTTTTNNNNNNNNNNNNNNHHHHHHHHTTTTTTTLLLLLLLRHRRRRRRSSSSSSSSXXWWWWWWWDDDDDDDNKKKKKKKKKKKHHCCCRRRRRRRRRRRMLVVLLLXXXXXXXXXXLLLUUU
IIIIXXXXXXTTTTTTTTTTTTTNNNNNNNNNNNNNNNHHHTTTTTTTLLLLLLLLLRRRRRRRRRRRRQQXWXXWWWWWWWDDDDDDDDDDKKKKKKKKKHHCCCRRRRRRRRRRRMLTTXXXXXXXXXXXXXLLLLUU
IIIIXXXXXTTTTTTTTTTTTNNNNNNNNNNNNNNNHHHHHTTTTTTTLLLLLLLLLRRRRRRRRRRRRRWWWXXWWWWWWWWWHHDDDDDDDDDDDDKKKKHCCXRRRRRRRRRRRLLTTXXXXXXXXXLLLLLLLLUU
UUUUURXXXXTTTTTTTTTTTTCNNNNNNNNNSNNNHHHHHTTTTTTTTTTTLLLLLRRRRRRRRRRRRRWWWWWWWWWWWWWHHHFDDDDDDDDDXXXXKKHHXXRRRRRRRRRRRTTTTXXXXXXLXLLLLLLLLLUU
UUUUURXXQHHTTTTTTTTTTTCCNNNNNNBNENNHHHHHHTTTTTTTTTLTLLLLRRRRRRRRRRRRRRRWWWWWWWWWWWWHFFFDDDDDDDDXXXXXKXHHXXXXXCCRRRRRRTTTTTXXXOOLLLLLLLLLLLLU
UUUUUUXSHHHHTTTTTTTTTTCNNNNNNNNNENHHHHHHTTTTTTTTTTLLLLLLLLRRRRRRRRRRRRWWWWWWWWWFWWFFFFFDDDDDDDDXXXXXXXXXXXXXXCCRRRRRRTTTTTXOOOOLLLLLLLLLLLLU
UUUUUUUSSHHHHTTTTTATCCCKKKKKKKEEEHHEHHTHTTTTTTTTTTLLLLWLWLRRRWWRRRRRRRRWWWWWWWWFWFFFFFFDDDDDDDDDXXXXXXXXXXXXJJJRRRRRRTTTTTOOOOLLLLLLLLLLLLLU
UUUUUUUSHHHHHHTTTTTCCCCCCKKKKEEEEEHEEHTTTTTTTTTTTLLWLLWWWWMWWWWWRRRRRRRWWWWWWFFFFFFFFFDDDDDDDDDDXXXXXXXXXXXXJJJRRRRRRRTTTTTOOOOOFLLLLLLLLLUU
UUUUUUUHKHHHHHHHTHTZCCCCCKKEEEEEEEEEHHHTTTHHHHTTTLLWWWMWWWWWWWWWRRRRRWWWWWWWFKFFFFFFFFFDDDDDDDDDDXXXXXXXXXXXJJJTTTTRRRTOOOOOOOOOLLLLLLLLLLUU
UUUUUUUHHHHHHHHHHHTZCCZZNNEEEEEEEEEENNHHHHHHHHTTTLLWWWWWWWWWWWWWRRRRRWWWWWFFFFFFFFFFFFFDDDDDDDDDXXXXXXXXXXXXXJJTTWTRRROOOOOOOOOOOORLLLRLLUUU
UUUUUUUUUHHHHHHHHHTZZZZZNXXXXXXXXEEEENNHHNNUUUUUUWWWWWWWWWWWWWWWWIRRWWWWWWWFFFFFFFFFFUUXDDDWWDWDDXXXXXXXXXXXJJJTTTTRRROOOOOOOOOOORRRLLRUUUUU
UUUUUUUUHHHHHHHHHHTHHZNZZXXXXXXXXEEHHNNNNNNNUUUUUUWWWWWWWWWWWWWWWIIWWWZWWWWWFQQFFFFFFFUUDDDWWWWXXXXXXXXXXXXJJJTTTTTRRROOOOOOOOOOORRRRLRUUUUU
UUUUUUUUGHHHHHHHHHHHHHNNNXXXXXXXXEEEENNNNNNUUUUUUUUWWWWWWWWWWWWRDDZZZWZZWWWWQQQQFJFLFFUDDDXWWXXXXXXXXXXXXXXJJJRRRRRRRROOOOOOOOOOORRRRRRUUUUU
UUUUUUUUHHHHHHHHHCHHHHHHNXXXXXXXXENEEEENNNNUUUUUUUUUUWWWWWWWWWWWDGZZZZZZWZWWQQQQQFFFRFUUXXXXXXXXXXXXXXXXXRXXJJRRRRRRTTOOOOOOOOOOORRRRRRUUUUU
UUUUUUUUUHHHHHHHCCHHHHHHHXXXXXXXXNNEENNNNNNNUUUUUUUUUWWWWWWWWWWWDGDZZZZZZZZWZQQQQFFRRUUUXXXXXXXXXXXXXXXXXXXJJJRRRRRRTTTOOOOOOOOXGRRRRRUHUUUU
UUUUUUUUUHHHHHCCCHHHHHHHHXXXXXXXXNNNNNNNNNNNUUUUUUUUWWWWWWWWWWDDDDDZZZZZZZZZZQQQQQFRXXXXXXXXXXXXNXSSSSXXXYYGGTRRRRRRTOOOOOOOOHGGGGGRRRUUUUUU
UUUUUUUUUHHHEHQCCHHHHHHHHXXXXXXXXNNNNNNNNNNNUUUUUUUUWWWWWWWWWWDDDDDZZZZZZZZZZQQQQQQXXXXXXXXXXXXXXSSSSSXXYYYYGGRRRRRRWWOOOOOOOOGGGGGRRRUUUUUU
UUUUUUUUIHEEEQQQCHHHHHHHHXXXXXXXXNNNNNNNNNNNUUUUUUUUUWWWWWWWEEZDDDZZZZZZZZZZIZQQQQQXXXXXXXXXXXXXXSSSSSXYYYYSGGGGTWWTTWOODOOOGGGGGGGRRRRRUUUU
UUUUUUQKQQQQEQQCCCHHHHHHHXXXXXXXXXXXXXXXNNYYUUYUUUUUUUUWWWWEEEZZZZZZZZZZZZZZIZQQQQQXXXXXXXXXXXXXSSSSSSSSSSSSSGGOTWWWWWWVDDDOIGGGGGGGRRRRRUUU
VUUUUQQKQQLQEQQQCCHHHHHHHXXXXXXXXXXXXXXXNNBYYUYUUYUUUUWWWCWEEEEEZZZZZZZZZZZZZZZQQQQXXXXXXXXXXXXXSSSSSSSSSSSSSSOOSWWWWWVVVDGGGGGGGGGGGRRRRUUR
VUUVQQQQQQQQQQQQQCHHHHHHHHHNNNXXXXXXXXXXNXYYYYYUYYUUUUWWWWWWEEEEZZEZZZZZZZZZZZZQQQQQXXXXXXXXXXXSSXSSSSSSSSSSSOOOSWWWWWVVVVRRRRGGGGGRRRRRRRRR
VVVVQQQQQQQQQQQQQQXHHHHHHHHNHNXXXXXXXXXXXXXYYYYYYYUUUUEEEEEEEEEEEZEEZFZZZZZZZZZQQQQQXXXXXXXXXXXXXXSSSSSSSSSSSSSSSWWWWVVVVVVRRGGGGGGRRRRGGRRR
VVVVQQQQQQQQQQQQQQQHHHOHHHHHHNXXXXXXXXXXXXXYYYYYYYUUUUUEEEIIIIEEEEEEEFFZZZZZZQQQQQQQXXXXXXXXXXXXXXSXXSSSSSSSSSSSSWWVVVVVVVVVVGGGGGPGRRGGGRRR
VVQQQQQQQQQQQQQQQQQKHFOHHHHHNNXXXXXXXXXXXXBYYYYYYYTUUUUEEIIIIIEEETTTEEFFVZZZQQQQQQXXXXXXXXXXXXXXXXXXSSSSSSSSSSSSPVVVVVVVVVTTVTGGGGGGGGGGGGRR
VVQQQQQQQQQQQQQQQKKKOOOOOHHNNNXXXXXXXXXXXBBYYYYYYYYUUUUEEEIIIEEETTTEEFFFFFCCQQQQQQQXIXOXXXXXXXXXXXXXSSSSSSSSSSSSSVVVVVVVVVTTTTGGGGGGGGGGGRRR
VQQQQQQQQQQQQQQQQKQOOOOOONNNNNNNBBBBBBBBBBBYYYYYYYYEEEEEEEIIIIIETTTEFFFFCCCCQQQNNNNIINOXXXXXXXXXXXXXSSFSSSSSSQSSOQVVVVVVVVGGGGGGGGGGGGGRRRRR
VVQQQQQQKFQQQQQQQQQOOOOOOONNNNNNBBBBBBBBBBBYYYYYYYYYYEEEEEIIIIEETTTTFFFJFCCQQQQNNNNNNNNVVXXXXXXXXXSSSSFSSSSSQQQQQQQQVVVVVVVGGGGGGGGGGGGGGGRR
VVQQIIIQFFQQQQQQQQOOOOOOOONNNNNBBBBBBBBBBYYYYYYYYYYJJEEEEEIEIITTTTTTFFFFFFFQNNNNNNNNNNNAVXXXXXXXXXSSSFFFSSSSQQQXQQQQQVVVVVGGGGGGGGGGGGGGGGRR
VVVIIFFFFFFFQQQQQOOOOOOOOOOONNBBBBBBBBBBBYYYYYYYUYYYEEEEEEEEETTTTTTFFFFFFFQQNNNNNNNNNNNAXXXXXIXXXXSSFFFFSSFFQQQQQQQVVVVVVVGGGGGGGGGGUGGGURRR
VVVIIFFFFFFFFQQOOOOOOOOOOOOOOOEEEBBBBBBBYYYYYYYYYYUEEEEEEEETETTTTTCCFFFBFFNNNNNNNNNNNANAXXXXXIXXXSSSFFFFFFFFFQQQQQQSVVXVVVWGGGGGGGGGUGGUUURR
VVIIIFFFFFFFFQQOOOOOOOOOOOOOOOEEEEEBBBBBYYYYYYYYUUUEEEEEEETTTTTTTTCCFFFFFFNENNNNNNNNAAAAXXXXXXXXHAAFFFFFFFFFFQQQQQQQQLVVVVWWGGGGGGGGUHHHUUUU
VFFNIFFFFFFFFQQOOOOOOOOOOOOOOOEEEEEEEEEBBYSYYYYUUUUUHHEETTTTTTTTTTTFFFFTDTKNNNNNNNNNAAAAAUUUUUUUUAAAFFFFFFFFQQQQQQQQMMMQVVVURGGGGGGUUUUUUUUU
VFFFFFFFFFFFFFQOOOOOOOOOOOOOOEEEEEEEEEEEEUUUUYUUUUUUUHEEETTTVVVVVVVTFFFTTTKKKNNNNNNBAAAAAUUUUUUUUAAAFFFFFFFFQQQQQQQMMMMMVVUUUGGDDDDUUUUUUMUU
VVVFFFFFFFFNNNNNNNOOOOOOOOOOEEEEEEEEEEEEUUUUUUUUUUUUUUEEVVVVVVVVVVVVTTTTTKKYNNNNNNSAAAAAAUUUUUUUUAAFFFFFFFFFQQQQQQQSMMMMMRUUUUGGGDUUUUUUUUWW
VVVFNNNNNNNNNNNNNNOOOOOOOOOOOEEEEEEEEEEEKUUUUUUUUUUUUUKKVVVVVVVVVVVVVSTTTKYYYNYNNFAAAAAAAUUUUUUUUAAAFFFFFFFFQQQQQQQQMMMMMRRUUUGUUUUUUUUUUUUU
IIIINNNNNNNNNNNNNNOOOOONOOOOOEEEEEEEEEEEUUUUUUUUUUUUUUUUVVVVVVVVVVVVVPPTTTTYYYYYYAAAAUUUUUUUUUUUUAAHZFFFFFFFZQQQQQJMMMMMMMUUUUUUUUUUUUUUUUUH
IIIFNNNNNNNNNNNNNNOOONNNOOOEEEEEEEEEEEEEGUUUUUOUUUUUUKUUVVVVVVVVVVVVVPPYYYYYYYYYYJAAQUUUUUUUUAAAAAHHHHFFFFFFQQQQQQMMMMMMMMMUUUUUUUUUUUUUUUUU
IIIINNNNNNNNNNNNNNZNNNNNNNONEEEEEEEEEEEEGGEEUUOUUUIIIVVVVVVVVVVVVVVVVYYYYYYYYYYYJJCBBUUUUUUUUHHAAAHHHFFFFFFFFFQQQQCMMMMMMMUUUUUUUUUUUUUUUUUU
IIIINNNNNNNNNNNNNNNNNNNNNNNNNNEEEEEEEEEGGGEEUOOOIIIIIVVVVVVVVVVTTTTTYYYYYYYYYYYYYJJJBUUUUUUUUHHAHHHHHFFFFFFFFFQQQQCMMMMMMMUUUUUUUUUUUUUUUUUH
IIINNNNNNNNNNNNNNNNNNNNNNNNNNNNNEZZEEEEEGGEEEOOOKKIIIVVVVVVVVVVTTDDQYYYYYYYYYYYYYJJJJUUUUUUUUHHHHHHHHFFFFFFFNQQQQQMMMMMMMRMMUUUNUUUUUUUUUUHH
IIINNNNNNNNNNNNNNNBNNNNNNNNNNNNNZZZZZEEVGGGEEOOOKKKKKVVVVVSGGGTTTDQQYYYYYYYYYYYYJJJJJUUUUUUUUHHHHHHHVFFFFFFFFQQQQQQMMMMMMMMSUSUUUUUUUUUUUHHH
IIINNNNNNNNNNNNNNNNNNNNNNNNNNNNNZMZZEEEEOOEEEOOOOOKKKVVVVVSSSGGGQQQQQYYYYYYYYYYYYAAAAUUUUUUUUUUUUUUHHHFFFFFGGGQQQQQQMMMMMMMSMSUUKKKUUUUUHHHH
IIINNNNNNNNNNNNNNNBNNNNNNNNNNNNNZMMZZZOOOSOOOOOOOOKKKVVVVVSSSGSSSQQQQQQYYYYYYYYAAAAAAAAAAAAHUUUUUUUHGGFFFGGGGGGGQQGGMMMMMMMSMMEEEEEUUUUUHHHH
IIINNNNNNNNNNBBBBBBNNNWNNNNNNNNNMMMMOOOOOOOOOOOOOOOOKKKKSSSSSGSKQQQQQQQQYYYYYYYYAAAAAAAAAAAFUUUUUUUGGGGFGGGGGGGGQQGGMMMMMMMMMMEEEEEUUUUHHHHH
IIINNNIEJENNNBBBBBNNNNNNNNNNNNNMMMMMOOOOOOOOOOOOOOOKKKKSSSSSSSSSSSQQQQRQYYYYYYYYYYAAAAAAAAFUUUUUUUUGGGGGGGGAAAGGGGGMMMMMMMMMMMMEEEEUUHHHHHHH
IIINNNYYYYYPBBBBBBBNNFNNNNNNMMMMMMMMOOOOOOOOOOOOOOORRRSSSDRSSSSSSQQQQQQQQYYYYYYYYAAAAAAAAAFUUUUUUUUGGGGGGAAAAHAGGAAMMMMMZZMMMEEEEEEUUHHHHHAA
IIINNNYYYYYYYLBBBBNNHHHHNNMMMMMMMMMMMOOOOOOOOOOORRRRRRRRSSRRSSSSHQQQQQQQQYYYYYYYYYYAAAAAAAFUUUUUUUCGGGAAAAAAAAAAGAAMMMMZZZMEEEEEEEEUAAHHAAAA
IIIIYYYYYYYLLLBBBBBBHHHHHNNGMMMMMMMMMOOOOOOOOOOORRRRRRRRRRRRZRSRROQQQQQQQYYYYYYYYYAAAAAATTTUUUUUUUCCGAAAAAAAAAAAAAAMMMMMMMEEEEEEEEEEAAAAAAAA
IIIIIYYYYQQQLBBBBBBBHHHHHHHHHHMMMMMMMOOOOOOOOOORRRRRRRRRRRRRRRRRROQQQQQQQYYYYHYYYAAAATTTTTTUUUUUUUUCAAAAAAAAAAAAAMMMMMMMMMMEEEEEEEEEAAAAAAAA
IIYIIYYYYYQLLLBBCCBHHHHHHHMMHHMMMMMMMOOOOOOORRRRRRRRRRRRRRRRRRRROOOOOOQQQYYYHHHYYAAAAAATTTTTTTUUUUUCCCAAAAAAAAAAAMMMMMMMMVVVEEWWEEEEAAAAAAAA
YYYIIYYYYYQYYYCCCBBHHHHHHHHMMMMMMMMMMOOOOOOOOGRLYRRRRRRRRRRRRRRBOOOOOOONNNNYHHHHHAAAATTTTTTTTTUUUUUCCCAAAAAAAAAAAMMMMMMMVVVVVWWWWEEEAGGAAAAA
YYYYIYYYYYYYYYYCHIHHHHHHHHHMMMMMMMMMMMOOOOOOOGRRYYRRRRRRRRRRRROOOOOOOOOOHNHHHHHHHHHAAAAATNTTTTUUUUUCCCCCAAAAAAAAAAAMMMMMMMVVWWWWWEWWWWGAAAAA
YYYYYYYYYYYYYCCCHHHHHHHHHHMMMMPMMMMAMMMMOOOOOYYYYYRRURRRRRRRQQQOOOOOOOOOHHHKHHHHHHAAAAAATNTTTTUUUUUCCNCCAAAAAAAAAAAMMMMMMMMVWWWWWEWWWWGAAAAA
YYYYYYYYYYYYYCCCCHHHHHHHHMMMMMPMMMMAAMMMMOOOSYYYYYYYURRRRRRRQOOOOOOOOOOOOOHHHHHHHHHAAAAANNETTTTTWWWWWNNXAAAAAAAAAAAMMMMMMLWWWWWWWWWWWGGAAAAA
GYYYYYYYYYYYYCCCCHHHHHHHPMMMPPPPPMMAHMMMMSSSSSYDYYWWUURZZRVQQOOOOOOOOOOOOOHHHHHHHHHAAAAANNNNCTNTTWWNNNNXAAAAAAAAZZZZMMMZWWWWWWWWWWWWWGAARAAA
YYYYYYYYYYYYYYCCCHHHHPPZPPPPPPPPMMAAAAATMASSSYYYWWWWWRRRZVVVQOOOOOOOOOOOOOOOOHHHHHHJNNNNNNNNNENWWWWNNNNXNAAAAAAAAZZZZMMZZWWWWWWWWWWWWGAAAAAA
YYYYYYYYYYYYYCCCNHHHPPPPPPPPPPPPMMAAAAATTASSWPYYWWWVWZRZZVVQQOOOOOOOOOOOUOOUUUHHHHHJNNNNNNNNNNNNFWWNNNNNNNNAAAAAAZZZZZZZZWWWWWWWWWWWGGAAAAAA
OYYYYYYYYYYCCCCCNNNNNNPPPPPPPPPPMMMAAAAAAAAAWWYWWWWWWZZZPQCCCCCCCCCOOOOOUUUUUUJHJJJJJNNNNNNNNNNZFFFFNNNNNNZAAAAAZZZZZZZWWWWWNNDWDGGGGGAAAAAA
OYYYYYYYYYXNNNNNNNNNSSPPPPPPPPPPMJAAAAAAAAAAWWWWWWWWZZZPPQCCCCCCCCCOOOOBBUUUUUJJJJJJJNNNNNNNNNZZZZZZZNNNNNZZAAZZZZZZDDDDDWDDDDDDDGGGGGGAAAAA
OYYYYYXXXXXOONNNNNNNSSSSPHPPPPPJPJJJAAAAAAAAWWWWWWWWZZZPPPCCCCCCCCCOOOBBUUUUUUJJJJJJJNNNNNNNNNNZZZZZZNNNZZZZAZZZZZZZZDDDDDDDDDDDDGGGGGAAAOOA
OOYYYIXXXMXOXXXNNNNNSSSSSPPPPPJJJJJJAAAAAAAAWWWWWWWWZZZPPPCCCCCCCCCOOOOBUUUUUUJJJJJJNNNNNNNNNNNZZZZZZZNNZZZZZZZZZZZZZDDDDDDDDDDDDDDGGFHHAOOO
OYYOOXXXXMXXXXNNNNNNNSSSSPPPJJJJJJJJAAAAAAAAWWWWWWWWWZZPPPCCCCCCCCCKKOBBKUUUUUJJJJJJNNNNNNNNNZZZZZZZZZZZZZZZTZZZZZZZZDDDDDDDDDDDDDGGFFHHAOFF
OOOOOXXXXXXXXXXNNNNNNSSSSSSPPJJJJJJJJAAAAIIWWWWWWZZZZZZPPPCCCCCCCCCKPBBKKKUUUJJJIINNNNNNNNNNNNZZZZZZZZZZZZZZTZZZUUUUUDDDDDDDDDDDDDFGFFHHFFFF
OOOOXXXXXXXXXXNNNNNNNSSSSSSPJJJJJJJJJAAAVDWWDWWWWWZZZZZPPPCCCCCCCCCPPKKKKKUUJJJJIIJNNZZZNNNNNNZZZZZZZZZTTTZTTTTUUUUUUWDDDDDDDDDDDKFFFFFHFFFF
XXXXXXXXXXXXNNNNNNNHDHHHHSSPJJJJJJJJJJADDDDDDWWWWWWZZZZPPPPPPPPPPPPPXKKKKKUJJHHHHIIINZZNNNNNNZZZZZZZZZZTTTTJTTTTUUSUWWDDDDDDDDDDDFFFFFFFFFFF
XXXXXXXXXXXXNNNNNNNHHHHHHHHHJJJJJJJJJJDDDDDDDWWWWWLZZZZZZPPPPPPPPPPPPKAKKKUUUHHIIIIINNZZZNNNNZZZZZZZZZZZBTTTTTTTUUUWWWWDDDDDDDDDDIFFFFFFFFFF
XXXXXXXXXXXXKKKNNNNHHHHHHHHHJJJJJJJJJDDDDDDDDDDLLLLZZZPPPPPPPPPPPPPPPPAAAKUUEHHIIIIIIIZZZZNNNNSZZZZZZZZZZTTTTTTTUUUWWWWWDDDDDDDDDFFFFFFFFFFF
XXXXXXXXXXXKKKNNNNNHHHHHHHHHHHJJJJJJDDDDDDDDDDDLLOOZZZZZZPPPPPPPPPPPUPAAAEUDEEEEMMMIIIIZZZNNNSSZZZZZZZZZZTTTTTTTTTWWWWOWDDDDDDIDFFFFIFFFFFFF
XXXXXXXXXXKKKNNNNNNNHHHHHHHHHHZJJJJJJTDDDDDDDDDLOOOOOPPPPPPPXXXXGXXXUUEEEEDDEEEEMMMMMMIMZZZZZZZZZZZZZZZZLLTTTTTTTTWWWOODDDDDDDIIIIIFFFFFFFFF
XXXXXXXXXXKKKNNNNNNNHHHHHHHHHHHHHHLLLLLLLLLLDDDDOOOOOOOPPPPPXXXXXXXEUUUEEEEEEEEEMMMMMMMMMZZZZZZZZZZZZZLLLTTTTOOTTWWOOOOKKDDDDDIIIIIFFFFFFFFF
XXXXXXXXXKKKKKNOOHHHHHHHHHHHHHHHRRLLLLLLLLLLDDDDOOOOOOPPPXXXXXXXXXXEEUUEEEEEEEEMMMMMMMMMGMZZZZZZZZZZZZZLLLTTTOOOOOOOOOOOKQQQQIIIIIIFFFFFFFFF
XXXXXXXXXXKPKKKOOHHHHHHHHHHHHEHRRRLLLLLLLLLLBSDDOOOOOOOPPIXXXXXXXXEEEEEEEEEEEEEEEMMMMMMMMMMMZZZZZZZZZZZLLLTETOOOOOOOOOOQQQQQIIIIIIIIFFFFFFFF
XXXXXXWXXXKPPPKOPYHHHHHHHHHHHHRRHRLLLLLLLLLLBSQDOOOOWPPPXIXXXXXXXXXEEEEEEEEEEEEEMMMMMMMMMMMMZZZZZZZZZZZZLLOOOOOXOOOQQQQQQQQQQQQSSSSSSFFFFFFF
SSSSSSXXSSKPPPPPPYHHHHHHHHHHHHHHHHLLLLLLLLLLSSQOOOOOOPPPXXXXXXXXXXXXEEEEEEEEEEEMMMMMMMMMMMMMZZZZZZZZZZZLLLLOOOOXOXOOQQQQQQQQQQQSSSSSSFFZFZZZ
SSSSSSSSSSKKPPPPPPYHHYYHHHHHHHHXHHHHTHHTDDSSSSOOOOOOOOPPXKKKKKKKKXXXXEEEEEEEEEEMMMMMMMMMMZZZZZZZZZZZIZZLLLLXXXXXXXQQQQQQQQQQGGGGSSSSSZZZZZZZ
SSSSSSSSPPPPPPPPPYYHHYHHYYYHHOHHHHHHHHHSSSSSSSSSOOTTONYVXKKKKKKKKXXXEEEEEEEEEEEMMMMMMMMMMMMZZZZZZZZZZZLLLLLLXXXXXXQQQQQQQQQQQGGSSSZSZZZZZZZZ
SSSSSSSSSBPPPPPPYYYYYYHYYYYHHHHHHHHHHHHSSSSSSSSSUTTOONYYYKKKKKKKKXXEEEEEEEEEEMMMMMMMMMMMMMMMZZZZZZZZZZLXXXXXXXXXXQQQQQQQQQQQSSSSZZZZZZZZZZZZ
SSSSSSSSSSBPPPPPYYYFYYYYYYYYYOOHHHHHHHHHHSSSSSSUUUUUYYYYYKKKKKKKKXXAAEEEEEEEEEEMMMMMMMMMMMMZZZZZZZZZZZXXXXXXXXXXXQQQQQQQQQQNNNSSZZZZZZZZZZZZ
SSQQSSSSSSPPPPPPFYFFFYYYYYOYOOOHHHHHHHHHSSSSSSSLUUUUYYYYYKKKKKKKKXXAAEAPEEEEEEEMMMMMMMMMMMZZZZZZZZPZZXXXXXXXXXXXXXQQQQQQTZZZZZZOZZZZZZZZZZZZ
SSQQQQQQSSQQQPFFFFFFYYYYYYOOOOOHHHHHHHHHSSSSSSUUUUYYYYYYYKKKKKKKKAXAAAAAESEEEEMMMMMMMMMMMMMMZZZZZPPPXXXXXXXXXXXXXXQQQTTTTZZZZZZZZZZZZZZZZZZZ
SSQQQQQQQQQQQZZFFFFYYYYYYYOOOOOOHHHHHHHHSSSSSUUUUUUYYYYYYKKKKKKKKAAAAAAAEEEEEEEMMMDMMZMMDSSSWZWWPPWWBXXXXXXXXXXXXQQQQTTTTTZZZTTZZZZZZLZZZZZZ
SSQQQQQQQQQQQQZIFFFFYYYYYOOOOOOOHHHHHOSSSSSSSSSUUUZZYYYYYKKKKKKKKAAAAAAEEEEEEEEDMDDDDDDDDSWWWWWWWWWWWXXXXXXXXXXXXXQQQTTTTTTZTTTTZZZLLLZZZZZZ
QSQQQQQQQQQQQQZFFFFFYYYYYYOOOOOOOOHHHOOSSSSSSSUUUZKKKKKKKKKKKKKKKKAAAAAAACEDDEEDDDDDDDDDDDWWWXWWWWWWWXXXXXXXXXXXXXQQQTTTTTTTTTTZZZZZLZZZZZZZ
QQQQQQQQQQQQQQZZFFFFYYYYYYYOOOOOOOHOOOOOOOSSSSWWUZKKKKKKKKKKKKKKKKAAAAAAAAADDDDDDDDDDDDNNDNWWWWWWWWWWWWXXXXXXXXXXXQQQTTTTTTTTZZZZZZZZZZZZZZZ
QQQQQQQQQQQQQFZZFFFFYYYYYYYOOOOOOHHHOOOOOOOOYSWWUZKKKKKKKKKKKKKKKKQQQAAAAAADDDDDDDDDDDDNNNNWWWWWWWWWWWWXXXXXTXXXXQQQQTTTTTTTTTZZZZZZZZZZZZZZ
QQQQQQQQQQQQQQFFFFFFFYYYYYYOOOOOOOOOOOOOOOOOYWWWWWKKKKKKKKKKKKKKKKQNNDNAAAADDDDDDDDDDDNNWWWWWWWWWWWWWWWWWWTTTTXXXXTTQZZTTTTTTTZZZZZZZZZZZZZZ
QQQQQQQQQQFQFFFFFFFFFYYYYYYOOOOOOOOOOOOOOOOOOWWWWWZZZZYOOKKKKKKKKQNNNNNQAAADDDDDDDDDDDDYYWWWWWWWWWWWWWWWWTTYYXXXXTTTTTTTTTTTTTTTTZZZZZZZZZZZ
QQQQQQQQQFFFFFFFFFFFFYYYYYYOOOOOOOOOOOOOOOOWWWWWWWWWWWIOOKKKKKKKKQNNFNNQQQDDDDDDDDDDDDDYYWWWWWWWWWWWWWWWWTTYYYYXTTTTTTTTTTTTTTTTTZZZZZZZZZZZ
QQQQQQQQQFFFFFFFFFFFFYYYYYYOOOOOOOOOOOOOOOOOOWWWWWWWWWIOOKKKKKKKKQQNNNNQQQDDDDDDDDDDDDDYYYYOWWWWWWWWWWMWTTTYYYYYTTTTTTTTTTTTTTTTTZZZZZZZZZZZ
QQQQQQQQQFFFFFFFFFFFFYYYYYYOOOOOOOOOOOOOOOOOWWWWWWDWIIIIOKKKKKKKKQQQNQQQQDDDDDDEDDDDDDDYYYYOWWWWWWWWWWMWWTTTTTTTTTTTTTTTTTTTTTTTTZZZZZZZZZZZ";
    }
}