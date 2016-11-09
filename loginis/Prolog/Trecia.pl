/*1.6 2.7 3.5 4.1*/
/*1.6  tr_suma(Sar,Sum): duotajame saraše Sar galima rasti tris iš eiles einancius skaicius, kuriu suma lygi Sum.*/
/*trSuma([1,5,7,8,9,7,5], 24).*/
/*--Pirma---------*/
sarasas([Pradzia|Likutis], Pradzia, Likutis).
trSuma(Sarasas, Suma):-
	          sarasas(Sarasas, PirmasDemuo, LikutisPirmas),
	          sarasas(LikutisPirmas, AntrasDemuo, LikutisAntras),
		  sarasas(LikutisAntras, TreciasDemuo, _),
		  Suma is PirmasDemuo + AntrasDemuo + TreciasDemuo;
		  sarasas(Sarasas, _, LikutisPirmas),
		  trSuma(LikutisPirmas, Suma).
/*-------Antra------------*/
/*Skaicius Skaic atitinka duota dešimtainiu skaitmenu saraša Sar.
 des_skaic ([1,9,8,5],1985).*/
listToNumber([SarasoPradzia|SarasoPabaiga], Skaicius):-
	listTonumber(SarasoPabaiga, Skaicius, Temp),
	SarasoPradzia =:= mod(Temp, 10).
listToNumber([],X,Z):- Z is X.




/*-------Trecia-------------*/
/*sarašas R - pirmuju duoto sarašo S   K elementu sarašas.
	pirmieji([a,b,c,d,e],3,[a,b,c]).*/
pirmieji([PirmasPradzia|PirmasLikutis], Kiekis, [AntrasPradzia|AntrasLikutis]):-
                            KiekisN is Kiekis-1,
			    KiekisN =:= 0,
			    lygu(PirmasPradzia,AntrasPradzia),
			    AntrasLikutis is  123;
			    KiekisN is Kiekis-1,
			    lygu(PirmasPradzia,AntrasPradzia),
			    pirmieji(PirmasLikutis, KiekisN, AntrasLikutis).

lygu(X,X).
/*---------Ketvirta------------------*/
/*Saraše S yra K vienas po kito einanciu vienodu elementu E
	kart([a,a,c,a,b,b,b,b,a,g],4,b).*/
kartSim([SarasasPradzia|SarasasLikutis], Kiekis, Simbolis):-
	KiekisN is Kiekis -1,
	KiekisN =:=0,
	lygu(SarasasPradzia, Simbolis);
	KiekisN is Kiekis -1,
	lygu(SarasasPradzia, Simbolis),
	kartSim(SarasasLikutis, KiekisN, Simbolis).

kart([SarasasPradzia|SarasasLikutis], Kiekis, Simbolis):-
	lygu(SarasasPradzia, Simbolis),
	kartSim([SarasasPradzia|SarasasLikutis], Kiekis, Simbolis);
	kart(SarasasLikutis, Kiekis, Simbolis).


