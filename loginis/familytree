/*Migle Pucetaite, PS4, 3gr., 1310521, 1užd.: 19,25,32,37 */
/*19 is_vienos_seimos(rimantas, rima, migle).
     is_vienos_seimos(albinas, daiva, jovita).*/
/*25 vaikas(rima, migle).
     vaikas(ugnius, migle).*/
/*32 tmbml(andrius, audrius, mikas).
     tmbml(andrius, audrius, tomas).*/
/*37 klaida_duomenyse(jovita).
     klaida_duomenyse(dalius).*/

asmuo(vanda, mot, 75, siuvinejimas).
asmuo(antanas, vyr, 76, kates).
asmuo(stase, mot, 73, maistas).
asmuo(vytautas, vyr, 77, arkliai).
asmuo(bronius, vyr, 52, alus).
asmuo(rasuole, mot, 49, parduotuve).
asmuo(rimantas, vyr, 48, zvejyba).
asmuo(rima, mot, 49, kalbejimas).
asmuo(euginijus, vyr, 47, plaukimas).
asmuo(albinas, vyr, 53, rukimas).
asmuo(daiva, mot, 12, siuvimas).
asmuo(jovita, mot, 21, zaidimai).
asmuo(ugnius, vyr, 25, zaidimai).
asmuo(migle, mot, 22, logika).
asmuo(ugne, mot, 20, bendravimas).
asmuo(dalius, vyr, 26, zaidimai).

asmuo(andrius, vyr, 10, limonadas).
asmuo(audrius, vyr, 10, limonadas).
asmuo(mikas, vyr, 10, limonadas).
asmuo(mantas, vyr, 10, gele).
asmuo(tomas, vyr, 20, limonadas).
asmuo(lina, mot, 10, limonadas).



mama(vanda, rasuole).
mama(vanda, rimantas).
mama(stase, rima).
mama(stase, eugenijus).
mama(stase, albinas).
mama(rasuole, jovita).
mama(rima, migle).
mama(rima, ugne).
mama(daiva, dalius).
pora(antanas, vanda).
pora(vytautas, stase).
pora(bronius, rasuole).
pora(rimantas, rima).
pora(albinas, daiva).
pora(ugnius, migle).

vaikas(Vaikas, Suauges) :- mama(Suauges,Vaikas); pora(Suauges, Mama), mama(Mama, Vaikas).
is_vienos_seimos(Tetis, Mama, Vaikas) :- mama(Mama,Vaikas), pora(Tetis, Mama).
tmbml(Pirmas, Antras, Trecias) :-
	asmuo(Pirmas,Lytis1,Amzius1,Pomegis1),
	Lytis1 = vyr,
	Amzius1  < 15,
	Pomegis1 = limonadas,
	asmuo(Antras,Lytis2,Amzius2,Pomegis2),
	Lytis2 = vyr,
	Amzius2  < 15,
	Pomegis2 = limonadas,
	asmuo(Trecias,Lytis3,Amzius3,Pomegis3),
	Lytis3 = vyr,
	Amzius3  < 15,
	Pomegis3 = limonadas,
	Pirmas \= Antras,
	Antras \= Trecias,
	Pirmas \= Trecias.


klaida_duomenyse(Asmuo) :-
	mama(Mama, Asmuo),
	asmuo(Asmuo, _X1, Amzius1,_X2),
	asmuo(Mama, _X3, Amzius2, _X4),
	Amzius1 > Amzius2;
	mama(Mama, Asmuo),
	pora(Tetis, Mama),
	asmuo(Asmuo, _X1, Amzius1,_X2),
	asmuo(Tetis, _X3, Amzius2, _X4),
	Amzius1 > Amzius2.
