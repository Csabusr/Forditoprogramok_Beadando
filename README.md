# Forditoprogramok_Beadando

<div style="text-align: center">
<h1>Help</h1>

G = ({E, E’, T, T’, F}, {+, *, (, ), i}, P, E)

S -> E# <br>
E’ -> +TE’ | e <br>
T -> FT’ <br>
T’ -> *FT’ | e <br>
F -> (E) | i <br>
</div>
<hr>

A nyelvtan segítségével a következő kifejezések validálhatók:
<div style="font-weight: bold; text-align: center">
( 3 * 3 ) + 2 
</div>
A kifejezéseket egyszerűsíteni kell a következő formában:

pl.: ( 3 * 4 ) + 2 kifejezésből az ( i + i ) * i egyszerűsített formulát kell létrehozni a következő reguláris kifejezéssel:


expressionstring = Regex.Replace(expressionstring, ”[0-9]+”, ”i” );
<div style="font-weight: bold; text-align: center">
i + ( i * i ), i + i, i * i, ...
</div>
A szabályrendszer alkalmazásához az alábbi táblázatot kell használni. 

![](doc/Pic%201.jpg)

A program a következő módon működik:

Az algoritmus
1.	Szükség van egy input szalagra, ami egy string típusú változó és egy int típusú változóra az input indexeléséhez. 
2.	A táblázatot tárolni kell egy StringGrid, vagy hasonló típusú kontrollban. A tárolás történhet grafikusan, vagy egy n*m-es string mátrixban.

3.	Szükség van egy Stack típusú változóra. Az elemzés során ebbe a verembe terminális és nemterminális jelek kerülnek bele. A verem kezdetben a szabályrendszer start szimbólumát tartalmazza (E).
4.	Az input változó kezdetben a teljes elemzendő kifejezést tartalmazza. Pl.: String input = ”(i+i)*i#”. Az input kifejezés végére egy # jelet kell elhelyezni.
5.	A működési ciklus a következő: Be kell olvasni a soron következő elemet (minden lépésben az i index alapján az aktuális karaktert) az input szalagról.
6.	Ki kell venni a verem legfelső elemét (POP művelet).
7.	Az így kapott adatokat sor és oszlopindexnek kell használni a szabályokat tartalmazó mátrix indexeléséhez.
8.	Az így azonosított cellából vegyük ki az ott található elemet (a mátrixnak az az eleme, amit a két kiolvasott elem alapján azonosítunk).
9.	Pl.: ha az input string aktuális eleme a +, a veremben pedig az E’ nemterminális elem található, akkor az azonosított cella a (+TE’, 2), ahol a vessző bal oldalán egy szabály jobb oldala, a vessző jobb oldalán pedig a szabály sorszáma található.
10.	Az azonosított cellában 4 féle elem fordulhat elő.
There are 4 types of items that can occur in an identified cell.
* Ha a cella üres, az azt jelenti, hogy a kifejezésben hibát találtunk.
Ha a cella az elfogad szót tartalmazza, akkor a végére értünk az elemzésnek, és a kifejezés helyes.
* Ha a pop szó található a cellában, akkor el kell távolítani a verem tetején található elemet (egy karaktert, ami lehet terminális, vagy nemterminális jel), és az indexet léptetni kell, vagyis megnövelni az index változó értékét eggyel.
* Ha a cella egy zárójeles szabályt tartalmaz, akkor:
* El kell távolítani a zárójeleket.

11.	a vessző bal oldalán található szabályt és a jobb oldalán található sorszámot be kell tenni egy-egy változóba (pl.: a string[] elemek = String.Split(elemek, ”,”) metódussal).
A vessző bal oldalán található szabályt karakterenként a verembe kell helyezni.
A szabály sorszámát el kell tárolni egy listába. Ezt az adatot nem használjuk, de a segítségével elő lehet állítani a program szintaxis fáját.
Az 5-10 lépéseket addig kell ismételni, amíg el nem érjük az input végét, vagy hibát nem találunk.
Amennyiben a működési ciklus végén a verem üres, és az input szalag végére értünk, a kifejezés helyes.
Ezt úgy is megállapíthatjuk, ha a két változó által azonosított cella a szabályokat tartalmazó mátrixban az elfogad szót tartalmazza.

A programnak folyamatosan mutatnia kell a lépéseket egy rendezett hármasban (tuple, ordered triplet) a következő formában:

<div style="font-weight: bold; text-align: center">
( i+i*i#, E, emptylist ) initially
</div>
ezután minden lépésben:
<div style="font-weight: bold; text-align: center">
( +i*i)#, +TE’#, 14862) 
</div>
ahol<br>
●	az első elem az aktuális input szalag maradék része,<br>
●	a középső elem a verem aktuális tartalma,<br>
●	a jobboldali elem pedig az eddig alkalmazott szabályok sorozata.<br>

A programot megvalósíthatjuk grafikus felület használatával, vagy console application formában. A programozási nyelv nincs kikötve de javasolt a C#, vagy a Java nyelvek használata.

Meg kell oldani, hogy a szabályokat tartalmazó táblázat alapértelmezetten tartalmazza a minta táblázatot, de az elemeit a felhasználó tudja szerkeszteni.

Az input kifejezést a felhasználó tudja megadni. Ha a felhasználó a kifejezés végére nem ír # jelet, akkor a program ezt pótolja helyette.

Egy példa a program levezetésére:
![](doc/Pic%202.jpg)
![](doc/pic3.jpg)
<div style="font-weight: bold; text-align: center">
(i+i*i#, E#, e)<br>
(i+i*i#, TE’#, 1)<br>
(i+i*i#, FT’E’#, 14) pop<br>
(+i*i#, E’#, 1486)<br>
(i*i#, TE’#, 1486)....<br>
error -> hiba van<br>
(#, #, 1486....) -> elfogad<br>
</div>


Az input szalag tartalmazza az i+i*i kifejezést. A veremben az E szimbólum található. Ez a szabályrendszer start szimbóluma.

Kivesszük a legfelső elemet a veremből. Ez az “E” nemterminális jel. Kiolvassuk at index által mutatott karaktert (az első karakter az első lépésben). Ezt a két elemet úgy használjuk a táblázatban, mint sor és oszlopindex. A két index a következő cellát azonosítja: (TE’, 1).
![](doc/pic4.jpg)

A zárójeleket eltávolítjuk. A vessző bal oldalán található karaktereket egyesével a verembe helyezzük. Így a rendezett hármas tartalma a következő lesz:
( i+i*i#, TE’#, 1), mivel az input nem változik, a veremből töröljük a már indexelésre használt legfelső elemet, helyére beírjuk a cellából vett szabály karaktereit, és felírjuk az alkalmazott szabály sorszámát.

A következő lépésben újra kivesszük a verem legfelső elemét, és az index által mutatott elemet az input string-ből. Ez jelenleg még az első elem, mert az indexet nem léptettük. A verem tetején most a T nemterminális található.

A két elem által mutatott cella a következő: (FT’, 4). Megismételjük az előző lépéseket.
Ha a cella nem szabályt, hanem a pop kifejezést tartalmazza, akkor növeljük az index értékét, és töröljük a verem legfelső elemét.
The cell indicated by the two elements is: (FT ’, 4). Repeat the previous steps.<br>

●	Ha a cella üres, akkor hibát találtunk, megállíthatjuk az elemzést.<br>
●	Ha a cella az elfogad szót tartalmazza, akkor megállhatunk, a kifejezés helyes..<br>
●	Ha egy szabály az epsylon (e) kifejezést tartalmazza, akkor ezt nem kell a verembe írni.<br>

A lépéseket ismételve a fenti levezetést kapjuk. A program megírása előtt papíron, tollal, vagy ceruzával érdemes az elemzést levezetni.
